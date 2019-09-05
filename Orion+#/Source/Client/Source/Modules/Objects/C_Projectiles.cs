
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.IO;
using System.Windows.Forms;
using ASFW;
using SFML.Graphics;
using SFML.Window;
using Engine;


namespace Engine
{
	internal sealed class C_Projectiles
	{
		
#region Defines
		
		internal const int MaxProjectiles = 255;
		internal static ProjectileRec[] Projectiles = new ProjectileRec[MaxProjectiles + 1];
		internal static MapProjectileRec[] MapProjectiles = new MapProjectileRec[MaxProjectiles + 1];
		internal static int NumProjectiles;
		internal static bool InitProjectileEditor;
		internal const byte EditorProjectile = 10;
		internal static bool[] ProjectileChanged = new bool[MaxProjectiles + 1];
		
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
			public byte Dir;
			public int Range;
			public int TravelTime;
			public int Timer;
		}
		
#endregion
		
#region Sending
		
		public static void SendRequestProjectiles()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestProjectiles);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
		public static void SendClearProjectile(int projectileNum, int collisionindex, byte collisionType, int collisionZone)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CClearProjectile);
			buffer.WriteInt32(projectileNum);
			buffer.WriteInt32(collisionindex);
			buffer.WriteInt32(collisionType);
			buffer.WriteInt32(collisionZone);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
			
		}
		
#endregion
		
#region Recieving
		
		internal static void HandleUpdateProjectile(ref byte[] data)
		{
			int projectileNum = 0;
			ByteStream buffer = new ByteStream(data);
			projectileNum = buffer.ReadInt32();
			
			Projectiles[projectileNum].Name = buffer.ReadString();
			Projectiles[projectileNum].Sprite = buffer.ReadInt32();
			Projectiles[projectileNum].Range = (byte) (buffer.ReadInt32());
			Projectiles[projectileNum].Speed = buffer.ReadInt32();
			Projectiles[projectileNum].Damage = buffer.ReadInt32();
			
			buffer.Dispose();
			
		}
		
		internal static void HandleMapProjectile(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			
			ref var with_1 = ref MapProjectiles[i];
			with_1.ProjectileNum = buffer.ReadInt32();
			with_1.Owner = buffer.ReadInt32();
			with_1.OwnerType = (byte) (buffer.ReadInt32());
			with_1.Dir = (byte) (buffer.ReadInt32());
			with_1.X = buffer.ReadInt32();
			with_1.Y = buffer.ReadInt32();
			with_1.Range = 0;
			with_1.Timer = C_General.GetTickCount() + 60000;
			
			buffer.Dispose();
			
		}
		
#endregion
		
#region Database
		
		public static void ClearProjectiles()
		{
			int i = 0;
			
			for (i = 1; i <= MaxProjectiles; i++)
			{
				ClearProjectile(i);
			}
			
		}
		
		public static void ClearProjectile(int index)
		{
			
			Projectiles[index].Name = "";
			Projectiles[index].Sprite = 0;
			Projectiles[index].Range = (byte) 0;
			Projectiles[index].Speed = 0;
			Projectiles[index].Damage = 0;
			
		}
		
		public static void ClearMapProjectile(int projectileNum)
		{
			
			MapProjectiles[projectileNum].ProjectileNum = 0;
			MapProjectiles[projectileNum].Owner = 0;
			MapProjectiles[projectileNum].OwnerType = (byte) 0;
			MapProjectiles[projectileNum].X = 0;
			MapProjectiles[projectileNum].Y = 0;
			MapProjectiles[projectileNum].Dir = (byte) 0;
			MapProjectiles[projectileNum].Timer = 0;
			
		}
		
#endregion
		
