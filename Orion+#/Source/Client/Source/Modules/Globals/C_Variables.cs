
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using Engine;


namespace Engine
{
	sealed class C_Variables
	{
		
		//char creation/selecting
		internal static byte SelectedChar;
		
		internal static byte MaxChars;
		
		internal static int TotalOnline;
		
		// for directional blocking
		internal static byte[] DirArrowX = new byte[5];
		
		internal static byte[] DirArrowY = new byte[5];
		
		internal static byte LastTileset;
		
		internal static bool UseFade;
		internal static int FadeType;
		internal static int FadeAmount;
		internal static int FlashTimer;
		
		// targetting
		internal static int MyTarget;
		
		internal static int MyTargetType;
		
		// chat bubble
		internal static C_Types.ChatBubbleRec[] ChatBubble = new C_Types.ChatBubbleRec[byte.MaxValue + 1];
		
		internal static int ChatBubbleindex;
		
		// skill drag + drop
		internal static int DragSkillSlotNum;
		
		internal static int SkillX;
		internal static int SkillY;
		
		// gui
		internal static int EqX;
		
		internal static int EqY;
		internal static int Fps;
		internal static int Lps;
		internal static string PingToDraw;
		internal static bool ShowRClick;
		
		internal static int LastSkillDesc; // Stores the last skill we showed in desc
		
		internal static int TmpCurrencyItem;
		
		internal static byte CurrencyMenu;
		internal static bool HideGui;
		
		// Player variables
		internal static int Myindex; // Index of actual player
		
		internal static Types.PlayerInvRec[] PlayerInv = new Types.PlayerInvRec[Constants.MAX_INV + 1]; // Inventory
		internal static byte[] PlayerSkills = new byte[Constants.MAX_PLAYER_SKILLS + 1];
		internal static int InventoryItemSelected;
		internal static int SkillBuffer;
		internal static int SkillBufferTimer;
		internal static int[] SkillCd = new int[Constants.MAX_PLAYER_SKILLS + 1];
		internal static int StunDuration;
		internal static int NextlevelExp;
		
		// Stops movement when updating a map
		internal static bool CanMoveNow;
		
		// Controls main gameloop
		internal static bool InGame;
		
		internal static bool IsLogging;
		internal static bool MapData;
		internal static bool PlayerData;
		
		// Text variables
		
		// Draw map name location
		internal static float DrawMapNameX = 110;
		
		internal static float DrawMapNameY = 70;
		internal static SFML.Graphics.Color DrawMapNameColor;
		
		// Game direction vars
		internal static bool DirUp;
		
		internal static bool DirDown;
		internal static bool DirLeft;
		internal static bool DirRight;

        // 8 Directional Movement
        internal static bool DirUpLeft;
        internal static bool DirUpRight;
        internal static bool DirDownLeft;
        internal static bool DirDownRight;


        internal static bool ShiftDown;
		internal static bool ControlDown;
		
		// Used for dragging Picture Boxes
		internal static int SOffsetX;
		
		internal static int SOffsetY;
		
		// Used to freeze controls when getting a new map
		internal static bool GettingMap;
		
		// Used to check if FPS needs to be drawn
		internal static bool Bfps;
		
		internal static bool Blps;
		internal static bool BLoc;
		
		// FPS and Time-based movement vars
		internal static double ElapsedTime;
		
		internal static int GameFps;
		internal static int GameLps;
		
		// Text vars
		internal static string VbQuote;
		
		// Mouse cursor tile location
		internal static int CurX;
		
		internal static int CurY;
		internal static int CurMouseX;
		internal static int CurMouseY;
		
		// Game editors
		internal static byte Editor;
		
		internal static int Editorindex;
		
		// Used to check if in editor or not and variables for use in editor
		internal static int SpawnNpcNum;
		
		internal static byte SpawnNpcDir;
		
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

        // Used for map editor light tiles
		internal static int MapEditorLightRadius;
		internal static bool MapEditorLightFlicker;
		internal static bool MapEditorLightShadows;
		
		// Maximum classes
		internal static byte MaxClasses;
		
		internal static Rectangle Camera;
		internal static Types.Rect TileView;
		
		// Pinging
		internal static int PingStart;
		
		internal static int PingEnd;
		internal static int Ping;
		
		// indexing
		internal static byte ActionMsgIndex;
		
		internal static byte BloodIndex;
		internal static byte AnimationIndex;
		
		// New char
		internal static int NewCharSprite;
		
		internal static int NewCharClass;
		
		internal static byte[] TempMapData;
		
		//dialog
		internal static byte DialogType;
		
		internal static string DialogMsg1;
		internal static string DialogMsg2;
		internal static string DialogMsg3;
		internal static bool UpdateDialog;
		internal static string DialogButton1Text;
		internal static string DialogButton2Text;
		
		//store news here
		internal static string News;
		
		internal static bool UpdateNews;

        //Server side game settings
		internal static bool allowEightDirectionalMovement;
		internal static bool useSmoothDynamicLightRendering;
		
		internal static bool ShakeTimerEnabled;
		internal static int ShakeTimer;
		internal static byte ShakeCount;
		internal static byte LastDir;
		
		internal static bool ShowAnimLayers;
		internal static int ShowAnimTimer;
		
		internal static Asfw.IO.Encryption.KeyPair EKeyPair = new Asfw.IO.Encryption.KeyPair();
	}
}
