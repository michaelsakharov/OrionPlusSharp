using System.Windows.Forms;
using System.IO;
using ASFW;
using ASFW.IO.FileIO;

namespace Engine
{
    internal static class S_Quest
    {


        // Constants
        internal const int MAX_QUESTS = 250;

        // Friend Const MAX_TASKS As Byte = 10
        // Friend Const MAX_REQUIREMENTS As Byte = 10
        internal const int MAX_ACTIVEQUESTS = 10;

        internal const byte EDITOR_TASKS = 7;

        // Friend Const QUEST_TYPE_GOSLAY As Byte = 1
        // Friend Const QUEST_TYPE_GOCOLLECT As Byte = 2
        // Friend Const QUEST_TYPE_GOTALK As Byte = 3
        // Friend Const QUEST_TYPE_GOREACH As Byte = 4
        // Friend Const QUEST_TYPE_GOGIVE As Byte = 5
        // Friend Const QUEST_TYPE_GOKILL As Byte = 6
        // Friend Const QUEST_TYPE_GOGATHER As Byte = 7
        // Friend Const QUEST_TYPE_GOFETCH As Byte = 8
        // Friend Const QUEST_TYPE_TALKEVENT As Byte = 9

        // Friend Const QUEST_NOT_STARTED As Byte = 0
        // Friend Const QUEST_STARTED As Byte = 1
        // Friend Const QUEST_COMPLETED As Byte = 2
        // Friend Const QUEST_REPEATABLE As Byte = 3

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
            public int NPC;
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



        public static void SaveQuests()
        {
            int I;
            for (I = 1; I <= MAX_QUESTS; I++)
            {
                SaveQuest(I);
                Application.DoEvents();
            }
        }

        public static void SaveQuest(int QuestNum)
        {
            string filename;
            int I;
            filename = Path.Combine(Application.StartupPath, "data", "quests", string.Format("quest{0}.dat", QuestNum));

            ByteStream writer = new ByteStream(100);

            writer.WriteString(Quest[QuestNum].Name);
            writer.WriteString(Quest[QuestNum].QuestLog);
            writer.WriteByte(Quest[QuestNum].Repeat);
            writer.WriteByte(Quest[QuestNum].Cancelable);

            writer.WriteInt32(Quest[QuestNum].ReqCount);
            var loopTo = Quest[QuestNum].ReqCount;
            for (I = 1; I <= loopTo; I++)
            {
                writer.WriteInt32(Quest[QuestNum].Requirement[I]);
                writer.WriteInt32(Quest[QuestNum].RequirementIndex[I]);
            }

            writer.WriteInt32(Quest[QuestNum].QuestGiveItem);
            writer.WriteInt32(Quest[QuestNum].QuestGiveItemValue);
            writer.WriteInt32(Quest[QuestNum].QuestRemoveItem);
            writer.WriteInt32(Quest[QuestNum].QuestRemoveItemValue);

            for (I = 1; I <= 3; I++)
                writer.WriteString(Quest[QuestNum].Chat[I]);

            writer.WriteInt32(Quest[QuestNum].RewardCount);
            var loopTo1 = Quest[QuestNum].RewardCount;
            for (I = 1; I <= loopTo1; I++)
            {
                writer.WriteInt32(Quest[QuestNum].RewardItem[I]);
                writer.WriteInt32(Quest[QuestNum].RewardItemAmount[I]);
            }
            writer.WriteInt32(Quest[QuestNum].RewardExp);

            writer.WriteInt32(Quest[QuestNum].TaskCount);
            var loopTo2 = Quest[QuestNum].TaskCount;
            for (I = 1; I <= loopTo2; I++)
            {
                writer.WriteInt32(Quest[QuestNum].Task[I].Order);
                writer.WriteInt32(Quest[QuestNum].Task[I].NPC);
                writer.WriteInt32(Quest[QuestNum].Task[I].Item);
                writer.WriteInt32(Quest[QuestNum].Task[I].Map);
                writer.WriteInt32(Quest[QuestNum].Task[I].Resource);
                writer.WriteInt32(Quest[QuestNum].Task[I].Amount);
                writer.WriteString(Quest[QuestNum].Task[I].Speech);
                writer.WriteString(Quest[QuestNum].Task[I].TaskLog);
                writer.WriteByte(Quest[QuestNum].Task[I].QuestEnd);
                writer.WriteInt32(Quest[QuestNum].Task[I].TaskType);
            }

            BinaryFile.Save(filename, ref writer);
        }

