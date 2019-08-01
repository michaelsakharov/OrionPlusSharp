using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using System.IO;
using ASFW;
using ASFW.IO.FileIO;
using static Engine.Enums;

namespace Engine
{
    static class S_Pets
    {
        internal static PetRec[] Pet;

        // PET constants
        internal const byte PetBehaviourFollow = 0; // The pet will attack all npcs around

        internal const byte PetBehaviourGoto = 1; // If attacked, the pet will fight back
        internal const byte PetAttackBehaviourAttackonsight = 2; // The pet will attack all npcs around
        internal const byte PetAttackBehaviourGuard = 3; // If attacked, the pet will fight back
        internal const byte PetAttackBehaviourDonothing = 4; // The pet will not attack even if attacked

        internal struct PetRec
        {
            public int Num;
            public string Name;
            public int Sprite;

            public int Range;

            public int Level;

            public int MaxLevel;
            public int ExpGain;
            public int LevelPnts;

            public byte StatType; // 1 for set stats, 2 for relation to owner's stats
            public byte LevelingType; // 0 for leveling on own, 1 for not leveling

            public byte[] Stat;

            public int[] Skill;

            public byte Evolvable;
            public int EvolveLevel;
            public int EvolveNum;
        }

        internal struct PlayerPetRec
        {
            public int Num;
            public int Health;
            public int Mana;
            public int Level;
            public int[] Stat;
            public int[] Skill;
            public int X;
            public int Y;
            public int Dir;
            public byte Alive;
            public int AttackBehaviour;
            public byte AdoptiveStats;
            public int Points;
            public int Exp;
        }



        public static void SavePets()
        {
            int i;

            for (i = 1; i <= Constants.MAX_PETS; i++)
            {
                SavePet(i);
                //Application.DoEvents();
            }
        }

        public static void SavePet(int petNum)
        {
            string filename;
            int i;

            filename = Application.StartupPath + @"\data\pets\pet" + petNum + ".dat";

            ByteStream writer = new ByteStream(100);

            writer.WriteInt32(Pet[petNum].Num);
            writer.WriteString(Pet[petNum].Name.Trim());
            writer.WriteInt32(Pet[petNum].Sprite);
            writer.WriteInt32(Pet[petNum].Range);
            writer.WriteInt32(Pet[petNum].Level);
            writer.WriteInt32(Pet[petNum].MaxLevel);
            writer.WriteInt32(Pet[petNum].ExpGain);
            writer.WriteInt32(Pet[petNum].LevelPnts);

            writer.WriteByte(Pet[petNum].StatType);
            writer.WriteByte(Pet[petNum].LevelingType);

            for (i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                writer.WriteByte(Pet[petNum].Stat[i]);

            for (i = 1; i <= 4; i++)
                writer.WriteInt32(Pet[petNum].Skill[i]);

            writer.WriteByte(Pet[petNum].Evolvable);
            writer.WriteInt32(Pet[petNum].EvolveLevel);
            writer.WriteInt32(Pet[petNum].EvolveNum);

            BinaryFile.Save(filename, ref writer);
        }

        public static void LoadPets()
        {
            int i;

            ClearPets();
            CheckPets();

            for (i = 1; i <= Constants.MAX_PETS; i++)
                LoadPet(i);
        }

        public static void LoadPet(int petNum)
        {
            ByteStream reader = new ByteStream();
            string filename;
            int i;

            filename = Application.StartupPath + @"\data\pets\pet" + petNum + ".dat";

            BinaryFile.Load(filename, ref reader);

            Pet[petNum].Num = reader.ReadInt32();
            Pet[petNum].Name = reader.ReadString();
            Pet[petNum].Sprite = reader.ReadInt32();
            Pet[petNum].Range = reader.ReadInt32();
            Pet[petNum].Level = reader.ReadInt32();
            Pet[petNum].MaxLevel = reader.ReadInt32();
            Pet[petNum].ExpGain = reader.ReadInt32();
            Pet[petNum].LevelPnts = reader.ReadInt32();

            Pet[petNum].StatType = reader.ReadByte();
            Pet[petNum].LevelingType = reader.ReadByte();

            Pet[petNum].Stat = new byte[7];
            for (i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                Pet[petNum].Stat[i] = reader.ReadByte();

            Pet[petNum].Skill = new int[5];
            for (i = 1; i <= 4; i++)
                Pet[petNum].Skill[i] = reader.ReadInt32();

            Pet[petNum].Evolvable = reader.ReadByte();
            Pet[petNum].EvolveLevel = reader.ReadInt32();
            Pet[petNum].EvolveNum = reader.ReadInt32();
        }

        public static void CheckPets()
        {
            for (var i = 1; i <= Constants.MAX_PETS; i++)
            {
                if (!File.Exists(Application.StartupPath + @"\Data\pets\pet" + i + ".dat"))
                    SavePet(i);
            }
        }

        public static void ClearPet(int petNum)
        {
            Pet[petNum].Name = "";

            Pet[petNum].Stat = new byte[7];
            Pet[petNum].Skill = new int[5];
        }

        public static void ClearPets()
        {
            int i;

            Pet = new PetRec[101];
            for (i = 1; i <= Constants.MAX_PETS; i++)
                ClearPet(i);
        }



        public static void SendPets(int index)
        {
            int i;

            for (i = 1; i <= Constants.MAX_PETS; i++)
            {
                if (Pet[i].Name.Length > 0)
                    SendUpdatePetTo(index, i);
            }
        }

        public static void SendUpdatePetToAll(int petNum)
        {
            var buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SUpdatePet);

            buffer.WriteInt32(petNum);

            {
                buffer.WriteInt32(Pet[petNum].Num);
                if (Pet[petNum].Name == null) { Pet[petNum].Name = "Null"; }
                buffer.WriteString(Pet[petNum].Name.Trim());
                buffer.WriteInt32(Pet[petNum].Sprite);
                buffer.WriteInt32(Pet[petNum].Range);
                buffer.WriteInt32(Pet[petNum].Level);
                buffer.WriteInt32(Pet[petNum].MaxLevel);
                buffer.WriteInt32(Pet[petNum].ExpGain);
                buffer.WriteInt32(Pet[petNum].LevelPnts);
                buffer.WriteInt32(Pet[petNum].StatType);
                buffer.WriteInt32(Pet[petNum].LevelingType);

                for (var i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                    buffer.WriteInt32(Pet[petNum].Stat[i]);

                for (int i = 1; i <= 4; i++)
                    buffer.WriteInt32(Pet[petNum].Skill[i]);

                buffer.WriteInt32(Pet[petNum].Evolvable);
                buffer.WriteInt32(Pet[petNum].EvolveLevel);
                buffer.WriteInt32(Pet[petNum].EvolveNum);
            }

            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendUpdatePetTo(int index, int petNum)
        {
            var buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SUpdatePet);

            buffer.WriteInt32(petNum);

            {
                buffer.WriteInt32(Pet[petNum].Num);
                if (Pet[petNum].Name == null) { Pet[petNum].Name = "Null"; }
                buffer.WriteString(Pet[petNum].Name.Trim());
                buffer.WriteInt32(Pet[petNum].Sprite);
                buffer.WriteInt32(Pet[petNum].Range);
                buffer.WriteInt32(Pet[petNum].Level);
                buffer.WriteInt32(Pet[petNum].MaxLevel);
                buffer.WriteInt32(Pet[petNum].ExpGain);
                buffer.WriteInt32(Pet[petNum].LevelPnts);
                buffer.WriteInt32(Pet[petNum].StatType);
                buffer.WriteInt32(Pet[petNum].LevelingType);

                for (var i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                    buffer.WriteInt32(Pet[petNum].Stat[i]);

                for (int i = 1; i <= 4; i++)
                    buffer.WriteInt32(Pet[petNum].Skill[i]);

                buffer.WriteInt32(Pet[petNum].Evolvable);
                buffer.WriteInt32(Pet[petNum].EvolveLevel);
                buffer.WriteInt32(Pet[petNum].EvolveNum);
            }

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        internal static void SendUpdatePlayerPet(int index, bool ownerOnly)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SUpdatePlayerPet);

            buffer.WriteInt32(index);

            buffer.WriteInt32(GetPetNum(index));
            buffer.WriteInt32(GetPetVital(index, Enums.VitalType.HP));
            buffer.WriteInt32(GetPetVital(index, Enums.VitalType.MP));
            buffer.WriteInt32(GetPetLevel(index));

            for (var i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                buffer.WriteInt32(GetPetStat(index, (Enums.StatType)i));

            for (int i = 1; i <= 4; i++)
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Skill[i]);

            buffer.WriteInt32(GetPetX(index));
            buffer.WriteInt32(GetPetY(index));
            buffer.WriteInt32(GetPetDir(index));

            buffer.WriteInt32(GetPetMaxVital(index, Enums.VitalType.HP));
            buffer.WriteInt32(GetPetMaxVital(index, Enums.VitalType.MP));

            buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Alive);

            buffer.WriteInt32(GetPetBehaviour(index));
            buffer.WriteInt32(GetPetPoints(index));
            buffer.WriteInt32(GetPetExp(index));
            buffer.WriteInt32(GetPetNextLevel(index));

            if (ownerOnly)
                S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            else
                S_NetworkConfig.SendDataToMap(S_Players.GetPlayerMap(index), ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendPetAttack(int index, int mapNum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SPetAttack);
            buffer.WriteInt32(index);
            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendPetXy(int index, int x, int y)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SPetXY);
            buffer.WriteInt32(index);
            buffer.WriteInt32(x);
            buffer.WriteInt32(y);
            S_NetworkConfig.SendDataToMap(S_Players.GetPlayerMap(index), ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendPetExp(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SPetExp);
            buffer.WriteInt32(GetPetExp(index));
            buffer.WriteInt32(GetPetNextLevel(index));
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendPetVital(int index, Enums.VitalType vital)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SPetVital);

            buffer.WriteInt32(index);

            if (vital == Enums.VitalType.HP)
                buffer.WriteInt32(1);
            else if (vital == Enums.VitalType.MP)
                buffer.WriteInt32(2);

            switch (vital)
            {
                case Enums.VitalType.HP:
                    {
                        buffer.WriteInt32(GetPetMaxVital(index, Enums.VitalType.HP));
                        buffer.WriteInt32(GetPetVital(index, Enums.VitalType.HP));
                        break;
                    }

                case Enums.VitalType.MP:
                    {
                        buffer.WriteInt32(GetPetMaxVital(index, Enums.VitalType.MP));
                        buffer.WriteInt32(GetPetVital(index, Enums.VitalType.MP));
                        break;
                    }
            }

            S_NetworkConfig.SendDataToMap(S_Players.GetPlayerMap(index), ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendClearPetSpellBuffer(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SClearPetSkillBuffer);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }



        public static void Packet_RequestEditPet(int index, ref byte[] data)
        {
            var buffer = new ByteStream(4);

            if (S_Players.GetPlayerAccess(index) < (int)Enums.AdminType.Developer)
                return;

            buffer.WriteInt32((int)Packets.ServerPackets.SPetEditor);
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void Packet_SavePet(int index, ref byte[] data)
        {
            int petNum;
            int i;
            ByteStream buffer = new ByteStream(data);

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (int)Enums.AdminType.Developer)
                return;

            petNum = buffer.ReadInt32();

            // Prevent hacking
            if (petNum < 0 || petNum > Constants.MAX_PETS)
                return;

            {
                Pet[petNum].Num = buffer.ReadInt32();
                Pet[petNum].Name = buffer.ReadString();
                Pet[petNum].Sprite = buffer.ReadInt32();
                Pet[petNum].Range = buffer.ReadInt32();
                Pet[petNum].Level = buffer.ReadInt32();
                Pet[petNum].MaxLevel = buffer.ReadInt32();
                Pet[petNum].ExpGain = buffer.ReadInt32();
                Pet[petNum].LevelPnts = buffer.ReadInt32();
                Pet[petNum].StatType = (byte)buffer.ReadInt32();
                Pet[petNum].LevelingType = (byte)buffer.ReadInt32();

                for (i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                    Pet[petNum].Stat[i] = (byte)buffer.ReadInt32();

                for (i = 1; i <= 4; i++)
                    Pet[petNum].Skill[i] = buffer.ReadInt32();

                Pet[petNum].Evolvable = (byte)buffer.ReadInt32();
                Pet[petNum].EvolveLevel = buffer.ReadInt32();
                Pet[petNum].EvolveNum = buffer.ReadInt32();
            }

            // Save it
            SendUpdatePetToAll(petNum);
            SavePet(petNum);
            modDatabase.Addlog(S_Players.GetPlayerLogin(index) + " saved Pet #" + petNum + ".", S_Constants.ADMIN_LOG);
            SendPets(index);
        }

        public static void Packet_RequestPets(int index, ref byte[] data)
        {
            SendPets(index);
        }

        public static void Packet_SummonPet(int index, ref byte[] data)
        {
            if (PetAlive(index))
                ReCallPet(index);
            else
                SummonPet(index);
        }

        public static void Packet_PetMove(int index, ref byte[] data)
        {
            int x;
            int y;
            int i;
            ByteStream buffer = new ByteStream(data);
            x = buffer.ReadInt32();
            y = buffer.ReadInt32();

            // Prevent subscript out of range
            if (x < 0 || x > modTypes.Map[S_Players.GetPlayerMap(index)].MaxX || y < 0 || y > modTypes.Map[S_Players.GetPlayerMap(index)].MaxY)
                return;
            var loopTo = S_GameLogic.GetPlayersOnline();

            // Check for a player
            for (i = 1; i <= loopTo; i++)
            {
                if (S_NetworkConfig.IsPlaying(i))
                {
                    if (S_Players.GetPlayerMap(index) == S_Players.GetPlayerMap(i) && S_Players.GetPlayerX(i) == x && S_Players.GetPlayerY(i) == y)
                    {
                        if (i == index)
                        {
                            // Change target
                            if (modTypes.TempPlayer[index].PetTargetType == (byte)Enums.TargetType.Player && modTypes.TempPlayer[index].PetTarget == i)
                            {
                                modTypes.TempPlayer[index].PetTarget = 0;
                                modTypes.TempPlayer[index].PetTargetType = (byte)Enums.TargetType.None;
                                modTypes.TempPlayer[index].PetBehavior = PetBehaviourGoto;
                                modTypes.TempPlayer[index].GoToX = x;
                                modTypes.TempPlayer[index].GoToY = y;
                                // send target to player
                                S_NetworkSend.PlayerMsg(index, "Your pet is no longer following you.", (int)Enums.ColorType.BrightGreen);
                            }
                            else
                            {
                                modTypes.TempPlayer[index].PetTarget = i;
                                modTypes.TempPlayer[index].PetTargetType = (byte)Enums.TargetType.Player;
                                // send target to player
                                modTypes.TempPlayer[index].PetBehavior = PetBehaviourFollow;
                                S_NetworkSend.PlayerMsg(index, "Your " + GetPetName(index).Trim() + " is now following you.", (int)Enums.ColorType.BrightGreen);
                            }
                        }
                        else
// Change target
if (modTypes.TempPlayer[index].PetTargetType == (byte)Enums.TargetType.Player && modTypes.TempPlayer[index].PetTarget == i)
                        {
                            modTypes.TempPlayer[index].PetTarget = 0;
                            modTypes.TempPlayer[index].PetTargetType = (byte)Enums.TargetType.None;
                            // send target to player
                            S_NetworkSend.PlayerMsg(index, "Your pet is no longer targetting " + S_Players.GetPlayerName(i).Trim() + ".", (int)Enums.ColorType.BrightGreen);
                        }
                        else
                        {
                            modTypes.TempPlayer[index].PetTarget = i;
                            modTypes.TempPlayer[index].PetTargetType = (byte)Enums.TargetType.Player;
                            // send target to player
                            S_NetworkSend.PlayerMsg(index, "Your pet is now targetting " + S_Players.GetPlayerName(i).Trim() + ".", (int)Enums.ColorType.BrightGreen);
                        }
                        return;
                    }
                }

                if (PetAlive(i) && i != index)
                {
                    if (GetPetX(i) == x && GetPetY(i) == y)
                    {
                        // Change target
                        if (modTypes.TempPlayer[index].PetTargetType == (byte)Enums.TargetType.Pet && modTypes.TempPlayer[index].PetTarget == i)
                        {
                            modTypes.TempPlayer[index].PetTarget = 0;
                            modTypes.TempPlayer[index].PetTargetType = (byte)Enums.TargetType.None;
                            // send target to player
                            S_NetworkSend.PlayerMsg(index, "Your pet is no longer targetting " + S_Players.GetPlayerName(i).Trim() + "'s " + GetPetName(i).Trim() + ".", (int)Enums.ColorType.BrightGreen);
                        }
                        else
                        {
                            modTypes.TempPlayer[index].PetTarget = i;
                            modTypes.TempPlayer[index].PetTargetType = (int)Enums.TargetType.Pet;
                            // send target to player
                            S_NetworkSend.PlayerMsg(index, "Your pet is now targetting " + S_Players.GetPlayerName(i).Trim() + "'s " + GetPetName(i).Trim() + ".", (int)Enums.ColorType.BrightGreen);
                        }
                        return;
                    }
                }
            }

            // Search For Target First
            // Check for an npc
            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
            {
                if (modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].Num > 0 && modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].X == x && modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].Y == y)
                {
                    if (modTypes.TempPlayer[index].PetTarget == i && modTypes.TempPlayer[index].PetTargetType == (int)Enums.TargetType.Npc)
                    {
                        // Change target
                        modTypes.TempPlayer[index].PetTarget = 0;
                        modTypes.TempPlayer[index].PetTargetType = (int)Enums.TargetType.None;
                        // send target to player
                        S_NetworkSend.PlayerMsg(index, "Your " + GetPetName(index).Trim() + "'s target is no longer a " + Types.Npc[modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].Num].Name.Trim() + "!", (int)Enums.ColorType.BrightGreen);
                        return;
                    }
                    else
                    {
                        // Change target
                        modTypes.TempPlayer[index].PetTarget = i;
                        modTypes.TempPlayer[index].PetTargetType = (int)Enums.TargetType.Npc;
                        // send target to player
                        S_NetworkSend.PlayerMsg(index, "Your " + GetPetName(index).Trim() + "'s target is now a " + Types.Npc[modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].Num].Name.Trim() + "!", (int)Enums.ColorType.BrightGreen);
                        return;
                    }
                }
            }

            modTypes.TempPlayer[index].PetBehavior = PetBehaviourGoto;
            modTypes.TempPlayer[index].PetTargetType = 0;
            modTypes.TempPlayer[index].PetTarget = 0;
            modTypes.TempPlayer[index].GoToX = x;
            modTypes.TempPlayer[index].GoToY = y;

