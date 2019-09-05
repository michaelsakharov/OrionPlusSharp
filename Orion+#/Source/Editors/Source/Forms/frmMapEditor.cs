using System.Collections.Generic;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using System.ComponentModel;

namespace Engine
{
	
	public partial class frmMapEditor
	{
		public frmMapEditor()
		{
			InitializeComponent();

            this.MouseWheel += ScrlMapViewH_MouseWheel;

            if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmMapEditor defaultInstance;
		
		public static frmMapEditor Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmMapEditor();
					defaultInstance.FormClosed += new System.Windows.Forms.FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
			set
			{
				defaultInstance = value;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            E_Sound.StopMusic();
            E_Sound.StopPreview();
            defaultInstance = null;
		}
		
#endregion
		
#region Form Code
		
		public void FrmEditor_Map_Load(object sender, EventArgs e)
		{
			cmbTileSets.SelectedIndex = 0;
			pnlAttributes.BringToFront();
			pnlAttributes.Visible = false;
			pnlTiles.BringToFront();
			pnlTiles.Visible = true;
			optBlocked.Checked = true;
			E_Globals.SelectedTab = (byte) 1;
			
			nudFog.Maximum = E_Graphics.NumFogs;
			
			picScreen.Width = (E_Types.Map.MaxX * E_Globals.PIC_X) + E_Globals.PIC_X;
			picScreen.Height = (E_Types.Map.MaxY * E_Globals.PIC_Y) + E_Globals.PIC_Y;
			
			scrlMapViewH.Maximum = (int)((E_Types.Map.MaxX / E_Globals.PIC_X) + E_Globals.PIC_X);
			scrlMapViewV.Maximum = (int)((E_Types.Map.MaxY / E_Globals.PIC_Y) + E_Globals.PIC_Y);
			
			E_Graphics.GameWindow.SetView(new SFML.Graphics.View(new SFML.Graphics.FloatRect(0, 0, picScreen.Width, picScreen.Height)));
			E_Graphics.TilesetWindow.SetView(new SFML.Graphics.View(new SFML.Graphics.FloatRect(0, 0, picBackSelect.Width, picBackSelect.Height)));
			
			picScreen.Focus();

            this.WindowState = FormWindowState.Maximized;
			
		}
		
		public void FrmEditor_MapEditor_Resize(object sender, EventArgs e)
		{
			if (ReferenceEquals(E_Graphics.GameWindow, null))
			{
				return;
			}
			
			picScreen.Width = (E_Types.Map.MaxX * E_Globals.PIC_X) + E_Globals.PIC_X;
			picScreen.Height = (E_Types.Map.MaxY * E_Globals.PIC_Y) + E_Globals.PIC_Y;
			
			// set the scrollbars
			scrlMapViewH.Maximum = (int)((E_Types.Map.MaxX / E_Globals.PIC_X) + E_Globals.PIC_X);
			scrlMapViewV.Maximum = (int)((E_Types.Map.MaxY / E_Globals.PIC_Y) + E_Globals.PIC_Y);
			
			E_Graphics.GameWindow.SetView(new SFML.Graphics.View(new SFML.Graphics.FloatRect(0, 0, picScreen.Width, picScreen.Height)));
			
		}
		
		public void FrmEditor_MapEditor_Closing(object sender, CancelEventArgs e)
        {
            E_Sound.StopMusic();
            E_Sound.StopPreview();
            E_Editors.MapEditorCancel();
		}
		
		public void FrmEditor_MapEditor_Closed(object sender, EventArgs e)
        {
            E_Sound.StopMusic();
            E_Sound.StopPreview();
            E_Editors.MapEditorCancel();
		}
		
		public void PicBackSelect_MouseDown(object sender, MouseEventArgs e)
		{
			E_Editors.MapEditorChooseTile((int)e.Button, e.X, e.Y);
        }

        public void picBackSelect_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        public void PicBackSelect_MouseMove(object sender, MouseEventArgs e)
		{
            E_Editors.MapEditorDrag((int)e.Button, e.X, e.Y);
		}
		
		public void PicBackSelect_Paint(object sender, PaintEventArgs e)
		{
			//Overrides the paint sub
		}
		
		public void PnlBack_Paint(object sender, PaintEventArgs e)
		{
			//Overrides the paint sub
		}
		
		public void PnlBack2_Paint(object sender, PaintEventArgs e)
		{
			//Overrides the paint sub
		}
		
		public void ScrlPictureY_Scroll(object sender, EventArgs e)
		{
			E_Editors.MapEditorTileScroll();
		}
		
		public void ScrlPictureX_Scroll(object sender, EventArgs e)
		{
			E_Editors.MapEditorTileScroll();
		}
		
		public void CmbTileSets_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbTileSets.SelectedIndex + 1 > E_Graphics.NumTileSets)
			{
				cmbTileSets.SelectedIndex = 0;
			}
			
