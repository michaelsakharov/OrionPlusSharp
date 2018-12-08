using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using System.ComponentModel;
using static Engine.Types;
using static Engine.E_AutoTiles;

namespace Engine
{
    internal partial class frmMapEditor
    {
        private void FrmEditor_Map_Load(object sender, EventArgs e)
        {
            cmbTileSets.SelectedIndex = 0;
            pnlAttributes.BringToFront();
            pnlAttributes.Visible = false;
            pnlTiles.BringToFront();
            pnlTiles.Visible = true;
            optBlocked.Checked = true;
            E_Globals.SelectedTab = 1;

            nudFog.Maximum = E_Graphics.NumFogs;

            picScreen.Width = (E_Types.Map.MaxX * E_Globals.PIC_X) + E_Globals.PIC_X;
            picScreen.Height = (E_Types.Map.MaxY * E_Globals.PIC_Y) + E_Globals.PIC_Y;

            scrlMapViewH.Maximum = (E_Types.Map.MaxX / E_Globals.PIC_X) + E_Globals.PIC_X;
            scrlMapViewV.Maximum = (E_Types.Map.MaxY / E_Globals.PIC_Y) + E_Globals.PIC_Y;

            E_Graphics.GameWindow.SetView(new SFML.Graphics.View(new SFML.Graphics.FloatRect(0, 0, picScreen.Width, picScreen.Height)));
            E_Graphics.TilesetWindow.SetView(new SFML.Graphics.View(new SFML.Graphics.FloatRect(0, 0, picBackSelect.Width, picBackSelect.Height)));

            picScreen.Focus();
        }

        private void FrmEditor_MapEditor_Resize(object sender, EventArgs e)
        {
            if (E_Graphics.GameWindow == null)
                return;

            picScreen.Width = (E_Types.Map.MaxX * E_Globals.PIC_X) + E_Globals.PIC_X;
            picScreen.Height = (E_Types.Map.MaxY * E_Globals.PIC_Y) + E_Globals.PIC_Y;

            // set the scrollbars
            scrlMapViewH.Maximum = (E_Types.Map.MaxX / E_Globals.PIC_X) + E_Globals.PIC_X;
            scrlMapViewV.Maximum = (E_Types.Map.MaxY / E_Globals.PIC_Y) + E_Globals.PIC_Y;

            E_Graphics.GameWindow.SetView(new SFML.Graphics.View(new SFML.Graphics.FloatRect(0, 0, picScreen.Width, picScreen.Height)));
        }

        private void FrmEditor_MapEditor_Closing(object sender, CancelEventArgs e)
        {
            E_Editors.MapEditorCancel();
        }

        private void FrmEditor_MapEditor_Closed(object sender, EventArgs e)
        {
            E_Editors.MapEditorCancel();
        }

        private void PicBackSelect_MouseDown(object sender, MouseEventArgs e)
        {
            E_Editors.MapEditorChooseTile((int)e.Button, e.X, e.Y);
        }

        private void PicBackSelect_MouseMove(object sender, MouseEventArgs e)
        {
            E_Editors.MapEditorDrag((int)e.Button, e.X, e.Y);
        }

        private new void PicBackSelect_Paint(object sender, PaintEventArgs e)
        {
        }

        private new void PnlBack_Paint(object sender, PaintEventArgs e)
        {
        }

        private new void PnlBack2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void ScrlPictureY_Scroll(object sender, EventArgs e)
        {
            E_Editors.MapEditorTileScroll();
        }

        private void ScrlPictureX_Scroll(object sender, EventArgs e)
        {
            E_Editors.MapEditorTileScroll();
        }

        private void CmbTileSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTileSets.SelectedIndex + 1 > E_Graphics.NumTileSets)
                cmbTileSets.SelectedIndex = 0;

            E_Types.Map.tileset = cmbTileSets.SelectedIndex + 1;

            E_Globals.EditorTileSelStart = new Point(0, 0);
            E_Globals.EditorTileSelEnd = new Point(1, 1);

            // EditorMap_DrawTileset2()

            // pnlBack.Refresh()

            picBackSelect.Height = E_Graphics.TileSetTextureInfo[cmbTileSets.SelectedIndex + 1].height;
            picBackSelect.Width = E_Graphics.TileSetTextureInfo[cmbTileSets.SelectedIndex + 1].width;

