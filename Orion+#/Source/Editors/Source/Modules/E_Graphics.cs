
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
using SFML.Graphics;
using SFML.Window;
using Engine;


namespace Engine
{
	sealed class E_Graphics
	{
		internal static RenderWindow GameWindow;
		internal static RenderWindow TilesetWindow;
		
		internal static RenderWindow EditorItem_Furniture;
		
		internal static RenderWindow EditorSkill_Icon;
		
		internal static RenderWindow EditorAnimation_Anim1;
		internal static RenderWindow EditorAnimation_Anim2;
		
		internal static RenderWindow TmpItemWindow;
		
		internal static SFML.Graphics.Font SFMLGameFont;
		
		//TileSets
		internal static Texture[] TileSetTexture;
		
		internal static Sprite[] TileSetSprite;
		internal static GraphicInfo[] TileSetTextureInfo;
		
		//Characters
		internal static Texture[] CharacterGFX;
		
		internal static Sprite[] CharacterSprite;
		internal static GraphicInfo[] CharacterGFXInfo;
		
		//Paperdolls
		internal static Texture[] PaperDollGFX;
		
		internal static Sprite[] PaperDollSprite;
		internal static GraphicInfo[] PaperDollGFXInfo;
		
		//Items
		internal static Texture[] ItemsGFX;
		
		internal static Sprite[] ItemsSprite;
		internal static GraphicInfo[] ItemsGFXInfo;
		
		//Resources
		internal static Texture[] ResourcesGFX;
		
		internal static Sprite[] ResourcesSprite;
		internal static GraphicInfo[] ResourcesGFXInfo;
		
		//Animations
		internal static Texture[] AnimationsGFX;
		
		internal static Sprite[] AnimationsSprite;
		internal static GraphicInfo[] AnimationsGFXInfo;
		
		//Skills
		internal static Texture[] SkillIconsGFX;
		
		internal static Sprite[] SkillIconsSprite;
		internal static GraphicInfo[] SkillIconsGFXInfo;
		
		//Housing
		internal static Texture[] FurnitureGFX;
		
		internal static Sprite[] FurnitureSprite;
		internal static GraphicInfo[] FurnitureGFXInfo;
		
		//Faces
		internal static Texture[] FacesGFX;
		
		internal static Sprite[] FacesSprite;
		internal static GraphicInfo[] FacesGFXInfo;
		
		//Projectiles
		internal static Texture[] ProjectileGFX;
		
		internal static Sprite[] ProjectileSprite;
		internal static GraphicInfo[] ProjectileGFXInfo;
		
		//Fogs
		internal static Texture[] FogGFX;
		
		internal static Sprite[] FogSprite;
		internal static GraphicInfo[] FogGFXInfo;
		
		//Door
		internal static Texture DoorGFX;
		
		internal static Sprite DoorSprite;
		internal static GraphicInfo DoorGFXInfo;
		
		//Directions
		internal static Texture DirectionsGfx;
		
		internal static Sprite DirectionsSprite;
		internal static GraphicInfo DirectionsGFXInfo;
		
		//Weather
		internal static Texture WeatherGFX;
		
		internal static Sprite WeatherSprite;
		internal static GraphicInfo WeatherGFXInfo;
		
		// Number of graphic files
		internal static Bitmap MapEditorBackBuffer;
		
		internal static Sprite MapTintSprite;
		
		internal static int NumTileSets;
		internal static int NumCharacters;
		internal static int NumPaperdolls;
		internal static int NumItems;
		internal static int NumResources;
		internal static int NumAnimations;
		internal static int NumSkillIcons;
		internal static int NumFaces;
		internal static int NumFogs;
		
		internal static RenderTexture NightGfx = new RenderTexture((uint) 245, (uint) 245);
		internal static Sprite NightSprite;
		internal static GraphicInfo NightGfxInfo;
		
		internal static Texture LightGfx;
		internal static Sprite LightSprite;
		internal static GraphicInfo LightGfxInfo;
		
		public struct GraphicInfo
		{
			public int width;
			public int height;
			public bool IsLoaded;
			public int TextureTimer;
		}
		
		public struct Graphics_Tiles
		{
			public Texture[,] Tile;
		}
		
		public static void InitGraphics()
		{
			
			GameWindow = new RenderWindow(frmMapEditor.Default.picScreen.Handle);
			GameWindow.SetFramerateLimit((uint) E_Globals.FPS_LIMIT);
			
			TilesetWindow = new RenderWindow(frmMapEditor.Default.picBackSelect.Handle);
			
			EditorItem_Furniture = new RenderWindow(FrmItem.Default.picFurniture.Handle);
			
			EditorSkill_Icon = new RenderWindow(frmSkill.Default.picSprite.Handle);
			
			EditorAnimation_Anim1 = new RenderWindow(FrmAnimation.Default.picSprite0.Handle);
			EditorAnimation_Anim2 = new RenderWindow(FrmAnimation.Default.picSprite1.Handle);
			
			SFMLGameFont = new SFML.Graphics.Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\" + E_Globals.FONT_NAME);
			
			//this stuff only loads when needed :)
			
			TileSetTexture = new Texture[NumTileSets + 1];
			TileSetSprite = new Sprite[NumTileSets + 1];
			TileSetTextureInfo = new E_Graphics.GraphicInfo[NumTileSets + 1];
			
			CharacterGFX = new Texture[NumCharacters + 1];
			CharacterSprite = new Sprite[NumCharacters + 1];
			CharacterGFXInfo = new E_Graphics.GraphicInfo[NumCharacters + 1];
			
			PaperDollGFX = new Texture[NumPaperdolls + 1];
			PaperDollSprite = new Sprite[NumPaperdolls + 1];
			PaperDollGFXInfo = new E_Graphics.GraphicInfo[NumPaperdolls + 1];
			
			ItemsGFX = new Texture[NumItems + 1];
			ItemsSprite = new Sprite[NumItems + 1];
			ItemsGFXInfo = new E_Graphics.GraphicInfo[NumItems + 1];
			
			ResourcesGFX = new Texture[NumResources + 1];
			ResourcesSprite = new Sprite[NumResources + 1];
			ResourcesGFXInfo = new E_Graphics.GraphicInfo[NumResources + 1];
			
			AnimationsGFX = new Texture[NumAnimations + 1];
			AnimationsSprite = new Sprite[NumAnimations + 1];
			AnimationsGFXInfo = new E_Graphics.GraphicInfo[NumAnimations + 1];
			
			SkillIconsGFX = new Texture[NumSkillIcons + 1];
			SkillIconsSprite = new Sprite[NumSkillIcons + 1];
			SkillIconsGFXInfo = new E_Graphics.GraphicInfo[NumSkillIcons + 1];
			
			FacesGFX = new Texture[NumFaces + 1];
			FacesSprite = new Sprite[NumFaces + 1];
			FacesGFXInfo = new E_Graphics.GraphicInfo[NumFaces + 1];
			
			FurnitureGFX = new Texture[E_Housing.NumFurniture + 1];
			FurnitureSprite = new Sprite[E_Housing.NumFurniture + 1];
			FurnitureGFXInfo = new E_Graphics.GraphicInfo[E_Housing.NumFurniture + 1];
			
			ProjectileGFX = new Texture[E_Projectiles.NumProjectiles + 1];
			ProjectileSprite = new Sprite[E_Projectiles.NumProjectiles + 1];
			ProjectileGFXInfo = new E_Graphics.GraphicInfo[E_Projectiles.NumProjectiles + 1];
			
			FogGFX = new Texture[NumFogs + 1];
			FogSprite = new Sprite[NumFogs + 1];
			FogGFXInfo = new E_Graphics.GraphicInfo[NumFogs + 1];
			
			//sadly, gui shit is always needed, so we preload it :/
			DoorGFXInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Misc\\Door" + E_Globals.GFX_EXT))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				DoorGFX = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "Misc\\Door" + E_Globals.GFX_EXT);
				DoorSprite = new Sprite(DoorGFX);
				
				//Cache the width and height
				DoorGFXInfo.width = (int)DoorGFX.Size.X;
				DoorGFXInfo.height = (int)DoorGFX.Size.Y;
			}
			
			DirectionsGFXInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Misc\\Direction" + E_Globals.GFX_EXT))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				DirectionsGfx = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "Misc\\Direction" + E_Globals.GFX_EXT);
				DirectionsSprite = new Sprite(DirectionsGfx);
				
				//Cache the width and height
				DirectionsGFXInfo.width = (int)DirectionsGfx.Size.X;
				DirectionsGFXInfo.height = (int)DirectionsGfx.Size.Y;
			}
			
			WeatherGFXInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Misc\\Weather" + E_Globals.GFX_EXT))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				WeatherGFX = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "Misc\\Weather" + E_Globals.GFX_EXT);
				WeatherSprite = new Sprite(WeatherGFX);
				