			E_Types.Map.tileset = cmbTileSets.SelectedIndex + 1;
			
			E_Globals.EditorTileSelStart = new Point(1, 1);
			E_Globals.EditorTileSelEnd = new Point(2, 2);
			
			//EditorMap_DrawTileset2()
			
			//pnlBack.Refresh()
			
			picBackSelect.Height = E_Graphics.TileSetTextureInfo[cmbTileSets.SelectedIndex + 1].height;
			picBackSelect.Width = E_Graphics.TileSetTextureInfo[cmbTileSets.SelectedIndex + 1].width;
			
			scrlPictureY.Maximum = ((picBackSelect.Height / E_Globals.PIC_Y) + E_Globals.PIC_Y);
			scrlPictureX.Maximum = ((picBackSelect.Width / E_Globals.PIC_X) + E_Globals.PIC_X);
		}
		
		public void CmbAutoTile_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cmbAutoTile.SelectedIndex == 0)
			{
				E_Globals.EditorTileWidth = 1;
				E_Globals.EditorTileHeight = 1;
			}
		}
		
		public void BtnTiles_Click(object sender, EventArgs e)
		{
			E_Globals.SelectedTab = (byte) 1;
			
			pnlTiles.Visible = true;
			
			pnlAttribute.Visible = false;
			pnlNpc.Visible = false;
			pnlDirBlock.Visible = false;
			pnlEvents.Visible = false;
		}
		
		public void BtnAttributes_Click(object sender, EventArgs e)
		{
			E_Globals.SelectedTab = (byte) 2;
			
			pnlAttribute.Visible = true;
			
			pnlTiles.Visible = false;
			pnlNpc.Visible = false;
			pnlDirBlock.Visible = false;
			pnlEvents.Visible = false;
		}
		
		public void BtnNpc_Click(object sender, EventArgs e)
		{
			E_Globals.SelectedTab = (byte) 3;
			
			pnlNpc.Visible = true;
			
			pnlTiles.Visible = false;
			pnlAttribute.Visible = false;
			pnlDirBlock.Visible = false;
			pnlEvents.Visible = false;
		}
		
		public void BtnDirBlock_Click(object sender, EventArgs e)
		{
			E_Globals.SelectedTab = (byte) 4;
			
			pnlDirBlock.Visible = true;
			
			pnlTiles.Visible = false;
			pnlNpc.Visible = false;
			pnlAttribute.Visible = false;
			pnlEvents.Visible = false;
		}
		
		public void BtnEvents_Click(object sender, EventArgs e)
		{
			E_Globals.SelectedTab = (byte) 5;
			
			pnlEvents.Visible = true;
			
			pnlTiles.Visible = false;
			pnlAttribute.Visible = false;
			pnlNpc.Visible = false;
			pnlDirBlock.Visible = false;
			
		}
		
#endregion
		
#region Toolbar
		
		public void TsbSave_Click(object sender, EventArgs e)
		{
            E_Sound.StopMusic();
            E_Sound.StopPreview();
            E_Globals.HideCursor = true;
			E_Globals.ScreenShotTimer = (ClientDataBase.GetTickCount() + 500);
			E_Globals.MakeCache = true;
		}
		
		public void TsbDiscard_Click(object sender, EventArgs e)
        {
            E_Sound.StopMusic();
            E_Sound.StopPreview();
            E_Editors.MapEditorCancel();
		}
		
		public void TsbMapGrid_Click(object sender, EventArgs e)
		{
			E_Globals.MapGrid = !E_Globals.MapGrid;
		}
		
		public void TsbFill_Click(object sender, EventArgs e)
		{
			E_Editors.MapEditorFillLayer((byte) cmbAutoTile.SelectedIndex);
		}
		
		public void TsbClear_Click(object sender, EventArgs e)
		{
			E_Editors.MapEditorClearLayer();
		}
		
		public void CmbMapList_SelectedIndexChanged(object sender, EventArgs e)
		{
			E_NetworkSend.SendEditorRequestMap(cmbMapList.SelectedIndex + 1);
		}
		
		public void TsbScreenShot_Click(object sender, EventArgs e)
		{
			E_Globals.HideCursor = true;
			E_Globals.ScreenShotTimer = (ClientDataBase.GetTickCount() + 1000);
			E_Globals.TakeScreenShot = true;
		}
		
