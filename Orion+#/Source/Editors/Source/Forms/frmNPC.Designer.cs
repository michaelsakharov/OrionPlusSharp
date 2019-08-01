
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
	partial class frmNPC : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNPC));
            this.DarkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.lstIndex = new System.Windows.Forms.ListBox();
            this.DarkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.cmbSpawnPeriod = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel30 = new DarkUI.Controls.DarkLabel();
            this.nudSpawnSecs = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel13 = new DarkUI.Controls.DarkLabel();
            this.nudDamage = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel12 = new DarkUI.Controls.DarkLabel();
            this.nudLevel = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel11 = new DarkUI.Controls.DarkLabel();
            this.nudExp = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel10 = new DarkUI.Controls.DarkLabel();
            this.nudHp = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel9 = new DarkUI.Controls.DarkLabel();
            this.cmbFaction = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel8 = new DarkUI.Controls.DarkLabel();
            this.cmbBehaviour = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel5 = new DarkUI.Controls.DarkLabel();
            this.cmbQuest = new DarkUI.Controls.DarkComboBox();
            this.cmbAnimation = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel7 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel6 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel4 = new DarkUI.Controls.DarkLabel();
            this.nudRange = new DarkUI.Controls.DarkNumericUpDown();
            this.nudSprite = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel3 = new DarkUI.Controls.DarkLabel();
            this.txtAttackSay = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel2 = new DarkUI.Controls.DarkLabel();
            this.picSprite = new System.Windows.Forms.PictureBox();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel1 = new DarkUI.Controls.DarkLabel();
            this.DarkGroupBox3 = new DarkUI.Controls.DarkGroupBox();
            this.cmbSkill6 = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel17 = new DarkUI.Controls.DarkLabel();
            this.cmbSkill5 = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel18 = new DarkUI.Controls.DarkLabel();
            this.cmbSkill4 = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel19 = new DarkUI.Controls.DarkLabel();
            this.cmbSkill3 = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel16 = new DarkUI.Controls.DarkLabel();
            this.cmbSkill2 = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel15 = new DarkUI.Controls.DarkLabel();
            this.cmbSkill1 = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel14 = new DarkUI.Controls.DarkLabel();
            this.DarkGroupBox4 = new DarkUI.Controls.DarkGroupBox();
            this.nudAmount = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel29 = new DarkUI.Controls.DarkLabel();
            this.cmbItem = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel28 = new DarkUI.Controls.DarkLabel();
            this.cmbDropSlot = new DarkUI.Controls.DarkComboBox();
            this.nudChance = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel27 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel26 = new DarkUI.Controls.DarkLabel();
            this.DarkGroupBox5 = new DarkUI.Controls.DarkGroupBox();
            this.chkIsBoss = new DarkUI.Controls.DarkCheckBox();
            this.btnGenStats = new DarkUI.Controls.DarkButton();
            this.nudSpirit = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel23 = new DarkUI.Controls.DarkLabel();
            this.nudIntelligence = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel24 = new DarkUI.Controls.DarkLabel();
            this.nudLuck = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel25 = new DarkUI.Controls.DarkLabel();
            this.nudVitality = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel22 = new DarkUI.Controls.DarkLabel();
            this.nudEndurance = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel21 = new DarkUI.Controls.DarkLabel();
            this.nudStrength = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel20 = new DarkUI.Controls.DarkLabel();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnDelete = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.label1 = new System.Windows.Forms.Label();
            this.DarkGroupBox1.SuspendLayout();
            this.DarkGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnSecs)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSprite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSprite)).BeginInit();
            this.DarkGroupBox3.SuspendLayout();
            this.DarkGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChance)).BeginInit();
            this.DarkGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpirit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntelligence)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitality)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndurance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrength)).BeginInit();
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
            this.DarkGroupBox1.Size = new System.Drawing.Size(227, 504);
            this.DarkGroupBox1.TabIndex = 0;
            this.DarkGroupBox1.TabStop = false;
            this.DarkGroupBox1.Text = "Npc List";
            // 
            // lstIndex
            // 
            this.lstIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstIndex.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstIndex.FormattingEnabled = true;
            this.lstIndex.Location = new System.Drawing.Point(4, 16);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(219, 483);
            this.lstIndex.TabIndex = 2;
            this.lstIndex.Click += new System.EventHandler(this.LstIndex_Click);
            // 
            // DarkGroupBox2
            // 
            this.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox2.Controls.Add(this.cmbSpawnPeriod);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel30);
            this.DarkGroupBox2.Controls.Add(this.nudSpawnSecs);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel13);
            this.DarkGroupBox2.Controls.Add(this.nudDamage);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel12);
            this.DarkGroupBox2.Controls.Add(this.nudLevel);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel11);
            this.DarkGroupBox2.Controls.Add(this.nudExp);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel10);
            this.DarkGroupBox2.Controls.Add(this.nudHp);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel9);
            this.DarkGroupBox2.Controls.Add(this.cmbFaction);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel8);
            this.DarkGroupBox2.Controls.Add(this.cmbBehaviour);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel5);
            this.DarkGroupBox2.Controls.Add(this.cmbQuest);
            this.DarkGroupBox2.Controls.Add(this.cmbAnimation);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel7);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel6);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel4);
            this.DarkGroupBox2.Controls.Add(this.nudRange);
            this.DarkGroupBox2.Controls.Add(this.nudSprite);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel3);
            this.DarkGroupBox2.Controls.Add(this.txtAttackSay);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel2);
            this.DarkGroupBox2.Controls.Add(this.picSprite);
            this.DarkGroupBox2.Controls.Add(this.txtName);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel1);
            this.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox2.Location = new System.Drawing.Point(236, 2);
            this.DarkGroupBox2.Name = "DarkGroupBox2";
            this.DarkGroupBox2.Size = new System.Drawing.Size(394, 231);
            this.DarkGroupBox2.TabIndex = 1;
            this.DarkGroupBox2.TabStop = false;
            this.DarkGroupBox2.Text = "Npc Properties";
            // 
            // cmbSpawnPeriod
            // 
            this.cmbSpawnPeriod.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSpawnPeriod.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSpawnPeriod.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSpawnPeriod.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSpawnPeriod.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSpawnPeriod.ButtonIcon")));
            this.cmbSpawnPeriod.DrawDropdownHoverOutline = false;
            this.cmbSpawnPeriod.DrawFocusRectangle = false;
            this.cmbSpawnPeriod.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSpawnPeriod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpawnPeriod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSpawnPeriod.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSpawnPeriod.FormattingEnabled = true;
            this.cmbSpawnPeriod.Items.AddRange(new object[] {
            "Day",
            "Night",
            "Dawn",
            "Dusk",
            "Always"});
            this.cmbSpawnPeriod.Location = new System.Drawing.Point(285, 202);
            this.cmbSpawnPeriod.Name = "cmbSpawnPeriod";
            this.cmbSpawnPeriod.Size = new System.Drawing.Size(101, 21);
            this.cmbSpawnPeriod.TabIndex = 38;
            this.cmbSpawnPeriod.Text = "Day";
            this.cmbSpawnPeriod.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSpawnPeriod.SelectedIndexChanged += new System.EventHandler(this.CmbSpawnPeriod_SelectedIndexChanged);
            // 
            // DarkLabel30
            // 
            this.DarkLabel30.AutoSize = true;
            this.DarkLabel30.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel30.Location = new System.Drawing.Point(235, 205);
            this.DarkLabel30.Name = "DarkLabel30";
            this.DarkLabel30.Size = new System.Drawing.Size(48, 13);
            this.DarkLabel30.TabIndex = 37;
            this.DarkLabel30.Text = "Spawns:";
            // 
            // nudSpawnSecs
            // 
            this.nudSpawnSecs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpawnSecs.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpawnSecs.Location = new System.Drawing.Point(149, 203);
            this.nudSpawnSecs.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudSpawnSecs.Name = "nudSpawnSecs";
            this.nudSpawnSecs.Size = new System.Drawing.Size(83, 20);
            this.nudSpawnSecs.TabIndex = 36;
            this.nudSpawnSecs.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpawnSecs.ValueChanged += new System.EventHandler(this.NudSpawnSecs_ValueChanged);
            // 
            // DarkLabel13
            // 
            this.DarkLabel13.AutoSize = true;
            this.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel13.Location = new System.Drawing.Point(6, 205);
            this.DarkLabel13.Name = "DarkLabel13";
            this.DarkLabel13.Size = new System.Drawing.Size(137, 13);
            this.DarkLabel13.TabIndex = 35;
            this.DarkLabel13.Text = "Respawn Time in Seconds:";
            // 
            // nudDamage
            // 
            this.nudDamage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudDamage.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDamage.Location = new System.Drawing.Point(266, 177);
            this.nudDamage.Name = "nudDamage";
            this.nudDamage.Size = new System.Drawing.Size(120, 20);
            this.nudDamage.TabIndex = 34;
            this.nudDamage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDamage.ValueChanged += new System.EventHandler(this.NudDamage_ValueChanged);
            // 
            // DarkLabel12
            // 
            this.DarkLabel12.AutoSize = true;
            this.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel12.Location = new System.Drawing.Point(186, 179);
            this.DarkLabel12.Name = "DarkLabel12";
            this.DarkLabel12.Size = new System.Drawing.Size(77, 13);
            this.DarkLabel12.TabIndex = 33;
            this.DarkLabel12.Text = "Base Damage:";
            // 
            // nudLevel
            // 
            this.nudLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudLevel.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLevel.Location = new System.Drawing.Point(60, 177);
            this.nudLevel.Name = "nudLevel";
            this.nudLevel.Size = new System.Drawing.Size(120, 20);
            this.nudLevel.TabIndex = 32;
            this.nudLevel.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLevel.ValueChanged += new System.EventHandler(this.NudLevel_ValueChanged);
            // 
            // DarkLabel11
            // 
            this.DarkLabel11.AutoSize = true;
            this.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel11.Location = new System.Drawing.Point(6, 179);
            this.DarkLabel11.Name = "DarkLabel11";
            this.DarkLabel11.Size = new System.Drawing.Size(36, 13);
            this.DarkLabel11.TabIndex = 31;
            this.DarkLabel11.Text = "Level:";
            // 
            // nudExp
            // 
            this.nudExp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudExp.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudExp.Location = new System.Drawing.Point(238, 151);
            this.nudExp.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudExp.Name = "nudExp";
            this.nudExp.Size = new System.Drawing.Size(148, 20);
            this.nudExp.TabIndex = 30;
            this.nudExp.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudExp.ValueChanged += new System.EventHandler(this.NudExp_ValueChanged);
            // 
            // DarkLabel10
            // 
            this.DarkLabel10.AutoSize = true;
            this.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel10.Location = new System.Drawing.Point(173, 153);
            this.DarkLabel10.Name = "DarkLabel10";
            this.DarkLabel10.Size = new System.Drawing.Size(59, 13);
            this.DarkLabel10.TabIndex = 29;
            this.DarkLabel10.Text = "Exp Given:";
            // 
            // nudHp
            // 
            this.nudHp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudHp.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudHp.Location = new System.Drawing.Point(60, 151);
            this.nudHp.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudHp.Name = "nudHp";
            this.nudHp.Size = new System.Drawing.Size(107, 20);
            this.nudHp.TabIndex = 28;
            this.nudHp.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudHp.ValueChanged += new System.EventHandler(this.NudHp_ValueChanged);
            // 
            // DarkLabel9
            // 
            this.DarkLabel9.AutoSize = true;
            this.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel9.Location = new System.Drawing.Point(6, 153);
            this.DarkLabel9.Name = "DarkLabel9";
            this.DarkLabel9.Size = new System.Drawing.Size(41, 13);
            this.DarkLabel9.TabIndex = 27;
            this.DarkLabel9.Text = "Health:";
            // 
            // cmbFaction
            // 
            this.cmbFaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbFaction.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbFaction.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbFaction.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbFaction.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbFaction.ButtonIcon")));
            this.cmbFaction.DrawDropdownHoverOutline = false;
            this.cmbFaction.DrawFocusRectangle = false;
            this.cmbFaction.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFaction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFaction.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbFaction.FormattingEnabled = true;
            this.cmbFaction.Items.AddRange(new object[] {
            "None",
            "Baddies",
            "Goodies"});
            this.cmbFaction.Location = new System.Drawing.Point(259, 124);
            this.cmbFaction.Name = "cmbFaction";
            this.cmbFaction.Size = new System.Drawing.Size(127, 21);
            this.cmbFaction.TabIndex = 26;
            this.cmbFaction.Text = "None";
            this.cmbFaction.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbFaction.SelectedIndexChanged += new System.EventHandler(this.CmbFaction_SelectedIndexChanged);
            // 
            // DarkLabel8
            // 
            this.DarkLabel8.AutoSize = true;
            this.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel8.Location = new System.Drawing.Point(205, 127);
            this.DarkLabel8.Name = "DarkLabel8";
            this.DarkLabel8.Size = new System.Drawing.Size(45, 13);
            this.DarkLabel8.TabIndex = 25;
            this.DarkLabel8.Text = "Faction:";
            // 
            // cmbBehaviour
            // 
            this.cmbBehaviour.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbBehaviour.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbBehaviour.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbBehaviour.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbBehaviour.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbBehaviour.ButtonIcon")));
            this.cmbBehaviour.DrawDropdownHoverOutline = false;
            this.cmbBehaviour.DrawFocusRectangle = false;
            this.cmbBehaviour.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBehaviour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbBehaviour.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbBehaviour.FormattingEnabled = true;
            this.cmbBehaviour.Items.AddRange(new object[] {
            "Attack on sight",
            "Attack when attacked",
            "Friendly",
            "Shop keeper",
            "Guard",
            "Quest"});
            this.cmbBehaviour.Location = new System.Drawing.Point(60, 124);
            this.cmbBehaviour.Name = "cmbBehaviour";
            this.cmbBehaviour.Size = new System.Drawing.Size(139, 21);
            this.cmbBehaviour.TabIndex = 24;
            this.cmbBehaviour.Text = "Attack on sight";
            this.cmbBehaviour.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbBehaviour.SelectedIndexChanged += new System.EventHandler(this.CmbBehavior_SelectedIndexChanged);
            // 
            // DarkLabel5
            // 
            this.DarkLabel5.AutoSize = true;
            this.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel5.Location = new System.Drawing.Point(6, 127);
            this.DarkLabel5.Name = "DarkLabel5";
            this.DarkLabel5.Size = new System.Drawing.Size(52, 13);
            this.DarkLabel5.TabIndex = 23;
            this.DarkLabel5.Text = "Behavior:";
            // 
            // cmbQuest
            // 
            this.cmbQuest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbQuest.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbQuest.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbQuest.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbQuest.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbQuest.ButtonIcon")));
            this.cmbQuest.DrawDropdownHoverOutline = false;
            this.cmbQuest.DrawFocusRectangle = false;
            this.cmbQuest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbQuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbQuest.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbQuest.FormattingEnabled = true;
            this.cmbQuest.Location = new System.Drawing.Point(218, 97);
            this.cmbQuest.Name = "cmbQuest";
            this.cmbQuest.Size = new System.Drawing.Size(168, 21);
            this.cmbQuest.TabIndex = 22;
            this.cmbQuest.Text = null;
            this.cmbQuest.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbQuest.SelectedIndexChanged += new System.EventHandler(this.CmbQuest_SelectedIndexChanged);
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
            this.cmbAnimation.Location = new System.Drawing.Point(60, 97);
            this.cmbAnimation.Name = "cmbAnimation";
            this.cmbAnimation.Size = new System.Drawing.Size(108, 21);
            this.cmbAnimation.TabIndex = 21;
            this.cmbAnimation.Text = null;
            this.cmbAnimation.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbAnimation.SelectedIndexChanged += new System.EventHandler(this.CmbAnimation_SelectedIndexChanged);
            // 
            // DarkLabel7
            // 
            this.DarkLabel7.AutoSize = true;
            this.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel7.Location = new System.Drawing.Point(6, 100);
            this.DarkLabel7.Name = "DarkLabel7";
            this.DarkLabel7.Size = new System.Drawing.Size(56, 13);
            this.DarkLabel7.TabIndex = 20;
            this.DarkLabel7.Text = "Animation:";
            // 
            // DarkLabel6
            // 
            this.DarkLabel6.AutoSize = true;
            this.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel6.Location = new System.Drawing.Point(174, 100);
            this.DarkLabel6.Name = "DarkLabel6";
            this.DarkLabel6.Size = new System.Drawing.Size(38, 13);
            this.DarkLabel6.TabIndex = 18;
            this.DarkLabel6.Text = "Quest:";
            // 
            // DarkLabel4
            // 
            this.DarkLabel4.AutoSize = true;
            this.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel4.Location = new System.Drawing.Point(6, 73);
            this.DarkLabel4.Name = "DarkLabel4";
            this.DarkLabel4.Size = new System.Drawing.Size(42, 13);
            this.DarkLabel4.TabIndex = 15;
            this.DarkLabel4.Text = "Range:";
            // 
            // nudRange
            // 
            this.nudRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudRange.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudRange.Location = new System.Drawing.Point(60, 71);
            this.nudRange.Name = "nudRange";
            this.nudRange.Size = new System.Drawing.Size(108, 20);
            this.nudRange.TabIndex = 14;
            this.nudRange.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRange.ValueChanged += new System.EventHandler(this.NudRange_ValueChanged);
            // 
            // nudSprite
            // 
            this.nudSprite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSprite.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSprite.Location = new System.Drawing.Point(217, 71);
            this.nudSprite.Name = "nudSprite";
            this.nudSprite.Size = new System.Drawing.Size(96, 20);
            this.nudSprite.TabIndex = 13;
            this.nudSprite.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSprite.ValueChanged += new System.EventHandler(this.NudSprite_ValueChanged);
            // 
            // DarkLabel3
            // 
            this.DarkLabel3.AutoSize = true;
            this.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel3.Location = new System.Drawing.Point(174, 73);
            this.DarkLabel3.Name = "DarkLabel3";
            this.DarkLabel3.Size = new System.Drawing.Size(37, 13);
            this.DarkLabel3.TabIndex = 12;
            this.DarkLabel3.Text = "Sprite:";
            // 
            // txtAttackSay
            // 
            this.txtAttackSay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtAttackSay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAttackSay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtAttackSay.Location = new System.Drawing.Point(60, 45);
            this.txtAttackSay.Name = "txtAttackSay";
            this.txtAttackSay.Size = new System.Drawing.Size(253, 20);
            this.txtAttackSay.TabIndex = 11;
            this.txtAttackSay.TextChanged += new System.EventHandler(this.TxtAttackSay_TextChanged);
            // 
            // DarkLabel2
            // 
            this.DarkLabel2.AutoSize = true;
            this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel2.Location = new System.Drawing.Point(6, 47);
            this.DarkLabel2.Name = "DarkLabel2";
            this.DarkLabel2.Size = new System.Drawing.Size(48, 13);
            this.DarkLabel2.TabIndex = 10;
            this.DarkLabel2.Text = "SayMsg:";
            // 
            // picSprite
            // 
            this.picSprite.BackColor = System.Drawing.Color.Black;
            this.picSprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picSprite.Location = new System.Drawing.Point(319, 19);
            this.picSprite.Name = "picSprite";
            this.picSprite.Size = new System.Drawing.Size(67, 72);
            this.picSprite.TabIndex = 9;
            this.picSprite.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtName.Location = new System.Drawing.Point(60, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(253, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            // 
            // DarkLabel1
            // 
            this.DarkLabel1.AutoSize = true;
            this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel1.Location = new System.Drawing.Point(6, 21);
            this.DarkLabel1.Name = "DarkLabel1";
            this.DarkLabel1.Size = new System.Drawing.Size(38, 13);
            this.DarkLabel1.TabIndex = 0;
            this.DarkLabel1.Text = "Name:";
            // 
            // DarkGroupBox3
            // 
            this.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox3.Controls.Add(this.cmbSkill6);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel17);
            this.DarkGroupBox3.Controls.Add(this.cmbSkill5);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel18);
            this.DarkGroupBox3.Controls.Add(this.cmbSkill4);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel19);
            this.DarkGroupBox3.Controls.Add(this.cmbSkill3);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel16);
            this.DarkGroupBox3.Controls.Add(this.cmbSkill2);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel15);
            this.DarkGroupBox3.Controls.Add(this.cmbSkill1);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel14);
            this.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox3.Location = new System.Drawing.Point(236, 231);
            this.DarkGroupBox3.Name = "DarkGroupBox3";
            this.DarkGroupBox3.Size = new System.Drawing.Size(394, 65);
            this.DarkGroupBox3.TabIndex = 2;
            this.DarkGroupBox3.TabStop = false;
            this.DarkGroupBox3.Text = "Skills";
            // 
            // cmbSkill6
            // 
            this.cmbSkill6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSkill6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSkill6.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSkill6.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSkill6.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSkill6.ButtonIcon")));
            this.cmbSkill6.DrawDropdownHoverOutline = false;
            this.cmbSkill6.DrawFocusRectangle = false;
            this.cmbSkill6.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSkill6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkill6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSkill6.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSkill6.FormattingEnabled = true;
            this.cmbSkill6.Location = new System.Drawing.Point(285, 40);
            this.cmbSkill6.Name = "cmbSkill6";
            this.cmbSkill6.Size = new System.Drawing.Size(105, 21);
            this.cmbSkill6.TabIndex = 11;
            this.cmbSkill6.Text = null;
            this.cmbSkill6.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSkill6.SelectedIndexChanged += new System.EventHandler(this.CmbSkill6_SelectedIndexChanged);
            // 
            // DarkLabel17
            // 
            this.DarkLabel17.AutoSize = true;
            this.DarkLabel17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel17.Location = new System.Drawing.Point(266, 43);
            this.DarkLabel17.Name = "DarkLabel17";
            this.DarkLabel17.Size = new System.Drawing.Size(13, 13);
            this.DarkLabel17.TabIndex = 10;
            this.DarkLabel17.Text = "6";
            // 
            // cmbSkill5
            // 
            this.cmbSkill5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSkill5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSkill5.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSkill5.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSkill5.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSkill5.ButtonIcon")));
            this.cmbSkill5.DrawDropdownHoverOutline = false;
            this.cmbSkill5.DrawFocusRectangle = false;
            this.cmbSkill5.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSkill5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkill5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSkill5.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSkill5.FormattingEnabled = true;
            this.cmbSkill5.Location = new System.Drawing.Point(155, 40);
            this.cmbSkill5.Name = "cmbSkill5";
            this.cmbSkill5.Size = new System.Drawing.Size(105, 21);
            this.cmbSkill5.TabIndex = 9;
            this.cmbSkill5.Text = null;
            this.cmbSkill5.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSkill5.SelectedIndexChanged += new System.EventHandler(this.CmbSkill5_SelectedIndexChanged);
            // 
            // DarkLabel18
            // 
            this.DarkLabel18.AutoSize = true;
            this.DarkLabel18.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel18.Location = new System.Drawing.Point(136, 43);
            this.DarkLabel18.Name = "DarkLabel18";
            this.DarkLabel18.Size = new System.Drawing.Size(13, 13);
            this.DarkLabel18.TabIndex = 8;
            this.DarkLabel18.Text = "5";
            // 
            // cmbSkill4
            // 
            this.cmbSkill4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSkill4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSkill4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSkill4.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSkill4.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSkill4.ButtonIcon")));
            this.cmbSkill4.DrawDropdownHoverOutline = false;
            this.cmbSkill4.DrawFocusRectangle = false;
            this.cmbSkill4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSkill4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkill4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSkill4.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSkill4.FormattingEnabled = true;
            this.cmbSkill4.Location = new System.Drawing.Point(25, 40);
            this.cmbSkill4.Name = "cmbSkill4";
            this.cmbSkill4.Size = new System.Drawing.Size(105, 21);
            this.cmbSkill4.TabIndex = 7;
            this.cmbSkill4.Text = null;
            this.cmbSkill4.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSkill4.SelectedIndexChanged += new System.EventHandler(this.CmbSkill4_SelectedIndexChanged);
            // 
            // DarkLabel19
            // 
            this.DarkLabel19.AutoSize = true;
            this.DarkLabel19.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel19.Location = new System.Drawing.Point(6, 43);
            this.DarkLabel19.Name = "DarkLabel19";
            this.DarkLabel19.Size = new System.Drawing.Size(13, 13);
            this.DarkLabel19.TabIndex = 6;
            this.DarkLabel19.Text = "4";
            // 
            // cmbSkill3
            // 
            this.cmbSkill3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSkill3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSkill3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSkill3.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSkill3.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSkill3.ButtonIcon")));
            this.cmbSkill3.DrawDropdownHoverOutline = false;
            this.cmbSkill3.DrawFocusRectangle = false;
            this.cmbSkill3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSkill3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkill3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSkill3.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSkill3.FormattingEnabled = true;
            this.cmbSkill3.Location = new System.Drawing.Point(285, 13);
            this.cmbSkill3.Name = "cmbSkill3";
            this.cmbSkill3.Size = new System.Drawing.Size(105, 21);
            this.cmbSkill3.TabIndex = 5;
            this.cmbSkill3.Text = null;
            this.cmbSkill3.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSkill3.SelectedIndexChanged += new System.EventHandler(this.CmbSkill3_SelectedIndexChanged);
            // 
            // DarkLabel16
            // 
            this.DarkLabel16.AutoSize = true;
            this.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel16.Location = new System.Drawing.Point(266, 16);
            this.DarkLabel16.Name = "DarkLabel16";
            this.DarkLabel16.Size = new System.Drawing.Size(13, 13);
            this.DarkLabel16.TabIndex = 4;
            this.DarkLabel16.Text = "3";
            // 
            // cmbSkill2
            // 
            this.cmbSkill2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSkill2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSkill2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSkill2.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSkill2.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSkill2.ButtonIcon")));
            this.cmbSkill2.DrawDropdownHoverOutline = false;
            this.cmbSkill2.DrawFocusRectangle = false;
            this.cmbSkill2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSkill2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkill2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSkill2.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSkill2.FormattingEnabled = true;
            this.cmbSkill2.Location = new System.Drawing.Point(155, 13);
            this.cmbSkill2.Name = "cmbSkill2";
            this.cmbSkill2.Size = new System.Drawing.Size(105, 21);
            this.cmbSkill2.TabIndex = 3;
            this.cmbSkill2.Text = null;
            this.cmbSkill2.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSkill2.SelectedIndexChanged += new System.EventHandler(this.CmbSkill2_SelectedIndexChanged);
            // 
            // DarkLabel15
            // 
            this.DarkLabel15.AutoSize = true;
            this.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel15.Location = new System.Drawing.Point(136, 16);
            this.DarkLabel15.Name = "DarkLabel15";
            this.DarkLabel15.Size = new System.Drawing.Size(13, 13);
            this.DarkLabel15.TabIndex = 2;
            this.DarkLabel15.Text = "2";
            // 
            // cmbSkill1
            // 
            this.cmbSkill1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbSkill1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbSkill1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSkill1.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbSkill1.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbSkill1.ButtonIcon")));
            this.cmbSkill1.DrawDropdownHoverOutline = false;
            this.cmbSkill1.DrawFocusRectangle = false;
            this.cmbSkill1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSkill1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkill1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSkill1.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSkill1.FormattingEnabled = true;
            this.cmbSkill1.Location = new System.Drawing.Point(25, 13);
            this.cmbSkill1.Name = "cmbSkill1";
            this.cmbSkill1.Size = new System.Drawing.Size(105, 21);
            this.cmbSkill1.TabIndex = 1;
            this.cmbSkill1.Text = null;
            this.cmbSkill1.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbSkill1.SelectedIndexChanged += new System.EventHandler(this.CmbSkill1_SelectedIndexChanged);
            // 
            // DarkLabel14
            // 
            this.DarkLabel14.AutoSize = true;
            this.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel14.Location = new System.Drawing.Point(6, 16);
            this.DarkLabel14.Name = "DarkLabel14";
            this.DarkLabel14.Size = new System.Drawing.Size(13, 13);
            this.DarkLabel14.TabIndex = 0;
            this.DarkLabel14.Text = "1";
            // 
            // DarkGroupBox4
            // 
            this.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox4.Controls.Add(this.nudAmount);
            this.DarkGroupBox4.Controls.Add(this.DarkLabel29);
            this.DarkGroupBox4.Controls.Add(this.cmbItem);
            this.DarkGroupBox4.Controls.Add(this.DarkLabel28);
            this.DarkGroupBox4.Controls.Add(this.cmbDropSlot);
            this.DarkGroupBox4.Controls.Add(this.nudChance);
            this.DarkGroupBox4.Controls.Add(this.DarkLabel27);
            this.DarkGroupBox4.Controls.Add(this.DarkLabel26);
            this.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox4.Location = new System.Drawing.Point(236, 392);
            this.DarkGroupBox4.Name = "DarkGroupBox4";
            this.DarkGroupBox4.Size = new System.Drawing.Size(394, 85);
            this.DarkGroupBox4.TabIndex = 3;
            this.DarkGroupBox4.TabStop = false;
            this.DarkGroupBox4.Text = "Drop Items";
            // 
            // nudAmount
            // 
            this.nudAmount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudAmount.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudAmount.Location = new System.Drawing.Point(268, 44);
            this.nudAmount.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(120, 20);
            this.nudAmount.TabIndex = 7;
            this.nudAmount.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudAmount.ValueChanged += new System.EventHandler(this.ScrlValue_Scroll);
            // 
            // DarkLabel29
            // 
            this.DarkLabel29.AutoSize = true;
            this.DarkLabel29.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel29.Location = new System.Drawing.Point(205, 46);
            this.DarkLabel29.Name = "DarkLabel29";
            this.DarkLabel29.Size = new System.Drawing.Size(46, 13);
            this.DarkLabel29.TabIndex = 6;
            this.DarkLabel29.Text = "Amount:";
            // 
            // cmbItem
            // 
            this.cmbItem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbItem.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbItem.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbItem.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbItem.ButtonIcon")));
            this.cmbItem.DrawDropdownHoverOutline = false;
            this.cmbItem.DrawFocusRectangle = false;
            this.cmbItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(66, 43);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(121, 21);
            this.cmbItem.TabIndex = 5;
            this.cmbItem.Text = null;
            this.cmbItem.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbItem.SelectedIndexChanged += new System.EventHandler(this.CmbItem_SelectedIndexChanged);
            // 
            // DarkLabel28
            // 
            this.DarkLabel28.AutoSize = true;
            this.DarkLabel28.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel28.Location = new System.Drawing.Point(6, 46);
            this.DarkLabel28.Name = "DarkLabel28";
            this.DarkLabel28.Size = new System.Drawing.Size(30, 13);
            this.DarkLabel28.TabIndex = 4;
            this.DarkLabel28.Text = "Item:";
            // 
            // cmbDropSlot
            // 
            this.cmbDropSlot.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.cmbDropSlot.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.cmbDropSlot.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbDropSlot.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.cmbDropSlot.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("cmbDropSlot.ButtonIcon")));
            this.cmbDropSlot.DrawDropdownHoverOutline = false;
            this.cmbDropSlot.DrawFocusRectangle = false;
            this.cmbDropSlot.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbDropSlot.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDropSlot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbDropSlot.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbDropSlot.FormattingEnabled = true;
            this.cmbDropSlot.Items.AddRange(new object[] {
            "Slot 1",
            "Slot 2",
            "Slot 3",
            "Slot 4",
            "Slot 5"});
            this.cmbDropSlot.Location = new System.Drawing.Point(66, 13);
            this.cmbDropSlot.Name = "cmbDropSlot";
            this.cmbDropSlot.Size = new System.Drawing.Size(121, 21);
            this.cmbDropSlot.TabIndex = 3;
            this.cmbDropSlot.Text = "Slot 1";
            this.cmbDropSlot.TextPadding = new System.Windows.Forms.Padding(2);
            this.cmbDropSlot.SelectedIndexChanged += new System.EventHandler(this.CmbDropSlot_SelectedIndexChanged);
            // 
            // nudChance
            // 
            this.nudChance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudChance.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudChance.Location = new System.Drawing.Point(294, 14);
            this.nudChance.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.nudChance.Name = "nudChance";
            this.nudChance.Size = new System.Drawing.Size(94, 20);
            this.nudChance.TabIndex = 2;
            this.nudChance.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudChance.ValueChanged += new System.EventHandler(this.NudChance_ValueChanged);
            // 
            // DarkLabel27
            // 
            this.DarkLabel27.AutoSize = true;
            this.DarkLabel27.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel27.Location = new System.Drawing.Point(205, 16);
            this.DarkLabel27.Name = "DarkLabel27";
            this.DarkLabel27.Size = new System.Drawing.Size(83, 13);
            this.DarkLabel27.TabIndex = 1;
            this.DarkLabel27.Text = "Chance 1 out of";
            // 
            // DarkLabel26
            // 
            this.DarkLabel26.AutoSize = true;
            this.DarkLabel26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel26.Location = new System.Drawing.Point(6, 16);
            this.DarkLabel26.Name = "DarkLabel26";
            this.DarkLabel26.Size = new System.Drawing.Size(54, 13);
            this.DarkLabel26.TabIndex = 0;
            this.DarkLabel26.Text = "Drop Slot:";
            // 
            // DarkGroupBox5
            // 
            this.DarkGroupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox5.Controls.Add(this.label1);
            this.DarkGroupBox5.Controls.Add(this.chkIsBoss);
            this.DarkGroupBox5.Controls.Add(this.btnGenStats);
            this.DarkGroupBox5.Controls.Add(this.nudSpirit);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel23);
            this.DarkGroupBox5.Controls.Add(this.nudIntelligence);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel24);
            this.DarkGroupBox5.Controls.Add(this.nudLuck);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel25);
            this.DarkGroupBox5.Controls.Add(this.nudVitality);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel22);
            this.DarkGroupBox5.Controls.Add(this.nudEndurance);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel21);
            this.DarkGroupBox5.Controls.Add(this.nudStrength);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel20);
            this.DarkGroupBox5.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox5.Location = new System.Drawing.Point(236, 290);
            this.DarkGroupBox5.Name = "DarkGroupBox5";
            this.DarkGroupBox5.Size = new System.Drawing.Size(394, 104);
            this.DarkGroupBox5.TabIndex = 4;
            this.DarkGroupBox5.TabStop = false;
            this.DarkGroupBox5.Text = "Stats";
            // 
            // chkIsBoss
            // 
            this.chkIsBoss.AutoSize = true;
            this.chkIsBoss.Location = new System.Drawing.Point(197, 77);
            this.chkIsBoss.Name = "chkIsBoss";
            this.chkIsBoss.Size = new System.Drawing.Size(60, 17);
            this.chkIsBoss.TabIndex = 62;
            this.chkIsBoss.Text = "Is Boss";
            // 
            // btnGenStats
            // 
            this.btnGenStats.Location = new System.Drawing.Point(259, 73);
            this.btnGenStats.Name = "btnGenStats";
            this.btnGenStats.Padding = new System.Windows.Forms.Padding(5);
            this.btnGenStats.Size = new System.Drawing.Size(124, 23);
            this.btnGenStats.TabIndex = 8;
            this.btnGenStats.Text = "Generate Stats";
            this.btnGenStats.Click += new System.EventHandler(this.btnGenStats_Click);
            // 
            // nudSpirit
            // 
            this.nudSpirit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpirit.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpirit.Location = new System.Drawing.Point(320, 45);
            this.nudSpirit.Name = "nudSpirit";
            this.nudSpirit.Size = new System.Drawing.Size(63, 20);
            this.nudSpirit.TabIndex = 11;
            this.nudSpirit.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudSpirit.ValueChanged += new System.EventHandler(this.NudSpirit_ValueChanged);
            // 
            // DarkLabel23
            // 
            this.DarkLabel23.AutoSize = true;
            this.DarkLabel23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel23.Location = new System.Drawing.Point(266, 47);
            this.DarkLabel23.Name = "DarkLabel23";
            this.DarkLabel23.Size = new System.Drawing.Size(33, 13);
            this.DarkLabel23.TabIndex = 10;
            this.DarkLabel23.Text = "Spirit:";
            // 
            // nudIntelligence
            // 
            this.nudIntelligence.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudIntelligence.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudIntelligence.Location = new System.Drawing.Point(197, 45);
            this.nudIntelligence.Name = "nudIntelligence";
            this.nudIntelligence.Size = new System.Drawing.Size(63, 20);
            this.nudIntelligence.TabIndex = 9;
            this.nudIntelligence.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudIntelligence.ValueChanged += new System.EventHandler(this.NudIntelligence_ValueChanged);
            // 
            // DarkLabel24
            // 
            this.DarkLabel24.AutoSize = true;
            this.DarkLabel24.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel24.Location = new System.Drawing.Point(129, 47);
            this.DarkLabel24.Name = "DarkLabel24";
            this.DarkLabel24.Size = new System.Drawing.Size(64, 13);
            this.DarkLabel24.TabIndex = 8;
            this.DarkLabel24.Text = "Intelligence:";
            // 
            // nudLuck
            // 
            this.nudLuck.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudLuck.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLuck.Location = new System.Drawing.Point(60, 45);
            this.nudLuck.Name = "nudLuck";
            this.nudLuck.Size = new System.Drawing.Size(63, 20);
            this.nudLuck.TabIndex = 7;
            this.nudLuck.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudLuck.ValueChanged += new System.EventHandler(this.NudLuck_ValueChanged);
            // 
            // DarkLabel25
            // 
            this.DarkLabel25.AutoSize = true;
            this.DarkLabel25.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel25.Location = new System.Drawing.Point(6, 47);
            this.DarkLabel25.Name = "DarkLabel25";
            this.DarkLabel25.Size = new System.Drawing.Size(34, 13);
            this.DarkLabel25.TabIndex = 6;
            this.DarkLabel25.Text = "Luck:";
            // 
            // nudVitality
            // 
            this.nudVitality.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudVitality.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudVitality.Location = new System.Drawing.Point(320, 19);
            this.nudVitality.Name = "nudVitality";
            this.nudVitality.Size = new System.Drawing.Size(63, 20);
            this.nudVitality.TabIndex = 5;
            this.nudVitality.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudVitality.ValueChanged += new System.EventHandler(this.NudVitality_ValueChanged);
            // 
            // DarkLabel22
            // 
            this.DarkLabel22.AutoSize = true;
            this.DarkLabel22.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel22.Location = new System.Drawing.Point(266, 21);
            this.DarkLabel22.Name = "DarkLabel22";
            this.DarkLabel22.Size = new System.Drawing.Size(40, 13);
            this.DarkLabel22.TabIndex = 4;
            this.DarkLabel22.Text = "Vitality:";
            // 
            // nudEndurance
            // 
            this.nudEndurance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudEndurance.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudEndurance.Location = new System.Drawing.Point(197, 19);
            this.nudEndurance.Name = "nudEndurance";
            this.nudEndurance.Size = new System.Drawing.Size(63, 20);
            this.nudEndurance.TabIndex = 3;
            this.nudEndurance.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudEndurance.ValueChanged += new System.EventHandler(this.NudEndurance_ValueChanged);
            // 
            // DarkLabel21
            // 
            this.DarkLabel21.AutoSize = true;
            this.DarkLabel21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel21.Location = new System.Drawing.Point(129, 21);
            this.DarkLabel21.Name = "DarkLabel21";
            this.DarkLabel21.Size = new System.Drawing.Size(62, 13);
            this.DarkLabel21.TabIndex = 2;
            this.DarkLabel21.Text = "Endurance:";
            // 
            // nudStrength
            // 
            this.nudStrength.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudStrength.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudStrength.Location = new System.Drawing.Point(60, 19);
            this.nudStrength.Name = "nudStrength";
            this.nudStrength.Size = new System.Drawing.Size(63, 20);
            this.nudStrength.TabIndex = 1;
            this.nudStrength.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudStrength.ValueChanged += new System.EventHandler(this.NudStrength_ValueChanged);
            // 
            // DarkLabel20
            // 
            this.DarkLabel20.AutoSize = true;
            this.DarkLabel20.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel20.Location = new System.Drawing.Point(6, 21);
            this.DarkLabel20.Name = "DarkLabel20";
            this.DarkLabel20.Size = new System.Drawing.Size(50, 13);
            this.DarkLabel20.TabIndex = 0;
            this.DarkLabel20.Text = "Strenght:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(555, 483);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(236, 483);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(5);
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(393, 483);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Make sure to assign level first:";
            // 
            // frmNPC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(637, 510);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.DarkGroupBox5);
            this.Controls.Add(this.DarkGroupBox4);
            this.Controls.Add(this.DarkGroupBox3);
            this.Controls.Add(this.DarkGroupBox2);
            this.Controls.Add(this.DarkGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmNPC";
            this.Text = "Npc Editor";
            this.Load += new System.EventHandler(this.FrmEditor_NPC_Load);
            this.DarkGroupBox1.ResumeLayout(false);
            this.DarkGroupBox2.ResumeLayout(false);
            this.DarkGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpawnSecs)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudExp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSprite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSprite)).EndInit();
            this.DarkGroupBox3.ResumeLayout(false);
            this.DarkGroupBox3.PerformLayout();
            this.DarkGroupBox4.ResumeLayout(false);
            this.DarkGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudChance)).EndInit();
            this.DarkGroupBox5.ResumeLayout(false);
            this.DarkGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpirit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntelligence)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudLuck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVitality)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudEndurance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudStrength)).EndInit();
            this.ResumeLayout(false);

		}
		
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox1;
		internal ListBox lstIndex;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox2;
		internal DarkUI.Controls.DarkTextBox txtName;
		internal DarkUI.Controls.DarkLabel DarkLabel1;
		internal PictureBox picSprite;
		internal DarkUI.Controls.DarkTextBox txtAttackSay;
		internal DarkUI.Controls.DarkLabel DarkLabel2;
		internal DarkUI.Controls.DarkNumericUpDown nudSprite;
		internal DarkUI.Controls.DarkLabel DarkLabel3;
		internal DarkUI.Controls.DarkLabel DarkLabel4;
		internal DarkUI.Controls.DarkNumericUpDown nudRange;
		internal DarkUI.Controls.DarkLabel DarkLabel6;
		internal DarkUI.Controls.DarkComboBox cmbAnimation;
		internal DarkUI.Controls.DarkLabel DarkLabel7;
		internal DarkUI.Controls.DarkComboBox cmbQuest;
		internal DarkUI.Controls.DarkComboBox cmbFaction;
		internal DarkUI.Controls.DarkLabel DarkLabel8;
		internal DarkUI.Controls.DarkComboBox cmbBehaviour;
		internal DarkUI.Controls.DarkLabel DarkLabel5;
		internal DarkUI.Controls.DarkNumericUpDown nudHp;
		internal DarkUI.Controls.DarkLabel DarkLabel9;
		internal DarkUI.Controls.DarkNumericUpDown nudExp;
		internal DarkUI.Controls.DarkLabel DarkLabel10;
		internal DarkUI.Controls.DarkNumericUpDown nudDamage;
		internal DarkUI.Controls.DarkLabel DarkLabel12;
		internal DarkUI.Controls.DarkNumericUpDown nudLevel;
		internal DarkUI.Controls.DarkLabel DarkLabel11;
		internal DarkUI.Controls.DarkNumericUpDown nudSpawnSecs;
		internal DarkUI.Controls.DarkLabel DarkLabel13;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox3;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox4;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox5;
		internal DarkUI.Controls.DarkComboBox cmbSkill1;
		internal DarkUI.Controls.DarkLabel DarkLabel14;
		internal DarkUI.Controls.DarkComboBox cmbSkill6;
		internal DarkUI.Controls.DarkLabel DarkLabel17;
		internal DarkUI.Controls.DarkComboBox cmbSkill5;
		internal DarkUI.Controls.DarkLabel DarkLabel18;
		internal DarkUI.Controls.DarkComboBox cmbSkill4;
		internal DarkUI.Controls.DarkLabel DarkLabel19;
		internal DarkUI.Controls.DarkComboBox cmbSkill3;
		internal DarkUI.Controls.DarkLabel DarkLabel16;
		internal DarkUI.Controls.DarkComboBox cmbSkill2;
		internal DarkUI.Controls.DarkLabel DarkLabel15;
		internal DarkUI.Controls.DarkNumericUpDown nudStrength;
		internal DarkUI.Controls.DarkLabel DarkLabel20;
		internal DarkUI.Controls.DarkNumericUpDown nudSpirit;
		internal DarkUI.Controls.DarkLabel DarkLabel23;
		internal DarkUI.Controls.DarkNumericUpDown nudIntelligence;
		internal DarkUI.Controls.DarkLabel DarkLabel24;
		internal DarkUI.Controls.DarkNumericUpDown nudLuck;
		internal DarkUI.Controls.DarkLabel DarkLabel25;
		internal DarkUI.Controls.DarkNumericUpDown nudVitality;
		internal DarkUI.Controls.DarkLabel DarkLabel22;
		internal DarkUI.Controls.DarkNumericUpDown nudEndurance;
		internal DarkUI.Controls.DarkLabel DarkLabel21;
		internal DarkUI.Controls.DarkLabel DarkLabel26;
		internal DarkUI.Controls.DarkComboBox cmbDropSlot;
		internal DarkUI.Controls.DarkNumericUpDown nudChance;
		internal DarkUI.Controls.DarkLabel DarkLabel27;
		internal DarkUI.Controls.DarkNumericUpDown nudAmount;
		internal DarkUI.Controls.DarkLabel DarkLabel29;
		internal DarkUI.Controls.DarkComboBox cmbItem;
		internal DarkUI.Controls.DarkLabel DarkLabel28;
		internal DarkUI.Controls.DarkButton btnCancel;
		internal DarkUI.Controls.DarkButton btnDelete;
		internal DarkUI.Controls.DarkButton btnSave;
		internal DarkUI.Controls.DarkComboBox cmbSpawnPeriod;
		internal DarkUI.Controls.DarkLabel DarkLabel30;
        internal DarkUI.Controls.DarkButton btnGenStats;
        internal DarkUI.Controls.DarkCheckBox chkIsBoss;
        private Label label1;
    }
	
}
