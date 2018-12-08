using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using ASFW;
using static Engine.Types;

namespace Engine
{
    static class S_AutoMap
    {
        // Automapper System
        // Version: 1.0
        // Author: Lucas Tardivo (boasfesta)
        // Map analysis and tips: Richard Johnson, Luan Meireles (Alenzinho)


        private static MapOrientationRec[] _mapOrientation;

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

        enum TilePrefab
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

        // Distance between mountains and the map limit, so the player can walk freely when teleport between maps
        private const byte MountainBorder = 5;

        internal static Types.TileRec[] Tile = new Types.TileRec[8];
        static DetailRec[] Detail;
        internal static string ResourcesNum;
        private static string[] _resources;

        enum MountainTile
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

        enum MapPrefab
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

        struct DetailRec
        {
            public byte DetailBase;
            public Types.TileRec Tile;
        }

        struct MapOrientationRec
        {
            public int Prefab;
            public int TileStartX;
            public int TileStartY;
            public int TileEndX;
            public int TileEndY;
            public TilePrefab[,] Tile;
        }



        /// <summary>
    /// Loads TilePrefab from the Automapper.ini
    /// </summary>
        public static void LoadTilePrefab()
        {
            int prefab;
            int layer;

            XmlClass myXml = new XmlClass()
            {
                Filename = Path.Combine(Application.StartupPath, "Data", "AutoMapper.xml"),
                Root = "Options"
            };

            myXml.LoadXml();

            Tile = new TileRec[8];
            for (prefab = 1; prefab <= (int)TilePrefab.Count - 1; prefab++)
            {
                Tile[(int)prefab].Layer = new TileDataRec[6];
                for (layer = 1; layer <= (int)Enums.LayerType.Count - 1; layer++)
                {
                    Tile[(int)prefab].Layer[layer].Tileset = (byte)Conversion.Val(myXml.ReadString("Prefab" + prefab, "Layer" + layer + "Tileset"));
                    Tile[(int)prefab].Layer[layer].X = (byte)Conversion.Val(myXml.ReadString("Prefab" + prefab, "Layer" + layer + "X"));
                    Tile[(int)prefab].Layer[layer].Y = (byte)Conversion.Val(myXml.ReadString("Prefab" + prefab, "Layer" + layer + "Y"));
                    Tile[(int)prefab].Layer[layer].AutoTile = (byte)Conversion.Val(myXml.ReadString("Prefab" + prefab, "Layer" + layer + "Autotile"));
                }
                Tile[(int)prefab].Type = (byte)Conversion.Val(myXml.ReadString("Prefab" + prefab, "Type"));
            }

            ResourcesNum = myXml.ReadString("Resources", "ResourcesNum");
            _resources = Microsoft.VisualBasic.Strings.Split(ResourcesNum, ";");
        }

        /// <summary>
    /// Load details to the rec
    /// </summary>
    /// <param name="prefab">Which TilePrefab to use.</param>
    /// <param name="tileset">Tileset number to use.</param>
    /// <param name="x">The X coordinate, where the tiles start on the tilesheet.</param>
    /// <param name="y">The Y coordinate, where the tiles start on the tilesheet.</param>
    /// <param name="tileType">Which TileType to use, if any, blocked, None, etc</param>
    /// <param name="endX">The X coordinate, where the tiles end on the tilesheet.</param>
    /// <param name="endY">The Y coordinate, where the tiles end on the tilesheet.</param>
        static void LoadDetail(TilePrefab prefab, int tileset, int x, int y, int tileType = 0, int endX = 0, int endY = 0)
        {
            if (endX == 0)
                endX = x;
            if (endY == 0)
                endY = y;
            int pX;
            int pY;
            var loopTo = endX;
            for (pX = x; pX <= loopTo; pX++)
            {
                var loopTo1 = endY;
                for (pY = y; pY <= loopTo1; pY++)
                    AddDetail(prefab, tileset, pX, pY, tileType);
            }
        }

        /// <summary>
    /// Load details to memory for mapping.
    /// </summary>
    /// <param name="prefab">Which TilePrefab to use.</param>
    /// <param name="tileset">Tileset number to use.</param>
    /// <param name="x">The X coordinate, where the tiles start on the tilesheet.</param>
    /// <param name="y">The Y coordinate, where the tiles start on the tilesheet.</param>
    /// <param name="tileType">Which TileType to use, if any, blocked, None, etc.</param>
        static void AddDetail(TilePrefab prefab, int tileset, int x, int y, int tileType)
        {
            int detailCount;

            detailCount = Information.UBound(Detail) + 1;
            var oldDetail = Detail;
            Detail = new DetailRec[detailCount + 1];
            if (oldDetail != null)
                Array.Copy(oldDetail, Detail, Math.Min(detailCount + 1, oldDetail.Length));
            var oldLayer = Detail[detailCount].Tile.Layer;
            Detail[detailCount].Tile.Layer = new TileDataRec[6];
            if (oldLayer != null)
                Array.Copy(oldLayer, Detail[detailCount].Tile.Layer, Math.Min(6, oldDetail[detailCount].Tile.Layer.Length));

            Detail[detailCount].DetailBase = (byte)prefab;
            Detail[detailCount].Tile.Type = (byte)tileType;
            Detail[detailCount].Tile.Layer[(int)Enums.LayerType.Mask2].Tileset = (byte)tileset;
            Detail[detailCount].Tile.Layer[(int)Enums.LayerType.Mask2].X = (byte)x;
            Detail[detailCount].Tile.Layer[(int)Enums.LayerType.Mask2].Y = (byte)y;
        }

        /// <summary>
    /// Here a user can define which details to add
    /// </summary>
        public static void LoadDetails()
        {
            Detail = new DetailRec[2];

            // Detail config area
            // Use: LoadDetail TilePrefab, Tileset, StartTilesetX, StartTilesetY, TileType, EndTilesetX, EndTilesetY
            LoadDetail(TilePrefab.Grass, 9, 0, 0, (int)Enums.TileType.None, 9, 15);

            LoadDetail(TilePrefab.Sand, 10, 0, 13, (int)Enums.TileType.None, 7, 14);
            LoadDetail(TilePrefab.Sand, 11, 0, 0, (int)Enums.TileType.None, 1, 1);
        }

        /// <summary>
    /// Check for details
    /// </summary>
    /// <param name="prefab"></param>
    /// <returns></returns>
        static bool HaveDetails(TilePrefab prefab)
        {
            return !(prefab == TilePrefab.Water || prefab == TilePrefab.River);
        }



        public static void Packet_RequestAutoMap(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved EMSG: RequestAutoMap");

            if (S_Players.GetPlayerAccess(index) == (byte)Enums.AdminType.Player)
                return;

            SendAutoMapper(index);
        }

        public static void Packet_SaveAutoMap(int index, ref byte[] data)
        {
            int Layer;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved EMSG: SaveAutoMap");

            if (S_Players.GetPlayerAccess(index) == (byte)Enums.AdminType.Player)
                return;

            MapStart = buffer.ReadInt32();
            MapSize = buffer.ReadInt32();
            MapX = buffer.ReadInt32();
            MapY = buffer.ReadInt32();
            SandBorder = buffer.ReadInt32();
            DetailFreq = buffer.ReadInt32();
            ResourceFreq = buffer.ReadInt32();

            XmlClass myXml = new XmlClass()
            {
                Filename = Application.StartupPath + @"\Data\AutoMapper.xml",
                Root = "Options"
            };

            myXml.LoadXml();

            myXml.WriteString("Resources", "ResourcesNum", buffer.ReadString());

            for (var Prefab = 1; Prefab <= (int)TilePrefab.Count - 1; Prefab++)
            {
                Tile[Prefab].Layer = new TileDataRec[6];

                Layer = buffer.ReadInt32();
                myXml.WriteString("Prefab" + Prefab, "Layer" + Layer + "Tileset", buffer.ReadInt32().ToString());
                myXml.WriteString("Prefab" + Prefab, "Layer" + Layer + "X", buffer.ReadInt32().ToString());
                myXml.WriteString("Prefab" + Prefab, "Layer" + Layer + "Y", buffer.ReadInt32().ToString());
                myXml.WriteString("Prefab" + Prefab, "Layer" + Layer + "Autotile", buffer.ReadInt32().ToString());

                myXml.WriteString("Prefab" + Prefab, "Type", buffer.ReadInt32().ToString());
            }

            buffer.Dispose();

            myXml.CloseXml(true);

            StartAutomapper(MapStart, MapSize, MapX, MapY);
        }



        public static void SendAutoMapper(int index)
        {
            ByteStream buffer;
            int Prefab;
            XmlClass myXml = new XmlClass()
            {
                Filename = Application.StartupPath + @"\Data\AutoMapper.xml",
                Root = "Options"
            };
            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SAutoMapper);

            S_General.AddDebug("Sent SMSG: SAutoMapper");