#endregion
		
#region PicScreen
		
		public void Picscreen_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.X > pnlBack2.Width - 32 || e.Y > pnlBack2.Height - 32)
			{
				return;
			}
			E_Editors.MapEditorMouseDown((int) e.Button, e.X, e.Y, false);
			
		}
		
		public void Picscreen_Paint(object sender, PaintEventArgs e)
		{
			//This is here to make sure that the box dosen't try to re-paint itself... saves time and w/e else
			return;
		}
		
		public void Picscreen_MouseMove(object sender, MouseEventArgs e)
		{
			
			E_Globals.CurX = E_Globals.TileView.Left + ((e.Location.X + E_Globals.Camera.Left) / E_Globals.PIC_X);
			E_Globals.CurY = E_Globals.TileView.Top + ((e.Location.Y + E_Globals.Camera.Top) / E_Globals.PIC_Y);
			
			E_Globals.CurMouseX = e.Location.X;
			E_Globals.CurMouseY = e.Location.Y;
			
			if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
			{
				E_Editors.MapEditorMouseDown((int) e.Button, e.X, e.Y);
			}
			
			tslCurXY.Text = "X: " + E_Globals.CurX.ToString() + " - " + " Y: " + E_Globals.CurY.ToString();
		}
		
		public void Picscreen_MouseUp(object sender, MouseEventArgs e)
		{

            // do a re-init so we can see our changes
            E_AutoTiles.InitAutotiles();

            E_Globals.CurX = E_Globals.TileView.Left + ((e.Location.X + E_Globals.Camera.Left) / E_Globals.PIC_X);
			E_Globals.CurY = E_Globals.TileView.Top + ((e.Location.Y + E_Globals.Camera.Top) / E_Globals.PIC_Y);
			
		}
		
#endregion
		
