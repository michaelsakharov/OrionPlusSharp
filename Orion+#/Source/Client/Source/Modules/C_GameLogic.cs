
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using Asfw;
using Microsoft.VisualBasic.CompilerServices;
using Engine;


namespace Engine
{
	sealed class C_GameLogic
	{
		internal static Random GameRand = new Random();

        private static int lastTick;
        private static int lastFrameRate;
        private static int frameRate;

        public static float deltaTime;
        public static double lastTime;

        private static Stopwatch clock;

        public static void DeltaTime()
        {
            double time = clock.Elapsed.TotalSeconds;
            double delta = (time - lastTime);
            lastTime = time;

            deltaTime = (float)delta;
        }

        public static int CalculateFrameRate()
        {
            int tickCount = Environment.TickCount;
            if (tickCount - lastTick >= 1000)
            {
                lastFrameRate = frameRate;
                frameRate = 0;
                lastTick = tickCount;
            }
            frameRate++;
            return lastFrameRate;
        }

        public static void GameLoop()
		{
			int i = 5;
            Point dest = new Point((Size)FrmGame.Default.PointToScreen(FrmGame.Default.picscreen.Location));

            Graphics g = FrmGame.Default.picscreen.CreateGraphics();
			int starttime = 0;
			int tick = 0;
			int fogtmr = 0;
			int tmplps = 0;
			int walkTimer = 0;
			int frameTime = 0;
			int tmr10000 = 0;
			int tmr1000 = 0;
			int tmrweather = 0;
			int tmr100 = 0;
			int tmr500 = 0;
			int tmrconnect = 0;
			int rendercount = 0;
			int fadetmr = 0;
			int appDoEventsTimer = 0;
			int x = 0;
			int Y = 0;
			
			starttime = C_General.GetTickCount();
			FrmMenu.Default.lblNextChar.Left = C_UpdateUI.Lblnextcharleft;
            
            clock = new Stopwatch();
            clock.Start();

            Application.DoEvents();

            do
			{
                try
                {
                    if (C_UpdateUI.GameDestroyed)
                    {
                        ProjectData.EndApp();
                    }

                    C_Variables.DirDown = C_UpdateUI.VbKeyDown;
                    C_Variables.DirUp = C_UpdateUI.VbKeyUp;
                    C_Variables.DirLeft = C_UpdateUI.VbKeyLeft;
                    C_Variables.DirRight = C_UpdateUI.VbKeyRight;

                    // 8 Directional Movement
                    if (C_Variables.allowEightDirectionalMovement)
                    {
                        C_Variables.DirUpLeft = (C_UpdateUI.VbKeyUp && C_UpdateUI.VbKeyLeft);
                        C_Variables.DirUpRight = (C_UpdateUI.VbKeyUp && C_UpdateUI.VbKeyRight);
                        C_Variables.DirDownLeft = (C_UpdateUI.VbKeyDown && C_UpdateUI.VbKeyLeft);
                        C_Variables.DirDownRight = (C_UpdateUI.VbKeyDown && C_UpdateUI.VbKeyRight);
                    }
                    else
                    {
                        C_Variables.DirUpLeft = false;
                        C_Variables.DirUpRight = false;
                        C_Variables.DirDownLeft = false;
                        C_Variables.DirDownRight = false;
                    }

                    if (C_UpdateUI.Frmmenuvisible == true)
                    {
                        // Were not connected and were in the main menu so lets connect
                        if (C_Discord.client == null)
                        {
                            C_Discord.SetPresence(C_Constants.GameName, "Main Menu");
                        }

                        if (tmrconnect < C_General.GetTickCount())
                        {
                            if (C_NetworkConfig.Socket.IsConnected == true)
                            {
                                FrmMenu.Default.lblServerStatus.ForeColor = Color.LightGreen;
                                FrmMenu.Default.lblServerStatus.Text = Strings.Get("mainmenu", "serveronline");
                            }
                            else
                            {
                                i++;
                                if (i >= 5)
                                {
                                    C_NetworkConfig.Connect();
                                    FrmMenu.Default.lblServerStatus.Text = Strings.Get("mainmenu", "serverreconnect");
                                    FrmMenu.Default.lblServerStatus.ForeColor = Color.Orange;
                                    i = 0;
                                }
                                else
                                {
                                    FrmMenu.Default.lblServerStatus.Text = Strings.Get("mainmenu", "serveroffline");
                                    FrmMenu.Default.lblServerStatus.ForeColor = Color.Red;
                                }
                            }
                            tmrconnect = C_General.GetTickCount() + 500;
                        }
                    }

                    //Update the UI
                    C_UpdateUI.UpdateUi();

                    if (GameStarted())
                    {

                        tick = C_General.GetTickCount();
                        C_Variables.ElapsedTime = tick - frameTime; // Set the time difference for time-based movement

                        frameTime = tick;
                        C_UpdateUI.Frmmaingamevisible = true;

                        //Calculate lps
                        if (starttime < tick)
                        {
                            C_Variables.Lps = tmplps;
                            tmplps = 0;
                            starttime = tick + 1000;
                        }
                        tmplps++;

                        // Update inv animation
                        if (C_Graphics.NumItems > 0)
                        {
                            if (tmr100 < tick)
                            {

                                if (C_Banks.InBank == 1)
                                {
                                    C_Banks.DrawBank();
                                }
                                if (C_Shops.InShop == 1)
                                {
                                    C_Shops.DrawShop();
                                }
                                if (C_Trade.InTrade)
                                {
                                    C_Trade.DrawTrade();
                                }

                                tmr100 = tick + 100;
                            }
                        }

                        if (C_Variables.ShowAnimTimer < tick)
                        {
                            C_Variables.ShowAnimLayers = !C_Variables.ShowAnimLayers;
                            C_Variables.ShowAnimTimer = tick + 500;
                        }

                        for (i = 1; i <= byte.MaxValue; i++)
                        {
                            CheckAnimInstance(i);
                        }

                        if (tick > C_EventSystem.EventChatTimer)
                        {
                            if (string.IsNullOrEmpty(C_EventSystem.EventText))
                            {
                                if (C_EventSystem.EventChat == true)
                                {
                                    C_EventSystem.EventChat = false;
                                    C_UpdateUI.PnlEventChatVisible = false;
                                }
                            }
                        }

                        if (tmr10000 < tick)
                        {
                            //clear any unused gfx
                            //C_Graphics.ClearGfx();

                            C_NetworkSend.GetPing();
                            DrawPing();

                            tmr10000 = tick + 10000;
                        }

                        if (tmr1000 < tick)
                        {
                            Time.Instance.Tick();

                            tmr1000 = tick + 1000;
                        }

                        //crafting timer
                        if (C_Crafting.CraftTimerEnabled)
                        {
                            if (C_Crafting.CraftTimer < tick)
                            {
                                C_Crafting.CraftProgressValue = System.Convert.ToInt32(C_Crafting.CraftProgressValue + (100 / C_Crafting.Recipe[C_Crafting.GetRecipeIndex(C_Crafting.RecipeNames[C_Crafting.SelectedRecipe])].CreateTime));

                                if (C_Crafting.CraftProgressValue >= 100)
                                {
                                    C_Crafting.CraftTimerEnabled = false;
                                }
                                C_Crafting.CraftTimer = tick + 1000;
                            }
                        }

                        //screenshake timer
                        if (C_Variables.ShakeTimerEnabled)
                        {
                            if (C_Variables.ShakeTimer < tick)
                            {
                                if (C_Variables.ShakeCount < 10)
                                {
                                    if (C_Variables.LastDir == 0)
                                    {
                                        FrmGame.Default.picscreen.Location = new Point(FrmGame.Default.picscreen.Location.X + 20, FrmGame.Default.picscreen.Location.Y);
                                        C_Variables.LastDir = (byte)1;
                                    }
                                    else
                                    {
                                        FrmGame.Default.picscreen.Location = new Point(FrmGame.Default.picscreen.Location.X - 20, FrmGame.Default.picscreen.Location.Y);
                                        C_Variables.LastDir = (byte)0;
                                    }
                                }
                                else
                                {
                                    FrmGame.Default.picscreen.Location = new Point(0, 0);
                                    C_Variables.ShakeCount = (byte)0;
                                    C_Variables.ShakeTimerEnabled = false;
                                }

                                C_Variables.ShakeCount++;

                                C_Variables.ShakeTimer = tick + 50;
                            }
                        }

                        // check if trade timed out
                        if (C_Trade.TradeRequest == true)
                        {
                            if (C_Trade.TradeTimer < tick)
                            {
                                C_Text.AddText(Strings.Get("trade", "tradetimeout"), (System.Int32)Enums.ColorType.Yellow);
                                C_Trade.TradeRequest = false;
                                C_Trade.TradeTimer = 0;
                            }
                        }

                        // check if we need to end the CD icon
                        if (C_Graphics.NumSkillIcons > 0)
                        {
                            for (i = 1; i <= Constants.MAX_PLAYER_SKILLS; i++)
                            {
                                if (C_Variables.PlayerSkills[i] > 0)
                                {
                                    if (C_Variables.SkillCd[i] > 0)
                                    {
                                        if (C_Variables.SkillCd[i] + (Types.Skill[C_Variables.PlayerSkills[i]].CdTime * 1000) < tick)
                                        {
                                            C_Variables.SkillCd[i] = 0;
                                            C_Graphics.DrawPlayerSkills();
                                        }
                                    }
                                }
                            }
                        }

                        // check if we need to unlock the player's skill casting restriction
                        if (C_Variables.SkillBuffer > 0)
                        {
                            if (C_Variables.SkillBufferTimer + (Types.Skill[C_Variables.PlayerSkills[C_Variables.SkillBuffer]].CastTime * 100) < tick)
                            {
                                C_Variables.SkillBuffer = 0;
                                C_Variables.SkillBufferTimer = 0;
                            }
                        }
                        // check if we need to unlock the pets's spell casting restriction
                        if (C_Pets.PetSkillBuffer > 0)
                        {
                            if (C_Pets.PetSkillBufferTimer + (Types.Skill[C_Pets.Pet[C_Types.Player[C_Variables.Myindex].Pet.Num].Skill[C_Pets.PetSkillBuffer]].CastTime * 100) < tick)
                            {
                                C_Pets.PetSkillBuffer = 0;
                                C_Pets.PetSkillBufferTimer = 0;
                            }
                        }

                        lock (C_Maps.MapLock)
                        {
                            //Set this to True to use Auto Attack on Client
                            bool UseAutoAttack = false;
                            //AutoAttack
                            if (UseAutoAttack)
                            {
                                if (C_Variables.CanMoveNow)
                                {
                                    switch (C_Player.GetPlayerDir(C_Variables.Myindex))
                                    {
                                        case (int)Enums.DirectionType.Up:
                                            x = C_Player.GetPlayerX(C_Variables.Myindex);
                                            Y = C_Player.GetPlayerY(C_Variables.Myindex) - 1;
                                            break;
                                        case (int)Enums.DirectionType.Down:
                                            x = C_Player.GetPlayerX(C_Variables.Myindex);
                                            Y = C_Player.GetPlayerY(C_Variables.Myindex) + 1;
                                            break;
                                        case (int)Enums.DirectionType.Left:
                                            x = C_Player.GetPlayerX(C_Variables.Myindex) - 1;
                                            Y = C_Player.GetPlayerY(C_Variables.Myindex);
                                            break;
                                        case (int)Enums.DirectionType.Right:
                                            x = C_Player.GetPlayerX(C_Variables.Myindex) + 1;
                                            Y = C_Player.GetPlayerY(C_Variables.Myindex);
                                            break;
                                    }
                                    if (C_Variables.MyTarget > 0)
                                    {
                                        if (x == C_Maps.MapNpc[C_Variables.MyTarget].X && Y == C_Maps.MapNpc[C_Variables.MyTarget].Y)
                                        {
                                            C_Variables.ControlDown = true;
                                        }
                                        else
                                        {
                                            C_Player.CheckMovement(); // Check if player is trying to move
                                            C_Player.CheckAttack(); // Check to see if player is trying to attack
                                        }
                                    }
                                }
                                else
                                {
                                    if (C_Variables.CanMoveNow)
                                    {
                                        switch (C_Player.GetPlayerDir(C_Variables.Myindex))
                                        {
                                            case (int)Enums.DirectionType.Up:
                                                x = C_Player.GetPlayerX(C_Variables.Myindex);
                                                Y = C_Player.GetPlayerY(C_Variables.Myindex) - 1;
                                                break;
                                            case (int)Enums.DirectionType.Down:
                                                x = C_Player.GetPlayerX(C_Variables.Myindex);
                                                Y = C_Player.GetPlayerY(C_Variables.Myindex) + 1;
                                                break;
                                            case (int)Enums.DirectionType.Left:
                                                x = C_Player.GetPlayerX(C_Variables.Myindex) - 1;
                                                Y = C_Player.GetPlayerY(C_Variables.Myindex);
                                                break;
                                            case (int)Enums.DirectionType.Right:
                                                x = C_Player.GetPlayerX(C_Variables.Myindex) + 1;
                                                Y = C_Player.GetPlayerY(C_Variables.Myindex);
                                                break;
                                        }
                                        C_Player.CheckMovement(); // Check if player is trying to move
                                    }
                                }
                            }

                            if (C_Variables.CanMoveNow && !UseAutoAttack)
                            {

                                C_Player.CheckMovement(); // Check if player is trying to move
                                C_Player.CheckAttack(); // Check to see if player is trying to attack
                            }

                            // Process input before rendering, otherwise input will be behind by 1 frame
                            if (walkTimer < tick)
                            {

                                for (i = 1; i <= C_Variables.TotalOnline; i++) //MAX_PLAYERS
                                {
                                    if (C_Player.IsPlaying(i))
                                    {
                                        C_Player.ProcessMovement(i);
                                        if (C_Pets.PetAlive(i))
                                        {
                                            C_Pets.ProcessPetMovement(i);
                                        }
                                    }
                                }

                                // Process npc movements (actually move them)
                                for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                                {
                                    if (C_Maps.Map.Npc[i] > 0)
                                    {
                                        ProcessNpcMovement(i);
                                    }
                                }

                                if (C_Maps.Map.CurrentEvents > 0)
                                {
                                    for (i = 1; i <= C_Maps.Map.CurrentEvents; i++)
                                    {
                                        C_EventSystem.ProcessEventMovement(i);
                                    }
                                }

                                walkTimer = tick + 30; // edit this value to change WalkTimer
                            }

                            // fog scrolling
                            if (fogtmr < tick)
                            {
                                if (C_Weather.CurrentFogSpeed > 0)
                                {
                                    // move
                                    C_Weather.FogOffsetX--;
                                    C_Weather.FogOffsetY--;
                                    // reset
                                    if (C_Weather.FogOffsetX < -255)
                                    {
                                        C_Weather.FogOffsetX = 1;
                                    }
                                    if (C_Weather.FogOffsetY < -255)
                                    {
                                        C_Weather.FogOffsetY = 1;
                                    }
                                    fogtmr = tick + 255 - C_Weather.CurrentFogSpeed;
                                }
                            }

                            if (tmr500 < tick)
                            {
                                // animate waterfalls
                                switch (C_AutoTiles.WaterfallFrame)
                                {
                                    case 0:
                                        C_AutoTiles.WaterfallFrame = 1;
                                        break;
                                    case 1:
                                        C_AutoTiles.WaterfallFrame = 2;
                                        break;
                                    case 2:
                                        C_AutoTiles.WaterfallFrame = 0;
                                        break;
                                }
                                // animate autotiles
                                switch (C_AutoTiles.AutoTileFrame)
                                {
                                    case 0:
                                        C_AutoTiles.AutoTileFrame = 1;
                                        break;
                                    case 1:
                                        C_AutoTiles.AutoTileFrame = 2;
                                        break;
                                    case 2:
                                        C_AutoTiles.AutoTileFrame = 0;
                                        break;
                                }

                                tmr500 = tick + 500;
                            }

                            if (C_Sound.FadeInSwitch == true)
                            {
                                C_Sound.FadeIn();
                            }

                            if (C_Sound.FadeOutSwitch == true)
                            {
                                C_Sound.FadeOut();
                            }

                            if (C_Constants.InMapEditor)
                            {
                                FrmEditor_MapEditor.Default.EditorMap_DrawTileset();
                            }

                            //Do we need todo this?
                            //Application.DoEvents();

                            if (C_Variables.GettingMap)
                            {
                                Font font = new Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\" + C_Constants.FontName, C_Constants.FontSize);
                                g.DrawString(Strings.Get("gamegui", "maprecieve"), font, Brushes.DarkCyan, FrmGame.Default.picscreen.Width - 130, 5);
                            }

                        }
                    }

                    if (tmrweather < tick)
                    {
                        C_Weather.ProcessWeather();
                        tmrweather = tick + 50;
                    }

                    if (fadetmr < tick)
                    {
                        if (C_Variables.FadeType != 2)
                        {
                            if (C_Variables.FadeType == 1)
                            {
                                if (C_Variables.FadeAmount != 255)
                                {
                                    C_Variables.FadeAmount = C_Variables.FadeAmount + 5;
                                }
                            }
                            else if (C_Variables.FadeType == 0)
                            {
                                if (C_Variables.FadeAmount == 0)
                                {
                                    C_Variables.UseFade = false;
                                }
                                else
                                {
                                    C_Variables.FadeAmount = C_Variables.FadeAmount - 5;
                                }
                            }
                        }
                        fadetmr = tick + 30;
                    }

                    if (rendercount < tick || C_Types.Options.UnlockFPS == 1)
                    {
                        //Actual Game Loop Stuff :/
                        C_Variables.Fps = CalculateFrameRate();
                        C_Graphics.Render_Graphics();
                        rendercount = tick + 8;
                    }

                    if(appDoEventsTimer < C_General.GetTickCount())
                    {
                        Application.DoEvents();
                        appDoEventsTimer = C_General.GetTickCount() + 25;
                    }


                    DeltaTime();


                    Thread.Sleep(1); 
                    // Yield also works but Yield produces much more erratic performance, while Sleep produces a smooth stable performance
                    // Thats because Yield has to find a new open thread, this process can sometimes be instant or take a bit to process.
                    // While Thread.Sleep will always wait exactly the said time rather then it being slightly random.
                    // You could also play without a delay entirely, there isnt a major change besides a MINOR boost to performance
                    // But it will attempt to consume 100% of the cpu at all times, which may not be desired
                    // The delay gives the CPU a break
                    //Thread.Yield();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.StackTrace, "ERROR");
                }
				
			} while (true);
		}

