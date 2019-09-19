
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using Engine;
using SFML.Graphics;

namespace Engine
{
	internal sealed class C_AutoTiles
	{
		
#region Globals and Types
		
		// Autotiles
		internal const byte AutoInner = 1;
		
		internal const byte AutoOuter = 2;
		internal const byte AutoHorizontal = 3;
		internal const byte AutoVertical = 4;
		internal const byte AutoFill = 5;
		
		// Autotile types
		internal const byte AutotileNone = 0;
		
		internal const byte AutotileNormal = 1;
		internal const byte AutotileFake = 2;
		internal const byte AutotileAnim = 3;
		internal const byte AutotileCliff = 4;
		internal const byte AutotileWaterfall = 5;
		
		// Rendering
		internal const int RenderStateNone = 0;
		
		internal const int RenderStateNormal = 1;
		internal const int RenderStateAutotile = 2;
		
		// autotiling
		internal static PointRec[] AutoIn = new PointRec[5];
		
		internal static PointRec[] AutoNw = new PointRec[5];
		internal static PointRec[] AutoNe = new PointRec[5];
		internal static PointRec[] AutoSw = new PointRec[5];
		internal static PointRec[] AutoSe = new PointRec[5];
		
		// Map animations
		internal static int WaterfallFrame;
		
		internal static int AutoTileFrame;
		
		internal static AutotileRec[,] Autotile;
		
		public struct PointRec
		{
			public int X;
			public int Y;
		}
		
		public struct QuarterTileRec
		{
			public PointRec[] QuarterTile; //1 To 4
			public byte RenderState;
			public int[] SrcX; //1 To 4
			public int[] SrcY; //1 To 4
		}
		
		public struct AutotileRec
		{
			public QuarterTileRec[] Layer; //1 To MapLayer.Count - 1
			public QuarterTileRec[] ExLayer; //1 To ExMapLayer.Count - 1
		}
		
#endregion
		
