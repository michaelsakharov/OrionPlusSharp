using System.Drawing;

namespace Engine
{
	sealed class C_Constants
	{
		
		//Chatbubble
		internal const int ChatBubbleWidth = 100;
		
		internal const int EffectTypeFadein = 1;
		internal const int EffectTypeFadeout = 2;
		internal const int EffectTypeFlash = 3;
		internal const int EffectTypeFog = 4;
		internal const int EffectTypeWeather = 5;
		internal const int EffectTypeTint = 6;
		
		// path constants
		internal const string SoundPath = "\\Data\\sound\\";
		
		internal const string MusicPath = "\\Data\\music\\";
		
		// Font variables
		internal const string FontName = "Arial.ttf";
		
		internal const byte FontSize = 13;
		
		// Log Path and variables
		internal const string LogDebug = "debug.txt";
		
		internal const string LogPath = "\\Data\\logs\\";
		
		// Gfx Path and variables
		internal const string GfxPath = "\\Data\\graphics\\";
		
		internal const string GfxGuiPath = "\\Data\\graphics\\gui\\";
		internal const string GfxExt = ".png";
		
		// Menu states
		internal const byte MenuStateNewaccount = 0;
		
		internal const byte MenuStateDelaccount = 1;
		internal const byte MenuStateLogin = 2;
		internal const byte MenuStateGetchars = 3;
		internal const byte MenuStateNewchar = 4;
		internal const byte MenuStateAddchar = 5;
		internal const byte MenuStateDelchar = 6;
		internal const byte MenuStateUsechar = 7;
		internal const byte MenuStateInit = 8;
		
		// Number of tiles in width in tilesets
		internal const int TilesheetWidth = 15; // * PicX pixels
		
		internal static bool MapGrid;
		
		// Speed moving vars
		internal const byte WalkSpeed = 6;
		
		internal const byte RunSpeed = 10;
		
		// Tile size constants
		internal const int PicX = 32;
		
		internal const int PicY = 32;
		
		// Sprite, item, skill size constants
		internal const int SizeX = 32;
		
		internal const int SizeY = 32;
		
		// ********************************************************
		// * The values below must match with the server's values *
		// ********************************************************
		
		// General constants
		internal static string GameName = "Lupus";
		
		// Website
		internal const string GameWebsite = "http://ascensiongamedev.com/index.php";
		
		// Map constants
		internal static byte ScreenMapx = (byte) 35;
		
		internal static byte ScreenMapy = (byte) 26;
		
		internal static SFML.Graphics.Color ItemRarityColor0 = SFML.Graphics.Color.White; // white
		internal static System.Object ItemRarityColor1 = new SFML.Graphics.Color(102, 255, 0); // green
		internal static System.Object ItemRarityColor2 = new SFML.Graphics.Color(73, 151, 208); // blue
		internal static System.Object ItemRarityColor3 = new SFML.Graphics.Color(255, 0, 0); // red
		internal static System.Object ItemRarityColor4 = new SFML.Graphics.Color(159, 0, 197); // purple
		internal static System.Object ItemRarityColor5 = new SFML.Graphics.Color(255, 215, 0); // gold
		
		// Used to check if in editor or not and variables for use in editor
		public static bool InMapEditor;
		
		public static int EditorTileX;
		public static int EditorTileY;
		public static int EditorTileWidth;
		public static int EditorTileHeight;
		public static int EditorWarpMap;
		public static int EditorWarpX;
		public static int EditorWarpY;
		public static int EditorShop;
		public static Point EditorTileSelStart;
		public static Point EditorTileSelEnd;
		
		internal static int HalfX = System.Convert.ToInt32((((byte) 35 + 1) / 2) * PicX);
		internal static int HalfY = System.Convert.ToInt32((((byte) 26 + 1) / 2) * PicY);
		internal static int ScreenX = ((byte) 35 + 1) * PicX;
		internal static int ScreenY = ((byte) 26 + 1) * PicY;
		
		//dialog types
		internal const byte DialogueTypeBuyhome = 1;
		
		internal const byte DialogueTypeVisit = 2;
		internal const byte DialogueTypeParty = 3;
		internal const byte DialogueTypeQuest = 4;
		internal const byte DialogueTypeTrade = 5;
		
	}
}