		public static void ClearTempTile()
		{
			int x = 0;
			int y = 0;
			C_Maps.TempTile = new C_Types.TempTileRec[C_Maps.Map.MaxX + 1, C_Maps.Map.MaxY + 1];
			
			for (x = 0; x <= C_Maps.Map.MaxX; x++)
			{
				for (y = 0; y <= C_Maps.Map.MaxY; y++)
				{
					C_Maps.TempTile[x, y].DoorOpen = (byte) 0;
				}
			}
			
		}
		
		public static void ProcessNpcMovement(int mapNpcNum)
		{
			
			// Check if NPC is walking, and if so process moving them over
			if (C_Maps.MapNpc[mapNpcNum].Moving == (byte)Enums.MovementType.Walking)
			{
				
				if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Up)
				{
					C_Maps.MapNpc[mapNpcNum].YOffset = (C_Maps.MapNpc[mapNpcNum].YOffset - C_Constants.WalkSpeed);
					if (C_Maps.MapNpc[mapNpcNum].YOffset < 0)
					{
						C_Maps.MapNpc[mapNpcNum].YOffset = 0;
					}
				}
				else if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Down)
				{
					C_Maps.MapNpc[mapNpcNum].YOffset = (C_Maps.MapNpc[mapNpcNum].YOffset + C_Constants.WalkSpeed);
					if (C_Maps.MapNpc[mapNpcNum].YOffset > 0)
					{
						C_Maps.MapNpc[mapNpcNum].YOffset = 0;
					}
				}
				else if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Left)
				{
					C_Maps.MapNpc[mapNpcNum].XOffset = (C_Maps.MapNpc[mapNpcNum].XOffset - C_Constants.WalkSpeed);
					if (C_Maps.MapNpc[mapNpcNum].XOffset < 0)
					{
						C_Maps.MapNpc[mapNpcNum].XOffset = 0;
					}
				}
				else if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Right)
				{
					C_Maps.MapNpc[mapNpcNum].XOffset = (C_Maps.MapNpc[mapNpcNum].XOffset + C_Constants.WalkSpeed);
					if (C_Maps.MapNpc[mapNpcNum].XOffset > 0)
					{
						C_Maps.MapNpc[mapNpcNum].XOffset = 0;
					}
				}

                // 8 Directional Movement

				else if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.UpLeft)
				{
					C_Maps.MapNpc[mapNpcNum].YOffset = (C_Maps.MapNpc[mapNpcNum].YOffset - (int)(C_Constants.WalkSpeed / 1.2f));
					if (C_Maps.MapNpc[mapNpcNum].YOffset < 0) { C_Maps.MapNpc[mapNpcNum].YOffset = 0; }
					C_Maps.MapNpc[mapNpcNum].XOffset = (C_Maps.MapNpc[mapNpcNum].XOffset - (int)(C_Constants.WalkSpeed / 1.2f));
					if (C_Maps.MapNpc[mapNpcNum].XOffset < 0) { C_Maps.MapNpc[mapNpcNum].XOffset = 0; }
				}
				else if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.UpRight)
				{
					C_Maps.MapNpc[mapNpcNum].YOffset = (C_Maps.MapNpc[mapNpcNum].YOffset - (int)(C_Constants.WalkSpeed / 1.2f));
					if (C_Maps.MapNpc[mapNpcNum].YOffset < 0) { C_Maps.MapNpc[mapNpcNum].YOffset = 0; }
					C_Maps.MapNpc[mapNpcNum].XOffset = (C_Maps.MapNpc[mapNpcNum].XOffset + (int)(C_Constants.WalkSpeed / 1.2f));
					if (C_Maps.MapNpc[mapNpcNum].XOffset > 0) { C_Maps.MapNpc[mapNpcNum].XOffset = 0; }
				}
				else if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.DownLeft)
				{
					C_Maps.MapNpc[mapNpcNum].XOffset = (C_Maps.MapNpc[mapNpcNum].XOffset - (int)(C_Constants.WalkSpeed / 1.2f));
					if (C_Maps.MapNpc[mapNpcNum].XOffset < 0) { C_Maps.MapNpc[mapNpcNum].XOffset = 0; }
					C_Maps.MapNpc[mapNpcNum].YOffset = (C_Maps.MapNpc[mapNpcNum].YOffset + (int)(C_Constants.WalkSpeed / 1.2f));
					if (C_Maps.MapNpc[mapNpcNum].YOffset > 0) { C_Maps.MapNpc[mapNpcNum].YOffset = 0; }
				}
				else if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.DownRight)
                {
                    C_Maps.MapNpc[mapNpcNum].XOffset = (C_Maps.MapNpc[mapNpcNum].XOffset + (int)(C_Constants.WalkSpeed / 1.2f));
                    if (C_Maps.MapNpc[mapNpcNum].XOffset > 0) { C_Maps.MapNpc[mapNpcNum].XOffset = 0; }
                    C_Maps.MapNpc[mapNpcNum].YOffset = (C_Maps.MapNpc[mapNpcNum].YOffset + (int)(C_Constants.WalkSpeed / 1.2f));
                    if (C_Maps.MapNpc[mapNpcNum].YOffset > 0) { C_Maps.MapNpc[mapNpcNum].YOffset = 0; }
                }
				
				// Check if completed walking over to the next tile
				if (C_Maps.MapNpc[mapNpcNum].Moving > 0)
				{
					//if (C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Right || C_Maps.MapNpc[mapNpcNum].Dir == (byte)Enums.DirectionType.Down)
                    if (C_Maps.MapNpc[mapNpcNum].Dir == (int)Enums.DirectionType.Right || C_Maps.MapNpc[mapNpcNum].Dir == (int)Enums.DirectionType.Down || C_Maps.MapNpc[mapNpcNum].Dir == (int)Enums.DirectionType.DownLeft || C_Maps.MapNpc[mapNpcNum].Dir == (int)Enums.DirectionType.DownRight)
                    {
                            if ((C_Maps.MapNpc[mapNpcNum].XOffset >= 0) && (C_Maps.MapNpc[mapNpcNum].YOffset >= 0))
						{
							C_Maps.MapNpc[mapNpcNum].Moving = (byte) 0;
							if (C_Maps.MapNpc[mapNpcNum].Steps == 1)
							{
								C_Maps.MapNpc[mapNpcNum].Steps = 3;
							}
							else
							{
								C_Maps.MapNpc[mapNpcNum].Steps = 1;
							}
						}
					}
					else
					{
						if ((C_Maps.MapNpc[mapNpcNum].XOffset <= 0) && (C_Maps.MapNpc[mapNpcNum].YOffset <= 0))
						{
							C_Maps.MapNpc[mapNpcNum].Moving = (byte) 0;
							if (C_Maps.MapNpc[mapNpcNum].Steps == 1)
							{
								C_Maps.MapNpc[mapNpcNum].Steps = 3;
							}
							else
							{
								C_Maps.MapNpc[mapNpcNum].Steps = 1;
							}
						}
					}
				}
			}
		}
		
		public static void DrawPing()
		{
			
			C_Variables.PingToDraw = System.Convert.ToString(C_Variables.Ping);
			
			if (C_Variables.Ping == -1)
			{
				C_Variables.PingToDraw = Strings.Get("gamegui", "pingsync");
			}
			else if (C_Variables.Ping >= 0 && C_Variables.Ping <= 5)
			{
				C_Variables.PingToDraw = Strings.Get("gamegui", "pinglocal");
			}
			
		}
		
		internal static dynamic IsInBounds()
		{
			dynamic returnValue = default(dynamic);
			returnValue = false;
			
			if ((C_Variables.CurX >= 0) && (C_Variables.CurX <= C_Maps.Map.MaxX))
			{
				if ((C_Variables.CurY >= 0) && (C_Variables.CurY <= C_Maps.Map.MaxY))
				{
					return true;
				}
			}
			
			return returnValue;
		}
		
		public static bool GameStarted()
		{
			bool returnValue = false;
			returnValue = false;
			if (C_Variables.InGame == false)
			{
				return returnValue;
			}
			if (C_Variables.MapData == false)
			{
				return returnValue;
			}
			if (C_Variables.PlayerData == false)
			{
				return returnValue;
			}
			returnValue = true;
			C_UpdateUI.Pnlloadvisible = false;
			return returnValue;
		}
		
		internal static void CreateActionMsg(string message, int color, byte msgType, int x, int y)
		{
			
			C_Variables.ActionMsgIndex++;
			if (C_Variables.ActionMsgIndex >= byte.MaxValue)
			{
				C_Variables.ActionMsgIndex = (byte) 1;
			}
			
            C_Types.ActionMsg[C_Variables.ActionMsgIndex].Message = message;
			C_Types.ActionMsg[C_Variables.ActionMsgIndex].Color = color;
			C_Types.ActionMsg[C_Variables.ActionMsgIndex].Type = msgType;
			C_Types.ActionMsg[C_Variables.ActionMsgIndex].Created = C_General.GetTickCount();
			C_Types.ActionMsg[C_Variables.ActionMsgIndex].Scroll = 1;
			C_Types.ActionMsg[C_Variables.ActionMsgIndex].X = x;
			C_Types.ActionMsg[C_Variables.ActionMsgIndex].Y = y;
			
			if (C_Types.ActionMsg[C_Variables.ActionMsgIndex].Type == (int) Enums.ActionMsgType.Scroll)
			{
				C_Types.ActionMsg[C_Variables.ActionMsgIndex].Y = C_Types.ActionMsg[C_Variables.ActionMsgIndex].Y + Rand(-2, 6);
				C_Types.ActionMsg[C_Variables.ActionMsgIndex].X = C_Types.ActionMsg[C_Variables.ActionMsgIndex].X + Rand(-8, 8);
			}
			
		}
		
		internal static int Rand(int maxNumber, int minNumber = 0)
		{
			if (minNumber > maxNumber)
			{
				int t = minNumber;
				minNumber = maxNumber;
				maxNumber = t;
			}
			
			return GameRand.Next(minNumber, maxNumber);
		}

        // BitWise Operators for directional blocking
        internal static void SetDirBlock(ref byte blockvar, byte Dir, bool block)
        {
            checked
            {
                if (block)
                {
                    blockvar = (byte)(unchecked(blockvar) | (ulong)((long)Math.Round(Math.Pow(2.0, Dir))));
                }
                else
                {
                    blockvar = (byte)(unchecked(blockvar) & (~(ulong)((long)Math.Round(Math.Pow(2.0, Dir)))));
                }
            }
        }

        internal static bool IsDirBlocked(byte Blockvar, byte Dir)
        {
            return !(~Blockvar <= 0 || Math.Pow(2.0, (double)Dir) == 0.0);
        }

        internal static string ConvertCurrency(int amount)
		{
			string returnValue = "";
			
			if (amount < 10000)
			{
				returnValue = amount.ToString();
			}
			else if (amount < 999999)
			{
				returnValue = (amount / 1000) + "k";
			}
			else if (amount < 999999999)
			{
				return (amount / 1000000) + "m";
			}
			else
			{
				return (amount / 1000000000) + "b";
			}
			
			return returnValue;
		}
		
		public static void HandlePressEnter()
		{

            string chatText = "";
            chatText = ChatModule.ChatInput.CurrentMessage.Trim();

            if (chatText.Length == 0)
            {
                return;
            }

			string name = "";
			int i = 0;
			int n = 0;
			string[] command;
			ByteStream buffer = new ByteStream();
			name = "";
			
			ChatModule.ChatInput.CurrentMessage = chatText.ToLower();
			
			if (C_EventSystem.EventChat == true)
			{
				if (C_EventSystem.EventChatType == 0)
				{
					buffer = new ByteStream(4);
					buffer.WriteInt32((System.Int32) Packets.ClientPackets.CEventChatReply);
					buffer.WriteInt32(C_EventSystem.EventReplyId);
					buffer.WriteInt32(C_EventSystem.EventReplyPage);
					buffer.WriteInt32(0);
					C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
					buffer.Dispose();
					C_EventSystem.ClearEventChat();
					C_EventSystem.InEvent = false;
					return;
				}
			}
			
			// Broadcast message
			if (chatText.Substring(0, 1) == "'")
			{
				chatText = chatText.Substring(1, chatText.Length - 1);
				
				if (chatText.Length > 0)
				{
					C_NetworkSend.BroadcastMsg(chatText); //("Привет, русский чат")
				}
				
				ChatModule.ChatInput.CurrentMessage = "";
				return;
			}
			
			// party message
			if (chatText.Substring(0, 1) == "-")
			{
				ChatModule.ChatInput.CurrentMessage = chatText.Substring(1, chatText.Length - 1);
				
				if (chatText.Length > 0)
				{
					C_Parties.SendPartyChatMsg(ChatModule.ChatInput.CurrentMessage);
				}
				
				ChatModule.ChatInput.CurrentMessage = "";
				return;
			}
			
			// Player message
			if (chatText.Substring(0, 1) == "!")
			{
				chatText = chatText.Substring(1, chatText.Length - 1);
				name = "";
				
				// Get the desired player from the user text
				for (i = 1; i <= chatText.Length; i++)
				{
					
					if (chatText.Substring(i - 1, 1) != Microsoft.VisualBasic.Strings.Space(1))
					{
						name = name + chatText.Substring(i - 1, 1);
					}
					else
					{
						break;
					}
					
				}
				
				ChatModule.ChatInput.CurrentMessage = chatText.Substring(i - 1, chatText.Length - 1).Trim();
				
				// Make sure they are actually sending something
				if (ChatModule.ChatInput.CurrentMessage.Length > 0)
				{
					// Send the message to the player
					C_NetworkSend.PlayerMsg(ChatModule.ChatInput.CurrentMessage, name);
				}
				else
				{
					C_Text.AddText(Strings.Get("chatcommand", "playermsg"), (System.Int32) Enums.ColorType.Yellow);
				}
				
				ChatModule.ChatInput.CurrentMessage = "";
				return;
			}
			
			if (ChatModule.ChatInput.CurrentMessage.Substring(0, 1) == "/")
			{
				command = ChatModule.ChatInput.CurrentMessage.Split(Microsoft.VisualBasic.Strings.Space(1).ToCharArray()[0]);
				
				switch (command[0])
				{
					case "/emote":
						// Checks to make sure we have more than one string in the array
						if ((command.Length - 1) < 1)
						{
							C_Text.AddText(Strings.Get("chatcommand", "emote"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						if (!Information.IsNumeric(command[1]))
						{
							C_Text.AddText(Strings.Get("chatcommand", "emote"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						C_NetworkSend.SendUseEmote(System.Convert.ToInt32(command[1]));
						break;
						
					case "/help":
						C_Text.AddText(Strings.Get("chatcommand", "help1"), (System.Int32) Enums.ColorType.Yellow);
						C_Text.AddText(Strings.Get("chatcommand", "help2"), (System.Int32) Enums.ColorType.Yellow);
						C_Text.AddText(Strings.Get("chatcommand", "help3"), (System.Int32) Enums.ColorType.Yellow);
						C_Text.AddText(Strings.Get("chatcommand", "help4"), (System.Int32) Enums.ColorType.Yellow);
						C_Text.AddText(Strings.Get("chatcommand", "help5"), (System.Int32) Enums.ColorType.Yellow);
						break;
						
					case "/houseinvite":
						
						// Checks to make sure we have more than one string in the array
						if ((command.Length - 1) < 1)
						{
							C_Text.AddText(Strings.Get("chatcommand", "houseinvite"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						if (Information.IsNumeric(command[1]))
						{
							C_Text.AddText(Strings.Get("chatcommand", "houseinvite"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						C_Housing.SendInvite(command[1]);
						break;
						
					case "/sellhouse":
						buffer = new ByteStream(4);
						buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSellHouse);
						C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
						buffer.Dispose();
						break;
					case "/info":
						
						// Checks to make sure we have more than one string in the array
						if ((command.Length - 1) < 1)
						{
							C_Text.AddText(Strings.Get("chatcommand", "info"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						if (Information.IsNumeric(command[1]))
						{
							C_Text.AddText(Strings.Get("chatcommand", "info"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						buffer = new ByteStream(4);
						buffer.WriteInt32((System.Int32) Packets.ClientPackets.CPlayerInfoRequest);
						buffer.WriteString(command[1]);
						C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
						buffer.Dispose();
						break;
						// Whos Online
					case "/who":
						C_NetworkSend.SendWhosOnline();
						break;
						// Checking fps
					case "/fps":
						C_Variables.Bfps = !C_Variables.Bfps;
						break;
					case "/lps":
						C_Variables.Blps = !C_Variables.Blps;
						break;
						// Request stats
					case "/stats":
						buffer = new ByteStream(4);
						buffer.WriteInt32((System.Int32) Packets.ClientPackets.CGetStats);
						C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
						buffer.Dispose();
						break;
					case "/party":
						// Make sure they are actually sending something
						if ((command.Length - 1) < 1)
						{
							C_Text.AddText(Strings.Get("chatcommand", "party"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						if (Information.IsNumeric(command[1]))
						{
							C_Text.AddText(Strings.Get("chatcommand", "party"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						C_Parties.SendPartyRequest(command[1]);
						break;
						
						// Join party
					case "/join":
						C_Parties.SendAcceptParty();
						break;
						// Leave party
					case "/leave":
						C_Parties.SendLeaveParty();
						break;
						
						//release pet
					case "/releasepet":
						C_Pets.SendReleasePet();
						break;
						
						// // Monitor Admin Commands //
						
					case "/questreset":
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						if ((command.Length - 1) < 1)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "questreset"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						if (!Information.IsNumeric(command[1]))
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "questreset"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						n = System.Convert.ToInt32(command[1]);
						
						// Check to make sure its a valid map #
						if (n > 0 && n <= C_Quest.MaxQuests)
						{
							C_Quest.QuestReset(n);
						}
						else
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "wrongquestnr"), (System.Int32) Enums.QColorType.AlertColor);
						}
						break;
						
						// Admin Help
					case "/admin":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Monitor)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						C_Text.AddText(Strings.Get("adminchatcommand", "admin1"), (System.Int32) Enums.ColorType.Yellow);
						C_Text.AddText(Strings.Get("adminchatcommand", "adminglobal"), (System.Int32) Enums.ColorType.Yellow);
						C_Text.AddText(Strings.Get("adminchatcommand", "adminprivate"), (System.Int32) Enums.ColorType.Yellow);
						C_Text.AddText(Strings.Get("adminchatcommand", "admin2"), (System.Int32) Enums.ColorType.Yellow);
						break;
						// Kicking a player
					case "/kick":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Monitor)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						if ((command.Length - 1) < 1)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "kick"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						if (Information.IsNumeric(command[1]))
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "kick"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						C_NetworkSend.SendKick(command[1]);
						break;
						// // Mapper Admin Commands //
						// Location
					case "/loc":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						C_Variables.BLoc = !C_Variables.BLoc;
						break;
						// Map Editor
					case "/mapeditor":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						C_Maps.SendRequestEditMap();
						break;
						// Warping to a player
					case "/warpmeto":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						if ((command.Length - 1) < 1)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "warpmeto"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						if (Information.IsNumeric(command[1]))
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "warpmeto"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						C_NetworkSend.WarpMeTo(command[1]);
						break;
						// Warping a player to you
					case "/warptome":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						if ((command.Length - 1) < 1)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "warptome"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						if (Information.IsNumeric(command[1]))
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "warptome"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						C_NetworkSend.WarpToMe(command[1]);
						break;
						// Warping to a map
					case "/warpto":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						if ((command.Length - 1) < 1)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "warpto"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						if (!Information.IsNumeric(command[1]))
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "warpto"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						n = System.Convert.ToInt32(command[1]);
						
						// Check to make sure its a valid map #
						if (n > 0 && n <= Constants.MAX_MAPS)
						{
							C_NetworkSend.WarpTo(n);
						}
						else
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "wrongmapnr"), (System.Int32) Enums.QColorType.AlertColor);
						}
						break;
						
						// Setting sprite
					case "/setsprite":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						if ((command.Length - 1) < 1)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "setsprite"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						if (!Information.IsNumeric(command[1]))
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "setsprite"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						C_NetworkSend.SendSetSprite(System.Convert.ToInt32(command[1]));
						break;
						// Map report
					case "/mapreport":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						C_NetworkSend.SendRequestMapreport();
						break;
						// Respawn request
					case "/respawn":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						C_Maps.SendMapRespawn();
						break;
						// MOTD change
					case "/motd":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						if ((command.Length - 1) < 1)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "motd"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						C_NetworkSend.SendMotdChange(chatText.Substring(chatText.Length - (chatText.Length - 5), chatText.Length - 5));
						break;
						// Check the ban list
					case "/banlist":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						C_NetworkSend.SendBanList();
						break;
						// Banning a player
					case "/ban":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						if ((command.Length - 1) < 1)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "ban"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						C_NetworkSend.SendBan(command[1]);
						break;
						// // Developer Admin Commands //
						
						// // Creator Admin Commands //
						// Giving another player access
					case "/setaccess":
						
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Creator)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "accesswarning"), (System.Int32) Enums.QColorType.AlertColor);
							goto Continue1;
						}
						
						if ((command.Length - 1) < 2)
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "setaccess"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						if (Information.IsNumeric(command[1]) || !Information.IsNumeric(command[2]))
						{
							C_Text.AddText(Strings.Get("adminchatcommand", "setaccess"), (System.Int32) Enums.ColorType.Yellow);
							goto Continue1;
						}
						
						C_NetworkSend.SendSetAccess(command[1], byte.Parse(command[2]));
						break;
					default:
						C_Text.AddText(Strings.Get("chatcommand", "wrongcmd"), (System.Int32) Enums.QColorType.AlertColor);
						break;
				}
				
				//continue label where we go instead of exiting the sub
Continue1:
				ChatModule.ChatInput.CurrentMessage = "";
				return;
			}
			
			// Say message
			if (chatText.Length > 0)
			{
				C_NetworkSend.SayMsg(chatText);
			}
			
			ChatModule.ChatInput.CurrentMessage = "";
		}
		
		public static void CheckMapGetItem()
		{
			ByteStream buffer = new ByteStream(4);
			buffer = new ByteStream(4);
			
			if (C_General.GetTickCount() > C_Types.Player[C_Variables.Myindex].MapGetTimer + 250)
			{
				if (ChatModule.ChatInput.CurrentMessage.Trim() == "")
				{
					C_Types.Player[C_Variables.Myindex].MapGetTimer = C_General.GetTickCount();
					buffer.WriteInt32((System.Int32) Packets.ClientPackets.CMapGetItem);
					C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
				}
			}
			
			buffer.Dispose();
		}
		
		internal static void UpdateDescWindow(int itemnum, int amount, int invNum, byte windowType)
		{
			string theName = "";
			int tmpRarity = 0;
			
			if (Types.Item[itemnum].Randomize != 0 && invNum != 0)
			{
				if (windowType == 0) // inventory
				{
					theName = Microsoft.VisualBasic.Strings.Trim(C_Types.Player[C_Variables.Myindex].RandInv[invNum].Prefix) + " " + Microsoft.VisualBasic.Strings.Trim(Types.Item[itemnum].Name) + " " + Microsoft.VisualBasic.Strings.Trim(C_Types.Player[C_Variables.Myindex].RandInv[invNum].Suffix);
					tmpRarity = C_Types.Player[C_Variables.Myindex].RandInv[invNum].Rarity;
				}
				else if (windowType == 1) // equip
				{
					theName = Microsoft.VisualBasic.Strings.Trim(C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Prefix) + " " + Microsoft.VisualBasic.Strings.Trim(Types.Item[itemnum].Name) + " " + Microsoft.VisualBasic.Strings.Trim(C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Suffix);
					tmpRarity = C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Rarity;
				}
				else if (windowType == 2) // bank
				{
					theName = Microsoft.VisualBasic.Strings.Trim(C_Banks.Bank.ItemRand[invNum].Prefix) + " " + Microsoft.VisualBasic.Strings.Trim(Types.Item[itemnum].Name) + " " + Microsoft.VisualBasic.Strings.Trim(C_Banks.Bank.ItemRand[invNum].Suffix);
					tmpRarity = C_Banks.Bank.ItemRand[invNum].Rarity;
				}
				else if (windowType == 3) // shop
				{
					theName = Microsoft.VisualBasic.Strings.Trim(C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Prefix) + " " + Microsoft.VisualBasic.Strings.Trim(Types.Item[itemnum].Name) + " " + Microsoft.VisualBasic.Strings.Trim(C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Suffix);
					tmpRarity = C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Rarity;
				}
				else if (windowType == 4) // trade
				{
					theName = Microsoft.VisualBasic.Strings.Trim(C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Prefix) + " " + Microsoft.VisualBasic.Strings.Trim(Types.Item[itemnum].Name) + " " + Microsoft.VisualBasic.Strings.Trim(C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Suffix);
					tmpRarity = C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Rarity;
				}
			}
			else
			{
				theName = Microsoft.VisualBasic.Strings.Trim(Types.Item[itemnum].Name);
				tmpRarity = Types.Item[itemnum].Rarity;
			}
			
			C_UpdateUI.ItemDescName = theName;
			
			C_UpdateUI.ItemDescItemNum = itemnum;
			
			if (C_Items.LastItemDesc == itemnum)
			{
				return;
			}
			
			// set the name
			switch (tmpRarity)
			{
				case 0: // White
					C_UpdateUI.ItemDescRarityColor = C_Constants.ItemRarityColor0;
					C_UpdateUI.ItemDescRarityBackColor = SFML.Graphics.Color.Black;
					break;
				case 1: // green
					C_UpdateUI.ItemDescRarityColor = (SFML.Graphics.Color)C_Constants.ItemRarityColor1;
					C_UpdateUI.ItemDescRarityBackColor = SFML.Graphics.Color.Black;
					break;
				case 2: // blue
					C_UpdateUI.ItemDescRarityColor = (SFML.Graphics.Color)C_Constants.ItemRarityColor2;
					C_UpdateUI.ItemDescRarityBackColor = SFML.Graphics.Color.Black;
					break;
				case 3: // red
					C_UpdateUI.ItemDescRarityColor = (SFML.Graphics.Color)C_Constants.ItemRarityColor3;
					C_UpdateUI.ItemDescRarityBackColor = SFML.Graphics.Color.Black;
					break;
				case 4: // purple
					C_UpdateUI.ItemDescRarityColor = (SFML.Graphics.Color)C_Constants.ItemRarityColor4;
					C_UpdateUI.ItemDescRarityBackColor = SFML.Graphics.Color.Black;
					break;
				case 5: //gold
					C_UpdateUI.ItemDescRarityColor = (SFML.Graphics.Color)C_Constants.ItemRarityColor5;
					C_UpdateUI.ItemDescRarityBackColor = SFML.Graphics.Color.Black;
					break;
			}
			
			C_UpdateUI.ItemDescDescription = Types.Item[itemnum].Description;
			
			// For the stats label
			if (Types.Item[itemnum].Type == (byte)Enums.ItemType.None)
			{
				C_UpdateUI.ItemDescInfo = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescType = Strings.Get("itemdescription", "notavail");
			}
			else if (Types.Item[itemnum].Type == (byte)Enums.ItemType.Equipment)
			{
				if (Types.Item[itemnum].SubType == (byte)Enums.EquipmentType.Weapon)
				{
					if (Types.Item[itemnum].Randomize != 0)
					{
						if (windowType == 0)
						{
							C_UpdateUI.ItemDescInfo = "Damage: " + System.Convert.ToString(C_Types.Player[C_Variables.Myindex].RandInv[invNum].Damage);
						}
						else
						{
							C_UpdateUI.ItemDescInfo = "Damage: " + System.Convert.ToString(C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Damage);
						}
					}
					else
					{
						C_UpdateUI.ItemDescInfo = "Damage: " + System.Convert.ToString(Types.Item[itemnum].Data2);
					}
					C_UpdateUI.ItemDescType = "Weapon";
				}
				else if (Types.Item[itemnum].SubType == (byte)Enums.EquipmentType.Armor)
				{
					C_UpdateUI.ItemDescInfo = "Defence: " + System.Convert.ToString(Types.Item[itemnum].Data2);
					C_UpdateUI.ItemDescType = "Armor";
				}
				else if (Types.Item[itemnum].SubType == (byte)Enums.EquipmentType.Helmet)
				{
					C_UpdateUI.ItemDescInfo = "Defence: " + System.Convert.ToString(Types.Item[itemnum].Data2);
					C_UpdateUI.ItemDescType = "Helmet";
				}
				else if (Types.Item[itemnum].SubType == (byte)Enums.EquipmentType.Shield)
				{
					C_UpdateUI.ItemDescInfo = "Defence: " + System.Convert.ToString(Types.Item[itemnum].Data2);
					C_UpdateUI.ItemDescType = "Shield";
				}
				else if (Types.Item[itemnum].SubType == (byte)Enums.EquipmentType.Shoes)
				{
					C_UpdateUI.ItemDescInfo = "Defence: " + System.Convert.ToString(Types.Item[itemnum].Data2);
					C_UpdateUI.ItemDescType = "Shoes";
				}
				else if (Types.Item[itemnum].SubType == (byte)Enums.EquipmentType.Gloves)
				{
					C_UpdateUI.ItemDescInfo = "Defence: " + System.Convert.ToString(Types.Item[itemnum].Data2);
					C_UpdateUI.ItemDescType = "Gloves";
				}
			}
			else if (Types.Item[itemnum].Type == (byte)Enums.ItemType.Consumable)
			{
				if (Types.Item[itemnum].SubType == (byte)Enums.ConsumableType.Hp)
				{
					C_UpdateUI.ItemDescInfo = Strings.Get("itemdescription", "restore") + System.Convert.ToString(Types.Item[itemnum].Data2);
					C_UpdateUI.ItemDescType = Strings.Get("itemdescription", "potion");
				}
				else if (Types.Item[itemnum].SubType == (byte)Enums.ConsumableType.Mp)
				{
					C_UpdateUI.ItemDescInfo = Strings.Get("itemdescription", "restore") + System.Convert.ToString(Types.Item[itemnum].Data2);
					C_UpdateUI.ItemDescType = Strings.Get("itemdescription", "potion");
				}
				else if (Types.Item[itemnum].SubType == (byte)Enums.ConsumableType.Sp)
				{
					C_UpdateUI.ItemDescInfo = Strings.Get("itemdescription", "restore") + System.Convert.ToString(Types.Item[itemnum].Data2);
					C_UpdateUI.ItemDescType = Strings.Get("itemdescription", "potion");
				}
				else if (Types.Item[itemnum].SubType == (byte)Enums.ConsumableType.Exp)
				{
					C_UpdateUI.ItemDescInfo = Strings.Get("itemdescription", "amount") + System.Convert.ToString(Types.Item[itemnum].Data2);
					C_UpdateUI.ItemDescType = Strings.Get("itemdescription", "potion");
				}
			}
			else if (Types.Item[itemnum].Type == (byte)Enums.ItemType.Key)
			{
				C_UpdateUI.ItemDescInfo = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescType = Strings.Get("itemdescription", "key");
			}
			else if (Types.Item[itemnum].Type == (byte)Enums.ItemType.Currency)
			{
				C_UpdateUI.ItemDescInfo = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescType = Strings.Get("itemdescription", "currency");
			}
			else if (Types.Item[itemnum].Type == (byte)Enums.ItemType.Skill)
			{
				C_UpdateUI.ItemDescInfo = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescType = Strings.Get("itemdescription", "skill");
			}
			else if (Types.Item[itemnum].Type == (byte)Enums.ItemType.Furniture)
			{
				C_UpdateUI.ItemDescInfo = Strings.Get("itemdescription", "furniture");
			}
			
			// Currency
			C_UpdateUI.ItemDescCost = Types.Item[itemnum].Price + "g";
			
			// If currency, exit out before all the other shit
			if (Types.Item[itemnum].Type == (byte)Enums.ItemType.Currency || Types.Item[itemnum].Type == (byte)Enums.ItemType.None)
			{
				// Clear other labels
				C_UpdateUI.ItemDescLevel = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescSpeed = Strings.Get("itemdescription", "notavail");
				
				C_UpdateUI.ItemDescStr = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescEnd = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescInt = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescSpr = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescVit = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescLuck = Strings.Get("itemdescription", "notavail");
				return;
			}
			
			// Potions + crap
			C_UpdateUI.ItemDescLevel = System.Convert.ToString(Types.Item[itemnum].LevelReq);
			
			// Exit out for everything else 'scept equipment
			if (Types.Item[itemnum].Type != (int) Enums.ItemType.Equipment)
			{
				// Clear other labels
				C_UpdateUI.ItemDescSpeed = Strings.Get("itemdescription", "notavail");
				
				C_UpdateUI.ItemDescStr = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescEnd = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescInt = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescSpr = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescVit = Strings.Get("itemdescription", "notavail");
				C_UpdateUI.ItemDescLuck = Strings.Get("itemdescription", "notavail");
				return;
			}
			
			// Equipment specific
			if (Types.Item[itemnum].Randomize != 0)
			{
				if (windowType == 0)
				{
					if (C_Types.Player[C_Variables.Myindex].RandInv[invNum].Stat[(byte)Enums.StatType.Strength] > 0)
					{
						C_UpdateUI.ItemDescStr = "+" + C_Types.Player[C_Variables.Myindex].RandInv[invNum].Stat[(byte)Enums.StatType.Strength];
					}
					else
					{
						C_UpdateUI.ItemDescStr = Strings.Get("itemdescription", "none");
					}
				}
				else
				{
					if (C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Stat[(byte)Enums.StatType.Strength] > 0)
					{
						C_UpdateUI.ItemDescStr = "+" + C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Stat[(byte)Enums.StatType.Strength];
					}
					else
					{
						C_UpdateUI.ItemDescStr = Strings.Get("itemdescription", "none");
					}
				}
			}
			else
			{
				if (Types.Item[itemnum].Add_Stat[(byte)Enums.StatType.Strength] > 0)
				{
					C_UpdateUI.ItemDescStr = "+" + Types.Item[itemnum].Add_Stat[(byte)Enums.StatType.Strength];
				}
				else
				{
					C_UpdateUI.ItemDescStr = Strings.Get("itemdescription", "none");
				}
			}
			
			if (Types.Item[itemnum].Randomize != 0)
			{
				if (windowType == 0)
				{
					if (C_Types.Player[C_Variables.Myindex].RandInv[invNum].Stat[(byte)Enums.StatType.Vitality] > 0)
					{
						C_UpdateUI.ItemDescVit = "+" + C_Types.Player[C_Variables.Myindex].RandInv[invNum].Stat[(byte)Enums.StatType.Vitality];
					}
					else
					{
						C_UpdateUI.ItemDescVit = Strings.Get("itemdescription", "none");
					}
				}
				else
				{
					if (C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Stat[(byte)Enums.StatType.Vitality] > 0)
					{
						C_UpdateUI.ItemDescVit = "+" + C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Stat[(byte)Enums.StatType.Vitality];
					}
					else
					{
						C_UpdateUI.ItemDescVit = Strings.Get("itemdescription", "none");
					}
				}
			}
			else
			{
				if (Types.Item[itemnum].Add_Stat[(byte)Enums.StatType.Vitality] > 0)
				{
					C_UpdateUI.ItemDescVit = "+" + Types.Item[itemnum].Add_Stat[(byte)Enums.StatType.Vitality];
				}
				else
				{
					C_UpdateUI.ItemDescVit = Strings.Get("itemdescription", "none");
				}
			}
			
			if (Types.Item[itemnum].Randomize != 0)
			{
				if (windowType == 0)
				{
					if (C_Types.Player[C_Variables.Myindex].RandInv[invNum].Stat[(byte)Enums.StatType.Intelligence] > 0)
					{
						C_UpdateUI.ItemDescInt = "+" + C_Types.Player[C_Variables.Myindex].RandInv[invNum].Stat[(byte)Enums.StatType.Intelligence];
					}
					else
					{
						C_UpdateUI.ItemDescInt = Strings.Get("itemdescription", "none");
					}
				}
				else
				{
					if (C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Stat[(byte)Enums.StatType.Intelligence] > 0)
					{
						C_UpdateUI.ItemDescInt = "+" + C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Stat[(byte)Enums.StatType.Intelligence];
					}
					else
					{
						C_UpdateUI.ItemDescInt = Strings.Get("itemdescription", "none");
					}
				}
			}
			else
			{
				if (Types.Item[itemnum].Add_Stat[(byte)Enums.StatType.Intelligence] > 0)
				{
					C_UpdateUI.ItemDescInt = "+" + Types.Item[itemnum].Add_Stat[(byte)Enums.StatType.Intelligence];
				}
				else
				{
					C_UpdateUI.ItemDescInt = Strings.Get("itemdescription", "none");
				}
			}
			
			if (Types.Item[itemnum].Randomize != 0)
			{
				if (windowType == 0)
				{
					if (C_Types.Player[C_Variables.Myindex].RandInv[invNum].Stat[(byte)Enums.StatType.Endurance] > 0)
					{
						C_UpdateUI.ItemDescEnd = "+" + C_Types.Player[C_Variables.Myindex].RandInv[invNum].Stat[(byte)Enums.StatType.Endurance];
					}
					else
					{
						C_UpdateUI.ItemDescEnd = Strings.Get("itemdescription", "none");
					}
				}
				else
				{
					if (C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Stat[(byte)Enums.StatType.Endurance] > 0)
					{
						C_UpdateUI.ItemDescEnd = "+" + C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Stat[(byte)Enums.StatType.Endurance];
					}
					else
					{
						C_UpdateUI.ItemDescEnd = Strings.Get("itemdescription", "none");
					}
				}
			}
			else
			{
				if (Types.Item[itemnum].Add_Stat[(byte)Enums.StatType.Endurance] > 0)
				{
					C_UpdateUI.ItemDescEnd = "+" + Types.Item[itemnum].Add_Stat[(byte)Enums.StatType.Endurance];
				}
				else
				{
					C_UpdateUI.ItemDescEnd = Strings.Get("itemdescription", "none");
				}
			}
			
			if (Types.Item[itemnum].Randomize != 0)
			{
				if (windowType == 0)
				{
					if (C_Types.Player[C_Variables.Myindex].RandInv[invNum].Stat[(byte)Enums.StatType.Luck] > 0)
					{
						C_UpdateUI.ItemDescLuck = "+" + C_Types.Player[C_Variables.Myindex].RandInv[invNum].Stat[(byte)Enums.StatType.Luck];
					}
					else
					{
						C_UpdateUI.ItemDescLuck = Strings.Get("itemdescription", "none");
					}
				}
				else
				{
					if (C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Stat[(byte)Enums.StatType.Luck] > 0)
					{
						C_UpdateUI.ItemDescLuck = "+" + C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Stat[(byte)Enums.StatType.Luck];
					}
					else
					{
						C_UpdateUI.ItemDescLuck = Strings.Get("itemdescription", "none");
					}
				}
			}
			else
			{
				if (Types.Item[itemnum].Add_Stat[(byte)Enums.StatType.Luck] > 0)
				{
					C_UpdateUI.ItemDescLuck = "+" + Types.Item[itemnum].Add_Stat[(byte)Enums.StatType.Luck];
				}
				else
				{
					C_UpdateUI.ItemDescLuck = Strings.Get("itemdescription", "none");
				}
			}
			
			if (Types.Item[itemnum].Randomize != 0)
			{
				if (windowType == 0)
				{
					if (C_Types.Player[C_Variables.Myindex].RandInv[invNum].Stat[(byte)Enums.StatType.Spirit] > 0)
					{
						C_UpdateUI.ItemDescSpr = "+" + C_Types.Player[C_Variables.Myindex].RandInv[invNum].Stat[(byte)Enums.StatType.Spirit];
					}
					else
					{
						C_UpdateUI.ItemDescSpr = Strings.Get("itemdescription", "none");
					}
				}
				else
				{
					if (C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Stat[(byte)Enums.StatType.Spirit] > 0)
					{
						C_UpdateUI.ItemDescSpr = "+" + C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Stat[(byte)Enums.StatType.Spirit];
					}
					else
					{
						C_UpdateUI.ItemDescSpr = Strings.Get("itemdescription", "none");
					}
				}
			}
			else
			{
				if (Types.Item[itemnum].Add_Stat[(byte)Enums.StatType.Spirit] > 0)
				{
					C_UpdateUI.ItemDescSpr = "+" + Types.Item[itemnum].Add_Stat[(byte)Enums.StatType.Spirit];
				}
				else
				{
					C_UpdateUI.ItemDescSpr = Strings.Get("itemdescription", "none");
				}
			}
			
			if (Types.Item[itemnum].Randomize != 0)
			{
				if (windowType == 0)
				{
					if (Types.Item[itemnum].SubType == (byte)Enums.EquipmentType.Weapon)
					{
						C_UpdateUI.ItemDescSpeed = (double) C_Types.Player[C_Variables.Myindex].RandInv[invNum].Speed / 1000 + Strings.Get("itemdescription", "secs");
					}
					else
					{
						C_UpdateUI.ItemDescSpeed = Strings.Get("itemdescription", "notavail");
					}
				}
				else
				{
					if (Types.Item[itemnum].SubType == (byte)Enums.EquipmentType.Weapon)
					{
						C_UpdateUI.ItemDescSpeed = (double) C_Types.Player[C_Variables.Myindex].RandEquip[invNum].Speed / 1000 + Strings.Get("itemdescription", "secs");
					}
					else
					{
						C_UpdateUI.ItemDescSpeed = Strings.Get("itemdescription", "notavail");
					}
				}
			}
			else
			{
				if (Types.Item[itemnum].SubType == (byte)Enums.EquipmentType.Weapon)
				{
					C_UpdateUI.ItemDescSpeed = (double) Types.Item[itemnum].Speed / 1000 + Strings.Get("itemdescription", "secs");
				}
				else
				{
					C_UpdateUI.ItemDescSpeed = Strings.Get("itemdescription", "notavail");
				}
			}
			
		}
		
		internal static void OpenShop(int shopnum)
		{
			C_Shops.InShop = shopnum;
			C_Shops.ShopAction = (byte) 0;
		}
		
		internal static int GetBankItemNum(byte bankslot)
		{
			if (bankslot == 0)
			{
				return 0;
				
			}
			
			if (bankslot > Constants.MAX_BANK)
			{
				return 0;
				
			}
			
			return C_Banks.Bank.Item[bankslot].Num;
		}
		
		internal static void SetBankItemNum(byte bankslot, int itemnum)
		{
			C_Banks.Bank.Item[bankslot].Num = itemnum;
		}
		
		internal static int GetBankItemValue(byte bankslot)
		{
			return C_Banks.Bank.Item[bankslot].Value;
		}
		
		internal static void SetBankItemValue(byte bankslot, int itemValue)
		{
			C_Banks.Bank.Item[bankslot].Value = itemValue;
		}
		
		internal static void ClearActionMsg(byte index)
		{
			C_Types.ActionMsg[index].Message = "";
			C_Types.ActionMsg[index].Created = 0;
			C_Types.ActionMsg[index].Type = 0;
			C_Types.ActionMsg[index].Color = 0;
			C_Types.ActionMsg[index].Scroll = 0;
			C_Types.ActionMsg[index].X = 0;
			C_Types.ActionMsg[index].Y = 0;
		}
		
		internal static void UpdateSkillWindow(int skillnum)
		{
			
			if (C_Variables.LastSkillDesc == skillnum)
			{
				return;
			}
			
			C_UpdateUI.SkillDescName = Types.Skill[skillnum].Name;
			
			if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.DamageHp)
			{
				C_UpdateUI.SkillDescType = Strings.Get("skilldescription", "damagehp");
				C_UpdateUI.SkillDescVital = Strings.Get("skilldescription", "damage");
			}
			else if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.DamageMp)
			{
				C_UpdateUI.SkillDescType = Strings.Get("skilldescription", "damagemp");
				C_UpdateUI.SkillDescVital = Strings.Get("skilldescription", "damage");
			}
			else if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.HealHp)
			{
				C_UpdateUI.SkillDescType = Strings.Get("skilldescription", "healhp");
				C_UpdateUI.SkillDescVital = Strings.Get("skilldescription", "heal");
			}
			else if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.HealMp)
			{
				C_UpdateUI.SkillDescType = Strings.Get("skilldescription", "healmp");
				C_UpdateUI.SkillDescVital = Strings.Get("skilldescription", "heal");
			}
			else if (Types.Skill[skillnum].Type == (byte)Enums.SkillType.Warp)
			{
				C_UpdateUI.SkillDescType = Strings.Get("skilldescription", "warp");
			}
			
			C_UpdateUI.SkillDescReqMp = System.Convert.ToString(Types.Skill[skillnum].MpCost);
			C_UpdateUI.SkillDescReqLvl = System.Convert.ToString(Types.Skill[skillnum].LevelReq);
			C_UpdateUI.SkillDescReqAccess = System.Convert.ToString(Types.Skill[skillnum].AccessReq);
			
			if (Types.Skill[skillnum].ClassReq > 0)
			{
				C_UpdateUI.SkillDescReqClass = Microsoft.VisualBasic.Strings.Trim(Types.Classes[Types.Skill[skillnum].ClassReq].Name);
			}
			else
			{
				C_UpdateUI.SkillDescReqClass = Strings.Get("skilldescription", "none");
			}
			
			C_UpdateUI.SkillDescCastTime = Types.Skill[skillnum].CastTime + "s";
			C_UpdateUI.SkillDescCoolDown = Types.Skill[skillnum].CdTime + "s";
			C_UpdateUI.SkillDescDamage = System.Convert.ToString(Types.Skill[skillnum].Vital);
			
			if (Types.Skill[skillnum].IsAoE)
			{
				C_UpdateUI.SkillDescAoe = Types.Skill[skillnum].AoE + Strings.Get("skilldescription", "tiles");
			}
			else
			{
				C_UpdateUI.SkillDescAoe = Strings.Get("skilldescription", "no");
			}
			
			if (Types.Skill[skillnum].Range > 0)
			{
				C_UpdateUI.SkillDescRange = Types.Skill[skillnum].Range + Strings.Get("skilldescription", "tiles");
			}
			else
			{
				C_UpdateUI.SkillDescRange = Strings.Get("skilldescription", "selfcast");
			}
			
		}
		
		internal static void CheckAnimInstance(int index)
		{
			// if doesn't exist then exit sub
			if (C_Types.AnimInstance[index].Animation <= 0)
			{
				return;
			}
			if (C_Types.AnimInstance[index].Animation >= Constants.MAX_ANIMATIONS)
			{
				return;
			}

            int looptime = 0;
            int layer = 0;
            string sound = "";
            int frameCount = 0;

            sound = Types.Animation[C_Types.AnimInstance[index].Animation].Sound;
			
			for (layer = 0; layer <= 1; layer++)
			{
				if (C_Types.AnimInstance[index].Used[layer])
				{
					looptime = (Types.Animation[C_Types.AnimInstance[index].Animation].LoopTime[layer]);
					frameCount = (Types.Animation[C_Types.AnimInstance[index].Animation].Frames[layer]);
					
					// if zero'd then set so we don't have extra loop and/or frame
					if (C_Types.AnimInstance[index].FrameIndex[layer] == 0)
					{
						C_Types.AnimInstance[index].FrameIndex[layer] = 1;
					}
					if (C_Types.AnimInstance[index].LoopIndex[layer] == 0)
					{
						C_Types.AnimInstance[index].LoopIndex[layer] = 1;
					}
					
					// check if frame timer is set, and needs to have a frame change
					if (C_Types.AnimInstance[index].Timer[layer] + looptime <= C_General.GetTickCount())
					{
						// check if out of range
						if (C_Types.AnimInstance[index].FrameIndex[layer] >= frameCount)
						{
							C_Types.AnimInstance[index].LoopIndex[layer] = C_Types.AnimInstance[index].LoopIndex[layer] + 1;
							if (C_Types.AnimInstance[index].LoopIndex[layer] > Types.Animation[C_Types.AnimInstance[index].Animation].LoopCount[layer])
							{
								C_Types.AnimInstance[index].Used[layer] = false;
							}
							else
							{
								C_Types.AnimInstance[index].FrameIndex[layer] = 1;
							}
						}
						else
						{
							C_Types.AnimInstance[index].FrameIndex[layer] = C_Types.AnimInstance[index].FrameIndex[layer] + 1;
						}
						C_Types.AnimInstance[index].Timer[layer] = C_General.GetTickCount();
					}
				}
			}
			
			// if neither layer is used, clear
			if (C_Types.AnimInstance[index].Used[0] == false && C_Types.AnimInstance[index].Used[1] == false)
			{
				C_DataBase.ClearAnimInstance(index);
			}
			else
			{
				if (!string.IsNullOrEmpty(sound))
				{
					C_Sound.PlaySound(sound);
				}
			}
		}
		
		internal static void UpdateDrawMapName()
		{
			Graphics g = Graphics.FromImage(new Bitmap(1, 1));
			//Dim width As Integer
			//width = g.MeasureString(Trim$(Map.Name), New Font(FONT_NAME, FONT_SIZE, FontStyle.Bold, GraphicsUnit.Pixel)).Width
			//DrawMapNameX = ((SCREEN_MAPX + 1) * PicX / 2) - width + 32
			//DrawMapNameY = 1
			
			if (C_Maps.Map.Moral == (byte)Enums.MapMoralType.None)
			{
				C_Variables.DrawMapNameColor = SFML.Graphics.Color.Red;
			}
			else if (C_Maps.Map.Moral == (byte)Enums.MapMoralType.Safe)
			{
				C_Variables.DrawMapNameColor = SFML.Graphics.Color.Green;
			}
			else
			{
				C_Variables.DrawMapNameColor = SFML.Graphics.Color.White;
			}
			g.Dispose();
		}
		
		internal static void AddChatBubble(int target, byte targetType, string msg, int colour)
		{
			int i = 0;
			int index = 0;
			
			// set the global index
			
			C_Variables.ChatBubbleindex++;
			if (C_Variables.ChatBubbleindex < 1 || C_Variables.ChatBubbleindex > byte.MaxValue)
			{
				C_Variables.ChatBubbleindex = 1;
			}
			// default to new bubble
			index = C_Variables.ChatBubbleindex;
			// loop through and see if that player/npc already has a chat bubble
			for (i = 1; i <= byte.MaxValue; i++)
			{
				if (C_Variables.ChatBubble[i].TargetType == targetType)
				{
					if (C_Variables.ChatBubble[i].Target == target)
					{
						// reset master index
						if (C_Variables.ChatBubbleindex > 1)
						{
							C_Variables.ChatBubbleindex--;
						}
						// we use this one now, yes
						index = i;
						break;
					}
				}
			}
			// set the bubble up
			ref var with_1 = ref C_Variables.ChatBubble[index];
			with_1.Target = target;
			with_1.TargetType = targetType;
			with_1.Msg = msg;
			with_1.Colour = colour;
			with_1.Timer = C_General.GetTickCount();
			with_1.Active = true;
			
		}
		
	}
}
