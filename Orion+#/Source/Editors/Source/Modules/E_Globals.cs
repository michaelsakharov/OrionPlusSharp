using System.Drawing;

namespace Engine
{
    static class E_Globals
    {
        internal const int INSTANCED_MAP_MASK = 16777216; // 1 << 24
        internal const int MAP_NUMBER_MASK = INSTANCED_MAP_MASK - 1;

        internal static byte SelectedTab;
        internal static bool HideCursor;
        internal static bool TakeScreenShot;
        internal static int ScreenShotTimer;
        internal static bool MakeCache;
        internal static int FPS;

        internal static bool GameStarted;
        internal static bool GameDestroyed;

        internal static SFML.Graphics.Color[] TilesetsClr;
        internal static byte LastTileset;

        // Gfx Path and variables
        internal const string GFX_PATH = @"\Data\graphics\";

        internal const string GFX_GUI_PATH = @"\Data\graphics\gui\";
        internal const string GFX_EXT = ".png";

        // path constants
        internal const string SOUND_PATH = @"\Data\sound\";

        internal const string MUSIC_PATH = @"\Data\music\";

        internal static byte Max_Classes;

        internal static bool MapData;

        // Cache the Resources in an array
        internal static E_Types.MapResourceRec[] MapResource;

        internal static int Resource_index;
        internal static bool Resources_Init;

        // fog
        internal static int fogOffsetX;

        internal static int fogOffsetY;

        internal static int CurrentWeather;
        internal static int CurrentWeatherIntensity;
        internal static int CurrentFog;
        internal static int CurrentFogSpeed;
        internal static int CurrentFogOpacity;
        internal static int CurrentTintR;
        internal static int CurrentTintG;
        internal static int CurrentTintB;
        internal static int CurrentTintA;
        internal static int DrawThunder;

        // Editor edited items array
        internal static bool[] Item_Changed = new bool[501];

        internal static bool[] NPC_Changed = new bool[501];
        internal static bool[] Resource_Changed = new bool[501];
        internal static bool[] Animation_Changed = new bool[501];
        internal static bool[] Skill_Changed = new bool[256];
        internal static bool[] Shop_Changed = new bool[51];

        // Editors
        internal static bool InitEditor;

        internal static bool InitMapEditor;
        internal static bool InitItemEditor;
        internal static bool InitResourceEditor;
        internal static bool InitNPCEditor;
        internal static bool InitSkillEditor;
        internal static bool InitShopEditor;
        internal static bool InitAnimationEditor;
        internal static bool InitClassEditor;
        internal static bool InitAutoMapper;

        internal static bool InitMapProperties;

        // Game editor constants
        internal const byte EDITOR_ITEM = 1;

        internal const byte EDITOR_NPC = 2;
        internal const byte EDITOR_SKILL = 3;
        internal const byte EDITOR_SHOP = 4;
        internal const byte EDITOR_RESOURCE = 5;
        internal const byte EDITOR_ANIMATION = 6;
        internal const byte EDITOR_QUEST = 7;
        internal const byte EDITOR_HOUSE = 8;
        internal const byte EDITOR_RECIPE = 9;
        internal const byte EDITOR_CLASSES = 10;

        // Mapreport
        internal static bool UpdateMapnames;

        // Game editors
        internal static byte Editor;

        internal static int Editorindex;
        internal static int[] AnimEditorFrame = new int[2];
        internal static int[] AnimEditorTimer = new int[2];

        // Used to check if in editor or not and variables for use in editor
        internal static bool InMapEditor;

        internal static int EditorTileX;
        internal static int EditorViewX;
        internal static int EditorViewY;
        internal static int EditorTileY;
        internal static int EditorTileWidth;
        internal static int EditorTileHeight;
        internal static int EditorWarpMap;
        internal static int EditorWarpX;
        internal static int EditorWarpY;
        internal static int SpawnNpcNum;
        internal static byte SpawnNpcDir;
        internal static int EditorShop;
        internal static Point EditorTileSelStart;
        internal static Point EditorTileSelEnd;

        // Used for map item editor
        internal static int ItemEditorNum;

        internal static int ItemEditorValue;

        // Used for map key editor
        internal static int KeyEditorNum;

        internal static int KeyEditorTake;

        // Used for map key open editor
        internal static int KeyOpenEditorX;

        internal static int KeyOpenEditorY;

        // Map Resources
        internal static int ResourceEditorNum;

        // Used for map editor heal & trap & slide tiles
        internal static int MapEditorHealType;

        internal static int MapEditorHealAmount;
        internal static int MapEditorSlideDir;

        // Map constants
        internal static byte SCREEN_MAPX = 35;

        internal static byte SCREEN_MAPY = 26;

        // Used to freeze controls when getting a new map
        internal static bool GettingMap;

        // Font variables
        internal const string FONT_NAME = "Arial.ttf";

        internal const byte FONT_SIZE = 13;

        // Tile size constants
        internal const int PIC_X = 32;

        internal const int PIC_Y = 32;

        // Sprite, item, skill size constants
        internal const int SIZE_X = 32;

        internal const int SIZE_Y = 32;

        // Graphics
        internal const int FPS_LIMIT = 64;

        internal static Rectangle Camera;
        internal static Types.Rect TileView;

        // for directional blocking
        internal static byte[] DirArrowX = new byte[5];

        internal static byte[] DirArrowY = new byte[5];

        internal static int HalfX = ((SCREEN_MAPX + 1) / 2) * PIC_X;
        internal static int HalfY = ((SCREEN_MAPY + 1) / 2) * PIC_Y;
        internal static int ScreenX = (SCREEN_MAPX + 1) * PIC_X;
        internal static int ScreenY = (SCREEN_MAPY + 1) * PIC_Y;

        // Number of tiles in width in tilesets
        internal const int TILESHEET_WIDTH = 15; // * PIC_X pixels

        internal static bool MapGrid;

        // Mouse cursor tile location
        internal static int CurX;

        internal static int CurY;
        internal static int CurMouseX;
        internal static int CurMouseY;

        // Draw map name location
        internal static float DrawMapNameX;

        internal static float DrawMapNameY;
        internal static SFML.Graphics.Color DrawMapNameColor;

        internal static bool LoadClassInfo;

        internal static ASFW.IO.Encryption.KeyPair EKeyPair = new ASFW.IO.Encryption.KeyPair();
    }
}
