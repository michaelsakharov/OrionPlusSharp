
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using ASFW;
using Engine;


namespace Engine
{
	internal sealed class C_Quest
	{
		
#region Global Info
		
		//Constants
		internal const int MaxQuests = 250;
		
		//Friend Const MAX_TASKS As Byte = 10
		//Friend Const MAX_REQUIREMENTS As Byte = 10
		internal const byte EditorTasks = 7;
		
		//Friend Const QUEST_TYPE_GOSLAY As Byte = 1
		//Friend Const QUEST_TYPE_GOCOLLECT As Byte = 2
		//Friend Const QUEST_TYPE_GOTALK As Byte = 3
		//Friend Const QUEST_TYPE_GOREACH As Byte = 4
		//Friend Const QUEST_TYPE_GOGIVE As Byte = 5
		//Friend Const QUEST_TYPE_GOKILL As Byte = 6
		//Friend Const QUEST_TYPE_GOGATHER As Byte = 7
		//Friend Const QUEST_TYPE_GOFETCH As Byte = 8
		//Friend Const QUEST_TYPE_TALKEVENT As Byte = 9
		
		//Friend Const QUEST_NOT_STARTED As Byte = 0
		//Friend Const QUEST_STARTED As Byte = 1
		//Friend Const QUEST_COMPLETED As Byte = 2
		//Friend Const QUEST_REPEATABLE As Byte = 3
		
		internal static int QuestLogPage;
		internal static string[] QuestNames = new string[MaxActivequests + 1];
		
		internal static bool[] QuestChanged = new bool[MaxQuests + 1];
		
		internal static bool QuestEditorShow;
		
		//questlog variables
		
		internal const int MaxActivequests = 10;
		
		internal static int QuestLogX = 150;
		internal static int QuestLogY = 100;
		
		internal static bool PnlQuestLogVisible;
		internal static int SelectedQuest;
		internal static string QuestTaskLogText = "";
		internal static string ActualTaskText = "";
		internal static string QuestDialogText = "";
		internal static string QuestStatus2Text = "";
		internal static string AbandonQuestText = "";
		internal static bool AbandonQuestVisible;
		internal static string QuestRequirementsText = "";
		internal static string[] QuestRewardsText;
		
		//here we store temp info because off UpdateUI >.<
		internal static bool UpdateQuestWindow;
		
		internal static bool UpdateQuestChat;
		internal static int QuestNum;
		internal static int QuestNumForStart;
		internal static string QuestMessage;
		internal static int QuestAcceptTag;
		
		//Types
		internal static QuestRec[] Quest = new QuestRec[MaxQuests + 1];
		
		public struct PlayerQuestRec
		{
			public int Status; //0=not started, 1=started, 2=completed, 3=completed but repeatable
			public int ActualTask;
			public int CurrentCount; //Used to handle the Amount property
		}
		
		public struct TaskRec
		{
			public int Order;
			public int Npc;
			public int Item;
			public int Map;
			public int Resource;
			public int Amount;
			public string Speech;
			public string TaskLog;
			public byte QuestEnd;
			public int TaskType;
		}
		
		public struct QuestRec
		{
			public string Name;
			public string QuestLog;
			public byte Repeat;
			public byte Cancelable;
			
			public int ReqCount;
			public int[] Requirement; //1=item, 2=quest, 3=class
			public int[] RequirementIndex;
			
			public int QuestGiveItem; //Todo: make this dynamic
			public int QuestGiveItemValue;
			public int QuestRemoveItem;
			public int QuestRemoveItemValue;
			
			public string[] Chat;
			
			public int RewardCount;
			public int[] RewardItem;
			public int[] RewardItemAmount;
			public int RewardExp;
			
			public int TaskCount;
			public TaskRec[] Task;
			
		}
		
#endregion
		
#region DataBase
		
