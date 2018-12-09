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
    partial class frmShop : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShop));
            this.DarkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
            this.lstIndex = new System.Windows.Forms.ListBox();
            this.DarkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.btnDelete = new DarkUI.Controls.DarkButton();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.DarkGroupBox3 = new DarkUI.Controls.DarkGroupBox();
            this.btnDeleteTrade = new DarkUI.Controls.DarkButton();
            this.btnUpdate = new DarkUI.Controls.DarkButton();
            this.nudCostValue = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel8 = new DarkUI.Controls.DarkLabel();
            this.cmbCostItem = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel7 = new DarkUI.Controls.DarkLabel();
            this.nudItemValue = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel6 = new DarkUI.Controls.DarkLabel();
            this.cmbItem = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel5 = new DarkUI.Controls.DarkLabel();
            this.lstTradeItem = new System.Windows.Forms.ListBox();
            this.DarkLabel4 = new DarkUI.Controls.DarkLabel();
            this.nudBuy = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel3 = new DarkUI.Controls.DarkLabel();
            this.nudFace = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel2 = new DarkUI.Controls.DarkLabel();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel1 = new DarkUI.Controls.DarkLabel();
            this.picFace = new System.Windows.Forms.PictureBox();
            this.DarkGroupBox1.SuspendLayout();
            this.DarkGroupBox2.SuspendLayout();
            this.DarkGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudCostValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudItemValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudBuy).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudFace).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.picFace).BeginInit();
            this.SuspendLayout();
            // 
            // DarkGroupBox1
            // 
            this.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox1.Controls.Add(this.lstIndex);
            this.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox1.Location = new System.Drawing.Point(3, 3);
            this.DarkGroupBox1.Name = "DarkGroupBox1";
            this.DarkGroupBox1.Size = new System.Drawing.Size(209, 398);
            this.DarkGroupBox1.TabIndex = 0;
            this.DarkGroupBox1.TabStop = false;
            this.DarkGroupBox1.Text = "Shop List";
            // 
            // lstIndex
            // 
            this.lstIndex.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstIndex.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstIndex.FormattingEnabled = true;
            this.lstIndex.Location = new System.Drawing.Point(6, 19);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(196, 366);
            this.lstIndex.TabIndex = 1;
            // 
            // DarkGroupBox2
            // 
            this.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox2.Controls.Add(this.btnCancel);
            this.DarkGroupBox2.Controls.Add(this.btnDelete);
            this.DarkGroupBox2.Controls.Add(this.btnSave);
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox3);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel4);
            this.DarkGroupBox2.Controls.Add(this.nudBuy);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel3);
            this.DarkGroupBox2.Controls.Add(this.nudFace);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel2);
            this.DarkGroupBox2.Controls.Add(this.txtName);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel1);
            this.DarkGroupBox2.Controls.Add(this.picFace);
            this.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox2.Location = new System.Drawing.Point(218, 3);
            this.DarkGroupBox2.Name = "DarkGroupBox2";
            this.DarkGroupBox2.Size = new System.Drawing.Size(414, 398);
            this.DarkGroupBox2.TabIndex = 1;
            this.DarkGroupBox2.TabStop = false;
            this.DarkGroupBox2.Text = "Shop Properties";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(333, 365);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 55;
            this.btnCancel.Text = "Cancel";
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(170, 365);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Padding = new System.Windows.Forms.Padding(5);
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 54;
            this.btnDelete.Text = "Delete";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(6, 365);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 53;
            this.btnSave.Text = "Save";
            // 
            // DarkGroupBox3
            // 
            this.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox3.Controls.Add(this.btnDeleteTrade);
            this.DarkGroupBox3.Controls.Add(this.btnUpdate);
            this.DarkGroupBox3.Controls.Add(this.nudCostValue);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel8);
            this.DarkGroupBox3.Controls.Add(this.cmbCostItem);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel7);
            this.DarkGroupBox3.Controls.Add(this.nudItemValue);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel6);
            this.DarkGroupBox3.Controls.Add(this.cmbItem);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel5);
            this.DarkGroupBox3.Controls.Add(this.lstTradeItem);
            this.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox3.Location = new System.Drawing.Point(6, 121);
            this.DarkGroupBox3.Name = "DarkGroupBox3";
            this.DarkGroupBox3.Size = new System.Drawing.Size(401, 238);
            this.DarkGroupBox3.TabIndex = 52;
            this.DarkGroupBox3.TabStop = false;
            this.DarkGroupBox3.Text = "Items the Shop Sells";
            // 
            // btnDeleteTrade
            // 
            this.btnDeleteTrade.Location = new System.Drawing.Point(203, 211);
            this.btnDeleteTrade.Name = "btnDeleteTrade";
            this.btnDeleteTrade.Padding = new System.Windows.Forms.Padding(5);
            this.btnDeleteTrade.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTrade.TabIndex = 53;
            this.btnDeleteTrade.Text = "Delete";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(122, 211);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Padding = new System.Windows.Forms.Padding(5);
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 52;
            this.btnUpdate.Text = "Update";
            // 
            // nudCostValue
            // 
            this.nudCostValue.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudCostValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudCostValue.Location = new System.Drawing.Point(297, 184);
            this.nudCostValue.Name = "nudCostValue";
            this.nudCostValue.Size = new System.Drawing.Size(98, 20);
            this.nudCostValue.TabIndex = 51;
            this.nudCostValue.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // DarkLabel8
            // 
            this.DarkLabel8.AutoSize = true;
            this.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel8.Location = new System.Drawing.Point(245, 186);
            this.DarkLabel8.Name = "DarkLabel8";
            this.DarkLabel8.Size = new System.Drawing.Size(46, 13);
            this.DarkLabel8.TabIndex = 50;
            this.DarkLabel8.Text = "Amount:";
            // 
            // cmbCostItem
            // 
            this.cmbCostItem.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbCostItem.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbCostItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbCostItem.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbCostItem.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbCostItem.ButtonIcon");
            this.cmbCostItem.DrawDropdownHoverOutline = false;
            this.cmbCostItem.DrawFocusRectangle = false;
            this.cmbCostItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbCostItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCostItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCostItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbCostItem.FormattingEnabled = true;
            this.cmbCostItem.Location = new System.Drawing.Point(74, 184);
            this.cmbCostItem.Name = "cmbCostItem";
            this.cmbCostItem.Size = new System.Drawing.Size(165, 21);
            this.cmbCostItem.TabIndex = 49;
            this.cmbCostItem.Text = null;
            this.cmbCostItem.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel7
            // 
            this.DarkLabel7.AutoSize = true;
            this.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel7.Location = new System.Drawing.Point(6, 187);
            this.DarkLabel7.Name = "DarkLabel7";
            this.DarkLabel7.Size = new System.Drawing.Size(54, 13);
            this.DarkLabel7.TabIndex = 48;
            this.DarkLabel7.Text = "Item Cost:";
            // 
            // nudItemValue
            // 
            this.nudItemValue.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudItemValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudItemValue.Location = new System.Drawing.Point(297, 158);
            this.nudItemValue.Name = "nudItemValue";
            this.nudItemValue.Size = new System.Drawing.Size(98, 20);
            this.nudItemValue.TabIndex = 47;
            this.nudItemValue.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // DarkLabel6
            // 
            this.DarkLabel6.AutoSize = true;
            this.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel6.Location = new System.Drawing.Point(245, 160);
            this.DarkLabel6.Name = "DarkLabel6";
            this.DarkLabel6.Size = new System.Drawing.Size(46, 13);
            this.DarkLabel6.TabIndex = 46;
            this.DarkLabel6.Text = "Amount:";
            // 
            // cmbItem
            // 
            this.cmbItem.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbItem.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbItem.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbItem.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbItem.ButtonIcon");
            this.cmbItem.DrawDropdownHoverOutline = false;
            this.cmbItem.DrawFocusRectangle = false;
            this.cmbItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbItem.FormattingEnabled = true;
            this.cmbItem.Location = new System.Drawing.Point(74, 157);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(165, 21);
            this.cmbItem.TabIndex = 45;
            this.cmbItem.Text = null;
            this.cmbItem.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel5
            // 
            this.DarkLabel5.AutoSize = true;
            this.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel5.Location = new System.Drawing.Point(6, 160);
            this.DarkLabel5.Name = "DarkLabel5";
            this.DarkLabel5.Size = new System.Drawing.Size(62, 13);
            this.DarkLabel5.TabIndex = 44;
            this.DarkLabel5.Text = "Item to Sell:";
            // 
            // lstTradeItem
            // 
            this.lstTradeItem.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.lstTradeItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTradeItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstTradeItem.FormattingEnabled = true;
            this.lstTradeItem.Items.AddRange(new object[] { "1.", "2.", "3.", "4.", "5.", "6.", "7.", "8." });
            this.lstTradeItem.Location = new System.Drawing.Point(6, 19);
            this.lstTradeItem.Name = "lstTradeItem";
            this.lstTradeItem.Size = new System.Drawing.Size(389, 132);
            this.lstTradeItem.TabIndex = 43;
            // 
            // DarkLabel4
            // 
            this.DarkLabel4.AutoSize = true;
            this.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel4.Location = new System.Drawing.Point(279, 87);
            this.DarkLabel4.Name = "DarkLabel4";
            this.DarkLabel4.Size = new System.Drawing.Size(98, 13);
            this.DarkLabel4.TabIndex = 51;
            this.DarkLabel4.Text = "% of the Item Value";
            // 
            // nudBuy
            // 
            this.nudBuy.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudBuy.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudBuy.Location = new System.Drawing.Point(193, 85);
            this.nudBuy.Name = "nudBuy";
            this.nudBuy.Size = new System.Drawing.Size(80, 20);
            this.nudBuy.TabIndex = 50;
            this.nudBuy.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // DarkLabel3
            // 
            this.DarkLabel3.AutoSize = true;
            this.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel3.Location = new System.Drawing.Point(108, 87);
            this.DarkLabel3.Name = "DarkLabel3";
            this.DarkLabel3.Size = new System.Drawing.Size(79, 13);
            this.DarkLabel3.TabIndex = 49;
            this.DarkLabel3.Text = "BuyBack Rate:";
            // 
            // nudFace
            // 
            this.nudFace.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudFace.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudFace.Location = new System.Drawing.Point(180, 51);
            this.nudFace.Name = "nudFace";
            this.nudFace.Size = new System.Drawing.Size(93, 20);
            this.nudFace.TabIndex = 48;
            this.nudFace.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // DarkLabel2
            // 
            this.DarkLabel2.AutoSize = true;
            this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel2.Location = new System.Drawing.Point(108, 53);
            this.DarkLabel2.Name = "DarkLabel2";
            this.DarkLabel2.Size = new System.Drawing.Size(34, 13);
            this.DarkLabel2.TabIndex = 47;
            this.DarkLabel2.Text = "Face:";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.txtName.Location = new System.Drawing.Point(180, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(227, 20);
            this.txtName.TabIndex = 46;
            // 
            // DarkLabel1
            // 
            this.DarkLabel1.AutoSize = true;
            this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel1.Location = new System.Drawing.Point(108, 21);
            this.DarkLabel1.Name = "DarkLabel1";
            this.DarkLabel1.Size = new System.Drawing.Size(66, 13);
            this.DarkLabel1.TabIndex = 45;
            this.DarkLabel1.Text = "Shop Name:";
            // 
            // picFace
            // 
            this.picFace.BackColor = System.Drawing.Color.Black;
            this.picFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picFace.Location = new System.Drawing.Point(6, 19);
            this.picFace.Name = "picFace";
            this.picFace.Size = new System.Drawing.Size(96, 96);
            this.picFace.TabIndex = 44;
            this.picFace.TabStop = false;
            // 
            // frmShop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.ClientSize = new System.Drawing.Size(638, 408);
            this.ControlBox = false;
            this.Controls.Add(this.DarkGroupBox2);
            this.Controls.Add(this.DarkGroupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmShop";
            this.Text = "Shop Editor";
            this.DarkGroupBox1.ResumeLayout(false);
            this.DarkGroupBox2.ResumeLayout(false);
            this.DarkGroupBox2.PerformLayout();
            this.DarkGroupBox3.ResumeLayout(false);
            this.DarkGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudCostValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudItemValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudBuy).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudFace).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.picFace).EndInit();
            this.ResumeLayout(false);
        }

        public DarkUI.Controls.DarkGroupBox DarkGroupBox1;
        
        public ListBox lstIndex;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox2;
        
        public DarkUI.Controls.DarkTextBox txtName;
        
        public DarkUI.Controls.DarkLabel DarkLabel1;
        
        public PictureBox picFace;
        
        public DarkUI.Controls.DarkNumericUpDown nudFace;
        
        public DarkUI.Controls.DarkLabel DarkLabel2;
        
        public DarkUI.Controls.DarkLabel DarkLabel4;

        public DarkUI.Controls.DarkNumericUpDown nudBuy;

        public DarkUI.Controls.DarkLabel DarkLabel3;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox3;

        public ListBox lstTradeItem;

        public DarkUI.Controls.DarkComboBox cmbItem;

        public DarkUI.Controls.DarkLabel DarkLabel5;

        public DarkUI.Controls.DarkNumericUpDown nudItemValue;

        public DarkUI.Controls.DarkLabel DarkLabel6;

        public DarkUI.Controls.DarkLabel DarkLabel7;

        public DarkUI.Controls.DarkComboBox cmbCostItem;

        public DarkUI.Controls.DarkNumericUpDown nudCostValue;

        public DarkUI.Controls.DarkLabel DarkLabel8;

        public DarkUI.Controls.DarkButton btnUpdate;

        public DarkUI.Controls.DarkButton btnDeleteTrade;

        public DarkUI.Controls.DarkButton btnCancel;

        public DarkUI.Controls.DarkButton btnDelete;

        public DarkUI.Controls.DarkButton btnSave;
    }
}