            buffer.WriteInt32(MapStart);
            buffer.WriteInt32(MapSize);
            buffer.WriteInt32(MapX);
            buffer.WriteInt32(MapY);
            buffer.WriteInt32(SandBorder);
            buffer.WriteInt32(DetailFreq);
            buffer.WriteInt32(ResourceFreq);

            myXml.LoadXml();

            // send xml info
            buffer.WriteString((myXml.ReadString("Resources", "ResourcesNum")));

            for (Prefab = 1; Prefab <= (int)TilePrefab.Count - 1; Prefab++)
            {
                for (var Layer = 1; Layer <= (int)Enums.LayerType.Count - 1; Layer++)
                {
                    if ((int)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "Tileset")) > 0)
                    {
                        buffer.WriteInt32(Layer);
                        buffer.WriteInt32((int)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "Tileset")));
                        buffer.WriteInt32((int)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "X")));
                        buffer.WriteInt32((int)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "Y")));
                        buffer.WriteInt32((int)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "Autotile")));
                    }
                }
                buffer.WriteInt32((int)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Type")));
            }

            myXml.CloseXml(false);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }



        static void AddTile(TilePrefab prefab, int mapNum, int x, int y)
        {
            Types.TileRec tileDest;
            bool cleanNextTiles = false;
            int i = 0;

            // DetailFreq = Val(frmAutoMapper.txtDetail.Text)

            tileDest = modTypes.Map[mapNum].Tile[x, y];
            tileDest.Type = Tile[(int)prefab].Type;
            var oldLayer = tileDest.Layer;
            tileDest.Layer = new TileDataRec[6];
            if (oldLayer != null)
                Array.Copy(oldLayer, tileDest.Layer, Math.Min(6, oldLayer.Length));

            for (i = 1; i <= (int)Enums.LayerType.Count - 1; i++)
            {
                if (Tile[(int)prefab].Layer[i].Tileset != 0 || cleanNextTiles)
                {
                    tileDest.Layer[i] = Tile[(int)prefab].Layer[i];
                    if (!HaveDetails(prefab))
                        cleanNextTiles = true;
                }
            }

            if (prefab == TilePrefab.Grass || prefab == TilePrefab.Sand)
            {
                if (DetailsChecked == true)
                {
                    if (S_GameLogic.Random(1, DetailFreq) == 1)
                    {
                        int detailNum;
                        int[] details;
                        details = new int[2];
                        var loopTo = Information.UBound(Detail);
                        for (i = 1; i <= loopTo; i++)
                        {
                            if (Detail[i].DetailBase == (byte)prefab)
                            {
                                var oldDetails = details;
                                details = new int[Information.UBound(details) + 1 + 1];
                                if (oldDetails != null)
                                    Array.Copy(oldDetails, details, Math.Min(Information.UBound(details) + 1 + 1, oldDetails.Length));
                                details[Information.UBound(details)] = i;
                            }
                        }
                        if (Information.UBound(details) > 1)
                        {
                            detailNum = details[S_GameLogic.Random(2, Information.UBound(details))];
                            if (Detail[detailNum].DetailBase == (byte)prefab)
                            {
                                tileDest.Layer[3] = Detail[detailNum].Tile.Layer[3];
                                tileDest.Type = Detail[detailNum].Tile.Type;
                            }
                        }
                    }
                }
            }

            modTypes.Map[mapNum].Tile[x, y] = tileDest;
            _mapOrientation[mapNum].Tile[x, y] = prefab;
        }

        public static bool CanPlaceResource(int mapNum, int X, int Y)
        {
            bool flag = S_AutoMap._mapOrientation[mapNum].Tile[X, Y] == S_AutoMap.TilePrefab.Grass || S_AutoMap._mapOrientation[mapNum].Tile[X, Y] == S_AutoMap.TilePrefab.Overgrass || (S_AutoMap._mapOrientation[mapNum].Tile[X, Y] == S_AutoMap.TilePrefab.Mountain && modTypes.Map[mapNum].Tile[X, Y].Type != 1);
            bool CanPlaceResource = false;
            if (flag)
            {
                CanPlaceResource = true;
            }
            return CanPlaceResource;
        }


        public static bool CanPlaceOvergrass(int mapNum, int X, int Y)
        {
            bool flag = S_AutoMap._mapOrientation[mapNum].Tile[X, Y] == S_AutoMap.TilePrefab.Grass || (S_AutoMap._mapOrientation[mapNum].Tile[X, Y] == S_AutoMap.TilePrefab.Mountain && modTypes.Map[mapNum].Tile[X, Y].Type != 1);
            bool CanPlaceOvergrass = false;
            if (flag)
            {
                CanPlaceOvergrass = true;
            }
            return CanPlaceOvergrass;
        }

        static void MakeResource(int mapNum)
        {
            int x;
            int y;
            var loopTo = modTypes.Map[mapNum].MaxX - 1;
            for (x = 1; x <= loopTo; x++)
            {
                var loopTo1 = modTypes.Map[mapNum].MaxY - 1;
                for (y = 1; y <= loopTo1; y++)
                {
                    if (CanPlaceResource(mapNum, x, y) && CanPlaceResource(mapNum, x - 1, y) && CanPlaceResource(mapNum, x + 1, y) && CanPlaceResource(mapNum, x, y - 1) && CanPlaceResource(mapNum, x, y + 1))
                    {
                        int resourceNum;

                        if (_resources[0] == "")
                            return;

                        if (S_GameLogic.Random(1, ResourceFreq) == 1)
                        {
                            resourceNum = (int)Conversion.Val(_resources[S_GameLogic.Random(1, Information.UBound(_resources))]);
                            modTypes.Map[mapNum].Tile[x, y].Type = (byte)Enums.TileType.Resource;
                            modTypes.Map[mapNum].Tile[x, y].Data1 = resourceNum;
                        }
                    }
                }
            }
        }

        public static void MakeResources(int mapStart, int size)
        {
            int i;
            int totalMaps;
            int tick;

            Console.WriteLine("Working...");
            Application.DoEvents();
            tick = S_General.GetTimeMs();
            totalMaps = size * size;
            var loopTo = mapStart + totalMaps - 1;
            for (i = mapStart; i <= loopTo; i++)
            {
                MakeResource(i);
                S_Resources.CacheResources(i);
            }

            tick = S_General.GetTimeMs() - tick;
            Console.WriteLine("Done and cached resources in " + System.Convert.ToString(tick / (double)1000) + "s");
            Application.DoEvents();
        }

        public static void MakeOvergrasses(int mapStart, int size)
        {
            int i;
            int totalMaps;
            int tick;

            Console.WriteLine("Working...");
            Application.DoEvents();
            tick = S_General.GetTimeMs();
            totalMaps = size * size;
            var loopTo = mapStart + totalMaps - 1;
            for (i = mapStart; i <= loopTo; i++)
                MakeOvergrass(i);

            tick = S_General.GetTimeMs() - tick;
            Console.WriteLine("Done overgrasses in " + System.Convert.ToString(tick / (double)1000) + "s");
            Application.DoEvents();
        }

        public static void MakeOvergrass(int mapNum)
        {
            int startX = 0;
            int startY = 0;
            int totalOvergrass = 0;
            int x = 0;
            // Dim MapSize As Integer
            int y = 0;
            int grassCount = 0;
            int overgrassCount = 0;
            int nextDir = 0;
            int brushSize = 0;
            bool foundBorder = false;

            {
                var loopTo = modTypes.Map[mapNum].MaxX;
                for (int xx = 0; xx <= loopTo; xx++)
                {
                    var loopTo1 = modTypes.Map[mapNum].MaxY;
                    for (y = 0; y <= loopTo1; y++)
                    {
                        if (CanPlaceOvergrass(mapNum, xx, y))
                            grassCount = grassCount + 1;
                    }
                }

                totalOvergrass = S_GameLogic.Random((int)Conversion.Int(grassCount / (double)100), Conversion.Int(grassCount / (int)50));

                while (overgrassCount >= totalOvergrass)
                {
                    int totalWalk;
                    brushSize = S_GameLogic.Random(1, 2);
                    startX = S_GameLogic.Random(0, modTypes.Map[mapNum].MaxX);
                    startY = S_GameLogic.Random(0, modTypes.Map[mapNum].MaxY);

                    if (CanPlaceOvergrass(mapNum, startX, startY))
                    {
                        PaintOvergrass(mapNum, startX, startY, brushSize, brushSize);
                        x = startX;
                        y = startY;
                        totalWalk = 1;
                        nextDir = 0;
                        while (nextDir != 5 && totalWalk < 15)
                        {
                            if (foundBorder)
                                nextDir = S_GameLogic.Random(0, 5);
                            else
                                nextDir = S_GameLogic.Random(0, 4);
                            switch (nextDir)
                            {
                                case (byte)Enums.DirectionType.Up:
                                    {
                                        y = y - 1;
                                        break;
                                    }

                                case (byte)Enums.DirectionType.Down:
                                    {
                                        y = y + 1;
                                        break;
                                    }

                                case (byte)Enums.DirectionType.Left:
                                    {
                                        x = x - 1;
                                        break;
                                    }

                                case (byte)Enums.DirectionType.Right:
                                    {
                                        x = x + 1;
                                        break;
                                    }
                            }
                            if (nextDir < 5)
                            {
                                if (x > 0 && x < modTypes.Map[mapNum].MaxX)
                                {
                                    if (y > 0 && y < modTypes.Map[mapNum].MaxY)
                                    {
                                        if (CanPlaceOvergrass(mapNum, x, y))
                                        {
                                            brushSize = S_GameLogic.Random(0, 2);
                                            PaintOvergrass(mapNum, x, y, brushSize, brushSize);
                                            totalWalk = totalWalk + 1;
                                            foundBorder = true;
                                        }
                                        else if (_mapOrientation[mapNum].Tile[x, y] == TilePrefab.Overgrass)
                                            foundBorder = false;
                                        else
                                            nextDir = 5;
                                    }
                                    else
                                        nextDir = 5;
                                }
                                else
                                    nextDir = 5;
                            }
                        }
                        overgrassCount = overgrassCount + 1;
                    }
                }
            }
        }

        public static void PaintOvergrass(int mapNum, int x, int y, int brushSizeX, int brushSizeY)
        {
            int pX;
            int pY;
            var loopTo = x + brushSizeX;
            for (pX = x - brushSizeX; pX <= loopTo; pX++)
            {
                var loopTo1 = y + brushSizeY;
                for (pY = y - brushSizeY; pY <= loopTo1; pY++)
                {
                    if (pX >= 0 && pX <= modTypes.Map[mapNum].MaxX)
                    {
                        if (pY >= 0 && pY <= modTypes.Map[mapNum].MaxY)
                        {
                            if (_mapOrientation[mapNum].Tile[(int)pX, pY] != TilePrefab.Overgrass)
                            {
                                if (CanPlaceOvergrass(mapNum, pX, pY))
                                {
                                    if (S_GameLogic.Random(1, 100) >= 50)
                                        AddTile(TilePrefab.Overgrass, mapNum, pX, pY);
                                }
                            }
                        }
                    }
                }
            }
        }

        static void PaintTile(TilePrefab prefab, int mapNum, int x, int y, int brushSizeX, int brushSizeY, bool humanMade = true, TilePrefab onlyTo = 0)
        {
            int pX;
            int pY;
            var loopTo = x + brushSizeX;
            for (pX = x - brushSizeX; pX <= loopTo; pX++)
            {
                var loopTo1 = y + brushSizeY;
                for (pY = y - brushSizeY; pY <= loopTo1; pY++)
                {
                    if (pX >= 0 && pX <= modTypes.Map[mapNum].MaxX)
                    {
                        if (pY >= 0 && pY <= modTypes.Map[mapNum].MaxY)
                        {
                            if (_mapOrientation[mapNum].Tile[(int)pX, pY] != prefab)
                            {
                                bool canPaint;
                                canPaint = true;
                                if (onlyTo != 0)
                                {
                                    if (_mapOrientation[mapNum].Tile[(int)pX, pY] != onlyTo)
                                        canPaint = false;
                                }
                                if (canPaint)
                                {
                                    if (humanMade)
                                        AddTile(prefab, mapNum, pX, pY);
                                    else if (S_GameLogic.Random(1, 100) >= 50)
                                        AddTile(prefab, mapNum, pX, pY);
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void PaintRiver(int mapNum, int X, int Y, byte riverDir, int riverWidth)
        {
            int pX;
            int pY;
            if (riverDir == (byte)Enums.DirectionType.Down)
            {
                var loopTo = X + riverWidth;
                for (pX = X - riverWidth; pX <= loopTo; pX++)
                {
                    if (pX > 0 && pX < modTypes.Map[mapNum].MaxX)
                        AddTile(TilePrefab.River, mapNum, pX, Y);
                }
            }
            if (riverDir == (byte)Enums.DirectionType.Left || riverDir == (byte)Enums.DirectionType.Right)
            {
                var loopTo1 = Y + riverWidth;
                for (pY = Y - riverWidth; pY <= loopTo1; pY++)
                {
                    if (pY > 0 && pY < modTypes.Map[mapNum].MaxY)
                        AddTile(TilePrefab.River, mapNum, X, pY);
                }
            }
        }

        public static void MakeRivers(int mapStart, int size)
        {
            // Dim RiverType As Integer
            int riverMap;
            int totalRivers;
            int totalMaps;
            int madeRivers;
            int riverX;
            int riverY;
            int riverWidth;
            int riverHeight;
            byte riverDir;
            int riverBorder;
            int riverFlowWidth;
            bool riverEnd;
            int riverSteps;
            int tick;

            Console.WriteLine("Working...");
            Application.DoEvents();
            tick = S_General.GetTimeMs();
            riverBorder = 4;
            madeRivers = 0;
            totalMaps = size * size;
            totalRivers = Conversion.Int(totalMaps / (int)4);

            while (madeRivers <= totalRivers)
            {
            // Start river
            SelectMap:
                ;
                riverMap = S_GameLogic.Random(mapStart, mapStart + totalMaps - 1);
                if (_mapOrientation[riverMap].Prefab != (byte)MapPrefab.Common)
                    goto SelectMap;
                riverX = S_GameLogic.Random(riverBorder, modTypes.Map[riverMap].MaxX - riverBorder);
                riverY = S_GameLogic.Random(riverBorder, modTypes.Map[riverMap].MaxY - riverBorder);
                riverWidth = S_GameLogic.Random(2, 3);
                riverHeight = S_GameLogic.Random(2, 3);
                AddTile(TilePrefab.River, riverMap, riverX, riverY);
                PaintTile(TilePrefab.River, riverMap, riverX, riverY, riverWidth, riverHeight, false);
                riverDir = (byte)S_GameLogic.Random(1, 3);
                riverEnd = false;
                riverSteps = 0;
                riverFlowWidth = S_GameLogic.Random(1, 3);
                while (_mapOrientation[riverMap].Tile[riverX, riverY] != TilePrefab.River)
                {
                    if (riverDir == (int)Enums.DirectionType.Left)
                    {
                        riverX = riverX - 1;
                        if (riverX < 0)
                        {
                            riverX = 0;
                            riverDir = (int)Enums.DirectionType.Right;
                        }
                    }
                    if (riverDir == (int)Enums.DirectionType.Down)
                    {
                        riverY = riverY + 1;
                        if (riverY > modTypes.Map[riverMap].MaxY)
                        {
                            riverY = modTypes.Map[riverMap].MaxY;
                            riverDir = (byte)S_GameLogic.Random(2, 3);
                        }
                    }
                    if (riverDir == (int)Enums.DirectionType.Right)
                    {
                        riverX = riverX + 1;
                        if (riverX > modTypes.Map[riverMap].MaxX)
                        {
                            riverX = modTypes.Map[riverMap].MaxX;
                            riverDir = (int)Enums.DirectionType.Left;
                        }
                    }
                }
                while (!riverEnd)
                {
                    riverSteps = riverSteps + 1;
                    if (riverX < 0)
                        riverX = 0;
                    if (riverX > modTypes.Map[riverMap].MaxX)
                        riverX = modTypes.Map[riverMap].MaxX;
                    if (riverY < 0)
                        riverY = 0;
                    if (riverY > modTypes.Map[riverMap].MaxY)
                        riverY = modTypes.Map[riverMap].MaxY;
                    PaintRiver(riverMap, riverX, riverY, riverDir, riverFlowWidth);
                    switch (riverDir)
                    {
                        case (int)Enums.DirectionType.Left:
                            {
                                riverY = riverY + S_GameLogic.Random(-1, 1);
                                break;
                            }

                        case (int)Enums.DirectionType.Down:
                            {
                                riverX = riverX + S_GameLogic.Random(-1, 1);
                                break;
                            }

                        case (int)Enums.DirectionType.Right:
                            {
                                riverY = riverY + S_GameLogic.Random(-1, 1);
                                break;
                            }
                    }

                    if (S_GameLogic.Random(1, 100) < 5)
                        riverDir = (byte)S_GameLogic.Random(1, 3);
                    switch (riverDir)
                    {
                        case (int)Enums.DirectionType.Left:
                            {
                                riverX = riverX - 1;
                                break;
                            }

                        case (int)Enums.DirectionType.Down:
                            {
                                riverY = riverY + 1;
                                break;
                            }

                        case (int)Enums.DirectionType.Right:
                            {
                                riverX = riverX + 1;
                                break;
                            }
                    }
                    if (riverDir == (int)Enums.DirectionType.Down)
                    {
                        if (_mapOrientation[modTypes.Map[riverMap].Down].Prefab == (int)MapPrefab.Common)
                        {
                            if (riverY > modTypes.Map[riverMap].MaxY)
                            {
                                riverMap = modTypes.Map[riverMap].Down;
                                riverY = 0;
                            }
                        }
                        else if (riverY > modTypes.Map[riverMap].MaxY / (double)2)
                        {
                            PaintTile(TilePrefab.River, riverMap, riverX, riverY, S_GameLogic.Random(2, 3), S_GameLogic.Random(3, 4), false);
                            riverEnd = true;
                        }
                    }
                    if (riverDir == (int)Enums.DirectionType.Left)
                    {
                        if (_mapOrientation[modTypes.Map[riverMap].Left].Prefab == (int)MapPrefab.Common)
                        {
                            if (riverX < 0)
                            {
                                // MapCache_Create RiverMap
                                riverMap = modTypes.Map[riverMap].Left;
                                riverX = modTypes.Map[riverMap].MaxX;
                            }
                        }
                        else if (riverX < modTypes.Map[riverMap].MaxX / (double)2)
                        {
                            PaintTile(TilePrefab.River, riverMap, riverX, riverY, S_GameLogic.Random(2, 3), S_GameLogic.Random(3, 4), false);
                            riverEnd = true;
                        }
                    }
                    if (riverDir == (int)Enums.DirectionType.Right)
                    {
                        if (_mapOrientation[modTypes.Map[riverMap].Right].Prefab == (int)MapPrefab.Common)
                        {
                            if (riverX > modTypes.Map[riverMap].MaxX)
                            {
                                // MapCache_Create RiverMap
                                riverMap = modTypes.Map[riverMap].Right;
                                riverX = 0;
                            }
                        }
                        else if (riverX > modTypes.Map[riverMap].MaxX / (double)2)
                        {
                            PaintTile(TilePrefab.River, riverMap, riverX, riverY, S_GameLogic.Random(2, 3), S_GameLogic.Random(3, 4), false);
                            riverEnd = true;
                        }
                    }
                }
                madeRivers = madeRivers + 1;
            }

            tick = S_General.GetTimeMs() - tick;
            Console.WriteLine("Done " + totalRivers + " rivers in " + System.Convert.ToString(tick / (double)1000) + "s");
            Application.DoEvents();
        }

        static void PlaceMountain(int mapNum, int x, int y, MountainTile mountainPrefab)
        {
            int oldX;
            int oldY;

            oldX = Tile[(int)TilePrefab.Mountain].Layer[2].X;
            oldY = Tile[(int)TilePrefab.Mountain].Layer[2].Y;
            Tile[(int)TilePrefab.Mountain].Layer[2].X = (byte)(oldX + ((int)mountainPrefab % 3));
            Tile[(int)TilePrefab.Mountain].Layer[2].Y = (byte)(oldY + ((int)Conversion.Int((int)mountainPrefab / (int)3)));
            AddTile(TilePrefab.Mountain, mapNum, x, y);
            Tile[(int)TilePrefab.Mountain].Layer[2].X = (byte)oldX;
            Tile[(int)TilePrefab.Mountain].Layer[2].Y = (byte)oldY;
        }

        public static void MarkMountain(int mapNum, int x, int y, int width, int height)
        {
            int pX;
            int pY;
            var loopTo = x + Conversion.Int(width / (double)2);
            for (pX = x - Conversion.Int(width / (int)2); pX <= loopTo; pX++)
            {
                var loopTo1 = y + Conversion.Int(height / (double)2);
                for (pY = y - Conversion.Int(height / (int)2); pY <= loopTo1; pY++)
                {
                    if (pX > MountainBorder && pX < modTypes.Map[mapNum].MaxX - MountainBorder)
                    {
                        if (pY > MountainBorder && pY < modTypes.Map[mapNum].MaxY - MountainBorder)
                            _mapOrientation[mapNum].Tile[(int)pX, pY] = TilePrefab.Mountain;
                    }
                }
            }
        }

        public static void MakeMapMountains(int mapNum)
        {
            int mountainMinAreaWidth;
            int MountainMinAreaHeight;
            int mountainMinSize;
            int MountainMinArea;
            int mountainSize;
            int x;
            int y;
            // Dim ScanX As Integer, ScanY As Integer
            // Dim FoundPlace As Boolean
            int totalGrass = 0;
            int totalMountains;
            int i;
            int positionTries;
            int mountainSteps;
            mountainMinAreaWidth = 5;
            MountainMinAreaHeight = 5;
            MountainMinArea = 4;
            mountainMinSize = 10;
            var loopTo = modTypes.Map[mapNum].MaxX - MountainBorder;
            for (x = MountainBorder; x <= loopTo; x++)
            {
                var loopTo1 = modTypes.Map[mapNum].MaxY - MountainBorder;
                for (y = MountainBorder; y <= loopTo1; y++)
                {
                    if (_mapOrientation[mapNum].Tile[x, y] == TilePrefab.Grass)
                        totalGrass = totalGrass + 1;
                }
            }

            totalMountains = S_GameLogic.Random(0, (totalGrass / (int)(mountainMinAreaWidth * MountainMinAreaHeight)));

            if (totalMountains > 0)
            {
                var loopTo2 = totalMountains;
                for (i = 1; i <= loopTo2; i++)
                {
                    positionTries = 0;
                Retry:
                    ;
                    if (positionTries < 5)
                    {
                        x = S_GameLogic.Random(mountainMinAreaWidth + MountainBorder, modTypes.Map[mapNum].MaxX - mountainMinAreaWidth - MountainBorder);
                        y = S_GameLogic.Random(MountainMinAreaHeight + MountainBorder, modTypes.Map[mapNum].MaxY - MountainMinAreaHeight - MountainBorder);
                        if (!ValidMountainPosition(mapNum, x, y, mountainMinAreaWidth, MountainMinAreaHeight))
                        {
                            positionTries = positionTries + 1;
                            goto Retry;
                        }
                        MarkMountain(mapNum, x, y, mountainMinAreaWidth, MountainMinAreaHeight);

                        mountainSteps = 0;
                        mountainSize = S_GameLogic.Random(mountainMinSize, mountainMinSize * (totalMountains / (int)i));

                        while (mountainSteps < mountainSize)
                        {
                            int OldX;
                            int OldY;
                            OldX = x;
                            OldY = y;
                            x = x + (S_GameLogic.Random(0, 2) - 1);
                            y = y + (S_GameLogic.Random(0, 2) - 1);
                            if (ValidMountainPosition(mapNum, x, y, 3, 5))
                                MarkMountain(mapNum, x, y, 3, 5);
                            else
                            {
                                // Return
                                x = OldX;
                                y = OldY;
                            }
                            mountainSteps = mountainSteps + 1;
                        }
                    }
                }

                var loopTo3 = modTypes.Map[mapNum].MaxX - MountainBorder;

                // Fill Mountain
                for (x = MountainBorder; x <= loopTo3; x++)
                {
                    var loopTo4 = modTypes.Map[mapNum].MaxY - MountainBorder;
                    for (y = MountainBorder; y <= loopTo4; y++)
                    {
                        if (_mapOrientation[mapNum].Tile[x, y] == TilePrefab.Mountain)
                        {
                            MountainTile mountainPrefab;
                            mountainPrefab = GetMountainPrefab(mapNum, x, y);
                            // Exceptions
                            if (!(_mapOrientation[mapNum].Tile[x, y - 1] != TilePrefab.Mountain))
                            {
                                if (((GetMountainPrefab(mapNum, x - 1, y) == MountainTile.MiddleFoot || GetMountainPrefab(mapNum, x - 1, y) == MountainTile.LeftFoot) || (GetMountainPrefab(mapNum, x - 1, y) == MountainTile.LeftBody || GetMountainPrefab(mapNum, x - 1, y) == MountainTile.MiddleBody)) && !(mountainPrefab == MountainTile.MiddleBody || mountainPrefab == MountainTile.MiddleFoot || mountainPrefab == MountainTile.RightBody || mountainPrefab == MountainTile.RightFoot))
                                    mountainPrefab = MountainTile.MidLeftBorder;
                                if (GetMountainPrefab(mapNum, x, y + 1) == MountainTile.LeftFoot)
                                {
                                    mountainPrefab = MountainTile.LeftBody;
                                    goto Important;
                                }
                                if (GetMountainPrefab(mapNum, x, y + 2) == MountainTile.LeftFoot)
                                {
                                    mountainPrefab = MountainTile.BottomLeftBorder;
                                    goto Important;
                                }
                                if (((GetMountainPrefab(mapNum, x + 1, y) == MountainTile.MiddleFoot || GetMountainPrefab(mapNum, x + 1, y) == MountainTile.RightFoot) || (GetMountainPrefab(mapNum, x + 1, y) == MountainTile.RightBody || GetMountainPrefab(mapNum, x + 1, y) == MountainTile.MiddleBody)) && !(mountainPrefab == MountainTile.MiddleBody || mountainPrefab == MountainTile.MiddleFoot || mountainPrefab == MountainTile.LeftBody || mountainPrefab == MountainTile.LeftFoot))
                                    mountainPrefab = MountainTile.MidRightBorder;
                                if (GetMountainPrefab(mapNum, x, y + 1) == MountainTile.RightFoot)
                                {
                                    mountainPrefab = MountainTile.RightBody;
                                    goto Important;
                                }
                                if (GetMountainPrefab(mapNum, x, y + 2) == MountainTile.RightFoot)
                                {
                                    mountainPrefab = MountainTile.BottomRightBorder;
                                    goto Important;
                                }
                            }

                        Important:
                            ;
                            if (mountainPrefab >= 0)
                                PlaceMountain(mapNum, x, y, mountainPrefab);
                        }
                    }
                }
            }
        }

        static MountainTile GetMountainPrefab(int mapNum, int x, int y)
        {
            byte verticalPos;
            S_AutoMap.MountainTile GetMountainPrefab;
            MountainTile mountainPrefab;
            if (_mapOrientation[mapNum].Tile[x, y] == TilePrefab.Mountain)
            {
                verticalPos = 1;
                if (_mapOrientation[mapNum].Tile[x - 1, y] != TilePrefab.Mountain)
                    verticalPos = 0;
                if (_mapOrientation[mapNum].Tile[x + 1, y] != TilePrefab.Mountain)
                    verticalPos = 2;
                mountainPrefab = (S_AutoMap.MountainTile)(-1);
                if (_mapOrientation[mapNum].Tile[x, y - 1] == TilePrefab.Mountain)
                {
                    // Its not the top
                    if (y + 3 < modTypes.Map[mapNum].MaxY)
                    {
                        if (_mapOrientation[mapNum].Tile[x, y + 3] != TilePrefab.Mountain && _mapOrientation[mapNum].Tile[x, y + 2] == TilePrefab.Mountain)
                        {
                            // Inferior
                            switch (verticalPos)
                            {
                                case 0:
                                    {
                                        mountainPrefab = MountainTile.BottomLeftBorder;
                                        break;
                                    }

                                case 1:
                                    {
                                        mountainPrefab = MountainTile.BottomMidBorder;
                                        break;
                                    }

                                case 2:
                                    {
                                        mountainPrefab = MountainTile.BottomRightBorder;
                                        break;
                                    }
                            }
                        }
                        else if (_mapOrientation[mapNum].Tile[x, y + 2] != TilePrefab.Mountain && _mapOrientation[mapNum].Tile[x, y + 1] == TilePrefab.Mountain)
                        {
                            // Body
                            switch (verticalPos)
                            {
                                case 0:
                                    {
                                        mountainPrefab = MountainTile.LeftBody;
                                        break;
                                    }

                                case 1:
                                    {
                                        mountainPrefab = MountainTile.MiddleBody;
                                        break;
                                    }

                                case 2:
                                    {
                                        mountainPrefab = MountainTile.RightBody;
                                        break;
                                    }
                            }
                        }
                        else if (_mapOrientation[mapNum].Tile[x, y + 1] != TilePrefab.Mountain)
                        {
                            // Foots
                            switch (verticalPos)
                            {
                                case 0:
                                    {
                                        mountainPrefab = MountainTile.LeftFoot;
                                        break;
                                    }

                                case 1:
                                    {
                                        mountainPrefab = MountainTile.MiddleFoot;
                                        break;
                                    }

                                case 2:
                                    {
                                        mountainPrefab = MountainTile.RightFoot;
                                        break;
                                    }
                            }
                        }
                        else
                            // Mid
                            switch (verticalPos)
                            {
                                case 0:
                                    {
                                        mountainPrefab = MountainTile.MidLeftBorder;
                                        break;
                                    }

                                case 2:
                                    {
                                        mountainPrefab = MountainTile.MidRightBorder;
                                        break;
                                    }
                            }
                    }
                }
                else
                    // Its top
                    switch (verticalPos)
                    {
                        case 0:
                            {
                                mountainPrefab = MountainTile.UpLeftBorder;
                                break;
                            }

                        case 1:
                            {
                                mountainPrefab = MountainTile.UpMidBorder;
                                break;
                            }

                        case 2:
                            {
                                mountainPrefab = MountainTile.UpRightBorder;
                                break;
                            }
                    }
                GetMountainPrefab = mountainPrefab;
            }
            else
            {
                GetMountainPrefab = (S_AutoMap.MountainTile)(-1);
            }
            return GetMountainPrefab;
        }

        public static bool ValidMountainPosition(int mapNum, int x, int y, int width, int height)
        {
            int pX;
            int pY;
            bool ValidMountainPosition = true;
            var loopTo = x + Conversion.Int(width / (double)2);
            for (pX = x - Conversion.Int(width / (int)2); pX <= loopTo; pX++)
            {
                var loopTo1 = y + Conversion.Int(height / (double)2);
                for (pY = y - Conversion.Int(height / (int)2); pY <= loopTo1; pY++)
                {
                    if (pX < 1 || pX > modTypes.Map[mapNum].MaxX - 1)
                        ValidMountainPosition = false;
                    if (pY < 1 || pY >= modTypes.Map[mapNum].MaxY - 3)
                        ValidMountainPosition = false;
                    if (ValidMountainPosition)
                    {
                        if (_mapOrientation[mapNum].Tile[(int)pX, pY] != TilePrefab.Grass && _mapOrientation[mapNum].Tile[(int)pX, pY] != TilePrefab.Overgrass && _mapOrientation[mapNum].Tile[(int)pX, pY] != TilePrefab.Mountain)
                            ValidMountainPosition = false;
                    }
                }
            }
            return ValidMountainPosition;
        }

        public static void MakeMountains(int mapStart, int size)
        {
            int i;
            int totalMaps;
            int tick;
            int mapCount;
            Console.WriteLine("Working...");
            Application.DoEvents();
            tick = S_General.GetTimeMs();
            totalMaps = size * size;
            mapCount = 0;
            var loopTo = mapStart + totalMaps - 1;
            for (i = mapStart; i <= loopTo; i++)
            {
                if (_mapOrientation[i].Prefab == (int)MapPrefab.Common)
                {
                    MakeMapMountains(i);
                    mapCount = mapCount + 1;
                }
            }
            tick = S_General.GetTimeMs() - tick;
            Console.WriteLine("Done mountains in " + (mapCount) + " maps in " + System.Convert.ToString(tick / (double)1000) + "s");
            Application.DoEvents();
        }

        static void MakeMap(int mapNum, MapPrefab prefab)
        {
            int x = 0;
            int y = 0;
            int tileX = 0;
            int tileY = 0;
            int tileStartX = 0;
            int tileStartY = 0;
            int tileEndX = 0;
            int tileEndY = 0;
            int change = 0;
            bool changed = false;

            _mapOrientation[mapNum].Prefab = (int)prefab;

            {
                if (prefab != MapPrefab.Common)
                {
                    var loopTo = modTypes.Map[mapNum].MaxX;
                    for (x = 0; x <= loopTo; x++)
                    {
                        var loopTo1 = modTypes.Map[mapNum].MaxY;
                        for (y = 0; y <= loopTo1; y++)
                            AddTile(TilePrefab.Water, mapNum, x, y);
                    }
                }
                else
                {
                    var loopTo2 = modTypes.Map[mapNum].MaxX;
                    for (x = 0; x <= loopTo2; x++)
                    {
                        var loopTo3 = modTypes.Map[mapNum].MaxY;
                        for (y = 0; y <= loopTo3; y++)
                            AddTile(TilePrefab.Grass, mapNum, x, y);
                    }
                }
                if (prefab == MapPrefab.UpLeftQuarter)
                {
                    tileStartX = Conversion.Int(modTypes.Map[mapNum].MaxX / (int)2) - S_GameLogic.Random(0, Conversion.Int(modTypes.Map[mapNum].MaxX / (int)4));
                    tileStartY = modTypes.Map[mapNum].MaxY;
                    tileEndX = modTypes.Map[mapNum].MaxX;
                    tileEndY = Conversion.Int(modTypes.Map[mapNum].MaxY / (int)2) - S_GameLogic.Random(0, Conversion.Int(modTypes.Map[mapNum].MaxY / (int)4));
                    tileX = tileStartX;
                    var loopTo4 = tileEndY;
                    for (y = tileStartY; y >= loopTo4; y += -1)
                    {
                        if (y != tileStartY)
                            tileX = tileX + S_GameLogic.Random(0, 2);
                        if (tileX >= tileEndX)
                        {
                            tileEndY = y;
                            break;
                        }
                        else
                        {
                            var loopTo5 = tileEndX;
                            for (x = tileX; x <= loopTo5; x++)
                            {
                                if (x < tileX + SandBorder || y < tileEndY + SandBorder)
                                    AddTile(TilePrefab.Sand, mapNum, x, y);
                                else
                                    AddTile(TilePrefab.Grass, mapNum, x, y);
                            }
                        }
                    }
                }
                if (prefab == MapPrefab.UpBorder)
                {
                    tileStartX = 0;
                    tileStartY = _mapOrientation[modTypes.Map[mapNum].Left].TileEndY;
                    tileEndX = modTypes.Map[mapNum].MaxX;
                    tileY = tileStartY;
                    changed = true;
                    var loopTo6 = tileEndX;
                    for (x = tileStartX; x <= loopTo6; x++)
                    {
                        if (changed == false)
                        {
                            change = S_GameLogic.Random(-1, 1);
                            if (change != 0)
                            {
                                changed = true;
                                tileY = tileY + change;
                            }
                        }
                        else
                            changed = false;
                        if (tileY < Conversion.Int(modTypes.Map[mapNum].MaxY / (double)4))
                            tileY = Conversion.Int(modTypes.Map[mapNum].MaxY / (int)4);
                        if (tileY > Conversion.Int(modTypes.Map[mapNum].MaxY / (double)2) + Conversion.Int(modTypes.Map[mapNum].MaxY / (int)4))
                            tileY = Conversion.Int(modTypes.Map[mapNum].MaxY / (int)2) + Conversion.Int(modTypes.Map[mapNum].MaxY / (int)4);
                        var loopTo7 = modTypes.Map[mapNum].MaxY;
                        for (y = tileY; y <= loopTo7; y++)
                        {
                            if (y < tileY + SandBorder)
                                AddTile(TilePrefab.Sand, mapNum, x, y);
                            else
                                AddTile(TilePrefab.Grass, mapNum, x, y);
                        }
                    }

                    _mapOrientation[mapNum].TileEndY = tileY;
                }
                if (prefab == MapPrefab.UpRightQuarter)
                {
                    tileStartX = S_GameLogic.Random(4, 8);
                    tileStartY = _mapOrientation[modTypes.Map[mapNum].Left].TileEndY;
                    tileEndX = 0;
                    tileEndY = modTypes.Map[mapNum].MaxY;

                    tileX = tileStartX;
                    var loopTo8 = tileEndY;
                    for (y = tileStartY; y <= loopTo8; y++)
                    {
                        if (y != tileStartY)
                            tileX = tileX + S_GameLogic.Random(0, 2);
                        if (tileX > modTypes.Map[mapNum].MaxX)
                            tileX = modTypes.Map[mapNum].MaxX;
                        var loopTo9 = tileEndX;
                        for (x = tileX; x >= loopTo9; x += -1)
                        {
                            if (x > tileX - SandBorder || y < tileY + SandBorder)
                                AddTile(TilePrefab.Sand, mapNum, x, y);
                            else
                                AddTile(TilePrefab.Grass, mapNum, x, y);
                        }
                    }

                    tileEndX = tileX;
                }
                if (prefab == MapPrefab.LeftBorder)
                {
                    if (modTypes.Map[mapNum].Up == MapStart)
                        tileStartX = _mapOrientation[modTypes.Map[mapNum].Up].TileStartX;
                    else
                        tileStartX = _mapOrientation[modTypes.Map[mapNum].Up].TileEndX;
                    tileStartY = 0;
                    tileEndX = modTypes.Map[mapNum].MaxX;
                    tileEndY = modTypes.Map[mapNum].MaxY;
                    tileX = tileStartX;
                    changed = true;
                    var loopTo10 = tileEndY;
                    for (y = tileStartY; y <= loopTo10; y++)
                    {
                        if (changed == false)
                        {
                            change = S_GameLogic.Random(-1, 1);
                            if (change != 0)
                            {
                                changed = true;
                                tileX = tileX + change;
                            }
                        }
                        else
                            changed = false;
                        if (tileX < Conversion.Int(modTypes.Map[mapNum].MaxX / (double)4))
                            tileX = Conversion.Int(modTypes.Map[mapNum].MaxX / (int)4);
                        if (tileX > Conversion.Int(modTypes.Map[mapNum].MaxX / (double)2) + Conversion.Int(modTypes.Map[mapNum].MaxX / (double)4))
                            tileX = Conversion.Int(modTypes.Map[mapNum].MaxX / (int)2) + Conversion.Int(modTypes.Map[mapNum].MaxX / (int)4);
                        var loopTo11 = tileEndX;
                        for (x = tileX; x <= loopTo11; x++)
                        {
                            if (x < tileX + SandBorder)
                                AddTile(TilePrefab.Sand, mapNum, x, y);
                            else
                                AddTile(TilePrefab.Grass, mapNum, x, y);
                        }
                    }

                    _mapOrientation[mapNum].TileEndX = tileX;
                }
                if (prefab == MapPrefab.RightBorder)
                {
                    if (modTypes.Map[mapNum].Up == MapStart)
                        tileStartX = _mapOrientation[modTypes.Map[mapNum].Up].TileStartX;
                    else
                        tileStartX = _mapOrientation[modTypes.Map[mapNum].Up].TileEndX;
                    tileStartY = 0;
                    tileEndX = modTypes.Map[mapNum].MaxX;
                    tileEndY = modTypes.Map[mapNum].MaxY;
                    tileX = tileStartX;
                    changed = true;
                    var loopTo12 = tileEndY;
                    for (y = tileStartY; y <= loopTo12; y++)
                    {
                        if (changed == false)
                        {
                            change = S_GameLogic.Random(-1, 1);
                            if (change != 0)
                            {
                                changed = true;
                                tileX = tileX + change;
                            }
                        }
                        else
                            changed = false;
                        if (tileX < Conversion.Int(modTypes.Map[mapNum].MaxX / (double)4))
                            tileX = Conversion.Int(modTypes.Map[mapNum].MaxX / (int)4);
                        if (tileX > Conversion.Int(modTypes.Map[mapNum].MaxX / (double)2) + Conversion.Int(modTypes.Map[mapNum].MaxX / (double)4))
                            tileX = Conversion.Int(modTypes.Map[mapNum].MaxX / (int)2) + Conversion.Int(modTypes.Map[mapNum].MaxX / (int)4);
                        for (x = tileX; x >= 0; x += -1)
                        {
                            if (x > tileX - SandBorder)
                                AddTile(TilePrefab.Sand, mapNum, x, y);
                            else
                                AddTile(TilePrefab.Grass, mapNum, x, y);
                        }
                    }

                    _mapOrientation[mapNum].TileEndX = tileX;
                }
                if (prefab == MapPrefab.DownLeftQuarter)
                {
                    tileStartX = _mapOrientation[modTypes.Map[mapNum].Up].TileEndX;
                    tileEndX = modTypes.Map[mapNum].MaxX;
                    tileStartY = 0;
                    tileEndY = Conversion.Int(modTypes.Map[mapNum].MaxY / 2) + S_GameLogic.Random(0, Conversion.Int(modTypes.Map[mapNum].MaxY / 4));

                    tileX = tileStartX;
                    var loopTo13 = tileEndY;
                    for (y = tileStartY; y <= loopTo13; y++)
                    {
                        if (y != tileStartY)
                            tileX = tileX + S_GameLogic.Random(0, 2);
                        if (tileX >= tileEndX)
                        {
                            tileEndY = y;
                            break;
                        }
                        else
                        {
                            var loopTo14 = tileEndX;
                            for (x = tileX; x <= loopTo14; x++)
                            {
                                if (x < tileX + SandBorder || y > tileEndY - SandBorder)
                                    AddTile(TilePrefab.Sand, mapNum, x, y);
                                else
                                    AddTile(TilePrefab.Grass, mapNum, x, y);
                            }
                        }
                    }
                }
                if (prefab == MapPrefab.BottomBorder)
                {
                    tileStartX = 0;
                    tileEndX = modTypes.Map[mapNum].MaxX;
                    tileStartY = _mapOrientation[modTypes.Map[mapNum].Left].TileEndY;

                    tileY = tileStartY;
                    changed = true;
                    var loopTo15 = tileEndX;
                    for (x = tileStartX; x <= loopTo15; x++)
                    {
                        if (changed == false)
                        {
                            change = S_GameLogic.Random(-1, 1);
                            if (change != 0)
                            {
                                changed = true;
                                tileY = tileY + change;
                            }
                        }
                        else
                            changed = false;
                        if (tileY < Conversion.Int(modTypes.Map[mapNum].MaxY / (double)4))
                            tileY = Conversion.Int(modTypes.Map[mapNum].MaxY / (int)4);
                        if (tileY > Conversion.Int(modTypes.Map[mapNum].MaxY / (double)2) + Conversion.Int(modTypes.Map[mapNum].MaxY / (double)4))
                            tileY = Conversion.Int(modTypes.Map[mapNum].MaxY / (int)2) + Conversion.Int(modTypes.Map[mapNum].MaxY / (int)4);
                        for (y = tileY; y >= 0; y += -1)
                        {
                            if (y > tileY - SandBorder)
                                AddTile(TilePrefab.Sand, mapNum, x, y);
                            else
                                AddTile(TilePrefab.Grass, mapNum, x, y);
                        }
                    }

                    _mapOrientation[mapNum].TileEndY = tileY;
                }
                if (prefab == MapPrefab.DownRightQuarter)
                {
                    tileStartY = _mapOrientation[modTypes.Map[mapNum].Left].TileEndY;
                    tileEndY = 0;
                    tileStartX = 0;
                    tileEndX = _mapOrientation[modTypes.Map[mapNum].Up].TileEndX;
                    tileY = tileStartY;
                    var loopTo16 = tileEndX;
                    for (x = tileStartX; x <= loopTo16; x++)
                    {
                        if (x != tileStartX)
                            tileY = tileY - S_GameLogic.Random(0, 1);
                        var loopTo17 = tileEndY;
                        for (y = tileY; y >= loopTo17; y += -1)
                        {
                            if (y > tileY - SandBorder || x > tileEndX - SandBorder)
                                AddTile(TilePrefab.Sand, mapNum, x, y);
                            else
                                AddTile(TilePrefab.Grass, mapNum, x, y);
                        }
                    }
                }
            }

            if (_mapOrientation[mapNum].TileStartX == 0)
                _mapOrientation[mapNum].TileStartX = tileStartX;
            if (_mapOrientation[mapNum].TileStartY == 0)
                _mapOrientation[mapNum].TileStartY = tileStartY;
            if (_mapOrientation[mapNum].TileEndX == 0)
                _mapOrientation[mapNum].TileEndX = tileEndX;
            if (_mapOrientation[mapNum].TileEndY == 0)
                _mapOrientation[mapNum].TileEndY = tileEndY;
        }

        public static void MakePath(int mapNum, int x, int y, byte dir, int steps = 1)
        {
            bool pathEnd = false;
            int brushX = 0;
            int brushY = 0;
            byte i;
            if (!(_mapOrientation[mapNum].Prefab == (int)MapPrefab.Common))
                return;
            pathEnd = false;
            while (!pathEnd)
            {
                if (steps % modTypes.Map[mapNum].MaxX == 0)
                {
                    int oldDir;
                    oldDir = dir;
                ChangeDir:
                    ;
                    dir = (byte)S_GameLogic.Random(0, 3);
                    // Avoid invert direction
                    if ((oldDir == (int)Enums.DirectionType.Up && dir == (int)Enums.DirectionType.Down) || (oldDir == (int)Enums.DirectionType.Down && dir == (int)Enums.DirectionType.Up) || (oldDir == (int)Enums.DirectionType.Right && dir == (int)Enums.DirectionType.Left) || (oldDir == (int)Enums.DirectionType.Left && dir == (int)Enums.DirectionType.Right))
                        goto ChangeDir;
                }
                switch (dir)
                {
                    case (int)Enums.DirectionType.Up:
                        {
                            brushX = 1;
                            brushY = 0;
                            y = y - 1;
                            x = x + S_GameLogic.Random(0, 2) - 1;
                            if (x <= 1)
                                x = 1;
                            if (x >= modTypes.Map[mapNum].MaxX - 1)
                                x = modTypes.Map[mapNum].MaxX - 1;
                            break;
                        }

                    case (int)Enums.DirectionType.Down:
                        {
                            brushX = 1;
                            brushY = 0;
                            y = y + 1;
                            x = x + S_GameLogic.Random(0, 2) - 1;
                            if (x <= 1)
                                x = 1;
                            if (x >= modTypes.Map[mapNum].MaxX - 1)
                                x = modTypes.Map[mapNum].MaxX - 1;
                            break;
                        }

                    case (int)Enums.DirectionType.Left:
                        {
                            brushX = 0;
                            brushY = 1;
                            y = y + S_GameLogic.Random(0, 2) - 1;
                            x = x - 1;
                            if (y <= 1)
                                y = 1;
                            if (y >= modTypes.Map[mapNum].MaxY - 1)
                                y = modTypes.Map[mapNum].MaxY - 1;
                            break;
                        }

                    case (int)Enums.DirectionType.Right:
                        {
                            brushX = 0;
                            brushY = 1;
                            y = y + S_GameLogic.Random(0, 2) - 1;
                            x = x + 1;
                            if (y <= 1)
                                y = 1;
                            if (y >= modTypes.Map[mapNum].MaxY - 1)
                                y = modTypes.Map[mapNum].MaxY - 1;
                            break;
                        }
                }
                if (x <= 0)
                {
                    if (modTypes.Map[mapNum].Left > 0)
                    {
                        if (_mapOrientation[modTypes.Map[mapNum].Left].Prefab == (int)MapPrefab.Common)
                        {
                            PaintTile(TilePrefab.Passing, mapNum, x, y, brushX, brushY, onlyTo: TilePrefab.Grass);
                            PaintTile(TilePrefab.Passing, modTypes.Map[mapNum].Left, (int)Conversion.Val(modTypes.Map[mapNum].MaxX), y, brushX, brushY, onlyTo: TilePrefab.Grass);
                            MakePath(modTypes.Map[mapNum].Left, modTypes.Map[mapNum].MaxX, y, dir, steps);
                        }
                    }
                    return;
                }
                if (x >= modTypes.Map[mapNum].MaxX)
                {
                    if (modTypes.Map[mapNum].Right > 0)
                    {
                        if (_mapOrientation[modTypes.Map[mapNum].Right].Prefab == (int)MapPrefab.Common)
                        {
                            PaintTile(TilePrefab.Passing, mapNum, x, y, brushX, brushY, onlyTo: TilePrefab.Grass);
                            PaintTile(TilePrefab.Passing, modTypes.Map[mapNum].Right, 0, y, brushX, brushY, onlyTo: TilePrefab.Grass);
                            MakePath(modTypes.Map[mapNum].Right, 0, y, dir, steps);
                        }
                    }
                    return;
                }
                if (y <= 0)
                {
                    if (modTypes.Map[mapNum].Up > 0)
                    {
                        if (_mapOrientation[modTypes.Map[mapNum].Up].Prefab == (int)MapPrefab.Common)
                        {
                            PaintTile(TilePrefab.Passing, mapNum, x, y, brushX, brushY, onlyTo: TilePrefab.Grass);
                            PaintTile(TilePrefab.Passing, modTypes.Map[mapNum].Up, x, (int)Conversion.Val(modTypes.Map[mapNum].MaxY), brushX, brushY, onlyTo: TilePrefab.Grass);
                            MakePath(modTypes.Map[mapNum].Up, x, modTypes.Map[mapNum].MaxY, dir, steps);
                        }
                    }
                    return;
                }
                if (y >= modTypes.Map[mapNum].MaxY)
                {
                    if (modTypes.Map[mapNum].Down > 0)
                    {
                        if (_mapOrientation[modTypes.Map[mapNum].Down].Prefab == (int)MapPrefab.Common)
                        {
                            PaintTile(TilePrefab.Passing, mapNum, x, y, brushX, brushY, onlyTo: TilePrefab.Grass);
                            PaintTile(TilePrefab.Passing, modTypes.Map[mapNum].Down, x, 0, brushX, brushY, onlyTo: TilePrefab.Grass);
                            MakePath(modTypes.Map[mapNum].Down, x, 0, dir, steps);
                        }
                    }
                    return;
                }

                if (CheckPath(mapNum, x, y, dir))
                {
                    PaintTile(TilePrefab.Passing, mapNum, x, y, brushX, brushY, onlyTo: TilePrefab.Grass);
                    steps = steps + 1;
                }
                else
                    for (i = 0; i <= 3; i++)
                    {
                        if (i != dir)
                        {
                            if (CheckPath(mapNum, x, y, i))
                            {
                                dir = i;
                                break;
                            }
                        }
                    }
            }
        }

        static bool CheckPath(int mapNum, int X, int Y, byte Dir)
        {
            int sizeX = 0;
            int sizeY = 0;
            switch (Dir)
            {
                case (byte)Enums.DirectionType.Up:
                case (byte)Enums.DirectionType.Down:
                    {
                        sizeX = 1;
                        break;
                    }

                case (int)Enums.DirectionType.Left:
                case (int)Enums.DirectionType.Right:
                    {
                        sizeY = 1;
                        break;
                    }
            }

            int pX;
            int pY;
            var loopTo = X + sizeX;
            for (pX = X - sizeX; pX <= loopTo; pX++)
            {
                var loopTo1 = Y + sizeY;
                for (pY = Y - sizeY; pY <= loopTo1; pY++)
                {
                    if (pX >= 0 && pX <= modTypes.Map[mapNum].MaxX)
                    {
                        if (pY >= 0 && pY <= modTypes.Map[mapNum].MaxY)
                        {
                            if (_mapOrientation[mapNum].Tile[(int)pX, pY] != TilePrefab.Grass && _mapOrientation[mapNum].Tile[(int)pX, pY] != TilePrefab.Passing)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public static bool SearchForPreviousPaths(int mapNum, int X, int Y)
        {
            int pX;
            int pY;
            var loopTo = X + 10;
            for (pX = X - 10; pX <= loopTo; pX++)
            {
                var loopTo1 = Y + 10;
                for (pY = Y - 10; pY <= loopTo1; pY++)
                {
                    if (pX >= 0 && pX <= modTypes.Map[mapNum].MaxX)
                    {
                        if (pY >= 0 && pY <= modTypes.Map[mapNum].MaxY)
                        {
                            if (_mapOrientation[mapNum].Tile[(int)pX, pY] == TilePrefab.Passing)
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public static void MakeMapPaths(int mapNum)
        {
            int x = 0;
            int y = 0;
            int[] startX = new[] { 0 };
            int[] startY = new[] { 0 };
            int locationCount = 0;
            int totalPaths = 0;
            int maxTries = 0;
            int tries = 0;
            int tick = 0;

            Console.WriteLine("Working...");
            Application.DoEvents();
            tick = S_General.GetTimeMs();

            maxTries = 30;
            totalPaths = S_GameLogic.Random(modTypes.Map[mapNum].MaxX / (int)20, modTypes.Map[mapNum].MaxX / (int)10);

            while (locationCount < totalPaths && tries < maxTries)
            {
                x = S_GameLogic.Random(1, modTypes.Map[mapNum].MaxX - 1);
                y = S_GameLogic.Random(1, modTypes.Map[mapNum].MaxY - 1);
                if (_mapOrientation[mapNum].Tile[x, y] == TilePrefab.Grass && _mapOrientation[mapNum].Tile[x + 1, y] == TilePrefab.Grass && _mapOrientation[mapNum].Tile[x, y + 1] == TilePrefab.Grass && _mapOrientation[mapNum].Tile[x + 1, y + 1] == TilePrefab.Grass)
                {
                    if (!SearchForPreviousPaths(mapNum, x, y))
                    {
                        PaintTile(TilePrefab.Passing, mapNum, x, y, 1, 1, onlyTo: TilePrefab.Grass);
                        locationCount = locationCount + 1;
                        var oldStartX = startX;
                        startX = new int[locationCount + 1];
                        if (oldStartX != null)
                            Array.Copy(oldStartX, startX, Math.Min(locationCount + 1, oldStartX.Length));
                        var oldStartY = startY;
                        startY = new int[locationCount + 1];
                        if (oldStartY != null)
                            Array.Copy(oldStartY, startY, Math.Min(locationCount + 1, oldStartY.Length));
                        startX[locationCount] = x;
                        startY[locationCount] = y;
                    }
                }
                tries = tries + 1;
            }

            if (locationCount > 0)
            {
                int i = 0;
                int dir = 0;
                var loopTo = locationCount;
                for (i = 1; i <= loopTo; i++)
                {
                    if (startX[i] < modTypes.Map[mapNum].MaxX / (double)2)
                    {
                        if (startY[i] < modTypes.Map[mapNum].MaxY / (double)2)
                        {
                            if (S_GameLogic.Random(1, 2) == 1)
                                dir = (int)Enums.DirectionType.Left;
                            else
                                dir = (int)Enums.DirectionType.Up;
                        }
                        else if (S_GameLogic.Random(1, 2) == 1)
                            dir = (int)Enums.DirectionType.Left;
                        else
                            dir = (int)Enums.DirectionType.Down;
                    }
                    else if (startY[i] < modTypes.Map[mapNum].MaxY / (double)2)
                    {
                        if (S_GameLogic.Random(1, 2) == 1)
                            dir = (int)Enums.DirectionType.Right;
                        else
                            dir = (int)Enums.DirectionType.Up;
                    }
                    else if (S_GameLogic.Random(1, 2) == 1)
                        dir = (int)Enums.DirectionType.Right;
                    else
                        dir = (int)Enums.DirectionType.Down;
                    MakePath(mapNum, startX[i] + 1, startY[i], (byte)dir);
                }
            }

            tick = S_General.GetTimeMs() - tick;
            Console.WriteLine("Done " + totalPaths + " paths in " + System.Convert.ToString(tick / (double)1000) + "s");
            Application.DoEvents();
        }

        public static void MakePaths(int mapStart, int size)
        {
            int totalMaps = size * size;

            if (totalMaps % 2 == 1)
                MakeMapPaths((int)Conversion.Int(totalMaps / (double)2) + 1);
            else
            {
                MakeMapPaths((int)Conversion.Int(totalMaps / (int)2) - (size / (int)2));
                MakeMapPaths((int)Conversion.Int(totalMaps / (int)2) - (size / (int)2) + 1);
                MakeMapPaths((int)Conversion.Int(totalMaps / (int)2) - (size / (int)2) + size);
                MakeMapPaths((int)Conversion.Int(totalMaps / (int)2) - (size / (int)2) + size + 1);
            }
        }

        public static void StartAutomapper(int mapStart, int size, int mapX, int mapY)
        {
            int startTick;
            int tick;
            startTick = S_General.GetTimeMs();
            LoadTilePrefab();
            LoadDetails();

            int mapNum;
            int totalMaps = (size * size);

            _mapOrientation = new MapOrientationRec[mapStart + totalMaps + 1];

            tick = S_General.GetTimeMs();
            var loopTo = mapStart + totalMaps - 1;
            for (mapNum = mapStart; mapNum <= loopTo; mapNum++)
            {
                modDatabase.ClearMap(mapNum);

                modTypes.Map[mapNum].MaxX = (byte)mapX;
                modTypes.Map[mapNum].MaxY = (byte)mapY;
                modTypes.Map[mapNum].Tile = new TileRec[modTypes.Map[mapNum].MaxX + 1, modTypes.Map[mapNum].MaxY + 1];
                _mapOrientation[mapNum].Tile = new TilePrefab[modTypes.Map[mapNum].MaxX + 1, modTypes.Map[mapNum].MaxY + 1];
                modDatabase.ClearTempTile(mapNum);

                // // Down teleport \\
                if (mapNum <= mapStart - 1 + totalMaps - size)
                    modTypes.Map[mapNum].Down = mapNum + size;
                // \\ Down teleport //

                // // Left teleport \\
                if (mapNum - mapStart + 1 % size != 1)
                    modTypes.Map[mapNum].Left = mapNum - 1;
                // \\ Left teleport //

                // // Up teleport \\
                if (mapNum - mapStart + 1 > size)
                    modTypes.Map[mapNum].Up = mapNum - size;
                // \\ Up teleport //

                // // Right teleport \\
                if (mapNum - mapStart + 1 % size != 0)
                    modTypes.Map[mapNum].Right = mapNum + 1;
                // \\ Right teleport //

                MapPrefab Prefab;
                Prefab = MapPrefab.Undefined;
                if (mapNum == mapStart)
                    Prefab = MapPrefab.UpLeftQuarter;
                if (mapNum > mapStart && mapNum < mapStart - 1 + size)
                    Prefab = MapPrefab.UpBorder;
                if (mapNum == mapStart - 1 + size)
                    Prefab = MapPrefab.UpRightQuarter;
                if (mapNum > mapStart - 1 + size && mapNum <= mapStart - 1 + totalMaps - size)
                {
                    if ((mapNum - mapStart + 1) % size == 1)
                        Prefab = MapPrefab.LeftBorder;
                    else if ((mapNum - mapStart + 1) % size == 0)
                        Prefab = MapPrefab.RightBorder;
                    else
                        Prefab = MapPrefab.Common;
                }
                if (mapNum > mapStart - 1 + totalMaps - size)
                {
                    if ((mapNum - mapStart + 1) % size == 1)
                        Prefab = MapPrefab.DownLeftQuarter;
                    else if ((mapNum - mapStart + 1) % size == 0)
                        Prefab = MapPrefab.DownRightQuarter;
                    else
                        Prefab = MapPrefab.BottomBorder;
                }

                MakeMap(mapNum, Prefab);
            }

            tick = S_General.GetTimeMs() - tick;
            Console.WriteLine("Done " + totalMaps + " maps models in " + System.Convert.ToString(tick / (double)1000) + "s");
            Application.DoEvents();

            if (PathsChecked == true)
                MakePaths(mapStart, size);
            if (RiversChecked == true)
                MakeRivers(mapStart, size);
            if (MountainsChecked == true)
                MakeMountains(mapStart, size);
            if (OverGrassChecked == true)
                MakeOvergrasses(mapStart, size);
            if (ResourcesChecked == true)
                MakeResources(mapStart, size);

            tick = S_General.GetTimeMs();
            Console.WriteLine("Working...");
            Application.DoEvents();
            var loopTo1 = mapStart + totalMaps - 1;
            for (mapNum = mapStart; mapNum <= loopTo1; mapNum++)
                modDatabase.SaveMap(mapNum);

            tick = S_General.GetTimeMs() - tick;
            startTick = S_General.GetTimeMs() - startTick;

            Console.WriteLine("Cached all maps in " + System.Convert.ToString(tick / (double)1000) + "s (" + ((tick / (double)startTick) * 100) + "%)");
            Console.WriteLine("Done " + totalMaps + " maps in " + System.Convert.ToString(startTick / (double)1000) + "s");
        }
    }
}
