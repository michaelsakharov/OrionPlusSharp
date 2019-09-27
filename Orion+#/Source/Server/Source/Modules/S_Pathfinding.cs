using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using static Engine.Enums;

namespace Engine
{
    public class modPathfinding
    {

        //=========================================================
        
        public static mapMatrixRec[] mapMatrix = new mapMatrixRec[Constants.MAX_MAPS];
        
        public struct mapMatrixRec
        {
            public bool created;
            public eCell[,] gaeGrid;
        };
        
        public enum eCell
        {
            Void = 0,
            Start = 1,
            Obstacle = 2,
            target = 3
        };
        
        
        private struct tCell
        {
            public int x;  // Coordinates of the listed cell
            public int y;
            public int Parent;  // Parent Index within the list (-1 for start point)
            public float Cost;  // Cost to get til here
            public float Heuristic;  // Estimated cost til target
            public bool Closed;  // Not considered anymore
        };
        
        
        private struct tGrid
        {
            public eListStat ListStat;  // Status of the list element
            public int Index;  // Index into the open list.
        };
        
        private enum eListStat
        {
            Unprocessed = 0,
            IsOpen = 1,
            IsClosed = 2
        };
        
        
        public struct tPoint
        {
            public int x;
            public int y;
        };
        
		public static bool APlus(int MapNum, int SX, int SY, int TX, int TY, eCell FreeCell, ref tPoint[] Path)
		{
			bool APlus = false;
			// A+ Pathfinding Algorithm:
			// Implementation by Herbert Glarner (herbert.glarner@bluewin.ch)
			// Unlimited use for whatever purpose allowed provided that above credits are given.
			// Suggestions and bug reports welcome.
			 int lMaxList = 0; 
			 int lActList; 
			 float sCheapCost; int lCheapIndex; 
			 float sTotalCost; 
			 int lCheapX,  lCheapY; 
			 int lOffX,  lOffY; 
			 int lTestX,  lTestY; 
			 int lMaxX,  lMaxY; 
			 float sAdditCost; 
			 int lPathPtr; 
        
			// The test program wants to access this grid. For this reason it is defined
			// and initialized globally. Usually one would define and initialize it only
			// in this procedure.
			// The two fields of tGrid can also be merged into the source matrix.
			// Dim abGridCopy() As tGrid
        
			 const float cSqr2 = 1.4142135623731f; 
        
			// Define the upper boundaries of the grid.
			lMaxX = Information.UBound(mapMatrix[MapNum].gaeGrid, 1); lMaxY = Information.UBound(mapMatrix[MapNum].gaeGrid, 2);
        
            // For each cell of the grid a bit is defined to hold it's "closed" status
            // and the index to the Open-List.
            // The test program wants to access this grid. For this reason it is defined
            // and initialized globally. Usually one would define and initialize it only
            // in this procedure. (Don't omit here: we need an empty matrix.)
            tGrid[,] abGridCopy = new tGrid[lMaxX + 1, lMaxY + 1];
        
            // The starting point is added to the working list. It has no parent (-1).
            // The cost to get here is 0 (we start here). The direct distance enters
            // the Heuristic.
            tCell[] grList = new tCell[0 + 1];
        
			grList[0].x = SX; grList[0].y = SY; grList[0].Parent = -1; grList[0].Cost = 0;
			grList[0].Heuristic = (float)(Math.Sqrt((TX-SX)*(TX-SX)+(TY-SY)*(TY-SY)));
        
        
			// Start the algorithm
			for(;;) {
				// Get the cell with the lowest Cost+Heuristic. Initialize the cheapest cost
				// with an impossible high value (change as needed). The best found index
				// is set to -1 to indicate "none found".
				sCheapCost = 10000000;
				lCheapIndex = -1;
				// Check all cells of the list. Initially, there is only the start point,
				// but more will be added soon.
				for(lActList=0; lActList<=lMaxList; lActList++) {
					// Only check if not closed already.
					if (!grList[lActList].Closed) {
						// If this cells total cost (Cost+Heuristic) is lower than the so
						// far lowest cost, then store this total cost and the cell's index
						// as the so far best found.
						sTotalCost = grList[lActList].Cost+grList[lActList].Heuristic;
						if (sTotalCost<sCheapCost) {
							// New cheapest cost found.
							sCheapCost = sTotalCost; lCheapIndex = lActList;
						}
					}
				} // lActList
        
				// lCheapIndex contains the cell with the lowest total cost now.
				// If no such cell could be found, all cells were already closed and there
				// is no path at all to the target.
				if (lCheapIndex==-1) {
					// There is no path.
					APlus = false; return APlus;
				}
        
				// Get the cheapest cell's coordinates
				lCheapX = grList[lCheapIndex].x;
				lCheapY = grList[lCheapIndex].y;
        
				// If the best field is the target field, we have found our path.
				if (lCheapX==TX & lCheapY==TY) {
					// Path found.
					break;
				}
        
				// Check all immediate neighbors
				for(lOffY=-1; lOffY<=1; lOffY++) {
					for(lOffX=-1; lOffX<=1; lOffX++) {
						// Ignore the actual field, process all others (8 neighbors).
						if (lOffX!=0 | lOffY!=0) {
							// ignore all diagonal movement
							if (!(lOffX!=0 & lOffY!=0)) {
								// Get the neighbor's coordinates.
								lTestX = lCheapX+lOffX; lTestY = lCheapY+lOffY;
								// Don't test beyond the grid's boundaries.
								if (lTestX>=0 & lTestX<=lMaxX & lTestY>=0 & lTestY<=lMaxY) {
									// The cell is within the grid's boundaries.
									// Make sure the field is accessible. To be accessible,
									// the cell must have the value as per the function
									// argument FreeCell (change as needed). Of course, the
									// target is allowed as well.
									if (mapMatrix[MapNum].gaeGrid[lTestX, lTestY]==FreeCell || mapMatrix[MapNum].gaeGrid[lTestX, lTestY]==eCell.target) {
										// The cell is accessible.
										// For this we created the "bitmatrix" abGridCopy().
										if (abGridCopy[lTestX, lTestY].ListStat==eListStat.Unprocessed) {
											// Register the new cell in the list.
											lMaxList += 1;
											 Array.Resize(ref grList, lMaxList + 1);
        
											// The parent is where we come from (the cheapest field);
											// it's index is registered.
											grList[lMaxList].x = lTestX; grList[lMaxList].y = lTestY; grList[lMaxList].Parent = lCheapIndex;
											// Additional cost is 1 for othogonal movement, cSqr2 for
											// diagonal movement (change if diagonal steps should have
											// a different cost).
											if (Math.Abs(lOffX)+Math.Abs(lOffY)==1) sAdditCost = (float)(1.0);											 else  sAdditCost = cSqr2;
											// Store cost to get there by summing the actual cell's cost
											// and the additional cost.
											grList[lMaxList].Cost = grList[lCheapIndex].Cost+sAdditCost;
											// Calculate distance to target as the heuristical part
											grList[lMaxList].Heuristic = (float)(Math.Sqrt((TX-lTestX)*(TX-lTestX)+(TY-lTestY)*(TY-lTestY)));
        
											// Register in the Grid copy as open.
											abGridCopy[lTestX, lTestY].ListStat = eListStat.IsOpen;
											// Also register the index to quickly find the element in the
											// "closed" list.
											abGridCopy[lTestX, lTestY].Index = lMaxList;
										} else if (abGridCopy[lTestX, lTestY].ListStat==eListStat.IsOpen) {
											// Is the cost to get to this already open field cheaper when using
											// this path via lTestX/lTestY ?
											lActList = abGridCopy[lTestX, lTestY].Index;
											sAdditCost = (float)((Math.Abs(lOffX)+Math.Abs(lOffY)==1 ? 1.0 : cSqr2));
											if (grList[lCheapIndex].Cost+sAdditCost<grList[lActList].Cost) {
												// The cost to reach the already open field is lower via the
												// actual field.
        
												// Store new cost
												grList[lActList].Cost = grList[lCheapIndex].Cost+sAdditCost;
												// Store new parent
												grList[lActList].Parent = lCheapIndex;
											}
											// ElseIf abGridCopy(lTestX, lTestY) = IsClosed Then
											// This cell can be ignored
										}
									}
								}
							}
						}
					} // lOffX
				} // lOffY
				// Close the just checked cheapest cell.
				grList[lCheapIndex].Closed = true;
				abGridCopy[lCheapX, lCheapY].ListStat = eListStat.IsClosed;
			}
        
            // The path can be found by backtracing from the field TX/TY until SX/SY.
            // The path is traversed in backwards order and stored reversely (!) in
            // the "argument" Path().
            Path = new tPoint[0 + 1];
			lPathPtr = -1;
			// lCheapIndex (lCheapX/Y) initially contains the target TX/TY
			do {
				// Store the coordinates of the current cell
				lPathPtr += 1;
				 Array.Resize(ref Path, lPathPtr + 1);
				Path[lPathPtr].x = grList[lCheapIndex].x;
				Path[lPathPtr].y = grList[lCheapIndex].y;
				// Follow the parent
				lCheapIndex = grList[lCheapIndex].Parent;
			} while (lCheapIndex!=-1);
        
			Console.WriteLine("Path found");
        
			APlus = true; 
        return APlus;
		}
        
