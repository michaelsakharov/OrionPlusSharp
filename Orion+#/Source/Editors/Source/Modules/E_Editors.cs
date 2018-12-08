using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.IO;

namespace Engine
{
    static class E_Editors
    {
        internal static void AnimationEditorInit()
        {
            if (My.MyProject.Forms.FrmAnimation.Visible == false)
                return;

            E_Globals.Editorindex = My.MyProject.Forms.FrmAnimation.lstIndex.SelectedIndex + 1;

            {
                var withBlock = Types.Animation[E_Globals.Editorindex];

                // find the music we have set
                My.MyProject.Forms.FrmAnimation.cmbSound.Items.Clear();
                My.MyProject.Forms.FrmAnimation.cmbSound.Items.Add("None");

                if (Information.UBound(E_Sound.SoundCache) > 0)
                {
                    var loopTo = Information.UBound(E_Sound.SoundCache);
                    for (var i = 1; i <= loopTo; i++)
                        My.MyProject.Forms.FrmAnimation.cmbSound.Items.Add(E_Sound.SoundCache[i]);
                }

                if (Microsoft.VisualBasic.Strings.Trim(Types.Animation[E_Globals.Editorindex].Sound) == "None" || Microsoft.VisualBasic.Strings.Trim(Types.Animation[E_Globals.Editorindex].Sound) == "")
                    My.MyProject.Forms.FrmAnimation.cmbSound.SelectedIndex = 0;
                else
                {
                    var loopTo1 = My.MyProject.Forms.FrmAnimation.cmbSound.Items.Count;
                    for (var i = 1; i <= loopTo1; i++)
                    {
                        if (My.MyProject.Forms.FrmAnimation.cmbSound.Items[i - 1].ToString() == Microsoft.VisualBasic.Strings.Trim(withBlock.Sound))
                        {
                            My.MyProject.Forms.FrmAnimation.cmbSound.SelectedIndex = i - 1;
                            break;
                        }
                    }
                }
                My.MyProject.Forms.FrmAnimation.txtName.Text = Microsoft.VisualBasic.Strings.Trim(withBlock.Name);

                My.MyProject.Forms.FrmAnimation.nudSprite0.Value = withBlock.Sprite[0];
                My.MyProject.Forms.FrmAnimation.nudFrameCount0.Value = withBlock.Frames[0];
                My.MyProject.Forms.FrmAnimation.nudLoopCount0.Value = withBlock.LoopCount[0];
                My.MyProject.Forms.FrmAnimation.nudLoopTime0.Value = withBlock.LoopTime[0];

                My.MyProject.Forms.FrmAnimation.nudSprite1.Value = withBlock.Sprite[1];
                My.MyProject.Forms.FrmAnimation.nudFrameCount1.Value = withBlock.Frames[1];
                My.MyProject.Forms.FrmAnimation.nudLoopCount1.Value = withBlock.LoopCount[1];
                My.MyProject.Forms.FrmAnimation.nudLoopTime1.Value = withBlock.LoopTime[1];

                E_Globals.Editorindex = My.MyProject.Forms.FrmAnimation.lstIndex.SelectedIndex + 1;
            }

            E_Graphics.EditorAnim_DrawAnim();
            E_Globals.Animation_Changed[E_Globals.Editorindex] = true;
        }

        internal static void AnimationEditorOk()
        {
            int i;

            for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
            {
                if (E_Globals.Animation_Changed[i])
                    E_NetworkSend.SendSaveAnimation(i);
            }

            My.MyProject.Forms.FrmAnimation.Visible = false;
            E_Globals.Editor = 0;
            ClearChanged_Animation();
        }

        internal static void AnimationEditorCancel()
        {
            E_Globals.Editor = 0;
            My.MyProject.Forms.FrmAnimation.Visible = false;
            ClearChanged_Animation();
            ClientDataBase.ClearAnimations();
            E_NetworkSend.SendRequestAnimations();
        }

        internal static void ClearChanged_Animation()
        {
            for (var i = 0; i <= Constants.MAX_ANIMATIONS; i++)
                E_Globals.Animation_Changed[i] = false;
        }



        internal static void MapPropertiesInit()
        {
            int X;
            int Y;
            int i;

            My.MyProject.Forms.frmMapEditor.txtName.Text = Microsoft.VisualBasic.Strings.Trim(E_Types.Map.Name);

            // find the music we have set
            My.MyProject.Forms.frmMapEditor.lstMusic.Items.Clear();
            My.MyProject.Forms.frmMapEditor.lstMusic.Items.Add("None");

            if (Information.UBound(E_Sound.MusicCache) > 0)
            {
                var loopTo = Information.UBound(E_Sound.MusicCache);
                for (i = 1; i <= loopTo; i++)
                    My.MyProject.Forms.frmMapEditor.lstMusic.Items.Add(E_Sound.MusicCache[i]);
            }

            if (Microsoft.VisualBasic.Strings.Trim(E_Types.Map.Music) == "None")
                My.MyProject.Forms.frmMapEditor.lstMusic.SelectedIndex = 0;
            else
            {
                var loopTo1 = My.MyProject.Forms.frmMapEditor.lstMusic.Items.Count;
                for (i = 1; i <= loopTo1; i++)
                {
                    if (My.MyProject.Forms.frmMapEditor.lstMusic.Items[i - 1].ToString() == Microsoft.VisualBasic.Strings.Trim(E_Types.Map.Music))
                    {
                        My.MyProject.Forms.frmMapEditor.lstMusic.SelectedIndex = i - 1;
                        break;
                    }
                }
            }

            // rest of it
            My.MyProject.Forms.frmMapEditor.nudUp.Value = E_Types.Map.Up;
            My.MyProject.Forms.frmMapEditor.nudDown.Value = E_Types.Map.Down;
            My.MyProject.Forms.frmMapEditor.nudLeft.Value = E_Types.Map.Left;
            My.MyProject.Forms.frmMapEditor.nudRight.Value = E_Types.Map.Right;
            My.MyProject.Forms.frmMapEditor.cmbMoral.SelectedIndex = E_Types.Map.Moral;
            My.MyProject.Forms.frmMapEditor.nudSpawnMap.Value = E_Types.Map.BootMap;
            My.MyProject.Forms.frmMapEditor.nudSpawnX.Value = E_Types.Map.BootX;
            My.MyProject.Forms.frmMapEditor.nudSpawnY.Value = E_Types.Map.BootY;

            if (E_Types.Map.Instanced == 1)
                My.MyProject.Forms.frmMapEditor.chkInstance.Checked = true;
            else
                My.MyProject.Forms.frmMapEditor.chkInstance.Checked = false;

            My.MyProject.Forms.frmMapEditor.lstMapNpc.Items.Clear();

            for (X = 1; X <= Constants.MAX_MAP_NPCS; X++)
            {
                if (E_Types.Map.Npc[X] == 0)
                    My.MyProject.Forms.frmMapEditor.lstMapNpc.Items.Add("No NPC");
                else
                    My.MyProject.Forms.frmMapEditor.lstMapNpc.Items.Add(X + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[E_Types.Map.Npc[X]].Name));
            }

            My.MyProject.Forms.frmMapEditor.cmbNpcList.Items.Clear();
            My.MyProject.Forms.frmMapEditor.cmbNpcList.Items.Add("No NPC");

