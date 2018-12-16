
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
using Microsoft.VisualBasic.CompilerServices;
using System.Threading;
using Engine;


namespace Engine
{
	sealed class ClientDataBase
	{
		internal static Random GameRand = new Random();
		
		public static void ClearTempTile()
		{
			int X = 0;
			int Y = 0;
			E_Types.TempTile = new E_Types.TempTileRec[E_Types.Map.MaxX + 1, E_Types.Map.MaxY + 1];
			
			for (X = 0; X <= E_Types.Map.MaxX; X++)
			{
				for (Y = 0; Y <= E_Types.Map.MaxY; Y++)
				{
					E_Types.TempTile[X, Y].DoorOpen = (byte) 0;
				}
			}
			
		}
		
		internal static dynamic IsInBounds()
		{
			dynamic returnValue = default(dynamic);
			returnValue = false;
			if (E_Globals.CurX >= 0)
			{
				if (E_Globals.CurX <= E_Types.Map.MaxX)
				{
					if (E_Globals.CurY >= 0)
					{
						if (E_Globals.CurY <= E_Types.Map.MaxY)
						{
							return true;
						}
					}
				}
			}
			
			return returnValue;
		}
		
		internal static dynamic GetTickCount()
		{
			return Environment.TickCount;
		}
		
		internal static int Rand(int MaxNumber, int MinNumber = 0)
		{
			if (MinNumber > MaxNumber)
			{
				int t = MinNumber;
				MinNumber = MaxNumber;
				MaxNumber = t;
			}
			
			return GameRand.Next(MinNumber, MaxNumber);
		}
		
		internal static void CheckTilesets()
		{
			int i = 0;
			Bitmap tmp = default(Bitmap);
			i = 1;
			
			while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "\\tilesets\\" + System.Convert.ToString(i) + E_Globals.GFX_EXT))
			{
				E_Graphics.NumTileSets++;
				i++;
			}
			
			E_Globals.TilesetsClr = new Color[E_Graphics.NumTileSets + 1];
			
