
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using System.Windows.Forms;
using ASFW;
using SFML.Graphics;
using SFML.Window;
using Microsoft.VisualBasic.CompilerServices;
using Engine;


namespace Engine
{
	internal sealed class C_EventSystem
	{
		
#region Globals
		
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
		
		internal static int GraphicSelType; //Are we selecting a graphic for a move route? A page sprite? What??
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
		internal static int AnotherChat; //Determines if another showtext/showchoices is comming up, if so, dont close the event chatbox...
		
		//constants
		internal static string[] Switches = new string[MaxSwitches + 1];
		
		internal static string[] Variables = new string[MaxVariables + 1];
		internal const int MaxSwitches = 500;
		internal const int MaxVariables = 500;
		
		internal static EventRec CpEvent;
		internal static bool EventCopy;
		internal static bool EventPaste;
		internal static EventListRec[] EventList;
		
		internal static bool InEvent;
		internal static bool HoldPlayer;
		internal static bool InitEventEditorForm;
		
#endregion
		
#region Types
		
		public struct EventCommandRec
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
		
		public struct MoveRouteRec
		{
			public int Index;
			public int Data1;
			public int Data2;
			public int Data3;
			public int Data4;
			public int Data5;
			public int Data6;
		}
		
		public struct CommandListRec
		{
			public int CommandCount;
			public int ParentList;
			public EventCommandRec[] Commands;
		}
		
		public struct ConditionalBranchRec
		{
			public int Condition;
			public int Data1;
			public int Data2;
			public int Data3;
			public int CommandList;
			public int ElseCommandList;
		}
		
		public struct EventPageRec
		{
			
			//These are condition variables that decide if the event even appears to the player.
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
			//End Conditions
			
			//Handles the Event Sprite
			public byte GraphicType;
			
			public int Graphic;
			public int GraphicX;
			public int GraphicY;
			public int GraphicX2;
			public int GraphicY2;
			
			//Handles Movement - Move Routes to come soon.
			public byte MoveType;
			
			public byte MoveSpeed;
			public byte MoveFreq;
			public int MoveRouteCount;
			public MoveRouteRec[] MoveRoute;
			public int IgnoreMoveRoute;
			public int RepeatMoveRoute;
			
			//Guidelines for the event
			public byte WalkAnim;
			
			public byte DirFix;
			public byte WalkThrough;
			public byte ShowName;
			
			//Trigger for the event
			public byte Trigger;
			
			//Commands for the event
			public int CommandListCount;
			
			public CommandListRec[] CommandList;
			public byte Position;
			public int Questnum;
			
			//Client Needed Only
			public int X;
			
			public int Y;
		}
		
		public struct EventRec
		{
			public string Name;
			public int Globals;
			public int PageCount;
			public EventPageRec[] Pages;
			public int X;
			public int Y;
		}
		
		public struct MapEventRec
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
		
		public struct EventListRec
		{
			public int CommandList;
			public int CommandNum;
		}
		
#endregion
		
#region Enums
		
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
			
			//Etc...
			EvCustomScript,
			
			EvSetAccess,
			
			//Shop/Bank
			EvOpenBank,
			EvOpenShop,
			EvOpenAuction,
			
			//New
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
		
#endregion
		
#region EventEditor
		
		//Event Editor Stuffz Also includes event functions from the map editor (copy/paste/delete)
		
		public static void CopyEvent_Map(int X, int Y)
		{
			int count = 0;
			int i = 0;
			
			count = C_Maps.Map.EventCount;
			if (count == 0)
			{
				return;
			}
			for (i = 1; i <= count; i++)
			{
				if (C_Maps.Map.Events[i].X == X && C_Maps.Map.Events[i].Y == Y)
				{
					// copy it
					CopyEvent = C_Maps.Map.Events[i];
					
					// exit
					return;
				}
			}
			
		}
		
		public static void PasteEvent_Map(int X, int Y)
		{
			int count = 0;
			int i = 0;
			int EventNum = 0;
			
			count = C_Maps.Map.EventCount;
			if (count > 0)
			{
				for (i = 1; i <= count; i++)
				{
					if (C_Maps.Map.Events[i].X == X && C_Maps.Map.Events[i].Y == Y)
					{
						// already an event - paste over it
						EventNum = i;
					}
				}
			}
			
			// couldn't find one - create one
			if (EventNum == 0)
			{
				// increment count
				AddEvent(X, Y, true);
				EventNum = count + 1;
			}
			
			// copy it
			C_Maps.Map.Events[EventNum] = CopyEvent;
			// set position
			C_Maps.Map.Events[EventNum].X = X;
			C_Maps.Map.Events[EventNum].Y = Y;
			
		}
		
		public static void DeleteEvent(int X, int Y)
		{
			int count = 0;
			int i = 0;
			int lowIndex = 0;
			
			if (!C_Constants.InMapEditor)
			{
				return;
			}
			if (FrmEditor_Events.Default.Visible == true)
			{
				return;
			}
			
			count = C_Maps.Map.EventCount;
			for (i = 1; i <= count; i++)
			{
				if (C_Maps.Map.Events[i].X == X && C_Maps.Map.Events[i].Y == Y)
				{
					// delete it
					ClearEvent(i);
					lowIndex = i;
					break;
				}
			}
			// not found anything
			if (lowIndex == 0)
			{
				return;
			}
			// move everything down an index
			for (i = lowIndex; i <= count - 1; i++)
			{
				C_Maps.Map.Events[i] = C_Maps.Map.Events[i + 1];
			}
			// delete the last index
			ClearEvent(count);
			// set the new count
			C_Maps.Map.EventCount = count - 1;
			C_Maps.Map.CurrentEvents = count - 1;
			
		}
		
		public static void AddEvent(int X, int Y, bool cancelLoad = false)
		{
			int count = 0;
			int pageCount = 0;
			int i = 0;
			
			count = C_Maps.Map.EventCount + 1;
			// make sure there's not already an event
			if (count - 1 > 0)
			{
				for (i = 1; i <= count - 1; i++)
				{
					if (C_Maps.Map.Events[i].X == X && C_Maps.Map.Events[i].Y == Y)
					{
						// already an event - edit it
						if (!cancelLoad)
						{
							EventEditorInit(i);
						}
						return;
					}
				}
			}
			// increment count
			C_Maps.Map.EventCount = count;
			Array.Resize(ref C_Maps.Map.Events, count + 1);
			// set the new event
			C_Maps.Map.Events[count].X = X;
			C_Maps.Map.Events[count].Y = Y;
			// give it a new page
			pageCount = C_Maps.Map.Events[count].PageCount + 1;
			C_Maps.Map.Events[count].PageCount = pageCount;
			Array.Resize(ref C_Maps.Map.Events[count].Pages, pageCount + 1);
			// load the editor
			if (!cancelLoad)
			{
				EventEditorInit(count);
			}
			
		}
		
		public static void ClearEvent(int EventNum)
		{
			if (EventNum > C_Maps.Map.EventCount || EventNum > (C_Maps.Map.MapEvents.Length - 1))
			{
				return;
			}
			ref var with_1 = ref C_Maps.Map.Events[EventNum];
			with_1.Name = "";
			with_1.PageCount = 0;
			with_1.Pages = new EventPageRec[1];
			with_1.Globals = 0;
			with_1.X = 0;
			with_1.Y = 0;
			ref var with_2 = ref C_Maps.Map.MapEvents[EventNum];
			with_2.Name = "";
			with_2.Dir = 0;
			with_2.ShowDir = 0;
			with_2.GraphicNum = 0;
			with_2.GraphicType = 0;
			with_2.GraphicX = 0;
			with_2.GraphicX2 = 0;
			with_2.GraphicY = 0;
			with_2.GraphicY2 = 0;
			with_2.MovementSpeed = 0;
			with_2.Moving = 0;
			with_2.X = 0;
			with_2.Y = 0;
			with_2.XOffset = 0;
			with_2.YOffset = 0;
			with_2.Position = 0;
			with_2.Visible = 0;
			with_2.WalkAnim = 0;
			with_2.DirFix = 0;
			with_2.WalkThrough = 0;
			with_2.ShowName = 0;
			with_2.Questnum = 0;
			
		}
		
		public static void EventEditorInit(int EventNum)
		{
			
			EditorEvent = EventNum;
			
			TmpEvent = C_Maps.Map.Events[EventNum];
			InitEventEditorForm = true;
			
		}
		
		public static void EventEditorLoadPage(int PageNum)
		{
			// populate form
			
			ref var with_1 = ref TmpEvent.Pages[PageNum];
			GraphicSelX = with_1.GraphicX;
			GraphicSelY = with_1.GraphicY;
			GraphicSelX2 = with_1.GraphicX2;
			GraphicSelY2 = with_1.GraphicY2;
			FrmEditor_Events.Default.cmbGraphic.SelectedIndex = with_1.GraphicType;
			FrmEditor_Events.Default.cmbHasItem.SelectedIndex = with_1.HasItemindex;
			if (with_1.HasItemAmount == 0)
			{
				FrmEditor_Events.Default.nudCondition_HasItem.Value = 1;
			}
			else
			{
				FrmEditor_Events.Default.nudCondition_HasItem.Value = with_1.HasItemAmount;
			}
			FrmEditor_Events.Default.cmbMoveFreq.SelectedIndex = with_1.MoveFreq;
			FrmEditor_Events.Default.cmbMoveSpeed.SelectedIndex = with_1.MoveSpeed;
			FrmEditor_Events.Default.cmbMoveType.SelectedIndex = with_1.MoveType;
			FrmEditor_Events.Default.cmbPlayerVar.SelectedIndex = with_1.Variableindex;
			FrmEditor_Events.Default.cmbPlayerSwitch.SelectedIndex = with_1.Switchindex;
			FrmEditor_Events.Default.cmbSelfSwitchCompare.SelectedIndex = with_1.SelfSwitchCompare;
			FrmEditor_Events.Default.cmbPlayerSwitchCompare.SelectedIndex = with_1.SwitchCompare;
			FrmEditor_Events.Default.cmbPlayervarCompare.SelectedIndex = with_1.VariableCompare;
			FrmEditor_Events.Default.chkGlobal.Checked = System.Convert.ToBoolean(TmpEvent.Globals);
			FrmEditor_Events.Default.cmbTrigger.SelectedIndex = with_1.Trigger;
			FrmEditor_Events.Default.chkDirFix.Checked = System.Convert.ToBoolean(with_1.DirFix);
			FrmEditor_Events.Default.chkHasItem.Checked = System.Convert.ToBoolean(with_1.ChkHasItem);
			FrmEditor_Events.Default.chkPlayerVar.Checked = System.Convert.ToBoolean(with_1.ChkVariable);
			FrmEditor_Events.Default.chkPlayerSwitch.Checked = System.Convert.ToBoolean(with_1.ChkSwitch);
			FrmEditor_Events.Default.chkSelfSwitch.Checked = System.Convert.ToBoolean(with_1.ChkSelfSwitch);
			FrmEditor_Events.Default.chkWalkAnim.Checked = System.Convert.ToBoolean(with_1.WalkAnim);
			FrmEditor_Events.Default.chkWalkThrough.Checked = System.Convert.ToBoolean(with_1.WalkThrough);
			FrmEditor_Events.Default.chkShowName.Checked = System.Convert.ToBoolean(with_1.ShowName);
			FrmEditor_Events.Default.nudPlayerVariable.Value = with_1.VariableCondition;
			FrmEditor_Events.Default.nudGraphic.Value = with_1.Graphic;
			if (FrmEditor_Events.Default.cmbEventQuest.Items.Count > 0)
			{
				if (with_1.Questnum >= 0 && with_1.Questnum <= FrmEditor_Events.Default.cmbEventQuest.Items.Count)
				{
					FrmEditor_Events.Default.cmbEventQuest.SelectedIndex = with_1.Questnum;
				}
			}
			if (FrmEditor_Events.Default.cmbEventQuest.SelectedIndex == -1)
			{
				FrmEditor_Events.Default.cmbEventQuest.SelectedIndex = 0;
			}
			if (with_1.ChkHasItem == 0)
			{
				FrmEditor_Events.Default.cmbHasItem.Enabled = false;
			}
			else
			{
				FrmEditor_Events.Default.cmbHasItem.Enabled = true;
			}
			if (with_1.ChkSelfSwitch == 0)
			{
				FrmEditor_Events.Default.cmbSelfSwitch.Enabled = false;
				FrmEditor_Events.Default.cmbSelfSwitchCompare.Enabled = false;
			}
			else
			{
				FrmEditor_Events.Default.cmbSelfSwitch.Enabled = true;
				FrmEditor_Events.Default.cmbSelfSwitchCompare.Enabled = true;
			}
			if (with_1.ChkSwitch == 0)
			{
				FrmEditor_Events.Default.cmbPlayerSwitch.Enabled = false;
				FrmEditor_Events.Default.cmbPlayerSwitchCompare.Enabled = false;
			}
			else
			{
				FrmEditor_Events.Default.cmbPlayerSwitch.Enabled = true;
				FrmEditor_Events.Default.cmbPlayerSwitchCompare.Enabled = true;
			}
			if (with_1.ChkVariable == 0)
			{
				FrmEditor_Events.Default.cmbPlayerVar.Enabled = false;
				FrmEditor_Events.Default.nudPlayerVariable.Enabled = false;
				FrmEditor_Events.Default.cmbPlayervarCompare.Enabled = false;
			}
			else
			{
				FrmEditor_Events.Default.cmbPlayerVar.Enabled = true;
				FrmEditor_Events.Default.nudPlayerVariable.Enabled = true;
				FrmEditor_Events.Default.cmbPlayervarCompare.Enabled = true;
			}
			if (FrmEditor_Events.Default.cmbMoveType.SelectedIndex == 2)
			{
				FrmEditor_Events.Default.btnMoveRoute.Enabled = true;
			}
			else
			{
				FrmEditor_Events.Default.btnMoveRoute.Enabled = false;
			}
			FrmEditor_Events.Default.cmbPositioning.SelectedIndex = with_1.Position;
			// show the commands
			EventListCommands();
			
			EditorEvent_DrawGraphic();
			
		}
		
		public static void EventEditorOK()
		{
			// copy the event data from the temp event
			
			C_Maps.Map.Events[EditorEvent] = TmpEvent;
			// unload the form
			FrmEditor_Events.Default.Dispose();
			
		}
		
