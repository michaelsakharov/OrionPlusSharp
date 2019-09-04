
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
using Engine;


namespace Engine
{
	sealed class E_Editors
	{
		
#region Animation Editor
		
		internal static void AnimationEditorInit()
		{
			
			if (FrmAnimation.Default.Visible == false)
			{
				return;
			}
			
			E_Globals.Editorindex = FrmAnimation.Default.lstIndex.SelectedIndex + 1;
			
			// find the music we have set
			FrmAnimation.Default.cmbSound.Items.Clear();
			FrmAnimation.Default.cmbSound.Items.Add("None");
			
			if ((E_Sound.SoundCache.Length - 1) > 0)
			{
				for (var i = 1; i <= (E_Sound.SoundCache.Length - 1); i++)
				{
					FrmAnimation.Default.cmbSound.Items.Add(E_Sound.SoundCache[(int) i]);
				}
			}
			if(Types.Animation[E_Globals.Editorindex].Sound == null)
            {
                Types.Animation[E_Globals.Editorindex].Sound = "";
            }
			if (Types.Animation[E_Globals.Editorindex].Sound.Trim() == "None" || Types.Animation[E_Globals.Editorindex].Sound.Trim() == "")
			{
				FrmAnimation.Default.cmbSound.SelectedIndex = 0;
			}
			else
			{
				for (var i = 1; i <= FrmAnimation.Default.cmbSound.Items.Count; i++)
				{
					if (FrmAnimation.Default.cmbSound.Items[i - 1].ToString() == Types.Animation[E_Globals.Editorindex].Sound.Trim())
					{
						FrmAnimation.Default.cmbSound.SelectedIndex = (int)(i - 1);
						break;
					}
				}
			}
            if (Types.Animation[E_Globals.Editorindex].Name == null)
            {
                Types.Animation[E_Globals.Editorindex].Name = "";
            }
            FrmAnimation.Default.txtName.Text = Types.Animation[E_Globals.Editorindex].Name.Trim();
			
			FrmAnimation.Default.nudSprite0.Value = Types.Animation[E_Globals.Editorindex].Sprite[0];
			FrmAnimation.Default.nudFrameCount0.Value = Types.Animation[E_Globals.Editorindex].Frames[0];
			FrmAnimation.Default.nudLoopCount0.Value = Types.Animation[E_Globals.Editorindex].LoopCount[0];
			FrmAnimation.Default.nudLoopTime0.Value = Types.Animation[E_Globals.Editorindex].LoopTime[0];
			
			FrmAnimation.Default.nudSprite1.Value = Types.Animation[E_Globals.Editorindex].Sprite[1];
			FrmAnimation.Default.nudFrameCount1.Value = Types.Animation[E_Globals.Editorindex].Frames[1];
			FrmAnimation.Default.nudLoopCount1.Value = Types.Animation[E_Globals.Editorindex].LoopCount[1];
			FrmAnimation.Default.nudLoopTime1.Value = Types.Animation[E_Globals.Editorindex].LoopTime[1];
			
			E_Globals.Editorindex = FrmAnimation.Default.lstIndex.SelectedIndex + 1;
			
			E_Graphics.EditorAnim_DrawAnim();
			E_Globals.Animation_Changed[E_Globals.Editorindex] = true;
		}
		
		internal static void AnimationEditorOk()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
			{
				if (E_Globals.Animation_Changed[i])
				{
					E_NetworkSend.SendSaveAnimation(i);
				}
			}
			
			FrmAnimation.Default.Visible = false;
			E_Globals.Editor = (byte) 0;
			ClearChanged_Animation();
		}
		
		internal static void AnimationEditorCancel()
		{
			E_Globals.Editor = (byte) 0;
			FrmAnimation.Default.Visible = false;
			ClearChanged_Animation();
			ClientDataBase.ClearAnimations();
			E_NetworkSend.SendRequestAnimations();
		}
		
		internal static void ClearChanged_Animation()
		{
			for (var i = 0; i <= Constants.MAX_ANIMATIONS; i++)
			{
				E_Globals.Animation_Changed[(int) i] = false;
			}
		}
		
#endregion
		
#region Map Editor
		
		internal static void MapPropertiesInit()
		{
			int X = 0;
			int Y = 0;
			int i = 0;
			
			frmMapEditor.Default.txtName.Text = E_Types.Map.Name.Trim();
			
			// find the music we have set
			frmMapEditor.Default.lstMusic.Items.Clear();
			frmMapEditor.Default.lstMusic.Items.Add("None");
			
			if ((E_Sound.MusicCache.Length - 1) > 0)
			{
				for (i = 1; i <= (E_Sound.MusicCache.Length - 1); i++)
				{
					frmMapEditor.Default.lstMusic.Items.Add(E_Sound.MusicCache[i]);
				}
			}
			
			if (E_Types.Map.Music.Trim() == "None")
			{
				frmMapEditor.Default.lstMusic.SelectedIndex = 0;
			}
			else
			{
				for (i = 1; i <= frmMapEditor.Default.lstMusic.Items.Count; i++)
				{
					if (frmMapEditor.Default.lstMusic.Items[i - 1].ToString() == E_Types.Map.Music.Trim())
					{
						frmMapEditor.Default.lstMusic.SelectedIndex = i - 1;
						break;
					}
				}
			}
			
			// rest of it
			frmMapEditor.Default.nudUp.Value = E_Types.Map.Up;
			frmMapEditor.Default.nudDown.Value = E_Types.Map.Down;
			frmMapEditor.Default.nudLeft.Value = E_Types.Map.Left;
			frmMapEditor.Default.nudRight.Value = E_Types.Map.Right;
			frmMapEditor.Default.cmbMoral.SelectedIndex = E_Types.Map.Moral;
			frmMapEditor.Default.nudSpawnMap.Value = E_Types.Map.BootMap;
			frmMapEditor.Default.nudSpawnX.Value = E_Types.Map.BootX;
			frmMapEditor.Default.nudSpawnY.Value = E_Types.Map.BootY;
			
			if (E_Types.Map.Instanced == 1)
			{
				frmMapEditor.Default.chkInstance.Checked = true;
			}
			else
			{
				frmMapEditor.Default.chkInstance.Checked = false;
			}

            frmMapEditor.Default.lstMapNpc.Items.Clear();
			
			for (X = 1; X <= Constants.MAX_MAP_NPCS; X++)
			{
				if (E_Types.Map.Npc[X] == 0)
				{
					frmMapEditor.Default.lstMapNpc.Items.Add("No NPC");
				}
				else
				{
					frmMapEditor.Default.lstMapNpc.Items.Add(X + ": " + Types.Npc[E_Types.Map.Npc[X]].Name.Trim());
				}
				
			}
			
			frmMapEditor.Default.cmbNpcList.Items.Clear();
			frmMapEditor.Default.cmbNpcList.Items.Add("No NPC");
            
            for (Y = 1; Y <= Constants.MAX_NPCS; Y++)
			{
                if (Types.Npc[Y].Name != null)
                {
                    frmMapEditor.Default.cmbNpcList.Items.Add(Y + ": " + Types.Npc[Y].Name.Trim());
                }
                else
                {
                    frmMapEditor.Default.cmbNpcList.Items.Add(Y + ": " + "Null");
                }
			}
			
			frmMapEditor.Default.lblMap.Text = "Current Map: " + System.Convert.ToString(E_Types.Map.mapNum);
			frmMapEditor.Default.nudMaxX.Value = E_Types.Map.MaxX;
			frmMapEditor.Default.nudMaxY.Value = E_Types.Map.MaxY;
			
			frmMapEditor.Default.cmbTileSets.SelectedIndex = 0;
			frmMapEditor.Default.cmbLayers.SelectedIndex = 0;
			frmMapEditor.Default.cmbAutoTile.SelectedIndex = 0;
			
			frmMapEditor.Default.cmbWeather.SelectedIndex = E_Types.Map.WeatherType;
			frmMapEditor.Default.nudFog.Value = E_Types.Map.Fogindex;
			frmMapEditor.Default.nudIntensity.Value = E_Types.Map.WeatherIntensity;
			frmMapEditor.Default.nudBrightness.Value = E_Types.Map.Brightness;
			
			E_Globals.SelectedTab = (byte) 1;
			
			E_Graphics.GameWindow.SetView(new SFML.Graphics.View(new SFML.Graphics.FloatRect(0, 0, frmMapEditor.Default.picScreen.Width, frmMapEditor.Default.picScreen.Height)));
			
			frmMapEditor.Default.tslCurMap.Text = "Map: " + System.Convert.ToString(E_Types.Map.mapNum);
			
			// show the form
			frmMapEditor.Default.Show();
			
			E_Globals.GameStarted = true;
			
			frmMapEditor.Default.picScreen.Focus();
			
			E_Globals.InitMapEditor = false;
		}
		
