
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
using Engine;


namespace Engine
{
	internal sealed class E_Projectiles
	{
		
#region Defines
		
		internal const int MAX_PROJECTILES = 255;
		internal static ProjectileRec[] Projectiles = new ProjectileRec[MAX_PROJECTILES + 1];
		internal static MapProjectileRec[] MapProjectiles = new MapProjectileRec[MAX_PROJECTILES + 1];
		internal static int NumProjectiles;
		internal static bool InitProjectileEditor;
		internal const byte EDITOR_PROJECTILE = 10;
		internal static bool[] Projectile_Changed = new bool[MAX_PROJECTILES + 1];
		
#endregion
		
#region Types
		
		public struct ProjectileRec
		{
			public string Name;
			public int Sprite;
			public byte Range;
			public int Speed;
			public int Damage;
		}
		
		public struct MapProjectileRec
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
		
#endregion
		
#region Sending
		
		public static void SendRequestEditProjectiles()
		{
			ByteStream buffer = new ByteStream();
			
			buffer = new ByteStream(4);
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.RequestEditProjectiles);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		public static void SendSaveProjectile(int ProjectileNum)
		{
			ByteStream buffer = new ByteStream();
			
			buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.SaveProjectile);
			buffer.WriteInt32(ProjectileNum);
			
			buffer.WriteString(Projectiles[ProjectileNum].Name.Trim());
			buffer.WriteInt32(Projectiles[ProjectileNum].Sprite);
			buffer.WriteInt32(Projectiles[ProjectileNum].Range);
			buffer.WriteInt32(Projectiles[ProjectileNum].Speed);
			buffer.WriteInt32(Projectiles[ProjectileNum].Damage);
			
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		public static void SendRequestProjectiles()
		{
			ByteStream buffer = new ByteStream();
			
			buffer = new ByteStream(4);
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestProjectiles);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		public static void SendClearProjectile(int ProjectileNum, int Collisionindex, byte CollisionType, int CollisionZone)
		{
			ByteStream buffer = new ByteStream();
			
			buffer = new ByteStream(4);
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CClearProjectile);
			buffer.WriteInt32(ProjectileNum);
			buffer.WriteInt32(Collisionindex);
			buffer.WriteInt32(CollisionType);
			buffer.WriteInt32(CollisionZone);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
#endregion
		
#region Recieving
		
		internal static void HandleProjectileEditor(ref byte[] data)
		{
			
			InitProjectileEditor = true;
			
		}
		
		internal static void HandleUpdateProjectile(ref byte[] data)
		{
			int ProjectileNum = 0;
			ByteStream buffer = new ByteStream(data);
			ProjectileNum = buffer.ReadInt32();
			
			Projectiles[ProjectileNum].Name = buffer.ReadString();
			Projectiles[ProjectileNum].Sprite = buffer.ReadInt32();
			Projectiles[ProjectileNum].Range = (byte) (buffer.ReadInt32());
			Projectiles[ProjectileNum].Speed = buffer.ReadInt32();
			Projectiles[ProjectileNum].Damage = buffer.ReadInt32();
			
			buffer.Dispose();
			
		}
		
		internal static void HandleMapProjectile(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			
			MapProjectiles[i].ProjectileNum = buffer.ReadInt32();
			MapProjectiles[i].Owner = buffer.ReadInt32();
			MapProjectiles[i].OwnerType = (byte) (buffer.ReadInt32());
			MapProjectiles[i].dir = (byte) (buffer.ReadInt32());
			MapProjectiles[i].X = buffer.ReadInt32();
			MapProjectiles[i].Y = buffer.ReadInt32();
			MapProjectiles[i].Range = 0;
			MapProjectiles[i].Timer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 60000);
			
			buffer.Dispose();
			
		}
		
#endregion
		
#region Database
		
		public static void ClearProjectiles()
		{
			int i = 0;
			
			for (i = 1; i <= MAX_PROJECTILES; i++)
			{
				ClearProjectile(i);
			}
			
		}
		
