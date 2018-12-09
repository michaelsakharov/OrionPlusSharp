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
    partial class FrmQuest : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQuest));
            this.fraQuestList = new DarkUI.Controls.DarkGroupBox();
            this.lstIndex = new System.Windows.Forms.ListBox();
            this.DarkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
            this.DarkGroupBox5 = new DarkUI.Controls.DarkGroupBox();
            this.btnRemoveTask = new DarkUI.Controls.DarkButton();
            this.btnAddTask = new DarkUI.Controls.DarkButton();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.DarkGroupBox4 = new DarkUI.Controls.DarkGroupBox();
            this.lstRequirements = new System.Windows.Forms.ListBox();
            this.btnRemoveRequirement = new DarkUI.Controls.DarkButton();
            this.btnAddRequirement = new DarkUI.Controls.DarkButton();
            this.DarkGroupBox3 = new DarkUI.Controls.DarkGroupBox();
            this.nudItemRewValue = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel7 = new DarkUI.Controls.DarkLabel();
            this.cmbItemReward = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel6 = new DarkUI.Controls.DarkLabel();
            this.nudExpReward = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel5 = new DarkUI.Controls.DarkLabel();
            this.btnRemoveReward = new DarkUI.Controls.DarkButton();
            this.btnAddReward = new DarkUI.Controls.DarkButton();
            this.lstRewards = new System.Windows.Forms.ListBox();
            this.DarkLabel4 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel3 = new DarkUI.Controls.DarkLabel();
            this.txtEndText = new DarkUI.Controls.DarkTextBox();
            this.txtProgressText = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel2 = new DarkUI.Controls.DarkLabel();
            this.txtStartText = new DarkUI.Controls.DarkTextBox();
            this.chkQuestCancel = new DarkUI.Controls.DarkCheckBox();
            this.chkRepeat = new DarkUI.Controls.DarkCheckBox();
            this.txtName = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel1 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel8 = new DarkUI.Controls.DarkLabel();
            this.btnSave = new DarkUI.Controls.DarkButton();
            this.btnCancel = new DarkUI.Controls.DarkButton();
            this.fraTasks = new DarkUI.Controls.DarkGroupBox();
            this.btnCancelTask = new DarkUI.Controls.DarkButton();
            this.btnSaveTask = new DarkUI.Controls.DarkButton();
            this.Panel2 = new System.Windows.Forms.Panel();
            this.optTask7 = new DarkUI.Controls.DarkRadioButton();
            this.optTask6 = new DarkUI.Controls.DarkRadioButton();
            this.optTask5 = new DarkUI.Controls.DarkRadioButton();
            this.optTask4 = new DarkUI.Controls.DarkRadioButton();
            this.optTask3 = new DarkUI.Controls.DarkRadioButton();
            this.optTask2 = new DarkUI.Controls.DarkRadioButton();
            this.DarkLabel16 = new DarkUI.Controls.DarkLabel();
            this.optTask1 = new DarkUI.Controls.DarkRadioButton();
            this.optTask0 = new DarkUI.Controls.DarkRadioButton();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.cmbResource = new DarkUI.Controls.DarkComboBox();
            this.cmbMap = new DarkUI.Controls.DarkComboBox();
            this.cmbItem = new DarkUI.Controls.DarkComboBox();
            this.cmbNpc = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel17 = new DarkUI.Controls.DarkLabel();
            this.lblTaskNum = new DarkUI.Controls.DarkLabel();
            this.nudAmount = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel15 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel14 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel13 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel12 = new DarkUI.Controls.DarkLabel();
            this.DarkLabel11 = new DarkUI.Controls.DarkLabel();
            this.chkEnd = new DarkUI.Controls.DarkCheckBox();
            this.txtTaskSpeech = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel10 = new DarkUI.Controls.DarkLabel();
            this.txtTaskLog = new DarkUI.Controls.DarkTextBox();
            this.DarkLabel9 = new DarkUI.Controls.DarkLabel();
            this.fraRequirements = new DarkUI.Controls.DarkGroupBox();
            this.DarkGroupBox6 = new DarkUI.Controls.DarkGroupBox();
            this.btnRequirementCancel = new DarkUI.Controls.DarkButton();
            this.btnRequirementSave = new DarkUI.Controls.DarkButton();
            this.nudTakeAmount = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel23 = new DarkUI.Controls.DarkLabel();
            this.cmbEndItem = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel24 = new DarkUI.Controls.DarkLabel();
            this.nudGiveAmount = new DarkUI.Controls.DarkNumericUpDown();
            this.DarkLabel22 = new DarkUI.Controls.DarkLabel();
            this.cmbStartItem = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel21 = new DarkUI.Controls.DarkLabel();
            this.cmbClassReq = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel20 = new DarkUI.Controls.DarkLabel();
            this.rdbClassReq = new DarkUI.Controls.DarkRadioButton();
            this.cmbQuestReq = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel19 = new DarkUI.Controls.DarkLabel();
            this.rdbQuestReq = new DarkUI.Controls.DarkRadioButton();
            this.cmbItemReq = new DarkUI.Controls.DarkComboBox();
            this.DarkLabel18 = new DarkUI.Controls.DarkLabel();
            this.rdbItemReq = new DarkUI.Controls.DarkRadioButton();
            this.rdbNoneReq = new DarkUI.Controls.DarkRadioButton();
            this.fraQuestList.SuspendLayout();
            this.DarkGroupBox2.SuspendLayout();
            this.DarkGroupBox5.SuspendLayout();
            this.DarkGroupBox4.SuspendLayout();
            this.DarkGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudItemRewValue).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudExpReward).BeginInit();
            this.fraTasks.SuspendLayout();
            this.Panel2.SuspendLayout();
            this.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudAmount).BeginInit();
            this.fraRequirements.SuspendLayout();
            this.DarkGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudTakeAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)this.nudGiveAmount).BeginInit();
            this.SuspendLayout();
            // 
            // fraQuestList
            // 
            this.fraQuestList.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.fraQuestList.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.fraQuestList.Controls.Add(this.lstIndex);
            this.fraQuestList.ForeColor = System.Drawing.Color.Gainsboro;
            this.fraQuestList.Location = new System.Drawing.Point(3, 3);
            this.fraQuestList.Name = "fraQuestList";
            this.fraQuestList.Size = new System.Drawing.Size(212, 486);
            this.fraQuestList.TabIndex = 0;
            this.fraQuestList.TabStop = false;
            this.fraQuestList.Text = "Quest List";
            // 
            // lstIndex
            // 
            this.lstIndex.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.lstIndex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstIndex.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstIndex.FormattingEnabled = true;
            this.lstIndex.Location = new System.Drawing.Point(9, 19);
            this.lstIndex.Name = "lstIndex";
            this.lstIndex.Size = new System.Drawing.Size(194, 457);
            this.lstIndex.TabIndex = 1;
            // 
            // DarkGroupBox2
            // 
            this.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox5);
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox4);
            this.DarkGroupBox2.Controls.Add(this.DarkGroupBox3);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel4);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel3);
            this.DarkGroupBox2.Controls.Add(this.txtEndText);
            this.DarkGroupBox2.Controls.Add(this.txtProgressText);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel2);
            this.DarkGroupBox2.Controls.Add(this.txtStartText);
            this.DarkGroupBox2.Controls.Add(this.chkQuestCancel);
            this.DarkGroupBox2.Controls.Add(this.chkRepeat);
            this.DarkGroupBox2.Controls.Add(this.txtName);
            this.DarkGroupBox2.Controls.Add(this.DarkLabel1);
            this.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox2.Location = new System.Drawing.Point(221, 3);
            this.DarkGroupBox2.Name = "DarkGroupBox2";
            this.DarkGroupBox2.Size = new System.Drawing.Size(497, 458);
            this.DarkGroupBox2.TabIndex = 1;
            this.DarkGroupBox2.TabStop = false;
            this.DarkGroupBox2.Text = "General Settings";
            // 
            // DarkGroupBox5
            // 
            this.DarkGroupBox5.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox5.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox5.Controls.Add(this.btnRemoveTask);
            this.DarkGroupBox5.Controls.Add(this.btnAddTask);
            this.DarkGroupBox5.Controls.Add(this.lstTasks);
            this.DarkGroupBox5.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox5.Location = new System.Drawing.Point(249, 254);
            this.DarkGroupBox5.Name = "DarkGroupBox5";
            this.DarkGroupBox5.Size = new System.Drawing.Size(243, 199);
            this.DarkGroupBox5.TabIndex = 12;
            this.DarkGroupBox5.TabStop = false;
            this.DarkGroupBox5.Text = "Quest Tasks";
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.Location = new System.Drawing.Point(121, 170);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Padding = new System.Windows.Forms.Padding(5);
            this.btnRemoveTask.Size = new System.Drawing.Size(118, 23);
            this.btnRemoveTask.TabIndex = 5;
            this.btnRemoveTask.Text = "Remove Task";
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(4, 170);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddTask.Size = new System.Drawing.Size(111, 23);
            this.btnAddTask.TabIndex = 4;
            this.btnAddTask.Text = "Add Task";
            // 
            // lstTasks
            // 
            this.lstTasks.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.lstTasks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstTasks.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.Location = new System.Drawing.Point(6, 19);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(231, 145);
            this.lstTasks.TabIndex = 3;
            // 
            // DarkGroupBox4
            // 
            this.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox4.Controls.Add(this.lstRequirements);
            this.DarkGroupBox4.Controls.Add(this.btnRemoveRequirement);
            this.DarkGroupBox4.Controls.Add(this.btnAddRequirement);
            this.DarkGroupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
            this.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox4.Location = new System.Drawing.Point(0, 254);
            this.DarkGroupBox4.Name = "DarkGroupBox4";
            this.DarkGroupBox4.Size = new System.Drawing.Size(243, 199);
            this.DarkGroupBox4.TabIndex = 11;
            this.DarkGroupBox4.TabStop = false;
            this.DarkGroupBox4.Text = "Quest Requirements";
            // 
            // lstRequirements
            // 
            this.lstRequirements.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.lstRequirements.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRequirements.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstRequirements.FormattingEnabled = true;
            this.lstRequirements.Location = new System.Drawing.Point(6, 19);
            this.lstRequirements.Name = "lstRequirements";
            this.lstRequirements.Size = new System.Drawing.Size(231, 145);
            this.lstRequirements.TabIndex = 2;
            // 
            // btnRemoveRequirement
            // 
            this.btnRemoveRequirement.Location = new System.Drawing.Point(110, 170);
            this.btnRemoveRequirement.Name = "btnRemoveRequirement";
            this.btnRemoveRequirement.Padding = new System.Windows.Forms.Padding(5);
            this.btnRemoveRequirement.Size = new System.Drawing.Size(129, 23);
            this.btnRemoveRequirement.TabIndex = 1;
            this.btnRemoveRequirement.Text = "Remove Requirement";
            // 
            // btnAddRequirement
            // 
            this.btnAddRequirement.Location = new System.Drawing.Point(4, 170);
            this.btnAddRequirement.Name = "btnAddRequirement";
            this.btnAddRequirement.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddRequirement.Size = new System.Drawing.Size(102, 23);
            this.btnAddRequirement.TabIndex = 0;
            this.btnAddRequirement.Text = "Add Requirement";
            // 
            // DarkGroupBox3
            // 
            this.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox3.Controls.Add(this.nudItemRewValue);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel7);
            this.DarkGroupBox3.Controls.Add(this.cmbItemReward);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel6);
            this.DarkGroupBox3.Controls.Add(this.nudExpReward);
            this.DarkGroupBox3.Controls.Add(this.DarkLabel5);
            this.DarkGroupBox3.Controls.Add(this.btnRemoveReward);
            this.DarkGroupBox3.Controls.Add(this.btnAddReward);
            this.DarkGroupBox3.Controls.Add(this.lstRewards);
            this.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox3.Location = new System.Drawing.Point(6, 143);
            this.DarkGroupBox3.Name = "DarkGroupBox3";
            this.DarkGroupBox3.Size = new System.Drawing.Size(485, 105);
            this.DarkGroupBox3.TabIndex = 10;
            this.DarkGroupBox3.TabStop = false;
            this.DarkGroupBox3.Text = "Rewards";
            // 
            // nudItemRewValue
            // 
            this.nudItemRewValue.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudItemRewValue.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudItemRewValue.Location = new System.Drawing.Point(380, 79);
            this.nudItemRewValue.Name = "nudItemRewValue";
            this.nudItemRewValue.Size = new System.Drawing.Size(99, 20);
            this.nudItemRewValue.TabIndex = 8;
            this.nudItemRewValue.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // DarkLabel7
            // 
            this.DarkLabel7.AutoSize = true;
            this.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel7.Location = new System.Drawing.Point(328, 81);
            this.DarkLabel7.Name = "DarkLabel7";
            this.DarkLabel7.Size = new System.Drawing.Size(46, 13);
            this.DarkLabel7.TabIndex = 7;
            this.DarkLabel7.Text = "Amount:";
            // 
            // cmbItemReward
            // 
            this.cmbItemReward.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbItemReward.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbItemReward.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbItemReward.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbItemReward.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbItemReward.ButtonIcon");
            this.cmbItemReward.DrawDropdownHoverOutline = false;
            this.cmbItemReward.DrawFocusRectangle = false;
            this.cmbItemReward.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbItemReward.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemReward.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbItemReward.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbItemReward.FormattingEnabled = true;
            this.cmbItemReward.Location = new System.Drawing.Point(364, 52);
            this.cmbItemReward.Name = "cmbItemReward";
            this.cmbItemReward.Size = new System.Drawing.Size(115, 21);
            this.cmbItemReward.TabIndex = 6;
            this.cmbItemReward.Text = null;
            this.cmbItemReward.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel6
            // 
            this.DarkLabel6.AutoSize = true;
            this.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel6.Location = new System.Drawing.Point(328, 55);
            this.DarkLabel6.Name = "DarkLabel6";
            this.DarkLabel6.Size = new System.Drawing.Size(30, 13);
            this.DarkLabel6.TabIndex = 5;
            this.DarkLabel6.Text = "Item:";
            // 
            // nudExpReward
            // 
            this.nudExpReward.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudExpReward.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudExpReward.Location = new System.Drawing.Point(399, 22);
            this.nudExpReward.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            this.nudExpReward.Name = "nudExpReward";
            this.nudExpReward.Size = new System.Drawing.Size(80, 20);
            this.nudExpReward.TabIndex = 4;
            this.nudExpReward.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // DarkLabel5
            // 
            this.DarkLabel5.AutoSize = true;
            this.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel5.Location = new System.Drawing.Point(328, 24);
            this.DarkLabel5.Name = "DarkLabel5";
            this.DarkLabel5.Size = new System.Drawing.Size(65, 13);
            this.DarkLabel5.TabIndex = 3;
            this.DarkLabel5.Text = "Exp Gained:";
            // 
            // btnRemoveReward
            // 
            this.btnRemoveReward.Location = new System.Drawing.Point(247, 76);
            this.btnRemoveReward.Name = "btnRemoveReward";
            this.btnRemoveReward.Padding = new System.Windows.Forms.Padding(5);
            this.btnRemoveReward.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveReward.TabIndex = 2;
            this.btnRemoveReward.Text = "Remove";
            // 
            // btnAddReward
            // 
            this.btnAddReward.Location = new System.Drawing.Point(247, 19);
            this.btnAddReward.Name = "btnAddReward";
            this.btnAddReward.Padding = new System.Windows.Forms.Padding(5);
            this.btnAddReward.Size = new System.Drawing.Size(75, 23);
            this.btnAddReward.TabIndex = 1;
            this.btnAddReward.Text = "Add";
            // 
            // lstRewards
            // 
            this.lstRewards.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.lstRewards.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstRewards.ForeColor = System.Drawing.Color.Gainsboro;
            this.lstRewards.FormattingEnabled = true;
            this.lstRewards.Location = new System.Drawing.Point(6, 19);
            this.lstRewards.Name = "lstRewards";
            this.lstRewards.Size = new System.Drawing.Size(235, 80);
            this.lstRewards.TabIndex = 0;
            // 
            // DarkLabel4
            // 
            this.DarkLabel4.AutoSize = true;
            this.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel4.Location = new System.Drawing.Point(323, 56);
            this.DarkLabel4.Name = "DarkLabel4";
            this.DarkLabel4.Size = new System.Drawing.Size(50, 13);
            this.DarkLabel4.TabIndex = 9;
            this.DarkLabel4.Text = "End Text";
            // 
            // DarkLabel3
            // 
            this.DarkLabel3.AutoSize = true;
            this.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel3.Location = new System.Drawing.Point(163, 56);
            this.DarkLabel3.Name = "DarkLabel3";
            this.DarkLabel3.Size = new System.Drawing.Size(84, 13);
            this.DarkLabel3.TabIndex = 8;
            this.DarkLabel3.Text = "In Progress Text";
            // 
            // txtEndText
            // 
            this.txtEndText.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.txtEndText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEndText.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.txtEndText.Location = new System.Drawing.Point(326, 72);
            this.txtEndText.Multiline = true;
            this.txtEndText.Name = "txtEndText";
            this.txtEndText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtEndText.Size = new System.Drawing.Size(154, 65);
            this.txtEndText.TabIndex = 7;
            // 
            // txtProgressText
            // 
            this.txtProgressText.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.txtProgressText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProgressText.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.txtProgressText.Location = new System.Drawing.Point(166, 72);
            this.txtProgressText.Multiline = true;
            this.txtProgressText.Name = "txtProgressText";
            this.txtProgressText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProgressText.Size = new System.Drawing.Size(154, 65);
            this.txtProgressText.TabIndex = 6;
            // 
            // DarkLabel2
            // 
            this.DarkLabel2.AutoSize = true;
            this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel2.Location = new System.Drawing.Point(6, 56);
            this.DarkLabel2.Name = "DarkLabel2";
            this.DarkLabel2.Size = new System.Drawing.Size(53, 13);
            this.DarkLabel2.TabIndex = 5;
            this.DarkLabel2.Text = "Start Text";
            // 
            // txtStartText
            // 
            this.txtStartText.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.txtStartText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtStartText.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.txtStartText.Location = new System.Drawing.Point(6, 72);
            this.txtStartText.Multiline = true;
            this.txtStartText.Name = "txtStartText";
            this.txtStartText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStartText.Size = new System.Drawing.Size(154, 65);
            this.txtStartText.TabIndex = 4;
            // 
            // chkQuestCancel
            // 
            this.chkQuestCancel.AutoSize = true;
            this.chkQuestCancel.Location = new System.Drawing.Point(372, 20);
            this.chkQuestCancel.Name = "chkQuestCancel";
            this.chkQuestCancel.Size = new System.Drawing.Size(90, 17);
            this.chkQuestCancel.TabIndex = 3;
            this.chkQuestCancel.Text = "Cancel Quest";
            // 
            // chkRepeat
            // 
            this.chkRepeat.AutoSize = true;
            this.chkRepeat.Location = new System.Drawing.Point(279, 20);
            this.chkRepeat.Name = "chkRepeat";
            this.chkRepeat.Size = new System.Drawing.Size(87, 17);
            this.chkRepeat.TabIndex = 2;
            this.chkRepeat.Text = "Repeatable?";
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.txtName.Location = new System.Drawing.Point(81, 19);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(192, 20);
            this.txtName.TabIndex = 1;
            // 
            // DarkLabel1
            // 
            this.DarkLabel1.AutoSize = true;
            this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel1.Location = new System.Drawing.Point(6, 21);
            this.DarkLabel1.Name = "DarkLabel1";
            this.DarkLabel1.Size = new System.Drawing.Size(69, 13);
            this.DarkLabel1.TabIndex = 0;
            this.DarkLabel1.Text = "Quest Name:";
            // 
            // DarkLabel8
            // 
            this.DarkLabel8.AutoSize = true;
            this.DarkLabel8.ForeColor = System.Drawing.Color.Red;
            this.DarkLabel8.Location = new System.Drawing.Point(221, 464);
            this.DarkLabel8.Name = "DarkLabel8";
            this.DarkLabel8.Size = new System.Drawing.Size(218, 13);
            this.DarkLabel8.TabIndex = 2;
            this.DarkLabel8.Text = "Use /questreset # to reset a quest for testing";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(553, 467);
            this.btnSave.Name = "btnSave";
            this.btnSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(634, 467);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            // 
            // fraTasks
            // 
            this.fraTasks.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.fraTasks.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.fraTasks.Controls.Add(this.btnCancelTask);
            this.fraTasks.Controls.Add(this.btnSaveTask);
            this.fraTasks.Controls.Add(this.Panel2);
            this.fraTasks.Controls.Add(this.Panel1);
            this.fraTasks.ForeColor = System.Drawing.Color.Gainsboro;
            this.fraTasks.Location = new System.Drawing.Point(724, 3);
            this.fraTasks.Name = "fraTasks";
            this.fraTasks.Size = new System.Drawing.Size(719, 497);
            this.fraTasks.TabIndex = 5;
            this.fraTasks.TabStop = false;
            this.fraTasks.Text = "Tasks";
            // 
            // btnCancelTask
            // 
            this.btnCancelTask.Location = new System.Drawing.Point(139, 345);
            this.btnCancelTask.Name = "btnCancelTask";
            this.btnCancelTask.Padding = new System.Windows.Forms.Padding(5);
            this.btnCancelTask.Size = new System.Drawing.Size(112, 23);
            this.btnCancelTask.TabIndex = 3;
            this.btnCancelTask.Text = "Cancel Task";
            // 
            // btnSaveTask
            // 
            this.btnSaveTask.Location = new System.Drawing.Point(6, 345);
            this.btnSaveTask.Name = "btnSaveTask";
            this.btnSaveTask.Padding = new System.Windows.Forms.Padding(5);
            this.btnSaveTask.Size = new System.Drawing.Size(110, 23);
            this.btnSaveTask.TabIndex = 2;
            this.btnSaveTask.Text = "Save Task";
            // 
            // Panel2
            // 
            this.Panel2.Controls.Add(this.optTask7);
            this.Panel2.Controls.Add(this.optTask6);
            this.Panel2.Controls.Add(this.optTask5);
            this.Panel2.Controls.Add(this.optTask4);
            this.Panel2.Controls.Add(this.optTask3);
            this.Panel2.Controls.Add(this.optTask2);
            this.Panel2.Controls.Add(this.DarkLabel16);
            this.Panel2.Controls.Add(this.optTask1);
            this.Panel2.Controls.Add(this.optTask0);
            this.Panel2.Location = new System.Drawing.Point(257, 19);
            this.Panel2.Name = "Panel2";
            this.Panel2.Size = new System.Drawing.Size(154, 197);
            this.Panel2.TabIndex = 1;
            // 
            // optTask7
            // 
            this.optTask7.AutoSize = true;
            this.optTask7.Location = new System.Drawing.Point(6, 175);
            this.optTask7.Name = "optTask7";
            this.optTask7.Size = new System.Drawing.Size(111, 17);
            this.optTask7.TabIndex = 8;
            this.optTask7.TabStop = true;
            this.optTask7.Text = "Get Item from Npc";
            // 
            // optTask6
            // 
            this.optTask6.AutoSize = true;
            this.optTask6.Location = new System.Drawing.Point(6, 152);
            this.optTask6.Name = "optTask6";
            this.optTask6.Size = new System.Drawing.Size(111, 17);
            this.optTask6.TabIndex = 7;
            this.optTask6.TabStop = true;
            this.optTask6.Text = "Gather Resources";
            // 
            // optTask5
            // 
            this.optTask5.AutoSize = true;
            this.optTask5.Location = new System.Drawing.Point(6, 129);
            this.optTask5.Name = "optTask5";
            this.optTask5.Size = new System.Drawing.Size(105, 17);
            this.optTask5.TabIndex = 6;
            this.optTask5.TabStop = true;
            this.optTask5.Text = "Give Item to Npc";
            // 
            // optTask4
            // 
            this.optTask4.AutoSize = true;
            this.optTask4.Location = new System.Drawing.Point(6, 106);
            this.optTask4.Name = "optTask4";
            this.optTask4.Size = new System.Drawing.Size(81, 17);
            this.optTask4.TabIndex = 5;
            this.optTask4.TabStop = true;
            this.optTask4.Text = "Reach Map";
            // 
            // optTask3
            // 
            this.optTask3.AutoSize = true;
            this.optTask3.Location = new System.Drawing.Point(6, 83);
            this.optTask3.Name = "optTask3";
            this.optTask3.Size = new System.Drawing.Size(85, 17);
            this.optTask3.TabIndex = 4;
            this.optTask3.TabStop = true;
            this.optTask3.Text = "Talk To Npc";
            // 
            // optTask2
            // 
            this.optTask2.AutoSize = true;
            this.optTask2.Location = new System.Drawing.Point(6, 60);
            this.optTask2.Name = "optTask2";
            this.optTask2.Size = new System.Drawing.Size(85, 17);
            this.optTask2.TabIndex = 3;
            this.optTask2.TabStop = true;
            this.optTask2.Text = "Gather Items";
            // 
            // DarkLabel16
            // 
            this.DarkLabel16.AutoSize = true;
            this.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel16.Location = new System.Drawing.Point(3, 25);
            this.DarkLabel16.Name = "DarkLabel16";
            this.DarkLabel16.Size = new System.Drawing.Size(145, 13);
            this.DarkLabel16.TabIndex = 2;
            this.DarkLabel16.Text = "----------------------------------------------";
            // 
            // optTask1
            // 
            this.optTask1.AutoSize = true;
            this.optTask1.Location = new System.Drawing.Point(6, 37);
            this.optTask1.Name = "optTask1";
            this.optTask1.Size = new System.Drawing.Size(87, 17);
            this.optTask1.TabIndex = 1;
            this.optTask1.TabStop = true;
            this.optTask1.Text = "Defeat Npc's";
            // 
            // optTask0
            // 
            this.optTask0.AutoSize = true;
            this.optTask0.Location = new System.Drawing.Point(6, 5);
            this.optTask0.Name = "optTask0";
            this.optTask0.Size = new System.Drawing.Size(62, 17);
            this.optTask0.TabIndex = 0;
            this.optTask0.TabStop = true;
            this.optTask0.Text = "Nothing";
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.cmbResource);
            this.Panel1.Controls.Add(this.cmbMap);
            this.Panel1.Controls.Add(this.cmbItem);
            this.Panel1.Controls.Add(this.cmbNpc);
            this.Panel1.Controls.Add(this.DarkLabel17);
            this.Panel1.Controls.Add(this.lblTaskNum);
            this.Panel1.Controls.Add(this.nudAmount);
            this.Panel1.Controls.Add(this.DarkLabel15);
            this.Panel1.Controls.Add(this.DarkLabel14);
            this.Panel1.Controls.Add(this.DarkLabel13);
            this.Panel1.Controls.Add(this.DarkLabel12);
            this.Panel1.Controls.Add(this.DarkLabel11);
            this.Panel1.Controls.Add(this.chkEnd);
            this.Panel1.Controls.Add(this.txtTaskSpeech);
            this.Panel1.Controls.Add(this.DarkLabel10);
            this.Panel1.Controls.Add(this.txtTaskLog);
            this.Panel1.Controls.Add(this.DarkLabel9);
            this.Panel1.Location = new System.Drawing.Point(6, 19);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(245, 320);
            this.Panel1.TabIndex = 0;
            // 
            // cmbResource
            // 
            this.cmbResource.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbResource.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbResource.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbResource.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbResource.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbResource.ButtonIcon");
            this.cmbResource.DrawDropdownHoverOutline = false;
            this.cmbResource.DrawFocusRectangle = false;
            this.cmbResource.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbResource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbResource.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbResource.FormattingEnabled = true;
            this.cmbResource.Location = new System.Drawing.Point(62, 199);
            this.cmbResource.Name = "cmbResource";
            this.cmbResource.Size = new System.Drawing.Size(121, 21);
            this.cmbResource.TabIndex = 20;
            this.cmbResource.Text = null;
            this.cmbResource.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbMap
            // 
            this.cmbMap.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbMap.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbMap.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbMap.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbMap.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbMap.ButtonIcon");
            this.cmbMap.DrawDropdownHoverOutline = false;
            this.cmbMap.DrawFocusRectangle = false;
            this.cmbMap.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbMap.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbMap.FormattingEnabled = true;
            this.cmbMap.Location = new System.Drawing.Point(62, 173);
            this.cmbMap.Name = "cmbMap";
            this.cmbMap.Size = new System.Drawing.Size(121, 21);
            this.cmbMap.TabIndex = 19;
            this.cmbMap.Text = null;
            this.cmbMap.TextPadding = new System.Windows.Forms.Padding(2);
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
            this.cmbItem.Location = new System.Drawing.Point(62, 147);
            this.cmbItem.Name = "cmbItem";
            this.cmbItem.Size = new System.Drawing.Size(121, 21);
            this.cmbItem.TabIndex = 18;
            this.cmbItem.Text = null;
            this.cmbItem.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // cmbNpc
            // 
            this.cmbNpc.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbNpc.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbNpc.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbNpc.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbNpc.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbNpc.ButtonIcon");
            this.cmbNpc.DrawDropdownHoverOutline = false;
            this.cmbNpc.DrawFocusRectangle = false;
            this.cmbNpc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbNpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNpc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbNpc.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbNpc.FormattingEnabled = true;
            this.cmbNpc.Location = new System.Drawing.Point(62, 121);
            this.cmbNpc.Name = "cmbNpc";
            this.cmbNpc.Size = new System.Drawing.Size(121, 21);
            this.cmbNpc.TabIndex = 17;
            this.cmbNpc.Text = null;
            this.cmbNpc.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel17
            // 
            this.DarkLabel17.AutoSize = true;
            this.DarkLabel17.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel17.Location = new System.Drawing.Point(7, 223);
            this.DarkLabel17.Name = "DarkLabel17";
            this.DarkLabel17.Size = new System.Drawing.Size(232, 13);
            this.DarkLabel17.TabIndex = 16;
            this.DarkLabel17.Text = "---------------------------------------------------------------------------";
            // 
            // lblTaskNum
            // 
            this.lblTaskNum.AutoSize = true;
            this.lblTaskNum.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.lblTaskNum.Location = new System.Drawing.Point(3, 297);
            this.lblTaskNum.Name = "lblTaskNum";
            this.lblTaskNum.Size = new System.Drawing.Size(74, 13);
            this.lblTaskNum.TabIndex = 15;
            this.lblTaskNum.Text = "Task Number:";
            // 
            // nudAmount
            // 
            this.nudAmount.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudAmount.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudAmount.Location = new System.Drawing.Point(63, 239);
            this.nudAmount.Name = "nudAmount";
            this.nudAmount.Size = new System.Drawing.Size(120, 20);
            this.nudAmount.TabIndex = 14;
            this.nudAmount.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // DarkLabel15
            // 
            this.DarkLabel15.AutoSize = true;
            this.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel15.Location = new System.Drawing.Point(3, 241);
            this.DarkLabel15.Name = "DarkLabel15";
            this.DarkLabel15.Size = new System.Drawing.Size(46, 13);
            this.DarkLabel15.TabIndex = 13;
            this.DarkLabel15.Text = "Amount:";
            // 
            // DarkLabel14
            // 
            this.DarkLabel14.AutoSize = true;
            this.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel14.Location = new System.Drawing.Point(3, 202);
            this.DarkLabel14.Name = "DarkLabel14";
            this.DarkLabel14.Size = new System.Drawing.Size(56, 13);
            this.DarkLabel14.TabIndex = 11;
            this.DarkLabel14.Text = "Resource:";
            // 
            // DarkLabel13
            // 
            this.DarkLabel13.AutoSize = true;
            this.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel13.Location = new System.Drawing.Point(3, 176);
            this.DarkLabel13.Name = "DarkLabel13";
            this.DarkLabel13.Size = new System.Drawing.Size(31, 13);
            this.DarkLabel13.TabIndex = 9;
            this.DarkLabel13.Text = "Map:";
            // 
            // DarkLabel12
            // 
            this.DarkLabel12.AutoSize = true;
            this.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel12.Location = new System.Drawing.Point(3, 150);
            this.DarkLabel12.Name = "DarkLabel12";
            this.DarkLabel12.Size = new System.Drawing.Size(30, 13);
            this.DarkLabel12.TabIndex = 7;
            this.DarkLabel12.Text = "Item:";
            // 
            // DarkLabel11
            // 
            this.DarkLabel11.AutoSize = true;
            this.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel11.Location = new System.Drawing.Point(3, 124);
            this.DarkLabel11.Name = "DarkLabel11";
            this.DarkLabel11.Size = new System.Drawing.Size(30, 13);
            this.DarkLabel11.TabIndex = 5;
            this.DarkLabel11.Text = "Npc:";
            // 
            // chkEnd
            // 
            this.chkEnd.AutoSize = true;
            this.chkEnd.ForeColor = System.Drawing.Color.Lime;
            this.chkEnd.Location = new System.Drawing.Point(3, 86);
            this.chkEnd.Name = "chkEnd";
            this.chkEnd.Size = new System.Drawing.Size(107, 17);
            this.chkEnd.TabIndex = 4;
            this.chkEnd.Text = "End Quest Now?";
            // 
            // txtTaskSpeech
            // 
            this.txtTaskSpeech.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.txtTaskSpeech.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaskSpeech.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.txtTaskSpeech.Location = new System.Drawing.Point(3, 60);
            this.txtTaskSpeech.Name = "txtTaskSpeech";
            this.txtTaskSpeech.Size = new System.Drawing.Size(236, 20);
            this.txtTaskSpeech.TabIndex = 3;
            // 
            // DarkLabel10
            // 
            this.DarkLabel10.AutoSize = true;
            this.DarkLabel10.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel10.Location = new System.Drawing.Point(3, 44);
            this.DarkLabel10.Name = "DarkLabel10";
            this.DarkLabel10.Size = new System.Drawing.Size(71, 13);
            this.DarkLabel10.TabIndex = 2;
            this.DarkLabel10.Text = "Task Speech";
            // 
            // txtTaskLog
            // 
            this.txtTaskLog.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.txtTaskLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTaskLog.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.txtTaskLog.Location = new System.Drawing.Point(3, 21);
            this.txtTaskLog.Name = "txtTaskLog";
            this.txtTaskLog.Size = new System.Drawing.Size(236, 20);
            this.txtTaskLog.TabIndex = 1;
            // 
            // DarkLabel9
            // 
            this.DarkLabel9.AutoSize = true;
            this.DarkLabel9.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel9.Location = new System.Drawing.Point(3, 5);
            this.DarkLabel9.Name = "DarkLabel9";
            this.DarkLabel9.Size = new System.Drawing.Size(52, 13);
            this.DarkLabel9.TabIndex = 0;
            this.DarkLabel9.Text = "Task Log";
            // 
            // fraRequirements
            // 
            this.fraRequirements.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.fraRequirements.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.fraRequirements.Controls.Add(this.DarkGroupBox6);
            this.fraRequirements.Controls.Add(this.cmbClassReq);
            this.fraRequirements.Controls.Add(this.DarkLabel20);
            this.fraRequirements.Controls.Add(this.rdbClassReq);
            this.fraRequirements.Controls.Add(this.cmbQuestReq);
            this.fraRequirements.Controls.Add(this.DarkLabel19);
            this.fraRequirements.Controls.Add(this.rdbQuestReq);
            this.fraRequirements.Controls.Add(this.cmbItemReq);
            this.fraRequirements.Controls.Add(this.DarkLabel18);
            this.fraRequirements.Controls.Add(this.rdbItemReq);
            this.fraRequirements.Controls.Add(this.rdbNoneReq);
            this.fraRequirements.ForeColor = System.Drawing.Color.Gainsboro;
            this.fraRequirements.Location = new System.Drawing.Point(724, 3);
            this.fraRequirements.Name = "fraRequirements";
            this.fraRequirements.Size = new System.Drawing.Size(719, 497);
            this.fraRequirements.TabIndex = 6;
            this.fraRequirements.TabStop = false;
            this.fraRequirements.Text = "Requirements";
            this.fraRequirements.Visible = false;
            // 
            // DarkGroupBox6
            // 
            this.DarkGroupBox6.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.DarkGroupBox6.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.DarkGroupBox6.Controls.Add(this.btnRequirementCancel);
            this.DarkGroupBox6.Controls.Add(this.btnRequirementSave);
            this.DarkGroupBox6.Controls.Add(this.nudTakeAmount);
            this.DarkGroupBox6.Controls.Add(this.DarkLabel23);
            this.DarkGroupBox6.Controls.Add(this.cmbEndItem);
            this.DarkGroupBox6.Controls.Add(this.DarkLabel24);
            this.DarkGroupBox6.Controls.Add(this.nudGiveAmount);
            this.DarkGroupBox6.Controls.Add(this.DarkLabel22);
            this.DarkGroupBox6.Controls.Add(this.cmbStartItem);
            this.DarkGroupBox6.Controls.Add(this.DarkLabel21);
            this.DarkGroupBox6.ForeColor = System.Drawing.Color.Gainsboro;
            this.DarkGroupBox6.Location = new System.Drawing.Point(6, 159);
            this.DarkGroupBox6.Name = "DarkGroupBox6";
            this.DarkGroupBox6.Size = new System.Drawing.Size(338, 288);
            this.DarkGroupBox6.TabIndex = 10;
            this.DarkGroupBox6.TabStop = false;
            this.DarkGroupBox6.Text = "Items Needed For Quest";
            // 
            // btnRequirementCancel
            // 
            this.btnRequirementCancel.Location = new System.Drawing.Point(257, 259);
            this.btnRequirementCancel.Name = "btnRequirementCancel";
            this.btnRequirementCancel.Padding = new System.Windows.Forms.Padding(5);
            this.btnRequirementCancel.Size = new System.Drawing.Size(75, 23);
            this.btnRequirementCancel.TabIndex = 9;
            this.btnRequirementCancel.Text = "Cancel";
            // 
            // btnRequirementSave
            // 
            this.btnRequirementSave.Location = new System.Drawing.Point(176, 259);
            this.btnRequirementSave.Name = "btnRequirementSave";
            this.btnRequirementSave.Padding = new System.Windows.Forms.Padding(5);
            this.btnRequirementSave.Size = new System.Drawing.Size(75, 23);
            this.btnRequirementSave.TabIndex = 8;
            this.btnRequirementSave.Text = "Save";
            // 
            // nudTakeAmount
            // 
            this.nudTakeAmount.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudTakeAmount.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudTakeAmount.Location = new System.Drawing.Point(262, 73);
            this.nudTakeAmount.Name = "nudTakeAmount";
            this.nudTakeAmount.Size = new System.Drawing.Size(70, 20);
            this.nudTakeAmount.TabIndex = 7;
            this.nudTakeAmount.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // DarkLabel23
            // 
            this.DarkLabel23.AutoSize = true;
            this.DarkLabel23.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel23.Location = new System.Drawing.Point(210, 75);
            this.DarkLabel23.Name = "DarkLabel23";
            this.DarkLabel23.Size = new System.Drawing.Size(46, 13);
            this.DarkLabel23.TabIndex = 6;
            this.DarkLabel23.Text = "Amount:";
            // 
            // cmbEndItem
            // 
            this.cmbEndItem.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbEndItem.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbEndItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbEndItem.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbEndItem.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbEndItem.ButtonIcon");
            this.cmbEndItem.DrawDropdownHoverOutline = false;
            this.cmbEndItem.DrawFocusRectangle = false;
            this.cmbEndItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbEndItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEndItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEndItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbEndItem.FormattingEnabled = true;
            this.cmbEndItem.Location = new System.Drawing.Point(67, 72);
            this.cmbEndItem.Name = "cmbEndItem";
            this.cmbEndItem.Size = new System.Drawing.Size(137, 21);
            this.cmbEndItem.TabIndex = 5;
            this.cmbEndItem.Text = null;
            this.cmbEndItem.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel24
            // 
            this.DarkLabel24.AutoSize = true;
            this.DarkLabel24.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel24.Location = new System.Drawing.Point(6, 75);
            this.DarkLabel24.Name = "DarkLabel24";
            this.DarkLabel24.Size = new System.Drawing.Size(58, 13);
            this.DarkLabel24.TabIndex = 4;
            this.DarkLabel24.Text = "Take Item:";
            // 
            // nudGiveAmount
            // 
            this.nudGiveAmount.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.nudGiveAmount.ForeColor = System.Drawing.Color.Gainsboro;
            this.nudGiveAmount.Location = new System.Drawing.Point(262, 29);
            this.nudGiveAmount.Name = "nudGiveAmount";
            this.nudGiveAmount.Size = new System.Drawing.Size(70, 20);
            this.nudGiveAmount.TabIndex = 3;
            this.nudGiveAmount.Value = new decimal(new int[] { 0, 0, 0, 0 });
            // 
            // DarkLabel22
            // 
            this.DarkLabel22.AutoSize = true;
            this.DarkLabel22.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel22.Location = new System.Drawing.Point(210, 31);
            this.DarkLabel22.Name = "DarkLabel22";
            this.DarkLabel22.Size = new System.Drawing.Size(46, 13);
            this.DarkLabel22.TabIndex = 2;
            this.DarkLabel22.Text = "Amount:";
            // 
            // cmbStartItem
            // 
            this.cmbStartItem.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbStartItem.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbStartItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbStartItem.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbStartItem.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbStartItem.ButtonIcon");
            this.cmbStartItem.DrawDropdownHoverOutline = false;
            this.cmbStartItem.DrawFocusRectangle = false;
            this.cmbStartItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbStartItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStartItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbStartItem.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbStartItem.FormattingEnabled = true;
            this.cmbStartItem.Location = new System.Drawing.Point(67, 28);
            this.cmbStartItem.Name = "cmbStartItem";
            this.cmbStartItem.Size = new System.Drawing.Size(137, 21);
            this.cmbStartItem.TabIndex = 1;
            this.cmbStartItem.Text = null;
            this.cmbStartItem.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel21
            // 
            this.DarkLabel21.AutoSize = true;
            this.DarkLabel21.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel21.Location = new System.Drawing.Point(6, 31);
            this.DarkLabel21.Name = "DarkLabel21";
            this.DarkLabel21.Size = new System.Drawing.Size(55, 13);
            this.DarkLabel21.TabIndex = 0;
            this.DarkLabel21.Text = "Give Item:";
            // 
            // cmbClassReq
            // 
            this.cmbClassReq.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbClassReq.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbClassReq.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbClassReq.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbClassReq.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbClassReq.ButtonIcon");
            this.cmbClassReq.DrawDropdownHoverOutline = false;
            this.cmbClassReq.DrawFocusRectangle = false;
            this.cmbClassReq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbClassReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClassReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbClassReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbClassReq.FormattingEnabled = true;
            this.cmbClassReq.Location = new System.Drawing.Point(185, 127);
            this.cmbClassReq.Name = "cmbClassReq";
            this.cmbClassReq.Size = new System.Drawing.Size(159, 21);
            this.cmbClassReq.TabIndex = 9;
            this.cmbClassReq.Text = null;
            this.cmbClassReq.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel20
            // 
            this.DarkLabel20.AutoSize = true;
            this.DarkLabel20.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel20.Location = new System.Drawing.Point(80, 130);
            this.DarkLabel20.Name = "DarkLabel20";
            this.DarkLabel20.Size = new System.Drawing.Size(98, 13);
            this.DarkLabel20.TabIndex = 8;
            this.DarkLabel20.Text = "Class Requirement:";
            // 
            // rdbClassReq
            // 
            this.rdbClassReq.AutoSize = true;
            this.rdbClassReq.Location = new System.Drawing.Point(10, 128);
            this.rdbClassReq.Name = "rdbClassReq";
            this.rdbClassReq.Size = new System.Drawing.Size(50, 17);
            this.rdbClassReq.TabIndex = 7;
            this.rdbClassReq.TabStop = true;
            this.rdbClassReq.Text = "Class";
            // 
            // cmbQuestReq
            // 
            this.cmbQuestReq.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbQuestReq.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbQuestReq.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbQuestReq.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbQuestReq.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbQuestReq.ButtonIcon");
            this.cmbQuestReq.DrawDropdownHoverOutline = false;
            this.cmbQuestReq.DrawFocusRectangle = false;
            this.cmbQuestReq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbQuestReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbQuestReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbQuestReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbQuestReq.FormattingEnabled = true;
            this.cmbQuestReq.Location = new System.Drawing.Point(185, 91);
            this.cmbQuestReq.Name = "cmbQuestReq";
            this.cmbQuestReq.Size = new System.Drawing.Size(159, 21);
            this.cmbQuestReq.TabIndex = 6;
            this.cmbQuestReq.Text = null;
            this.cmbQuestReq.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel19
            // 
            this.DarkLabel19.AutoSize = true;
            this.DarkLabel19.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel19.Location = new System.Drawing.Point(80, 94);
            this.DarkLabel19.Name = "DarkLabel19";
            this.DarkLabel19.Size = new System.Drawing.Size(101, 13);
            this.DarkLabel19.TabIndex = 5;
            this.DarkLabel19.Text = "Quest Requirement:";
            // 
            // rdbQuestReq
            // 
            this.rdbQuestReq.AutoSize = true;
            this.rdbQuestReq.Location = new System.Drawing.Point(10, 92);
            this.rdbQuestReq.Name = "rdbQuestReq";
            this.rdbQuestReq.Size = new System.Drawing.Size(53, 17);
            this.rdbQuestReq.TabIndex = 4;
            this.rdbQuestReq.TabStop = true;
            this.rdbQuestReq.Text = "Quest";
            // 
            // cmbItemReq
            // 
            this.cmbItemReq.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
            this.cmbItemReq.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
            this.cmbItemReq.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
            this.cmbItemReq.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
            this.cmbItemReq.ButtonIcon = (System.Drawing.Bitmap)resources.GetObject("cmbItemReq.ButtonIcon");
            this.cmbItemReq.DrawDropdownHoverOutline = false;
            this.cmbItemReq.DrawFocusRectangle = false;
            this.cmbItemReq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cmbItemReq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbItemReq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbItemReq.ForeColor = System.Drawing.Color.Gainsboro;
            this.cmbItemReq.FormattingEnabled = true;
            this.cmbItemReq.Location = new System.Drawing.Point(185, 55);
            this.cmbItemReq.Name = "cmbItemReq";
            this.cmbItemReq.Size = new System.Drawing.Size(159, 21);
            this.cmbItemReq.TabIndex = 3;
            this.cmbItemReq.Text = null;
            this.cmbItemReq.TextPadding = new System.Windows.Forms.Padding(2);
            // 
            // DarkLabel18
            // 
            this.DarkLabel18.AutoSize = true;
            this.DarkLabel18.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
            this.DarkLabel18.Location = new System.Drawing.Point(80, 58);
            this.DarkLabel18.Name = "DarkLabel18";
            this.DarkLabel18.Size = new System.Drawing.Size(93, 13);
            this.DarkLabel18.TabIndex = 2;
            this.DarkLabel18.Text = "Item Requirement:";
            // 
            // rdbItemReq
            // 
            this.rdbItemReq.AutoSize = true;
            this.rdbItemReq.Location = new System.Drawing.Point(10, 56);
            this.rdbItemReq.Name = "rdbItemReq";
            this.rdbItemReq.Size = new System.Drawing.Size(45, 17);
            this.rdbItemReq.TabIndex = 1;
            this.rdbItemReq.TabStop = true;
            this.rdbItemReq.Text = "Item";
            // 
            // rdbNoneReq
            // 
            this.rdbNoneReq.AutoSize = true;
            this.rdbNoneReq.Location = new System.Drawing.Point(10, 21);
            this.rdbNoneReq.Name = "rdbNoneReq";
            this.rdbNoneReq.Size = new System.Drawing.Size(51, 17);
            this.rdbNoneReq.TabIndex = 0;
            this.rdbNoneReq.TabStop = true;
            this.rdbNoneReq.Text = "None";
            // 
            // frmQuest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
            this.ClientSize = new System.Drawing.Size(1250, 494);
            this.ControlBox = false;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.DarkLabel8);
            this.Controls.Add(this.DarkGroupBox2);
            this.Controls.Add(this.fraQuestList);
            this.Controls.Add(this.fraTasks);
            this.Controls.Add(this.fraRequirements);
            this.ForeColor = System.Drawing.Color.Gainsboro;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmQuest";
            this.Text = "Quest Editor";
            this.fraQuestList.ResumeLayout(false);
            this.DarkGroupBox2.ResumeLayout(false);
            this.DarkGroupBox2.PerformLayout();
            this.DarkGroupBox5.ResumeLayout(false);
            this.DarkGroupBox4.ResumeLayout(false);
            this.DarkGroupBox3.ResumeLayout(false);
            this.DarkGroupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudItemRewValue).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudExpReward).EndInit();
            this.fraTasks.ResumeLayout(false);
            this.Panel2.ResumeLayout(false);
            this.Panel2.PerformLayout();
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudAmount).EndInit();
            this.fraRequirements.ResumeLayout(false);
            this.fraRequirements.PerformLayout();
            this.DarkGroupBox6.ResumeLayout(false);
            this.DarkGroupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)this.nudTakeAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)this.nudGiveAmount).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public DarkUI.Controls.DarkGroupBox fraQuestList;

        public ListBox lstIndex;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox2;

        public DarkUI.Controls.DarkTextBox txtName;

        public DarkUI.Controls.DarkLabel DarkLabel1;

        public DarkUI.Controls.DarkCheckBox chkRepeat;

        public DarkUI.Controls.DarkCheckBox chkQuestCancel;

        public DarkUI.Controls.DarkTextBox txtStartText;

        public DarkUI.Controls.DarkLabel DarkLabel2;

        public DarkUI.Controls.DarkTextBox txtEndText;

        public DarkUI.Controls.DarkTextBox txtProgressText;

        public DarkUI.Controls.DarkLabel DarkLabel3;

        public DarkUI.Controls.DarkLabel DarkLabel4;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox3;

        public ListBox lstRewards;

        public DarkUI.Controls.DarkButton btnAddReward;

        public DarkUI.Controls.DarkButton btnRemoveReward;

        public DarkUI.Controls.DarkNumericUpDown nudExpReward;

        public DarkUI.Controls.DarkLabel DarkLabel5;

        public DarkUI.Controls.DarkNumericUpDown nudItemRewValue;

        public DarkUI.Controls.DarkLabel DarkLabel7;

        public DarkUI.Controls.DarkComboBox cmbItemReward;

        public DarkUI.Controls.DarkLabel DarkLabel6;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox4;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox5;

        public DarkUI.Controls.DarkButton btnAddRequirement;

        public DarkUI.Controls.DarkButton btnRemoveRequirement;

        public ListBox lstRequirements;
        

        public ListBox lstTasks;
        

        public DarkUI.Controls.DarkButton btnRemoveTask;
        

        public DarkUI.Controls.DarkButton btnAddTask;
        

        public DarkUI.Controls.DarkLabel DarkLabel8;
        

        public DarkUI.Controls.DarkButton btnSave;
        

        public DarkUI.Controls.DarkButton btnCancel;
        
        public DarkUI.Controls.DarkGroupBox fraTasks;

        public Panel Panel1;

        public DarkUI.Controls.DarkTextBox txtTaskLog;

        public DarkUI.Controls.DarkLabel DarkLabel9;

        public DarkUI.Controls.DarkTextBox txtTaskSpeech;

        public DarkUI.Controls.DarkLabel DarkLabel10;

        public DarkUI.Controls.DarkCheckBox chkEnd;

        public DarkUI.Controls.DarkLabel DarkLabel11;

        public DarkUI.Controls.DarkLabel DarkLabel13;

        public DarkUI.Controls.DarkLabel DarkLabel12;

        public DarkUI.Controls.DarkLabel DarkLabel14;

        public DarkUI.Controls.DarkNumericUpDown nudAmount;

        public DarkUI.Controls.DarkLabel DarkLabel15;

        public DarkUI.Controls.DarkLabel lblTaskNum;

        public Panel Panel2;

        public DarkUI.Controls.DarkRadioButton optTask0;

        public DarkUI.Controls.DarkLabel DarkLabel16;

        public DarkUI.Controls.DarkRadioButton optTask1;

        public DarkUI.Controls.DarkRadioButton optTask2;

        public DarkUI.Controls.DarkRadioButton optTask3;

        public DarkUI.Controls.DarkRadioButton optTask4;

        public DarkUI.Controls.DarkRadioButton optTask5;

        public DarkUI.Controls.DarkRadioButton optTask6;

        public DarkUI.Controls.DarkRadioButton optTask7;

        public DarkUI.Controls.DarkLabel DarkLabel17;

        public DarkUI.Controls.DarkGroupBox fraRequirements;

        public DarkUI.Controls.DarkRadioButton rdbNoneReq;

        public DarkUI.Controls.DarkRadioButton rdbItemReq;

        public DarkUI.Controls.DarkComboBox cmbItemReq;

        public DarkUI.Controls.DarkLabel DarkLabel18;

        public DarkUI.Controls.DarkComboBox cmbQuestReq;

        public DarkUI.Controls.DarkLabel DarkLabel19;

        public DarkUI.Controls.DarkRadioButton rdbQuestReq;

        public DarkUI.Controls.DarkComboBox cmbClassReq;

        public DarkUI.Controls.DarkLabel DarkLabel20;

        public DarkUI.Controls.DarkRadioButton rdbClassReq;

        public DarkUI.Controls.DarkGroupBox DarkGroupBox6;

        public DarkUI.Controls.DarkComboBox cmbStartItem;

        public DarkUI.Controls.DarkLabel DarkLabel21;

        public DarkUI.Controls.DarkNumericUpDown nudGiveAmount;

        public DarkUI.Controls.DarkLabel DarkLabel22;

        public DarkUI.Controls.DarkNumericUpDown nudTakeAmount;

        public DarkUI.Controls.DarkLabel DarkLabel23;

        public DarkUI.Controls.DarkComboBox cmbEndItem;

        public DarkUI.Controls.DarkLabel DarkLabel24;

        public DarkUI.Controls.DarkButton btnRequirementSave;

        public DarkUI.Controls.DarkButton btnRequirementCancel;

        public DarkUI.Controls.DarkButton btnCancelTask;

        public DarkUI.Controls.DarkButton btnSaveTask;

        public DarkUI.Controls.DarkComboBox cmbResource;

        public DarkUI.Controls.DarkComboBox cmbMap;

        public DarkUI.Controls.DarkComboBox cmbItem;

        public DarkUI.Controls.DarkComboBox cmbNpc;
    }
}
