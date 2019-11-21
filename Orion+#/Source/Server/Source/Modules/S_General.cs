using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using static Engine.modTypes;
using static Engine.S_Quest;
using static Engine.S_Events;
using static Engine.S_Housing;
using static Engine.Types;
using static Engine.S_Projectiles;
using static Engine.S_Pets;
using System.Text;

namespace Engine
{
    static class S_General
    {
        [System.Runtime.InteropServices.DllImport("user32")]
        internal static extern int GetQueueStatus(int fuFlags);
        internal static string MyIPAddress;
        internal static Stopwatch myStopWatch = new Stopwatch();

        public static int gameCPS;

        internal static Stopwatch shutDownTimer;
        internal static int shutDownLastTimer;

        public static bool isInMaintenance = false;

        internal static int GetTimeMs()
        {
            return (int)myStopWatch.ElapsedMilliseconds;
        }

        public static void InitServer()
        {
            int i;
            int F;
            int x;
            int time1;
            int time2;

            myStopWatch.Start();

            if (Debugger.IsAttached)
                // Since there is a debugger attached,
                // assume we are running from the IDE
                S_Globals.Debugging = true;
            else
            {
                // Assume we aren't running from the IDE
                AppDomain currentDomain = AppDomain.CurrentDomain;
                currentDomain.UnhandledException += ErrorHandler;
            }

            Console.Title = "Lupus Engine Server";
            Console.SetWindowSize(120, 20);

            time1 = GetTimeMs();

            // Initialize the random-number generator
            VBMathClone.Randomize();

            // LOAD ENCRYPTION
            var fi = Application.StartupPath + @"\AsyncKeys.xml";
            if (!File.Exists(fi))
            {
                S_Globals.EKeyPair.GenerateKeys();
                S_Globals.EKeyPair.ExportKey(fi, true); // True exports private key too.
            }
            else
                S_Globals.EKeyPair.ImportKey(fi);
            // END LOAD ENCRYPTION

            modTypes.Map = new MapRec[601];

            modTypes.MapNpc = new MapDataRec[601];
            for (i = 0; i <= S_Instances.MAX_CACHED_MAPS; i++)
            {
                modTypes.MapNpc[i].Npc = new MapNpcRec[Constants.MAX_MAP_NPCS + 1];
                modTypes.Map[i].Npc = new int[Constants.MAX_MAP_NPCS + 1];
            }

            // quests
            S_Quest.Quest = new QuestRec[251];
            S_Quest.ClearQuests();

            // event
            S_Events.Switches = new string[501];
            S_Events.Variables = new string[501];
            S_Events.TempEventMap = new GlobalEventsStruct[601];

            // Housing
            S_Housing.HouseConfig = new HouseRec[S_Housing.MAX_HOUSES + 1];

            for (i = 0; i <= S_Instances.MAX_CACHED_MAPS; i++)
            {
                for (x = 0; x <= Constants.MAX_MAP_NPCS; x++)
                    modTypes.MapNpc[i].Npc[x].Vital = new int[(int)Enums.VitalType.Count + 1];
            }

            modTypes.Bank = new BankRec[71];

            for (i = 1; i <= Constants.MAX_PLAYERS; i++)
            {
                modTypes.Bank[i].Item = new PlayerInvRec[Constants.MAX_BANK + 1];
                modTypes.Bank[i].ItemRand = new RandInvRec[Constants.MAX_BANK + 1];
                for (x = 1; x <= Constants.MAX_BANK; x++)
                    modTypes.Bank[i].ItemRand[x].Stat = new int[7];
            }

            modTypes.Player = new PlayerRec[71];

            for (i = 1; i <= Constants.MAX_PLAYERS; i++)
            {
                // multi char
                modTypes.Player[i].Character = new CharacterRec[S_Constants.MAX_CHARS + 1];
                for (x = 1; x <= S_Constants.MAX_CHARS; x++)
                {
                    modTypes.Player[i].Character[x].Switches = new byte[501];
                    modTypes.Player[i].Character[x].Variables = new int[501];
                    modTypes.Player[i].Character[x].Vital = new int[4];
                    modTypes.Player[i].Character[x].Stat = new int[7];
                    modTypes.Player[i].Character[x].Equipment = new int[7];
                    modTypes.Player[i].Character[x].Inv = new PlayerInvRec[Constants.MAX_INV + 1];
                    modTypes.Player[i].Character[x].Skill = new int[Constants.MAX_PLAYER_SKILLS + 1];
                    modTypes.Player[i].Character[x].PlayerQuest = new PlayerQuestRec[251];

                    modTypes.Player[i].Character[x].RandEquip = new RandInvRec[7];
                    modTypes.Player[i].Character[x].RandInv = new RandInvRec[Constants.MAX_INV + 1];
                    for (var y = 1; y <= (int)Enums.EquipmentType.Count - 1; y++)
                        modTypes.Player[i].Character[x].RandEquip[y].Stat = new int[7];
                    for (int y = 1; y <= Constants.MAX_INV; y++)
                        modTypes.Player[i].Character[x].RandInv[y].Stat = new int[7];
                }
            }

            modTypes.TempPlayer = new TempPlayerRec[71];

            for (i = 1; i <= Constants.MAX_PLAYERS; i++)
            {
                modTypes.TempPlayer[i].SkillCd = new int[Constants.MAX_PLAYER_SKILLS + 1];
                modTypes.TempPlayer[i].PetSkillCd = new int[5];
            }

            for (i = 1; i <= Constants.MAX_PLAYERS; i++)
                modTypes.TempPlayer[i].TradeOffer = new PlayerInvRec[Constants.MAX_INV + 1];

            S_AutoMap.LoadTilePrefab();

            Types.Classes = new ClassRec[S_Globals.Max_Classes + 1];
            var loopTo = S_Globals.Max_Classes;
            for (i = 0; i <= loopTo; i++)
            {
                Types.Classes[i].Stat = new byte[7];
                Types.Classes[i].StartItem = new int[6];
                Types.Classes[i].StartValue = new int[6];
            }

            for (i = 0; i <= Constants.MAX_ITEMS; i++)
            {
                Types.Item[i].Add_Stat = new byte[7];
                Types.Item[i].Stat_Req = new byte[7];
                Types.Item[i].FurnitureBlocks = new int[4, 4];
                Types.Item[i].FurnitureFringe = new int[4, 4];
            }
            Types.Npc[Constants.MAX_NPCS].Stat = new byte[7];

            Types.Shop[Constants.MAX_SHOPS].TradeItem = new TradeItemRec[Constants.MAX_TRADES + 1];

            Types.Animation[Constants.MAX_ANIMATIONS].Sprite = new int[2];
            Types.Animation[Constants.MAX_ANIMATIONS].Frames = new int[2];
            Types.Animation[Constants.MAX_ANIMATIONS].LoopCount = new int[2];
            Types.Animation[Constants.MAX_ANIMATIONS].LoopTime = new int[2];

            S_Projectiles.MapProjectiles = new MapProjectileRec[601, 256];
            S_Projectiles.Projectiles = new ProjectileRec[256];

            // parties
            S_Parties.ClearParties();

            // pets
            S_Pets.Pet = new PetRec[101];
            S_Pets.ClearPets();

            // Check if the directory is there, if its not make it
            CheckDir(Path.Combine(Application.StartupPath, "data"));
            CheckDir(Path.Combine(Application.StartupPath, "data", "items"));
            CheckDir(Path.Combine(Application.StartupPath, "data", "maps"));
            CheckDir(Path.Combine(Application.StartupPath, "data", "npcs"));
            CheckDir(Path.Combine(Application.StartupPath, "data", "shops"));
            CheckDir(Path.Combine(Application.StartupPath, "data", "skills"));
            CheckDir(Path.Combine(Application.StartupPath, "data", "accounts"));
            CheckDir(Path.Combine(Application.StartupPath, "data", "resources"));
            CheckDir(Path.Combine(Application.StartupPath, "data", "animations"));
            CheckDir(Path.Combine(Application.StartupPath, "data", "logs"));
            CheckDir(Path.Combine(Application.StartupPath, "data", "quests"));
            CheckDir(Path.Combine(Application.StartupPath, "data", "recipes"));
            CheckDir(Path.Combine(Application.StartupPath, "data", "pets"));
            CheckDir(Path.Combine(Application.StartupPath, "data", "projectiles"));

            // load options, set if they dont exist
            if (!File.Exists(Path.Combine(Application.StartupPath, "Data", "Config.xml")))
            {
                modTypes.Options.GameName = "Lupus Engine";
                modTypes.Options.Port = 7001;
                modTypes.Options.Motd = "Welcome to the Lupus Engine";
                modTypes.Options.Website = "http://ascensiongamedev.com/index.php";
                modTypes.Options.StartMap = 1;
                modTypes.Options.StartX = 13;
                modTypes.Options.StartY = 7;
                modTypes.Options.allowEightDirectionalMovement = true;
                modTypes.Options.useSmoothDynamicLightRendering = true;
                modDatabase.SaveOptions();
            }
            else
                modDatabase.LoadOptions();

            // Get that network READY SUN! ~ SpiceyWOlf
            S_NetworkConfig.InitNetwork();
            
            Console.ForegroundColor = ConsoleColor.Yellow;

            // Init all the player sockets
            Console.WriteLine("Initializing player array...");

            for (x = 1; x <= Constants.MAX_PLAYERS; x++)
                modDatabase.ClearPlayer(x);

            // Serves as a constructor
            ClearGameData();
            LoadGameData();
            Console.WriteLine("Spawning map items...");
            S_Items.SpawnAllMapsItems();
            Console.WriteLine("Spawning map npcs...");
            S_Npc.SpawnAllMapNpcs();

            // Check if the master charlist file exists for checking duplicate names, and if it doesnt make it
            if (!File.Exists(@"data\accounts\charlist.txt"))
                F = FileSystem.FreeFile();

            // resource system
            S_Resources.LoadSkillExp();

            modTime.InitTime();

            UpdateCaption();
            time2 = GetTimeMs();
            
            Console.ForegroundColor = ConsoleColor.Cyan;

                    Console.Clear();
            Console.WriteLine(@"ooooo        ooooo     ooo ooooooooo.   ooooo     ooo  .oooooo..o ");
            Console.WriteLine(@"`888'        `888'     `8' `888   `Y88. `888'     `8' d8P'    `Y8 ");
            Console.WriteLine(@" 888          888       8   888   .d88'  888       8  Y88bo.      ");
            Console.WriteLine(@" 888          888       8   888ooo88P'   888       8   `""Y8888o.  ");
            Console.WriteLine(@" 888          888       8   888          888       8       `""Y88b ");
            Console.WriteLine(@" 888       o  `88.    .8'   888          `88.    .8'  oo     .d8P ");
            Console.WriteLine(@"o888ooooood8    `YbodP'    o888o           `YbodP'    8""""88888P'  ");
            
            Console.WriteLine("");
            
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("Initialization complete. Server loaded in " + (time2 - time1).ToString() + "ms.");
            Console.WriteLine("");
            Console.WriteLine("Use /help for the available commands.");

            Random r = new Random();
            for(int d=0; d<100; d++)
            {
                Console.WriteLine(VBMathClone.Rnd());
            }

            Console.ResetColor();

            MyIPAddress = S_NetworkConfig.GetIP();

            UpdateCaption();

            // reset shutdown value
            S_Globals.isShuttingDown = false;

            try
            {
                // Start listener now that everything is loaded
                S_NetworkConfig.Socket.StartListening(modTypes.Options.Port, 5);
            }
            catch(Exception err)
            {
                Console.WriteLine("FAILED TO START SERVER");
                Console.WriteLine(err.StackTrace.ToString());
                return;
            }

            // Starts the server loop
            ModLoop.ServerLoop();
        }

        private static bool ConsoleEventCallback(int eventType)
        {
            if (eventType == 2)
            {
                Console.WriteLine("Console window closing, death imminent");
                // cleanup and close
                DestroyServer();
            }
            return false;
        }

        // Keeps it from getting garbage collected
        // Pinvoke
        private delegate bool ConsoleEventDelegate(int eventType);


        public static void UpdateCaption()
        {
            Console.Title = string.Format("{0} <IP {1}:{2}> ({3} Players Online) - Current Errors: {4} - Time: {5} - CPS: {6}", modTypes.Options.GameName, MyIPAddress, modTypes.Options.Port, S_GameLogic.GetPlayersOnline(), S_Globals.ErrorCount, Time.Instance.ToString(), S_General.gameCPS);
        }

        public static void DestroyServer()
        {
            S_NetworkConfig.Socket.StopListening();

            Console.WriteLine("Saving players online...");
            modDatabase.SaveAllPlayersOnline();

            Console.WriteLine("Unloading players...");
            for (int i = 1; i <= Constants.MAX_PLAYERS; i++)
            {
                S_NetworkSend.SendLeftGame(i);
                S_Players.LeftGame(i);
            }

            S_NetworkConfig.DestroyNetwork();
            ClearGameData();
            
            Environment.Exit(0);
        }

        internal static void ClearGameData()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Clearing temp tile fields..."); modDatabase.ClearTempTiles();
            Console.WriteLine("Clearing Maps..."); modDatabase.ClearMaps();
            Console.WriteLine("Clearing Map Items..."); modDatabase.ClearMapItems();
            Console.WriteLine("Clearing Map Npc's..."); modDatabase.ClearAllMapNpcs();
            Console.WriteLine("Clearing Npc's..."); modDatabase.ClearNpcs();
            Console.WriteLine("Clearing Resources..."); S_Resources.ClearResources();
            Console.WriteLine("Clearing Items..."); S_Items.ClearItems();
            Console.WriteLine("Clearing Shops..."); modDatabase.ClearShops();
            Console.WriteLine("Clearing Skills..."); modDatabase.ClearSkills();
            Console.WriteLine("Clearing Animations..."); S_Animations.ClearAnimations();
            Console.WriteLine("Clearing Quests..."); S_Quest.ClearQuests();
            Console.WriteLine("Clearing map projectiles..."); S_Projectiles.ClearMapProjectiles();
            Console.WriteLine("Clearing projectiles..."); S_Projectiles.ClearProjectiles();
            Console.WriteLine("Clearing Recipes..."); modCrafting.ClearRecipes();
            Console.WriteLine("Clearing pets..."); S_Pets.ClearPets();
            Console.ResetColor();
        }

        private static void LoadGameData()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Loading Classes..."); modDatabase.LoadClasses();
            Console.WriteLine("Loading Maps..."); modDatabase.LoadMaps();
            Console.WriteLine("Creating Map Matrices...");
            for (int i=1; i < Constants.MAX_MAPS; i++)
            {
                modPathfinding.CreatePathMatrix(i);
            }
            Console.WriteLine("Loading Items..."); S_Items.LoadItems();
            Console.WriteLine("Loading Npc's..."); modDatabase.LoadNpcs();
            Console.WriteLine("Loading Resources..."); S_Resources.LoadResources();
            Console.WriteLine("Loading Shops..."); modDatabase.LoadShops();
            Console.WriteLine("Loading Skills..."); modDatabase.LoadSkills();
            Console.WriteLine("Loading Animations..."); S_Animations.LoadAnimations();
            Console.WriteLine("Loading Quests..."); S_Quest.LoadQuests();
            Console.WriteLine("Loading House Configurations..."); S_Housing.LoadHouses();
            Console.WriteLine("Loading Switches..."); S_Events.LoadSwitches();
            Console.WriteLine("Loading Variables..."); S_Events.LoadVariables();
            Console.WriteLine("Spawning global events..."); S_EventLogic.SpawnAllMapGlobalEvents();
            Console.WriteLine("Loading projectiles..."); S_Projectiles.LoadProjectiles();
            Console.WriteLine("Loading Recipes..."); modCrafting.LoadRecipes();
            Console.WriteLine("Loading Pets..."); S_Pets.LoadPets();
            Console.ResetColor();
        }

        // Used for checking validity of names
        public static bool IsNameLegal(int sInput)
        {
            if ((sInput >= 65 && sInput <= 90) || (sInput >= 97 && sInput <= 122) || (sInput == 95) || (sInput == 32) || (sInput >= 48 && sInput <= 57))
                return true;
            else
                return false;
        }

        internal static void CheckDir(string path)
        {
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
        }

        public static void ErrorHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            string myFilePath = Path.Combine(Application.StartupPath, "data", "logs", "ErrorLog.log");

            using (StreamWriter sw = new StreamWriter(File.Open(myFilePath, FileMode.Append)))
            {
                sw.WriteLine(DateTime.Now);
                sw.WriteLine(GetExceptionInfo(e));
            }

            S_Globals.ErrorCount = S_Globals.ErrorCount + 1;

            UpdateCaption();
        }

        internal static string GetExceptionInfo(Exception ex)
        {
            string Result;
            int hr = System.Runtime.InteropServices.Marshal.GetHRForException(ex);
            Result = ex.GetType().ToString() + "(0x" + hr.ToString("X8") + "): " + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine;
            StackTrace st = new StackTrace(ex, true);
            foreach (StackFrame sf in st.GetFrames())
            {
                if (sf.GetFileLineNumber() > 0)
                    Result += "Line:" + sf.GetFileLineNumber() + " Filename: " + Path.GetFileName(sf.GetFileName()) + Environment.NewLine;
            }
            return Result;
        }

        internal static void AddDebug(string Msg)
        {
            if (S_Globals.DebugTxt == true)
            {
                modDatabase.Addlog(Msg, S_Constants.PACKET_LOG);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(Msg);
                Console.ResetColor();
            }
        }
    }
}
