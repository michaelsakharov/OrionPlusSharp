
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using Microsoft.VisualBasic.CompilerServices;
using Engine;

namespace Engine
{
	sealed class E_AutoMap
	{
		// Automapper System
		// Version: 1.0
		// Author: Lucas Tardivo (boasfesta)
		// Map analysis and tips: Richard Johnson, Luan Meireles (Alenzinho)
		
#region Globals And Types
		
		internal static int MapStart = 1;
		internal static int MapSize = 4;
		internal static int MapX = 50;
		internal static int MapY = 50;
		
		internal static int SandBorder = 4;
		internal static int DetailFreq = 10;
		internal static int ResourceFreq = 20;
		
		internal static bool DetailsChecked = true;
		internal static bool PathsChecked = true;
		internal static bool RiversChecked = true;
		internal static bool MountainsChecked = true;
		internal static bool OverGrassChecked = true;
		internal static bool ResourcesChecked = true;
		
		public enum TilePrefab
		{
			Water = 1,
			Sand,
			Grass,
			Passing,
			Overgrass,
			River,
			Mountain,
			Count
		}
		
		//Distance between mountains and the map limit, so the player can walk freely when teleport between maps
		private const byte MountainBorder = 5;
		
		internal static Types.TileRec[] Tile = new Types.TileRec[(int) TilePrefab.Count];
		internal static DetailRec[] Detail;
		internal static string ResourcesNum;
		private static string[] Resources;
		//Private ActualMap As Integer
		
		public enum MountainTile
		{
			UpLeftBorder = 0,
			UpMidBorder,
			UpRightBorder,
			MidLeftBorder,
			Middle,
			MidRightBorder,
			BottomLeftBorder,
			BottomMidBorder,
			BottomRightBorder,
			LeftBody,
			MiddleBody,
			RightBody,
			LeftFoot,
			MiddleFoot,
			RightFoot
		}
		
		public enum MapPrefab
		{
			Undefined = 0,
			UpLeftQuarter,
			UpBorder,
			UpRightQuarter,
			RightBorder,
			DownRightQuarter,
			BottomBorder,
			DownLeftQuarter,
			LeftBorder,
			Common
		}
		
		public struct DetailRec
		{
			public byte DetailBase;
			public Types.TileRec Tile;
		}
		
		public struct MapOrientationRec
		{
			public int Prefab;
			public int TileStartX;
			public int TileStartY;
			public int TileEndX;
			public int TileEndY;
			public TilePrefab[,] Tile;
		}
		
#endregion
		
#region Loading Functions
		
		public static void OpenAutomapper()
		{
			LoadTilePrefab();
			FrmAutoMapper.Default.Visible = true;
		}
		
		public static void LoadTilePrefab()
		{
			int Prefab = 0;
			int Layer = 0;
			
			XmlClass myXml = new XmlClass() {
					Filename = System.IO.Path.Combine(Application.StartupPath, "Data", "AutoMapper.xml"),
					Root = "Options"
				};
			
			myXml.LoadXml();
			
			Tile = new Types.TileRec[(int) TilePrefab.Count];
			for (Prefab = 1; Prefab <= (int) TilePrefab.Count - 1; Prefab++)
			{
				
				Tile[Prefab].Layer = new Types.TileDataRec[(int) Enums.LayerType.Count];
				for (Layer = 1; Layer <= (int) Enums.LayerType.Count - 1; Layer++)
				{
					Tile[Prefab].Layer[Layer].Tileset = (byte) (Conversion.Val(myXml.ReadString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "Tileset")));
					Tile[Prefab].Layer[Layer].X = (byte) (Conversion.Val(myXml.ReadString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "X")));
					Tile[Prefab].Layer[Layer].Y = (byte) (Conversion.Val(myXml.ReadString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "Y")));
					Tile[Prefab].Layer[Layer].AutoTile = (byte) (Conversion.Val(myXml.ReadString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "Autotile")));
				}
				Tile[Prefab].Type = (byte) (Conversion.Val(myXml.ReadString("Prefab" + System.Convert.ToString(Prefab), "Type")));
			}
			
			ResourcesNum = myXml.ReadString("Resources", "ResourcesNum");
			Resources = ResourcesNum.Split(';');
			
			myXml.CloseXml(false);
		}
		
		public static void LoadDetail(TilePrefab Prefab, int Tileset, int X, int Y, int TileType = 0, int EndX = 0, int EndY = 0)
		{
			if (EndX == 0)
			{
				EndX = X;
			}
			if (EndY == 0)
			{
				EndY = Y;
			}
			
			int pX = 0;
			int pY = 0;
			for (pX = X; pX <= EndX; pX++)
			{
				for (pY = Y; pY <= EndY; pY++)
				{
					AddDetail(Prefab, Tileset, pX, pY, TileType);
				}
			}
			
		}
		
		public static void AddDetail(TilePrefab Prefab, int Tileset, int X, int Y, int TileType)
		{
			int DetailCount = 0;
			DetailCount = (Detail.Length - 1) + 1;
			
			Array.Resize(ref Detail, DetailCount + 1);
			Array.Resize(ref Detail[DetailCount].Tile.Layer, (int) Enums.LayerType.Count);
			
			Detail[DetailCount].DetailBase = (byte)Prefab;
			Detail[DetailCount].Tile.Type = (byte) TileType;
			Detail[DetailCount].Tile.Layer[3].Tileset = (byte) Tileset;
			Detail[DetailCount].Tile.Layer[3].X = (byte) X;
			Detail[DetailCount].Tile.Layer[3].Y = (byte) Y;
		}
		
		public static void LoadDetails()
		{
			Detail = new E_AutoMap.DetailRec[2];
			
			//Detail config area
			//Use: LoadDetail TilePrefab, Tileset, StartTilesetX, StartTilesetY, TileType, EndTilesetX, EndTilesetY
			LoadDetail(TilePrefab.Grass, 9, 0, 0, (System.Int32) Enums.TileType.None, 7, 7);
			LoadDetail(TilePrefab.Grass, 9, 0, 10, (System.Int32) Enums.TileType.None, 6, 15);
			LoadDetail(TilePrefab.Grass, 9, 0, 13, (System.Int32) Enums.TileType.None, 7, 14);
			LoadDetail(TilePrefab.Sand, 10, 0, 13, (System.Int32) Enums.TileType.None, 7, 14);
			LoadDetail(TilePrefab.Sand, 11, 0, 0, (System.Int32) Enums.TileType.None, 1, 1);
		}
		
