using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using static Engine.Types;

namespace Engine
{
    static class E_AutoMap
    {
        // Automapper System
        // Version: 1.0
        // Author: Lucas Tardivo (boasfesta)
        // Map analysis and tips: Richard Johnson, Luan Meireles (Alenzinho)


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

        // Distance between mountains and the map limit, so the player can walk freely when teleport between maps
        private const byte MountainBorder = 5;

        internal static Types.TileRec[] Tile = new Types.TileRec[8];
        internal static DetailRec[] Detail;
        internal static string ResourcesNum;
        private static string[] Resources;
        // Private ActualMap As Integer

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



        public static void OpenAutomapper()
        {
            LoadTilePrefab();
            My.MyProject.Forms.FrmAutoMapper.Visible = true;
        }

        public static void LoadTilePrefab()
        {
            int Prefab;
            int Layer;

            XmlClass myXml = new XmlClass()
            {
                Filename = System.IO.Path.Combine(Application.StartupPath, "Data", "AutoMapper.xml"),
                Root = "Options"
            };

            myXml.LoadXml();

            Tile = new TileRec[8];
            for (Prefab = 1; Prefab <= (byte)TilePrefab.Count - 1; Prefab++)
            {
                Tile[Prefab].Layer = new TileDataRec[6];
                for (Layer = 1; Layer <= (byte)Enums.LayerType.Count - 1; Layer++)
                {
                    Tile[Prefab].Layer[Layer].Tileset = (byte)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "Tileset"));
                    Tile[Prefab].Layer[Layer].X = (byte)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "X"));
                    Tile[Prefab].Layer[Layer].Y = (byte)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "Y"));
                    Tile[Prefab].Layer[Layer].AutoTile = (byte)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "Autotile"));
                }
                Tile[Prefab].Type = (byte)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Type"));
            }

            ResourcesNum = myXml.ReadString("Resources", "ResourcesNum");
            Resources = Microsoft.VisualBasic.Strings.Split(ResourcesNum, ";");

            myXml.CloseXml(false);
        }

        public static void LoadDetail(TilePrefab Prefab, int Tileset, int X, int Y, int TileType = 0, int EndX = 0, int EndY = 0)
        {
            if (EndX == 0)
                EndX = X;
            if (EndY == 0)
                EndY = Y;
            int pX;
            int pY;
            var loopTo = EndX;
            for (pX = X; pX <= loopTo; pX++)
            {
                var loopTo1 = EndY;
                for (pY = Y; pY <= loopTo1; pY++)
                    AddDetail(Prefab, Tileset, pX, pY, TileType);
            }
        }

        public static void AddDetail(TilePrefab Prefab, int Tileset, int X, int Y, int TileType)
        {
            int DetailCount;
            DetailCount = Information.UBound(Detail) + 1;
            var oldDetail = Detail;
            Detail = new DetailRec[DetailCount + 1];
            if (oldDetail != null)
                Array.Copy(oldDetail, Detail, Math.Min(DetailCount + 1, oldDetail.Length));
            var oldLayer = Detail[DetailCount].Tile.Layer;
            Detail[DetailCount].Tile.Layer = new TileDataRec[6];
            if (oldLayer != null)
                Array.Copy(oldLayer, Detail[DetailCount].Tile.Layer, Math.Min(6, oldLayer.Length));

            Detail[DetailCount].DetailBase = (byte)Prefab;
            Detail[DetailCount].Tile.Type = (byte)TileType;
            Detail[DetailCount].Tile.Layer[3].Tileset = (byte)Tileset;
            Detail[DetailCount].Tile.Layer[3].X = (byte)X;
            Detail[DetailCount].Tile.Layer[3].Y = (byte)Y;
        }

        public static void LoadDetails()
        {
            Detail = new DetailRec[2];

            // Detail config area
            // Use: LoadDetail TilePrefab, Tileset, StartTilesetX, StartTilesetY, TileType, EndTilesetX, EndTilesetY
            LoadDetail(TilePrefab.Grass, 9, 0, 0, (byte)Enums.TileType.None, 7, 7);
            LoadDetail(TilePrefab.Grass, 9, 0, 10, (byte)Enums.TileType.None, 6, 15);
            LoadDetail(TilePrefab.Grass, 9, 0, 13, (byte)Enums.TileType.None, 7, 14);
            LoadDetail(TilePrefab.Sand, 10, 0, 13, (byte)Enums.TileType.None, 7, 14);
            LoadDetail(TilePrefab.Sand, 11, 0, 0, (byte)Enums.TileType.None, 1, 1);
        }



        public static void Packet_AutoMapper(ref byte[] data)
        {
            int Layer;
            ASFW.ByteStream buffer = new ASFW.ByteStream(data);
            MapStart = buffer.ReadInt32();
            MapSize = buffer.ReadInt32();
            MapX = buffer.ReadInt32();
            MapY = buffer.ReadInt32();
            SandBorder = buffer.ReadInt32();
            DetailFreq = buffer.ReadInt32();
            ResourceFreq = buffer.ReadInt32();

            XmlClass myXml = new XmlClass()
            {
                Filename = System.IO.Path.Combine(Application.StartupPath, "Data", "AutoMapper.xml"),
                Root = "Options"
            };

            myXml.LoadXml();

            myXml.WriteString("Resources", "ResourcesNum", buffer.ReadString());

            for (var Prefab = 1; Prefab <= (byte)TilePrefab.Count - 1; Prefab++)
            {
                Tile[Prefab].Layer = new TileDataRec[6];

                Layer = buffer.ReadInt32();
                myXml.WriteString("Prefab" + Prefab, "Layer" + Layer + "Tileset", buffer.ReadInt32().ToString());
                myXml.WriteString("Prefab" + Prefab, "Layer" + Layer + "X", buffer.ReadInt32().ToString());
                myXml.WriteString("Prefab" + Prefab, "Layer" + Layer + "Y", buffer.ReadInt32().ToString());
                myXml.WriteString("Prefab" + Prefab, "Layer" + Layer + "Autotile", buffer.ReadInt32().ToString());

                myXml.WriteString("Prefab" + Prefab, "Type", buffer.ReadInt32().ToString());
            }

            myXml.CloseXml(true);

            buffer.Dispose();

            E_Globals.InitAutoMapper = true;
        }



        internal static void SendRequestAutoMapper()
        {
            ASFW.ByteStream buffer = new ASFW.ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.RequestAutoMap);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendSaveAutoMapper()
        {
            XmlClass myXml = new XmlClass()
            {
                Filename = Application.StartupPath + @"\Data\AutoMapper.xml",
                Root = "Options"
            };
            ASFW.ByteStream buffer = new ASFW.ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.SaveAutoMap);

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

            for (var Prefab = 1; Prefab <= (byte)TilePrefab.Count - 1; Prefab++)
            {
                for (var Layer = 1; Layer <= (byte)Enums.LayerType.Count - 1; Layer++)
                {
                    if (Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "Tileset")) > 0)
                    {
                        buffer.WriteInt32(Layer);
                        buffer.WriteInt32((byte)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "Tileset")));
                        buffer.WriteInt32((byte)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "X")));
                        buffer.WriteInt32((byte)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "Y")));
                        buffer.WriteInt32((byte)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Layer" + Layer + "Autotile")));
                    }
                }
                buffer.WriteInt32((byte)Conversion.Val(myXml.ReadString("Prefab" + Prefab, "Type")));
            }

            myXml.CloseXml(false);

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }
    }
}