		public static void CreatePathMatrix(int MapNum)
		{
			 int x,  y; 
        
			mapMatrix[MapNum].gaeGrid = new eCell[modTypes.Map[MapNum].MaxX + 1, modTypes.Map[MapNum].MaxY + 1];
			for(x=0; x<= modTypes.Map[MapNum].MaxX; x++) {
				for(y=0; y<= modTypes.Map[MapNum].MaxY; y++) {
					if (modTypes.Map[MapNum].Tile[x, y].Type != (int)Enums.TileType.None && modTypes.Map[MapNum].Tile[x, y].Type != (int)Enums.TileType.Warp && modTypes.Map[MapNum].Tile[x, y].Type != (int)Enums.TileType.Light && modTypes.Map[MapNum].Tile[x, y].Type != (int)Enums.TileType.House && modTypes.Map[MapNum].Tile[x, y].Type != (int)Enums.TileType.Item && modTypes.Map[MapNum].Tile[x, y].Type != (int)Enums.TileType.NpcSpawn) {
						mapMatrix[MapNum].gaeGrid[x, y] = eCell.Obstacle;
					} else {
						mapMatrix[MapNum].gaeGrid[x, y] = eCell.Void;
					}
				}
			}
        
			mapMatrix[MapNum].created = true;
			return;
		}
        
