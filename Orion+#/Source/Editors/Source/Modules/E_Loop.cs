
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using System.IO;
using System.Threading;
using Microsoft.VisualBasic.CompilerServices;
using Engine;


namespace Engine
{
	sealed class E_Loop
	{
		
#region Startup
		
		internal static void Main()
		{
			
			//check if we are in the right place...
			if (!System.IO.Directory.Exists(Application.StartupPath + "\\Data"))
			{
				MessageBox.Show("Run Editor from inside the Client folder!");
				ProjectData.EndApp();
			}
			
			if (E_Globals.GameStarted == true)
			{
				return;
			}
			
			SFML.Portable.Activate();
			
			//Strings.Init(1, "English")
			
			ClientDataBase.ClearTempTile();
			
			// set values for directional blocking arrows
			E_Globals.DirArrowX[1] = (byte) 12; // up
			E_Globals.DirArrowY[1] = (byte) 0;
			E_Globals.DirArrowX[2] = (byte) 12; // down
			E_Globals.DirArrowY[2] = (byte) 23;
			E_Globals.DirArrowX[3] = (byte) 0; // left
			E_Globals.DirArrowY[3] = (byte) 12;
			E_Globals.DirArrowX[4] = (byte) 23; // right
			E_Globals.DirArrowY[4] = (byte) 12;
			
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
			
			E_Graphics.InitGraphics();
			
			E_AutoTiles.Autotile = new E_AutoTiles.AutotileRec[E_Types.Map.MaxX + 1, E_Types.Map.MaxY + 1];
			
			for (var X = 0; X <= E_Types.Map.MaxX; X++)
			{
				for (var Y = 0; Y <= E_Types.Map.MaxY; Y++)
				{
					E_AutoTiles.Autotile[(int) X, (int) Y].Layer = new E_AutoTiles.QuarterTileRec[(int) Enums.LayerType.Count];
					for (var i = 0; i <= (int) Enums.LayerType.Count - 1; i++)
					{
						E_AutoTiles.Autotile[(int) X, (int) Y].Layer[(int) i].srcX = new int[5];
						E_AutoTiles.Autotile[(int) X, (int) Y].Layer[(int) i].srcY = new int[5];
						E_AutoTiles.Autotile[(int) X, (int) Y].Layer[(int) i].QuarterTile = new E_AutoTiles.PointRec[5];
					}
				}
			}
			
			//'Housing
			E_Housing.House = new E_Housing.HouseRec[E_Housing.MAX_HOUSES + 1];
			E_Housing.HouseConfig = new E_Housing.HouseRec[E_Housing.MAX_HOUSES + 1];
			
			//quests
			E_Quest.Quest = new E_Quest.QuestRec[E_Quest.MAX_QUESTS + 1];
			E_Quest.ClearQuests();
			
			E_Types.Map.Npc = new int[Constants.MAX_MAP_NPCS + 1];
			
			Types.Item = new Types.ItemRec[Constants.MAX_ITEMS + 1];
			for (var i = 0; i <= Constants.MAX_ITEMS; i++)
			{
				for (var x = 0; x <= (int) Enums.StatType.Count - 1; x++)
				{
					Types.Item[(int) i].Add_Stat = new byte[(int) x + 1];
				}
				for (var x = 0; x <= (int) Enums.StatType.Count - 1; x++)
				{
					Types.Item[(int) i].Stat_Req = new byte[(int) x + 1];
				}
				
				Types.Item[(int) i].FurnitureBlocks = new int[4, 4];
				Types.Item[(int) i].FurnitureFringe = new int[4, 4];
			}
			
			Types.Npc = new Types.NpcRec[Constants.MAX_NPCS + 1];
			for (var i = 0; i <= Constants.MAX_NPCS; i++)
			{
				for (var x = 0; x <= (int) Enums.StatType.Count - 1; x++)
				{
					Types.Npc[(int) i].Stat = new byte[(int) x + 1];
				}
				
				Types.Npc[(int) i].DropChance = new int[6];
				Types.Npc[(int) i].DropItem = new int[6];
				Types.Npc[(int) i].DropItemValue = new int[6];
				
				Types.Npc[(int) i].Skill = new byte[7];
			}
			
			E_Types.MapNpc = new E_Types.MapNpcRec[Constants.MAX_MAP_NPCS + 1];
			for (var i = 0; i <= Constants.MAX_MAP_NPCS; i++)
			{
				for (var x = 0; x <= (int) Enums.VitalType.Count - 1; x++)
				{
					E_Types.MapNpc[(int) i].Vital = new int[(int) x + 1];
				}
			}
			
			Types.Shop = new Types.ShopRec[Constants.MAX_SHOPS + 1];
			for (var i = 0; i <= Constants.MAX_SHOPS; i++)
			{
				for (var x = 0; x <= Constants.MAX_TRADES; x++)
				{
					Types.Shop[(int) i].TradeItem = new Types.TradeItemRec[(int) x + 1];
				}
			}
			
			Types.Animation = new Types.AnimationRec[Constants.MAX_ANIMATIONS + 1];
			for (var i = 0; i <= Constants.MAX_ANIMATIONS; i++)
			{
				for (var x = 0; x <= 1; x++)
				{
					Types.Animation[(int) i].Sprite = new int[(int) x + 1];
				}
				for (var x = 0; x <= 1; x++)
				{
					Types.Animation[(int) i].Frames = new int[(int) x + 1];
				}
				for (var x = 0; x <= 1; x++)
				{
					Types.Animation[(int) i].LoopCount = new int[(int) x + 1];
				}
				for (var x = 0; x <= 1; x++)
				{
					Types.Animation[(int) i].LoopTime = new int[(int) x + 1];
				}
			}
			
			//craft
			E_Crafting.ClearRecipes();
			
			//pets
			E_Pets.ClearPets();
			
			// load options
			if (File.Exists(Application.StartupPath + "\\Data\\Config.xml"))
			{
				LoadOptions();
			}
			else
			{
				CreateOptions();
			}
			
			E_NetworkConfig.InitNetwork();
			
			E_Globals.GameDestroyed = false;
			E_Globals.GameStarted = true;
			
			FrmLogin.Default.Visible = true;
			
			GameLoop();
			
		}
		
#endregion
		
#region Options
		