#region Drawing
		
		internal static void CheckProjectiles()
		{
			int i = 0;
			
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "projectiles\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				
				NumProjectiles++;
				i++;
			}
			
			if (NumProjectiles == 0)
			{
				return;
			}
			
		}
		
		internal static void DrawProjectile(int projectileNum)
		{
			Types.Rect rec = new Types.Rect();
			bool canClearProjectile = false;
			int collisionindex = 0;
			byte collisionType = 0;
			int collisionZone = 0;
			int xOffset;
			int yOffset;
			int x = 0;
			int y = 0;
			int i = 0;
			int sprite = 0;
			
			// check to see if it's time to move the Projectile
			if (C_General.GetTickCount() > MapProjectiles[projectileNum].TravelTime)
			{
				if (MapProjectiles[projectileNum].Dir == (byte)Enums.DirectionType.Up)
				{
					MapProjectiles[projectileNum].Y = MapProjectiles[projectileNum].Y - 1;
				}
				else if (MapProjectiles[projectileNum].Dir == (byte)Enums.DirectionType.Down)
				{
					MapProjectiles[projectileNum].Y = MapProjectiles[projectileNum].Y + 1;
				}
				else if (MapProjectiles[projectileNum].Dir == (byte)Enums.DirectionType.Left)
				{
					MapProjectiles[projectileNum].X = MapProjectiles[projectileNum].X - 1;
				}
				else if (MapProjectiles[projectileNum].Dir == (byte)Enums.DirectionType.Right)
				{
					MapProjectiles[projectileNum].X = MapProjectiles[projectileNum].X + 1;
				}
				MapProjectiles[projectileNum].TravelTime = C_General.GetTickCount() + Projectiles[MapProjectiles[projectileNum].ProjectileNum].Speed;
				MapProjectiles[projectileNum].Range = MapProjectiles[projectileNum].Range + 1;
			}
			
			x = MapProjectiles[projectileNum].X;
			y = MapProjectiles[projectileNum].Y;
			
			//Check if its been going for over 1 minute, if so clear.
			if (MapProjectiles[projectileNum].Timer < C_General.GetTickCount())
			{
				canClearProjectile = true;
			}
			
			if (x > C_Maps.Map.MaxX || x < 0)
			{
				canClearProjectile = true;
			}
			if (y > C_Maps.Map.MaxY || y < 0)
			{
				canClearProjectile = true;
			}
			
			//Check for blocked wall collision
			if (canClearProjectile == false) //Add a check to prevent crashing
			{
				if (C_Maps.Map.Tile[x, y].Type == (byte)Enums.TileType.Blocked)
				{
					canClearProjectile = true;
				}
			}
			
			//Check for npc collision
			for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
			{
				if (C_Maps.MapNpc[i].X == x && C_Maps.MapNpc[i].Y == y)
				{
					canClearProjectile = true;
					collisionindex = i;
					collisionType = (byte)Enums.TargetType.Npc;
					collisionZone = -1;
					break;
				}
			}
			
			//Check for player collision
			for (i = 1; i <= Constants.MAX_PLAYERS; i++)
			{
				if (C_Player.IsPlaying(i) && C_Player.GetPlayerMap(i) == C_Player.GetPlayerMap(C_Variables.Myindex))
				{
					if (C_Player.GetPlayerX(i) == x && C_Player.GetPlayerY(i) == y)
					{
						canClearProjectile = true;
						collisionindex = i;
						collisionType = (byte)Enums.TargetType.Player;
						collisionZone = -1;
						if (MapProjectiles[projectileNum].OwnerType == (byte)Enums.TargetType.Player)
						{
							if (MapProjectiles[projectileNum].Owner == i)
							{
								canClearProjectile = false; // Reset if its the owner of projectile
							}
						}
						break;
					}
					
				}
			}
			
			//Check if it has hit its maximum range
			if (MapProjectiles[projectileNum].Range >= Projectiles[MapProjectiles[projectileNum].ProjectileNum].Range + 1)
			{
				canClearProjectile = true;
			}
			
			//Clear the projectile if possible
			if (canClearProjectile == true)
			{
				//Only send the clear to the server if you're the projectile caster or the one hit (only if owner is not a player)
				if (MapProjectiles[projectileNum].OwnerType == (byte)Enums.TargetType.Player && MapProjectiles[projectileNum].Owner == C_Variables.Myindex)
				{
					SendClearProjectile(projectileNum, collisionindex, collisionType, collisionZone);
				}
				
				ClearMapProjectile(projectileNum);
				return;
			}
			
			sprite = Projectiles[MapProjectiles[projectileNum].ProjectileNum].Sprite;
			if (sprite < 1 || sprite > NumProjectiles)
			{
				return;
			}
			
			if (C_Graphics.ProjectileGfxInfo[sprite].IsLoaded == false)
			{
				C_Graphics.LoadTexture(sprite, (byte) 11);
			}
			
			//seeying we still use it, lets update timer
			ref var with_1 = ref C_Graphics.ProjectileGfxInfo[sprite];
			with_1.TextureTimer = C_General.GetTickCount() + 100000;
			
			// src rect
			rec.Top = 0;
			rec.Bottom = C_Graphics.ProjectileGfxInfo[sprite].Height;
			rec.Left = MapProjectiles[projectileNum].Dir * C_Constants.PicX;
			rec.Right = rec.Left + C_Constants.PicX;
			
			//Find the offset
			if (MapProjectiles[projectileNum].Dir == (byte)Enums.DirectionType.Up)
			{
				yOffset = ((MapProjectiles[projectileNum].TravelTime - C_General.GetTickCount()) / Projectiles[MapProjectiles[projectileNum].ProjectileNum].Speed) * C_Constants.PicY;
			}
			else if (MapProjectiles[projectileNum].Dir == (byte)Enums.DirectionType.Down)
			{
				yOffset = - ((MapProjectiles[projectileNum].TravelTime - C_General.GetTickCount()) / Projectiles[MapProjectiles[projectileNum].ProjectileNum].Speed) * C_Constants.PicY;
			}
			else if (MapProjectiles[projectileNum].Dir == (byte)Enums.DirectionType.Left)
			{
				xOffset = ((MapProjectiles[projectileNum].TravelTime - C_General.GetTickCount()) / Projectiles[MapProjectiles[projectileNum].ProjectileNum].Speed) * C_Constants.PicX;
			}
			else if (MapProjectiles[projectileNum].Dir == (byte)Enums.DirectionType.Right)
			{
				xOffset = -((MapProjectiles[projectileNum].TravelTime - C_General.GetTickCount()) / Projectiles[MapProjectiles[projectileNum].ProjectileNum].Speed) * C_Constants.PicX;
			}
			
			x = C_Graphics.ConvertMapX(x * C_Constants.PicX);
			y = C_Graphics.ConvertMapY(y * C_Constants.PicY);
			
			Sprite tmpSprite = new Sprite(C_Graphics.ProjectileGfx[sprite]) {
					TextureRect = new IntRect(rec.Left, rec.Top, 32, 32),
					Position = new Vector2f(x, y)
				};
			C_Graphics.GameWindow.Draw(tmpSprite);
			
		}
		
#endregion
		
	}
}
