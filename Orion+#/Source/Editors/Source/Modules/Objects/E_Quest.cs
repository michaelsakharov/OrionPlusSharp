
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using ASFW;
using Engine;


namespace Engine
{
	internal sealed class E_Quest
	{
		
#region Global Info
		
		//Constants
		internal const int MAX_QUESTS = 250;
		
		//Friend Const MAX_REQUIREMENTS As Byte = 10
		//Friend Const MAX_TASKS As Byte = 10
		internal const byte EDITOR_TASKS = 7;
		
		internal const byte QUEST_TYPE_GOSLAY = 1;
		internal const byte QUEST_TYPE_GOGATHER = 2;
		internal const byte QUEST_TYPE_GOTALK = 3;
		internal const byte QUEST_TYPE_GOREACH = 4;
		internal const byte QUEST_TYPE_GOGIVE = 5;
		internal const byte QUEST_TYPE_GOKILL = 6;
		internal const byte QUEST_TYPE_GOTRAIN = 7;
		internal const byte QUEST_TYPE_GOGET = 8;
		
		internal const byte QUEST_NOT_STARTED = 0;
		internal const byte QUEST_STARTED = 1;
		internal const byte QUEST_COMPLETED = 2;
		internal const byte QUEST_COMPLETED_BUT = 3;
		
		internal static int QuestLogPage;
		internal static string[] QuestNames = new string[MAX_ACTIVEQUESTS + 1];
		
		internal static bool[] Quest_Changed = new bool[MAX_QUESTS + 1];
		
		internal static bool QuestEditorShow;
		
		//questlog variables
		
		internal const int MAX_ACTIVEQUESTS = 10;
		
		internal static int QuestLogX = 150;
		internal static int QuestLogY = 100;
		
		internal static bool pnlQuestLogVisible;
		internal static string SelectedQuest;
		internal static string QuestTaskLogText = "";
		internal static string ActualTaskText = "";
		internal static string QuestDialogText = "";
		internal static string QuestStatus2Text = "";
		internal static string AbandonQuestText = "";
		internal static bool AbandonQuestVisible;
		internal static string QuestRequirementsText = "";
		internal static string QuestRewardsText = "";
		
		//here we store temp info because off UpdateUI >.<
		internal static bool UpdateQuestWindow;
		
		internal static bool UpdateQuestChat;
		internal static int QuestNum;
		internal static int QuestNumForStart;
		internal static string QuestMessage;
		internal static int QuestAcceptTag;
		
		//Types
		internal static QuestRec[] Quest = new QuestRec[MAX_QUESTS + 1];
		
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
		
#region Quest Editor
		