		internal static void MapEditorInit()
		{
			// we're in the map editor
			E_Globals.InMapEditor = true;
			
			// set the scrolly bars
			if (E_Types.Map.tileset == 0)
			{
				E_Types.Map.tileset = 1;
			}
			if (E_Types.Map.tileset > E_Graphics.NumTileSets)
			{
				E_Types.Map.tileset = 1;
			}
			
			E_Globals.EditorTileSelStart = new Point(1, 1);
			E_Globals.EditorTileSelEnd = new Point(2, 2);
			
			//clear memory
			//ReDim TileSetImgsLoaded(NumTileSets)
			//For i = 0 To NumTileSets
			//    TileSetImgsLoaded(i) = False
			//Next
			
			// set the scrollbars
			frmMapEditor.Default.scrlPictureY.Maximum = System.Convert.ToInt32((frmMapEditor.Default.picBackSelect.Height / E_Globals.PIC_Y) / 2); // \2 is new, lets test
			frmMapEditor.Default.scrlPictureX.Maximum = System.Convert.ToInt32((frmMapEditor.Default.picBackSelect.Width / E_Globals.PIC_X) / 2);
			
			//set map names
			frmMapEditor.Default.cmbMapList.Items.Clear();
			FrmVisualWarp.Default.lstMaps.Items.Clear();
			
			for (var i = 1; i <= Constants.MAX_MAPS; i++)
			{
				frmMapEditor.Default.cmbMapList.Items.Add(i + ": " + E_Types.MapNames[(int) i]);
				FrmVisualWarp.Default.lstMaps.Items.Add(i + ": " + E_Types.MapNames[(int) i]);
			}
			
			if (E_Types.Map.mapNum > 0)
			{
				frmMapEditor.Default.cmbMapList.SelectedIndex = E_Types.Map.mapNum - 1;
			}
			else
			{
				frmMapEditor.Default.cmbMapList.SelectedIndex = 0;
			}
			
			// set shops for the shop attribute
			frmMapEditor.Default.cmbShop.Items.Add("None");
			for (var i = 1; i <= Constants.MAX_SHOPS; i++)
			{
				frmMapEditor.Default.cmbShop.Items.Add(i + ": " + Types.Shop[(int) i].Name);
			}
			// we're not in a shop
			frmMapEditor.Default.cmbShop.SelectedIndex = 0;
			
			frmMapEditor.Default.optBlocked.Checked = true;
			
			frmMapEditor.Default.cmbTileSets.Items.Clear();
			for (var i = 1; i <= E_Graphics.NumTileSets; i++)
			{
				frmMapEditor.Default.cmbTileSets.Items.Add("Tileset " + System.Convert.ToString(i));
			}
			
			frmMapEditor.Default.cmbTileSets.SelectedIndex = 0;
			frmMapEditor.Default.cmbLayers.SelectedIndex = 0;
			
			E_Globals.InitMapProperties = true;
			
			if (E_Globals.MapData == true)
			{
				E_Globals.GettingMap = false;
			}

		}
		
		internal static void MapEditorTileScroll()
		{
			frmMapEditor.Default.picBackSelect.Top = (frmMapEditor.Default.scrlPictureY.Value * E_Globals.PIC_Y) * -1;
			frmMapEditor.Default.picBackSelect.Left = (frmMapEditor.Default.scrlPictureX.Value * E_Globals.PIC_X) * -1;
		}
		
		internal static void MapEditorChooseTile(int Button, float X, float Y)
		{
			
			if (Button == (int) MouseButtons.Left) //Left Mouse Button
			{
				
				E_Globals.EditorTileWidth = 1;
				E_Globals.EditorTileHeight = 1;
				
				if (frmMapEditor.Default.cmbAutoTile.SelectedIndex > 0)
				{
					switch (frmMapEditor.Default.cmbAutoTile.SelectedIndex)
					{
						case 1: // autotile
							E_Globals.EditorTileWidth = 2;
							E_Globals.EditorTileHeight = 3;
							break;
						case 2: // fake autotile
							E_Globals.EditorTileWidth = 1;
							E_Globals.EditorTileHeight = 1;
							break;
						case 3: // animated
							E_Globals.EditorTileWidth = 6;
							E_Globals.EditorTileHeight = 3;
							break;
						case 4: // cliff
							E_Globals.EditorTileWidth = 2;
							E_Globals.EditorTileHeight = 2;
							break;
						case 5: // waterfall
							E_Globals.EditorTileWidth = 2;
							E_Globals.EditorTileHeight = 3;
							break;
					}
				}
				
				E_Globals.EditorTileX = (int)(X / E_Globals.PIC_X);
				E_Globals.EditorTileY = (int)(Y / E_Globals.PIC_Y);
				
				E_Globals.EditorTileSelStart = new Point(E_Globals.EditorTileX, E_Globals.EditorTileY);
				E_Globals.EditorTileSelEnd = new Point(E_Globals.EditorTileX + E_Globals.EditorTileWidth, E_Globals.EditorTileY + E_Globals.EditorTileHeight);
				
			}
			
		}
		
