
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using Engine;

namespace Engine
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
		public partial class frmMapEditor : System.Windows.Forms.Form
		{
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
			protected override void Dispose(bool disposing)
			{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
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
            this.darkLabel17 = new DarkUI.Controls.DarkLabel();
            this.nudBrightness = new DarkUI.Controls.DarkNumericUpDown();
            this.lblBrightness = new DarkUI.Controls.DarkLabel();
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
            this.fraLight = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lightRadiusInput = new System.Windows.Forms.NumericUpDown();
            this.flickerCheckBox = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.picBackSelect)).BeginInit();
            this.pnlNpc.SuspendLayout();
            this.pnlDirBlock.SuspendLayout();
            this.pnlEvents.SuspendLayout();
            this.pnlAttribute.SuspendLayout();
            this.DarkSectionPanel2.SuspendLayout();
            this.pnlMoreOptions.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFogAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFogSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntensity)).BeginInit();
            this.GroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapAlpha)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapRed)).BeginInit();
            this.GroupBox3.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxX)).BeginInit();
            this.GroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnMap)).BeginInit();
            this.fraMapLinks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUp)).BeginInit();
            this.ToolStrip.SuspendLayout();
            this.pnlBack2.SuspendLayout();
            this.pnlAttributes.SuspendLayout();
            this.fraLight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightRadiusInput)).BeginInit();
            this.fraMapWarp.SuspendLayout();
            this.fraBuyHouse.SuspendLayout();
            this.fraKeyOpen.SuspendLayout();
            this.fraMapKey.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMapKey)).BeginInit();
            this.fraNpcSpawn.SuspendLayout();
            this.fraHeal.SuspendLayout();
            this.fraShop.SuspendLayout();
            this.fraResource.SuspendLayout();
            this.fraMapItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMapItem)).BeginInit();
            this.fraTrap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // DarkDockPanel1
            // 
            this.DarkDockPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
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
            this.ssInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ssInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ssInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ssInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslCurMap,
            this.tslCurXY,
            this.tsCurFps});
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
            this.pnlTiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
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
            this.cmbAutoTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbAutoTile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbAutoTile.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbAutoTile.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbAutoTile.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbAutoTile.ButtonIcon")));
            this.cmbAutoTile.DrawDropdownHoverOutline = false;
            this.cmbAutoTile.DrawFocusRectangle = false;
            this.cmbAutoTile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAutoTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutoTile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAutoTile.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbAutoTile.FormattingEnabled = true;
            this.cmbAutoTile.Items.AddRange(new object[] {
            "Normal",
            "AutoTile",
            "Fake",
            "Animated",
            "Cliff",
            "Waterfall"});
            this.cmbAutoTile.Location = new System.Drawing.Point(52, 512);
            this.cmbAutoTile.Name = "cmbAutoTile";
            this.cmbAutoTile.Size = new System.Drawing.Size(109, 21);
            this.cmbAutoTile.TabIndex = 22;
            this.cmbAutoTile.Text = "Normal";
            this.cmbAutoTile.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbAutoTile.SelectedIndexChanged += new System.EventHandler(this.CmbAutoTile_SelectedIndexChanged);
            // 
            // cmbTileSets
            // 
            this.cmbTileSets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbTileSets.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbTileSets.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbTileSets.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbTileSets.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbTileSets.ButtonIcon")));
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
            this.cmbTileSets.SelectedIndexChanged += new System.EventHandler(this.CmbTileSets_SelectedIndexChanged);
            // 
            // cmbLayers
            // 
            this.cmbLayers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbLayers.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbLayers.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbLayers.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbLayers.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbLayers.ButtonIcon")));
            this.cmbLayers.DrawDropdownHoverOutline = false;
            this.cmbLayers.DrawFocusRectangle = false;
            this.cmbLayers.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLayers.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbLayers.FormattingEnabled = true;
            this.cmbLayers.Items.AddRange(new object[] {
            "Ground",
            "Mask",
            "Mask2",
            "Fringe",
            "Fringe2"});
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
            this.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
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
            this.pnlBack.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlBack_Paint);
            // 
            // picBackSelect
            // 
            this.picBackSelect.BackColor = System.Drawing.Color.Black;
            this.picBackSelect.Location = new System.Drawing.Point(0, 0);
            this.picBackSelect.Name = "picBackSelect";
            this.picBackSelect.Size = new System.Drawing.Size(283, 451);
            this.picBackSelect.TabIndex = 1;
            this.picBackSelect.TabStop = false;
            this.picBackSelect.Paint += new System.Windows.Forms.PaintEventHandler(this.PicBackSelect_Paint);
            this.picBackSelect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicBackSelect_MouseDown);
            this.picBackSelect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicBackSelect_MouseMove);
            this.picBackSelect.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picBackSelect_MouseUp);
            // 
            // DarkLabel3
            // 
            this.DarkLabel3.AutoSize = true;
            this.DarkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
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
            this.scrlPictureY.ValueChanged += new System.EventHandler<DarkUI.Controls.ScrollValueEventArgs>(this.ScrlPictureY_Scroll);
            // 
            // scrlPictureX
            // 
            this.scrlPictureX.BackColor = System.Drawing.SystemColors.ControlDark;
            this.scrlPictureX.Location = new System.Drawing.Point(3, 451);
            this.scrlPictureX.Name = "scrlPictureX";
            this.scrlPictureX.ScrollOrientation = DarkUI.Controls.DarkScrollOrientation.Horizontal;
            this.scrlPictureX.Size = new System.Drawing.Size(283, 16);
            this.scrlPictureX.TabIndex = 11;
            this.scrlPictureX.ValueChanged += new System.EventHandler<DarkUI.Controls.ScrollValueEventArgs>(this.ScrlPictureX_Scroll);
            // 
            // DarkLabel2
            // 
            this.DarkLabel2.AutoSize = true;
            this.DarkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
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
            this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel1.Location = new System.Drawing.Point(57, 470);
            this.DarkLabel1.Name = "DarkLabel1";
            this.DarkLabel1.Size = new System.Drawing.Size(174, 13);
            this.DarkLabel1.TabIndex = 13;
            this.DarkLabel1.Text = "Drag Mouse to Select Multiple Tiles";
            // 
            // pnlNpc
            // 
            this.pnlNpc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.pnlNpc.Controls.Add(this.cmbNpcList);
            this.pnlNpc.Controls.Add(this.lstMapNpc);
            this.pnlNpc.Location = new System.Drawing.Point(2, 50);
            this.pnlNpc.Name = "pnlNpc";
            this.pnlNpc.Size = new System.Drawing.Size(314, 548);
            this.pnlNpc.TabIndex = 8;
            // 
            // cmbNpcList
            // 
            this.cmbNpcList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.cmbNpcList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNpcList.ForeColor = System.Drawing.Color.LightGray;
            this.cmbNpcList.FormattingEnabled = true;
            this.cmbNpcList.Location = new System.Drawing.Point(126, 441);
            this.cmbNpcList.Name = "cmbNpcList";
            this.cmbNpcList.Size = new System.Drawing.Size(184, 21);
            this.cmbNpcList.TabIndex = 18;
            this.cmbNpcList.SelectedIndexChanged += new System.EventHandler(this.CmbNpcList_SelectedIndexChanged);
            // 
            // lstMapNpc
            // 
            this.lstMapNpc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstMapNpc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstMapNpc.ForeColor = System.Drawing.Color.LightGray;
            this.lstMapNpc.FormattingEnabled = true;
            this.lstMapNpc.Location = new System.Drawing.Point(3, 4);
            this.lstMapNpc.Name = "lstMapNpc";
            this.lstMapNpc.Size = new System.Drawing.Size(307, 431);
            this.lstMapNpc.TabIndex = 0;
            this.lstMapNpc.SelectedIndexChanged += new System.EventHandler(this.LstMapNpc_SelectedIndexChanged);
            // 
            // pnlDirBlock
            // 
            this.pnlDirBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.pnlDirBlock.Controls.Add(this.DarkLabel6);
            this.pnlDirBlock.Location = new System.Drawing.Point(2, 51);
            this.pnlDirBlock.Name = "pnlDirBlock";
            this.pnlDirBlock.Size = new System.Drawing.Size(314, 548);
            this.pnlDirBlock.TabIndex = 7;
            // 
            // DarkLabel6
            // 
            this.DarkLabel6.AutoSize = true;
            this.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel6.Location = new System.Drawing.Point(8, 8);
            this.DarkLabel6.Name = "DarkLabel6";
            this.DarkLabel6.Size = new System.Drawing.Size(239, 13);
            this.DarkLabel6.TabIndex = 0;
            this.DarkLabel6.Text = "Just press the arrows to block that side of the tile.";
            // 
            // btnEvents
            // 
            this.btnEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btnEvents.Location = new System.Drawing.Point(264, 28);
            this.btnEvents.Name = "btnEvents";
            this.btnEvents.Padding = new System.Windows.Forms.Padding(5);
            this.btnEvents.Size = new System.Drawing.Size(52, 23);
            this.btnEvents.TabIndex = 4;
            this.btnEvents.Text = "Events";
            this.btnEvents.Click += new System.EventHandler(this.BtnEvents_Click);
            // 
            // btnDirBlock
            // 
            this.btnDirBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btnDirBlock.Location = new System.Drawing.Point(163, 28);
            this.btnDirBlock.Name = "btnDirBlock";
            this.btnDirBlock.Padding = new System.Windows.Forms.Padding(5);
            this.btnDirBlock.Size = new System.Drawing.Size(100, 23);
            this.btnDirBlock.TabIndex = 3;
            this.btnDirBlock.Text = "Directional Block";
            this.btnDirBlock.Click += new System.EventHandler(this.BtnDirBlock_Click);
            // 
            // btnNpc
            // 
            this.btnNpc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btnNpc.Location = new System.Drawing.Point(118, 28);
            this.btnNpc.Name = "btnNpc";
            this.btnNpc.Padding = new System.Windows.Forms.Padding(5);
            this.btnNpc.Size = new System.Drawing.Size(44, 23);
            this.btnNpc.TabIndex = 2;
            this.btnNpc.Text = "Npc\'s";
            this.btnNpc.Click += new System.EventHandler(this.BtnNpc_Click);
            // 
            // btnAttributes
            // 
            this.btnAttributes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btnAttributes.Location = new System.Drawing.Point(49, 28);
            this.btnAttributes.Name = "btnAttributes";
            this.btnAttributes.Padding = new System.Windows.Forms.Padding(5);
            this.btnAttributes.Size = new System.Drawing.Size(68, 23);
            this.btnAttributes.TabIndex = 1;
            this.btnAttributes.Text = "Attributes";
            this.btnAttributes.Click += new System.EventHandler(this.BtnAttributes_Click);
            // 
            // btnTiles
            // 
            this.btnTiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btnTiles.Location = new System.Drawing.Point(4, 28);
            this.btnTiles.Name = "btnTiles";
            this.btnTiles.Padding = new System.Windows.Forms.Padding(5);
            this.btnTiles.Size = new System.Drawing.Size(44, 23);
            this.btnTiles.TabIndex = 0;
            this.btnTiles.Text = "Tiles";
            this.btnTiles.Click += new System.EventHandler(this.BtnTiles_Click);
            // 
            // pnlEvents
            // 
            this.pnlEvents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
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
            this.lblPasteMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
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
            this.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel16.Location = new System.Drawing.Point(8, 111);
            this.DarkLabel16.Name = "DarkLabel16";
            this.DarkLabel16.Size = new System.Drawing.Size(251, 44);
            this.DarkLabel16.TabIndex = 16;
            this.DarkLabel16.Text = "To paste a copied Event, press the paste button, then click on the map to place i" +
    "t.";
            // 
            // lblCopyMode
            // 
            this.lblCopyMode.AutoSize = true;
            this.lblCopyMode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
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
            this.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel15.Location = new System.Drawing.Point(8, 29);
            this.DarkLabel15.Name = "DarkLabel15";
            this.DarkLabel15.Size = new System.Drawing.Size(237, 30);
            this.DarkLabel15.TabIndex = 13;
            this.DarkLabel15.Text = "To copy a existing Event, press the copy button, then the event.";
            // 
            // DarkLabel5
            // 
            this.DarkLabel5.AutoSize = true;
            this.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel5.Location = new System.Drawing.Point(8, 8);
            this.DarkLabel5.Name = "DarkLabel5";
            this.DarkLabel5.Size = new System.Drawing.Size(233, 13);
            this.DarkLabel5.TabIndex = 0;
            this.DarkLabel5.Text = "Click on the map where you want to ad a event.";
            // 
            // pnlAttribute
            // 
            this.pnlAttribute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
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
            this.optLight.Click += new System.EventHandler(this.optLight_Click);
            // 
            // btnClearAttribute
            // 
            this.btnClearAttribute.Location = new System.Drawing.Point(10, 470);
            this.btnClearAttribute.Name = "btnClearAttribute";
            this.btnClearAttribute.Padding = new System.Windows.Forms.Padding(5);
            this.btnClearAttribute.Size = new System.Drawing.Size(297, 23);
            this.btnClearAttribute.TabIndex = 15;
            this.btnClearAttribute.Text = "Clear Attributes";
            this.btnClearAttribute.Click += new System.EventHandler(this.BtnClearAttribute_Click);
            // 
            // optHouse
            // 
            this.optHouse.AutoSize = true;
            this.optHouse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optHouse.Location = new System.Drawing.Point(163, 139);
            this.optHouse.Name = "optHouse";
            this.optHouse.Size = new System.Drawing.Size(56, 17);
            this.optHouse.TabIndex = 14;
            this.optHouse.Text = "House";
            this.optHouse.CheckedChanged += new System.EventHandler(this.OptHouse_CheckedChanged);
            // 
            // optShop
            // 
            this.optShop.AutoSize = true;
            this.optShop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optShop.Location = new System.Drawing.Point(97, 139);
            this.optShop.Name = "optShop";
            this.optShop.Size = new System.Drawing.Size(50, 17);
            this.optShop.TabIndex = 13;
            this.optShop.Text = "Shop";
            this.optShop.CheckedChanged += new System.EventHandler(this.OptShop_CheckedChanged);
            // 
            // optNpcSpawn
            // 
            this.optNpcSpawn.AutoSize = true;
            this.optNpcSpawn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optNpcSpawn.Location = new System.Drawing.Point(10, 139);
            this.optNpcSpawn.Name = "optNpcSpawn";
            this.optNpcSpawn.Size = new System.Drawing.Size(81, 17);
            this.optNpcSpawn.TabIndex = 12;
            this.optNpcSpawn.Text = "Npc Spawn";
            this.optNpcSpawn.CheckedChanged += new System.EventHandler(this.OptNPCSpawn_CheckedChanged);
            // 
            // optBank
            // 
            this.optBank.AutoSize = true;
            this.optBank.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optBank.Location = new System.Drawing.Point(235, 94);
            this.optBank.Name = "optBank";
            this.optBank.Size = new System.Drawing.Size(50, 17);
            this.optBank.TabIndex = 11;
            this.optBank.Text = "Bank";
            // 
            // optCraft
            // 
            this.optCraft.AutoSize = true;
            this.optCraft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optCraft.Location = new System.Drawing.Point(163, 94);
            this.optCraft.Name = "optCraft";
            this.optCraft.Size = new System.Drawing.Size(47, 17);
            this.optCraft.TabIndex = 10;
            this.optCraft.Text = "Craft";
            // 
            // optTrap
            // 
            this.optTrap.AutoSize = true;
            this.optTrap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optTrap.Location = new System.Drawing.Point(97, 94);
            this.optTrap.Name = "optTrap";
            this.optTrap.Size = new System.Drawing.Size(47, 17);
            this.optTrap.TabIndex = 9;
            this.optTrap.Text = "Trap";
            this.optTrap.CheckedChanged += new System.EventHandler(this.OptTrap_CheckedChanged);
            // 
            // optHeal
            // 
            this.optHeal.AutoSize = true;
            this.optHeal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optHeal.Location = new System.Drawing.Point(10, 94);
            this.optHeal.Name = "optHeal";
            this.optHeal.Size = new System.Drawing.Size(47, 17);
            this.optHeal.TabIndex = 8;
            this.optHeal.Text = "Heal";
            this.optHeal.CheckedChanged += new System.EventHandler(this.OptHeal_CheckedChanged);
            // 
            // optKeyOpen
            // 
            this.optKeyOpen.AutoSize = true;
            this.optKeyOpen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optKeyOpen.Location = new System.Drawing.Point(235, 50);
            this.optKeyOpen.Name = "optKeyOpen";
            this.optKeyOpen.Size = new System.Drawing.Size(72, 17);
            this.optKeyOpen.TabIndex = 7;
            this.optKeyOpen.Text = "Key Open";
            this.optKeyOpen.CheckedChanged += new System.EventHandler(this.OptKeyOpen_CheckedChanged);
            // 
            // optKey
            // 
            this.optKey.AutoSize = true;
            this.optKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optKey.Location = new System.Drawing.Point(163, 50);
            this.optKey.Name = "optKey";
            this.optKey.Size = new System.Drawing.Size(43, 17);
            this.optKey.TabIndex = 6;
            this.optKey.Text = "Key";
            this.optKey.CheckedChanged += new System.EventHandler(this.OptKey_CheckedChanged);
            // 
            // optDoor
            // 
            this.optDoor.AutoSize = true;
            this.optDoor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optDoor.Location = new System.Drawing.Point(97, 50);
            this.optDoor.Name = "optDoor";
            this.optDoor.Size = new System.Drawing.Size(48, 17);
            this.optDoor.TabIndex = 5;
            this.optDoor.Text = "Door";
            this.optDoor.CheckedChanged += new System.EventHandler(this.OptDoor_CheckedChanged);
            // 
            // optResource
            // 
            this.optResource.AutoSize = true;
            this.optResource.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optResource.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optResource.Location = new System.Drawing.Point(10, 50);
            this.optResource.Name = "optResource";
            this.optResource.Size = new System.Drawing.Size(71, 17);
            this.optResource.TabIndex = 4;
            this.optResource.Text = "Resource";
            this.optResource.CheckedChanged += new System.EventHandler(this.OptResource_CheckedChanged);
            // 
            // optNpcAvoid
            // 
            this.optNpcAvoid.AutoSize = true;
            this.optNpcAvoid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optNpcAvoid.Location = new System.Drawing.Point(235, 7);
            this.optNpcAvoid.Name = "optNpcAvoid";
            this.optNpcAvoid.Size = new System.Drawing.Size(75, 17);
            this.optNpcAvoid.TabIndex = 3;
            this.optNpcAvoid.Text = "Npc Avoid";
            // 
            // optItem
            // 
            this.optItem.AutoSize = true;
            this.optItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optItem.Location = new System.Drawing.Point(163, 7);
            this.optItem.Name = "optItem";
            this.optItem.Size = new System.Drawing.Size(66, 17);
            this.optItem.TabIndex = 2;
            this.optItem.Text = "MapItem";
            this.optItem.CheckedChanged += new System.EventHandler(this.OptItem_CheckedChanged);
            // 
            // optWarp
            // 
            this.optWarp.AutoSize = true;
            this.optWarp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optWarp.Location = new System.Drawing.Point(97, 7);
            this.optWarp.Name = "optWarp";
            this.optWarp.Size = new System.Drawing.Size(51, 17);
            this.optWarp.TabIndex = 1;
            this.optWarp.Text = "Warp";
            this.optWarp.CheckedChanged += new System.EventHandler(this.OptWarp_CheckedChanged);
            // 
            // optBlocked
            // 
            this.optBlocked.AutoSize = true;
            this.optBlocked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.optBlocked.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optBlocked.Location = new System.Drawing.Point(10, 7);
            this.optBlocked.Name = "optBlocked";
            this.optBlocked.Size = new System.Drawing.Size(64, 17);
            this.optBlocked.TabIndex = 0;
            this.optBlocked.Text = "Blocked";
            this.optBlocked.CheckedChanged += new System.EventHandler(this.OptBlocked_CheckedChanged);
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
            this.pnlMoreOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.pnlMoreOptions.Controls.Add(this.GroupBox4);
            this.pnlMoreOptions.Location = new System.Drawing.Point(4, 26);
            this.pnlMoreOptions.Name = "pnlMoreOptions";
            this.pnlMoreOptions.Size = new System.Drawing.Size(208, 539);
            this.pnlMoreOptions.TabIndex = 31;
            this.pnlMoreOptions.Visible = false;
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.darkLabel17);
            this.GroupBox4.Controls.Add(this.nudBrightness);
            this.GroupBox4.Controls.Add(this.lblBrightness);
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
            this.GroupBox4.Size = new System.Drawing.Size(200, 146);
            this.GroupBox4.TabIndex = 0;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Weather and Lighting Options";
            // 
            // darkLabel17
            // 
            this.darkLabel17.AutoSize = true;
            this.darkLabel17.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.darkLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel17.Location = new System.Drawing.Point(18, 107);
            this.darkLabel17.Name = "darkLabel17";
            this.darkLabel17.Size = new System.Drawing.Size(168, 9);
            this.darkLabel17.TabIndex = 32;
            this.darkLabel17.Text = "A value above 0 overwrites the Day/Night cycles";
            // 
            // nudBrightness
            // 
            this.nudBrightness.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudBrightness.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudBrightness.Location = new System.Drawing.Point(91, 118);
            this.nudBrightness.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudBrightness.Name = "nudBrightness";
            this.nudBrightness.Size = new System.Drawing.Size(103, 20);
            this.nudBrightness.TabIndex = 31;
            this.nudBrightness.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudBrightness.ValueChanged += new System.EventHandler(this.ScrlBrightness_Scroll);
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblBrightness.Location = new System.Drawing.Point(7, 120);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(59, 13);
            this.lblBrightness.TabIndex = 30;
            this.lblBrightness.Text = "Brightness:";
            // 
            // nudFogAlpha
            // 
            this.nudFogAlpha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudFogAlpha.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudFogAlpha.Location = new System.Drawing.Point(145, 69);
            this.nudFogAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudFogAlpha.Name = "nudFogAlpha";
            this.nudFogAlpha.Size = new System.Drawing.Size(49, 20);
            this.nudFogAlpha.TabIndex = 29;
            this.nudFogAlpha.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudFogAlpha.ValueChanged += new System.EventHandler(this.ScrlFogAlpha_Scroll);
            // 
            // nudFogSpeed
            // 
            this.nudFogSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudFogSpeed.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudFogSpeed.Location = new System.Drawing.Point(61, 69);
            this.nudFogSpeed.Name = "nudFogSpeed";
            this.nudFogSpeed.Size = new System.Drawing.Size(44, 20);
            this.nudFogSpeed.TabIndex = 28;
            this.nudFogSpeed.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudFogSpeed.ValueChanged += new System.EventHandler(this.ScrlFogSpeed_Scroll);
            // 
            // nudFog
            // 
            this.nudFog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudFog.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudFog.Location = new System.Drawing.Point(145, 44);
            this.nudFog.Name = "nudFog";
            this.nudFog.Size = new System.Drawing.Size(49, 20);
            this.nudFog.TabIndex = 28;
            this.nudFog.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudFog.ValueChanged += new System.EventHandler(this.ScrlFog_Scroll);
            // 
            // nudIntensity
            // 
            this.nudIntensity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudIntensity.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudIntensity.Location = new System.Drawing.Point(61, 44);
            this.nudIntensity.Name = "nudIntensity";
            this.nudIntensity.Size = new System.Drawing.Size(44, 20);
            this.nudIntensity.TabIndex = 28;
            this.nudIntensity.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudIntensity.ValueChanged += new System.EventHandler(this.ScrlIntensity_Scroll);
            // 
            // lblFogAlpha
            // 
            this.lblFogAlpha.AutoSize = true;
            this.lblFogAlpha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblFogAlpha.Location = new System.Drawing.Point(111, 72);
            this.lblFogAlpha.Name = "lblFogAlpha";
            this.lblFogAlpha.Size = new System.Drawing.Size(37, 13);
            this.lblFogAlpha.TabIndex = 23;
            this.lblFogAlpha.Text = "Alpha:";
            // 
            // lblFogSpeed
            // 
            this.lblFogSpeed.AutoSize = true;
            this.lblFogSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblFogSpeed.Location = new System.Drawing.Point(6, 72);
            this.lblFogSpeed.Name = "lblFogSpeed";
            this.lblFogSpeed.Size = new System.Drawing.Size(41, 13);
            this.lblFogSpeed.TabIndex = 21;
            this.lblFogSpeed.Text = "Speed:";
            // 
            // lblFogIndex
            // 
            this.lblFogIndex.AutoSize = true;
            this.lblFogIndex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblFogIndex.Location = new System.Drawing.Point(111, 46);
            this.lblFogIndex.Name = "lblFogIndex";
            this.lblFogIndex.Size = new System.Drawing.Size(28, 13);
            this.lblFogIndex.TabIndex = 19;
            this.lblFogIndex.Text = "Fog:";
            // 
            // lblIntensity
            // 
            this.lblIntensity.AutoSize = true;
            this.lblIntensity.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblIntensity.Location = new System.Drawing.Point(6, 46);
            this.lblIntensity.Name = "lblIntensity";
            this.lblIntensity.Size = new System.Drawing.Size(49, 13);
            this.lblIntensity.TabIndex = 17;
            this.lblIntensity.Text = "Intensity:";
            // 
            // cmbWeather
            // 
            this.cmbWeather.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.cmbWeather.ForeColor = System.Drawing.Color.LightGray;
            this.cmbWeather.FormattingEnabled = true;
            this.cmbWeather.Items.AddRange(new object[] {
            "None",
            "Rain",
            "Snow",
            "Hail",
            "Sand Storm",
            "Storm",
            "Fog"});
            this.cmbWeather.Location = new System.Drawing.Point(91, 17);
            this.cmbWeather.Name = "cmbWeather";
            this.cmbWeather.Size = new System.Drawing.Size(103, 21);
            this.cmbWeather.TabIndex = 16;
            this.cmbWeather.SelectedIndexChanged += new System.EventHandler(this.CmbWeather_SelectedIndexChanged);
            // 
            // DarkLabel14
            // 
            this.DarkLabel14.AutoSize = true;
            this.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
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
            this.nudMapAlpha.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMapAlpha.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMapAlpha.Location = new System.Drawing.Point(139, 55);
            this.nudMapAlpha.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMapAlpha.Name = "nudMapAlpha";
            this.nudMapAlpha.Size = new System.Drawing.Size(47, 20);
            this.nudMapAlpha.TabIndex = 31;
            this.nudMapAlpha.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMapAlpha.ValueChanged += new System.EventHandler(this.ScrlMapAlpha_Scroll);
            // 
            // nudMapBlue
            // 
            this.nudMapBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMapBlue.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMapBlue.Location = new System.Drawing.Point(41, 55);
            this.nudMapBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMapBlue.Name = "nudMapBlue";
            this.nudMapBlue.Size = new System.Drawing.Size(47, 20);
            this.nudMapBlue.TabIndex = 30;
            this.nudMapBlue.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMapBlue.ValueChanged += new System.EventHandler(this.ScrlMapBlue_Scroll);
            // 
            // nudMapGreen
            // 
            this.nudMapGreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMapGreen.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMapGreen.Location = new System.Drawing.Point(139, 29);
            this.nudMapGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMapGreen.Name = "nudMapGreen";
            this.nudMapGreen.Size = new System.Drawing.Size(47, 20);
            this.nudMapGreen.TabIndex = 29;
            this.nudMapGreen.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMapGreen.ValueChanged += new System.EventHandler(this.ScrlMapGreen_Scroll);
            // 
            // nudMapRed
            // 
            this.nudMapRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMapRed.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMapRed.Location = new System.Drawing.Point(41, 29);
            this.nudMapRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudMapRed.Name = "nudMapRed";
            this.nudMapRed.Size = new System.Drawing.Size(47, 20);
            this.nudMapRed.TabIndex = 28;
            this.nudMapRed.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudMapRed.ValueChanged += new System.EventHandler(this.ScrlMapRed_Scroll);
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
            this.chkUseTint.CheckedChanged += new System.EventHandler(this.ChkUseTint_CheckedChanged);
            // 
            // lblMapAlpha
            // 
            this.lblMapAlpha.AutoSize = true;
            this.lblMapAlpha.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblMapAlpha.Location = new System.Drawing.Point(96, 57);
            this.lblMapAlpha.Name = "lblMapAlpha";
            this.lblMapAlpha.Size = new System.Drawing.Size(37, 13);
            this.lblMapAlpha.TabIndex = 23;
            this.lblMapAlpha.Text = "Alpha:";
            // 
            // lblMapBlue
            // 
            this.lblMapBlue.AutoSize = true;
            this.lblMapBlue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblMapBlue.Location = new System.Drawing.Point(4, 57);
            this.lblMapBlue.Name = "lblMapBlue";
            this.lblMapBlue.Size = new System.Drawing.Size(31, 13);
            this.lblMapBlue.TabIndex = 21;
            this.lblMapBlue.Text = "Blue:";
            // 
            // lblMapGreen
            // 
            this.lblMapGreen.AutoSize = true;
            this.lblMapGreen.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblMapGreen.Location = new System.Drawing.Point(94, 31);
            this.lblMapGreen.Name = "lblMapGreen";
            this.lblMapGreen.Size = new System.Drawing.Size(39, 13);
            this.lblMapGreen.TabIndex = 19;
            this.lblMapGreen.Text = "Green:";
            // 
            // lblMapRed
            // 
            this.lblMapRed.AutoSize = true;
            this.lblMapRed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblMapRed.Location = new System.Drawing.Point(5, 31);
            this.lblMapRed.Name = "lblMapRed";
            this.lblMapRed.Size = new System.Drawing.Size(30, 13);
            this.lblMapRed.TabIndex = 17;
            this.lblMapRed.Text = "Red:";
            // 
            // btnMoreOptions
            // 
            this.btnMoreOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btnMoreOptions.Location = new System.Drawing.Point(9, 571);
            this.btnMoreOptions.Name = "btnMoreOptions";
            this.btnMoreOptions.Padding = new System.Windows.Forms.Padding(5);
            this.btnMoreOptions.Size = new System.Drawing.Size(203, 23);
            this.btnMoreOptions.TabIndex = 30;
            this.btnMoreOptions.Text = "More Options";
            this.btnMoreOptions.Click += new System.EventHandler(this.BtnMoreOptions_Click);
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
            this.btnPreview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.Location = new System.Drawing.Point(9, 102);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Padding = new System.Windows.Forms.Padding(5);
            this.btnPreview.Size = new System.Drawing.Size(185, 23);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "Preview Music";
            this.btnPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPreview.UseMnemonic = false;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // lstMusic
            // 
            this.lstMusic.FormattingEnabled = true;
            this.lstMusic.Location = new System.Drawing.Point(6, 14);
            this.lstMusic.Name = "lstMusic";
            this.lstMusic.ScrollAlwaysVisible = true;
            this.lstMusic.Size = new System.Drawing.Size(191, 82);
            this.lstMusic.TabIndex = 4;
            this.lstMusic.SelectedIndexChanged += new System.EventHandler(this.LstMusic_SelectedIndexChanged);
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
            this.nudMaxY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMaxY.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMaxY.Location = new System.Drawing.Point(145, 14);
            this.nudMaxY.Name = "nudMaxY";
            this.nudMaxY.Size = new System.Drawing.Size(41, 20);
            this.nudMaxY.TabIndex = 6;
            this.nudMaxY.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // nudMaxX
            // 
            this.nudMaxX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudMaxX.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMaxX.Location = new System.Drawing.Point(52, 14);
            this.nudMaxX.Name = "nudMaxX";
            this.nudMaxX.Size = new System.Drawing.Size(41, 20);
            this.nudMaxX.TabIndex = 5;
            this.nudMaxX.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // btnSetSize
            // 
            this.btnSetSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.btnSetSize.Location = new System.Drawing.Point(64, 39);
            this.btnSetSize.Name = "btnSetSize";
            this.btnSetSize.Padding = new System.Windows.Forms.Padding(5);
            this.btnSetSize.Size = new System.Drawing.Size(75, 23);
            this.btnSetSize.TabIndex = 4;
            this.btnSetSize.Text = "Set Size";
            this.btnSetSize.Click += new System.EventHandler(this.BtnSetSize_Click);
            // 
            // DarkLabel13
            // 
            this.DarkLabel13.AutoSize = true;
            this.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel13.Location = new System.Drawing.Point(99, 16);
            this.DarkLabel13.Name = "DarkLabel13";
            this.DarkLabel13.Size = new System.Drawing.Size(40, 13);
            this.DarkLabel13.TabIndex = 1;
            this.DarkLabel13.Text = "Max Y:";
            // 
            // DarkLabel12
            // 
            this.DarkLabel12.AutoSize = true;
            this.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
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
            this.nudSpawnY.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpawnY.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpawnY.Location = new System.Drawing.Point(143, 44);
            this.nudSpawnY.Name = "nudSpawnY";
            this.nudSpawnY.Size = new System.Drawing.Size(51, 20);
            this.nudSpawnY.TabIndex = 29;
            this.nudSpawnY.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpawnY.ValueChanged += new System.EventHandler(this.TxtBootY_TextChanged);
            // 
            // nudSpawnX
            // 
            this.nudSpawnX.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpawnX.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpawnX.Location = new System.Drawing.Point(48, 44);
            this.nudSpawnX.Name = "nudSpawnX";
            this.nudSpawnX.Size = new System.Drawing.Size(51, 20);
            this.nudSpawnX.TabIndex = 28;
            this.nudSpawnX.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpawnX.ValueChanged += new System.EventHandler(this.TxtBootX_TextChanged);
            // 
            // nudSpawnMap
            // 
            this.nudSpawnMap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpawnMap.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpawnMap.Location = new System.Drawing.Point(108, 18);
            this.nudSpawnMap.Name = "nudSpawnMap";
            this.nudSpawnMap.Size = new System.Drawing.Size(86, 20);
            this.nudSpawnMap.TabIndex = 6;
            this.nudSpawnMap.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpawnMap.ValueChanged += new System.EventHandler(this.TxtBootMap_TextChanged);
            // 
            // DarkLabel11
            // 
            this.DarkLabel11.AutoSize = true;
            this.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel11.Location = new System.Drawing.Point(120, 46);
            this.DarkLabel11.Name = "DarkLabel11";
            this.DarkLabel11.Size = new System.Drawing.Size(17, 13);
            this.DarkLabel11.TabIndex = 2;
            this.DarkLabel11.Text = "Y:";
            // 
            // DarkLabel10
            // 
            this.DarkLabel10.AutoSize = true;
            this.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel10.Location = new System.Drawing.Point(7, 46);
            this.DarkLabel10.Name = "DarkLabel10";
            this.DarkLabel10.Size = new System.Drawing.Size(17, 13);
            this.DarkLabel10.TabIndex = 1;
            this.DarkLabel10.Text = "X:";
            // 
            // DarkLabel9
            // 
            this.DarkLabel9.AutoSize = true;
            this.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
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
            this.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel7.Location = new System.Drawing.Point(6, 33);
            this.DarkLabel7.Name = "DarkLabel7";
            this.DarkLabel7.Size = new System.Drawing.Size(38, 13);
            this.DarkLabel7.TabIndex = 21;
            this.DarkLabel7.Text = "Name:";
            // 
            // chkInstance
            // 
            this.chkInstance.AutoSize = true;
            this.chkInstance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.chkInstance.ForeColor = System.Drawing.Color.Gainsboro;
            this.chkInstance.Location = new System.Drawing.Point(9, 85);
            this.chkInstance.Name = "chkInstance";
            this.chkInstance.Size = new System.Drawing.Size(79, 17);
            this.chkInstance.TabIndex = 26;
            this.chkInstance.Text = "Instanced?";
            this.chkInstance.CheckedChanged += new System.EventHandler(this.ChkInstance_CheckedChanged);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtName.Location = new System.Drawing.Point(50, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(162, 20);
            this.txtName.TabIndex = 22;
            this.txtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            // 
            // DarkLabel8
            // 
            this.DarkLabel8.AutoSize = true;
            this.DarkLabel8.BackColor = System.Drawing.Color.Transparent;
            this.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
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
            this.nudRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudRight.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudRight.Location = new System.Drawing.Point(147, 34);
            this.nudRight.Name = "nudRight";
            this.nudRight.Size = new System.Drawing.Size(50, 20);
            this.nudRight.TabIndex = 8;
            this.nudRight.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRight.ValueChanged += new System.EventHandler(this.NudRight_ValueChanged);
            // 
            // nudLeft
            // 
            this.nudLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudLeft.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLeft.Location = new System.Drawing.Point(6, 34);
            this.nudLeft.Name = "nudLeft";
            this.nudLeft.Size = new System.Drawing.Size(50, 20);
            this.nudLeft.TabIndex = 7;
            this.nudLeft.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLeft.ValueChanged += new System.EventHandler(this.NudLeft_ValueChanged);
            // 
            // nudDown
            // 
            this.nudDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudDown.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDown.Location = new System.Drawing.Point(75, 54);
            this.nudDown.Name = "nudDown";
            this.nudDown.Size = new System.Drawing.Size(50, 20);
            this.nudDown.TabIndex = 6;
            this.nudDown.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDown.ValueChanged += new System.EventHandler(this.NudDown_ValueChanged);
            // 
            // nudUp
            // 
            this.nudUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudUp.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudUp.Location = new System.Drawing.Point(75, 11);
            this.nudUp.Name = "nudUp";
            this.nudUp.Size = new System.Drawing.Size(50, 20);
            this.nudUp.TabIndex = 5;
            this.nudUp.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudUp.ValueChanged += new System.EventHandler(this.NudUp_ValueChanged);
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblMap.Location = new System.Drawing.Point(72, 36);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(65, 13);
            this.lblMap.TabIndex = 4;
            this.lblMap.Text = "Curr. Map: 0";
            // 
            // cmbMoral
            // 
            this.cmbMoral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.cmbMoral.ForeColor = System.Drawing.Color.LightGray;
            this.cmbMoral.FormattingEnabled = true;
            this.cmbMoral.Items.AddRange(new object[] {
            "None",
            "Safe Zone",
            "Indoors"});
            this.cmbMoral.Location = new System.Drawing.Point(50, 57);
            this.cmbMoral.Name = "cmbMoral";
            this.cmbMoral.Size = new System.Drawing.Size(162, 21);
            this.cmbMoral.TabIndex = 24;
            this.cmbMoral.SelectedIndexChanged += new System.EventHandler(this.CmbMoral_SelectedIndexChanged);
            // 
            // ToolStrip
            // 
            this.ToolStrip.AutoSize = false;
            this.ToolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ToolStrip.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbDiscard,
            this.ToolStripSeparator1,
            this.tsbMapGrid,
            this.ToolStripSeparator2,
            this.tsbFill,
            this.tsbClear,
            this.ToolStripSeparator3,
            this.ToolStripLabel1,
            this.cmbMapList,
            this.ToolStripSeparator4,
            this.tsbScreenShot});
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
            this.tsbSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(78, 22);
            this.tsbSave.Text = "Save Map";
            this.tsbSave.Click += new System.EventHandler(this.TsbSave_Click);
            // 
            // tsbDiscard
            // 
            this.tsbDiscard.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tsbDiscard.Image = ((System.Drawing.Image)(resources.GetObject("tsbDiscard.Image")));
            this.tsbDiscard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDiscard.Name = "tsbDiscard";
            this.tsbDiscard.Size = new System.Drawing.Size(66, 22);
            this.tsbDiscard.Text = "Discard";
            this.tsbDiscard.Click += new System.EventHandler(this.TsbDiscard_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripSeparator1.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbMapGrid
            // 
            this.tsbMapGrid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tsbMapGrid.Image = ((System.Drawing.Image)(resources.GetObject("tsbMapGrid.Image")));
            this.tsbMapGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMapGrid.Name = "tsbMapGrid";
            this.tsbMapGrid.Size = new System.Drawing.Size(76, 22);
            this.tsbMapGrid.Text = "Map Grid";
            this.tsbMapGrid.Click += new System.EventHandler(this.TsbMapGrid_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripSeparator2.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbFill
            // 
            this.tsbFill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tsbFill.Image = ((System.Drawing.Image)(resources.GetObject("tsbFill.Image")));
            this.tsbFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFill.Name = "tsbFill";
            this.tsbFill.Size = new System.Drawing.Size(73, 22);
            this.tsbFill.Text = "Fill Layer";
            this.tsbFill.Click += new System.EventHandler(this.TsbFill_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(85, 22);
            this.tsbClear.Text = "Clear Layer";
            this.tsbClear.Click += new System.EventHandler(this.TsbClear_Click);
            // 
            // ToolStripSeparator3
            // 
            this.ToolStripSeparator3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripSeparator3.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolStripSeparator3.Name = "ToolStripSeparator3";
            this.ToolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // ToolStripLabel1
            // 
            this.ToolStripLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripLabel1.Name = "ToolStripLabel1";
            this.ToolStripLabel1.Size = new System.Drawing.Size(34, 22);
            this.ToolStripLabel1.Text = "Map:";
            // 
            // cmbMapList
            // 
            this.cmbMapList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.cmbMapList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.cmbMapList.Name = "cmbMapList";
            this.cmbMapList.Size = new System.Drawing.Size(121, 25);
            this.cmbMapList.SelectedIndexChanged += new System.EventHandler(this.CmbMapList_SelectedIndexChanged);
            // 
            // ToolStripSeparator4
            // 
            this.ToolStripSeparator4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ToolStripSeparator4.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.ToolStripSeparator4.Name = "ToolStripSeparator4";
            this.ToolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbScreenShot
            // 
            this.tsbScreenShot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.tsbScreenShot.Image = ((System.Drawing.Image)(resources.GetObject("tsbScreenShot.Image")));
            this.tsbScreenShot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbScreenShot.Name = "tsbScreenShot";
            this.tsbScreenShot.Size = new System.Drawing.Size(86, 22);
            this.tsbScreenShot.Text = "ScreenShot";
            this.tsbScreenShot.Click += new System.EventHandler(this.TsbScreenShot_Click);
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
            this.pnlBack2.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlBack2_Paint);
            // 
            // pnlAttributes
            // 
            this.pnlAttributes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.pnlAttributes.Controls.Add(this.fraLight);
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
            // fraLight
            // 
            this.fraLight.Controls.Add(this.checkBox1);
            this.fraLight.Controls.Add(this.lightRadiusInput);
            this.fraLight.Controls.Add(this.flickerCheckBox);
            this.fraLight.Controls.Add(this.button1);
            this.fraLight.Controls.Add(this.label1);
            this.fraLight.ForeColor = System.Drawing.Color.LightGray;
            this.fraLight.Location = new System.Drawing.Point(428, 299);
            this.fraLight.Name = "fraLight";
            this.fraLight.Size = new System.Drawing.Size(206, 164);
            this.fraLight.TabIndex = 21;
            this.fraLight.TabStop = false;
            this.fraLight.Text = "Light";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(9, 87);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(76, 17);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Shadows?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lightRadiusInput
            // 
            this.lightRadiusInput.Location = new System.Drawing.Point(10, 38);
            this.lightRadiusInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.lightRadiusInput.Name = "lightRadiusInput";
            this.lightRadiusInput.Size = new System.Drawing.Size(120, 20);
            this.lightRadiusInput.TabIndex = 9;
            this.lightRadiusInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // flickerCheckBox
            // 
            this.flickerCheckBox.AutoSize = true;
            this.flickerCheckBox.Checked = true;
            this.flickerCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.flickerCheckBox.Location = new System.Drawing.Point(9, 64);
            this.flickerCheckBox.Name = "flickerCheckBox";
            this.flickerCheckBox.Size = new System.Drawing.Size(63, 17);
            this.flickerCheckBox.TabIndex = 8;
            this.flickerCheckBox.Text = "Flicker?";
            this.flickerCheckBox.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(58, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Accept";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Radius";
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
            this.lblVisualWarp.Click += new System.EventHandler(this.LblVisualWarp_Click);
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
            this.btnMapWarp.Click += new System.EventHandler(this.BtnMapWarp_Click);
            // 
            // scrlMapWarpY
            // 
            this.scrlMapWarpY.Location = new System.Drawing.Point(58, 60);
            this.scrlMapWarpY.Name = "scrlMapWarpY";
            this.scrlMapWarpY.Size = new System.Drawing.Size(144, 18);
            this.scrlMapWarpY.TabIndex = 5;
            this.scrlMapWarpY.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlMapWarpY_Scroll);
            // 
            // scrlMapWarpX
            // 
            this.scrlMapWarpX.Location = new System.Drawing.Point(58, 38);
            this.scrlMapWarpX.Name = "scrlMapWarpX";
            this.scrlMapWarpX.Size = new System.Drawing.Size(144, 18);
            this.scrlMapWarpX.TabIndex = 4;
            this.scrlMapWarpX.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlMapWarpX_Scroll);
            // 
            // scrlMapWarpMap
            // 
            this.scrlMapWarpMap.Location = new System.Drawing.Point(58, 16);
            this.scrlMapWarpMap.Name = "scrlMapWarpMap";
            this.scrlMapWarpMap.Size = new System.Drawing.Size(144, 18);
            this.scrlMapWarpMap.TabIndex = 3;
            this.scrlMapWarpMap.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlMapWarpMap_Scroll);
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
            this.btnHouseTileOk.Click += new System.EventHandler(this.BtnHouseTileOk_Click);
            // 
            // scrlBuyHouse
            // 
            this.scrlBuyHouse.LargeChange = 1;
            this.scrlBuyHouse.Location = new System.Drawing.Point(9, 36);
            this.scrlBuyHouse.Name = "scrlBuyHouse";
            this.scrlBuyHouse.Size = new System.Drawing.Size(193, 18);
            this.scrlBuyHouse.TabIndex = 3;
            this.scrlBuyHouse.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlBuyHouse_Scroll);
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
            this.scrlKeyY.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlKeyY_Scroll);
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
            this.btnMapKeyOpen.Click += new System.EventHandler(this.BtnMapKeyOpen_Click);
            // 
            // scrlKeyX
            // 
            this.scrlKeyX.Location = new System.Drawing.Point(9, 37);
            this.scrlKeyX.Name = "scrlKeyX";
            this.scrlKeyX.Size = new System.Drawing.Size(160, 18);
            this.scrlKeyX.TabIndex = 3;
            this.scrlKeyX.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlKeyX_Scroll);
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
            this.btnMapKey.Click += new System.EventHandler(this.BtnMapKey_Click);
            // 
            // scrlMapKey
            // 
            this.scrlMapKey.Location = new System.Drawing.Point(9, 37);
            this.scrlMapKey.Name = "scrlMapKey";
            this.scrlMapKey.Size = new System.Drawing.Size(160, 18);
            this.scrlMapKey.TabIndex = 3;
            this.scrlMapKey.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlMapKey_Scroll);
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
            this.btnNpcSpawn.Click += new System.EventHandler(this.BtnNpcSpawn_Click);
            // 
            // scrlNpcDir
            // 
            this.scrlNpcDir.LargeChange = 1;
            this.scrlNpcDir.Location = new System.Drawing.Point(6, 64);
            this.scrlNpcDir.Maximum = 3;
            this.scrlNpcDir.Name = "scrlNpcDir";
            this.scrlNpcDir.Size = new System.Drawing.Size(193, 18);
            this.scrlNpcDir.TabIndex = 3;
            this.scrlNpcDir.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlNpcDir_Scroll);
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
            this.scrlHeal.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlHeal_Scroll);
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
            this.cmbHeal.Items.AddRange(new object[] {
            "Hp",
            "Mp"});
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
            this.btnHeal.Click += new System.EventHandler(this.BtnHeal_Click);
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
            this.btnShop.Click += new System.EventHandler(this.BtnShop_Click);
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
            this.btnResourceOk.Click += new System.EventHandler(this.BtnResourceOk_Click);
            // 
            // scrlResource
            // 
            this.scrlResource.Location = new System.Drawing.Point(9, 49);
            this.scrlResource.Name = "scrlResource";
            this.scrlResource.Size = new System.Drawing.Size(182, 18);
            this.scrlResource.TabIndex = 3;
            this.scrlResource.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlResource_Scroll);
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
            this.btnMapItem.Click += new System.EventHandler(this.BtnMapItem_Click);
            // 
            // scrlMapItemValue
            // 
            this.scrlMapItemValue.Location = new System.Drawing.Point(9, 53);
            this.scrlMapItemValue.Name = "scrlMapItemValue";
            this.scrlMapItemValue.Size = new System.Drawing.Size(149, 18);
            this.scrlMapItemValue.TabIndex = 4;
            this.scrlMapItemValue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlMapItemValue_Scroll);
            // 
            // scrlMapItem
            // 
            this.scrlMapItem.Location = new System.Drawing.Point(9, 31);
            this.scrlMapItem.Name = "scrlMapItem";
            this.scrlMapItem.Size = new System.Drawing.Size(149, 18);
            this.scrlMapItem.TabIndex = 3;
            this.scrlMapItem.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlMapItem_Scroll);
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
            this.btnTrap.Click += new System.EventHandler(this.BtnTrap_Click);
            // 
            // scrlTrap
            // 
            this.scrlTrap.Location = new System.Drawing.Point(11, 32);
            this.scrlTrap.Name = "scrlTrap";
            this.scrlTrap.Size = new System.Drawing.Size(191, 17);
            this.scrlTrap.TabIndex = 41;
            this.scrlTrap.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrlTrap_Scroll);
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
            this.scrlMapViewV.ValueChanged += new System.EventHandler<DarkUI.Controls.ScrollValueEventArgs>(this.ScrlMapViewV_Scroll);
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
            this.scrlMapViewH.ValueChanged += new System.EventHandler<DarkUI.Controls.ScrollValueEventArgs>(this.ScrlMapViewH_Scroll);
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
            this.picScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.Picscreen_Paint);
            this.picScreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picscreen_MouseDown);
            this.picScreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picscreen_MouseMove);
            this.picScreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Picscreen_MouseUp);
            // 
            // frmMapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 626);
            this.Controls.Add(this.pnlBack2);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.DarkSectionPanel2);
            this.Controls.Add(this.DarkSectionPanel1);
            this.Controls.Add(this.ToolStripContainer2);
            this.Controls.Add(this.DarkDockPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMapEditor";
            this.Text = "Map Editor";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmEditor_MapEditor_Closing);
            this.Closed += new System.EventHandler(this.FrmEditor_MapEditor_Closed);
            this.Load += new System.EventHandler(this.FrmEditor_MapEditor_Load);
            this.Shown += new System.EventHandler(this.FrmEditor_Map_Load);
            this.Resize += new System.EventHandler(this.FrmEditor_MapEditor_Resize);
            this.ToolStripContainer2.ContentPanel.ResumeLayout(false);
            this.ToolStripContainer2.ResumeLayout(false);
            this.ToolStripContainer2.PerformLayout();
            this.ssInfo.ResumeLayout(false);
            this.ssInfo.PerformLayout();
            this.DarkSectionPanel1.ResumeLayout(false);
            this.pnlTiles.ResumeLayout(false);
            this.pnlTiles.PerformLayout();
            this.pnlBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBackSelect)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.nudBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFogAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFogSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudFog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntensity)).EndInit();
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapAlpha)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMapRed)).EndInit();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxX)).EndInit();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnMap)).EndInit();
            this.fraMapLinks.ResumeLayout(false);
            this.fraMapLinks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudUp)).EndInit();
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.pnlBack2.ResumeLayout(false);
            this.pnlAttributes.ResumeLayout(false);
            this.fraLight.ResumeLayout(false);
            this.fraLight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lightRadiusInput)).EndInit();
            this.fraMapWarp.ResumeLayout(false);
            this.fraMapWarp.PerformLayout();
            this.fraBuyHouse.ResumeLayout(false);
            this.fraBuyHouse.PerformLayout();
            this.fraKeyOpen.ResumeLayout(false);
            this.fraKeyOpen.PerformLayout();
            this.fraMapKey.ResumeLayout(false);
            this.fraMapKey.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMapKey)).EndInit();
            this.fraNpcSpawn.ResumeLayout(false);
            this.fraNpcSpawn.PerformLayout();
            this.fraHeal.ResumeLayout(false);
            this.fraHeal.PerformLayout();
            this.fraShop.ResumeLayout(false);
            this.fraResource.ResumeLayout(false);
            this.fraResource.PerformLayout();
            this.fraMapItem.ResumeLayout(false);
            this.fraMapItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMapItem)).EndInit();
            this.fraTrap.ResumeLayout(false);
            this.fraTrap.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picScreen)).EndInit();
            this.ResumeLayout(false);

		}
		
		internal DarkUI.Docking.DarkDockPanel DarkDockPanel1;
		internal ToolStripContainer ToolStripContainer2;
		internal DarkUI.Controls.DarkSectionPanel DarkSectionPanel1;
		internal DarkUI.Controls.DarkSectionPanel DarkSectionPanel2;
		internal DarkUI.Controls.DarkToolStrip ToolStrip;
		internal ToolStripButton tsbSave;
		internal ToolStripButton tsbDiscard;
		internal ToolStripSeparator ToolStripSeparator1;
		internal ToolStripButton tsbMapGrid;
		internal ToolStripSeparator ToolStripSeparator2;
		internal ToolStripButton tsbFill;
		internal ToolStripButton tsbClear;
		internal ToolStripSeparator ToolStripSeparator3;
		internal ToolStripLabel ToolStripLabel1;
		internal DarkUI.Controls.DarkSectionPanel pnlBack2;
		internal PictureBox picScreen;
		internal DarkUI.Controls.DarkStatusStrip ssInfo;
		internal ToolStripStatusLabel tslCurMap;
		internal ToolStripComboBox cmbMapList;
		internal DarkUI.Controls.DarkButton btnAttributes;
		internal DarkUI.Controls.DarkButton btnTiles;
		internal DarkUI.Controls.DarkScrollBar scrlMapViewH;
		internal DarkUI.Controls.DarkButton btnNpc;
		internal DarkUI.Controls.DarkButton btnDirBlock;
		internal DarkUI.Controls.DarkButton btnEvents;
		internal DarkUI.Controls.DarkScrollBar scrlMapViewV;
		internal Panel pnlBack;
		internal PictureBox picBackSelect;
		internal DarkUI.Controls.DarkScrollBar scrlPictureY;
		internal DarkUI.Controls.DarkScrollBar scrlPictureX;
		internal DarkUI.Controls.DarkLabel DarkLabel1;
		internal DarkUI.Controls.DarkLabel DarkLabel2;
		internal DarkUI.Controls.DarkLabel DarkLabel3;
		internal Panel pnlTiles;
		internal DarkUI.Controls.DarkLabel DarkLabel4;
		internal Panel pnlEvents;
		internal Panel pnlDirBlock;
		internal DarkUI.Controls.DarkLabel DarkLabel6;
		internal DarkUI.Controls.DarkLabel DarkLabel5;
		internal Panel pnlNpc;
		internal ListBox lstMapNpc;
		internal ComboBox cmbNpcList;
		internal Panel pnlAttribute;
		internal DarkUI.Controls.DarkRadioButton optBlocked;
		internal DarkUI.Controls.DarkRadioButton optNpcAvoid;
		internal DarkUI.Controls.DarkRadioButton optItem;
		internal DarkUI.Controls.DarkRadioButton optWarp;
		internal DarkUI.Controls.DarkRadioButton optHouse;
		internal DarkUI.Controls.DarkRadioButton optShop;
		internal DarkUI.Controls.DarkRadioButton optNpcSpawn;
		internal DarkUI.Controls.DarkRadioButton optBank;
		internal DarkUI.Controls.DarkRadioButton optCraft;
		internal DarkUI.Controls.DarkRadioButton optTrap;
		internal DarkUI.Controls.DarkRadioButton optHeal;
		internal DarkUI.Controls.DarkRadioButton optKeyOpen;
		internal DarkUI.Controls.DarkRadioButton optKey;
		internal DarkUI.Controls.DarkRadioButton optDoor;
		internal DarkUI.Controls.DarkRadioButton optResource;
		internal ToolStripStatusLabel tslCurXY;
		internal DarkUI.Controls.DarkButton btnClearAttribute;
		internal DarkUI.Controls.DarkLabel DarkLabel7;
		internal DarkUI.Controls.DarkCheckBox chkInstance;
		internal DarkUI.Controls.DarkTextBox txtName;
		internal DarkUI.Controls.DarkLabel DarkLabel8;
		internal GroupBox fraMapLinks;
		internal ComboBox cmbMoral;
		internal DarkUI.Controls.DarkLabel lblMap;
		internal GroupBox GroupBox1;
		internal DarkUI.Controls.DarkLabel DarkLabel9;
		internal DarkUI.Controls.DarkLabel DarkLabel11;
		internal DarkUI.Controls.DarkLabel DarkLabel10;
		internal GroupBox GroupBox2;
		internal DarkUI.Controls.DarkLabel DarkLabel13;
		internal DarkUI.Controls.DarkLabel DarkLabel12;
		internal DarkUI.Controls.DarkButton btnSetSize;
		internal GroupBox GroupBox3;
		internal DarkUI.Controls.DarkButton btnPreview;
		internal ListBox lstMusic;
		internal Panel pnlMoreOptions;
		internal DarkUI.Controls.DarkButton btnMoreOptions;
		internal GroupBox GroupBox4;
		internal ComboBox cmbWeather;
		internal DarkUI.Controls.DarkLabel DarkLabel14;
		internal DarkUI.Controls.DarkLabel lblIntensity;
		internal DarkUI.Controls.DarkLabel lblFogIndex;
		internal DarkUI.Controls.DarkLabel lblFogSpeed;
		internal DarkUI.Controls.DarkLabel lblFogAlpha;
		internal GroupBox GroupBox5;
		internal CheckBox chkUseTint;
		internal DarkUI.Controls.DarkLabel lblMapAlpha;
		internal DarkUI.Controls.DarkLabel lblMapBlue;
		internal DarkUI.Controls.DarkLabel lblMapGreen;
		internal DarkUI.Controls.DarkLabel lblMapRed;
		internal ToolStripStatusLabel tsCurFps;
		internal ToolStripSeparator ToolStripSeparator4;
		internal ToolStripButton tsbScreenShot;
		internal DarkUI.Controls.DarkRadioButton optLight;
		internal DarkUI.Controls.DarkComboBox cmbLayers;
		internal DarkUI.Controls.DarkComboBox cmbTileSets;
		internal DarkUI.Controls.DarkComboBox cmbAutoTile;
		internal Panel pnlAttributes;
		internal GroupBox fraMapWarp;
		internal Button btnMapWarp;
		internal HScrollBar scrlMapWarpY;
		internal HScrollBar scrlMapWarpX;
		internal HScrollBar scrlMapWarpMap;
		internal Label lblMapWarpY;
		internal Label lblMapWarpX;
		internal Label lblMapWarpMap;
		internal GroupBox fraBuyHouse;
		internal Button btnHouseTileOk;
		internal HScrollBar scrlBuyHouse;
		internal Label lblHouseName;
		internal GroupBox fraKeyOpen;
		internal HScrollBar scrlKeyY;
		internal Label lblKeyY;
		internal Button btnMapKeyOpen;
		internal HScrollBar scrlKeyX;
		internal Label lblKeyX;
		internal GroupBox fraMapKey;
		internal CheckBox chkMapKey;
		internal PictureBox picMapKey;
		internal Button btnMapKey;
		internal HScrollBar scrlMapKey;
		internal Label lblMapKey;
		internal GroupBox fraNpcSpawn;
		internal ComboBox lstNpc;
		internal Button btnNpcSpawn;
		internal HScrollBar scrlNpcDir;
		internal Label lblNpcDir;
		internal GroupBox fraHeal;
		internal HScrollBar scrlHeal;
		internal Label lblHeal;
		internal ComboBox cmbHeal;
		internal Button btnHeal;
		internal GroupBox fraShop;
		internal ComboBox cmbShop;
		internal Button btnShop;
		internal GroupBox fraResource;
		internal Button btnResourceOk;
		internal HScrollBar scrlResource;
		internal Label lblResource;
		internal GroupBox fraMapItem;
		internal PictureBox picMapItem;
		internal Button btnMapItem;
		internal HScrollBar scrlMapItemValue;
		internal HScrollBar scrlMapItem;
		internal Label lblMapItem;
		internal GroupBox fraTrap;
		internal Button btnTrap;
		internal HScrollBar scrlTrap;
		internal Label lblTrap;
		internal DarkUI.Controls.DarkNumericUpDown nudRight;
		internal DarkUI.Controls.DarkNumericUpDown nudLeft;
		internal DarkUI.Controls.DarkNumericUpDown nudDown;
		internal DarkUI.Controls.DarkNumericUpDown nudUp;
		internal DarkUI.Controls.DarkNumericUpDown nudMaxY;
		internal DarkUI.Controls.DarkNumericUpDown nudMaxX;
		internal DarkUI.Controls.DarkNumericUpDown nudSpawnY;
		internal DarkUI.Controls.DarkNumericUpDown nudSpawnX;
		internal DarkUI.Controls.DarkNumericUpDown nudSpawnMap;
		internal DarkUI.Controls.DarkNumericUpDown nudMapAlpha;
		internal DarkUI.Controls.DarkNumericUpDown nudMapBlue;
		internal DarkUI.Controls.DarkNumericUpDown nudMapGreen;
		internal DarkUI.Controls.DarkNumericUpDown nudMapRed;
		internal DarkUI.Controls.DarkNumericUpDown nudFogAlpha;
		internal DarkUI.Controls.DarkNumericUpDown nudFogSpeed;
		internal DarkUI.Controls.DarkNumericUpDown nudFog;
		internal DarkUI.Controls.DarkNumericUpDown nudIntensity;
		internal DarkUI.Controls.DarkLabel lblPasteMode;
		internal DarkUI.Controls.DarkButton btnPasteEvent;
		internal DarkUI.Controls.DarkLabel DarkLabel16;
		internal DarkUI.Controls.DarkLabel lblCopyMode;
		internal DarkUI.Controls.DarkButton btnCopyEvent;
		internal DarkUI.Controls.DarkLabel DarkLabel15;
		internal Label lblVisualWarp;
        internal DarkUI.Controls.DarkNumericUpDown nudBrightness;
        internal DarkUI.Controls.DarkLabel lblBrightness;
        internal DarkUI.Controls.DarkLabel darkLabel17;
        internal GroupBox fraLight;
        private NumericUpDown lightRadiusInput;
        internal CheckBox flickerCheckBox;
        internal Button button1;
        internal Label label1;
        internal CheckBox checkBox1;
    }
	
}