		internal static void QuestEditorInit()
		{
			
			if (FrmQuest.Default.Visible == false)
			{
				return;
			}
			E_Globals.Editorindex = FrmQuest.Default.lstIndex.SelectedIndex + 1;
			
			FrmQuest.Default.txtName.Text = Quest[E_Globals.Editorindex].Name.Trim();
			
			if (Quest[E_Globals.Editorindex].Repeat == 1)
			{
				FrmQuest.Default.chkRepeat.Checked = true;
			}
			else
			{
				FrmQuest.Default.chkRepeat.Checked = false;
			}
			
			FrmQuest.Default.txtStartText.Text = System.Convert.ToString(Quest[E_Globals.Editorindex].Chat[1]).Trim();
			FrmQuest.Default.txtProgressText.Text = System.Convert.ToString(Quest[E_Globals.Editorindex].Chat[2]).Trim();
			FrmQuest.Default.txtEndText.Text = System.Convert.ToString(Quest[E_Globals.Editorindex].Chat[3]).Trim();
			
			FrmQuest.Default.cmbStartItem.Items.Clear();
			FrmQuest.Default.cmbItemReq.Items.Clear();
			FrmQuest.Default.cmbEndItem.Items.Clear();
			FrmQuest.Default.cmbItemReward.Items.Clear();
			FrmQuest.Default.cmbStartItem.Items.Add("None");
			FrmQuest.Default.cmbItemReq.Items.Add("None");
			FrmQuest.Default.cmbEndItem.Items.Add("None");
			FrmQuest.Default.cmbItemReward.Items.Add("None");
			
			for (var i = 1; i <= Constants.MAX_ITEMS; i++)
			{
				FrmQuest.Default.cmbStartItem.Items.Add(i + ": " + Types.Item[(int) i].Name);
				FrmQuest.Default.cmbItemReq.Items.Add(i + ": " + Types.Item[(int) i].Name);
				FrmQuest.Default.cmbEndItem.Items.Add(i + ": " + Types.Item[(int) i].Name);
				FrmQuest.Default.cmbItemReward.Items.Add(i + ": " + Types.Item[(int) i].Name);
			}
			
			FrmQuest.Default.cmbStartItem.SelectedIndex = 0;
			FrmQuest.Default.cmbItemReq.SelectedIndex = 0;
			FrmQuest.Default.cmbEndItem.SelectedIndex = 0;
			FrmQuest.Default.cmbItemReward.SelectedIndex = 0;
			
			FrmQuest.Default.cmbClassReq.Items.Clear();
			FrmQuest.Default.cmbClassReq.Items.Add("None");
			for (var i = 1; i <= E_Globals.Max_Classes; i++)
			{
				FrmQuest.Default.cmbClassReq.Items.Add(Types.Classes[(int) i].Name.Trim());
			}
			
			FrmQuest.Default.cmbStartItem.SelectedIndex = Quest[E_Globals.Editorindex].QuestGiveItem;
			FrmQuest.Default.cmbEndItem.SelectedIndex = Quest[E_Globals.Editorindex].QuestRemoveItem;
			
			FrmQuest.Default.nudGiveAmount.Value = Quest[E_Globals.Editorindex].QuestGiveItemValue;
			
			FrmQuest.Default.nudTakeAmount.Value = Quest[E_Globals.Editorindex].QuestRemoveItemValue;
			
			FrmQuest.Default.lstRewards.Items.Clear();
			for (var i = 1; i <= Quest[E_Globals.Editorindex].RewardCount; i++)
			{
				FrmQuest.Default.lstRewards.Items.Add(i + ":" + Quest[E_Globals.Editorindex].RewardItemAmount[(int) i] + " X " + Types.Item[Quest[E_Globals.Editorindex].RewardItem[(int) i]].Name.Trim());
			}
			
			FrmQuest.Default.nudExpReward.Value = Quest[E_Globals.Editorindex].RewardExp;
			
			FrmQuest.Default.lstRequirements.Items.Clear();
			
			for (var i = 1; i <= Quest[E_Globals.Editorindex].ReqCount; i++)
			{
				
				if ((int) (Quest[E_Globals.Editorindex].Requirement[(int) i]) == 1)
				{
					FrmQuest.Default.lstRequirements.Items.Add(i + ":" + "Item Requirement: " + Types.Item[Quest[E_Globals.Editorindex].RequirementIndex[(int) i]].Name.Trim());
				}
				else if ((int) (Quest[E_Globals.Editorindex].Requirement[(int) i]) == 2)
				{
					FrmQuest.Default.lstRequirements.Items.Add(i + ":" + "Quest Requirement: " + Quest[Quest[E_Globals.Editorindex].RequirementIndex[(int) i]].Name.Trim());
				}
				else if ((int) (Quest[E_Globals.Editorindex].Requirement[(int) i]) == 3)
				{
					FrmQuest.Default.lstRequirements.Items.Add(i + ":" + "Class Requirement: " + Types.Classes[Quest[E_Globals.Editorindex].RequirementIndex[(int) i]].Name.Trim());
				}
				else
				{
					FrmQuest.Default.lstRequirements.Items.Add(i + ":");
				}
			}
			
			FrmQuest.Default.lstTasks.Items.Clear();
			for (var i = 1; i <= Quest[E_Globals.Editorindex].TaskCount; i++)
			{
				FrmQuest.Default.lstTasks.Items.Add(i + ":" + Quest[E_Globals.Editorindex].Task[(int) i].TaskLog);
			}
			
			FrmQuest.Default.rdbNoneReq.Checked = true;
			
			Quest_Changed[E_Globals.Editorindex] = true;
			
		}
		
