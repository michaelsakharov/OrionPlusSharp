
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using Asfw;
using Engine;


namespace Engine
{
	sealed class C_Trade
	{
		
#region Globals & Types
		
		internal static int TradeTimer;
		internal static bool TradeRequest;
		internal static bool InTrade;
		internal static Types.PlayerInvRec[] TradeYourOffer = new Types.PlayerInvRec[Constants.MAX_INV + 1];
		internal static Types.PlayerInvRec[] TradeTheirOffer = new Types.PlayerInvRec[Constants.MAX_INV + 1];
		internal static int TradeX;
		internal static int TradeY;
		internal static string TheirWorth;
		internal static string YourWorth;
		
#endregion
		
#region Incoming Packets
		
		public static void Packet_ClearTradeTimer(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			TradeRequest = false;
			TradeTimer = 0;
			
			buffer.Dispose();
		}
		
		public static void Packet_TradeInvite(ref byte[] data)
		{
			int requester = 0;
			ByteStream buffer = new ByteStream(data);
			requester = buffer.ReadInt32();
			
			C_Variables.DialogType = C_Constants.DialogueTypeTrade;
			
			C_Variables.DialogMsg1 = Strings.Get("trade", "tradeinvite", C_Types.Player[requester].Name.Trim());
			
			C_Variables.UpdateDialog = true;
			
			buffer.Dispose();
		}
		
		public static void Packet_Trade(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_UpdateUI.NeedToOpenTrade = true;
			buffer.ReadInt32();
			C_UpdateUI.Tradername = buffer.ReadString().Trim();
			C_UpdateUI.PnlTradeVisible = true;
			
			buffer.Dispose();
		}
		
		public static void Packet_CloseTrade(ref byte[] data)
		{
			C_UpdateUI.NeedtoCloseTrade = true;
		}
		
		public static void Packet_TradeUpdate(ref byte[] data)
		{
			int datatype;
			ByteStream buffer = new ByteStream(data);
			datatype = buffer.ReadInt32();
			
			if (datatype == 0) // ours!
			{
				for (var i = 1; i <= Constants.MAX_INV; i++)
				{
					TradeYourOffer[(int) i].Num = buffer.ReadInt32();
					TradeYourOffer[(int) i].Value = buffer.ReadInt32();
				}
				YourWorth = Strings.Get("trade", "tradeworth", buffer.ReadInt32());
			}
			else if (datatype == 1) //theirs
			{
				for (var i = 1; i <= Constants.MAX_INV; i++)
				{
					TradeTheirOffer[(int) i].Num = buffer.ReadInt32();
					TradeTheirOffer[(int) i].Value = buffer.ReadInt32();
				}
				TheirWorth = "Total Worth: " + System.Convert.ToString(buffer.ReadInt32()) + "g";
			}
			
			C_UpdateUI.NeedtoUpdateTrade = true;
			
			buffer.Dispose();
		}
		
		public static void Packet_TradeStatus(ref byte[] data)
		{
			int tradestatus = 0;
			ByteStream buffer = new ByteStream(data);
			tradestatus = buffer.ReadInt32();
			
			switch (tradestatus)
			{
				case 0: // clear
					break;
					//frmMainGame.lblTradeStatus.Text = ""
				case 1: // they've accepted
					C_Text.AddText(Strings.Get("trade", "tradestatusok"), (System.Int32) Enums.ColorType.White);
					break;
				case 2: // you've accepted
					C_Text.AddText(Strings.Get("trade", "tradestatuswait"), (System.Int32) Enums.ColorType.White);
					break;
			}
			
			buffer.Dispose();
		}
		
#endregion
		
#region Outgoing Packets
		