		internal static void MapEditorDrag(int Button, float X, float Y)
		{
			
			if (Button == (int) MouseButtons.Left) //Left Mouse Button
			{
				// convert the pixel number to tile number
				X = ((X / E_Globals.PIC_X) + 1);
				Y = ((Y / E_Globals.PIC_Y) + 1);
				// check it's not out of bounds
				if (X < 0)
				{
					X = 0;
				}
				if (X > (double)frmMapEditor.Default.picBackSelect.Width / E_Globals.PIC_X)
				{
					X = (float)((double)frmMapEditor.Default.picBackSelect.Width / E_Globals.PIC_X);
				}
				if (Y < 0)
				{
					Y = 0;
				}
				if (Y > (double)frmMapEditor.Default.picBackSelect.Height / E_Globals.PIC_Y)
				{
					Y = (float)((double)frmMapEditor.Default.picBackSelect.Height / E_Globals.PIC_Y);
				}
				// find out what to set the width + height of map editor to
				if (X > E_Globals.EditorTileX) // drag right
				{
                    //EditorTileWidth = X
                    if ((int)(X - E_Globals.EditorTileX) < 1)
                    {
                        E_Globals.EditorTileWidth = 1;
                    }
                    else
                    {
                        E_Globals.EditorTileWidth = (int)(X - E_Globals.EditorTileX);
                    }
				}
				else // drag left
				{
					// TO DO
				}
				if (Y > E_Globals.EditorTileY) // drag down
				{
                    //EditorTileHeight = Y
                    if ((int)(Y - E_Globals.EditorTileY) < 1)
                    {
                        E_Globals.EditorTileHeight = 1;
                    }
                    else
                    {
                        E_Globals.EditorTileHeight = (int)(Y - E_Globals.EditorTileY);
                    }
				}
				else // drag up
				{
					// TO DO
				}
				
				E_Globals.EditorTileSelStart = new Point(E_Globals.EditorTileX, E_Globals.EditorTileY);
				E_Globals.EditorTileSelEnd = new Point(E_Globals.EditorTileWidth, E_Globals.EditorTileHeight);
			}
			
		}
		
