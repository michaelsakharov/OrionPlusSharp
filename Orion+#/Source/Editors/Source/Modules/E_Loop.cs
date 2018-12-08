using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using System.Threading;
using static Engine.E_AutoTiles;
using static Engine.E_Quest;
using static Engine.Types;
using static Engine.E_Types;

namespace Engine
{
    static class E_Loop
    {
        internal static void Main()
        {

            // check if we are in the right place...
            if (!System.IO.Directory.Exists(Application.StartupPath + @"\Data"))
            {
                Interaction.MsgBox("Run Editor from inside the Client folder!");
                System.Environment.Exit(0);
            }

            if (E_Globals.GameStarted == true)
                return;

            SFML.Portable.Activate();

            // Strings.Init(1, "English")

            ClientDataBase.ClearTempTile();

            // set values for directional blocking arrows
            E_Globals.DirArrowX[1] = 12; // up
            E_Globals.DirArrowY[1] = 0;
            E_Globals.DirArrowX[2] = 12; // down
            E_Globals.DirArrowY[2] = 23;
            E_Globals.DirArrowX[3] = 0; // left
            E_Globals.DirArrowY[3] = 12;
            E_Globals.DirArrowX[4] = 23; // right
            E_Globals.DirArrowY[4] = 12;

            ClientDataBase.CheckTilesets();
            ClientDataBase.CheckCharacters();
            ClientDataBase.CheckPaperdolls();
            ClientDataBase.CheckAnimations();
            E_Items.CheckItems();
            ClientDataBase.CheckResources();
            ClientDataBase.CheckSkillIcons();
            ClientDataBase.CheckFaces();
            ClientDataBase.CheckFog();
            ClientDataBase.CacheMusic();
            ClientDataBase.CacheSound();

            E_Housing.CheckFurniture();
            E_Projectiles.CheckProjectiles();

            //E_Graphics.InitGraphics();

            E_AutoTiles.Autotile = new AutotileRec[E_Types.Map.MaxX + 1, E_Types.Map.MaxY + 1];
            var loopTo = E_Types.Map.MaxX;
            for (var X = 0; X <= loopTo; X++)
            {
                var loopTo1 = E_Types.Map.MaxY;
                for (var Y = 0; Y <= loopTo1; Y++)
                {
                    E_AutoTiles.Autotile[X, Y].Layer = new QuarterTileRec[6];
                    for (var i = 0; i <= (byte)Enums.LayerType.Count - 1; i++)
                    {
                        E_AutoTiles.Autotile[X, Y].Layer[i].srcX = new int[5];
                        E_AutoTiles.Autotile[X, Y].Layer[i].srcY = new int[5];
                        E_AutoTiles.Autotile[X, Y].Layer[i].QuarterTile = new PointRec[5];
                    }
                }
            }

            // 'Housing
            E_Housing.House = new E_Housing.HouseRec[E_Housing.MAX_HOUSES + 1];
            E_Housing.HouseConfig = new E_Housing.HouseRec[E_Housing.MAX_HOUSES + 1];

            // quests
            E_Quest.Quest = new QuestRec[251];
            E_Quest.ClearQuests();

            E_Types.Map.Npc = new int[Constants.MAX_MAP_NPCS + 1];

            Types.Item = new ItemRec[501];
            for (var i = 0; i <= Constants.MAX_ITEMS; i++)
            {
                for (var x = 0; x <= (byte)Enums.StatType.Count - 1; x++)
                    Types.Item[i].Add_Stat = new byte[x + 1];
                for (int x = 0; x <= (int)Enums.StatType.Count - 1; x++)
                    Types.Item[i].Stat_Req = new byte[x + 1];

                Types.Item[i].FurnitureBlocks = new int[4, 4];
                Types.Item[i].FurnitureFringe = new int[4, 4];
            }

            Types.Npc = new NpcRec[501];
            for (var i = 0; i <= Constants.MAX_NPCS; i++)
            {
                for (var x = 0; x <= (int)Enums.StatType.Count - 1; x++)
                    Types.Npc[i].Stat = new byte[x + 1];

                Types.Npc[i].DropChance = new int[6];
                Types.Npc[i].DropItem = new int[6];
                Types.Npc[i].DropItemValue = new int[6];

                Types.Npc[i].Skill = new byte[7];
            }

            E_Types.MapNpc = new MapNpcRec[Constants.MAX_MAP_NPCS + 1];
            for (var i = 0; i <= Constants.MAX_MAP_NPCS; i++)
            {
                for (var x = 0; x <= (int)Enums.VitalType.Count - 1; x++)
                    E_Types.MapNpc[i].Vital = new int[x + 1];
            }

            Types.Shop = new ShopRec[51];
            for (var i = 0; i <= Constants.MAX_SHOPS; i++)
            {
                for (var x = 0; x <= Constants.MAX_TRADES; x++)
                    Types.Shop[i].TradeItem = new TradeItemRec[x + 1];
            }

            Types.Animation = new AnimationRec[501];
            for (var i = 0; i <= Constants.MAX_ANIMATIONS; i++)
            {
                for (var x = 0; x <= 1; x++)
                    Types.Animation[i].Sprite = new int[x + 1];
                for (int x = 0; x <= 1; x++)
                    Types.Animation[i].Frames = new int[x + 1];
                for (int x = 0; x <= 1; x++)
                    Types.Animation[i].LoopCount = new int[x + 1];
                for (int x = 0; x <= 1; x++)
                    Types.Animation[i].LoopTime = new int[x + 1];
            }

            // craft
            E_Crafting.ClearRecipes();

            // pets
            E_Pets.ClearPets();

            // load options
            if (File.Exists(Application.StartupPath + @"\Data\Config.xml"))
                LoadOptions();
            else
                CreateOptions();

            E_NetworkConfig.InitNetwork();

            E_Globals.GameDestroyed = false;
            E_Globals.GameStarted = true;

            My.MyProject.Forms.FrmLogin.Visible = true;

            GameLoop();
        }