		internal static void QuestEditorOk()
		{
			int I = 0;
			
			for (I = 1; I <= MAX_QUESTS; I++)
			{
				if (Quest_Changed[I])
				{
					SendSaveQuest(I);
				}
			}
			
			FrmQuest.Default.Dispose();
			E_Globals.Editor = (byte) 0;
			ClearChanged_Quest();
			
		}
		
		internal static void QuestEditorCancel()
		{
			E_Globals.Editor = (byte) 0;
			FrmQuest.Default.Close();
			ClearChanged_Quest();
			ClearQuests();
			SendRequestQuests();
		}
		
		internal static void ClearChanged_Quest()
		{
			int I = 0;
			
			for (I = 0; I <= MAX_QUESTS; I++)
			{
				Quest_Changed[I] = false;
			}
		}
		
#endregion
		
#region DataBase
		
		public static void ClearQuest(int QuestNum)
		{
			int I = 0;
			
			// clear the Quest
			Quest[QuestNum].Name = "";
			Quest[QuestNum].QuestLog = "";
			Quest[QuestNum].Repeat = (byte) 0;
			Quest[QuestNum].Cancelable = (byte) 0;
			
			Quest[QuestNum].ReqCount = 0;
			Quest[QuestNum].Requirement = new int[Quest[QuestNum].ReqCount + 1];
			Quest[QuestNum].RequirementIndex = new int[Quest[QuestNum].ReqCount + 1];
			for (I = 1; I <= Quest[QuestNum].ReqCount; I++)
			{
				Quest[QuestNum].Requirement[I] = 0;
				Quest[QuestNum].RequirementIndex[I] = 0;
			}
			
			Quest[QuestNum].QuestGiveItem = 0;
			Quest[QuestNum].QuestGiveItemValue = 0;
			Quest[QuestNum].QuestRemoveItem = 0;
			Quest[QuestNum].QuestRemoveItemValue = 0;
			
			Quest[QuestNum].Chat = new string[4];
			for (I = 1; I <= 3; I++)
			{
				Quest[QuestNum].Chat[I] = "";
			}
			
			Quest[QuestNum].RewardCount = 0;
			Quest[QuestNum].RewardItem = new int[Quest[QuestNum].RewardCount + 1];
			Quest[QuestNum].RewardItemAmount = new int[Quest[QuestNum].RewardCount + 1];
			for (I = 1; I <= Quest[QuestNum].RewardCount; I++)
			{
				Quest[QuestNum].RewardItem[I] = 0;
				Quest[QuestNum].RewardItemAmount[I] = 0;
			}
			Quest[QuestNum].RewardExp = 0;
			
			Quest[QuestNum].TaskCount = 0;
			Quest[QuestNum].Task = new E_Quest.TaskRec[Quest[QuestNum].TaskCount + 1];
			for (I = 1; I <= Quest[QuestNum].TaskCount; I++)
			{
				Quest[QuestNum].Task[I].Order = 0;
				Quest[QuestNum].Task[I].Npc = 0;
				Quest[QuestNum].Task[I].Item = 0;
				Quest[QuestNum].Task[I].Map = 0;
				Quest[QuestNum].Task[I].Resource = 0;
				Quest[QuestNum].Task[I].Amount = 0;
				Quest[QuestNum].Task[I].Speech = "";
				Quest[QuestNum].Task[I].TaskLog = "";
				Quest[QuestNum].Task[I].QuestEnd = (byte) 0;
				Quest[QuestNum].Task[I].TaskType = 0;
			}
			
		}
		
