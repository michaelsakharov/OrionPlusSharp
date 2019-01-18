
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using Engine;

namespace Engine
{
	sealed class C_Types
	{
		
		// options
		internal static C_Options Options = new C_Options();
		
		// Friend data structures
		internal static PlayerRec[] Player = new PlayerRec[Constants.MAX_PLAYERS + 1];
		
		// client-side stuff
		internal static ActionMsgRec[] ActionMsg = new ActionMsgRec[byte.MaxValue + 1];
		
		internal static BloodRec[] Blood = new BloodRec[byte.MaxValue + 1];
		internal static Types.AnimInstanceRec[] AnimInstance = new Types.AnimInstanceRec[byte.MaxValue + 1];
		internal static List<ChatRec> Chat = new List<ChatRec>();
		
		//Mapreport
		internal static string[] MapNames = new string[Constants.MAX_MAPS + 1];
		
		internal static CharSelRec[] CharSelection;
		
		public struct CharSelRec
		{
			public string Name;
			public int Sprite;
			public int Gender;
			public string ClassName;
			public int Level;
		}
		
		public struct ChatRec
		{
			public string Text;
			public int Color;
			public byte Y;
		}
		
		public struct SkillAnim
		{
			public int Skillnum;
			public int Timer;
			public int FramePointer;
		}
		
		public struct PlayerRec
		{
			
			// General
			public string Name;
			
			public byte Classes;
			public int Sprite;
			public byte Level;
			public int Exp;
			public byte Access;
			public byte Pk;
			
			// Vitals
			public int[] Vital;
			
			// Stats
			public byte[] Stat;
			
			public byte Points;
			
			// Worn equipment
			public int[] Equipment;
			
			// Position
			public int Map;
			
			public byte X;
			public byte Y;
			public byte Dir;
			
			// Client use only
			public int MaxHp;
			
			public int MaxMp;
			public int MaxSp;
			public int XOffset;
			public int YOffset;
			public byte Moving;
			public byte Attacking;
			public int AttackTimer;
			public int MapGetTimer;
			public byte Steps;
			
			public int Emote;
			public int EmoteTimer;
			
			public C_Quest.PlayerQuestRec[] PlayerQuest;
			
			//Housing
			public C_Housing.PlayerHouseRec House;
			
			public int InHouse;
			public int LastMap;
			public int LastX;
			public int LastY;
			
			public C_HotBar.HotbarRec[] Hotbar;
			
			public int EventTimer;
			
			//gather skills
			public Types.ResourceSkillsRec[] GatherSkills;
			
			public byte[] RecipeLearned;
			
			// Random Items
			public Types.RandInvRec[] RandInv;
			
			public Types.RandInvRec[] RandEquip;
			
			public C_Pets.PlayerPetRec Pet;
		}
		
		public struct MapRec
		{
			public string Name;
			public string Music;
			
			public int Revision;
			public byte Moral;
			public int Tileset;
			
			public int Up;
			public int Down;
			public int Left;
			public int Right;
			
			public int BootMap;
			public byte BootX;
			public byte BootY;
			
			public byte MaxX;
			public byte MaxY;
			
			public Types.TileRec[,] Tile;
			public int[] Npc;
			public int EventCount;
			public C_EventSystem.EventRec[] Events;
			
			public byte WeatherType;
			public int Fogindex;
			public int WeatherIntensity;
			public byte FogAlpha;
			public byte FogSpeed;
			
			public byte HasMapTint;
			public byte MapTintR;
			public byte MapTintG;
			public byte MapTintB;
			public byte MapTintA;
			
			public byte Instanced;
			
			public byte Panorama;
			public byte Parallax;

            public byte Brightness;
			
			//Client Side Only -- Temporary
			public int CurrentEvents;
			
			public C_EventSystem.MapEventRec[] MapEvents;
		}
		
		public struct ClassRec
		{
			public string Name;
			public string Desc;
			public byte[] Stat;
			public int[] MaleSprite;
			public int[] FemaleSprite;
			public int[] StartItem;
			public int[] StartValue;
			public int StartMap;
			public byte StartX;
			public byte StartY;
			public int BaseExp;
			
			// For client use
			public int[] Vital;
			
		}
		
		public struct MapItemRec
		{
			public int Num;
			public int Value;
			public byte Frame;
			public byte X;
			public byte Y;
			
			public Types.RandInvRec RandData;
		}
		
		public struct MapNpcRec
		{
			public int Num;
			public int Target;
			public byte TargetType;
			public int[] Vital;
			public int Map;
			public byte X;
			public byte Y;
			public byte Dir;
			
			// Client use only
			public int XOffset;
			
			public int YOffset;
			public byte Moving;
			public byte Attacking;
			public int AttackTimer;
			public int Steps;
		}
		
		public struct ChatBubbleRec
		{
			public string Msg;
			public int Colour;
			public int Target;
			public byte TargetType;
			public int Timer;
			public bool Active;
		}
		
		public struct TempTileRec
		{
			public byte DoorOpen;
			public byte DoorFrame;
			public int DoorTimer;
			public byte DoorAnimate; // 0 = nothing| 1 = opening | 2 = closing
		}
		
		public struct MapResourceRec
		{
			public int X;
			public int Y;
			public byte ResourceState;
		}
		
		public struct ActionMsgRec
		{
			public string Message;
			public int Created;
			public int Type;
			public int Color;
			public int Scroll;
			public int X;
			public int Y;
			public int Timer;
		}
		
		public struct BloodRec
		{
			public int Sprite;
			public int Timer;
			public int X;
			public int Y;
		}
		
	}
}