		public static void ClearQuest(int questNum)
		{
			int I = 0;
			
			// clear the Quest
			Quest[questNum].Name = "";
			Quest[questNum].QuestLog = "";
			Quest[questNum].Repeat = (byte) 0;
			Quest[questNum].Cancelable = (byte) 0;
			
			Quest[questNum].ReqCount = 0;
			Quest[questNum].Requirement = new int[Quest[questNum].ReqCount + 1];
			Quest[questNum].RequirementIndex = new int[Quest[questNum].ReqCount + 1];
			for (I = 1; I <= Quest[questNum].ReqCount; I++)
			{
				Quest[questNum].Requirement[I] = 0;
				Quest[questNum].RequirementIndex[I] = 0;
			}
			
			Quest[questNum].QuestGiveItem = 0;
			Quest[questNum].QuestGiveItemValue = 0;
			Quest[questNum].QuestRemoveItem = 0;
			Quest[questNum].QuestRemoveItemValue = 0;
			
			Quest[questNum].Chat = new string[4];
			for (I = 1; I <= 3; I++)
			{
				Quest[questNum].Chat[I] = "";
			}
			
			Quest[questNum].RewardCount = 0;
			Quest[questNum].RewardItem = new int[Quest[questNum].RewardCount + 1];
			Quest[questNum].RewardItemAmount = new int[Quest[questNum].RewardCount + 1];
			for (I = 1; I <= Quest[questNum].RewardCount; I++)
			{
				Quest[questNum].RewardItem[I] = 0;
				Quest[questNum].RewardItemAmount[I] = 0;
			}
			Quest[questNum].RewardExp = 0;
			
			Quest[questNum].TaskCount = 0;
			Quest[questNum].Task = new C_Quest.TaskRec[Quest[questNum].TaskCount + 1];
			for (I = 1; I <= Quest[questNum].TaskCount; I++)
			{
				Quest[questNum].Task[I].Order = 0;
				Quest[questNum].Task[I].Npc = 0;
				Quest[questNum].Task[I].Item = 0;
				Quest[questNum].Task[I].Map = 0;
				Quest[questNum].Task[I].Resource = 0;
				Quest[questNum].Task[I].Amount = 0;
				Quest[questNum].Task[I].Speech = "";
				Quest[questNum].Task[I].TaskLog = "";
				Quest[questNum].Task[I].QuestEnd = (byte) 0;
				Quest[questNum].Task[I].TaskType = 0;
			}
			
		}
		
		public static void ClearQuests()
		{
			int I = 0;
			
			Quest = new C_Quest.QuestRec[MaxQuests + 1];
			
			for (I = 1; I <= MaxQuests; I++)
			{
				ClearQuest(I);
			}
		}
		
#endregion
		
#region Incoming Packets
		
		internal static void Packet_QuestEditor(ref byte[] data)
		{
			QuestEditorShow = true;
		}
		
		internal static void Packet_UpdateQuest(ref byte[] data)
		{
			int questNum = 0;
			ByteStream buffer = new ByteStream(data);
			questNum = buffer.ReadInt32();
			
			// Update the Quest
			Quest[questNum].Name = buffer.ReadString();
			Quest[questNum].QuestLog = buffer.ReadString();
			Quest[questNum].Repeat = (byte) (buffer.ReadInt32());
			Quest[questNum].Cancelable = (byte) (buffer.ReadInt32());
			
			Quest[questNum].ReqCount = buffer.ReadInt32();
			Quest[questNum].Requirement = new int[Quest[questNum].ReqCount + 1];
			Quest[questNum].RequirementIndex = new int[Quest[questNum].ReqCount + 1];
			for (var I = 1; I <= Quest[questNum].ReqCount; I++)
			{
				Quest[questNum].Requirement[(int) I] = buffer.ReadInt32();
				Quest[questNum].RequirementIndex[(int) I] = buffer.ReadInt32();
			}
			
			Quest[questNum].QuestGiveItem = buffer.ReadInt32();
			Quest[questNum].QuestGiveItemValue = buffer.ReadInt32();
			Quest[questNum].QuestRemoveItem = buffer.ReadInt32();
			Quest[questNum].QuestRemoveItemValue = buffer.ReadInt32();
			
			for (var I = 1; I <= 3; I++)
			{
				Quest[questNum].Chat[(int) I] = buffer.ReadString();
			}
			
			Quest[questNum].RewardCount = buffer.ReadInt32();
			Quest[questNum].RewardItem = new int[Quest[questNum].RewardCount + 1];
			Quest[questNum].RewardItemAmount = new int[Quest[questNum].RewardCount + 1];
			for (var i = 1; i <= Quest[questNum].RewardCount; i++)
			{
				Quest[questNum].RewardItem[(int) i] = buffer.ReadInt32();
				Quest[questNum].RewardItemAmount[(int) i] = buffer.ReadInt32();
			}
			
			Quest[questNum].RewardExp = buffer.ReadInt32();
			
			Quest[questNum].TaskCount = buffer.ReadInt32();
			Quest[questNum].Task = new C_Quest.TaskRec[Quest[questNum].TaskCount + 1];
			for (var I = 1; I <= Quest[questNum].TaskCount; I++)
			{
				Quest[questNum].Task[(int) I].Order = buffer.ReadInt32();
				Quest[questNum].Task[(int) I].Npc = buffer.ReadInt32();
				Quest[questNum].Task[(int) I].Item = buffer.ReadInt32();
				Quest[questNum].Task[(int) I].Map = buffer.ReadInt32();
				Quest[questNum].Task[(int) I].Resource = buffer.ReadInt32();
				Quest[questNum].Task[(int) I].Amount = buffer.ReadInt32();
				Quest[questNum].Task[(int) I].Speech = buffer.ReadString();
				Quest[questNum].Task[(int) I].TaskLog = buffer.ReadString();
				Quest[questNum].Task[(int) I].QuestEnd = (byte) (buffer.ReadInt32());
				Quest[questNum].Task[(int) I].TaskType = buffer.ReadInt32();
			}
			
			buffer.Dispose();
		}
		