        internal static void CreateOptions()
        {
            XmlClass myXml = new XmlClass()
            {
                Filename = Application.StartupPath + @"\Data\Config.xml",
                Root = "Options"
            };

            myXml.NewXmlDocument();

            E_Types.Options.Password = "";
            E_Types.Options.SavePass = false;
            E_Types.Options.Username = "";
            E_Types.Options.IP = "Localhost";
            E_Types.Options.Port = 7001;
            E_Types.Options.MenuMusic = "";
            E_Types.Options.Music = 1;
            E_Types.Options.Sound = 1;
            E_Types.Options.Volume = 100;

            myXml.LoadXml();

            myXml.WriteString("UserInfo", "Username", Microsoft.VisualBasic.Strings.Trim(E_Types.Options.Username));
            myXml.WriteString("UserInfo", "Password", Microsoft.VisualBasic.Strings.Trim(E_Types.Options.Password));
            myXml.WriteString("UserInfo", "SavePass", Microsoft.VisualBasic.Strings.Trim(E_Types.Options.SavePass.ToString()));

            myXml.WriteString("Connection", "Ip", Microsoft.VisualBasic.Strings.Trim(E_Types.Options.IP));
            myXml.WriteString("Connection", "Port", Microsoft.VisualBasic.Strings.Trim(E_Types.Options.Port.ToString()));

            myXml.WriteString("Sfx", "MenuMusic", Microsoft.VisualBasic.Strings.Trim(E_Types.Options.MenuMusic));
            myXml.WriteString("Sfx", "Music", Microsoft.VisualBasic.Strings.Trim(E_Types.Options.Music.ToString()));
            myXml.WriteString("Sfx", "Sound", Microsoft.VisualBasic.Strings.Trim(E_Types.Options.Sound.ToString()));
            myXml.WriteString("Sfx", "Volume", Microsoft.VisualBasic.Strings.Trim(E_Types.Options.Volume.ToString()));

            myXml.CloseXml(true);
        }

        internal static void LoadOptions()
        {
            XmlClass myXml = new XmlClass()
            {
                Filename = Application.StartupPath + @"\Data\Config.xml",
                Root = "Options"
            };

            myXml.LoadXml();

            E_Types.Options.Username = myXml.ReadString("UserInfo", "Username", "");
            E_Types.Options.Password = myXml.ReadString("UserInfo", "Password", "");
            E_Types.Options.SavePass = Convert.ToBoolean(myXml.ReadString("UserInfo", "SavePass", "False"));

            E_Types.Options.IP = myXml.ReadString("Connection", "Ip", "127.0.0.1");
            E_Types.Options.Port = (int)Conversion.Val(myXml.ReadString("Connection", "Port", "7001"));

            E_Types.Options.MenuMusic = myXml.ReadString("Sfx", "MenuMusic", "");
            E_Types.Options.Music = (byte)Convert.ToInt32(myXml.ReadString("Sfx", "Music", "1"));
            E_Types.Options.Sound = (byte)Convert.ToInt32(myXml.ReadString("Sfx", "Sound", "1"));
            E_Types.Options.Volume = (int)Conversion.Val(myXml.ReadString("Sfx", "Volume", "100"));

            myXml.CloseXml(false);

            //My.MyProject.Forms.FrmLogin.txtLogin.Text = E_Types.Options.Username;
            //My.MyProject.Forms.FrmLogin.txtPassword.Text = E_Types.Options.Password;
        }