		public static void EventListCommands()
		{
			int i = 0;
			int curlist = 0;
			int X = 0;
			string indent = "";
			int[] listleftoff;
			int[] conditionalstage;
			
			FrmEditor_Events.Default.lstCommands.Items.Clear();
			
			if (TmpEvent.Pages[CurPageNum].CommandListCount > 0)
			{
				listleftoff = new int[TmpEvent.Pages[CurPageNum].CommandListCount + 1];
				conditionalstage = new int[TmpEvent.Pages[CurPageNum].CommandListCount + 1];
				//Start Up at 1
				curlist = 1;
				X = -1;
newlist:
				for (i = 1; i <= TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount; i++)
				{
					if (listleftoff[curlist] > 0)
					{
						if ((TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[listleftoff[curlist]].Index == (int) EventType.EvCondition || TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[listleftoff[curlist]].Index == (int) EventType.EvShowChoices) && conditionalstage[curlist] != 0)
						{
							i = listleftoff[curlist];
						}
						else if (listleftoff[curlist] >= i)
						{
							i = listleftoff[curlist] + 1;
						}
					}
					if (i <= TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount)
					{
						if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Index == (int) EventType.EvCondition)
						{
							X++;
							switch (conditionalstage[curlist])
							{
								case 0:
									Array.Resize(ref EventList, X + 1);
									EventList[X].CommandList = curlist;
									EventList[X].CommandNum = i;
									switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Condition)
									{
										case 0:
											switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2)
											{
												case 0:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Variable [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) +". " + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] == " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3));
													break;
												case 1:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Variable [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) +". " + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] >= " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3));
													break;
												case 2:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Variable [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) +". " + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] <= " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3));
													break;
												case 3:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Variable [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) +". " + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] > " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3));
													break;
												case 4:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Variable [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) +". " + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] < " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3));
													break;
												case 5:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Variable [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) +". " + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] != " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3));
													break;
											}
											break;
										case 1:
											if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2 == 0)
											{
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Switch [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) +". " + Switches[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] == " + "True");
											}
											else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2 == 1)
											{
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Switch [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) +". " + Switches[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1] + "] == " + "False");
											}
											break;
										case 2:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Has Item [" + Microsoft.VisualBasic.Strings.Trim(Types.Item[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1].Name) + "] x" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2));
											break;
										case 3:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Class Is [" + Microsoft.VisualBasic.Strings.Trim(Types.Classes[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1].Name) + "]");
											break;
										case 4:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player Knows Skill [" + Microsoft.VisualBasic.Strings.Trim(Types.Skill[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1].Name) + "]");
											break;
										case 5:
											switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2)
											{
												case 0:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Level is == " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1));
													break;
												case 1:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Level is >= " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1));
													break;
												case 2:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Level is <= " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1));
													break;
												case 3:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Level is > " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1));
													break;
												case 4:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Level is < " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1));
													break;
												case 5:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Level is NOT " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1));
													break;
											}
											break;
										case 6:
											if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2 == 0)
											{
												switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1)
												{
													case 0:
														FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [A] == " + "True");
														break;
													case 1:
														FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [B] == " + "True");
														break;
													case 2:
														FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [C] == " + "True");
														break;
													case 3:
														FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [D] == " + "True");
														break;
												}
											}
											else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2 == 1)
											{
												switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1)
												{
													case 0:
														FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [A] == " + "False");
														break;
													case 1:
														FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [B] == " + "False");
														break;
													case 2:
														FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [C] == " + "False");
														break;
													case 3:
														FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Self Switch [D] == " + "False");
														break;
												}
											}
											break;
										case 7:
											if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2 == 0)
											{
												switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3)
												{
													case 0:
														FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Quest [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) + "] not started.");
														break;
													case 1:
														FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Quest [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) + "] is started.");
														break;
													case 2:
														FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Quest [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) + "] is completed.");
														break;
													case 3:
														FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Quest [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) + "] can be started.");
														break;
													case 4:
														FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Quest [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) + "] can be ended. (All tasks complete)");
														break;
												}
											}
											else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data2 == 1)
											{
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Quest [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1) + "] in progress and on task #" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data3));
											}
											break;
										case 8:
											switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1)
											{
												case (int) Enums.SexType.Male:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's Gender is Male");
													break;
												case (int) Enums.SexType.Female:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Player's  Gender is Female");
													break;
											}
											break;
										case 9:
											switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.Data1)
											{
												case (int) Engine.TimeOfDay.Day:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Time of Day is Day");
													break;
												case (int) Engine.TimeOfDay.Night:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Time of Day is Night");
													break;
												case (int) Engine.TimeOfDay.Dawn:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Time of Day is Dawn");
													break;
												case (int) Engine.TimeOfDay.Dusk:
													FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Conditional Branch: Time of Day is Dusk");
													break;
											}
											break;
									}
									indent = indent + "       ";
									listleftoff[curlist] = i;
									conditionalstage[curlist] = 1;
									curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.CommandList;
									goto newlist;
								case 1:
									Array.Resize(ref EventList, X + 1);
									EventList[X].CommandList = curlist;
									EventList[X].CommandNum = 0;
									FrmEditor_Events.Default.lstCommands.Items.Add(indent.Substring(0, indent.Length - 4) + " : " + "Else");
									listleftoff[curlist] = i;
									conditionalstage[curlist] = 2;
									curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].ConditionalBranch.ElseCommandList;
									goto newlist;
								case 2:
									Array.Resize(ref EventList, X + 1);
									EventList[X].CommandList = curlist;
									EventList[X].CommandNum = 0;
									FrmEditor_Events.Default.lstCommands.Items.Add(indent.Substring(0, indent.Length - 4) + " : " + "End Branch");
									indent = indent.Substring(0, indent.Length - 7);
									listleftoff[curlist] = i;
									conditionalstage[curlist] = 0;
									break;
							}
						}
						else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Index == (int) EventType.EvShowChoices)
						{
							X++;
							switch (conditionalstage[curlist])
							{
								case 0:
									Array.Resize(ref EventList, X + 1);
									EventList[X].CommandList = curlist;
									EventList[X].CommandNum = i;
									if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data5 > 0)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Show Choices - Prompt: " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) +"... - Face: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data5));
									}
									else
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Show Choices - Prompt: " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) +"... - No Face");
									}
									indent = indent + "       ";
									listleftoff[curlist] = i;
									conditionalstage[curlist] = 1;
									goto newlist;
								case 1:
									if (Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text2) != "")
									{
										Array.Resize(ref EventList, X + 1);
										EventList[X].CommandList = curlist;
										EventList[X].CommandNum = 0;
										FrmEditor_Events.Default.lstCommands.Items.Add(indent.Substring(0, indent.Length - 4) + " : " + "When [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text2) + "]");
										listleftoff[curlist] = i;
										conditionalstage[curlist] = 2;
										curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1;
										goto newlist;
									}
									else
									{
										X--;
										listleftoff[curlist] = i;
										conditionalstage[curlist] = 2;
										curlist = curlist;
										goto newlist;
									}
									break;
								case 2:
									if (Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text3) != "")
									{
										Array.Resize(ref EventList, X + 1);
										EventList[X].CommandList = curlist;
										EventList[X].CommandNum = 0;
										FrmEditor_Events.Default.lstCommands.Items.Add(indent.Substring(0, indent.Length - 4) + " : " + "When [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text3) + "]");
										listleftoff[curlist] = i;
										conditionalstage[curlist] = 3;
										curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2;
										goto newlist;
									}
									else
									{
										X--;
										listleftoff[curlist] = i;
										conditionalstage[curlist] = 3;
										curlist = curlist;
										goto newlist;
									}
									break;
								case 3:
									if (Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text4) != "")
									{
										Array.Resize(ref EventList, X + 1);
										EventList[X].CommandList = curlist;
										EventList[X].CommandNum = 0;
										FrmEditor_Events.Default.lstCommands.Items.Add(indent.Substring(0, indent.Length - 4) + " : " + "When [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text4) + "]");
										listleftoff[curlist] = i;
										conditionalstage[curlist] = 4;
										curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3;
										goto newlist;
									}
									else
									{
										X--;
										listleftoff[curlist] = i;
										conditionalstage[curlist] = 4;
										curlist = curlist;
										goto newlist;
									}
									break;
								case 4:
									if (Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text5) != "")
									{
										Array.Resize(ref EventList, X + 1);
										EventList[X].CommandList = curlist;
										EventList[X].CommandNum = 0;
										FrmEditor_Events.Default.lstCommands.Items.Add(indent.Substring(0, indent.Length - 4) + " : " + "When [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text5) + "]");
										listleftoff[curlist] = i;
										conditionalstage[curlist] = 5;
										curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4;
										goto newlist;
									}
									else
									{
										X--;
										listleftoff[curlist] = i;
										conditionalstage[curlist] = 5;
										curlist = curlist;
										goto newlist;
									}
									break;
								case 5:
									Array.Resize(ref EventList, X + 1);
									EventList[X].CommandList = curlist;
									EventList[X].CommandNum = 0;
									FrmEditor_Events.Default.lstCommands.Items.Add(indent.Substring(0, indent.Length - 4) + " : " + "Branch End");
									indent = indent.Substring(0, indent.Length - 7);
									listleftoff[curlist] = i;
									conditionalstage[curlist] = 0;
									break;
							}
						}
						else
						{
							X++;
							Array.Resize(ref EventList, X + 1);
							EventList[X].CommandList = curlist;
							EventList[X].CommandNum = i;
							switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Index)
							{
								case (int) EventType.EvAddText:
									switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2)
									{
										case 0:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Add Text - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) +"... - Color: " + System.Convert.ToString(GetColorString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)) + " - Chat Type: Player");
											break;
										case 1:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Add Text - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) +"... - Color: " + System.Convert.ToString(GetColorString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)) + " - Chat Type: Map");
											break;
										case 2:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Add Text - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) +"... - Color: " + System.Convert.ToString(GetColorString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)) + " - Chat Type: Global");
											break;
									}
									break;
								case (int) EventType.EvShowText:
									if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 == 0)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Show Text - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) +"... - No Face");
									}
									else
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Show Text - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) +"... - Face: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1));
									}
									break;
								case (int) EventType.EvPlayerVar:
									switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2)
									{
										case 0:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player Variable [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] + "] == " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3));
											break;
										case 1:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player Variable [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] + "] + " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3));
											break;
										case 2:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player Variable [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] + "] - " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3));
											break;
										case 3:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player Variable [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + Variables[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] + "] Random Between " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + " and " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4));
											break;
									}
									break;
								case (int) EventType.EvPlayerSwitch:
									if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player Switch [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) +". " + Switches[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] + "] == True");
									}
									else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player Switch [" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) +". " + Switches[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] + "] == False");
									}
									break;
								case (int) EventType.EvSelfSwitch:
									switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)
									{
										case 0:
											if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
											{
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [A] to ON");
											}
											else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
											{
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [A] to OFF");
											}
											break;
										case 1:
											if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
											{
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [B] to ON");
											}
											else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
											{
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [B] to OFF");
											}
											break;
										case 2:
											if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
											{
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [C] to ON");
											}
											else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
											{
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [C] to OFF");
											}
											break;
										case 3:
											if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
											{
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [D] to ON");
											}
											else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
											{
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Self Switch [D] to OFF");
											}
											break;
									}
									break;
								case (int) EventType.EvExitProcess:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Exit Event Processing");
									break;
								case (int) EventType.EvChangeItems:
									if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Item Amount of [" + Microsoft.VisualBasic.Strings.Trim(Types.Item[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "] to " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3));
									}
									else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Give Player " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + " " + Microsoft.VisualBasic.Strings.Trim(Types.Item[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "(s)");
									}
									else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 2)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Take " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + " " + Microsoft.VisualBasic.Strings.Trim(Types.Item[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "(s) from Player.");
									}
									break;
								case (int) EventType.EvRestoreHp:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Restore Player HP");
									break;
								case (int) EventType.EvRestoreMp:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Restore Player MP");
									break;
								case (int) EventType.EvLevelUp:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Level Up Player");
									break;
								case (int) EventType.EvChangeLevel:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player Level to " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1));
									break;
								case (int) EventType.EvChangeSkills:
									if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Teach Player Skill [" + Microsoft.VisualBasic.Strings.Trim(Types.Skill[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]");
									}
									else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Remove Player Skill [" + Microsoft.VisualBasic.Strings.Trim(Types.Skill[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]");
									}
									break;
								case (int) EventType.EvChangeClass:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player Class to " + Microsoft.VisualBasic.Strings.Trim(Types.Classes[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name));
									break;
								case (int) EventType.EvChangeSprite:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player Sprite to " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1));
									break;
								case (int) EventType.EvChangeSex:
									if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 == 0)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player Sex to Male.");
									}
									else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 == 1)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player Sex to Female.");
									}
									break;
								case (int) EventType.EvChangePk:
									if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 == 0)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player PK to No.");
									}
									else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 == 1)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player PK to Yes.");
									}
									break;
								case (int) EventType.EvWarpPlayer:
									if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4 == 0)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Warp Player To Map: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " Tile(" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "," + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + ") while retaining direction.");
									}
									else
									{
										switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4 - 1)
										{
											case (System.Int32) Enums.DirectionType.Up:
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Warp Player To Map: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " Tile(" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "," + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + ") facing upward.");
												break;
											case (System.Int32) Enums.DirectionType.Down:
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Warp Player To Map: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " Tile(" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "," + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + ") facing downward.");
												break;
											case (System.Int32) Enums.DirectionType.Left:
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Warp Player To Map: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " Tile(" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "," + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + ") facing left.");
												break;
											case (System.Int32) Enums.DirectionType.Right:
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Warp Player To Map: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " Tile(" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "," + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + ") facing right.");
												break;
										}
									}
									break;
								case (int) EventType.EvSetMoveRoute:
									if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 <= C_Maps.Map.EventCount)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Move Route for Event #" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " [" + Microsoft.VisualBasic.Strings.Trim(C_Maps.Map.Events[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]");
									}
									else
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Move Route for COULD NOT FIND EVENT!");
									}
									break;
								case (int) EventType.EvPlayAnimation:
									if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 0)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Play Animation " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " [" + Microsoft.VisualBasic.Strings.Trim(Types.Animation[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]" + " on Player");
									}
									else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 1)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Play Animation " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " [" + Microsoft.VisualBasic.Strings.Trim(Types.Animation[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]" + " on Event #" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + " [" + Microsoft.VisualBasic.Strings.Trim(C_Maps.Map.Events[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3].Name) + "]");
									}
									else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2 == 2)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Play Animation " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " [" + Microsoft.VisualBasic.Strings.Trim(Types.Animation[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]" + " on Tile(" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + "," + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4) + ")");
									}
									break;
								case (int) EventType.EvCustomScript:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Execute Custom Script Case: " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1));
									break;
								case (int) EventType.EvPlayBgm:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Play BGM [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1) + "]");
									break;
								case (int) EventType.EvFadeoutBgm:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Fadeout BGM");
									break;
								case (int) EventType.EvPlaySound:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Play Sound [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1) + "]");
									break;
								case (int) EventType.EvStopSound:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Stop Sound");
									break;
								case (int) EventType.EvOpenBank:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Open Bank");
                                    break;
                                case (int) EventType.EvOpenAuction:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Open Auction");
									break;
								case (int) EventType.EvOpenMail:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Open Mail Box");
									break;
								case (int) EventType.EvOpenShop:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Open Shop [" + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)+". " + Microsoft.VisualBasic.Strings.Trim(Types.Shop[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "]");
									break;
								case (int) EventType.EvSetAccess:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Player Access [" + System.Convert.ToString(FrmEditor_Events.Default.cmbSetAccess.Items[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1]) + "]");
									break;
								case (int) EventType.EvGiveExp:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Give Player " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " Experience.");
									break;
								case (int) EventType.EvShowChatBubble:
									switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)
									{
										case (int) Enums.TargetType.Player:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Show Chat Bubble - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) +"... - On Player");
											break;
										case (int) Enums.TargetType.Npc:
											if (C_Maps.Map.Npc[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2] <= 0)
											{
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Show Chat Bubble - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) +"... - On NPC [" + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2)+". ]");
											}
											else
											{
												FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Show Chat Bubble - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) +"... - On NPC [" + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2)+". " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[C_Maps.Map.Npc[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2]].Name) + "]");
											}
											break;
										case (int) Enums.TargetType.Event:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Show Chat Bubble - " + Microsoft.VisualBasic.Strings.Mid(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1, 1, 20) +"... - On Event [" + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2)+". " + Microsoft.VisualBasic.Strings.Trim(C_Maps.Map.Events[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2].Name) + "]");
											break;
									}
									break;
								case (int) EventType.EvLabel:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Label: [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1) + "]");
									break;
								case (int) EventType.EvGotoLabel:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Jump to Label: [" + Microsoft.VisualBasic.Strings.Trim(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Text1) + "]");
									break;
								case (int) EventType.EvSpawnNpc:
									if (C_Maps.Map.Npc[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1] <= 0)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Spawn NPC: [" + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)+". " + "]");
									}
									else
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Spawn NPC: [" + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)+". " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[C_Maps.Map.Npc[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1]].Name) + "]");
									}
									break;
								case (int) EventType.EvFadeIn:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Fade In");
									break;
								case (int) EventType.EvFadeOut:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Fade Out");
									break;
								case (int) EventType.EvFlashWhite:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Flash White");
									break;
								case (int) EventType.EvSetFog:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Fog [Fog: " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " Speed: " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + " Opacity: " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + "]");
									break;
								case (int) EventType.EvSetWeather:
									switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)
									{
										case (int) Enums.WeatherType.None:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Weather [None]");
											break;
										case (int) Enums.WeatherType.Rain:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Weather [Rain - Intensity: " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "]");
											break;
										case (int) Enums.WeatherType.Snow:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Weather [Snow - Intensity: " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "]");
											break;
										case (int) Enums.WeatherType.Sandstorm:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Weather [Sand Storm - Intensity: " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "]");
											break;
										case (int) Enums.WeatherType.Storm:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Weather [Storm - Intensity: " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "]");
											break;
									}
									break;
								case (int) EventType.EvSetTint:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Set Map Tint RGBA [" + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + "," + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + "," + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3) + "," + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4) + "]");
									break;
								case (int) EventType.EvWait:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Wait " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " Ms");
									break;
								case (int) EventType.EvBeginQuest:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Begin Quest: " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)+". " + Microsoft.VisualBasic.Strings.Trim(C_Quest.Quest[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name));
									break;
								case (int) EventType.EvEndQuest:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "End Quest: " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)+". " + Microsoft.VisualBasic.Strings.Trim(C_Quest.Quest[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name));
									break;
								case (int) EventType.EvQuestTask:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Complete Quest Task: " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1)+". " + Microsoft.VisualBasic.Strings.Trim(C_Quest.Quest[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + " - Task# " + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2));
									break;
								case (int) EventType.EvShowPicture:
									switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data3)
									{
										case 1:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Show Picture " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + 1) + ": Pic=" + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + " Top Left, X: " + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4) + " Y: " + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data5));
											break;
										case 2:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Show Picture " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + 1) + ": Pic=" + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + " Center Screen, X: " + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4) + " Y: " + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data5));
											break;
										case 3:
											FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Show Picture " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + 1) + ": Pic=" + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data2) + " On Player, X: " + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data4) + " Y: " + Conversion.Str(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data5));
											break;
									}
									break;
								case (int) EventType.EvHidePicture:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Hide Picture " + Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 + 1));
									break;
								case (int) EventType.EvWaitMovement:
									if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1 <= C_Maps.Map.EventCount)
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Wait for Event #" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1) + " [" + Microsoft.VisualBasic.Strings.Trim(C_Maps.Map.Events[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i].Data1].Name) + "] to complete move route.");
									}
									else
									{
										FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Wait for COULD NOT FIND EVENT to complete move route.");
									}
									break;
								case (int) EventType.EvHoldPlayer:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Hold Player [Do not allow player to move.]");
									break;
								case (int) EventType.EvReleasePlayer:
									FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@>" + "Release Player [Allow player to turn and move again.]");
									break;
								default:
									//Ghost
									X--;
									if (X == -1)
									{
										EventList = new C_EventSystem.EventListRec[1];
									}
									else
									{
										Array.Resize(ref EventList, X + 1);
									}
									break;
							}
						}
					}
				}
				if (curlist > 1)
				{
					X++;
					Array.Resize(ref EventList, X + 1);
					EventList[X].CommandList = curlist;
					EventList[X].CommandNum = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount + 1;
					FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@> ");
					curlist = TmpEvent.Pages[CurPageNum].CommandList[curlist].ParentList;
					goto newlist;
				}
			}
			FrmEditor_Events.Default.lstCommands.Items.Add(indent + "@> ");
			
			int z = 0;
			X = 0;
			for (i = 0; i <= FrmEditor_Events.Default.lstCommands.Items.Count - 1; i++)
			{
				if (X > z)
				{
					z = X;
				}
			}
			
		}
		
		public static void AddCommand(int Index)
		{
			int curlist = 0;
			int i = 0;
			int X = 0;
			int curslot = 0;
			int p = 0;
			CommandListRec oldCommandList = new CommandListRec();
			
			if (TmpEvent.Pages[CurPageNum].CommandListCount == 0)
			{
				TmpEvent.Pages[CurPageNum].CommandListCount = 1;
				TmpEvent.Pages[CurPageNum].CommandList = new C_EventSystem.CommandListRec[2];
			}
			
			if (FrmEditor_Events.Default.lstCommands.SelectedIndex == FrmEditor_Events.Default.lstCommands.Items.Count - 1)
			{
				curlist = 1;
			}
			else
			{
				curlist = EventList[FrmEditor_Events.Default.lstCommands.SelectedIndex].CommandList;
			}
			if (TmpEvent.Pages[CurPageNum].CommandListCount == 0)
			{
				TmpEvent.Pages[CurPageNum].CommandListCount = 1;
				TmpEvent.Pages[CurPageNum].CommandList = new C_EventSystem.CommandListRec[curlist + 1];
			}
			oldCommandList = TmpEvent.Pages[CurPageNum].CommandList[curlist];
			TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount + 1;
			p = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount;
			if (p <= 0)
			{
				TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands = new C_EventSystem.EventCommandRec[1];
			}
			else
			{
				TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands = new C_EventSystem.EventCommandRec[p + 1];
				TmpEvent.Pages[CurPageNum].CommandList[curlist].ParentList = oldCommandList.ParentList;
				TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount = p;
				for (i = 1; i <= p - 1; i++)
				{
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[i] = oldCommandList.Commands[i];
				}
			}
			if (FrmEditor_Events.Default.lstCommands.SelectedIndex == FrmEditor_Events.Default.lstCommands.Items.Count - 1)
			{
				curslot = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount;
			}
			else
			{
				i = EventList[FrmEditor_Events.Default.lstCommands.SelectedIndex].CommandNum;
				if (i < TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount)
				{
					for (X = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount - 1; X >= i; X--)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[X + 1] = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[X];
					}
					curslot = EventList[FrmEditor_Events.Default.lstCommands.SelectedIndex].CommandNum;
				}
				else
				{
					curslot = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount;
				}
			}
			
			switch (Index)
			{
				case (int) EventType.EvAddText:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = FrmEditor_Events.Default.txtAddText_Text.Text;
					//tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlAddText_Colour.Value
					if (FrmEditor_Events.Default.optAddText_Player.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
					}
					else if (FrmEditor_Events.Default.optAddText_Map.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
					}
					else if (FrmEditor_Events.Default.optAddText_Global.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 2;
					}
					break;
				case (int) EventType.EvCondition:
					//This is the part where the whole entire source goes to hell :D
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandListCount = TmpEvent.Pages[CurPageNum].CommandListCount + 2;
					Array.Resize(ref TmpEvent.Pages[CurPageNum].CommandList, TmpEvent.Pages[CurPageNum].CommandListCount + 1);
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.CommandList = TmpEvent.Pages[CurPageNum].CommandListCount - 1;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.ElseCommandList = TmpEvent.Pages[CurPageNum].CommandListCount;
					TmpEvent.Pages[CurPageNum].CommandList[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.CommandList].ParentList = curlist;
					TmpEvent.Pages[CurPageNum].CommandList[TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.ElseCommandList].ParentList = curlist;
					
					if (FrmEditor_Events.Default.optCondition0.Checked == true)
					{
						X = 0;
					}
					if (FrmEditor_Events.Default.optCondition1.Checked == true)
					{
						X = 1;
					}
					if (FrmEditor_Events.Default.optCondition2.Checked == true)
					{
						X = 2;
					}
					if (FrmEditor_Events.Default.optCondition3.Checked == true)
					{
						X = 3;
					}
					if (FrmEditor_Events.Default.optCondition4.Checked == true)
					{
						X = 4;
					}
					if (FrmEditor_Events.Default.optCondition5.Checked == true)
					{
						X = 5;
					}
					if (FrmEditor_Events.Default.optCondition6.Checked == true)
					{
						X = 6;
					}
					if (FrmEditor_Events.Default.optCondition7.Checked == true)
					{
						X = 7;
					}
					if (FrmEditor_Events.Default.optCondition8.Checked == true)
					{
						X = 8;
					}
					if (FrmEditor_Events.Default.optCondition9.Checked == true)
					{
						X = 9;
					}
					
					switch (X)
					{
						case 0: //Player Var
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 0;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_PlayerVarIndex.SelectedIndex + 1;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = FrmEditor_Events.Default.cmbCondition_PlayerVarCompare.SelectedIndex;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3 = (int) FrmEditor_Events.Default.nudCondition_PlayerVarCondition.Value;
							break;
						case 1: //Player Switch
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 1;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_PlayerSwitch.SelectedIndex + 1;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = FrmEditor_Events.Default.cmbCondtion_PlayerSwitchCondition.SelectedIndex;
							break;
						case 2: //Has Item
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 2;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_HasItem.SelectedIndex + 1;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = (int) FrmEditor_Events.Default.nudCondition_HasItem.Value;
							break;
						case 3: //Class Is
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 3;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_ClassIs.SelectedIndex + 1;
							break;
						case 4: //Learnt Skill
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 4;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_LearntSkill.SelectedIndex + 1;
							break;
						case 5: //Level Is
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 5;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int) FrmEditor_Events.Default.nudCondition_LevelAmount.Value;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = FrmEditor_Events.Default.cmbCondition_LevelCompare.SelectedIndex;
							break;
						case 6: //Self Switch
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 6;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_SelfSwitch.SelectedIndex;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = FrmEditor_Events.Default.cmbCondition_SelfSwitchCondition.SelectedIndex;
							break;
						case 7: //Quest Shiz
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 7;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int) FrmEditor_Events.Default.nudCondition_Quest.Value;
							if (FrmEditor_Events.Default.optCondition_Quest0.Checked)
							{
								TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = 0;
								TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3 = FrmEditor_Events.Default.cmbCondition_General.SelectedIndex;
							}
							else
							{
								TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = 1;
								TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3 = (int) FrmEditor_Events.Default.nudCondition_QuestTask.Value;
							}
							break;
						case 8: //Gender
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 8;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_Gender.SelectedIndex;
							break;
						case 9: //Time
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 9;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_Time.SelectedIndex;
							break;
					}
					break;
					
				case (int) EventType.EvShowText:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					string tmptxt = "";
					for (i = 0; i <= (FrmEditor_Events.Default.txtShowText.Lines.Length - 1); i++)
					{
						tmptxt = tmptxt + System.Convert.ToString(FrmEditor_Events.Default.txtShowText.Lines[i]);
					}
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = tmptxt;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudShowTextFace.Value;
					break;
					
				case (int) EventType.EvShowChoices:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = FrmEditor_Events.Default.txtChoicePrompt.Text;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text2 = FrmEditor_Events.Default.txtChoices1.Text;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text3 = FrmEditor_Events.Default.txtChoices2.Text;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text4 = FrmEditor_Events.Default.txtChoices3.Text;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text5 = FrmEditor_Events.Default.txtChoices4.Text;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data5 = (int) FrmEditor_Events.Default.nudShowChoicesFace.Value;
					TmpEvent.Pages[CurPageNum].CommandListCount = TmpEvent.Pages[CurPageNum].CommandListCount + 4;
					Array.Resize(ref TmpEvent.Pages[CurPageNum].CommandList, TmpEvent.Pages[CurPageNum].CommandListCount + 1);
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = TmpEvent.Pages[CurPageNum].CommandListCount - 3;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = TmpEvent.Pages[CurPageNum].CommandListCount - 2;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = TmpEvent.Pages[CurPageNum].CommandListCount - 1;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = TmpEvent.Pages[CurPageNum].CommandListCount;
					TmpEvent.Pages[CurPageNum].CommandList[TmpEvent.Pages[CurPageNum].CommandListCount - 3].ParentList = curlist;
					TmpEvent.Pages[CurPageNum].CommandList[TmpEvent.Pages[CurPageNum].CommandListCount - 2].ParentList = curlist;
					TmpEvent.Pages[CurPageNum].CommandList[TmpEvent.Pages[CurPageNum].CommandListCount - 1].ParentList = curlist;
					TmpEvent.Pages[CurPageNum].CommandList[TmpEvent.Pages[CurPageNum].CommandListCount].ParentList = curlist;
					break;
					
				case (int) EventType.EvPlayerVar:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbVariable.SelectedIndex + 1;
					
					if (FrmEditor_Events.Default.optVariableAction0.Checked == true)
					{
						i = 0;
					}
					if (FrmEditor_Events.Default.optVariableAction1.Checked == true)
					{
						i = 1;
					}
					if (FrmEditor_Events.Default.optVariableAction2.Checked == true)
					{
						i = 2;
					}
					if (FrmEditor_Events.Default.optVariableAction3.Checked == true)
					{
						i = 3;
					}
					
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = i;
					if (i == 3)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudVariableData3.Value;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int) FrmEditor_Events.Default.nudVariableData4.Value;
					}
					else if (i == 0)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudVariableData0.Value;
					}
					else if (i == 1)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudVariableData1.Value;
					}
					else if (i == 2)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudVariableData2.Value;
					}
					break;
					
				case (int) EventType.EvPlayerSwitch:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbSwitch.SelectedIndex + 1;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = FrmEditor_Events.Default.cmbPlayerSwitchSet.SelectedIndex;
					break;
					
				case (int) EventType.EvSelfSwitch:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbSetSelfSwitch.SelectedIndex;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = FrmEditor_Events.Default.cmbSetSelfSwitchTo.SelectedIndex;
					break;
					
				case (int) EventType.EvExitProcess:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
					
				case (int) EventType.EvChangeItems:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbChangeItemIndex.SelectedIndex + 1;
					if (FrmEditor_Events.Default.optChangeItemSet.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
					}
					else if (FrmEditor_Events.Default.optChangeItemAdd.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
					}
					else if (FrmEditor_Events.Default.optChangeItemRemove.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 2;
					}
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudChangeItemsAmount.Value;
					break;
					
				case (int) EventType.EvRestoreHp:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
					
				case (int) EventType.EvRestoreMp:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
					
				case (int) EventType.EvLevelUp:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
					
				case (int) EventType.EvChangeLevel:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudChangeLevel.Value;
					break;
					
				case (int) EventType.EvChangeSkills:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbChangeSkills.SelectedIndex + 1;
					if (FrmEditor_Events.Default.optChangeSkillsAdd.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
					}
					else if (FrmEditor_Events.Default.optChangeSkillsRemove.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
					}
					break;
					
				case (int) EventType.EvChangeClass:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbChangeClass.SelectedIndex + 1;
					break;
					
				case (int) EventType.EvChangeSprite:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudChangeSprite.Value;
					break;
					
				case (int) EventType.EvChangeSex:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					if (FrmEditor_Events.Default.optChangeSexMale.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = 0;
					}
					else if (FrmEditor_Events.Default.optChangeSexFemale.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = 1;
					}
					break;
					
				case (int) EventType.EvChangePk:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbSetPK.SelectedIndex;
					break;
					
				case (int) EventType.EvWarpPlayer:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudWPMap.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int) FrmEditor_Events.Default.nudWPX.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudWPY.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = FrmEditor_Events.Default.cmbWarpPlayerDir.SelectedIndex;
					break;
					
				case (int) EventType.EvSetMoveRoute:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = ListOfEvents[FrmEditor_Events.Default.cmbEvent.SelectedIndex];
					if (FrmEditor_Events.Default.chkIgnoreMove.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
					}
					else
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
					}
					
					if (FrmEditor_Events.Default.chkRepeatRoute.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = 1;
					}
					else
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = 0;
					}
					
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].MoveRouteCount = TempMoveRouteCount;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].MoveRoute = TempMoveRoute;
					break;
					
				case (int) EventType.EvPlayAnimation:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbPlayAnim.SelectedIndex + 1;
					if (FrmEditor_Events.Default.cmbAnimTargetType.SelectedIndex == 0)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
					}
					else if (FrmEditor_Events.Default.cmbAnimTargetType.SelectedIndex == 1)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = FrmEditor_Events.Default.cmbPlayAnimEvent.SelectedIndex + 1;
					}
					else if (FrmEditor_Events.Default.cmbAnimTargetType.SelectedIndex == 2 == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 2;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudPlayAnimTileX.Value;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int) FrmEditor_Events.Default.nudPlayAnimTileY.Value;
					}
					break;
					
				case (int) EventType.EvCustomScript:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudCustomScript.Value;
					break;
					
				case (int) EventType.EvPlayBgm:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = C_Sound.MusicCache[FrmEditor_Events.Default.cmbPlayBGM.SelectedIndex + 1];
					break;
					
				case (int) EventType.EvFadeoutBgm:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
					
				case (int) EventType.EvPlaySound:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = C_Sound.SoundCache[FrmEditor_Events.Default.cmbPlaySound.SelectedIndex + 1];
					break;
					
				case (int) EventType.EvStopSound:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
					
				case (int) EventType.EvOpenBank:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
                case (int) EventType.EvOpenAuction:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
					
				case (int) EventType.EvOpenMail:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
					
				case (int) EventType.EvOpenShop:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbOpenShop.SelectedIndex + 1;
					break;
					
				case (int) EventType.EvSetAccess:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbSetAccess.SelectedIndex;
					break;
					
				case (int) EventType.EvGiveExp:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudGiveExp.Value;
					break;
					
				case (int) EventType.EvShowChatBubble:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = FrmEditor_Events.Default.txtChatbubbleText.Text;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbChatBubbleTargetType.SelectedIndex + 1;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = FrmEditor_Events.Default.cmbChatBubbleTarget.SelectedIndex + 1;
					break;
					
				case (int) EventType.EvLabel:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = FrmEditor_Events.Default.txtLabelName.Text;
					break;
					
				case (int) EventType.EvGotoLabel:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = FrmEditor_Events.Default.txtGotoLabel.Text;
					break;
					
				case (int) EventType.EvSpawnNpc:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbSpawnNpc.SelectedIndex + 1;
					break;
					
				case (int) EventType.EvFadeIn:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
					
				case (int) EventType.EvFadeOut:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
					
				case (int) EventType.EvFlashWhite:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
					
				case (int) EventType.EvSetFog:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudFogData0.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int) FrmEditor_Events.Default.nudFogData1.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudFogData2.Value;
					break;
					
				case (int) EventType.EvSetWeather:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.CmbWeather.SelectedIndex;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int) FrmEditor_Events.Default.nudWeatherIntensity.Value;
					break;
					
				case (int) EventType.EvSetTint:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudMapTintData0.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int) FrmEditor_Events.Default.nudMapTintData1.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudMapTintData2.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int) FrmEditor_Events.Default.nudMapTintData3.Value;
					break;
					
				case (int) EventType.EvWait:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudWaitAmount.Value;
					break;
					
				case (int) EventType.EvBeginQuest:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbBeginQuest.SelectedIndex + 1;
					break;
					
				case (int) EventType.EvEndQuest:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbEndQuest.SelectedIndex + 1;
					break;
					
				case (int) EventType.EvQuestTask:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbCompleteQuest.SelectedIndex;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int) FrmEditor_Events.Default.nudCompleteQuestTask.Value;
					break;
					
				case (int) EventType.EvShowPicture:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbPicIndex.SelectedIndex;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int) FrmEditor_Events.Default.nudShowPicture.Value;
					
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = FrmEditor_Events.Default.cmbPicLoc.SelectedIndex + 1;
					
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int) FrmEditor_Events.Default.nudPicOffsetX.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data5 = (int) FrmEditor_Events.Default.nudPicOffsetY.Value;
					break;
					
				case (int) EventType.EvHidePicture:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudHidePic.Value;
					break;
					
				case (int) EventType.EvWaitMovement:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = ListOfEvents[FrmEditor_Events.Default.cmbMoveWait.SelectedIndex];
					break;
					
				case (int) EventType.EvHoldPlayer:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
					
				case (int) EventType.EvReleasePlayer:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index = Index;
					break;
			}
			EventListCommands();
			
		}
		
		public static void EditEventCommand()
		{
			int i = 0;
			int X = 0;
			int curlist = 0;
			int curslot = 0;
			
			i = FrmEditor_Events.Default.lstCommands.SelectedIndex;
			if (i == -1)
			{
				return;
			}
			if (i > (EventList.Length - 1))
			{
				return;
			}
			
			FrmEditor_Events.Default.fraConditionalBranch.Visible = false;
			FrmEditor_Events.Default.fraDialogue.BringToFront();
			
			curlist = EventList[i].CommandList;
			curslot = EventList[i].CommandNum;
			if (curlist == 0)
			{
				return;
			}
			if (curslot == 0)
			{
				return;
			}
			if (curlist > TmpEvent.Pages[CurPageNum].CommandListCount)
			{
				return;
			}
			if (curslot > TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount)
			{
				return;
			}
			switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index)
			{
				case (int) EventType.EvAddText:
					IsEdit = true;
					FrmEditor_Events.Default.txtAddText_Text.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1;
					//frmEditor_Events.scrlAddText_Colour.Value = tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1
					switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2)
					{
						case 0:
							FrmEditor_Events.Default.optAddText_Player.Checked = true;
							break;
						case 1:
							FrmEditor_Events.Default.optAddText_Map.Checked = true;
							break;
						case 2:
							FrmEditor_Events.Default.optAddText_Global.Checked = true;
							break;
					}
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraAddText.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvCondition:
					IsEdit = true;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraConditionalBranch.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					FrmEditor_Events.Default.ClearConditionFrame();
					
					switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition)
					{
						case 0:
							FrmEditor_Events.Default.optCondition0.Checked = true;
							break;
						case 1:
							FrmEditor_Events.Default.optCondition1.Checked = true;
							break;
						case 2:
							FrmEditor_Events.Default.optCondition2.Checked = true;
							break;
						case 3:
							FrmEditor_Events.Default.optCondition3.Checked = true;
							break;
						case 4:
							FrmEditor_Events.Default.optCondition4.Checked = true;
							break;
						case 5:
							FrmEditor_Events.Default.optCondition5.Checked = true;
							break;
						case 6:
							FrmEditor_Events.Default.optCondition6.Checked = true;
							break;
						case 7:
							FrmEditor_Events.Default.optCondition7.Checked = true;
							break;
						case 8:
							FrmEditor_Events.Default.optCondition8.Checked = true;
							break;
						case 9:
							FrmEditor_Events.Default.optCondition9.Checked = true;
							break;
					}
					
					switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition)
					{
						case 0:
							FrmEditor_Events.Default.cmbCondition_PlayerVarIndex.Enabled = true;
							FrmEditor_Events.Default.cmbCondition_PlayerVarCompare.Enabled = true;
							FrmEditor_Events.Default.nudCondition_PlayerVarCondition.Enabled = true;
							FrmEditor_Events.Default.cmbCondition_PlayerVarIndex.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 - 1;
							FrmEditor_Events.Default.cmbCondition_PlayerVarCompare.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2;
							FrmEditor_Events.Default.nudCondition_PlayerVarCondition.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3;
							break;
						case 1:
							FrmEditor_Events.Default.cmbCondition_PlayerSwitch.Enabled = true;
							FrmEditor_Events.Default.cmbCondtion_PlayerSwitchCondition.Enabled = true;
							FrmEditor_Events.Default.cmbCondition_PlayerSwitch.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 - 1;
							FrmEditor_Events.Default.cmbCondtion_PlayerSwitchCondition.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2;
							break;
						case 2:
							FrmEditor_Events.Default.cmbCondition_HasItem.Enabled = true;
							FrmEditor_Events.Default.nudCondition_HasItem.Enabled = true;
							FrmEditor_Events.Default.cmbCondition_HasItem.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 - 1;
							FrmEditor_Events.Default.nudCondition_HasItem.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2;
							break;
						case 3:
							FrmEditor_Events.Default.cmbCondition_ClassIs.Enabled = true;
							FrmEditor_Events.Default.cmbCondition_ClassIs.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 - 1;
							break;
						case 4:
							FrmEditor_Events.Default.cmbCondition_LearntSkill.Enabled = true;
							FrmEditor_Events.Default.cmbCondition_LearntSkill.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 - 1;
							break;
						case 5:
							FrmEditor_Events.Default.cmbCondition_LevelCompare.Enabled = true;
							FrmEditor_Events.Default.nudCondition_LevelAmount.Enabled = true;
							FrmEditor_Events.Default.nudCondition_LevelAmount.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1;
							FrmEditor_Events.Default.cmbCondition_LevelCompare.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2;
							break;
						case 6:
							FrmEditor_Events.Default.cmbCondition_SelfSwitch.Enabled = true;
							FrmEditor_Events.Default.cmbCondition_SelfSwitchCondition.Enabled = true;
							FrmEditor_Events.Default.cmbCondition_SelfSwitch.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1;
							FrmEditor_Events.Default.cmbCondition_SelfSwitchCondition.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2;
							break;
						case 7:
							FrmEditor_Events.Default.nudCondition_Quest.Enabled = true;
							FrmEditor_Events.Default.nudCondition_Quest.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1;
							FrmEditor_Events.Default.fraConditions_Quest.Visible = true;
							if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 == 0)
							{
								FrmEditor_Events.Default.optCondition_Quest0.Checked = true;
								FrmEditor_Events.Default.cmbCondition_General.Enabled = true;
								FrmEditor_Events.Default.cmbCondition_General.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3;
							}
							else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 == 1)
							{
								FrmEditor_Events.Default.optCondition_Quest1.Checked = true;
								FrmEditor_Events.Default.nudCondition_QuestTask.Enabled = true;
								FrmEditor_Events.Default.nudCondition_QuestTask.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3;
							}
							break;
						case 8:
							FrmEditor_Events.Default.cmbCondition_Gender.Enabled = true;
							FrmEditor_Events.Default.cmbCondition_Gender.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1;
							break;
						case 9:
							FrmEditor_Events.Default.cmbCondition_Time.Enabled = true;
							FrmEditor_Events.Default.cmbCondition_Time.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1;
							break;
					}
					break;
				case (int) EventType.EvShowText:
					IsEdit = true;
					FrmEditor_Events.Default.txtShowText.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1;
					FrmEditor_Events.Default.nudShowTextFace.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraShowText.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvShowChoices:
					IsEdit = true;
					FrmEditor_Events.Default.txtChoicePrompt.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1;
					FrmEditor_Events.Default.txtChoices1.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text2;
					FrmEditor_Events.Default.txtChoices2.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text3;
					FrmEditor_Events.Default.txtChoices3.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text4;
					FrmEditor_Events.Default.txtChoices4.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text5;
					FrmEditor_Events.Default.nudShowChoicesFace.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data5;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraShowChoices.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvPlayerVar:
					IsEdit = true;
					FrmEditor_Events.Default.cmbVariable.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
					switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2)
					{
						case 0:
							FrmEditor_Events.Default.optVariableAction0.Checked = true;
							FrmEditor_Events.Default.nudVariableData0.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
							break;
						case 1:
							FrmEditor_Events.Default.optVariableAction1.Checked = true;
							FrmEditor_Events.Default.nudVariableData1.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
							break;
						case 2:
							FrmEditor_Events.Default.optVariableAction2.Checked = true;
							FrmEditor_Events.Default.nudVariableData2.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
							break;
						case 3:
							FrmEditor_Events.Default.optVariableAction3.Checked = true;
							FrmEditor_Events.Default.nudVariableData3.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
							FrmEditor_Events.Default.nudVariableData4.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4;
							break;
					}
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraPlayerVariable.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvPlayerSwitch:
					IsEdit = true;
					FrmEditor_Events.Default.cmbSwitch.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
					FrmEditor_Events.Default.cmbPlayerSwitchSet.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraPlayerSwitch.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvSelfSwitch:
					IsEdit = true;
					FrmEditor_Events.Default.cmbSetSelfSwitch.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.cmbSetSelfSwitchTo.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraSetSelfSwitch.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvChangeItems:
					IsEdit = true;
					FrmEditor_Events.Default.cmbChangeItemIndex.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
					if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 0)
					{
						FrmEditor_Events.Default.optChangeItemSet.Checked = true;
					}
					else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 1)
					{
						FrmEditor_Events.Default.optChangeItemAdd.Checked = true;
					}
					else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 2)
					{
						FrmEditor_Events.Default.optChangeItemRemove.Checked = true;
					}
					FrmEditor_Events.Default.nudChangeItemsAmount.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraChangeItems.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvChangeLevel:
					IsEdit = true;
					FrmEditor_Events.Default.nudChangeLevel.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraChangeLevel.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvChangeSkills:
					IsEdit = true;
					FrmEditor_Events.Default.cmbChangeSkills.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
					if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 0)
					{
						FrmEditor_Events.Default.optChangeSkillsAdd.Checked = true;
					}
					else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 1)
					{
						FrmEditor_Events.Default.optChangeSkillsRemove.Checked = true;
					}
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraChangeSkills.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvChangeClass:
					IsEdit = true;
					FrmEditor_Events.Default.cmbChangeClass.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraChangeClass.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvChangeSprite:
					IsEdit = true;
					FrmEditor_Events.Default.nudChangeSprite.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraChangeSprite.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvChangeSex:
					IsEdit = true;
					if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 == 0)
					{
						FrmEditor_Events.Default.optChangeSexMale.Checked = true;
					}
					else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 == 1)
					{
						FrmEditor_Events.Default.optChangeSexFemale.Checked = true;
					}
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraChangeGender.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvChangePk:
					IsEdit = true;
					
					FrmEditor_Events.Default.cmbSetPK.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraChangePK.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvWarpPlayer:
					IsEdit = true;
					FrmEditor_Events.Default.nudWPMap.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.nudWPX.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
					FrmEditor_Events.Default.nudWPY.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
					FrmEditor_Events.Default.cmbWarpPlayerDir.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraPlayerWarp.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvSetMoveRoute:
					IsEdit = true;
					FrmEditor_Events.Default.fraMoveRoute.Visible = true;
					FrmEditor_Events.Default.fraMoveRoute.BringToFront();
					FrmEditor_Events.Default.lstMoveRoute.Items.Clear();
					FrmEditor_Events.Default.cmbEvent.Items.Clear();
					ListOfEvents = new int[C_Maps.Map.EventCount + 1];
					ListOfEvents[0] = EditorEvent;
					FrmEditor_Events.Default.cmbEvent.Items.Add("This Event");
					FrmEditor_Events.Default.cmbEvent.SelectedIndex = 0;
					FrmEditor_Events.Default.cmbEvent.Enabled = true;
					for (i = 1; i <= C_Maps.Map.EventCount; i++)
					{
						if (i != EditorEvent)
						{
							FrmEditor_Events.Default.cmbEvent.Items.Add(Microsoft.VisualBasic.Strings.Trim(C_Maps.Map.Events[i].Name));
							X++;
							ListOfEvents[X] = i;
							if (i == TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1)
							{
								FrmEditor_Events.Default.cmbEvent.SelectedIndex = X;
							}
						}
					}
					
					IsMoveRouteCommand = true;
					FrmEditor_Events.Default.chkIgnoreMove.Checked = System.Convert.ToBoolean(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2);
					FrmEditor_Events.Default.chkRepeatRoute.Checked = System.Convert.ToBoolean(TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3);
					TempMoveRouteCount = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].MoveRouteCount;
					TempMoveRoute = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].MoveRoute;
					for (i = 1; i <= TempMoveRouteCount; i++)
					{
						switch (TempMoveRoute[i].Index)
						{
							case 1:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Move Up");
								break;
							case 2:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Move Down");
								break;
							case 3:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Move Left");
								break;
							case 4:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Move Right");
								break;
							case 5:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Move Randomly");
								break;
							case 6:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Move Towards Player");
								break;
							case 7:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Move Away From Player");
								break;
							case 8:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Step Forward");
								break;
							case 9:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Step Back");
								break;
							case 10:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Wait 100ms");
								break;
							case 11:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Wait 500ms");
								break;
							case 12:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Wait 1000ms");
								break;
							case 13:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn Up");
								break;
							case 14:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn Down");
								break;
							case 15:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn Left");
								break;
							case 16:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn Right");
								break;
							case 17:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn 90 Degrees To the Right");
								break;
							case 18:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn 90 Degrees To the Left");
								break;
							case 19:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn Around 180 Degrees");
								break;
							case 20:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn Randomly");
								break;
							case 21:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn Towards Player");
								break;
							case 22:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn Away from Player");
								break;
							case 23:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Speed 8x Slower");
								break;
							case 24:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Speed 4x Slower");
								break;
							case 25:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Speed 2x Slower");
								break;
							case 26:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Speed to Normal");
								break;
							case 27:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Speed 2x Faster");
								break;
							case 28:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Speed 4x Faster");
								break;
							case 29:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Frequency Lowest");
								break;
							case 30:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Frequency Lower");
								break;
							case 31:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Frequency Normal");
								break;
							case 32:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Frequency Higher");
								break;
							case 33:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Frequency Highest");
								break;
							case 34:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn On Walking Animation");
								break;
							case 35:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn Off Walking Animation");
								break;
							case 36:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn On Fixed Direction");
								break;
							case 37:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn Off Fixed Direction");
								break;
							case 38:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn On Walk Through");
								break;
							case 39:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Turn Off Walk Through");
								break;
							case 40:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Position Below Player");
								break;
							case 41:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Position at Player Level");
								break;
							case 42:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Position Above Player");
								break;
							case 43:
								FrmEditor_Events.Default.lstMoveRoute.Items.Add("Set Graphic");
								break;
						}
					}
					FrmEditor_Events.Default.fraMoveRoute.Width = 841;
					FrmEditor_Events.Default.fraMoveRoute.Height = 636;
					FrmEditor_Events.Default.fraMoveRoute.Visible = true;
					FrmEditor_Events.Default.fraDialogue.Visible = false;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvPlayAnimation:
					IsEdit = true;
					FrmEditor_Events.Default.lblPlayAnimX.Visible = false;
					FrmEditor_Events.Default.lblPlayAnimY.Visible = false;
					FrmEditor_Events.Default.nudPlayAnimTileX.Visible = false;
					FrmEditor_Events.Default.nudPlayAnimTileY.Visible = false;
					FrmEditor_Events.Default.cmbPlayAnimEvent.Visible = false;
					FrmEditor_Events.Default.cmbPlayAnim.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
					FrmEditor_Events.Default.cmbPlayAnimEvent.Items.Clear();
					for (i = 1; i <= C_Maps.Map.EventCount; i++)
					{
						FrmEditor_Events.Default.cmbPlayAnimEvent.Items.Add(i +". " + Microsoft.VisualBasic.Strings.Trim(C_Maps.Map.Events[i].Name));
					}
					FrmEditor_Events.Default.cmbPlayAnimEvent.SelectedIndex = 0;
					if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 0)
					{
						FrmEditor_Events.Default.cmbAnimTargetType.SelectedIndex = 0;
					}
					else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 1)
					{
						FrmEditor_Events.Default.cmbAnimTargetType.SelectedIndex = 1;
						FrmEditor_Events.Default.cmbPlayAnimEvent.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 - 1;
					}
					else if (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 == 2)
					{
						FrmEditor_Events.Default.cmbAnimTargetType.SelectedIndex = 2;
						FrmEditor_Events.Default.nudPlayAnimTileX.Maximum = C_Maps.Map.MaxX;
						FrmEditor_Events.Default.nudPlayAnimTileY.Maximum = C_Maps.Map.MaxY;
						FrmEditor_Events.Default.nudPlayAnimTileX.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
						FrmEditor_Events.Default.nudPlayAnimTileY.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4;
					}
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraPlayAnimation.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvCustomScript:
					IsEdit = true;
					FrmEditor_Events.Default.nudCustomScript.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraCustomScript.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvPlayBgm:
					IsEdit = true;
					for (i = 1; i <= (C_Sound.MusicCache.Length - 1); i++)
					{
						if (C_Sound.MusicCache[i] == TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1)
						{
							FrmEditor_Events.Default.cmbPlayBGM.SelectedIndex = i - 1;
						}
					}
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraPlayBGM.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvPlaySound:
					IsEdit = true;
					for (i = 1; i <= (C_Sound.SoundCache.Length - 1); i++)
					{
						if (C_Sound.SoundCache[i] == TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1)
						{
							FrmEditor_Events.Default.cmbPlaySound.SelectedIndex = i - 1;
						}
					}
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraPlaySound.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvOpenShop:
					IsEdit = true;
					FrmEditor_Events.Default.cmbOpenShop.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraOpenShop.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvSetAccess:
					IsEdit = true;
					FrmEditor_Events.Default.cmbSetAccess.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraSetAccess.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvGiveExp:
					IsEdit = true;
					FrmEditor_Events.Default.nudGiveExp.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraGiveExp.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvShowChatBubble:
					IsEdit = true;
					FrmEditor_Events.Default.txtChatbubbleText.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1;
					FrmEditor_Events.Default.cmbChatBubbleTargetType.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
					FrmEditor_Events.Default.cmbChatBubbleTarget.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 - 1;
					
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraShowChatBubble.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvLabel:
					IsEdit = true;
					FrmEditor_Events.Default.txtLabelName.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraCreateLabel.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvGotoLabel:
					IsEdit = true;
					FrmEditor_Events.Default.txtGotoLabel.Text = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraGoToLabel.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvSpawnNpc:
					IsEdit = true;
					FrmEditor_Events.Default.cmbSpawnNpc.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 - 1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraSpawnNpc.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvSetFog:
					IsEdit = true;
					FrmEditor_Events.Default.nudFogData0.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.nudFogData1.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
					FrmEditor_Events.Default.nudFogData2.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraSetFog.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvSetWeather:
					IsEdit = true;
					FrmEditor_Events.Default.CmbWeather.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.nudWeatherIntensity.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraSetWeather.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvSetTint:
					IsEdit = true;
					FrmEditor_Events.Default.nudMapTintData0.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.nudMapTintData1.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
					FrmEditor_Events.Default.nudMapTintData2.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3;
					FrmEditor_Events.Default.nudMapTintData3.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraMapTint.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvWait:
					IsEdit = true;
					FrmEditor_Events.Default.nudWaitAmount.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraSetWait.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvBeginQuest:
					IsEdit = true;
					FrmEditor_Events.Default.cmbBeginQuest.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraBeginQuest.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvEndQuest:
					IsEdit = true;
					FrmEditor_Events.Default.cmbEndQuest.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraEndQuest.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvQuestTask:
					IsEdit = true;
					FrmEditor_Events.Default.cmbCompleteQuest.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.nudCompleteQuestTask.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraCompleteTask.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvShowPicture:
					IsEdit = true;
					FrmEditor_Events.Default.cmbPicIndex.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.nudShowPicture.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2;
					
					FrmEditor_Events.Default.cmbPicLoc.SelectedIndex = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 - 1;
					
					FrmEditor_Events.Default.nudPicOffsetX.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4;
					FrmEditor_Events.Default.nudPicOffsetY.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data5;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraShowPic.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvHidePicture:
					IsEdit = true;
					FrmEditor_Events.Default.nudHidePic.Value = TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraHidePic.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					break;
				case (int) EventType.EvWaitMovement:
					IsEdit = true;
					FrmEditor_Events.Default.fraDialogue.Visible = true;
					FrmEditor_Events.Default.fraMoveRouteWait.Visible = true;
					FrmEditor_Events.Default.fraCommands.Visible = false;
					FrmEditor_Events.Default.cmbMoveWait.Items.Clear();
					ListOfEvents = new int[C_Maps.Map.EventCount + 1];
					ListOfEvents[0] = EditorEvent;
					FrmEditor_Events.Default.cmbMoveWait.Items.Add("This Event");
					FrmEditor_Events.Default.cmbMoveWait.SelectedIndex = 0;
					for (i = 1; i <= C_Maps.Map.EventCount; i++)
					{
						if (i != EditorEvent)
						{
							FrmEditor_Events.Default.cmbMoveWait.Items.Add(Microsoft.VisualBasic.Strings.Trim(C_Maps.Map.Events[i].Name));
							X++;
							ListOfEvents[X] = i;
							if (i == TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1)
							{
								FrmEditor_Events.Default.cmbMoveWait.SelectedIndex = X;
							}
						}
					}
					break;
			}
			
		}
		
		public static void DeleteEventCommand()
		{
			int i = 0;
			int X = 0;
			int curlist = 0;
			int curslot = 0;
			int p = 0;
			CommandListRec oldCommandList = new CommandListRec();
			
			i = FrmEditor_Events.Default.lstCommands.SelectedIndex;
			if (i == -1)
			{
				return;
			}
			if (i > (EventList.Length - 1))
			{
				return;
			}
			curlist = EventList[i].CommandList;
			curslot = EventList[i].CommandNum;
			if (curlist == 0)
			{
				return;
			}
			if (curslot == 0)
			{
				return;
			}
			if (curlist > TmpEvent.Pages[CurPageNum].CommandListCount)
			{
				return;
			}
			if (curslot > TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount)
			{
				return;
			}
			if (curslot == TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount)
			{
				TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount - 1;
				p = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount;
				if (p <= 0)
				{
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands = new C_EventSystem.EventCommandRec[1];
				}
				else
				{
					oldCommandList = TmpEvent.Pages[CurPageNum].CommandList[curlist];
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands = new C_EventSystem.EventCommandRec[p + 1];
					X = 1;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].ParentList = oldCommandList.ParentList;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount = p;
					for (i = 1; i <= p + 1; i++)
					{
						if (i != curslot)
						{
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[X] = oldCommandList.Commands[i];
							X++;
						}
					}
				}
			}
			else
			{
				TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount - 1;
				p = TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount;
				oldCommandList = TmpEvent.Pages[CurPageNum].CommandList[curlist];
				X = 1;
				if (p <= 0)
				{
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands = new C_EventSystem.EventCommandRec[1];
				}
				else
				{
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands = new C_EventSystem.EventCommandRec[p + 1];
					TmpEvent.Pages[CurPageNum].CommandList[curlist].ParentList = oldCommandList.ParentList;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount = p;
					for (i = 1; i <= p + 1; i++)
					{
						if (i != curslot)
						{
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[X] = oldCommandList.Commands[i];
							X++;
						}
					}
				}
			}
			EventListCommands();
			
		}
		
		public static void ClearEventCommands()
		{
			
			TmpEvent.Pages[CurPageNum].CommandList = new C_EventSystem.CommandListRec[2];
			TmpEvent.Pages[CurPageNum].CommandListCount = 1;
			EventListCommands();
			
		}
		
		public static void EditCommand()
		{
			int i = 0;
			int curlist = 0;
			int curslot = 0;
			
			i = FrmEditor_Events.Default.lstCommands.SelectedIndex;
			if (i == -1)
			{
				return;
			}
			if (i > (EventList.Length - 1))
			{
				return;
			}
			
			curlist = EventList[i].CommandList;
			curslot = EventList[i].CommandNum;
			if (curlist == 0)
			{
				return;
			}
			if (curslot == 0)
			{
				return;
			}
			if (curlist > TmpEvent.Pages[CurPageNum].CommandListCount)
			{
				return;
			}
			if (curslot > TmpEvent.Pages[CurPageNum].CommandList[curlist].CommandCount)
			{
				return;
			}
			switch (TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Index)
			{
				case (int) EventType.EvAddText:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = FrmEditor_Events.Default.txtAddText_Text.Text;
					//tmpEvent.Pages(curPageNum).CommandList(curlist).Commands(curslot).Data1 = frmEditor_Events.scrlAddText_Colour.Value
					if (FrmEditor_Events.Default.optAddText_Player.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
					}
					else if (FrmEditor_Events.Default.optAddText_Map.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
					}
					else if (FrmEditor_Events.Default.optAddText_Global.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 2;
					}
					break;
				case (int) EventType.EvCondition:
					if (FrmEditor_Events.Default.optCondition0.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 0;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_PlayerVarIndex.SelectedIndex + 1;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = FrmEditor_Events.Default.cmbCondition_PlayerVarCompare.SelectedIndex;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3 = (int) FrmEditor_Events.Default.nudCondition_PlayerVarCondition.Value;
					}
					else if (FrmEditor_Events.Default.optCondition1.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 1;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_PlayerSwitch.SelectedIndex + 1;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = FrmEditor_Events.Default.cmbCondtion_PlayerSwitchCondition.SelectedIndex;
					}
					else if (FrmEditor_Events.Default.optCondition2.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 2;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_HasItem.SelectedIndex + 1;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = (int) FrmEditor_Events.Default.nudCondition_HasItem.Value;
					}
					else if (FrmEditor_Events.Default.optCondition3.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 3;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_ClassIs.SelectedIndex + 1;
					}
					else if (FrmEditor_Events.Default.optCondition4.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 4;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_LearntSkill.SelectedIndex + 1;
					}
					else if (FrmEditor_Events.Default.optCondition5.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 5;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int) FrmEditor_Events.Default.nudCondition_LevelAmount.Value;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = FrmEditor_Events.Default.cmbCondition_LevelCompare.SelectedIndex;
					}
					else if (FrmEditor_Events.Default.optCondition6.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 6;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_SelfSwitch.SelectedIndex;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = FrmEditor_Events.Default.cmbCondition_SelfSwitchCondition.SelectedIndex;
					}
					else if (FrmEditor_Events.Default.optCondition7.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 7;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = (int) FrmEditor_Events.Default.nudCondition_Quest.Value;
						if (FrmEditor_Events.Default.optCondition_Quest0.Checked)
						{
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = 0;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3 = FrmEditor_Events.Default.cmbCondition_General.SelectedIndex;
						}
						else
						{
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data2 = 1;
							TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data3 = (int) FrmEditor_Events.Default.nudCondition_QuestTask.Value;
						}
					}
					else if (FrmEditor_Events.Default.optCondition8.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 8;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_Gender.SelectedIndex;
					}
					else if (FrmEditor_Events.Default.optCondition9.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Condition = 9;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].ConditionalBranch.Data1 = FrmEditor_Events.Default.cmbCondition_Time.SelectedIndex;
					}
					break;
				case (int) EventType.EvShowText:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = FrmEditor_Events.Default.txtShowText.Text;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudShowTextFace.Value;
					break;
				case (int) EventType.EvShowChoices:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = FrmEditor_Events.Default.txtChoicePrompt.Text;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text2 = FrmEditor_Events.Default.txtChoices1.Text;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text3 = FrmEditor_Events.Default.txtChoices2.Text;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text4 = FrmEditor_Events.Default.txtChoices3.Text;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text5 = FrmEditor_Events.Default.txtChoices4.Text;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data5 = (int) FrmEditor_Events.Default.nudShowChoicesFace.Value;
					break;
				case (int) EventType.EvPlayerVar:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbVariable.SelectedIndex + 1;
					if (FrmEditor_Events.Default.optVariableAction0.Checked == true)
					{
						i = 0;
					}
					if (FrmEditor_Events.Default.optVariableAction1.Checked == true)
					{
						i = 1;
					}
					if (FrmEditor_Events.Default.optVariableAction2.Checked == true)
					{
						i = 2;
					}
					if (FrmEditor_Events.Default.optVariableAction3.Checked == true)
					{
						i = 3;
					}
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = i;
					if (i == 0)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudVariableData0.Value;
					}
					else if (i == 1)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudVariableData1.Value;
					}
					else if (i == 2)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudVariableData2.Value;
					}
					else if (i == 3)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudVariableData3.Value;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int) FrmEditor_Events.Default.nudVariableData4.Value;
					}
					break;
				case (int) EventType.EvPlayerSwitch:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbSwitch.SelectedIndex + 1;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = FrmEditor_Events.Default.cmbPlayerSwitchSet.SelectedIndex;
					break;
				case (int) EventType.EvSelfSwitch:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbSetSelfSwitch.SelectedIndex;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = FrmEditor_Events.Default.cmbSetSelfSwitchTo.SelectedIndex;
					break;
				case (int) EventType.EvChangeItems:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbChangeItemIndex.SelectedIndex + 1;
					if (FrmEditor_Events.Default.optChangeItemSet.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
					}
					else if (FrmEditor_Events.Default.optChangeItemAdd.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
					}
					else if (FrmEditor_Events.Default.optChangeItemRemove.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 2;
					}
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudChangeItemsAmount.Value;
					break;
				case (int) EventType.EvChangeLevel:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudChangeLevel.Value;
					break;
				case (int) EventType.EvChangeSkills:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbChangeSkills.SelectedIndex + 1;
					if (FrmEditor_Events.Default.optChangeSkillsAdd.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
					}
					else if (FrmEditor_Events.Default.optChangeSkillsRemove.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
					}
					break;
				case (int) EventType.EvChangeClass:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbChangeClass.SelectedIndex + 1;
					break;
				case (int) EventType.EvChangeSprite:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudChangeSprite.Value;
					break;
				case (int) EventType.EvChangeSex:
					if (FrmEditor_Events.Default.optChangeSexMale.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = 0;
					}
					else if (FrmEditor_Events.Default.optChangeSexFemale.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = 1;
					}
					break;
				case (int) EventType.EvChangePk:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbSetPK.SelectedIndex;
					break;
					
				case (int) EventType.EvWarpPlayer:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudWPMap.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int) FrmEditor_Events.Default.nudWPX.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudWPY.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = FrmEditor_Events.Default.cmbWarpPlayerDir.SelectedIndex;
					break;
				case (int) EventType.EvSetMoveRoute:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = ListOfEvents[FrmEditor_Events.Default.cmbEvent.SelectedIndex];
					if (FrmEditor_Events.Default.chkIgnoreMove.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
					}
					else
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
					}
					
					if (FrmEditor_Events.Default.chkRepeatRoute.Checked == true)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = 1;
					}
					else
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = 0;
					}
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].MoveRouteCount = TempMoveRouteCount;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].MoveRoute = TempMoveRoute;
					break;
				case (int) EventType.EvPlayAnimation:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbPlayAnim.SelectedIndex + 1;
					if (FrmEditor_Events.Default.cmbAnimTargetType.SelectedIndex == 0)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 0;
					}
					else if (FrmEditor_Events.Default.cmbAnimTargetType.SelectedIndex == 1)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 1;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = FrmEditor_Events.Default.cmbPlayAnimEvent.SelectedIndex + 1;
					}
					else if (FrmEditor_Events.Default.cmbAnimTargetType.SelectedIndex == 2)
					{
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = 2;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudPlayAnimTileX.Value;
						TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int) FrmEditor_Events.Default.nudPlayAnimTileY.Value;
					}
					break;
				case (int) EventType.EvCustomScript:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudCustomScript.Value;
					break;
				case (int) EventType.EvPlayBgm:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = C_Sound.MusicCache[FrmEditor_Events.Default.cmbPlayBGM.SelectedIndex + 1];
					break;
				case (int) EventType.EvPlaySound:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = C_Sound.SoundCache[FrmEditor_Events.Default.cmbPlaySound.SelectedIndex + 1];
					break;
				case (int) EventType.EvOpenShop:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbOpenShop.SelectedIndex + 1;
					break;
				case (int) EventType.EvSetAccess:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbSetAccess.SelectedIndex;
					break;
				case (int) EventType.EvGiveExp:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudGiveExp.Value;
					break;
				case (int) EventType.EvShowChatBubble:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = FrmEditor_Events.Default.txtChatbubbleText.Text;
					
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbChatBubbleTargetType.SelectedIndex + 1;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = FrmEditor_Events.Default.cmbChatBubbleTarget.SelectedIndex + 1;
					break;
				case (int) EventType.EvLabel:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = FrmEditor_Events.Default.txtLabelName.Text;
					break;
				case (int) EventType.EvGotoLabel:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Text1 = FrmEditor_Events.Default.txtGotoLabel.Text;
					break;
				case (int) EventType.EvSpawnNpc:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbSpawnNpc.SelectedIndex + 1;
					break;
				case (int) EventType.EvSetFog:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudFogData0.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int) FrmEditor_Events.Default.nudFogData1.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudFogData2.Value;
					break;
				case (int) EventType.EvSetWeather:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.CmbWeather.SelectedIndex;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int) FrmEditor_Events.Default.nudWeatherIntensity.Value;
					break;
				case (int) EventType.EvSetTint:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudMapTintData0.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int) FrmEditor_Events.Default.nudMapTintData1.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = (int) FrmEditor_Events.Default.nudMapTintData2.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int) FrmEditor_Events.Default.nudMapTintData3.Value;
					break;
				case (int) EventType.EvWait:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudWaitAmount.Value;
					break;
				case (int) EventType.EvBeginQuest:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbBeginQuest.SelectedIndex;
					break;
				case (int) EventType.EvEndQuest:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbEndQuest.SelectedIndex;
					break;
				case (int) EventType.EvQuestTask:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbCompleteQuest.SelectedIndex;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int) FrmEditor_Events.Default.nudCompleteQuestTask.Value;
					break;
				case (int) EventType.EvShowPicture:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = FrmEditor_Events.Default.cmbPicIndex.SelectedIndex;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data2 = (int) FrmEditor_Events.Default.nudShowPicture.Value;
					
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data3 = FrmEditor_Events.Default.cmbPicLoc.SelectedIndex + 1;
					
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data4 = (int) FrmEditor_Events.Default.nudPicOffsetX.Value;
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data5 = (int) FrmEditor_Events.Default.nudPicOffsetY.Value;
					break;
				case (int) EventType.EvHidePicture:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = (int) FrmEditor_Events.Default.nudHidePic.Value;
					break;
				case (int) EventType.EvWaitMovement:
					TmpEvent.Pages[CurPageNum].CommandList[curlist].Commands[curslot].Data1 = ListOfEvents[FrmEditor_Events.Default.cmbMoveWait.SelectedIndex];
					break;
			}
			EventListCommands();
			
		}
		
