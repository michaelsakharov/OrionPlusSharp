using SFML.Graphics;
using SFML.Window;

namespace Engine
{
    internal static class E_AutoTiles
    {


        // Autotiles
        internal const byte AUTO_INNER = 1;

        internal const byte AUTO_OUTER = 2;
        internal const byte AUTO_HORIZONTAL = 3;
        internal const byte AUTO_VERTICAL = 4;
        internal const byte AUTO_FILL = 5;

        // Autotile types
        internal const byte AUTOTILE_NONE = 0;

        internal const byte AUTOTILE_NORMAL = 1;
        internal const byte AUTOTILE_FAKE = 2;
        internal const byte AUTOTILE_ANIM = 3;
        internal const byte AUTOTILE_CLIFF = 4;
        internal const byte AUTOTILE_WATERFALL = 5;

        // Rendering
        internal const int RENDER_STATE_NONE = 0;

        internal const int RENDER_STATE_NORMAL = 1;
        internal const int RENDER_STATE_AUTOTILE = 2;

        // autotiling
        internal static PointRec[] autoInner = new PointRec[5];

        internal static PointRec[] autoNW = new PointRec[5];
        internal static PointRec[] autoNE = new PointRec[5];
        internal static PointRec[] autoSW = new PointRec[5];
        internal static PointRec[] autoSE = new PointRec[5];

        // Map animations
        internal static int waterfallFrame;

        internal static int autoTileFrame;

        internal static AutotileRec[,] Autotile;

        internal struct PointRec
        {
            public int X;
            public int Y;
        }

        internal struct QuarterTileRec
        {
            public PointRec[] QuarterTile; // 1 To 4
            public byte renderState;
            public int[] srcX; // 1 To 4
            public int[] srcY; // 1 To 4
        }

        internal struct AutotileRec
        {
            public QuarterTileRec[] Layer; // 1 To MapLayer.Count - 1
            public QuarterTileRec[] ExLayer; // 1 To ExMapLayer.Count - 1
        }


        // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        // All of this code is for auto tiles and the math behind generating them.
        // \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
        internal static void PlaceAutotile(int layerNum, int X, int Y, byte tileQuarter, string autoTileLetter)
        {
            if (layerNum > (byte)Enums.LayerType.Count - 1)
            {
                layerNum = layerNum - (byte)(Enums.LayerType.Count - 1);
                {
                    var withBlock = Autotile[X, Y].ExLayer[layerNum].QuarterTile[tileQuarter];
                    switch (autoTileLetter)
                    {
                        case "a":
                            {
                                withBlock.X = autoInner[1].X;
                                withBlock.Y = autoInner[1].Y;
                                break;
                            }

                        case "b":
                            {
                                withBlock.X = autoInner[2].X;
                                withBlock.Y = autoInner[2].Y;
                                break;
                            }

                        case "c":
                            {
                                withBlock.X = autoInner[3].X;
                                withBlock.Y = autoInner[3].Y;
                                break;
                            }

                        case "d":
                            {
                                withBlock.X = autoInner[4].X;
                                withBlock.Y = autoInner[4].Y;
                                break;
                            }

                        case "e":
                            {
                                withBlock.X = autoNW[1].X;
                                withBlock.Y = autoNW[1].Y;
                                break;
                            }

                        case "f":
                            {
                                withBlock.X = autoNW[2].X;
                                withBlock.Y = autoNW[2].Y;
                                break;
                            }

                        case "g":
                            {
                                withBlock.X = autoNW[3].X;
                                withBlock.Y = autoNW[3].Y;
                                break;
                            }

                        case "h":
                            {
                                withBlock.X = autoNW[4].X;
                                withBlock.Y = autoNW[4].Y;
                                break;
                            }

                        case "i":
                            {
                                withBlock.X = autoNE[1].X;
                                withBlock.Y = autoNE[1].Y;
                                break;
                            }

                        case "j":
                            {
                                withBlock.X = autoNE[2].X;
                                withBlock.Y = autoNE[2].Y;
                                break;
                            }

                        case "k":
                            {
                                withBlock.X = autoNE[3].X;
                                withBlock.Y = autoNE[3].Y;
                                break;
                            }

                        case "l":
                            {
                                withBlock.X = autoNE[4].X;
                                withBlock.Y = autoNE[4].Y;
                                break;
                            }

                        case "m":
                            {
                                withBlock.X = autoSW[1].X;
                                withBlock.Y = autoSW[1].Y;
                                break;
                            }

                        case "n":
                            {
                                withBlock.X = autoSW[2].X;
                                withBlock.Y = autoSW[2].Y;
                                break;
                            }

                        case "o":
                            {
                                withBlock.X = autoSW[3].X;
                                withBlock.Y = autoSW[3].Y;
                                break;
                            }

                        case "p":
                            {
                                withBlock.X = autoSW[4].X;
                                withBlock.Y = autoSW[4].Y;
                                break;
                            }

                        case "q":
                            {
                                withBlock.X = autoSE[1].X;
                                withBlock.Y = autoSE[1].Y;
                                break;
                            }

                        case "r":
                            {
                                withBlock.X = autoSE[2].X;
                                withBlock.Y = autoSE[2].Y;
                                break;
                            }

                        case "s":
                            {
                                withBlock.X = autoSE[3].X;
                                withBlock.Y = autoSE[3].Y;
                                break;
                            }

                        case "t":
                            {
                                withBlock.X = autoSE[4].X;
                                withBlock.Y = autoSE[4].Y;
                                break;
                            }
                    }
                }
            }
            else
            {
                var withBlock1 = Autotile[X, Y].Layer[layerNum].QuarterTile[tileQuarter];
                switch (autoTileLetter)
                {
                    case "a":
                        {
                            withBlock1.X = autoInner[1].X;
                            withBlock1.Y = autoInner[1].Y;
                            break;
                        }

                    case "b":
                        {
                            withBlock1.X = autoInner[2].X;
                            withBlock1.Y = autoInner[2].Y;
                            break;
                        }

                    case "c":
                        {
                            withBlock1.X = autoInner[3].X;
                            withBlock1.Y = autoInner[3].Y;
                            break;
                        }

                    case "d":
                        {
                            withBlock1.X = autoInner[4].X;
                            withBlock1.Y = autoInner[4].Y;
                            break;
                        }

                    case "e":
                        {
                            withBlock1.X = autoNW[1].X;
                            withBlock1.Y = autoNW[1].Y;
                            break;
                        }

                    case "f":
                        {
                            withBlock1.X = autoNW[2].X;
                            withBlock1.Y = autoNW[2].Y;
                            break;
                        }

                    case "g":
                        {
                            withBlock1.X = autoNW[3].X;
                            withBlock1.Y = autoNW[3].Y;
                            break;
                        }

                    case "h":
                        {
                            withBlock1.X = autoNW[4].X;
                            withBlock1.Y = autoNW[4].Y;
                            break;
                        }

                    case "i":
                        {
                            withBlock1.X = autoNE[1].X;
                            withBlock1.Y = autoNE[1].Y;
                            break;
                        }

                    case "j":
                        {
                            withBlock1.X = autoNE[2].X;
                            withBlock1.Y = autoNE[2].Y;
                            break;
                        }

                    case "k":
                        {
                            withBlock1.X = autoNE[3].X;
                            withBlock1.Y = autoNE[3].Y;
                            break;
                        }

                    case "l":
                        {
                            withBlock1.X = autoNE[4].X;
                            withBlock1.Y = autoNE[4].Y;
                            break;
                        }

                    case "m":
                        {
                            withBlock1.X = autoSW[1].X;
                            withBlock1.Y = autoSW[1].Y;
                            break;
                        }

                    case "n":
                        {
                            withBlock1.X = autoSW[2].X;
                            withBlock1.Y = autoSW[2].Y;
                            break;
                        }

                    case "o":
                        {
                            withBlock1.X = autoSW[3].X;
                            withBlock1.Y = autoSW[3].Y;
                            break;
                        }

                    case "p":
                        {
                            withBlock1.X = autoSW[4].X;
                            withBlock1.Y = autoSW[4].Y;
                            break;
                        }

                    case "q":
                        {
                            withBlock1.X = autoSE[1].X;
                            withBlock1.Y = autoSE[1].Y;
                            break;
                        }

                    case "r":
                        {
                            withBlock1.X = autoSE[2].X;
                            withBlock1.Y = autoSE[2].Y;
                            break;
                        }

                    case "s":
                        {
                            withBlock1.X = autoSE[3].X;
                            withBlock1.Y = autoSE[3].Y;
                            break;
                        }

                    case "t":
                        {
                            withBlock1.X = autoSE[4].X;
                            withBlock1.Y = autoSE[4].Y;
                            break;
                        }
                }
            }
        }

