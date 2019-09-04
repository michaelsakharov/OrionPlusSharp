
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ASFW;
using SFML.Graphics;
using SFML.Window;
using Engine;

namespace Engine
{

    public partial class FrmEditor_MapEditor
    {
        public FrmEditor_MapEditor()
        {
            InitializeComponent();


            if (defaultInstance == null)
                defaultInstance = this;
        }

        #region Default Instance

        private static FrmEditor_MapEditor defaultInstance;

        /// <summary>
        /// The Instance of this Form
        /// </summary>
        public static FrmEditor_MapEditor Default
        {
            get
            {
                if (defaultInstance == null)
                {
                    defaultInstance = new FrmEditor_MapEditor();
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
            defaultInstance = null;
        }

        #endregion

        #region Frm

        public void FrmEditor_Map_Load(object sender, EventArgs e)
        {
            cmbTileSets.SelectedIndex = 0;
            EditorMap_DrawTileset();
            pnlAttributes.BringToFront();
            pnlAttributes.Visible = false;
            pnlAttributes.Left = 4;
            pnlAttributes.Top = 28;
            this.Width = 525;
            optBlocked.Checked = true;
            tabpages.SelectedIndex = 0;

            scrlBrightness.Value = C_Maps.Map.Brightness;
            lblBrightness.Text = "Brightness: " + scrlBrightness.Value;



            scrlFog.Maximum = C_Graphics.NumFogs;

            TopMost = true;
        }

        #endregion

        #region Toolbar

        public void TsbSave_Click(object sender, EventArgs e)
        {
            MapEditorSend();
            C_Variables.GettingMap = true;
        }

        public void TsbFill_Click(object sender, EventArgs e)
        {
            MapEditorFillLayer(System.Convert.ToByte(cmbAutoTile.SelectedIndex));
        }

        public void TsbClear_Click(object sender, EventArgs e)
        {
            MapEditorClearLayer();
        }

        public void TsbDiscard_Click(object sender, EventArgs e)
        {
            MapEditorCancel();
        }

        public void TsbMapGrid_Click(object sender, EventArgs e)
        {
            C_Constants.MapGrid = !C_Constants.MapGrid;
        }

        #endregion

        #region Tiles

        public void PicBackSelect_MouseDown(object sender, MouseEventArgs e)
        {
            MapEditorChooseTile((System.Int32)e.Button, e.X, e.Y);
        }

        public void PicBackSelect_MouseMove(object sender, MouseEventArgs e)
        {
            MapEditorDrag((System.Int32)e.Button, e.X, e.Y);
        }

        public void PicBackSelect_Paint(object sender, PaintEventArgs e)
        {
            //Overrides the paint sub
        }

        public void PnlBack_Paint(object sender, PaintEventArgs e)
        {
            //Overrides the paint sub
        }

        public void ScrlPictureY_Scroll(object sender, EventArgs e)
        {
            MapEditorTileScroll();
        }

        public void ScrlPictureX_Scroll(object sender, EventArgs e)
        {
            MapEditorTileScroll();
        }

        public void CmbTileSets_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTileSets.SelectedIndex + 1 > C_Graphics.NumTileSets)
            {
                cmbTileSets.SelectedIndex = 0;
            }

            C_Maps.Map.Tileset = (int)(cmbTileSets.SelectedIndex + 1);

            C_Constants.EditorTileSelStart = new Point(0, 0);
            C_Constants.EditorTileSelEnd = new Point(1, 1);

            picBackSelect.Height = C_Graphics.TileSetTextureInfo[cmbTileSets.SelectedIndex + 1].Height;
            picBackSelect.Width = C_Graphics.TileSetTextureInfo[cmbTileSets.SelectedIndex + 1].Width;

            scrlPictureY.Maximum = picBackSelect.Height / C_Constants.PicY;
            scrlPictureX.Maximum = picBackSelect.Width / C_Constants.PicX;
        }

