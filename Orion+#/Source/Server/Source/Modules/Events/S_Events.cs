using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using System.IO;
using ASFW;

namespace Engine
{
    internal static class S_Events
    {
        internal static GlobalEventsStruct[] TempEventMap;
        internal static string[] Switches;
        internal static string[] Variables;

        internal const int MaxSwitches = 500;
        internal const int MaxVariables = 500;

        internal const int PathfindingType = 1;

        // Effect Constants - Used for event options...
        internal const int EffectTypeFadein = 2;

        internal const int EffectTypeFadeout = 1;
        internal const int EffectTypeFlash = 3;
        internal const int EffectTypeFog = 4;
        internal const int EffectTypeWeather = 5;
        internal const int EffectTypeTint = 6;



        public struct MoveRouteStruct
        {
            public int Index;
            public int Data1;
            public int Data2;
            public int Data3;
            public int Data4;
            public int Data5;
            public int Data6;
        }

        public struct GlobalEventStruct
        {
            public int X;
            public int Y;
            public int Dir;
            public int Active;

            public int WalkingAnim;
            public int FixedDir;
            public int WalkThrough;
            public int ShowName;

            public int Position;

            public int GraphicType;
            public int GraphicNum;
            public int GraphicX;
            public int GraphicX2;
            public int GraphicY;
            public int GraphicY2;

            // Server Only Options
            public int MoveType;

            public int MoveSpeed;
            public int MoveFreq;
            public int MoveRouteCount;
            public MoveRouteStruct[] MoveRoute;
            public int MoveRouteStep;

            public int RepeatMoveRoute;
            public int IgnoreIfCannotMove;

            public int MoveTimer;
            public int QuestNum;
            public int MoveRouteComplete;
        }

        public struct GlobalEventsStruct
        {
            public int EventCount;
            public GlobalEventStruct[] Events;
        }

        internal struct ConditionalBranchStruct
        {
            public int Condition;
            public int Data1;
            public int Data2;
            public int Data3;
            public int CommandList;
            public int ElseCommandList;
        }

        public struct EventCommandStruct
        {
            public byte Index;
            public string Text1;
            public string Text2;
            public string Text3;
            public string Text4;
            public string Text5;
            public int Data1;
            public int Data2;
            public int Data3;
            public int Data4;
            public int Data5;
            public int Data6;
            public ConditionalBranchStruct ConditionalBranch;
            public int MoveRouteCount;
            public MoveRouteStruct[] MoveRoute;
        }

        public struct CommandListStruct
        {
            public int CommandCount;
            public int ParentList;
            public EventCommandStruct[] Commands;
        }

        public struct EventPageStruct
        {

            // These are condition variables that decide if the event even appears to the player.
            public int ChkVariable;

            public int Variableindex;
            public int VariableCondition;
            public int VariableCompare;

            public int ChkSwitch;
            public int Switchindex;
            public int SwitchCompare;

            public int ChkHasItem;
            public int HasItemindex;
            public int HasItemAmount;

            public int ChkSelfSwitch;
            public int SelfSwitchindex;
            public int SelfSwitchCompare;
            public int ChkPlayerGender;
            // End Conditions

            // Handles the Event Sprite
            public byte GraphicType;

            public int Graphic;
            public int GraphicX;
            public int GraphicY;
            public int GraphicX2;
            public int GraphicY2;

            // Handles Movement - Move Routes to come soon.
            public byte MoveType;

            public byte MoveSpeed;
            public byte MoveFreq;
            public int MoveRouteCount;
            public MoveRouteStruct[] MoveRoute;
            public int IgnoreMoveRoute;
            public int RepeatMoveRoute;

            // Guidelines for the event
            public int WalkAnim;

            public int DirFix;
            public int WalkThrough;
            public int ShowName;

            // Trigger for the event
            public byte Trigger;

            // Commands for the event
            public int CommandListCount;

            public CommandListStruct[] CommandList;

            public byte Position;

            public int QuestNum;

            // For EventMap
            public int X;

            public int Y;
        }

        public struct EventStruct
        {
            public string Name;
            public byte Globals;
            public int PageCount;
            public EventPageStruct[] Pages;
            public int X;
            public int Y;

            // Self Switches re-set on restart.
            public int[] SelfSwitches; // 0 to 4
        }

        internal struct GlobalMapEventsStruct
        {
            public int EventId;
            public int PageId;
            public int X;
            public int Y;
        }

        public struct MapEventStruct
        {
            public int Dir;
            public int X;
            public int Y;

            public int WalkingAnim;
            public int FixedDir;
            public int WalkThrough;
            public int ShowName;

            public int GraphicType;
            public int GraphicX;
            public int GraphicY;
            public int GraphicX2;
            public int GraphicY2;
            public int GraphicNum;

            public int MovementSpeed;
            public int Position;
            public int Visible;
            public int EventId;
            public int PageId;

            // Server Only Options
            public int MoveType;

            public int MoveSpeed;
            public int MoveFreq;
            public int MoveRouteCount;
            public MoveRouteStruct[] MoveRoute;
            public int MoveRouteStep;

            public int RepeatMoveRoute;
            public int IgnoreIfCannotMove;
            public int QuestNum;

            public int MoveTimer;
            public int[] SelfSwitches; // 0 to 4
            public int MoveRouteComplete;
        }

        public struct EventMapStruct
        {
            public int CurrentEvents;
            public MapEventStruct[] EventPages;
        }

        public struct EventProcessingStruct
        {
            public int Active;
            public int CurList;
            public int CurSlot;
            public int EventId;
            public int PageId;
            public int WaitingForResponse;
            public int EventMovingId;
            public int EventMovingType;
            public int ActionTimer;
            public int[] ListLeftOff;
        }



        internal enum MoveRouteOpts
        {
            MoveUp = 1,
            MoveDown,
            MoveLeft,
            MoveRight,
            MoveRandom,
            MoveTowardsPlayer,
            MoveAwayFromPlayer,
            StepForward,
            StepBack,
            Wait100Ms,
            Wait500Ms,
            Wait1000Ms,
            TurnUp,
            TurnDown,
            TurnLeft,
            TurnRight,
            Turn90Right,
            Turn90Left,
            Turn180,
            TurnRandom,
            TurnTowardPlayer,
            TurnAwayFromPlayer,
            SetSpeed8XSlower,
            SetSpeed4XSlower,
            SetSpeed2XSlower,
            SetSpeedNormal,
            SetSpeed2XFaster,
            SetSpeed4XFaster,
            SetFreqLowest,
            SetFreqLower,
            SetFreqNormal,
            SetFreqHigher,
            SetFreqHighest,
            WalkingAnimOn,
            WalkingAnimOff,
            DirFixOn,
            DirFixOff,
            WalkThroughOn,
            WalkThroughOff,
            PositionBelowPlayer,
            PositionWithPlayer,
            PositionAbovePlayer,
            ChangeGraphic
        }

        // Event Types
        internal enum EventType
        {

            // Message
            EvAddText = 1,
            EvShowText,
            EvShowChoices,

            // Game Progression
            EvPlayerVar,
            EvPlayerSwitch,
            EvSelfSwitch,

            // Flow Control
            EvCondition,
            EvExitProcess,

            // Player
            EvChangeItems,
            EvRestoreHp,
            EvRestoreMp,
            EvLevelUp,
            EvChangeLevel,
            EvChangeSkills,
            EvChangeClass,
            EvChangeSprite,
            EvChangeSex,
            EvChangePk,

            // Movement
            EvWarpPlayer,
            EvSetMoveRoute,

            // Character
            EvPlayAnimation,

            // Music and Sounds
            EvPlayBgm,
            EvFadeoutBgm,
            EvPlaySound,
            EvStopSound,

            // Etc...
            EvCustomScript,
            EvSetAccess,

            // Shop/Bank
            EvOpenBank,
            EvOpenShop,

            // New
            EvGiveExp,
            EvShowChatBubble,
            EvLabel,
            EvGotoLabel,
            EvSpawnNpc,
            EvFadeIn,
            EvFadeOut,
            EvFlashWhite,
            EvSetFog,
            EvSetWeather,
            EvSetTint,
            EvWait,
            EvOpenMail,
            EvBeginQuest,
            EvEndQuest,
            EvQuestTask,
            EvShowPicture,
            EvHidePicture,
            EvWaitMovement,
            EvHoldPlayer,
            EvReleasePlayer
        }



        public static void CreateSwitches()
        {
            int i;
            XmlClass myXml = new XmlClass()
            {
                Filename = Path.Combine(Application.StartupPath, "Data", "Switches.xml"),
                Root = "Data"
            };

            myXml.NewXmlDocument();

            for (i = 1; i <= MaxSwitches; i++)
                Switches[i] = "";

            SaveSwitches();
        }

        public static void CreateVariables()
        {
            int i;
            XmlClass myXml = new XmlClass()
            {
                Filename = Path.Combine(Application.StartupPath, "Data", "Variables.xml"),
                Root = "Data"
            };

            myXml.NewXmlDocument();

            for (i = 1; i <= MaxVariables; i++)
                Variables[i] = "";

            SaveVariables();
        }

        public static void SaveSwitches()
        {
            int i;
            XmlClass myXml = new XmlClass()
            {
                Filename = Path.Combine(Application.StartupPath, "Data", "Switches.xml"),
                Root = "Data"
            };

            myXml.LoadXml();

            for (i = 1; i <= MaxSwitches; i++)
                myXml.WriteString("Switches", "Switch" + i + "Name", Switches[i]);

            myXml.CloseXml(true);
        }

