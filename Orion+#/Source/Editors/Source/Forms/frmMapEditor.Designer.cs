using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Engine
{
    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class frmMapEditor : System.Windows.Forms.Form
    {

        // Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                    components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapEditor));
            this.DarkDockPanel1 = new DarkUI.Docking.DarkDockPanel();
            this.ToolStripContainer2 = new System.Windows.Forms.ToolStripContainer();
            this.ssInfo = new DarkUI.Controls.DarkStatusStrip();
            this.tslCurMap = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslCurXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsCurFps = new System.Windows.Forms.ToolStripStatusLabel();
            this.DarkSectionPanel1 = new DarkUI.Controls.DarkSectionPanel();
            this.pnlTiles = new System.Windows.Forms.Panel();
            this.cmbAutoTile = new DarkUI.Controls.DarkComboBox();
            this.cmbTileSets = new DarkUI.Controls.DarkComboBox();
            this.cmbLayers = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel4 = new DarkUI.Controls.DarkLabel();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.picBackSelect = new System.Windows.Forms.PictureBox();
            this.DarkLabel3 = new DarkUI.Controls.DarkLabel();
            this.scrlPictureY = new DarkUI.Controls.DarkScrollBar();
            this.scrlPictureX = new DarkUI.Controls.DarkScrollBar();
            this.DarkLabel2 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel1 = new DarkUI.Controls.DarkLabel();
            this.pnlNpc = new System.Windows.Forms.Panel();
            this.cmbNpcList = new System.Windows.Forms.ComboBox();
            this.lstMapNpc = new System.Windows.Forms.ListBox();
            this.pnlDirBlock = new System.Windows.Forms.Panel();
            this.DarkLabel6 = new DarkUI.Controls.DarkLabel();
            this.btnEvents = new DarkUI.Controls.DarkButton();
            this.btnDirBlock = new DarkUI.Controls.DarkButton();
            this.btnNpc = new DarkUI.Controls.DarkButton();
            this.btnAttributes = new DarkUI.Controls.DarkButton();
            this.btnTiles = new DarkUI.Controls.DarkButton();
            this.pnlEvents = new System.Windows.Forms.Panel();
            this.lblPasteMode = new DarkUI.Controls.DarkLabel();
            this.btnPasteEvent = new DarkUI.Controls.DarkButton();
            this.DarkLabel16 = new DarkUI.Controls.DarkLabel();
            this.lblCopyMode = new DarkUI.Controls.DarkLabel();
            this.btnCopyEvent = new DarkUI.Controls.DarkButton();
            this.DarkLabel15 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel5 = new DarkUI.Controls.DarkLabel();
            this.pnlAttribute = new System.Windows.Forms.Panel();
            this.optLight = new DarkUI.Controls.DarkRadioButton();
            this.btnClearAttribute = new DarkUI.Controls.DarkButton();
            this.optHouse = new DarkUI.Controls.DarkRadioButton();
            this.optShop = new DarkUI.Controls.DarkRadioButton();
            this.optNpcSpawn = new DarkUI.Controls.DarkRadioButton();
            this.optBank = new DarkUI.Controls.DarkRadioButton();
            this.optCraft = new DarkUI.Controls.DarkRadioButton();
            this.optTrap = new DarkUI.Controls.DarkRadioButton();
            this.optHeal = new DarkUI.Controls.DarkRadioButton();
            this.optKeyOpen = new DarkUI.Controls.DarkRadioButton();
            this.optKey = new DarkUI.Controls.DarkRadioButton();
            this.optDoor = new DarkUI.Controls.DarkRadioButton();
            this.optResource = new DarkUI.Controls.DarkRadioButton();
            this.optNpcAvoid = new DarkUI.Controls.DarkRadioButton();
            this.optItem = new DarkUI.Controls.DarkRadioButton();
            this.optWarp = new DarkUI.Controls.DarkRadioButton();
            this.optBlocked = new DarkUI.Controls.DarkRadioButton();
            this.DarkSectionPanel2 = new DarkUI.Controls.DarkSectionPanel();
            this.pnlMoreOptions = new System.Windows.Forms.Panel();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.nudFogAlpha = new DarkUI.Controls.DarkNumericUpDown();
            this.nudFogSpeed = new DarkUI.Controls.DarkNumericUpDown();
            this.nudFog = new DarkUI.Controls.DarkNumericUpDown();
            this.nudIntensity = new DarkUI.Controls.DarkNumericUpDown();
            this.lblFogAlpha = new DarkUI.Controls.DarkLabel();
            this.lblFogSpeed = new DarkUI.Controls.DarkLabel();
            this.lblFogIndex = new DarkUI.Controls.DarkLabel();
            this.lblIntensity = new DarkUI.Controls.DarkLabel();
            this.cmbWeather = new System.Windows.Forms.ComboBox();
            this.DarkLabel14 = new DarkUI.Controls.DarkLabel();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.nudMapAlpha = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMapBlue = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMapGreen = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMapRed = new DarkUI.Controls.DarkNumericUpDown();
            this.chkUseTint = new System.Windows.Forms.CheckBox();
            this.lblMapAlpha = new DarkUI.Controls.DarkLabel();
            this.lblMapBlue = new DarkUI.Controls.DarkLabel();
            this.lblMapGreen = new DarkUI.Controls.DarkLabel();
            this.lblMapRed = new DarkUI.Controls.DarkLabel();
            this.btnMoreOptions = new DarkUI.Controls.DarkButton();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.btnPreview = new DarkUI.Controls.DarkButton();
            this.lstMusic = new System.Windows.Forms.ListBox();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.nudMaxY = new DarkUI.Controls.DarkNumericUpDown();
            this.nudMaxX = new DarkUI.Controls.DarkNumericUpDown();
            this.btnSetSize = new DarkUI.Controls.DarkButton();
            this.DarkLabel13 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel12 = new DarkUI.Controls.DarkLabel();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.nudSpawnY = new DarkUI.Controls.DarkNumericUpDown();
            this.nudSpawnX = new DarkUI.Controls.DarkNumericUpDown();
            this.nudSpawnMap = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel11 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel10 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel9 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel7 = new DarkUI.Controls.DarkLabel();
            this.chkInstance = new DarkUI.Controls.DarkCheckBox();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel8 = new DarkUI.Controls.DarkLabel();
            this.fraMapLinks = new System.Windows.Forms.GroupBox();
            this.nudRight = new DarkUI.Controls.DarkNumericUpDown();
            this.nudLeft = new DarkUI.Controls.DarkNumericUpDown();
            this.nudDown = new DarkUI.Controls.DarkNumericUpDown();
            this.nudUp = new DarkUI.Controls.DarkNumericUpDown();
            this.lblMap = new DarkUI.Controls.DarkLabel();
            this.cmbMoral = new System.Windows.Forms.ComboBox();
            this.ToolStrip = new DarkUI.Controls.DarkToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbDiscard = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMapGrid = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFill = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cmbMapList = new System.Windows.Forms.ToolStripComboBox();
            this.ToolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbScreenShot = new System.Windows.Forms.ToolStripButton();
            this.pnlBack2 = new DarkUI.Controls.DarkSectionPanel();
            this.pnlAttributes = new System.Windows.Forms.Panel();
            this.fraMapWarp = new System.Windows.Forms.GroupBox();
            this.lblVisualWarp = new System.Windows.Forms.Label();
            this.btnMapWarp = new System.Windows.Forms.Button();
            this.scrlMapWarpY = new System.Windows.Forms.HScrollBar();
            this.scrlMapWarpX = new System.Windows.Forms.HScrollBar();
            this.scrlMapWarpMap = new System.Windows.Forms.HScrollBar();
            this.lblMapWarpY = new System.Windows.Forms.Label();
            this.lblMapWarpX = new System.Windows.Forms.Label();
            this.lblMapWarpMap = new System.Windows.Forms.Label();
            this.fraBuyHouse = new System.Windows.Forms.GroupBox();
            this.btnHouseTileOk = new System.Windows.Forms.Button();
            this.scrlBuyHouse = new System.Windows.Forms.HScrollBar();
            this.lblHouseName = new System.Windows.Forms.Label();
            this.fraKeyOpen = new System.Windows.Forms.GroupBox();
            this.scrlKeyY = new System.Windows.Forms.HScrollBar();
            this.lblKeyY = new System.Windows.Forms.Label();
            this.btnMapKeyOpen = new System.Windows.Forms.Button();
            this.scrlKeyX = new System.Windows.Forms.HScrollBar();
            this.lblKeyX = new System.Windows.Forms.Label();
            this.fraMapKey = new System.Windows.Forms.GroupBox();
            this.chkMapKey = new System.Windows.Forms.CheckBox();
            this.picMapKey = new System.Windows.Forms.PictureBox();
            this.btnMapKey = new System.Windows.Forms.Button();
            this.scrlMapKey = new System.Windows.Forms.HScrollBar();
            this.lblMapKey = new System.Windows.Forms.Label();
            this.fraNpcSpawn = new System.Windows.Forms.GroupBox();
            this.lstNpc = new System.Windows.Forms.ComboBox();
            this.btnNpcSpawn = new System.Windows.Forms.Button();
            this.scrlNpcDir = new System.Windows.Forms.HScrollBar();
            this.lblNpcDir = new System.Windows.Forms.Label();
            this.fraHeal = new System.Windows.Forms.GroupBox();
            this.scrlHeal = new System.Windows.Forms.HScrollBar();
            this.lblHeal = new System.Windows.Forms.Label();
            this.cmbHeal = new System.Windows.Forms.ComboBox();
            this.btnHeal = new System.Windows.Forms.Button();
            this.fraShop = new System.Windows.Forms.GroupBox();
            this.cmbShop = new System.Windows.Forms.ComboBox();
            this.btnShop = new System.Windows.Forms.Button();
            this.fraResource = new System.Windows.Forms.GroupBox();
            this.btnResourceOk = new System.Windows.Forms.Button();
            this.scrlResource = new System.Windows.Forms.HScrollBar();
            this.lblResource = new System.Windows.Forms.Label();
            this.fraMapItem = new System.Windows.Forms.GroupBox();
            this.picMapItem = new System.Windows.Forms.PictureBox();
            this.btnMapItem = new System.Windows.Forms.Button();
            this.scrlMapItemValue = new System.Windows.Forms.HScrollBar();
            this.scrlMapItem = new System.Windows.Forms.HScrollBar();
            this.lblMapItem = new System.Windows.Forms.Label();
            this.fraTrap = new System.Windows.Forms.GroupBox();
            this.btnTrap = new System.Windows.Forms.Button();
            this.scrlTrap = new System.Windows.Forms.HScrollBar();
            this.lblTrap = new System.Windows.Forms.Label();
            this.scrlMapViewV = new DarkUI.Controls.DarkScrollBar();
            this.scrlMapViewH = new DarkUI.Controls.DarkScrollBar();
            this.picScreen = new System.Windows.Forms.PictureBox();
            this.ToolStripContainer2.ContentPanel.SuspendLayout();
            this.ToolStripContainer2.SuspendLayout();
            this.ssInfo.SuspendLayout();
            this.DarkSectionPanel1.SuspendLayout();
            this.pnlTiles.SuspendLayout();
            this.pnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.picBackSelect).BeginInit();
            this.pnlNpc.SuspendLayout();
            this.pnlDirBlock.SuspendLayout();
            this.pnlEvents.SuspendLayout();
            this.pnlAttribute.SuspendLayout();
            this.DarkSectionPanel2.SuspendLayout();
            this.pnlMoreOptions.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudFogAlpha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudFogSpeed).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudFog).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudIntensity).BeginInit();
            this.GroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudMapAlpha).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudMapBlue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudMapGreen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudMapRed).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudMaxY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudMaxX).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudSpawnY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSpawnX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSpawnMap).BeginInit();
            this.fraMapLinks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudRight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudLeft).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudUp).BeginInit();
            this.ToolStrip.SuspendLayout();
            this.pnlBack2.SuspendLayout();
            this.pnlAttributes.SuspendLayout();
            this.fraMapWarp.SuspendLayout();
            this.fraBuyHouse.SuspendLayout();
            this.fraKeyOpen.SuspendLayout();
            this.fraMapKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.picMapKey).BeginInit();
            this.fraNpcSpawn.SuspendLayout();
            this.fraHeal.SuspendLayout();
            this.fraShop.SuspendLayout();
            this.fraResource.SuspendLayout();
            this.fraMapItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.picMapItem).BeginInit();
            this.fraTrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.picScreen).BeginInit();
            this.SuspendLayout();
            // 
            // DarkDockPanel1
            // 
            this.DarkDockPanel1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.DarkDockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DarkDockPanel1.Location = new System.Drawing.Point(0, 0);
            this.DarkDockPanel1.Name = "DarkDockPanel1";
            this.DarkDockPanel1.Size = new System.Drawing.Size(1292, 626);
            this.DarkDockPanel1.TabIndex = 0;
            // 
            // ToolStripContainer2
            // 
            // 
            // ToolStripContainer2.ContentPanel
            // 
            this.ToolStripContainer2.ContentPanel.Controls.Add(this.ssInfo);
            this.ToolStripContainer2.ContentPanel.Size = new System.Drawing.Size(1292, 28);
            this.ToolStripContainer2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ToolStripContainer2.LeftToolStripPanelVisible = false;
            this.ToolStripContainer2.Location = new System.Drawing.Point(0, 598);
            this.ToolStripContainer2.Name = "ToolStripContainer2";
            this.ToolStripContainer2.RightToolStripPanelVisible = false;
            this.ToolStripContainer2.Size = new System.Drawing.Size(1292, 28);
            this.ToolStripContainer2.TabIndex = 6;
            this.ToolStripContainer2.Text = "ToolStripContainer2";
            this.ToolStripContainer2.TopToolStripPanelVisible = false;
            // 
            // ssInfo
            // 
            this.ssInfo.AutoSize = false;
            this.ssInfo.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.ssInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ssInfo.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.ssInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tslCurMap, this.tslCurXY, this.tsCurFps });
            this.ssInfo.Location = new System.Drawing.Point(0, 0);
            this.ssInfo.Name = "ssInfo";
            this.ssInfo.Padding = new System.Windows.Forms.Padding(0, 5, 0, 3);
            this.ssInfo.Size = new System.Drawing.Size(1292, 28);
            this.ssInfo.SizingGrip = false;
            this.ssInfo.TabIndex = 0;
            this.ssInfo.Text = "DarkStatusStrip1";
            // 
            // tslCurMap
            // 
            this.tslCurMap.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tslCurMap.Name = "tslCurMap";
            this.tslCurMap.Size = new System.Drawing.Size(86, 15);
            this.tslCurMap.Text = "Current Map: 1";
            // 
            // tslCurXY
            // 
            this.tslCurXY.Name = "tslCurXY";
            this.tslCurXY.Size = new System.Drawing.Size(50, 15);
            this.tslCurXY.Text = "X:1 - Y:1";
            // 
            // tsCurFps
            // 
            this.tsCurFps.Name = "tsCurFps";
            this.tsCurFps.Size = new System.Drawing.Size(81, 15);
            this.tsCurFps.Text = "Current FPS: 0";
            // 
            // DarkSectionPanel1
            // 
            this.DarkSectionPanel1.Controls.Add(this.pnlTiles);
            this.DarkSectionPanel1.Controls.Add(this.pnlNpc);
            this.DarkSectionPanel1.Controls.Add(this.pnlDirBlock);
            this.DarkSectionPanel1.Controls.Add(this.btnEvents);
            this.DarkSectionPanel1.Controls.Add(this.btnDirBlock);
            this.DarkSectionPanel1.Controls.Add(this.btnNpc);
            this.DarkSectionPanel1.Controls.Add(this.btnAttributes);
            this.DarkSectionPanel1.Controls.Add(this.btnTiles);
            this.DarkSectionPanel1.Controls.Add(this.pnlEvents);
            this.DarkSectionPanel1.Controls.Add(this.pnlAttribute);
            this.DarkSectionPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.DarkSectionPanel1.Location = new System.Drawing.Point(0, 0);
            this.DarkSectionPanel1.Name = "DarkSectionPanel1";
            this.DarkSectionPanel1.SectionHeader = "Map Layers";
            this.DarkSectionPanel1.Size = new System.Drawing.Size(318, 598);
            this.DarkSectionPanel1.TabIndex = 7;
            // 
            // pnlTiles
            // 
            this.pnlTiles.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.pnlTiles.Controls.Add(this.cmbAutoTile);
            this.pnlTiles.Controls.Add(this.cmbTileSets);
            this.pnlTiles.Controls.Add(this.cmbLayers);
            this.pnlTiles.Controls.Add(this.DarkLabel4);
            this.pnlTiles.Controls.Add(this.pnlBack);
            this.pnlTiles.Controls.Add(this.DarkLabel3);
            this.pnlTiles.Controls.Add(this.scrlPictureY);
            this.pnlTiles.Controls.Add(this.scrlPictureX);
            this.pnlTiles.Controls.Add(this.DarkLabel2);
            this.pnlTiles.Controls.Add(this.DarkLabel1);
            this.pnlTiles.Location = new System.Drawing.Point(1, 51);
            this.pnlTiles.Name = "pnlTiles";
            this.pnlTiles.Size = new System.Drawing.Size(316, 546);
            this.pnlTiles.TabIndex = 0;
            // 
            // cmbAutoTile
            // 
            this.cmbAutoTile.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbAutoTile.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbAutoTile.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbAutoTile.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbAutoTile.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbAutoTile.ButtonIcon");
            this.cmbAutoTile.DrawDropdownHoverOutline = false;
            this.cmbAutoTile.DrawFocusRectangle = false;
            this.cmbAutoTile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAutoTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutoTile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAutoTile.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbAutoTile.FormattingEnabled = true;
            this.cmbAutoTile.Items.AddRange(new object[] { "Normal", "AutoTile", "Fake", "Animated", "Cliff", "Waterfall" });
            this.cmbAutoTile.Location = new System.Drawing.Point(52, 512);
            this.cmbAutoTile.Name = "cmbAutoTile";
            this.cmbAutoTile.Size = new System.Drawing.Size(109, 21);
            this.cmbAutoTile.TabIndex = 22;
            this.cmbAutoTile.Text = "Normal";
            this.cmbAutoTile.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbTileSets
            // 
            this.cmbTileSets.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbTileSets.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbTileSets.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbTileSets.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbTileSets.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbTileSets.ButtonIcon");
            this.cmbTileSets.DrawDropdownHoverOutline = false;
            this.cmbTileSets.DrawFocusRectangle = false;
            this.cmbTileSets.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTileSets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTileSets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTileSets.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbTileSets.FormattingEnabled = true;
            this.cmbTileSets.Location = new System.Drawing.Point(52, 485);
            this.cmbTileSets.Name = "cmbTileSets";
            this.cmbTileSets.Size = new System.Drawing.Size(80, 21);
            this.cmbTileSets.TabIndex = 21;
            this.cmbTileSets.Text = null;
            this.cmbTileSets.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbLayers
            // 
            this.cmbLayers.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbLayers.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbLayers.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbLayers.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbLayers.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbLayers.ButtonIcon");
            this.cmbLayers.DrawDropdownHoverOutline = false;
            this.cmbLayers.DrawFocusRectangle = false;
            this.cmbLayers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLayers.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbLayers.FormattingEnabled = true;
            this.cmbLayers.Items.AddRange(new object[] { "Ground", "Mask", "Mask2", "Fringe", "Fringe2" });
            this.cmbLayers.Location = new System.Drawing.Point(180, 485);
            this.cmbLayers.Name = "cmbLayers";
            this.cmbLayers.Size = new System.Drawing.Size(130, 21);
            this.cmbLayers.TabIndex = 20;
            this.cmbLayers.Text = "Ground";
            this.cmbLayers.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel4
            // 
            this.DarkLabel4.AutoSize = true;
            this.DarkLabel4.BackColor = System.Drawing.Color.Transparent;
            this.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel4.Location = new System.Drawing.Point(3, 516);
            this.DarkLabel4.Name = "DarkLabel4";
            this.DarkLabel4.Size = new System.Drawing.Size(49, 13);
            this.DarkLabel4.TabIndex = 18;
            this.DarkLabel4.Text = "AutoTile:";
            // 
            // pnlBack
            // 
            this.pnlBack.BackColor = System.Drawing.Color.Black;
            this.pnlBack.Controls.Add(this.picBackSelect);
            this.pnlBack.Location = new System.Drawing.Point(3, 3);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(286, 442);
            this.pnlBack.TabIndex = 10;
            // 
            // picBackSelect
            // 
            this.picBackSelect.BackColor = System.Drawing.Color.Black;
            this.picBackSelect.Location = new System.Drawing.Point(0, 0);
            this.picBackSelect.Name = "picBackSelect";
            this.picBackSelect.Size = new System.Drawing.Size(283, 451);
            this.picBackSelect.TabIndex = 1;
            this.picBackSelect.TabStop = false;
            // 
            // DarkLabel3
            // 
            this.DarkLabel3.AutoSize = true;
            this.DarkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel3.Location = new System.Drawing.Point(138, 489);
            this.DarkLabel3.Name = "DarkLabel3";
            this.DarkLabel3.Size = new System.Drawing.Size(36, 13);
            this.DarkLabel3.TabIndex = 16;
            this.DarkLabel3.Text = "Layer:";
            // 
            // scrlPictureY
            // 
            this.scrlPictureY.BackColor = System.Drawing.SystemColors.ControlDark;
            this.scrlPictureY.Location = new System.Drawing.Point(292, 3);
            this.scrlPictureY.Name = "scrlPictureY";
            this.scrlPictureY.Size = new System.Drawing.Size(18, 442);
            this.scrlPictureY.TabIndex = 12;
            // 
            // scrlPictureX
            // 
            this.scrlPictureX.BackColor = System.Drawing.SystemColors.ControlDark;
            this.scrlPictureX.Location = new System.Drawing.Point(3, 451);
            this.scrlPictureX.Name = "scrlPictureX";
            this.scrlPictureX.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal;
            this.scrlPictureX.Size = new System.Drawing.Size(283, 16);
            this.scrlPictureX.TabIndex = 11;
            // 
            // DarkLabel2
            // 
            this.DarkLabel2.AutoSize = true;
            this.DarkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel2.Location = new System.Drawing.Point(3, 489);
            this.DarkLabel2.Name = "DarkLabel2";
            this.DarkLabel2.Size = new System.Drawing.Size(43, 13);
            this.DarkLabel2.TabIndex = 14;
            this.DarkLabel2.Text = "TileSet:";
            // 
            // DarkLabel1
            // 
            this.DarkLabel1.AutoSize = true;
            this.DarkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.DarkLabel1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel1.Location = new System.Drawing.Point(57, 470);
            this.DarkLabel1.Name = "DarkLabel1";
            this.DarkLabel1.Size = new System.Drawing.Size(174, 13);
            this.DarkLabel1.TabIndex = 13;
            this.DarkLabel1.Text = "Drag Mouse to Select Multiple Tiles";
            // 
            // pnlNpc
            // 
            this.pnlNpc.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.pnlNpc.Controls.Add(this.cmbNpcList);
            this.pnlNpc.Controls.Add(this.lstMapNpc);
            this.pnlNpc.Location = new System.Drawing.Point(2, 50);
            this.pnlNpc.Name = "pnlNpc";
            this.pnlNpc.Size = new System.Drawing.Size(314, 548);
            this.pnlNpc.TabIndex = 8;
            // 
            // cmbNpcList
            // 
            this.cmbNpcList.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.cmbNpcList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNpcList.ForeColor = System.Drawing.Color.LightGray;
            this.cmbNpcList.FormattingEnabled = true;
            this.cmbNpcList.Location = new System.Drawing.Point(126, 441);
            this.cmbNpcList.Name = "cmbNpcList";
            this.cmbNpcList.Size = new System.Drawing.Size(184, 21);
            this.cmbNpcList.TabIndex = 18;
            // 
            // lstMapNpc
            // 
            this.lstMapNpc.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.lstMapNpc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstMapNpc.ForeColor = System.Drawing.Color.LightGray;
            this.lstMapNpc.FormattingEnabled = true;
            this.lstMapNpc.Location = new System.Drawing.Point(3, 4);
            this.lstMapNpc.Name = "lstMapNpc";
            this.lstMapNpc.Size = new System.Drawing.Size(307, 431);
            this.lstMapNpc.TabIndex = 0;
            // 
            // pnlDirBlock
            // 
            this.pnlDirBlock.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.pnlDirBlock.Controls.Add(this.DarkLabel6);
            this.pnlDirBlock.Location = new System.Drawing.Point(2, 51);
            this.pnlDirBlock.Name = "pnlDirBlock";
            this.pnlDirBlock.Size = new System.Drawing.Size(314, 548);
            this.pnlDirBlock.TabIndex = 7;
            // 
            // DarkLabel6
            // 
            this.DarkLabel6.AutoSize = true;
            this.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel6.Location = new System.Drawing.Point(8, 8);
            this.DarkLabel6.Name = "DarkLabel6";
            this.DarkLabel6.Size = new System.Drawing.Size(239, 13);
            this.DarkLabel6.TabIndex = 0;
            this.DarkLabel6.Text = "Just press the arrows to block that side of the tile.";
            // 
            // btnEvents
            // 
            this.btnEvents.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.btnEvents.Location = new System.Drawing.Point(264, 28);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Padding = new System.Windows.Forms.Padding(5);
            this.btnEvents.Size = new System.Drawing.Size(52, 23);
            this.btnEvents.TabIndex = 4;
            this.btnEvents.Text = "Events";
            // 
            // btnDirBlock
            // 
            this.btnDirBlock.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.btnDirBlock.Location = new System.Drawing.Point(163, 28);
            this.btnDirBlock.Name = "btnDirBlock";
            this.btnDirBlock.Padding = new System.Windows.Forms.Padding(5);
            this.btnDirBlock.Size = new System.Drawing.Size(100, 23);
            this.btnDirBlock.TabIndex = 3;
            this.btnDirBlock.Text = "Directional Block";
            // 
            // btnNpc
            // 
            this.btnNpc.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.btnNpc.Location = new System.Drawing.Point(118, 28);
            this.btnNpc.Name = "btnNpc";
            this.btnNpc.Padding = new System.Windows.Forms.Padding(5);
            this.btnNpc.Size = new System.Drawing.Size(44, 23);
            this.btnNpc.TabIndex = 2;
            this.btnNpc.Text = "Npc's";
            // 
            // btnAttributes
            // 
            this.btnAttributes.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.btnAttributes.Location = new System.Drawing.Point(49, 28);
            this.btnAttributes.Name = "btnAttributes";
            this.btnAttributes.Padding = new System.Windows.Forms.Padding(5);
            this.btnAttributes.Size = new System.Drawing.Size(68, 23);
            this.btnAttributes.TabIndex = 1;
            this.btnAttributes.Text = "Attributes";
            // 
            // btnTiles
            // 
            this.btnTiles.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.btnTiles.Location = new System.Drawing.Point(4, 28);
            this.btnTiles.Name = "btnTiles";
            this.btnTiles.Padding = new System.Windows.Forms.Padding(5);
            this.btnTiles.Size = new System.Drawing.Size(44, 23);
            this.btnTiles.TabIndex = 0;
            this.btnTiles.Text = "Tiles";
            // 
            // pnlEvents
            // 
            this.pnlEvents.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.pnlEvents.Controls.Add(this.lblPasteMode);
            this.pnlEvents.Controls.Add(this.btnPasteEvent);
            this.pnlEvents.Controls.Add(this.DarkLabel16);
            this.pnlEvents.Controls.Add(this.lblCopyMode);
            this.pnlEvents.Controls.Add(this.btnCopyEvent);
            this.pnlEvents.Controls.Add(this.DarkLabel15);
            this.pnlEvents.Controls.Add(this.DarkLabel5);
            this.pnlEvents.Location = new System.Drawing.Point(4, 50);
            this.pnlEvents.Name = "pnlEvents";
            this.pnlEvents.Size = new System.Drawing.Size(314, 548);
            this.pnlEvents.TabIndex = 6;
            // 
            // lblPasteMode
            // 
            this.lblPasteMode.AutoSize = true;
            this.lblPasteMode.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblPasteMode.Location = new System.Drawing.Point(92, 148);
            this.lblPasteMode.Name = "lblPasteMode";
            this.lblPasteMode.Size = new System.Drawing.Size(78, 13);
            this.lblPasteMode.TabIndex = 18;
            this.lblPasteMode.Text = "PasteMode Off";
            // 
            // btnPasteEvent
            // 
            this.btnPasteEvent.Location = new System.Drawing.Point(9, 143);
            this.btnPasteEvent.Name = "btnPasteEvent";
            this.btnPasteEvent.Padding = new System.Windows.Forms.Padding(5);
            this.btnPasteEvent.Size = new System.Drawing.Size(75, 23);
            this.btnPasteEvent.TabIndex = 17;
            this.btnPasteEvent.Text = "Paste Event";
            // 
            // DarkLabel16
            // 
            this.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel16.Location = new System.Drawing.Point(8, 111);
            this.DarkLabel16.Name = "DarkLabel16";
            this.DarkLabel16.Size = new System.Drawing.Size(251, 44);
            this.DarkLabel16.TabIndex = 16;
            this.DarkLabel16.Text = "To paste a copied Event, press the paste button, then click on the map to place i" + "t.";
            // 
            // lblCopyMode
            // 
            this.lblCopyMode.AutoSize = true;
            this.lblCopyMode.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblCopyMode.Location = new System.Drawing.Point(92, 67);
            this.lblCopyMode.Name = "lblCopyMode";
            this.lblCopyMode.Size = new System.Drawing.Size(75, 13);
            this.lblCopyMode.TabIndex = 15;
            this.lblCopyMode.Text = "CopyMode Off";
            // 
            // btnCopyEvent
            // 
            this.btnCopyEvent.Location = new System.Drawing.Point(11, 62);
            this.btnCopyEvent.Name = "btnCopyEvent";
            this.btnCopyEvent.Padding = new System.Windows.Forms.Padding(5);
            this.btnCopyEvent.Size = new System.Drawing.Size(75, 23);
            this.btnCopyEvent.TabIndex = 14;
            this.btnCopyEvent.Text = "Copy Event";
            // 
            // DarkLabel15
            // 
            this.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel15.Location = new System.Drawing.Point(8, 29);
            this.DarkLabel15.Name = "DarkLabel15";
            this.DarkLabel15.Size = new System.Drawing.Size(237, 30);
            this.DarkLabel15.TabIndex = 13;
            this.DarkLabel15.Text = "To copy a existing Event, press the copy button, then the event.";
            // 
            // DarkLabel5
            // 
            this.DarkLabel5.AutoSize = true;
            this.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel5.Location = new System.Drawing.Point(8, 8);
            this.DarkLabel5.Name = "DarkLabel5";
            this.DarkLabel5.Size = new System.Drawing.Size(233, 13);
            this.DarkLabel5.TabIndex = 0;
            this.DarkLabel5.Text = "Click on the map where you want to ad a event.";
            // 
            // pnlAttribute
            // 
            this.pnlAttribute.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.pnlAttribute.Controls.Add(this.optLight);
            this.pnlAttribute.Controls.Add(this.btnClearAttribute);
            this.pnlAttribute.Controls.Add(this.optHouse);
            this.pnlAttribute.Controls.Add(this.optShop);
            this.pnlAttribute.Controls.Add(this.optNpcSpawn);
            this.pnlAttribute.Controls.Add(this.optBank);
            this.pnlAttribute.Controls.Add(this.optCraft);
            this.pnlAttribute.Controls.Add(this.optTrap);
            this.pnlAttribute.Controls.Add(this.optHeal);
            this.pnlAttribute.Controls.Add(this.optKeyOpen);
            this.pnlAttribute.Controls.Add(this.optKey);
            this.pnlAttribute.Controls.Add(this.optDoor);
            this.pnlAttribute.Controls.Add(this.optResource);
            this.pnlAttribute.Controls.Add(this.optNpcAvoid);
            this.pnlAttribute.Controls.Add(this.optItem);
            this.pnlAttribute.Controls.Add(this.optWarp);
            this.pnlAttribute.Controls.Add(this.optBlocked);
            this.pnlAttribute.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlAttribute.Location = new System.Drawing.Point(2, 50);
            this.pnlAttribute.Name = "pnlAttribute";
            this.pnlAttribute.Size = new System.Drawing.Size(314, 548);
            this.pnlAttribute.TabIndex = 9;
            // 
            // optLight
            // 
            this.optLight.AutoSize = true;
            this.optLight.Location = new System.Drawing.Point(235, 138);
            this.optLight.Name = "optLight";
            this.optLight.Size = new System.Drawing.Size(48, 17);
            this.optLight.TabIndex = 16;
            this.optLight.TabStop = true;
            this.optLight.Text = "Light";
            // 
            // btnClearAttribute
            // 
            this.btnClearAttribute.Location = new System.Drawing.Point(10, 470);
            this.btnClearAttribute.Name = "btnClearAttribute";
            this.btnClearAttribute.Padding = new System.Windows.Forms.Padding(5);
            this.btnClearAttribute.Size = new System.Drawing.Size(297, 23);
            this.btnClearAttribute.TabIndex = 15;
            this.btnClearAttribute.Text = "Clear Attributes";
            // 
            // optHouse
            // 
            this.optHouse.AutoSize = true;
            this.optHouse.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optHouse.Location = new System.Drawing.Point(163, 139);
            this.optHouse.Name = "optHouse";
            this.optHouse.Size = new System.Drawing.Size(56, 17);
            this.optHouse.TabIndex = 14;
            this.optHouse.Text = "House";
            // 
            // optShop
            // 
            this.optShop.AutoSize = true;
            this.optShop.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optShop.Location = new System.Drawing.Point(97, 139);
            this.optShop.Name = "optShop";
            this.optShop.Size = new System.Drawing.Size(50, 17);
            this.optShop.TabIndex = 13;
            this.optShop.Text = "Shop";
            // 
            // optNpcSpawn
            // 
            this.optNpcSpawn.AutoSize = true;
            this.optNpcSpawn.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optNpcSpawn.Location = new System.Drawing.Point(10, 139);
            this.optNpcSpawn.Name = "optNpcSpawn";
            this.optNpcSpawn.Size = new System.Drawing.Size(81, 17);
            this.optNpcSpawn.TabIndex = 12;
            this.optNpcSpawn.Text = "Npc Spawn";
            // 
            // optBank
            // 
            this.optBank.AutoSize = true;
            this.optBank.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optBank.Location = new System.Drawing.Point(235, 94);
            this.optBank.Name = "optBank";
            this.optBank.Size = new System.Drawing.Size(50, 17);
            this.optBank.TabIndex = 11;
            this.optBank.Text = "Bank";
            // 
            // optCraft
            // 
            this.optCraft.AutoSize = true;
            this.optCraft.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optCraft.Location = new System.Drawing.Point(163, 94);
            this.optCraft.Name = "optCraft";
            this.optCraft.Size = new System.Drawing.Size(47, 17);
            this.optCraft.TabIndex = 10;
            this.optCraft.Text = "Craft";
            // 
            // optTrap
            // 
            this.optTrap.AutoSize = true;
            this.optTrap.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optTrap.Location = new System.Drawing.Point(97, 94);
            this.optTrap.Name = "optTrap";
            this.optTrap.Size = new System.Drawing.Size(47, 17);
            this.optTrap.TabIndex = 9;
            this.optTrap.Text = "Trap";
            // 
            // optHeal
            // 
            this.optHeal.AutoSize = true;
            this.optHeal.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optHeal.Location = new System.Drawing.Point(10, 94);
            this.optHeal.Name = "optHeal";
            this.optHeal.Size = new System.Drawing.Size(47, 17);
            this.optHeal.TabIndex = 8;
            this.optHeal.Text = "Heal";
            // 
            // optKeyOpen
            // 
            this.optKeyOpen.AutoSize = true;
            this.optKeyOpen.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optKeyOpen.Location = new System.Drawing.Point(235, 50);
            this.optKeyOpen.Name = "optKeyOpen";
            this.optKeyOpen.Size = new System.Drawing.Size(72, 17);
            this.optKeyOpen.TabIndex = 7;
            this.optKeyOpen.Text = "Key Open";
            // 
            // optKey
            // 
            this.optKey.AutoSize = true;
            this.optKey.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optKey.Location = new System.Drawing.Point(163, 50);
            this.optKey.Name = "optKey";
            this.optKey.Size = new System.Drawing.Size(43, 17);
            this.optKey.TabIndex = 6;
            this.optKey.Text = "Key";
            // 
            // optDoor
            // 
            this.optDoor.AutoSize = true;
            this.optDoor.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optDoor.Location = new System.Drawing.Point(97, 50);
            this.optDoor.Name = "optDoor";
            this.optDoor.Size = new System.Drawing.Size(48, 17);
            this.optDoor.TabIndex = 5;
            this.optDoor.Text = "Door";
            // 
            // optResource
            // 
            this.optResource.AutoSize = true;
            this.optResource.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optResource.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optResource.Location = new System.Drawing.Point(10, 50);
            this.optResource.Name = "optResource";
            this.optResource.Size = new System.Drawing.Size(71, 17);
            this.optResource.TabIndex = 4;
            this.optResource.Text = "Resource";
            // 
            // optNpcAvoid
            // 
            this.optNpcAvoid.AutoSize = true;
            this.optNpcAvoid.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optNpcAvoid.Location = new System.Drawing.Point(235, 7);
            this.optNpcAvoid.Name = "optNpcAvoid";
            this.optNpcAvoid.Size = new System.Drawing.Size(75, 17);
            this.optNpcAvoid.TabIndex = 3;
            this.optNpcAvoid.Text = "Npc Avoid";
            // 
            // optItem
            // 
            this.optItem.AutoSize = true;
            this.optItem.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optItem.Location = new System.Drawing.Point(163, 7);
            this.optItem.Name = "optItem";
            this.optItem.Size = new System.Drawing.Size(66, 17);
            this.optItem.TabIndex = 2;
            this.optItem.Text = "MapItem";
            // 
            // optWarp
            // 
            this.optWarp.AutoSize = true;
            this.optWarp.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optWarp.Location = new System.Drawing.Point(97, 7);
            this.optWarp.Name = "optWarp";
            this.optWarp.Size = new System.Drawing.Size(51, 17);
            this.optWarp.TabIndex = 1;
            this.optWarp.Text = "Warp";
            // 
            // optBlocked
            // 
            this.optBlocked.AutoSize = true;
            this.optBlocked.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.optBlocked.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optBlocked.Location = new System.Drawing.Point(10, 7);
            this.optBlocked.Name = "optBlocked";
            this.optBlocked.Size = new System.Drawing.Size(64, 17);
            this.optBlocked.TabIndex = 0;
            this.optBlocked.Text = "Blocked";
            // 
            // DarkSectionPanel2
            // 
            this.DarkSectionPanel2.AutoScroll = true;
            this.DarkSectionPanel2.Controls.Add(this.pnlMoreOptions);
            this.DarkSectionPanel2.Controls.Add(this.GroupBox5);
            this.DarkSectionPanel2.Controls.Add(this.btnMoreOptions);
            this.DarkSectionPanel2.Controls.Add(this.GroupBox3);
            this.DarkSectionPanel2.Controls.Add(this.GroupBox2);
            this.DarkSectionPanel2.Controls.Add(this.GroupBox1);
            this.DarkSectionPanel2.Controls.Add(this.DarkLabel7);
            this.DarkSectionPanel2.Controls.Add(this.chkInstance);
            this.DarkSectionPanel2.Controls.Add(this.txtName);
            this.DarkSectionPanel2.Controls.Add(this.DarkLabel8);
            this.DarkSectionPanel2.Controls.Add(this.fraMapLinks);
            this.DarkSectionPanel2.Controls.Add(this.cmbMoral);
            this.DarkSectionPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.DarkSectionPanel2.Location = new System.Drawing.Point(1076, 0);
            this.DarkSectionPanel2.Name = "DarkSectionPanel2";
            this.DarkSectionPanel2.SectionHeader = "Map Settings";
            this.DarkSectionPanel2.Size = new System.Drawing.Size(216, 598);
            this.DarkSectionPanel2.TabIndex = 8;
            // 
            // pnlMoreOptions
            // 
            this.pnlMoreOptions.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.pnlMoreOptions.Controls.Add(this.GroupBox4);
            this.pnlMoreOptions.Location = new System.Drawing.Point(4, 26);
            this.pnlMoreOptions.Name = "pnlMoreOptions";
            this.pnlMoreOptions.Size = new System.Drawing.Size(208, 539);
            this.pnlMoreOptions.TabIndex = 31;
            this.pnlMoreOptions.Visible = false;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.nudFogAlpha);
            this.GroupBox4.Controls.Add(this.nudFogSpeed);
            this.GroupBox4.Controls.Add(this.nudFog);
            this.GroupBox4.Controls.Add(this.nudIntensity);
            this.GroupBox4.Controls.Add(this.lblFogAlpha);
            this.GroupBox4.Controls.Add(this.lblFogSpeed);
            this.GroupBox4.Controls.Add(this.lblFogIndex);
            this.GroupBox4.Controls.Add(this.lblIntensity);
            this.GroupBox4.Controls.Add(this.cmbWeather);
            this.GroupBox4.Controls.Add(this.DarkLabel14);
            this.GroupBox4.ForeColor = System.Drawing.Color.LightGray;
            this.GroupBox4.Location = new System.Drawing.Point(5, 7);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(200, 96);
            this.GroupBox4.TabIndex = 0;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Weather Options";
            // 
            // nudFogAlpha
            // 
            this.nudFogAlpha.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudFogAlpha.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudFogAlpha.Location = new System.Drawing.Point(145, 69);
            this.nudFogAlpha.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            this.nudFogAlpha.Name = "nudFogAlpha";
            this.nudFogAlpha.Size = new System.Drawing.Size(49, 20);
            this.nudFogAlpha.TabIndex = 29;
            this.nudFogAlpha.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nudFogSpeed
            // 
            this.nudFogSpeed.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudFogSpeed.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudFogSpeed.Location = new System.Drawing.Point(61, 69);
            this.nudFogSpeed.Name = "nudFogSpeed";
            this.nudFogSpeed.Size = new System.Drawing.Size(44, 20);
            this.nudFogSpeed.TabIndex = 28;
            this.nudFogSpeed.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nudFog
            // 
            this.nudFog.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudFog.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudFog.Location = new System.Drawing.Point(145, 44);
            this.nudFog.Name = "nudFog";
            this.nudFog.Size = new System.Drawing.Size(49, 20);
            this.nudFog.TabIndex = 28;
            this.nudFog.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nudIntensity
            // 
            this.nudIntensity.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudIntensity.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudIntensity.Location = new System.Drawing.Point(61, 44);
            this.nudIntensity.Name = "nudIntensity";
            this.nudIntensity.Size = new System.Drawing.Size(44, 20);
            this.nudIntensity.TabIndex = 28;
            this.nudIntensity.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // lblFogAlpha
            // 
            this.lblFogAlpha.AutoSize = true;
            this.lblFogAlpha.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblFogAlpha.Location = new System.Drawing.Point(111, 72);
            this.lblFogAlpha.Name = "lblFogAlpha";
            this.lblFogAlpha.Size = new System.Drawing.Size(37, 13);
            this.lblFogAlpha.TabIndex = 23;
            this.lblFogAlpha.Text = "Alpha:";
            // 
            // lblFogSpeed
            // 
            this.lblFogSpeed.AutoSize = true;
            this.lblFogSpeed.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblFogSpeed.Location = new System.Drawing.Point(6, 72);
            this.lblFogSpeed.Name = "lblFogSpeed";
            this.lblFogSpeed.Size = new System.Drawing.Size(41, 13);
            this.lblFogSpeed.TabIndex = 21;
            this.lblFogSpeed.Text = "Speed:";
            // 
            // lblFogIndex
            // 
            this.lblFogIndex.AutoSize = true;
            this.lblFogIndex.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblFogIndex.Location = new System.Drawing.Point(111, 46);
            this.lblFogIndex.Name = "lblFogIndex";
            this.lblFogIndex.Size = new System.Drawing.Size(28, 13);
            this.lblFogIndex.TabIndex = 19;
            this.lblFogIndex.Text = "Fog:";
            // 
            // lblIntensity
            // 
            this.lblIntensity.AutoSize = true;
            this.lblIntensity.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblIntensity.Location = new System.Drawing.Point(6, 46);
            this.lblIntensity.Name = "lblIntensity";
            this.lblIntensity.Size = new System.Drawing.Size(49, 13);
            this.lblIntensity.TabIndex = 17;
            this.lblIntensity.Text = "Intensity:";
            // 
            // cmbWeather
            // 
            this.cmbWeather.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.cmbWeather.ForeColor = System.Drawing.Color.LightGray;
            this.cmbWeather.FormattingEnabled = true;
            this.cmbWeather.Items.AddRange(new object[] { "None", "Rain", "Snow", "Hail", "Sand Storm", "Storm", "Fog" });
            this.cmbWeather.Location = new System.Drawing.Point(91, 17);
            this.cmbWeather.Name = "cmbWeather";
            this.cmbWeather.Size = new System.Drawing.Size(103, 21);
            this.cmbWeather.TabIndex = 16;
            // 
            // DarkLabel14
            // 
            this.DarkLabel14.AutoSize = true;
            this.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel14.Location = new System.Drawing.Point(7, 22);
            this.DarkLabel14.Name = "DarkLabel14";
            this.DarkLabel14.Size = new System.Drawing.Size(78, 13);
            this.DarkLabel14.TabIndex = 0;
            this.DarkLabel14.Text = "Weather Type:";
            // 
            // GroupBox5
            // 
            this.GroupBox5.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox5.Controls.Add(this.nudMapAlpha);
            this.GroupBox5.Controls.Add(this.nudMapBlue);
            this.GroupBox5.Controls.Add(this.nudMapGreen);
            this.GroupBox5.Controls.Add(this.nudMapRed);
            this.GroupBox5.Controls.Add(this.chkUseTint);
            this.GroupBox5.Controls.Add(this.lblMapAlpha);
            this.GroupBox5.Controls.Add(this.lblMapBlue);
            this.GroupBox5.Controls.Add(this.lblMapGreen);
            this.GroupBox5.Controls.Add(this.lblMapRed);
            this.GroupBox5.ForeColor = System.Drawing.Color.LightGray;
            this.GroupBox5.Location = new System.Drawing.Point(9, 473);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(200, 85);
            this.GroupBox5.TabIndex = 1;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Map Tinting";
            // 
            // nudMapAlpha
            // 
            this.nudMapAlpha.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudMapAlpha.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMapAlpha.Location = new System.Drawing.Point(139, 55);
            this.nudMapAlpha.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            this.nudMapAlpha.Name = "nudMapAlpha";
            this.nudMapAlpha.Size = new System.Drawing.Size(47, 20);
            this.nudMapAlpha.TabIndex = 31;
            this.nudMapAlpha.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nudMapBlue
            // 
            this.nudMapBlue.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudMapBlue.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMapBlue.Location = new System.Drawing.Point(41, 55);
            this.nudMapBlue.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            this.nudMapBlue.Name = "nudMapBlue";
            this.nudMapBlue.Size = new System.Drawing.Size(47, 20);
            this.nudMapBlue.TabIndex = 30;
            this.nudMapBlue.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nudMapGreen
            // 
            this.nudMapGreen.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudMapGreen.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMapGreen.Location = new System.Drawing.Point(139, 29);
            this.nudMapGreen.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            this.nudMapGreen.Name = "nudMapGreen";
            this.nudMapGreen.Size = new System.Drawing.Size(47, 20);
            this.nudMapGreen.TabIndex = 29;
            this.nudMapGreen.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nudMapRed
            // 
            this.nudMapRed.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudMapRed.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMapRed.Location = new System.Drawing.Point(41, 29);
            this.nudMapRed.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            this.nudMapRed.Name = "nudMapRed";
            this.nudMapRed.Size = new System.Drawing.Size(47, 20);
            this.nudMapRed.TabIndex = 28;
            this.nudMapRed.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // chkUseTint
            // 
            this.chkUseTint.AutoSize = true;
            this.chkUseTint.BackColor = System.Drawing.Color.Transparent;
            this.chkUseTint.Checked = true;
            this.chkUseTint.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseTint.Location = new System.Drawing.Point(6, 13);
            this.chkUseTint.Name = "chkUseTint";
            this.chkUseTint.Size = new System.Drawing.Size(93, 17);
            this.chkUseTint.TabIndex = 25;
            this.chkUseTint.Text = "Use MapTint?";
            this.chkUseTint.UseVisualStyleBackColor = false;
            // 
            // lblMapAlpha
            // 
            this.lblMapAlpha.AutoSize = true;
            this.lblMapAlpha.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblMapAlpha.Location = new System.Drawing.Point(96, 57);
            this.lblMapAlpha.Name = "lblMapAlpha";
            this.lblMapAlpha.Size = new System.Drawing.Size(37, 13);
            this.lblMapAlpha.TabIndex = 23;
            this.lblMapAlpha.Text = "Alpha:";
            // 
            // lblMapBlue
            // 
            this.lblMapBlue.AutoSize = true;
            this.lblMapBlue.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblMapBlue.Location = new System.Drawing.Point(4, 57);
            this.lblMapBlue.Name = "lblMapBlue";
            this.lblMapBlue.Size = new System.Drawing.Size(31, 13);
            this.lblMapBlue.TabIndex = 21;
            this.lblMapBlue.Text = "Blue:";
            // 
            // lblMapGreen
            // 
            this.lblMapGreen.AutoSize = true;
            this.lblMapGreen.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblMapGreen.Location = new System.Drawing.Point(94, 31);
            this.lblMapGreen.Name = "lblMapGreen";
            this.lblMapGreen.Size = new System.Drawing.Size(39, 13);
            this.lblMapGreen.TabIndex = 19;
            this.lblMapGreen.Text = "Green:";
            // 
            // lblMapRed
            // 
            this.lblMapRed.AutoSize = true;
            this.lblMapRed.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblMapRed.Location = new System.Drawing.Point(5, 31);
            this.lblMapRed.Name = "lblMapRed";
            this.lblMapRed.Size = new System.Drawing.Size(30, 13);
            this.lblMapRed.TabIndex = 17;
            this.lblMapRed.Text = "Red:";
            // 
            // btnMoreOptions
            // 
            this.btnMoreOptions.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.btnMoreOptions.Location = new System.Drawing.Point(9, 571);
            this.btnMoreOptions.Name = "btnMoreOptions";
            this.btnMoreOptions.Padding = new System.Windows.Forms.Padding(5);
            this.btnMoreOptions.Size = new System.Drawing.Size(203, 23);
            this.btnMoreOptions.TabIndex = 30;
            this.btnMoreOptions.Text = "More Options";
            // 
            // GroupBox3
            // 
            this.GroupBox3.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox3.Controls.Add(this.btnPreview);
            this.GroupBox3.Controls.Add(this.lstMusic);
            this.GroupBox3.ForeColor = System.Drawing.Color.LightGray;
            this.GroupBox3.Location = new System.Drawing.Point(9, 335);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(203, 136);
            this.GroupBox3.TabIndex = 29;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Music";
            // 
            // btnPreview
            // 
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.btnPreview.Image = (System.Drawing.Image)resources.GetObject("btnPreview.Image");
            this.btnPreview.Location = new System.Drawing.Point(9, 102);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Padding = new System.Windows.Forms.Padding(5);
            this.btnPreview.Size = new System.Drawing.Size(185, 23);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "Preview Music";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseMnemonic = false;
            // 
            // lstMusic
            // 
            this.lstMusic.FormattingEnabled = true;
            this.lstMusic.Location = new System.Drawing.Point(6, 14);
            this.lstMusic.Name = "lstMusic";
            this.lstMusic.ScrollAlwaysVisible = true;
            this.lstMusic.Size = new System.Drawing.Size(191, 82);
            this.lstMusic.TabIndex = 4;
            // 
            // GroupBox2
            // 
            this.GroupBox2.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox2.Controls.Add(this.nudMaxY);
            this.GroupBox2.Controls.Add(this.nudMaxX);
            this.GroupBox2.Controls.Add(this.btnSetSize);
            this.GroupBox2.Controls.Add(this.DarkLabel13);
            this.GroupBox2.Controls.Add(this.DarkLabel12);
            this.GroupBox2.ForeColor = System.Drawing.Color.LightGray;
            this.GroupBox2.Location = new System.Drawing.Point(9, 264);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(203, 69);
            this.GroupBox2.TabIndex = 28;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Map Size";
            // 
            // nudMaxY
            // 
            this.nudMaxY.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudMaxY.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMaxY.Location = new System.Drawing.Point(145, 14);
            this.nudMaxY.Name = "nudMaxY";
            this.nudMaxY.Size = new System.Drawing.Size(41, 20);
            this.nudMaxY.TabIndex = 6;
            this.nudMaxY.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nudMaxX
            // 
            this.nudMaxX.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudMaxX.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMaxX.Location = new System.Drawing.Point(52, 14);
            this.nudMaxX.Name = "nudMaxX";
            this.nudMaxX.Size = new System.Drawing.Size(41, 20);
            this.nudMaxX.TabIndex = 5;
            this.nudMaxX.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // btnSetSize
            // 
            this.btnSetSize.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.btnSetSize.Location = new System.Drawing.Point(64, 39);
            this.btnSetSize.Name = "btnSetSize";
            this.btnSetSize.Padding = new System.Windows.Forms.Padding(5);
            this.btnSetSize.Size = new System.Drawing.Size(75, 23);
            this.btnSetSize.TabIndex = 4;
            this.btnSetSize.Text = "Set Size";
            // 
            // DarkLabel13
            // 
            this.DarkLabel13.AutoSize = true;
            this.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel13.Location = new System.Drawing.Point(99, 16);
            this.DarkLabel13.Name = "DarkLabel13";
            this.DarkLabel13.Size = new System.Drawing.Size(40, 13);
            this.DarkLabel13.TabIndex = 1;
            this.DarkLabel13.Text = "Max Y:";
            // 
            // DarkLabel12
            // 
            this.DarkLabel12.AutoSize = true;
            this.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel12.Location = new System.Drawing.Point(6, 16);
            this.DarkLabel12.Name = "DarkLabel12";
            this.DarkLabel12.Size = new System.Drawing.Size(40, 13);
            this.DarkLabel12.TabIndex = 0;
            this.DarkLabel12.Text = "Max X:";
            // 
            // GroupBox1
            // 
            this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
            this.GroupBox1.Controls.Add(this.nudSpawnY);
            this.GroupBox1.Controls.Add(this.nudSpawnX);
            this.GroupBox1.Controls.Add(this.nudSpawnMap);
            this.GroupBox1.Controls.Add(this.DarkLabel11);
            this.GroupBox1.Controls.Add(this.DarkLabel10);
            this.GroupBox1.Controls.Add(this.DarkLabel9);
            this.GroupBox1.ForeColor = System.Drawing.Color.LightGray;
            this.GroupBox1.Location = new System.Drawing.Point(9, 189);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(203, 74);
            this.GroupBox1.TabIndex = 27;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Respawn Settings";
            // 
            // nudSpawnY
            // 
            this.nudSpawnY.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudSpawnY.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpawnY.Location = new System.Drawing.Point(143, 44);
            this.nudSpawnY.Name = "nudSpawnY";
            this.nudSpawnY.Size = new System.Drawing.Size(51, 20);
            this.nudSpawnY.TabIndex = 29;
            this.nudSpawnY.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nudSpawnX
            // 
            this.nudSpawnX.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudSpawnX.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpawnX.Location = new System.Drawing.Point(48, 44);
            this.nudSpawnX.Name = "nudSpawnX";
            this.nudSpawnX.Size = new System.Drawing.Size(51, 20);
            this.nudSpawnX.TabIndex = 28;
            this.nudSpawnX.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nudSpawnMap
            // 
            this.nudSpawnMap.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudSpawnMap.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpawnMap.Location = new System.Drawing.Point(108, 18);
            this.nudSpawnMap.Name = "nudSpawnMap";
            this.nudSpawnMap.Size = new System.Drawing.Size(86, 20);
            this.nudSpawnMap.TabIndex = 6;
            this.nudSpawnMap.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // DarkLabel11
            // 
            this.DarkLabel11.AutoSize = true;
            this.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel11.Location = new System.Drawing.Point(120, 46);
            this.DarkLabel11.Name = "DarkLabel11";
            this.DarkLabel11.Size = new System.Drawing.Size(17, 13);
            this.DarkLabel11.TabIndex = 2;
            this.DarkLabel11.Text = "Y:";
            // 
            // DarkLabel10
            // 
            this.DarkLabel10.AutoSize = true;
            this.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel10.Location = new System.Drawing.Point(7, 46);
            this.DarkLabel10.Name = "DarkLabel10";
            this.DarkLabel10.Size = new System.Drawing.Size(17, 13);
            this.DarkLabel10.TabIndex = 1;
            this.DarkLabel10.Text = "X:";
            // 
            // DarkLabel9
            // 
            this.DarkLabel9.AutoSize = true;
            this.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel9.Location = new System.Drawing.Point(6, 22);
            this.DarkLabel9.Name = "DarkLabel9";
            this.DarkLabel9.Size = new System.Drawing.Size(79, 13);
            this.DarkLabel9.TabIndex = 0;
            this.DarkLabel9.Text = "Respawn Map:";
            // 
            // DarkLabel7
            // 
            this.DarkLabel7.AutoSize = true;
            this.DarkLabel7.BackColor = System.Drawing.Color.Transparent;
            this.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel7.Location = new System.Drawing.Point(6, 33);
            this.DarkLabel7.Name = "DarkLabel7";
            this.DarkLabel7.Size = new System.Drawing.Size(38, 13);
            this.DarkLabel7.TabIndex = 21;
            this.DarkLabel7.Text = "Name:";
            // 
            // chkInstance
            // 
            this.chkInstance.AutoSize = true;
            this.chkInstance.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.chkInstance.ForeColor = System.Drawing.Color.Gainsboro;
            this.chkInstance.Location = new System.Drawing.Point(9, 85);
            this.chkInstance.Name = "chkInstance";
            this.chkInstance.Size = new System.Drawing.Size(79, 17);
            this.chkInstance.TabIndex = 26;
            this.chkInstance.Text = "Instanced?";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.txtName.Location = new System.Drawing.Point(50, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(162, 20);
            this.txtName.TabIndex = 22;
            // 
            // DarkLabel8
            // 
            this.DarkLabel8.AutoSize = true;
            this.DarkLabel8.BackColor = System.Drawing.Color.Transparent;
            this.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel8.Location = new System.Drawing.Point(8, 60);
            this.DarkLabel8.Name = "DarkLabel8";
            this.DarkLabel8.Size = new System.Drawing.Size(36, 13);
            this.DarkLabel8.TabIndex = 25;
            this.DarkLabel8.Text = "Moral:";
            // 
            // fraMapLinks
            // 
            this.fraMapLinks.BackColor = System.Drawing.Color.Transparent;
            this.fraMapLinks.Controls.Add(this.nudRight);
            this.fraMapLinks.Controls.Add(this.nudLeft);
            this.fraMapLinks.Controls.Add(this.nudDown);
            this.fraMapLinks.Controls.Add(this.nudUp);
            this.fraMapLinks.Controls.Add(this.lblMap);
            this.fraMapLinks.ForeColor = System.Drawing.Color.LightGray;
            this.fraMapLinks.Location = new System.Drawing.Point(9, 105);
            this.fraMapLinks.Name = "fraMapLinks";
            this.fraMapLinks.Size = new System.Drawing.Size(203, 82);
            this.fraMapLinks.TabIndex = 23;
            this.fraMapLinks.TabStop = false;
            this.fraMapLinks.Text = "Map Links";
            // 
            // nudRight
            // 
            this.nudRight.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudRight.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudRight.Location = new System.Drawing.Point(147, 34);
            this.nudRight.Name = "nudRight";
            this.nudRight.Size = new System.Drawing.Size(50, 20);
            this.nudRight.TabIndex = 8;
            this.nudRight.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nudLeft
            // 
            this.nudLeft.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudLeft.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLeft.Location = new System.Drawing.Point(6, 34);
            this.nudLeft.Name = "nudLeft";
            this.nudLeft.Size = new System.Drawing.Size(50, 20);
            this.nudLeft.TabIndex = 7;
            this.nudLeft.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nudDown
            // 
            this.nudDown.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudDown.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDown.Location = new System.Drawing.Point(75, 54);
            this.nudDown.Name = "nudDown";
            this.nudDown.Size = new System.Drawing.Size(50, 20);
            this.nudDown.TabIndex = 6;
            this.nudDown.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // nudUp
            // 
            this.nudUp.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudUp.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudUp.Location = new System.Drawing.Point(75, 11);
            this.nudUp.Name = "nudUp";
            this.nudUp.Size = new System.Drawing.Size(50, 20);
            this.nudUp.TabIndex = 5;
            this.nudUp.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblMap.Location = new System.Drawing.Point(72, 36);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(65, 13);
            this.lblMap.TabIndex = 4;
            this.lblMap.Text = "Curr. Map: 0";
            // 
            // cmbMoral
            // 
            this.cmbMoral.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.cmbMoral.ForeColor = System.Drawing.Color.LightGray;
            this.cmbMoral.FormattingEnabled = true;
            this.cmbMoral.Items.AddRange(new object[] { "None", "Safe Zone", "Indoors" });
            this.cmbMoral.Location = new System.Drawing.Point(50, 57);
            this.cmbMoral.Name = "cmbMoral";
            this.cmbMoral.Size = new System.Drawing.Size(162, 21);
            this.cmbMoral.TabIndex = 24;
            // 
            // ToolStrip
            // 
            this.ToolStrip.AutoSize = false;
            this.ToolStrip.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.ToolStrip.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.tsbSave, this.tsbDiscard, this.ToolStripSeparator1, this.tsbMapGrid, this.ToolStripSeparator2, this.tsbFill, this.tsbClear, this.ToolStripSeparator3, this.ToolStripLabel1, this.cmbMapList, this.ToolStripSeparator4, this.tsbScreenShot });
            this.ToolStrip.Location = new System.Drawing.Point(318, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Padding = new System.Windows.Forms.Padding(5, 0, 1, 0);
            this.ToolStrip.Size = new System.Drawing.Size(758, 25);
            this.ToolStrip.Stretch = true;
            this.ToolStrip.TabIndex = 11;
            this.ToolStrip.Text = "DarkToolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.tsbSave.Image = (System.Drawing.Image)resources.GetObject("tsbSave.Image");
            this.tsbSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(78, 22);
            this.tsbSave.Text = "Save Map";
            // 
            // tsbDiscard
            // 
            this.tsbDiscard.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.tsbDiscard.Image = (System.Drawing.Image)resources.GetObject("tsbDiscard.Image");
            this.tsbDiscard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDiscard.Name = "tsbDiscard";
            this.tsbDiscard.Size = new System.Drawing.Size(66, 22);
            this.tsbDiscard.Text = "Discard";
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.ToolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbMapGrid
            // 
            this.tsbMapGrid.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.tsbMapGrid.Image = (System.Drawing.Image)resources.GetObject("tsbMapGrid.Image");
            this.tsbMapGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMapGrid.Name = "tsbMapGrid";
            this.tsbMapGrid.Size = new System.Drawing.Size(76, 22);
            this.tsbMapGrid.Text = "Map Grid";
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.ToolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbFill
            // 
            this.tsbFill.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.tsbFill.Image = (System.Drawing.Image)resources.GetObject("tsbFill.Image");
            this.tsbFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFill.Name = "tsbFill";
            this.tsbFill.Size = new System.Drawing.Size(73, 22);
            this.tsbFill.Text = "Fill Layer";
            // 
            // tsbClear
            // 
            this.tsbClear.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.tsbClear.Image = (System.Drawing.Image)resources.GetObject("tsbClear.Image");
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(85, 22);
            this.tsbClear.Text = "Clear Layer";
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.ToolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripLabel1
            // 
            this.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.ToolStripLabel1.Name = "ToolStripLabel1";
            this.ToolStripLabel1.Size = new System.Drawing.Size(34, 22);
            this.ToolStripLabel1.Text = "Map:";
            // 
            // cmbMapList
            // 
            this.cmbMapList.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.cmbMapList.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.cmbMapList.Name = "cmbMapList";
            this.cmbMapList.Size = new System.Drawing.Size(121, 25);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.ToolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbScreenShot
            // 
            this.tsbScreenShot.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.tsbScreenShot.Image = (System.Drawing.Image)resources.GetObject("tsbScreenShot.Image");
            this.tsbScreenShot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbScreenShot.Name = "tsbScreenShot";
            this.tsbScreenShot.Size = new System.Drawing.Size(86, 22);
            this.tsbScreenShot.Text = "ScreenShot";
            // 
            // pnlBack2
            // 
            this.pnlBack2.Controls.Add(this.pnlAttributes);
            this.pnlBack2.Controls.Add(this.scrlMapViewV);
            this.pnlBack2.Controls.Add(this.scrlMapViewH);
            this.pnlBack2.Controls.Add(this.picScreen);
            this.pnlBack2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack2.Location = new System.Drawing.Point(318, 25);
            this.pnlBack2.Name = "pnlBack2";
            this.pnlBack2.SectionHeader = "MapView";
            this.pnlBack2.Size = new System.Drawing.Size(758, 573);
            this.pnlBack2.TabIndex = 12;
            // 
            // pnlAttributes
            // 
            this.pnlAttributes.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(60)), System.Convert.ToInt32(System.Convert.ToByte(63)), System.Convert.ToInt32(System.Convert.ToByte(65)));
            this.pnlAttributes.Controls.Add(this.fraMapWarp);
            this.pnlAttributes.Controls.Add(this.fraBuyHouse);
            this.pnlAttributes.Controls.Add(this.fraKeyOpen);
            this.pnlAttributes.Controls.Add(this.fraMapKey);
            this.pnlAttributes.Controls.Add(this.fraNpcSpawn);
            this.pnlAttributes.Controls.Add(this.fraHeal);
            this.pnlAttributes.Controls.Add(this.fraShop);
            this.pnlAttributes.Controls.Add(this.fraResource);
            this.pnlAttributes.Controls.Add(this.fraMapItem);
            this.pnlAttributes.Controls.Add(this.fraTrap);
            this.pnlAttributes.ForeColor = System.Drawing.Color.LightGray;
            this.pnlAttributes.Location = new System.Drawing.Point(6, 34);
            this.pnlAttributes.Name = "pnlAttributes";
            this.pnlAttributes.Size = new System.Drawing.Size(709, 516);
            this.pnlAttributes.TabIndex = 11;
            this.pnlAttributes.Visible = false;
            // 
            // fraMapWarp
            // 
            this.fraMapWarp.Controls.Add(this.lblVisualWarp);
            this.fraMapWarp.Controls.Add(this.btnMapWarp);
            this.fraMapWarp.Controls.Add(this.scrlMapWarpY);
            this.fraMapWarp.Controls.Add(this.scrlMapWarpX);
            this.fraMapWarp.Controls.Add(this.scrlMapWarpMap);
            this.fraMapWarp.Controls.Add(this.lblMapWarpY);
            this.fraMapWarp.Controls.Add(this.lblMapWarpX);
            this.fraMapWarp.Controls.Add(this.lblMapWarpMap);
            this.fraMapWarp.ForeColor = System.Drawing.Color.LightGray;
            this.fraMapWarp.Location = new System.Drawing.Point(428, 134);
            this.fraMapWarp.Name = "fraMapWarp";
            this.fraMapWarp.Size = new System.Drawing.Size(211, 158);
            this.fraMapWarp.TabIndex = 18;
            this.fraMapWarp.TabStop = false;
            this.fraMapWarp.Text = "Map Warp";
            // 
            // lblVisualWarp
            // 
            this.lblVisualWarp.AutoSize = true;
            this.lblVisualWarp.Location = new System.Drawing.Point(8, 120);
            this.lblVisualWarp.Name = "lblVisualWarp";
            this.lblVisualWarp.Size = new System.Drawing.Size(64, 13);
            this.lblVisualWarp.TabIndex = 7;
            this.lblVisualWarp.Text = "Visual Warp";
            // 
            // btnMapWarp
            // 
            this.btnMapWarp.ForeColor = System.Drawing.Color.Black;
            this.btnMapWarp.Location = new System.Drawing.Point(84, 81);
            this.btnMapWarp.Name = "btnMapWarp";
            this.btnMapWarp.Size = new System.Drawing.Size(90, 28);
            this.btnMapWarp.TabIndex = 6;
            this.btnMapWarp.Text = "Accept";
            this.btnMapWarp.UseVisualStyleBackColor = true;
            // 
            // scrlMapWarpY
            // 
            this.scrlMapWarpY.Location = new System.Drawing.Point(58, 60);
            this.scrlMapWarpY.Name = "scrlMapWarpY";
            this.scrlMapWarpY.Size = new System.Drawing.Size(144, 18);
            this.scrlMapWarpY.TabIndex = 5;
            // 
            // scrlMapWarpX
            // 
            this.scrlMapWarpX.Location = new System.Drawing.Point(58, 38);
            this.scrlMapWarpX.Name = "scrlMapWarpX";
            this.scrlMapWarpX.Size = new System.Drawing.Size(144, 18);
            this.scrlMapWarpX.TabIndex = 4;
            // 
            // scrlMapWarpMap
            // 
            this.scrlMapWarpMap.Location = new System.Drawing.Point(58, 16);
            this.scrlMapWarpMap.Name = "scrlMapWarpMap";
            this.scrlMapWarpMap.Size = new System.Drawing.Size(144, 18);
            this.scrlMapWarpMap.TabIndex = 3;
            // 
            // lblMapWarpY
            // 
            this.lblMapWarpY.AutoSize = true;
            this.lblMapWarpY.Location = new System.Drawing.Point(7, 62);
            this.lblMapWarpY.Name = "lblMapWarpY";
            this.lblMapWarpY.Size = new System.Drawing.Size(26, 13);
            this.lblMapWarpY.TabIndex = 2;
            this.lblMapWarpY.Text = "Y: 1";
            // 
            // lblMapWarpX
            // 
            this.lblMapWarpX.AutoSize = true;
            this.lblMapWarpX.Location = new System.Drawing.Point(7, 41);
            this.lblMapWarpX.Name = "lblMapWarpX";
            this.lblMapWarpX.Size = new System.Drawing.Size(26, 13);
            this.lblMapWarpX.TabIndex = 1;
            this.lblMapWarpX.Text = "X: 1";
            // 
            // lblMapWarpMap
            // 
            this.lblMapWarpMap.AutoSize = true;
            this.lblMapWarpMap.Location = new System.Drawing.Point(6, 21);
            this.lblMapWarpMap.Name = "lblMapWarpMap";
            this.lblMapWarpMap.Size = new System.Drawing.Size(40, 13);
            this.lblMapWarpMap.TabIndex = 0;
            this.lblMapWarpMap.Text = "Map: 1";
            // 
            // fraBuyHouse
            // 
            this.fraBuyHouse.Controls.Add(this.btnHouseTileOk);
            this.fraBuyHouse.Controls.Add(this.scrlBuyHouse);
            this.fraBuyHouse.Controls.Add(this.lblHouseName);
            this.fraBuyHouse.ForeColor = System.Drawing.Color.LightGray;
            this.fraBuyHouse.Location = new System.Drawing.Point(428, 9);
            this.fraBuyHouse.Name = "fraBuyHouse";
            this.fraBuyHouse.Size = new System.Drawing.Size(211, 119);
            this.fraBuyHouse.TabIndex = 27;
            this.fraBuyHouse.TabStop = false;
            this.fraBuyHouse.Text = "Buy House";
            // 
            // btnHouseTileOk
            // 
            this.btnHouseTileOk.ForeColor = System.Drawing.Color.Black;
            this.btnHouseTileOk.Location = new System.Drawing.Point(58, 85);
            this.btnHouseTileOk.Name = "btnHouseTileOk";
            this.btnHouseTileOk.Size = new System.Drawing.Size(90, 28);
            this.btnHouseTileOk.TabIndex = 6;
            this.btnHouseTileOk.Text = "Accept";
            this.btnHouseTileOk.UseVisualStyleBackColor = true;
            // 
            // scrlBuyHouse
            // 
            this.scrlBuyHouse.LargeChange = 1;
            this.scrlBuyHouse.Location = new System.Drawing.Point(9, 36);
            this.scrlBuyHouse.Name = "scrlBuyHouse";
            this.scrlBuyHouse.Size = new System.Drawing.Size(193, 18);
            this.scrlBuyHouse.TabIndex = 3;
            // 
            // lblHouseName
            // 
            this.lblHouseName.AutoSize = true;
            this.lblHouseName.Location = new System.Drawing.Point(6, 16);
            this.lblHouseName.Name = "lblHouseName";
            this.lblHouseName.Size = new System.Drawing.Size(41, 13);
            this.lblHouseName.TabIndex = 0;
            this.lblHouseName.Text = "House:";
            // 
            // fraKeyOpen
            // 
            this.fraKeyOpen.Controls.Add(this.scrlKeyY);
            this.fraKeyOpen.Controls.Add(this.lblKeyY);
            this.fraKeyOpen.Controls.Add(this.btnMapKeyOpen);
            this.fraKeyOpen.Controls.Add(this.scrlKeyX);
            this.fraKeyOpen.Controls.Add(this.lblKeyX);
            this.fraKeyOpen.ForeColor = System.Drawing.Color.LightGray;
            this.fraKeyOpen.Location = new System.Drawing.Point(3, 369);
            this.fraKeyOpen.Name = "fraKeyOpen";
            this.fraKeyOpen.Size = new System.Drawing.Size(207, 138);
            this.fraKeyOpen.TabIndex = 21;
            this.fraKeyOpen.TabStop = false;
            this.fraKeyOpen.Text = "Map Key Open";
            // 
            // scrlKeyY
            // 
            this.scrlKeyY.Location = new System.Drawing.Point(9, 76);
            this.scrlKeyY.Name = "scrlKeyY";
            this.scrlKeyY.Size = new System.Drawing.Size(160, 18);
            this.scrlKeyY.TabIndex = 8;
            // 
            // lblKeyY
            // 
            this.lblKeyY.AutoSize = true;
            this.lblKeyY.Location = new System.Drawing.Point(6, 61);
            this.lblKeyY.Name = "lblKeyY";
            this.lblKeyY.Size = new System.Drawing.Size(26, 13);
            this.lblKeyY.TabIndex = 7;
            this.lblKeyY.Text = "Y: 0";
            // 
            // btnMapKeyOpen
            // 
            this.btnMapKeyOpen.ForeColor = System.Drawing.Color.Black;
            this.btnMapKeyOpen.Location = new System.Drawing.Point(53, 105);
            this.btnMapKeyOpen.Name = "btnMapKeyOpen";
            this.btnMapKeyOpen.Size = new System.Drawing.Size(90, 28);
            this.btnMapKeyOpen.TabIndex = 6;
            this.btnMapKeyOpen.Text = "Accept";
            this.btnMapKeyOpen.UseVisualStyleBackColor = true;
            // 
            // scrlKeyX
            // 
            this.scrlKeyX.Location = new System.Drawing.Point(9, 37);
            this.scrlKeyX.Name = "scrlKeyX";
            this.scrlKeyX.Size = new System.Drawing.Size(160, 18);
            this.scrlKeyX.TabIndex = 3;
            // 
            // lblKeyX
            // 
            this.lblKeyX.AutoSize = true;
            this.lblKeyX.Location = new System.Drawing.Point(6, 22);
            this.lblKeyX.Name = "lblKeyX";
            this.lblKeyX.Size = new System.Drawing.Size(26, 13);
            this.lblKeyX.TabIndex = 0;
            this.lblKeyX.Text = "X: 0";
            // 
            // fraMapKey
            // 
            this.fraMapKey.Controls.Add(this.chkMapKey);
            this.fraMapKey.Controls.Add(this.picMapKey);
            this.fraMapKey.Controls.Add(this.btnMapKey);
            this.fraMapKey.Controls.Add(this.scrlMapKey);
            this.fraMapKey.Controls.Add(this.lblMapKey);
            this.fraMapKey.ForeColor = System.Drawing.Color.LightGray;
            this.fraMapKey.Location = new System.Drawing.Point(216, 369);
            this.fraMapKey.Name = "fraMapKey";
            this.fraMapKey.Size = new System.Drawing.Size(206, 138);
            this.fraMapKey.TabIndex = 20;
            this.fraMapKey.TabStop = false;
            this.fraMapKey.Text = "Map Key";
            // 
            // chkMapKey
            // 
            this.chkMapKey.AutoSize = true;
            this.chkMapKey.Checked = true;
            this.chkMapKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMapKey.Location = new System.Drawing.Point(9, 64);
            this.chkMapKey.Name = "chkMapKey";
            this.chkMapKey.Size = new System.Drawing.Size(152, 17);
            this.chkMapKey.TabIndex = 8;
            this.chkMapKey.Text = "Take Key Away Upon Use";
            this.chkMapKey.UseVisualStyleBackColor = true;
            // 
            // picMapKey
            // 
            this.picMapKey.BackColor = System.Drawing.Color.Black;
            this.picMapKey.Location = new System.Drawing.Point(172, 25);
            this.picMapKey.Name = "picMapKey";
            this.picMapKey.Size = new System.Drawing.Size(32, 32);
            this.picMapKey.TabIndex = 7;
            this.picMapKey.TabStop = false;
            // 
            // btnMapKey
            // 
            this.btnMapKey.ForeColor = System.Drawing.Color.Black;
            this.btnMapKey.Location = new System.Drawing.Point(54, 103);
            this.btnMapKey.Name = "btnMapKey";
            this.btnMapKey.Size = new System.Drawing.Size(90, 28);
            this.btnMapKey.TabIndex = 6;
            this.btnMapKey.Text = "Accept";
            this.btnMapKey.UseVisualStyleBackColor = true;
            // 
            // scrlMapKey
            // 
            this.scrlMapKey.Location = new System.Drawing.Point(9, 37);
            this.scrlMapKey.Name = "scrlMapKey";
            this.scrlMapKey.Size = new System.Drawing.Size(160, 18);
            this.scrlMapKey.TabIndex = 3;
            // 
            // lblMapKey
            // 
            this.lblMapKey.AutoSize = true;
            this.lblMapKey.Location = new System.Drawing.Point(6, 22);
            this.lblMapKey.Name = "lblMapKey";
            this.lblMapKey.Size = new System.Drawing.Size(59, 13);
            this.lblMapKey.TabIndex = 0;
            this.lblMapKey.Text = "Item: None";
            // 
            // fraNpcSpawn
            // 
            this.fraNpcSpawn.Controls.Add(this.lstNpc);
            this.fraNpcSpawn.Controls.Add(this.btnNpcSpawn);
            this.fraNpcSpawn.Controls.Add(this.scrlNpcDir);
            this.fraNpcSpawn.Controls.Add(this.lblNpcDir);
            this.fraNpcSpawn.ForeColor = System.Drawing.Color.LightGray;
            this.fraNpcSpawn.Location = new System.Drawing.Point(3, 8);
            this.fraNpcSpawn.Name = "fraNpcSpawn";
            this.fraNpcSpawn.Size = new System.Drawing.Size(207, 120);
            this.fraNpcSpawn.TabIndex = 23;
            this.fraNpcSpawn.TabStop = false;
            this.fraNpcSpawn.Text = "Npc Spawn";
            // 
            // lstNpc
            // 
            this.lstNpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstNpc.FormattingEnabled = true;
            this.lstNpc.Location = new System.Drawing.Point(6, 21);
            this.lstNpc.Name = "lstNpc";
            this.lstNpc.Size = new System.Drawing.Size(192, 21);
            this.lstNpc.TabIndex = 37;
            // 
            // btnNpcSpawn
            // 
            this.btnNpcSpawn.BackColor = System.Drawing.SystemColors.Control;
            this.btnNpcSpawn.ForeColor = System.Drawing.Color.Black;
            this.btnNpcSpawn.Location = new System.Drawing.Point(53, 86);
            this.btnNpcSpawn.Name = "btnNpcSpawn";
            this.btnNpcSpawn.Size = new System.Drawing.Size(90, 28);
            this.btnNpcSpawn.TabIndex = 6;
            this.btnNpcSpawn.Text = "Accept";
            this.btnNpcSpawn.UseVisualStyleBackColor = false;
            // 
            // scrlNpcDir
            // 
            this.scrlNpcDir.LargeChange = 1;
            this.scrlNpcDir.Location = new System.Drawing.Point(6, 64);
            this.scrlNpcDir.Maximum = 3;
            this.scrlNpcDir.Name = "scrlNpcDir";
            this.scrlNpcDir.Size = new System.Drawing.Size(193, 18);
            this.scrlNpcDir.TabIndex = 3;
            // 
            // lblNpcDir
            // 
            this.lblNpcDir.AutoSize = true;
            this.lblNpcDir.Location = new System.Drawing.Point(3, 49);
            this.lblNpcDir.Name = "lblNpcDir";
            this.lblNpcDir.Size = new System.Drawing.Size(69, 13);
            this.lblNpcDir.TabIndex = 0;
            this.lblNpcDir.Text = "Direction: Up";
            // 
            // fraHeal
            // 
            this.fraHeal.Controls.Add(this.scrlHeal);
            this.fraHeal.Controls.Add(this.lblHeal);
            this.fraHeal.Controls.Add(this.cmbHeal);
            this.fraHeal.Controls.Add(this.btnHeal);
            this.fraHeal.ForeColor = System.Drawing.Color.LightGray;
            this.fraHeal.Location = new System.Drawing.Point(3, 252);
            this.fraHeal.Name = "fraHeal";
            this.fraHeal.Size = new System.Drawing.Size(207, 111);
            this.fraHeal.TabIndex = 25;
            this.fraHeal.TabStop = false;
            this.fraHeal.Text = "Heal";
            // 
            // scrlHeal
            // 
            this.scrlHeal.Location = new System.Drawing.Point(7, 56);
            this.scrlHeal.Name = "scrlHeal";
            this.scrlHeal.Size = new System.Drawing.Size(191, 17);
            this.scrlHeal.TabIndex = 39;
            // 
            // lblHeal
            // 
            this.lblHeal.AutoSize = true;
            this.lblHeal.Location = new System.Drawing.Point(8, 43);
            this.lblHeal.Name = "lblHeal";
            this.lblHeal.Size = new System.Drawing.Size(55, 13);
            this.lblHeal.TabIndex = 38;
            this.lblHeal.Text = "Amount: 0";
            // 
            // cmbHeal
            // 
            this.cmbHeal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHeal.FormattingEnabled = true;
            this.cmbHeal.Items.AddRange(new object[] { "Hp", "Mp" });
            this.cmbHeal.Location = new System.Drawing.Point(7, 19);
            this.cmbHeal.Name = "cmbHeal";
            this.cmbHeal.Size = new System.Drawing.Size(192, 21);
            this.cmbHeal.TabIndex = 37;
            // 
            // btnHeal
            // 
            this.btnHeal.ForeColor = System.Drawing.Color.Black;
            this.btnHeal.Location = new System.Drawing.Point(53, 76);
            this.btnHeal.Name = "btnHeal";
            this.btnHeal.Size = new System.Drawing.Size(90, 28);
            this.btnHeal.TabIndex = 6;
            this.btnHeal.Text = "Accept";
            this.btnHeal.UseVisualStyleBackColor = true;
            // 
            // fraShop
            // 
            this.fraShop.Controls.Add(this.cmbShop);
            this.fraShop.Controls.Add(this.btnShop);
            this.fraShop.ForeColor = System.Drawing.Color.LightGray;
            this.fraShop.Location = new System.Drawing.Point(216, 252);
            this.fraShop.Name = "fraShop";
            this.fraShop.Size = new System.Drawing.Size(206, 111);
            this.fraShop.TabIndex = 24;
            this.fraShop.TabStop = false;
            this.fraShop.Text = "Shop";
            // 
            // cmbShop
            // 
            this.cmbShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShop.FormattingEnabled = true;
            this.cmbShop.Location = new System.Drawing.Point(6, 19);
            this.cmbShop.Name = "cmbShop";
            this.cmbShop.Size = new System.Drawing.Size(192, 21);
            this.cmbShop.TabIndex = 37;
            // 
            // btnShop
            // 
            this.btnShop.ForeColor = System.Drawing.Color.Black;
            this.btnShop.Location = new System.Drawing.Point(54, 76);
            this.btnShop.Name = "btnShop";
            this.btnShop.Size = new System.Drawing.Size(90, 28);
            this.btnShop.TabIndex = 6;
            this.btnShop.Text = "Accept";
            this.btnShop.UseVisualStyleBackColor = true;
            // 
            // fraResource
            // 
            this.fraResource.Controls.Add(this.btnResourceOk);
            this.fraResource.Controls.Add(this.scrlResource);
            this.fraResource.Controls.Add(this.lblResource);
            this.fraResource.ForeColor = System.Drawing.Color.LightGray;
            this.fraResource.Location = new System.Drawing.Point(216, 8);
            this.fraResource.Name = "fraResource";
            this.fraResource.Size = new System.Drawing.Size(206, 120);
            this.fraResource.TabIndex = 22;
            this.fraResource.TabStop = false;
            this.fraResource.Text = "Resources";
            // 
            // btnResourceOk
            // 
            this.btnResourceOk.ForeColor = System.Drawing.Color.Black;
            this.btnResourceOk.Location = new System.Drawing.Point(56, 86);
            this.btnResourceOk.Name = "btnResourceOk";
            this.btnResourceOk.Size = new System.Drawing.Size(90, 28);
            this.btnResourceOk.TabIndex = 6;
            this.btnResourceOk.Text = "Accept";
            this.btnResourceOk.UseVisualStyleBackColor = true;
            // 
            // scrlResource
            // 
            this.scrlResource.Location = new System.Drawing.Point(9, 49);
            this.scrlResource.Name = "scrlResource";
            this.scrlResource.Size = new System.Drawing.Size(182, 18);
            this.scrlResource.TabIndex = 3;
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.Location = new System.Drawing.Point(6, 29);
            this.lblResource.Name = "lblResource";
            this.lblResource.Size = new System.Drawing.Size(41, 13);
            this.lblResource.TabIndex = 0;
            this.lblResource.Text = "Object:";
            // 
            // fraMapItem
            // 
            this.fraMapItem.Controls.Add(this.picMapItem);
            this.fraMapItem.Controls.Add(this.btnMapItem);
            this.fraMapItem.Controls.Add(this.scrlMapItemValue);
            this.fraMapItem.Controls.Add(this.scrlMapItem);
            this.fraMapItem.Controls.Add(this.lblMapItem);
            this.fraMapItem.ForeColor = System.Drawing.Color.LightGray;
            this.fraMapItem.Location = new System.Drawing.Point(216, 134);
            this.fraMapItem.Name = "fraMapItem";
            this.fraMapItem.Size = new System.Drawing.Size(206, 112);
            this.fraMapItem.TabIndex = 19;
            this.fraMapItem.TabStop = false;
            this.fraMapItem.Text = "Map Item";
            // 
            // picMapItem
            // 
            this.picMapItem.BackColor = System.Drawing.Color.Black;
            this.picMapItem.Location = new System.Drawing.Point(161, 31);
            this.picMapItem.Name = "picMapItem";
            this.picMapItem.Size = new System.Drawing.Size(32, 32);
            this.picMapItem.TabIndex = 7;
            this.picMapItem.TabStop = false;
            // 
            // btnMapItem
            // 
            this.btnMapItem.ForeColor = System.Drawing.Color.Black;
            this.btnMapItem.Location = new System.Drawing.Point(58, 78);
            this.btnMapItem.Name = "btnMapItem";
            this.btnMapItem.Size = new System.Drawing.Size(90, 28);
            this.btnMapItem.TabIndex = 6;
            this.btnMapItem.Text = "Accept";
            this.btnMapItem.UseVisualStyleBackColor = true;
            // 
            // scrlMapItemValue
            // 
            this.scrlMapItemValue.Location = new System.Drawing.Point(9, 53);
            this.scrlMapItemValue.Name = "scrlMapItemValue";
            this.scrlMapItemValue.Size = new System.Drawing.Size(149, 18);
            this.scrlMapItemValue.TabIndex = 4;
            // 
            // scrlMapItem
            // 
            this.scrlMapItem.Location = new System.Drawing.Point(9, 31);
            this.scrlMapItem.Name = "scrlMapItem";
            this.scrlMapItem.Size = new System.Drawing.Size(149, 18);
            this.scrlMapItem.TabIndex = 3;
            // 
            // lblMapItem
            // 
            this.lblMapItem.AutoSize = true;
            this.lblMapItem.Location = new System.Drawing.Point(6, 16);
            this.lblMapItem.Name = "lblMapItem";
            this.lblMapItem.Size = new System.Drawing.Size(73, 13);
            this.lblMapItem.TabIndex = 0;
            this.lblMapItem.Text = "Item: None x0";
            // 
            // fraTrap
            // 
            this.fraTrap.Controls.Add(this.btnTrap);
            this.fraTrap.Controls.Add(this.scrlTrap);
            this.fraTrap.Controls.Add(this.lblTrap);
            this.fraTrap.ForeColor = System.Drawing.Color.LightGray;
            this.fraTrap.Location = new System.Drawing.Point(3, 133);
            this.fraTrap.Name = "fraTrap";
            this.fraTrap.Size = new System.Drawing.Size(207, 113);
            this.fraTrap.TabIndex = 26;
            this.fraTrap.TabStop = false;
            this.fraTrap.Text = "Trap";
            // 
            // btnTrap
            // 
            this.btnTrap.ForeColor = System.Drawing.Color.Black;
            this.btnTrap.Location = new System.Drawing.Point(53, 79);
            this.btnTrap.Name = "btnTrap";
            this.btnTrap.Size = new System.Drawing.Size(90, 28);
            this.btnTrap.TabIndex = 42;
            this.btnTrap.Text = "Accept";
            this.btnTrap.UseVisualStyleBackColor = true;
            // 
            // scrlTrap
            // 
            this.scrlTrap.Location = new System.Drawing.Point(11, 32);
            this.scrlTrap.Name = "scrlTrap";
            this.scrlTrap.Size = new System.Drawing.Size(191, 17);
            this.scrlTrap.TabIndex = 41;
            // 
            // lblTrap
            // 
            this.lblTrap.AutoSize = true;
            this.lblTrap.Location = new System.Drawing.Point(6, 15);
            this.lblTrap.Name = "lblTrap";
            this.lblTrap.Size = new System.Drawing.Size(55, 13);
            this.lblTrap.TabIndex = 40;
            this.lblTrap.Text = "Amount: 0";
            // 
            // scrlMapViewV
            // 
            this.scrlMapViewV.BackColor = System.Drawing.SystemColors.ControlDark;
            this.scrlMapViewV.Dock = System.Windows.Forms.DockStyle.Right;
            this.scrlMapViewV.Location = new System.Drawing.Point(741, 25);
            this.scrlMapViewV.Name = "scrlMapViewV";
            this.scrlMapViewV.Size = new System.Drawing.Size(16, 531);
            this.scrlMapViewV.TabIndex = 10;
            this.scrlMapViewV.Text = "DarkScrollBar1";
            // 
            // scrlMapViewH
            // 
            this.scrlMapViewH.BackColor = System.Drawing.SystemColors.ControlDark;
            this.scrlMapViewH.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scrlMapViewH.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.scrlMapViewH.Location = new System.Drawing.Point(1, 556);
            this.scrlMapViewH.Name = "scrlMapViewH";
            this.scrlMapViewH.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal;
            this.scrlMapViewH.Size = new System.Drawing.Size(756, 16);
            this.scrlMapViewH.TabIndex = 3;
            // 
            // picScreen
            // 
            this.picScreen.BackColor = System.Drawing.Color.Black;
            this.picScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.picScreen.Location = new System.Drawing.Point(1, 25);
            this.picScreen.Name = "picScreen";
            this.picScreen.Size = new System.Drawing.Size(598, 413);
            this.picScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picScreen.TabIndex = 2;
            this.picScreen.TabStop = false;
            // 
            // frmMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 626);
            this.Controls.Add(this.pnlBack2);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.DarkSectionPanel2);
            this.Controls.Add(this.DarkSectionPanel1);
            this.Controls.Add(this.ToolStripContainer2);
            this.Controls.Add(this.DarkDockPanel1);
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.Name = "frmMapEditor";
            this.Text = "Map Editor";
            this.ToolStripContainer2.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer2.ResumeLayout(false);
            this.ToolStripContainer2.PerformLayout();
            this.ssInfo.ResumeLayout(false);
            this.ssInfo.PerformLayout();
            this.DarkSectionPanel1.ResumeLayout(false);
            this.pnlTiles.ResumeLayout(false);
            this.pnlTiles.PerformLayout();
            this.pnlBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.picBackSelect).EndInit();
            this.pnlNpc.ResumeLayout(false);
            this.pnlDirBlock.ResumeLayout(false);
            this.pnlDirBlock.PerformLayout();
            this.pnlEvents.ResumeLayout(false);
            this.pnlEvents.PerformLayout();
            this.pnlAttribute.ResumeLayout(false);
            this.pnlAttribute.PerformLayout();
            this.DarkSectionPanel2.ResumeLayout(false);
            this.DarkSectionPanel2.PerformLayout();
            this.pnlMoreOptions.ResumeLayout(false);
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudFogAlpha).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudFogSpeed).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudFog).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudIntensity).EndInit();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudMapAlpha).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudMapBlue).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudMapGreen).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudMapRed).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudMaxY).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudMaxX).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudSpawnY).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSpawnX).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSpawnMap).EndInit();
            this.fraMapLinks.ResumeLayout(false);
            this.fraMapLinks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudRight).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudLeft).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudUp).EndInit();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.pnlBack2.ResumeLayout(false);
            this.pnlAttributes.ResumeLayout(false);
            this.fraMapWarp.ResumeLayout(false);
            this.fraMapWarp.PerformLayout();
            this.fraBuyHouse.ResumeLayout(false);
            this.fraBuyHouse.PerformLayout();
            this.fraKeyOpen.ResumeLayout(false);
            this.fraKeyOpen.PerformLayout();
            this.fraMapKey.ResumeLayout(false);
            this.fraMapKey.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.picMapKey).EndInit();
            this.fraNpcSpawn.ResumeLayout(false);
            this.fraNpcSpawn.PerformLayout();
            this.fraHeal.ResumeLayout(false);
            this.fraHeal.PerformLayout();
            this.fraShop.ResumeLayout(false);
            this.fraResource.ResumeLayout(false);
            this.fraResource.PerformLayout();
            this.fraMapItem.ResumeLayout(false);
            this.fraMapItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.picMapItem).EndInit();
            this.fraTrap.ResumeLayout(false);
            this.fraTrap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.picScreen).EndInit();
            this.ResumeLayout(false);
        }

        private DarkUI.Docking.DarkDockPanel _DarkDockPanel1;

        internal DarkUI.Docking.DarkDockPanel DarkDockPanel1
        {
            
            get
            {
                return _DarkDockPanel1;
            }

            
            set
            {
                if (_DarkDockPanel1 != null)
                {
                }

                _DarkDockPanel1 = value;
                if (_DarkDockPanel1 != null)
                {
                }
            }
        }

        private ToolStripContainer _ToolStripContainer2;

        internal ToolStripContainer ToolStripContainer2
        {
            
            get
            {
                return _ToolStripContainer2;
            }

            
            set
            {
                if (_ToolStripContainer2 != null)
                {
                }

                _ToolStripContainer2 = value;
                if (_ToolStripContainer2 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkSectionPanel _DarkSectionPanel1;

        internal DarkUI.Controls.DarkSectionPanel DarkSectionPanel1
        {
            
            get
            {
                return _DarkSectionPanel1;
            }

            
            set
            {
                if (_DarkSectionPanel1 != null)
                {
                }

                _DarkSectionPanel1 = value;
                if (_DarkSectionPanel1 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkSectionPanel _DarkSectionPanel2;

        internal DarkUI.Controls.DarkSectionPanel DarkSectionPanel2
        {
            
            get
            {
                return _DarkSectionPanel2;
            }

            
            set
            {
                if (_DarkSectionPanel2 != null)
                {
                }

                _DarkSectionPanel2 = value;
                if (_DarkSectionPanel2 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkToolStrip _ToolStrip;

        internal DarkUI.Controls.DarkToolStrip ToolStrip
        {
            
            get
            {
                return _ToolStrip;
            }

            
            set
            {
                if (_ToolStrip != null)
                {
                }

                _ToolStrip = value;
                if (_ToolStrip != null)
                {
                }
            }
        }

        private ToolStripButton _tsbSave;

        internal ToolStripButton tsbSave
        {
            
            get
            {
                return _tsbSave;
            }

            
            set
            {
                if (_tsbSave != null)
                {
                }

                _tsbSave = value;
                if (_tsbSave != null)
                {
                }
            }
        }

        private ToolStripButton _tsbDiscard;

        internal ToolStripButton tsbDiscard
        {
            
            get
            {
                return _tsbDiscard;
            }

            
            set
            {
                if (_tsbDiscard != null)
                {
                }

                _tsbDiscard = value;
                if (_tsbDiscard != null)
                {
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator1;

        internal ToolStripSeparator ToolStripSeparator1
        {
            
            get
            {
                return _ToolStripSeparator1;
            }

            
            set
            {
                if (_ToolStripSeparator1 != null)
                {
                }

                _ToolStripSeparator1 = value;
                if (_ToolStripSeparator1 != null)
                {
                }
            }
        }

        private ToolStripButton _tsbMapGrid;

        internal ToolStripButton tsbMapGrid
        {
            
            get
            {
                return _tsbMapGrid;
            }

            
            set
            {
                if (_tsbMapGrid != null)
                {
                }

                _tsbMapGrid = value;
                if (_tsbMapGrid != null)
                {
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator2;

        internal ToolStripSeparator ToolStripSeparator2
        {
            
            get
            {
                return _ToolStripSeparator2;
            }

            
            set
            {
                if (_ToolStripSeparator2 != null)
                {
                }

                _ToolStripSeparator2 = value;
                if (_ToolStripSeparator2 != null)
                {
                }
            }
        }

        private ToolStripButton _tsbFill;

        internal ToolStripButton tsbFill
        {
            
            get
            {
                return _tsbFill;
            }

            
            set
            {
                if (_tsbFill != null)
                {
                }

                _tsbFill = value;
                if (_tsbFill != null)
                {
                }
            }
        }

        private ToolStripButton _tsbClear;

        internal ToolStripButton tsbClear
        {
            
            get
            {
                return _tsbClear;
            }

            
            set
            {
                if (_tsbClear != null)
                {
                }

                _tsbClear = value;
                if (_tsbClear != null)
                {
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator3;

        internal ToolStripSeparator ToolStripSeparator3
        {
            
            get
            {
                return _ToolStripSeparator3;
            }

            
            set
            {
                if (_ToolStripSeparator3 != null)
                {
                }

                _ToolStripSeparator3 = value;
                if (_ToolStripSeparator3 != null)
                {
                }
            }
        }

        private ToolStripLabel _ToolStripLabel1;

        internal ToolStripLabel ToolStripLabel1
        {
            
            get
            {
                return _ToolStripLabel1;
            }

            
            set
            {
                if (_ToolStripLabel1 != null)
                {
                }

                _ToolStripLabel1 = value;
                if (_ToolStripLabel1 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkSectionPanel _pnlBack2;

        internal DarkUI.Controls.DarkSectionPanel pnlBack2
        {
            
            get
            {
                return _pnlBack2;
            }

            
            set
            {
                if (_pnlBack2 != null)
                {
                }

                _pnlBack2 = value;
                if (_pnlBack2 != null)
                {
                }
            }
        }

        private PictureBox _picScreen;

        internal PictureBox picScreen
        {
            
            get
            {
                return _picScreen;
            }

            
            set
            {
                if (_picScreen != null)
                {
                }

                _picScreen = value;
                if (_picScreen != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkStatusStrip _ssInfo;

        internal DarkUI.Controls.DarkStatusStrip ssInfo
        {
            
            get
            {
                return _ssInfo;
            }

            
            set
            {
                if (_ssInfo != null)
                {
                }

                _ssInfo = value;
                if (_ssInfo != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _tslCurMap;

        internal ToolStripStatusLabel tslCurMap
        {
            
            get
            {
                return _tslCurMap;
            }

            
            set
            {
                if (_tslCurMap != null)
                {
                }

                _tslCurMap = value;
                if (_tslCurMap != null)
                {
                }
            }
        }

        private ToolStripComboBox _cmbMapList;

        internal ToolStripComboBox cmbMapList
        {
            
            get
            {
                return _cmbMapList;
            }

            
            set
            {
                if (_cmbMapList != null)
                {
                }

                _cmbMapList = value;
                if (_cmbMapList != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnAttributes;

        internal DarkUI.Controls.DarkButton btnAttributes
        {
            
            get
            {
                return _btnAttributes;
            }

            
            set
            {
                if (_btnAttributes != null)
                {
                }

                _btnAttributes = value;
                if (_btnAttributes != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnTiles;

        internal DarkUI.Controls.DarkButton btnTiles
        {
            
            get
            {
                return _btnTiles;
            }

            
            set
            {
                if (_btnTiles != null)
                {
                }

                _btnTiles = value;
                if (_btnTiles != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkScrollBar _scrlMapViewH;

        internal DarkUI.Controls.DarkScrollBar scrlMapViewH
        {
            
            get
            {
                return _scrlMapViewH;
            }

            
            set
            {
                if (_scrlMapViewH != null)
                {
                }

                _scrlMapViewH = value;
                if (_scrlMapViewH != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnNpc;

        internal DarkUI.Controls.DarkButton btnNpc
        {
            
            get
            {
                return _btnNpc;
            }

            
            set
            {
                if (_btnNpc != null)
                {
                }

                _btnNpc = value;
                if (_btnNpc != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnDirBlock;

        internal DarkUI.Controls.DarkButton btnDirBlock
        {
            
            get
            {
                return _btnDirBlock;
            }

            
            set
            {
                if (_btnDirBlock != null)
                {
                }

                _btnDirBlock = value;
                if (_btnDirBlock != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnEvents;

        internal DarkUI.Controls.DarkButton btnEvents
        {
            
            get
            {
                return _btnEvents;
            }

            
            set
            {
                if (_btnEvents != null)
                {
                }

                _btnEvents = value;
                if (_btnEvents != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkScrollBar _scrlMapViewV;

        internal DarkUI.Controls.DarkScrollBar scrlMapViewV
        {
            
            get
            {
                return _scrlMapViewV;
            }

            
            set
            {
                if (_scrlMapViewV != null)
                {
                }

                _scrlMapViewV = value;
                if (_scrlMapViewV != null)
                {
                }
            }
        }

        private Panel _pnlBack;

        internal Panel pnlBack
        {
            
            get
            {
                return _pnlBack;
            }

            
            set
            {
                if (_pnlBack != null)
                {
                }

                _pnlBack = value;
                if (_pnlBack != null)
                {
                }
            }
        }

        private PictureBox _picBackSelect;

        internal PictureBox picBackSelect
        {
            
            get
            {
                return _picBackSelect;
            }

            
            set
            {
                if (_picBackSelect != null)
                {
                }

                _picBackSelect = value;
                if (_picBackSelect != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkScrollBar _scrlPictureY;

        internal DarkUI.Controls.DarkScrollBar scrlPictureY
        {
            
            get
            {
                return _scrlPictureY;
            }

            
            set
            {
                if (_scrlPictureY != null)
                {
                }

                _scrlPictureY = value;
                if (_scrlPictureY != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkScrollBar _scrlPictureX;

        internal DarkUI.Controls.DarkScrollBar scrlPictureX
        {
            
            get
            {
                return _scrlPictureX;
            }

            
            set
            {
                if (_scrlPictureX != null)
                {
                }

                _scrlPictureX = value;
                if (_scrlPictureX != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel1;

        internal DarkUI.Controls.DarkLabel DarkLabel1
        {
            
            get
            {
                return _DarkLabel1;
            }

            
            set
            {
                if (_DarkLabel1 != null)
                {
                }

                _DarkLabel1 = value;
                if (_DarkLabel1 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel2;

        internal DarkUI.Controls.DarkLabel DarkLabel2
        {
            
            get
            {
                return _DarkLabel2;
            }

            
            set
            {
                if (_DarkLabel2 != null)
                {
                }

                _DarkLabel2 = value;
                if (_DarkLabel2 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel3;

        internal DarkUI.Controls.DarkLabel DarkLabel3
        {
            
            get
            {
                return _DarkLabel3;
            }

            
            set
            {
                if (_DarkLabel3 != null)
                {
                }

                _DarkLabel3 = value;
                if (_DarkLabel3 != null)
                {
                }
            }
        }

        private Panel _pnlTiles;

        internal Panel pnlTiles
        {
            
            get
            {
                return _pnlTiles;
            }

            
            set
            {
                if (_pnlTiles != null)
                {
                }

                _pnlTiles = value;
                if (_pnlTiles != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel4;

        internal DarkUI.Controls.DarkLabel DarkLabel4
        {
            
            get
            {
                return _DarkLabel4;
            }

            
            set
            {
                if (_DarkLabel4 != null)
                {
                }

                _DarkLabel4 = value;
                if (_DarkLabel4 != null)
                {
                }
            }
        }

        private Panel _pnlEvents;

        internal Panel pnlEvents
        {
            
            get
            {
                return _pnlEvents;
            }

            
            set
            {
                if (_pnlEvents != null)
                {
                }

                _pnlEvents = value;
                if (_pnlEvents != null)
                {
                }
            }
        }

        private Panel _pnlDirBlock;

        internal Panel pnlDirBlock
        {
            
            get
            {
                return _pnlDirBlock;
            }

            
            set
            {
                if (_pnlDirBlock != null)
                {
                }

                _pnlDirBlock = value;
                if (_pnlDirBlock != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel6;

        internal DarkUI.Controls.DarkLabel DarkLabel6
        {
            
            get
            {
                return _DarkLabel6;
            }

            
            set
            {
                if (_DarkLabel6 != null)
                {
                }

                _DarkLabel6 = value;
                if (_DarkLabel6 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel5;

        internal DarkUI.Controls.DarkLabel DarkLabel5
        {
            
            get
            {
                return _DarkLabel5;
            }

            
            set
            {
                if (_DarkLabel5 != null)
                {
                }

                _DarkLabel5 = value;
                if (_DarkLabel5 != null)
                {
                }
            }
        }

        private Panel _pnlNpc;

        internal Panel pnlNpc
        {
            
            get
            {
                return _pnlNpc;
            }

            
            set
            {
                if (_pnlNpc != null)
                {
                }

                _pnlNpc = value;
                if (_pnlNpc != null)
                {
                }
            }
        }

        private ListBox _lstMapNpc;

        internal ListBox lstMapNpc
        {
            
            get
            {
                return _lstMapNpc;
            }

            
            set
            {
                if (_lstMapNpc != null)
                {
                }

                _lstMapNpc = value;
                if (_lstMapNpc != null)
                {
                }
            }
        }

        private ComboBox _cmbNpcList;

        internal ComboBox cmbNpcList
        {
            
            get
            {
                return _cmbNpcList;
            }

            
            set
            {
                if (_cmbNpcList != null)
                {
                }

                _cmbNpcList = value;
                if (_cmbNpcList != null)
                {
                }
            }
        }

        private Panel _pnlAttribute;

        internal Panel pnlAttribute
        {
            
            get
            {
                return _pnlAttribute;
            }

            
            set
            {
                if (_pnlAttribute != null)
                {
                }

                _pnlAttribute = value;
                if (_pnlAttribute != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optBlocked;

        internal DarkUI.Controls.DarkRadioButton optBlocked
        {
            
            get
            {
                return _optBlocked;
            }

            
            set
            {
                if (_optBlocked != null)
                {
                }

                _optBlocked = value;
                if (_optBlocked != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optNpcAvoid;

        internal DarkUI.Controls.DarkRadioButton optNpcAvoid
        {
            
            get
            {
                return _optNpcAvoid;
            }

            
            set
            {
                if (_optNpcAvoid != null)
                {
                }

                _optNpcAvoid = value;
                if (_optNpcAvoid != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optItem;

        internal DarkUI.Controls.DarkRadioButton optItem
        {
            
            get
            {
                return _optItem;
            }

            
            set
            {
                if (_optItem != null)
                {
                }

                _optItem = value;
                if (_optItem != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optWarp;

        internal DarkUI.Controls.DarkRadioButton optWarp
        {
            
            get
            {
                return _optWarp;
            }

            
            set
            {
                if (_optWarp != null)
                {
                }

                _optWarp = value;
                if (_optWarp != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optHouse;

        internal DarkUI.Controls.DarkRadioButton optHouse
        {
            
            get
            {
                return _optHouse;
            }

            
            set
            {
                if (_optHouse != null)
                {
                }

                _optHouse = value;
                if (_optHouse != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optShop;

        internal DarkUI.Controls.DarkRadioButton optShop
        {
            
            get
            {
                return _optShop;
            }

            
            set
            {
                if (_optShop != null)
                {
                }

                _optShop = value;
                if (_optShop != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optNpcSpawn;

        internal DarkUI.Controls.DarkRadioButton optNpcSpawn
        {
            
            get
            {
                return _optNpcSpawn;
            }

            
            set
            {
                if (_optNpcSpawn != null)
                {
                }

                _optNpcSpawn = value;
                if (_optNpcSpawn != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optBank;

        internal DarkUI.Controls.DarkRadioButton optBank
        {
            
            get
            {
                return _optBank;
            }

            
            set
            {
                if (_optBank != null)
                {
                }

                _optBank = value;
                if (_optBank != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optCraft;

        internal DarkUI.Controls.DarkRadioButton optCraft
        {
            
            get
            {
                return _optCraft;
            }

            
            set
            {
                if (_optCraft != null)
                {
                }

                _optCraft = value;
                if (_optCraft != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optTrap;

        internal DarkUI.Controls.DarkRadioButton optTrap
        {
            
            get
            {
                return _optTrap;
            }

            
            set
            {
                if (_optTrap != null)
                {
                }

                _optTrap = value;
                if (_optTrap != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optHeal;

        internal DarkUI.Controls.DarkRadioButton optHeal
        {
            
            get
            {
                return _optHeal;
            }

            
            set
            {
                if (_optHeal != null)
                {
                }

                _optHeal = value;
                if (_optHeal != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optKeyOpen;

        internal DarkUI.Controls.DarkRadioButton optKeyOpen
        {
            
            get
            {
                return _optKeyOpen;
            }

            
            set
            {
                if (_optKeyOpen != null)
                {
                }

                _optKeyOpen = value;
                if (_optKeyOpen != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optKey;

        internal DarkUI.Controls.DarkRadioButton optKey
        {
            
            get
            {
                return _optKey;
            }

            
            set
            {
                if (_optKey != null)
                {
                }

                _optKey = value;
                if (_optKey != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optDoor;

        internal DarkUI.Controls.DarkRadioButton optDoor
        {
            
            get
            {
                return _optDoor;
            }

            
            set
            {
                if (_optDoor != null)
                {
                }

                _optDoor = value;
                if (_optDoor != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optResource;

        internal DarkUI.Controls.DarkRadioButton optResource
        {
            
            get
            {
                return _optResource;
            }

            
            set
            {
                if (_optResource != null)
                {
                }

                _optResource = value;
                if (_optResource != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _tslCurXY;

        internal ToolStripStatusLabel tslCurXY
        {
            
            get
            {
                return _tslCurXY;
            }

            
            set
            {
                if (_tslCurXY != null)
                {
                }

                _tslCurXY = value;
                if (_tslCurXY != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnClearAttribute;

        internal DarkUI.Controls.DarkButton btnClearAttribute
        {
            
            get
            {
                return _btnClearAttribute;
            }

            
            set
            {
                if (_btnClearAttribute != null)
                {
                }

                _btnClearAttribute = value;
                if (_btnClearAttribute != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel7;

        internal DarkUI.Controls.DarkLabel DarkLabel7
        {
            
            get
            {
                return _DarkLabel7;
            }

            
            set
            {
                if (_DarkLabel7 != null)
                {
                }

                _DarkLabel7 = value;
                if (_DarkLabel7 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkCheckBox _chkInstance;

        internal DarkUI.Controls.DarkCheckBox chkInstance
        {
            
            get
            {
                return _chkInstance;
            }

            
            set
            {
                if (_chkInstance != null)
                {
                }

                _chkInstance = value;
                if (_chkInstance != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkTextBox _txtName;

        internal DarkUI.Controls.DarkTextBox txtName
        {
            
            get
            {
                return _txtName;
            }

            
            set
            {
                if (_txtName != null)
                {
                }

                _txtName = value;
                if (_txtName != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel8;

        internal DarkUI.Controls.DarkLabel DarkLabel8
        {
            
            get
            {
                return _DarkLabel8;
            }

            
            set
            {
                if (_DarkLabel8 != null)
                {
                }

                _DarkLabel8 = value;
                if (_DarkLabel8 != null)
                {
                }
            }
        }

        private GroupBox _fraMapLinks;

        internal GroupBox fraMapLinks
        {
            
            get
            {
                return _fraMapLinks;
            }

            
            set
            {
                if (_fraMapLinks != null)
                {
                }

                _fraMapLinks = value;
                if (_fraMapLinks != null)
                {
                }
            }
        }

        private ComboBox _cmbMoral;

        internal ComboBox cmbMoral
        {
            
            get
            {
                return _cmbMoral;
            }

            
            set
            {
                if (_cmbMoral != null)
                {
                }

                _cmbMoral = value;
                if (_cmbMoral != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _lblMap;

        internal DarkUI.Controls.DarkLabel lblMap
        {
            
            get
            {
                return _lblMap;
            }

            
            set
            {
                if (_lblMap != null)
                {
                }

                _lblMap = value;
                if (_lblMap != null)
                {
                }
            }
        }

        private GroupBox _GroupBox1;

        internal GroupBox GroupBox1
        {
            
            get
            {
                return _GroupBox1;
            }

            
            set
            {
                if (_GroupBox1 != null)
                {
                }

                _GroupBox1 = value;
                if (_GroupBox1 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel9;

        internal DarkUI.Controls.DarkLabel DarkLabel9
        {
            
            get
            {
                return _DarkLabel9;
            }

            
            set
            {
                if (_DarkLabel9 != null)
                {
                }

                _DarkLabel9 = value;
                if (_DarkLabel9 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel11;

        internal DarkUI.Controls.DarkLabel DarkLabel11
        {
            
            get
            {
                return _DarkLabel11;
            }

            
            set
            {
                if (_DarkLabel11 != null)
                {
                }

                _DarkLabel11 = value;
                if (_DarkLabel11 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel10;

        internal DarkUI.Controls.DarkLabel DarkLabel10
        {
            
            get
            {
                return _DarkLabel10;
            }

            
            set
            {
                if (_DarkLabel10 != null)
                {
                }

                _DarkLabel10 = value;
                if (_DarkLabel10 != null)
                {
                }
            }
        }

        private GroupBox _GroupBox2;

        internal GroupBox GroupBox2
        {
            
            get
            {
                return _GroupBox2;
            }

            
            set
            {
                if (_GroupBox2 != null)
                {
                }

                _GroupBox2 = value;
                if (_GroupBox2 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel13;

        internal DarkUI.Controls.DarkLabel DarkLabel13
        {
            
            get
            {
                return _DarkLabel13;
            }

            
            set
            {
                if (_DarkLabel13 != null)
                {
                }

                _DarkLabel13 = value;
                if (_DarkLabel13 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel12;

        internal DarkUI.Controls.DarkLabel DarkLabel12
        {
            
            get
            {
                return _DarkLabel12;
            }

            
            set
            {
                if (_DarkLabel12 != null)
                {
                }

                _DarkLabel12 = value;
                if (_DarkLabel12 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnSetSize;

        internal DarkUI.Controls.DarkButton btnSetSize
        {
            
            get
            {
                return _btnSetSize;
            }

            
            set
            {
                if (_btnSetSize != null)
                {
                }

                _btnSetSize = value;
                if (_btnSetSize != null)
                {
                }
            }
        }

        private GroupBox _GroupBox3;

        internal GroupBox GroupBox3
        {
            
            get
            {
                return _GroupBox3;
            }

            
            set
            {
                if (_GroupBox3 != null)
                {
                }

                _GroupBox3 = value;
                if (_GroupBox3 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnPreview;

        internal DarkUI.Controls.DarkButton btnPreview
        {
            
            get
            {
                return _btnPreview;
            }

            
            set
            {
                if (_btnPreview != null)
                {
                }

                _btnPreview = value;
                if (_btnPreview != null)
                {
                }
            }
        }

        private ListBox _lstMusic;

        internal ListBox lstMusic
        {
            
            get
            {
                return _lstMusic;
            }

            
            set
            {
                if (_lstMusic != null)
                {
                }

                _lstMusic = value;
                if (_lstMusic != null)
                {
                }
            }
        }

        private Panel _pnlMoreOptions;

        internal Panel pnlMoreOptions
        {
            
            get
            {
                return _pnlMoreOptions;
            }

            
            set
            {
                if (_pnlMoreOptions != null)
                {
                }

                _pnlMoreOptions = value;
                if (_pnlMoreOptions != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnMoreOptions;

        internal DarkUI.Controls.DarkButton btnMoreOptions
        {
            
            get
            {
                return _btnMoreOptions;
            }

            
            set
            {
                if (_btnMoreOptions != null)
                {
                }

                _btnMoreOptions = value;
                if (_btnMoreOptions != null)
                {
                }
            }
        }

        private GroupBox _GroupBox4;

        internal GroupBox GroupBox4
        {
            
            get
            {
                return _GroupBox4;
            }

            
            set
            {
                if (_GroupBox4 != null)
                {
                }

                _GroupBox4 = value;
                if (_GroupBox4 != null)
                {
                }
            }
        }

        private ComboBox _cmbWeather;

        internal ComboBox cmbWeather
        {
            
            get
            {
                return _cmbWeather;
            }

            
            set
            {
                if (_cmbWeather != null)
                {
                }

                _cmbWeather = value;
                if (_cmbWeather != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel14;

        internal DarkUI.Controls.DarkLabel DarkLabel14
        {
            
            get
            {
                return _DarkLabel14;
            }

            
            set
            {
                if (_DarkLabel14 != null)
                {
                }

                _DarkLabel14 = value;
                if (_DarkLabel14 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _lblIntensity;

        internal DarkUI.Controls.DarkLabel lblIntensity
        {
            
            get
            {
                return _lblIntensity;
            }

            
            set
            {
                if (_lblIntensity != null)
                {
                }

                _lblIntensity = value;
                if (_lblIntensity != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _lblFogIndex;

        internal DarkUI.Controls.DarkLabel lblFogIndex
        {
            
            get
            {
                return _lblFogIndex;
            }

            
            set
            {
                if (_lblFogIndex != null)
                {
                }

                _lblFogIndex = value;
                if (_lblFogIndex != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _lblFogSpeed;

        internal DarkUI.Controls.DarkLabel lblFogSpeed
        {
            
            get
            {
                return _lblFogSpeed;
            }

            
            set
            {
                if (_lblFogSpeed != null)
                {
                }

                _lblFogSpeed = value;
                if (_lblFogSpeed != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _lblFogAlpha;

        internal DarkUI.Controls.DarkLabel lblFogAlpha
        {
            
            get
            {
                return _lblFogAlpha;
            }

            
            set
            {
                if (_lblFogAlpha != null)
                {
                }

                _lblFogAlpha = value;
                if (_lblFogAlpha != null)
                {
                }
            }
        }

        private GroupBox _GroupBox5;

        internal GroupBox GroupBox5
        {
            
            get
            {
                return _GroupBox5;
            }

            
            set
            {
                if (_GroupBox5 != null)
                {
                }

                _GroupBox5 = value;
                if (_GroupBox5 != null)
                {
                }
            }
        }

        private CheckBox _chkUseTint;

        internal CheckBox chkUseTint
        {
            
            get
            {
                return _chkUseTint;
            }

            
            set
            {
                if (_chkUseTint != null)
                {
                }

                _chkUseTint = value;
                if (_chkUseTint != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _lblMapAlpha;

        internal DarkUI.Controls.DarkLabel lblMapAlpha
        {
            
            get
            {
                return _lblMapAlpha;
            }

            
            set
            {
                if (_lblMapAlpha != null)
                {
                }

                _lblMapAlpha = value;
                if (_lblMapAlpha != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _lblMapBlue;

        internal DarkUI.Controls.DarkLabel lblMapBlue
        {
            
            get
            {
                return _lblMapBlue;
            }

            
            set
            {
                if (_lblMapBlue != null)
                {
                }

                _lblMapBlue = value;
                if (_lblMapBlue != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _lblMapGreen;

        internal DarkUI.Controls.DarkLabel lblMapGreen
        {
            
            get
            {
                return _lblMapGreen;
            }

            
            set
            {
                if (_lblMapGreen != null)
                {
                }

                _lblMapGreen = value;
                if (_lblMapGreen != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _lblMapRed;

        internal DarkUI.Controls.DarkLabel lblMapRed
        {
            
            get
            {
                return _lblMapRed;
            }

            
            set
            {
                if (_lblMapRed != null)
                {
                }

                _lblMapRed = value;
                if (_lblMapRed != null)
                {
                }
            }
        }

        private ToolStripStatusLabel _tsCurFps;

        internal ToolStripStatusLabel tsCurFps
        {
            
            get
            {
                return _tsCurFps;
            }

            
            set
            {
                if (_tsCurFps != null)
                {
                }

                _tsCurFps = value;
                if (_tsCurFps != null)
                {
                }
            }
        }

        private ToolStripSeparator _ToolStripSeparator4;

        internal ToolStripSeparator ToolStripSeparator4
        {
            
            get
            {
                return _ToolStripSeparator4;
            }

            
            set
            {
                if (_ToolStripSeparator4 != null)
                {
                }

                _ToolStripSeparator4 = value;
                if (_ToolStripSeparator4 != null)
                {
                }
            }
        }

        private ToolStripButton _tsbScreenShot;

        internal ToolStripButton tsbScreenShot
        {
            
            get
            {
                return _tsbScreenShot;
            }

            
            set
            {
                if (_tsbScreenShot != null)
                {
                }

                _tsbScreenShot = value;
                if (_tsbScreenShot != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkRadioButton _optLight;

        internal DarkUI.Controls.DarkRadioButton optLight
        {
            
            get
            {
                return _optLight;
            }

            
            set
            {
                if (_optLight != null)
                {
                }

                _optLight = value;
                if (_optLight != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkComboBox _cmbLayers;

        internal DarkUI.Controls.DarkComboBox cmbLayers
        {
            
            get
            {
                return _cmbLayers;
            }

            
            set
            {
                if (_cmbLayers != null)
                {
                }

                _cmbLayers = value;
                if (_cmbLayers != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkComboBox _cmbTileSets;

        internal DarkUI.Controls.DarkComboBox cmbTileSets
        {
            
            get
            {
                return _cmbTileSets;
            }

            
            set
            {
                if (_cmbTileSets != null)
                {
                }

                _cmbTileSets = value;
                if (_cmbTileSets != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkComboBox _cmbAutoTile;

        internal DarkUI.Controls.DarkComboBox cmbAutoTile
        {
            
            get
            {
                return _cmbAutoTile;
            }

            
            set
            {
                if (_cmbAutoTile != null)
                {
                }

                _cmbAutoTile = value;
                if (_cmbAutoTile != null)
                {
                }
            }
        }

        private Panel _pnlAttributes;

        internal Panel pnlAttributes
        {
            
            get
            {
                return _pnlAttributes;
            }

            
            set
            {
                if (_pnlAttributes != null)
                {
                }

                _pnlAttributes = value;
                if (_pnlAttributes != null)
                {
                }
            }
        }

        private GroupBox _fraMapWarp;

        internal GroupBox fraMapWarp
        {
            
            get
            {
                return _fraMapWarp;
            }

            
            set
            {
                if (_fraMapWarp != null)
                {
                }

                _fraMapWarp = value;
                if (_fraMapWarp != null)
                {
                }
            }
        }

        private Button _btnMapWarp;

        internal Button btnMapWarp
        {
            
            get
            {
                return _btnMapWarp;
            }

            
            set
            {
                if (_btnMapWarp != null)
                {
                }

                _btnMapWarp = value;
                if (_btnMapWarp != null)
                {
                }
            }
        }

        private HScrollBar _scrlMapWarpY;

        internal HScrollBar scrlMapWarpY
        {
            
            get
            {
                return _scrlMapWarpY;
            }

            
            set
            {
                if (_scrlMapWarpY != null)
                {
                }

                _scrlMapWarpY = value;
                if (_scrlMapWarpY != null)
                {
                }
            }
        }

        private HScrollBar _scrlMapWarpX;

        internal HScrollBar scrlMapWarpX
        {
            
            get
            {
                return _scrlMapWarpX;
            }

            
            set
            {
                if (_scrlMapWarpX != null)
                {
                }

                _scrlMapWarpX = value;
                if (_scrlMapWarpX != null)
                {
                }
            }
        }

        private HScrollBar _scrlMapWarpMap;

        internal HScrollBar scrlMapWarpMap
        {
            
            get
            {
                return _scrlMapWarpMap;
            }

            
            set
            {
                if (_scrlMapWarpMap != null)
                {
                }

                _scrlMapWarpMap = value;
                if (_scrlMapWarpMap != null)
                {
                }
            }
        }

        private Label _lblMapWarpY;

        internal Label lblMapWarpY
        {
            
            get
            {
                return _lblMapWarpY;
            }

            
            set
            {
                if (_lblMapWarpY != null)
                {
                }

                _lblMapWarpY = value;
                if (_lblMapWarpY != null)
                {
                }
            }
        }

        private Label _lblMapWarpX;

        internal Label lblMapWarpX
        {
            
            get
            {
                return _lblMapWarpX;
            }

            
            set
            {
                if (_lblMapWarpX != null)
                {
                }

                _lblMapWarpX = value;
                if (_lblMapWarpX != null)
                {
                }
            }
        }

        private Label _lblMapWarpMap;

        internal Label lblMapWarpMap
        {
            
            get
            {
                return _lblMapWarpMap;
            }

            
            set
            {
                if (_lblMapWarpMap != null)
                {
                }

                _lblMapWarpMap = value;
                if (_lblMapWarpMap != null)
                {
                }
            }
        }

        private GroupBox _fraBuyHouse;

        internal GroupBox fraBuyHouse
        {
            
            get
            {
                return _fraBuyHouse;
            }

            
            set
            {
                if (_fraBuyHouse != null)
                {
                }

                _fraBuyHouse = value;
                if (_fraBuyHouse != null)
                {
                }
            }
        }

        private Button _btnHouseTileOk;

        internal Button btnHouseTileOk
        {
            
            get
            {
                return _btnHouseTileOk;
            }

            
            set
            {
                if (_btnHouseTileOk != null)
                {
                }

                _btnHouseTileOk = value;
                if (_btnHouseTileOk != null)
                {
                }
            }
        }

        private HScrollBar _scrlBuyHouse;

        internal HScrollBar scrlBuyHouse
        {
            
            get
            {
                return _scrlBuyHouse;
            }

            
            set
            {
                if (_scrlBuyHouse != null)
                {
                }

                _scrlBuyHouse = value;
                if (_scrlBuyHouse != null)
                {
                }
            }
        }

        private Label _lblHouseName;

        internal Label lblHouseName
        {
            
            get
            {
                return _lblHouseName;
            }

            
            set
            {
                if (_lblHouseName != null)
                {
                }

                _lblHouseName = value;
                if (_lblHouseName != null)
                {
                }
            }
        }

        private GroupBox _fraKeyOpen;

        internal GroupBox fraKeyOpen
        {
            
            get
            {
                return _fraKeyOpen;
            }

            
            set
            {
                if (_fraKeyOpen != null)
                {
                }

                _fraKeyOpen = value;
                if (_fraKeyOpen != null)
                {
                }
            }
        }

        private HScrollBar _scrlKeyY;

        internal HScrollBar scrlKeyY
        {
            
            get
            {
                return _scrlKeyY;
            }

            
            set
            {
                if (_scrlKeyY != null)
                {
                }

                _scrlKeyY = value;
                if (_scrlKeyY != null)
                {
                }
            }
        }

        private Label _lblKeyY;

        internal Label lblKeyY
        {
            
            get
            {
                return _lblKeyY;
            }

            
            set
            {
                if (_lblKeyY != null)
                {
                }

                _lblKeyY = value;
                if (_lblKeyY != null)
                {
                }
            }
        }

        private Button _btnMapKeyOpen;

        internal Button btnMapKeyOpen
        {
            
            get
            {
                return _btnMapKeyOpen;
            }

            
            set
            {
                if (_btnMapKeyOpen != null)
                {
                }

                _btnMapKeyOpen = value;
                if (_btnMapKeyOpen != null)
                {
                }
            }
        }

        private HScrollBar _scrlKeyX;

        internal HScrollBar scrlKeyX
        {
            
            get
            {
                return _scrlKeyX;
            }

            
            set
            {
                if (_scrlKeyX != null)
                {
                }

                _scrlKeyX = value;
                if (_scrlKeyX != null)
                {
                }
            }
        }

        private Label _lblKeyX;

        internal Label lblKeyX
        {
            
            get
            {
                return _lblKeyX;
            }

            
            set
            {
                if (_lblKeyX != null)
                {
                }

                _lblKeyX = value;
                if (_lblKeyX != null)
                {
                }
            }
        }

        private GroupBox _fraMapKey;

        internal GroupBox fraMapKey
        {
            
            get
            {
                return _fraMapKey;
            }

            
            set
            {
                if (_fraMapKey != null)
                {
                }

                _fraMapKey = value;
                if (_fraMapKey != null)
                {
                }
            }
        }

        private CheckBox _chkMapKey;

        internal CheckBox chkMapKey
        {
            
            get
            {
                return _chkMapKey;
            }

            
            set
            {
                if (_chkMapKey != null)
                {
                }

                _chkMapKey = value;
                if (_chkMapKey != null)
                {
                }
            }
        }

        private PictureBox _picMapKey;

        internal PictureBox picMapKey
        {
            
            get
            {
                return _picMapKey;
            }

            
            set
            {
                if (_picMapKey != null)
                {
                }

                _picMapKey = value;
                if (_picMapKey != null)
                {
                }
            }
        }

        private Button _btnMapKey;

        internal Button btnMapKey
        {
            
            get
            {
                return _btnMapKey;
            }

            
            set
            {
                if (_btnMapKey != null)
                {
                }

                _btnMapKey = value;
                if (_btnMapKey != null)
                {
                }
            }
        }

        private HScrollBar _scrlMapKey;

        internal HScrollBar scrlMapKey
        {
            
            get
            {
                return _scrlMapKey;
            }

            
            set
            {
                if (_scrlMapKey != null)
                {
                }

                _scrlMapKey = value;
                if (_scrlMapKey != null)
                {
                }
            }
        }

        private Label _lblMapKey;

        internal Label lblMapKey
        {
            
            get
            {
                return _lblMapKey;
            }

            
            set
            {
                if (_lblMapKey != null)
                {
                }

                _lblMapKey = value;
                if (_lblMapKey != null)
                {
                }
            }
        }

        private GroupBox _fraNpcSpawn;

        internal GroupBox fraNpcSpawn
        {
            
            get
            {
                return _fraNpcSpawn;
            }

            
            set
            {
                if (_fraNpcSpawn != null)
                {
                }

                _fraNpcSpawn = value;
                if (_fraNpcSpawn != null)
                {
                }
            }
        }

        private ComboBox _lstNpc;

        internal ComboBox lstNpc
        {
            
            get
            {
                return _lstNpc;
            }

            
            set
            {
                if (_lstNpc != null)
                {
                }

                _lstNpc = value;
                if (_lstNpc != null)
                {
                }
            }
        }

        private Button _btnNpcSpawn;

        internal Button btnNpcSpawn
        {
            
            get
            {
                return _btnNpcSpawn;
            }

            
            set
            {
                if (_btnNpcSpawn != null)
                {
                }

                _btnNpcSpawn = value;
                if (_btnNpcSpawn != null)
                {
                }
            }
        }

        private HScrollBar _scrlNpcDir;

        internal HScrollBar scrlNpcDir
        {
            
            get
            {
                return _scrlNpcDir;
            }

            
            set
            {
                if (_scrlNpcDir != null)
                {
                }

                _scrlNpcDir = value;
                if (_scrlNpcDir != null)
                {
                }
            }
        }

        private Label _lblNpcDir;

        internal Label lblNpcDir
        {
            
            get
            {
                return _lblNpcDir;
            }

            
            set
            {
                if (_lblNpcDir != null)
                {
                }

                _lblNpcDir = value;
                if (_lblNpcDir != null)
                {
                }
            }
        }

        private GroupBox _fraHeal;

        internal GroupBox fraHeal
        {
            
            get
            {
                return _fraHeal;
            }

            
            set
            {
                if (_fraHeal != null)
                {
                }

                _fraHeal = value;
                if (_fraHeal != null)
                {
                }
            }
        }

        private HScrollBar _scrlHeal;

        internal HScrollBar scrlHeal
        {
            
            get
            {
                return _scrlHeal;
            }

            
            set
            {
                if (_scrlHeal != null)
                {
                }

                _scrlHeal = value;
                if (_scrlHeal != null)
                {
                }
            }
        }

        private Label _lblHeal;

        internal Label lblHeal
        {
            
            get
            {
                return _lblHeal;
            }

            
            set
            {
                if (_lblHeal != null)
                {
                }

                _lblHeal = value;
                if (_lblHeal != null)
                {
                }
            }
        }

        private ComboBox _cmbHeal;

        internal ComboBox cmbHeal
        {
            
            get
            {
                return _cmbHeal;
            }

            
            set
            {
                if (_cmbHeal != null)
                {
                }

                _cmbHeal = value;
                if (_cmbHeal != null)
                {
                }
            }
        }

        private Button _btnHeal;

        internal Button btnHeal
        {
            
            get
            {
                return _btnHeal;
            }

            
            set
            {
                if (_btnHeal != null)
                {
                }

                _btnHeal = value;
                if (_btnHeal != null)
                {
                }
            }
        }

        private GroupBox _fraShop;

        internal GroupBox fraShop
        {
            
            get
            {
                return _fraShop;
            }

            
            set
            {
                if (_fraShop != null)
                {
                }

                _fraShop = value;
                if (_fraShop != null)
                {
                }
            }
        }

        private ComboBox _cmbShop;

        internal ComboBox cmbShop
        {
            
            get
            {
                return _cmbShop;
            }

            
            set
            {
                if (_cmbShop != null)
                {
                }

                _cmbShop = value;
                if (_cmbShop != null)
                {
                }
            }
        }

        private Button _btnShop;

        internal Button btnShop
        {
            
            get
            {
                return _btnShop;
            }

            
            set
            {
                if (_btnShop != null)
                {
                }

                _btnShop = value;
                if (_btnShop != null)
                {
                }
            }
        }

        private GroupBox _fraResource;

        internal GroupBox fraResource
        {
            
            get
            {
                return _fraResource;
            }

            
            set
            {
                if (_fraResource != null)
                {
                }

                _fraResource = value;
                if (_fraResource != null)
                {
                }
            }
        }

        private Button _btnResourceOk;

        internal Button btnResourceOk
        {
            
            get
            {
                return _btnResourceOk;
            }

            
            set
            {
                if (_btnResourceOk != null)
                {
                }

                _btnResourceOk = value;
                if (_btnResourceOk != null)
                {
                }
            }
        }

        private HScrollBar _scrlResource;

        internal HScrollBar scrlResource
        {
            
            get
            {
                return _scrlResource;
            }

            
            set
            {
                if (_scrlResource != null)
                {
                }

                _scrlResource = value;
                if (_scrlResource != null)
                {
                }
            }
        }

        private Label _lblResource;

        internal Label lblResource
        {
            
            get
            {
                return _lblResource;
            }

            
            set
            {
                if (_lblResource != null)
                {
                }

                _lblResource = value;
                if (_lblResource != null)
                {
                }
            }
        }

        private GroupBox _fraMapItem;

        internal GroupBox fraMapItem
        {
            
            get
            {
                return _fraMapItem;
            }

            
            set
            {
                if (_fraMapItem != null)
                {
                }

                _fraMapItem = value;
                if (_fraMapItem != null)
                {
                }
            }
        }

        private PictureBox _picMapItem;

        internal PictureBox picMapItem
        {
            
            get
            {
                return _picMapItem;
            }

            
            set
            {
                if (_picMapItem != null)
                {
                }

                _picMapItem = value;
                if (_picMapItem != null)
                {
                }
            }
        }

        private Button _btnMapItem;

        internal Button btnMapItem
        {
            
            get
            {
                return _btnMapItem;
            }

            
            set
            {
                if (_btnMapItem != null)
                {
                }

                _btnMapItem = value;
                if (_btnMapItem != null)
                {
                }
            }
        }

        private HScrollBar _scrlMapItemValue;

        internal HScrollBar scrlMapItemValue
        {
            
            get
            {
                return _scrlMapItemValue;
            }

            
            set
            {
                if (_scrlMapItemValue != null)
                {
                }

                _scrlMapItemValue = value;
                if (_scrlMapItemValue != null)
                {
                }
            }
        }

        private HScrollBar _scrlMapItem;

        internal HScrollBar scrlMapItem
        {
            
            get
            {
                return _scrlMapItem;
            }

            
            set
            {
                if (_scrlMapItem != null)
                {
                }

                _scrlMapItem = value;
                if (_scrlMapItem != null)
                {
                }
            }
        }

        private Label _lblMapItem;

        internal Label lblMapItem
        {
            
            get
            {
                return _lblMapItem;
            }

            
            set
            {
                if (_lblMapItem != null)
                {
                }

                _lblMapItem = value;
                if (_lblMapItem != null)
                {
                }
            }
        }

        private GroupBox _fraTrap;

        internal GroupBox fraTrap
        {
            
            get
            {
                return _fraTrap;
            }

            
            set
            {
                if (_fraTrap != null)
                {
                }

                _fraTrap = value;
                if (_fraTrap != null)
                {
                }
            }
        }

        private Button _btnTrap;

        internal Button btnTrap
        {
            
            get
            {
                return _btnTrap;
            }

            
            set
            {
                if (_btnTrap != null)
                {
                }

                _btnTrap = value;
                if (_btnTrap != null)
                {
                }
            }
        }

        private HScrollBar _scrlTrap;

        internal HScrollBar scrlTrap
        {
            
            get
            {
                return _scrlTrap;
            }

            
            set
            {
                if (_scrlTrap != null)
                {
                }

                _scrlTrap = value;
                if (_scrlTrap != null)
                {
                }
            }
        }

        private Label _lblTrap;

        internal Label lblTrap
        {
            
            get
            {
                return _lblTrap;
            }

            
            set
            {
                if (_lblTrap != null)
                {
                }

                _lblTrap = value;
                if (_lblTrap != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudRight;

        internal DarkUI.Controls.DarkNumericUpDown nudRight
        {
            
            get
            {
                return _nudRight;
            }

            
            set
            {
                if (_nudRight != null)
                {
                }

                _nudRight = value;
                if (_nudRight != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudLeft;

        internal DarkUI.Controls.DarkNumericUpDown nudLeft
        {
            
            get
            {
                return _nudLeft;
            }

            
            set
            {
                if (_nudLeft != null)
                {
                }

                _nudLeft = value;
                if (_nudLeft != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudDown;

        internal DarkUI.Controls.DarkNumericUpDown nudDown
        {
            
            get
            {
                return _nudDown;
            }

            
            set
            {
                if (_nudDown != null)
                {
                }

                _nudDown = value;
                if (_nudDown != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudUp;

        internal DarkUI.Controls.DarkNumericUpDown nudUp
        {
            
            get
            {
                return _nudUp;
            }

            
            set
            {
                if (_nudUp != null)
                {
                }

                _nudUp = value;
                if (_nudUp != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudMaxY;

        internal DarkUI.Controls.DarkNumericUpDown nudMaxY
        {
            
            get
            {
                return _nudMaxY;
            }

            
            set
            {
                if (_nudMaxY != null)
                {
                }

                _nudMaxY = value;
                if (_nudMaxY != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudMaxX;

        internal DarkUI.Controls.DarkNumericUpDown nudMaxX
        {
            
            get
            {
                return _nudMaxX;
            }

            
            set
            {
                if (_nudMaxX != null)
                {
                }

                _nudMaxX = value;
                if (_nudMaxX != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudSpawnY;

        internal DarkUI.Controls.DarkNumericUpDown nudSpawnY
        {
            
            get
            {
                return _nudSpawnY;
            }

            
            set
            {
                if (_nudSpawnY != null)
                {
                }

                _nudSpawnY = value;
                if (_nudSpawnY != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudSpawnX;

        internal DarkUI.Controls.DarkNumericUpDown nudSpawnX
        {
            
            get
            {
                return _nudSpawnX;
            }

            
            set
            {
                if (_nudSpawnX != null)
                {
                }

                _nudSpawnX = value;
                if (_nudSpawnX != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudSpawnMap;

        internal DarkUI.Controls.DarkNumericUpDown nudSpawnMap
        {
            
            get
            {
                return _nudSpawnMap;
            }

            
            set
            {
                if (_nudSpawnMap != null)
                {
                }

                _nudSpawnMap = value;
                if (_nudSpawnMap != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudMapAlpha;

        internal DarkUI.Controls.DarkNumericUpDown nudMapAlpha
        {
            
            get
            {
                return _nudMapAlpha;
            }

            
            set
            {
                if (_nudMapAlpha != null)
                {
                }

                _nudMapAlpha = value;
                if (_nudMapAlpha != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudMapBlue;

        internal DarkUI.Controls.DarkNumericUpDown nudMapBlue
        {
            
            get
            {
                return _nudMapBlue;
            }

            
            set
            {
                if (_nudMapBlue != null)
                {
                }

                _nudMapBlue = value;
                if (_nudMapBlue != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudMapGreen;

        internal DarkUI.Controls.DarkNumericUpDown nudMapGreen
        {
            
            get
            {
                return _nudMapGreen;
            }

            
            set
            {
                if (_nudMapGreen != null)
                {
                }

                _nudMapGreen = value;
                if (_nudMapGreen != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudMapRed;

        internal DarkUI.Controls.DarkNumericUpDown nudMapRed
        {
            
            get
            {
                return _nudMapRed;
            }

            
            set
            {
                if (_nudMapRed != null)
                {
                }

                _nudMapRed = value;
                if (_nudMapRed != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudFogAlpha;

        internal DarkUI.Controls.DarkNumericUpDown nudFogAlpha
        {
            
            get
            {
                return _nudFogAlpha;
            }

            
            set
            {
                if (_nudFogAlpha != null)
                {
                }

                _nudFogAlpha = value;
                if (_nudFogAlpha != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudFogSpeed;

        internal DarkUI.Controls.DarkNumericUpDown nudFogSpeed
        {
            
            get
            {
                return _nudFogSpeed;
            }

            
            set
            {
                if (_nudFogSpeed != null)
                {
                }

                _nudFogSpeed = value;
                if (_nudFogSpeed != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudFog;

        internal DarkUI.Controls.DarkNumericUpDown nudFog
        {
            
            get
            {
                return _nudFog;
            }

            
            set
            {
                if (_nudFog != null)
                {
                }

                _nudFog = value;
                if (_nudFog != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudIntensity;

        internal DarkUI.Controls.DarkNumericUpDown nudIntensity
        {
            
            get
            {
                return _nudIntensity;
            }

            
            set
            {
                if (_nudIntensity != null)
                {
                }

                _nudIntensity = value;
                if (_nudIntensity != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _lblPasteMode;

        internal DarkUI.Controls.DarkLabel lblPasteMode
        {
            
            get
            {
                return _lblPasteMode;
            }

            
            set
            {
                if (_lblPasteMode != null)
                {
                }

                _lblPasteMode = value;
                if (_lblPasteMode != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnPasteEvent;

        internal DarkUI.Controls.DarkButton btnPasteEvent
        {
            
            get
            {
                return _btnPasteEvent;
            }

            
            set
            {
                if (_btnPasteEvent != null)
                {
                }

                _btnPasteEvent = value;
                if (_btnPasteEvent != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel16;

        internal DarkUI.Controls.DarkLabel DarkLabel16
        {
            
            get
            {
                return _DarkLabel16;
            }

            
            set
            {
                if (_DarkLabel16 != null)
                {
                }

                _DarkLabel16 = value;
                if (_DarkLabel16 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _lblCopyMode;

        internal DarkUI.Controls.DarkLabel lblCopyMode
        {
            
            get
            {
                return _lblCopyMode;
            }

            
            set
            {
                if (_lblCopyMode != null)
                {
                }

                _lblCopyMode = value;
                if (_lblCopyMode != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnCopyEvent;

        internal DarkUI.Controls.DarkButton btnCopyEvent
        {
            
            get
            {
                return _btnCopyEvent;
            }

            
            set
            {
                if (_btnCopyEvent != null)
                {
                }

                _btnCopyEvent = value;
                if (_btnCopyEvent != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel15;

        internal DarkUI.Controls.DarkLabel DarkLabel15
        {
            
            get
            {
                return _DarkLabel15;
            }

            
            set
            {
                if (_DarkLabel15 != null)
                {
                }

                _DarkLabel15 = value;
                if (_DarkLabel15 != null)
                {
                }
            }
        }

        private Label _lblVisualWarp;

        internal Label lblVisualWarp
        {
            
            get
            {
                return _lblVisualWarp;
            }

            
            set
            {
                if (_lblVisualWarp != null)
                {
                }

                _lblVisualWarp = value;
                if (_lblVisualWarp != null)
                {
                }
            }
        }
    }
}