        internal static void InitAutotiles()
        {
            int X;
            int Y;
            int layerNum;
            // Procedure used to cache autotile positions. All positioning is
            // independant from the tileset. Calculations are convoluted and annoying.
            // Maths is not my strong point. Luckily we're caching them so it's a one-off
            // thing when the map is originally loaded. As such optimisation isn't an issue.
            // For simplicity's sake we cache all subtile SOURCE positions in to an array.
            // We also give letters to each subtile for easy rendering tweaks. ;]
            // First, we need to re-size the array

            Autotile = new AutotileRec[E_Types.Map.MaxX + 1, E_Types.Map.MaxY + 1];
            var loopTo = E_Types.Map.MaxX;
            for (X = 0; X <= loopTo; X++)
            {
                var loopTo1 = E_Types.Map.MaxY;
                for (Y = 0; Y <= loopTo1; Y++)
                {
                    Autotile[X, Y].Layer = new QuarterTileRec[6];
                    for (var i = 0; i <= (byte)Enums.LayerType.Count - 1; i++)
                    {
                        Autotile[X, Y].Layer[i].srcX = new int[5];
                        Autotile[X, Y].Layer[i].srcY = new int[5];
                        Autotile[X, Y].Layer[i].QuarterTile = new PointRec[5];
                    }
                }
            }

            // Inner tiles (Top right subtile region)
            // NW - a
            autoInner[1].X = 32;
            autoInner[1].Y = 0;
            // NE - b
            autoInner[2].X = 48;
            autoInner[2].Y = 0;
            // SW - c
            autoInner[3].X = 32;
            autoInner[3].Y = 16;
            // SE - d
            autoInner[4].X = 48;
            autoInner[4].Y = 16;
            // Outer Tiles - NW (bottom subtile region)
            // NW - e
            autoNW[1].X = 0;
            autoNW[1].Y = 32;
            // NE - f
            autoNW[2].X = 16;
            autoNW[2].Y = 32;
            // SW - g
            autoNW[3].X = 0;
            autoNW[3].Y = 48;
            // SE - h
            autoNW[4].X = 16;
            autoNW[4].Y = 48;
            // Outer Tiles - NE (bottom subtile region)
            // NW - i
            autoNE[1].X = 32;
            autoNE[1].Y = 32;
            // NE - g
            autoNE[2].X = 48;
            autoNE[2].Y = 32;
            // SW - k
            autoNE[3].X = 32;
            autoNE[3].Y = 48;
            // SE - l
            autoNE[4].X = 48;
            autoNE[4].Y = 48;
            // Outer Tiles - SW (bottom subtile region)
            // NW - m
            autoSW[1].X = 0;
            autoSW[1].Y = 64;
            // NE - n
            autoSW[2].X = 16;
            autoSW[2].Y = 64;
            // SW - o
            autoSW[3].X = 0;
            autoSW[3].Y = 80;
            // SE - p
            autoSW[4].X = 16;
            autoSW[4].Y = 80;
            // Outer Tiles - SE (bottom subtile region)
            // NW - q
            autoSE[1].X = 32;
            autoSE[1].Y = 64;
            // NE - r
            autoSE[2].X = 48;
            autoSE[2].Y = 64;
            // SW - s
            autoSE[3].X = 32;
            autoSE[3].Y = 80;
            // SE - t
            autoSE[4].X = 48;
            autoSE[4].Y = 80;
            var loopTo2 = E_Types.Map.MaxX;
            for (X = 0; X <= loopTo2; X++)
            {
                var loopTo3 = E_Types.Map.MaxY;
                for (Y = 0; Y <= loopTo3; Y++)
                {
                    for (layerNum = 1; layerNum <= (byte)Enums.LayerType.Count - 1; layerNum++)
                    {
                        // calculate the subtile positions and place them
                        CalculateAutotile(X, Y, layerNum);
                        // cache the rendering state of the tiles and set them
                        CacheRenderState(X, Y, layerNum);
                    }
                }
            }
        }

