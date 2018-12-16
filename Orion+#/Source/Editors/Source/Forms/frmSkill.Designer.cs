
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
		public partial class frmSkill : System.Windows.Forms.Form
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
			this.DarkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
			base.Load += new System.EventHandler(FrmEditor_Skill_Load);
			this.lstIndex = new System.Windows.Forms.ListBox();
			this.lstIndex.Click += new System.EventHandler(this.LstIndex_Click);
			this.DarkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
			this.btnDelete = new DarkUI.Controls.DarkButton();
			this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
			this.btnCancel = new DarkUI.Controls.DarkButton();
			this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			this.btnSave = new DarkUI.Controls.DarkButton();
			this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
			this.DarkGroupBox5 = new DarkUI.Controls.DarkGroupBox();
			this.DarkGroupBox8 = new DarkUI.Controls.DarkGroupBox();
			this.cmbAnim = new DarkUI.Controls.DarkComboBox();
			this.cmbAnim.SelectedIndexChanged += new System.EventHandler(this.CmbAnim_Scroll);
			this.DarkLabel23 = new DarkUI.Controls.DarkLabel();
			this.cmbAnimCast = new DarkUI.Controls.DarkComboBox();
			this.cmbAnimCast.SelectedIndexChanged += new System.EventHandler(this.CmbAnimCast_Scroll);
			this.DarkLabel22 = new DarkUI.Controls.DarkLabel();
			this.nudStun = new DarkUI.Controls.DarkNumericUpDown();
			this.nudStun.ValueChanged += new System.EventHandler(this.NudStun_Scroll);
			this.DarkLabel21 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel20 = new DarkUI.Controls.DarkLabel();
			this.nudAoE = new DarkUI.Controls.DarkNumericUpDown();
			this.nudAoE.ValueChanged += new System.EventHandler(this.NudAoE_Scroll);
			this.DarkLabel19 = new DarkUI.Controls.DarkLabel();
			this.chkAoE = new DarkUI.Controls.DarkCheckBox();
			this.chkAoE.CheckedChanged += new System.EventHandler(this.ChkAOE_CheckedChanged);
			this.DarkLabel18 = new DarkUI.Controls.DarkLabel();
			this.nudRange = new DarkUI.Controls.DarkNumericUpDown();
			this.nudRange.ValueChanged += new System.EventHandler(this.NudRange_Scroll);
			this.DarkLabel17 = new DarkUI.Controls.DarkLabel();
			this.DarkGroupBox7 = new DarkUI.Controls.DarkGroupBox();
			this.nudInterval = new DarkUI.Controls.DarkNumericUpDown();
			this.nudInterval.ValueChanged += new System.EventHandler(this.NudInterval_Scroll);
			this.DarkLabel16 = new DarkUI.Controls.DarkLabel();
			this.nudDuration = new DarkUI.Controls.DarkNumericUpDown();
			this.nudDuration.ValueChanged += new System.EventHandler(this.NudDuration_Scroll);
			this.DarkLabel15 = new DarkUI.Controls.DarkLabel();
			this.nudVital = new DarkUI.Controls.DarkNumericUpDown();
			this.nudVital.ValueChanged += new System.EventHandler(this.NudVital_Scroll);
			this.DarkLabel14 = new DarkUI.Controls.DarkLabel();
			this.DarkGroupBox6 = new DarkUI.Controls.DarkGroupBox();
			this.nudY = new DarkUI.Controls.DarkNumericUpDown();
			this.nudY.ValueChanged += new System.EventHandler(this.NudY_Scroll);
			this.DarkLabel13 = new DarkUI.Controls.DarkLabel();
			this.nudX = new DarkUI.Controls.DarkNumericUpDown();
			this.nudX.ValueChanged += new System.EventHandler(this.NudX_Scroll);
			this.DarkLabel12 = new DarkUI.Controls.DarkLabel();
			this.cmbDir = new DarkUI.Controls.DarkComboBox();
			this.cmbDir.SelectedIndexChanged += new System.EventHandler(this.CmbDir_SelectedIndexChanged);
			this.DarkLabel11 = new DarkUI.Controls.DarkLabel();
			this.nudMap = new DarkUI.Controls.DarkNumericUpDown();
			this.nudMap.ValueChanged += new System.EventHandler(this.NudMap_Scroll);
			this.DarkLabel10 = new DarkUI.Controls.DarkLabel();
			this.DarkGroupBox3 = new DarkUI.Controls.DarkGroupBox();
			this.chkKnockBack = new DarkUI.Controls.DarkCheckBox();
			this.chkKnockBack.CheckedChanged += new System.EventHandler(this.ChkKnockBack_CheckedChanged);
			this.cmbKnockBackTiles = new DarkUI.Controls.DarkComboBox();
			this.cmbKnockBackTiles.SelectedIndexChanged += new System.EventHandler(this.CmbKnockBackTiles_SelectedIndexChanged);
			this.cmbProjectile = new DarkUI.Controls.DarkComboBox();
			this.cmbProjectile.SelectedIndexChanged += new System.EventHandler(this.ScrlProjectile_Scroll);
			this.chkProjectile = new DarkUI.Controls.DarkCheckBox();
			this.chkProjectile.CheckedChanged += new System.EventHandler(this.ChkProjectile_CheckedChanged);
			this.nudIcon = new DarkUI.Controls.DarkNumericUpDown();
			this.nudIcon.ValueChanged += new System.EventHandler(this.NudIcon_Scroll);
			this.DarkLabel9 = new DarkUI.Controls.DarkLabel();
			this.picSprite = new System.Windows.Forms.PictureBox();
			this.nudCool = new DarkUI.Controls.DarkNumericUpDown();
			this.nudCool.ValueChanged += new System.EventHandler(this.NudCool_Scroll);
			this.DarkLabel8 = new DarkUI.Controls.DarkLabel();
			this.nudCast = new DarkUI.Controls.DarkNumericUpDown();
			this.nudCast.ValueChanged += new System.EventHandler(this.NudCast_Scroll);
			this.DarkLabel7 = new DarkUI.Controls.DarkLabel();
			this.DarkGroupBox4 = new DarkUI.Controls.DarkGroupBox();
			this.DarkLabel6 = new DarkUI.Controls.DarkLabel();
			this.cmbClass = new DarkUI.Controls.DarkComboBox();
			this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.CmbClass_SelectedIndexChanged);
			this.cmbAccessReq = new DarkUI.Controls.DarkComboBox();
			this.cmbAccessReq.SelectedIndexChanged += new System.EventHandler(this.CmbAccessReq_SelectedIndexChanged);
			this.DarkLabel5 = new DarkUI.Controls.DarkLabel();
			this.nudLevel = new DarkUI.Controls.DarkNumericUpDown();
			this.nudLevel.ValueChanged += new System.EventHandler(this.NudLevel_ValueChanged);
			this.DarkLabel4 = new DarkUI.Controls.DarkLabel();
			this.nudMp = new DarkUI.Controls.DarkNumericUpDown();
			this.nudMp.ValueChanged += new System.EventHandler(this.NudMp_ValueChanged);
			this.DarkLabel3 = new DarkUI.Controls.DarkLabel();
			this.cmbType = new DarkUI.Controls.DarkComboBox();
			this.cmbType.SelectedIndexChanged += new System.EventHandler(this.CmbType_SelectedIndexChanged);
			this.DarkLabel2 = new DarkUI.Controls.DarkLabel();
			this.txtName = new DarkUI.Controls.DarkTextBox();
			this.txtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
			this.DarkLabel1 = new DarkUI.Controls.DarkLabel();
			this.DarkGroupBox1.SuspendLayout();
			this.DarkGroupBox2.SuspendLayout();
			this.DarkGroupBox5.SuspendLayout();
			this.DarkGroupBox8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudStun).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudAoE).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudRange).BeginInit();
			this.DarkGroupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudInterval).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudDuration).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudVital).BeginInit();
			this.DarkGroupBox6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudY).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudX).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudMap).BeginInit();
			this.DarkGroupBox3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.picSprite).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudCool).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudCast).BeginInit();
			this.DarkGroupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudLevel).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudMp).BeginInit();
			this.SuspendLayout();
			//
			//DarkGroupBox1
			//
			this.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox1.Controls.Add(this.lstIndex);
			this.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox1.Location = new System.Drawing.Point(3, 3);
			this.DarkGroupBox1.Name = "DarkGroupBox1";
			this.DarkGroupBox1.Size = new System.Drawing.Size(183, 394);
			this.DarkGroupBox1.TabIndex = 0;
			this.DarkGroupBox1.TabStop = false;
			this.DarkGroupBox1.Text = "Skill List";
			//
			//lstIndex
			//
			this.lstIndex.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstIndex.ForeColor = System.Drawing.Color.Gainsboro;
			this.lstIndex.FormattingEnabled = true;
			this.lstIndex.Location = new System.Drawing.Point(6, 19);
			this.lstIndex.Name = "lstIndex";
			this.lstIndex.Size = new System.Drawing.Size(171, 366);
			this.lstIndex.TabIndex = 1;
			//
			//DarkGroupBox2
			//
			this.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox2.Controls.Add(this.btnDelete);
			this.DarkGroupBox2.Controls.Add(this.btnCancel);
			this.DarkGroupBox2.Controls.Add(this.btnSave);
			this.DarkGroupBox2.Controls.Add(this.DarkGroupBox5);
			this.DarkGroupBox2.Controls.Add(this.DarkGroupBox3);
			this.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox2.Location = new System.Drawing.Point(192, 3);
			this.DarkGroupBox2.Name = "DarkGroupBox2";
			this.DarkGroupBox2.Size = new System.Drawing.Size(619, 394);
			this.DarkGroupBox2.TabIndex = 1;
			this.DarkGroupBox2.TabStop = false;
			this.DarkGroupBox2.Text = "Skill Properties";
			//
			//btnDelete
			//
			this.btnDelete.Location = new System.Drawing.Point(134, 365);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Padding = new System.Windows.Forms.Padding(5);
			this.btnDelete.Size = new System.Drawing.Size(75, 23);
			this.btnDelete.TabIndex = 4;
			this.btnDelete.Text = "Delete";
			//
			//btnCancel
			//
			this.btnCancel.Location = new System.Drawing.Point(261, 365);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 3;
			this.btnCancel.Text = "Cancel";
			//
			//btnSave
			//
			this.btnSave.Location = new System.Drawing.Point(6, 365);
			this.btnSave.Name = "btnSave";
			this.btnSave.Padding = new System.Windows.Forms.Padding(5);
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 2;
			this.btnSave.Text = "Save";
			//
			//DarkGroupBox5
			//
			this.DarkGroupBox5.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox5.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox5.Controls.Add(this.DarkGroupBox8);
			this.DarkGroupBox5.Controls.Add(this.DarkGroupBox7);
			this.DarkGroupBox5.Controls.Add(this.DarkGroupBox6);
			this.DarkGroupBox5.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox5.Location = new System.Drawing.Point(342, 19);
			this.DarkGroupBox5.Name = "DarkGroupBox5";
			this.DarkGroupBox5.Size = new System.Drawing.Size(267, 367);
			this.DarkGroupBox5.TabIndex = 1;
			this.DarkGroupBox5.TabStop = false;
			this.DarkGroupBox5.Text = "Data";
			//
			//DarkGroupBox8
			//
			this.DarkGroupBox8.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox8.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox8.Controls.Add(this.cmbAnim);
			this.DarkGroupBox8.Controls.Add(this.DarkLabel23);
			this.DarkGroupBox8.Controls.Add(this.cmbAnimCast);
			this.DarkGroupBox8.Controls.Add(this.DarkLabel22);
			this.DarkGroupBox8.Controls.Add(this.nudStun);
			this.DarkGroupBox8.Controls.Add(this.DarkLabel21);
			this.DarkGroupBox8.Controls.Add(this.DarkLabel20);
			this.DarkGroupBox8.Controls.Add(this.nudAoE);
			this.DarkGroupBox8.Controls.Add(this.DarkLabel19);
			this.DarkGroupBox8.Controls.Add(this.chkAoE);
			this.DarkGroupBox8.Controls.Add(this.DarkLabel18);
			this.DarkGroupBox8.Controls.Add(this.nudRange);
			this.DarkGroupBox8.Controls.Add(this.DarkLabel17);
			this.DarkGroupBox8.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox8.Location = new System.Drawing.Point(6, 181);
			this.DarkGroupBox8.Name = "DarkGroupBox8";
			this.DarkGroupBox8.Size = new System.Drawing.Size(254, 181);
			this.DarkGroupBox8.TabIndex = 2;
			this.DarkGroupBox8.TabStop = false;
			this.DarkGroupBox8.Text = "Cast Settings";
			//
			//cmbAnim
			//
			this.cmbAnim.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbAnim.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbAnim.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbAnim.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbAnim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAnim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbAnim.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbAnim.FormattingEnabled = true;
			this.cmbAnim.Location = new System.Drawing.Point(104, 153);
			this.cmbAnim.Name = "cmbAnim";
			this.cmbAnim.Size = new System.Drawing.Size(144, 21);
			this.cmbAnim.TabIndex = 12;
			//
			//DarkLabel23
			//
			this.DarkLabel23.AutoSize = true;
			this.DarkLabel23.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel23.Location = new System.Drawing.Point(6, 156);
			this.DarkLabel23.Name = "DarkLabel23";
			this.DarkLabel23.Size = new System.Drawing.Size(56, 13);
			this.DarkLabel23.TabIndex = 11;
			this.DarkLabel23.Text = "Animation:";
			//
			//cmbAnimCast
			//
			this.cmbAnimCast.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbAnimCast.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbAnimCast.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbAnimCast.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbAnimCast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAnimCast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbAnimCast.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbAnimCast.FormattingEnabled = true;
			this.cmbAnimCast.Location = new System.Drawing.Point(104, 126);
			this.cmbAnimCast.Name = "cmbAnimCast";
			this.cmbAnimCast.Size = new System.Drawing.Size(144, 21);
			this.cmbAnimCast.TabIndex = 10;
			//
			//DarkLabel22
			//
			this.DarkLabel22.AutoSize = true;
			this.DarkLabel22.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel22.Location = new System.Drawing.Point(6, 129);
			this.DarkLabel22.Name = "DarkLabel22";
			this.DarkLabel22.Size = new System.Drawing.Size(80, 13);
			this.DarkLabel22.TabIndex = 9;
			this.DarkLabel22.Text = "Cast Animation:";
			//
			//nudStun
			//
			this.nudStun.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudStun.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudStun.Location = new System.Drawing.Point(150, 95);
			this.nudStun.Name = "nudStun";
			this.nudStun.Size = new System.Drawing.Size(75, 20);
			this.nudStun.TabIndex = 8;
			//
			//DarkLabel21
			//
			this.DarkLabel21.AutoSize = true;
			this.DarkLabel21.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel21.Location = new System.Drawing.Point(6, 97);
			this.DarkLabel21.Name = "DarkLabel21";
			this.DarkLabel21.Size = new System.Drawing.Size(103, 13);
			this.DarkLabel21.TabIndex = 7;
			this.DarkLabel21.Text = "Stun Duration(secs):";
			//
			//DarkLabel20
			//
			this.DarkLabel20.AutoSize = true;
			this.DarkLabel20.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel20.Location = new System.Drawing.Point(107, 71);
			this.DarkLabel20.Name = "DarkLabel20";
			this.DarkLabel20.Size = new System.Drawing.Size(118, 13);
			this.DarkLabel20.TabIndex = 6;
			this.DarkLabel20.Text = "Tiles. Hint: 0 is self-cast";
			//
			//nudAoE
			//
			this.nudAoE.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudAoE.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudAoE.Location = new System.Drawing.Point(54, 69);
			this.nudAoE.Name = "nudAoE";
			this.nudAoE.Size = new System.Drawing.Size(47, 20);
			this.nudAoE.TabIndex = 5;
			//
			//DarkLabel19
			//
			this.DarkLabel19.AutoSize = true;
			this.DarkLabel19.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel19.Location = new System.Drawing.Point(6, 71);
			this.DarkLabel19.Name = "DarkLabel19";
			this.DarkLabel19.Size = new System.Drawing.Size(30, 13);
			this.DarkLabel19.TabIndex = 4;
			this.DarkLabel19.Text = "AoE:";
			//
			//chkAoE
			//
			this.chkAoE.AutoSize = true;
			this.chkAoE.Location = new System.Drawing.Point(9, 46);
			this.chkAoE.Name = "chkAoE";
			this.chkAoE.Size = new System.Drawing.Size(79, 17);
			this.chkAoE.TabIndex = 3;
			this.chkAoE.Text = "Is AoE Skill";
			//
			//DarkLabel18
			//
			this.DarkLabel18.AutoSize = true;
			this.DarkLabel18.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel18.Location = new System.Drawing.Point(107, 23);
			this.DarkLabel18.Name = "DarkLabel18";
			this.DarkLabel18.Size = new System.Drawing.Size(118, 13);
			this.DarkLabel18.TabIndex = 2;
			this.DarkLabel18.Text = "Tiles. Hint: 0 is self-cast";
			//
			//nudRange
			//
			this.nudRange.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudRange.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudRange.Location = new System.Drawing.Point(54, 20);
			this.nudRange.Name = "nudRange";
			this.nudRange.Size = new System.Drawing.Size(47, 20);
			this.nudRange.TabIndex = 1;
			//
			//DarkLabel17
			//
			this.DarkLabel17.AutoSize = true;
			this.DarkLabel17.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel17.Location = new System.Drawing.Point(6, 23);
			this.DarkLabel17.Name = "DarkLabel17";
			this.DarkLabel17.Size = new System.Drawing.Size(42, 13);
			this.DarkLabel17.TabIndex = 0;
			this.DarkLabel17.Text = "Range:";
			//
			//DarkGroupBox7
			//
			this.DarkGroupBox7.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox7.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox7.Controls.Add(this.nudInterval);
			this.DarkGroupBox7.Controls.Add(this.DarkLabel16);
			this.DarkGroupBox7.Controls.Add(this.nudDuration);
			this.DarkGroupBox7.Controls.Add(this.DarkLabel15);
			this.DarkGroupBox7.Controls.Add(this.nudVital);
			this.DarkGroupBox7.Controls.Add(this.DarkLabel14);
			this.DarkGroupBox7.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox7.Location = new System.Drawing.Point(6, 98);
			this.DarkGroupBox7.Name = "DarkGroupBox7";
			this.DarkGroupBox7.Size = new System.Drawing.Size(254, 77);
			this.DarkGroupBox7.TabIndex = 1;
			this.DarkGroupBox7.TabStop = false;
			this.DarkGroupBox7.Text = "HoT & DoT Settings ";
			//
			//nudInterval
			//
			this.nudInterval.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudInterval.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudInterval.Location = new System.Drawing.Point(203, 45);
			this.nudInterval.Name = "nudInterval";
			this.nudInterval.Size = new System.Drawing.Size(45, 20);
			this.nudInterval.TabIndex = 5;
			//
			//DarkLabel16
			//
			this.DarkLabel16.AutoSize = true;
			this.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel16.Location = new System.Drawing.Point(152, 47);
			this.DarkLabel16.Name = "DarkLabel16";
			this.DarkLabel16.Size = new System.Drawing.Size(45, 13);
			this.DarkLabel16.TabIndex = 4;
			this.DarkLabel16.Text = "Interval:";
			//
			//nudDuration
			//
			this.nudDuration.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudDuration.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudDuration.Location = new System.Drawing.Point(90, 45);
			this.nudDuration.Name = "nudDuration";
			this.nudDuration.Size = new System.Drawing.Size(45, 20);
			this.nudDuration.TabIndex = 3;
			//
			//DarkLabel15
			//
			this.DarkLabel15.AutoSize = true;
			this.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel15.Location = new System.Drawing.Point(6, 47);
			this.DarkLabel15.Name = "DarkLabel15";
			this.DarkLabel15.Size = new System.Drawing.Size(78, 13);
			this.DarkLabel15.TabIndex = 2;
			this.DarkLabel15.Text = "Duration(secs):";
			//
			//nudVital
			//
			this.nudVital.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudVital.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudVital.Location = new System.Drawing.Point(146, 19);
			this.nudVital.Name = "nudVital";
			this.nudVital.Size = new System.Drawing.Size(102, 20);
			this.nudVital.TabIndex = 1;
			//
			//DarkLabel14
			//
			this.DarkLabel14.AutoSize = true;
			this.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel14.Location = new System.Drawing.Point(6, 21);
			this.DarkLabel14.Name = "DarkLabel14";
			this.DarkLabel14.Size = new System.Drawing.Size(134, 13);
			this.DarkLabel14.TabIndex = 0;
			this.DarkLabel14.Text = "Amount to heal or damage:";
			//
			//DarkGroupBox6
			//
			this.DarkGroupBox6.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox6.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox6.Controls.Add(this.nudY);
			this.DarkGroupBox6.Controls.Add(this.DarkLabel13);
			this.DarkGroupBox6.Controls.Add(this.nudX);
			this.DarkGroupBox6.Controls.Add(this.DarkLabel12);
			this.DarkGroupBox6.Controls.Add(this.cmbDir);
			this.DarkGroupBox6.Controls.Add(this.DarkLabel11);
			this.DarkGroupBox6.Controls.Add(this.nudMap);
			this.DarkGroupBox6.Controls.Add(this.DarkLabel10);
			this.DarkGroupBox6.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox6.Location = new System.Drawing.Point(6, 14);
			this.DarkGroupBox6.Name = "DarkGroupBox6";
			this.DarkGroupBox6.Size = new System.Drawing.Size(254, 78);
			this.DarkGroupBox6.TabIndex = 0;
			this.DarkGroupBox6.TabStop = false;
			this.DarkGroupBox6.Text = "Warp Settings";
			//
			//nudY
			//
			this.nudY.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudY.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudY.Location = new System.Drawing.Point(176, 45);
			this.nudY.Name = "nudY";
			this.nudY.Size = new System.Drawing.Size(69, 20);
			this.nudY.TabIndex = 7;
			//
			//DarkLabel13
			//
			this.DarkLabel13.AutoSize = true;
			this.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel13.Location = new System.Drawing.Point(118, 47);
			this.DarkLabel13.Name = "DarkLabel13";
			this.DarkLabel13.Size = new System.Drawing.Size(17, 13);
			this.DarkLabel13.TabIndex = 6;
			this.DarkLabel13.Text = "Y:";
			//
			//nudX
			//
			this.nudX.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudX.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudX.Location = new System.Drawing.Point(43, 45);
			this.nudX.Name = "nudX";
			this.nudX.Size = new System.Drawing.Size(69, 20);
			this.nudX.TabIndex = 5;
			//
			//DarkLabel12
			//
			this.DarkLabel12.AutoSize = true;
			this.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel12.Location = new System.Drawing.Point(6, 47);
			this.DarkLabel12.Name = "DarkLabel12";
			this.DarkLabel12.Size = new System.Drawing.Size(17, 13);
			this.DarkLabel12.TabIndex = 4;
			this.DarkLabel12.Text = "X:";
			//
			//cmbDir
			//
			this.cmbDir.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbDir.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbDir.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbDir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbDir.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbDir.FormattingEnabled = true;
			this.cmbDir.Items.AddRange(new object[] {"Up", "Down", "Left", "Right"});
			this.cmbDir.Location = new System.Drawing.Point(176, 18);
			this.cmbDir.Name = "cmbDir";
			this.cmbDir.Size = new System.Drawing.Size(69, 21);
			this.cmbDir.TabIndex = 3;
			//
			//DarkLabel11
			//
			this.DarkLabel11.AutoSize = true;
			this.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel11.Location = new System.Drawing.Point(118, 21);
			this.DarkLabel11.Name = "DarkLabel11";
			this.DarkLabel11.Size = new System.Drawing.Size(52, 13);
			this.DarkLabel11.TabIndex = 2;
			this.DarkLabel11.Text = "Direction:";
			//
			//nudMap
			//
			this.nudMap.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudMap.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudMap.Location = new System.Drawing.Point(43, 19);
			this.nudMap.Name = "nudMap";
			this.nudMap.Size = new System.Drawing.Size(69, 20);
			this.nudMap.TabIndex = 1;
			//
			//DarkLabel10
			//
			this.DarkLabel10.AutoSize = true;
			this.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel10.Location = new System.Drawing.Point(6, 21);
			this.DarkLabel10.Name = "DarkLabel10";
			this.DarkLabel10.Size = new System.Drawing.Size(31, 13);
			this.DarkLabel10.TabIndex = 0;
			this.DarkLabel10.Text = "Map:";
			//
			//DarkGroupBox3
			//
			this.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox3.Controls.Add(this.chkKnockBack);
			this.DarkGroupBox3.Controls.Add(this.cmbKnockBackTiles);
			this.DarkGroupBox3.Controls.Add(this.cmbProjectile);
			this.DarkGroupBox3.Controls.Add(this.chkProjectile);
			this.DarkGroupBox3.Controls.Add(this.nudIcon);
			this.DarkGroupBox3.Controls.Add(this.DarkLabel9);
			this.DarkGroupBox3.Controls.Add(this.picSprite);
			this.DarkGroupBox3.Controls.Add(this.nudCool);
			this.DarkGroupBox3.Controls.Add(this.DarkLabel8);
			this.DarkGroupBox3.Controls.Add(this.nudCast);
			this.DarkGroupBox3.Controls.Add(this.DarkLabel7);
			this.DarkGroupBox3.Controls.Add(this.DarkGroupBox4);
			this.DarkGroupBox3.Controls.Add(this.nudMp);
			this.DarkGroupBox3.Controls.Add(this.DarkLabel3);
			this.DarkGroupBox3.Controls.Add(this.cmbType);
			this.DarkGroupBox3.Controls.Add(this.DarkLabel2);
			this.DarkGroupBox3.Controls.Add(this.txtName);
			this.DarkGroupBox3.Controls.Add(this.DarkLabel1);
			this.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox3.Location = new System.Drawing.Point(6, 19);
			this.DarkGroupBox3.Name = "DarkGroupBox3";
			this.DarkGroupBox3.Size = new System.Drawing.Size(330, 323);
			this.DarkGroupBox3.TabIndex = 0;
			this.DarkGroupBox3.TabStop = false;
			this.DarkGroupBox3.Text = "Basic Settings";
			//
			//chkKnockBack
			//
			this.chkKnockBack.AutoSize = true;
			this.chkKnockBack.Location = new System.Drawing.Point(9, 158);
			this.chkKnockBack.Name = "chkKnockBack";
			this.chkKnockBack.Size = new System.Drawing.Size(114, 17);
			this.chkKnockBack.TabIndex = 61;
			this.chkKnockBack.Text = "Has knockback of";
			//
			//cmbKnockBackTiles
			//
			this.cmbKnockBackTiles.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbKnockBackTiles.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbKnockBackTiles.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbKnockBackTiles.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbKnockBackTiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbKnockBackTiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbKnockBackTiles.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbKnockBackTiles.FormattingEnabled = true;
			this.cmbKnockBackTiles.Items.AddRange(new object[] {"No KnockBack", "1 Tile", "2 Tiles", "3 Tiles", "4 Tiles", "5 Tiles"});
			this.cmbKnockBackTiles.Location = new System.Drawing.Point(153, 156);
			this.cmbKnockBackTiles.Name = "cmbKnockBackTiles";
			this.cmbKnockBackTiles.Size = new System.Drawing.Size(171, 21);
			this.cmbKnockBackTiles.TabIndex = 60;
			//
			//cmbProjectile
			//
			this.cmbProjectile.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbProjectile.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbProjectile.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbProjectile.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbProjectile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProjectile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbProjectile.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbProjectile.FormattingEnabled = true;
			this.cmbProjectile.Location = new System.Drawing.Point(153, 129);
			this.cmbProjectile.Name = "cmbProjectile";
			this.cmbProjectile.Size = new System.Drawing.Size(171, 21);
			this.cmbProjectile.TabIndex = 59;
			//
			//chkProjectile
			//
			this.chkProjectile.AutoSize = true;
			this.chkProjectile.Location = new System.Drawing.Point(9, 131);
			this.chkProjectile.Name = "chkProjectile";
			this.chkProjectile.Size = new System.Drawing.Size(97, 17);
			this.chkProjectile.TabIndex = 58;
			this.chkProjectile.Text = "Has Projectile?";
			//
			//nudIcon
			//
			this.nudIcon.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudIcon.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudIcon.Location = new System.Drawing.Point(72, 93);
			this.nudIcon.Name = "nudIcon";
			this.nudIcon.Size = new System.Drawing.Size(80, 20);
			this.nudIcon.TabIndex = 57;
			//
			//DarkLabel9
			//
			this.DarkLabel9.AutoSize = true;
			this.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel9.Location = new System.Drawing.Point(6, 95);
			this.DarkLabel9.Name = "DarkLabel9";
			this.DarkLabel9.Size = new System.Drawing.Size(31, 13);
			this.DarkLabel9.TabIndex = 56;
			this.DarkLabel9.Text = "Icon:";
			//
			//picSprite
			//
			this.picSprite.BackColor = System.Drawing.Color.Black;
			this.picSprite.Location = new System.Drawing.Point(158, 91);
			this.picSprite.Name = "picSprite";
			this.picSprite.Size = new System.Drawing.Size(32, 32);
			this.picSprite.TabIndex = 55;
			this.picSprite.TabStop = false;
			//
			//nudCool
			//
			this.nudCool.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudCool.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudCool.Location = new System.Drawing.Point(247, 67);
			this.nudCool.Name = "nudCool";
			this.nudCool.Size = new System.Drawing.Size(77, 20);
			this.nudCool.TabIndex = 12;
			//
			//DarkLabel8
			//
			this.DarkLabel8.AutoSize = true;
			this.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel8.Location = new System.Drawing.Point(158, 69);
			this.DarkLabel8.Name = "DarkLabel8";
			this.DarkLabel8.Size = new System.Drawing.Size(83, 13);
			this.DarkLabel8.TabIndex = 11;
			this.DarkLabel8.Text = "Cooldown Time:";
			//
			//nudCast
			//
			this.nudCast.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudCast.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudCast.Location = new System.Drawing.Point(72, 67);
			this.nudCast.Name = "nudCast";
			this.nudCast.Size = new System.Drawing.Size(80, 20);
			this.nudCast.TabIndex = 10;
			//
			//DarkLabel7
			//
			this.DarkLabel7.AutoSize = true;
			this.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel7.Location = new System.Drawing.Point(6, 69);
			this.DarkLabel7.Name = "DarkLabel7";
			this.DarkLabel7.Size = new System.Drawing.Size(57, 13);
			this.DarkLabel7.TabIndex = 9;
			this.DarkLabel7.Text = "Cast Time:";
			//
			//DarkGroupBox4
			//
			this.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox4.Controls.Add(this.DarkLabel6);
			this.DarkGroupBox4.Controls.Add(this.cmbClass);
			this.DarkGroupBox4.Controls.Add(this.cmbAccessReq);
			this.DarkGroupBox4.Controls.Add(this.DarkLabel5);
			this.DarkGroupBox4.Controls.Add(this.nudLevel);
			this.DarkGroupBox4.Controls.Add(this.DarkLabel4);
			this.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox4.Location = new System.Drawing.Point(6, 227);
			this.DarkGroupBox4.Name = "DarkGroupBox4";
			this.DarkGroupBox4.Size = new System.Drawing.Size(318, 87);
			this.DarkGroupBox4.TabIndex = 8;
			this.DarkGroupBox4.TabStop = false;
			this.DarkGroupBox4.Text = "Requirements";
			//
			//DarkLabel6
			//
			this.DarkLabel6.AutoSize = true;
			this.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel6.Location = new System.Drawing.Point(6, 48);
			this.DarkLabel6.Name = "DarkLabel6";
			this.DarkLabel6.Size = new System.Drawing.Size(81, 13);
			this.DarkLabel6.TabIndex = 11;
			this.DarkLabel6.Text = "Class Required:";
			//
			//cmbClass
			//
			this.cmbClass.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbClass.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbClass.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbClass.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbClass.FormattingEnabled = true;
			this.cmbClass.Location = new System.Drawing.Point(94, 45);
			this.cmbClass.Name = "cmbClass";
			this.cmbClass.Size = new System.Drawing.Size(218, 21);
			this.cmbClass.TabIndex = 10;
			//
			//cmbAccessReq
			//
			this.cmbAccessReq.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbAccessReq.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbAccessReq.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbAccessReq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbAccessReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAccessReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbAccessReq.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbAccessReq.FormattingEnabled = true;
			this.cmbAccessReq.Items.AddRange(new object[] {"Player", "Monitor", "Mapper", "Developer", "Creator"});
			this.cmbAccessReq.Location = new System.Drawing.Point(241, 18);
			this.cmbAccessReq.Name = "cmbAccessReq";
			this.cmbAccessReq.Size = new System.Drawing.Size(71, 21);
			this.cmbAccessReq.TabIndex = 9;
			//
			//DarkLabel5
			//
			this.DarkLabel5.AutoSize = true;
			this.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel5.Location = new System.Drawing.Point(144, 21);
			this.DarkLabel5.Name = "DarkLabel5";
			this.DarkLabel5.Size = new System.Drawing.Size(91, 13);
			this.DarkLabel5.TabIndex = 8;
			this.DarkLabel5.Text = "Access Required:";
			//
			//nudLevel
			//
			this.nudLevel.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudLevel.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudLevel.Location = new System.Drawing.Point(94, 19);
			this.nudLevel.Name = "nudLevel";
			this.nudLevel.Size = new System.Drawing.Size(44, 20);
			this.nudLevel.TabIndex = 7;
			//
			//DarkLabel4
			//
			this.DarkLabel4.AutoSize = true;
			this.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel4.Location = new System.Drawing.Point(6, 21);
			this.DarkLabel4.Name = "DarkLabel4";
			this.DarkLabel4.Size = new System.Drawing.Size(82, 13);
			this.DarkLabel4.TabIndex = 6;
			this.DarkLabel4.Text = "Level Required:";
			//
			//nudMp
			//
			this.nudMp.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudMp.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudMp.Location = new System.Drawing.Point(247, 40);
			this.nudMp.Name = "nudMp";
			this.nudMp.Size = new System.Drawing.Size(77, 20);
			this.nudMp.TabIndex = 5;
			//
			//DarkLabel3
			//
			this.DarkLabel3.AutoSize = true;
			this.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel3.Location = new System.Drawing.Point(191, 43);
			this.DarkLabel3.Name = "DarkLabel3";
			this.DarkLabel3.Size = new System.Drawing.Size(50, 13);
			this.DarkLabel3.TabIndex = 4;
			this.DarkLabel3.Text = "MP Cost:";
			//
			//cmbType
			//
			this.cmbType.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbType.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbType.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbType.FormattingEnabled = true;
			this.cmbType.Items.AddRange(new object[] {"Damage HP", "Damage MP", "Heal HP", "Heal MP", "Warp"});
			this.cmbType.Location = new System.Drawing.Point(72, 40);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(90, 21);
			this.cmbType.TabIndex = 3;
			//
			//DarkLabel2
			//
			this.DarkLabel2.AutoSize = true;
			this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel2.Location = new System.Drawing.Point(6, 43);
			this.DarkLabel2.Name = "DarkLabel2";
			this.DarkLabel2.Size = new System.Drawing.Size(56, 13);
			this.DarkLabel2.TabIndex = 2;
			this.DarkLabel2.Text = "Skill Type:";
			//
			//txtName
			//
			this.txtName.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtName.Location = new System.Drawing.Point(72, 14);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(252, 20);
			this.txtName.TabIndex = 1;
			//
			//DarkLabel1
			//
			this.DarkLabel1.AutoSize = true;
			this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel1.Location = new System.Drawing.Point(6, 16);
			this.DarkLabel1.Name = "DarkLabel1";
			this.DarkLabel1.Size = new System.Drawing.Size(60, 13);
			this.DarkLabel1.TabIndex = 0;
			this.DarkLabel1.Text = "Skill Name:";
			//
			//frmEditor_Skill
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.ClientSize = new System.Drawing.Size(816, 401);
			this.ControlBox = false;
			this.Controls.Add(this.DarkGroupBox2);
			this.Controls.Add(this.DarkGroupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmEditor_Skill";
			this.Text = "Skill Editor";
			this.DarkGroupBox1.ResumeLayout(false);
			this.DarkGroupBox2.ResumeLayout(false);
			this.DarkGroupBox5.ResumeLayout(false);
			this.DarkGroupBox8.ResumeLayout(false);
			this.DarkGroupBox8.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudStun).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudAoE).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudRange).EndInit();
			this.DarkGroupBox7.ResumeLayout(false);
			this.DarkGroupBox7.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudInterval).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudDuration).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudVital).EndInit();
			this.DarkGroupBox6.ResumeLayout(false);
			this.DarkGroupBox6.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudY).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudX).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudMap).EndInit();
			this.DarkGroupBox3.ResumeLayout(false);
			this.DarkGroupBox3.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudIcon).EndInit();
			((System.ComponentModel.ISupportInitialize) this.picSprite).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudCool).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudCast).EndInit();
			this.DarkGroupBox4.ResumeLayout(false);
			this.DarkGroupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudLevel).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudMp).EndInit();
			this.ResumeLayout(false);
			
		}
		
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox1;
		internal ListBox lstIndex;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox2;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox3;
		internal DarkUI.Controls.DarkTextBox txtName;
		internal DarkUI.Controls.DarkLabel DarkLabel1;
		internal DarkUI.Controls.DarkComboBox cmbType;
		internal DarkUI.Controls.DarkLabel DarkLabel2;
		internal DarkUI.Controls.DarkNumericUpDown nudMp;
		internal DarkUI.Controls.DarkLabel DarkLabel3;
		internal DarkUI.Controls.DarkNumericUpDown nudLevel;
		internal DarkUI.Controls.DarkLabel DarkLabel4;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox4;
		internal DarkUI.Controls.DarkLabel DarkLabel5;
		internal DarkUI.Controls.DarkComboBox cmbAccessReq;
		internal DarkUI.Controls.DarkLabel DarkLabel6;
		internal DarkUI.Controls.DarkComboBox cmbClass;
		internal DarkUI.Controls.DarkNumericUpDown nudCast;
		internal DarkUI.Controls.DarkLabel DarkLabel7;
		internal DarkUI.Controls.DarkNumericUpDown nudCool;
		internal DarkUI.Controls.DarkLabel DarkLabel8;
		internal DarkUI.Controls.DarkLabel DarkLabel9;
		internal PictureBox picSprite;
		internal DarkUI.Controls.DarkNumericUpDown nudIcon;
		internal DarkUI.Controls.DarkCheckBox chkProjectile;
		internal DarkUI.Controls.DarkComboBox cmbProjectile;
		internal DarkUI.Controls.DarkCheckBox chkKnockBack;
		internal DarkUI.Controls.DarkComboBox cmbKnockBackTiles;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox5;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox6;
		internal DarkUI.Controls.DarkNumericUpDown nudMap;
		internal DarkUI.Controls.DarkLabel DarkLabel10;
		internal DarkUI.Controls.DarkLabel DarkLabel11;
		internal DarkUI.Controls.DarkComboBox cmbDir;
		internal DarkUI.Controls.DarkNumericUpDown nudX;
		internal DarkUI.Controls.DarkLabel DarkLabel12;
		internal DarkUI.Controls.DarkNumericUpDown nudY;
		internal DarkUI.Controls.DarkLabel DarkLabel13;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox7;
		internal DarkUI.Controls.DarkNumericUpDown nudVital;
		internal DarkUI.Controls.DarkLabel DarkLabel14;
		internal DarkUI.Controls.DarkNumericUpDown nudDuration;
		internal DarkUI.Controls.DarkLabel DarkLabel15;
		internal DarkUI.Controls.DarkNumericUpDown nudInterval;
		internal DarkUI.Controls.DarkLabel DarkLabel16;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox8;
		internal DarkUI.Controls.DarkLabel DarkLabel18;
		internal DarkUI.Controls.DarkNumericUpDown nudRange;
		internal DarkUI.Controls.DarkLabel DarkLabel17;
		internal DarkUI.Controls.DarkCheckBox chkAoE;
		internal DarkUI.Controls.DarkLabel DarkLabel20;
		internal DarkUI.Controls.DarkNumericUpDown nudAoE;
		internal DarkUI.Controls.DarkLabel DarkLabel19;
		internal DarkUI.Controls.DarkNumericUpDown nudStun;
		internal DarkUI.Controls.DarkLabel DarkLabel21;
		internal DarkUI.Controls.DarkLabel DarkLabel22;
		internal DarkUI.Controls.DarkComboBox cmbAnimCast;
		internal DarkUI.Controls.DarkComboBox cmbAnim;
		internal DarkUI.Controls.DarkLabel DarkLabel23;
		internal DarkUI.Controls.DarkButton btnDelete;
		internal DarkUI.Controls.DarkButton btnCancel;
		internal DarkUI.Controls.DarkButton btnSave;
	}
	
}
