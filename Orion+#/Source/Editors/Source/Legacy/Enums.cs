
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
	sealed class Enums
	{
		/// <Summary> Text Color Contstant </Summary>
		public enum ColorType : byte
		{
			Black,
			Blue,
			Green,
			Cyan,
			Red,
			Magenta,
			Brown,
			Gray,
			DarkGray,
			BrightBlue,
			BrightGreen,
			BrightCyan,
			BrightRed,
			Pink,
			Yellow,
			White
		}
		
		/// <Summary> Quick Access/Constant Color References </Summary>
		public enum QColorType : byte
		{
			SayColor = ColorType.White,
			GlobalColor = ColorType.BrightBlue,
			BroadcastColor = ColorType.White,
			TellColor = ColorType.BrightGreen,
			EmoteColor = ColorType.BrightCyan,
			AdminColor = ColorType.BrightCyan,
			HelpColor = ColorType.BrightBlue,
			WhoColor = ColorType.BrightBlue,
			JoinLeftColor = ColorType.Gray,
			NpcColor = ColorType.Brown,
			AlertColor = ColorType.BrightRed,
			NewMapColor = ColorType.BrightBlue
		}
		
		/// <Summary> Sex Constant </Summary>
		public enum SexType : byte
		{
			Male,
			Female
		}
		
		/// <Summary> Map Moral Constant </Summary>
		public enum MapMoralType : byte
		{
			None,
			Safe,
			Indoors
		}
		
		/// <Summary> Tile Constant </Summary>
		public enum TileType : byte
		{
			None,
			Blocked,
			Warp,
			Item,
			NpcAvoid,
			Key,
			KeyOpen,
			Resource,
			Door,
			NpcSpawn,
			Shop,
			Bank,
			Heal,
			Trap,
			House,
			Craft,
			Light,
			
			Count
		}
		
		/// <Summary> Item Constant </Summary>
		public enum ItemType : byte
		{
			None,
			Equipment,
			Consumable,
			Key,
			Currency,
			Skill,
			Furniture,
			Recipe,
			Pet,
			
			Count
		}
		
		/// <Summary> Consumable Constant </Summary>
		public enum ConsumableType : byte
		{
			Hp,
			Mp,
			Sp,
			Exp
		}
		
		/// <Summary> Direction Constant </Summary>
		public enum DirectionType : byte
		{
			Up,
			Down,
			Left,
			Right,
            UpLeft,
            UpRight,
            DownLeft,
            DownRight
		}
		
		/// <Summary> Movement Constant </Summary>
		public enum MovementType : byte
		{
			Standing,
			Walking,
			Running
		}
		
		/// <Summary> Admin Constant </Summary>
		public enum AdminType : byte
		{
			Player,
			Monitor,
			Mapper,
			Developer,
			Creator
		}
		
		/// <Summary> Npc Behavior Constant </Summary>
		public enum NpcBehavior : byte
		{
			AttackOnSight,
			AttackWhenAttacked,
			Friendly,
			ShopKeeper,
			Guard,
			Quest
		}
		
		/// <Summary> Skill Constant </Summary>
		public enum SkillType : byte
		{
			DamageHp,
			DamageMp,
			HealHp,
			HealMp,
			Warp,
			Pet
		}
		
		/// <Summary> Target Constant </Summary>
		public enum TargetType : byte
		{
			None,
			Player,
			Npc,
			@Event,
			Pet
		}
		
		/// <Summary> Action Message Constant </Summary>
		public enum ActionMsgType : byte
		{
			@Static,
			Scroll,
			Screen
		}
		
		/// <Summary> Stats used by Players, Npcs and Classes </Summary>
		internal enum StatType : byte
		{
			Strength = 1,
			Endurance,
			Vitality,
			Luck,
			Intelligence,
			Spirit,
			
			Count
		}
		
		/// <Summary> Vitals used by Players, Npcs, and Classes </Summary>
		internal enum VitalType : byte
		{
			HP = 1,
			MP,
			SP,
			
			Count
		}
		
		/// <Summary> Equipment used by Players </Summary>
		internal enum EquipmentType : byte
		{
			Weapon = 1,
			Armor,
			Helmet,
			Shield,
			Shoes,
			Gloves,
			
			Count
		}
		
		/// <Summary> Layers in a map </Summary>
		internal enum LayerType : byte
		{
			Ground = 1,
			Mask,
			Mask2,
			Fringe,
			Fringe2,
			
			Count
		}
		
		/// <Summary> Resource Skills </Summary>
		internal enum ResourceSkills : byte
		{
			Herbalist = 1,
			WoodCutter,
			Miner,
			Fisherman,
			
			Count
		}
		
		internal enum RandomBonusType
		{
			RANDOM_SPEED = 1, // Reduces time between attacks by 20%
			RANDOM_DAMAGE, // Increases base damage by 25%
			RANDOM_WARRIOR, // Adds Strength and Endurance
			RANDOM_ARCHER, // Adds Achery and Endurance
			RANDOM_MAGE, // Adds Magic and Endurance
			RANDOM_JESTER, // Adds Magic and Archery
			RANDOM_BATTLEMAGE, // Adds Attack and Magic
			RANDOM_ROGUE, // Adds Attack and Archery
			RANDOM_TOWER, // Adds Endurance and Defense
			RANDOM_SURVIVALIST, // Adds Cooking and Fishing
			RANDOM_PERFECTIONIST, // Adds Mining and Jeweler
			RANDOM_COALMEN, // Adds Mining and Blacksmithing
			RANDOM_BOWYER, // Adds Woodcutting and Fletching
			RANDOM_BROKEN, // Reduces damage and increases speed by 10%
			RANDOM_PRISM, // Gives four random stats, but will always turn soulbound
			RANDOM_CANNON // Gives Attack, Ranged and Magic
		}
		
		internal enum RarityType
		{
			RARITY_BROKEN = 1,
			RARITY_COMMON,
			RARITY_UNCOMMON,
			RARITY_RARE,
			RARITY_EPIC
		}
		
		internal enum WeatherType
		{
			None,
			Rain,
			Snow,
			Hail,
			Sandstorm,
			Storm,
			Fog
		}
		
		internal enum QuestType
		{
			Slay = 1,
			Collect,
			Talk,
			Reach,
			Give,
			Kill,
			Gather,
			Fetch,
			TalkEvent
		}
		
		internal enum QuestStatusType
		{
			NotStarted,
			Started,
			Completed,
			Repeatable
		}
	}
}