            for (Y = 1; Y <= Constants.MAX_NPCS; Y++)
                My.MyProject.Forms.frmMapEditor.cmbNpcList.Items.Add(Y + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[Y].Name));

            My.MyProject.Forms.frmMapEditor.lblMap.Text = "Current Map: " + E_Types.Map.mapNum;
            My.MyProject.Forms.frmMapEditor.nudMaxX.Value = E_Types.Map.MaxX;
            My.MyProject.Forms.frmMapEditor.nudMaxY.Value = E_Types.Map.MaxY;

            My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex = 0;
            My.MyProject.Forms.frmMapEditor.cmbLayers.SelectedIndex = 0;
            My.MyProject.Forms.frmMapEditor.cmbAutoTile.SelectedIndex = 0;

            My.MyProject.Forms.frmMapEditor.cmbWeather.SelectedIndex = E_Types.Map.WeatherType;
            My.MyProject.Forms.frmMapEditor.nudFog.Value = E_Types.Map.Fogindex;
            My.MyProject.Forms.frmMapEditor.nudIntensity.Value = E_Types.Map.WeatherIntensity;

            E_Globals.SelectedTab = 1;

            E_Graphics.GameWindow.SetView(new SFML.Graphics.View(new SFML.Graphics.FloatRect(0, 0, My.MyProject.Forms.frmMapEditor.picScreen.Width, My.MyProject.Forms.frmMapEditor.picScreen.Height)));

            My.MyProject.Forms.frmMapEditor.tslCurMap.Text = "Map: " + E_Types.Map.mapNum;

            // show the form
            My.MyProject.Forms.frmMapEditor.Visible = true;

            E_Globals.GameStarted = true;

            My.MyProject.Forms.frmMapEditor.picScreen.Focus();