		internal static void CreateOptions()
		{
			XmlClass myXml = new XmlClass() {
					Filename = Application.StartupPath + "\\Data\\Config.xml",
					Root = "Options"
				};
			
			myXml.NewXmlDocument();
			
			E_Types.Options.Password = "";
			E_Types.Options.SavePass = false;
			E_Types.Options.Username = "";
			E_Types.Options.IP = "Localhost";
			E_Types.Options.Port = 7001;
			E_Types.Options.MenuMusic = "";
			E_Types.Options.Music = (byte) 1;
			E_Types.Options.Sound = (byte) 1;
			E_Types.Options.Volume = 100;
			
			myXml.LoadXml();
			
			myXml.WriteString("UserInfo", "Username", E_Types.Options.Username.Trim());
			myXml.WriteString("UserInfo", "Password", E_Types.Options.Password.Trim());
			myXml.WriteString("UserInfo", "SavePass", System.Convert.ToString(E_Types.Options.SavePass).Trim());
			
			myXml.WriteString("Connection", "Ip", E_Types.Options.IP.Trim());
			myXml.WriteString("Connection", "Port", System.Convert.ToString(E_Types.Options.Port).Trim());
			
			myXml.WriteString("Sfx", "MenuMusic", E_Types.Options.MenuMusic.Trim());
			myXml.WriteString("Sfx", "Music", E_Types.Options.Music.ToString());
			myXml.WriteString("Sfx", "Sound", E_Types.Options.Sound.ToString());
			myXml.WriteString("Sfx", "Volume", System.Convert.ToString(E_Types.Options.Volume).Trim());
			
			myXml.CloseXml(true);
		}
		