        public static void GameLoop()
        {
            Point dest = new Point(My.MyProject.Forms.frmMapEditor.PointToScreen(My.MyProject.Forms.frmMapEditor.picScreen.Location).X, My.MyProject.Forms.frmMapEditor.PointToScreen(My.MyProject.Forms.frmMapEditor.picScreen.Location).Y);
            Graphics g = My.MyProject.Forms.frmMapEditor.picScreen.CreateGraphics();
            int starttime = 0;
            int Tick = 0;
            int fogtmr = 0;
            int FrameTime = 0;
            int tmr500 = 0;
            int tmpfps = 0;
            int rendercount = 0;

            starttime = ClientDataBase.GetTickCount();

            do
            {
                if (E_Globals.GameDestroyed == true)
                    System.Environment.Exit(0);
                UpdateUI();
                if (E_Globals.GameStarted == true)
                {
                    Tick = ClientDataBase.GetTickCount();

                    // update animation editor
                    if (E_Globals.Editor == E_Globals.EDITOR_ANIMATION)
                        E_Graphics.EditorAnim_DrawAnim();
                    FrameTime = Tick;
                    if (E_Globals.InMapEditor && !E_Globals.GettingMap)
                    {

                        // Calculate FPS
                        if (starttime < Tick)
                        {
                            E_Globals.FPS = tmpfps;
                            My.MyProject.Forms.frmMapEditor.tsCurFps.Text = "Current FPS: " + E_Globals.FPS;
                            tmpfps = 0;
                            starttime = ClientDataBase.GetTickCount() + 1000;
                        }

                        tmpfps = tmpfps + 1;
                        lock (E_Types.MapLock)
                        {
                            // fog scrolling
                            if (fogtmr < Tick)
                            {
                                if (E_Globals.CurrentFogSpeed > 0)
                                {
                                    // move
                                    E_Globals.fogOffsetX = E_Globals.fogOffsetX - 1;
                                    E_Globals.fogOffsetY = E_Globals.fogOffsetY - 1;
                                    FileSystem.Reset();
                                    if (E_Globals.fogOffsetX < -256)
                                        E_Globals.fogOffsetX = 0;
                                    if (E_Globals.fogOffsetY < -256)
                                        E_Globals.fogOffsetY = 0;
                                    fogtmr = Tick + 255 - E_Globals.CurrentFogSpeed;
                                }
                            }

                            if (tmr500 < Tick)
                            {
                                // animate waterfalls
                                switch (E_AutoTiles.waterfallFrame)
                                {
                                    case 0:
                                        {
                                            E_AutoTiles.waterfallFrame = 1;
                                            break;
                                        }

                                    case 1:
                                        {
                                            E_AutoTiles.waterfallFrame = 2;
                                            break;
                                        }

                                    case 2:
                                        {
                                            E_AutoTiles.waterfallFrame = 0;
                                            break;
                                        }
                                }
                                // animate autotiles
                                switch (E_AutoTiles.autoTileFrame)
                                {
                                    case 0:
                                        {
                                            E_AutoTiles.autoTileFrame = 1;
                                            break;
                                        }

                                    case 1:
                                        {
                                            E_AutoTiles.autoTileFrame = 2;
                                            break;
                                        }

                                    case 2:
                                        {
                                            E_AutoTiles.autoTileFrame = 0;
                                            break;
                                        }
                                }

                                tmr500 = Tick + 500;
                            }

                            E_Weather.ProcessWeather();
                            if (E_Sound.FadeInSwitch == true)
                                E_Sound.FadeIn();
                            if (E_Sound.FadeOutSwitch == true)
                                E_Sound.FadeOut();
                            if (rendercount < Tick)
                            {
                                // Auctual Game Loop Stuff :/
                                E_Graphics.Render_Graphics();
                                rendercount = Tick + 32;
                            }

                            Application.DoEvents();
                            E_Graphics.EditorMap_DrawTileset();
                            if (E_Globals.TakeScreenShot)
                            {
                                if (E_Globals.ScreenShotTimer < Tick)
                                {
                                    SFML.Graphics.Image screenshot = E_Graphics.GameWindow.Capture();
                                    if (!System.IO.Directory.Exists(Application.StartupPath + @"\Data\Screenshots"))
                                        System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Data\Screenshots");
                                    screenshot.SaveToFile(Application.StartupPath + @"\Data\Screenshots\Map" + E_Types.Map.mapNum + ".png");
                                    E_Globals.HideCursor = false;
                                    E_Globals.TakeScreenShot = false;
                                }
                            }

                            if (E_Globals.MakeCache)
                            {
                                if (E_Globals.ScreenShotTimer < Tick)
                                {
                                    SFML.Graphics.Image screenshot = E_Graphics.GameWindow.Capture();
                                    if (!System.IO.Directory.Exists(Application.StartupPath + @"\Data\Cache"))
                                        System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Data\Cache");
                                    screenshot.SaveToFile(Application.StartupPath + @"\Data\Cache\Map" + E_Types.Map.mapNum + ".png");
                                    E_Globals.HideCursor = false;
                                    E_Globals.MakeCache = false;
                                    E_Editors.MapEditorSend();
                                }
                            }
                        }
                    }
                }

                Application.DoEvents();
                Thread.Sleep(1);
            }
            while (true);
        }

