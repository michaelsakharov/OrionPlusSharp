using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System;
using ASFW;
using SFML.Graphics;
using SFML.Window;

namespace Engine
{
    internal static class E_EventSystem
    {


        // Temp event storage
        internal static EventRec TmpEvent;

        internal static bool IsEdit;

        internal static int CurPageNum;
        internal static int CurCommand;
        internal static int GraphicSelX;
        internal static int GraphicSelY;
        internal static int GraphicSelX2;
        internal static int GraphicSelY2;

        internal static int EventTileX;
        internal static int EventTileY;

        internal static int EditorEvent;

        internal static int GraphicSelType; // Are we selecting a graphic for a move route? A page sprite? What???
        internal static int TempMoveRouteCount;
        internal static MoveRouteRec[] TempMoveRoute;
        internal static bool IsMoveRouteCommand;
        internal static int[] ListOfEvents;

        internal static int EventReplyId;
        internal static int EventReplyPage;
        internal static int EventChatFace;

        internal static int RenameType;
        internal static int Renameindex;
        internal static int EventChatTimer;

        internal static bool EventChat;
        internal static string EventText;
        internal static bool ShowEventLbl;
        internal static string[] EventChoices = new string[5];
        internal static bool[] EventChoiceVisible = new bool[5];
        internal static int EventChatType;
        internal static int AnotherChat; // Determines if another showtext/showchoices is comming up, if so, dont close the event chatbox...

        // constants
        internal static string[] Switches = new string[501];

        internal static string[] Variables = new string[501];
        internal const int MaxSwitches = 500;
        internal const int MaxVariables = 500;

        internal static EventRec CpEvent;
        internal static EventListRec[] EventList;

        internal static bool InEvent;
        internal static bool HoldPlayer;
        internal static bool InitEventEditorForm;



        internal struct EventCommandRec
        {
            public int Index;
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
            public ConditionalBranchRec ConditionalBranch;
            public int MoveRouteCount;
            public MoveRouteRec[] MoveRoute;
        }

        internal struct MoveRouteRec
        {
            public int Index;
            public int Data1;
            public int Data2;
            public int Data3;
            public int Data4;
            public int Data5;
            public int Data6;
        }

        internal struct CommandListRec
        {
            public int CommandCount;
            public int ParentList;
            public EventCommandRec[] Commands;
        }

        internal struct ConditionalBranchRec
        {
            public int Condition;
            public int Data1;
            public int Data2;
            public int Data3;
            public int CommandList;
            public int ElseCommandList;
        }

        internal struct EventPageRec
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
            public MoveRouteRec[] MoveRoute;
            public int IgnoreMoveRoute;
            public int RepeatMoveRoute;

            // Guidelines for the event
            public byte WalkAnim;

            public byte DirFix;
            public byte WalkThrough;
            public byte ShowName;

            // Trigger for the event
            public byte Trigger;

            // Commands for the event
            public int CommandListCount;

            public CommandListRec[] CommandList;
            public byte Position;
            public int Questnum;

            // Client Needed Only
            public int X;

            public int Y;
        }

        internal struct EventRec
        {
            public string Name;
            public int Globals;
            public int PageCount;
            public EventPageRec[] Pages;
            public int X;
            public int Y;
        }

        internal struct MapEventRec
        {
            public string Name;
            public int Dir;
            public int X;
            public int Y;
            public int GraphicType;
            public int GraphicX;
            public int GraphicY;
            public int GraphicX2;
            public int GraphicY2;
            public int GraphicNum;
            public int Moving;
            public int MovementSpeed;
            public int Position;
            public int XOffset;
            public int YOffset;
            public int Steps;
            public int Visible;
            public int WalkAnim;
            public int DirFix;
            public int ShowDir;
            public int WalkThrough;
            public int ShowName;
            public int Questnum;
        }

        internal static EventRec CopyEvent;
        internal static EventPageRec CopyEventPage;

        internal struct EventListRec
        {
            public int CommandList;
            public int CommandNum;
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



        // Event Editor Stuffz Also includes event functions from the map editor (copy/paste/delete)

        public static void CopyEvent_Map(int x, int y)
        {
            int count;
            int i;

            count = E_Types.Map.EventCount;
            if (count == 0)
                return;
            var loopTo = count;
            for (i = 1; i <= loopTo; i++)
            {
                if (E_Types.Map.Events[i].X == x && E_Types.Map.Events[i].Y == y)
                {
                    // copy it
                    CopyEvent = E_Types.Map.Events[i];
                    // exit
                    return;
                }
            }
        }

        public static void PasteEvent_Map(int x, int y)
        {
            int count;
            int i;
            int eventNum = 0;

            count = E_Types.Map.EventCount;
            if (count > 0)
            {
                var loopTo = count;
                for (i = 1; i <= loopTo; i++)
                {
                    if (E_Types.Map.Events[i].X == x && E_Types.Map.Events[i].Y == y)
                        // already an event - paste over it
                        eventNum = i;
                }
            }

            // couldn't find one - create one
            if (eventNum == 0)
            {
                // increment count
                AddEvent(x, y, true);
                eventNum = count + 1;
            }

            // copy it
            E_Types.Map.Events[eventNum] = CopyEvent;
            // set position
            E_Types.Map.Events[eventNum].X = x;
            E_Types.Map.Events[eventNum].Y = y;
        }

        public static void DeleteEvent(int x, int y)
        {
            int count;
            int i;
            int lowindex = 0;

            if (!E_Globals.InMapEditor)
                return;
            if (My.MyProject.Forms.frmEvents.Visible == true)
                return;
            count = E_Types.Map.EventCount;
            var loopTo = count;
            for (i = 1; i <= loopTo; i++)
            {
                if (E_Types.Map.Events[i].X == x && E_Types.Map.Events[i].Y == y)
                {
                    // delete it
                    ClearEvent(i);
                    lowindex = i;
                    break;
                }
            }
            // not found anything
            if (lowindex == 0)
                return;
            var loopTo1 = count - 1;
            // move everything down an index
            for (i = lowindex; i <= loopTo1; i++)
                E_Types.Map.Events[i] = E_Types.Map.Events[i + 1];
            // delete the last index
            ClearEvent(count);
            // set the new count
            E_Types.Map.EventCount = count - 1;
            E_Types.Map.CurrentEvents = count - 1;
        }

        public static void AddEvent(int x, int y, bool cancelLoad = false)
        {
            int count;
            int pageCount;
            int i;

            count = E_Types.Map.EventCount + 1;
            // make sure there's not already an event
            if (count - 1 > 0)
            {
                var loopTo = count - 1;
                for (i = 1; i <= loopTo; i++)
                {
                    if (E_Types.Map.Events[i].X == x && E_Types.Map.Events[i].Y == y)
                    {
                        // already an event - edit it
                        if (!cancelLoad)
                            EventEditorInit(i);
                        return;
                    }
                }
            }
            // increment count
            E_Types.Map.EventCount = count;
            var oldEvents = E_Types.Map.Events;
            E_Types.Map.Events = new EventRec[count + 1];
            if (oldEvents != null)
                Array.Copy(oldEvents, E_Types.Map.Events, Math.Min(count + 1, oldEvents.Length));
            // set the new event
            E_Types.Map.Events[count].X = x;
            E_Types.Map.Events[count].Y = y;
            // give it a new page
            pageCount = E_Types.Map.Events[count].PageCount + 1;
            E_Types.Map.Events[count].PageCount = pageCount;
            var oldPages = E_Types.Map.Events[count].Pages;
            E_Types.Map.Events[count].Pages = new EventPageRec[pageCount + 1];
            if (oldPages != null)
                Array.Copy(oldPages, E_Types.Map.Events[count].Pages, Math.Min(pageCount + 1, oldPages.Length));
            // load the editor
            if (!cancelLoad)
                EventEditorInit(count);
        }

        public static void ClearEvent(int eventNum)
        {
            if (eventNum > E_Types.Map.EventCount || eventNum > Information.UBound(E_Types.Map.MapEvents))
                return;
            {
                var withBlock = E_Types.Map.Events[eventNum];
                withBlock.Name = "";
                withBlock.PageCount = 0;
                withBlock.Pages = new EventPageRec[1];
                withBlock.Globals = 0;
                withBlock.X = 0;
                withBlock.Y = 0;
            }
            {
                var withBlock1 = E_Types.Map.MapEvents[eventNum];
                withBlock1.Name = "";
                withBlock1.Dir = 0;
                withBlock1.ShowDir = 0;
                withBlock1.GraphicNum = 0;
                withBlock1.GraphicType = 0;
                withBlock1.GraphicX = 0;
                withBlock1.GraphicX2 = 0;
                withBlock1.GraphicY = 0;
                withBlock1.GraphicY2 = 0;
                withBlock1.MovementSpeed = 0;
                withBlock1.Moving = 0;
                withBlock1.X = 0;
                withBlock1.Y = 0;
                withBlock1.XOffset = 0;
                withBlock1.YOffset = 0;
                withBlock1.Position = 0;
                withBlock1.Visible = 0;
                withBlock1.WalkAnim = 0;
                withBlock1.DirFix = 0;
                withBlock1.WalkThrough = 0;
                withBlock1.ShowName = 0;
                withBlock1.Questnum = 0;
            }
        }

        public static void EventEditorInit(int eventNum)
        {
            // Dim i As Integer

            EditorEvent = eventNum;

            TmpEvent = E_Types.Map.Events[eventNum];
            InitEventEditorForm = true;
        }

        public static void EventEditorLoadPage(int pageNum)
        {
            // populate form

            {
                var withBlock = TmpEvent.Pages[pageNum];
                GraphicSelX = withBlock.GraphicX;
                GraphicSelY = withBlock.GraphicY;
                GraphicSelX2 = withBlock.GraphicX2;
                GraphicSelY2 = withBlock.GraphicY2;
                My.MyProject.Forms.frmEvents.cmbGraphic.SelectedIndex = withBlock.GraphicType;
                My.MyProject.Forms.frmEvents.cmbHasItem.SelectedIndex = withBlock.HasItemindex;
                if (withBlock.HasItemAmount == 0)
                    My.MyProject.Forms.frmEvents.nudCondition_HasItem.Value = 1;
                else
                    My.MyProject.Forms.frmEvents.nudCondition_HasItem.Value = withBlock.HasItemAmount;
                My.MyProject.Forms.frmEvents.cmbMoveFreq.SelectedIndex = withBlock.MoveFreq;
                My.MyProject.Forms.frmEvents.cmbMoveSpeed.SelectedIndex = withBlock.MoveSpeed;
                My.MyProject.Forms.frmEvents.cmbMoveType.SelectedIndex = withBlock.MoveType;
                My.MyProject.Forms.frmEvents.cmbPlayerVar.SelectedIndex = withBlock.Variableindex;
                My.MyProject.Forms.frmEvents.cmbPlayerSwitch.SelectedIndex = withBlock.Switchindex;
                My.MyProject.Forms.frmEvents.cmbSelfSwitch.SelectedIndex = withBlock.SelfSwitchindex;
                My.MyProject.Forms.frmEvents.cmbSelfSwitchCompare.SelectedIndex = withBlock.SelfSwitchCompare;
                My.MyProject.Forms.frmEvents.cmbPlayerSwitchCompare.SelectedIndex = withBlock.SwitchCompare;
                My.MyProject.Forms.frmEvents.cmbPlayervarCompare.SelectedIndex = withBlock.VariableCompare;
                My.MyProject.Forms.frmEvents.chkGlobal.Checked = Convert.ToBoolean(TmpEvent.Globals);
                My.MyProject.Forms.frmEvents.cmbTrigger.SelectedIndex = withBlock.Trigger;
                My.MyProject.Forms.frmEvents.chkDirFix.Checked = Convert.ToBoolean(withBlock.DirFix);
                My.MyProject.Forms.frmEvents.chkHasItem.Checked = Convert.ToBoolean(withBlock.ChkHasItem);
                My.MyProject.Forms.frmEvents.chkPlayerVar.Checked = Convert.ToBoolean(withBlock.ChkVariable);
                My.MyProject.Forms.frmEvents.chkPlayerSwitch.Checked = Convert.ToBoolean(withBlock.ChkSwitch);
                My.MyProject.Forms.frmEvents.chkSelfSwitch.Checked = Convert.ToBoolean(withBlock.ChkSelfSwitch);
                My.MyProject.Forms.frmEvents.chkWalkAnim.Checked = Convert.ToBoolean(withBlock.WalkAnim);
                My.MyProject.Forms.frmEvents.chkWalkThrough.Checked = Convert.ToBoolean(withBlock.WalkThrough);
                My.MyProject.Forms.frmEvents.chkShowName.Checked = Convert.ToBoolean(withBlock.ShowName);
                My.MyProject.Forms.frmEvents.nudPlayerVariable.Value = withBlock.VariableCondition;
                My.MyProject.Forms.frmEvents.nudGraphic.Value = withBlock.Graphic;
                if (My.MyProject.Forms.frmEvents.cmbEventQuest.Items.Count > 0)
                {
                    if (withBlock.Questnum >= 0 && withBlock.Questnum <= My.MyProject.Forms.frmEvents.cmbEventQuest.Items.Count)
                        My.MyProject.Forms.frmEvents.cmbEventQuest.SelectedIndex = withBlock.Questnum;
                }
                if (My.MyProject.Forms.frmEvents.cmbEventQuest.SelectedIndex == -1)
                    My.MyProject.Forms.frmEvents.cmbEventQuest.SelectedIndex = 0;
                if (withBlock.ChkHasItem == 0)
                    My.MyProject.Forms.frmEvents.cmbHasItem.Enabled = false;
                else
                    My.MyProject.Forms.frmEvents.cmbHasItem.Enabled = true;
                if (withBlock.ChkSelfSwitch == 0)
                {
                    My.MyProject.Forms.frmEvents.cmbSelfSwitch.Enabled = false;
                    My.MyProject.Forms.frmEvents.cmbSelfSwitchCompare.Enabled = false;
                }
                else
                {
                    My.MyProject.Forms.frmEvents.cmbSelfSwitch.Enabled = true;
                    My.MyProject.Forms.frmEvents.cmbSelfSwitchCompare.Enabled = true;
                }
                if (withBlock.ChkSwitch == 0)
                {
                    My.MyProject.Forms.frmEvents.cmbPlayerSwitch.Enabled = false;
                    My.MyProject.Forms.frmEvents.cmbPlayerSwitchCompare.Enabled = false;
                }
                else
                {
                    My.MyProject.Forms.frmEvents.cmbPlayerSwitch.Enabled = true;
                    My.MyProject.Forms.frmEvents.cmbPlayerSwitchCompare.Enabled = true;
                }
                if (withBlock.ChkVariable == 0)
                {
                    My.MyProject.Forms.frmEvents.cmbPlayerVar.Enabled = false;
                    My.MyProject.Forms.frmEvents.nudPlayerVariable.Enabled = false;
                    My.MyProject.Forms.frmEvents.cmbPlayervarCompare.Enabled = false;
                }
                else
                {
                    My.MyProject.Forms.frmEvents.cmbPlayerVar.Enabled = true;
                    My.MyProject.Forms.frmEvents.nudPlayerVariable.Enabled = true;
                    My.MyProject.Forms.frmEvents.cmbPlayervarCompare.Enabled = true;
                }
                if (My.MyProject.Forms.frmEvents.cmbMoveType.SelectedIndex == 2)
                    My.MyProject.Forms.frmEvents.btnMoveRoute.Enabled = true;
                else
                    My.MyProject.Forms.frmEvents.btnMoveRoute.Enabled = false;
                My.MyProject.Forms.frmEvents.cmbPositioning.SelectedIndex = withBlock.Position;
                // show the commands
                EventListCommands();

                EditorEvent_DrawGraphic();
            }
        }

        public static void EventEditorOk()
        {
            // copy the event data from the temp event

            E_Types.Map.Events[EditorEvent] = TmpEvent;
            // unload the form
            My.MyProject.Forms.frmEvents.Dispose();
        }