		internal static void MapEditorMouseDown(int Button, int X, int Y, bool movedMouse = true)
		{
			int i = 0;
			int CurLayer = 0;
			
			CurLayer = frmMapEditor.Default.cmbLayers.SelectedIndex + 1;
			
			if (!ClientDataBase.IsInBounds())
			{
				return;
			}
			if (Button == (int) MouseButtons.Left)
			{
				if (E_Globals.SelectedTab == 1)
				{
					// (EditorTileSelEnd.X - EditorTileSelStart.X) = 1 AndAlso (EditorTileSelEnd.Y - EditorTileSelStart.Y) = 1 Then 'single tile
					if (E_Globals.EditorTileWidth == 1 && E_Globals.EditorTileHeight == 1)
					{
						
						MapEditorSetTile(E_Globals.CurX, E_Globals.CurY, CurLayer, false, (byte) frmMapEditor.Default.cmbAutoTile.SelectedIndex);
					}
					else // multi tile!
					{
						if (frmMapEditor.Default.cmbAutoTile.SelectedIndex == 0)
						{
							MapEditorSetTile(E_Globals.CurX, E_Globals.CurY, CurLayer, true);
						}
						else
						{
							MapEditorSetTile(X: E_Globals.CurX, Y: E_Globals.CurY, CurLayer: CurLayer, theAutotile: (byte) frmMapEditor.Default.cmbAutoTile.SelectedIndex);
						}
					}
				}
				else if (E_Globals.SelectedTab == 2)
				{
					// blocked tile
					if (frmMapEditor.Default.optBlocked.Checked == true)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.Blocked;
					}
					// warp tile
					if (frmMapEditor.Default.optWarp.Checked == true)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.Warp;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = E_Globals.EditorWarpMap;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = E_Globals.EditorWarpX;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = E_Globals.EditorWarpY;
					}
					// item spawn
					if (frmMapEditor.Default.optItem.Checked == true)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.Item;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = E_Globals.ItemEditorNum;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = E_Globals.ItemEditorValue;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
					}
					// npc avoid
					if (frmMapEditor.Default.optNpcAvoid.Checked == true)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.NpcAvoid;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = 0;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = 0;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
					}
					// key
					if (frmMapEditor.Default.optKey.Checked == true)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.Key;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = E_Globals.KeyEditorNum;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = E_Globals.KeyEditorTake;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
					}
					// key open
					if (frmMapEditor.Default.optKeyOpen.Checked == true)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.KeyOpen;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = E_Globals.KeyOpenEditorX;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = E_Globals.KeyOpenEditorY;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
					}
					// resource
					if (frmMapEditor.Default.optResource.Checked == true)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.Resource;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = E_Globals.ResourceEditorNum;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = 0;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
					}
					// door
					if (frmMapEditor.Default.optDoor.Checked == true)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.Door;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = E_Globals.EditorWarpMap;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = E_Globals.EditorWarpX;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = E_Globals.EditorWarpY;
					}
					// npc spawn
					if (frmMapEditor.Default.optNpcSpawn.Checked == true)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.NpcSpawn;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = E_Globals.SpawnNpcNum;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = E_Globals.SpawnNpcDir;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
					}
					// shop
					if (frmMapEditor.Default.optShop.Checked == true)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.Shop;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = E_Globals.EditorShop;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = 0;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
					}
					// bank
					if (frmMapEditor.Default.optBank.Checked == true)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.Bank;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = 0;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = 0;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
					}
					// heal
					if (frmMapEditor.Default.optHeal.Checked == true)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.Heal;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = E_Globals.MapEditorHealType;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = E_Globals.MapEditorHealAmount;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
					}
					// trap
					if (frmMapEditor.Default.optTrap.Checked == true)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.Trap;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = E_Globals.MapEditorHealAmount;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = 0;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
					}
					//Housing
					if (frmMapEditor.Default.optHouse.Checked)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.House;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = E_Housing.HouseTileindex;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = 0;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
					}
					//craft tile
					if (frmMapEditor.Default.optCraft.Checked)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.Craft;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = 0;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = 0;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
					}
					if (frmMapEditor.Default.optLight.Checked)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = (byte)Enums.TileType.Light;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = 0;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = 0;
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
					}
				}
				else if (E_Globals.SelectedTab == 4)
				{
					if (movedMouse)
					{
						return;
					}
					// find what tile it is
					X = X - ((X / E_Globals.PIC_X) * E_Globals.PIC_X);
					Y = Y - ((Y / E_Globals.PIC_Y) * E_Globals.PIC_Y);
					// see if it hits an arrow
					for (i = 1; i <= 4; i++)
					{
						if (X >= E_Globals.DirArrowX[i] && X <= E_Globals.DirArrowX[i] + 8)
						{
							if (Y >= E_Globals.DirArrowY[i] && Y <= E_Globals.DirArrowY[i] + 8)
							{
								// flip the value.
								E_Graphics.SetDirBlock(ref E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].DirBlock, (byte) (i), !E_Graphics.IsDirBlocked(E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].DirBlock, (byte) (i)));
								return;
							}
						}
					}
				}
				else if (E_Globals.SelectedTab == 5)
				{
					if (frmEvents.Default.Visible == false)
					{
						E_EventSystem.AddEvent(E_Globals.CurX, E_Globals.CurY);
					}
				}
			}
			
			if (Button == (int) MouseButtons.Right)
			{
				if (E_Globals.SelectedTab == 1)
				{
					
					// clear layer
					E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Layer[CurLayer].X = 0;
					E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Layer[CurLayer].Y = 0;
					E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Layer[CurLayer].Tileset = 0;
					if (E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Layer[CurLayer].AutoTile > 0)
					{
						E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Layer[CurLayer].AutoTile = 0;
						// do a re-init so we can see our changes
						E_AutoTiles.InitAutotiles();
					}
					E_AutoTiles.CacheRenderState(X, Y, CurLayer);
					
				}
				else if (E_Globals.SelectedTab == 2)
				{
					// clear attribute
					E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Type = 0;
					E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data1 = 0;
					E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data2 = 0;
					E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].Data3 = 0;
				}
				else if (E_Globals.SelectedTab == 5)
				{
					E_EventSystem.DeleteEvent(E_Globals.CurX, E_Globals.CurY);
				}
			}
			
		}
		
		internal static void MapEditorCancel()
		{
			E_Globals.InMapEditor = false;
			frmMapEditor.Default.Visible = false;
			E_Globals.GettingMap = true;
			
			E_AutoTiles.InitAutotiles();
			
		}
		
		internal static void MapEditorSend()
		{
			E_NetworkSend.SendEditorMap();
			E_Globals.InMapEditor = false;
			frmMapEditor.Default.Visible = false;
			E_Globals.GettingMap = true;
			
		}
		
		internal static void MapEditorSetTile(int X, int Y, int CurLayer, bool multitile = false, byte theAutotile = 0)
		{
			int x2 = 0;
			int y2 = 0;
			
			if (theAutotile > 0)
			{
				// set layer
				E_Types.Map.Tile[X, Y].Layer[CurLayer].X = (byte)E_Globals.EditorTileX;
				E_Types.Map.Tile[X, Y].Layer[CurLayer].Y = (byte)E_Globals.EditorTileY;
				E_Types.Map.Tile[X, Y].Layer[CurLayer].Tileset = (byte)(frmMapEditor.Default.cmbTileSets.SelectedIndex + 1);
				E_Types.Map.Tile[X, Y].Layer[CurLayer].AutoTile = theAutotile;
				E_AutoTiles.CacheRenderState(X, Y, CurLayer);
				// do a re-init so we can see our changes
				E_AutoTiles.InitAutotiles();
				return;
			}
			
			if (!multitile) // single
			{
				// set layer
				E_Types.Map.Tile[X, Y].Layer[CurLayer].X = (byte)E_Globals.EditorTileX;
				E_Types.Map.Tile[X, Y].Layer[CurLayer].Y = (byte)E_Globals.EditorTileY;
				E_Types.Map.Tile[X, Y].Layer[CurLayer].Tileset = (byte)(frmMapEditor.Default.cmbTileSets.SelectedIndex + 1);
				E_Types.Map.Tile[X, Y].Layer[CurLayer].AutoTile = 0;
				E_AutoTiles.CacheRenderState(X, Y, CurLayer);
            }
			else // multitile
			{
				y2 = 0; // starting tile for y axis
				for (var Yy = E_Globals.CurY; Yy < E_Globals.CurY + E_Globals.EditorTileHeight; Yy++)
				{
					x2 = 0; // re-set x count every y loop
					for (var Xx = E_Globals.CurX; Xx < E_Globals.CurX + E_Globals.EditorTileWidth; Xx++)
					{
						if (Xx >= 0 && Xx <= E_Types.Map.MaxX)
						{
							if (Yy >= 0 && Yy <= E_Types.Map.MaxY)
							{
                                E_Types.Map.Tile[Xx, Yy].Layer[CurLayer].X = (byte)(E_Globals.EditorTileX + x2);
								E_Types.Map.Tile[Xx, Yy].Layer[CurLayer].Y = (byte)(E_Globals.EditorTileY + y2);
								E_Types.Map.Tile[Xx, Yy].Layer[CurLayer].Tileset = (byte)(frmMapEditor.Default.cmbTileSets.SelectedIndex + 1);
								E_Types.Map.Tile[Xx, Yy].Layer[CurLayer].AutoTile = 0;
								E_AutoTiles.CacheRenderState(X, Y, CurLayer);
                            }
						}
						x2++;
					}
					y2++;
				}
			}
		}
		
		internal static void MapEditorClearLayer()
		{
			int X = 0;
			int Y = 0;
			int CurLayer = 0;
			
			CurLayer = frmMapEditor.Default.cmbLayers.SelectedIndex + 1;
			
			if (CurLayer == 0)
			{
				return;
			}
			
			// ask to clear layer
			if (Interaction.MsgBox("Are you sure you wish to clear this layer?",Microsoft.VisualBasic.Constants.vbYesNo, "MapEditor") ==Microsoft.VisualBasic.Constants.vbYes)
			{
				for (X = 0; X <= E_Types.Map.MaxX; X++)
				{
					for (Y = 0; Y <= E_Types.Map.MaxY; Y++)
					{
						E_Types.Map.Tile[X, Y].Layer[CurLayer].X = 0;
						E_Types.Map.Tile[X, Y].Layer[CurLayer].Y = 0;
						E_Types.Map.Tile[X, Y].Layer[CurLayer].Tileset = 0;
						E_Types.Map.Tile[X, Y].Layer[CurLayer].AutoTile = 0;
						E_AutoTiles.CacheRenderState(X, Y, CurLayer);
					}
				}
			}
		}
		
		internal static void MapEditorFillLayer(byte theAutotile = 0)
		{
			int X = 0;
			int Y = 0;
			int CurLayer = 0;
			
			CurLayer = frmMapEditor.Default.cmbLayers.SelectedIndex + 1;
			
			if (Interaction.MsgBox("Are you sure you wish to fill this layer?", Microsoft.VisualBasic.Constants.vbYesNo, "Map Editor") == Microsoft.VisualBasic.Constants.vbYes)
			{
				if (theAutotile > 0)
				{
					for (X = 0; X <= E_Types.Map.MaxX; X++)
					{
						for (Y = 0; Y <= E_Types.Map.MaxY; Y++)
						{
							E_Types.Map.Tile[X, Y].Layer[CurLayer].X = (byte) E_Globals.EditorTileX;
							E_Types.Map.Tile[X, Y].Layer[CurLayer].Y = (byte) E_Globals.EditorTileY;
							E_Types.Map.Tile[X, Y].Layer[CurLayer].Tileset = (byte) (frmMapEditor.Default.cmbTileSets.SelectedIndex + 1);
							E_Types.Map.Tile[X, Y].Layer[CurLayer].AutoTile = theAutotile;
							E_AutoTiles.CacheRenderState(X, Y, CurLayer);
						}
					}
					
					// do a re-init so we can see our changes
					E_AutoTiles.InitAutotiles();
				}
				else
				{
					for (X = 0; X <= E_Types.Map.MaxX; X++)
					{
						for (Y = 0; Y <= E_Types.Map.MaxY; Y++)
						{
							E_Types.Map.Tile[X, Y].Layer[CurLayer].X = (byte) E_Globals.EditorTileX;
							E_Types.Map.Tile[X, Y].Layer[CurLayer].Y = (byte) E_Globals.EditorTileY;
							E_Types.Map.Tile[X, Y].Layer[CurLayer].Tileset = (byte) (frmMapEditor.Default.cmbTileSets.SelectedIndex + 1);
							E_AutoTiles.CacheRenderState(X, Y, CurLayer);
						}
					}
				}
			}
		}
		
		internal static void ClearAttributeDialogue()
		{
			
			frmMapEditor.Default.fraNpcSpawn.Visible = false;
			frmMapEditor.Default.fraResource.Visible = false;
			frmMapEditor.Default.fraMapItem.Visible = false;
			frmMapEditor.Default.fraMapKey.Visible = false;
			frmMapEditor.Default.fraKeyOpen.Visible = false;
			frmMapEditor.Default.fraMapWarp.Visible = false;
			frmMapEditor.Default.fraShop.Visible = false;
			frmMapEditor.Default.fraHeal.Visible = false;
			frmMapEditor.Default.fraTrap.Visible = false;
			frmMapEditor.Default.fraBuyHouse.Visible = false;
			
		}
		
		internal static void MapEditorClearAttribs()
		{
			int X = 0;
			int Y = 0;
			
			if (Interaction.MsgBox("Are you sure you wish to clear the attributes on this map?", Microsoft.VisualBasic.Constants.vbYesNo, "MapEditor") == Microsoft.VisualBasic.Constants.vbYes)
			{
				
				for (X = 0; X <= E_Types.Map.MaxX; X++)
				{
					for (Y = 0; Y <= E_Types.Map.MaxY; Y++)
					{
						E_Types.Map.Tile[X, Y].Type = (byte) 0;
					}
				}
				
			}
			
		}
		
		internal static void MapEditorLeaveMap()
		{
			
			if (E_Globals.InMapEditor)
			{
				if (Interaction.MsgBox("Save changes to current map?", Microsoft.VisualBasic.Constants.vbYesNo, null) == Microsoft.VisualBasic.Constants.vbYes)
				{
					MapEditorSend();
				}
				else
				{
					MapEditorCancel();
				}
			}
			
		}
		