        public static void SaveVariables()
        {
            int i;
            XmlClass myXml = new XmlClass()
            {
                Filename = Path.Combine(Application.StartupPath, "Data", "Variables.xml"),
                Root = "Data"
            };

            myXml.LoadXml();

            for (i = 1; i <= MaxVariables; i++)
                myXml.WriteString("Variables", "Variable" + i + "Name", Variables[i]);

            myXml.CloseXml(true);
        }

        public static void LoadSwitches()
        {
            int i;
            XmlClass myXml = new XmlClass()
            {
                Filename = Path.Combine(Application.StartupPath, "Data", "Switches.xml"),
                Root = "Data"
            };

            if (!File.Exists(myXml.Filename))
            {
                CreateSwitches();
                return;
            }

            myXml.LoadXml();

            for (i = 1; i <= MaxSwitches; i++)
                Switches[i] = myXml.ReadString("Switches", "Switch" + i + "Name");

            myXml.CloseXml(false);
        }

        public static void LoadVariables()
        {
            int i;
            XmlClass myXml = new XmlClass()
            {
                Filename = Path.Combine(Application.StartupPath, "Data", "Variables.xml"),
                Root = "Data"
            };

            if (!File.Exists(myXml.Filename))
            {
                CreateVariables();
                return;
            }

            myXml.LoadXml();

            for (i = 1; i <= MaxVariables; i++)
                Variables[i] = myXml.ReadString("Variables", "Variable" + i + "Name");

            myXml.CloseXml(false);
        }