        public void CmbAutoTile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAutoTile.SelectedIndex == 0)
            {
                C_Constants.EditorTileWidth = 1;
                C_Constants.EditorTileHeight = 1;
            }
        }

        #endregion

        #region Attributes

        public void ScrlMapWarpMap_Scroll(object sender, EventArgs e)
        {
            lblMapWarpMap.Text = "Map: " + System.Convert.ToString(scrlMapWarpMap.Value);
        }

        public void ScrlMapWarpX_Scroll(object sender, EventArgs e)
        {
            lblMapWarpX.Text = "X: " + System.Convert.ToString(scrlMapWarpX.Value);
        }

        public void ScrlMapWarpY_Scroll(object sender, EventArgs e)
        {
            lblMapWarpY.Text = "Y: " + System.Convert.ToString(scrlMapWarpY.Value);
        }

        public void BtnMapWarp_Click(object sender, EventArgs e)
        {
            C_Constants.EditorWarpMap = scrlMapWarpMap.Value;

            C_Constants.EditorWarpX = scrlMapWarpX.Value;
            C_Constants.EditorWarpY = scrlMapWarpY.Value;
            pnlAttributes.Visible = false;
            fraMapWarp.Visible = false;
        }

        public void OptWarp_CheckedChanged(object sender, EventArgs e)
        {
            if (optWarp.Checked == false)
            {
                return;
            }

            ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraMapWarp.Visible = true;

            scrlMapWarpMap.Maximum = Constants.MAX_MAPS;
            scrlMapWarpMap.Value = 1;
            scrlMapWarpX.Maximum = byte.MaxValue;
            scrlMapWarpY.Maximum = byte.MaxValue;
            scrlMapWarpX.Value = 0;
            scrlMapWarpY.Value = 0;
        }

        public void ScrlMapItem_Scroll(object sender, EventArgs e)
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

            EditorMap_DrawMapItem();
            lblMapItem.Text = "Item: " + System.Convert.ToString(scrlMapItem.Value) + ". " + Microsoft.VisualBasic.Strings.Trim(Types.Item[scrlMapItem.Value].Name) + " x" + System.Convert.ToString(scrlMapItemValue.Value);
        }

        public void ScrlMapItemValue_Scroll(object sender, EventArgs e)
        {
            lblMapItem.Text = Microsoft.VisualBasic.Strings.Trim(Types.Item[scrlMapItem.Value].Name) + " x" + System.Convert.ToString(scrlMapItemValue.Value);
        }

        public void BtnMapItem_Click(object sender, EventArgs e)
        {
            C_Variables.ItemEditorNum = scrlMapItem.Value;
            C_Variables.ItemEditorValue = scrlMapItemValue.Value;
            pnlAttributes.Visible = false;
            fraMapItem.Visible = false;
        }

        public void OptItem_CheckedChanged(object sender, EventArgs e)
        {
            if (optItem.Checked == false)
            {
                return;
            }

            ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraMapItem.Visible = true;

            scrlMapItem.Maximum = Constants.MAX_ITEMS;
            scrlMapItem.Value = 1;
            lblMapItem.Text = Microsoft.VisualBasic.Strings.Trim(Types.Item[scrlMapItem.Value].Name) + " x" + System.Convert.ToString(scrlMapItemValue.Value);
            EditorMap_DrawMapItem();
        }

        public void ScrlMapKey_Scroll(object sender, EventArgs e)
        {
            lblMapKey.Text = "Item: " + Microsoft.VisualBasic.Strings.Trim(Types.Item[scrlMapKey.Value].Name);
            EditorMap_DrawKey();
        }

        public void BtnMapKey_Click(object sender, EventArgs e)
        {
            C_Variables.KeyEditorNum = Convert.ToInt32(chkMapKey.Checked);
            pnlAttributes.Visible = false;
            fraMapKey.Visible = false;
        }

        public void OptKey_CheckedChanged(object sender, EventArgs e)
        {
            if (optKey.Checked == false)
            {
                return;
            }

            ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraMapKey.Visible = true;

            scrlMapKey.Maximum = Constants.MAX_ITEMS;
            scrlMapKey.Value = 1;
            chkMapKey.Checked = true;
            EditorMap_DrawKey();
            lblMapKey.Text = "Item: " + Microsoft.VisualBasic.Strings.Trim(Types.Item[scrlMapKey.Value].Name);
        }

        public void ScrlKeyX_Scroll(object sender, EventArgs e)
        {
            lblKeyX.Text = "X: " + System.Convert.ToString(scrlKeyX.Value);
        }

        public void ScrlKeyY_Scroll(object sender, EventArgs e)
        {
            lblKeyY.Text = "X: " + System.Convert.ToString(scrlKeyY.Value);
        }

        public void BtnMapKeyOpen_Click(object sender, EventArgs e)
        {
            C_Variables.KeyOpenEditorX = scrlKeyX.Value;
            C_Variables.KeyOpenEditorY = scrlKeyY.Value;
            pnlAttributes.Visible = false;
            fraKeyOpen.Visible = false;
        }

        public void OptKeyOpen_CheckedChanged(object sender, EventArgs e)
        {
            if (optKeyOpen.Checked == false)
            {
                return;
            }

            ClearAttributeDialogue();
            fraKeyOpen.Visible = true;
            pnlAttributes.Visible = true;

            scrlKeyX.Maximum = C_Maps.Map.MaxX;
            scrlKeyY.Maximum = C_Maps.Map.MaxY;
            scrlKeyX.Value = 0;
            scrlKeyY.Value = 0;
        }

        public void BtnResourceOk_Click(object sender, EventArgs e)
        {
            C_Variables.ResourceEditorNum = scrlResource.Value;
            pnlAttributes.Visible = false;
            fraResource.Visible = false;
        }

        public void ScrlResource_Scroll(object sender, EventArgs e)
        {
            lblResource.Text = "Resource: " + Types.Resource[scrlResource.Value].Name;
        }

        public void OptResource_CheckedChanged(object sender, EventArgs e)
        {
            if (optResource.Checked == false)
            {
                return;
            }

            ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraResource.Visible = true;
        }

        public void BtnNpcSpawn_Click(object sender, EventArgs e)
        {
            C_Variables.SpawnNpcNum = lstNpc.SelectedIndex + 1;
            C_Variables.SpawnNpcDir = (byte)scrlNpcDir.Value;
            pnlAttributes.Visible = false;
            fraNpcSpawn.Visible = false;
        }

        public void OptNPCSpawn_CheckedChanged(object sender, EventArgs e)
        {
            int n = 0;
            if (optNPCSpawn.Checked == false)
            {
                return;
            }

            lstNpc.Items.Clear();

            for (n = 1; n <= Constants.MAX_MAP_NPCS; n++)
            {
                if (C_Maps.Map.Npc[n] > 0)
                {
                    lstNpc.Items.Add(n + ": " + Types.Npc[C_Maps.Map.Npc[n]].Name);
                }
                else
                {
                    lstNpc.Items.Add(n + ": No Npc");
                }
            }

            scrlNpcDir.Value = 0;
            lstNpc.SelectedIndex = 0;

            ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraNpcSpawn.Visible = true;
        }

        public void BtnShop_Click(object sender, EventArgs e)
        {
            C_Constants.EditorShop = cmbShop.SelectedIndex;
            pnlAttributes.Visible = false;
            fraShop.Visible = false;
        }

        public void OptShop_CheckedChanged(object sender, EventArgs e)
        {
            if (optShop.Checked == false)
            {
                return;
            }

            ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraShop.Visible = true;
        }

        public void BtnHeal_Click(object sender, EventArgs e)
        {
            C_Variables.MapEditorHealType = cmbHeal.SelectedIndex + 1;
            C_Variables.MapEditorHealAmount = scrlHeal.Value;
            pnlAttributes.Visible = false;
            fraHeal.Visible = false;
        }

        public void ScrlHeal_Scroll(object sender, EventArgs e)
        {
            lblHeal.Text = "Amount: " + System.Convert.ToString(scrlHeal.Value);
        }

        public void OptHeal_CheckedChanged(object sender, EventArgs e)
        {
            if (optHeal.Checked == false)
            {
                return;
            }

            ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraHeal.Visible = true;
        }

        public void ScrlTrap_Scroll(object sender, EventArgs e)
        {
            lblTrap.Text = "Amount: " + System.Convert.ToString(scrlTrap.Value);
        }

        public void BtnTrap_Click(object sender, EventArgs e)
        {
            C_Variables.MapEditorHealAmount = scrlTrap.Value;
            pnlAttributes.Visible = false;
            fraTrap.Visible = false;
        }

        public void OptTrap_CheckedChanged(object sender, EventArgs e)
        {
            if (optTrap.Checked == false)
            {
                return;
            }

            ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraTrap.Visible = true;
        }

        public void BtnClearAttribute_Click(object sender, EventArgs e)
        {
            MapEditorClearAttribs();
        }

        public void ScrlNpcDir_Scroll(object sender, EventArgs e)
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
            if (optHouse.Checked == false)
            {
                return;
            }

            ClearAttributeDialogue();
            pnlAttributes.Visible = true;
            fraBuyHouse.Visible = true;
            scrlBuyHouse.Maximum = C_Housing.MaxHouses;
            scrlBuyHouse.Value = 1;
        }

        public void ScrlBuyHouse_Scroll(object sender, EventArgs e)
        {
            lblHouseName.Text = scrlBuyHouse.Value + ". " + C_Housing.HouseConfig[scrlBuyHouse.Value].ConfigName;
        }

        public void BtnHouseTileOk_Click(object sender, EventArgs e)
        {
            C_Housing.HouseTileindex = (int)(scrlBuyHouse.Value);
            pnlAttributes.Visible = false;
            fraBuyHouse.Visible = false;
        }

        public void ChkInstance_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInstance.Checked == true)
            {
                C_Maps.Map.Instanced = (byte)1;
            }
            else
            {
                C_Maps.Map.Instanced = (byte)0;
            }
        }

        public void OptDoor_CheckedChanged(object sender, EventArgs e)
        {
            if (optDoor.Checked == false)
            {
                return;
            }

            ClearAttributeDialogue();
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
                    C_Maps.Map.Npc[lstMapNpc.SelectedIndex + 1] = (int)(cmbNpcList.SelectedIndex);
                }
                else
                {
                    lstMapNpc.Items[lstMapNpc.SelectedIndex] = "No NPC";
                    C_Maps.Map.Npc[lstMapNpc.SelectedIndex + 1] = 0;
                }

            }
        }

        #endregion

        #region Settings

        public void BtnSaveSettings_Click(object sender, EventArgs e)
        {
            int X = 0;
            int x2 = 0;
            int Y = 0;
            int y2 = 0;
            Types.TileRec[,] tempArr;

            if (!Information.IsNumeric(txtMaxX.Text))
            {
                txtMaxX.Text = C_Maps.Map.MaxX.ToString();
            }
            if (Conversion.Val(txtMaxX.Text) < C_Constants.ScreenMapx)
            {
                txtMaxX.Text = C_Constants.ScreenMapx.ToString();
            }
            if (Conversion.Val(txtMaxX.Text) > byte.MaxValue)
            {
                txtMaxX.Text = byte.MaxValue.ToString();
            }
            if (!Information.IsNumeric(txtMaxY.Text))
            {
                txtMaxY.Text = C_Maps.Map.MaxY.ToString();
            }
            if (Conversion.Val(txtMaxY.Text) < C_Constants.ScreenMapy)
            {
                txtMaxY.Text = C_Constants.ScreenMapy.ToString();
            }
            if (Conversion.Val(txtMaxY.Text) > byte.MaxValue)
            {
                txtMaxY.Text = byte.MaxValue.ToString();
            }

            C_Maps.Map.Name = Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtName.Text));
            if (lstMusic.SelectedIndex >= 0)
            {
                C_Maps.Map.Music = lstMusic.Items[lstMusic.SelectedIndex].ToString();
            }
            else
            {
                C_Maps.Map.Music = "";
            }
            C_Maps.Map.Up = (int)(Conversion.Val(txtUp.Text));
            C_Maps.Map.Down = (int)(Conversion.Val(txtDown.Text));
            C_Maps.Map.Left = (int)(Conversion.Val(txtLeft.Text));
            C_Maps.Map.Right = (int)(Conversion.Val(txtRight.Text));
            C_Maps.Map.Moral = System.Convert.ToByte(cmbMoral.SelectedIndex);
            C_Maps.Map.BootMap = (int)(Conversion.Val(txtBootMap.Text));
            C_Maps.Map.BootX = (byte)(Conversion.Val(txtBootX.Text));
            C_Maps.Map.BootY = (byte)(Conversion.Val(txtBootY.Text));

            // set the data before changing it
            tempArr = (Types.TileRec[,])C_Maps.Map.Tile.Clone();

            x2 = C_Maps.Map.MaxX;
            y2 = C_Maps.Map.MaxY;
            // change the data
            C_Maps.Map.MaxX = (byte)(Conversion.Val(txtMaxX.Text));
            C_Maps.Map.MaxY = (byte)(Conversion.Val(txtMaxY.Text));
            C_Maps.Map.Tile = new Types.TileRec[C_Maps.Map.MaxX + 1, C_Maps.Map.MaxY + 1];

            C_AutoTiles.Autotile = new C_AutoTiles.AutotileRec[C_Maps.Map.MaxX + 1, C_Maps.Map.MaxY + 1];

            if (x2 > C_Maps.Map.MaxX)
            {
                x2 = C_Maps.Map.MaxX;
            }
            if (y2 > C_Maps.Map.MaxY)
            {
                y2 = C_Maps.Map.MaxY;
            }

            for (X = 0; X <= C_Maps.Map.MaxX; X++)
            {
                for (Y = 0; Y <= C_Maps.Map.MaxY; Y++)
                {
                    C_Maps.Map.Tile[X, Y].Layer = new Types.TileDataRec[(int)Enums.LayerType.Count];

                    C_AutoTiles.Autotile[X, Y].Layer = new C_AutoTiles.QuarterTileRec[(int)Enums.LayerType.Count];

                    if (X <= x2)
                    {
                        if (Y <= y2)
                        {
                            C_Maps.Map.Tile[X, Y] = tempArr[X, Y];
                        }
                    }
                }
            }

            C_GameLogic.ClearTempTile();
            MapEditorSend();
        }

        public void BtnPreview_Click(object sender, EventArgs e)
        {
            if (ReferenceEquals(C_Sound.PreviewPlayer, null))
            {
                if (lstMusic.SelectedIndex >= 0)
                {
                    C_Sound.StopMusic();
                    C_Sound.PlayPreview(lstMusic.Items[lstMusic.SelectedIndex].ToString());
                }
            }
            else
            {
                C_Sound.StopPreview();
                C_Sound.PlayMusic(C_Maps.Map.Music);
            }
        }

        #endregion

        #region Events

        public void BtnCopyEvent_Click(object sender, EventArgs e)
        {
            if (C_EventSystem.EventCopy == false)
            {
                C_EventSystem.EventCopy = true;
                lblCopyMode.Text = "CopyMode On";
                C_EventSystem.EventPaste = false;
                lblPasteMode.Text = "PasteMode Off";
            }
            else
            {
                C_EventSystem.EventCopy = false;
                lblCopyMode.Text = "CopyMode Off";
            }
        }

        public void BtnPasteEvent_Click(object sender, EventArgs e)
        {
            if (C_EventSystem.EventPaste == false)
            {
                C_EventSystem.EventPaste = true;
                lblPasteMode.Text = "PasteMode On";
                C_EventSystem.EventCopy = false;
                lblCopyMode.Text = "CopyMode Off";
            }
            else
            {
                C_EventSystem.EventPaste = false;
                lblPasteMode.Text = "PasteMode Off";
            }
        }

        #endregion

        #region Map Effects

        public void CmbWeather_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_Maps.Map.WeatherType = System.Convert.ToByte(cmbWeather.SelectedIndex);
        }

        public void ScrlFog_Scroll(object sender, EventArgs e)
        {
            C_Maps.Map.Fogindex = (int)(scrlFog.Value);
            lblFogIndex.Text = "Fog: " + scrlFog.Value;
        }

        public void ScrlIntensity_Scroll(object sender, EventArgs e)
        {
            C_Maps.Map.WeatherIntensity = (int)(scrlIntensity.Value);
            lblIntensity.Text = "Intensity: " + scrlIntensity.Value;
        }

        public void ScrlFogSpeed_Scroll(object sender, EventArgs e)
        {
            C_Maps.Map.FogSpeed = System.Convert.ToByte(scrlFogSpeed.Value);
            lblFogSpeed.Text = "FogSpeed: " + scrlFogSpeed.Value;
        }

        public void ScrlFogAlpha_Scroll(object sender, EventArgs e)
        {
            C_Maps.Map.FogAlpha = System.Convert.ToByte(scrlFogAlpha.Value);
            lblFogAlpha.Text = "Fog Alpha: " + scrlFogAlpha.Value;
        }

        public void ScrlFBrightness_Scroll(object sender, EventArgs e)
        {
            C_Maps.Map.Brightness = System.Convert.ToByte(scrlBrightness.Value);
            lblBrightness.Text = "Brightness: " + scrlBrightness.Value;
        }

        public void ChkUseTint_CheckedChanged(object sender, EventArgs e)
        {
            if (chkUseTint.Checked == true)
            {
                C_Maps.Map.HasMapTint = (byte)1;
            }
            else
            {
                C_Maps.Map.HasMapTint = (byte)0;
            }
        }

        public void ScrlMapRed_Scroll(object sender, EventArgs e)
        {
            C_Maps.Map.MapTintR = System.Convert.ToByte(scrlMapRed.Value);
            lblMapRed.Text = "Red: " + scrlMapRed.Value;
        }

        public void ScrlMapGreen_Scroll(object sender, EventArgs e)
        {
            C_Maps.Map.MapTintG = System.Convert.ToByte(scrlMapGreen.Value);
            lblMapGreen.Text = "Green: " + scrlMapGreen.Value;
        }

        public void ScrlMapBlue_Scroll(object sender, EventArgs e)
        {
            C_Maps.Map.MapTintB = System.Convert.ToByte(scrlMapBlue.Value);
            lblMapBlue.Text = "Blue: " + scrlMapBlue.Value;
        }

        public void ScrlMapAlpha_Scroll(object sender, EventArgs e)
        {
            C_Maps.Map.MapTintA = System.Convert.ToByte(scrlMapAlpha.Value);
            lblMapAlpha.Text = "Alpha: " + scrlMapAlpha.Value;
        }

        public void CmbPanorama_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_Maps.Map.Panorama = System.Convert.ToByte(cmbPanorama.SelectedIndex);
        }

        public void CmbParallax_SelectedIndexChanged(object sender, EventArgs e)
        {
            C_Maps.Map.Parallax = System.Convert.ToByte(cmbParallax.SelectedIndex);
        }

        #endregion

        #region Map Editor

        public void MapPropertiesInit()
        {
            int X = 0;
            int Y = 0;
            int i = 0;

            txtName.Text = C_Maps.Map.Name.Trim();

            // find the music we have set

            lstMusic.Items.Clear();
            lstMusic.Items.Add("None");

            if ((C_Sound.MusicCache.Length - 1) > 0)
            {
                for (i = 1; i <= (C_Sound.MusicCache.Length - 1); i++)
                {
                    lstMusic.Items.Add(C_Sound.MusicCache[i]);
                }
            }

            if (C_Maps.Map.Music.Trim() == "None")
            {
                lstMusic.SelectedIndex = 0;
            }
            else
            {
                for (i = 1; i <= lstMusic.Items.Count; i++)
                {
                    if (lstMusic.Items[i - 1].ToString() == C_Maps.Map.Music.Trim())
                    {
                        lstMusic.SelectedIndex = i - 1;
                        break;
                    }
                }
            }

            // rest of it
            txtUp.Text = C_Maps.Map.Up.ToString();
            txtDown.Text = C_Maps.Map.Down.ToString();
            txtLeft.Text = C_Maps.Map.Left.ToString();
            txtRight.Text = C_Maps.Map.Right.ToString();
            cmbMoral.SelectedIndex = C_Maps.Map.Moral;
            txtBootMap.Text = C_Maps.Map.BootMap.ToString();
            txtBootX.Text = C_Maps.Map.BootX.ToString();
            txtBootY.Text = C_Maps.Map.BootY.ToString();

            lstMapNpc.Items.Clear();

            for (X = 1; X <= Constants.MAX_MAP_NPCS; X++)
            {
                if (C_Maps.Map.Npc[X] == 0)
                {
                    lstMapNpc.Items.Add("No NPC");
                }
                else
                {
                    lstMapNpc.Items.Add(X + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[C_Maps.Map.Npc[X]].Name));
                }

            }

            cmbNpcList.Items.Clear();
            cmbNpcList.Items.Add("No NPC");

            for (Y = 1; Y <= Constants.MAX_NPCS; Y++)
            {
                cmbNpcList.Items.Add(Y + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[Y].Name));
            }

            lblMap.Text = "Current map: " + "?";
            txtMaxX.Text = C_Maps.Map.MaxX.ToString();
            txtMaxY.Text = C_Maps.Map.MaxY.ToString();

            cmbTileSets.SelectedIndex = 0;
            cmbLayers.SelectedIndex = 0;
            cmbAutoTile.SelectedIndex = 0;

            cmbWeather.SelectedIndex = C_Maps.Map.WeatherType;
            scrlFog.Value = C_Maps.Map.Fogindex;
            lblFogIndex.Text = "Fog: " + scrlFog.Value;
            scrlIntensity.Value = C_Maps.Map.WeatherIntensity;
            lblIntensity.Text = "Intensity: " + scrlIntensity.Value;

            cmbPanorama.Items.Clear();
            cmbPanorama.Items.Add("None");
            for (i = 1; i <= C_Graphics.NumPanorama; i++)
            {
                cmbPanorama.Items.Add("Panorama" + System.Convert.ToString(i));
            }

            cmbParallax.Items.Clear();
            cmbParallax.Items.Add("None");
            for (i = 1; i <= C_Graphics.NumParallax; i++)
            {
                cmbParallax.Items.Add("Parallax" + System.Convert.ToString(i));
            }

            // render the tiles
            EditorMap_DrawTileset();

            tabpages.SelectedIndex = 0;

            // show the form
            Visible = true;

        }

        public void MapEditorInit()
        {
            // we're in the map editor
            C_Constants.InMapEditor = true;

            // set the scrolly bars
            if (C_Maps.Map.Tileset == 0)
            {
                C_Maps.Map.Tileset = 1;
            }
            if (C_Maps.Map.Tileset > C_Graphics.NumTileSets)
            {
                C_Maps.Map.Tileset = 1;
            }

            C_Constants.EditorTileSelStart = new Point(0, 0);
            C_Constants.EditorTileSelEnd = new Point(1, 1);

            // set the scrollbars
            scrlPictureY.Maximum = (int)((picBackSelect.Height / C_Constants.PicY) / 2); // \2 is new, lets test
            scrlPictureX.Maximum = (int)((picBackSelect.Width / C_Constants.PicX) / 2);

            // set shops for the shop attribute
            cmbShop.Items.Add("None");
            for (var i = 1; i <= Constants.MAX_SHOPS; i++)
            {
                cmbShop.Items.Add(i + ": " + Types.Shop[(int)i].Name);
            }
            // we're not in a shop
            cmbShop.SelectedIndex = 0;

            optBlocked.Checked = true;

            cmbTileSets.Items.Clear();
            for (var i = 1; i <= C_Graphics.NumTileSets; i++)
            {
                cmbTileSets.Items.Add("Tileset " + System.Convert.ToString(i));
            }

            cmbTileSets.SelectedIndex = 0;
            cmbLayers.SelectedIndex = 0;

            C_UpdateUI.InitMapProperties = true;

            if (C_Variables.MapData == true)
            {
                C_Variables.GettingMap = false;
            }

        }

        public void MapEditorTileScroll()
        {
            picBackSelect.Top = (scrlPictureY.Value * C_Constants.PicY) * -1;
            picBackSelect.Left = (scrlPictureX.Value * C_Constants.PicX) * -1;
        }

        public void MapEditorChooseTile(int Button, float X, float Y)
        {

            if (Button == (int)MouseButtons.Left) //Left Mouse Button
            {

                C_Constants.EditorTileWidth = 1;
                C_Constants.EditorTileHeight = 1;

                if (cmbAutoTile.SelectedIndex > 0)
                {
                    if ((int)cmbAutoTile.SelectedIndex == 1) // autotile
                    {
                        C_Constants.EditorTileWidth = 2;
                        C_Constants.EditorTileHeight = 3;
                    } // fake autotile
                    else if ((int)cmbAutoTile.SelectedIndex == 2)
                    {
                        C_Constants.EditorTileWidth = 1;
                        C_Constants.EditorTileHeight = 1;
                    } // animated
                    else if ((int)cmbAutoTile.SelectedIndex == 3)
                    {
                        C_Constants.EditorTileWidth = 6;
                        C_Constants.EditorTileHeight = 3;
                    } // cliff
                    else if ((int)cmbAutoTile.SelectedIndex == 4)
                    {
                        C_Constants.EditorTileWidth = 2;
                        C_Constants.EditorTileHeight = 2;
                    } // waterfall
                    else if ((int)cmbAutoTile.SelectedIndex == 5)
                    {
                        C_Constants.EditorTileWidth = 2;
                        C_Constants.EditorTileHeight = 3;
                    }
                }

                C_Constants.EditorTileX = (int)(X / C_Constants.PicX);
                C_Constants.EditorTileY = (int)(Y / C_Constants.PicY);

                C_Constants.EditorTileSelStart = new Point(C_Constants.EditorTileX, C_Constants.EditorTileY);
                C_Constants.EditorTileSelEnd = new Point(C_Constants.EditorTileX + C_Constants.EditorTileWidth, C_Constants.EditorTileY + C_Constants.EditorTileHeight);

            }

        }

        public void MapEditorDrag(int Button, float X, float Y)
        {

            if (Button == (int)MouseButtons.Left) //Left Mouse Button
            {
                // convert the pixel number to tile number
                X = System.Convert.ToSingle((X / C_Constants.PicX) + 1);
                Y = System.Convert.ToSingle((Y / C_Constants.PicY) + 1);
                // check it's not out of bounds
                if (X < 0)
                {
                    X = 0;
                }
                if (X > (double)picBackSelect.Width / C_Constants.PicX)
                {
                    X = (float)((double)picBackSelect.Width / C_Constants.PicX);
                }
                if (Y < 0)
                {
                    Y = 0;
                }
                if (Y > (double)picBackSelect.Height / C_Constants.PicY)
                {
                    Y = (float)((double)picBackSelect.Height / C_Constants.PicY);
                }
                // find out what to set the width + height of map editor to
                if (X > C_Constants.EditorTileX) // drag right
                {
                    //EditorTileWidth = X
                    if ((int)(X - C_Constants.EditorTileX) < 1)
                    {
                        C_Constants.EditorTileWidth = 1;
                    }
                    else
                    {
                        C_Constants.EditorTileWidth = (int)(X - C_Constants.EditorTileX);
                    }
                }
                else // drag left
                {
                    // TO DO
                }
                if (Y > C_Constants.EditorTileY) // drag down
                {
                    //EditorTileHeight = Y
                    if ((int)(Y - C_Constants.EditorTileY) < 1)
                    {
                        C_Constants.EditorTileHeight = 1;
                    }
                    else
                    {
                        C_Constants.EditorTileHeight = (int)(Y - C_Constants.EditorTileY);
                    }
                }
                else // drag up
                {
                    // TO DO
                }

                C_Constants.EditorTileSelStart = new Point(C_Constants.EditorTileX, C_Constants.EditorTileY);
                C_Constants.EditorTileSelEnd = new Point(C_Constants.EditorTileWidth, C_Constants.EditorTileHeight);
            }

        }

        public void MapEditorMouseDown(int Button, int X, int Y, bool movedMouse = true)
        {
            int i = 0;
            int CurLayer = 0;

            CurLayer = (int)(cmbLayers.SelectedIndex + 1);

            if (!C_GameLogic.IsInBounds())
            {
                return;
            }
            if (Button == (int)MouseButtons.Left)
            {
                if (ReferenceEquals(tabpages.SelectedTab, tpTiles))
                {
                    if (C_Constants.EditorTileWidth == 1 && C_Constants.EditorTileHeight == 1) //single tile
                    {

                        MapEditorSetTile(C_Variables.CurX, C_Variables.CurY, CurLayer, false, System.Convert.ToByte(cmbAutoTile.SelectedIndex));
                    }
                    else // multi tile!
                    {
                        if (cmbAutoTile.SelectedIndex == 0)
                        {
                            MapEditorSetTile(C_Variables.CurX, C_Variables.CurY, CurLayer, true);
                        }
                        else
                        {
                            MapEditorSetTile(X: C_Variables.CurX, Y: C_Variables.CurY, CurLayer: CurLayer, theAutotile: System.Convert.ToByte(cmbAutoTile.SelectedIndex));
                        }
                    }
                }
                else if (ReferenceEquals(tabpages.SelectedTab, tpAttributes))
                {
                    ref var with_1 = ref C_Maps.Map.Tile[C_Variables.CurX, C_Variables.CurY];
                    // blocked tile
                    if (optBlocked.Checked == true)
                    {
                        with_1.Type = (byte)Enums.TileType.Blocked;
                    }
                    // warp tile
                    if (optWarp.Checked == true)
                    {
                        with_1.Type = (byte)Enums.TileType.Warp;
                        with_1.Data1 = C_Constants.EditorWarpMap;
                        with_1.Data2 = C_Constants.EditorWarpX;
                        with_1.Data3 = C_Constants.EditorWarpY;
                    }
                    // item spawn
                    if (optItem.Checked == true)
                    {
                        with_1.Type = (byte)Enums.TileType.Item;
                        with_1.Data1 = C_Variables.ItemEditorNum;
                        with_1.Data2 = C_Variables.ItemEditorValue;
                        with_1.Data3 = 0;
                    }
                    // npc avoid
                    if (optNPCAvoid.Checked == true)
                    {
                        with_1.Type = (byte)Enums.TileType.NpcAvoid;
                        with_1.Data1 = 0;
                        with_1.Data2 = 0;
                        with_1.Data3 = 0;
                    }
                    // key
                    if (optKey.Checked == true)
                    {
                        with_1.Type = (byte)Enums.TileType.Key;
                        with_1.Data1 = C_Variables.KeyEditorNum;
                        with_1.Data2 = C_Variables.KeyEditorTake;
                        with_1.Data3 = 0;
                    }
                    // key open
                    if (optKeyOpen.Checked == true)
                    {
                        with_1.Type = (byte)Enums.TileType.KeyOpen;
                        with_1.Data1 = C_Variables.KeyOpenEditorX;
                        with_1.Data2 = C_Variables.KeyOpenEditorY;
                        with_1.Data3 = 0;
                    }
                    // resource
                    if (optResource.Checked == true)
                    {
                        with_1.Type = (byte)Enums.TileType.Resource;
                        with_1.Data1 = C_Variables.ResourceEditorNum;
                        with_1.Data2 = 0;
                        with_1.Data3 = 0;
                    }
                    // door
                    if (optDoor.Checked == true)
                    {
                        with_1.Type = (byte)Enums.TileType.Door;
                        with_1.Data1 = C_Constants.EditorWarpMap;
                        with_1.Data2 = C_Constants.EditorWarpX;
                        with_1.Data3 = C_Constants.EditorWarpY;
                    }
                    // npc spawn
                    if (optNPCSpawn.Checked == true)
                    {
                        with_1.Type = (byte)Enums.TileType.NpcSpawn;
                        with_1.Data1 = C_Variables.SpawnNpcNum;
                        with_1.Data2 = C_Variables.SpawnNpcDir;
                        with_1.Data3 = 0;
                    }
                    // shop
                    if (optShop.Checked == true)
                    {
                        with_1.Type = (byte)Enums.TileType.Shop;
                        with_1.Data1 = C_Constants.EditorShop;
                        with_1.Data2 = 0;
                        with_1.Data3 = 0;
                    }
                    // bank
                    if (optBank.Checked == true)
                    {
                        with_1.Type = (byte)Enums.TileType.Bank;
                        with_1.Data1 = 0;
                        with_1.Data2 = 0;
                        with_1.Data3 = 0;
                    }
                    // heal
                    if (optHeal.Checked == true)
                    {
                        with_1.Type = (byte)Enums.TileType.Heal;
                        with_1.Data1 = C_Variables.MapEditorHealType;
                        with_1.Data2 = C_Variables.MapEditorHealAmount;
                        with_1.Data3 = 0;
                    }
                    // trap
                    if (optTrap.Checked == true)
                    {
                        with_1.Type = (byte)Enums.TileType.Trap;
                        with_1.Data1 = C_Variables.MapEditorHealAmount;
                        with_1.Data2 = 0;
                        with_1.Data3 = 0;
                    }
                    //Housing
                    if (optHouse.Checked)
                    {
                        with_1.Type = (byte)Enums.TileType.House;
                        with_1.Data1 = C_Housing.HouseTileindex;
                        with_1.Data2 = 0;
                        with_1.Data3 = 0;
                    }
                    //craft tile
                    if (optCraft.Checked)
                    {
                        with_1.Type = (byte)Enums.TileType.Craft;
                        with_1.Data1 = 0;
                        with_1.Data2 = 0;
                        with_1.Data3 = 0;
                    }
                    //light
                    if (optLight.Checked)
                    {
                        with_1.Type = (byte)Enums.TileType.Light;
                        with_1.Data1 = 0;
                        with_1.Data2 = 0;
                        with_1.Data3 = 0;
                    }
                }
                else if (ReferenceEquals(tabpages.SelectedTab, tpDirBlock))
                {
                    if (movedMouse)
                    {
                        return;
                    }
                    // find what tile it is
                    X = X - ((X / C_Constants.PicX) * C_Constants.PicX);
                    Y = Y - ((Y / C_Constants.PicY) * C_Constants.PicY);
                    // see if it hits an arrow
                    for (i = 1; i <= 4; i++)
                    {
                        if (X >= C_Variables.DirArrowX[i] && X <= C_Variables.DirArrowX[i] + 8)
                        {
                            if (Y >= C_Variables.DirArrowY[i] && Y <= C_Variables.DirArrowY[i] + 8)
                            {
                                // flip the value.
                                C_GameLogic.SetDirBlock(ref C_Maps.Map.Tile[C_Variables.CurX, C_Variables.CurY].DirBlock, (byte)(i), !C_GameLogic.IsDirBlocked(C_Maps.Map.Tile[C_Variables.CurX, C_Variables.CurY].DirBlock, (byte)(i)));
                                return;
                            }
                        }
                    }
                }
                else if (ReferenceEquals(tabpages.SelectedTab, tpEvents))
                {
                    if (FrmEditor_Events.Default.Visible == false)
                    {
                        if (C_EventSystem.EventCopy)
                        {
                            C_EventSystem.CopyEvent_Map(C_Variables.CurX, C_Variables.CurY);
                        }
                        else if (C_EventSystem.EventPaste)
                        {
                            C_EventSystem.PasteEvent_Map(C_Variables.CurX, C_Variables.CurY);
                        }
                        else
                        {
                            C_EventSystem.AddEvent(C_Variables.CurX, C_Variables.CurY);
                        }
                    }
                }
            }

            if (Button == (int)MouseButtons.Right)
            {
                if (ReferenceEquals(tabpages.SelectedTab, tpTiles))
                {

                    ref var with_2 = ref C_Maps.Map.Tile[C_Variables.CurX, C_Variables.CurY];
                    // clear layer
                    with_2.Layer[CurLayer].X = 0;
                    with_2.Layer[CurLayer].Y = 0;
                    with_2.Layer[CurLayer].Tileset = 0;
                    if (with_2.Layer[CurLayer].AutoTile > 0)
                    {
                        with_2.Layer[CurLayer].AutoTile = 0;
                        // do a re-init so we can see our changes
                        C_AutoTiles.InitAutotiles();
                    }
                    C_AutoTiles.CacheRenderState(X, Y, CurLayer);

                }
                else if (ReferenceEquals(tabpages.SelectedTab, tpAttributes))
                {
                    ref var with_3 = ref C_Maps.Map.Tile[C_Variables.CurX, C_Variables.CurY];
                    // clear attribute
                    with_3.Type = 0;
                    with_3.Data1 = 0;
                    with_3.Data2 = 0;
                    with_3.Data3 = 0;
                }
                else if (ReferenceEquals(tabpages.SelectedTab, tpEvents))
                {
                    C_EventSystem.DeleteEvent(C_Variables.CurX, C_Variables.CurY);
                }
            }

        }

        public void MapEditorCancel()
        {
            ByteStream Buffer = new ByteStream();
            Buffer = new ByteStream(4);
            Buffer.WriteInt32((System.Int32)Packets.ClientPackets.CNeedMap);
            Buffer.WriteInt32(1);
            C_NetworkConfig.Socket.SendData(Buffer.Data, Buffer.Head);
            C_Constants.InMapEditor = false;
            Visible = false;
            C_Variables.GettingMap = true;
        }

        public void MapEditorSend()
        {
            C_Maps.SendMap();
            C_Constants.InMapEditor = false;
            Visible = false;
            C_Variables.GettingMap = true;
        }

        public void MapEditorSetTile(int X, int Y, int CurLayer, bool multitile = false, byte theAutotile = 0)
        {
            int x2 = 0;
            int y2 = 0;

            if (theAutotile > 0)
            {
                ref var with_1 = ref C_Maps.Map.Tile[X, Y];
                // set layer
                with_1.Layer[CurLayer].X = (byte)C_Constants.EditorTileX;
                with_1.Layer[CurLayer].Y = (byte)C_Constants.EditorTileY;
                with_1.Layer[CurLayer].Tileset = (byte)(cmbTileSets.SelectedIndex + 1);
                with_1.Layer[CurLayer].AutoTile = theAutotile;
                C_AutoTiles.CacheRenderState(X, Y, CurLayer);
                // do a re-init so we can see our changes
                C_AutoTiles.InitAutotiles();
                return;
            }

            if (!multitile) // single
            {
                ref var with_2 = ref C_Maps.Map.Tile[X, Y];
                // set layer
                with_2.Layer[CurLayer].X = (byte)C_Constants.EditorTileX;
                with_2.Layer[CurLayer].Y = (byte)C_Constants.EditorTileY;
                with_2.Layer[CurLayer].Tileset = (byte)(cmbTileSets.SelectedIndex + 1);
                with_2.Layer[CurLayer].AutoTile = 0;
                C_AutoTiles.CacheRenderState(X, Y, CurLayer);
            }
            else // multitile
            {
                y2 = 0; // starting tile for y axis
                for (var Yy = C_Variables.CurY; Yy <= C_Variables.CurY + C_Constants.EditorTileHeight - 1; Yy++)
                {
                    x2 = 0; // re-set x count every y loop
                    for (var Xx = C_Variables.CurX; Xx <= C_Variables.CurX + C_Constants.EditorTileWidth - 1; Xx++)
                    {
                        if (Xx >= 0 && Xx <= C_Maps.Map.MaxX)
                        {
                            if (Yy >= 0 && Yy <= C_Maps.Map.MaxY)
                            {
                                ref var with_3 = ref C_Maps.Map.Tile[(int)Xx, (int)Yy];
                                with_3.Layer[CurLayer].X = (byte)(C_Constants.EditorTileX + x2);
                                with_3.Layer[CurLayer].Y = (byte)(C_Constants.EditorTileY + y2);
                                with_3.Layer[CurLayer].Tileset = (byte)(cmbTileSets.SelectedIndex + 1);
                                with_3.Layer[CurLayer].AutoTile = 0;
                                C_AutoTiles.CacheRenderState(Xx, Yy, CurLayer);
                            }
                        }
                        x2++;
                    }
                    y2++;
                }
            }
        }

        public void MapEditorClearLayer()
        {
            int X = 0;
            int Y = 0;
            int CurLayer = 0;

            CurLayer = (int)(cmbLayers.SelectedIndex + 1);

            if (CurLayer == 0)
            {
                return;
            }

            // ask to clear layer
            if (Interaction.MsgBox("Are you sure you wish to clear this layer?", Microsoft.VisualBasic.Constants.vbYesNo, "MapEditor") == Microsoft.VisualBasic.Constants.vbYes)
            {
                for (X = 0; X <= C_Maps.Map.MaxX; X++)
                {
                    for (Y = 0; Y <= C_Maps.Map.MaxY; Y++)
                    {
                        ref var with_1 = ref C_Maps.Map.Tile[X, Y];
                        with_1.Layer[CurLayer].X = 0;
                        with_1.Layer[CurLayer].Y = 0;
                        with_1.Layer[CurLayer].Tileset = 0;
                        with_1.Layer[CurLayer].AutoTile = 0;
                        C_AutoTiles.CacheRenderState(X, Y, CurLayer);
                    }
                }
            }
        }

        public void MapEditorFillLayer(byte theAutotile = 0)
        {
            int X = 0;
            int Y = 0;
            int CurLayer = 0;

            CurLayer = (int)(cmbLayers.SelectedIndex + 1);

            if (Interaction.MsgBox("Are you sure you wish to fill this layer?", Microsoft.VisualBasic.Constants.vbYesNo, "Map Editor") == Microsoft.VisualBasic.Constants.vbYes)
            {
                if (theAutotile > 0)
                {
                    for (X = 0; X <= C_Maps.Map.MaxX; X++)
                    {
                        for (Y = 0; Y <= C_Maps.Map.MaxY; Y++)
                        {
                            C_Maps.Map.Tile[X, Y].Layer[CurLayer].X = (byte)C_Constants.EditorTileX;
                            C_Maps.Map.Tile[X, Y].Layer[CurLayer].Y = (byte)C_Constants.EditorTileY;
                            C_Maps.Map.Tile[X, Y].Layer[CurLayer].Tileset = System.Convert.ToByte(cmbTileSets.SelectedIndex + 1);
                            C_Maps.Map.Tile[X, Y].Layer[CurLayer].AutoTile = theAutotile;
                            C_AutoTiles.CacheRenderState(X, Y, CurLayer);
                        }
                    }

                    // do a re-init so we can see our changes
                    C_AutoTiles.InitAutotiles();
                }
                else
                {
                    for (X = 0; X <= C_Maps.Map.MaxX; X++)
                    {
                        for (Y = 0; Y <= C_Maps.Map.MaxY; Y++)
                        {
                            C_Maps.Map.Tile[X, Y].Layer[CurLayer].X = (byte)C_Constants.EditorTileX;
                            C_Maps.Map.Tile[X, Y].Layer[CurLayer].Y = (byte)C_Constants.EditorTileY;
                            C_Maps.Map.Tile[X, Y].Layer[CurLayer].Tileset = System.Convert.ToByte(cmbTileSets.SelectedIndex + 1);
                            C_AutoTiles.CacheRenderState(X, Y, CurLayer);
                        }
                    }
                }
            }
        }

        public void ClearAttributeDialogue()
        {

            fraNpcSpawn.Visible = false;
            fraResource.Visible = false;
            fraMapItem.Visible = false;
            fraMapKey.Visible = false;
            fraKeyOpen.Visible = false;
            fraMapWarp.Visible = false;
            fraShop.Visible = false;
            fraHeal.Visible = false;
            fraTrap.Visible = false;
            fraBuyHouse.Visible = false;

        }

        public void MapEditorClearAttribs()
        {
            int X = 0;
            int Y = 0;

            if (Interaction.MsgBox("Are you sure you wish to clear the attributes on this map?", Microsoft.VisualBasic.Constants.vbYesNo, "MapEditor") == Microsoft.VisualBasic.Constants.vbYes)
            {

                for (X = 0; X <= C_Maps.Map.MaxX; X++)
                {
                    for (Y = 0; Y <= C_Maps.Map.MaxY; Y++)
                    {
                        C_Maps.Map.Tile[X, Y].Type = (byte)0;
                    }
                }

            }

        }

        public void MapEditorLeaveMap()
        {

            if (C_Constants.InMapEditor)
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

        #region Drawing

        public void EditorMap_DrawTileset3() {

            int height;
            int width;
            byte tileset;

            // find tileset number
            tileset = System.Convert.ToByte(this.cmbTileSets.SelectedIndex + 1);

            // exit out if doesn't exist
            if (tileset <= 0 || tileset > C_Graphics.NumTileSets)
            {
                return;
            }

            // Draw the tileset into memory

            C_Graphics.TileSetImgsGFX[tileset] = new Bitmap(Application.StartupPath + C_Constants.GfxPath + "tilesets\\" + tileset + C_Constants.GfxExt);


            height = C_Graphics.TileSetImgsGFX[tileset].Height;

            width = C_Graphics.TileSetImgsGFX[tileset].Width;

            C_Graphics.MapEditorBackBuffer = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(C_Graphics.MapEditorBackBuffer);

            g.FillRectangle(Brushes.Black, new Rectangle(0, 0, C_Graphics.MapEditorBackBuffer.Width, C_Graphics.MapEditorBackBuffer.Height)); ;

            picBackSelect.Height = height;
            picBackSelect.Width = width;

            // change selected shape for autotiles
            if (this.cmbAutoTile.SelectedIndex > 0)
            {
                // autotile
                if ((int)this.cmbAutoTile.SelectedIndex == 1) 
                {
                    C_Constants.EditorTileWidth = 2;
                    C_Constants.EditorTileHeight = 3;
                } 
                // fake autotile
                else if ((int)this.cmbAutoTile.SelectedIndex == 2)
                {
                    C_Constants.EditorTileWidth = 1;
                    C_Constants.EditorTileHeight = 1;
                } 
                // animated
                else if ((int)this.cmbAutoTile.SelectedIndex == 3)
                {
                    C_Constants.EditorTileWidth = 6;
                    C_Constants.EditorTileHeight = 3;
                } 
                // cliff
                else if ((int)this.cmbAutoTile.SelectedIndex == 4)
                {
                    C_Constants.EditorTileWidth = 2;
                    C_Constants.EditorTileHeight = 2;
                } 
                // waterfall
                else if ((int)this.cmbAutoTile.SelectedIndex == 5)
                {
                    C_Constants.EditorTileWidth = 2;
                    C_Constants.EditorTileHeight = 3;
                }
                else
                {
                    C_Constants.EditorTileWidth = 1;
                    C_Constants.EditorTileHeight = 1;
                }
            }

            g.DrawImage(C_Graphics.TileSetImgsGFX[tileset], new Rectangle(0, 0, C_Graphics.TileSetImgsGFX[tileset].Width, C_Graphics.TileSetImgsGFX[tileset].Height));

            g.DrawRectangle(Pens.Red, new Rectangle(C_Constants.EditorTileSelStart.X * C_Constants.PicX, C_Constants.EditorTileSelStart.Y * C_Constants.PicY, (C_Constants.EditorTileSelEnd.X - C_Constants.EditorTileSelStart.X) * C_Constants.PicX, (C_Constants.EditorTileSelEnd.Y - C_Constants.EditorTileSelStart.Y) * C_Constants.PicX));

            g.Dispose();

            g = picBackSelect.CreateGraphics();

            g.DrawImage(C_Graphics.MapEditorBackBuffer, new Rectangle(0, 0, width, height));

            g.Dispose();
    }

        public void EditorMap_DrawTileset()
		{
			int height = 0;
			int width = 0;
			byte tileset = 0;
			
			C_Graphics.TilesetWindow.DispatchEvents();
			C_Graphics.TilesetWindow.Clear(SFML.Graphics.Color.Black);
			
			// find tileset number
			tileset = (byte)(this.cmbTileSets.SelectedIndex + 1);
			
			// exit out if doesn't exist
			if (tileset <= 0 || tileset > C_Graphics.NumTileSets)
			{
				return;
			}
			
			RectangleShape rec2 = new RectangleShape() {
					OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.Red),
					OutlineThickness = 0.6F,
					FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
				};
			
			if (C_Graphics.TileSetTextureInfo[tileset].IsLoaded == false)
			{
				C_Graphics.LoadTexture(tileset, (byte) 1);
			}
			// we use it, lets update timer
            C_Graphics.TileSetTextureInfo[tileset].TextureTimer = C_General.GetTickCount() + 100000;
			
			height = C_Graphics.TileSetTextureInfo[tileset].Height;
			width = C_Graphics.TileSetTextureInfo[tileset].Width;
			this.picBackSelect.Height = height;
			this.picBackSelect.Width = width;
			
			C_Graphics.TilesetWindow.SetView(new SFML.Graphics.View(new FloatRect(0, 0, width, height)));
			
			// change selected shape for autotiles
			if (this.cmbAutoTile.SelectedIndex > 0)
			{
				if ((int) this.cmbAutoTile.SelectedIndex == 1) // autotile
				{
					C_Constants.EditorTileWidth = 2;
					C_Constants.EditorTileHeight = 3;
				} // fake autotile
				else if ((int) this.cmbAutoTile.SelectedIndex == 2)
				{
					C_Constants.EditorTileWidth = 1;
					C_Constants.EditorTileHeight = 1;
				} // animated
				else if ((int) this.cmbAutoTile.SelectedIndex == 3)
				{
					C_Constants.EditorTileWidth = 6;
					C_Constants.EditorTileHeight = 3;
				} // cliff
				else if ((int) this.cmbAutoTile.SelectedIndex == 4)
				{
					C_Constants.EditorTileWidth = 2;
					C_Constants.EditorTileHeight = 2;
				} // waterfall
				else if ((int) this.cmbAutoTile.SelectedIndex == 5)
				{
					C_Constants.EditorTileWidth = 2;
					C_Constants.EditorTileHeight = 3;
				}
				else
				{
					C_Constants.EditorTileWidth = 1;
					C_Constants.EditorTileHeight = 1;
				}
			}
			
			C_Graphics.RenderSprite(C_Graphics.TileSetSprite[tileset], C_Graphics.TilesetWindow, 0, 0, 0, 0, width, height);
			
			rec2.Size = new Vector2f(C_Constants.EditorTileWidth * C_Constants.PicX, C_Constants.EditorTileHeight * C_Constants.PicY);
			
			rec2.Position = new Vector2f(C_Constants.EditorTileSelStart.X * C_Constants.PicX, C_Constants.EditorTileSelStart.Y * C_Constants.PicY);
			C_Graphics.TilesetWindow.Draw(rec2);
			
			//and finally show everything on screen
			C_Graphics.TilesetWindow.Display();
			
			C_Variables.LastTileset = tileset;
		}
		
		public void EditorMap_DrawMapItem()
		{
			int itemnum = 0;
			itemnum = Types.Item[this.scrlMapItem.Value].Pic;
			
			if (itemnum < 1 || itemnum > C_Graphics.NumItems)
			{
				this.picMapItem.BackgroundImage = null;
				return;
			}
			
			if (File.Exists(Application.StartupPath + C_Constants.GfxPath + "items\\" + System.Convert.ToString(itemnum) + C_Constants.GfxExt))
			{
				this.picMapItem.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + C_Constants.GfxPath + "items\\" + System.Convert.ToString(itemnum) + C_Constants.GfxExt);
			}
			
		}
		
		public void EditorMap_DrawKey()
		{
			int itemnum = 0;
			
			itemnum = Types.Item[this.scrlMapKey.Value].Pic;
			
			if (itemnum < 1 || itemnum > C_Graphics.NumItems)
			{
				this.picMapKey.BackgroundImage = null;
				return;
			}
			
			if (File.Exists(Application.StartupPath + C_Constants.GfxPath + "items\\" + System.Convert.ToString(itemnum) + C_Constants.GfxExt))
			{
				this.picMapKey.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + C_Constants.GfxPath + "items\\" + System.Convert.ToString(itemnum) + C_Constants.GfxExt);
			}
			
		}
		
		internal void DrawTileOutline()
		{
			Rectangle rec = new Rectangle();
			if (ReferenceEquals(this.tabpages.SelectedTab, this.tpDirBlock))
			{
				return;
			}
			
			rec.Y = 0;
			rec.Height = C_Constants.PicY;
			rec.X = 0;
			rec.Width = C_Constants.PicX;
			
			RectangleShape rec2 = new RectangleShape() {
					OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.Blue),
					OutlineThickness = 0.6F,
					FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
				};
			
			if (ReferenceEquals(this.tabpages.SelectedTab, this.tpAttributes))
			{
				rec2.Size = new Vector2f(rec.Width, rec.Height);
			}
			else
			{
				if (C_Graphics.TileSetTextureInfo[this.cmbTileSets.SelectedIndex + 1].IsLoaded == false)
				{
					C_Graphics.LoadTexture((int)(this.cmbTileSets.SelectedIndex + 1), (byte) 1);
				}
				// we use it, lets update timer
				ref var with_2 = ref C_Graphics.TileSetTextureInfo[this.cmbTileSets.SelectedIndex + 1];
				with_2.TextureTimer = C_General.GetTickCount() + 100000;
				
				if (C_Constants.EditorTileWidth == 1 && C_Constants.EditorTileHeight == 1)
				{
					C_Graphics.RenderSprite(C_Graphics.TileSetSprite[this.cmbTileSets.SelectedIndex + 1], C_Graphics.GameWindow, C_Graphics.ConvertMapX(C_Variables.CurX * C_Constants.PicX), C_Graphics.ConvertMapY(C_Variables.CurY * C_Constants.PicY), C_Constants.EditorTileSelStart.X * C_Constants.PicX, C_Constants.EditorTileSelStart.Y * C_Constants.PicY, rec.Width, rec.Height);
					
					rec2.Size = new Vector2f(rec.Width, rec.Height);
				}
				else
				{
					if (this.cmbAutoTile.SelectedIndex > 0)
					{
						C_Graphics.RenderSprite(C_Graphics.TileSetSprite[this.cmbTileSets.SelectedIndex + 1], C_Graphics.GameWindow, C_Graphics.ConvertMapX(C_Variables.CurX * C_Constants.PicX), C_Graphics.ConvertMapY(C_Variables.CurY * C_Constants.PicY), C_Constants.EditorTileSelStart.X * C_Constants.PicX, C_Constants.EditorTileSelStart.Y * C_Constants.PicY, rec.Width, rec.Height);
						
						rec2.Size = new Vector2f(rec.Width, rec.Height);
					}
					else
					{
						C_Graphics.RenderSprite(C_Graphics.TileSetSprite[this.cmbTileSets.SelectedIndex + 1], C_Graphics.GameWindow, C_Graphics.ConvertMapX(C_Variables.CurX * C_Constants.PicX), C_Graphics.ConvertMapY(C_Variables.CurY * C_Constants.PicY), C_Constants.EditorTileSelStart.X * C_Constants.PicX, C_Constants.EditorTileSelStart.Y * C_Constants.PicY, C_Constants.EditorTileSelEnd.X * C_Constants.PicX, C_Constants.EditorTileSelEnd.Y * C_Constants.PicY);
						
						rec2.Size = new Vector2f(C_Constants.EditorTileSelEnd.X * C_Constants.PicX, C_Constants.EditorTileSelEnd.Y * C_Constants.PicY);
					}
					
				}
				
			}
			
			rec2.Position = new Vector2f(C_Graphics.ConvertMapX(C_Variables.CurX * C_Constants.PicX), C_Graphics.ConvertMapY(C_Variables.CurY * C_Constants.PicY));
			C_Graphics.GameWindow.Draw(rec2);
		}

        #endregion
    }
}
