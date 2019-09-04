using System.Windows.Forms;
using Microsoft.VisualBasic;
using ASFW;
using ASFW.IO;
using System;
using static Engine.Enums;

namespace Engine
{
    static class S_NetworkSend
    {
        public static void AlertMsg(int index, string Msg)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SAlertMsg);
            buffer.WriteString((Msg));
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: SAlertMsg");

            buffer.Dispose();
        }

        public static void GlobalMsg(string Msg)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SGlobalMsg);
            buffer.WriteString((Msg));
            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: SGlobalMsg");

            buffer.Dispose();
        }

        public static void PlayerMsg(int index, string Msg, int Colour)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SPlayerMsg);
            // buffer.Writestring((Msg)
            buffer.WriteString((Msg));
            buffer.WriteInt32(Colour);

            S_General.AddDebug("Sent SMSG: SPlayerMsg");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendNewCharClasses(int index)
        {
            int i;
            int n;
            int q;
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SNewCharClasses);
            buffer.WriteInt32(S_Globals.Max_Classes);

            S_General.AddDebug("Sent SMSG: SNewCharClasses");
            var loopTo = S_Globals.Max_Classes;
            for (i = 1; i <= loopTo; i++)
            {
                buffer.WriteString((modDatabase.GetClassName(i)));
                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Types.Classes[i].Desc)));

                buffer.WriteInt32(modDatabase.GetClassMaxVital(i, Enums.VitalType.HP));
                buffer.WriteInt32(modDatabase.GetClassMaxVital(i, Enums.VitalType.MP));
                buffer.WriteInt32(modDatabase.GetClassMaxVital(i, Enums.VitalType.SP));

                // set sprite array size
                n = Information.UBound(Types.Classes[i].MaleSprite);
                // send array size
                buffer.WriteInt32(n);
                var loopTo1 = n;
                // loop around sending each sprite
                for (q = 0; q <= loopTo1; q++)
                    buffer.WriteInt32(Types.Classes[i].MaleSprite[q]);

                // set sprite array size
                n = Information.UBound(Types.Classes[i].FemaleSprite);
                // send array size
                buffer.WriteInt32(n);
                var loopTo2 = n;
                // loop around sending each sprite
                for (q = 0; q <= loopTo2; q++)
                    buffer.WriteInt32(Types.Classes[i].FemaleSprite[q]);

                buffer.WriteInt32(Types.Classes[i].Stat[(int)Enums.StatType.Strength]);
                buffer.WriteInt32(Types.Classes[i].Stat[(int)Enums.StatType.Endurance]);
                buffer.WriteInt32(Types.Classes[i].Stat[(int)Enums.StatType.Vitality]);
                buffer.WriteInt32(Types.Classes[i].Stat[(int)Enums.StatType.Luck]);
                buffer.WriteInt32(Types.Classes[i].Stat[(int)Enums.StatType.Intelligence]);
                buffer.WriteInt32(Types.Classes[i].Stat[(int)Enums.StatType.Spirit]);

                for (q = 1; q <= 5; q++)
                {
                    buffer.WriteInt32(Types.Classes[i].StartItem[q]);
                    buffer.WriteInt32(Types.Classes[i].StartValue[q]);
                }

                buffer.WriteInt32(Types.Classes[i].StartMap);
                buffer.WriteInt32(Types.Classes[i].StartX);
                buffer.WriteInt32(Types.Classes[i].StartY);

                buffer.WriteInt32(Types.Classes[i].BaseExp);
            }

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendCloseTrade(int index)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SCloseTrade);
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: SCloseTrade");

            buffer.Dispose();
        }

        public static void SendExp(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SPlayerEXP);
            buffer.WriteInt32(index);
            buffer.WriteInt32(S_Players.GetPlayerExp(index));
            buffer.WriteInt32(S_Players.GetPlayerNextLevel(index));

            S_General.AddDebug("Sent SMSG: SPlayerEXP");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendLoadCharOk(int index)
        {
            ByteStream Buffer = new ByteStream(4);
            Buffer.WriteInt32((int)Packets.ServerPackets.SLoadCharOk);
            Buffer.WriteInt32(index);
            S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);

            S_General.AddDebug("Sent SMSG: SLoadCharOk");

            Buffer.Dispose();
        }

        public static void SendEditorLoadOk(int index)
        {
            ByteStream Buffer = new ByteStream(4);
            Buffer.WriteInt32((int)Packets.ServerPackets.SLoginOk);
            Buffer.WriteInt32(index);
            S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);

            S_General.AddDebug("Sent SMSG: SLoginOk");

            Buffer.Dispose();
        }

        public static void SendInGame(int index)
        {
            ByteStream Buffer = new ByteStream(4);
            Buffer.WriteInt32((int)Packets.ServerPackets.SInGame);
            S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);

            S_General.AddDebug("Sent SMSG: SInGame");

            Buffer.Dispose();
        }

        public static void SendClasses(int index)
        {
            // Dim i As Integer, n As Integer, q As Integer
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SClassesData);

            S_General.AddDebug("Sent SMSG: SClassesData");

            buffer.WriteBlock(modDatabase.ClassData());

            // For i = 1 To Max_Classes
            // buffer.WriteString((GetClassName(i).Trim))
            // buffer.WriteString((Classes(i).Desc.Trim))

            // buffer.WriteInt32(GetClassMaxVital(i, VitalType.HP))
            // buffer.WriteInt32(GetClassMaxVital(i, VitalType.MP))
            // buffer.WriteInt32(GetClassMaxVital(i, VitalType.SP))

            // ' set sprite array size
            // n = UBound(Classes(i).MaleSprite)

            // ' send array size
            // buffer.WriteInt32(n)

            // ' loop around sending each sprite
            // For q = 0 To n
            // buffer.WriteInt32(Classes(i).MaleSprite(q))
            // Next

            // ' set sprite array size
            // n = UBound(Classes(i).FemaleSprite)

            // ' send array size
            // buffer.WriteInt32(n)

            // ' loop around sending each sprite
            // For q = 0 To n
            // buffer.WriteInt32(Classes(i).FemaleSprite(q))
            // Next

            // buffer.WriteInt32(Classes(i).Stat(StatType.Strength))
            // buffer.WriteInt32(Classes(i).Stat(StatType.Endurance))
            // buffer.WriteInt32(Classes(i).Stat(StatType.Vitality))
            // buffer.WriteInt32(Classes(i).Stat(StatType.Intelligence))
            // buffer.WriteInt32(Classes(i).Stat(StatType.Luck))
            // buffer.WriteInt32(Classes(i).Stat(StatType.Spirit))

            // For q = 1 To 5
            // buffer.WriteInt32(Classes(i).StartItem(q))
            // buffer.WriteInt32(Classes(i).StartValue(q))
            // Next

            // buffer.WriteInt32(Classes(i).StartMap)
            // buffer.WriteInt32(Classes(i).StartX)
            // buffer.WriteInt32(Classes(i).StartY)

            // buffer.WriteInt32(Classes(i).BaseExp)
            // Next

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendClassesToAll()
        {
            // Dim i As Integer, n As Integer, q As Integer
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SClassesData);

            S_General.AddDebug("Sent SMSG: SClassesData To All");

            buffer.WriteBlock(modDatabase.ClassData());

            // For i = 1 To Max_Classes
            // buffer.WriteString((Trim$(GetClassName(i))))
            // buffer.WriteString((Trim$(Classes(i).Desc)))

            // buffer.WriteInt32(GetClassMaxVital(i, VitalType.HP))
            // buffer.WriteInt32(GetClassMaxVital(i, VitalType.MP))
            // buffer.WriteInt32(GetClassMaxVital(i, VitalType.SP))

            // ' set sprite array size
            // n = UBound(Classes(i).MaleSprite)

            // ' send array size
            // buffer.WriteInt32(n)

            // ' loop around sending each sprite
            // For q = 0 To n
            // buffer.WriteInt32(Classes(i).MaleSprite(q))
            // Next

            // ' set sprite array size
            // n = UBound(Classes(i).FemaleSprite)

            // ' send array size
            // buffer.WriteInt32(n)

            // ' loop around sending each sprite
            // For q = 0 To n
            // buffer.WriteInt32(Classes(i).FemaleSprite(q))
            // Next

            // buffer.WriteInt32(Classes(i).Stat(StatType.Strength))
            // buffer.WriteInt32(Classes(i).Stat(StatType.Endurance))
            // buffer.WriteInt32(Classes(i).Stat(StatType.Vitality))
            // buffer.WriteInt32(Classes(i).Stat(StatType.Intelligence))
            // buffer.WriteInt32(Classes(i).Stat(StatType.Luck))
            // buffer.WriteInt32(Classes(i).Stat(StatType.Spirit))

            // For q = 1 To 5
            // buffer.WriteInt32(Classes(i).StartItem(q))
            // buffer.WriteInt32(Classes(i).StartValue(q))
            // Next

            // buffer.WriteInt32(Classes(i).StartMap)
            // buffer.WriteInt32(Classes(i).StartX)
            // buffer.WriteInt32(Classes(i).StartY)

            // buffer.WriteInt32(Classes(i).BaseExp)
            // Next

            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendInventory(int index)
        {
            int i;
            int n;
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SPlayerInv);

            S_General.AddDebug("Sent SMSG: SPlayerInv");

            for (i = 1; i <= Constants.MAX_INV; i++)
            {
                buffer.WriteInt32(S_Players.GetPlayerInvItemNum(index, i));
                buffer.WriteInt32(S_Players.GetPlayerInvItemValue(index, i));
                buffer.WriteString((modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[i].Prefix.Trim()));
                buffer.WriteString((modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[i].Suffix.Trim()));
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[i].Rarity);
                for (n = 1; n <= (int)Enums.StatType.Count - 1; n++)
                    buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[i].Stat[n]);
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[i].Damage);
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[i].Speed);
            }

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendLeftMap(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SLeftMap);
            buffer.WriteInt32(index);
            S_NetworkConfig.SendDataToAllBut(index, ref buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: SLeftMap");

            buffer.Dispose();
        }

        public static void SendLeftGame(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SLeftGame);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendMapEquipment(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SMapWornEq);
            buffer.WriteInt32(index);
            buffer.WriteInt32(S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Armor));
            buffer.WriteInt32(S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Weapon));
            buffer.WriteInt32(S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Helmet));
            buffer.WriteInt32(S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Shield));
            buffer.WriteInt32(S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Shoes));
            buffer.WriteInt32(S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Gloves));

            S_General.AddDebug("Sent SMSG: SMapWornEq");

            S_NetworkConfig.SendDataToMap(S_Players.GetPlayerMap(index), ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendMapEquipmentTo(int PlayerNum, int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SMapWornEq);
            buffer.WriteInt32(PlayerNum);
            buffer.WriteInt32(S_Players.GetPlayerEquipment(PlayerNum, Enums.EquipmentType.Armor));
            buffer.WriteInt32(S_Players.GetPlayerEquipment(PlayerNum, Enums.EquipmentType.Weapon));
            buffer.WriteInt32(S_Players.GetPlayerEquipment(PlayerNum, Enums.EquipmentType.Helmet));
            buffer.WriteInt32(S_Players.GetPlayerEquipment(PlayerNum, Enums.EquipmentType.Shield));
            buffer.WriteInt32(S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Shoes));
            buffer.WriteInt32(S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Gloves));

            S_General.AddDebug("Sent SMSG: SMapWornEq To");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendShops(int index)
        {
            int i;

            for (i = 1; i <= Constants.MAX_SHOPS; i++)
            {
                if (Types.Shop[i].Name.Trim().Length > 0)
                    SendUpdateShopTo(index, i);
            }
        }

        public static void SendUpdateShopTo(int index, int shopNum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SUpdateShop);

            buffer.WriteInt32(shopNum);
            buffer.WriteInt32(Types.Shop[shopNum].BuyRate);
            buffer.WriteString((Types.Shop[shopNum].Name.Trim()));
            buffer.WriteInt32(Types.Shop[shopNum].Face);

            S_General.AddDebug("Sent SMSG: SUpdateShop");

            for (var i = 0; i <= Constants.MAX_TRADES; i++)
            {
                buffer.WriteInt32(Types.Shop[shopNum].TradeItem[i].CostItem);
                buffer.WriteInt32(Types.Shop[shopNum].TradeItem[i].CostValue);
                buffer.WriteInt32(Types.Shop[shopNum].TradeItem[i].Item);
                buffer.WriteInt32(Types.Shop[shopNum].TradeItem[i].ItemValue);
            }

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendUpdateShopToAll(int shopNum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SUpdateShop);

            buffer.WriteInt32(shopNum);
            buffer.WriteInt32(Types.Shop[shopNum].BuyRate);
            buffer.WriteString(Types.Shop[shopNum].Name.Trim());
            buffer.WriteInt32(Types.Shop[shopNum].Face);

            S_General.AddDebug("Sent SMSG: SUpdateShop To All");

            for (var i = 0; i <= Constants.MAX_TRADES; i++)
            {
                buffer.WriteInt32(Types.Shop[shopNum].TradeItem[i].CostItem);
                buffer.WriteInt32(Types.Shop[shopNum].TradeItem[i].CostValue);
                buffer.WriteInt32(Types.Shop[shopNum].TradeItem[i].Item);
                buffer.WriteInt32(Types.Shop[shopNum].TradeItem[i].ItemValue);
            }

            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendSkills(int index)
        {
            int i;

            for (i = 1; i <= Constants.MAX_SKILLS; i++)
            {
                if (Types.Skill[i].Name.Trim().Length > 0)
                    SendUpdateSkillTo(index, i);
            }
        }

        public static void SendUpdateSkillTo(int index, int skillnum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SUpdateSkill);
            buffer.WriteInt32(skillnum);
            buffer.WriteInt32(Types.Skill[skillnum].AccessReq);
            buffer.WriteInt32(Types.Skill[skillnum].AoE);
            buffer.WriteInt32(Types.Skill[skillnum].CastAnim);
            buffer.WriteInt32(Types.Skill[skillnum].CastTime);
            buffer.WriteInt32(Types.Skill[skillnum].CdTime);
            buffer.WriteInt32(Types.Skill[skillnum].ClassReq);
            buffer.WriteInt32(Types.Skill[skillnum].Dir);
            buffer.WriteInt32(Types.Skill[skillnum].Duration);
            buffer.WriteInt32(Types.Skill[skillnum].Icon);
            buffer.WriteInt32(Types.Skill[skillnum].Interval);
            buffer.WriteInt32(Convert.ToInt32(Types.Skill[skillnum].IsAoE));
            buffer.WriteInt32(Types.Skill[skillnum].LevelReq);
            buffer.WriteInt32(Types.Skill[skillnum].Map);
            buffer.WriteInt32(Types.Skill[skillnum].MpCost);
            buffer.WriteString(Types.Skill[skillnum].Name.Trim());
            buffer.WriteInt32(Types.Skill[skillnum].Range);
            buffer.WriteInt32(Types.Skill[skillnum].SkillAnim);
            buffer.WriteInt32(Types.Skill[skillnum].StunDuration);
            buffer.WriteInt32(Types.Skill[skillnum].Type);
            buffer.WriteInt32(Types.Skill[skillnum].Vital);
            buffer.WriteInt32(Types.Skill[skillnum].X);
            buffer.WriteInt32(Types.Skill[skillnum].Y);

            S_General.AddDebug("Sent SMSG: SUpdateSkill");

            // projectiles
            buffer.WriteInt32(Types.Skill[skillnum].IsProjectile);
            buffer.WriteInt32(Types.Skill[skillnum].Projectile);

            buffer.WriteInt32(Types.Skill[skillnum].KnockBack);
            buffer.WriteInt32(Types.Skill[skillnum].KnockBackTiles);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendUpdateSkillToAll(int skillnum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SUpdateSkill);
            buffer.WriteInt32(skillnum);
            buffer.WriteInt32(Types.Skill[skillnum].AccessReq);
            buffer.WriteInt32(Types.Skill[skillnum].AoE);
            buffer.WriteInt32(Types.Skill[skillnum].CastAnim);
            buffer.WriteInt32(Types.Skill[skillnum].CastTime);
            buffer.WriteInt32(Types.Skill[skillnum].CdTime);
            buffer.WriteInt32(Types.Skill[skillnum].ClassReq);
            buffer.WriteInt32(Types.Skill[skillnum].Dir);
            buffer.WriteInt32(Types.Skill[skillnum].Duration);
            buffer.WriteInt32(Types.Skill[skillnum].Icon);
            buffer.WriteInt32(Types.Skill[skillnum].Interval);
            buffer.WriteInt32(Convert.ToInt32(Types.Skill[skillnum].IsAoE));
            buffer.WriteInt32(Types.Skill[skillnum].LevelReq);
            buffer.WriteInt32(Types.Skill[skillnum].Map);
            buffer.WriteInt32(Types.Skill[skillnum].MpCost);
            buffer.WriteString(Types.Skill[skillnum].Name.Trim());
            buffer.WriteInt32(Types.Skill[skillnum].Range);
            buffer.WriteInt32(Types.Skill[skillnum].SkillAnim);
            buffer.WriteInt32(Types.Skill[skillnum].StunDuration);
            buffer.WriteInt32(Types.Skill[skillnum].Type);
            buffer.WriteInt32(Types.Skill[skillnum].Vital);
            buffer.WriteInt32(Types.Skill[skillnum].X);
            buffer.WriteInt32(Types.Skill[skillnum].Y);

            S_General.AddDebug("Sent SMSG: SUpdateSkill To All");

            // projectiles
            buffer.WriteInt32(Types.Skill[skillnum].IsProjectile);
            buffer.WriteInt32(Types.Skill[skillnum].Projectile);

            buffer.WriteInt32(Types.Skill[skillnum].KnockBack);
            buffer.WriteInt32(Types.Skill[skillnum].KnockBackTiles);

            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendStats(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SPlayerStats);
            buffer.WriteInt32(index);
            buffer.WriteInt32(S_Players.GetPlayerStat(index, Enums.StatType.Strength));
            buffer.WriteInt32(S_Players.GetPlayerStat(index, Enums.StatType.Endurance));
            buffer.WriteInt32(S_Players.GetPlayerStat(index, Enums.StatType.Vitality));
            buffer.WriteInt32(S_Players.GetPlayerStat(index, Enums.StatType.Luck));
            buffer.WriteInt32(S_Players.GetPlayerStat(index, Enums.StatType.Intelligence));
            buffer.WriteInt32(S_Players.GetPlayerStat(index, Enums.StatType.Spirit));
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: SPlayerStats");

            buffer.Dispose();
        }

        public static void SendVitals(int index)
        {
            for (int i = 1; i <= (int)Enums.VitalType.Count - 1; i++)
                SendVital(index, (VitalType)i);
        }

        public static void SendVital(int index, Enums.VitalType Vital)
        {
            ByteStream buffer = new ByteStream(4);

            // Get our packet type.
            switch (Vital)
            {
                case Enums.VitalType.HP:
                    {
                        buffer.WriteInt32((int)Packets.ServerPackets.SPlayerHp);
                        S_General.AddDebug("Sent SMSG: SPlayerHp");
                        break;
                    }

                case Enums.VitalType.MP:
                    {
                        buffer.WriteInt32((int)Packets.ServerPackets.SPlayerMp);
                        S_General.AddDebug("Sent SMSG: SPlayerMp");
                        break;
                    }

                case Enums.VitalType.SP:
                    {
                        buffer.WriteInt32((int)Packets.ServerPackets.SPlayerSp);
                        S_General.AddDebug("Sent SMSG: SPlayerSp");
                        break;
                    }
            }

            // Set and send related data.
            buffer.WriteInt32(S_Players.GetPlayerMaxVital(index, Vital));
            buffer.WriteInt32(S_Players.GetPlayerVital(index, Vital));
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendWelcome(int index)
        {

            // Send them MOTD
            if (modTypes.Options.Motd.Trim().Length > 0)
                PlayerMsg(index, modTypes.Options.Motd, (int)Enums.ColorType.BrightCyan);

            // Send whos online
            SendWhosOnline(index);
        }

        public static void SendWhosOnline(int index)
        {
            string s = "";
            int n = 0;
            int i = 0;
            var loopTo = S_GameLogic.GetPlayersOnline();
            for (i = 1; i <= loopTo; i++)
            {
                if (S_NetworkConfig.IsPlaying(i))
                {
                    if (i != index)
                    {
                        s = s + S_Players.GetPlayerName(i) + ", ";
                        n = n + 1;
                    }
                }
            }

            if (n == 0)
                s = "There are no other players online.";
            else
            {
                s = Microsoft.VisualBasic.Strings.Mid(s, 1, Microsoft.VisualBasic.Strings.Len(s) - 2);
                s = "There are " + n + " other players online: " + s + ".";
            }

            PlayerMsg(index, s, (int)Enums.ColorType.White);
        }

        public static void SendWornEquipment(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SPlayerWornEq);

            S_General.AddDebug("Sent SMSG: SPlayerWornEq");

            for (var i = 1; i <= (int)Enums.EquipmentType.Count - 1; i++)
                buffer.WriteInt32(S_Players.GetPlayerEquipment(index, (EquipmentType)i));

            for (int i = 1; i <= (int)Enums.EquipmentType.Count - 1; i++)
            {
                buffer.WriteString((modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[i].Prefix.Trim().Length.ToString()));
                buffer.WriteString((modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[i].Suffix.Trim().Length.ToString()));
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[i].Damage);
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[i].Speed);
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[i].Rarity);
                for (var n = 1; n <= (int)Enums.StatType.Count - 1; n++)
                    buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[i].Stat[n]);
            }

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendMapData(int index, int mapNum, bool SendMap)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SMapData);
            buffer.WriteBlock(CompressMapData(index, mapNum, SendMap));
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: SMapData");

            buffer.Dispose();
        }

        public static byte[] CompressMapData(int index, int mapNum, bool mapTileData)
        {

            ByteStream buffer = new ByteStream(4);
            if (mapTileData)
            {
                buffer.WriteInt32(1);
                buffer.WriteInt32(mapNum);
                buffer.WriteString(modTypes.Map[mapNum].Name.Trim());
                buffer.WriteString(modTypes.Map[mapNum].Music.Trim());
                buffer.WriteInt32(modTypes.Map[mapNum].Revision);
                buffer.WriteInt32(modTypes.Map[mapNum].Moral);
                buffer.WriteInt32(modTypes.Map[mapNum].Tileset);
                buffer.WriteInt32(modTypes.Map[mapNum].Up);
                buffer.WriteInt32(modTypes.Map[mapNum].Down);
                buffer.WriteInt32(modTypes.Map[mapNum].Left);
                buffer.WriteInt32(modTypes.Map[mapNum].Right);
                buffer.WriteInt32(modTypes.Map[mapNum].BootMap);
                buffer.WriteInt32(modTypes.Map[mapNum].BootX);
                buffer.WriteInt32(modTypes.Map[mapNum].BootY);
                buffer.WriteInt32(modTypes.Map[mapNum].MaxX);
                buffer.WriteInt32(modTypes.Map[mapNum].MaxY);
                buffer.WriteInt32(modTypes.Map[mapNum].WeatherType);
                buffer.WriteInt32(modTypes.Map[mapNum].Fogindex);
                buffer.WriteInt32(modTypes.Map[mapNum].WeatherIntensity);
                buffer.WriteInt32(modTypes.Map[mapNum].FogAlpha);
                buffer.WriteInt32(modTypes.Map[mapNum].FogSpeed);
                buffer.WriteInt32(modTypes.Map[mapNum].HasMapTint);
                buffer.WriteInt32(modTypes.Map[mapNum].MapTintR);
                buffer.WriteInt32(modTypes.Map[mapNum].MapTintG);
                buffer.WriteInt32(modTypes.Map[mapNum].MapTintB);
                buffer.WriteInt32(modTypes.Map[mapNum].MapTintA);
                buffer.WriteInt32(modTypes.Map[mapNum].Instanced);
                buffer.WriteInt32(modTypes.Map[mapNum].Panorama);
                buffer.WriteInt32(modTypes.Map[mapNum].Parallax);
                buffer.WriteInt32(modTypes.Map[mapNum].Brightness);

                for (var i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                    buffer.WriteInt32(modTypes.Map[mapNum].Npc[i]);
                var loopTo = modTypes.Map[mapNum].MaxX;
                for (var x = 0; x <= loopTo; x++)
                {
                    var loopTo1 = modTypes.Map[mapNum].MaxY;
                    for (var y = 0; y <= loopTo1; y++)
                    {
                        buffer.WriteInt32(modTypes.Map[mapNum].Tile[x, y].Data1);
                        buffer.WriteInt32(modTypes.Map[mapNum].Tile[x, y].Data2);
                        buffer.WriteInt32(modTypes.Map[mapNum].Tile[x, y].Data3);
                        buffer.WriteInt32(modTypes.Map[mapNum].Tile[x, y].DirBlock);
                        for (var i = 0; i <= (int)Enums.LayerType.Count - 1; i++)
                        {
                            buffer.WriteInt32(modTypes.Map[mapNum].Tile[x, y].Layer[i].Tileset);
                            buffer.WriteInt32(modTypes.Map[mapNum].Tile[x, y].Layer[i].X);
                            buffer.WriteInt32(modTypes.Map[mapNum].Tile[x, y].Layer[i].Y);
                            buffer.WriteInt32(modTypes.Map[mapNum].Tile[x, y].Layer[i].AutoTile);
                        }
                        buffer.WriteInt32(modTypes.Map[mapNum].Tile[x, y].Type);
                    }
                }

                // Event Data
                buffer.WriteInt32(modTypes.Map[mapNum].EventCount);
                if (modTypes.Map[mapNum].EventCount > 0)
                {
                    var loopTo2 = modTypes.Map[mapNum].EventCount;
                    for (var i = 1; i <= loopTo2; i++)
                    {
                        {
                            if (modTypes.Map[mapNum].Events[i].Name == null) { modTypes.Map[mapNum].Events[i].Name = "Null"; }
                            buffer.WriteString((modTypes.Map[mapNum].Events[i].Name.Trim()));
                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Globals);
                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].X);
                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Y);
                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].PageCount);
                        }
                        if (modTypes.Map[mapNum].Events[i].PageCount > 0)
                        {
                            var loopTo3 = modTypes.Map[mapNum].Events[i].PageCount;
                            for (var X = 1; X <= loopTo3; X++)
                            {
                                {
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].ChkVariable);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].Variableindex);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].VariableCondition);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].VariableCompare);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].ChkSwitch);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].Switchindex);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].SwitchCompare);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].ChkHasItem);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].HasItemindex);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].HasItemAmount);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].ChkSelfSwitch);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].SelfSwitchindex);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].SelfSwitchCompare);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].GraphicType);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].Graphic);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].GraphicX);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].GraphicY);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].GraphicX2);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].GraphicY2);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].MoveType);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].MoveSpeed);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].MoveFreq);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].MoveRouteCount);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].IgnoreMoveRoute);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].RepeatMoveRoute);
                                    if (modTypes.Map[mapNum].Events[i].Pages[X].MoveRouteCount > 0)
                                    {
                                        var loopTo4 = modTypes.Map[mapNum].Events[i].Pages[X].MoveRouteCount;
                                        for (var Y = 1; Y <= loopTo4; Y++)
                                        {
                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].MoveRoute[Y].Index);
                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].MoveRoute[Y].Data1);
                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].MoveRoute[Y].Data2);
                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].MoveRoute[Y].Data3);
                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].MoveRoute[Y].Data4);
                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].MoveRoute[Y].Data5);
                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].MoveRoute[Y].Data6);
                                        }
                                    }
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].WalkAnim);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].DirFix);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].WalkThrough);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].ShowName);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].Trigger);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandListCount);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].Position);
                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].QuestNum);

                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].ChkPlayerGender);
                                }
                                if (modTypes.Map[mapNum].Events[i].Pages[X].CommandListCount > 0)
                                {
                                    var loopTo5 = modTypes.Map[mapNum].Events[i].Pages[X].CommandListCount;
                                    for (var Y = 1; Y <= loopTo5; Y++)
                                    {
                                        buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].CommandCount);
                                        buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].ParentList);
                                        if (modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].CommandCount > 0)
                                        {
                                            var loopTo6 = modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].CommandCount;
                                            for (var z = 1; z <= loopTo6; z++)
                                            {
                                                {
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].Index);
                                                    buffer.WriteString((modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].Text1.Trim()));
                                                    buffer.WriteString((modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].Text2.Trim()));
                                                    buffer.WriteString((modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].Text3.Trim()));
                                                    buffer.WriteString((modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].Text4.Trim()));
                                                    buffer.WriteString((modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].Text5.Trim()));
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].Data1);
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].Data2);
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].Data3);
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].Data4);
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].Data5);
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].Data6);
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].ConditionalBranch.CommandList);
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].ConditionalBranch.Condition);
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].ConditionalBranch.Data1);
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].ConditionalBranch.Data2);
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].ConditionalBranch.Data3);
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].ConditionalBranch.ElseCommandList);
                                                    buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].MoveRouteCount);
                                                    if (modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].MoveRouteCount > 0)
                                                    {
                                                        var loopTo7 = modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].MoveRouteCount;
                                                        for (var w = 1; w <= loopTo7; w++)
                                                        {
                                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Index);
                                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Data1);
                                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Data2);
                                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Data3);
                                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Data4);
                                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Data5);
                                                            buffer.WriteInt32(modTypes.Map[mapNum].Events[i].Pages[X].CommandList[Y].Commands[z].MoveRoute[w].Data6);
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
            }
            else
            {
                buffer.WriteInt32(0);
            }

            for (var i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
            {
                buffer.WriteInt32(modTypes.MapItem[mapNum, i].Num);
                buffer.WriteInt32(modTypes.MapItem[mapNum, i].Value);
                buffer.WriteInt32(modTypes.MapItem[mapNum, i].X);
                buffer.WriteInt32(modTypes.MapItem[mapNum, i].Y);
            }

            for (int i = 1; i <= Constants.MAX_MAP_NPCS; i++)
            {
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Num);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].X);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Y);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Dir);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Vital[(int)Enums.VitalType.HP]);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Vital[(int)Enums.VitalType.MP]);
            }

            // send Resource cache
            if (S_Resources.ResourceCache[S_Players.GetPlayerMap(index)].ResourceCount > 0)
            {
                buffer.WriteInt32(1);
                buffer.WriteInt32(S_Resources.ResourceCache[S_Players.GetPlayerMap(index)].ResourceCount);
                var loopTo8 = S_Resources.ResourceCache[S_Players.GetPlayerMap(index)].ResourceCount;
                for (var i = 0; i <= loopTo8; i++)
                {
                    buffer.WriteInt32(S_Resources.ResourceCache[S_Players.GetPlayerMap(index)].ResourceData[i].ResourceState);
                    buffer.WriteInt32(S_Resources.ResourceCache[S_Players.GetPlayerMap(index)].ResourceData[i].X);
                    buffer.WriteInt32(S_Resources.ResourceCache[S_Players.GetPlayerMap(index)].ResourceData[i].Y);
                }
            }
            else
                buffer.WriteInt32(0);

            return(Compression.CompressBytes(buffer.ToArray()));
        }

        public static void SendJoinMap(int index)
        {
            int i;
            byte[] data;
            var loopTo = S_GameLogic.GetPlayersOnline();

            // Send all players on current map to index
            for (i = 1; i <= loopTo; i++)
            {
                if (S_NetworkConfig.IsPlaying(i))
                {
                    if (i != index)
                    {
                        if (S_Players.GetPlayerMap(i) == S_Players.GetPlayerMap(index))
                        {
                            data = PlayerData(i);
                            S_NetworkConfig.Socket.SendDataTo(index, data, data.Length);
                        }
                    }
                }
            }

            // Send index's player data to everyone on the map including himself
            data = PlayerData(index);
            S_NetworkConfig.SendDataToMap(S_Players.GetPlayerMap(index), ref data, data.Length);
        }

        public static byte[] PlayerData(int index)
        {
            ByteStream buffer = new ByteStream(4);
            if (index > Constants.MAX_PLAYERS)
                return null;

            buffer.WriteInt32((int)Packets.ServerPackets.SPlayerData);
            buffer.WriteInt32(index);
            buffer.WriteString(S_Players.GetPlayerName(index).Trim());
            buffer.WriteInt32(S_Players.GetPlayerClass(index));
            buffer.WriteInt32(S_Players.GetPlayerLevel(index));
            buffer.WriteInt32(S_Players.GetPlayerPOINTS(index));
            buffer.WriteInt32(S_Players.GetPlayerSprite(index));
            buffer.WriteInt32(S_Players.GetPlayerMap(index));
            buffer.WriteInt32(S_Players.GetPlayerX(index));
            buffer.WriteInt32(S_Players.GetPlayerY(index));
            buffer.WriteInt32(S_Players.GetPlayerDir(index));
            buffer.WriteInt32(S_Players.GetPlayerAccess(index));
            buffer.WriteInt32(S_Players.GetPlayerPK(index));

            S_General.AddDebug("Sent SMSG: SPlayerData");

            for (int i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                buffer.WriteInt32(S_Players.GetPlayerStat(index, (StatType)i));

            buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse);

            for (int i = 0; i <= (int)Enums.ResourceSkills.Count - 1; i++)
            {
                buffer.WriteInt32(S_Resources.GetPlayerGatherSkillLvl(index, i));
                buffer.WriteInt32(S_Resources.GetPlayerGatherSkillExp(index, i));
                buffer.WriteInt32(S_Resources.GetPlayerGatherSkillMaxExp(index, i));
            }

            for (int i = 1; i <= Constants.MAX_RECIPE; i++)
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RecipeLearned[i]);

            byte[] bufferData = buffer.ToArray(); ;
            buffer.Dispose();

            return bufferData;
        }

        public static void SendPlayerXY(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SPlayerXY);
            buffer.WriteInt32(S_Players.GetPlayerX(index));
            buffer.WriteInt32(S_Players.GetPlayerY(index));
            buffer.WriteInt32(S_Players.GetPlayerDir(index));

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: SPlayerXY");

            buffer.Dispose();
        }

        public static void SendPlayerMove(int index, int Movement)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SPlayerMove);
            buffer.WriteInt32(index);
            buffer.WriteInt32(S_Players.GetPlayerX(index));
            buffer.WriteInt32(S_Players.GetPlayerY(index));
            buffer.WriteInt32(S_Players.GetPlayerDir(index));
            buffer.WriteInt32(Movement);

            S_NetworkConfig.SendDataToMapBut(index, S_Players.GetPlayerMap(index), ref buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: SPlayerMove");

            buffer.Dispose();
        }

        public static void SendDoorAnimation(int mapNum, int X, int Y)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SDoorAnimation);
            buffer.WriteInt32(X);
            buffer.WriteInt32(Y);

            S_General.AddDebug("Sent SMSG: SDoorAnimation");

            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendMapKey(int index, int X, int Y, int Value)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SMapKey);
            buffer.WriteInt32(X);
            buffer.WriteInt32(Y);
            buffer.WriteInt32(Value);

            S_General.AddDebug("Sent SMSG: SMapKey");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void MapMsg(int mapNum, string Msg, byte Color)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SMapMsg);
            buffer.WriteString((Msg.Trim()));

            S_General.AddDebug("Sent SMSG: SMapMsg");

            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendActionMsg(int mapNum, string Message, int Color, int MsgType, int X, int Y, int PlayerOnlyNum = 0)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SActionMsg);
            buffer.WriteString((Message.Trim()));
            buffer.WriteInt32(Color);
            buffer.WriteInt32(MsgType);
            buffer.WriteInt32(X);
            buffer.WriteInt32(Y);

            S_General.AddDebug("Sent SMSG: SActionMsg");

            if (PlayerOnlyNum > 0)
                S_NetworkConfig.Socket.SendDataTo(PlayerOnlyNum, buffer.Data, buffer.Head);
            else
                S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SayMsg_Map(int mapNum, int index, string Message, int SayColour)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SSayMsg);
            buffer.WriteString(S_Players.GetPlayerName(index).Trim());
            buffer.WriteInt32(S_Players.GetPlayerAccess(index));
            buffer.WriteInt32(S_Players.GetPlayerPK(index));
            buffer.WriteString(Message.Trim());
            buffer.WriteString(("[Map] "));
            buffer.WriteInt32(SayColour);

            S_General.AddDebug("Sent SMSG: SSayMsg");

            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendPlayerData(int index)
        {
            var data = PlayerData(index);
            S_NetworkConfig.SendDataToMap(S_Players.GetPlayerMap(index), ref data, data.Length);
        }

        public static void SendMapKeyToMap(int mapNum, int X, int Y, int Value)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SMapKey);
            buffer.WriteInt32(X);
            buffer.WriteInt32(Y);
            buffer.WriteInt32(Value);
            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: SMapKey");

            buffer.Dispose();
        }

        public static void SendGameData(int index)
        {
            ByteStream buffer = new ByteStream(4);
            int i;
            byte[] data;

            buffer.WriteBlock(modDatabase.ClassData());

            i = 0;

            for (var x = 1; x <= Constants.MAX_ITEMS; x++)
            {
                if (Types.Item[x].Name.Trim().Length > 0)
                    i = i + 1;
            }

            // Write Number of Items it is Sending and then The Item Data
            buffer.WriteInt32(i);
            buffer.WriteBlock(S_Items.ItemsData());

            i = 0;

            for (var x = 1; x <= Constants.MAX_ANIMATIONS; x++)
            {
                if (Types.Animation[x].Name.Trim().Length > 0)
                    i = i + 1;
            }

            buffer.WriteInt32(i);
            buffer.WriteBlock(S_Animations.AnimationsData());

            i = 0;

            for (var x = 1; x <= Constants.MAX_NPCS; x++)
            {
                if (Types.Npc[x].Name.Trim().Length > 0)
                    i = i + 1;
            }

            buffer.WriteInt32(i);
            buffer.WriteBlock(modDatabase.NpcsData());

            i = 0;

            for (var x = 1; x <= Constants.MAX_SHOPS; x++)
            {
                if (Types.Shop[x].Name.Trim().Length > 0)
                    i = i + 1;
            }

            buffer.WriteInt32(i);
            buffer.WriteBlock(modDatabase.ShopsData());

            i = 0;

            for (var x = 1; x <= Constants.MAX_SKILLS; x++)
            {
                if (Types.Skill[x].Name.Trim().Length > 0)
                    i = i + 1;
            }

            buffer.WriteInt32(i);
            buffer.WriteBlock(modDatabase.SkillsData());

            i = 0;

            for (var x = 1; x <= Constants.MAX_RESOURCES; x++)
            {
                if (Types.Resource[x].Name.Trim().Length > 0)
                    i = i + 1;
            }

            buffer.WriteInt32(i);
            buffer.WriteBlock(S_Resources.ResourcesData());

            data = Compression.CompressBytes(buffer.ToArray());

            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SGameData);

            S_General.AddDebug("Sent SMSG: SGameData");

            buffer.WriteBlock(data);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SayMsg_Global(int index, string Message, int SayColour)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SSayMsg);
            buffer.WriteString(S_Players.GetPlayerName(index).Trim());
            buffer.WriteInt32(S_Players.GetPlayerAccess(index));
            buffer.WriteInt32(S_Players.GetPlayerPK(index));
            buffer.WriteString(Message.Trim());
            buffer.WriteString(("[Global] "));
            buffer.WriteInt32(SayColour);

            S_General.AddDebug("Sent SMSG: SSayMsg Global");

            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendInventoryUpdate(int index, int InvSlot)
        {
            ByteStream buffer = new ByteStream(4);
            int n;

            buffer.WriteInt32((int)Packets.ServerPackets.SPlayerInvUpdate);
            buffer.WriteInt32(InvSlot);
            buffer.WriteInt32(S_Players.GetPlayerInvItemNum(index, InvSlot));
            buffer.WriteInt32(S_Players.GetPlayerInvItemValue(index, InvSlot));

            S_General.AddDebug("Sent SMSG: SPlayerInvUpdate");

            buffer.WriteString((modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvSlot].Prefix.Trim()));
            buffer.WriteString((modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvSlot].Suffix.Trim()));
            buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvSlot].Rarity);
            for (n = 1; n <= (int)Enums.StatType.Count - 1; n++)
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvSlot].Stat[n]);
            buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvSlot].Damage);
            buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvSlot].Speed);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendOpenShop(int index, int ShopNum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SOpenShop);
            buffer.WriteInt32(ShopNum);
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: SOpenShop");

            buffer.Dispose();
        }

        public static void ResetShopAction(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SResetShopAction);

            S_General.AddDebug("Sent SMSG: SResetShopAction");

            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendBank(int index)
        {
            ByteStream buffer = new ByteStream(4);
            int i;

            buffer.WriteInt32((int)Packets.ServerPackets.SBank);

            S_General.AddDebug("Sent SMSG: SBank");

            for (i = 1; i <= Constants.MAX_BANK; i++)
            {
                buffer.WriteInt32(modTypes.Bank[index].Item[i].Num);
                buffer.WriteInt32(modTypes.Bank[index].Item[i].Value);

                buffer.WriteString((modTypes.Bank[index].ItemRand[i].Prefix.Trim()));
                buffer.WriteString((modTypes.Bank[index].ItemRand[i].Suffix.Trim()));
                buffer.WriteInt32(modTypes.Bank[index].ItemRand[i].Rarity);
                buffer.WriteInt32(modTypes.Bank[index].ItemRand[i].Damage);
                buffer.WriteInt32(modTypes.Bank[index].ItemRand[i].Speed);

                for (var x = 1; x <= (int)Enums.StatType.Count - 1; x++)
                    buffer.WriteInt32(modTypes.Bank[index].ItemRand[i].Stat[x]);
            }

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendClearSkillBuffer(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SClearSkillBuffer);

            S_General.AddDebug("Sent SMSG: SClearSkillBuffer");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendClearTradeTimer(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SClearTradeTimer);

            S_General.AddDebug("Sent SMSG: SClearTradeTimer");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendTradeInvite(int index, int Tradeindex)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.STradeInvite);

            S_General.AddDebug("Sent SMSG: STradeInvite");

            buffer.WriteInt32(Tradeindex);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendTrade(int index, int TradeTarget)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.STrade);
            buffer.WriteInt32(TradeTarget);
            buffer.WriteString(S_Players.GetPlayerName(TradeTarget).Trim());
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: STrade");

            buffer.Dispose();
        }

        public static void SendTradeUpdate(int index, byte DataType)
        {
            ByteStream buffer = new ByteStream(4);
            int i = 0;
            int tradeTarget = 0;
            int totalWorth = 0;

            tradeTarget = modTypes.TempPlayer[index].InTrade;

            buffer.WriteInt32((int)Packets.ServerPackets.STradeUpdate);
            buffer.WriteInt32(DataType);

            S_General.AddDebug("Sent SMSG: STradeUpdate");

            if (DataType == 0)
            {
                for (i = 1; i <= Constants.MAX_INV; i++)
                {
                    buffer.WriteInt32(modTypes.TempPlayer[index].TradeOffer[i].Num);
                    buffer.WriteInt32(modTypes.TempPlayer[index].TradeOffer[i].Value);

                    // add total worth
                    if (modTypes.TempPlayer[index].TradeOffer[i].Num > 0)
                    {
                        // currency?
                        if (Types.Item[modTypes.TempPlayer[index].TradeOffer[i].Num].Type == (byte)Enums.ItemType.Currency || Types.Item[modTypes.TempPlayer[index].TradeOffer[i].Num].Stackable == 1)
                        {
                            if (modTypes.TempPlayer[index].TradeOffer[i].Value == 0)
                                modTypes.TempPlayer[index].TradeOffer[i].Value = 1;
                            totalWorth = totalWorth + (Types.Item[S_Players.GetPlayerInvItemNum(index, modTypes.TempPlayer[index].TradeOffer[i].Num)].Price * modTypes.TempPlayer[index].TradeOffer[i].Value);
                        }
                        else
                            totalWorth = totalWorth + Types.Item[S_Players.GetPlayerInvItemNum(index, modTypes.TempPlayer[index].TradeOffer[i].Num)].Price;
                    }
                }
            }
            else if (DataType == 1)
            {
                for (i = 1; i <= Constants.MAX_INV; i++)
                {
                    buffer.WriteInt32(S_Players.GetPlayerInvItemNum(tradeTarget, modTypes.TempPlayer[tradeTarget].TradeOffer[i].Num));
                    buffer.WriteInt32(modTypes.TempPlayer[tradeTarget].TradeOffer[i].Value);

                    // add total worth
                    if (S_Players.GetPlayerInvItemNum(tradeTarget, modTypes.TempPlayer[tradeTarget].TradeOffer[i].Num) > 0)
                    {
                        // currency?
                        if (Types.Item[S_Players.GetPlayerInvItemNum(tradeTarget, modTypes.TempPlayer[tradeTarget].TradeOffer[i].Num)].Type == (byte)Enums.ItemType.Currency || Types.Item[S_Players.GetPlayerInvItemNum(tradeTarget, modTypes.TempPlayer[tradeTarget].TradeOffer[i].Num)].Stackable == 1)
                        {
                            if (modTypes.TempPlayer[tradeTarget].TradeOffer[i].Value == 0)
                                modTypes.TempPlayer[tradeTarget].TradeOffer[i].Value = 1;
                            totalWorth = totalWorth + (Types.Item[S_Players.GetPlayerInvItemNum(tradeTarget, modTypes.TempPlayer[tradeTarget].TradeOffer[i].Num)].Price * modTypes.TempPlayer[tradeTarget].TradeOffer[i].Value);
                        }
                        else
                            totalWorth = totalWorth + Types.Item[S_Players.GetPlayerInvItemNum(tradeTarget, modTypes.TempPlayer[tradeTarget].TradeOffer[i].Num)].Price;
                    }
                }
            }

            // send total worth of trade
            buffer.WriteInt32(totalWorth);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendTradeStatus(int index, byte Status)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.STradeStatus);
            buffer.WriteInt32(Status);
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: STradeStatus");

            buffer.Dispose();
        }

        public static void SendStunned(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SStunned);
            buffer.WriteInt32(modTypes.TempPlayer[index].StunDuration);

            S_General.AddDebug("Sent SMSG: SStunned");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendBlood(int mapNum, int X, int Y)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SBlood);
            buffer.WriteInt32(X);
            buffer.WriteInt32(Y);

            S_General.AddDebug("Sent SMSG: SBlood");

            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendPlayerSkills(int index)
        {
            int i;
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SSkills);

            S_General.AddDebug("Sent SMSG: SSkills");

            for (i = 1; i <= Constants.MAX_PLAYER_SKILLS; i++)
                buffer.WriteInt32(S_Players.GetPlayerSkill(index, i));

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendCooldown(int index, int Slot)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SCooldown);
            buffer.WriteInt32(Slot);

            S_General.AddDebug("Sent SMSG: SCooldown");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendTarget(int index, int Target, int TargetType)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.STarget);
            buffer.WriteInt32(Target);
            buffer.WriteInt32(TargetType);

            S_General.AddDebug("Sent SMSG: STarget");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        // Mapreport
        public static void SendMapReport(int index)
        {
            ByteStream buffer = new ByteStream(4);
            int I;

            buffer.WriteInt32((int)Packets.ServerPackets.SMapReport);

            S_General.AddDebug("Sent SMSG: SMapReport");

            for (I = 1; I <= Constants.MAX_MAPS; I++)
                buffer.WriteString(modTypes.Map[I].Name.Trim());

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendAdminPanel(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SAdmin);

            S_General.AddDebug("Sent SMSG: SAdmin");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendMapNames(int index)
        {
            ByteStream buffer = new ByteStream(4);
            int I;

            buffer.WriteInt32((int)Packets.ServerPackets.SMapNames);

            S_General.AddDebug("Sent SMSG: SMapNames");

            for (I = 1; I <= Constants.MAX_MAPS; I++)
                buffer.WriteString(modTypes.Map[I].Name.Trim());

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendHotbar(int index)
        {
            ByteStream buffer = new ByteStream(4);
            int i;

            buffer.WriteInt32((int)Packets.ServerPackets.SHotbar);

            S_General.AddDebug("Sent SMSG: SHotbar");

            for (i = 1; i <= S_Constants.MAX_HOTBAR; i++)
            {
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Hotbar[i].Slot);
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Hotbar[i].SlotType);
            }

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendCritical(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SCritical);

            S_General.AddDebug("Sent SMSG: SCritical");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendKeyPair(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SKeyPair);
            buffer.WriteString(S_Globals.EKeyPair.ExportKeyString(false).Trim());
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendNews(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SNews);

            S_General.AddDebug("Sent SMSG: SNews");

            buffer.WriteString(modTypes.Options.GameName.Trim());
            buffer.WriteString(modDatabase.GetFileContents(Application.StartupPath + @"\data\news.txt").Trim());

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendRightClick(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SrClick);

            S_General.AddDebug("Sent SMSG: SrClick");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendClassEditor(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SClassEditor);

            S_General.AddDebug("Sent SMSG: SClassEditor");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendEmote(int index, int Emote)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SEmote);

            S_General.AddDebug("Sent SMSG: SEmote");

            buffer.WriteInt32(index);
            buffer.WriteInt32(Emote);

            S_NetworkConfig.SendDataToMap(S_Players.GetPlayerMap(index), ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendChatBubble(int mapNum, int Target, int TargetType, string Message, int Colour)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SChatBubble);

            S_General.AddDebug("Sent SMSG: SChatBubble");

            buffer.WriteInt32(Target);
            buffer.WriteInt32(TargetType);
            buffer.WriteString(Message.Trim());
            buffer.WriteInt32(Colour);
            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendPlayerAttack(int index)
        {
            ByteStream Buffer = new ByteStream(4);

            Buffer.WriteInt32((int)Packets.ServerPackets.SAttack);

            S_General.AddDebug("Sent SMSG: SPlayerAttack");

            Buffer.WriteInt32(index);
            S_NetworkConfig.SendDataToMapBut(index, S_Players.GetPlayerMap(index), ref Buffer.Data, Buffer.Head);
            Buffer.Dispose();
        }

        public static void SendTotalOnlineTo(int index)
        {
            ByteStream Buffer = new ByteStream(4);

            Buffer.WriteInt32((int)Packets.ServerPackets.STotalOnline);

            S_General.AddDebug("Sent SMSG: STotalOnline");

            Buffer.WriteInt32(S_GameLogic.GetPlayersOnline());
            S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);

            Buffer.Dispose();
        }

        public static void SendTotalOnlineToAll()
        {
            ByteStream Buffer = new ByteStream(4);

            Buffer.WriteInt32((int)Packets.ServerPackets.STotalOnline);

            S_General.AddDebug("Sent SMSG: STotalOnline To All");

            Buffer.WriteInt32(S_GameLogic.GetPlayersOnline());
            S_NetworkConfig.SendDataToAll(ref Buffer.Data, Buffer.Head);

            Buffer.Dispose();
        }
    }
}
