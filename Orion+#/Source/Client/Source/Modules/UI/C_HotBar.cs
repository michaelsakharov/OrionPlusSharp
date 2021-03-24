
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
	internal sealed class C_HotBar
	{
		internal static int SelHotbarSlot;
		internal static bool SelSkillSlot;
		
		internal const byte MaxHotbar = 7;
		
		//hotbar constants
		internal const byte HotbarTop = 2;
		
		internal const byte HotbarLeft = 2;
		internal const byte HotbarOffsetX = 2;
		
		public struct HotbarRec
		{
			public int Slot;
			public byte SType;
		}
		
		internal static int IsHotBarSlot(float x, float y)
		{
			int returnValue = 0;
			Types.Rect tempRec = new Types.Rect();
			int i = 0;
			
			returnValue = 0;
			
			for (i = 1; i <= MaxHotbar; i++)
			{
				tempRec.Top = C_UpdateUI.HotbarY + HotbarTop;
				tempRec.Bottom = tempRec.Top + C_Constants.PicY;
				tempRec.Left = C_UpdateUI.HotbarX + HotbarLeft + ((HotbarOffsetX + 32) * ((i - 1) % MaxHotbar));
				tempRec.Right = tempRec.Left + C_Constants.PicX;
				
				if (x >= tempRec.Left && x <= tempRec.Right)
				{
					if (y >= tempRec.Top && y <= tempRec.Bottom)
					{
						return i;
						
					}
				}
			}
			
			return returnValue;
		}
		
		internal static void SendSetHotbarSlot(int slot, int num, int type)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSetHotbarSlot);
			
			buffer.WriteInt32(slot);
			buffer.WriteInt32(num);
			buffer.WriteInt32(type);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendDeleteHotbar(int slot)
		{
			ByteStream buffer = new ByteStream(4);
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CDeleteHotbarSlot);
			
			buffer.WriteInt32(slot);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendUseHotbarSlot(int slot)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CUseHotbarSlot);
			
			buffer.WriteInt32(slot);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void DrawHotbar()
		{
			int i = 0;
			int num = 0;
			int pic = 0;
			Rectangle rec = new Rectangle();
			Rectangle recPos = new Rectangle();
			
			C_Graphics.RenderSprite(C_Graphics.HotBarSprite, C_Graphics.GameWindow, C_UpdateUI.HotbarX, C_UpdateUI.HotbarY, 0, 0, C_Graphics.HotBarGfxInfo.Width, C_Graphics.HotBarGfxInfo.Height);
			
			for (i = 1; i <= MaxHotbar; i++)
			{
				if (C_Types.Player[C_Variables.Myindex].Hotbar[i].SType == 1)
				{
					num = C_Variables.PlayerSkills[C_Types.Player[C_Variables.Myindex].Hotbar[i].Slot];
					
					if (num > 0)
					{
						pic = Types.Skill[num].Icon;
						
						if (C_Graphics.SkillIconsGfxInfo[pic].IsLoaded == false)
						{
							C_Graphics.LoadTexture(pic, (byte) 9);
						}
						
						//seeying we still use it, lets update timer
						ref var with_1 = ref C_Graphics.SkillIconsGfxInfo[pic];
						with_1.TextureTimer = C_General.GetTickCount() + 100000;
						
						rec.Y = 0;
						rec.Height = 32;
						rec.X = 0;
						rec.Width = 32;
						
						if (!(C_Variables.SkillCd[i] == 0))
						{
							rec.X = 32;
							rec.Width = 32;
						}
						
						recPos.Y = C_UpdateUI.HotbarY + HotbarTop;
						recPos.Height = C_Constants.PicY;
						recPos.X = C_UpdateUI.HotbarX + HotbarLeft + ((HotbarOffsetX + 32) * (i - 1));
						recPos.Width = C_Constants.PicX;
						
						C_Graphics.RenderSprite(C_Graphics.SkillIconsSprite[pic], C_Graphics.GameWindow, recPos.X, recPos.Y, rec.X, rec.Y, rec.Width, rec.Height);
					}
					
				}
				else if (C_Types.Player[C_Variables.Myindex].Hotbar[i].SType == 2)
				{
					num = C_Variables.PlayerInv[C_Types.Player[C_Variables.Myindex].Hotbar[i].Slot].Num;
					
					if (num > 0)
					{
						pic = Types.Item[num].Pic;
						
						if (C_Graphics.ItemsGfxInfo[pic].IsLoaded == false)
						{
							C_Graphics.LoadTexture(pic, (byte) 4);
						}
						
						//seeying we still use it, lets update timer
						ref var with_4 = ref C_Graphics.ItemsGfxInfo[pic];
						with_4.TextureTimer = C_General.GetTickCount() + 100000;
						
						rec.Y = 0;
						rec.Height = 32;
						rec.X = 0;
						rec.Width = 32;
						
						recPos.Y = C_UpdateUI.HotbarY + HotbarTop;
						recPos.Height = C_Constants.PicY;
						recPos.X = C_UpdateUI.HotbarX + HotbarLeft + ((HotbarOffsetX + 32) * (i - 1));
						recPos.Width = C_Constants.PicX;
						
						C_Graphics.RenderSprite(C_Graphics.ItemsSprite[pic], C_Graphics.GameWindow, recPos.X, recPos.Y, rec.X, rec.Y, rec.Width, rec.Height);
					}
				}
			}
			
		}
		
	}
}
