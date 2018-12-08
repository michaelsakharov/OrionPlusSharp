using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using ASFW;
using ASFW.IO.FileIO;
using static Engine.Types;

namespace Engine
{
    internal static class S_Resources
    {
        internal static int[] SkillExpTable = new int[101];
        internal static ResourceCacheRec[] ResourceCache = new ResourceCacheRec[601];

        internal struct MapResourceRec
        {
            public byte ResourceState;
            public int ResourceTimer;
            public int X;
            public int Y;
            public byte CurHealth;
        }

        internal struct ResourceCacheRec
        {
            public int ResourceCount;
            public MapResourceRec[] ResourceData;
        }



        public static void SaveResources()
        {
            int i;

            for (i = 1; i <= Constants.MAX_RESOURCES; i++)
                SaveResource(i);
        }

        public static void SaveResource(int ResourceNum)
        {
            string filename;

            filename = Path.Combine(Application.StartupPath, "data", "resources", string.Format("resource{0}.dat", ResourceNum));

            ByteStream writer = new ByteStream(100);

            writer.WriteString(Types.Resource[ResourceNum].Name);
            writer.WriteString(Types.Resource[ResourceNum].SuccessMessage);
            writer.WriteString(Types.Resource[ResourceNum].EmptyMessage);
            writer.WriteInt32(Types.Resource[ResourceNum].ResourceType);
            writer.WriteInt32(Types.Resource[ResourceNum].ResourceImage);
            writer.WriteInt32(Types.Resource[ResourceNum].ExhaustedImage);
            writer.WriteInt32(Types.Resource[ResourceNum].ExpReward);
            writer.WriteInt32(Types.Resource[ResourceNum].ItemReward);
            writer.WriteInt32(Types.Resource[ResourceNum].LvlRequired);
            writer.WriteInt32(Types.Resource[ResourceNum].ToolRequired);
            writer.WriteInt32(Types.Resource[ResourceNum].Health);
            writer.WriteInt32(Types.Resource[ResourceNum].RespawnTime);
            writer.WriteBoolean(Types.Resource[ResourceNum].Walkthrough);
            writer.WriteInt32(Types.Resource[ResourceNum].Animation);

            BinaryFile.Save(filename, ref writer);
        }

        public static void LoadResources()
        {
            int i;

            CheckResources();

            for (i = 1; i <= Constants.MAX_RESOURCES; i++)
            {
                LoadResource(i);
                Application.DoEvents();
            }
        }

        public static void LoadResource(int ResourceNum)
        {
            string filename;

            filename = Path.Combine(Application.StartupPath, "data", "resources", string.Format("resource{0}.dat", ResourceNum));
            ByteStream reader = new ByteStream();
            BinaryFile.Load(filename, ref reader);

            Types.Resource[ResourceNum].Name = reader.ReadString();
            Types.Resource[ResourceNum].SuccessMessage = reader.ReadString();
            Types.Resource[ResourceNum].EmptyMessage = reader.ReadString();
            Types.Resource[ResourceNum].ResourceType = reader.ReadInt32();
            Types.Resource[ResourceNum].ResourceImage = reader.ReadInt32();
            Types.Resource[ResourceNum].ExhaustedImage = reader.ReadInt32();
            Types.Resource[ResourceNum].ExpReward = reader.ReadInt32();
            Types.Resource[ResourceNum].ItemReward = reader.ReadInt32();
            Types.Resource[ResourceNum].LvlRequired = reader.ReadInt32();
            Types.Resource[ResourceNum].ToolRequired = reader.ReadInt32();
            Types.Resource[ResourceNum].Health = reader.ReadInt32();
            Types.Resource[ResourceNum].RespawnTime = reader.ReadInt32();
            Types.Resource[ResourceNum].Walkthrough = reader.ReadBoolean();
            Types.Resource[ResourceNum].Animation = reader.ReadInt32();

            if (Types.Resource[ResourceNum].Name == null)
                Types.Resource[ResourceNum].Name = "";
            if (Types.Resource[ResourceNum].EmptyMessage == null)
                Types.Resource[ResourceNum].EmptyMessage = "";
            if (Types.Resource[ResourceNum].SuccessMessage == null)
                Types.Resource[ResourceNum].SuccessMessage = "";
        }