#endregion
		
		
		
#region Npc Editor
		
		internal static void NpcEditorInit()
		{
			int i = 0;
			
			if (frmNPC.Default.Visible == false)
			{
				return;
			}
			E_Globals.Editorindex = frmNPC.Default.lstIndex.SelectedIndex + 1;
			frmNPC.Default.cmbDropSlot.SelectedIndex = 0;
			if (ReferenceEquals(Types.Npc[E_Globals.Editorindex].AttackSay, null))
			{
				Types.Npc[E_Globals.Editorindex].AttackSay = "";
			}
			if (ReferenceEquals(Types.Npc[E_Globals.Editorindex].Name, null))
			{
				Types.Npc[E_Globals.Editorindex].Name = "";
			}
			
			//populate combo boxes
			frmNPC.Default.cmbAnimation.Items.Clear();
            frmNPC.Default.cmbAnimation.Items.Add("None");
			for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
			{
                frmNPC.Default.cmbAnimation.Items.Add(i + ": " + Types.Animation[i].Name);
			}

            frmNPC.Default.cmbQuest.Items.Clear();
            frmNPC.Default.cmbQuest.Items.Add("None");
			for (i = 1; i <= E_Quest.MAX_QUESTS; i++)
			{
                frmNPC.Default.cmbQuest.Items.Add(i + ": " + E_Quest.Quest[i].Name);
			}

            frmNPC.Default.cmbItem.Items.Clear();
            frmNPC.Default.cmbItem.Items.Add("None");
			for (i = 1; i <= Constants.MAX_ITEMS; i++)
			{
                frmNPC.Default.cmbItem.Items.Add(i + ": " + Types.Item[i].Name);
			}

            frmNPC.Default.txtName.Text = Types.Npc[E_Globals.Editorindex].Name.Trim();
            frmNPC.Default.txtAttackSay.Text = Types.Npc[E_Globals.Editorindex].AttackSay.Trim();
			
			if (Types.Npc[E_Globals.Editorindex].Sprite < 0 || Types.Npc[E_Globals.Editorindex].Sprite > frmNPC.Default.nudSprite.Maximum)
			{
				Types.Npc[E_Globals.Editorindex].Sprite = 0;
			}
			frmNPC.Default.nudSprite.Value = Types.Npc[E_Globals.Editorindex].Sprite;
			frmNPC.Default.nudSpawnSecs.Value = Types.Npc[E_Globals.Editorindex].SpawnSecs;
			frmNPC.Default.cmbBehaviour.SelectedIndex = Types.Npc[E_Globals.Editorindex].Behaviour;
			frmNPC.Default.cmbFaction.SelectedIndex = Types.Npc[E_Globals.Editorindex].Faction;
			frmNPC.Default.nudRange.Value = Types.Npc[E_Globals.Editorindex].Range;
			frmNPC.Default.nudChance.Value = Types.Npc[E_Globals.Editorindex].DropChance[frmNPC.Default.cmbDropSlot.SelectedIndex + 1];
            frmNPC.Default.cmbItem.SelectedIndex = Types.Npc[E_Globals.Editorindex].DropItem[frmNPC.Default.cmbDropSlot.SelectedIndex + 1];

            frmNPC.Default.nudAmount.Value = Types.Npc[E_Globals.Editorindex].DropItemValue[frmNPC.Default.cmbDropSlot.SelectedIndex + 1];
			
			frmNPC.Default.nudHp.Value = Types.Npc[E_Globals.Editorindex].Hp;
			frmNPC.Default.nudExp.Value = Types.Npc[E_Globals.Editorindex].Exp;
			frmNPC.Default.nudLevel.Value = Types.Npc[E_Globals.Editorindex].Level;
            frmNPC.Default.nudDamage.Value = Types.Npc[E_Globals.Editorindex].Damage;

            frmNPC.Default.cmbQuest.SelectedIndex = Types.Npc[E_Globals.Editorindex].QuestNum;
            frmNPC.Default.cmbSpawnPeriod.SelectedIndex = Types.Npc[E_Globals.Editorindex].SpawnTime;
			
			frmNPC.Default.nudStrength.Value = Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Strength];
			frmNPC.Default.nudEndurance.Value = Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Endurance];
			frmNPC.Default.nudIntelligence.Value = Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Intelligence];
			frmNPC.Default.nudSpirit.Value = Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Spirit];
			frmNPC.Default.nudLuck.Value = Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Luck];
            frmNPC.Default.nudVitality.Value = Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Vitality];
			
			frmNPC.Default.cmbSkill1.Items.Clear();
			frmNPC.Default.cmbSkill2.Items.Clear();
			frmNPC.Default.cmbSkill3.Items.Clear();
			frmNPC.Default.cmbSkill4.Items.Clear();
			frmNPC.Default.cmbSkill5.Items.Clear();
            frmNPC.Default.cmbSkill6.Items.Clear();
			
			frmNPC.Default.cmbSkill1.Items.Add("None");
			frmNPC.Default.cmbSkill2.Items.Add("None");
			frmNPC.Default.cmbSkill3.Items.Add("None");
			frmNPC.Default.cmbSkill4.Items.Add("None");
			frmNPC.Default.cmbSkill5.Items.Add("None");
            frmNPC.Default.cmbSkill6.Items.Add("None");
			
			for (i = 1; i <= Constants.MAX_SKILLS; i++)
			{
                if (Types.Skill[i].Name == null)
                {
                    Types.Skill[i].Name = "";
                }
                if (Types.Skill[i].Name.Length > 0)
				{
					frmNPC.Default.cmbSkill1.Items.Add(Types.Skill[i].Name);
					frmNPC.Default.cmbSkill2.Items.Add(Types.Skill[i].Name);
					frmNPC.Default.cmbSkill3.Items.Add(Types.Skill[i].Name);
					frmNPC.Default.cmbSkill4.Items.Add(Types.Skill[i].Name);
					frmNPC.Default.cmbSkill5.Items.Add(Types.Skill[i].Name);
                    frmNPC.Default.cmbSkill6.Items.Add(Types.Skill[i].Name);
				}
			}
			
			frmNPC.Default.cmbSkill1.SelectedIndex = Types.Npc[E_Globals.Editorindex].Skill[1];
			frmNPC.Default.cmbSkill2.SelectedIndex = Types.Npc[E_Globals.Editorindex].Skill[2];
			frmNPC.Default.cmbSkill3.SelectedIndex = Types.Npc[E_Globals.Editorindex].Skill[3];
			frmNPC.Default.cmbSkill4.SelectedIndex = Types.Npc[E_Globals.Editorindex].Skill[4];
			frmNPC.Default.cmbSkill5.SelectedIndex = Types.Npc[E_Globals.Editorindex].Skill[5];
            frmNPC.Default.cmbSkill6.SelectedIndex = Types.Npc[E_Globals.Editorindex].Skill[6];
			
			E_Graphics.EditorNpc_DrawSprite();
			E_Globals.NPC_Changed[E_Globals.Editorindex] = true;
		}
		
		internal static void NpcEditorOk()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_NPCS; i++)
			{
				if (E_Globals.NPC_Changed[i])
				{
					E_NetworkSend.SendSaveNpc(i);
				}
			}
			
			frmNPC.Default.Visible = false;
			E_Globals.Editor = (byte) 0;
			ClearChanged_NPC();
		}
		
		internal static void NpcEditorCancel()
		{
			E_Globals.Editor = (byte) 0;
			frmNPC.Default.Visible = false;
			ClearChanged_NPC();
			ClientDataBase.ClearNpcs();
			E_NetworkSend.SendRequestNPCS();
		}
		
		internal static void ClearChanged_NPC()
		{
			for (var i = 1; i <= Constants.MAX_NPCS; i++)
			{
				E_Globals.NPC_Changed[(int) i] = false;
			}
		}
		