        public static bool CanEventMove(int index, int mapNum, int x, int y, int eventId, int walkThrough, byte dir, bool globalevent = false)
        {
            bool flag = mapNum <= 0 || mapNum > 500 || dir < 0 || dir > 3;
            checked
            {
                bool CanEventMove = false;
                if (!flag)
                {
                    bool gettingmap = S_Globals.Gettingmap;
                    if (!gettingmap)
                    {
                        CanEventMove = true;
                        bool flag2 = index == 0;
                        if (!flag2)
                        {
                            switch (dir)
                            {
                                case 0:
                                    {
                                        bool flag3 = y > 0;
                                        if (flag3)
                                        {
                                            int i = (int)modTypes.Map[mapNum].Tile[x, y - 1].Type;
                                            bool flag4 = walkThrough == 1;
                                            if (flag4)
                                            {
                                                CanEventMove = true;
                                            }
                                            else
                                            {
                                                bool flag5 = i == 1;
                                                if (flag5)
                                                {
                                                    CanEventMove = false;
                                                }
                                                else
                                                {
                                                    bool flag6 = i != 0 && i != 3 && i != 9;
                                                    if (flag6)
                                                    {
                                                        CanEventMove = false;
                                                    }
                                                    else
                                                    {
                                                        int highIndex = S_NetworkConfig.Socket.HighIndex;
                                                        for (int j = 1; j <= highIndex; j++)
                                                        {
                                                            bool flag7 = S_NetworkConfig.IsPlaying(j);
                                                            if (flag7)
                                                            {
                                                                bool flag8 = S_Players.GetPlayerMap(j) == mapNum && S_Players.GetPlayerX(j) == x && S_Players.GetPlayerY(j) == y - 1;
                                                                if (flag8)
                                                                {
                                                                    CanEventMove = false;
                                                                    bool flag9 = modTypes.Map[mapNum].Events[eventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId].Trigger == 1;
                                                                    if (flag9)
                                                                    {
                                                                        bool begineventprocessing = true;
                                                                        bool flag10 = begineventprocessing;
                                                                        if (flag10)
                                                                        {
                                                                            bool flag11 = modTypes.Map[mapNum].Events[eventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId].CommandListCount > 0;
                                                                            if (flag11)
                                                                            {
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].Active = 1;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].ActionTimer = S_General.GetTimeMs();
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].CurList = 1;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].CurSlot = 1;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].EventId = eventId;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].PageId = modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].WaitingForResponse = 0;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].ListLeftOff = new int[modTypes.Map[S_Players.GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[eventId].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId].CommandListCount + 1];
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        bool flag12 = !CanEventMove;
                                                        if (!flag12)
                                                        {
                                                            int j = 1;
                                                            for (; ; )
                                                            {
                                                                bool flag13 = (int)modTypes.MapNpc[mapNum].Npc[j].X == x && (int)modTypes.MapNpc[mapNum].Npc[j].Y == y - 1;
                                                                if (flag13)
                                                                {
                                                                    break;
                                                                }
                                                                j++;
                                                                if (j > 30)
                                                                {
                                                                    goto Block_25;
                                                                }
                                                            }
                                                            CanEventMove = false;
                                                            break;
                                                            Block_25:
                                                            bool flag14 = globalevent && S_Events.TempEventMap[mapNum].EventCount > 0;
                                                            if (flag14)
                                                            {
                                                                int eventCount = S_Events.TempEventMap[mapNum].EventCount;
                                                                for (int z = 1; z <= eventCount; z++)
                                                                {
                                                                    bool flag15 = z != eventId && z > 0 && S_Events.TempEventMap[mapNum].Events[z].X == x && S_Events.TempEventMap[mapNum].Events[z].Y == y - 1 && S_Events.TempEventMap[mapNum].Events[z].WalkThrough == 0;
                                                                    if (flag15)
                                                                    {
                                                                        return false;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                bool flag16 = modTypes.TempPlayer[index].EventMap.CurrentEvents > 0;
                                                                if (flag16)
                                                                {
                                                                    int currentEvents = modTypes.TempPlayer[index].EventMap.CurrentEvents;
                                                                    for (int z = 1; z <= currentEvents; z++)
                                                                    {
                                                                        bool flag17 = modTypes.TempPlayer[index].EventMap.EventPages[z].EventId != eventId && eventId > 0 && modTypes.TempPlayer[index].EventMap.EventPages[z].X == modTypes.TempPlayer[index].EventMap.EventPages[eventId].X && modTypes.TempPlayer[index].EventMap.EventPages[z].Y == modTypes.TempPlayer[index].EventMap.EventPages[eventId].Y - 1 && modTypes.TempPlayer[index].EventMap.EventPages[z].WalkThrough == 0;
                                                                        if (flag17)
                                                                        {
                                                                            return false;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            Types.TileRec ptr = modTypes.Map[mapNum].Tile[x, y];
                                                            byte b = 1;
                                                            bool flag18 = S_Players.IsDirBlocked(ref ptr.DirBlock, ref b);
                                                            if (flag18)
                                                            {
                                                                CanEventMove = false;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            CanEventMove = false;
                                        }
                                        break;
                                    }
                                case 1:
                                    {
                                        bool flag19 = y < (int)modTypes.Map[mapNum].MaxY;
                                        if (flag19)
                                        {
                                            int i = (int)modTypes.Map[mapNum].Tile[x, y + 1].Type;
                                            bool flag20 = walkThrough == 1;
                                            if (flag20)
                                            {
                                                CanEventMove = true;
                                            }
                                            else
                                            {
                                                bool flag21 = i == 1;
                                                if (flag21)
                                                {
                                                    CanEventMove = false;
                                                }
                                                else
                                                {
                                                    bool flag22 = i != 0 && i != 3 && i != 9;
                                                    if (flag22)
                                                    {
                                                        CanEventMove = false;
                                                    }
                                                    else
                                                    {
                                                        int highIndex2 = S_NetworkConfig.Socket.HighIndex;
                                                        for (int j = 1; j <= highIndex2; j++)
                                                        {
                                                            bool flag23 = S_NetworkConfig.IsPlaying(j);
                                                            if (flag23)
                                                            {
                                                                bool flag24 = S_Players.GetPlayerMap(j) == mapNum && S_Players.GetPlayerX(j) == x && S_Players.GetPlayerY(j) == y + 1;
                                                                if (flag24)
                                                                {
                                                                    CanEventMove = false;
                                                                    bool flag25 = modTypes.Map[mapNum].Events[eventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId].Trigger == 1;
                                                                    if (flag25)
                                                                    {
                                                                        bool begineventprocessing = true;
                                                                        bool flag26 = begineventprocessing;
                                                                        if (flag26)
                                                                        {
                                                                            bool flag27 = modTypes.Map[mapNum].Events[eventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId].CommandListCount > 0;
                                                                            if (flag27)
                                                                            {
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].Active = 1;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].ActionTimer = S_General.GetTimeMs();
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].CurList = 1;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].CurSlot = 1;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].EventId = eventId;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].PageId = modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].WaitingForResponse = 0;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].ListLeftOff = new int[modTypes.Map[S_Players.GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[eventId].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId].CommandListCount + 1];
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        bool flag28 = !CanEventMove;
                                                        if (!flag28)
                                                        {
                                                            int j = 1;
                                                            for (; ; )
                                                            {
                                                                bool flag29 = (int)modTypes.MapNpc[mapNum].Npc[j].X == x && (int)modTypes.MapNpc[mapNum].Npc[j].Y == y + 1;
                                                                if (flag29)
                                                                {
                                                                    break;
                                                                }
                                                                j++;
                                                                if (j > 30)
                                                                {
                                                                    goto Block_58;
                                                                }
                                                            }
                                                            CanEventMove = false;
                                                            break;
                                                            Block_58:
                                                            bool flag30 = globalevent && S_Events.TempEventMap[mapNum].EventCount > 0;
                                                            if (flag30)
                                                            {
                                                                int eventCount2 = S_Events.TempEventMap[mapNum].EventCount;
                                                                for (int z = 1; z <= eventCount2; z++)
                                                                {
                                                                    bool flag31 = z != eventId && z > 0 && S_Events.TempEventMap[mapNum].Events[z].X == x && S_Events.TempEventMap[mapNum].Events[z].Y == y + 1 && S_Events.TempEventMap[mapNum].Events[z].WalkThrough == 0;
                                                                    if (flag31)
                                                                    {
                                                                        return false;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                bool flag32 = modTypes.TempPlayer[index].EventMap.CurrentEvents > 0;
                                                                if (flag32)
                                                                {
                                                                    int currentEvents2 = modTypes.TempPlayer[index].EventMap.CurrentEvents;
                                                                    for (int z = 1; z <= currentEvents2; z++)
                                                                    {
                                                                        bool flag33 = modTypes.TempPlayer[index].EventMap.EventPages[z].EventId != eventId && eventId > 0 && modTypes.TempPlayer[index].EventMap.EventPages[z].X == modTypes.TempPlayer[index].EventMap.EventPages[eventId].X && modTypes.TempPlayer[index].EventMap.EventPages[z].Y == modTypes.TempPlayer[index].EventMap.EventPages[eventId].Y + 1 && modTypes.TempPlayer[index].EventMap.EventPages[z].WalkThrough == 0;
                                                                        if (flag33)
                                                                        {
                                                                            return false;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            Types.TileRec ptr2 = modTypes.Map[mapNum].Tile[x, y];
                                                            byte b = 2;
                                                            bool flag34 = S_Players.IsDirBlocked(ref ptr2.DirBlock, ref b);
                                                            if (flag34)
                                                            {
                                                                CanEventMove = false;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            CanEventMove = false;
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        bool flag35 = x > 0;
                                        if (flag35)
                                        {
                                            int i = (int)modTypes.Map[mapNum].Tile[x - 1, y].Type;
                                            bool flag36 = walkThrough == 1;
                                            if (flag36)
                                            {
                                                CanEventMove = true;
                                            }
                                            else
                                            {
                                                bool flag37 = i == 1;
                                                if (flag37)
                                                {
                                                    CanEventMove = false;
                                                }
                                                else
                                                {
                                                    bool flag38 = i != 0 && i != 3 && i != 9;
                                                    if (flag38)
                                                    {
                                                        CanEventMove = false;
                                                    }
                                                    else
                                                    {
                                                        int highIndex3 = S_NetworkConfig.Socket.HighIndex;
                                                        for (int j = 1; j <= highIndex3; j++)
                                                        {
                                                            bool flag39 = S_NetworkConfig.IsPlaying(j);
                                                            if (flag39)
                                                            {
                                                                bool flag40 = S_Players.GetPlayerMap(j) == mapNum && S_Players.GetPlayerX(j) == x - 1 && S_Players.GetPlayerY(j) == y;
                                                                if (flag40)
                                                                {
                                                                    CanEventMove = false;
                                                                    bool flag41 = modTypes.Map[mapNum].Events[eventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId].Trigger == 1;
                                                                    if (flag41)
                                                                    {
                                                                        bool begineventprocessing = true;
                                                                        bool flag42 = begineventprocessing;
                                                                        if (flag42)
                                                                        {
                                                                            bool flag43 = modTypes.Map[mapNum].Events[eventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId].CommandListCount > 0;
                                                                            if (flag43)
                                                                            {
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].Active = 1;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].ActionTimer = S_General.GetTimeMs();
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].CurList = 1;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].CurSlot = 1;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].EventId = eventId;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].PageId = modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].WaitingForResponse = 0;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].ListLeftOff = new int[modTypes.Map[S_Players.GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[eventId].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId].CommandListCount + 1];
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        bool flag44 = !CanEventMove;
                                                        if (!flag44)
                                                        {
                                                            int j = 1;
                                                            for (; ; )
                                                            {
                                                                bool flag45 = (int)modTypes.MapNpc[mapNum].Npc[j].X == x - 1 && (int)modTypes.MapNpc[mapNum].Npc[j].Y == y;
                                                                if (flag45)
                                                                {
                                                                    break;
                                                                }
                                                                j++;
                                                                if (j > 30)
                                                                {
                                                                    goto Block_91;
                                                                }
                                                            }
                                                            CanEventMove = false;
                                                            break;
                                                            Block_91:
                                                            bool flag46 = globalevent && S_Events.TempEventMap[mapNum].EventCount > 0;
                                                            if (flag46)
                                                            {
                                                                int eventCount3 = S_Events.TempEventMap[mapNum].EventCount;
                                                                for (int z = 1; z <= eventCount3; z++)
                                                                {
                                                                    bool flag47 = z != eventId && z > 0 && S_Events.TempEventMap[mapNum].Events[z].X == x - 1 && S_Events.TempEventMap[mapNum].Events[z].Y == y && S_Events.TempEventMap[mapNum].Events[z].WalkThrough == 0;
                                                                    if (flag47)
                                                                    {
                                                                        return false;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                bool flag48 = modTypes.TempPlayer[index].EventMap.CurrentEvents > 0;
                                                                if (flag48)
                                                                {
                                                                    int currentEvents3 = modTypes.TempPlayer[index].EventMap.CurrentEvents;
                                                                    for (int z = 1; z <= currentEvents3; z++)
                                                                    {
                                                                        bool flag49 = modTypes.TempPlayer[index].EventMap.EventPages[z].EventId != eventId && eventId > 0 && modTypes.TempPlayer[index].EventMap.EventPages[z].X == modTypes.TempPlayer[index].EventMap.EventPages[eventId].X - 1 && modTypes.TempPlayer[index].EventMap.EventPages[z].Y == modTypes.TempPlayer[index].EventMap.EventPages[eventId].Y && modTypes.TempPlayer[index].EventMap.EventPages[z].WalkThrough == 0;
                                                                        if (flag49)
                                                                        {
                                                                            return false;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            Types.TileRec ptr3 = modTypes.Map[mapNum].Tile[x, y];
                                                            byte b = 3;
                                                            bool flag50 = S_Players.IsDirBlocked(ref ptr3.DirBlock, ref b);
                                                            if (flag50)
                                                            {
                                                                CanEventMove = false;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            CanEventMove = false;
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        bool flag51 = x < (int)modTypes.Map[mapNum].MaxX;
                                        if (flag51)
                                        {
                                            int i = (int)modTypes.Map[mapNum].Tile[x + 1, y].Type;
                                            bool flag52 = walkThrough == 1;
                                            if (flag52)
                                            {
                                                CanEventMove = true;
                                            }
                                            else
                                            {
                                                bool flag53 = i == 1;
                                                if (flag53)
                                                {
                                                    CanEventMove = false;
                                                }
                                                else
                                                {
                                                    bool flag54 = i != 0 && i != 3 && i != 9;
                                                    if (flag54)
                                                    {
                                                        CanEventMove = false;
                                                    }
                                                    else
                                                    {
                                                        int highIndex4 = S_NetworkConfig.Socket.HighIndex;
                                                        for (int j = 1; j <= highIndex4; j++)
                                                        {
                                                            bool flag55 = S_NetworkConfig.IsPlaying(j);
                                                            if (flag55)
                                                            {
                                                                bool flag56 = S_Players.GetPlayerMap(j) == mapNum && S_Players.GetPlayerX(j) == x + 1 && S_Players.GetPlayerY(j) == y;
                                                                if (flag56)
                                                                {
                                                                    CanEventMove = false;
                                                                    bool flag57 = modTypes.Map[mapNum].Events[eventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId].Trigger == 1;
                                                                    if (flag57)
                                                                    {
                                                                        bool begineventprocessing = true;
                                                                        bool flag58 = begineventprocessing;
                                                                        if (flag58)
                                                                        {
                                                                            bool flag59 = modTypes.Map[mapNum].Events[eventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId].CommandListCount > 0;
                                                                            if (flag59)
                                                                            {
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].Active = 1;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].ActionTimer = S_General.GetTimeMs();
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].CurList = 1;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].CurSlot = 1;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].EventId = eventId;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].PageId = modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].WaitingForResponse = 0;
                                                                                modTypes.TempPlayer[index].EventProcessing[eventId].ListLeftOff = new int[modTypes.Map[S_Players.GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[eventId].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[eventId].PageId].CommandListCount + 1];
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        bool flag60 = !CanEventMove;
                                                        if (!flag60)
                                                        {
                                                            int j = 1;
                                                            for (; ; )
                                                            {
                                                                bool flag61 = (int)modTypes.MapNpc[mapNum].Npc[j].X == x + 1 && (int)modTypes.MapNpc[mapNum].Npc[j].Y == y;
                                                                if (flag61)
                                                                {
                                                                    break;
                                                                }
                                                                j++;
                                                                if (j > 30)
                                                                {
                                                                    goto Block_124;
                                                                }
                                                            }
                                                            CanEventMove = false;
                                                            break;
                                                            Block_124:
                                                            bool flag62 = globalevent && S_Events.TempEventMap[mapNum].EventCount > 0;
                                                            if (flag62)
                                                            {
                                                                int eventCount4 = S_Events.TempEventMap[mapNum].EventCount;
                                                                for (int z = 1; z <= eventCount4; z++)
                                                                {
                                                                    bool flag63 = z != eventId && z > 0 && S_Events.TempEventMap[mapNum].Events[z].X == x + 1 && S_Events.TempEventMap[mapNum].Events[z].Y == y && S_Events.TempEventMap[mapNum].Events[z].WalkThrough == 0;
                                                                    if (flag63)
                                                                    {
                                                                        return false;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                bool flag64 = modTypes.TempPlayer[index].EventMap.CurrentEvents > 0;
                                                                if (flag64)
                                                                {
                                                                    int currentEvents4 = modTypes.TempPlayer[index].EventMap.CurrentEvents;
                                                                    for (int z = 1; z <= currentEvents4; z++)
                                                                    {
                                                                        bool flag65 = modTypes.TempPlayer[index].EventMap.EventPages[z].EventId != eventId && eventId > 0 && modTypes.TempPlayer[index].EventMap.EventPages[z].X == modTypes.TempPlayer[index].EventMap.EventPages[eventId].X + 1 && modTypes.TempPlayer[index].EventMap.EventPages[z].Y == modTypes.TempPlayer[index].EventMap.EventPages[eventId].Y && modTypes.TempPlayer[index].EventMap.EventPages[z].WalkThrough == 0;
                                                                        if (flag65)
                                                                        {
                                                                            return false;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            Types.TileRec ptr4 = modTypes.Map[mapNum].Tile[x, y];
                                                            byte b = 4;
                                                            bool flag66 = S_Players.IsDirBlocked(ref ptr4.DirBlock, ref b);
                                                            if (flag66)
                                                            {
                                                                CanEventMove = false;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            CanEventMove = false;
                                        }
                                        break;
                                    }
                            }
                        }
                    }
                }
                return CanEventMove;
            }
        }

        public static void EventDir(int playerindex, int mapNum, int eventId, int dir, bool globalevent = false)
        {
            ByteStream buffer = new ByteStream(4);
            int eventindex = 0;
            int i;

            // Check for subscript out of range

            if (S_Globals.Gettingmap == true)
                return;

            if (mapNum <= 0 || mapNum > Constants.MAX_MAPS || dir < (int)Enums.DirectionType.Up || dir > (int)Enums.DirectionType.Right)
                return;

            if (globalevent == false)
            {
                if (modTypes.TempPlayer[playerindex].EventMap.CurrentEvents > 0)
                {
                    var loopTo = modTypes.TempPlayer[playerindex].EventMap.CurrentEvents;
                    for (i = 1; i <= loopTo; i++)
                    {
                        if (eventId == i)
                        {
                            eventindex = eventId;
                            eventId = modTypes.TempPlayer[playerindex].EventMap.EventPages[i].EventId;
                            break;
                        }
                    }
                }

                if (eventindex == 0 || eventId == 0)
                    return;
            }

            if (globalevent)
            {
                if (modTypes.Map[mapNum].Events[eventId].Pages[1].DirFix == 0)
                    TempEventMap[mapNum].Events[eventId].Dir = dir;
            }
            else if (modTypes.Map[mapNum].Events[eventId].Pages[modTypes.TempPlayer[playerindex].EventMap.EventPages[eventindex].PageId].DirFix == 0)
                modTypes.TempPlayer[playerindex].EventMap.EventPages[eventindex].Dir = dir;

            buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SEventDir));
            buffer.WriteInt32(eventId);

            modDatabase.Addlog("Sent SMSG: SEventDir", S_Constants.PACKET_LOG);
            Console.WriteLine("Sent SMSG: SEventDir");

            if (globalevent)
                buffer.WriteInt32(TempEventMap[mapNum].Events[eventId].Dir);
            else
                buffer.WriteInt32(modTypes.TempPlayer[playerindex].EventMap.EventPages[eventindex].Dir);

            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void EventMove(int index, int mapNum, int eventId, int dir, int movementspeed, bool globalevent = false)
        {
            ByteStream buffer = new ByteStream(4);
            int eventindex = 0;
            int i;

            // Check for subscript out of range
            if (S_Globals.Gettingmap == true)
                return;

            if (mapNum <= 0 || mapNum > Constants.MAX_MAPS || dir < (int)Enums.DirectionType.Up || dir > (int)Enums.DirectionType.Right)
                return;

            if (globalevent == false)
            {
                if (modTypes.TempPlayer[index].EventMap.CurrentEvents > 0)
                {
                    var loopTo = modTypes.TempPlayer[index].EventMap.CurrentEvents;
                    for (i = 1; i <= loopTo; i++)
                    {
                        if (eventId == i)
                        {
                            eventindex = eventId;
                            eventId = modTypes.TempPlayer[index].EventMap.EventPages[i].EventId;
                            break;
                        }
                    }
                }

                if (eventindex == 0 || eventId == 0)
                    return;
            }
            else
            {
                eventindex = eventId;
                if (eventindex == 0)
                    return;
            }

            if (globalevent)
            {
                if (modTypes.Map[mapNum].Events[eventId].Pages[1].DirFix == 0)
                    TempEventMap[mapNum].Events[eventId].Dir = dir;
            }
            else if (modTypes.Map[mapNum].Events[eventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[eventindex].PageId].DirFix == 0)
                modTypes.TempPlayer[index].EventMap.EventPages[eventindex].Dir = dir;

            switch (dir)
            {
                case (int)Enums.DirectionType.Up:
                    {
                        if (globalevent)
                        {
                            TempEventMap[mapNum].Events[eventindex].Y = TempEventMap[mapNum].Events[eventindex].Y - 1;
                            buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SEventMove));
                            buffer.WriteInt32(eventId);
                            buffer.WriteInt32(TempEventMap[mapNum].Events[eventindex].X);
                            buffer.WriteInt32(TempEventMap[mapNum].Events[eventindex].Y);
                            buffer.WriteInt32(dir);
                            buffer.WriteInt32(TempEventMap[mapNum].Events[eventindex].Dir);
                            buffer.WriteInt32(movementspeed);

                            modDatabase.Addlog("Sent SMSG: SEventMove Dir Up GlobalEvent", S_Constants.PACKET_LOG);
                            Console.WriteLine("Sent SMSG: SEventMove Dir Up GlobalEvent");

                            if (globalevent)
                                S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                            else
                                S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
                            buffer.Dispose();
                        }
                        else
                        {
                            modTypes.TempPlayer[index].EventMap.EventPages[eventindex].Y = modTypes.TempPlayer[index].EventMap.EventPages[eventindex].Y - 1;
                            buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SEventMove));
                            buffer.WriteInt32(eventId);
                            buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[eventindex].X);
                            buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[eventindex].Y);
                            buffer.WriteInt32(dir);
                            buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[eventindex].Dir);
                            buffer.WriteInt32(movementspeed);

                            modDatabase.Addlog("Sent SMSG: SEventMove Dir Up", S_Constants.PACKET_LOG);
                            Console.WriteLine("Sent SMSG: SEventMove Dir Up");

                            if (globalevent)
                                S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                            else
                                S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
                            buffer.Dispose();
                        }

                        break;
                    }

                case (int)Enums.DirectionType.Down:
                    {
                        if (globalevent)
                        {
                            TempEventMap[mapNum].Events[eventindex].Y = TempEventMap[mapNum].Events[eventindex].Y + 1;
                            buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SEventMove));
                            buffer.WriteInt32(eventId);
                            buffer.WriteInt32(TempEventMap[mapNum].Events[eventindex].X);
                            buffer.WriteInt32(TempEventMap[mapNum].Events[eventindex].Y);
                            buffer.WriteInt32(dir);
                            buffer.WriteInt32(TempEventMap[mapNum].Events[eventindex].Dir);
                            buffer.WriteInt32(movementspeed);

                            modDatabase.Addlog("Sent SMSG: SEventMove Down GlobalEvent", S_Constants.PACKET_LOG);
                            Console.WriteLine("Sent SMSG: SEventMove Down GlobalEvent");

                            if (globalevent)
                                S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                            else
                                S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
                            buffer.Dispose();
                        }
                        else
                        {
                            modTypes.TempPlayer[index].EventMap.EventPages[eventindex].Y = modTypes.TempPlayer[index].EventMap.EventPages[eventindex].Y + 1;
                            buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SEventMove));
                            buffer.WriteInt32(eventId);
                            buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[eventindex].X);
                            buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[eventindex].Y);
                            buffer.WriteInt32(dir);
                            buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[eventindex].Dir);
                            buffer.WriteInt32(movementspeed);

                            modDatabase.Addlog("Sent SMSG: SEventMove", S_Constants.PACKET_LOG);
                            Console.WriteLine("Sent SMSG: SEventMove");

                            if (globalevent)
                                S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                            else
                                S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
                            buffer.Dispose();
                        }

                        break;
                    }

                case (int)Enums.DirectionType.Left:
                    {
                        if (globalevent)
                        {
                            TempEventMap[mapNum].Events[eventindex].X = TempEventMap[mapNum].Events[eventindex].X - 1;
                            buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SEventMove));
                            buffer.WriteInt32(eventId);
                            buffer.WriteInt32(TempEventMap[mapNum].Events[eventindex].X);
                            buffer.WriteInt32(TempEventMap[mapNum].Events[eventindex].Y);
                            buffer.WriteInt32(dir);
                            buffer.WriteInt32(TempEventMap[mapNum].Events[eventindex].Dir);
                            buffer.WriteInt32(movementspeed);

                            modDatabase.Addlog("Sent SMSG: SEventMove Left GlobalEvent", S_Constants.PACKET_LOG);
                            Console.WriteLine("Sent SMSG: SEventMove Left GlobalEvent");

                            if (globalevent)
                                S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                            else
                                S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
                            buffer.Dispose();
                        }
                        else
                        {
                            modTypes.TempPlayer[index].EventMap.EventPages[eventindex].X = modTypes.TempPlayer[index].EventMap.EventPages[eventindex].X - 1;
                            buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SEventMove));
                            buffer.WriteInt32(eventId);
                            buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[eventindex].X);
                            buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[eventindex].Y);
                            buffer.WriteInt32(dir);
                            buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[eventindex].Dir);
                            buffer.WriteInt32(movementspeed);

                            modDatabase.Addlog("Sent SMSG: SEventMove", S_Constants.PACKET_LOG);
                            Console.WriteLine("Sent SMSG: SEventMove");

                            if (globalevent)
                                S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                            else
                                S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
                            buffer.Dispose();
                        }

                        break;
                    }

                case (int)Enums.DirectionType.Right:
                    {
                        if (globalevent)
                        {
                            TempEventMap[mapNum].Events[eventindex].X = TempEventMap[mapNum].Events[eventindex].X + 1;
                            buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SEventMove));
                            buffer.WriteInt32(eventId);
                            buffer.WriteInt32(TempEventMap[mapNum].Events[eventindex].X);
                            buffer.WriteInt32(TempEventMap[mapNum].Events[eventindex].Y);
                            buffer.WriteInt32(dir);
                            buffer.WriteInt32(TempEventMap[mapNum].Events[eventindex].Dir);
                            buffer.WriteInt32(movementspeed);

                            modDatabase.Addlog("Sent SMSG: SEventMove GlobalEvent", S_Constants.PACKET_LOG);
                            Console.WriteLine("Sent SMSG: SEventMove GlobalEvent");

                            if (globalevent)
                                S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                            else
                                S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
                            buffer.Dispose();
                        }
                        else
                        {
                            modTypes.TempPlayer[index].EventMap.EventPages[eventindex].X = modTypes.TempPlayer[index].EventMap.EventPages[eventindex].X + 1;
                            buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SEventMove));
                            buffer.WriteInt32(eventId);
                            buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[eventindex].X);
                            buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[eventindex].Y);
                            buffer.WriteInt32(dir);
                            buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[eventindex].Dir);
                            buffer.WriteInt32(movementspeed);

                            modDatabase.Addlog("Sent SMSG: SEventMove", S_Constants.PACKET_LOG);
                            Console.WriteLine("Sent SMSG: SEventMove");

                            if (globalevent)
                                S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                            else
                                S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
                            buffer.Dispose();
                        }

                        break;
                    }
            }
        }

        public static bool IsOneBlockAway(int x1, int y1, int x2, int y2)
        {
            bool flag = x1 == x2;
            checked
            {
                bool IsOneBlockAway;
                if (flag)
                {
                    bool flag2 = y1 == y2 - 1 || y1 == y2 + 1;
                    IsOneBlockAway = flag2;
                }
                else
                {
                    bool flag3 = y1 == y2;
                    if (flag3)
                    {
                        bool flag4 = x1 == x2 - 1 || x1 == x2 + 1;
                        IsOneBlockAway = flag4;
                    }
                    else
                    {
                        IsOneBlockAway = false;
                    }
                }
                return IsOneBlockAway;
            }
        }

        public static int GetNpcDir(int x, int y, int x1, int y1)
        {
            int i = 3;
            checked
            {
                bool flag = x - x1 > 0;
                int distance = 0;
                if (flag)
                {
                    bool flag2 = x - x1 > distance;
                    if (flag2)
                    {
                        i = 3;
                        distance = x - x1;
                    }
                }
                else
                {
                    bool flag3 = x - x1 < 0;
                    if (flag3)
                    {
                        bool flag4 = (x - x1) * -1 > distance;
                        if (flag4)
                        {
                            i = 2;
                            distance = (x - x1) * -1;
                        }
                    }
                }
                bool flag5 = y - y1 > 0;
                if (flag5)
                {
                    bool flag6 = y - y1 > distance;
                    if (flag6)
                    {
                        i = 1;
                        distance = y - y1;
                    }
                }
                else
                {
                    bool flag7 = y - y1 < 0;
                    if (flag7)
                    {
                        bool flag8 = (y - y1) * -1 > distance;
                        if (flag8)
                        {
                            i = 0;
                            distance = (y - y1) * -1;
                        }
                    }
                }
                return i;
            }
        }

        public static int CanEventMoveTowardsPlayer(int playerId, int mapNum, int eventId)
        {
            int CanEventMoveTowardsPlayer = 4;
            bool flag = playerId <= 0 || playerId > 70;
            if (!flag)
            {
                bool flag2 = mapNum <= 0 || mapNum > 500;
                if (!flag2)
                {
                    bool flag3 = eventId <= 0 || eventId > modTypes.TempPlayer[playerId].EventMap.CurrentEvents;
                    if (!flag3)
                    {
                        bool gettingmap = S_Globals.Gettingmap;
                        if (!gettingmap)
                        {
                            int x = S_Players.GetPlayerX(playerId);
                            int y = S_Players.GetPlayerY(playerId);
                            int x2 = modTypes.TempPlayer[playerId].EventMap.EventPages[eventId].X;
                            int y2 = modTypes.TempPlayer[playerId].EventMap.EventPages[eventId].Y;
                            int walkThrough = modTypes.Map[mapNum].Events[modTypes.TempPlayer[playerId].EventMap.EventPages[eventId].EventId].Pages[modTypes.TempPlayer[playerId].EventMap.EventPages[eventId].PageId].WalkThrough;
                            int i = checked((int)Math.Round(Convert.ToDouble(unchecked(VBMath.Rnd() * 5f))));
                            bool didwalk = false;
                            switch (i)
                            {
                                case 0:
                                    {
                                        bool flag4 = y2 > y && !didwalk;
                                        if (flag4)
                                        {
                                            bool flag5 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 0, false);
                                            if (flag5)
                                            {
                                                return 0;
                                            }
                                        }
                                        bool flag6 = y2 < y && !didwalk;
                                        if (flag6)
                                        {
                                            bool flag7 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 1, false);
                                            if (flag7)
                                            {
                                                return 1;
                                            }
                                        }
                                        bool flag8 = x2 > x && !didwalk;
                                        if (flag8)
                                        {
                                            bool flag9 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 2, false);
                                            if (flag9)
                                            {
                                                return 2;
                                            }
                                        }
                                        bool flag10 = x2 < x && !didwalk;
                                        if (flag10)
                                        {
                                            bool flag11 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 3, false);
                                            if (flag11)
                                            {
                                                return 3;
                                            }
                                        }
                                        break;
                                    }
                                case 1:
                                    {
                                        bool flag12 = x2 < x && !didwalk;
                                        if (flag12)
                                        {
                                            bool flag13 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 3, false);
                                            if (flag13)
                                            {
                                                return 3;
                                            }
                                        }
                                        bool flag14 = x2 > x && !didwalk;
                                        if (flag14)
                                        {
                                            bool flag15 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 2, false);
                                            if (flag15)
                                            {
                                                return 2;
                                            }
                                        }
                                        bool flag16 = y2 < y && !didwalk;
                                        if (flag16)
                                        {
                                            bool flag17 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 1, false);
                                            if (flag17)
                                            {
                                                return 1;
                                            }
                                        }
                                        bool flag18 = y2 > y && !didwalk;
                                        if (flag18)
                                        {
                                            bool flag19 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 0, false);
                                            if (flag19)
                                            {
                                                return 0;
                                            }
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        bool flag20 = y2 < y && !didwalk;
                                        if (flag20)
                                        {
                                            bool flag21 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 1, false);
                                            if (flag21)
                                            {
                                                return 1;
                                            }
                                        }
                                        bool flag22 = y2 > y && !didwalk;
                                        if (flag22)
                                        {
                                            bool flag23 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 0, false);
                                            if (flag23)
                                            {
                                                return 0;
                                            }
                                        }
                                        bool flag24 = x2 < x && !didwalk;
                                        if (flag24)
                                        {
                                            bool flag25 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 3, false);
                                            if (flag25)
                                            {
                                                return 3;
                                            }
                                        }
                                        bool flag26 = x2 > x && !didwalk;
                                        if (flag26)
                                        {
                                            bool flag27 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 2, false);
                                            if (flag27)
                                            {
                                                return 2;
                                            }
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        bool flag28 = x2 > x && !didwalk;
                                        if (flag28)
                                        {
                                            bool flag29 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 2, false);
                                            if (flag29)
                                            {
                                                return 2;
                                            }
                                        }
                                        bool flag30 = x2 < x && !didwalk;
                                        if (flag30)
                                        {
                                            bool flag31 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 3, false);
                                            if (flag31)
                                            {
                                                return 3;
                                            }
                                        }
                                        bool flag32 = y2 > y && !didwalk;
                                        if (flag32)
                                        {
                                            bool flag33 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 0, false);
                                            if (flag33)
                                            {
                                                return 0;
                                            }
                                        }
                                        bool flag34 = y2 < y && !didwalk;
                                        if (flag34)
                                        {
                                            bool flag35 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 1, false);
                                            if (flag35)
                                            {
                                                return 1;
                                            }
                                        }
                                        break;
                                    }
                            }
                            CanEventMoveTowardsPlayer = S_GameLogic.Random(0, 3);
                        }
                    }
                }
            }
            return CanEventMoveTowardsPlayer;
        }

        public static int CanEventMoveAwayFromPlayer(int playerId, int mapNum, int eventId)
        {
            int CanEventMoveAwayFromPlayer = 5;
            bool flag = playerId <= 0 || playerId > 70;
            if (!flag)
            {
                bool flag2 = mapNum <= 0 || mapNum > 500;
                if (!flag2)
                {
                    bool flag3 = eventId <= 0 || eventId > modTypes.TempPlayer[playerId].EventMap.CurrentEvents;
                    if (!flag3)
                    {
                        bool gettingmap = S_Globals.Gettingmap;
                        if (!gettingmap)
                        {
                            int x = S_Players.GetPlayerX(playerId);
                            int y = S_Players.GetPlayerY(playerId);
                            int x2 = modTypes.TempPlayer[playerId].EventMap.EventPages[eventId].X;
                            int y2 = modTypes.TempPlayer[playerId].EventMap.EventPages[eventId].Y;
                            int walkThrough = modTypes.Map[mapNum].Events[modTypes.TempPlayer[playerId].EventMap.EventPages[eventId].EventId].Pages[modTypes.TempPlayer[playerId].EventMap.EventPages[eventId].PageId].WalkThrough;
                            int i = checked((int)Math.Round((double)Convert.ToInt32(unchecked(Microsoft.VisualBasic.VBMath.Rnd() * 5f))));
                            bool didwalk = false;
                            switch (i)
                            {
                                case 0:
                                    {
                                        bool flag4 = y2 > y && !didwalk;
                                        if (flag4)
                                        {
                                            bool flag5 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 1, false);
                                            if (flag5)
                                            {
                                                return 1;
                                            }
                                        }
                                        bool flag6 = y2 < y && !didwalk;
                                        if (flag6)
                                        {
                                            bool flag7 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 0, false);
                                            if (flag7)
                                            {
                                                return 0;
                                            }
                                        }
                                        bool flag8 = x2 > x && !didwalk;
                                        if (flag8)
                                        {
                                            bool flag9 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 3, false);
                                            if (flag9)
                                            {
                                                return 3;
                                            }
                                        }
                                        bool flag10 = x2 < x && !didwalk;
                                        if (flag10)
                                        {
                                            bool flag11 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 2, false);
                                            if (flag11)
                                            {
                                                return 2;
                                            }
                                        }
                                        break;
                                    }
                                case 1:
                                    {
                                        bool flag12 = x2 < x && !didwalk;
                                        if (flag12)
                                        {
                                            bool flag13 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 2, false);
                                            if (flag13)
                                            {
                                                return 2;
                                            }
                                        }
                                        bool flag14 = x2 > x && !didwalk;
                                        if (flag14)
                                        {
                                            bool flag15 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 3, false);
                                            if (flag15)
                                            {
                                                return 3;
                                            }
                                        }
                                        bool flag16 = y2 < y && !didwalk;
                                        if (flag16)
                                        {
                                            bool flag17 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 0, false);
                                            if (flag17)
                                            {
                                                return 0;
                                            }
                                        }
                                        bool flag18 = y2 > y && !didwalk;
                                        if (flag18)
                                        {
                                            bool flag19 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 1, false);
                                            if (flag19)
                                            {
                                                return 1;
                                            }
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        bool flag20 = y2 < y && !didwalk;
                                        if (flag20)
                                        {
                                            bool flag21 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 0, false);
                                            if (flag21)
                                            {
                                                return 0;
                                            }
                                        }
                                        bool flag22 = y2 > y && !didwalk;
                                        if (flag22)
                                        {
                                            bool flag23 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 1, false);
                                            if (flag23)
                                            {
                                                return 1;
                                            }
                                        }
                                        bool flag24 = x2 < x && !didwalk;
                                        if (flag24)
                                        {
                                            bool flag25 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 2, false);
                                            if (flag25)
                                            {
                                                return 2;
                                            }
                                        }
                                        bool flag26 = x2 > x && !didwalk;
                                        if (flag26)
                                        {
                                            bool flag27 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 3, false);
                                            if (flag27)
                                            {
                                                return 3;
                                            }
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        bool flag28 = x2 > x && !didwalk;
                                        if (flag28)
                                        {
                                            bool flag29 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 3, false);
                                            if (flag29)
                                            {
                                                return 3;
                                            }
                                        }
                                        bool flag30 = x2 < x && !didwalk;
                                        if (flag30)
                                        {
                                            bool flag31 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 2, false);
                                            if (flag31)
                                            {
                                                return 2;
                                            }
                                        }
                                        bool flag32 = y2 > y && !didwalk;
                                        if (flag32)
                                        {
                                            bool flag33 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 1, false);
                                            if (flag33)
                                            {
                                                return 1;
                                            }
                                        }
                                        bool flag34 = y2 < y && !didwalk;
                                        if (flag34)
                                        {
                                            bool flag35 = S_Events.CanEventMove(playerId, mapNum, x2, y2, eventId, walkThrough, 0, false);
                                            if (flag35)
                                            {
                                                return 0;
                                            }
                                        }
                                        break;
                                    }
                            }
                            CanEventMoveAwayFromPlayer = S_GameLogic.Random(0, 3);
                        }
                    }
                }
            }
            return CanEventMoveAwayFromPlayer;
        }

        public static int GetDirToPlayer(int playerId, int mapNum, int eventId)
        {
            bool flag = playerId <= 0 || playerId > 70;
            checked
            {
                int GetDirToPlayer = 0;
                if (!flag)
                {
                    bool flag2 = mapNum <= 0 || mapNum > 500;
                    if (!flag2)
                    {
                        bool flag3 = eventId <= 0 || eventId > modTypes.TempPlayer[playerId].EventMap.CurrentEvents;
                        if (!flag3)
                        {
                            int x = S_Players.GetPlayerX(playerId);
                            int y = S_Players.GetPlayerY(playerId);
                            int x2 = modTypes.TempPlayer[playerId].EventMap.EventPages[eventId].X;
                            int y2 = modTypes.TempPlayer[playerId].EventMap.EventPages[eventId].Y;
                            int i = 3;
                            bool flag4 = x - x2 > 0;
                            int distance = 0;
                            if (flag4)
                            {
                                bool flag5 = x - x2 > distance;
                                if (flag5)
                                {
                                    i = 3;
                                    distance = x - x2;
                                }
                            }
                            else
                            {
                                bool flag6 = x - x2 < 0;
                                if (flag6)
                                {
                                    bool flag7 = (x - x2) * -1 > distance;
                                    if (flag7)
                                    {
                                        i = 2;
                                        distance = (x - x2) * -1;
                                    }
                                }
                            }
                            bool flag8 = y - y2 > 0;
                            if (flag8)
                            {
                                bool flag9 = y - y2 > distance;
                                if (flag9)
                                {
                                    i = 1;
                                    distance = y - y2;
                                }
                            }
                            else
                            {
                                bool flag10 = y - y2 < 0;
                                if (flag10)
                                {
                                    bool flag11 = (y - y2) * -1 > distance;
                                    if (flag11)
                                    {
                                        i = 0;
                                        distance = (y - y2) * -1;
                                    }
                                }
                            }
                            GetDirToPlayer = i;
                        }
                    }
                }
                return GetDirToPlayer;
            }
        }

        public static int GetDirAwayFromPlayer(int playerId, int mapNum, int eventId)
        {
            bool flag = playerId <= 0 || playerId > 70;
            checked
            {
                int GetDirAwayFromPlayer = 0;
                if (!flag)
                {
                    bool flag2 = mapNum <= 0 || mapNum > 500;
                    if (!flag2)
                    {
                        bool flag3 = eventId <= 0 || eventId > modTypes.TempPlayer[playerId].EventMap.CurrentEvents;
                        if (!flag3)
                        {
                            int x = S_Players.GetPlayerX(playerId);
                            int y = S_Players.GetPlayerY(playerId);
                            int x2 = modTypes.TempPlayer[playerId].EventMap.EventPages[eventId].X;
                            int y2 = modTypes.TempPlayer[playerId].EventMap.EventPages[eventId].Y;
                            int i = 3;
                            bool flag4 = x - x2 > 0;
                            int distance = 0;
                            if (flag4)
                            {
                                bool flag5 = x - x2 > distance;
                                if (flag5)
                                {
                                    i = 2;
                                    distance = x - x2;
                                }
                            }
                            else
                            {
                                bool flag6 = x - x2 < 0;
                                if (flag6)
                                {
                                    bool flag7 = (x - x2) * -1 > distance;
                                    if (flag7)
                                    {
                                        i = 3;
                                        distance = (x - x2) * -1;
                                    }
                                }
                            }
                            bool flag8 = y - y2 > 0;
                            if (flag8)
                            {
                                bool flag9 = y - y2 > distance;
                                if (flag9)
                                {
                                    i = 0;
                                    distance = y - y2;
                                }
                            }
                            else
                            {
                                bool flag10 = y - y2 < 0;
                                if (flag10)
                                {
                                    bool flag11 = (y - y2) * -1 > distance;
                                    if (flag11)
                                    {
                                        i = 1;
                                        distance = (y - y2) * -1;
                                    }
                                }
                            }
                            GetDirAwayFromPlayer = i;
                        }
                    }
                }
                return GetDirAwayFromPlayer;
            }
        }



        public static void Packet_EventChatReply(int index, ref byte[] data)
        {
            int eventId;
            int pageId;
            int reply;
            int i;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CEventChatReply");

            eventId = buffer.ReadInt32();
            pageId = buffer.ReadInt32();
            reply = buffer.ReadInt32();

            if (modTypes.TempPlayer[index].EventProcessingCount > 0)
            {
                var loopTo = modTypes.TempPlayer[index].EventProcessingCount;
                for (i = 1; i <= loopTo; i++)
                {
                    if (modTypes.TempPlayer[index].EventProcessing[i].EventId == eventId && modTypes.TempPlayer[index].EventProcessing[i].PageId == pageId)
                    {
                        if (modTypes.TempPlayer[index].EventProcessing[i].WaitingForResponse == 1)
                        {
                            if (reply == 0)
                            {
                                if (modTypes.Map[S_Players.GetPlayerMap(index)].Events[eventId].Pages[pageId].CommandList[modTypes.TempPlayer[index].EventProcessing[i].CurList].Commands[modTypes.TempPlayer[index].EventProcessing[i].CurSlot - 1].Index == (byte)EventType.EvShowText)
                                    modTypes.TempPlayer[index].EventProcessing[i].WaitingForResponse = 0;
                            }
                            else if (reply > 0)
                            {
                                if (modTypes.Map[S_Players.GetPlayerMap(index)].Events[eventId].Pages[pageId].CommandList[modTypes.TempPlayer[index].EventProcessing[i].CurList].Commands[modTypes.TempPlayer[index].EventProcessing[i].CurSlot - 1].Index == (byte)EventType.EvShowChoices)
                                {
                                    switch (reply)
                                    {
                                        case 1:
                                            {
                                                modTypes.TempPlayer[index].EventProcessing[i].ListLeftOff[modTypes.TempPlayer[index].EventProcessing[i].CurList] = modTypes.TempPlayer[index].EventProcessing[i].CurSlot - 1;
                                                modTypes.TempPlayer[index].EventProcessing[i].CurList = modTypes.Map[S_Players.GetPlayerMap(index)].Events[eventId].Pages[pageId].CommandList[modTypes.TempPlayer[index].EventProcessing[i].CurList].Commands[modTypes.TempPlayer[index].EventProcessing[i].CurSlot - 1].Data1;
                                                modTypes.TempPlayer[index].EventProcessing[i].CurSlot = 1;
                                                break;
                                            }

                                        case 2:
                                            {
                                                modTypes.TempPlayer[index].EventProcessing[i].ListLeftOff[modTypes.TempPlayer[index].EventProcessing[i].CurList] = modTypes.TempPlayer[index].EventProcessing[i].CurSlot - 1;
                                                modTypes.TempPlayer[index].EventProcessing[i].CurList = modTypes.Map[S_Players.GetPlayerMap(index)].Events[eventId].Pages[pageId].CommandList[modTypes.TempPlayer[index].EventProcessing[i].CurList].Commands[modTypes.TempPlayer[index].EventProcessing[i].CurSlot - 1].Data2;
                                                modTypes.TempPlayer[index].EventProcessing[i].CurSlot = 1;
                                                break;
                                            }

                                        case 3:
                                            {
                                                modTypes.TempPlayer[index].EventProcessing[i].ListLeftOff[modTypes.TempPlayer[index].EventProcessing[i].CurList] = modTypes.TempPlayer[index].EventProcessing[i].CurSlot - 1;
                                                modTypes.TempPlayer[index].EventProcessing[i].CurList = modTypes.Map[S_Players.GetPlayerMap(index)].Events[eventId].Pages[pageId].CommandList[modTypes.TempPlayer[index].EventProcessing[i].CurList].Commands[modTypes.TempPlayer[index].EventProcessing[i].CurSlot - 1].Data3;
                                                modTypes.TempPlayer[index].EventProcessing[i].CurSlot = 1;
                                                break;
                                            }

                                        case 4:
                                            {
                                                modTypes.TempPlayer[index].EventProcessing[i].ListLeftOff[modTypes.TempPlayer[index].EventProcessing[i].CurList] = modTypes.TempPlayer[index].EventProcessing[i].CurSlot - 1;
                                                modTypes.TempPlayer[index].EventProcessing[i].CurList = modTypes.Map[S_Players.GetPlayerMap(index)].Events[eventId].Pages[pageId].CommandList[modTypes.TempPlayer[index].EventProcessing[i].CurList].Commands[modTypes.TempPlayer[index].EventProcessing[i].CurSlot - 1].Data4;
                                                modTypes.TempPlayer[index].EventProcessing[i].CurSlot = 1;
                                                break;
                                            }
                                    }
                                }
                                modTypes.TempPlayer[index].EventProcessing[i].WaitingForResponse = 0;
                            }
                        }
                    }
                }
            }

            buffer.Dispose();
        }

        public static void Packet_Event(int index, ref byte[] data)
        {
            int i;
            bool begineventprocessing = false;
            int z;
            int x;
            int y;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CEvent");

            i = buffer.ReadInt32();
            buffer.Dispose();

            switch (S_Players.GetPlayerDir(index))
            {
                case (int)Enums.DirectionType.Up:
                    {
                        if (S_Players.GetPlayerY(index) == 0)
                            return;
                        x = S_Players.GetPlayerX(index);
                        y = S_Players.GetPlayerY(index) - 1;
                        break;
                    }

                case (int)Enums.DirectionType.Down:
                    {
                        if (S_Players.GetPlayerY(index) == modTypes.Map[S_Players.GetPlayerMap(index)].MaxY)
                            return;
                        x = S_Players.GetPlayerX(index);
                        y = S_Players.GetPlayerY(index) + 1;
                        break;
                    }

                case (int)Enums.DirectionType.Left:
                    {
                        if (S_Players.GetPlayerX(index) == 0)
                            return;
                        x = S_Players.GetPlayerX(index) - 1;
                        y = S_Players.GetPlayerY(index);
                        break;
                    }

                case (int)Enums.DirectionType.Right:
                    {
                        if (S_Players.GetPlayerX(index) == modTypes.Map[S_Players.GetPlayerMap(index)].MaxX)
                            return;
                        x = S_Players.GetPlayerX(index) + 1;
                        y = S_Players.GetPlayerY(index);
                        break;
                    }
            }

            if (modTypes.TempPlayer[index].EventMap.CurrentEvents > 0)
            {
                var loopTo = modTypes.TempPlayer[index].EventMap.CurrentEvents;
                for (z = 1; z <= loopTo; z++)
                {
                    if (modTypes.TempPlayer[index].EventMap.EventPages[z].EventId == i)
                    {
                        i = z;
                        begineventprocessing = true;
                        break;
                    }
                }
            }

            if (begineventprocessing == true)
            {
                if (modTypes.Map[S_Players.GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount > 0)
                {
                    // Process this event, it is action button and everything checks out.
                    if ((modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Active == 0))
                    {
                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Active = 1;
                        {
                            var withBlock = modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId];
                            withBlock.ActionTimer = S_General.GetTimeMs();
                            withBlock.CurList = 1;
                            withBlock.CurSlot = 1;
                            withBlock.EventId = modTypes.TempPlayer[index].EventMap.EventPages[i].EventId;
                            withBlock.PageId = modTypes.TempPlayer[index].EventMap.EventPages[i].PageId;
                            withBlock.WaitingForResponse = 0;
                            withBlock.ListLeftOff = new int[modTypes.Map[S_Players.GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount + 1];
                        }
                    }
                }
                begineventprocessing = false;
            }
        }

        public static void Packet_RequestSwitchesAndVariables(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CRequestSwitchesAndVariables");

            SendSwitchesAndVariables(index);
        }

        public static void Packet_SwitchesAndVariables(int index, ref byte[] data)
        {
            int i;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CSwitchesAndVariables");

            for (i = 1; i <= MaxSwitches; i++)
                Switches[i] = buffer.ReadString();

            for (i = 1; i <= MaxVariables; i++)
                Variables[i] = buffer.ReadString();

            SaveSwitches();
            SaveVariables();

            buffer.Dispose();

            SendSwitchesAndVariables(0, true);
        }



        public static void SendSpecialEffect(int index, int effectType, int data1 = 0, int data2 = 0, int data3 = 0, int data4 = 0)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SSpecialEffect);

            S_General.AddDebug("Sent SMSG: SSpecialEffect");

            switch (effectType)
            {
                case EffectTypeFadein:
                    {
                        buffer.WriteInt32(effectType);
                        break;
                    }

                case EffectTypeFadeout:
                    {
                        buffer.WriteInt32(effectType);
                        break;
                    }

                case EffectTypeFlash:
                    {
                        buffer.WriteInt32(effectType);
                        break;
                    }

                case EffectTypeFog:
                    {
                        buffer.WriteInt32(effectType);
                        buffer.WriteInt32(data1); // fognum
                        buffer.WriteInt32(data2); // fog movement speed
                        buffer.WriteInt32(data3); // opacity
                        break;
                    }

                case EffectTypeWeather:
                    {
                        buffer.WriteInt32(effectType);
                        buffer.WriteInt32(data1); // weather type
                        buffer.WriteInt32(data2); // weather intensity
                        break;
                    }

                case EffectTypeTint:
                    {
                        buffer.WriteInt32(effectType);
                        buffer.WriteInt32(data1); // red
                        buffer.WriteInt32(data2); // green
                        buffer.WriteInt32(data3); // blue
                        buffer.WriteInt32(data4); // alpha
                        break;
                    }
            }

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendSwitchesAndVariables(int index, bool everyone = false)
        {
            ByteStream buffer = new ByteStream(4);
            int i;

            buffer.WriteInt32((int)Packets.ServerPackets.SSwitchesAndVariables);

            S_General.AddDebug("Sent SMSG: SSwitchesAndVariables");

            for (i = 1; i <= MaxSwitches; i++)
                buffer.WriteString(Switches[i].Trim());

            for (i = 1; i <= MaxVariables; i++)
                buffer.WriteString(Variables[i].Trim());

            if (everyone)
                S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);
            else
                S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendMapEventData(int index)
        {
            ByteStream buffer = new ByteStream(4);
            int i;
            int x;
            int y;
            int z;
            int mapNum;
            int w;

            buffer.WriteInt32((int)Packets.ServerPackets.SMapEventData);
            mapNum = S_Players.GetPlayerMap(index);

            S_General.AddDebug("Sent SMSG: SMapEventData");

            // Event Data
            buffer.WriteInt32(modTypes.Map[mapNum].EventCount);

            if (modTypes.Map[mapNum].EventCount > 0)
            {
                var loopTo = modTypes.Map[mapNum].EventCount;
                for (i = 1; i <= loopTo; i++)
                {
                    {
                        var withBlock = modTypes.Map[mapNum].Events[i];
                        //Shouldnt ever be Null, Stuck a Check here but this isnt a proper fix. - Orion+# Todo
                        if (withBlock.Name == null) { withBlock.Name = "Null"; }
                        buffer.WriteString(withBlock.Name.Trim());
                        buffer.WriteInt32(withBlock.Globals);
                        buffer.WriteInt32(withBlock.X);
                        buffer.WriteInt32(withBlock.Y);
                        buffer.WriteInt32(withBlock.PageCount);
                    }
                    if (modTypes.Map[mapNum].Events[i].PageCount > 0)
                    {
                        var loopTo1 = modTypes.Map[mapNum].Events[i].PageCount;
                        for (x = 1; x <= loopTo1; x++)
                        {
                            {
                                var withBlock1 = modTypes.Map[mapNum].Events[i].Pages[x];
                                buffer.WriteInt32(withBlock1.ChkVariable);
                                buffer.WriteInt32(withBlock1.Variableindex);
                                buffer.WriteInt32(withBlock1.VariableCondition);
                                buffer.WriteInt32(withBlock1.VariableCompare);

                                buffer.WriteInt32(withBlock1.ChkSwitch);
                                buffer.WriteInt32(withBlock1.Switchindex);
                                buffer.WriteInt32(withBlock1.SwitchCompare);

                                buffer.WriteInt32(withBlock1.ChkHasItem);
                                buffer.WriteInt32(withBlock1.HasItemindex);
                                buffer.WriteInt32(withBlock1.HasItemAmount);

                                buffer.WriteInt32(withBlock1.ChkSelfSwitch);
                                buffer.WriteInt32(withBlock1.SelfSwitchindex);
                                buffer.WriteInt32(withBlock1.SelfSwitchCompare);

                                buffer.WriteInt32(withBlock1.GraphicType);
                                buffer.WriteInt32(withBlock1.Graphic);
                                buffer.WriteInt32(withBlock1.GraphicX);
                                buffer.WriteInt32(withBlock1.GraphicY);
                                buffer.WriteInt32(withBlock1.GraphicX2);
                                buffer.WriteInt32(withBlock1.GraphicY2);

                                buffer.WriteInt32(withBlock1.MoveType);
                                buffer.WriteInt32(withBlock1.MoveSpeed);
                                buffer.WriteInt32(withBlock1.MoveFreq);
                                buffer.WriteInt32(withBlock1.MoveRouteCount);

                                buffer.WriteInt32(withBlock1.IgnoreMoveRoute);
                                buffer.WriteInt32(withBlock1.RepeatMoveRoute);

                                if (withBlock1.MoveRouteCount > 0)
                                {
                                    var loopTo2 = withBlock1.MoveRouteCount;
                                    for (y = 1; y <= loopTo2; y++)
                                    {
                                        buffer.WriteInt32(withBlock1.MoveRoute[y].Index);
                                        buffer.WriteInt32(withBlock1.MoveRoute[y].Data1);
                                        buffer.WriteInt32(withBlock1.MoveRoute[y].Data2);
                                        buffer.WriteInt32(withBlock1.MoveRoute[y].Data3);
                                        buffer.WriteInt32(withBlock1.MoveRoute[y].Data4);
                                        buffer.WriteInt32(withBlock1.MoveRoute[y].Data5);
                                        buffer.WriteInt32(withBlock1.MoveRoute[y].Data6);
                                    }
                                }

                                buffer.WriteInt32(withBlock1.WalkAnim);
                                buffer.WriteInt32(withBlock1.DirFix);
                                buffer.WriteInt32(withBlock1.WalkThrough);
                                buffer.WriteInt32(withBlock1.ShowName);
                                buffer.WriteInt32(withBlock1.Trigger);
                                buffer.WriteInt32(withBlock1.CommandListCount);

                                buffer.WriteInt32(withBlock1.Position);
                                buffer.WriteInt32(withBlock1.QuestNum);
                            }

                            if (modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount > 0)
                            {
                                var loopTo3 = modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount;
                                for (y = 1; y <= loopTo3; y++)
                                {
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].ParentList);
                                    if (modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount > 0)
                                    {
                                        var loopTo4 = modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount;
                                        for (z = 1; z <= loopTo4; z++)
                                        {
                                            {
                                                var withBlock2 = modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z];
                                                buffer.WriteInt32(withBlock2.Index);
                                                buffer.WriteString((withBlock2.Text1));
                                                buffer.WriteString((withBlock2.Text2));
                                                buffer.WriteString((withBlock2.Text3));
                                                buffer.WriteString((withBlock2.Text4));
                                                buffer.WriteString((withBlock2.Text5));
                                                buffer.WriteInt32(withBlock2.Data1);
                                                buffer.WriteInt32(withBlock2.Data2);
                                                buffer.WriteInt32(withBlock2.Data3);
                                                buffer.WriteInt32(withBlock2.Data4);
                                                buffer.WriteInt32(withBlock2.Data5);
                                                buffer.WriteInt32(withBlock2.Data6);
                                                buffer.WriteInt32(withBlock2.ConditionalBranch.CommandList);
                                                buffer.WriteInt32(withBlock2.ConditionalBranch.Condition);
                                                buffer.WriteInt32(withBlock2.ConditionalBranch.Data1);
                                                buffer.WriteInt32(withBlock2.ConditionalBranch.Data2);
                                                buffer.WriteInt32(withBlock2.ConditionalBranch.Data3);
                                                buffer.WriteInt32(withBlock2.ConditionalBranch.ElseCommandList);
                                                buffer.WriteInt32(withBlock2.MoveRouteCount);
                                                if (withBlock2.MoveRouteCount > 0)
                                                {
                                                    var loopTo5 = withBlock2.MoveRouteCount;
                                                    for (w = 1; w <= loopTo5; w++)
                                                    {
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Index);
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Data1);
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Data2);
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Data3);
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Data4);
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Data5);
                                                        buffer.WriteInt32(withBlock2.MoveRoute[w].Data6);
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

            // End Event Data
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
            SendSwitchesAndVariables(index);
        }



        internal static void GivePlayerExp(int index, int exp)
        {
            int petnum;

            // give the exp

            S_Players.SetPlayerExp(index, S_Players.GetPlayerExp(index) + exp);
            S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(index), "+" + exp + " Exp", (int)Enums.ColorType.White, 1, (S_Players.GetPlayerX(index) * 32), (S_Players.GetPlayerY(index) * 32));
            // check if we've leveled
            S_Players.CheckPlayerLevelUp(index);

            if (S_Pets.PetAlive(index))
            {
                petnum = S_Pets.GetPetNum(index);

                if (S_Pets.Pet[petnum].LevelingType == 1)
                {
                    S_Pets.SetPetExp(index, (int)(S_Pets.GetPetExp(index) + (exp * (S_Pets.Pet[petnum].ExpGain / (double)100))));
                    S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(index), "+" + (exp * (S_Pets.Pet[petnum].ExpGain / (double)100)) + " Exp", (int)Enums.ColorType.White, 1, (S_Pets.GetPetX(index) * 32), (S_Pets.GetPetY(index) * 32));
                    S_Pets.CheckPetLevelUp(index);
                    S_Pets.SendPetExp(index);
                }
            }

            S_NetworkSend.SendExp(index);
            S_NetworkSend.SendPlayerData(index);
        }

        internal static void CustomScript(int index, int caseId, int mapNum, int eventId)
        {
            switch (caseId)
            {
                default:
                    {
                        S_NetworkSend.PlayerMsg(index, "You just activated custom script " + caseId + ". This script is not yet programmed.", (int)Enums.ColorType.BrightRed);
                        break;
                    }
            }
        }
    }
}