#endregion
		
#region Incoming Packets
		
		public static void Packet_SpawnEvent(ref byte[] data)
		{
			int id = 0;
			ByteStream buffer = new ByteStream(data);
			id = buffer.ReadInt32();
			if (id > C_Maps.Map.CurrentEvents)
			{
				C_Maps.Map.CurrentEvents = id;
				Array.Resize(ref C_Maps.Map.MapEvents, C_Maps.Map.CurrentEvents + 1);
			}
			
			ref var with_1 = ref C_Maps.Map.MapEvents[id];
			with_1.Name = buffer.ReadString();
			with_1.Dir = buffer.ReadInt32();
			with_1.ShowDir = with_1.Dir;
			with_1.GraphicNum = buffer.ReadInt32();
			with_1.GraphicType = buffer.ReadInt32();
			with_1.GraphicX = buffer.ReadInt32();
			with_1.GraphicX2 = buffer.ReadInt32();
			with_1.GraphicY = buffer.ReadInt32();
			with_1.GraphicY2 = buffer.ReadInt32();
			with_1.MovementSpeed = buffer.ReadInt32();
			with_1.Moving = 0;
			with_1.X = buffer.ReadInt32();
			with_1.Y = buffer.ReadInt32();
			with_1.XOffset = 0;
			with_1.YOffset = 0;
			with_1.Position = buffer.ReadInt32();
			with_1.Visible = buffer.ReadInt32();
			with_1.WalkAnim = buffer.ReadInt32();
			with_1.DirFix = buffer.ReadInt32();
			with_1.WalkThrough = buffer.ReadInt32();
			with_1.ShowName = buffer.ReadInt32();
			with_1.Questnum = buffer.ReadInt32();
			buffer.Dispose();
			
		}
		
		public static void Packet_EventMove(ref byte[] data)
		{
			int id = 0;
			int x = 0;
			int y = 0;
			int dir = 0;
			int showDir = 0;
			int movementSpeed = 0;
			ByteStream buffer = new ByteStream(data);
			id = buffer.ReadInt32();
			x = buffer.ReadInt32();
			y = buffer.ReadInt32();
			dir = buffer.ReadInt32();
			showDir = buffer.ReadInt32();
			movementSpeed = buffer.ReadInt32();
			if (id > C_Maps.Map.CurrentEvents)
			{
				return;
			}
			
			ref var with_1 = ref C_Maps.Map.MapEvents[id];
			with_1.X = x;
			with_1.Y = y;
			with_1.Dir = dir;
			with_1.XOffset = 0;
			with_1.YOffset = 0;
			with_1.Moving = 1;
			with_1.ShowDir = showDir;
			with_1.MovementSpeed = movementSpeed;
			
			switch (dir)
			{
				case (int) Enums.DirectionType.Up:
					with_1.YOffset = C_Constants.PicY;
					break;
				case (int) Enums.DirectionType.Down:
					with_1.YOffset = C_Constants.PicY * -1;
					break;
				case (int) Enums.DirectionType.Left:
					with_1.XOffset = C_Constants.PicX;
					break;
				case (int) Enums.DirectionType.Right:
					with_1.XOffset = C_Constants.PicX * -1;
					break;
			}
			
			
		}
		
		public static void Packet_EventDir(ref byte[] data)
		{
			int i = 0;
			byte dir = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			dir = (byte) (buffer.ReadInt32());
			if (i > C_Maps.Map.CurrentEvents)
			{
				return;
			}
			
			ref var with_1 = ref C_Maps.Map.MapEvents[i];
			with_1.Dir = dir;
			with_1.ShowDir = dir;
			with_1.XOffset = 0;
			with_1.YOffset = 0;
			with_1.Moving = 0;
			
		}
		
		public static void Packet_SwitchesAndVariables(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			for (i = 1; i <= MaxSwitches; i++)
			{
				Switches[i] = buffer.ReadString();
			}
			for (i = 1; i <= MaxVariables; i++)
			{
				Variables[i] = buffer.ReadString();
			}
			
			buffer.Dispose();
			
		}
		
		public static void Packet_MapEventData(ref byte[] data)
		{
			int i = 0;
			int x = 0;
			int y = 0;
			int z = 0;
			int w = 0;
			ByteStream buffer = new ByteStream(data);
			//Event Data!
			C_Maps.Map.EventCount = buffer.ReadInt32();
			if (C_Maps.Map.EventCount > 0)
			{
				C_Maps.Map.Events = new C_EventSystem.EventRec[C_Maps.Map.EventCount + 1];
				for (i = 1; i <= C_Maps.Map.EventCount; i++)
				{
					ref var with_1 = ref C_Maps.Map.Events[i];
					with_1.Name = buffer.ReadString();
					with_1.Globals = buffer.ReadInt32();
					with_1.X = buffer.ReadInt32();
					with_1.Y = buffer.ReadInt32();
					with_1.PageCount = buffer.ReadInt32();
					if (C_Maps.Map.Events[i].PageCount > 0)
					{
						C_Maps.Map.Events[i].Pages = new C_EventSystem.EventPageRec[C_Maps.Map.Events[i].PageCount + 1];
						for (x = 1; x <= C_Maps.Map.Events[i].PageCount; x++)
						{
							ref var with_2 = ref C_Maps.Map.Events[i].Pages[x];
							with_2.ChkVariable = buffer.ReadInt32();
							with_2.Variableindex = buffer.ReadInt32();
							with_2.VariableCondition = buffer.ReadInt32();
							with_2.VariableCompare = buffer.ReadInt32();
							with_2.ChkSwitch = buffer.ReadInt32();
							with_2.Switchindex = buffer.ReadInt32();
							with_2.SwitchCompare = buffer.ReadInt32();
							with_2.ChkHasItem = buffer.ReadInt32();
							with_2.HasItemindex = buffer.ReadInt32();
							with_2.HasItemAmount = buffer.ReadInt32();
							with_2.ChkSelfSwitch = buffer.ReadInt32();
							with_2.SelfSwitchindex = buffer.ReadInt32();
							with_2.SelfSwitchCompare = buffer.ReadInt32();
							with_2.GraphicType = (byte) (buffer.ReadInt32());
							with_2.Graphic = buffer.ReadInt32();
							with_2.GraphicX = buffer.ReadInt32();
							with_2.GraphicY = buffer.ReadInt32();
							with_2.GraphicX2 = buffer.ReadInt32();
							with_2.GraphicY2 = buffer.ReadInt32();
							with_2.MoveType = (byte) (buffer.ReadInt32());
							with_2.MoveSpeed = (byte) (buffer.ReadInt32());
							with_2.MoveFreq = (byte) (buffer.ReadInt32());
							with_2.MoveRouteCount = buffer.ReadInt32();
							with_2.IgnoreMoveRoute = buffer.ReadInt32();
							with_2.RepeatMoveRoute = buffer.ReadInt32();
							if (with_2.MoveRouteCount > 0)
							{
								C_Maps.Map.Events[i].Pages[x].MoveRoute = new C_EventSystem.MoveRouteRec[with_2.MoveRouteCount + 1];
								for (y = 1; y <= with_2.MoveRouteCount; y++)
								{
									with_2.MoveRoute[y].Index = buffer.ReadInt32();
									with_2.MoveRoute[y].Data1 = buffer.ReadInt32();
									with_2.MoveRoute[y].Data2 = buffer.ReadInt32();
									with_2.MoveRoute[y].Data3 = buffer.ReadInt32();
									with_2.MoveRoute[y].Data4 = buffer.ReadInt32();
									with_2.MoveRoute[y].Data5 = buffer.ReadInt32();
									with_2.MoveRoute[y].Data6 = buffer.ReadInt32();
								}
							}
							with_2.WalkAnim = (byte) (buffer.ReadInt32());
							with_2.DirFix = (byte) (buffer.ReadInt32());
							with_2.WalkThrough = (byte) (buffer.ReadInt32());
							with_2.ShowName = (byte) (buffer.ReadInt32());
							with_2.Trigger = (byte) (buffer.ReadInt32());
							with_2.CommandListCount = buffer.ReadInt32();
							with_2.Position = (byte) (buffer.ReadInt32());
							with_2.Questnum = buffer.ReadInt32();
							if (C_Maps.Map.Events[i].Pages[x].CommandListCount > 0)
							{
								C_Maps.Map.Events[i].Pages[x].CommandList = new C_EventSystem.CommandListRec[C_Maps.Map.Events[i].Pages[x].CommandListCount + 1];
								for (y = 1; y <= C_Maps.Map.Events[i].Pages[x].CommandListCount; y++)
								{
									C_Maps.Map.Events[i].Pages[x].CommandList[y].CommandCount = buffer.ReadInt32();
									C_Maps.Map.Events[i].Pages[x].CommandList[y].ParentList = buffer.ReadInt32();
									if (C_Maps.Map.Events[i].Pages[x].CommandList[y].CommandCount > 0)
									{
										C_Maps.Map.Events[i].Pages[x].CommandList[y].Commands = new C_EventSystem.EventCommandRec[C_Maps.Map.Events[i].Pages[x].CommandList[y].CommandCount + 1];
										for (z = 1; z <= C_Maps.Map.Events[i].Pages[x].CommandList[y].CommandCount; z++)
										{
											ref var with_3 = ref C_Maps.Map.Events[i].Pages[x].CommandList[y].Commands[z];
											with_3.Index = buffer.ReadInt32();
											with_3.Text1 = buffer.ReadString();
											with_3.Text2 = buffer.ReadString();
											with_3.Text3 = buffer.ReadString();
											with_3.Text4 = buffer.ReadString();
											with_3.Text5 = buffer.ReadString();
											with_3.Data1 = buffer.ReadInt32();
											with_3.Data2 = buffer.ReadInt32();
											with_3.Data3 = buffer.ReadInt32();
											with_3.Data4 = buffer.ReadInt32();
											with_3.Data5 = buffer.ReadInt32();
											with_3.Data6 = buffer.ReadInt32();
											with_3.ConditionalBranch.CommandList = buffer.ReadInt32();
											with_3.ConditionalBranch.Condition = buffer.ReadInt32();
											with_3.ConditionalBranch.Data1 = buffer.ReadInt32();
											with_3.ConditionalBranch.Data2 = buffer.ReadInt32();
											with_3.ConditionalBranch.Data3 = buffer.ReadInt32();
											with_3.ConditionalBranch.ElseCommandList = buffer.ReadInt32();
											with_3.MoveRouteCount = buffer.ReadInt32();
											if (with_3.MoveRouteCount > 0)
											{
												Array.Resize(ref with_3.MoveRoute, with_3.MoveRouteCount + 1);
												for (w = 1; w <= with_3.MoveRouteCount; w++)
												{
													with_3.MoveRoute[w].Index = buffer.ReadInt32();
													with_3.MoveRoute[w].Data1 = buffer.ReadInt32();
													with_3.MoveRoute[w].Data2 = buffer.ReadInt32();
													with_3.MoveRoute[w].Data3 = buffer.ReadInt32();
													with_3.MoveRoute[w].Data4 = buffer.ReadInt32();
													with_3.MoveRoute[w].Data5 = buffer.ReadInt32();
													with_3.MoveRoute[w].Data6 = buffer.ReadInt32();
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
			buffer.Dispose();
			
		}
		
		public static void Packet_EventChat(ref byte[] data)
		{
			int i = 0;
			int choices = 0;
			ByteStream buffer = new ByteStream(data);
			EventReplyId = buffer.ReadInt32();
			EventReplyPage = buffer.ReadInt32();
			EventChatFace = buffer.ReadInt32();
			EventText = buffer.ReadString();
			if (string.IsNullOrEmpty(EventText))
			{
				EventText = " ";
			}
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
				for (i = 1; i <= choices; i++)
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
			{
				HoldPlayer = true;
			}
			else
			{
				HoldPlayer = false;
			}
			
			buffer.Dispose();
			
		}
		
		public static void Packet_PlayBGM(ref byte[] data)
		{
			string music = "";
			ByteStream buffer = new ByteStream(data);
			music = buffer.ReadString();
			
			C_Sound.PlayMusic(music);
			
			buffer.Dispose();
		}
		
		public static void Packet_FadeOutBGM(ref byte[] data)
		{
			C_Sound.CurMusic = "";
			C_Sound.FadeOutSwitch = true;
		}
		
		public static void Packet_PlaySound(ref byte[] data)
		{
			string sound = "";
			ByteStream buffer = new ByteStream(data);
			sound = buffer.ReadString();
			
			C_Sound.PlaySound(sound);
			
			buffer.Dispose();
		}
		
		public static void Packet_StopSound(ref byte[] data)
		{
			C_Sound.StopSound();
		}
		
		public static void Packet_SpecialEffect(ref byte[] data)
		{
			int effectType = 0;
			ByteStream buffer = new ByteStream(data);
			effectType = buffer.ReadInt32();
			
			switch (effectType)
			{
				case C_Constants.EffectTypeFadein:
					C_Variables.UseFade = true;
					C_Variables.FadeType = 1;
					C_Variables.FadeAmount = 0;
					break;
				case C_Constants.EffectTypeFadeout:
					C_Variables.UseFade = true;
					C_Variables.FadeType = 0;
					C_Variables.FadeAmount = 255;
					break;
				case C_Constants.EffectTypeFlash:
					C_Variables.FlashTimer = C_General.GetTickCount() + 150;
					break;
				case C_Constants.EffectTypeFog:
					C_Weather.CurrentFog = buffer.ReadInt32();
					C_Weather.CurrentFogSpeed = buffer.ReadInt32();
					C_Weather.CurrentFogOpacity = buffer.ReadInt32();
					break;
				case C_Constants.EffectTypeWeather:
					C_Weather.CurrentWeather = buffer.ReadInt32();
					C_Weather.CurrentWeatherIntensity = buffer.ReadInt32();
					break;
				case C_Constants.EffectTypeTint:
					C_Maps.Map.HasMapTint = (byte) 1;
					C_Weather.CurrentTintR = buffer.ReadInt32();
					C_Weather.CurrentTintG = buffer.ReadInt32();
					C_Weather.CurrentTintB = buffer.ReadInt32();
					C_Weather.CurrentTintA = buffer.ReadInt32();
					break;
			}
			
			buffer.Dispose();
		}
		
#endregion
		
#region Outgoing Packets
		
		public static void RequestSwitchesAndVariables()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestSwitchesAndVariables);
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
		}
		
		public static void SendSwitchesAndVariables()
		{
			int i = 0;
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSwitchesAndVariables);
			
			for (i = 1; i <= MaxSwitches; i++)
			{
				buffer.WriteString(Switches[i].Trim());
			}
			for (i = 1; i <= MaxVariables; i++)
			{
				buffer.WriteString(Variables[i].Trim());
			}
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
		}
		
#endregion
		
#region Drawing...
		
		public static void EditorEvent_DrawGraphic()
		{
			Types.Rect sRect = new Types.Rect();
			Types.Rect dRect = new Types.Rect();
			Bitmap targetBitmap = default(Bitmap); //Bitmap we draw to
			Bitmap sourceBitmap = default(Bitmap); //This is our sprite or tileset that we are drawing from
			Graphics g = default(Graphics); //This is our graphics class that helps us draw to the targetBitmap
			
			if (FrmEditor_Events.Default.picGraphicSel.Visible)
			{
				switch (FrmEditor_Events.Default.cmbGraphic.SelectedIndex)
				{
					case 0:
						//None
						FrmEditor_Events.Default.picGraphicSel.BackgroundImage = null;
						break;
					case 1:
						if (FrmEditor_Events.Default.nudGraphic.Value > 0 && FrmEditor_Events.Default.nudGraphic.Value <= C_Graphics.NumCharacters)
						{
							//Load character from Contents into our sourceBitmap
							sourceBitmap = new Bitmap(Application.StartupPath + "/Data/graphics/characters/" + System.Convert.ToString(FrmEditor_Events.Default.nudGraphic.Value) +".png");
							targetBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height); //Create our target Bitmap
							
							g = Graphics.FromImage(targetBitmap);
							//This is the section we are pulling from the source graphic
							Rectangle sourceRect = new Rectangle(0, 0, System.Convert.ToInt32((double) sourceBitmap.Width / 4), System.Convert.ToInt32((double) sourceBitmap.Height / 4));
							//This is the rectangle in the target graphic we want to render to
							Rectangle destRect = new Rectangle(0, 0, System.Convert.ToInt32((double) targetBitmap.Width / 4), System.Convert.ToInt32((double) targetBitmap.Height / 4));
							
							g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel);
							
							g.DrawRectangle(Pens.Red, new Rectangle(GraphicSelX * C_Constants.PicX, GraphicSelY * C_Constants.PicY, GraphicSelX2 * C_Constants.PicX, GraphicSelY2 * C_Constants.PicY));
							
							FrmEditor_Events.Default.picGraphicSel.Width = targetBitmap.Width;
							FrmEditor_Events.Default.picGraphicSel.Height = targetBitmap.Height;
							FrmEditor_Events.Default.picGraphicSel.Visible = true;
							FrmEditor_Events.Default.picGraphicSel.BackgroundImage = targetBitmap;
							FrmEditor_Events.Default.picGraphic.BackgroundImage = targetBitmap;
							
							g.Dispose();
						}
						else
						{
							FrmEditor_Events.Default.picGraphicSel.BackgroundImage = null;
							return;
						}
						break;
					case 2:
						if (FrmEditor_Events.Default.nudGraphic.Value > 0 && FrmEditor_Events.Default.nudGraphic.Value <= C_Graphics.NumTileSets)
						{
							//Load tilesheet from Contents into our sourceBitmap
							sourceBitmap = new Bitmap(Application.StartupPath + "/Data/graphics/tilesets/" + System.Convert.ToString(FrmEditor_Events.Default.nudGraphic.Value) +".png");
							targetBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height); //Create our target Bitmap
							
							if (TmpEvent.Pages[CurPageNum].GraphicX2 == 0 && TmpEvent.Pages[CurPageNum].GraphicY2 == 0)
							{
								sRect.Top = TmpEvent.Pages[CurPageNum].GraphicY * 32;
								sRect.Left = TmpEvent.Pages[CurPageNum].GraphicX * 32;
								sRect.Bottom = sRect.Top + 32;
								sRect.Right = sRect.Left + 32;
								
								dRect.Top = System.Convert.ToInt32(((double) 193 / 2) - ((double) (sRect.Bottom - sRect.Top) / 2));
								dRect.Bottom = dRect.Top + (sRect.Bottom - sRect.Top);
								dRect.Left = System.Convert.ToInt32(((double) 120 / 2) - ((double) (sRect.Right - sRect.Left) / 2));
								dRect.Right = dRect.Left + (sRect.Right - sRect.Left);
							}
							else
							{
								sRect.Top = TmpEvent.Pages[CurPageNum].GraphicY * 32;
								sRect.Left = TmpEvent.Pages[CurPageNum].GraphicX * 32;
								sRect.Bottom = sRect.Top + ((TmpEvent.Pages[CurPageNum].GraphicY2 - TmpEvent.Pages[CurPageNum].GraphicY) * 32);
								sRect.Right = sRect.Left + ((TmpEvent.Pages[CurPageNum].GraphicX2 - TmpEvent.Pages[CurPageNum].GraphicX) * 32);
								
								dRect.Top = System.Convert.ToInt32(((double) 193 / 2) - ((double) (sRect.Bottom - sRect.Top) / 2));
								dRect.Bottom = dRect.Top + (sRect.Bottom - sRect.Top);
								dRect.Left = System.Convert.ToInt32(((double) 120 / 2) - ((double) (sRect.Right - sRect.Left) / 2));
								dRect.Right = dRect.Left + (sRect.Right - sRect.Left);
								
							}
							
							g = Graphics.FromImage(targetBitmap);
							
							Rectangle sourceRect = new Rectangle(0, 0, sourceBitmap.Width, sourceBitmap.Height); //This is the section we are pulling from the source graphic
							Rectangle destRect = new Rectangle(0, 0, targetBitmap.Width, targetBitmap.Height); //This is the rectangle in the target graphic we want to render to
							
							g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel);
							
							g.DrawRectangle(Pens.Red, new Rectangle(GraphicSelX * C_Constants.PicX, GraphicSelY * C_Constants.PicY, (GraphicSelX2) * C_Constants.PicX, (GraphicSelY2) * C_Constants.PicY));
							
							g.Dispose();
							
							FrmEditor_Events.Default.picGraphicSel.Width = targetBitmap.Width;
							FrmEditor_Events.Default.picGraphicSel.Height = targetBitmap.Height;
							FrmEditor_Events.Default.picGraphicSel.Visible = true;
							FrmEditor_Events.Default.picGraphicSel.BackgroundImage = targetBitmap;
							// frmEditor_Events.pnlGraphicSelect.Width = targetBitmap.Width
							//frmEditor_Events.pnlGraphicSelect.Height = targetBitmap.Height
						}
						else
						{
							FrmEditor_Events.Default.picGraphicSel.BackgroundImage = null;
							return;
						}
						break;
				}
			}
			else
			{
				if (TmpEvent.PageCount > 0)
				{
					if (TmpEvent.Pages[CurPageNum].GraphicType == ((byte) 0))
					{
						FrmEditor_Events.Default.picGraphicSel.BackgroundImage = null;
					}
					else if (TmpEvent.Pages[CurPageNum].GraphicType == ((byte) 1))
					{
						if (TmpEvent.Pages[CurPageNum].Graphic > 0 && TmpEvent.Pages[CurPageNum].Graphic <= C_Graphics.NumCharacters)
						{
							//Load character from Contents into our sourceBitmap
							sourceBitmap = new Bitmap(Application.StartupPath + C_Constants.GfxPath + "\\characters\\" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].Graphic) +".png");
							targetBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height); //Create our target Bitmap
							
							g = Graphics.FromImage(targetBitmap);
							
							Rectangle sourceRect = new Rectangle(0, 0, System.Convert.ToInt32((double) sourceBitmap.Width / 4), System.Convert.ToInt32((double) sourceBitmap.Height / 4)); //This is the section we are pulling from the source graphic
							Rectangle destRect = new Rectangle(0, 0, System.Convert.ToInt32((double) targetBitmap.Width / 4), System.Convert.ToInt32((double) targetBitmap.Height / 4)); //This is the rectangle in the target graphic we want to render to
							
							g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel);
							
							g.Dispose();
							
							FrmEditor_Events.Default.picGraphic.Width = targetBitmap.Width;
							FrmEditor_Events.Default.picGraphic.Height = targetBitmap.Height;
							FrmEditor_Events.Default.picGraphic.BackgroundImage = targetBitmap;
						}
						else
						{
							FrmEditor_Events.Default.picGraphic.BackgroundImage = null;
							return;
						}
					}
					else if (TmpEvent.Pages[CurPageNum].GraphicType == ((byte) 2))
					{
						if (TmpEvent.Pages[CurPageNum].Graphic > 0 && TmpEvent.Pages[CurPageNum].Graphic <= C_Graphics.NumTileSets)
						{
							//Load tilesheet from Contents into our sourceBitmap
							sourceBitmap = new Bitmap(Application.StartupPath + C_Constants.GfxPath + "tilesets\\" + System.Convert.ToString(TmpEvent.Pages[CurPageNum].Graphic) +".png");
							targetBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height); //Create our target Bitmap
							
							if (TmpEvent.Pages[CurPageNum].GraphicX2 == 0 && TmpEvent.Pages[CurPageNum].GraphicY2 == 0)
							{
								sRect.Top = TmpEvent.Pages[CurPageNum].GraphicY * 32;
								sRect.Left = TmpEvent.Pages[CurPageNum].GraphicX * 32;
								sRect.Bottom = sRect.Top + 32;
								sRect.Right = sRect.Left + 32;
								
								dRect.Top = 0;
								dRect.Bottom = C_Constants.PicY;
								dRect.Left = 0;
								dRect.Right = C_Constants.PicX;
							}
							else
							{
								sRect.Top = TmpEvent.Pages[CurPageNum].GraphicY * 32;
								sRect.Left = TmpEvent.Pages[CurPageNum].GraphicX * 32;
								sRect.Bottom = TmpEvent.Pages[CurPageNum].GraphicY2 * 32;
								sRect.Right = TmpEvent.Pages[CurPageNum].GraphicX2 * 32;
								
								dRect.Top = 0;
								dRect.Bottom = sRect.Bottom;
								dRect.Left = 0;
								dRect.Right = sRect.Right;
								
							}
							
							g = Graphics.FromImage(targetBitmap);
							
							Rectangle sourceRect = new Rectangle(sRect.Left, sRect.Top, sRect.Right, sRect.Bottom); //This is the section we are pulling from the source graphic
							Rectangle destRect = new Rectangle(dRect.Left, dRect.Top, dRect.Right, dRect.Bottom); //This is the rectangle in the target graphic we want to render to
							
							g.DrawImage(sourceBitmap, destRect, sourceRect, GraphicsUnit.Pixel);
							
							g.Dispose();
							
							FrmEditor_Events.Default.picGraphic.Width = targetBitmap.Width;
							FrmEditor_Events.Default.picGraphic.Height = targetBitmap.Height;
							FrmEditor_Events.Default.picGraphic.BackgroundImage = targetBitmap;
						}
					}
				}
			}
			
		}
		
		internal static void DrawEvents()
		{
			Rectangle rec = new Rectangle();
			int width;
			int height;
			int i = 0;
			int x = 0;
			int y = 0;
			int tX = 0;
			int tY = 0;
			
			if (C_Maps.Map.EventCount <= 0)
			{
				return;
			}
			for (i = 1; i <= C_Maps.Map.EventCount; i++)
			{
				width = 32;
				height = 32;
				x = C_Maps.Map.Events[i].X * 32;
				y = C_Maps.Map.Events[i].Y * 32;
				if (C_Maps.Map.Events[i].PageCount <= 0)
				{
					rec.Y = 0;
					rec.Height = C_Constants.PicY;
					rec.X = 0;
					rec.Width = C_Constants.PicX;
					
					RectangleShape rec2 = new RectangleShape() {
							OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.Blue),
							OutlineThickness = 0.6F,
							FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
							Size = new Vector2f(rec.Width, rec.Height),
							Position = new Vector2f(C_Graphics.ConvertMapX(C_Variables.CurX * C_Constants.PicX), C_Graphics.ConvertMapY(C_Variables.CurY * C_Constants.PicY))
						};
					C_Graphics.GameWindow.Draw(rec2);
					goto nextevent;
				}
				x = C_Graphics.ConvertMapX(x);
				y = C_Graphics.ConvertMapY(y);
				if (i > C_Maps.Map.EventCount)
				{
					return;
				}
				if (1 > C_Maps.Map.Events[i].PageCount)
				{
					return;
				}
				if (C_Maps.Map.Events[i].Pages[1].GraphicType == ((byte) 0))
				{
					tX = System.Convert.ToInt32(((x) - 4) + (C_Constants.PicX * 0.5));
					tY = System.Convert.ToInt32(((y) - 7) + (C_Constants.PicY * 0.5));
					C_Text.DrawText(tX, tY, "EV", SFML.Graphics.Color.Green, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
				}
				else if (C_Maps.Map.Events[i].Pages[1].GraphicType == ((byte) 1))
				{
					if (C_Maps.Map.Events[i].Pages[1].Graphic > 0 && C_Maps.Map.Events[i].Pages[1].Graphic <= C_Graphics.NumCharacters)
					{
						if (C_Graphics.CharacterGfxInfo[C_Maps.Map.Events[i].Pages[1].Graphic].IsLoaded == false)
						{
							C_Graphics.LoadTexture(C_Maps.Map.Events[i].Pages[1].Graphic, (byte) 2);
						}
						
						//seeying we still use it, lets update timer
						ref var with_2 = ref C_Graphics.CharacterGfxInfo[C_Maps.Map.Events[i].Pages[1].Graphic];
						with_2.TextureTimer = C_General.GetTickCount() + 100000;
						rec.Y = System.Convert.ToInt32(C_Maps.Map.Events[i].Pages[1].GraphicY * ((double) C_Graphics.CharacterGfxInfo[C_Maps.Map.Events[i].Pages[1].Graphic].Height / 4));
						rec.Height = rec.Y + C_Constants.PicY;
						rec.X = System.Convert.ToInt32(C_Maps.Map.Events[i].Pages[1].GraphicX * ((double) C_Graphics.CharacterGfxInfo[C_Maps.Map.Events[i].Pages[1].Graphic].Width / 4));
						rec.Width = rec.X + C_Constants.PicX;
						
						Sprite tmpSprite = new Sprite(C_Graphics.CharacterGfx[C_Maps.Map.Events[i].Pages[1].Graphic]) {
								TextureRect = new IntRect(rec.X, rec.Y, rec.Width, rec.Height),
								Position = new Vector2f(C_Graphics.ConvertMapX(C_Maps.Map.Events[i].X * C_Constants.PicX), C_Graphics.ConvertMapY(C_Maps.Map.Events[i].Y * C_Constants.PicY))
							};
						C_Graphics.GameWindow.Draw(tmpSprite);
					}
					else
					{
						rec.Y = 0;
						rec.Height = C_Constants.PicY;
						rec.X = 0;
						rec.Width = C_Constants.PicX;
						
						RectangleShape rec2 = new RectangleShape() {
								OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.Blue),
								OutlineThickness = 0.6F,
								FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
								Size = new Vector2f(rec.Width, rec.Height),
								Position = new Vector2f(C_Graphics.ConvertMapX(C_Variables.CurX * C_Constants.PicX), C_Graphics.ConvertMapY(C_Variables.CurY * C_Constants.PicY))
							};
						C_Graphics.GameWindow.Draw(rec2);
					}
				}
				else if (C_Maps.Map.Events[i].Pages[1].GraphicType == ((byte) 2))
				{
					if (C_Maps.Map.Events[i].Pages[1].Graphic > 0 && C_Maps.Map.Events[i].Pages[1].Graphic <= C_Graphics.NumTileSets)
					{
						rec.X = C_Maps.Map.Events[i].Pages[1].GraphicX * 32;
						rec.Width = C_Maps.Map.Events[i].Pages[1].GraphicX2 * 32;
						rec.Y = C_Maps.Map.Events[i].Pages[1].GraphicY * 32;
						rec.Height = C_Maps.Map.Events[i].Pages[1].GraphicY2 * 32;
						
						if (C_Graphics.TileSetTextureInfo[C_Maps.Map.Events[i].Pages[1].Graphic].IsLoaded == false)
						{
							C_Graphics.LoadTexture(C_Maps.Map.Events[i].Pages[1].Graphic, (byte) 1);
						}
						// we use it, lets update timer
						ref var with_6 = ref C_Graphics.TileSetTextureInfo[C_Maps.Map.Events[i].Pages[1].Graphic];
						with_6.TextureTimer = C_General.GetTickCount() + 100000;
						
						if (rec.Height > 32)
						{
							C_Graphics.RenderSprite(C_Graphics.TileSetSprite[C_Maps.Map.Events[i].Pages[1].Graphic], C_Graphics.GameWindow, C_Graphics.ConvertMapX(C_Maps.Map.Events[i].X * C_Constants.PicX), C_Graphics.ConvertMapY(C_Maps.Map.Events[i].Y * C_Constants.PicY) - C_Constants.PicY, rec.X, rec.Y, rec.Width, rec.Height);
						}
						else
						{
							C_Graphics.RenderSprite(C_Graphics.TileSetSprite[C_Maps.Map.Events[i].Pages[1].Graphic], C_Graphics.GameWindow, C_Graphics.ConvertMapX(C_Maps.Map.Events[i].X * C_Constants.PicX), C_Graphics.ConvertMapY(C_Maps.Map.Events[i].Y * C_Constants.PicY), rec.X, rec.Y, rec.Width, rec.Height);
						}
					}
					else
					{
						rec.Y = 0;
						rec.Height = C_Constants.PicY;
						rec.X = 0;
						rec.Width = C_Constants.PicX;
						
						RectangleShape rec2 = new RectangleShape() {
								OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.Blue),
								OutlineThickness = 0.6F,
								FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
								Size = new Vector2f(rec.Width, rec.Height),
								Position = new Vector2f(C_Graphics.ConvertMapX(C_Variables.CurX * C_Constants.PicX), C_Graphics.ConvertMapY(C_Variables.CurY * C_Constants.PicY))
							};
						C_Graphics.GameWindow.Draw(rec2);
					}
				}
