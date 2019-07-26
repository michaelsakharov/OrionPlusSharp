
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SFML.Graphics;
using SFML.Window;
using Engine;


namespace Engine
{
	sealed class C_Graphics
	{
		
#region Declarations
		
		internal static RenderWindow GameWindow;
		internal static RenderWindow TilesetWindow;
		
		internal static SFML.Graphics.Font SfmlGameFont;
		
		internal static Texture CursorGfx;
		internal static Sprite CursorSprite;
		internal static GraphicInfo CursorInfo;
		
		//TileSets
		internal static Texture[] TileSetTexture;
		
		internal static Sprite[] TileSetSprite;
		internal static GraphicInfo[] TileSetTextureInfo;
		
		//Characters
		internal static Texture[] CharacterGfx;
		
		internal static Sprite[] CharacterSprite;
		internal static GraphicInfo[] CharacterGfxInfo;
		
		//Paperdolls
		internal static Texture[] PaperDollGfx;
		
		internal static Sprite[] PaperDollSprite;
		internal static GraphicInfo[] PaperDollGfxInfo;
		
		//Items
		internal static Texture[] ItemsGfx;
		
		internal static Sprite[] ItemsSprite;
		internal static GraphicInfo[] ItemsGfxInfo;
		
		//Resources
		internal static Texture[] ResourcesGfx;
		
		internal static Sprite[] ResourcesSprite;
		internal static GraphicInfo[] ResourcesGfxInfo;
		
		//Animations
		internal static Texture[] AnimationsGfx;
		
		internal static Sprite[] AnimationsSprite;
		internal static GraphicInfo[] AnimationsGfxInfo;
		
		//Skills
		internal static Texture[] SkillIconsGfx;
		
		internal static Sprite[] SkillIconsSprite;
		internal static GraphicInfo[] SkillIconsGfxInfo;
		
		//Housing
		internal static Texture[] FurnitureGfx;
		
		internal static Sprite[] FurnitureSprite;
		internal static GraphicInfo[] FurnitureGfxInfo;
		
		//Faces
		internal static Texture[] FacesGfx;
		
		internal static Sprite[] FacesSprite;
		internal static GraphicInfo[] FacesGfxInfo;
		
		//Projectiles
		internal static Texture[] ProjectileGfx;
		
		internal static Sprite[] ProjectileSprite;
		internal static GraphicInfo[] ProjectileGfxInfo;
		
		//Fogs
		internal static Texture[] FogGfx;
		
		internal static Sprite[] FogSprite;
		internal static GraphicInfo[] FogGfxInfo;
		
		//Emotes
		internal static Texture[] EmotesGfx;
		
		internal static Sprite[] EmotesSprite;
		internal static GraphicInfo[] EmotesGfxInfo;
		
		//Panoramas
		internal static Texture[] PanoramasGfx;
		
		internal static Sprite[] PanoramasSprite;
		internal static GraphicInfo[] PanoramasGfxInfo;
		
		//Parallax
		internal static Texture[] ParallaxGfx;
		
		internal static Sprite[] ParallaxSprite;
		internal static GraphicInfo[] ParallaxGfxInfo;
		
		//Door
		internal static Texture DoorGfx;
		
		internal static Sprite DoorSprite;
		internal static GraphicInfo DoorGfxInfo;
		
		//Blood
		internal static Texture BloodGfx;
		
		internal static Sprite BloodSprite;
		internal static GraphicInfo BloodGfxInfo;
		
		//Directions
		internal static Texture DirectionsGfx;
		
		internal static Sprite DirectionsSprite;
		internal static GraphicInfo DirectionsGfxInfo;
		
		//Weather
		internal static Texture WeatherGfx;
		
		internal static Sprite WeatherSprite;
		internal static GraphicInfo WeatherGfxInfo;
		
		//Hotbar
		internal static Texture HotBarGfx;
		
		internal static Sprite HotBarSprite;
		internal static GraphicInfo HotBarGfxInfo;
		
		//Chat
		internal static Texture ChatWindowGfx;
		
		internal static Sprite ChatWindowSprite;
		internal static GraphicInfo ChatWindowGfxInfo;
		
		//MyChat
		internal static Texture MyChatWindowGfx;
		
		internal static Sprite MyChatWindowSprite;
		internal static GraphicInfo MyChatWindowGfxInfo;
		
		//Buttons
		internal static Texture ButtonGfx;
		
		internal static Sprite ButtonSprite;
		internal static GraphicInfo ButtonGfxInfo;
		internal static Texture ButtonHoverGfx;
		internal static Sprite ButtonHoverSprite;
		internal static GraphicInfo ButtonHoverGfxInfo;
		
		//Hud
		internal static Texture HudPanelGfx;
		
		internal static Sprite HudPanelSprite;
		internal static GraphicInfo HudPanelGfxInfo;
		
		//Bars
		internal static Texture HpBarGfx;
		
		internal static Sprite HpBarSprite;
		internal static GraphicInfo HpBarGfxInfo;
		internal static Texture MpBarGfx;
		internal static Sprite MpBarSprite;
		internal static GraphicInfo MpBarGfxInfo;
		internal static Texture ExpBarGfx;
		internal static Sprite ExpBarSprite;
		internal static GraphicInfo ExpBarGfxInfo;
		
		internal static Texture ActionPanelGfx;
		internal static Sprite ActionPanelSprite;
		internal static GraphicInfo ActionPanelGfxInfo;
		internal static Texture[] ActionPanelButtonsGfx = new Texture[9];
		internal static Sprite[] ActionPanelButtonsSprite = new Sprite[9];
		internal static GraphicInfo[] ActionPanelButtonGfxInfo = new GraphicInfo[9];
		
		internal static Texture InvPanelGfx;
		internal static Sprite InvPanelSprite;
		internal static GraphicInfo InvPanelGfxInfo;
		
		internal static Texture SkillPanelGfx;
		internal static Sprite SkillPanelSprite;
		internal static GraphicInfo SkillPanelGfxInfo;
		
		internal static Texture CharPanelGfx;
		internal static Sprite CharPanelSprite;
		internal static GraphicInfo CharPanelGfxInfo;
		internal static Texture CharPanelPlusGfx;
		internal static Sprite CharPanelPlusSprite;
		internal static GraphicInfo CharPanelPlusGfxInfo;
		internal static Texture CharPanelMinGfx;
		internal static Sprite CharPanelMinSprite;
		internal static GraphicInfo CharPanelMinGfxInfo;
		
		internal static Texture BankPanelGfx;
		internal static Sprite BankPanelSprite;
		internal static GraphicInfo BankPanelGfxInfo;
		
		internal static Texture TradePanelGfx;
		internal static Sprite TradePanelSprite;
		internal static GraphicInfo TradePanelGfxInfo;
		
		internal static Texture ShopPanelGfx;
		internal static Sprite ShopPanelSprite;
		internal static GraphicInfo ShopPanelGfxInfo;
		
		internal static Texture EventChatGfx;
		internal static Sprite EventChatSprite;
		internal static GraphicInfo EventChatGfxInfo;
		
		internal static Texture TargetGfx;
		internal static Sprite TargetSprite;
		internal static GraphicInfo TargetGfxInfo;
		
		internal static Texture DescriptionGfx;
		internal static Sprite DescriptionSprite;
		internal static GraphicInfo DescriptionGfxInfo;
		
		internal static Texture QuestGfx;
		internal static Sprite QuestSprite;
		internal static GraphicInfo QuestGfxInfo;
		
		internal static Texture CraftGfx;
		internal static Sprite CraftSprite;
		internal static GraphicInfo CraftGfxInfo;
		
		internal static Texture ProgBarGfx;
		internal static Sprite ProgBarSprite;
		internal static GraphicInfo ProgBarGfxInfo;
		
		internal static Texture RClickGfx;
		internal static Sprite RClickSprite;
		internal static GraphicInfo RClickGfxInfo;
		
		internal static Texture ChatBubbleGfx;
		internal static Sprite ChatBubbleSprite;
		internal static GraphicInfo ChatBubbleGfxInfo;
		
		internal static Texture PetStatsGfx;
		internal static Sprite PetStatsSprite;
		internal static GraphicInfo PetStatsGfxInfo;
		
		internal static Texture PetBarGfx;
		internal static Sprite PetBarSprite;
		internal static GraphicInfo PetbarGfxInfo;
		
		internal static RenderTexture MapTintGfx = new RenderTexture((uint) 1152, (uint) 864);
		internal static Sprite MapTintSprite;
		
		internal static Sprite MapFadeSprite;
		
		// Number of graphic files
		internal static int NumTileSets;
		
		internal static int NumCharacters;
		internal static int NumPaperdolls;
		internal static int NumItems;
		internal static int NumResources;
		internal static int NumAnimations;
		internal static int NumSkillIcons;
		internal static int NumFaces;
		internal static int NumFogs;
		internal static int NumEmotes;
		internal static int NumPanorama;
		internal static int NumParallax;
		
		// #Day/Night
		internal static RenderTexture NightGfx = new RenderTexture((uint) 1152, (uint) 864);
		
		internal static Sprite NightSprite;
		internal static GraphicInfo NightGfxInfo;
		
		internal static Texture LightGfx;
		internal static Sprite LightSprite;
		internal static GraphicInfo LightGfxInfo;
		
		internal static Texture ShadowGfx;
		internal static Sprite ShadowSprite;
		internal static GraphicInfo ShadowGfxInfo;
		
#endregion
		
#region Types
		
		public struct GraphicInfo
		{
			public int Width;
			public int Height;
			public bool IsLoaded;
			public int TextureTimer;
		}
		
		public struct GraphicsTiles
		{
			public Texture[,] Tile;
		}
		
#endregion
		
#region initialisation
		
		public static void InitGraphics()
		{
			
			GameWindow = new RenderWindow(FrmGame.Default.picscreen.Handle);
			TilesetWindow = new RenderWindow(FrmEditor_MapEditor.Default.picBackSelect.Handle);
			
			SfmlGameFont = new SFML.Graphics.Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\" + C_Constants.FontName);
			
			//this stuff only loads when needed :)
			
			TileSetTexture = new Texture[NumTileSets + 1];
			TileSetSprite = new Sprite[NumTileSets + 1];
			TileSetTextureInfo = new C_Graphics.GraphicInfo[NumTileSets + 1];
			
			CharacterGfx = new Texture[NumCharacters + 1];
			CharacterSprite = new Sprite[NumCharacters + 1];
			CharacterGfxInfo = new C_Graphics.GraphicInfo[NumCharacters + 1];
			
			PaperDollGfx = new Texture[NumPaperdolls + 1];
			PaperDollSprite = new Sprite[NumPaperdolls + 1];
			PaperDollGfxInfo = new C_Graphics.GraphicInfo[NumPaperdolls + 1];
			
			ItemsGfx = new Texture[NumItems + 1];
			ItemsSprite = new Sprite[NumItems + 1];
			ItemsGfxInfo = new C_Graphics.GraphicInfo[NumItems + 1];
			
			ResourcesGfx = new Texture[NumResources + 1];
			ResourcesSprite = new Sprite[NumResources + 1];
			ResourcesGfxInfo = new C_Graphics.GraphicInfo[NumResources + 1];
			
			AnimationsGfx = new Texture[NumAnimations + 1];
			AnimationsSprite = new Sprite[NumAnimations + 1];
			AnimationsGfxInfo = new C_Graphics.GraphicInfo[NumAnimations + 1];
			
			SkillIconsGfx = new Texture[NumSkillIcons + 1];
			SkillIconsSprite = new Sprite[NumSkillIcons + 1];
			SkillIconsGfxInfo = new C_Graphics.GraphicInfo[NumSkillIcons + 1];
			
			FacesGfx = new Texture[NumFaces + 1];
			FacesSprite = new Sprite[NumFaces + 1];
			FacesGfxInfo = new C_Graphics.GraphicInfo[NumFaces + 1];
			
			FurnitureGfx = new Texture[C_Housing.NumFurniture + 1];
			FurnitureSprite = new Sprite[C_Housing.NumFurniture + 1];
			FurnitureGfxInfo = new C_Graphics.GraphicInfo[C_Housing.NumFurniture + 1];
			
			ProjectileGfx = new Texture[C_Projectiles.NumProjectiles + 1];
			ProjectileSprite = new Sprite[C_Projectiles.NumProjectiles + 1];
			ProjectileGfxInfo = new C_Graphics.GraphicInfo[C_Projectiles.NumProjectiles + 1];
			
			FogGfx = new Texture[NumFogs + 1];
			FogSprite = new Sprite[NumFogs + 1];
			FogGfxInfo = new C_Graphics.GraphicInfo[NumFogs + 1];
			
			EmotesGfx = new Texture[NumEmotes + 1];
			EmotesSprite = new Sprite[NumEmotes + 1];
			EmotesGfxInfo = new C_Graphics.GraphicInfo[NumEmotes + 1];
			
			PanoramasGfx = new Texture[NumPanorama + 1];
			PanoramasSprite = new Sprite[NumPanorama + 1];
			PanoramasGfxInfo = new C_Graphics.GraphicInfo[NumPanorama + 1];
			
			ParallaxGfx = new Texture[NumParallax + 1];
			ParallaxSprite = new Sprite[NumParallax + 1];
			ParallaxGfxInfo = new C_Graphics.GraphicInfo[NumParallax + 1];
			
			//sadly, gui shit is always needed, so we preload it :/
			CursorInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Misc\\Cursor" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				CursorGfx = new Texture(Application.StartupPath + C_Constants.GfxPath + "Misc\\Cursor" + C_Constants.GfxExt);
				CursorSprite = new Sprite(CursorGfx);
				
				//Cache the width and height
				CursorInfo.Width = (int)CursorGfx.Size.X;
				CursorInfo.Height = (int)CursorGfx.Size.Y;
			}
			
			DoorGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Misc\\Door" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				DoorGfx = new Texture(Application.StartupPath + C_Constants.GfxPath + "Misc\\Door" + C_Constants.GfxExt);
				DoorSprite = new Sprite(DoorGfx);
				
				//Cache the width and height
				DoorGfxInfo.Width = (int)DoorGfx.Size.X;
				DoorGfxInfo.Height = (int)DoorGfx.Size.Y;
			}
			
			BloodGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Misc\\Blood" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				BloodGfx = new Texture(Application.StartupPath + C_Constants.GfxPath + "Misc\\Blood" + C_Constants.GfxExt);
				BloodSprite = new Sprite(BloodGfx);
				