            E_Globals.InitMapEditor = false;
        }

        internal static void MapEditorInit()
        {
            // we're in the map editor
            E_Globals.InMapEditor = true;

            // set the scrolly bars
            if (E_Types.Map.tileset == 0)
                E_Types.Map.tileset = 1;
            if (E_Types.Map.tileset > E_Graphics.NumTileSets)
                E_Types.Map.tileset = 1;

            E_Globals.EditorTileSelStart = new Point(0, 0);
            E_Globals.EditorTileSelEnd = new Point(1, 1);

            // clear memory
            // ReDim TileSetImgsLoaded(NumTileSets)
            // For i = 0 To NumTileSets
            // TileSetImgsLoaded(i) = False
            // Next

            // set the scrollbars
            My.MyProject.Forms.frmMapEditor.scrlPictureY.Maximum = (My.MyProject.Forms.frmMapEditor.picBackSelect.Height / E_Globals.PIC_Y) / 2; // \2 is new, lets test
            My.MyProject.Forms.frmMapEditor.scrlPictureX.Maximum = (My.MyProject.Forms.frmMapEditor.picBackSelect.Width / E_Globals.PIC_X) / 2;

            // set map names
            My.MyProject.Forms.frmMapEditor.cmbMapList.Items.Clear();
            My.MyProject.Forms.FrmVisualWarp.lstMaps.Items.Clear();

            for (var i = 1; i <= Constants.MAX_MAPS; i++)
            {
                My.MyProject.Forms.frmMapEditor.cmbMapList.Items.Add(i + ": " + E_Types.MapNames[i]);
                My.MyProject.Forms.FrmVisualWarp.lstMaps.Items.Add(i + ": " + E_Types.MapNames[i]);
            }

            if (E_Types.Map.mapNum > 0)
                My.MyProject.Forms.frmMapEditor.cmbMapList.SelectedIndex = E_Types.Map.mapNum - 1;
            else
                My.MyProject.Forms.frmMapEditor.cmbMapList.SelectedIndex = 0;

            // set shops for the shop attribute
            My.MyProject.Forms.frmMapEditor.cmbShop.Items.Add("None");
            for (var i = 1; i <= Constants.MAX_SHOPS; i++)
                My.MyProject.Forms.frmMapEditor.cmbShop.Items.Add(i + ": " + Types.Shop[i].Name);
            // we're not in a shop
            My.MyProject.Forms.frmMapEditor.cmbShop.SelectedIndex = 0;

            My.MyProject.Forms.frmMapEditor.optBlocked.Checked = true;

            My.MyProject.Forms.frmMapEditor.cmbTileSets.Items.Clear();
            var loopTo = E_Graphics.NumTileSets;
            for (var i = 1; i <= loopTo; i++)
                My.MyProject.Forms.frmMapEditor.cmbTileSets.Items.Add("Tileset " + i);

            My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex = 0;
            My.MyProject.Forms.frmMapEditor.cmbLayers.SelectedIndex = 0;

            E_Globals.InitMapProperties = true;

            if (E_Globals.MapData == true)
                E_Globals.GettingMap = false;
        }

        internal static void MapEditorTileScroll()
        {
            My.MyProject.Forms.frmMapEditor.picBackSelect.Top = (My.MyProject.Forms.frmMapEditor.scrlPictureY.Value * E_Globals.PIC_Y) * -1;
            My.MyProject.Forms.frmMapEditor.picBackSelect.Left = (My.MyProject.Forms.frmMapEditor.scrlPictureX.Value * E_Globals.PIC_X) * -1;
        }

        internal static void MapEditorChooseTile(int Button, float X, float Y)
        {
            if (Button == (int)MouseButtons.Left)
            {
                E_Globals.EditorTileWidth = 1;
                E_Globals.EditorTileHeight = 1;

                if (My.MyProject.Forms.frmMapEditor.cmbAutoTile.SelectedIndex > 0)
                {
                    switch (My.MyProject.Forms.frmMapEditor.cmbAutoTile.SelectedIndex)
                    {
                        case 1 // autotile
                       :
                            {
                                E_Globals.EditorTileWidth = 2;
                                E_Globals.EditorTileHeight = 3;
                                break;
                            }

                        case 2 // fake autotile
                 :
                            {
                                E_Globals.EditorTileWidth = 1;
                                E_Globals.EditorTileHeight = 1;
                                break;
                            }

                        case 3 // animated
                 :
                            {
                                E_Globals.EditorTileWidth = 6;
                                E_Globals.EditorTileHeight = 3;
                                break;
                            }

                        case 4 // cliff
                 :
                            {
                                E_Globals.EditorTileWidth = 2;
                                E_Globals.EditorTileHeight = 2;
                                break;
                            }

                        case 5 // waterfall
                 :
                            {
                                E_Globals.EditorTileWidth = 2;
                                E_Globals.EditorTileHeight = 3;
                                break;
                            }
                    }
                }

                E_Globals.EditorTileX = (int)X / E_Globals.PIC_X;
                E_Globals.EditorTileY = (int)Y / E_Globals.PIC_Y;

                E_Globals.EditorTileSelStart = new Point(E_Globals.EditorTileX, E_Globals.EditorTileY);
                E_Globals.EditorTileSelEnd = new Point(E_Globals.EditorTileX + E_Globals.EditorTileWidth, E_Globals.EditorTileY + E_Globals.EditorTileHeight);
            }
        }

        internal static void MapEditorDrag(int Button, float X, float Y)
        {
            if (Button == (int)MouseButtons.Left)
            {
                // convert the pixel number to tile number
                X = (X / E_Globals.PIC_X) + 1;
                Y = (Y / E_Globals.PIC_Y) + 1;
                // check it's not out of bounds
                if (X < 0)
                    X = 0;
                if (X > My.MyProject.Forms.frmMapEditor.picBackSelect.Width / (int)E_Globals.PIC_X)
                    X = My.MyProject.Forms.frmMapEditor.picBackSelect.Width / (int)E_Globals.PIC_X;
                if (Y < 0)
                    Y = 0;
                if (Y > My.MyProject.Forms.frmMapEditor.picBackSelect.Height / (int)E_Globals.PIC_Y)
                    Y = My.MyProject.Forms.frmMapEditor.picBackSelect.Height / (int)E_Globals.PIC_Y;
                // find out what to set the width + height of map editor to
                if (X > E_Globals.EditorTileX)
                    // EditorTileWidth = X
                    E_Globals.EditorTileWidth = (int)X - E_Globals.EditorTileX;
                else
                {
                }
                if (Y > E_Globals.EditorTileY)
                    // EditorTileHeight = Y
                    E_Globals.EditorTileHeight = (int)Y - E_Globals.EditorTileY;
                else
                {
                }

                E_Globals.EditorTileSelStart = new Point(E_Globals.EditorTileX, E_Globals.EditorTileY);
                E_Globals.EditorTileSelEnd = new Point(E_Globals.EditorTileWidth, E_Globals.EditorTileHeight);
            }
        }

        internal static void MapEditorMouseDown(int Button, int X, int Y, bool movedMouse = true)
        {
            int i;
            int CurLayer;

            CurLayer = My.MyProject.Forms.frmMapEditor.cmbLayers.SelectedIndex + 1;

            if (!ClientDataBase.IsInBounds())
                return;
            if (Button == (int)MouseButtons.Left)
            {
                if (E_Globals.SelectedTab == 1)
                {
                    // (EditorTileSelEnd.X - EditorTileSelStart.X) = 1 AndAlso (EditorTileSelEnd.Y - EditorTileSelStart.Y) = 1 Then 'single tile
                    if (E_Globals.EditorTileWidth == 1 && E_Globals.EditorTileHeight == 1)
                        MapEditorSetTile(E_Globals.CurX, E_Globals.CurY, CurLayer, false, (byte)My.MyProject.Forms.frmMapEditor.cmbAutoTile.SelectedIndex);
                    else if (My.MyProject.Forms.frmMapEditor.cmbAutoTile.SelectedIndex == 0)
                        MapEditorSetTile(E_Globals.CurX, E_Globals.CurY, CurLayer, true);
                    else
                        MapEditorSetTile(E_Globals.CurX, E_Globals.CurY, CurLayer, theAutotile: (byte)My.MyProject.Forms.frmMapEditor.cmbAutoTile.SelectedIndex);
                }
                else if (E_Globals.SelectedTab == 2)
                {
                    {
                        var withBlock = E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY];
                        // blocked tile
                        if (My.MyProject.Forms.frmMapEditor.optBlocked.Checked == true)
                            withBlock.Type = (byte)Enums.TileType.Blocked;
                        // warp tile
                        if (My.MyProject.Forms.frmMapEditor.optWarp.Checked == true)
                        {
                            withBlock.Type = (byte)Enums.TileType.Warp;
                            withBlock.Data1 = E_Globals.EditorWarpMap;
                            withBlock.Data2 = E_Globals.EditorWarpX;
                            withBlock.Data3 = E_Globals.EditorWarpY;
                        }
                        // item spawn
                        if (My.MyProject.Forms.frmMapEditor.optItem.Checked == true)
                        {
                            withBlock.Type = (byte)Enums.TileType.Item;
                            withBlock.Data1 = E_Globals.ItemEditorNum;
                            withBlock.Data2 = E_Globals.ItemEditorValue;
                            withBlock.Data3 = 0;
                        }
                        // npc avoid
                        if (My.MyProject.Forms.frmMapEditor.optNpcAvoid.Checked == true)
                        {
                            withBlock.Type = (byte)Enums.TileType.NpcAvoid;
                            withBlock.Data1 = 0;
                            withBlock.Data2 = 0;
                            withBlock.Data3 = 0;
                        }
                        // key
                        if (My.MyProject.Forms.frmMapEditor.optKey.Checked == true)
                        {
                            withBlock.Type = (byte)Enums.TileType.Key;
                            withBlock.Data1 = E_Globals.KeyEditorNum;
                            withBlock.Data2 = E_Globals.KeyEditorTake;
                            withBlock.Data3 = 0;
                        }
                        // key open
                        if (My.MyProject.Forms.frmMapEditor.optKeyOpen.Checked == true)
                        {
                            withBlock.Type = (byte)Enums.TileType.KeyOpen;
                            withBlock.Data1 = E_Globals.KeyOpenEditorX;
                            withBlock.Data2 = E_Globals.KeyOpenEditorY;
                            withBlock.Data3 = 0;
                        }
                        // resource
                        if (My.MyProject.Forms.frmMapEditor.optResource.Checked == true)
                        {
                            withBlock.Type = (byte)Enums.TileType.Resource;
                            withBlock.Data1 = E_Globals.ResourceEditorNum;
                            withBlock.Data2 = 0;
                            withBlock.Data3 = 0;
                        }
                        // door
                        if (My.MyProject.Forms.frmMapEditor.optDoor.Checked == true)
                        {
                            withBlock.Type = (byte)Enums.TileType.Door;
                            withBlock.Data1 = E_Globals.EditorWarpMap;
                            withBlock.Data2 = E_Globals.EditorWarpX;
                            withBlock.Data3 = E_Globals.EditorWarpY;
                        }
                        // npc spawn
                        if (My.MyProject.Forms.frmMapEditor.optNpcSpawn.Checked == true)
                        {
                            withBlock.Type = (byte)Enums.TileType.NpcSpawn;
                            withBlock.Data1 = E_Globals.SpawnNpcNum;
                            withBlock.Data2 = E_Globals.SpawnNpcDir;
                            withBlock.Data3 = 0;
                        }
                        // shop
                        if (My.MyProject.Forms.frmMapEditor.optShop.Checked == true)
                        {
                            withBlock.Type = (byte)Enums.TileType.Shop;
                            withBlock.Data1 = E_Globals.EditorShop;
                            withBlock.Data2 = 0;
                            withBlock.Data3 = 0;
                        }
                        // bank
                        if (My.MyProject.Forms.frmMapEditor.optBank.Checked == true)
                        {
                            withBlock.Type = (byte)Enums.TileType.Bank;
                            withBlock.Data1 = 0;
                            withBlock.Data2 = 0;
                            withBlock.Data3 = 0;
                        }
                        // heal
                        if (My.MyProject.Forms.frmMapEditor.optHeal.Checked == true)
                        {
                            withBlock.Type = (byte)Enums.TileType.Heal;
                            withBlock.Data1 = E_Globals.MapEditorHealType;
                            withBlock.Data2 = E_Globals.MapEditorHealAmount;
                            withBlock.Data3 = 0;
                        }
                        // trap
                        if (My.MyProject.Forms.frmMapEditor.optTrap.Checked == true)
                        {
                            withBlock.Type = (byte)Enums.TileType.Trap;
                            withBlock.Data1 = E_Globals.MapEditorHealAmount;
                            withBlock.Data2 = 0;
                            withBlock.Data3 = 0;
                        }
                        // Housing
                        if (My.MyProject.Forms.frmMapEditor.optHouse.Checked)
                        {
                            withBlock.Type = (byte)Enums.TileType.House;
                            withBlock.Data1 = E_Housing.HouseTileindex;
                            withBlock.Data2 = 0;
                            withBlock.Data3 = 0;
                        }
                        // craft tile
                        if (My.MyProject.Forms.frmMapEditor.optCraft.Checked)
                        {
                            withBlock.Type = (byte)Enums.TileType.Craft;
                            withBlock.Data1 = 0;
                            withBlock.Data2 = 0;
                            withBlock.Data3 = 0;
                        }
                        if (My.MyProject.Forms.frmMapEditor.optLight.Checked)
                        {
                            withBlock.Type = (byte)Enums.TileType.Light;
                            withBlock.Data1 = 0;
                            withBlock.Data2 = 0;
                            withBlock.Data3 = 0;
                        }
                    }
                }
                else if (E_Globals.SelectedTab == 4)
                {
                    if (movedMouse)
                        return;
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
                                E_Graphics.SetDirBlock(ref E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].DirBlock, (byte)i, !E_Graphics.IsDirBlocked(ref E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY].DirBlock, (byte)i));
                                return;
                            }
                        }
                    }
                }
                else if (E_Globals.SelectedTab == 5)
                {
                    if (My.MyProject.Forms.frmEvents.Visible == false)
                        E_EventSystem.AddEvent(E_Globals.CurX, E_Globals.CurY);
                }
            }

            if (Button == (int)MouseButtons.Right)
            {
                if (E_Globals.SelectedTab == 1)
                {
                    {
                        var withBlock1 = E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY];
                        // clear layer
                        withBlock1.Layer[CurLayer].X = 0;
                        withBlock1.Layer[CurLayer].Y = 0;
                        withBlock1.Layer[CurLayer].Tileset = 0;
                        if (withBlock1.Layer[CurLayer].AutoTile > 0)
                        {
                            withBlock1.Layer[CurLayer].AutoTile = 0;
                            // do a re-init so we can see our changes
                            E_AutoTiles.InitAutotiles();
                        }
                        E_AutoTiles.CacheRenderState(X, Y, CurLayer);
                    }
                }
                else if (E_Globals.SelectedTab == 2)
                {
                    {
                        var withBlock2 = E_Types.Map.Tile[E_Globals.CurX, E_Globals.CurY];
                        // clear attribute
                        withBlock2.Type = 0;
                        withBlock2.Data1 = 0;
                        withBlock2.Data2 = 0;
                        withBlock2.Data3 = 0;
                    }
                }
                else if (E_Globals.SelectedTab == 5)
                    E_EventSystem.DeleteEvent(E_Globals.CurX, E_Globals.CurY);
            }
        }

        internal static void MapEditorCancel()
        {
            E_Globals.InMapEditor = false;
            My.MyProject.Forms.frmMapEditor.Visible = false;
            E_Globals.GettingMap = true;

            E_AutoTiles.InitAutotiles();
        }

        internal static void MapEditorSend()
        {
            E_NetworkSend.SendEditorMap();
            E_Globals.InMapEditor = false;
            My.MyProject.Forms.frmMapEditor.Visible = false;
            E_Globals.GettingMap = true;
        }

        internal static void MapEditorSetTile(int X, int Y, int CurLayer, bool multitile = false, byte theAutotile = 0)
        {
            int x2;
            int y2;

            if (theAutotile > 0)
            {
                {
                    var withBlock = E_Types.Map.Tile[X, Y];
                    // set layer
                    withBlock.Layer[CurLayer].X = (byte)E_Globals.EditorTileX;
                    withBlock.Layer[CurLayer].Y = (byte)E_Globals.EditorTileY;
                    withBlock.Layer[CurLayer].Tileset = (byte)(My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex + 1);
                    withBlock.Layer[CurLayer].AutoTile = theAutotile;
                    E_AutoTiles.CacheRenderState(X, Y, CurLayer);
                }
                // do a re-init so we can see our changes
                E_AutoTiles.InitAutotiles();
                return;
            }

            if (!multitile)
            {
                {
                    var withBlock1 = E_Types.Map.Tile[X, Y];
                    // set layer
                    withBlock1.Layer[CurLayer].X = (byte)E_Globals.EditorTileX;
                    withBlock1.Layer[CurLayer].Y = (byte)E_Globals.EditorTileY;
                    withBlock1.Layer[CurLayer].Tileset = (byte)(My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex + 1);
                    withBlock1.Layer[CurLayer].AutoTile = 0;
                    E_AutoTiles.CacheRenderState(X, Y, CurLayer);
                }
            }
            else
            {
                y2 = 0; // starting tile for y axis
                var loopTo = E_Globals.CurY + E_Globals.EditorTileHeight - 1;
                for (Y = E_Globals.CurY; Y <= loopTo; Y++)
                {
                    x2 = 0; // re-set x count every y loop
                    var loopTo1 = E_Globals.CurX + E_Globals.EditorTileWidth - 1;
                    for (X = E_Globals.CurX; X <= loopTo1; X++)
                    {
                        if (X >= 0 && X <= E_Types.Map.MaxX)
                        {
                            if (Y >= 0 && Y <= E_Types.Map.MaxY)
                            {
                                {
                                    var withBlock2 = E_Types.Map.Tile[X, Y];
                                    withBlock2.Layer[CurLayer].X = (byte)(E_Globals.EditorTileX + x2);
                                    withBlock2.Layer[CurLayer].Y = (byte)(E_Globals.EditorTileY + y2);
                                    withBlock2.Layer[CurLayer].Tileset = (byte)(My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex + 1);
                                    withBlock2.Layer[CurLayer].AutoTile = 0;
                                    E_AutoTiles.CacheRenderState(X, Y, CurLayer);
                                }
                            }
                        }
                        x2 = x2 + 1;
                    }
                    y2 = y2 + 1;
                }
            }
        }

        internal static void MapEditorClearLayer()
        {
            int X;
            int Y;
            int CurLayer;

            CurLayer = My.MyProject.Forms.frmMapEditor.cmbLayers.SelectedIndex + 1;

            if (CurLayer == 0)
                return;

            // ask to clear layer
            if (Interaction.MsgBox("Are you sure you wish to clear this layer?", Microsoft.VisualBasic.Constants.vbYesNo, "MapEditor") == Microsoft.VisualBasic.Constants.vbYes)
            {
                var loopTo = E_Types.Map.MaxX;
                for (X = 0; X <= loopTo; X++)
                {
                    var loopTo1 = E_Types.Map.MaxY;
                    for (Y = 0; Y <= loopTo1; Y++)
                    {
                        {
                            var withBlock = E_Types.Map.Tile[X, Y];
                            withBlock.Layer[CurLayer].X = 0;
                            withBlock.Layer[CurLayer].Y = 0;
                            withBlock.Layer[CurLayer].Tileset = 0;
                            withBlock.Layer[CurLayer].AutoTile = 0;
                            E_AutoTiles.CacheRenderState(X, Y, CurLayer);
                        }
                    }
                }
            }
        }

        internal static void MapEditorFillLayer(byte theAutotile = 0)
        {
            int X;
            int Y = 0;
            int CurLayer;

            CurLayer = My.MyProject.Forms.frmMapEditor.cmbLayers.SelectedIndex + 1;

            if (Interaction.MsgBox("Are you sure you wish to fill this layer?", Microsoft.VisualBasic.Constants.vbYesNo, "Map Editor") == Microsoft.VisualBasic.Constants.vbYes)
            {
                if (theAutotile > 0)
                {
                    var loopTo = E_Types.Map.MaxX;
                    for (X = 0; X <= loopTo; X++)
                    {
                        var loopTo1 = E_Types.Map.MaxY;
                        for (Y = 0; Y <= loopTo1; Y++)
                        {
                            E_Types.Map.Tile[X, Y].Layer[CurLayer].X = (byte)E_Globals.EditorTileX;
                            E_Types.Map.Tile[X, Y].Layer[CurLayer].Y = (byte)E_Globals.EditorTileY;
                            E_Types.Map.Tile[X, Y].Layer[CurLayer].Tileset = (byte)(My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex + 1);
                            E_Types.Map.Tile[X, Y].Layer[CurLayer].AutoTile = theAutotile;
                            E_AutoTiles.CacheRenderState(X, Y, CurLayer);
                        }
                    }

                    // do a re-init so we can see our changes
                    E_AutoTiles.InitAutotiles();
                }
                else
                {
                    var loopTo2 = E_Types.Map.MaxX;
                    for (X = 0; X <= loopTo2; X++)
                    {
                        var loopTo3 = E_Types.Map.MaxY;
                        for (Y = 0; Y <= loopTo3; Y++)
                        {
                            E_Types.Map.Tile[X, Y].Layer[CurLayer].X = (byte)E_Globals.EditorTileX;
                            E_Types.Map.Tile[X, Y].Layer[CurLayer].Y = (byte)E_Globals.EditorTileY;
                            E_Types.Map.Tile[X, Y].Layer[CurLayer].Tileset = (byte)(My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex + 1);
                            E_AutoTiles.CacheRenderState(X, Y, CurLayer);
                        }
                    }
                }
            }
        }

        internal static void ClearAttributeDialogue()
        {
            {
                var withBlock = My.MyProject.Forms.frmMapEditor;
                withBlock.fraNpcSpawn.Visible = false;
                withBlock.fraResource.Visible = false;
                withBlock.fraMapItem.Visible = false;
                withBlock.fraMapKey.Visible = false;
                withBlock.fraKeyOpen.Visible = false;
                withBlock.fraMapWarp.Visible = false;
                withBlock.fraShop.Visible = false;
                withBlock.fraHeal.Visible = false;
                withBlock.fraTrap.Visible = false;
                withBlock.fraBuyHouse.Visible = false;
            }
        }

        internal static void MapEditorClearAttribs()
        {
            int X;
            int Y;

            if (Interaction.MsgBox("Are you sure you wish to clear the attributes on this map?", Microsoft.VisualBasic.Constants.vbYesNo, "MapEditor") == Microsoft.VisualBasic.Constants.vbYes)
            {
                var loopTo = E_Types.Map.MaxX;
                for (X = 0; X <= loopTo; X++)
                {
                    var loopTo1 = E_Types.Map.MaxY;
                    for (Y = 0; Y <= loopTo1; Y++)
                        E_Types.Map.Tile[X, Y].Type = 0;
                }
            }
        }

        internal static void MapEditorLeaveMap()
        {
            if (E_Globals.InMapEditor)
            {
                if (Interaction.MsgBox("Save changes to current map?", Microsoft.VisualBasic.Constants.vbYesNo) == Microsoft.VisualBasic.Constants.vbYes)
                    MapEditorSend();
                else
                    MapEditorCancel();
            }
        }





        internal static void NpcEditorInit()
        {
            int i;

            if (My.MyProject.Forms.frmNPC.Visible == false)
                return;
            E_Globals.Editorindex = My.MyProject.Forms.frmNPC.lstIndex.SelectedIndex + 1;
            My.MyProject.Forms.frmNPC.cmbDropSlot.SelectedIndex = 0;
            if (Types.Npc[E_Globals.Editorindex].AttackSay == null)
                Types.Npc[E_Globals.Editorindex].AttackSay = "";
            if (Types.Npc[E_Globals.Editorindex].Name == null)
                Types.Npc[E_Globals.Editorindex].Name = "";

            {
                var withBlock = My.MyProject.Forms.frmNPC;
                // populate combo boxes
                withBlock.cmbAnimation.Items.Clear();
                withBlock.cmbAnimation.Items.Add("None");
                for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
                    withBlock.cmbAnimation.Items.Add(i + ": " + Types.Animation[i].Name);

                withBlock.cmbQuest.Items.Clear();
                withBlock.cmbQuest.Items.Add("None");
                for (i = 1; i <= E_Quest.MAX_QUESTS; i++)
                    withBlock.cmbQuest.Items.Add(i + ": " + E_Quest.Quest[i].Name);

                withBlock.cmbItem.Items.Clear();
                withBlock.cmbItem.Items.Add("None");
                for (i = 1; i <= Constants.MAX_ITEMS; i++)
                    withBlock.cmbItem.Items.Add(i + ": " + Types.Item[i].Name);

                withBlock.txtName.Text = Microsoft.VisualBasic.Strings.Trim(Types.Npc[E_Globals.Editorindex].Name);
                withBlock.txtAttackSay.Text = Microsoft.VisualBasic.Strings.Trim(Types.Npc[E_Globals.Editorindex].AttackSay);

                if (Types.Npc[E_Globals.Editorindex].Sprite < 0 || Types.Npc[E_Globals.Editorindex].Sprite > withBlock.nudSprite.Maximum)
                    Types.Npc[E_Globals.Editorindex].Sprite = 0;
                withBlock.nudSprite.Value = Types.Npc[E_Globals.Editorindex].Sprite;
                withBlock.nudSpawnSecs.Value = Types.Npc[E_Globals.Editorindex].SpawnSecs;
                withBlock.cmbBehaviour.SelectedIndex = Types.Npc[E_Globals.Editorindex].Behaviour;
                withBlock.cmbFaction.SelectedIndex = Types.Npc[E_Globals.Editorindex].Faction;
                withBlock.nudRange.Value = Types.Npc[E_Globals.Editorindex].Range;
                withBlock.nudChance.Value = Types.Npc[E_Globals.Editorindex].DropChance[My.MyProject.Forms.frmNPC.cmbDropSlot.SelectedIndex + 1];
                withBlock.cmbItem.SelectedIndex = Types.Npc[E_Globals.Editorindex].DropItem[My.MyProject.Forms.frmNPC.cmbDropSlot.SelectedIndex + 1];

                withBlock.nudAmount.Value = Types.Npc[E_Globals.Editorindex].DropItemValue[My.MyProject.Forms.frmNPC.cmbDropSlot.SelectedIndex + 1];

                withBlock.nudHp.Value = Types.Npc[E_Globals.Editorindex].Hp;
                withBlock.nudExp.Value = Types.Npc[E_Globals.Editorindex].Exp;
                withBlock.nudLevel.Value = Types.Npc[E_Globals.Editorindex].Level;
                withBlock.nudDamage.Value = Types.Npc[E_Globals.Editorindex].Damage;

                withBlock.cmbQuest.SelectedIndex = Types.Npc[E_Globals.Editorindex].QuestNum;
                withBlock.cmbSpawnPeriod.SelectedIndex = Types.Npc[E_Globals.Editorindex].SpawnTime;

                withBlock.nudStrength.Value = Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Strength];
                withBlock.nudEndurance.Value = Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Endurance];
                withBlock.nudIntelligence.Value = Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Intelligence];
                withBlock.nudSpirit.Value = Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Spirit];
                withBlock.nudLuck.Value = Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Luck];
                withBlock.nudVitality.Value = Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Vitality];

                withBlock.cmbSkill1.Items.Clear();
                withBlock.cmbSkill2.Items.Clear();
                withBlock.cmbSkill3.Items.Clear();
                withBlock.cmbSkill4.Items.Clear();
                withBlock.cmbSkill5.Items.Clear();
                withBlock.cmbSkill6.Items.Clear();

                withBlock.cmbSkill1.Items.Add("None");
                withBlock.cmbSkill2.Items.Add("None");
                withBlock.cmbSkill3.Items.Add("None");
                withBlock.cmbSkill4.Items.Add("None");
                withBlock.cmbSkill5.Items.Add("None");
                withBlock.cmbSkill6.Items.Add("None");

                for (i = 1; i <= Constants.MAX_SKILLS; i++)
                {
                    if (Microsoft.VisualBasic.Strings.Len(Types.Skill[i].Name) > 0)
                    {
                        withBlock.cmbSkill1.Items.Add(Types.Skill[i].Name);
                        withBlock.cmbSkill2.Items.Add(Types.Skill[i].Name);
                        withBlock.cmbSkill3.Items.Add(Types.Skill[i].Name);
                        withBlock.cmbSkill4.Items.Add(Types.Skill[i].Name);
                        withBlock.cmbSkill5.Items.Add(Types.Skill[i].Name);
                        withBlock.cmbSkill6.Items.Add(Types.Skill[i].Name);
                    }
                }

                withBlock.cmbSkill1.SelectedIndex = Types.Npc[E_Globals.Editorindex].Skill[1];
                withBlock.cmbSkill2.SelectedIndex = Types.Npc[E_Globals.Editorindex].Skill[2];
                withBlock.cmbSkill3.SelectedIndex = Types.Npc[E_Globals.Editorindex].Skill[3];
                withBlock.cmbSkill4.SelectedIndex = Types.Npc[E_Globals.Editorindex].Skill[4];
                withBlock.cmbSkill5.SelectedIndex = Types.Npc[E_Globals.Editorindex].Skill[5];
                withBlock.cmbSkill6.SelectedIndex = Types.Npc[E_Globals.Editorindex].Skill[6];
            }

            E_Graphics.EditorNpc_DrawSprite();
            E_Globals.NPC_Changed[E_Globals.Editorindex] = true;
        }

        internal static void NpcEditorOk()
        {
            int i;

            for (i = 1; i <= Constants.MAX_NPCS; i++)
            {
                if (E_Globals.NPC_Changed[i])
                    E_NetworkSend.SendSaveNpc(i);
            }

            My.MyProject.Forms.frmNPC.Visible = false;
            E_Globals.Editor = 0;
            ClearChanged_NPC();
        }

        internal static void NpcEditorCancel()
        {
            E_Globals.Editor = 0;
            My.MyProject.Forms.frmNPC.Visible = false;
            ClearChanged_NPC();
            ClientDataBase.ClearNpcs();
            E_NetworkSend.SendRequestNPCS();
        }

        internal static void ClearChanged_NPC()
        {
            for (var i = 1; i <= Constants.MAX_NPCS; i++)
                E_Globals.NPC_Changed[i] = false;
        }



        internal static void ResourceEditorInit()
        {
            int i;

            if (My.MyProject.Forms.FrmResource.Visible == false)
                return;
            E_Globals.Editorindex = My.MyProject.Forms.FrmResource.lstIndex.SelectedIndex + 1;

            {
                var withBlock = My.MyProject.Forms.FrmResource;
                // populate combo boxes
                withBlock.cmbRewardItem.Items.Clear();
                withBlock.cmbRewardItem.Items.Add("None");
                for (i = 1; i <= Constants.MAX_ITEMS; i++)
                    withBlock.cmbRewardItem.Items.Add(i + ": " + Types.Item[i].Name);

                withBlock.cmbAnimation.Items.Clear();
                withBlock.cmbAnimation.Items.Add("None");
                for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
                    withBlock.cmbAnimation.Items.Add(i + ": " + Types.Animation[i].Name);

                withBlock.nudExhaustedPic.Maximum = E_Graphics.NumResources;
                withBlock.nudNormalPic.Maximum = E_Graphics.NumResources;
                withBlock.nudRespawn.Maximum = 1000000;
                withBlock.txtName.Text = Microsoft.VisualBasic.Strings.Trim(Types.Resource[E_Globals.Editorindex].Name);
                withBlock.txtMessage.Text = Microsoft.VisualBasic.Strings.Trim(Types.Resource[E_Globals.Editorindex].SuccessMessage);
                withBlock.txtMessage2.Text = Microsoft.VisualBasic.Strings.Trim(Types.Resource[E_Globals.Editorindex].EmptyMessage);
                withBlock.cmbType.SelectedIndex = Types.Resource[E_Globals.Editorindex].ResourceType;
                withBlock.nudNormalPic.Value = Types.Resource[E_Globals.Editorindex].ResourceImage;
                withBlock.nudExhaustedPic.Value = Types.Resource[E_Globals.Editorindex].ExhaustedImage;
                withBlock.cmbRewardItem.SelectedIndex = Types.Resource[E_Globals.Editorindex].ItemReward;
                withBlock.nudRewardExp.Value = Types.Resource[E_Globals.Editorindex].ExpReward;
                withBlock.cmbTool.SelectedIndex = Types.Resource[E_Globals.Editorindex].ToolRequired;
                withBlock.nudHealth.Value = Types.Resource[E_Globals.Editorindex].Health;
                withBlock.nudRespawn.Value = Types.Resource[E_Globals.Editorindex].RespawnTime;
                withBlock.cmbAnimation.SelectedIndex = Types.Resource[E_Globals.Editorindex].Animation;
                withBlock.nudLvlReq.Value = Types.Resource[E_Globals.Editorindex].LvlRequired;
            }

            My.MyProject.Forms.FrmResource.Visible = true;

            E_Graphics.EditorResource_DrawSprite();

            E_Globals.Resource_Changed[E_Globals.Editorindex] = true;
        }

        internal static void ResourceEditorOk()
        {
            int i;

            for (i = 1; i <= Constants.MAX_RESOURCES; i++)
            {
                if (E_Globals.Resource_Changed[i])
                    E_NetworkSend.SendSaveResource(i);
            }

            My.MyProject.Forms.FrmResource.Visible = false;
            E_Globals.Editor = 0;
            ClientDataBase.ClearChanged_Resource();
        }

        internal static void ResourceEditorCancel()
        {
            E_Globals.Editor = 0;
            My.MyProject.Forms.FrmResource.Visible = false;
            ClientDataBase.ClearChanged_Resource();
            ClientDataBase.ClearResources();
            E_NetworkSend.SendRequestResources();
        }



        internal static void SkillEditorInit()
        {
            int i;

            if (My.MyProject.Forms.frmSkill.Visible == false)
                return;
            E_Globals.Editorindex = My.MyProject.Forms.frmSkill.lstIndex.SelectedIndex + 1;

            if (Types.Skill[E_Globals.Editorindex].Name == null)
                Types.Skill[E_Globals.Editorindex].Name = "";

            {
                var withBlock = My.MyProject.Forms.frmSkill;
                // set max values
                withBlock.nudAoE.Maximum = byte.MaxValue;
                withBlock.nudRange.Maximum = byte.MaxValue;
                withBlock.nudMap.Maximum = Constants.MAX_MAPS;

                // build class combo
                withBlock.cmbClass.Items.Clear();
                withBlock.cmbClass.Items.Add("None");
                var loopTo = E_Globals.Max_Classes;
                for (i = 1; i <= loopTo; i++)
                    withBlock.cmbClass.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Classes[i].Name));
                withBlock.cmbClass.SelectedIndex = 0;

                withBlock.cmbProjectile.Items.Clear();
                withBlock.cmbProjectile.Items.Add("None");
                for (i = 1; i <= E_Projectiles.MAX_PROJECTILES; i++)
                    withBlock.cmbProjectile.Items.Add(Microsoft.VisualBasic.Strings.Trim(E_Projectiles.Projectiles[i].Name));
                withBlock.cmbProjectile.SelectedIndex = 0;

                withBlock.cmbAnimCast.Items.Clear();
                withBlock.cmbAnimCast.Items.Add("None");
                withBlock.cmbAnim.Items.Clear();
                withBlock.cmbAnim.Items.Add("None");
                for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
                {
                    withBlock.cmbAnimCast.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Animation[i].Name));
                    withBlock.cmbAnim.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Animation[i].Name));
                }
                withBlock.cmbAnimCast.SelectedIndex = 0;
                withBlock.cmbAnim.SelectedIndex = 0;

                // set values
                withBlock.txtName.Text = Microsoft.VisualBasic.Strings.Trim(Types.Skill[E_Globals.Editorindex].Name);
                withBlock.cmbType.SelectedIndex = Types.Skill[E_Globals.Editorindex].Type;
                withBlock.nudMp.Value = Types.Skill[E_Globals.Editorindex].MpCost;
                withBlock.nudLevel.Value = Types.Skill[E_Globals.Editorindex].LevelReq;
                withBlock.cmbAccessReq.SelectedIndex = Types.Skill[E_Globals.Editorindex].AccessReq;
                withBlock.cmbClass.SelectedIndex = Types.Skill[E_Globals.Editorindex].ClassReq;
                withBlock.nudCast.Value = Types.Skill[E_Globals.Editorindex].CastTime;
                withBlock.nudCool.Value = Types.Skill[E_Globals.Editorindex].CdTime;
                withBlock.nudIcon.Value = Types.Skill[E_Globals.Editorindex].Icon;
                withBlock.nudMap.Value = Types.Skill[E_Globals.Editorindex].Map;
                withBlock.nudX.Value = Types.Skill[E_Globals.Editorindex].X;
                withBlock.nudY.Value = Types.Skill[E_Globals.Editorindex].Y;
                withBlock.cmbDir.SelectedIndex = Types.Skill[E_Globals.Editorindex].Dir;
                withBlock.nudVital.Value = Types.Skill[E_Globals.Editorindex].Vital;
                withBlock.nudDuration.Value = Types.Skill[E_Globals.Editorindex].Duration;
                withBlock.nudInterval.Value = Types.Skill[E_Globals.Editorindex].Interval;
                withBlock.nudRange.Value = Types.Skill[E_Globals.Editorindex].Range;

                withBlock.chkAoE.Checked = Types.Skill[E_Globals.Editorindex].IsAoE;

                withBlock.nudAoE.Value = Types.Skill[E_Globals.Editorindex].AoE;
                withBlock.cmbAnimCast.SelectedIndex = Types.Skill[E_Globals.Editorindex].CastAnim;
                withBlock.cmbAnim.SelectedIndex = Types.Skill[E_Globals.Editorindex].SkillAnim;
                withBlock.nudStun.Value = Types.Skill[E_Globals.Editorindex].StunDuration;

                if (Types.Skill[E_Globals.Editorindex].IsProjectile == 1)
                    withBlock.chkProjectile.Checked = true;
                else
                    withBlock.chkProjectile.Checked = false;
                withBlock.cmbProjectile.SelectedIndex = Types.Skill[E_Globals.Editorindex].Projectile;

                if (Types.Skill[E_Globals.Editorindex].KnockBack == 1)
                    withBlock.chkKnockBack.Checked = true;
                else
                    withBlock.chkKnockBack.Checked = false;
                withBlock.cmbKnockBackTiles.SelectedIndex = Types.Skill[E_Globals.Editorindex].KnockBackTiles;
            }

            E_Graphics.EditorSkill_BltIcon();

            E_Globals.Skill_Changed[E_Globals.Editorindex] = true;
        }

        internal static void SkillEditorOk()
        {
            int i;

            for (i = 1; i <= Constants.MAX_SKILLS; i++)
            {
                if (E_Globals.Skill_Changed[i])
                    E_NetworkSend.SendSaveSkill(i);
            }

            My.MyProject.Forms.frmSkill.Visible = false;
            E_Globals.Editor = 0;
            ClearChanged_Skill();
        }

        internal static void SkillEditorCancel()
        {
            E_Globals.Editor = 0;
            My.MyProject.Forms.frmSkill.Visible = false;
            ClearChanged_Skill();
            ClientDataBase.ClearSkills();
            E_NetworkSend.SendRequestSkills();
        }

        internal static void ClearChanged_Skill()
        {
            for (var i = 1; i <= Constants.MAX_SKILLS; i++)
                E_Globals.Skill_Changed[i] = false;
        }



        internal static void ShopEditorInit()
        {
            int i;

            if (My.MyProject.Forms.frmShop.Visible == false)
                return;
            E_Globals.Editorindex = My.MyProject.Forms.frmShop.lstIndex.SelectedIndex + 1;

            My.MyProject.Forms.frmShop.txtName.Text = Microsoft.VisualBasic.Strings.Trim(Types.Shop[E_Globals.Editorindex].Name);
            if (Types.Shop[E_Globals.Editorindex].BuyRate > 0)
                My.MyProject.Forms.frmShop.nudBuy.Value = Types.Shop[E_Globals.Editorindex].BuyRate;
            else
                My.MyProject.Forms.frmShop.nudBuy.Value = 100;

            My.MyProject.Forms.frmShop.nudFace.Value = Types.Shop[E_Globals.Editorindex].Face;
            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Faces\" + Types.Shop[E_Globals.Editorindex].Face + E_Globals.GFX_EXT))
                My.MyProject.Forms.frmShop.picFace.BackgroundImage = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"Faces\" + Types.Shop[E_Globals.Editorindex].Face + E_Globals.GFX_EXT);

            My.MyProject.Forms.frmShop.cmbItem.Items.Clear();
            My.MyProject.Forms.frmShop.cmbItem.Items.Add("None");
            My.MyProject.Forms.frmShop.cmbCostItem.Items.Clear();
            My.MyProject.Forms.frmShop.cmbCostItem.Items.Add("None");

            for (i = 1; i <= Constants.MAX_ITEMS; i++)
            {
                My.MyProject.Forms.frmShop.cmbItem.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Item[i].Name));
                My.MyProject.Forms.frmShop.cmbCostItem.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Item[i].Name));
            }

            My.MyProject.Forms.frmShop.cmbItem.SelectedIndex = 0;
            My.MyProject.Forms.frmShop.cmbCostItem.SelectedIndex = 0;

            UpdateShopTrade();

            E_Globals.Shop_Changed[E_Globals.Editorindex] = true;
        }

        internal static void UpdateShopTrade()
        {
            int i;
            My.MyProject.Forms.frmShop.lstTradeItem.Items.Clear();

            for (i = 1; i <= Constants.MAX_TRADES; i++)
            {
                {
                    var withBlock = Types.Shop[E_Globals.Editorindex].TradeItem[i];
                    // if none, show as none
                    if (withBlock.Item == 0 && withBlock.CostItem == 0)
                        My.MyProject.Forms.frmShop.lstTradeItem.Items.Add("Empty Trade Slot");
                    else
                        My.MyProject.Forms.frmShop.lstTradeItem.Items.Add(i + ": " + withBlock.ItemValue + "x " + Microsoft.VisualBasic.Strings.Trim(Types.Item[withBlock.Item].Name) + " for " + withBlock.CostValue + "x " + Microsoft.VisualBasic.Strings.Trim(Types.Item[withBlock.CostItem].Name));
                }
            }

            My.MyProject.Forms.frmShop.lstTradeItem.SelectedIndex = 0;
        }

        internal static void ShopEditorOk()
        {
            int i;

            for (i = 1; i <= Constants.MAX_SHOPS; i++)
            {
                if (E_Globals.Shop_Changed[i])
                    E_NetworkSend.SendSaveShop(i);
            }

            My.MyProject.Forms.frmShop.Visible = false;
            E_Globals.Editor = 0;
            ClearChanged_Shop();
        }

        internal static void ShopEditorCancel()
        {
            E_Globals.Editor = 0;
            My.MyProject.Forms.frmShop.Visible = false;
            ClearChanged_Shop();
            ClientDataBase.ClearShops();
            E_NetworkSend.SendRequestShops();
        }

        internal static void ClearChanged_Shop()
        {
            for (var i = 1; i <= Constants.MAX_SHOPS; i++)
                E_Globals.Shop_Changed[i] = false;
        }



        internal static void ClassesEditorOk()
        {
            E_NetworkSend.SendSaveClasses();

            My.MyProject.Forms.frmClasses.Visible = false;
            E_Globals.Editor = 0;
        }

        internal static void ClassesEditorCancel()
        {
            E_NetworkSend.SendRequestClasses();
            My.MyProject.Forms.frmClasses.Visible = false;
            E_Globals.Editor = 0;
        }

        internal static void ClassEditorInit()
        {
            int i;

            My.MyProject.Forms.frmClasses.lstIndex.Items.Clear();
            var loopTo = E_Globals.Max_Classes;
            for (i = 1; i <= loopTo; i++)
                My.MyProject.Forms.frmClasses.lstIndex.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Classes[i].Name));

            E_Globals.Editor = E_Globals.EDITOR_CLASSES;

            My.MyProject.Forms.frmClasses.nudMaleSprite.Maximum = E_Graphics.NumCharacters;
            My.MyProject.Forms.frmClasses.nudFemaleSprite.Maximum = E_Graphics.NumCharacters;

            My.MyProject.Forms.frmClasses.cmbItems.Items.Clear();

            My.MyProject.Forms.frmClasses.cmbItems.Items.Add("None");
            for (i = 1; i <= Constants.MAX_ITEMS; i++)
                My.MyProject.Forms.frmClasses.cmbItems.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Item[i].Name));

            My.MyProject.Forms.frmClasses.lstIndex.SelectedIndex = 0;

            My.MyProject.Forms.frmClasses.Visible = true;
        }

        internal static void LoadClass()
        {
            int i;

            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            My.MyProject.Forms.frmClasses.txtName.Text = Types.Classes[E_Globals.Editorindex].Name;
            My.MyProject.Forms.frmClasses.txtDescription.Text = Types.Classes[E_Globals.Editorindex].Desc;

            My.MyProject.Forms.frmClasses.cmbMaleSprite.Items.Clear();
            var loopTo = Information.UBound(Types.Classes[E_Globals.Editorindex].MaleSprite);
            for (i = 0; i <= loopTo; i++)
                My.MyProject.Forms.frmClasses.cmbMaleSprite.Items.Add("Sprite " + i + 1);

            My.MyProject.Forms.frmClasses.cmbFemaleSprite.Items.Clear();
            var loopTo1 = Information.UBound(Types.Classes[E_Globals.Editorindex].FemaleSprite);
            for (i = 0; i <= loopTo1; i++)
                My.MyProject.Forms.frmClasses.cmbFemaleSprite.Items.Add("Sprite " + i + 1);

            My.MyProject.Forms.frmClasses.nudMaleSprite.Value = Types.Classes[E_Globals.Editorindex].MaleSprite[0];
            My.MyProject.Forms.frmClasses.nudFemaleSprite.Value = Types.Classes[E_Globals.Editorindex].FemaleSprite[0];

            My.MyProject.Forms.frmClasses.cmbMaleSprite.SelectedIndex = 0;
            My.MyProject.Forms.frmClasses.cmbFemaleSprite.SelectedIndex = 0;

            My.MyProject.Forms.frmClasses.DrawPreview();

            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
            {
                if (Types.Classes[E_Globals.Editorindex].Stat[i] == 0)
                    Types.Classes[E_Globals.Editorindex].Stat[i] = 1;
            }

            My.MyProject.Forms.frmClasses.nudStrength.Value = Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Strength];
            My.MyProject.Forms.frmClasses.nudLuck.Value = Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Luck];
            My.MyProject.Forms.frmClasses.nudEndurance.Value = Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Endurance];
            My.MyProject.Forms.frmClasses.nudIntelligence.Value = Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Intelligence];
            My.MyProject.Forms.frmClasses.nudVitality.Value = Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Vitality];
            My.MyProject.Forms.frmClasses.nudSpirit.Value = Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Spirit];

            if (Types.Classes[E_Globals.Editorindex].BaseExp < 10)
                My.MyProject.Forms.frmClasses.nudBaseExp.Value = 10;
            else
                My.MyProject.Forms.frmClasses.nudBaseExp.Value = Types.Classes[E_Globals.Editorindex].BaseExp;

            My.MyProject.Forms.frmClasses.lstStartItems.Items.Clear();

            for (i = 1; i <= 5; i++)
            {
                if (Types.Classes[E_Globals.Editorindex].StartItem[i] > 0)
                    My.MyProject.Forms.frmClasses.lstStartItems.Items.Add(Types.Item[Types.Classes[E_Globals.Editorindex].StartItem[i]].Name + " X " + Types.Classes[E_Globals.Editorindex].StartValue[i]);
                else
                    My.MyProject.Forms.frmClasses.lstStartItems.Items.Add("None");
            }

            My.MyProject.Forms.frmClasses.nudStartMap.Value = Types.Classes[E_Globals.Editorindex].StartMap;
            My.MyProject.Forms.frmClasses.nudStartX.Value = Types.Classes[E_Globals.Editorindex].StartX;
            My.MyProject.Forms.frmClasses.nudStartY.Value = Types.Classes[E_Globals.Editorindex].StartY;
        }
    }
}
