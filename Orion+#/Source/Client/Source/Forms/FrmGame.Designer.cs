
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using Engine;

namespace Engine
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
		public partial class FrmGame : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGame));
            this.picscreen = new System.Windows.Forms.PictureBox();
            this.pnlCurrency = new System.Windows.Forms.Panel();
            this.lblCurrencyCancel = new System.Windows.Forms.Label();
            this.lblCurrencyOk = new System.Windows.Forms.Label();
            this.txtCurrency = new System.Windows.Forms.TextBox();
            this.lblCurrency = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picscreen)).BeginInit();
            this.pnlCurrency.SuspendLayout();
            this.SuspendLayout();
            // 
            // picscreen
            // 
            this.picscreen.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picscreen.Location = new System.Drawing.Point(0, 0);
            this.picscreen.Margin = new System.Windows.Forms.Padding(0);
            this.picscreen.Name = "picscreen";
            this.picscreen.Size = new System.Drawing.Size(978, 615);
            this.picscreen.TabIndex = 4;
            this.picscreen.TabStop = false;
            this.picscreen.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Picscreen_KeyUp);
            this.picscreen.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Picscreen_KeyDown);
            this.picscreen.Paint += new System.Windows.Forms.PaintEventHandler(this.Picscreen_Paint);
            this.picscreen.DoubleClick += new System.EventHandler(this.Picscreen_DoubleClick);
            this.picscreen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Picscreen_MouseDown);
            this.picscreen.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Picscreen_MouseMove);
            this.picscreen.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Picscreen_MouseUp);
            // 
            // pnlCurrency
            // 
            this.pnlCurrency.BackColor = System.Drawing.Color.DimGray;
            this.pnlCurrency.Controls.Add(this.lblCurrencyCancel);
            this.pnlCurrency.Controls.Add(this.lblCurrencyOk);
            this.pnlCurrency.Controls.Add(this.txtCurrency);
            this.pnlCurrency.Controls.Add(this.lblCurrency);
            this.pnlCurrency.Location = new System.Drawing.Point(108, 343);
            this.pnlCurrency.Name = "pnlCurrency";
            this.pnlCurrency.Size = new System.Drawing.Size(351, 98);
            this.pnlCurrency.TabIndex = 16;
            this.pnlCurrency.Visible = false;
            // 
            // lblCurrencyCancel
            // 
            this.lblCurrencyCancel.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrencyCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrencyCancel.ForeColor = System.Drawing.Color.White;
            this.lblCurrencyCancel.Location = new System.Drawing.Point(214, 71);
            this.lblCurrencyCancel.Name = "lblCurrencyCancel";
            this.lblCurrencyCancel.Size = new System.Drawing.Size(108, 16);
            this.lblCurrencyCancel.TabIndex = 4;
            this.lblCurrencyCancel.Text = "Cancel";
            this.lblCurrencyCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCurrencyOk
            // 
            this.lblCurrencyOk.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrencyOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrencyOk.ForeColor = System.Drawing.Color.White;
            this.lblCurrencyOk.Location = new System.Drawing.Point(13, 71);
            this.lblCurrencyOk.Name = "lblCurrencyOk";
            this.lblCurrencyOk.Size = new System.Drawing.Size(102, 16);
            this.lblCurrencyOk.TabIndex = 3;
            this.lblCurrencyOk.Text = "Okay";
            this.lblCurrencyOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCurrencyOk.Click += new System.EventHandler(this.LblCurrencyOk_Click);
            // 
            // txtCurrency
            // 
            this.txtCurrency.Location = new System.Drawing.Point(84, 35);
            this.txtCurrency.Name = "txtCurrency";
            this.txtCurrency.Size = new System.Drawing.Size(180, 20);
            this.txtCurrency.TabIndex = 2;
            // 
            // lblCurrency
            // 
            this.lblCurrency.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrency.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrency.ForeColor = System.Drawing.Color.White;
            this.lblCurrency.Location = new System.Drawing.Point(3, 0);
            this.lblCurrency.Name = "lblCurrency";
            this.lblCurrency.Size = new System.Drawing.Size(345, 24);
            this.lblCurrency.TabIndex = 1;
            this.lblCurrency.Text = "How many do you want to drop?";
            this.lblCurrency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(983, 619);
            this.Controls.Add(this.pnlCurrency);
            this.Controls.Add(this.picscreen);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMainGame";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FrmMainGame_Closing);
            this.Load += new System.EventHandler(this.FrmMainGame_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMainGame_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmMainGame_KeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMainGame_KeyUp);
            this.Resize += new System.EventHandler(this.FrmGame_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picscreen)).EndInit();
            this.pnlCurrency.ResumeLayout(false);
            this.pnlCurrency.PerformLayout();
            this.ResumeLayout(false);

		}
		internal System.Windows.Forms.PictureBox picscreen;
		internal System.Windows.Forms.Panel pnlCurrency;
		internal System.Windows.Forms.Label lblCurrency;
		internal System.Windows.Forms.Label lblCurrencyCancel;
		internal System.Windows.Forms.Label lblCurrencyOk;
		internal System.Windows.Forms.TextBox txtCurrency;
	}
	
}