        internal static void EventListCommands()
        {
            int i;
            int curlist;
            int x;
            string indent = "";
            int[] listleftoff;
            int[] conditionalstage;

            My.MyProject.Forms.frmEvents.lstCommands.Items.Clear();

            if (TmpEvent.Pages[CurPageNum].CommandListCount > 0)
            {
                listleftoff = new int[TmpEvent.Pages[CurPageNum].CommandListCount + 1];
                conditionalstage = new int[TmpEvent.Pages[CurPageNum].CommandListCount + 1];
                // Start Up at 1
                curlist = 1;
                x = -1;
            newlist:
                ;
                var loopTo = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount;
                for (i = 1; i <= loopTo; i++)
                {
                    if (listleftoff[curlist] > 0)
                    {
                        if ((TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[listleftoff[curlist]].Index == (int)EventType.EvCondition || TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[listleftoff[curlist]].Index == (int)EventType.EvShowChoices) && conditionalstage[curlist] != 0)
                            i = listleftoff[curlist];
                        else if (listleftoff[curlist] >= i)
                            i = listleftoff[curlist] + 1;
                    }
                    if (i <= TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount)
                    {
                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Index == (int)EventType.EvCondition)
                        {
                            x = x + 1;
                            switch (conditionalstage[curlist])
                            {
                                case 0:
                                    {
                                        var oldEventList = EventList;
                                        EventList = new EventListRec[x + 1];
                                        if (oldEventList != null)
                                            Array.Copy(oldEventList, EventList, Math.Min(x + 1, oldEventList.Length));
                                        EventList[x].CommandList = curlist;
                                        EventList[x].CommandNum = i;
                                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Condition)
                                        {
                                            case 0:
                                                {
                                                    switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2)
                                                    {
                                                        case 0:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Variable [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + ". " + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] == " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3);
                                                                break;
                                                            }

                                                        case 1:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Variable [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + ". " + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] >= " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3);
                                                                break;
                                                            }

                                                        case 2:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Variable [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + ". " + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] <= " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3);
                                                                break;
                                                            }

                                                        case 3:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Variable [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + ". " + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] > " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3);
                                                                break;
                                                            }

                                                        case 4:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Variable [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + ". " + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] < " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3);
                                                                break;
                                                            }

                                                        case 5:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Variable [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + ". " + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] != " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3);
                                                                break;
                                                            }
                                                    }

                                                    break;
                                                }

                                            case 1:
                                                {
                                                    if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2 == 0)
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Switch [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + ". " + Switches[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] == " + "True");
                                                    else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2 == 1)
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Switch [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + ". " + Switches[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] == " + "False");
                                                    break;
                                                }