		public static void ClearQuests()
		{
			int I = 0;
			
			for (I = 1; I <= MAX_QUESTS; I++)
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
			int QuestNum = 0;
			ByteStream buffer = new ByteStream(data);
			QuestNum = buffer.ReadInt32();
			
			// Update the Quest
			Quest[QuestNum].Name = buffer.ReadString();
			Quest[QuestNum].QuestLog = buffer.ReadString();
			Quest[QuestNum].Repeat = (byte) (buffer.ReadInt32());
			Quest[QuestNum].Cancelable = (byte) (buffer.ReadInt32());
			
			Quest[QuestNum].ReqCount = buffer.ReadInt32();
			Quest[QuestNum].Requirement = new int[Quest[QuestNum].ReqCount + 1];
			Quest[QuestNum].RequirementIndex = new int[Quest[QuestNum].ReqCount + 1];
			for (var I = 1; I <= Quest[QuestNum].ReqCount; I++)
			{
				Quest[QuestNum].Requirement[(int) I] = buffer.ReadInt32();
				Quest[QuestNum].RequirementIndex[(int) I] = buffer.ReadInt32();
			}
			
			Quest[QuestNum].QuestGiveItem = buffer.ReadInt32();
			Quest[QuestNum].QuestGiveItemValue = buffer.ReadInt32();
			Quest[QuestNum].QuestRemoveItem = buffer.ReadInt32();
			Quest[QuestNum].QuestRemoveItemValue = buffer.ReadInt32();
			
			for (var I = 1; I <= 3; I++)
			{
				Quest[QuestNum].Chat[(int) I] = buffer.ReadString();
			}
			
			Quest[QuestNum].RewardCount = buffer.ReadInt32();
			Quest[QuestNum].RewardItem = new int[Quest[QuestNum].RewardCount + 1];
			Quest[QuestNum].RewardItemAmount = new int[Quest[QuestNum].RewardCount + 1];
			for (var i = 1; i <= Quest[QuestNum].RewardCount; i++)
			{
				Quest[QuestNum].RewardItem[(int) i] = buffer.ReadInt32();
				Quest[QuestNum].RewardItemAmount[(int) i] = buffer.ReadInt32();
			}
			
			Quest[QuestNum].RewardExp = buffer.ReadInt32();
			
			Quest[QuestNum].TaskCount = buffer.ReadInt32();
			Quest[QuestNum].Task = new E_Quest.TaskRec[Quest[QuestNum].TaskCount + 1];
			for (var I = 1; I <= Quest[QuestNum].TaskCount; I++)
			{
				Quest[QuestNum].Task[(int) I].Order = buffer.ReadInt32();
				Quest[QuestNum].Task[(int) I].Npc = buffer.ReadInt32();
				Quest[QuestNum].Task[(int) I].Item = buffer.ReadInt32();
				Quest[QuestNum].Task[(int) I].Map = buffer.ReadInt32();
				Quest[QuestNum].Task[(int) I].Resource = buffer.ReadInt32();
				Quest[QuestNum].Task[(int) I].Amount = buffer.ReadInt32();
				Quest[QuestNum].Task[(int) I].Speech = buffer.ReadString();
				Quest[QuestNum].Task[(int) I].TaskLog = buffer.ReadString();
				Quest[QuestNum].Task[(int) I].QuestEnd = (byte) (buffer.ReadInt32());
				Quest[QuestNum].Task[(int) I].TaskType = buffer.ReadInt32();
			}
			
			buffer.Dispose();
		}
		
#endregion
		
#region Outgoing Packets
		
		internal static void SendRequestEditQuest()
		{
			ByteStream buffer = new ByteStream();
			
			buffer = new ByteStream(4);
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.RequestEditQuest);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		internal static void SendSaveQuest(int QuestNum)
		{
			ByteStream buffer = new ByteStream();
			
			buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.SaveQuest);
			buffer.WriteInt32(QuestNum);
			
			buffer.WriteString(Quest[QuestNum].Name.Trim());
			buffer.WriteString(Quest[QuestNum].QuestLog.Trim());
			buffer.WriteInt32(Quest[QuestNum].Repeat);
			buffer.WriteInt32(Quest[QuestNum].Cancelable);
			
			buffer.WriteInt32(Quest[QuestNum].ReqCount);
			for (var I = 1; I <= Quest[QuestNum].ReqCount; I++)
			{
				buffer.WriteInt32(System.Convert.ToInt32(Quest[QuestNum].Requirement[(int) I]));
				buffer.WriteInt32(System.Convert.ToInt32(Quest[QuestNum].RequirementIndex[(int) I]));
			}
			