#endregion
		
#region Resource Editor
		
		internal static void ResourceEditorInit()
		{
			int i = 0;
			
			if (FrmResource.Default.Visible == false)
			{
				return;
			}
			E_Globals.Editorindex = FrmResource.Default.lstIndex.SelectedIndex + 1;
			
			//populate combo boxes
			FrmResource.Default.cmbRewardItem.Items.Clear();
			FrmResource.Default.cmbRewardItem.Items.Add("None");
			for (i = 1; i <= Constants.MAX_ITEMS; i++)
			{
				FrmResource.Default.cmbRewardItem.Items.Add(i + ": " + Types.Item[i].Name);
			}
			
			FrmResource.Default.cmbAnimation.Items.Clear();
			FrmResource.Default.cmbAnimation.Items.Add("None");
			for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
			{
				FrmResource.Default.cmbAnimation.Items.Add(i + ": " + Types.Animation[i].Name);
			}
			
			FrmResource.Default.nudExhaustedPic.Maximum = E_Graphics.NumResources;
			FrmResource.Default.nudNormalPic.Maximum = E_Graphics.NumResources;
			FrmResource.Default.nudRespawn.Maximum = 1000000;
			FrmResource.Default.txtName.Text = Types.Resource[E_Globals.Editorindex].Name.Trim();
			FrmResource.Default.txtMessage.Text = Types.Resource[E_Globals.Editorindex].SuccessMessage.Trim();
			FrmResource.Default.txtMessage2.Text = Types.Resource[E_Globals.Editorindex].EmptyMessage.Trim();
			FrmResource.Default.cmbType.SelectedIndex = Types.Resource[E_Globals.Editorindex].ResourceType;
			FrmResource.Default.nudNormalPic.Value = Types.Resource[E_Globals.Editorindex].ResourceImage;
			FrmResource.Default.nudExhaustedPic.Value = Types.Resource[E_Globals.Editorindex].ExhaustedImage;
			FrmResource.Default.cmbRewardItem.SelectedIndex = Types.Resource[E_Globals.Editorindex].ItemReward;
			FrmResource.Default.nudRewardExp.Value = Types.Resource[E_Globals.Editorindex].ExpReward;
			FrmResource.Default.cmbTool.SelectedIndex = Types.Resource[E_Globals.Editorindex].ToolRequired;
			FrmResource.Default.nudHealth.Value = Types.Resource[E_Globals.Editorindex].Health;
			FrmResource.Default.nudRespawn.Value = Types.Resource[E_Globals.Editorindex].RespawnTime;
			FrmResource.Default.cmbAnimation.SelectedIndex = Types.Resource[E_Globals.Editorindex].Animation;
			FrmResource.Default.nudLvlReq.Value = Types.Resource[E_Globals.Editorindex].LvlRequired;
			
			FrmResource.Default.Visible = true;
			
			E_Graphics.EditorResource_DrawSprite();
			
			E_Globals.Resource_Changed[E_Globals.Editorindex] = true;
		}
		
		internal static void ResourceEditorOk()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_RESOURCES; i++)
			{
				if (E_Globals.Resource_Changed[i])
				{
					E_NetworkSend.SendSaveResource(i);
				}
			}
			
			FrmResource.Default.Visible = false;
			E_Globals.Editor = (byte) 0;
			ClientDataBase.ClearChanged_Resource();
		}
		
		internal static void ResourceEditorCancel()
		{
			E_Globals.Editor = (byte) 0;
			FrmResource.Default.Visible = false;
			ClientDataBase.ClearChanged_Resource();
			ClientDataBase.ClearResources();
			E_NetworkSend.SendRequestResources();
		}
		
#endregion
		
