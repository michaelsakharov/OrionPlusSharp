
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
	partial class FrmVisualWarp : System.Windows.Forms.Form
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
            this.btnWarpOK = new DarkUI.Controls.DarkButton();
            this.DarkLabel15 = new DarkUI.Controls.DarkLabel();
            this.lstMaps = new System.Windows.Forms.ListBox();
            this.pnlPreview = new System.Windows.Forms.Panel();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.lblSelX = new DarkUI.Controls.DarkLabel();
            this.lblSelY = new DarkUI.Controls.DarkLabel();
            this.pnlPreview.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // btnWarpOK
            // 
            this.btnWarpOK.Location = new System.Drawing.Point(12, 504);
            this.btnWarpOK.Name = "btnWarpOK";
            this.btnWarpOK.Padding = new System.Windows.Forms.Padding(5);
            this.btnWarpOK.Size = new System.Drawing.Size(167, 23);
            this.btnWarpOK.TabIndex = 4;
            this.btnWarpOK.Text = "Ok";
            this.btnWarpOK.Click += new System.EventHandler(this.BtnWarpOK_Click);
            // 
            // DarkLabel15
            // 
            this.DarkLabel15.AutoSize = true;
            this.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.DarkLabel15.Location = new System.Drawing.Point(12, 9);
            this.DarkLabel15.Name = "DarkLabel15";
            this.DarkLabel15.Size = new System.Drawing.Size(47, 13);
            this.DarkLabel15.TabIndex = 3;
            this.DarkLabel15.Text = "Map List";
            // 
            // lstMaps
            // 
            this.lstMaps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.lstMaps.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstMaps.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstMaps.FormattingEnabled = true;
            this.lstMaps.Location = new System.Drawing.Point(12, 25);
            this.lstMaps.Name = "lstMaps";
            this.lstMaps.Size = new System.Drawing.Size(173, 275);
            this.lstMaps.TabIndex = 2;
            this.lstMaps.SelectedIndexChanged += new System.EventHandler(this.LstMaps_SelectedIndexChanged);
            // 
            // pnlPreview
            // 
            this.pnlPreview.AutoScroll = true;
            this.pnlPreview.Controls.Add(this.picPreview);
            this.pnlPreview.Location = new System.Drawing.Point(191, 12);
            this.pnlPreview.Name = "pnlPreview";
            this.pnlPreview.Size = new System.Drawing.Size(589, 515);
            this.pnlPreview.TabIndex = 1;
            this.pnlPreview.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PnlPreview_Scroll);
            this.pnlPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlPreview_Paint);
            // 
            // picPreview
            // 
            this.picPreview.Location = new System.Drawing.Point(3, 3);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(356, 376);
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            this.picPreview.Click += new System.EventHandler(this.PicPreview_Click);
            // 
            // lblSelX
            // 
            this.lblSelX.AutoSize = true;
            this.lblSelX.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblSelX.Location = new System.Drawing.Point(12, 313);
            this.lblSelX.Name = "lblSelX";
            this.lblSelX.Size = new System.Drawing.Size(71, 13);
            this.lblSelX.TabIndex = 5;
            this.lblSelX.Text = "Selected X: 0";
            // 
            // lblSelY
            // 
            this.lblSelY.AutoSize = true;
            this.lblSelY.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.lblSelY.Location = new System.Drawing.Point(12, 338);
            this.lblSelY.Name = "lblSelY";
            this.lblSelY.Size = new System.Drawing.Size(71, 13);
            this.lblSelY.TabIndex = 6;
            this.lblSelY.Text = "Selected Y: 0";
            // 
            // FrmVisualWarp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(63)))), ((int)(((byte)(65)))));
            this.ClientSize = new System.Drawing.Size(788, 539);
            this.ControlBox = false;
            this.Controls.Add(this.lblSelY);
            this.Controls.Add(this.lblSelX);
            this.Controls.Add(this.pnlPreview);
            this.Controls.Add(this.btnWarpOK);
            this.Controls.Add(this.DarkLabel15);
            this.Controls.Add(this.lstMaps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "FrmVisualWarp";
            this.Text = "Visual Warp";
            this.Load += new System.EventHandler(this.FrmVisualWarp_Load);
            this.pnlPreview.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal DarkUI.Controls.DarkButton btnWarpOK;
		internal DarkUI.Controls.DarkLabel DarkLabel15;
		internal ListBox lstMaps;
		internal Panel pnlPreview;
		internal PictureBox picPreview;
		internal DarkUI.Controls.DarkLabel lblSelX;
		internal DarkUI.Controls.DarkLabel lblSelY;
	}
	
}
