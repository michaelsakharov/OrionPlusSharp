
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
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class FrmAutoMapper : System.Windows.Forms.Form
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
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAutoMapper));
			this.pnlResources = new System.Windows.Forms.Panel();
			base.Load += new System.EventHandler(FrmAutoMapper_Load);
			this.btnAddResource = new DarkUI.Controls.DarkButton();
			this.btnAddResource.Click += new System.EventHandler(this.BtnAdd_Click);
			this.btnRemoveResource = new DarkUI.Controls.DarkButton();
			this.btnRemoveResource.Click += new System.EventHandler(this.BtnRemove_Click);
			this.btnUpdateResource = new DarkUI.Controls.DarkButton();
			this.btnUpdateResource.Click += new System.EventHandler(this.BtnUpdate_Click);
			this.btnSaveResource = new DarkUI.Controls.DarkButton();
			this.btnSaveResource.Click += new System.EventHandler(this.BtnSaveResource_Click);
			this.btnCloseResource = new DarkUI.Controls.DarkButton();
			this.btnCloseResource.Click += new System.EventHandler(this.BtnCloseResource_Click);
			this.txtResource = new DarkUI.Controls.DarkTextBox();
			this.DarkLabel8 = new DarkUI.Controls.DarkLabel();
			this.lstResources = new System.Windows.Forms.ListBox();
			this.lstResources.SelectedIndexChanged += new System.EventHandler(this.LstResources_SelectedIndexChanged);
			this.pnlTileConfig = new System.Windows.Forms.Panel();
			this.btnTileSetSave = new DarkUI.Controls.DarkButton();
			this.btnTileSetSave.Click += new System.EventHandler(this.BtnTileSetSave_Click);
			this.btnTileSetClose = new DarkUI.Controls.DarkButton();
			this.btnTileSetClose.Click += new System.EventHandler(this.BtnTileSetClose_Click);
			this.DarkLabel10 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel9 = new DarkUI.Controls.DarkLabel();
			this.cmbLayer = new DarkUI.Controls.DarkComboBox();
			this.cmbLayer.SelectedIndexChanged += new System.EventHandler(this.CmbLayer_SelectedIndexChanged);
			this.cmbPrefab = new DarkUI.Controls.DarkComboBox();
			this.cmbPrefab.SelectedIndexChanged += new System.EventHandler(this.CmbPrefab_SelectedIndexChanged);
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.txtAutotile = new DarkUI.Controls.DarkTextBox();
			this.txtTileY = new DarkUI.Controls.DarkTextBox();
			this.txtTileX = new DarkUI.Controls.DarkTextBox();
			this.txtTileset = new DarkUI.Controls.DarkTextBox();
			this.chkBlocked = new DarkUI.Controls.DarkCheckBox();
			this.Label14 = new System.Windows.Forms.Label();
			this.Label13 = new System.Windows.Forms.Label();
			this.Label12 = new System.Windows.Forms.Label();
			this.Label11 = new System.Windows.Forms.Label();
			this.DarkMenu = new DarkUI.Controls.DarkMenuStrip();
			this.ConfigurationsToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.TilesetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.TilesetsToolStripMenuItem.Click += new System.EventHandler(this.TilesetsToolStripMenuItem2_Click);
			this.ResourcesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.ResourcesToolStripMenuItem.Click += new System.EventHandler(this.ResourcesToolStripMenuItem2_Click);
			this.GenerateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.PathsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.RiversToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.MountainsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.OverGrassToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.ResourcesToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.DetailsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.DarkLabel1 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel2 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel3 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel4 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel5 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel6 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel7 = new DarkUI.Controls.DarkLabel();
			this.txtMapStart = new DarkUI.Controls.DarkTextBox();
			this.txtMapSize = new DarkUI.Controls.DarkTextBox();
			this.txtMapX = new DarkUI.Controls.DarkTextBox();
			this.txtMapY = new DarkUI.Controls.DarkTextBox();
			this.txtSandBorder = new DarkUI.Controls.DarkTextBox();
			this.txtDetail = new DarkUI.Controls.DarkTextBox();
			this.txtResourceFreq = new DarkUI.Controls.DarkTextBox();
			this.btnStart = new DarkUI.Controls.DarkButton();
			this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
			this.pnlResources.SuspendLayout();
			this.pnlTileConfig.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.DarkMenu.SuspendLayout();
			this.SuspendLayout();
			//
			//pnlResources
			//
			this.pnlResources.Controls.Add(this.btnAddResource);
			this.pnlResources.Controls.Add(this.btnRemoveResource);
			this.pnlResources.Controls.Add(this.btnUpdateResource);
			this.pnlResources.Controls.Add(this.btnSaveResource);
			this.pnlResources.Controls.Add(this.btnCloseResource);
			this.pnlResources.Controls.Add(this.txtResource);
			this.pnlResources.Controls.Add(this.DarkLabel8);
			this.pnlResources.Controls.Add(this.lstResources);
			this.pnlResources.Location = new System.Drawing.Point(394, 20);
			this.pnlResources.Name = "pnlResources";
			this.pnlResources.Size = new System.Drawing.Size(385, 267);
			this.pnlResources.TabIndex = 24;
			this.pnlResources.Visible = false;
			//
			//btnAddResource
			//
			this.btnAddResource.Location = new System.Drawing.Point(254, 154);
			this.btnAddResource.Name = "btnAddResource";
			this.btnAddResource.Padding = new System.Windows.Forms.Padding(5);
			this.btnAddResource.Size = new System.Drawing.Size(122, 23);
			this.btnAddResource.TabIndex = 14;
			this.btnAddResource.Text = "Add Resources";
			//
			//btnRemoveResource
			//
			this.btnRemoveResource.Location = new System.Drawing.Point(254, 183);
			this.btnRemoveResource.Name = "btnRemoveResource";
			this.btnRemoveResource.Padding = new System.Windows.Forms.Padding(5);
			this.btnRemoveResource.Size = new System.Drawing.Size(122, 23);
			this.btnRemoveResource.TabIndex = 13;
			this.btnRemoveResource.Text = "Remove Resources";
			//
			//btnUpdateResource
			//
			this.btnUpdateResource.Location = new System.Drawing.Point(254, 212);
			this.btnUpdateResource.Name = "btnUpdateResource";
			this.btnUpdateResource.Padding = new System.Windows.Forms.Padding(5);
			this.btnUpdateResource.Size = new System.Drawing.Size(122, 23);
			this.btnUpdateResource.TabIndex = 12;
			this.btnUpdateResource.Text = "Update Resources";
			//
			//btnSaveResource
			//
			this.btnSaveResource.Location = new System.Drawing.Point(254, 241);
			this.btnSaveResource.Name = "btnSaveResource";
			this.btnSaveResource.Padding = new System.Windows.Forms.Padding(5);
			this.btnSaveResource.Size = new System.Drawing.Size(122, 23);
			this.btnSaveResource.TabIndex = 11;
			this.btnSaveResource.Text = "Save";
			//
			//btnCloseResource
			//
			this.btnCloseResource.Location = new System.Drawing.Point(3, 240);
			this.btnCloseResource.Name = "btnCloseResource";
			this.btnCloseResource.Padding = new System.Windows.Forms.Padding(5);
			this.btnCloseResource.Size = new System.Drawing.Size(122, 23);
			this.btnCloseResource.TabIndex = 10;
			this.btnCloseResource.Text = "Close";
			//
			//txtResource
			//
			this.txtResource.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtResource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtResource.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtResource.Location = new System.Drawing.Point(109, 156);
			this.txtResource.Name = "txtResource";
			this.txtResource.Size = new System.Drawing.Size(100, 20);
			this.txtResource.TabIndex = 9;
			//
			//DarkLabel8
			//
			this.DarkLabel8.AutoSize = true;
			this.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel8.Location = new System.Drawing.Point(7, 156);
			this.DarkLabel8.Name = "DarkLabel8";
			this.DarkLabel8.Size = new System.Drawing.Size(96, 13);
			this.DarkLabel8.TabIndex = 8;
			this.DarkLabel8.Text = "Resource Number:";
			//
			//lstResources
			//
			this.lstResources.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.lstResources.ForeColor = System.Drawing.Color.Gainsboro;
			this.lstResources.FormattingEnabled = true;
			this.lstResources.Location = new System.Drawing.Point(3, 3);
			this.lstResources.Name = "lstResources";
			this.lstResources.Size = new System.Drawing.Size(373, 147);
			this.lstResources.TabIndex = 0;
			//
			//pnlTileConfig
			//
			this.pnlTileConfig.Controls.Add(this.btnTileSetSave);
			this.pnlTileConfig.Controls.Add(this.btnTileSetClose);
			this.pnlTileConfig.Controls.Add(this.DarkLabel10);
			this.pnlTileConfig.Controls.Add(this.DarkLabel9);
			this.pnlTileConfig.Controls.Add(this.cmbLayer);
			this.pnlTileConfig.Controls.Add(this.cmbPrefab);
			this.pnlTileConfig.Controls.Add(this.GroupBox1);
			this.pnlTileConfig.Location = new System.Drawing.Point(803, 23);
			this.pnlTileConfig.Name = "pnlTileConfig";
			this.pnlTileConfig.Size = new System.Drawing.Size(381, 270);
			this.pnlTileConfig.TabIndex = 25;
			this.pnlTileConfig.Visible = false;
			//
			//btnTileSetSave
			//
			this.btnTileSetSave.Location = new System.Drawing.Point(298, 240);
			this.btnTileSetSave.Name = "btnTileSetSave";
			this.btnTileSetSave.Padding = new System.Windows.Forms.Padding(5);
			this.btnTileSetSave.Size = new System.Drawing.Size(75, 23);
			this.btnTileSetSave.TabIndex = 45;
			this.btnTileSetSave.Text = "Save";
			//
			//btnTileSetClose
			//
			this.btnTileSetClose.Location = new System.Drawing.Point(7, 241);
			this.btnTileSetClose.Name = "btnTileSetClose";
			this.btnTileSetClose.Padding = new System.Windows.Forms.Padding(5);
			this.btnTileSetClose.Size = new System.Drawing.Size(75, 23);
			this.btnTileSetClose.TabIndex = 44;
			this.btnTileSetClose.Text = "Close";
			//
			//DarkLabel10
			//
			this.DarkLabel10.AutoSize = true;
			this.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel10.Location = new System.Drawing.Point(7, 37);
			this.DarkLabel10.Name = "DarkLabel10";
			this.DarkLabel10.Size = new System.Drawing.Size(97, 13);
			this.DarkLabel10.TabIndex = 43;
			this.DarkLabel10.Text = "Choose The Layer:";
			//
			//DarkLabel9
			//
			this.DarkLabel9.AutoSize = true;
			this.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel9.Location = new System.Drawing.Point(7, 10);
			this.DarkLabel9.Name = "DarkLabel9";
			this.DarkLabel9.Size = new System.Drawing.Size(102, 13);
			this.DarkLabel9.TabIndex = 43;
			this.DarkLabel9.Text = "Choose The Prefab:";
			//
			//cmbLayer
			//
			this.cmbLayer.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.cmbLayer.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbLayer.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbLayer.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbLayer.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbLayer.ButtonIcon"));
			this.cmbLayer.DrawDropdownHoverOutline = false;
			this.cmbLayer.DrawFocusRectangle = false;
			this.cmbLayer.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbLayer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbLayer.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbLayer.FormattingEnabled = true;
			this.cmbLayer.Items.AddRange(new object[] {"Ground", "Mask", "Mask 2", "Fringe", "Fringe 2"});
			this.cmbLayer.Location = new System.Drawing.Point(115, 34);
			this.cmbLayer.Name = "cmbLayer";
			this.cmbLayer.Size = new System.Drawing.Size(252, 21);
			this.cmbLayer.TabIndex = 43;
			this.cmbLayer.Text = "Ground";
			this.cmbLayer.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//cmbPrefab
			//
			this.cmbPrefab.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.cmbPrefab.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbPrefab.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbPrefab.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbPrefab.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbPrefab.ButtonIcon"));
			this.cmbPrefab.DrawDropdownHoverOutline = false;
			this.cmbPrefab.DrawFocusRectangle = false;
			this.cmbPrefab.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPrefab.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPrefab.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPrefab.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbPrefab.FormattingEnabled = true;
			this.cmbPrefab.Items.AddRange(new object[] {"Water", "Sand", "Grass", "Passing", "Overgrass", "River", "Mountain"});
			this.cmbPrefab.Location = new System.Drawing.Point(115, 7);
			this.cmbPrefab.Name = "cmbPrefab";
			this.cmbPrefab.Size = new System.Drawing.Size(252, 21);
			this.cmbPrefab.TabIndex = 43;
			this.cmbPrefab.Text = "Water";
			this.cmbPrefab.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.txtAutotile);
			this.GroupBox1.Controls.Add(this.txtTileY);
			this.GroupBox1.Controls.Add(this.txtTileX);
			this.GroupBox1.Controls.Add(this.txtTileset);
			this.GroupBox1.Controls.Add(this.chkBlocked);
			this.GroupBox1.Controls.Add(this.Label14);
			this.GroupBox1.Controls.Add(this.Label13);
			this.GroupBox1.Controls.Add(this.Label12);
			this.GroupBox1.Controls.Add(this.Label11);
			this.GroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
			this.GroupBox1.Location = new System.Drawing.Point(7, 66);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(366, 169);
			this.GroupBox1.TabIndex = 4;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Tile Settings";
			//
			//txtAutotile
			//
			this.txtAutotile.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtAutotile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtAutotile.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtAutotile.Location = new System.Drawing.Point(108, 98);
			this.txtAutotile.Name = "txtAutotile";
			this.txtAutotile.Size = new System.Drawing.Size(252, 20);
			this.txtAutotile.TabIndex = 47;
			//
			//txtTileY
			//
			this.txtTileY.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtTileY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTileY.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtTileY.Location = new System.Drawing.Point(108, 72);
			this.txtTileY.Name = "txtTileY";
			this.txtTileY.Size = new System.Drawing.Size(252, 20);
			this.txtTileY.TabIndex = 46;
			//
			//txtTileX
			//
			this.txtTileX.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtTileX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTileX.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtTileX.Location = new System.Drawing.Point(108, 46);
			this.txtTileX.Name = "txtTileX";
			this.txtTileX.Size = new System.Drawing.Size(252, 20);
			this.txtTileX.TabIndex = 45;
			//
			//txtTileset
			//
			this.txtTileset.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtTileset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtTileset.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtTileset.Location = new System.Drawing.Point(108, 20);
			this.txtTileset.Name = "txtTileset";
			this.txtTileset.Size = new System.Drawing.Size(252, 20);
			this.txtTileset.TabIndex = 44;
			//
			//chkBlocked
			//
			this.chkBlocked.AutoSize = true;
			this.chkBlocked.Location = new System.Drawing.Point(8, 132);
			this.chkBlocked.Name = "chkBlocked";
			this.chkBlocked.Size = new System.Drawing.Size(91, 17);
			this.chkBlocked.TabIndex = 43;
			this.chkBlocked.Text = "Is It Blocked?";
			//
			//Label14
			//
			this.Label14.AutoSize = true;
			this.Label14.Location = new System.Drawing.Point(11, 100);
			this.Label14.Name = "Label14";
			this.Label14.Size = new System.Drawing.Size(49, 13);
			this.Label14.TabIndex = 6;
			this.Label14.Text = "AutoTile:";
			//
			//Label13
			//
			this.Label13.AutoSize = true;
			this.Label13.Location = new System.Drawing.Point(11, 74);
			this.Label13.Name = "Label13";
			this.Label13.Size = new System.Drawing.Size(53, 13);
			this.Label13.TabIndex = 4;
			this.Label13.Text = "TileSet Y:";
			//
			//Label12
			//
			this.Label12.AutoSize = true;
			this.Label12.Location = new System.Drawing.Point(11, 48);
			this.Label12.Name = "Label12";
			this.Label12.Size = new System.Drawing.Size(53, 13);
			this.Label12.TabIndex = 2;
			this.Label12.Text = "TileSet X:";
			//
			//Label11
			//
			this.Label11.AutoSize = true;
			this.Label11.Location = new System.Drawing.Point(11, 22);
			this.Label11.Name = "Label11";
			this.Label11.Size = new System.Drawing.Size(83, 13);
			this.Label11.TabIndex = 0;
			this.Label11.Text = "TileSet Number:";
			//
			//DarkMenu
			//
			this.DarkMenu.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkMenu.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.ConfigurationsToolStripMenuItem2, this.GenerateToolStripMenuItem1});
			this.DarkMenu.Location = new System.Drawing.Point(0, 0);
			this.DarkMenu.Name = "DarkMenu";
			this.DarkMenu.Padding = new System.Windows.Forms.Padding(3, 2, 0, 2);
			this.DarkMenu.Size = new System.Drawing.Size(1188, 24);
			this.DarkMenu.TabIndex = 27;
			//
			//ConfigurationsToolStripMenuItem2
			//
			this.ConfigurationsToolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.TilesetsToolStripMenuItem, this.ResourcesToolStripMenuItem});
			this.ConfigurationsToolStripMenuItem2.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.ConfigurationsToolStripMenuItem2.Name = "ConfigurationsToolStripMenuItem2";
			this.ConfigurationsToolStripMenuItem2.Size = new System.Drawing.Size(93, 20);
			this.ConfigurationsToolStripMenuItem2.Text = "Configuration";
			//
			//TilesetsToolStripMenuItem
			//
			this.TilesetsToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.TilesetsToolStripMenuItem.Name = "TilesetsToolStripMenuItem";
			this.TilesetsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.TilesetsToolStripMenuItem.Text = "Tilesets";
			//
			//ResourcesToolStripMenuItem
			//
			this.ResourcesToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.ResourcesToolStripMenuItem.Name = "ResourcesToolStripMenuItem";
			this.ResourcesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
			this.ResourcesToolStripMenuItem.Text = "Resources";
			//
			//GenerateToolStripMenuItem1
			//
			this.GenerateToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.PathsToolStripMenuItem1, this.RiversToolStripMenuItem1, this.MountainsToolStripMenuItem1, this.OverGrassToolStripMenuItem1, this.ResourcesToolStripMenuItem3, this.DetailsToolStripMenuItem1});
			this.GenerateToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.GenerateToolStripMenuItem1.Name = "GenerateToolStripMenuItem1";
			this.GenerateToolStripMenuItem1.Size = new System.Drawing.Size(66, 20);
			this.GenerateToolStripMenuItem1.Text = "Generate";
			//
			//PathsToolStripMenuItem1
			//
			this.PathsToolStripMenuItem1.Checked = true;
			this.PathsToolStripMenuItem1.CheckOnClick = true;
			this.PathsToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.PathsToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.PathsToolStripMenuItem1.Name = "PathsToolStripMenuItem1";
			this.PathsToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
			this.PathsToolStripMenuItem1.Text = "Paths";
			//
			//RiversToolStripMenuItem1
			//
			this.RiversToolStripMenuItem1.Checked = true;
			this.RiversToolStripMenuItem1.CheckOnClick = true;
			this.RiversToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.RiversToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.RiversToolStripMenuItem1.Name = "RiversToolStripMenuItem1";
			this.RiversToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
			this.RiversToolStripMenuItem1.Text = "Rivers";
			//
			//MountainsToolStripMenuItem1
			//
			this.MountainsToolStripMenuItem1.Checked = true;
			this.MountainsToolStripMenuItem1.CheckOnClick = true;
			this.MountainsToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.MountainsToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.MountainsToolStripMenuItem1.Name = "MountainsToolStripMenuItem1";
			this.MountainsToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
			this.MountainsToolStripMenuItem1.Text = "Mountains";
			//
			//OverGrassToolStripMenuItem1
			//
			this.OverGrassToolStripMenuItem1.Checked = true;
			this.OverGrassToolStripMenuItem1.CheckOnClick = true;
			this.OverGrassToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.OverGrassToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.OverGrassToolStripMenuItem1.Name = "OverGrassToolStripMenuItem1";
			this.OverGrassToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
			this.OverGrassToolStripMenuItem1.Text = "OverGrass";
			//
			//ResourcesToolStripMenuItem3
			//
			this.ResourcesToolStripMenuItem3.Checked = true;
			this.ResourcesToolStripMenuItem3.CheckOnClick = true;
			this.ResourcesToolStripMenuItem3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ResourcesToolStripMenuItem3.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.ResourcesToolStripMenuItem3.Name = "ResourcesToolStripMenuItem3";
			this.ResourcesToolStripMenuItem3.Size = new System.Drawing.Size(131, 22);
			this.ResourcesToolStripMenuItem3.Text = "Resources";
			//
			//DetailsToolStripMenuItem1
			//
			this.DetailsToolStripMenuItem1.Checked = true;
			this.DetailsToolStripMenuItem1.CheckOnClick = true;
			this.DetailsToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.DetailsToolStripMenuItem1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DetailsToolStripMenuItem1.Name = "DetailsToolStripMenuItem1";
			this.DetailsToolStripMenuItem1.Size = new System.Drawing.Size(131, 22);
			this.DetailsToolStripMenuItem1.Text = "Details";
			//
			//DarkLabel1
			//
			this.DarkLabel1.AutoSize = true;
			this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel1.Location = new System.Drawing.Point(12, 31);
			this.DarkLabel1.Name = "DarkLabel1";
			this.DarkLabel1.Size = new System.Drawing.Size(56, 13);
			this.DarkLabel1.TabIndex = 28;
			this.DarkLabel1.Text = "Start Map:";
			//
			//DarkLabel2
			//
			this.DarkLabel2.AutoSize = true;
			this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel2.Location = new System.Drawing.Point(12, 57);
			this.DarkLabel2.Name = "DarkLabel2";
			this.DarkLabel2.Size = new System.Drawing.Size(63, 13);
			this.DarkLabel2.TabIndex = 29;
			this.DarkLabel2.Text = "Island Area:";
			//
			//DarkLabel3
			//
			this.DarkLabel3.AutoSize = true;
			this.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel3.Location = new System.Drawing.Point(13, 83);
			this.DarkLabel3.Name = "DarkLabel3";
			this.DarkLabel3.Size = new System.Drawing.Size(63, 13);
			this.DarkLabel3.TabIndex = 30;
			this.DarkLabel3.Text = "Max Size X:";
			//
			//DarkLabel4
			//
			this.DarkLabel4.AutoSize = true;
			this.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel4.Location = new System.Drawing.Point(12, 109);
			this.DarkLabel4.Name = "DarkLabel4";
			this.DarkLabel4.Size = new System.Drawing.Size(64, 13);
			this.DarkLabel4.TabIndex = 31;
			this.DarkLabel4.Text = "Map Size Y:";
			//
			//DarkLabel5
			//
			this.DarkLabel5.AutoSize = true;
			this.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel5.Location = new System.Drawing.Point(13, 135);
			this.DarkLabel5.Name = "DarkLabel5";
			this.DarkLabel5.Size = new System.Drawing.Size(69, 13);
			this.DarkLabel5.TabIndex = 32;
			this.DarkLabel5.Text = "Sand Border:";
			//
			//DarkLabel6
			//
			this.DarkLabel6.AutoSize = true;
			this.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel6.Location = new System.Drawing.Point(13, 161);
			this.DarkLabel6.Name = "DarkLabel6";
			this.DarkLabel6.Size = new System.Drawing.Size(111, 13);
			this.DarkLabel6.TabIndex = 33;
			this.DarkLabel6.Text = "Detail Frequency 1 of ";
			//
			//DarkLabel7
			//
			this.DarkLabel7.AutoSize = true;
			this.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel7.Location = new System.Drawing.Point(12, 187);
			this.DarkLabel7.Name = "DarkLabel7";
			this.DarkLabel7.Size = new System.Drawing.Size(127, 13);
			this.DarkLabel7.TabIndex = 34;
			this.DarkLabel7.Text = "Resource Frequency 1 of";
			//
			//txtMapStart
			//
			this.txtMapStart.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtMapStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMapStart.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtMapStart.Location = new System.Drawing.Point(145, 28);
			this.txtMapStart.Name = "txtMapStart";
			this.txtMapStart.Size = new System.Drawing.Size(225, 20);
			this.txtMapStart.TabIndex = 35;
			this.txtMapStart.Text = "1";
			//
			//txtMapSize
			//
			this.txtMapSize.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtMapSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMapSize.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtMapSize.Location = new System.Drawing.Point(145, 54);
			this.txtMapSize.Name = "txtMapSize";
			this.txtMapSize.Size = new System.Drawing.Size(225, 20);
			this.txtMapSize.TabIndex = 36;
			this.txtMapSize.Text = "4";
			//
			//txtMapX
			//
			this.txtMapX.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtMapX.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMapX.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtMapX.Location = new System.Drawing.Point(145, 80);
			this.txtMapX.Name = "txtMapX";
			this.txtMapX.Size = new System.Drawing.Size(225, 20);
			this.txtMapX.TabIndex = 37;
			this.txtMapX.Text = "50";
			//
			//txtMapY
			//
			this.txtMapY.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtMapY.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMapY.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtMapY.Location = new System.Drawing.Point(145, 106);
			this.txtMapY.Name = "txtMapY";
			this.txtMapY.Size = new System.Drawing.Size(225, 20);
			this.txtMapY.TabIndex = 38;
			this.txtMapY.Text = "50";
			//
			//txtSandBorder
			//
			this.txtSandBorder.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtSandBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtSandBorder.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtSandBorder.Location = new System.Drawing.Point(145, 132);
			this.txtSandBorder.Name = "txtSandBorder";
			this.txtSandBorder.Size = new System.Drawing.Size(225, 20);
			this.txtSandBorder.TabIndex = 39;
			this.txtSandBorder.Text = "4";
			//
			//txtDetail
			//
			this.txtDetail.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtDetail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtDetail.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtDetail.Location = new System.Drawing.Point(145, 158);
			this.txtDetail.Name = "txtDetail";
			this.txtDetail.Size = new System.Drawing.Size(225, 20);
			this.txtDetail.TabIndex = 40;
			this.txtDetail.Text = "10";
			//
			//txtResourceFreq
			//
			this.txtResourceFreq.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtResourceFreq.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtResourceFreq.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtResourceFreq.Location = new System.Drawing.Point(145, 184);
			this.txtResourceFreq.Name = "txtResourceFreq";
			this.txtResourceFreq.Size = new System.Drawing.Size(225, 20);
			this.txtResourceFreq.TabIndex = 41;
			this.txtResourceFreq.Text = "20";
			//
			//btnStart
			//
			this.btnStart.Location = new System.Drawing.Point(16, 232);
			this.btnStart.Name = "btnStart";
			this.btnStart.Padding = new System.Windows.Forms.Padding(5);
			this.btnStart.Size = new System.Drawing.Size(354, 33);
			this.btnStart.TabIndex = 42;
			this.btnStart.Text = "Create The World";
			//
			//FrmAutoMapper
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.ClientSize = new System.Drawing.Size(1188, 296);
			this.Controls.Add(this.pnlResources);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.txtResourceFreq);
			this.Controls.Add(this.txtDetail);
			this.Controls.Add(this.txtSandBorder);
			this.Controls.Add(this.txtMapY);
			this.Controls.Add(this.txtMapX);
			this.Controls.Add(this.txtMapSize);
			this.Controls.Add(this.txtMapStart);
			this.Controls.Add(this.DarkLabel7);
			this.Controls.Add(this.DarkLabel6);
			this.Controls.Add(this.DarkLabel5);
			this.Controls.Add(this.DarkLabel4);
			this.Controls.Add(this.DarkLabel3);
			this.Controls.Add(this.DarkLabel2);
			this.Controls.Add(this.DarkLabel1);
			this.Controls.Add(this.pnlTileConfig);
			this.Controls.Add(this.DarkMenu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmAutoMapper";
			this.Text = "Auto Mapper";
			this.pnlResources.ResumeLayout(false);
			this.pnlResources.PerformLayout();
			this.pnlTileConfig.ResumeLayout(false);
			this.pnlTileConfig.PerformLayout();
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.DarkMenu.ResumeLayout(false);
			this.DarkMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		internal Panel pnlResources;
		internal ListBox lstResources;
		internal Panel pnlTileConfig;
		internal GroupBox GroupBox1;
		internal Label Label13;
		internal Label Label12;
		internal Label Label11;
		internal Label Label14;
		internal DarkUI.Controls.DarkMenuStrip DarkMenu;
		internal ToolStripMenuItem ConfigurationsToolStripMenuItem2;
		internal ToolStripMenuItem TilesetsToolStripMenuItem;
		internal ToolStripMenuItem ResourcesToolStripMenuItem;
		internal ToolStripMenuItem GenerateToolStripMenuItem1;
		internal ToolStripMenuItem PathsToolStripMenuItem1;
		internal ToolStripMenuItem RiversToolStripMenuItem1;
		internal ToolStripMenuItem MountainsToolStripMenuItem1;
		internal ToolStripMenuItem OverGrassToolStripMenuItem1;
		internal ToolStripMenuItem ResourcesToolStripMenuItem3;
		internal ToolStripMenuItem DetailsToolStripMenuItem1;
		internal DarkUI.Controls.DarkLabel DarkLabel1;
		internal DarkUI.Controls.DarkLabel DarkLabel2;
		internal DarkUI.Controls.DarkLabel DarkLabel3;
		internal DarkUI.Controls.DarkLabel DarkLabel4;
		internal DarkUI.Controls.DarkLabel DarkLabel5;
		internal DarkUI.Controls.DarkLabel DarkLabel6;
		internal DarkUI.Controls.DarkLabel DarkLabel7;
		internal DarkUI.Controls.DarkTextBox txtMapStart;
		internal DarkUI.Controls.DarkTextBox txtMapSize;
		internal DarkUI.Controls.DarkTextBox txtMapX;
		internal DarkUI.Controls.DarkTextBox txtMapY;
		internal DarkUI.Controls.DarkTextBox txtSandBorder;
		internal DarkUI.Controls.DarkTextBox txtDetail;
		internal DarkUI.Controls.DarkTextBox txtResourceFreq;
		internal DarkUI.Controls.DarkButton btnStart;
		internal DarkUI.Controls.DarkLabel DarkLabel8;
		internal DarkUI.Controls.DarkButton btnCloseResource;
		internal DarkUI.Controls.DarkTextBox txtResource;
		internal DarkUI.Controls.DarkButton btnSaveResource;
		internal DarkUI.Controls.DarkButton btnUpdateResource;
		internal DarkUI.Controls.DarkButton btnRemoveResource;
		internal DarkUI.Controls.DarkButton btnAddResource;
		internal DarkUI.Controls.DarkComboBox cmbPrefab;
		internal DarkUI.Controls.DarkComboBox cmbLayer;
		internal DarkUI.Controls.DarkLabel DarkLabel10;
		internal DarkUI.Controls.DarkLabel DarkLabel9;
		internal DarkUI.Controls.DarkCheckBox chkBlocked;
		internal DarkUI.Controls.DarkTextBox txtTileset;
		internal DarkUI.Controls.DarkTextBox txtAutotile;
		internal DarkUI.Controls.DarkTextBox txtTileY;
		internal DarkUI.Controls.DarkTextBox txtTileX;
		internal DarkUI.Controls.DarkButton btnTileSetClose;
		internal DarkUI.Controls.DarkButton btnTileSetSave;
	}
	
}
