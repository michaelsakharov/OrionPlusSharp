
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using System.IO;
using ASFW;
using SFML.Graphics;
using SFML.Window;
using Engine;


namespace Engine
{
	internal sealed class E_Housing
	{
		
#region Globals & Types
		
		internal static int MAX_HOUSES = 100;
		
		internal static int FurnitureCount;
		internal static int FurnitureHouse;
		internal static int FurnitureSelected;
		internal static int HouseTileindex;
		
		internal static HouseRec[] House;
		internal static HouseRec[] HouseConfig;
		internal static FurnitureRec[] Furniture;
		internal static int NumFurniture;
		internal static bool[] House_Changed = new bool[MAX_HOUSES + 1];
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
			
			for (i = 1; i <= MAX_HOUSES; i++)
			{
				HouseConfig[i].ConfigName = buffer.ReadString();
				HouseConfig[i].BaseMap = buffer.ReadInt32();
				HouseConfig[i].MaxFurniture = buffer.ReadInt32();
				HouseConfig[i].Price = buffer.ReadInt32();
			}
			buffer.Dispose();
			
		}
		
		public static void Packet_Furniture(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			FurnitureHouse = buffer.ReadInt32();
			FurnitureCount = buffer.ReadInt32();
			
			Furniture = new E_Housing.FurnitureRec[FurnitureCount + 1];
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
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			for (i = 1; i <= MAX_HOUSES; i++)
			{
				House[i].ConfigName = buffer.ReadString().Trim();
				House[i].BaseMap = buffer.ReadInt32();
				House[i].X = buffer.ReadInt32();
				House[i].Y = buffer.ReadInt32();
				House[i].Price = buffer.ReadInt32();
				House[i].MaxFurniture = buffer.ReadInt32();
			}
			
			HouseEdit = true;
			
			buffer.Dispose();
			
		}
		
#endregion
		
#region Outgoing Packets
		
		internal static void SendRequestEditHouse()
		{
			ByteStream buffer = new ByteStream();
			
			buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.RequestEditHouse);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
			
		}
		
		internal static void SendBuyHouse(byte Accepted)
		{
			ByteStream buffer = new ByteStream();
			buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CBuyHouse);
			buffer.WriteInt32(Accepted);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
		}
		
		internal static void SendInvite(string Name)
		{
			ByteStream buffer = new ByteStream();
			buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CVisit);
			buffer.WriteString(Name);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
		}
		
		internal static void SendVisit(byte Accepted)
		{
			ByteStream buffer = new ByteStream();
			buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CAcceptVisit);
			buffer.WriteInt32(Accepted);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
		}
		
#endregion
		