        public static void LoadQuests()
        {
            int I;

            CheckQuests();

            for (I = 1; I <= MAX_QUESTS; I++)
            {
                LoadQuest(I);
                Application.DoEvents();
            }
        }

        public static void LoadQuest(int QuestNum)
        {
            string FileName;
            int I;

            FileName = Path.Combine(Application.StartupPath, "data", "quests", string.Format("quest{0}.dat", QuestNum));

            ByteStream reader = new ByteStream();
            BinaryFile.Load(FileName, ref reader);

            Quest[QuestNum].Name = reader.ReadString();
            Quest[QuestNum].QuestLog = reader.ReadString();
            Quest[QuestNum].Repeat = reader.ReadByte();
            Quest[QuestNum].Cancelable = reader.ReadByte();

            Quest[QuestNum].ReqCount = reader.ReadInt32();
            Quest[QuestNum].Requirement = new int[Quest[QuestNum].ReqCount + 1];
            Quest[QuestNum].RequirementIndex = new int[Quest[QuestNum].ReqCount + 1];
            var loopTo = Quest[QuestNum].ReqCount;
            for (I = 1; I <= loopTo; I++)
            {
                Quest[QuestNum].Requirement[I] = reader.ReadInt32();
                Quest[QuestNum].RequirementIndex[I] = reader.ReadInt32();
            }

            Quest[QuestNum].QuestGiveItem = reader.ReadInt32();
            Quest[QuestNum].QuestGiveItemValue = reader.ReadInt32();
            Quest[QuestNum].QuestRemoveItem = reader.ReadInt32();
            Quest[QuestNum].QuestRemoveItemValue = reader.ReadInt32();

            for (I = 1; I <= 3; I++)
                Quest[QuestNum].Chat[I] = reader.ReadString();

            Quest[QuestNum].RewardCount = reader.ReadInt32();
            Quest[QuestNum].RewardItem = new int[Quest[QuestNum].RewardCount + 1];
            Quest[QuestNum].RewardItemAmount = new int[Quest[QuestNum].RewardCount + 1];
            var loopTo1 = Quest[QuestNum].RewardCount;
            for (I = 1; I <= loopTo1; I++)
            {
                Quest[QuestNum].RewardItem[I] = reader.ReadInt32();
                Quest[QuestNum].RewardItemAmount[I] = reader.ReadInt32();
            }
            Quest[QuestNum].RewardExp = reader.ReadInt32();

            Quest[QuestNum].TaskCount = reader.ReadInt32();
            Quest[QuestNum].Task = new TaskRec[Quest[QuestNum].TaskCount + 1];
            var loopTo2 = Quest[QuestNum].TaskCount;
            for (I = 1; I <= loopTo2; I++)
            {
                Quest[QuestNum].Task[I].Order = reader.ReadInt32();
                Quest[QuestNum].Task[I].NPC = reader.ReadInt32();
                Quest[QuestNum].Task[I].Item = reader.ReadInt32();
                Quest[QuestNum].Task[I].Map = reader.ReadInt32();
                Quest[QuestNum].Task[I].Resource = reader.ReadInt32();
                Quest[QuestNum].Task[I].Amount = reader.ReadInt32();
                Quest[QuestNum].Task[I].Speech = reader.ReadString();
                Quest[QuestNum].Task[I].TaskLog = reader.ReadString();
                Quest[QuestNum].Task[I].QuestEnd = reader.ReadByte();
                Quest[QuestNum].Task[I].TaskType = reader.ReadInt32();
            }
        }