			buffer.WriteInt32(Quest[QuestNum].QuestGiveItem);
			buffer.WriteInt32(Quest[QuestNum].QuestGiveItemValue);
			buffer.WriteInt32(Quest[QuestNum].QuestRemoveItem);
			buffer.WriteInt32(Quest[QuestNum].QuestRemoveItemValue);
			
			for (var I = 1; I <= 3; I++)
			{
				buffer.WriteString(System.Convert.ToString(Quest[QuestNum].Chat[(int) I]).Trim());
			}
			
			buffer.WriteInt32(Quest[QuestNum].RewardCount);
			for (var i = 1; i <= Quest[QuestNum].RewardCount; i++)
			{
				buffer.WriteInt32(System.Convert.ToInt32(Quest[QuestNum].RewardItem[(int) i]));
				buffer.WriteInt32(System.Convert.ToInt32(Quest[QuestNum].RewardItemAmount[(int) i]));
			}
			
			buffer.WriteInt32(Quest[QuestNum].RewardExp);
			
			buffer.WriteInt32(Quest[QuestNum].TaskCount);
			for (var I = 1; I <= Quest[QuestNum].TaskCount; I++)
			{
				buffer.WriteInt32(Quest[QuestNum].Task[(int) I].Order);
				buffer.WriteInt32(Quest[QuestNum].Task[(int) I].Npc);
				buffer.WriteInt32(Quest[QuestNum].Task[(int) I].Item);
				buffer.WriteInt32(Quest[QuestNum].Task[(int) I].Map);
				buffer.WriteInt32(Quest[QuestNum].Task[(int) I].Resource);
				buffer.WriteInt32(Quest[QuestNum].Task[(int) I].Amount);
				buffer.WriteString(Quest[QuestNum].Task[(int) I].Speech.Trim());
				buffer.WriteString(Quest[QuestNum].Task[(int) I].TaskLog.Trim());
				buffer.WriteInt32(Quest[QuestNum].Task[(int) I].QuestEnd);
				buffer.WriteInt32(Quest[QuestNum].Task[(int) I].TaskType);
			}
			
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		public static void SendRequestQuests()
		{
			ByteStream buffer = new ByteStream();
			
			buffer = new ByteStream(4);
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestQuests);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		internal static void UpdateQuestLog()
		{
			ByteStream buffer = new ByteStream();
			
			buffer = new ByteStream(4);
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CQuestLogUpdate);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		internal static void PlayerHandleQuest(int QuestNum, int Order)
		{
			ByteStream buffer = new ByteStream();
			
			buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CPlayerHandleQuest);
			buffer.WriteInt32(QuestNum);
			buffer.WriteInt32(Order); //1=accept quest, 2=cancel quest
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void QuestReset(int QuestNum)
		{
			ByteStream buffer = new ByteStream();
			
			buffer = new ByteStream(4);
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CQuestReset);
			buffer.WriteInt32(QuestNum);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
#endregion
		
#region Support Functions
		
		internal static int GetQuestNum(string QuestName)
		{
			int returnValue = 0;
			int I = 0;
			returnValue = 0;
			
			for (I = 1; I <= MAX_QUESTS; I++)
			{
				if (Quest[I].Name.Trim() == QuestName.Trim())
				{
					returnValue = I;
					break;
				}
			}
			return returnValue;
		}
		
#endregion
		
#region Misc Functions
		
