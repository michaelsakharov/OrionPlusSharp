using System.Windows.Forms;
using System.IO;
using ASFW;
using SFML.Graphics;
using SFML.Window;

namespace Engine
{
    internal static class E_Housing
    {
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



        public static void Packet_HouseConfigurations(ref byte[] data)
        {
            int i;
            ByteStream buffer = new ByteStream(data);
            var loopTo = MAX_HOUSES;
            for (i = 1; i <= loopTo; i++)
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
            int i;
            ByteStream buffer = new ByteStream(data);
            FurnitureHouse = buffer.ReadInt32();
            FurnitureCount = buffer.ReadInt32();

            Furniture = new FurnitureRec[FurnitureCount + 1];
            if (FurnitureCount > 0)
            {
                var loopTo = FurnitureCount;
                for (i = 1; i <= loopTo; i++)
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
            int i;
            ByteStream buffer = new ByteStream(data);
            var loopTo = MAX_HOUSES;
            for (i = 1; i <= loopTo; i++)
            {
                {
                    var withBlock = House[i];
                    withBlock.ConfigName = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
                    withBlock.BaseMap = buffer.ReadInt32();
                    withBlock.X = buffer.ReadInt32();
                    withBlock.Y = buffer.ReadInt32();
                    withBlock.Price = buffer.ReadInt32();
                    withBlock.MaxFurniture = buffer.ReadInt32();
                }
            }

            HouseEdit = true;

            buffer.Dispose();
        }



        internal static void SendRequestEditHouse()
        {
            ByteStream buffer;

            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.RequestEditHouse);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        internal static void SendBuyHouse(byte Accepted)
        {
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CBuyHouse);
            buffer.WriteInt32(Accepted);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        internal static void SendInvite(string Name)
        {
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CVisit);
            buffer.WriteString((Name));
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        internal static void SendVisit(byte Accepted)
        {
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CAcceptVisit);
            buffer.WriteInt32(Accepted);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);

            buffer.Dispose();
        }



        internal static void HouseEditorInit()
        {
            if (My.MyProject.Forms.FrmHouse.Visible == false)
                return;

            E_Globals.Editorindex = My.MyProject.Forms.FrmHouse.lstIndex.SelectedIndex + 1;

            {
                var withBlock = House[E_Globals.Editorindex];
                My.MyProject.Forms.FrmHouse.txtName.Text = Microsoft.VisualBasic.Strings.Trim(withBlock.ConfigName);
                if (withBlock.BaseMap == 0)
                    withBlock.BaseMap = 1;
                My.MyProject.Forms.FrmHouse.nudBaseMap.Value = withBlock.BaseMap;
                if (withBlock.X == 0)
                    withBlock.X = 1;
                My.MyProject.Forms.FrmHouse.nudX.Value = withBlock.X;
                if (withBlock.Y == 0)
                    withBlock.Y = 1;
                My.MyProject.Forms.FrmHouse.nudY.Value = withBlock.Y;
                My.MyProject.Forms.FrmHouse.nudPrice.Value = withBlock.Price;
                My.MyProject.Forms.FrmHouse.nudFurniture.Value = withBlock.MaxFurniture;
            }

            House_Changed[E_Globals.Editorindex] = true;
        }

        internal static void HouseEditorCancel()
        {
            E_Globals.Editor = 0;
            My.MyProject.Forms.FrmHouse.Dispose();

            ClearChanged_House();
        }

        internal static void HouseEditorOk()
        {
            int i;
            ByteStream Buffer;
            int count = 0;
            Buffer = new ByteStream(4);

            Buffer.WriteInt32((int)Packets.EditorPackets.SaveHouses);
            var loopTo = MAX_HOUSES;
            for (i = 1; i <= loopTo; i++)
            {
                if (House_Changed[i])
                    count = count + 1;
            }

            Buffer.WriteInt32(count);

            if (count > 0)
            {
                var loopTo1 = MAX_HOUSES;
                for (i = 1; i <= loopTo1; i++)
                {
                    if (House_Changed[i])
                    {
                        Buffer.WriteInt32(i);
                        Buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(House[i].ConfigName)));
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
            My.MyProject.Forms.FrmHouse.Dispose();
            E_Globals.Editor = 0;

            ClearChanged_House();
        }

        internal static void ClearChanged_House()
        {
            var loopTo = MAX_HOUSES;
            for (var i = 1; i <= loopTo; i++)
                House_Changed[i] = default(bool);

            House_Changed = new bool[MAX_HOUSES + 1];
        }



        internal static void CheckFurniture()
        {
            int i;
            i = 1;

            while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Furniture\" + i + E_Globals.GFX_EXT))
            {
                NumFurniture = NumFurniture + 1;
                i = i + 1;
            }

            if (NumFurniture == 0)
                return;
        }

        internal static void DrawFurniture(int index, int Layer)
        {
            int i;
            int ItemNum;
            int X;
            int Y;
            int Width;
            int Height;
            int X1;
            int Y1;

            ItemNum = Furniture[index].ItemNum;

            if (Types.Item[ItemNum].Type != (byte)Enums.ItemType.Furniture)
                return;

            i = Types.Item[ItemNum].Data2;

            if (E_Graphics.FurnitureGFXInfo[i].IsLoaded == false)
                E_Graphics.LoadTexture(i, 10);

            // seeying we still use it, lets update timer
            {
                var withBlock = E_Graphics.SkillIconsGFXInfo[i];
                withBlock.TextureTimer = ClientDataBase.GetTickCount() + 100000;
            }

            Width = Types.Item[ItemNum].FurnitureWidth;
            Height = Types.Item[ItemNum].FurnitureHeight;

            if (Width > 4)
                Width = 4;
            if (Height > 4)
                Height = 4;
            if (i <= 0 || i > NumFurniture)
                return;

            // make sure it's not out of map
            if (Furniture[index].X > E_Types.Map.MaxX)
                return;
            if (Furniture[index].Y > E_Types.Map.MaxY)
                return;
            var loopTo = Width - 1;
            for (X1 = 0; X1 <= loopTo; X1++)
            {
                var loopTo1 = Height;
                for (Y1 = 0; Y1 <= loopTo1; Y1++)
                {
                    if (Types.Item[Furniture[index].ItemNum].FurnitureFringe[X1, Y1] == Layer)
                    {
                        // Set base x + y, then the offset due to size
                        X = (Furniture[index].X * 32) + (X1 * 32);
                        Y = (Furniture[index].Y * 32 - (Height * 32)) + (Y1 * 32);
                        X = E_Graphics.ConvertMapX(X);
                        Y = E_Graphics.ConvertMapY(Y);

                        Sprite tmpSprite = new Sprite(E_Graphics.FurnitureGFX[i])
                        {
                            TextureRect = new IntRect(0 + (X1 * 32), 0 + (Y1 * 32), 32, 32),
                            Position = new Vector2f(X, Y)
                        };
                        E_Graphics.GameWindow.Draw(tmpSprite);
                    }
                }
            }
        }
    }
}
