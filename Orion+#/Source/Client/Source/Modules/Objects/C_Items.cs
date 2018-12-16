
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.IO;
using System.Windows.Forms;
using ASFW;
using Engine;


namespace Engine
{
	sealed class C_Items
	{
		
#region Globals & Types
		
		// inv drag + drop
		internal static int DragInvSlotNum;
		
		internal static int InvX;
		internal static int InvY;
		
		internal static byte[] InvItemFrame = new byte[Constants.MAX_INV + 1]; // Used for animated items
		internal static int LastItemDesc; // Stores the last item we showed in desc
		
#endregion
		
#region DataBase
		
		internal static void CheckItems()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Items\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				C_Graphics.NumItems++;
				i++;
			}
			
			if (C_Graphics.NumItems == 0)
			{
				return;
			}
		}
		
		internal static void ClearItem(int index)
		{
			Types.Item[index] = new Types.ItemRec();
			for (var x = 0; x <= (int) Enums.StatType.Count - 1; x++)
			{
				Types.Item[index].Add_Stat = new byte[(int) x + 1];
			}
			for (var x = 0; x <= (int) Enums.StatType.Count - 1; x++)
			{
				Types.Item[index].Stat_Req = new byte[(int) x + 1];
			}
			
			Types.Item[index].FurnitureBlocks = new int[4, 4];
			Types.Item[index].FurnitureFringe = new int[4, 4];
			
			Types.Item[index].Name = "";
		}
		
		public static void ClearItems()
		{
			int i = 0;
			
			Types.Item = new Types.ItemRec[Constants.MAX_ITEMS + 1];
			
			for (i = 1; i <= Constants.MAX_ITEMS; i++)
			{
				ClearItem(i);
			}
			
		}
		
#endregion
		
#region Incoming Packets
		
		internal static void Packet_UpdateItem(ref byte[] data)
		{
			int n = 0;
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			n = buffer.ReadInt32();
			
			// Update the item
			Types.Item[n].AccessReq = buffer.ReadInt32();
			
			for (i = 0; i <= (int) Enums.StatType.Count - 1; i++)
			{
				Types.Item[n].Add_Stat[i] = (byte)buffer.ReadInt32();
			}
			
			Types.Item[n].Animation = buffer.ReadInt32();
			Types.Item[n].BindType = (byte) (buffer.ReadInt32());
			Types.Item[n].ClassReq = buffer.ReadInt32();
			Types.Item[n].Data1 = buffer.ReadInt32();
			Types.Item[n].Data2 = buffer.ReadInt32();
			Types.Item[n].Data3 = buffer.ReadInt32();
			Types.Item[n].TwoHanded = buffer.ReadInt32();
			Types.Item[n].LevelReq = buffer.ReadInt32();
			Types.Item[n].Mastery = (byte) (buffer.ReadInt32());
			Types.Item[n].Name = buffer.ReadString().Trim();
			Types.Item[n].Paperdoll = buffer.ReadInt32();
			Types.Item[n].Pic = buffer.ReadInt32();
			Types.Item[n].Price = buffer.ReadInt32();
			Types.Item[n].Rarity = (byte) (buffer.ReadInt32());
			Types.Item[n].Speed = buffer.ReadInt32();
			
			Types.Item[n].Randomize = (byte) (buffer.ReadInt32());
			Types.Item[n].RandomMin = (byte) (buffer.ReadInt32());
			Types.Item[n].RandomMax = (byte) (buffer.ReadInt32());
			
			Types.Item[n].Stackable = (byte) (buffer.ReadInt32());
			Types.Item[n].Description = buffer.ReadString().Trim();
			
			for (i = 0; i <= (int) Enums.StatType.Count - 1; i++)
			{
				Types.Item[n].Stat_Req[i] = (byte)buffer.ReadInt32();
			}
			
			Types.Item[n].Type = (byte) (buffer.ReadInt32());
			Types.Item[n].SubType = (byte) (buffer.ReadInt32());
			
			//Housing
			Types.Item[n].FurnitureWidth = buffer.ReadInt32();
			Types.Item[n].FurnitureHeight = buffer.ReadInt32();
			
			for (var a = 0; a <= 3; a++)
			{
				for (var b = 0; b <= 3; b++)
				{
					Types.Item[n].FurnitureBlocks[(int) a, (int) b] = buffer.ReadInt32();
					Types.Item[n].FurnitureFringe[(int) a, (int) b] = buffer.ReadInt32();
				}
			}
			
			Types.Item[n].KnockBack = (byte) (buffer.ReadInt32());
			Types.Item[n].KnockBackTiles = (byte) (buffer.ReadInt32());
			
			Types.Item[n].Projectile = buffer.ReadInt32();
			Types.Item[n].Ammo = buffer.ReadInt32();
			
			buffer.Dispose();
			
			// changes to inventory, need to clear any drop menu
			FrmGame.Default.pnlCurrency.Visible = false;
			FrmGame.Default.txtCurrency.Text = "";
			C_Variables.TmpCurrencyItem = 0;
			C_Variables.CurrencyMenu = (byte) 0; // clear
			
		}
		
#endregion
		
#region Outgoing Packets
		
		public static void SendRequestItems()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestItems);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
#endregion
		
	}
}
