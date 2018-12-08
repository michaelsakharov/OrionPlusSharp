using System.Drawing;
using System.Windows.Forms;
using System.IO;
using ASFW;

namespace Engine
{
    internal static class E_Projectiles
    {
        internal const int MAX_PROJECTILES = 255;
        internal static ProjectileRec[] Projectiles = new ProjectileRec[256];
        internal static MapProjectileRec[] MapProjectiles = new MapProjectileRec[256];
        internal static int NumProjectiles;
        internal static bool InitProjectileEditor;
        internal const byte EDITOR_PROJECTILE = 10;
        internal static bool[] Projectile_Changed = new bool[256];



        internal struct ProjectileRec
        {
            public string Name;
            public int Sprite;
            public byte Range;
            public int Speed;
            public int Damage;
        }

        internal struct MapProjectileRec
        {
            public int ProjectileNum;
            public int Owner;
            public byte OwnerType;
            public int X;
            public int Y;
            public byte dir;
            public int Range;
            public int TravelTime;
            public int Timer;
        }



        public static void SendRequestEditProjectiles()
        {
            ByteStream buffer;

            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.EditorPackets.RequestEditProjectiles);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendSaveProjectile(int ProjectileNum)
        {
            ByteStream buffer;

            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.SaveProjectile);
            buffer.WriteInt32(ProjectileNum);

            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Projectiles[ProjectileNum].Name)));
            buffer.WriteInt32(Projectiles[ProjectileNum].Sprite);
            buffer.WriteInt32(Projectiles[ProjectileNum].Range);
            buffer.WriteInt32(Projectiles[ProjectileNum].Speed);
            buffer.WriteInt32(Projectiles[ProjectileNum].Damage);

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendRequestProjectiles()
        {
            ByteStream buffer;

            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ClientPackets.CRequestProjectiles);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendClearProjectile(int ProjectileNum, int Collisionindex, byte CollisionType, int CollisionZone)
        {
            ByteStream buffer;

            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ClientPackets.CClearProjectile);
            buffer.WriteInt32(ProjectileNum);
            buffer.WriteInt32(Collisionindex);
            buffer.WriteInt32(CollisionType);
            buffer.WriteInt32(CollisionZone);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }



        internal static void HandleProjectileEditor(ref byte[] data)
        {
            InitProjectileEditor = true;
        }

        internal static void HandleUpdateProjectile(ref byte[] data)
        {
            int ProjectileNum;
            ByteStream buffer = new ByteStream(data);
            ProjectileNum = buffer.ReadInt32();

            Projectiles[ProjectileNum].Name = buffer.ReadString();
            Projectiles[ProjectileNum].Sprite = buffer.ReadInt32();
            Projectiles[ProjectileNum].Range = (byte)buffer.ReadInt32();
            Projectiles[ProjectileNum].Speed = buffer.ReadInt32();
            Projectiles[ProjectileNum].Damage = buffer.ReadInt32();

            buffer.Dispose();
        }

        internal static void HandleMapProjectile(ref byte[] data)
        {
            int i;
            ByteStream buffer = new ByteStream(data);
            i = buffer.ReadInt32();

            {
                var withBlock = MapProjectiles[i];
                withBlock.ProjectileNum = buffer.ReadInt32();
                withBlock.Owner = buffer.ReadInt32();
                withBlock.OwnerType = (byte)buffer.ReadInt32();
                withBlock.dir = (byte)buffer.ReadInt32();
                withBlock.X = buffer.ReadInt32();
                withBlock.Y = buffer.ReadInt32();
                withBlock.Range = 0;
                withBlock.Timer = ClientDataBase.GetTickCount() + 60000;
            }

            buffer.Dispose();
        }



        public static void ClearProjectiles()
        {
            int i;

            for (i = 1; i <= MAX_PROJECTILES; i++)
                ClearProjectile(i);
        }

        public static void ClearProjectile(int index)
        {
            Projectiles[index].Name = "";
            Projectiles[index].Sprite = 0;
            Projectiles[index].Range = 0;
            Projectiles[index].Speed = 0;
            Projectiles[index].Damage = 0;
        }

        public static void ClearMapProjectile(int ProjectileNum)
        {
            MapProjectiles[ProjectileNum].ProjectileNum = 0;
            MapProjectiles[ProjectileNum].Owner = 0;
            MapProjectiles[ProjectileNum].OwnerType = 0;
            MapProjectiles[ProjectileNum].X = 0;
            MapProjectiles[ProjectileNum].Y = 0;
            MapProjectiles[ProjectileNum].dir = 0;
            MapProjectiles[ProjectileNum].Timer = 0;
        }



        internal static void CheckProjectiles()
        {
            int i;

            i = 1;

            while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"projectiles\" + i + E_Globals.GFX_EXT))
            {
                NumProjectiles = NumProjectiles + 1;
                i = i + 1;
            }

            if (NumProjectiles == 0)
                return;
        }

        internal static void EditorProjectile_DrawProjectile()
        {
            int iconnum;

            iconnum = (int)My.MyProject.Forms.frmProjectile.nudPic.Value;

            if (iconnum < 1 || iconnum > NumProjectiles)
            {
                My.MyProject.Forms.frmProjectile.picProjectile.BackgroundImage = null;
                return;
            }

            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Projectiles\" + iconnum + E_Globals.GFX_EXT))
                My.MyProject.Forms.frmProjectile.picProjectile.BackgroundImage = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"Projectiles\" + iconnum + E_Globals.GFX_EXT);
        }



        internal static void ProjectileEditorInit()
        {
            if (My.MyProject.Forms.frmProjectile.Visible == false)
                return;
            E_Globals.Editorindex = My.MyProject.Forms.frmProjectile.lstIndex.SelectedIndex + 1;

            {
                var withBlock = Projectiles[E_Globals.Editorindex];
                My.MyProject.Forms.frmProjectile.txtName.Text = Microsoft.VisualBasic.Strings.Trim(withBlock.Name);
                My.MyProject.Forms.frmProjectile.nudPic.Value = withBlock.Sprite;
                My.MyProject.Forms.frmProjectile.nudRange.Value = withBlock.Range;
                My.MyProject.Forms.frmProjectile.nudSpeed.Value = withBlock.Speed;
                My.MyProject.Forms.frmProjectile.nudDamage.Value = withBlock.Damage;
            }

            Projectile_Changed[E_Globals.Editorindex] = true;
        }

        internal static void ProjectileEditorOk()
        {
            int i;

            for (i = 1; i <= MAX_PROJECTILES; i++)
            {
                if (Projectile_Changed[i])
                    SendSaveProjectile(i);
            }

            My.MyProject.Forms.frmProjectile.Dispose();
            E_Globals.Editor = 0;
            ClearChanged_Projectile();
        }

        internal static void ProjectileEditorCancel()
        {
            E_Globals.Editor = 0;
            My.MyProject.Forms.frmProjectile.Dispose();
            ClearChanged_Projectile();
            ClearProjectiles();
            SendRequestProjectiles();
        }

        internal static void ClearChanged_Projectile()
        {
            int i;

            for (i = 0; i <= MAX_PROJECTILES; i++)
                Projectile_Changed[i] = false;
        }
    }
}
