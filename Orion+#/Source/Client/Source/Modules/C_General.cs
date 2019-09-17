
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Engine;


namespace Engine
{
	sealed class C_General
	{
		
		internal static bool Started;
		
		internal static int GetTickCount()
		{
			return Environment.TickCount;
		}
		
		public static void Startup()
		{
			SFML.Portable.Activate();
			
			SetStatus(Strings.Get("loadscreen", "loading"));
			
			FrmMenu.Default.Visible = true;

            Application.DoEvents();

            C_Types.CharSelection = new C_Types.CharSelRec[4];
			
			C_Types.Player = new C_Types.PlayerRec[Constants.MAX_PLAYERS + 1];
			
			for (var i = 1; i <= Constants.MAX_PLAYERS; i++)
			{
				C_Player.ClearPlayer(i);
			}
			
			C_AutoTiles.ClearAutotiles();
			
			//Housing
			C_Housing.House = new C_Housing.HouseRec[C_Housing.MaxHouses + 1];
			C_Housing.HouseConfig = new C_Housing.HouseRec[C_Housing.MaxHouses + 1];
			
			//quests
			C_Quest.ClearQuests();
			
			//npc's
			C_DataBase.ClearNpcs();
			C_Maps.Map.Npc = new int[Constants.MAX_MAP_NPCS + 1];
			C_Maps.MapNpc = new C_Types.MapNpcRec[Constants.MAX_MAP_NPCS + 1];
			for (var i = 0; i <= Constants.MAX_MAP_NPCS; i++)
			{
				for (var x = 0; x <= (int) Enums.VitalType.Count - 1; x++)
				{
					C_Maps.MapNpc[(int) i].Vital = new int[(int) x + 1];
				}
			}
			
			C_Shops.ClearShops();
			
			C_DataBase.ClearAnimations();
			
			C_DataBase.ClearAnimInstances();
			
			C_Banks.ClearBank();
			
			C_Projectiles.MapProjectiles = new C_Projectiles.MapProjectileRec[C_Projectiles.MaxProjectiles + 1];
			C_Projectiles.Projectiles = new C_Projectiles.ProjectileRec[C_Projectiles.MaxProjectiles + 1];
			
			C_Items.ClearItems();
			
			//craft
			C_Crafting.ClearRecipes();
			
			//party
			C_Parties.ClearParty();
			
			//pets
			C_Pets.ClearPets();
			
			C_Variables.GettingMap = true;
			C_Variables.VbQuote = System.Convert.ToString((char) 34); // "
			
			// Update the form with the game's name before it's loaded
			FrmGame.Default.Text = C_Constants.GameName;
			
			SetStatus(Strings.Get("loadscreen", "options"));
			
			// load options
			if (File.Exists(Application.StartupPath + "\\Data\\Config.xml"))
			{
				C_DataBase.LoadOptions();
			}
			else
			{
				C_DataBase.CreateOptions();
			}
			
			// randomize rnd's seed
			VBMath.Randomize();
			
			SetStatus(Strings.Get("loadscreen", "network"));
			
			FrmMenu.Default.Text = C_Constants.GameName;
			
			// DX7 Master Object is already created, early binding
			SetStatus(Strings.Get("loadscreen", "graphics"));
			C_Maps.CheckTilesets();
			C_DataBase.CheckCharacters();
			C_DataBase.CheckPaperdolls();
			C_DataBase.CheckAnimations();
			C_Items.CheckItems();
			C_Resources.CheckResources();
			C_DataBase.CheckSkillIcons();
			C_DataBase.CheckFaces();
			C_DataBase.CheckFog();
			C_DataBase.CacheMusic();
			C_DataBase.CacheSound();
			C_DataBase.CheckEmotes();
			C_DataBase.CheckPanoramas();
			C_Housing.CheckFurniture();
			C_Projectiles.CheckProjectiles();
			C_DataBase.CheckParallax();
			
			C_Graphics.InitGraphics();
			
			// check if we have main-menu music
			if (C_Types.Options.Music == 1 && C_Types.Options.MenuMusic.Trim().Length > 0)
			{
				C_Sound.PlayMusic(C_Types.Options.MenuMusic.Trim());
				C_Sound.MusicPlayer.Volume = 100;
			}
			
			// Reset values
			C_Variables.Ping = -1;
			
			// set values for directional blocking arrows
			C_Variables.DirArrowX[1] = 12; // up
			C_Variables.DirArrowY[1] = 0;

			C_Variables.DirArrowX[2] = 12; // down
			C_Variables.DirArrowY[2] = 23;

			C_Variables.DirArrowX[3] = 0; // left
			C_Variables.DirArrowY[3] = 12;

			C_Variables.DirArrowX[4] = 23; // right
			C_Variables.DirArrowY[4] = 12;
			
			//set gui switches
			C_UpdateUI.HudVisible = true;
			
			SetStatus(Strings.Get("loadscreen", "starting"));
			Started = true;
			C_UpdateUI.Frmmenuvisible = true;
			C_UpdateUI.Pnlloadvisible = false;
			
			//C_UpdateUI.PnlInventoryVisible = true;
			
			C_NetworkConfig.InitNetwork();
			
			C_GameLogic.GameLoop();
		}
		
