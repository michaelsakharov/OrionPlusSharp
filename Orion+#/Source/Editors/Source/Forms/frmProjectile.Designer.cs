
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
            this.DarkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.lstIndex = new System.Windows.Forms.ListBox();
            this.DarkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
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
            this.emitterPropertiesPanel = new DarkUI.Controls.DarkGroupBox();
            this.darkLabel9 = new DarkUI.Controls.DarkLabel();
            this.darkLabel8 = new DarkUI.Controls.DarkLabel();
            this.darkLabel7 = new DarkUI.Controls.DarkLabel();
            this.darkLabel6 = new DarkUI.Controls.DarkLabel();
            this.darkTextBox4 = new DarkUI.Controls.DarkTextBox();
            this.darkTextBox3 = new DarkUI.Controls.DarkTextBox();
            this.darkTextBox2 = new DarkUI.Controls.DarkTextBox();
            this.darkTextBox1 = new DarkUI.Controls.DarkTextBox();
            this.DarkGroupBox1.SuspendLayout();
            this.DarkGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDamage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picProjectile)).BeginInit();
            this.emitterPropertiesPanel.SuspendLayout();
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
            this.nudPic.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nudPic.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudPic.Name = "nudPic";
            this.nudPic.Size = new System.Drawing.Size(120, 20);
            this.nudPic.TabIndex = 5;
            this.nudPic.Value = new decimal(new int[] {
            1,
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
            this.picProjectile.Location = new System.Drawing.Point(55, 45);
            this.picProjectile.Name = "picProjectile";
            this.picProjectile.Size = new System.Drawing.Size(129, 32);
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
            // emitterPropertiesPanel
            // 
            this.emitterPropertiesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.emitterPropertiesPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(90)))), ((int)(((byte)(90)))));
            this.emitterPropertiesPanel.Controls.Add(this.darkLabel9);
            this.emitterPropertiesPanel.Controls.Add(this.darkLabel8);
            this.emitterPropertiesPanel.Controls.Add(this.darkLabel7);
            this.emitterPropertiesPanel.Controls.Add(this.darkLabel6);
            this.emitterPropertiesPanel.Controls.Add(this.darkTextBox4);
            this.emitterPropertiesPanel.Controls.Add(this.darkTextBox3);
            this.emitterPropertiesPanel.Controls.Add(this.darkTextBox2);
            this.emitterPropertiesPanel.Controls.Add(this.darkTextBox1);
            this.emitterPropertiesPanel.ForeColor = System.Drawing.Color.Gainsboro;
            this.emitterPropertiesPanel.Location = new System.Drawing.Point(452, 3);
            this.emitterPropertiesPanel.Name = "emitterPropertiesPanel";
            this.emitterPropertiesPanel.Size = new System.Drawing.Size(580, 494);
            this.emitterPropertiesPanel.TabIndex = 4;
            this.emitterPropertiesPanel.TabStop = false;
            this.emitterPropertiesPanel.Text = "Logic";
            // 
            // darkLabel9
            // 
            this.darkLabel9.AutoSize = true;
            this.darkLabel9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel9.Location = new System.Drawing.Point(284, 263);
            this.darkLabel9.Name = "darkLabel9";
            this.darkLabel9.Size = new System.Drawing.Size(220, 39);
            this.darkLabel9.TabIndex = 15;
            this.darkLabel9.Text = "On Hit Entity\r\n(Called when the projectile hits a living entity);\r\n\r\n";
            // 
            // darkLabel8
            // 
            this.darkLabel8.AutoSize = true;
            this.darkLabel8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel8.Location = new System.Drawing.Point(6, 263);
            this.darkLabel8.Name = "darkLabel8";
            this.darkLabel8.Size = new System.Drawing.Size(267, 26);
            this.darkLabel8.TabIndex = 14;
            this.darkLabel8.Text = "On Hit Wall\r\n(Called when the projectiles makes contact with a wall):\r\n";
            // 
            // darkLabel7
            // 
            this.darkLabel7.AutoSize = true;
            this.darkLabel7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel7.Location = new System.Drawing.Point(284, 21);
            this.darkLabel7.Name = "darkLabel7";
            this.darkLabel7.Size = new System.Drawing.Size(265, 26);
            this.darkLabel7.TabIndex = 13;
            this.darkLabel7.Text = "On Update\r\n(Called every Frame to Update the Projectiles Position):\r\n";
            // 
            // darkLabel6
            // 
            this.darkLabel6.AutoSize = true;
            this.darkLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkLabel6.Location = new System.Drawing.Point(6, 21);
            this.darkLabel6.Name = "darkLabel6";
            this.darkLabel6.Size = new System.Drawing.Size(187, 26);
            this.darkLabel6.TabIndex = 12;
            this.darkLabel6.Text = "On Instantiate\r\n(Called when the projectile is Created):";
            // 
            // darkTextBox4
            // 
            this.darkTextBox4.AcceptsReturn = true;
            this.darkTextBox4.AcceptsTab = true;
            this.darkTextBox4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkTextBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkTextBox4.Location = new System.Drawing.Point(285, 301);
            this.darkTextBox4.MaxLength = 99999;
            this.darkTextBox4.Multiline = true;
            this.darkTextBox4.Name = "darkTextBox4";
            this.darkTextBox4.Size = new System.Drawing.Size(287, 164);
            this.darkTextBox4.TabIndex = 5;
            this.darkTextBox4.TextChanged += new System.EventHandler(this.darkTextBox4_TextChanged);
            // 
            // darkTextBox3
            // 
            this.darkTextBox3.AcceptsReturn = true;
            this.darkTextBox3.AcceptsTab = true;
            this.darkTextBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkTextBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkTextBox3.Location = new System.Drawing.Point(287, 60);
            this.darkTextBox3.MaxLength = 99999;
            this.darkTextBox3.Multiline = true;
            this.darkTextBox3.Name = "darkTextBox3";
            this.darkTextBox3.Size = new System.Drawing.Size(287, 164);
            this.darkTextBox3.TabIndex = 4;
            this.darkTextBox3.TextChanged += new System.EventHandler(this.darkTextBox3_TextChanged);
            // 
            // darkTextBox2
            // 
            this.darkTextBox2.AcceptsReturn = true;
            this.darkTextBox2.AcceptsTab = true;
            this.darkTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkTextBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkTextBox2.Location = new System.Drawing.Point(6, 60);
            this.darkTextBox2.MaxLength = 99999;
            this.darkTextBox2.Multiline = true;
            this.darkTextBox2.Name = "darkTextBox2";
            this.darkTextBox2.Size = new System.Drawing.Size(273, 164);
            this.darkTextBox2.TabIndex = 3;
            this.darkTextBox2.TextChanged += new System.EventHandler(this.darkTextBox2_TextChanged);
            // 
            // darkTextBox1
            // 
            this.darkTextBox1.AcceptsReturn = true;
            this.darkTextBox1.AcceptsTab = true;
            this.darkTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(73)))), ((int)(((byte)(74)))));
            this.darkTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.darkTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.darkTextBox1.Location = new System.Drawing.Point(6, 301);
            this.darkTextBox1.MaxLength = 99999;
            this.darkTextBox1.Multiline = true;
            this.darkTextBox1.Name = "darkTextBox1";
            this.darkTextBox1.Size = new System.Drawing.Size(273, 164);
            this.darkTextBox1.TabIndex = 2;
            this.darkTextBox1.TextChanged += new System.EventHandler(this.darkTextBox1_TextChanged);
            // 
            // frmProjectile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(1044, 509);
            this.ControlBox = false;
            this.Controls.Add(this.emitterPropertiesPanel);
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
            this.emitterPropertiesPanel.ResumeLayout(false);
            this.emitterPropertiesPanel.PerformLayout();
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
        internal DarkUI.Controls.DarkGroupBox emitterPropertiesPanel;
        internal DarkUI.Controls.DarkLabel darkLabel9;
        internal DarkUI.Controls.DarkLabel darkLabel8;
        internal DarkUI.Controls.DarkLabel darkLabel7;
        internal DarkUI.Controls.DarkLabel darkLabel6;
        internal DarkUI.Controls.DarkTextBox darkTextBox4;
        internal DarkUI.Controls.DarkTextBox darkTextBox3;
        internal DarkUI.Controls.DarkTextBox darkTextBox2;
        internal DarkUI.Controls.DarkTextBox darkTextBox1;
    }
	
}
