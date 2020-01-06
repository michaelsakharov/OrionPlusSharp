using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using ASFW;
using ASFW.IO;
using static Engine.E_EventSystem;
using static Engine.Types;
using static Engine.E_Types;

namespace Engine
{
    static class E_NetworkReceive
    {
        public static void PacketRouter()
        {
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SAlertMsg] = Packet_AlertMSG;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SKeyPair] = Packet_KeyPair;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SLoginOk] = Packet_LoginOk;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SClassesData] = Packet_ClassesData;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SMapData] = Packet_MapData;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SMapNpcData] = Packet_MapNPCData;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SMapNpcUpdate] = Packet_MapNPCUpdate;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SItemEditor] = E_Items.Packet_EditItem;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SUpdateItem] = E_Items.Packet_UpdateItem;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SREditor] = Packet_ResourceEditor;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SNpcEditor] = Packet_NPCEditor;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SUpdateNpc] = Packet_UpdateNPC;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SEditMap] = Packet_EditMap;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SShopEditor] = Packet_EditShop;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SUpdateShop] = Packet_UpdateShop;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SSkillEditor] = Packet_EditSkill;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SUpdateSkill] = Packet_UpdateSkill;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SResourceEditor] = Packet_ResourceEditor;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SUpdateResource] = Packet_UpdateResource;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SAnimationEditor] = Packet_EditAnimation;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SUpdateAnimation] = Packet_UpdateAnimation;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SGameData] = Packet_GameData;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SMapReport] = Packet_Mapreport; // Mapreport

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SMapNames] = Packet_MapNames;

            // quests
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SQuestEditor] = E_Quest.Packet_QuestEditor;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SUpdateQuest] = E_Quest.Packet_UpdateQuest;

            // Housing
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SHouseConfigs] = E_Housing.Packet_HouseConfigurations;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SFurniture] = E_Housing.Packet_Furniture;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SHouseEdit] = E_Housing.Packet_EditHouses;

            // Events
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SSpawnEvent] = E_EventSystem.Packet_SpawnEvent;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SEventMove] = E_EventSystem.Packet_EventMove;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SEventDir] = E_EventSystem.Packet_EventDir;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SEventChat] = E_EventSystem.Packet_EventChat;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SEventStart] = E_EventSystem.Packet_EventStart;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SEventEnd] = E_EventSystem.Packet_EventEnd;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SSwitchesAndVariables] = E_EventSystem.Packet_SwitchesAndVariables;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SMapEventData] = E_EventSystem.Packet_MapEventData;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SHoldPlayer] = E_EventSystem.Packet_HoldPlayer;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SProjectileEditor] = E_Projectiles.HandleProjectileEditor;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SUpdateProjectile] = E_Projectiles.HandleUpdateProjectile;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SMapProjectile] = E_Projectiles.HandleMapProjectile;

            // craft
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SUpdateRecipe] = E_Crafting.Packet_UpdateRecipe;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SRecipeEditor] = E_Crafting.Packet_RecipeEditor;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SClassEditor] = Packet_ClassEditor;

            // Auto Mapper
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SAutoMapper] = E_AutoMap.Packet_AutoMapper;

            // pets
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SPetEditor] = E_Pets.Packet_PetEditor;
            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SUpdatePet] = E_Pets.Packet_UpdatePet;

            E_NetworkConfig.Socket.PacketId[(int)Packets.ServerPackets.SNews] = Packet_News;
        }

        private static void Packet_News(ref byte[] data)
        {
        }

        private static void Packet_AlertMSG(ref byte[] data)
        {
            string Msg;
            ByteStream buffer = new ByteStream(data);
            Msg = buffer.ReadString();

            buffer.Dispose();

            Interaction.MsgBox(Msg, Microsoft.VisualBasic.Constants.vbOKOnly, "Lupus Engine Editors");

            E_Loop.CloseEditor();
        }

        private static void Packet_KeyPair(ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            E_Globals.EKeyPair.ImportKeyString(buffer.ReadString());
            buffer.Dispose();
        }

        private static void Packet_LoginOk(ref byte[] data)
        {
            E_Globals.InitEditor = true;
        }

        private static void Packet_ClassesData(ref byte[] data)
        {
            int i;
            int z;
            int X;
            ByteStream buffer = new ByteStream(data);
            // Max classes
            E_Globals.Max_Classes = (byte)buffer.ReadInt32();
            Classes = new ClassRec[E_Globals.Max_Classes + 1];
            var loopTo = E_Globals.Max_Classes;
            for (i = 0; i <= loopTo; i++)
                Classes[i].Stat = new byte[7];
            var loopTo1 = E_Globals.Max_Classes;
            for (i = 0; i <= loopTo1; i++)
                Classes[i].Vital = new int[4];
            var loopTo2 = E_Globals.Max_Classes;
            for (i = 1; i <= loopTo2; i++)
            {
                {
                    Classes[i].Name = buffer.ReadString();
                    Classes[i].Desc = buffer.ReadString();

                    Classes[i].Vital[(int)Enums.VitalType.HP] = buffer.ReadInt32();
                    Classes[i].Vital[(int)Enums.VitalType.MP] = buffer.ReadInt32();
                    Classes[i].Vital[(int)Enums.VitalType.SP] = buffer.ReadInt32();

                    // get array size
                    z = buffer.ReadInt32();
                    // redim array
                    Classes[i].MaleSprite = new int[z + 1];
                    var loopTo3 = z;
                    // loop-receive data
                    for (X = 0; X <= loopTo3; X++)
                        Classes[i].MaleSprite[X] = buffer.ReadInt32();

                    // get array size
                    z = buffer.ReadInt32();
                    // redim array
                    Classes[i].FemaleSprite = new int[z + 1];
                    var loopTo4 = z;
                    // loop-receive data
                    for (X = 0; X <= loopTo4; X++)
                        Classes[i].FemaleSprite[X] = buffer.ReadInt32();

                    Classes[i].Stat[(int)Enums.StatType.Strength] = (byte)buffer.ReadInt32();
                    Classes[i].Stat[(int)Enums.StatType.Endurance] = (byte)buffer.ReadInt32();
                    Classes[i].Stat[(int)Enums.StatType.Vitality] = (byte)buffer.ReadInt32();
                    Classes[i].Stat[(int)Enums.StatType.Intelligence] = (byte)buffer.ReadInt32();
                    Classes[i].Stat[(int)Enums.StatType.Luck] = (byte)buffer.ReadInt32();
                    Classes[i].Stat[(int)Enums.StatType.Spirit] = (byte)buffer.ReadInt32();

                    Classes[i].StartItem = new int[6];
                    Classes[i].StartValue = new int[6];
                    for (var q = 1; q <= 5; q++)
                    {
                        Classes[i].StartItem[q] = buffer.ReadInt32();
                        Classes[i].StartValue[q] = buffer.ReadInt32();
                    }

                    Classes[i].StartMap = buffer.ReadInt32();
                    Classes[i].StartX = (byte)buffer.ReadInt32();
                    Classes[i].StartY = (byte)buffer.ReadInt32();

                    Classes[i].BaseExp = buffer.ReadInt32();
                }
            }

            buffer.Dispose();
        }

        private static void Packet_MapData(ref byte[] data)
        {
            int X;
            int Y;
            int i;
            ByteStream buffer = new ByteStream(Compression.DecompressBytes(data));

            E_Globals.MapData = false;

            lock (MapLock)
            {
                if (buffer.ReadInt32() == 1)
                {
                    ClientDataBase.ClearMap();
                    Map.mapNum = buffer.ReadInt32();
                    Map.Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                    Map.Music = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                    Map.Revision = buffer.ReadInt32();
                    Map.Moral = (byte)buffer.ReadInt32();
                    Map.tileset = buffer.ReadInt32();
                    Map.Up = buffer.ReadInt32();
                    Map.Down = buffer.ReadInt32();
                    Map.Left = buffer.ReadInt32();
                    Map.Right = buffer.ReadInt32();
                    Map.BootMap = buffer.ReadInt32();
                    Map.BootX = (byte)buffer.ReadInt32();
                    Map.BootY = (byte)buffer.ReadInt32();
                    Map.MaxX = (byte)buffer.ReadInt32();
                    Map.MaxY = (byte)buffer.ReadInt32();
                    Map.WeatherType = (byte)buffer.ReadInt32();
                    Map.Fogindex = buffer.ReadInt32();
                    Map.WeatherIntensity = buffer.ReadInt32();
                    Map.FogAlpha = (byte)buffer.ReadInt32();
                    Map.FogSpeed = (byte)buffer.ReadInt32();
                    Map.HasMapTint = (byte)buffer.ReadInt32();
                    Map.MapTintR = (byte)buffer.ReadInt32();
                    Map.MapTintG = (byte)buffer.ReadInt32();
                    Map.MapTintB = (byte)buffer.ReadInt32();
                    Map.MapTintA = (byte)buffer.ReadInt32();

                    Map.Instanced = (byte)buffer.ReadInt32();
                    Map.Panorama = (byte)buffer.ReadInt32();
                    Map.Parallax = (byte)buffer.ReadInt32();
                    Map.Brightness = (byte)buffer.ReadInt32();

                    Map.Tile = new TileRec[Map.MaxX + 1, Map.MaxY + 1];

                    for (X = 1; X <= Constants.MAX_MAP_NPCS; X++)
                        Map.Npc[X] = buffer.ReadInt32();
                    var loopTo = Map.MaxX;
                    for (X = 0; X <= loopTo; X++)
                    {
                        var loopTo1 = Map.MaxY;
                        for (Y = 0; Y <= loopTo1; Y++)
                        {
                            Map.Tile[X, Y].Data1 = buffer.ReadInt32();
                            Map.Tile[X, Y].Data2 = buffer.ReadInt32();
                            Map.Tile[X, Y].Data3 = buffer.ReadInt32();
                            Map.Tile[X, Y].DirBlock = (byte)buffer.ReadInt32();

                            Map.Tile[X, Y].Layer = new TileDataRec[6];

                            for (i = 0; i <= (byte)Enums.LayerType.Count - 1; i++)
                            {
                                Map.Tile[X, Y].Layer[i].Tileset = (byte)buffer.ReadInt32();
                                Map.Tile[X, Y].Layer[i].X = (byte)buffer.ReadInt32();
                                Map.Tile[X, Y].Layer[i].Y = (byte)buffer.ReadInt32();
                                Map.Tile[X, Y].Layer[i].AutoTile = (byte)buffer.ReadInt32();
                            }
                            Map.Tile[X, Y].Type = (byte)buffer.ReadInt32();
                        }
                    }

                    // Event Data!
                    E_EventSystem.ResetEventdata();

                    Map.EventCount = buffer.ReadInt32();

                    if (Map.EventCount > 0)
                    {
                        Map.Events = new EventRec[Map.EventCount + 1];
                        var loopTo2 = Map.EventCount;
                        for (i = 1; i <= loopTo2; i++)
                        {
                            {
                                Map.Events[i].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                                Map.Events[i].Globals = buffer.ReadInt32();
                                Map.Events[i].X = buffer.ReadInt32();
                                Map.Events[i].Y = buffer.ReadInt32();
                                Map.Events[i].PageCount = buffer.ReadInt32();
                            }
                            if (Map.Events[i].PageCount > 0)
                            {
                                Map.Events[i].Pages = new EventPageRec[Map.Events[i].PageCount + 1];
                                var loopTo3 = Map.Events[i].PageCount;
                                for (X = 1; X <= loopTo3; X++)
                                {
                                    {
                                        Map.Events[i].Pages[X].ChkVariable = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].Variableindex = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].VariableCondition = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].VariableCompare = buffer.ReadInt32();

                                        Map.Events[i].Pages[X].ChkSwitch = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].Switchindex = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].SwitchCompare = buffer.ReadInt32();

                                        Map.Events[i].Pages[X].ChkHasItem = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].HasItemindex = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].HasItemAmount = buffer.ReadInt32();

                                        Map.Events[i].Pages[X].ChkSelfSwitch = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].SelfSwitchindex = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].SelfSwitchCompare = buffer.ReadInt32();

                                        Map.Events[i].Pages[X].GraphicType = (byte)buffer.ReadInt32();
                                        Map.Events[i].Pages[X].Graphic = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].GraphicX = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].GraphicY = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].GraphicX2 = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].GraphicY2 = buffer.ReadInt32();

                                        Map.Events[i].Pages[X].MoveType = (byte)buffer.ReadInt32();
                                        Map.Events[i].Pages[X].MoveSpeed = (byte)buffer.ReadInt32();
                                        Map.Events[i].Pages[X].MoveFreq = (byte)buffer.ReadInt32();

                                        Map.Events[i].Pages[X].MoveRouteCount = buffer.ReadInt32();

                                        Map.Events[i].Pages[X].IgnoreMoveRoute = buffer.ReadInt32();
                                        Map.Events[i].Pages[X].RepeatMoveRoute = buffer.ReadInt32();

                                        if (Map.Events[i].Pages[X].MoveRouteCount > 0)
                                        {
                                            Map.Events[i].Pages[X].MoveRoute = new MoveRouteRec[Map.Events[i].Pages[X].MoveRouteCount + 1];
                                            var loopTo4 = Map.Events[i].Pages[X].MoveRouteCount;
                                            for (Y = 1; Y <= loopTo4; Y++)
                                            {
                                                Map.Events[i].Pages[X].MoveRoute[Y].Index = buffer.ReadInt32();
                                                Map.Events[i].Pages[X].MoveRoute[Y].Data1 = buffer.ReadInt32();
                                                Map.Events[i].Pages[X].MoveRoute[Y].Data2 = buffer.ReadInt32();
                                                Map.Events[i].Pages[X].MoveRoute[Y].Data3 = buffer.ReadInt32();
                                                Map.Events[i].Pages[X].MoveRoute[Y].Data4 = buffer.ReadInt32();
                                                Map.Events[i].Pages[X].MoveRoute[Y].Data5 = buffer.ReadInt32();
                                                Map.Events[i].Pages[X].MoveRoute[Y].Data6 = buffer.ReadInt32();
                                            }
                                        }

                                        Map.Events[i].Pages[X].WalkAnim = (byte)buffer.ReadInt32();
                                        Map.Events[i].Pages[X].DirFix = (byte)buffer.ReadInt32();
                                        Map.Events[i].Pages[X].WalkThrough = (byte)buffer.ReadInt32();
                                        Map.Events[i].Pages[X].ShowName = (byte)buffer.ReadInt32();
                                        Map.Events[i].Pages[X].Trigger = (byte)buffer.ReadInt32();
                                        Map.Events[i].Pages[X].CommandListCount = buffer.ReadInt32();

                                        Map.Events[i].Pages[X].Position = (byte)buffer.ReadInt32();
                                        Map.Events[i].Pages[X].Questnum = buffer.ReadInt32();

                                        Map.Events[i].Pages[X].ChkPlayerGender = buffer.ReadInt32();
                                    }

                                    if (Map.Events[i].Pages[X].CommandListCount > 0)
                                    {
                                        Map.Events[i].Pages[X].CommandList = new CommandListRec[Map.Events[i].Pages[X].CommandListCount + 1];
                                        var loopTo5 = Map.Events[i].Pages[X].CommandListCount;
                                        for (Y = 1; Y <= loopTo5; Y++)
                                        {
                                            Map.Events[i].Pages[X].CommandList[Y].CommandCount = buffer.ReadInt32();
                                            Map.Events[i].Pages[X].CommandList[Y].ParentList = buffer.ReadInt32();
                                            if (Map.Events[i].Pages[X].CommandList[Y].CommandCount > 0)
                                            {
                                                Map.Events[i].Pages[X].CommandList[Y].Commands = new EventCommandRec[Map.Events[i].Pages[X].CommandList[Y].CommandCount + 1];
                                                var loopTo6 = Map.Events[i].Pages[X].CommandList[Y].CommandCount;
                                                for (var z = 1; z <= loopTo6; z++)
                                                {
                                                    {
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].Index = buffer.ReadInt32();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].Text1 = buffer.ReadString().Trim();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].Text2 = buffer.ReadString().Trim();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].Text3 = buffer.ReadString().Trim();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].Text4 = buffer.ReadString().Trim();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].Text5 = buffer.ReadString().Trim();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].Data1 = buffer.ReadInt32();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].Data2 = buffer.ReadInt32();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].Data3 = buffer.ReadInt32();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].Data4 = buffer.ReadInt32();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].Data5 = buffer.ReadInt32();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].Data6 = buffer.ReadInt32();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].ConditionalBranch.CommandList = buffer.ReadInt32();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].ConditionalBranch.Condition = buffer.ReadInt32();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].ConditionalBranch.Data1 = buffer.ReadInt32();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].ConditionalBranch.Data2 = buffer.ReadInt32();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].ConditionalBranch.Data3 = buffer.ReadInt32();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].ConditionalBranch.ElseCommandList = buffer.ReadInt32();
                                                        Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRouteCount = buffer.ReadInt32();
                                                        if (Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRouteCount > 0)
                                                        {
                                                            var oldMoveRoute = Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute;
                                                            Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute = new MoveRouteRec[Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRouteCount + 1];
                                                            if (oldMoveRoute != null)
                                                                Array.Copy(oldMoveRoute, Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute, Math.Min(Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRouteCount + 1, oldMoveRoute.Length));
                                                            var loopTo7 = Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRouteCount;
                                                            for (var w = 1; w <= loopTo7; w++)
                                                            {
                                                                Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Index = buffer.ReadInt32();
                                                                Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Data1 = buffer.ReadInt32();
                                                                Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Data2 = buffer.ReadInt32();
                                                                Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Data3 = buffer.ReadInt32();
                                                                Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Data4 = buffer.ReadInt32();
                                                                Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Data5 = buffer.ReadInt32();
                                                                Map.Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Data6 = buffer.ReadInt32();
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
                    }
                }

                for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
                {
                    MapItem[i].Num = buffer.ReadInt32();
                    MapItem[i].Value = buffer.ReadInt32();
                    MapItem[i].X = (byte)buffer.ReadInt32();
                    MapItem[i].Y = (byte)buffer.ReadInt32();
                }

                for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                {
                    MapNpc[i].Num = (byte)buffer.ReadInt32();
                    MapNpc[i].X = (byte)buffer.ReadInt32();
                    MapNpc[i].Y = (byte)buffer.ReadInt32();
                    MapNpc[i].Dir = (byte)buffer.ReadInt32();
                    MapNpc[i].Vital[(int)Enums.VitalType.HP] = buffer.ReadInt32();
                    MapNpc[i].Vital[(int)Enums.VitalType.MP] = buffer.ReadInt32();
                }

                if (buffer.ReadInt32() == 1)
                {
                    E_Globals.Resource_index = buffer.ReadInt32();
                    E_Globals.Resources_Init = false;

                    if (E_Globals.Resource_index > 0)
                    {
                        E_Globals.MapResource = new MapResourceRec[E_Globals.Resource_index + 1];
                        var loopTo8 = E_Globals.Resource_index;
                        for (i = 0; i <= loopTo8; i++)
                        {
                            E_Globals.MapResource[i].ResourceState = (byte)buffer.ReadInt32();
                            E_Globals.MapResource[i].X = buffer.ReadInt32();
                            E_Globals.MapResource[i].Y = buffer.ReadInt32();
                        }

                        E_Globals.Resources_Init = true;
                    }
                    else
                        E_Globals.MapResource = new MapResourceRec[2];
                }

                buffer.Dispose();
            }

            ClientDataBase.ClearTempTile();
            E_AutoTiles.InitAutotiles();

            E_Graphics.tempTileLights = null;

            E_Globals.MapData = true;

            E_Globals.CurrentWeather = Map.WeatherType;
            E_Globals.CurrentWeatherIntensity = Map.WeatherIntensity;
            E_Globals.CurrentFog = Map.Fogindex;
            E_Globals.CurrentFogSpeed = Map.FogSpeed;
            E_Globals.CurrentFogOpacity = Map.FogAlpha;
            E_Globals.CurrentTintR = Map.MapTintR;
            E_Globals.CurrentTintG = Map.MapTintG;
            E_Globals.CurrentTintB = Map.MapTintB;
            E_Globals.CurrentTintA = Map.MapTintA;
            E_Graphics.MapTintSprite = null;

            E_Globals.InMapEditor = true;

            E_Globals.GettingMap = false;
        }

        private static void Packet_MapNPCData(ref byte[] data)
        {
            int i;
            ByteStream buffer = new ByteStream(data);

            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
            {
                {
                    MapNpc[i].Num = (byte)buffer.ReadInt32();
                    MapNpc[i].X = (byte)buffer.ReadInt32();
                    MapNpc[i].Y = (byte)buffer.ReadInt32();
                    MapNpc[i].Dir = (byte)buffer.ReadInt32();
                    MapNpc[i].Vital[(int)Enums.VitalType.HP] = buffer.ReadInt32();
                    MapNpc[i].Vital[(int)Enums.VitalType.MP] = buffer.ReadInt32();
                }
            }

            buffer.Dispose();
        }

        private static void Packet_MapNPCUpdate(ref byte[] data)
        {
            int NpcNum;
            ByteStream buffer;
            buffer = new ByteStream(data);

            NpcNum = buffer.ReadInt32();

            {
                MapNpc[NpcNum].Num = (byte)buffer.ReadInt32();
                MapNpc[NpcNum].X = (byte)buffer.ReadInt32();
                MapNpc[NpcNum].Y = (byte)buffer.ReadInt32();
                MapNpc[NpcNum].Dir = (byte)buffer.ReadInt32();
                MapNpc[NpcNum].Vital[(int)Enums.VitalType.HP] = buffer.ReadInt32();
                MapNpc[NpcNum].Vital[(int)Enums.VitalType.MP] = buffer.ReadInt32();
            }

            buffer.Dispose();
        }

        private static void Packet_NPCEditor(ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            E_Globals.InitNPCEditor = true;

            buffer.Dispose();
        }

        private static void Packet_UpdateNPC(ref byte[] data)
        {
            int i;
            int x;
            ByteStream buffer = new ByteStream(data);

            i = buffer.ReadInt32();
            // Update the Npc
            Npc[i].Animation = buffer.ReadInt32();
            Npc[i].AttackSay = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Npc[i].Behaviour = (byte)buffer.ReadInt32();
            Npc[i].DropChance = new int[6];
            Npc[i].DropItem = new int[6];
            Npc[i].DropItemValue = new int[6];
            for (x = 1; x <= 5; x++)
            {
                Npc[i].DropChance[x] = buffer.ReadInt32();
                Npc[i].DropItem[x] = buffer.ReadInt32();
                Npc[i].DropItemValue[x] = buffer.ReadInt32();
            }

            Npc[i].Exp = buffer.ReadInt32();
            Npc[i].Faction = (byte)buffer.ReadInt32();
            Npc[i].Hp = buffer.ReadInt32();
            Npc[i].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Npc[i].Range = (byte)buffer.ReadInt32();
            Npc[i].SpawnTime = (byte)buffer.ReadInt32();
            Npc[i].SpawnSecs = buffer.ReadInt32();
            Npc[i].Sprite = buffer.ReadInt32();

            for (x = 0; x <= (byte)Enums.StatType.Count - 1; x++)
                Npc[i].Stat[x] = (byte)buffer.ReadInt32();

            Npc[i].QuestNum = buffer.ReadInt32();

            for (x = 1; x <= Constants.MAX_NPC_SKILLS; x++)
                Npc[i].Skill[x] = (byte)buffer.ReadInt32();

            Npc[i].Level = buffer.ReadInt32();
            Npc[i].Damage = buffer.ReadInt32();

            if (Npc[i].AttackSay == null)
                Npc[i].AttackSay = "";
            if (Npc[i].Name == null)
                Npc[i].Name = "";

            buffer.Dispose();
        }

        private static void Packet_EditMap(ref byte[] data)
        {
            E_Globals.InitMapEditor = true;
        }

        private static void Packet_EditShop(ref byte[] data)
        {
            E_Globals.InitShopEditor = true;
        }

        private static void Packet_UpdateShop(ref byte[] data)
        {
            int shopnum;
            ByteStream buffer = new ByteStream(data);
            shopnum = buffer.ReadInt32();

            Shop[shopnum].BuyRate = buffer.ReadInt32();
            Shop[shopnum].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Shop[shopnum].Face = (byte)buffer.ReadInt32();

            for (var i = 0; i <= Constants.MAX_TRADES; i++)
            {
                Shop[shopnum].TradeItem[i].CostItem = buffer.ReadInt32();
                Shop[shopnum].TradeItem[i].CostValue = buffer.ReadInt32();
                Shop[shopnum].TradeItem[i].Item = buffer.ReadInt32();
                Shop[shopnum].TradeItem[i].ItemValue = buffer.ReadInt32();
            }

            if (Shop[shopnum].Name == null)
                Shop[shopnum].Name = "";

            buffer.Dispose();
        }

        private static void Packet_EditSkill(ref byte[] data)
        {
            E_Globals.InitSkillEditor = true;
        }

        private static void Packet_UpdateSkill(ref byte[] data)
        {
            int skillnum;
            ByteStream buffer = new ByteStream(data);
            skillnum = buffer.ReadInt32();

            Skill[skillnum].AccessReq = buffer.ReadInt32();
            Skill[skillnum].AoE = buffer.ReadInt32();
            Skill[skillnum].CastAnim = buffer.ReadInt32();
            Skill[skillnum].CastTime = buffer.ReadInt32();
            Skill[skillnum].CdTime = buffer.ReadInt32();
            Skill[skillnum].ClassReq = buffer.ReadInt32();
            Skill[skillnum].Dir = (byte)buffer.ReadInt32();
            Skill[skillnum].Duration = buffer.ReadInt32();
            Skill[skillnum].Icon = buffer.ReadInt32();
            Skill[skillnum].Interval = buffer.ReadInt32();
            Skill[skillnum].IsAoE = Convert.ToBoolean(buffer.ReadInt32());
            Skill[skillnum].LevelReq = buffer.ReadInt32();
            Skill[skillnum].Map = buffer.ReadInt32();
            Skill[skillnum].MpCost = buffer.ReadInt32();
            Skill[skillnum].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Skill[skillnum].Range = buffer.ReadInt32();
            Skill[skillnum].SkillAnim = buffer.ReadInt32();
            Skill[skillnum].StunDuration = buffer.ReadInt32();
            Skill[skillnum].Type = (byte)buffer.ReadInt32();
            Skill[skillnum].Vital = buffer.ReadInt32();
            Skill[skillnum].X = buffer.ReadInt32();
            Skill[skillnum].Y = buffer.ReadInt32();

            Skill[skillnum].IsProjectile = buffer.ReadInt32();
            Skill[skillnum].Projectile = buffer.ReadInt32();

            Skill[skillnum].KnockBack = (byte)buffer.ReadInt32();
            Skill[skillnum].KnockBackTiles = (byte)buffer.ReadInt32();

            if (Skill[skillnum].Name == null)
                Skill[skillnum].Name = "";

            buffer.Dispose();
        }

        private static void Packet_ResourceEditor(ref byte[] data)
        {
            E_Globals.InitResourceEditor = true;
        }

        private static void Packet_UpdateResource(ref byte[] data)
        {
            int ResourceNum;
            ByteStream buffer = new ByteStream(data);
            ResourceNum = buffer.ReadInt32();

            Resource[ResourceNum].Animation = buffer.ReadInt32();
            Resource[ResourceNum].EmptyMessage = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Resource[ResourceNum].ExhaustedImage = buffer.ReadInt32();
            Resource[ResourceNum].Health = buffer.ReadInt32();
            Resource[ResourceNum].ExpReward = buffer.ReadInt32();
            Resource[ResourceNum].ItemReward = buffer.ReadInt32();
            Resource[ResourceNum].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Resource[ResourceNum].ResourceImage = buffer.ReadInt32();
            Resource[ResourceNum].ResourceType = buffer.ReadInt32();
            Resource[ResourceNum].RespawnTime = buffer.ReadInt32();
            Resource[ResourceNum].SuccessMessage = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Resource[ResourceNum].LvlRequired = buffer.ReadInt32();
            Resource[ResourceNum].ToolRequired = buffer.ReadInt32();
            Resource[ResourceNum].Walkthrough = Convert.ToBoolean(buffer.ReadInt32());

            if (Resource[ResourceNum].Name == null)
                Resource[ResourceNum].Name = "";
            if (Resource[ResourceNum].EmptyMessage == null)
                Resource[ResourceNum].EmptyMessage = "";
            if (Resource[ResourceNum].SuccessMessage == null)
                Resource[ResourceNum].SuccessMessage = "";

            buffer.Dispose();
        }

        private static void Packet_EditAnimation(ref byte[] data)
        {
            E_Globals.InitAnimationEditor = true;
        }

        private static void Packet_UpdateAnimation(ref byte[] data)
        {
            int n;
            int i;
            ByteStream buffer = new ByteStream(data);
            n = buffer.ReadInt32();
            var loopTo = Information.UBound(Animation[n].Frames);
            // Update the Animation
            for (i = 0; i <= loopTo; i++)
                Animation[n].Frames[i] = buffer.ReadInt32();
            var loopTo1 = Information.UBound(Animation[n].LoopCount);
            for (i = 0; i <= loopTo1; i++)
                Animation[n].LoopCount[i] = buffer.ReadInt32();
            var loopTo2 = Information.UBound(Animation[n].LoopTime);
            for (i = 0; i <= loopTo2; i++)
                Animation[n].LoopTime[i] = buffer.ReadInt32();

            Animation[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Animation[n].Sound = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());

            if (Animation[n].Name == null)
                Animation[n].Name = "";
            if (Animation[n].Sound == null)
                Animation[n].Sound = "";
            var loopTo3 = Information.UBound(Animation[n].Sprite);
            for (i = 0; i <= loopTo3; i++)
                Animation[n].Sprite[i] = buffer.ReadInt32();
            buffer.Dispose();
        }

        private static void Packet_GameData(ref byte[] data)
        {
            int n;
            int i;
            int z;
            int x;
            int a;
            int b;
            ByteStream buffer = new ByteStream(Compression.DecompressBytes(data));

            // \\\Read Class Data\\\

            // Max classes
            E_Globals.Max_Classes = (byte)buffer.ReadInt32();
            Classes = new ClassRec[E_Globals.Max_Classes + 1];
            var loopTo = E_Globals.Max_Classes;
            for (i = 0; i <= loopTo; i++)
                Classes[i].Stat = new byte[7];
            var loopTo1 = E_Globals.Max_Classes;
            for (i = 0; i <= loopTo1; i++)
                Classes[i].Vital = new int[4];
            var loopTo2 = E_Globals.Max_Classes;
            for (i = 1; i <= loopTo2; i++)
            {
                {
                    Classes[i].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                    Classes[i].Desc = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());

                    Classes[i].Vital[(int)Enums.VitalType.HP] = buffer.ReadInt32();
                    Classes[i].Vital[(int)Enums.VitalType.MP] = buffer.ReadInt32();
                    Classes[i].Vital[(int)Enums.VitalType.SP] = buffer.ReadInt32();

                    // get array size
                    z = buffer.ReadInt32();
                    // redim array
                    Classes[i].MaleSprite = new int[z + 1];
                    var loopTo3 = z;
                    // loop-receive data
                    for (x = 0; x <= loopTo3; x++)
                        Classes[i].MaleSprite[x] = buffer.ReadInt32();

                    // get array size
                    z = buffer.ReadInt32();
                    // redim array
                    Classes[i].FemaleSprite = new int[z + 1];
                    var loopTo4 = z;
                    // loop-receive data
                    for (x = 0; x <= loopTo4; x++)
                        Classes[i].FemaleSprite[x] = buffer.ReadInt32();

                    Classes[i].Stat[(int)Enums.StatType.Strength] = (byte)buffer.ReadInt32();
                    Classes[i].Stat[(int)Enums.StatType.Endurance] = (byte)buffer.ReadInt32();
                    Classes[i].Stat[(int)Enums.StatType.Vitality] = (byte)buffer.ReadInt32();
                    Classes[i].Stat[(int)Enums.StatType.Intelligence] = (byte)buffer.ReadInt32();
                    Classes[i].Stat[(int)Enums.StatType.Luck] = (byte)buffer.ReadInt32();
                    Classes[i].Stat[(int)Enums.StatType.Spirit] = (byte)buffer.ReadInt32();

                    Classes[i].StartItem = new int[6];
                    Classes[i].StartValue = new int[6];
                    for (var q = 1; q <= 5; q++)
                    {
                        Classes[i].StartItem[q] = buffer.ReadInt32();
                        Classes[i].StartValue[q] = buffer.ReadInt32();
                    }

                    Classes[i].StartMap = buffer.ReadInt32();
                    Classes[i].StartX = (byte)buffer.ReadInt32();
                    Classes[i].StartY = (byte)buffer.ReadInt32();

                    Classes[i].BaseExp = buffer.ReadInt32();
                }
            }

            i = 0;
            x = 0;
            n = 0;
            z = 0;

            // \\\End Read Class Data\\\

            // \\\Read Item Data\\\\\\\
            x = buffer.ReadInt32();
            var loopTo5 = x;
            for (i = 1; i <= loopTo5; i++)
            {
                n = buffer.ReadInt32();

                // Update the item
                Item[n].AccessReq = buffer.ReadInt32();

                for (z = 0; z <= (byte)Enums.StatType.Count - 1; z++)
                    Item[n].Add_Stat[z] = (byte)buffer.ReadInt32();

                Item[n].Animation = buffer.ReadInt32();
                Item[n].BindType = (byte)buffer.ReadInt32();
                Item[n].ClassReq = buffer.ReadInt32();
                Item[n].Data1 = buffer.ReadInt32();
                Item[n].Data2 = buffer.ReadInt32();
                Item[n].Data3 = buffer.ReadInt32();
                Item[n].TwoHanded = buffer.ReadInt32();
                Item[n].LevelReq = buffer.ReadInt32();
                Item[n].Mastery = (byte)buffer.ReadInt32();
                Item[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Item[n].Paperdoll = buffer.ReadInt32();
                Item[n].Pic = buffer.ReadInt32();
                Item[n].Price = buffer.ReadInt32();
                Item[n].Rarity = (byte)buffer.ReadInt32();
                Item[n].Speed = buffer.ReadInt32();

                Item[n].Randomize = (byte)buffer.ReadInt32();
                Item[n].RandomMin = (byte)buffer.ReadInt32();
                Item[n].RandomMax = (byte)buffer.ReadInt32();

                Item[n].Stackable = (byte)buffer.ReadInt32();
                Item[n].Description = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());

                for (z = 0; z <= (byte)Enums.StatType.Count - 1; z++)
                    Item[n].Stat_Req[z] = (byte)buffer.ReadInt32();

                Item[n].Type = (byte)buffer.ReadInt32();
                Item[n].SubType = (byte)buffer.ReadInt32();

                Item[n].ItemLevel = (byte)buffer.ReadInt32();

                // Housing
                Item[n].FurnitureWidth = buffer.ReadInt32();
                Item[n].FurnitureHeight = buffer.ReadInt32();

                for (a = 0; a <= 3; a++)
                {
                    for (b = 0; b <= 3; b++)
                    {
                        Item[n].FurnitureBlocks[a, b] = buffer.ReadInt32();
                        Item[n].FurnitureFringe[a, b] = buffer.ReadInt32();
                    }
                }

                Item[n].KnockBack = (byte)buffer.ReadInt32();
                Item[n].KnockBackTiles = (byte)buffer.ReadInt32();

                Item[n].Projectile = buffer.ReadInt32();
                Item[n].Ammo = buffer.ReadInt32();
            }

            i = 0;
            n = 0;
            x = 0;
            z = 0;

            // \\\End Read Item Data\\\\\\\

            // \\\Read Animation Data\\\\\\\
            x = buffer.ReadInt32();
            var loopTo6 = x;
            for (i = 1; i <= loopTo6; i++)
            {
                n = buffer.ReadInt32();
                var loopTo7 = Information.UBound(Animation[n].Frames);
                // Update the Animation
                for (z = 0; z <= loopTo7; z++)
                    Animation[n].Frames[z] = buffer.ReadInt32();
                var loopTo8 = Information.UBound(Animation[n].LoopCount);
                for (z = 0; z <= loopTo8; z++)
                    Animation[n].LoopCount[z] = buffer.ReadInt32();
                var loopTo9 = Information.UBound(Animation[n].LoopTime);
                for (z = 0; z <= loopTo9; z++)
                    Animation[n].LoopTime[z] = buffer.ReadInt32();

                Animation[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Animation[n].Sound = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());

                if (Animation[n].Name == null)
                    Animation[n].Name = "";
                if (Animation[n].Sound == null)
                    Animation[n].Sound = "";
                var loopTo10 = Information.UBound(Animation[n].Sprite);
                for (z = 0; z <= loopTo10; z++)
                    Animation[n].Sprite[z] = buffer.ReadInt32();
            }

            i = 0;
            n = 0;
            x = 0;
            z = 0;

            // \\\End Read Animation Data\\\\\\\

            // \\\Read NPC Data\\\\\\\
            x = buffer.ReadInt32();
            var loopTo11 = x;
            for (i = 1; i <= loopTo11; i++)
            {
                n = buffer.ReadInt32();
                // Update the Npc
                Npc[n].Animation = buffer.ReadInt32();
                Npc[n].AttackSay = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Npc[n].Behaviour = (byte)buffer.ReadInt32();
                for (z = 1; z <= 5; z++)
                {
                    Npc[n].DropChance[z] = buffer.ReadInt32();
                    Npc[n].DropItem[z] = buffer.ReadInt32();
                    Npc[n].DropItemValue[z] = buffer.ReadInt32();
                }

                Npc[n].Exp = buffer.ReadInt32();
                Npc[n].Faction = (byte)buffer.ReadInt32();
                Npc[n].Hp = buffer.ReadInt32();
                Npc[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Npc[n].Range = (byte)buffer.ReadInt32();
                Npc[n].SpawnTime = (byte)buffer.ReadInt32();
                Npc[n].SpawnSecs = buffer.ReadInt32();
                Npc[n].Sprite = buffer.ReadInt32();

                for (z = 0; z <= (byte)Enums.StatType.Count - 1; z++)
                    Npc[n].Stat[z] = (byte)buffer.ReadInt32();

                Npc[n].QuestNum = buffer.ReadInt32();

                Npc[n].Skill = new byte[Constants.MAX_NPC_SKILLS + 1];
                for (z = 1; z <= Constants.MAX_NPC_SKILLS; z++)
                    Npc[n].Skill[z] = (byte)buffer.ReadInt32();

                Npc[i].Level = buffer.ReadInt32();
                Npc[i].Damage = buffer.ReadInt32();

                if (Npc[n].AttackSay == null)
                    Npc[n].AttackSay = "";
                if (Npc[n].Name == null)
                    Npc[n].Name = "";
            }

            i = 0;
            n = 0;
            x = 0;
            z = 0;

            // \\\End Read NPC Data\\\\\\\

            // \\\Read Shop Data\\\\\\\
            x = buffer.ReadInt32();
            var loopTo12 = x;
            for (i = 1; i <= loopTo12; i++)
            {
                n = buffer.ReadInt32();

                Shop[n].BuyRate = buffer.ReadInt32();
                Shop[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Shop[n].Face = (byte)buffer.ReadInt32();

                for (z = 0; z <= Constants.MAX_TRADES; z++)
                {
                    Shop[n].TradeItem[z].CostItem = buffer.ReadInt32();
                    Shop[n].TradeItem[z].CostValue = buffer.ReadInt32();
                    Shop[n].TradeItem[z].Item = buffer.ReadInt32();
                    Shop[n].TradeItem[z].ItemValue = buffer.ReadInt32();
                }

                if (Shop[n].Name == null)
                    Shop[n].Name = "";
            }

            i = 0;
            n = 0;
            x = 0;
            z = 0;

            // \\\End Read Shop Data\\\\\\\

            // \\\Read Skills Data\\\\\\\\\\
            x = buffer.ReadInt32();
            var loopTo13 = x;
            for (i = 1; i <= loopTo13; i++)
            {
                n = buffer.ReadInt32();

                Skill[n].AccessReq = buffer.ReadInt32();
                Skill[n].AoE = buffer.ReadInt32();
                Skill[n].CastAnim = buffer.ReadInt32();
                Skill[n].CastTime = buffer.ReadInt32();
                Skill[n].CdTime = buffer.ReadInt32();
                Skill[n].ClassReq = buffer.ReadInt32();
                Skill[n].Dir = (byte)buffer.ReadInt32();
                Skill[n].Duration = buffer.ReadInt32();
                Skill[n].Icon = buffer.ReadInt32();
                Skill[n].Interval = buffer.ReadInt32();
                Skill[n].IsAoE = Convert.ToBoolean(buffer.ReadInt32());
                Skill[n].LevelReq = buffer.ReadInt32();
                Skill[n].Map = buffer.ReadInt32();
                Skill[n].MpCost = buffer.ReadInt32();
                Skill[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Skill[n].Range = buffer.ReadInt32();
                Skill[n].SkillAnim = buffer.ReadInt32();
                Skill[n].StunDuration = buffer.ReadInt32();
                Skill[n].Type = (byte)buffer.ReadInt32();
                Skill[n].Vital = buffer.ReadInt32();
                Skill[n].X = buffer.ReadInt32();
                Skill[n].Y = buffer.ReadInt32();

                Skill[n].IsProjectile = buffer.ReadInt32();
                Skill[n].Projectile = buffer.ReadInt32();

                Skill[n].KnockBack = (byte)buffer.ReadInt32();
                Skill[n].KnockBackTiles = (byte)buffer.ReadInt32();

                if (Skill[n].Name == null)
                    Skill[n].Name = "";
            }

            i = 0;
            x = 0;
            n = 0;
            z = 0;

            // \\\End Read Skills Data\\\\\\\\\\

            // \\\Read Resource Data\\\\\\\\\\\\
            x = buffer.ReadInt32();
            var loopTo14 = x;
            for (i = 1; i <= loopTo14; i++)
            {
                n = buffer.ReadInt32();

                Resource[n].Animation = buffer.ReadInt32();
                Resource[n].EmptyMessage = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Resource[n].ExhaustedImage = buffer.ReadInt32();
                Resource[n].Health = buffer.ReadInt32();
                Resource[n].ExpReward = buffer.ReadInt32();
                Resource[n].ItemReward = buffer.ReadInt32();
                Resource[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Resource[n].ResourceImage = buffer.ReadInt32();
                Resource[n].ResourceType = buffer.ReadInt32();
                Resource[n].RespawnTime = buffer.ReadInt32();
                Resource[n].SuccessMessage = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Resource[n].LvlRequired = buffer.ReadInt32();
                Resource[n].ToolRequired = buffer.ReadInt32();
                Resource[n].Walkthrough = Convert.ToBoolean(buffer.ReadInt32());

                if (Resource[n].Name == null)
                    Resource[n].Name = "";
                if (Resource[n].EmptyMessage == null)
                    Resource[n].EmptyMessage = "";
                if (Resource[n].SuccessMessage == null)
                    Resource[n].SuccessMessage = "";
            }

            i = 0;
            n = 0;
            x = 0;
            z = 0;

            // \\\End Read Resource Data\\\\\\\\\\\\

            buffer.Dispose();
        }

        private static void Packet_Mapreport(ref byte[] data)
        {
            int I;
            ByteStream buffer = new ByteStream(data);
            for (I = 1; I <= Constants.MAX_MAPS; I++)
                MapNames[I] = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());

            E_Globals.UpdateMapnames = true;

            buffer.Dispose();
        }

        private static void Packet_MapNames(ref byte[] data)
        {
            int I;
            ByteStream buffer = new ByteStream(data);
            for (I = 1; I <= Constants.MAX_MAPS; I++)
                MapNames[I] = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());

            buffer.Dispose();
        }

        private static void Packet_ClassEditor(ref byte[] data)
        {
            E_Globals.InitClassEditor = true;
        }
    }
}