                                            case 2:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Has Item [" + Microsoft.VisualBasic.Strings.Trim(Types.Item[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1].Name) + "] x" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2);
                                                    break;
                                                }

                                            case 3:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Class Is [" + Microsoft.VisualBasic.Strings.Trim(Types.Classes[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1].Name) + "]");
                                                    break;
                                                }

                                            case 4:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Knows Skill [" + Microsoft.VisualBasic.Strings.Trim(Types.Skill[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1].Name) + "]");
                                                    break;
                                                }

                                            case 5:
                                                {
                                                    switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2)
                                                    {
                                                        case 0:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Level is == " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1);
                                                                break;
                                                            }

                                                        case 1:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Level is >= " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1);
                                                                break;
                                                            }

                                                        case 2:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Level is <= " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1);
                                                                break;
                                                            }

                                                        case 3:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Level is > " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1);
                                                                break;
                                                            }

                                                        case 4:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Level is < " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1);
                                                                break;
                                                            }

                                                        case 5:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Level is NOT " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1);
                                                                break;
                                                            }
                                                    }

                                                    break;
                                                }

                                            case 6:
                                                {
                                                    if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2 == 0)
                                                    {
                                                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1)
                                                        {
                                                            case 0:
                                                                {
                                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [A] == " + "True");
                                                                    break;
                                                                }

                                                            case 1:
                                                                {
                                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [B] == " + "True");
                                                                    break;
                                                                }

                                                            case 2:
                                                                {
                                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [C] == " + "True");
                                                                    break;
                                                                }

                                                            case 3:
                                                                {
                                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [D] == " + "True");
                                                                    break;
                                                                }
                                                        }
                                                    }
                                                    else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2 == 1)
                                                    {
                                                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1)
                                                        {
                                                            case 0:
                                                                {
                                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [A] == " + "False");
                                                                    break;
                                                                }

                                                            case 1:
                                                                {
                                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [B] == " + "False");
                                                                    break;
                                                                }

                                                            case 2:
                                                                {
                                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [C] == " + "False");
                                                                    break;
                                                                }

                                                            case 3:
                                                                {
                                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [D] == " + "False");
                                                                    break;
                                                                }
                                                        }
                                                    }

                                                    break;
                                                }

                                            case 7:
                                                {
                                                    if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2 == 0)
                                                    {
                                                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3)
                                                        {
                                                            case 0:
                                                                {
                                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Quest [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + "] not started.");
                                                                    break;
                                                                }

                                                            case 1:
                                                                {
                                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Quest [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + "] is started.");
                                                                    break;
                                                                }

                                                            case 2:
                                                                {
                                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Quest [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + "] is completed.");
                                                                    break;
                                                                }

                                                            case 3:
                                                                {
                                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Quest [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + "] can be started.");
                                                                    break;
                                                                }

                                                            case 4:
                                                                {
                                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Quest [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + "] can be ended. (All tasks complete)");
                                                                    break;
                                                                }
                                                        }
                                                    }
                                                    else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2 == 1)
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Quest [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1 + "] in progress and on task #" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3);
                                                    break;
                                                }

                                            case 8:
                                                {
                                                    switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1)
                                                    {
                                                        case (int)Enums.SexType.Male:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Gender is Male");
                                                                break;
                                                            }

                                                        case (int)Enums.SexType.Female:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's  Gender is Female");
                                                                break;
                                                            }
                                                    }

                                                    break;
                                                }

                                            case 9:
                                                {
                                                    switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1)
                                                    {
                                                        case (int)TimeOfDay.Day:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Time of Day is Day");
                                                                break;
                                                            }

                                                        case (int)TimeOfDay.Night:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Time of Day is Night");
                                                                break;
                                                            }

                                                        case (int)TimeOfDay.Dawn:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Time of Day is Dawn");
                                                                break;
                                                            }

                                                        case (int)TimeOfDay.Dusk:
                                                            {
                                                                My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Time of Day is Dusk");
                                                                break;
                                                            }
                                                    }

                                                    break;
                                                }
                                        }
                                        indent = indent + "       ";
                                        listleftoff[curlist] = i;
                                        conditionalstage[curlist] = 1;
                                        curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.CommandList;
                                        goto newlist;
                                        break;
                                    }

                                case 1:
                                    {
                                        var oldEventList1 = EventList;
                                        EventList = new EventListRec[x + 1];
                                        if (oldEventList1 != null)
                                            Array.Copy(oldEventList1, EventList, Math.Min(x + 1, oldEventList1.Length));
                                        EventList[x].CommandList = curlist;
                                        EventList[x].CommandNum = 0;
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(Microsoft.VisualBasic.Strings.Mid(indent, 1, Microsoft.VisualBasic.Strings.Len(indent) - 4) + " : " + "Else");
                                        listleftoff[curlist] = i;
                                        conditionalstage[curlist] = 2;
                                        curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.ElseCommandList;
                                        goto newlist;
                                        break;
                                    }

                                case 2:
                                    {
                                        var oldEventList2 = EventList;
                                        EventList = new EventListRec[x + 1];
                                        if (oldEventList2 != null)
                                            Array.Copy(oldEventList2, EventList, Math.Min(x + 1, oldEventList2.Length));
                                        EventList[x].CommandList = curlist;
                                        EventList[x].CommandNum = 0;
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(Microsoft.VisualBasic.Strings.Mid(indent, 1, Microsoft.VisualBasic.Strings.Len(indent) - 4) + " : " + "End Branch");
                                        indent = Microsoft.VisualBasic.Strings.Mid(indent, 1, Microsoft.VisualBasic.Strings.Len(indent) - 7);
                                        listleftoff[curlist] = i;
                                        conditionalstage[curlist] = 0;
                                        break;
                                    }
                            }
                        }
                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Index == (int)EventType.EvShowChoices)
                        {
                            x = x + 1;
                            switch (conditionalstage[curlist])
                            {
                                case 0:
                                    {
                                        var oldEventList5 = EventList;
                                        EventList = new EventListRec[x + 1];
                                        if (oldEventList5 != null)
                                            Array.Copy(oldEventList5, EventList, Math.Min(x + 1, oldEventList5.Length));
                                        EventList[x].CommandList = curlist;
                                        EventList[x].CommandNum = i;
                                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data5 > 0)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Show Choices - Prompt: " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) + "... - Face: " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data5);
                                        else
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Show Choices - Prompt: " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) + "... - No Face");
                                        indent = indent + "       ";
                                        listleftoff[curlist] = i;
                                        conditionalstage[curlist] = 1;
                                        goto newlist;
                                        break;
                                    }

                                case 1:
                                    {
                                        if (Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text2) != "")
                                        {
                                            var oldEventList6 = EventList;
                                            EventList = new EventListRec[x + 1];
                                            if (oldEventList6 != null)
                                                Array.Copy(oldEventList6, EventList, Math.Min(x + 1, oldEventList6.Length));
                                            EventList[x].CommandList = curlist;
                                            EventList[x].CommandNum = 0;
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(Microsoft.VisualBasic.Strings.Mid(indent, 1, Microsoft.VisualBasic.Strings.Len(indent) - 4) + " : " + "When [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text2) + "]");
                                            listleftoff[curlist] = i;
                                            conditionalstage[curlist] = 2;
                                            curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1;
                                            goto newlist;
                                        }
                                        else
                                        {
                                            x = x - 1;
                                            listleftoff[curlist] = i;
                                            conditionalstage[curlist] = 2;
                                            curlist = curlist;
                                            goto newlist;
                                        }

                                        break;
                                    }

                                case 2:
                                    {
                                        if (Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text3) != "")
                                        {
                                            var oldEventList7 = EventList;
                                            EventList = new EventListRec[x + 1];
                                            if (oldEventList7 != null)
                                                Array.Copy(oldEventList7, EventList, Math.Min(x + 1, oldEventList7.Length));
                                            EventList[x].CommandList = curlist;
                                            EventList[x].CommandNum = 0;
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(Microsoft.VisualBasic.Strings.Mid(indent, 1, Microsoft.VisualBasic.Strings.Len(indent) - 4) + " : " + "When [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text3) + "]");
                                            listleftoff[curlist] = i;
                                            conditionalstage[curlist] = 3;
                                            curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2;
                                            goto newlist;
                                        }
                                        else
                                        {
                                            x = x - 1;
                                            listleftoff[curlist] = i;
                                            conditionalstage[curlist] = 3;
                                            curlist = curlist;
                                            goto newlist;
                                        }

                                        break;
                                    }

                                case 3:
                                    {
                                        if (Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text4) != "")
                                        {
                                            var oldEventList8 = EventList;
                                            EventList = new EventListRec[x + 1];
                                            if (oldEventList8 != null)
                                                Array.Copy(oldEventList8, EventList, Math.Min(x + 1, oldEventList8.Length));
                                            EventList[x].CommandList = curlist;
                                            EventList[x].CommandNum = 0;
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(Microsoft.VisualBasic.Strings.Mid(indent, 1, Microsoft.VisualBasic.Strings.Len(indent) - 4) + " : " + "When [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text4) + "]");
                                            listleftoff[curlist] = i;
                                            conditionalstage[curlist] = 4;
                                            curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3;
                                            goto newlist;
                                        }
                                        else
                                        {
                                            x = x - 1;
                                            listleftoff[curlist] = i;
                                            conditionalstage[curlist] = 4;
                                            curlist = curlist;
                                            goto newlist;
                                        }

                                        break;
                                    }

                                case 4:
                                    {
                                        if (Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text5) != "")
                                        {
                                            var oldEventList9 = EventList;
                                            EventList = new EventListRec[x + 1];
                                            if (oldEventList9 != null)
                                                Array.Copy(oldEventList9, EventList, Math.Min(x + 1, oldEventList9.Length));
                                            EventList[x].CommandList = curlist;
                                            EventList[x].CommandNum = 0;
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(Microsoft.VisualBasic.Strings.Mid(indent, 1, Microsoft.VisualBasic.Strings.Len(indent) - 4) + " : " + "When [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text5) + "]");
                                            listleftoff[curlist] = i;
                                            conditionalstage[curlist] = 5;
                                            curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4;
                                            goto newlist;
                                        }
                                        else
                                        {
                                            x = x - 1;
                                            listleftoff[curlist] = i;
                                            conditionalstage[curlist] = 5;
                                            curlist = curlist;
                                            goto newlist;
                                        }

                                        break;
                                    }

                                case 5:
                                    {
                                        var oldEventList10 = EventList;
                                        EventList = new EventListRec[x + 1];
                                        if (oldEventList10 != null)
                                            Array.Copy(oldEventList10, EventList, Math.Min(x + 1, oldEventList10.Length));
                                        EventList[x].CommandList = curlist;
                                        EventList[x].CommandNum = 0;
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(Microsoft.VisualBasic.Strings.Mid(indent, 1, Microsoft.VisualBasic.Strings.Len(indent) - 4) + " : " + "Branch End");
                                        indent = Microsoft.VisualBasic.Strings.Mid(indent, 1, Microsoft.VisualBasic.Strings.Len(indent) - 7);
                                        listleftoff[curlist] = i;
                                        conditionalstage[curlist] = 0;
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            x = x + 1;
                            var oldEventList3 = EventList;
                            EventList = new EventListRec[x + 1];
                            if (oldEventList3 != null)
                                Array.Copy(oldEventList3, EventList, Math.Min(x + 1, oldEventList3.Length));
                            EventList[x].CommandList = curlist;
                            EventList[x].CommandNum = i;
                            switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Index)
                            {
                                case (int)EventType.EvAddText:
                                    {
                                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2)
                                        {
                                            case 0:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Add Text - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) + "... - Color: " + GetColorString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " - Chat Type: Player");
                                                    break;
                                                }

                                            case 1:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Add Text - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) + "... - Color: " + GetColorString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " - Chat Type: Map");
                                                    break;
                                                }

                                            case 2:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Add Text - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) + "... - Color: " + GetColorString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " - Chat Type: Global");
                                                    break;
                                                }
                                        }

                                        break;
                                    }

                                case (int)EventType.EvShowText:
                                    {
                                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 == 0)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Show Text - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) + "... - No Face");
                                        else
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Show Text - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) + "... - Face: " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1);
                                        break;
                                    }

                                case (int)EventType.EvPlayerVar:
                                    {
                                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2)
                                        {
                                            case 0:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player Variable [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] + "] == " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3);
                                                    break;
                                                }

                                            case 1:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player Variable [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] + "] + " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3);
                                                    break;
                                                }

                                            case 2:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player Variable [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] + "] - " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3);
                                                    break;
                                                }

                                            case 3:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player Variable [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] + "] Random Between " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3 + " and " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4);
                                                    break;
                                                }
                                        }

                                        break;
                                    }

                                case (int)EventType.EvPlayerSwitch:
                                    {
                                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player Switch [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + ". " + Switches[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] + "] == True");
                                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player Switch [" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + ". " + Switches[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] + "] == False");
                                        break;
                                    }

                                case (int)EventType.EvSelfSwitch:
                                    {
                                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)
                                        {
                                            case 0:
                                                {
                                                    if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [A] to ON");
                                                    else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [A] to OFF");
                                                    break;
                                                }

                                            case 1:
                                                {
                                                    if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [B] to ON");
                                                    else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [B] to OFF");
                                                    break;
                                                }

                                            case 2:
                                                {
                                                    if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [C] to ON");
                                                    else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [C] to OFF");
                                                    break;
                                                }

                                            case 3:
                                                {
                                                    if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [D] to ON");
                                                    else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [D] to OFF");
                                                    break;
                                                }
                                        }

                                        break;
                                    }

                                case (int)EventType.EvExitProcess:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Exit Event Processing");
                                        break;
                                    }

                                case (int)EventType.EvChangeItems:
                                    {
                                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Item Amount of [" + Microsoft.VisualBasic.Strings.Trim(Types.Item[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "] to " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3);
                                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Give Player " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3 + " " + Microsoft.VisualBasic.Strings.Trim(Types.Item[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "(s)");
                                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 2)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Take " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3 + " " + Microsoft.VisualBasic.Strings.Trim(Types.Item[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "(s) from Player.");
                                        break;
                                    }

                                case (int)EventType.EvRestoreHp:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Restore Player HP");
                                        break;
                                    }

                                case (int)EventType.EvRestoreMp:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Restore Player MP");
                                        break;
                                    }

                                case (int)EventType.EvLevelUp:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Level Up Player");
                                        break;
                                    }

                                case (int)EventType.EvChangeLevel:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player Level to " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1);
                                        break;
                                    }

                                case (int)EventType.EvChangeSkills:
                                    {
                                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Teach Player Skill [" + Microsoft.VisualBasic.Strings.Trim(Types.Skill[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]");
                                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Remove Player Skill [" + Microsoft.VisualBasic.Strings.Trim(Types.Skill[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]");
                                        break;
                                    }

                                case (int)EventType.EvChangeClass:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player Class to " + Microsoft.VisualBasic.Strings.Trim(Types.Classes[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name));
                                        break;
                                    }

                                case (int)EventType.EvChangeSprite:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player Sprite to " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1);
                                        break;
                                    }

                                case (int)EventType.EvChangeSex:
                                    {
                                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 == 0)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player Sex to Male.");
                                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 == 1)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player Sex to Female.");
                                        break;
                                    }

                                case (int)EventType.EvChangePk:
                                    {
                                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 == 0)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player PK to No.");
                                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 == 1)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player PK to Yes.");
                                        break;
                                    }

                                case (int)EventType.EvWarpPlayer:
                                    {
                                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4 == 0)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Warp Player To Map: " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + " Tile(" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 + "," + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3 + ") while retaining direction.");
                                        else
                                            switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4 - 1)
                                            {
                                                case (int)Enums.DirectionType.Up:
                                                    {
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Warp Player To Map: " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + " Tile(" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 + "," + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3 + ") facing upward.");
                                                        break;
                                                    }

                                                case (int)Enums.DirectionType.Down:
                                                    {
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Warp Player To Map: " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + " Tile(" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 + "," + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3 + ") facing downward.");
                                                        break;
                                                    }

                                                case (int)Enums.DirectionType.Left:
                                                    {
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Warp Player To Map: " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + " Tile(" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 + "," + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3 + ") facing left.");
                                                        break;
                                                    }

                                                case (int)Enums.DirectionType.Right:
                                                    {
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Warp Player To Map: " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + " Tile(" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 + "," + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3 + ") facing right.");
                                                        break;
                                                    }
                                            }

                                        break;
                                    }

                                case (int)EventType.EvSetMoveRoute:
                                    {
                                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 <= E_Types.Map.EventCount)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Move Route for Event #" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + " [" + Microsoft.VisualBasic.Strings.Trim(E_Types.Map.Events[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]");
                                        else
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Move Route for COULD NOT FIND EVENT!");
                                        break;
                                    }

                                case (int)EventType.EvPlayAnimation:
                                    {
                                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Play Animation " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + " [" + Microsoft.VisualBasic.Strings.Trim(Types.Animation[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]" + " on Player");
                                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Play Animation " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + " [" + Microsoft.VisualBasic.Strings.Trim(Types.Animation[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]" + " on Event #" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3 + " [" + Microsoft.VisualBasic.Strings.Trim(E_Types.Map.Events[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3].Name) + "]");
                                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 2)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Play Animation " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + " [" + Microsoft.VisualBasic.Strings.Trim(Types.Animation[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]" + " on Tile(" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3 + "," + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4 + ")");
                                        break;
                                    }

                                case (int)EventType.EvCustomScript:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Execute Custom Script Case: " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1);
                                        break;
                                    }

                                case (int)EventType.EvPlayBgm:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Play BGM [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1) + "]");
                                        break;
                                    }

                                case (int)EventType.EvFadeoutBgm:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Fadeout BGM");
                                        break;
                                    }

                                case (int)EventType.EvPlaySound:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Play Sound [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1) + "]");
                                        break;
                                    }

                                case (int)EventType.EvStopSound:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Stop Sound");
                                        break;
                                    }

                                case (int)EventType.EvOpenBank:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Open Bank");
                                        break;
                                    }

                                case (int)EventType.EvOpenMail:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Open Mail Box");
                                        break;
                                    }

                                case (int)EventType.EvOpenShop:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Open Shop [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + ". " + Microsoft.VisualBasic.Strings.Trim(Types.Shop[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]");
                                        break;
                                    }

                                case (int)EventType.EvSetAccess:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Player Access [" + My.MyProject.Forms.frmEvents.cmbSetAccess.Items[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] + "]");
                                        break;
                                    }

                                case (int)EventType.EvGiveExp:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Give Player " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + " Experience.");
                                        break;
                                    }

                                case (int)EventType.EvShowChatBubble:
                                    {
                                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)
                                        {
                                            case (int)Enums.TargetType.Player:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Show Chat Bubble - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) + "... - On Player");
                                                    break;
                                                }

                                            case (int)Enums.TargetType.Npc:
                                                {
                                                    if (E_Types.Map.Npc[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2] <= 0)
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Show Chat Bubble - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) + "... - On NPC [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + ". ]");
                                                    else
                                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Show Chat Bubble - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) + "... - On NPC [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + ". " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[E_Types.Map.Npc[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2]].Name) + "]");
                                                    break;
                                                }

                                            case (int)Enums.TargetType.Event:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Show Chat Bubble - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) + "... - On Event [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + ". " + Microsoft.VisualBasic.Strings.Trim(E_Types.Map.Events[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2].Name) + "]");
                                                    break;
                                                }
                                        }

                                        break;
                                    }

                                case (int)EventType.EvLabel:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Label: [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1) + "]");
                                        break;
                                    }

                                case (int)EventType.EvGotoLabel:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Jump to Label: [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1) + "]");
                                        break;
                                    }

                                case (int)EventType.EvSpawnNpc:
                                    {
                                        if (E_Types.Map.Npc[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] <= 0)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Spawn NPC: [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + ". " + "]");
                                        else
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Spawn NPC: [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + ". " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[E_Types.Map.Npc[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1]].Name) + "]");
                                        break;
                                    }

                                case (int)EventType.EvFadeIn:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Fade In");
                                        break;
                                    }

                                case (int)EventType.EvFadeOut:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Fade Out");
                                        break;
                                    }

                                case (int)EventType.EvFlashWhite:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Flash White");
                                        break;
                                    }

                                case (int)EventType.EvSetFog:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Fog [Fog: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " Speed: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + " Opacity: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + "]");
                                        break;
                                    }

                                case (int)EventType.EvSetWeather:
                                    {
                                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)
                                        {
                                            case (int)Enums.WeatherType.None:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Weather [None]");
                                                    break;
                                                }

                                            case (int)Enums.WeatherType.Rain:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Weather [Rain - Intensity: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "]");
                                                    break;
                                                }

                                            case (int)Enums.WeatherType.Snow:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Weather [Snow - Intensity: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "]");
                                                    break;
                                                }

                                            case (int)Enums.WeatherType.Sandstorm:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Weather [Sand Storm - Intensity: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "]");
                                                    break;
                                                }

                                            case (int)Enums.WeatherType.Storm:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Weather [Storm - Intensity: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "]");
                                                    break;
                                                }
                                        }

                                        break;
                                    }

                                case (int)EventType.EvSetTint:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Set Map Tint RGBA [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + "," + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "," + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + "," + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4) + "]");
                                        break;
                                    }

                                case (int)EventType.EvWait:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Wait " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " Ms");
                                        break;
                                    }

                                case (int)EventType.EvBeginQuest:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Begin Quest: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + ". " + Microsoft.VisualBasic.Strings.Trim(E_Quest.Quest[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name));
                                        break;
                                    }

                                case (int)EventType.EvEndQuest:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "End Quest: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + ". " + Microsoft.VisualBasic.Strings.Trim(E_Quest.Quest[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name));
                                        break;
                                    }

                                case (int)EventType.EvQuestTask:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Complete Quest Task: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + ". " + Microsoft.VisualBasic.Strings.Trim(E_Quest.Quest[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + " - Task# " + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2);
                                        break;
                                    }

                                case (int)EventType.EvShowPicture:
                                    {
                                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3)
                                        {
                                            case 1:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Show Picture " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + 1) + ": Pic=" + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + " Top Left, X: " + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4) + " Y: " + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data5));
                                                    break;
                                                }

                                            case 2:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Show Picture " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + 1) + ": Pic=" + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + " Center Screen, X: " + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4) + " Y: " + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data5));
                                                    break;
                                                }

                                            case 3:
                                                {
                                                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Show Picture " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + 1) + ": Pic=" + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + " On Player, X: " + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4) + " Y: " + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data5));
                                                    break;
                                                }
                                        }

                                        break;
                                    }

                                case (int)EventType.EvHidePicture:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Hide Picture " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + 1));
                                        break;
                                    }

                                case (int)EventType.EvWaitMovement:
                                    {
                                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 <= E_Types.Map.EventCount)
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Wait for Event #" + TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + " [" + Microsoft.VisualBasic.Strings.Trim(E_Types.Map.Events[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "] to complete move route.");
                                        else
                                            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Wait for COULD NOT FIND EVENT to complete move route.");
                                        break;
                                    }

                                case (int)EventType.EvHoldPlayer:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Hold Player [Do not allow player to move.]");
                                        break;
                                    }

                                case (int)EventType.EvReleasePlayer:
                                    {
                                        My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@>" + "Release Player [Allow player to turn and move again.]");
                                        break;
                                    }

                                default:
                                    {
                                        // Ghost
                                        x = x - 1;
                                        if (x == -1)
                                            EventList = new EventListRec[1];
                                        else
                                        {
                                            var oldEventList4 = EventList;
                                            EventList = new EventListRec[x + 1];
                                            if (oldEventList4 != null)
                                                Array.Copy(oldEventList4, EventList, Math.Min(x + 1, oldEventList4.Length));
                                        }

                                        break;
                                    }
                            }
                        }
                    }
                }
                if (curlist > 1)
                {
                    x = x + 1;
                    var oldEventList11 = EventList;
                    EventList = new EventListRec[x + 1];
                    if (oldEventList11 != null)
                        Array.Copy(oldEventList11, EventList, Math.Min(x + 1, oldEventList11.Length));
                    EventList[x].CommandList = curlist;
                    EventList[x].CommandNum = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount + 1;
                    My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@> ");
                    curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].ParentList;
                    goto newlist;
                }
            }
            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(indent + "@> ");

            int z = 0;
            x = 0;
            var loopTo1 = My.MyProject.Forms.frmEvents.lstCommands.Items.Count - 1;
            for (i = 0; i <= loopTo1; i++)
            {
                // X = frmEditor_Events.TextWidth(frmEditor_Events.lstCommands.Items.Item(i).ToString)
                if (x > z)
                    z = x;
            }

            ScrollCommands(z);
        }

        internal static void ScrollCommands(int size)
        {
        }

        public static void ListCommandAdd(string s)
        {
            My.MyProject.Forms.frmEvents.lstCommands.Items.Add(s);
        }

        public static void AddCommand(int index)
        {
            int curlist;
            int i = 0;
            int x = 0;
            int curslot;
            int p;
            CommandListRec oldCommandList;

            if (TmpEvent.Pages[CurPageNum].CommandListCount == 0)
            {
                TmpEvent.Pages[CurPageNum].CommandListCount = 1;
                TmpEvent.Pages[CurPageNum].CommandList = new CommandListRec[2];
            }

            if (My.MyProject.Forms.frmEvents.lstCommands.SelectedIndex == My.MyProject.Forms.frmEvents.lstCommands.Items.Count - 1)
                curlist = 1;
            else
                curlist = EventList[My.MyProject.Forms.frmEvents.lstCommands.SelectedIndex].CommandList;
            if (TmpEvent.Pages[CurPageNum].CommandListCount == 0)
            {
                TmpEvent.Pages[CurPageNum].CommandListCount = 1;
                TmpEvent.Pages[CurPageNum].CommandList = new CommandListRec[curlist + 1];
            }
            oldCommandList = TmpEvent.Pages[CurPageNum].CommandList[curlist];
            TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount + 1;
            p = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount;
            if (p <= 0)
                TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands = new EventCommandRec[1];
            else
            {
                TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands = new EventCommandRec[p + 1];
                TmpEvent.Pages[CurPageNum].CommandList[curlist].ParentList = oldCommandList.ParentList;
                TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount = p;
                var loopTo = p - 1;
                for (i = 1; i <= loopTo; i++)
                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i] = oldCommandList.Commands[i];
            }
            if (My.MyProject.Forms.frmEvents.lstCommands.SelectedIndex == My.MyProject.Forms.frmEvents.lstCommands.Items.Count - 1)
                curslot = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount;
            else
            {
                i = EventList[My.MyProject.Forms.frmEvents.lstCommands.SelectedIndex].CommandNum;
                if (i < TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount)
                {
                    var loopTo1 = i;
                    for (x = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount - 1; x >= loopTo1; x += -1)
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[x + 1] = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[x];
                    curslot = EventList[My.MyProject.Forms.frmEvents.lstCommands.SelectedIndex].CommandNum;
                }
                else
                    curslot = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount;
            }

            switch (index)
            {
                case (int)EventType.EvAddText:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = My.MyProject.Forms.frmEvents.txtAddText_Text.Text;
                        // tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlAddText_Colour.Value
                        if (My.MyProject.Forms.frmEvents.optAddText_Player.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
                        else if (My.MyProject.Forms.frmEvents.optAddText_Map.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
                        else if (My.MyProject.Forms.frmEvents.optAddText_Global.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 2;
                        break;
                    }

                case (int)EventType.EvCondition:
                    {
                        // This is the part where the whole entire source goes to hell :D
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandListCount = TmpEvent.Pages[CurPageNum].CommandListCount + 2;
                        var oldList = TmpEvent.Pages[CurPageNum].CommandList;
                        TmpEvent.Pages[CurPageNum].CommandList = new CommandListRec[TmpEvent.Pages[CurPageNum].CommandListCount + 1];
                        if (oldList != null)
                            Array.Copy(oldList, TmpEvent.Pages[CurPageNum].CommandList, Math.Min(TmpEvent.Pages[CurPageNum].CommandListCount + 1, oldList.Length));
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.CommandList = TmpEvent.Pages[CurPageNum].CommandListCount - 1;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.ElseCommandList = TmpEvent.Pages[CurPageNum].CommandListCount;
                        TmpEvent.Pages[CurPageNum].CommandList[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.CommandList].ParentList = curlist;
                        TmpEvent.Pages[CurPageNum].CommandList[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.ElseCommandList].ParentList = curlist;

                        if (My.MyProject.Forms.frmEvents.optCondition0.Checked == true)
                            x = 0;
                        if (My.MyProject.Forms.frmEvents.optCondition1.Checked == true)
                            x = 1;
                        if (My.MyProject.Forms.frmEvents.optCondition2.Checked == true)
                            x = 2;
                        if (My.MyProject.Forms.frmEvents.optCondition3.Checked == true)
                            x = 3;
                        if (My.MyProject.Forms.frmEvents.optCondition4.Checked == true)
                            x = 4;
                        if (My.MyProject.Forms.frmEvents.optCondition5.Checked == true)
                            x = 5;
                        if (My.MyProject.Forms.frmEvents.optCondition6.Checked == true)
                            x = 6;
                        if (My.MyProject.Forms.frmEvents.optCondition7.Checked == true)
                            x = 7;
                        if (My.MyProject.Forms.frmEvents.optCondition8.Checked == true)
                            x = 8;
                        if (My.MyProject.Forms.frmEvents.optCondition9.Checked == true)
                            x = 9;

                        switch (x)
                        {
                            case 0 // Player Var
                           :
                                {
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 0;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_PlayerVarIndex.SelectedIndex + 1;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = (int)My.MyProject.Forms.frmEvents.cmbCondition_PlayerVarCompare.SelectedIndex;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3 = (int)My.MyProject.Forms.frmEvents.nudCondition_PlayerVarCondition.Value;
                                    break;
                                }

                            case 1 // Player Switch
                     :
                                {
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 1;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_PlayerSwitch.SelectedIndex + 1;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = (int)My.MyProject.Forms.frmEvents.cmbCondtion_PlayerSwitchCondition.SelectedIndex;
                                    break;
                                }

                            case 2 // Has Item
                     :
                                {
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 2;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_HasItem.SelectedIndex + 1;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = (int)My.MyProject.Forms.frmEvents.nudCondition_HasItem.Value;
                                    break;
                                }

                            case 3 // Class Is
                     :
                                {
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 3;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_ClassIs.SelectedIndex + 1;
                                    break;
                                }

                            case 4 // Learnt Skill
                     :
                                {
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 4;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_LearntSkill.SelectedIndex + 1;
                                    break;
                                }

                            case 5 // Level Is
                     :
                                {
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 5;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.nudCondition_LevelAmount.Value;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = (int)My.MyProject.Forms.frmEvents.cmbCondition_LevelCompare.SelectedIndex;
                                    break;
                                }

                            case 6 // Self Switch
                     :
                                {
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 6;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_SelfSwitch.SelectedIndex;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = (int)My.MyProject.Forms.frmEvents.cmbCondition_SelfSwitchCondition.SelectedIndex;
                                    break;
                                }

                            case 7 // Quest Shiz
                     :
                                {
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 7;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.nudCondition_Quest.Value;
                                    if (My.MyProject.Forms.frmEvents.optCondition_Quest0.Checked)
                                    {
                                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = 0;
                                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3 = (int)My.MyProject.Forms.frmEvents.cmbCondition_General.SelectedIndex;
                                    }
                                    else
                                    {
                                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = 1;
                                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3 = (int)My.MyProject.Forms.frmEvents.nudCondition_QuestTask.Value;
                                    }

                                    break;
                                }

                            case 8 // Gender
                     :
                                {
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 8;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_Gender.SelectedIndex;
                                    break;
                                }

                            case 9 // time of day
                     :
                                {
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 9;
                                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_Time.SelectedIndex;
                                    break;
                                }
                        }

                        break;
                    }

                case (int)EventType.EvShowText:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        string tmptxt = "";
                        var loopTo2 = Information.UBound(My.MyProject.Forms.frmEvents.txtShowText.Lines);
                        for (i = 0; i <= loopTo2; i++)
                            tmptxt = tmptxt + My.MyProject.Forms.frmEvents.txtShowText.Lines[i];
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = tmptxt;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudShowTextFace.Value;
                        break;
                    }

                case (int)EventType.EvShowChoices:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = My.MyProject.Forms.frmEvents.txtChoicePrompt.Text;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text2 = My.MyProject.Forms.frmEvents.txtChoices1.Text;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text3 = My.MyProject.Forms.frmEvents.txtChoices2.Text;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text4 = My.MyProject.Forms.frmEvents.txtChoices3.Text;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text5 = My.MyProject.Forms.frmEvents.txtChoices4.Text;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data5 = (int)My.MyProject.Forms.frmEvents.nudShowChoicesFace.Value;
                        TmpEvent.Pages[CurPageNum].CommandListCount = TmpEvent.Pages[CurPageNum].CommandListCount + 4;
                        var oldCommandList1 = TmpEvent.Pages[CurPageNum].CommandList;
                        TmpEvent.Pages[CurPageNum].CommandList = new CommandListRec[TmpEvent.Pages[CurPageNum].CommandListCount + 1];
                        if (oldCommandList1 != null)
                            Array.Copy(oldCommandList1, TmpEvent.Pages[CurPageNum].CommandList, Math.Min(TmpEvent.Pages[CurPageNum].CommandListCount + 1, oldCommandList1.Length));
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = TmpEvent.Pages[CurPageNum].CommandListCount - 3;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = TmpEvent.Pages[CurPageNum].CommandListCount - 2;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = TmpEvent.Pages[CurPageNum].CommandListCount - 1;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = TmpEvent.Pages[CurPageNum].CommandListCount;
                        TmpEvent.Pages[CurPageNum].CommandList[TmpEvent.Pages[CurPageNum].CommandListCount - 3].ParentList = curlist;
                        TmpEvent.Pages[CurPageNum].CommandList[TmpEvent.Pages[CurPageNum].CommandListCount - 2].ParentList = curlist;
                        TmpEvent.Pages[CurPageNum].CommandList[TmpEvent.Pages[CurPageNum].CommandListCount - 1].ParentList = curlist;
                        TmpEvent.Pages[CurPageNum].CommandList[TmpEvent.Pages[CurPageNum].CommandListCount].ParentList = curlist;
                        break;
                    }

                case (int)EventType.EvPlayerVar:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbVariable.SelectedIndex + 1;

                        if (My.MyProject.Forms.frmEvents.optVariableAction0.Checked == true)
                            i = 0;
                        if (My.MyProject.Forms.frmEvents.optVariableAction1.Checked == true)
                            i = 1;
                        if (My.MyProject.Forms.frmEvents.optVariableAction2.Checked == true)
                            i = 2;
                        if (My.MyProject.Forms.frmEvents.optVariableAction3.Checked == true)
                            i = 3;

                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = i;
                        if (i == 3)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudVariableData3.Value;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int)My.MyProject.Forms.frmEvents.nudVariableData4.Value;
                        }
                        else if (i == 0)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudVariableData0.Value;
                        else if (i == 1)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudVariableData1.Value;
                        else if (i == 2)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudVariableData2.Value;
                        break;
                    }

                case (int)EventType.EvPlayerSwitch:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbSwitch.SelectedIndex + 1;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.cmbPlayerSwitchSet.SelectedIndex;
                        break;
                    }

                case (int)EventType.EvSelfSwitch:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbSetSelfSwitch.SelectedIndex;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.cmbSetSelfSwitchTo.SelectedIndex;
                        break;
                    }

                case (int)EventType.EvExitProcess:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        break;
                    }

                case (int)EventType.EvChangeItems:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbChangeItemIndex.SelectedIndex + 1;
                        if (My.MyProject.Forms.frmEvents.optChangeItemSet.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
                        else if (My.MyProject.Forms.frmEvents.optChangeItemAdd.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
                        else if (My.MyProject.Forms.frmEvents.optChangeItemRemove.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 2;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudChangeItemsAmount.Value;
                        break;
                    }

                case (int)EventType.EvRestoreHp:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        break;
                    }

                case (int)EventType.EvRestoreMp:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        break;
                    }

                case (int)EventType.EvLevelUp:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        break;
                    }

                case (int)EventType.EvChangeLevel:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudChangeLevel.Value;
                        break;
                    }

                case (int)EventType.EvChangeSkills:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbChangeSkills.SelectedIndex + 1;
                        if (My.MyProject.Forms.frmEvents.optChangeSkillsAdd.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
                        else if (My.MyProject.Forms.frmEvents.optChangeSkillsRemove.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
                        break;
                    }

                case (int)EventType.EvChangeClass:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbChangeClass.SelectedIndex + 1;
                        break;
                    }

                case (int)EventType.EvChangeSprite:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudChangeSprite.Value;
                        break;
                    }

                case (int)EventType.EvChangeSex:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        if (My.MyProject.Forms.frmEvents.optChangeSexMale.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = 0;
                        else if (My.MyProject.Forms.frmEvents.optChangeSexFemale.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = 1;
                        break;
                    }

                case (int)EventType.EvChangePk:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbSetPK.SelectedIndex;
                        break;
                    }

                case (int)EventType.EvWarpPlayer:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudWPMap.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.nudWPX.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudWPY.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int)My.MyProject.Forms.frmEvents.cmbWarpPlayerDir.SelectedIndex;
                        break;
                    }

                case (int)EventType.EvSetMoveRoute:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = ListOfEvents[My.MyProject.Forms.frmEvents.cmbEvent.SelectedIndex];
                        if (My.MyProject.Forms.frmEvents.chkIgnoreMove.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
                        else
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;

                        if (My.MyProject.Forms.frmEvents.chkRepeatRoute.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = 1;
                        else
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = 0;

                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].MoveRouteCount = TempMoveRouteCount;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].MoveRoute = TempMoveRoute;
                        break;
                    }

                case (int)EventType.EvPlayAnimation:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbPlayAnim.SelectedIndex + 1;
                        if (My.MyProject.Forms.frmEvents.cmbAnimTargetType.SelectedIndex == 0)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
                        else if (My.MyProject.Forms.frmEvents.cmbAnimTargetType.SelectedIndex == 1)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.cmbPlayAnimEvent.SelectedIndex + 1;
                        }
                        else if (My.MyProject.Forms.frmEvents.cmbAnimTargetType.SelectedIndex == 2 == true)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 2;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudPlayAnimTileX.Value;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int)My.MyProject.Forms.frmEvents.nudPlayAnimTileY.Value;
                        }

                        break;
                    }

                case (int)EventType.EvCustomScript:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudCustomScript.Value;
                        break;
                    }

                case (int)EventType.EvPlayBgm:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = E_Sound.MusicCache[My.MyProject.Forms.frmEvents.cmbPlayBGM.SelectedIndex + 1];
                        break;
                    }

                case (int)EventType.EvFadeoutBgm:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        break;
                    }

                case (int)EventType.EvPlaySound:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = E_Sound.SoundCache[My.MyProject.Forms.frmEvents.cmbPlaySound.SelectedIndex + 1];
                        break;
                    }

                case (int)EventType.EvStopSound:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        break;
                    }

                case (int)EventType.EvOpenBank:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        break;
                    }

                case (int)EventType.EvOpenMail:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        break;
                    }

                case (int)EventType.EvOpenShop:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbOpenShop.SelectedIndex + 1;
                        break;
                    }

                case (int)EventType.EvSetAccess:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbSetAccess.SelectedIndex;
                        break;
                    }

                case (int)EventType.EvGiveExp:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudGiveExp.Value;
                        break;
                    }

                case (int)EventType.EvShowChatBubble:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = My.MyProject.Forms.frmEvents.txtChatbubbleText.Text;

                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbChatBubbleTargetType.SelectedIndex + 1;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.cmbChatBubbleTarget.SelectedIndex + 1;
                        break;
                    }

                case (int)EventType.EvLabel:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = My.MyProject.Forms.frmEvents.txtLabelName.Text;
                        break;
                    }

                case (int)EventType.EvGotoLabel:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = My.MyProject.Forms.frmEvents.txtGotoLabel.Text;
                        break;
                    }

                case (int)EventType.EvSpawnNpc:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbSpawnNpc.SelectedIndex + 1;
                        break;
                    }

                case (int)EventType.EvFadeIn:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        break;
                    }

                case (int)EventType.EvFadeOut:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        break;
                    }

                case (int)EventType.EvFlashWhite:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        break;
                    }

                case (int)EventType.EvSetFog:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudFogData0.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.nudFogData1.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudFogData2.Value;
                        break;
                    }

                case (int)EventType.EvSetWeather:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.CmbWeather.SelectedIndex;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.nudWeatherIntensity.Value;
                        break;
                    }

                case (int)EventType.EvSetTint:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudMapTintData0.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.nudMapTintData1.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudMapTintData2.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int)My.MyProject.Forms.frmEvents.nudMapTintData3.Value;
                        break;
                    }

                case (int)EventType.EvWait:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudWaitAmount.Value;
                        break;
                    }

                case (int)EventType.EvBeginQuest:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbBeginQuest.SelectedIndex + 1;
                        break;
                    }

                case (int)EventType.EvEndQuest:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbEndQuest.SelectedIndex + 1;
                        break;
                    }

                case (int)EventType.EvQuestTask:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbCompleteQuest.SelectedIndex;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.nudCompleteQuestTask.Value;
                        break;
                    }

                case (int)EventType.EvShowPicture:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbPicIndex.SelectedIndex;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.nudShowPicture.Value;

                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.cmbPicLoc.SelectedIndex + 1;

                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int)My.MyProject.Forms.frmEvents.nudPicOffsetX.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data5 = (int)My.MyProject.Forms.frmEvents.nudPicOffsetY.Value;
                        break;
                    }

                case (int)EventType.EvHidePicture:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudHidePic.Value;
                        break;
                    }

                case (int)EventType.EvWaitMovement:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = ListOfEvents[My.MyProject.Forms.frmEvents.cmbMoveWait.SelectedIndex];
                        break;
                    }

                case (int)EventType.EvHoldPlayer:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        break;
                    }

                case (int)EventType.EvReleasePlayer:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = index;
                        break;
                    }
            }
            EventListCommands();
        }

        internal static void EditEventCommand()
        {
            int i;
            int x = 0;
            int curlist;
            int curslot;

            i = My.MyProject.Forms.frmEvents.lstCommands.SelectedIndex;
            if (i == -1)
                return;
            if (i > Information.UBound(EventList))
                return;

            My.MyProject.Forms.frmEvents.fraConditionalBranch.Visible = false;
            My.MyProject.Forms.frmEvents.fraDialogue.BringToFront();

            curlist = EventList[i].CommandList;
            curslot = EventList[i].CommandNum;
            if (curlist == 0)
                return;
            if (curslot == 0)
                return;
            if (curlist > TmpEvent.Pages[CurPageNum].CommandListCount)
                return;
            if (curslot > TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount)
                return;
            switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index)
            {
                case (int)EventType.EvAddText:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.txtAddText_Text.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1;
                        // frmEditor_Events.scrlAddText_Colour.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2)
                        {
                            case 0:
                                {
                                    My.MyProject.Forms.frmEvents.optAddText_Player.Checked = true;
                                    break;
                                }

                            case 1:
                                {
                                    My.MyProject.Forms.frmEvents.optAddText_Map.Checked = true;
                                    break;
                                }

                            case 2:
                                {
                                    My.MyProject.Forms.frmEvents.optAddText_Global.Checked = true;
                                    break;
                                }
                        }
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraAddText.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvCondition:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraConditionalBranch.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        My.MyProject.Forms.frmEvents.ClearConditionFrame();

                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition)
                        {
                            case 0:
                                {
                                    My.MyProject.Forms.frmEvents.optCondition0.Checked = true;
                                    break;
                                }

                            case 1:
                                {
                                    My.MyProject.Forms.frmEvents.optCondition1.Checked = true;
                                    break;
                                }

                            case 2:
                                {
                                    My.MyProject.Forms.frmEvents.optCondition2.Checked = true;
                                    break;
                                }

                            case 3:
                                {
                                    My.MyProject.Forms.frmEvents.optCondition3.Checked = true;
                                    break;
                                }

                            case 4:
                                {
                                    My.MyProject.Forms.frmEvents.optCondition4.Checked = true;
                                    break;
                                }

                            case 5:
                                {
                                    My.MyProject.Forms.frmEvents.optCondition5.Checked = true;
                                    break;
                                }

                            case 6:
                                {
                                    My.MyProject.Forms.frmEvents.optCondition6.Checked = true;
                                    break;
                                }

                            case 7:
                                {
                                    My.MyProject.Forms.frmEvents.optCondition7.Checked = true;
                                    break;
                                }

                            case 8:
                                {
                                    My.MyProject.Forms.frmEvents.optCondition8.Checked = true;
                                    break;
                                }

                            case 9:
                                {
                                    My.MyProject.Forms.frmEvents.optCondition9.Checked = true;
                                    break;
                                }
                        }

                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition)
                        {
                            case 0:
                                {
                                    My.MyProject.Forms.frmEvents.cmbCondition_PlayerVarIndex.Enabled = true;
                                    My.MyProject.Forms.frmEvents.cmbCondition_PlayerVarCompare.Enabled = true;
                                    My.MyProject.Forms.frmEvents.nudCondition_PlayerVarCondition.Enabled = true;
                                    My.MyProject.Forms.frmEvents.cmbCondition_PlayerVarIndex.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 - 1;
                                    My.MyProject.Forms.frmEvents.cmbCondition_PlayerVarCompare.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2;
                                    My.MyProject.Forms.frmEvents.nudCondition_PlayerVarCondition.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3;
                                    break;
                                }

                            case 1:
                                {
                                    My.MyProject.Forms.frmEvents.cmbCondition_PlayerSwitch.Enabled = true;
                                    My.MyProject.Forms.frmEvents.cmbCondtion_PlayerSwitchCondition.Enabled = true;
                                    My.MyProject.Forms.frmEvents.cmbCondition_PlayerSwitch.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 - 1;
                                    My.MyProject.Forms.frmEvents.cmbCondtion_PlayerSwitchCondition.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2;
                                    break;
                                }

                            case 2:
                                {
                                    My.MyProject.Forms.frmEvents.cmbCondition_HasItem.Enabled = true;
                                    My.MyProject.Forms.frmEvents.nudCondition_HasItem.Enabled = true;
                                    My.MyProject.Forms.frmEvents.cmbCondition_HasItem.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 - 1;
                                    My.MyProject.Forms.frmEvents.nudCondition_HasItem.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2;
                                    break;
                                }

                            case 3:
                                {
                                    My.MyProject.Forms.frmEvents.cmbCondition_ClassIs.Enabled = true;
                                    My.MyProject.Forms.frmEvents.cmbCondition_ClassIs.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 - 1;
                                    break;
                                }

                            case 4:
                                {
                                    My.MyProject.Forms.frmEvents.cmbCondition_LearntSkill.Enabled = true;
                                    My.MyProject.Forms.frmEvents.cmbCondition_LearntSkill.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 - 1;
                                    break;
                                }

                            case 5:
                                {
                                    My.MyProject.Forms.frmEvents.cmbCondition_LevelCompare.Enabled = true;
                                    My.MyProject.Forms.frmEvents.nudCondition_LevelAmount.Enabled = true;
                                    My.MyProject.Forms.frmEvents.nudCondition_LevelAmount.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1;
                                    My.MyProject.Forms.frmEvents.cmbCondition_LevelCompare.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2;
                                    break;
                                }

                            case 6:
                                {
                                    My.MyProject.Forms.frmEvents.cmbCondition_SelfSwitch.Enabled = true;
                                    My.MyProject.Forms.frmEvents.cmbCondition_SelfSwitchCondition.Enabled = true;
                                    My.MyProject.Forms.frmEvents.cmbCondition_SelfSwitch.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1;
                                    My.MyProject.Forms.frmEvents.cmbCondition_SelfSwitchCondition.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2;
                                    break;
                                }

                            case 7:
                                {
                                    My.MyProject.Forms.frmEvents.nudCondition_Quest.Enabled = true;
                                    My.MyProject.Forms.frmEvents.nudCondition_Quest.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1;
                                    My.MyProject.Forms.frmEvents.fraConditions_Quest.Visible = true;
                                    if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 == 0)
                                    {
                                        My.MyProject.Forms.frmEvents.optCondition_Quest0.Checked = true;
                                        My.MyProject.Forms.frmEvents.cmbCondition_General.Enabled = true;
                                        My.MyProject.Forms.frmEvents.cmbCondition_General.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3;
                                    }
                                    else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 == 1)
                                    {
                                        My.MyProject.Forms.frmEvents.optCondition_Quest1.Checked = true;
                                        My.MyProject.Forms.frmEvents.nudCondition_QuestTask.Enabled = true;
                                        My.MyProject.Forms.frmEvents.nudCondition_QuestTask.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3;
                                    }

                                    break;
                                }

                            case 8:
                                {
                                    My.MyProject.Forms.frmEvents.cmbCondition_Gender.Enabled = true;
                                    My.MyProject.Forms.frmEvents.cmbCondition_Gender.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1;
                                    break;
                                }

                            case 9:
                                {
                                    My.MyProject.Forms.frmEvents.cmbCondition_Time.Enabled = true;
                                    My.MyProject.Forms.frmEvents.cmbCondition_Time.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1;
                                    break;
                                }
                        }

                        break;
                    }

                case (int)EventType.EvShowText:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.txtShowText.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1;
                        My.MyProject.Forms.frmEvents.nudShowTextFace.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraShowText.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvShowChoices:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.txtChoicePrompt.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1;
                        My.MyProject.Forms.frmEvents.txtChoices1.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text2;
                        My.MyProject.Forms.frmEvents.txtChoices2.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text3;
                        My.MyProject.Forms.frmEvents.txtChoices3.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text4;
                        My.MyProject.Forms.frmEvents.txtChoices4.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text5;
                        My.MyProject.Forms.frmEvents.nudShowChoicesFace.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data5;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraShowChoices.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvPlayerVar:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.cmbVariable.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
                        switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2)
                        {
                            case 0:
                                {
                                    My.MyProject.Forms.frmEvents.optVariableAction0.Checked = true;
                                    My.MyProject.Forms.frmEvents.nudVariableData0.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
                                    break;
                                }

                            case 1:
                                {
                                    My.MyProject.Forms.frmEvents.optVariableAction1.Checked = true;
                                    My.MyProject.Forms.frmEvents.nudVariableData1.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
                                    break;
                                }

                            case 2:
                                {
                                    My.MyProject.Forms.frmEvents.optVariableAction2.Checked = true;
                                    My.MyProject.Forms.frmEvents.nudVariableData2.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
                                    break;
                                }

                            case 3:
                                {
                                    My.MyProject.Forms.frmEvents.optVariableAction3.Checked = true;
                                    My.MyProject.Forms.frmEvents.nudVariableData3.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
                                    My.MyProject.Forms.frmEvents.nudVariableData4.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4;
                                    break;
                                }
                        }
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraPlayerVariable.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvPlayerSwitch:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.cmbSwitch.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
                        My.MyProject.Forms.frmEvents.cmbPlayerSwitchSet.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraPlayerSwitch.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvSelfSwitch:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.cmbSetSelfSwitch.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.cmbSetSelfSwitchTo.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraSetSelfSwitch.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvChangeItems:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.cmbChangeItemIndex.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 0)
                            My.MyProject.Forms.frmEvents.optChangeItemSet.Checked = true;
                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 1)
                            My.MyProject.Forms.frmEvents.optChangeItemAdd.Checked = true;
                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 2)
                            My.MyProject.Forms.frmEvents.optChangeItemRemove.Checked = true;
                        My.MyProject.Forms.frmEvents.nudChangeItemsAmount.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraChangeItems.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvChangeLevel:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.nudChangeLevel.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraChangeLevel.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvChangeSkills:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.cmbChangeSkills.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 0)
                            My.MyProject.Forms.frmEvents.optChangeSkillsAdd.Checked = true;
                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 1)
                            My.MyProject.Forms.frmEvents.optChangeSkillsRemove.Checked = true;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraChangeSkills.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvChangeClass:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.cmbChangeClass.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraChangeClass.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvChangeSprite:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.nudChangeSprite.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraChangeSprite.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvChangeSex:
                    {
                        IsEdit = true;
                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 == 0)
                            My.MyProject.Forms.frmEvents.optChangeSexMale.Checked = true;
                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 == 1)
                            My.MyProject.Forms.frmEvents.optChangeSexFemale.Checked = true;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraChangeGender.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvChangePk:
                    {
                        IsEdit = true;

                        My.MyProject.Forms.frmEvents.cmbSetPK.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;

                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraChangePK.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvWarpPlayer:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.nudWPMap.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.nudWPX.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
                        My.MyProject.Forms.frmEvents.nudWPY.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
                        My.MyProject.Forms.frmEvents.cmbWarpPlayerDir.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraPlayerWarp.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvSetMoveRoute:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.fraMoveRoute.Visible = true;
                        My.MyProject.Forms.frmEvents.fraMoveRoute.BringToFront();
                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Clear();
                        My.MyProject.Forms.frmEvents.cmbEvent.Items.Clear();
                        ListOfEvents = new int[E_Types.Map.EventCount + 1];
                        ListOfEvents[0] = EditorEvent;
                        My.MyProject.Forms.frmEvents.cmbEvent.Items.Add("This Event");
                        My.MyProject.Forms.frmEvents.cmbEvent.SelectedIndex = 0;
                        My.MyProject.Forms.frmEvents.cmbEvent.Enabled = true;
                        var loopTo = E_Types.Map.EventCount;
                        for (i = 1; i <= loopTo; i++)
                        {
                            if (i != EditorEvent)
                            {
                                My.MyProject.Forms.frmEvents.cmbEvent.Items.Add(Microsoft.VisualBasic.Strings.Trim(E_Types.Map.Events[i].Name));
                                x = (x + 1);
                                ListOfEvents[x] = i;
                                if (i == TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1)
                                    My.MyProject.Forms.frmEvents.cmbEvent.SelectedIndex = x;
                            }
                        }

                        IsMoveRouteCommand = true;
                        My.MyProject.Forms.frmEvents.chkIgnoreMove.Checked = Convert.ToBoolean(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2);
                        My.MyProject.Forms.frmEvents.chkRepeatRoute.Checked = Convert.ToBoolean(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3);
                        TempMoveRouteCount = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].MoveRouteCount;
                        TempMoveRoute = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].MoveRoute;
                        var loopTo1 = TempMoveRouteCount;
                        for (i = 1; i <= loopTo1; i++)
                        {
                            switch (TempMoveRoute[i].Index)
                            {
                                case 1:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Move Up");
                                        break;
                                    }

                                case 2:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Move Down");
                                        break;
                                    }

                                case 3:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Move Left");
                                        break;
                                    }

                                case 4:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Move Right");
                                        break;
                                    }

                                case 5:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Move Randomly");
                                        break;
                                    }

                                case 6:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Move Towards Player");
                                        break;
                                    }

                                case 7:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Move Away From Player");
                                        break;
                                    }

                                case 8:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Step Forward");
                                        break;
                                    }

                                case 9:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Step Back");
                                        break;
                                    }

                                case 10:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Wait 100ms");
                                        break;
                                    }

                                case 11:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Wait 500ms");
                                        break;
                                    }

                                case 12:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Wait 1000ms");
                                        break;
                                    }

                                case 13:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn Up");
                                        break;
                                    }

                                case 14:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn Down");
                                        break;
                                    }

                                case 15:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn Left");
                                        break;
                                    }

                                case 16:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn Right");
                                        break;
                                    }

                                case 17:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn 90 Degrees To the Right");
                                        break;
                                    }

                                case 18:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn 90 Degrees To the Left");
                                        break;
                                    }

                                case 19:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn Around 180 Degrees");
                                        break;
                                    }

                                case 20:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn Randomly");
                                        break;
                                    }

                                case 21:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn Towards Player");
                                        break;
                                    }

                                case 22:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn Away from Player");
                                        break;
                                    }

                                case 23:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Speed 8x Slower");
                                        break;
                                    }

                                case 24:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Speed 4x Slower");
                                        break;
                                    }

                                case 25:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Speed 2x Slower");
                                        break;
                                    }

                                case 26:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Speed to Normal");
                                        break;
                                    }

                                case 27:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Speed 2x Faster");
                                        break;
                                    }

                                case 28:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Speed 4x Faster");
                                        break;
                                    }

                                case 29:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Frequency Lowest");
                                        break;
                                    }

                                case 30:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Frequency Lower");
                                        break;
                                    }

                                case 31:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Frequency Normal");
                                        break;
                                    }

                                case 32:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Frequency Higher");
                                        break;
                                    }

                                case 33:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Frequency Highest");
                                        break;
                                    }

                                case 34:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn On Walking Animation");
                                        break;
                                    }

                                case 35:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn Off Walking Animation");
                                        break;
                                    }

                                case 36:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn On Fixed Direction");
                                        break;
                                    }

                                case 37:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn Off Fixed Direction");
                                        break;
                                    }

                                case 38:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn On Walk Through");
                                        break;
                                    }

                                case 39:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Turn Off Walk Through");
                                        break;
                                    }

                                case 40:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Position Below Player");
                                        break;
                                    }

                                case 41:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Position at Player Level");
                                        break;
                                    }

                                case 42:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Position Above Player");
                                        break;
                                    }

                                case 43:
                                    {
                                        My.MyProject.Forms.frmEvents.lstMoveRoute.Items.Add("Set Graphic");
                                        break;
                                    }
                            }
                        }
                        My.MyProject.Forms.frmEvents.fraMoveRoute.Width = 841;
                        My.MyProject.Forms.frmEvents.fraMoveRoute.Height = 636;
                        My.MyProject.Forms.frmEvents.fraMoveRoute.Visible = true;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = false;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvPlayAnimation:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.lblPlayAnimX.Visible = false;
                        My.MyProject.Forms.frmEvents.lblPlayAnimY.Visible = false;
                        My.MyProject.Forms.frmEvents.nudPlayAnimTileX.Visible = false;
                        My.MyProject.Forms.frmEvents.nudPlayAnimTileY.Visible = false;
                        My.MyProject.Forms.frmEvents.cmbPlayAnimEvent.Visible = false;
                        My.MyProject.Forms.frmEvents.cmbPlayAnim.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
                        My.MyProject.Forms.frmEvents.cmbPlayAnimEvent.Items.Clear();
                        var loopTo2 = E_Types.Map.EventCount;
                        for (i = 1; i <= loopTo2; i++)
                            My.MyProject.Forms.frmEvents.cmbPlayAnimEvent.Items.Add(i + ". " + Microsoft.VisualBasic.Strings.Trim(E_Types.Map.Events[i].Name));
                        My.MyProject.Forms.frmEvents.cmbPlayAnimEvent.SelectedIndex = 0;
                        if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 0)
                            My.MyProject.Forms.frmEvents.cmbAnimTargetType.SelectedIndex = 0;
                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 1)
                        {
                            My.MyProject.Forms.frmEvents.cmbAnimTargetType.SelectedIndex = 1;
                            My.MyProject.Forms.frmEvents.cmbPlayAnimEvent.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 - 1;
                        }
                        else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 2)
                        {
                            My.MyProject.Forms.frmEvents.cmbAnimTargetType.SelectedIndex = 2;
                            My.MyProject.Forms.frmEvents.nudPlayAnimTileX.Maximum = E_Types.Map.MaxX;
                            My.MyProject.Forms.frmEvents.nudPlayAnimTileY.Maximum = E_Types.Map.MaxY;
                            My.MyProject.Forms.frmEvents.nudPlayAnimTileX.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
                            My.MyProject.Forms.frmEvents.nudPlayAnimTileY.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4;
                        }
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraPlayAnimation.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvCustomScript:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.nudCustomScript.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCustomScript.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvPlayBgm:
                    {
                        IsEdit = true;
                        var loopTo3 = Information.UBound(E_Sound.MusicCache);
                        for (i = 1; i <= loopTo3; i++)
                        {
                            if (E_Sound.MusicCache[i] == TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1)
                                My.MyProject.Forms.frmEvents.cmbPlayBGM.SelectedIndex = i - 1;
                        }
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraPlayBGM.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvPlaySound:
                    {
                        IsEdit = true;
                        var loopTo4 = Information.UBound(E_Sound.SoundCache);
                        for (i = 1; i <= loopTo4; i++)
                        {
                            if (E_Sound.SoundCache[i] == TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1)
                                My.MyProject.Forms.frmEvents.cmbPlaySound.SelectedIndex = i - 1;
                        }
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraPlaySound.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvOpenShop:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.cmbOpenShop.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraOpenShop.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvSetAccess:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.cmbSetAccess.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraSetAccess.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvGiveExp:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.nudGiveExp.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraGiveExp.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvShowChatBubble:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.txtChatbubbleText.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1;
                        My.MyProject.Forms.frmEvents.cmbChatBubbleTargetType.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
                        My.MyProject.Forms.frmEvents.cmbChatBubbleTarget.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 - 1;

                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraShowChatBubble.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvLabel:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.txtLabelName.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCreateLabel.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvGotoLabel:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.txtGotoLabel.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraGoToLabel.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvSpawnNpc:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.cmbSpawnNpc.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraSpawnNpc.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvSetFog:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.nudFogData0.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.nudFogData1.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
                        My.MyProject.Forms.frmEvents.nudFogData2.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraSetFog.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvSetWeather:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.CmbWeather.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.nudWeatherIntensity.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraSetWeather.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvSetTint:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.nudMapTintData0.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.nudMapTintData1.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
                        My.MyProject.Forms.frmEvents.nudMapTintData2.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
                        My.MyProject.Forms.frmEvents.nudMapTintData3.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraMapTint.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvWait:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.nudWaitAmount.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraSetWait.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvBeginQuest:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.cmbBeginQuest.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraBeginQuest.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvEndQuest:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.cmbEndQuest.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraEndQuest.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvQuestTask:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.cmbCompleteQuest.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.nudCompleteQuestTask.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCompleteTask.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvShowPicture:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.cmbPicIndex.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.nudShowPicture.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;

                        My.MyProject.Forms.frmEvents.cmbPicLoc.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 - 1;

                        My.MyProject.Forms.frmEvents.nudPicOffsetX.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4;
                        My.MyProject.Forms.frmEvents.nudPicOffsetY.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data5;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraShowPic.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvHidePicture:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.nudHidePic.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraHidePic.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        break;
                    }

                case (int)EventType.EvWaitMovement:
                    {
                        IsEdit = true;
                        My.MyProject.Forms.frmEvents.fraDialogue.Visible = true;
                        My.MyProject.Forms.frmEvents.fraMoveRouteWait.Visible = true;
                        My.MyProject.Forms.frmEvents.fraCommands.Visible = false;
                        My.MyProject.Forms.frmEvents.cmbMoveWait.Items.Clear();
                        ListOfEvents = new int[E_Types.Map.EventCount + 1];
                        ListOfEvents[0] = EditorEvent;
                        My.MyProject.Forms.frmEvents.cmbMoveWait.Items.Add("This Event");
                        My.MyProject.Forms.frmEvents.cmbMoveWait.SelectedIndex = 0;
                        var loopTo5 = E_Types.Map.EventCount;
                        for (i = 1; i <= loopTo5; i++)
                        {
                            if (i != EditorEvent)
                            {
                                My.MyProject.Forms.frmEvents.cmbMoveWait.Items.Add(Microsoft.VisualBasic.Strings.Trim(E_Types.Map.Events[i].Name));
                                x = x + 1;
                                ListOfEvents[x] = i;
                                if (i == TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1)
                                    My.MyProject.Forms.frmEvents.cmbMoveWait.SelectedIndex = x;
                            }
                        }

                        break;
                    }
            }
        }

        internal static void DeleteEventCommand()
        {
            int i;
            int x;
            int curlist;
            int curslot;
            int p;
            CommandListRec oldCommandList;

            i = My.MyProject.Forms.frmEvents.lstCommands.SelectedIndex;
            if (i == -1)
                return;
            if (i > Information.UBound(EventList))
                return;
            curlist = EventList[i].CommandList;
            curslot = EventList[i].CommandNum;
            if (curlist == 0)
                return;
            if (curslot == 0)
                return;
            if (curlist > TmpEvent.Pages[CurPageNum].CommandListCount)
                return;
            if (curslot > TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount)
                return;
            if (curslot == TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount)
            {
                TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount - 1;
                p = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount;
                if (p <= 0)
                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands = new EventCommandRec[1];
                else
                {
                    oldCommandList = TmpEvent.Pages[CurPageNum].CommandList[curlist];
                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands = new EventCommandRec[p + 1];
                    x = 1;
                    TmpEvent.Pages[CurPageNum].CommandList[curlist].ParentList = oldCommandList.ParentList;
                    TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount = p;
                    var loopTo = p + 1;
                    for (i = 1; i <= loopTo; i++)
                    {
                        if (i != curslot)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[x] = oldCommandList.Commands[i];
                            x = x + 1;
                        }
                    }
                }
            }
            else
            {
                TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount - 1;
                p = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount;
                oldCommandList = TmpEvent.Pages[CurPageNum].CommandList[curlist];
                x = 1;
                if (p <= 0)
                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands = new EventCommandRec[1];
                else
                {
                    TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands = new EventCommandRec[p + 1];
                    TmpEvent.Pages[CurPageNum].CommandList[curlist].ParentList = oldCommandList.ParentList;
                    TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount = p;
                    var loopTo1 = p + 1;
                    for (i = 1; i <= loopTo1; i++)
                    {
                        if (i != curslot)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[x] = oldCommandList.Commands[i];
                            x = x + 1;
                        }
                    }
                }
            }
            EventListCommands();
        }

        internal static void ClearEventCommands()
        {
            TmpEvent.Pages[CurPageNum].CommandList = new CommandListRec[2];
            TmpEvent.Pages[CurPageNum].CommandListCount = 1;
            EventListCommands();
        }

        internal static void EditCommand()
        {
            int i;
            int curlist;
            int curslot;

            i = My.MyProject.Forms.frmEvents.lstCommands.SelectedIndex;
            if (i == -1)
                return;
            if (i > Information.UBound(EventList))
                return;

            curlist = EventList[i].CommandList;
            curslot = EventList[i].CommandNum;
            if (curlist == 0)
                return;
            if (curslot == 0)
                return;
            if (curlist > TmpEvent.Pages[CurPageNum].CommandListCount)
                return;
            if (curslot > TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount)
                return;
            switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index)
            {
                case (int)EventType.EvAddText:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = My.MyProject.Forms.frmEvents.txtAddText_Text.Text;
                        // tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlAddText_Colour.Value
                        if (My.MyProject.Forms.frmEvents.optAddText_Player.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
                        else if (My.MyProject.Forms.frmEvents.optAddText_Map.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
                        else if (My.MyProject.Forms.frmEvents.optAddText_Global.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 2;
                        break;
                    }

                case (int)EventType.EvCondition:
                    {
                        if (My.MyProject.Forms.frmEvents.optCondition0.Checked == true)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 0;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_PlayerVarIndex.SelectedIndex + 1;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = (int)My.MyProject.Forms.frmEvents.cmbCondition_PlayerVarCompare.SelectedIndex;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3 = (int)My.MyProject.Forms.frmEvents.nudCondition_PlayerVarCondition.Value;
                        }
                        else if (My.MyProject.Forms.frmEvents.optCondition1.Checked == true)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 1;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_PlayerSwitch.SelectedIndex + 1;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = (int)My.MyProject.Forms.frmEvents.cmbCondtion_PlayerSwitchCondition.SelectedIndex;
                        }
                        else if (My.MyProject.Forms.frmEvents.optCondition2.Checked == true)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 2;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_HasItem.SelectedIndex + 1;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = (int)My.MyProject.Forms.frmEvents.nudCondition_HasItem.Value;
                        }
                        else if (My.MyProject.Forms.frmEvents.optCondition3.Checked == true)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 3;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_ClassIs.SelectedIndex + 1;
                        }
                        else if (My.MyProject.Forms.frmEvents.optCondition4.Checked == true)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 4;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_LearntSkill.SelectedIndex + 1;
                        }
                        else if (My.MyProject.Forms.frmEvents.optCondition5.Checked == true)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 5;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.nudCondition_LevelAmount.Value;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = (int)My.MyProject.Forms.frmEvents.cmbCondition_LevelCompare.SelectedIndex;
                        }
                        else if (My.MyProject.Forms.frmEvents.optCondition6.Checked == true)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 6;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_SelfSwitch.SelectedIndex;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = (int)My.MyProject.Forms.frmEvents.cmbCondition_SelfSwitchCondition.SelectedIndex;
                        }
                        else if (My.MyProject.Forms.frmEvents.optCondition7.Checked == true)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 7;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.nudCondition_Quest.Value;
                            if (My.MyProject.Forms.frmEvents.optCondition_Quest0.Checked)
                            {
                                TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = 0;
                                TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3 = (int)My.MyProject.Forms.frmEvents.cmbCondition_General.SelectedIndex;
                            }
                            else
                            {
                                TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = 1;
                                TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3 = (int)My.MyProject.Forms.frmEvents.nudCondition_QuestTask.Value;
                            }
                        }
                        else if (My.MyProject.Forms.frmEvents.optCondition8.Checked == true)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 8;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_Gender.SelectedIndex;
                        }
                        else if (My.MyProject.Forms.frmEvents.optCondition9.Checked == true)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 9;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int)My.MyProject.Forms.frmEvents.cmbCondition_Time.SelectedIndex;
                        }

                        break;
                    }

                case (int)EventType.EvShowText:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = My.MyProject.Forms.frmEvents.txtShowText.Text;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudShowTextFace.Value;
                        break;
                    }

                case (int)EventType.EvShowChoices:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = My.MyProject.Forms.frmEvents.txtChoicePrompt.Text;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text2 = My.MyProject.Forms.frmEvents.txtChoices1.Text;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text3 = My.MyProject.Forms.frmEvents.txtChoices2.Text;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text4 = My.MyProject.Forms.frmEvents.txtChoices3.Text;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text5 = My.MyProject.Forms.frmEvents.txtChoices4.Text;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data5 = (int)My.MyProject.Forms.frmEvents.nudShowChoicesFace.Value;
                        break;
                    }

                case (int)EventType.EvPlayerVar:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbVariable.SelectedIndex + 1;
                        if (My.MyProject.Forms.frmEvents.optVariableAction0.Checked == true)
                            i = 0;
                        if (My.MyProject.Forms.frmEvents.optVariableAction1.Checked == true)
                            i = 1;
                        if (My.MyProject.Forms.frmEvents.optVariableAction2.Checked == true)
                            i = 2;
                        if (My.MyProject.Forms.frmEvents.optVariableAction3.Checked == true)
                            i = 3;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = i;
                        if (i == 0)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudVariableData0.Value;
                        else if (i == 1)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudVariableData1.Value;
                        else if (i == 2)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudVariableData2.Value;
                        else if (i == 3)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudVariableData3.Value;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int)My.MyProject.Forms.frmEvents.nudVariableData4.Value;
                        }

                        break;
                    }

                case (int)EventType.EvPlayerSwitch:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbSwitch.SelectedIndex + 1;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.cmbPlayerSwitchSet.SelectedIndex;
                        break;
                    }

                case (int)EventType.EvSelfSwitch:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbSetSelfSwitch.SelectedIndex;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.cmbSetSelfSwitchTo.SelectedIndex;
                        break;
                    }

                case (int)EventType.EvChangeItems:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbChangeItemIndex.SelectedIndex + 1;
                        if (My.MyProject.Forms.frmEvents.optChangeItemSet.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
                        else if (My.MyProject.Forms.frmEvents.optChangeItemAdd.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
                        else if (My.MyProject.Forms.frmEvents.optChangeItemRemove.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 2;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudChangeItemsAmount.Value;
                        break;
                    }

                case (int)EventType.EvChangeLevel:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudChangeLevel.Value;
                        break;
                    }

                case (int)EventType.EvChangeSkills:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbChangeSkills.SelectedIndex + 1;
                        if (My.MyProject.Forms.frmEvents.optChangeSkillsAdd.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
                        else if (My.MyProject.Forms.frmEvents.optChangeSkillsRemove.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
                        break;
                    }

                case (int)EventType.EvChangeClass:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbChangeClass.SelectedIndex + 1;
                        break;
                    }

                case (int)EventType.EvChangeSprite:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudChangeSprite.Value;
                        break;
                    }

                case (int)EventType.EvChangeSex:
                    {
                        if (My.MyProject.Forms.frmEvents.optChangeSexMale.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = 0;
                        else if (My.MyProject.Forms.frmEvents.optChangeSexFemale.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = 1;
                        break;
                    }

                case (int)EventType.EvChangePk:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbSetPK.SelectedIndex;
                        break;
                    }

                case (int)EventType.EvWarpPlayer:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudWPMap.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.nudWPX.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudWPY.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int)My.MyProject.Forms.frmEvents.cmbWarpPlayerDir.SelectedIndex;
                        break;
                    }

                case (int)EventType.EvSetMoveRoute:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = ListOfEvents[My.MyProject.Forms.frmEvents.cmbEvent.SelectedIndex];
                        if (My.MyProject.Forms.frmEvents.chkIgnoreMove.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
                        else
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;

                        if (My.MyProject.Forms.frmEvents.chkRepeatRoute.Checked == true)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = 1;
                        else
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = 0;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].MoveRouteCount = TempMoveRouteCount;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].MoveRoute = TempMoveRoute;
                        break;
                    }

                case (int)EventType.EvPlayAnimation:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbPlayAnim.SelectedIndex + 1;
                        if (My.MyProject.Forms.frmEvents.cmbAnimTargetType.SelectedIndex == 0)
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
                        else if (My.MyProject.Forms.frmEvents.cmbAnimTargetType.SelectedIndex == 1)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.cmbPlayAnimEvent.SelectedIndex + 1;
                        }
                        else if (My.MyProject.Forms.frmEvents.cmbAnimTargetType.SelectedIndex == 2)
                        {
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 2;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudPlayAnimTileX.Value;
                            TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int)My.MyProject.Forms.frmEvents.nudPlayAnimTileY.Value;
                        }

                        break;
                    }

                case (int)EventType.EvCustomScript:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudCustomScript.Value;
                        break;
                    }

                case (int)EventType.EvPlayBgm:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = E_Sound.MusicCache[My.MyProject.Forms.frmEvents.cmbPlayBGM.SelectedIndex + 1];
                        break;
                    }

                case (int)EventType.EvPlaySound:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = E_Sound.SoundCache[My.MyProject.Forms.frmEvents.cmbPlaySound.SelectedIndex + 1];
                        break;
                    }

                case (int)EventType.EvOpenShop:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbOpenShop.SelectedIndex + 1;
                        break;
                    }

                case (int)EventType.EvSetAccess:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbSetAccess.SelectedIndex;
                        break;
                    }

                case (int)EventType.EvGiveExp:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudGiveExp.Value;
                        break;
                    }

                case (int)EventType.EvShowChatBubble:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = My.MyProject.Forms.frmEvents.txtChatbubbleText.Text;

                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbChatBubbleTargetType.SelectedIndex + 1;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.cmbChatBubbleTarget.SelectedIndex + 1;
                        break;
                    }

                case (int)EventType.EvLabel:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = My.MyProject.Forms.frmEvents.txtLabelName.Text;
                        break;
                    }

                case (byte)EventType.EvGotoLabel:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = My.MyProject.Forms.frmEvents.txtGotoLabel.Text;
                        break;
                    }

                case (byte)EventType.EvSpawnNpc:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbSpawnNpc.SelectedIndex + 1;
                        break;
                    }

                case (byte)EventType.EvSetFog:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudFogData0.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.nudFogData1.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudFogData2.Value;
                        break;
                    }

                case (byte)EventType.EvSetWeather:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.CmbWeather.SelectedIndex;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.nudWeatherIntensity.Value;
                        break;
                    }

                case (byte)EventType.EvSetTint:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudMapTintData0.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.nudMapTintData1.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.nudMapTintData2.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int)My.MyProject.Forms.frmEvents.nudMapTintData3.Value;
                        break;
                    }

                case (byte)EventType.EvWait:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudWaitAmount.Value;
                        break;
                    }

                case (byte)EventType.EvBeginQuest:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbBeginQuest.SelectedIndex;
                        break;
                    }

                case (byte)EventType.EvEndQuest:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbEndQuest.SelectedIndex;
                        break;
                    }

                case (byte)EventType.EvQuestTask:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbCompleteQuest.SelectedIndex;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.nudCompleteQuestTask.Value;
                        break;
                    }

                case (byte)EventType.EvShowPicture:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.cmbPicIndex.SelectedIndex;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int)My.MyProject.Forms.frmEvents.nudShowPicture.Value;

                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int)My.MyProject.Forms.frmEvents.cmbPicLoc.SelectedIndex + 1;

                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int)My.MyProject.Forms.frmEvents.nudPicOffsetX.Value;
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data5 = (int)My.MyProject.Forms.frmEvents.nudPicOffsetY.Value;
                        break;
                    }

                case (byte)EventType.EvHidePicture:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int)My.MyProject.Forms.frmEvents.nudHidePic.Value;
                        break;
                    }

                case (byte)EventType.EvWaitMovement:
                    {
                        TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = ListOfEvents[My.MyProject.Forms.frmEvents.cmbMoveWait.SelectedIndex];
                        break;
                    }
            }
            EventListCommands();
        }

        public static void RequestSwitchesAndVariables()
        {
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CRequestSwitchesAndVariables);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendSwitchesAndVariables()
        {
            int i;
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CSwitchesAndVariables);
            for (i = 1; i <= MaxSwitches; i++)
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Switches[i])));
            for (i = 1; i <= MaxVariables; i++)
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Variables[i])));
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);

            buffer.Dispose();
        }



        public static void Packet_SpawnEvent(ref byte[] data)
        {
            int id;
            ByteStream buffer = new ByteStream(data);
            id = buffer.ReadInt32();
            if (id > E_Types.Map.CurrentEvents)
            {
                E_Types.Map.CurrentEvents = id;
                var oldMapEvents = E_Types.Map.MapEvents;
                E_Types.Map.MapEvents = new MapEventRec[E_Types.Map.CurrentEvents + 1];
                if (oldMapEvents != null)
                    Array.Copy(oldMapEvents, E_Types.Map.MapEvents, Math.Min(E_Types.Map.CurrentEvents + 1, oldMapEvents.Length));
            }

            {
                var withBlock = E_Types.Map.MapEvents[id];
                withBlock.Name = buffer.ReadString();
                withBlock.Dir = buffer.ReadInt32();
                withBlock.ShowDir = withBlock.Dir;
                withBlock.GraphicNum = buffer.ReadInt32();
                withBlock.GraphicType = buffer.ReadInt32();
                withBlock.GraphicX = buffer.ReadInt32();
                withBlock.GraphicX2 = buffer.ReadInt32();
                withBlock.GraphicY = buffer.ReadInt32();
                withBlock.GraphicY2 = buffer.ReadInt32();
                withBlock.MovementSpeed = buffer.ReadInt32();
                withBlock.Moving = 0;
                withBlock.X = buffer.ReadInt32();
                withBlock.Y = buffer.ReadInt32();
                withBlock.XOffset = 0;
                withBlock.YOffset = 0;
                withBlock.Position = buffer.ReadInt32();
                withBlock.Visible = buffer.ReadInt32();
                withBlock.WalkAnim = buffer.ReadInt32();
                withBlock.DirFix = buffer.ReadInt32();
                withBlock.WalkThrough = buffer.ReadInt32();
                withBlock.ShowName = buffer.ReadInt32();
                withBlock.Questnum = buffer.ReadInt32();
            }
            buffer.Dispose();
        }

        public static void Packet_EventMove(ref byte[] data)
        {
            int id;
            int x;
            int y;
            int dir;
            int showDir;
            int movementSpeed;
            ByteStream buffer = new ByteStream(data);
            id = buffer.ReadInt32();
            x = buffer.ReadInt32();
            y = buffer.ReadInt32();
            dir = buffer.ReadInt32();
            showDir = buffer.ReadInt32();
            movementSpeed = buffer.ReadInt32();
            if (id > E_Types.Map.CurrentEvents)
                return;

            {
                var withBlock = E_Types.Map.MapEvents[id];
                withBlock.X = x;
                withBlock.Y = y;
                withBlock.Dir = dir;
                withBlock.XOffset = 0;
                withBlock.YOffset = 0;
                withBlock.Moving = 1;
                withBlock.ShowDir = showDir;
                withBlock.MovementSpeed = movementSpeed;

                switch (dir)
                {
                    case (int)Enums.DirectionType.Up:
                        {
                            withBlock.YOffset = E_Globals.PIC_Y;
                            break;
                        }

                    case (int)Enums.DirectionType.Down:
                        {
                            withBlock.YOffset = E_Globals.PIC_Y * -1;
                            break;
                        }

                    case (int)Enums.DirectionType.Left:
                        {
                            withBlock.XOffset = E_Globals.PIC_X;
                            break;
                        }

                    case (int)Enums.DirectionType.Right:
                        {
                            withBlock.XOffset = E_Globals.PIC_X * -1;
                            break;
                        }
                }
            }
        }

        public static void Packet_EventDir(ref byte[] data)
        {
            int i;
            byte dir;
            ByteStream buffer = new ByteStream(data);
            i = buffer.ReadInt32();
            dir = (byte)buffer.ReadInt32();
            if (i > E_Types.Map.CurrentEvents)
                return;

            {
                var withBlock = E_Types.Map.MapEvents[i];
                withBlock.Dir = dir;
                withBlock.ShowDir = dir;
                withBlock.XOffset = 0;
                withBlock.YOffset = 0;
                withBlock.Moving = 0;
            }
        }

        public static void Packet_SwitchesAndVariables(ref byte[] data)
        {
            int i;
            ByteStream buffer = new ByteStream(data);
            for (i = 1; i <= MaxSwitches; i++)
                Switches[i] = buffer.ReadString();
            for (i = 1; i <= MaxVariables; i++)
                Variables[i] = buffer.ReadString();

            buffer.Dispose();
        }

        public static void Packet_MapEventData(ref byte[] data)
        {
            int i;
            int x;
            int y;
            int z;
            int w;

            ByteStream buffer = new ByteStream(data);
            // Event Data!
            E_Types.Map.EventCount = buffer.ReadInt32();
            if (E_Types.Map.EventCount > 0)
            {
                E_Types.Map.Events = new EventRec[E_Types.Map.EventCount + 1];
                var loopTo = E_Types.Map.EventCount;
                for (i = 1; i <= loopTo; i++)
                {
                    {
                        var withBlock = E_Types.Map.Events[i];
                        withBlock.Name = buffer.ReadString();
                        withBlock.Globals = buffer.ReadInt32();
                        withBlock.X = buffer.ReadInt32();
                        withBlock.Y = buffer.ReadInt32();
                        withBlock.PageCount = buffer.ReadInt32();
                    }
                    if (E_Types.Map.Events[i].PageCount > 0)
                    {
                        E_Types.Map.Events[i].Pages = new EventPageRec[E_Types.Map.Events[i].PageCount + 1];
                        var loopTo1 = E_Types.Map.Events[i].PageCount;
                        for (x = 1; x <= loopTo1; x++)
                        {
                            {
                                var withBlock1 = E_Types.Map.Events[i].Pages[x];
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
                                    E_Types.Map.Events[i].Pages[x].MoveRoute = new MoveRouteRec[withBlock1.MoveRouteCount + 1];
                                    var loopTo2 = withBlock1.MoveRouteCount;
                                    for (y = 1; y <= loopTo2; y++)
                                    {
                                        withBlock1.MoveRoute[y].Index = buffer.ReadInt32();
                                        withBlock1.MoveRoute[y].Data1 = buffer.ReadInt32();
                                        withBlock1.MoveRoute[y].Data2 = buffer.ReadInt32();
                                        withBlock1.MoveRoute[y].Data3 = buffer.ReadInt32();
                                        withBlock1.MoveRoute[y].Data4 = buffer.ReadInt32();
                                        withBlock1.MoveRoute[y].Data5 = buffer.ReadInt32();
                                        withBlock1.MoveRoute[y].Data6 = buffer.ReadInt32();
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
                            }
                            if (E_Types.Map.Events[i].Pages[x].CommandListCount > 0)
                            {
                                E_Types.Map.Events[i].Pages[x].CommandList = new CommandListRec[E_Types.Map.Events[i].Pages[x].CommandListCount + 1];
                                var loopTo3 = E_Types.Map.Events[i].Pages[x].CommandListCount;
                                for (y = 1; y <= loopTo3; y++)
                                {
                                    E_Types.Map.Events[i].Pages[x].CommandList[y].CommandCount = buffer.ReadInt32();
                                    E_Types.Map.Events[i].Pages[x].CommandList[y].ParentList = buffer.ReadInt32();
                                    if (E_Types.Map.Events[i].Pages[x].CommandList[y].CommandCount > 0)
                                    {
                                        E_Types.Map.Events[i].Pages[x].CommandList[y].Commands = new EventCommandRec[E_Types.Map.Events[i].Pages[x].CommandList[y].CommandCount + 1];
                                        var loopTo4 = E_Types.Map.Events[i].Pages[x].CommandList[y].CommandCount;
                                        for (z = 1; z <= loopTo4; z++)
                                        {
                                            {
                                                var withBlock2 = E_Types.Map.Events[i].Pages[x].CommandList[y].Commands[z];
                                                withBlock2.Index = buffer.ReadInt32();
                                                withBlock2.Text1 = buffer.ReadString();
                                                withBlock2.Text2 = buffer.ReadString();
                                                withBlock2.Text3 = buffer.ReadString();
                                                withBlock2.Text4 = buffer.ReadString();
                                                withBlock2.Text5 = buffer.ReadString();
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
                                                    var loopTo5 = withBlock2.MoveRouteCount;
                                                    for (w = 1; w <= loopTo5; w++)
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
            // End Event Data
            buffer.Dispose();
        }

        public static void Packet_EventChat(ref byte[] data)
        {
            int i;
            int choices;
            ByteStream buffer = new ByteStream(data);
            EventReplyId = buffer.ReadInt32();
            EventReplyPage = buffer.ReadInt32();
            EventChatFace = buffer.ReadInt32();
            EventText = buffer.ReadString();
            if (EventText == "")
                EventText = " ";
            EventChat = true;
            ShowEventLbl = true;
            choices = buffer.ReadInt32();
            InEvent = true;
            for (i = 1; i <= 4; i++)
            {
                EventChoices[i] = "";
                EventChoiceVisible[i] = false;
            }
            EventChatType = 0;
            if (choices == 0)
            {
            }
            else
            {
                EventChatType = 1;
                var loopTo = choices;
                for (i = 1; i <= loopTo; i++)
                {
                    EventChoices[i] = buffer.ReadString();
                    EventChoiceVisible[i] = true;
                }
            }
            AnotherChat = buffer.ReadInt32();

            buffer.Dispose();
        }

        public static void Packet_EventStart(ref byte[] data)
        {
            InEvent = true;
        }

        public static void Packet_EventEnd(ref byte[] data)
        {
            InEvent = false;
        }

        public static void Packet_HoldPlayer(ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            if (buffer.ReadInt32() == 0)
                HoldPlayer = true;
            else
                HoldPlayer = false;

            buffer.Dispose();
        }



        internal static void EditorEvent_DrawGraphic()
        {
            Types.Rect sRect = new Types.Rect();
            Types.Rect dRect = new Types.Rect();
            Bitmap targetBitmap; // Bitmap we draw to
            Bitmap sourceBitmap; // This is our sprite or tileset that we are drawing from
            Graphics g; // This is our graphics class that helps us draw to the targetBitmap

            if (My.MyProject.Forms.frmEvents.picGraphicSel.Visible)
            {
                switch (My.MyProject.Forms.frmEvents.cmbGraphic.SelectedIndex)
                {
                    case 0:
                        {
                            // None
                            My.MyProject.Forms.frmEvents.picGraphicSel.BackgroundImage = null;
                            break;
                        }

                    case 1:
                        {
                            if (My.MyProject.Forms.frmEvents.nudGraphic.Value > 0 && My.MyProject.Forms.frmEvents.nudGraphic.Value <= E_Graphics.NumCharacters)
                            {
                                // Load character from Contents into our sourceBitmap
                                sourceBitmap = new Bitmap(Application.StartupPath + "/Data/graphics/characters/" + My.MyProject.Forms.frmEvents.nudGraphic.Value + ".png");
                                targetBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height); // Create our target Bitmap

                                g = Graphics.FromImage(targetBitmap);

                                Rectangle sourceRect = new Rectangle(0, 0, sourceBitmap.Width / (int)4, sourceBitmap.Height / (int)4);  // This is the section we are pulling from the source graphic
                                Rectangle destRect = new Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height);     // This is the rectangle in the target graphic we want to render to

                                g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel);

                                g.DrawRectangle(Pens.Red, new Rectangle(GraphicSelX * E_Globals.PIC_X, GraphicSelY * E_Globals.PIC_Y, GraphicSelX2 * E_Globals.PIC_X, GraphicSelY2 * E_Globals.PIC_Y));

                                g.Dispose();

                                My.MyProject.Forms.frmEvents.picGraphicSel.Width = targetBitmap.Width;
                                My.MyProject.Forms.frmEvents.picGraphicSel.Height = targetBitmap.Height;
                                My.MyProject.Forms.frmEvents.picGraphicSel.Visible = true;
                                My.MyProject.Forms.frmEvents.picGraphicSel.BackgroundImage = targetBitmap;
                                My.MyProject.Forms.frmEvents.picGraphic.BackgroundImage = targetBitmap;
                            }
                            else
                            {
                                My.MyProject.Forms.frmEvents.picGraphicSel.BackgroundImage = null;
                                return;
                            }

                            break;
                        }

                    case 2:
                        {
                            if (My.MyProject.Forms.frmEvents.nudGraphic.Value > 0 && My.MyProject.Forms.frmEvents.nudGraphic.Value <= E_Graphics.NumTileSets)
                            {
                                // Load tilesheet from Contents into our sourceBitmap
                                sourceBitmap = new Bitmap(Application.StartupPath + "/Data/graphics/tilesets/" + My.MyProject.Forms.frmEvents.nudGraphic.Value + ".png");
                                targetBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height); // Create our target Bitmap

                                if (TmpEvent.Pages[CurPageNum].GraphicX2 == 0 && TmpEvent.Pages[CurPageNum].GraphicY2 == 0)
                                {
                                    sRect.Top = TmpEvent.Pages[CurPageNum].GraphicY * 32;
                                    sRect.Left = TmpEvent.Pages[CurPageNum].GraphicX * 32;
                                    sRect.Bottom = sRect.Top + 32;
                                    sRect.Right = sRect.Left + 32;

                                    {
                                        var withBlock = dRect;
                                        dRect.Top = (193 / (int)2) - ((sRect.Bottom - sRect.Top) / (int)2);
                                        dRect.Bottom = dRect.Top + (sRect.Bottom - sRect.Top);
                                        dRect.Left = (120 / (int)2) - ((sRect.Right - sRect.Left) / (int)2);
                                        dRect.Right = dRect.Left + (sRect.Right - sRect.Left);
                                    }
                                }
                                else
                                {
                                    sRect.Top = TmpEvent.Pages[CurPageNum].GraphicY * 32;
                                    sRect.Left = TmpEvent.Pages[CurPageNum].GraphicX * 32;
                                    sRect.Bottom = sRect.Top + ((TmpEvent.Pages[CurPageNum].GraphicY2 - TmpEvent.Pages[CurPageNum].GraphicY) * 32);
                                    sRect.Right = sRect.Left + ((TmpEvent.Pages[CurPageNum].GraphicX2 - TmpEvent.Pages[CurPageNum].GraphicX) * 32);

                                    {
                                        var withBlock1 = dRect;
                                        dRect.Top = (193 / (int)2) - ((sRect.Bottom - sRect.Top) / (int)2);
                                        dRect.Bottom = dRect.Top + (sRect.Bottom - sRect.Top);
                                        dRect.Left = (120 / (int)2) - ((sRect.Right - sRect.Left) / (int)2);
                                        dRect.Right = dRect.Left + (sRect.Right - sRect.Left);
                                    }
                                }

                                g = Graphics.FromImage(targetBitmap);

                                Rectangle sourceRect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);  // This is the section we are pulling from the source graphic
                                Rectangle destRect = new Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height);     // This is the rectangle in the target graphic we want to render to

                                g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel);

                                g.DrawRectangle(Pens.Red, new Rectangle(GraphicSelX * E_Globals.PIC_X, GraphicSelY * E_Globals.PIC_Y, (GraphicSelX2) * E_Globals.PIC_X, (GraphicSelY2) * E_Globals.PIC_Y));

                                g.Dispose();

                                My.MyProject.Forms.frmEvents.picGraphicSel.Width = targetBitmap.Width;
                                My.MyProject.Forms.frmEvents.picGraphicSel.Height = targetBitmap.Height;
                                My.MyProject.Forms.frmEvents.picGraphicSel.Visible = true;
                                My.MyProject.Forms.frmEvents.picGraphicSel.BackgroundImage = targetBitmap;
                            }
                            else
                            {
                                My.MyProject.Forms.frmEvents.picGraphicSel.BackgroundImage = null;
                                return;
                            }

                            break;
                        }
                }
            }
            else if (TmpEvent.PageCount > 0)
            {
                switch (TmpEvent.Pages[CurPageNum].GraphicType)
                {
                    case 0:
                        {
                            My.MyProject.Forms.frmEvents.picGraphicSel.BackgroundImage = null;
                            break;
                        }

                    case 1:
                        {
                            if (TmpEvent.Pages[CurPageNum].Graphic > 0 && TmpEvent.Pages[CurPageNum].Graphic <= E_Graphics.NumCharacters)
                            {
                                // Load character from Contents into our sourceBitmap
                                sourceBitmap = new Bitmap(Application.StartupPath + E_Globals.GFX_PATH + @"\characters\" + TmpEvent.Pages[CurPageNum].Graphic + ".png");
                                targetBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height); // Create our target Bitmap

                                g = Graphics.FromImage(targetBitmap);

                                Rectangle sourceRect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height);  // This is the section we are pulling from the source graphic
                                Rectangle destRect = new Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height);     // This is the rectangle in the target graphic we want to render to

                                g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel);

                                g.Dispose();

                                My.MyProject.Forms.frmEvents.picGraphic.Width = targetBitmap.Width;
                                My.MyProject.Forms.frmEvents.picGraphic.Height = targetBitmap.Height;
                                My.MyProject.Forms.frmEvents.picGraphic.BackgroundImage = targetBitmap;
                            }
                            else
                            {
                                My.MyProject.Forms.frmEvents.picGraphic.BackgroundImage = null;
                                return;
                            }

                            break;
                        }

                    case 2:
                        {
                            if (TmpEvent.Pages[CurPageNum].Graphic > 0 && TmpEvent.Pages[CurPageNum].Graphic <= E_Graphics.NumTileSets)
                            {
                                // Load tilesheet from Contents into our sourceBitmap
                                sourceBitmap = new Bitmap(Application.StartupPath + E_Globals.GFX_PATH + @"tilesets\" + TmpEvent.Pages[CurPageNum].Graphic + ".png");
                                targetBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height); // Create our target Bitmap

                                if (TmpEvent.Pages[CurPageNum].GraphicX2 == 0 && TmpEvent.Pages[CurPageNum].GraphicY2 == 0)
                                {
                                    sRect.Top = TmpEvent.Pages[CurPageNum].GraphicY * 32;
                                    sRect.Left = TmpEvent.Pages[CurPageNum].GraphicX * 32;
                                    sRect.Bottom = sRect.Top + 32;
                                    sRect.Right = sRect.Left + 32;

                                    {
                                        var withBlock2 = dRect;
                                        dRect.Top = 0;
                                        dRect.Bottom = E_Globals.PIC_Y;
                                        dRect.Left = 0;
                                        dRect.Right = E_Globals.PIC_X;
                                    }
                                }
                                else
                                {
                                    sRect.Top = TmpEvent.Pages[CurPageNum].GraphicY * 32;
                                    sRect.Left = TmpEvent.Pages[CurPageNum].GraphicX * 32;
                                    sRect.Bottom = TmpEvent.Pages[CurPageNum].GraphicY2 * 32;
                                    sRect.Right = TmpEvent.Pages[CurPageNum].GraphicX2 * 32;

                                    {
                                        var withBlock3 = dRect;
                                        dRect.Top = 0;
                                        dRect.Bottom = sRect.Bottom;
                                        dRect.Left = 0;
                                        dRect.Right = sRect.Right;
                                    }
                                }

                                g = Graphics.FromImage(targetBitmap);

                                Rectangle sourceRect = new Rectangle(sRect.Left, sRect.Top, sRect.Right, sRect.Bottom);  // This is the section we are pulling from the source graphic
                                Rectangle destRect = new Rectangle(dRect.Left, dRect.Top, dRect.Right, dRect.Bottom);     // This is the rectangle in the target graphic we want to render to

                                g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel);

                                g.Dispose();

                                My.MyProject.Forms.frmEvents.picGraphic.Width = targetBitmap.Width;
                                My.MyProject.Forms.frmEvents.picGraphic.Height = targetBitmap.Height;
                                My.MyProject.Forms.frmEvents.picGraphic.BackgroundImage = targetBitmap;
                            }

                            break;
                        }
                }
            }
        }

        internal static void DrawEvents()
        {
            Rectangle rec = new Rectangle();
            int width;
            int height;
            int i;
            int x;
            int y;
            int tX;
            int tY;

            if (E_Types.Map.EventCount <= 0)
                return;
            var loopTo = E_Types.Map.EventCount;
            for (i = 1; i <= loopTo; i++)
            {
                width = 32;
                height = 32;
                x = E_Types.Map.Events[i].X * 32;
                y = E_Types.Map.Events[i].Y * 32;
                if (E_Types.Map.Events[i].PageCount <= 0)
                {
                    {
                        var withBlock = rec;
                        withBlock.Y = 0;
                        withBlock.Height = E_Globals.PIC_Y;
                        withBlock.X = 0;
                        withBlock.Width = E_Globals.PIC_X;
                    }

                    RectangleShape rec2 = new RectangleShape()
                    {
                        OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.Blue),
                        OutlineThickness = 0.6f,
                        FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
                        Size = new Vector2f(rec.Width, rec.Height),
                        Position = new Vector2f(E_Graphics.ConvertMapX(E_Globals.CurX * E_Globals.PIC_X), E_Graphics.ConvertMapY(E_Globals.CurY * E_Globals.PIC_Y))
                    };
                    E_Graphics.GameWindow.Draw(rec2);
                    goto nextevent;
                }
                x = E_Graphics.ConvertMapX(x);
                y = E_Graphics.ConvertMapY(y);
                if (i > E_Types.Map.EventCount)
                    return;
                if (1 > E_Types.Map.Events[i].PageCount)
                    return;
                switch (E_Types.Map.Events[i].Pages[1].GraphicType)
                {
                    case 0:
                        {
                            tX = ((x) - 4) + (E_Globals.PIC_X * (int)0.5);
                            tY = ((y) - 7) + (E_Globals.PIC_Y * (int)0.5);
                            E_Text.DrawText(tX, tY, "EV", (SFML.Graphics.Color.Green), (SFML.Graphics.Color.Black), ref E_Graphics.GameWindow);
                            break;
                        }

                    case 1:
                        {
                            if (E_Types.Map.Events[i].Pages[1].Graphic > 0 && E_Types.Map.Events[i].Pages[1].Graphic <= E_Graphics.NumCharacters)
                            {
                                if (E_Graphics.CharacterGFXInfo[E_Types.Map.Events[i].Pages[1].Graphic].IsLoaded == false)
                                    E_Graphics.LoadTexture(E_Types.Map.Events[i].Pages[1].Graphic, 2);

                                // seeying we still use it, lets update timer
                                {
                                    var withBlock1 = E_Graphics.CharacterGFXInfo[E_Types.Map.Events[i].Pages[1].Graphic];
                                    withBlock1.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                                }
                                {
                                    var withBlock2 = rec;
                                    withBlock2.Y = (E_Types.Map.Events[i].Pages[1].GraphicY * (E_Graphics.CharacterGFXInfo[E_Types.Map.Events[i].Pages[1].Graphic].height / (int)4));
                                    withBlock2.Height = withBlock2.Y + E_Globals.PIC_Y;
                                    withBlock2.X = (E_Types.Map.Events[i].Pages[1].GraphicX * (E_Graphics.CharacterGFXInfo[E_Types.Map.Events[i].Pages[1].Graphic].width / (int)4));
                                    withBlock2.Width = withBlock2.X + E_Globals.PIC_X;
                                }

                                Sprite tmpSprite = new Sprite(E_Graphics.CharacterGFX[E_Types.Map.Events[i].Pages[1].Graphic])
                                {
                                    TextureRect = new IntRect(rec.X, rec.Y, rec.Width, rec.Height),
                                    Position = new Vector2f(E_Graphics.ConvertMapX(E_Types.Map.Events[i].X * E_Globals.PIC_X), E_Graphics.ConvertMapY(E_Types.Map.Events[i].Y * E_Globals.PIC_Y))
                                };
                                E_Graphics.GameWindow.Draw(tmpSprite);
                            }
                            else
                            {
                                {
                                    var withBlock3 = rec;
                                    withBlock3.Y = 0;
                                    withBlock3.Height = E_Globals.PIC_Y;
                                    withBlock3.X = 0;
                                    withBlock3.Width = E_Globals.PIC_X;
                                }

                                RectangleShape rec2 = new RectangleShape()
                                {
                                    OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.Blue),
                                    OutlineThickness = 0.6f,
                                    FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
                                    Size = new Vector2f(rec.Width, rec.Height),
                                    Position = new Vector2f(E_Graphics.ConvertMapX(E_Globals.CurX * E_Globals.PIC_X), E_Graphics.ConvertMapY(E_Globals.CurY * E_Globals.PIC_Y))
                                };
                                E_Graphics.GameWindow.Draw(rec2);
                            }

                            break;
                        }

                    case 2:
                        {
                            if (E_Types.Map.Events[i].Pages[1].Graphic > 0 && E_Types.Map.Events[i].Pages[1].Graphic <= E_Graphics.NumTileSets)
                            {
                                {
                                    var withBlock4 = rec;
                                    withBlock4.X = E_Types.Map.Events[i].Pages[1].GraphicX * 32;
                                    withBlock4.Width = E_Types.Map.Events[i].Pages[1].GraphicX2 * 32;
                                    withBlock4.Y = E_Types.Map.Events[i].Pages[1].GraphicY * 32;
                                    withBlock4.Height = E_Types.Map.Events[i].Pages[1].GraphicY2 * 32;
                                }

                                if (E_Graphics.TileSetTextureInfo[E_Types.Map.Events[i].Pages[1].Graphic].IsLoaded == false)
                                    E_Graphics.LoadTexture(E_Types.Map.Events[i].Pages[1].Graphic, 1);
                                // we use it, lets update timer
                                {
                                    var withBlock5 = E_Graphics.TileSetTextureInfo[E_Types.Map.Events[i].Pages[1].Graphic];
                                    withBlock5.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                                }

                                if (rec.Height > 32)
                                    E_Graphics.RenderSprite(E_Graphics.TileSetSprite[E_Types.Map.Events[i].Pages[1].Graphic], E_Graphics.GameWindow, E_Graphics.ConvertMapX(E_Types.Map.Events[i].X * E_Globals.PIC_X), E_Graphics.ConvertMapY(E_Types.Map.Events[i].Y * E_Globals.PIC_Y) - E_Globals.PIC_Y, rec.X, rec.Y, rec.Width, rec.Height);
                                else
                                    E_Graphics.RenderSprite(E_Graphics.TileSetSprite[E_Types.Map.Events[i].Pages[1].Graphic], E_Graphics.GameWindow, E_Graphics.ConvertMapX(E_Types.Map.Events[i].X * E_Globals.PIC_X), E_Graphics.ConvertMapY(E_Types.Map.Events[i].Y * E_Globals.PIC_Y), rec.X, rec.Y, rec.Width, rec.Height);
                            }
                            else
                            {
                                {
                                    var withBlock6 = rec;
                                    withBlock6.Y = 0;
                                    withBlock6.Height = E_Globals.PIC_Y;
                                    withBlock6.X = 0;
                                    withBlock6.Width = E_Globals.PIC_X;
                                }

                                RectangleShape rec2 = new RectangleShape()
                                {
                                    OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.Blue),
                                    OutlineThickness = 0.6f,
                                    FillColor = new  SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
                                    Size = new Vector2f(rec.Width, rec.Height),
                                    Position = new Vector2f(E_Graphics.ConvertMapX(E_Globals.CurX * E_Globals.PIC_X), E_Graphics.ConvertMapY(E_Globals.CurY * E_Globals.PIC_Y))
                                };
                                E_Graphics.GameWindow.Draw(rec2);
                            }

                            break;
                        }
                }

            nextevent:
                ;
            }
        }

        internal static void DrawEvent(int id) // draw on map, outside the editor
        {
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;
            Rectangle sRect = new Rectangle();
            int anim = 0;
            int spritetop = 0;

            if (E_Types.Map.MapEvents[id].Visible == 0)
                return;
            if (E_Globals.InMapEditor)
                return;
            switch (E_Types.Map.MapEvents[id].GraphicType)
            {
                case 0:
                    {
                        return;
                    }

                case 1:
                    {
                        if (E_Types.Map.MapEvents[id].GraphicNum <= 0 || E_Types.Map.MapEvents[id].GraphicNum > E_Graphics.NumCharacters)
                            return;

                        // Reset frame
                        if (E_Types.Map.MapEvents[id].Steps == 3)
                            anim = 0;
                        else if (E_Types.Map.MapEvents[id].Steps == 1)
                            anim = 2;

                        switch (E_Types.Map.MapEvents[id].Dir)
                        {
                            case (int)Enums.DirectionType.Up:
                                {
                                    if ((E_Types.Map.MapEvents[id].YOffset > 8))
                                        anim = E_Types.Map.MapEvents[id].Steps;
                                    break;
                                }

                            case (int)Enums.DirectionType.Down:
                                {
                                    if ((E_Types.Map.MapEvents[id].YOffset < -8))
                                        anim = E_Types.Map.MapEvents[id].Steps;
                                    break;
                                }

                            case (int)Enums.DirectionType.Left:
                                {
                                    if ((E_Types.Map.MapEvents[id].XOffset > 8))
                                        anim = E_Types.Map.MapEvents[id].Steps;
                                    break;
                                }

                            case (int)Enums.DirectionType.Right:
                                {
                                    if ((E_Types.Map.MapEvents[id].XOffset < -8))
                                        anim = E_Types.Map.MapEvents[id].Steps;
                                    break;
                                }
                        }

                        // Set the left
                        switch (E_Types.Map.MapEvents[id].ShowDir)
                        {
                            case (int)Enums.DirectionType.Up:
                                {
                                    spritetop = 3;
                                    break;
                                }

                            case (int)Enums.DirectionType.Right:
                                {
                                    spritetop = 2;
                                    break;
                                }

                            case (int)Enums.DirectionType.Down:
                                {
                                    spritetop = 0;
                                    break;
                                }

                            case (int)Enums.DirectionType.Left:
                                {
                                    spritetop = 1;
                                    break;
                                }
                        }

                        if (E_Types.Map.MapEvents[id].WalkAnim == 1)
                            anim = 0;
                        if (E_Types.Map.MapEvents[id].Moving == 0)
                            anim = E_Types.Map.MapEvents[id].GraphicX;

                        width = E_Graphics.CharacterGFXInfo[E_Types.Map.MapEvents[id].GraphicNum].width / (int)4;
                        height = E_Graphics.CharacterGFXInfo[E_Types.Map.MapEvents[id].GraphicNum].height / (int)4;

                        sRect = new Rectangle((anim) * (E_Graphics.CharacterGFXInfo[E_Types.Map.MapEvents[id].GraphicNum].width / (int)4), spritetop * (E_Graphics.CharacterGFXInfo[E_Types.Map.MapEvents[id].GraphicNum].height / (int)4), (E_Graphics.CharacterGFXInfo[E_Types.Map.MapEvents[id].GraphicNum].width / (int)4), (E_Graphics.CharacterGFXInfo[E_Types.Map.MapEvents[id].GraphicNum].height / (int)4));
                        // Calculate the X
                        x = E_Types.Map.MapEvents[id].X * E_Globals.PIC_X + E_Types.Map.MapEvents[id].XOffset - ((E_Graphics.CharacterGFXInfo[E_Types.Map.MapEvents[id].GraphicNum].width / (int)4 - 32) / 2);

                        // Is the player's height more than 32..?
                        if ((E_Graphics.CharacterGFXInfo[E_Types.Map.MapEvents[id].GraphicNum].height * 4) > 32)
                            // Create a 32 pixel offset for larger sprites
                            y = E_Types.Map.MapEvents[id].Y * E_Globals.PIC_Y + E_Types.Map.MapEvents[id].YOffset - ((E_Graphics.CharacterGFXInfo[E_Types.Map.MapEvents[id].GraphicNum].height / (int)4) - 32);
                        else
                            // Proceed as normal
                            y = E_Types.Map.MapEvents[id].Y * E_Globals.PIC_Y + E_Types.Map.MapEvents[id].YOffset;
                        // render the actual sprite
                        E_Graphics.DrawCharacter(E_Types.Map.MapEvents[id].GraphicNum, x, y, sRect);
                        break;
                    }

                case 2:
                    {
                        if (E_Types.Map.MapEvents[id].GraphicNum < 1 || E_Types.Map.MapEvents[id].GraphicNum > E_Graphics.NumTileSets)
                            return;
                        if (E_Types.Map.MapEvents[id].GraphicY2 > 0 || E_Types.Map.MapEvents[id].GraphicX2 > 0)
                        {
                            {
                                var withBlock = sRect;
                                withBlock.X = E_Types.Map.MapEvents[id].GraphicX * 32;
                                withBlock.Y = E_Types.Map.MapEvents[id].GraphicY * 32;
                                withBlock.Width = E_Types.Map.MapEvents[id].GraphicX2 * 32;
                                withBlock.Height = E_Types.Map.MapEvents[id].GraphicY2 * 32;
                            }
                        }
                        else
                        {
                            var withBlock1 = sRect;
                            withBlock1.X = E_Types.Map.MapEvents[id].GraphicY * 32;
                            withBlock1.Height = withBlock1.Top + 32;
                            withBlock1.Y = E_Types.Map.MapEvents[id].GraphicX * 32;
                            withBlock1.Width = withBlock1.Left + 32;
                        }

                        if (E_Graphics.TileSetTextureInfo[E_Types.Map.MapEvents[id].GraphicNum].IsLoaded == false)
                            E_Graphics.LoadTexture(E_Types.Map.MapEvents[id].GraphicNum, 1);
                        // we use it, lets update timer
                        {
                            var withBlock2 = E_Graphics.TileSetTextureInfo[E_Types.Map.MapEvents[id].GraphicNum];
                            withBlock2.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                        }

                        x = E_Types.Map.MapEvents[id].X * 32;
                        y = E_Types.Map.MapEvents[id].Y * 32;
                        x = x - ((sRect.Right - sRect.Left) / (int)2);
                        y = y - (sRect.Bottom - sRect.Top) + 32;

                        if (E_Types.Map.MapEvents[id].GraphicY2 > 1)
                            E_Graphics.RenderSprite(E_Graphics.TileSetSprite[E_Types.Map.MapEvents[id].GraphicNum], E_Graphics.GameWindow, E_Graphics.ConvertMapX(E_Types.Map.MapEvents[id].X * E_Globals.PIC_X), E_Graphics.ConvertMapY(E_Types.Map.MapEvents[id].Y * E_Globals.PIC_Y) - E_Globals.PIC_Y, sRect.Left, sRect.Top, sRect.Width, sRect.Height);
                        else
                            E_Graphics.RenderSprite(E_Graphics.TileSetSprite[E_Types.Map.MapEvents[id].GraphicNum], E_Graphics.GameWindow, E_Graphics.ConvertMapX(E_Types.Map.MapEvents[id].X * E_Globals.PIC_X), E_Graphics.ConvertMapY(E_Types.Map.MapEvents[id].Y * E_Globals.PIC_Y), sRect.Left, sRect.Top, sRect.Width, sRect.Height);
                        break;
                    }
            }
        }



        internal static string GetColorString(int color)
        {
            switch (color)
            {
                case 0:
                    {
                        return "Black";
                        break;
                    }

                case 1:
                    {
                        return "Blue";
                        break;
                    }

                case 2:
                    {
                        return "Green";
                        break;
                    }

                case 3:
                    {
                        return "Cyan";
                        break;
                    }

                case 4:
                    {
                        return "Red";
                        break;
                    }

                case 5:
                    {
                        return "Magenta";
                        break;
                    }

                case 6:
                    {
                        return "Brown";
                        break;
                    }

                case 7:
                    {
                        return "Grey";
                        break;
                    }

                case 8:
                    {
                        return "Dark Grey";
                        break;
                    }

                case 9:
                    {
                        return "Bright Blue";
                        break;
                    }

                case 10:
                    {
                        return "Bright Green";
                        break;
                    }

                case 11:
                    {
                        return "Bright Cyan";
                        break;
                    }

                case 12:
                    {
                        return "Bright Red";
                        break;
                    }

                case 13:
                    {
                        return "Pink";
                        break;
                    }

                case 14:
                    {
                        return "Yellow";
                        break;
                    }

                case 15:
                    {
                        return "White";
                        break;
                    }

                default:
                    {
                        return "Black";
                        break;
                    }
            }
        }

        internal static void ResetEventdata()
        {
            var loopTo = E_Types.Map.EventCount;
            for (var i = 0; i <= loopTo; i++)
            {
                E_Types.Map.MapEvents = new MapEventRec[E_Types.Map.EventCount + 1];
                E_Types.Map.CurrentEvents = 0;
                {
                    var withBlock = E_Types.Map.MapEvents[i];
                    withBlock.Name = "";
                    withBlock.Dir = 0;
                    withBlock.ShowDir = 0;
                    withBlock.GraphicNum = 0;
                    withBlock.GraphicType = 0;
                    withBlock.GraphicX = 0;
                    withBlock.GraphicX2 = 0;
                    withBlock.GraphicY = 0;
                    withBlock.GraphicY2 = 0;
                    withBlock.MovementSpeed = 0;
                    withBlock.Moving = 0;
                    withBlock.X = 0;
                    withBlock.Y = 0;
                    withBlock.XOffset = 0;
                    withBlock.YOffset = 0;
                    withBlock.Position = 0;
                    withBlock.Visible = 0;
                    withBlock.WalkAnim = 0;
                    withBlock.DirFix = 0;
                    withBlock.WalkThrough = 0;
                    withBlock.ShowName = 0;
                    withBlock.Questnum = 0;
                }
            }
        }
    }
}
