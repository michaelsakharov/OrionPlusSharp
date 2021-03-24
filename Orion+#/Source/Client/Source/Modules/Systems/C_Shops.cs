
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
	sealed class C_Shops
	{
		
#region Globals & Types
		
		internal static int InShop; // is the player in a shop
		internal static byte ShopAction; // stores the current shop action
		
#endregion
		
#region DataBase
		
		public static void ClearShop(int index)
		{
			Types.Shop[index] = new Types.ShopRec {
					Name = ""
				};
			Types.Shop[index].TradeItem = new Types.TradeItemRec[Constants.MAX_TRADES + 1];
			for (var x = 0; x <= Constants.MAX_TRADES; x++)
			{
				Types.Shop[index].TradeItem = new Types.TradeItemRec[(int) x + 1];
			}
		}
		
		public static void ClearShops()
		{
			int i = 0;
			
			Types.Shop = new Types.ShopRec[Constants.MAX_SHOPS + 1];
			
			for (i = 1; i <= Constants.MAX_SHOPS; i++)
			{
				ClearShop(i);
			}
			
		}
		
#endregion
		
#region Incoming Packets
		
		internal static void Packet_OpenShop(ref byte[] data)
		{
			int shopnum = 0;
			ByteStream buffer = new ByteStream(data);
			shopnum = buffer.ReadInt32();
			
			C_UpdateUI.NeedToOpenShop = true;
			C_UpdateUI.NeedToOpenShopNum = shopnum;
			
			buffer.Dispose();
		}
		
		internal static void Packet_ResetShopAction(ref byte[] data)
		{
			ShopAction = (byte) 0;
		}
		
		internal static void Packet_UpdateShop(ref byte[] data)
		{
			int shopnum = 0;
			ByteStream buffer = new ByteStream(data);
			shopnum = buffer.ReadInt32();
			
			Types.Shop[shopnum].BuyRate = buffer.ReadInt32();
			Types.Shop[shopnum].Name = buffer.ReadString().Trim();
			Types.Shop[shopnum].Face = (byte) (buffer.ReadInt32());
			
			for (var i = 0; i <= Constants.MAX_TRADES; i++)
			{
				Types.Shop[shopnum].TradeItem[(int) i].CostItem = buffer.ReadInt32();
				Types.Shop[shopnum].TradeItem[(int) i].CostValue = buffer.ReadInt32();
				Types.Shop[shopnum].TradeItem[(int) i].Item = buffer.ReadInt32();
				Types.Shop[shopnum].TradeItem[(int) i].ItemValue = buffer.ReadInt32();
			}
			
			if (ReferenceEquals(Types.Shop[shopnum].Name, null))
			{
				Types.Shop[shopnum].Name = "";
			}
			
			buffer.Dispose();
		}
		
#endregion
		
#region Outgoing Packets
		
		internal static void SendRequestShops()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestShops);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void BuyItem(int shopslot)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CBuyItem);
			buffer.WriteInt32(shopslot);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SellItem(int invslot)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSellItem);
			buffer.WriteInt32(invslot);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
#endregion
		