		public static void ClearAutotiles()
		{
			int x = 0;
			int y = 0;
			int i = 0;
			
			Autotile = new C_AutoTiles.AutotileRec[C_Maps.Map.MaxX + 1, C_Maps.Map.MaxY + 1];
			
			for (x = 0; x <= C_Maps.Map.MaxX; x++)
			{
				for (y = 0; y <= C_Maps.Map.MaxY; y++)
				{
					Autotile[x, y].Layer = new C_AutoTiles.QuarterTileRec[(int) Enums.LayerType.Count];
					for (i = 0; i <= (int) Enums.LayerType.Count - 1; i++)
					{
						Autotile[x, y].Layer[i].SrcX = new int[5];
						Autotile[x, y].Layer[i].SrcY = new int[5];
						Autotile[x, y].Layer[i].QuarterTile = new C_AutoTiles.PointRec[5];
					}
				}
			}
		}
		
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		//   All of this code is for auto tiles and the math behind generating them.
		//\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
		internal static void PlaceAutotile(int layerNum, int x, int y, byte tileQuarter, string autoTileLetter)
		{
			
			if (layerNum > (int) Enums.LayerType.Count - 1)
			{
				layerNum = layerNum - ((int) Enums.LayerType.Count - 1);
				ref var with_1 = ref Autotile[x, y].ExLayer[layerNum].QuarterTile[tileQuarter];
				switch (autoTileLetter)
				{
					case "a":
						with_1.X = AutoIn[1].X;
						with_1.Y = AutoIn[1].Y;
						break;
					case "b":
						with_1.X = AutoIn[2].X;
						with_1.Y = AutoIn[2].Y;
						break;
					case "c":
						with_1.X = AutoIn[3].X;
						with_1.Y = AutoIn[3].Y;
						break;
					case "d":
						with_1.X = AutoIn[4].X;
						with_1.Y = AutoIn[4].Y;
						break;
					case "e":
						with_1.X = AutoNw[1].X;
						with_1.Y = AutoNw[1].Y;
						break;
					case "f":
						with_1.X = AutoNw[2].X;
						with_1.Y = AutoNw[2].Y;
						break;
					case "g":
						with_1.X = AutoNw[3].X;
						with_1.Y = AutoNw[3].Y;
						break;
					case "h":
						with_1.X = AutoNw[4].X;
						with_1.Y = AutoNw[4].Y;
						break;
					case "i":
						with_1.X = AutoNe[1].X;
						with_1.Y = AutoNe[1].Y;
						break;
					case "j":
						with_1.X = AutoNe[2].X;
						with_1.Y = AutoNe[2].Y;
						break;
					case "k":
						with_1.X = AutoNe[3].X;
						with_1.Y = AutoNe[3].Y;
						break;
					case "l":
						with_1.X = AutoNe[4].X;
						with_1.Y = AutoNe[4].Y;
						break;
					case "m":
						with_1.X = AutoSw[1].X;
						with_1.Y = AutoSw[1].Y;
						break;
					case "n":
						with_1.X = AutoSw[2].X;
						with_1.Y = AutoSw[2].Y;
						break;
					case "o":
						with_1.X = AutoSw[3].X;
						with_1.Y = AutoSw[3].Y;
						break;
					case "p":
						with_1.X = AutoSw[4].X;
						with_1.Y = AutoSw[4].Y;
						break;
					case "q":
						with_1.X = AutoSe[1].X;
						with_1.Y = AutoSe[1].Y;
						break;
					case "r":
						with_1.X = AutoSe[2].X;
						with_1.Y = AutoSe[2].Y;
						break;
					case "s":
						with_1.X = AutoSe[3].X;
						with_1.Y = AutoSe[3].Y;
						break;
					case "t":
						with_1.X = AutoSe[4].X;
						with_1.Y = AutoSe[4].Y;
						break;
				}
			}
			else
			{
				ref var with_2 = ref Autotile[x, y].Layer[layerNum].QuarterTile[tileQuarter];
				switch (autoTileLetter)
				{
					case "a":
						with_2.X = AutoIn[1].X;
						with_2.Y = AutoIn[1].Y;
						break;
					case "b":
						with_2.X = AutoIn[2].X;
						with_2.Y = AutoIn[2].Y;
						break;
					case "c":
						with_2.X = AutoIn[3].X;
						with_2.Y = AutoIn[3].Y;
						break;
					case "d":
						with_2.X = AutoIn[4].X;
						with_2.Y = AutoIn[4].Y;
						break;
					case "e":
						with_2.X = AutoNw[1].X;
						with_2.Y = AutoNw[1].Y;
						break;
					case "f":
						with_2.X = AutoNw[2].X;
						with_2.Y = AutoNw[2].Y;
						break;
					case "g":
						with_2.X = AutoNw[3].X;
						with_2.Y = AutoNw[3].Y;
						break;
					case "h":
						with_2.X = AutoNw[4].X;
						with_2.Y = AutoNw[4].Y;
						break;
					case "i":
						with_2.X = AutoNe[1].X;
						with_2.Y = AutoNe[1].Y;
						break;
					case "j":
						with_2.X = AutoNe[2].X;
						with_2.Y = AutoNe[2].Y;
						break;
					case "k":
						with_2.X = AutoNe[3].X;
						with_2.Y = AutoNe[3].Y;
						break;
					case "l":
						with_2.X = AutoNe[4].X;
						with_2.Y = AutoNe[4].Y;
						break;
					case "m":
						with_2.X = AutoSw[1].X;
						with_2.Y = AutoSw[1].Y;
						break;
					case "n":
						with_2.X = AutoSw[2].X;
						with_2.Y = AutoSw[2].Y;
						break;
					case "o":
						with_2.X = AutoSw[3].X;
						with_2.Y = AutoSw[3].Y;
						break;
					case "p":
						with_2.X = AutoSw[4].X;
						with_2.Y = AutoSw[4].Y;
						break;
					case "q":
						with_2.X = AutoSe[1].X;
						with_2.Y = AutoSe[1].Y;
						break;
					case "r":
						with_2.X = AutoSe[2].X;
						with_2.Y = AutoSe[2].Y;
						break;
					case "s":
						with_2.X = AutoSe[3].X;
						with_2.Y = AutoSe[3].Y;
						break;
					case "t":
						with_2.X = AutoSe[4].X;
						with_2.Y = AutoSe[4].Y;
						break;
				}
			}
			
		}
		