        internal static void CacheRenderState(int X, int Y, int layerNum)
        {
            int quarterNum;

            // exit out early

            if (X < 0 || X > E_Types.Map.MaxX || Y < 0 || Y > E_Types.Map.MaxY)
                return;

            {
                var withBlock = E_Types.Map.Tile[X, Y];
                // check if the tile can be rendered
                if (withBlock.Layer[layerNum].Tileset <= 0 || withBlock.Layer[layerNum].Tileset > E_Graphics.NumTileSets)
                {
                    Autotile[X, Y].Layer[layerNum].renderState = RENDER_STATE_NONE;
                    return;
                }
                // check if it's a key - hide mask if key is closed
                if (layerNum == (byte)Enums.LayerType.Mask)
                {
                    if (withBlock.Type == (byte)Enums.TileType.Key)
                    {
                        if (E_Types.TempTile[X, Y].DoorOpen == 0)
                        {
                            Autotile[X, Y].Layer[layerNum].renderState = RENDER_STATE_NONE;
                            return;
                        }
                        else
                        {
                            Autotile[X, Y].Layer[layerNum].renderState = RENDER_STATE_NORMAL;
                            return;
                        }
                    }
                }
                // check if it needs to be rendered as an autotile
                if (withBlock.Layer[layerNum].AutoTile == AUTOTILE_NONE || withBlock.Layer[layerNum].AutoTile == AUTOTILE_FAKE)
                    // ReDim Autotile(X, Y).Layer(MapLayer.Count - 1)
                    // default to... default
                    Autotile[X, Y].Layer[layerNum].renderState = RENDER_STATE_NORMAL;
                else
                {
                    Autotile[X, Y].Layer[layerNum].renderState = RENDER_STATE_AUTOTILE;
                    // cache tileset positioning
                    for (quarterNum = 1; quarterNum <= 4; quarterNum++)
                    {
                        Autotile[X, Y].Layer[layerNum].srcX[quarterNum] = (E_Types.Map.Tile[X, Y].Layer[layerNum].X * 32) + Autotile[X, Y].Layer[layerNum].QuarterTile[quarterNum].X;
                        Autotile[X, Y].Layer[layerNum].srcY[quarterNum] = (E_Types.Map.Tile[X, Y].Layer[layerNum].Y * 32) + Autotile[X, Y].Layer[layerNum].QuarterTile[quarterNum].Y;
                    }
                }
            }
        }

        internal static void CalculateAutotile(int X, int Y, int layerNum)
        {
            // Right, so we've split the tile block in to an easy to remember
            // collection of letters. We now need to do the calculations to find
            // out which little lettered block needs to be rendered. We do this
            // by reading the surrounding tiles to check for matches.
            // First we check to make sure an autotile situation is actually there.
            // Then we calculate exactly which situation has arisen.
            // The situations are "inner", "outer", "horizontal", "vertical" and "fill".
            // Exit out if we don't have an autotile

            if (E_Types.Map.Tile[X, Y].Layer[layerNum].AutoTile == 0)
                return;
            // Okay, we have autotiling but which one?
            switch (E_Types.Map.Tile[X, Y].Layer[layerNum].AutoTile)
            {
                case AUTOTILE_NORMAL:
                case AUTOTILE_ANIM:
                    {
                        // North West Quarter
                        CalculateNW_Normal(layerNum, X, Y);
                        // North East Quarter
                        CalculateNE_Normal(layerNum, X, Y);
                        // South West Quarter
                        CalculateSW_Normal(layerNum, X, Y);
                        // South East Quarter
                        CalculateSE_Normal(layerNum, X, Y);
                        break;
                    }

                case AUTOTILE_CLIFF:
                    {
                        // North West Quarter
                        CalculateNW_Cliff(layerNum, X, Y);
                        // North East Quarter
                        CalculateNE_Cliff(layerNum, X, Y);
                        // South West Quarter
                        CalculateSW_Cliff(layerNum, X, Y);
                        // South East Quarter
                        CalculateSE_Cliff(layerNum, X, Y);
                        break;
                    }

                case AUTOTILE_WATERFALL:
                    {
                        // North West Quarter
                        CalculateNW_Waterfall(layerNum, X, Y);
                        // North East Quarter
                        CalculateNE_Waterfall(layerNum, X, Y);
                        // South West Quarter
                        CalculateSW_Waterfall(layerNum, X, Y);
                        // South East Quarter
                        CalculateSE_Waterfall(layerNum, X, Y);
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        // Normal autotiling
        internal static void CalculateNW_Normal(int layerNum, int X, int Y)
        {
            bool[] tmpTile = new bool[4];
            byte situation = 0;

            // North West

            if (CheckTileMatch(layerNum, X, Y, X - 1, Y - 1))
                tmpTile[1] = true;
            // North
            if (CheckTileMatch(layerNum, X, Y, X, Y - 1))
                tmpTile[2] = true;
            // West
            if (CheckTileMatch(layerNum, X, Y, X - 1, Y))
                tmpTile[3] = true;
            // Calculate Situation - Inner
            if (!tmpTile[2] && !tmpTile[3])
                situation = AUTO_INNER;
            // Horizontal
            if (!tmpTile[2] && tmpTile[3])
                situation = AUTO_HORIZONTAL;
            // Vertical
            if (tmpTile[2] && !tmpTile[3])
                situation = AUTO_VERTICAL;
            // Outer
            if (!tmpTile[1] && tmpTile[2] && tmpTile[3])
                situation = AUTO_OUTER;
            // Fill
            if (tmpTile[1] && tmpTile[2] && tmpTile[3])
                situation = AUTO_FILL;
            // Actually place the subtile
            switch (situation)
            {
                case AUTO_INNER:
                    {
                        PlaceAutotile(layerNum, X, Y, 1, "e");
                        break;
                    }

                case AUTO_OUTER:
                    {
                        PlaceAutotile(layerNum, X, Y, 1, "a");
                        break;
                    }

                case AUTO_HORIZONTAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 1, "i");
                        break;
                    }

                case AUTO_VERTICAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 1, "m");
                        break;
                    }

                case AUTO_FILL:
                    {
                        PlaceAutotile(layerNum, X, Y, 1, "q");
                        break;
                    }
            }
        }

