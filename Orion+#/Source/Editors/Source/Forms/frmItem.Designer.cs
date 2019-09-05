
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
		public partial class FrmItem : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmItem));
            this.DarkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.lstIndex = new System.Windows.Forms.ListBox();
            this.fraBasics = new DarkUI.Controls.DarkGroupBox();
            this.fraPet = new DarkUI.Controls.DarkGroupBox();
            this.cmbPet = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel13 = new DarkUI.Controls.DarkLabel();
            this.txtDescription = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel10 = new DarkUI.Controls.DarkLabel();
            this.cmbAnimation = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel9 = new DarkUI.Controls.DarkLabel();
            this.nudItemLvl = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel8 = new DarkUI.Controls.DarkLabel();
            this.nudPrice = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel7 = new DarkUI.Controls.DarkLabel();
            this.cmbBind = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel6 = new DarkUI.Controls.DarkLabel();
            this.chkStackable = new DarkUI.Controls.DarkCheckBox();
            this.cmbSubType = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel5 = new DarkUI.Controls.DarkLabel();
            this.cmbType = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel4 = new DarkUI.Controls.DarkLabel();
            this.picItem = new System.Windows.Forms.PictureBox();
            this.nudRarity = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel3 = new DarkUI.Controls.DarkLabel();
            this.nudPic = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel2 = new DarkUI.Controls.DarkLabel();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel1 = new DarkUI.Controls.DarkLabel();
            this.fraSkill = new DarkUI.Controls.DarkGroupBox();
            this.cmbSkills = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel12 = new DarkUI.Controls.DarkLabel();
            this.fraRecipe = new DarkUI.Controls.DarkGroupBox();
            this.cmbRecipe = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel35 = new DarkUI.Controls.DarkLabel();
            this.fraVitals = new DarkUI.Controls.DarkGroupBox();
            this.nudVitalMod = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel11 = new DarkUI.Controls.DarkLabel();
            this.fraEquipment = new DarkUI.Controls.DarkGroupBox();
            this.DarkGroupBox3 = new DarkUI.Controls.DarkGroupBox();
            this.cmbAmmo = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel25 = new DarkUI.Controls.DarkLabel();
            this.cmbProjectile = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel24 = new DarkUI.Controls.DarkLabel();
            this.nudPaperdoll = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel23 = new DarkUI.Controls.DarkLabel();
            this.picPaperdoll = new System.Windows.Forms.PictureBox();
            this.DarkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.nudSpirit = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel22 = new DarkUI.Controls.DarkLabel();
            this.nudIntelligence = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel21 = new DarkUI.Controls.DarkLabel();
            this.nudVitality = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel20 = new DarkUI.Controls.DarkLabel();
            this.nudLuck = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel19 = new DarkUI.Controls.DarkLabel();
            this.nudEndurance = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel18 = new DarkUI.Controls.DarkLabel();
            this.nudStrength = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel17 = new DarkUI.Controls.DarkLabel();
            this.chkRandomize = new DarkUI.Controls.DarkCheckBox();
            this.cmbKnockBackTiles = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel16 = new DarkUI.Controls.DarkLabel();
            this.chkKnockBack = new DarkUI.Controls.DarkCheckBox();
            this.nudSpeed = new DarkUI.Controls.DarkNumericUpDown();
            this.lblSpeed = new DarkUI.Controls.DarkLabel();
            this.nudDamage = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel15 = new DarkUI.Controls.DarkLabel();
            this.cmbTool = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel14 = new DarkUI.Controls.DarkLabel();
            this.btnBasics = new DarkUI.Controls.DarkButton();
            this.btnRequirements = new DarkUI.Controls.DarkButton();
            this.fraRequirements = new DarkUI.Controls.DarkGroupBox();
            this.DarkGroupBox4 = new DarkUI.Controls.DarkGroupBox();
            this.nudSprReq = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel32 = new DarkUI.Controls.DarkLabel();
            this.nudIntReq = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel33 = new DarkUI.Controls.DarkLabel();
            this.nudVitReq = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel34 = new DarkUI.Controls.DarkLabel();
            this.nudLuckReq = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel29 = new DarkUI.Controls.DarkLabel();
            this.nudEndReq = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel30 = new DarkUI.Controls.DarkLabel();
            this.nudStrReq = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel31 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel28 = new DarkUI.Controls.DarkLabel();
            this.nudLevelReq = new DarkUI.Controls.DarkNumericUpDown();
            this.cmbAccessReq = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel27 = new DarkUI.Controls.DarkLabel();
            this.cmbClassReq = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel26 = new DarkUI.Controls.DarkLabel();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.btnDelete = new DarkUI.Controls.DarkButton();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.fraFurniture = new DarkUI.Controls.DarkGroupBox();
            this.nudFurniture = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel37 = new DarkUI.Controls.DarkLabel();
            this.lblSetOption = new DarkUI.Controls.DarkLabel();
            this.optSetFringe = new DarkUI.Controls.DarkRadioButton();
            this.optSetBlocks = new DarkUI.Controls.DarkRadioButton();
            this.optNoFurnitureEditing = new DarkUI.Controls.DarkRadioButton();
            this.cmbFurnitureType = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel36 = new DarkUI.Controls.DarkLabel();
            this.picFurniture = new System.Windows.Forms.PictureBox();
            this.DarkGroupBox1.SuspendLayout();
            this.fraBasics.SuspendLayout();
            this.fraPet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemLvl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRarity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPic)).BeginInit();
            this.fraSkill.SuspendLayout();
            this.fraRecipe.SuspendLayout();
            this.fraVitals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitalMod)).BeginInit();
            this.fraEquipment.SuspendLayout();
            this.DarkGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperdoll)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPaperdoll)).BeginInit();
            this.DarkGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpirit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntelligence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndurance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamage)).BeginInit();
            this.fraRequirements.SuspendLayout();
            this.DarkGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSprReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuckReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevelReq)).BeginInit();
            this.fraFurniture.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFurniture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFurniture)).BeginInit();
            this.SuspendLayout();
            // 
            // DarkGroupBox1
            // 
            this.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox1.Controls.Add(this.lstIndex);
            this.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox1.Location = new System.Drawing.Point(2, 2);
            this.DarkGroupBox1.Name = "DarkGroupBox1";
            this.DarkGroupBox1.Size = new System.Drawing.Size(209, 401);
            this.DarkGroupBox1.TabIndex = 0;
            this.DarkGroupBox1.TabStop = false;
            this.DarkGroupBox1.Text = "Item List";
            // 
            // lstIndex
            // 
            this.lstIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstIndex.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstIndex.FormattingEnabled = true;
            this.lstIndex.Location = new System.Drawing.Point(6, 14);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(196, 379);
            this.lstIndex.TabIndex = 1;
            this.lstIndex.Click += new System.EventHandler(this.LstIndex_Click);
            // 
            // fraBasics
            // 
            this.fraBasics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.fraBasics.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.fraBasics.Controls.Add(this.fraPet);
            this.fraBasics.Controls.Add(this.txtDescription);
            this.fraBasics.Controls.Add(this.DarkLabel10);
            this.fraBasics.Controls.Add(this.cmbAnimation);
            this.fraBasics.Controls.Add(this.DarkLabel9);
            this.fraBasics.Controls.Add(this.nudItemLvl);
            this.fraBasics.Controls.Add(this.DarkLabel8);
            this.fraBasics.Controls.Add(this.nudPrice);
            this.fraBasics.Controls.Add(this.DarkLabel7);
            this.fraBasics.Controls.Add(this.cmbBind);
            this.fraBasics.Controls.Add(this.DarkLabel6);
            this.fraBasics.Controls.Add(this.chkStackable);
            this.fraBasics.Controls.Add(this.cmbSubType);
            this.fraBasics.Controls.Add(this.DarkLabel5);
            this.fraBasics.Controls.Add(this.cmbType);
            this.fraBasics.Controls.Add(this.DarkLabel4);
            this.fraBasics.Controls.Add(this.picItem);
            this.fraBasics.Controls.Add(this.nudRarity);
            this.fraBasics.Controls.Add(this.DarkLabel3);
            this.fraBasics.Controls.Add(this.nudPic);
            this.fraBasics.Controls.Add(this.DarkLabel2);
            this.fraBasics.Controls.Add(this.txtName);
            this.fraBasics.Controls.Add(this.DarkLabel1);
            this.fraBasics.Controls.Add(this.fraSkill);
            this.fraBasics.Controls.Add(this.fraRecipe);
            this.fraBasics.Controls.Add(this.fraVitals);
            this.fraBasics.ForeColor = System.Drawing.Color.Gainsboro;
            this.fraBasics.Location = new System.Drawing.Point(217, 37);
            this.fraBasics.Name = "fraBasics";
            this.fraBasics.Size = new System.Drawing.Size(450, 202);
            this.fraBasics.TabIndex = 1;
            this.fraBasics.TabStop = false;
            this.fraBasics.Text = "Basics";
            // 
            // fraPet
            // 
            this.fraPet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.fraPet.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.fraPet.Controls.Add(this.cmbPet);
            this.fraPet.Controls.Add(this.DarkLabel13);
            this.fraPet.ForeColor = System.Drawing.Color.Gainsboro;
            this.fraPet.Location = new System.Drawing.Point(243, 159);
            this.fraPet.Name = "fraPet";
            this.fraPet.Size = new System.Drawing.Size(200, 40);
            this.fraPet.TabIndex = 25;
            this.fraPet.TabStop = false;
            this.fraPet.Text = "Pets";
            // 
            // cmbPet
            // 
            this.cmbPet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbPet.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbPet.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbPet.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbPet.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbPet.ButtonIcon")));
            this.cmbPet.DrawDropdownHoverOutline = false;
            this.cmbPet.DrawFocusRectangle = false;
            this.cmbPet.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbPet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbPet.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbPet.FormattingEnabled = true;
            this.cmbPet.Location = new System.Drawing.Point(41, 14);
            this.cmbPet.Name = "cmbPet";
            this.cmbPet.Size = new System.Drawing.Size(153, 21);
            this.cmbPet.TabIndex = 1;
            this.cmbPet.Text = null;
            this.cmbPet.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbPet.SelectedIndexChanged += new System.EventHandler(this.CmbPet_SelectedIndexChanged);
            // 
            // DarkLabel13
            // 
            this.DarkLabel13.AutoSize = true;
            this.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel13.Location = new System.Drawing.Point(6, 17);
            this.DarkLabel13.Name = "DarkLabel13";
            this.DarkLabel13.Size = new System.Drawing.Size(26, 13);
            this.DarkLabel13.TabIndex = 0;
            this.DarkLabel13.Text = "Pet:";
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtDescription.Location = new System.Drawing.Point(9, 135);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(228, 60);
            this.txtDescription.TabIndex = 22;
            this.txtDescription.TextChanged += new System.EventHandler(this.TxtDescription_TextChanged);
            // 
            // DarkLabel10
            // 
            this.DarkLabel10.AutoSize = true;
            this.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel10.Location = new System.Drawing.Point(6, 119);
            this.DarkLabel10.Name = "DarkLabel10";
            this.DarkLabel10.Size = new System.Drawing.Size(60, 13);
            this.DarkLabel10.TabIndex = 21;
            this.DarkLabel10.Text = "Description";
            // 
            // cmbAnimation
            // 
            this.cmbAnimation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbAnimation.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbAnimation.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbAnimation.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbAnimation.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbAnimation.ButtonIcon")));
            this.cmbAnimation.DrawDropdownHoverOutline = false;
            this.cmbAnimation.DrawFocusRectangle = false;
            this.cmbAnimation.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAnimation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnimation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAnimation.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbAnimation.FormattingEnabled = true;
            this.cmbAnimation.Location = new System.Drawing.Point(325, 93);
            this.cmbAnimation.Name = "cmbAnimation";
            this.cmbAnimation.Size = new System.Drawing.Size(118, 21);
            this.cmbAnimation.TabIndex = 20;
            this.cmbAnimation.Text = null;
            this.cmbAnimation.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbAnimation.SelectedIndexChanged += new System.EventHandler(this.CmbAnimation_SelectedIndexChanged);
            // 
            // DarkLabel9
            // 
            this.DarkLabel9.AutoSize = true;
            this.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel9.Location = new System.Drawing.Point(263, 96);
            this.DarkLabel9.Name = "DarkLabel9";
            this.DarkLabel9.Size = new System.Drawing.Size(56, 13);
            this.DarkLabel9.TabIndex = 19;
            this.DarkLabel9.Text = "Animation:";
            // 
            // nudItemLvl
            // 
            this.nudItemLvl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudItemLvl.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudItemLvl.Location = new System.Drawing.Point(209, 94);
            this.nudItemLvl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudItemLvl.Name = "nudItemLvl";
            this.nudItemLvl.Size = new System.Drawing.Size(48, 20);
            this.nudItemLvl.TabIndex = 18;
            this.nudItemLvl.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudItemLvl.Click += new System.EventHandler(this.NudItemLvl_ValueChanged);
            // 
            // DarkLabel8
            // 
            this.DarkLabel8.AutoSize = true;
            this.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel8.Location = new System.Drawing.Point(148, 96);
            this.DarkLabel8.Name = "DarkLabel8";
            this.DarkLabel8.Size = new System.Drawing.Size(59, 13);
            this.DarkLabel8.TabIndex = 17;
            this.DarkLabel8.Text = "Item Level:";
            // 
            // nudPrice
            // 
            this.nudPrice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudPrice.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudPrice.Location = new System.Drawing.Point(73, 94);
            this.nudPrice.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudPrice.Name = "nudPrice";
            this.nudPrice.Size = new System.Drawing.Size(69, 20);
            this.nudPrice.TabIndex = 16;
            this.nudPrice.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPrice.Click += new System.EventHandler(this.NudPrice_ValueChanged);
            // 
            // DarkLabel7
            // 
            this.DarkLabel7.AutoSize = true;
            this.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel7.Location = new System.Drawing.Point(6, 96);
            this.DarkLabel7.Name = "DarkLabel7";
            this.DarkLabel7.Size = new System.Drawing.Size(54, 13);
            this.DarkLabel7.TabIndex = 15;
            this.DarkLabel7.Text = "Sell Price:";
            // 
            // cmbBind
            // 
            this.cmbBind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbBind.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbBind.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbBind.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbBind.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbBind.ButtonIcon")));
            this.cmbBind.DrawDropdownHoverOutline = false;
            this.cmbBind.DrawFocusRectangle = false;
            this.cmbBind.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBind.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbBind.FormattingEnabled = true;
            this.cmbBind.Items.AddRange(new object[] {
            "None",
            "Bind on Pickup",
            "Bind on Equip"});
            this.cmbBind.Location = new System.Drawing.Point(285, 67);
            this.cmbBind.Name = "cmbBind";
            this.cmbBind.Size = new System.Drawing.Size(158, 21);
            this.cmbBind.TabIndex = 14;
            this.cmbBind.Text = "None";
            this.cmbBind.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbBind.SelectedIndexChanged += new System.EventHandler(this.CmbBind_SelectedIndexChanged);
            // 
            // DarkLabel6
            // 
            this.DarkLabel6.AutoSize = true;
            this.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel6.Location = new System.Drawing.Point(224, 70);
            this.DarkLabel6.Name = "DarkLabel6";
            this.DarkLabel6.Size = new System.Drawing.Size(55, 13);
            this.DarkLabel6.TabIndex = 13;
            this.DarkLabel6.Text = "BindType:";
            // 
            // chkStackable
            // 
            this.chkStackable.AutoSize = true;
            this.chkStackable.Location = new System.Drawing.Point(227, 42);
            this.chkStackable.Name = "chkStackable";
            this.chkStackable.Size = new System.Drawing.Size(74, 17);
            this.chkStackable.TabIndex = 12;
            this.chkStackable.Text = "Stackable";
            this.chkStackable.CheckedChanged += new System.EventHandler(this.ChkStackable_CheckedChanged);
            // 
            // cmbSubType
            // 
            this.cmbSubType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSubType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSubType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSubType.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSubType.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSubType.ButtonIcon")));
            this.cmbSubType.DrawDropdownHoverOutline = false;
            this.cmbSubType.DrawFocusRectangle = false;
            this.cmbSubType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSubType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSubType.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSubType.FormattingEnabled = true;
            this.cmbSubType.Items.AddRange(new object[] {
            "None",
            "Weapon",
            "Armor",
            "Helmet",
            "Shield",
            "Shoes",
            "Gloves",
            "Potion Add HP",
            "Potion Add MP",
            "Potion Add SP",
            "Potion Sub HP",
            "Potion Sub MP",
            "Potion Sub SP",
            "Key",
            "Currency",
            "Skill",
            "Furniture",
            "Recipe"});
            this.cmbSubType.Location = new System.Drawing.Point(73, 67);
            this.cmbSubType.Name = "cmbSubType";
            this.cmbSubType.Size = new System.Drawing.Size(121, 21);
            this.cmbSubType.TabIndex = 11;
            this.cmbSubType.Text = "None";
            this.cmbSubType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSubType.SelectedIndexChanged += new System.EventHandler(this.CmbSubType_SelectedIndexChanged);
            // 
            // DarkLabel5
            // 
            this.DarkLabel5.AutoSize = true;
            this.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel5.Location = new System.Drawing.Point(6, 70);
            this.DarkLabel5.Name = "DarkLabel5";
            this.DarkLabel5.Size = new System.Drawing.Size(56, 13);
            this.DarkLabel5.TabIndex = 10;
            this.DarkLabel5.Text = "Sub-Type:";
            // 
            // cmbType
            // 
            this.cmbType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbType.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbType.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbType.ButtonIcon")));
            this.cmbType.DrawDropdownHoverOutline = false;
            this.cmbType.DrawFocusRectangle = false;
            this.cmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbType.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbType.FormattingEnabled = true;
            this.cmbType.Items.AddRange(new object[] {
            "None",
            "Equipment",
            "Consumables",
            "Key",
            "Currency",
            "Skill",
            "Furniture",
            "Recipe",
            "Pet"});
            this.cmbType.Location = new System.Drawing.Point(73, 40);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 9;
            this.cmbType.Text = "None";
            this.cmbType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.CmbType_SelectedIndexChanged);
            // 
            // DarkLabel4
            // 
            this.DarkLabel4.AutoSize = true;
            this.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel4.Location = new System.Drawing.Point(6, 43);
            this.DarkLabel4.Name = "DarkLabel4";
            this.DarkLabel4.Size = new System.Drawing.Size(57, 13);
            this.DarkLabel4.TabIndex = 8;
            this.DarkLabel4.Text = "Item Type:";
            // 
            // picItem
            // 
            this.picItem.BackColor = System.Drawing.Color.Black;
            this.picItem.Location = new System.Drawing.Point(411, 14);
            this.picItem.Name = "picItem";
            this.picItem.Size = new System.Drawing.Size(32, 32);
            this.picItem.TabIndex = 7;
            this.picItem.TabStop = false;
            this.picItem.Paint += new System.Windows.Forms.PaintEventHandler(this.PicItem_Paint);
            // 
            // nudRarity
            // 
            this.nudRarity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudRarity.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudRarity.Location = new System.Drawing.Point(356, 40);
            this.nudRarity.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudRarity.Name = "nudRarity";
            this.nudRarity.Size = new System.Drawing.Size(49, 20);
            this.nudRarity.TabIndex = 5;
            this.nudRarity.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRarity.Click += new System.EventHandler(this.NudRarity_ValueChanged);
            // 
            // DarkLabel3
            // 
            this.DarkLabel3.AutoSize = true;
            this.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel3.Location = new System.Drawing.Point(307, 43);
            this.DarkLabel3.Name = "DarkLabel3";
            this.DarkLabel3.Size = new System.Drawing.Size(37, 13);
            this.DarkLabel3.TabIndex = 4;
            this.DarkLabel3.Text = "Rarity:";
            // 
            // nudPic
            // 
            this.nudPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudPic.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudPic.Location = new System.Drawing.Point(356, 14);
            this.nudPic.Name = "nudPic";
            this.nudPic.Size = new System.Drawing.Size(49, 20);
            this.nudPic.TabIndex = 3;
            this.nudPic.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPic.Click += new System.EventHandler(this.NudPic_ValueChanged);
            // 
            // DarkLabel2
            // 
            this.DarkLabel2.AutoSize = true;
            this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel2.Location = new System.Drawing.Point(307, 16);
            this.DarkLabel2.Name = "DarkLabel2";
            this.DarkLabel2.Size = new System.Drawing.Size(43, 13);
            this.DarkLabel2.TabIndex = 2;
            this.DarkLabel2.Text = "Picture:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtName.Location = new System.Drawing.Point(73, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(228, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            // 
            // DarkLabel1
            // 
            this.DarkLabel1.AutoSize = true;
            this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel1.Location = new System.Drawing.Point(6, 16);
            this.DarkLabel1.Name = "DarkLabel1";
            this.DarkLabel1.Size = new System.Drawing.Size(61, 13);
            this.DarkLabel1.TabIndex = 0;
            this.DarkLabel1.Text = "Item Name:";
            // 
            // fraSkill
            // 
            this.fraSkill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.fraSkill.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.fraSkill.Controls.Add(this.cmbSkills);
            this.fraSkill.Controls.Add(this.DarkLabel12);
            this.fraSkill.ForeColor = System.Drawing.Color.Gainsboro;
            this.fraSkill.Location = new System.Drawing.Point(243, 120);
            this.fraSkill.Name = "fraSkill";
            this.fraSkill.Size = new System.Drawing.Size(200, 40);
            this.fraSkill.TabIndex = 24;
            this.fraSkill.TabStop = false;
            this.fraSkill.Text = "Skills";
            // 
            // cmbSkills
            // 
            this.cmbSkills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSkills.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSkills.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSkills.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSkills.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSkills.ButtonIcon")));
            this.cmbSkills.DrawDropdownHoverOutline = false;
            this.cmbSkills.DrawFocusRectangle = false;
            this.cmbSkills.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkills.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSkills.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSkills.FormattingEnabled = true;
            this.cmbSkills.Location = new System.Drawing.Point(41, 14);
            this.cmbSkills.Name = "cmbSkills";
            this.cmbSkills.Size = new System.Drawing.Size(153, 21);
            this.cmbSkills.TabIndex = 1;
            this.cmbSkills.Text = null;
            this.cmbSkills.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSkills.SelectedIndexChanged += new System.EventHandler(this.CmbSkills_SelectedIndexChanged);
            // 
            // DarkLabel12
            // 
            this.DarkLabel12.AutoSize = true;
            this.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel12.Location = new System.Drawing.Point(6, 17);
            this.DarkLabel12.Name = "DarkLabel12";
            this.DarkLabel12.Size = new System.Drawing.Size(29, 13);
            this.DarkLabel12.TabIndex = 0;
            this.DarkLabel12.Text = "Skill:";
            // 
            // fraRecipe
            // 
            this.fraRecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.fraRecipe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.fraRecipe.Controls.Add(this.cmbRecipe);
            this.fraRecipe.Controls.Add(this.DarkLabel35);
            this.fraRecipe.ForeColor = System.Drawing.Color.Gainsboro;
            this.fraRecipe.Location = new System.Drawing.Point(243, 160);
            this.fraRecipe.Name = "fraRecipe";
            this.fraRecipe.Size = new System.Drawing.Size(200, 40);
            this.fraRecipe.TabIndex = 26;
            this.fraRecipe.TabStop = false;
            this.fraRecipe.Text = "Recipe";
            // 
            // cmbRecipe
            // 
            this.cmbRecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbRecipe.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbRecipe.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbRecipe.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbRecipe.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbRecipe.ButtonIcon")));
            this.cmbRecipe.DrawDropdownHoverOutline = false;
            this.cmbRecipe.DrawFocusRectangle = false;
            this.cmbRecipe.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRecipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRecipe.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbRecipe.FormattingEnabled = true;
            this.cmbRecipe.Location = new System.Drawing.Point(56, 12);
            this.cmbRecipe.Name = "cmbRecipe";
            this.cmbRecipe.Size = new System.Drawing.Size(138, 21);
            this.cmbRecipe.TabIndex = 1;
            this.cmbRecipe.Text = null;
            this.cmbRecipe.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbRecipe.SelectedIndexChanged += new System.EventHandler(this.CmbRecipe_SelectedIndexChanged);
            // 
            // DarkLabel35
            // 
            this.DarkLabel35.AutoSize = true;
            this.DarkLabel35.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel35.Location = new System.Drawing.Point(6, 17);
            this.DarkLabel35.Name = "DarkLabel35";
            this.DarkLabel35.Size = new System.Drawing.Size(44, 13);
            this.DarkLabel35.TabIndex = 0;
            this.DarkLabel35.Text = "Recipe:";
            // 
            // fraVitals
            // 
            this.fraVitals.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.fraVitals.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.fraVitals.Controls.Add(this.nudVitalMod);
            this.fraVitals.Controls.Add(this.DarkLabel11);
            this.fraVitals.ForeColor = System.Drawing.Color.Gainsboro;
            this.fraVitals.Location = new System.Drawing.Point(243, 120);
            this.fraVitals.Name = "fraVitals";
            this.fraVitals.Size = new System.Drawing.Size(200, 40);
            this.fraVitals.TabIndex = 23;
            this.fraVitals.TabStop = false;
            this.fraVitals.Text = "Vitals";
            // 
            // nudVitalMod
            // 
            this.nudVitalMod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudVitalMod.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudVitalMod.Location = new System.Drawing.Point(67, 14);
            this.nudVitalMod.Name = "nudVitalMod";
            this.nudVitalMod.Size = new System.Drawing.Size(127, 20);
            this.nudVitalMod.TabIndex = 1;
            this.nudVitalMod.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudVitalMod.Click += new System.EventHandler(this.NudVitalMod_ValueChanged);
            // 
            // DarkLabel11
            // 
            this.DarkLabel11.AutoSize = true;
            this.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel11.Location = new System.Drawing.Point(6, 17);
            this.DarkLabel11.Name = "DarkLabel11";
            this.DarkLabel11.Size = new System.Drawing.Size(59, 13);
            this.DarkLabel11.TabIndex = 0;
            this.DarkLabel11.Text = "Vitals Mod:";
            // 
            // fraEquipment
            // 
            this.fraEquipment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.fraEquipment.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.fraEquipment.Controls.Add(this.DarkGroupBox3);
            this.fraEquipment.Controls.Add(this.nudPaperdoll);
            this.fraEquipment.Controls.Add(this.DarkLabel23);
            this.fraEquipment.Controls.Add(this.picPaperdoll);
            this.fraEquipment.Controls.Add(this.DarkGroupBox2);
            this.fraEquipment.Controls.Add(this.cmbKnockBackTiles);
            this.fraEquipment.Controls.Add(this.DarkLabel16);
            this.fraEquipment.Controls.Add(this.chkKnockBack);
            this.fraEquipment.Controls.Add(this.nudSpeed);
            this.fraEquipment.Controls.Add(this.lblSpeed);
            this.fraEquipment.Controls.Add(this.nudDamage);
            this.fraEquipment.Controls.Add(this.DarkLabel15);
            this.fraEquipment.Controls.Add(this.cmbTool);
            this.fraEquipment.Controls.Add(this.DarkLabel14);
            this.fraEquipment.ForeColor = System.Drawing.Color.Gainsboro;
            this.fraEquipment.Location = new System.Drawing.Point(217, 245);
            this.fraEquipment.Name = "fraEquipment";
            this.fraEquipment.Size = new System.Drawing.Size(450, 245);
            this.fraEquipment.TabIndex = 2;
            this.fraEquipment.TabStop = false;
            this.fraEquipment.Text = "Equipment Settings";
            // 
            // DarkGroupBox3
            // 
            this.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox3.Controls.Add(this.cmbAmmo);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel25);
            this.DarkGroupBox3.Controls.Add(this.cmbProjectile);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel24);
            this.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox3.Location = new System.Drawing.Point(119, 167);
            this.DarkGroupBox3.Name = "DarkGroupBox3";
            this.DarkGroupBox3.Size = new System.Drawing.Size(325, 69);
            this.DarkGroupBox3.TabIndex = 60;
            this.DarkGroupBox3.TabStop = false;
            this.DarkGroupBox3.Text = "Projectile Settings";
            // 
            // cmbAmmo
            // 
            this.cmbAmmo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbAmmo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbAmmo.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbAmmo.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbAmmo.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbAmmo.ButtonIcon")));
            this.cmbAmmo.DrawDropdownHoverOutline = false;
            this.cmbAmmo.DrawFocusRectangle = false;
            this.cmbAmmo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAmmo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAmmo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAmmo.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbAmmo.FormattingEnabled = true;
            this.cmbAmmo.Location = new System.Drawing.Point(64, 40);
            this.cmbAmmo.Name = "cmbAmmo";
            this.cmbAmmo.Size = new System.Drawing.Size(254, 21);
            this.cmbAmmo.TabIndex = 3;
            this.cmbAmmo.Text = null;
            this.cmbAmmo.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbAmmo.SelectedIndexChanged += new System.EventHandler(this.CmbAmmo_SelectedIndexChanged);
            // 
            // DarkLabel25
            // 
            this.DarkLabel25.AutoSize = true;
            this.DarkLabel25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel25.Location = new System.Drawing.Point(16, 43);
            this.DarkLabel25.Name = "DarkLabel25";
            this.DarkLabel25.Size = new System.Drawing.Size(39, 13);
            this.DarkLabel25.TabIndex = 2;
            this.DarkLabel25.Text = "Ammo:";
            // 
            // cmbProjectile
            // 
            this.cmbProjectile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbProjectile.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbProjectile.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbProjectile.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbProjectile.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbProjectile.ButtonIcon")));
            this.cmbProjectile.DrawDropdownHoverOutline = false;
            this.cmbProjectile.DrawFocusRectangle = false;
            this.cmbProjectile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbProjectile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProjectile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProjectile.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbProjectile.FormattingEnabled = true;
            this.cmbProjectile.Location = new System.Drawing.Point(64, 13);
            this.cmbProjectile.Name = "cmbProjectile";
            this.cmbProjectile.Size = new System.Drawing.Size(254, 21);
            this.cmbProjectile.TabIndex = 1;
            this.cmbProjectile.Text = null;
            this.cmbProjectile.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbProjectile.SelectedIndexChanged += new System.EventHandler(this.CmbProjectile_SelectedIndexChanged);
            // 
            // DarkLabel24
            // 
            this.DarkLabel24.AutoSize = true;
            this.DarkLabel24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel24.Location = new System.Drawing.Point(5, 16);
            this.DarkLabel24.Name = "DarkLabel24";
            this.DarkLabel24.Size = new System.Drawing.Size(53, 13);
            this.DarkLabel24.TabIndex = 0;
            this.DarkLabel24.Text = "Projectile:";
            // 
            // nudPaperdoll
            // 
            this.nudPaperdoll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudPaperdoll.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudPaperdoll.Location = new System.Drawing.Point(66, 216);
            this.nudPaperdoll.Name = "nudPaperdoll";
            this.nudPaperdoll.Size = new System.Drawing.Size(47, 20);
            this.nudPaperdoll.TabIndex = 59;
            this.nudPaperdoll.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPaperdoll.Click += new System.EventHandler(this.NudPaperdoll_ValueChanged);
            // 
            // DarkLabel23
            // 
            this.DarkLabel23.AutoSize = true;
            this.DarkLabel23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel23.Location = new System.Drawing.Point(6, 218);
            this.DarkLabel23.Name = "DarkLabel23";
            this.DarkLabel23.Size = new System.Drawing.Size(54, 13);
            this.DarkLabel23.TabIndex = 58;
            this.DarkLabel23.Text = "Paperdoll:";
            // 
            // picPaperdoll
            // 
            this.picPaperdoll.BackColor = System.Drawing.Color.Black;
            this.picPaperdoll.Location = new System.Drawing.Point(6, 167);
            this.picPaperdoll.Name = "picPaperdoll";
            this.picPaperdoll.Size = new System.Drawing.Size(107, 48);
            this.picPaperdoll.TabIndex = 57;
            this.picPaperdoll.TabStop = false;
            this.picPaperdoll.Paint += new System.Windows.Forms.PaintEventHandler(this.PicPaperdoll_Paint);
            // 
            // DarkGroupBox2
            // 
            this.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox2.Controls.Add(this.nudSpirit);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel22);
            this.DarkGroupBox2.Controls.Add(this.nudIntelligence);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel21);
            this.DarkGroupBox2.Controls.Add(this.nudVitality);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel20);
            this.DarkGroupBox2.Controls.Add(this.nudLuck);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel19);
            this.DarkGroupBox2.Controls.Add(this.nudEndurance);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel18);
            this.DarkGroupBox2.Controls.Add(this.nudStrength);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel17);
            this.DarkGroupBox2.Controls.Add(this.chkRandomize);
            this.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox2.Location = new System.Drawing.Point(6, 85);
            this.DarkGroupBox2.Name = "DarkGroupBox2";
            this.DarkGroupBox2.Size = new System.Drawing.Size(438, 76);
            this.DarkGroupBox2.TabIndex = 9;
            this.DarkGroupBox2.TabStop = false;
            this.DarkGroupBox2.Text = "Stats";
            // 
            // nudSpirit
            // 
            this.nudSpirit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpirit.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpirit.Location = new System.Drawing.Point(284, 44);
            this.nudSpirit.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSpirit.Name = "nudSpirit";
            this.nudSpirit.Size = new System.Drawing.Size(50, 20);
            this.nudSpirit.TabIndex = 12;
            this.nudSpirit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpirit.Click += new System.EventHandler(this.NudSpirit_ValueChanged);
            // 
            // DarkLabel22
            // 
            this.DarkLabel22.AutoSize = true;
            this.DarkLabel22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel22.Location = new System.Drawing.Point(242, 46);
            this.DarkLabel22.Name = "DarkLabel22";
            this.DarkLabel22.Size = new System.Drawing.Size(33, 13);
            this.DarkLabel22.TabIndex = 11;
            this.DarkLabel22.Text = "Spirit:";
            // 
            // nudIntelligence
            // 
            this.nudIntelligence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudIntelligence.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudIntelligence.Location = new System.Drawing.Point(167, 44);
            this.nudIntelligence.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudIntelligence.Name = "nudIntelligence";
            this.nudIntelligence.Size = new System.Drawing.Size(50, 20);
            this.nudIntelligence.TabIndex = 10;
            this.nudIntelligence.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudIntelligence.Click += new System.EventHandler(this.NudIntelligence_ValueChanged);
            // 
            // DarkLabel21
            // 
            this.DarkLabel21.AutoSize = true;
            this.DarkLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel21.Location = new System.Drawing.Point(103, 46);
            this.DarkLabel21.Name = "DarkLabel21";
            this.DarkLabel21.Size = new System.Drawing.Size(64, 13);
            this.DarkLabel21.TabIndex = 9;
            this.DarkLabel21.Text = "Intelligence:";
            // 
            // nudVitality
            // 
            this.nudVitality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudVitality.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudVitality.Location = new System.Drawing.Point(47, 44);
            this.nudVitality.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudVitality.Name = "nudVitality";
            this.nudVitality.Size = new System.Drawing.Size(50, 20);
            this.nudVitality.TabIndex = 8;
            this.nudVitality.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudVitality.Click += new System.EventHandler(this.NudVitality_ValueChanged);
            // 
            // DarkLabel20
            // 
            this.DarkLabel20.AutoSize = true;
            this.DarkLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel20.Location = new System.Drawing.Point(5, 46);
            this.DarkLabel20.Name = "DarkLabel20";
            this.DarkLabel20.Size = new System.Drawing.Size(40, 13);
            this.DarkLabel20.TabIndex = 7;
            this.DarkLabel20.Text = "Vitality:";
            // 
            // nudLuck
            // 
            this.nudLuck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudLuck.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLuck.Location = new System.Drawing.Point(372, 18);
            this.nudLuck.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudLuck.Name = "nudLuck";
            this.nudLuck.Size = new System.Drawing.Size(50, 20);
            this.nudLuck.TabIndex = 6;
            this.nudLuck.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLuck.Click += new System.EventHandler(this.NudLuck_ValueChanged);
            // 
            // DarkLabel19
            // 
            this.DarkLabel19.AutoSize = true;
            this.DarkLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel19.Location = new System.Drawing.Point(340, 20);
            this.DarkLabel19.Name = "DarkLabel19";
            this.DarkLabel19.Size = new System.Drawing.Size(34, 13);
            this.DarkLabel19.TabIndex = 5;
            this.DarkLabel19.Text = "Luck:";
            // 
            // nudEndurance
            // 
            this.nudEndurance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudEndurance.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudEndurance.Location = new System.Drawing.Point(284, 18);
            this.nudEndurance.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudEndurance.Name = "nudEndurance";
            this.nudEndurance.Size = new System.Drawing.Size(50, 20);
            this.nudEndurance.TabIndex = 4;
            this.nudEndurance.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudEndurance.Click += new System.EventHandler(this.NudEndurance_ValueChanged);
            // 
            // DarkLabel18
            // 
            this.DarkLabel18.AutoSize = true;
            this.DarkLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel18.Location = new System.Drawing.Point(223, 20);
            this.DarkLabel18.Name = "DarkLabel18";
            this.DarkLabel18.Size = new System.Drawing.Size(62, 13);
            this.DarkLabel18.TabIndex = 3;
            this.DarkLabel18.Text = "Endurance:";
            // 
            // nudStrength
            // 
            this.nudStrength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudStrength.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudStrength.Location = new System.Drawing.Point(167, 18);
            this.nudStrength.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudStrength.Name = "nudStrength";
            this.nudStrength.Size = new System.Drawing.Size(50, 20);
            this.nudStrength.TabIndex = 2;
            this.nudStrength.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudStrength.Click += new System.EventHandler(this.NudStrength_ValueChanged);
            // 
            // DarkLabel17
            // 
            this.DarkLabel17.AutoSize = true;
            this.DarkLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel17.Location = new System.Drawing.Point(118, 20);
            this.DarkLabel17.Name = "DarkLabel17";
            this.DarkLabel17.Size = new System.Drawing.Size(50, 13);
            this.DarkLabel17.TabIndex = 1;
            this.DarkLabel17.Text = "Strength:";
            // 
            // chkRandomize
            // 
            this.chkRandomize.AutoSize = true;
            this.chkRandomize.Location = new System.Drawing.Point(6, 19);
            this.chkRandomize.Name = "chkRandomize";
            this.chkRandomize.Size = new System.Drawing.Size(106, 17);
            this.chkRandomize.TabIndex = 0;
            this.chkRandomize.Text = "Randomize Stats";
            this.chkRandomize.CheckedChanged += new System.EventHandler(this.ChkRandomize_CheckedChanged);
            // 
            // cmbKnockBackTiles
            // 
            this.cmbKnockBackTiles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbKnockBackTiles.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbKnockBackTiles.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbKnockBackTiles.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbKnockBackTiles.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbKnockBackTiles.ButtonIcon")));
            this.cmbKnockBackTiles.DrawDropdownHoverOutline = false;
            this.cmbKnockBackTiles.DrawFocusRectangle = false;
            this.cmbKnockBackTiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbKnockBackTiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKnockBackTiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbKnockBackTiles.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbKnockBackTiles.FormattingEnabled = true;
            this.cmbKnockBackTiles.Items.AddRange(new object[] {
            "No KnockBack",
            "1 Tile",
            "2 Tiles",
            "3 Tiles",
            "4 Tiles",
            "5 Tiles"});
            this.cmbKnockBackTiles.Location = new System.Drawing.Point(325, 58);
            this.cmbKnockBackTiles.Name = "cmbKnockBackTiles";
            this.cmbKnockBackTiles.Size = new System.Drawing.Size(119, 21);
            this.cmbKnockBackTiles.TabIndex = 8;
            this.cmbKnockBackTiles.Text = "No KnockBack";
            this.cmbKnockBackTiles.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbKnockBackTiles.SelectedIndexChanged += new System.EventHandler(this.CmbKnockBackTiles_SelectedIndexChanged);
            // 
            // DarkLabel16
            // 
            this.DarkLabel16.AutoSize = true;
            this.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel16.Location = new System.Drawing.Point(301, 61);
            this.DarkLabel16.Name = "DarkLabel16";
            this.DarkLabel16.Size = new System.Drawing.Size(18, 13);
            this.DarkLabel16.TabIndex = 7;
            this.DarkLabel16.Text = "Of";
            // 
            // chkKnockBack
            // 
            this.chkKnockBack.AutoSize = true;
            this.chkKnockBack.Location = new System.Drawing.Point(197, 60);
            this.chkKnockBack.Name = "chkKnockBack";
            this.chkKnockBack.Size = new System.Drawing.Size(104, 17);
            this.chkKnockBack.TabIndex = 6;
            this.chkKnockBack.Text = "Has KnockBack";
            this.chkKnockBack.CheckedChanged += new System.EventHandler(this.ChkKnockBack_CheckedChanged);
            // 
            // nudSpeed
            // 
            this.nudSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpeed.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpeed.Location = new System.Drawing.Point(99, 59);
            this.nudSpeed.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(92, 20);
            this.nudSpeed.TabIndex = 5;
            this.nudSpeed.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpeed.Click += new System.EventHandler(this.NudSpeed_ValueChanged);
            // 
            // lblSpeed
            // 
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblSpeed.Location = new System.Drawing.Point(6, 61);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(59, 13);
            this.lblSpeed.TabIndex = 4;
            this.lblSpeed.Text = "Speed: 0.1";
            // 
            // nudDamage
            // 
            this.nudDamage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudDamage.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDamage.Location = new System.Drawing.Point(253, 20);
            this.nudDamage.Name = "nudDamage";
            this.nudDamage.Size = new System.Drawing.Size(120, 20);
            this.nudDamage.TabIndex = 3;
            this.nudDamage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDamage.Click += new System.EventHandler(this.NudDamage_ValueChanged);
            // 
            // DarkLabel15
            // 
            this.DarkLabel15.AutoSize = true;
            this.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel15.Location = new System.Drawing.Point(197, 22);
            this.DarkLabel15.Name = "DarkLabel15";
            this.DarkLabel15.Size = new System.Drawing.Size(50, 13);
            this.DarkLabel15.TabIndex = 2;
            this.DarkLabel15.Text = "Damage:";
            // 
            // cmbTool
            // 
            this.cmbTool.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbTool.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbTool.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbTool.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbTool.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbTool.ButtonIcon")));
            this.cmbTool.DrawDropdownHoverOutline = false;
            this.cmbTool.DrawFocusRectangle = false;
            this.cmbTool.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbTool.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbTool.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbTool.FormattingEnabled = true;
            this.cmbTool.Items.AddRange(new object[] {
            "None",
            "Hatchet",
            "Rod",
            "Pickaxe",
            "Hoe"});
            this.cmbTool.Location = new System.Drawing.Point(70, 19);
            this.cmbTool.Name = "cmbTool";
            this.cmbTool.Size = new System.Drawing.Size(121, 21);
            this.cmbTool.TabIndex = 1;
            this.cmbTool.Text = "None";
            this.cmbTool.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbTool.SelectedIndexChanged += new System.EventHandler(this.CmbTool_SelectedIndexChanged);
            // 
            // DarkLabel14
            // 
            this.DarkLabel14.AutoSize = true;
            this.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel14.Location = new System.Drawing.Point(6, 22);
            this.DarkLabel14.Name = "DarkLabel14";
            this.DarkLabel14.Size = new System.Drawing.Size(58, 13);
            this.DarkLabel14.TabIndex = 0;
            this.DarkLabel14.Text = "Tool Type:";
            // 
            // btnBasics
            // 
            this.btnBasics.Location = new System.Drawing.Point(217, 8);
            this.btnBasics.Name = "btnBasics";
            this.btnBasics.Padding = new System.Windows.Forms.Padding(5);
            this.btnBasics.Size = new System.Drawing.Size(75, 23);
            this.btnBasics.TabIndex = 3;
            this.btnBasics.Text = "Basics";
            this.btnBasics.Click += new System.EventHandler(this.BtnBasics_Click);
            // 
            // btnRequirements
            // 
            this.btnRequirements.Location = new System.Drawing.Point(298, 8);
            this.btnRequirements.Name = "btnRequirements";
            this.btnRequirements.Padding = new System.Windows.Forms.Padding(5);
            this.btnRequirements.Size = new System.Drawing.Size(92, 23);
            this.btnRequirements.TabIndex = 4;
            this.btnRequirements.Text = "Requirements";
            this.btnRequirements.Click += new System.EventHandler(this.BtnRequirements_Click);
            // 
            // fraRequirements
            // 
            this.fraRequirements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.fraRequirements.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.fraRequirements.Controls.Add(this.DarkGroupBox4);
            this.fraRequirements.Controls.Add(this.DarkLabel28);
            this.fraRequirements.Controls.Add(this.nudLevelReq);
            this.fraRequirements.Controls.Add(this.cmbAccessReq);
            this.fraRequirements.Controls.Add(this.DarkLabel27);
            this.fraRequirements.Controls.Add(this.cmbClassReq);
            this.fraRequirements.Controls.Add(this.DarkLabel26);
            this.fraRequirements.ForeColor = System.Drawing.Color.Gainsboro;
            this.fraRequirements.Location = new System.Drawing.Point(217, 37);
            this.fraRequirements.Name = "fraRequirements";
            this.fraRequirements.Size = new System.Drawing.Size(450, 202);
            this.fraRequirements.TabIndex = 5;
            this.fraRequirements.TabStop = false;
            this.fraRequirements.Text = "Requirements";
            this.fraRequirements.Visible = false;
            // 
            // DarkGroupBox4
            // 
            this.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox4.Controls.Add(this.nudSprReq);
            this.DarkGroupBox4.Controls.Add(this.DarkLabel32);
            this.DarkGroupBox4.Controls.Add(this.nudIntReq);
            this.DarkGroupBox4.Controls.Add(this.DarkLabel33);
            this.DarkGroupBox4.Controls.Add(this.nudVitReq);
            this.DarkGroupBox4.Controls.Add(this.DarkLabel34);
            this.DarkGroupBox4.Controls.Add(this.nudLuckReq);
            this.DarkGroupBox4.Controls.Add(this.DarkLabel29);
            this.DarkGroupBox4.Controls.Add(this.nudEndReq);
            this.DarkGroupBox4.Controls.Add(this.DarkLabel30);
            this.DarkGroupBox4.Controls.Add(this.nudStrReq);
            this.DarkGroupBox4.Controls.Add(this.DarkLabel31);
            this.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox4.Location = new System.Drawing.Point(6, 95);
            this.DarkGroupBox4.Name = "DarkGroupBox4";
            this.DarkGroupBox4.Size = new System.Drawing.Size(438, 100);
            this.DarkGroupBox4.TabIndex = 6;
            this.DarkGroupBox4.TabStop = false;
            this.DarkGroupBox4.Text = "Stat Requirements";
            // 
            // nudSprReq
            // 
            this.nudSprReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSprReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSprReq.Location = new System.Drawing.Point(292, 64);
            this.nudSprReq.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudSprReq.Name = "nudSprReq";
            this.nudSprReq.Size = new System.Drawing.Size(50, 20);
            this.nudSprReq.TabIndex = 18;
            this.nudSprReq.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSprReq.Click += new System.EventHandler(this.NudSprReq_ValueChanged);
            // 
            // DarkLabel32
            // 
            this.DarkLabel32.AutoSize = true;
            this.DarkLabel32.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel32.Location = new System.Drawing.Point(250, 66);
            this.DarkLabel32.Name = "DarkLabel32";
            this.DarkLabel32.Size = new System.Drawing.Size(33, 13);
            this.DarkLabel32.TabIndex = 17;
            this.DarkLabel32.Text = "Spirit:";
            // 
            // nudIntReq
            // 
            this.nudIntReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudIntReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudIntReq.Location = new System.Drawing.Point(175, 64);
            this.nudIntReq.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudIntReq.Name = "nudIntReq";
            this.nudIntReq.Size = new System.Drawing.Size(50, 20);
            this.nudIntReq.TabIndex = 16;
            this.nudIntReq.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudIntReq.Click += new System.EventHandler(this.NudIntReq_ValueChanged);
            // 
            // DarkLabel33
            // 
            this.DarkLabel33.AutoSize = true;
            this.DarkLabel33.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel33.Location = new System.Drawing.Point(111, 66);
            this.DarkLabel33.Name = "DarkLabel33";
            this.DarkLabel33.Size = new System.Drawing.Size(64, 13);
            this.DarkLabel33.TabIndex = 15;
            this.DarkLabel33.Text = "Intelligence:";
            // 
            // nudVitReq
            // 
            this.nudVitReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudVitReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudVitReq.Location = new System.Drawing.Point(55, 64);
            this.nudVitReq.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudVitReq.Name = "nudVitReq";
            this.nudVitReq.Size = new System.Drawing.Size(50, 20);
            this.nudVitReq.TabIndex = 14;
            this.nudVitReq.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudVitReq.Click += new System.EventHandler(this.NudVitReq_ValueChanged);
            // 
            // DarkLabel34
            // 
            this.DarkLabel34.AutoSize = true;
            this.DarkLabel34.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel34.Location = new System.Drawing.Point(13, 66);
            this.DarkLabel34.Name = "DarkLabel34";
            this.DarkLabel34.Size = new System.Drawing.Size(40, 13);
            this.DarkLabel34.TabIndex = 13;
            this.DarkLabel34.Text = "Vitality:";
            // 
            // nudLuckReq
            // 
            this.nudLuckReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudLuckReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLuckReq.Location = new System.Drawing.Point(292, 22);
            this.nudLuckReq.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudLuckReq.Name = "nudLuckReq";
            this.nudLuckReq.Size = new System.Drawing.Size(50, 20);
            this.nudLuckReq.TabIndex = 12;
            this.nudLuckReq.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLuckReq.Click += new System.EventHandler(this.NudLuckReq_ValueChanged);
            // 
            // DarkLabel29
            // 
            this.DarkLabel29.AutoSize = true;
            this.DarkLabel29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel29.Location = new System.Drawing.Point(260, 24);
            this.DarkLabel29.Name = "DarkLabel29";
            this.DarkLabel29.Size = new System.Drawing.Size(34, 13);
            this.DarkLabel29.TabIndex = 11;
            this.DarkLabel29.Text = "Luck:";
            // 
            // nudEndReq
            // 
            this.nudEndReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudEndReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudEndReq.Location = new System.Drawing.Point(175, 22);
            this.nudEndReq.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudEndReq.Name = "nudEndReq";
            this.nudEndReq.Size = new System.Drawing.Size(50, 20);
            this.nudEndReq.TabIndex = 10;
            this.nudEndReq.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudEndReq.Click += new System.EventHandler(this.NudEndReq_ValueChanged);
            // 
            // DarkLabel30
            // 
            this.DarkLabel30.AutoSize = true;
            this.DarkLabel30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel30.Location = new System.Drawing.Point(114, 24);
            this.DarkLabel30.Name = "DarkLabel30";
            this.DarkLabel30.Size = new System.Drawing.Size(62, 13);
            this.DarkLabel30.TabIndex = 9;
            this.DarkLabel30.Text = "Endurance:";
            // 
            // nudStrReq
            // 
            this.nudStrReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudStrReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudStrReq.Location = new System.Drawing.Point(55, 22);
            this.nudStrReq.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudStrReq.Name = "nudStrReq";
            this.nudStrReq.Size = new System.Drawing.Size(50, 20);
            this.nudStrReq.TabIndex = 8;
            this.nudStrReq.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudStrReq.Click += new System.EventHandler(this.NudStrReq_ValueChanged);
            // 
            // DarkLabel31
            // 
            this.DarkLabel31.AutoSize = true;
            this.DarkLabel31.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel31.Location = new System.Drawing.Point(6, 24);
            this.DarkLabel31.Name = "DarkLabel31";
            this.DarkLabel31.Size = new System.Drawing.Size(50, 13);
            this.DarkLabel31.TabIndex = 7;
            this.DarkLabel31.Text = "Strength:";
            // 
            // DarkLabel28
            // 
            this.DarkLabel28.AutoSize = true;
            this.DarkLabel28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel28.Location = new System.Drawing.Point(6, 68);
            this.DarkLabel28.Name = "DarkLabel28";
            this.DarkLabel28.Size = new System.Drawing.Size(99, 13);
            this.DarkLabel28.TabIndex = 5;
            this.DarkLabel28.Text = "Level Requirement:";
            // 
            // nudLevelReq
            // 
            this.nudLevelReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudLevelReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLevelReq.Location = new System.Drawing.Point(120, 66);
            this.nudLevelReq.Name = "nudLevelReq";
            this.nudLevelReq.Size = new System.Drawing.Size(120, 20);
            this.nudLevelReq.TabIndex = 4;
            this.nudLevelReq.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLevelReq.Click += new System.EventHandler(this.NudLevelReq_ValueChanged);
            // 
            // cmbAccessReq
            // 
            this.cmbAccessReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbAccessReq.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbAccessReq.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbAccessReq.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbAccessReq.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbAccessReq.ButtonIcon")));
            this.cmbAccessReq.DrawDropdownHoverOutline = false;
            this.cmbAccessReq.DrawFocusRectangle = false;
            this.cmbAccessReq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbAccessReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccessReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbAccessReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbAccessReq.FormattingEnabled = true;
            this.cmbAccessReq.Items.AddRange(new object[] {
            "Player",
            "Monitor",
            "Mapper",
            "Developer",
            "Creator"});
            this.cmbAccessReq.Location = new System.Drawing.Point(120, 39);
            this.cmbAccessReq.Name = "cmbAccessReq";
            this.cmbAccessReq.Size = new System.Drawing.Size(177, 21);
            this.cmbAccessReq.TabIndex = 3;
            this.cmbAccessReq.Text = "Player";
            this.cmbAccessReq.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbAccessReq.SelectedIndexChanged += new System.EventHandler(this.CmbAccessReq_SelectedIndexChanged);
            // 
            // DarkLabel27
            // 
            this.DarkLabel27.AutoSize = true;
            this.DarkLabel27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel27.Location = new System.Drawing.Point(6, 43);
            this.DarkLabel27.Name = "DarkLabel27";
            this.DarkLabel27.Size = new System.Drawing.Size(108, 13);
            this.DarkLabel27.TabIndex = 2;
            this.DarkLabel27.Text = "Access Requirement:";
            // 
            // cmbClassReq
            // 
            this.cmbClassReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbClassReq.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbClassReq.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbClassReq.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbClassReq.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbClassReq.ButtonIcon")));
            this.cmbClassReq.DrawDropdownHoverOutline = false;
            this.cmbClassReq.DrawFocusRectangle = false;
            this.cmbClassReq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClassReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClassReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbClassReq.FormattingEnabled = true;
            this.cmbClassReq.Location = new System.Drawing.Point(120, 13);
            this.cmbClassReq.Name = "cmbClassReq";
            this.cmbClassReq.Size = new System.Drawing.Size(177, 21);
            this.cmbClassReq.TabIndex = 1;
            this.cmbClassReq.Text = null;
            this.cmbClassReq.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbClassReq.SelectedIndexChanged += new System.EventHandler(this.CmbClassReq_SelectedIndexChanged);
            // 
            // DarkLabel26
            // 
            this.DarkLabel26.AutoSize = true;
            this.DarkLabel26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel26.Location = new System.Drawing.Point(6, 16);
            this.DarkLabel26.Name = "DarkLabel26";
            this.DarkLabel26.Size = new System.Drawing.Size(98, 13);
            this.DarkLabel26.TabIndex = 0;
            this.DarkLabel26.Text = "Class Requirement:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(8, 409);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(196, 23);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(8, 438);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(5);
            this.btnDelete.Size = new System.Drawing.Size(196, 23);
            this.btnDelete.TabIndex = 7;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(8, 467);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(196, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // fraFurniture
            // 
            this.fraFurniture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.fraFurniture.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.fraFurniture.Controls.Add(this.nudFurniture);
            this.fraFurniture.Controls.Add(this.DarkLabel37);
            this.fraFurniture.Controls.Add(this.lblSetOption);
            this.fraFurniture.Controls.Add(this.optSetFringe);
            this.fraFurniture.Controls.Add(this.optSetBlocks);
            this.fraFurniture.Controls.Add(this.optNoFurnitureEditing);
            this.fraFurniture.Controls.Add(this.cmbFurnitureType);
            this.fraFurniture.Controls.Add(this.DarkLabel36);
            this.fraFurniture.Controls.Add(this.picFurniture);
            this.fraFurniture.ForeColor = System.Drawing.Color.Gainsboro;
            this.fraFurniture.Location = new System.Drawing.Point(217, 245);
            this.fraFurniture.Name = "fraFurniture";
            this.fraFurniture.Size = new System.Drawing.Size(450, 245);
            this.fraFurniture.TabIndex = 9;
            this.fraFurniture.TabStop = false;
            this.fraFurniture.Text = "Furniture Settings";
            // 
            // nudFurniture
            // 
            this.nudFurniture.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudFurniture.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudFurniture.Location = new System.Drawing.Point(368, 172);
            this.nudFurniture.Name = "nudFurniture";
            this.nudFurniture.Size = new System.Drawing.Size(76, 20);
            this.nudFurniture.TabIndex = 15;
            this.nudFurniture.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudFurniture.Click += new System.EventHandler(this.NudFurniture_ValueChanged);
            // 
            // DarkLabel37
            // 
            this.DarkLabel37.AutoSize = true;
            this.DarkLabel37.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel37.Location = new System.Drawing.Point(295, 174);
            this.DarkLabel37.Name = "DarkLabel37";
            this.DarkLabel37.Size = new System.Drawing.Size(51, 13);
            this.DarkLabel37.TabIndex = 14;
            this.DarkLabel37.Text = "Furniture:";
            // 
            // lblSetOption
            // 
            this.lblSetOption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblSetOption.Location = new System.Drawing.Point(86, 66);
            this.lblSetOption.Name = "lblSetOption";
            this.lblSetOption.Size = new System.Drawing.Size(203, 103);
            this.lblSetOption.TabIndex = 13;
            this.lblSetOption.Text = "Set Blocks: Os are passable and Xs are not. Simply place Xs where you do not want" +
    " the player to walk.";
            // 
            // optSetFringe
            // 
            this.optSetFringe.AutoSize = true;
            this.optSetFringe.Location = new System.Drawing.Point(6, 108);
            this.optSetFringe.Name = "optSetFringe";
            this.optSetFringe.Size = new System.Drawing.Size(73, 17);
            this.optSetFringe.TabIndex = 12;
            this.optSetFringe.Text = "Set Fringe";
            this.optSetFringe.CheckedChanged += new System.EventHandler(this.OptSetFringe_CheckedChanged);
            // 
            // optSetBlocks
            // 
            this.optSetBlocks.AutoSize = true;
            this.optSetBlocks.Location = new System.Drawing.Point(6, 85);
            this.optSetBlocks.Name = "optSetBlocks";
            this.optSetBlocks.Size = new System.Drawing.Size(76, 17);
            this.optSetBlocks.TabIndex = 11;
            this.optSetBlocks.Text = "Set Blocks";
            this.optSetBlocks.CheckedChanged += new System.EventHandler(this.OptSetBlocks_CheckedChanged);
            // 
            // optNoFurnitureEditing
            // 
            this.optNoFurnitureEditing.AutoSize = true;
            this.optNoFurnitureEditing.Checked = true;
            this.optNoFurnitureEditing.Location = new System.Drawing.Point(6, 62);
            this.optNoFurnitureEditing.Name = "optNoFurnitureEditing";
            this.optNoFurnitureEditing.Size = new System.Drawing.Size(74, 17);
            this.optNoFurnitureEditing.TabIndex = 10;
            this.optNoFurnitureEditing.TabStop = true;
            this.optNoFurnitureEditing.Text = "No Editing";
            this.optNoFurnitureEditing.CheckedChanged += new System.EventHandler(this.OptNoFurnitureEditing_CheckedChanged);
            // 
            // cmbFurnitureType
            // 
            this.cmbFurnitureType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbFurnitureType.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbFurnitureType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbFurnitureType.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbFurnitureType.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbFurnitureType.ButtonIcon")));
            this.cmbFurnitureType.DrawDropdownHoverOutline = false;
            this.cmbFurnitureType.DrawFocusRectangle = false;
            this.cmbFurnitureType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFurnitureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFurnitureType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFurnitureType.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbFurnitureType.FormattingEnabled = true;
            this.cmbFurnitureType.Items.AddRange(new object[] {
            "Normal"});
            this.cmbFurnitureType.Location = new System.Drawing.Point(87, 24);
            this.cmbFurnitureType.Name = "cmbFurnitureType";
            this.cmbFurnitureType.Size = new System.Drawing.Size(202, 21);
            this.cmbFurnitureType.TabIndex = 9;
            this.cmbFurnitureType.Text = "Normal";
            this.cmbFurnitureType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbFurnitureType.SelectedIndexChanged += new System.EventHandler(this.CmbFurnitureType_SelectedIndexChanged);
            // 
            // DarkLabel36
            // 
            this.DarkLabel36.AutoSize = true;
            this.DarkLabel36.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel36.Location = new System.Drawing.Point(6, 27);
            this.DarkLabel36.Name = "DarkLabel36";
            this.DarkLabel36.Size = new System.Drawing.Size(78, 13);
            this.DarkLabel36.TabIndex = 8;
            this.DarkLabel36.Text = "Furniture Type:";
            // 
            // picFurniture
            // 
            this.picFurniture.BackColor = System.Drawing.Color.Black;
            this.picFurniture.Location = new System.Drawing.Point(294, 19);
            this.picFurniture.Name = "picFurniture";
            this.picFurniture.Size = new System.Drawing.Size(150, 150);
            this.picFurniture.TabIndex = 7;
            this.picFurniture.TabStop = false;
            this.picFurniture.Paint += new System.Windows.Forms.PaintEventHandler(this.PicFurniture_Paint);
            this.picFurniture.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PicFurniture_MouseDown);
            // 
            // FrmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(677, 498);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRequirements);
            this.Controls.Add(this.btnBasics);
            this.Controls.Add(this.DarkGroupBox1);
            this.Controls.Add(this.fraBasics);
            this.Controls.Add(this.fraEquipment);
            this.Controls.Add(this.fraFurniture);
            this.Controls.Add(this.fraRequirements);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmItem";
            this.Text = "Item Editor";
            this.Load += new System.EventHandler(this.FrmEditor_Item_Load);
            this.DarkGroupBox1.ResumeLayout(false);
            this.fraBasics.ResumeLayout(false);
            this.fraBasics.PerformLayout();
            this.fraPet.ResumeLayout(false);
            this.fraPet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudItemLvl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRarity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPic)).EndInit();
            this.fraSkill.ResumeLayout(false);
            this.fraSkill.PerformLayout();
            this.fraRecipe.ResumeLayout(false);
            this.fraRecipe.PerformLayout();
            this.fraVitals.ResumeLayout(false);
            this.fraVitals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitalMod)).EndInit();
            this.fraEquipment.ResumeLayout(false);
            this.fraEquipment.PerformLayout();
            this.DarkGroupBox3.ResumeLayout(false);
            this.DarkGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudPaperdoll)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPaperdoll)).EndInit();
            this.DarkGroupBox2.ResumeLayout(false);
            this.DarkGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpirit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntelligence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndurance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamage)).EndInit();
            this.fraRequirements.ResumeLayout(false);
            this.fraRequirements.PerformLayout();
            this.DarkGroupBox4.ResumeLayout(false);
            this.DarkGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSprReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuckReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevelReq)).EndInit();
            this.fraFurniture.ResumeLayout(false);
            this.fraFurniture.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudFurniture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFurniture)).EndInit();
            this.ResumeLayout(false);

		}
		
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox1;
		internal ListBox lstIndex;
		internal DarkUI.Controls.DarkGroupBox fraBasics;
		internal DarkUI.Controls.DarkTextBox txtName;
		internal DarkUI.Controls.DarkLabel DarkLabel1;
		internal DarkUI.Controls.DarkNumericUpDown nudPic;
		internal DarkUI.Controls.DarkLabel DarkLabel2;
		internal DarkUI.Controls.DarkNumericUpDown nudRarity;
		internal DarkUI.Controls.DarkLabel DarkLabel3;
		internal PictureBox picItem;
		internal DarkUI.Controls.DarkComboBox cmbType;
		internal DarkUI.Controls.DarkLabel DarkLabel4;
		internal DarkUI.Controls.DarkComboBox cmbSubType;
		internal DarkUI.Controls.DarkLabel DarkLabel5;
		internal DarkUI.Controls.DarkCheckBox chkStackable;
		internal DarkUI.Controls.DarkComboBox cmbBind;
		internal DarkUI.Controls.DarkLabel DarkLabel6;
		internal DarkUI.Controls.DarkNumericUpDown nudPrice;
		internal DarkUI.Controls.DarkLabel DarkLabel7;
		internal DarkUI.Controls.DarkNumericUpDown nudItemLvl;
		internal DarkUI.Controls.DarkLabel DarkLabel8;
		internal DarkUI.Controls.DarkComboBox cmbAnimation;
		internal DarkUI.Controls.DarkLabel DarkLabel9;
		internal DarkUI.Controls.DarkTextBox txtDescription;
		internal DarkUI.Controls.DarkLabel DarkLabel10;
		internal DarkUI.Controls.DarkGroupBox fraVitals;
		internal DarkUI.Controls.DarkNumericUpDown nudVitalMod;
		internal DarkUI.Controls.DarkLabel DarkLabel11;
		internal DarkUI.Controls.DarkGroupBox fraSkill;
		internal DarkUI.Controls.DarkLabel DarkLabel12;
		internal DarkUI.Controls.DarkComboBox cmbSkills;
		internal DarkUI.Controls.DarkGroupBox fraPet;
		internal DarkUI.Controls.DarkComboBox cmbPet;
		internal DarkUI.Controls.DarkLabel DarkLabel13;
		internal DarkUI.Controls.DarkGroupBox fraEquipment;
		internal DarkUI.Controls.DarkComboBox cmbTool;
		internal DarkUI.Controls.DarkLabel DarkLabel14;
		internal DarkUI.Controls.DarkLabel DarkLabel15;
		internal DarkUI.Controls.DarkNumericUpDown nudDamage;
		internal DarkUI.Controls.DarkLabel lblSpeed;
		internal DarkUI.Controls.DarkNumericUpDown nudSpeed;
		internal DarkUI.Controls.DarkCheckBox chkKnockBack;
		internal DarkUI.Controls.DarkComboBox cmbKnockBackTiles;
		internal DarkUI.Controls.DarkLabel DarkLabel16;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox2;
		internal DarkUI.Controls.DarkCheckBox chkRandomize;
		internal DarkUI.Controls.DarkLabel DarkLabel17;
		internal DarkUI.Controls.DarkNumericUpDown nudEndurance;
		internal DarkUI.Controls.DarkLabel DarkLabel18;
		internal DarkUI.Controls.DarkNumericUpDown nudStrength;
		internal DarkUI.Controls.DarkNumericUpDown nudLuck;
		internal DarkUI.Controls.DarkLabel DarkLabel19;
		internal DarkUI.Controls.DarkNumericUpDown nudVitality;
		internal DarkUI.Controls.DarkLabel DarkLabel20;
		internal DarkUI.Controls.DarkNumericUpDown nudIntelligence;
		internal DarkUI.Controls.DarkLabel DarkLabel21;
		internal DarkUI.Controls.DarkNumericUpDown nudSpirit;
		internal DarkUI.Controls.DarkLabel DarkLabel22;
		internal DarkUI.Controls.DarkNumericUpDown nudPaperdoll;
		internal DarkUI.Controls.DarkLabel DarkLabel23;
		internal PictureBox picPaperdoll;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox3;
		internal DarkUI.Controls.DarkComboBox cmbAmmo;
		internal DarkUI.Controls.DarkLabel DarkLabel25;
		internal DarkUI.Controls.DarkComboBox cmbProjectile;
		internal DarkUI.Controls.DarkLabel DarkLabel24;
		internal DarkUI.Controls.DarkButton btnBasics;
		internal DarkUI.Controls.DarkButton btnRequirements;
		internal DarkUI.Controls.DarkGroupBox fraRequirements;
		internal DarkUI.Controls.DarkComboBox cmbClassReq;
		internal DarkUI.Controls.DarkLabel DarkLabel26;
		internal DarkUI.Controls.DarkComboBox cmbAccessReq;
		internal DarkUI.Controls.DarkLabel DarkLabel27;
		internal DarkUI.Controls.DarkLabel DarkLabel28;
		internal DarkUI.Controls.DarkNumericUpDown nudLevelReq;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox4;
		internal DarkUI.Controls.DarkNumericUpDown nudSprReq;
		internal DarkUI.Controls.DarkLabel DarkLabel32;
		internal DarkUI.Controls.DarkNumericUpDown nudIntReq;
		internal DarkUI.Controls.DarkLabel DarkLabel33;
		internal DarkUI.Controls.DarkNumericUpDown nudVitReq;
		internal DarkUI.Controls.DarkLabel DarkLabel34;
		internal DarkUI.Controls.DarkNumericUpDown nudLuckReq;
		internal DarkUI.Controls.DarkLabel DarkLabel29;
		internal DarkUI.Controls.DarkNumericUpDown nudEndReq;
		internal DarkUI.Controls.DarkLabel DarkLabel30;
		internal DarkUI.Controls.DarkNumericUpDown nudStrReq;
		internal DarkUI.Controls.DarkLabel DarkLabel31;
		internal DarkUI.Controls.DarkGroupBox fraRecipe;
		internal DarkUI.Controls.DarkLabel DarkLabel35;
		internal DarkUI.Controls.DarkButton btnSave;
		internal DarkUI.Controls.DarkButton btnDelete;
		internal DarkUI.Controls.DarkButton btnCancel;
		internal DarkUI.Controls.DarkComboBox cmbRecipe;
		internal DarkUI.Controls.DarkGroupBox fraFurniture;
		internal PictureBox picFurniture;
		internal DarkUI.Controls.DarkComboBox cmbFurnitureType;
		internal DarkUI.Controls.DarkLabel DarkLabel36;
		internal DarkUI.Controls.DarkRadioButton optSetFringe;
		internal DarkUI.Controls.DarkRadioButton optSetBlocks;
		internal DarkUI.Controls.DarkRadioButton optNoFurnitureEditing;
		internal DarkUI.Controls.DarkLabel lblSetOption;
		internal DarkUI.Controls.DarkNumericUpDown nudFurniture;
		internal DarkUI.Controls.DarkLabel DarkLabel37;
	}
	
}
