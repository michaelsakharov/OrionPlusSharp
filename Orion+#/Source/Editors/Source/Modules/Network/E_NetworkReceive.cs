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

            Interaction.MsgBox(Msg, Microsoft.VisualBasic.Constants.vbOKOnly, "OrionClient+ Editors");

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
            Types.Classes = new ClassRec[E_Globals.Max_Classes + 1];
            var loopTo = E_Globals.Max_Classes;
            for (i = 0; i <= loopTo; i++)
                Types.Classes[i].Stat = new byte[7];
            var loopTo1 = E_Globals.Max_Classes;
            for (i = 0; i <= loopTo1; i++)
                Types.Classes[i].Vital = new int[4];
            var loopTo2 = E_Globals.Max_Classes;
            for (i = 1; i <= loopTo2; i++)
            {
                {
                    ref var withBlock = ref Types.Classes[i];
                    withBlock.Name = buffer.ReadString();
                    withBlock.Desc = buffer.ReadString();

                    withBlock.Vital[(int)Enums.VitalType.HP] = buffer.ReadInt32();
                    withBlock.Vital[(int)Enums.VitalType.MP] = buffer.ReadInt32();
                    withBlock.Vital[(int)Enums.VitalType.SP] = buffer.ReadInt32();

                    // get array size
                    z = buffer.ReadInt32();
                    // redim array
                    withBlock.MaleSprite = new int[z + 1];
                    var loopTo3 = z;
                    // loop-receive data
                    for (X = 0; X <= loopTo3; X++)
                        withBlock.MaleSprite[X] = buffer.ReadInt32();

                    // get array size
                    z = buffer.ReadInt32();
                    // redim array
                    withBlock.FemaleSprite = new int[z + 1];
                    var loopTo4 = z;
                    // loop-receive data
                    for (X = 0; X <= loopTo4; X++)
                        withBlock.FemaleSprite[X] = buffer.ReadInt32();

                    withBlock.Stat[(int)Enums.StatType.Strength] = (byte)buffer.ReadInt32();
                    withBlock.Stat[(int)Enums.StatType.Endurance] = (byte)buffer.ReadInt32();
                    withBlock.Stat[(int)Enums.StatType.Vitality] = (byte)buffer.ReadInt32();
                    withBlock.Stat[(int)Enums.StatType.Intelligence] = (byte)buffer.ReadInt32();
                    withBlock.Stat[(int)Enums.StatType.Luck] = (byte)buffer.ReadInt32();
                    withBlock.Stat[(int)Enums.StatType.Spirit] = (byte)buffer.ReadInt32();

                    withBlock.StartItem = new int[6];
                    withBlock.StartValue = new int[6];
                    for (var q = 1; q <= 5; q++)
                    {
                        withBlock.StartItem[q] = buffer.ReadInt32();
                        withBlock.StartValue[q] = buffer.ReadInt32();
                    }

                    withBlock.StartMap = buffer.ReadInt32();
                    withBlock.StartX = (byte)buffer.ReadInt32();
                    withBlock.StartY = (byte)buffer.ReadInt32();

                    withBlock.BaseExp = buffer.ReadInt32();
                }
            }

            buffer.Dispose();
        }

        private static void Packet_MapData(ref byte[] data)
        {
            int X;
            int Y;
            int i;
            int mapDir;
            ByteStream buffer = new ByteStream(Compression.DecompressBytes(data));

            E_Globals.MapData = false;

            lock (E_Types.MapLock)
            {
                if (buffer.ReadInt32() == 1)
                {
                    ClientDataBase.ClearMap();
                    E_Types.Map.mapNum = buffer.ReadInt32();
                    E_Types.Map.Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                    E_Types.Map.Music = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                    E_Types.Map.Revision = buffer.ReadInt32();
                    E_Types.Map.Moral = (byte)buffer.ReadInt32();
                    E_Types.Map.tileset = buffer.ReadInt32();
                    E_Types.Map.Up = buffer.ReadInt32();
                    E_Types.Map.Down = buffer.ReadInt32();
                    E_Types.Map.Left = buffer.ReadInt32();
                    E_Types.Map.Right = buffer.ReadInt32();
                    E_Types.Map.BootMap = buffer.ReadInt32();
                    E_Types.Map.BootX = (byte)buffer.ReadInt32();
                    E_Types.Map.BootY = (byte)buffer.ReadInt32();
                    E_Types.Map.MaxX = (byte)buffer.ReadInt32();
                    E_Types.Map.MaxY = (byte)buffer.ReadInt32();
                    E_Types.Map.WeatherType = (byte)buffer.ReadInt32();
                    E_Types.Map.Fogindex = buffer.ReadInt32();
                    E_Types.Map.WeatherIntensity = buffer.ReadInt32();
                    E_Types.Map.FogAlpha = (byte)buffer.ReadInt32();
                    E_Types.Map.FogSpeed = (byte)buffer.ReadInt32();
                    E_Types.Map.HasMapTint = (byte)buffer.ReadInt32();
                    E_Types.Map.MapTintR = (byte)buffer.ReadInt32();
                    E_Types.Map.MapTintG = (byte)buffer.ReadInt32();
                    E_Types.Map.MapTintB = (byte)buffer.ReadInt32();
                    E_Types.Map.MapTintA = (byte)buffer.ReadInt32();

                    E_Types.Map.Instanced = (byte)buffer.ReadInt32();
                    E_Types.Map.Panorama = (byte)buffer.ReadInt32();
                    E_Types.Map.Parallax = (byte)buffer.ReadInt32();
                    E_Types.Map.Brightness = (byte)buffer.ReadInt32();

                    E_Types.Map.Tile = new TileRec[E_Types.Map.MaxX + 1, E_Types.Map.MaxY + 1];

                    for (X = 1; X <= Constants.MAX_MAP_NPCS; X++)
                        E_Types.Map.Npc[X] = buffer.ReadInt32();
                    var loopTo = E_Types.Map.MaxX;
                    for (X = 0; X <= loopTo; X++)
                    {
                        var loopTo1 = E_Types.Map.MaxY;
                        for (Y = 0; Y <= loopTo1; Y++)
                        {
                            E_Types.Map.Tile[X, Y].Data1 = buffer.ReadInt32();
                            E_Types.Map.Tile[X, Y].Data2 = buffer.ReadInt32();
                            E_Types.Map.Tile[X, Y].Data3 = buffer.ReadInt32();
                            E_Types.Map.Tile[X, Y].DirBlock = (byte)buffer.ReadInt32();

                            E_Types.Map.Tile[X, Y].Layer = new TileDataRec[6];

                            for (i = 0; i <= (byte)Enums.LayerType.Count - 1; i++)
                            {
                                E_Types.Map.Tile[X, Y].Layer[i].Tileset = (byte)buffer.ReadInt32();
                                E_Types.Map.Tile[X, Y].Layer[i].X = (byte)buffer.ReadInt32();
                                E_Types.Map.Tile[X, Y].Layer[i].Y = (byte)buffer.ReadInt32();
                                E_Types.Map.Tile[X, Y].Layer[i].AutoTile = (byte)buffer.ReadInt32();
                            }
                            E_Types.Map.Tile[X, Y].Type = (byte)buffer.ReadInt32();
                        }
                    }

                    // Event Data!
                    E_EventSystem.ResetEventdata();

                    E_Types.Map.EventCount = buffer.ReadInt32();

                    if (E_Types.Map.EventCount > 0)
                    {
                        E_Types.Map.Events = new EventRec[E_Types.Map.EventCount + 1];
                        var loopTo2 = E_Types.Map.EventCount;
                        for (i = 1; i <= loopTo2; i++)
                        {
                            {
                                ref var withBlock = ref E_Types.Map.Events[i];
                                withBlock.Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                                withBlock.Globals = buffer.ReadInt32();
                                withBlock.X = buffer.ReadInt32();
                                withBlock.Y = buffer.ReadInt32();
                                withBlock.PageCount = buffer.ReadInt32();
                            }
                            if (E_Types.Map.Events[i].PageCount > 0)
                            {
                                E_Types.Map.Events[i].Pages = new EventPageRec[E_Types.Map.Events[i].PageCount + 1];
                                var loopTo3 = E_Types.Map.Events[i].PageCount;
                                for (X = 1; X <= loopTo3; X++)
                                {
                                    {
                                        ref var withBlock1 = ref E_Types.Map.Events[i].Pages[X];
                                        withBlock1.ChkVariable = buffer.ReadInt32();
                                        withBlock1.Variableindex = buffer.ReadInt32();
                                        withBlock1.VariableCondition = buffer.ReadInt32();
                                        withBlock1.VariableCompare = buffer.ReadInt32();

                                        withBlock1.ChkSwitch = buffer.ReadInt32();
                                        withBlock1.Switchindex = buffer.ReadInt32();
                                        withBlock1.SwitchCompare = buffer.ReadInt32();

                                        withBlock1.ChkHasItem = buffer.ReadInt32();
                                        withBlock1.HasItemindex = buffer.ReadInt32();
                                        withBlock1.HasItemAmount = buffer.ReadInt32();

                                        withBlock1.ChkSelfSwitch = buffer.ReadInt32();
                                        withBlock1.SelfSwitchindex = buffer.ReadInt32();
                                        withBlock1.SelfSwitchCompare = buffer.ReadInt32();

                                        withBlock1.GraphicType = (byte)buffer.ReadInt32();
                                        withBlock1.Graphic = buffer.ReadInt32();
                                        withBlock1.GraphicX = buffer.ReadInt32();
                                        withBlock1.GraphicY = buffer.ReadInt32();
                                        withBlock1.GraphicX2 = buffer.ReadInt32();
                                        withBlock1.GraphicY2 = buffer.ReadInt32();

                                        withBlock1.MoveType = (byte)buffer.ReadInt32();
                                        withBlock1.MoveSpeed = (byte)buffer.ReadInt32();
                                        withBlock1.MoveFreq = (byte)buffer.ReadInt32();

                                        withBlock1.MoveRouteCount = buffer.ReadInt32();

                                        withBlock1.IgnoreMoveRoute = buffer.ReadInt32();
                                        withBlock1.RepeatMoveRoute = buffer.ReadInt32();

                                        if (withBlock1.MoveRouteCount > 0)
                                        {
                                            E_Types.Map.Events[i].Pages[X].MoveRoute = new MoveRouteRec[withBlock1.MoveRouteCount + 1];
                                            var loopTo4 = withBlock1.MoveRouteCount;
                                            for (Y = 1; Y <= loopTo4; Y++)
                                            {
                                                withBlock1.MoveRoute[Y].Index = buffer.ReadInt32();
                                                withBlock1.MoveRoute[Y].Data1 = buffer.ReadInt32();
                                                withBlock1.MoveRoute[Y].Data2 = buffer.ReadInt32();
                                                withBlock1.MoveRoute[Y].Data3 = buffer.ReadInt32();
                                                withBlock1.MoveRoute[Y].Data4 = buffer.ReadInt32();
                                                withBlock1.MoveRoute[Y].Data5 = buffer.ReadInt32();
                                                withBlock1.MoveRoute[Y].Data6 = buffer.ReadInt32();
                                            }
                                        }

                                        withBlock1.WalkAnim = (byte)buffer.ReadInt32();
                                        withBlock1.DirFix = (byte)buffer.ReadInt32();
                                        withBlock1.WalkThrough = (byte)buffer.ReadInt32();
                                        withBlock1.ShowName = (byte)buffer.ReadInt32();
                                        withBlock1.Trigger = (byte)buffer.ReadInt32();
                                        withBlock1.CommandListCount = buffer.ReadInt32();

                                        withBlock1.Position = (byte)buffer.ReadInt32();
                                        withBlock1.Questnum = buffer.ReadInt32();

                                        withBlock1.ChkPlayerGender = buffer.ReadInt32();
                                    }

                                    if (E_Types.Map.Events[i].Pages[X].CommandListCount > 0)
                                    {
                                        E_Types.Map.Events[i].Pages[X].CommandList = new CommandListRec[E_Types.Map.Events[i].Pages[X].CommandListCount + 1];
                                        var loopTo5 = E_Types.Map.Events[i].Pages[X].CommandListCount;
                                        for (Y = 1; Y <= loopTo5; Y++)
                                        {
                                            E_Types.Map.Events[i].Pages[X].CommandList[Y].CommandCount = buffer.ReadInt32();
                                            E_Types.Map.Events[i].Pages[X].CommandList[Y].ParentList = buffer.ReadInt32();
                                            if (E_Types.Map.Events[i].Pages[X].CommandList[Y].CommandCount > 0)
                                            {
                                                E_Types.Map.Events[i].Pages[X].CommandList[Y].Commands = new EventCommandRec[E_Types.Map.Events[i].Pages[X].CommandList[Y].CommandCount + 1];
                                                var loopTo6 = E_Types.Map.Events[i].Pages[X].CommandList[Y].CommandCount;
                                                for (var z = 1; z <= loopTo6; z++)
                                                {
                                                    {
                                                        ref var withBlock2 = ref E_Types.Map.Events[i].Pages[X].CommandList[Y].Commands[z];
                                                        withBlock2.Index = buffer.ReadInt32();
                                                        withBlock2.Text1 = buffer.ReadString().Trim();
                                                        withBlock2.Text2 = buffer.ReadString().Trim();
                                                        withBlock2.Text3 = buffer.ReadString().Trim();
                                                        withBlock2.Text4 = buffer.ReadString().Trim();
                                                        withBlock2.Text5 = buffer.ReadString().Trim();
                                                        withBlock2.Data1 = buffer.ReadInt32();
                                                        withBlock2.Data2 = buffer.ReadInt32();
                                                        withBlock2.Data3 = buffer.ReadInt32();
                                                        withBlock2.Data4 = buffer.ReadInt32();
                                                        withBlock2.Data5 = buffer.ReadInt32();
                                                        withBlock2.Data6 = buffer.ReadInt32();
                                                        withBlock2.ConditionalBranch.CommandList = buffer.ReadInt32();
                                                        withBlock2.ConditionalBranch.Condition = buffer.ReadInt32();
                                                        withBlock2.ConditionalBranch.Data1 = buffer.ReadInt32();
                                                        withBlock2.ConditionalBranch.Data2 = buffer.ReadInt32();
                                                        withBlock2.ConditionalBranch.Data3 = buffer.ReadInt32();
                                                        withBlock2.ConditionalBranch.ElseCommandList = buffer.ReadInt32();
                                                        withBlock2.MoveRouteCount = buffer.ReadInt32();
                                                        if (withBlock2.MoveRouteCount > 0)
                                                        {
                                                            var oldMoveRoute = withBlock2.MoveRoute;
                                                            withBlock2.MoveRoute = new MoveRouteRec[withBlock2.MoveRouteCount + 1];
                                                            if (oldMoveRoute != null)
                                                                Array.Copy(oldMoveRoute, withBlock2.MoveRoute, Math.Min(withBlock2.MoveRouteCount + 1, oldMoveRoute.Length));
                                                            var loopTo7 = withBlock2.MoveRouteCount;
                                                            for (var w = 1; w <= loopTo7; w++)
                                                            {
                                                                withBlock2.MoveRoute[w].Index = buffer.ReadInt32();
                                                                withBlock2.MoveRoute[w].Data1 = buffer.ReadInt32();
                                                                withBlock2.MoveRoute[w].Data2 = buffer.ReadInt32();
                                                                withBlock2.MoveRoute[w].Data3 = buffer.ReadInt32();
                                                                withBlock2.MoveRoute[w].Data4 = buffer.ReadInt32();
                                                                withBlock2.MoveRoute[w].Data5 = buffer.ReadInt32();
                                                                withBlock2.MoveRoute[w].Data6 = buffer.ReadInt32();
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
                    E_Types.MapItem[i].Num = buffer.ReadInt32();
                    E_Types.MapItem[i].Value = buffer.ReadInt32();
                    E_Types.MapItem[i].X = (byte)buffer.ReadInt32();
                    E_Types.MapItem[i].Y = (byte)buffer.ReadInt32();
                }

                for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                {
                    E_Types.MapNpc[i].Num = (byte)buffer.ReadInt32();
                    E_Types.MapNpc[i].X = (byte)buffer.ReadInt32();
                    E_Types.MapNpc[i].Y = (byte)buffer.ReadInt32();
                    E_Types.MapNpc[i].Dir = (byte)buffer.ReadInt32();
                    E_Types.MapNpc[i].Vital[(int)Enums.VitalType.HP] = buffer.ReadInt32();
                    E_Types.MapNpc[i].Vital[(int)Enums.VitalType.MP] = buffer.ReadInt32();
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

            E_Globals.MapData = true;

            E_Globals.CurrentWeather = E_Types.Map.WeatherType;
            E_Globals.CurrentWeatherIntensity = E_Types.Map.WeatherIntensity;
            E_Globals.CurrentFog = E_Types.Map.Fogindex;
            E_Globals.CurrentFogSpeed = E_Types.Map.FogSpeed;
            E_Globals.CurrentFogOpacity = E_Types.Map.FogAlpha;
            E_Globals.CurrentTintR = E_Types.Map.MapTintR;
            E_Globals.CurrentTintG = E_Types.Map.MapTintG;
            E_Globals.CurrentTintB = E_Types.Map.MapTintB;
            E_Globals.CurrentTintA = E_Types.Map.MapTintA;

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
                    ref var withBlock = ref E_Types.MapNpc[i];
                    withBlock.Num = (byte)buffer.ReadInt32();
                    withBlock.X = (byte)buffer.ReadInt32();
                    withBlock.Y = (byte)buffer.ReadInt32();
                    withBlock.Dir = (byte)buffer.ReadInt32();
                    withBlock.Vital[(int)Enums.VitalType.HP] = buffer.ReadInt32();
                    withBlock.Vital[(int)Enums.VitalType.MP] = buffer.ReadInt32();
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
                ref var withBlock = ref E_Types.MapNpc[NpcNum];
                withBlock.Num = (byte)buffer.ReadInt32();
                withBlock.X = (byte)buffer.ReadInt32();
                withBlock.Y = (byte)buffer.ReadInt32();
                withBlock.Dir = (byte)buffer.ReadInt32();
                withBlock.Vital[(int)Enums.VitalType.HP] = buffer.ReadInt32();
                withBlock.Vital[(int)Enums.VitalType.MP] = buffer.ReadInt32();
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
            Types.Npc[i].Animation = buffer.ReadInt32();
            Types.Npc[i].AttackSay = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Types.Npc[i].Behaviour = (byte)buffer.ReadInt32();
            Types.Npc[i].DropChance = new int[6];
            Types.Npc[i].DropItem = new int[6];
            Types.Npc[i].DropItemValue = new int[6];
            for (x = 1; x <= 5; x++)
            {
                Types.Npc[i].DropChance[x] = buffer.ReadInt32();
                Types.Npc[i].DropItem[x] = buffer.ReadInt32();
                Types.Npc[i].DropItemValue[x] = buffer.ReadInt32();
            }

            Types.Npc[i].Exp = buffer.ReadInt32();
            Types.Npc[i].Faction = (byte)buffer.ReadInt32();
            Types.Npc[i].Hp = buffer.ReadInt32();
            Types.Npc[i].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Types.Npc[i].Range = (byte)buffer.ReadInt32();
            Types.Npc[i].SpawnTime = (byte)buffer.ReadInt32();
            Types.Npc[i].SpawnSecs = buffer.ReadInt32();
            Types.Npc[i].Sprite = buffer.ReadInt32();

            for (x = 0; x <= (byte)Enums.StatType.Count - 1; x++)
                Types.Npc[i].Stat[x] = (byte)buffer.ReadInt32();

            Types.Npc[i].QuestNum = buffer.ReadInt32();

            for (x = 1; x <= Constants.MAX_NPC_SKILLS; x++)
                Types.Npc[i].Skill[x] = (byte)buffer.ReadInt32();

            Types.Npc[i].Level = buffer.ReadInt32();
            Types.Npc[i].Damage = buffer.ReadInt32();

            if (Types.Npc[i].AttackSay == null)
                Types.Npc[i].AttackSay = "";
            if (Types.Npc[i].Name == null)
                Types.Npc[i].Name = "";

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

            Types.Shop[shopnum].BuyRate = buffer.ReadInt32();
            Types.Shop[shopnum].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Types.Shop[shopnum].Face = (byte)buffer.ReadInt32();

            for (var i = 0; i <= Constants.MAX_TRADES; i++)
            {
                Types.Shop[shopnum].TradeItem[i].CostItem = buffer.ReadInt32();
                Types.Shop[shopnum].TradeItem[i].CostValue = buffer.ReadInt32();
                Types.Shop[shopnum].TradeItem[i].Item = buffer.ReadInt32();
                Types.Shop[shopnum].TradeItem[i].ItemValue = buffer.ReadInt32();
            }

            if (Types.Shop[shopnum].Name == null)
                Types.Shop[shopnum].Name = "";

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

            Types.Skill[skillnum].AccessReq = buffer.ReadInt32();
            Types.Skill[skillnum].AoE = buffer.ReadInt32();
            Types.Skill[skillnum].CastAnim = buffer.ReadInt32();
            Types.Skill[skillnum].CastTime = buffer.ReadInt32();
            Types.Skill[skillnum].CdTime = buffer.ReadInt32();
            Types.Skill[skillnum].ClassReq = buffer.ReadInt32();
            Types.Skill[skillnum].Dir = (byte)buffer.ReadInt32();
            Types.Skill[skillnum].Duration = buffer.ReadInt32();
            Types.Skill[skillnum].Icon = buffer.ReadInt32();
            Types.Skill[skillnum].Interval = buffer.ReadInt32();
            Types.Skill[skillnum].IsAoE = Convert.ToBoolean(buffer.ReadInt32());
            Types.Skill[skillnum].LevelReq = buffer.ReadInt32();
            Types.Skill[skillnum].Map = buffer.ReadInt32();
            Types.Skill[skillnum].MpCost = buffer.ReadInt32();
            Types.Skill[skillnum].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Types.Skill[skillnum].Range = buffer.ReadInt32();
            Types.Skill[skillnum].SkillAnim = buffer.ReadInt32();
            Types.Skill[skillnum].StunDuration = buffer.ReadInt32();
            Types.Skill[skillnum].Type = (byte)buffer.ReadInt32();
            Types.Skill[skillnum].Vital = buffer.ReadInt32();
            Types.Skill[skillnum].X = buffer.ReadInt32();
            Types.Skill[skillnum].Y = buffer.ReadInt32();

            Types.Skill[skillnum].IsProjectile = buffer.ReadInt32();
            Types.Skill[skillnum].Projectile = buffer.ReadInt32();

            Types.Skill[skillnum].KnockBack = (byte)buffer.ReadInt32();
            Types.Skill[skillnum].KnockBackTiles = (byte)buffer.ReadInt32();

            if (Types.Skill[skillnum].Name == null)
                Types.Skill[skillnum].Name = "";

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

            Types.Resource[ResourceNum].Animation = buffer.ReadInt32();
            Types.Resource[ResourceNum].EmptyMessage = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Types.Resource[ResourceNum].ExhaustedImage = buffer.ReadInt32();
            Types.Resource[ResourceNum].Health = buffer.ReadInt32();
            Types.Resource[ResourceNum].ExpReward = buffer.ReadInt32();
            Types.Resource[ResourceNum].ItemReward = buffer.ReadInt32();
            Types.Resource[ResourceNum].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Types.Resource[ResourceNum].ResourceImage = buffer.ReadInt32();
            Types.Resource[ResourceNum].ResourceType = buffer.ReadInt32();
            Types.Resource[ResourceNum].RespawnTime = buffer.ReadInt32();
            Types.Resource[ResourceNum].SuccessMessage = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Types.Resource[ResourceNum].LvlRequired = buffer.ReadInt32();
            Types.Resource[ResourceNum].ToolRequired = buffer.ReadInt32();
            Types.Resource[ResourceNum].Walkthrough = Convert.ToBoolean(buffer.ReadInt32());

            if (Types.Resource[ResourceNum].Name == null)
                Types.Resource[ResourceNum].Name = "";
            if (Types.Resource[ResourceNum].EmptyMessage == null)
                Types.Resource[ResourceNum].EmptyMessage = "";
            if (Types.Resource[ResourceNum].SuccessMessage == null)
                Types.Resource[ResourceNum].SuccessMessage = "";

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
            var loopTo = Information.UBound(Types.Animation[n].Frames);
            // Update the Animation
            for (i = 0; i <= loopTo; i++)
                Types.Animation[n].Frames[i] = buffer.ReadInt32();
            var loopTo1 = Information.UBound(Types.Animation[n].LoopCount);
            for (i = 0; i <= loopTo1; i++)
                Types.Animation[n].LoopCount[i] = buffer.ReadInt32();
            var loopTo2 = Information.UBound(Types.Animation[n].LoopTime);
            for (i = 0; i <= loopTo2; i++)
                Types.Animation[n].LoopTime[i] = buffer.ReadInt32();

            Types.Animation[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Types.Animation[n].Sound = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());

            if (Types.Animation[n].Name == null)
                Types.Animation[n].Name = "";
            if (Types.Animation[n].Sound == null)
                Types.Animation[n].Sound = "";
            var loopTo3 = Information.UBound(Types.Animation[n].Sprite);
            for (i = 0; i <= loopTo3; i++)
                Types.Animation[n].Sprite[i] = buffer.ReadInt32();
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
            Types.Classes = new ClassRec[E_Globals.Max_Classes + 1];
            var loopTo = E_Globals.Max_Classes;
            for (i = 0; i <= loopTo; i++)
                Types.Classes[i].Stat = new byte[7];
            var loopTo1 = E_Globals.Max_Classes;
            for (i = 0; i <= loopTo1; i++)
                Types.Classes[i].Vital = new int[4];
            var loopTo2 = E_Globals.Max_Classes;
            for (i = 1; i <= loopTo2; i++)
            {
                {
                    ref var withBlock = ref Types.Classes[i];
                    withBlock.Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                    withBlock.Desc = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());

                    withBlock.Vital[(int)Enums.VitalType.HP] = buffer.ReadInt32();
                    withBlock.Vital[(int)Enums.VitalType.MP] = buffer.ReadInt32();
                    withBlock.Vital[(int)Enums.VitalType.SP] = buffer.ReadInt32();

                    // get array size
                    z = buffer.ReadInt32();
                    // redim array
                    withBlock.MaleSprite = new int[z + 1];
                    var loopTo3 = z;
                    // loop-receive data
                    for (x = 0; x <= loopTo3; x++)
                        withBlock.MaleSprite[x] = buffer.ReadInt32();

                    // get array size
                    z = buffer.ReadInt32();
                    // redim array
                    withBlock.FemaleSprite = new int[z + 1];
                    var loopTo4 = z;
                    // loop-receive data
                    for (x = 0; x <= loopTo4; x++)
                        withBlock.FemaleSprite[x] = buffer.ReadInt32();

                    withBlock.Stat[(int)Enums.StatType.Strength] = (byte)buffer.ReadInt32();
                    withBlock.Stat[(int)Enums.StatType.Endurance] = (byte)buffer.ReadInt32();
                    withBlock.Stat[(int)Enums.StatType.Vitality] = (byte)buffer.ReadInt32();
                    withBlock.Stat[(int)Enums.StatType.Intelligence] = (byte)buffer.ReadInt32();
                    withBlock.Stat[(int)Enums.StatType.Luck] = (byte)buffer.ReadInt32();
                    withBlock.Stat[(int)Enums.StatType.Spirit] = (byte)buffer.ReadInt32();

                    withBlock.StartItem = new int[6];
                    withBlock.StartValue = new int[6];
                    for (var q = 1; q <= 5; q++)
                    {
                        withBlock.StartItem[q] = buffer.ReadInt32();
                        withBlock.StartValue[q] = buffer.ReadInt32();
                    }

                    withBlock.StartMap = buffer.ReadInt32();
                    withBlock.StartX = (byte)buffer.ReadInt32();
                    withBlock.StartY = (byte)buffer.ReadInt32();

                    withBlock.BaseExp = buffer.ReadInt32();
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
                Types.Item[n].AccessReq = buffer.ReadInt32();

                for (z = 0; z <= (byte)Enums.StatType.Count - 1; z++)
                    Types.Item[n].Add_Stat[z] = (byte)buffer.ReadInt32();

                Types.Item[n].Animation = buffer.ReadInt32();
                Types.Item[n].BindType = (byte)buffer.ReadInt32();
                Types.Item[n].ClassReq = buffer.ReadInt32();
                Types.Item[n].Data1 = buffer.ReadInt32();
                Types.Item[n].Data2 = buffer.ReadInt32();
                Types.Item[n].Data3 = buffer.ReadInt32();
                Types.Item[n].TwoHanded = buffer.ReadInt32();
                Types.Item[n].LevelReq = buffer.ReadInt32();
                Types.Item[n].Mastery = (byte)buffer.ReadInt32();
                Types.Item[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Types.Item[n].Paperdoll = buffer.ReadInt32();
                Types.Item[n].Pic = buffer.ReadInt32();
                Types.Item[n].Price = buffer.ReadInt32();
                Types.Item[n].Rarity = (byte)buffer.ReadInt32();
                Types.Item[n].Speed = buffer.ReadInt32();

                Types.Item[n].Randomize = (byte)buffer.ReadInt32();
                Types.Item[n].RandomMin = (byte)buffer.ReadInt32();
                Types.Item[n].RandomMax = (byte)buffer.ReadInt32();

                Types.Item[n].Stackable = (byte)buffer.ReadInt32();
                Types.Item[n].Description = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());

                for (z = 0; z <= (byte)Enums.StatType.Count - 1; z++)
                    Types.Item[n].Stat_Req[z] = (byte)buffer.ReadInt32();

                Types.Item[n].Type = (byte)buffer.ReadInt32();
                Types.Item[n].SubType = (byte)buffer.ReadInt32();

                Types.Item[n].ItemLevel = (byte)buffer.ReadInt32();

                // Housing
                Types.Item[n].FurnitureWidth = buffer.ReadInt32();
                Types.Item[n].FurnitureHeight = buffer.ReadInt32();

                for (a = 0; a <= 3; a++)
                {
                    for (b = 0; b <= 3; b++)
                    {
                        Types.Item[n].FurnitureBlocks[a, b] = buffer.ReadInt32();
                        Types.Item[n].FurnitureFringe[a, b] = buffer.ReadInt32();
                    }
                }

                Types.Item[n].KnockBack = (byte)buffer.ReadInt32();
                Types.Item[n].KnockBackTiles = (byte)buffer.ReadInt32();

                Types.Item[n].Projectile = buffer.ReadInt32();
                Types.Item[n].Ammo = buffer.ReadInt32();
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
                var loopTo7 = Information.UBound(Types.Animation[n].Frames);
                // Update the Animation
                for (z = 0; z <= loopTo7; z++)
                    Types.Animation[n].Frames[z] = buffer.ReadInt32();
                var loopTo8 = Information.UBound(Types.Animation[n].LoopCount);
                for (z = 0; z <= loopTo8; z++)
                    Types.Animation[n].LoopCount[z] = buffer.ReadInt32();
                var loopTo9 = Information.UBound(Types.Animation[n].LoopTime);
                for (z = 0; z <= loopTo9; z++)
                    Types.Animation[n].LoopTime[z] = buffer.ReadInt32();

                Types.Animation[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Types.Animation[n].Sound = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());

                if (Types.Animation[n].Name == null)
                    Types.Animation[n].Name = "";
                if (Types.Animation[n].Sound == null)
                    Types.Animation[n].Sound = "";
                var loopTo10 = Information.UBound(Types.Animation[n].Sprite);
                for (z = 0; z <= loopTo10; z++)
                    Types.Animation[n].Sprite[z] = buffer.ReadInt32();
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
                Types.Npc[n].Animation = buffer.ReadInt32();
                Types.Npc[n].AttackSay = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Types.Npc[n].Behaviour = (byte)buffer.ReadInt32();
                for (z = 1; z <= 5; z++)
                {
                    Types.Npc[n].DropChance[z] = buffer.ReadInt32();
                    Types.Npc[n].DropItem[z] = buffer.ReadInt32();
                    Types.Npc[n].DropItemValue[z] = buffer.ReadInt32();
                }

                Types.Npc[n].Exp = buffer.ReadInt32();
                Types.Npc[n].Faction = (byte)buffer.ReadInt32();
                Types.Npc[n].Hp = buffer.ReadInt32();
                Types.Npc[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Types.Npc[n].Range = (byte)buffer.ReadInt32();
                Types.Npc[n].SpawnTime = (byte)buffer.ReadInt32();
                Types.Npc[n].SpawnSecs = buffer.ReadInt32();
                Types.Npc[n].Sprite = buffer.ReadInt32();

                for (z = 0; z <= (byte)Enums.StatType.Count - 1; z++)
                    Types.Npc[n].Stat[z] = (byte)buffer.ReadInt32();

                Types.Npc[n].QuestNum = buffer.ReadInt32();

                Types.Npc[n].Skill = new byte[Constants.MAX_NPC_SKILLS + 1];
                for (z = 1; z <= Constants.MAX_NPC_SKILLS; z++)
                    Types.Npc[n].Skill[z] = (byte)buffer.ReadInt32();

                Types.Npc[i].Level = buffer.ReadInt32();
                Types.Npc[i].Damage = buffer.ReadInt32();

                if (Types.Npc[n].AttackSay == null)
                    Types.Npc[n].AttackSay = "";
                if (Types.Npc[n].Name == null)
                    Types.Npc[n].Name = "";
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

                Types.Shop[n].BuyRate = buffer.ReadInt32();
                Types.Shop[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Types.Shop[n].Face = (byte)buffer.ReadInt32();

                for (z = 0; z <= Constants.MAX_TRADES; z++)
                {
                    Types.Shop[n].TradeItem[z].CostItem = buffer.ReadInt32();
                    Types.Shop[n].TradeItem[z].CostValue = buffer.ReadInt32();
                    Types.Shop[n].TradeItem[z].Item = buffer.ReadInt32();
                    Types.Shop[n].TradeItem[z].ItemValue = buffer.ReadInt32();
                }

                if (Types.Shop[n].Name == null)
                    Types.Shop[n].Name = "";
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

                Types.Skill[n].AccessReq = buffer.ReadInt32();
                Types.Skill[n].AoE = buffer.ReadInt32();
                Types.Skill[n].CastAnim = buffer.ReadInt32();
                Types.Skill[n].CastTime = buffer.ReadInt32();
                Types.Skill[n].CdTime = buffer.ReadInt32();
                Types.Skill[n].ClassReq = buffer.ReadInt32();
                Types.Skill[n].Dir = (byte)buffer.ReadInt32();
                Types.Skill[n].Duration = buffer.ReadInt32();
                Types.Skill[n].Icon = buffer.ReadInt32();
                Types.Skill[n].Interval = buffer.ReadInt32();
                Types.Skill[n].IsAoE = Convert.ToBoolean(buffer.ReadInt32());
                Types.Skill[n].LevelReq = buffer.ReadInt32();
                Types.Skill[n].Map = buffer.ReadInt32();
                Types.Skill[n].MpCost = buffer.ReadInt32();
                Types.Skill[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Types.Skill[n].Range = buffer.ReadInt32();
                Types.Skill[n].SkillAnim = buffer.ReadInt32();
                Types.Skill[n].StunDuration = buffer.ReadInt32();
                Types.Skill[n].Type = (byte)buffer.ReadInt32();
                Types.Skill[n].Vital = buffer.ReadInt32();
                Types.Skill[n].X = buffer.ReadInt32();
                Types.Skill[n].Y = buffer.ReadInt32();

                Types.Skill[n].IsProjectile = buffer.ReadInt32();
                Types.Skill[n].Projectile = buffer.ReadInt32();

                Types.Skill[n].KnockBack = (byte)buffer.ReadInt32();
                Types.Skill[n].KnockBackTiles = (byte)buffer.ReadInt32();

                if (Types.Skill[n].Name == null)
                    Types.Skill[n].Name = "";
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

                Types.Resource[n].Animation = buffer.ReadInt32();
                Types.Resource[n].EmptyMessage = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Types.Resource[n].ExhaustedImage = buffer.ReadInt32();
                Types.Resource[n].Health = buffer.ReadInt32();
                Types.Resource[n].ExpReward = buffer.ReadInt32();
                Types.Resource[n].ItemReward = buffer.ReadInt32();
                Types.Resource[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Types.Resource[n].ResourceImage = buffer.ReadInt32();
                Types.Resource[n].ResourceType = buffer.ReadInt32();
                Types.Resource[n].RespawnTime = buffer.ReadInt32();
                Types.Resource[n].SuccessMessage = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                Types.Resource[n].LvlRequired = buffer.ReadInt32();
                Types.Resource[n].ToolRequired = buffer.ReadInt32();
                Types.Resource[n].Walkthrough = Convert.ToBoolean(buffer.ReadInt32());

                if (Types.Resource[n].Name == null)
                    Types.Resource[n].Name = "";
                if (Types.Resource[n].EmptyMessage == null)
                    Types.Resource[n].EmptyMessage = "";
                if (Types.Resource[n].SuccessMessage == null)
                    Types.Resource[n].SuccessMessage = "";
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
                E_Types.MapNames[I] = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());

            E_Globals.UpdateMapnames = true;

            buffer.Dispose();
        }

        private static void Packet_MapNames(ref byte[] data)
        {
            int I;
            ByteStream buffer = new ByteStream(data);
            for (I = 1; I <= Constants.MAX_MAPS; I++)
                E_Types.MapNames[I] = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());

            buffer.Dispose();
        }

        private static void Packet_ClassEditor(ref byte[] data)
        {
            E_Globals.InitClassEditor = true;
        }
    }
}