		internal static void LoadOptions()
		{
			XmlClass myXml = new XmlClass() {
					Filename = Application.StartupPath + "\\Data\\Config.xml",
					Root = "Options"
				};
			
			myXml.LoadXml();
			
			E_Types.Options.Username = myXml.ReadString("UserInfo", "Username", "");
			E_Types.Options.Password = myXml.ReadString("UserInfo", "Password", "");
			E_Types.Options.SavePass = bool.Parse(myXml.ReadString("UserInfo", "SavePass", "False"));
			
			E_Types.Options.IP = myXml.ReadString("Connection", "Ip", "127.0.0.1");
			E_Types.Options.Port = (int)(Conversion.Val(myXml.ReadString("Connection", "Port", "7001")));
			
			E_Types.Options.MenuMusic = myXml.ReadString("Sfx", "MenuMusic", "");
			E_Types.Options.Music = byte.Parse(myXml.ReadString("Sfx", "Music", "1"));
			E_Types.Options.Sound = byte.Parse(myXml.ReadString("Sfx", "Sound", "1"));
			E_Types.Options.Volume = (float) (Conversion.Val(myXml.ReadString("Sfx", "Volume", "100")));
			
			myXml.CloseXml(false);
			
			FrmLogin.Default.txtLogin.Text = E_Types.Options.Username;
			FrmLogin.Default.txtPassword.Text = E_Types.Options.Password;
		}
		
#endregion
		
		public static void GameLoop()
		{
            Point dest = new Point(frmMapEditor.Default.PointToScreen(frmMapEditor.Default.picScreen.Location).X, frmMapEditor.Default.PointToScreen(frmMapEditor.Default.picScreen.Location).Y);
            Graphics g = frmMapEditor.Default.picScreen.CreateGraphics();
			int starttime = 0;
			int Tick = 0;
			int fogtmr = 0;
			int FrameTime;
			int tmr500 = 0;
			int tmpfps = 0;
			int rendercount = 0;
			
			starttime = ClientDataBase.GetTickCount();
			
			do
			{
				if (E_Globals.GameDestroyed == true)
				{
					ProjectData.EndApp();
				}
				
				UpdateUI();
				
				if (E_Globals.GameStarted == true)
				{
					Tick = ClientDataBase.GetTickCount();
					
					// update animation editor
					if (E_Globals.Editor == E_Globals.EDITOR_ANIMATION)
					{
						E_Graphics.EditorAnim_DrawAnim();
					}
					
                    if(E_Globals.Editor == E_Projectiles.EDITOR_PROJECTILE)
                    {
                        E_Graphics.Draw_ProjectilePreview();
                    }

					FrameTime = Tick;
					if (E_Globals.InMapEditor && !E_Globals.GettingMap)
					{
						
						//Calculate FPS
						if (starttime < Tick)
						{
							E_Globals.FPS = tmpfps;
							
							frmMapEditor.Default.tsCurFps.Text = "Current FPS: " + E_Globals.FPS;
							tmpfps = 0;
							starttime = (ClientDataBase.GetTickCount() + 1000);
						}
						tmpfps++;
						
						lock(E_Types.MapLock)
						{
							// fog scrolling
							if (fogtmr < Tick)
							{
								if (E_Globals.CurrentFogSpeed > 0)
								{
									//move
									E_Globals.fogOffsetX--;
									E_Globals.fogOffsetY--;
									FileSystem.Reset();
									if (E_Globals.fogOffsetX < -256)
									{
										E_Globals.fogOffsetX = 0;
									}
									if (E_Globals.fogOffsetY < -256)
									{
										E_Globals.fogOffsetY = 0;
									}
									fogtmr = Tick + 255 - E_Globals.CurrentFogSpeed;
								}
							}
							
							if (tmr500 < Tick)
							{
								// animate waterfalls
								switch (E_AutoTiles.waterfallFrame)
								{
									case 0:
										E_AutoTiles.waterfallFrame = 1;
										break;
									case 1:
										E_AutoTiles.waterfallFrame = 2;
										break;
									case 2:
										E_AutoTiles.waterfallFrame = 0;
										break;
								}
								// animate autotiles
								switch (E_AutoTiles.autoTileFrame)
								{
									case 0:
										E_AutoTiles.autoTileFrame = 1;
										break;
									case 1:
										E_AutoTiles.autoTileFrame = 2;
										break;
									case 2:
										E_AutoTiles.autoTileFrame = 0;
										break;
								}
								
								tmr500 = Tick + 500;
							}
							
							E_Weather.ProcessWeather();
							
							if (E_Sound.FadeInSwitch == true)
							{
								E_Sound.FadeIn();
							}
							
							if (E_Sound.FadeOutSwitch == true)
							{
								E_Sound.FadeOut();
							}
							
							if (rendercount < Tick)
							{
								//Auctual Game Loop Stuff :/
								E_Graphics.Render_Graphics();
								rendercount = Tick + 32;
							}

                            //Do we need this?
                            //Application.DoEvents();

                            E_Graphics.EditorMap_DrawTileset();
							
							if (E_Globals.TakeScreenShot)
							{
								if (E_Globals.ScreenShotTimer < Tick)
								{
									SFML.Graphics.Image screenshot = E_Graphics.GameWindow.Capture();
									
									if (!System.IO.Directory.Exists(Application.StartupPath + "\\Data\\Screenshots"))
									{
										System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Data\\Screenshots");
									}
									screenshot.SaveToFile(Application.StartupPath + "\\Data\\Screenshots\\Map" + System.Convert.ToString(E_Types.Map.mapNum) +".png");
									
									E_Globals.HideCursor = false;
									E_Globals.TakeScreenShot = false;
								}
							}
							
							if (E_Globals.MakeCache)
							{
								if (E_Globals.ScreenShotTimer < Tick)
								{
									SFML.Graphics.Image screenshot = E_Graphics.GameWindow.Capture();
									
									if (!System.IO.Directory.Exists(Application.StartupPath + "\\Data\\Cache"))
									{
										System.IO.Directory.CreateDirectory(Application.StartupPath + "\\Data\\Cache");
									}
									screenshot.SaveToFile(Application.StartupPath + "\\Data\\Cache\\Map" + System.Convert.ToString(E_Types.Map.mapNum) +".png");
									
									E_Globals.HideCursor = false;
									E_Globals.MakeCache = false;
									E_Editors.MapEditorSend();
								}
							}
							
						}
						
					}
				}
				
                // This should be the only one we need?
				Application.DoEvents();
                //Do we need to pause the thread? without it we gain like 200+ fps
                //Thread.Sleep(1);
                // Lets Yield Instead
                Thread.Yield();
            } while (true);
		}
		