#region Attributes
		
		public void LblVisualWarp_Click(object sender, EventArgs e)
		{
			fraMapWarp.Visible = false;
			FrmVisualWarp.Default.Visible = true;
		}
		
		public void ScrlMapWarpMap_Scroll(object sender, ScrollEventArgs e)
		{
			lblMapWarpMap.Text = "Map: " + scrlMapWarpMap.Value.ToString();
		}
		
		public void ScrlMapWarpX_Scroll(object sender, ScrollEventArgs e)
		{
			lblMapWarpX.Text = "X: " + scrlMapWarpX.Value.ToString();
		}
		
		public void ScrlMapWarpY_Scroll(object sender, ScrollEventArgs e)
		{
			lblMapWarpY.Text = "Y: " + scrlMapWarpY.Value.ToString();
		}
		
		public void BtnMapWarp_Click(object sender, EventArgs e)
		{
			E_Globals.EditorWarpMap = scrlMapWarpMap.Value;
			
			E_Globals.EditorWarpX = scrlMapWarpX.Value;
			E_Globals.EditorWarpY = scrlMapWarpY.Value;
			pnlAttributes.Visible = false;
			fraMapWarp.Visible = false;
		}
		
		public void OptWarp_CheckedChanged(object sender, EventArgs e)
		{
			
			if (optWarp.Checked == true)
			{
				E_Editors.ClearAttributeDialogue();
				fraMapWarp.Visible = true;
				//FrmVisualWarp.Visible = True
			}
			
		}
		
		public void ScrlMapItem_Scroll(object sender, ScrollEventArgs e)
		{
			if (Types.Item[scrlMapItem.Value].Type == (byte)Enums.ItemType.Currency || Types.Item[scrlMapItem.Value].Stackable == 1)
			{
				scrlMapItemValue.Enabled = true;
			}
			else
			{
				scrlMapItemValue.Value = 1;
				scrlMapItemValue.Enabled = false;
			}
			
			E_Graphics.EditorMap_DrawMapItem();
			lblMapItem.Text = "Item: " + scrlMapItem.Value.ToString() +". " + Types.Item[scrlMapItem.Value].Name.Trim() + " x" + scrlMapItemValue.Value.ToString();
		}
		
		public void ScrlMapItemValue_Scroll(object sender, ScrollEventArgs e)
		{
			lblMapItem.Text = Types.Item[scrlMapItem.Value].Name.Trim() + " x" + scrlMapItemValue.Value.ToString();
		}
		
		public void BtnMapItem_Click(object sender, EventArgs e)
		{
			E_Globals.ItemEditorNum = scrlMapItem.Value;
			E_Globals.ItemEditorValue = scrlMapItemValue.Value;
			pnlAttributes.Visible = false;
			fraMapItem.Visible = false;
		}
		
		public void OptItem_CheckedChanged(object sender, EventArgs e)
		{
			E_Editors.ClearAttributeDialogue();
			pnlAttributes.Visible = true;
			fraMapItem.Visible = true;
			
			scrlMapItem.Maximum = Constants.MAX_ITEMS;
			scrlMapItem.Value = 1;
			lblMapItem.Text = Types.Item[scrlMapItem.Value].Name.Trim() + " x" + scrlMapItemValue.Value.ToString();
			E_Graphics.EditorMap_DrawMapItem();
		}
		
		public void ScrlMapKey_Scroll(object sender, ScrollEventArgs e)
		{
			lblMapKey.Text = "Item: " + Types.Item[scrlMapKey.Value].Name.Trim();
			E_Graphics.EditorMap_DrawKey();
		}
		
		public void BtnMapKey_Click(object sender, EventArgs e)
		{
			E_Globals.KeyEditorNum = scrlMapKey.Value;
			E_Globals.KeyEditorTake = Convert.ToInt32(chkMapKey.Checked);
			pnlAttributes.Visible = false;
			fraMapKey.Visible = false;
		}
		
		public void OptKey_CheckedChanged(object sender, EventArgs e)
		{
			E_Editors.ClearAttributeDialogue();
			pnlAttributes.Visible = true;
			fraMapKey.Visible = true;
			
			scrlMapKey.Maximum = Constants.MAX_ITEMS;
			scrlMapKey.Value = 1;
			chkMapKey.Checked = true;
			E_Graphics.EditorMap_DrawKey();
			lblMapKey.Text = "Item: " + Types.Item[scrlMapKey.Value].Name.Trim();
		}
		
		public void ScrlKeyX_Scroll(object sender, ScrollEventArgs e)
		{
			lblKeyX.Text = "X: " + scrlKeyX.Value.ToString();
		}
		
		public void ScrlKeyY_Scroll(object sender, ScrollEventArgs e)
		{
			lblKeyY.Text = "X: " + scrlKeyY.Value.ToString();
		}
		
		public void BtnMapKeyOpen_Click(object sender, EventArgs e)
		{
			E_Globals.KeyOpenEditorX = scrlKeyX.Value;
			E_Globals.KeyOpenEditorY = scrlKeyY.Value;
			pnlAttributes.Visible = false;
			fraKeyOpen.Visible = false;
		}
		
		public void OptKeyOpen_CheckedChanged(object sender, EventArgs e)
		{
			E_Editors.ClearAttributeDialogue();
			fraKeyOpen.Visible = true;
			pnlAttributes.Visible = true;
			
			scrlKeyX.Maximum = E_Types.Map.MaxX;
			scrlKeyY.Maximum = E_Types.Map.MaxY;
			scrlKeyX.Value = 0;
			scrlKeyY.Value = 0;
		}
		
		public void BtnResourceOk_Click(object sender, EventArgs e)
		{
			E_Globals.ResourceEditorNum = scrlResource.Value;
			pnlAttributes.Visible = false;
			fraResource.Visible = false;
		}
		
		public void ScrlResource_Scroll(object sender, ScrollEventArgs e)
		{
			lblResource.Text = "Resource: " + Types.Resource[scrlResource.Value].Name;
		}
		
		public void OptResource_CheckedChanged(object sender, EventArgs e)
		{
			E_Editors.ClearAttributeDialogue();
			pnlAttributes.Visible = true;
			fraResource.Visible = true;
		}
		
		public void BtnNpcSpawn_Click(object sender, EventArgs e)
		{
			E_Globals.SpawnNpcNum = lstNpc.SelectedIndex + 1;
			E_Globals.SpawnNpcDir = (byte) scrlNpcDir.Value;
			pnlAttributes.Visible = false;
			fraNpcSpawn.Visible = false;
		}
		
		public void OptNPCSpawn_CheckedChanged(object sender, EventArgs e)
		{
			int n = 0;
			
			lstNpc.Items.Clear();
			
			for (n = 1; n <= Constants.MAX_MAP_NPCS; n++)
			{
				if (E_Types.Map.Npc[n] > 0)
				{
                    if(Types.Npc[E_Types.Map.Npc[n]].Name != null)
                    {
                        lstNpc.Items.Add(n + ": " + Types.Npc[E_Types.Map.Npc[n]].Name);
                    }
                    else
                    {
                        lstNpc.Items.Add(n + ": " + "Null");
                    }
				}
				else
				{
					lstNpc.Items.Add(n + ": No Npc");
				}
			}
			
			scrlNpcDir.Value = 0;
			lstNpc.SelectedIndex = 0;
			
			E_Editors.ClearAttributeDialogue();
			pnlAttributes.Visible = true;
			fraNpcSpawn.Visible = true;
		}
		
		public void BtnShop_Click(object sender, EventArgs e)
		{
			E_Globals.EditorShop = cmbShop.SelectedIndex;
			pnlAttributes.Visible = false;
			fraShop.Visible = false;
		}
		
		public void OptShop_CheckedChanged(object sender, EventArgs e)
		{
			E_Editors.ClearAttributeDialogue();
			pnlAttributes.Visible = true;
			fraShop.Visible = true;
		}
		
		public void BtnHeal_Click(object sender, EventArgs e)
		{
			E_Globals.MapEditorHealType = cmbHeal.SelectedIndex + 1;
			E_Globals.MapEditorHealAmount = scrlHeal.Value;
			pnlAttributes.Visible = false;
			fraHeal.Visible = false;
		}
		
		public void ScrlHeal_Scroll(object sender, ScrollEventArgs e)
		{
			lblHeal.Text = "Amount: " + scrlHeal.Value.ToString();
		}
		
		public void OptHeal_CheckedChanged(object sender, EventArgs e)
		{
			E_Editors.ClearAttributeDialogue();
			pnlAttributes.Visible = true;
			fraHeal.Visible = true;
		}
		
		public void ScrlTrap_Scroll(object sender, ScrollEventArgs e)
		{
			lblTrap.Text = "Amount: " + scrlTrap.Value.ToString();
		}
		
		public void BtnTrap_Click(object sender, EventArgs e)
		{
			E_Globals.MapEditorHealAmount = scrlTrap.Value;
			pnlAttributes.Visible = false;
			fraTrap.Visible = false;
		}
		
		public void OptTrap_CheckedChanged(object sender, EventArgs e)
		{
			E_Editors.ClearAttributeDialogue();
			pnlAttributes.Visible = true;
			fraTrap.Visible = true;
		}
		
		public void BtnClearAttribute_Click(object sender, EventArgs e)
		{
			E_Editors.MapEditorClearAttribs();
		}
		
		public void ScrlNpcDir_Scroll(object sender, ScrollEventArgs e)
		{
			switch (scrlNpcDir.Value)
			{
				case 0:
					lblNpcDir.Text = "Direction: Up";
					break;
				case 1:
					lblNpcDir.Text = "Direction: Down";
					break;
				case 2:
					lblNpcDir.Text = "Direction: Left";
					break;
				case 3:
					lblNpcDir.Text = "Direction: Right";
					break;
			}
		}
		
		public void OptBlocked_CheckedChanged(object sender, EventArgs e)
		{
			if (optBlocked.Checked)
			{
				pnlAttributes.Visible = false;
			}
		}
		
		public void OptHouse_CheckedChanged(object sender, EventArgs e)
		{
			E_Editors.ClearAttributeDialogue();
			pnlAttributes.Visible = true;
			fraBuyHouse.Visible = true;
			scrlBuyHouse.Maximum = E_Housing.MAX_HOUSES;
			scrlBuyHouse.Value = 1;
		}
		
		public void ScrlBuyHouse_Scroll(object sender, ScrollEventArgs e)
		{
			lblHouseName.Text = scrlBuyHouse.Value + ". " + E_Housing.HouseConfig[scrlBuyHouse.Value].ConfigName;
		}
		
		public void BtnHouseTileOk_Click(object sender, EventArgs e)
		{
			E_Housing.HouseTileindex = scrlBuyHouse.Value;
			pnlAttributes.Visible = false;
			fraBuyHouse.Visible = false;
		}
		