			for (i = 1; i <= E_Graphics.NumTileSets; i++)
			{
				tmp = new Bitmap(Application.StartupPath + E_Globals.GFX_PATH + "\\tilesets\\" + System.Convert.ToString(i) + E_Globals.GFX_EXT);
				E_Globals.TilesetsClr[E_Graphics.NumTileSets] = tmp.GetPixel(0, 0);
			}
			if (E_Graphics.NumTileSets == 0)
			{
				return;
			}
			
		}
		
		internal static void CheckCharacters()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "characters\\" + System.Convert.ToString(i) + E_Globals.GFX_EXT))
			{
				E_Graphics.NumCharacters++;
				i++;
			}
			
			if (E_Graphics.NumCharacters == 0)
			{
				return;
			}
		}
		
		internal static void CheckPaperdolls()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "paperdolls\\" + System.Convert.ToString(i) + E_Globals.GFX_EXT))
			{
				E_Graphics.NumPaperdolls++;
				i++;
			}
			
			if (E_Graphics.NumPaperdolls == 0)
			{
				return;
			}
		}
		
		internal static void CheckAnimations()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "animations\\" + System.Convert.ToString(i) + E_Globals.GFX_EXT))
			{
				E_Graphics.NumAnimations++;
				i++;
			}
			
			if (E_Graphics.NumAnimations == 0)
			{
				return;
			}
		}
		
		internal static void CheckResources()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Resources\\" + System.Convert.ToString(i) + E_Globals.GFX_EXT))
			{
				E_Graphics.NumResources++;
				i++;
			}
			
			if (E_Graphics.NumResources == 0)
			{
				return;
			}
		}
		
		internal static void CheckSkillIcons()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "SkillIcons\\" + System.Convert.ToString(i) + E_Globals.GFX_EXT))
			{
				E_Graphics.NumSkillIcons++;
				i++;
			}
			
			if (E_Graphics.NumSkillIcons == 0)
			{
				return;
			}
		}
		
		internal static void CheckFaces()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Faces\\" + System.Convert.ToString(i) + E_Globals.GFX_EXT))
			{
				E_Graphics.NumFaces++;
				i++;
			}
			
			if (E_Graphics.NumFaces == 0)
			{
				return;
			}
		}
		
		internal static void CheckFog()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Fogs\\" + System.Convert.ToString(i) + E_Globals.GFX_EXT))
			{
				E_Graphics.NumFogs++;
				i++;
			}
			
			if (E_Graphics.NumFogs == 0)
			{
				return;
			}
		}
		
		internal static void CacheMusic()
		{
			string[] Files = Directory.GetFiles(Application.StartupPath + E_Globals.MUSIC_PATH, "*.ogg");
			string MaxNum = System.Convert.ToString(Directory.GetFiles(Application.StartupPath + E_Globals.MUSIC_PATH, "*.ogg").Count());
			int Counter = 1;
			
			foreach (var FileName in Files)
			{
				Array.Resize(ref E_Sound.MusicCache, Counter + 1);
				
				E_Sound.MusicCache[Counter] = Path.GetFileName(FileName);
				Counter++;
				Application.DoEvents();
			}
			
		}
		
		internal static void CacheSound()
		{
			string[] Files = Directory.GetFiles(Application.StartupPath + E_Globals.SOUND_PATH, "*.ogg");
			string MaxNum = System.Convert.ToString(Directory.GetFiles(Application.StartupPath + E_Globals.SOUND_PATH, "*.ogg").Count());
			int Counter = 1;
			
			foreach (var FileName in Files)
			{
				Array.Resize(ref E_Sound.SoundCache, Counter + 1);
				
				E_Sound.SoundCache[Counter] = Path.GetFileName(FileName);
				Counter++;
				Application.DoEvents();
			}
			
		}
		
		internal static string GetFileContents(string FullPath, ref string ErrInfo)
		{
			string strContents = "";
			StreamReader objReader = default(StreamReader);
			strContents = "";
			try
			{
				objReader = new StreamReader(FullPath);
				strContents = objReader.ReadToEnd();
				objReader.Close();
			}
			catch (Exception Ex)
			{
				ErrInfo = Ex.Message;
			}
			return strContents;
		}
		
		public static void ClearMap()
		{
			lock(E_Types.MapLock)
			{
				E_Types.Map.mapNum = 0;
				E_Types.Map.Name = "";
				E_Types.Map.tileset = 1;
				E_Types.Map.MaxX = E_Globals.SCREEN_MAPX;
				E_Types.Map.MaxY = E_Globals.SCREEN_MAPY;
				E_Types.Map.BootMap = 0;
				E_Types.Map.BootX = (byte) 0;
				E_Types.Map.BootY = (byte) 0;
				E_Types.Map.Down = 0;
				E_Types.Map.Left = 0;
				E_Types.Map.Moral = (byte) 0;
				E_Types.Map.Music = "";
				E_Types.Map.Revision = 0;
				E_Types.Map.Right = 0;
				E_Types.Map.Up = 0;
				
				E_Types.Map.Npc = new int[Constants.MAX_MAP_NPCS + 1];
				E_Types.Map.Tile = new Types.TileRec[E_Types.Map.MaxX + 1, E_Types.Map.MaxY + 1];
				
				for (var x = 0; x <= E_Globals.SCREEN_MAPX; x++)
				{
					for (var y = 0; y <= E_Globals.SCREEN_MAPY; y++)
					{
						E_Types.Map.Tile[(int) x, (int) y].Layer = new Types.TileDataRec[(int) Enums.LayerType.Count];
						for (var l = 0; l <= (int) Enums.LayerType.Count - 1; l++)
						{
							E_Types.Map.Tile[(int) x, (int) y].Layer[(int) l].Tileset = (byte) 0;
							E_Types.Map.Tile[(int) x, (int) y].Layer[(int) l].X = (byte) 0;
							E_Types.Map.Tile[(int) x, (int) y].Layer[(int) l].Y = (byte) 0;
							E_Types.Map.Tile[(int) x, (int) y].Layer[(int) l].AutoTile = (byte) 0;
						}
						
					}
				}
				
			}
			
		}
		
		public static void ClearMapItems()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
			{
				ClearMapItem(i);
			}
			
		}
		
		public static void ClearMapItem(int index)
		{
			E_Types.MapItem[index].Frame = (byte) 0;
			E_Types.MapItem[index].Num = 0;
			E_Types.MapItem[index].Value = 0;
			E_Types.MapItem[index].X = (byte) 0;
			E_Types.MapItem[index].Y = (byte) 0;
		}
		
		public static void ClearMapNpc(int index)
		{
			E_Types.MapNpc[index].Attacking = (byte) 0;
			E_Types.MapNpc[index].AttackTimer = 0;
			E_Types.MapNpc[index].Dir = (byte) 0;
			E_Types.MapNpc[index].Map = 0;
			E_Types.MapNpc[index].Moving = (byte) 0;
			E_Types.MapNpc[index].Num = (byte) 0;
			E_Types.MapNpc[index].Steps = 0;
			E_Types.MapNpc[index].Target = 0;
			E_Types.MapNpc[index].TargetType = (byte) 0;
			E_Types.MapNpc[index].Vital[(byte)Enums.VitalType.HP] = 0;
			E_Types.MapNpc[index].Vital[(byte)Enums.VitalType.MP] = 0;
			E_Types.MapNpc[index].Vital[(byte)Enums.VitalType.SP] = 0;
			E_Types.MapNpc[index].X = (byte) 0;
			E_Types.MapNpc[index].XOffset = 0;
			E_Types.MapNpc[index].Y = (byte) 0;
			E_Types.MapNpc[index].YOffset = 0;
		}
		
		public static void ClearMapNpcs()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
			{
				ClearMapNpc(i);
			}
			
		}
		
		internal static void ClearChanged_Resource()
		{
			for (var i = 1; i <= Constants.MAX_RESOURCES; i++)
			{
				E_Globals.Resource_Changed[(int) i] = false;
			}
			E_Globals.Resource_Changed = new bool[Constants.MAX_RESOURCES + 1];
		}
		
		public static void ClearResource(int index)
		{
			Types.Resource[index] = new Types.ResourceRec {
					Name = ""
				};
		}
		
		public static void ClearResources()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_RESOURCES; i++)
			{
				ClearResource(i);
			}
			
		}
		
		public static void ClearNpcs()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_NPCS; i++)
			{
				ClearNpc(i);
			}
			
		}
		
		public static void ClearNpc(int index)
		{
			Types.Npc[index].Name = "";
			Types.Npc[index].AttackSay = "";
			Types.Npc[index].Stat = new byte[(int) Enums.StatType.Count];
			Types.Npc[index].Skill = new byte[Constants.MAX_NPC_SKILLS + 1];
			
			Types.Npc[index].DropItem = new int[6];
			Types.Npc[index].DropItemValue = new int[6];
			Types.Npc[index].DropChance = new int[6];
		}
		
		public static void ClearAnimation(int index)
		{
			Types.Animation[index] = new Types.AnimationRec();
			for (var x = 0; x <= 1; x++)
			{
				Types.Animation[index].Sprite = new int[(int) x + 1];
			}
			for (var x = 0; x <= 1; x++)
			{
				Types.Animation[index].Frames = new int[(int) x + 1];
			}
			for (var x = 0; x <= 1; x++)
			{
				Types.Animation[index].LoopCount = new int[(int) x + 1];
			}
			for (var x = 0; x <= 1; x++)
			{
				Types.Animation[index].LoopTime = new int[(int) x + 1];
			}
			Types.Animation[index].Name = "";
		}
		
		public static void ClearAnimations()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
			{
				ClearAnimation(i);
			}
			
		}
		
		public static void ClearSkills()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_SKILLS; i++)
			{
				ClearSkill(i);
			}
			
		}
		
		public static void ClearSkill(int index)
		{
			Types.Skill[index] = new Types.SkillRec {
					Name = ""
				};
		}
		
		public static void ClearShop(int index)
		{
			Types.Shop[index] = new Types.ShopRec {
					Name = ""
				};
			Types.Shop[index].TradeItem = new Types.TradeItemRec[Constants.MAX_TRADES + 1];
		}
		
		public static void ClearShops()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_SHOPS; i++)
			{
				ClearShop(i);
			}
			
		}
		
	}
}