		internal static void InitAutotiles()
		{
			int x = 0;
			int y = 0;
			int layerNum = 0;
            // Procedure used to cache autotile positions. All positioning is
            // independant from the tileset. Calculations are convoluted and annoying.
            // Maths is not my strong point. Luckily we're caching them so it's a one-off
            // thing when the map is originally loaded. As such optimisation isn't an issue.
            // For simplicity's sake we cache all subtile SOURCE positions in to an array.
            // We also give letters to each subtile for easy rendering tweaks. ;]
            // First, we need to re-size the array
            
            C_Maps.autoTileCache.Clear();

            Autotile = new C_AutoTiles.AutotileRec[C_Maps.Map.MaxX + 1, C_Maps.Map.MaxY + 1];
			for (x = 0; x <= C_Maps.Map.MaxX; x++)
			{
				for (y = 0; y <= C_Maps.Map.MaxY; y++)
				{
					Autotile[x, y].Layer = new C_AutoTiles.QuarterTileRec[(int) Enums.LayerType.Count];
					for (var i = 0; i <= (int) Enums.LayerType.Count - 1; i++)
					{
						Autotile[x, y].Layer[(int) i].SrcX = new int[5];
						Autotile[x, y].Layer[(int) i].SrcY = new int[5];
						Autotile[x, y].Layer[(int) i].QuarterTile = new C_AutoTiles.PointRec[5];
					}
				}
			}
			
			// Inner tiles (Top right subtile region)
			// NW - a
			AutoIn[1].X = 32;
			AutoIn[1].Y = 0;
			// NE - b
			AutoIn[2].X = 48;
			AutoIn[2].Y = 0;
			// SW - c
			AutoIn[3].X = 32;
			AutoIn[3].Y = 16;
			// SE - d
			AutoIn[4].X = 48;
			AutoIn[4].Y = 16;
			// Outer Tiles - NW (bottom subtile region)
			// NW - e
			AutoNw[1].X = 0;
			AutoNw[1].Y = 32;
			// NE - f
			AutoNw[2].X = 16;
			AutoNw[2].Y = 32;
			// SW - g
			AutoNw[3].X = 0;
			AutoNw[3].Y = 48;
			// SE - h
			AutoNw[4].X = 16;
			AutoNw[4].Y = 48;
			// Outer Tiles - NE (bottom subtile region)
			// NW - i
			AutoNe[1].X = 32;
			AutoNe[1].Y = 32;
			// NE - g
			AutoNe[2].X = 48;
			AutoNe[2].Y = 32;
			// SW - k
			AutoNe[3].X = 32;
			AutoNe[3].Y = 48;
			// SE - l
			AutoNe[4].X = 48;
			AutoNe[4].Y = 48;
			// Outer Tiles - SW (bottom subtile region)
			// NW - m
			AutoSw[1].X = 0;
			AutoSw[1].Y = 64;
			// NE - n
			AutoSw[2].X = 16;
			AutoSw[2].Y = 64;
			// SW - o
			AutoSw[3].X = 0;
			AutoSw[3].Y = 80;
			// SE - p
			AutoSw[4].X = 16;
			AutoSw[4].Y = 80;
			// Outer Tiles - SE (bottom subtile region)
			// NW - q
			AutoSe[1].X = 32;
			AutoSe[1].Y = 64;
			// NE - r
			AutoSe[2].X = 48;
			AutoSe[2].Y = 64;
			// SW - s
			AutoSe[3].X = 32;
			AutoSe[3].Y = 80;
			// SE - t
			AutoSe[4].X = 48;
			AutoSe[4].Y = 80;
			
			for (x = 0; x <= C_Maps.Map.MaxX; x++)
			{
				for (y = 0; y <= C_Maps.Map.MaxY; y++)
				{
					for (layerNum = 1; layerNum <= (int) Enums.LayerType.Count - 1; layerNum++)
					{
						// calculate the subtile positions and place them
						CalculateAutotile(x, y, layerNum);
						// cache the rendering state of the tiles and set them
						CacheRenderState(x, y, layerNum);
					}
				}
			}
			
		}
		
		internal static void CacheRenderState(int x, int y, int layerNum)
		{
			int quarterNum = 0;
			
			// exit out early
			
			if (x < 0 || x > C_Maps.Map.MaxX || y < 0 || y > C_Maps.Map.MaxY)
			{
				return;
			}
			
			ref var with_1 = ref C_Maps.Map.Tile[x, y];
			// check if the tile can be rendered
			if (with_1.Layer[layerNum].Tileset <= 0 || with_1.Layer[layerNum].Tileset > C_Graphics.NumTileSets)
			{
				Autotile[x, y].Layer[layerNum].RenderState = (byte) RenderStateNone;
				return;
			}
			// check if it's a key - hide mask if key is closed
			if (layerNum == (int) Enums.LayerType.Mask)
			{
				if (with_1.Type == (byte)Enums.TileType.Key)
				{
					if (C_Maps.TempTile[x, y].DoorOpen == 0)
					{
						Autotile[x, y].Layer[layerNum].RenderState = (byte) RenderStateNone;
						return;
					}
					else
					{
						Autotile[x, y].Layer[layerNum].RenderState = (byte) RenderStateNormal;
						return;
					}
				}
			}
			// check if it needs to be rendered as an autotile
			if (with_1.Layer[layerNum].AutoTile == AutotileNone || with_1.Layer[layerNum].AutoTile == AutotileFake)
			{
				//ReDim Autotile(X, Y).Layer(MapLayer.Count - 1)
				// default to... default
				Autotile[x, y].Layer[layerNum].RenderState = (byte) RenderStateNormal;
			}
			else
			{
				Autotile[x, y].Layer[layerNum].RenderState = (byte) RenderStateAutotile;
				// cache tileset positioning
				for (quarterNum = 1; quarterNum <= 4; quarterNum++)
				{
					Autotile[x, y].Layer[layerNum].SrcX[quarterNum] = (C_Maps.Map.Tile[x, y].Layer[layerNum].X * 32) + Autotile[x, y].Layer[layerNum].QuarterTile[quarterNum].X;
					Autotile[x, y].Layer[layerNum].SrcY[quarterNum] = (C_Maps.Map.Tile[x, y].Layer[layerNum].Y * 32) + Autotile[x, y].Layer[layerNum].QuarterTile[quarterNum].Y;
				}
			}
			// End If
			
		}
		