				//Cache the width and height
				BloodGfxInfo.Width = (int)BloodGfx.Size.X;
				BloodGfxInfo.Height = (int)BloodGfx.Size.Y;
			}
			
			DirectionsGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Misc\\Direction" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				DirectionsGfx = new Texture(Application.StartupPath + C_Constants.GfxPath + "Misc\\Direction" + C_Constants.GfxExt);
				DirectionsSprite = new Sprite(DirectionsGfx);
				
				//Cache the width and height
				DirectionsGfxInfo.Width = (int)DirectionsGfx.Size.X;
				DirectionsGfxInfo.Height = (int)DirectionsGfx.Size.Y;
			}
			
			WeatherGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Misc\\Weather" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				WeatherGfx = new Texture(Application.StartupPath + C_Constants.GfxPath + "Misc\\Weather" + C_Constants.GfxExt);
				WeatherSprite = new Sprite(WeatherGfx);
				
				//Cache the width and height
				WeatherGfxInfo.Width = (int)WeatherGfx.Size.X;
				WeatherGfxInfo.Height = (int)WeatherGfx.Size.Y;
			}
			
			HotBarGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\HotBar" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				HotBarGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\HotBar" + C_Constants.GfxExt);
				HotBarSprite = new Sprite(HotBarGfx);
				
				//Cache the width and height
				HotBarGfxInfo.Width = (int)HotBarGfx.Size.X;
				HotBarGfxInfo.Height = (int)HotBarGfx.Size.Y;
			}
			
			ChatWindowGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "Chat" + C_Constants.GfxExt))
			{
				ChatWindowGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "Chat" + C_Constants.GfxExt);
				ChatWindowSprite = new Sprite(ChatWindowGfx);
				
				//Cache the width and height
				ChatWindowGfxInfo.Width = (int)ChatWindowGfx.Size.X;
				ChatWindowGfxInfo.Height = (int)ChatWindowGfx.Size.Y;
			}
			
			MyChatWindowGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "MyChat" + C_Constants.GfxExt))
			{
				MyChatWindowGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "MyChat" + C_Constants.GfxExt);
				MyChatWindowSprite = new Sprite(MyChatWindowGfx);
				
				//Cache the width and height
				MyChatWindowGfxInfo.Width = (int)MyChatWindowGfx.Size.X;
				MyChatWindowGfxInfo.Height = (int)MyChatWindowGfx.Size.Y;
			}
			
			ButtonGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Button" + C_Constants.GfxExt))
			{
				ButtonGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Button" + C_Constants.GfxExt);
				ButtonSprite = new Sprite(ButtonGfx);
				
				//Cache the width and height
				ButtonGfxInfo.Width = (int)ButtonGfx.Size.X;
				ButtonGfxInfo.Height = (int)ButtonGfx.Size.Y;
			}
			
			ButtonHoverGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Button_Hover" + C_Constants.GfxExt))
			{
				ButtonHoverGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Button_Hover" + C_Constants.GfxExt);
				ButtonHoverSprite = new Sprite(ButtonHoverGfx);
				
				//Cache the width and height
				ButtonHoverGfxInfo.Width = (int)ButtonHoverGfx.Size.X;
				ButtonHoverGfxInfo.Height = (int)ButtonHoverGfx.Size.Y;
			}
			
			HudPanelGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\HUD" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				HudPanelGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\HUD" + C_Constants.GfxExt);
				HudPanelSprite = new Sprite(HudPanelGfx);
				
				//Cache the width and height
				HudPanelGfxInfo.Width = (int)HudPanelGfx.Size.X;
				HudPanelGfxInfo.Height = (int)HudPanelGfx.Size.Y;
			}
			
			HpBarGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "HPBar" + C_Constants.GfxExt))
			{
				HpBarGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "HPBar" + C_Constants.GfxExt);
				HpBarSprite = new Sprite(HpBarGfx);
				
				//Cache the width and height
				HpBarGfxInfo.Width = (int)HpBarGfx.Size.X;
				HpBarGfxInfo.Height = (int)HpBarGfx.Size.Y;
			}
			
			MpBarGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "MPBar" + C_Constants.GfxExt))
			{
				MpBarGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "MPBar" + C_Constants.GfxExt);
				MpBarSprite = new Sprite(MpBarGfx);
				
				//Cache the width and height
				MpBarGfxInfo.Width = (int)MpBarGfx.Size.X;
				MpBarGfxInfo.Height = (int)MpBarGfx.Size.Y;
			}
			
			ExpBarGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "EXPBar" + C_Constants.GfxExt))
			{
				ExpBarGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "EXPBar" + C_Constants.GfxExt);
				ExpBarSprite = new Sprite(ExpBarGfx);
				
				//Cache the width and height
				ExpBarGfxInfo.Width = (int)ExpBarGfx.Size.X;
				ExpBarGfxInfo.Height = (int)ExpBarGfx.Size.Y;
			}
			
			ActionPanelGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "ActionBar\\ActionBar" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				ActionPanelGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "ActionBar\\ActionBar" + C_Constants.GfxExt);
				ActionPanelSprite = new Sprite(ActionPanelGfx);
				
				//Cache the width and height
				ActionPanelGfxInfo.Width = (int)ActionPanelGfx.Size.X;
				ActionPanelGfxInfo.Height = (int)ActionPanelGfx.Size.Y;
			}
			
			InvPanelGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\inventory" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				InvPanelGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\inventory" + C_Constants.GfxExt);
				InvPanelSprite = new Sprite(InvPanelGfx);
				
				//Cache the width and height
				InvPanelGfxInfo.Width = (int)InvPanelGfx.Size.X;
				InvPanelGfxInfo.Height = (int)InvPanelGfx.Size.Y;
			}
			
			SkillPanelGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\skills" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				SkillPanelGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\skills" + C_Constants.GfxExt);
				SkillPanelSprite = new Sprite(SkillPanelGfx);
				
				//Cache the width and height
				SkillPanelGfxInfo.Width = (int)SkillPanelGfx.Size.X;
				SkillPanelGfxInfo.Height = (int)SkillPanelGfx.Size.Y;
			}
			
			CharPanelGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\char" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				CharPanelGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\char" + C_Constants.GfxExt);
				CharPanelSprite = new Sprite(CharPanelGfx);
				
				//Cache the width and height
				CharPanelGfxInfo.Width = (int)CharPanelGfx.Size.X;
				CharPanelGfxInfo.Height = (int)CharPanelGfx.Size.Y;
			}
			
			CharPanelPlusGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\plus" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				CharPanelPlusGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\plus" + C_Constants.GfxExt);
				CharPanelPlusSprite = new Sprite(CharPanelPlusGfx);
				
				//Cache the width and height
				CharPanelPlusGfxInfo.Width = (int)CharPanelPlusGfx.Size.X;
				CharPanelPlusGfxInfo.Height = (int)CharPanelPlusGfx.Size.Y;
			}
			
			CharPanelMinGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\min" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				CharPanelMinGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\min" + C_Constants.GfxExt);
				CharPanelMinSprite = new Sprite(CharPanelMinGfx);
				
				//Cache the width and height
				CharPanelMinGfxInfo.Width = (int)CharPanelMinGfx.Size.X;
				CharPanelMinGfxInfo.Height = (int)CharPanelMinGfx.Size.Y;
			}
			
			BankPanelGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\Bank" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				BankPanelGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\Bank" + C_Constants.GfxExt);
				BankPanelSprite = new Sprite(BankPanelGfx);
				
				//Cache the width and height
				BankPanelGfxInfo.Width = (int)BankPanelGfx.Size.X;
				BankPanelGfxInfo.Height = (int)BankPanelGfx.Size.Y;
			}
			
			ShopPanelGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\Shop" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				ShopPanelGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\Shop" + C_Constants.GfxExt);
				ShopPanelSprite = new Sprite(ShopPanelGfx);
				
				//Cache the width and height
				ShopPanelGfxInfo.Width = (int)ShopPanelGfx.Size.X;
				ShopPanelGfxInfo.Height = (int)ShopPanelGfx.Size.Y;
			}
			
			TradePanelGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\Trade" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				TradePanelGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\Trade" + C_Constants.GfxExt);
				TradePanelSprite = new Sprite(TradePanelGfx);
				
				//Cache the width and height
				TradePanelGfxInfo.Width = (int)TradePanelGfx.Size.X;
				TradePanelGfxInfo.Height = (int)TradePanelGfx.Size.Y;
			}
			
			EventChatGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\EventChat" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				EventChatGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\EventChat" + C_Constants.GfxExt);
				EventChatSprite = new Sprite(EventChatGfx);
				
				//Cache the width and height
				EventChatGfxInfo.Width = (int)EventChatGfx.Size.X;
				EventChatGfxInfo.Height = (int)EventChatGfx.Size.Y;
			}
			
			TargetGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Misc\\Target" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				TargetGfx = new Texture(Application.StartupPath + C_Constants.GfxPath + "Misc\\Target" + C_Constants.GfxExt);
				TargetSprite = new Sprite(TargetGfx);
				
				//Cache the width and height
				TargetGfxInfo.Width = (int)TargetGfx.Size.X;
				TargetGfxInfo.Height = (int)TargetGfx.Size.Y;
			}
			
			DescriptionGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "Description" + C_Constants.GfxExt))
			{
				DescriptionGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "Description" + C_Constants.GfxExt);
				DescriptionSprite = new Sprite(DescriptionGfx);
				
				//Cache the width and height
				DescriptionGfxInfo.Width = (int)DescriptionGfx.Size.X;
				DescriptionGfxInfo.Height = (int)DescriptionGfx.Size.Y;
			}
			
			RClickGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "RightClick" + C_Constants.GfxExt))
			{
				RClickGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "RightClick" + C_Constants.GfxExt);
				RClickSprite = new Sprite(RClickGfx);
				
				//Cache the width and height
				RClickGfxInfo.Width = (int)RClickGfx.Size.X;
				RClickGfxInfo.Height = (int)RClickGfx.Size.Y;
			}
			
			QuestGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "QuestLog" + C_Constants.GfxExt))
			{
				QuestGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "QuestLog" + C_Constants.GfxExt);
				QuestSprite = new Sprite(QuestGfx);
				
				//Cache the width and height
				QuestGfxInfo.Width = (int)QuestGfx.Size.X;
				QuestGfxInfo.Height = (int)QuestGfx.Size.Y;
			}
			
			CraftGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "Craft" + C_Constants.GfxExt))
			{
				CraftGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "Craft" + C_Constants.GfxExt);
				CraftSprite = new Sprite(CraftGfx);
				
				//Cache the width and height
				CraftGfxInfo.Width = (int)CraftGfx.Size.X;
				CraftGfxInfo.Height = (int)CraftGfx.Size.Y;
			}
			
			ProgBarGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "ProgBar" + C_Constants.GfxExt))
			{
				ProgBarGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\" + "ProgBar" + C_Constants.GfxExt);
				ProgBarSprite = new Sprite(ProgBarGfx);
				
				//Cache the width and height
				ProgBarGfxInfo.Width = (int)ProgBarGfx.Size.X;
				ProgBarGfxInfo.Height = (int)ProgBarGfx.Size.Y;
			}
			
			ChatBubbleGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Misc\\ChatBubble" + C_Constants.GfxExt))
			{
				ChatBubbleGfx = new Texture(Application.StartupPath + C_Constants.GfxPath + "Misc\\ChatBubble" + C_Constants.GfxExt);
				ChatBubbleSprite = new Sprite(ChatBubbleGfx);
				//Cache the width and height
				ChatBubbleGfxInfo.Width = (int)ChatBubbleGfx.Size.X;
				ChatBubbleGfxInfo.Height = (int)ChatBubbleGfx.Size.Y;
			}
			
			PetStatsGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\Pet" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				PetStatsGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\Pet" + C_Constants.GfxExt);
				PetStatsSprite = new Sprite(PetStatsGfx);
				
				//Cache the width and height
				PetStatsGfxInfo.Width = (int)PetStatsGfx.Size.X;
				PetStatsGfxInfo.Height = (int)PetStatsGfx.Size.Y;
			}
			
			PetbarGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\Petbar" + C_Constants.GfxExt))
			{
				//Load texture first, dont care about memory streams (just use the filename)
				PetBarGfx = new Texture(Application.StartupPath + C_Constants.GfxGuiPath + "Main\\Petbar" + C_Constants.GfxExt);
				PetBarSprite = new Sprite(PetBarGfx);
				
				//Cache the width and height
				PetbarGfxInfo.Width = (int)PetBarGfx.Size.X;
				PetbarGfxInfo.Height = (int)PetBarGfx.Size.Y;
			}
			
			LightGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Misc\\Light" + C_Constants.GfxExt))
			{
				LightGfx = new Texture(Application.StartupPath + C_Constants.GfxPath + "Misc\\Light" + C_Constants.GfxExt);
				LightSprite = new Sprite(LightGfx);
				
				//Cache the width and height
				LightGfxInfo.Width = (int)LightGfx.Size.X;
				LightGfxInfo.Height = (int)LightGfx.Size.Y;
			}
			
			ShadowGfxInfo = new GraphicInfo();
			if (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Misc\\Shadow" + C_Constants.GfxExt))
			{
				ShadowGfx = new Texture(Application.StartupPath + C_Constants.GfxPath + "Misc\\Shadow" + C_Constants.GfxExt);
				ShadowSprite = new Sprite(ShadowGfx);
				
				//Cache the width and height
				ShadowGfxInfo.Width = (int)ShadowGfx.Size.X;
				ShadowGfxInfo.Height = (int)ShadowGfx.Size.Y;
			}
		}
		
		internal static void LoadTexture(int index, byte texType)
		{
			
			if (texType == 1) //tilesets
			{
				if (index < 0 || index > NumTileSets)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				TileSetTexture[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "tilesets\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				TileSetSprite[index] = new Sprite(TileSetTexture[index]);
				
				//Cache the width and height
				ref var with_1 = ref TileSetTextureInfo[index];
				with_1.Width = (int)TileSetTexture[index].Size.X;
				with_1.Height = (int)TileSetTexture[index].Size.Y;
				with_1.IsLoaded = true;
				with_1.TextureTimer = C_General.GetTickCount() + 100000;
				
			}
			else if (texType == 2) //characters
			{
				if (index < 0 || index > NumCharacters)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				CharacterGfx[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "characters\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				CharacterSprite[index] = new Sprite(CharacterGfx[index]);
				
				//Cache the width and height
				ref var with_2 = ref CharacterGfxInfo[index];
				with_2.Width = (int)CharacterGfx[index].Size.X;
				with_2.Height = (int)CharacterGfx[index].Size.Y;
				with_2.IsLoaded = true;
				with_2.TextureTimer = C_General.GetTickCount() + 100000;
				
			}
			else if (texType == 3) //paperdoll
			{
				if (index < 0 || index > NumPaperdolls)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				PaperDollGfx[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "Paperdolls\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				PaperDollSprite[index] = new Sprite(PaperDollGfx[index]);
				
				//Cache the width and height
				ref var with_3 = ref PaperDollGfxInfo[index];
				with_3.Width = (int)PaperDollGfx[index].Size.X;
				with_3.Height = (int)PaperDollGfx[index].Size.Y;
				with_3.IsLoaded = true;
				with_3.TextureTimer = C_General.GetTickCount() + 100000;
				
			}
			else if (texType == 4) //items
			{
				if (index <= 0 || index > NumItems)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				ItemsGfx[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "items\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				ItemsSprite[index] = new Sprite(ItemsGfx[index]);
				
				//Cache the width and height
				ref var with_4 = ref ItemsGfxInfo[index];
				with_4.Width = (int)ItemsGfx[index].Size.X;
				with_4.Height = (int)ItemsGfx[index].Size.Y;
				with_4.IsLoaded = true;
				with_4.TextureTimer = C_General.GetTickCount() + 100000;
				
			}
			else if (texType == 5) //resources
			{
				if (index < 0 || index > NumResources)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				ResourcesGfx[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "resources\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				ResourcesSprite[index] = new Sprite(ResourcesGfx[index]);
				
				//Cache the width and height
				ref var with_5 = ref ResourcesGfxInfo[index];
				with_5.Width = (int)ResourcesGfx[index].Size.X;
				with_5.Height = (int)ResourcesGfx[index].Size.Y;
				with_5.IsLoaded = true;
				with_5.TextureTimer = C_General.GetTickCount() + 100000;
				
			}
			else if (texType == 6) //animations
			{
				if (index <= 0 || index > NumAnimations)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				AnimationsGfx[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "Animations\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				AnimationsSprite[index] = new Sprite(AnimationsGfx[index]);
				
				//Cache the width and height
				ref var with_6 = ref AnimationsGfxInfo[index];
				with_6.Width = (int)AnimationsGfx[index].Size.X;
				with_6.Height = (int)AnimationsGfx[index].Size.Y;
				with_6.IsLoaded = true;
				with_6.TextureTimer = C_General.GetTickCount() + 100000;
				
			}
			else if (texType == 7) //faces
			{
				if (index < 0 || index > NumFaces)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				FacesGfx[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "Faces\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				FacesSprite[index] = new Sprite(FacesGfx[index]);
				
				//Cache the width and height
				ref var with_7 = ref FacesGfxInfo[index];
				with_7.Width = (int)FacesGfx[index].Size.X;
				with_7.Height = (int)FacesGfx[index].Size.Y;
				with_7.IsLoaded = true;
				with_7.TextureTimer = C_General.GetTickCount() + 100000;
				
			}
			else if (texType == 8) //fogs
			{
				if (index < 0 || index > NumFogs)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				FogGfx[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "Fogs\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				FogSprite[index] = new Sprite(FogGfx[index]);
				
				//Cache the width and height
				ref var with_8 = ref FogGfxInfo[index];
				with_8.Width = (int)FogGfx[index].Size.X;
				with_8.Height = (int)FogGfx[index].Size.Y;
				with_8.IsLoaded = true;
				with_8.TextureTimer = C_General.GetTickCount() + 100000;
				
			}
			else if (texType == 9) //skill icons
			{
				if (index <= 0 || index > NumSkillIcons)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				SkillIconsGfx[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "SkillIcons\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				SkillIconsSprite[index] = new Sprite(SkillIconsGfx[index]);
				
				//Cache the width and height
				ref var with_9 = ref SkillIconsGfxInfo[index];
				with_9.Width = (int)SkillIconsGfx[index].Size.X;
				with_9.Height = (int)SkillIconsGfx[index].Size.Y;
				with_9.IsLoaded = true;
				with_9.TextureTimer = C_General.GetTickCount() + 100000;
				
			}
			else if (texType == 10) //furniture
			{
				if (index < 0 || index > C_Housing.NumFurniture)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				FurnitureGfx[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "Furniture\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				FurnitureSprite[index] = new Sprite(FurnitureGfx[index]);
				
				//Cache the width and height
				ref var with_10 = ref FurnitureGfxInfo[index];
				with_10.Width = (int)FurnitureGfx[index].Size.X;
				with_10.Height = (int)FurnitureGfx[index].Size.Y;
				with_10.IsLoaded = true;
				with_10.TextureTimer = C_General.GetTickCount() + 100000;
				
			}
			else if (texType == 11) //projectiles
			{
				if (index < 0 || index > C_Projectiles.NumProjectiles)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				ProjectileGfx[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "Projectiles\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				ProjectileSprite[index] = new Sprite(ProjectileGfx[index]);
				
				//Cache the width and height
				ref var with_11 = ref ProjectileGfxInfo[index];
				with_11.Width = (int)ProjectileGfx[index].Size.X;
				with_11.Height = (int)ProjectileGfx[index].Size.Y;
				with_11.IsLoaded = true;
				with_11.TextureTimer = C_General.GetTickCount() + 100000;
				
			}
			else if (texType == 12) //emotes
			{
				if (index < 0 || index > NumEmotes)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				EmotesGfx[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "Emotes\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				EmotesSprite[index] = new Sprite(EmotesGfx[index]);
				
				//Cache the width and height
				ref var with_12 = ref EmotesGfxInfo[index];
				with_12.Width = (int)EmotesGfx[index].Size.X;
				with_12.Height = (int)EmotesGfx[index].Size.Y;
				with_12.IsLoaded = true;
				with_12.TextureTimer = C_General.GetTickCount() + 100000;
				
			}
			else if (texType == 13) //Panoramas
			{
				if (index < 0 || index > NumPanorama)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				PanoramasGfx[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "Panoramas\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				PanoramasSprite[index] = new Sprite(PanoramasGfx[index]);
				
				//Cache the width and height
				ref var with_13 = ref PanoramasGfxInfo[index];
				with_13.Width = (int)PanoramasGfx[index].Size.X;
				with_13.Height = (int)PanoramasGfx[index].Size.Y;
				with_13.IsLoaded = true;
				with_13.TextureTimer = C_General.GetTickCount() + 100000;
			}
			else if (texType == 14) //Parallax
			{
				if (index < 0 || index > NumParallax)
				{
					return;
				}
				
				//Load texture first, dont care about memory streams (just use the filename)
				ParallaxGfx[index] = new Texture(Application.StartupPath + C_Constants.GfxPath + "Parallax\\" + System.Convert.ToString(index) + C_Constants.GfxExt);
				ParallaxSprite[index] = new Sprite(ParallaxGfx[index]);
				
				//Cache the width and height
				ref var with_14 = ref ParallaxGfxInfo[index];
				with_14.Width = (int)ParallaxGfx[index].Size.X;
				with_14.Height = (int)ParallaxGfx[index].Size.Y;
				with_14.IsLoaded = true;
				with_14.TextureTimer = C_General.GetTickCount() + 100000;
			}
			
		}
		
#endregion
		
		internal static void DrawEmotes(int x2, int y2, int sprite)
		{
			Rectangle rec = new Rectangle();
			int x = 0;
			int y = 0;
			int anim = 0;
			//Dim width As Integer, height As Integer
			
			if (sprite < 1 || sprite > NumEmotes)
			{
				return;
			}
			
			if (EmotesGfxInfo[sprite].IsLoaded == false)
			{
				LoadTexture(sprite, (byte) 12);
			}
			
			//seeying we still use it, lets update timer
			ref var with_1 = ref EmotesGfxInfo[sprite];
			with_1.TextureTimer = C_General.GetTickCount() + 100000;
			
			if (C_Variables.ShowAnimLayers == true)
			{
				anim = 1;
			}
			else
			{
				anim = 0;
			}
			
			rec.Y = 0;
			rec.Height = C_Constants.PicX;
			rec.X = System.Convert.ToInt32(anim * ((double) EmotesGfxInfo[sprite].Width / 2));
			rec.Width = System.Convert.ToInt32((double) EmotesGfxInfo[sprite].Width / 2);
			
			x = ConvertMapX(x2);
			y = ConvertMapY(y2) - (C_Constants.PicY + 16);
			
			RenderSprite(EmotesSprite[sprite], GameWindow, x, y, rec.X, rec.Y, rec.Width, rec.Height);
			
		}
		
		public static void DrawChat()
		{
			int i = 0;
			int x = 0;
			int y = 0;
			string text = "";
			
			//first draw back image
			RenderSprite(ChatWindowSprite, GameWindow, C_UpdateUI.ChatWindowX, C_UpdateUI.ChatWindowY - 2, 0, 0, ChatWindowGfxInfo.Width, ChatWindowGfxInfo.Height);
			
			y = 5;
			x = 5;
			
			C_Text.FirstLineindex = (C_Types.Chat.Count - C_Text.MaxChatDisplayLines) - C_Text.ScrollMod; //First element is the 5th from the last in the list
			if (C_Text.FirstLineindex < 0)
			{
				C_Text.FirstLineindex = 0; //if the list has less than 5 elements, the first is the 0th index or first element
			}
			
			C_Text.LastLineindex = C_Text.FirstLineindex + C_Text.MaxChatDisplayLines; // - ScrollMod
			if (C_Text.LastLineindex >= C_Types.Chat.Count)
			{
				C_Text.LastLineindex = C_Types.Chat.Count - 1; //Based off of index 0, so the last element should be Chat.Count -1
			}
			
			//only loop tru last entries
			for (i = C_Text.FirstLineindex; i <= C_Text.LastLineindex; i++)
			{
				text = System.Convert.ToString(C_Types.Chat[i].Text);
				
				if (!string.IsNullOrEmpty(text)) // or not
				{
					C_Text.DrawText(C_UpdateUI.ChatWindowX + x, C_UpdateUI.ChatWindowY + y, text, C_Text.GetSfmlColor(System.Convert.ToByte(C_Types.Chat[i].Color)), SFML.Graphics.Color.Black, GameWindow);
					y = y + C_Text.ChatLineSpacing + 1;
				}
				
			}
			
			//My Text
			//first draw back image
			RenderSprite(MyChatWindowSprite, GameWindow, C_UpdateUI.MyChatX, C_UpdateUI.MyChatY - 5, 0, 0, MyChatWindowGfxInfo.Width, MyChatWindowGfxInfo.Height);
			
			if (ChatModule.ChatInput.CurrentMessage.Length > 0)
			{
				string subText = ChatModule.ChatInput.CurrentMessage;
				while (C_Text.GetTextWidth(subText) > MyChatWindowGfxInfo.Width - C_Text.ChatEntryPadding)
				{
					subText = subText.Substring(1);
				}
				C_Text.DrawText(C_UpdateUI.MyChatX + 5, C_UpdateUI.MyChatY - 3, subText, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			}
		}
		
		internal static void DrawButton(string text, int destX, int destY, byte hover)
		{
			if (hover == 0)
			{
				RenderSprite(ButtonSprite, GameWindow, destX, destY, 0, 0, ButtonGfxInfo.Width, ButtonGfxInfo.Height);
				
				C_Text.DrawText(destX + (ButtonGfxInfo.Width / 2) - (C_Text.GetTextWidth(text) / 2), destY + (ButtonGfxInfo.Height / 2) - (C_Constants.FontSize / 2), text, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			}
			else
			{
				RenderSprite(ButtonHoverSprite, GameWindow, destX, destY, 0, 0, ButtonHoverGfxInfo.Width, ButtonHoverGfxInfo.Height);
				
				C_Text.DrawText(destX + (ButtonHoverGfxInfo.Width / 2) - (C_Text.GetTextWidth(text) / 2), destY + (ButtonHoverGfxInfo.Height / 2) - (C_Constants.FontSize / 2), text, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			}
			
		}
		
		internal static void RenderSprite(Sprite tmpSprite, RenderWindow target, int destX, int destY, int sourceX, int sourceY, int sourceWidth, int sourceHeight)
		{
			
			if (ReferenceEquals(tmpSprite, null))
			{
				return;
			}
			
			tmpSprite.TextureRect = new IntRect(sourceX, sourceY, sourceWidth, sourceHeight);
			tmpSprite.Position = new Vector2f(destX, destY);
			target.Draw(tmpSprite);
		}
		
		internal static void RenderTextures(Texture txture, RenderWindow target, float dX, float dY, float sx, float sy, float dWidth, float dHeight, float sWidth, float sHeight)
		{
			Sprite tmpImage = new Sprite(txture);
			tmpImage.TextureRect = new IntRect(System.Convert.ToInt32(sx), System.Convert.ToInt32(sy), System.Convert.ToInt32(sWidth), System.Convert.ToInt32(sHeight));
			tmpImage.Scale = new Vector2f(dWidth / sWidth, dHeight / sHeight);
			tmpImage.Position = new Vector2f(dX, dY);
			target.Draw(tmpImage);
		}
		
		internal static void DrawDirections(int x, int y)
		{
			Rectangle rec = new Rectangle();
			
			// render grid
			rec.Y = 24;
			rec.X = 0;
			rec.Width = 32;
			rec.Height = 32;
			
			RenderSprite(DirectionsSprite, GameWindow, ConvertMapX(x * C_Constants.PicX), ConvertMapY(y * C_Constants.PicY), rec.X, rec.Y, rec.Width, rec.Height);
			
			// render dir blobs
			for (byte i = 1; i <= 4; i++)
			{
				rec.X = (i - 1) * 8;
				rec.Width = 8;
				// find out whether render blocked or not
				if (!C_GameLogic.IsDirBlocked(C_Maps.Map.Tile[x, y].DirBlock, i))
				{
					rec.Y = 8;
				}
				else
				{
					rec.Y = 16;
				}
				rec.Height = 8;
				
				RenderSprite(DirectionsSprite, GameWindow, ConvertMapX(x * C_Constants.PicX) + C_Variables.DirArrowX[i], ConvertMapY(y * C_Constants.PicY) + C_Variables.DirArrowY[i], rec.X, rec.Y, rec.Width, rec.Height);
			}
		}
		
		internal static int ConvertMapX(int x)
		{
			return x - (C_Variables.TileView.Left * C_Constants.PicX) - C_Variables.Camera.Left;
		}
		
		internal static int ConvertMapY(int y)
		{
			return y - (C_Variables.TileView.Top * C_Constants.PicY) - C_Variables.Camera.Top;
		}
		
		internal static void DrawPlayer(int index)
		{
			byte anim = 0;
			int x = 0;
			int y = 0;
			int spritenum = 0;
			int spriteleft = 0;
			int attackspeed = 0;
			byte attackSprite;
			Rectangle srcrec = new Rectangle();
			
			spritenum = C_Player.GetPlayerSprite(index);
			
			attackSprite = (byte) 0;
			
			if (spritenum < 1 || spritenum > NumCharacters)
			{
				return;
			}
			
			// speed from weapon
			if (C_Player.GetPlayerEquipment(index, Enums.EquipmentType.Weapon) > 0)
			{
				attackspeed = Types.Item[C_Player.GetPlayerEquipment(index, Enums.EquipmentType.Weapon)].Speed;
			}
			else
			{
				attackspeed = 1000;
			}
			
			// Reset frame
			anim = (byte) 0;
			
			// Check for attacking animation
			if (C_Types.Player[index].AttackTimer + ((double) attackspeed / 2) > C_General.GetTickCount())
			{
				if (C_Types.Player[index].Attacking == 1)
				{
					if (attackSprite == 1)
					{
						anim = (byte) 4;
					}
					else
					{
						anim = (byte) 3;
					}
				}
			}
			else
			{
				// If not attacking, walk normally
				switch (C_Player.GetPlayerDir(index))
				{
					case (int) Enums.DirectionType.Up:
						
						if (C_Types.Player[index].YOffset > 8)
						{
							anim = C_Types.Player[index].Steps;
						}
						break;
					case (int) Enums.DirectionType.Down:
						
						if (C_Types.Player[index].YOffset < -8)
						{
							anim = C_Types.Player[index].Steps;
						}
						break;
					case (int) Enums.DirectionType.Left:
						
						if (C_Types.Player[index].XOffset > 8)
						{
							anim = C_Types.Player[index].Steps;
						}
						break;
					case (int) Enums.DirectionType.Right:
						
						if (C_Types.Player[index].XOffset < -8)
						{
							anim = C_Types.Player[index].Steps;
						}
						break;
				}
				
			}
			
			// Check to see if we want to stop making him attack
			ref var with_1 = ref C_Types.Player[index];
			if (with_1.AttackTimer + attackspeed < C_General.GetTickCount())
			{
				with_1.Attacking = (byte) 0;
				with_1.AttackTimer = 0;
			}
			
			
			// Set the left
			switch (C_Player.GetPlayerDir(index))
			{
				case (int) Enums.DirectionType.Up:
					spriteleft = 3;
					break;
				case (int) Enums.DirectionType.Right:
					spriteleft = 2;
					break;
				case (int) Enums.DirectionType.Down:
					spriteleft = 0;
					break;
				case (int) Enums.DirectionType.Left:
					spriteleft = 1;
					break;
			}
			
			if (attackSprite == 1)
			{
				srcrec = new Rectangle(System.Convert.ToInt32((anim) * ((double) CharacterGfxInfo[spritenum].Width / 5)), System.Convert.ToInt32(spriteleft * ((double) CharacterGfxInfo[spritenum].Height / 4)), System.Convert.ToInt32((double) CharacterGfxInfo[spritenum].Width / 5), System.Convert.ToInt32((double) CharacterGfxInfo[spritenum].Height / 4));
			}
			else
			{
				srcrec = new Rectangle(System.Convert.ToInt32((anim) * ((double) CharacterGfxInfo[spritenum].Width / 4)), System.Convert.ToInt32(spriteleft * ((double) CharacterGfxInfo[spritenum].Height / 4)), System.Convert.ToInt32((double) CharacterGfxInfo[spritenum].Width / 4), System.Convert.ToInt32((double) CharacterGfxInfo[spritenum].Height / 4));
			}
			
			// Calculate the X
			if (attackSprite == 1)
			{
				x = System.Convert.ToInt32(C_Player.GetPlayerX(index) * C_Constants.PicX + C_Types.Player[index].XOffset - (((double) CharacterGfxInfo[spritenum].Width / 5 - 32) / 2));
			}
			else
			{
				x = System.Convert.ToInt32(C_Player.GetPlayerX(index) * C_Constants.PicX + C_Types.Player[index].XOffset - (((double) CharacterGfxInfo[spritenum].Width / 4 - 32) / 2));
			}
			
			// Is the player's height more than 32..
			if ((CharacterGfxInfo[spritenum].Height) > 32)
			{
				// Create a 32 pixel offset for larger sprites
				y = System.Convert.ToInt32(C_Player.GetPlayerY(index) * C_Constants.PicY + C_Types.Player[index].YOffset - (((double) CharacterGfxInfo[spritenum].Height / 4) - 32));
			}
			else
			{
				// Proceed as normal
				y = C_Player.GetPlayerY(index) * C_Constants.PicY + C_Types.Player[index].YOffset;
			}
			
			// render the actual sprite
			DrawCharacter(spritenum, x, y, srcrec);
			
			//check for paperdolling
			for (var i = 1; i <= (int) Enums.EquipmentType.Count - 1; i++)
			{
				if (C_Player.GetPlayerEquipment(index, (Enums.EquipmentType)i) > 0)
				{
					if (Types.Item[C_Player.GetPlayerEquipment(index, (Enums.EquipmentType)i)].Paperdoll > 0)
					{
						DrawPaperdoll(x, y, Types.Item[C_Player.GetPlayerEquipment(index, (Enums.EquipmentType)i)].Paperdoll, anim, spriteleft);
					}
				}
			}
			
			// Check to see if we want to stop showing emote
			ref var with_2 = ref C_Types.Player[index];
			if (with_2.EmoteTimer < C_General.GetTickCount())
			{
				with_2.Emote = 0;
				with_2.EmoteTimer = 0;
			}
			
			//check for emotes
			//Player(Index).Emote = 4
			if (C_Types.Player[index].Emote > 0)
			{
				DrawEmotes(x, y, C_Types.Player[index].Emote);
			}
		}
		
		internal static void DrawPaperdoll(int x2, int y2, int sprite, int anim, int spritetop)
		{
			Rectangle rec = new Rectangle();
			int x = 0;
			int y = 0;
			int width;
			int height;
			
			if (sprite < 1 || sprite > NumPaperdolls)
			{
				return;
			}
			
			if (PaperDollGfxInfo[sprite].IsLoaded == false)
			{
				LoadTexture(sprite, (byte) 3);
			}
			
			// we use it, lets update timer
			ref var with_1 = ref PaperDollGfxInfo[sprite];
			with_1.TextureTimer = C_General.GetTickCount() + 100000;
			
			rec.Y = System.Convert.ToInt32(spritetop * ((double) PaperDollGfxInfo[sprite].Height / 4));
			rec.Height = System.Convert.ToInt32((double) PaperDollGfxInfo[sprite].Height / 4);
			rec.X = System.Convert.ToInt32(anim * ((double) PaperDollGfxInfo[sprite].Width / 4));
			rec.Width = System.Convert.ToInt32((double) PaperDollGfxInfo[sprite].Width / 4);
			
			x = ConvertMapX(x2);
			y = ConvertMapY(y2);
			width = rec.Right - rec.Left;
			height = rec.Bottom - rec.Top;
			
			RenderSprite(PaperDollSprite[sprite], GameWindow, x, y, rec.X, rec.Y, rec.Width, rec.Height);
			
		}
		
		internal static void DrawNpc(int mapNpcNum)
		{
			byte anim = 0;
			int x = 0;
			int y = 0;
			int sprite = 0;
			int spriteleft = 0;
			Rectangle destrec;
			Rectangle srcrec = new Rectangle();
			int attackspeed = 0;
			
			if (C_Maps.MapNpc[mapNpcNum].Num == 0)
			{
				return; // no npc set
			}
			
			if (C_Maps.MapNpc[mapNpcNum].X < C_Variables.TileView.Left || C_Maps.MapNpc[mapNpcNum].X > C_Variables.TileView.Right)
			{
				return;
			}
			if (C_Maps.MapNpc[mapNpcNum].Y < C_Variables.TileView.Top || C_Maps.MapNpc[mapNpcNum].Y > C_Variables.TileView.Bottom)
			{
				return;
			}
			
			sprite = Types.Npc[C_Maps.MapNpc[mapNpcNum].Num].Sprite;
			
			if (sprite < 1 || sprite > NumCharacters)
			{
				return;
			}
			
			attackspeed = 1000;
			
			// Reset frame
			anim = (byte) 0;
			
			// Check for attacking animation
			if (C_Maps.MapNpc[mapNpcNum].AttackTimer + ((double) attackspeed / 2) > C_General.GetTickCount())
			{
				if (C_Maps.MapNpc[mapNpcNum].Attacking == 1)
				{
					anim = (byte) 3;
				}
			}
			else
			{
				// If not attacking, walk normally
				if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Up)
				{
					if (C_Maps.MapNpc[mapNpcNum].YOffset > 8)
					{
						anim = (byte) (C_Maps.MapNpc[mapNpcNum].Steps);
					}
				}
				else if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Down)
				{
					if (C_Maps.MapNpc[mapNpcNum].YOffset < -8)
					{
						anim = (byte) (C_Maps.MapNpc[mapNpcNum].Steps);
					}
				}
				else if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Left)
				{
					if (C_Maps.MapNpc[mapNpcNum].XOffset > 8)
					{
						anim = (byte) (C_Maps.MapNpc[mapNpcNum].Steps);
					}
				}
				else if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Right)
				{
					if (C_Maps.MapNpc[mapNpcNum].XOffset < -8)
					{
						anim = (byte) (C_Maps.MapNpc[mapNpcNum].Steps);
					}
				}
			}
			
			// Check to see if we want to stop making him attack
			ref var with_1 = ref C_Maps.MapNpc[mapNpcNum];
			if (System.Convert.ToInt32(with_1.AttackTimer + attackspeed) < C_General.GetTickCount())
			{
				with_1.Attacking = 0;
				with_1.AttackTimer = 0;
			}
			
			// Set the left
			if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Up)
			{
				spriteleft = 3;
			}
			else if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Right)
			{
				spriteleft = 2;
			}
			else if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Down)
			{
				spriteleft = 0;
			}
			else if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Left)
			{
				spriteleft = 1;
			}
			
			srcrec = new Rectangle(System.Convert.ToInt32((anim) * ((double) CharacterGfxInfo[sprite].Width / 4)), System.Convert.ToInt32(spriteleft * ((double) CharacterGfxInfo[sprite].Height / 4)), System.Convert.ToInt32((double) CharacterGfxInfo[sprite].Width / 4), System.Convert.ToInt32((double) CharacterGfxInfo[sprite].Height / 4));
			
			// Calculate the X
			x = System.Convert.ToInt32(C_Maps.MapNpc[mapNpcNum].X * C_Constants.PicX + C_Maps.MapNpc[mapNpcNum].XOffset - (((double) CharacterGfxInfo[sprite].Width / 4 - 32) / 2));
			
			// Is the player's height more than 32..
			if (((double) CharacterGfxInfo[sprite].Height / 4) > 32)
			{
				// Create a 32 pixel offset for larger sprites
				y = System.Convert.ToInt32(C_Maps.MapNpc[mapNpcNum].Y * C_Constants.PicY + C_Maps.MapNpc[mapNpcNum].YOffset - (((double) CharacterGfxInfo[sprite].Height / 4) - 32));
			}
			else
			{
				// Proceed as normal
				y = C_Maps.MapNpc[mapNpcNum].Y * C_Constants.PicY + C_Maps.MapNpc[mapNpcNum].YOffset;
			}
			
			destrec = new Rectangle(x, y, System.Convert.ToInt32((double) CharacterGfxInfo[sprite].Width / 4), System.Convert.ToInt32((double) CharacterGfxInfo[sprite].Height / 4));
			
			DrawCharacter(sprite, x, y, srcrec);
			
			if (Types.Npc[C_Maps.MapNpc[mapNpcNum].Num].Behaviour == (byte)Enums.NpcBehavior.Quest)
			{
				if (C_Quest.CanStartQuest(Types.Npc[C_Maps.MapNpc[mapNpcNum].Num].QuestNum))
				{
					if (C_Types.Player[C_Variables.Myindex].PlayerQuest[Types.Npc[C_Maps.MapNpc[mapNpcNum].Num].QuestNum].Status == (int) Enums.QuestStatusType.NotStarted)
					{
						DrawEmotes(x, y, 5);
					}
				}
				else if (C_Types.Player[C_Variables.Myindex].PlayerQuest[Types.Npc[C_Maps.MapNpc[mapNpcNum].Num].QuestNum].Status == (int) Enums.QuestStatusType.Started)
				{
					DrawEmotes(x, y, 9);
				}
			}
			
		}
		
		internal static void DrawItem(int itemnum)
		{
			Rectangle srcrec = new Rectangle();
			Rectangle destrec;
			int picNum = 0;
			int x = 0;
			int y = 0;
			
			picNum = Types.Item[C_Maps.MapItem[itemnum].Num].Pic;
			
			if (picNum < 1 || picNum > NumItems)
			{
				return;
			}
			
			if (ItemsGfxInfo[picNum].IsLoaded == false)
			{
				LoadTexture(picNum, (byte) 4);
			}
			
			//seeying we still use it, lets update timer
			ref var with_1 = ref ItemsGfxInfo[picNum];
			with_1.TextureTimer = C_General.GetTickCount() + 100000;
			
			ref var with_2 = ref C_Maps.MapItem[itemnum];
			if (with_2.X < C_Variables.TileView.Left || with_2.X > C_Variables.TileView.Right)
			{
				return;
			}
			if (with_2.Y < C_Variables.TileView.Top || with_2.Y > C_Variables.TileView.Bottom)
			{
				return;
			}
			
			if (ItemsGfxInfo[picNum].Width > 32) // has more than 1 frame
			{
				srcrec = new Rectangle(C_Maps.MapItem[itemnum].Frame * 32, 0, 32, 32);
				destrec = new Rectangle(ConvertMapX(C_Maps.MapItem[itemnum].X * C_Constants.PicX), ConvertMapY(C_Maps.MapItem[itemnum].Y * C_Constants.PicY), 32, 32);
			}
			else
			{
				srcrec = new Rectangle(0, 0, C_Constants.PicX, C_Constants.PicY);
				destrec = new Rectangle(ConvertMapX(C_Maps.MapItem[itemnum].X * C_Constants.PicX), ConvertMapY(C_Maps.MapItem[itemnum].Y * C_Constants.PicY), C_Constants.PicX, C_Constants.PicY);
			}
			
			x = ConvertMapX(C_Maps.MapItem[itemnum].X * C_Constants.PicX);
			y = ConvertMapY(C_Maps.MapItem[itemnum].Y * C_Constants.PicY);
			
			RenderSprite(ItemsSprite[picNum], GameWindow, x, y, srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height);
			
		}
		
		internal static void DrawCharacter(int sprite, int x2, int y2, Rectangle rec)
		{
			int x = 0;
			int y = 0;
			int width;
			int height;
			//On Error Resume Next
			
			if (sprite < 1 || sprite > NumCharacters)
			{
				return;
			}
			
			if (CharacterGfxInfo[sprite].IsLoaded == false)
			{
				LoadTexture(sprite, (byte) 2);
			}
			
			//seeying we still use it, lets update timer
			ref var with_1 = ref CharacterGfxInfo[sprite];
			with_1.TextureTimer = C_General.GetTickCount() + 100000;
			
			x = ConvertMapX(x2);
			y = ConvertMapY(y2);
			width = rec.Width;
			height = rec.Height;
			
			//shadow first
			RenderSprite(ShadowSprite, GameWindow, x - 1, y + 6, 0, 0, ShadowGfxInfo.Width, ShadowGfxInfo.Height);
			
			RenderSprite(CharacterSprite[sprite], GameWindow, x, y, rec.X, rec.Y, rec.Width, rec.Height);
			
		}
		
		internal static void DrawBlood(int index)
		{
            Point dest = new Point((Size)FrmGame.Default.PointToScreen(FrmGame.Default.picscreen.Location));

            Rectangle srcrec = new Rectangle();
			Rectangle destrec;
			int x = 0;
			int y = 0;
			
			ref var with_1 = ref C_Types.Blood[index];
			if (with_1.X < C_Variables.TileView.Left || with_1.X > C_Variables.TileView.Right)
			{
				return;
			}
			if (with_1.Y < C_Variables.TileView.Top || with_1.Y > C_Variables.TileView.Bottom)
			{
				return;
			}
			
			// check if we should be seeing it
			if (with_1.Timer + 20000 < C_General.GetTickCount())
			{
				return;
			}
			
			x = ConvertMapX(C_Types.Blood[index].X * C_Constants.PicX);
			y = ConvertMapY(C_Types.Blood[index].Y * C_Constants.PicY);
			
			srcrec = new Rectangle((with_1.Sprite - 1) * C_Constants.PicX, 0, C_Constants.PicX, C_Constants.PicY);
			
			destrec = new Rectangle(ConvertMapX(with_1.X * C_Constants.PicX), ConvertMapY(with_1.Y * C_Constants.PicY), C_Constants.PicX, C_Constants.PicY);
			
			RenderSprite(BloodSprite, GameWindow, x, y, srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height);
			
			
		}
		
		internal static bool IsValidMapPoint(int x, int y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x < 0)
			{
				return returnValue;
			}
			if (y < 0)
			{
				return returnValue;
			}
			if (x > C_Maps.Map.MaxX)
			{
				return returnValue;
			}
			if (y > C_Maps.Map.MaxY)
			{
				return returnValue;
			}
			return true;
		}
		
		internal static void UpdateCamera()
		{
			int offsetX = 0;
			int offsetY = 0;
			int startX = 0;
			int startY = 0;
			int endX = 0;
			int endY = 0;
			
			offsetX = C_Types.Player[C_Variables.Myindex].XOffset + C_Constants.PicX;
			offsetY = C_Types.Player[C_Variables.Myindex].YOffset + C_Constants.PicY;


			startX = System.Convert.ToInt32(C_Player.GetPlayerX(C_Variables.Myindex) - ((C_Constants.ScreenMapx + 1) / 2) - 1);
			startY = System.Convert.ToInt32(C_Player.GetPlayerY(C_Variables.Myindex) - ((C_Constants.ScreenMapy + 1) / 2) - 1);
			

            //Uncomment this to Lock camera to inside Map Borders
			//if (startX < 0)
			//{
			//	offsetX = 0;
			//	
			//	if (startX == -1)
			//	{
			//		if (C_Types.Player[C_Variables.Myindex].XOffset > 0)
			//		{
			//			offsetX = C_Types.Player[C_Variables.Myindex].XOffset;
			//		}
			//	}
			//	
			//	startX = 0;
			//}
			
			//if (startY < 0)
			//{
			//	offsetY = 0;
			//	
			//	if (startY == -1)
			//	{
			//		if (C_Types.Player[C_Variables.Myindex].YOffset > 0)
			//		{
			//			offsetY = C_Types.Player[C_Variables.Myindex].YOffset;
			//		}
			//	}
			//	
			//	startY = 0;
			//}
			
			endX = startX + (C_Constants.ScreenMapx + 1) + 1;
			endY = startY + (C_Constants.ScreenMapy + 1) + 1;

            //Uncomment this to Lock camera to inside Map Borders
            //if (endX > C_Maps.Map.MaxX)
            //{
            //	offsetX = 32;
            //	
            //	if (endX == C_Maps.Map.MaxX + 1)
            //	{
            //		if (C_Types.Player[C_Variables.Myindex].XOffset < 0)
            //		{
            //			offsetX = C_Types.Player[C_Variables.Myindex].XOffset + C_Constants.PicX;
            //		}
            //	}
            //	
            //	endX = C_Maps.Map.MaxX;
            //	startX = endX - C_Constants.ScreenMapx - 1;
            //}

            //if (endY > C_Maps.Map.MaxY)
            //{
            //	offsetY = 32;
            //	
            //	if (endY == C_Maps.Map.MaxY + 1)
            //	{
            //		if (C_Types.Player[C_Variables.Myindex].YOffset < 0)
            //		{
            //			offsetY = C_Types.Player[C_Variables.Myindex].YOffset + C_Constants.PicY;
            //		}
            //	}
            //	
            //	endY = C_Maps.Map.MaxY;
            //	startY = endY - C_Constants.ScreenMapy - 1;
            //}

            C_Variables.TileView.Top = startY;
			C_Variables.TileView.Bottom = endY;
			C_Variables.TileView.Left = startX;
			C_Variables.TileView.Right = endX;
			
			C_Variables.Camera.Y = offsetY;
			C_Variables.Camera.Height = C_Constants.ScreenY + 32;
			C_Variables.Camera.X = offsetX;
			C_Variables.Camera.Width = C_Constants.ScreenX + 32;
			
			C_GameLogic.UpdateDrawMapName();
			
		}
		
		public static void ClearGfx()
		{
			
			//clear tilesets
			for (var I = 1; I <= NumTileSets; I++)
			{
				if (TileSetTextureInfo[(int) I].IsLoaded)
				{
					if (TileSetTextureInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						TileSetTexture[(int) I].Dispose();
						TileSetSprite[(int) I].Dispose();
						TileSetTextureInfo[(int) I].IsLoaded = false;
						TileSetTextureInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear characters
			for (var I = 1; I <= NumCharacters; I++)
			{
				if (CharacterGfxInfo[(int) I].IsLoaded)
				{
					if (CharacterGfxInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						CharacterGfx[(int) I].Dispose();
						CharacterSprite[(int) I].Dispose();
						CharacterGfxInfo[(int) I].IsLoaded = false;
						CharacterGfxInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear paperdoll
			for (var I = 1; I <= NumPaperdolls; I++)
			{
				if (PaperDollGfxInfo[(int) I].IsLoaded)
				{
					if (PaperDollGfxInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						PaperDollGfx[(int) I].Dispose();
						PaperDollSprite[(int) I].Dispose();
						PaperDollGfxInfo[(int) I].IsLoaded = false;
						PaperDollGfxInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear items
			for (var I = 1; I <= NumItems; I++)
			{
				if (ItemsGfxInfo[(int) I].IsLoaded)
				{
					if (ItemsGfxInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						ItemsGfx[(int) I].Dispose();
						ItemsSprite[(int) I].Dispose();
						ItemsGfxInfo[(int) I].IsLoaded = false;
						ItemsGfxInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear resources
			for (var I = 1; I <= NumResources; I++)
			{
				if (ResourcesGfxInfo[(int) I].IsLoaded)
				{
					if (ResourcesGfxInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						ResourcesGfx[(int) I].Dispose();
						ResourcesSprite[(int) I].Dispose();
						ResourcesGfxInfo[(int) I].IsLoaded = false;
						ResourcesGfxInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//animations
			for (var I = 1; I <= NumAnimations; I++)
			{
				if (AnimationsGfxInfo[(int) I].IsLoaded)
				{
					if (AnimationsGfxInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						AnimationsGfx[(int) I].Dispose();
						AnimationsGfxInfo[(int) I].IsLoaded = false;
						AnimationsGfxInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear faces
			for (var I = 1; I <= NumFaces; I++)
			{
				if (FacesGfxInfo[(int) I].IsLoaded)
				{
					if (FacesGfxInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						FacesGfx[(int) I].Dispose();
						FacesSprite[(int) I].Dispose();
						FacesGfxInfo[(int) I].IsLoaded = false;
						FacesGfxInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear fogs
			for (var I = 1; I <= NumFogs; I++)
			{
				if (FogGfxInfo[(int) I].IsLoaded)
				{
					if (FogGfxInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						FogGfx[(int) I].Dispose();
						FogGfxInfo[(int) I].IsLoaded = false;
						FogGfxInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear SkillIcons
			for (var I = 1; I <= NumSkillIcons; I++)
			{
				if (SkillIconsGfxInfo[(int) I].IsLoaded)
				{
					if (SkillIconsGfxInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						SkillIconsGfx[(int) I].Dispose();
						SkillIconsSprite[(int) I].Dispose();
						SkillIconsGfxInfo[(int) I].IsLoaded = false;
						SkillIconsGfxInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear Furniture
			for (var I = 1; I <= C_Housing.NumFurniture; I++)
			{
				if (FurnitureGfxInfo[(int) I].IsLoaded)
				{
					if (FurnitureGfxInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						FurnitureGfx[(int) I].Dispose();
						FurnitureSprite[(int) I].Dispose();
						FurnitureGfxInfo[(int) I].IsLoaded = false;
						FurnitureGfxInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear Projectiles
			for (var I = 1; I <= C_Projectiles.NumProjectiles; I++)
			{
				if (ProjectileGfxInfo[(int) I].IsLoaded)
				{
					if (ProjectileGfxInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						ProjectileGfx[(int) I].Dispose();
						ProjectileSprite[(int) I].Dispose();
						ProjectileGfxInfo[(int) I].IsLoaded = false;
						ProjectileGfxInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear Emotes
			for (var I = 1; I <= NumEmotes; I++)
			{
				if (EmotesGfxInfo[(int) I].IsLoaded)
				{
					if (EmotesGfxInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						EmotesGfx[(int) I].Dispose();
						EmotesSprite[(int) I].Dispose();
						EmotesGfxInfo[(int) I].IsLoaded = false;
						EmotesGfxInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear Panoramas
			for (var I = 1; I <= NumPanorama; I++)
			{
				if (PanoramasGfxInfo[(int) I].IsLoaded)
				{
					if (PanoramasGfxInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						PanoramasGfx[(int) I].Dispose();
						PanoramasSprite[(int) I].Dispose();
						PanoramasGfxInfo[(int) I].IsLoaded = false;
						PanoramasGfxInfo[(int) I].TextureTimer = 0;
					}
				}
			}
			
			//clear Parallax
			for (var I = 1; I <= NumParallax; I++)
			{
				if (ParallaxGfxInfo[(int) I].IsLoaded)
				{
					if (ParallaxGfxInfo[(int) I].TextureTimer < C_General.GetTickCount())
					{
						ParallaxGfx[(int) I].Dispose();
						ParallaxSprite[(int) I].Dispose();
						ParallaxGfxInfo[(int) I].IsLoaded = false;
						ParallaxGfxInfo[(int) I].TextureTimer = 0;
					}
				}
			}
		}
		
		internal static void Render_Graphics()
		{
			int x = 0;
			int y = 0;
			int I = 0;
			
			//Don't Render IF
			if (FrmGame.Default.WindowState == FormWindowState.Minimized)
			{
				return;
			}
			if (C_Variables.GettingMap)
			{
				return;
			}
			
			//lets get going
			
			//update view around player
			UpdateCamera();
			
			//let program do other things
			Application.DoEvents();
			
			//Clear each of our render targets
			GameWindow.DispatchEvents();
			GameWindow.Clear(SFML.Graphics.Color.Black);
			
			//If CurMouseX > 0 AndAlso CurMouseX <= GameWindow.Size.X Then
			//    If CurMouseY > 0 AndAlso CurMouseY <= GameWindow.Size.Y Then
			//        GameWindow.SetMouseCursorVisible(False)
			//    End If
			//End If
			
			if (NumPanorama > 0 && C_Maps.Map.Panorama > 0)
			{
				DrawPanorama(C_Maps.Map.Panorama);
			}
			
			if (NumParallax > 0 && C_Maps.Map.Parallax > 0)
			{
				DrawParallax(C_Maps.Map.Parallax);
			}
			
			// blit lower tiles
			if (NumTileSets > 0)
			{
				
				for (x = C_Variables.TileView.Left; x <= C_Variables.TileView.Right + 1; x++)
				{
					for (y = C_Variables.TileView.Top; y <= C_Variables.TileView.Bottom + 1; y++)
					{
						if (IsValidMapPoint(x, y))
						{
							C_Maps.DrawMapTile(x, y);
						}
					}
				}
			}
			
			// Furniture
			if (C_Housing.FurnitureHouse > 0)
			{
				if (C_Housing.FurnitureHouse == C_Types.Player[C_Variables.Myindex].InHouse)
				{
					if (C_Housing.FurnitureCount > 0)
					{
						for (I = 1; I <= C_Housing.FurnitureCount; I++)
						{
							if (C_Housing.Furniture[I].ItemNum > 0)
							{
								C_Housing.DrawFurniture(I, 0);
							}
						}
					}
				}
			}
			
			// events
			if (C_Maps.Map.CurrentEvents > 0 && C_Maps.Map.CurrentEvents <= C_Maps.Map.EventCount)
			{
				
				for (I = 1; I <= C_Maps.Map.CurrentEvents; I++)
				{
					if (C_Maps.Map.MapEvents[I].Position == 0)
					{
						C_EventSystem.DrawEvent(I);
					}
				}
			}
			
			//blood
			for (I = 1; I <= byte.MaxValue; I++)
			{
				DrawBlood(I);
			}
			
			// Draw out the items
			if (NumItems > 0)
			{
				for (I = 1; I <= Constants.MAX_MAP_ITEMS; I++)
				{
					if (C_Maps.MapItem[I].Num > 0)
					{
						DrawItem(I);
					}
				}
			}
			
			//Draw sum d00rs.
			if (C_Variables.GettingMap)
			{
				return;
			}
			
			for (x = C_Variables.TileView.Left; x <= C_Variables.TileView.Right; x++)
			{
				for (y = C_Variables.TileView.Top; y <= C_Variables.TileView.Bottom; y++)
				{
					if (IsValidMapPoint(x, y))
					{
						if (ReferenceEquals(C_Maps.Map.Tile, null))
						{
							return;
						}
						if (C_Maps.Map.Tile[x, y].Type == (byte)Enums.TileType.Door)
						{
							DrawDoor(x, y);
						}
					}
				}
			}
			
			// draw animations
			if (NumAnimations > 0)
			{
				for (I = 1; I <= byte.MaxValue; I++)
				{
					if (C_Types.AnimInstance[I].Used[0])
					{
						DrawAnimation(I, 0);
					}
				}
			}
			
			// Y-based render. Renders Players, Npcs and Resources based on Y-axis.
			for (y = 0; y <= C_Maps.Map.MaxY; y++)
			{
				
				if (NumCharacters > 0)
				{
					// Players
					for (I = 1; I <= C_Variables.TotalOnline; I++) //MAX_PLAYERS
					{
						if (C_Player.IsPlaying(I) && C_Player.GetPlayerMap(I) == C_Player.GetPlayerMap(C_Variables.Myindex))
						{
							if (C_Types.Player[I].Y == y)
							{
								DrawPlayer(I);
							}
							if (C_Pets.PetAlive(I))
							{
								if (C_Types.Player[I].Pet.Y == y)
								{
									C_Pets.DrawPet(I);
								}
							}
						}
					}
					
					// Npcs
					for (I = 1; I <= Constants.MAX_MAP_NPCS; I++)
					{
						if (C_Maps.MapNpc[I].Y == y)
						{
							DrawNpc(I);
						}
					}
					
					// events
					if (C_Maps.Map.CurrentEvents > 0 && C_Maps.Map.CurrentEvents <= C_Maps.Map.EventCount)
					{
						for (I = 1; I <= C_Maps.Map.CurrentEvents; I++)
						{
							if (C_Maps.Map.MapEvents[I].Position == 1)
							{
								if (y == C_Maps.Map.MapEvents[I].Y)
								{
									C_EventSystem.DrawEvent(I);
								}
							}
						}
					}
					
					// Draw the target icon
					if (C_Variables.MyTarget > 0)
					{
						if (C_Variables.MyTargetType == (int) Enums.TargetType.Player)
						{
							DrawTarget(C_Types.Player[C_Variables.MyTarget].X * 32 - 16 + C_Types.Player[C_Variables.MyTarget].XOffset, C_Types.Player[C_Variables.MyTarget].Y * 32 + C_Types.Player[C_Variables.MyTarget].YOffset);
						}
						else if (C_Variables.MyTargetType == (int) Enums.TargetType.Npc)
						{
							DrawTarget(C_Maps.MapNpc[C_Variables.MyTarget].X * 32 - 16 + C_Maps.MapNpc[C_Variables.MyTarget].XOffset, C_Maps.MapNpc[C_Variables.MyTarget].Y * 32 + C_Maps.MapNpc[C_Variables.MyTarget].YOffset);
						}
						else if (C_Variables.MyTargetType == (int) Enums.TargetType.Pet)
						{
							DrawTarget(C_Types.Player[C_Variables.MyTarget].Pet.X * 32 - 16 + C_Types.Player[C_Variables.MyTarget].Pet.XOffset, (C_Types.Player[C_Variables.MyTarget].Pet.Y * 32) + C_Types.Player[C_Variables.MyTarget].Pet.YOffset);
						}
					}
					
					for (I = 1; I <= C_Variables.TotalOnline; I++) //MAX_PLAYERS
					{
						if (C_Player.IsPlaying(I))
						{
							if (C_Types.Player[I].Map == C_Types.Player[C_Variables.Myindex].Map)
							{
								if (C_Variables.CurX == C_Types.Player[I].X && C_Variables.CurY == C_Types.Player[I].Y)
								{
									if (C_Variables.MyTargetType == (int) Enums.TargetType.Player && C_Variables.MyTarget == I)
									{
										// dont render lol
									}
									else
									{
										DrawHover(C_Types.Player[I].X * 32 - 16, C_Types.Player[I].Y * 32 + C_Types.Player[I].YOffset);
									}
								}
								
							}
						}
					}
				}
				
				// Resources
				if (NumResources > 0)
				{
					if (C_Resources.ResourcesInit)
					{
						if (C_Resources.ResourceIndex > 0)
						{
							for (I = 1; I <= C_Resources.ResourceIndex; I++)
							{
								if (C_Resources.MapResource[I].Y == y)
								{
									C_Resources.DrawMapResource(I);
								}
							}
						}
					}
				}
			}
			
			// animations
			if (NumAnimations > 0)
			{
				for (I = 1; I <= byte.MaxValue; I++)
				{
					if (C_Types.AnimInstance[I - 1].Used[1])
					{
						DrawAnimation(I - 1, 1);
					}
				}
			}
			
			//projectiles
			if (C_Projectiles.NumProjectiles > 0)
			{
				for (I = 1; I <= C_Projectiles.MaxProjectiles; I++)
				{
					if (C_Projectiles.MapProjectiles[I].ProjectileNum > 0)
					{
						C_Projectiles.DrawProjectile(I);
					}
				}
			}
			
			//events
			if (C_Maps.Map.CurrentEvents > 0 && C_Maps.Map.CurrentEvents <= C_Maps.Map.EventCount)
			{
				for (I = 1; I <= C_Maps.Map.CurrentEvents; I++)
				{
					if (C_Maps.Map.MapEvents[I].Position == 2)
					{
						C_EventSystem.DrawEvent(I);
					}
				}
			}
			
			// blit out upper tiles
			if (NumTileSets > 0)
			{
				for (x = C_Variables.TileView.Left; x <= C_Variables.TileView.Right + 1; x++)
				{
					for (y = C_Variables.TileView.Top; y <= C_Variables.TileView.Bottom + 1; y++)
					{
						if (IsValidMapPoint(x, y))
						{
							C_Maps.DrawMapFringeTile(x, y);
						}
					}
				}
			}
			
			// Furniture
			if (C_Housing.FurnitureHouse > 0)
			{
				if (C_Housing.FurnitureHouse == C_Types.Player[C_Variables.Myindex].InHouse)
				{
					if (C_Housing.FurnitureCount > 0)
					{
						for (I = 1; I <= C_Housing.FurnitureCount; I++)
						{
							if (C_Housing.Furniture[I].ItemNum > 0)
							{
								C_Housing.DrawFurniture(I, 1);
							}
						}
					}
				}
			}
			
			DrawNight();
			
			C_Weather.DrawWeather();
			C_Weather.DrawThunderEffect();
			DrawMapTint();
			
			// Draw out a square at mouse cursor
			if (C_Constants.MapGrid == true && C_Constants.InMapEditor)
			{
				DrawGrid();
			}
			
			if (ReferenceEquals(FrmEditor_MapEditor.Default.tabpages.SelectedTab, FrmEditor_MapEditor.Default.tpDirBlock))
			{
				for (x = C_Variables.TileView.Left; x <= C_Variables.TileView.Right; x++)
				{
					for (y = C_Variables.TileView.Top; y <= C_Variables.TileView.Bottom; y++)
					{
						if (IsValidMapPoint(x, y))
						{
							DrawDirections(x, y);
						}
					}
				}
			}
			
			if (C_Constants.InMapEditor)
			{
				FrmEditor_MapEditor.Default.DrawTileOutline();
			}
			
			//furniture
			if (C_Housing.FurnitureSelected > 0)
			{
				if (C_Types.Player[C_Variables.Myindex].InHouse == C_Variables.Myindex)
				{
					DrawFurnitureOutline();
				}
			}
			
			// draw cursor, player X and Y locations
			if (C_Variables.BLoc)
			{
				C_Text.DrawText(1, C_UpdateUI.HudWindowY + HudPanelGfxInfo.Height + 1, Strings.Get("gamegui", "curloc", C_Variables.CurX, C_Variables.CurY).Trim(), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow);
				C_Text.DrawText(1, C_UpdateUI.HudWindowY + HudPanelGfxInfo.Height + 15, Strings.Get("gamegui", "loc", C_Player.GetPlayerX(C_Variables.Myindex), C_Player.GetPlayerY(C_Variables.Myindex)).Trim(), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow);
				C_Text.DrawText(1, C_UpdateUI.HudWindowY + HudPanelGfxInfo.Height + 30, Strings.Get("gamegui", "curmap", C_Player.GetPlayerMap(C_Variables.Myindex)).Trim(), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow);
			}
			
			// draw player names
			for (I = 1; I <= C_Variables.TotalOnline; I++) //MAX_PLAYERS
			{
				if (C_Player.IsPlaying(I) && C_Player.GetPlayerMap(I) == C_Player.GetPlayerMap(C_Variables.Myindex))
				{
					C_Text.DrawPlayerName(I);
					if (C_Pets.PetAlive(I))
					{
						C_Pets.DrawPlayerPetName(I);
					}
				}
			}
			
			//draw event names
			for (I = 1; I <= C_Maps.Map.CurrentEvents; I++)
			{
				if (C_Maps.Map.MapEvents[I].Visible == 1)
				{
					if (C_Maps.Map.MapEvents[I].ShowName == 1)
					{
						C_Text.DrawEventName(I);
					}
				}
			}
			
			// draw npc names
			for (I = 1; I <= Constants.MAX_MAP_NPCS; I++)
			{
				if (C_Maps.MapNpc[I].Num > 0)
				{
					C_Text.DrawNpcName(I);
				}
			}
			
			if (C_Weather.CurrentFog > 0)
			{
				C_Weather.DrawFog();
			}
			
			// draw the messages
			for (I = 1; I <= byte.MaxValue; I++)
			{
				if (C_Variables.ChatBubble[I].Active)
				{
					C_Text.DrawChatBubble(I);
				}
			}
			
			//action msg
			for (I = 1; I <= byte.MaxValue; I++)
			{
				C_Text.DrawActionMsg(I);
			}
			
			// Blit out map attributes
			if (C_Constants.InMapEditor)
			{
				C_Text.DrawMapAttributes();
			}
			
			if (C_Constants.InMapEditor && ReferenceEquals(FrmEditor_MapEditor.Default.tabpages.SelectedTab, FrmEditor_MapEditor.Default.tpEvents))
			{
				C_EventSystem.DrawEvents();
				C_EventSystem.EditorEvent_DrawGraphic();
			}
			
			if (C_Variables.GettingMap)
			{
				return;
			}
			
			//draw hp and casting bars
			DrawBars();
			
			//party
			C_Parties.DrawParty();
			
			//Render GUI
			DrawGui();
			
			DrawMapFade();
			
			//and finally show everything on screen
			GameWindow.Display();
		}
		
		internal static void DrawPanorama(int index)
		{
			if (C_Maps.Map.Moral == (byte)Enums.MapMoralType.Indoors)
			{
				return;
			}
			
			if (index < 1 || index > NumParallax)
			{
				return;
			}
			
			if (PanoramasGfxInfo[index].IsLoaded == false)
			{
				LoadTexture(index, (byte) 13);
			}
			
			// we use it, lets update timer
			ref var with_1 = ref PanoramasGfxInfo[index];
			with_1.TextureTimer = C_General.GetTickCount() + 100000;
			
			PanoramasSprite[index].TextureRect = new IntRect(0, 0, (int)GameWindow.Size.X, (int)GameWindow.Size.Y);
			
			PanoramasSprite[index].Position = new Vector2f(0, 0);
			
			GameWindow.Draw(PanoramasSprite[index]);
			
		}
		
		internal static void DrawParallax(int index)
		{
			int horz = 0;
			int vert = 0;
			
			if (C_Maps.Map.Moral == (byte)Enums.MapMoralType.Indoors)
			{
				return;
			}
			
			if (index < 1 || index > NumParallax)
			{
				return;
			}
			
			if (ParallaxGfxInfo[index].IsLoaded == false)
			{
				LoadTexture(index, (byte) 14);
			}
			
			// we use it, lets update timer
			ref var with_1 = ref ParallaxGfxInfo[index];
			with_1.TextureTimer = C_General.GetTickCount() + 100000;
			
			horz = ConvertMapX(C_Player.GetPlayerX(C_Variables.Myindex));
			vert = ConvertMapY(C_Player.GetPlayerY(C_Variables.Myindex));
			
			ParallaxSprite[index].Position = new Vector2f((float) ((horz * 2.5) - 50), (float) ((vert * 2.5) - 50));
			
			GameWindow.Draw(ParallaxSprite[index]);
		}
		
		internal static void DrawBars()
		{
			int tmpY = 0;
			int tmpX = 0;
			int barWidth = 0;
			Rectangle[] rec = new Rectangle[2];
			
			if (C_Variables.GettingMap)
			{
				return;
			}
			
			// check for casting time bar
			if (C_Variables.SkillBuffer > 0)
			{
				// lock to player
				tmpX = C_Player.GetPlayerX(C_Variables.Myindex) * C_Constants.PicX + C_Types.Player[C_Variables.Myindex].XOffset;
				tmpY = C_Player.GetPlayerY(C_Variables.Myindex) * C_Constants.PicY + C_Types.Player[C_Variables.Myindex].YOffset + 35;
				if (Types.Skill[C_Variables.PlayerSkills[C_Variables.SkillBuffer]].CastTime == 0)
				{
					Types.Skill[C_Variables.PlayerSkills[C_Variables.SkillBuffer]].CastTime = 1;
				}
				// calculate the width to fill
				barWidth = System.Convert.ToInt32((double) (C_General.GetTickCount() - C_Variables.SkillBufferTimer) / ((C_General.GetTickCount() - C_Variables.SkillBufferTimer) + (Types.Skill[C_Variables.PlayerSkills[C_Variables.SkillBuffer]].CastTime * 1000)) * 64);
				// draw bars
				rec[1] = new Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4);
				RectangleShape rectShape = new RectangleShape(new Vector2f(barWidth, 4)) {
						Position = new Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY)),
						FillColor = SFML.Graphics.Color.Cyan
					};
				GameWindow.Draw(rectShape);
			}
			
			if (C_Types.Options.ShowNpcBar == 1)
			{
				// check for hp bar
				for (var i = 1; i <= Constants.MAX_MAP_NPCS; i++)
				{
					if (ReferenceEquals(C_Maps.Map.Npc, null))
					{
						return;
					}
					if (C_Maps.Map.Npc[(int) i] > 0)
					{
						if (Types.Npc[C_Maps.MapNpc[(int) i].Num].Behaviour == (byte)Enums.NpcBehavior.AttackOnSight || Types.Npc[C_Maps.MapNpc[(int) i].Num].Behaviour == (byte)Enums.NpcBehavior.AttackWhenAttacked || Types.Npc[C_Maps.MapNpc[(int) i].Num].Behaviour == (byte)Enums.NpcBehavior.Guard)
						{
							// lock to npc
							tmpX = C_Maps.MapNpc[(int) i].X * C_Constants.PicX + C_Maps.MapNpc[(int) i].XOffset;
							tmpY = System.Convert.ToInt32(C_Maps.MapNpc[(int) i].Y * C_Constants.PicY + C_Maps.MapNpc[(int) i].YOffset + 35);
							if (C_Maps.MapNpc[(int) i].Vital[(byte)Enums.VitalType.HP] > 0)
							{
								// calculate the width to fill
								barWidth = System.Convert.ToInt32(C_Maps.MapNpc[(int) i].Vital[(byte)Enums.VitalType.HP] / (Types.Npc[C_Maps.MapNpc[(int) i].Num].Hp) * 32);
								// draw bars
								rec[1] = new Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4);
								RectangleShape rectShape = new RectangleShape(new Vector2f(barWidth, 4)) {
										Position = new Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY - 75)),
										FillColor = SFML.Graphics.Color.Red
									};
								GameWindow.Draw(rectShape);
								
								if (C_Maps.MapNpc[(int) i].Vital[(byte)Enums.VitalType.MP] > 0)
								{
									// calculate the width to fill
									barWidth = System.Convert.ToInt32(C_Maps.MapNpc[(int) i].Vital[(byte)Enums.VitalType.MP] / (Types.Npc[C_Maps.MapNpc[(int) i].Num].Stat[(byte)Enums.StatType.Intelligence] * 2) * 32);
									// draw bars
									rec[1] = new Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4);
									RectangleShape rectShape2 = new RectangleShape(new Vector2f(barWidth, 4)) {
											Position = new Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY - 80)),
											FillColor = SFML.Graphics.Color.Blue
										};
									GameWindow.Draw(rectShape2);
								}
							}
						}
					}
				}
			}
			
			if (C_Pets.PetAlive(C_Variables.Myindex))
			{
				// draw own health bar
				if (C_Types.Player[C_Variables.Myindex].Pet.Health > 0 && C_Types.Player[C_Variables.Myindex].Pet.Health <= C_Types.Player[C_Variables.Myindex].Pet.MaxHp)
				{
					//Debug.Print("pethealth:" & Player(Myindex).Pet.Health)
					// lock to Player
					tmpX = C_Types.Player[C_Variables.Myindex].Pet.X * C_Constants.PicX + C_Types.Player[C_Variables.Myindex].Pet.XOffset;
					tmpY = C_Types.Player[C_Variables.Myindex].Pet.Y * C_Constants.PicX + C_Types.Player[C_Variables.Myindex].Pet.YOffset + 35;
					// calculate the width to fill
					barWidth = System.Convert.ToInt32(((double) (C_Types.Player[C_Variables.Myindex].Pet.Health) / (C_Types.Player[C_Variables.Myindex].Pet.MaxHp)) * 32);
					// draw bars
					rec[1] = new Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4);
					RectangleShape rectShape = new RectangleShape(new Vector2f(barWidth, 4)) {
							Position = new Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY - 75)),
							FillColor = SFML.Graphics.Color.Red
						};
					GameWindow.Draw(rectShape);
				}
			}
			// check for pet casting time bar
			if (C_Pets.PetSkillBuffer > 0)
			{
				if (Types.Skill[C_Pets.Pet[C_Types.Player[C_Variables.Myindex].Pet.Num].Skill[C_Pets.PetSkillBuffer]].CastTime > 0)
				{
					// lock to pet
					tmpX = C_Types.Player[C_Variables.Myindex].Pet.X * C_Constants.PicX + C_Types.Player[C_Variables.Myindex].Pet.XOffset;
					tmpY = C_Types.Player[C_Variables.Myindex].Pet.Y * C_Constants.PicY + C_Types.Player[C_Variables.Myindex].Pet.YOffset + 35;
					
					// calculate the width to fill
					barWidth = System.Convert.ToInt32((double) (C_General.GetTickCount() - C_Pets.PetSkillBufferTimer) / (Types.Skill[C_Pets.Pet[C_Types.Player[C_Variables.Myindex].Pet.Num].Skill[C_Pets.PetSkillBuffer]].CastTime * 1000) * 64);
					// draw bar background
					rec[1] = new Rectangle(ConvertMapX(tmpX), ConvertMapY(tmpY), barWidth, 4);
					RectangleShape rectShape = new RectangleShape(new Vector2f(barWidth, 4)) {
							Position = new Vector2f(ConvertMapX(tmpX), ConvertMapY(tmpY)),
							FillColor = SFML.Graphics.Color.Cyan
						};
					GameWindow.Draw(rectShape);
				}
			}
		}
		
		public static void DrawMapName()
		{
			C_Text.DrawText(System.Convert.ToInt32(C_Variables.DrawMapNameX), System.Convert.ToInt32(C_Variables.DrawMapNameY), Strings.Get("gamegui", "mapname") + C_Maps.Map.Name, C_Variables.DrawMapNameColor, SFML.Graphics.Color.Black, GameWindow);
		}
		
		internal static void DrawDoor(int x, int y)
		{
			Rectangle rec = new Rectangle();
			
			int x2;
			int y2;
			
			// sort out animation
			ref var with_1 = ref C_Maps.TempTile[x, y];
			if (with_1.DoorAnimate == 1) // opening
			{
				if (with_1.DoorTimer + 100 < C_General.GetTickCount())
				{
					if (with_1.DoorFrame < 4)
					{
						with_1.DoorFrame = (byte)(with_1.DoorFrame + 1);
					}
					else
					{
						with_1.DoorAnimate = 2; // set to closing
					}
					with_1.DoorTimer = C_General.GetTickCount();
				}
			}
			else if (with_1.DoorAnimate == 2) // closing
			{
				if (with_1.DoorTimer + 100 < C_General.GetTickCount())
				{
					if (with_1.DoorFrame > 1)
					{
						with_1.DoorFrame--;
					}
					else
					{
						with_1.DoorAnimate = 0; // end animation
					}
					with_1.DoorTimer = C_General.GetTickCount();
				}
			}
			
			if (with_1.DoorFrame == 0)
			{
				with_1.DoorFrame = 1;
			}
			
			rec.Y = 0;
			rec.Height = DoorGfxInfo.Height;
			rec.X = System.Convert.ToInt32((C_Maps.TempTile[x, y].DoorFrame - 1) * DoorGfxInfo.Width / 4);
			rec.Width = System.Convert.ToInt32((double) DoorGfxInfo.Width / 4);
			
			x2 = x * C_Constants.PicX;
			y2 = System.Convert.ToInt32((y * C_Constants.PicY) - ((double) DoorGfxInfo.Height / 2) + 4);
			
			RenderSprite(DoorSprite, GameWindow, ConvertMapX(x * C_Constants.PicX), ConvertMapY((y * C_Constants.PicY) - C_Constants.PicY), rec.X, rec.Y, rec.Width, rec.Height);
			
		}
		
		internal static void DrawAnimation(int index, int layer)
		{
			
			int sprite = 0;
			Rectangle sRect = new Rectangle();
			int width = 0;
			int height = 0;
			int frameCount = 0;
			int x = 0;
			int y = 0;
			int lockindex = 0;
			
			if (C_Types.AnimInstance[index].Animation == 0)
			{
				C_DataBase.ClearAnimInstance(index);
				return;
			}
			
			sprite = System.Convert.ToInt32(Types.Animation[C_Types.AnimInstance[index].Animation].Sprite[layer]);
			
			if (sprite < 1 || sprite > NumAnimations)
			{
				return;
			}
			
			if (AnimationsGfxInfo[sprite].IsLoaded == false)
			{
				LoadTexture(sprite, (byte) 6);
			}
			
			frameCount = System.Convert.ToInt32(Types.Animation[C_Types.AnimInstance[index].Animation].Frames[layer]);
			
			if (frameCount <= 0)
			{
				return;
			}
			
			// total width divided by frame count
			width = System.Convert.ToInt32((double) AnimationsGfxInfo[sprite].Width / frameCount);
			height = AnimationsGfxInfo[sprite].Height;
			
			sRect.Y = 0;
			sRect.Height = height;
			sRect.X = (C_Types.AnimInstance[index].FrameIndex[layer] - 1) * width;
			sRect.Width = width;
			
			// change x or y if locked
			if (C_Types.AnimInstance[index].LockType > (int) Enums.TargetType.None) // if <> none
			{
				// is a player
				if (C_Types.AnimInstance[index].LockType == (byte)Enums.TargetType.Player)
				{
					// quick save the index
					lockindex = C_Types.AnimInstance[index].lockindex;
					// check if is ingame
					if (C_Player.IsPlaying(lockindex))
					{
						// check if on same map
						if (C_Player.GetPlayerMap(lockindex) == C_Player.GetPlayerMap(C_Variables.Myindex))
						{
							// is on map, is playing, set x & y
							x = System.Convert.ToInt32((C_Player.GetPlayerX(lockindex) * C_Constants.PicX) + 16 - ((double) width / 2) + C_Types.Player[lockindex].XOffset);
							y = System.Convert.ToInt32((C_Player.GetPlayerY(lockindex) * C_Constants.PicY) + 16 - ((double) height / 2) + C_Types.Player[lockindex].YOffset);
						}
					}
				}
				else if (C_Types.AnimInstance[index].LockType == (byte)Enums.TargetType.Npc)
				{
					// quick save the index
					lockindex = C_Types.AnimInstance[index].lockindex;
					// check if NPC exists
					if (C_Maps.MapNpc[lockindex].Num > 0)
					{
						// check if alive
						if (C_Maps.MapNpc[lockindex].Vital[(byte)Enums.VitalType.HP] > 0)
						{
							// exists, is alive, set x & y
							x = System.Convert.ToInt32((C_Maps.MapNpc[lockindex].X * C_Constants.PicX) + 16 - ((double) width / 2) + C_Maps.MapNpc[lockindex].XOffset);
							y = System.Convert.ToInt32((C_Maps.MapNpc[lockindex].Y * C_Constants.PicY) + 16 - ((double) height / 2) + C_Maps.MapNpc[lockindex].YOffset);
						}
						else
						{
							// npc not alive anymore, kill the animation
							C_DataBase.ClearAnimInstance(index);
							return;
						}
					}
					else
					{
						// npc not alive anymore, kill the animation
						C_DataBase.ClearAnimInstance(index);
						return;
					}
				}
				else if (C_Types.AnimInstance[index].LockType == (byte)Enums.TargetType.Pet)
				{
					// quick save the index
					lockindex = C_Types.AnimInstance[index].lockindex;
					// check if is ingame
					if (C_Player.IsPlaying(lockindex) && C_Pets.PetAlive(lockindex) == true)
					{
						// check if on same map
						if (C_Player.GetPlayerMap(lockindex) == C_Player.GetPlayerMap(C_Variables.Myindex))
						{
							// is on map, is playing, set x & y
							x = System.Convert.ToInt32((C_Types.Player[lockindex].Pet.X * C_Constants.PicX) + 16 - ((double) width / 2) + C_Types.Player[lockindex].Pet.XOffset);
							y = System.Convert.ToInt32((C_Types.Player[lockindex].Pet.Y * C_Constants.PicY) + 16 - ((double) height / 2) + C_Types.Player[lockindex].Pet.YOffset);
						}
					}
				}
			}
			else
			{
				// no lock, default x + y
				x = System.Convert.ToInt32((C_Types.AnimInstance[index].X * 32) + 16 - ((double) width / 2));
				y = System.Convert.ToInt32((C_Types.AnimInstance[index].Y * 32) + 16 - ((double) height / 2));
			}
			
			x = ConvertMapX(x);
			y = ConvertMapY(y);
			
			// Clip to screen
			if (y < 0)
			{
				
				sRect.Y = sRect.Y - y;
				sRect.Height = sRect.Height - (y * (-1));
				
				y = 0;
			}
			
			if (x < 0)
			{
				
				sRect.X = sRect.X - x;
				sRect.Width = sRect.Width - (y * (-1));
				
				x = 0;
			}
			
			if (sRect.Width < 0 || sRect.Height < 0)
			{
				return;
			}
			
			RenderSprite(AnimationsSprite[sprite], GameWindow, x, y, sRect.X, sRect.Y, sRect.Width, sRect.Height);
			
		}
		
		internal static void DrawFurnitureOutline()
		{
			Rectangle rec = new Rectangle();
			
			rec.Y = 0;
			rec.Height = Types.Item[C_Player.GetPlayerInvItemNum(C_Variables.Myindex, C_Housing.FurnitureSelected)].FurnitureHeight * C_Constants.PicY;
			rec.X = 0;
			rec.Width = Types.Item[C_Player.GetPlayerInvItemNum(C_Variables.Myindex, C_Housing.FurnitureSelected)].FurnitureWidth * C_Constants.PicX;
			
			RectangleShape rec2 = new RectangleShape() {
					OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.Blue),
					OutlineThickness = 0.6F,
					FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
					Size = new Vector2f(rec.Width, rec.Height),
					Position = new Vector2f(ConvertMapX(C_Variables.CurX * C_Constants.PicX), ConvertMapY(C_Variables.CurY * C_Constants.PicY))
				};
			GameWindow.Draw(rec2);
		}
		
		internal static void DrawGrid()
		{
			
			RectangleShape rec = new RectangleShape();
			
			for (var x = C_Variables.TileView.Left; x <= C_Variables.TileView.Right; x++) // - 1
			{
				for (var y = C_Variables.TileView.Top; y <= C_Variables.TileView.Bottom; y++) // - 1
				{
					if (IsValidMapPoint(System.Convert.ToInt32(x), System.Convert.ToInt32(y)))
					{
						rec.OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.White);
						rec.OutlineThickness = (float) (0.6F);
						rec.FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent);
						rec.Size = new Vector2f(System.Convert.ToSingle(x * C_Constants.PicX), System.Convert.ToSingle(y * C_Constants.PicX));
						rec.Position = new Vector2f(ConvertMapX(System.Convert.ToInt32((x - 1) * C_Constants.PicX)), ConvertMapY(System.Convert.ToInt32((y - 1) * C_Constants.PicY)));
						
						GameWindow.Draw(rec);
					}
				}
			}
			
		}
		
		internal static void DrawMapTint()
		{
			
			if (C_Maps.Map.HasMapTint == 0)
			{
				return;
			}
			
			MapTintGfx.Clear(new SFML.Graphics.Color((byte) C_Weather.CurrentTintR, (byte) C_Weather.CurrentTintG, (byte) C_Weather.CurrentTintB, (byte) C_Weather.CurrentTintA));
			
			MapTintSprite = new Sprite(MapTintGfx.Texture) {
					TextureRect = new IntRect(0, 0, (int)GameWindow.Size.X, (int)GameWindow.Size.Y),
					Position = new Vector2f(0, 0)
				};
			
			MapTintGfx.Display();
			
			GameWindow.Draw(MapTintSprite);
			
		}
		
		internal static void DrawMapFade()
		{
			if (C_Variables.UseFade == false)
			{
				return;
			}
			
			MapFadeSprite = new Sprite(new Texture(new SFML.Graphics.Image(GameWindow.Size.X, GameWindow.Size.Y, SFML.Graphics.Color.Black))) {
					Color = new SFML.Graphics.Color((byte) 0, (byte) 0, (byte) 0, (byte) C_Variables.FadeAmount),
					TextureRect = new IntRect(0, 0, (int)GameWindow.Size.X, (int)GameWindow.Size.Y),
					Position = new Vector2f(0, 0)
				};
			
			GameWindow.Draw(MapFadeSprite);
			
		}
		
		public static void DestroyGraphics()
		{
			try
			{
				for (var i = 0; i <= NumAnimations; i++)
				{
					if (!ReferenceEquals(AnimationsGfx[(int) i], null))
					{
						AnimationsGfx[(int) i].Dispose();
					}
				}
				
				for (var i = 0; i <= NumCharacters; i++)
				{
					if (!ReferenceEquals(CharacterGfx[(int) i], null))
					{
						CharacterGfx[(int) i].Dispose();
					}
				}
				
				for (var i = 0; i <= NumItems; i++)
				{
					if (!ReferenceEquals(ItemsGfx[(int) i], null))
					{
						ItemsGfx[(int) i].Dispose();
					}
				}
				
				for (var i = 0; i <= NumPaperdolls; i++)
				{
					if (!ReferenceEquals(PaperDollGfx[(int) i], null))
					{
						PaperDollGfx[(int) i].Dispose();
					}
				}
				
				for (var i = 0; i <= NumResources; i++)
				{
					if (!ReferenceEquals(ResourcesGfx[(int) i], null))
					{
						ResourcesGfx[(int) i].Dispose();
					}
				}
				
				for (var i = 0; i <= NumSkillIcons; i++)
				{
					if (!ReferenceEquals(SkillIconsGfx[(int) i], null))
					{
						SkillIconsGfx[(int) i].Dispose();
					}
				}
				
				for (var i = 0; i <= NumTileSets; i++)
				{
					if (!ReferenceEquals(TileSetTexture[(int) i], null))
					{
						TileSetTexture[(int) i].Dispose();
					}
				}
				
				for (var i = 0; i <= C_Housing.NumFurniture; i++)
				{
					if (!ReferenceEquals(FurnitureGfx[(int) i], null))
					{
						FurnitureGfx[(int) i].Dispose();
					}
				}
				
				for (var i = 0; i <= NumFaces; i++)
				{
					if (!ReferenceEquals(FacesGfx[(int) i], null))
					{
						FacesGfx[(int) i].Dispose();
					}
				}
				
				for (var i = 0; i <= NumFogs; i++)
				{
					if (!ReferenceEquals(FogGfx[(int) i], null))
					{
						FogGfx[(int) i].Dispose();
					}
				}
				
				for (var i = 0; i <= C_Projectiles.NumProjectiles; i++)
				{
					if (!ReferenceEquals(ProjectileGfx[(int) i], null))
					{
						ProjectileGfx[(int) i].Dispose();
					}
				}
				
				for (var i = 0; i <= NumEmotes; i++)
				{
					if (!ReferenceEquals(EmotesGfx[(int) i], null))
					{
						EmotesGfx[(int) i].Dispose();
					}
				}
				
				for (var i = 0; i <= NumPanorama; i++)
				{
					if (!ReferenceEquals(PanoramasGfx[(int) i], null))
					{
						PanoramasGfx[(int) i].Dispose();
					}
				}
				
				for (var i = 0; i <= NumParallax; i++)
				{
					if (!ReferenceEquals(ParallaxGfx[(int) i], null))
					{
						ParallaxGfx[(int) i].Dispose();
					}
				}
				
				if (!ReferenceEquals(CursorGfx, null))
				{
					CursorGfx.Dispose();
				}
				if (!ReferenceEquals(DoorGfx, null))
				{
					DoorGfx.Dispose();
				}
				if (!ReferenceEquals(BloodGfx, null))
				{
					BloodGfx.Dispose();
				}
				if (!ReferenceEquals(DirectionsGfx, null))
				{
					DirectionsGfx.Dispose();
				}
				if (!ReferenceEquals(ActionPanelGfx, null))
				{
					ActionPanelGfx.Dispose();
				}
				if (!ReferenceEquals(InvPanelGfx, null))
				{
					InvPanelGfx.Dispose();
				}
				if (!ReferenceEquals(CharPanelGfx, null))
				{
					CharPanelGfx.Dispose();
				}
				if (!ReferenceEquals(CharPanelPlusGfx, null))
				{
					CharPanelPlusGfx.Dispose();
				}
				if (!ReferenceEquals(CharPanelMinGfx, null))
				{
					CharPanelMinGfx.Dispose();
				}
				if (!ReferenceEquals(TargetGfx, null))
				{
					TargetGfx.Dispose();
				}
				if (!ReferenceEquals(WeatherGfx, null))
				{
					WeatherGfx.Dispose();
				}
				if (!ReferenceEquals(HotBarGfx, null))
				{
					HotBarGfx.Dispose();
				}
				if (!ReferenceEquals(ChatWindowGfx, null))
				{
					ChatWindowGfx.Dispose();
				}
				if (!ReferenceEquals(BankPanelGfx, null))
				{
					BankPanelGfx.Dispose();
				}
				if (!ReferenceEquals(ShopPanelGfx, null))
				{
					ShopPanelGfx.Dispose();
				}
				if (!ReferenceEquals(TradePanelGfx, null))
				{
					TradePanelGfx.Dispose();
				}
				if (!ReferenceEquals(EventChatGfx, null))
				{
					EventChatGfx.Dispose();
				}
				if (!ReferenceEquals(RClickGfx, null))
				{
					RClickGfx.Dispose();
				}
				if (!ReferenceEquals(ButtonGfx, null))
				{
					ButtonGfx.Dispose();
				}
				if (!ReferenceEquals(ButtonHoverGfx, null))
				{
					ButtonHoverGfx.Dispose();
				}
				if (!ReferenceEquals(QuestGfx, null))
				{
					QuestGfx.Dispose();
				}
				if (!ReferenceEquals(CraftGfx, null))
				{
					CraftGfx.Dispose();
				}
				if (!ReferenceEquals(ProgBarGfx, null))
				{
					ProgBarGfx.Dispose();
				}
				if (!ReferenceEquals(ChatBubbleGfx, null))
				{
					ChatBubbleGfx.Dispose();
				}
				
				if (!ReferenceEquals(HpBarGfx, null))
				{
					HpBarGfx.Dispose();
				}
				if (!ReferenceEquals(MpBarGfx, null))
				{
					MpBarGfx.Dispose();
				}
				if (!ReferenceEquals(ExpBarGfx, null))
				{
					ExpBarGfx.Dispose();
				}
				
				if (!ReferenceEquals(LightGfx, null))
				{
					LightGfx.Dispose();
				}
				if (!ReferenceEquals(NightGfx, null))
				{
					NightGfx.Dispose();
				}
			}
			catch (Exception)
			{
				
			}
		}
		
		public static void DrawHud()
		{
			Rectangle rec = new Rectangle();
			
			//first render backpanel
			rec.Y = 0;
			rec.Height = HudPanelGfxInfo.Height;
			rec.X = 0;
			rec.Width = HudPanelGfxInfo.Width;
			
			RenderSprite(HudPanelSprite, GameWindow, C_UpdateUI.HudWindowX, C_UpdateUI.HudWindowY, rec.X, rec.Y, rec.Width, rec.Height);
			
			if (C_Types.Player[C_Variables.Myindex].Sprite <= NumFaces)
			{
				Sprite tmpSprite = new Sprite(FacesGfx[C_Types.Player[C_Variables.Myindex].Sprite]);
				
				if (FacesGfxInfo[C_Types.Player[C_Variables.Myindex].Sprite].IsLoaded == false)
				{
					LoadTexture(C_Types.Player[C_Variables.Myindex].Sprite, (byte) 7);
				}
				
				//seeying we still use it, lets update timer
				ref var with_2 = ref FacesGfxInfo[C_Types.Player[C_Variables.Myindex].Sprite];
				with_2.TextureTimer = C_General.GetTickCount() + 100000;
				
				//then render face
				rec.Y = 0;
				rec.Height = FacesGfxInfo[C_Types.Player[C_Variables.Myindex].Sprite].Height;
				rec.X = 0;
				rec.Width = FacesGfxInfo[C_Types.Player[C_Variables.Myindex].Sprite].Width;
				
				RenderSprite(FacesSprite[C_Types.Player[C_Variables.Myindex].Sprite], GameWindow, C_UpdateUI.HudFaceX, C_UpdateUI.HudFaceY, rec.X, rec.Y, rec.Width, rec.Height);
			}
			
			//Hp Bar etc
			DrawStatBars();
			
			//Fps etc
			if (C_Variables.Fps > 64)
			{
				C_Variables.Fps = 64;
			}

            string timeFormat = "h:mm";

            C_Text.DrawText(C_UpdateUI.HudWindowX + C_UpdateUI.HudhpBarX + HpBarGfxInfo.Width + 10, C_UpdateUI.HudWindowY + C_UpdateUI.HudhpBarY + 4, Strings.Get("gamegui", "fps") + System.Convert.ToString(C_Variables.Fps), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			C_Text.DrawText(C_UpdateUI.HudWindowX + C_UpdateUI.HudmpBarX + MpBarGfxInfo.Width + 10, C_UpdateUI.HudWindowY + C_UpdateUI.HudmpBarY + 4, Strings.Get("gamegui", "ping") + C_Variables.PingToDraw, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			C_Text.DrawText(C_UpdateUI.HudWindowX + C_UpdateUI.HudexpBarX + ExpBarGfxInfo.Width + 10, C_UpdateUI.HudWindowY + C_UpdateUI.HudexpBarY + 4, Strings.Get("gamegui", "clock") + Time.Instance.ToString(ref timeFormat), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			
			if (C_Variables.Blps)
			{
				C_Text.DrawText(C_UpdateUI.HudWindowX + C_UpdateUI.HudexpBarX + ExpBarGfxInfo.Width + 10, C_UpdateUI.HudWindowY + C_UpdateUI.HudexpBarY + 20, Strings.Get("gamegui", "lps") + System.Convert.ToString(C_Variables.Lps), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			}
			
			// Draw map name
			DrawMapName();
		}
		
		public static void DrawStatBars()
		{
			Rectangle rec = new Rectangle();
			int curHp = 0;
			int curMp = 0;
			int curExp = 0;
			
			//HP Bar
			curHp = System.Convert.ToInt32(((double) C_Player.GetPlayerVital(C_Variables.Myindex, (Enums.VitalType)1) / C_Player.GetPlayerMaxVital(C_Variables.Myindex, (Enums.VitalType)1)) * 100);
			
			rec.Y = 0;
			rec.Height = HpBarGfxInfo.Height;
			rec.X = 0;
			rec.Width = System.Convert.ToInt32((double) curHp * HpBarGfxInfo.Width / 100);
			
			//then render full ontop of it
			RenderSprite(HpBarSprite, GameWindow, C_UpdateUI.HudWindowX + C_UpdateUI.HudhpBarX, C_UpdateUI.HudWindowY + C_UpdateUI.HudhpBarY + 4, rec.X, rec.Y, rec.Width, rec.Height);
			
			//then draw the text onto that
			C_Text.DrawText(C_UpdateUI.HudWindowX + C_UpdateUI.HudhpBarX + 65, C_UpdateUI.HudWindowY + C_UpdateUI.HudhpBarY + 4, C_Player.GetPlayerVital(C_Variables.Myindex, (Enums.VitalType)1) + "/" + System.Convert.ToString(C_Player.GetPlayerMaxVital(C_Variables.Myindex, (Enums.VitalType)1)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			
			//==============================
			
			//MP Bar
			curMp = System.Convert.ToInt32(((double) C_Player.GetPlayerVital(C_Variables.Myindex, (Enums.VitalType)2) / C_Player.GetPlayerMaxVital(C_Variables.Myindex, (Enums.VitalType)2)) * 100);
			
			//then render full ontop of it
			rec.Y = 0;
			rec.Height = MpBarGfxInfo.Height;
			rec.X = 0;
			rec.Width = System.Convert.ToInt32((double) curMp * MpBarGfxInfo.Width / 100);
			
			RenderSprite(MpBarSprite, GameWindow, C_UpdateUI.HudWindowX + C_UpdateUI.HudmpBarX, C_UpdateUI.HudWindowY + C_UpdateUI.HudmpBarY + 4, rec.X, rec.Y, rec.Width, rec.Height);
			
			//draw text onto that
			C_Text.DrawText(C_UpdateUI.HudWindowX + C_UpdateUI.HudmpBarX + 65, C_UpdateUI.HudWindowY + C_UpdateUI.HudmpBarY + 4, C_Player.GetPlayerVital(C_Variables.Myindex, (Enums.VitalType)2) + "/" + System.Convert.ToString(C_Player.GetPlayerMaxVital(C_Variables.Myindex, (Enums.VitalType)2)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			
			//====================================================
			//EXP Bar
			curExp = System.Convert.ToInt32(((double) C_Player.GetPlayerExp(C_Variables.Myindex) / C_Variables.NextlevelExp) * 100);
			
			//then render full ontop of it
			rec.Y = 0;
			rec.Height = ExpBarGfxInfo.Height;
			rec.X = 0;
			rec.Width = System.Convert.ToInt32((double) curExp * ExpBarGfxInfo.Width / 100);
			
			RenderSprite(ExpBarSprite, GameWindow, C_UpdateUI.HudWindowX + C_UpdateUI.HudexpBarX, C_UpdateUI.HudWindowY + C_UpdateUI.HudexpBarY + 4, rec.X, rec.Y, rec.Width, rec.Height);
			
			//draw text onto that
			C_Text.DrawText(C_UpdateUI.HudWindowX + C_UpdateUI.HudexpBarX + 65, C_UpdateUI.HudWindowY + C_UpdateUI.HudexpBarY + 4, C_Player.GetPlayerExp(C_Variables.Myindex) + "/" + System.Convert.ToString(C_Variables.NextlevelExp), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
		}
		
		public static void DrawActionPanel()
		{
			Rectangle rec = new Rectangle();
			
			//first render backpanel
			rec.Y = 0;
			rec.Height = ActionPanelGfxInfo.Height;
			rec.X = 0;
			rec.Width = ActionPanelGfxInfo.Width;
			
			RenderSprite(ActionPanelSprite, GameWindow, C_UpdateUI.ActionPanelX, C_UpdateUI.ActionPanelY, rec.X, rec.Y, rec.Width, rec.Height);
			
		}
		
		public static void DrawEquipment()
		{
			int i = 0;
			int itemnum = 0;
			int itempic = 0;
			byte tmprarity = 0;
			Rectangle rec = new Rectangle();
			Rectangle recPos = new Rectangle();
			int playersprite = 0;
			Sprite tmpSprite2 = new Sprite(CharPanelGfx);
			SFML.Graphics.Color tempRarityColor = new SFML.Graphics.Color();
			
			if (NumItems == 0)
			{
				return;
			}
			
			//first render panel
			RenderSprite(CharPanelSprite, GameWindow, C_UpdateUI.CharWindowX, C_UpdateUI.CharWindowY, 0, 0, CharPanelGfxInfo.Width, CharPanelGfxInfo.Height);
			
			//lets get player sprite to render
			playersprite = C_Player.GetPlayerSprite(C_Variables.Myindex);
			
			rec.Y = 0;
			rec.Height = System.Convert.ToInt32((double) CharacterGfxInfo[playersprite].Height / 4);
			rec.X = 0;
			rec.Width = System.Convert.ToInt32((double) CharacterGfxInfo[playersprite].Width / 4);
			
			RenderSprite(CharacterSprite[playersprite], GameWindow, System.Convert.ToInt32(C_UpdateUI.CharWindowX + (double) CharPanelGfxInfo.Width / 4 - (double) rec.Width / 2), System.Convert.ToInt32(C_UpdateUI.CharWindowY + (double) CharPanelGfxInfo.Height / 2 - (double) rec.Height / 2), rec.X, rec.Y, rec.Width, rec.Height);
			
			for (i = 1; i <= (int) Enums.EquipmentType.Count - 1; i++)
			{
				itemnum = C_Player.GetPlayerEquipment(C_Variables.Myindex, (Enums.EquipmentType)i);
				
				if (itemnum > 0)
				{
					
					itempic = Types.Item[itemnum].Pic;
					
					if (ItemsGfxInfo[itempic].IsLoaded == false)
					{
						LoadTexture(itempic, (byte) 4);
					}
					
					//seeying we still use it, lets update timer
					ref var with_2 = ref ItemsGfxInfo[itempic];
					with_2.TextureTimer = C_General.GetTickCount() + 100000;
					
					rec.Y = 0;
					rec.Height = 32;
					rec.X = 0;
					rec.Width = 32;
					
					recPos.Y = C_UpdateUI.CharWindowY + C_UpdateUI.EqTop + ((C_UpdateUI.EqOffsetY + 32) * ((i - 1) / C_UpdateUI.EqColumns));
					recPos.Height = C_Constants.PicY;
					recPos.X = C_UpdateUI.CharWindowX + C_UpdateUI.EqLeft + 1 + ((C_UpdateUI.EqOffsetX + 32 - 2) * ((i - 1) % C_UpdateUI.EqColumns));
					recPos.Width = C_Constants.PicX;
					
					ItemsSprite[itempic].TextureRect = new IntRect(rec.X, rec.Y, rec.Width, rec.Height);
					ItemsSprite[itempic].Position = new Vector2f(recPos.X, recPos.Y);
					GameWindow.Draw(ItemsSprite[itempic]);
					
					// set the name
					if (Types.Item[itemnum].Randomize != 0)
					{
						tmprarity = (byte) (C_Types.Player[C_Variables.Myindex].RandEquip[i].Rarity);
					}
					else
					{
						tmprarity = Types.Item[itemnum].Rarity;
					}
					
					if (tmprarity == ((byte) 0)) // White
					{
						tempRarityColor = C_Constants.ItemRarityColor0;
					} // green
					else if (tmprarity == ((byte) 1))
					{
						tempRarityColor = (SFML.Graphics.Color)C_Constants.ItemRarityColor1;
					} // blue
					else if (tmprarity == ((byte) 2))
					{
						tempRarityColor = (SFML.Graphics.Color)C_Constants.ItemRarityColor2;
					} // maroon
					else if (tmprarity == ((byte) 3))
					{
						tempRarityColor = (SFML.Graphics.Color)C_Constants.ItemRarityColor3;
					} // purple
					else if (tmprarity == ((byte) 4))
					{
						tempRarityColor = (SFML.Graphics.Color)C_Constants.ItemRarityColor4;
					} //gold
					else if (tmprarity == ((byte) 5))
					{
						tempRarityColor = (SFML.Graphics.Color)C_Constants.ItemRarityColor5;
					}
					
					RectangleShape rec2 = new RectangleShape() {
							OutlineColor = new SFML.Graphics.Color(tempRarityColor),
							OutlineThickness = 2,
							FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent),
							Size = new Vector2f(30, 30),
							Position = new Vector2f(recPos.X, recPos.Y)
						};
					GameWindow.Draw(rec2);
				}
				
			}
			
			// Set the character windows
			//name
			C_Text.DrawText(C_UpdateUI.CharWindowX + 10, C_UpdateUI.CharWindowY + 14, Strings.Get("charwindow", "charname") + C_Player.GetPlayerName(C_Variables.Myindex), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//class
			C_Text.DrawText(C_UpdateUI.CharWindowX + 10, C_UpdateUI.CharWindowY + 33, Strings.Get("charwindow", "charclass") + Microsoft.VisualBasic.Strings.Trim(Types.Classes[C_Player.GetPlayerClass(C_Variables.Myindex)].Name), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//level
			C_Text.DrawText(C_UpdateUI.CharWindowX + 150, C_UpdateUI.CharWindowY + 14, Strings.Get("charwindow", "charlvl") + System.Convert.ToString(C_Player.GetPlayerLevel(C_Variables.Myindex)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//points
			C_Text.DrawText(C_UpdateUI.CharWindowX + 6, C_UpdateUI.CharWindowY + 200, Strings.Get("charwindow", "charpoints") + System.Convert.ToString(C_Player.GetPlayerPoints(C_Variables.Myindex)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			
			//Header
			C_Text.DrawText(C_UpdateUI.CharWindowX + 250, C_UpdateUI.CharWindowY + 14, Strings.Get("charwindow", "charstatslbl"), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			
			//strength stat
			C_Text.DrawText(C_UpdateUI.CharWindowX + 210, C_UpdateUI.CharWindowY + 30, Strings.Get("charwindow", "charstrength") + System.Convert.ToString(C_Player.GetPlayerStat(C_Variables.Myindex, Enums.StatType.Strength)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, (byte) 11);
			//endurance stat
			C_Text.DrawText(C_UpdateUI.CharWindowX + 210, C_UpdateUI.CharWindowY + 50, Strings.Get("charwindow", "charendurance") + System.Convert.ToString(C_Player.GetPlayerStat(C_Variables.Myindex, Enums.StatType.Endurance)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, (byte) 11);
			//vitality stat
			C_Text.DrawText(C_UpdateUI.CharWindowX + 210, C_UpdateUI.CharWindowY + 70, Strings.Get("charwindow", "charvitality") + System.Convert.ToString(C_Player.GetPlayerStat(C_Variables.Myindex, Enums.StatType.Vitality)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, (byte) 11);
			//intelligence stat
			C_Text.DrawText(C_UpdateUI.CharWindowX + 210, C_UpdateUI.CharWindowY + 90, Strings.Get("charwindow", "charintelligence") + System.Convert.ToString(C_Player.GetPlayerStat(C_Variables.Myindex, Enums.StatType.Intelligence)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, (byte) 11);
			//luck stat
			C_Text.DrawText(C_UpdateUI.CharWindowX + 210, C_UpdateUI.CharWindowY + 110, Strings.Get("charwindow", "charluck") + System.Convert.ToString(C_Player.GetPlayerStat(C_Variables.Myindex, Enums.StatType.Luck)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, (byte) 11);
			//spirit stat
			C_Text.DrawText(C_UpdateUI.CharWindowX + 210, C_UpdateUI.CharWindowY + 130, Strings.Get("charwindow", "charspirit") + System.Convert.ToString(C_Player.GetPlayerStat(C_Variables.Myindex, Enums.StatType.Spirit)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, (byte) 11);
			
			if (C_Player.GetPlayerPoints(C_Variables.Myindex) > 0)
			{
				//strength upgrade
				RenderSprite(CharPanelPlusSprite, GameWindow, C_UpdateUI.CharWindowX + C_UpdateUI.StrengthUpgradeX, C_UpdateUI.CharWindowY + C_UpdateUI.StrengthUpgradeY + 4, 0, 0, CharPanelPlusGfxInfo.Width, CharPanelPlusGfxInfo.Height);
				//endurance upgrade
				RenderSprite(CharPanelPlusSprite, GameWindow, C_UpdateUI.CharWindowX + C_UpdateUI.EnduranceUpgradeX, C_UpdateUI.CharWindowY + C_UpdateUI.EnduranceUpgradeY + 4, 0, 0, CharPanelPlusGfxInfo.Width, CharPanelPlusGfxInfo.Height);
				//vitality upgrade
				RenderSprite(CharPanelPlusSprite, GameWindow, C_UpdateUI.CharWindowX + C_UpdateUI.VitalityUpgradeX, C_UpdateUI.CharWindowY + C_UpdateUI.VitalityUpgradeY + 4, 0, 0, CharPanelPlusGfxInfo.Width, CharPanelPlusGfxInfo.Height);
				//intelligence upgrade
				RenderSprite(CharPanelPlusSprite, GameWindow, C_UpdateUI.CharWindowX + C_UpdateUI.IntellectUpgradeX, C_UpdateUI.CharWindowY + C_UpdateUI.IntellectUpgradeY + 4, 0, 0, CharPanelPlusGfxInfo.Width, CharPanelPlusGfxInfo.Height);
				//willpower upgrade
				RenderSprite(CharPanelPlusSprite, GameWindow, C_UpdateUI.CharWindowX + C_UpdateUI.LuckUpgradeX, C_UpdateUI.CharWindowY + C_UpdateUI.LuckUpgradeY + 4, 0, 0, CharPanelPlusGfxInfo.Width, CharPanelPlusGfxInfo.Height);
				//spirit upgrade
				RenderSprite(CharPanelPlusSprite, GameWindow, C_UpdateUI.CharWindowX + C_UpdateUI.SpiritUpgradeX, C_UpdateUI.CharWindowY + C_UpdateUI.SpiritUpgradeY + 4, 0, 0, CharPanelPlusGfxInfo.Width, CharPanelPlusGfxInfo.Height);
			}
			
			//gather skills
			//Header
			C_Text.DrawText(C_UpdateUI.CharWindowX + 250, C_UpdateUI.CharWindowY + 145, Strings.Get("charwindow", "chargather"), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//herbalist skill
			C_Text.DrawText(C_UpdateUI.CharWindowX + 210, C_UpdateUI.CharWindowY + 164, Strings.Get("charwindow", "charherb") + System.Convert.ToString(C_Player.GetPlayerGatherSkillLvl(C_Variables.Myindex, (System.Int32) Enums.ResourceSkills.Herbalist)) + Strings.Get("charwindow", "charexp") + System.Convert.ToString(C_Player.GetPlayerGatherSkillExp(C_Variables.Myindex, (System.Int32) Enums.ResourceSkills.Herbalist)) + "/" + System.Convert.ToString(C_Player.GetPlayerGatherSkillMaxExp(C_Variables.Myindex, (System.Int32) Enums.ResourceSkills.Herbalist)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, (byte) 11);
			//woodcutter
			C_Text.DrawText(C_UpdateUI.CharWindowX + 210, C_UpdateUI.CharWindowY + 184, Strings.Get("charwindow", "charwood") + System.Convert.ToString(C_Player.GetPlayerGatherSkillLvl(C_Variables.Myindex, (System.Int32) Enums.ResourceSkills.WoodCutter)) + Strings.Get("charwindow", "charexp") + System.Convert.ToString(C_Player.GetPlayerGatherSkillExp(C_Variables.Myindex, (System.Int32) Enums.ResourceSkills.WoodCutter)) + "/" + System.Convert.ToString(C_Player.GetPlayerGatherSkillMaxExp(C_Variables.Myindex, (System.Int32) Enums.ResourceSkills.WoodCutter)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, (byte) 11);
			//miner
			C_Text.DrawText(C_UpdateUI.CharWindowX + 210, C_UpdateUI.CharWindowY + 204, Strings.Get("charwindow", "charmine") + System.Convert.ToString(C_Player.GetPlayerGatherSkillLvl(C_Variables.Myindex, (System.Int32) Enums.ResourceSkills.Miner)) + Strings.Get("charwindow", "charexp") + System.Convert.ToString(C_Player.GetPlayerGatherSkillExp(C_Variables.Myindex, (System.Int32) Enums.ResourceSkills.Miner)) + "/" + System.Convert.ToString(C_Player.GetPlayerGatherSkillMaxExp(C_Variables.Myindex, (System.Int32) Enums.ResourceSkills.Miner)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, (byte) 11);
			//fisherman
			C_Text.DrawText(C_UpdateUI.CharWindowX + 210, C_UpdateUI.CharWindowY + 224, Strings.Get("charwindow", "charfish") + System.Convert.ToString(C_Player.GetPlayerGatherSkillLvl(C_Variables.Myindex, (System.Int32) Enums.ResourceSkills.Fisherman)) + Strings.Get("charwindow", "charexp") + System.Convert.ToString(C_Player.GetPlayerGatherSkillExp(C_Variables.Myindex, (System.Int32) Enums.ResourceSkills.Fisherman)) + "/" + System.Convert.ToString(C_Player.GetPlayerGatherSkillMaxExp(C_Variables.Myindex, (System.Int32) Enums.ResourceSkills.Fisherman)), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow, (byte) 11);
		}
		
		internal static void DrawInventoryItem(int x, int y)
		{
			Rectangle rec = new Rectangle();
			int itemnum = 0;
			int itempic = 0;
			
			itemnum = C_Player.GetPlayerInvItemNum(C_Variables.Myindex, C_Items.DragInvSlotNum);
			
			if (itemnum > 0 && itemnum <= Constants.MAX_ITEMS)
			{
				
				itempic = Types.Item[itemnum].Pic;
				if (itempic == 0)
				{
					return;
				}
				
				if (ItemsGfxInfo[itempic].IsLoaded == false)
				{
					LoadTexture(itempic, (byte) 4);
				}
				
				//seeying we still use it, lets update timer
				ref var with_1 = ref ItemsGfxInfo[itempic];
				with_1.TextureTimer = C_General.GetTickCount() + 100000;
				
				rec.Y = 0;
				rec.Height = C_Constants.PicY;
				rec.X = 0;
				rec.Width = C_Constants.PicX;
				
				RenderSprite(ItemsSprite[itempic], GameWindow, x + 16, y + 16, rec.X, rec.Y, rec.Width, rec.Height);
			}
		}
		
		public static void DrawInventory()
		{
			int i = 0;
			int x = 0;
			int y = 0;
			int itemnum = 0;
			int itempic = 0;
			string amount = "";
			Rectangle rec = new Rectangle();
			Rectangle recPos = new Rectangle();
			SFML.Graphics.Color colour = new SFML.Graphics.Color();
			
			if (!C_Variables.InGame)
			{
				return;
			}
			
			//first render panel
			RenderSprite(InvPanelSprite, GameWindow, C_UpdateUI.InvWindowX, C_UpdateUI.InvWindowY, 0, 0, InvPanelGfxInfo.Width, InvPanelGfxInfo.Height);
			
			for (i = 1; i <= Constants.MAX_INV; i++)
			{
				itemnum = C_Player.GetPlayerInvItemNum(C_Variables.Myindex, i);
				
				if (itemnum > 0 && itemnum <= Constants.MAX_ITEMS)
				{
					itempic = Types.Item[itemnum].Pic;
					if (itempic == 0)
					{
						goto NextLoop;
					}
					
					if (ItemsGfxInfo[itempic].IsLoaded == false)
					{
						LoadTexture(itempic, (byte) 4);
					}
					
					//seeying we still use it, lets update timer
					ref var with_1 = ref ItemsGfxInfo[itempic];
					with_1.TextureTimer = C_General.GetTickCount() + 100000;
					
					// exit out if we're offering item in a trade.
					if (C_Trade.InTrade)
					{
						for (x = 1; x <= Constants.MAX_INV; x++)
						{
							if (C_Trade.TradeYourOffer[x].Num == i)
							{
								goto NextLoop;
							}
						}
					}
					
					if (itempic > 0 && itempic <= NumItems)
					{
						if (ItemsGfxInfo[itempic].Width <= 64) // more than 1 frame is handled by anim sub
						{
							
							rec.Y = 0;
							rec.Height = 32;
							rec.X = 0;
							rec.Width = 32;
							
							recPos.Y = C_UpdateUI.InvWindowY + C_UpdateUI.InvTop + ((C_UpdateUI.InvOffsetY + 32) * ((i - 1) / C_UpdateUI.InvColumns));
							recPos.Height = C_Constants.PicY;
							recPos.X = C_UpdateUI.InvWindowX + C_UpdateUI.InvLeft + ((C_UpdateUI.InvOffsetX + 32) * ((i - 1) % C_UpdateUI.InvColumns));
							recPos.Width = C_Constants.PicX;
							
							RenderSprite(ItemsSprite[itempic], GameWindow, recPos.X, recPos.Y, rec.X, rec.Y, rec.Width, rec.Height);
							
							// If item is a stack - draw the amount you have
							if (C_Player.GetPlayerInvItemValue(C_Variables.Myindex, i) > 1)
							{
								y = recPos.Top + 22;
								x = recPos.Left - 4;
								amount = System.Convert.ToString(C_Player.GetPlayerInvItemValue(C_Variables.Myindex, i));
								
								colour = SFML.Graphics.Color.White;
								
								// Draw currency but with k, m, b etc. using a convertion function
								if (long.Parse(amount) < 1000000)
								{
									colour = SFML.Graphics.Color.White;
								}
								else if (long.Parse(amount) > 1000000 && long.Parse(amount) < 10000000)
								{
									colour = SFML.Graphics.Color.Yellow;
								}
								else if (long.Parse(amount) > 10000000)
								{
									colour = SFML.Graphics.Color.Green;
								}
								
								C_Text.DrawText(x, y, C_GameLogic.ConvertCurrency(System.Convert.ToInt32(amount)), colour, SFML.Graphics.Color.Black, GameWindow);
								
							}
						}
					}
				}
NextLoop:
				1.GetHashCode() ;
			}
			
			DrawAnimatedInvItems();
		}
		
		static int DrawAnimatedInvItems_tmr100 = 0;
		
		public static void DrawAnimatedInvItems()
		{
			int i = 0;
			int itemnum = 0;
			int itempic = 0;
			
			int x = 0;
			int y = 0;
			byte maxFrames = 0;
			int amount = 0;
			Rectangle rec = new Rectangle();
			Rectangle recPos = new Rectangle();
			Rectangle[] clearregion = new Rectangle[2];
			if (DrawAnimatedInvItems_tmr100 == 0)
			{
				DrawAnimatedInvItems_tmr100 = C_General.GetTickCount() + 100;
			}
			
			if (!C_Variables.InGame)
			{
				return;
			}
			
			if (C_General.GetTickCount() > DrawAnimatedInvItems_tmr100)
			{
				// check for map animation changes#
				for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
				{
					
					if (C_Maps.MapItem[i].Num > 0)
					{
						itempic = Types.Item[C_Maps.MapItem[i].Num].Pic;
						
						if (itempic < 1 || itempic > NumItems)
						{
							return;
						}
						maxFrames = (byte) (((double) ItemsGfxInfo[itempic].Width / 2) / 32); // Work out how many frames there are. /2 because of inventory icons as well as ingame
						
						if (C_Maps.MapItem[i].Frame < maxFrames - 1)
						{
							C_Maps.MapItem[i].Frame = (byte) (C_Maps.MapItem[i].Frame + 1);
						}
						else
						{
							C_Maps.MapItem[i].Frame = (byte) 1;
						}
					}
				}
			}
			
			for (i = 1; i <= Constants.MAX_INV; i++)
			{
				itemnum = C_Player.GetPlayerInvItemNum(C_Variables.Myindex, i);
				
				if (itemnum > 0 && itemnum <= Constants.MAX_ITEMS)
				{
					itempic = Types.Item[itemnum].Pic;
					if (itempic > 0 && itempic <= NumItems)
					{
						if (ItemsGfxInfo[itempic].Width > 64)
						{
							
							maxFrames = (byte) (((double) ItemsGfxInfo[itempic].Width / 2) / 32); // Work out how many frames there are. /2 because of inventory icons as well as ingame
							
							if (C_General.GetTickCount() > DrawAnimatedInvItems_tmr100)
							{
								if (C_Items.InvItemFrame[i] < maxFrames - 1)
								{
									C_Items.InvItemFrame[i] = (byte) (C_Items.InvItemFrame[i] + 1);
								}
								else
								{
									C_Items.InvItemFrame[i] = (byte) 1;
								}
								DrawAnimatedInvItems_tmr100 = C_General.GetTickCount() + 100;
							}
							
							rec.Y = 0;
							rec.Height = 32;
							rec.X = System.Convert.ToInt32(((double) ItemsGfxInfo[itempic].Width / 2) + (C_Items.InvItemFrame[i] * 32)); // middle to get the start of inv gfx, then +32 for each frame
							rec.Width = 32;
							
							recPos.Y = C_UpdateUI.InvTop + ((C_UpdateUI.InvOffsetY + 32) * ((i - 1) / C_UpdateUI.InvColumns));
							recPos.Height = C_Constants.PicY;
							recPos.X = C_UpdateUI.InvLeft + ((C_UpdateUI.InvOffsetX + 32) * ((i - 1) % C_UpdateUI.InvColumns));
							recPos.Width = C_Constants.PicX;
							
							ref var with_3 = ref clearregion[1];
							with_3.Y = recPos.Y;
							with_3.Height = recPos.Height;
							with_3.X = recPos.X;
							with_3.Width = recPos.Width;
							
							// We'll now re-draw the item, and place the currency value over it again :P
							RenderSprite(ItemsSprite[itempic], GameWindow, recPos.X, recPos.Y, rec.X, rec.Y, rec.Width, rec.Height);
							
							// If item is a stack - draw the amount you have
							if (C_Player.GetPlayerInvItemValue(C_Variables.Myindex, i) > 1)
							{
								y = recPos.Top + 22;
								x = recPos.Left - 4;
								amount = System.Convert.ToInt32(Convert.ToString(C_Player.GetPlayerInvItemValue(C_Variables.Myindex, i)));
								// Draw currency but with k, m, b etc. using a convertion function
								C_Text.DrawText(x, y, C_GameLogic.ConvertCurrency(amount), SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, GameWindow);
								
							}
						}
					}
				}
				
			}
		}
		
		internal static void DrawSkillItem(int x, int y)
		{
			Rectangle rec = new Rectangle();
			int skillnum = 0;
			int skillpic = 0;
			
			skillnum = C_Variables.DragSkillSlotNum;
			
			if (skillnum > 0 && skillnum <= Constants.MAX_SKILLS)
			{
				
				skillpic = Types.Skill[skillnum].Icon;
				if (skillpic == 0)
				{
					return;
				}
				
				if (SkillIconsGfxInfo[skillpic].IsLoaded == false)
				{
					LoadTexture(skillpic, (byte) 9);
				}
				
				//seeying we still use it, lets update timer
				ref var with_1 = ref SkillIconsGfxInfo[skillnum];
				with_1.TextureTimer = C_General.GetTickCount() + 100000;
				
				rec.Y = 0;
				rec.Height = C_Constants.PicY;
				rec.X = 0;
				rec.Width = C_Constants.PicX;
				
				RenderSprite(SkillIconsSprite[skillpic], GameWindow, x + 16, y + 16, rec.X, rec.Y, rec.Width, rec.Height);
			}
		}
		
		public static void DrawPlayerSkills()
		{
			int i = 0;
			int skillnum = 0;
			int skillicon = 0;
			Rectangle rec = new Rectangle();
			Rectangle recPos = new Rectangle();
			
			if (!C_Variables.InGame)
			{
				return;
			}
			
			//first render panel
			RenderSprite(SkillPanelSprite, GameWindow, C_UpdateUI.SkillWindowX, C_UpdateUI.SkillWindowY, 0, 0, SkillPanelGfxInfo.Width, SkillPanelGfxInfo.Height);
			
			for (i = 1; i <= Constants.MAX_PLAYER_SKILLS; i++)
			{
				skillnum = C_Variables.PlayerSkills[i];
				
				if (skillnum > 0 && skillnum <= Constants.MAX_SKILLS)
				{
					skillicon = Types.Skill[skillnum].Icon;
					
					if (skillicon > 0 && skillicon <= NumSkillIcons)
					{
						
						if (SkillIconsGfxInfo[skillicon].IsLoaded == false)
						{
							LoadTexture(skillicon, (byte) 9);
						}
						
						//seeying we still use it, lets update timer
						ref var with_1 = ref SkillIconsGfxInfo[skillicon];
						with_1.TextureTimer = C_General.GetTickCount() + 100000;
						
						rec.Y = 0;
						rec.Height = 32;
						rec.X = 0;
						rec.Width = 32;
						
						if (!(C_Variables.SkillCd[i] == 0))
						{
							rec.X = 32;
							rec.Width = 32;
						}
						
						recPos.Y = C_UpdateUI.SkillWindowY + C_UpdateUI.SkillTop + ((C_UpdateUI.SkillOffsetY + 32) * ((i - 1) / C_UpdateUI.SkillColumns));
						recPos.Height = C_Constants.PicY;
						recPos.X = C_UpdateUI.SkillWindowX + C_UpdateUI.SkillLeft + ((C_UpdateUI.SkillOffsetX + 32) * ((i - 1) % C_UpdateUI.SkillColumns));
						recPos.Width = C_Constants.PicX;
						
						RenderSprite(SkillIconsSprite[skillicon], GameWindow, recPos.X, recPos.Y, rec.X, rec.Y, rec.Width, rec.Height);
					}
				}
			}
			
		}
		
		internal static SFML.Graphics.Color ToSfmlColor(System.Drawing.Color toConvert)
		{
			return new SFML.Graphics.Color(toConvert.R, toConvert.G, toConvert.G, toConvert.A);
		}
		
		internal static void DrawTarget(int x2, int y2)
		{
			Rectangle rec = new Rectangle();
			int x = 0;
			int y = 0;
			int width;
			int height;
			
			rec.Y = 0;
			rec.Height = TargetGfxInfo.Height;
			rec.X = 0;
			rec.Width = System.Convert.ToInt32((double) TargetGfxInfo.Width / 2);
			
			x = ConvertMapX(x2);
			y = ConvertMapY(y2);
			width = rec.Right - rec.Left;
			height = rec.Bottom - rec.Top;
			
			RenderSprite(TargetSprite, GameWindow, x, y, rec.X, rec.Y, rec.Width, rec.Height);
		}
		
		internal static void DrawHover(int x2, int y2)
		{
			Rectangle rec = new Rectangle();
			int x = 0;
			int y = 0;
			int width;
			int height;
			
			rec.Y = 0;
			rec.Height = TargetGfxInfo.Height;
			rec.X = System.Convert.ToInt32((double) TargetGfxInfo.Width / 2);
			rec.Width = System.Convert.ToInt32((double) TargetGfxInfo.Width / 2 + (double) TargetGfxInfo.Width / 2);
			
			x = ConvertMapX(x2);
			y = ConvertMapY(y2);
			width = rec.Right - rec.Left;
			height = rec.Bottom - rec.Top;
			
			RenderSprite(TargetSprite, GameWindow, x, y, rec.X, rec.Y, rec.Width, rec.Height);
		}
		
		internal static void DrawItemDesc()
		{
			int xoffset = 0;
			int yoffset = 0;
			int y = 0;
			
			y = 0;
			
			if (C_UpdateUI.PnlCharacterVisible == true)
			{
				xoffset = C_UpdateUI.CharWindowX;
				yoffset = C_UpdateUI.CharWindowY;
			}
			if (C_UpdateUI.PnlInventoryVisible == true)
			{
				xoffset = C_UpdateUI.InvWindowX;
				yoffset = C_UpdateUI.InvWindowY;
			}
			if (C_UpdateUI.PnlBankVisible == true)
			{
				xoffset = C_UpdateUI.BankWindowX;
				yoffset = C_UpdateUI.BankWindowY;
			}
			if (C_UpdateUI.PnlShopVisible == true)
			{
				xoffset = C_UpdateUI.ShopWindowX;
				yoffset = C_UpdateUI.ShopWindowY;
			}
			if (C_UpdateUI.PnlTradeVisible == true)
			{
				xoffset = C_UpdateUI.TradeWindowX;
				yoffset = C_UpdateUI.TradeWindowY;
			}
			
			//first render panel
			RenderSprite(DescriptionSprite, GameWindow, xoffset - DescriptionGfxInfo.Width, yoffset, 0, 0, DescriptionGfxInfo.Width, DescriptionGfxInfo.Height);
			
			//name
			foreach (string str in C_Text.WordWrap(C_UpdateUI.ItemDescName, 22, C_Text.WrapMode.Characters, C_Text.WrapType.BreakWord, 13))
			{
				//description
				C_Text.DrawText(xoffset - DescriptionGfxInfo.Width + 10, yoffset + 12 + y, str, C_UpdateUI.ItemDescRarityColor, C_UpdateUI.ItemDescRarityBackColor, GameWindow);
				y = y + 15;
			}
			
			if (C_Variables.ShiftDown || C_UpdateUI.VbKeyShift == true)
			{
				//info
				C_Text.DrawText(xoffset - DescriptionGfxInfo.Width + 10, yoffset + 56, C_UpdateUI.ItemDescInfo, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
				
				//cost
				//DrawText(Xoffset - DescriptionGFXInfo.width + 10, Yoffset + 74, "Worth: " & ItemDescCost, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
				//type
				//DrawText(Xoffset - DescriptionGFXInfo.width + 10, Yoffset + 90, "Type: " & ItemDescType, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow)
				//speed
				C_Text.DrawText(xoffset - DescriptionGfxInfo.Width + 10, yoffset + 74, "Speed: " + C_UpdateUI.ItemDescSpeed, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
				//level
				C_Text.DrawText(xoffset - DescriptionGfxInfo.Width + 10, yoffset + 90, "Level required: " + C_UpdateUI.ItemDescLevel, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
				//bonuses
				C_Text.DrawText(xoffset - DescriptionGfxInfo.Width + 10, yoffset + 118, "=Bonuses=", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
				//strength
				C_Text.DrawText(xoffset - DescriptionGfxInfo.Width + 10, yoffset + 134, "Strenght: " + C_UpdateUI.ItemDescStr, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
				//vitality
				C_Text.DrawText(xoffset - DescriptionGfxInfo.Width + 10, yoffset + 150, "Vitality: " + C_UpdateUI.ItemDescVit, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
				//intelligence
				C_Text.DrawText(xoffset - DescriptionGfxInfo.Width + 10, yoffset + 166, "Intelligence: " + C_UpdateUI.ItemDescInt, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
				//endurance
				C_Text.DrawText(xoffset - DescriptionGfxInfo.Width + 10, yoffset + 182, "Endurance: " + C_UpdateUI.ItemDescEnd, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
				//luck
				C_Text.DrawText(xoffset - DescriptionGfxInfo.Width + 10, yoffset + 198, "Luck: " + C_UpdateUI.ItemDescLuck, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
				//spirit
				C_Text.DrawText(xoffset - DescriptionGfxInfo.Width + 10, yoffset + 214, "Spirit: " + C_UpdateUI.ItemDescSpr, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			}
			else
			{
				foreach (string str in C_Text.WordWrap(C_UpdateUI.ItemDescDescription, 22, C_Text.WrapMode.Characters, C_Text.WrapType.BreakWord, 13))
				{
					//description
					C_Text.DrawText(xoffset - DescriptionGfxInfo.Width + 10, yoffset + 44 + y, str, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
					y = y + 15;
				}
			}
			
		}
		
		internal static void DrawSkillDesc()
		{
			//first render panel
			RenderSprite(DescriptionSprite, GameWindow, C_UpdateUI.SkillWindowX - DescriptionGfxInfo.Width, C_UpdateUI.SkillWindowY, 0, 0, DescriptionGfxInfo.Width, DescriptionGfxInfo.Height);
			
			//name
			C_Text.DrawText(C_UpdateUI.SkillWindowX - DescriptionGfxInfo.Width + 10, C_UpdateUI.SkillWindowY + 12, C_UpdateUI.SkillDescName, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//type
			C_Text.DrawText(C_UpdateUI.SkillWindowX - DescriptionGfxInfo.Width + 10, C_UpdateUI.SkillWindowY + 28, C_UpdateUI.SkillDescInfo, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//cast time
			C_Text.DrawText(C_UpdateUI.SkillWindowX - DescriptionGfxInfo.Width + 10, C_UpdateUI.SkillWindowY + 44, "Cast Time: " + C_UpdateUI.SkillDescCastTime, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//cool down
			C_Text.DrawText(C_UpdateUI.SkillWindowX - DescriptionGfxInfo.Width + 10, C_UpdateUI.SkillWindowY + 58, "CoolDown: " + C_UpdateUI.SkillDescCoolDown, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//Damage
			C_Text.DrawText(C_UpdateUI.SkillWindowX - DescriptionGfxInfo.Width + 10, C_UpdateUI.SkillWindowY + 74, "Damage: " + C_UpdateUI.SkillDescDamage, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//AOE
			C_Text.DrawText(C_UpdateUI.SkillWindowX - DescriptionGfxInfo.Width + 10, C_UpdateUI.SkillWindowY + 90, "Aoe: " + C_UpdateUI.SkillDescAoe, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//range
			C_Text.DrawText(C_UpdateUI.SkillWindowX - DescriptionGfxInfo.Width + 10, C_UpdateUI.SkillWindowY + 104, "Range: " + C_UpdateUI.SkillDescRange, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			
			//requirements
			C_Text.DrawText(C_UpdateUI.SkillWindowX - DescriptionGfxInfo.Width + 10, C_UpdateUI.SkillWindowY + 128, "=Requirements=", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//Mp
			C_Text.DrawText(C_UpdateUI.SkillWindowX - DescriptionGfxInfo.Width + 10, C_UpdateUI.SkillWindowY + 144, "MP: " + C_UpdateUI.SkillDescReqMp, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//level
			C_Text.DrawText(C_UpdateUI.SkillWindowX - DescriptionGfxInfo.Width + 10, C_UpdateUI.SkillWindowY + 160, "Level: " + C_UpdateUI.SkillDescReqLvl, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//Access
			C_Text.DrawText(C_UpdateUI.SkillWindowX - DescriptionGfxInfo.Width + 10, C_UpdateUI.SkillWindowY + 176, "Access: " + C_UpdateUI.SkillDescReqAccess, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			//Class
			C_Text.DrawText(C_UpdateUI.SkillWindowX - DescriptionGfxInfo.Width + 10, C_UpdateUI.SkillWindowY + 192, "Class: " + C_UpdateUI.SkillDescReqClass, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			
		}
		
		internal static void DrawDialogPanel()
		{
			//first render panel
			RenderSprite(EventChatSprite, GameWindow, C_UpdateUI.DialogPanelX, C_UpdateUI.DialogPanelY, 0, 0, EventChatGfxInfo.Width, EventChatGfxInfo.Height);
			
			C_Text.DrawText(C_UpdateUI.DialogPanelX + 175, C_UpdateUI.DialogPanelY + 10, C_Variables.DialogMsg1.Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			
			if (C_Variables.DialogMsg2.Length > 0)
			{
				C_Text.DrawText(C_UpdateUI.DialogPanelX + 60, C_UpdateUI.DialogPanelY + 30, C_Variables.DialogMsg2.Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			}
			
			if (C_Variables.DialogMsg3.Length > 0)
			{
				C_Text.DrawText(C_UpdateUI.DialogPanelX + 60, C_UpdateUI.DialogPanelY + 50, C_Variables.DialogMsg3.Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			}
			
			if (C_Variables.DialogType == C_Constants.DialogueTypeQuest)
			{
				if (C_Quest.QuestAcceptTag > 0)
				{
					//render accept button
					DrawButton(C_Variables.DialogButton1Text, C_UpdateUI.DialogPanelX + C_UpdateUI.OkButtonX, C_UpdateUI.DialogPanelY + C_UpdateUI.OkButtonY, (byte) 0);
					DrawButton(C_Variables.DialogButton2Text, C_UpdateUI.DialogPanelX + C_UpdateUI.CancelButtonX, C_UpdateUI.DialogPanelY + C_UpdateUI.CancelButtonY, (byte) 0);
				}
				else
				{
					//render cancel button
					DrawButton(C_Variables.DialogButton2Text, C_UpdateUI.DialogPanelX + C_UpdateUI.CancelButtonX - 140, C_UpdateUI.DialogPanelY + C_UpdateUI.CancelButtonY, (byte) 0);
				}
			}
			else
			{
				//render ok button
				DrawButton(C_Variables.DialogButton1Text, C_UpdateUI.DialogPanelX + C_UpdateUI.OkButtonX, C_UpdateUI.DialogPanelY + C_UpdateUI.OkButtonY, (byte) 0);
				
				//render cancel button
				DrawButton(C_Variables.DialogButton2Text, C_UpdateUI.DialogPanelX + C_UpdateUI.CancelButtonX, C_UpdateUI.DialogPanelY + C_UpdateUI.CancelButtonY, (byte) 0);
			}
			
		}
		
		internal static void DrawRClick()
		{
			//first render panel
			RenderSprite(RClickSprite, GameWindow, C_UpdateUI.RClickX, C_UpdateUI.RClickY, 0, 0, RClickGfxInfo.Width, RClickGfxInfo.Height);
			
			C_Text.DrawText(C_UpdateUI.RClickX + (RClickGfxInfo.Width / 2) - (C_Text.GetTextWidth(C_UpdateUI.RClickname) / 2), C_UpdateUI.RClickY + 10, C_UpdateUI.RClickname, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			
			C_Text.DrawText(C_UpdateUI.RClickX + (RClickGfxInfo.Width / 2) - (C_Text.GetTextWidth("Invite to Trade") / 2), C_UpdateUI.RClickY + 35, "Invite to Trade", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			
			C_Text.DrawText(C_UpdateUI.RClickX + (RClickGfxInfo.Width / 2) - (C_Text.GetTextWidth("Invite to Party") / 2), C_UpdateUI.RClickY + 60, "Invite to Party", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			
			C_Text.DrawText(C_UpdateUI.RClickX + (RClickGfxInfo.Width / 2) - (C_Text.GetTextWidth("Invite to House") / 2), C_UpdateUI.RClickY + 85, "Invite to House", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, GameWindow);
			
		}
		
		internal static void DrawGui()
		{
			//hide GUI when mapping...
			if (C_Variables.HideGui == true)
			{
				return;
			}
			
			if (C_UpdateUI.HudVisible == true)
			{
				DrawHud();
				DrawActionPanel();
				DrawChat();
				C_HotBar.DrawHotbar();
				C_Pets.DrawPetBar();
				C_Pets.DrawPetStats();
			}
			
			if (C_UpdateUI.PnlCharacterVisible == true)
			{
				DrawEquipment();
				if (C_UpdateUI.ShowItemDesc == true)
				{
					DrawItemDesc();
				}
			}
			
			if (C_UpdateUI.PnlInventoryVisible == true)
			{
				DrawInventory();
				if (C_UpdateUI.ShowItemDesc == true)
				{
					DrawItemDesc();
				}
			}
			
			if (C_UpdateUI.PnlSkillsVisible == true)
			{
				DrawPlayerSkills();
				if (C_UpdateUI.ShowSkillDesc == true)
				{
					DrawSkillDesc();
				}
			}
			
			if (C_UpdateUI.DialogPanelVisible == true)
			{
				DrawDialogPanel();
			}
			
			if (C_UpdateUI.PnlBankVisible == true)
			{
				C_Banks.DrawBank();
			}
			
			if (C_UpdateUI.PnlShopVisible == true)
			{
				C_Shops.DrawShop();
			}
			
			if (C_UpdateUI.PnlTradeVisible == true)
			{
				C_Trade.DrawTrade();
			}
			
			if (C_UpdateUI.PnlEventChatVisible == true)
			{
				C_EventSystem.DrawEventChat();
			}
			
			if (C_UpdateUI.PnlRClickVisible == true)
			{
				DrawRClick();
			}
			
			if (C_Quest.PnlQuestLogVisible == true)
			{
				C_Quest.DrawQuestLog();
			}
			
			if (C_Crafting.PnlCraftVisible == true)
			{
				C_Crafting.DrawCraftPanel();
			}
			
			if (C_Items.DragInvSlotNum > 0)
			{
				DrawInventoryItem(C_Variables.CurMouseX, C_Variables.CurMouseY);
			}
			
			if (C_Banks.DragBankSlotNum > 0)
			{
				C_Banks.DrawBankItem(C_Variables.CurMouseX, C_Variables.CurMouseY);
			}
			
			if (C_Variables.DragSkillSlotNum > 0)
			{
				DrawSkillItem(C_Variables.CurMouseX, C_Variables.CurMouseY);
			}
			
			//draw cursor
			//DrawCursor()
		}
		
		public static void DrawNight()
		{
			int x = 0;
			int y = 0;
			
			if (C_Maps.Map.Moral == (byte)Enums.MapMoralType.Indoors)
			{
                NightGfx.Clear(new SFML.Graphics.Color((byte)0, (byte)0, (byte)0, (byte)C_Maps.Map.Brightness));
                //return;
			}

            if (C_Maps.Map.Brightness > 0)
            {
                NightGfx.Clear(new SFML.Graphics.Color((byte)0, (byte)0, (byte)0, (byte)C_Maps.Map.Brightness));
            }
            else if (Time.Instance.TimeOfDay == TimeOfDay.Dawn)
			{
                NightGfx.Clear(new SFML.Graphics.Color((byte)0, (byte)0, (byte)0, (byte)100));
            }
			else if (Time.Instance.TimeOfDay == TimeOfDay.Dusk)
			{
                NightGfx.Clear(new SFML.Graphics.Color((byte)0, (byte)0, (byte)0, (byte)150));
            }
			else if (Time.Instance.TimeOfDay == TimeOfDay.Night)
			{
                NightGfx.Clear(new SFML.Graphics.Color((byte)0, (byte)0, (byte)0, (byte)200));
            }
			else
			{
				return;
			}
			
			for (x = C_Variables.TileView.Left - 4; x <= C_Variables.TileView.Right + 5; x++)
			{
				for (y = C_Variables.TileView.Top - 4; y <= C_Variables.TileView.Bottom + 5; y++)
				{
					if (IsValidMapPoint(x, y))
					{
                        if (C_Maps.Map.Tile[x, y].Type == (byte)Enums.TileType.Light)
                        {
							var x1 = ConvertMapX(x * 32) + 16 - (double) LightGfxInfo.Width / 2;
							var y1 = ConvertMapY(y * 32) + 16 - (double) LightGfxInfo.Height / 2;
							
							//Create the light texture to multiply over the dark texture.
							LightSprite.Position = new Vector2f((float) x1, (float) y1);
							LightSprite.Color = SFML.Graphics.Color.Red;
                            LightSprite.Scale = new Vector2f(1, 1);

                            NightGfx.Draw(LightSprite, new RenderStates(BlendMode.Multiply));
						}

                        //Comment out this entire IF statement to remove the Light around players
                        if(x == C_Types.Player[C_Variables.Myindex].X && y == C_Types.Player[C_Variables.Myindex].Y)
                        {

                            var x1 = ConvertMapX(x * 32) + 56 + C_Types.Player[C_Variables.Myindex].XOffset - (double)LightGfxInfo.Width / 2;
                            var y1 = ConvertMapY(y * 32) + 56 + C_Types.Player[C_Variables.Myindex].YOffset - (double)LightGfxInfo.Height / 2;

                            //Create the light texture to multiply over the dark texture.
                            LightSprite.Position = new Vector2f((float)x1, (float)y1);
                            LightSprite.Color = SFML.Graphics.Color.Red;
                            LightSprite.Scale = new Vector2f(0.7f, 0.7f);
                            NightGfx.Draw(LightSprite, new RenderStates(BlendMode.Multiply));

                        }
					}
				}
			}
			
			NightSprite = new Sprite(NightGfx.Texture);
			
			NightGfx.Display();
			GameWindow.Draw(NightSprite);
		}

		public static void DrawCursor()
		{
			RenderSprite(CursorSprite, GameWindow, C_Variables.CurMouseX, C_Variables.CurMouseY, 0, 0, CursorInfo.Width, CursorInfo.Height);
		}
		
	}
}