		internal static bool IsLoginLegal(string username, string password)
		{
			return username.Trim().Length >= 3 && password.Trim().Length >= 3;
		}
		
		internal static bool IsStringLegal(string sInput)
		{
			int i = 0;
			
			// Prevent high ascii chars
			for (i = 1; i <= sInput.Length; i++)
			{
				
				if ((Microsoft.VisualBasic.Strings.Asc(sInput.Substring(i - 1, 1))) < 32 || Microsoft.VisualBasic.Strings.Asc(sInput.Substring(i - 1, 1)) > 126)
				{
					Interaction.MsgBox(Strings.Get("mainmenu", "stringlegal"), Microsoft.VisualBasic.Constants.vbOKOnly, C_Constants.GameName);
					return false;
					
				}
				
			}
			
			return true;
		}
		
		public static void GameInit()
		{
			C_UpdateUI.Pnlloadvisible = false;

            // Set the focus
            //This is sometimes called on a differant thread than picscreen was created on, so gotta do some more complicated stuffsss
            FrmGame.Default.picscreen.Invoke(new Action(() => FrmGame.Default.picscreen.Focus()));
			
			//stop the song playing
			C_Sound.StopMusic();
		}
		
		internal static void SetStatus(string caption)
		{
			//This is sometimes called on a differant thread than lblStatus was created on, so gotta do some more complicated stuffsss
            FrmMenu.Default.lblStatus.Invoke(new Action(() => FrmMenu.Default.lblStatus.Text = caption));
        }
		
		internal static void MenuState(int state)
		{
			C_UpdateUI.Pnlloadvisible = true;
			C_UpdateUI.Frmmenuvisible = false;
			switch (state)
			{
				case C_Constants.MenuStateAddchar:
					C_UpdateUI.PnlCharCreateVisible = false;
					C_UpdateUI.PnlLoginVisible = false;
					C_UpdateUI.PnlRegisterVisible = false;
					C_UpdateUI.PnlCreditsVisible = false;
					
					if (ConnectToServer(1))
					{
						SetStatus(Strings.Get("mainmenu", "sendaddchar"));
						
						if (FrmMenu.Default.rdoMale.Checked == true)
						{
							C_NetworkSend.SendAddChar(C_Variables.SelectedChar, FrmMenu.Default.txtCharName.Text, (System.Int32) Enums.SexType.Male, FrmMenu.Default.cmbClass.SelectedIndex + 1, C_Variables.NewCharSprite);
						}
						else
						{
							C_NetworkSend.SendAddChar(C_Variables.SelectedChar, FrmMenu.Default.txtCharName.Text, (System.Int32) Enums.SexType.Female, FrmMenu.Default.cmbClass.SelectedIndex + 1, C_Variables.NewCharSprite);
						}
					}
					break;
					
				case C_Constants.MenuStateNewaccount:
					C_UpdateUI.PnlLoginVisible = false;
					C_UpdateUI.PnlCharCreateVisible = false;
					C_UpdateUI.PnlRegisterVisible = false;
					C_UpdateUI.PnlCreditsVisible = false;
					
					if (ConnectToServer(1))
					{
						SetStatus(Strings.Get("mainmenu", "sendnewacc"));
						C_NetworkSend.SendNewAccount(FrmMenu.Default.txtRuser.Text, FrmMenu.Default.txtRPass.Text);
					}
					break;
					
				case C_Constants.MenuStateLogin:
					C_UpdateUI.PnlLoginVisible = false;
					C_UpdateUI.PnlCharCreateVisible = false;
					C_UpdateUI.PnlRegisterVisible = false;
					C_UpdateUI.PnlCreditsVisible = false;
					C_UpdateUI.TempUserName = FrmMenu.Default.txtLogin.Text;
					C_UpdateUI.TempPassword = FrmMenu.Default.txtPassword.Text;
					
					if (ConnectToServer(1))
					{
						SetStatus(Strings.Get("mainmenu", "sendlogin"));
						C_NetworkSend.SendLogin(FrmMenu.Default.txtLogin.Text, FrmMenu.Default.txtPassword.Text);
						return;
					}
					break;
			}
			
		}
		