		internal static void CalculateAutotile(int x, int y, int layerNum)
		{
			// Right, so we've split the tile block in to an easy to remember
			// collection of letters. We now need to do the calculations to find
			// out which little lettered block needs to be rendered. We do this
			// by reading the surrounding tiles to check for matches.
			// First we check to make sure an autotile situation is actually there.
			// Then we calculate exactly which situation has arisen.
			// The situations are "inner", "outer", "horizontal", "vertical" and "fill".
			// Exit out if we don't have an autotile
			
			if (C_Maps.Map.Tile[x, y].Layer[layerNum].AutoTile == 0)
			{
				return;
			}
			// Okay, we have autotiling but which one
			// Normal or animated - same difference
			if ((C_Maps.Map.Tile[x, y].Layer[layerNum].AutoTile == AutotileNormal) || (C_Maps.Map.Tile[x, y].Layer[layerNum].AutoTile == AutotileAnim))
			{
				// North West Quarter
				CalculateNW_Normal(layerNum, x, y);
				// North East Quarter
				CalculateNE_Normal(layerNum, x, y);
				// South West Quarter
				CalculateSW_Normal(layerNum, x, y);
				// South East Quarter
				CalculateSE_Normal(layerNum, x, y);
				// Cliff
			}
			else if (C_Maps.Map.Tile[x, y].Layer[layerNum].AutoTile == AutotileCliff)
			{
				// North West Quarter
				CalculateNW_Cliff(layerNum, x, y);
				// North East Quarter
				CalculateNE_Cliff(layerNum, x, y);
				// South West Quarter
				CalculateSW_Cliff(layerNum, x, y);
				// South East Quarter
				CalculateSE_Cliff(layerNum, x, y);
				// Waterfalls
			}
			else if (C_Maps.Map.Tile[x, y].Layer[layerNum].AutoTile == AutotileWaterfall)
			{
				// North West Quarter
				CalculateNW_Waterfall(layerNum, x, y);
				// North East Quarter
				CalculateNE_Waterfall(layerNum, x, y);
				// South West Quarter
				CalculateSW_Waterfall(layerNum, x, y);
				// South East Quarter
				CalculateSE_Waterfall(layerNum, x, y);
				// Anything else
			}
			// End If
			
		}
		
		// Normal autotiling
		internal static void CalculateNW_Normal(int layerNum, int x, int y)
		{
			bool[] tmpTile = new bool[4];
			byte situation = 0;
			
			// North West
			
			if (CheckTileMatch(layerNum, x, y, x - 1, y - 1))
			{
				tmpTile[1] = true;
			}
			// North
			if (CheckTileMatch(layerNum, x, y, x, y - 1))
			{
				tmpTile[2] = true;
			}
			// West
			if (CheckTileMatch(layerNum, x, y, x - 1, y))
			{
				tmpTile[3] = true;
			}
			// Calculate Situation - Inner
			if (!tmpTile[2] && !tmpTile[3])
			{
				situation = AutoInner;
			}
			// Horizontal
			if (!tmpTile[2] && tmpTile[3])
			{
				situation = AutoHorizontal;
			}
			// Vertical
			if (tmpTile[2] && !tmpTile[3])
			{
				situation = AutoVertical;
			}
			// Outer
			if (!tmpTile[1] && tmpTile[2] && tmpTile[3])
			{
				situation = AutoOuter;
			}
			// Fill
			if (tmpTile[1] && tmpTile[2] && tmpTile[3])
			{
				situation = AutoFill;
			}
			// Actually place the subtile
			if (situation == AutoInner)
			{
				PlaceAutotile(layerNum, x, y, (byte) 1, "e");
			}
			else if (situation == AutoOuter)
			{
				PlaceAutotile(layerNum, x, y, (byte) 1, "a");
			}
			else if (situation == AutoHorizontal)
			{
				PlaceAutotile(layerNum, x, y, (byte) 1, "i");
			}
			else if (situation == AutoVertical)
			{
				PlaceAutotile(layerNum, x, y, (byte) 1, "m");
			}
			else if (situation == AutoFill)
			{
				PlaceAutotile(layerNum, x, y, (byte) 1, "q");
			}
			
		}
		
		internal static void CalculateNE_Normal(int layerNum, int x, int y)
		{
			bool[] tmpTile = new bool[4];
			byte situation = 0;
			
			// North
			
			if (CheckTileMatch(layerNum, x, y, x, y - 1))
			{
				tmpTile[1] = true;
			}
			// North East
			if (CheckTileMatch(layerNum, x, y, x + 1, y - 1))
			{
				tmpTile[2] = true;
			}
			// East
			if (CheckTileMatch(layerNum, x, y, x + 1, y))
			{
				tmpTile[3] = true;
			}
			// Calculate Situation - Inner
			if (!tmpTile[1] && !tmpTile[3])
			{
				situation = AutoInner;
			}
			// Horizontal
			if (!tmpTile[1] && tmpTile[3])
			{
				situation = AutoHorizontal;
			}
			// Vertical
			if (tmpTile[1] && !tmpTile[3])
			{
				situation = AutoVertical;
			}
			// Outer
			if (tmpTile[1] && !tmpTile[2] && tmpTile[3])
			{
				situation = AutoOuter;
			}
			// Fill
			if (tmpTile[1] && tmpTile[2] && tmpTile[3])
			{
				situation = AutoFill;
			}
			// Actually place the subtile
			if (situation == AutoInner)
			{
				PlaceAutotile(layerNum, x, y, (byte) 2, "j");
			}
			else if (situation == AutoOuter)
			{
				PlaceAutotile(layerNum, x, y, (byte) 2, "b");
			}
			else if (situation == AutoHorizontal)
			{
				PlaceAutotile(layerNum, x, y, (byte) 2, "f");
			}
			else if (situation == AutoVertical)
			{
				PlaceAutotile(layerNum, x, y, (byte) 2, "r");
			}
			else if (situation == AutoFill)
			{
				PlaceAutotile(layerNum, x, y, (byte) 2, "n");
			}
			
		}
		