#region Editor
		
		internal static void HouseEditorInit()
		{
			
			if (FrmHouse.Default.Visible == false)
			{
				return;
			}
			
			E_Globals.Editorindex = FrmHouse.Default.lstIndex.SelectedIndex + 1;
			
			FrmHouse.Default.txtName.Text = House[E_Globals.Editorindex].ConfigName.Trim();
			if (House[E_Globals.Editorindex].BaseMap == 0)
			{
				House[E_Globals.Editorindex].BaseMap = 1;
			}
			FrmHouse.Default.nudBaseMap.Value = House[E_Globals.Editorindex].BaseMap;
			if (House[E_Globals.Editorindex].X == 0)
			{
				House[E_Globals.Editorindex].X = 1;
			}
			FrmHouse.Default.nudX.Value = House[E_Globals.Editorindex].X;
			if (House[E_Globals.Editorindex].Y == 0)
			{
				House[E_Globals.Editorindex].Y = 1;
			}
			FrmHouse.Default.nudY.Value = House[E_Globals.Editorindex].Y;
			FrmHouse.Default.nudPrice.Value = House[E_Globals.Editorindex].Price;
			FrmHouse.Default.nudFurniture.Value = House[E_Globals.Editorindex].MaxFurniture;
			
			House_Changed[E_Globals.Editorindex] = true;
			
		}
		
		internal static void HouseEditorCancel()
		{
			
			E_Globals.Editor = (byte) 0;
			FrmHouse.Default.Close();
			
			ClearChanged_House();
			
		}
		
		internal static void HouseEditorOk()
		{
			int i = 0;
			ByteStream Buffer = new ByteStream();
			int count = 0;
			Buffer = new ByteStream(4);
			
			Buffer.WriteInt32((System.Int32) Packets.EditorPackets.SaveHouses);
			
			for (i = 1; i <= MAX_HOUSES; i++)
			{
				if (House_Changed[i])
				{
					count++;
				}
			}
			
			Buffer.WriteInt32(count);
			
			if (count > 0)
			{
				for (i = 1; i <= MAX_HOUSES; i++)
				{
					if (House_Changed[i])
					{
						Buffer.WriteInt32(i);
						Buffer.WriteString(House[i].ConfigName.Trim());
						Buffer.WriteInt32(House[i].BaseMap);
						Buffer.WriteInt32(House[i].X);
						Buffer.WriteInt32(House[i].Y);
						Buffer.WriteInt32(House[i].Price);
						Buffer.WriteInt32(House[i].MaxFurniture);
					}
				}
			}
			
			E_NetworkConfig.Socket.SendData(Buffer.Data, Buffer.Head);
			Buffer.Dispose();
			FrmHouse.Default.Close();
			E_Globals.Editor = (byte) 0;
			
			ClearChanged_House();
			
		}
		
		internal static void ClearChanged_House()
		{
			
			for (var i = 1; i <= MAX_HOUSES; i++)
			{
				House_Changed[(int) i] = false;
			}
			
			House_Changed = new bool[MAX_HOUSES + 1];
		}
		
#endregion
		
#region Drawing
		
		internal static void CheckFurniture()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Furniture\\" + System.Convert.ToString(i) + E_Globals.GFX_EXT))
			{
				NumFurniture++;
				i++;
			}
			
			if (NumFurniture == 0)
			{
				return;
			}
		}
		
		internal static void DrawFurniture(int index, int Layer)
		{
			int i = 0;
			int ItemNum = 0;
			int X = 0;
			int Y = 0;
			int Width = 0;
			int Height = 0;
			int X1 = 0;
			int Y1 = 0;
			
			ItemNum = Furniture[index].ItemNum;
			
			if (Types.Item[ItemNum].Type != (int) Enums.ItemType.Furniture)
			{
				return;
			}
			
			i = Types.Item[ItemNum].Data2;
			
			if (E_Graphics.FurnitureGFXInfo[i].IsLoaded == false)
			{
				E_Graphics.LoadTexture(i, (byte) 10);
			}
			
			//seeying we still use it, lets update timer
			E_Graphics.SkillIconsGFXInfo[i].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
			
			Width = Types.Item[ItemNum].FurnitureWidth;
			Height = Types.Item[ItemNum].FurnitureHeight;
			
			if (Width > 4)
			{
				Width = 4;
			}
			if (Height > 4)
			{
				Height = 4;
			}
			if (i <= 0 || i > NumFurniture)
			{
				return;
			}
			
			// make sure it's not out of map
			if (Furniture[index].X > E_Types.Map.MaxX)
			{
				return;
			}
			if (Furniture[index].Y > E_Types.Map.MaxY)
			{
				return;
			}
			
			for (X1 = 0; X1 <= Width - 1; X1++)
			{
				for (Y1 = 0; Y1 <= Height; Y1++)
				{
					if (Types.Item[Furniture[index].ItemNum].FurnitureFringe[X1, Y1] == Layer)
					{
						// Set base x + y, then the offset due to size
						X = (Furniture[index].X * 32) + (X1 * 32);
						Y = (Furniture[index].Y * 32 - (Height * 32)) + (Y1 * 32);
						X = E_Graphics.ConvertMapX(X);
						Y = E_Graphics.ConvertMapY(Y);
						
						Sprite tmpSprite = new Sprite(E_Graphics.FurnitureGFX[i]) {
								TextureRect = new IntRect(0 + (X1 * 32), 0 + (Y1 * 32), 32, 32),
								Position = new Vector2f(X, Y)
							};
						E_Graphics.GameWindow.Draw(tmpSprite);
					}
				}
			}
			
		}
		
#endregion
		
	}
}