		internal static void LoadRequirement(int QuestNum, int ReqNum)
		{
			int i = 0;
			
			//Populate combo boxes
			FrmQuest.Default.cmbItemReq.Items.Clear();
			FrmQuest.Default.cmbItemReq.Items.Add("None");
			
			for (i = 1; i <= Constants.MAX_ITEMS; i++)
			{
				FrmQuest.Default.cmbItemReq.Items.Add(i + ": " + Types.Item[i].Name);
			}
			
			FrmQuest.Default.cmbQuestReq.Items.Clear();
			FrmQuest.Default.cmbQuestReq.Items.Add("None");
			
			for (i = 1; i <= MAX_QUESTS; i++)
			{
				FrmQuest.Default.cmbQuestReq.Items.Add(i + ": " + Quest[i].Name);
			}
			
			FrmQuest.Default.cmbClassReq.Items.Clear();
			FrmQuest.Default.cmbClassReq.Items.Add("None");
			
			for (i = 1; i <= E_Globals.Max_Classes; i++)
			{
				FrmQuest.Default.cmbClassReq.Items.Add(i + ": " + Types.Classes[i].Name);
			}
			
			FrmQuest.Default.cmbItemReq.Enabled = false;
			FrmQuest.Default.cmbQuestReq.Enabled = false;
			FrmQuest.Default.cmbClassReq.Enabled = false;
			
			if ((int) (Quest[QuestNum].Requirement[ReqNum]) == 0)
			{
				FrmQuest.Default.rdbNoneReq.Checked = true;
			}
			else if ((int) (Quest[QuestNum].Requirement[ReqNum]) == 1)
			{
				FrmQuest.Default.rdbItemReq.Checked = true;
				FrmQuest.Default.cmbItemReq.Enabled = true;
				FrmQuest.Default.cmbItemReq.SelectedIndex = Quest[QuestNum].RequirementIndex[ReqNum];
			}
			else if ((int) (Quest[QuestNum].Requirement[ReqNum]) == 2)
			{
				FrmQuest.Default.rdbQuestReq.Checked = true;
				FrmQuest.Default.cmbQuestReq.Enabled = true;
				FrmQuest.Default.cmbQuestReq.SelectedIndex = Quest[QuestNum].RequirementIndex[ReqNum];
			}
			else if ((int) (Quest[QuestNum].Requirement[ReqNum]) == 3)
			{
				FrmQuest.Default.rdbClassReq.Checked = true;
				FrmQuest.Default.cmbClassReq.Enabled = true;
				FrmQuest.Default.cmbClassReq.SelectedIndex = Quest[QuestNum].RequirementIndex[ReqNum];
			}
			
			
		}
		