#endregion
		
#region Map Settings
		
		public void TxtName_TextChanged(object sender, EventArgs e)
		{
			E_Types.Map.Name = txtName.Text.Trim();
		}
		
		public void CmbMoral_SelectedIndexChanged(object sender, EventArgs e)
		{
			E_Types.Map.Moral = (byte) cmbMoral.SelectedIndex;
		}
		
		public void NudLeft_ValueChanged(object sender, EventArgs e)
		{
			E_Types.Map.Left = (int) nudLeft.Value;
		}
		
		public void NudRight_ValueChanged(object sender, EventArgs e)
		{
			E_Types.Map.Right = (int) nudRight.Value;
		}
		
		public void NudUp_ValueChanged(object sender, EventArgs e)
		{
			E_Types.Map.Up = (int) nudUp.Value;
		}
		
		public void NudDown_ValueChanged(object sender, EventArgs e)
		{
			E_Types.Map.Down = (int) nudDown.Value;
		}
		
		public void TxtBootMap_TextChanged(object sender, EventArgs e)
		{
			E_Types.Map.BootMap = (int) nudSpawnMap.Value;
		}
		
		public void TxtBootX_TextChanged(object sender, EventArgs e)
		{
			E_Types.Map.BootX = (byte) nudSpawnX.Value;
		}
		
		public void TxtBootY_TextChanged(object sender, EventArgs e)
		{
			E_Types.Map.BootY = (byte) nudSpawnY.Value;
		}
		
		public void BtnPreview_Click(object sender, EventArgs e)
		{
			if (ReferenceEquals(E_Sound.PreviewPlayer, null))
			{
				if (lstMusic.SelectedIndex >= 0)
				{
					E_Sound.StopMusic();
					E_Sound.PlayPreview(lstMusic.Items[lstMusic.SelectedIndex].ToString());
				}
			}
			else
			{
				E_Sound.StopPreview();
				E_Sound.PlayMusic(E_Types.Map.Music);
			}
		}
		
		public void CmbWeather_SelectedIndexChanged(object sender, EventArgs e)
		{
			E_Types.Map.WeatherType = (byte) cmbWeather.SelectedIndex;
			E_Globals.CurrentWeather = cmbWeather.SelectedIndex;
		}
		
		public void ScrlFog_Scroll(object sender, EventArgs e)
		{
			E_Types.Map.Fogindex = (int) nudFog.Value;
			E_Globals.CurrentFog = (int) nudFog.Value;
		}
		
		public void ScrlIntensity_Scroll(object sender, EventArgs e)
		{
			E_Types.Map.WeatherIntensity = (int) nudIntensity.Value;
			E_Globals.CurrentWeatherIntensity = (int) nudIntensity.Value;
		}

        public void ScrlBrightness_Scroll(object sender, EventArgs e)
		{
			E_Types.Map.Brightness = (byte)nudBrightness.Value;
			E_Globals.CurrentBrightness = (int)nudBrightness.Value;
		}
		
		public void ScrlFogSpeed_Scroll(object sender, EventArgs e)
		{
			E_Types.Map.FogSpeed = (byte) nudFogSpeed.Value;
			E_Globals.CurrentFogSpeed = (int) nudFogSpeed.Value;
		}
		
		public void ScrlFogAlpha_Scroll(object sender, EventArgs e)
		{
			E_Types.Map.FogAlpha = (byte) nudFogAlpha.Value;
			E_Globals.CurrentFogOpacity = (int) nudFogAlpha.Value;
		}
		
		public void ChkUseTint_CheckedChanged(object sender, EventArgs e)
		{
			if (chkUseTint.Checked == true)
			{
				E_Types.Map.HasMapTint = (byte) 1;
			}
			else
			{
				E_Types.Map.HasMapTint = (byte) 0;
			}
		}
		
		public void ScrlMapRed_Scroll(object sender, EventArgs e)
		{
			E_Types.Map.MapTintR = (byte) nudMapRed.Value;
			E_Globals.CurrentTintR = (int) nudMapRed.Value;
		}
		
		public void ScrlMapGreen_Scroll(object sender, EventArgs e)
		{
			E_Types.Map.MapTintG = (byte) nudMapGreen.Value;
			E_Globals.CurrentTintG = (int) nudMapGreen.Value;
		}
		
		public void ScrlMapBlue_Scroll(object sender, EventArgs e)
		{
			E_Types.Map.MapTintB = (byte) nudMapBlue.Value;
			E_Globals.CurrentTintB = (int) nudMapBlue.Value;
		}
		
		public void ScrlMapAlpha_Scroll(object sender, EventArgs e)
		{
			E_Types.Map.MapTintA = (byte) nudMapAlpha.Value;
			E_Globals.CurrentTintA = (int) nudMapAlpha.Value;
		}
		
		public void BtnSetSize_Click(object sender, EventArgs e)
		{
			int X = 0;
			int x2 = 0;
			int i = 0;
			int Y = 0;
			int y2 = 0;
			Types.TileRec[,] tempArr;
			
			if (nudMaxX.Value < E_Globals.SCREEN_MAPX)
			{
				nudMaxX.Value = E_Globals.SCREEN_MAPX;
			}
			if (nudMaxY.Value < E_Globals.SCREEN_MAPY)
			{
				nudMaxY.Value = E_Globals.SCREEN_MAPY;
			}
			
			E_Globals.GettingMap = true;
			
			// set the data before changing it
			tempArr = new Types.TileRec[E_Types.Map.MaxX + 1, E_Types.Map.MaxY + 1];
			for (X = 0; X <= E_Types.Map.MaxX; X++)
			{
				for (Y = 0; Y <= E_Types.Map.MaxY; Y++)
				{
					tempArr[X, Y].Layer = new Types.TileDataRec[(int) Enums.LayerType.Count];
					
					tempArr[X, Y].Data1 = E_Types.Map.Tile[X, Y].Data1;
					tempArr[X, Y].Data2 = E_Types.Map.Tile[X, Y].Data2;
					tempArr[X, Y].Data3 = E_Types.Map.Tile[X, Y].Data3;
					tempArr[X, Y].DirBlock = E_Types.Map.Tile[X, Y].DirBlock;
					tempArr[X, Y].Type = E_Types.Map.Tile[X, Y].Type;
					
					for (i = 1; i <= (int) Enums.LayerType.Count - 1; i++)
					{
						tempArr[X, Y].Layer[i].AutoTile = E_Types.Map.Tile[X, Y].Layer[i].AutoTile;
						tempArr[X, Y].Layer[i].Tileset = E_Types.Map.Tile[X, Y].Layer[i].Tileset;
						tempArr[X, Y].Layer[i].X = E_Types.Map.Tile[X, Y].Layer[i].X;
						tempArr[X, Y].Layer[i].Y = E_Types.Map.Tile[X, Y].Layer[i].Y;
					}
				}
			}
			
			x2 = E_Types.Map.MaxX;
			y2 = E_Types.Map.MaxY;
			// change the data
			E_Types.Map.MaxX = (byte) nudMaxX.Value;
			E_Types.Map.MaxY = (byte) nudMaxY.Value;
			
			E_Types.Map.Tile = new Types.TileRec[E_Types.Map.MaxX + 1, E_Types.Map.MaxY + 1];
			E_AutoTiles.Autotile = new E_AutoTiles.AutotileRec[E_Types.Map.MaxX + 1, E_Types.Map.MaxY + 1];
			
			if (x2 > E_Types.Map.MaxX)
			{
				x2 = E_Types.Map.MaxX;
			}
			if (y2 > E_Types.Map.MaxY)
			{
				y2 = E_Types.Map.MaxY;
			}
			
			for (X = 0; X <= E_Types.Map.MaxX; X++)
			{
				for (Y = 0; Y <= E_Types.Map.MaxY; Y++)
				{
					Array.Resize(ref E_Types.Map.Tile[X, Y].Layer, (int) Enums.LayerType.Count);
					
					Array.Resize(ref E_AutoTiles.Autotile[X, Y].Layer, (int) Enums.LayerType.Count);
					
					if (X <= x2)
					{
						if (Y <= y2)
						{
							E_Types.Map.Tile[X, Y].Data1 = tempArr[X, Y].Data1;
							E_Types.Map.Tile[X, Y].Data2 = tempArr[X, Y].Data2;
							E_Types.Map.Tile[X, Y].Data3 = tempArr[X, Y].Data3;
							E_Types.Map.Tile[X, Y].DirBlock = tempArr[X, Y].DirBlock;
							E_Types.Map.Tile[X, Y].Type = tempArr[X, Y].Type;
							
							for (i = 1; i <= (int) Enums.LayerType.Count - 1; i++)
							{
								E_Types.Map.Tile[X, Y].Layer[i].AutoTile = tempArr[X, Y].Layer[i].AutoTile;
								E_Types.Map.Tile[X, Y].Layer[i].Tileset = tempArr[X, Y].Layer[i].Tileset;
								E_Types.Map.Tile[X, Y].Layer[i].X = tempArr[X, Y].Layer[i].X;
								E_Types.Map.Tile[X, Y].Layer[i].Y = tempArr[X, Y].Layer[i].Y;
							}
						}
					}
				}
			}
			E_AutoTiles.InitAutotiles();
			ClientDataBase.ClearTempTile();
			//MapEditorSend()
			
			E_Globals.GettingMap = false;
		}
		
		public void ScrlMapViewH_Scroll(object sender, EventArgs e)
		{
			E_Globals.EditorViewX = scrlMapViewH.Value;
		}
		
		public void ScrlMapViewV_Scroll(object sender, EventArgs e)
		{
			E_Globals.EditorViewY = scrlMapViewV.Value;
		}
		
        public void ScrlMapViewH_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys != Keys.Shift)
            {
                E_Globals.EditorViewY -= (e.Delta / 120);
                if (E_Globals.EditorViewY < 0) { E_Globals.EditorViewY = 0; }
                if (E_Globals.EditorViewY > scrlMapViewV.Maximum) { E_Globals.EditorViewY = scrlMapViewV.Maximum; }
            }
            else
            {
                E_Globals.EditorViewX -= (e.Delta / 120);
                if (E_Globals.EditorViewX < 0) { E_Globals.EditorViewX = 0; }
                if (E_Globals.EditorViewX > scrlMapViewH.Maximum) { E_Globals.EditorViewX = scrlMapViewH.Maximum; }
            }
            scrlMapViewV.Value = E_Globals.EditorViewY;
            scrlMapViewH.Value = E_Globals.EditorViewX;
        }
        
        public void ChkInstance_CheckedChanged(object sender, EventArgs e)
		{
			if (chkInstance.Checked == true)
			{
				E_Types.Map.Instanced = (byte) 1;
			}
			else
			{
				E_Types.Map.Instanced = (byte) 0;
			}
		}
		
		public void BtnMoreOptions_Click(object sender, EventArgs e)
		{
			if (pnlMoreOptions.Visible == false)
			{
				pnlMoreOptions.Visible = true;
			}
			else
			{
				pnlMoreOptions.Visible = false;
			}
		}
		
		public void LstMusic_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstMusic.SelectedIndex >= 0)
			{
				E_Types.Map.Music = lstMusic.Items[lstMusic.SelectedIndex].ToString();
			}
			else
			{
				E_Types.Map.Music = "";
			}
		}
		
		public void OptDoor_CheckedChanged(object sender, EventArgs e)
		{
			if (optDoor.Checked == false)
			{
				return;
			}
			
			E_Editors.ClearAttributeDialogue();
			pnlAttributes.Visible = true;
			fraMapWarp.Visible = true;
			
			scrlMapWarpMap.Maximum = Constants.MAX_MAPS;
			scrlMapWarpMap.Value = 1;
			scrlMapWarpX.Maximum = byte.MaxValue;
			scrlMapWarpY.Maximum = byte.MaxValue;
			scrlMapWarpX.Value = 0;
			scrlMapWarpY.Value = 0;
		}
		
