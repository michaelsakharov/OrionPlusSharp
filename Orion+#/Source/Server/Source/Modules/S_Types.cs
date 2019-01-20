namespace Engine
{
    static class modTypes
    {
        internal static S_Options Options = new S_Options();

        // Friend data structures
        internal static MapRec[] Map = new MapRec[601];

        internal static TempTileRec[] TempTile = new TempTileRec[601];
        internal static int[] PlayersOnMap = new int[601];
        internal static MapItemRec[,] MapItem = new MapItemRec[601, Constants.MAX_MAP_ITEMS + 1];
        internal static MapDataRec[] MapNpc = new MapDataRec[601];
        internal static Types.BankRec[] Bank = new Types.BankRec[71];
        internal static TempPlayerRec[] TempPlayer = new TempPlayerRec[71];
        internal static PlayerRec[] Player = new PlayerRec[71];

        internal struct PlayerRec
        {

            // Account
            public string Login;

            public string Password;
            public byte Access;

            // multi char
            public CharacterRec[] Character;

            public long Money;
            public long BidWon;
            public long BidWonAmount;
        }

        internal struct CharacterRec
        {

            // General
            public string Name;

            public byte Sex;
            public byte Classes;
            public int Sprite;
            public byte Level;
            public int Exp;

            public byte Pk;

            // Vitals
            public int[] Vital;

            // Stats
            public byte[] Stat;

            public byte Points;

            // Worn equipment
            public int[] Equipment;

            // Inventory
            public Types.PlayerInvRec[] Inv;

            public int[] Skill;

            // Position
            public int Map;

            public byte X;
            public byte Y;
            public byte Dir;

            public S_Quest.PlayerQuestRec[] PlayerQuest;

            // Housing
            public S_Housing.PlayerHouseRec House;

            public int InHouse;
            public int LastMap;
            public int LastX;
            public int LastY;

            // Hotbar
            public HotbarRec[] Hotbar;

            // Event
            public byte[] Switches;

            public int[] Variables;

            // gather skills
            public Types.ResourceSkillsRec[] GatherSkills;

            public byte[] RecipeLearned;

            // Random Items
            public Types.RandInvRec[] RandInv;

            public Types.RandInvRec[] RandEquip;

            public S_Pets.PlayerPetRec Pet;
        }

        internal struct TempPlayerRec
        {

            // Non saved local vars
            public bool InGame;

            public int AttackTimer;
            public int DataTimer;
            public int DataBytes;
            public int DataPackets;
            public int PartyInvite;
            public byte InParty;
            public byte TargetType;
            public int Target;
            public byte PartyStarter;
            public byte GettingMap;
            public int SkillBuffer;
            public int SkillBufferTimer;
            public int[] SkillCd;
            public int InShop;
            public int StunTimer;
            public int StunDuration;
            public bool InBank;

            // trade
            public int TradeRequest;

            public int InTrade;
            public Types.PlayerInvRec[] TradeOffer;
            public bool AcceptTrade;

            // Housing
            public int BuyHouseindex;

            public int Invitationindex;
            public int InvitationTimer;

            public S_Events.EventMapStruct EventMap;
            public int EventProcessingCount;
            public S_Events.EventProcessingStruct[] EventProcessing;

            // multi char
            public byte CurChar;

            // craft shit
            public bool IsCrafting;

            public byte CraftIt;
            public int CraftTimer;
            public int CraftTimeNeeded;

            public int CraftRecipe;
            public int CraftAmount;

            public int StopRegenTimer;
            public byte StopRegen;

            // instance stuff
            public byte InInstance;

            public int TmpInstanceNum;
            public int TmpMap;
            public int TmpX;
            public int TmpY;

            // pets
            public int PetTarget;

            public int PetTargetType;
            public int PetBehavior;

            public int GoToX;
            public int GoToY;

            public int PetStunTimer;
            public int PetStunDuration;
            public int PetAttackTimer;

            public int[] PetSkillCd;
            public SkillBufferRec PetskillBuffer;

            public DoTRec[] PetDoT;
            public DoTRec[] PetHoT;

            // regen
            public bool PetstopRegen;

            public int PetstopRegenTimer;
        }

        internal struct MapRec
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
            public S_Events.EventStruct[] Events;

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
        }

        internal struct ClassRec
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
        }

        internal struct MapItemRec
        {
            public int Num;
            public int Value;
            public byte X;
            public byte Y;

            public Types.RandInvRec RandData;

            // ownership + despawn
            public string PlayerName;

            public long PlayerTimer;
            public bool CanDespawn;
            public long DespawnTimer;
        }

        internal struct MapNpcRec
        {
            public int Num;
            public int Target;
            public byte TargetType;
            public int[] Vital;
            public byte X;
            public byte Y;
            public int Dir;

            // For server use only
            public int SpawnWait;

            public int AttackTimer;
            public int StunDuration;
            public int StunTimer;
            public int SkillBuffer;
            public int SkillBufferTimer;
            public int[] SkillCd;
            public byte StopRegen;
            public int StopRegenTimer;
        }

        internal struct TempTileRec
        {
            public byte[,] DoorOpen;
            public int DoorTimer;
        }

        internal struct MapDataRec
        {
            public MapNpcRec[] Npc;
        }

        internal struct HotbarRec
        {
            public int Slot;
            public byte SlotType;
        }

        internal struct SkillBufferRec
        {
            public int Skill;
            public int Timer;
            public int Target;
            public byte TargetTypes;
        }

        internal struct DoTRec
        {
            public bool Used;
            public int Skill;
            public int Timer;
            public int Caster;
            public int StartTime;

            // PET
            public int AttackerType; // For Pets
        }
    }
}