nextevent:
				1.GetHashCode();
			}
			
		}
		
		internal static void DrawEvent(int id) // draw on map, outside the editor
		{
			int x = 0;
			int y = 0;
			int width;
			int height;
			Rectangle sRect = new Rectangle();
			int anim = 0;
			int spritetop = 0;
			
			if (C_Maps.Map.MapEvents[id].Visible == 0)
			{
				return;
			}
			
			switch (C_Maps.Map.MapEvents[id].GraphicType)
			{
				case 0:
					return;
				case 1:
					if (C_Maps.Map.MapEvents[id].GraphicNum <= 0 || C_Maps.Map.MapEvents[id].GraphicNum > C_Graphics.NumCharacters)
					{
						return;
					}
					
					// Reset frame
					if (C_Maps.Map.MapEvents[id].Steps == 3)
					{
						anim = 0;
					}
					else if (C_Maps.Map.MapEvents[id].Steps == 1)
					{
						anim = 2;
					}
					
					switch (C_Maps.Map.MapEvents[id].Dir)
					{
						case (int) Enums.DirectionType.Up:
							if (C_Maps.Map.MapEvents[id].YOffset > 8)
							{
								anim = C_Maps.Map.MapEvents[id].Steps;
							}
							break;
						case (int) Enums.DirectionType.Down:
							if (C_Maps.Map.MapEvents[id].YOffset < -8)
							{
								anim = C_Maps.Map.MapEvents[id].Steps;
							}
							break;
						case (int) Enums.DirectionType.Left:
							if (C_Maps.Map.MapEvents[id].XOffset > 8)
							{
								anim = C_Maps.Map.MapEvents[id].Steps;
							}
							break;
						case (int) Enums.DirectionType.Right:
							if (C_Maps.Map.MapEvents[id].XOffset < -8)
							{
								anim = C_Maps.Map.MapEvents[id].Steps;
							}
							break;
					}
					
					// Set the left
					switch (C_Maps.Map.MapEvents[id].ShowDir)
					{
						case (int) Enums.DirectionType.Up:
							spritetop = 3;
							break;
						case (int) Enums.DirectionType.Right:
							spritetop = 2;
							break;
						case (int) Enums.DirectionType.Down:
							spritetop = 0;
							break;
						case (int) Enums.DirectionType.Left:
							spritetop = 1;
							break;
					}
					
					if (C_Maps.Map.MapEvents[id].WalkAnim == 1)
					{
						anim = 0;
					}
					if (C_Maps.Map.MapEvents[id].Moving == 0)
					{
						anim = C_Maps.Map.MapEvents[id].GraphicX;
					}
					
					width = System.Convert.ToInt32((double) C_Graphics.CharacterGfxInfo[C_Maps.Map.MapEvents[id].GraphicNum].Width / 4);
					height = System.Convert.ToInt32((double) C_Graphics.CharacterGfxInfo[C_Maps.Map.MapEvents[id].GraphicNum].Height / 4);
					
					sRect = new Rectangle(System.Convert.ToInt32((anim) * ((double) C_Graphics.CharacterGfxInfo[C_Maps.Map.MapEvents[id].GraphicNum].Width / 4)), System.Convert.ToInt32(spritetop * ((double) C_Graphics.CharacterGfxInfo[C_Maps.Map.MapEvents[id].GraphicNum].Height / 4)), System.Convert.ToInt32((double) C_Graphics.CharacterGfxInfo[C_Maps.Map.MapEvents[id].GraphicNum].Width / 4), System.Convert.ToInt32((double) C_Graphics.CharacterGfxInfo[C_Maps.Map.MapEvents[id].GraphicNum].Height / 4));
					// Calculate the X
					x = System.Convert.ToInt32(C_Maps.Map.MapEvents[id].X * C_Constants.PicX + C_Maps.Map.MapEvents[id].XOffset - (((double) C_Graphics.CharacterGfxInfo[C_Maps.Map.MapEvents[id].GraphicNum].Width / 4 - 32) / 2));
					
					// Is the player's height more than 32..
					if ((C_Graphics.CharacterGfxInfo[C_Maps.Map.MapEvents[id].GraphicNum].Height * 4) > 32)
					{
						// Create a 32 pixel offset for larger sprites
						y = System.Convert.ToInt32(C_Maps.Map.MapEvents[id].Y * C_Constants.PicY + C_Maps.Map.MapEvents[id].YOffset - (((double) C_Graphics.CharacterGfxInfo[C_Maps.Map.MapEvents[id].GraphicNum].Height / 4) - 32));
					}
					else
					{
						// Proceed as normal
						y = C_Maps.Map.MapEvents[id].Y * C_Constants.PicY + C_Maps.Map.MapEvents[id].YOffset;
					}
					// render the actual sprite
					C_Graphics.DrawCharacter(C_Maps.Map.MapEvents[id].GraphicNum, x, y, sRect);
					
					if (C_Maps.Map.MapEvents[id].Questnum > 0)
					{
						if (C_Quest.CanStartQuest(C_Maps.Map.MapEvents[id].Questnum))
						{
							if (C_Types.Player[C_Variables.Myindex].PlayerQuest[C_Maps.Map.MapEvents[id].Questnum].Status == (int) Enums.QuestStatusType.NotStarted)
							{
								C_Graphics.DrawEmotes(x, y, 5);
							}
						}
						else if (C_Types.Player[C_Variables.Myindex].PlayerQuest[C_Maps.Map.MapEvents[id].Questnum].Status == (int) Enums.QuestStatusType.Started)
						{
							C_Graphics.DrawEmotes(x, y, 9);
						}
					}
					break;
				case 2:
					if (C_Maps.Map.MapEvents[id].GraphicNum < 1 || C_Maps.Map.MapEvents[id].GraphicNum > C_Graphics.NumTileSets)
					{
						return;
					}
					if (C_Maps.Map.MapEvents[id].GraphicY2 > 0 || C_Maps.Map.MapEvents[id].GraphicX2 > 0)
					{
						sRect.X = C_Maps.Map.MapEvents[id].GraphicX * 32;
						sRect.Y = C_Maps.Map.MapEvents[id].GraphicY * 32;
						sRect.Width = C_Maps.Map.MapEvents[id].GraphicX2 * 32;
						sRect.Height = C_Maps.Map.MapEvents[id].GraphicY2 * 32;
					}
					else
					{
						sRect.X = C_Maps.Map.MapEvents[id].GraphicY * 32;
						sRect.Height = sRect.Top + 32;
						sRect.Y = C_Maps.Map.MapEvents[id].GraphicX * 32;
						sRect.Width = sRect.Left + 32;
					}
					
					if (C_Graphics.TileSetTextureInfo[C_Maps.Map.MapEvents[id].GraphicNum].IsLoaded == false)
					{
						C_Graphics.LoadTexture(C_Maps.Map.MapEvents[id].GraphicNum, (byte) 1);
					}
					// we use it, lets update timer
					ref var with_3 = ref C_Graphics.TileSetTextureInfo[C_Maps.Map.MapEvents[id].GraphicNum];
					with_3.TextureTimer = C_General.GetTickCount() + 100000;
					
					x = C_Maps.Map.MapEvents[id].X * 32;
					y = C_Maps.Map.MapEvents[id].Y * 32;
					x = System.Convert.ToInt32(x - ((double) (sRect.Right - sRect.Left) / 2));
					y = y - (sRect.Bottom - sRect.Top) + 32;
					
					if (C_Maps.Map.MapEvents[id].GraphicY2 > 1)
					{
						C_Graphics.RenderSprite(C_Graphics.TileSetSprite[C_Maps.Map.MapEvents[id].GraphicNum], C_Graphics.GameWindow, C_Graphics.ConvertMapX(C_Maps.Map.MapEvents[id].X * C_Constants.PicX), C_Graphics.ConvertMapY(C_Maps.Map.MapEvents[id].Y * C_Constants.PicY) - C_Constants.PicY, sRect.Left, sRect.Top, sRect.Width, sRect.Height);
					}
					else
					{
						C_Graphics.RenderSprite(C_Graphics.TileSetSprite[C_Maps.Map.MapEvents[id].GraphicNum], C_Graphics.GameWindow, C_Graphics.ConvertMapX(C_Maps.Map.MapEvents[id].X * C_Constants.PicX), C_Graphics.ConvertMapY(C_Maps.Map.MapEvents[id].Y * C_Constants.PicY), sRect.Left, sRect.Top, sRect.Width, sRect.Height);
					}
					
					if (C_Maps.Map.MapEvents[id].Questnum > 0)
					{
						if (C_Quest.CanStartQuest(C_Maps.Map.MapEvents[id].Questnum))
						{
							if (C_Types.Player[C_Variables.Myindex].PlayerQuest[C_Maps.Map.MapEvents[id].Questnum].Status == (int) Enums.QuestStatusType.NotStarted)
							{
								C_Graphics.DrawEmotes(x, y, 5);
							}
						}
						else if (C_Types.Player[C_Variables.Myindex].PlayerQuest[C_Maps.Map.MapEvents[id].Questnum].Status == (int) Enums.QuestStatusType.Started)
						{
							C_Graphics.DrawEmotes(x, y, 9);
						}
					}
					break;
			}
			
		}
		
		internal static void DrawEventChat()
		{
			string temptext = "";
			List<string> txtArray = new List<string>();
			int tmpY = 0;
			
			//first render panel
			C_Graphics.RenderSprite(C_Graphics.EventChatSprite, C_Graphics.GameWindow, C_UpdateUI.EventChatX, C_UpdateUI.EventChatY, 0, 0, C_Graphics.EventChatGfxInfo.Width, C_Graphics.EventChatGfxInfo.Height);
			
			//face
			if (EventChatFace > 0 && EventChatFace < C_Graphics.NumFaces)
			{
				//render face
				if (C_Graphics.FacesGfxInfo[EventChatFace].IsLoaded == false)
				{
					C_Graphics.LoadTexture(EventChatFace, (byte) 7);
				}
				
				//seeying we still use it, lets update timer
				ref var with_2 = ref C_Graphics.FacesGfxInfo[EventChatFace];
				with_2.TextureTimer = C_General.GetTickCount() + 100000;
				C_Graphics.RenderSprite(C_Graphics.FacesSprite[EventChatFace], C_Graphics.GameWindow, C_UpdateUI.EventChatX + 12, C_UpdateUI.EventChatY + 14, 0, 0, C_Graphics.FacesGfxInfo[EventChatFace].Width, C_Graphics.FacesGfxInfo[EventChatFace].Height);
				C_UpdateUI.EventChatTextX = 113;
			}
			else
			{
				C_UpdateUI.EventChatTextX = 14;
			}
			
			//EventPrompt
			txtArray = C_Text.WordWrap(EventText, 45, C_Text.WrapMode.Characters, C_Text.WrapType.BreakWord, 13);
			for (var i = 0; i <= txtArray.Count; i++)
			{
				if (i == txtArray.Count)
				{
					break;
				}
				//draw text
				C_Text.DrawText(C_UpdateUI.EventChatX + C_UpdateUI.EventChatTextX, C_UpdateUI.EventChatY + C_UpdateUI.EventChatTextY + tmpY, Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtArray[i].Replace("\r\n", ""))), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 13);
				tmpY = tmpY + 20;
			}
			
			if (EventChatType == 1)
			{
				
				if (EventChoiceVisible[1])
				{
					//Response1
					temptext = EventChoices[1];
					C_Text.DrawText(C_UpdateUI.EventChatX + 10, C_UpdateUI.EventChatY + 124, temptext.Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 13);
				}
				
				if (EventChoiceVisible[2])
				{
					//Response2
					temptext = EventChoices[2];
					C_Text.DrawText(C_UpdateUI.EventChatX + 10, C_UpdateUI.EventChatY + 146, temptext.Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 13);
				}
				
				if (EventChoiceVisible[3])
				{
					//Response3
					temptext = EventChoices[3];
					C_Text.DrawText(C_UpdateUI.EventChatX + 226, C_UpdateUI.EventChatY + 124, temptext.Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 13);
				}
				
				if (EventChoiceVisible[4])
				{
					//Response4
					temptext = EventChoices[4];
					C_Text.DrawText(C_UpdateUI.EventChatX + 226, C_UpdateUI.EventChatY + 146, temptext.Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 13);
				}
			}
			else
			{
				temptext = Strings.Get("events", "continue");
				C_Text.DrawText(C_UpdateUI.EventChatX + 410, C_UpdateUI.EventChatY + 156, temptext.Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 13);
			}
			
			
		}
		
