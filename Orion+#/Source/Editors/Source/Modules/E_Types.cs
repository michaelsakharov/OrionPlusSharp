
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using Engine;

namespace Engine
{
	sealed class E_Types
	{
		
		// options
		internal static E_Options Options = new E_Options();
		
		// Friend data structures
		internal static MapRec Map;
		
		internal static TempTileRec[,] TempTile;
		internal static object MapLock = new object();
		internal static MapItemRec[] MapItem = new MapItemRec[Constants.MAX_MAP_ITEMS + 1];
		internal static MapNpcRec[] MapNpc = new MapNpcRec[Constants.MAX_MAP_NPCS + 1];
		
		//Mapreport
		internal static string[] MapNames = new string[Constants.MAX_MAPS + 1];
		
		public struct MapRec
		{
			public int mapNum;
			public string Name;
			public string Music;
			
			public int Revision;
			public byte Moral;
			public int tileset;
			
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
			public E_EventSystem.EventRec[] Events;
			
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
			
			//Client Side Only -- Temporary
			public int CurrentEvents;
			
			public E_EventSystem.MapEventRec[] MapEvents;
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
		}
		
		public struct MapNpcRec
		{
			public byte Num;
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
		
	}
}