		public static void ClearProjectile(int index)
		{
			
			Projectiles[index].Name = "";
			Projectiles[index].Sprite = 0;
			Projectiles[index].Range = 0;
			Projectiles[index].Speed = 1;
			Projectiles[index].Damage = 0;
			
		}
		
		public static void ClearMapProjectile(int ProjectileNum)
		{
			
			MapProjectiles[ProjectileNum].ProjectileNum = 0;
			MapProjectiles[ProjectileNum].Owner = 0;
			MapProjectiles[ProjectileNum].OwnerType = (byte) 0;
			MapProjectiles[ProjectileNum].X = 0;
			MapProjectiles[ProjectileNum].Y = 0;
			MapProjectiles[ProjectileNum].dir = (byte) 0;
			MapProjectiles[ProjectileNum].Timer = 0;
			
		}
		
#endregion
		
#region Drawing
		
		internal static void CheckProjectiles()
		{
			int i = 0;
			
			i = 1;
			
			while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "projectiles\\" + System.Convert.ToString(i) + E_Globals.GFX_EXT))
			{
				
				NumProjectiles++;
				i++;
			}
			
			if (NumProjectiles == 0)
			{
				return;
			}
			
		}
		
		internal static void EditorProjectile_DrawProjectile()
		{
			int iconnum = 0;
			
			iconnum = (int) frmProjectile.Default.nudPic.Value;
			
			if (iconnum < 1 || iconnum > NumProjectiles)
			{
				frmProjectile.Default.picProjectile.BackgroundImage = null;
				return;
			}
			
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Projectiles\\" + System.Convert.ToString(iconnum) + E_Globals.GFX_EXT))
			{
				frmProjectile.Default.picProjectile.BackgroundImage = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "Projectiles\\" + System.Convert.ToString(iconnum) + E_Globals.GFX_EXT);
			}
			
		}
		
#endregion
		
#region Projectile Editor
		
		internal static void ProjectileEditorInit()
		{
			
			if (frmProjectile.Default.Visible == false)
			{
				return;
			}
			E_Globals.Editorindex = frmProjectile.Default.lstIndex.SelectedIndex + 1;
			
            if(Projectiles[E_Globals.Editorindex].Name == null)
            {
                Projectiles[E_Globals.Editorindex].Name = "";
            }
			frmProjectile.Default.txtName.Text = Projectiles[E_Globals.Editorindex].Name.Trim();
			frmProjectile.Default.nudPic.Value = Projectiles[E_Globals.Editorindex].Sprite;
			frmProjectile.Default.nudRange.Value = Projectiles[E_Globals.Editorindex].Range;
			frmProjectile.Default.nudSpeed.Value = Projectiles[E_Globals.Editorindex].Speed;
			frmProjectile.Default.nudDamage.Value = Projectiles[E_Globals.Editorindex].Damage;
			
			Projectile_Changed[E_Globals.Editorindex] = true;
			
		}
		
		internal static void ProjectileEditorOk()
		{
			int i = 0;
			
			for (i = 1; i <= MAX_PROJECTILES; i++)
			{
				if (Projectile_Changed[i])
				{
					SendSaveProjectile(i);
				}
			}
			
			frmProjectile.Default.Close();
			E_Globals.Editor = (byte) 0;
			ClearChanged_Projectile();
			
		}
		
		internal static void ProjectileEditorCancel()
		{
			
			E_Globals.Editor = (byte) 0;
			frmProjectile.Default.Close();
			ClearChanged_Projectile();
			ClearProjectiles();
			SendRequestProjectiles();
			
		}
		
		internal static void ClearChanged_Projectile()
		{
			int i = 0;
			
			for (i = 0; i <= MAX_PROJECTILES; i++)
			{
				Projectile_Changed[i] = false;
			}
			
		}
		
#endregion
		
	}
}