		public static void UpdateUI()
		{
			if (E_Globals.InitEditor == true)
			{
				FrmLogin.Default.pnlAdmin.Visible = true;
				E_Globals.InitEditor = false;
			}
			
			if (E_Pets.InitPetEditor == true)
			{
				E_Globals.Editor = E_Pets.EDITOR_PET;
				frmPet.Default.lstIndex.Items.Clear();
				
				// Add the names
				for (var i = 1; i <= Constants.MAX_PETS; i++)
				{
                    if (E_Pets.Pet[(int)i].Name != null)
                    {
                        frmPet.Default.lstIndex.Items.Add(i + ": " + E_Pets.Pet[(int)i].Name.Trim());
                    }
                    else
                    {
                        frmPet.Default.lstIndex.Items.Add(i + ": " + "");
                    }
				}
				
				frmPet.Default.cmbEvolve.Items.Clear();
				
				frmPet.Default.cmbEvolve.Items.Add("None");
				
				// Add the names
				for (var i = 1; i <= Constants.MAX_PETS; i++)
				{
                    if (E_Pets.Pet[(int)i].Name != null)
                    {
                        frmPet.Default.cmbEvolve.Items.Add(i + ": " + E_Pets.Pet[(int)i].Name.Trim());
                    }
                    else
                    {
                        frmPet.Default.cmbEvolve.Items.Add(i + ": " + "Null");
                    }
				}
				
				frmPet.Default.Show();
				frmPet.Default.Visible = true;
				frmPet.Default.lstIndex.SelectedIndex = 0;
				frmPet.Default.cmbEvolve.SelectedIndex = 0;
				E_Pets.PetEditorInit();
				E_Pets.InitPetEditor = false;
			}
			
			if (E_Quest.QuestEditorShow == true)
			{
				E_Globals.Editor = E_Quest.EDITOR_TASKS;
				FrmQuest.Default.lstIndex.Items.Clear();
				FrmQuest.Default.cmbQuestReq.Items.Clear();
				FrmQuest.Default.cmbQuestReq.Items.Add("None");
				// Add the names
				for (var I = 1; I <= E_Quest.MAX_QUESTS; I++)
				{
                    if (E_Quest.Quest[(int)I].Name != null)
                    {
                        FrmQuest.Default.lstIndex.Items.Add(I + ": " + E_Quest.Quest[(int)I].Name.Trim());
                        FrmQuest.Default.cmbQuestReq.Items.Add(I + ": " + E_Quest.Quest[(int)I].Name.Trim());
                    }
                    else
                    {
                        FrmQuest.Default.lstIndex.Items.Add(I + ": " + "");
                        FrmQuest.Default.cmbQuestReq.Items.Add(I + ": " + "");
                    }
				}
				
				FrmQuest.Default.Show();
				FrmQuest.Default.Visible = true;
				FrmQuest.Default.lstIndex.SelectedIndex = 0;
				E_Quest.QuestEditorInit();
				E_Quest.QuestEditorShow = false;
			}
			
			if (E_Globals.InitAnimationEditor == true)
			{
				E_Globals.Editor = E_Globals.EDITOR_ANIMATION;
				FrmAnimation.Default.lstIndex.Items.Clear();
				
				// Add the names
				for (var i = 1; i <= Constants.MAX_ANIMATIONS; i++)
				{
                    if (Types.Animation[(int)i].Name != null)
                    {
                        FrmAnimation.Default.lstIndex.Items.Add(i + ": " + Types.Animation[(int)i].Name.Trim());
                    }
                    else
                    {
                        FrmAnimation.Default.lstIndex.Items.Add(i + ": " + "");
                    }
				}
				
				FrmAnimation.Default.Show();
				FrmAnimation.Default.Visible = true;
				FrmAnimation.Default.lstIndex.SelectedIndex = 0;
				E_Editors.AnimationEditorInit();
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
				int i = 0;
				
				E_Globals.Editor = E_Globals.EDITOR_RESOURCE;
				FrmResource.Default.lstIndex.Items.Clear();
				
				// Add the names
				for (i = 1; i <= Constants.MAX_RESOURCES; i++)
				{
					if (Types.Resource[i].Name == null)
					{
						Types.Resource[i].Name = "";
					}
					if (Types.Resource[i].SuccessMessage == null)
					{
						Types.Resource[i].SuccessMessage = "";
					}
					if (Types.Resource[i].EmptyMessage == null)
					{
						Types.Resource[i].EmptyMessage = "";
					}
					FrmResource.Default.lstIndex.Items.Add(i + ": " + Types.Resource[i].Name.Trim());
				}
				
				FrmResource.Default.Show();
				FrmResource.Default.Visible = true;
				FrmResource.Default.lstIndex.SelectedIndex = 0;
				E_Editors.ResourceEditorInit();
				E_Globals.InitResourceEditor = false;
			}
			
			if (E_Globals.InitNPCEditor == true)
			{
				E_Globals.Editor = E_Globals.EDITOR_NPC;
				frmNPC.Default.lstIndex.Items.Clear();
				
				// Add the names
				for (var i = 1; i <= Constants.MAX_NPCS; i++)
				{
                    if (Types.Npc[(int)i].Name != null)
                    {
                        frmNPC.Default.lstIndex.Items.Add(i + ": " + Types.Npc[(int)i].Name.Trim());
                    }
                    else
                    {
                        frmNPC.Default.lstIndex.Items.Add(i + ": " + "");
                    }
				}
				
				frmNPC.Default.Show();
				frmNPC.Default.Visible = true;
				frmNPC.Default.lstIndex.SelectedIndex = 0;
				E_Editors.NpcEditorInit();
				E_Globals.InitNPCEditor = false;
			}
			
			if (E_Globals.InitSkillEditor == true)
			{
				E_Globals.Editor = E_Globals.EDITOR_SKILL;
				frmSkill.Default.lstIndex.Items.Clear();
				
				// Add the names
				for (var i = 1; i <= Constants.MAX_SKILLS; i++)
				{
                    if (Types.Skill[(int)i].Name != null)
                    {
                        frmSkill.Default.lstIndex.Items.Add(i + ": " + Types.Skill[(int)i].Name.Trim());
                    }
                    else
                    {
                        frmSkill.Default.lstIndex.Items.Add(i + ": " + "");
                    }
				}
				
				frmSkill.Default.Show();
				frmSkill.Default.Visible = true;
				frmSkill.Default.lstIndex.SelectedIndex = 0;
				E_Editors.SkillEditorInit();
				E_Globals.InitSkillEditor = false;
			}
			
			if (E_Globals.InitShopEditor == true)
			{
				E_Globals.Editor = E_Globals.EDITOR_SHOP;
				frmShop.Default.lstIndex.Items.Clear();
				
				// Add the names
				for (var i = 1; i <= Constants.MAX_SHOPS; i++)
				{
                    if (Types.Shop[(int)i].Name != null)
                    {
                        frmShop.Default.lstIndex.Items.Add(i + ": " + Types.Shop[(int)i].Name.Trim());
                    }
                    else
                    {
                        frmShop.Default.lstIndex.Items.Add(i + ": " + "");
                    }
				}
				
				frmShop.Default.Show();
                frmShop.Default.Visible = true;

                frmShop.Default.Visible = true;
				frmShop.Default.lstIndex.SelectedIndex = 0;
				E_Editors.ShopEditorInit();
				E_Globals.InitShopEditor = false;
			}
			
			if (E_Globals.InitAnimationEditor == true)
			{
				E_Globals.Editor = E_Globals.EDITOR_ANIMATION;
				FrmAnimation.Default.lstIndex.Items.Clear();
				
				// Add the names
				for (var i = 1; i <= Constants.MAX_ANIMATIONS; i++)
				{
                    if (Types.Animation[(int)i].Name != null)
                    {
                        FrmAnimation.Default.lstIndex.Items.Add(i + ": " + Types.Animation[(int)i].Name.Trim());
                    }
                    else
                    {
                        FrmAnimation.Default.lstIndex.Items.Add(i + ": " + "");
                    }
				}
				
				FrmAnimation.Default.Show();
				FrmAnimation.Default.Visible = true;
				FrmAnimation.Default.lstIndex.SelectedIndex = 0;
				E_Editors.AnimationEditorInit();
				E_Globals.InitAnimationEditor = false;
			}
			
			if (E_Housing.HouseEdit == true)
			{
				E_Globals.Editor = E_Globals.EDITOR_HOUSE;
				FrmHouse.Default.lstIndex.Items.Clear();
				
				// Add the names
				for (var i = 1; i <= E_Housing.MAX_HOUSES; i++)
				{
                    if (E_Housing.House[(int)i].ConfigName != null)
                    {
                        FrmHouse.Default.lstIndex.Items.Add(i + ": " + E_Housing.House[(int)i].ConfigName.Trim());
                    }
                    else
                    {
                        FrmHouse.Default.lstIndex.Items.Add(i + ": " + "");
                    }
				}
				
				FrmHouse.Default.Show();
				FrmHouse.Default.Visible = true;
				FrmHouse.Default.lstIndex.SelectedIndex = 0;
				
				E_Housing.HouseEditorInit();
				
				E_Housing.HouseEdit = false;
			}
			
			if (E_EventSystem.InitEventEditorForm == true)
			{
				frmEvents.Default.InitEventEditorForm();
				
				// populate form
				// set the tabs
				frmEvents.Default.tabPages.TabPages.Clear();
				
				for (var i = 1; i <= E_EventSystem.TmpEvent.PageCount; i++)
				{
                    frmEvents.Default.tabPages.TabPages.Add(Conversion.Str(i));
				}
				// items
				frmEvents.Default.cmbHasItem.Items.Clear();
				frmEvents.Default.cmbHasItem.Items.Add("None");
				for (var i = 1; i <= Constants.MAX_ITEMS; i++)
				{
                    if (Types.Item[(int)i].Name != null)
                    {
                        frmEvents.Default.cmbHasItem.Items.Add(i + ": " + Types.Item[(int)i].Name.Trim());
                    }
                    else
                    {
                        frmEvents.Default.cmbHasItem.Items.Add(i + ": " + "");
                    }
				}
				// variables
				frmEvents.Default.cmbPlayerVar.Items.Clear();
				frmEvents.Default.cmbPlayerVar.Items.Add("None");
				for (var i = 1; i <= E_EventSystem.MaxVariables; i++)
				{
                    if (E_EventSystem.Variables[(int)i] != null)
                    {
                        frmEvents.Default.cmbPlayerVar.Items.Add(i + ". " + E_EventSystem.Variables[(int)i]);
                    }
                    else
                    {
                        frmEvents.Default.cmbPlayerVar.Items.Add(i + ". " + "");
                    }
				}
				// variables
				frmEvents.Default.cmbPlayerSwitch.Items.Clear();
				frmEvents.Default.cmbPlayerSwitch.Items.Add("None");
				for (var i = 1; i <= E_EventSystem.MaxSwitches; i++)
				{
                    if (E_EventSystem.Switches[(int)i] != null)
                    {
                        frmEvents.Default.cmbPlayerSwitch.Items.Add(i + ". " + E_EventSystem.Switches[(int)i]);
                    }
                    else
                    {
                        frmEvents.Default.cmbPlayerSwitch.Items.Add(i + ". " + "");
                    }
                    
				}
				// name
				frmEvents.Default.txtName.Text = E_EventSystem.TmpEvent.Name;
				// enable delete button
				if (E_EventSystem.TmpEvent.PageCount > 1)
				{
					frmEvents.Default.btnDeletePage.Enabled = true;
				}
				else
				{
					frmEvents.Default.btnDeletePage.Enabled = false;
				}
				frmEvents.Default.btnPastePage.Enabled = false;
				// Load page 1 to start off with
				E_EventSystem.CurPageNum = 1;
				E_EventSystem.EventEditorLoadPage(E_EventSystem.CurPageNum);
				
				frmEvents.Default.nudShowTextFace.Maximum = E_Graphics.NumFaces;
				frmEvents.Default.nudShowChoicesFace.Maximum = E_Graphics.NumFaces;
				// show the editor
				frmEvents.Default.Show();
				frmEvents.Default.Visible = true;
				
				E_EventSystem.InitEventEditorForm = false;
			}
			
			if (E_Projectiles.InitProjectileEditor == true)
			{
				E_Globals.Editor = E_Projectiles.EDITOR_PROJECTILE;
				frmProjectile.Default.lstIndex.Items.Clear();
				
				// Add the names
				for (var i = 1; i <= E_Projectiles.MAX_PROJECTILES; i++)
				{
                    if (E_Projectiles.Projectiles[(int)i].Name != null)
                    {
                        frmProjectile.Default.lstIndex.Items.Add(i + ": " + E_Projectiles.Projectiles[(int)i].Name.Trim());
                    }
                    else
                    {
                        frmProjectile.Default.lstIndex.Items.Add(i + ": " + "");
                    }
				}
				
				frmProjectile.Default.Show();
				frmProjectile.Default.Visible = true;
				frmProjectile.Default.lstIndex.SelectedIndex = 0;
				E_Projectiles.ProjectileEditorInit();
				
				E_Projectiles.InitProjectileEditor = false;
			}
			
			if (frmProjectile.Default.Visible)
			{
				E_Projectiles.EditorProjectile_DrawProjectile();
			}
			
			if (E_Globals.InitAutoMapper == true)
			{
				E_AutoMap.OpenAutomapper();
				E_Globals.InitAutoMapper = false;
			}
		}
		
		public static void CloseEditor()
		{
            if (E_NetworkConfig.Socket != null && E_NetworkConfig.Socket.IsConnected)
            {
                E_NetworkSend.SendLeaveGame();
            }
			
			E_Globals.GameDestroyed = true;
			E_Globals.GameStarted = false;

            Application.Exit();
		}
		
	}
}