				//Cache the width and height
				WeatherGFXInfo.width = (int)WeatherGFX.Size.X;
				WeatherGFXInfo.height = (int)WeatherGFX.Size.Y;
			}
			
			LightGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Misc\\Light" + E_Globals.GFX_EXT))
			{
				LightGfx = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "Misc\\Light" + E_Globals.GFX_EXT);
				LightSprite = new Sprite(LightGfx);
				
				//Cache the width and height
				LightGfxInfo.width = (int)LightGfx.Size.X;
				LightGfxInfo.height = (int)LightGfx.Size.Y;
			}
			
		}
		
		internal static void LoadTexture(int index, byte TexType)
		{
			
			if (TexType == 1) //tilesets
			{
				if (index <= 0 || index > NumTileSets)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				TileSetTexture[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "tilesets\\" + System.Convert.ToString(index) + E_Globals.GFX_EXT);
				TileSetSprite[index] = new Sprite(TileSetTexture[index]);
				
				//Cache the width and height
				TileSetTextureInfo[index].width = (int)TileSetTexture[index].Size.X;
				TileSetTextureInfo[index].height = (int)TileSetTexture[index].Size.Y;
				TileSetTextureInfo[index].IsLoaded = true;
				TileSetTextureInfo[index].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
				
			}
			else if (TexType == 2) //characters
			{
				if (index <= 0 || index > NumCharacters)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				CharacterGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "characters\\" + System.Convert.ToString(index) + E_Globals.GFX_EXT);
				CharacterSprite[index] = new Sprite(CharacterGFX[index]);
				
				//Cache the width and height
				CharacterGFXInfo[index].width = (int)CharacterGFX[index].Size.X;
				CharacterGFXInfo[index].height = (int)CharacterGFX[index].Size.Y;
				CharacterGFXInfo[index].IsLoaded = true;
				CharacterGFXInfo[index].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
				
			}
			else if (TexType == 3) //paperdoll
			{
				if (index <= 0 || index > NumPaperdolls)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				PaperDollGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "Paperdolls\\" + System.Convert.ToString(index) + E_Globals.GFX_EXT);
				PaperDollSprite[index] = new Sprite(PaperDollGFX[index]);
				
				//Cache the width and height
				PaperDollGFXInfo[index].width = (int)PaperDollGFX[index].Size.X;
				PaperDollGFXInfo[index].height = (int)PaperDollGFX[index].Size.Y;
				PaperDollGFXInfo[index].IsLoaded = true;
				PaperDollGFXInfo[index].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
				
			}
			else if (TexType == 4) //items
			{
				if (index <= 0 || index > NumItems)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				ItemsGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "items\\" + System.Convert.ToString(index) + E_Globals.GFX_EXT);
				ItemsSprite[index] = new Sprite(ItemsGFX[index]);
				
				//Cache the width and height
				ItemsGFXInfo[index].width = (int)ItemsGFX[index].Size.X;
				ItemsGFXInfo[index].height = (int)ItemsGFX[index].Size.Y;
				ItemsGFXInfo[index].IsLoaded = true;
				ItemsGFXInfo[index].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
				
			}
			else if (TexType == 5) //resources
			{
				if (index <= 0 || index > NumResources)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				ResourcesGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "resources\\" + System.Convert.ToString(index) + E_Globals.GFX_EXT);
				ResourcesSprite[index] = new Sprite(ResourcesGFX[index]);
				
				//Cache the width and height
                ResourcesGFXInfo[index].width = (int)ResourcesGFX[index].Size.X;
                ResourcesGFXInfo[index].height = (int)ResourcesGFX[index].Size.Y;
                ResourcesGFXInfo[index].IsLoaded = true;
                ResourcesGFXInfo[index].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
				
			}
			else if (TexType == 6) //animations
			{
				if (index <= 0 || index > NumAnimations)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				AnimationsGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "Animations\\" + System.Convert.ToString(index) + E_Globals.GFX_EXT);
				AnimationsSprite[index] = new Sprite(AnimationsGFX[index]);
				
				//Cache the width and height
                AnimationsGFXInfo[index].width = (int)AnimationsGFX[index].Size.X;
                AnimationsGFXInfo[index].height = (int)AnimationsGFX[index].Size.Y;
                AnimationsGFXInfo[index].IsLoaded = true;
                AnimationsGFXInfo[index].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
				
			}
			else if (TexType == 7) //faces
			{
				if (index <= 0 || index > NumFaces)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				FacesGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "Faces\\" + System.Convert.ToString(index) + E_Globals.GFX_EXT);
				FacesSprite[index] = new Sprite(FacesGFX[index]);
				
				//Cache the width and height
                FacesGFXInfo[index].width = (int)FacesGFX[index].Size.X;
                FacesGFXInfo[index].height = (int)FacesGFX[index].Size.Y;
                FacesGFXInfo[index].IsLoaded = true;
                FacesGFXInfo[index].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
				
			}
			else if (TexType == 8) //fogs
			{
				if (index <= 0 || index > NumFogs)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				FogGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "Fogs\\" + System.Convert.ToString(index) + E_Globals.GFX_EXT);
				FogSprite[index] = new Sprite(FogGFX[index]);
				
				//Cache the width and height
                FogGFXInfo[index].width = (int)FogGFX[index].Size.X;
                FogGFXInfo[index].height = (int)FogGFX[index].Size.Y;
                FogGFXInfo[index].IsLoaded = true;
                FogGFXInfo[index].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
				
			}
			else if (TexType == 9) //skill icons
			{
				if (index <= 0 || index > NumSkillIcons)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				SkillIconsGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "SkillIcons\\" + System.Convert.ToString(index) + E_Globals.GFX_EXT);
				SkillIconsSprite[index] = new Sprite(SkillIconsGFX[index]);
				
				//Cache the width and height
                SkillIconsGFXInfo[index].width = (int)SkillIconsGFX[index].Size.X;
                SkillIconsGFXInfo[index].height = (int)SkillIconsGFX[index].Size.Y;
                SkillIconsGFXInfo[index].IsLoaded = true;
                SkillIconsGFXInfo[index].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
			}
			else if (TexType == 10) //furniture
			{
				if (index <= 0 || index > E_Housing.NumFurniture)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				FurnitureGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "Furniture\\" + System.Convert.ToString(index) + E_Globals.GFX_EXT);
				FurnitureSprite[index] = new Sprite(FurnitureGFX[index]);
				
				//Cache the width and height
				FurnitureGFXInfo[index].width = (int)FurnitureGFX[index].Size.X;
				FurnitureGFXInfo[index].height = (int)FurnitureGFX[index].Size.Y;
				FurnitureGFXInfo[index].IsLoaded = true;
				FurnitureGFXInfo[index].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
			}
			else if (TexType == 11) //projectiles
			{
				if (index <= 0 || index > E_Projectiles.NumProjectiles)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				ProjectileGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + "Projectiles\\" + System.Convert.ToString(index) + E_Globals.GFX_EXT);
				ProjectileSprite[index] = new Sprite(ProjectileGFX[index]);
				
				//Cache the width and height
				ProjectileGFXInfo[index].width = (int)ProjectileGFX[index].Size.X;
				ProjectileGFXInfo[index].height = (int)ProjectileGFX[index].Size.Y;
				ProjectileGFXInfo[index].IsLoaded = true;
				ProjectileGFXInfo[index].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
			}
			
		}
		
		internal static void RenderSprite(Sprite TmpSprite, RenderWindow Target, int DestX, int DestY, int SourceX, int SourceY, int SourceWidth, int SourceHeight)
		{
			
			TmpSprite.TextureRect = new IntRect(SourceX, SourceY, SourceWidth, SourceHeight);
			TmpSprite.Position = new Vector2f(DestX, DestY);
			Target.Draw(TmpSprite);
		}
		
		internal static void DrawDirections(int X, int Y)
		{
			Rectangle rec = new Rectangle();
			int i = 0;
			
			// render grid
			rec.Y = 24;
			rec.X = 0;
			rec.Width = 32;
			rec.Height = 32;
			
			RenderSprite(DirectionsSprite, GameWindow, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y), rec.X, rec.Y, rec.Width, rec.Height);
			
			// render dir blobs
			for (i = 1; i <= 4; i++)
			{
				rec.X = (i - 1) * 8;
				rec.Width = 8;
				// find out whether render blocked or not
				if (!IsDirBlocked(ref E_Types.Map.Tile[X, Y].DirBlock, (byte) (i)))
				{
					rec.Y = 8;
				}
				else
				{
					rec.Y = 16;
				}
				rec.Height = 8;
				
				RenderSprite(DirectionsSprite, GameWindow, ConvertMapX(X * E_Globals.PIC_X) + E_Globals.DirArrowX[i], ConvertMapY(Y * E_Globals.PIC_Y) + E_Globals.DirArrowY[i], rec.X, rec.Y, rec.Width, rec.Height);
			}
		}

        // BitWise Operators for directional blocking
        internal static void SetDirBlock(ref byte blockvar, byte Dir, bool block)
        {
            checked
            {
                if (block)
                {
                    blockvar = (byte)(unchecked(blockvar) | (ulong)((long)Math.Round(Math.Pow(2.0, Dir))));
                }
                else
                {
                    blockvar = (byte)(unchecked(blockvar) & (~(ulong)((long)Math.Round(Math.Pow(2.0, Dir)))));
                }
            }
        }

        internal static bool IsDirBlocked(ref byte blockvar, byte Dir)
        {
            return !(~blockvar <= 0 || Math.Pow(2.0, (double)Dir) == 0.0);
        }

        internal static int ConvertMapX(int X)
		{
			return X - (E_Globals.TileView.Left * E_Globals.PIC_X) - E_Globals.Camera.Left;
		}
		
		internal static int ConvertMapY(int Y)
		{
			return Y - (E_Globals.TileView.Top * E_Globals.PIC_Y) - E_Globals.Camera.Top;
		}
		
		internal static void DrawNpc(int MapNpcNum)
		{
			byte anim = 0;
			int X = 0;
			int Y = 0;
			int Sprite = 0;
			int spriteleft = 0;
			Rectangle destrec;
			Rectangle srcrec = new Rectangle();
			int attackspeed = 0;
			
			if (E_Types.MapNpc[MapNpcNum].Num == 0)
			{
				return; // no npc set
			}
			
			if (E_Types.MapNpc[MapNpcNum].X < E_Globals.TileView.Left || E_Types.MapNpc[MapNpcNum].X > E_Globals.TileView.Right)
			{
				return;
			}
			if (E_Types.MapNpc[MapNpcNum].Y < E_Globals.TileView.Top || E_Types.MapNpc[MapNpcNum].Y > E_Globals.TileView.Bottom)
			{
				return;
			}
			
			Sprite = Types.Npc[E_Types.MapNpc[MapNpcNum].Num].Sprite;
			
			if (Sprite < 1 || Sprite > NumCharacters)
			{
				return;
			}
			
			attackspeed = 1000;
			
			// Reset frame
			anim = (byte) 0;
			
			// Check for attacking animation
			if (E_Types.MapNpc[MapNpcNum].AttackTimer + ((double) attackspeed / 2) > System.Convert.ToDouble(ClientDataBase.GetTickCount()))
			{
				if (E_Types.MapNpc[MapNpcNum].Attacking == 1)
				{
					anim = (byte) 3;
				}
			}
			else
			{
				// If not attacking, walk normally
				if (E_Types.MapNpc[MapNpcNum].Dir == (byte)Enums.DirectionType.Up)
				{
					if (E_Types.MapNpc[MapNpcNum].YOffset > 8)
					{
						anim = (byte) (E_Types.MapNpc[MapNpcNum].Steps);
					}
				}
				else if (E_Types.MapNpc[MapNpcNum].Dir == (byte)Enums.DirectionType.Down)
				{
					if (E_Types.MapNpc[MapNpcNum].YOffset < -8)
					{
						anim = (byte) (E_Types.MapNpc[MapNpcNum].Steps);
					}
				}
				else if (E_Types.MapNpc[MapNpcNum].Dir == (byte)Enums.DirectionType.Left)
				{
					if (E_Types.MapNpc[MapNpcNum].XOffset > 8)
					{
						anim = (byte) (E_Types.MapNpc[MapNpcNum].Steps);
					}
				}
				else if (E_Types.MapNpc[MapNpcNum].Dir == (byte)Enums.DirectionType.Right)
				{
					if (E_Types.MapNpc[MapNpcNum].XOffset < -8)
					{
						anim = (byte) (E_Types.MapNpc[MapNpcNum].Steps);
					}
				}
			}
			
			// Check to see if we want to stop making him attack
			if (E_Types.MapNpc[MapNpcNum].AttackTimer + attackspeed < System.Convert.ToInt32(ClientDataBase.GetTickCount()))
			{
				E_Types.MapNpc[MapNpcNum].Attacking = (byte) 0;
				E_Types.MapNpc[MapNpcNum].AttackTimer = 0;
			}
			
			// Set the left
			if (E_Types.MapNpc[MapNpcNum].Dir == (byte)Enums.DirectionType.Up)
			{
				spriteleft = 3;
			}
			else if (E_Types.MapNpc[MapNpcNum].Dir == (byte)Enums.DirectionType.Right)
			{
				spriteleft = 2;
			}
			else if (E_Types.MapNpc[MapNpcNum].Dir == (byte)Enums.DirectionType.Down)
			{
				spriteleft = 0;
			}
			else if (E_Types.MapNpc[MapNpcNum].Dir == (byte)Enums.DirectionType.Left)
			{
				spriteleft = 1;
			}
			
			srcrec = new Rectangle(System.Convert.ToInt32((anim) * ((double) CharacterGFXInfo[Sprite].width / 4)), System.Convert.ToInt32(spriteleft * ((double) CharacterGFXInfo[Sprite].height / 4)), System.Convert.ToInt32((double) CharacterGFXInfo[Sprite].width / 4), System.Convert.ToInt32((double) CharacterGFXInfo[Sprite].height / 4));
			
			// Calculate the X
			X = System.Convert.ToInt32(E_Types.MapNpc[MapNpcNum].X * E_Globals.PIC_X + E_Types.MapNpc[MapNpcNum].XOffset - (((double) CharacterGFXInfo[Sprite].width / 4 - 32) / 2));
			
			// Is the player's height more than 32..
			if (((double) CharacterGFXInfo[Sprite].height / 4) > 32)
			{
				// Create a 32 pixel offset for larger sprites
				Y = System.Convert.ToInt32(E_Types.MapNpc[MapNpcNum].Y * E_Globals.PIC_Y + E_Types.MapNpc[MapNpcNum].YOffset - (((double) CharacterGFXInfo[Sprite].height / 4) - 32));
			}
			else
			{
				// Proceed as normal
				Y = E_Types.MapNpc[MapNpcNum].Y * E_Globals.PIC_Y + E_Types.MapNpc[MapNpcNum].YOffset;
			}
			
			destrec = new Rectangle(X, Y, System.Convert.ToInt32((double) CharacterGFXInfo[Sprite].width / 4), System.Convert.ToInt32((double) CharacterGFXInfo[Sprite].height / 4));
			
			DrawCharacter(Sprite, X, Y, srcrec);
			
		}
		
		internal static void DrawResource(int Resource, int dx, int dy, Rectangle rec)
		{
			if (Resource < 1 || Resource > NumResources)
			{
				return;
			}
			int X = 0;
			int Y = 0;
			int width;
			int height;
			
			X = ConvertMapX(dx);
			Y = ConvertMapY(dy);
			width = rec.Right - rec.Left;
			height = rec.Bottom - rec.Top;
			
			if (rec.Width < 0 || rec.Height < 0)
			{
				return;
			}
			
			if (ResourcesGFXInfo[Resource].IsLoaded == false)
			{
				LoadTexture(Resource, (byte) 5);
			}
			
			//seeying we still use it, lets update timer
			ResourcesGFXInfo[Resource].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
			
			RenderSprite(ResourcesSprite[Resource], GameWindow, X, Y, rec.X, rec.Y, rec.Width, rec.Height);
		}
		
		internal static void DrawMapResource(int Resource_num)
		{
			int Resource_master = 0;
			
			int Resource_state;
			int Resource_sprite = 0;
			Rectangle rec = new Rectangle();
			int X = 0;
			int Y = 0;
			
			if (E_Globals.GettingMap)
			{
				return;
			}
			if (E_Globals.MapData == false)
			{
				return;
			}
			
			if (E_Globals.MapResource[Resource_num].X > E_Types.Map.MaxX || E_Globals.MapResource[Resource_num].Y > E_Types.Map.MaxY)
			{
				return;
			}
			// Get the Resource type
			Resource_master = E_Types.Map.Tile[E_Globals.MapResource[Resource_num].X, E_Globals.MapResource[Resource_num].Y].Data1;
			
			if (Resource_master == 0)
			{
				return;
			}
			
			if (Types.Resource[Resource_master].ResourceImage == 0)
			{
				return;
			}
			
			// Get the Resource state
			Resource_state = E_Globals.MapResource[Resource_num].ResourceState;
			
			if (Resource_state == 0) // normal
			{
				Resource_sprite = Types.Resource[Resource_master].ResourceImage;
			}
			else if (Resource_state == 1) // used
			{
				Resource_sprite = Types.Resource[Resource_master].ExhaustedImage;
			}
			
			// src rect
			rec.Y = 0;
			rec.Height = ResourcesGFXInfo[Resource_sprite].height;
			rec.X = 0;
			rec.Width = ResourcesGFXInfo[Resource_sprite].width;
			
			// Set base x + y, then the offset due to size
			X = System.Convert.ToInt32((E_Globals.MapResource[Resource_num].X * E_Globals.PIC_X) - ((double) ResourcesGFXInfo[Resource_sprite].width / 2) + 16);
			Y = (E_Globals.MapResource[Resource_num].Y * E_Globals.PIC_Y) - ResourcesGFXInfo[Resource_sprite].height + 32;
			
			DrawResource(Resource_sprite, X, Y, rec);
		}
		
		internal static void DrawItem(int itemnum)
		{
			
			Rectangle srcrec = new Rectangle();
			Rectangle destrec;
			int PicNum = 0;
			int x = 0;
			int y = 0;
			PicNum = Types.Item[E_Types.MapItem[itemnum].Num].Pic;
			
			if (PicNum < 1 || PicNum > NumItems)
			{
				return;
			}
			
			if (ItemsGFXInfo[PicNum].IsLoaded == false)
			{
				LoadTexture(PicNum, (byte) 4);
			}
			
			//seeying we still use it, lets update timer
			ItemsGFXInfo[PicNum].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
			
			if (E_Types.MapItem[itemnum].X < E_Globals.TileView.Left || E_Types.MapItem[itemnum].X > E_Globals.TileView.Right)
			{
				return;
			}
			if (E_Types.MapItem[itemnum].Y < E_Globals.TileView.Top || E_Types.MapItem[itemnum].Y > E_Globals.TileView.Bottom)
			{
				return;
			}
			
			if (ItemsGFXInfo[PicNum].width > 32) // has more than 1 frame
			{
				srcrec = new Rectangle(E_Types.MapItem[itemnum].Frame * 32, 0, 32, 32);
				destrec = new Rectangle(ConvertMapX(E_Types.MapItem[itemnum].X * E_Globals.PIC_X), ConvertMapY(E_Types.MapItem[itemnum].Y * E_Globals.PIC_Y), 32, 32);
			}
			else
			{
				srcrec = new Rectangle(0, 0, E_Globals.PIC_X, E_Globals.PIC_Y);
				destrec = new Rectangle(ConvertMapX(E_Types.MapItem[itemnum].X * E_Globals.PIC_X), ConvertMapY(E_Types.MapItem[itemnum].Y * E_Globals.PIC_Y), E_Globals.PIC_X, E_Globals.PIC_Y);
			}
			
			x = ConvertMapX(E_Types.MapItem[itemnum].X * E_Globals.PIC_X);
			y = ConvertMapY(E_Types.MapItem[itemnum].Y * E_Globals.PIC_Y);
			
			RenderSprite(ItemsSprite[PicNum], GameWindow, x, y, srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height);
		}
		
		internal static void DrawCharacter(int Sprite, int x2, int y2, Rectangle rec)
		{
			int X = 0;
			int y = 0;
			int width;
			int height;
			try
			{
				
				if (Sprite < 1 || Sprite > NumCharacters)
				{
					return;
				}
				
				if (CharacterGFXInfo[Sprite].IsLoaded == false)
				{
					LoadTexture(Sprite, (byte) 2);
				}
				
				//seeying we still use it, lets update timer
				CharacterGFXInfo[Sprite].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
				
				X = ConvertMapX(x2);
				y = ConvertMapY(y2);
				width = rec.Width;
				height = rec.Height;
				
				RenderSprite(CharacterSprite[Sprite], GameWindow, X, y, rec.X, rec.Y, rec.Width, rec.Height);

            }
            catch
            {

            }
		}
		
		internal static void DrawMapTile(int X, int Y)
		{
			int i = 0;
			Rectangle srcrect = new Rectangle(0, 0, 0, 0);
			
			if (E_Globals.GettingMap)
			{
				return;
			}
			if (E_Globals.MapData == false)
			{
				return;
			}
			
			for (i = (byte)Enums.LayerType.Ground; i <= (byte)Enums.LayerType.Mask2; i++)
			{
				// skip tile if tileset isn't set
				if (E_Types.Map.Tile[X, Y].Layer[i].Tileset > 0 && E_Types.Map.Tile[X, Y].Layer[i].Tileset <= NumTileSets)
				{
					if (TileSetTextureInfo[E_Types.Map.Tile[X, Y].Layer[i].Tileset].IsLoaded == false)
					{
						LoadTexture(System.Convert.ToInt32(E_Types.Map.Tile[X, Y].Layer[i].Tileset), (byte) 1);
					}
					// we use it, lets update timer
					TileSetTextureInfo[i].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
					if (E_AutoTiles.Autotile[X, Y].Layer[i].renderState == E_AutoTiles.RENDER_STATE_NORMAL)
					{
						srcrect.X = System.Convert.ToInt32(E_Types.Map.Tile[X, Y].Layer[i].X * 32);
						srcrect.Y = System.Convert.ToInt32(E_Types.Map.Tile[X, Y].Layer[i].Y * 32);
						srcrect.Width = 32;
						srcrect.Height = 32;
						
						RenderSprite(TileSetSprite[E_Types.Map.Tile[X, Y].Layer[i].Tileset], GameWindow, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y), srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height);
						
					}
					else if (E_AutoTiles.Autotile[X, Y].Layer[i].renderState == E_AutoTiles.RENDER_STATE_AUTOTILE)
					{
						// Draw autotiles
						E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y), 1, X, Y, 0, false);
						E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X) + 16, ConvertMapY(Y * E_Globals.PIC_Y), 2, X, Y, 0, false);
						E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y) + 16, 3, X, Y, 0, false);
						E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X) + 16, ConvertMapY(Y * E_Globals.PIC_Y) + 16, 4, X, Y, 0, false);
					}
				}
			}
			
		}
		
		internal static void DrawMapFringeTile(int X, int Y)
		{
			int i = 0;
			Rectangle srcrect = new Rectangle(0, 0, 0, 0);
			Rectangle dest = new Rectangle(frmMapEditor.Default.PointToScreen(frmMapEditor.Default.picScreen.Location), new Size(32, 32));
			//Dim tmpSprite As Sprite
			
			if (E_Globals.GettingMap)
			{
				return;
			}
			if (E_Globals.MapData == false)
			{
				return;
			}
			
			for (i = (byte)Enums.LayerType.Fringe; i <= (byte)Enums.LayerType.Fringe2; i++)
			{
				// skip tile if tileset isn't set
				if (E_Types.Map.Tile[X, Y].Layer[i].Tileset > 0 && E_Types.Map.Tile[X, Y].Layer[i].Tileset <= NumTileSets)
				{
					if (TileSetTextureInfo[E_Types.Map.Tile[X, Y].Layer[i].Tileset].IsLoaded == false)
					{
						LoadTexture(System.Convert.ToInt32(E_Types.Map.Tile[X, Y].Layer[i].Tileset), (byte) 1);
					}
					
					// we use it, lets update timer
					TileSetTextureInfo[E_Types.Map.Tile[X, Y].Layer[i].Tileset].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
					
					// render
					if (E_AutoTiles.Autotile[X, Y].Layer[i].renderState == E_AutoTiles.RENDER_STATE_NORMAL)
					{
						srcrect.X = System.Convert.ToInt32(E_Types.Map.Tile[X, Y].Layer[i].X * 32);
						srcrect.Y = System.Convert.ToInt32(E_Types.Map.Tile[X, Y].Layer[i].Y * 32);
						srcrect.Width = 32;
						srcrect.Height = 32;
						
						RenderSprite(TileSetSprite[E_Types.Map.Tile[X, Y].Layer[i].Tileset], GameWindow, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y), srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height);
						
					}
					else if (E_AutoTiles.Autotile[X, Y].Layer[i].renderState == E_AutoTiles.RENDER_STATE_AUTOTILE)
					{
						// Draw autotiles
						E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y), 1, X, Y, 0, false);
						E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X) + 16, ConvertMapY(Y * E_Globals.PIC_Y), 2, X, Y, 0, false);
						E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y) + 16, 3, X, Y, 0, false);
						E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X) + 16, ConvertMapY(Y * E_Globals.PIC_Y) + 16, 4, X, Y, 0, false);
					}
				}
			}
			
		}
		
		internal static bool IsValidMapPoint(int X, int Y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (X < 0)
			{
				return returnValue;
			}
			if (Y < 0)
			{
				return returnValue;
			}
			if (X > E_Types.Map.MaxX)
			{
				return returnValue;
			}
			if (Y > E_Types.Map.MaxY)
			{
				return returnValue;
			}
			return true;
		}
		
		//Friend Sub UpdateCamera()
		//    Dim offsetX As Integer, offsetY As Integer
		//    Dim StartX As Integer, StartY As Integer
		//    Dim EndX As Integer, EndY As Integer
		
		//    'offsetX = Player(MyIndex).XOffset + PIC_X
		//    'offsetY = Player(MyIndex).YOffset + PIC_Y
		//    'StartX = GetPlayerX(MyIndex) - ((SCREEN_MAPX + 1) \ 2) - 1
		//    'StartY = GetPlayerY(MyIndex) - ((SCREEN_MAPY + 1) \ 2) - 1
		
		//    If StartX < 0 Then
		//        offsetX = 0
		
		//        'If StartX = -1 Then
		//        '    If Player(MyIndex).XOffset > 0 Then
		//        '        offsetX = Player(MyIndex).XOffset
		//        '    End If
		//        'End If
		
		//        StartX = 0
		//    End If
		
		//    If StartY < 0 Then
		//        offsetY = 0
		
		//        If StartY = -1 Then
		//            'If Player(MyIndex).YOffset > 0 Then
		//            '    offsetY = Player(MyIndex).YOffset
		//            'End If
		//        End If
		
		//        StartY = 0
		//    End If
		
		//    EndX = StartX + (SCREEN_MAPX + 1) + 1
		//    EndY = StartY + (SCREEN_MAPY + 1) + 1
		
		//    If EndX > Map.MaxX Then
		//        offsetX = 32
		
		//        If EndX = Map.MaxX + 1 Then
		//            'If Player(MyIndex).XOffset < 0 Then
		//            '    offsetX = Player(MyIndex).XOffset + PIC_X
		//            'End If
		//        End If
		
		//        EndX = Map.MaxX
		//        StartX = EndX - SCREEN_MAPX - 1
		//    End If
		
		//    If EndY > Map.MaxY Then
		//        offsetY = 32
		
		//        If EndY = Map.MaxY + 1 Then
		//            'If Player(MyIndex).YOffset < 0 Then
		//            '    offsetY = Player(MyIndex).YOffset + PIC_Y
		//            'End If
		//        End If
		
		//        EndY = Map.MaxY
		//        StartY = EndY - SCREEN_MAPY - 1
		//    End If
		
		//    With TileView
		//        .top = StartY
		//        .bottom = EndY
		//        .left = StartX
		//        .right = EndX
		//    End With
		
		//    With Camera
		//        .Y = offsetY
		//        .Height = ScreenY + 32
		//        .X = offsetX
		//        .Width = ScreenX + 32
		//    End With
		
		//    UpdateDrawMapName()
		
		//End Sub
		
		internal static void UpdateCamera()
		{
			
			E_Globals.TileView.Top = E_Globals.EditorViewY;
			E_Globals.TileView.Bottom = E_Types.Map.MaxY;
			E_Globals.TileView.Left = E_Globals.EditorViewX;
			E_Globals.TileView.Right = E_Types.Map.MaxX;
			
			E_Globals.Camera.Y = 0;
			E_Globals.Camera.Height = E_Types.Map.MaxY * 32;
			E_Globals.Camera.X = 0;
			E_Globals.Camera.Width = E_Types.Map.MaxX * 32;
			
			UpdateDrawMapName();
			
		}
		
		public static void ClearGFX()
		{
			
			//clear tilesets
			for (var I = 1; I <= NumTileSets; I++)
			{
				if (TileSetTextureInfo[(int) I].IsLoaded)
				{
					if (TileSetTextureInfo[(int) I].TextureTimer < System.Convert.ToInt32(ClientDataBase.GetTickCount()))
					{
						TileSetTexture[(int) I].Dispose();
						TileSetTextureInfo[(int) I].IsLoaded = false;
						TileSetTextureInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear characters
			for (var I = 1; I <= NumCharacters; I++)
			{
				if (CharacterGFXInfo[(int) I].IsLoaded)
				{
					if (CharacterGFXInfo[(int) I].TextureTimer < System.Convert.ToInt32(ClientDataBase.GetTickCount()))
					{
						CharacterGFX[(int) I].Dispose();
						CharacterGFXInfo[(int) I].IsLoaded = false;
						CharacterGFXInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear paperdoll
			for (var I = 1; I <= NumPaperdolls; I++)
			{
				if (PaperDollGFXInfo[(int) I].IsLoaded)
				{
					if (PaperDollGFXInfo[(int) I].TextureTimer < System.Convert.ToInt32(ClientDataBase.GetTickCount()))
					{
						PaperDollGFX[(int) I].Dispose();
						PaperDollGFXInfo[(int) I].IsLoaded = false;
						PaperDollGFXInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear items
			for (var I = 1; I <= NumItems; I++)
			{
				if (ItemsGFXInfo[(int) I].IsLoaded)
				{
					if (ItemsGFXInfo[(int) I].TextureTimer < System.Convert.ToInt32(ClientDataBase.GetTickCount()))
					{
						ItemsGFX[(int) I].Dispose();
						ItemsGFXInfo[(int) I].IsLoaded = false;
						ItemsGFXInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear resources
			for (var I = 1; I <= NumResources; I++)
			{
				if (ResourcesGFXInfo[(int) I].IsLoaded)
				{
					if (ResourcesGFXInfo[(int) I].TextureTimer < System.Convert.ToInt32(ClientDataBase.GetTickCount()))
					{
						ResourcesGFX[(int) I].Dispose();
						ResourcesGFXInfo[(int) I].IsLoaded = false;
						ResourcesGFXInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear faces
			for (var I = 1; I <= NumFaces; I++)
			{
				if (FacesGFXInfo[(int) I].IsLoaded)
				{
					if (FacesGFXInfo[(int) I].TextureTimer < System.Convert.ToInt32(ClientDataBase.GetTickCount()))
					{
						FacesGFX[(int) I].Dispose();
						FacesGFXInfo[(int) I].IsLoaded = false;
						FacesGFXInfo[(int) I].TextureTimer = 0;
					}
				}
			}
		}
		
		internal static void Render_Graphics()
		{
			int X = 0;
			int Y = 0;
			int I = 0;
			
			//Don't Render IF
			if (E_Globals.GettingMap)
			{
				return;
			}
			
			//lets get going
			
			//update view around player
			UpdateCamera();
			
			//let program do other things
			Application.DoEvents();
			
			frmMapEditor.Default.picScreen.Width = (E_Types.Map.MaxX * E_Globals.PIC_X) + E_Globals.PIC_X;
			frmMapEditor.Default.picScreen.Height = (E_Types.Map.MaxY * E_Globals.PIC_Y) + E_Globals.PIC_Y;
			
			//Clear each of our render targets
			GameWindow.DispatchEvents();
			GameWindow.Clear(SFML.Graphics.Color.Black);
			
			GameWindow.SetView(new SFML.Graphics.View(new FloatRect(0, 0, frmMapEditor.Default.picScreen.Width, frmMapEditor.Default.picScreen.Height)));
			TilesetWindow.SetView(new SFML.Graphics.View(new FloatRect(0, 0, frmMapEditor.Default.picBackSelect.Width, frmMapEditor.Default.picBackSelect.Height)));
			
			//clear any unused gfx
			ClearGFX();
			
			// update animation editor
			//If Editor = EDITOR_ANIMATION Then
			//    EditorAnim_DrawAnim()
			//End If
			
			if (E_Globals.InMapEditor && E_Globals.MapData == true)
			{
				// blit lower tiles
				if (NumTileSets > 0)
				{
					for (X = E_Globals.TileView.Left; X <= E_Globals.TileView.Right + 1; X++)
					{
						for (Y = E_Globals.TileView.Top; Y <= E_Globals.TileView.Bottom + 1; Y++)
						{
							if (IsValidMapPoint(X, Y))
							{
								DrawMapTile(X, Y);
							}
						}
					}
				}
				
				// events
				if (E_Types.Map.CurrentEvents > 0 && E_Types.Map.CurrentEvents <= E_Types.Map.EventCount)
				{
					
					for (I = 1; I <= E_Types.Map.CurrentEvents; I++)
					{
						if (E_Types.Map.MapEvents[I].Position == 0)
						{
							E_EventSystem.DrawEvent(I);
						}
					}
				}
				
				// Draw out the items
				if (NumItems > 0)
				{
					for (I = 1; I <= Constants.MAX_MAP_ITEMS; I++)
					{
						
						if (E_Types.MapItem[I].Num > 0)
						{
							DrawItem(I);
						}
						
					}
				}
				
				//Draw sum d00rs.
				for (X = E_Globals.TileView.Left; X <= E_Globals.TileView.Right; X++)
				{
					for (Y = E_Globals.TileView.Top; Y <= E_Globals.TileView.Bottom; Y++)
					{
						
						if (IsValidMapPoint(X, Y))
						{
							if (E_Types.Map.Tile[X, Y].Type == (byte)Enums.TileType.Door)
							{
								DrawDoor(X, Y);
							}
						}
						
					}
				}
				
				// Y-based render. Renders Players, Npcs and Resources based on Y-axis.
				for (Y = 0; Y <= E_Types.Map.MaxY; Y++)
				{
					
					if (NumCharacters > 0)
					{
						
						// Npcs
						for (I = 1; I <= Constants.MAX_MAP_NPCS; I++)
						{
							if (E_Types.MapNpc[I].Y == Y)
							{
								DrawNpc(I);
							}
						}
						
						// events
						if (E_Types.Map.CurrentEvents > 0 && E_Types.Map.CurrentEvents <= E_Types.Map.EventCount)
						{
							
							for (I = 1; I <= E_Types.Map.CurrentEvents; I++)
							{
								if (E_Types.Map.MapEvents[I].Position == 1)
								{
									if (Y == E_Types.Map.MapEvents[I].Y)
									{
										E_EventSystem.DrawEvent(I);
									}
								}
							}
						}
						
					}
					
					// Resources
					if (NumResources > 0)
					{
						if (E_Globals.Resources_Init)
						{
							if (E_Globals.Resource_index > 0)
							{
								for (I = 1; I <= E_Globals.Resource_index; I++)
								{
									if (E_Globals.MapResource[I].Y == Y)
									{
										DrawMapResource(I);
									}
								}
							}
						}
					}
				}
				
				//events
				if (E_Types.Map.CurrentEvents > 0 && E_Types.Map.CurrentEvents <= E_Types.Map.EventCount)
				{
					
					for (I = 1; I <= E_Types.Map.CurrentEvents; I++)
					{
						if (E_Types.Map.MapEvents[I].Position == 2)
						{
							E_EventSystem.DrawEvent(I);
						}
					}
				}
				
				// blit out upper tiles
				if (NumTileSets > 0)
				{
					for (X = E_Globals.TileView.Left; X <= E_Globals.TileView.Right + 1; X++)
					{
						for (Y = E_Globals.TileView.Top; Y <= E_Globals.TileView.Bottom + 1; Y++)
						{
							if (IsValidMapPoint(X, Y))
							{
								DrawMapFringeTile(X, Y);
							}
						}
					}
				}
				
				E_Weather.DrawWeather();
				E_Weather.DrawThunderEffect();
				DrawMapTint();
				
				// Draw out a square at mouse cursor
				if (E_Globals.MapGrid == true)
				{
					DrawGrid();
				}
				
				if (E_Globals.SelectedTab == 4)
				{
					for (X = E_Globals.TileView.Left; X <= E_Globals.TileView.Right; X++)
					{
						for (Y = E_Globals.TileView.Top; Y <= E_Globals.TileView.Bottom; Y++)
						{
							if (IsValidMapPoint(X, Y))
							{
								DrawDirections(X, Y);
							}
						}
					}
				}
				
				//draw event names
				for (I = 0; I <= E_Types.Map.CurrentEvents; I++)
				{
					if (E_Types.Map.MapEvents[I].Visible == 1)
					{
						if (E_Types.Map.MapEvents[I].ShowName == 1)
						{
							E_Text.DrawEventName(I);
						}
					}
				}
				
				// draw npc names
				for (I = 1; I <= Constants.MAX_MAP_NPCS; I++)
				{
					if (E_Types.MapNpc[I].Num > 0)
					{
						E_Text.DrawNPCName(I);
					}
				}
				
				if (E_Globals.CurrentFog > 0)
				{
					E_Weather.DrawFog();
				}
				
				// Blit out map attributes
				if (E_Globals.InMapEditor)
				{
					E_Text.DrawMapAttributes();
					DrawTileOutline();
				}
				
				if (E_Globals.InMapEditor && E_Globals.SelectedTab == 5)
				{
					E_EventSystem.DrawEvents();
					E_EventSystem.EditorEvent_DrawGraphic();
				}
				
				// Draw map name
				DrawMapName();
			}
			
			//and finally show everything on screen
			GameWindow.Display();
		}
		
		public static void DrawMapName()
		{
			E_Text.DrawText(System.Convert.ToInt32(E_Globals.DrawMapNameX), System.Convert.ToInt32(E_Globals.DrawMapNameY), E_Types.Map.Name, E_Globals.DrawMapNameColor, SFML.Graphics.Color.Black, GameWindow);
		}
		
		internal static void DrawDoor(int X, int Y)
		{
			Rectangle rec = new Rectangle();
			
			int x2;
			int y2;
			
			// sort out animation
			if (E_Types.TempTile[X, Y].DoorAnimate == 1) // opening
			{
				if (E_Types.TempTile[X, Y].DoorTimer + 100 < System.Convert.ToInt32(ClientDataBase.GetTickCount()))
				{
					if (E_Types.TempTile[X, Y].DoorFrame < 4)
					{
						E_Types.TempTile[X, Y].DoorFrame++;
					}
					else
					{
						E_Types.TempTile[X, Y].DoorAnimate = (byte) 2; // set to closing
					}
					E_Types.TempTile[X, Y].DoorTimer = System.Convert.ToInt32(ClientDataBase.GetTickCount());
				}
			}
			else if (E_Types.TempTile[X, Y].DoorAnimate == 2) // closing
			{
				if (E_Types.TempTile[X, Y].DoorTimer + 100 < System.Convert.ToInt32(ClientDataBase.GetTickCount()))
				{
					if (E_Types.TempTile[X, Y].DoorFrame > 1)
					{
						E_Types.TempTile[X, Y].DoorFrame--;
					}
					else
					{
						E_Types.TempTile[X, Y].DoorAnimate = (byte) 0; // end animation
					}
					E_Types.TempTile[X, Y].DoorTimer = System.Convert.ToInt32(ClientDataBase.GetTickCount());
				}
			}
			
			if (E_Types.TempTile[X, Y].DoorFrame == 0)
			{
				E_Types.TempTile[X, Y].DoorFrame = (byte) 1;
			}
			
			rec.Y = 0;
			rec.Height = DoorGFXInfo.height;
			rec.X = System.Convert.ToInt32((E_Types.TempTile[X, Y].DoorFrame - 1) * DoorGFXInfo.width / 4);
			rec.Width = System.Convert.ToInt32((double) DoorGFXInfo.width / 4);
			
			x2 = X * E_Globals.PIC_X;
			y2 = System.Convert.ToInt32((Y * E_Globals.PIC_Y) - ((double) DoorGFXInfo.height / 2) + 4);
			
			RenderSprite(DoorSprite, GameWindow, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y), rec.X, rec.Y, rec.Width, rec.Height);
		}
		
		internal static void DrawTileOutline()
		{
			Rectangle rec = new Rectangle();
			int tileset = 0;
			if (E_Globals.SelectedTab == 4 || E_Globals.HideCursor == true)
			{
				return;
			}
			
			rec.Y = 0;
			rec.Height = E_Globals.PIC_Y;
			rec.X = 0;
			rec.Width = E_Globals.PIC_X;
			
			tileset = frmMapEditor.Default.cmbTileSets.SelectedIndex + 1;
			
			// exit out if doesn't exist
			if (tileset <= 0 || tileset > NumTileSets)
			{
				return;
			}
			
			RectangleShape rec2 = new RectangleShape() {
					OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.Blue),
					OutlineThickness = 0.6F,
					FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
				};
			
			if (E_Globals.SelectedTab == 2)
			{
				//RenderTexture(MiscGFX, GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), rec.X, rec.Y, rec.Width, rec.Height)
				rec2.Size = new Vector2f(rec.Width, rec.Height);
			}
			else
			{
				if (TileSetTextureInfo[frmMapEditor.Default.cmbTileSets.SelectedIndex + 1].IsLoaded == false)
				{
					LoadTexture(frmMapEditor.Default.cmbTileSets.SelectedIndex + 1, (byte) 1);
				}
				// we use it, lets update timer
				TileSetTextureInfo[frmMapEditor.Default.cmbTileSets.SelectedIndex + 1].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
				
				if (E_Globals.EditorTileWidth == 1 && E_Globals.EditorTileHeight == 1)
				{
					RenderSprite(TileSetSprite[frmMapEditor.Default.cmbTileSets.SelectedIndex + 1], GameWindow, ConvertMapX(E_Globals.CurX * E_Globals.PIC_X), ConvertMapY(E_Globals.CurY * E_Globals.PIC_Y), E_Globals.EditorTileSelStart.X * E_Globals.PIC_X, E_Globals.EditorTileSelStart.Y * E_Globals.PIC_Y, rec.Width, rec.Height);
					rec2.Size = new Vector2f(rec.Width, rec.Height);
				}
				else
				{
					if (frmMapEditor.Default.cmbAutoTile.SelectedIndex > 0)
					{
						RenderSprite(TileSetSprite[frmMapEditor.Default.cmbTileSets.SelectedIndex + 1], GameWindow, ConvertMapX(E_Globals.CurX * E_Globals.PIC_X), ConvertMapY(E_Globals.CurY * E_Globals.PIC_Y), E_Globals.EditorTileSelStart.X * E_Globals.PIC_X, E_Globals.EditorTileSelStart.Y * E_Globals.PIC_Y, rec.Width, rec.Height);
						rec2.Size = new Vector2f(rec.Width, rec.Height);
					}
					else
					{
						RenderSprite(TileSetSprite[frmMapEditor.Default.cmbTileSets.SelectedIndex + 1], GameWindow, ConvertMapX(E_Globals.CurX * E_Globals.PIC_X), ConvertMapY(E_Globals.CurY * E_Globals.PIC_Y), E_Globals.EditorTileSelStart.X * E_Globals.PIC_X, E_Globals.EditorTileSelStart.Y * E_Globals.PIC_Y, E_Globals.EditorTileSelEnd.X * E_Globals.PIC_X, E_Globals.EditorTileSelEnd.Y * E_Globals.PIC_Y);
						rec2.Size = new Vector2f(E_Globals.EditorTileSelEnd.X * E_Globals.PIC_X, E_Globals.EditorTileSelEnd.Y * E_Globals.PIC_Y);
					}
					
				}
				
			}
			
			rec2.Position = new Vector2f(ConvertMapX(E_Globals.CurX * E_Globals.PIC_X), ConvertMapY(E_Globals.CurY * E_Globals.PIC_Y));
			GameWindow.Draw(rec2);
		}
		
		internal static void DrawGrid()
		{
			
			RectangleShape rec = new RectangleShape();
			
			for (var x = E_Globals.TileView.Left; x <= E_Globals.TileView.Right; x++) // - 1
			{
				
				for (var y = E_Globals.TileView.Top; y <= E_Globals.TileView.Bottom; y++) // - 1
				{
					
					if (IsValidMapPoint(System.Convert.ToInt32(x), System.Convert.ToInt32(y)))
					{
						
						rec.OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.White);
						rec.OutlineThickness = (float) (0.6F);
						rec.FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent);
						rec.Size = new Vector2f(System.Convert.ToSingle(x * E_Globals.PIC_X), System.Convert.ToSingle(y * E_Globals.PIC_X));
						rec.Position = new Vector2f(ConvertMapX(System.Convert.ToInt32((x - 1) * E_Globals.PIC_X)), ConvertMapY(System.Convert.ToInt32((y - 1) * E_Globals.PIC_Y)));
						
						GameWindow.Draw(rec);
					}
					
				}
				
			}
			
		}
		
		internal static void DrawMapTint()
		{
            //If InMapEditor Then Exit Sub

            return;
            //Needs to be rewritten, HUGE performance hit

			if (E_Types.Map.HasMapTint == 0)
			{
				return;
			}
			
			MapTintSprite = new Sprite(new Texture(new SFML.Graphics.Image((uint) (E_Types.Map.MaxX * E_Globals.PIC_X), (uint) (E_Types.Map.MaxY * E_Globals.PIC_Y), SFML.Graphics.Color.White))) {
					Color = new SFML.Graphics.Color((byte)E_Globals.CurrentTintR, (Byte)E_Globals.CurrentTintG, (Byte)E_Globals.CurrentTintB, (Byte)E_Globals.CurrentTintA),
					TextureRect = new IntRect(0, 0, (E_Types.Map.MaxX * E_Globals.PIC_X) + E_Globals.PIC_X, (E_Types.Map.MaxY * E_Globals.PIC_Y) + E_Globals.PIC_Y),
					Position = new Vector2f(0, 0)
				};
			
			GameWindow.Draw(MapTintSprite);
			
		}
		
		internal static void EditorMap_DrawTileset()
		{
			int height = 0;
			int width = 0;
			byte tileset = 0;
			
			TilesetWindow.DispatchEvents();
			TilesetWindow.Clear(SFML.Graphics.Color.Black);
			
			// find tileset number
			tileset = (byte) (frmMapEditor.Default.cmbTileSets.SelectedIndex + 1);
			
			// exit out if doesn't exist
			if (tileset <= 0 || tileset > NumTileSets)
			{
				return;
			}
			
			RectangleShape rec2 = new RectangleShape() {
					OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.Red),
					OutlineThickness = 0.6F,
					FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
				};
			
			if (TileSetTextureInfo[tileset].IsLoaded == false)
			{
				LoadTexture(tileset, (byte) 1);
			}
			// we use it, lets update timer
			TileSetTextureInfo[tileset].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
			
			height = TileSetTextureInfo[tileset].height;
			width = TileSetTextureInfo[tileset].width;
			frmMapEditor.Default.picBackSelect.Height = height;
			frmMapEditor.Default.picBackSelect.Width = width;
			
			TilesetWindow.SetView(new SFML.Graphics.View(new SFML.Graphics.FloatRect(0, 0, width, height)));
			
			// change selected shape for autotiles
			if (frmMapEditor.Default.cmbAutoTile.SelectedIndex > 0)
			{
				switch (frmMapEditor.Default.cmbAutoTile.SelectedIndex)
				{
					case 1: // autotile
						E_Globals.EditorTileWidth = 2;
						E_Globals.EditorTileHeight = 3;
						break;
					case 2: // fake autotile
						E_Globals.EditorTileWidth = 1;
						E_Globals.EditorTileHeight = 1;
						break;
					case 3: // animated
						E_Globals.EditorTileWidth = 6;
						E_Globals.EditorTileHeight = 3;
						break;
					case 4: // cliff
						E_Globals.EditorTileWidth = 2;
						E_Globals.EditorTileHeight = 2;
						break;
					case 5: // waterfall
						E_Globals.EditorTileWidth = 2;
						E_Globals.EditorTileHeight = 3;
						break;
				}
			}
			
			RenderSprite(TileSetSprite[tileset], TilesetWindow, 0, 0, 0, 0, width, height);
			
			rec2.Size = new Vector2f(E_Globals.EditorTileWidth * E_Globals.PIC_X, E_Globals.EditorTileHeight * E_Globals.PIC_Y);
			
			rec2.Position = new Vector2f(E_Globals.EditorTileSelStart.X * E_Globals.PIC_X, E_Globals.EditorTileSelStart.Y * E_Globals.PIC_Y);
			TilesetWindow.Draw(rec2);
			
			//and finally show everything on screen
			TilesetWindow.Display();
			
			E_Globals.LastTileset = tileset;
		}
		
		public static void DestroyGraphics()
		{
			
			// Number of graphic files
			if (!ReferenceEquals(MapEditorBackBuffer, null))
			{
				MapEditorBackBuffer.Dispose();
			}
			
			for (var i = 0; i <= NumAnimations; i++)
			{
				if (!ReferenceEquals(AnimationsGFX[(int) i], null))
				{
					AnimationsGFX[(int) i].Dispose();
				}
			}
			
			for (var i = 0; i <= NumCharacters; i++)
			{
				if (!ReferenceEquals(CharacterGFX[(int) i], null))
				{
					CharacterGFX[(int) i].Dispose();
				}
			}
			
			for (var i = 0; i <= NumItems; i++)
			{
				if (!ReferenceEquals(ItemsGFX[(int) i], null))
				{
					ItemsGFX[(int) i].Dispose();
				}
			}
			
			for (var i = 0; i <= NumPaperdolls; i++)
			{
				if (!ReferenceEquals(PaperDollGFX[(int) i], null))
				{
					PaperDollGFX[(int) i].Dispose();
				}
			}
			
			for (var i = 0; i <= NumResources; i++)
			{
				if (!ReferenceEquals(ResourcesGFX[(int) i], null))
				{
					ResourcesGFX[(int) i].Dispose();
				}
			}
			
			for (var i = 0; i <= NumSkillIcons; i++)
			{
				if (!ReferenceEquals(SkillIconsGFX[(int) i], null))
				{
					SkillIconsGFX[(int) i].Dispose();
				}
			}
			
			for (var i = 0; i <= NumTileSets; i++)
			{
				//If Not TileSetImgsGFX(i) Is Nothing Then TileSetImgsGFX(i).Dispose()
				if (!ReferenceEquals(TileSetTexture[(int) i], null))
				{
					TileSetTexture[(int) i].Dispose();
				}
			}
			
			for (var i = 0; i <= E_Housing.NumFurniture; i++)
			{
				if (!ReferenceEquals(FurnitureGFX[(int) i], null))
				{
					FurnitureGFX[(int) i].Dispose();
				}
			}
			
			for (var i = 0; i <= NumFaces; i++)
			{
				if (!ReferenceEquals(FacesGFX[(int) i], null))
				{
					FacesGFX[(int) i].Dispose();
				}
			}
			
			for (var i = 0; i <= NumFogs; i++)
			{
				if (!ReferenceEquals(FogGFX[(int) i], null))
				{
					FogGFX[(int) i].Dispose();
				}
			}
			
			if (!ReferenceEquals(DoorGFX, null))
			{
				DoorGFX.Dispose();
			}
			if (!ReferenceEquals(DirectionsGfx, null))
			{
				DirectionsGfx.Dispose();
			}
			if (!ReferenceEquals(WeatherGFX, null))
			{
				WeatherGFX.Dispose();
			}
			
		}
		
		internal static void EditorMap_DrawMapItem()
		{
			int itemnum = 0;
			itemnum = Types.Item[frmMapEditor.Default.scrlMapItem.Value].Pic;
			
			if (itemnum < 1 || itemnum > NumItems)
			{
				frmMapEditor.Default.picMapItem.BackgroundImage = null;
				return;
			}
			
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "items\\" + System.Convert.ToString(itemnum) + E_Globals.GFX_EXT))
			{
				frmMapEditor.Default.picMapItem.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "items\\" + System.Convert.ToString(itemnum) + E_Globals.GFX_EXT);
			}
			
		}
		
		internal static void EditorMap_DrawKey()
		{
			int itemnum = 0;
			
			itemnum = Types.Item[frmMapEditor.Default.scrlMapKey.Value].Pic;
			
			if (itemnum < 1 || itemnum > NumItems)
			{
				frmMapEditor.Default.picMapKey.BackgroundImage = null;
				return;
			}
			
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "items\\" + System.Convert.ToString(itemnum) + E_Globals.GFX_EXT))
			{
				frmMapEditor.Default.picMapKey.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "items\\" + System.Convert.ToString(itemnum) + E_Globals.GFX_EXT);
			}
			
		}
		
		internal static void EditorNpc_DrawSprite()
		{
			int Sprite = 0;
			
			Sprite = (int) frmNPC.Default.nudSprite.Value;
			
			if (Sprite < 1 || Sprite > NumCharacters)
			{
				frmNPC.Default.picSprite.BackgroundImage = null;
				return;
			}
			
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "characters\\" + System.Convert.ToString(Sprite) + E_Globals.GFX_EXT))
			{
				frmNPC.Default.picSprite.Width = System.Convert.ToInt32((double) System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "characters\\" + System.Convert.ToString(Sprite) + E_Globals.GFX_EXT).Width / 4);
				frmNPC.Default.picSprite.Height = System.Convert.ToInt32((double) System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "characters\\" + System.Convert.ToString(Sprite) + E_Globals.GFX_EXT).Height / 4);
				frmNPC.Default.picSprite.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "characters\\" + System.Convert.ToString(Sprite) + E_Globals.GFX_EXT);
			}
		}
		
		internal static void EditorResource_DrawSprite()
		{
			int Sprite = 0;
			
			// normal sprite
			Sprite = (int) FrmResource.Default.nudNormalPic.Value;
			
			if (Sprite < 1 || Sprite > NumResources)
			{
				FrmResource.Default.picNormalpic.BackgroundImage = null;
			}
			else
			{
				if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "resources\\" + System.Convert.ToString(Sprite) + E_Globals.GFX_EXT))
				{
					FrmResource.Default.picNormalpic.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "resources\\" + System.Convert.ToString(Sprite) + E_Globals.GFX_EXT);
				}
			}
			
			// exhausted sprite
			Sprite = (int) FrmResource.Default.nudExhaustedPic.Value;
			
			if (Sprite < 1 || Sprite > NumResources)
			{
				FrmResource.Default.picExhaustedPic.BackgroundImage = null;
			}
			else
			{
				if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "resources\\" + System.Convert.ToString(Sprite) + E_Globals.GFX_EXT))
				{
					FrmResource.Default.picExhaustedPic.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "resources\\" + System.Convert.ToString(Sprite) + E_Globals.GFX_EXT);
				}
			}
		}
		
		internal static void EditorSkill_BltIcon()
		{
			int iconnum = 0;
			Rectangle sRECT = new Rectangle();
			Rectangle dRECT = new Rectangle();
			iconnum = (int) frmSkill.Default.nudIcon.Value;
			
			if (iconnum < 1 || iconnum > NumSkillIcons)
			{
				EditorSkill_Icon.Clear(ToSFMLColor(frmSkill.Default.picSprite.BackColor));
				EditorSkill_Icon.Display();
				return;
			}
			
			if (SkillIconsGFXInfo[iconnum].IsLoaded == false)
			{
				LoadTexture(iconnum, (byte) 9);
			}
			
			//seeying we still use it, lets update timer
			SkillIconsGFXInfo[iconnum].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
			
			sRECT.Y = 0;
			sRECT.Height = E_Globals.PIC_Y;
			sRECT.X = 0;
			sRECT.Width = E_Globals.PIC_X;
			
			//drect is the same, so just copy it
			dRECT = sRECT;
			
			EditorSkill_Icon.Clear(ToSFMLColor(frmSkill.Default.picSprite.BackColor));
			
			RenderSprite(SkillIconsSprite[iconnum], EditorSkill_Icon, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height);
			
			EditorSkill_Icon.Display();
		}
		
		internal static void EditorAnim_DrawAnim()
		{
			int Animationnum = 0;
			Rectangle sRECT = new Rectangle();
			Rectangle dRECT = new Rectangle();
			int width = 0;
			int height = 0;
			int looptime = 0;
			int FrameCount = 0;
			bool ShouldRender = false;
			
			Animationnum = (int) FrmAnimation.Default.nudSprite0.Value;
			
			if (Animationnum < 1 || Animationnum > NumAnimations)
			{
				EditorAnimation_Anim1.Clear(ToSFMLColor(FrmAnimation.Default.picSprite0.BackColor));
				EditorAnimation_Anim1.Display();
			}
			else
			{
				if (AnimationsGFXInfo[Animationnum].IsLoaded == false)
				{
					LoadTexture(Animationnum, (byte) 6);
				}
				
				//seeying we still use it, lets update timer
				AnimationsGFXInfo[Animationnum].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
				
				looptime = (int) FrmAnimation.Default.nudLoopTime0.Value;
				FrameCount = (int) FrmAnimation.Default.nudFrameCount0.Value;
				
				ShouldRender = false;
				
				// check if we need to render new frame
				if (E_Globals.AnimEditorTimer[0] + looptime <= System.Convert.ToInt32(ClientDataBase.GetTickCount()))
				{
					// check if out of range
					if (E_Globals.AnimEditorFrame[0] >= FrameCount)
					{
						E_Globals.AnimEditorFrame[0] = 1;
					}
					else
					{
						E_Globals.AnimEditorFrame[0] = E_Globals.AnimEditorFrame[0] + 1;
					}
					E_Globals.AnimEditorTimer[0] = System.Convert.ToInt32(ClientDataBase.GetTickCount());
					ShouldRender = true;
				}
				
				if (ShouldRender)
				{
					if (FrmAnimation.Default.nudFrameCount0.Value > 0)
					{
						// total width divided by frame count
						height = AnimationsGFXInfo[Animationnum].height;
						width = (int) (AnimationsGFXInfo[Animationnum].width / FrmAnimation.Default.nudFrameCount0.Value);
						
						sRECT.Y = 0;
						sRECT.Height = height;
						sRECT.X = (E_Globals.AnimEditorFrame[0] - 1) * width;
						sRECT.Width = width;
						
						dRECT.Y = 0;
						dRECT.Height = height;
						dRECT.X = 0;
						dRECT.Width = width;
						
						EditorAnimation_Anim1.Clear(ToSFMLColor(FrmAnimation.Default.picSprite0.BackColor));
						
						RenderSprite(AnimationsSprite[Animationnum], EditorAnimation_Anim1, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height);
						
						EditorAnimation_Anim1.Display();
					}
				}
			}
			
			Animationnum = (int) FrmAnimation.Default.nudSprite1.Value;
			
			if (Animationnum < 1 || Animationnum > NumAnimations)
			{
				EditorAnimation_Anim2.Clear(ToSFMLColor(FrmAnimation.Default.picSprite1.BackColor));
				EditorAnimation_Anim2.Display();
			}
			else
			{
				if (AnimationsGFXInfo[Animationnum].IsLoaded == false)
				{
					LoadTexture(Animationnum, (byte) 6);
				}
				
				//seeying we still use it, lets update timer
				AnimationsGFXInfo[Animationnum].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
				
				looptime = (int) FrmAnimation.Default.nudLoopTime1.Value;
				FrameCount = (int) FrmAnimation.Default.nudFrameCount1.Value;
				
				ShouldRender = false;
				
				// check if we need to render new frame
				if (E_Globals.AnimEditorTimer[1] + looptime <= System.Convert.ToInt32(ClientDataBase.GetTickCount()))
				{
					// check if out of range
					if (E_Globals.AnimEditorFrame[1] >= FrameCount)
					{
						E_Globals.AnimEditorFrame[1] = 1;
					}
					else
					{
						E_Globals.AnimEditorFrame[1] = E_Globals.AnimEditorFrame[1] + 1;
					}
					E_Globals.AnimEditorTimer[1] = System.Convert.ToInt32(ClientDataBase.GetTickCount());
					ShouldRender = true;
				}
				
				if (ShouldRender)
				{
					if (FrmAnimation.Default.nudFrameCount1.Value > 0)
					{
						// total width divided by frame count
						height = AnimationsGFXInfo[Animationnum].height;
						width = (int) (AnimationsGFXInfo[Animationnum].width / FrmAnimation.Default.nudFrameCount1.Value);
						
						sRECT.Y = 0;
						sRECT.Height = height;
						sRECT.X = (E_Globals.AnimEditorFrame[1] - 1) * width;
						sRECT.Width = width;
						
						dRECT.Y = 0;
						dRECT.Height = height;
						dRECT.X = 0;
						dRECT.Width = width;
						
						EditorAnimation_Anim2.Clear(ToSFMLColor(FrmAnimation.Default.picSprite1.BackColor));
						
						RenderSprite(AnimationsSprite[Animationnum], EditorAnimation_Anim2, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height);
						EditorAnimation_Anim2.Display();
						
					}
				}
			}
		}
		
		internal static void UpdateDrawMapName()
		{
			Graphics g = Graphics.FromImage(new Bitmap(1, 1));
			int width = 0;
			width = System.Convert.ToInt32(g.MeasureString(E_Types.Map.Name.Trim(), new System.Drawing.Font(E_Globals.FONT_NAME, E_Globals.FONT_SIZE, FontStyle.Bold, GraphicsUnit.Pixel)).Width);
			E_Globals.DrawMapNameX = (float) (((double) (E_Globals.SCREEN_MAPX + 1) * E_Globals.PIC_X / 2) - width + 32);
			E_Globals.DrawMapNameY = 1;
			
			if (E_Types.Map.Moral == (byte)Enums.MapMoralType.None)
			{
				E_Globals.DrawMapNameColor = SFML.Graphics.Color.Red;
			}
			else if (E_Types.Map.Moral == (byte)Enums.MapMoralType.Safe)
			{
				E_Globals.DrawMapNameColor = SFML.Graphics.Color.Green;
			}
			else
			{
				E_Globals.DrawMapNameColor = SFML.Graphics.Color.White;
			}
			g.Dispose();
		}
		
		internal static SFML.Graphics.Color ToSFMLColor(System.Drawing.Color ToConvert)
		{
			return new SFML.Graphics.Color(ToConvert.R, ToConvert.G, ToConvert.G, ToConvert.A);
		}
		
	}
}
