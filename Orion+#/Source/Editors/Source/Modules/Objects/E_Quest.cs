using ASFW;

namespace Engine
{
    internal static class E_Quest
    {


        // Constants
        internal const int MAX_QUESTS = 250;

        // Friend Const MAX_REQUIREMENTS As Byte = 10
        // Friend Const MAX_TASKS As Byte = 10
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
        internal static string[] QuestNames = new string[11];

        internal static bool[] Quest_Changed = new bool[251];

        internal static bool QuestEditorShow;

        // questlog variables

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

        // here we store temp info because off UpdateUI >.<
        internal static bool UpdateQuestWindow;

        internal static bool UpdateQuestChat;
        internal static int QuestNum;
        internal static int QuestNumForStart;
        internal static string QuestMessage;
        internal static int QuestAcceptTag;

        // Types
        internal static QuestRec[] Quest = new QuestRec[251];

        internal struct PlayerQuestRec
        {
            public int Status; // 0=not started, 1=started, 2=completed, 3=completed but repeatable
            public int ActualTask;
            public int CurrentCount; // Used to handle the Amount property
        }

        internal struct TaskRec
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

        internal struct QuestRec
        {
            public string Name;
            public string QuestLog;
            public byte Repeat;
            public byte Cancelable;

            public int ReqCount;
            public int[] Requirement; // 1=item, 2=quest, 3=class
            public int[] RequirementIndex;

            public int QuestGiveItem; // Todo: make this dynamic
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



        internal static void QuestEditorInit()
        {
            if (My.MyProject.Forms.FrmQuest.Visible == false)
                return;
            E_Globals.Editorindex = My.MyProject.Forms.FrmQuest.lstIndex.SelectedIndex + 1;

            {
                var withBlock = My.MyProject.Forms.FrmQuest;
                withBlock.txtName.Text = Microsoft.VisualBasic.Strings.Trim(Quest[E_Globals.Editorindex].Name);

                if (Quest[E_Globals.Editorindex].Repeat == 1)
                    withBlock.chkRepeat.Checked = true;
                else
                    withBlock.chkRepeat.Checked = false;

                withBlock.txtStartText.Text = Microsoft.VisualBasic.Strings.Trim(Quest[E_Globals.Editorindex].Chat[1]);
                withBlock.txtProgressText.Text = Microsoft.VisualBasic.Strings.Trim(Quest[E_Globals.Editorindex].Chat[2]);
                withBlock.txtEndText.Text = Microsoft.VisualBasic.Strings.Trim(Quest[E_Globals.Editorindex].Chat[3]);

                withBlock.cmbStartItem.Items.Clear();
                withBlock.cmbItemReq.Items.Clear();
                withBlock.cmbEndItem.Items.Clear();
                withBlock.cmbItemReward.Items.Clear();
                withBlock.cmbStartItem.Items.Add("None");
                withBlock.cmbItemReq.Items.Add("None");
                withBlock.cmbEndItem.Items.Add("None");
                withBlock.cmbItemReward.Items.Add("None");

                for (var i = 1; i <= Constants.MAX_ITEMS; i++)
                {
                    withBlock.cmbStartItem.Items.Add(i + ": " + Types.Item[i].Name);
                    withBlock.cmbItemReq.Items.Add(i + ": " + Types.Item[i].Name);
                    withBlock.cmbEndItem.Items.Add(i + ": " + Types.Item[i].Name);
                    withBlock.cmbItemReward.Items.Add(i + ": " + Types.Item[i].Name);
                }

                withBlock.cmbStartItem.SelectedIndex = 0;
                withBlock.cmbItemReq.SelectedIndex = 0;
                withBlock.cmbEndItem.SelectedIndex = 0;
                withBlock.cmbItemReward.SelectedIndex = 0;

                withBlock.cmbClassReq.Items.Clear();
                withBlock.cmbClassReq.Items.Add("None");
                var loopTo = E_Globals.Max_Classes;
                for (var i = 1; i <= loopTo; i++)
                    withBlock.cmbClassReq.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Classes[i].Name));

                withBlock.cmbStartItem.SelectedIndex = Quest[E_Globals.Editorindex].QuestGiveItem;
                withBlock.cmbEndItem.SelectedIndex = Quest[E_Globals.Editorindex].QuestRemoveItem;