#endregion
		
#region Incoming Packets
		
		public static void Packet_AutoMapper(ref byte[] data)
		{
			int Layer = 0;
			Asfw.ByteStream buffer = new Asfw.ByteStream(data);
			MapStart = buffer.ReadInt32();
			MapSize = buffer.ReadInt32();
			MapX = buffer.ReadInt32();
			MapY = buffer.ReadInt32();
			SandBorder = buffer.ReadInt32();
			DetailFreq = buffer.ReadInt32();
			ResourceFreq = buffer.ReadInt32();
			
			XmlClass myXml = new XmlClass() {
					Filename = System.IO.Path.Combine(Application.StartupPath, "Data", "AutoMapper.xml"),
					Root = "Options"
				};
			
			myXml.LoadXml();
			
			myXml.WriteString("Resources", "ResourcesNum", buffer.ReadString());
			
			for (var Prefab = 1; Prefab <= (int) TilePrefab.Count - 1; Prefab++)
			{
				Tile[(int) Prefab].Layer = new Types.TileDataRec[(int) Enums.LayerType.Count];
				
				Layer = buffer.ReadInt32();
				myXml.WriteString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "Tileset", System.Convert.ToString(buffer.ReadInt32()));
				myXml.WriteString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "X", System.Convert.ToString(buffer.ReadInt32()));
				myXml.WriteString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "Y", System.Convert.ToString(buffer.ReadInt32()));
				myXml.WriteString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "Autotile", System.Convert.ToString(buffer.ReadInt32()));
				
				myXml.WriteString("Prefab" + System.Convert.ToString(Prefab), "Type", System.Convert.ToString(buffer.ReadInt32()));
			}
			
			myXml.CloseXml(true);
			
			buffer.Dispose();
			
			E_Globals.InitAutoMapper = true;
			
		}
		
#endregion
		
#region Outgoing Packets
		
		internal static void SendRequestAutoMapper()
		{
			Asfw.ByteStream buffer = new Asfw.ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.RequestAutoMap);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendSaveAutoMapper()
		{
			XmlClass myXml = new XmlClass() {
					Filename = Application.StartupPath + "\\Data\\AutoMapper.xml",
					Root = "Options"
				};
			Asfw.ByteStream buffer = new Asfw.ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.SaveAutoMap);
			
			buffer.WriteInt32(MapStart);
			buffer.WriteInt32(MapSize);
			buffer.WriteInt32(MapX);
			buffer.WriteInt32(MapY);
			buffer.WriteInt32(SandBorder);
			buffer.WriteInt32(DetailFreq);
			buffer.WriteInt32(ResourceFreq);
			
			myXml.LoadXml();
			
			//send xml info
			buffer.WriteString(myXml.ReadString("Resources", "ResourcesNum"));
			
			for (var Prefab = 1; Prefab <= (int) TilePrefab.Count - 1; Prefab++)
			{
				for (var Layer = 1; Layer <= (int) Enums.LayerType.Count - 1; Layer++)
				{
					if (Conversion.Val(myXml.ReadString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "Tileset")) > 0)
					{
						buffer.WriteInt32(System.Convert.ToInt32(Layer));
						buffer.WriteInt32(System.Convert.ToInt32(Conversion.Val(myXml.ReadString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "Tileset"))));
						buffer.WriteInt32(System.Convert.ToInt32(Conversion.Val(myXml.ReadString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "X"))));
						buffer.WriteInt32(System.Convert.ToInt32(Conversion.Val(myXml.ReadString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "Y"))));
						buffer.WriteInt32(System.Convert.ToInt32(Conversion.Val(myXml.ReadString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "Autotile"))));
					}
				}
				buffer.WriteInt32(System.Convert.ToInt32(Conversion.Val(myXml.ReadString("Prefab" + System.Convert.ToString(Prefab), "Type"))));
			}
			
			myXml.CloseXml(false);
			
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
#endregion
		
	}
}