        internal static void CalculateNE_Normal(int layerNum, int X, int Y)
        {
            bool[] tmpTile = new bool[4];
            byte situation = 0;

            // North

            if (CheckTileMatch(layerNum, X, Y, X, Y - 1))
                tmpTile[1] = true;
            // North East
            if (CheckTileMatch(layerNum, X, Y, X + 1, Y - 1))
                tmpTile[2] = true;
            // East
            if (CheckTileMatch(layerNum, X, Y, X + 1, Y))
                tmpTile[3] = true;
            // Calculate Situation - Inner
            if (!tmpTile[1] && !tmpTile[3])
                situation = AUTO_INNER;
            // Horizontal
            if (!tmpTile[1] && tmpTile[3])
                situation = AUTO_HORIZONTAL;
            // Vertical
            if (tmpTile[1] && !tmpTile[3])
                situation = AUTO_VERTICAL;
            // Outer
            if (tmpTile[1] && !tmpTile[2] && tmpTile[3])
                situation = AUTO_OUTER;
            // Fill
            if (tmpTile[1] && tmpTile[2] && tmpTile[3])
                situation = AUTO_FILL;
            // Actually place the subtile
            switch (situation)
            {
                case AUTO_INNER:
                    {
                        PlaceAutotile(layerNum, X, Y, 2, "j");
                        break;
                    }

                case AUTO_OUTER:
                    {
                        PlaceAutotile(layerNum, X, Y, 2, "b");
                        break;
                    }

                case AUTO_HORIZONTAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 2, "f");
                        break;
                    }