#endregion
		
#region Npc's
		
		public void LstMapNpc_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmbNpcList.SelectedItem = lstMapNpc.SelectedItem;
		}
		
		public void CmbNpcList_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstMapNpc.SelectedIndex > -1)
			{
				if (cmbNpcList.SelectedIndex > 0)
				{
					lstMapNpc.Items[lstMapNpc.SelectedIndex] = cmbNpcList.SelectedIndex + ": " + Types.Npc[cmbNpcList.SelectedIndex].Name;
					E_Types.Map.Npc[lstMapNpc.SelectedIndex + 1] = cmbNpcList.SelectedIndex;
				}
				else
				{
					lstMapNpc.Items[lstMapNpc.SelectedIndex] = "No NPC";
					E_Types.Map.Npc[lstMapNpc.SelectedIndex + 1] = 0;
				}
				
			}
		}
		
		public void FrmEditor_MapEditor_Load(object sender, EventArgs e)
		{
			//To Whom It May Concern,
			//This is super shitty code.
			//We know this is super shitty code
			//You will be tempted to remove this code
			//Do not.
			
			//Find and yell at JC. But leave this code in place
			//Have a nice day
			this.WindowState = FormWindowState.Maximized;
            //Do we need this?
            //Application.DoEvents();
            this.WindowState = FormWindowState.Normal;
		}

        #endregion
        
    }
}
