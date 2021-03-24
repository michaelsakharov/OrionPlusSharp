﻿using System;
using System.IO;
using System.Windows.Forms;
using Asfw;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Engine
{
    [StandardModule]
    internal sealed class S_Housing
    {
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
        
        public static void LoadHouses()
        {
            if (!File.Exists(Path.Combine(Application.StartupPath, "data", "houseconfig.xml")))
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
                    if (S_NetworkConfig.IsPlaying(i))
                    {
                        S_Housing.SendHouseConfigs(i);
                    }
                }
            }
        }
        
        public static void SaveHouse(int index)
        {
            XmlClass myXml = new XmlClass
            {
                Filename = Path.Combine(Application.StartupPath, "data", "houseconfig.xml"),
                Root = "Config"
            };
            myXml.LoadXml();
            if (index > 0 && index <= S_Housing.MAX_HOUSES)
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
        
        public static void Packet_BuyHouse(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            int i = buffer.ReadInt32();
            if (i == 1)
            {
                if (modTypes.TempPlayer[index].BuyHouseindex > 0)
                {
                    int price = S_Housing.HouseConfig[modTypes.TempPlayer[index].BuyHouseindex].Price;
                    if (S_Players.HasItem(index, 1) >= price)
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
        
        public static void Packet_InviteToHouse(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            string Name = (buffer.ReadString().Trim());
            int invitee = S_GameLogic.FindPlayer(Name);
            buffer.Dispose();
            if (invitee == 0)
            {
                S_NetworkSend.PlayerMsg(index, "Player not found.", 12);
            }
            else
            {
                if (index == invitee)
                {
                    S_NetworkSend.PlayerMsg(index, "You cannot invite yourself to you own house!", 12);
                }
                else
                {
                    if (modTypes.TempPlayer[invitee].Invitationindex > 0)
                    {
                        if (modTypes.TempPlayer[invitee].InvitationTimer > S_General.GetTimeMs())
                        {
                            S_NetworkSend.PlayerMsg(index, (S_Players.GetPlayerName(invitee).Trim()) + " is currently busy!", 14);
                            return;
                        }
                    }

                    if (modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Houseindex > 0)
                    {
                        if (modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse > 0)
                        {
                            if (modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse == index)
                            {
                                if (modTypes.Player[invitee].Character[(int)modTypes.TempPlayer[invitee].CurChar].InHouse > 0)
                                {
                                    if (modTypes.Player[invitee].Character[(int)modTypes.TempPlayer[invitee].CurChar].InHouse == index)
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
        
        public static void Packet_AcceptInvite(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            int response = buffer.ReadInt32();
            buffer.Dispose();
            if (response == 1)
            {
                if (modTypes.TempPlayer[index].Invitationindex > 0)
                {
                    if (modTypes.TempPlayer[index].InvitationTimer > S_General.GetTimeMs())
                    {
                        if (S_NetworkConfig.IsPlaying(modTypes.TempPlayer[index].Invitationindex))
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
                if (S_NetworkConfig.IsPlaying(modTypes.TempPlayer[index].Invitationindex))
                {
                    modTypes.TempPlayer[index].InvitationTimer = 0;
                    S_NetworkSend.PlayerMsg(modTypes.TempPlayer[index].Invitationindex, (S_Players.GetPlayerName(index).Trim()) + " rejected your invitation", 12);
                }
            }
        }
        
        public static void Packet_PlaceFurniture(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            int x = buffer.ReadInt32();
            int y = buffer.ReadInt32();
            int invslot = buffer.ReadInt32();
            buffer.Dispose();
            int ItemNum = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].Inv[invslot].Num;
            checked
            {
                if (!(ItemNum < 1 || ItemNum > 500))
                {
                    if (modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse == index)
                    {
                        if (Types.Item[ItemNum].Type == 6)
                        {
                            int i = 1;
                            for (; ; )
                            {
                                if (S_Players.GetPlayerRawStat(index, (Enums.StatType)i) < (int)Types.Item[ItemNum].Stat_Req[i])
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
                            if (S_Players.GetPlayerLevel(index) < Types.Item[ItemNum].LevelReq)
                            {
                                S_NetworkSend.PlayerMsg(index, "You do not meet the level requirement to use this item.", 12);
                            }
                            else
                            {
                                if (Types.Item[ItemNum].ClassReq > 0)
                                {
                                    if (S_Players.GetPlayerClass(index) != Types.Item[ItemNum].ClassReq)
                                    {
                                        S_NetworkSend.PlayerMsg(index, "You do not meet the class requirement to use this item.", 12);
                                        return;
                                    }
                                }
                                if (S_Players.GetPlayerAccess(index) < Types.Item[ItemNum].AccessReq)
                                {
                                    S_NetworkSend.PlayerMsg(index, "You do not meet the access requirement to use this item.", 12);
                                }
                                else
                                {
                                    if (modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse != index)
                                    {
                                        S_NetworkSend.PlayerMsg(index, "You must be inside your house to place furniture!", 14);
                                    }
                                    else
                                    {
                                        if (modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount >= S_Housing.HouseConfig[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Houseindex].MaxFurniture)
                                        {
                                            if (S_Housing.HouseConfig[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Houseindex].MaxFurniture > 0)
                                            {
                                                S_NetworkSend.PlayerMsg(index, "Your house cannot hold any more furniture!", 12);
                                                return;
                                            }
                                        }
                                        if (!(x < 0 || x > (int)modTypes.Map[S_Players.GetPlayerMap(index)].MaxX))
                                        {
                                            if (!(y < 0 || y > (int)modTypes.Map[S_Players.GetPlayerMap(index)].MaxY))
                                            {
                                                int x2;
                                                int widthoffset;
                                                if (Types.Item[ItemNum].FurnitureWidth > 2)
                                                {
                                                    x2 = (int)Math.Round(unchecked((double)x + (double)Types.Item[ItemNum].FurnitureWidth / 2.0));
                                                    widthoffset = x2 - x;
                                                    x2 -= Types.Item[ItemNum].FurnitureWidth - widthoffset;
                                                }
                                                x2 = x;
                                                widthoffset = 0;
                                                int y2 = y;
                                                if (widthoffset > 0)
                                                {
                                                    int num = x2;
                                                    int num2 = x2 + widthoffset;
                                                    for (x = num; x <= num2; x++)
                                                    {
                                                        int num3 = y2;
                                                        int num4 = y2 - Types.Item[ItemNum].FurnitureHeight + 1;
                                                        for (y = num3; y >= num4; y += -1)
                                                        {
                                                            if (modTypes.Map[S_Players.GetPlayerMap(index)].Tile[x, y].Type == 1)
                                                            {
                                                                return;
                                                            }
                                                            int playersOnline = S_GameLogic.GetPlayersOnline();
                                                            for (i = 1; i <= playersOnline; i++)
                                                            {
                                                                if (S_NetworkConfig.IsPlaying(i) && i != index && S_Players.GetPlayerMap(i) == S_Players.GetPlayerMap(index))
                                                                {
                                                                    if (modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].InHouse == modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse)
                                                                    {
                                                                        if ((int)modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].X == x && (int)modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].Y == y)
                                                                        {
                                                                            return;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            if (modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount > 0)
                                                            {
                                                                int furnitureCount = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount;
                                                                for (i = 1; i <= furnitureCount; i++)
                                                                {
                                                                    if (x >= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].X && x <= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].X + Types.Item[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureWidth - 1)
                                                                    {
                                                                        if (y <= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y && y >= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y - Types.Item[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureHeight + 1)
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
                                                            if (modTypes.Map[S_Players.GetPlayerMap(index)].Tile[x, y].Type == 1)
                                                            {
                                                                return;
                                                            }
                                                            int playersOnline2 = S_GameLogic.GetPlayersOnline();
                                                            for (i = 1; i <= playersOnline2; i++)
                                                            {
                                                                if (S_NetworkConfig.IsPlaying(i) && i != index && S_Players.GetPlayerMap(i) == S_Players.GetPlayerMap(index))
                                                                {
                                                                    if (modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].InHouse == modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse)
                                                                    {
                                                                        if ((int)modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].X == x && (int)modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].Y == y)
                                                                        {
                                                                            return;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            if (modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount > 0)
                                                            {
                                                                int furnitureCount2 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount;
                                                                for (i = 1; i <= furnitureCount2; i++)
                                                                {
                                                                    if (x >= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].X && x <= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].X + Types.Item[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureWidth - 1)
                                                                    {
                                                                        if (y <= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y && y >= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y - Types.Item[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureHeight + 1)
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
                                                            if (modTypes.Map[S_Players.GetPlayerMap(index)].Tile[x, y].Type == 1)
                                                            {
                                                                return;
                                                            }
                                                            int playersOnline3 = S_GameLogic.GetPlayersOnline();
                                                            for (i = 1; i <= playersOnline3; i++)
                                                            {
                                                                if (S_NetworkConfig.IsPlaying(i) && i != index && S_Players.GetPlayerMap(i) == S_Players.GetPlayerMap(index))
                                                                {
                                                                    if (modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].InHouse == modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse)
                                                                    {
                                                                        if ((int)modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].X == x && (int)modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].Y == y)
                                                                        {
                                                                            return;
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            if (modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount > 0)
                                                            {
                                                                int furnitureCount3 = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.FurnitureCount;
                                                                for (i = 1; i <= furnitureCount3; i++)
                                                                {
                                                                    if (x >= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].X && x <= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].X + Types.Item[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureWidth - 1)
                                                                    {
                                                                        if (y <= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y && y >= modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y - Types.Item[modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureHeight + 1)
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
        
        public static void Packet_RequestEditHouse(int index, ref byte[] data)
        {
            checked
            {
                if (!(S_Players.GetPlayerAccess(index) < 2))
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
        
        public static void Packet_SaveHouses(int index, ref byte[] data)
        {
            checked
            {
                if (!(S_Players.GetPlayerAccess(index) < 2))
                {
                    ByteStream buffer = new ByteStream(data);
                    int Count = buffer.ReadInt32();
                    if (Count > 0)
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
                                if (S_NetworkConfig.IsPlaying(x) && modTypes.Player[x].Character[(int)modTypes.TempPlayer[x].CurChar].InHouse == i)
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
        
        public static void Packet_SellHouse(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            int Tmpindex = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].House.Houseindex;

            checked
            {
                if (Tmpindex > 0)
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

                    if (modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].InHouse == Tmpindex)
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
        
        public static void SendFurnitureToHouse(int Houseindex)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32(92);
            buffer.WriteInt32(Houseindex);
            buffer.WriteInt32(modTypes.Player[Houseindex].Character[(int)modTypes.TempPlayer[Houseindex].CurChar].House.FurnitureCount);

            checked
            {
                if (modTypes.Player[Houseindex].Character[(int)modTypes.TempPlayer[Houseindex].CurChar].House.FurnitureCount > 0)
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
                    if (S_NetworkConfig.IsPlaying(i))
                    {
                        if (modTypes.Player[i].Character[(int)modTypes.TempPlayer[i].CurChar].InHouse == Houseindex)
                        {
                            S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);
                        }
                    }
                }
                buffer.Dispose();
            }
        }
        
        internal static int MAX_HOUSES = 100;
        
        internal static S_Housing.HouseRec[] HouseConfig;
        
        public struct HouseRec
        {
            public string ConfigName;
            
            public int BaseMap;
            
            public int Price;
            
            public int MaxFurniture;
            
            public int X;
            
            public int Y;
        }
        
        public struct FurnitureRec
        {
            public int ItemNum;
            
            public int X;
            
            public int Y;
        }
        
        public struct PlayerHouseRec
        {
            public int Houseindex;
            
            public int FurnitureCount;
            
            public S_Housing.FurnitureRec[] Furniture;
        }
    }
}