		internal static void CalculateSW_Normal(int layerNum, int x, int y)
		{
			bool[] tmpTile = new bool[4];
			byte situation = 0;
			
			// West
			
			if (CheckTileMatch(layerNum, x, y, x - 1, y))
			{
				tmpTile[1] = true;
			}
			// South West
			if (CheckTileMatch(layerNum, x, y, x - 1, y + 1))
			{
				tmpTile[2] = true;
			}
			// South
			if (CheckTileMatch(layerNum, x, y, x, y + 1))
			{
				tmpTile[3] = true;
			}
			// Calculate Situation - Inner
			if (!tmpTile[1] && !tmpTile[3])
			{
				situation = AutoInner;
			}
			// Horizontal
			if (tmpTile[1] && !tmpTile[3])
			{
				situation = AutoHorizontal;
			}
			// Vertical
			if (!tmpTile[1] && tmpTile[3])
			{
				situation = AutoVertical;
			}
			// Outer
			if (tmpTile[1] && !tmpTile[2] && tmpTile[3])
			{
				situation = AutoOuter;
			}
			// Fill
			if (tmpTile[1] && tmpTile[2] && tmpTile[3])
			{
				situation = AutoFill;
			}
			// Actually place the subtile
			if (situation == AutoInner)
			{
				PlaceAutotile(layerNum, x, y, (byte) 3, "o");
			}
			else if (situation == AutoOuter)
			{
				PlaceAutotile(layerNum, x, y, (byte) 3, "c");
			}
			else if (situation == AutoHorizontal)
			{
				PlaceAutotile(layerNum, x, y, (byte) 3, "s");
			}
			else if (situation == AutoVertical)
			{
				PlaceAutotile(layerNum, x, y, (byte) 3, "g");
			}
			else if (situation == AutoFill)
			{
				PlaceAutotile(layerNum, x, y, (byte) 3, "k");
			}
			
		}
		
		internal static void CalculateSE_Normal(int layerNum, int x, int y)
		{
			bool[] tmpTile = new bool[4];
			byte situation = 0;
			
			// South
			
			if (CheckTileMatch(layerNum, x, y, x, y + 1))
			{
				tmpTile[1] = true;
			}
			// South East
			if (CheckTileMatch(layerNum, x, y, x + 1, y + 1))
			{
				tmpTile[2] = true;
			}
			// East
			if (CheckTileMatch(layerNum, x, y, x + 1, y))
			{
				tmpTile[3] = true;
			}
			// Calculate Situation - Inner
			if (!tmpTile[1] && !tmpTile[3])
			{
				situation = AutoInner;
			}
			// Horizontal
			if (!tmpTile[1] && tmpTile[3])
			{
				situation = AutoHorizontal;
			}
			// Vertical
			if (tmpTile[1] && !tmpTile[3])
			{
				situation = AutoVertical;
			}
			// Outer
			if (tmpTile[1] && !tmpTile[2] && tmpTile[3])
			{
				situation = AutoOuter;
			}
			// Fill
			if (tmpTile[1] && tmpTile[2] && tmpTile[3])
			{
				situation = AutoFill;
			}
			// Actually place the subtile
			if (situation == AutoInner)
			{
				PlaceAutotile(layerNum, x, y, (byte) 4, "t");
			}
			else if (situation == AutoOuter)
			{
				PlaceAutotile(layerNum, x, y, (byte) 4, "d");
			}
			else if (situation == AutoHorizontal)
			{
				PlaceAutotile(layerNum, x, y, (byte) 4, "p");
			}
			else if (situation == AutoVertical)
			{
				PlaceAutotile(layerNum, x, y, (byte) 4, "l");
			}
			else if (situation == AutoFill)
			{
				PlaceAutotile(layerNum, x, y, (byte) 4, "h");
			}
			
		}
		
		// Waterfall autotiling
		internal static void CalculateNW_Waterfall(int layerNum, int x, int y)
		{
			bool tmpTile = false;
			// West
			
			if (CheckTileMatch(layerNum, x, y, x - 1, y))
			{
				tmpTile = true;
			}
			// Actually place the subtile
			if (tmpTile)
			{
				// Extended
				PlaceAutotile(layerNum, x, y, (byte) 1, "i");
			}
			else
			{
				// Edge
				PlaceAutotile(layerNum, x, y, (byte) 1, "e");
			}
			
		}
		
