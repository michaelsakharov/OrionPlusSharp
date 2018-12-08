namespace Engine
{
    static class Types
    {
        // Common data structure arrays
        internal static modTypes.ClassRec[] Classes;
        internal static ItemRec[] Item = new ItemRec[501];
        internal static NpcRec[] Npc = new NpcRec[501];
        internal static ShopRec[] Shop = new ShopRec[51];
        internal static SkillRec[] Skill = new SkillRec[256];
        internal static ResourceRec[] Resource = new ResourceRec[101];
        internal static AnimationRec[] Animation = new AnimationRec[501];

        // Common data structures
        internal struct RandInvRec
        {
            public string Prefix;
            public string Suffix;
            public int[] Stat;
            public int Rarity;
            public int Damage;
            public int Speed;
        }

        internal struct ResourceSkillsRec
        {
            public int SkillLevel;
            public int SkillCurExp;
            public int SkillNextLvlExp;
        }

        internal struct AnimationRec
        {
            public string Name;
            public string Sound;
            public int[] Sprite;
            public int[] Frames;
            public int[] LoopCount;
            public int[] LoopTime;
        }

        internal struct Rect
        {
            public int Top;
            public int Left;
            public int Right;
            public int Bottom;
        }

        internal struct ResourceRec
        {
            public string Name;
            public string SuccessMessage;
            public string EmptyMessage;
            public int ResourceType;
            public int ResourceImage;
            public int ExhaustedImage;
            public int ExpReward;
            public int ItemReward;
            public int LvlRequired;
            public int ToolRequired;
            public int Health;
            public int RespawnTime;
            public bool Walkthrough;
            public int Animation;
        }

        internal struct SkillRec
        {
            public string Name;
            public byte Type;
            public int MpCost;
            public int LevelReq;
            public int AccessReq;
            public int ClassReq;
            public int CastTime;
            public int CdTime;
            public int Icon;
            public int Map;
            public int X;
            public int Y;
            public byte Dir;
            public int Vital;
            public int Duration;
            public int Interval;
            public int Range;
            public bool IsAoE;
            public int AoE;
            public int CastAnim;
            public int SkillAnim;
            public int StunDuration;

            // projectiles
            public int IsProjectile; // 0 is no, 1 is yes
            public int Projectile;

            public byte KnockBack; // 0 is no, 1 is yes
            public byte KnockBackTiles;
        }

        internal struct ShopRec
        {
            public string Name;
            public byte Face;
            public int BuyRate;
            public TradeItemRec[] TradeItem;
        }

        internal struct PlayerInvRec
        {
            public int Num;
            public int Value;
        }

        internal struct BankRec
        {
            public PlayerInvRec[] Item;
            public RandInvRec[] ItemRand;
        }

        internal struct Cache
        {
            public byte[] Data;
        }

        internal struct TileDataRec
        {
            public byte X;
            public byte Y;
            public byte Tileset;
            public byte AutoTile;
        }

        internal struct TileRec
        {
            public TileDataRec[] Layer;
            public byte Type;
            public int Data1;
            public int Data2;
            public int Data3;
            public byte DirBlock;
        }

        internal struct ItemRec
        {
            public string Name;
            public int Pic;
            public string Description;

            public byte Type;
            public byte SubType;
            public int Data1;
            public int Data2;
            public int Data3;
            public int ClassReq;
            public int AccessReq;
            public int LevelReq;
            public byte Mastery;
            public int Price;
            public byte[] Add_Stat;
            public byte Rarity;
            public int Speed;
            public int TwoHanded;
            public byte BindType;
            public byte[] Stat_Req;
            public int Animation;
            public int Paperdoll;

            public byte Randomize;
            public byte RandomMin;
            public byte RandomMax;

            public byte Stackable;
            public byte ItemLevel;

            // Housing
            public int FurnitureWidth;
            public int FurnitureHeight;
            public int[,] FurnitureBlocks;
            public int[,] FurnitureFringe;

            public byte KnockBack;
            public byte KnockBackTiles;

            public int Projectile;
            public int Ammo;
        }

        internal struct AnimInstanceRec
        {
            public int Animation;
            public int X;
            public int Y;
            // used for locking to players/npcs
            public int lockindex;
            public byte LockType;
            // timing
            public int[] Timer;
            // rendering check
            public bool[] Used;
            // counting the loop
            public int[] LoopIndex;
            public int[] FrameIndex;
        }

        internal struct NpcRec
        {
            public string Name;
            public string AttackSay;
            public int Sprite;
            public byte SpawnTime;
            public int SpawnSecs;
            public byte Behaviour;
            public byte Range;
            public int[] DropChance;
            public int[] DropItem;
            public int[] DropItemValue;
            public byte[] Stat;
            public byte Faction;
            public int Hp;
            public int Exp;
            public int Animation;
            public int QuestNum;
            public byte[] Skill;

            public int Level;
            public int Damage;
        }

        internal struct TradeItemRec
        {
            public int Item;
            public int ItemValue;
            public int CostItem;
            public int CostValue;
        }
    }
}