#region Skill Editor
		
		internal static void SkillEditorInit()
		{
			int i = 0;
			
			if (frmSkill.Default.Visible == false)
			{
				return;
			}
			E_Globals.Editorindex = frmSkill.Default.lstIndex.SelectedIndex + 1;
			
			if (ReferenceEquals(Types.Skill[E_Globals.Editorindex].Name, null))
			{
				Types.Skill[E_Globals.Editorindex].Name = "";
			}
			
			// set max values
			frmSkill.Default.nudAoE.Maximum = byte.MaxValue;
			frmSkill.Default.nudRange.Maximum = byte.MaxValue;
			frmSkill.Default.nudMap.Maximum = Constants.MAX_MAPS;
			
			// build class combo
			frmSkill.Default.cmbClass.Items.Clear();
			frmSkill.Default.cmbClass.Items.Add("None");
			for (i = 1; i <= E_Globals.Max_Classes; i++)
			{
                if(Types.Classes[i].Name == null)
                {
                    Types.Classes[i].Name = "";
                }
				frmSkill.Default.cmbClass.Items.Add(Types.Classes[i].Name.Trim());
			}
			frmSkill.Default.cmbClass.SelectedIndex = 0;
			
			frmSkill.Default.cmbProjectile.Items.Clear();
			frmSkill.Default.cmbProjectile.Items.Add("None");
			for (i = 1; i <= E_Projectiles.MAX_PROJECTILES; i++)
			{
                if (E_Projectiles.Projectiles[i].Name == null)
                {
                    E_Projectiles.Projectiles[i].Name = "";
                }
                frmSkill.Default.cmbProjectile.Items.Add(E_Projectiles.Projectiles[i].Name.Trim());
			}
			frmSkill.Default.cmbProjectile.SelectedIndex = 0;
			
			frmSkill.Default.cmbAnimCast.Items.Clear();
			frmSkill.Default.cmbAnimCast.Items.Add("None");
			frmSkill.Default.cmbAnim.Items.Clear();
			frmSkill.Default.cmbAnim.Items.Add("None");
			for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
			{
                if (Types.Animation[i].Name == null)
                {
                    Types.Animation[i].Name = "";
                }
                frmSkill.Default.cmbAnimCast.Items.Add(Types.Animation[i].Name.Trim());
				frmSkill.Default.cmbAnim.Items.Add(Types.Animation[i].Name.Trim());
			}
			frmSkill.Default.cmbAnimCast.SelectedIndex = 0;
			frmSkill.Default.cmbAnim.SelectedIndex = 0;
			
			// set values
			frmSkill.Default.txtName.Text = Types.Skill[E_Globals.Editorindex].Name.Trim();
			frmSkill.Default.cmbType.SelectedIndex = Types.Skill[E_Globals.Editorindex].Type;
			frmSkill.Default.nudMp.Value = Types.Skill[E_Globals.Editorindex].MpCost;
			frmSkill.Default.nudLevel.Value = Types.Skill[E_Globals.Editorindex].LevelReq;
			frmSkill.Default.cmbAccessReq.SelectedIndex = Types.Skill[E_Globals.Editorindex].AccessReq;
			frmSkill.Default.cmbClass.SelectedIndex = Types.Skill[E_Globals.Editorindex].ClassReq;
			frmSkill.Default.nudCast.Value = Types.Skill[E_Globals.Editorindex].CastTime;
			frmSkill.Default.nudCool.Value = Types.Skill[E_Globals.Editorindex].CdTime;
			frmSkill.Default.nudIcon.Value = Types.Skill[E_Globals.Editorindex].Icon;
			frmSkill.Default.nudMap.Value = Types.Skill[E_Globals.Editorindex].Map;
			frmSkill.Default.nudX.Value = Types.Skill[E_Globals.Editorindex].X;
			frmSkill.Default.nudY.Value = Types.Skill[E_Globals.Editorindex].Y;
			frmSkill.Default.cmbDir.SelectedIndex = Types.Skill[E_Globals.Editorindex].Dir;
			frmSkill.Default.nudVital.Value = Types.Skill[E_Globals.Editorindex].Vital;
			frmSkill.Default.nudDuration.Value = Types.Skill[E_Globals.Editorindex].Duration;
			frmSkill.Default.nudInterval.Value = Types.Skill[E_Globals.Editorindex].Interval;
			frmSkill.Default.nudRange.Value = Types.Skill[E_Globals.Editorindex].Range;
			
			frmSkill.Default.chkAoE.Checked = Types.Skill[E_Globals.Editorindex].IsAoE;
			
			frmSkill.Default.nudAoE.Value = Types.Skill[E_Globals.Editorindex].AoE;
			frmSkill.Default.cmbAnimCast.SelectedIndex = Types.Skill[E_Globals.Editorindex].CastAnim;
			frmSkill.Default.cmbAnim.SelectedIndex = Types.Skill[E_Globals.Editorindex].SkillAnim;
			frmSkill.Default.nudStun.Value = Types.Skill[E_Globals.Editorindex].StunDuration;
			
			if (Types.Skill[E_Globals.Editorindex].IsProjectile == 1)
			{
				frmSkill.Default.chkProjectile.Checked = true;
			}
			else
			{
				frmSkill.Default.chkProjectile.Checked = false;
			}
			frmSkill.Default.cmbProjectile.SelectedIndex = Types.Skill[E_Globals.Editorindex].Projectile;
			
			if (Types.Skill[E_Globals.Editorindex].KnockBack == 1)
			{
				frmSkill.Default.chkKnockBack.Checked = true;
			}
			else
			{
				frmSkill.Default.chkKnockBack.Checked = false;
			}
			frmSkill.Default.cmbKnockBackTiles.SelectedIndex = Types.Skill[E_Globals.Editorindex].KnockBackTiles;
			
			E_Graphics.EditorSkill_BltIcon();
			
			E_Globals.Skill_Changed[E_Globals.Editorindex] = true;
		}
		
		internal static void SkillEditorOk()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_SKILLS; i++)
			{
				if (E_Globals.Skill_Changed[i])
				{
					E_NetworkSend.SendSaveSkill(i);
				}
			}
			
			frmSkill.Default.Visible = false;
			E_Globals.Editor = (byte) 0;
			ClearChanged_Skill();
		}
		
		internal static void SkillEditorCancel()
		{
			E_Globals.Editor = (byte) 0;
			frmSkill.Default.Visible = false;
			ClearChanged_Skill();
			ClientDataBase.ClearSkills();
			E_NetworkSend.SendRequestSkills();
		}
		
		internal static void ClearChanged_Skill()
		{
			for (var i = 1; i <= Constants.MAX_SKILLS; i++)
			{
				E_Globals.Skill_Changed[(int) i] = false;
			}
		}
		
#endregion
		
#region Shop editor
		
		internal static void ShopEditorInit()
		{
			int i = 0;
			
			if (frmShop.Default.Visible == false)
			{
				return;
			}
			E_Globals.Editorindex = frmShop.Default.lstIndex.SelectedIndex + 1;
            if (Types.Shop[E_Globals.Editorindex].Name == null)
            {
                Types.Shop[E_Globals.Editorindex].Name = "";
            }
            frmShop.Default.txtName.Text = Types.Shop[E_Globals.Editorindex].Name.Trim();
			if (Types.Shop[E_Globals.Editorindex].BuyRate > 0)
			{
				frmShop.Default.nudBuy.Value = Types.Shop[E_Globals.Editorindex].BuyRate;
			}
			else
			{
				frmShop.Default.nudBuy.Value = 100;
			}
			
			frmShop.Default.nudFace.Value = Types.Shop[E_Globals.Editorindex].Face;
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Faces\\" + System.Convert.ToString(Types.Shop[E_Globals.Editorindex].Face) + E_Globals.GFX_EXT))
			{
				frmShop.Default.picFace.BackgroundImage = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "Faces\\" + System.Convert.ToString(Types.Shop[E_Globals.Editorindex].Face) + E_Globals.GFX_EXT);
			}
			
			frmShop.Default.cmbItem.Items.Clear();
			frmShop.Default.cmbItem.Items.Add("None");
			frmShop.Default.cmbCostItem.Items.Clear();
			frmShop.Default.cmbCostItem.Items.Add("None");
			
			for (i = 1; i <= Constants.MAX_ITEMS; i++)
			{
                if (Types.Item[i].Name == null)
                {
                    Types.Item[i].Name = "";
                }
                frmShop.Default.cmbItem.Items.Add(i + ": " + Types.Item[i].Name.Trim());
				frmShop.Default.cmbCostItem.Items.Add(i + ": " + Types.Item[i].Name.Trim());
			}
			
			frmShop.Default.cmbItem.SelectedIndex = 0;
			frmShop.Default.cmbCostItem.SelectedIndex = 0;
			
			UpdateShopTrade();
			
			E_Globals.Shop_Changed[E_Globals.Editorindex] = true;
		}
		
		internal static void UpdateShopTrade()
		{
			int i = 0;
			frmShop.Default.lstTradeItem.Items.Clear();
			
			for (i = 1; i <= Constants.MAX_TRADES; i++)
			{
				// if none, show as none
				if (Types.Shop[E_Globals.Editorindex].TradeItem[i].Item == 0 && Types.Shop[E_Globals.Editorindex].TradeItem[i].CostItem == 0)
				{
					frmShop.Default.lstTradeItem.Items.Add("Empty Trade Slot");
				}
				else
				{
					frmShop.Default.lstTradeItem.Items.Add(i + ": " + System.Convert.ToString(Types.Shop[E_Globals.Editorindex].TradeItem[i].ItemValue) + "x " + Types.Item[Types.Shop[E_Globals.Editorindex].TradeItem[i].Item].Name.Trim() + " for " + System.Convert.ToString(Types.Shop[E_Globals.Editorindex].TradeItem[i].CostValue) + "x " + Types.Item[Types.Shop[E_Globals.Editorindex].TradeItem[i].CostItem].Name.Trim());
				}
			}
			
			frmShop.Default.lstTradeItem.SelectedIndex = 0;
		}
		
		internal static void ShopEditorOk()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_SHOPS; i++)
			{
				if (E_Globals.Shop_Changed[i])
				{
					E_NetworkSend.SendSaveShop(i);
				}
			}
			
			frmShop.Default.Visible = false;
			E_Globals.Editor = (byte) 0;
			ClearChanged_Shop();
		}
		
		internal static void ShopEditorCancel()
		{
			E_Globals.Editor = (byte) 0;
			frmShop.Default.Visible = false;
			ClearChanged_Shop();
			ClientDataBase.ClearShops();
			E_NetworkSend.SendRequestShops();
		}
		
		internal static void ClearChanged_Shop()
		{
			for (var i = 1; i <= Constants.MAX_SHOPS; i++)
			{
				E_Globals.Shop_Changed[(int) i] = false;
			}
		}
		