                withBlock.nudGiveAmount.Value = Quest[E_Globals.Editorindex].QuestGiveItemValue;

                withBlock.nudTakeAmount.Value = Quest[E_Globals.Editorindex].QuestRemoveItemValue;

                withBlock.lstRewards.Items.Clear();
                var loopTo1 = Quest[E_Globals.Editorindex].RewardCount;
                for (var i = 1; i <= loopTo1; i++)
                    withBlock.lstRewards.Items.Add(i + ":" + Quest[E_Globals.Editorindex].RewardItemAmount[i] + " X " + Microsoft.VisualBasic.Strings.Trim(Types.Item[Quest[E_Globals.Editorindex].RewardItem[i]].Name));

                withBlock.nudExpReward.Value = Quest[E_Globals.Editorindex].RewardExp;

                withBlock.lstRequirements.Items.Clear();
                var loopTo2 = Quest[E_Globals.Editorindex].ReqCount;
                for (var i = 1; i <= loopTo2; i++)
                {
                    switch (Quest[E_Globals.Editorindex].Requirement[i])
                    {
                        case 1:
                            {
                                withBlock.lstRequirements.Items.Add(i + ":" + "Item Requirement: " + Microsoft.VisualBasic.Strings.Trim(Types.Item[Quest[E_Globals.Editorindex].RequirementIndex[i]].Name));
                                break;
                            }

                        case 2:
                            {
                                withBlock.lstRequirements.Items.Add(i + ":" + "Quest Requirement: " + Microsoft.VisualBasic.Strings.Trim(Quest[Quest[E_Globals.Editorindex].RequirementIndex[i]].Name));
                                break;
                            }

                        case 3:
                            {
                                withBlock.lstRequirements.Items.Add(i + ":" + "Class Requirement: " + Microsoft.VisualBasic.Strings.Trim(Types.Classes[Quest[E_Globals.Editorindex].RequirementIndex[i]].Name));
                                break;
                            }

                        default:
                            {
                                withBlock.lstRequirements.Items.Add(i + ":");
                                break;
                            }
                    }
                }

                withBlock.lstTasks.Items.Clear();
                var loopTo3 = Quest[E_Globals.Editorindex].TaskCount;
                for (var i = 1; i <= loopTo3; i++)
                    My.MyProject.Forms.FrmQuest.lstTasks.Items.Add(i + ":" + Quest[E_Globals.Editorindex].Task[i].TaskLog);

                withBlock.rdbNoneReq.Checked = true;
            }

            Quest_Changed[E_Globals.Editorindex] = true;
        }

        internal static void QuestEditorOk()
        {
            int I;

            for (I = 1; I <= MAX_QUESTS; I++)
            {
                if (Quest_Changed[I])
                    SendSaveQuest(I);
            }

            My.MyProject.Forms.FrmQuest.Dispose();
            E_Globals.Editor = 0;
            ClearChanged_Quest();
        }

        internal static void QuestEditorCancel()
        {
            E_Globals.Editor = 0;
            My.MyProject.Forms.FrmQuest.Dispose();
            ClearChanged_Quest();
            ClearQuests();
            SendRequestQuests();
        }

        internal static void ClearChanged_Quest()
        {
            int I;

            for (I = 0; I <= MAX_QUESTS; I++)
                Quest_Changed[I] = false;
        }



