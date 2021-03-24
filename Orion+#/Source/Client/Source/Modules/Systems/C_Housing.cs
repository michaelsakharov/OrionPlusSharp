
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.IO;
using System.Windows.Forms;
using Asfw;
using SFML.Graphics;
using SFML.Window;
using Engine;


namespace Engine
{
	internal sealed class C_Housing
	{
		
#region Globals & Types
		
		internal static int MaxHouses = 100;
		
		internal static int FurnitureCount;
		internal static int FurnitureHouse;
		internal static int FurnitureSelected;
		internal static int HouseTileindex;
		
		internal static HouseRec[] House;
		internal static HouseRec[] HouseConfig;
		internal static FurnitureRec[] Furniture;
		internal static int NumFurniture;
		internal static bool[] HouseChanged = new bool[MaxHouses + 1];
		internal static bool HouseEdit;
		
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
			public FurnitureRec[] Furniture;
		}
		
#endregion
		
#region Incoming Packets
		
		public static void Packet_HouseConfigurations(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			for (i = 1; i <= MaxHouses; i++)
			{
				HouseConfig[i].ConfigName = buffer.ReadString();
				HouseConfig[i].BaseMap = buffer.ReadInt32();
				HouseConfig[i].MaxFurniture = buffer.ReadInt32();
				HouseConfig[i].Price = buffer.ReadInt32();
			}
			
			buffer.Dispose();
			
		}
		
		public static void Packet_HouseOffer(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			
			buffer.Dispose();
			
			C_Variables.DialogType = C_Constants.DialogueTypeBuyhome;
			if (HouseConfig[i].MaxFurniture > 0)
			{
				// ask to buy house
				C_Variables.DialogMsg1 = "Would you like to buy the house: " + HouseConfig[i].ConfigName.Trim();
				C_Variables.DialogMsg2 = "Cost: " + System.Convert.ToString(HouseConfig[i].Price);
				C_Variables.DialogMsg3 = "Furniture Limit: " + System.Convert.ToString(HouseConfig[i].MaxFurniture);
			}
			else
			{
				C_Variables.DialogMsg1 = "Would you like to buy the house: " + HouseConfig[i].ConfigName.Trim();
				C_Variables.DialogMsg2 = "Cost: " + System.Convert.ToString(HouseConfig[i].Price);
				C_Variables.DialogMsg3 = "Furniture Limit: None.";
			}
			
			C_Variables.UpdateDialog = true;
			
			buffer.Dispose();
			
		}
		
		public static void Packet_Visit(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			
			C_Variables.DialogType = C_Constants.DialogueTypeVisit;
			
			C_Variables.DialogMsg1 = "You have been invited to visit " + C_Player.GetPlayerName(i).Trim() + "'s house.";
			C_Variables.DialogMsg2 = "";
			C_Variables.DialogMsg3 = "";
			
			buffer.Dispose();
			
			C_Variables.UpdateDialog = true;
			
		}
		
		public static void Packet_Furniture(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			FurnitureHouse = buffer.ReadInt32();
			FurnitureCount = buffer.ReadInt32();
			
			Furniture = new C_Housing.FurnitureRec[FurnitureCount + 1];
			if (FurnitureCount > 0)
			{
				for (i = 1; i <= FurnitureCount; i++)
				{
					Furniture[i].ItemNum = buffer.ReadInt32();
					Furniture[i].X = buffer.ReadInt32();
					Furniture[i].Y = buffer.ReadInt32();
				}
			}
			
			buffer.Dispose();
			
		}
		
		public static void Packet_EditHouses(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			int i = 0;
			for (i = 1; i <= MaxHouses; i++)
			{
				ref var with_1 = ref House[i];
				with_1.ConfigName = buffer.ReadString().Trim();
				with_1.BaseMap = buffer.ReadInt32();
				with_1.X = buffer.ReadInt32();
				with_1.Y = buffer.ReadInt32();
				with_1.Price = buffer.ReadInt32();
				with_1.MaxFurniture = buffer.ReadInt32();
			}
			
			HouseEdit = true;
			
			buffer.Dispose();
			
		}
		
#endregion
		
#region Outgoing Packets
		
		internal static void SendRequestEditHouse()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.RequestEditHouse);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		internal static void SendBuyHouse(byte accepted)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CBuyHouse);
			buffer.WriteInt32(accepted);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendInvite(string name)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CVisit);
			buffer.WriteString(name);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendVisit(byte accepted)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CAcceptVisit);
			buffer.WriteInt32(accepted);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
#endregion
		
#region Drawing
		
		internal static void CheckFurniture()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Furniture\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				NumFurniture++;
				i++;
			}
			
			if (NumFurniture == 0)
			{
				return;
			}
		}
		
		internal static void DrawFurniture(int index, int layer)
		{
			int i = 0;
			int itemNum = 0;
			int x = 0;
			int y = 0;
			int width = 0;
			int height = 0;
			int x1 = 0;
			int y1 = 0;
			
			itemNum = Furniture[index].ItemNum;
			
			if (Types.Item[itemNum].Type != (int) Enums.ItemType.Furniture)
			{
				return;
			}
			
			i = Types.Item[itemNum].Data2;
			
			if (C_Graphics.FurnitureGfxInfo[i].IsLoaded == false)
			{
				C_Graphics.LoadTexture(i, (byte) 10);
			}
			
			//seeying we still use it, lets update timer
			ref var with_1 = ref C_Graphics.FurnitureGfxInfo[i];
			with_1.TextureTimer = C_General.GetTickCount() + 100000;
			
			width = Types.Item[itemNum].FurnitureWidth;
			height = Types.Item[itemNum].FurnitureHeight;
			
			if (width > 4)
			{
				width = 4;
			}
			if (height > 4)
			{
				height = 4;
			}
			if (i <= 0 || i > NumFurniture)
			{
				return;
			}
			
			// make sure it's not out of map
			if (Furniture[index].X > C_Maps.Map.MaxX)
			{
				return;
			}
			if (Furniture[index].Y > C_Maps.Map.MaxY)
			{
				return;
			}
			
			for (x1 = 0; x1 <= width - 1; x1++)
			{
				for (y1 = 0; y1 <= height; y1++)
				{
					if (Types.Item[Furniture[index].ItemNum].FurnitureFringe[x1, y1] == layer)
					{
						// Set base x + y, then the offset due to size
						x = (Furniture[index].X * 32) + (x1 * 32);
						y = (Furniture[index].Y * 32 - (height * 32)) + (y1 * 32);
						x = C_Graphics.ConvertMapX(x);
						y = C_Graphics.ConvertMapY(y);
						
						Sprite tmpSprite = new Sprite(C_Graphics.FurnitureGfx[i]) {
								TextureRect = new IntRect(0 + (x1 * 32), 0 + (y1 * 32), 32, 32),
								Position = new Vector2f(x, y)
							};
						C_Graphics.GameWindow.Draw(tmpSprite);
					}
				}
			}
			
		}
		
#endregion
		
	}
}
