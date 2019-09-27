
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
	partial class FrmResource : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResource));
            this.DarkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.lstIndex = new System.Windows.Forms.ListBox();
            this.DarkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.DarkGroupBox5 = new DarkUI.Controls.DarkGroupBox();
            this.nudRewardExp = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel13 = new DarkUI.Controls.DarkLabel();
            this.cmbRewardItem = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel12 = new DarkUI.Controls.DarkLabel();
            this.DarkGroupBox4 = new DarkUI.Controls.DarkGroupBox();
            this.nudLvlReq = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel11 = new DarkUI.Controls.DarkLabel();
            this.cmbTool = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel10 = new DarkUI.Controls.DarkLabel();
            this.cmbAnimation = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel9 = new DarkUI.Controls.DarkLabel();
            this.nudRespawn = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel8 = new DarkUI.Controls.DarkLabel();
            this.DarkGroupBox3 = new DarkUI.Controls.DarkGroupBox();
            this.nudExhaustedPic = new DarkUI.Controls.DarkNumericUpDown();
            this.nudNormalPic = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel7 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel6 = new DarkUI.Controls.DarkLabel();
            this.picExhaustedPic = new System.Windows.Forms.PictureBox();
            this.picNormalpic = new System.Windows.Forms.PictureBox();
            this.nudHealth = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel5 = new DarkUI.Controls.DarkLabel();
            this.cmbType = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel4 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel3 = new DarkUI.Controls.DarkLabel();
            this.txtMessage2 = new DarkUI.Controls.DarkTextBox();
            this.txtMessage = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel2 = new DarkUI.Controls.DarkLabel();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel1 = new DarkUI.Controls.DarkLabel();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.btnDelete = new DarkUI.Controls.DarkButton();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.DarkGroupBox1.SuspendLayout();
            this.DarkGroupBox2.SuspendLayout();
            this.DarkGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRewardExp)).BeginInit();
            this.DarkGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLvlReq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRespawn)).BeginInit();
            this.DarkGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExhaustedPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNormalPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExhaustedPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNormalpic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHealth)).BeginInit();
            this.SuspendLayout();
            // 
            // DarkGroupBox1
            // 
            this.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox1.Controls.Add(this.lstIndex);
            this.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox1.Location = new System.Drawing.Point(3, 2);
            this.DarkGroupBox1.Name = "DarkGroupBox1";
            this.DarkGroupBox1.Size = new System.Drawing.Size(216, 448);
            this.DarkGroupBox1.TabIndex = 0;
            this.DarkGroupBox1.TabStop = false;
            this.DarkGroupBox1.Text = "Resource List";
            // 
            // lstIndex
            // 
            this.lstIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstIndex.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstIndex.FormattingEnabled = true;
            this.lstIndex.Location = new System.Drawing.Point(9, 19);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(196, 418);
            this.lstIndex.TabIndex = 1;
            this.lstIndex.Click += new System.EventHandler(this.LstIndex_Click);
            // 
            // DarkGroupBox2
            // 
            this.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox5);
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox4);
            this.DarkGroupBox2.Controls.Add(this.cmbAnimation);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel9);
            this.DarkGroupBox2.Controls.Add(this.nudRespawn);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel8);
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox3);
            this.DarkGroupBox2.Controls.Add(this.nudHealth);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel5);
            this.DarkGroupBox2.Controls.Add(this.cmbType);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel4);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel3);
            this.DarkGroupBox2.Controls.Add(this.txtMessage2);
            this.DarkGroupBox2.Controls.Add(this.txtMessage);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel2);
            this.DarkGroupBox2.Controls.Add(this.txtName);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel1);
            this.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox2.Location = new System.Drawing.Point(225, 2);
            this.DarkGroupBox2.Name = "DarkGroupBox2";
            this.DarkGroupBox2.Size = new System.Drawing.Size(365, 419);
            this.DarkGroupBox2.TabIndex = 1;
            this.DarkGroupBox2.TabStop = false;
            this.DarkGroupBox2.Text = "Resource Properties";
            // 
            // DarkGroupBox5
            // 
            this.DarkGroupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox5.Controls.Add(this.nudRewardExp);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel13);
            this.DarkGroupBox5.Controls.Add(this.cmbRewardItem);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel12);
            this.DarkGroupBox5.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox5.Location = new System.Drawing.Point(9, 369);
            this.DarkGroupBox5.Name = "DarkGroupBox5";
            this.DarkGroupBox5.Size = new System.Drawing.Size(346, 44);
            this.DarkGroupBox5.TabIndex = 16;
            this.DarkGroupBox5.TabStop = false;
            this.DarkGroupBox5.Text = "Rewards";
            // 
            // nudRewardExp
            // 
            this.nudRewardExp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudRewardExp.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudRewardExp.Location = new System.Drawing.Point(241, 14);
            this.nudRewardExp.Name = "nudRewardExp";
            this.nudRewardExp.Size = new System.Drawing.Size(98, 20);
            this.nudRewardExp.TabIndex = 3;
            this.nudRewardExp.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRewardExp.ValueChanged += new System.EventHandler(this.ScrlRewardExp_Scroll);
            // 
            // DarkLabel13
            // 
            this.DarkLabel13.AutoSize = true;
            this.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel13.Location = new System.Drawing.Point(172, 16);
            this.DarkLabel13.Name = "DarkLabel13";
            this.DarkLabel13.Size = new System.Drawing.Size(63, 13);
            this.DarkLabel13.TabIndex = 2;
            this.DarkLabel13.Text = "Experience:";
            // 
            // cmbRewardItem
            // 
            this.cmbRewardItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbRewardItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbRewardItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbRewardItem.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbRewardItem.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbRewardItem.ButtonIcon")));
            this.cmbRewardItem.DrawDropdownHoverOutline = false;
            this.cmbRewardItem.DrawFocusRectangle = false;
            this.cmbRewardItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbRewardItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRewardItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRewardItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbRewardItem.FormattingEnabled = true;
            this.cmbRewardItem.Location = new System.Drawing.Point(42, 13);
            this.cmbRewardItem.Name = "cmbRewardItem";
            this.cmbRewardItem.Size = new System.Drawing.Size(121, 21);
            this.cmbRewardItem.TabIndex = 1;
            this.cmbRewardItem.Text = null;
            this.cmbRewardItem.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbRewardItem.SelectedIndexChanged += new System.EventHandler(this.ScrlRewardItem_Scroll);
            // 
            // DarkLabel12
            // 
            this.DarkLabel12.AutoSize = true;
            this.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel12.Location = new System.Drawing.Point(6, 16);
            this.DarkLabel12.Name = "DarkLabel12";
            this.DarkLabel12.Size = new System.Drawing.Size(30, 13);
            this.DarkLabel12.TabIndex = 0;
            this.DarkLabel12.Text = "Item:";
            // 
            // DarkGroupBox4
            // 
            this.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox4.Controls.Add(this.nudLvlReq);
            this.DarkGroupBox4.Controls.Add(this.DarkLabel11);
            this.DarkGroupBox4.Controls.Add(this.cmbTool);
            this.DarkGroupBox4.Controls.Add(this.DarkLabel10);
            this.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox4.Location = new System.Drawing.Point(9, 319);
            this.DarkGroupBox4.Name = "DarkGroupBox4";
            this.DarkGroupBox4.Size = new System.Drawing.Size(346, 44);
            this.DarkGroupBox4.TabIndex = 15;
            this.DarkGroupBox4.TabStop = false;
            this.DarkGroupBox4.Text = "Requirements";
            // 
            // nudLvlReq
            // 
            this.nudLvlReq.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudLvlReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLvlReq.Location = new System.Drawing.Point(257, 14);
            this.nudLvlReq.Name = "nudLvlReq";
            this.nudLvlReq.Size = new System.Drawing.Size(82, 20);
            this.nudLvlReq.TabIndex = 3;
            this.nudLvlReq.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLvlReq.ValueChanged += new System.EventHandler(this.ScrlLvlReq_Scroll);
            // 
            // DarkLabel11
            // 
            this.DarkLabel11.AutoSize = true;
            this.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel11.Location = new System.Drawing.Point(193, 16);
            this.DarkLabel11.Name = "DarkLabel11";
            this.DarkLabel11.Size = new System.Drawing.Size(58, 13);
            this.DarkLabel11.TabIndex = 2;
            this.DarkLabel11.Text = "Skill Level:";
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
            "Fishing Rod",
            "Pickaxe",
            "Hoe"});
            this.cmbTool.Location = new System.Drawing.Point(84, 13);
            this.cmbTool.Name = "cmbTool";
            this.cmbTool.Size = new System.Drawing.Size(103, 21);
            this.cmbTool.TabIndex = 1;
            this.cmbTool.Text = "None";
            this.cmbTool.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbTool.SelectedIndexChanged += new System.EventHandler(this.CmbTool_SelectedIndexChanged);
            // 
            // DarkLabel10
            // 
            this.DarkLabel10.AutoSize = true;
            this.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel10.Location = new System.Drawing.Point(6, 16);
            this.DarkLabel10.Name = "DarkLabel10";
            this.DarkLabel10.Size = new System.Drawing.Size(72, 13);
            this.DarkLabel10.TabIndex = 0;
            this.DarkLabel10.Text = "Tool Needed:";
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
            this.cmbAnimation.Location = new System.Drawing.Point(255, 122);
            this.cmbAnimation.Name = "cmbAnimation";
            this.cmbAnimation.Size = new System.Drawing.Size(100, 21);
            this.cmbAnimation.TabIndex = 14;
            this.cmbAnimation.Text = null;
            this.cmbAnimation.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbAnimation.SelectedIndexChanged += new System.EventHandler(this.ScrlAnim_Scroll);
            // 
            // DarkLabel9
            // 
            this.DarkLabel9.AutoSize = true;
            this.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel9.Location = new System.Drawing.Point(193, 124);
            this.DarkLabel9.Name = "DarkLabel9";
            this.DarkLabel9.Size = new System.Drawing.Size(56, 13);
            this.DarkLabel9.TabIndex = 13;
            this.DarkLabel9.Text = "Animation:";
            // 
            // nudRespawn
            // 
            this.nudRespawn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudRespawn.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudRespawn.Location = new System.Drawing.Point(110, 122);
            this.nudRespawn.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudRespawn.Name = "nudRespawn";
            this.nudRespawn.Size = new System.Drawing.Size(77, 20);
            this.nudRespawn.TabIndex = 12;
            this.nudRespawn.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRespawn.ValueChanged += new System.EventHandler(this.ScrlRespawn_Scroll);
            // 
            // DarkLabel8
            // 
            this.DarkLabel8.AutoSize = true;
            this.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel8.Location = new System.Drawing.Point(6, 124);
            this.DarkLabel8.Name = "DarkLabel8";
            this.DarkLabel8.Size = new System.Drawing.Size(106, 13);
            this.DarkLabel8.TabIndex = 11;
            this.DarkLabel8.Text = "RespawnTime(secs):";
            // 
            // DarkGroupBox3
            // 
            this.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox3.Controls.Add(this.nudExhaustedPic);
            this.DarkGroupBox3.Controls.Add(this.nudNormalPic);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel7);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel6);
            this.DarkGroupBox3.Controls.Add(this.picExhaustedPic);
            this.DarkGroupBox3.Controls.Add(this.picNormalpic);
            this.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox3.Location = new System.Drawing.Point(9, 149);
            this.DarkGroupBox3.Name = "DarkGroupBox3";
            this.DarkGroupBox3.Size = new System.Drawing.Size(346, 164);
            this.DarkGroupBox3.TabIndex = 10;
            this.DarkGroupBox3.TabStop = false;
            this.DarkGroupBox3.Text = "Graphics";
            // 
            // nudExhaustedPic
            // 
            this.nudExhaustedPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudExhaustedPic.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudExhaustedPic.Location = new System.Drawing.Point(267, 137);
            this.nudExhaustedPic.Name = "nudExhaustedPic";
            this.nudExhaustedPic.Size = new System.Drawing.Size(72, 20);
            this.nudExhaustedPic.TabIndex = 49;
            this.nudExhaustedPic.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudExhaustedPic.ValueChanged += new System.EventHandler(this.ScrlExhaustedPic_Scroll);
            // 
            // nudNormalPic
            // 
            this.nudNormalPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudNormalPic.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudNormalPic.Location = new System.Drawing.Point(86, 137);
            this.nudNormalPic.Name = "nudNormalPic";
            this.nudNormalPic.Size = new System.Drawing.Size(72, 20);
            this.nudNormalPic.TabIndex = 48;
            this.nudNormalPic.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudNormalPic.ValueChanged += new System.EventHandler(this.ScrlNormalPic_Scroll);
            // 
            // DarkLabel7
            // 
            this.DarkLabel7.AutoSize = true;
            this.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel7.Location = new System.Drawing.Point(185, 139);
            this.DarkLabel7.Name = "DarkLabel7";
            this.DarkLabel7.Size = new System.Drawing.Size(71, 13);
            this.DarkLabel7.TabIndex = 47;
            this.DarkLabel7.Text = "Empty Image:";
            // 
            // DarkLabel6
            // 
            this.DarkLabel6.AutoSize = true;
            this.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel6.Location = new System.Drawing.Point(3, 139);
            this.DarkLabel6.Name = "DarkLabel6";
            this.DarkLabel6.Size = new System.Drawing.Size(75, 13);
            this.DarkLabel6.TabIndex = 46;
            this.DarkLabel6.Text = "Normal Image:";
            // 
            // picExhaustedPic
            // 
            this.picExhaustedPic.BackColor = System.Drawing.Color.Black;
            this.picExhaustedPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picExhaustedPic.Location = new System.Drawing.Point(188, 19);
            this.picExhaustedPic.Name = "picExhaustedPic";
            this.picExhaustedPic.Size = new System.Drawing.Size(152, 112);
            this.picExhaustedPic.TabIndex = 45;
            this.picExhaustedPic.TabStop = false;
            // 
            // picNormalpic
            // 
            this.picNormalpic.BackColor = System.Drawing.Color.Black;
            this.picNormalpic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.picNormalpic.Location = new System.Drawing.Point(6, 19);
            this.picNormalpic.Name = "picNormalpic";
            this.picNormalpic.Size = new System.Drawing.Size(152, 112);
            this.picNormalpic.TabIndex = 44;
            this.picNormalpic.TabStop = false;
            // 
            // nudHealth
            // 
            this.nudHealth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudHealth.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudHealth.Location = new System.Drawing.Point(294, 96);
            this.nudHealth.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nudHealth.Name = "nudHealth";
            this.nudHealth.Size = new System.Drawing.Size(61, 20);
            this.nudHealth.TabIndex = 9;
            this.nudHealth.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudHealth.ValueChanged += new System.EventHandler(this.ScrlHealth_Scroll);
            // 
            // DarkLabel5
            // 
            this.DarkLabel5.AutoSize = true;
            this.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel5.Location = new System.Drawing.Point(236, 98);
            this.DarkLabel5.Name = "DarkLabel5";
            this.DarkLabel5.Size = new System.Drawing.Size(52, 13);
            this.DarkLabel5.TabIndex = 8;
            this.DarkLabel5.Text = "HitPoints:";
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
            "Herb",
            "Tree",
            "Mine",
            "Fishing Spot"});
            this.cmbType.Location = new System.Drawing.Point(109, 95);
            this.cmbType.Name = "cmbType";
            this.cmbType.Size = new System.Drawing.Size(121, 21);
            this.cmbType.TabIndex = 7;
            this.cmbType.Text = "None";
            this.cmbType.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbType.SelectedIndexChanged += new System.EventHandler(this.CmbType_SelectedIndexChanged);
            // 
            // DarkLabel4
            // 
            this.DarkLabel4.AutoSize = true;
            this.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel4.Location = new System.Drawing.Point(6, 98);
            this.DarkLabel4.Name = "DarkLabel4";
            this.DarkLabel4.Size = new System.Drawing.Size(83, 13);
            this.DarkLabel4.TabIndex = 6;
            this.DarkLabel4.Text = "Resource Type:";
            // 
            // DarkLabel3
            // 
            this.DarkLabel3.AutoSize = true;
            this.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel3.Location = new System.Drawing.Point(6, 71);
            this.DarkLabel3.Name = "DarkLabel3";
            this.DarkLabel3.Size = new System.Drawing.Size(72, 13);
            this.DarkLabel3.TabIndex = 5;
            this.DarkLabel3.Text = "Fail Message:";
            // 
            // txtMessage2
            // 
            this.txtMessage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtMessage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtMessage2.Location = new System.Drawing.Point(109, 69);
            this.txtMessage2.Name = "txtMessage2";
            this.txtMessage2.Size = new System.Drawing.Size(246, 20);
            this.txtMessage2.TabIndex = 4;
            this.txtMessage2.TextChanged += new System.EventHandler(this.TxtMessage2_TextChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtMessage.Location = new System.Drawing.Point(109, 43);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(246, 20);
            this.txtMessage.TabIndex = 3;
            this.txtMessage.TextChanged += new System.EventHandler(this.TxtMessage_TextChanged);
            // 
            // DarkLabel2
            // 
            this.DarkLabel2.AutoSize = true;
            this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel2.Location = new System.Drawing.Point(6, 45);
            this.DarkLabel2.Name = "DarkLabel2";
            this.DarkLabel2.Size = new System.Drawing.Size(97, 13);
            this.DarkLabel2.TabIndex = 2;
            this.DarkLabel2.Text = "Success Message:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtName.Location = new System.Drawing.Point(109, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(246, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            // 
            // DarkLabel1
            // 
            this.DarkLabel1.AutoSize = true;
            this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel1.Location = new System.Drawing.Point(6, 19);
            this.DarkLabel1.Name = "DarkLabel1";
            this.DarkLabel1.Size = new System.Drawing.Size(87, 13);
            this.DarkLabel1.TabIndex = 0;
            this.DarkLabel1.Text = "Resource Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(225, 427);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(367, 427);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(5);
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(515, 427);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // FrmResource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(596, 458);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.DarkGroupBox2);
            this.Controls.Add(this.DarkGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmResource";
            this.Text = "Resource Editor";
            this.Load += new System.EventHandler(this.FrmEditor_Resource_Load);
            this.DarkGroupBox1.ResumeLayout(false);
            this.DarkGroupBox2.ResumeLayout(false);
            this.DarkGroupBox2.PerformLayout();
            this.DarkGroupBox5.ResumeLayout(false);
            this.DarkGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudRewardExp)).EndInit();
            this.DarkGroupBox4.ResumeLayout(false);
            this.DarkGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudLvlReq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRespawn)).EndInit();
            this.DarkGroupBox3.ResumeLayout(false);
            this.DarkGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudExhaustedPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudNormalPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExhaustedPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNormalpic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHealth)).EndInit();
            this.ResumeLayout(false);

		}
		
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox1;
		internal ListBox lstIndex;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox2;
		internal DarkUI.Controls.DarkLabel DarkLabel3;
		internal DarkUI.Controls.DarkTextBox txtMessage2;
		internal DarkUI.Controls.DarkTextBox txtMessage;
		internal DarkUI.Controls.DarkLabel DarkLabel2;
		internal DarkUI.Controls.DarkTextBox txtName;
		internal DarkUI.Controls.DarkLabel DarkLabel1;
		internal DarkUI.Controls.DarkComboBox cmbType;
		internal DarkUI.Controls.DarkLabel DarkLabel4;
		internal DarkUI.Controls.DarkNumericUpDown nudHealth;
		internal DarkUI.Controls.DarkLabel DarkLabel5;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox3;
		internal PictureBox picExhaustedPic;
		internal PictureBox picNormalpic;
		internal DarkUI.Controls.DarkNumericUpDown nudExhaustedPic;
		internal DarkUI.Controls.DarkNumericUpDown nudNormalPic;
		internal DarkUI.Controls.DarkLabel DarkLabel7;
		internal DarkUI.Controls.DarkLabel DarkLabel6;
		internal DarkUI.Controls.DarkNumericUpDown nudRespawn;
		internal DarkUI.Controls.DarkLabel DarkLabel8;
		internal DarkUI.Controls.DarkComboBox cmbAnimation;
		internal DarkUI.Controls.DarkLabel DarkLabel9;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox4;
		internal DarkUI.Controls.DarkComboBox cmbTool;
		internal DarkUI.Controls.DarkLabel DarkLabel10;
		internal DarkUI.Controls.DarkNumericUpDown nudLvlReq;
		internal DarkUI.Controls.DarkLabel DarkLabel11;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox5;
		internal DarkUI.Controls.DarkComboBox cmbRewardItem;
		internal DarkUI.Controls.DarkLabel DarkLabel12;
		internal DarkUI.Controls.DarkNumericUpDown nudRewardExp;
		internal DarkUI.Controls.DarkLabel DarkLabel13;
		internal DarkUI.Controls.DarkButton btnSave;
		internal DarkUI.Controls.DarkButton btnDelete;
		internal DarkUI.Controls.DarkButton btnCancel;
	}
	
}