        public static void ClearQuest(int QuestNum)
        {
            int I;

            // clear the Quest
            Quest[QuestNum].Name = "";
            Quest[QuestNum].QuestLog = "";
            Quest[QuestNum].Repeat = 0;
            Quest[QuestNum].Cancelable = 0;

            Quest[QuestNum].ReqCount = 0;
            Quest[QuestNum].Requirement = new int[Quest[QuestNum].ReqCount + 1];
            Quest[QuestNum].RequirementIndex = new int[Quest[QuestNum].ReqCount + 1];
            var loopTo = Quest[QuestNum].ReqCount;
            for (I = 1; I <= loopTo; I++)
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
                Quest[QuestNum].Chat[I] = "";

            Quest[QuestNum].RewardCount = 0;
            Quest[QuestNum].RewardItem = new int[Quest[QuestNum].RewardCount + 1];
            Quest[QuestNum].RewardItemAmount = new int[Quest[QuestNum].RewardCount + 1];
            var loopTo1 = Quest[QuestNum].RewardCount;
            for (I = 1; I <= loopTo1; I++)
            {
                Quest[QuestNum].RewardItem[I] = 0;
                Quest[QuestNum].RewardItemAmount[I] = 0;
            }
            Quest[QuestNum].RewardExp = 0;

            Quest[QuestNum].TaskCount = 0;
            Quest[QuestNum].Task = new TaskRec[Quest[QuestNum].TaskCount + 1];
            var loopTo2 = Quest[QuestNum].TaskCount;
            for (I = 1; I <= loopTo2; I++)
            {
                Quest[QuestNum].Task[I].Order = 0;
                Quest[QuestNum].Task[I].Npc = 0;
                Quest[QuestNum].Task[I].Item = 0;
                Quest[QuestNum].Task[I].Map = 0;
                Quest[QuestNum].Task[I].Resource = 0;
                Quest[QuestNum].Task[I].Amount = 0;
                Quest[QuestNum].Task[I].Speech = "";
                Quest[QuestNum].Task[I].TaskLog = "";
                Quest[QuestNum].Task[I].QuestEnd = 0;
                Quest[QuestNum].Task[I].TaskType = 0;
            }
        }

        public static void ClearQuests()
        {
            int I;

            for (I = 1; I <= MAX_QUESTS; I++)
                ClearQuest(I);
        }



        internal static void Packet_QuestEditor(ref byte[] data)
        {
            QuestEditorShow = true;
        }

        internal static void Packet_UpdateQuest(ref byte[] data)
        {
            int QuestNum;
            ByteStream buffer = new ByteStream(data);
            QuestNum = buffer.ReadInt32();

            // Update the Quest
            Quest[QuestNum].Name = buffer.ReadString();
            Quest[QuestNum].QuestLog = buffer.ReadString();
            Quest[QuestNum].Repeat = (byte)buffer.ReadInt32();
            Quest[QuestNum].Cancelable = (byte)buffer.ReadInt32();

            Quest[QuestNum].ReqCount = buffer.ReadInt32();
            Quest[QuestNum].Requirement = new int[Quest[QuestNum].ReqCount + 1];
            Quest[QuestNum].RequirementIndex = new int[Quest[QuestNum].ReqCount + 1];
            var loopTo = Quest[QuestNum].ReqCount;
            for (var I = 1; I <= loopTo; I++)
            {
                Quest[QuestNum].Requirement[I] = buffer.ReadInt32();
                Quest[QuestNum].RequirementIndex[I] = buffer.ReadInt32();
            }

            Quest[QuestNum].QuestGiveItem = buffer.ReadInt32();
            Quest[QuestNum].QuestGiveItemValue = buffer.ReadInt32();
            Quest[QuestNum].QuestRemoveItem = buffer.ReadInt32();
            Quest[QuestNum].QuestRemoveItemValue = buffer.ReadInt32();

            for (var I = 1; I <= 3; I++)
                Quest[QuestNum].Chat[I] = buffer.ReadString();

            Quest[QuestNum].RewardCount = buffer.ReadInt32();
            Quest[QuestNum].RewardItem = new int[Quest[QuestNum].RewardCount + 1];
            Quest[QuestNum].RewardItemAmount = new int[Quest[QuestNum].RewardCount + 1];
            var loopTo1 = Quest[QuestNum].RewardCount;
            for (var i = 1; i <= loopTo1; i++)
            {
                Quest[QuestNum].RewardItem[i] = buffer.ReadInt32();
                Quest[QuestNum].RewardItemAmount[i] = buffer.ReadInt32();
            }

            Quest[QuestNum].RewardExp = buffer.ReadInt32();

            Quest[QuestNum].TaskCount = buffer.ReadInt32();
            Quest[QuestNum].Task = new TaskRec[Quest[QuestNum].TaskCount + 1];
            var loopTo2 = Quest[QuestNum].TaskCount;
            for (var I = 1; I <= loopTo2; I++)
            {
                Quest[QuestNum].Task[I].Order = buffer.ReadInt32();
                Quest[QuestNum].Task[I].Npc = buffer.ReadInt32();
                Quest[QuestNum].Task[I].Item = buffer.ReadInt32();
                Quest[QuestNum].Task[I].Map = buffer.ReadInt32();
                Quest[QuestNum].Task[I].Resource = buffer.ReadInt32();
                Quest[QuestNum].Task[I].Amount = buffer.ReadInt32();
                Quest[QuestNum].Task[I].Speech = buffer.ReadString();
                Quest[QuestNum].Task[I].TaskLog = buffer.ReadString();
                Quest[QuestNum].Task[I].QuestEnd = (byte)buffer.ReadInt32();
                Quest[QuestNum].Task[I].TaskType = buffer.ReadInt32();
            }

            buffer.Dispose();
        }



