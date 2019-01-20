
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Windows.Forms;
using ASFW;
using Engine;


namespace Engine
{
	sealed class C_NetworkSend
	{
		
		internal static void SendNewAccount(string name, string password)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CNewAccount);
			buffer.WriteString(C_Variables.EKeyPair.EncryptString(name));
			buffer.WriteString(C_Variables.EKeyPair.EncryptString(password));
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
		}
		
		internal static void SendAddChar(int slot, string name, int sex, int classNum, int sprite)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CAddChar);
			buffer.WriteInt32(slot);
			buffer.WriteString(name);
			buffer.WriteInt32(sex);
			buffer.WriteInt32(classNum);
			buffer.WriteInt32(sprite);
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
		}
		
		internal static void SendLogin(string name, string password)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CLogin);
			buffer.WriteString(C_Variables.EKeyPair.EncryptString(name));
			buffer.WriteString(C_Variables.EKeyPair.EncryptString(password));
			buffer.WriteString(C_Variables.EKeyPair.EncryptString(Application.ProductVersion));
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
		}
		
		public static void GetPing()
		{
			ByteStream buffer = new ByteStream(4);
			C_Variables.PingStart = C_General.GetTickCount();
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CCheckPing);
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
		}
		
		internal static void SendPlayerMove()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CPlayerMove);
			buffer.WriteInt32(C_Player.GetPlayerDir(C_Variables.Myindex));
			buffer.WriteInt32(C_Types.Player[C_Variables.Myindex].Moving);
			buffer.WriteInt32(C_Types.Player[C_Variables.Myindex].X);
			buffer.WriteInt32(C_Types.Player[C_Variables.Myindex].Y);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SayMsg(string text)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSayMsg);
			buffer.WriteString(text);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendKick(string name)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CKickPlayer);
			buffer.WriteString(name);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendBan(string name)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CBanPlayer);
			buffer.WriteString(name);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void WarpMeTo(string name)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CWarpMeTo);
			buffer.WriteString(name);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void WarpToMe(string name)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CWarpToMe);
			buffer.WriteString(name);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void WarpTo(int mapNum)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CWarpTo);
			buffer.WriteInt32(mapNum);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendRequestLevelUp()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestLevelUp);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendSpawnItem(int tmpItem, int tmpAmount)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSpawnItem);
			buffer.WriteInt32(tmpItem);
			buffer.WriteInt32(tmpAmount);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendSetSprite(int spriteNum)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSetSprite);
			buffer.WriteInt32(spriteNum);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendSetAccess(string name, byte access)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSetAccess);
			buffer.WriteString(name);
			buffer.WriteInt32(access);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendAttack()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CAttack);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendPlayerDir()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CPlayerDir);
			buffer.WriteInt32(C_Player.GetPlayerDir(C_Variables.Myindex));
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendRequestNpcs()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestNPCS);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendRequestSkills()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestSkills);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendRequestAnimations()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestAnimations);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendTrainStat(byte statNum)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CTrainStat);
			buffer.WriteInt32(statNum);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendRequestPlayerData()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestPlayerData);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void BroadcastMsg(string text)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CBroadcastMsg);
			buffer.WriteString(text.Trim());
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void PlayerMsg(string text, string msgTo)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CPlayerMsg);
			buffer.WriteString(msgTo);
			buffer.WriteString(text);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendWhosOnline()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CWhosOnline);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendMotdChange(string motd)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSetMotd);
			buffer.WriteString(motd);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendBanList()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CBanList);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendChangeInvSlots(int oldSlot, int newSlot)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSwapInvSlots);
			buffer.WriteInt32(oldSlot);
			buffer.WriteInt32(newSlot);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendUseItem(int invNum)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CUseItem);
			buffer.WriteInt32(invNum);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendDropItem(int invNum, int amount)
		{
			ByteStream buffer = new ByteStream(4);
			
			if (System.Convert.ToBoolean(C_Banks.InBank != 0 || C_Shops.InShop != 0))
			{
				return;
			}
			
			// do basic checks
			if (invNum < 1 || invNum > Constants.MAX_INV)
			{
				return;
			}
			if (C_Variables.PlayerInv[invNum].Num < 1 || C_Variables.PlayerInv[invNum].Num > Constants.MAX_ITEMS)
			{
				return;
			}
			if (Types.Item[C_Player.GetPlayerInvItemNum(C_Variables.Myindex, invNum)].Type == (byte)Enums.ItemType.Currency || Types.Item[C_Player.GetPlayerInvItemNum(C_Variables.Myindex, invNum)].Stackable == 1)
			{
				if (amount < 1 || amount > C_Variables.PlayerInv[invNum].Value)
				{
					return;
				}
			}
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CMapDropItem);
			buffer.WriteInt32(invNum);
			buffer.WriteInt32(amount);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void PlayerSearch(int curX, int curY, byte rClick)
		{
			ByteStream buffer = new ByteStream(4);
			
			if (C_GameLogic.IsInBounds())
			{
				buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSearch);
				buffer.WriteInt32(curX);
				buffer.WriteInt32(curY);
				buffer.WriteInt32(rClick);
				C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			}
			
			buffer.Dispose();
		}
		
		internal static void AdminWarp(int x, int y)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CAdminWarp);
			buffer.WriteInt32(x);
			buffer.WriteInt32(y);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendLeaveGame()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CQuit);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendUnequip(int eqNum)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CUnequip);
			buffer.WriteInt32(eqNum);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}

        public static void SendAddAuction(int ItemNum, int Price, int Max)
		{
            ByteStream buffer = new ByteStream(100);
            buffer.WriteInt32((int)Packets.ClientPackets.CAddAuct);
            buffer.WriteInt32(ItemNum);
            buffer.WriteInt32(Price);
            buffer.WriteInt32(Max);

            C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}

        public static void SendGetAuction()
		{
            ByteStream buffer = new ByteStream(100);
            buffer.WriteInt32((int)Packets.ClientPackets.CCheckAuct);

            C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}

        public static void SendBid(int AuctionNum, int Bid)
		{
            ByteStream buffer = new ByteStream(100);
            buffer.WriteInt32((int)Packets.ClientPackets.CBid);
            buffer.WriteInt32(AuctionNum);
            buffer.WriteInt32(Bid);

            C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void ForgetSkill(int skillslot)
		{
			ByteStream buffer = new ByteStream(4);
			
			// Check for subscript out of range
			if (skillslot < 1 || skillslot > Constants.MAX_PLAYER_SKILLS)
			{
				return;
			}
			
			// dont let them forget a skill which is in CD
			if (C_Variables.SkillCd[skillslot] > 0)
			{
				C_Text.AddText("Cannot forget a skill which is cooling down!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			// dont let them forget a skill which is buffered
			if (C_Variables.SkillBuffer == skillslot)
			{
				C_Text.AddText("Cannot forget a skill which you are casting!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			if (C_Variables.PlayerSkills[skillslot] > 0)
			{
				buffer.WriteInt32((System.Int32) Packets.ClientPackets.CForgetSkill);
				buffer.WriteInt32(skillslot);
				C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			}
			else
			{
				C_Text.AddText("No skill found.", (System.Int32) Enums.QColorType.AlertColor);
			}
			
			buffer.Dispose();
		}
		
		internal static void SendRequestMapreport()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CMapReport);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendRequestAdmin()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CAdmin);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendRequestClasses()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestClasses);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendUseEmote(int emote)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CEmote);
			buffer.WriteInt32(emote);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
	}
}
