using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Engine
{
    partial class FrmAnimation : System.Windows.Forms.Form
    {

        // Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                    components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAnimation));
            this.DarkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.lstIndex = new System.Windows.Forms.ListBox();
            this.DarkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.cmbSound = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel2 = new DarkUI.Controls.DarkLabel();
            this.DarkGroupBox4 = new DarkUI.Controls.DarkGroupBox();
            this.nudLoopTime1 = new DarkUI.Controls.DarkNumericUpDown();
            this.nudFrameCount1 = new DarkUI.Controls.DarkNumericUpDown();
            this.nudLoopCount1 = new DarkUI.Controls.DarkNumericUpDown();
            this.nudSprite1 = new DarkUI.Controls.DarkNumericUpDown();
            this.lblLoopTime1 = new DarkUI.Controls.DarkLabel();
            this.lblFrameCount1 = new DarkUI.Controls.DarkLabel();
            this.lblLoopCount1 = new DarkUI.Controls.DarkLabel();
            this.lblSprite1 = new DarkUI.Controls.DarkLabel();
            this.picSprite1 = new System.Windows.Forms.PictureBox();
            this.DarkGroupBox3 = new DarkUI.Controls.DarkGroupBox();
            this.nudLoopTime0 = new DarkUI.Controls.DarkNumericUpDown();
            this.nudFrameCount0 = new DarkUI.Controls.DarkNumericUpDown();
            this.nudLoopCount0 = new DarkUI.Controls.DarkNumericUpDown();
            this.nudSprite0 = new DarkUI.Controls.DarkNumericUpDown();
            this.lblLoopTime0 = new DarkUI.Controls.DarkLabel();
            this.lblFrameCount0 = new DarkUI.Controls.DarkLabel();
            this.lblLoopCount0 = new DarkUI.Controls.DarkLabel();
            this.lblSprite0 = new DarkUI.Controls.DarkLabel();
            this.picSprite0 = new System.Windows.Forms.PictureBox();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel1 = new DarkUI.Controls.DarkLabel();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.btnDelete = new DarkUI.Controls.DarkButton();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.DarkGroupBox1.SuspendLayout();
            this.DarkGroupBox2.SuspendLayout();
            this.DarkGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudLoopTime1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudFrameCount1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudLoopCount1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSprite1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.picSprite1).BeginInit();
            this.DarkGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudLoopTime0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudFrameCount0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudLoopCount0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSprite0).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.picSprite0).BeginInit();
            this.SuspendLayout();
            // 
            // DarkGroupBox1
            // 
            this.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox1.Controls.Add(this.lstIndex);
            this.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox1.Location = new System.Drawing.Point(2, 3);
            this.DarkGroupBox1.Name = "DarkGroupBox1";
            this.DarkGroupBox1.Size = new System.Drawing.Size(200, 464);
            this.DarkGroupBox1.TabIndex = 0;
            this.DarkGroupBox1.TabStop = false;
            this.DarkGroupBox1.Text = "Animations List";
            // 
            // lstIndex
            // 
            this.lstIndex.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstIndex.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstIndex.FormattingEnabled = true;
            this.lstIndex.Location = new System.Drawing.Point(6, 19);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(188, 403);
            this.lstIndex.TabIndex = 0;
            // 
            // DarkGroupBox2
            // 
            this.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox2.Controls.Add(this.cmbSound);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel2);
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox4);
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox3);
            this.DarkGroupBox2.Controls.Add(this.txtName);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel1);
            this.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox2.Location = new System.Drawing.Point(208, 3);
            this.DarkGroupBox2.Name = "DarkGroupBox2";
            this.DarkGroupBox2.Size = new System.Drawing.Size(438, 464);
            this.DarkGroupBox2.TabIndex = 1;
            this.DarkGroupBox2.TabStop = false;
            this.DarkGroupBox2.Text = "Animation Properties";
            // 
            // cmbSound
            // 
            this.cmbSound.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbSound.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbSound.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSound.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbSound.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbSound.ButtonIcon");
            this.cmbSound.DrawDropdownHoverOutline = false;
            this.cmbSound.DrawFocusRectangle = false;
            this.cmbSound.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.cmbSound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSound.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSound.FormattingEnabled = true;
            this.cmbSound.Location = new System.Drawing.Point(117, 54);
            this.cmbSound.Name = "cmbSound";
            this.cmbSound.Size = new System.Drawing.Size(156, 21);
            this.cmbSound.TabIndex = 25;
            this.cmbSound.Text = null;
            this.cmbSound.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel2
            // 
            this.DarkLabel2.AutoSize = true;
            this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel2.Location = new System.Drawing.Point(16, 57);
            this.DarkLabel2.Name = "DarkLabel2";
            this.DarkLabel2.Size = new System.Drawing.Size(90, 13);
            this.DarkLabel2.TabIndex = 24;
            this.DarkLabel2.Text = "Animation Sound:";
            // 
            // DarkGroupBox4
            // 
            this.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox4.Controls.Add(this.nudLoopTime1);
            this.DarkGroupBox4.Controls.Add(this.nudFrameCount1);
            this.DarkGroupBox4.Controls.Add(this.nudLoopCount1);
            this.DarkGroupBox4.Controls.Add(this.nudSprite1);
            this.DarkGroupBox4.Controls.Add(this.lblLoopTime1);
            this.DarkGroupBox4.Controls.Add(this.lblFrameCount1);
            this.DarkGroupBox4.Controls.Add(this.lblLoopCount1);
            this.DarkGroupBox4.Controls.Add(this.lblSprite1);
            this.DarkGroupBox4.Controls.Add(this.picSprite1);
            this.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox4.Location = new System.Drawing.Point(6, 278);
            this.DarkGroupBox4.Name = "DarkGroupBox4";
            this.DarkGroupBox4.Size = new System.Drawing.Size(426, 180);
            this.DarkGroupBox4.TabIndex = 23;
            this.DarkGroupBox4.TabStop = false;
            this.DarkGroupBox4.Text = "Layer 1 - Above Player";
            // 
            // nudLoopTime1
            // 
            this.nudLoopTime1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudLoopTime1.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLoopTime1.Location = new System.Drawing.Point(87, 138);
            this.nudLoopTime1.Name = "nudLoopTime1";
            this.nudLoopTime1.Size = new System.Drawing.Size(120, 20);
            this.nudLoopTime1.TabIndex = 33;
            // 
            // nudFrameCount1
            // 
            this.nudFrameCount1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudFrameCount1.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudFrameCount1.Location = new System.Drawing.Point(87, 99);
            this.nudFrameCount1.Name = "nudFrameCount1";
            this.nudFrameCount1.Size = new System.Drawing.Size(120, 20);
            this.nudFrameCount1.TabIndex = 32;
            // 
            // nudLoopCount1
            // 
            this.nudLoopCount1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudLoopCount1.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLoopCount1.Location = new System.Drawing.Point(87, 61);
            this.nudLoopCount1.Name = "nudLoopCount1";
            this.nudLoopCount1.Size = new System.Drawing.Size(120, 20);
            this.nudLoopCount1.TabIndex = 31;
            // 
            // nudSprite1
            // 
            this.nudSprite1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudSprite1.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSprite1.Location = new System.Drawing.Point(87, 24);
            this.nudSprite1.Name = "nudSprite1";
            this.nudSprite1.Size = new System.Drawing.Size(120, 20);
            this.nudSprite1.TabIndex = 30;
            // 
            // lblLoopTime1
            // 
            this.lblLoopTime1.AutoSize = true;
            this.lblLoopTime1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblLoopTime1.Location = new System.Drawing.Point(10, 140);
            this.lblLoopTime1.Name = "lblLoopTime1";
            this.lblLoopTime1.Size = new System.Drawing.Size(60, 13);
            this.lblLoopTime1.TabIndex = 28;
            this.lblLoopTime1.Text = "Loop Time:";
            // 
            // lblFrameCount1
            // 
            this.lblFrameCount1.AutoSize = true;
            this.lblFrameCount1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblFrameCount1.Location = new System.Drawing.Point(11, 101);
            this.lblFrameCount1.Name = "lblFrameCount1";
            this.lblFrameCount1.Size = new System.Drawing.Size(70, 13);
            this.lblFrameCount1.TabIndex = 26;
            this.lblFrameCount1.Text = "Frame Count:";
            // 
            // lblLoopCount1
            // 
            this.lblLoopCount1.AutoSize = true;
            this.lblLoopCount1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblLoopCount1.Location = new System.Drawing.Point(11, 63);
            this.lblLoopCount1.Name = "lblLoopCount1";
            this.lblLoopCount1.Size = new System.Drawing.Size(65, 13);
            this.lblLoopCount1.TabIndex = 24;
            this.lblLoopCount1.Text = "Loop Count:";
            // 
            // lblSprite1
            // 
            this.lblSprite1.AutoSize = true;
            this.lblSprite1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblSprite1.Location = new System.Drawing.Point(10, 26);
            this.lblSprite1.Name = "lblSprite1";
            this.lblSprite1.Size = new System.Drawing.Size(37, 13);
            this.lblSprite1.TabIndex = 22;
            this.lblSprite1.Text = "Sprite:";
            // 
            // picSprite1
            // 
            this.picSprite1.BackColor = System.Drawing.Color.Black;
            this.picSprite1.Location = new System.Drawing.Point(213, 8);
            this.picSprite1.Name = "picSprite1";
            this.picSprite1.Size = new System.Drawing.Size(205, 165);
            this.picSprite1.TabIndex = 21;
            this.picSprite1.TabStop = false;
            // 
            // DarkGroupBox3
            // 
            this.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox3.Controls.Add(this.nudLoopTime0);
            this.DarkGroupBox3.Controls.Add(this.nudFrameCount0);
            this.DarkGroupBox3.Controls.Add(this.nudLoopCount0);
            this.DarkGroupBox3.Controls.Add(this.nudSprite0);
            this.DarkGroupBox3.Controls.Add(this.lblLoopTime0);
            this.DarkGroupBox3.Controls.Add(this.lblFrameCount0);
            this.DarkGroupBox3.Controls.Add(this.lblLoopCount0);
            this.DarkGroupBox3.Controls.Add(this.lblSprite0);
            this.DarkGroupBox3.Controls.Add(this.picSprite0);
            this.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox3.Location = new System.Drawing.Point(6, 92);
            this.DarkGroupBox3.Name = "DarkGroupBox3";
            this.DarkGroupBox3.Size = new System.Drawing.Size(426, 180);
            this.DarkGroupBox3.TabIndex = 22;
            this.DarkGroupBox3.TabStop = false;
            this.DarkGroupBox3.Text = "Layer 0 - Beneath Player";
            // 
            // nudLoopTime0
            // 
            this.nudLoopTime0.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudLoopTime0.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLoopTime0.Location = new System.Drawing.Point(87, 138);
            this.nudLoopTime0.Name = "nudLoopTime0";
            this.nudLoopTime0.Size = new System.Drawing.Size(120, 20);
            this.nudLoopTime0.TabIndex = 33;
            // 
            // nudFrameCount0
            // 
            this.nudFrameCount0.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudFrameCount0.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudFrameCount0.Location = new System.Drawing.Point(87, 99);
            this.nudFrameCount0.Name = "nudFrameCount0";
            this.nudFrameCount0.Size = new System.Drawing.Size(120, 20);
            this.nudFrameCount0.TabIndex = 32;
            // 
            // nudLoopCount0
            // 
            this.nudLoopCount0.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudLoopCount0.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLoopCount0.Location = new System.Drawing.Point(87, 61);
            this.nudLoopCount0.Name = "nudLoopCount0";
            this.nudLoopCount0.Size = new System.Drawing.Size(120, 20);
            this.nudLoopCount0.TabIndex = 31;
            // 
            // nudSprite0
            // 
            this.nudSprite0.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudSprite0.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSprite0.Location = new System.Drawing.Point(87, 24);
            this.nudSprite0.Name = "nudSprite0";
            this.nudSprite0.Size = new System.Drawing.Size(120, 20);
            this.nudSprite0.TabIndex = 30;
            // 
            // lblLoopTime0
            // 
            this.lblLoopTime0.AutoSize = true;
            this.lblLoopTime0.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblLoopTime0.Location = new System.Drawing.Point(10, 140);
            this.lblLoopTime0.Name = "lblLoopTime0";
            this.lblLoopTime0.Size = new System.Drawing.Size(60, 13);
            this.lblLoopTime0.TabIndex = 28;
            this.lblLoopTime0.Text = "Loop Time:";
            // 
            // lblFrameCount0
            // 
            this.lblFrameCount0.AutoSize = true;
            this.lblFrameCount0.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblFrameCount0.Location = new System.Drawing.Point(11, 101);
            this.lblFrameCount0.Name = "lblFrameCount0";
            this.lblFrameCount0.Size = new System.Drawing.Size(70, 13);
            this.lblFrameCount0.TabIndex = 26;
            this.lblFrameCount0.Text = "Frame Count:";
            // 
            // lblLoopCount0
            // 
            this.lblLoopCount0.AutoSize = true;
            this.lblLoopCount0.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblLoopCount0.Location = new System.Drawing.Point(11, 63);
            this.lblLoopCount0.Name = "lblLoopCount0";
            this.lblLoopCount0.Size = new System.Drawing.Size(65, 13);
            this.lblLoopCount0.TabIndex = 24;
            this.lblLoopCount0.Text = "Loop Count:";
            // 
            // lblSprite0
            // 
            this.lblSprite0.AutoSize = true;
            this.lblSprite0.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblSprite0.Location = new System.Drawing.Point(10, 26);
            this.lblSprite0.Name = "lblSprite0";
            this.lblSprite0.Size = new System.Drawing.Size(37, 13);
            this.lblSprite0.TabIndex = 22;
            this.lblSprite0.Text = "Sprite:";
            // 
            // picSprite0
            // 
            this.picSprite0.BackColor = System.Drawing.Color.Black;
            this.picSprite0.Location = new System.Drawing.Point(213, 9);
            this.picSprite0.Name = "picSprite0";
            this.picSprite0.Size = new System.Drawing.Size(205, 165);
            this.picSprite0.TabIndex = 21;
            this.picSprite0.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.txtName.Location = new System.Drawing.Point(117, 28);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(315, 20);
            this.txtName.TabIndex = 1;
            // 
            // DarkLabel1
            // 
            this.DarkLabel1.AutoSize = true;
            this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel1.Location = new System.Drawing.Point(16, 30);
            this.DarkLabel1.Name = "DarkLabel1";
            this.DarkLabel1.Size = new System.Drawing.Size(87, 13);
            this.DarkLabel1.TabIndex = 0;
            this.DarkLabel1.Text = "Animation Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(470, 473);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(2, 473);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(5);
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(571, 473);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            // 
            // FrmEditor_Animation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.ClientSize = new System.Drawing.Size(650, 508);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.DarkGroupBox2);
            this.Controls.Add(this.DarkGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEditor_Animation";
            this.Text = "Animation Editor";
            this.DarkGroupBox1.ResumeLayout(false);
            this.DarkGroupBox2.ResumeLayout(false);
            this.DarkGroupBox2.PerformLayout();
            this.DarkGroupBox4.ResumeLayout(false);
            this.DarkGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudLoopTime1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudFrameCount1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudLoopCount1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSprite1).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.picSprite1).EndInit();
            this.DarkGroupBox3.ResumeLayout(false);
            this.DarkGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudLoopTime0).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudFrameCount0).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudLoopCount0).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSprite0).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.picSprite0).EndInit();
            this.ResumeLayout(false);
        }

        public DarkUI.Controls.DarkGroupBox DarkGroupBox1;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox2;

        public ListBox lstIndex;

        public DarkUI.Controls.DarkTextBox txtName;

        public DarkUI.Controls.DarkLabel DarkLabel1;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox3;

        public PictureBox picSprite0;

        public DarkUI.Controls.DarkLabel lblLoopCount0;

        public DarkUI.Controls.DarkLabel lblSprite0;

        public DarkUI.Controls.DarkLabel lblLoopTime0;

        public DarkUI.Controls.DarkLabel lblFrameCount0;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox4;

        public DarkUI.Controls.DarkLabel lblLoopTime1;

        public DarkUI.Controls.DarkLabel lblFrameCount1;

        public DarkUI.Controls.DarkLabel lblLoopCount1;

        public DarkUI.Controls.DarkLabel lblSprite1;

        public PictureBox picSprite1;

        public DarkUI.Controls.DarkButton btnSave;

        public DarkUI.Controls.DarkButton btnDelete;

        public DarkUI.Controls.DarkButton btnCancel;

        public DarkUI.Controls.DarkNumericUpDown nudLoopTime0;

        public DarkUI.Controls.DarkNumericUpDown nudFrameCount0;

        public DarkUI.Controls.DarkNumericUpDown nudLoopCount0;

        public DarkUI.Controls.DarkNumericUpDown nudSprite0;

        public DarkUI.Controls.DarkNumericUpDown nudLoopTime1;

        public DarkUI.Controls.DarkNumericUpDown nudFrameCount1;

        public DarkUI.Controls.DarkNumericUpDown nudLoopCount1;

        public DarkUI.Controls.DarkNumericUpDown nudSprite1;

        public DarkUI.Controls.DarkComboBox cmbSound;

        public DarkUI.Controls.DarkLabel DarkLabel2;
        
    }
}