        public static void UpdateUI()
        {
            if (E_Globals.InitEditor == true)
            {
                My.MyProject.Forms.FrmLogin.pnlAdmin.Visible = true;
                E_Globals.InitEditor = false;
            }

            if (E_Pets.InitPetEditor == true)
            {
                {
                    var withBlock = My.MyProject.Forms.frmPet;
                    E_Globals.Editor = E_Pets.EDITOR_PET;
                    withBlock.lstIndex.Items.Clear();

                    // Add the names
                    for (var i = 1; i <= Constants.MAX_PETS; i++)
                        withBlock.lstIndex.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(E_Pets.Pet[i].Name));

                    withBlock.cmbEvolve.Items.Clear();

                    withBlock.cmbEvolve.Items.Add("None");

                    // Add the names
                    for (var i = 1; i <= Constants.MAX_PETS; i++)
                        withBlock.cmbEvolve.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(E_Pets.Pet[i].Name));

                    withBlock.Show();
                    withBlock.lstIndex.SelectedIndex = 0;
                    withBlock.cmbEvolve.SelectedIndex = 0;
                    E_Pets.PetEditorInit();
                }
                E_Pets.InitPetEditor = false;
            }

            if (E_Quest.QuestEditorShow == true)
            {
                {
                    var withBlock1 = My.MyProject.Forms.FrmQuest;
                    E_Globals.Editor = E_Quest.EDITOR_TASKS;
                    withBlock1.lstIndex.Items.Clear();
                    withBlock1.cmbQuestReq.Items.Clear();
                    withBlock1.cmbQuestReq.Items.Add("None");
                    // Add the names
                    for (var I = 1; I <= E_Quest.MAX_QUESTS; I++)
                    {
                        withBlock1.lstIndex.Items.Add(I + ": " + Microsoft.VisualBasic.Strings.Trim(E_Quest.Quest[I].Name));
                        withBlock1.cmbQuestReq.Items.Add(I + ": " + Microsoft.VisualBasic.Strings.Trim(E_Quest.Quest[I].Name));
                    }

                    withBlock1.Show();
                    withBlock1.lstIndex.SelectedIndex = 0;
                    E_Quest.QuestEditorInit();
                }
                E_Quest.QuestEditorShow = false;
            }

            if (E_Globals.InitAnimationEditor == true)
            {
                {
                    var withBlock2 = My.MyProject.Forms.FrmAnimation;
                    E_Globals.Editor = E_Globals.EDITOR_ANIMATION;
                    withBlock2.lstIndex.Items.Clear();

                    // Add the names
                    for (var i = 1; i <= Constants.MAX_ANIMATIONS; i++)
                        withBlock2.lstIndex.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Animation[i].Name));