		internal static void Packet_PlayerQuest(ref byte[] data)
		{
			int questNum = 0;
			ByteStream buffer = new ByteStream(data);
			questNum = buffer.ReadInt32();
			
			C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].Status = buffer.ReadInt32();
			C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].ActualTask = buffer.ReadInt32();
			C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].CurrentCount = buffer.ReadInt32();
			
			RefreshQuestLog();
			
			buffer.Dispose();
		}
		
		internal static void Packet_PlayerQuests(ref byte[] data)
		{
			int I = 0;
			ByteStream buffer = new ByteStream(data);
			for (I = 1; I <= MaxQuests; I++)
			{
				C_Types.Player[C_Variables.Myindex].PlayerQuest[I].Status = buffer.ReadInt32();
				C_Types.Player[C_Variables.Myindex].PlayerQuest[I].ActualTask = buffer.ReadInt32();
				C_Types.Player[C_Variables.Myindex].PlayerQuest[I].CurrentCount = buffer.ReadInt32();
			}
			
			RefreshQuestLog();
			
			buffer.Dispose();
		}
		
		internal static void Packet_QuestMessage(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			QuestNum = buffer.ReadInt32();
			QuestMessage = buffer.ReadString().Trim();
			QuestMessage = QuestMessage.Replace("$playername$", C_Player.GetPlayerName(C_Variables.Myindex));
			QuestNumForStart = buffer.ReadInt32();
			
			UpdateQuestChat = true;
			
			buffer.Dispose();
		}
		
#endregion
		
#region Outgoing Packets
		
		public static void SendRequestQuests()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestQuests);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		internal static void UpdateQuestLog()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CQuestLogUpdate);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		internal static void PlayerHandleQuest(int questNum, int order)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CPlayerHandleQuest);
			buffer.WriteInt32(questNum);
			buffer.WriteInt32(order); //1=accept quest, 2=cancel quest
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void QuestReset(int questNum)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CQuestReset);
			buffer.WriteInt32(questNum);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
#endregion
		
#region Support Functions
		
		//Tells if the quest is in progress or not
		internal static bool QuestInProgress(int questNum)
		{
			bool returnValue = false;
			returnValue = false;
			if (questNum < 1 || questNum > MaxQuests)
			{
				return returnValue;
			}
			
			if (C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].Status == (int) Enums.QuestStatusType.Started) //Status=1 means started
			{
				return true;
			}
			return returnValue;
		}
		
		internal static bool QuestCompleted(int questNum)
		{
			bool returnValue = false;
			returnValue = false;
			if (questNum < 1 || questNum > MaxQuests)
			{
				return returnValue;
			}
			
			if (C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].Status == (int) Enums.QuestStatusType.Completed || C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].Status == (int) Enums.QuestStatusType.Repeatable)
			{
				return true;
			}
			return returnValue;
		}
		
		internal static int GetQuestNum(string questName)
		{
			int returnValue = 0;
			int I = 0;
			returnValue = 0;
			
			for (I = 1; I <= MaxQuests; I++)
			{
				if (Quest[I].Name.Trim() == questName.Trim())
				{
					returnValue = I;
					break;
				}
			}
			return returnValue;
		}
		
