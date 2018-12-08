using System;
using System.IO;
using System.Windows.Forms;
using ASFW;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Engine
{
    // Token: 0x0200001B RID: 27
    [StandardModule]
    internal sealed class S_Housing
    {
        // Token: 0x060001D7 RID: 471 RVA: 0x00039760 File Offset: 0x00037960
        public static void CreateHouses()
        {
            XmlClass myXml = new XmlClass
            {
                Filename = Path.Combine(Application.StartupPath, "data", "houseconfig.xml"),
                Root = "Config"
            };
            myXml.NewXmlDocument();
            myXml.LoadXml();
            myXml.WriteString("House" + Conversions.ToString(1), "BaseMap", Conversions.ToString(S_Housing.HouseConfig[1].BaseMap));
            myXml.WriteString("House" + Conversions.ToString(1), "Name", S_Housing.HouseConfig[1].ConfigName);
            myXml.WriteString("House" + Conversions.ToString(1), "MaxFurniture", Conversions.ToString(S_Housing.HouseConfig[1].MaxFurniture));
            myXml.WriteString("House" + Conversions.ToString(1), "Price", Conversions.ToString(S_Housing.HouseConfig[1].Price));
            myXml.WriteString("House" + Conversions.ToString(1), "X", Conversions.ToString(S_Housing.HouseConfig[1].X));
            myXml.WriteString("House" + Conversions.ToString(1), "Y", Conversions.ToString(S_Housing.HouseConfig[1].Y));
            myXml.CloseXml(true);
        }

        // Token: 0x060001D8 RID: 472 RVA: 0x000398D4 File Offset: 0x00037AD4
        public static void LoadHouses()
        {
            bool flag = !File.Exists(Path.Combine(Application.StartupPath, "data", "houseconfig.xml"));
            if (flag)
            {
                S_Housing.CreateHouses();
            }
            XmlClass myXml = new XmlClass
            {
                Filename = Path.Combine(Application.StartupPath, "data", "houseconfig.xml"),
                Root = "Config"
            };
            myXml.LoadXml();
            int max_HOUSES = S_Housing.MAX_HOUSES;
            checked
            {
                for (int i = 1; i <= max_HOUSES; i++)
                {
                    S_Housing.HouseConfig[i].BaseMap = (int)Math.Round(Conversion.Val(myXml.ReadString("House" + Conversions.ToString(i), "BaseMap", "")));
                    S_Housing.HouseConfig[i].ConfigName = (myXml.ReadString("House" + Conversions.ToString(i), "Name", "").Trim());
                    S_Housing.HouseConfig[i].MaxFurniture = (int)Math.Round(Conversion.Val(myXml.ReadString("House" + Conversions.ToString(i), "MaxFurniture", "")));
                    S_Housing.HouseConfig[i].Price = (int)Math.Round(Conversion.Val(myXml.ReadString("House" + Conversions.ToString(i), "Price", "")));
                    S_Housing.HouseConfig[i].X = (int)Math.Round(Conversion.Val(myXml.ReadString("House" + Conversions.ToString(i), "X", "")));
                    S_Housing.HouseConfig[i].Y = (int)Math.Round(Conversion.Val(myXml.ReadString("House" + Conversions.ToString(i), "Y", "")));
                }
                myXml.CloseXml(false);
                int playersOnline = S_GameLogic.GetPlayersOnline();
                for (int i = 1; i <= playersOnline; i++)
                {
                    bool flag2 = S_NetworkConfig.IsPlaying(i);
                    if (flag2)
                    {
                        S_Housing.SendHouseConfigs(i);
                    }
                }
            }
        }

        // Token: 0x060001D9 RID: 473 RVA: 0x00039AE4 File Offset: 0x00037CE4
        public static void SaveHouse(int index)
        {
            XmlClass myXml = new XmlClass
            {
                Filename = Path.Combine(Application.StartupPath, "data", "houseconfig.xml"),
                Root = "Config"
            };
            myXml.LoadXml();
            bool flag = index > 0 && index <= S_Housing.MAX_HOUSES;
            if (flag)
            {
                myXml.WriteString("House" + Conversions.ToString(index), "BaseMap", Conversions.ToString(S_Housing.HouseConfig[index].BaseMap));
                myXml.WriteString("House" + Conversions.ToString(index), "Name", S_Housing.HouseConfig[index].ConfigName);
                myXml.WriteString("House" + Conversions.ToString(index), "MaxFurniture", Conversions.ToString(S_Housing.HouseConfig[index].MaxFurniture));
                myXml.WriteString("House" + Conversions.ToString(index), "Price", Conversions.ToString(S_Housing.HouseConfig[index].Price));
                myXml.WriteString("House" + Conversions.ToString(index), "X", Conversions.ToString(S_Housing.HouseConfig[index].X));
                myXml.WriteString("House" + Conversions.ToString(index), "Y", Conversions.ToString(S_Housing.HouseConfig[index].Y));
            }
            myXml.CloseXml(true);
            S_Housing.LoadHouses();
        }

        // Token: 0x060001DA RID: 474 RVA: 0x00039C70 File Offset: 0x00037E70
        public static void SaveHouses()
        {
            int max_HOUSES = S_Housing.MAX_HOUSES;
            checked
            {
                for (int i = 1; i <= max_HOUSES; i++)
                {
                    S_Housing.SaveHouse(i);
                }
            }
        }

        // Token: 0x060001DB RID: 475 RVA: 0x00039C98 File Offset: 0x00037E98
        public static void Packet_BuyHouse(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            int i = buffer.ReadInt32();
            bool flag = i == 1;
            if (flag)
            {
                bool flag2 = modTypes.TempPlayer[index].BuyHouseindex > 0;
                if (flag2)
                {
                    int price = S_Housing.HouseConfig[modTypes.TempPlayer[index].BuyHouseindex].Price;
                    bool flag3 = S_Players.HasItem(index, 1) >= price;
                    if (flag3)
                    {
                        S_Players.TakeInvItem(index, 1, price);
                        modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Houseindex = modTypes.TempPlayer[index].BuyHouseindex;
                        S_NetworkSend.PlayerMsg(index, "You just bought the " + (S_Housing.HouseConfig[modTypes.TempPlayer[index].BuyHouseindex].ConfigName.Trim()) + " house!", 10);
                        modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].LastMap = S_Players.GetPlayerMap(index);
                        modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].LastX = S_Players.GetPlayerX(index);
                        modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].LastY = S_Players.GetPlayerY(index);
                        modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse = index;
                        S_Players.PlayerWarp(index, S_Housing.HouseConfig[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Houseindex].BaseMap, S_Housing.HouseConfig[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Houseindex].X, S_Housing.HouseConfig[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Houseindex].Y, true, false);
                        modDatabase.SavePlayer(index);
                    }
                    else
                    {
                        S_NetworkSend.PlayerMsg(index, "You cannot afford this house!", 12);
                    }
                }
            }
            modTypes.TempPlayer[index].BuyHouseindex = 0;
            buffer.Dispose();
        }

        // Token: 0x060001DC RID: 476 RVA: 0x00039F50 File Offset: 0x00038150
        public static void Packet_InviteToHouse(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            string Name = (buffer.ReadString().Trim());
            int invitee = S_GameLogic.FindPlayer(Name);
            buffer.Dispose();
            bool flag = invitee == 0;
            if (flag)
            {
                S_NetworkSend.PlayerMsg(index, "Player not found.", 12);
            }
            else
            {
                bool flag2 = index == invitee;
                if (flag2)
                {
                    S_NetworkSend.PlayerMsg(index, "You cannot invite yourself to you own house!", 12);
                }
                else
                {
                    bool flag3 = modTypes.TempPlayer[invitee].Invitationindex > 0;
                    if (flag3)
                    {
                        bool flag4 = modTypes.TempPlayer[invitee].InvitationTimer > S_General.GetTimeMs();
                        if (flag4)
                        {
                            S_NetworkSend.PlayerMsg(index, (S_Players.GetPlayerName(invitee).Trim()) + " is currently busy!", 14);
                            return;
                        }
                    }
                    bool flag5 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Houseindex > 0;
                    if (flag5)
                    {
                        bool flag6 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse > 0;
                        if (flag6)
                        {
                            bool flag7 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse == index;
                            if (flag7)
                            {
                                bool flag8 = modTypes.Player[invitee].Character[(int)modTypes.TempPlayer[invitee].CurChar].InHouse > 0;
                                if (flag8)
                                {
                                    bool flag9 = modTypes.Player[invitee].Character[(int)modTypes.TempPlayer[invitee].CurChar].InHouse == index;
                                    if (flag9)
                                    {
                                        S_NetworkSend.PlayerMsg(index, (S_Players.GetPlayerName(invitee).Trim()) + " is already in your house!", 14);
                                    }
                                    else
                                    {
                                        S_NetworkSend.PlayerMsg(index, (S_Players.GetPlayerName(invitee).Trim()) + " is already visiting someone elses house!", 14);
                                    }
                                }
                                else
                                {
                                    buffer = new ByteStream(4);
                                    buffer.WriteInt32(91);
                                    buffer.WriteInt32(index);
                                    S_NetworkConfig.Socket.SendDataTo(invitee, buffer.Data, buffer.Head);
                                    modTypes.TempPlayer[invitee].Invitationindex = index;
                                    modTypes.TempPlayer[invitee].InvitationTimer = checked(S_General.GetTimeMs() + 15000);
                                    buffer.Dispose();
                                }
                            }
                            else
                            {
                                S_NetworkSend.PlayerMsg(index, "Only the house owner can invite other players into their house.", 12);
                            }
                        }
                        else
                        {
                            S_NetworkSend.PlayerMsg(index, "You must be inside your house before you can invite someone to visit!", 12);
                        }
                    }
                    else
                    {
                        S_NetworkSend.PlayerMsg(index, "You do not have a house to invite anyone to!", 12);
                    }
                }
            }
        }

        // Token: 0x060001DD RID: 477 RVA: 0x0003A20C File Offset: 0x0003840C
        public static void Packet_AcceptInvite(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            int response = buffer.ReadInt32();
            buffer.Dispose();
            bool flag = response == 1;
            if (flag)
            {
                bool flag2 = modTypes.TempPlayer[index].Invitationindex > 0;
                if (flag2)
                {
                    bool flag3 = modTypes.TempPlayer[index].InvitationTimer > S_General.GetTimeMs();
                    if (flag3)
                    {
                        bool flag4 = S_NetworkConfig.IsPlaying(modTypes.TempPlayer[index].Invitationindex);
                        if (flag4)
                        {
                            modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse = modTypes.TempPlayer[index].Invitationindex;
                            modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].LastX = S_Players.GetPlayerX(index);
                            modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].LastY = S_Players.GetPlayerY(index);
                            modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].LastMap = S_Players.GetPlayerMap(index);
                            modTypes.TempPlayer[index].InvitationTimer = 0;
                            S_Players.PlayerWarp(index, modTypes.Player[modTypes.TempPlayer[index].Invitationindex].Character[(int)modTypes.TempPlayer[index].CurChar].Map, S_Housing.HouseConfig[modTypes.Player[modTypes.TempPlayer[index].Invitationindex].Character[(int)modTypes.TempPlayer[modTypes.TempPlayer[index].Invitationindex].CurChar].House.Houseindex].X, S_Housing.HouseConfig[modTypes.Player[modTypes.TempPlayer[index].Invitationindex].Character[(int)modTypes.TempPlayer[modTypes.TempPlayer[index].Invitationindex].CurChar].House.Houseindex].Y, true, true);
                        }
                        else
                        {
                            modTypes.TempPlayer[index].InvitationTimer = 0;
                            S_NetworkSend.PlayerMsg(index, "Cannot find player!", 12);
                        }
                    }
                    else
                    {
                        S_NetworkSend.PlayerMsg(index, "Your invitation has expired, have your friend re-invite you.", 14);
                    }
                }
            }
            else
            {
                bool flag5 = S_NetworkConfig.IsPlaying(modTypes.TempPlayer[index].Invitationindex);
                if (flag5)
                {
                    modTypes.TempPlayer[index].InvitationTimer = 0;
                    S_NetworkSend.PlayerMsg(modTypes.TempPlayer[index].Invitationindex, (S_Players.GetPlayerName(index).Trim()) + " rejected your invitation", 12);
                }
            }
        }

        // Token: 0x060001DE RID: 478 RVA: 0x0003A504 File Offset: 0x00038704
        public static void Packet_PlaceFurniture(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            int x = buffer.ReadInt32();
            int y = buffer.ReadInt32();
            int invslot = buffer.ReadInt32();
            buffer.Dispose();
            int ItemNum = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].Inv[invslot].Num;
            bool flag = ItemNum < 1 || ItemNum > 500;
            checked
            {
                if (!flag)
                {
                    bool flag2 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse == index;
                    if (flag2)
                    {
                        bool flag3 = Types.Item[ItemNum].Type == 6;
                        if (flag3)
                        {
                            int i = 1;
                            for (; ; )
                            {
                                bool flag4 = S_Players.GetPlayerRawStat(index, (Enums.StatType)i) < (int)Types.Item[ItemNum].Stat_Req[i];
                                if (flag4)
                                {
                                    break;
                                }
                                i++;
                                if (i > 6)
                                {
                                    goto Block_6;
                                }
                            }
                            S_NetworkSend.PlayerMsg(index, "You do not meet the stat requirements to use this item.", 12);
                            return;
                            Block_6:
                            bool flag5 = S_Players.GetPlayerLevel(index) < Types.Item[ItemNum].LevelReq;
                            if (flag5)
                            {
                                S_NetworkSend.PlayerMsg(index, "You do not meet the level requirement to use this item.", 12);
                            }
                            else
                            {
                                bool flag6 = Types.Item[ItemNum].ClassReq > 0;
                                if (flag6)
                                {
                                    bool flag7 = S_Players.GetPlayerClass(index) != Types.Item[ItemNum].ClassReq;
                                    if (flag7)
                                    {
                                        S_NetworkSend.PlayerMsg(index, "You do not meet the class requirement to use this item.", 12);
                                        return;
                                    }
                                }
                                bool flag8 = S_Players.GetPlayerAccess(index) < Types.Item[ItemNum].AccessReq;
                                if (flag8)
                                {
                                    S_NetworkSend.PlayerMsg(index, "You do not meet the access requirement to use this item.", 12);
                                }
                                else
                                {
                                    bool flag9 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse != index;
                                    if (flag9)
                                    {
                                        S_NetworkSend.PlayerMsg(index, "You must be inside your house to place furniture!", 14);
                                    }
                                    else
                                    {
                                        bool flag10 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount >= S_Housing.HouseConfig[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Houseindex].MaxFurniture;
                                        if (flag10)
                                        {
                                            bool flag11 = S_Housing.HouseConfig[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Houseindex].MaxFurniture > 0;
                                            if (flag11)
                                            {
                                                S_NetworkSend.PlayerMsg(index, "Your house cannot hold any more furniture!", 12);
                                                return;
                                            }
                                        }
                                        bool flag12 = x < 0 || x > (int)modTypes.Map[S_Players.GetPlayerMap(index)].MaxX;
                                        if (!flag12)
                                        {
                                            bool flag13 = y < 0 || y > (int)modTypes.Map[S_Players.GetPlayerMap(index)].MaxY;
                                            if (!flag13)
                                            {
                                                bool flag14 = Types.Item[ItemNum].FurnitureWidth > 2;
                                                int x2;
                                                int widthoffset;
                                                if (flag14)
                                                {
                                                    x2 = (int)Math.Round(unchecked((double)x + (double)Types.Item[ItemNum].FurnitureWidth / 2.0));
                                                    widthoffset = x2 - x;
                                                    x2 -= Types.Item[ItemNum].FurnitureWidth - widthoffset;
                                                }
                                                x2 = x;
                                                widthoffset = 0;
                                                int y2 = y;
                                                bool flag15 = widthoffset > 0;
                                                if (flag15)
                                                {
                                                    int num = x2;
                                                    int num2 = x2 + widthoffset;
                                                    for (x = num; x <= num2; x++)
                                                    {
                                                        int num3 = y2;
                                                        int num4 = y2 - Types.Item[ItemNum].FurnitureHeight + 1;
                                                        for (y = num3; y >= num4; y += -1)
                                                        {
                                                            bool flag16 = modTypes.Map[S_Players.GetPlayerMap(index)].Tile[x, y].Type == 1;
                                                            if (flag16)
                                                            {
                                                                return;
                                                            }
                                                            int playersOnline = S_GameLogic.GetPlayersOnline();
                                                            for (i = 1; i <= playersOnline; i++)
                                                            {
                                                                bool flag17 = S_NetworkConfig.IsPlaying(i) && i != index && S_Players.GetPlayerMap(i) == S_Players.GetPlayerMap(index);
                                                                if (flag17)
                                                                {
                                                                    bool flag18 = modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].InHouse == modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse;
                                                                    if (flag18)
                                                                    {
                                                                        bool flag19 = (int)modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].X == x && (int)modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].Y == y;
                                                                        if (flag19)
                                                                        {
                                                                            return;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            bool flag20 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount > 0;
                                                            if (flag20)
                                                            {
                                                                int furnitureCount = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount;
                                                                for (i = 1; i <= furnitureCount; i++)
                                                                {
                                                                    bool flag21 = x >= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].X && x <= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].X + Types.Item[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureWidth - 1;
                                                                    if (flag21)
                                                                    {
                                                                        bool flag22 = y <= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y && y >= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y - Types.Item[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureHeight + 1;
                                                                        if (flag22)
                                                                        {
                                                                            return;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    int num5 = x2;
                                                    int num6 = x2 - (Types.Item[ItemNum].FurnitureWidth - widthoffset);
                                                    for (x = num5; x >= num6; x += -1)
                                                    {
                                                        int num7 = y2;
                                                        int num8 = y2 - Types.Item[ItemNum].FurnitureHeight + 1;
                                                        for (y = num7; y >= num8; y += -1)
                                                        {
                                                            bool flag23 = modTypes.Map[S_Players.GetPlayerMap(index)].Tile[x, y].Type == 1;
                                                            if (flag23)
                                                            {
                                                                return;
                                                            }
                                                            int playersOnline2 = S_GameLogic.GetPlayersOnline();
                                                            for (i = 1; i <= playersOnline2; i++)
                                                            {
                                                                bool flag24 = S_NetworkConfig.IsPlaying(i) && i != index && S_Players.GetPlayerMap(i) == S_Players.GetPlayerMap(index);
                                                                if (flag24)
                                                                {
                                                                    bool flag25 = modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].InHouse == modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse;
                                                                    if (flag25)
                                                                    {
                                                                        bool flag26 = (int)modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].X == x && (int)modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].Y == y;
                                                                        if (flag26)
                                                                        {
                                                                            return;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            bool flag27 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount > 0;
                                                            if (flag27)
                                                            {
                                                                int furnitureCount2 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount;
                                                                for (i = 1; i <= furnitureCount2; i++)
                                                                {
                                                                    bool flag28 = x >= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].X && x <= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].X + Types.Item[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureWidth - 1;
                                                                    if (flag28)
                                                                    {
                                                                        bool flag29 = y <= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y && y >= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y - Types.Item[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureHeight + 1;
                                                                        if (flag29)
                                                                        {
                                                                            return;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    int num9 = x2;
                                                    int num10 = x2 + Types.Item[ItemNum].FurnitureWidth - 1;
                                                    for (x = num9; x <= num10; x++)
                                                    {
                                                        int num11 = y2;
                                                        int num12 = y2 - Types.Item[ItemNum].FurnitureHeight + 1;
                                                        for (y = num11; y >= num12; y += -1)
                                                        {
                                                            bool flag30 = modTypes.Map[S_Players.GetPlayerMap(index)].Tile[x, y].Type == 1;
                                                            if (flag30)
                                                            {
                                                                return;
                                                            }
                                                            int playersOnline3 = S_GameLogic.GetPlayersOnline();
                                                            for (i = 1; i <= playersOnline3; i++)
                                                            {
                                                                bool flag31 = S_NetworkConfig.IsPlaying(i) && i != index && S_Players.GetPlayerMap(i) == S_Players.GetPlayerMap(index);
                                                                if (flag31)
                                                                {
                                                                    bool flag32 = modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].InHouse == modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse;
                                                                    if (flag32)
                                                                    {
                                                                        bool flag33 = (int)modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].X == x && (int)modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].Y == y;
                                                                        if (flag33)
                                                                        {
                                                                            return;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            bool flag34 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount > 0;
                                                            if (flag34)
                                                            {
                                                                int furnitureCount3 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount;
                                                                for (i = 1; i <= furnitureCount3; i++)
                                                                {
                                                                    bool flag35 = x >= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].X && x <= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].X + Types.Item[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureWidth - 1;
                                                                    if (flag35)
                                                                    {
                                                                        bool flag36 = y <= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y && y >= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y - Types.Item[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureHeight + 1;
                                                                        if (flag36)
                                                                        {
                                                                            return;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                x = x2;
                                                y = y2;
                                                modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount + 1;
                                                modTypes.CharacterRec[] character = modTypes.Player[index].Character;
                                                byte curChar = modTypes.TempPlayer[index].CurChar;
                                                character[(int)curChar].House.Furniture = (S_Housing.FurnitureRec[])Utils.CopyArray(character[(int)curChar].House.Furniture, new S_Housing.FurnitureRec[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount + 1]);
                                                modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount].ItemNum = ItemNum;
                                                modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount].X = x;
                                                modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount].Y = y;
                                                S_Players.TakeInvItem(index, ItemNum, 0);
                                                S_Housing.SendFurnitureToHouse(modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse);
                                                modDatabase.SavePlayer(index);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        S_NetworkSend.PlayerMsg(index, "You cannot place furniture unless you are in your own house!", 12);
                    }
                }
            }
        }

        // Token: 0x060001DF RID: 479 RVA: 0x0003B69C File Offset: 0x0003989C
        public static void Packet_RequestEditHouse(int index, ref byte[] data)
        {
            bool flag = S_Players.GetPlayerAccess(index) < 2;
            checked
            {
                if (!flag)
                {
                    ByteStream buffer = new ByteStream(4);
                    buffer.WriteInt32(93);
                    int max_HOUSES = S_Housing.MAX_HOUSES;
                    for (int i = 1; i <= max_HOUSES; i++)
                    {
                        buffer.WriteString((S_Housing.HouseConfig[i].ConfigName.Trim()));
                        buffer.WriteInt32(S_Housing.HouseConfig[i].BaseMap);
                        buffer.WriteInt32(S_Housing.HouseConfig[i].X);
                        buffer.WriteInt32(S_Housing.HouseConfig[i].Y);
                        buffer.WriteInt32(S_Housing.HouseConfig[i].Price);
                        buffer.WriteInt32(S_Housing.HouseConfig[i].MaxFurniture);
                    }
                    S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
                    buffer.Dispose();
                }
            }
        }

        // Token: 0x060001E0 RID: 480 RVA: 0x0003B79C File Offset: 0x0003999C
        public static void Packet_SaveHouses(int index, ref byte[] data)
        {
            bool flag = S_Players.GetPlayerAccess(index) < 2;
            checked
            {
                if (!flag)
                {
                    ByteStream buffer = new ByteStream(data);
                    int Count = buffer.ReadInt32();
                    bool flag2 = Count > 0;
                    if (flag2)
                    {
                        int num = Count;
                        for (int z = 1; z <= num; z++)
                        {
                            int i = buffer.ReadInt32();
                            S_Housing.HouseConfig[i].ConfigName = (buffer.ReadString().Trim());
                            S_Housing.HouseConfig[i].BaseMap = buffer.ReadInt32();
                            S_Housing.HouseConfig[i].X = buffer.ReadInt32();
                            S_Housing.HouseConfig[i].Y = buffer.ReadInt32();
                            S_Housing.HouseConfig[i].Price = buffer.ReadInt32();
                            S_Housing.HouseConfig[i].MaxFurniture = buffer.ReadInt32();
                            S_Housing.SaveHouse(i);
                            int playersOnline = S_GameLogic.GetPlayersOnline();
                            for (int x = 1; x <= playersOnline; x++)
                            {
                                bool flag3 = S_NetworkConfig.IsPlaying(x) && modTypes.Player[x].Character[(int)modTypes.TempPlayer[x].CurChar].InHouse == i;
                                if (flag3)
                                {
                                    S_Housing.SendFurnitureToHouse(i);
                                }
                            }
                        }
                    }
                    buffer.Dispose();
                }
            }
        }

        // Token: 0x060001E1 RID: 481 RVA: 0x0003B8F8 File Offset: 0x00039AF8
        public static void Packet_SellHouse(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            int Tmpindex = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Houseindex;
            bool flag = Tmpindex > 0;
            checked
            {
                if (flag)
                {
                    int refund = (int)Math.Round((double)S_Housing.HouseConfig[Tmpindex].Price / 2.0);
                    modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Houseindex = 0;
                    modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount = 0;
                    modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture = new S_Housing.FurnitureRec[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount + 1];
                    int furnitureCount = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount;
                    for (int i = 0; i <= furnitureCount; i++)
                    {
                        modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum = 0;
                        modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].X = 0;
                        modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y = 0;
                    }
                    bool flag2 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse == Tmpindex;
                    if (flag2)
                    {
                        S_Players.PlayerWarp(index, modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].LastMap, modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].LastX, modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].LastY, false, false);
                    }
                    modDatabase.SavePlayer(index);
                    S_NetworkSend.PlayerMsg(index, "You sold your House for " + Conversions.ToString(refund) + " Gold!", 10);
                    S_Players.GiveInvItem(index, 1, refund, true);
                }
                else
                {
                    S_NetworkSend.PlayerMsg(index, "You dont own a House!", 12);
                }
                buffer.Dispose();
            }
        }

        // Token: 0x060001E2 RID: 482 RVA: 0x0003BC34 File Offset: 0x00039E34
        public static void SendHouseConfigs(int index)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32(94);
            int max_HOUSES = S_Housing.MAX_HOUSES;
            checked
            {
                for (int i = 1; i <= max_HOUSES; i++)
                {
                    buffer.WriteString(S_Housing.HouseConfig[i].ConfigName.Trim());
                    buffer.WriteInt32(S_Housing.HouseConfig[i].BaseMap);
                    buffer.WriteInt32(S_Housing.HouseConfig[i].MaxFurniture);
                    buffer.WriteInt32(S_Housing.HouseConfig[i].Price);
                }
                S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
                buffer.Dispose();
            }
        }

        // Token: 0x060001E3 RID: 483 RVA: 0x0003BCEC File Offset: 0x00039EEC
        public static void SendFurnitureToHouse(int Houseindex)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32(92);
            buffer.WriteInt32(Houseindex);
            buffer.WriteInt32(modTypes.Player[Houseindex].Character[(int)modTypes.TempPlayer[Houseindex].CurChar].House.FurnitureCount);
            bool flag = modTypes.Player[Houseindex].Character[(int)modTypes.TempPlayer[Houseindex].CurChar].House.FurnitureCount > 0;
            checked
            {
                if (flag)
                {
                    int furnitureCount = modTypes.Player[Houseindex].Character[(int)modTypes.TempPlayer[Houseindex].CurChar].House.FurnitureCount;
                    for (int i = 1; i <= furnitureCount; i++)
                    {
                        buffer.WriteInt32(modTypes.Player[Houseindex].Character[(int)modTypes.TempPlayer[Houseindex].CurChar].House.Furniture[i].ItemNum);
                        buffer.WriteInt32(modTypes.Player[Houseindex].Character[(int)modTypes.TempPlayer[Houseindex].CurChar].House.Furniture[i].X);
                        buffer.WriteInt32(modTypes.Player[Houseindex].Character[(int)modTypes.TempPlayer[Houseindex].CurChar].House.Furniture[i].Y);
                    }
                }
                int playersOnline = S_GameLogic.GetPlayersOnline();
                for (int i = 1; i <= playersOnline; i++)
                {
                    bool flag2 = S_NetworkConfig.IsPlaying(i);
                    if (flag2)
                    {
                        bool flag3 = modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].InHouse == Houseindex;
                        if (flag3)
                        {
                            S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);
                        }
                    }
                }
                buffer.Dispose();
            }
        }

        // Token: 0x04000054 RID: 84
        internal static int MAX_HOUSES = 100;

        // Token: 0x04000055 RID: 85
        internal static S_Housing.HouseRec[] HouseConfig;

        // Token: 0x0200004B RID: 75
        public struct HouseRec
        {
            // Token: 0x040001DA RID: 474
            public string ConfigName;

            // Token: 0x040001DB RID: 475
            public int BaseMap;

            // Token: 0x040001DC RID: 476
            public int Price;

            // Token: 0x040001DD RID: 477
            public int MaxFurniture;

            // Token: 0x040001DE RID: 478
            public int X;

            // Token: 0x040001DF RID: 479
            public int Y;
        }

        // Token: 0x0200004C RID: 76
        public struct FurnitureRec
        {
            // Token: 0x040001E0 RID: 480
            public int ItemNum;

            // Token: 0x040001E1 RID: 481
            public int X;

            // Token: 0x040001E2 RID: 482
            public int Y;
        }

        // Token: 0x0200004D RID: 77
        public struct PlayerHouseRec
        {
            // Token: 0x040001E3 RID: 483
            public int Houseindex;

            // Token: 0x040001E4 RID: 484
            public int FurnitureCount;

            // Token: 0x040001E5 RID: 485
            public S_Housing.FurnitureRec[] Furniture;
        }
    }
}