		public static void NpcMoveAlongPath(int MapNum, int MapNpcNum)
		{

			 int x,  y; 
        
			// make sure we're not at end of path
			if (modTypes.MapNpc[MapNum].Npc[MapNpcNum].pathLoc>=1) {
                x = modTypes.MapNpc[MapNum].Npc[MapNpcNum].arPath[modTypes.MapNpc[MapNum].Npc[MapNpcNum].pathLoc-1].x;
				y = modTypes.MapNpc[MapNum].Npc[MapNpcNum].arPath[modTypes.MapNpc[MapNum].Npc[MapNpcNum].pathLoc-1].y;
				// up
				if (y < modTypes.MapNpc[MapNum].Npc[MapNpcNum].Y) {
					if (S_Npc.CanNpcMove(MapNum, MapNpcNum, (int)DirectionType.Up)) {
                        S_Npc.NpcMove(MapNum, MapNpcNum, (int)DirectionType.Up, (int)MovementType.Walking);
						modTypes.MapNpc[MapNum].Npc[MapNpcNum].pathLoc -= 1;
						return;
					}
				}
				// down
				if (y > modTypes.MapNpc[MapNum].Npc[MapNpcNum].Y) {
					if (S_Npc.CanNpcMove(MapNum, MapNpcNum, (int)DirectionType.Down)) {
                        S_Npc.NpcMove(MapNum, MapNpcNum, (int)DirectionType.Down, (int)MovementType.Walking);
						modTypes.MapNpc[MapNum].Npc[MapNpcNum].pathLoc -= 1;
						return;
					}
				}
				// left
				if (x < modTypes.MapNpc[MapNum].Npc[MapNpcNum].X) {
					if (S_Npc.CanNpcMove(MapNum, MapNpcNum, (int)DirectionType.Left)) {
                        S_Npc.NpcMove(MapNum, MapNpcNum, (int)DirectionType.Left, (int)MovementType.Walking);
						modTypes.MapNpc[MapNum].Npc[MapNpcNum].pathLoc -= 1;
						return;
					}
				}
				// right
				if (x > modTypes.MapNpc[MapNum].Npc[MapNpcNum].X) {
					if (S_Npc.CanNpcMove(MapNum, MapNpcNum, (int)DirectionType.Right)) {
                        S_Npc.NpcMove(MapNum, MapNpcNum, (int)DirectionType.Right, (int)MovementType.Walking);
						modTypes.MapNpc[MapNum].Npc[MapNpcNum].pathLoc -= 1;
						return;
					}
				}
			}
            
		}