		//Subroutine that load the desired task in the form
		internal static void LoadTask(int QuestNum, int TaskNum)
		{
			TaskRec TaskToLoad = new TaskRec();
			TaskToLoad = Quest[QuestNum].Task[TaskNum];
			
			//Load the task type
			switch (TaskToLoad.Order)
			{
				case 0:
					FrmQuest.Default.optTask0.Checked = true;
					break;
				case 1:
					FrmQuest.Default.optTask1.Checked = true;
					break;
				case 2:
					FrmQuest.Default.optTask2.Checked = true;
					break;
				case 3:
					FrmQuest.Default.optTask3.Checked = true;
					break;
				case 4:
					FrmQuest.Default.optTask4.Checked = true;
					break;
				case 5:
					FrmQuest.Default.optTask5.Checked = true;
					break;
				case 6:
					FrmQuest.Default.optTask6.Checked = true;
					break;
				case 7:
					FrmQuest.Default.optTask7.Checked = true;
					break;
			}
			
			//Load textboxes
			FrmQuest.Default.txtTaskLog.Text = "" + TaskToLoad.TaskLog.Trim();
			
			//Populate combo boxes
			FrmQuest.Default.cmbNpc.Items.Clear();
			FrmQuest.Default.cmbNpc.Items.Add("None");
			
			for (var i = 1; i <= Constants.MAX_NPCS; i++)
			{
				FrmQuest.Default.cmbNpc.Items.Add(i + ": " + Types.Npc[(int) i].Name);
			}
			
			FrmQuest.Default.cmbItem.Items.Clear();
			FrmQuest.Default.cmbItem.Items.Add("None");
			
			for (var i = 1; i <= Constants.MAX_ITEMS; i++)
			{
				FrmQuest.Default.cmbItem.Items.Add(i + ": " + Types.Item[(int) i].Name);
			}
			
			FrmQuest.Default.cmbMap.Items.Clear();
			FrmQuest.Default.cmbMap.Items.Add("None");
			
			for (var i = 1; i <= Constants.MAX_MAPS; i++)
			{
				FrmQuest.Default.cmbMap.Items.Add(i);
			}
			
			FrmQuest.Default.cmbResource.Items.Clear();
			FrmQuest.Default.cmbResource.Items.Add("None");
			
			for (var i = 1; i <= Constants.MAX_RESOURCES; i++)
			{
				FrmQuest.Default.cmbResource.Items.Add(i + ": " + Types.Resource[(int) i].Name);
			}
			
			//Set combo to 0 and disable them so they can be enabled when needed
			FrmQuest.Default.cmbNpc.SelectedIndex = 0;
			FrmQuest.Default.cmbItem.SelectedIndex = 0;
			FrmQuest.Default.cmbMap.SelectedIndex = 0;
			FrmQuest.Default.cmbResource.SelectedIndex = 0;
			FrmQuest.Default.nudAmount.Value = 0;
			
			FrmQuest.Default.cmbNpc.Enabled = false;
			FrmQuest.Default.cmbItem.Enabled = false;
			FrmQuest.Default.cmbMap.Enabled = false;
			FrmQuest.Default.cmbResource.Enabled = false;
			FrmQuest.Default.nudAmount.Enabled = false;
			
			if (TaskToLoad.QuestEnd == 1)
			{
				FrmQuest.Default.chkEnd.Checked = true;
			}
			else
			{
				FrmQuest.Default.chkEnd.Checked = false;
			}
			
			switch (TaskToLoad.Order)
			{
				case 0: //Nothing
					break;
					
				case QUEST_TYPE_GOSLAY: //1
					FrmQuest.Default.cmbNpc.Enabled = true;
					FrmQuest.Default.cmbNpc.SelectedIndex = TaskToLoad.Npc;
					FrmQuest.Default.nudAmount.Enabled = true;
					FrmQuest.Default.nudAmount.Value = TaskToLoad.Amount;
					break;
					
				case QUEST_TYPE_GOGATHER: //2
					FrmQuest.Default.cmbItem.Enabled = true;
					FrmQuest.Default.cmbItem.SelectedIndex = TaskToLoad.Item;
					FrmQuest.Default.nudAmount.Enabled = true;
					FrmQuest.Default.nudAmount.Value = TaskToLoad.Amount;
					break;
					
				case QUEST_TYPE_GOTALK: //3
					FrmQuest.Default.cmbNpc.Enabled = true;
					FrmQuest.Default.cmbNpc.SelectedIndex = TaskToLoad.Npc;
					break;
					
				case QUEST_TYPE_GOREACH: //4
					FrmQuest.Default.cmbMap.Enabled = true;
					FrmQuest.Default.cmbMap.SelectedIndex = TaskToLoad.Map;
					break;
					
				case QUEST_TYPE_GOGIVE: //5
					FrmQuest.Default.cmbItem.Enabled = true;
					FrmQuest.Default.cmbItem.SelectedIndex = TaskToLoad.Item;
					FrmQuest.Default.nudAmount.Enabled = true;
					FrmQuest.Default.nudAmount.Value = TaskToLoad.Amount;
					FrmQuest.Default.cmbNpc.Enabled = true;
					FrmQuest.Default.cmbNpc.SelectedIndex = TaskToLoad.Npc;
					FrmQuest.Default.txtTaskSpeech.Text = "" + TaskToLoad.Speech.Trim();
					break;
					
				case QUEST_TYPE_GOTRAIN: //6
					FrmQuest.Default.cmbResource.Enabled = true;
					FrmQuest.Default.cmbResource.SelectedIndex = TaskToLoad.Resource;
					FrmQuest.Default.nudAmount.Enabled = true;
					FrmQuest.Default.nudAmount.Value = TaskToLoad.Amount;
					break;
					
				case QUEST_TYPE_GOGET: //7
					FrmQuest.Default.cmbNpc.Enabled = true;
					FrmQuest.Default.cmbNpc.SelectedIndex = TaskToLoad.Npc;
					FrmQuest.Default.cmbItem.Enabled = true;
					FrmQuest.Default.cmbItem.SelectedIndex = TaskToLoad.Item;
					FrmQuest.Default.nudAmount.Enabled = true;
					FrmQuest.Default.nudAmount.Value = TaskToLoad.Amount;
					FrmQuest.Default.txtTaskSpeech.Text = "" + TaskToLoad.Speech.Trim();
					break;
			}
			
			FrmQuest.Default.lblTaskNum.Text = "Task Number: " + System.Convert.ToString(TaskNum);
		}
		
#endregion
		
	}
}