            buffer.Dispose();
        }

        public static void Packet_SetPetBehaviour(int index, ref byte[] data)
        {
            int behaviour;
            ByteStream buffer = new ByteStream(data);
            behaviour = buffer.ReadInt32();

            if (PetAlive(index))
            {
                switch (behaviour)
                {
                    case PetAttackBehaviourAttackonsight:
                        {
                            SetPetBehaviour(index, PetAttackBehaviourAttackonsight);
                            S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(index), "Agressive Mode!", (int)Enums.ColorType.White, 0, GetPetX(index) * 32, GetPetY(index) * 32, index);
                            break;
                        }

                    case PetAttackBehaviourGuard:
                        {
                            SetPetBehaviour(index, PetAttackBehaviourGuard);
                            S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(index), "Defensive Mode!", (int)Enums.ColorType.White, 0, GetPetX(index) * 32, GetPetY(index) * 32, index);
                            break;
                        }
                }
            }

            buffer.Dispose();
        }

        public static void Packet_ReleasePet(int index, ref byte[] data)
        {
            if (GetPetNum(index) > 0)
                ReleasePet(index);
        }

        public static void Packet_PetSkill(int index, ref byte[] data)
        {
            int n;
            ByteStream buffer = new ByteStream(data);
            // Skill slot
            n = buffer.ReadInt32();

            buffer.Dispose();

            // set the skill buffer before castin
            BufferPetSkill(index, n);
        }

        public static void Packet_UsePetStatPoint(int index, ref byte[] data)
        {
            byte pointType;
            string sMes = "";
            ByteStream buffer = new ByteStream(data);
            pointType = (byte)buffer.ReadInt32();
            buffer.Dispose();

            // Prevent hacking
            if ((pointType < 0) || (pointType > (int)Enums.StatType.Count))
                return;

            if (!PetAlive(index))
                return;

            // Make sure they have points
            if (GetPetPoints(index) > 0)
            {

                // make sure they're not maxed#
                if (GetPetStat(index, (StatType)pointType) >= 255)
                {
                    S_NetworkSend.PlayerMsg(index, "You cannot spend any more points on that stat for your pet.", (int)Enums.ColorType.BrightRed);
                    return;
                }

                SetPetPoints(index, GetPetPoints(index) - 1);

                // Everything is ok
                switch (pointType)
                {
                    case (int)Enums.StatType.Strength:
                        {
                            SetPetStat(index, (StatType)pointType, GetPetStat(index, (StatType)pointType) + 1);
                            sMes = "Strength";
                            break;
                        }

                    case (int)Enums.StatType.Endurance:
                        {
                            SetPetStat(index, (StatType)pointType, GetPetStat(index, (StatType)pointType) + 1);
                            sMes = "Endurance";
                            break;
                        }

                    case (int)Enums.StatType.Intelligence:
                        {
                            SetPetStat(index, (StatType)pointType, GetPetStat(index, (StatType)pointType) + 1);
                            sMes = "Intelligence";
                            break;
                        }

                    case (int)Enums.StatType.Luck:
                        {
                            SetPetStat(index, (StatType)pointType, GetPetStat(index, (StatType)pointType) + 1);
                            sMes = "Agility";
                            break;
                        }

                    case (int)Enums.StatType.Spirit:
                        {
                            SetPetStat(index, (StatType)pointType, GetPetStat(index, (StatType)pointType) + 1);
                            sMes = "Willpower";
                            break;
                        }
                }

                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(index), "+1 " + sMes, (int)Enums.ColorType.White, 1, (GetPetX(index) * 32), (GetPetY(index) * 32));
            }
            else
                return;

            // Send the update
            SendUpdatePlayerPet(index, true);
        }



        internal static void UpdatePetAi()
        {
            bool didWalk = false;
            int givePetHpTimer = 0;
            int playerindex = 0;
            int mapNum = 0;
            int tickCount = 0;
            int i = 0;
            int n = 0;
            int distanceX = 0;
            int distanceY = 0;
            int tmpdir = 0;
            int target = 0;
            byte targetTypes = 0;
            int targetX = 0;
            int targetY = 0;
            bool targetVerify = false;

            for (mapNum = 1; mapNum <= S_Instances.MAX_CACHED_MAPS; mapNum++)
            {
                var loopTo = S_GameLogic.GetPlayersOnline();
                for (playerindex = 1; playerindex <= loopTo; playerindex++)
                {
                    tickCount = S_General.GetTimeMs();

                    if (S_Players.GetPlayerMap(playerindex) == mapNum && PetAlive(playerindex))
                    {
                        // // This is used for ATTACKING ON SIGHT //

                        // If the npc is a attack on sight, search for a player on the map
                        if (GetPetBehaviour(playerindex) != PetAttackBehaviourDonothing)
                        {

                            // make sure it's not stunned
                            if (!(modTypes.TempPlayer[playerindex].PetStunDuration > 0))
                            {
                                var loopTo1 = S_NetworkConfig.Socket.HighIndex;
                                for (i = 1; i <= loopTo1; i++)
                                {
                                    if (modTypes.TempPlayer[playerindex].PetTargetType > 0)
                                    {
                                        if (modTypes.TempPlayer[playerindex].PetTargetType == 1 && modTypes.TempPlayer[playerindex].PetTarget == playerindex)
                                        {
                                        }
                                        else
                                            break;
                                    }

                                    if (S_NetworkConfig.IsPlaying(i) && i != playerindex)
                                    {
                                        if (S_Players.GetPlayerMap(i) == mapNum && S_Players.GetPlayerAccess(i) <= (int)Enums.AdminType.Monitor)
                                        {
                                            if (PetAlive(i))
                                            {
                                                n = GetPetRange(playerindex);
                                                distanceX = GetPetX(playerindex) - GetPetX(i);
                                                distanceY = GetPetY(playerindex) - GetPetY(i);

                                                // Make sure we get a positive value
                                                if (distanceX < 0)
                                                    distanceX = distanceX * -1;
                                                if (distanceY < 0)
                                                    distanceY = distanceY * -1;

                                                // Are they in range?  if so GET'M!
                                                if (distanceX <= n && distanceY <= n)
                                                {
                                                    if (GetPetBehaviour(playerindex) == PetAttackBehaviourAttackonsight)
                                                    {
                                                        modTypes.TempPlayer[playerindex].PetTargetType = (int)Enums.TargetType.Pet; // pet
                                                        modTypes.TempPlayer[playerindex].PetTarget = i;
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                n = GetPetRange(playerindex);
                                                distanceX = GetPetX(playerindex) - S_Players.GetPlayerX(i);
                                                distanceY = GetPetY(playerindex) - S_Players.GetPlayerY(i);

                                                // Make sure we get a positive value
                                                if (distanceX < 0)
                                                    distanceX = distanceX * -1;
                                                if (distanceY < 0)
                                                    distanceY = distanceY * -1;

                                                // Are they in range?  if so GET'M!
                                                if (distanceX <= n && distanceY <= n)
                                                {
                                                    if (GetPetBehaviour(playerindex) == PetAttackBehaviourAttackonsight)
                                                    {
                                                        modTypes.TempPlayer[playerindex].PetTargetType = (int)Enums.TargetType.Player; // player
                                                        modTypes.TempPlayer[playerindex].PetTarget = i;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                if (modTypes.TempPlayer[playerindex].PetTargetType == 0)
                                {
                                    for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                                    {
                                        if (modTypes.TempPlayer[playerindex].PetTargetType > 0)
                                            break;
                                        if (PetAlive(playerindex))
                                        {
                                            n = GetPetRange(playerindex);
                                            distanceX = GetPetX(playerindex) - modTypes.MapNpc[S_Players.GetPlayerMap(playerindex)].Npc[i].X;
                                            distanceY = GetPetY(playerindex) - modTypes.MapNpc[S_Players.GetPlayerMap(playerindex)].Npc[i].Y;

                                            // Make sure we get a positive value
                                            if (distanceX < 0)
                                                distanceX = distanceX * -1;
                                            if (distanceY < 0)
                                                distanceY = distanceY * -1;

                                            // Are they in range?  if so GET'M!
                                            if (distanceX <= n && distanceY <= n)
                                            {
                                                if (GetPetBehaviour(playerindex) == PetAttackBehaviourAttackonsight)
                                                {
                                                    modTypes.TempPlayer[playerindex].PetTargetType = (int)Enums.TargetType.Npc; // npc
                                                    modTypes.TempPlayer[playerindex].PetTarget = i;
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            targetVerify = false;

                            // // This is used for Pet walking/targetting //

                            // Make sure theres a npc with the map
                            if (modTypes.TempPlayer[playerindex].PetStunDuration > 0)
                            {
                                // check if we can unstun them
                                if (S_General.GetTimeMs() > modTypes.TempPlayer[playerindex].PetStunTimer + (modTypes.TempPlayer[playerindex].PetStunDuration * 1000))
                                {
                                    modTypes.TempPlayer[playerindex].PetStunDuration = 0;
                                    modTypes.TempPlayer[playerindex].PetStunTimer = 0;
                                }
                            }
                            else
                            {
                                target = modTypes.TempPlayer[playerindex].PetTarget;
                                targetTypes = (byte)modTypes.TempPlayer[playerindex].PetTargetType;

                                // Check to see if its time for the npc to walk
                                if (GetPetBehaviour(playerindex) != PetAttackBehaviourDonothing)
                                {
                                    if (targetTypes == (int)Enums.TargetType.Player)
                                    {
                                        // Check to see if we are following a player or not
                                        if (target > 0)
                                        {

                                            // Check if the player is even playing, if so follow'm
                                            if (S_NetworkConfig.IsPlaying(target) && S_Players.GetPlayerMap(target) == mapNum)
                                            {
                                                if (target != playerindex)
                                                {
                                                    didWalk = false;
                                                    targetVerify = true;
                                                    targetY = S_Players.GetPlayerY(target);
                                                    targetX = S_Players.GetPlayerX(target);
                                                }
                                            }
                                            else
                                            {
                                                modTypes.TempPlayer[playerindex].PetTargetType = (int)Enums.TargetType.None; // clear
                                                modTypes.TempPlayer[playerindex].PetTarget = 0;
                                            }
                                        }
                                    }
                                    else if (targetTypes == (int)Enums.TargetType.Npc)
                                    {
                                        if (target > 0)
                                        {
                                            if (modTypes.MapNpc[mapNum].Npc[target].Num > 0)
                                            {
                                                didWalk = false;
                                                targetVerify = true;
                                                targetY = modTypes.MapNpc[mapNum].Npc[target].Y;
                                                targetX = modTypes.MapNpc[mapNum].Npc[target].X;
                                            }
                                            else
                                            {
                                                modTypes.TempPlayer[playerindex].PetTargetType = (int)Enums.TargetType.None; // clear
                                                modTypes.TempPlayer[playerindex].PetTarget = 0;
                                            }
                                        }
                                    }
                                    else if (targetTypes == (int)Enums.TargetType.Pet)
                                    {
                                        if (target > 0)
                                        {
                                            if (S_NetworkConfig.IsPlaying(target) && S_Players.GetPlayerMap(target) == mapNum && PetAlive(target))
                                            {
                                                didWalk = false;
                                                targetVerify = true;
                                                targetY = GetPetY(target);
                                                targetX = GetPetX(target);
                                            }
                                            else
                                            {
                                                modTypes.TempPlayer[playerindex].PetTargetType = (int)Enums.TargetType.None; // clear
                                                modTypes.TempPlayer[playerindex].PetTarget = 0;
                                            }
                                        }
                                    }
                                }

                                if (targetVerify)
                                {
                                    didWalk = false;

                                    if (S_Events.IsOneBlockAway(GetPetX(playerindex), GetPetY(playerindex), targetX, targetY))
                                    {
                                        if (GetPetX(playerindex) < targetX)
                                        {
                                            PetDir(playerindex, (byte)Enums.DirectionType.Right);
                                            didWalk = true;
                                        }
                                        else if (GetPetX(playerindex) > targetX)
                                        {
                                            PetDir(playerindex, (int)Enums.DirectionType.Left);
                                            didWalk = true;
                                        }
                                        else if (GetPetY(playerindex) < targetY)
                                        {
                                            PetDir(playerindex, (int)Enums.DirectionType.Up);
                                            didWalk = true;
                                        }
                                        else if (GetPetY(playerindex) > targetY)
                                        {
                                            PetDir(playerindex, (int)Enums.DirectionType.Down);
                                            didWalk = true;
                                        }
                                    }
                                    else
                                        didWalk = PetTryWalk(playerindex, targetX, targetY);
                                }
                                else if (modTypes.TempPlayer[playerindex].PetBehavior == PetBehaviourGoto && targetVerify == false)
                                {
                                    if (GetPetX(playerindex) == modTypes.TempPlayer[playerindex].GoToX && GetPetY(playerindex) == modTypes.TempPlayer[playerindex].GoToY)
                                    {
                                    }
                                    else
                                    {
                                        didWalk = false;
                                        targetX = modTypes.TempPlayer[playerindex].GoToX;
                                        targetY = modTypes.TempPlayer[playerindex].GoToY;
                                        didWalk = PetTryWalk(playerindex, targetX, targetY);

                                        if (didWalk == false)
                                        {
                                            tmpdir = (byte)Conversion.Int(VBMath.Rnd() * 4);

                                            if (tmpdir == 1)
                                            {
                                                tmpdir = (byte)Conversion.Int(VBMath.Rnd() * 4);
                                                if (CanPetMove(playerindex, mapNum, (byte)tmpdir))
                                                    PetMove(playerindex, mapNum, tmpdir, (byte)Enums.MovementType.Walking);
                                            }
                                        }
                                    }
                                }
                                else if (modTypes.TempPlayer[playerindex].PetBehavior == PetBehaviourFollow)
                                {
                                    if (IsPetByPlayer(playerindex))
                                    {
                                    }
                                    else
                                    {
                                        didWalk = false;
                                        targetX = S_Players.GetPlayerX(playerindex);
                                        targetY = S_Players.GetPlayerY(playerindex);
                                        didWalk = PetTryWalk(playerindex, targetX, targetY);

                                        if (didWalk == false)
                                        {
                                            tmpdir = (byte)Conversion.Int(VBMath.Rnd() * 4);
                                            if (tmpdir == 1)
                                            {
                                                tmpdir = (byte)Conversion.Int(VBMath.Rnd() * 4);
                                                if (CanPetMove(playerindex, mapNum, (byte)tmpdir))
                                                    PetMove(playerindex, mapNum, tmpdir, (byte)Enums.MovementType.Walking);
                                            }
                                        }
                                    }
                                }
                            }

                            // // This is used for pets to attack targets //

                            // Make sure theres a npc with the map
                            target = modTypes.TempPlayer[playerindex].PetTarget;
                            targetTypes = (byte)modTypes.TempPlayer[playerindex].PetTargetType;

                            // Check if the pet can attack the targeted player
                            if (target > 0)
                            {
                                if (targetTypes == (int)Enums.TargetType.Player)
                                {
                                    // Is the target playing and on the same map?
                                    if (S_NetworkConfig.IsPlaying(target) && S_Players.GetPlayerMap(target) == mapNum)
                                    {
                                        if (playerindex != target)
                                            TryPetAttackPlayer(playerindex, target);
                                    }
                                    else
                                    {
                                        // Player left map or game, set target to 0
                                        modTypes.TempPlayer[playerindex].PetTarget = 0;
                                        modTypes.TempPlayer[playerindex].PetTargetType = (int)Enums.TargetType.None; // clear
                                    }
                                }
                                else if (targetTypes == (int)Enums.TargetType.Npc)
                                {
                                    if (modTypes.MapNpc[S_Players.GetPlayerMap(playerindex)].Npc[modTypes.TempPlayer[playerindex].PetTarget].Num > 0)
                                        TryPetAttackNpc(playerindex, modTypes.TempPlayer[playerindex].PetTarget);
                                    else
                                    {
                                        // Player left map or game, set target to 0
                                        modTypes.TempPlayer[playerindex].PetTarget = 0;
                                        modTypes.TempPlayer[playerindex].PetTargetType = (int)Enums.TargetType.None; // clear
                                    }
                                }
                                else if (targetTypes == (int)Enums.TargetType.Pet)
                                {
                                    // Is the target playing and on the same map? AndAlso is pet alive??
                                    if (S_NetworkConfig.IsPlaying(target) && S_Players.GetPlayerMap(target) == mapNum && PetAlive(target))
                                        TryPetAttackPet(playerindex, target);
                                    else
                                    {
                                        // Player left map or game, set target to 0
                                        modTypes.TempPlayer[playerindex].PetTarget = 0;
                                        modTypes.TempPlayer[playerindex].PetTargetType = (int)Enums.TargetType.None; // clear
                                    }
                                }
                            }

                            // ////////////////////////////////////////////
                            // // This is used for regenerating Pet's HP //
                            // ////////////////////////////////////////////
                            // Check to see if we want to regen some of the npc's hp
                            if (!modTypes.TempPlayer[playerindex].PetstopRegen)
                            {
                                if (PetAlive(playerindex) && tickCount > givePetHpTimer + 10000)
                                {
                                    if (GetPetVital(playerindex, Enums.VitalType.HP) > 0)
                                    {
                                        SetPetVital(playerindex, Enums.VitalType.HP, GetPetVital(playerindex, Enums.VitalType.HP) + GetPetVitalRegen(playerindex, Enums.VitalType.HP));
                                        SetPetVital(playerindex, Enums.VitalType.MP, GetPetVital(playerindex, Enums.VitalType.MP) + GetPetVitalRegen(playerindex, Enums.VitalType.MP));

                                        // Check if they have more then they should and if so just set it to max
                                        if (GetPetVital(playerindex, Enums.VitalType.HP) > GetPetMaxVital(playerindex, Enums.VitalType.HP))
                                            SetPetVital(playerindex, Enums.VitalType.HP, GetPetMaxVital(playerindex, Enums.VitalType.HP));

                                        if (GetPetVital(playerindex, Enums.VitalType.MP) > GetPetMaxVital(playerindex, Enums.VitalType.MP))
                                            SetPetVital(playerindex, Enums.VitalType.MP, GetPetMaxVital(playerindex, Enums.VitalType.MP));

                                        if (!(GetPetVital(playerindex, Enums.VitalType.HP) == GetPetMaxVital(playerindex, Enums.VitalType.HP)))
                                        {
                                            SendPetVital(playerindex, Enums.VitalType.HP);
                                            SendPetVital(playerindex, Enums.VitalType.MP);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            // Make sure we reset the timer for npc hp regeneration
            if (S_General.GetTimeMs() > givePetHpTimer + 10000)
                givePetHpTimer = S_General.GetTimeMs();
        }

        public static void SummonPet(int index)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Alive = 1;
            S_NetworkSend.PlayerMsg(index, "You summoned your " + GetPetName(index).Trim() + "!", (int)Enums.ColorType.BrightGreen);
            SendUpdatePlayerPet(index, false);
        }

        public static void ReCallPet(int index)
        {
            S_NetworkSend.PlayerMsg(index, "You recalled your " + GetPetName(index).Trim() + "!", (int)Enums.ColorType.BrightGreen);
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Alive = 0;
            SendUpdatePlayerPet(index, false);
        }

        public static void ReleasePet(int index)
        {
            int i;

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Alive = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Num = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.AttackBehaviour = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Dir = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Health = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Level = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Mana = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.X = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Y = 0;

            modTypes.TempPlayer[index].PetTarget = 0;
            modTypes.TempPlayer[index].PetTargetType = 0;
            modTypes.TempPlayer[index].GoToX = -1;
            modTypes.TempPlayer[index].GoToY = -1;

            for (i = 1; i <= 4; i++)
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Skill[i] = 0;

            for (i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Stat[i] = 0;

            SendUpdatePlayerPet(index, false);

            modDatabase.SavePlayer(index);

            S_NetworkSend.PlayerMsg(index, "You released your pet!", (int)Enums.ColorType.BrightGreen);

            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
            {
                if (modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].Vital[(int)Enums.VitalType.HP] > 0)
                {
                    if (modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].TargetType == (int)Enums.TargetType.Pet)
                    {
                        if (modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].Target == index)
                        {
                            modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].TargetType = (int)Enums.TargetType.Player;
                            modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].Target = index;
                        }
                    }
                }
            }
        }

        public static void AdoptPet(int index, int petNum)
        {
            if (GetPetNum(index) == 0)
                S_NetworkSend.PlayerMsg(index, "You have adopted a " + Pet[petNum].Name.Trim(), (int)Enums.ColorType.BrightGreen);
            else
            {
                S_NetworkSend.PlayerMsg(index, "You already have a " + Pet[petNum].Name.Trim() + ", release your old pet first!", (int)Enums.ColorType.BrightGreen);
                return;
            }

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Num = petNum;

            for (var i = 1; i <= 4; i++)
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Skill[i] = Pet[petNum].Skill[i];

            if (Pet[petNum].StatType == 0)
            {
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Health = S_Players.GetPlayerMaxVital(index, Enums.VitalType.HP);
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Mana = S_Players.GetPlayerMaxVital(index, Enums.VitalType.MP);
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Level = S_Players.GetPlayerLevel(index);

                for (var i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Stat[i] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Stat[i];

                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.AdoptiveStats = 1;
            }
            else
            {
                for (var i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Stat[i] = Pet[petNum].Stat[i];

                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Level = Pet[petNum].Level;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.AdoptiveStats = 0;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Health = GetPetMaxVital(index, Enums.VitalType.HP);
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Mana = GetPetMaxVital(index, Enums.VitalType.MP);
            }

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.X = S_Players.GetPlayerX(index);
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Y = S_Players.GetPlayerY(index);

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Alive = 1;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Points = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Exp = 0;

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.AttackBehaviour = PetAttackBehaviourGuard; // By default it will guard but this can be changed

            modDatabase.SavePlayer(index);

            SendUpdatePlayerPet(index, false);
        }

        public static void PetMove(int index, int mapNum, int dir, int movement)
        {
            ByteStream buffer = new ByteStream(4);

            if (mapNum < 1 || mapNum > Constants.MAX_MAPS || index <= 0 || index > Constants.MAX_PLAYERS || dir < (int)Enums.DirectionType.Up || dir > (int)Enums.DirectionType.Right || movement < 1 || movement > 2)
                return;

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Dir = dir;

            switch (dir)
            {
                case (int)Enums.DirectionType.Up:
                    {
                        SetPetY(index, GetPetY(index) - 1);
                        break;
                    }

                case (int)Enums.DirectionType.Down:
                    {
                        SetPetY(index, GetPetY(index) + 1);
                        break;
                    }

                case (int)Enums.DirectionType.Left:
                    {
                        SetPetX(index, GetPetX(index) - 1);
                        break;
                    }

                case (int)Enums.DirectionType.Right:
                    {
                        SetPetX(index, GetPetX(index) + 1);
                        break;
                    }
            }

            buffer.WriteInt32((int)Packets.ServerPackets.SPetMove);
            buffer.WriteInt32(index);
            buffer.WriteInt32(GetPetX(index));
            buffer.WriteInt32(GetPetY(index));
            buffer.WriteInt32(GetPetDir(index));
            buffer.WriteInt32(movement);
            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static bool CanPetMove(int index, int mapNum, byte dir)
        {
            int i;
            int n;
            int x;
            int y;
            bool CanPetMove;
            if (mapNum < 1 || mapNum > Constants.MAX_MAPS || index <= 0 || index > Constants.MAX_PLAYERS || dir < (int)Enums.DirectionType.Up || dir > (int)Enums.DirectionType.Right)
                return false;

            if (index <= 0 || index > Constants.MAX_PLAYERS)
                return false;

            x = GetPetX(index);
            y = GetPetY(index);

            if (x < 0 || x > modTypes.Map[mapNum].MaxX)
                return false;
            if (y < 0 || y > modTypes.Map[mapNum].MaxY)
                return false;

            CanPetMove = true;

            if (modTypes.TempPlayer[index].PetskillBuffer.Skill > 0)
            {
                return false;
            }

            switch (dir)
            {
                case (int)Enums.DirectionType.Up:
                    {
                        // Check to make sure not outside of boundries
                        if (y > 0)
                        {
                            n = modTypes.Map[mapNum].Tile[x, y - 1].Type;

                            // Check to make sure that the tile is walkable
                            if (n != (int)Enums.TileType.None && n != (int)Enums.TileType.NpcSpawn)
                            {
                                return false;
                            }

                            var loopTo = S_GameLogic.GetPlayersOnline();

                            // Check to make sure that there is not a player in the way
                            for (i = 1; i <= loopTo; i++)
                            {
                                if (S_NetworkConfig.IsPlaying(i))
                                {
                                    if ((S_Players.GetPlayerMap(i) == mapNum) && (S_Players.GetPlayerX(i) == GetPetX(index) + 1) && (S_Players.GetPlayerY(i) == GetPetY(index) - 1))
                                    {
                                        return false;
                                    }
                                    else if (PetAlive(i) && (S_Players.GetPlayerMap(i) == mapNum) && (GetPetX(i) == GetPetX(index)) && (GetPetY(i) == GetPetY(index) - 1))
                                    {
                                        return false;
                                    }
                                }
                            }

                            // Check to make sure that there is not another npc in the way
                            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                            {
                                if ((modTypes.MapNpc[mapNum].Npc[i].Num > 0) && (modTypes.MapNpc[mapNum].Npc[i].X == GetPetX(index)) && (modTypes.MapNpc[mapNum].Npc[i].Y == GetPetY(index) - 1))
                                {
                                    return false;
                                }
                            }

                            // Directional blocking
                            byte directionRef = (byte)(Enums.DirectionType.Up + 1);
                            if (S_Players.IsDirBlocked(ref modTypes.Map[mapNum].Tile[GetPetX(index), GetPetY(index)].DirBlock, ref directionRef))
                            {
                                return false;
                            }
                        }
                        else
                            CanPetMove = false;
                        break;
                    }

                case (int)Enums.DirectionType.Down:
                    {

                        // Check to make sure not outside of boundries
                        if (y < modTypes.Map[mapNum].MaxY)
                        {
                            n = modTypes.Map[mapNum].Tile[x, y + 1].Type;

                            // Check to make sure that the tile is walkable
                            if (n != (int)Enums.TileType.None && n != (int)Enums.TileType.NpcSpawn)
                            {
                                return false;
                            }

                            var loopTo1 = S_GameLogic.GetPlayersOnline();
                            for (i = 1; i <= loopTo1; i++)
                            {
                                if (S_NetworkConfig.IsPlaying(i))
                                {
                                    if ((S_Players.GetPlayerMap(i) == mapNum) && (S_Players.GetPlayerX(i) == GetPetX(index)) && (S_Players.GetPlayerY(i) == GetPetY(index) + 1))
                                    {
                                        return false;
                                    }
                                    else if (PetAlive(i) && (S_Players.GetPlayerMap(i) == mapNum) && (GetPetX(i) == GetPetX(index)) && (GetPetY(i) == GetPetY(index) + 1))
                                    {
                                        return false;
                                    }
                                }
                            }

                            // Check to make sure that there is not another npc in the way
                            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                            {
                                if ((modTypes.MapNpc[mapNum].Npc[i].Num > 0) && (modTypes.MapNpc[mapNum].Npc[i].X == GetPetX(index)) && (modTypes.MapNpc[mapNum].Npc[i].Y == GetPetY(index) + 1))
                                {
                                    return false;
                                }
                            }

                            // Directional blocking
                            byte directionRef = (byte)(Enums.DirectionType.Down + 1);
                            if (S_Players.IsDirBlocked(ref modTypes.Map[mapNum].Tile[GetPetX(index), GetPetY(index)].DirBlock, ref directionRef))
                            {
                                return false;
                            }
                        }
                        else
                            CanPetMove = false;
                        break;
                    }

                case (int)Enums.DirectionType.Left:
                    {

                        // Check to make sure not outside of boundries
                        if (x > 0)
                        {
                            n = modTypes.Map[mapNum].Tile[x - 1, y].Type;

                            // Check to make sure that the tile is walkable
                            if (n != (int)Enums.TileType.None && n != (int)Enums.TileType.NpcSpawn)
                            {
                                return false;
                            }

                            var loopTo2 = S_GameLogic.GetPlayersOnline();
                            for (i = 1; i <= loopTo2; i++)
                            {
                                if (S_NetworkConfig.IsPlaying(i))
                                {
                                    if ((S_Players.GetPlayerMap(i) == mapNum) && (S_Players.GetPlayerX(i) == GetPetX(index) - 1) && (S_Players.GetPlayerY(i) == GetPetY(index)))
                                    {
                                        return false;
                                    }
                                    else if (PetAlive(i) && (S_Players.GetPlayerMap(i) == mapNum) && (GetPetX(i) == GetPetX(index) - 1) && (GetPetY(i) == GetPetY(index)))
                                    {
                                        return false;
                                    }
                                }
                            }

                            // Check to make sure that there is not another npc in the way
                            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                            {
                                if ((modTypes.MapNpc[mapNum].Npc[i].Num > 0) && (modTypes.MapNpc[mapNum].Npc[i].X == GetPetX(index) - 1) && (modTypes.MapNpc[mapNum].Npc[i].Y == GetPetY(index)))
                                {
                                    return false;
                                }
                            }

                            // Directional blocking
                            byte directionRef = (byte)(Enums.DirectionType.Left + 1);
                            if (S_Players.IsDirBlocked(ref modTypes.Map[mapNum].Tile[GetPetX(index), GetPetY(index)].DirBlock, ref directionRef))
                            {
                                return false;
                            }
                        }
                        else
                            CanPetMove = false;
                        break;
                    }

                case (int)Enums.DirectionType.Right:
                    {

                        // Check to make sure not outside of boundries
                        if (x < modTypes.Map[mapNum].MaxX)
                        {
                            n = modTypes.Map[mapNum].Tile[x + 1, y].Type;

                            // Check to make sure that the tile is walkable
                            if (n != (int)Enums.TileType.None && n != (int)Enums.TileType.NpcSpawn)
                            {
                                return false;
                            }

                            var loopTo3 = S_GameLogic.GetPlayersOnline();
                            for (i = 1; i <= loopTo3; i++)
                            {
                                if (S_NetworkConfig.IsPlaying(i))
                                {
                                    if ((S_Players.GetPlayerMap(i) == mapNum) && (S_Players.GetPlayerX(i) == GetPetX(index) + 1) && (S_Players.GetPlayerY(i) == GetPetY(index)))
                                    {
                                        return false;
                                    }
                                    else if (PetAlive(i) && (S_Players.GetPlayerMap(i) == mapNum) && (GetPetX(i) == GetPetX(index) + 1) && (GetPetY(i) == GetPetY(index)))
                                    {
                                        return false;
                                    }
                                }
                            }

                            // Check to make sure that there is not another npc in the way
                            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                            {
                                if ((modTypes.MapNpc[mapNum].Npc[i].Num > 0) && (modTypes.MapNpc[mapNum].Npc[i].X == GetPetX(index) + 1) && (modTypes.MapNpc[mapNum].Npc[i].Y == GetPetY(index)))
                                {
                                    return false;
                                }
                            }

                            // Directional blocking
                            byte directionRef = (byte)(Enums.DirectionType.Right + 1);
                            if (S_Players.IsDirBlocked(ref modTypes.Map[mapNum].Tile[GetPetX(index), GetPetY(index)].DirBlock, ref directionRef))
                            {
                                return false;
                            }
                        }
                        else
                            CanPetMove = false;
                        break;
                    }
            }
            return CanPetMove;
        }

        public static void PetDir(int index, int dir)
        {
            ByteStream buffer = new ByteStream(4);

            if (index <= 0 || index > Constants.MAX_PLAYERS || dir < (int)Enums.DirectionType.Up || dir > (int)Enums.DirectionType.Right)
                return;

            if (modTypes.TempPlayer[index].PetskillBuffer.Skill > 0)
                return;

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Dir = dir;

            buffer.WriteInt32((int)Packets.ServerPackets.SPetDir);
            buffer.WriteInt32(index);
            buffer.WriteInt32(dir);
            S_NetworkConfig.SendDataToMap(S_Players.GetPlayerMap(index), ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static bool PetTryWalk(int index, int targetX, int targetY)
        {
            int i = 0;
            int x = 0;
            bool didwalk = false;
            int mapNum = 0;

            mapNum = S_Players.GetPlayerMap(index);
            x = index;

            if (S_Events.IsOneBlockAway(targetX, targetY, GetPetX(index), GetPetY(index)) == false)
            {
                if (S_Events.PathfindingType == 1)
                {
                    i = (int)Conversion.Int(VBMath.Rnd() * 5);

                    // Lets move the pet
                    switch (i)
                    {
                        case 0:
                            {
                                // Up
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.Y > targetY && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Up))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Up, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                // Down
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.Y < targetY && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Down))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Down, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                // Left
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.X > targetX && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Left))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Left, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                // Right
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.X < targetX && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Right))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Right, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                break;
                            }

                        case 1:
                            {

                                // Right
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.X < targetX && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Right))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Right, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                // Left
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.X > targetX && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Left))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Left, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                // Down
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.Y < targetY && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Down))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Down, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                // Up
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.Y > targetY && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Up))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Up, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                break;
                            }

                        case 2:
                            {

                                // Down
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.Y < targetY && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Down))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Down, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                // Up
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.Y > targetY && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Up))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Up, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                // Right
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.X < targetX && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Right))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Right, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                // Left
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.X > targetX && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Left))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Left, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                break;
                            }

                        case 3:
                            {

                                // Left
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.X > targetX && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Left))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Left, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                // Right
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.X < targetX && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Right))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Right, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                // Up
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.Y > targetY && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Up))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Up, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                // Down
                                if (modTypes.Player[x].Character[modTypes.TempPlayer[x].CurChar].Pet.Y < targetY && !didwalk)
                                {
                                    if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Down))
                                    {
                                        PetMove(x, mapNum, (int)Enums.DirectionType.Down, (int)Enums.MovementType.Walking);
                                        didwalk = true;
                                    }
                                }

                                break;
                            }
                    }

                    // Check if we can't move and if Target is behind something and if we can just switch dirs
                    if (!didwalk)
                    {
                        if (GetPetX(x) - 1 == targetX && GetPetY(x) == targetY)
                        {
                            if (GetPetDir(x) != (int)Enums.DirectionType.Left)
                                PetDir(x, (int)Enums.DirectionType.Left);

                            didwalk = true;
                        }

                        if (GetPetX(x) + 1 == targetX && GetPetY(x) == targetY)
                        {
                            if (GetPetDir(x) != (int)Enums.DirectionType.Right)
                                PetDir(x, (int)Enums.DirectionType.Right);

                            didwalk = true;
                        }

                        if (GetPetX(x) == targetX && GetPetY(x) - 1 == targetY)
                        {
                            if (GetPetDir(x) != (int)Enums.DirectionType.Up)
                                PetDir(x, (int)Enums.DirectionType.Up);

                            didwalk = true;
                        }

                        if (GetPetX(x) == targetX && GetPetY(x) + 1 == targetY)
                        {
                            if (GetPetDir(x) != (int)Enums.DirectionType.Down)
                                PetDir(x, (int)Enums.DirectionType.Down);

                            didwalk = true;
                        }
                    }
                }
            }
            else

                // Look to target
                if (GetPetX(index) > modTypes.TempPlayer[index].GoToX)
            {
                if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Left))
                {
                    PetMove(x, mapNum, (int)Enums.DirectionType.Left, (int)Enums.MovementType.Walking);
                    didwalk = true;
                }
                else
                {
                    PetDir(x, (int)Enums.DirectionType.Left);
                    didwalk = true;
                }
            }
            else if (GetPetX(index) < modTypes.TempPlayer[index].GoToX)
            {
                if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Right))
                {
                    PetMove(x, mapNum, (int)Enums.DirectionType.Right, (int)Enums.MovementType.Walking);
                    didwalk = true;
                }
                else
                {
                    PetDir(x, (int)Enums.DirectionType.Right);
                    didwalk = true;
                }
            }
            else if (GetPetY(index) > modTypes.TempPlayer[index].GoToY)
            {
                if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Up))
                {
                    PetMove(x, mapNum, (int)Enums.DirectionType.Up, (int)Enums.MovementType.Walking);
                    didwalk = true;
                }
                else
                {
                    PetDir(x, (int)Enums.DirectionType.Up);
                    didwalk = true;
                }
            }
            else if (GetPetY(index) < modTypes.TempPlayer[index].GoToY)
            {
                if (CanPetMove(x, mapNum, (int)Enums.DirectionType.Down))
                {
                    PetMove(x, mapNum, (int)Enums.DirectionType.Down, (int)Enums.MovementType.Walking);
                    didwalk = true;
                }
                else
                {
                    PetDir(x, (int)Enums.DirectionType.Down);
                    didwalk = true;
                }
            }

            // We could not move so Target must be behind something, walk randomly.
            if (!didwalk)
            {
                i = (int)Conversion.Int(VBMath.Rnd() * 2);

                if (i == 1)
                {
                    i = (int)Conversion.Int(VBMath.Rnd() * 4);

                    if (CanPetMove(x, mapNum, (byte)i))
                        PetMove(x, mapNum, i, (int)Enums.MovementType.Walking);
                }
            }

            return didwalk;
        }

        public static int FindPetPath(int mapNum, int index, int targetX, int targetY)
        {
            int tim = 0;
            int sX = 0;
            int sY = 0;
            int[,] pos;
            bool reachable;
            int j = 0;
            int lastSum = 0;
            int sum = 0;
            int fx = 0;
            int fy = 0;
            int i = 0;
            Point[] path;
            int lastX = 0;
            int lastY = 0;
            bool did;

            // Initialization phase

            tim = 0;
            sX = GetPetX(index);
            sY = GetPetY(index);

            fx = targetX;
            fy = targetY;

            if (fx == -1)
                return 0;
            if (fy == -1)
                return 0;

            pos = new int[modTypes.Map[mapNum].MaxX + 1, modTypes.Map[mapNum].MaxY + 1];
            // pos = MapBlocks(MapNum).Blocks

            pos[sX, sY] = 100 + tim;
            pos[fx, fy] = 2;

            // reset reachable
            reachable = false;

            // Do while reachable is false... if its set true in progress, we jump out
            // If the path is decided unreachable in process, we will use exit sub. Not proper,
            // but faster ;-)
            while (reachable == false)
            {
                var loopTo = modTypes.Map[mapNum].MaxY;

                // we loop through all squares
                for (j = 0; j <= loopTo; j++)
                {
                    var loopTo1 = modTypes.Map[mapNum].MaxX;
                    for (i = 0; i <= loopTo1; i++)
                    {

                        // If j = 10 AndAlso i = 0 Then MsgBox "hi!"
                        // If they are to be extended, the pointer TIM is on them
                        if (pos[i, j] == 100 + tim)
                        {

                            // The part is to be extended, so do it
                            // We have to make sure that there is a pos(i+1,j) BEFORE we actually use it,
                            // because then we get error... If the square is on side, we dont test for this one!
                            if (i < modTypes.Map[mapNum].MaxX)
                            {

                                // If there isnt a wall, or any other... thing
                                if (pos[i + 1, j] == 0)
                                    // Expand it, and make its pos equal to tim+1, so the next time we make this loop,
                                    // It will exapand that square too! This is crucial part of the program
                                    pos[i + 1, j] = 100 + tim + 1;
                                else if (pos[i + 1, j] == 2)
                                    // If the position is no 0 but its 2 (FINISH) then Reachable = true!!! We found end
                                    reachable = true;
                            }

                            // This is the same as the last one, as i said a lot of copy paste work and editing that
                            // This is simply another side that we have to test for... so instead of i+1 we have i-1
                            // Its actually pretty same then... I wont comment it therefore, because its only repeating
                            // same thing with minor changes to check sides
                            if (i > 0)
                            {
                                if (pos[(i - 1), j] == 0)
                                    pos[i - 1, j] = 100 + tim + 1;
                                else if (pos[i - 1, j] == 2)
                                    reachable = true;
                            }

                            if (j < modTypes.Map[mapNum].MaxY)
                            {
                                if (pos[i, j + 1] == 0)
                                    pos[i, j + 1] = 100 + tim + 1;
                                else if (pos[i, j + 1] == 2)
                                    reachable = true;
                            }

                            if (j > 0)
                            {
                                if (pos[i, j - 1] == 0)
                                    pos[i, j - 1] = 100 + tim + 1;
                                else if (pos[i, j - 1] == 2)
                                    reachable = true;
                            }
                        }

                        //Application.DoEvents();
                    }
                }

                // If the reachable is STILL false, then
                if (reachable == false)
                {
                    // reset sum
                    sum = 0;
                    var loopTo2 = modTypes.Map[mapNum].MaxY;
                    for (j = 0; j <= loopTo2; j++)
                    {
                        var loopTo3 = modTypes.Map[mapNum].MaxX;
                        for (i = 0; i <= loopTo3; i++)
                            // we add up ALL the squares
                            sum = sum + pos[i, j];
                    }

                    // Now if the sum is euqal to the last sum, its not reachable, if it isnt, then we store
                    // sum to lastsum
                    if (sum == lastSum)
                    {
                        return 4;
                    }
                    else
                        lastSum = sum;
                }

                // we increase the pointer to point to the next squares to be expanded
                tim = tim + 1;
            }

            // We work backwards to find the way...
            lastX = fx;
            lastY = fy;

            path = new Point[tim + 1 + 1];

            // The following code may be a little bit confusing but ill try my best to explain it.
            // We are working backwards to find ONE of the shortest ways back to Start.
            // So we repeat the loop until the LastX and LastY arent in start. Look in the code to see
            // how LastX and LasY change
            while (lastX != sX || lastY != sY)
            {
                // We decrease tim by one, and then we are finding any adjacent square to the final one, that
                // has that value. So lets say the tim would be 5, because it takes 5 steps to get to the target.
                // Now everytime we decrease that, so we make it 4, and we look for any adjacent square that has
                // that value. When we find it, we just color it yellow as for the solution
                tim = tim - 1;
                // reset did to false
                did = false;

                // If we arent on edge
                if (lastX < modTypes.Map[mapNum].MaxX)
                {

                    // check the square on the right of the solution. Is it a tim-1 one? or just a blank one
                    if (pos[lastX + 1, lastY] == 100 + tim)
                    {
                        // if it, then make it yellow, and change did to true
                        lastX = lastX + 1;
                        did = true;
                    }
                }

                // This will then only work if the previous part didnt execute, and did is still false. THen
                // we want to check another square, the on left. Is it a tim-1 one ?
                if (did == false)
                {
                    if (lastX > 0)
                    {
                        if (pos[lastX - 1, lastY] == 100 + tim)
                        {
                            lastX = lastX - 1;
                            did = true;
                        }
                    }
                }

                // We check the one below it
                if (did == false)
                {
                    if (lastY < modTypes.Map[mapNum].MaxY)
                    {
                        if (pos[lastX, lastY + 1] == 100 + tim)
                        {
                            lastY = lastY + 1;
                            did = true;
                        }
                    }
                }

                // And above it. One of these have to be it, since we have found the solution, we know that already
                // there is a way back.
                if (did == false)
                {
                    if (lastY > 0)
                    {
                        if (pos[lastX, lastY - 1] == 100 + tim)
                            lastY = lastY - 1;
                    }
                }

                path[tim].X = lastX;
                path[tim].Y = lastY;

                // Now we loop back and decrease tim, and look for the next square with lower value
                //Application.DoEvents();
            }

            // Ok we got a path. Now, lets look at the first step and see what direction we should take.
            if (path[1].X > lastX)
                return (int)Enums.DirectionType.Right;
            else if (path[1].Y > lastY)
                return (int)Enums.DirectionType.Down;
            else if (path[1].Y < lastY)
                return (int)Enums.DirectionType.Up;
            else if (path[1].X < lastX)
                return (int)Enums.DirectionType.Left;
            return 0;
        }

        public static int GetPetDamage(int index)
        {

            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(index) == false || index <= 0 || index > Constants.MAX_PLAYERS || !PetAlive(index))
                return 0;

            return (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Stat[(int)Enums.StatType.Strength] * 2) + (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Level * 3) + S_GameLogic.Random(0, 20);
        }

        internal static bool CanPetCrit(int index)
        {
            int rate;
            int rndNum;

            if (!PetAlive(index))
                return false;

            bool CanPetCrit = false;

            rate = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Stat[(int)Enums.StatType.Luck] / (int)3;
            rndNum = S_GameLogic.Random(1, 100);

            if (rndNum <= rate)
                CanPetCrit = true;
            return CanPetCrit;
        }

        public static bool IsPetByPlayer(int index)
        {
            int x;
            int y;
            int x1;
            int y1;

            if (index <= 0 || index > Constants.MAX_PLAYERS || !PetAlive(index))
                return false;

            bool IsPetByPlayer = false;

            x = S_Players.GetPlayerX(index);
            y = S_Players.GetPlayerY(index);
            x1 = GetPetX(index);
            y1 = GetPetY(index);

            if (x == x1)
            {
                if (y == y1 + 1 || y == y1 - 1)
                    IsPetByPlayer = true;
            }
            else if (y == y1)
            {
                if (x == x1 - 1 || x == x1 + 1)
                    IsPetByPlayer = true;
            }
            return IsPetByPlayer;
        }

        public static int GetPetVitalRegen(int index, Enums.VitalType vital)
        {
            int i = 0;

            if (index <= 0 || index > Constants.MAX_PLAYERS || !PetAlive(index))
            {
                return 0;
            }

            switch (vital)
            {
                case Enums.VitalType.HP:
                    {
                        i = ((int)(S_Players.GetPlayerStat(index, Enums.StatType.Spirit) * 0.8)) + 6;
                        break;
                    }

                case Enums.VitalType.MP:
                    {
                        i = (int)((S_Players.GetPlayerStat(index, Enums.StatType.Spirit) / (int)4) + 12.5);
                        break;
                    }
            }

            return i;
        }

        public static void CheckPetLevelUp(int index)
        {
            int expRollover;
            int levelCount;

            levelCount = 0;

            while (GetPetExp(index) >= GetPetNextLevel(index))
            {
                expRollover = GetPetExp(index) - GetPetNextLevel(index);

                // can level up?
                if (GetPetLevel(index) < 99 && GetPetLevel(index) < Pet[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Num].MaxLevel)
                    SetPetLevel(index, GetPetLevel(index) + 1);

                SetPetPoints(index, GetPetPoints(index) + Pet[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Num].LevelPnts);
                SetPetExp(index, expRollover);
                levelCount = levelCount + 1;
            }

            if (levelCount > 0)
            {
                if (levelCount == 1)
                    // singular
                    S_NetworkSend.PlayerMsg(index, "Your " + GetPetName(index).Trim() + " has gained " + levelCount + " level!", (int)Enums.ColorType.BrightGreen);
                else
                    // plural
                    S_NetworkSend.PlayerMsg(index, "Your " + GetPetName(index).Trim() + " has gained " + levelCount + " levels!", (int)Enums.ColorType.BrightGreen);

                S_NetworkSend.SendPlayerData(index);
            }
        }

        internal static void PetFireProjectile(int index, int spellnum)
        {
            int projectileSlot = 0;
            int projectileNum = 0;
            int mapNum = 0;
            int i = 0;

            // Prevent subscript out of range

            mapNum = S_Players.GetPlayerMap(index);

            // Find a free projectile
            for (i = 1; i <= S_Projectiles.MAX_PROJECTILES; i++)
            {
                if (S_Projectiles.MapProjectiles[mapNum, i].ProjectileNum == 0)
                {
                    projectileSlot = i;
                    break;
                }
            }

            // Check for no projectile, if so just overwrite the first slot
            if (projectileSlot == 0)
                projectileSlot = 1;

            if (spellnum < 1 || spellnum > Constants.MAX_SKILLS)
                return;

            projectileNum = Types.Skill[spellnum].Projectile;

            {
                S_Projectiles.MapProjectiles[mapNum, projectileSlot].ProjectileNum = projectileNum;
                S_Projectiles.MapProjectiles[mapNum, projectileSlot].Owner = index;
                S_Projectiles.MapProjectiles[mapNum, projectileSlot].OwnerType = (int)Enums.TargetType.Pet;
                S_Projectiles.MapProjectiles[mapNum, projectileSlot].Dir = (byte)modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Pet.Dir;
                S_Projectiles.MapProjectiles[mapNum, projectileSlot].X = modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Pet.X;
                S_Projectiles.MapProjectiles[mapNum, projectileSlot].Y = modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Pet.Y;
                S_Projectiles.MapProjectiles[mapNum, projectileSlot].Timer = S_General.GetTimeMs() + 60000;
            }

            S_Projectiles.SendProjectileToMap(mapNum, projectileSlot);
        }



        internal static void TryPetAttackNpc(int index, int mapNpcNum)
        {
            int blockAmount;
            int npcnum;
            int mapNum;
            int damage;

            damage = 0;

            // Can we attack the npc?
            if (CanPetAttackNpc(index, mapNpcNum))
            {
                mapNum = S_Players.GetPlayerMap(index);
                npcnum = modTypes.MapNpc[mapNum].Npc[mapNpcNum].Num;

                // check if NPC can avoid the attack
                if (S_Npc.CanNpcDodge(npcnum))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Dodge!", (int)Enums.ColorType.Pink, 1, (modTypes.MapNpc[mapNum].Npc[mapNpcNum].X * 32), (modTypes.MapNpc[mapNum].Npc[mapNpcNum].Y * 32));
                    return;
                }

                if (S_Npc.CanNpcParry(npcnum))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Parry!", (int)Enums.ColorType.Pink, 1, (modTypes.MapNpc[mapNum].Npc[mapNpcNum].X * 32), (modTypes.MapNpc[mapNum].Npc[mapNpcNum].Y * 32));
                    return;
                }

                // Get the damage we can do
                damage = GetPetDamage(index);

                // if the npc blocks, take away the block amount
                blockAmount = unchecked(((S_Npc.CanNpcBlock(mapNpcNum) != false) ? true : false)) ? 1 : 0;
                damage = damage - blockAmount;

                // take away armour
                damage = damage - S_GameLogic.Random(1, (Types.Npc[npcnum].Stat[(int)Enums.StatType.Luck] * 2));
                // randomise from 1 to max hit
                damage = S_GameLogic.Random(1, damage);

                // * 1.5 if it's a crit!
                if (CanPetCrit(index))
                {
                    damage = (int)(damage * 1.5);
                    S_NetworkSend.SendActionMsg(mapNum, "Critical!", (int)Enums.ColorType.BrightCyan, 1, (S_Players.GetPlayerX(index) * 32), (S_Players.GetPlayerY(index) * 32));
                }

                if (damage > 0)
                    PetAttackNpc(index, mapNpcNum, damage);
                else
                    S_NetworkSend.PlayerMsg(index, "Your pet's attack does nothing.", (int)Enums.ColorType.BrightRed);
            }
        }

        internal static bool CanPetAttackNpc(int attacker, int mapnpcnum, bool isSpell = false)
        {
            int mapNum = 0;
            int npcnum = 0;
            int npcX = 0;
            int npcY = 0;
            int attackspeed = 0;

            if (S_NetworkConfig.IsPlaying(attacker) == false || mapnpcnum <= 0 || mapnpcnum > Constants.MAX_MAP_NPCS || !PetAlive(attacker))
                return false;

            // Check for subscript out of range
            if (modTypes.MapNpc[S_Players.GetPlayerMap(attacker)].Npc[mapnpcnum].Num <= 0)
                return false;

            mapNum = S_Players.GetPlayerMap(attacker);
            npcnum = modTypes.MapNpc[mapNum].Npc[mapnpcnum].Num;

            // Make sure the npc isn't already dead
            if (modTypes.MapNpc[mapNum].Npc[mapnpcnum].Vital[(int)Enums.VitalType.HP] <= 0)
                return false;

            // Make sure they are on the same map
            if (S_NetworkConfig.IsPlaying(attacker))
            {
                if (modTypes.TempPlayer[attacker].PetskillBuffer.Skill > 0 && isSpell == false)
                    return false;

                // exit out early
                if (isSpell && npcnum > 0)
                {
                    if (Types.Npc[npcnum].Behaviour != (int)Enums.NpcBehavior.Friendly && Types.Npc[npcnum].Behaviour != (int)Enums.NpcBehavior.ShopKeeper)
                    {
                        return true;
                    }
                }

                attackspeed = 1000; // Pet cannot wield a weapon

                if (npcnum > 0 && S_General.GetTimeMs() > modTypes.TempPlayer[attacker].PetAttackTimer + attackspeed)
                {

                    // Check if at same coordinates
                    switch (GetPetDir(attacker))
                    {
                        case (int)Enums.DirectionType.Up:
                            {
                                npcX = modTypes.MapNpc[mapNum].Npc[mapnpcnum].X;
                                npcY = modTypes.MapNpc[mapNum].Npc[mapnpcnum].Y + 1;
                                break;
                            }

                        case (int)Enums.DirectionType.Down:
                            {
                                npcX = modTypes.MapNpc[mapNum].Npc[mapnpcnum].X;
                                npcY = modTypes.MapNpc[mapNum].Npc[mapnpcnum].Y - 1;
                                break;
                            }

                        case (int)Enums.DirectionType.Left:
                            {
                                npcX = modTypes.MapNpc[mapNum].Npc[mapnpcnum].X + 1;
                                npcY = modTypes.MapNpc[mapNum].Npc[mapnpcnum].Y;
                                break;
                            }

                        case (int)Enums.DirectionType.Right:
                            {
                                npcX = modTypes.MapNpc[mapNum].Npc[mapnpcnum].X - 1;
                                npcY = modTypes.MapNpc[mapNum].Npc[mapnpcnum].Y;
                                break;
                            }
                    }

                    if (npcX == GetPetX(attacker) && npcY == GetPetY(attacker))
                    {
                        if (Types.Npc[npcnum].Behaviour != (int)Enums.NpcBehavior.Friendly && Types.Npc[npcnum].Behaviour != (int)Enums.NpcBehavior.ShopKeeper)
                            return true;
                        else
                            return false;
                    }
                }
            }
            return false;
        }

        internal static void PetAttackNpc(int attacker, int mapnpcnum, int damage, int skillnum = 0, bool overTime = false)
        {
            string name;
            int exp;
            int n;
            int i;
            int mapNum;
            int npcnum;

            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(attacker) == false || mapnpcnum <= 0 || mapnpcnum > Constants.MAX_MAP_NPCS || damage < 0 || !PetAlive(attacker))
                return;

            mapNum = S_Players.GetPlayerMap(attacker);
            npcnum = modTypes.MapNpc[mapNum].Npc[mapnpcnum].Num;
            name = Microsoft.VisualBasic.Strings.Trim(Types.Npc[npcnum].Name);

            if (skillnum == 0)
                // Send this packet so they can see the pet attacking
                SendPetAttack(attacker, mapNum);

            // Check for weapon
            n = 0; // no weapon, pet :P

            // set the regen timer
            modTypes.TempPlayer[attacker].PetstopRegen = true;
            modTypes.TempPlayer[attacker].PetstopRegenTimer = S_General.GetTimeMs();

            if (damage >= modTypes.MapNpc[mapNum].Npc[mapnpcnum].Vital[(int)Enums.VitalType.HP])
            {
                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(attacker), "-" + modTypes.MapNpc[mapNum].Npc[mapnpcnum].Vital[(int)Enums.VitalType.HP], (int)Enums.ColorType.BrightRed, 1, (modTypes.MapNpc[mapNum].Npc[mapnpcnum].X * 32), (modTypes.MapNpc[mapNum].Npc[mapnpcnum].Y * 32));
                S_NetworkSend.SendBlood(S_Players.GetPlayerMap(attacker), modTypes.MapNpc[mapNum].Npc[mapnpcnum].X, modTypes.MapNpc[mapNum].Npc[mapnpcnum].Y);

                // Calculate exp to give attacker
                exp = Types.Npc[npcnum].Exp;

                // Make sure we dont get less then 0
                if (exp < 0)
                    exp = 1;

                // in party?
                if (modTypes.TempPlayer[attacker].InParty > 0)
                    // pass through party sharing function
                    S_Parties.Party_ShareExp(modTypes.TempPlayer[attacker].InParty, exp, attacker, mapNum);
                else
                    // no party - keep exp for self
                    S_Events.GivePlayerExp(attacker, exp);

                // For n = 1 To 20
                // If MapNpc(MapNum).Npc(mapnpcnum).Num > 0 Then
                // 'SpawnItem(MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Num, MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Value, MapNum, MapNpc(MapNum).Npc(mapnpcnum).x, MapNpc(MapNum).Npc(mapnpcnum).y)
                // 'MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Value = 0
                // 'MapNpc(MapNum).Npc(mapnpcnum).Inventory(n).Num = 0
                // End If
                // Next

                // Now set HP to 0 so we know to actually kill them in the server loop (this prevents subscript out of range)
                modTypes.MapNpc[mapNum].Npc[mapnpcnum].Num = 0;
                modTypes.MapNpc[mapNum].Npc[mapnpcnum].SpawnWait = S_General.GetTimeMs();
                modTypes.MapNpc[mapNum].Npc[mapnpcnum].Vital[(int)Enums.VitalType.HP] = 0;
                modTypes.MapNpc[mapNum].Npc[mapnpcnum].TargetType = 0;
                modTypes.MapNpc[mapNum].Npc[mapnpcnum].Target = 0;

                // clear DoTs and HoTs
                // For i = 1 To MAX_DOTS
                // With MapNpc(MapNum).Npc(mapnpcnum).DoT(i)
                // .Spell = 0
                // .Timer = 0
                // .Caster = 0
                // .StartTime = 0
                // .Used = False
                // End With
                // With MapNpc(MapNum).Npc(mapnpcnum).HoT(i)
                // .Spell = 0
                // .Timer = 0
                // .Caster = 0
                // .StartTime = 0
                // .Used = False
                // End With
                // Next

                // send death to the map
                S_Npc.SendNpcDead(mapNum, mapnpcnum);
                var loopTo = S_NetworkConfig.Socket.HighIndex;

                // Loop through entire map and purge NPC from targets
                for (i = 1; i <= loopTo; i++)
                {
                    if (S_NetworkConfig.IsPlaying(i))
                    {
                        if (S_Players.GetPlayerMap(i) == mapNum)
                        {
                            if (modTypes.TempPlayer[i].TargetType == (int)Enums.TargetType.Npc)
                            {
                                if (modTypes.TempPlayer[i].Target == mapnpcnum)
                                {
                                    modTypes.TempPlayer[i].Target = 0;
                                    modTypes.TempPlayer[i].TargetType = (int)Enums.TargetType.None;
                                    S_NetworkSend.SendTarget(i, 0, (byte)Enums.TargetType.None);
                                }
                            }

                            if (modTypes.TempPlayer[i].PetTargetType == (int)Enums.TargetType.Npc)
                            {
                                if (modTypes.TempPlayer[i].PetTarget == mapnpcnum)
                                {
                                    modTypes.TempPlayer[i].PetTarget = 0;
                                    modTypes.TempPlayer[i].PetTargetType = (int)Enums.TargetType.None;
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                // NPC not dead, just do the damage
                modTypes.MapNpc[mapNum].Npc[mapnpcnum].Vital[(int)Enums.VitalType.HP] = modTypes.MapNpc[mapNum].Npc[mapnpcnum].Vital[(int)Enums.VitalType.HP] - damage;

                // Check for a weapon and say damage
                S_NetworkSend.SendActionMsg(mapNum, "-" + damage, (int)Enums.ColorType.BrightRed, 1, (modTypes.MapNpc[mapNum].Npc[mapnpcnum].X * 32), (modTypes.MapNpc[mapNum].Npc[mapnpcnum].Y * 32));
                S_NetworkSend.SendBlood(S_Players.GetPlayerMap(attacker), modTypes.MapNpc[mapNum].Npc[mapnpcnum].X, modTypes.MapNpc[mapNum].Npc[mapnpcnum].Y);

                // send the sound
                // If Spellnum > 0 Then SendMapSound Attacker, MapNpc(MapNum).Npc(mapnpcnum).x, MapNpc(MapNum).Npc(mapnpcnum).y, SoundEntity.seSpell, Spellnum

                // Set the NPC target to the player
                modTypes.MapNpc[mapNum].Npc[mapnpcnum].TargetType = (int)Enums.TargetType.Pet; // player's pet
                modTypes.MapNpc[mapNum].Npc[mapnpcnum].Target = attacker;

                // Now check for guard ai and if so have all onmap guards come after'm
                if (Types.Npc[modTypes.MapNpc[mapNum].Npc[mapnpcnum].Num].Behaviour == (byte)Enums.NpcBehavior.Guard)
                {
                    for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                    {
                        if (modTypes.MapNpc[mapNum].Npc[i].Num == modTypes.MapNpc[mapNum].Npc[mapnpcnum].Num)
                        {
                            modTypes.MapNpc[mapNum].Npc[i].Target = attacker;
                            modTypes.MapNpc[mapNum].Npc[i].TargetType = (int)Enums.TargetType.Pet; // pet
                        }
                    }
                }

                // set the regen timer
                modTypes.MapNpc[mapNum].Npc[mapnpcnum].StopRegen = 1;
                modTypes.MapNpc[mapNum].Npc[mapnpcnum].StopRegenTimer = S_General.GetTimeMs();

                // if stunning spell, stun the npc
                if (skillnum > 0)
                {
                    if (Types.Skill[skillnum].StunDuration > 0)
                        S_Players.StunNPC(mapnpcnum, mapNum, skillnum);
                    // DoT
                    if (Types.Skill[skillnum].Duration > 0)
                    {
                    }
                }

                S_Npc.SendMapNpcVitals(mapNum, (byte)mapnpcnum);
            }

            if (skillnum == 0)
                // Reset attack timer
                modTypes.TempPlayer[attacker].PetAttackTimer = S_General.GetTimeMs();
        }



        internal static void TryNpcAttackPet(int mapNpcNum, int index)
        {
            int mapNum;
            int npcnum;
            int damage = 0;

            // Can the npc attack the pet?

            if (CanNpcAttackPet(mapNpcNum, index))
            {
                mapNum = S_Players.GetPlayerMap(index);
                npcnum = modTypes.MapNpc[mapNum].Npc[mapNpcNum].Num;

                // check if Pet can avoid the attack
                if (CanPetDodge(index))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Dodge!", (int)Enums.ColorType.Pink, (byte)Enums.ActionMsgType.Scroll, (GetPetX(index) * 32), (GetPetY(index) * 32));
                    return;
                }

                // Get the damage we can do
                damage = S_Npc.GetNpcDamage(npcnum);

                // take away armour
                damage = damage - ((GetPetStat(index, Enums.StatType.Endurance) * 2) + (GetPetLevel(index) * 2));

                // * 1.5 if crit hit
                if (S_Npc.CanNpcCrit(npcnum))
                {
                    damage = (int)(damage * 1.5);
                    S_NetworkSend.SendActionMsg(mapNum, "Critical!", (int)Enums.ColorType.BrightCyan, (byte)Enums.ActionMsgType.Scroll, (modTypes.MapNpc[mapNum].Npc[mapNpcNum].X * 32), (modTypes.MapNpc[mapNum].Npc[mapNpcNum].Y * 32));
                }
            }

            if (damage > 0)
                NpcAttackPet(mapNpcNum, index, damage);
        }

        public static bool CanNpcAttackPet(int mapNpcNum, int index)
        {
            int mapNum;
            int npcnum;

            bool CanNpcAttackPet = false;

            if (mapNpcNum <= 0 || mapNpcNum > Constants.MAX_MAP_NPCS || !S_NetworkConfig.IsPlaying(index) || !PetAlive(index))
                return false;

            // Check for subscript out of range
            if (modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[mapNpcNum].Num <= 0)
                return false;

            mapNum = S_Players.GetPlayerMap(index);
            npcnum = modTypes.MapNpc[mapNum].Npc[mapNpcNum].Num;

            // Make sure the npc isn't already dead
            if (modTypes.MapNpc[mapNum].Npc[mapNpcNum].Vital[(int)Enums.VitalType.HP] <= 0)
                return false;

            // Make sure npcs dont attack more then once a second
            if (S_General.GetTimeMs() < modTypes.MapNpc[mapNum].Npc[mapNpcNum].AttackTimer + 1000)
                return false;

            // Make sure we dont attack the player if they are switching maps
            if (modTypes.TempPlayer[index].GettingMap == 1)
                return false;

            modTypes.MapNpc[mapNum].Npc[mapNpcNum].AttackTimer = S_General.GetTimeMs();

            // Make sure they are on the same map
            if (S_NetworkConfig.IsPlaying(index) && PetAlive(index))
            {
                if (npcnum > 0)
                {

                    // Check if at same coordinates
                    if ((GetPetY(index) + 1 == modTypes.MapNpc[mapNum].Npc[mapNpcNum].Y) && (GetPetX(index) == modTypes.MapNpc[mapNum].Npc[mapNpcNum].X))
                        CanNpcAttackPet = true;
                    else if ((GetPetY(index) - 1 == modTypes.MapNpc[mapNum].Npc[mapNpcNum].Y) && (GetPetX(index) == modTypes.MapNpc[mapNum].Npc[mapNpcNum].X))
                        CanNpcAttackPet = true;
                    else if ((GetPetY(index) == modTypes.MapNpc[mapNum].Npc[mapNpcNum].Y) && (GetPetX(index) + 1 == modTypes.MapNpc[mapNum].Npc[mapNpcNum].X))
                        CanNpcAttackPet = true;
                    else if ((GetPetY(index) == modTypes.MapNpc[mapNum].Npc[mapNpcNum].Y) && (GetPetX(index) - 1 == modTypes.MapNpc[mapNum].Npc[mapNpcNum].X))
                        CanNpcAttackPet = true;
                }
            }
            return CanNpcAttackPet;
        }

        public static void NpcAttackPet(int mapnpcnum, int victim, int damage)
        {
            string name;
            int mapNum;

            // Check for subscript out of range
            if (mapnpcnum <= 0 || mapnpcnum > Constants.MAX_MAP_NPCS || S_NetworkConfig.IsPlaying(victim) == false || !PetAlive(victim))
                return;

            // Check for subscript out of range
            if (modTypes.MapNpc[S_Players.GetPlayerMap(victim)].Npc[mapnpcnum].Num <= 0)
                return;

            mapNum = S_Players.GetPlayerMap(victim);
            name = Microsoft.VisualBasic.Strings.Trim(Types.Npc[modTypes.MapNpc[mapNum].Npc[mapnpcnum].Num].Name);

            // Send this packet so they can see the npc attacking
            S_Npc.SendNpcAttack(victim, mapnpcnum);

            if (damage <= 0)
                return;

            // set the regen timer
            modTypes.MapNpc[mapNum].Npc[mapnpcnum].StopRegen = 1;
            modTypes.MapNpc[mapNum].Npc[mapnpcnum].StopRegenTimer = S_General.GetTimeMs();

            if (damage >= GetPetVital(victim, Enums.VitalType.HP))
            {
                // Say damage
                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(victim), "-" + GetPetVital(victim, Enums.VitalType.HP), (int)Enums.ColorType.BrightRed, (byte)Enums.ActionMsgType.Scroll, (GetPetX(victim) * 32), (GetPetY(victim) * 32));

                // kill pet
                S_NetworkSend.PlayerMsg(victim, "Your " + Microsoft.VisualBasic.Strings.Trim(GetPetName(victim)) + " was killed by a " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[modTypes.MapNpc[mapNum].Npc[mapnpcnum].Num].Name) + ".", (int)Enums.ColorType.BrightRed);
                ReCallPet(victim);

                // Now that pet is dead, go for owner
                modTypes.MapNpc[mapNum].Npc[mapnpcnum].Target = victim;
                modTypes.MapNpc[mapNum].Npc[mapnpcnum].TargetType = (int)Enums.TargetType.Player;
            }
            else
            {
                // Pet not dead, just do the damage
                SetPetVital(victim, Enums.VitalType.HP, GetPetVital(victim, Enums.VitalType.HP) - damage);
                SendPetVital(victim, Enums.VitalType.HP);
                S_Animations.SendAnimation(mapNum, Types.Npc[modTypes.MapNpc[S_Players.GetPlayerMap(victim)].Npc[mapnpcnum].Num].Animation, 0, 0, (byte)Enums.TargetType.Pet, victim);

                // Say damage
                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(victim), "-" + damage, (int)Enums.ColorType.BrightRed, (byte)Enums.ActionMsgType.Scroll, (GetPetX(victim) * 32), (GetPetY(victim) * 32));
                S_NetworkSend.SendBlood(S_Players.GetPlayerMap(victim), GetPetX(victim), GetPetY(victim));

                // set the regen timer
                modTypes.TempPlayer[victim].PetstopRegen = true;
                modTypes.TempPlayer[victim].PetstopRegenTimer = S_General.GetTimeMs();

                // pet gets attacked, lets set this target
                modTypes.TempPlayer[victim].PetTarget = mapnpcnum;
                modTypes.TempPlayer[victim].PetTargetType = (int)Enums.TargetType.Npc;
            }
        }



        public static bool CanPetAttackPlayer(int attacker, int victim, bool isSkill = false)
        {
            if (!isSkill)
            {
                if (S_General.GetTimeMs() < modTypes.TempPlayer[attacker].PetAttackTimer + 1000)
                    return false;
            }

            // Check for subscript out of range
            if (!S_NetworkConfig.IsPlaying(victim))
                return false;

            // Make sure they are on the same map
            if (!(S_Players.GetPlayerMap(attacker) == S_Players.GetPlayerMap(victim)))
                return false;

            // Make sure we dont attack the player if they are switching maps
            if (modTypes.TempPlayer[victim].GettingMap == 1)
                return false;

            if (modTypes.TempPlayer[attacker].PetskillBuffer.Skill > 0 && isSkill == false)
                return false;

            if (!isSkill)
            {
                // Check if at same coordinates
                switch (GetPetDir(attacker))
                {
                    case (int)Enums.DirectionType.Up:
                        {
                            if (!(S_Players.GetPlayerY(victim) + 1 == GetPetY(attacker)) && (S_Players.GetPlayerX(victim) == GetPetX(attacker)))
                                return false;
                            break;
                        }

                    case (int)Enums.DirectionType.Down:
                        {
                            if (!(S_Players.GetPlayerY(victim) - 1 == GetPetY(attacker)) && (S_Players.GetPlayerX(victim) == GetPetX(attacker)))
                                return false;
                            break;
                        }

                    case (int)Enums.DirectionType.Left:
                        {
                            if (!(S_Players.GetPlayerY(victim) == GetPetY(attacker)) && (S_Players.GetPlayerX(victim) + 1 == GetPetX(attacker)))
                                return false;
                            break;
                        }

                    case (int)Enums.DirectionType.Right:
                        {
                            if (!(S_Players.GetPlayerY(victim) == GetPetY(attacker)) && (S_Players.GetPlayerX(victim) - 1 == GetPetX(attacker)))
                                return false;
                            break;
                        }

                    default:
                        {
                            return false;
                        }
                }
            }

            // Check if map is attackable
            if (!(modTypes.Map[S_Players.GetPlayerMap(attacker)].Moral == (byte)Enums.MapMoralType.None))
            {
                if (S_Players.GetPlayerPK(victim) == 0)
                    return false;
            }

            // Make sure they have more then 0 hp
            if (S_Players.GetPlayerVital(victim, Enums.VitalType.HP) <= 0)
                return false;

            // Check to make sure that they dont have access
            if (S_Players.GetPlayerAccess(attacker) > (int)Enums.AdminType.Monitor)
            {
                S_NetworkSend.PlayerMsg(attacker, "Admins cannot attack other players.", (int)Enums.ColorType.Yellow);
                return false;
            }

            // Check to make sure the victim isn't an admin
            if (S_Players.GetPlayerAccess(victim) > (int)Enums.AdminType.Monitor)
            {
                S_NetworkSend.PlayerMsg(attacker, "You cannot attack " + S_Players.GetPlayerName(victim) + "!", (int)Enums.ColorType.Yellow);
                return false;
            }

            // Don't attack a party member
            if (modTypes.TempPlayer[attacker].InParty > 0 && modTypes.TempPlayer[victim].InParty > 0)
            {
                if (modTypes.TempPlayer[attacker].InParty == modTypes.TempPlayer[victim].InParty)
                {
                    S_NetworkSend.PlayerMsg(attacker, "You can't attack another party member!", (int)Enums.ColorType.Yellow);
                    return false;
                }
            }

            return true;
        }

        public static void PetAttackPlayer(int attacker, int victim, int damage, int skillNum = 0)
        {
            int exp;
            int n;
            int i;

            // Check for subscript out of range

            if (S_NetworkConfig.IsPlaying(attacker) == false || S_NetworkConfig.IsPlaying(victim) == false || damage < 0 || PetAlive(attacker) == false)
                return;

            // Check for weapon
            n = 0; // No Weapon, PET!

            if (skillNum == 0)
                // Send this packet so they can see the pet attacking
                SendPetAttack(attacker, victim);

            // set the regen timer
            modTypes.TempPlayer[attacker].PetstopRegen = true;
            modTypes.TempPlayer[attacker].PetstopRegenTimer = S_General.GetTimeMs();

            if (damage >= S_Players.GetPlayerVital(victim, Enums.VitalType.HP))
            {
                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(victim), "-" + S_Players.GetPlayerVital(victim, Enums.VitalType.HP), (int)Enums.ColorType.BrightRed, 1, (S_Players.GetPlayerX(victim) * 32), (S_Players.GetPlayerY(victim) * 32));

                // send the sound
                // If SkillNum > 0 Then SendMapSound(Victim, GetPlayerX(Victim), GetPlayerY(Victim), SoundEntity.seSpell, SkillNum)

                // Player is dead
                S_NetworkSend.GlobalMsg(S_Players.GetPlayerName(victim) + " has been killed by " + S_Players.GetPlayerName(attacker) + "'s " + Microsoft.VisualBasic.Strings.Trim(GetPetName(attacker)) + ".");

                // Calculate exp to give attacker
                exp = (S_Players.GetPlayerExp(victim) / 10);

                // Make sure we dont get less then 0
                if (exp < 0)
                    exp = 0;

                if (exp == 0)
                {
                    S_NetworkSend.PlayerMsg(victim, "You lost no exp.", (int)Enums.ColorType.BrightGreen);
                    S_NetworkSend.PlayerMsg(attacker, "You received no exp.", (int)Enums.ColorType.BrightRed);
                }
                else
                {
                    S_Players.SetPlayerExp(victim, S_Players.GetPlayerExp(victim) - exp);
                    S_NetworkSend.SendExp(victim);
                    S_NetworkSend.PlayerMsg(victim, "You lost " + exp + " exp.", (int)Enums.ColorType.BrightRed);

                    // check if we're in a party
                    if (modTypes.TempPlayer[attacker].InParty > 0)
                        // pass through party exp share function
                        S_Parties.Party_ShareExp(modTypes.TempPlayer[attacker].InParty, exp, attacker, S_Players.GetPlayerMap(attacker));
                    else
                        // not in party, get exp for self
                        S_Events.GivePlayerExp(attacker, exp);
                }

                var loopTo = S_NetworkConfig.Socket.HighIndex;

                // purge target info of anyone who targetted dead guy
                for (i = 1; i <= loopTo; i++)
                {
                    if (S_NetworkConfig.IsPlaying(i) && S_NetworkConfig.Socket.IsConnected(i))
                    {
                        if (S_Players.GetPlayerMap(i) == S_Players.GetPlayerMap(attacker))
                        {
                            if (modTypes.TempPlayer[i].TargetType == (int)Enums.TargetType.Player)
                            {
                                if (modTypes.TempPlayer[i].Target == victim)
                                {
                                    modTypes.TempPlayer[i].Target = 0;
                                    modTypes.TempPlayer[i].TargetType = (int)Enums.TargetType.None;
                                    S_NetworkSend.SendTarget(i, 0, (byte)Enums.TargetType.None);
                                }
                            }

                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Pet.Alive == 1)
                            {
                                if (modTypes.TempPlayer[i].PetTargetType == (int)Enums.TargetType.Player)
                                {
                                    if (modTypes.TempPlayer[i].PetTarget == victim)
                                    {
                                        modTypes.TempPlayer[i].PetTarget = 0;
                                        modTypes.TempPlayer[i].PetTargetType = (int)Enums.TargetType.None;
                                    }
                                }
                            }
                        }
                    }
                }

                if (S_Players.GetPlayerPK(victim) == 0)
                {
                    if (S_Players.GetPlayerPK(attacker) == 0)
                    {
                        S_Players.SetPlayerPK(attacker, 1);
                        S_NetworkSend.SendPlayerData(attacker);
                        S_NetworkSend.GlobalMsg(S_Players.GetPlayerName(attacker) + " has been deemed a Player Killer!!!");
                    }
                }
                else
                    S_NetworkSend.GlobalMsg(S_Players.GetPlayerName(victim) + " has paid the price for being a Player Killer!!!");

                S_Players.OnDeath(victim);
            }
            else
            {
                // Player not dead, just do the damage
                S_Players.SetPlayerVital(victim, Enums.VitalType.HP, S_Players.GetPlayerVital(victim, Enums.VitalType.HP) - damage);
                S_NetworkSend.SendVital(victim, Enums.VitalType.HP);

                // send vitals to party if in one
                if (modTypes.TempPlayer[victim].InParty > 0)
                    S_Parties.SendPartyVitals(modTypes.TempPlayer[victim].InParty, victim);

                // send the sound
                // If SkillNum > 0 Then SendMapSound(Victim, GetPlayerX(Victim), GetPlayerY(Victim), SoundEntity.seSpell, SkillNum)

                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(victim), "-" + damage, (int)Enums.ColorType.BrightRed, 1, (S_Players.GetPlayerX(victim) * 32), (S_Players.GetPlayerY(victim) * 32));
                S_NetworkSend.SendBlood(S_Players.GetPlayerMap(victim), S_Players.GetPlayerX(victim), S_Players.GetPlayerY(victim));

                // set the regen timer
                modTypes.TempPlayer[victim].StopRegen = 1;
                modTypes.TempPlayer[victim].StopRegenTimer = S_General.GetTimeMs();

                // if a stunning spell, stun the player
                if (skillNum > 0)
                {
                    if (Types.Skill[skillNum].StunDuration > 0)
                        S_Players.StunPlayer(victim, skillNum);

                    // DoT
                    if (Types.Skill[skillNum].Duration > 0)
                    {
                    }
                }
            }

            // Reset attack timer
            modTypes.TempPlayer[attacker].PetAttackTimer = S_General.GetTimeMs();
        }

        internal static void TryPetAttackPlayer(int index, int victim)
        {
            int mapNum;
            int blockAmount;
            int damage;

            if (S_Players.GetPlayerMap(index) != S_Players.GetPlayerMap(victim))
                return;

            if (!PetAlive(index))
                return;

            // Can the npc attack the player?
            if (CanPetAttackPlayer(index, victim))
            {
                mapNum = S_Players.GetPlayerMap(index);

                // check if PLAYER can avoid the attack
                if (S_Players.CanPlayerDodge(victim))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Dodge!", (int)Enums.ColorType.Pink, 1, (S_Players.GetPlayerX(victim) * 32), (S_Players.GetPlayerY(victim) * 32));
                    return;
                }

                if (S_Players.CanPlayerParry(victim))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Parry!", (int)Enums.ColorType.Pink, 1, (S_Players.GetPlayerX(victim) * 32), (S_Players.GetPlayerY(victim) * 32));
                    return;
                }

                // Get the damage we can do
                damage = GetPetDamage(index);

                // if the player blocks, take away the block amount
                blockAmount = unchecked(((S_Players.CanPlayerBlockHit(victim) != false) ? true : false)) ? 1 : 0; ;
                damage = damage - blockAmount;

                // take away armour
                damage = damage - S_GameLogic.Random(1, (GetPetStat(index, Enums.StatType.Luck)) * 2);

                // randomise for up to 10% lower than max hit
                damage = S_GameLogic.Random(1, damage);

                // * 1.5 if crit hit
                if (CanPetCrit(index))
                {
                    damage = (int)(damage * 1.5);
                    S_NetworkSend.SendActionMsg(mapNum, "Critical!", (int)Enums.ColorType.BrightCyan, 1, (GetPetX(index) * 32), (GetPetY(index) * 32));
                }

                if (damage > 0)
                    PetAttackPlayer(index, victim, damage);
            }
        }



        public static bool CanPetAttackPet(int attacker, int victim, int isSkill = 0)
        {
            if (!(isSkill == 1))
            {
                if (S_General.GetTimeMs() < modTypes.TempPlayer[attacker].PetAttackTimer + 1000)
                    return false;
            }

            // Check for subscript out of range
            if (!S_NetworkConfig.IsPlaying(victim) || !S_NetworkConfig.IsPlaying(attacker))
                return false;

            // Make sure they are on the same map
            if (!(S_Players.GetPlayerMap(attacker) == S_Players.GetPlayerMap(victim)))
                return false;

            // Make sure we dont attack the player if they are switching maps
            if (modTypes.TempPlayer[victim].GettingMap == 1)
                return false;

            if (modTypes.TempPlayer[attacker].PetskillBuffer.Skill > 0 && isSkill == 0)
                return false;

            if (!(isSkill == 1))
            {

                // Check if at same coordinates
                switch (GetPetDir(attacker))
                {
                    case (int)Enums.DirectionType.Up:
                        {
                            if (!((GetPetY(victim) - 1 == GetPetY(attacker)) && (GetPetX(victim) == GetPetX(attacker))))
                                return false;
                            break;
                        }

                    case (int)Enums.DirectionType.Down:
                        {
                            if (!((GetPetY(victim) + 1 == GetPetY(attacker)) && (GetPetX(victim) == GetPetX(attacker))))
                                return false;
                            break;
                        }

                    case (int)Enums.DirectionType.Left:
                        {
                            if (!((GetPetY(victim) == GetPetY(attacker)) && (GetPetX(victim) + 1 == GetPetX(attacker))))
                                return false;
                            break;
                        }

                    case (int)Enums.DirectionType.Right:
                        {
                            if (!((GetPetY(victim) == GetPetY(attacker)) && (GetPetX(victim) - 1 == GetPetX(attacker))))
                                return false;
                            break;
                        }

                    default:
                        {
                            return false;
                        }
                }
            }

            // Check if map is attackable
            if (!(modTypes.Map[S_Players.GetPlayerMap(attacker)].Moral == (byte)Enums.MapMoralType.None))
            {
                if (S_Players.GetPlayerPK(victim) == 0)
                    return false;
            }

            // Make sure they have more then 0 hp
            if (modTypes.Player[victim].Character[modTypes.TempPlayer[victim].CurChar].Pet.Health <= 0)
                return false;

            // Check to make sure that they dont have access
            if (S_Players.GetPlayerAccess(attacker) > (int)Enums.AdminType.Monitor)
            {
                S_NetworkSend.PlayerMsg(attacker, "Admins cannot attack other players.", (int)Enums.ColorType.BrightRed);
                return false;
            }

            // Check to make sure the victim isn't an admin
            if (S_Players.GetPlayerAccess(victim) > (int)Enums.AdminType.Monitor)
            {
                S_NetworkSend.PlayerMsg(attacker, "You cannot attack " + S_Players.GetPlayerName(victim) + "!", (int)Enums.ColorType.BrightRed);
                return false;
            }

            // Don't attack a party member
            if (modTypes.TempPlayer[attacker].InParty > 0 && modTypes.TempPlayer[victim].InParty > 0)
            {
                if (modTypes.TempPlayer[attacker].InParty == modTypes.TempPlayer[victim].InParty)
                {
                    S_NetworkSend.PlayerMsg(attacker, "You can't attack another party member!", (int)Enums.ColorType.BrightRed);
                    return false;
                }
            }

            if (modTypes.TempPlayer[attacker].InParty > 0 && modTypes.TempPlayer[victim].InParty > 0 && modTypes.TempPlayer[attacker].InParty == modTypes.TempPlayer[victim].InParty)
            {
                if (isSkill > 0)
                {
                    if (Types.Skill[isSkill].Type == (byte)Enums.SkillType.HealMp || Types.Skill[isSkill].Type == (byte)Enums.SkillType.HealHp)
                    {
                    }
                    else
                        return false;
                }
                else
                    return false;
            }

            return true;
        }

        public static void PetAttackPet(int attacker, int victim, int damage, int skillnum = 0)
        {
            int exp;
            int n;
            int i;

            // Check for subscript out of range

            if (S_NetworkConfig.IsPlaying(attacker) == false || S_NetworkConfig.IsPlaying(victim) == false || damage < 0 || PetAlive(attacker) == false || PetAlive(victim) == false)
                return;

            // Check for weapon
            n = 0; // No Weapon, PET!

            if (skillnum == 0)
                // Send this packet so they can see the pet attacking
                SendPetAttack(attacker, victim);

            // set the regen timer
            modTypes.TempPlayer[attacker].PetstopRegen = true;
            modTypes.TempPlayer[attacker].PetstopRegenTimer = S_General.GetTimeMs();

            if (damage >= GetPetVital(victim, Enums.VitalType.HP))
            {
                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(victim), "-" + GetPetVital(victim, Enums.VitalType.HP), (int)Enums.ColorType.BrightRed, (byte)Enums.ActionMsgType.Scroll, (GetPetX(victim) * 32), (GetPetY(victim) * 32));

                // send the sound
                // If Spellnum > 0 Then SendMapSound Victim, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seSpell, Spellnum

                // Player is dead
                S_NetworkSend.GlobalMsg(S_Players.GetPlayerName(victim) + " has been killed by " + S_Players.GetPlayerName(attacker) + "'s " + Microsoft.VisualBasic.Strings.Trim(GetPetName(attacker)) + ".");

                // Calculate exp to give attacker
                exp = (S_Players.GetPlayerExp(victim) / 10);

                // Make sure we dont get less then 0
                if (exp < 0)
                    exp = 0;

                if (exp == 0)
                {
                    S_NetworkSend.PlayerMsg(victim, "You lost no exp.", (int)Enums.ColorType.BrightGreen);
                    S_NetworkSend.PlayerMsg(attacker, "You received no exp.", (int)Enums.ColorType.Yellow);
                }
                else
                {
                    S_Players.SetPlayerExp(victim, S_Players.GetPlayerExp(victim) - exp);
                    S_NetworkSend.SendExp(victim);
                    S_NetworkSend.PlayerMsg(victim, "You lost " + exp + " exp.", (int)Enums.ColorType.BrightRed);

                    // check if we're in a party
                    if (modTypes.TempPlayer[attacker].InParty > 0)
                        // pass through party exp share function
                        S_Parties.Party_ShareExp(modTypes.TempPlayer[attacker].InParty, exp, attacker, S_Players.GetPlayerMap(attacker));
                    else
                        // not in party, get exp for self
                        S_Events.GivePlayerExp(attacker, exp);
                }

                var loopTo = S_NetworkConfig.Socket.HighIndex;

                // purge target info of anyone who targetted dead guy
                for (i = 1; i <= loopTo; i++)
                {
                    if (S_NetworkConfig.IsPlaying(i) && S_NetworkConfig.Socket.IsConnected(i))
                    {
                        if (S_Players.GetPlayerMap(i) == S_Players.GetPlayerMap(attacker))
                        {
                            if (modTypes.TempPlayer[i].TargetType == (int)Enums.TargetType.Player)
                            {
                                if (modTypes.TempPlayer[i].Target == victim)
                                {
                                    modTypes.TempPlayer[i].Target = 0;
                                    modTypes.TempPlayer[i].TargetType = (int)Enums.TargetType.None;
                                    S_NetworkSend.SendTarget(i, 0, (byte)Enums.TargetType.None);
                                }
                            }

                            if (PetAlive(i))
                            {
                                if (modTypes.TempPlayer[i].PetTargetType == (int)Enums.TargetType.Player)
                                {
                                    if (modTypes.TempPlayer[i].PetTarget == victim)
                                    {
                                        modTypes.TempPlayer[i].PetTarget = 0;
                                        modTypes.TempPlayer[i].PetTargetType = (int)Enums.TargetType.None;
                                    }
                                }
                            }
                        }
                    }
                }

                if (S_Players.GetPlayerPK(victim) == 0)
                {
                    if (S_Players.GetPlayerPK(attacker) == 0)
                    {
                        S_Players.SetPlayerPK(attacker, 1);
                        S_NetworkSend.SendPlayerData(attacker);
                        S_NetworkSend.GlobalMsg(S_Players.GetPlayerName(attacker) + " has been deemed a Player Killer!!!");
                    }
                }
                else
                    S_NetworkSend.GlobalMsg(S_Players.GetPlayerName(victim) + " has paid the price for being a Player Killer!!!");

                // kill pet
                S_NetworkSend.PlayerMsg(victim, "Your " + Microsoft.VisualBasic.Strings.Trim(GetPetName(victim)) + " was killed by " + Microsoft.VisualBasic.Strings.Trim(S_Players.GetPlayerName(attacker)) + "'s " + Microsoft.VisualBasic.Strings.Trim(GetPetName(attacker)) + "!", (int)Enums.ColorType.BrightRed);
                ReleasePet(victim);
            }
            else
            {
                // Player not dead, just do the damage
                SetPetVital(victim, Enums.VitalType.HP, GetPetVital(victim, Enums.VitalType.HP) - damage);
                SendPetVital(victim, Enums.VitalType.HP);

                // Set pet to begin attacking the other pet if it isn't dead or dosent have another target
                if (modTypes.TempPlayer[victim].PetTarget <= 0 && modTypes.TempPlayer[victim].PetBehavior != PetBehaviourGoto)
                {
                    modTypes.TempPlayer[victim].PetTarget = attacker;
                    modTypes.TempPlayer[victim].PetTargetType = (int)Enums.TargetType.Pet;
                }

                // send the sound
                // If Spellnum > 0 Then SendMapSound Victim, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seSpell, Spellnum

                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(victim), "-" + damage, (int)Enums.ColorType.BrightRed, 1, (GetPetX(victim) * 32), (GetPetY(victim) * 32));
                S_NetworkSend.SendBlood(S_Players.GetPlayerMap(victim), GetPetX(victim), GetPetY(victim));

                // set the regen timer
                modTypes.TempPlayer[victim].PetstopRegen = true;
                modTypes.TempPlayer[victim].PetstopRegenTimer = S_General.GetTimeMs();

                // if a stunning spell, stun the player
                if (skillnum > 0)
                {
                    if (Types.Skill[skillnum].StunDuration > 0)
                        StunPet(victim, skillnum);
                    // DoT
                    if (Types.Skill[skillnum].Duration > 0)
                    {
                    }
                }
            }

            // Reset attack timer
            modTypes.TempPlayer[attacker].PetAttackTimer = S_General.GetTimeMs();
        }

        internal static void TryPetAttackPet(int index, int victim)
        {
            int mapNum;
            int blockAmount = 0;
            int damage = 0;

            if (S_Players.GetPlayerMap(index) != S_Players.GetPlayerMap(victim))
                return;

            if (!PetAlive(index) || !PetAlive(victim))
                return;

            // Can the npc attack the player?
            if (CanPetAttackPet(index, victim))
            {
                mapNum = S_Players.GetPlayerMap(index);

                // check if Pet can avoid the attack
                if (CanPetDodge(victim))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Dodge!", (int)Enums.ColorType.Pink, 1, (GetPetX(victim) * 32), (GetPetY(victim) * 32));
                    return;
                }

                if (CanPetParry(victim))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Parry!", (int)Enums.ColorType.Pink, 1, (GetPetX(victim) * 32), (GetPetY(victim) * 32));
                    return;
                }

                // Get the damage we can do
                damage = GetPetDamage(index);

                // if the player blocks, take away the block amount
                damage = damage - blockAmount;

                // take away armour
                damage = damage - S_GameLogic.Random(1, (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Stat[(int)Enums.StatType.Luck] * 2));

                // randomise for up to 10% lower than max hit
                damage = S_GameLogic.Random(1, damage);

                // * 1.5 if crit hit
                if (CanPetCrit(index))
                {
                    damage = (int)(damage * 1.5);
                    S_NetworkSend.SendActionMsg(mapNum, "Critical!", (int)Enums.ColorType.BrightCyan, 1, (GetPetX(index) * 32), (GetPetY(index) * 32));
                }

                if (damage > 0)
                    PetAttackPet(index, victim, damage);
            }
        }



        internal static void BufferPetSkill(int index, int skillSlot)
        {
            int skillnum;
            int mpCost;
            int levelReq;
            int mapNum;
            int skillCastType;
            int accessReq;
            int range;
            bool hasBuffered;
            byte targetTypes;
            int target;

            // Prevent subscript out of range

            if (skillSlot <= 0 || skillSlot > 4)
                return;

            skillnum = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Skill[skillSlot];
            mapNum = S_Players.GetPlayerMap(index);

            if (skillnum <= 0 || skillnum > Constants.MAX_SKILLS)
                return;

            // see if cooldown has finished
            if (modTypes.TempPlayer[index].PetSkillCd[skillSlot] > S_General.GetTimeMs())
            {
                S_NetworkSend.PlayerMsg(index, Microsoft.VisualBasic.Strings.Trim(GetPetName(index)) + "'s Skill hasn't cooled down yet!", (int)Enums.ColorType.BrightRed);
                return;
            }

            mpCost = Types.Skill[skillnum].MpCost;

            // Check if they have enough MP
            if (GetPetVital(index, Enums.VitalType.MP) < mpCost)
            {
                S_NetworkSend.PlayerMsg(index, "Your " + Microsoft.VisualBasic.Strings.Trim(GetPetName(index)) + " does not have enough mana!", (int)Enums.ColorType.BrightRed);
                return;
            }

            levelReq = Types.Skill[skillnum].LevelReq;

            // Make sure they are the right level
            if (levelReq > GetPetLevel(index))
            {
                S_NetworkSend.PlayerMsg(index, Microsoft.VisualBasic.Strings.Trim(GetPetName(index)) + " must be level " + levelReq + " to cast this skill.", (int)Enums.ColorType.BrightRed);
                return;
            }

            accessReq = Types.Skill[skillnum].AccessReq;

            // make sure they have the right access
            if (accessReq > S_Players.GetPlayerAccess(index))
            {
                S_NetworkSend.PlayerMsg(index, "You must be an administrator to cast this spell, even as a pet owner.", (int)Enums.ColorType.BrightRed);
                return;
            }

            // find out what kind of spell it is! self cast, target or AOE
            if (Types.Skill[skillnum].Range > 0)
            {

                // ranged attack, single target or aoe?
                if (!Types.Skill[skillnum].IsAoE)
                    skillCastType = 2; // targetted
                else
                    skillCastType = 3;// targetted aoe
            }
            else if (!Types.Skill[skillnum].IsAoE)
                skillCastType = 0; // self-cast
            else
                skillCastType = 1;// self-cast AoE

            targetTypes = (byte)modTypes.TempPlayer[index].PetTargetType;
            target = modTypes.TempPlayer[index].PetTarget;
            range = Types.Skill[skillnum].Range;
            hasBuffered = false;

            switch (skillCastType)
            {
                case 0:
                case 1:
                case (int)Enums.SkillType.Pet // self-cast & self-cast AOE
               :
                    {
                        hasBuffered = true;
                        break;
                    }

                case 2:
                case 3 // targeted & targeted AOE
         :
                    {

                        // check if have target
                        if (!(target > 0))
                        {
                            if (skillCastType == (byte)Enums.SkillType.HealHp || skillCastType == (byte)Enums.SkillType.HealMp)
                            {
                                target = index;
                                targetTypes = (int)Enums.TargetType.Pet;
                            }
                            else
                                S_NetworkSend.PlayerMsg(index, "Your " + Microsoft.VisualBasic.Strings.Trim(GetPetName(index)) + " does not have a target.", (int)Enums.ColorType.Yellow);
                        }

                        if (targetTypes == (int)Enums.TargetType.Player)
                        {

                            // if have target, check in range
                            if (!S_Players.IsInRange(range, GetPetX(index), GetPetY(index), S_Players.GetPlayerX(target), S_Players.GetPlayerY(target)))
                                S_NetworkSend.PlayerMsg(index, "Target not in range of " + Microsoft.VisualBasic.Strings.Trim(GetPetName(index)) + ".", (int)Enums.ColorType.Yellow);
                            else
                                // go through spell types
                                if (Types.Skill[skillnum].Type != (int)Enums.SkillType.DamageHp && Types.Skill[skillnum].Type != (int)Enums.SkillType.DamageMp)
                                hasBuffered = true;
                            else if (CanPetAttackPlayer(index, target, true))
                                hasBuffered = true;
                        }
                        else if (targetTypes == (int)Enums.TargetType.Npc)
                        {

                            // if have target, check in range
                            if (!S_Players.IsInRange(range, GetPetX(index), GetPetY(index), modTypes.MapNpc[mapNum].Npc[target].X, modTypes.MapNpc[mapNum].Npc[target].Y))
                            {
                                S_NetworkSend.PlayerMsg(index, "Target not in range of " + Microsoft.VisualBasic.Strings.Trim(GetPetName(index)) + ".", (int)Enums.ColorType.Yellow);
                                hasBuffered = false;
                            }
                            else
                                // go through spell types
                                if (Types.Skill[skillnum].Type != (int)Enums.SkillType.DamageHp && Types.Skill[skillnum].Type != (int)Enums.SkillType.DamageMp)
                                hasBuffered = true;
                            else if (CanPetAttackNpc(index, target, true))
                                hasBuffered = true;
                        }
                        else if (targetTypes == (int)Enums.TargetType.Pet)
                        {

                            // if have target, check in range
                            if (!S_Players.IsInRange(range, GetPetX(index), GetPetY(index), GetPetX(target), GetPetY(target)))
                            {
                                S_NetworkSend.PlayerMsg(index, "Target not in range of " + GetPetName(index).Trim() + ".", (int)Enums.ColorType.Yellow);
                                hasBuffered = false;
                            }
                            else
                                // go through spell types
                                if (Types.Skill[skillnum].Type != (int)Enums.SkillType.DamageHp && Types.Skill[skillnum].Type != (int)Enums.SkillType.DamageMp)
                                hasBuffered = true;
                            else if (CanPetAttackPet(index, target, skillnum))
                                hasBuffered = true;
                        }

                        break;
                    }
            }

            if (hasBuffered)
            {
                S_Animations.SendAnimation(mapNum, Types.Skill[skillnum].CastAnim, 0, 0, (byte)Enums.TargetType.Pet, index);
                S_NetworkSend.SendActionMsg(mapNum, "Casting " + Microsoft.VisualBasic.Strings.Trim(Types.Skill[skillnum].Name) + "!", (int)Enums.ColorType.BrightRed, (byte)Enums.ActionMsgType.Scroll, GetPetX(index) * 32, GetPetY(index) * 32);
                modTypes.TempPlayer[index].PetskillBuffer.Skill = skillSlot;
                modTypes.TempPlayer[index].PetskillBuffer.Timer = S_General.GetTimeMs();
                modTypes.TempPlayer[index].PetskillBuffer.Target = target;
                modTypes.TempPlayer[index].PetskillBuffer.TargetTypes = targetTypes;
                return;
            }
            else
                SendClearPetSpellBuffer(index);
        }

        internal static void PetCastSkill(int index, int skillslot, int target, byte targetTypes, bool takeMana = true)
        {
            int skillnum = 0;
            int mpCost = 0;
            int levelReq = 0;
            int mapNum = 0;
            int vital = 0;
            bool didCast = false;
            int accessReq = 0;
            int i = 0;
            int aoE = 0;
            int range = 0;
            byte vitalType = 0;
            bool increment = false;
            int x = 0;
            int y = 0;
            int skillCastType = 0;

            didCast = false;

            // Prevent subscript out of range
            if (skillslot <= 0 || skillslot > 4)
                return;

            skillnum = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Skill[skillslot];
            mapNum = S_Players.GetPlayerMap(index);

            mpCost = Types.Skill[skillnum].MpCost;

            // Check if they have enough MP
            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Mana < mpCost)
            {
                S_NetworkSend.PlayerMsg(index, "Your " + Microsoft.VisualBasic.Strings.Trim(GetPetName(index)) + " does not have enough mana!", (int)Enums.ColorType.BrightRed);
                return;
            }

            levelReq = Types.Skill[skillnum].LevelReq;

            // Make sure they are the right level
            if (levelReq > modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Level)
            {
                S_NetworkSend.PlayerMsg(index, Microsoft.VisualBasic.Strings.Trim(GetPetName(index)) + " must be level " + levelReq + " to cast this spell.", (int)Enums.ColorType.BrightRed);
                return;
            }

            accessReq = Types.Skill[skillnum].AccessReq;

            // make sure they have the right access
            if (accessReq > S_Players.GetPlayerAccess(index))
            {
                S_NetworkSend.PlayerMsg(index, "You must be an administrator for even your pet to cast this spell.", (int)Enums.ColorType.BrightRed);
                return;
            }

            // find out what kind of spell it is! self cast, target or AOE
            if (Types.Skill[skillnum].IsProjectile == 1)
                skillCastType = 4; // Projectile
            else if (Types.Skill[skillnum].Range > 0)
            {
                // ranged attack, single target or aoe?
                if (!Types.Skill[skillnum].IsAoE)
                    skillCastType = 2; // targetted
                else
                    skillCastType = 3;// targetted aoe
            }
            else if (!Types.Skill[skillnum].IsAoE)
                skillCastType = 0; // self-cast
            else
                skillCastType = 1;// self-cast AoE

            // set the vital
            vital = Types.Skill[skillnum].Vital;
            aoE = Types.Skill[skillnum].AoE;
            range = Types.Skill[skillnum].Range;

            switch (skillCastType)
            {
                case 0 // self-cast target
               :
                    {
                        switch (Types.Skill[skillnum].Type)
                        {
                            case (int)Enums.SkillType.HealHp:
                                {
                                    SkillPet_Effect((byte)Enums.VitalType.HP, true, index, vital, skillnum);
                                    didCast = true;
                                    break;
                                }

                            case (int)Enums.SkillType.HealMp:
                                {
                                    SkillPet_Effect((byte)Enums.VitalType.MP, true, index, vital, skillnum);
                                    didCast = true;
                                    break;
                                }
                        }

                        break;
                    }

                case 1:
                case 3 // self-cast AOE & targetted AOE
         :
                    {
                        if (skillCastType == 1)
                        {
                            x = GetPetX(index);
                            y = GetPetY(index);
                        }
                        else if (skillCastType == 3)
                        {
                            if (targetTypes == 0)
                                return;
                            if (target == 0)
                                return;

                            if (targetTypes == (int)Enums.TargetType.Player)
                            {
                                x = S_Players.GetPlayerX(target);
                                y = S_Players.GetPlayerY(target);
                            }
                            else if (targetTypes == (int)Enums.TargetType.Npc)
                            {
                                x = modTypes.MapNpc[mapNum].Npc[target].X;
                                y = modTypes.MapNpc[mapNum].Npc[target].Y;
                            }
                            else if (targetTypes == (int)Enums.TargetType.Pet)
                            {
                                x = GetPetX(target);
                                y = GetPetY(target);
                            }

                            if (!S_Players.IsInRange(range, GetPetX(index), GetPetY(index), x, y))
                            {
                                S_NetworkSend.PlayerMsg(index, Microsoft.VisualBasic.Strings.Trim(GetPetName(index)) + "'s target not in range.", (int)Enums.ColorType.Yellow);
                                SendClearPetSpellBuffer(index);
                            }
                        }

                        switch (Types.Skill[skillnum].Type)
                        {
                            case (int)Enums.SkillType.DamageHp:
                                {
                                    didCast = true;
                                    var loopTo = S_GameLogic.GetPlayersOnline();
                                    for (i = 1; i <= loopTo; i++)
                                    {
                                        if (S_NetworkConfig.IsPlaying(i) && i != index)
                                        {
                                            if (S_Players.GetPlayerMap(i) == S_Players.GetPlayerMap(index))
                                            {
                                                if (S_Players.IsInRange(aoE, x, y, S_Players.GetPlayerX(i), S_Players.GetPlayerY(i)))
                                                {
                                                    if (CanPetAttackPlayer(index, i, true) && index != target)
                                                    {
                                                        S_Animations.SendAnimation(mapNum, Types.Skill[skillnum].SkillAnim, 0, 0, (byte)Enums.TargetType.Player, i);
                                                        PetAttackPlayer(index, i, vital, skillnum);
                                                    }
                                                }

                                                if (PetAlive(i))
                                                {
                                                    if (S_Players.IsInRange(aoE, x, y, GetPetX(i), GetPetY(i)))
                                                    {
                                                        if (CanPetAttackPet(index, i, skillnum))
                                                        {
                                                            S_Animations.SendAnimation(mapNum, Types.Skill[skillnum].SkillAnim, 0, 0, (byte)Enums.TargetType.Pet, i);
                                                            PetAttackPet(index, i, vital, skillnum);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                                    {
                                        if (modTypes.MapNpc[mapNum].Npc[i].Num > 0 && modTypes.MapNpc[mapNum].Npc[i].Vital[(int)Enums.VitalType.HP] > 0)
                                        {
                                            if (S_Players.IsInRange(aoE, x, y, modTypes.MapNpc[mapNum].Npc[i].X, modTypes.MapNpc[mapNum].Npc[i].Y))
                                            {
                                                if (CanPetAttackNpc(index, i, true))
                                                {
                                                    S_Animations.SendAnimation(mapNum, Types.Skill[skillnum].SkillAnim, 0, 0, (byte)Enums.TargetType.Npc, i);
                                                    PetAttackNpc(index, i, vital, skillnum);
                                                }
                                            }
                                        }
                                    }

                                    break;
                                }

                            case (int)Enums.SkillType.HealHp:
                            case (int)Enums.SkillType.HealMp:
                            case (int)Enums.SkillType.DamageMp:
                                {
                                    if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.HealHp)
                                    {
                                        vitalType = (byte)Enums.VitalType.HP;
                                        increment = true;
                                    }
                                    else if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.HealMp)
                                    {
                                        vitalType = (byte)Enums.VitalType.MP;
                                        increment = true;
                                    }
                                    else if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.DamageMp)
                                    {
                                        vitalType = (byte)Enums.VitalType.MP;
                                        increment = false;
                                    }

                                    didCast = true;
                                    var loopTo1 = S_GameLogic.GetPlayersOnline();
                                    for (i = 1; i <= loopTo1; i++)
                                    {
                                        if (S_NetworkConfig.IsPlaying(i) && S_Players.GetPlayerMap(i) == S_Players.GetPlayerMap(index))
                                        {
                                            if (S_Players.IsInRange(aoE, x, y, S_Players.GetPlayerX(i), S_Players.GetPlayerY(i)))
                                                S_Players.SpellPlayer_Effect(vitalType, increment, i, vital, skillnum);

                                            if (PetAlive(i))
                                            {
                                                if (S_Players.IsInRange(aoE, x, y, GetPetX(i), GetPetY(i)))
                                                    SkillPet_Effect(vitalType, increment, i, vital, skillnum);
                                            }
                                        }
                                    }

                                    break;
                                }
                        }

                        break;
                    }

                case 2 // targetted
         :
                    {
                        if (targetTypes == 0)
                            return;
                        if (target == 0)
                            return;

                        if (targetTypes == (int)Enums.TargetType.Player)
                        {
                            x = S_Players.GetPlayerX(target);
                            y = S_Players.GetPlayerY(target);
                        }
                        else if (targetTypes == (int)Enums.TargetType.Npc)
                        {
                            x = modTypes.MapNpc[mapNum].Npc[target].X;
                            y = modTypes.MapNpc[mapNum].Npc[target].Y;
                        }
                        else if (targetTypes == (int)Enums.TargetType.Pet)
                        {
                            x = GetPetX(target);
                            y = GetPetY(target);
                        }

                        if (!S_Players.IsInRange(range, GetPetX(index), GetPetY(index), x, y))
                        {
                            S_NetworkSend.PlayerMsg(index, "Target is not in range of your " + Microsoft.VisualBasic.Strings.Trim(GetPetName(index)) + "!", (int)Enums.ColorType.Yellow);
                            SendClearPetSpellBuffer(index);
                            return;
                        }

                        switch (Types.Skill[skillnum].Type)
                        {
                            case (int)Enums.SkillType.DamageHp:
                                {
                                    if (targetTypes == (int)Enums.TargetType.Player)
                                    {
                                        if (CanPetAttackPlayer(index, target, true) && index != target)
                                        {
                                            if (vital > 0)
                                            {
                                                S_Animations.SendAnimation(mapNum, Types.Skill[skillnum].SkillAnim, 0, 0, (byte)Enums.TargetType.Player, target);
                                                PetAttackPlayer(index, target, vital, skillnum);
                                                didCast = true;
                                            }
                                        }
                                    }
                                    else if (targetTypes == (int)Enums.TargetType.Npc)
                                    {
                                        if (CanPetAttackNpc(index, target, true))
                                        {
                                            if (vital > 0)
                                            {
                                                S_Animations.SendAnimation(mapNum, Types.Skill[skillnum].SkillAnim, 0, 0, (byte)Enums.TargetType.Npc, target);
                                                PetAttackNpc(index, target, vital, skillnum);
                                                didCast = true;
                                            }
                                        }
                                    }
                                    else if (targetTypes == (int)Enums.TargetType.Pet)
                                    {
                                        if (CanPetAttackPet(index, target, skillnum))
                                        {
                                            if (vital > 0)
                                            {
                                                S_Animations.SendAnimation(mapNum, Types.Skill[skillnum].SkillAnim, 0, 0, (byte)Enums.TargetType.Pet, target);
                                                PetAttackPet(index, target, vital, skillnum);
                                                didCast = true;
                                            }
                                        }
                                    }

                                    break;
                                }

                            case (int)Enums.SkillType.DamageMp:
                            case (int)Enums.SkillType.HealMp:
                            case (int)Enums.SkillType.HealHp:
                                {
                                    if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.DamageMp)
                                    {
                                        vitalType = (byte)Enums.VitalType.MP;
                                        increment = false;
                                    }
                                    else if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.HealMp)
                                    {
                                        vitalType = (byte)Enums.VitalType.MP;
                                        increment = true;
                                    }
                                    else if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.HealHp)
                                    {
                                        vitalType = (byte)Enums.VitalType.HP;
                                        increment = true;
                                    }

                                    if (targetTypes == (int)Enums.TargetType.Player)
                                    {
                                        if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.DamageMp)
                                        {
                                            if (CanPetAttackPlayer(index, target, true))
                                                S_Players.SpellPlayer_Effect(vitalType, increment, target, vital, skillnum);
                                        }
                                        else
                                            S_Players.SpellPlayer_Effect(vitalType, increment, target, vital, skillnum);
                                    }
                                    else if (targetTypes == (int)Enums.TargetType.Npc)
                                    {
                                        if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.DamageMp)
                                        {
                                            if (CanPetAttackNpc(index, target, true))
                                                S_Npc.SpellNpc_Effect(vitalType, increment, target, vital, skillnum, mapNum);
                                        }
                                        else if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.HealHp || Types.Skill[skillnum].Type == (byte)Enums.SkillType.HealMp)
                                            SkillPet_Effect(vitalType, increment, index, vital, skillnum);
                                        else
                                            S_Npc.SpellNpc_Effect(vitalType, increment, target, vital, skillnum, mapNum);
                                    }
                                    else if (targetTypes == (int)Enums.TargetType.Pet)
                                    {
                                        if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.DamageMp)
                                        {
                                            if (CanPetAttackPet(index, target, skillnum))
                                                SkillPet_Effect(vitalType, increment, target, vital, skillnum);
                                        }
                                        else
                                        {
                                            SkillPet_Effect(vitalType, increment, target, vital, skillnum);
                                            SendPetVital(target, (VitalType)vital);
                                        }
                                    }

                                    break;
                                }
                        }

                        break;
                    }

                case 4 // Projectile
         :
                    {
                        PetFireProjectile(index, skillnum);
                        didCast = true;
                        break;
                    }
            }

            if (didCast)
            {
                if (takeMana)
                    SetPetVital(index, Enums.VitalType.MP, GetPetVital(index, Enums.VitalType.MP) - mpCost);
                SendPetVital(index, Enums.VitalType.MP);
                SendPetVital(index, Enums.VitalType.HP);

                modTypes.TempPlayer[index].PetSkillCd[skillslot] = S_General.GetTimeMs() + (Types.Skill[skillnum].CdTime * 1000);

                S_NetworkSend.SendActionMsg(mapNum, Microsoft.VisualBasic.Strings.Trim(Types.Skill[skillnum].Name) + "!", (int)Enums.ColorType.BrightRed, (byte)Enums.ActionMsgType.Scroll, GetPetX(index) * 32, GetPetY(index) * 32);
            }
        }

        internal static void SkillPet_Effect(byte vital, bool increment, int index, int damage, int skillnum)
        {
            string sSymbol;
            int colour = 0;

            if (damage > 0)
            {
                if (increment)
                {
                    sSymbol = "+";
                    if (vital == (byte)Enums.VitalType.HP)
                        colour = (int)Enums.ColorType.BrightGreen;
                    if (vital == (byte)Enums.VitalType.MP)
                        colour = (int)Enums.ColorType.BrightBlue;
                }
                else
                {
                    sSymbol = "-";
                    colour = (int)Enums.ColorType.Blue;
                }

                S_Animations.SendAnimation(S_Players.GetPlayerMap(index), Types.Skill[skillnum].SkillAnim, 0, 0, (byte)Enums.TargetType.Pet, index);
                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(index), sSymbol + damage, colour, (byte)Enums.ActionMsgType.Scroll, GetPetX(index) * 32, GetPetY(index) * 32);

                // send the sound
                // SendMapSound(Index, Player(Index).Character(TempPlayer(Index).CurChar).Pet.x, Player(Index).Character(TempPlayer(Index).CurChar).Pet.y, SoundEntity.seSpell, Skillnum)

                if (increment)
                {
                    SetPetVital(index, Enums.VitalType.HP, GetPetVital(index, Enums.VitalType.HP) + damage);

                    if (Types.Skill[skillnum].Duration > 0)
                        AddHoT_Pet(index, skillnum);
                }
                else if (!increment)
                {
                    if (vital == (byte)Enums.VitalType.HP)
                        SetPetVital(index, Enums.VitalType.HP, GetPetVital(index, Enums.VitalType.HP) - damage);
                    else if (vital == (byte)Enums.VitalType.MP)
                        SetPetVital(index, Enums.VitalType.MP, GetPetVital(index, Enums.VitalType.MP) - damage);
                }
            }

            if (GetPetVital(index, Enums.VitalType.HP) > GetPetMaxVital(index, Enums.VitalType.HP))
                SetPetVital(index, Enums.VitalType.HP, GetPetMaxVital(index, Enums.VitalType.HP));

            if (GetPetVital(index, Enums.VitalType.MP) > GetPetMaxVital(index, Enums.VitalType.MP))
                SetPetVital(index, Enums.VitalType.MP, GetPetMaxVital(index, Enums.VitalType.MP));
        }

        internal static void AddHoT_Pet(int index, int skillnum)
        {
            int i;

            for (i = 1; i <= Constants.MAX_DOTS; i++)
            {
                {
                    if (modTypes.TempPlayer[index].PetHoT[i].Skill == skillnum)
                    {
                        modTypes.TempPlayer[index].PetHoT[i].Timer = S_General.GetTimeMs();
                        modTypes.TempPlayer[index].PetHoT[i].StartTime = S_General.GetTimeMs();
                        return;
                    }

                    if (modTypes.TempPlayer[index].PetHoT[i].Used == false)
                    {
                        modTypes.TempPlayer[index].PetHoT[i].Skill = skillnum;
                        modTypes.TempPlayer[index].PetHoT[i].Timer = S_General.GetTimeMs();
                        modTypes.TempPlayer[index].PetHoT[i].Used = true;
                        modTypes.TempPlayer[index].PetHoT[i].StartTime = S_General.GetTimeMs();
                        return;
                    }
                }
            }
        }

        internal static void AddDoT_Pet(int index, int skillnum, int caster, int attackerType)
        {
            int i;

            if (!PetAlive(index))
                return;

            for (i = 1; i <= Constants.MAX_DOTS; i++)
            {
                {
                    if (modTypes.TempPlayer[index].PetDoT[i].Skill == skillnum)
                    {
                        modTypes.TempPlayer[index].PetDoT[i].Timer = S_General.GetTimeMs();
                        modTypes.TempPlayer[index].PetDoT[i].Caster = caster;
                        modTypes.TempPlayer[index].PetDoT[i].StartTime = S_General.GetTimeMs();
                        modTypes.TempPlayer[index].PetDoT[i].AttackerType = attackerType;
                        return;
                    }

                    if (modTypes.TempPlayer[index].PetDoT[i].Used == false)
                    {
                        modTypes.TempPlayer[index].PetDoT[i].Skill = skillnum;
                        modTypes.TempPlayer[index].PetDoT[i].Timer = S_General.GetTimeMs();
                        modTypes.TempPlayer[index].PetDoT[i].Caster = caster;
                        modTypes.TempPlayer[index].PetDoT[i].Used = true;
                        modTypes.TempPlayer[index].PetDoT[i].StartTime = S_General.GetTimeMs();
                        modTypes.TempPlayer[index].PetDoT[i].AttackerType = attackerType;
                        return;
                    }
                }
            }
        }

        internal static void StunPet(int index, int skillnum)
        {
            // check if it's a stunning spell

            if (PetAlive(index))
            {
                if (Types.Skill[skillnum].StunDuration > 0)
                {
                    // set the values on index
                    modTypes.TempPlayer[index].PetStunDuration = Types.Skill[skillnum].StunDuration;
                    modTypes.TempPlayer[index].PetStunTimer = S_General.GetTimeMs();
                    // tell him he's stunned
                    S_NetworkSend.PlayerMsg(index, "Your " + Microsoft.VisualBasic.Strings.Trim(GetPetName(index)) + " has been stunned.", (int)Enums.ColorType.Yellow);
                }
            }
        }

        internal static void HandleDoT_Pet(int index, int dotNum)
        {
            {
                if (modTypes.TempPlayer[index].PetDoT[dotNum].Used && modTypes.TempPlayer[index].PetDoT[dotNum].Skill > 0)
                {
                    // time to tick?
                    if (S_General.GetTimeMs() > modTypes.TempPlayer[index].PetDoT[dotNum].Timer + (Types.Skill[modTypes.TempPlayer[index].PetDoT[dotNum].Skill].Interval * 1000))
                    {
                        if (modTypes.TempPlayer[index].PetDoT[dotNum].AttackerType == (int)Enums.TargetType.Pet)
                        {
                            if (CanPetAttackPet(modTypes.TempPlayer[index].PetDoT[dotNum].Caster, index, modTypes.TempPlayer[index].PetDoT[dotNum].Skill))
                            {
                                PetAttackPet(modTypes.TempPlayer[index].PetDoT[dotNum].Caster, index, Types.Skill[modTypes.TempPlayer[index].PetDoT[dotNum].Skill].Vital);
                                SendPetVital(index, Enums.VitalType.HP);
                                SendPetVital(index, Enums.VitalType.MP);
                            }
                        }
                        else if (modTypes.TempPlayer[index].PetDoT[dotNum].AttackerType == (int)Enums.TargetType.Player)
                        {
                            if (CanPlayerAttackPet(modTypes.TempPlayer[index].PetDoT[dotNum].Caster, index, Convert.ToBoolean(modTypes.TempPlayer[index].PetDoT[dotNum].Skill)))
                            {
                                PlayerAttackPet(modTypes.TempPlayer[index].PetDoT[dotNum].Caster, index, Types.Skill[modTypes.TempPlayer[index].PetDoT[dotNum].Skill].Vital);
                                SendPetVital(index, Enums.VitalType.HP);
                                SendPetVital(index, Enums.VitalType.MP);
                            }
                        }

                        modTypes.TempPlayer[index].PetDoT[dotNum].Timer = S_General.GetTimeMs();

                        // check if DoT is still active - if player died it'll have been purged
                        if (modTypes.TempPlayer[index].PetDoT[dotNum].Used && modTypes.TempPlayer[index].PetDoT[dotNum].Skill > 0)
                        {
                            // destroy DoT if finished
                            if (S_General.GetTimeMs() - modTypes.TempPlayer[index].PetDoT[dotNum].StartTime >= (Types.Skill[modTypes.TempPlayer[index].PetDoT[dotNum].Skill].Duration * 1000))
                            {
                                modTypes.TempPlayer[index].PetDoT[dotNum].Used = false;
                                modTypes.TempPlayer[index].PetDoT[dotNum].Skill = 0;
                                modTypes.TempPlayer[index].PetDoT[dotNum].Timer = 0;
                                modTypes.TempPlayer[index].PetDoT[dotNum].Caster = 0;
                                modTypes.TempPlayer[index].PetDoT[dotNum].StartTime = 0;
                            }
                        }
                    }
                }
            }
        }

        internal static void HandleHoT_Pet(int index, int hotNum)
        {
            {
                if (modTypes.TempPlayer[index].PetHoT[hotNum].Used && modTypes.TempPlayer[index].PetHoT[hotNum].Skill > 0)
                {
                    // time to tick?
                    if (S_General.GetTimeMs() > modTypes.TempPlayer[index].PetHoT[hotNum].Timer + (Types.Skill[modTypes.TempPlayer[index].PetHoT[hotNum].Skill].Interval * 1000))
                    {
                        S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(index), "+" + Types.Skill[modTypes.TempPlayer[index].PetHoT[hotNum].Skill].Vital, (int)Enums.ColorType.BrightGreen, (byte)Enums.ActionMsgType.Scroll, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.X * 32, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Y * 32);
                        SetPetVital(index, Enums.VitalType.HP, GetPetVital(index, Enums.VitalType.HP) + Types.Skill[modTypes.TempPlayer[index].PetHoT[hotNum].Skill].Vital);

                        if (GetPetVital(index, Enums.VitalType.HP) > GetPetMaxVital(index, Enums.VitalType.HP))
                            SetPetVital(index, Enums.VitalType.HP, GetPetMaxVital(index, Enums.VitalType.HP));

                        if (GetPetVital(index, Enums.VitalType.MP) > GetPetMaxVital(index, Enums.VitalType.MP))
                            SetPetVital(index, Enums.VitalType.MP, GetPetMaxVital(index, Enums.VitalType.MP));

                        SendPetVital(index, Enums.VitalType.HP);
                        SendPetVital(index, Enums.VitalType.MP);
                        modTypes.TempPlayer[index].PetHoT[hotNum].Timer = S_General.GetTimeMs();

                        // check if DoT is still active - if player died it'll have been purged
                        if (modTypes.TempPlayer[index].PetHoT[hotNum].Used && modTypes.TempPlayer[index].PetHoT[hotNum].Skill > 0)
                        {
                            // destroy hoT if finished
                            if (S_General.GetTimeMs() - modTypes.TempPlayer[index].PetHoT[hotNum].StartTime >= (Types.Skill[modTypes.TempPlayer[index].PetHoT[hotNum].Skill].Duration * 1000))
                            {
                                modTypes.TempPlayer[index].PetHoT[hotNum].Used = false;
                                modTypes.TempPlayer[index].PetHoT[hotNum].Skill = 0;
                                modTypes.TempPlayer[index].PetHoT[hotNum].Timer = 0;
                                modTypes.TempPlayer[index].PetHoT[hotNum].Caster = 0;
                                modTypes.TempPlayer[index].PetHoT[hotNum].StartTime = 0;
                            }
                        }
                    }
                }
            }
        }

        internal static bool CanPetDodge(int index)
        {
            int rate;
            int rndNum;
            bool CanPetDodge;
            if (!PetAlive(index))
                return false;

            CanPetDodge = false;

            rate = GetPetStat(index, Enums.StatType.Luck) / (int)4;
            rndNum = S_GameLogic.Random(1, 100);

            if (rndNum <= rate)
                CanPetDodge = true;

            return CanPetDodge;
        }

        internal static bool CanPetParry(int index)
        {
            int rate;
            int rndNum;
            bool CanPetParry;
            if (!PetAlive(index))
                return false;

            CanPetParry = false;

            rate = GetPetStat(index, Enums.StatType.Luck) / (int)6;
            rndNum = S_GameLogic.Random(1, 100);

            if (rndNum <= rate)
                CanPetParry = true;
            return CanPetParry;
        }



        public static bool CanPlayerAttackPet(int attacker, int victim, bool isSkill = false)
        {
            if (isSkill == false)
            {
                // Check attack timer
                if (S_Players.GetPlayerEquipment(attacker, Enums.EquipmentType.Weapon) > 0)
                {
                    if (S_General.GetTimeMs() < modTypes.TempPlayer[attacker].AttackTimer + Types.Item[S_Players.GetPlayerEquipment(attacker, Enums.EquipmentType.Weapon)].Speed)
                        return false;
                }
                else if (S_General.GetTimeMs() < modTypes.TempPlayer[attacker].AttackTimer + 1000)
                    return false;
            }

            // Check for subscript out of range
            if (!S_NetworkConfig.IsPlaying(victim))
                return false;

            if (!PetAlive(victim))
                return false;

            // Make sure they are on the same map
            if (!(S_Players.GetPlayerMap(attacker) == S_Players.GetPlayerMap(victim)))
                return false;

            // Make sure we dont attack the player if they are switching maps
            if (modTypes.TempPlayer[victim].GettingMap == 1)
                return false;

            if (isSkill == false)
            {

                // Check if at same coordinates
                switch (S_Players.GetPlayerDir(attacker))
                {
                    case (int)Enums.DirectionType.Up:
                        {
                            if (!((GetPetY(victim) + 1 == S_Players.GetPlayerY(attacker)) && (GetPetX(victim) == S_Players.GetPlayerX(attacker))))
                                return false;
                            break;
                        }

                    case (int)Enums.DirectionType.Down:
                        {
                            if (!((GetPetY(victim) - 1 == S_Players.GetPlayerY(attacker)) && (GetPetX(victim) == S_Players.GetPlayerX(attacker))))
                                return false;
                            break;
                        }

                    case (int)Enums.DirectionType.Left:
                        {
                            if (!((GetPetY(victim) == S_Players.GetPlayerY(attacker)) && (GetPetX(victim) + 1 == S_Players.GetPlayerX(attacker))))
                                return false;
                            break;
                        }

                    case (int)Enums.DirectionType.Right:
                        {
                            if (!((GetPetY(victim) == S_Players.GetPlayerY(attacker)) && (GetPetX(victim) - 1 == S_Players.GetPlayerX(attacker))))
                                return false;
                            break;
                        }

                    default:
                        {
                            return false;
                        }
                }
            }

            // Check if map is attackable
            if (!(modTypes.Map[S_Players.GetPlayerMap(attacker)].Moral == (byte)Enums.MapMoralType.None))
            {
                if (S_Players.GetPlayerPK(victim) == 0)
                {
                    S_NetworkSend.PlayerMsg(attacker, "This is a safe zone!", (int)Enums.ColorType.Yellow);
                    return false;
                }
            }

            // Make sure they have more then 0 hp
            if (GetPetVital(victim, Enums.VitalType.HP) <= 0)
                return false;

            // Check to make sure that they dont have access
            if (S_Players.GetPlayerAccess(attacker) > (int)Enums.AdminType.Monitor)
            {
                S_NetworkSend.PlayerMsg(attacker, "Admins cannot attack other players.", (int)Enums.ColorType.BrightRed);
                return false;
            }

            // Check to make sure the victim isn't an admin
            if (S_Players.GetPlayerAccess(victim) > (int)Enums.AdminType.Monitor)
            {
                S_NetworkSend.PlayerMsg(attacker, "You cannot attack " + S_Players.GetPlayerName(victim) + "s " + Microsoft.VisualBasic.Strings.Trim(GetPetName(victim)) + "!", (int)Enums.ColorType.BrightRed);
                return false;
            }

            // Don't attack a party member
            if (modTypes.TempPlayer[attacker].InParty > 0 && modTypes.TempPlayer[victim].InParty > 0)
            {
                if (modTypes.TempPlayer[attacker].InParty == modTypes.TempPlayer[victim].InParty)
                {
                    S_NetworkSend.PlayerMsg(attacker, "You can't attack another party member!", (int)Enums.ColorType.BrightRed);
                    return false;
                }
            }

            if (modTypes.TempPlayer[attacker].InParty > 0 && modTypes.TempPlayer[victim].InParty > 0 && modTypes.TempPlayer[attacker].InParty == modTypes.TempPlayer[victim].InParty)
            {
                if (Convert.ToInt32(isSkill) > 0)
                {
                    if (Types.Skill[Convert.ToInt32(isSkill)].Type == (byte)Enums.SkillType.HealMp || Types.Skill[Convert.ToInt32(isSkill)].Type == (byte)Enums.SkillType.HealHp)
                    {
                    }
                    else
                        return false;
                }
                else
                    return false;
            }

            return true;
        }

        public static void PlayerAttackPet(int attacker, int victim, int damage, int skillnum = 0)
        {
            int exp;
            int n;
            int i;

            // Check for subscript out of range

            if (S_NetworkConfig.IsPlaying(attacker) == false || S_NetworkConfig.IsPlaying(victim) == false || damage < 0 || !PetAlive(victim))
                return;
            // Check for weapon
            n = 0;

            if (S_Players.GetPlayerEquipment(attacker, Enums.EquipmentType.Weapon) > 0)
                n = S_Players.GetPlayerEquipment(attacker, Enums.EquipmentType.Weapon);

            // set the regen timer
            modTypes.TempPlayer[attacker].StopRegen = 1;
            modTypes.TempPlayer[attacker].StopRegenTimer = S_General.GetTimeMs();

            if (damage >= GetPetVital(victim, Enums.VitalType.HP))
            {
                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(victim), "-" + GetPetVital(victim, Enums.VitalType.HP), (int)Enums.ColorType.BrightRed, 1, (GetPetX(victim) * 32), (GetPetY(victim) * 32));

                // send the sound
                // If Spellnum > 0 Then SendMapSound Victim, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.x, Player(Victim).characters(TempPlayer(Victim).CurChar).Pet.y, SoundEntity.seSpell, Spellnum

                // Calculate exp to give attacker
                exp = (S_Players.GetPlayerExp(victim) / 10);

                // Make sure we dont get less then 0
                if (exp < 0)
                    exp = 0;

                if (exp == 0)
                {
                    S_NetworkSend.PlayerMsg(victim, "You lost no exp.", (int)Enums.ColorType.BrightGreen);
                    S_NetworkSend.PlayerMsg(attacker, "You received no exp.", (int)Enums.ColorType.Yellow);
                }
                else
                {
                    S_Players.SetPlayerExp(victim, S_Players.GetPlayerExp(victim) - exp);
                    S_NetworkSend.SendExp(victim);
                    S_NetworkSend.PlayerMsg(victim, "You lost " + exp + " exp.", (int)Enums.ColorType.BrightRed);

                    // check if we're in a party
                    if (modTypes.TempPlayer[attacker].InParty > 0)
                        // pass through party exp share function
                        S_Parties.Party_ShareExp(modTypes.TempPlayer[attacker].InParty, exp, attacker, S_Players.GetPlayerMap(attacker));
                    else
                        // not in party, get exp for self
                        S_Events.GivePlayerExp(attacker, exp);
                }

                var loopTo = S_GameLogic.GetPlayersOnline();

                // purge target info of anyone who targetted dead guy
                for (i = 1; i <= loopTo; i++)
                {
                    if (S_NetworkConfig.IsPlaying(i) && S_NetworkConfig.Socket.IsConnected(i) && S_Players.GetPlayerMap(i) == S_Players.GetPlayerMap(attacker))
                    {
                        if (modTypes.TempPlayer[i].Target == (int)Enums.TargetType.Pet && modTypes.TempPlayer[i].Target == victim)
                        {
                            modTypes.TempPlayer[i].Target = 0;
                            modTypes.TempPlayer[i].TargetType = (int)Enums.TargetType.None;
                            S_NetworkSend.SendTarget(i, 0, (byte)Enums.TargetType.None);
                        }
                    }
                }

                S_NetworkSend.PlayerMsg(victim, ("Your " + Microsoft.VisualBasic.Strings.Trim(GetPetName(victim)) + " was killed by  " + Microsoft.VisualBasic.Strings.Trim(S_Players.GetPlayerName(attacker)) + "."), (int)Enums.ColorType.BrightRed);
                ReCallPet(victim);
            }
            else
            {
                // Pet not dead, just do the damage
                SetPetVital(victim, Enums.VitalType.HP, GetPetVital(victim, Enums.VitalType.HP) - damage);
                SendPetVital(victim, Enums.VitalType.HP);

                // Set pet to begin attacking the other pet if it isn't dead or dosent have another target
                if (modTypes.TempPlayer[victim].PetTarget <= 0 && modTypes.TempPlayer[victim].PetBehavior != PetBehaviourGoto)
                {
                    modTypes.TempPlayer[victim].PetTarget = attacker;
                    modTypes.TempPlayer[victim].PetTargetType = (int)Enums.TargetType.Player;
                }

                // send the sound
                // If Spellnum > 0 Then SendMapSound Victim, GetPetX(Victim), GetPety(Victim), SoundEntity.seSpell, Spellnum

                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(victim), "-" + damage, (int)Enums.ColorType.BrightRed, 1, (GetPetX(victim) * 32), (GetPetY(victim) * 32));
                S_NetworkSend.SendBlood(S_Players.GetPlayerMap(victim), GetPetX(victim), GetPetY(victim));

                // set the regen timer
                modTypes.TempPlayer[victim].PetstopRegen = true;
                modTypes.TempPlayer[victim].PetstopRegenTimer = S_General.GetTimeMs();

                // if a stunning spell, stun the player
                if (skillnum > 0)
                {
                    if (Types.Skill[skillnum].StunDuration > 0)
                        StunPet(victim, skillnum);

                    // DoT
                    if (Types.Skill[skillnum].Duration > 0)
                        AddDoT_Pet(victim, skillnum, attacker, (byte)Enums.TargetType.Player);
                }
            }

            // Reset attack timer
            modTypes.TempPlayer[attacker].AttackTimer = S_General.GetTimeMs();
        }

        internal static void TryPlayerAttackPet(int attacker, int victim)
        {
            int blockAmount;
            int mapNum;
            int damage;

            damage = 0;

            if (!PetAlive(victim))
                return;

            // Can we attack the npc?
            if (CanPlayerAttackPet(attacker, victim))
            {
                mapNum = S_Players.GetPlayerMap(attacker);

                modTypes.TempPlayer[attacker].Target = victim;
                modTypes.TempPlayer[attacker].TargetType = (int)Enums.TargetType.Pet;

                // check if NPC can avoid the attack
                if (CanPetDodge(victim))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Dodge!", (int)Enums.ColorType.Pink, 1, (S_Players.GetPlayerX(victim) * 32), (S_Players.GetPlayerY(victim) * 32));
                    return;
                }

                if (CanPetParry(victim))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Parry!", (int)Enums.ColorType.Pink, 1, (S_Players.GetPlayerX(victim) * 32), (S_Players.GetPlayerY(victim) * 32));
                    return;
                }

                // Get the damage we can do
                damage = S_Players.GetPlayerDamage(attacker);

                // if the npc blocks, take away the block amount
                blockAmount = 0;
                damage = damage - blockAmount;

                // take away armour
                damage = damage - S_GameLogic.Random(1, (S_Players.GetPlayerStat(victim, Enums.StatType.Luck) * 2));

                // randomise for up to 10% lower than max hit
                damage = S_GameLogic.Random(1, damage);

                // * 1.5 if can crit
                if (S_Players.CanPlayerCriticalHit(attacker))
                {
                    damage = (int)(damage * 1.5);
                    S_NetworkSend.SendActionMsg(mapNum, "Critical!", (int)Enums.ColorType.BrightCyan, 1, (S_Players.GetPlayerX(attacker) * 32), (S_Players.GetPlayerY(attacker) * 32));
                }

                if (damage > 0)
                    PlayerAttackPet(attacker, victim, damage);
                else
                    S_NetworkSend.PlayerMsg(attacker, "Your attack does nothing.", (int)Enums.ColorType.BrightRed);
            }
        }



        internal static bool PetAlive(int index)
        {
            bool PetAlive = false;

            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Alive == 1)
                PetAlive = true;
            return PetAlive;
        }

        internal static string GetPetName(int index)
        {
            string GetPetName = "";

            if (PetAlive(index))
                GetPetName = Pet[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Num].Name;
            return GetPetName;
        }

        internal static int GetPetNum(int index)
        {
            int GetPetNum = 0;

            GetPetNum = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Num;
            return GetPetNum;
        }

        internal static int GetPetRange(int index)
        {
            int GetPetRange = 0;

            if (PetAlive(index))
                GetPetRange = Pet[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Num].Range;
            return GetPetRange;
        }

        internal static int GetPetLevel(int index)
        {
            int GetPetLevel = 0;

            if (PetAlive(index))
                GetPetLevel = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Level;
            return GetPetLevel;
        }

        internal static void SetPetLevel(int index, int newlvl)
        {
            if (PetAlive(index))
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Level = newlvl;
        }

        internal static int GetPetX(int index)
        {
            int GetPetX = 0;

            if (PetAlive(index))
                GetPetX = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.X;
            return GetPetX;
        }

        internal static void SetPetX(int index, int x)
        {
            if (PetAlive(index))
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.X = x;
        }

        internal static int GetPetY(int index)
        {
            int GetPetY = 0;

            if (PetAlive(index))
                GetPetY = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Y;
            return GetPetY;
        }

        internal static void SetPetY(int index, int y)
        {
            if (PetAlive(index))
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Y = y;
        }

        internal static int GetPetDir(int index)
        {
            int GetPetDir = 0;

            if (PetAlive(index))
                GetPetDir = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Dir;
            return GetPetDir;
        }

        internal static int GetPetBehaviour(int index)
        {
            int GetPetBehaviour = 0;

            if (PetAlive(index))
                GetPetBehaviour = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.AttackBehaviour;
            return GetPetBehaviour;
        }

        internal static void SetPetBehaviour(int index, byte behaviour)
        {
            if (PetAlive(index))
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.AttackBehaviour = behaviour;
        }

        internal static int GetPetStat(int index, Enums.StatType stat)
        {
            int GetPetStat = 0;

            if (PetAlive(index))
                GetPetStat = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Stat[(int)stat];
            return GetPetStat;
        }

        internal static void SetPetStat(int index, Enums.StatType stat, int amount)
        {
            if (PetAlive(index))
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Stat[(int)stat] = amount;
        }

        internal static int GetPetPoints(int index)
        {
            int GetPetPoints = 0;

            if (PetAlive(index))
                GetPetPoints = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Points;
            return GetPetPoints;
        }

        internal static void SetPetPoints(int index, int amount)
        {
            if (PetAlive(index))
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Points = amount;
        }

        internal static int GetPetExp(int index)
        {
            int GetPetExp = 0;

            if (PetAlive(index))
                GetPetExp = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Exp;
            return GetPetExp;
        }

        internal static void SetPetExp(int index, int amount)
        {
            if (PetAlive(index))
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Exp = amount;
        }

        public static int GetPetVital(int index, Enums.VitalType vital)
        {
            int GetPetVital = 0;
            if (index > Constants.MAX_PLAYERS)
                return 0;

            switch (vital)
            {
                case Enums.VitalType.HP:
                    {
                        GetPetVital = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Health;
                        break;
                    }

                case Enums.VitalType.MP:
                    {
                        GetPetVital = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Mana;
                        break;
                    }
            }
            return GetPetVital;
        }

        public static void SetPetVital(int index, Enums.VitalType vital, int amount)
        {
            if (index > Constants.MAX_PLAYERS)
                return;

            switch (vital)
            {
                case Enums.VitalType.HP:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Health = amount;
                        break;
                    }

                case Enums.VitalType.MP:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Mana = amount;
                        break;
                    }
            }
        }

        public static int GetPetMaxVital(int index, Enums.VitalType vital)
        {
            int GetPetMaxVital = 0;
            if (index > Constants.MAX_PLAYERS)
                return 0;

            switch (vital)
            {
                case Enums.VitalType.HP:
                    {
                        GetPetMaxVital = ((modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Level * 4) + (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Stat[(int)Enums.StatType.Endurance] * 10)) + 150;
                        break;
                    }

                case Enums.VitalType.MP:
                    {
                        GetPetMaxVital = ((modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Level * 4) + (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Stat[(int)Enums.StatType.Spirit] / (int)2)) * 5 + 50;
                        break;
                    }
            }
            return GetPetMaxVital;
        }

        public static int GetPetNextLevel(int index)
        {
            int GetPetNextLevel = 0;
            if (PetAlive(index))
            {
                if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Level == Pet[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Num].MaxLevel)
                {
                    return 0;
                }
                GetPetNextLevel = (int)((50 / (int)3) * (Math.Pow((modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Level + 1), 3) - (6 * Math.Pow((modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Level + 1), 2)) + 17 * (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pet.Level + 1) - 12));
            }
            return GetPetNextLevel;
        }
    }
}