        public static void CheckQuests()
        {
            int I;
            for (I = 1; I <= MAX_QUESTS; I++)
            {
                if (!File.Exists(Path.Combine(Application.StartupPath, "data", "quests", string.Format("quest{0}.dat", I))))
                {
                    SaveQuest(I);
                    Application.DoEvents();
                }
            }
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
                Quest[QuestNum].Requirement[QuestNum] = 0;
                Quest[QuestNum].RequirementIndex[QuestNum] = 0;
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
                Quest[QuestNum].Task[I].NPC = 0;
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



        public static void Packet_RequestEditQuest(int index, ref byte[] data)
        {
            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Developer)
                return;

            var Buffer = new ByteStream(4);
            Buffer.WriteInt32((byte)Packets.ServerPackets.SQuestEditor);
            S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);
            Buffer.Dispose();
        }

        public static void Packet_SaveQuest(int index, ref byte[] data)
        {
            int QuestNum;
            ByteStream buffer = new ByteStream(data);
            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Developer)
                return;

            QuestNum = buffer.ReadInt32();
            if (QuestNum < 0 || QuestNum > MAX_QUESTS)
                return;

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
                Quest[QuestNum].Task[I].NPC = buffer.ReadInt32();
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

            // Save it
            SendQuests(index); // editor
            SendUpdateQuestToAll(QuestNum); // players
            SaveQuest(QuestNum);
            modDatabase.Addlog(S_Players.GetPlayerLogin(index) + " saved Quest #" + QuestNum + ".", S_Constants.ADMIN_LOG);
        }

        public static void Packet_RequestQuests(int index, ref byte[] data)
        {
            SendQuests(index);
        }

        public static void Packet_PlayerHandleQuest(int index, ref byte[] data)
        {
            int QuestNum;
            int Order; // , I As Integer
            ByteStream buffer = new ByteStream(data);
            QuestNum = buffer.ReadInt32();
            Order = buffer.ReadInt32(); // 1 = accept, 2 = cancel

            if (Order == 1)
            {
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].Status = (byte)Enums.QuestStatusType.Started; // 1
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask = 1;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount = 0;
                S_NetworkSend.PlayerMsg(index, "New quest accepted: " + Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Name) + "!", (int)Enums.ColorType.BrightGreen);
            }
            else if (Order == 2)
            {
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].Status = (byte)Enums.QuestStatusType.NotStarted; // 2
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask = 1;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount = 0;

                S_NetworkSend.PlayerMsg(index, Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Name) + " has been canceled!", (int)Enums.ColorType.BrightRed);

                if (S_Players.GetPlayerAccess(index) > 0 && QuestNum == 1)
                {
                    for (var I = 1; I <= MAX_QUESTS; I++)
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[I].Status = (byte)Enums.QuestStatusType.NotStarted; // 2
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[I].ActualTask = 1;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[I].CurrentCount = 0;
                    }
                }
            }

            modDatabase.SavePlayer(index);
            S_NetworkSend.SendPlayerData(index);
            SendPlayerQuests(index);
            buffer.Dispose();
        }

        public static void Packet_QuestLogUpdate(int index, ref byte[] data)
        {
            SendPlayerQuests(index);
        }

        public static void Packet_QuestReset(int index, ref byte[] data)
        {
            int QuestNum;

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;
            ByteStream buffer = new ByteStream(data);
            QuestNum = buffer.ReadInt32();

            ResetQuest(index, QuestNum);

            buffer.Dispose();
        }



        public static void SendQuests(int index)
        {
            int I;

            for (I = 1; I <= MAX_QUESTS; I++)
            {
                if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Quest[I].Name)) > 0)
                    SendUpdateQuestTo(index, I);
            }
        }

        public static void SendUpdateQuestToAll(int QuestNum)
        {
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((byte)Packets.ServerPackets.SUpdateQuest);
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
                buffer.WriteInt32(Quest[QuestNum].Task[I].NPC);
                buffer.WriteInt32(Quest[QuestNum].Task[I].Item);
                buffer.WriteInt32(Quest[QuestNum].Task[I].Map);
                buffer.WriteInt32(Quest[QuestNum].Task[I].Resource);
                buffer.WriteInt32(Quest[QuestNum].Task[I].Amount);
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Task[I].Speech)));
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Task[I].TaskLog)));
                buffer.WriteInt32(Quest[QuestNum].Task[I].QuestEnd);
                buffer.WriteInt32(Quest[QuestNum].Task[I].TaskType);
            }

            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendUpdateQuestTo(int index, int QuestNum)
        {
            ByteStream buffer;
            int I;
            buffer = new ByteStream(4);

            buffer.WriteInt32((byte)Packets.ServerPackets.SUpdateQuest);
            buffer.WriteInt32(QuestNum);

            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Name)));
            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].QuestLog)));
            buffer.WriteInt32(Quest[QuestNum].Repeat);
            buffer.WriteInt32(Quest[QuestNum].Cancelable);

            buffer.WriteInt32(Quest[QuestNum].ReqCount);
            var loopTo = Quest[QuestNum].ReqCount;
            for (I = 1; I <= loopTo; I++)
            {
                buffer.WriteInt32(Quest[QuestNum].Requirement[I]);
                buffer.WriteInt32(Quest[QuestNum].RequirementIndex[I]);
            }

            buffer.WriteInt32(Quest[QuestNum].QuestGiveItem);
            buffer.WriteInt32(Quest[QuestNum].QuestGiveItemValue);
            buffer.WriteInt32(Quest[QuestNum].QuestRemoveItem);
            buffer.WriteInt32(Quest[QuestNum].QuestRemoveItemValue);

            for (I = 1; I <= 3; I++)
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Chat[I])));

            buffer.WriteInt32(Quest[QuestNum].RewardCount);
            var loopTo1 = Quest[QuestNum].RewardCount;
            for (I = 1; I <= loopTo1; I++)
            {
                buffer.WriteInt32(Quest[QuestNum].RewardItem[I]);
                buffer.WriteInt32(Quest[QuestNum].RewardItemAmount[I]);
            }

            buffer.WriteInt32(Quest[QuestNum].RewardExp);

            buffer.WriteInt32(Quest[QuestNum].TaskCount);
            var loopTo2 = Quest[QuestNum].TaskCount;
            for (I = 1; I <= loopTo2; I++)
            {
                buffer.WriteInt32(Quest[QuestNum].Task[I].Order);
                buffer.WriteInt32(Quest[QuestNum].Task[I].NPC);
                buffer.WriteInt32(Quest[QuestNum].Task[I].Item);
                buffer.WriteInt32(Quest[QuestNum].Task[I].Map);
                buffer.WriteInt32(Quest[QuestNum].Task[I].Resource);
                buffer.WriteInt32(Quest[QuestNum].Task[I].Amount);
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Task[I].Speech)));
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Task[I].TaskLog)));
                buffer.WriteInt32(Quest[QuestNum].Task[I].QuestEnd);
                buffer.WriteInt32(Quest[QuestNum].Task[I].TaskType);
            }

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendPlayerQuests(int index)
        {
            int I;
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((byte)Packets.ServerPackets.SPlayerQuests);

            for (I = 1; I <= MAX_QUESTS; I++)
            {
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[I].Status);
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[I].ActualTask);
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[I].CurrentCount);
            }

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendPlayerQuest(int index, int QuestNum)
        {
            ByteStream buffer;

            buffer = new ByteStream(4);
            buffer.WriteInt32((byte)Packets.ServerPackets.SPlayerQuest);

            buffer.WriteInt32(QuestNum);
            buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].Status);
            buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask);
            buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        // sends a message to the client that is shown on the screen
        internal static void QuestMessage(int index, int QuestNum, string message, int QuestNumForStart)
        {
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((byte)Packets.ServerPackets.SQuestMessage);

            buffer.WriteInt32(QuestNum);
            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(message)));
            buffer.WriteInt32(QuestNumForStart);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }



        internal static void ResetQuest(int index, int QuestNum)
        {
            if (S_Players.GetPlayerAccess(index) > 0)
            {
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].Status = (byte)Enums.QuestStatusType.NotStarted;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask = 1;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount = 0;

                SendPlayerQuests(index);
                S_NetworkSend.PlayerMsg(index, "Quest " + QuestNum + " reset!", (int)Enums.ColorType.BrightRed);
            }
        }

        internal static bool CanStartQuest(int index, int QuestNum)
        {
            bool CanStartQuest = false;
            bool flag = QuestNum < 1 || QuestNum > 250;
            checked
            {
                if (!flag)
                {
                    bool flag2 = S_Quest.QuestInProgress(index, QuestNum);
                    if (!flag2)
                    {
                        bool flag3 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].Status == 0 || modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].Status == 3;
                        if (flag3)
                        {
                            int reqCount = S_Quest.Quest[QuestNum].ReqCount;
                            for (int i = 1; i <= reqCount; i++)
                            {
                                bool flag4 = S_Quest.Quest[QuestNum].Requirement[i] == 1;
                                if (flag4)
                                {
                                    bool flag5 = S_Quest.Quest[QuestNum].RequirementIndex[i] > 0 && S_Quest.Quest[QuestNum].RequirementIndex[i] <= 500;
                                    if (flag5)
                                    {
                                        bool flag6 = S_Players.HasItem(index, S_Quest.Quest[QuestNum].RequirementIndex[i]) == 0;
                                        if (flag6)
                                        {
                                            S_NetworkSend.PlayerMsg(index, "You need " + Types.Item[S_Quest.Quest[QuestNum].Requirement[2]].Name + " to take this quest!", 14);
                                            return CanStartQuest;
                                        }
                                    }
                                }
                                bool flag7 = S_Quest.Quest[QuestNum].Requirement[i] == 2;
                                if (flag7)
                                {
                                    bool flag8 = S_Quest.Quest[QuestNum].RequirementIndex[i] > 0 && S_Quest.Quest[QuestNum].RequirementIndex[i] <= 250;
                                    if (flag8)
                                    {
                                        bool flag9 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].PlayerQuest[S_Quest.Quest[QuestNum].Requirement[2]].Status == 0 || modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].PlayerQuest[S_Quest.Quest[QuestNum].Requirement[2]].Status == 1;
                                        if (flag9)
                                        {
                                            S_NetworkSend.PlayerMsg(index, "You need to complete the " + S_Quest.Quest[S_Quest.Quest[QuestNum].Requirement[2]].Name.Trim() + " quest in order to take this quest!", 14);
                                            return CanStartQuest;
                                        }
                                    }
                                }
                            }
                            CanStartQuest = true;
                        }
                    }
                }
                return CanStartQuest;
            }
        }

        internal static bool CanEndQuest(int index, int QuestNum)
        {
            bool CanEndQuest = false;
            bool flag = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask >= S_Quest.Quest[QuestNum].Task.Length;
            if (flag)
            {
                CanEndQuest = true;
            }
            bool flag2 = S_Quest.Quest[QuestNum].Task[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask].QuestEnd == 1;
            if (flag2)
            {
                CanEndQuest = true;
            }
            return CanEndQuest;
        }

        // Tells if the quest is in progress or not
        internal static bool QuestInProgress(int index, int QuestNum)
        {
            bool QuestInProgress = false;
            bool flag = QuestNum < 1 || QuestNum > 250;
            if (!flag)
            {
                bool flag2 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].Status == 1;
                if (flag2)
                {
                    QuestInProgress = true;
                }
            }
            return QuestInProgress;
        }

        // Token: 0x06000302 RID: 770 RVA: 0x00058D04 File Offset: 0x00056F04
        internal static bool QuestCompleted(int index, int QuestNum)
        {
            bool QuestCompleted = false;
            bool flag = QuestNum < 1 || QuestNum > 250;
            if (!flag)
            {
                bool flag2 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].Status == 2 || modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].Status == 3;
                if (flag2)
                {
                    QuestCompleted = true;
                }
            }
            return QuestCompleted;
        }

        // Token: 0x06000303 RID: 771 RVA: 0x00058DA8 File Offset: 0x00056FA8
        internal static int GetQuestNum(string QuestName)
        {
            int GetQuestNum = 0;
            int I = 1;
            checked
            {
                for (; ; )
                {
                    if ((S_Quest.Quest[I].Name.Trim() == QuestName.Trim()))
                    {
                        break;
                    }
                    I++;
                    if (I > 250)
                    {
                        return GetQuestNum;
                    }
                }
                GetQuestNum = I;
                return GetQuestNum;
            }
        }

        // Token: 0x06000304 RID: 772 RVA: 0x00058DF4 File Offset: 0x00056FF4
        internal static int GetItemNum(string ItemName)
        {
            int GetItemNum = 0;
            int I = 1;
            checked
            {
                for (; ; )
                {
                    if (((Types.Item[I].Name.Trim()) == (ItemName.Trim())))
                    {
                        break;
                    }
                    I++;
                    if (I > 500)
                    {
                        return GetItemNum;
                    }
                }
                GetItemNum = I;
                return GetItemNum;
            }
        }

        // /////////////////////
        // // General Purpose //
        // /////////////////////

        internal static void CheckTasks(int index, int TaskType, int Targetindex)
        {
            int I;

            for (I = 1; I <= MAX_QUESTS; I++)
            {
                if (QuestInProgress(index, I))
                    CheckTask(index, I, TaskType, Targetindex);
            }
        }

        internal static void CheckTask(int index, int QuestNum, int TaskType, int Targetindex)
        {
            int ActualTask;
            int I;
            ActualTask = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask;

            if (ActualTask >= Quest[QuestNum].Task.Length)
                return;

            switch (TaskType)
            {
                case (int)Enums.QuestType.Slay // defeat X amount of X npc's.
               :
                    {

                        // is npc defeated id same as the npc i have to defeat?
                        if (Targetindex == Quest[QuestNum].Task[ActualTask].NPC)
                        {
                            // Count +1
                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount + 1;
                            // did i finish the work?
                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount >= Quest[QuestNum].Task[ActualTask].Amount)
                            {
                                QuestMessage(index, QuestNum, Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Task[ActualTask].TaskLog) + " - Task completed", 0);
                                // is the quest's end?
                                if (CanEndQuest(index, QuestNum))
                                    EndQuest(index, QuestNum);
                                else
                                    // otherwise continue to the next task
                                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask = ActualTask + 1;
                            }
                        }

                        break;
                    }

                case (int)Enums.QuestType.Collect // Gather X amount of X item.
         :
                    {
                        if (Targetindex == Quest[QuestNum].Task[ActualTask].Item)
                        {
                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount + 1;
                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount >= Quest[QuestNum].Task[ActualTask].Amount)
                            {
                                QuestMessage(index, QuestNum, Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Task[ActualTask].TaskLog) + " - Task completed", 0);
                                if (CanEndQuest(index, QuestNum))
                                    EndQuest(index, QuestNum);
                                else
                                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask = ActualTask + 1;
                            }
                        }

                        break;
                    }

                case (int)Enums.QuestType.Talk // Interact with X npc.
         :
                    {
                        if (Targetindex == Quest[QuestNum].Task[ActualTask].NPC && Quest[QuestNum].Task[ActualTask].Amount == 0)
                        {
                            QuestMessage(index, QuestNum, Quest[QuestNum].Task[ActualTask].Speech, 0);
                            if (CanEndQuest(index, QuestNum))
                                EndQuest(index, QuestNum);
                            else
                                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask = ActualTask + 1;
                        }

                        break;
                    }

                case (int)Enums.QuestType.Reach // Reach X map.
         :
                    {
                        if (Targetindex == Quest[QuestNum].Task[ActualTask].Map)
                        {
                            QuestMessage(index, QuestNum, Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Task[ActualTask].TaskLog) + " - Task completed", 0);
                            if (CanEndQuest(index, QuestNum))
                                EndQuest(index, QuestNum);
                            else
                                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask = ActualTask + 1;
                        }

                        break;
                    }

                case (int)Enums.QuestType.Give // Give X amount of X item to X npc.
         :
                    {
                        if (Targetindex == Quest[QuestNum].Task[ActualTask].NPC)
                        {
                            for (I = 1; I <= Constants.MAX_INV; I++)
                            {
                                if (S_Players.GetPlayerInvItemNum(index, I) == Quest[QuestNum].Task[ActualTask].Item)
                                {
                                    if (S_Players.GetPlayerInvItemValue(index, I) >= Quest[QuestNum].Task[ActualTask].Amount)
                                    {
                                        S_Players.TakeInvItem(index, S_Players.GetPlayerInvItemNum(index, I), Quest[QuestNum].Task[ActualTask].Amount);
                                        QuestMessage(index, QuestNum, Quest[QuestNum].Task[ActualTask].Speech, 0);
                                        if (CanEndQuest(index, QuestNum))
                                            EndQuest(index, QuestNum);
                                        else
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask = ActualTask + 1;
                                        break;
                                    }
                                }
                            }
                        }

                        break;
                    }

                case (int)Enums.QuestType.Kill // Kill X amount of players.
         :
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount + 1;
                        if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount >= Quest[QuestNum].Task[ActualTask].Amount)
                        {
                            QuestMessage(index, QuestNum, Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Task[ActualTask].TaskLog) + " - Task completed", 0);
                            if (CanEndQuest(index, QuestNum))
                                EndQuest(index, QuestNum);
                            else
                                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask = ActualTask + 1;
                        }

                        break;
                    }

                case (int)Enums.QuestType.Gather // Hit X amount of times X resource.
         :
                    {
                        if (Targetindex == Quest[QuestNum].Task[ActualTask].Resource)
                        {
                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount + 1;
                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].CurrentCount >= Quest[QuestNum].Task[ActualTask].Amount)
                            {
                                QuestMessage(index, QuestNum, Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Task[ActualTask].TaskLog) + " - Task completed", 0);
                                if (CanEndQuest(index, QuestNum))
                                    EndQuest(index, QuestNum);
                                else
                                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask = ActualTask + 1;
                            }
                        }

                        break;
                    }

                case (int)Enums.QuestType.Fetch // Get X amount of X item from X npc.
         :
                    {
                        if (Targetindex == Quest[QuestNum].Task[ActualTask].NPC)
                        {
                            S_Players.GiveInvItem(index, Quest[QuestNum].Task[ActualTask].Item, Quest[QuestNum].Task[ActualTask].Amount);
                            QuestMessage(index, QuestNum, Quest[QuestNum].Task[ActualTask].Speech, 0);
                            if (CanEndQuest(index, QuestNum))
                                EndQuest(index, QuestNum);
                            else
                                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].ActualTask = ActualTask + 1;
                        }

                        break;
                    }
            }

            SendPlayerQuest(index, QuestNum);
        }

        internal static void ShowQuest(int index, int QuestNum)
        {
            if (QuestInProgress(index, QuestNum))
            {
                QuestMessage(index, QuestNum, Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Chat[2]), 0); // show meanwhile message
                return;
            }
            if (!CanStartQuest(index, QuestNum))
                return;

            QuestMessage(index, QuestNum, Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Chat[1]), QuestNum); // chat 1 = request message
        }

        internal static void EndQuest(int index, int QuestNum)
        {
            int I;

            QuestMessage(index, QuestNum, Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Chat[3]), 0);
            var loopTo = Quest[QuestNum].RewardCount;
            for (I = 1; I <= loopTo; I++)
            {
                if (Quest[QuestNum].RewardItem[I] > 0)
                    S_NetworkSend.PlayerMsg(index, "You recieved " + Quest[QuestNum].RewardItemAmount[I] + " " + Microsoft.VisualBasic.Strings.Trim(Types.Item[Quest[QuestNum].RewardItem[I]].Name), (int)Enums.ColorType.BrightGreen);
                S_Players.GiveInvItem(index, Quest[QuestNum].RewardItem[I], Quest[QuestNum].RewardItemAmount[I]);
            }

            if (Quest[QuestNum].RewardExp > 0)
            {
                S_Players.SetPlayerExp(index, S_Players.GetPlayerExp(index) + Quest[QuestNum].RewardExp);
                S_NetworkSend.SendExp(index);
                // Check for level up
                S_Players.CheckPlayerLevelUp(index);
            }

            // Check if quest is repeatable, set it as completed
            if (Quest[QuestNum].Repeat == 1)
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].Status = (byte)Enums.QuestStatusType.Repeatable;
            else
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].PlayerQuest[QuestNum].Status = (byte)Enums.QuestStatusType.Completed;
            S_NetworkSend.PlayerMsg(index, Microsoft.VisualBasic.Strings.Trim(Quest[QuestNum].Name) + ": quest completed", (int)Enums.ColorType.BrightGreen);

            modDatabase.SavePlayer(index);
            S_NetworkSend.SendPlayerData(index);
            SendPlayerQuest(index, QuestNum);
        }
    }
}