                case AUTO_VERTICAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 2, "r");
                        break;
                    }

                case AUTO_FILL:
                    {
                        PlaceAutotile(layerNum, X, Y, 2, "n");
                        break;
                    }
            }
        }

        internal static void CalculateSW_Normal(int layerNum, int X, int Y)
        {
            bool[] tmpTile = new bool[4];
            byte situation = 0;

            // West

            if (CheckTileMatch(layerNum, X, Y, X - 1, Y))
                tmpTile[1] = true;
            // South West
            if (CheckTileMatch(layerNum, X, Y, X - 1, Y + 1))
                tmpTile[2] = true;
            // South
            if (CheckTileMatch(layerNum, X, Y, X, Y + 1))
                tmpTile[3] = true;
            // Calculate Situation - Inner
            if (!tmpTile[1] && !tmpTile[3])
                situation = AUTO_INNER;
            // Horizontal
            if (tmpTile[1] && !tmpTile[3])
                situation = AUTO_HORIZONTAL;
            // Vertical
            if (!tmpTile[1] && tmpTile[3])
                situation = AUTO_VERTICAL;
            // Outer
            if (tmpTile[1] && !tmpTile[2] && tmpTile[3])
                situation = AUTO_OUTER;
            // Fill
            if (tmpTile[1] && tmpTile[2] && tmpTile[3])
                situation = AUTO_FILL;
            // Actually place the subtile
            switch (situation)
            {
                case AUTO_INNER:
                    {
                        PlaceAutotile(layerNum, X, Y, 3, "o");
                        break;
                    }

                case AUTO_OUTER:
                    {
                        PlaceAutotile(layerNum, X, Y, 3, "c");
                        break;
                    }

                case AUTO_HORIZONTAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 3, "s");
                        break;
                    }

                case AUTO_VERTICAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 3, "g");
                        break;
                    }

                case AUTO_FILL:
                    {
                        PlaceAutotile(layerNum, X, Y, 3, "k");
                        break;
                    }
            }
        }

        internal static void CalculateSE_Normal(int layerNum, int X, int Y)
        {
            bool[] tmpTile = new bool[4];
            byte situation = 0;

            // South

            if (CheckTileMatch(layerNum, X, Y, X, Y + 1))
                tmpTile[1] = true;
            // South East
            if (CheckTileMatch(layerNum, X, Y, X + 1, Y + 1))
                tmpTile[2] = true;
            // East
            if (CheckTileMatch(layerNum, X, Y, X + 1, Y))
                tmpTile[3] = true;
            // Calculate Situation - Inner
            if (!tmpTile[1] && !tmpTile[3])
                situation = AUTO_INNER;
            // Horizontal
            if (!tmpTile[1] && tmpTile[3])
                situation = AUTO_HORIZONTAL;
            // Vertical
            if (tmpTile[1] && !tmpTile[3])
                situation = AUTO_VERTICAL;
            // Outer
            if (tmpTile[1] && !tmpTile[2] && tmpTile[3])
                situation = AUTO_OUTER;
            // Fill
            if (tmpTile[1] && tmpTile[2] && tmpTile[3])
                situation = AUTO_FILL;
            // Actually place the subtile
            switch (situation)
            {
                case AUTO_INNER:
                    {
                        PlaceAutotile(layerNum, X, Y, 4, "t");
                        break;
                    }

                case AUTO_OUTER:
                    {
                        PlaceAutotile(layerNum, X, Y, 4, "d");
                        break;
                    }

                case AUTO_HORIZONTAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 4, "p");
                        break;
                    }

                case AUTO_VERTICAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 4, "l");
                        break;
                    }

                case AUTO_FILL:
                    {
                        PlaceAutotile(layerNum, X, Y, 4, "h");
                        break;
                    }
            }
        }

        // Waterfall autotiling
        internal static void CalculateNW_Waterfall(int layerNum, int X, int Y)
        {
            bool tmpTile = false;
            // West

            if (CheckTileMatch(layerNum, X, Y, X - 1, Y))
                tmpTile = true;
            // Actually place the subtile
            if (tmpTile)
                // Extended
                PlaceAutotile(layerNum, X, Y, 1, "i");
            else
                // Edge
                PlaceAutotile(layerNum, X, Y, 1, "e");
        }

        internal static void CalculateNE_Waterfall(int layerNum, int X, int Y)
        {
            bool tmpTile = false;
            // East

            if (CheckTileMatch(layerNum, X, Y, X + 1, Y))
                tmpTile = true;
            // Actually place the subtile
            if (tmpTile)
                // Extended
                PlaceAutotile(layerNum, X, Y, 2, "f");
            else
                // Edge
                PlaceAutotile(layerNum, X, Y, 2, "j");
        }

        internal static void CalculateSW_Waterfall(int layerNum, int X, int Y)
        {
            bool tmpTile = false;
            // West

            if (CheckTileMatch(layerNum, X, Y, X - 1, Y))
                tmpTile = true;
            // Actually place the subtile
            if (tmpTile)
                // Extended
                PlaceAutotile(layerNum, X, Y, 3, "k");
            else
                // Edge
                PlaceAutotile(layerNum, X, Y, 3, "g");
        }

        internal static void CalculateSE_Waterfall(int layerNum, int X, int Y)
        {
            bool tmpTile = false;
            // East

            if (CheckTileMatch(layerNum, X, Y, X + 1, Y))
                tmpTile = true;
            // Actually place the subtile
            if (tmpTile)
                // Extended
                PlaceAutotile(layerNum, X, Y, 4, "h");
            else
                // Edge
                PlaceAutotile(layerNum, X, Y, 4, "l");
        }

        // Cliff autotiling
        internal static void CalculateNW_Cliff(int layerNum, int X, int Y)
        {
            bool[] tmpTile = new bool[4];
            byte situation;

            // North West

            if (CheckTileMatch(layerNum, X, Y, X - 1, Y - 1))
                tmpTile[1] = true;
            // North
            if (CheckTileMatch(layerNum, X, Y, X, Y - 1))
                tmpTile[2] = true;
            // West
            if (CheckTileMatch(layerNum, X, Y, X - 1, Y))
                tmpTile[3] = true;
            situation = AUTO_FILL;
            // Calculate Situation - Horizontal
            if (!tmpTile[2] && tmpTile[3])
                situation = AUTO_HORIZONTAL;
            // Vertical
            if (tmpTile[2] && !tmpTile[3])
                situation = AUTO_VERTICAL;
            // Fill
            if (tmpTile[1] && tmpTile[2] && tmpTile[3])
                situation = AUTO_FILL;
            // Inner
            if (!tmpTile[2] && !tmpTile[3])
                situation = AUTO_INNER;
            // Actually place the subtile
            switch (situation)
            {
                case AUTO_INNER:
                    {
                        PlaceAutotile(layerNum, X, Y, 1, "e");
                        break;
                    }

                case AUTO_HORIZONTAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 1, "i");
                        break;
                    }

                case AUTO_VERTICAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 1, "m");
                        break;
                    }

                case AUTO_FILL:
                    {
                        PlaceAutotile(layerNum, X, Y, 1, "q");
                        break;
                    }
            }
        }

        internal static void CalculateNE_Cliff(int layerNum, int X, int Y)
        {
            bool[] tmpTile = new bool[4];
            byte situation;

            // North

            if (CheckTileMatch(layerNum, X, Y, X, Y - 1))
                tmpTile[1] = true;
            // North East
            if (CheckTileMatch(layerNum, X, Y, X + 1, Y - 1))
                tmpTile[2] = true;
            // East
            if (CheckTileMatch(layerNum, X, Y, X + 1, Y))
                tmpTile[3] = true;
            situation = AUTO_FILL;
            // Calculate Situation - Horizontal
            if (!tmpTile[1] && tmpTile[3])
                situation = AUTO_HORIZONTAL;
            // Vertical
            if (tmpTile[1] && !tmpTile[3])
                situation = AUTO_VERTICAL;
            // Fill
            if (tmpTile[1] && tmpTile[2] && tmpTile[3])
                situation = AUTO_FILL;
            // Inner
            if (!tmpTile[1] && !tmpTile[3])
                situation = AUTO_INNER;
            // Actually place the subtile
            switch (situation)
            {
                case AUTO_INNER:
                    {
                        PlaceAutotile(layerNum, X, Y, 2, "j");
                        break;
                    }

                case AUTO_HORIZONTAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 2, "f");
                        break;
                    }

                case AUTO_VERTICAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 2, "r");
                        break;
                    }

                case AUTO_FILL:
                    {
                        PlaceAutotile(layerNum, X, Y, 2, "n");
                        break;
                    }
            }
        }

        internal static void CalculateSW_Cliff(int layerNum, int X, int Y)
        {
            bool[] tmpTile = new bool[4];
            byte situation;

            // West

            if (CheckTileMatch(layerNum, X, Y, X - 1, Y))
                tmpTile[1] = true;
            // South West
            if (CheckTileMatch(layerNum, X, Y, X - 1, Y + 1))
                tmpTile[2] = true;
            // South
            if (CheckTileMatch(layerNum, X, Y, X, Y + 1))
                tmpTile[3] = true;
            situation = AUTO_FILL;
            // Calculate Situation - Horizontal
            if (tmpTile[1] && !tmpTile[3])
                situation = AUTO_HORIZONTAL;
            // Vertical
            if (!tmpTile[1] && tmpTile[3])
                situation = AUTO_VERTICAL;
            // Fill
            if (tmpTile[1] && tmpTile[2] && tmpTile[3])
                situation = AUTO_FILL;
            // Inner
            if (!tmpTile[1] && !tmpTile[3])
                situation = AUTO_INNER;
            // Actually place the subtile
            switch (situation)
            {
                case AUTO_INNER:
                    {
                        PlaceAutotile(layerNum, X, Y, 3, "o");
                        break;
                    }

                case AUTO_HORIZONTAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 3, "s");
                        break;
                    }

                case AUTO_VERTICAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 3, "g");
                        break;
                    }

                case AUTO_FILL:
                    {
                        PlaceAutotile(layerNum, X, Y, 3, "k");
                        break;
                    }
            }
        }

        internal static void CalculateSE_Cliff(int layerNum, int X, int Y)
        {
            bool[] tmpTile = new bool[4];
            byte situation;

            // South

            if (CheckTileMatch(layerNum, X, Y, X, Y + 1))
                tmpTile[1] = true;
            // South East
            if (CheckTileMatch(layerNum, X, Y, X + 1, Y + 1))
                tmpTile[2] = true;
            // East
            if (CheckTileMatch(layerNum, X, Y, X + 1, Y))
                tmpTile[3] = true;
            situation = AUTO_FILL;
            // Calculate Situation -  Horizontal
            if (!tmpTile[1] && tmpTile[3])
                situation = AUTO_HORIZONTAL;
            // Vertical
            if (tmpTile[1] && !tmpTile[3])
                situation = AUTO_VERTICAL;
            // Fill
            if (tmpTile[1] && tmpTile[2] && tmpTile[3])
                situation = AUTO_FILL;
            // Inner
            if (!tmpTile[1] && !tmpTile[3])
                situation = AUTO_INNER;
            // Actually place the subtile
            switch (situation)
            {
                case AUTO_INNER:
                    {
                        PlaceAutotile(layerNum, X, Y, 4, "t");
                        break;
                    }

                case AUTO_HORIZONTAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 4, "p");
                        break;
                    }

                case AUTO_VERTICAL:
                    {
                        PlaceAutotile(layerNum, X, Y, 4, "l");
                        break;
                    }

                case AUTO_FILL:
                    {
                        PlaceAutotile(layerNum, X, Y, 4, "h");
                        break;
                    }
            }
        }

        internal static bool CheckTileMatch(int layerNum, int X1, int Y1, int X2, int Y2)
        {
            // we'll exit out early if true
            bool exTile;

            if (layerNum > (byte)Enums.LayerType.Count - 1)
            {
                exTile = true; layerNum = layerNum - (byte)(Enums.LayerType.Count - 1);
            }
            // if it's off the map then set it as autotile and exit out early
            if (X2 < 0 || X2 > E_Types.Map.MaxX || Y2 < 0 || Y2 > E_Types.Map.MaxY)
            {
                return true;
            }

            // fakes ALWAYS return true
            if (E_Types.Map.Tile[X2, Y2].Layer[layerNum].AutoTile == AUTOTILE_FAKE)
            {
                return true;
            }

            // check neighbour is an autotile
            if (E_Types.Map.Tile[X2, Y2].Layer[layerNum].AutoTile == 0)
            {
               return false;
            }

            // check we're a matching
            if (E_Types.Map.Tile[X1, Y1].Layer[layerNum].Tileset != E_Types.Map.Tile[X2, Y2].Layer[layerNum].Tileset)
            {
                return false;
            }

            // check tiles match
            if (E_Types.Map.Tile[X1, Y1].Layer[layerNum].X != E_Types.Map.Tile[X2, Y2].Layer[layerNum].X)
            {
                return false;
            }
            else if (E_Types.Map.Tile[X1, Y1].Layer[layerNum].Y != E_Types.Map.Tile[X2, Y2].Layer[layerNum].Y)
            {
                return false;
            }
            return true;
        }

        internal static void DrawAutoTile(int layerNum, int destX, int destY, int quarterNum, int X, int Y, int forceFrame = 0, bool strict = true, bool ExLayer = false)
        {
            int YOffset = 0;
            int XOffset = 0;
            Sprite tmpSprite;

            if (E_Globals.GettingMap)
                return;
            if (E_Globals.MapData == false)
                return;

            // calculate the offset
            if (forceFrame > 0)
            {
                switch (forceFrame - 1)
                {
                    case 0:
                        {
                            waterfallFrame = 1;
                            break;
                        }

                    case 1:
                        {
                            waterfallFrame = 2;
                            break;
                        }

                    case 2:
                        {
                            waterfallFrame = 0;
                            break;
                        }
                }
                // animate autotiles
                switch (forceFrame - 1)
                {
                    case 0:
                        {
                            autoTileFrame = 1;
                            break;
                        }

                    case 1:
                        {
                            autoTileFrame = 2;
                            break;
                        }

                    case 2:
                        {
                            autoTileFrame = 0;
                            break;
                        }
                }
            }

            switch (E_Types.Map.Tile[X, Y].Layer[layerNum].AutoTile)
            {
                case AUTOTILE_WATERFALL:
                    {
                        YOffset = (waterfallFrame - 1) * 32;
                        break;
                    }

                case AUTOTILE_ANIM:
                    {
                        XOffset = autoTileFrame * 64;
                        break;
                    }

                case AUTOTILE_CLIFF:
                    {
                        YOffset = -32;
                        break;
                    }
            }

            // Draw the quarter
            tmpSprite = new Sprite(E_Graphics.TileSetTexture[E_Types.Map.Tile[X, Y].Layer[layerNum].Tileset])
            {
                TextureRect = new IntRect(Autotile[X, Y].Layer[layerNum].srcX[quarterNum] + XOffset, Autotile[X, Y].Layer[layerNum].srcY[quarterNum] + YOffset, 16, 16),
                Position = new Vector2f(destX, destY)
            };
            E_Graphics.GameWindow.Draw(tmpSprite);
        }
    }
}