#region Drawing
		
		public static void DrawShop()
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
			
			if (!C_Variables.InGame || C_UpdateUI.PnlShopVisible == false)
			{
				return;
			}
			
			//first render panel
			C_Graphics.RenderSprite(C_Graphics.ShopPanelSprite, C_Graphics.GameWindow, C_UpdateUI.ShopWindowX, C_UpdateUI.ShopWindowY, 0, 0, C_Graphics.ShopPanelGfxInfo.Width, C_Graphics.ShopPanelGfxInfo.Height);
			
			if (Types.Shop[InShop].Face > 0)
			{
				//render face
				if (C_Graphics.FacesGfxInfo[Types.Shop[InShop].Face].IsLoaded == false)
				{
					C_Graphics.LoadTexture(Types.Shop[InShop].Face, (byte) 7);
				}
				
				//seeying we still use it, lets update timer
				ref var with_1 = ref C_Graphics.FacesGfxInfo[Types.Shop[InShop].Face];
				with_1.TextureTimer = C_General.GetTickCount() + 100000;
				C_Graphics.RenderSprite(C_Graphics.FacesSprite[Types.Shop[InShop].Face], C_Graphics.GameWindow, C_UpdateUI.ShopWindowX + C_UpdateUI.ShopFaceX, C_UpdateUI.ShopWindowY + C_UpdateUI.ShopFaceY, 0, 0, C_Graphics.FacesGfxInfo[Types.Shop[InShop].Face].Width, C_Graphics.FacesGfxInfo[Types.Shop[InShop].Face].Height);
			}
			
			//draw text
			C_Text.DrawText(C_UpdateUI.ShopWindowX + C_UpdateUI.ShopLeft, C_UpdateUI.ShopWindowY + 10, Types.Shop[InShop].Name.Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 15);
			
			C_Text.DrawText(C_UpdateUI.ShopWindowX + 10, C_UpdateUI.ShopWindowY + 10, "Hello, and welcome", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 15);
			C_Text.DrawText(C_UpdateUI.ShopWindowX + 10, C_UpdateUI.ShopWindowY + 25, "to the shop!", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow, (byte) 15);
			
			//render buy button
			if (C_Variables.CurMouseX > C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonBuyX && C_Variables.CurMouseX < C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonBuyX + C_Graphics.ButtonGfxInfo.Width &
					C_Variables.CurMouseY > C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonBuyY && C_Variables.CurMouseY < C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonBuyY + C_Graphics.ButtonGfxInfo.Height)
					{
					C_Graphics.DrawButton("Buy Item", C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonBuyX, C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonBuyY, (byte) 1);
			}
			else
			{
				C_Graphics.DrawButton("Buy Item", C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonBuyX, C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonBuyY, (byte) 0);
			}
			
			//render sell button
			if (C_Variables.CurMouseX > C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonSellX && C_Variables.CurMouseX < C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonSellX + C_Graphics.ButtonGfxInfo.Width &
					C_Variables.CurMouseY > C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonSellY && C_Variables.CurMouseY < C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonSellY + C_Graphics.ButtonGfxInfo.Height)
					{
					C_Graphics.DrawButton("Sell Item", C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonSellX, C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonSellY, (byte) 1);
			}
			else
			{
				C_Graphics.DrawButton("Sell Item", C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonSellX, C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonSellY, (byte) 0);
			}
			
			//render close button
			if (C_Variables.CurMouseX > C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonCloseX && C_Variables.CurMouseX < C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonCloseX + C_Graphics.ButtonGfxInfo.Width &
					C_Variables.CurMouseY > C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonCloseY && C_Variables.CurMouseY < C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonCloseY + C_Graphics.ButtonGfxInfo.Height)
					{
					C_Graphics.DrawButton("Close Shop", C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonCloseX, C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonCloseY, (byte) 1);
			}
			else
			{
				C_Graphics.DrawButton("Close Shop", C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonCloseX, C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonCloseY, (byte) 0);
			}
			
			for (i = 1; i <= Constants.MAX_TRADES; i++)
			{
				itemnum = Types.Shop[InShop].TradeItem[i].Item;
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
						ref var with_2 = ref C_Graphics.ItemsGfxInfo[itempic];
						with_2.TextureTimer = C_General.GetTickCount() + 100000;
						
						rec.Y = 0;
						rec.Height = 32;
						rec.X = 0;
						rec.Width = 32;
						
						recPos.Y = C_UpdateUI.ShopWindowY + C_UpdateUI.ShopTop + ((C_UpdateUI.ShopOffsetY + 32) * ((i - 1) / C_UpdateUI.ShopColumns));
						recPos.Height = C_Constants.PicY;
						recPos.X = C_UpdateUI.ShopWindowX + C_UpdateUI.ShopLeft + ((C_UpdateUI.ShopOffsetX + 1 + 32) * ((i - 1) % C_UpdateUI.ShopColumns));
						recPos.Width = C_Constants.PicX;
						
						C_Graphics.RenderSprite(C_Graphics.ItemsSprite[itempic], C_Graphics.GameWindow, recPos.X, recPos.Y, rec.X, rec.Y, rec.Width, rec.Height);
						
						// If item is a stack - draw the amount you have
						if (Types.Shop[InShop].TradeItem[i].ItemValue > 1)
						{
							y = recPos.Top + 22;
							x = recPos.Left - 4;
							amount = System.Convert.ToString(Types.Shop[InShop].TradeItem[i].ItemValue);
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
			
		}
		
#endregion
		
	}
}