            scrlPictureY.Maximum = (picBackSelect.Height / E_Globals.PIC_Y) + E_Globals.PIC_Y;
            scrlPictureX.Maximum = (picBackSelect.Width / E_Globals.PIC_X) + E_Globals.PIC_X;
        }

        private void CmbAutoTile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAutoTile.SelectedIndex == 0)
            {
                E_Globals.EditorTileWidth = 1;
                E_Globals.EditorTileHeight = 1;
            }
        }

        private void BtnTiles_Click(object sender, EventArgs e)
        {
            E_Globals.SelectedTab = 1;

            pnlTiles.Visible = true;

            pnlAttribute.Visible = false;
            pnlNpc.Visible = false;
            pnlDirBlock.Visible = false;
            pnlEvents.Visible = false;
        }

        private void BtnAttributes_Click(object sender, EventArgs e)
        {
            E_Globals.SelectedTab = 2;

            pnlAttribute.Visible = true;

            pnlTiles.Visible = false;
            pnlNpc.Visible = false;
            pnlDirBlock.Visible = false;
            pnlEvents.Visible = false;
        }

        private void BtnNpc_Click(object sender, EventArgs e)
        {
            E_Globals.SelectedTab = 3;

            pnlNpc.Visible = true;

            pnlTiles.Visible = false;
            pnlAttribute.Visible = false;
            pnlDirBlock.Visible = false;
            pnlEvents.Visible = false;
        }

        private void BtnDirBlock_Click(object sender, EventArgs e)
        {
            E_Globals.SelectedTab = 4;

            pnlDirBlock.Visible = true;

            pnlTiles.Visible = false;
            pnlNpc.Visible = false;
            pnlAttribute.Visible = false;
            pnlEvents.Visible = false;
        }

        private void BtnEvents_Click(object sender, EventArgs e)
        {
            E_Globals.SelectedTab = 5;

            pnlEvents.Visible = true;

            pnlTiles.Visible = false;
            pnlAttribute.Visible = false;
            pnlNpc.Visible = false;
            pnlDirBlock.Visible = false;
        }



        private void TsbSave_Click(object sender, EventArgs e)
        {
            E_Globals.HideCursor = true;
            E_Globals.ScreenShotTimer = ClientDataBase.GetTickCount() + 500;
            E_Globals.MakeCache = true;
        }

        private void TsbDiscard_Click(object sender, EventArgs e)
        {
            E_Editors.MapEditorCancel();
        }

        private void TsbMapGrid_Click(object sender, EventArgs e)
        {
            E_Globals.MapGrid = !E_Globals.MapGrid;
        }

        private void TsbFill_Click(object sender, EventArgs e)
        {
            E_Editors.MapEditorFillLayer((byte)cmbAutoTile.SelectedIndex);
        }

        private void TsbClear_Click(object sender, EventArgs e)
        {
            E_Editors.MapEditorClearLayer();
        }

        private void CmbMapList_SelectedIndexChanged(object sender, EventArgs e)
        {
            E_NetworkSend.SendEditorRequestMap(cmbMapList.SelectedIndex + 1);
        }

        private void TsbScreenShot_Click(object sender, EventArgs e)
        {
            E_Globals.HideCursor = true;
            E_Globals.ScreenShotTimer = ClientDataBase.GetTickCount() + 1000;
            E_Globals.TakeScreenShot = true;
        }



        private void Picscreen_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.X > pnlBack2.Width - 32 || e.Y > pnlBack2.Height - 32)
                return;
            E_Editors.MapEditorMouseDown((int)e.Button, e.X, e.Y, false);
        }

        private new void Picscreen_Paint(object sender, PaintEventArgs e)
        {
            // This is here to make sure that the box dosen't try to re-paint itself... saves time and w/e else
            return;
        }

        private void Picscreen_MouseMove(object sender, MouseEventArgs e)
        {
            E_Globals.CurX = E_Globals.TileView.Left + ((e.Location.X + E_Globals.Camera.Left) / E_Globals.PIC_X);
            E_Globals.CurY = E_Globals.TileView.Top + ((e.Location.Y + E_Globals.Camera.Top) / E_Globals.PIC_Y);

            E_Globals.CurMouseX = e.Location.X;
            E_Globals.CurMouseY = e.Location.Y;

            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                E_Editors.MapEditorMouseDown((int)e.Button, e.X, e.Y);

            tslCurXY.Text = "X: " + E_Globals.CurX + " - " + " Y: " + E_Globals.CurY;
        }

        private void Picscreen_MouseUp(object sender, MouseEventArgs e)
        {
            E_Globals.CurX = E_Globals.TileView.Left + ((e.Location.X + E_Globals.Camera.Left) / E_Globals.PIC_X);
            E_Globals.CurY = E_Globals.TileView.Top + ((e.Location.Y + E_Globals.Camera.Top) / E_Globals.PIC_Y);
        }



        private void LblVisualWarp_Click(object sender, EventArgs e)
        {
            fraMapWarp.Visible = false;
            My.MyProject.Forms.FrmVisualWarp.Visible = true;
        }

        private void ScrlMapWarpMap_Scroll(object sender, ScrollEventArgs e)
        {
            lblMapWarpMap.Text = "Map: " + scrlMapWarpMap.Value;
        }

        private void ScrlMapWarpX_Scroll(object sender, ScrollEventArgs e)
        {
            lblMapWarpX.Text = "X: " + scrlMapWarpX.Value;
        }

        private void ScrlMapWarpY_Scroll(object sender, ScrollEventArgs e)
        {
            lblMapWarpY.Text = "Y: " + scrlMapWarpY.Value;
        }

        private void BtnMapWarp_Click(object sender, EventArgs e)
        {
            E_Globals.EditorWarpMap = scrlMapWarpMap.Value;

            E_Globals.EditorWarpX = scrlMapWarpX.Value;
            E_Globals.EditorWarpY = scrlMapWarpY.Value;
            pnlAttributes.Visible = false;
            fraMapWarp.Visible = false;
        }

        private void OptWarp_CheckedChanged(object sender, EventArgs e)
        {
            if (optWarp.Checked == true)
            {
                E_Editors.ClearAttributeDialogue();
                fraMapWarp.Visible = true;
            }
        }

        private void ScrlMapItem_Scroll(object sender, ScrollEventArgs e)
        {
            if (Types.Item[scrlMapItem.Value].Type == (byte)Enums.ItemType.Currency || Types.Item[scrlMapItem.Value].Stackable == 1)
                scrlMapItemValue.Enabled = true;
            else
            {
                scrlMapItemValue.Value = 1;
                scrlMapItemValue.Enabled = false;
            }

            E_Graphics.EditorMap_DrawMapItem();
            lblMapItem.Text = "Item: " + scrlMapItem.Value + ". " + Microsoft.VisualBasic.Strings.Trim(Types.Item[scrlMapItem.Value].Name) + " x" + scrlMapItemValue.Value;
        }

        private void ScrlMapItemValue_Scroll(object sender, ScrollEventArgs e)
        {
            lblMapItem.Text = Microsoft.VisualBasic.Strings.Trim(Types.Item[scrlMapItem.Value].Name) + " x" + scrlMapItemValue.Value;
        }

        private void BtnMapItem_Click(object sender, EventArgs e)
        {
            E_Globals.ItemEditorNum = scrlMapItem.Value;
            E_Globals.ItemEditorValue = scrlMapItemValue.Value;
            pnlAttributes.Visible = false;
            fraMapItem.Visible = false;
        }

        private void OptItem_CheckedChanged(object sender, EventArgs e)
        {
            E_Editors.ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraMapItem.Visible = true;

            scrlMapItem.Maximum = Constants.MAX_ITEMS;
            scrlMapItem.Value = 1;
            lblMapItem.Text = Microsoft.VisualBasic.Strings.Trim(Types.Item[scrlMapItem.Value].Name) + " x" + scrlMapItemValue.Value;
            E_Graphics.EditorMap_DrawMapItem();
        }

        private void ScrlMapKey_Scroll(object sender, ScrollEventArgs e)
        {
            lblMapKey.Text = "Item: " + Microsoft.VisualBasic.Strings.Trim(Types.Item[scrlMapKey.Value].Name);
            E_Graphics.EditorMap_DrawKey();
        }

        private void BtnMapKey_Click(object sender, EventArgs e)
        {
            E_Globals.KeyEditorNum = scrlMapKey.Value;
            E_Globals.KeyEditorTake = Convert.ToInt32(chkMapKey.Checked);
            pnlAttributes.Visible = false;
            fraMapKey.Visible = false;
        }

        private void OptKey_CheckedChanged(object sender, EventArgs e)
        {
            E_Editors.ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraMapKey.Visible = true;

            scrlMapKey.Maximum = Constants.MAX_ITEMS;
            scrlMapKey.Value = 1;
            chkMapKey.Checked = true;
            E_Graphics.EditorMap_DrawKey();
            lblMapKey.Text = "Item: " + Microsoft.VisualBasic.Strings.Trim(Types.Item[scrlMapKey.Value].Name);
        }

        private void ScrlKeyX_Scroll(object sender, ScrollEventArgs e)
        {
            lblKeyX.Text = "X: " + scrlKeyX.Value;
        }

        private void ScrlKeyY_Scroll(object sender, ScrollEventArgs e)
        {
            lblKeyY.Text = "X: " + scrlKeyY.Value;
        }

        private void BtnMapKeyOpen_Click(object sender, EventArgs e)
        {
            E_Globals.KeyOpenEditorX = scrlKeyX.Value;
            E_Globals.KeyOpenEditorY = scrlKeyY.Value;
            pnlAttributes.Visible = false;
            fraKeyOpen.Visible = false;
        }

        private void OptKeyOpen_CheckedChanged(object sender, EventArgs e)
        {
            E_Editors.ClearAttributeDialogue();
            fraKeyOpen.Visible = true;
            pnlAttributes.Visible = true;

            scrlKeyX.Maximum = E_Types.Map.MaxX;
            scrlKeyY.Maximum = E_Types.Map.MaxY;
            scrlKeyX.Value = 0;
            scrlKeyY.Value = 0;
        }

        private void BtnResourceOk_Click(object sender, EventArgs e)
        {
            E_Globals.ResourceEditorNum = scrlResource.Value;
            pnlAttributes.Visible = false;
            fraResource.Visible = false;
        }

        private void ScrlResource_Scroll(object sender, ScrollEventArgs e)
        {
            lblResource.Text = "Resource: " + Types.Resource[scrlResource.Value].Name;
        }

        private void OptResource_CheckedChanged(object sender, EventArgs e)
        {
            E_Editors.ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraResource.Visible = true;
        }

        private void BtnNpcSpawn_Click(object sender, EventArgs e)
        {
            E_Globals.SpawnNpcNum = lstNpc.SelectedIndex + 1;
            E_Globals.SpawnNpcDir = (byte)scrlNpcDir.Value;
            pnlAttributes.Visible = false;
            fraNpcSpawn.Visible = false;
        }

        private void OptNPCSpawn_CheckedChanged(object sender, EventArgs e)
        {
            int n;

            lstNpc.Items.Clear();

            for (n = 1; n <= Constants.MAX_MAP_NPCS; n++)
            {
                if (E_Types.Map.Npc[n] > 0)
                    lstNpc.Items.Add(n + ": " + Types.Npc[E_Types.Map.Npc[n]].Name);
                else
                    lstNpc.Items.Add(n + ": No Npc");
            }

            scrlNpcDir.Value = 0;
            lstNpc.SelectedIndex = 0;

            E_Editors.ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraNpcSpawn.Visible = true;
        }

        private void BtnShop_Click(object sender, EventArgs e)
        {
            E_Globals.EditorShop = cmbShop.SelectedIndex;
            pnlAttributes.Visible = false;
            fraShop.Visible = false;
        }

        private void OptShop_CheckedChanged(object sender, EventArgs e)
        {
            E_Editors.ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraShop.Visible = true;
        }

        private void BtnHeal_Click(object sender, EventArgs e)
        {
            E_Globals.MapEditorHealType = cmbHeal.SelectedIndex + 1;
            E_Globals.MapEditorHealAmount = scrlHeal.Value;
            pnlAttributes.Visible = false;
            fraHeal.Visible = false;
        }

        private void ScrlHeal_Scroll(object sender, ScrollEventArgs e)
        {
            lblHeal.Text = "Amount: " + scrlHeal.Value;
        }

        private void OptHeal_CheckedChanged(object sender, EventArgs e)
        {
            E_Editors.ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraHeal.Visible = true;
        }

        private void ScrlTrap_Scroll(object sender, ScrollEventArgs e)
        {
            lblTrap.Text = "Amount: " + scrlTrap.Value;
        }

        private void BtnTrap_Click(object sender, EventArgs e)
        {
            E_Globals.MapEditorHealAmount = scrlTrap.Value;
            pnlAttributes.Visible = false;
            fraTrap.Visible = false;
        }

        private void OptTrap_CheckedChanged(object sender, EventArgs e)
        {
            E_Editors.ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraTrap.Visible = true;
        }

        private void BtnClearAttribute_Click(object sender, EventArgs e)
        {
            E_Editors.MapEditorClearAttribs();
        }

        private void ScrlNpcDir_Scroll(object sender, ScrollEventArgs e)
        {
            switch (scrlNpcDir.Value)
            {
                case 0:
                    {
                        lblNpcDir.Text = "Direction: Up";
                        break;
                    }

                case 1:
                    {
                        lblNpcDir.Text = "Direction: Down";
                        break;
                    }

                case 2:
                    {
                        lblNpcDir.Text = "Direction: Left";
                        break;
                    }

                case 3:
                    {
                        lblNpcDir.Text = "Direction: Right";
                        break;
                    }
            }
        }

        private void OptBlocked_CheckedChanged(object sender, EventArgs e)
        {
            if (optBlocked.Checked)
                pnlAttributes.Visible = false;
        }

        private void OptHouse_CheckedChanged(object sender, EventArgs e)
        {
            E_Editors.ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraBuyHouse.Visible = true;
            scrlBuyHouse.Maximum = E_Housing.MAX_HOUSES;
            scrlBuyHouse.Value = 1;
        }

        private void ScrlBuyHouse_Scroll(object sender, ScrollEventArgs e)
        {
            lblHouseName.Text = scrlBuyHouse.Value + ". " + E_Housing.HouseConfig[scrlBuyHouse.Value].ConfigName;
        }

        private void BtnHouseTileOk_Click(object sender, EventArgs e)
        {
            E_Housing.HouseTileindex = scrlBuyHouse.Value;
            pnlAttributes.Visible = false;
            fraBuyHouse.Visible = false;
        }



        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            E_Types.Map.Name = Microsoft.VisualBasic.Strings.Trim(txtName.Text);
        }

        private void CmbMoral_SelectedIndexChanged(object sender, EventArgs e)
        {
            E_Types.Map.Moral = (byte)cmbMoral.SelectedIndex;
        }

        private void NudLeft_ValueChanged(object sender, EventArgs e)
        {
            E_Types.Map.Left = (byte)nudLeft.Value;
        }

        private void NudRight_ValueChanged(object sender, EventArgs e)
        {
            E_Types.Map.Right = (byte)nudRight.Value;
        }

        private void NudUp_ValueChanged(object sender, EventArgs e)
        {
            E_Types.Map.Up = (byte)nudUp.Value;
        }

        private void NudDown_ValueChanged(object sender, EventArgs e)
        {
            E_Types.Map.Down = (byte)nudDown.Value;
        }

        private void TxtBootMap_TextChanged(object sender, EventArgs e)
        {
            E_Types.Map.BootMap = (byte)nudSpawnMap.Value;
        }

        private void TxtBootX_TextChanged(object sender, EventArgs e)
        {
            E_Types.Map.BootX = (byte)nudSpawnX.Value;
        }

        private void TxtBootY_TextChanged(object sender, EventArgs e)
        {
            E_Types.Map.BootY = (byte)nudSpawnY.Value;
        }

        private void BtnPreview_Click(object sender, EventArgs e)
        {
            if (E_Sound.PreviewPlayer == null)
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

        private void CmbWeather_SelectedIndexChanged(object sender, EventArgs e)
        {
            E_Types.Map.WeatherType = (byte)cmbWeather.SelectedIndex;
            E_Globals.CurrentWeather = cmbWeather.SelectedIndex;
        }

        private void ScrlFog_Scroll(object sender, EventArgs e)
        {
            E_Types.Map.Fogindex = (byte)nudFog.Value;
            E_Globals.CurrentFog = (byte)nudFog.Value;
        }

        private void ScrlIntensity_Scroll(object sender, EventArgs e)
        {
            E_Types.Map.WeatherIntensity = (byte)nudIntensity.Value;
            E_Globals.CurrentWeatherIntensity = (byte)nudIntensity.Value;
        }

        private void ScrlFogSpeed_Scroll(object sender, EventArgs e)
        {
            E_Types.Map.FogSpeed = (byte)nudFogSpeed.Value;
            E_Globals.CurrentFogSpeed = (byte)nudFogSpeed.Value;
        }

        private void ScrlFogAlpha_Scroll(object sender, EventArgs e)
        {
            E_Types.Map.FogAlpha = (byte)nudFogAlpha.Value;
            E_Globals.CurrentFogOpacity = (byte)nudFogAlpha.Value;
        }

        private void ChkUseTint_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseTint.Checked == true)
                E_Types.Map.HasMapTint = 1;
            else
                E_Types.Map.HasMapTint = 0;
        }

        private void ScrlMapRed_Scroll(object sender, EventArgs e)
        {
            E_Types.Map.MapTintR = (byte)nudMapRed.Value;
            E_Globals.CurrentTintR = (byte)nudMapRed.Value;
        }

        private void ScrlMapGreen_Scroll(object sender, EventArgs e)
        {
            E_Types.Map.MapTintG = (byte)nudMapGreen.Value;
            E_Globals.CurrentTintG = (byte)nudMapGreen.Value;
        }

        private void ScrlMapBlue_Scroll(object sender, EventArgs e)
        {
            E_Types.Map.MapTintB = (byte)nudMapBlue.Value;
            E_Globals.CurrentTintB = (byte)nudMapBlue.Value;
        }

        private void ScrlMapAlpha_Scroll(object sender, EventArgs e)
        {
            E_Types.Map.MapTintA = (byte)nudMapAlpha.Value;
            E_Globals.CurrentTintA = (byte)nudMapAlpha.Value;
        }

        private void BtnSetSize_Click(object sender, EventArgs e)
        {
            int X;
            int x2;
            int i;
            int Y;
            int y2;
            Types.TileRec[,] tempArr;

            if (nudMaxX.Value < E_Globals.SCREEN_MAPX)
                nudMaxX.Value = E_Globals.SCREEN_MAPX;
            if (nudMaxY.Value < E_Globals.SCREEN_MAPY)
                nudMaxY.Value = E_Globals.SCREEN_MAPY;

            E_Globals.GettingMap = true;
            {
                var withBlock = E_Types.Map;

                // set the data before changing it
                tempArr = new TileRec[withBlock.MaxX + 1, withBlock.MaxY + 1];
                var loopTo = withBlock.MaxX;
                for (X = 0; X <= loopTo; X++)
                {
                    var loopTo1 = withBlock.MaxY;
                    for (Y = 0; Y <= loopTo1; Y++)
                    {
                        tempArr[X, Y].Layer = new TileDataRec[6];

                        tempArr[X, Y].Data1 = withBlock.Tile[X, Y].Data1;
                        tempArr[X, Y].Data2 = withBlock.Tile[X, Y].Data2;
                        tempArr[X, Y].Data3 = withBlock.Tile[X, Y].Data3;
                        tempArr[X, Y].DirBlock = withBlock.Tile[X, Y].DirBlock;
                        tempArr[X, Y].Type = withBlock.Tile[X, Y].Type;

                        for (i = 1; i <= (byte)Enums.LayerType.Count - 1; i++)
                        {
                            tempArr[X, Y].Layer[i].AutoTile = withBlock.Tile[X, Y].Layer[i].AutoTile;
                            tempArr[X, Y].Layer[i].Tileset = withBlock.Tile[X, Y].Layer[i].Tileset;
                            tempArr[X, Y].Layer[i].X = withBlock.Tile[X, Y].Layer[i].X;
                            tempArr[X, Y].Layer[i].Y = withBlock.Tile[X, Y].Layer[i].Y;
                        }
                    }
                }

                x2 = E_Types.Map.MaxX;
                y2 = E_Types.Map.MaxY;
                // change the data
                withBlock.MaxX = (byte)nudMaxX.Value;
                withBlock.MaxY = (byte)nudMaxY.Value;

                E_Types.Map.Tile = new TileRec[withBlock.MaxX + 1, withBlock.MaxY + 1];
                E_AutoTiles.Autotile = new AutotileRec[withBlock.MaxX + 1, withBlock.MaxY + 1];

                if (x2 > withBlock.MaxX)
                    x2 = withBlock.MaxX;
                if (y2 > withBlock.MaxY)
                    y2 = withBlock.MaxY;
                var loopTo2 = withBlock.MaxX;
                for (X = 0; X <= loopTo2; X++)
                {
                    var loopTo3 = withBlock.MaxY;
                    for (Y = 0; Y <= loopTo3; Y++)
                    {
                        var oldLayer = withBlock.Tile[X, Y].Layer;
                        withBlock.Tile[X, Y].Layer = new TileDataRec[6];
                        if (oldLayer != null)
                            Array.Copy(oldLayer, withBlock.Tile[X, Y].Layer, Math.Min(6, oldLayer.Length));
                        var olddLayer = E_AutoTiles.Autotile[X, Y].Layer;
                        E_AutoTiles.Autotile[X, Y].Layer = new QuarterTileRec[6];
                        if (olddLayer != null)
                            Array.Copy(olddLayer, E_AutoTiles.Autotile[X, Y].Layer, Math.Min(6, olddLayer.Length));

                        if (X <= x2)
                        {
                            if (Y <= y2)
                            {
                                withBlock.Tile[X, Y].Data1 = tempArr[X, Y].Data1;
                                withBlock.Tile[X, Y].Data2 = tempArr[X, Y].Data2;
                                withBlock.Tile[X, Y].Data3 = tempArr[X, Y].Data3;
                                withBlock.Tile[X, Y].DirBlock = tempArr[X, Y].DirBlock;
                                withBlock.Tile[X, Y].Type = tempArr[X, Y].Type;

                                for (i = 1; i <= (byte)Enums.LayerType.Count - 1; i++)
                                {
                                    withBlock.Tile[X, Y].Layer[i].AutoTile = tempArr[X, Y].Layer[i].AutoTile;
                                    withBlock.Tile[X, Y].Layer[i].Tileset = tempArr[X, Y].Layer[i].Tileset;
                                    withBlock.Tile[X, Y].Layer[i].X = tempArr[X, Y].Layer[i].X;
                                    withBlock.Tile[X, Y].Layer[i].Y = tempArr[X, Y].Layer[i].Y;
                                }
                            }
                        }
                    }
                }
                E_AutoTiles.InitAutotiles();
                ClientDataBase.ClearTempTile();
            }

            E_Globals.GettingMap = false;
        }

        private void ScrlMapViewH_Scroll(object sender, EventArgs e)
        {
            E_Globals.EditorViewX = scrlMapViewH.Value;
        }

        private void ScrlMapViewV_Scroll(object sender, EventArgs e)
        {
            E_Globals.EditorViewY = scrlMapViewV.Value;
        }

        private void ChkInstance_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInstance.Checked == true)
                E_Types.Map.Instanced = 1;
            else
                E_Types.Map.Instanced = 0;
        }

        private void BtnMoreOptions_Click(object sender, EventArgs e)
        {
            if (pnlMoreOptions.Visible == false)
                pnlMoreOptions.Visible = true;
            else
                pnlMoreOptions.Visible = false;
        }

        private void LstMusic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMusic.SelectedIndex >= 0)
                E_Types.Map.Music = lstMusic.Items[lstMusic.SelectedIndex].ToString();
            else
                E_Types.Map.Music = "";
        }

        private void OptDoor_CheckedChanged(object sender, EventArgs e)
        {
            if (optDoor.Checked == false)
                return;

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



        private void LstMapNpc_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbNpcList.SelectedItem = lstMapNpc.SelectedItem;
        }

        private void CmbNpcList_SelectedIndexChanged(object sender, EventArgs e)
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

        private void FrmEditor_MapEditor_Load(object sender, EventArgs e)
        {
            // To Whom It May Concern,
            // This is super shitty code.
            // We know this is super shitty code
            // You will be tempted to remove this code
            // Do not.

            // Find and yell at JC. But leave this code in place
            // Have a nice day
            this.WindowState = FormWindowState.Maximized;
            Application.DoEvents();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
