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
    [global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
    partial class frmPet : System.Windows.Forms.Form
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPet));
            this.DarkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.lstIndex = new System.Windows.Forms.ListBox();
            this.DarkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.DarkGroupBox6 = new DarkUI.Controls.DarkGroupBox();
            this.cmbSkill4 = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel19 = new DarkUI.Controls.DarkLabel();
            this.cmbSkill3 = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel18 = new DarkUI.Controls.DarkLabel();
            this.cmbSkill2 = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel17 = new DarkUI.Controls.DarkLabel();
            this.cmbSkill1 = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel16 = new DarkUI.Controls.DarkLabel();
            this.DarkGroupBox4 = new DarkUI.Controls.DarkGroupBox();
            this.pnlPetlevel = new System.Windows.Forms.Panel();
            this.DarkGroupBox5 = new DarkUI.Controls.DarkGroupBox();
            this.cmbEvolve = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel15 = new DarkUI.Controls.DarkLabel();
            this.nudEvolveLvl = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel14 = new DarkUI.Controls.DarkLabel();
            this.chkEvolve = new DarkUI.Controls.DarkCheckBox();
            this.nudMaxLevel = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel12 = new DarkUI.Controls.DarkLabel();
            this.nudPetPnts = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel13 = new DarkUI.Controls.DarkLabel();
            this.nudPetExp = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel11 = new DarkUI.Controls.DarkLabel();
            this.optDoNotLevel = new DarkUI.Controls.DarkRadioButton();
            this.optLevel = new DarkUI.Controls.DarkRadioButton();
            this.DarkGroupBox3 = new DarkUI.Controls.DarkGroupBox();
            this.pnlCustomStats = new System.Windows.Forms.Panel();
            this.nudLevel = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel10 = new DarkUI.Controls.DarkLabel();
            this.nudSpirit = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel7 = new DarkUI.Controls.DarkLabel();
            this.nudIntelligence = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel8 = new DarkUI.Controls.DarkLabel();
            this.nudLuck = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel9 = new DarkUI.Controls.DarkLabel();
            this.nudVitality = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel6 = new DarkUI.Controls.DarkLabel();
            this.nudEndurance = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel5 = new DarkUI.Controls.DarkLabel();
            this.nudStrength = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel4 = new DarkUI.Controls.DarkLabel();
            this.optAdoptStats = new DarkUI.Controls.DarkRadioButton();
            this.optCustomStats = new DarkUI.Controls.DarkRadioButton();
            this.DarkLabel3 = new DarkUI.Controls.DarkLabel();
            this.nudRange = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel2 = new DarkUI.Controls.DarkLabel();
            this.nudSprite = new DarkUI.Controls.DarkNumericUpDown();
            this.picSprite = new System.Windows.Forms.PictureBox();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel1 = new DarkUI.Controls.DarkLabel();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.DarkGroupBox1.SuspendLayout();
            this.DarkGroupBox2.SuspendLayout();
            this.DarkGroupBox6.SuspendLayout();
            this.DarkGroupBox4.SuspendLayout();
            this.pnlPetlevel.SuspendLayout();
            this.DarkGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudEvolveLvl).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudMaxLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudPetPnts).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudPetExp).BeginInit();
            this.DarkGroupBox3.SuspendLayout();
            this.pnlCustomStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudLevel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSpirit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudIntelligence).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudLuck).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudVitality).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudEndurance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudStrength).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudRange).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSprite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.picSprite).BeginInit();
            this.SuspendLayout();
            // 
            // DarkGroupBox1
            // 
            this.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox1.Controls.Add(this.lstIndex);
            this.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox1.Location = new System.Drawing.Point(1, 3);
            this.DarkGroupBox1.Name = "DarkGroupBox1";
            this.DarkGroupBox1.Size = new System.Drawing.Size(209, 443);
            this.DarkGroupBox1.TabIndex = 0;
            this.DarkGroupBox1.TabStop = false;
            this.DarkGroupBox1.Text = "Pet List";
            // 
            // lstIndex
            // 
            this.lstIndex.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstIndex.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstIndex.FormattingEnabled = true;
            this.lstIndex.Location = new System.Drawing.Point(6, 14);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(198, 418);
            this.lstIndex.TabIndex = 1;
            // 
            // DarkGroupBox2
            // 
            this.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox6);
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox4);
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox3);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel3);
            this.DarkGroupBox2.Controls.Add(this.nudRange);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel2);
            this.DarkGroupBox2.Controls.Add(this.nudSprite);
            this.DarkGroupBox2.Controls.Add(this.picSprite);
            this.DarkGroupBox2.Controls.Add(this.txtName);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel1);
            this.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox2.Location = new System.Drawing.Point(216, 3);
            this.DarkGroupBox2.Name = "DarkGroupBox2";
            this.DarkGroupBox2.Size = new System.Drawing.Size(410, 472);
            this.DarkGroupBox2.TabIndex = 1;
            this.DarkGroupBox2.TabStop = false;
            this.DarkGroupBox2.Text = "Pet Properties";
            // 
            // DarkGroupBox6
            // 
            this.DarkGroupBox6.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox6.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox6.Controls.Add(this.cmbSkill4);
            this.DarkGroupBox6.Controls.Add(this.DarkLabel19);
            this.DarkGroupBox6.Controls.Add(this.cmbSkill3);
            this.DarkGroupBox6.Controls.Add(this.DarkLabel18);
            this.DarkGroupBox6.Controls.Add(this.cmbSkill2);
            this.DarkGroupBox6.Controls.Add(this.DarkLabel17);
            this.DarkGroupBox6.Controls.Add(this.cmbSkill1);
            this.DarkGroupBox6.Controls.Add(this.DarkLabel16);
            this.DarkGroupBox6.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox6.Location = new System.Drawing.Point(6, 390);
            this.DarkGroupBox6.Name = "DarkGroupBox6";
            this.DarkGroupBox6.Size = new System.Drawing.Size(398, 76);
            this.DarkGroupBox6.TabIndex = 10;
            this.DarkGroupBox6.TabStop = false;
            this.DarkGroupBox6.Text = "Start Skills";
            // 
            // cmbSkill4
            // 
            this.cmbSkill4.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbSkill4.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbSkill4.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSkill4.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbSkill4.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbSkill4.ButtonIcon");
            this.cmbSkill4.DrawDropdownHoverOutline = false;
            this.cmbSkill4.DrawFocusRectangle = false;
            this.cmbSkill4.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSkill4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkill4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSkill4.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSkill4.FormattingEnabled = true;
            this.cmbSkill4.Location = new System.Drawing.Point(249, 46);
            this.cmbSkill4.Name = "cmbSkill4";
            this.cmbSkill4.Size = new System.Drawing.Size(138, 21);
            this.cmbSkill4.TabIndex = 7;
            this.cmbSkill4.Text = null;
            this.cmbSkill4.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel19
            // 
            this.DarkLabel19.AutoSize = true;
            this.DarkLabel19.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel19.Location = new System.Drawing.Point(205, 49);
            this.DarkLabel19.Name = "DarkLabel19";
            this.DarkLabel19.Size = new System.Drawing.Size(38, 13);
            this.DarkLabel19.TabIndex = 6;
            this.DarkLabel19.Text = "Skill 4:";
            // 
            // cmbSkill3
            // 
            this.cmbSkill3.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbSkill3.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbSkill3.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSkill3.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbSkill3.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbSkill3.ButtonIcon");
            this.cmbSkill3.DrawDropdownHoverOutline = false;
            this.cmbSkill3.DrawFocusRectangle = false;
            this.cmbSkill3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSkill3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkill3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSkill3.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSkill3.FormattingEnabled = true;
            this.cmbSkill3.Location = new System.Drawing.Point(48, 46);
            this.cmbSkill3.Name = "cmbSkill3";
            this.cmbSkill3.Size = new System.Drawing.Size(138, 21);
            this.cmbSkill3.TabIndex = 5;
            this.cmbSkill3.Text = null;
            this.cmbSkill3.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel18
            // 
            this.DarkLabel18.AutoSize = true;
            this.DarkLabel18.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel18.Location = new System.Drawing.Point(4, 49);
            this.DarkLabel18.Name = "DarkLabel18";
            this.DarkLabel18.Size = new System.Drawing.Size(38, 13);
            this.DarkLabel18.TabIndex = 4;
            this.DarkLabel18.Text = "Skill 3:";
            // 
            // cmbSkill2
            // 
            this.cmbSkill2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbSkill2.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbSkill2.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSkill2.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbSkill2.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbSkill2.ButtonIcon");
            this.cmbSkill2.DrawDropdownHoverOutline = false;
            this.cmbSkill2.DrawFocusRectangle = false;
            this.cmbSkill2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSkill2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkill2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSkill2.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSkill2.FormattingEnabled = true;
            this.cmbSkill2.Location = new System.Drawing.Point(249, 19);
            this.cmbSkill2.Name = "cmbSkill2";
            this.cmbSkill2.Size = new System.Drawing.Size(138, 21);
            this.cmbSkill2.TabIndex = 3;
            this.cmbSkill2.Text = null;
            this.cmbSkill2.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel17
            // 
            this.DarkLabel17.AutoSize = true;
            this.DarkLabel17.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel17.Location = new System.Drawing.Point(205, 22);
            this.DarkLabel17.Name = "DarkLabel17";
            this.DarkLabel17.Size = new System.Drawing.Size(38, 13);
            this.DarkLabel17.TabIndex = 2;
            this.DarkLabel17.Text = "Skill 2:";
            // 
            // cmbSkill1
            // 
            this.cmbSkill1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbSkill1.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbSkill1.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbSkill1.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbSkill1.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbSkill1.ButtonIcon");
            this.cmbSkill1.DrawDropdownHoverOutline = false;
            this.cmbSkill1.DrawFocusRectangle = false;
            this.cmbSkill1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbSkill1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSkill1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbSkill1.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbSkill1.FormattingEnabled = true;
            this.cmbSkill1.Location = new System.Drawing.Point(48, 19);
            this.cmbSkill1.Name = "cmbSkill1";
            this.cmbSkill1.Size = new System.Drawing.Size(138, 21);
            this.cmbSkill1.TabIndex = 1;
            this.cmbSkill1.Text = null;
            this.cmbSkill1.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel16
            // 
            this.DarkLabel16.AutoSize = true;
            this.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel16.Location = new System.Drawing.Point(4, 22);
            this.DarkLabel16.Name = "DarkLabel16";
            this.DarkLabel16.Size = new System.Drawing.Size(38, 13);
            this.DarkLabel16.TabIndex = 0;
            this.DarkLabel16.Text = "Skill 1:";
            // 
            // DarkGroupBox4
            // 
            this.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox4.Controls.Add(this.pnlPetlevel);
            this.DarkGroupBox4.Controls.Add(this.optDoNotLevel);
            this.DarkGroupBox4.Controls.Add(this.optLevel);
            this.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox4.Location = new System.Drawing.Point(6, 218);
            this.DarkGroupBox4.Name = "DarkGroupBox4";
            this.DarkGroupBox4.Size = new System.Drawing.Size(398, 166);
            this.DarkGroupBox4.TabIndex = 9;
            this.DarkGroupBox4.TabStop = false;
            this.DarkGroupBox4.Text = "Leveling";
            // 
            // pnlPetlevel
            // 
            this.pnlPetlevel.Controls.Add(this.DarkGroupBox5);
            this.pnlPetlevel.Controls.Add(this.nudMaxLevel);
            this.pnlPetlevel.Controls.Add(this.DarkLabel12);
            this.pnlPetlevel.Controls.Add(this.nudPetPnts);
            this.pnlPetlevel.Controls.Add(this.DarkLabel13);
            this.pnlPetlevel.Controls.Add(this.nudPetExp);
            this.pnlPetlevel.Controls.Add(this.DarkLabel11);
            this.pnlPetlevel.Location = new System.Drawing.Point(6, 42);
            this.pnlPetlevel.Name = "pnlPetlevel";
            this.pnlPetlevel.Size = new System.Drawing.Size(386, 118);
            this.pnlPetlevel.TabIndex = 2;
            // 
            // DarkGroupBox5
            // 
            this.DarkGroupBox5.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox5.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox5.Controls.Add(this.cmbEvolve);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel15);
            this.DarkGroupBox5.Controls.Add(this.nudEvolveLvl);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel14);
            this.DarkGroupBox5.Controls.Add(this.chkEvolve);
            this.DarkGroupBox5.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox5.Location = new System.Drawing.Point(6, 38);
            this.DarkGroupBox5.Name = "DarkGroupBox5";
            this.DarkGroupBox5.Size = new System.Drawing.Size(373, 75);
            this.DarkGroupBox5.TabIndex = 7;
            this.DarkGroupBox5.TabStop = false;
            this.DarkGroupBox5.Text = "Evolution";
            // 
            // cmbEvolve
            // 
            this.cmbEvolve.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbEvolve.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbEvolve.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbEvolve.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbEvolve.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbEvolve.ButtonIcon");
            this.cmbEvolve.DrawDropdownHoverOutline = false;
            this.cmbEvolve.DrawFocusRectangle = false;
            this.cmbEvolve.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEvolve.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEvolve.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEvolve.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbEvolve.FormattingEnabled = true;
            this.cmbEvolve.Location = new System.Drawing.Point(100, 45);
            this.cmbEvolve.Name = "cmbEvolve";
            this.cmbEvolve.Size = new System.Drawing.Size(267, 21);
            this.cmbEvolve.TabIndex = 4;
            this.cmbEvolve.Text = null;
            this.cmbEvolve.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel15
            // 
            this.DarkLabel15.AutoSize = true;
            this.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel15.Location = new System.Drawing.Point(6, 48);
            this.DarkLabel15.Name = "DarkLabel15";
            this.DarkLabel15.Size = new System.Drawing.Size(74, 13);
            this.DarkLabel15.TabIndex = 3;
            this.DarkLabel15.Text = "Evolves intoo:";
            // 
            // nudEvolveLvl
            // 
            this.nudEvolveLvl.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudEvolveLvl.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudEvolveLvl.Location = new System.Drawing.Point(305, 21);
            this.nudEvolveLvl.Name = "nudEvolveLvl";
            this.nudEvolveLvl.Size = new System.Drawing.Size(62, 20);
            this.nudEvolveLvl.TabIndex = 2;
            // 
            // DarkLabel14
            // 
            this.DarkLabel14.AutoSize = true;
            this.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel14.Location = new System.Drawing.Point(207, 23);
            this.DarkLabel14.Name = "DarkLabel14";
            this.DarkLabel14.Size = new System.Drawing.Size(92, 13);
            this.DarkLabel14.TabIndex = 1;
            this.DarkLabel14.Text = "Evolves on Level:";
            // 
            // chkEvolve
            // 
            this.chkEvolve.AutoSize = true;
            this.chkEvolve.Location = new System.Drawing.Point(6, 19);
            this.chkEvolve.Name = "chkEvolve";
            this.chkEvolve.Size = new System.Drawing.Size(100, 17);
            this.chkEvolve.TabIndex = 0;
            this.chkEvolve.Text = "Pet Can Evolve";
            // 
            // nudMaxLevel
            // 
            this.nudMaxLevel.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudMaxLevel.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMaxLevel.Location = new System.Drawing.Point(325, 12);
            this.nudMaxLevel.Name = "nudMaxLevel";
            this.nudMaxLevel.Size = new System.Drawing.Size(47, 20);
            this.nudMaxLevel.TabIndex = 6;
            this.nudMaxLevel.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // DarkLabel12
            // 
            this.DarkLabel12.AutoSize = true;
            this.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel12.Location = new System.Drawing.Point(260, 14);
            this.DarkLabel12.Name = "DarkLabel12";
            this.DarkLabel12.Size = new System.Drawing.Size(59, 13);
            this.DarkLabel12.TabIndex = 5;
            this.DarkLabel12.Text = "Max Level:";
            // 
            // nudPetPnts
            // 
            this.nudPetPnts.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudPetPnts.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudPetPnts.Location = new System.Drawing.Point(217, 12);
            this.nudPetPnts.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudPetPnts.Name = "nudPetPnts";
            this.nudPetPnts.Size = new System.Drawing.Size(36, 20);
            this.nudPetPnts.TabIndex = 4;
            this.nudPetPnts.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // DarkLabel13
            // 
            this.DarkLabel13.AutoSize = true;
            this.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel13.Location = new System.Drawing.Point(127, 14);
            this.DarkLabel13.Name = "DarkLabel13";
            this.DarkLabel13.Size = new System.Drawing.Size(87, 13);
            this.DarkLabel13.TabIndex = 3;
            this.DarkLabel13.Text = "Points Per Level:";
            // 
            // nudPetExp
            // 
            this.nudPetExp.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudPetExp.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudPetExp.Location = new System.Drawing.Point(74, 12);
            this.nudPetExp.Name = "nudPetExp";
            this.nudPetExp.Size = new System.Drawing.Size(47, 20);
            this.nudPetExp.TabIndex = 1;
            this.nudPetExp.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // DarkLabel11
            // 
            this.DarkLabel11.AutoSize = true;
            this.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel11.Location = new System.Drawing.Point(4, 14);
            this.DarkLabel11.Name = "DarkLabel11";
            this.DarkLabel11.Size = new System.Drawing.Size(64, 13);
            this.DarkLabel11.TabIndex = 0;
            this.DarkLabel11.Text = "Exp Gain %:";
            // 
            // optDoNotLevel
            // 
            this.optDoNotLevel.AutoSize = true;
            this.optDoNotLevel.Location = new System.Drawing.Point(264, 19);
            this.optDoNotLevel.Name = "optDoNotLevel";
            this.optDoNotLevel.Size = new System.Drawing.Size(113, 17);
            this.optDoNotLevel.TabIndex = 1;
            this.optDoNotLevel.Text = "Does Not LevelUp";
            // 
            // optLevel
            // 
            this.optLevel.AutoSize = true;
            this.optLevel.Location = new System.Drawing.Point(6, 19);
            this.optLevel.Name = "optLevel";
            this.optLevel.Size = new System.Drawing.Size(121, 17);
            this.optLevel.TabIndex = 0;
            this.optLevel.Text = "Level by Experience";
            // 
            // DarkGroupBox3
            // 
            this.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox3.Controls.Add(this.pnlCustomStats);
            this.DarkGroupBox3.Controls.Add(this.optAdoptStats);
            this.DarkGroupBox3.Controls.Add(this.optCustomStats);
            this.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox3.Location = new System.Drawing.Point(6, 77);
            this.DarkGroupBox3.Name = "DarkGroupBox3";
            this.DarkGroupBox3.Size = new System.Drawing.Size(396, 135);
            this.DarkGroupBox3.TabIndex = 8;
            this.DarkGroupBox3.TabStop = false;
            this.DarkGroupBox3.Text = "Starting Stats";
            // 
            // pnlCustomStats
            // 
            this.pnlCustomStats.Controls.Add(this.nudLevel);
            this.pnlCustomStats.Controls.Add(this.DarkLabel10);
            this.pnlCustomStats.Controls.Add(this.nudSpirit);
            this.pnlCustomStats.Controls.Add(this.DarkLabel7);
            this.pnlCustomStats.Controls.Add(this.nudIntelligence);
            this.pnlCustomStats.Controls.Add(this.DarkLabel8);
            this.pnlCustomStats.Controls.Add(this.nudLuck);
            this.pnlCustomStats.Controls.Add(this.DarkLabel9);
            this.pnlCustomStats.Controls.Add(this.nudVitality);
            this.pnlCustomStats.Controls.Add(this.DarkLabel6);
            this.pnlCustomStats.Controls.Add(this.nudEndurance);
            this.pnlCustomStats.Controls.Add(this.DarkLabel5);
            this.pnlCustomStats.Controls.Add(this.nudStrength);
            this.pnlCustomStats.Controls.Add(this.DarkLabel4);
            this.pnlCustomStats.Location = new System.Drawing.Point(6, 42);
            this.pnlCustomStats.Name = "pnlCustomStats";
            this.pnlCustomStats.Size = new System.Drawing.Size(384, 88);
            this.pnlCustomStats.TabIndex = 2;
            // 
            // nudLevel
            // 
            this.nudLevel.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudLevel.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLevel.Location = new System.Drawing.Point(59, 60);
            this.nudLevel.Name = "nudLevel";
            this.nudLevel.Size = new System.Drawing.Size(54, 20);
            this.nudLevel.TabIndex = 13;
            // 
            // DarkLabel10
            // 
            this.DarkLabel10.AutoSize = true;
            this.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel10.Location = new System.Drawing.Point(4, 62);
            this.DarkLabel10.Name = "DarkLabel10";
            this.DarkLabel10.Size = new System.Drawing.Size(36, 13);
            this.DarkLabel10.TabIndex = 12;
            this.DarkLabel10.Text = "Level:";
            // 
            // nudSpirit
            // 
            this.nudSpirit.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudSpirit.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpirit.Location = new System.Drawing.Point(325, 34);
            this.nudSpirit.Name = "nudSpirit";
            this.nudSpirit.Size = new System.Drawing.Size(54, 20);
            this.nudSpirit.TabIndex = 11;
            // 
            // DarkLabel7
            // 
            this.DarkLabel7.AutoSize = true;
            this.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel7.Location = new System.Drawing.Point(270, 36);
            this.DarkLabel7.Name = "DarkLabel7";
            this.DarkLabel7.Size = new System.Drawing.Size(33, 13);
            this.DarkLabel7.TabIndex = 10;
            this.DarkLabel7.Text = "Spirit:";
            // 
            // nudIntelligence
            // 
            this.nudIntelligence.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudIntelligence.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudIntelligence.Location = new System.Drawing.Point(199, 34);
            this.nudIntelligence.Name = "nudIntelligence";
            this.nudIntelligence.Size = new System.Drawing.Size(54, 20);
            this.nudIntelligence.TabIndex = 9;
            // 
            // DarkLabel8
            // 
            this.DarkLabel8.AutoSize = true;
            this.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel8.Location = new System.Drawing.Point(132, 36);
            this.DarkLabel8.Name = "DarkLabel8";
            this.DarkLabel8.Size = new System.Drawing.Size(64, 13);
            this.DarkLabel8.TabIndex = 8;
            this.DarkLabel8.Text = "Intelligence:";
            // 
            // nudLuck
            // 
            this.nudLuck.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudLuck.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLuck.Location = new System.Drawing.Point(59, 34);
            this.nudLuck.Name = "nudLuck";
            this.nudLuck.Size = new System.Drawing.Size(54, 20);
            this.nudLuck.TabIndex = 7;
            // 
            // DarkLabel9
            // 
            this.DarkLabel9.AutoSize = true;
            this.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel9.Location = new System.Drawing.Point(4, 36);
            this.DarkLabel9.Name = "DarkLabel9";
            this.DarkLabel9.Size = new System.Drawing.Size(34, 13);
            this.DarkLabel9.TabIndex = 6;
            this.DarkLabel9.Text = "Luck:";
            // 
            // nudVitality
            // 
            this.nudVitality.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudVitality.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudVitality.Location = new System.Drawing.Point(325, 8);
            this.nudVitality.Name = "nudVitality";
            this.nudVitality.Size = new System.Drawing.Size(54, 20);
            this.nudVitality.TabIndex = 5;
            // 
            // DarkLabel6
            // 
            this.DarkLabel6.AutoSize = true;
            this.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel6.Location = new System.Drawing.Point(269, 10);
            this.DarkLabel6.Name = "DarkLabel6";
            this.DarkLabel6.Size = new System.Drawing.Size(40, 13);
            this.DarkLabel6.TabIndex = 4;
            this.DarkLabel6.Text = "Vitality:";
            // 
            // nudEndurance
            // 
            this.nudEndurance.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudEndurance.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudEndurance.Location = new System.Drawing.Point(199, 8);
            this.nudEndurance.Name = "nudEndurance";
            this.nudEndurance.Size = new System.Drawing.Size(54, 20);
            this.nudEndurance.TabIndex = 3;
            // 
            // DarkLabel5
            // 
            this.DarkLabel5.AutoSize = true;
            this.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel5.Location = new System.Drawing.Point(131, 10);
            this.DarkLabel5.Name = "DarkLabel5";
            this.DarkLabel5.Size = new System.Drawing.Size(62, 13);
            this.DarkLabel5.TabIndex = 2;
            this.DarkLabel5.Text = "Endurance:";
            // 
            // nudStrength
            // 
            this.nudStrength.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudStrength.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudStrength.Location = new System.Drawing.Point(59, 8);
            this.nudStrength.Name = "nudStrength";
            this.nudStrength.Size = new System.Drawing.Size(54, 20);
            this.nudStrength.TabIndex = 1;
            // 
            // DarkLabel4
            // 
            this.DarkLabel4.AutoSize = true;
            this.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel4.Location = new System.Drawing.Point(3, 10);
            this.DarkLabel4.Name = "DarkLabel4";
            this.DarkLabel4.Size = new System.Drawing.Size(50, 13);
            this.DarkLabel4.TabIndex = 0;
            this.DarkLabel4.Text = "Strength:";
            // 
            // optAdoptStats
            // 
            this.optAdoptStats.AutoSize = true;
            this.optAdoptStats.Location = new System.Drawing.Point(269, 19);
            this.optAdoptStats.Name = "optAdoptStats";
            this.optAdoptStats.Size = new System.Drawing.Size(121, 17);
            this.optAdoptStats.TabIndex = 1;
            this.optAdoptStats.TabStop = true;
            this.optAdoptStats.Text = "Adopt Owner's Stats";
            // 
            // optCustomStats
            // 
            this.optCustomStats.AutoSize = true;
            this.optCustomStats.Location = new System.Drawing.Point(6, 19);
            this.optCustomStats.Name = "optCustomStats";
            this.optCustomStats.Size = new System.Drawing.Size(87, 17);
            this.optCustomStats.TabIndex = 0;
            this.optCustomStats.TabStop = true;
            this.optCustomStats.Text = "Custom Stats";
            // 
            // DarkLabel3
            // 
            this.DarkLabel3.AutoSize = true;
            this.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel3.Location = new System.Drawing.Point(209, 53);
            this.DarkLabel3.Name = "DarkLabel3";
            this.DarkLabel3.Size = new System.Drawing.Size(42, 13);
            this.DarkLabel3.TabIndex = 7;
            this.DarkLabel3.Text = "Range:";
            // 
            // nudRange
            // 
            this.nudRange.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudRange.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudRange.Location = new System.Drawing.Point(272, 51);
            this.nudRange.Name = "nudRange";
            this.nudRange.Size = new System.Drawing.Size(76, 20);
            this.nudRange.TabIndex = 6;
            // 
            // DarkLabel2
            // 
            this.DarkLabel2.AutoSize = true;
            this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel2.Location = new System.Drawing.Point(6, 53);
            this.DarkLabel2.Name = "DarkLabel2";
            this.DarkLabel2.Size = new System.Drawing.Size(37, 13);
            this.DarkLabel2.TabIndex = 5;
            this.DarkLabel2.Text = "Sprite:";
            // 
            // nudSprite
            // 
            this.nudSprite.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudSprite.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSprite.Location = new System.Drawing.Point(69, 51);
            this.nudSprite.Name = "nudSprite";
            this.nudSprite.Size = new System.Drawing.Size(76, 20);
            this.nudSprite.TabIndex = 4;
            // 
            // picSprite
            // 
            this.picSprite.BackColor = System.Drawing.Color.Black;
            this.picSprite.Location = new System.Drawing.Point(354, 23);
            this.picSprite.Name = "picSprite";
            this.picSprite.Size = new System.Drawing.Size(48, 48);
            this.picSprite.TabIndex = 3;
            this.picSprite.TabStop = false;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.txtName.Location = new System.Drawing.Point(69, 23);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(279, 20);
            this.txtName.TabIndex = 1;
            // 
            // DarkLabel1
            // 
            this.DarkLabel1.AutoSize = true;
            this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel1.Location = new System.Drawing.Point(6, 25);
            this.DarkLabel1.Name = "DarkLabel1";
            this.DarkLabel1.Size = new System.Drawing.Size(57, 13);
            this.DarkLabel1.TabIndex = 0;
            this.DarkLabel1.Text = "Pet Name:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(7, 452);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(130, 452);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            // 
            // FrmEditor_Pet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.ClientSize = new System.Drawing.Size(632, 482);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.DarkGroupBox2);
            this.Controls.Add(this.DarkGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmEditor_Pet";
            this.Text = "frmEditor_Pet_Dark";
            this.DarkGroupBox1.ResumeLayout(false);
            this.DarkGroupBox2.ResumeLayout(false);
            this.DarkGroupBox2.PerformLayout();
            this.DarkGroupBox6.ResumeLayout(false);
            this.DarkGroupBox6.PerformLayout();
            this.DarkGroupBox4.ResumeLayout(false);
            this.DarkGroupBox4.PerformLayout();
            this.pnlPetlevel.ResumeLayout(false);
            this.pnlPetlevel.PerformLayout();
            this.DarkGroupBox5.ResumeLayout(false);
            this.DarkGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudEvolveLvl).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudMaxLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudPetPnts).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudPetExp).EndInit();
            this.DarkGroupBox3.ResumeLayout(false);
            this.DarkGroupBox3.PerformLayout();
            this.pnlCustomStats.ResumeLayout(false);
            this.pnlCustomStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudLevel).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSpirit).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudIntelligence).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudLuck).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudVitality).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudEndurance).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudStrength).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudRange).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSprite).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.picSprite).EndInit();
            this.ResumeLayout(false);
        }

        public DarkUI.Controls.DarkGroupBox DarkGroupBox1;

        public ListBox lstIndex;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox2;

        public DarkUI.Controls.DarkTextBox txtName;

        public DarkUI.Controls.DarkLabel DarkLabel1;

        public PictureBox picSprite;

        public DarkUI.Controls.DarkLabel DarkLabel2;

        public DarkUI.Controls.DarkNumericUpDown nudSprite;

        public DarkUI.Controls.DarkLabel DarkLabel3;

        public DarkUI.Controls.DarkNumericUpDown nudRange;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox3;

        public DarkUI.Controls.DarkRadioButton optCustomStats;

        public DarkUI.Controls.DarkRadioButton optAdoptStats;

        public Panel pnlCustomStats;

        public DarkUI.Controls.DarkNumericUpDown nudVitality;

        public DarkUI.Controls.DarkLabel DarkLabel6;

        public DarkUI.Controls.DarkNumericUpDown nudEndurance;

        public DarkUI.Controls.DarkLabel DarkLabel5;

        public DarkUI.Controls.DarkNumericUpDown nudStrength;

        public DarkUI.Controls.DarkLabel DarkLabel4;

        public DarkUI.Controls.DarkNumericUpDown nudSpirit;

        public DarkUI.Controls.DarkLabel DarkLabel7;

        public DarkUI.Controls.DarkNumericUpDown nudIntelligence;

        public DarkUI.Controls.DarkLabel DarkLabel8;

        public DarkUI.Controls.DarkNumericUpDown nudLuck;

        public DarkUI.Controls.DarkLabel DarkLabel9;

        public DarkUI.Controls.DarkNumericUpDown nudLevel;

        public DarkUI.Controls.DarkLabel DarkLabel10;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox4;

        public DarkUI.Controls.DarkRadioButton optLevel;

        public DarkUI.Controls.DarkRadioButton optDoNotLevel;

        public Panel pnlPetlevel;

        public DarkUI.Controls.DarkNumericUpDown nudPetExp;

        public DarkUI.Controls.DarkLabel DarkLabel11;

        public DarkUI.Controls.DarkLabel DarkLabel13;

        public DarkUI.Controls.DarkNumericUpDown nudMaxLevel;

        public DarkUI.Controls.DarkLabel DarkLabel12;

        public DarkUI.Controls.DarkNumericUpDown nudPetPnts;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox5;

        public DarkUI.Controls.DarkCheckBox chkEvolve;

        public DarkUI.Controls.DarkLabel DarkLabel14;

        public DarkUI.Controls.DarkNumericUpDown nudEvolveLvl;

        public DarkUI.Controls.DarkLabel DarkLabel15;

        public DarkUI.Controls.DarkComboBox cmbEvolve;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox6;

        public DarkUI.Controls.DarkComboBox cmbSkill4;

        public DarkUI.Controls.DarkLabel DarkLabel19;

        public DarkUI.Controls.DarkComboBox cmbSkill3;

        public DarkUI.Controls.DarkLabel DarkLabel18;

        public DarkUI.Controls.DarkComboBox cmbSkill2;

        public DarkUI.Controls.DarkLabel DarkLabel17;

        public DarkUI.Controls.DarkComboBox cmbSkill1;

        public DarkUI.Controls.DarkLabel DarkLabel16;

        public DarkUI.Controls.DarkButton btnSave;

        public DarkUI.Controls.DarkButton btnCancel;
    }
}