                    withBlock2.Show();
                    withBlock2.lstIndex.SelectedIndex = 0;
                    E_Editors.AnimationEditorInit();
                }
                E_Globals.InitAnimationEditor = false;
            }

            if (E_Globals.InitMapEditor == true)
            {
                E_Editors.MapEditorInit();
                E_Globals.InitMapEditor = false;
            }

            if (E_Globals.InitMapProperties == true)
            {
                E_Editors.MapPropertiesInit();
                E_Globals.InitMapProperties = false;
            }

            if (E_Globals.InitItemEditor == true)
            {
                E_Items.ItemEditorPreInit();
                E_Globals.InitItemEditor = false;
            }

            if (E_Crafting.InitRecipeEditor == true)
            {
                E_Crafting.RecipeEditorPreInit();
                E_Crafting.InitRecipeEditor = false;
            }

            if (E_Globals.InitClassEditor == true)
            {
                E_Editors.ClassEditorInit();
                E_Globals.InitClassEditor = false;
            }

            if (E_Globals.LoadClassInfo == true)
            {
                E_Editors.LoadClass();
                E_Globals.LoadClassInfo = false;
            }

            if (E_Globals.InitResourceEditor == true)
            {
                int i;

                {
                    var withBlock3 = My.MyProject.Forms.FrmResource;
                    E_Globals.Editor = E_Globals.EDITOR_RESOURCE;
                    withBlock3.lstIndex.Items.Clear();

                    // Add the names
                    for (i = 1; i <= Constants.MAX_RESOURCES; i++)
                    {
                        if (Types.Resource[i].Name == null)
                            Types.Resource[i].Name = "";
                        if (Types.Resource[i].SuccessMessage == null)
                            Types.Resource[i].SuccessMessage = "";
                        if (Types.Resource[i].EmptyMessage == null)
                            Types.Resource[i].EmptyMessage = "";
                        withBlock3.lstIndex.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Resource[i].Name));
                    }

                    withBlock3.Show();
                    withBlock3.lstIndex.SelectedIndex = 0;
                    E_Editors.ResourceEditorInit();
                }
                E_Globals.InitResourceEditor = false;
            }

            if (E_Globals.InitNPCEditor == true)
            {
                {
                    var withBlock4 = My.MyProject.Forms.frmNPC;
                    E_Globals.Editor = E_Globals.EDITOR_NPC;
                    withBlock4.lstIndex.Items.Clear();

                    // Add the names
                    for (var i = 1; i <= Constants.MAX_NPCS; i++)
                        withBlock4.lstIndex.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[i].Name));

                    withBlock4.Show();
                    withBlock4.lstIndex.SelectedIndex = 0;
                    E_Editors.NpcEditorInit();
                }
                E_Globals.InitNPCEditor = false;
            }

            if (E_Globals.InitSkillEditor == true)
            {
                {
                    var withBlock5 = My.MyProject.Forms.frmSkill;
                    E_Globals.Editor = E_Globals.EDITOR_SKILL;
                    withBlock5.lstIndex.Items.Clear();

                    // Add the names
                    for (var i = 1; i <= Constants.MAX_SKILLS; i++)
                        withBlock5.lstIndex.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Skill[i].Name));

                    withBlock5.Show();
                    withBlock5.lstIndex.SelectedIndex = 0;
                    E_Editors.SkillEditorInit();
                }
                E_Globals.InitSkillEditor = false;
            }

            if (E_Globals.InitShopEditor == true)
            {
                {
                    var withBlock6 = My.MyProject.Forms.frmShop;
                    E_Globals.Editor = E_Globals.EDITOR_SHOP;
                    withBlock6.lstIndex.Items.Clear();

                    // Add the names
                    for (var i = 1; i <= Constants.MAX_SHOPS; i++)
                        withBlock6.lstIndex.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Shop[i].Name));

                    withBlock6.Show();
                    withBlock6.lstIndex.SelectedIndex = 0;
                    E_Editors.ShopEditorInit();
                }
                E_Globals.InitShopEditor = false;
            }

            if (E_Globals.InitAnimationEditor == true)
            {
                {
                    var withBlock7 = My.MyProject.Forms.FrmAnimation;
                    E_Globals.Editor = E_Globals.EDITOR_ANIMATION;
                    withBlock7.lstIndex.Items.Clear();

                    // Add the names
                    for (var i = 1; i <= Constants.MAX_ANIMATIONS; i++)
                        withBlock7.lstIndex.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Animation[i].Name));

                    withBlock7.Show();
                    withBlock7.lstIndex.SelectedIndex = 0;
                    E_Editors.AnimationEditorInit();
                }
                E_Globals.InitAnimationEditor = false;
            }

            if (E_Housing.HouseEdit == true)
            {
                {
                    var withBlock8 = My.MyProject.Forms.FrmHouse;
                    E_Globals.Editor = E_Globals.EDITOR_HOUSE;
                    withBlock8.lstIndex.Items.Clear();
                    var loopTo = E_Housing.MAX_HOUSES;

                    // Add the names
                    for (var i = 1; i <= loopTo; i++)
                        withBlock8.lstIndex.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(E_Housing.House[i].ConfigName));

                    withBlock8.Show();
                    withBlock8.lstIndex.SelectedIndex = 0;
                }

                E_Housing.HouseEditorInit();

                E_Housing.HouseEdit = false;
            }

            if (E_EventSystem.InitEventEditorForm == true)
            {
                My.MyProject.Forms.frmEvents.InitEventEditorForm();

                // populate form
                {
                    var withBlock9 = My.MyProject.Forms.frmEvents;
                    // set the tabs
                    withBlock9.tabPages.TabPages.Clear();
                    var loopTo1 = E_EventSystem.TmpEvent.PageCount;
                    for (var i = 1; i <= loopTo1; i++)
                        withBlock9.tabPages.TabPages.Add(Conversion.Str(i));
                    // items
                    withBlock9.cmbHasItem.Items.Clear();
                    withBlock9.cmbHasItem.Items.Add("None");
                    for (var i = 1; i <= Constants.MAX_ITEMS; i++)
                        withBlock9.cmbHasItem.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Item[i].Name));
                    // variables
                    withBlock9.cmbPlayerVar.Items.Clear();
                    withBlock9.cmbPlayerVar.Items.Add("None");
                    for (var i = 1; i <= E_EventSystem.MaxVariables; i++)
                        withBlock9.cmbPlayerVar.Items.Add(i + ". " + E_EventSystem.Variables[i]);
                    // variables
                    withBlock9.cmbPlayerSwitch.Items.Clear();
                    withBlock9.cmbPlayerSwitch.Items.Add("None");
                    for (var i = 1; i <= E_EventSystem.MaxSwitches; i++)
                        withBlock9.cmbPlayerSwitch.Items.Add(i + ". " + E_EventSystem.Switches[i]);
                    // name
                    withBlock9.txtName.Text = E_EventSystem.TmpEvent.Name;
                    // enable delete button
                    if (E_EventSystem.TmpEvent.PageCount > 1)
                        withBlock9.btnDeletePage.Enabled = true;
                    else
                        withBlock9.btnDeletePage.Enabled = false;
                    withBlock9.btnPastePage.Enabled = false;
                    // Load page 1 to start off with
                    E_EventSystem.CurPageNum = 1;
                    E_EventSystem.EventEditorLoadPage(E_EventSystem.CurPageNum);

                    withBlock9.nudShowTextFace.Maximum = E_Graphics.NumFaces;
                    withBlock9.nudShowChoicesFace.Maximum = E_Graphics.NumFaces;
                }
                // show the editor
                My.MyProject.Forms.frmEvents.Show();

                E_EventSystem.InitEventEditorForm = false;
            }

            if (E_Projectiles.InitProjectileEditor == true)
            {
                {
                    var withBlock10 = My.MyProject.Forms.frmProjectile;
                    E_Globals.Editor = E_Projectiles.EDITOR_PROJECTILE;
                    withBlock10.lstIndex.Items.Clear();

                    // Add the names
                    for (var i = 1; i <= E_Projectiles.MAX_PROJECTILES; i++)
                        withBlock10.lstIndex.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(E_Projectiles.Projectiles[i].Name));

                    withBlock10.Show();
                    withBlock10.lstIndex.SelectedIndex = 0;
                    E_Projectiles.ProjectileEditorInit();
                }

                E_Projectiles.InitProjectileEditor = false;
            }

            if (My.MyProject.Forms.frmProjectile.Visible)
                E_Projectiles.EditorProjectile_DrawProjectile();

            if (E_Globals.InitAutoMapper == true)
            {
                E_AutoMap.OpenAutomapper();
                E_Globals.InitAutoMapper = false;
            }
        }

        public static void CloseEditor()
        {
            E_NetworkSend.SendLeaveGame();

            E_Globals.GameDestroyed = true;
            E_Globals.GameStarted = false;

            Application.Exit();
        }
    }
}
