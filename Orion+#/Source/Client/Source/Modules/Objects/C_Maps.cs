
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ASFW;
using ASFW.IO;
using Microsoft.VisualBasic.CompilerServices;
using System.Threading;
using Engine;
using SFML.Graphics;

namespace Engine
{

    sealed class C_Maps
    {

        #region Globals & Types

        internal static C_Types.MapRec Map;
        internal static object MapLock = new object();
        internal static C_Types.MapItemRec[] MapItem = new C_Types.MapItemRec[Constants.MAX_MAP_ITEMS + 1];
        internal static C_Types.MapNpcRec[] MapNpc = new C_Types.MapNpcRec[Constants.MAX_MAP_NPCS + 1];
        internal static C_Types.TempTileRec[,] TempTile;

        public static SFML.Graphics.Sprite[] mapLayers;
        public static SFML.Graphics.Sprite[] fringeMapLayers;

        #endregion

        #region DataBase

        internal static void CheckTilesets()
        {
            int i = 0;
            i = 1;

            while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "\\tilesets\\" + Convert.ToString(i) + C_Constants.GfxExt))
            {
                C_Graphics.NumTileSets++;
                i++;
            }

            if (C_Graphics.NumTileSets == 0)
            {
                return;
            }
        }

        public static void ClearMap()
        {

            lock (MapLock)
            {
                // We are clearing the map, so lets also clear the Cache
                mapLayers = null;
                fringeMapLayers = null;

                Map.Name = "";
                Map.Tileset = 1;
                Map.MaxX = C_Constants.ScreenMapx;
                Map.MaxY = C_Constants.ScreenMapy;
                Map.BootMap = 0;
                Map.BootX = 0;
                Map.BootY = 0;
                Map.Down = 0;
                Map.Left = 0;
                Map.Moral = 0;
                Map.Music = "";
                Map.Revision = 0;
                Map.Right = 0;
                Map.Up = 0;

                Map.Npc = new int[Constants.MAX_MAP_NPCS + 1];
                Map.Tile = new Types.TileRec[Map.MaxX + 1, Map.MaxY + 1];

                for (var x = 0; x <= C_Constants.ScreenMapx; x++)
                {
                    for (var y = 0; y <= C_Constants.ScreenMapy; y++)
                    {
                        Map.Tile[x, y].Layer = new Types.TileDataRec[(int)Enums.LayerType.Count];
                        for (var l = 0; l <= (int)Enums.LayerType.Count - 1; l++)
                        {
                            Map.Tile[x, y].Layer[l].Tileset = 0;
                            Map.Tile[x, y].Layer[l].X = 0;
                            Map.Tile[x, y].Layer[l].Y = 0;
                            Map.Tile[x, y].Layer[l].AutoTile = 0;
                        }

                    }
                }

            }

        }

        public static void ClearMapItems()
        {
            int i = 0;

            for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
            {
                ClearMapItem(i);
            }

        }

        public static void ClearMapItem(int index)
        {
            MapItem[index].Frame = 0;
            MapItem[index].Num = 0;
            MapItem[index].Value = 0;
            MapItem[index].X = 0;
            MapItem[index].Y = 0;
        }

        public static void ClearMapNpc(int index)
        {
            MapNpc[index].Attacking = 0;
            MapNpc[index].AttackTimer = 0;
            MapNpc[index].Dir = 0;
            MapNpc[index].Map = 0;
            MapNpc[index].Moving = 0;
            MapNpc[index].Num = 0;
            MapNpc[index].Steps = 0;
            MapNpc[index].Target = 0;
            MapNpc[index].TargetType = 0;
            MapNpc[index].Vital[(byte)Enums.VitalType.HP] = 0;
            MapNpc[index].Vital[(byte)Enums.VitalType.MP] = 0;
            MapNpc[index].Vital[(byte)Enums.VitalType.SP] = 0;
            MapNpc[index].X = 0;
            MapNpc[index].XOffset = 0;
            MapNpc[index].Y = 0;
            MapNpc[index].YOffset = 0;
        }

        public static void ClearMapNpcs()
        {
            int i = 0;

            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
            {
                ClearMapNpc(i);
            }

        }

        #endregion

        #region Incoming Packets

        internal static void Packet_EditMap(ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            C_UpdateUI.InitMapEditor = true;

            buffer.Dispose();
        }

        public static void Packet_CheckMap(ref byte[] data)
        {
            int x;
            int y;
            int i = 0;
            byte needMap = 0;
            ByteStream buffer = new ByteStream(data);
            C_Variables.GettingMap = true;

            // Erase all players except self
            for (i = 1; i <= C_Variables.TotalOnline; i++) //MAX_PLAYERS
            {
                if (i != C_Variables.Myindex)
                {
                    C_Player.SetPlayerMap(i, 0);
                }
            }

            // Erase all temporary tile values
            C_GameLogic.ClearTempTile();
            ClearMapNpcs();
            ClearMapItems();
            C_DataBase.ClearBlood();
            ClearMap();

            // Get map num
            x = buffer.ReadInt32();
            // Get revision
            y = buffer.ReadInt32();

            needMap = 1;

            // Either the revisions didn't match or we dont have the map, so we need it
            buffer = new ByteStream(4);
            buffer.WriteInt32((Int32)Packets.ClientPackets.CNeedMap);
            buffer.WriteInt32(needMap);
            C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void Packet_MapData(ref byte[] data)
        {
            int x = 0;
            int y = 0;
            int i = 0;
            int mapNum;
            ByteStream buffer = new ByteStream(Compression.DecompressBytes(data));

            C_Variables.MapData = false;

            ClearMap();

            lock (MapLock)
            {
                if (buffer.ReadInt32() == 1)
                {

                    mapNum = buffer.ReadInt32();
                    Map.Name = buffer.ReadString().Trim();
                    Map.Music = buffer.ReadString().Trim();
                    Map.Revision = buffer.ReadInt32();
                    Map.Moral = (byte)(buffer.ReadInt32());
                    Map.Tileset = buffer.ReadInt32();
                    Map.Up = buffer.ReadInt32();
                    Map.Down = buffer.ReadInt32();
                    Map.Left = buffer.ReadInt32();
                    Map.Right = buffer.ReadInt32();
                    Map.BootMap = buffer.ReadInt32();
                    Map.BootX = (byte)(buffer.ReadInt32());
                    Map.BootY = (byte)(buffer.ReadInt32());
                    Map.MaxX = (byte)(buffer.ReadInt32());
                    Map.MaxY = (byte)(buffer.ReadInt32());
                    Map.WeatherType = (byte)(buffer.ReadInt32());
                    Map.Fogindex = buffer.ReadInt32();
                    Map.WeatherIntensity = buffer.ReadInt32();
                    Map.FogAlpha = (byte)(buffer.ReadInt32());
                    Map.FogSpeed = (byte)(buffer.ReadInt32());
                    Map.HasMapTint = (byte)(buffer.ReadInt32());
                    Map.MapTintR = (byte)(buffer.ReadInt32());
                    Map.MapTintG = (byte)(buffer.ReadInt32());
                    Map.MapTintB = (byte)(buffer.ReadInt32());
                    Map.MapTintA = (byte)(buffer.ReadInt32());
                    Map.Instanced = (byte)(buffer.ReadInt32());
                    Map.Panorama = (byte)(buffer.ReadInt32());
                    Map.Parallax = (byte)(buffer.ReadInt32());
                    Map.Brightness = (byte)(buffer.ReadInt32());

                    Map.Tile = new Types.TileRec[Map.MaxX + 1, Map.MaxY + 1];

                    for (x = 1; x <= Constants.MAX_MAP_NPCS; x++)
                    {
                        Map.Npc[x] = buffer.ReadInt32();
                    }

                    for (x = 0; x <= Map.MaxX; x++)
                    {
                        for (y = 0; y <= Map.MaxY; y++)
                        {
                            Map.Tile[x, y].Data1 = buffer.ReadInt32();
                            Map.Tile[x, y].Data2 = buffer.ReadInt32();
                            Map.Tile[x, y].Data3 = buffer.ReadInt32();
                            Map.Tile[x, y].DirBlock = (byte)(buffer.ReadInt32());

                            Map.Tile[x, y].Layer = new Types.TileDataRec[(int)Enums.LayerType.Count];

                            for (i = 0; i <= (int)Enums.LayerType.Count - 1; i++)
                            {
                                Map.Tile[x, y].Layer[i].Tileset = (byte)(buffer.ReadInt32());
                                Map.Tile[x, y].Layer[i].X = (byte)(buffer.ReadInt32());
                                Map.Tile[x, y].Layer[i].Y = (byte)(buffer.ReadInt32());
                                Map.Tile[x, y].Layer[i].AutoTile = (byte)(buffer.ReadInt32());
                            }
                            Map.Tile[x, y].Type = (byte)(buffer.ReadInt32());
                        }
                    }

                    //Event Data!
                    C_EventSystem.ResetEventdata();

                    Map.EventCount = buffer.ReadInt32();

                    if (Map.EventCount > 0)
                    {
                        Map.Events = new C_EventSystem.EventRec[Map.EventCount + 1];
                        for (i = 1; i <= Map.EventCount; i++)
                        {
                            Map.Events[i].Name = buffer.ReadString().Trim();
                            Map.Events[i].Globals = buffer.ReadInt32();
                            Map.Events[i].X = buffer.ReadInt32();
                            Map.Events[i].Y = buffer.ReadInt32();
                            Map.Events[i].PageCount = buffer.ReadInt32();
                            if (Map.Events[i].PageCount > 0)
                            {
                                Map.Events[i].Pages = new C_EventSystem.EventPageRec[Map.Events[i].PageCount + 1];
                                for (x = 1; x <= Map.Events[i].PageCount; x++)
                                {
                                    Map.Events[i].Pages[x].ChkVariable = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].Variableindex = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].VariableCondition = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].VariableCompare = buffer.ReadInt32();

                                    Map.Events[i].Pages[x].ChkSwitch = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].Switchindex = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].SwitchCompare = buffer.ReadInt32();

                                    Map.Events[i].Pages[x].ChkHasItem = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].HasItemindex = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].HasItemAmount = buffer.ReadInt32();

                                    Map.Events[i].Pages[x].ChkSelfSwitch = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].SelfSwitchindex = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].SelfSwitchCompare = buffer.ReadInt32();

                                    Map.Events[i].Pages[x].GraphicType = (byte)(buffer.ReadInt32());
                                    Map.Events[i].Pages[x].Graphic = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].GraphicX = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].GraphicY = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].GraphicX2 = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].GraphicY2 = buffer.ReadInt32();

                                    Map.Events[i].Pages[x].MoveType = (byte)(buffer.ReadInt32());
                                    Map.Events[i].Pages[x].MoveSpeed = (byte)(buffer.ReadInt32());
                                    Map.Events[i].Pages[x].MoveFreq = (byte)(buffer.ReadInt32());

                                    Map.Events[i].Pages[x].MoveRouteCount = buffer.ReadInt32();

                                    Map.Events[i].Pages[x].IgnoreMoveRoute = buffer.ReadInt32();
                                    Map.Events[i].Pages[x].RepeatMoveRoute = buffer.ReadInt32();

                                    if (Map.Events[i].Pages[x].MoveRouteCount > 0)
                                    {
                                        Map.Events[i].Pages[x].MoveRoute = new C_EventSystem.MoveRouteRec[Map.Events[i].Pages[x].MoveRouteCount + 1];
                                        for (y = 1; y <= Map.Events[i].Pages[x].MoveRouteCount; y++)
                                        {
                                            Map.Events[i].Pages[x].MoveRoute[y].Index = buffer.ReadInt32();
                                            Map.Events[i].Pages[x].MoveRoute[y].Data1 = buffer.ReadInt32();
                                            Map.Events[i].Pages[x].MoveRoute[y].Data2 = buffer.ReadInt32();
                                            Map.Events[i].Pages[x].MoveRoute[y].Data3 = buffer.ReadInt32();
                                            Map.Events[i].Pages[x].MoveRoute[y].Data4 = buffer.ReadInt32();
                                            Map.Events[i].Pages[x].MoveRoute[y].Data5 = buffer.ReadInt32();
                                            Map.Events[i].Pages[x].MoveRoute[y].Data6 = buffer.ReadInt32();
                                        }
                                    }

                                    Map.Events[i].Pages[x].WalkAnim = (byte)(buffer.ReadInt32());
                                    Map.Events[i].Pages[x].DirFix = (byte)(buffer.ReadInt32());
                                    Map.Events[i].Pages[x].WalkThrough = (byte)(buffer.ReadInt32());
                                    Map.Events[i].Pages[x].ShowName = (byte)(buffer.ReadInt32());
                                    Map.Events[i].Pages[x].Trigger = (byte)(buffer.ReadInt32());
                                    Map.Events[i].Pages[x].CommandListCount = buffer.ReadInt32();

                                    Map.Events[i].Pages[x].Position = (byte)(buffer.ReadInt32());
                                    Map.Events[i].Pages[x].Questnum = buffer.ReadInt32();

                                    Map.Events[i].Pages[x].ChkPlayerGender = buffer.ReadInt32();

                                    if (Map.Events[i].Pages[x].CommandListCount > 0)
                                    {
                                        Map.Events[i].Pages[x].CommandList = new C_EventSystem.CommandListRec[Map.Events[i].Pages[x].CommandListCount + 1];
                                        for (y = 1; y <= Map.Events[i].Pages[x].CommandListCount; y++)
                                        {
                                            Map.Events[i].Pages[x].CommandList[y].CommandCount = buffer.ReadInt32();
                                            Map.Events[i].Pages[x].CommandList[y].ParentList = buffer.ReadInt32();
                                            if (Map.Events[i].Pages[x].CommandList[y].CommandCount > 0)
                                            {
                                                Map.Events[i].Pages[x].CommandList[y].Commands = new C_EventSystem.EventCommandRec[Map.Events[i].Pages[x].CommandList[y].CommandCount + 1];
                                                for (var z = 1; z <= Map.Events[i].Pages[x].CommandList[y].CommandCount; z++)
                                                {
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].Index = buffer.ReadInt32();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].Text1 = buffer.ReadString().Trim();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].Text2 = buffer.ReadString().Trim();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].Text3 = buffer.ReadString().Trim();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].Text4 = buffer.ReadString().Trim();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].Text5 = buffer.ReadString().Trim();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].Data1 = buffer.ReadInt32();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].Data2 = buffer.ReadInt32();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].Data3 = buffer.ReadInt32();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].Data4 = buffer.ReadInt32();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].Data5 = buffer.ReadInt32();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].Data6 = buffer.ReadInt32();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.CommandList = buffer.ReadInt32();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Condition = buffer.ReadInt32();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data1 = buffer.ReadInt32();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data2 = buffer.ReadInt32();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data3 = buffer.ReadInt32();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.ElseCommandList = buffer.ReadInt32();
                                                    Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount = buffer.ReadInt32();
                                                    if (Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount > 0)
                                                    {
                                                        Array.Resize(ref Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute, Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount + 1);
                                                        for (var w = 1; w <= Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount; w++)
                                                        {
                                                            Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Index = buffer.ReadInt32();
                                                            Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data1 = buffer.ReadInt32();
                                                            Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data2 = buffer.ReadInt32();
                                                            Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data3 = buffer.ReadInt32();
                                                            Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data4 = buffer.ReadInt32();
                                                            Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data5 = buffer.ReadInt32();
                                                            Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data6 = buffer.ReadInt32();
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    //End Event Data
                }

                for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
                {
                    MapItem[i].Num = buffer.ReadInt32();
                    MapItem[i].Value = buffer.ReadInt32();
                    MapItem[i].X = (byte)(buffer.ReadInt32());
                    MapItem[i].Y = (byte)(buffer.ReadInt32());
                }

                for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                {
                    MapNpc[i].Num = buffer.ReadInt32();
                    MapNpc[i].X = (byte)(buffer.ReadInt32());
                    MapNpc[i].Y = (byte)(buffer.ReadInt32());
                    MapNpc[i].Dir = (byte)(buffer.ReadInt32());
                    MapNpc[i].Vital[(byte)Enums.VitalType.HP] = buffer.ReadInt32();
                    MapNpc[i].Vital[(byte)Enums.VitalType.MP] = buffer.ReadInt32();
                }

                if (buffer.ReadInt32() == 1)
                {
                    C_Resources.ResourceIndex = buffer.ReadInt32();
                    C_Resources.ResourcesInit = false;

                    if (C_Resources.ResourceIndex > 0)
                    {
                        C_Resources.MapResource = new C_Types.MapResourceRec[C_Resources.ResourceIndex + 1];

                        for (i = 0; i <= C_Resources.ResourceIndex; i++)
                        {
                            C_Resources.MapResource[i].ResourceState = (byte)(buffer.ReadInt32());
                            C_Resources.MapResource[i].X = buffer.ReadInt32();
                            C_Resources.MapResource[i].Y = buffer.ReadInt32();
                        }

                        C_Resources.ResourcesInit = true;
                    }
                    else
                    {
                        C_Resources.MapResource = new C_Types.MapResourceRec[2];
                    }
                }

                C_GameLogic.ClearTempTile();

                buffer.Dispose();

            }

            C_AutoTiles.InitAutotiles();

            C_Variables.MapData = true;

            for (i = 1; i <= byte.MaxValue; i++)
            {
                C_GameLogic.ClearActionMsg((byte)i);
            }

            C_Weather.CurrentWeather = Map.WeatherType;
            C_Weather.CurrentWeatherIntensity = Map.WeatherIntensity;
            C_Weather.CurrentFog = Map.Fogindex;
            C_Weather.CurrentFogSpeed = Map.FogSpeed;
            C_Weather.CurrentFogOpacity = Map.FogAlpha;
            C_Weather.CurrentTintR = Map.MapTintR;
            C_Weather.CurrentTintG = Map.MapTintG;
            C_Weather.CurrentTintB = Map.MapTintB;
            C_Weather.CurrentTintA = Map.MapTintA;

            C_Sound.PlayMusic(Map.Music.Trim());

            C_GameLogic.UpdateDrawMapName();

            C_Variables.GettingMap = false;
            C_Variables.CanMoveNow = true;

        }

        public static void Packet_MapNPCData(ref byte[] data)
        {
            int i = 0;
            ByteStream buffer = new ByteStream(data);
            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
            {
                
                MapNpc[i].Num = buffer.ReadInt32();
                MapNpc[i].X = (byte)buffer.ReadInt32();
                MapNpc[i].Y = (byte)buffer.ReadInt32();
                MapNpc[i].Dir = (byte)buffer.ReadInt32();
                MapNpc[i].Vital[(byte)Enums.VitalType.HP] = buffer.ReadInt32();
                MapNpc[i].Vital[(byte)Enums.VitalType.MP] = buffer.ReadInt32();

            }

            buffer.Dispose();
        }

        public static void Packet_MapNPCUpdate(ref byte[] data)
        {
            int npcNum = 0;
            ByteStream buffer = new ByteStream(data);
            npcNum = buffer.ReadInt32();
            
            MapNpc[npcNum].Num = buffer.ReadInt32();
            MapNpc[npcNum].X = (byte)buffer.ReadInt32();
            MapNpc[npcNum].Y = (byte)buffer.ReadInt32();
            MapNpc[npcNum].Dir = (byte)buffer.ReadInt32();
            MapNpc[npcNum].Vital[(byte)Enums.VitalType.HP] = buffer.ReadInt32();
            MapNpc[npcNum].Vital[(byte)Enums.VitalType.MP] = buffer.ReadInt32();

            buffer.Dispose();
        }

        public static void Packet_MapDone(ref byte[] data)
        {
            int i = 0;
            string musicFile = "";

            for (i = 1; i <= byte.MaxValue; i++)
            {
                C_GameLogic.ClearActionMsg((byte)i);
            }

            C_Weather.CurrentWeather = Map.WeatherType;
            C_Weather.CurrentWeatherIntensity = Map.WeatherIntensity;
            C_Weather.CurrentFog = Map.Fogindex;
            C_Weather.CurrentFogSpeed = Map.FogSpeed;
            C_Weather.CurrentFogOpacity = Map.FogAlpha;
            C_Weather.CurrentTintR = Map.MapTintR;
            C_Weather.CurrentTintG = Map.MapTintG;
            C_Weather.CurrentTintB = Map.MapTintB;
            C_Weather.CurrentTintA = Map.MapTintA;

            musicFile = Map.Music.Trim();
            C_Sound.PlayMusic(musicFile);

            C_GameLogic.UpdateDrawMapName();

            C_Variables.GettingMap = false;
            C_Variables.CanMoveNow = true;

        }

        #endregion

        #region Outgoing Packets

        internal static void SendPlayerRequestNewMap()
        {
            if (C_Variables.GettingMap)
            {
                return;
            }

            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((Int32)Packets.ClientPackets.CRequestNewMap);
            buffer.WriteInt32(C_Player.GetPlayerDir(C_Variables.Myindex));

            C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();

        }

        internal static void SendRequestEditMap()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((Int32)Packets.ClientPackets.CRequestEditMap);
            C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        internal static void SendMap()
        {
            int x = 0;
            int y = 0;
            int i = 0;
            byte[] data;
            ByteStream buffer = new ByteStream(4);
            C_Variables.CanMoveNow = false;

            buffer.WriteString(Map.Name.Trim());
            buffer.WriteString(Map.Music.Trim());
            buffer.WriteInt32(Map.Moral);
            buffer.WriteInt32(Map.Tileset);
            buffer.WriteInt32(Map.Up);
            buffer.WriteInt32(Map.Down);
            buffer.WriteInt32(Map.Left);
            buffer.WriteInt32(Map.Right);
            buffer.WriteInt32(Map.BootMap);
            buffer.WriteInt32(Map.BootX);
            buffer.WriteInt32(Map.BootY);
            buffer.WriteInt32(Map.MaxX);
            buffer.WriteInt32(Map.MaxY);
            buffer.WriteInt32(Map.WeatherType);
            buffer.WriteInt32(Map.Fogindex);
            buffer.WriteInt32(Map.WeatherIntensity);
            buffer.WriteInt32(Map.FogAlpha);
            buffer.WriteInt32(Map.FogSpeed);
            buffer.WriteInt32(Map.HasMapTint);
            buffer.WriteInt32(Map.MapTintR);
            buffer.WriteInt32(Map.MapTintG);
            buffer.WriteInt32(Map.MapTintB);
            buffer.WriteInt32(Map.MapTintA);
            buffer.WriteInt32(Map.Instanced);
            buffer.WriteInt32(Map.Panorama);
            buffer.WriteInt32(Map.Parallax);
            buffer.WriteInt32(Map.Brightness);

            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
            {
                buffer.WriteInt32(Map.Npc[i]);
            }

            for (x = 0; x <= Map.MaxX; x++)
            {
                for (y = 0; y <= Map.MaxY; y++)
                {
                    buffer.WriteInt32(Map.Tile[x, y].Data1);
                    buffer.WriteInt32(Map.Tile[x, y].Data2);
                    buffer.WriteInt32(Map.Tile[x, y].Data3);
                    buffer.WriteInt32(Map.Tile[x, y].DirBlock);
                    for (i = 0; i <= (int)Enums.LayerType.Count - 1; i++)
                    {
                        buffer.WriteInt32(Map.Tile[x, y].Layer[i].Tileset);
                        buffer.WriteInt32(Map.Tile[x, y].Layer[i].X);
                        buffer.WriteInt32(Map.Tile[x, y].Layer[i].Y);
                        buffer.WriteInt32(Map.Tile[x, y].Layer[i].AutoTile);
                    }
                    buffer.WriteInt32(Map.Tile[x, y].Type);
                }
            }

            //Event Data
            buffer.WriteInt32(Map.EventCount);
            if (Map.EventCount > 0)
            {
                for (i = 1; i <= Map.EventCount; i++)
                {
                    buffer.WriteString(Map.Events[i].Name.Trim());
                    buffer.WriteInt32(Map.Events[i].Globals);
                    buffer.WriteInt32(Map.Events[i].X);
                    buffer.WriteInt32(Map.Events[i].Y);
                    buffer.WriteInt32(Map.Events[i].PageCount);
                    if (Map.Events[i].PageCount > 0)
                    {
                        for (x = 1; x <= Map.Events[i].PageCount; x++)
                        {
                            buffer.WriteInt32(Map.Events[i].Pages[x].ChkVariable);
                            buffer.WriteInt32(Map.Events[i].Pages[x].Variableindex);
                            buffer.WriteInt32(Map.Events[i].Pages[x].VariableCondition);
                            buffer.WriteInt32(Map.Events[i].Pages[x].VariableCompare);
                            buffer.WriteInt32(Map.Events[i].Pages[x].ChkSwitch);
                            buffer.WriteInt32(Map.Events[i].Pages[x].Switchindex);
                            buffer.WriteInt32(Map.Events[i].Pages[x].SwitchCompare);
                            buffer.WriteInt32(Map.Events[i].Pages[x].ChkHasItem);
                            buffer.WriteInt32(Map.Events[i].Pages[x].HasItemindex);
                            buffer.WriteInt32(Map.Events[i].Pages[x].HasItemAmount);
                            buffer.WriteInt32(Map.Events[i].Pages[x].ChkSelfSwitch);
                            buffer.WriteInt32(Map.Events[i].Pages[x].SelfSwitchindex);
                            buffer.WriteInt32(Map.Events[i].Pages[x].SelfSwitchCompare);
                            buffer.WriteInt32(Map.Events[i].Pages[x].GraphicType);
                            buffer.WriteInt32(Map.Events[i].Pages[x].Graphic);
                            buffer.WriteInt32(Map.Events[i].Pages[x].GraphicX);
                            buffer.WriteInt32(Map.Events[i].Pages[x].GraphicY);
                            buffer.WriteInt32(Map.Events[i].Pages[x].GraphicX2);
                            buffer.WriteInt32(Map.Events[i].Pages[x].GraphicY2);
                            buffer.WriteInt32(Map.Events[i].Pages[x].MoveType);
                            buffer.WriteInt32(Map.Events[i].Pages[x].MoveSpeed);
                            buffer.WriteInt32(Map.Events[i].Pages[x].MoveFreq);
                            buffer.WriteInt32(Map.Events[i].Pages[x].MoveRouteCount);
                            buffer.WriteInt32(Map.Events[i].Pages[x].IgnoreMoveRoute);
                            buffer.WriteInt32(Map.Events[i].Pages[x].RepeatMoveRoute);
                            if (Map.Events[i].Pages[x].MoveRouteCount > 0)
                            {
                                for (y = 1; y <= Map.Events[i].Pages[x].MoveRouteCount; y++)
                                {
                                    buffer.WriteInt32(Map.Events[i].Pages[x].MoveRoute[y].Index);
                                    buffer.WriteInt32(Map.Events[i].Pages[x].MoveRoute[y].Data1);
                                    buffer.WriteInt32(Map.Events[i].Pages[x].MoveRoute[y].Data2);
                                    buffer.WriteInt32(Map.Events[i].Pages[x].MoveRoute[y].Data3);
                                    buffer.WriteInt32(Map.Events[i].Pages[x].MoveRoute[y].Data4);
                                    buffer.WriteInt32(Map.Events[i].Pages[x].MoveRoute[y].Data5);
                                    buffer.WriteInt32(Map.Events[i].Pages[x].MoveRoute[y].Data6);
                                }
                            }
                            buffer.WriteInt32(Map.Events[i].Pages[x].WalkAnim);
                            buffer.WriteInt32(Map.Events[i].Pages[x].DirFix);
                            buffer.WriteInt32(Map.Events[i].Pages[x].WalkThrough);
                            buffer.WriteInt32(Map.Events[i].Pages[x].ShowName);
                            buffer.WriteInt32(Map.Events[i].Pages[x].Trigger);
                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandListCount);
                            buffer.WriteInt32(Map.Events[i].Pages[x].Position);
                            buffer.WriteInt32(Map.Events[i].Pages[x].Questnum);

                            buffer.WriteInt32(Map.Events[i].Pages[x].ChkPlayerGender);
                            if (Map.Events[i].Pages[x].CommandListCount > 0)
                            {
                                for (y = 1; y <= Map.Events[i].Pages[x].CommandListCount; y++)
                                {
                                    buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].CommandCount);
                                    buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].ParentList);
                                    if (Map.Events[i].Pages[x].CommandList[y].CommandCount > 0)
                                    {
                                        for (var z = 1; z <= Map.Events[i].Pages[x].CommandList[y].CommandCount; z++)
                                        {
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].Index);
                                            buffer.WriteString(Map.Events[i].Pages[x].CommandList[y].Commands[z].Text1);
                                            buffer.WriteString(Map.Events[i].Pages[x].CommandList[y].Commands[z].Text2);
                                            buffer.WriteString(Map.Events[i].Pages[x].CommandList[y].Commands[z].Text3);
                                            buffer.WriteString(Map.Events[i].Pages[x].CommandList[y].Commands[z].Text4);
                                            buffer.WriteString(Map.Events[i].Pages[x].CommandList[y].Commands[z].Text5);
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].Data1);
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].Data2);
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].Data3);
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].Data4);
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].Data5);
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].Data6);
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.CommandList);
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Condition);
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data1);
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data2);
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data3);
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.ElseCommandList);
                                            buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount);
                                            if (Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount > 0)
                                            {
                                                for (var w = 1; w <= Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount; w++)
                                                {
                                                    buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Index);
                                                    buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data1);
                                                    buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data2);
                                                    buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data3);
                                                    buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data4);
                                                    buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data5);
                                                    buffer.WriteInt32(Map.Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data6);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            //End Event Data

            data = buffer.ToArray();

            buffer = new ByteStream(4);
            buffer.WriteInt32((Int32)Packets.ClientPackets.CSaveMap);
            buffer.WriteBlock(Compression.CompressBytes(data));

            C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendMapRespawn()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((Int32)Packets.ClientPackets.CMapRespawn);

            C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        #endregion

        #region Drawing

        internal static void CreateMapLayersImage()
        {
            if (mapLayers == null || mapLayers[0] == null || mapLayers[1] == null || mapLayers[2] == null)
            {
                Dictionary<int, SFML.Graphics.Image> tilesets = new Dictionary<int, SFML.Graphics.Image>();
                if (C_Graphics.NumTileSets > 0)
                {
                    if (mapLayers == null)
                    {
                        mapLayers = new Sprite[(byte)Enums.LayerType.Mask2];
                    }
                    for (int i = (byte)Enums.LayerType.Ground; i <= (byte)Enums.LayerType.Mask2; i++)
                    {
                        if (mapLayers[i - 1] == null)
                        {
                            SFML.Graphics.Image layerImage = new SFML.Graphics.Image((uint)(Map.MaxX * 32), (uint)(Map.MaxY * 32), new SFML.Graphics.Color(0, 0, 0, 0));
                            for (int x = 0; x < Map.MaxX; x++)
                            {
                                for (int y = 0; y < Map.MaxY; y++)
                                {
                                    // skip tile if tileset isn't set
                                    if (Map.Tile[x, y].Layer[i].Tileset > 0 && Map.Tile[x, y].Layer[i].Tileset <= C_Graphics.NumTileSets)
                                    {
                                        if (C_AutoTiles.Autotile[x, y].Layer[i].RenderState == C_AutoTiles.RenderStateNormal)
                                        {
                                            if (!tilesets.ContainsKey(Map.Tile[x, y].Layer[i].Tileset))
                                            {
                                                tilesets.Add(Map.Tile[x, y].Layer[i].Tileset, new SFML.Graphics.Image(Application.StartupPath + C_Constants.GfxPath + "tilesets\\" + Map.Tile[x, y].Layer[i].Tileset + C_Constants.GfxExt));
                                            }

                                            //Add Tile to LayerImage
                                            for (int xx = 0; xx < 32; xx++)
                                            {
                                                for (int yy = 0; yy < 32; yy++)
                                                {
                                                    SFML.Graphics.Color color = new SFML.Graphics.Color(tilesets[Map.Tile[x, y].Layer[i].Tileset].GetPixel((uint)((Map.Tile[x, y].Layer[i].X * 32) + xx), (uint)((Map.Tile[x, y].Layer[i].Y * 32) + yy)));
                                                    layerImage.SetPixel((uint)(x * 32 + xx), (uint)(y * 32 + yy), color);
                                                }
                                            }
                                        }
                                        else if (C_AutoTiles.Autotile[x, y].Layer[i].RenderState == C_AutoTiles.RenderStateAutotile)
                                        {
                                            if (Map.Tile[x, y].Layer[i].AutoTile == 1 || Map.Tile[x, y].Layer[i].AutoTile == 4)
                                            {
                                                if (C_Graphics.TileSetTextureInfo[Map.Tile[x, y].Layer[i].Tileset].IsLoaded == false)
                                                {
                                                    C_Graphics.LoadTexture(Map.Tile[x, y].Layer[i].Tileset, 1);
                                                }
                                                SFML.Graphics.Image autotile = C_AutoTiles.CreateAndReturnAutoTileImage(i, x, y); // This isnt an animated tile, So we can cache it
                                                                                                                                  //Add Tile to LayerImage
                                                for (int xx = 0; xx < 32; xx++)
                                                {
                                                    for (int yy = 0; yy < 32; yy++)
                                                    {
                                                        SFML.Graphics.Color color = new SFML.Graphics.Color(autotile.GetPixel((uint)(xx), (uint)(yy)));
                                                        layerImage.SetPixel((uint)(x * 32 + xx), (uint)(y * 32 + yy), color);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            mapLayers[i - 1] = new Sprite(new Texture(layerImage));
                            layerImage.Dispose();
                        }
                    }
                }
                tilesets.Clear();
            }
        }

        internal static void DrawMapTiles()
        {
            if (C_Variables.GettingMap)
            {
                mapLayers = null;
                return;
            }
            if (C_Variables.MapData == false)
            {
                mapLayers = null;
                return;
            }
            if (ReferenceEquals(Map.Tile, null))
            {
                mapLayers = null;
                return;
            }

            for (int i = (byte)Enums.LayerType.Ground; i <= (byte)Enums.LayerType.Mask2; i++)
            {

                // Render the normal Ground first
                C_Graphics.RenderSprite(mapLayers[i - 1], C_Graphics.GameWindow, C_Graphics.ConvertMapX(0), C_Graphics.ConvertMapY(0), 0, 0, (C_Maps.Map.MaxX * 32), (C_Maps.Map.MaxY * 32));

                for (int x = C_Variables.TileView.Left; x <= C_Variables.TileView.Right + 1; x++)
                {
                    for (int y = C_Variables.TileView.Top; y <= C_Variables.TileView.Bottom + 1; y++)
                    {
                        if (C_Graphics.IsValidMapPoint(x, y))
                        {
                            if (Map.Tile[x, y].Layer == null)
                            {
                                continue;
                            }
                            if (Map.Tile[x, y].Layer[i].AutoTile == 1 || Map.Tile[x, y].Layer[i].AutoTile == 4)
                            {
                                continue;
                            }
                            // skip tile if tileset isn't set
                            if (Map.Tile[x, y].Layer[i].Tileset > 0 && Map.Tile[x, y].Layer[i].Tileset <= C_Graphics.NumTileSets)
                            {
                                if (C_Graphics.TileSetTextureInfo[Map.Tile[x, y].Layer[i].Tileset].IsLoaded == false)
                                {
                                    C_Graphics.LoadTexture(Map.Tile[x, y].Layer[i].Tileset, 1);
                                }
                                // we use it, lets update timer
                                C_Graphics.TileSetTextureInfo[Map.Tile[x, y].Layer[i].Tileset].TextureTimer = C_General.GetTickCount() + 100000;
                                if (C_AutoTiles.Autotile[x, y].Layer[i].RenderState == C_AutoTiles.RenderStateAutotile)
                                {
                                    // Draw autotiles
                                    C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX), C_Graphics.ConvertMapY(y * C_Constants.PicY), 1, x, y, 0, false);
                                    C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX) + 16, C_Graphics.ConvertMapY(y * C_Constants.PicY), 2, x, y, 0, false);
                                    C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX), C_Graphics.ConvertMapY(y * C_Constants.PicY) + 16, 3, x, y, 0, false);
                                    C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX) + 16, C_Graphics.ConvertMapY(y * C_Constants.PicY) + 16, 4, x, y, 0, false);
                                }
                            }
                        }
                    }
                }
            }
        }

        internal static void CreateMapFringeLayersImage()
        {
            if (fringeMapLayers == null || fringeMapLayers[0] == null || fringeMapLayers[1] == null)
            {
                Dictionary<int, SFML.Graphics.Image> tilesets = new Dictionary<int, SFML.Graphics.Image>();
                if (C_Graphics.NumTileSets > 0)
                {
                    if (fringeMapLayers == null)
                    {
                        fringeMapLayers = new Sprite[2];
                    }
                    for (int i = (byte)Enums.LayerType.Fringe; i <= (byte)Enums.LayerType.Fringe2; i++)
                    {
                        if (fringeMapLayers[i - 4] == null)
                        {
                            SFML.Graphics.Image layerImage = new SFML.Graphics.Image((uint)(Map.MaxX * 32), (uint)(Map.MaxY * 32), new SFML.Graphics.Color(0, 0, 0, 0));
                            for (int x = 0; x < Map.MaxX; x++)
                            {
                                for (int y = 0; y < Map.MaxY; y++)
                                {
                                    // skip tile if tileset isn't set
                                    if (Map.Tile[x, y].Layer[i].Tileset > 0 && Map.Tile[x, y].Layer[i].Tileset <= C_Graphics.NumTileSets)
                                    {
                                        if (C_AutoTiles.Autotile[x, y].Layer[i].RenderState == C_AutoTiles.RenderStateNormal)
                                        {
                                            if (!tilesets.ContainsKey(Map.Tile[x, y].Layer[i].Tileset))
                                            {
                                                tilesets.Add(Map.Tile[x, y].Layer[i].Tileset, new SFML.Graphics.Image(Application.StartupPath + C_Constants.GfxPath + "tilesets\\" + Map.Tile[x, y].Layer[i].Tileset + C_Constants.GfxExt));
                                            }

                                            //Add Tile to LayerImage
                                            for (int xx = 0; xx < 32; xx++)
                                            {
                                                for (int yy = 0; yy < 32; yy++)
                                                {
                                                    SFML.Graphics.Color color = new SFML.Graphics.Color(tilesets[Map.Tile[x, y].Layer[i].Tileset].GetPixel((uint)((Map.Tile[x, y].Layer[i].X * 32) + xx), (uint)((Map.Tile[x, y].Layer[i].Y * 32) + yy)));
                                                    layerImage.SetPixel((uint)(x * 32 + xx), (uint)(y * 32 + yy), color);
                                                }
                                            }
                                        }
                                        else if (C_AutoTiles.Autotile[x, y].Layer[i].RenderState == C_AutoTiles.RenderStateAutotile)
                                        {
                                            if (Map.Tile[x, y].Layer[i].AutoTile == 1 || Map.Tile[x, y].Layer[i].AutoTile == 4)
                                            {
                                                if (C_Graphics.TileSetTextureInfo[Map.Tile[x, y].Layer[i].Tileset].IsLoaded == false)
                                                {
                                                    C_Graphics.LoadTexture(Map.Tile[x, y].Layer[i].Tileset, 1);
                                                }
                                                SFML.Graphics.Image autotile = C_AutoTiles.CreateAndReturnAutoTileImage(i, x, y); // This isnt an animated tile, So we can cache it
                                                                                                                                  //Add Tile to LayerImage
                                                for (int xx = 0; xx < 32; xx++)
                                                {
                                                    for (int yy = 0; yy < 32; yy++)
                                                    {
                                                        SFML.Graphics.Color color = new SFML.Graphics.Color(autotile.GetPixel((uint)(xx), (uint)(yy)));
                                                        layerImage.SetPixel((uint)(x * 32 + xx), (uint)(y * 32 + yy), color);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            fringeMapLayers[i - 4] = new Sprite(new Texture(layerImage));
                            layerImage.Dispose();
                        }
                    }
                }
                tilesets.Clear();
            }
        }

        internal static void DrawMapFringeTiles()
        {
            if (C_Variables.GettingMap)
            {
                return;
            }
            if (C_Variables.MapData == false)
            {
                return;
            }
            if (Map.Tile == null)
            {
                return;
            }

            for (int i = (byte)Enums.LayerType.Fringe; i <= (byte)Enums.LayerType.Fringe2; i++)
            {
                // Render the normal Ground first
                C_Graphics.RenderSprite(fringeMapLayers[i - 4], C_Graphics.GameWindow, C_Graphics.ConvertMapX(0), C_Graphics.ConvertMapY(0), 0, 0, (C_Maps.Map.MaxX * 32), (C_Maps.Map.MaxY * 32));

                for (int x = C_Variables.TileView.Left; x <= C_Variables.TileView.Right + 1; x++)
                {
                    for (int y = C_Variables.TileView.Top; y <= C_Variables.TileView.Bottom + 1; y++)
                    {
                        if (C_Graphics.IsValidMapPoint(x, y))
                        {
                            if (Map.Tile[x, y].Layer == null)
                            {
                                continue;
                            }
                            if (Map.Tile[x, y].Layer[i].AutoTile == 1 || Map.Tile[x, y].Layer[i].AutoTile == 4)
                            {
                                continue;
                            }
                            // skip tile if tileset isn't set
                            if (Map.Tile[x, y].Layer[i].Tileset > 0 && Map.Tile[x, y].Layer[i].Tileset <= C_Graphics.NumTileSets)
                            {
                                if (C_Graphics.TileSetTextureInfo[Map.Tile[x, y].Layer[i].Tileset].IsLoaded == false)
                                {
                                    C_Graphics.LoadTexture(Map.Tile[x, y].Layer[i].Tileset, 1);
                                }

                                // we use it, lets update timer
                                C_Graphics.TileSetTextureInfo[Map.Tile[x, y].Layer[i].Tileset].TextureTimer = C_General.GetTickCount() + 100000;

                                // render
                                if (C_AutoTiles.Autotile[x, y].Layer[i].RenderState == C_AutoTiles.RenderStateNormal)
                                {
                                    //srcrect.X = Map.Tile[x, y].Layer[i].X * 32;
                                    //srcrect.Y = Map.Tile[x, y].Layer[i].Y * 32;
                                    //srcrect.Width = 32;
                                    //srcrect.Height = 32;
                                    //
                                    //C_Graphics.RenderSprite(C_Graphics.TileSetSprite[Map.Tile[x, y].Layer[i].Tileset], C_Graphics.GameWindow, C_Graphics.ConvertMapX(x * C_Constants.PicX), C_Graphics.ConvertMapY(y * C_Constants.PicY), srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height);

                                }
                                else if (C_AutoTiles.Autotile[x, y].Layer[i].RenderState == C_AutoTiles.RenderStateAutotile)
                                {
                                    // Draw autotiles
                                    C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX), C_Graphics.ConvertMapY(y * C_Constants.PicY), 1, x, y, 0, false);
                                    C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX) + 16, C_Graphics.ConvertMapY(y * C_Constants.PicY), 2, x, y, 0, false);
                                    C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX), C_Graphics.ConvertMapY(y * C_Constants.PicY) + 16, 3, x, y, 0, false);
                                    C_AutoTiles.DrawAutoTile(i, C_Graphics.ConvertMapX(x * C_Constants.PicX) + 16, C_Graphics.ConvertMapY(y * C_Constants.PicY) + 16, 4, x, y, 0, false);
                                }
                            }
                        }

                    }

                    #endregion

                }
            }
        }
    }
}