		internal static bool ConnectToServer(int i)
		{
			bool returnValue = false;
			int Until;
			returnValue = false;
			
			// Check to see if we are already connected, if so just exit
			if (C_NetworkConfig.Socket.IsConnected)
			{
				return true;
				
			}
			
			if (i == 4)
			{
				return returnValue;
			}
			Until = GetTickCount() + 3500;
			
			C_NetworkConfig.Connect();
			
			SetStatus(Strings.Get("mainmenu", "connectserver", i));
			
			// Wait until connected or a few seconds have passed and report the server being down
			while ((!C_NetworkConfig.Socket.IsConnected) && (GetTickCount() <= Until))
			{
				Application.DoEvents();
				Thread.Sleep(10);
			}
			
			// return value
			if (C_NetworkConfig.Socket.IsConnected)
			{
				returnValue = true;
			}
			
			if (returnValue)
			{
				ConnectToServer(i + 1);
			}
			
			return returnValue;
		}
		
		internal static void RePositionGui()
		{
			
			//first change the tiles
			if (C_Types.Options.ScreenSize == 0) // 800x600
			{
				C_Constants.ScreenMapx = (byte) 25;
				C_Constants.ScreenMapy = (byte) 19;
			}
			else if (C_Types.Options.ScreenSize == 1) //1024x768
			{
				C_Constants.ScreenMapx = (byte) 31;
				C_Constants.ScreenMapy = (byte) 24;
			}
			else if (C_Types.Options.ScreenSize == 2)
			{
				C_Constants.ScreenMapx = (byte) 35;
				C_Constants.ScreenMapy = (byte) 26;
			}
			
			//then the window
			FrmGame.Default.ClientSize = new System.Drawing.Size((C_Constants.ScreenMapx) * C_Constants.PicX + C_Constants.PicX, (C_Constants.ScreenMapy) * C_Constants.PicY + C_Constants.PicY);
			FrmGame.Default.picscreen.Width = (C_Constants.ScreenMapx) * C_Constants.PicX + C_Constants.PicX;
			FrmGame.Default.picscreen.Height = (C_Constants.ScreenMapy) * C_Constants.PicY + C_Constants.PicY;
			
			C_Constants.HalfX = System.Convert.ToInt32(((C_Constants.ScreenMapx) / 2) * C_Constants.PicX);
			C_Constants.HalfY = System.Convert.ToInt32(((C_Constants.ScreenMapy) / 2) * C_Constants.PicY);
			C_Constants.ScreenX = (C_Constants.ScreenMapx) * C_Constants.PicX;
			C_Constants.ScreenY = (C_Constants.ScreenMapy) * C_Constants.PicY;
			
			C_Graphics.GameWindow.SetView(new SFML.Graphics.View(new SFML.Graphics.FloatRect(0, 0, (C_Constants.ScreenMapx) * C_Constants.PicX + C_Constants.PicX, (C_Constants.ScreenMapy) * C_Constants.PicY + C_Constants.PicY)));
			
			//Then we can recalculate the positions
			
			//chatwindow
			C_UpdateUI.ChatWindowX = 1;
			C_UpdateUI.ChatWindowY = FrmGame.Default.Height - C_Graphics.ChatWindowGfxInfo.Height - 65;
			
			C_UpdateUI.MyChatX = 1;
			C_UpdateUI.MyChatY = FrmGame.Default.Height - 60;
			
			//hotbar
			if (C_Types.Options.ScreenSize == 0)
			{
				C_UpdateUI.HotbarX = C_UpdateUI.HudWindowX + C_Graphics.HudPanelGfxInfo.Width + 20;
				C_UpdateUI.HotbarY = 5;
				
				//petbar
				C_UpdateUI.PetbarX = C_UpdateUI.HotbarX;
				C_UpdateUI.PetbarY = C_UpdateUI.HotbarY + 34;
			}
			else
			{
				C_UpdateUI.HotbarX = C_UpdateUI.ChatWindowX + C_Graphics.MyChatWindowGfxInfo.Width + 50;
				C_UpdateUI.HotbarY = FrmGame.Default.Height - C_Graphics.HotBarGfxInfo.Height - 45;
				
				//petbar
				C_UpdateUI.PetbarX = C_UpdateUI.HotbarX;
				C_UpdateUI.PetbarY = C_UpdateUI.HotbarY - 34;
			}
			
			//action panel
			C_UpdateUI.ActionPanelX = FrmGame.Default.Width - C_Graphics.ActionPanelGfxInfo.Width - 25;
			C_UpdateUI.ActionPanelY = FrmGame.Default.Height - C_Graphics.ActionPanelGfxInfo.Height - 45;
			
			//Char Window
			C_UpdateUI.CharWindowX = FrmGame.Default.Width - C_Graphics.CharPanelGfxInfo.Width - 26;
			C_UpdateUI.CharWindowY = FrmGame.Default.Height - C_Graphics.CharPanelGfxInfo.Height - C_Graphics.ActionPanelGfxInfo.Height - 50;
			
			//inv Window
			C_UpdateUI.InvWindowX = FrmGame.Default.Width - C_Graphics.InvPanelGfxInfo.Width - 26;
			C_UpdateUI.InvWindowY = FrmGame.Default.Height - C_Graphics.InvPanelGfxInfo.Height - C_Graphics.ActionPanelGfxInfo.Height - 50;
			
			//skill window
			C_UpdateUI.SkillWindowX = FrmGame.Default.Width - C_Graphics.SkillPanelGfxInfo.Width - 26;
			C_UpdateUI.SkillWindowY = FrmGame.Default.Height - C_Graphics.SkillPanelGfxInfo.Height - C_Graphics.ActionPanelGfxInfo.Height - 50;
			
			//petstat window
			C_UpdateUI.PetStatX = C_UpdateUI.PetbarX;
			C_UpdateUI.PetStatY = C_UpdateUI.PetbarY - C_Graphics.PetStatsGfxInfo.Height - 10;
		}
		