#endregion
		
#region Misc
		
		public static void ProcessEventMovement(int id)
		{
			
			if (id > C_Maps.Map.EventCount)
			{
				return;
			}
			if (id > C_Maps.Map.MapEvents.Length)
			{
				return;
			}
			
			if (C_Maps.Map.MapEvents[id].Moving == 1)
			{
				switch (C_Maps.Map.MapEvents[id].Dir)
				{
					case (int) Enums.DirectionType.Up:
						C_Maps.Map.MapEvents[id].YOffset = System.Convert.ToInt32(C_Maps.Map.MapEvents[id].YOffset - (((double) C_Variables.ElapsedTime / 1000) * (C_Maps.Map.MapEvents[id].MovementSpeed * C_Constants.SizeX)));
						if (C_Maps.Map.MapEvents[id].YOffset < 0)
						{
							C_Maps.Map.MapEvents[id].YOffset = 0;
						}
						break;
					case (int) Enums.DirectionType.Down:
						C_Maps.Map.MapEvents[id].YOffset = System.Convert.ToInt32(C_Maps.Map.MapEvents[id].YOffset + (((double) C_Variables.ElapsedTime / 1000) * (C_Maps.Map.MapEvents[id].MovementSpeed * C_Constants.SizeX)));
						if (C_Maps.Map.MapEvents[id].YOffset > 0)
						{
							C_Maps.Map.MapEvents[id].YOffset = 0;
						}
						break;
					case (int) Enums.DirectionType.Left:
						C_Maps.Map.MapEvents[id].XOffset = System.Convert.ToInt32(C_Maps.Map.MapEvents[id].XOffset - (((double) C_Variables.ElapsedTime / 1000) * (C_Maps.Map.MapEvents[id].MovementSpeed * C_Constants.SizeX)));
						if (C_Maps.Map.MapEvents[id].XOffset < 0)
						{
							C_Maps.Map.MapEvents[id].XOffset = 0;
						}
						break;
					case (int) Enums.DirectionType.Right:
						C_Maps.Map.MapEvents[id].XOffset = System.Convert.ToInt32(C_Maps.Map.MapEvents[id].XOffset + (((double) C_Variables.ElapsedTime / 1000) * (C_Maps.Map.MapEvents[id].MovementSpeed * C_Constants.SizeX)));
						if (C_Maps.Map.MapEvents[id].XOffset > 0)
						{
							C_Maps.Map.MapEvents[id].XOffset = 0;
						}
						break;
				}
				// Check if completed walking over to the next tile
				if (C_Maps.Map.MapEvents[id].Moving > 0)
				{
					if (C_Maps.Map.MapEvents[id].Dir == (int) Enums.DirectionType.Right || C_Maps.Map.MapEvents[id].Dir == (int) Enums.DirectionType.Down)
					{
						if ((C_Maps.Map.MapEvents[id].XOffset >= 0) && (C_Maps.Map.MapEvents[id].YOffset >= 0))
						{
							C_Maps.Map.MapEvents[id].Moving = 0;
							if (C_Maps.Map.MapEvents[id].Steps == 1)
							{
								C_Maps.Map.MapEvents[id].Steps = 3;
							}
							else
							{
								C_Maps.Map.MapEvents[id].Steps = 1;
							}
						}
					}
					else
					{
						if ((C_Maps.Map.MapEvents[id].XOffset <= 0) && (C_Maps.Map.MapEvents[id].YOffset <= 0))
						{
							C_Maps.Map.MapEvents[id].Moving = 0;
							if (C_Maps.Map.MapEvents[id].Steps == 1)
							{
								C_Maps.Map.MapEvents[id].Steps = 3;
							}
							else
							{
								C_Maps.Map.MapEvents[id].Steps = 1;
							}
						}
					}
				}
			}
			
		}
		
		internal static dynamic GetColorString(int color)
		{
			
			switch (color)
			{
				case 0:
					return "Black";
					break;
				case 1:
					return "Blue";
					break;
				case 2:
					return "Green";
					break;
				case 3:
					return "Cyan";
					break;
				case 4:
					return "Red";
					break;
				case 5:
					return "Magenta";
					break;
				case 6:
					return "Brown";
					break;
				case 7:
					return "Grey";
					break;
				case 8:
					return "Dark Grey";
					break;
				case 9:
					return "Bright Blue";
					break;
				case 10:
					return "Bright Green";
					break;
				case 11:
					return "Bright Cyan";
					break;
				case 12:
					return "Bright Red";
					break;
				case 13:
					return "Pink";
					break;
				case 14:
					return "Yellow";
					break;
				case 15:
					return "White";
					break;
				default:
					return "Black";
					break;
			}
			
		}
		
		public static void ClearEventChat()
		{
			int i = 0;
			
			if (AnotherChat == 1)
			{
				for (i = 1; i <= 4; i++)
				{
					EventChoiceVisible[i] = false;
				}
				EventText = "";
				EventChatType = 1;
				EventChatTimer = C_General.GetTickCount() + 100;
			}
			else if (AnotherChat == 2)
			{
				for (i = 1; i <= 4; i++)
				{
					EventChoiceVisible[i] = false;
				}
				EventText = "";
				EventChatType = 1;
				EventChatTimer = C_General.GetTickCount() + 100;
			}
			else
			{
				EventChat = false;
			}
			C_UpdateUI.PnlEventChatVisible = false;
		}
		
		internal static void ResetEventdata()
		{
			for (var i = 0; i <= C_Maps.Map.EventCount; i++)
			{
				C_Maps.Map.MapEvents = new C_EventSystem.MapEventRec[C_Maps.Map.EventCount + 1];
				C_Maps.Map.CurrentEvents = 0;
				ref var with_1 = ref C_Maps.Map.MapEvents[(int) i];
				with_1.Name = "";
				with_1.Dir = 0;
				with_1.ShowDir = 0;
				with_1.GraphicNum = 0;
				with_1.GraphicType = 0;
				with_1.GraphicX = 0;
				with_1.GraphicX2 = 0;
				with_1.GraphicY = 0;
				with_1.GraphicY2 = 0;
				with_1.MovementSpeed = 0;
				with_1.Moving = 0;
				with_1.X = 0;
				with_1.Y = 0;
				with_1.XOffset = 0;
				with_1.YOffset = 0;
				with_1.Position = 0;
				with_1.Visible = 0;
				with_1.WalkAnim = 0;
				with_1.DirFix = 0;
				with_1.WalkThrough = 0;
				with_1.ShowName = 0;
				with_1.Questnum = 0;
			}
		}
		
#endregion
		
	}
}