		internal static void CalculateNE_Waterfall(int layerNum, int x, int y)
		{
			bool tmpTile = false;
			// East
			
			if (CheckTileMatch(layerNum, x, y, x + 1, y))
			{
				tmpTile = true;
			}
			// Actually place the subtile
			if (tmpTile)
			{
				// Extended
				PlaceAutotile(layerNum, x, y, (byte) 2, "f");
			}
			else
			{
				// Edge
				PlaceAutotile(layerNum, x, y, (byte) 2, "j");
			}
			
		}
		
		internal static void CalculateSW_Waterfall(int layerNum, int x, int y)
		{
			bool tmpTile = false;
			// West
			
			if (CheckTileMatch(layerNum, x, y, x - 1, y))
			{
				tmpTile = true;
			}
			// Actually place the subtile
			if (tmpTile)
			{
				// Extended
				PlaceAutotile(layerNum, x, y, (byte) 3, "k");
			}
			else
			{
				// Edge
				PlaceAutotile(layerNum, x, y, (byte) 3, "g");
			}
			
		}
		
		internal static void CalculateSE_Waterfall(int layerNum, int x, int y)
		{
			bool tmpTile = false;
			// East
			
			if (CheckTileMatch(layerNum, x, y, x + 1, y))
			{
				tmpTile = true;
			}
			// Actually place the subtile
			if (tmpTile)
			{
				// Extended
				PlaceAutotile(layerNum, x, y, (byte) 4, "h");
			}
			else
			{
				// Edge
				PlaceAutotile(layerNum, x, y, (byte) 4, "l");
			}
			
		}
		
		// Cliff autotiling
		internal static void CalculateNW_Cliff(int layerNum, int x, int y)
		{
			bool[] tmpTile = new bool[4];
			byte situation = 0;
			
			// North West
			
			if (CheckTileMatch(layerNum, x, y, x - 1, y - 1))
			{
				tmpTile[1] = true;
			}
			// North
			if (CheckTileMatch(layerNum, x, y, x, y - 1))
			{
				tmpTile[2] = true;
			}
			// West
			if (CheckTileMatch(layerNum, x, y, x - 1, y))
			{
				tmpTile[3] = true;
			}
			situation = AutoFill;
			// Calculate Situation - Horizontal
			if (!tmpTile[2] && tmpTile[3])
			{
				situation = AutoHorizontal;
			}
			// Vertical
			if (tmpTile[2] && !tmpTile[3])
			{
				situation = AutoVertical;
			}
			// Fill
			if (tmpTile[1] && tmpTile[2] && tmpTile[3])
			{
				situation = AutoFill;
			}
			// Inner
			if (!tmpTile[2] && !tmpTile[3])
			{
				situation = AutoInner;
			}
			// Actually place the subtile
			if (situation == AutoInner)
			{
				PlaceAutotile(layerNum, x, y, (byte) 1, "e");
			}
			else if (situation == AutoHorizontal)
			{
				PlaceAutotile(layerNum, x, y, (byte) 1, "i");
			}
			else if (situation == AutoVertical)
			{
				PlaceAutotile(layerNum, x, y, (byte) 1, "m");
			}
			else if (situation == AutoFill)
			{
				PlaceAutotile(layerNum, x, y, (byte) 1, "q");
			}
			
		}
		
		internal static void CalculateNE_Cliff(int layerNum, int x, int y)
		{
			bool[] tmpTile = new bool[4];
			byte situation = 0;
			
			// North
			
			if (CheckTileMatch(layerNum, x, y, x, y - 1))
			{
				tmpTile[1] = true;
			}
			// North East
			if (CheckTileMatch(layerNum, x, y, x + 1, y - 1))
			{
				tmpTile[2] = true;
			}
			// East
			if (CheckTileMatch(layerNum, x, y, x + 1, y))
			{
				tmpTile[3] = true;
			}
			situation = AutoFill;
			// Calculate Situation - Horizontal
			if (!tmpTile[1] && tmpTile[3])
			{
				situation = AutoHorizontal;
			}
			// Vertical
			if (tmpTile[1] && !tmpTile[3])
			{
				situation = AutoVertical;
			}
			// Fill
			if (tmpTile[1] && tmpTile[2] && tmpTile[3])
			{
				situation = AutoFill;
			}
			// Inner
			if (!tmpTile[1] && !tmpTile[3])
			{
				situation = AutoInner;
			}
			// Actually place the subtile
			if (situation == AutoInner)
			{
				PlaceAutotile(layerNum, x, y, (byte) 2, "j");
			}
			else if (situation == AutoHorizontal)
			{
				PlaceAutotile(layerNum, x, y, (byte) 2, "f");
			}
			else if (situation == AutoVertical)
			{
				PlaceAutotile(layerNum, x, y, (byte) 2, "r");
			}
			else if (situation == AutoFill)
			{
				PlaceAutotile(layerNum, x, y, (byte) 2, "n");
			}
			
		}
		