		internal static void AcceptTrade()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CAcceptTrade);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void DeclineTrade()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CDeclineTrade);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendTradeRequest(string name)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CTradeInvite);
			
			buffer.WriteString(name);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		public static void SendTradeInviteAccept(byte awnser)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CTradeInviteAccept);
			
			buffer.WriteInt32(awnser);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		internal static void TradeItem(int invslot, int amount)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CTradeItem);
			buffer.WriteInt32(invslot);
			buffer.WriteInt32(amount);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void UntradeItem(int invslot)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CUntradeItem);
			buffer.WriteInt32(invslot);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
#endregion
		
#region Drawing
		
		public static void DrawTrade()
		{
			int i = 0;
			int x = 0;
			int y = 0;
			int itemnum = 0;
			int itempic = 0;
			string amount = "";
			Rectangle rec = new Rectangle();
			Rectangle recPos = new Rectangle();
			SFML.Graphics.Color colour = new SFML.Graphics.Color();
			
			amount = System.Convert.ToString(0);
			colour = SFML.Graphics.Color.White;
			
			if (!C_Variables.InGame)
			{
				return;
			}
			
			//first render panel
			C_Graphics.RenderSprite(C_Graphics.TradePanelSprite, C_Graphics.GameWindow, C_UpdateUI.TradeWindowX, C_UpdateUI.TradeWindowY, 0, 0, C_Graphics.TradePanelGfxInfo.Width, C_Graphics.TradePanelGfxInfo.Height);
			
			//Headertext
			C_Text.DrawText(C_UpdateUI.TradeWindowX + 70, C_UpdateUI.TradeWindowY + 6, "Your Offer", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 15);
			
			C_Text.DrawText(C_UpdateUI.TradeWindowX + 260, C_UpdateUI.TradeWindowY + 6, C_UpdateUI.Tradername + "'s Offer.", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 15);
			
			for (i = 1; i <= Constants.MAX_INV; i++)
			{
				// blt your own offer
				itemnum = C_Player.GetPlayerInvItemNum(C_Variables.Myindex, TradeYourOffer[i].Num);
				
				if (itemnum > 0 && itemnum <= Constants.MAX_ITEMS)
				{
					itempic = Types.Item[itemnum].Pic;
					
					if (itempic > 0 && itempic <= C_Graphics.NumItems)
					{
						
						if (C_Graphics.ItemsGfxInfo[itempic].IsLoaded == false)
						{
							C_Graphics.LoadTexture(itempic, (byte) 4);
						}
						
						//seeying we still use it, lets update timer
						ref var with_1 = ref C_Graphics.ItemsGfxInfo[itempic];
						with_1.TextureTimer = C_General.GetTickCount() + 100000;
						
						rec.Y = 0;
						rec.Height = C_Constants.PicY;
						rec.X = 0;
						rec.Width = C_Constants.PicX;
						
						recPos.Y = C_UpdateUI.TradeWindowY + C_UpdateUI.OurTradeY + C_UpdateUI.InvTop + ((C_UpdateUI.InvOffsetY + 32) * ((i - 1) / C_UpdateUI.InvColumns));
						recPos.Height = C_Constants.PicY;
						recPos.X = C_UpdateUI.TradeWindowX + C_UpdateUI.OurTradeX + C_UpdateUI.InvLeft + ((C_UpdateUI.InvOffsetX + 32) * ((i - 1) % C_UpdateUI.InvColumns));
						recPos.Width = C_Constants.PicX;
						
						C_Graphics.RenderSprite(C_Graphics.ItemsSprite[itempic], C_Graphics.GameWindow, recPos.X, recPos.Y, rec.X, rec.Y, rec.Width, rec.Height);
						
						// If item is a stack - draw the amount you have
						if (TradeYourOffer[i].Value >= 1)
						{
							y = recPos.Top + 22;
							x = recPos.Left - 4;
							
							// Draw currency but with k, m, b etc. using a convertion function
							if (double.Parse(amount) < 1000000)
							{
								colour = SFML.Graphics.Color.White;
							}
							else if (double.Parse(amount) > 1000000 && long.Parse(amount) < 10000000)
							{
								colour = SFML.Graphics.Color.Yellow;
							}
							else if (double.Parse(amount) > 10000000)
							{
								colour = SFML.Graphics.Color.Green;
							}
							
							amount = System.Convert.ToString(TradeYourOffer[i].Value);
							C_Text.DrawText(x, y, C_GameLogic.ConvertCurrency(System.Convert.ToInt32(amount)), colour, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
						}
					}
				}
			}
			
			C_Text.DrawText(C_UpdateUI.TradeWindowX + 8, C_UpdateUI.TradeWindowY + 288, YourWorth, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 13);
			
			for (i = 1; i <= Constants.MAX_INV; i++)
			{
				// blt their offer
				itemnum = TradeTheirOffer[i].Num;
				//itemnum = GetPlayerInvItemNum(MyIndex, TradeYourOffer(i).Num)
				if (itemnum > 0 && itemnum <= Constants.MAX_ITEMS)
				{
					itempic = Types.Item[itemnum].Pic;
					
					if (itempic > 0 && itempic <= C_Graphics.NumItems)
					{
						if (C_Graphics.ItemsGfxInfo[itempic].IsLoaded == false)
						{
							C_Graphics.LoadTexture(itempic, (byte) 4);
						}
						
						//seeying we still use it, lets update timer
						ref var with_4 = ref C_Graphics.ItemsGfxInfo[itempic];
						with_4.TextureTimer = C_General.GetTickCount() + 100000;
						
						rec.Y = 0;
						rec.Height = C_Constants.PicY;
						rec.X = 0;
						rec.Width = C_Constants.PicX;
						
						recPos.Y = C_UpdateUI.TradeWindowY + C_UpdateUI.TheirTradeY + C_UpdateUI.InvTop + ((C_UpdateUI.InvOffsetY + 32) * ((i - 1) / C_UpdateUI.InvColumns));
						recPos.Height = C_Constants.PicY;
						recPos.X = C_UpdateUI.TradeWindowX + C_UpdateUI.TheirTradeX + C_UpdateUI.InvLeft + ((C_UpdateUI.InvOffsetX + 32) * ((i - 1) % C_UpdateUI.InvColumns));
						recPos.Width = C_Constants.PicX;
						
						C_Graphics.RenderSprite(C_Graphics.ItemsSprite[itempic], C_Graphics.GameWindow, recPos.X, recPos.Y, rec.X, rec.Y, rec.Width, rec.Height);
						
						// If item is a stack - draw the amount they have
						if (TradeTheirOffer[i].Value >= 1)
						{
							y = recPos.Top + 22;
							x = recPos.Left - 4;
							
							// Draw currency but with k, m, b etc. using a convertion function
							if (double.Parse(amount) < 1000000)
							{
								colour = SFML.Graphics.Color.White;
							}
							else if (double.Parse(amount) > 1000000 && long.Parse(amount) < 10000000)
							{
								colour = SFML.Graphics.Color.Yellow;
							}
							else if (double.Parse(amount) > 10000000)
							{
								colour = SFML.Graphics.Color.Green;
							}
							
							amount = System.Convert.ToString(TradeTheirOffer[i].Value);
							C_Text.DrawText(x, y, amount, colour, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
						}
					}
				}
			}
			
			C_Text.DrawText(C_UpdateUI.TradeWindowX + 208, C_UpdateUI.TradeWindowY + 288, TheirWorth, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 13);
			
			//render accept button
			C_Graphics.DrawButton("Accept Trade", C_UpdateUI.TradeWindowX + C_UpdateUI.TradeButtonAcceptX, C_UpdateUI.TradeWindowY + C_UpdateUI.TradeButtonAcceptY, (byte) 0);
			
			//render decline button
			C_Graphics.DrawButton("Decline Trade", C_UpdateUI.TradeWindowX + C_UpdateUI.TradeButtonDeclineX, C_UpdateUI.TradeWindowY + C_UpdateUI.TradeButtonDeclineY, (byte) 0);
		}
		
#endregion
		
	}
}