        public static void CheckResources()
        {
            for (var i = 1; i <= Constants.MAX_RESOURCES; i++)
            {
                if (!File.Exists(Path.Combine(Application.StartupPath, "data", "resources", string.Format("resource{0}.dat", i))))
                    SaveResource(i);
            }
        }

        public static void ClearResource(int index)
        {
            Types.Resource[index] = default(ResourceRec);
            Types.Resource[index].Name = "";
            Types.Resource[index].EmptyMessage = "";
            Types.Resource[index].SuccessMessage = "";
        }

        public static void ClearResources()
        {
            for (var i = 1; i <= Constants.MAX_RESOURCES; i++)
                ClearResource(i);
        }

        internal static void CacheResources(int mapNum)
        {
            int x;
            int y;
            int Resource_Count;
            Resource_Count = 0;
            var loopTo = modTypes.Map[mapNum].MaxX;
            for (x = 0; x <= loopTo; x++)
            {
                var loopTo1 = modTypes.Map[mapNum].MaxY;
                for (y = 0; y <= loopTo1; y++)
                {
                    if (modTypes.Map[mapNum].Tile[x, y].Type == (byte)Enums.TileType.Resource)
                    {
                        Resource_Count = Resource_Count + 1;
                        var oldResourceData = ResourceCache[mapNum].ResourceData;
                        ResourceCache[mapNum].ResourceData = new MapResourceRec[Resource_Count + 1];
                        if (oldResourceData != null)
                            Array.Copy(oldResourceData, ResourceCache[mapNum].ResourceData, Math.Min(Resource_Count + 1, oldResourceData.Length));
                        ResourceCache[mapNum].ResourceData[Resource_Count].X = x;
                        ResourceCache[mapNum].ResourceData[Resource_Count].Y = y;
                        ResourceCache[mapNum].ResourceData[Resource_Count].CurHealth = (byte)Types.Resource[modTypes.Map[mapNum].Tile[x, y].Data1].Health;
                    }
                }
            }

            ResourceCache[mapNum].ResourceCount = Resource_Count;
        }

        public static byte[] ResourcesData()
        {
            ByteStream buffer = new ByteStream(4);
            for (var i = 1; i <= Constants.MAX_RESOURCES; i++)
            {
                if (!(Types.Resource[i].Name.Trim().Length > 0))
                    continue;
                buffer.WriteBlock(ResourceData(i));
            }
            return buffer.ToArray();
        }

        public static byte[] ResourceData(int ResourceNum)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32(ResourceNum);
            buffer.WriteInt32(Types.Resource[ResourceNum].Animation);
            buffer.WriteString((Types.Resource[ResourceNum].EmptyMessage));
            buffer.WriteInt32(Types.Resource[ResourceNum].ExhaustedImage);
            buffer.WriteInt32(Types.Resource[ResourceNum].Health);
            buffer.WriteInt32(Types.Resource[ResourceNum].ExpReward);
            buffer.WriteInt32(Types.Resource[ResourceNum].ItemReward);
            buffer.WriteString((Types.Resource[ResourceNum].Name));
            buffer.WriteInt32(Types.Resource[ResourceNum].ResourceImage);
            buffer.WriteInt32(Types.Resource[ResourceNum].ResourceType);
            buffer.WriteInt32(Types.Resource[ResourceNum].RespawnTime);
            buffer.WriteString((Types.Resource[ResourceNum].SuccessMessage));
            buffer.WriteInt32(Types.Resource[ResourceNum].LvlRequired);
            buffer.WriteInt32(Types.Resource[ResourceNum].ToolRequired);
            buffer.WriteInt32(Convert.ToInt32(Types.Resource[ResourceNum].Walkthrough));
            return buffer.ToArray();
        }

