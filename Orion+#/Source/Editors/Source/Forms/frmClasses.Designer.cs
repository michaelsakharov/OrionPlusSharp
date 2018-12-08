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
    partial class frmClasses : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClasses));
            this.DarkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.lstIndex = new System.Windows.Forms.ListBox();
            this.DarkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.DarkGroupBox7 = new DarkUI.Controls.DarkGroupBox();
            this.nudStartY = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel15 = new DarkUI.Controls.DarkLabel();
            this.nudStartX = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel14 = new DarkUI.Controls.DarkLabel();
            this.nudStartMap = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel13 = new DarkUI.Controls.DarkLabel();
            this.DarkGroupBox6 = new DarkUI.Controls.DarkGroupBox();
            this.btnItemAdd = new DarkUI.Controls.DarkButton();
            this.nudItemAmount = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel12 = new DarkUI.Controls.DarkLabel();
            this.cmbItems = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel11 = new DarkUI.Controls.DarkLabel();
            this.lstStartItems = new System.Windows.Forms.ListBox();
            this.DarkGroupBox5 = new DarkUI.Controls.DarkGroupBox();
            this.nudBaseExp = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel10 = new DarkUI.Controls.DarkLabel();
            this.nudSpirit = new DarkUI.Controls.DarkNumericUpDown();
            this.nudEndurance = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel8 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel9 = new DarkUI.Controls.DarkLabel();
            this.nudVitality = new DarkUI.Controls.DarkNumericUpDown();
            this.nudLuck = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel6 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel7 = new DarkUI.Controls.DarkLabel();
            this.nudIntelligence = new DarkUI.Controls.DarkNumericUpDown();
            this.nudStrength = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel5 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel3 = new DarkUI.Controls.DarkLabel();
            this.DarkGroupBox4 = new DarkUI.Controls.DarkGroupBox();
            this.nudFemaleSprite = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel4 = new DarkUI.Controls.DarkLabel();
            this.btnDeleteFemaleSprite = new DarkUI.Controls.DarkButton();
            this.btnAddFemaleSprite = new DarkUI.Controls.DarkButton();
            this.cmbFemaleSprite = new DarkUI.Controls.DarkComboBox();
            this.picFemale = new System.Windows.Forms.PictureBox();
            this.DarkGroupBox3 = new DarkUI.Controls.DarkGroupBox();
            this.nudMaleSprite = new DarkUI.Controls.DarkNumericUpDown();
            this.lblMaleSprite = new DarkUI.Controls.DarkLabel();
            this.btnDeleteMaleSprite = new DarkUI.Controls.DarkButton();
            this.btnAddMaleSprite = new DarkUI.Controls.DarkButton();
            this.cmbMaleSprite = new DarkUI.Controls.DarkComboBox();
            this.picMale = new System.Windows.Forms.PictureBox();
            this.txtDescription = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel2 = new DarkUI.Controls.DarkLabel();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel1 = new DarkUI.Controls.DarkLabel();
            this.btnAddClass = new DarkUI.Controls.DarkButton();
            this.btnRemoveClass = new DarkUI.Controls.DarkButton();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.DarkGroupBox1.SuspendLayout();
            this.DarkGroupBox2.SuspendLayout();
            this.DarkGroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudStartY).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudStartX).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudStartMap).BeginInit();
            this.DarkGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudItemAmount).BeginInit();
            this.DarkGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudBaseExp).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSpirit).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudEndurance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudVitality).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudLuck).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudIntelligence).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudStrength).BeginInit();
            this.DarkGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudFemaleSprite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.picFemale).BeginInit();
            this.DarkGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudMaleSprite).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.picMale).BeginInit();
            this.SuspendLayout();
            // 
            // DarkGroupBox1
            // 
            this.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox1.Controls.Add(this.lstIndex);
            this.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox1.Location = new System.Drawing.Point(2, 2);
            this.DarkGroupBox1.Name = "DarkGroupBox1";
            this.DarkGroupBox1.Size = new System.Drawing.Size(173, 311);
            this.DarkGroupBox1.TabIndex = 0;
            this.DarkGroupBox1.TabStop = false;
            this.DarkGroupBox1.Text = "Classes List";
            // 
            // lstIndex
            // 
            this.lstIndex.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstIndex.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstIndex.FormattingEnabled = true;
            this.lstIndex.Location = new System.Drawing.Point(6, 16);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(160, 288);
            this.lstIndex.TabIndex = 0;
            // 
            // DarkGroupBox2
            // 
            this.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox7);
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox6);
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox5);
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox4);
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox3);
            this.DarkGroupBox2.Controls.Add(this.txtDescription);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel2);
            this.DarkGroupBox2.Controls.Add(this.txtName);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel1);
            this.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox2.Location = new System.Drawing.Point(181, 2);
            this.DarkGroupBox2.Name = "DarkGroupBox2";
            this.DarkGroupBox2.Size = new System.Drawing.Size(341, 472);
            this.DarkGroupBox2.TabIndex = 1;
            this.DarkGroupBox2.TabStop = false;
            this.DarkGroupBox2.Text = "Settings";
            // 
            // DarkGroupBox7
            // 
            this.DarkGroupBox7.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox7.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox7.Controls.Add(this.nudStartY);
            this.DarkGroupBox7.Controls.Add(this.DarkLabel15);
            this.DarkGroupBox7.Controls.Add(this.nudStartX);
            this.DarkGroupBox7.Controls.Add(this.DarkLabel14);
            this.DarkGroupBox7.Controls.Add(this.nudStartMap);
            this.DarkGroupBox7.Controls.Add(this.DarkLabel13);
            this.DarkGroupBox7.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox7.Location = new System.Drawing.Point(6, 422);
            this.DarkGroupBox7.Name = "DarkGroupBox7";
            this.DarkGroupBox7.Size = new System.Drawing.Size(328, 43);
            this.DarkGroupBox7.TabIndex = 8;
            this.DarkGroupBox7.TabStop = false;
            this.DarkGroupBox7.Text = "Starting Point";
            // 
            // nudStartY
            // 
            this.nudStartY.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudStartY.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudStartY.Location = new System.Drawing.Point(274, 14);
            this.nudStartY.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudStartY.Name = "nudStartY";
            this.nudStartY.Size = new System.Drawing.Size(48, 20);
            this.nudStartY.TabIndex = 5;
            this.nudStartY.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DarkLabel15
            // 
            this.DarkLabel15.AutoSize = true;
            this.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel15.Location = new System.Drawing.Point(226, 16);
            this.DarkLabel15.Name = "DarkLabel15";
            this.DarkLabel15.Size = new System.Drawing.Size(35, 13);
            this.DarkLabel15.TabIndex = 4;
            this.DarkLabel15.Text = "Start :";
            // 
            // nudStartX
            // 
            this.nudStartX.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudStartX.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudStartX.Location = new System.Drawing.Point(168, 14);
            this.nudStartX.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudStartX.Name = "nudStartX";
            this.nudStartX.Size = new System.Drawing.Size(48, 20);
            this.nudStartX.TabIndex = 3;
            this.nudStartX.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DarkLabel14
            // 
            this.DarkLabel14.AutoSize = true;
            this.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel14.Location = new System.Drawing.Point(120, 16);
            this.DarkLabel14.Name = "DarkLabel14";
            this.DarkLabel14.Size = new System.Drawing.Size(42, 13);
            this.DarkLabel14.TabIndex = 2;
            this.DarkLabel14.Text = "Start X:";
            // 
            // nudStartMap
            // 
            this.nudStartMap.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudStartMap.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudStartMap.Location = new System.Drawing.Point(68, 14);
            this.nudStartMap.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudStartMap.Name = "nudStartMap";
            this.nudStartMap.Size = new System.Drawing.Size(46, 20);
            this.nudStartMap.TabIndex = 1;
            this.nudStartMap.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DarkLabel13
            // 
            this.DarkLabel13.AutoSize = true;
            this.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel13.Location = new System.Drawing.Point(6, 16);
            this.DarkLabel13.Name = "DarkLabel13";
            this.DarkLabel13.Size = new System.Drawing.Size(56, 13);
            this.DarkLabel13.TabIndex = 0;
            this.DarkLabel13.Text = "Start Map:";
            // 
            // DarkGroupBox6
            // 
            this.DarkGroupBox6.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox6.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox6.Controls.Add(this.btnItemAdd);
            this.DarkGroupBox6.Controls.Add(this.nudItemAmount);
            this.DarkGroupBox6.Controls.Add(this.DarkLabel12);
            this.DarkGroupBox6.Controls.Add(this.cmbItems);
            this.DarkGroupBox6.Controls.Add(this.DarkLabel11);
            this.DarkGroupBox6.Controls.Add(this.lstStartItems);
            this.DarkGroupBox6.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox6.Location = new System.Drawing.Point(6, 310);
            this.DarkGroupBox6.Name = "DarkGroupBox6";
            this.DarkGroupBox6.Size = new System.Drawing.Size(328, 106);
            this.DarkGroupBox6.TabIndex = 7;
            this.DarkGroupBox6.TabStop = false;
            this.DarkGroupBox6.Text = "Starting Items";
            // 
            // btnItemAdd
            // 
            this.btnItemAdd.Location = new System.Drawing.Point(183, 73);
            this.btnItemAdd.Name = "btnItemAdd";
            this.btnItemAdd.Padding = new System.Windows.Forms.Padding(5);
            this.btnItemAdd.Size = new System.Drawing.Size(139, 26);
            this.btnItemAdd.TabIndex = 6;
            this.btnItemAdd.Text = "Update List";
            // 
            // nudItemAmount
            // 
            this.nudItemAmount.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudItemAmount.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudItemAmount.Location = new System.Drawing.Point(235, 50);
            this.nudItemAmount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudItemAmount.Name = "nudItemAmount";
            this.nudItemAmount.Size = new System.Drawing.Size(87, 20);
            this.nudItemAmount.TabIndex = 5;
            this.nudItemAmount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DarkLabel12
            // 
            this.DarkLabel12.AutoSize = true;
            this.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel12.Location = new System.Drawing.Point(183, 52);
            this.DarkLabel12.Name = "DarkLabel12";
            this.DarkLabel12.Size = new System.Drawing.Size(46, 13);
            this.DarkLabel12.TabIndex = 4;
            this.DarkLabel12.Text = "Amount:";
            // 
            // cmbItems
            // 
            this.cmbItems.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbItems.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbItems.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbItems.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbItems.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbItems.ButtonIcon");
            this.cmbItems.DrawDropdownHoverOutline = false;
            this.cmbItems.DrawFocusRectangle = false;
            this.cmbItems.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItems.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbItems.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbItems.FormattingEnabled = true;
            this.cmbItems.Location = new System.Drawing.Point(183, 23);
            this.cmbItems.Name = "cmbItems";
            this.cmbItems.Size = new System.Drawing.Size(139, 21);
            this.cmbItems.TabIndex = 3;
            this.cmbItems.Text = null;
            this.cmbItems.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel11
            // 
            this.DarkLabel11.AutoSize = true;
            this.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel11.Location = new System.Drawing.Point(183, 7);
            this.DarkLabel11.Name = "DarkLabel11";
            this.DarkLabel11.Size = new System.Drawing.Size(52, 13);
            this.DarkLabel11.TabIndex = 2;
            this.DarkLabel11.Text = "Start Item";
            // 
            // lstStartItems
            // 
            this.lstStartItems.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.lstStartItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstStartItems.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstStartItems.FormattingEnabled = true;
            this.lstStartItems.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            this.lstStartItems.Location = new System.Drawing.Point(6, 19);
            this.lstStartItems.Name = "lstStartItems";
            this.lstStartItems.Size = new System.Drawing.Size(171, 80);
            this.lstStartItems.TabIndex = 1;
            // 
            // DarkGroupBox5
            // 
            this.DarkGroupBox5.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox5.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox5.Controls.Add(this.nudBaseExp);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel10);
            this.DarkGroupBox5.Controls.Add(this.nudSpirit);
            this.DarkGroupBox5.Controls.Add(this.nudEndurance);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel8);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel9);
            this.DarkGroupBox5.Controls.Add(this.nudVitality);
            this.DarkGroupBox5.Controls.Add(this.nudLuck);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel6);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel7);
            this.DarkGroupBox5.Controls.Add(this.nudIntelligence);
            this.DarkGroupBox5.Controls.Add(this.nudStrength);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel5);
            this.DarkGroupBox5.Controls.Add(this.DarkLabel3);
            this.DarkGroupBox5.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox5.Location = new System.Drawing.Point(6, 204);
            this.DarkGroupBox5.Name = "DarkGroupBox5";
            this.DarkGroupBox5.Size = new System.Drawing.Size(328, 100);
            this.DarkGroupBox5.TabIndex = 6;
            this.DarkGroupBox5.TabStop = false;
            this.DarkGroupBox5.Text = "Start Stats";
            // 
            // nudBaseExp
            // 
            this.nudBaseExp.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudBaseExp.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudBaseExp.Location = new System.Drawing.Point(102, 70);
            this.nudBaseExp.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            this.nudBaseExp.Name = "nudBaseExp";
            this.nudBaseExp.Size = new System.Drawing.Size(103, 20);
            this.nudBaseExp.TabIndex = 13;
            this.nudBaseExp.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // DarkLabel10
            // 
            this.DarkLabel10.AutoSize = true;
            this.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel10.Location = new System.Drawing.Point(6, 72);
            this.DarkLabel10.Name = "DarkLabel10";
            this.DarkLabel10.Size = new System.Drawing.Size(90, 13);
            this.DarkLabel10.TabIndex = 12;
            this.DarkLabel10.Text = "Base Experience:";
            // 
            // nudSpirit
            // 
            this.nudSpirit.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudSpirit.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudSpirit.Location = new System.Drawing.Point(277, 40);
            this.nudSpirit.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudSpirit.Name = "nudSpirit";
            this.nudSpirit.Size = new System.Drawing.Size(45, 20);
            this.nudSpirit.TabIndex = 11;
            this.nudSpirit.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudEndurance
            // 
            this.nudEndurance.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudEndurance.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudEndurance.Location = new System.Drawing.Point(277, 14);
            this.nudEndurance.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            this.nudEndurance.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudEndurance.Name = "nudEndurance";
            this.nudEndurance.Size = new System.Drawing.Size(45, 20);
            this.nudEndurance.TabIndex = 10;
            this.nudEndurance.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DarkLabel8
            // 
            this.DarkLabel8.AutoSize = true;
            this.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel8.Location = new System.Drawing.Point(211, 42);
            this.DarkLabel8.Name = "DarkLabel8";
            this.DarkLabel8.Size = new System.Drawing.Size(33, 13);
            this.DarkLabel8.TabIndex = 9;
            this.DarkLabel8.Text = "Spirit:";
            // 
            // DarkLabel9
            // 
            this.DarkLabel9.AutoSize = true;
            this.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel9.Location = new System.Drawing.Point(211, 16);
            this.DarkLabel9.Name = "DarkLabel9";
            this.DarkLabel9.Size = new System.Drawing.Size(62, 13);
            this.DarkLabel9.TabIndex = 8;
            this.DarkLabel9.Text = "Endurance:";
            // 
            // nudVitality
            // 
            this.nudVitality.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudVitality.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudVitality.Location = new System.Drawing.Point(160, 40);
            this.nudVitality.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudVitality.Name = "nudVitality";
            this.nudVitality.Size = new System.Drawing.Size(45, 20);
            this.nudVitality.TabIndex = 7;
            this.nudVitality.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudLuck
            // 
            this.nudLuck.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudLuck.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudLuck.Location = new System.Drawing.Point(160, 14);
            this.nudLuck.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            this.nudLuck.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudLuck.Name = "nudLuck";
            this.nudLuck.Size = new System.Drawing.Size(45, 20);
            this.nudLuck.TabIndex = 6;
            this.nudLuck.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DarkLabel6
            // 
            this.DarkLabel6.AutoSize = true;
            this.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel6.Location = new System.Drawing.Point(120, 42);
            this.DarkLabel6.Name = "DarkLabel6";
            this.DarkLabel6.Size = new System.Drawing.Size(40, 13);
            this.DarkLabel6.TabIndex = 5;
            this.DarkLabel6.Text = "Vitality:";
            // 
            // DarkLabel7
            // 
            this.DarkLabel7.AutoSize = true;
            this.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel7.Location = new System.Drawing.Point(120, 16);
            this.DarkLabel7.Name = "DarkLabel7";
            this.DarkLabel7.Size = new System.Drawing.Size(34, 13);
            this.DarkLabel7.TabIndex = 4;
            this.DarkLabel7.Text = "Luck:";
            // 
            // nudIntelligence
            // 
            this.nudIntelligence.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudIntelligence.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudIntelligence.Location = new System.Drawing.Point(69, 40);
            this.nudIntelligence.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudIntelligence.Name = "nudIntelligence";
            this.nudIntelligence.Size = new System.Drawing.Size(45, 20);
            this.nudIntelligence.TabIndex = 3;
            this.nudIntelligence.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // nudStrength
            // 
            this.nudStrength.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudStrength.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudStrength.Location = new System.Drawing.Point(69, 14);
            this.nudStrength.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            this.nudStrength.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.nudStrength.Name = "nudStrength";
            this.nudStrength.Size = new System.Drawing.Size(45, 20);
            this.nudStrength.TabIndex = 2;
            this.nudStrength.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DarkLabel5
            // 
            this.DarkLabel5.AutoSize = true;
            this.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel5.Location = new System.Drawing.Point(6, 42);
            this.DarkLabel5.Name = "DarkLabel5";
            this.DarkLabel5.Size = new System.Drawing.Size(64, 13);
            this.DarkLabel5.TabIndex = 1;
            this.DarkLabel5.Text = "Intelligence:";
            // 
            // DarkLabel3
            // 
            this.DarkLabel3.AutoSize = true;
            this.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel3.Location = new System.Drawing.Point(6, 16);
            this.DarkLabel3.Name = "DarkLabel3";
            this.DarkLabel3.Size = new System.Drawing.Size(50, 13);
            this.DarkLabel3.TabIndex = 0;
            this.DarkLabel3.Text = "Strength:";
            // 
            // DarkGroupBox4
            // 
            this.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox4.Controls.Add(this.nudFemaleSprite);
            this.DarkGroupBox4.Controls.Add(this.DarkLabel4);
            this.DarkGroupBox4.Controls.Add(this.btnDeleteFemaleSprite);
            this.DarkGroupBox4.Controls.Add(this.btnAddFemaleSprite);
            this.DarkGroupBox4.Controls.Add(this.cmbFemaleSprite);
            this.DarkGroupBox4.Controls.Add(this.picFemale);
            this.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox4.Location = new System.Drawing.Point(173, 87);
            this.DarkGroupBox4.Name = "DarkGroupBox4";
            this.DarkGroupBox4.Size = new System.Drawing.Size(161, 111);
            this.DarkGroupBox4.TabIndex = 5;
            this.DarkGroupBox4.TabStop = false;
            this.DarkGroupBox4.Text = "Female Sprite";
            // 
            // nudFemaleSprite
            // 
            this.nudFemaleSprite.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudFemaleSprite.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudFemaleSprite.Location = new System.Drawing.Point(46, 54);
            this.nudFemaleSprite.Name = "nudFemaleSprite";
            this.nudFemaleSprite.Size = new System.Drawing.Size(55, 20);
            this.nudFemaleSprite.TabIndex = 18;
            this.nudFemaleSprite.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // DarkLabel4
            // 
            this.DarkLabel4.AutoSize = true;
            this.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel4.Location = new System.Drawing.Point(3, 56);
            this.DarkLabel4.Name = "DarkLabel4";
            this.DarkLabel4.Size = new System.Drawing.Size(37, 13);
            this.DarkLabel4.TabIndex = 17;
            this.DarkLabel4.Text = "Sprite:";
            // 
            // btnDeleteFemaleSprite
            // 
            this.btnDeleteFemaleSprite.Image = (System.Drawing.Image)resources.GetObject("btnDeleteFemaleSprite.Image");
            this.btnDeleteFemaleSprite.Location = new System.Drawing.Point(36, 19);
            this.btnDeleteFemaleSprite.Name = "btnDeleteFemaleSprite";
            this.btnDeleteFemaleSprite.Padding = new System.Windows.Forms.Padding(5);
            this.btnDeleteFemaleSprite.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteFemaleSprite.TabIndex = 16;
            // 
            // btnAddFemaleSprite
            // 
            this.btnAddFemaleSprite.Image = (System.Drawing.Image)resources.GetObject("btnAddFemaleSprite.Image");
            this.btnAddFemaleSprite.Location = new System.Drawing.Point(6, 19);
            this.btnAddFemaleSprite.Name = "btnAddFemaleSprite";
            this.btnAddFemaleSprite.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddFemaleSprite.Size = new System.Drawing.Size(24, 24);
            this.btnAddFemaleSprite.TabIndex = 13;
            // 
            // cmbFemaleSprite
            // 
            this.cmbFemaleSprite.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbFemaleSprite.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbFemaleSprite.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbFemaleSprite.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbFemaleSprite.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbFemaleSprite.ButtonIcon");
            this.cmbFemaleSprite.DrawDropdownHoverOutline = false;
            this.cmbFemaleSprite.DrawFocusRectangle = false;
            this.cmbFemaleSprite.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbFemaleSprite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFemaleSprite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbFemaleSprite.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbFemaleSprite.FormattingEnabled = true;
            this.cmbFemaleSprite.Location = new System.Drawing.Point(6, 80);
            this.cmbFemaleSprite.Name = "cmbFemaleSprite";
            this.cmbFemaleSprite.Size = new System.Drawing.Size(149, 21);
            this.cmbFemaleSprite.TabIndex = 15;
            this.cmbFemaleSprite.Text = null;
            this.cmbFemaleSprite.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // picFemale
            // 
            this.picFemale.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(64)), System.Convert.ToInt32(System.Convert.ToByte(64)), System.Convert.ToInt32(System.Convert.ToByte(64)));
            this.picFemale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picFemale.Location = new System.Drawing.Point(107, 10);
            this.picFemale.Name = "picFemale";
            this.picFemale.Size = new System.Drawing.Size(48, 64);
            this.picFemale.TabIndex = 14;
            this.picFemale.TabStop = false;
            // 
            // DarkGroupBox3
            // 
            this.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox3.Controls.Add(this.nudMaleSprite);
            this.DarkGroupBox3.Controls.Add(this.lblMaleSprite);
            this.DarkGroupBox3.Controls.Add(this.btnDeleteMaleSprite);
            this.DarkGroupBox3.Controls.Add(this.btnAddMaleSprite);
            this.DarkGroupBox3.Controls.Add(this.cmbMaleSprite);
            this.DarkGroupBox3.Controls.Add(this.picMale);
            this.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox3.Location = new System.Drawing.Point(6, 87);
            this.DarkGroupBox3.Name = "DarkGroupBox3";
            this.DarkGroupBox3.Size = new System.Drawing.Size(161, 111);
            this.DarkGroupBox3.TabIndex = 4;
            this.DarkGroupBox3.TabStop = false;
            this.DarkGroupBox3.Text = "Male Sprite";
            // 
            // nudMaleSprite
            // 
            this.nudMaleSprite.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudMaleSprite.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudMaleSprite.Location = new System.Drawing.Point(46, 54);
            this.nudMaleSprite.Name = "nudMaleSprite";
            this.nudMaleSprite.Size = new System.Drawing.Size(55, 20);
            this.nudMaleSprite.TabIndex = 12;
            this.nudMaleSprite.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblMaleSprite
            // 
            this.lblMaleSprite.AutoSize = true;
            this.lblMaleSprite.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblMaleSprite.Location = new System.Drawing.Point(3, 56);
            this.lblMaleSprite.Name = "lblMaleSprite";
            this.lblMaleSprite.Size = new System.Drawing.Size(37, 13);
            this.lblMaleSprite.TabIndex = 11;
            this.lblMaleSprite.Text = "Sprite:";
            // 
            // btnDeleteMaleSprite
            // 
            this.btnDeleteMaleSprite.Image = (System.Drawing.Image)resources.GetObject("btnDeleteMaleSprite.Image");
            this.btnDeleteMaleSprite.Location = new System.Drawing.Point(36, 19);
            this.btnDeleteMaleSprite.Name = "btnDeleteMaleSprite";
            this.btnDeleteMaleSprite.Padding = new System.Windows.Forms.Padding(5);
            this.btnDeleteMaleSprite.Size = new System.Drawing.Size(24, 24);
            this.btnDeleteMaleSprite.TabIndex = 10;
            // 
            // btnAddMaleSprite
            // 
            this.btnAddMaleSprite.Image = (System.Drawing.Image)resources.GetObject("btnAddMaleSprite.Image");
            this.btnAddMaleSprite.Location = new System.Drawing.Point(6, 19);
            this.btnAddMaleSprite.Name = "btnAddMaleSprite";
            this.btnAddMaleSprite.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddMaleSprite.Size = new System.Drawing.Size(24, 24);
            this.btnAddMaleSprite.TabIndex = 6;
            // 
            // cmbMaleSprite
            // 
            this.cmbMaleSprite.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbMaleSprite.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbMaleSprite.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbMaleSprite.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbMaleSprite.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbMaleSprite.ButtonIcon");
            this.cmbMaleSprite.DrawDropdownHoverOutline = false;
            this.cmbMaleSprite.DrawFocusRectangle = false;
            this.cmbMaleSprite.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMaleSprite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMaleSprite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMaleSprite.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbMaleSprite.FormattingEnabled = true;
            this.cmbMaleSprite.Location = new System.Drawing.Point(6, 80);
            this.cmbMaleSprite.Name = "cmbMaleSprite";
            this.cmbMaleSprite.Size = new System.Drawing.Size(149, 21);
            this.cmbMaleSprite.TabIndex = 9;
            this.cmbMaleSprite.Text = null;
            this.cmbMaleSprite.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // picMale
            // 
            this.picMale.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(64)), System.Convert.ToInt32(System.Convert.ToByte(64)), System.Convert.ToInt32(System.Convert.ToByte(64)));
            this.picMale.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picMale.Location = new System.Drawing.Point(107, 10);
            this.picMale.Name = "picMale";
            this.picMale.Size = new System.Drawing.Size(48, 64);
            this.picMale.TabIndex = 8;
            this.picMale.TabStop = false;
            // 
            // txtDescription
            // 
            this.txtDescription.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
            this.txtDescription.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.txtDescription.Location = new System.Drawing.Point(75, 47);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(259, 34);
            this.txtDescription.TabIndex = 3;
            // 
            // DarkLabel2
            // 
            this.DarkLabel2.AutoSize = true;
            this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel2.Location = new System.Drawing.Point(6, 49);
            this.DarkLabel2.Name = "DarkLabel2";
            this.DarkLabel2.Size = new System.Drawing.Size(63, 13);
            this.DarkLabel2.TabIndex = 2;
            this.DarkLabel2.Text = "Description:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.txtName.Location = new System.Drawing.Point(50, 14);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(284, 22);
            this.txtName.TabIndex = 1;
            // 
            // DarkLabel1
            // 
            this.DarkLabel1.AutoSize = true;
            this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel1.Location = new System.Drawing.Point(6, 16);
            this.DarkLabel1.Name = "DarkLabel1";
            this.DarkLabel1.Size = new System.Drawing.Size(38, 13);
            this.DarkLabel1.TabIndex = 0;
            this.DarkLabel1.Text = "Name:";
            // 
            // btnAddClass
            // 
            this.btnAddClass.Location = new System.Drawing.Point(8, 319);
            this.btnAddClass.Name = "btnAddClass";
            this.btnAddClass.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddClass.Size = new System.Drawing.Size(160, 23);
            this.btnAddClass.TabIndex = 2;
            this.btnAddClass.Text = "Add Class";
            // 
            // btnRemoveClass
            // 
            this.btnRemoveClass.Location = new System.Drawing.Point(8, 348);
            this.btnRemoveClass.Name = "btnRemoveClass";
            this.btnRemoveClass.Padding = new System.Windows.Forms.Padding(5);
            this.btnRemoveClass.Size = new System.Drawing.Size(160, 23);
            this.btnRemoveClass.TabIndex = 3;
            this.btnRemoveClass.Text = "Remove Class";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(8, 451);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(160, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(8, 422);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(160, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            // 
            // frmClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.ClientSize = new System.Drawing.Size(527, 479);
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRemoveClass);
            this.Controls.Add(this.btnAddClass);
            this.Controls.Add(this.DarkGroupBox2);
            this.Controls.Add(this.DarkGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmClasses";
            this.Text = "Class Editor";
            this.DarkGroupBox1.ResumeLayout(false);
            this.DarkGroupBox2.ResumeLayout(false);
            this.DarkGroupBox2.PerformLayout();
            this.DarkGroupBox7.ResumeLayout(false);
            this.DarkGroupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudStartY).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudStartX).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudStartMap).EndInit();
            this.DarkGroupBox6.ResumeLayout(false);
            this.DarkGroupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudItemAmount).EndInit();
            this.DarkGroupBox5.ResumeLayout(false);
            this.DarkGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudBaseExp).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudSpirit).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudEndurance).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudVitality).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudLuck).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudIntelligence).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudStrength).EndInit();
            this.DarkGroupBox4.ResumeLayout(false);
            this.DarkGroupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudFemaleSprite).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.picFemale).EndInit();
            this.DarkGroupBox3.ResumeLayout(false);
            this.DarkGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudMaleSprite).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.picMale).EndInit();
            this.ResumeLayout(false);
        }

        private DarkUI.Controls.DarkGroupBox _DarkGroupBox1;

        internal DarkUI.Controls.DarkGroupBox DarkGroupBox1
        {
            
            get
            {
                return _DarkGroupBox1;
            }

            
            set
            {
                if (_DarkGroupBox1 != null)
                {
                }

                _DarkGroupBox1 = value;
                if (_DarkGroupBox1 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkGroupBox _DarkGroupBox2;

        internal DarkUI.Controls.DarkGroupBox DarkGroupBox2
        {
            
            get
            {
                return _DarkGroupBox2;
            }

            
            set
            {
                if (_DarkGroupBox2 != null)
                {
                }

                _DarkGroupBox2 = value;
                if (_DarkGroupBox2 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkTextBox _txtName;

        internal DarkUI.Controls.DarkTextBox txtName
        {
            
            get
            {
                return _txtName;
            }

            
            set
            {
                if (_txtName != null)
                {
                }

                _txtName = value;
                if (_txtName != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel1;

        internal DarkUI.Controls.DarkLabel DarkLabel1
        {
            
            get
            {
                return _DarkLabel1;
            }

            
            set
            {
                if (_DarkLabel1 != null)
                {
                }

                _DarkLabel1 = value;
                if (_DarkLabel1 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkTextBox _txtDescription;

        internal DarkUI.Controls.DarkTextBox txtDescription
        {
            
            get
            {
                return _txtDescription;
            }

            
            set
            {
                if (_txtDescription != null)
                {
                }

                _txtDescription = value;
                if (_txtDescription != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel2;

        internal DarkUI.Controls.DarkLabel DarkLabel2
        {
            
            get
            {
                return _DarkLabel2;
            }

            
            set
            {
                if (_DarkLabel2 != null)
                {
                }

                _DarkLabel2 = value;
                if (_DarkLabel2 != null)
                {
                }
            }
        }

        private ListBox _lstIndex;

        internal ListBox lstIndex
        {
            
            get
            {
                return _lstIndex;
            }

            
            set
            {
                if (_lstIndex != null)
                {
                }

                _lstIndex = value;
                if (_lstIndex != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkGroupBox _DarkGroupBox4;

        internal DarkUI.Controls.DarkGroupBox DarkGroupBox4
        {
            
            get
            {
                return _DarkGroupBox4;
            }

            
            set
            {
                if (_DarkGroupBox4 != null)
                {
                }

                _DarkGroupBox4 = value;
                if (_DarkGroupBox4 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkGroupBox _DarkGroupBox3;

        internal DarkUI.Controls.DarkGroupBox DarkGroupBox3
        {
            
            get
            {
                return _DarkGroupBox3;
            }

            
            set
            {
                if (_DarkGroupBox3 != null)
                {
                }

                _DarkGroupBox3 = value;
                if (_DarkGroupBox3 != null)
                {
                }
            }
        }

        private PictureBox _picMale;

        internal PictureBox picMale
        {
            
            get
            {
                return _picMale;
            }

            
            set
            {
                if (_picMale != null)
                {
                }

                _picMale = value;
                if (_picMale != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkComboBox _cmbMaleSprite;

        internal DarkUI.Controls.DarkComboBox cmbMaleSprite
        {
            
            get
            {
                return _cmbMaleSprite;
            }

            
            set
            {
                if (_cmbMaleSprite != null)
                {
                }

                _cmbMaleSprite = value;
                if (_cmbMaleSprite != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnAddMaleSprite;

        internal DarkUI.Controls.DarkButton btnAddMaleSprite
        {
            
            get
            {
                return _btnAddMaleSprite;
            }

            
            set
            {
                if (_btnAddMaleSprite != null)
                {
                }

                _btnAddMaleSprite = value;
                if (_btnAddMaleSprite != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnDeleteMaleSprite;

        internal DarkUI.Controls.DarkButton btnDeleteMaleSprite
        {
            
            get
            {
                return _btnDeleteMaleSprite;
            }

            
            set
            {
                if (_btnDeleteMaleSprite != null)
                {
                }

                _btnDeleteMaleSprite = value;
                if (_btnDeleteMaleSprite != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel4;

        internal DarkUI.Controls.DarkLabel DarkLabel4
        {
            
            get
            {
                return _DarkLabel4;
            }

            
            set
            {
                if (_DarkLabel4 != null)
                {
                }

                _DarkLabel4 = value;
                if (_DarkLabel4 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnDeleteFemaleSprite;

        internal DarkUI.Controls.DarkButton btnDeleteFemaleSprite
        {
            
            get
            {
                return _btnDeleteFemaleSprite;
            }

            
            set
            {
                if (_btnDeleteFemaleSprite != null)
                {
                }

                _btnDeleteFemaleSprite = value;
                if (_btnDeleteFemaleSprite != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnAddFemaleSprite;

        internal DarkUI.Controls.DarkButton btnAddFemaleSprite
        {
            
            get
            {
                return _btnAddFemaleSprite;
            }

            
            set
            {
                if (_btnAddFemaleSprite != null)
                {
                }

                _btnAddFemaleSprite = value;
                if (_btnAddFemaleSprite != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkComboBox _cmbFemaleSprite;

        internal DarkUI.Controls.DarkComboBox cmbFemaleSprite
        {
            
            get
            {
                return _cmbFemaleSprite;
            }

            
            set
            {
                if (_cmbFemaleSprite != null)
                {
                }

                _cmbFemaleSprite = value;
                if (_cmbFemaleSprite != null)
                {
                }
            }
        }

        private PictureBox _picFemale;

        internal PictureBox picFemale
        {
            
            get
            {
                return _picFemale;
            }

            
            set
            {
                if (_picFemale != null)
                {
                }

                _picFemale = value;
                if (_picFemale != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _lblMaleSprite;

        internal DarkUI.Controls.DarkLabel lblMaleSprite
        {
            
            get
            {
                return _lblMaleSprite;
            }

            
            set
            {
                if (_lblMaleSprite != null)
                {
                }

                _lblMaleSprite = value;
                if (_lblMaleSprite != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnAddClass;

        internal DarkUI.Controls.DarkButton btnAddClass
        {
            
            get
            {
                return _btnAddClass;
            }

            
            set
            {
                if (_btnAddClass != null)
                {
                }

                _btnAddClass = value;
                if (_btnAddClass != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnRemoveClass;

        internal DarkUI.Controls.DarkButton btnRemoveClass
        {
            
            get
            {
                return _btnRemoveClass;
            }

            
            set
            {
                if (_btnRemoveClass != null)
                {
                }

                _btnRemoveClass = value;
                if (_btnRemoveClass != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnCancel;

        internal DarkUI.Controls.DarkButton btnCancel
        {
            
            get
            {
                return _btnCancel;
            }

            
            set
            {
                if (_btnCancel != null)
                {
                }

                _btnCancel = value;
                if (_btnCancel != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnSave;

        internal DarkUI.Controls.DarkButton btnSave
        {
            
            get
            {
                return _btnSave;
            }

            
            set
            {
                if (_btnSave != null)
                {
                }

                _btnSave = value;
                if (_btnSave != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkGroupBox _DarkGroupBox5;

        internal DarkUI.Controls.DarkGroupBox DarkGroupBox5
        {
            
            get
            {
                return _DarkGroupBox5;
            }

            
            set
            {
                if (_DarkGroupBox5 != null)
                {
                }

                _DarkGroupBox5 = value;
                if (_DarkGroupBox5 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudFemaleSprite;

        internal DarkUI.Controls.DarkNumericUpDown nudFemaleSprite
        {
            
            get
            {
                return _nudFemaleSprite;
            }

            
            set
            {
                if (_nudFemaleSprite != null)
                {
                }

                _nudFemaleSprite = value;
                if (_nudFemaleSprite != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudMaleSprite;

        internal DarkUI.Controls.DarkNumericUpDown nudMaleSprite
        {
            
            get
            {
                return _nudMaleSprite;
            }

            
            set
            {
                if (_nudMaleSprite != null)
                {
                }

                _nudMaleSprite = value;
                if (_nudMaleSprite != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel5;

        internal DarkUI.Controls.DarkLabel DarkLabel5
        {
            
            get
            {
                return _DarkLabel5;
            }

            
            set
            {
                if (_DarkLabel5 != null)
                {
                }

                _DarkLabel5 = value;
                if (_DarkLabel5 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel3;

        internal DarkUI.Controls.DarkLabel DarkLabel3
        {
            
            get
            {
                return _DarkLabel3;
            }

            
            set
            {
                if (_DarkLabel3 != null)
                {
                }

                _DarkLabel3 = value;
                if (_DarkLabel3 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudIntelligence;

        internal DarkUI.Controls.DarkNumericUpDown nudIntelligence
        {
            
            get
            {
                return _nudIntelligence;
            }

            
            set
            {
                if (_nudIntelligence != null)
                {
                }

                _nudIntelligence = value;
                if (_nudIntelligence != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudStrength;

        internal DarkUI.Controls.DarkNumericUpDown nudStrength
        {
            
            get
            {
                return _nudStrength;
            }

            
            set
            {
                if (_nudStrength != null)
                {
                }

                _nudStrength = value;
                if (_nudStrength != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudVitality;

        internal DarkUI.Controls.DarkNumericUpDown nudVitality
        {
            
            get
            {
                return _nudVitality;
            }

            
            set
            {
                if (_nudVitality != null)
                {
                }

                _nudVitality = value;
                if (_nudVitality != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudLuck;

        internal DarkUI.Controls.DarkNumericUpDown nudLuck
        {
            
            get
            {
                return _nudLuck;
            }

            
            set
            {
                if (_nudLuck != null)
                {
                }

                _nudLuck = value;
                if (_nudLuck != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel6;

        internal DarkUI.Controls.DarkLabel DarkLabel6
        {
            
            get
            {
                return _DarkLabel6;
            }

            
            set
            {
                if (_DarkLabel6 != null)
                {
                }

                _DarkLabel6 = value;
                if (_DarkLabel6 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel7;

        internal DarkUI.Controls.DarkLabel DarkLabel7
        {
            
            get
            {
                return _DarkLabel7;
            }

            
            set
            {
                if (_DarkLabel7 != null)
                {
                }

                _DarkLabel7 = value;
                if (_DarkLabel7 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudSpirit;

        internal DarkUI.Controls.DarkNumericUpDown nudSpirit
        {
            
            get
            {
                return _nudSpirit;
            }

            
            set
            {
                if (_nudSpirit != null)
                {
                }

                _nudSpirit = value;
                if (_nudSpirit != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudEndurance;

        internal DarkUI.Controls.DarkNumericUpDown nudEndurance
        {
            
            get
            {
                return _nudEndurance;
            }

            
            set
            {
                if (_nudEndurance != null)
                {
                }

                _nudEndurance = value;
                if (_nudEndurance != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel8;

        internal DarkUI.Controls.DarkLabel DarkLabel8
        {
            
            get
            {
                return _DarkLabel8;
            }

            
            set
            {
                if (_DarkLabel8 != null)
                {
                }

                _DarkLabel8 = value;
                if (_DarkLabel8 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel9;

        internal DarkUI.Controls.DarkLabel DarkLabel9
        {
            
            get
            {
                return _DarkLabel9;
            }

            
            set
            {
                if (_DarkLabel9 != null)
                {
                }

                _DarkLabel9 = value;
                if (_DarkLabel9 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudBaseExp;

        internal DarkUI.Controls.DarkNumericUpDown nudBaseExp
        {
            
            get
            {
                return _nudBaseExp;
            }

            
            set
            {
                if (_nudBaseExp != null)
                {
                }

                _nudBaseExp = value;
                if (_nudBaseExp != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel10;

        internal DarkUI.Controls.DarkLabel DarkLabel10
        {
            
            get
            {
                return _DarkLabel10;
            }

            
            set
            {
                if (_DarkLabel10 != null)
                {
                }

                _DarkLabel10 = value;
                if (_DarkLabel10 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkGroupBox _DarkGroupBox6;

        internal DarkUI.Controls.DarkGroupBox DarkGroupBox6
        {
            
            get
            {
                return _DarkGroupBox6;
            }

            
            set
            {
                if (_DarkGroupBox6 != null)
                {
                }

                _DarkGroupBox6 = value;
                if (_DarkGroupBox6 != null)
                {
                }
            }
        }

        private ListBox _lstStartItems;

        internal ListBox lstStartItems
        {
            
            get
            {
                return _lstStartItems;
            }

            
            set
            {
                if (_lstStartItems != null)
                {
                }

                _lstStartItems = value;
                if (_lstStartItems != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkComboBox _cmbItems;

        internal DarkUI.Controls.DarkComboBox cmbItems
        {
            
            get
            {
                return _cmbItems;
            }

            
            set
            {
                if (_cmbItems != null)
                {
                }

                _cmbItems = value;
                if (_cmbItems != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel11;

        internal DarkUI.Controls.DarkLabel DarkLabel11
        {
            
            get
            {
                return _DarkLabel11;
            }

            
            set
            {
                if (_DarkLabel11 != null)
                {
                }

                _DarkLabel11 = value;
                if (_DarkLabel11 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudItemAmount;

        internal DarkUI.Controls.DarkNumericUpDown nudItemAmount
        {
            
            get
            {
                return _nudItemAmount;
            }

            
            set
            {
                if (_nudItemAmount != null)
                {
                }

                _nudItemAmount = value;
                if (_nudItemAmount != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel12;

        internal DarkUI.Controls.DarkLabel DarkLabel12
        {
            
            get
            {
                return _DarkLabel12;
            }

            
            set
            {
                if (_DarkLabel12 != null)
                {
                }

                _DarkLabel12 = value;
                if (_DarkLabel12 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkButton _btnItemAdd;

        internal DarkUI.Controls.DarkButton btnItemAdd
        {
            
            get
            {
                return _btnItemAdd;
            }

            
            set
            {
                if (_btnItemAdd != null)
                {
                }

                _btnItemAdd = value;
                if (_btnItemAdd != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkGroupBox _DarkGroupBox7;

        internal DarkUI.Controls.DarkGroupBox DarkGroupBox7
        {
            
            get
            {
                return _DarkGroupBox7;
            }

            
            set
            {
                if (_DarkGroupBox7 != null)
                {
                }

                _DarkGroupBox7 = value;
                if (_DarkGroupBox7 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudStartMap;

        internal DarkUI.Controls.DarkNumericUpDown nudStartMap
        {
            
            get
            {
                return _nudStartMap;
            }

            
            set
            {
                if (_nudStartMap != null)
                {
                }

                _nudStartMap = value;
                if (_nudStartMap != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel13;

        internal DarkUI.Controls.DarkLabel DarkLabel13
        {
            
            get
            {
                return _DarkLabel13;
            }

            
            set
            {
                if (_DarkLabel13 != null)
                {
                }

                _DarkLabel13 = value;
                if (_DarkLabel13 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudStartY;

        internal DarkUI.Controls.DarkNumericUpDown nudStartY
        {
            
            get
            {
                return _nudStartY;
            }

            
            set
            {
                if (_nudStartY != null)
                {
                }

                _nudStartY = value;
                if (_nudStartY != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel15;

        internal DarkUI.Controls.DarkLabel DarkLabel15
        {
            
            get
            {
                return _DarkLabel15;
            }

            
            set
            {
                if (_DarkLabel15 != null)
                {
                }

                _DarkLabel15 = value;
                if (_DarkLabel15 != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkNumericUpDown _nudStartX;

        internal DarkUI.Controls.DarkNumericUpDown nudStartX
        {
            
            get
            {
                return _nudStartX;
            }

            
            set
            {
                if (_nudStartX != null)
                {
                }

                _nudStartX = value;
                if (_nudStartX != null)
                {
                }
            }
        }

        private DarkUI.Controls.DarkLabel _DarkLabel14;

        internal DarkUI.Controls.DarkLabel DarkLabel14
        {
            
            get
            {
                return _DarkLabel14;
            }

            
            set
            {
                if (_DarkLabel14 != null)
                {
                }

                _DarkLabel14 = value;
                if (_DarkLabel14 != null)
                {
                }
            }
        }
    }
}