        internal static void SendRequestEditQuest()
        {
            ByteStream buffer;

            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.EditorPackets.RequestEditQuest);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendSaveQuest(int QuestNum)
        {
            ByteStream buffer;

            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.SaveQuest);
            buffer.WriteInt32(QuestNum);

            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Name)));
            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].QuestLog)));
            buffer.WriteInt32(Quest[QuestNum].Repeat);
            buffer.WriteInt32(Quest[QuestNum].Cancelable);

            buffer.WriteInt32(Quest[QuestNum].ReqCount);
            var loopTo = Quest[QuestNum].ReqCount;
            for (var I = 1; I <= loopTo; I++)
            {
                buffer.WriteInt32(Quest[QuestNum].Requirement[I]);
                buffer.WriteInt32(Quest[QuestNum].RequirementIndex[I]);
            }

            buffer.WriteInt32(Quest[QuestNum].QuestGiveItem);
            buffer.WriteInt32(Quest[QuestNum].QuestGiveItemValue);
            buffer.WriteInt32(Quest[QuestNum].QuestRemoveItem);
            buffer.WriteInt32(Quest[QuestNum].QuestRemoveItemValue);

            for (var I = 1; I <= 3; I++)
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Chat[I])));

            buffer.WriteInt32(Quest[QuestNum].RewardCount);
            var loopTo1 = Quest[QuestNum].RewardCount;
            for (var i = 1; i <= loopTo1; i++)
            {
                buffer.WriteInt32(Quest[QuestNum].RewardItem[i]);
                buffer.WriteInt32(Quest[QuestNum].RewardItemAmount[i]);
            }

            buffer.WriteInt32(Quest[QuestNum].RewardExp);

            buffer.WriteInt32(Quest[QuestNum].TaskCount);
            var loopTo2 = Quest[QuestNum].TaskCount;
            for (var I = 1; I <= loopTo2; I++)
            {
                buffer.WriteInt32(Quest[QuestNum].Task[I].Order);
                buffer.WriteInt32(Quest[QuestNum].Task[I].Npc);
                buffer.WriteInt32(Quest[QuestNum].Task[I].Item);
                buffer.WriteInt32(Quest[QuestNum].Task[I].Map);
                buffer.WriteInt32(Quest[QuestNum].Task[I].Resource);
                buffer.WriteInt32(Quest[QuestNum].Task[I].Amount);
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Task[I].Speech)));
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Task[I].TaskLog)));
                buffer.WriteInt32(Quest[QuestNum].Task[I].QuestEnd);
                buffer.WriteInt32(Quest[QuestNum].Task[I].TaskType);
            }

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendRequestQuests()
        {
            ByteStream buffer;

            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ClientPackets.CRequestQuests);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void UpdateQuestLog()
        {
            ByteStream buffer;

            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ClientPackets.CQuestLogUpdate);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void PlayerHandleQuest(int QuestNum, int Order)
        {
            ByteStream buffer;

            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CPlayerHandleQuest);
            buffer.WriteInt32(QuestNum);
            buffer.WriteInt32(Order); // 1=accept quest, 2=cancel quest
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void QuestReset(int QuestNum)
        {
            ByteStream buffer;

            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ClientPackets.CQuestReset);
            buffer.WriteInt32(QuestNum);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }



        internal static int GetQuestNum(string QuestName)
        {
            int I;
            int GetQuestNum = 0;

            for (I = 1; I <= MAX_QUESTS; I++)
            {
                if (Microsoft.VisualBasic.Strings.Trim(Quest[I].Name) == Microsoft.VisualBasic.Strings.Trim(QuestName))
                {
                    GetQuestNum = I;
                    break;
                }
            }
            return GetQuestNum;
        }



        internal static void LoadRequirement(int QuestNum, int ReqNum)
        {
            int i;

            {
                var withBlock = My.MyProject.Forms.FrmQuest;
                // Populate combo boxes
                withBlock.cmbItemReq.Items.Clear();
                withBlock.cmbItemReq.Items.Add("None");

                for (i = 1; i <= Constants.MAX_ITEMS; i++)
                    withBlock.cmbItemReq.Items.Add(i + ": " + Types.Item[i].Name);

                withBlock.cmbQuestReq.Items.Clear();
                withBlock.cmbQuestReq.Items.Add("None");

                for (i = 1; i <= MAX_QUESTS; i++)
                    withBlock.cmbQuestReq.Items.Add(i + ": " + Quest[i].Name);

                withBlock.cmbClassReq.Items.Clear();
                withBlock.cmbClassReq.Items.Add("None");
                var loopTo = E_Globals.Max_Classes;
                for (i = 1; i <= loopTo; i++)
                    withBlock.cmbClassReq.Items.Add(i + ": " + Types.Classes[i].Name);

                withBlock.cmbItemReq.Enabled = false;
                withBlock.cmbQuestReq.Enabled = false;
                withBlock.cmbClassReq.Enabled = false;

                switch (Quest[QuestNum].Requirement[ReqNum])
                {
                    case 0:
                        {
                            withBlock.rdbNoneReq.Checked = true;
                            break;
                        }

                    case 1:
                        {
                            withBlock.rdbItemReq.Checked = true;
                            withBlock.cmbItemReq.Enabled = true;
                            withBlock.cmbItemReq.SelectedIndex = Quest[QuestNum].RequirementIndex[ReqNum];
                            break;
                        }

                    case 2:
                        {
                            withBlock.rdbQuestReq.Checked = true;
                            withBlock.cmbQuestReq.Enabled = true;
                            withBlock.cmbQuestReq.SelectedIndex = Quest[QuestNum].RequirementIndex[ReqNum];
                            break;
                        }

                    case 3:
                        {
                            withBlock.rdbClassReq.Checked = true;
                            withBlock.cmbClassReq.Enabled = true;
                            withBlock.cmbClassReq.SelectedIndex = Quest[QuestNum].RequirementIndex[ReqNum];
                            break;
                        }
                }
            }
        }

        // Subroutine that load the desired task in the form
        internal static void LoadTask(int QuestNum, int TaskNum)
        {
            TaskRec TaskToLoad;
            TaskToLoad = Quest[QuestNum].Task[TaskNum];

            {
                var withBlock = My.MyProject.Forms.FrmQuest;
                // Load the task type
                switch (TaskToLoad.Order)
                {
                    case 0:
                        {
                            withBlock.optTask0.Checked = true;
                            break;
                        }

                    case 1:
                        {
                            withBlock.optTask1.Checked = true;
                            break;
                        }

                    case 2:
                        {
                            withBlock.optTask2.Checked = true;
                            break;
                        }

                    case 3:
                        {
                            withBlock.optTask3.Checked = true;
                            break;
                        }

                    case 4:
                        {
                            withBlock.optTask4.Checked = true;
                            break;
                        }

                    case 5:
                        {
                            withBlock.optTask5.Checked = true;
                            break;
                        }

                    case 6:
                        {
                            withBlock.optTask6.Checked = true;
                            break;
                        }

                    case 7:
                        {
                            withBlock.optTask7.Checked = true;
                            break;
                        }
                }

                // Load textboxes
                withBlock.txtTaskLog.Text = "" + Microsoft.VisualBasic.Strings.Trim(TaskToLoad.TaskLog);

                // Populate combo boxes
                withBlock.cmbNpc.Items.Clear();
                withBlock.cmbNpc.Items.Add("None");

                for (var i = 1; i <= Constants.MAX_NPCS; i++)
                    withBlock.cmbNpc.Items.Add(i + ": " + Types.Npc[i].Name);

                withBlock.cmbItem.Items.Clear();
                withBlock.cmbItem.Items.Add("None");

                for (var i = 1; i <= Constants.MAX_ITEMS; i++)
                    withBlock.cmbItem.Items.Add(i + ": " + Types.Item[i].Name);

                withBlock.cmbMap.Items.Clear();
                withBlock.cmbMap.Items.Add("None");

                for (var i = 1; i <= Constants.MAX_MAPS; i++)
                    withBlock.cmbMap.Items.Add(i);

                withBlock.cmbResource.Items.Clear();
                withBlock.cmbResource.Items.Add("None");

                for (var i = 1; i <= Constants.MAX_RESOURCES; i++)
                    withBlock.cmbResource.Items.Add(i + ": " + Types.Resource[i].Name);

                // Set combo to 0 and disable them so they can be enabled when needed
                withBlock.cmbNpc.SelectedIndex = 0;
                withBlock.cmbItem.SelectedIndex = 0;
                withBlock.cmbMap.SelectedIndex = 0;
                withBlock.cmbResource.SelectedIndex = 0;
                withBlock.nudAmount.Value = 0;

                withBlock.cmbNpc.Enabled = false;
                withBlock.cmbItem.Enabled = false;
                withBlock.cmbMap.Enabled = false;
                withBlock.cmbResource.Enabled = false;
                withBlock.nudAmount.Enabled = false;

                if (TaskToLoad.QuestEnd == 1)
                    withBlock.chkEnd.Checked = true;
                else
                    withBlock.chkEnd.Checked = false;

                switch (TaskToLoad.Order)
                {
                    case 0 // Nothing
                   :
                        {
                            break;
                        }

                    case QUEST_TYPE_GOSLAY // 1
           :
                        {
                            withBlock.cmbNpc.Enabled = true;
                            withBlock.cmbNpc.SelectedIndex = TaskToLoad.Npc;
                            withBlock.nudAmount.Enabled = true;
                            withBlock.nudAmount.Value = TaskToLoad.Amount;
                            break;
                        }

                    case QUEST_TYPE_GOGATHER // 2
             :
                        {
                            withBlock.cmbItem.Enabled = true;
                            withBlock.cmbItem.SelectedIndex = TaskToLoad.Item;
                            withBlock.nudAmount.Enabled = true;
                            withBlock.nudAmount.Value = TaskToLoad.Amount;
                            break;
                        }

                    case QUEST_TYPE_GOTALK // 3
             :
                        {
                            withBlock.cmbNpc.Enabled = true;
                            withBlock.cmbNpc.SelectedIndex = TaskToLoad.Npc;
                            break;
                        }

                    case QUEST_TYPE_GOREACH // 4
             :
                        {
                            withBlock.cmbMap.Enabled = true;
                            withBlock.cmbMap.SelectedIndex = TaskToLoad.Map;
                            break;
                        }

                    case QUEST_TYPE_GOGIVE // 5
             :
                        {
                            withBlock.cmbItem.Enabled = true;
                            withBlock.cmbItem.SelectedIndex = TaskToLoad.Item;
                            withBlock.nudAmount.Enabled = true;
                            withBlock.nudAmount.Value = TaskToLoad.Amount;
                            withBlock.cmbNpc.Enabled = true;
                            withBlock.cmbNpc.SelectedIndex = TaskToLoad.Npc;
                            withBlock.txtTaskSpeech.Text = "" + Microsoft.VisualBasic.Strings.Trim(TaskToLoad.Speech);
                            break;
                        }

                    case QUEST_TYPE_GOTRAIN // 6
             :
                        {
                            withBlock.cmbResource.Enabled = true;
                            withBlock.cmbResource.SelectedIndex = TaskToLoad.Resource;
                            withBlock.nudAmount.Enabled = true;
                            withBlock.nudAmount.Value = TaskToLoad.Amount;
                            break;
                        }

                    case QUEST_TYPE_GOGET // 7
             :
                        {
                            withBlock.cmbNpc.Enabled = true;
                            withBlock.cmbNpc.SelectedIndex = TaskToLoad.Npc;
                            withBlock.cmbItem.Enabled = true;
                            withBlock.cmbItem.SelectedIndex = TaskToLoad.Item;
                            withBlock.nudAmount.Enabled = true;
                            withBlock.nudAmount.Value = TaskToLoad.Amount;
                            withBlock.txtTaskSpeech.Text = "" + Microsoft.VisualBasic.Strings.Trim(TaskToLoad.Speech);
                            break;
                        }
                }

                withBlock.lblTaskNum.Text = "Task Number: " + TaskNum;
            }
        }
    }
}
