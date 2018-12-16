
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using Engine;

namespace Engine
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class FrmAdmin : System.Windows.Forms.Form
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdmin));
			this.btnRespawn = new System.Windows.Forms.Button();
			base.Load += new System.EventHandler(FrmAdmin_Load);
			this.btnRespawn.Click += new System.EventHandler(this.BtnRespawn_Click);
			this.btnMapReport = new System.Windows.Forms.Button();
			this.btnMapReport.Click += new System.EventHandler(this.BtnMapReport_Click);
			this.btnALoc = new System.Windows.Forms.Button();
			this.btnALoc.Click += new System.EventHandler(this.BtnALoc_Click);
			this.btnSpawnItem = new System.Windows.Forms.Button();
			this.btnSpawnItem.Click += new System.EventHandler(this.BtnSpawnItem_Click);
			this.lblSpawnItemAmount = new System.Windows.Forms.Label();
			this.lblItemSpawn = new System.Windows.Forms.Label();
			this.btnAdminSetSprite = new System.Windows.Forms.Button();
			this.btnAdminSetSprite.Click += new System.EventHandler(this.BtnAdminSetSprite_Click);
			this.btnAdminWarpTo = new System.Windows.Forms.Button();
			this.btnAdminWarpTo.Click += new System.EventHandler(this.BtnAdminWarpTo_Click);
			this.Label5 = new System.Windows.Forms.Label();
			this.Label4 = new System.Windows.Forms.Label();
			this.btnAdminSetAccess = new System.Windows.Forms.Button();
			this.btnAdminSetAccess.Click += new System.EventHandler(this.BtnAdminSetAccess_Click);
			this.btnAdminWarpMe2 = new System.Windows.Forms.Button();
			this.btnAdminWarpMe2.Click += new System.EventHandler(this.BtnAdminWarpMe2_Click);
			this.btnAdminWarp2Me = new System.Windows.Forms.Button();
			this.btnAdminWarp2Me.Click += new System.EventHandler(this.BtnAdminWarp2Me_Click);
			this.btnAdminBan = new System.Windows.Forms.Button();
			this.btnAdminBan.Click += new System.EventHandler(this.BtnAdminBan_Click);
			this.btnAdminKick = new System.Windows.Forms.Button();
			this.btnAdminKick.Click += new System.EventHandler(this.BtnAdminKick_Click);
			this.txtAdminName = new System.Windows.Forms.TextBox();
			this.Label3 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.lstMaps = new System.Windows.Forms.ListView();
			this.lstMaps.DoubleClick += new System.EventHandler(this.LstMaps_DoubleClick);
			this.ColumnHeader1 = (System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader());
			this.ColumnHeader2 = (System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader());
			this.TabControl1 = new System.Windows.Forms.TabControl();
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.nudAdminSprite = new System.Windows.Forms.NumericUpDown();
			this.nudAdminMap = new System.Windows.Forms.NumericUpDown();
			this.btnLevelUp = new System.Windows.Forms.Button();
			this.btnLevelUp.Click += new System.EventHandler(this.BtnLevelUp_Click);
			this.cmbAccess = new System.Windows.Forms.ComboBox();
			this.TabPage3 = new System.Windows.Forms.TabPage();
			this.TabPage4 = new System.Windows.Forms.TabPage();
			this.nudSpawnItemAmount = new System.Windows.Forms.NumericUpDown();
			this.cmbSpawnItem = new System.Windows.Forms.ComboBox();
			this.cmbSpawnItem.SelectedIndexChanged += new System.EventHandler(this.CmbSpawnItem_SelectedIndexChanged);
			this.btnMapEditor = new System.Windows.Forms.Button();
			this.btnMapEditor.Click += new System.EventHandler(this.BtnMapEditor_Click);
			this.TabControl1.SuspendLayout();
			this.TabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudAdminSprite).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudAdminMap).BeginInit();
			this.TabPage3.SuspendLayout();
			this.TabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudSpawnItemAmount).BeginInit();
			this.SuspendLayout();
			//
			//btnRespawn
			//
			this.btnRespawn.Location = new System.Drawing.Point(136, 16);
			this.btnRespawn.Name = "btnRespawn";
			this.btnRespawn.Size = new System.Drawing.Size(106, 22);
			this.btnRespawn.TabIndex = 34;
			this.btnRespawn.Text = "Respawn Map";
			this.btnRespawn.UseVisualStyleBackColor = true;
			//
			//btnMapReport
			//
			this.btnMapReport.Location = new System.Drawing.Point(6, 209);
			this.btnMapReport.Name = "btnMapReport";
			this.btnMapReport.Size = new System.Drawing.Size(238, 22);
			this.btnMapReport.TabIndex = 33;
			this.btnMapReport.Text = "Refresh List";
			this.btnMapReport.UseVisualStyleBackColor = true;
			//
			//btnALoc
			//
			this.btnALoc.Location = new System.Drawing.Point(14, 16);
			this.btnALoc.Name = "btnALoc";
			this.btnALoc.Size = new System.Drawing.Size(106, 22);
			this.btnALoc.TabIndex = 31;
			this.btnALoc.Text = "Location";
			this.btnALoc.UseVisualStyleBackColor = true;
			//
			//btnSpawnItem
			//
			this.btnSpawnItem.Location = new System.Drawing.Point(14, 145);
			this.btnSpawnItem.Name = "btnSpawnItem";
			this.btnSpawnItem.Size = new System.Drawing.Size(228, 22);
			this.btnSpawnItem.TabIndex = 29;
			this.btnSpawnItem.Text = "Spawn Item";
			this.btnSpawnItem.UseVisualStyleBackColor = true;
			//
			//lblSpawnItemAmount
			//
			this.lblSpawnItemAmount.AutoSize = true;
			this.lblSpawnItemAmount.Location = new System.Drawing.Point(31, 121);
			this.lblSpawnItemAmount.Name = "lblSpawnItemAmount";
			this.lblSpawnItemAmount.Size = new System.Drawing.Size(46, 13);
			this.lblSpawnItemAmount.TabIndex = 26;
			this.lblSpawnItemAmount.Text = "Amount:";
			//
			//lblItemSpawn
			//
			this.lblItemSpawn.AutoSize = true;
			this.lblItemSpawn.Location = new System.Drawing.Point(11, 95);
			this.lblItemSpawn.Name = "lblItemSpawn";
			this.lblItemSpawn.Size = new System.Drawing.Size(66, 13);
			this.lblItemSpawn.TabIndex = 25;
			this.lblItemSpawn.Text = "Spawn Item:";
			//
			//btnAdminSetSprite
			//
			this.btnAdminSetSprite.Location = new System.Drawing.Point(134, 206);
			this.btnAdminSetSprite.Name = "btnAdminSetSprite";
			this.btnAdminSetSprite.Size = new System.Drawing.Size(108, 24);
			this.btnAdminSetSprite.TabIndex = 16;
			this.btnAdminSetSprite.Text = "Set Player Sprite";
			this.btnAdminSetSprite.UseVisualStyleBackColor = true;
			//
			//btnAdminWarpTo
			//
			this.btnAdminWarpTo.Location = new System.Drawing.Point(134, 176);
			this.btnAdminWarpTo.Name = "btnAdminWarpTo";
			this.btnAdminWarpTo.Size = new System.Drawing.Size(108, 24);
			this.btnAdminWarpTo.TabIndex = 15;
			this.btnAdminWarpTo.Text = "Warp To Map";
			this.btnAdminWarpTo.UseVisualStyleBackColor = true;
			//
			//Label5
			//
			this.Label5.AutoSize = true;
			this.Label5.Location = new System.Drawing.Point(6, 210);
			this.Label5.Name = "Label5";
			this.Label5.Size = new System.Drawing.Size(37, 13);
			this.Label5.TabIndex = 13;
			this.Label5.Text = "Sprite:";
			//
			//Label4
			//
			this.Label4.AutoSize = true;
			this.Label4.Location = new System.Drawing.Point(6, 182);
			this.Label4.Name = "Label4";
			this.Label4.Size = new System.Drawing.Size(71, 13);
			this.Label4.TabIndex = 11;
			this.Label4.Text = "Map Number:";
			//
			//btnAdminSetAccess
			//
			this.btnAdminSetAccess.Location = new System.Drawing.Point(9, 148);
			this.btnAdminSetAccess.Name = "btnAdminSetAccess";
			this.btnAdminSetAccess.Size = new System.Drawing.Size(233, 22);
			this.btnAdminSetAccess.TabIndex = 9;
			this.btnAdminSetAccess.Text = "Set Access";
			this.btnAdminSetAccess.UseVisualStyleBackColor = true;
			//
			//btnAdminWarpMe2
			//
			this.btnAdminWarpMe2.Location = new System.Drawing.Point(127, 62);
			this.btnAdminWarpMe2.Name = "btnAdminWarpMe2";
			this.btnAdminWarpMe2.Size = new System.Drawing.Size(115, 22);
			this.btnAdminWarpMe2.TabIndex = 8;
			this.btnAdminWarpMe2.Text = "Warp Me To Player";
			this.btnAdminWarpMe2.UseVisualStyleBackColor = true;
			//
			//btnAdminWarp2Me
			//
			this.btnAdminWarp2Me.Location = new System.Drawing.Point(6, 62);
			this.btnAdminWarp2Me.Name = "btnAdminWarp2Me";
			this.btnAdminWarp2Me.Size = new System.Drawing.Size(115, 22);
			this.btnAdminWarp2Me.TabIndex = 7;
			this.btnAdminWarp2Me.Text = "Warp Player To Me";
			this.btnAdminWarp2Me.UseVisualStyleBackColor = true;
			//
			//btnAdminBan
			//
			this.btnAdminBan.Location = new System.Drawing.Point(127, 34);
			this.btnAdminBan.Name = "btnAdminBan";
			this.btnAdminBan.Size = new System.Drawing.Size(115, 22);
			this.btnAdminBan.TabIndex = 6;
			this.btnAdminBan.Text = "Ban Player";
			this.btnAdminBan.UseVisualStyleBackColor = true;
			//
			//btnAdminKick
			//
			this.btnAdminKick.Location = new System.Drawing.Point(6, 34);
			this.btnAdminKick.Name = "btnAdminKick";
			this.btnAdminKick.Size = new System.Drawing.Size(115, 22);
			this.btnAdminKick.TabIndex = 5;
			this.btnAdminKick.Text = "Kick Player";
			this.btnAdminKick.UseVisualStyleBackColor = true;
			//
			//txtAdminName
			//
			this.txtAdminName.Location = new System.Drawing.Point(82, 8);
			this.txtAdminName.Name = "txtAdminName";
			this.txtAdminName.Size = new System.Drawing.Size(160, 20);
			this.txtAdminName.TabIndex = 3;
			//
			//Label3
			//
			this.Label3.AutoSize = true;
			this.Label3.Location = new System.Drawing.Point(6, 124);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(45, 13);
			this.Label3.TabIndex = 2;
			this.Label3.Text = "Access:";
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.Location = new System.Drawing.Point(6, 11);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(70, 13);
			this.Label2.TabIndex = 1;
			this.Label2.Text = "Player Name:";
			//
			//lstMaps
			//
			this.lstMaps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.ColumnHeader1, this.ColumnHeader2});
			this.lstMaps.FullRowSelect = true;
			this.lstMaps.GridLines = true;
			this.lstMaps.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.lstMaps.HideSelection = false;
			this.lstMaps.Location = new System.Drawing.Point(6, 6);
			this.lstMaps.MultiSelect = false;
			this.lstMaps.Name = "lstMaps";
			this.lstMaps.Size = new System.Drawing.Size(239, 197);
			this.lstMaps.TabIndex = 4;
			this.lstMaps.UseCompatibleStateImageBehavior = false;
			this.lstMaps.View = System.Windows.Forms.View.Details;
			//
			//ColumnHeader1
			//
			this.ColumnHeader1.Text = "#";
			this.ColumnHeader1.Width = 30;
			//
			//ColumnHeader2
			//
			this.ColumnHeader2.Text = "Name";
			this.ColumnHeader2.Width = 200;
			//
			//TabControl1
			//
			this.TabControl1.Controls.Add(this.TabPage1);
			this.TabControl1.Controls.Add(this.TabPage3);
			this.TabControl1.Controls.Add(this.TabPage4);
			this.TabControl1.Location = new System.Drawing.Point(2, 2);
			this.TabControl1.Name = "TabControl1";
			this.TabControl1.SelectedIndex = 0;
			this.TabControl1.Size = new System.Drawing.Size(258, 265);
			this.TabControl1.TabIndex = 38;
			//
			//TabPage1
			//
			this.TabPage1.Controls.Add(this.nudAdminSprite);
			this.TabPage1.Controls.Add(this.nudAdminMap);
			this.TabPage1.Controls.Add(this.btnLevelUp);
			this.TabPage1.Controls.Add(this.cmbAccess);
			this.TabPage1.Controls.Add(this.Label2);
			this.TabPage1.Controls.Add(this.Label3);
			this.TabPage1.Controls.Add(this.txtAdminName);
			this.TabPage1.Controls.Add(this.btnAdminKick);
			this.TabPage1.Controls.Add(this.btnAdminBan);
			this.TabPage1.Controls.Add(this.btnAdminWarp2Me);
			this.TabPage1.Controls.Add(this.btnAdminWarpMe2);
			this.TabPage1.Controls.Add(this.btnAdminSetAccess);
			this.TabPage1.Controls.Add(this.Label4);
			this.TabPage1.Controls.Add(this.Label5);
			this.TabPage1.Controls.Add(this.btnAdminWarpTo);
			this.TabPage1.Controls.Add(this.btnAdminSetSprite);
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(250, 239);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "Moderation";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//nudAdminSprite
			//
			this.nudAdminSprite.Location = new System.Drawing.Point(80, 208);
			this.nudAdminSprite.Name = "nudAdminSprite";
			this.nudAdminSprite.Size = new System.Drawing.Size(48, 20);
			this.nudAdminSprite.TabIndex = 33;
			//
			//nudAdminMap
			//
			this.nudAdminMap.Location = new System.Drawing.Point(80, 178);
			this.nudAdminMap.Name = "nudAdminMap";
			this.nudAdminMap.Size = new System.Drawing.Size(48, 20);
			this.nudAdminMap.TabIndex = 32;
			//
			//btnLevelUp
			//
			this.btnLevelUp.Location = new System.Drawing.Point(32, 90);
			this.btnLevelUp.Name = "btnLevelUp";
			this.btnLevelUp.Size = new System.Drawing.Size(188, 22);
			this.btnLevelUp.TabIndex = 31;
			this.btnLevelUp.Text = "Level Up";
			this.btnLevelUp.UseVisualStyleBackColor = true;
			//
			//cmbAccess
			//
			this.cmbAccess.FormattingEnabled = true;
			this.cmbAccess.Items.AddRange(new object[] {"Normal Player", "Monitor (GM)", "Mapper", "Developer", "Creator"});
			this.cmbAccess.Location = new System.Drawing.Point(57, 121);
			this.cmbAccess.Name = "cmbAccess";
			this.cmbAccess.Size = new System.Drawing.Size(185, 21);
			this.cmbAccess.TabIndex = 17;
			//
			//TabPage3
			//
			this.TabPage3.Controls.Add(this.lstMaps);
			this.TabPage3.Controls.Add(this.btnMapReport);
			this.TabPage3.Location = new System.Drawing.Point(4, 22);
			this.TabPage3.Name = "TabPage3";
			this.TabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage3.Size = new System.Drawing.Size(250, 239);
			this.TabPage3.TabIndex = 2;
			this.TabPage3.Text = "Map List";
			this.TabPage3.UseVisualStyleBackColor = true;
			//
			//TabPage4
			//
			this.TabPage4.Controls.Add(this.btnMapEditor);
			this.TabPage4.Controls.Add(this.nudSpawnItemAmount);
			this.TabPage4.Controls.Add(this.cmbSpawnItem);
			this.TabPage4.Controls.Add(this.btnRespawn);
			this.TabPage4.Controls.Add(this.btnALoc);
			this.TabPage4.Controls.Add(this.lblItemSpawn);
			this.TabPage4.Controls.Add(this.lblSpawnItemAmount);
			this.TabPage4.Controls.Add(this.btnSpawnItem);
			this.TabPage4.Location = new System.Drawing.Point(4, 22);
			this.TabPage4.Name = "TabPage4";
			this.TabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage4.Size = new System.Drawing.Size(250, 239);
			this.TabPage4.TabIndex = 3;
			this.TabPage4.Text = "Map Tools";
			this.TabPage4.UseVisualStyleBackColor = true;
			//
			//nudSpawnItemAmount
			//
			this.nudSpawnItemAmount.Location = new System.Drawing.Point(122, 119);
			this.nudSpawnItemAmount.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
			this.nudSpawnItemAmount.Name = "nudSpawnItemAmount";
			this.nudSpawnItemAmount.Size = new System.Drawing.Size(120, 20);
			this.nudSpawnItemAmount.TabIndex = 37;
			//
			//cmbSpawnItem
			//
			this.cmbSpawnItem.FormattingEnabled = true;
			this.cmbSpawnItem.Location = new System.Drawing.Point(83, 92);
			this.cmbSpawnItem.Name = "cmbSpawnItem";
			this.cmbSpawnItem.Size = new System.Drawing.Size(159, 21);
			this.cmbSpawnItem.TabIndex = 36;
			//
			//btnMapEditor
			//
			this.btnMapEditor.Location = new System.Drawing.Point(69, 44);
			this.btnMapEditor.Name = "btnMapEditor";
			this.btnMapEditor.Size = new System.Drawing.Size(106, 25);
			this.btnMapEditor.TabIndex = 39;
			this.btnMapEditor.Text = "Map Editor";
			this.btnMapEditor.UseVisualStyleBackColor = true;
			//
			//FrmAdmin
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(260, 270);
			this.Controls.Add(this.TabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = (System.Drawing.Icon) (resources.GetObject("$this.Icon"));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmAdmin";
			this.ShowIcon = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Admin Panel";
			this.TabControl1.ResumeLayout(false);
			this.TabPage1.ResumeLayout(false);
			this.TabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudAdminSprite).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudAdminMap).EndInit();
			this.TabPage3.ResumeLayout(false);
			this.TabPage4.ResumeLayout(false);
			this.TabPage4.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudSpawnItemAmount).EndInit();
			this.ResumeLayout(false);
			
		}
		internal System.Windows.Forms.Button btnRespawn;
		internal System.Windows.Forms.Button btnMapReport;
		internal System.Windows.Forms.Button btnALoc;
		internal System.Windows.Forms.Button btnSpawnItem;
		internal System.Windows.Forms.Label lblSpawnItemAmount;
		internal System.Windows.Forms.Label lblItemSpawn;
		internal System.Windows.Forms.Button btnAdminSetSprite;
		internal System.Windows.Forms.Button btnAdminWarpTo;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Button btnAdminSetAccess;
		internal System.Windows.Forms.Button btnAdminWarpMe2;
		internal System.Windows.Forms.Button btnAdminWarp2Me;
		internal System.Windows.Forms.Button btnAdminBan;
		internal System.Windows.Forms.Button btnAdminKick;
		internal System.Windows.Forms.TextBox txtAdminName;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ListView lstMaps;
		internal System.Windows.Forms.ColumnHeader ColumnHeader1;
		internal System.Windows.Forms.ColumnHeader ColumnHeader2;
		internal System.Windows.Forms.TabControl TabControl1;
		internal System.Windows.Forms.TabPage TabPage1;
		internal System.Windows.Forms.TabPage TabPage3;
		internal System.Windows.Forms.TabPage TabPage4;
		internal System.Windows.Forms.ComboBox cmbAccess;
		internal System.Windows.Forms.ComboBox cmbSpawnItem;
		internal System.Windows.Forms.NumericUpDown nudAdminSprite;
		internal System.Windows.Forms.NumericUpDown nudAdminMap;
		internal System.Windows.Forms.Button btnLevelUp;
		internal System.Windows.Forms.NumericUpDown nudSpawnItemAmount;
		internal System.Windows.Forms.Button btnMapEditor;
	}
	
}