		internal static void DestroyGame(bool restart = false)
		{
			//SendLeaveGame()
			// break out of GameLoop
            if (restart)
            {
                RestartGame();
            }
            else
            {
                C_Variables.InGame = false;

                C_Graphics.DestroyGraphics();
                C_UpdateUI.GameDestroyed = true;
                C_NetworkConfig.DestroyNetwork();
                Application.Exit();
                ProjectData.EndApp();
            }
		}

        internal static void RestartGame()
        {
            // Return to main Menu
            Application.Restart();
            Application.ExitThread();
        }
		
		internal static void CheckDir(string dirPath)
		{
			
			if (!System.IO.Directory.Exists(dirPath))
			{
				System.IO.Directory.CreateDirectory(dirPath);
			}
			
		}
		
		internal static string GetExceptionInfo(Exception ex)
		{
			string result = "";
			int hr = System.Runtime.InteropServices.Marshal.GetHRForException(ex);
			result = ex.GetType().ToString() + "(0x" + hr.ToString("X8") + "): " + ex.Message + Environment.NewLine + ex.StackTrace + Environment.NewLine;
			StackTrace st = new StackTrace(ex, true);
			foreach (StackFrame sf in st.GetFrames())
			{
				if (sf.GetFileLineNumber() > 0)
				{
					result += "Line:" + System.Convert.ToString(sf.GetFileLineNumber()) + " Filename: " + System.IO.Path.GetFileName(sf.GetFileName()) + Environment.NewLine;
				}
			}
			return result;
		}
		
	}
}
