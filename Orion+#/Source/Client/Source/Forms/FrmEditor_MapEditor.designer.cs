
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using Engine;

namespace Engine
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
		public partial class FrmEditor_MapEditor : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditor_MapEditor));
            this.scrlPictureX = new System.Windows.Forms.HScrollBar();
            this.scrlPictureY = new System.Windows.Forms.VScrollBar();
            this.optHouse = new System.Windows.Forms.RadioButton();
            this.btnClearAttribute = new System.Windows.Forms.Button();
            this.optTrap = new System.Windows.Forms.RadioButton();
            this.optHeal = new System.Windows.Forms.RadioButton();
            this.optBank = new System.Windows.Forms.RadioButton();
            this.optShop = new System.Windows.Forms.RadioButton();
            this.optNPCSpawn = new System.Windows.Forms.RadioButton();
            this.optDoor = new System.Windows.Forms.RadioButton();
            this.optResource = new System.Windows.Forms.RadioButton();
            this.optKeyOpen = new System.Windows.Forms.RadioButton();
            this.optKey = new System.Windows.Forms.RadioButton();
            this.optNPCAvoid = new System.Windows.Forms.RadioButton();
            this.optItem = new System.Windows.Forms.RadioButton();
            this.optWarp = new System.Windows.Forms.RadioButton();
            this.optBlocked = new System.Windows.Forms.RadioButton();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.picBackSelect = new System.Windows.Forms.PictureBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.pnlAttributes = new System.Windows.Forms.Panel();
            this.fraMapWarp = new System.Windows.Forms.GroupBox();
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
            this.ToolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbDiscard = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbMapGrid = new System.Windows.Forms.ToolStripButton();
            this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFill = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.tabpages = new System.Windows.Forms.TabControl();
            this.tpTiles = new System.Windows.Forms.TabPage();
            this.cmbAutoTile = new System.Windows.Forms.ComboBox();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.cmbLayers = new System.Windows.Forms.ComboBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.cmbTileSets = new System.Windows.Forms.ComboBox();
            this.tpAttributes = new System.Windows.Forms.TabPage();
            this.optLight = new System.Windows.Forms.RadioButton();
            this.optCraft = new System.Windows.Forms.RadioButton();
            this.tpNpcs = new System.Windows.Forms.TabPage();
            this.fraNpcs = new System.Windows.Forms.GroupBox();
            this.Label18 = new System.Windows.Forms.Label();
            this.Label17 = new System.Windows.Forms.Label();
            this.cmbNpcList = new System.Windows.Forms.ComboBox();
            this.lstMapNpc = new System.Windows.Forms.ListBox();
            this.ComboBox23 = new System.Windows.Forms.ComboBox();
            this.tpSettings = new System.Windows.Forms.TabPage();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.fraMapSettings = new System.Windows.Forms.GroupBox();
            this.chkInstance = new System.Windows.Forms.CheckBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.cmbMoral = new System.Windows.Forms.ComboBox();
            this.fraMapLinks = new System.Windows.Forms.GroupBox();
            this.txtDown = new System.Windows.Forms.TextBox();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.lblMap = new System.Windows.Forms.Label();
            this.txtRight = new System.Windows.Forms.TextBox();
            this.txtUp = new System.Windows.Forms.TextBox();
            this.fraBootSettings = new System.Windows.Forms.GroupBox();
            this.txtBootMap = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtBootY = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtBootX = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.fraMaxSizes = new System.Windows.Forms.GroupBox();
            this.txtMaxY = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.txtMaxX = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.btnPreview = new System.Windows.Forms.Button();
            this.lstMusic = new System.Windows.Forms.ListBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.tpDirBlock = new System.Windows.Forms.TabPage();
            this.Label12 = new System.Windows.Forms.Label();
            this.tpEvents = new System.Windows.Forms.TabPage();
            this.lblPasteMode = new System.Windows.Forms.Label();
            this.lblCopyMode = new System.Windows.Forms.Label();
            this.btnPasteEvent = new System.Windows.Forms.Button();
            this.Label16 = new System.Windows.Forms.Label();
            this.btnCopyEvent = new System.Windows.Forms.Button();
            this.Label15 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.TabPage1 = new System.Windows.Forms.TabPage();
            this.GroupBox5 = new System.Windows.Forms.GroupBox();
            this.Label20 = new System.Windows.Forms.Label();
            this.cmbParallax = new System.Windows.Forms.ComboBox();
            this.GroupBox4 = new System.Windows.Forms.GroupBox();
            this.Label19 = new System.Windows.Forms.Label();
            this.cmbPanorama = new System.Windows.Forms.ComboBox();
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.chkUseTint = new System.Windows.Forms.CheckBox();
            this.lblMapAlpha = new System.Windows.Forms.Label();
            this.lblMapBlue = new System.Windows.Forms.Label();
            this.lblMapGreen = new System.Windows.Forms.Label();
            this.lblMapRed = new System.Windows.Forms.Label();
            this.scrlMapAlpha = new System.Windows.Forms.HScrollBar();
            this.scrlMapBlue = new System.Windows.Forms.HScrollBar();
            this.scrlMapGreen = new System.Windows.Forms.HScrollBar();
            this.scrlMapRed = new System.Windows.Forms.HScrollBar();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.scrlFogAlpha = new System.Windows.Forms.HScrollBar();
            this.lblFogAlpha = new System.Windows.Forms.Label();
            this.scrlFogSpeed = new System.Windows.Forms.HScrollBar();
            this.lblFogSpeed = new System.Windows.Forms.Label();
            this.scrlIntensity = new System.Windows.Forms.HScrollBar();
            this.lblIntensity = new System.Windows.Forms.Label();
            this.scrlFog = new System.Windows.Forms.HScrollBar();
            this.lblFogIndex = new System.Windows.Forms.Label();
            this.Label14 = new System.Windows.Forms.Label();
            this.cmbWeather = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.lblBrightness = new System.Windows.Forms.Label();
            this.scrlBrightness = new System.Windows.Forms.HScrollBar();
            this.pnlBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBackSelect)).BeginInit();
            this.pnlAttributes.SuspendLayout();
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
            this.ToolStrip.SuspendLayout();
            this.tabpages.SuspendLayout();
            this.tpTiles.SuspendLayout();
            this.tpAttributes.SuspendLayout();
            this.tpNpcs.SuspendLayout();
            this.fraNpcs.SuspendLayout();
            this.tpSettings.SuspendLayout();
            this.fraMapSettings.SuspendLayout();
            this.fraMapLinks.SuspendLayout();
            this.fraBootSettings.SuspendLayout();
            this.fraMaxSizes.SuspendLayout();
            this.GroupBox2.SuspendLayout();
            this.tpDirBlock.SuspendLayout();
            this.tpEvents.SuspendLayout();
            this.TabPage1.SuspendLayout();
            this.GroupBox5.SuspendLayout();
            this.GroupBox4.SuspendLayout();
            this.GroupBox3.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // scrlPictureX
            // 
            this.scrlPictureX.LargeChange = 1;
            this.scrlPictureX.Location = new System.Drawing.Point(3, 408);
            this.scrlPictureX.Name = "scrlPictureX";
            this.scrlPictureX.Size = new System.Drawing.Size(463, 16);
            this.scrlPictureX.TabIndex = 1;
            this.scrlPictureX.ValueChanged += new System.EventHandler(this.ScrlPictureX_Scroll);
            // 
            // scrlPictureY
            // 
            this.scrlPictureY.LargeChange = 1;
            this.scrlPictureY.Location = new System.Drawing.Point(469, 9);
            this.scrlPictureY.Name = "scrlPictureY";
            this.scrlPictureY.Size = new System.Drawing.Size(16, 396);
            this.scrlPictureY.TabIndex = 2;
            this.scrlPictureY.ValueChanged += new System.EventHandler(this.ScrlPictureY_Scroll);
            // 
            // optHouse
            // 
            this.optHouse.AutoSize = true;
            this.optHouse.Location = new System.Drawing.Point(320, 49);
            this.optHouse.Name = "optHouse";
            this.optHouse.Size = new System.Drawing.Size(77, 17);
            this.optHouse.TabIndex = 15;
            this.optHouse.TabStop = true;
            this.optHouse.Text = "Buy House";
            this.optHouse.UseVisualStyleBackColor = true;
            this.optHouse.CheckedChanged += new System.EventHandler(this.OptHouse_CheckedChanged);
            // 
            // btnClearAttribute
            // 
            this.btnClearAttribute.Location = new System.Drawing.Point(320, 437);
            this.btnClearAttribute.Name = "btnClearAttribute";
            this.btnClearAttribute.Size = new System.Drawing.Size(165, 25);
            this.btnClearAttribute.TabIndex = 14;
            this.btnClearAttribute.Text = "Clear All Attributes";
            this.btnClearAttribute.UseVisualStyleBackColor = true;
            this.btnClearAttribute.Click += new System.EventHandler(this.BtnClearAttribute_Click);
            // 
            // optTrap
            // 
            this.optTrap.AutoSize = true;
            this.optTrap.Location = new System.Drawing.Point(101, 85);
            this.optTrap.Name = "optTrap";
            this.optTrap.Size = new System.Drawing.Size(47, 17);
            this.optTrap.TabIndex = 12;
            this.optTrap.TabStop = true;
            this.optTrap.Text = "Trap";
            this.optTrap.UseVisualStyleBackColor = true;
            this.optTrap.CheckedChanged += new System.EventHandler(this.OptTrap_CheckedChanged);
            // 
            // optHeal
            // 
            this.optHeal.AutoSize = true;
            this.optHeal.Location = new System.Drawing.Point(10, 85);
            this.optHeal.Name = "optHeal";
            this.optHeal.Size = new System.Drawing.Size(47, 17);
            this.optHeal.TabIndex = 11;
            this.optHeal.TabStop = true;
            this.optHeal.Text = "Heal";
            this.optHeal.UseVisualStyleBackColor = true;
            this.optHeal.CheckedChanged += new System.EventHandler(this.OptHeal_CheckedChanged);
            // 
            // optBank
            // 
            this.optBank.AutoSize = true;
            this.optBank.Location = new System.Drawing.Point(409, 49);
            this.optBank.Name = "optBank";
            this.optBank.Size = new System.Drawing.Size(50, 17);
            this.optBank.TabIndex = 10;
            this.optBank.TabStop = true;
            this.optBank.Text = "Bank";
            this.optBank.UseVisualStyleBackColor = true;
            // 
            // optShop
            // 
            this.optShop.AutoSize = true;
            this.optShop.Location = new System.Drawing.Point(409, 14);
            this.optShop.Name = "optShop";
            this.optShop.Size = new System.Drawing.Size(50, 17);
            this.optShop.TabIndex = 9;
            this.optShop.TabStop = true;
            this.optShop.Text = "Shop";
            this.optShop.UseVisualStyleBackColor = true;
            this.optShop.CheckedChanged += new System.EventHandler(this.OptShop_CheckedChanged);
            // 
            // optNPCSpawn
            // 
            this.optNPCSpawn.AutoSize = true;
            this.optNPCSpawn.Location = new System.Drawing.Point(320, 14);
            this.optNPCSpawn.Name = "optNPCSpawn";
            this.optNPCSpawn.Size = new System.Drawing.Size(83, 17);
            this.optNPCSpawn.TabIndex = 8;
            this.optNPCSpawn.TabStop = true;
            this.optNPCSpawn.Text = "NPC Spawn";
            this.optNPCSpawn.UseVisualStyleBackColor = true;
            this.optNPCSpawn.CheckedChanged += new System.EventHandler(this.OptNPCSpawn_CheckedChanged);
            // 
            // optDoor
            // 
            this.optDoor.AutoSize = true;
            this.optDoor.Location = new System.Drawing.Point(101, 50);
            this.optDoor.Name = "optDoor";
            this.optDoor.Size = new System.Drawing.Size(48, 17);
            this.optDoor.TabIndex = 7;
            this.optDoor.TabStop = true;
            this.optDoor.Text = "Door";
            this.optDoor.UseVisualStyleBackColor = true;
            this.optDoor.CheckedChanged += new System.EventHandler(this.OptDoor_CheckedChanged);
            // 
            // optResource
            // 
            this.optResource.AutoSize = true;
            this.optResource.Location = new System.Drawing.Point(10, 50);
            this.optResource.Name = "optResource";
            this.optResource.Size = new System.Drawing.Size(71, 17);
            this.optResource.TabIndex = 6;
            this.optResource.TabStop = true;
            this.optResource.Text = "Resource";
            this.optResource.UseVisualStyleBackColor = true;
            this.optResource.CheckedChanged += new System.EventHandler(this.OptResource_CheckedChanged);
            // 
            // optKeyOpen
            // 
            this.optKeyOpen.AutoSize = true;
            this.optKeyOpen.Location = new System.Drawing.Point(237, 50);
            this.optKeyOpen.Name = "optKeyOpen";
            this.optKeyOpen.Size = new System.Drawing.Size(72, 17);
            this.optKeyOpen.TabIndex = 5;
            this.optKeyOpen.TabStop = true;
            this.optKeyOpen.Text = "Key Open";
            this.optKeyOpen.UseVisualStyleBackColor = true;
            this.optKeyOpen.CheckedChanged += new System.EventHandler(this.OptKeyOpen_CheckedChanged);
            // 
            // optKey
            // 
            this.optKey.AutoSize = true;
            this.optKey.Location = new System.Drawing.Point(173, 50);
            this.optKey.Name = "optKey";
            this.optKey.Size = new System.Drawing.Size(43, 17);
            this.optKey.TabIndex = 4;
            this.optKey.TabStop = true;
            this.optKey.Text = "Key";
            this.optKey.UseVisualStyleBackColor = true;
            this.optKey.CheckedChanged += new System.EventHandler(this.OptKey_CheckedChanged);
            // 
            // optNPCAvoid
            // 
            this.optNPCAvoid.AutoSize = true;
            this.optNPCAvoid.Location = new System.Drawing.Point(237, 14);
            this.optNPCAvoid.Name = "optNPCAvoid";
            this.optNPCAvoid.Size = new System.Drawing.Size(77, 17);
            this.optNPCAvoid.TabIndex = 3;
            this.optNPCAvoid.TabStop = true;
            this.optNPCAvoid.Text = "NPC Avoid";
            this.optNPCAvoid.UseVisualStyleBackColor = true;
            // 
            // optItem
            // 
            this.optItem.AutoSize = true;
            this.optItem.Location = new System.Drawing.Point(173, 14);
            this.optItem.Name = "optItem";
            this.optItem.Size = new System.Drawing.Size(45, 17);
            this.optItem.TabIndex = 2;
            this.optItem.TabStop = true;
            this.optItem.Text = "Item";
            this.optItem.UseVisualStyleBackColor = true;
            this.optItem.CheckedChanged += new System.EventHandler(this.OptItem_CheckedChanged);
            // 
            // optWarp
            // 
            this.optWarp.AutoSize = true;
            this.optWarp.Location = new System.Drawing.Point(101, 14);
            this.optWarp.Name = "optWarp";
            this.optWarp.Size = new System.Drawing.Size(51, 17);
            this.optWarp.TabIndex = 1;
            this.optWarp.TabStop = true;
            this.optWarp.Text = "Warp";
            this.optWarp.UseVisualStyleBackColor = true;
            this.optWarp.CheckedChanged += new System.EventHandler(this.OptWarp_CheckedChanged);
            // 
            // optBlocked
            // 
            this.optBlocked.AutoSize = true;
            this.optBlocked.Location = new System.Drawing.Point(10, 14);
            this.optBlocked.Name = "optBlocked";
            this.optBlocked.Size = new System.Drawing.Size(64, 17);
            this.optBlocked.TabIndex = 0;
            this.optBlocked.TabStop = true;
            this.optBlocked.Text = "Blocked";
            this.optBlocked.UseVisualStyleBackColor = true;
            this.optBlocked.CheckedChanged += new System.EventHandler(this.OptBlocked_CheckedChanged);
            // 
            // pnlBack
            // 
            this.pnlBack.Controls.Add(this.picBackSelect);
            this.pnlBack.Location = new System.Drawing.Point(6, 8);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(460, 397);
            this.pnlBack.TabIndex = 9;
            this.pnlBack.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlBack_Paint);
            // 
            // picBackSelect
            // 
            this.picBackSelect.BackColor = System.Drawing.Color.Black;
            this.picBackSelect.Location = new System.Drawing.Point(0, 0);
            this.picBackSelect.Name = "picBackSelect";
            this.picBackSelect.Size = new System.Drawing.Size(460, 397);
            this.picBackSelect.TabIndex = 1;
            this.picBackSelect.TabStop = false;
            this.picBackSelect.Paint += new System.Windows.Forms.PaintEventHandler(this.PicBackSelect_Paint);
            this.picBackSelect.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicBackSelect_MouseDown);
            this.picBackSelect.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PicBackSelect_MouseMove);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(78, 423);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(174, 13);
            this.Label1.TabIndex = 11;
            this.Label1.Text = "Drag Mouse to Select Multiple Tiles";
            // 
            // pnlAttributes
            // 
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
            this.pnlAttributes.Location = new System.Drawing.Point(505, 31);
            this.pnlAttributes.Name = "pnlAttributes";
            this.pnlAttributes.Size = new System.Drawing.Size(502, 491);
            this.pnlAttributes.TabIndex = 12;
            this.pnlAttributes.Visible = false;
            // 
            // fraMapWarp
            // 
            this.fraMapWarp.Controls.Add(this.btnMapWarp);
            this.fraMapWarp.Controls.Add(this.scrlMapWarpY);
            this.fraMapWarp.Controls.Add(this.scrlMapWarpX);
            this.fraMapWarp.Controls.Add(this.scrlMapWarpMap);
            this.fraMapWarp.Controls.Add(this.lblMapWarpY);
            this.fraMapWarp.Controls.Add(this.lblMapWarpX);
            this.fraMapWarp.Controls.Add(this.lblMapWarpMap);
            this.fraMapWarp.Location = new System.Drawing.Point(9, 370);
            this.fraMapWarp.Name = "fraMapWarp";
            this.fraMapWarp.Size = new System.Drawing.Size(252, 119);
            this.fraMapWarp.TabIndex = 0;
            this.fraMapWarp.TabStop = false;
            this.fraMapWarp.Text = "Map Warp";
            // 
            // btnMapWarp
            // 
            this.btnMapWarp.Location = new System.Drawing.Point(80, 88);
            this.btnMapWarp.Name = "btnMapWarp";
            this.btnMapWarp.Size = new System.Drawing.Size(90, 28);
            this.btnMapWarp.TabIndex = 6;
            this.btnMapWarp.Text = "Accept";
            this.btnMapWarp.UseVisualStyleBackColor = true;
            this.btnMapWarp.Click += new System.EventHandler(this.BtnMapWarp_Click);
            // 
            // scrlMapWarpY
            // 
            this.scrlMapWarpY.Location = new System.Drawing.Point(62, 63);
            this.scrlMapWarpY.Name = "scrlMapWarpY";
            this.scrlMapWarpY.Size = new System.Drawing.Size(161, 18);
            this.scrlMapWarpY.TabIndex = 5;
            this.scrlMapWarpY.ValueChanged += new System.EventHandler(this.ScrlMapWarpY_Scroll);
            // 
            // scrlMapWarpX
            // 
            this.scrlMapWarpX.Location = new System.Drawing.Point(62, 41);
            this.scrlMapWarpX.Name = "scrlMapWarpX";
            this.scrlMapWarpX.Size = new System.Drawing.Size(161, 18);
            this.scrlMapWarpX.TabIndex = 4;
            this.scrlMapWarpX.ValueChanged += new System.EventHandler(this.ScrlMapWarpX_Scroll);
            // 
            // scrlMapWarpMap
            // 
            this.scrlMapWarpMap.Location = new System.Drawing.Point(62, 20);
            this.scrlMapWarpMap.Name = "scrlMapWarpMap";
            this.scrlMapWarpMap.Size = new System.Drawing.Size(161, 18);
            this.scrlMapWarpMap.TabIndex = 3;
            this.scrlMapWarpMap.ValueChanged += new System.EventHandler(this.ScrlMapWarpMap_Scroll);
            // 
            // lblMapWarpY
            // 
            this.lblMapWarpY.AutoSize = true;
            this.lblMapWarpY.Location = new System.Drawing.Point(7, 67);
            this.lblMapWarpY.Name = "lblMapWarpY";
            this.lblMapWarpY.Size = new System.Drawing.Size(26, 13);
            this.lblMapWarpY.TabIndex = 2;
            this.lblMapWarpY.Text = "Y: 1";
            // 
            // lblMapWarpX
            // 
            this.lblMapWarpX.AutoSize = true;
            this.lblMapWarpX.Location = new System.Drawing.Point(7, 46);
            this.lblMapWarpX.Name = "lblMapWarpX";
            this.lblMapWarpX.Size = new System.Drawing.Size(26, 13);
            this.lblMapWarpX.TabIndex = 1;
            this.lblMapWarpX.Text = "X: 1";
            // 
            // lblMapWarpMap
            // 
            this.lblMapWarpMap.AutoSize = true;
            this.lblMapWarpMap.Location = new System.Drawing.Point(6, 25);
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
            this.fraBuyHouse.Location = new System.Drawing.Point(336, 6);
            this.fraBuyHouse.Name = "fraBuyHouse";
            this.fraBuyHouse.Size = new System.Drawing.Size(164, 113);
            this.fraBuyHouse.TabIndex = 17;
            this.fraBuyHouse.TabStop = false;
            this.fraBuyHouse.Text = "Buy House";
            // 
            // btnHouseTileOk
            // 
            this.btnHouseTileOk.Location = new System.Drawing.Point(39, 76);
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
            this.scrlBuyHouse.Location = new System.Drawing.Point(9, 37);
            this.scrlBuyHouse.Name = "scrlBuyHouse";
            this.scrlBuyHouse.Size = new System.Drawing.Size(142, 18);
            this.scrlBuyHouse.TabIndex = 3;
            this.scrlBuyHouse.ValueChanged += new System.EventHandler(this.ScrlBuyHouse_Scroll);
            // 
            // lblHouseName
            // 
            this.lblHouseName.AutoSize = true;
            this.lblHouseName.Location = new System.Drawing.Point(6, 17);
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
            this.fraKeyOpen.Location = new System.Drawing.Point(265, 370);
            this.fraKeyOpen.Name = "fraKeyOpen";
            this.fraKeyOpen.Size = new System.Drawing.Size(200, 117);
            this.fraKeyOpen.TabIndex = 9;
            this.fraKeyOpen.TabStop = false;
            this.fraKeyOpen.Text = "Map Key Open";
            // 
            // scrlKeyY
            // 
            this.scrlKeyY.Location = new System.Drawing.Point(63, 45);
            this.scrlKeyY.Name = "scrlKeyY";
            this.scrlKeyY.Size = new System.Drawing.Size(127, 18);
            this.scrlKeyY.TabIndex = 8;
            this.scrlKeyY.ValueChanged += new System.EventHandler(this.ScrlKeyY_Scroll);
            // 
            // lblKeyY
            // 
            this.lblKeyY.AutoSize = true;
            this.lblKeyY.Location = new System.Drawing.Point(6, 47);
            this.lblKeyY.Name = "lblKeyY";
            this.lblKeyY.Size = new System.Drawing.Size(26, 13);
            this.lblKeyY.TabIndex = 7;
            this.lblKeyY.Text = "Y: 0";
            // 
            // btnMapKeyOpen
            // 
            this.btnMapKeyOpen.Location = new System.Drawing.Point(51, 76);
            this.btnMapKeyOpen.Name = "btnMapKeyOpen";
            this.btnMapKeyOpen.Size = new System.Drawing.Size(90, 28);
            this.btnMapKeyOpen.TabIndex = 6;
            this.btnMapKeyOpen.Text = "Accept";
            this.btnMapKeyOpen.UseVisualStyleBackColor = true;
            this.btnMapKeyOpen.Click += new System.EventHandler(this.BtnMapKeyOpen_Click);
            // 
            // scrlKeyX
            // 
            this.scrlKeyX.Location = new System.Drawing.Point(63, 17);
            this.scrlKeyX.Name = "scrlKeyX";
            this.scrlKeyX.Size = new System.Drawing.Size(127, 18);
            this.scrlKeyX.TabIndex = 3;
            this.scrlKeyX.ValueChanged += new System.EventHandler(this.ScrlKeyX_Scroll);
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
            this.fraMapKey.Location = new System.Drawing.Point(183, 251);
            this.fraMapKey.Name = "fraMapKey";
            this.fraMapKey.Size = new System.Drawing.Size(166, 113);
            this.fraMapKey.TabIndex = 8;
            this.fraMapKey.TabStop = false;
            this.fraMapKey.Text = "Map Key";
            // 
            // chkMapKey
            // 
            this.chkMapKey.AutoSize = true;
            this.chkMapKey.Checked = true;
            this.chkMapKey.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMapKey.Location = new System.Drawing.Point(9, 58);
            this.chkMapKey.Name = "chkMapKey";
            this.chkMapKey.Size = new System.Drawing.Size(152, 17);
            this.chkMapKey.TabIndex = 8;
            this.chkMapKey.Text = "Take Key Away Upon Use";
            this.chkMapKey.UseVisualStyleBackColor = true;
            // 
            // picMapKey
            // 
            this.picMapKey.BackColor = System.Drawing.Color.Black;
            this.picMapKey.Location = new System.Drawing.Point(17, 76);
            this.picMapKey.Name = "picMapKey";
            this.picMapKey.Size = new System.Drawing.Size(32, 32);
            this.picMapKey.TabIndex = 7;
            this.picMapKey.TabStop = false;
            // 
            // btnMapKey
            // 
            this.btnMapKey.Location = new System.Drawing.Point(55, 80);
            this.btnMapKey.Name = "btnMapKey";
            this.btnMapKey.Size = new System.Drawing.Size(90, 28);
            this.btnMapKey.TabIndex = 6;
            this.btnMapKey.Text = "Accept";
            this.btnMapKey.UseVisualStyleBackColor = true;
            this.btnMapKey.Click += new System.EventHandler(this.BtnMapKey_Click);
            // 
            // scrlMapKey
            // 
            this.scrlMapKey.Location = new System.Drawing.Point(9, 31);
            this.scrlMapKey.Name = "scrlMapKey";
            this.scrlMapKey.Size = new System.Drawing.Size(152, 18);
            this.scrlMapKey.TabIndex = 3;
            this.scrlMapKey.ValueChanged += new System.EventHandler(this.ScrlMapKey_Scroll);
            // 
            // lblMapKey
            // 
            this.lblMapKey.AutoSize = true;
            this.lblMapKey.Location = new System.Drawing.Point(6, 16);
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
            this.fraNpcSpawn.Location = new System.Drawing.Point(3, 6);
            this.fraNpcSpawn.Name = "fraNpcSpawn";
            this.fraNpcSpawn.Size = new System.Drawing.Size(174, 113);
            this.fraNpcSpawn.TabIndex = 11;
            this.fraNpcSpawn.TabStop = false;
            this.fraNpcSpawn.Text = "Npc Spawn";
            // 
            // lstNpc
            // 
            this.lstNpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lstNpc.FormattingEnabled = true;
            this.lstNpc.Location = new System.Drawing.Point(6, 16);
            this.lstNpc.Name = "lstNpc";
            this.lstNpc.Size = new System.Drawing.Size(155, 21);
            this.lstNpc.TabIndex = 37;
            // 
            // btnNpcSpawn
            // 
            this.btnNpcSpawn.Location = new System.Drawing.Point(39, 76);
            this.btnNpcSpawn.Name = "btnNpcSpawn";
            this.btnNpcSpawn.Size = new System.Drawing.Size(90, 28);
            this.btnNpcSpawn.TabIndex = 6;
            this.btnNpcSpawn.Text = "Accept";
            this.btnNpcSpawn.UseVisualStyleBackColor = true;
            this.btnNpcSpawn.Click += new System.EventHandler(this.BtnNpcSpawn_Click);
            // 
            // scrlNpcDir
            // 
            this.scrlNpcDir.LargeChange = 1;
            this.scrlNpcDir.Location = new System.Drawing.Point(8, 55);
            this.scrlNpcDir.Maximum = 3;
            this.scrlNpcDir.Name = "scrlNpcDir";
            this.scrlNpcDir.Size = new System.Drawing.Size(153, 18);
            this.scrlNpcDir.TabIndex = 3;
            this.scrlNpcDir.ValueChanged += new System.EventHandler(this.ScrlNpcDir_Scroll);
            // 
            // lblNpcDir
            // 
            this.lblNpcDir.AutoSize = true;
            this.lblNpcDir.Location = new System.Drawing.Point(5, 40);
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
            this.fraHeal.Location = new System.Drawing.Point(3, 251);
            this.fraHeal.Name = "fraHeal";
            this.fraHeal.Size = new System.Drawing.Size(174, 113);
            this.fraHeal.TabIndex = 15;
            this.fraHeal.TabStop = false;
            this.fraHeal.Text = "Heal";
            // 
            // scrlHeal
            // 
            this.scrlHeal.Location = new System.Drawing.Point(4, 56);
            this.scrlHeal.Name = "scrlHeal";
            this.scrlHeal.Size = new System.Drawing.Size(155, 17);
            this.scrlHeal.TabIndex = 39;
            this.scrlHeal.ValueChanged += new System.EventHandler(this.ScrlHeal_Scroll);
            // 
            // lblHeal
            // 
            this.lblHeal.AutoSize = true;
            this.lblHeal.Location = new System.Drawing.Point(3, 43);
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
            "Heal HP",
            "Heal MP"});
            this.cmbHeal.Location = new System.Drawing.Point(6, 19);
            this.cmbHeal.Name = "cmbHeal";
            this.cmbHeal.Size = new System.Drawing.Size(155, 21);
            this.cmbHeal.TabIndex = 37;
            // 
            // btnHeal
            // 
            this.btnHeal.Location = new System.Drawing.Point(37, 76);
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
            this.fraShop.Location = new System.Drawing.Point(336, 125);
            this.fraShop.Name = "fraShop";
            this.fraShop.Size = new System.Drawing.Size(147, 120);
            this.fraShop.TabIndex = 12;
            this.fraShop.TabStop = false;
            this.fraShop.Text = "Shop";
            // 
            // cmbShop
            // 
            this.cmbShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShop.FormattingEnabled = true;
            this.cmbShop.Location = new System.Drawing.Point(6, 19);
            this.cmbShop.Name = "cmbShop";
            this.cmbShop.Size = new System.Drawing.Size(133, 21);
            this.cmbShop.TabIndex = 37;
            // 
            // btnShop
            // 
            this.btnShop.Location = new System.Drawing.Point(29, 85);
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
            this.fraResource.Location = new System.Drawing.Point(183, 6);
            this.fraResource.Name = "fraResource";
            this.fraResource.Size = new System.Drawing.Size(147, 113);
            this.fraResource.TabIndex = 10;
            this.fraResource.TabStop = false;
            this.fraResource.Text = "Resource";
            // 
            // btnResourceOk
            // 
            this.btnResourceOk.Location = new System.Drawing.Point(28, 76);
            this.btnResourceOk.Name = "btnResourceOk";
            this.btnResourceOk.Size = new System.Drawing.Size(90, 28);
            this.btnResourceOk.TabIndex = 6;
            this.btnResourceOk.Text = "Accept";
            this.btnResourceOk.UseVisualStyleBackColor = true;
            this.btnResourceOk.Click += new System.EventHandler(this.BtnResourceOk_Click);
            // 
            // scrlResource
            // 
            this.scrlResource.Location = new System.Drawing.Point(3, 36);
            this.scrlResource.Name = "scrlResource";
            this.scrlResource.Size = new System.Drawing.Size(136, 18);
            this.scrlResource.TabIndex = 3;
            this.scrlResource.ValueChanged += new System.EventHandler(this.ScrlResource_Scroll);
            // 
            // lblResource
            // 
            this.lblResource.AutoSize = true;
            this.lblResource.Location = new System.Drawing.Point(0, 16);
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
            this.fraMapItem.Location = new System.Drawing.Point(3, 126);
            this.fraMapItem.Name = "fraMapItem";
            this.fraMapItem.Size = new System.Drawing.Size(174, 119);
            this.fraMapItem.TabIndex = 7;
            this.fraMapItem.TabStop = false;
            this.fraMapItem.Text = "Map Item";
            // 
            // picMapItem
            // 
            this.picMapItem.BackColor = System.Drawing.Color.Black;
            this.picMapItem.Location = new System.Drawing.Point(133, 36);
            this.picMapItem.Name = "picMapItem";
            this.picMapItem.Size = new System.Drawing.Size(32, 32);
            this.picMapItem.TabIndex = 7;
            this.picMapItem.TabStop = false;
            // 
            // btnMapItem
            // 
            this.btnMapItem.Location = new System.Drawing.Point(39, 84);
            this.btnMapItem.Name = "btnMapItem";
            this.btnMapItem.Size = new System.Drawing.Size(90, 28);
            this.btnMapItem.TabIndex = 6;
            this.btnMapItem.Text = "Accept";
            this.btnMapItem.UseVisualStyleBackColor = true;
            this.btnMapItem.Click += new System.EventHandler(this.BtnMapItem_Click);
            // 
            // scrlMapItemValue
            // 
            this.scrlMapItemValue.Location = new System.Drawing.Point(9, 59);
            this.scrlMapItemValue.Name = "scrlMapItemValue";
            this.scrlMapItemValue.Size = new System.Drawing.Size(120, 18);
            this.scrlMapItemValue.TabIndex = 4;
            this.scrlMapItemValue.ValueChanged += new System.EventHandler(this.ScrlMapItemValue_Scroll);
            // 
            // scrlMapItem
            // 
            this.scrlMapItem.Location = new System.Drawing.Point(9, 37);
            this.scrlMapItem.Name = "scrlMapItem";
            this.scrlMapItem.Size = new System.Drawing.Size(120, 18);
            this.scrlMapItem.TabIndex = 3;
            this.scrlMapItem.ValueChanged += new System.EventHandler(this.ScrlMapItem_Scroll);
            // 
            // lblMapItem
            // 
            this.lblMapItem.AutoSize = true;
            this.lblMapItem.Location = new System.Drawing.Point(6, 22);
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
            this.fraTrap.Location = new System.Drawing.Point(183, 125);
            this.fraTrap.Name = "fraTrap";
            this.fraTrap.Size = new System.Drawing.Size(147, 120);
            this.fraTrap.TabIndex = 16;
            this.fraTrap.TabStop = false;
            this.fraTrap.Text = "Trap";
            // 
            // btnTrap
            // 
            this.btnTrap.Location = new System.Drawing.Point(28, 85);
            this.btnTrap.Name = "btnTrap";
            this.btnTrap.Size = new System.Drawing.Size(90, 28);
            this.btnTrap.TabIndex = 42;
            this.btnTrap.Text = "Accept";
            this.btnTrap.UseVisualStyleBackColor = true;
            this.btnTrap.Click += new System.EventHandler(this.BtnTrap_Click);
            // 
            // scrlTrap
            // 
            this.scrlTrap.Location = new System.Drawing.Point(11, 33);
            this.scrlTrap.Name = "scrlTrap";
            this.scrlTrap.Size = new System.Drawing.Size(128, 17);
            this.scrlTrap.TabIndex = 41;
            this.scrlTrap.ValueChanged += new System.EventHandler(this.ScrlTrap_Scroll);
            // 
            // lblTrap
            // 
            this.lblTrap.AutoSize = true;
            this.lblTrap.Location = new System.Drawing.Point(6, 16);
            this.lblTrap.Name = "lblTrap";
            this.lblTrap.Size = new System.Drawing.Size(55, 13);
            this.lblTrap.TabIndex = 40;
            this.lblTrap.Text = "Amount: 0";
            // 
            // ToolStrip
            // 
            this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbDiscard,
            this.ToolStripSeparator1,
            this.tsbMapGrid,
            this.ToolStripSeparator2,
            this.tsbFill,
            this.tsbClear});
            this.ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip.Name = "ToolStrip";
            this.ToolStrip.Size = new System.Drawing.Size(1014, 25);
            this.ToolStrip.TabIndex = 13;
            this.ToolStrip.Text = "ToolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.Image = global::My.Resources.Resources.Save;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(51, 22);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.TsbSave_Click);
            // 
            // tsbDiscard
            // 
            this.tsbDiscard.Image = global::My.Resources.Resources._Exit;
            this.tsbDiscard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDiscard.Name = "tsbDiscard";
            this.tsbDiscard.Size = new System.Drawing.Size(66, 22);
            this.tsbDiscard.Text = "Discard";
            this.tsbDiscard.Click += new System.EventHandler(this.TsbDiscard_Click);
            // 
            // ToolStripSeparator1
            // 
            this.ToolStripSeparator1.Name = "ToolStripSeparator1";
            this.ToolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbMapGrid
            // 
            this.tsbMapGrid.Image = global::My.Resources.Resources.Grid;
            this.tsbMapGrid.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbMapGrid.Name = "tsbMapGrid";
            this.tsbMapGrid.Size = new System.Drawing.Size(76, 22);
            this.tsbMapGrid.Text = "Map Grid";
            this.tsbMapGrid.Click += new System.EventHandler(this.TsbMapGrid_Click);
            // 
            // ToolStripSeparator2
            // 
            this.ToolStripSeparator2.Name = "ToolStripSeparator2";
            this.ToolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbFill
            // 
            this.tsbFill.Image = global::My.Resources.Resources.Fill;
            this.tsbFill.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFill.Name = "tsbFill";
            this.tsbFill.Size = new System.Drawing.Size(73, 22);
            this.tsbFill.Text = "Fill Layer";
            this.tsbFill.ToolTipText = "Fill Layer";
            this.tsbFill.Click += new System.EventHandler(this.TsbFill_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.Image = global::My.Resources.Resources.Clear;
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(85, 22);
            this.tsbClear.Text = "Clear Layer";
            this.tsbClear.Click += new System.EventHandler(this.TsbClear_Click);
            // 
            // tabpages
            // 
            this.tabpages.Controls.Add(this.tpTiles);
            this.tabpages.Controls.Add(this.tpAttributes);
            this.tabpages.Controls.Add(this.tpNpcs);
            this.tabpages.Controls.Add(this.tpSettings);
            this.tabpages.Controls.Add(this.tpDirBlock);
            this.tabpages.Controls.Add(this.tpEvents);
            this.tabpages.Controls.Add(this.TabPage1);
            this.tabpages.Location = new System.Drawing.Point(4, 28);
            this.tabpages.Name = "tabpages";
            this.tabpages.SelectedIndex = 0;
            this.tabpages.Size = new System.Drawing.Size(499, 494);
            this.tabpages.TabIndex = 14;
            // 
            // tpTiles
            // 
            this.tpTiles.Controls.Add(this.cmbAutoTile);
            this.tpTiles.Controls.Add(this.Label11);
            this.tpTiles.Controls.Add(this.Label10);
            this.tpTiles.Controls.Add(this.cmbLayers);
            this.tpTiles.Controls.Add(this.Label9);
            this.tpTiles.Controls.Add(this.cmbTileSets);
            this.tpTiles.Controls.Add(this.pnlBack);
            this.tpTiles.Controls.Add(this.Label1);
            this.tpTiles.Controls.Add(this.scrlPictureX);
            this.tpTiles.Controls.Add(this.scrlPictureY);
            this.tpTiles.Location = new System.Drawing.Point(4, 22);
            this.tpTiles.Name = "tpTiles";
            this.tpTiles.Padding = new System.Windows.Forms.Padding(3);
            this.tpTiles.Size = new System.Drawing.Size(491, 468);
            this.tpTiles.TabIndex = 0;
            this.tpTiles.Text = "Tiles";
            this.tpTiles.UseVisualStyleBackColor = true;
            // 
            // cmbAutoTile
            // 
            this.cmbAutoTile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutoTile.FormattingEnabled = true;
            this.cmbAutoTile.Items.AddRange(new object[] {
            "Normal",
            "AutoTile (VX)",
            "Fake (VX)",
            "Animated (VX)",
            "Cliff (VX)",
            "Waterfall (VX)"});
            this.cmbAutoTile.Location = new System.Drawing.Point(366, 443);
            this.cmbAutoTile.Name = "cmbAutoTile";
            this.cmbAutoTile.Size = new System.Drawing.Size(119, 21);
            this.cmbAutoTile.TabIndex = 17;
            this.cmbAutoTile.SelectedIndexChanged += new System.EventHandler(this.CmbAutoTile_SelectedIndexChanged);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(311, 446);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(49, 13);
            this.Label11.TabIndex = 16;
            this.Label11.Text = "AutoTile:";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Location = new System.Drawing.Point(142, 446);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(36, 13);
            this.Label10.TabIndex = 15;
            this.Label10.Text = "Layer:";
            // 
            // cmbLayers
            // 
            this.cmbLayers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLayers.FormattingEnabled = true;
            this.cmbLayers.Items.AddRange(new object[] {
            "Ground",
            "Mask",
            "Mask 2",
            "Fringe",
            "Fringe 2"});
            this.cmbLayers.Location = new System.Drawing.Point(184, 443);
            this.cmbLayers.Name = "cmbLayers";
            this.cmbLayers.Size = new System.Drawing.Size(121, 21);
            this.cmbLayers.TabIndex = 14;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(6, 446);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(41, 13);
            this.Label9.TabIndex = 13;
            this.Label9.Text = "Tileset:";
            // 
            // cmbTileSets
            // 
            this.cmbTileSets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTileSets.FormattingEnabled = true;
            this.cmbTileSets.Location = new System.Drawing.Point(53, 443);
            this.cmbTileSets.Name = "cmbTileSets";
            this.cmbTileSets.Size = new System.Drawing.Size(83, 21);
            this.cmbTileSets.TabIndex = 12;
            this.cmbTileSets.Click += new System.EventHandler(this.CmbTileSets_SelectedIndexChanged);
            // 
            // tpAttributes
            // 
            this.tpAttributes.Controls.Add(this.optLight);
            this.tpAttributes.Controls.Add(this.optCraft);
            this.tpAttributes.Controls.Add(this.optHouse);
            this.tpAttributes.Controls.Add(this.btnClearAttribute);
            this.tpAttributes.Controls.Add(this.optTrap);
            this.tpAttributes.Controls.Add(this.optBlocked);
            this.tpAttributes.Controls.Add(this.optHeal);
            this.tpAttributes.Controls.Add(this.optWarp);
            this.tpAttributes.Controls.Add(this.optBank);
            this.tpAttributes.Controls.Add(this.optItem);
            this.tpAttributes.Controls.Add(this.optShop);
            this.tpAttributes.Controls.Add(this.optNPCAvoid);
            this.tpAttributes.Controls.Add(this.optNPCSpawn);
            this.tpAttributes.Controls.Add(this.optKey);
            this.tpAttributes.Controls.Add(this.optDoor);
            this.tpAttributes.Controls.Add(this.optKeyOpen);
            this.tpAttributes.Controls.Add(this.optResource);
            this.tpAttributes.Location = new System.Drawing.Point(4, 22);
            this.tpAttributes.Name = "tpAttributes";
            this.tpAttributes.Padding = new System.Windows.Forms.Padding(3);
            this.tpAttributes.Size = new System.Drawing.Size(491, 468);
            this.tpAttributes.TabIndex = 3;
            this.tpAttributes.Text = "Attributes";
            this.tpAttributes.UseVisualStyleBackColor = true;
            // 
            // optLight
            // 
            this.optLight.AutoSize = true;
            this.optLight.Location = new System.Drawing.Point(237, 85);
            this.optLight.Name = "optLight";
            this.optLight.Size = new System.Drawing.Size(48, 17);
            this.optLight.TabIndex = 18;
            this.optLight.TabStop = true;
            this.optLight.Text = "Light";
            this.optLight.UseVisualStyleBackColor = true;
            // 
            // optCraft
            // 
            this.optCraft.AutoSize = true;
            this.optCraft.Location = new System.Drawing.Point(173, 85);
            this.optCraft.Name = "optCraft";
            this.optCraft.Size = new System.Drawing.Size(47, 17);
            this.optCraft.TabIndex = 17;
            this.optCraft.TabStop = true;
            this.optCraft.Text = "Craft";
            this.optCraft.UseVisualStyleBackColor = true;
            // 
            // tpNpcs
            // 
            this.tpNpcs.Controls.Add(this.fraNpcs);
            this.tpNpcs.Location = new System.Drawing.Point(4, 22);
            this.tpNpcs.Name = "tpNpcs";
            this.tpNpcs.Padding = new System.Windows.Forms.Padding(3);
            this.tpNpcs.Size = new System.Drawing.Size(491, 468);
            this.tpNpcs.TabIndex = 1;
            this.tpNpcs.Text = "Npc\'s";
            this.tpNpcs.UseVisualStyleBackColor = true;
            // 
            // fraNpcs
            // 
            this.fraNpcs.Controls.Add(this.Label18);
            this.fraNpcs.Controls.Add(this.Label17);
            this.fraNpcs.Controls.Add(this.cmbNpcList);
            this.fraNpcs.Controls.Add(this.lstMapNpc);
            this.fraNpcs.Controls.Add(this.ComboBox23);
            this.fraNpcs.Location = new System.Drawing.Point(6, 8);
            this.fraNpcs.Name = "fraNpcs";
            this.fraNpcs.Size = new System.Drawing.Size(479, 426);
            this.fraNpcs.TabIndex = 11;
            this.fraNpcs.TabStop = false;
            this.fraNpcs.Text = "NPCs";
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(258, 29);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(137, 13);
            this.Label18.TabIndex = 72;
            this.Label18.Text = "2, then select the npc here.";
            // 
            // Label17
            // 
            this.Label17.AutoSize = true;
            this.Label17.Location = new System.Drawing.Point(6, 29);
            this.Label17.Name = "Label17";
            this.Label17.Size = new System.Drawing.Size(131, 13);
            this.Label17.TabIndex = 71;
            this.Label17.Text = "1, Select a slot out the list.";
            // 
            // cmbNpcList
            // 
            this.cmbNpcList.FormattingEnabled = true;
            this.cmbNpcList.Location = new System.Drawing.Point(261, 45);
            this.cmbNpcList.Name = "cmbNpcList";
            this.cmbNpcList.Size = new System.Drawing.Size(213, 21);
            this.cmbNpcList.TabIndex = 70;
            this.cmbNpcList.SelectedIndexChanged += new System.EventHandler(this.CmbNpcList_SelectedIndexChanged);
            // 
            // lstMapNpc
            // 
            this.lstMapNpc.FormattingEnabled = true;
            this.lstMapNpc.Location = new System.Drawing.Point(9, 45);
            this.lstMapNpc.Name = "lstMapNpc";
            this.lstMapNpc.Size = new System.Drawing.Size(181, 368);
            this.lstMapNpc.TabIndex = 69;
            this.lstMapNpc.SelectedIndexChanged += new System.EventHandler(this.LstMapNpc_SelectedIndexChanged);
            // 
            // ComboBox23
            // 
            this.ComboBox23.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ComboBox23.FormattingEnabled = true;
            this.ComboBox23.Location = new System.Drawing.Point(341, 469);
            this.ComboBox23.Name = "ComboBox23";
            this.ComboBox23.Size = new System.Drawing.Size(133, 21);
            this.ComboBox23.TabIndex = 68;
            // 
            // tpSettings
            // 
            this.tpSettings.Controls.Add(this.btnSaveSettings);
            this.tpSettings.Controls.Add(this.fraMapSettings);
            this.tpSettings.Controls.Add(this.fraMapLinks);
            this.tpSettings.Controls.Add(this.fraBootSettings);
            this.tpSettings.Controls.Add(this.fraMaxSizes);
            this.tpSettings.Controls.Add(this.GroupBox2);
            this.tpSettings.Controls.Add(this.txtName);
            this.tpSettings.Controls.Add(this.Label6);
            this.tpSettings.Location = new System.Drawing.Point(4, 22);
            this.tpSettings.Name = "tpSettings";
            this.tpSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tpSettings.Size = new System.Drawing.Size(491, 468);
            this.tpSettings.TabIndex = 2;
            this.tpSettings.Text = "Settings";
            this.tpSettings.UseVisualStyleBackColor = true;
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(377, 439);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(108, 23);
            this.btnSaveSettings.TabIndex = 16;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.BtnSaveSettings_Click);
            // 
            // fraMapSettings
            // 
            this.fraMapSettings.Controls.Add(this.chkInstance);
            this.fraMapSettings.Controls.Add(this.Label8);
            this.fraMapSettings.Controls.Add(this.cmbMoral);
            this.fraMapSettings.Location = new System.Drawing.Point(6, 32);
            this.fraMapSettings.Name = "fraMapSettings";
            this.fraMapSettings.Size = new System.Drawing.Size(232, 68);
            this.fraMapSettings.TabIndex = 15;
            this.fraMapSettings.TabStop = false;
            this.fraMapSettings.Text = "Map Settings";
            // 
            // chkInstance
            // 
            this.chkInstance.AutoSize = true;
            this.chkInstance.Location = new System.Drawing.Point(6, 45);
            this.chkInstance.Name = "chkInstance";
            this.chkInstance.Size = new System.Drawing.Size(79, 17);
            this.chkInstance.TabIndex = 40;
            this.chkInstance.Text = "Instanced?";
            this.chkInstance.UseVisualStyleBackColor = true;
            this.chkInstance.CheckedChanged += new System.EventHandler(this.ChkInstance_CheckedChanged);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(3, 15);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(36, 13);
            this.Label8.TabIndex = 38;
            this.Label8.Text = "Moral:";
            // 
            // cmbMoral
            // 
            this.cmbMoral.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMoral.FormattingEnabled = true;
            this.cmbMoral.Items.AddRange(new object[] {
            "None",
            "Safe Zone",
            "Indoors"});
            this.cmbMoral.Location = new System.Drawing.Point(45, 12);
            this.cmbMoral.Name = "cmbMoral";
            this.cmbMoral.Size = new System.Drawing.Size(181, 21);
            this.cmbMoral.TabIndex = 37;
            // 
            // fraMapLinks
            // 
            this.fraMapLinks.Controls.Add(this.txtDown);
            this.fraMapLinks.Controls.Add(this.txtLeft);
            this.fraMapLinks.Controls.Add(this.lblMap);
            this.fraMapLinks.Controls.Add(this.txtRight);
            this.fraMapLinks.Controls.Add(this.txtUp);
            this.fraMapLinks.Location = new System.Drawing.Point(6, 106);
            this.fraMapLinks.Name = "fraMapLinks";
            this.fraMapLinks.Size = new System.Drawing.Size(232, 112);
            this.fraMapLinks.TabIndex = 14;
            this.fraMapLinks.TabStop = false;
            this.fraMapLinks.Text = "Map Links";
            // 
            // txtDown
            // 
            this.txtDown.Location = new System.Drawing.Point(90, 86);
            this.txtDown.Name = "txtDown";
            this.txtDown.Size = new System.Drawing.Size(50, 20);
            this.txtDown.TabIndex = 6;
            this.txtDown.Text = "0";
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(7, 47);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(43, 20);
            this.txtLeft.TabIndex = 5;
            this.txtLeft.Text = "0";
            // 
            // lblMap
            // 
            this.lblMap.AutoSize = true;
            this.lblMap.Location = new System.Drawing.Point(75, 50);
            this.lblMap.Name = "lblMap";
            this.lblMap.Size = new System.Drawing.Size(77, 13);
            this.lblMap.TabIndex = 4;
            this.lblMap.Text = "Current Map: 0";
            // 
            // txtRight
            // 
            this.txtRight.Location = new System.Drawing.Point(177, 47);
            this.txtRight.Name = "txtRight";
            this.txtRight.Size = new System.Drawing.Size(50, 20);
            this.txtRight.TabIndex = 3;
            this.txtRight.Text = "0";
            // 
            // txtUp
            // 
            this.txtUp.Location = new System.Drawing.Point(89, 10);
            this.txtUp.Name = "txtUp";
            this.txtUp.Size = new System.Drawing.Size(50, 20);
            this.txtUp.TabIndex = 1;
            this.txtUp.Text = "0";
            // 
            // fraBootSettings
            // 
            this.fraBootSettings.Controls.Add(this.txtBootMap);
            this.fraBootSettings.Controls.Add(this.Label5);
            this.fraBootSettings.Controls.Add(this.txtBootY);
            this.fraBootSettings.Controls.Add(this.Label3);
            this.fraBootSettings.Controls.Add(this.txtBootX);
            this.fraBootSettings.Controls.Add(this.Label4);
            this.fraBootSettings.Location = new System.Drawing.Point(6, 224);
            this.fraBootSettings.Name = "fraBootSettings";
            this.fraBootSettings.Size = new System.Drawing.Size(232, 91);
            this.fraBootSettings.TabIndex = 13;
            this.fraBootSettings.TabStop = false;
            this.fraBootSettings.Text = "Respawn Settings";
            // 
            // txtBootMap
            // 
            this.txtBootMap.Location = new System.Drawing.Point(176, 11);
            this.txtBootMap.Name = "txtBootMap";
            this.txtBootMap.Size = new System.Drawing.Size(50, 20);
            this.txtBootMap.TabIndex = 5;
            this.txtBootMap.Text = "0";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(6, 16);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(79, 13);
            this.Label5.TabIndex = 4;
            this.Label5.Text = "Respawn Map:";
            // 
            // txtBootY
            // 
            this.txtBootY.Location = new System.Drawing.Point(176, 63);
            this.txtBootY.Name = "txtBootY";
            this.txtBootY.Size = new System.Drawing.Size(50, 20);
            this.txtBootY.TabIndex = 3;
            this.txtBootY.Text = "0";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(6, 65);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(65, 13);
            this.Label3.TabIndex = 2;
            this.Label3.Text = "Respawn Y:";
            // 
            // txtBootX
            // 
            this.txtBootX.Location = new System.Drawing.Point(176, 37);
            this.txtBootX.Name = "txtBootX";
            this.txtBootX.Size = new System.Drawing.Size(50, 20);
            this.txtBootX.TabIndex = 1;
            this.txtBootX.Text = "0";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(6, 37);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(65, 13);
            this.Label4.TabIndex = 0;
            this.Label4.Text = "Respawn X:";
            // 
            // fraMaxSizes
            // 
            this.fraMaxSizes.Controls.Add(this.txtMaxY);
            this.fraMaxSizes.Controls.Add(this.Label2);
            this.fraMaxSizes.Controls.Add(this.txtMaxX);
            this.fraMaxSizes.Controls.Add(this.Label7);
            this.fraMaxSizes.Location = new System.Drawing.Point(244, 224);
            this.fraMaxSizes.Name = "fraMaxSizes";
            this.fraMaxSizes.Size = new System.Drawing.Size(241, 78);
            this.fraMaxSizes.TabIndex = 12;
            this.fraMaxSizes.TabStop = false;
            this.fraMaxSizes.Text = "Map Sizes";
            // 
            // txtMaxY
            // 
            this.txtMaxY.Location = new System.Drawing.Point(124, 42);
            this.txtMaxY.Name = "txtMaxY";
            this.txtMaxY.Size = new System.Drawing.Size(50, 20);
            this.txtMaxY.TabIndex = 3;
            this.txtMaxY.Text = "0";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(6, 45);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(64, 13);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Maximum Y:";
            // 
            // txtMaxX
            // 
            this.txtMaxX.Location = new System.Drawing.Point(124, 16);
            this.txtMaxX.Name = "txtMaxX";
            this.txtMaxX.Size = new System.Drawing.Size(50, 20);
            this.txtMaxX.TabIndex = 1;
            this.txtMaxX.Text = "0";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(6, 19);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(64, 13);
            this.Label7.TabIndex = 0;
            this.Label7.Text = "Maximum X:";
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.btnPreview);
            this.GroupBox2.Controls.Add(this.lstMusic);
            this.GroupBox2.Location = new System.Drawing.Point(244, 3);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(241, 216);
            this.GroupBox2.TabIndex = 11;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Music";
            // 
            // btnPreview
            // 
            this.btnPreview.Image = ((System.Drawing.Image)(resources.GetObject("btnPreview.Image")));
            this.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPreview.Location = new System.Drawing.Point(49, 180);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(139, 29);
            this.btnPreview.TabIndex = 4;
            this.btnPreview.Text = "Preview Music";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.BtnPreview_Click);
            // 
            // lstMusic
            // 
            this.lstMusic.FormattingEnabled = true;
            this.lstMusic.Location = new System.Drawing.Point(6, 19);
            this.lstMusic.Name = "lstMusic";
            this.lstMusic.ScrollAlwaysVisible = true;
            this.lstMusic.Size = new System.Drawing.Size(229, 160);
            this.lstMusic.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(53, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(185, 20);
            this.txtName.TabIndex = 10;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(6, 9);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(38, 13);
            this.Label6.TabIndex = 9;
            this.Label6.Text = "Name:";
            // 
            // tpDirBlock
            // 
            this.tpDirBlock.Controls.Add(this.Label12);
            this.tpDirBlock.Location = new System.Drawing.Point(4, 22);
            this.tpDirBlock.Name = "tpDirBlock";
            this.tpDirBlock.Padding = new System.Windows.Forms.Padding(3);
            this.tpDirBlock.Size = new System.Drawing.Size(491, 468);
            this.tpDirBlock.TabIndex = 4;
            this.tpDirBlock.Text = "Directional Block";
            this.tpDirBlock.UseVisualStyleBackColor = true;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Location = new System.Drawing.Point(22, 23);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(239, 13);
            this.Label12.TabIndex = 0;
            this.Label12.Text = "Just press the arrows to block that side of the tile.";
            // 
            // tpEvents
            // 
            this.tpEvents.Controls.Add(this.lblPasteMode);
            this.tpEvents.Controls.Add(this.lblCopyMode);
            this.tpEvents.Controls.Add(this.btnPasteEvent);
            this.tpEvents.Controls.Add(this.Label16);
            this.tpEvents.Controls.Add(this.btnCopyEvent);
            this.tpEvents.Controls.Add(this.Label15);
            this.tpEvents.Controls.Add(this.Label13);
            this.tpEvents.Location = new System.Drawing.Point(4, 22);
            this.tpEvents.Name = "tpEvents";
            this.tpEvents.Padding = new System.Windows.Forms.Padding(3);
            this.tpEvents.Size = new System.Drawing.Size(491, 468);
            this.tpEvents.TabIndex = 5;
            this.tpEvents.Text = "Events";
            this.tpEvents.UseVisualStyleBackColor = true;
            // 
            // lblPasteMode
            // 
            this.lblPasteMode.AutoSize = true;
            this.lblPasteMode.Location = new System.Drawing.Point(104, 171);
            this.lblPasteMode.Name = "lblPasteMode";
            this.lblPasteMode.Size = new System.Drawing.Size(78, 13);
            this.lblPasteMode.TabIndex = 6;
            this.lblPasteMode.Text = "PasteMode Off";
            // 
            // lblCopyMode
            // 
            this.lblCopyMode.AutoSize = true;
            this.lblCopyMode.Location = new System.Drawing.Point(104, 112);
            this.lblCopyMode.Name = "lblCopyMode";
            this.lblCopyMode.Size = new System.Drawing.Size(75, 13);
            this.lblCopyMode.TabIndex = 5;
            this.lblCopyMode.Text = "CopyMode Off";
            // 
            // btnPasteEvent
            // 
            this.btnPasteEvent.Location = new System.Drawing.Point(23, 166);
            this.btnPasteEvent.Name = "btnPasteEvent";
            this.btnPasteEvent.Size = new System.Drawing.Size(75, 23);
            this.btnPasteEvent.TabIndex = 4;
            this.btnPasteEvent.Text = "Paste Event";
            this.btnPasteEvent.UseVisualStyleBackColor = true;
            this.btnPasteEvent.Click += new System.EventHandler(this.BtnPasteEvent_Click);
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.Location = new System.Drawing.Point(20, 149);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(395, 13);
            this.Label16.TabIndex = 3;
            this.Label16.Text = "To paste a copied Event, press the paste button, then click on the map to place i" +
    "t.";
            // 
            // btnCopyEvent
            // 
            this.btnCopyEvent.Location = new System.Drawing.Point(23, 107);
            this.btnCopyEvent.Name = "btnCopyEvent";
            this.btnCopyEvent.Size = new System.Drawing.Size(75, 23);
            this.btnCopyEvent.TabIndex = 2;
            this.btnCopyEvent.Text = "Copy Event";
            this.btnCopyEvent.UseVisualStyleBackColor = true;
            this.btnCopyEvent.Click += new System.EventHandler(this.BtnCopyEvent_Click);
            // 
            // Label15
            // 
            this.Label15.AutoSize = true;
            this.Label15.Location = new System.Drawing.Point(20, 87);
            this.Label15.Name = "Label15";
            this.Label15.Size = new System.Drawing.Size(310, 13);
            this.Label15.TabIndex = 1;
            this.Label15.Text = "To copy a existing Event, press the copy button, then the event.";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(20, 21);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(239, 13);
            this.Label13.TabIndex = 0;
            this.Label13.Text = "Click on the map where you want to add a event.";
            // 
            // TabPage1
            // 
            this.TabPage1.Controls.Add(this.GroupBox5);
            this.TabPage1.Controls.Add(this.GroupBox4);
            this.TabPage1.Controls.Add(this.GroupBox3);
            this.TabPage1.Controls.Add(this.GroupBox1);
            this.TabPage1.Location = new System.Drawing.Point(4, 22);
            this.TabPage1.Name = "TabPage1";
            this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage1.Size = new System.Drawing.Size(491, 468);
            this.TabPage1.TabIndex = 6;
            this.TabPage1.Text = "Map Effects";
            this.TabPage1.UseVisualStyleBackColor = true;
            // 
            // GroupBox5
            // 
            this.GroupBox5.Controls.Add(this.Label20);
            this.GroupBox5.Controls.Add(this.cmbParallax);
            this.GroupBox5.Location = new System.Drawing.Point(253, 225);
            this.GroupBox5.Name = "GroupBox5";
            this.GroupBox5.Size = new System.Drawing.Size(238, 53);
            this.GroupBox5.TabIndex = 21;
            this.GroupBox5.TabStop = false;
            this.GroupBox5.Text = "Map Parallax";
            // 
            // Label20
            // 
            this.Label20.AutoSize = true;
            this.Label20.Location = new System.Drawing.Point(6, 22);
            this.Label20.Name = "Label20";
            this.Label20.Size = new System.Drawing.Size(47, 13);
            this.Label20.TabIndex = 1;
            this.Label20.Text = "Parallax:";
            // 
            // cmbParallax
            // 
            this.cmbParallax.FormattingEnabled = true;
            this.cmbParallax.Location = new System.Drawing.Point(70, 19);
            this.cmbParallax.Name = "cmbParallax";
            this.cmbParallax.Size = new System.Drawing.Size(161, 21);
            this.cmbParallax.TabIndex = 0;
            this.cmbParallax.SelectedIndexChanged += new System.EventHandler(this.CmbParallax_SelectedIndexChanged);
            // 
            // GroupBox4
            // 
            this.GroupBox4.Controls.Add(this.Label19);
            this.GroupBox4.Controls.Add(this.cmbPanorama);
            this.GroupBox4.Location = new System.Drawing.Point(253, 166);
            this.GroupBox4.Name = "GroupBox4";
            this.GroupBox4.Size = new System.Drawing.Size(236, 53);
            this.GroupBox4.TabIndex = 20;
            this.GroupBox4.TabStop = false;
            this.GroupBox4.Text = "Map Panorama";
            // 
            // Label19
            // 
            this.Label19.AutoSize = true;
            this.Label19.Location = new System.Drawing.Point(6, 22);
            this.Label19.Name = "Label19";
            this.Label19.Size = new System.Drawing.Size(58, 13);
            this.Label19.TabIndex = 1;
            this.Label19.Text = "Panorama:";
            // 
            // cmbPanorama
            // 
            this.cmbPanorama.FormattingEnabled = true;
            this.cmbPanorama.Location = new System.Drawing.Point(70, 19);
            this.cmbPanorama.Name = "cmbPanorama";
            this.cmbPanorama.Size = new System.Drawing.Size(161, 21);
            this.cmbPanorama.TabIndex = 0;
            this.cmbPanorama.SelectedIndexChanged += new System.EventHandler(this.CmbPanorama_SelectedIndexChanged);
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.chkUseTint);
            this.GroupBox3.Controls.Add(this.lblMapAlpha);
            this.GroupBox3.Controls.Add(this.lblMapBlue);
            this.GroupBox3.Controls.Add(this.lblMapGreen);
            this.GroupBox3.Controls.Add(this.lblMapRed);
            this.GroupBox3.Controls.Add(this.scrlMapAlpha);
            this.GroupBox3.Controls.Add(this.scrlMapBlue);
            this.GroupBox3.Controls.Add(this.scrlMapGreen);
            this.GroupBox3.Controls.Add(this.scrlMapRed);
            this.GroupBox3.Location = new System.Drawing.Point(253, 6);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(236, 154);
            this.GroupBox3.TabIndex = 19;
            this.GroupBox3.TabStop = false;
            this.GroupBox3.Text = "Map Tint";
            // 
            // chkUseTint
            // 
            this.chkUseTint.AutoSize = true;
            this.chkUseTint.Location = new System.Drawing.Point(6, 19);
            this.chkUseTint.Name = "chkUseTint";
            this.chkUseTint.Size = new System.Drawing.Size(93, 17);
            this.chkUseTint.TabIndex = 18;
            this.chkUseTint.Text = "Use MapTint?";
            this.chkUseTint.UseVisualStyleBackColor = true;
            this.chkUseTint.CheckedChanged += new System.EventHandler(this.ChkUseTint_CheckedChanged);
            // 
            // lblMapAlpha
            // 
            this.lblMapAlpha.AutoSize = true;
            this.lblMapAlpha.Location = new System.Drawing.Point(8, 96);
            this.lblMapAlpha.Name = "lblMapAlpha";
            this.lblMapAlpha.Size = new System.Drawing.Size(46, 13);
            this.lblMapAlpha.TabIndex = 17;
            this.lblMapAlpha.Text = "Alpha: 0";
            // 
            // lblMapBlue
            // 
            this.lblMapBlue.AutoSize = true;
            this.lblMapBlue.Location = new System.Drawing.Point(8, 77);
            this.lblMapBlue.Name = "lblMapBlue";
            this.lblMapBlue.Size = new System.Drawing.Size(40, 13);
            this.lblMapBlue.TabIndex = 16;
            this.lblMapBlue.Text = "Blue: 0";
            // 
            // lblMapGreen
            // 
            this.lblMapGreen.AutoSize = true;
            this.lblMapGreen.Location = new System.Drawing.Point(8, 58);
            this.lblMapGreen.Name = "lblMapGreen";
            this.lblMapGreen.Size = new System.Drawing.Size(48, 13);
            this.lblMapGreen.TabIndex = 15;
            this.lblMapGreen.Text = "Green: 0";
            // 
            // lblMapRed
            // 
            this.lblMapRed.AutoSize = true;
            this.lblMapRed.Location = new System.Drawing.Point(6, 39);
            this.lblMapRed.Name = "lblMapRed";
            this.lblMapRed.Size = new System.Drawing.Size(39, 13);
            this.lblMapRed.TabIndex = 14;
            this.lblMapRed.Text = "Red: 0";
            // 
            // scrlMapAlpha
            // 
            this.scrlMapAlpha.LargeChange = 1;
            this.scrlMapAlpha.Location = new System.Drawing.Point(86, 94);
            this.scrlMapAlpha.Maximum = 255;
            this.scrlMapAlpha.Name = "scrlMapAlpha";
            this.scrlMapAlpha.Size = new System.Drawing.Size(145, 17);
            this.scrlMapAlpha.TabIndex = 13;
            this.scrlMapAlpha.ValueChanged += new System.EventHandler(this.ScrlMapAlpha_Scroll);
            // 
            // scrlMapBlue
            // 
            this.scrlMapBlue.LargeChange = 1;
            this.scrlMapBlue.Location = new System.Drawing.Point(86, 75);
            this.scrlMapBlue.Maximum = 255;
            this.scrlMapBlue.Name = "scrlMapBlue";
            this.scrlMapBlue.Size = new System.Drawing.Size(145, 17);
            this.scrlMapBlue.TabIndex = 12;
            this.scrlMapBlue.ValueChanged += new System.EventHandler(this.ScrlMapBlue_Scroll);
            // 
            // scrlMapGreen
            // 
            this.scrlMapGreen.LargeChange = 1;
            this.scrlMapGreen.Location = new System.Drawing.Point(86, 56);
            this.scrlMapGreen.Maximum = 255;
            this.scrlMapGreen.Name = "scrlMapGreen";
            this.scrlMapGreen.Size = new System.Drawing.Size(145, 17);
            this.scrlMapGreen.TabIndex = 11;
            this.scrlMapGreen.ValueChanged += new System.EventHandler(this.ScrlMapGreen_Scroll);
            // 
            // scrlMapRed
            // 
            this.scrlMapRed.LargeChange = 1;
            this.scrlMapRed.Location = new System.Drawing.Point(86, 37);
            this.scrlMapRed.Maximum = 255;
            this.scrlMapRed.Name = "scrlMapRed";
            this.scrlMapRed.Size = new System.Drawing.Size(145, 17);
            this.scrlMapRed.TabIndex = 10;
            this.scrlMapRed.ValueChanged += new System.EventHandler(this.ScrlMapRed_Scroll);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.scrlBrightness);
            this.GroupBox1.Controls.Add(this.lblBrightness);
            this.GroupBox1.Controls.Add(this.label21);
            this.GroupBox1.Controls.Add(this.scrlFogAlpha);
            this.GroupBox1.Controls.Add(this.lblFogAlpha);
            this.GroupBox1.Controls.Add(this.scrlFogSpeed);
            this.GroupBox1.Controls.Add(this.lblFogSpeed);
            this.GroupBox1.Controls.Add(this.scrlIntensity);
            this.GroupBox1.Controls.Add(this.lblIntensity);
            this.GroupBox1.Controls.Add(this.scrlFog);
            this.GroupBox1.Controls.Add(this.lblFogIndex);
            this.GroupBox1.Controls.Add(this.Label14);
            this.GroupBox1.Controls.Add(this.cmbWeather);
            this.GroupBox1.Location = new System.Drawing.Point(6, 6);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(241, 213);
            this.GroupBox1.TabIndex = 18;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Map Weather";
            // 
            // scrlFogAlpha
            // 
            this.scrlFogAlpha.LargeChange = 1;
            this.scrlFogAlpha.Location = new System.Drawing.Point(90, 124);
            this.scrlFogAlpha.Maximum = 255;
            this.scrlFogAlpha.Name = "scrlFogAlpha";
            this.scrlFogAlpha.Size = new System.Drawing.Size(145, 17);
            this.scrlFogAlpha.TabIndex = 9;
            this.scrlFogAlpha.ValueChanged += new System.EventHandler(this.ScrlFogAlpha_Scroll);
            // 
            // lblFogAlpha
            // 
            this.lblFogAlpha.AutoSize = true;
            this.lblFogAlpha.Location = new System.Drawing.Point(6, 126);
            this.lblFogAlpha.Name = "lblFogAlpha";
            this.lblFogAlpha.Size = new System.Drawing.Size(79, 13);
            this.lblFogAlpha.TabIndex = 8;
            this.lblFogAlpha.Text = "Fog Alpha: 255";
            // 
            // scrlFogSpeed
            // 
            this.scrlFogSpeed.LargeChange = 1;
            this.scrlFogSpeed.Location = new System.Drawing.Point(90, 101);
            this.scrlFogSpeed.Name = "scrlFogSpeed";
            this.scrlFogSpeed.Size = new System.Drawing.Size(145, 17);
            this.scrlFogSpeed.TabIndex = 7;
            this.scrlFogSpeed.ValueChanged += new System.EventHandler(this.ScrlFogSpeed_Scroll);
            // 
            // lblFogSpeed
            // 
            this.lblFogSpeed.AutoSize = true;
            this.lblFogSpeed.Location = new System.Drawing.Point(6, 105);
            this.lblFogSpeed.Name = "lblFogSpeed";
            this.lblFogSpeed.Size = new System.Drawing.Size(80, 13);
            this.lblFogSpeed.TabIndex = 6;
            this.lblFogSpeed.Text = "FogSpeed: 100";
            // 
            // scrlIntensity
            // 
            this.scrlIntensity.LargeChange = 1;
            this.scrlIntensity.Location = new System.Drawing.Point(90, 51);
            this.scrlIntensity.Name = "scrlIntensity";
            this.scrlIntensity.Size = new System.Drawing.Size(145, 17);
            this.scrlIntensity.TabIndex = 5;
            this.scrlIntensity.ValueChanged += new System.EventHandler(this.ScrlIntensity_Scroll);
            // 
            // lblIntensity
            // 
            this.lblIntensity.AutoSize = true;
            this.lblIntensity.Location = new System.Drawing.Point(6, 53);
            this.lblIntensity.Name = "lblIntensity";
            this.lblIntensity.Size = new System.Drawing.Size(70, 13);
            this.lblIntensity.TabIndex = 4;
            this.lblIntensity.Text = "Intensity: 100";
            // 
            // scrlFog
            // 
            this.scrlFog.LargeChange = 1;
            this.scrlFog.Location = new System.Drawing.Point(90, 81);
            this.scrlFog.Name = "scrlFog";
            this.scrlFog.Size = new System.Drawing.Size(145, 17);
            this.scrlFog.TabIndex = 3;
            this.scrlFog.ValueChanged += new System.EventHandler(this.ScrlFog_Scroll);
            // 
            // lblFogIndex
            // 
            this.lblFogIndex.AutoSize = true;
            this.lblFogIndex.Location = new System.Drawing.Point(6, 82);
            this.lblFogIndex.Name = "lblFogIndex";
            this.lblFogIndex.Size = new System.Drawing.Size(37, 13);
            this.lblFogIndex.TabIndex = 2;
            this.lblFogIndex.Text = "Fog: 1";
            // 
            // Label14
            // 
            this.Label14.AutoSize = true;
            this.Label14.Location = new System.Drawing.Point(6, 25);
            this.Label14.Name = "Label14";
            this.Label14.Size = new System.Drawing.Size(78, 13);
            this.Label14.TabIndex = 1;
            this.Label14.Text = "Weather Type:";
            // 
            // cmbWeather
            // 
            this.cmbWeather.FormattingEnabled = true;
            this.cmbWeather.Items.AddRange(new object[] {
            "None",
            "Rain",
            "Snow",
            "Hail",
            "Sand Storm",
            "Storm",
            "Fog"});
            this.cmbWeather.Location = new System.Drawing.Point(90, 22);
            this.cmbWeather.Name = "cmbWeather";
            this.cmbWeather.Size = new System.Drawing.Size(145, 21);
            this.cmbWeather.TabIndex = 0;
            this.cmbWeather.SelectedIndexChanged += new System.EventHandler(this.CmbWeather_SelectedIndexChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label21.Location = new System.Drawing.Point(32, 160);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(167, 9);
            this.label21.TabIndex = 10;
            this.label21.Text = "A Value above 0 Overwrites the Day/Night cycle";
            // 
            // lblBrightness
            // 
            this.lblBrightness.AutoSize = true;
            this.lblBrightness.Location = new System.Drawing.Point(6, 179);
            this.lblBrightness.Name = "lblBrightness";
            this.lblBrightness.Size = new System.Drawing.Size(80, 13);
            this.lblBrightness.TabIndex = 11;
            this.lblBrightness.Text = "Brightness: 255";
            // 
            // scrlBrightness
            // 
            this.scrlBrightness.LargeChange = 1;
            this.scrlBrightness.Location = new System.Drawing.Point(88, 178);
            this.scrlBrightness.Maximum = 255;
            this.scrlBrightness.Name = "scrlBrightness";
            this.scrlBrightness.Size = new System.Drawing.Size(145, 17);
            this.scrlBrightness.TabIndex = 12;
            this.scrlBrightness.ValueChanged += new System.EventHandler(this.ScrlFBrightness_Scroll);
            // 
            // FrmEditor_MapEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 527);
            this.ControlBox = false;
            this.Controls.Add(this.tabpages);
            this.Controls.Add(this.ToolStrip);
            this.Controls.Add(this.pnlAttributes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FrmEditor_MapEditor";
            this.Text = "Map Editor";
            this.Load += new System.EventHandler(this.FrmEditor_Map_Load);
            this.pnlBack.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBackSelect)).EndInit();
            this.pnlAttributes.ResumeLayout(false);
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
            this.ToolStrip.ResumeLayout(false);
            this.ToolStrip.PerformLayout();
            this.tabpages.ResumeLayout(false);
            this.tpTiles.ResumeLayout(false);
            this.tpTiles.PerformLayout();
            this.tpAttributes.ResumeLayout(false);
            this.tpAttributes.PerformLayout();
            this.tpNpcs.ResumeLayout(false);
            this.fraNpcs.ResumeLayout(false);
            this.fraNpcs.PerformLayout();
            this.tpSettings.ResumeLayout(false);
            this.tpSettings.PerformLayout();
            this.fraMapSettings.ResumeLayout(false);
            this.fraMapSettings.PerformLayout();
            this.fraMapLinks.ResumeLayout(false);
            this.fraMapLinks.PerformLayout();
            this.fraBootSettings.ResumeLayout(false);
            this.fraBootSettings.PerformLayout();
            this.fraMaxSizes.ResumeLayout(false);
            this.fraMaxSizes.PerformLayout();
            this.GroupBox2.ResumeLayout(false);
            this.tpDirBlock.ResumeLayout(false);
            this.tpDirBlock.PerformLayout();
            this.tpEvents.ResumeLayout(false);
            this.tpEvents.PerformLayout();
            this.TabPage1.ResumeLayout(false);
            this.GroupBox5.ResumeLayout(false);
            this.GroupBox5.PerformLayout();
            this.GroupBox4.ResumeLayout(false);
            this.GroupBox4.PerformLayout();
            this.GroupBox3.ResumeLayout(false);
            this.GroupBox3.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.HScrollBar scrlPictureX;
		internal System.Windows.Forms.VScrollBar scrlPictureY;
		internal System.Windows.Forms.Panel pnlBack;
		internal System.Windows.Forms.RadioButton optTrap;
		internal System.Windows.Forms.RadioButton optHeal;
		internal System.Windows.Forms.RadioButton optBank;
		internal System.Windows.Forms.RadioButton optShop;
		internal System.Windows.Forms.RadioButton optNPCSpawn;
		internal System.Windows.Forms.RadioButton optDoor;
		internal System.Windows.Forms.RadioButton optResource;
		internal System.Windows.Forms.RadioButton optKeyOpen;
		internal System.Windows.Forms.RadioButton optKey;
		internal System.Windows.Forms.RadioButton optNPCAvoid;
		internal System.Windows.Forms.RadioButton optItem;
		internal System.Windows.Forms.RadioButton optWarp;
		internal System.Windows.Forms.RadioButton optBlocked;
		public System.Windows.Forms.PictureBox picBackSelect;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Button btnClearAttribute;
		internal System.Windows.Forms.Panel pnlAttributes;
		internal System.Windows.Forms.GroupBox fraMapWarp;
		internal System.Windows.Forms.Label lblMapWarpY;
		internal System.Windows.Forms.Label lblMapWarpX;
		internal System.Windows.Forms.Label lblMapWarpMap;
		internal System.Windows.Forms.HScrollBar scrlMapWarpY;
		internal System.Windows.Forms.HScrollBar scrlMapWarpX;
		internal System.Windows.Forms.HScrollBar scrlMapWarpMap;
		internal System.Windows.Forms.Button btnMapWarp;
		internal System.Windows.Forms.GroupBox fraMapItem;
		internal System.Windows.Forms.Button btnMapItem;
		internal System.Windows.Forms.HScrollBar scrlMapItemValue;
		internal System.Windows.Forms.HScrollBar scrlMapItem;
		internal System.Windows.Forms.Label lblMapItem;
		internal System.Windows.Forms.PictureBox picMapItem;
		internal System.Windows.Forms.GroupBox fraMapKey;
		internal System.Windows.Forms.CheckBox chkMapKey;
		internal System.Windows.Forms.PictureBox picMapKey;
		internal System.Windows.Forms.Button btnMapKey;
		internal System.Windows.Forms.HScrollBar scrlMapKey;
		internal System.Windows.Forms.Label lblMapKey;
		internal System.Windows.Forms.GroupBox fraKeyOpen;
		internal System.Windows.Forms.Button btnMapKeyOpen;
		internal System.Windows.Forms.HScrollBar scrlKeyX;
		internal System.Windows.Forms.Label lblKeyX;
		internal System.Windows.Forms.HScrollBar scrlKeyY;
		internal System.Windows.Forms.Label lblKeyY;
		internal System.Windows.Forms.GroupBox fraResource;
		internal System.Windows.Forms.Button btnResourceOk;
		internal System.Windows.Forms.HScrollBar scrlResource;
		internal System.Windows.Forms.Label lblResource;
		internal System.Windows.Forms.GroupBox fraNpcSpawn;
		internal System.Windows.Forms.Button btnNpcSpawn;
		internal System.Windows.Forms.HScrollBar scrlNpcDir;
		internal System.Windows.Forms.Label lblNpcDir;
		internal System.Windows.Forms.ComboBox lstNpc;
		internal System.Windows.Forms.GroupBox fraShop;
		internal System.Windows.Forms.ComboBox cmbShop;
		internal System.Windows.Forms.Button btnShop;
		internal System.Windows.Forms.GroupBox fraHeal;
		internal System.Windows.Forms.Label lblHeal;
		internal System.Windows.Forms.ComboBox cmbHeal;
		internal System.Windows.Forms.Button btnHeal;
		internal System.Windows.Forms.HScrollBar scrlHeal;
		internal System.Windows.Forms.GroupBox fraTrap;
		internal System.Windows.Forms.Button btnTrap;
		internal System.Windows.Forms.HScrollBar scrlTrap;
		internal System.Windows.Forms.Label lblTrap;
		internal System.Windows.Forms.RadioButton optHouse;
		internal System.Windows.Forms.GroupBox fraBuyHouse;
		internal System.Windows.Forms.Button btnHouseTileOk;
		internal System.Windows.Forms.HScrollBar scrlBuyHouse;
		internal System.Windows.Forms.Label lblHouseName;
		internal System.Windows.Forms.ToolStrip ToolStrip;
		internal System.Windows.Forms.ToolStripButton tsbSave;
		internal System.Windows.Forms.ToolStripButton tsbDiscard;
		internal System.Windows.Forms.TabControl tabpages;
		internal System.Windows.Forms.TabPage tpTiles;
		internal System.Windows.Forms.TabPage tpNpcs;
		internal System.Windows.Forms.TabPage tpSettings;
		internal System.Windows.Forms.GroupBox fraNpcs;
		internal System.Windows.Forms.ComboBox ComboBox23;
		internal System.Windows.Forms.TextBox txtName;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.GroupBox fraMapLinks;
		internal System.Windows.Forms.TextBox txtDown;
		internal System.Windows.Forms.TextBox txtLeft;
		internal System.Windows.Forms.Label lblMap;
		internal System.Windows.Forms.TextBox txtRight;
		internal System.Windows.Forms.TextBox txtUp;
		internal System.Windows.Forms.GroupBox fraBootSettings;
		internal System.Windows.Forms.TextBox txtBootMap;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox txtBootY;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox txtBootX;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.GroupBox fraMaxSizes;
		internal System.Windows.Forms.TextBox txtMaxY;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.TextBox txtMaxX;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.ListBox lstMusic;
		internal System.Windows.Forms.GroupBox fraMapSettings;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.ComboBox cmbMoral;
		internal System.Windows.Forms.Button btnSaveSettings;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;
		internal System.Windows.Forms.ComboBox cmbNpcList;
		internal System.Windows.Forms.ListBox lstMapNpc;
		internal System.Windows.Forms.TabPage tpAttributes;
		internal System.Windows.Forms.ComboBox cmbTileSets;
		internal System.Windows.Forms.ComboBox cmbAutoTile;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.ComboBox cmbLayers;
		internal System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.TabPage tpDirBlock;
		internal System.Windows.Forms.TabPage tpEvents;
		internal System.Windows.Forms.Label Label12;
		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.ToolStripButton tsbMapGrid;
		internal System.Windows.Forms.Button btnPreview;
		internal System.Windows.Forms.RadioButton optCraft;
		internal System.Windows.Forms.ToolStripButton tsbFill;
		internal System.Windows.Forms.ToolStripButton tsbClear;
		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;
		internal System.Windows.Forms.CheckBox chkInstance;
		internal System.Windows.Forms.RadioButton optLight;
		internal System.Windows.Forms.Button btnPasteEvent;
		internal System.Windows.Forms.Label Label16;
		internal System.Windows.Forms.Button btnCopyEvent;
		internal System.Windows.Forms.Label Label15;
		internal System.Windows.Forms.Label lblPasteMode;
		internal System.Windows.Forms.Label lblCopyMode;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.GroupBox GroupBox3;
		internal System.Windows.Forms.CheckBox chkUseTint;
		internal System.Windows.Forms.Label lblMapAlpha;
		internal System.Windows.Forms.Label lblMapBlue;
		internal System.Windows.Forms.Label lblMapGreen;
		internal System.Windows.Forms.Label lblMapRed;
		internal System.Windows.Forms.HScrollBar scrlMapAlpha;
		internal System.Windows.Forms.HScrollBar scrlMapBlue;
		internal System.Windows.Forms.HScrollBar scrlMapGreen;
		internal System.Windows.Forms.HScrollBar scrlMapRed;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.HScrollBar scrlFogAlpha;
		internal System.Windows.Forms.Label lblFogAlpha;
		internal System.Windows.Forms.HScrollBar scrlFogSpeed;
		internal System.Windows.Forms.Label lblFogSpeed;
		internal System.Windows.Forms.HScrollBar scrlIntensity;
		internal System.Windows.Forms.Label lblIntensity;
		internal System.Windows.Forms.HScrollBar scrlFog;
		internal System.Windows.Forms.Label lblFogIndex;
		internal System.Windows.Forms.Label Label14;
		internal System.Windows.Forms.ComboBox cmbWeather;
		internal System.Windows.Forms.Label Label18;
		internal System.Windows.Forms.Label Label17;
		internal System.Windows.Forms.GroupBox GroupBox5;
		internal System.Windows.Forms.Label Label20;
		internal System.Windows.Forms.ComboBox cmbParallax;
		internal System.Windows.Forms.GroupBox GroupBox4;
		internal System.Windows.Forms.Label Label19;
		internal System.Windows.Forms.ComboBox cmbPanorama;
        internal System.Windows.Forms.HScrollBar scrlBrightness;
        internal System.Windows.Forms.Label lblBrightness;
        internal System.Windows.Forms.Label label21;
    }
	
}