#endregion
		
#region Class Editor
		
		internal static void ClassesEditorOk()
		{
			E_NetworkSend.SendSaveClasses();
			
			frmClasses.Default.Visible = false;
			E_Globals.Editor = (byte) 0;
		}
		
		internal static void ClassesEditorCancel()
		{
			E_NetworkSend.SendRequestClasses();
			frmClasses.Default.Visible = false;
			E_Globals.Editor = (byte) 0;
		}
		
		internal static void ClassEditorInit()
		{
			int i = 0;
			
			frmClasses.Default.lstIndex.Items.Clear();
			
			for (i = 1; i <= E_Globals.Max_Classes; i++)
			{
                if(Types.Classes[i].Name == null)
                {
                    Types.Classes[i].Name = "";
                }
				frmClasses.Default.lstIndex.Items.Add(Types.Classes[i].Name.Trim());
			}
			
			E_Globals.Editor = E_Globals.EDITOR_CLASSES;
			
			frmClasses.Default.nudMaleSprite.Maximum = E_Graphics.NumCharacters;
			frmClasses.Default.nudFemaleSprite.Maximum = E_Graphics.NumCharacters;
			
			frmClasses.Default.cmbItems.Items.Clear();
			
			frmClasses.Default.cmbItems.Items.Add("None");
			for (i = 1; i <= Constants.MAX_ITEMS; i++)
			{
                if (Types.Item[i].Name == null)
                {
                    Types.Item[i].Name = "";
                }
                frmClasses.Default.cmbItems.Items.Add(Types.Item[i].Name.Trim());
			}
			
			//frmClasses.Default.lstIndex.SelectedIndex = 0;
			frmClasses.Default.lstIndex.SelectedIndex = -1; // Fixed Crash when no Classes?
			
			frmClasses.Default.Visible = true;
		}
		
		internal static void LoadClass()
		{
			int i = 0;
			
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			frmClasses.Default.txtName.Text = Types.Classes[E_Globals.Editorindex].Name;
			frmClasses.Default.txtDescription.Text = Types.Classes[E_Globals.Editorindex].Desc;
			
			frmClasses.Default.cmbMaleSprite.Items.Clear();

            if (Types.Classes[E_Globals.Editorindex].MaleSprite == null)
            {
                Types.Classes[E_Globals.Editorindex].MaleSprite = new int[1];
            }
            for (i = 0; i <= (Types.Classes[E_Globals.Editorindex].MaleSprite.Length - 1); i++)
			{
				frmClasses.Default.cmbMaleSprite.Items.Add("Sprite " + System.Convert.ToString(i + 1));
			}
			
			frmClasses.Default.cmbFemaleSprite.Items.Clear();

            if (Types.Classes[E_Globals.Editorindex].FemaleSprite == null)
            {
                Types.Classes[E_Globals.Editorindex].FemaleSprite = new int[1];
            }
            for (i = 0; i <= (Types.Classes[E_Globals.Editorindex].FemaleSprite.Length - 1); i++)
			{
				frmClasses.Default.cmbFemaleSprite.Items.Add("Sprite " + System.Convert.ToString(i + 1));
			}
			
			frmClasses.Default.nudMaleSprite.Value = System.Convert.ToDecimal(Types.Classes[E_Globals.Editorindex].MaleSprite[0]);
			frmClasses.Default.nudFemaleSprite.Value = System.Convert.ToDecimal(Types.Classes[E_Globals.Editorindex].FemaleSprite[0]);
			
			frmClasses.Default.cmbMaleSprite.SelectedIndex = 0;
			frmClasses.Default.cmbFemaleSprite.SelectedIndex = 0;
			
			frmClasses.Default.DrawPreview();
			
			for (i = 1; i <= (int) Enums.StatType.Count - 1; i++)
			{
				if (Types.Classes[E_Globals.Editorindex].Stat[i] == 0)
				{
					Types.Classes[E_Globals.Editorindex].Stat[i] = 1;
				}
			}
			
			frmClasses.Default.nudStrength.Value = System.Convert.ToDecimal(Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Strength]);
			frmClasses.Default.nudLuck.Value = System.Convert.ToDecimal(Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Luck]);
			frmClasses.Default.nudEndurance.Value = System.Convert.ToDecimal(Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Endurance]);
			frmClasses.Default.nudIntelligence.Value = System.Convert.ToDecimal(Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Intelligence]);
			frmClasses.Default.nudVitality.Value = System.Convert.ToDecimal(Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Vitality]);
			frmClasses.Default.nudSpirit.Value = System.Convert.ToDecimal(Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Spirit]);
			
			if (Types.Classes[E_Globals.Editorindex].BaseExp < 10)
			{
				frmClasses.Default.nudBaseExp.Value = 10;
			}
			else
			{
				frmClasses.Default.nudBaseExp.Value = Types.Classes[E_Globals.Editorindex].BaseExp;
			}
			
			frmClasses.Default.lstStartItems.Items.Clear();
			
			for (i = 1; i <= 5; i++)
			{
				if (Types.Classes[E_Globals.Editorindex].StartItem[i] > 0)
				{
					frmClasses.Default.lstStartItems.Items.Add(Types.Item[Types.Classes[E_Globals.Editorindex].StartItem[i]].Name + " X " + Types.Classes[E_Globals.Editorindex].StartValue[i]);
				}
				else
				{
					frmClasses.Default.lstStartItems.Items.Add("None");
				}
			}
			
			frmClasses.Default.nudStartMap.Value = Types.Classes[E_Globals.Editorindex].StartMap;
			frmClasses.Default.nudStartX.Value = Types.Classes[E_Globals.Editorindex].StartX;
			frmClasses.Default.nudStartY.Value = Types.Classes[E_Globals.Editorindex].StartY;
		}
		
#endregion
		
	}
}
