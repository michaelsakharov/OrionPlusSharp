
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
	partial class frmProjectile : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjectile));
            this.DarkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.lstIndex = new System.Windows.Forms.ListBox();
            this.DarkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.btnAddEmitter = new DarkUI.Controls.DarkButton();
            this.btnDeleteEmitter = new DarkUI.Controls.DarkButton();
            this.emitterListBox = new System.Windows.Forms.ListBox();
            this.DarkLabel5 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel4 = new DarkUI.Controls.DarkLabel();
            this.nudDamage = new DarkUI.Controls.DarkNumericUpDown();
            this.nudSpeed = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel3 = new DarkUI.Controls.DarkLabel();
            this.nudRange = new DarkUI.Controls.DarkNumericUpDown();
            this.nudPic = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel2 = new DarkUI.Controls.DarkLabel();
            this.picProjectile = new System.Windows.Forms.PictureBox();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel1 = new DarkUI.Controls.DarkLabel();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.darkGroupBox3 = new DarkUI.Controls.DarkGroupBox();
            this.darkLabel16 = new DarkUI.Controls.DarkLabel();
            this.emitterOffsetRotationNud = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel15 = new DarkUI.Controls.DarkLabel();
            this.emitterYOffsetNud = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel14 = new DarkUI.Controls.DarkLabel();
            this.emitterXOffsetNud = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel13 = new DarkUI.Controls.DarkLabel();
            this.emitterCountNud = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel6 = new DarkUI.Controls.DarkLabel();
            this.emitterSpeedNud = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel7 = new DarkUI.Controls.DarkLabel();
            this.emitterTypeComboBox = new DarkUI.Controls.DarkComboBox();
            this.darkLabel8 = new DarkUI.Controls.DarkLabel();
            this.darkLabel9 = new DarkUI.Controls.DarkLabel();
            this.darkNumericUpDown1 = new DarkUI.Controls.DarkNumericUpDown();
            this.emitterBulletSpeedNud = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel10 = new DarkUI.Controls.DarkLabel();
            this.emitterRangeNud = new DarkUI.Controls.DarkNumericUpDown();
            this.emitterSpriteNud = new DarkUI.Controls.DarkNumericUpDown();
            this.darkLabel11 = new DarkUI.Controls.DarkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.emitterNameTextBox = new DarkUI.Controls.DarkTextBox();
            this.darkLabel12 = new DarkUI.Controls.DarkLabel();
            this.darkGroupBox4 = new DarkUI.Controls.DarkGroupBox();
            this.darkGroupBox5 = new DarkUI.Controls.DarkGroupBox();
            this.DarkGroupBox1.SuspendLayout();
            this.DarkGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProjectile)).BeginInit();
            this.darkGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emitterOffsetRotationNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterYOffsetNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterXOffsetNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterCountNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterSpeedNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterBulletSpeedNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterRangeNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterSpriteNud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.darkGroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // DarkGroupBox1
            // 
            this.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox1.Controls.Add(this.lstIndex);
            this.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.DarkGroupBox1.Name = "DarkGroupBox1";
            this.DarkGroupBox1.Size = new System.Drawing.Size(188, 494);
            this.DarkGroupBox1.TabIndex = 0;
            this.DarkGroupBox1.TabStop = false;
            this.DarkGroupBox1.Text = "Projectile List";
            // 
            // lstIndex
            // 
            this.lstIndex.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstIndex.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstIndex.FormattingEnabled = true;
            this.lstIndex.Location = new System.Drawing.Point(6, 17);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(176, 470);
            this.lstIndex.TabIndex = 1;
            this.lstIndex.Click += new System.EventHandler(this.LstIndex_Click);
            // 
            // DarkGroupBox2
            // 
            this.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.DarkGroupBox2.Controls.Add(this.darkGroupBox5);
            this.DarkGroupBox2.Controls.Add(this.btnAddEmitter);
            this.DarkGroupBox2.Controls.Add(this.btnDeleteEmitter);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel5);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel4);
            this.DarkGroupBox2.Controls.Add(this.nudDamage);
            this.DarkGroupBox2.Controls.Add(this.nudSpeed);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel3);
            this.DarkGroupBox2.Controls.Add(this.nudRange);
            this.DarkGroupBox2.Controls.Add(this.nudPic);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel2);
            this.DarkGroupBox2.Controls.Add(this.picProjectile);
            this.DarkGroupBox2.Controls.Add(this.txtName);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel1);
            this.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox2.Location = new System.Drawing.Point(197, 3);
            this.DarkGroupBox2.Name = "DarkGroupBox2";
            this.DarkGroupBox2.Size = new System.Drawing.Size(249, 465);
            this.DarkGroupBox2.TabIndex = 1;
            this.DarkGroupBox2.TabStop = false;
            this.DarkGroupBox2.Text = "Projectile Properties";
            // 
            // btnAddEmitter
            // 
            this.btnAddEmitter.Image = ((System.Drawing.Image)(resources.GetObject("btnAddEmitter.Image")));
            this.btnAddEmitter.Location = new System.Drawing.Point(9, 435);
            this.btnAddEmitter.Name = "btnAddEmitter";
            this.btnAddEmitter.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddEmitter.Size = new System.Drawing.Size(24, 24);
            this.btnAddEmitter.TabIndex = 14;
            // 
            // btnDeleteEmitter
            // 
            this.btnDeleteEmitter.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteEmitter.Image")));
            this.btnDeleteEmitter.Location = new System.Drawing.Point(215, 435);
            this.btnDeleteEmitter.Name = "btnDeleteEmitter";
            this.btnDeleteEmitter.Padding = new System.Windows.Forms.Padding(5);
            this.btnDeleteEmitter.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteEmitter.TabIndex = 13;
            // 
            // emitterListBox
            // 
            this.emitterListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.emitterListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emitterListBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.emitterListBox.FormattingEnabled = true;
            this.emitterListBox.Location = new System.Drawing.Point(0, 14);
            this.emitterListBox.Name = "emitterListBox";
            this.emitterListBox.Size = new System.Drawing.Size(230, 236);
            this.emitterListBox.TabIndex = 12;
            // 
            // DarkLabel5
            // 
            this.DarkLabel5.AutoSize = true;
            this.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel5.Location = new System.Drawing.Point(6, 163);
            this.DarkLabel5.Name = "DarkLabel5";
            this.DarkLabel5.Size = new System.Drawing.Size(99, 13);
            this.DarkLabel5.TabIndex = 11;
            this.DarkLabel5.Text = "Additional Damage:";
            // 
            // DarkLabel4
            // 
            this.DarkLabel4.AutoSize = true;
            this.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel4.Location = new System.Drawing.Point(6, 137);
            this.DarkLabel4.Name = "DarkLabel4";
            this.DarkLabel4.Size = new System.Drawing.Size(41, 13);
            this.DarkLabel4.TabIndex = 10;
            this.DarkLabel4.Text = "Speed:";
            // 
            // nudDamage
            // 
            this.nudDamage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudDamage.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudDamage.Location = new System.Drawing.Point(119, 161);
            this.nudDamage.Name = "nudDamage";
            this.nudDamage.Size = new System.Drawing.Size(120, 20);
            this.nudDamage.TabIndex = 9;
            this.nudDamage.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudDamage.ValueChanged += new System.EventHandler(this.NudDamage_ValueChanged);
            // 
            // nudSpeed
            // 
            this.nudSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudSpeed.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpeed.Location = new System.Drawing.Point(119, 135);
            this.nudSpeed.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.nudSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(120, 20);
            this.nudSpeed.TabIndex = 8;
            this.nudSpeed.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudSpeed.ValueChanged += new System.EventHandler(this.NudSpeed_ValueChanged);
            // 
            // DarkLabel3
            // 
            this.DarkLabel3.AutoSize = true;
            this.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel3.Location = new System.Drawing.Point(6, 111);
            this.DarkLabel3.Name = "DarkLabel3";
            this.DarkLabel3.Size = new System.Drawing.Size(42, 13);
            this.DarkLabel3.TabIndex = 7;
            this.DarkLabel3.Text = "Range:";
            // 
            // nudRange
            // 
            this.nudRange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudRange.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudRange.Location = new System.Drawing.Point(119, 109);
            this.nudRange.Name = "nudRange";
            this.nudRange.Size = new System.Drawing.Size(120, 20);
            this.nudRange.TabIndex = 6;
            this.nudRange.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudRange.ValueChanged += new System.EventHandler(this.NudRange_ValueChanged);
            // 
            // nudPic
            // 
            this.nudPic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.nudPic.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudPic.Location = new System.Drawing.Point(119, 83);
            this.nudPic.Name = "nudPic";
            this.nudPic.Size = new System.Drawing.Size(120, 20);
            this.nudPic.TabIndex = 5;
            this.nudPic.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.nudPic.ValueChanged += new System.EventHandler(this.NudPic_ValueChanged);
            // 
            // DarkLabel2
            // 
            this.DarkLabel2.AutoSize = true;
            this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel2.Location = new System.Drawing.Point(6, 85);
            this.DarkLabel2.Name = "DarkLabel2";
            this.DarkLabel2.Size = new System.Drawing.Size(43, 13);
            this.DarkLabel2.TabIndex = 4;
            this.DarkLabel2.Text = "Picture:";
            // 
            // picProjectile
            // 
            this.picProjectile.BackColor = System.Drawing.Color.Black;
            this.picProjectile.Location = new System.Drawing.Point(9, 45);
            this.picProjectile.Name = "picProjectile";
            this.picProjectile.Size = new System.Drawing.Size(230, 32);
            this.picProjectile.TabIndex = 3;
            this.picProjectile.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.txtName.Location = new System.Drawing.Point(96, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(143, 20);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
            // 
            // DarkLabel1
            // 
            this.DarkLabel1.AutoSize = true;
            this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel1.Location = new System.Drawing.Point(6, 21);
            this.DarkLabel1.Name = "DarkLabel1";
            this.DarkLabel1.Size = new System.Drawing.Size(84, 13);
            this.DarkLabel1.TabIndex = 0;
            this.DarkLabel1.Text = "Projectile Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(197, 474);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(371, 474);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // darkGroupBox3
            // 
            this.darkGroupBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.darkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.darkGroupBox3.Controls.Add(this.darkLabel16);
            this.darkGroupBox3.Controls.Add(this.emitterOffsetRotationNud);
            this.darkGroupBox3.Controls.Add(this.darkLabel15);
            this.darkGroupBox3.Controls.Add(this.emitterYOffsetNud);
            this.darkGroupBox3.Controls.Add(this.darkLabel14);
            this.darkGroupBox3.Controls.Add(this.emitterXOffsetNud);
            this.darkGroupBox3.Controls.Add(this.darkLabel13);
            this.darkGroupBox3.Controls.Add(this.emitterCountNud);
            this.darkGroupBox3.Controls.Add(this.darkLabel6);
            this.darkGroupBox3.Controls.Add(this.emitterSpeedNud);
            this.darkGroupBox3.Controls.Add(this.darkLabel7);
            this.darkGroupBox3.Controls.Add(this.emitterTypeComboBox);
            this.darkGroupBox3.Controls.Add(this.darkLabel8);
            this.darkGroupBox3.Controls.Add(this.darkLabel9);
            this.darkGroupBox3.Controls.Add(this.darkNumericUpDown1);
            this.darkGroupBox3.Controls.Add(this.emitterBulletSpeedNud);
            this.darkGroupBox3.Controls.Add(this.darkLabel10);
            this.darkGroupBox3.Controls.Add(this.emitterRangeNud);
            this.darkGroupBox3.Controls.Add(this.emitterSpriteNud);
            this.darkGroupBox3.Controls.Add(this.darkLabel11);
            this.darkGroupBox3.Controls.Add(this.pictureBox1);
            this.darkGroupBox3.Controls.Add(this.emitterNameTextBox);
            this.darkGroupBox3.Controls.Add(this.darkLabel12);
            this.darkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro;
            this.darkGroupBox3.Location = new System.Drawing.Point(452, 3);
            this.darkGroupBox3.Name = "darkGroupBox3";
            this.darkGroupBox3.Size = new System.Drawing.Size(580, 494);
            this.darkGroupBox3.TabIndex = 4;
            this.darkGroupBox3.TabStop = false;
            this.darkGroupBox3.Text = "Emitter Properties";
            // 
            // darkLabel16
            // 
            this.darkLabel16.AutoSize = true;
            this.darkLabel16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel16.Location = new System.Drawing.Point(6, 178);
            this.darkLabel16.Name = "darkLabel16";
            this.darkLabel16.Size = new System.Drawing.Size(81, 13);
            this.darkLabel16.TabIndex = 23;
            this.darkLabel16.Text = "Offset Rotation:";
            // 
            // emitterOffsetRotationNud
            // 
            this.emitterOffsetRotationNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.emitterOffsetRotationNud.ForeColor = System.Drawing.Color.Gainsboro;
            this.emitterOffsetRotationNud.Location = new System.Drawing.Point(110, 176);
            this.emitterOffsetRotationNud.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.emitterOffsetRotationNud.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
            this.emitterOffsetRotationNud.Name = "emitterOffsetRotationNud";
            this.emitterOffsetRotationNud.Size = new System.Drawing.Size(129, 20);
            this.emitterOffsetRotationNud.TabIndex = 22;
            this.emitterOffsetRotationNud.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // darkLabel15
            // 
            this.darkLabel15.AutoSize = true;
            this.darkLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel15.Location = new System.Drawing.Point(6, 152);
            this.darkLabel15.Name = "darkLabel15";
            this.darkLabel15.Size = new System.Drawing.Size(73, 13);
            this.darkLabel15.TabIndex = 21;
            this.darkLabel15.Text = "Y Start Offset:";
            // 
            // emitterYOffsetNud
            // 
            this.emitterYOffsetNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.emitterYOffsetNud.ForeColor = System.Drawing.Color.Gainsboro;
            this.emitterYOffsetNud.Location = new System.Drawing.Point(110, 150);
            this.emitterYOffsetNud.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.emitterYOffsetNud.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.emitterYOffsetNud.Name = "emitterYOffsetNud";
            this.emitterYOffsetNud.Size = new System.Drawing.Size(129, 20);
            this.emitterYOffsetNud.TabIndex = 20;
            this.emitterYOffsetNud.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // darkLabel14
            // 
            this.darkLabel14.AutoSize = true;
            this.darkLabel14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel14.Location = new System.Drawing.Point(6, 126);
            this.darkLabel14.Name = "darkLabel14";
            this.darkLabel14.Size = new System.Drawing.Size(73, 13);
            this.darkLabel14.TabIndex = 19;
            this.darkLabel14.Text = "X Start Offset:";
            // 
            // emitterXOffsetNud
            // 
            this.emitterXOffsetNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.emitterXOffsetNud.ForeColor = System.Drawing.Color.Gainsboro;
            this.emitterXOffsetNud.Location = new System.Drawing.Point(110, 124);
            this.emitterXOffsetNud.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.emitterXOffsetNud.Minimum = new decimal(new int[] {
            200,
            0,
            0,
            -2147483648});
            this.emitterXOffsetNud.Name = "emitterXOffsetNud";
            this.emitterXOffsetNud.Size = new System.Drawing.Size(129, 20);
            this.emitterXOffsetNud.TabIndex = 18;
            this.emitterXOffsetNud.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // darkLabel13
            // 
            this.darkLabel13.AutoSize = true;
            this.darkLabel13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel13.Location = new System.Drawing.Point(6, 100);
            this.darkLabel13.Name = "darkLabel13";
            this.darkLabel13.Size = new System.Drawing.Size(38, 13);
            this.darkLabel13.TabIndex = 17;
            this.darkLabel13.Text = "Count:";
            // 
            // emitterCountNud
            // 
            this.emitterCountNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.emitterCountNud.ForeColor = System.Drawing.Color.Gainsboro;
            this.emitterCountNud.Location = new System.Drawing.Point(110, 98);
            this.emitterCountNud.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.emitterCountNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.emitterCountNud.Name = "emitterCountNud";
            this.emitterCountNud.Size = new System.Drawing.Size(129, 20);
            this.emitterCountNud.TabIndex = 16;
            this.emitterCountNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // darkLabel6
            // 
            this.darkLabel6.AutoSize = true;
            this.darkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel6.Location = new System.Drawing.Point(6, 256);
            this.darkLabel6.Name = "darkLabel6";
            this.darkLabel6.Size = new System.Drawing.Size(76, 13);
            this.darkLabel6.TabIndex = 15;
            this.darkLabel6.Text = "Emitter Speed:";
            // 
            // emitterSpeedNud
            // 
            this.emitterSpeedNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.emitterSpeedNud.ForeColor = System.Drawing.Color.Gainsboro;
            this.emitterSpeedNud.Location = new System.Drawing.Point(110, 254);
            this.emitterSpeedNud.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.emitterSpeedNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.emitterSpeedNud.Name = "emitterSpeedNud";
            this.emitterSpeedNud.Size = new System.Drawing.Size(129, 20);
            this.emitterSpeedNud.TabIndex = 14;
            this.emitterSpeedNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // darkLabel7
            // 
            this.darkLabel7.AutoSize = true;
            this.darkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel7.Location = new System.Drawing.Point(6, 48);
            this.darkLabel7.Name = "darkLabel7";
            this.darkLabel7.Size = new System.Drawing.Size(69, 13);
            this.darkLabel7.TabIndex = 13;
            this.darkLabel7.Text = "Emitter Type:";
            // 
            // emitterTypeComboBox
            // 
            this.emitterTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.emitterTypeComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.emitterTypeComboBox.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.emitterTypeComboBox.ButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.emitterTypeComboBox.ButtonIcon = ((System.Drawing.Bitmap)(resources.GetObject("emitterTypeComboBox.ButtonIcon")));
            this.emitterTypeComboBox.DrawDropdownHoverOutline = false;
            this.emitterTypeComboBox.DrawFocusRectangle = false;
            this.emitterTypeComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.emitterTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.emitterTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emitterTypeComboBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.emitterTypeComboBox.FormattingEnabled = true;
            this.emitterTypeComboBox.Items.AddRange(new object[] {
            "Linear",
            "Accelerating",
            "Laser Beam",
            "Boomerang",
            "Homing",
            "Re-Direction",
            "Wave",
            "Exploding Bullets",
            "Bouncing"});
            this.emitterTypeComboBox.Location = new System.Drawing.Point(110, 45);
            this.emitterTypeComboBox.Name = "emitterTypeComboBox";
            this.emitterTypeComboBox.Size = new System.Drawing.Size(129, 21);
            this.emitterTypeComboBox.TabIndex = 12;
            this.emitterTypeComboBox.Text = "Linear";
            this.emitterTypeComboBox.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // darkLabel8
            // 
            this.darkLabel8.AutoSize = true;
            this.darkLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel8.Location = new System.Drawing.Point(6, 282);
            this.darkLabel8.Name = "darkLabel8";
            this.darkLabel8.Size = new System.Drawing.Size(99, 13);
            this.darkLabel8.TabIndex = 11;
            this.darkLabel8.Text = "Additional Damage:";
            // 
            // darkLabel9
            // 
            this.darkLabel9.AutoSize = true;
            this.darkLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel9.Location = new System.Drawing.Point(6, 230);
            this.darkLabel9.Name = "darkLabel9";
            this.darkLabel9.Size = new System.Drawing.Size(41, 13);
            this.darkLabel9.TabIndex = 10;
            this.darkLabel9.Text = "Speed:";
            // 
            // darkNumericUpDown1
            // 
            this.darkNumericUpDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkNumericUpDown1.ForeColor = System.Drawing.Color.Gainsboro;
            this.darkNumericUpDown1.Location = new System.Drawing.Point(110, 280);
            this.darkNumericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.darkNumericUpDown1.Name = "darkNumericUpDown1";
            this.darkNumericUpDown1.Size = new System.Drawing.Size(129, 20);
            this.darkNumericUpDown1.TabIndex = 9;
            this.darkNumericUpDown1.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // emitterBulletSpeedNud
            // 
            this.emitterBulletSpeedNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.emitterBulletSpeedNud.ForeColor = System.Drawing.Color.Gainsboro;
            this.emitterBulletSpeedNud.Location = new System.Drawing.Point(110, 228);
            this.emitterBulletSpeedNud.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.emitterBulletSpeedNud.Name = "emitterBulletSpeedNud";
            this.emitterBulletSpeedNud.Size = new System.Drawing.Size(129, 20);
            this.emitterBulletSpeedNud.TabIndex = 8;
            this.emitterBulletSpeedNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // darkLabel10
            // 
            this.darkLabel10.AutoSize = true;
            this.darkLabel10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel10.Location = new System.Drawing.Point(6, 204);
            this.darkLabel10.Name = "darkLabel10";
            this.darkLabel10.Size = new System.Drawing.Size(42, 13);
            this.darkLabel10.TabIndex = 7;
            this.darkLabel10.Text = "Range:";
            // 
            // emitterRangeNud
            // 
            this.emitterRangeNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.emitterRangeNud.ForeColor = System.Drawing.Color.Gainsboro;
            this.emitterRangeNud.Location = new System.Drawing.Point(110, 202);
            this.emitterRangeNud.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.emitterRangeNud.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.emitterRangeNud.Name = "emitterRangeNud";
            this.emitterRangeNud.Size = new System.Drawing.Size(129, 20);
            this.emitterRangeNud.TabIndex = 6;
            this.emitterRangeNud.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // emitterSpriteNud
            // 
            this.emitterSpriteNud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.emitterSpriteNud.ForeColor = System.Drawing.Color.Gainsboro;
            this.emitterSpriteNud.Location = new System.Drawing.Point(110, 72);
            this.emitterSpriteNud.Name = "emitterSpriteNud";
            this.emitterSpriteNud.Size = new System.Drawing.Size(129, 20);
            this.emitterSpriteNud.TabIndex = 5;
            this.emitterSpriteNud.Value = new decimal(new int[] {
            0,
            0,
            0,
            0});
            // 
            // darkLabel11
            // 
            this.darkLabel11.AutoSize = true;
            this.darkLabel11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel11.Location = new System.Drawing.Point(6, 74);
            this.darkLabel11.Name = "darkLabel11";
            this.darkLabel11.Size = new System.Drawing.Size(43, 13);
            this.darkLabel11.TabIndex = 4;
            this.darkLabel11.Text = "Picture:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(249, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(325, 325);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // emitterNameTextBox
            // 
            this.emitterNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.emitterNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.emitterNameTextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.emitterNameTextBox.Location = new System.Drawing.Point(110, 19);
            this.emitterNameTextBox.Name = "emitterNameTextBox";
            this.emitterNameTextBox.Size = new System.Drawing.Size(129, 20);
            this.emitterNameTextBox.TabIndex = 1;
            // 
            // darkLabel12
            // 
            this.darkLabel12.AutoSize = true;
            this.darkLabel12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel12.Location = new System.Drawing.Point(6, 21);
            this.darkLabel12.Name = "darkLabel12";
            this.darkLabel12.Size = new System.Drawing.Size(73, 13);
            this.darkLabel12.TabIndex = 0;
            this.darkLabel12.Text = "Emitter Name:";
            // 
            // darkGroupBox4
            // 
            this.darkGroupBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.darkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.darkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro;
            this.darkGroupBox4.Location = new System.Drawing.Point(452, 345);
            this.darkGroupBox4.Name = "darkGroupBox4";
            this.darkGroupBox4.Size = new System.Drawing.Size(580, 152);
            this.darkGroupBox4.TabIndex = 24;
            this.darkGroupBox4.TabStop = false;
            this.darkGroupBox4.Text = "Emitter Type Settings";
            // 
            // darkGroupBox5
            // 
            this.darkGroupBox5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.darkGroupBox5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.darkGroupBox5.Controls.Add(this.emitterListBox);
            this.darkGroupBox5.ForeColor = System.Drawing.Color.Gainsboro;
            this.darkGroupBox5.Location = new System.Drawing.Point(9, 179);
            this.darkGroupBox5.Name = "darkGroupBox5";
            this.darkGroupBox5.Size = new System.Drawing.Size(230, 250);
            this.darkGroupBox5.TabIndex = 1;
            this.darkGroupBox5.TabStop = false;
            this.darkGroupBox5.Text = "Emitter List";
            // 
            // frmProjectile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1044, 509);
            this.ControlBox = false;
            this.Controls.Add(this.darkGroupBox4);
            this.Controls.Add(this.darkGroupBox3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.DarkGroupBox2);
            this.Controls.Add(this.DarkGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmProjectile";
            this.Text = "Projectile Editor";
            this.Load += new System.EventHandler(this.FrmEditor_Projectile_Load);
            this.DarkGroupBox1.ResumeLayout(false);
            this.DarkGroupBox2.ResumeLayout(false);
            this.DarkGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProjectile)).EndInit();
            this.darkGroupBox3.ResumeLayout(false);
            this.darkGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emitterOffsetRotationNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterYOffsetNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterXOffsetNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterCountNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterSpeedNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.darkNumericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterBulletSpeedNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterRangeNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emitterSpriteNud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.darkGroupBox5.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox1;
		internal ListBox lstIndex;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox2;
		internal DarkUI.Controls.DarkTextBox txtName;
		internal DarkUI.Controls.DarkLabel DarkLabel1;
		internal PictureBox picProjectile;
		internal DarkUI.Controls.DarkNumericUpDown nudRange;
		internal DarkUI.Controls.DarkNumericUpDown nudPic;
		internal DarkUI.Controls.DarkLabel DarkLabel2;
		internal DarkUI.Controls.DarkLabel DarkLabel3;
		internal DarkUI.Controls.DarkNumericUpDown nudDamage;
		internal DarkUI.Controls.DarkNumericUpDown nudSpeed;
		internal DarkUI.Controls.DarkLabel DarkLabel4;
		internal DarkUI.Controls.DarkLabel DarkLabel5;
		internal DarkUI.Controls.DarkButton btnSave;
		internal DarkUI.Controls.DarkButton btnCancel;
        internal ListBox emitterListBox;
        internal DarkUI.Controls.DarkGroupBox darkGroupBox3;
        internal DarkUI.Controls.DarkLabel darkLabel7;
        internal DarkUI.Controls.DarkComboBox emitterTypeComboBox;
        internal DarkUI.Controls.DarkLabel darkLabel8;
        internal DarkUI.Controls.DarkLabel darkLabel9;
        internal DarkUI.Controls.DarkNumericUpDown darkNumericUpDown1;
        internal DarkUI.Controls.DarkNumericUpDown emitterBulletSpeedNud;
        internal DarkUI.Controls.DarkLabel darkLabel10;
        internal DarkUI.Controls.DarkNumericUpDown emitterRangeNud;
        internal DarkUI.Controls.DarkNumericUpDown emitterSpriteNud;
        internal DarkUI.Controls.DarkLabel darkLabel11;
        internal PictureBox pictureBox1;
        internal DarkUI.Controls.DarkTextBox emitterNameTextBox;
        internal DarkUI.Controls.DarkLabel darkLabel12;
        internal DarkUI.Controls.DarkButton btnDeleteEmitter;
        internal DarkUI.Controls.DarkButton btnAddEmitter;
        internal DarkUI.Controls.DarkLabel darkLabel13;
        internal DarkUI.Controls.DarkNumericUpDown emitterCountNud;
        internal DarkUI.Controls.DarkLabel darkLabel6;
        internal DarkUI.Controls.DarkNumericUpDown emitterSpeedNud;
        internal DarkUI.Controls.DarkLabel darkLabel15;
        internal DarkUI.Controls.DarkNumericUpDown emitterYOffsetNud;
        internal DarkUI.Controls.DarkLabel darkLabel14;
        internal DarkUI.Controls.DarkNumericUpDown emitterXOffsetNud;
        internal DarkUI.Controls.DarkLabel darkLabel16;
        internal DarkUI.Controls.DarkNumericUpDown emitterOffsetRotationNud;
        internal DarkUI.Controls.DarkGroupBox darkGroupBox4;
        internal DarkUI.Controls.DarkGroupBox darkGroupBox5;
    }
	
}