        public static void PetMoveAlongPath(int MapNum, int playerNum)
        {

            int x, y;

            // make sure we're not at end of path
            if (modTypes.Player[playerNum].Character[modTypes.TempPlayer[playerNum].CurChar].Pet.pathLoc >= 1)
            {
                x = modTypes.Player[playerNum].Character[modTypes.TempPlayer[playerNum].CurChar].Pet.arPath[modTypes.Player[playerNum].Character[modTypes.TempPlayer[playerNum].CurChar].Pet.pathLoc - 1].x;
                y = modTypes.Player[playerNum].Character[modTypes.TempPlayer[playerNum].CurChar].Pet.arPath[modTypes.Player[playerNum].Character[modTypes.TempPlayer[playerNum].CurChar].Pet.pathLoc - 1].y;
                
                // up
                if (y < modTypes.Player[playerNum].Character[modTypes.TempPlayer[playerNum].CurChar].Pet.Y)
                {
                    if (S_Pets.CanPetMove(playerNum, MapNum, (int)DirectionType.Up))
                    {
                        S_Pets.PetMove(playerNum, MapNum, (int)DirectionType.Up, (int)MovementType.Walking);
                        modTypes.Player[playerNum].Character[modTypes.TempPlayer[playerNum].CurChar].Pet.pathLoc -= 1;
                        return;
                    }
                }
                // down
                if (y > modTypes.Player[playerNum].Character[modTypes.TempPlayer[playerNum].CurChar].Pet.Y)
                {
                    if (S_Pets.CanPetMove(playerNum, MapNum, (int)DirectionType.Down))
                    {
                        S_Pets.PetMove(playerNum, MapNum, (int)DirectionType.Down, (int)MovementType.Walking);
                        modTypes.Player[playerNum].Character[modTypes.TempPlayer[playerNum].CurChar].Pet.pathLoc -= 1;
                        return;
                    }
                }
                // left
                if (x < modTypes.Player[playerNum].Character[modTypes.TempPlayer[playerNum].CurChar].Pet.X)
                {
                    if (S_Pets.CanPetMove(playerNum, MapNum, (int)DirectionType.Left))
                    {
                        S_Pets.PetMove(playerNum, MapNum, (int)DirectionType.Left, (int)MovementType.Walking);
                        modTypes.Player[playerNum].Character[modTypes.TempPlayer[playerNum].CurChar].Pet.pathLoc -= 1;
                        return;
                    }
                }
                // right
                if (x > modTypes.Player[playerNum].Character[modTypes.TempPlayer[playerNum].CurChar].Pet.X)
                {
                    if (S_Pets.CanPetMove(playerNum, MapNum, (int)DirectionType.Right))
                    {
                        S_Pets.PetMove(playerNum, MapNum, (int)DirectionType.Right, (int)MovementType.Walking);
                        modTypes.Player[playerNum].Character[modTypes.TempPlayer[playerNum].CurChar].Pet.pathLoc -= 1;
                        return;
                    }
                }
            }

        }

    }
}