		internal static void CalculateSW_Cliff(int layerNum, int x, int y)
		{
			bool[] tmpTile = new bool[4];
			byte situation = 0;
			
			// West
			
			if (CheckTileMatch(layerNum, x, y, x - 1, y))
			{
				tmpTile[1] = true;
			}
			// South West
			if (CheckTileMatch(layerNum, x, y, x - 1, y + 1))
			{
				tmpTile[2] = true;
			}
			// South
			if (CheckTileMatch(layerNum, x, y, x, y + 1))
			{
				tmpTile[3] = true;
			}
			situation = AutoFill;
			// Calculate Situation - Horizontal
			if (tmpTile[1] && !tmpTile[3])
			{
				situation = AutoHorizontal;
			}
			// Vertical
			if (!tmpTile[1] && tmpTile[3])
			{
				situation = AutoVertical;
			}
			// Fill
			if (tmpTile[1] && tmpTile[2] && tmpTile[3])
			{
				situation = AutoFill;
			}
			// Inner
			if (!tmpTile[1] && !tmpTile[3])
			{
				situation = AutoInner;
			}
			// Actually place the subtile
			if (situation == AutoInner)
			{
				PlaceAutotile(layerNum, x, y, (byte) 3, "o");
			}
			else if (situation == AutoHorizontal)
			{
				PlaceAutotile(layerNum, x, y, (byte) 3, "s");
			}
			else if (situation == AutoVertical)
			{
				PlaceAutotile(layerNum, x, y, (byte) 3, "g");
			}
			else if (situation == AutoFill)
			{
				PlaceAutotile(layerNum, x, y, (byte) 3, "k");
			}
			
		}
		
		internal static void CalculateSE_Cliff(int layerNum, int x, int y)
		{
			bool[] tmpTile = new bool[4];
			byte situation = 0;
			
			// South
			
			if (CheckTileMatch(layerNum, x, y, x, y + 1))
			{
				tmpTile[1] = true;
			}
			// South East
			if (CheckTileMatch(layerNum, x, y, x + 1, y + 1))
			{
				tmpTile[2] = true;
			}
			// East
			if (CheckTileMatch(layerNum, x, y, x + 1, y))
			{
				tmpTile[3] = true;
			}
			situation = AutoFill;
			// Calculate Situation -  Horizontal
			if (!tmpTile[1] && tmpTile[3])
			{
				situation = AutoHorizontal;
			}
			// Vertical
			if (tmpTile[1] && !tmpTile[3])
			{
				situation = AutoVertical;
			}
			// Fill
			if (tmpTile[1] && tmpTile[2] && tmpTile[3])
			{
				situation = AutoFill;
			}
			// Inner
			if (!tmpTile[1] && !tmpTile[3])
			{
				situation = AutoInner;
			}
			// Actually place the subtile
			if (situation == AutoInner)
			{
				PlaceAutotile(layerNum, x, y, (byte) 4, "t");
			}
			else if (situation == AutoHorizontal)
			{
				PlaceAutotile(layerNum, x, y, (byte) 4, "p");
			}
			else if (situation == AutoVertical)
			{
				PlaceAutotile(layerNum, x, y, (byte) 4, "l");
			}
			else if (situation == AutoFill)
			{
				PlaceAutotile(layerNum, x, y, (byte) 4, "h");
			}
			
		}
		
		internal static bool CheckTileMatch(int layerNum, int x1, int y1, int x2, int y2)
		{
			bool returnValue = false;
			// we'll exit out early if true
			//Dim exTile As Boolean
			
			//If layerNum > MapLayer.Count - 1 Then exTile = True : layerNum = layerNum - (MapLayer.Count - 1)
			returnValue = true;
			// if it's off the map then set it as autotile and exit out early
			if (x2 < 0 || x2 > C_Maps.Map.MaxX || y2 < 0 || y2 > C_Maps.Map.MaxY)
			{
				return true;
				
			}
			
			// fakes ALWAYS return true
			if (C_Maps.Map.Tile[x2, y2].Layer[layerNum].AutoTile == AutotileFake)
			{
				return true;
				
			}
			// End If
			
			// check neighbour is an autotile
			if (C_Maps.Map.Tile[x2, y2].Layer[layerNum].AutoTile == 0)
			{
				return false;
				
			}
			// End If
			
			// check we're a matching
			if (C_Maps.Map.Tile[x1, y1].Layer[layerNum].Tileset != C_Maps.Map.Tile[x2, y2].Layer[layerNum].Tileset)
			{
				return false;
				
			}
			
			// check tiles match
			if (C_Maps.Map.Tile[x1, y1].Layer[layerNum].X != C_Maps.Map.Tile[x2, y2].Layer[layerNum].X)
			{
				return false;
				
			}
			else
			{
				if (C_Maps.Map.Tile[x1, y1].Layer[layerNum].Y != C_Maps.Map.Tile[x2, y2].Layer[layerNum].Y)
				{
					return false;
					
				}
			}
			return returnValue;
		}
		
