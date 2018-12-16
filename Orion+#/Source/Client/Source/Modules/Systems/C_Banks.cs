
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using ASFW;
using Engine;


namespace Engine
{
	sealed class C_Banks
	{
		
#region Globals & Types
		
		internal static Types.BankRec Bank;
		
		// Stores the last bank item we showed in desc
		internal static int LastBankDesc;
		
		internal static int InBank;
		
		// bank drag + drop
		internal static int DragBankSlotNum;
		
		internal static int BankX;
		internal static int BankY;
		
#endregion
		
#region Database
		
		public static void ClearBank()
		{
			Bank.Item = new Types.PlayerInvRec[Constants.MAX_BANK + 1];
			Bank.ItemRand = new Types.RandInvRec[Constants.MAX_BANK + 1];
			for (var x = 1; x <= Constants.MAX_BANK; x++)
			{
				Bank.ItemRand[(int) x].Stat = new int[(int) Enums.StatType.Count];
			}
		}
		
#endregion
		
#region Incoming Packets
		
		internal static void Packet_OpenBank(ref byte[] data)
		{
			int i = 0;
			int x = 0;
			ByteStream buffer = new ByteStream(data);
			for (i = 1; i <= Constants.MAX_BANK; i++)
			{
				Bank.Item[i].Num = buffer.ReadInt32();
				Bank.Item[i].Value = buffer.ReadInt32();
				
				Bank.ItemRand[i].Prefix = buffer.ReadString();
				Bank.ItemRand[i].Suffix = buffer.ReadString();
				Bank.ItemRand[i].Rarity = buffer.ReadInt32();
				Bank.ItemRand[i].Damage = buffer.ReadInt32();
				Bank.ItemRand[i].Speed = buffer.ReadInt32();
				
				for (x = 1; x <= (int) Enums.StatType.Count - 1; x++)
				{
					Bank.ItemRand[i].Stat[x] = buffer.ReadInt32();
				}
			}
			
			C_UpdateUI.NeedToOpenBank = true;
			
			buffer.Dispose();
		}
		
#endregion
		
#region Outgoing Packets
		
		internal static void DepositItem(int invslot, int amount)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CDepositItem);
			buffer.WriteInt32(invslot);
			buffer.WriteInt32(amount);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void WithdrawItem(int bankslot, int amount)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CWithdrawItem);
			buffer.WriteInt32(bankslot);
			buffer.WriteInt32(amount);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void ChangeBankSlots(int oldSlot, int newSlot)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CChangeBankSlots);
			buffer.WriteInt32(oldSlot);
			buffer.WriteInt32(newSlot);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void CloseBank()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CCloseBank);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
			InBank = System.Convert.ToInt32(false);
			C_UpdateUI.PnlBankVisible = false;
		}
		
#endregion
		
#region Drawing
		
		public static void DrawBank()
		{
			int i = 0;
			int x = 0;
			int y = 0;
			int itemnum = 0;
			string amount = "";
			Rectangle sRect = new Rectangle();
			Rectangle dRect = new Rectangle();
			int sprite = 0;
			SFML.Graphics.Color colour = new SFML.Graphics.Color();
			
			//first render panel
			C_Graphics.RenderSprite(C_Graphics.BankPanelSprite, C_Graphics.GameWindow, C_UpdateUI.BankWindowX, C_UpdateUI.BankWindowY, 0, 0, C_Graphics.BankPanelGfxInfo.Width, C_Graphics.BankPanelGfxInfo.Height);
			
			//Headertext
			C_Text.DrawText(C_UpdateUI.BankWindowX + 140, C_UpdateUI.BankWindowY + 6, "Your Bank", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 15);
			
			//close
			C_Text.DrawText(C_UpdateUI.BankWindowX + 140, C_UpdateUI.BankWindowY + C_Graphics.BankPanelGfxInfo.Height - 20, "Close Bank", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 15);
			
			for (i = 1; i <= Constants.MAX_BANK; i++)
			{
				itemnum = C_GameLogic.GetBankItemNum((byte) i);
				if (itemnum > 0 && itemnum <= Constants.MAX_ITEMS)
				{
					
					sprite = Types.Item[itemnum].Pic;
					
					if (C_Graphics.ItemsGfxInfo[sprite].IsLoaded == false)
					{
						C_Graphics.LoadTexture(sprite, (byte) 4);
					}
					
					//seeying we still use it, lets update timer
					ref var with_1 = ref C_Graphics.ItemsGfxInfo[sprite];
					with_1.TextureTimer = C_General.GetTickCount() + 100000;
					
					sRect.Y = 0;
					sRect.Height = C_Constants.PicY;
					sRect.X = 0;
					sRect.Width = C_Constants.PicX;
					
					dRect.Y = C_UpdateUI.BankWindowY + C_UpdateUI.BankTop + ((C_UpdateUI.BankOffsetY + 32) * ((i - 1) / C_UpdateUI.BankColumns));
					dRect.Height = C_Constants.PicY;
					dRect.X = C_UpdateUI.BankWindowX + C_UpdateUI.BankLeft + ((C_UpdateUI.BankOffsetX + 32) * ((i - 1) % C_UpdateUI.BankColumns));
					dRect.Width = C_Constants.PicX;
					
					C_Graphics.RenderSprite(C_Graphics.ItemsSprite[sprite], C_Graphics.GameWindow, dRect.X, dRect.Y, sRect.X, sRect.Y, sRect.Width, sRect.Height);
					
					// If item is a stack - draw the amount you have
					if (C_GameLogic.GetBankItemValue((byte) i) > 1)
					{
						y = dRect.Top + 22;
						x = dRect.Left - 4;
						
						amount = System.Convert.ToString(C_GameLogic.GetBankItemValue((byte) i));
						colour = SFML.Graphics.Color.White;
						// Draw currency but with k, m, b etc. using a convertion function
						if (long.Parse(amount) < 1000000)
						{
							colour = SFML.Graphics.Color.White;
						}
						else if (long.Parse(amount) > 1000000 && long.Parse(amount) < 10000000)
						{
							colour = SFML.Graphics.Color.Yellow;
						}
						else if (long.Parse(amount) > 10000000)
						{
							colour = SFML.Graphics.Color.Green;
						}
						
						C_Text.DrawText(x, y, C_GameLogic.ConvertCurrency(System.Convert.ToInt32(amount)), colour, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
					}
				}
			}
			
		}
		
		internal static void DrawBankItem(int x, int y)
		{
			Rectangle rec = new Rectangle();
			
			int itemnum = 0;
			int sprite = 0;
			
			itemnum = C_GameLogic.GetBankItemNum((byte) DragBankSlotNum);
			sprite = Types.Item[C_GameLogic.GetBankItemNum((byte) DragBankSlotNum)].Pic;
			
			if (itemnum > 0 && itemnum <= Constants.MAX_ITEMS)
			{
				
				if (C_Graphics.ItemsGfxInfo[sprite].IsLoaded == false)
				{
					C_Graphics.LoadTexture(sprite, (byte) 4);
				}
				
				//seeying we still use it, lets update timer
				ref var with_1 = ref C_Graphics.ItemsGfxInfo[sprite];
				with_1.TextureTimer = C_General.GetTickCount() + 100000;
				
				rec.Y = 0;
				rec.Height = C_Constants.PicY;
				rec.X = 0;
				rec.Width = C_Constants.PicX;
			}
			
			C_Graphics.RenderSprite(C_Graphics.ItemsSprite[sprite], C_Graphics.GameWindow, x + 16, y + 16, rec.X, rec.Y, rec.Width, rec.Height);
			
		}
		
#endregion
		
	}
}