        public static void LoadSkillExp()
        {
            XmlClass myXml = new XmlClass()
            {
                Filename = Application.StartupPath + @"\Data\SkillExp.xml",
                Root = "Data"
            };

            myXml.LoadXml();

            for (int i = 1; i <= 100; i++)
                SkillExpTable[i] = Convert.ToInt32(myXml.ReadString("Level", i.ToString()));

            myXml.CloseXml(false);
        }



        public static int GetPlayerGatherSkillLvl(int index, int SkillSlot)
        {
            int GetPlayerGatherSkillLvl = 0;

            if (index > Constants.MAX_PLAYERS)
                return 0;

            GetPlayerGatherSkillLvl = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].GatherSkills[SkillSlot].SkillLevel;
            return GetPlayerGatherSkillLvl;
        }

        public static int GetPlayerGatherSkillExp(int index, int SkillSlot)
        {
            int GetPlayerGatherSkillExp = 0;

            if (index > Constants.MAX_PLAYERS)
                return 0;

            GetPlayerGatherSkillExp = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].GatherSkills[SkillSlot].SkillCurExp;
            return GetPlayerGatherSkillExp;
        }

        public static int GetPlayerGatherSkillMaxExp(int index, int SkillSlot)
        {
            int GetPlayerGatherSkillMaxExp = 0;

            if (index > Constants.MAX_PLAYERS)
                return 0;

            GetPlayerGatherSkillMaxExp = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].GatherSkills[SkillSlot].SkillNextLvlExp;
            return GetPlayerGatherSkillMaxExp;
        }

        public static void SetPlayerGatherSkillLvl(int index, int SkillSlot, int lvl)
        {
            if (index > Constants.MAX_PLAYERS)
                return;

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].GatherSkills[SkillSlot].SkillLevel = lvl;
        }

        public static void SetPlayerGatherSkillExp(int index, int SkillSlot, int Exp)
        {
            if (index > Constants.MAX_PLAYERS)
                return;

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].GatherSkills[SkillSlot].SkillCurExp = Exp;
        }

        public static void SetPlayerGatherSkillMaxExp(int index, int SkillSlot, int MaxExp)
        {
            if (index > Constants.MAX_PLAYERS)
                return;

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].GatherSkills[SkillSlot].SkillNextLvlExp = MaxExp;
        }

        public static void CheckResourceLevelUp(int index, int SkillSlot)
        {

            if (GetPlayerGatherSkillLvl(index, SkillSlot) == 100)
                return;

            int expRollover;
            //string skillname = "";
            int level_count;

            level_count = 0;

            while (GetPlayerGatherSkillExp(index, SkillSlot) >= GetPlayerGatherSkillMaxExp(index, SkillSlot))
            {
                expRollover = GetPlayerGatherSkillExp(index, SkillSlot) - GetPlayerGatherSkillMaxExp(index, SkillSlot);
                SetPlayerGatherSkillLvl(index, SkillSlot, GetPlayerGatherSkillLvl(index, SkillSlot) + 1);
                SetPlayerGatherSkillExp(index, SkillSlot, expRollover);
                SetPlayerGatherSkillMaxExp(index, SkillSlot, GetSkillNextLevel(index, SkillSlot));
                level_count = level_count + 1;
            }

            if (level_count > 0)
            {
                if (level_count == 1)
                    // singular
                    S_NetworkSend.PlayerMsg(index, string.Format("Your {0} has gone up a level!", GetResourceSkillName((Enums.ResourceSkills)SkillSlot)), (int)Enums.ColorType.BrightGreen);
                else
                    // plural
                    S_NetworkSend.PlayerMsg(index, string.Format("Your {0} has gone up by {1} levels!", GetResourceSkillName((Enums.ResourceSkills)SkillSlot), level_count), (int)Enums.ColorType.BrightGreen);

                modDatabase.SavePlayer(index);
                S_NetworkSend.SendPlayerData(index);
            }
        }

        private static string GetResourceSkillName(Enums.ResourceSkills ResSkill)
        {
            string GetResourceSkillName;
            switch (ResSkill)
            {
                case Enums.ResourceSkills.Herbalist:
                    {
                        GetResourceSkillName = "herbalism";
                        break;
                    }

                case Enums.ResourceSkills.WoodCutter:
                    {
                        GetResourceSkillName = "woodcutting";
                        break;
                    }

                case Enums.ResourceSkills.Miner:
                    {
                        GetResourceSkillName = "mining";
                        break;
                    }

                case Enums.ResourceSkills.Fisherman:
                    {
                        GetResourceSkillName = "fishing";
                        break;
                    }

                default:
                    {
                        throw new NotImplementedException();
                    }
                    
            }
            return GetResourceSkillName;
        }

        public static int GetSkillNextLevel(int index, int SkillSlot)
        {
            int GetSkillNextLevel = 0;
            bool flag = index < 0 || index > 70;
            if (!flag)
            {
                GetSkillNextLevel = S_Resources.SkillExpTable[checked(S_Resources.GetPlayerGatherSkillLvl(index, SkillSlot) + 1)];
            }
            return GetSkillNextLevel;
        }



        public static void Packet_EditResource(int index, ref byte[] data)
        {
            ByteStream Buffer = new ByteStream(4);

            S_General.AddDebug("Recieved EMSG: RequestEditResource");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (int)Enums.AdminType.Developer)
                return;

            Buffer.WriteInt32((int)Packets.ServerPackets.SResourceEditor);
            S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);

            S_General.AddDebug("Sent SMSG: SResourceEditor");

            Buffer.Dispose();
        }

        public static void Packet_SaveResource(int index, ref byte[] data)
        {
            int resourcenum;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved EMSG: SaveResource");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (int)Enums.AdminType.Developer)
                return;

            resourcenum = buffer.ReadInt32();

            // Prevent hacking
            if (resourcenum <= 0 || resourcenum > Constants.MAX_RESOURCES)
                return;

            Types.Resource[resourcenum].Animation = buffer.ReadInt32();
            Types.Resource[resourcenum].EmptyMessage = buffer.ReadString();
            Types.Resource[resourcenum].ExhaustedImage = buffer.ReadInt32();
            Types.Resource[resourcenum].Health = buffer.ReadInt32();
            Types.Resource[resourcenum].ExpReward = buffer.ReadInt32();
            Types.Resource[resourcenum].ItemReward = buffer.ReadInt32();
            Types.Resource[resourcenum].Name = buffer.ReadString();
            Types.Resource[resourcenum].ResourceImage = buffer.ReadInt32();
            Types.Resource[resourcenum].ResourceType = buffer.ReadInt32();
            Types.Resource[resourcenum].RespawnTime = buffer.ReadInt32();
            Types.Resource[resourcenum].SuccessMessage = buffer.ReadString();
            Types.Resource[resourcenum].LvlRequired = buffer.ReadInt32();
            Types.Resource[resourcenum].ToolRequired = buffer.ReadInt32();
            Types.Resource[resourcenum].Walkthrough = Convert.ToBoolean(buffer.ReadInt32());

            // Save it
            SendUpdateResourceToAll(resourcenum);
            SaveResource(resourcenum);

            modDatabase.Addlog(S_Players.GetPlayerLogin(index) + " saved Resource #" + resourcenum + ".", S_Constants.ADMIN_LOG);

            buffer.Dispose();
        }

        public static void Packet_RequestResources(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CRequestResources");

            SendResources(index);
        }



        public static void SendResourceCacheTo(int index, int Resource_num)
        {
            int i;
            int mapnum;
            ByteStream buffer = new ByteStream(4);

            mapnum = S_Players.GetPlayerMap(index);

            buffer.WriteInt32((int)Packets.ServerPackets.SResourceCache);
            buffer.WriteInt32(ResourceCache[mapnum].ResourceCount);

            S_General.AddDebug("Sent SMSG: SResourcesCache");

            if (ResourceCache[mapnum].ResourceCount > 0)
            {
                var loopTo = ResourceCache[mapnum].ResourceCount;
                for (i = 0; i <= loopTo; i++)
                {
                    buffer.WriteInt32(ResourceCache[mapnum].ResourceData[i].ResourceState);
                    buffer.WriteInt32(ResourceCache[mapnum].ResourceData[i].X);
                    buffer.WriteInt32(ResourceCache[mapnum].ResourceData[i].Y);
                }
            }

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendResourceCacheToMap(int mapNum, int Resource_num)
        {
            int i;
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SResourceCache);
            buffer.WriteInt32(ResourceCache[mapNum].ResourceCount);

            S_General.AddDebug("Sent SMSG: SResourceCache");

            if (ResourceCache[mapNum].ResourceCount > 0)
            {
                var loopTo = ResourceCache[mapNum].ResourceCount;
                for (i = 0; i <= loopTo; i++)
                {
                    buffer.WriteInt32(ResourceCache[mapNum].ResourceData[i].ResourceState);
                    buffer.WriteInt32(ResourceCache[mapNum].ResourceData[i].X);
                    buffer.WriteInt32(ResourceCache[mapNum].ResourceData[i].Y);
                }
            }

            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendResources(int index)
        {
            int i;

            for (i = 1; i <= Constants.MAX_RESOURCES; i++)
            {
                if (Types.Resource[i].Name.Trim().Length > 0)
                    SendUpdateResourceTo(index, i);
            }
        }

        public static void SendUpdateResourceTo(int index, int ResourceNum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SUpdateResource);

            buffer.WriteBlock(ResourceData(ResourceNum));

            S_General.AddDebug("Sent SMSG: SUpdateResources");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendUpdateResourceToAll(int ResourceNum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SUpdateResource);

            buffer.WriteBlock(ResourceData(ResourceNum));

            S_General.AddDebug("Sent SMSG: SUpdateResource");

            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }



        public static void CheckResource(int index, int x, int y)
        {
            int Resource_num;
            byte ResourceType;
            int Resource_index;
            int rX;
            int rY;
            int Damage;

            if (modTypes.Map[S_Players.GetPlayerMap(index)].Tile[x, y].Type == (byte)Enums.TileType.Resource)
            {
                Resource_num = 0;
                Resource_index = modTypes.Map[S_Players.GetPlayerMap(index)].Tile[x, y].Data1;
                ResourceType = (byte)Types.Resource[Resource_index].ResourceType;
                var loopTo = ResourceCache[S_Players.GetPlayerMap(index)].ResourceCount;

                // Get the cache number
                for (var i = 0; i <= loopTo; i++)
                {
                    if (ResourceCache[S_Players.GetPlayerMap(index)].ResourceData[i].X == x)
                    {
                        if (ResourceCache[S_Players.GetPlayerMap(index)].ResourceData[i].Y == y)
                            Resource_num = i;
                    }
                }

                if (Resource_num > 0)
                {
                    if (S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Weapon) > 0 || Types.Resource[Resource_index].ToolRequired == 0)
                    {
                        if (Types.Item[S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Weapon)].Data3 == Types.Resource[Resource_index].ToolRequired)
                        {

                            // inv space?
                            if (Types.Resource[Resource_index].ItemReward > 0)
                            {
                                if (S_Players.FindOpenInvSlot(index, Types.Resource[Resource_index].ItemReward) == 0)
                                {
                                    S_NetworkSend.PlayerMsg(index, "You have no inventory space.", (int)Enums.ColorType.Yellow);
                                    return;
                                }
                            }

                            // required lvl?
                            if (Types.Resource[Resource_index].LvlRequired > GetPlayerGatherSkillLvl(index, ResourceType))
                            {
                                S_NetworkSend.PlayerMsg(index, "Your level is too low!", (int)Enums.ColorType.Yellow);
                                return;
                            }

                            // check if already cut down
                            if (ResourceCache[S_Players.GetPlayerMap(index)].ResourceData[Resource_num].ResourceState == 0)
                            {
                                rX = ResourceCache[S_Players.GetPlayerMap(index)].ResourceData[Resource_num].X;
                                rY = ResourceCache[S_Players.GetPlayerMap(index)].ResourceData[Resource_num].Y;

                                if (Types.Resource[Resource_index].ToolRequired == 0)
                                    Damage = 1 * GetPlayerGatherSkillLvl(index, ResourceType);
                                else
                                    Damage = Types.Item[S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Weapon)].Data2;

                                // check if damage is more than health
                                if (Damage > 0)
                                {
                                    // cut it down!
                                    if (ResourceCache[S_Players.GetPlayerMap(index)].ResourceData[Resource_num].CurHealth - Damage <= 0)
                                    {
                                        ResourceCache[S_Players.GetPlayerMap(index)].ResourceData[Resource_num].ResourceState = 1; // Cut
                                        ResourceCache[S_Players.GetPlayerMap(index)].ResourceData[Resource_num].ResourceTimer = S_General.GetTimeMs();
                                        SendResourceCacheToMap(S_Players.GetPlayerMap(index), Resource_num);
                                        S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(index), Types.Resource[Resource_index].SuccessMessage.Trim(), (int)Enums.ColorType.BrightGreen, 1, (S_Players.GetPlayerX(index) * 32), (S_Players.GetPlayerY(index) * 32));
                                        S_Players.GiveInvItem(index, Types.Resource[Resource_index].ItemReward, 1);
                                        S_Animations.SendAnimation(S_Players.GetPlayerMap(index), Types.Resource[Resource_index].Animation, rX, rY);
                                        SetPlayerGatherSkillExp(index, ResourceType, GetPlayerGatherSkillExp(index, ResourceType) + Types.Resource[Resource_index].ExpReward);
                                        // send msg
                                        S_NetworkSend.PlayerMsg(index, string.Format("Your {0} has earned {1} experience. ({2}/{3})", GetResourceSkillName((Enums.ResourceSkills)ResourceType), Types.Resource[Resource_index].ExpReward, GetPlayerGatherSkillExp(index, ResourceType), GetPlayerGatherSkillMaxExp(index, ResourceType)), (int)Enums.ColorType.BrightGreen);
                                        S_NetworkSend.SendPlayerData(index);

                                        CheckResourceLevelUp(index, ResourceType);
                                    }
                                    else
                                    {
                                        // just do the damage
                                        ResourceCache[S_Players.GetPlayerMap(index)].ResourceData[Resource_num].CurHealth = (byte)(ResourceCache[S_Players.GetPlayerMap(index)].ResourceData[Resource_num].CurHealth - Damage);
                                        S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(index), "-" + Damage, (int)Enums.ColorType.BrightRed, 1, (rX * 32), (rY * 32));
                                        S_Animations.SendAnimation(S_Players.GetPlayerMap(index), Types.Resource[Resource_index].Animation, rX, rY);
                                    }
                                    S_Quest.CheckTasks(index, (int)Enums.QuestType.Gather, Resource_index);
                                }
                                else
                                    // too weak
                                    S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(index), "Miss!", (int)Enums.ColorType.BrightRed, 1, (rX * 32), (rY * 32));
                            }
                            else
                                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(index), Types.Resource[Resource_index].EmptyMessage.Trim(), (int)Enums.ColorType.BrightRed, 1, (S_Players.GetPlayerX(index) * 32), (S_Players.GetPlayerY(index) * 32));
                        }
                        else
                            S_NetworkSend.PlayerMsg(index, "You have the wrong type of tool equiped.", (int)Enums.ColorType.Yellow);
                    }
                    else
                        S_NetworkSend.PlayerMsg(index, "You need a tool to gather this resource.", (int)Enums.ColorType.Yellow);
                }
            }
        }
    }
}
