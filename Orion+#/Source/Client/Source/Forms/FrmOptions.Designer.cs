
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using Engine;

namespace Engine
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class FrmOptions : System.Windows.Forms.Form
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
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.cmbScreenSize = new System.Windows.Forms.ComboBox();
            this.lblVolume = new System.Windows.Forms.Label();
            this.scrlVolume = new System.Windows.Forms.HScrollBar();
            this.GroupBox2 = new System.Windows.Forms.GroupBox();
            this.optSOff = new System.Windows.Forms.RadioButton();
            this.optSOn = new System.Windows.Forms.RadioButton();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.optMOff = new System.Windows.Forms.RadioButton();
            this.optMOn = new System.Windows.Forms.RadioButton();
            this.chkHighEnd = new System.Windows.Forms.CheckBox();
            this.chkNpcBars = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.GroupBox2.SuspendLayout();
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.ForeColor = System.Drawing.Color.Black;
            this.btnSaveSettings.Location = new System.Drawing.Point(11, 205);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(205, 23);
            this.btnSaveSettings.TabIndex = 14;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 100);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(61, 13);
            this.Label1.TabIndex = 13;
            this.Label1.Text = "ScreenSize";
            // 
            // cmbScreenSize
            // 
            this.cmbScreenSize.FormattingEnabled = true;
            this.cmbScreenSize.Items.AddRange(new object[] {
            "800X600",
            "1024X768",
            "1152X864"});
            this.cmbScreenSize.Location = new System.Drawing.Point(11, 116);
            this.cmbScreenSize.Name = "cmbScreenSize";
            this.cmbScreenSize.Size = new System.Drawing.Size(206, 21);
            this.cmbScreenSize.TabIndex = 12;
            // 
            // lblVolume
            // 
            this.lblVolume.AutoSize = true;
            this.lblVolume.BackColor = System.Drawing.Color.Transparent;
            this.lblVolume.ForeColor = System.Drawing.Color.Black;
            this.lblVolume.Location = new System.Drawing.Point(12, 54);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(48, 13);
            this.lblVolume.TabIndex = 11;
            this.lblVolume.Text = "Volume: ";
            // 
            // scrlVolume
            // 
            this.scrlVolume.LargeChange = 1;
            this.scrlVolume.Location = new System.Drawing.Point(12, 69);
            this.scrlVolume.Name = "scrlVolume";
            this.scrlVolume.Size = new System.Drawing.Size(205, 17);
            this.scrlVolume.TabIndex = 10;
            this.scrlVolume.Value = 100;
            this.scrlVolume.ValueChanged += new System.EventHandler(this.scrlVolume_ValueChanged);
            // 
            // GroupBox2
            // 
            this.GroupBox2.Controls.Add(this.optSOff);
            this.GroupBox2.Controls.Add(this.optSOn);
            this.GroupBox2.ForeColor = System.Drawing.Color.Black;
            this.GroupBox2.Location = new System.Drawing.Point(118, 13);
            this.GroupBox2.Name = "GroupBox2";
            this.GroupBox2.Size = new System.Drawing.Size(100, 38);
            this.GroupBox2.TabIndex = 7;
            this.GroupBox2.TabStop = false;
            this.GroupBox2.Text = "Sound";
            // 
            // optSOff
            // 
            this.optSOff.AutoSize = true;
            this.optSOff.Location = new System.Drawing.Point(49, 19);
            this.optSOff.Name = "optSOff";
            this.optSOff.Size = new System.Drawing.Size(39, 17);
            this.optSOff.TabIndex = 5;
            this.optSOff.TabStop = true;
            this.optSOff.Text = "Off";
            this.optSOff.UseVisualStyleBackColor = true;
            // 
            // optSOn
            // 
            this.optSOn.AutoSize = true;
            this.optSOn.Location = new System.Drawing.Point(4, 19);
            this.optSOn.Name = "optSOn";
            this.optSOn.Size = new System.Drawing.Size(39, 17);
            this.optSOn.TabIndex = 4;
            this.optSOn.TabStop = true;
            this.optSOn.Text = "On";
            this.optSOn.UseVisualStyleBackColor = true;
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.optMOff);
            this.GroupBox1.Controls.Add(this.optMOn);
            this.GroupBox1.ForeColor = System.Drawing.Color.Black;
            this.GroupBox1.Location = new System.Drawing.Point(12, 12);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(100, 39);
            this.GroupBox1.TabIndex = 6;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Music";
            // 
            // optMOff
            // 
            this.optMOff.AutoSize = true;
            this.optMOff.Location = new System.Drawing.Point(49, 17);
            this.optMOff.Name = "optMOff";
            this.optMOff.Size = new System.Drawing.Size(39, 17);
            this.optMOff.TabIndex = 2;
            this.optMOff.TabStop = true;
            this.optMOff.Text = "Off";
            this.optMOff.UseVisualStyleBackColor = true;
            // 
            // optMOn
            // 
            this.optMOn.AutoSize = true;
            this.optMOn.Location = new System.Drawing.Point(4, 17);
            this.optMOn.Name = "optMOn";
            this.optMOn.Size = new System.Drawing.Size(39, 17);
            this.optMOn.TabIndex = 1;
            this.optMOn.TabStop = true;
            this.optMOn.Text = "On";
            this.optMOn.UseVisualStyleBackColor = true;
            // 
            // chkHighEnd
            // 
            this.chkHighEnd.AutoSize = true;
            this.chkHighEnd.Location = new System.Drawing.Point(12, 143);
            this.chkHighEnd.Name = "chkHighEnd";
            this.chkHighEnd.Size = new System.Drawing.Size(90, 17);
            this.chkHighEnd.TabIndex = 15;
            this.chkHighEnd.Text = "HighEnd PC?";
            this.chkHighEnd.UseVisualStyleBackColor = true;
            // 
            // chkNpcBars
            // 
            this.chkNpcBars.AutoSize = true;
            this.chkNpcBars.Location = new System.Drawing.Point(12, 182);
            this.chkNpcBars.Name = "chkNpcBars";
            this.chkNpcBars.Size = new System.Drawing.Size(106, 17);
            this.chkNpcBars.TabIndex = 16;
            this.chkNpcBars.Text = "Show Npc Bars?";
            this.chkNpcBars.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 162);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(89, 17);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Unlock FPS?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FrmOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 239);
            this.ControlBox = false;
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.chkNpcBars);
            this.Controls.Add(this.chkHighEnd);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.GroupBox1);
            this.Controls.Add(this.cmbScreenSize);
            this.Controls.Add(this.GroupBox2);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.scrlVolume);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmOptions";
            this.ShowInTaskbar = false;
            this.Text = "Game Options";
            this.TopMost = true;
            this.GroupBox2.ResumeLayout(false);
            this.GroupBox2.PerformLayout();
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Button btnSaveSettings;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.ComboBox cmbScreenSize;
		internal System.Windows.Forms.Label lblVolume;
		internal System.Windows.Forms.HScrollBar scrlVolume;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.RadioButton optSOff;
		internal System.Windows.Forms.RadioButton optSOn;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.RadioButton optMOff;
		internal System.Windows.Forms.RadioButton optMOn;
		internal System.Windows.Forms.CheckBox chkHighEnd;
		internal System.Windows.Forms.CheckBox chkNpcBars;
        internal System.Windows.Forms.CheckBox checkBox1;
    }
	
}