#endregion
		
#region Misc Functions
		
		internal static bool CanStartQuest(int questNum)
		{
			bool returnValue = false;
			int i = 0;
			
			returnValue = false;
			
			if (questNum < 1 || questNum > MaxQuests)
			{
				return returnValue;
			}
			if (QuestInProgress(questNum))
			{
				return returnValue;
			}
			
			//Check if player has the quest 0 (not started) or 3 (completed but it can be started again)
			if (C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].Status == (int) Enums.QuestStatusType.NotStarted || C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].Status == (int) Enums.QuestStatusType.Repeatable)
			{
				
				for (i = 1; i <= Quest[questNum].ReqCount; i++)
				{
					//Check if item is needed
					if (Quest[questNum].Requirement[i] == 1)
					{
						if (Quest[questNum].RequirementIndex[i] > 0 && Quest[questNum].RequirementIndex[i] <= Constants.MAX_ITEMS)
						{
							if (HasItem(C_Variables.Myindex, System.Convert.ToInt32(Quest[questNum].RequirementIndex[i])) == 0)
							{
								return returnValue;
							}
						}
					}
					
					//Check if previous quest is needed
					if (Quest[questNum].Requirement[i] == 2)
					{
						if (Quest[questNum].RequirementIndex[i] > 0 && Quest[questNum].RequirementIndex[i] <= MaxQuests)
						{
							if (C_Types.Player[C_Variables.Myindex].PlayerQuest[Quest[questNum].RequirementIndex[i]].Status == (int) Enums.QuestStatusType.NotStarted || C_Types.Player[C_Variables.Myindex].PlayerQuest[Quest[questNum].RequirementIndex[i]].Status == (int) Enums.QuestStatusType.Started)
							{
								return returnValue;
							}
						}
					}
					
				}
				
				//Go on :)
				return true;
			}
			else
			{
				return false;
			}
			return returnValue;
		}
		
		internal static bool CanEndQuest(int index, int questNum)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (C_Types.Player[index].PlayerQuest[questNum].ActualTask >= Quest[questNum].Task.Length)
			{
				returnValue = true;
			}
			if (Quest[questNum].Task[C_Types.Player[index].PlayerQuest[questNum].ActualTask].QuestEnd == 1)
			{
				return true;
			}
			return returnValue;
		}
		
		public static int HasItem(int index, int itemNum)
		{
			int i = 0;
			
			// Check for subscript out of range
			if (C_Player.IsPlaying(index) == false || itemNum <= 0 || itemNum > Constants.MAX_ITEMS)
			{
				return 0;
			}
			
			for (i = 1; i <= Constants.MAX_INV; i++)
			{
				
				// Check to see if the player has the item
				if (C_Player.GetPlayerInvItemNum(index, i) == itemNum)
				{
					if (Types.Item[itemNum].Type == (byte)Enums.ItemType.Currency || Types.Item[itemNum].Stackable == 1)
					{
						return C_Player.GetPlayerInvItemValue(index, i);
					}
					else
					{
						return 1;
					}
					
					return 0;
				}
				
			}
            return 0;
			
		}
		
		internal static void RefreshQuestLog()
		{
			int I = 0;
			int x = 0;
			
			for (I = 1; I <= MaxActivequests; I++)
			{
				QuestNames[I] = "";
			}
			
			x = 1;
			
			for (I = 1; I <= MaxQuests; I++)
			{
				if (QuestInProgress(I) && x < MaxActivequests)
				{
					QuestNames[x] = Quest[I].Name.Trim();
					x++;
				}
			}
			
		}
		
		// ////////////////////////
		// // Visual Interaction //
		// ////////////////////////
		
		internal static void LoadQuestlogBox()
		{
			int questNum = 0;
			int curTask = 0;
			int I = 0;
			
			if (SelectedQuest == 0)
			{
				return;
			}
			
			for (I = 1; I <= MaxQuests; I++)
			{
				if (QuestNames[SelectedQuest].Trim() == Quest[I].Name.Trim())
				{
					questNum = I;
				}
			}
			
			if (questNum == 0)
			{
				return;
			}
			
			curTask = C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].ActualTask;
			
			if (curTask >= Quest[questNum].Task.Length)
			{
				return;
			}
			
			//Quest Log (Main Task)
			QuestTaskLogText = Quest[questNum].QuestLog.Trim();
			
			//Actual Task
			QuestTaskLogText = Quest[questNum].Task[curTask].TaskLog.Trim();
			
			//Last dialog
			if (C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].ActualTask > 1)
			{
				if (System.Convert.ToString(Quest[questNum].Task[curTask - 1].Speech).Trim().Length > 0)
				{
					QuestDialogText = System.Convert.ToString(System.Convert.ToString(Quest[questNum].Task[curTask - 1].Speech).Trim().Replace("$playername$", C_Player.GetPlayerName(C_Variables.Myindex)));
				}
				else
				{
					QuestDialogText = System.Convert.ToString(Quest[questNum].Chat[1].Replace("$playername$", C_Player.GetPlayerName(C_Variables.Myindex))).Trim();
				}
			}
			else
			{
				QuestDialogText = System.Convert.ToString(Quest[questNum].Chat[1].Replace("$playername$", C_Player.GetPlayerName(C_Variables.Myindex))).Trim();
			}
			
			//Quest Status
			if (C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].Status == (int) Enums.QuestStatusType.Started)
			{
				QuestStatus2Text = Strings.Get("quests", "queststarted");
				AbandonQuestText = Strings.Get("quests", "questcancel");
				AbandonQuestVisible = true;
			}
			else if (C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].Status == (int) Enums.QuestStatusType.Completed)
			{
				QuestStatus2Text = Strings.Get("quests", "questcomplete");
				AbandonQuestVisible = false;
			}
			else
			{
				QuestStatus2Text = "???";
				AbandonQuestVisible = false;
			}
			
			switch (Quest[questNum].Task[curTask].TaskType)
			{
				//defeat x amount of Npc
			case (int) Enums.QuestType.Slay:
				int curCount_1 = C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].CurrentCount;
				int maxAmount_1 = Quest[questNum].Task[curTask].Amount;
				string npcName_1 = Types.Npc[Quest[questNum].Task[curTask].Npc].Name;
				ActualTaskText = Strings.Get("quests", "questgoslay", curCount_1, maxAmount_1, npcName_1); //"Defeat " & CurCount & "/" & MaxAmount & " " & NpcName
				break;
				//gather x amount of items
			case (int) Enums.QuestType.Collect:
				int curCount_2 = C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].CurrentCount;
				int maxAmount_2 = Quest[questNum].Task[curTask].Amount;
				string itemName_1 = Types.Item[Quest[questNum].Task[curTask].Item].Name;
				ActualTaskText = Strings.Get("quests", "questgocollect", curCount_2, maxAmount_2, itemName_1); //"Collect " & CurCount & "/" & MaxAmount & " " & ItemName
				break;
				//go talk to npc
			case (int) Enums.QuestType.Talk:
				string npcName_2 = Types.Npc[Quest[questNum].Task[curTask].Npc].Name;
				ActualTaskText = Strings.Get("quests", "questtalkto", npcName_2); //"Go talk to  " & NpcName
				break;
				//reach certain map
			case (int) Enums.QuestType.Reach:
				string mapName = C_Types.MapNames[Quest[questNum].Task[curTask].Map];
				ActualTaskText = Strings.Get("quests", "questgoto", mapName); //"Go to " & MapName
				break;
			case (int) Enums.QuestType.Give:
				//give x amount of items to npc
				string npcName_3 = Types.Npc[Quest[questNum].Task[curTask].Npc].Name;
				int curCount_3 = C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].CurrentCount;
				int maxAmount_3 = Quest[questNum].Task[curTask].Amount;
				string itemName_2 = Types.Item[Quest[questNum].Task[curTask].Item].Name;
				ActualTaskText = Strings.Get("quests", "questgive", npcName_3, itemName_2, curCount_3, maxAmount_3); //"Give " & NpcName & " the " & ItemName & CurCount & "/" & MaxAmount & " they requested"
				break;
				//defeat certain amount of players
			case (int) Enums.QuestType.Kill:
				int curCount_4 = C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].CurrentCount;
				int maxAmount_4 = Quest[questNum].Task[curTask].Amount;
				ActualTaskText = Strings.Get("quests", "questkill", curCount_4, maxAmount_4); //"Defeat " & CurCount & "/" & MaxAmount & " Players in Battle"
				break;
				//go collect resources
			case (int) Enums.QuestType.Gather:
				int curCount = C_Types.Player[C_Variables.Myindex].PlayerQuest[questNum].CurrentCount;
				int maxAmount_5 = Quest[questNum].Task[curTask].Amount;
				string resourceName = Types.Resource[Quest[questNum].Task[curTask].Resource].Name;
				ActualTaskText = Strings.Get("quests", "questgather", curCount, maxAmount_5, resourceName); //"Gather " & CurCount & "/" & MaxAmount & " " & ResourceName
				break;
				//fetch x amount of items from npc
			case (int) Enums.QuestType.Fetch:
				string npcName = Types.Item[Quest[questNum].Task[curTask].Npc].Name;
				int maxAmount = Quest[questNum].Task[curTask].Amount;
				string itemName = Types.Item[Quest[questNum].Task[curTask].Item].Name;
				ActualTaskText = Strings.Get("quests", "questfetch", itemName, maxAmount, npcName); //"Fetch " & ItemName & "X" & MaxAmount & " from " & NpcName
				break;
			default:
				//ToDo
				ActualTaskText = "errr...";
				break;
		}
		
		//Rewards
		QuestRewardsText = new string[Quest[questNum].RewardCount + 1 + 1];
		for (I = 1; I <= Quest[questNum].RewardCount; I++)
		{
			QuestRewardsText[I] = Types.Item[Quest[questNum].RewardItem[I]].Name + " X" + Conversion.Str(Quest[questNum].RewardItemAmount[I]);
		}
		QuestRewardsText[I] = Conversion.Str(Quest[questNum].RewardExp) + " EXP";
	}
	
	internal static void DrawQuestLog()
	{
		int i = 0;
		int y = 0;
		
		y = 10;
		
		//first render panel
		C_Graphics.RenderSprite(C_Graphics.QuestSprite, C_Graphics.GameWindow, QuestLogX, QuestLogY, 0, 0, C_Graphics.QuestGfxInfo.Width, C_Graphics.QuestGfxInfo.Height);
		
		//draw quest names
		for (i = 1; i <= MaxActivequests; i++)
		{
			if (QuestNames[i].Trim().Length > 0)
			{
				C_Text.DrawText(QuestLogX + 7, QuestLogY + y, QuestNames[i].Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
				y = y + 20;
			}
		}
		
		if (SelectedQuest <= 0)
		{
			return;
		}
		
		//quest log text
		y = 0;
		foreach (string str in C_Text.WordWrap(QuestTaskLogText.Trim(), 35, C_Text.WrapMode.Characters, C_Text.WrapType.BreakWord, 13))
		{
			//description
			C_Text.DrawText(QuestLogX + 204, QuestLogY + 30 + y, str, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
			y = y + 15;
		}
		
		y = 0;
		foreach (string str in C_Text.WordWrap(ActualTaskText.Trim(), 40, C_Text.WrapMode.Characters, C_Text.WrapType.BreakWord, 13))
		{
			//description
			C_Text.DrawText(QuestLogX + 204, QuestLogY + 147 + y, str, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
			y = y + 15;
		}
		
		y = 0;
		foreach (string str in C_Text.WordWrap(QuestDialogText.Trim(), 40, C_Text.WrapMode.Characters, C_Text.WrapType.BreakWord, 13))
		{
			//description
			C_Text.DrawText(QuestLogX + 204, QuestLogY + 218 + y, str, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
			y = y + 15;
		}
		C_Text.DrawText(QuestLogX + 280, QuestLogY + 263, QuestStatus2Text.Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
		
		//DrawText(QuestLogX + 285, QuestLogY + 288, Trim$(QuestRequirementsText), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
		
		y = 0;
		for (i = 1; i <= QuestRewardsText.Length - 1; i++)
		{
			//description
			C_Text.DrawText(QuestLogX + 255, QuestLogY + 292 + y, QuestRewardsText[i].Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
			y = y + 15;
		}
		
	}
	
	internal static void ResetQuestLog()
	{
		
		QuestTaskLogText = "";
		ActualTaskText = "";
		QuestDialogText = "";
		QuestStatus2Text = "";
		AbandonQuestText = "";
		AbandonQuestVisible = false;
		QuestRequirementsText = "";
		QuestRewardsText = new string[1];
		PnlQuestLogVisible = false;
		
		SelectedQuest = 0;
	}
	
#endregion
	
}
}