		internal static void DrawAutoTile(int layerNum, int destX, int destY, int quarterNum, int x, int y, int forceFrame = 0, bool Strict = true)
        {

            if (C_Variables.GettingMap)
            {
                return;
            }
            if (ReferenceEquals(C_Maps.Map.Tile[x, y].Layer, null))
            {
                return;
            }

            int yOffset = 0;
			int xOffset = 0;
			
			// calculate the offset
			if (forceFrame > 0)
			{
				switch (forceFrame - 1)
				{
					case 0:
						WaterfallFrame = 1;
						break;
					case 1:
						WaterfallFrame = 2;
						break;
					case 2:
						WaterfallFrame = 0;
						break;
				}
				// animate autotiles
				switch (forceFrame - 1)
				{
					case 0:
						AutoTileFrame = 1;
						break;
					case 1:
						AutoTileFrame = 2;
						break;
					case 2:
						AutoTileFrame = 0;
						break;
				}
			}
			
			if (C_Maps.Map.Tile[x, y].Layer[layerNum].AutoTile == AutotileWaterfall)
			{
				yOffset = (WaterfallFrame - 1) * 32;
			}
			else if (C_Maps.Map.Tile[x, y].Layer[layerNum].AutoTile == AutotileAnim)
			{
				xOffset = AutoTileFrame * 64;
			}
			else if (C_Maps.Map.Tile[x, y].Layer[layerNum].AutoTile == AutotileCliff)
			{
				yOffset = -32;
			}
			
			// Draw the quarter
			C_Graphics.RenderSprite(C_Graphics.TileSetSprite[C_Maps.Map.Tile[x, y].Layer[layerNum].Tileset], C_Graphics.GameWindow, destX, destY, (int)(Autotile[x, y].Layer[layerNum].SrcX[quarterNum] + xOffset), (int)(Autotile[x, y].Layer[layerNum].SrcY[quarterNum] + yOffset), 16, 16);
		}

        internal static void CreateAndRenderAutoTileImage(int layerNum, int x, int y)
        {
            Tuple<int, int, int> key = new Tuple<int, int, int>(layerNum, x, y);
            if (!(C_Maps.autoTileCache.ContainsKey(key)))
            {
                int yOffset = 0;
                
                if (C_Maps.Map.Tile[x, y].Layer[layerNum].AutoTile == AutotileCliff)
                {
                    yOffset = -32;
                }
                
                // Create the Image
                Image topLeft = ImageFromTilesetSection(x, y, layerNum, 1, yOffset);
                Image topRight = ImageFromTilesetSection(x, y, layerNum, 2, yOffset);
                Image bottomLeft = ImageFromTilesetSection(x, y, layerNum, 3, yOffset);
                Image bottomRight = ImageFromTilesetSection(x, y, layerNum, 4, yOffset);
                
                Color[,] tile = new Color[32, 32];
                
                // Um honestly idk why Tile wants to be y, x rather then x, y
                // And in general something is very off about the order of things.. it works though
                for (uint px = 0; px < 32; px++)
                {
                    for (uint py = 0; py < 32; py++)
                    {
                        if (py < 16)
                        {
                            if (px < 16)
                            {
                                tile[py, px] = topLeft.GetPixel(px, py);
                            }
                            else
                            {
                                tile[py, px] = topRight.GetPixel(px - 16, py);
                            }
                        }
                        else 
                        {
                
                            if (px < 16)
                            {
                                tile[py, px] = bottomLeft.GetPixel(px, py - 16);
                            }
                            else
                            {
                                tile[py, px] = bottomRight.GetPixel(px - 16, py - 16);
                            }
                        }
                    }
                }
                
                C_Maps.autoTileCache.Add(key, new Sprite(new Texture(new Image(tile))));
                
                // We have the tile now se Render it
                C_Graphics.RenderSpriteSimple(C_Maps.autoTileCache[key], C_Graphics.GameWindow, C_Graphics.ConvertMapX(x * C_Constants.PicX), C_Graphics.ConvertMapY(y * C_Constants.PicY));
            }
            else
            {
                // We already have the Tile so just Render it
                C_Graphics.RenderSpriteSimple(C_Maps.autoTileCache[key], C_Graphics.GameWindow, C_Graphics.ConvertMapX(x * C_Constants.PicX), C_Graphics.ConvertMapY(y * C_Constants.PicY));
            }
        }

        internal static Image ImageFromTilesetSection(int x, int y, int layerNum, int quarterNum, int yOffset)
        {
            Color[,] pixels = new Color[16,16];
            for(int px = 0; px < 16; px++)
            {
                for (int py = 0; py < 16; py++)
                {
                    pixels[py, px] = C_Graphics.TileSetImage[C_Maps.Map.Tile[x, y].Layer[layerNum].Tileset].GetPixel((uint)(Autotile[x, y].Layer[layerNum].SrcX[quarterNum] + px), (uint)((Autotile[x, y].Layer[layerNum].SrcY[quarterNum] + yOffset) + py));
                }
            }
            return new Image(pixels);
        }

    }
}
