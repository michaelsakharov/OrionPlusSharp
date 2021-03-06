
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
	partial class frmEvents : System.Windows.Forms.Form
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
			System.Windows.Forms.TreeNode TreeNode59 = new System.Windows.Forms.TreeNode("Show Text");
			System.Windows.Forms.TreeNode TreeNode60 = new System.Windows.Forms.TreeNode("Show Choices");
			System.Windows.Forms.TreeNode TreeNode61 = new System.Windows.Forms.TreeNode("Add Chatbox Text");
			System.Windows.Forms.TreeNode TreeNode62 = new System.Windows.Forms.TreeNode("Show ChatBubble");
			System.Windows.Forms.TreeNode TreeNode63 = new System.Windows.Forms.TreeNode("Messages", new System.Windows.Forms.TreeNode[] {TreeNode59, TreeNode60, TreeNode61, TreeNode62});
			System.Windows.Forms.TreeNode TreeNode64 = new System.Windows.Forms.TreeNode("Set Player Variable");
			System.Windows.Forms.TreeNode TreeNode65 = new System.Windows.Forms.TreeNode("Set Player Switch");
			System.Windows.Forms.TreeNode TreeNode66 = new System.Windows.Forms.TreeNode("Set Self Switch");
			System.Windows.Forms.TreeNode TreeNode67 = new System.Windows.Forms.TreeNode("Event Processing", new System.Windows.Forms.TreeNode[] {TreeNode64, TreeNode65, TreeNode66});
			System.Windows.Forms.TreeNode TreeNode68 = new System.Windows.Forms.TreeNode("Conditional Branch");
			System.Windows.Forms.TreeNode TreeNode69 = new System.Windows.Forms.TreeNode("Stop Event Processing");
			System.Windows.Forms.TreeNode TreeNode70 = new System.Windows.Forms.TreeNode("Label");
			System.Windows.Forms.TreeNode TreeNode71 = new System.Windows.Forms.TreeNode("GoTo Label");
			System.Windows.Forms.TreeNode TreeNode72 = new System.Windows.Forms.TreeNode("Flow Control", new System.Windows.Forms.TreeNode[] {TreeNode68, TreeNode69, TreeNode70, TreeNode71});
			System.Windows.Forms.TreeNode TreeNode73 = new System.Windows.Forms.TreeNode("Change Items");
			System.Windows.Forms.TreeNode TreeNode74 = new System.Windows.Forms.TreeNode("Restore HP");
			System.Windows.Forms.TreeNode TreeNode75 = new System.Windows.Forms.TreeNode("Restore MP");
			System.Windows.Forms.TreeNode TreeNode76 = new System.Windows.Forms.TreeNode("Level Up");
			System.Windows.Forms.TreeNode TreeNode77 = new System.Windows.Forms.TreeNode("Change Level");
			System.Windows.Forms.TreeNode TreeNode78 = new System.Windows.Forms.TreeNode("Change Skills");
			System.Windows.Forms.TreeNode TreeNode79 = new System.Windows.Forms.TreeNode("Change Class");
			System.Windows.Forms.TreeNode TreeNode80 = new System.Windows.Forms.TreeNode("Change Sprite");
			System.Windows.Forms.TreeNode TreeNode81 = new System.Windows.Forms.TreeNode("Change Gender");
			System.Windows.Forms.TreeNode TreeNode82 = new System.Windows.Forms.TreeNode("Change PK");
			System.Windows.Forms.TreeNode TreeNode83 = new System.Windows.Forms.TreeNode("Give Experience");
			System.Windows.Forms.TreeNode TreeNode84 = new System.Windows.Forms.TreeNode("Player Options", new System.Windows.Forms.TreeNode[] {TreeNode73, TreeNode74, TreeNode75, TreeNode76, TreeNode77, TreeNode78, TreeNode79, TreeNode80, TreeNode81, TreeNode82, TreeNode83});
			System.Windows.Forms.TreeNode TreeNode85 = new System.Windows.Forms.TreeNode("Warp Player");
			System.Windows.Forms.TreeNode TreeNode86 = new System.Windows.Forms.TreeNode("Set Move Route");
			System.Windows.Forms.TreeNode TreeNode87 = new System.Windows.Forms.TreeNode("Wait for Route Completion");
			System.Windows.Forms.TreeNode TreeNode88 = new System.Windows.Forms.TreeNode("Force Spawn Npc");
			System.Windows.Forms.TreeNode TreeNode89 = new System.Windows.Forms.TreeNode("Hold Player");
			System.Windows.Forms.TreeNode TreeNode90 = new System.Windows.Forms.TreeNode("Release Player");
			System.Windows.Forms.TreeNode TreeNode91 = new System.Windows.Forms.TreeNode("Movement", new System.Windows.Forms.TreeNode[] {TreeNode85, TreeNode86, TreeNode87, TreeNode88, TreeNode89, TreeNode90});
			System.Windows.Forms.TreeNode TreeNode92 = new System.Windows.Forms.TreeNode("Animation");
			System.Windows.Forms.TreeNode TreeNode93 = new System.Windows.Forms.TreeNode("Animation", new System.Windows.Forms.TreeNode[] {TreeNode92});
			System.Windows.Forms.TreeNode TreeNode94 = new System.Windows.Forms.TreeNode("Begin Quest");
			System.Windows.Forms.TreeNode TreeNode95 = new System.Windows.Forms.TreeNode("Complete Task");
			System.Windows.Forms.TreeNode TreeNode96 = new System.Windows.Forms.TreeNode("End Quest");
			System.Windows.Forms.TreeNode TreeNode97 = new System.Windows.Forms.TreeNode("Questing", new System.Windows.Forms.TreeNode[] {TreeNode94, TreeNode95, TreeNode96});
			System.Windows.Forms.TreeNode TreeNode98 = new System.Windows.Forms.TreeNode("Set Fog");
			System.Windows.Forms.TreeNode TreeNode99 = new System.Windows.Forms.TreeNode("Set Weather");
			System.Windows.Forms.TreeNode TreeNode100 = new System.Windows.Forms.TreeNode("Set Map Tinting");
			System.Windows.Forms.TreeNode TreeNode101 = new System.Windows.Forms.TreeNode("Map Functions", new System.Windows.Forms.TreeNode[] {TreeNode98, TreeNode99, TreeNode100});
			System.Windows.Forms.TreeNode TreeNode102 = new System.Windows.Forms.TreeNode("Play BGM");
			System.Windows.Forms.TreeNode TreeNode103 = new System.Windows.Forms.TreeNode("Stop BGM");
			System.Windows.Forms.TreeNode TreeNode104 = new System.Windows.Forms.TreeNode("Play Sound");
			System.Windows.Forms.TreeNode TreeNode105 = new System.Windows.Forms.TreeNode("Stop Sounds");
			System.Windows.Forms.TreeNode TreeNode106 = new System.Windows.Forms.TreeNode("Music and Sound", new System.Windows.Forms.TreeNode[] {TreeNode102, TreeNode103, TreeNode104, TreeNode105});
			System.Windows.Forms.TreeNode TreeNode107 = new System.Windows.Forms.TreeNode("Wait...");
			System.Windows.Forms.TreeNode TreeNode108 = new System.Windows.Forms.TreeNode("Set Access");
			System.Windows.Forms.TreeNode TreeNode109 = new System.Windows.Forms.TreeNode("Custom Script");
			System.Windows.Forms.TreeNode TreeNode110 = new System.Windows.Forms.TreeNode("Etc...", new System.Windows.Forms.TreeNode[] {TreeNode107, TreeNode108, TreeNode109});
			System.Windows.Forms.TreeNode TreeNode111 = new System.Windows.Forms.TreeNode("Open Bank");
			System.Windows.Forms.TreeNode TreeNode112 = new System.Windows.Forms.TreeNode("Open Shop");
			System.Windows.Forms.TreeNode TreeNode113 = new System.Windows.Forms.TreeNode("Shop and Bank", new System.Windows.Forms.TreeNode[] {TreeNode111, TreeNode112});
			System.Windows.Forms.TreeNode TreeNode114 = new System.Windows.Forms.TreeNode("Fade In");
			System.Windows.Forms.TreeNode TreeNode115 = new System.Windows.Forms.TreeNode("Fade Out");
			System.Windows.Forms.TreeNode TreeNode116 = new System.Windows.Forms.TreeNode("CutScene Options", new System.Windows.Forms.TreeNode[] {TreeNode114, TreeNode115});
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvents));
			System.Windows.Forms.ListViewGroup ListViewGroup10 = new System.Windows.Forms.ListViewGroup("Movement", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup ListViewGroup11 = new System.Windows.Forms.ListViewGroup("Wait", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup ListViewGroup12 = new System.Windows.Forms.ListViewGroup("Turning", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup ListViewGroup13 = new System.Windows.Forms.ListViewGroup("Speed", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup ListViewGroup14 = new System.Windows.Forms.ListViewGroup("Walk Animation", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup ListViewGroup15 = new System.Windows.Forms.ListViewGroup("Fixed Direction", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup ListViewGroup16 = new System.Windows.Forms.ListViewGroup("WalkThrough", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup ListViewGroup17 = new System.Windows.Forms.ListViewGroup("Set Position", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewGroup ListViewGroup18 = new System.Windows.Forms.ListViewGroup("Set Graphic", System.Windows.Forms.HorizontalAlignment.Left);
			System.Windows.Forms.ListViewItem ListViewItem44 = new System.Windows.Forms.ListViewItem("Move Up");
			System.Windows.Forms.ListViewItem ListViewItem45 = new System.Windows.Forms.ListViewItem("Move Down");
			System.Windows.Forms.ListViewItem ListViewItem46 = new System.Windows.Forms.ListViewItem("Move left");
			System.Windows.Forms.ListViewItem ListViewItem47 = new System.Windows.Forms.ListViewItem("Move Right");
			System.Windows.Forms.ListViewItem ListViewItem48 = new System.Windows.Forms.ListViewItem("Move Randomly");
			System.Windows.Forms.ListViewItem ListViewItem49 = new System.Windows.Forms.ListViewItem("Move To Player***");
			System.Windows.Forms.ListViewItem ListViewItem50 = new System.Windows.Forms.ListViewItem("Move from Player***");
			System.Windows.Forms.ListViewItem ListViewItem51 = new System.Windows.Forms.ListViewItem("Step Forwards");
			System.Windows.Forms.ListViewItem ListViewItem52 = new System.Windows.Forms.ListViewItem("Step Backwards");
			System.Windows.Forms.ListViewItem ListViewItem53 = new System.Windows.Forms.ListViewItem("Wait 100Ms");
			System.Windows.Forms.ListViewItem ListViewItem54 = new System.Windows.Forms.ListViewItem("Wait 500Ms");
			System.Windows.Forms.ListViewItem ListViewItem55 = new System.Windows.Forms.ListViewItem("Wait 1000Ms");
			System.Windows.Forms.ListViewItem ListViewItem56 = new System.Windows.Forms.ListViewItem("Turn Up");
			System.Windows.Forms.ListViewItem ListViewItem57 = new System.Windows.Forms.ListViewItem("Turn Down");
			System.Windows.Forms.ListViewItem ListViewItem58 = new System.Windows.Forms.ListViewItem("Turn Left");
			System.Windows.Forms.ListViewItem ListViewItem59 = new System.Windows.Forms.ListViewItem("Turn Right");
			System.Windows.Forms.ListViewItem ListViewItem60 = new System.Windows.Forms.ListViewItem("Turn 90DG Right");
			System.Windows.Forms.ListViewItem ListViewItem61 = new System.Windows.Forms.ListViewItem("Turn 90DG Left");
			System.Windows.Forms.ListViewItem ListViewItem62 = new System.Windows.Forms.ListViewItem("Turn 180DG");
			System.Windows.Forms.ListViewItem ListViewItem63 = new System.Windows.Forms.ListViewItem("Turn Randomly");
			System.Windows.Forms.ListViewItem ListViewItem64 = new System.Windows.Forms.ListViewItem("Turn To Player***");
			System.Windows.Forms.ListViewItem ListViewItem65 = new System.Windows.Forms.ListViewItem("Turn From Player***");
			System.Windows.Forms.ListViewItem ListViewItem66 = new System.Windows.Forms.ListViewItem("Set Speed 8x Slower");
			System.Windows.Forms.ListViewItem ListViewItem67 = new System.Windows.Forms.ListViewItem("Set Speed 4x Slower");
			System.Windows.Forms.ListViewItem ListViewItem68 = new System.Windows.Forms.ListViewItem("Set Speed 2x Slower");
			System.Windows.Forms.ListViewItem ListViewItem69 = new System.Windows.Forms.ListViewItem("Set Speed To Normal");
			System.Windows.Forms.ListViewItem ListViewItem70 = new System.Windows.Forms.ListViewItem("Set Speed 2x Faster");
			System.Windows.Forms.ListViewItem ListViewItem71 = new System.Windows.Forms.ListViewItem("Set Speed 4x Faster");
			System.Windows.Forms.ListViewItem ListViewItem72 = new System.Windows.Forms.ListViewItem("Set Freq. To Lowest");
			System.Windows.Forms.ListViewItem ListViewItem73 = new System.Windows.Forms.ListViewItem("Set Freq. To Lower");
			System.Windows.Forms.ListViewItem ListViewItem74 = new System.Windows.Forms.ListViewItem("Set Freq. To Normal");
			System.Windows.Forms.ListViewItem ListViewItem75 = new System.Windows.Forms.ListViewItem("Set Freq. To Higher");
			System.Windows.Forms.ListViewItem ListViewItem76 = new System.Windows.Forms.ListViewItem("Set Freq. To Highest");
			System.Windows.Forms.ListViewItem ListViewItem77 = new System.Windows.Forms.ListViewItem("Walking Animation ON");
			System.Windows.Forms.ListViewItem ListViewItem78 = new System.Windows.Forms.ListViewItem("Walking Animation OFF");
			System.Windows.Forms.ListViewItem ListViewItem79 = new System.Windows.Forms.ListViewItem("Fixed Direction ON");
			System.Windows.Forms.ListViewItem ListViewItem80 = new System.Windows.Forms.ListViewItem("Fixed Direction OFF");
			System.Windows.Forms.ListViewItem ListViewItem81 = new System.Windows.Forms.ListViewItem("Walkthrough ON");
			System.Windows.Forms.ListViewItem ListViewItem82 = new System.Windows.Forms.ListViewItem("Walkthrough ON");
			System.Windows.Forms.ListViewItem ListViewItem83 = new System.Windows.Forms.ListViewItem("Set Position Below Player");
			System.Windows.Forms.ListViewItem ListViewItem84 = new System.Windows.Forms.ListViewItem("Set PositionWith Player");
			System.Windows.Forms.ListViewItem ListViewItem85 = new System.Windows.Forms.ListViewItem("Set Position Above Player");
			System.Windows.Forms.ListViewItem ListViewItem86 = new System.Windows.Forms.ListViewItem("Set Graphic...");
			this.tvCommands = new System.Windows.Forms.TreeView();
			base.Load += new System.EventHandler(FrmEditor_Events_Load);
			this.tvCommands.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvCommands_AfterSelect);
			this.fraPageSetUp = new DarkUI.Controls.DarkGroupBox();
			this.chkGlobal = new DarkUI.Controls.DarkCheckBox();
			this.chkGlobal.CheckedChanged += new System.EventHandler(this.ChkGlobal_CheckedChanged);
			this.btnClearPage = new DarkUI.Controls.DarkButton();
			this.btnClearPage.Click += new System.EventHandler(this.BtnClearPage_Click);
			this.btnDeletePage = new DarkUI.Controls.DarkButton();
			this.btnDeletePage.Click += new System.EventHandler(this.BtnDeletePage_Click);
			this.btnPastePage = new DarkUI.Controls.DarkButton();
			this.btnPastePage.Click += new System.EventHandler(this.BtnPastePage_Click);
			this.btnCopyPage = new DarkUI.Controls.DarkButton();
			this.btnCopyPage.Click += new System.EventHandler(this.BtnCopyPage_Click);
			this.btnNewPage = new DarkUI.Controls.DarkButton();
			this.btnNewPage.Click += new System.EventHandler(this.BtnNewPage_Click);
			this.txtName = new DarkUI.Controls.DarkTextBox();
			this.txtName.TextChanged += new System.EventHandler(this.TxtName_TextChanged);
			this.DarkLabel1 = new DarkUI.Controls.DarkLabel();
			this.tabPages = new System.Windows.Forms.TabControl();
			this.tabPages.Click += new System.EventHandler(this.TabPages_Click);
			this.TabPage1 = new System.Windows.Forms.TabPage();
			this.pnlTabPage = new System.Windows.Forms.Panel();
			this.fraCommands = new System.Windows.Forms.Panel();
			this.btnCancelCommand = new DarkUI.Controls.DarkButton();
			this.btnCancelCommand.Click += new System.EventHandler(this.BtnCancelCommand_Click);
			this.DarkGroupBox8 = new DarkUI.Controls.DarkGroupBox();
			this.btnClearCommand = new DarkUI.Controls.DarkButton();
			this.btnClearCommand.Click += new System.EventHandler(this.BtnClearCommand_Click);
			this.btnDeleteCommand = new DarkUI.Controls.DarkButton();
			this.btnDeleteCommand.Click += new System.EventHandler(this.BtnDeleteComand_Click);
			this.btnEditCommand = new DarkUI.Controls.DarkButton();
			this.btnEditCommand.Click += new System.EventHandler(this.BtnEditCommand_Click);
			this.btnAddCommand = new DarkUI.Controls.DarkButton();
			this.btnAddCommand.Click += new System.EventHandler(this.BtnAddCommand_Click);
			this.lstCommands = new System.Windows.Forms.ListBox();
			this.lstCommands.SelectedIndexChanged += new System.EventHandler(this.LstCommands_SelectedIndexChanged);
			this.DarkLabel10 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel9 = new DarkUI.Controls.DarkLabel();
			this.DarkGroupBox7 = new DarkUI.Controls.DarkGroupBox();
			this.cmbEventQuest = new DarkUI.Controls.DarkComboBox();
			this.cmbEventQuest.SelectedIndexChanged += new System.EventHandler(this.CmbEventQuest_SelectedIndexChanged);
			this.DarkLabel8 = new DarkUI.Controls.DarkLabel();
			this.DarkGroupBox5 = new DarkUI.Controls.DarkGroupBox();
			this.cmbTrigger = new DarkUI.Controls.DarkComboBox();
			this.cmbTrigger.SelectedIndexChanged += new System.EventHandler(this.CmbTrigger_SelectedIndexChanged);
			this.DarkGroupBox4 = new DarkUI.Controls.DarkGroupBox();
			this.cmbPositioning = new DarkUI.Controls.DarkComboBox();
			this.cmbPositioning.SelectedIndexChanged += new System.EventHandler(this.CmbPositioning_SelectedIndexChanged);
			this.DarkGroupBox3 = new DarkUI.Controls.DarkGroupBox();
			this.DarkLabel7 = new DarkUI.Controls.DarkLabel();
			this.cmbMoveFreq = new DarkUI.Controls.DarkComboBox();
			this.cmbMoveFreq.SelectedIndexChanged += new System.EventHandler(this.CmbMoveFreq_SelectedIndexChanged);
			this.DarkLabel6 = new DarkUI.Controls.DarkLabel();
			this.cmbMoveSpeed = new DarkUI.Controls.DarkComboBox();
			this.cmbMoveSpeed.SelectedIndexChanged += new System.EventHandler(this.CmbMoveSpeed_SelectedIndexChanged);
			this.btnMoveRoute = new DarkUI.Controls.DarkButton();
			this.btnMoveRoute.Click += new System.EventHandler(this.BtnMoveRoute_Click);
			this.cmbMoveType = new DarkUI.Controls.DarkComboBox();
			this.cmbMoveType.SelectedIndexChanged += new System.EventHandler(this.CmbMoveType_SelectedIndexChanged);
			this.DarkLabel5 = new DarkUI.Controls.DarkLabel();
			this.DarkGroupBox2 = new DarkUI.Controls.DarkGroupBox();
			this.picGraphic = new System.Windows.Forms.PictureBox();
			this.picGraphic.Click += new System.EventHandler(this.PicGraphic_Click);
			this.DarkGroupBox1 = new DarkUI.Controls.DarkGroupBox();
			this.cmbSelfSwitchCompare = new DarkUI.Controls.DarkComboBox();
			this.cmbSelfSwitchCompare.SelectedIndexChanged += new System.EventHandler(this.CmbSelfSwitchCompare_SelectedIndexChanged);
			this.DarkLabel4 = new DarkUI.Controls.DarkLabel();
			this.cmbSelfSwitch = new DarkUI.Controls.DarkComboBox();
			this.cmbSelfSwitch.SelectedIndexChanged += new System.EventHandler(this.CmbSelfSwitch_SelectedIndexChanged);
			this.chkSelfSwitch = new DarkUI.Controls.DarkCheckBox();
			this.chkSelfSwitch.CheckedChanged += new System.EventHandler(this.ChkSelfSwitch_CheckedChanged);
			this.cmbHasItem = new DarkUI.Controls.DarkComboBox();
			this.cmbHasItem.SelectedIndexChanged += new System.EventHandler(this.CmbHasItem_SelectedIndexChanged);
			this.chkHasItem = new DarkUI.Controls.DarkCheckBox();
			this.chkHasItem.CheckedChanged += new System.EventHandler(this.ChkHasItem_CheckedChanged);
			this.cmbPlayerSwitchCompare = new DarkUI.Controls.DarkComboBox();
			this.cmbPlayerSwitchCompare.SelectedIndexChanged += new System.EventHandler(this.CmbPlayerSwitchCompare_SelectedIndexChanged);
			this.DarkLabel3 = new DarkUI.Controls.DarkLabel();
			this.cmbPlayerSwitch = new DarkUI.Controls.DarkComboBox();
			this.cmbPlayerSwitch.SelectedIndexChanged += new System.EventHandler(this.CmbPlayerSwitch_SelectedIndexChanged);
			this.chkPlayerSwitch = new DarkUI.Controls.DarkCheckBox();
			this.chkPlayerSwitch.CheckedChanged += new System.EventHandler(this.ChkPlayerSwitch_CheckedChanged);
			this.nudPlayerVariable = new DarkUI.Controls.DarkNumericUpDown();
			this.nudPlayerVariable.ValueChanged += new System.EventHandler(this.NudPlayerVariable_ValueChanged);
			this.cmbPlayervarCompare = new DarkUI.Controls.DarkComboBox();
			this.cmbPlayervarCompare.SelectedIndexChanged += new System.EventHandler(this.CmbPlayervarCompare_SelectedIndexChanged);
			this.DarkLabel2 = new DarkUI.Controls.DarkLabel();
			this.cmbPlayerVar = new DarkUI.Controls.DarkComboBox();
			this.cmbPlayerVar.SelectedIndexChanged += new System.EventHandler(this.CmbPlayerVar_SelectedIndexChanged);
			this.chkPlayerVar = new DarkUI.Controls.DarkCheckBox();
			this.chkPlayerVar.CheckedChanged += new System.EventHandler(this.ChkPlayerVar_CheckedChanged);
			this.DarkGroupBox6 = new DarkUI.Controls.DarkGroupBox();
			this.chkShowName = new DarkUI.Controls.DarkCheckBox();
			this.chkShowName.CheckedChanged += new System.EventHandler(this.ChkShowName_CheckedChanged);
			this.chkWalkThrough = new DarkUI.Controls.DarkCheckBox();
			this.chkWalkThrough.CheckedChanged += new System.EventHandler(this.ChkWalkThrough_CheckedChanged);
			this.chkDirFix = new DarkUI.Controls.DarkCheckBox();
			this.chkDirFix.CheckedChanged += new System.EventHandler(this.ChkDirFix_CheckedChanged);
			this.chkWalkAnim = new DarkUI.Controls.DarkCheckBox();
			this.chkWalkAnim.CheckedChanged += new System.EventHandler(this.ChkWalkAnim_CheckedChanged);
			this.btnLabeling = new DarkUI.Controls.DarkButton();
			this.btnLabeling.Click += new System.EventHandler(this.BtnLabeling_Click);
			this.btnCancel = new DarkUI.Controls.DarkButton();
			this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			this.btnOk = new DarkUI.Controls.DarkButton();
			this.btnOk.Click += new System.EventHandler(this.BtnOK_Click);
			this.fraMoveRoute = new DarkUI.Controls.DarkGroupBox();
			this.btnMoveRouteOk = new DarkUI.Controls.DarkButton();
			this.btnMoveRouteOk.Click += new System.EventHandler(this.BtnMoveRouteOk_Click);
			this.btnMoveRouteCancel = new DarkUI.Controls.DarkButton();
			this.btnMoveRouteCancel.Click += new System.EventHandler(this.BtnMoveRouteCancel_Click);
			this.chkRepeatRoute = new DarkUI.Controls.DarkCheckBox();
			this.chkRepeatRoute.CheckedChanged += new System.EventHandler(this.ChkRepeatRoute_CheckedChanged);
			this.chkIgnoreMove = new DarkUI.Controls.DarkCheckBox();
			this.chkIgnoreMove.CheckedChanged += new System.EventHandler(this.ChkIgnoreMove_CheckedChanged);
			this.DarkGroupBox10 = new DarkUI.Controls.DarkGroupBox();
			this.lstvwMoveRoute = new System.Windows.Forms.ListView();
			this.lstvwMoveRoute.Click += new System.EventHandler(this.LstvwMoveRoute_SelectedIndexChanged);
			this.ColumnHeader3 = (System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader());
			this.ColumnHeader4 = (System.Windows.Forms.ColumnHeader) (new System.Windows.Forms.ColumnHeader());
			this.lstMoveRoute = new System.Windows.Forms.ListBox();
			this.lstMoveRoute.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LstMoveRoute_KeyDown);
			this.cmbEvent = new DarkUI.Controls.DarkComboBox();
			this.fraGraphic = new DarkUI.Controls.DarkGroupBox();
			this.pnlGraphicSel = new System.Windows.Forms.Panel();
			this.picGraphicSel = new System.Windows.Forms.PictureBox();
			this.picGraphicSel.Click += new System.EventHandler(this.PicGraphicSel_Click);
			this.picGraphicSel.Click += new System.EventHandler(this.PicGraphicSel_Click);
			this.btnGraphicOk = new DarkUI.Controls.DarkButton();
			this.btnGraphicOk.Click += new System.EventHandler(this.BtnGraphicOk_Click);
			this.btnGraphicCancel = new DarkUI.Controls.DarkButton();
			this.btnGraphicCancel.Click += new System.EventHandler(this.BtnGraphicCancel_Click);
			this.DarkLabel13 = new DarkUI.Controls.DarkLabel();
			this.nudGraphic = new DarkUI.Controls.DarkNumericUpDown();
			this.nudGraphic.ValueChanged += new System.EventHandler(this.NudGraphic_ValueChanged);
			this.DarkLabel12 = new DarkUI.Controls.DarkLabel();
			this.cmbGraphic = new DarkUI.Controls.DarkComboBox();
			this.cmbGraphic.SelectedIndexChanged += new System.EventHandler(this.CmbGraphic_SelectedIndexChanged);
			this.DarkLabel11 = new DarkUI.Controls.DarkLabel();
			this.fraDialogue = new DarkUI.Controls.DarkGroupBox();
			this.fraPlayAnimation = new DarkUI.Controls.DarkGroupBox();
			this.btnPlayAnimationOk = new DarkUI.Controls.DarkButton();
			this.btnPlayAnimationOk.Click += new System.EventHandler(this.BtnPlayAnimationOK_Click);
			this.btnPlayAnimationCancel = new DarkUI.Controls.DarkButton();
			this.btnPlayAnimationCancel.Click += new System.EventHandler(this.BtnPlayAnimationCancel_Click);
			this.lblPlayAnimY = new DarkUI.Controls.DarkLabel();
			this.lblPlayAnimX = new DarkUI.Controls.DarkLabel();
			this.cmbPlayAnimEvent = new DarkUI.Controls.DarkComboBox();
			this.DarkLabel62 = new DarkUI.Controls.DarkLabel();
			this.cmbAnimTargetType = new DarkUI.Controls.DarkComboBox();
			this.nudPlayAnimTileY = new DarkUI.Controls.DarkNumericUpDown();
			this.nudPlayAnimTileX = new DarkUI.Controls.DarkNumericUpDown();
			this.DarkLabel61 = new DarkUI.Controls.DarkLabel();
			this.cmbPlayAnim = new DarkUI.Controls.DarkComboBox();
			this.fraMoveRouteWait = new DarkUI.Controls.DarkGroupBox();
			this.btnMoveWaitCancel = new DarkUI.Controls.DarkButton();
			this.btnMoveWaitCancel.Click += new System.EventHandler(this.BtnMoveWaitCancel_Click);
			this.btnMoveWaitOk = new DarkUI.Controls.DarkButton();
			this.btnMoveWaitOk.Click += new System.EventHandler(this.BtnMoveWaitOK_Click);
			this.DarkLabel79 = new DarkUI.Controls.DarkLabel();
			this.cmbMoveWait = new DarkUI.Controls.DarkComboBox();
			this.fraCustomScript = new DarkUI.Controls.DarkGroupBox();
			this.nudCustomScript = new DarkUI.Controls.DarkNumericUpDown();
			this.DarkLabel78 = new DarkUI.Controls.DarkLabel();
			this.btnCustomScriptCancel = new DarkUI.Controls.DarkButton();
			this.btnCustomScriptCancel.Click += new System.EventHandler(this.BtnCustomScriptCancel_Click);
			this.btnCustomScriptOk = new DarkUI.Controls.DarkButton();
			this.btnCustomScriptOk.Click += new System.EventHandler(this.BtnCustomScriptOK_Click);
			this.fraSetWeather = new DarkUI.Controls.DarkGroupBox();
			this.btnSetWeatherOk = new DarkUI.Controls.DarkButton();
			this.btnSetWeatherOk.Click += new System.EventHandler(this.BtnSetWeatherOK_Click);
			this.btnSetWeatherCancel = new DarkUI.Controls.DarkButton();
			this.btnSetWeatherCancel.Click += new System.EventHandler(this.BtnSetWeatherCancel_Click);
			this.DarkLabel76 = new DarkUI.Controls.DarkLabel();
			this.nudWeatherIntensity = new DarkUI.Controls.DarkNumericUpDown();
			this.DarkLabel75 = new DarkUI.Controls.DarkLabel();
			this.CmbWeather = new DarkUI.Controls.DarkComboBox();
			this.fraSpawnNpc = new DarkUI.Controls.DarkGroupBox();
			this.btnSpawnNpcOk = new DarkUI.Controls.DarkButton();
			this.btnSpawnNpcOk.Click += new System.EventHandler(this.BtnSpawnNpcOK_Click);
			this.btnSpawnNpcCancel = new DarkUI.Controls.DarkButton();
			this.btnSpawnNpcCancel.Click += new System.EventHandler(this.BtnSpawnNpcCancel_Click);
			this.cmbSpawnNpc = new DarkUI.Controls.DarkComboBox();
			this.fraGiveExp = new DarkUI.Controls.DarkGroupBox();
			this.btnGiveExpOk = new DarkUI.Controls.DarkButton();
			this.btnGiveExpOk.Click += new System.EventHandler(this.BtnGiveExpOK_Click);
			this.btnGiveExpCancel = new DarkUI.Controls.DarkButton();
			this.btnGiveExpCancel.Click += new System.EventHandler(this.BtnGiveExpCancel_Click);
			this.nudGiveExp = new DarkUI.Controls.DarkNumericUpDown();
			this.DarkLabel77 = new DarkUI.Controls.DarkLabel();
			this.fraEndQuest = new DarkUI.Controls.DarkGroupBox();
			this.btnEndQuestOk = new DarkUI.Controls.DarkButton();
			this.btnEndQuestOk.Click += new System.EventHandler(this.BtnEndQuestOK_Click);
			this.btnEndQuestCancel = new DarkUI.Controls.DarkButton();
			this.btnEndQuestCancel.Click += new System.EventHandler(this.BtnEndQuestCancel_Click);
			this.cmbEndQuest = new DarkUI.Controls.DarkComboBox();
			this.fraSetAccess = new DarkUI.Controls.DarkGroupBox();
			this.btnSetAccessOk = new DarkUI.Controls.DarkButton();
			this.btnSetAccessOk.Click += new System.EventHandler(this.BtnSetAccessOK_Click);
			this.btnSetAccessCancel = new DarkUI.Controls.DarkButton();
			this.btnSetAccessCancel.Click += new System.EventHandler(this.BtnSetAccessCancel_Click);
			this.cmbSetAccess = new DarkUI.Controls.DarkComboBox();
			this.fraSetWait = new DarkUI.Controls.DarkGroupBox();
			this.btnSetWaitOk = new DarkUI.Controls.DarkButton();
			this.btnSetWaitOk.Click += new System.EventHandler(this.BtnSetWaitOK_Click);
			this.btnSetWaitCancel = new DarkUI.Controls.DarkButton();
			this.btnSetWaitCancel.Click += new System.EventHandler(this.BtnSetWaitCancel_Click);
			this.DarkLabel74 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel72 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel73 = new DarkUI.Controls.DarkLabel();
			this.nudWaitAmount = new DarkUI.Controls.DarkNumericUpDown();
			this.fraShowPic = new DarkUI.Controls.DarkGroupBox();
			this.btnShowPicOk = new DarkUI.Controls.DarkButton();
			this.btnShowPicOk.Click += new System.EventHandler(this.BtnShowPicOK_Click);
			this.btnShowPicCancel = new DarkUI.Controls.DarkButton();
			this.btnShowPicCancel.Click += new System.EventHandler(this.BtnShowPicCancel_Click);
			this.DarkLabel71 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel70 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel67 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel68 = new DarkUI.Controls.DarkLabel();
			this.nudPicOffsetY = new DarkUI.Controls.DarkNumericUpDown();
			this.nudPicOffsetX = new DarkUI.Controls.DarkNumericUpDown();
			this.DarkLabel69 = new DarkUI.Controls.DarkLabel();
			this.cmbPicLoc = new DarkUI.Controls.DarkComboBox();
			this.nudShowPicture = new DarkUI.Controls.DarkNumericUpDown();
			this.picShowPic = new System.Windows.Forms.PictureBox();
			this.cmbPicIndex = new DarkUI.Controls.DarkComboBox();
			this.DarkLabel66 = new DarkUI.Controls.DarkLabel();
			this.fraOpenShop = new DarkUI.Controls.DarkGroupBox();
			this.btnOpenShopOk = new DarkUI.Controls.DarkButton();
			this.btnOpenShopOk.Click += new System.EventHandler(this.BtnOpenShopOK_Click);
			this.btnOpenShopCancel = new DarkUI.Controls.DarkButton();
			this.btnOpenShopCancel.Click += new System.EventHandler(this.BtnOpenShopCancel_Click);
			this.cmbOpenShop = new DarkUI.Controls.DarkComboBox();
			this.fraChangeLevel = new DarkUI.Controls.DarkGroupBox();
			this.btnChangeLevelOk = new DarkUI.Controls.DarkButton();
			this.btnChangeLevelOk.Click += new System.EventHandler(this.BtnChangeLevelOK_Click);
			this.btnChangeLevelCancel = new DarkUI.Controls.DarkButton();
			this.btnChangeLevelCancel.Click += new System.EventHandler(this.BtnChangeLevelCancel_Click);
			this.DarkLabel65 = new DarkUI.Controls.DarkLabel();
			this.nudChangeLevel = new DarkUI.Controls.DarkNumericUpDown();
			this.fraChangeGender = new DarkUI.Controls.DarkGroupBox();
			this.btnChangeGenderOk = new DarkUI.Controls.DarkButton();
			this.btnChangeGenderOk.Click += new System.EventHandler(this.BtnChangeGenderOK_Click);
			this.btnChangeGenderCancel = new DarkUI.Controls.DarkButton();
			this.btnChangeGenderCancel.Click += new System.EventHandler(this.BtnChangeGenderCancel_Click);
			this.optChangeSexFemale = new DarkUI.Controls.DarkRadioButton();
			this.optChangeSexMale = new DarkUI.Controls.DarkRadioButton();
			this.fraGoToLabel = new DarkUI.Controls.DarkGroupBox();
			this.btnGoToLabelOk = new DarkUI.Controls.DarkButton();
			this.btnGoToLabelOk.Click += new System.EventHandler(this.BtnGoToLabelOk_Click);
			this.btnGoToLabelCancel = new DarkUI.Controls.DarkButton();
			this.btnGoToLabelCancel.Click += new System.EventHandler(this.BtnGoToLabelCancel_Click);
			this.txtGotoLabel = new DarkUI.Controls.DarkTextBox();
			this.DarkLabel60 = new DarkUI.Controls.DarkLabel();
			this.fraHidePic = new DarkUI.Controls.DarkGroupBox();
			this.btnHidePicOk = new DarkUI.Controls.DarkButton();
			this.btnHidePicOk.Click += new System.EventHandler(this.BtnHidePicOK_Click);
			this.btnHidePicCancel = new DarkUI.Controls.DarkButton();
			this.btnHidePicCancel.Click += new System.EventHandler(this.BtnHidePicCancel_Click);
			this.nudHidePic = new DarkUI.Controls.DarkNumericUpDown();
			this.DarkLabel59 = new DarkUI.Controls.DarkLabel();
			this.fraBeginQuest = new DarkUI.Controls.DarkGroupBox();
			this.btnBeginQuestOk = new DarkUI.Controls.DarkButton();
			this.btnBeginQuestOk.Click += new System.EventHandler(this.BtnBeginQuestOK_Click);
			this.btnBeginQuestCancel = new DarkUI.Controls.DarkButton();
			this.btnBeginQuestCancel.Click += new System.EventHandler(this.BtnBeginQuestCancel_Click);
			this.cmbBeginQuest = new DarkUI.Controls.DarkComboBox();
			this.DarkLabel58 = new DarkUI.Controls.DarkLabel();
			this.fraShowChoices = new DarkUI.Controls.DarkGroupBox();
			this.txtChoices4 = new DarkUI.Controls.DarkTextBox();
			this.txtChoices3 = new DarkUI.Controls.DarkTextBox();
			this.txtChoices2 = new DarkUI.Controls.DarkTextBox();
			this.txtChoices1 = new DarkUI.Controls.DarkTextBox();
			this.DarkLabel56 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel57 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel55 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel54 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel52 = new DarkUI.Controls.DarkLabel();
			this.txtChoicePrompt = new DarkUI.Controls.DarkTextBox();
			this.btnShowChoicesOk = new DarkUI.Controls.DarkButton();
			this.btnShowChoicesOk.Click += new System.EventHandler(this.BtnShowChoicesOk_Click);
			this.picShowChoicesFace = new System.Windows.Forms.PictureBox();
			this.btnShowChoicesCancel = new DarkUI.Controls.DarkButton();
			this.btnShowChoicesCancel.Click += new System.EventHandler(this.BtnShowChoicesCancel_Click);
			this.DarkLabel53 = new DarkUI.Controls.DarkLabel();
			this.nudShowChoicesFace = new DarkUI.Controls.DarkNumericUpDown();
			this.nudShowChoicesFace.ValueChanged += new System.EventHandler(this.NudShowChoicesFace_ValueChanged);
			this.fraPlayerVariable = new DarkUI.Controls.DarkGroupBox();
			this.nudVariableData2 = new DarkUI.Controls.DarkNumericUpDown();
			this.optVariableAction2 = new DarkUI.Controls.DarkRadioButton();
			this.optVariableAction2.CheckedChanged += new System.EventHandler(this.OptVariableAction2_CheckedChanged);
			this.btnPlayerVarOk = new DarkUI.Controls.DarkButton();
			this.btnPlayerVarOk.Click += new System.EventHandler(this.BtnPlayerVarOk_Click);
			this.btnPlayerVarCancel = new DarkUI.Controls.DarkButton();
			this.btnPlayerVarCancel.Click += new System.EventHandler(this.BtnPlayerVarCancel_Click);
			this.DarkLabel51 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel50 = new DarkUI.Controls.DarkLabel();
			this.nudVariableData4 = new DarkUI.Controls.DarkNumericUpDown();
			this.nudVariableData3 = new DarkUI.Controls.DarkNumericUpDown();
			this.optVariableAction3 = new DarkUI.Controls.DarkRadioButton();
			this.optVariableAction3.CheckedChanged += new System.EventHandler(this.OptVariableAction3_CheckedChanged);
			this.optVariableAction1 = new DarkUI.Controls.DarkRadioButton();
			this.optVariableAction1.CheckedChanged += new System.EventHandler(this.OptVariableAction1_CheckedChanged);
			this.nudVariableData1 = new DarkUI.Controls.DarkNumericUpDown();
			this.nudVariableData0 = new DarkUI.Controls.DarkNumericUpDown();
			this.optVariableAction0 = new DarkUI.Controls.DarkRadioButton();
			this.optVariableAction0.CheckedChanged += new System.EventHandler(this.OptVariableAction0_CheckedChanged);
			this.cmbVariable = new DarkUI.Controls.DarkComboBox();
			this.DarkLabel49 = new DarkUI.Controls.DarkLabel();
			this.fraChangeSprite = new DarkUI.Controls.DarkGroupBox();
			this.btnChangeSpriteOk = new DarkUI.Controls.DarkButton();
			this.btnChangeSpriteOk.Click += new System.EventHandler(this.BtnChangeSpriteOK_Click);
			this.btnChangeSpriteCancel = new DarkUI.Controls.DarkButton();
			this.btnChangeSpriteCancel.Click += new System.EventHandler(this.BtnChangeSpriteCancel_Click);
			this.DarkLabel48 = new DarkUI.Controls.DarkLabel();
			this.nudChangeSprite = new DarkUI.Controls.DarkNumericUpDown();
			this.picChangeSprite = new System.Windows.Forms.PictureBox();
			this.fraSetSelfSwitch = new DarkUI.Controls.DarkGroupBox();
			this.btnSelfswitchOk = new DarkUI.Controls.DarkButton();
			this.btnSelfswitchOk.Click += new System.EventHandler(this.BtnSelfswitchOk_Click);
			this.btnSelfswitchCancel = new DarkUI.Controls.DarkButton();
			this.btnSelfswitchCancel.Click += new System.EventHandler(this.BtnSelfswitchCancel_Click);
			this.DarkLabel47 = new DarkUI.Controls.DarkLabel();
			this.cmbSetSelfSwitchTo = new DarkUI.Controls.DarkComboBox();
			this.DarkLabel46 = new DarkUI.Controls.DarkLabel();
			this.cmbSetSelfSwitch = new DarkUI.Controls.DarkComboBox();
			this.fraMapTint = new DarkUI.Controls.DarkGroupBox();
			this.btnMapTintOk = new DarkUI.Controls.DarkButton();
			this.btnMapTintOk.Click += new System.EventHandler(this.BtnMapTintOK_Click);
			this.btnMapTintCancel = new DarkUI.Controls.DarkButton();
			this.btnMapTintCancel.Click += new System.EventHandler(this.BtnMapTintCancel_Click);
			this.DarkLabel42 = new DarkUI.Controls.DarkLabel();
			this.nudMapTintData3 = new DarkUI.Controls.DarkNumericUpDown();
			this.nudMapTintData2 = new DarkUI.Controls.DarkNumericUpDown();
			this.DarkLabel43 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel44 = new DarkUI.Controls.DarkLabel();
			this.nudMapTintData1 = new DarkUI.Controls.DarkNumericUpDown();
			this.nudMapTintData0 = new DarkUI.Controls.DarkNumericUpDown();
			this.DarkLabel45 = new DarkUI.Controls.DarkLabel();
			this.fraShowChatBubble = new DarkUI.Controls.DarkGroupBox();
			this.btnShowChatBubbleOk = new DarkUI.Controls.DarkButton();
			this.btnShowChatBubbleOk.Click += new System.EventHandler(this.BtnShowChatBubbleOK_Click);
			this.btnShowChatBubbleCancel = new DarkUI.Controls.DarkButton();
			this.btnShowChatBubbleCancel.Click += new System.EventHandler(this.BtnShowChatBubbleCancel_Click);
			this.DarkLabel41 = new DarkUI.Controls.DarkLabel();
			this.cmbChatBubbleTarget = new DarkUI.Controls.DarkComboBox();
			this.cmbChatBubbleTargetType = new DarkUI.Controls.DarkComboBox();
			this.cmbChatBubbleTargetType.SelectedIndexChanged += new System.EventHandler(this.CmbChatBubbleTargetType_SelectedIndexChanged);
			this.DarkLabel40 = new DarkUI.Controls.DarkLabel();
			this.txtChatbubbleText = new DarkUI.Controls.DarkTextBox();
			this.DarkLabel39 = new DarkUI.Controls.DarkLabel();
			this.fraPlaySound = new DarkUI.Controls.DarkGroupBox();
			this.btnPlaySoundOk = new DarkUI.Controls.DarkButton();
			this.btnPlaySoundOk.Click += new System.EventHandler(this.BtnPlaySoundOK_Click);
			this.btnPlaySoundCancel = new DarkUI.Controls.DarkButton();
			this.btnPlaySoundCancel.Click += new System.EventHandler(this.BtnPlaySoundCancel_Click);
			this.cmbPlaySound = new DarkUI.Controls.DarkComboBox();
			this.fraChangePK = new DarkUI.Controls.DarkGroupBox();
			this.btnChangePkOk = new DarkUI.Controls.DarkButton();
			this.btnChangePkOk.Click += new System.EventHandler(this.BtnChangePkOK_Click);
			this.btnChangePkCancel = new DarkUI.Controls.DarkButton();
			this.btnChangePkCancel.Click += new System.EventHandler(this.BtnChangePkCancel_Click);
			this.cmbSetPK = new DarkUI.Controls.DarkComboBox();
			this.fraCreateLabel = new DarkUI.Controls.DarkGroupBox();
			this.btnCreatelabelOk = new DarkUI.Controls.DarkButton();
			this.btnCreatelabelOk.Click += new System.EventHandler(this.BtnCreatelabelOk_Click);
			this.btnCreatelabelCancel = new DarkUI.Controls.DarkButton();
			this.btnCreatelabelCancel.Click += new System.EventHandler(this.BtnCreateLabelCancel_Click);
			this.txtLabelName = new DarkUI.Controls.DarkTextBox();
			this.lblLabelName = new DarkUI.Controls.DarkLabel();
			this.fraChangeClass = new DarkUI.Controls.DarkGroupBox();
			this.btnChangeClassOk = new DarkUI.Controls.DarkButton();
			this.btnChangeClassOk.Click += new System.EventHandler(this.BtnChangeClassOK_Click);
			this.btnChangeClassCancel = new DarkUI.Controls.DarkButton();
			this.btnChangeClassCancel.Click += new System.EventHandler(this.BtnChangeClassCancel_Click);
			this.cmbChangeClass = new DarkUI.Controls.DarkComboBox();
			this.DarkLabel38 = new DarkUI.Controls.DarkLabel();
			this.fraChangeSkills = new DarkUI.Controls.DarkGroupBox();
			this.btnChangeSkillsOk = new DarkUI.Controls.DarkButton();
			this.btnChangeSkillsOk.Click += new System.EventHandler(this.BtnChangeSkillsOK_Click);
			this.btnChangeSkillsCancel = new DarkUI.Controls.DarkButton();
			this.btnChangeSkillsCancel.Click += new System.EventHandler(this.BtnChangeSkillsCancel_Click);
			this.optChangeSkillsRemove = new DarkUI.Controls.DarkRadioButton();
			this.optChangeSkillsAdd = new DarkUI.Controls.DarkRadioButton();
			this.cmbChangeSkills = new DarkUI.Controls.DarkComboBox();
			this.DarkLabel37 = new DarkUI.Controls.DarkLabel();
			this.fraCompleteTask = new DarkUI.Controls.DarkGroupBox();
			this.btnCompleteQuestTaskOk = new DarkUI.Controls.DarkButton();
			this.btnCompleteQuestTaskOk.Click += new System.EventHandler(this.BtnCompleteQuestTaskOK_Click);
			this.btnCompleteQuestTaskCancel = new DarkUI.Controls.DarkButton();
			this.btnCompleteQuestTaskCancel.Click += new System.EventHandler(this.BtnCompleteQuestTaskCancel_Click);
			this.DarkLabel35 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel36 = new DarkUI.Controls.DarkLabel();
			this.nudCompleteQuestTask = new DarkUI.Controls.DarkNumericUpDown();
			this.cmbCompleteQuest = new DarkUI.Controls.DarkComboBox();
			this.fraPlayerWarp = new DarkUI.Controls.DarkGroupBox();
			this.btnPlayerWarpOk = new DarkUI.Controls.DarkButton();
			this.btnPlayerWarpOk.Click += new System.EventHandler(this.BtnPlayerWarpOK_Click);
			this.btnPlayerWarpCancel = new DarkUI.Controls.DarkButton();
			this.btnPlayerWarpCancel.Click += new System.EventHandler(this.BtnPlayerWarpCancel_Click);
			this.DarkLabel31 = new DarkUI.Controls.DarkLabel();
			this.cmbWarpPlayerDir = new DarkUI.Controls.DarkComboBox();
			this.nudWPY = new DarkUI.Controls.DarkNumericUpDown();
			this.DarkLabel32 = new DarkUI.Controls.DarkLabel();
			this.nudWPX = new DarkUI.Controls.DarkNumericUpDown();
			this.DarkLabel33 = new DarkUI.Controls.DarkLabel();
			this.nudWPMap = new DarkUI.Controls.DarkNumericUpDown();
			this.DarkLabel34 = new DarkUI.Controls.DarkLabel();
			this.fraSetFog = new DarkUI.Controls.DarkGroupBox();
			this.btnSetFogOk = new DarkUI.Controls.DarkButton();
			this.btnSetFogOk.Click += new System.EventHandler(this.BtnSetFogOK_Click);
			this.btnSetFogCancel = new DarkUI.Controls.DarkButton();
			this.btnSetFogCancel.Click += new System.EventHandler(this.BtnSetFogCancel_Click);
			this.DarkLabel30 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel29 = new DarkUI.Controls.DarkLabel();
			this.DarkLabel28 = new DarkUI.Controls.DarkLabel();
			this.nudFogData2 = new DarkUI.Controls.DarkNumericUpDown();
			this.nudFogData1 = new DarkUI.Controls.DarkNumericUpDown();
			this.nudFogData0 = new DarkUI.Controls.DarkNumericUpDown();
			this.fraShowText = new DarkUI.Controls.DarkGroupBox();
			this.DarkLabel27 = new DarkUI.Controls.DarkLabel();
			this.txtShowText = new DarkUI.Controls.DarkTextBox();
			this.btnShowTextCancel = new DarkUI.Controls.DarkButton();
			this.btnShowTextCancel.Click += new System.EventHandler(this.BtnShowTextCancel_Click);
			this.btnShowTextOk = new DarkUI.Controls.DarkButton();
			this.btnShowTextOk.Click += new System.EventHandler(this.BtnShowTextOk_Click);
			this.picShowTextFace = new System.Windows.Forms.PictureBox();
			this.DarkLabel26 = new DarkUI.Controls.DarkLabel();
			this.nudShowTextFace = new DarkUI.Controls.DarkNumericUpDown();
			this.nudShowTextFace.ValueChanged += new System.EventHandler(this.NudShowTextFace_ValueChanged);
			this.fraAddText = new DarkUI.Controls.DarkGroupBox();
			this.btnAddTextOk = new DarkUI.Controls.DarkButton();
			this.btnAddTextOk.Click += new System.EventHandler(this.BtnAddTextOk_Click);
			this.btnAddTextCancel = new DarkUI.Controls.DarkButton();
			this.btnAddTextCancel.Click += new System.EventHandler(this.BtnAddTextCancel_Click);
			this.optAddText_Global = new DarkUI.Controls.DarkRadioButton();
			this.optAddText_Map = new DarkUI.Controls.DarkRadioButton();
			this.optAddText_Player = new DarkUI.Controls.DarkRadioButton();
			this.DarkLabel25 = new DarkUI.Controls.DarkLabel();
			this.txtAddText_Text = new DarkUI.Controls.DarkTextBox();
			this.DarkLabel24 = new DarkUI.Controls.DarkLabel();
			this.fraPlayerSwitch = new DarkUI.Controls.DarkGroupBox();
			this.btnSetPlayerSwitchOk = new DarkUI.Controls.DarkButton();
			this.btnSetPlayerSwitchOk.Click += new System.EventHandler(this.BtnSetPlayerSwitchOk_Click);
			this.btnSetPlayerswitchCancel = new DarkUI.Controls.DarkButton();
			this.btnSetPlayerswitchCancel.Click += new System.EventHandler(this.BtnSetPlayerswitchCancel_Click);
			this.cmbPlayerSwitchSet = new DarkUI.Controls.DarkComboBox();
			this.DarkLabel23 = new DarkUI.Controls.DarkLabel();
			this.cmbSwitch = new DarkUI.Controls.DarkComboBox();
			this.DarkLabel22 = new DarkUI.Controls.DarkLabel();
			this.fraChangeItems = new DarkUI.Controls.DarkGroupBox();
			this.btnChangeItemsOk = new DarkUI.Controls.DarkButton();
			this.btnChangeItemsOk.Click += new System.EventHandler(this.BtnChangeItemsOk_Click);
			this.btnChangeItemsCancel = new DarkUI.Controls.DarkButton();
			this.btnChangeItemsCancel.Click += new System.EventHandler(this.BtnChangeItemsCancel_Click);
			this.nudChangeItemsAmount = new DarkUI.Controls.DarkNumericUpDown();
			this.optChangeItemRemove = new DarkUI.Controls.DarkRadioButton();
			this.optChangeItemAdd = new DarkUI.Controls.DarkRadioButton();
			this.optChangeItemSet = new DarkUI.Controls.DarkRadioButton();
			this.cmbChangeItemIndex = new DarkUI.Controls.DarkComboBox();
			this.cmbChangeItemIndex.SelectedIndexChanged += new System.EventHandler(this.CmbChangeItemIndex_SelectedIndexChanged);
			this.DarkLabel21 = new DarkUI.Controls.DarkLabel();
			this.fraConditionalBranch = new DarkUI.Controls.DarkGroupBox();
			this.btnConditionalBranchOk = new DarkUI.Controls.DarkButton();
			this.btnConditionalBranchOk.Click += new System.EventHandler(this.BtnConditionalBranchOk_Click);
			this.btnConditionalBranchCancel = new DarkUI.Controls.DarkButton();
			this.btnConditionalBranchCancel.Click += new System.EventHandler(this.BtnConditionalBranchCancel_Click);
			this.cmbCondition_Gender = new DarkUI.Controls.DarkComboBox();
			this.optCondition8 = new DarkUI.Controls.DarkRadioButton();
			this.optCondition8.CheckedChanged += new System.EventHandler(this.OptCondition8_CheckedChanged);
			this.fraConditions_Quest = new DarkUI.Controls.DarkGroupBox();
			this.DarkLabel20 = new DarkUI.Controls.DarkLabel();
			this.nudCondition_QuestTask = new DarkUI.Controls.DarkNumericUpDown();
			this.cmbCondition_General = new DarkUI.Controls.DarkComboBox();
			this.DarkLabel19 = new DarkUI.Controls.DarkLabel();
			this.optCondition_Quest1 = new DarkUI.Controls.DarkRadioButton();
			this.optCondition_Quest0 = new DarkUI.Controls.DarkRadioButton();
			this.nudCondition_Quest = new DarkUI.Controls.DarkNumericUpDown();
			this.DarkLabel18 = new DarkUI.Controls.DarkLabel();
			this.optCondition7 = new DarkUI.Controls.DarkRadioButton();
			this.optCondition7.CheckedChanged += new System.EventHandler(this.OptCondition7_CheckedChanged);
			this.cmbCondition_SelfSwitchCondition = new DarkUI.Controls.DarkComboBox();
			this.DarkLabel17 = new DarkUI.Controls.DarkLabel();
			this.cmbCondition_SelfSwitch = new DarkUI.Controls.DarkComboBox();
			this.optCondition6 = new DarkUI.Controls.DarkRadioButton();
			this.optCondition6.CheckedChanged += new System.EventHandler(this.OptCondition6_CheckedChanged);
			this.nudCondition_LevelAmount = new DarkUI.Controls.DarkNumericUpDown();
			this.optCondition5 = new DarkUI.Controls.DarkRadioButton();
			this.optCondition5.CheckedChanged += new System.EventHandler(this.OptCondition5_CheckedChanged);
			this.cmbCondition_LevelCompare = new DarkUI.Controls.DarkComboBox();
			this.cmbCondition_LearntSkill = new DarkUI.Controls.DarkComboBox();
			this.optCondition4 = new DarkUI.Controls.DarkRadioButton();
			this.optCondition4.CheckedChanged += new System.EventHandler(this.OptCondition4_CheckedChanged);
			this.cmbCondition_ClassIs = new DarkUI.Controls.DarkComboBox();
			this.optCondition3 = new DarkUI.Controls.DarkRadioButton();
			this.optCondition3.CheckedChanged += new System.EventHandler(this.OptCondition3_CheckedChanged);
			this.nudCondition_HasItem = new DarkUI.Controls.DarkNumericUpDown();
			this.DarkLabel16 = new DarkUI.Controls.DarkLabel();
			this.cmbCondition_HasItem = new DarkUI.Controls.DarkComboBox();
			this.optCondition2 = new DarkUI.Controls.DarkRadioButton();
			this.optCondition2.CheckedChanged += new System.EventHandler(this.OptCondition2_CheckedChanged);
			this.optCondition1 = new DarkUI.Controls.DarkRadioButton();
			this.optCondition1.CheckedChanged += new System.EventHandler(this.OptCondition1_CheckedChanged);
			this.DarkLabel15 = new DarkUI.Controls.DarkLabel();
			this.cmbCondtion_PlayerSwitchCondition = new DarkUI.Controls.DarkComboBox();
			this.cmbCondition_PlayerSwitch = new DarkUI.Controls.DarkComboBox();
			this.nudCondition_PlayerVarCondition = new DarkUI.Controls.DarkNumericUpDown();
			this.cmbCondition_PlayerVarCompare = new DarkUI.Controls.DarkComboBox();
			this.DarkLabel14 = new DarkUI.Controls.DarkLabel();
			this.cmbCondition_PlayerVarIndex = new DarkUI.Controls.DarkComboBox();
			this.optCondition0 = new DarkUI.Controls.DarkRadioButton();
			this.optCondition0.CheckedChanged += new System.EventHandler(this.OptCondition_Index0_CheckedChanged);
			this.fraPlayBGM = new DarkUI.Controls.DarkGroupBox();
			this.btnPlayBgmOk = new DarkUI.Controls.DarkButton();
			this.btnPlayBgmOk.Click += new System.EventHandler(this.BtnPlayBgmOK_Click);
			this.btnPlayBgmCancel = new DarkUI.Controls.DarkButton();
			this.btnPlayBgmCancel.Click += new System.EventHandler(this.BtnPlayBgmCancel_Click);
			this.cmbPlayBGM = new DarkUI.Controls.DarkComboBox();
			this.pnlVariableSwitches = new System.Windows.Forms.Panel();
			this.FraRenaming = new System.Windows.Forms.GroupBox();
			this.btnRename_Cancel = new System.Windows.Forms.Button();
			this.btnRename_Cancel.Click += new System.EventHandler(this.BtnRename_Cancel_Click);
			this.btnRename_Ok = new System.Windows.Forms.Button();
			this.btnRename_Ok.Click += new System.EventHandler(this.BtnRename_Ok_Click);
			this.fraRandom10 = new System.Windows.Forms.GroupBox();
			this.txtRename = new System.Windows.Forms.TextBox();
			this.txtRename.TextChanged += new System.EventHandler(this.TxtRename_TextChanged);
			this.lblEditing = new System.Windows.Forms.Label();
			this.fraLabeling = new DarkUI.Controls.DarkGroupBox();
			this.lstSwitches = new System.Windows.Forms.ListBox();
			this.lstSwitches.DoubleClick += new System.EventHandler(this.LstSwitches_DoubleClick);
			this.lstVariables = new System.Windows.Forms.ListBox();
			this.lstVariables.DoubleClick += new System.EventHandler(this.LstVariables_DoubleClick);
			this.btnLabel_Cancel = new System.Windows.Forms.Button();
			this.btnLabel_Cancel.Click += new System.EventHandler(this.BtnLabel_Cancel_Click);
			this.lblRandomLabel36 = new System.Windows.Forms.Label();
			this.btnRenameVariable = new System.Windows.Forms.Button();
			this.btnRenameVariable.Click += new System.EventHandler(this.BtnRenameVariable_Click);
			this.lblRandomLabel25 = new System.Windows.Forms.Label();
			this.btnRenameSwitch = new System.Windows.Forms.Button();
			this.btnRenameSwitch.Click += new System.EventHandler(this.BtnRenameSwitch_Click);
			this.btnLabel_Ok = new System.Windows.Forms.Button();
			this.btnLabel_Ok.Click += new System.EventHandler(this.BtnLabel_Ok_Click);
			this.optCondition9 = new DarkUI.Controls.DarkRadioButton();
			this.optCondition9.CheckedChanged += new System.EventHandler(this.OptCondition9_CheckedChanged);
			this.cmbCondition_Time = new DarkUI.Controls.DarkComboBox();
			this.fraPageSetUp.SuspendLayout();
			this.tabPages.SuspendLayout();
			this.pnlTabPage.SuspendLayout();
			this.fraCommands.SuspendLayout();
			this.DarkGroupBox8.SuspendLayout();
			this.DarkGroupBox7.SuspendLayout();
			this.DarkGroupBox5.SuspendLayout();
			this.DarkGroupBox4.SuspendLayout();
			this.DarkGroupBox3.SuspendLayout();
			this.DarkGroupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.picGraphic).BeginInit();
			this.DarkGroupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudPlayerVariable).BeginInit();
			this.DarkGroupBox6.SuspendLayout();
			this.fraMoveRoute.SuspendLayout();
			this.DarkGroupBox10.SuspendLayout();
			this.fraGraphic.SuspendLayout();
			this.pnlGraphicSel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.picGraphicSel).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudGraphic).BeginInit();
			this.fraDialogue.SuspendLayout();
			this.fraPlayAnimation.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudPlayAnimTileY).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudPlayAnimTileX).BeginInit();
			this.fraMoveRouteWait.SuspendLayout();
			this.fraCustomScript.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudCustomScript).BeginInit();
			this.fraSetWeather.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudWeatherIntensity).BeginInit();
			this.fraSpawnNpc.SuspendLayout();
			this.fraGiveExp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudGiveExp).BeginInit();
			this.fraEndQuest.SuspendLayout();
			this.fraSetAccess.SuspendLayout();
			this.fraSetWait.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudWaitAmount).BeginInit();
			this.fraShowPic.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudPicOffsetY).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudPicOffsetX).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudShowPicture).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.picShowPic).BeginInit();
			this.fraOpenShop.SuspendLayout();
			this.fraChangeLevel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudChangeLevel).BeginInit();
			this.fraChangeGender.SuspendLayout();
			this.fraGoToLabel.SuspendLayout();
			this.fraHidePic.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudHidePic).BeginInit();
			this.fraBeginQuest.SuspendLayout();
			this.fraShowChoices.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.picShowChoicesFace).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudShowChoicesFace).BeginInit();
			this.fraPlayerVariable.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudVariableData2).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudVariableData4).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudVariableData3).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudVariableData1).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudVariableData0).BeginInit();
			this.fraChangeSprite.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudChangeSprite).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.picChangeSprite).BeginInit();
			this.fraSetSelfSwitch.SuspendLayout();
			this.fraMapTint.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudMapTintData3).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudMapTintData2).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudMapTintData1).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudMapTintData0).BeginInit();
			this.fraShowChatBubble.SuspendLayout();
			this.fraPlaySound.SuspendLayout();
			this.fraChangePK.SuspendLayout();
			this.fraCreateLabel.SuspendLayout();
			this.fraChangeClass.SuspendLayout();
			this.fraChangeSkills.SuspendLayout();
			this.fraCompleteTask.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudCompleteQuestTask).BeginInit();
			this.fraPlayerWarp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudWPY).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudWPX).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudWPMap).BeginInit();
			this.fraSetFog.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudFogData2).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudFogData1).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudFogData0).BeginInit();
			this.fraShowText.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.picShowTextFace).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudShowTextFace).BeginInit();
			this.fraAddText.SuspendLayout();
			this.fraPlayerSwitch.SuspendLayout();
			this.fraChangeItems.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudChangeItemsAmount).BeginInit();
			this.fraConditionalBranch.SuspendLayout();
			this.fraConditions_Quest.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.nudCondition_QuestTask).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudCondition_Quest).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudCondition_LevelAmount).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudCondition_HasItem).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.nudCondition_PlayerVarCondition).BeginInit();
			this.fraPlayBGM.SuspendLayout();
			this.pnlVariableSwitches.SuspendLayout();
			this.FraRenaming.SuspendLayout();
			this.fraRandom10.SuspendLayout();
			this.fraLabeling.SuspendLayout();
			this.SuspendLayout();
			//
			//tvCommands
			//
			this.tvCommands.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.tvCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tvCommands.ForeColor = System.Drawing.Color.Gainsboro;
			this.tvCommands.Location = new System.Drawing.Point(6, 3);
			this.tvCommands.Name = "tvCommands";
			TreeNode59.Name = "Node1";
			TreeNode59.Text = "Show Text";
			TreeNode60.Name = "Node2";
			TreeNode60.Text = "Show Choices";
			TreeNode61.Name = "Node3";
			TreeNode61.Text = "Add Chatbox Text";
			TreeNode62.Name = "Node5";
			TreeNode62.Text = "Show ChatBubble";
			TreeNode63.Name = "NodeMessages";
			TreeNode63.Text = "Messages";
			TreeNode64.Name = "Node1";
			TreeNode64.Text = "Set Player Variable";
			TreeNode65.Name = "Node2";
			TreeNode65.Text = "Set Player Switch";
			TreeNode66.Name = "Node3";
			TreeNode66.Text = "Set Self Switch";
			TreeNode67.Name = "NodeProcessing";
			TreeNode67.Text = "Event Processing";
			TreeNode68.Name = "Node1";
			TreeNode68.Text = "Conditional Branch";
			TreeNode69.Name = "Node2";
			TreeNode69.Text = "Stop Event Processing";
			TreeNode70.Name = "Node3";
			TreeNode70.Text = "Label";
			TreeNode71.Name = "Node4";
			TreeNode71.Text = "GoTo Label";
			TreeNode72.Name = "NodeFlowControl";
			TreeNode72.Text = "Flow Control";
			TreeNode73.Name = "Node1";
			TreeNode73.Text = "Change Items";
			TreeNode74.Name = "Node2";
			TreeNode74.Text = "Restore HP";
			TreeNode75.Name = "Node3";
			TreeNode75.Text = "Restore MP";
			TreeNode76.Name = "Node4";
			TreeNode76.Text = "Level Up";
			TreeNode77.Name = "Node5";
			TreeNode77.Text = "Change Level";
			TreeNode78.Name = "Node6";
			TreeNode78.Text = "Change Skills";
			TreeNode79.Name = "Node7";
			TreeNode79.Text = "Change Class";
			TreeNode80.Name = "Node8";
			TreeNode80.Text = "Change Sprite";
			TreeNode81.Name = "Node9";
			TreeNode81.Text = "Change Gender";
			TreeNode82.Name = "Node10";
			TreeNode82.Text = "Change PK";
			TreeNode83.Name = "Node11";
			TreeNode83.Text = "Give Experience";
			TreeNode84.Name = "NodePlayerOptions";
			TreeNode84.Text = "Player Options";
			TreeNode85.Name = "Node1";
			TreeNode85.Text = "Warp Player";
			TreeNode86.Name = "Node2";
			TreeNode86.Text = "Set Move Route";
			TreeNode87.Name = "Node3";
			TreeNode87.Text = "Wait for Route Completion";
			TreeNode88.Name = "Node4";
			TreeNode88.Text = "Force Spawn Npc";
			TreeNode89.Name = "Node5";
			TreeNode89.Text = "Hold Player";
			TreeNode90.Name = "Node6";
			TreeNode90.Text = "Release Player";
			TreeNode91.Name = "NodeMovement";
			TreeNode91.Text = "Movement";
			TreeNode92.Name = "Node1";
			TreeNode92.Text = "Animation";
			TreeNode93.Name = "NodeAnimation";
			TreeNode93.Text = "Animation";
			TreeNode94.Name = "Node1";
			TreeNode94.Text = "Begin Quest";
			TreeNode95.Name = "Node2";
			TreeNode95.Text = "Complete Task";
			TreeNode96.Name = "Node3";
			TreeNode96.Text = "End Quest";
			TreeNode97.Name = "NodeQuesting";
			TreeNode97.Text = "Questing";
			TreeNode98.Name = "Node1";
			TreeNode98.Text = "Set Fog";
			TreeNode99.Name = "Node2";
			TreeNode99.Text = "Set Weather";
			TreeNode100.Name = "Node3";
			TreeNode100.Text = "Set Map Tinting";
			TreeNode101.Name = "NodeMapFunctions";
			TreeNode101.Text = "Map Functions";
			TreeNode102.Name = "Node1";
			TreeNode102.Text = "Play BGM";
			TreeNode103.Name = "Node2";
			TreeNode103.Text = "Stop BGM";
			TreeNode104.Name = "Node3";
			TreeNode104.Text = "Play Sound";
			TreeNode105.Name = "Node4";
			TreeNode105.Text = "Stop Sounds";
			TreeNode106.Name = "NodeSound";
			TreeNode106.Text = "Music and Sound";
			TreeNode107.Name = "Node1";
			TreeNode107.Text = "Wait...";
			TreeNode108.Name = "Node2";
			TreeNode108.Text = "Set Access";
			TreeNode109.Name = "Node3";
			TreeNode109.Text = "Custom Script";
			TreeNode110.Name = "NodeEtc";
			TreeNode110.Text = "Etc...";
			TreeNode111.Name = "Node1";
			TreeNode111.Text = "Open Bank";
			TreeNode112.Name = "Node2";
			TreeNode112.Text = "Open Shop";
			TreeNode113.Name = "NodeShopBank";
			TreeNode113.Text = "Shop and Bank";
			TreeNode114.Name = "Node1";
			TreeNode114.Text = "Fade In";
			TreeNode115.Name = "Node2";
			TreeNode115.Text = "Fade Out";
			TreeNode116.Name = "Node0";
			TreeNode116.Text = "CutScene Options";
			this.tvCommands.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {TreeNode63, TreeNode67, TreeNode72, TreeNode84, TreeNode91, TreeNode93, TreeNode97, TreeNode101, TreeNode106, TreeNode110, TreeNode113, TreeNode116});
			this.tvCommands.Size = new System.Drawing.Size(381, 443);
			this.tvCommands.TabIndex = 1;
			//
			//fraPageSetUp
			//
			this.fraPageSetUp.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraPageSetUp.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraPageSetUp.Controls.Add(this.chkGlobal);
			this.fraPageSetUp.Controls.Add(this.btnClearPage);
			this.fraPageSetUp.Controls.Add(this.btnDeletePage);
			this.fraPageSetUp.Controls.Add(this.btnPastePage);
			this.fraPageSetUp.Controls.Add(this.btnCopyPage);
			this.fraPageSetUp.Controls.Add(this.btnNewPage);
			this.fraPageSetUp.Controls.Add(this.txtName);
			this.fraPageSetUp.Controls.Add(this.DarkLabel1);
			this.fraPageSetUp.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraPageSetUp.Location = new System.Drawing.Point(3, 3);
			this.fraPageSetUp.Name = "fraPageSetUp";
			this.fraPageSetUp.Size = new System.Drawing.Size(791, 50);
			this.fraPageSetUp.TabIndex = 2;
			this.fraPageSetUp.TabStop = false;
			this.fraPageSetUp.Text = "General";
			//
			//chkGlobal
			//
			this.chkGlobal.AutoSize = true;
			this.chkGlobal.Location = new System.Drawing.Point(280, 20);
			this.chkGlobal.Name = "chkGlobal";
			this.chkGlobal.Size = new System.Drawing.Size(87, 17);
			this.chkGlobal.TabIndex = 7;
			this.chkGlobal.Text = "Global Event";
			//
			//btnClearPage
			//
			this.btnClearPage.Location = new System.Drawing.Point(707, 16);
			this.btnClearPage.Name = "btnClearPage";
			this.btnClearPage.Padding = new System.Windows.Forms.Padding(5);
			this.btnClearPage.Size = new System.Drawing.Size(75, 23);
			this.btnClearPage.TabIndex = 6;
			this.btnClearPage.Text = "Clear Page";
			//
			//btnDeletePage
			//
			this.btnDeletePage.Location = new System.Drawing.Point(622, 16);
			this.btnDeletePage.Name = "btnDeletePage";
			this.btnDeletePage.Padding = new System.Windows.Forms.Padding(5);
			this.btnDeletePage.Size = new System.Drawing.Size(79, 23);
			this.btnDeletePage.TabIndex = 5;
			this.btnDeletePage.Text = "Delete Page";
			//
			//btnPastePage
			//
			this.btnPastePage.Location = new System.Drawing.Point(541, 16);
			this.btnPastePage.Name = "btnPastePage";
			this.btnPastePage.Padding = new System.Windows.Forms.Padding(5);
			this.btnPastePage.Size = new System.Drawing.Size(75, 23);
			this.btnPastePage.TabIndex = 4;
			this.btnPastePage.Text = "Paste Page";
			//
			//btnCopyPage
			//
			this.btnCopyPage.Location = new System.Drawing.Point(460, 16);
			this.btnCopyPage.Name = "btnCopyPage";
			this.btnCopyPage.Padding = new System.Windows.Forms.Padding(5);
			this.btnCopyPage.Size = new System.Drawing.Size(75, 23);
			this.btnCopyPage.TabIndex = 3;
			this.btnCopyPage.Text = "Copy Page";
			//
			//btnNewPage
			//
			this.btnNewPage.Location = new System.Drawing.Point(379, 16);
			this.btnNewPage.Name = "btnNewPage";
			this.btnNewPage.Padding = new System.Windows.Forms.Padding(5);
			this.btnNewPage.Size = new System.Drawing.Size(75, 23);
			this.btnNewPage.TabIndex = 2;
			this.btnNewPage.Text = "New Page";
			//
			//txtName
			//
			this.txtName.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtName.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtName.Location = new System.Drawing.Point(84, 19);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(190, 20);
			this.txtName.TabIndex = 1;
			//
			//DarkLabel1
			//
			this.DarkLabel1.AutoSize = true;
			this.DarkLabel1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel1.Location = new System.Drawing.Point(9, 21);
			this.DarkLabel1.Name = "DarkLabel1";
			this.DarkLabel1.Size = new System.Drawing.Size(69, 13);
			this.DarkLabel1.TabIndex = 0;
			this.DarkLabel1.Text = "Event Name:";
			//
			//tabPages
			//
			this.tabPages.Controls.Add(this.TabPage1);
			this.tabPages.Location = new System.Drawing.Point(12, 59);
			this.tabPages.Name = "tabPages";
			this.tabPages.SelectedIndex = 0;
			this.tabPages.Size = new System.Drawing.Size(709, 19);
			this.tabPages.TabIndex = 3;
			//
			//TabPage1
			//
			this.TabPage1.BackColor = System.Drawing.Color.DimGray;
			this.TabPage1.Location = new System.Drawing.Point(4, 22);
			this.TabPage1.Name = "TabPage1";
			this.TabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.TabPage1.Size = new System.Drawing.Size(701, 0);
			this.TabPage1.TabIndex = 0;
			this.TabPage1.Text = "1";
			this.TabPage1.UseVisualStyleBackColor = true;
			//
			//pnlTabPage
			//
			this.pnlTabPage.Controls.Add(this.fraCommands);
			this.pnlTabPage.Controls.Add(this.DarkGroupBox8);
			this.pnlTabPage.Controls.Add(this.lstCommands);
			this.pnlTabPage.Controls.Add(this.DarkLabel10);
			this.pnlTabPage.Controls.Add(this.DarkLabel9);
			this.pnlTabPage.Controls.Add(this.DarkGroupBox7);
			this.pnlTabPage.Controls.Add(this.DarkGroupBox5);
			this.pnlTabPage.Controls.Add(this.DarkGroupBox4);
			this.pnlTabPage.Controls.Add(this.DarkGroupBox3);
			this.pnlTabPage.Controls.Add(this.DarkGroupBox2);
			this.pnlTabPage.Controls.Add(this.DarkGroupBox1);
			this.pnlTabPage.Location = new System.Drawing.Point(3, 81);
			this.pnlTabPage.Name = "pnlTabPage";
			this.pnlTabPage.Size = new System.Drawing.Size(791, 497);
			this.pnlTabPage.TabIndex = 4;
			//
			//fraCommands
			//
			this.fraCommands.Controls.Add(this.btnCancelCommand);
			this.fraCommands.Controls.Add(this.tvCommands);
			this.fraCommands.Location = new System.Drawing.Point(389, 6);
			this.fraCommands.Name = "fraCommands";
			this.fraCommands.Size = new System.Drawing.Size(393, 482);
			this.fraCommands.TabIndex = 6;
			this.fraCommands.Visible = false;
			//
			//btnCancelCommand
			//
			this.btnCancelCommand.Location = new System.Drawing.Point(312, 452);
			this.btnCancelCommand.Name = "btnCancelCommand";
			this.btnCancelCommand.Padding = new System.Windows.Forms.Padding(5);
			this.btnCancelCommand.Size = new System.Drawing.Size(75, 23);
			this.btnCancelCommand.TabIndex = 2;
			this.btnCancelCommand.Text = "Cancel";
			//
			//DarkGroupBox8
			//
			this.DarkGroupBox8.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox8.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox8.Controls.Add(this.btnClearCommand);
			this.DarkGroupBox8.Controls.Add(this.btnDeleteCommand);
			this.DarkGroupBox8.Controls.Add(this.btnEditCommand);
			this.DarkGroupBox8.Controls.Add(this.btnAddCommand);
			this.DarkGroupBox8.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox8.Location = new System.Drawing.Point(389, 439);
			this.DarkGroupBox8.Name = "DarkGroupBox8";
			this.DarkGroupBox8.Size = new System.Drawing.Size(393, 49);
			this.DarkGroupBox8.TabIndex = 9;
			this.DarkGroupBox8.TabStop = false;
			this.DarkGroupBox8.Text = "Commands";
			//
			//btnClearCommand
			//
			this.btnClearCommand.Location = new System.Drawing.Point(312, 19);
			this.btnClearCommand.Name = "btnClearCommand";
			this.btnClearCommand.Padding = new System.Windows.Forms.Padding(5);
			this.btnClearCommand.Size = new System.Drawing.Size(75, 23);
			this.btnClearCommand.TabIndex = 3;
			this.btnClearCommand.Text = "Clear";
			//
			//btnDeleteCommand
			//
			this.btnDeleteCommand.Location = new System.Drawing.Point(212, 19);
			this.btnDeleteCommand.Name = "btnDeleteCommand";
			this.btnDeleteCommand.Padding = new System.Windows.Forms.Padding(5);
			this.btnDeleteCommand.Size = new System.Drawing.Size(75, 23);
			this.btnDeleteCommand.TabIndex = 2;
			this.btnDeleteCommand.Text = "Delete";
			//
			//btnEditCommand
			//
			this.btnEditCommand.Location = new System.Drawing.Point(108, 19);
			this.btnEditCommand.Name = "btnEditCommand";
			this.btnEditCommand.Padding = new System.Windows.Forms.Padding(5);
			this.btnEditCommand.Size = new System.Drawing.Size(75, 23);
			this.btnEditCommand.TabIndex = 1;
			this.btnEditCommand.Text = "Edit";
			//
			//btnAddCommand
			//
			this.btnAddCommand.Location = new System.Drawing.Point(6, 19);
			this.btnAddCommand.Name = "btnAddCommand";
			this.btnAddCommand.Padding = new System.Windows.Forms.Padding(5);
			this.btnAddCommand.Size = new System.Drawing.Size(75, 23);
			this.btnAddCommand.TabIndex = 0;
			this.btnAddCommand.Text = "Add";
			//
			//lstCommands
			//
			this.lstCommands.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.lstCommands.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstCommands.ForeColor = System.Drawing.Color.Gainsboro;
			this.lstCommands.FormattingEnabled = true;
			this.lstCommands.Location = new System.Drawing.Point(389, 6);
			this.lstCommands.Name = "lstCommands";
			this.lstCommands.Size = new System.Drawing.Size(393, 431);
			this.lstCommands.TabIndex = 8;
			//
			//DarkLabel10
			//
			this.DarkLabel10.ForeColor = System.Drawing.Color.Red;
			this.DarkLabel10.Location = new System.Drawing.Point(182, 458);
			this.DarkLabel10.Name = "DarkLabel10";
			this.DarkLabel10.Size = new System.Drawing.Size(200, 30);
			this.DarkLabel10.TabIndex = 7;
			this.DarkLabel10.Text = "** If global, only the first page will be processed. For shop keepers etc.";
			//
			//DarkLabel9
			//
			this.DarkLabel9.ForeColor = System.Drawing.Color.Red;
			this.DarkLabel9.Location = new System.Drawing.Point(182, 424);
			this.DarkLabel9.Name = "DarkLabel9";
			this.DarkLabel9.Size = new System.Drawing.Size(201, 34);
			this.DarkLabel9.TabIndex = 6;
			this.DarkLabel9.Text = "* Self Switches are always global and will reset on server restart.";
			//
			//DarkGroupBox7
			//
			this.DarkGroupBox7.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox7.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox7.Controls.Add(this.cmbEventQuest);
			this.DarkGroupBox7.Controls.Add(this.DarkLabel8);
			this.DarkGroupBox7.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox7.Location = new System.Drawing.Point(182, 376);
			this.DarkGroupBox7.Name = "DarkGroupBox7";
			this.DarkGroupBox7.Size = new System.Drawing.Size(200, 45);
			this.DarkGroupBox7.TabIndex = 5;
			this.DarkGroupBox7.TabStop = false;
			this.DarkGroupBox7.Text = "Quest Icon";
			//
			//cmbEventQuest
			//
			this.cmbEventQuest.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbEventQuest.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbEventQuest.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbEventQuest.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbEventQuest.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbEventQuest.ButtonIcon"));
			this.cmbEventQuest.DrawDropdownHoverOutline = false;
			this.cmbEventQuest.DrawFocusRectangle = false;
			this.cmbEventQuest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbEventQuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEventQuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbEventQuest.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbEventQuest.FormattingEnabled = true;
			this.cmbEventQuest.Location = new System.Drawing.Point(51, 17);
			this.cmbEventQuest.Name = "cmbEventQuest";
			this.cmbEventQuest.Size = new System.Drawing.Size(143, 21);
			this.cmbEventQuest.TabIndex = 1;
			this.cmbEventQuest.Text = null;
			this.cmbEventQuest.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel8
			//
			this.DarkLabel8.AutoSize = true;
			this.DarkLabel8.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel8.Location = new System.Drawing.Point(7, 20);
			this.DarkLabel8.Name = "DarkLabel8";
			this.DarkLabel8.Size = new System.Drawing.Size(38, 13);
			this.DarkLabel8.TabIndex = 0;
			this.DarkLabel8.Text = "Quest:";
			//
			//DarkGroupBox5
			//
			this.DarkGroupBox5.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox5.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox5.Controls.Add(this.cmbTrigger);
			this.DarkGroupBox5.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox5.Location = new System.Drawing.Point(182, 321);
			this.DarkGroupBox5.Name = "DarkGroupBox5";
			this.DarkGroupBox5.Size = new System.Drawing.Size(200, 49);
			this.DarkGroupBox5.TabIndex = 4;
			this.DarkGroupBox5.TabStop = false;
			this.DarkGroupBox5.Text = "Trigger";
			//
			//cmbTrigger
			//
			this.cmbTrigger.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbTrigger.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbTrigger.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbTrigger.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbTrigger.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbTrigger.ButtonIcon"));
			this.cmbTrigger.DrawDropdownHoverOutline = false;
			this.cmbTrigger.DrawFocusRectangle = false;
			this.cmbTrigger.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbTrigger.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbTrigger.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbTrigger.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbTrigger.FormattingEnabled = true;
			this.cmbTrigger.Items.AddRange(new object[] {"Action Button", "Player Touch", "Parallel Process"});
			this.cmbTrigger.Location = new System.Drawing.Point(6, 19);
			this.cmbTrigger.Name = "cmbTrigger";
			this.cmbTrigger.Size = new System.Drawing.Size(189, 21);
			this.cmbTrigger.TabIndex = 0;
			this.cmbTrigger.Text = null;
			this.cmbTrigger.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkGroupBox4
			//
			this.DarkGroupBox4.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox4.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox4.Controls.Add(this.cmbPositioning);
			this.DarkGroupBox4.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox4.Location = new System.Drawing.Point(182, 267);
			this.DarkGroupBox4.Name = "DarkGroupBox4";
			this.DarkGroupBox4.Size = new System.Drawing.Size(200, 48);
			this.DarkGroupBox4.TabIndex = 3;
			this.DarkGroupBox4.TabStop = false;
			this.DarkGroupBox4.Text = "Positioning";
			//
			//cmbPositioning
			//
			this.cmbPositioning.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbPositioning.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbPositioning.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbPositioning.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbPositioning.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbPositioning.ButtonIcon"));
			this.cmbPositioning.DrawDropdownHoverOutline = false;
			this.cmbPositioning.DrawFocusRectangle = false;
			this.cmbPositioning.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPositioning.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPositioning.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPositioning.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbPositioning.FormattingEnabled = true;
			this.cmbPositioning.Items.AddRange(new object[] {"Below Characters", "Same as Characters", "Above Characters"});
			this.cmbPositioning.Location = new System.Drawing.Point(6, 19);
			this.cmbPositioning.Name = "cmbPositioning";
			this.cmbPositioning.Size = new System.Drawing.Size(189, 21);
			this.cmbPositioning.TabIndex = 0;
			this.cmbPositioning.Text = null;
			this.cmbPositioning.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkGroupBox3
			//
			this.DarkGroupBox3.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox3.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox3.Controls.Add(this.DarkLabel7);
			this.DarkGroupBox3.Controls.Add(this.cmbMoveFreq);
			this.DarkGroupBox3.Controls.Add(this.DarkLabel6);
			this.DarkGroupBox3.Controls.Add(this.cmbMoveSpeed);
			this.DarkGroupBox3.Controls.Add(this.btnMoveRoute);
			this.DarkGroupBox3.Controls.Add(this.cmbMoveType);
			this.DarkGroupBox3.Controls.Add(this.DarkLabel5);
			this.DarkGroupBox3.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox3.Location = new System.Drawing.Point(183, 138);
			this.DarkGroupBox3.Name = "DarkGroupBox3";
			this.DarkGroupBox3.Size = new System.Drawing.Size(200, 123);
			this.DarkGroupBox3.TabIndex = 2;
			this.DarkGroupBox3.TabStop = false;
			this.DarkGroupBox3.Text = "Movement";
			//
			//DarkLabel7
			//
			this.DarkLabel7.AutoSize = true;
			this.DarkLabel7.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel7.Location = new System.Drawing.Point(6, 100);
			this.DarkLabel7.Name = "DarkLabel7";
			this.DarkLabel7.Size = new System.Drawing.Size(57, 13);
			this.DarkLabel7.TabIndex = 6;
			this.DarkLabel7.Text = "Frequency";
			//
			//cmbMoveFreq
			//
			this.cmbMoveFreq.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbMoveFreq.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbMoveFreq.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbMoveFreq.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbMoveFreq.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbMoveFreq.ButtonIcon"));
			this.cmbMoveFreq.DrawDropdownHoverOutline = false;
			this.cmbMoveFreq.DrawFocusRectangle = false;
			this.cmbMoveFreq.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbMoveFreq.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMoveFreq.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbMoveFreq.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbMoveFreq.FormattingEnabled = true;
			this.cmbMoveFreq.Items.AddRange(new object[] {"Lowest", "Lower", "Normal", "Higher", "Highest"});
			this.cmbMoveFreq.Location = new System.Drawing.Point(69, 97);
			this.cmbMoveFreq.Name = "cmbMoveFreq";
			this.cmbMoveFreq.Size = new System.Drawing.Size(125, 21);
			this.cmbMoveFreq.TabIndex = 5;
			this.cmbMoveFreq.Text = null;
			this.cmbMoveFreq.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel6
			//
			this.DarkLabel6.AutoSize = true;
			this.DarkLabel6.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel6.Location = new System.Drawing.Point(6, 73);
			this.DarkLabel6.Name = "DarkLabel6";
			this.DarkLabel6.Size = new System.Drawing.Size(41, 13);
			this.DarkLabel6.TabIndex = 4;
			this.DarkLabel6.Text = "Speed:";
			//
			//cmbMoveSpeed
			//
			this.cmbMoveSpeed.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbMoveSpeed.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbMoveSpeed.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbMoveSpeed.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbMoveSpeed.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbMoveSpeed.ButtonIcon"));
			this.cmbMoveSpeed.DrawDropdownHoverOutline = false;
			this.cmbMoveSpeed.DrawFocusRectangle = false;
			this.cmbMoveSpeed.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbMoveSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMoveSpeed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbMoveSpeed.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbMoveSpeed.FormattingEnabled = true;
			this.cmbMoveSpeed.Items.AddRange(new object[] {"8x Slower", "4x Slower", "2x Slower", "Normal", "2x Faster", "4x Faster"});
			this.cmbMoveSpeed.Location = new System.Drawing.Point(69, 70);
			this.cmbMoveSpeed.Name = "cmbMoveSpeed";
			this.cmbMoveSpeed.Size = new System.Drawing.Size(125, 21);
			this.cmbMoveSpeed.TabIndex = 3;
			this.cmbMoveSpeed.Text = null;
			this.cmbMoveSpeed.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//btnMoveRoute
			//
			this.btnMoveRoute.Location = new System.Drawing.Point(119, 41);
			this.btnMoveRoute.Name = "btnMoveRoute";
			this.btnMoveRoute.Padding = new System.Windows.Forms.Padding(5);
			this.btnMoveRoute.Size = new System.Drawing.Size(75, 23);
			this.btnMoveRoute.TabIndex = 2;
			this.btnMoveRoute.Text = "Move Route";
			//
			//cmbMoveType
			//
			this.cmbMoveType.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbMoveType.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbMoveType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbMoveType.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbMoveType.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbMoveType.ButtonIcon"));
			this.cmbMoveType.DrawDropdownHoverOutline = false;
			this.cmbMoveType.DrawFocusRectangle = false;
			this.cmbMoveType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbMoveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMoveType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbMoveType.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbMoveType.FormattingEnabled = true;
			this.cmbMoveType.Items.AddRange(new object[] {"Fixed Position", "Random", "Move Route"});
			this.cmbMoveType.Location = new System.Drawing.Point(69, 14);
			this.cmbMoveType.Name = "cmbMoveType";
			this.cmbMoveType.Size = new System.Drawing.Size(125, 21);
			this.cmbMoveType.TabIndex = 1;
			this.cmbMoveType.Text = null;
			this.cmbMoveType.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel5
			//
			this.DarkLabel5.AutoSize = true;
			this.DarkLabel5.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel5.Location = new System.Drawing.Point(6, 17);
			this.DarkLabel5.Name = "DarkLabel5";
			this.DarkLabel5.Size = new System.Drawing.Size(34, 13);
			this.DarkLabel5.TabIndex = 0;
			this.DarkLabel5.Text = "Type:";
			//
			//DarkGroupBox2
			//
			this.DarkGroupBox2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox2.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox2.Controls.Add(this.picGraphic);
			this.DarkGroupBox2.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox2.Location = new System.Drawing.Point(3, 138);
			this.DarkGroupBox2.Name = "DarkGroupBox2";
			this.DarkGroupBox2.Size = new System.Drawing.Size(173, 232);
			this.DarkGroupBox2.TabIndex = 1;
			this.DarkGroupBox2.TabStop = false;
			this.DarkGroupBox2.Text = "Graphic";
			//
			//picGraphic
			//
			this.picGraphic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.picGraphic.Location = new System.Drawing.Point(6, 19);
			this.picGraphic.Name = "picGraphic";
			this.picGraphic.Size = new System.Drawing.Size(161, 207);
			this.picGraphic.TabIndex = 1;
			this.picGraphic.TabStop = false;
			//
			//DarkGroupBox1
			//
			this.DarkGroupBox1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox1.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox1.Controls.Add(this.cmbSelfSwitchCompare);
			this.DarkGroupBox1.Controls.Add(this.DarkLabel4);
			this.DarkGroupBox1.Controls.Add(this.cmbSelfSwitch);
			this.DarkGroupBox1.Controls.Add(this.chkSelfSwitch);
			this.DarkGroupBox1.Controls.Add(this.cmbHasItem);
			this.DarkGroupBox1.Controls.Add(this.chkHasItem);
			this.DarkGroupBox1.Controls.Add(this.cmbPlayerSwitchCompare);
			this.DarkGroupBox1.Controls.Add(this.DarkLabel3);
			this.DarkGroupBox1.Controls.Add(this.cmbPlayerSwitch);
			this.DarkGroupBox1.Controls.Add(this.chkPlayerSwitch);
			this.DarkGroupBox1.Controls.Add(this.nudPlayerVariable);
			this.DarkGroupBox1.Controls.Add(this.cmbPlayervarCompare);
			this.DarkGroupBox1.Controls.Add(this.DarkLabel2);
			this.DarkGroupBox1.Controls.Add(this.cmbPlayerVar);
			this.DarkGroupBox1.Controls.Add(this.chkPlayerVar);
			this.DarkGroupBox1.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox1.Location = new System.Drawing.Point(3, 6);
			this.DarkGroupBox1.Name = "DarkGroupBox1";
			this.DarkGroupBox1.Size = new System.Drawing.Size(380, 126);
			this.DarkGroupBox1.TabIndex = 0;
			this.DarkGroupBox1.TabStop = false;
			this.DarkGroupBox1.Text = "Conditions";
			//
			//cmbSelfSwitchCompare
			//
			this.cmbSelfSwitchCompare.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbSelfSwitchCompare.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbSelfSwitchCompare.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbSelfSwitchCompare.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbSelfSwitchCompare.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbSelfSwitchCompare.ButtonIcon"));
			this.cmbSelfSwitchCompare.DrawDropdownHoverOutline = false;
			this.cmbSelfSwitchCompare.DrawFocusRectangle = false;
			this.cmbSelfSwitchCompare.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbSelfSwitchCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSelfSwitchCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbSelfSwitchCompare.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbSelfSwitchCompare.FormattingEnabled = true;
			this.cmbSelfSwitchCompare.Items.AddRange(new object[] {"False = 0", "True = 1"});
			this.cmbSelfSwitchCompare.Location = new System.Drawing.Point(223, 98);
			this.cmbSelfSwitchCompare.Name = "cmbSelfSwitchCompare";
			this.cmbSelfSwitchCompare.Size = new System.Drawing.Size(89, 21);
			this.cmbSelfSwitchCompare.TabIndex = 14;
			this.cmbSelfSwitchCompare.Text = null;
			this.cmbSelfSwitchCompare.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel4
			//
			this.DarkLabel4.AutoSize = true;
			this.DarkLabel4.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel4.Location = new System.Drawing.Point(203, 101);
			this.DarkLabel4.Name = "DarkLabel4";
			this.DarkLabel4.Size = new System.Drawing.Size(14, 13);
			this.DarkLabel4.TabIndex = 13;
			this.DarkLabel4.Text = "is";
			//
			//cmbSelfSwitch
			//
			this.cmbSelfSwitch.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbSelfSwitch.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbSelfSwitch.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbSelfSwitch.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbSelfSwitch.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbSelfSwitch.ButtonIcon"));
			this.cmbSelfSwitch.DrawDropdownHoverOutline = false;
			this.cmbSelfSwitch.DrawFocusRectangle = false;
			this.cmbSelfSwitch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbSelfSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSelfSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbSelfSwitch.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbSelfSwitch.FormattingEnabled = true;
			this.cmbSelfSwitch.Items.AddRange(new object[] {"None", "1 - A", "2 - B", "3 - C", "4 - D"});
			this.cmbSelfSwitch.Location = new System.Drawing.Point(108, 98);
			this.cmbSelfSwitch.Name = "cmbSelfSwitch";
			this.cmbSelfSwitch.Size = new System.Drawing.Size(89, 21);
			this.cmbSelfSwitch.TabIndex = 12;
			this.cmbSelfSwitch.Text = null;
			this.cmbSelfSwitch.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//chkSelfSwitch
			//
			this.chkSelfSwitch.AutoSize = true;
			this.chkSelfSwitch.Location = new System.Drawing.Point(6, 100);
			this.chkSelfSwitch.Name = "chkSelfSwitch";
			this.chkSelfSwitch.Size = new System.Drawing.Size(83, 17);
			this.chkSelfSwitch.TabIndex = 11;
			this.chkSelfSwitch.Text = "Self Switch*";
			//
			//cmbHasItem
			//
			this.cmbHasItem.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbHasItem.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbHasItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbHasItem.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbHasItem.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbHasItem.ButtonIcon"));
			this.cmbHasItem.DrawDropdownHoverOutline = false;
			this.cmbHasItem.DrawFocusRectangle = false;
			this.cmbHasItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbHasItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbHasItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbHasItem.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbHasItem.FormattingEnabled = true;
			this.cmbHasItem.Location = new System.Drawing.Point(108, 71);
			this.cmbHasItem.Name = "cmbHasItem";
			this.cmbHasItem.Size = new System.Drawing.Size(204, 21);
			this.cmbHasItem.TabIndex = 10;
			this.cmbHasItem.Text = null;
			this.cmbHasItem.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//chkHasItem
			//
			this.chkHasItem.AutoSize = true;
			this.chkHasItem.Location = new System.Drawing.Point(6, 73);
			this.chkHasItem.Name = "chkHasItem";
			this.chkHasItem.Size = new System.Drawing.Size(98, 17);
			this.chkHasItem.TabIndex = 9;
			this.chkHasItem.Text = "Player has Item";
			//
			//cmbPlayerSwitchCompare
			//
			this.cmbPlayerSwitchCompare.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbPlayerSwitchCompare.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbPlayerSwitchCompare.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbPlayerSwitchCompare.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbPlayerSwitchCompare.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbPlayerSwitchCompare.ButtonIcon"));
			this.cmbPlayerSwitchCompare.DrawDropdownHoverOutline = false;
			this.cmbPlayerSwitchCompare.DrawFocusRectangle = false;
			this.cmbPlayerSwitchCompare.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPlayerSwitchCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPlayerSwitchCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPlayerSwitchCompare.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbPlayerSwitchCompare.FormattingEnabled = true;
			this.cmbPlayerSwitchCompare.Items.AddRange(new object[] {"False = 0", "True = 1"});
			this.cmbPlayerSwitchCompare.Location = new System.Drawing.Point(223, 44);
			this.cmbPlayerSwitchCompare.Name = "cmbPlayerSwitchCompare";
			this.cmbPlayerSwitchCompare.Size = new System.Drawing.Size(89, 21);
			this.cmbPlayerSwitchCompare.TabIndex = 8;
			this.cmbPlayerSwitchCompare.Text = null;
			this.cmbPlayerSwitchCompare.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel3
			//
			this.DarkLabel3.AutoSize = true;
			this.DarkLabel3.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel3.Location = new System.Drawing.Point(203, 47);
			this.DarkLabel3.Name = "DarkLabel3";
			this.DarkLabel3.Size = new System.Drawing.Size(14, 13);
			this.DarkLabel3.TabIndex = 7;
			this.DarkLabel3.Text = "is";
			//
			//cmbPlayerSwitch
			//
			this.cmbPlayerSwitch.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbPlayerSwitch.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbPlayerSwitch.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbPlayerSwitch.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbPlayerSwitch.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbPlayerSwitch.ButtonIcon"));
			this.cmbPlayerSwitch.DrawDropdownHoverOutline = false;
			this.cmbPlayerSwitch.DrawFocusRectangle = false;
			this.cmbPlayerSwitch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPlayerSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPlayerSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPlayerSwitch.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbPlayerSwitch.FormattingEnabled = true;
			this.cmbPlayerSwitch.Location = new System.Drawing.Point(108, 44);
			this.cmbPlayerSwitch.Name = "cmbPlayerSwitch";
			this.cmbPlayerSwitch.Size = new System.Drawing.Size(89, 21);
			this.cmbPlayerSwitch.TabIndex = 6;
			this.cmbPlayerSwitch.Text = null;
			this.cmbPlayerSwitch.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//chkPlayerSwitch
			//
			this.chkPlayerSwitch.AutoSize = true;
			this.chkPlayerSwitch.Location = new System.Drawing.Point(6, 46);
			this.chkPlayerSwitch.Name = "chkPlayerSwitch";
			this.chkPlayerSwitch.Size = new System.Drawing.Size(90, 17);
			this.chkPlayerSwitch.TabIndex = 5;
			this.chkPlayerSwitch.Text = "Player Switch";
			//
			//nudPlayerVariable
			//
			this.nudPlayerVariable.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudPlayerVariable.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudPlayerVariable.Location = new System.Drawing.Point(318, 18);
			this.nudPlayerVariable.Name = "nudPlayerVariable";
			this.nudPlayerVariable.Size = new System.Drawing.Size(56, 20);
			this.nudPlayerVariable.TabIndex = 4;
			//
			//cmbPlayervarCompare
			//
			this.cmbPlayervarCompare.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbPlayervarCompare.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbPlayervarCompare.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbPlayervarCompare.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbPlayervarCompare.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbPlayervarCompare.ButtonIcon"));
			this.cmbPlayervarCompare.DrawDropdownHoverOutline = false;
			this.cmbPlayervarCompare.DrawFocusRectangle = false;
			this.cmbPlayervarCompare.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPlayervarCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPlayervarCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPlayervarCompare.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbPlayervarCompare.FormattingEnabled = true;
			this.cmbPlayervarCompare.Items.AddRange(new object[] {"Equal To", "Great Than OrElse Equal To", "Less Than or Equal To", "Greater Than", "Less Than", "Does Not Equal"});
			this.cmbPlayervarCompare.Location = new System.Drawing.Point(223, 17);
			this.cmbPlayervarCompare.Name = "cmbPlayervarCompare";
			this.cmbPlayervarCompare.Size = new System.Drawing.Size(89, 21);
			this.cmbPlayervarCompare.TabIndex = 3;
			this.cmbPlayervarCompare.Text = null;
			this.cmbPlayervarCompare.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel2
			//
			this.DarkLabel2.AutoSize = true;
			this.DarkLabel2.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel2.Location = new System.Drawing.Point(203, 23);
			this.DarkLabel2.Name = "DarkLabel2";
			this.DarkLabel2.Size = new System.Drawing.Size(14, 13);
			this.DarkLabel2.TabIndex = 2;
			this.DarkLabel2.Text = "is";
			//
			//cmbPlayerVar
			//
			this.cmbPlayerVar.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbPlayerVar.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbPlayerVar.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbPlayerVar.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbPlayerVar.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbPlayerVar.ButtonIcon"));
			this.cmbPlayerVar.DrawDropdownHoverOutline = false;
			this.cmbPlayerVar.DrawFocusRectangle = false;
			this.cmbPlayerVar.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPlayerVar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPlayerVar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPlayerVar.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbPlayerVar.FormattingEnabled = true;
			this.cmbPlayerVar.Location = new System.Drawing.Point(108, 17);
			this.cmbPlayerVar.Name = "cmbPlayerVar";
			this.cmbPlayerVar.Size = new System.Drawing.Size(89, 21);
			this.cmbPlayerVar.TabIndex = 1;
			this.cmbPlayerVar.Text = null;
			this.cmbPlayerVar.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//chkPlayerVar
			//
			this.chkPlayerVar.AutoSize = true;
			this.chkPlayerVar.Location = new System.Drawing.Point(6, 19);
			this.chkPlayerVar.Name = "chkPlayerVar";
			this.chkPlayerVar.Size = new System.Drawing.Size(96, 17);
			this.chkPlayerVar.TabIndex = 0;
			this.chkPlayerVar.Text = "Player Variable";
			//
			//DarkGroupBox6
			//
			this.DarkGroupBox6.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox6.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox6.Controls.Add(this.chkShowName);
			this.DarkGroupBox6.Controls.Add(this.chkWalkThrough);
			this.DarkGroupBox6.Controls.Add(this.chkDirFix);
			this.DarkGroupBox6.Controls.Add(this.chkWalkAnim);
			this.DarkGroupBox6.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox6.Location = new System.Drawing.Point(3, 457);
			this.DarkGroupBox6.Name = "DarkGroupBox6";
			this.DarkGroupBox6.Size = new System.Drawing.Size(176, 112);
			this.DarkGroupBox6.TabIndex = 5;
			this.DarkGroupBox6.TabStop = false;
			this.DarkGroupBox6.Text = "Options";
			//
			//chkShowName
			//
			this.chkShowName.AutoSize = true;
			this.chkShowName.Location = new System.Drawing.Point(6, 88);
			this.chkShowName.Name = "chkShowName";
			this.chkShowName.Size = new System.Drawing.Size(84, 17);
			this.chkShowName.TabIndex = 3;
			this.chkShowName.Text = "Show Name";
			//
			//chkWalkThrough
			//
			this.chkWalkThrough.AutoSize = true;
			this.chkWalkThrough.Location = new System.Drawing.Point(6, 65);
			this.chkWalkThrough.Name = "chkWalkThrough";
			this.chkWalkThrough.Size = new System.Drawing.Size(94, 17);
			this.chkWalkThrough.TabIndex = 2;
			this.chkWalkThrough.Text = "Walk Through";
			//
			//chkDirFix
			//
			this.chkDirFix.AutoSize = true;
			this.chkDirFix.Location = new System.Drawing.Point(6, 42);
			this.chkDirFix.Name = "chkDirFix";
			this.chkDirFix.Size = new System.Drawing.Size(96, 17);
			this.chkDirFix.TabIndex = 1;
			this.chkDirFix.Text = "Direction Fixed";
			//
			//chkWalkAnim
			//
			this.chkWalkAnim.AutoSize = true;
			this.chkWalkAnim.Location = new System.Drawing.Point(6, 19);
			this.chkWalkAnim.Name = "chkWalkAnim";
			this.chkWalkAnim.Size = new System.Drawing.Size(117, 17);
			this.chkWalkAnim.TabIndex = 0;
			this.chkWalkAnim.Text = "No Walk Animation";
			//
			//btnLabeling
			//
			this.btnLabeling.Location = new System.Drawing.Point(3, 584);
			this.btnLabeling.Name = "btnLabeling";
			this.btnLabeling.Padding = new System.Windows.Forms.Padding(5);
			this.btnLabeling.Size = new System.Drawing.Size(170, 23);
			this.btnLabeling.TabIndex = 6;
			this.btnLabeling.Text = "Edit Variables/Switches";
			//
			//btnCancel
			//
			this.btnCancel.Location = new System.Drawing.Point(719, 584);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 7;
			this.btnCancel.Text = "Cancel";
			//
			//btnOk
			//
			this.btnOk.Location = new System.Drawing.Point(638, 584);
			this.btnOk.Name = "btnOk";
			this.btnOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnOk.Size = new System.Drawing.Size(75, 23);
			this.btnOk.TabIndex = 8;
			this.btnOk.Text = "Ok";
			//
			//fraMoveRoute
			//
			this.fraMoveRoute.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraMoveRoute.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraMoveRoute.Controls.Add(this.btnMoveRouteOk);
			this.fraMoveRoute.Controls.Add(this.btnMoveRouteCancel);
			this.fraMoveRoute.Controls.Add(this.chkRepeatRoute);
			this.fraMoveRoute.Controls.Add(this.chkIgnoreMove);
			this.fraMoveRoute.Controls.Add(this.DarkGroupBox10);
			this.fraMoveRoute.Controls.Add(this.lstMoveRoute);
			this.fraMoveRoute.Controls.Add(this.cmbEvent);
			this.fraMoveRoute.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraMoveRoute.Location = new System.Drawing.Point(800, 12);
			this.fraMoveRoute.Name = "fraMoveRoute";
			this.fraMoveRoute.Size = new System.Drawing.Size(93, 85);
			this.fraMoveRoute.TabIndex = 0;
			this.fraMoveRoute.TabStop = false;
			this.fraMoveRoute.Text = "Move Route";
			this.fraMoveRoute.Visible = false;
			//
			//btnMoveRouteOk
			//
			this.btnMoveRouteOk.Location = new System.Drawing.Point(642, 431);
			this.btnMoveRouteOk.Name = "btnMoveRouteOk";
			this.btnMoveRouteOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnMoveRouteOk.Size = new System.Drawing.Size(75, 23);
			this.btnMoveRouteOk.TabIndex = 7;
			this.btnMoveRouteOk.Text = "Ok";
			//
			//btnMoveRouteCancel
			//
			this.btnMoveRouteCancel.Location = new System.Drawing.Point(723, 431);
			this.btnMoveRouteCancel.Name = "btnMoveRouteCancel";
			this.btnMoveRouteCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnMoveRouteCancel.Size = new System.Drawing.Size(75, 23);
			this.btnMoveRouteCancel.TabIndex = 6;
			this.btnMoveRouteCancel.Text = "Cancel";
			//
			//chkRepeatRoute
			//
			this.chkRepeatRoute.AutoSize = true;
			this.chkRepeatRoute.Location = new System.Drawing.Point(6, 454);
			this.chkRepeatRoute.Name = "chkRepeatRoute";
			this.chkRepeatRoute.Size = new System.Drawing.Size(93, 17);
			this.chkRepeatRoute.TabIndex = 5;
			this.chkRepeatRoute.Text = "Repeat Route";
			//
			//chkIgnoreMove
			//
			this.chkIgnoreMove.AutoSize = true;
			this.chkIgnoreMove.Location = new System.Drawing.Point(6, 431);
			this.chkIgnoreMove.Name = "chkIgnoreMove";
			this.chkIgnoreMove.Size = new System.Drawing.Size(149, 17);
			this.chkIgnoreMove.TabIndex = 4;
			this.chkIgnoreMove.Text = "Ignore if event can't move";
			//
			//DarkGroupBox10
			//
			this.DarkGroupBox10.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.DarkGroupBox10.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.DarkGroupBox10.Controls.Add(this.lstvwMoveRoute);
			this.DarkGroupBox10.ForeColor = System.Drawing.Color.Gainsboro;
			this.DarkGroupBox10.Location = new System.Drawing.Point(203, 10);
			this.DarkGroupBox10.Name = "DarkGroupBox10";
			this.DarkGroupBox10.Size = new System.Drawing.Size(595, 415);
			this.DarkGroupBox10.TabIndex = 3;
			this.DarkGroupBox10.TabStop = false;
			this.DarkGroupBox10.Text = "Commands";
			//
			//lstvwMoveRoute
			//
			this.lstvwMoveRoute.AutoArrange = false;
			this.lstvwMoveRoute.BackColor = System.Drawing.Color.DimGray;
			this.lstvwMoveRoute.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lstvwMoveRoute.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.ColumnHeader3, this.ColumnHeader4});
			this.lstvwMoveRoute.Dock = System.Windows.Forms.DockStyle.Top;
			this.lstvwMoveRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.lstvwMoveRoute.ForeColor = System.Drawing.Color.Gainsboro;
			ListViewGroup10.Header = "Movement";
			ListViewGroup10.Name = "lstVgMovement";
			ListViewGroup11.Header = "Wait";
			ListViewGroup11.Name = "lstVgWait";
			ListViewGroup12.Header = "Turning";
			ListViewGroup12.Name = "lstVgTurn";
			ListViewGroup13.Header = "Speed";
			ListViewGroup13.Name = "lstVgSpeed";
			ListViewGroup14.Header = "Walk Animation";
			ListViewGroup14.Name = "lstVgWalk";
			ListViewGroup15.Header = "Fixed Direction";
			ListViewGroup15.Name = "lstVgDirection";
			ListViewGroup16.Header = "WalkThrough";
			ListViewGroup16.Name = "lstVgWalkThrough";
			ListViewGroup17.Header = "Set Position";
			ListViewGroup17.Name = "lstVgSetposition";
			ListViewGroup18.Header = "Set Graphic";
			ListViewGroup18.Name = "lstVgSetGraphic";
			this.lstvwMoveRoute.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {ListViewGroup10, ListViewGroup11, ListViewGroup12, ListViewGroup13, ListViewGroup14, ListViewGroup15, ListViewGroup16, ListViewGroup17, ListViewGroup18});
			this.lstvwMoveRoute.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			ListViewItem44.Group = ListViewGroup10;
			ListViewItem45.Group = ListViewGroup10;
			ListViewItem45.IndentCount = 1;
			ListViewItem46.Group = ListViewGroup10;
			ListViewItem47.Group = ListViewGroup10;
			ListViewItem47.IndentCount = 1;
			ListViewItem48.Group = ListViewGroup10;
			ListViewItem49.Group = ListViewGroup10;
			ListViewItem50.Group = ListViewGroup10;
			ListViewItem51.Group = ListViewGroup10;
			ListViewItem52.Group = ListViewGroup10;
			ListViewItem53.Group = ListViewGroup11;
			ListViewItem54.Group = ListViewGroup11;
			ListViewItem55.Group = ListViewGroup11;
			ListViewItem56.Group = ListViewGroup12;
			ListViewItem57.Group = ListViewGroup12;
			ListViewItem58.Group = ListViewGroup12;
			ListViewItem59.Group = ListViewGroup12;
			ListViewItem60.Group = ListViewGroup12;
			ListViewItem61.Group = ListViewGroup12;
			ListViewItem62.Group = ListViewGroup12;
			ListViewItem63.Group = ListViewGroup12;
			ListViewItem64.Group = ListViewGroup12;
			ListViewItem65.Group = ListViewGroup12;
			ListViewItem66.Group = ListViewGroup13;
			ListViewItem67.Group = ListViewGroup13;
			ListViewItem68.Group = ListViewGroup13;
			ListViewItem69.Group = ListViewGroup13;
			ListViewItem70.Group = ListViewGroup13;
			ListViewItem71.Group = ListViewGroup13;
			ListViewItem72.Group = ListViewGroup13;
			ListViewItem73.Group = ListViewGroup13;
			ListViewItem74.Group = ListViewGroup13;
			ListViewItem75.Group = ListViewGroup13;
			ListViewItem76.Group = ListViewGroup13;
			ListViewItem77.Group = ListViewGroup14;
			ListViewItem78.Group = ListViewGroup14;
			ListViewItem79.Group = ListViewGroup15;
			ListViewItem80.Group = ListViewGroup15;
			ListViewItem81.Group = ListViewGroup16;
			ListViewItem82.Group = ListViewGroup16;
			ListViewItem83.Group = ListViewGroup17;
			ListViewItem84.Group = ListViewGroup17;
			ListViewItem85.Group = ListViewGroup17;
			ListViewItem86.Group = ListViewGroup18;
			this.lstvwMoveRoute.Items.AddRange(new System.Windows.Forms.ListViewItem[] {ListViewItem44, ListViewItem45, ListViewItem46, ListViewItem47, ListViewItem48, ListViewItem49, ListViewItem50, ListViewItem51, ListViewItem52, ListViewItem53, ListViewItem54, ListViewItem55, ListViewItem56, ListViewItem57, ListViewItem58, ListViewItem59, ListViewItem60, ListViewItem61, ListViewItem62, ListViewItem63, ListViewItem64, ListViewItem65, ListViewItem66, ListViewItem67, ListViewItem68, ListViewItem69, ListViewItem70, ListViewItem71, ListViewItem72, ListViewItem73, ListViewItem74, ListViewItem75, ListViewItem76, ListViewItem77, ListViewItem78, ListViewItem79, ListViewItem80, ListViewItem81, ListViewItem82, ListViewItem83, ListViewItem84, ListViewItem85, ListViewItem86});
			this.lstvwMoveRoute.LabelWrap = false;
			this.lstvwMoveRoute.Location = new System.Drawing.Point(3, 16);
			this.lstvwMoveRoute.MultiSelect = false;
			this.lstvwMoveRoute.Name = "lstvwMoveRoute";
			this.lstvwMoveRoute.Size = new System.Drawing.Size(589, 397);
			this.lstvwMoveRoute.TabIndex = 5;
			this.lstvwMoveRoute.UseCompatibleStateImageBehavior = false;
			this.lstvwMoveRoute.View = System.Windows.Forms.View.Tile;
			//
			//ColumnHeader3
			//
			this.ColumnHeader3.Text = "";
			this.ColumnHeader3.Width = 150;
			//
			//ColumnHeader4
			//
			this.ColumnHeader4.Text = "";
			this.ColumnHeader4.Width = 150;
			//
			//lstMoveRoute
			//
			this.lstMoveRoute.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.lstMoveRoute.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstMoveRoute.ForeColor = System.Drawing.Color.Gainsboro;
			this.lstMoveRoute.FormattingEnabled = true;
			this.lstMoveRoute.Location = new System.Drawing.Point(6, 46);
			this.lstMoveRoute.Name = "lstMoveRoute";
			this.lstMoveRoute.Size = new System.Drawing.Size(191, 379);
			this.lstMoveRoute.TabIndex = 2;
			//
			//cmbEvent
			//
			this.cmbEvent.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbEvent.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbEvent.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbEvent.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbEvent.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbEvent.ButtonIcon"));
			this.cmbEvent.DrawDropdownHoverOutline = false;
			this.cmbEvent.DrawFocusRectangle = false;
			this.cmbEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbEvent.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbEvent.FormattingEnabled = true;
			this.cmbEvent.Location = new System.Drawing.Point(6, 19);
			this.cmbEvent.Name = "cmbEvent";
			this.cmbEvent.Size = new System.Drawing.Size(191, 21);
			this.cmbEvent.TabIndex = 0;
			this.cmbEvent.Text = null;
			this.cmbEvent.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//fraGraphic
			//
			this.fraGraphic.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraGraphic.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraGraphic.Controls.Add(this.pnlGraphicSel);
			this.fraGraphic.Controls.Add(this.btnGraphicOk);
			this.fraGraphic.Controls.Add(this.btnGraphicCancel);
			this.fraGraphic.Controls.Add(this.DarkLabel13);
			this.fraGraphic.Controls.Add(this.nudGraphic);
			this.fraGraphic.Controls.Add(this.DarkLabel12);
			this.fraGraphic.Controls.Add(this.cmbGraphic);
			this.fraGraphic.Controls.Add(this.DarkLabel11);
			this.fraGraphic.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraGraphic.Location = new System.Drawing.Point(806, 113);
			this.fraGraphic.Name = "fraGraphic";
			this.fraGraphic.Size = new System.Drawing.Size(78, 72);
			this.fraGraphic.TabIndex = 9;
			this.fraGraphic.TabStop = false;
			this.fraGraphic.Text = "Graphic Selection";
			this.fraGraphic.Visible = false;
			//
			//pnlGraphicSel
			//
			this.pnlGraphicSel.AutoScroll = true;
			this.pnlGraphicSel.Controls.Add(this.picGraphicSel);
			this.pnlGraphicSel.Location = new System.Drawing.Point(6, 45);
			this.pnlGraphicSel.Name = "pnlGraphicSel";
			this.pnlGraphicSel.Size = new System.Drawing.Size(808, 519);
			this.pnlGraphicSel.TabIndex = 9;
			//
			//picGraphicSel
			//
			this.picGraphicSel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.picGraphicSel.Location = new System.Drawing.Point(0, 0);
			this.picGraphicSel.Name = "picGraphicSel";
			this.picGraphicSel.Size = new System.Drawing.Size(802, 514);
			this.picGraphicSel.TabIndex = 5;
			this.picGraphicSel.TabStop = false;
			//
			//btnGraphicOk
			//
			this.btnGraphicOk.Location = new System.Drawing.Point(652, 570);
			this.btnGraphicOk.Name = "btnGraphicOk";
			this.btnGraphicOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnGraphicOk.Size = new System.Drawing.Size(75, 23);
			this.btnGraphicOk.TabIndex = 8;
			this.btnGraphicOk.Text = "Ok";
			//
			//btnGraphicCancel
			//
			this.btnGraphicCancel.Location = new System.Drawing.Point(733, 570);
			this.btnGraphicCancel.Name = "btnGraphicCancel";
			this.btnGraphicCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnGraphicCancel.Size = new System.Drawing.Size(75, 23);
			this.btnGraphicCancel.TabIndex = 7;
			this.btnGraphicCancel.Text = "Cancel";
			//
			//DarkLabel13
			//
			this.DarkLabel13.AutoSize = true;
			this.DarkLabel13.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel13.Location = new System.Drawing.Point(9, 571);
			this.DarkLabel13.Name = "DarkLabel13";
			this.DarkLabel13.Size = new System.Drawing.Size(158, 13);
			this.DarkLabel13.TabIndex = 6;
			this.DarkLabel13.Text = "Hold Shift to select multiple tiles.";
			//
			//nudGraphic
			//
			this.nudGraphic.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudGraphic.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudGraphic.Location = new System.Drawing.Point(380, 19);
			this.nudGraphic.Name = "nudGraphic";
			this.nudGraphic.Size = new System.Drawing.Size(120, 20);
			this.nudGraphic.TabIndex = 3;
			//
			//DarkLabel12
			//
			this.DarkLabel12.AutoSize = true;
			this.DarkLabel12.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel12.Location = new System.Drawing.Point(327, 21);
			this.DarkLabel12.Name = "DarkLabel12";
			this.DarkLabel12.Size = new System.Drawing.Size(47, 13);
			this.DarkLabel12.TabIndex = 2;
			this.DarkLabel12.Text = "Number:";
			//
			//cmbGraphic
			//
			this.cmbGraphic.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbGraphic.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbGraphic.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbGraphic.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbGraphic.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbGraphic.ButtonIcon"));
			this.cmbGraphic.DrawDropdownHoverOutline = false;
			this.cmbGraphic.DrawFocusRectangle = false;
			this.cmbGraphic.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbGraphic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbGraphic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbGraphic.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbGraphic.FormattingEnabled = true;
			this.cmbGraphic.Items.AddRange(new object[] {"None", "Character", "Tileset"});
			this.cmbGraphic.Location = new System.Drawing.Point(104, 18);
			this.cmbGraphic.Name = "cmbGraphic";
			this.cmbGraphic.Size = new System.Drawing.Size(217, 21);
			this.cmbGraphic.TabIndex = 1;
			this.cmbGraphic.Text = null;
			this.cmbGraphic.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel11
			//
			this.DarkLabel11.AutoSize = true;
			this.DarkLabel11.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel11.Location = new System.Drawing.Point(19, 21);
			this.DarkLabel11.Name = "DarkLabel11";
			this.DarkLabel11.Size = new System.Drawing.Size(79, 13);
			this.DarkLabel11.TabIndex = 0;
			this.DarkLabel11.Text = "Graphics Type:";
			//
			//fraDialogue
			//
			this.fraDialogue.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraDialogue.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraDialogue.Controls.Add(this.fraConditionalBranch);
			this.fraDialogue.Controls.Add(this.fraPlayAnimation);
			this.fraDialogue.Controls.Add(this.fraMoveRouteWait);
			this.fraDialogue.Controls.Add(this.fraCustomScript);
			this.fraDialogue.Controls.Add(this.fraSetWeather);
			this.fraDialogue.Controls.Add(this.fraSpawnNpc);
			this.fraDialogue.Controls.Add(this.fraGiveExp);
			this.fraDialogue.Controls.Add(this.fraEndQuest);
			this.fraDialogue.Controls.Add(this.fraSetAccess);
			this.fraDialogue.Controls.Add(this.fraSetWait);
			this.fraDialogue.Controls.Add(this.fraShowPic);
			this.fraDialogue.Controls.Add(this.fraOpenShop);
			this.fraDialogue.Controls.Add(this.fraChangeLevel);
			this.fraDialogue.Controls.Add(this.fraChangeGender);
			this.fraDialogue.Controls.Add(this.fraGoToLabel);
			this.fraDialogue.Controls.Add(this.fraHidePic);
			this.fraDialogue.Controls.Add(this.fraBeginQuest);
			this.fraDialogue.Controls.Add(this.fraShowChoices);
			this.fraDialogue.Controls.Add(this.fraPlayerVariable);
			this.fraDialogue.Controls.Add(this.fraChangeSprite);
			this.fraDialogue.Controls.Add(this.fraSetSelfSwitch);
			this.fraDialogue.Controls.Add(this.fraMapTint);
			this.fraDialogue.Controls.Add(this.fraShowChatBubble);
			this.fraDialogue.Controls.Add(this.fraPlaySound);
			this.fraDialogue.Controls.Add(this.fraChangePK);
			this.fraDialogue.Controls.Add(this.fraCreateLabel);
			this.fraDialogue.Controls.Add(this.fraChangeClass);
			this.fraDialogue.Controls.Add(this.fraChangeSkills);
			this.fraDialogue.Controls.Add(this.fraCompleteTask);
			this.fraDialogue.Controls.Add(this.fraPlayerWarp);
			this.fraDialogue.Controls.Add(this.fraSetFog);
			this.fraDialogue.Controls.Add(this.fraShowText);
			this.fraDialogue.Controls.Add(this.fraAddText);
			this.fraDialogue.Controls.Add(this.fraPlayerSwitch);
			this.fraDialogue.Controls.Add(this.fraChangeItems);
			this.fraDialogue.Controls.Add(this.fraPlayBGM);
			this.fraDialogue.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraDialogue.Location = new System.Drawing.Point(905, 12);
			this.fraDialogue.Name = "fraDialogue";
			this.fraDialogue.Size = new System.Drawing.Size(665, 595);
			this.fraDialogue.TabIndex = 10;
			this.fraDialogue.TabStop = false;
			this.fraDialogue.Visible = false;
			//
			//fraPlayAnimation
			//
			this.fraPlayAnimation.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraPlayAnimation.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraPlayAnimation.Controls.Add(this.btnPlayAnimationOk);
			this.fraPlayAnimation.Controls.Add(this.btnPlayAnimationCancel);
			this.fraPlayAnimation.Controls.Add(this.lblPlayAnimY);
			this.fraPlayAnimation.Controls.Add(this.lblPlayAnimX);
			this.fraPlayAnimation.Controls.Add(this.cmbPlayAnimEvent);
			this.fraPlayAnimation.Controls.Add(this.DarkLabel62);
			this.fraPlayAnimation.Controls.Add(this.cmbAnimTargetType);
			this.fraPlayAnimation.Controls.Add(this.nudPlayAnimTileY);
			this.fraPlayAnimation.Controls.Add(this.nudPlayAnimTileX);
			this.fraPlayAnimation.Controls.Add(this.DarkLabel61);
			this.fraPlayAnimation.Controls.Add(this.cmbPlayAnim);
			this.fraPlayAnimation.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraPlayAnimation.Location = new System.Drawing.Point(401, 257);
			this.fraPlayAnimation.Name = "fraPlayAnimation";
			this.fraPlayAnimation.Size = new System.Drawing.Size(248, 162);
			this.fraPlayAnimation.TabIndex = 36;
			this.fraPlayAnimation.TabStop = false;
			this.fraPlayAnimation.Text = "Play Animation";
			this.fraPlayAnimation.Visible = false;
			//
			//btnPlayAnimationOk
			//
			this.btnPlayAnimationOk.Location = new System.Drawing.Point(86, 132);
			this.btnPlayAnimationOk.Name = "btnPlayAnimationOk";
			this.btnPlayAnimationOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnPlayAnimationOk.Size = new System.Drawing.Size(75, 23);
			this.btnPlayAnimationOk.TabIndex = 36;
			this.btnPlayAnimationOk.Text = "Ok";
			//
			//btnPlayAnimationCancel
			//
			this.btnPlayAnimationCancel.Location = new System.Drawing.Point(167, 132);
			this.btnPlayAnimationCancel.Name = "btnPlayAnimationCancel";
			this.btnPlayAnimationCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnPlayAnimationCancel.Size = new System.Drawing.Size(75, 23);
			this.btnPlayAnimationCancel.TabIndex = 35;
			this.btnPlayAnimationCancel.Text = "Cancel";
			//
			//lblPlayAnimY
			//
			this.lblPlayAnimY.AutoSize = true;
			this.lblPlayAnimY.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.lblPlayAnimY.Location = new System.Drawing.Point(131, 106);
			this.lblPlayAnimY.Name = "lblPlayAnimY";
			this.lblPlayAnimY.Size = new System.Drawing.Size(61, 13);
			this.lblPlayAnimY.TabIndex = 34;
			this.lblPlayAnimY.Text = "Map Tile Y:";
			//
			//lblPlayAnimX
			//
			this.lblPlayAnimX.AutoSize = true;
			this.lblPlayAnimX.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.lblPlayAnimX.Location = new System.Drawing.Point(6, 106);
			this.lblPlayAnimX.Name = "lblPlayAnimX";
			this.lblPlayAnimX.Size = new System.Drawing.Size(61, 13);
			this.lblPlayAnimX.TabIndex = 33;
			this.lblPlayAnimX.Text = "Map Tile X:";
			//
			//cmbPlayAnimEvent
			//
			this.cmbPlayAnimEvent.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbPlayAnimEvent.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbPlayAnimEvent.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbPlayAnimEvent.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbPlayAnimEvent.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbPlayAnimEvent.ButtonIcon"));
			this.cmbPlayAnimEvent.DrawDropdownHoverOutline = false;
			this.cmbPlayAnimEvent.DrawFocusRectangle = false;
			this.cmbPlayAnimEvent.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPlayAnimEvent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPlayAnimEvent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPlayAnimEvent.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbPlayAnimEvent.FormattingEnabled = true;
			this.cmbPlayAnimEvent.Location = new System.Drawing.Point(83, 73);
			this.cmbPlayAnimEvent.Name = "cmbPlayAnimEvent";
			this.cmbPlayAnimEvent.Size = new System.Drawing.Size(159, 21);
			this.cmbPlayAnimEvent.TabIndex = 32;
			this.cmbPlayAnimEvent.Text = null;
			this.cmbPlayAnimEvent.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel62
			//
			this.DarkLabel62.AutoSize = true;
			this.DarkLabel62.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel62.Location = new System.Drawing.Point(4, 49);
			this.DarkLabel62.Name = "DarkLabel62";
			this.DarkLabel62.Size = new System.Drawing.Size(65, 13);
			this.DarkLabel62.TabIndex = 31;
			this.DarkLabel62.Text = "Target Type";
			//
			//cmbAnimTargetType
			//
			this.cmbAnimTargetType.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbAnimTargetType.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbAnimTargetType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbAnimTargetType.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbAnimTargetType.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbAnimTargetType.ButtonIcon"));
			this.cmbAnimTargetType.DrawDropdownHoverOutline = false;
			this.cmbAnimTargetType.DrawFocusRectangle = false;
			this.cmbAnimTargetType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbAnimTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbAnimTargetType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbAnimTargetType.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbAnimTargetType.FormattingEnabled = true;
			this.cmbAnimTargetType.Items.AddRange(new object[] {"Player", "Event", "Tile"});
			this.cmbAnimTargetType.Location = new System.Drawing.Point(83, 46);
			this.cmbAnimTargetType.Name = "cmbAnimTargetType";
			this.cmbAnimTargetType.Size = new System.Drawing.Size(159, 21);
			this.cmbAnimTargetType.TabIndex = 30;
			this.cmbAnimTargetType.Text = null;
			this.cmbAnimTargetType.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//nudPlayAnimTileY
			//
			this.nudPlayAnimTileY.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudPlayAnimTileY.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudPlayAnimTileY.Location = new System.Drawing.Point(198, 104);
			this.nudPlayAnimTileY.Name = "nudPlayAnimTileY";
			this.nudPlayAnimTileY.Size = new System.Drawing.Size(44, 20);
			this.nudPlayAnimTileY.TabIndex = 29;
			//
			//nudPlayAnimTileX
			//
			this.nudPlayAnimTileX.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudPlayAnimTileX.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudPlayAnimTileX.Location = new System.Drawing.Point(73, 104);
			this.nudPlayAnimTileX.Name = "nudPlayAnimTileX";
			this.nudPlayAnimTileX.Size = new System.Drawing.Size(44, 20);
			this.nudPlayAnimTileX.TabIndex = 28;
			//
			//DarkLabel61
			//
			this.DarkLabel61.AutoSize = true;
			this.DarkLabel61.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel61.Location = new System.Drawing.Point(6, 22);
			this.DarkLabel61.Name = "DarkLabel61";
			this.DarkLabel61.Size = new System.Drawing.Size(56, 13);
			this.DarkLabel61.TabIndex = 1;
			this.DarkLabel61.Text = "Animation:";
			//
			//cmbPlayAnim
			//
			this.cmbPlayAnim.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbPlayAnim.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbPlayAnim.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbPlayAnim.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbPlayAnim.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbPlayAnim.ButtonIcon"));
			this.cmbPlayAnim.DrawDropdownHoverOutline = false;
			this.cmbPlayAnim.DrawFocusRectangle = false;
			this.cmbPlayAnim.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPlayAnim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPlayAnim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPlayAnim.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbPlayAnim.FormattingEnabled = true;
			this.cmbPlayAnim.Location = new System.Drawing.Point(62, 19);
			this.cmbPlayAnim.Name = "cmbPlayAnim";
			this.cmbPlayAnim.Size = new System.Drawing.Size(180, 21);
			this.cmbPlayAnim.TabIndex = 0;
			this.cmbPlayAnim.Text = null;
			this.cmbPlayAnim.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//fraMoveRouteWait
			//
			this.fraMoveRouteWait.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraMoveRouteWait.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraMoveRouteWait.Controls.Add(this.btnMoveWaitCancel);
			this.fraMoveRouteWait.Controls.Add(this.btnMoveWaitOk);
			this.fraMoveRouteWait.Controls.Add(this.DarkLabel79);
			this.fraMoveRouteWait.Controls.Add(this.cmbMoveWait);
			this.fraMoveRouteWait.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraMoveRouteWait.Location = new System.Drawing.Point(401, 495);
			this.fraMoveRouteWait.Name = "fraMoveRouteWait";
			this.fraMoveRouteWait.Size = new System.Drawing.Size(248, 75);
			this.fraMoveRouteWait.TabIndex = 48;
			this.fraMoveRouteWait.TabStop = false;
			this.fraMoveRouteWait.Text = "Move Route Wait";
			this.fraMoveRouteWait.Visible = false;
			//
			//btnMoveWaitCancel
			//
			this.btnMoveWaitCancel.Location = new System.Drawing.Point(167, 46);
			this.btnMoveWaitCancel.Name = "btnMoveWaitCancel";
			this.btnMoveWaitCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnMoveWaitCancel.Size = new System.Drawing.Size(75, 23);
			this.btnMoveWaitCancel.TabIndex = 26;
			this.btnMoveWaitCancel.Text = "Cancel";
			//
			//btnMoveWaitOk
			//
			this.btnMoveWaitOk.Location = new System.Drawing.Point(86, 46);
			this.btnMoveWaitOk.Name = "btnMoveWaitOk";
			this.btnMoveWaitOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnMoveWaitOk.Size = new System.Drawing.Size(75, 23);
			this.btnMoveWaitOk.TabIndex = 27;
			this.btnMoveWaitOk.Text = "Ok";
			//
			//DarkLabel79
			//
			this.DarkLabel79.AutoSize = true;
			this.DarkLabel79.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel79.Location = new System.Drawing.Point(7, 22);
			this.DarkLabel79.Name = "DarkLabel79";
			this.DarkLabel79.Size = new System.Drawing.Size(38, 13);
			this.DarkLabel79.TabIndex = 1;
			this.DarkLabel79.Text = "Event:";
			//
			//cmbMoveWait
			//
			this.cmbMoveWait.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbMoveWait.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbMoveWait.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbMoveWait.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbMoveWait.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbMoveWait.ButtonIcon"));
			this.cmbMoveWait.DrawDropdownHoverOutline = false;
			this.cmbMoveWait.DrawFocusRectangle = false;
			this.cmbMoveWait.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbMoveWait.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbMoveWait.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbMoveWait.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbMoveWait.FormattingEnabled = true;
			this.cmbMoveWait.Location = new System.Drawing.Point(51, 19);
			this.cmbMoveWait.Name = "cmbMoveWait";
			this.cmbMoveWait.Size = new System.Drawing.Size(191, 21);
			this.cmbMoveWait.TabIndex = 0;
			this.cmbMoveWait.Text = null;
			this.cmbMoveWait.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//fraCustomScript
			//
			this.fraCustomScript.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraCustomScript.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraCustomScript.Controls.Add(this.nudCustomScript);
			this.fraCustomScript.Controls.Add(this.DarkLabel78);
			this.fraCustomScript.Controls.Add(this.btnCustomScriptCancel);
			this.fraCustomScript.Controls.Add(this.btnCustomScriptOk);
			this.fraCustomScript.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraCustomScript.Location = new System.Drawing.Point(401, 396);
			this.fraCustomScript.Name = "fraCustomScript";
			this.fraCustomScript.Size = new System.Drawing.Size(248, 95);
			this.fraCustomScript.TabIndex = 47;
			this.fraCustomScript.TabStop = false;
			this.fraCustomScript.Text = "Execute Custom Script";
			this.fraCustomScript.Visible = false;
			//
			//nudCustomScript
			//
			this.nudCustomScript.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudCustomScript.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudCustomScript.Location = new System.Drawing.Point(67, 19);
			this.nudCustomScript.Name = "nudCustomScript";
			this.nudCustomScript.Size = new System.Drawing.Size(169, 20);
			this.nudCustomScript.TabIndex = 1;
			//
			//DarkLabel78
			//
			this.DarkLabel78.AutoSize = true;
			this.DarkLabel78.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel78.Location = new System.Drawing.Point(10, 21);
			this.DarkLabel78.Name = "DarkLabel78";
			this.DarkLabel78.Size = new System.Drawing.Size(34, 13);
			this.DarkLabel78.TabIndex = 0;
			this.DarkLabel78.Text = "Case:";
			//
			//btnCustomScriptCancel
			//
			this.btnCustomScriptCancel.Location = new System.Drawing.Point(161, 45);
			this.btnCustomScriptCancel.Name = "btnCustomScriptCancel";
			this.btnCustomScriptCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnCustomScriptCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCustomScriptCancel.TabIndex = 24;
			this.btnCustomScriptCancel.Text = "Cancel";
			//
			//btnCustomScriptOk
			//
			this.btnCustomScriptOk.Location = new System.Drawing.Point(80, 45);
			this.btnCustomScriptOk.Name = "btnCustomScriptOk";
			this.btnCustomScriptOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnCustomScriptOk.Size = new System.Drawing.Size(75, 23);
			this.btnCustomScriptOk.TabIndex = 25;
			this.btnCustomScriptOk.Text = "Ok";
			//
			//fraSetWeather
			//
			this.fraSetWeather.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraSetWeather.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraSetWeather.Controls.Add(this.btnSetWeatherOk);
			this.fraSetWeather.Controls.Add(this.btnSetWeatherCancel);
			this.fraSetWeather.Controls.Add(this.DarkLabel76);
			this.fraSetWeather.Controls.Add(this.nudWeatherIntensity);
			this.fraSetWeather.Controls.Add(this.DarkLabel75);
			this.fraSetWeather.Controls.Add(this.CmbWeather);
			this.fraSetWeather.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraSetWeather.Location = new System.Drawing.Point(401, 352);
			this.fraSetWeather.Name = "fraSetWeather";
			this.fraSetWeather.Size = new System.Drawing.Size(248, 95);
			this.fraSetWeather.TabIndex = 44;
			this.fraSetWeather.TabStop = false;
			this.fraSetWeather.Text = "Set Weather";
			this.fraSetWeather.Visible = false;
			//
			//btnSetWeatherOk
			//
			this.btnSetWeatherOk.Location = new System.Drawing.Point(46, 66);
			this.btnSetWeatherOk.Name = "btnSetWeatherOk";
			this.btnSetWeatherOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnSetWeatherOk.Size = new System.Drawing.Size(75, 23);
			this.btnSetWeatherOk.TabIndex = 34;
			this.btnSetWeatherOk.Text = "Ok";
			//
			//btnSetWeatherCancel
			//
			this.btnSetWeatherCancel.Location = new System.Drawing.Point(127, 66);
			this.btnSetWeatherCancel.Name = "btnSetWeatherCancel";
			this.btnSetWeatherCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnSetWeatherCancel.Size = new System.Drawing.Size(75, 23);
			this.btnSetWeatherCancel.TabIndex = 33;
			this.btnSetWeatherCancel.Text = "Cancel";
			//
			//DarkLabel76
			//
			this.DarkLabel76.AutoSize = true;
			this.DarkLabel76.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel76.Location = new System.Drawing.Point(8, 44);
			this.DarkLabel76.Name = "DarkLabel76";
			this.DarkLabel76.Size = new System.Drawing.Size(49, 13);
			this.DarkLabel76.TabIndex = 32;
			this.DarkLabel76.Text = "Intensity:";
			//
			//nudWeatherIntensity
			//
			this.nudWeatherIntensity.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudWeatherIntensity.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudWeatherIntensity.Location = new System.Drawing.Point(87, 41);
			this.nudWeatherIntensity.Name = "nudWeatherIntensity";
			this.nudWeatherIntensity.Size = new System.Drawing.Size(155, 20);
			this.nudWeatherIntensity.TabIndex = 31;
			//
			//DarkLabel75
			//
			this.DarkLabel75.AutoSize = true;
			this.DarkLabel75.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel75.Location = new System.Drawing.Point(6, 18);
			this.DarkLabel75.Name = "DarkLabel75";
			this.DarkLabel75.Size = new System.Drawing.Size(75, 13);
			this.DarkLabel75.TabIndex = 1;
			this.DarkLabel75.Text = "Weather Type";
			//
			//CmbWeather
			//
			this.CmbWeather.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.CmbWeather.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.CmbWeather.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.CmbWeather.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.CmbWeather.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("CmbWeather.ButtonIcon"));
			this.CmbWeather.DrawDropdownHoverOutline = false;
			this.CmbWeather.DrawFocusRectangle = false;
			this.CmbWeather.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.CmbWeather.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.CmbWeather.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.CmbWeather.ForeColor = System.Drawing.Color.Gainsboro;
			this.CmbWeather.FormattingEnabled = true;
			this.CmbWeather.Items.AddRange(new object[] {"None", "Rain", "Snow", "Hail", "Sand Storm", "Storm"});
			this.CmbWeather.Location = new System.Drawing.Point(86, 15);
			this.CmbWeather.Name = "CmbWeather";
			this.CmbWeather.Size = new System.Drawing.Size(155, 21);
			this.CmbWeather.TabIndex = 0;
			this.CmbWeather.Text = null;
			this.CmbWeather.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//fraSpawnNpc
			//
			this.fraSpawnNpc.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraSpawnNpc.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraSpawnNpc.Controls.Add(this.btnSpawnNpcOk);
			this.fraSpawnNpc.Controls.Add(this.btnSpawnNpcCancel);
			this.fraSpawnNpc.Controls.Add(this.cmbSpawnNpc);
			this.fraSpawnNpc.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraSpawnNpc.Location = new System.Drawing.Point(401, 412);
			this.fraSpawnNpc.Name = "fraSpawnNpc";
			this.fraSpawnNpc.Size = new System.Drawing.Size(248, 77);
			this.fraSpawnNpc.TabIndex = 46;
			this.fraSpawnNpc.TabStop = false;
			this.fraSpawnNpc.Text = "Spawn Npc";
			this.fraSpawnNpc.Visible = false;
			//
			//btnSpawnNpcOk
			//
			this.btnSpawnNpcOk.Location = new System.Drawing.Point(46, 47);
			this.btnSpawnNpcOk.Name = "btnSpawnNpcOk";
			this.btnSpawnNpcOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnSpawnNpcOk.Size = new System.Drawing.Size(75, 23);
			this.btnSpawnNpcOk.TabIndex = 27;
			this.btnSpawnNpcOk.Text = "Ok";
			//
			//btnSpawnNpcCancel
			//
			this.btnSpawnNpcCancel.Location = new System.Drawing.Point(127, 47);
			this.btnSpawnNpcCancel.Name = "btnSpawnNpcCancel";
			this.btnSpawnNpcCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnSpawnNpcCancel.Size = new System.Drawing.Size(75, 23);
			this.btnSpawnNpcCancel.TabIndex = 26;
			this.btnSpawnNpcCancel.Text = "Cancel";
			//
			//cmbSpawnNpc
			//
			this.cmbSpawnNpc.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbSpawnNpc.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbSpawnNpc.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbSpawnNpc.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbSpawnNpc.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbSpawnNpc.ButtonIcon"));
			this.cmbSpawnNpc.DrawDropdownHoverOutline = false;
			this.cmbSpawnNpc.DrawFocusRectangle = false;
			this.cmbSpawnNpc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbSpawnNpc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSpawnNpc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbSpawnNpc.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbSpawnNpc.FormattingEnabled = true;
			this.cmbSpawnNpc.Location = new System.Drawing.Point(6, 19);
			this.cmbSpawnNpc.Name = "cmbSpawnNpc";
			this.cmbSpawnNpc.Size = new System.Drawing.Size(234, 21);
			this.cmbSpawnNpc.TabIndex = 0;
			this.cmbSpawnNpc.Text = null;
			this.cmbSpawnNpc.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//fraGiveExp
			//
			this.fraGiveExp.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraGiveExp.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraGiveExp.Controls.Add(this.btnGiveExpOk);
			this.fraGiveExp.Controls.Add(this.btnGiveExpCancel);
			this.fraGiveExp.Controls.Add(this.nudGiveExp);
			this.fraGiveExp.Controls.Add(this.DarkLabel77);
			this.fraGiveExp.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraGiveExp.Location = new System.Drawing.Point(401, 352);
			this.fraGiveExp.Name = "fraGiveExp";
			this.fraGiveExp.Size = new System.Drawing.Size(248, 73);
			this.fraGiveExp.TabIndex = 45;
			this.fraGiveExp.TabStop = false;
			this.fraGiveExp.Text = "Give Experience";
			this.fraGiveExp.Visible = false;
			//
			//btnGiveExpOk
			//
			this.btnGiveExpOk.Location = new System.Drawing.Point(50, 45);
			this.btnGiveExpOk.Name = "btnGiveExpOk";
			this.btnGiveExpOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnGiveExpOk.Size = new System.Drawing.Size(75, 23);
			this.btnGiveExpOk.TabIndex = 27;
			this.btnGiveExpOk.Text = "Ok";
			//
			//btnGiveExpCancel
			//
			this.btnGiveExpCancel.Location = new System.Drawing.Point(131, 45);
			this.btnGiveExpCancel.Name = "btnGiveExpCancel";
			this.btnGiveExpCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnGiveExpCancel.Size = new System.Drawing.Size(75, 23);
			this.btnGiveExpCancel.TabIndex = 26;
			this.btnGiveExpCancel.Text = "Cancel";
			//
			//nudGiveExp
			//
			this.nudGiveExp.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudGiveExp.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudGiveExp.Location = new System.Drawing.Point(77, 19);
			this.nudGiveExp.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
			this.nudGiveExp.Name = "nudGiveExp";
			this.nudGiveExp.Size = new System.Drawing.Size(165, 20);
			this.nudGiveExp.TabIndex = 20;
			//
			//DarkLabel77
			//
			this.DarkLabel77.AutoSize = true;
			this.DarkLabel77.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel77.Location = new System.Drawing.Point(6, 21);
			this.DarkLabel77.Name = "DarkLabel77";
			this.DarkLabel77.Size = new System.Drawing.Size(53, 13);
			this.DarkLabel77.TabIndex = 0;
			this.DarkLabel77.Text = "Give Exp:";
			//
			//fraEndQuest
			//
			this.fraEndQuest.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraEndQuest.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraEndQuest.Controls.Add(this.btnEndQuestOk);
			this.fraEndQuest.Controls.Add(this.btnEndQuestCancel);
			this.fraEndQuest.Controls.Add(this.cmbEndQuest);
			this.fraEndQuest.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraEndQuest.Location = new System.Drawing.Point(401, 416);
			this.fraEndQuest.Name = "fraEndQuest";
			this.fraEndQuest.Size = new System.Drawing.Size(248, 73);
			this.fraEndQuest.TabIndex = 43;
			this.fraEndQuest.TabStop = false;
			this.fraEndQuest.Text = "End Quest";
			this.fraEndQuest.Visible = false;
			//
			//btnEndQuestOk
			//
			this.btnEndQuestOk.Location = new System.Drawing.Point(46, 44);
			this.btnEndQuestOk.Name = "btnEndQuestOk";
			this.btnEndQuestOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnEndQuestOk.Size = new System.Drawing.Size(75, 23);
			this.btnEndQuestOk.TabIndex = 30;
			this.btnEndQuestOk.Text = "Ok";
			//
			//btnEndQuestCancel
			//
			this.btnEndQuestCancel.Location = new System.Drawing.Point(127, 44);
			this.btnEndQuestCancel.Name = "btnEndQuestCancel";
			this.btnEndQuestCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnEndQuestCancel.Size = new System.Drawing.Size(75, 23);
			this.btnEndQuestCancel.TabIndex = 29;
			this.btnEndQuestCancel.Text = "Cancel";
			//
			//cmbEndQuest
			//
			this.cmbEndQuest.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbEndQuest.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbEndQuest.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbEndQuest.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbEndQuest.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbEndQuest.ButtonIcon"));
			this.cmbEndQuest.DrawDropdownHoverOutline = false;
			this.cmbEndQuest.DrawFocusRectangle = false;
			this.cmbEndQuest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbEndQuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbEndQuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbEndQuest.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbEndQuest.FormattingEnabled = true;
			this.cmbEndQuest.Location = new System.Drawing.Point(33, 15);
			this.cmbEndQuest.Name = "cmbEndQuest";
			this.cmbEndQuest.Size = new System.Drawing.Size(188, 21);
			this.cmbEndQuest.TabIndex = 28;
			this.cmbEndQuest.Text = null;
			this.cmbEndQuest.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//fraSetAccess
			//
			this.fraSetAccess.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraSetAccess.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraSetAccess.Controls.Add(this.btnSetAccessOk);
			this.fraSetAccess.Controls.Add(this.btnSetAccessCancel);
			this.fraSetAccess.Controls.Add(this.cmbSetAccess);
			this.fraSetAccess.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraSetAccess.Location = new System.Drawing.Point(401, 353);
			this.fraSetAccess.Name = "fraSetAccess";
			this.fraSetAccess.Size = new System.Drawing.Size(248, 80);
			this.fraSetAccess.TabIndex = 42;
			this.fraSetAccess.TabStop = false;
			this.fraSetAccess.Text = "Set Access";
			this.fraSetAccess.Visible = false;
			//
			//btnSetAccessOk
			//
			this.btnSetAccessOk.Location = new System.Drawing.Point(46, 48);
			this.btnSetAccessOk.Name = "btnSetAccessOk";
			this.btnSetAccessOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnSetAccessOk.Size = new System.Drawing.Size(75, 23);
			this.btnSetAccessOk.TabIndex = 27;
			this.btnSetAccessOk.Text = "Ok";
			//
			//btnSetAccessCancel
			//
			this.btnSetAccessCancel.Location = new System.Drawing.Point(127, 48);
			this.btnSetAccessCancel.Name = "btnSetAccessCancel";
			this.btnSetAccessCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnSetAccessCancel.Size = new System.Drawing.Size(75, 23);
			this.btnSetAccessCancel.TabIndex = 26;
			this.btnSetAccessCancel.Text = "Cancel";
			//
			//cmbSetAccess
			//
			this.cmbSetAccess.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbSetAccess.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbSetAccess.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbSetAccess.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbSetAccess.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbSetAccess.ButtonIcon"));
			this.cmbSetAccess.DrawDropdownHoverOutline = false;
			this.cmbSetAccess.DrawFocusRectangle = false;
			this.cmbSetAccess.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbSetAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSetAccess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbSetAccess.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbSetAccess.FormattingEnabled = true;
			this.cmbSetAccess.Items.AddRange(new object[] {"0: Player", "1: Monitor", "2: Mapper", "3: Developer", "4: Creator"});
			this.cmbSetAccess.Location = new System.Drawing.Point(33, 19);
			this.cmbSetAccess.Name = "cmbSetAccess";
			this.cmbSetAccess.Size = new System.Drawing.Size(188, 21);
			this.cmbSetAccess.TabIndex = 0;
			this.cmbSetAccess.Text = null;
			this.cmbSetAccess.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//fraSetWait
			//
			this.fraSetWait.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraSetWait.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraSetWait.Controls.Add(this.btnSetWaitOk);
			this.fraSetWait.Controls.Add(this.btnSetWaitCancel);
			this.fraSetWait.Controls.Add(this.DarkLabel74);
			this.fraSetWait.Controls.Add(this.DarkLabel72);
			this.fraSetWait.Controls.Add(this.DarkLabel73);
			this.fraSetWait.Controls.Add(this.nudWaitAmount);
			this.fraSetWait.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraSetWait.Location = new System.Drawing.Point(401, 264);
			this.fraSetWait.Name = "fraSetWait";
			this.fraSetWait.Size = new System.Drawing.Size(248, 89);
			this.fraSetWait.TabIndex = 41;
			this.fraSetWait.TabStop = false;
			this.fraSetWait.Text = "Wait...";
			this.fraSetWait.Visible = false;
			//
			//btnSetWaitOk
			//
			this.btnSetWaitOk.Location = new System.Drawing.Point(50, 58);
			this.btnSetWaitOk.Name = "btnSetWaitOk";
			this.btnSetWaitOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnSetWaitOk.Size = new System.Drawing.Size(75, 23);
			this.btnSetWaitOk.TabIndex = 37;
			this.btnSetWaitOk.Text = "Ok";
			//
			//btnSetWaitCancel
			//
			this.btnSetWaitCancel.Location = new System.Drawing.Point(131, 58);
			this.btnSetWaitCancel.Name = "btnSetWaitCancel";
			this.btnSetWaitCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnSetWaitCancel.Size = new System.Drawing.Size(75, 23);
			this.btnSetWaitCancel.TabIndex = 36;
			this.btnSetWaitCancel.Text = "Cancel";
			//
			//DarkLabel74
			//
			this.DarkLabel74.AutoSize = true;
			this.DarkLabel74.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel74.Location = new System.Drawing.Point(70, 42);
			this.DarkLabel74.Name = "DarkLabel74";
			this.DarkLabel74.Size = new System.Drawing.Size(113, 13);
			this.DarkLabel74.TabIndex = 35;
			this.DarkLabel74.Text = "Hint: 1000 Ms = 1 Sec";
			//
			//DarkLabel72
			//
			this.DarkLabel72.AutoSize = true;
			this.DarkLabel72.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel72.Location = new System.Drawing.Point(218, 23);
			this.DarkLabel72.Name = "DarkLabel72";
			this.DarkLabel72.Size = new System.Drawing.Size(21, 13);
			this.DarkLabel72.TabIndex = 34;
			this.DarkLabel72.Text = "Ms";
			//
			//DarkLabel73
			//
			this.DarkLabel73.AutoSize = true;
			this.DarkLabel73.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel73.Location = new System.Drawing.Point(15, 23);
			this.DarkLabel73.Name = "DarkLabel73";
			this.DarkLabel73.Size = new System.Drawing.Size(29, 13);
			this.DarkLabel73.TabIndex = 33;
			this.DarkLabel73.Text = "Wait";
			//
			//nudWaitAmount
			//
			this.nudWaitAmount.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudWaitAmount.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudWaitAmount.Location = new System.Drawing.Point(50, 19);
			this.nudWaitAmount.Maximum = new decimal(new int[] {1000000, 0, 0, 0});
			this.nudWaitAmount.Name = "nudWaitAmount";
			this.nudWaitAmount.Size = new System.Drawing.Size(163, 20);
			this.nudWaitAmount.TabIndex = 32;
			//
			//fraShowPic
			//
			this.fraShowPic.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraShowPic.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraShowPic.Controls.Add(this.btnShowPicOk);
			this.fraShowPic.Controls.Add(this.btnShowPicCancel);
			this.fraShowPic.Controls.Add(this.DarkLabel71);
			this.fraShowPic.Controls.Add(this.DarkLabel70);
			this.fraShowPic.Controls.Add(this.DarkLabel67);
			this.fraShowPic.Controls.Add(this.DarkLabel68);
			this.fraShowPic.Controls.Add(this.nudPicOffsetY);
			this.fraShowPic.Controls.Add(this.nudPicOffsetX);
			this.fraShowPic.Controls.Add(this.DarkLabel69);
			this.fraShowPic.Controls.Add(this.cmbPicLoc);
			this.fraShowPic.Controls.Add(this.nudShowPicture);
			this.fraShowPic.Controls.Add(this.picShowPic);
			this.fraShowPic.Controls.Add(this.cmbPicIndex);
			this.fraShowPic.Controls.Add(this.DarkLabel66);
			this.fraShowPic.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraShowPic.Location = new System.Drawing.Point(401, 266);
			this.fraShowPic.Name = "fraShowPic";
			this.fraShowPic.Size = new System.Drawing.Size(248, 223);
			this.fraShowPic.TabIndex = 40;
			this.fraShowPic.TabStop = false;
			this.fraShowPic.Text = "Show Picture";
			this.fraShowPic.Visible = false;
			//
			//btnShowPicOk
			//
			this.btnShowPicOk.Location = new System.Drawing.Point(86, 194);
			this.btnShowPicOk.Name = "btnShowPicOk";
			this.btnShowPicOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnShowPicOk.Size = new System.Drawing.Size(75, 23);
			this.btnShowPicOk.TabIndex = 55;
			this.btnShowPicOk.Text = "Ok";
			//
			//btnShowPicCancel
			//
			this.btnShowPicCancel.Location = new System.Drawing.Point(167, 194);
			this.btnShowPicCancel.Name = "btnShowPicCancel";
			this.btnShowPicCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnShowPicCancel.Size = new System.Drawing.Size(75, 23);
			this.btnShowPicCancel.TabIndex = 54;
			this.btnShowPicCancel.Text = "Cancel";
			//
			//DarkLabel71
			//
			this.DarkLabel71.AutoSize = true;
			this.DarkLabel71.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel71.Location = new System.Drawing.Point(10, 139);
			this.DarkLabel71.Name = "DarkLabel71";
			this.DarkLabel71.Size = new System.Drawing.Size(105, 13);
			this.DarkLabel71.TabIndex = 53;
			this.DarkLabel71.Text = "Offset from Location:";
			//
			//DarkLabel70
			//
			this.DarkLabel70.AutoSize = true;
			this.DarkLabel70.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel70.Location = new System.Drawing.Point(112, 80);
			this.DarkLabel70.Name = "DarkLabel70";
			this.DarkLabel70.Size = new System.Drawing.Size(48, 13);
			this.DarkLabel70.TabIndex = 52;
			this.DarkLabel70.Text = "Location";
			//
			//DarkLabel67
			//
			this.DarkLabel67.AutoSize = true;
			this.DarkLabel67.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel67.Location = new System.Drawing.Point(137, 162);
			this.DarkLabel67.Name = "DarkLabel67";
			this.DarkLabel67.Size = new System.Drawing.Size(17, 13);
			this.DarkLabel67.TabIndex = 51;
			this.DarkLabel67.Text = "Y:";
			//
			//DarkLabel68
			//
			this.DarkLabel68.AutoSize = true;
			this.DarkLabel68.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel68.Location = new System.Drawing.Point(10, 164);
			this.DarkLabel68.Name = "DarkLabel68";
			this.DarkLabel68.Size = new System.Drawing.Size(17, 13);
			this.DarkLabel68.TabIndex = 50;
			this.DarkLabel68.Text = "X:";
			//
			//nudPicOffsetY
			//
			this.nudPicOffsetY.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudPicOffsetY.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudPicOffsetY.Location = new System.Drawing.Point(182, 160);
			this.nudPicOffsetY.Maximum = new decimal(new int[] {1000, 0, 0, 0});
			this.nudPicOffsetY.Name = "nudPicOffsetY";
			this.nudPicOffsetY.Size = new System.Drawing.Size(57, 20);
			this.nudPicOffsetY.TabIndex = 49;
			//
			//nudPicOffsetX
			//
			this.nudPicOffsetX.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudPicOffsetX.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudPicOffsetX.Location = new System.Drawing.Point(52, 160);
			this.nudPicOffsetX.Maximum = new decimal(new int[] {1000, 0, 0, 0});
			this.nudPicOffsetX.Name = "nudPicOffsetX";
			this.nudPicOffsetX.Size = new System.Drawing.Size(57, 20);
			this.nudPicOffsetX.TabIndex = 48;
			//
			//DarkLabel69
			//
			this.DarkLabel69.AutoSize = true;
			this.DarkLabel69.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel69.Location = new System.Drawing.Point(116, 46);
			this.DarkLabel69.Name = "DarkLabel69";
			this.DarkLabel69.Size = new System.Drawing.Size(43, 13);
			this.DarkLabel69.TabIndex = 47;
			this.DarkLabel69.Text = "Picture:";
			//
			//cmbPicLoc
			//
			this.cmbPicLoc.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbPicLoc.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbPicLoc.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbPicLoc.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbPicLoc.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbPicLoc.ButtonIcon"));
			this.cmbPicLoc.DrawDropdownHoverOutline = false;
			this.cmbPicLoc.DrawFocusRectangle = false;
			this.cmbPicLoc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPicLoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPicLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPicLoc.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbPicLoc.FormattingEnabled = true;
			this.cmbPicLoc.Items.AddRange(new object[] {"Top Left of Screen", "Center Screen", "Centered on Player"});
			this.cmbPicLoc.Location = new System.Drawing.Point(115, 98);
			this.cmbPicLoc.Name = "cmbPicLoc";
			this.cmbPicLoc.Size = new System.Drawing.Size(124, 21);
			this.cmbPicLoc.TabIndex = 46;
			this.cmbPicLoc.Text = null;
			this.cmbPicLoc.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//nudShowPicture
			//
			this.nudShowPicture.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudShowPicture.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudShowPicture.Location = new System.Drawing.Point(165, 44);
			this.nudShowPicture.Name = "nudShowPicture";
			this.nudShowPicture.Size = new System.Drawing.Size(75, 20);
			this.nudShowPicture.TabIndex = 45;
			//
			//picShowPic
			//
			this.picShowPic.BackColor = System.Drawing.Color.Black;
			this.picShowPic.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picShowPic.Location = new System.Drawing.Point(9, 43);
			this.picShowPic.Name = "picShowPic";
			this.picShowPic.Size = new System.Drawing.Size(100, 93);
			this.picShowPic.TabIndex = 42;
			this.picShowPic.TabStop = false;
			//
			//cmbPicIndex
			//
			this.cmbPicIndex.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbPicIndex.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbPicIndex.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbPicIndex.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbPicIndex.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbPicIndex.ButtonIcon"));
			this.cmbPicIndex.DrawDropdownHoverOutline = false;
			this.cmbPicIndex.DrawFocusRectangle = false;
			this.cmbPicIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPicIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPicIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPicIndex.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbPicIndex.FormattingEnabled = true;
			this.cmbPicIndex.Location = new System.Drawing.Point(78, 17);
			this.cmbPicIndex.Name = "cmbPicIndex";
			this.cmbPicIndex.Size = new System.Drawing.Size(162, 21);
			this.cmbPicIndex.TabIndex = 1;
			this.cmbPicIndex.Text = null;
			this.cmbPicIndex.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel66
			//
			this.DarkLabel66.AutoSize = true;
			this.DarkLabel66.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel66.Location = new System.Drawing.Point(6, 20);
			this.DarkLabel66.Name = "DarkLabel66";
			this.DarkLabel66.Size = new System.Drawing.Size(72, 13);
			this.DarkLabel66.TabIndex = 0;
			this.DarkLabel66.Text = "Picture Index:";
			//
			//fraOpenShop
			//
			this.fraOpenShop.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraOpenShop.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraOpenShop.Controls.Add(this.btnOpenShopOk);
			this.fraOpenShop.Controls.Add(this.btnOpenShopCancel);
			this.fraOpenShop.Controls.Add(this.cmbOpenShop);
			this.fraOpenShop.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraOpenShop.Location = new System.Drawing.Point(403, 217);
			this.fraOpenShop.Name = "fraOpenShop";
			this.fraOpenShop.Size = new System.Drawing.Size(246, 79);
			this.fraOpenShop.TabIndex = 39;
			this.fraOpenShop.TabStop = false;
			this.fraOpenShop.Text = "Open Shop";
			this.fraOpenShop.Visible = false;
			//
			//btnOpenShopOk
			//
			this.btnOpenShopOk.Location = new System.Drawing.Point(44, 47);
			this.btnOpenShopOk.Name = "btnOpenShopOk";
			this.btnOpenShopOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnOpenShopOk.Size = new System.Drawing.Size(75, 23);
			this.btnOpenShopOk.TabIndex = 27;
			this.btnOpenShopOk.Text = "Ok";
			//
			//btnOpenShopCancel
			//
			this.btnOpenShopCancel.Location = new System.Drawing.Point(125, 47);
			this.btnOpenShopCancel.Name = "btnOpenShopCancel";
			this.btnOpenShopCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnOpenShopCancel.Size = new System.Drawing.Size(75, 23);
			this.btnOpenShopCancel.TabIndex = 26;
			this.btnOpenShopCancel.Text = "Cancel";
			//
			//cmbOpenShop
			//
			this.cmbOpenShop.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbOpenShop.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbOpenShop.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbOpenShop.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbOpenShop.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbOpenShop.ButtonIcon"));
			this.cmbOpenShop.DrawDropdownHoverOutline = false;
			this.cmbOpenShop.DrawFocusRectangle = false;
			this.cmbOpenShop.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbOpenShop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbOpenShop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbOpenShop.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbOpenShop.FormattingEnabled = true;
			this.cmbOpenShop.Location = new System.Drawing.Point(9, 20);
			this.cmbOpenShop.Name = "cmbOpenShop";
			this.cmbOpenShop.Size = new System.Drawing.Size(226, 21);
			this.cmbOpenShop.TabIndex = 0;
			this.cmbOpenShop.Text = null;
			this.cmbOpenShop.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//fraChangeLevel
			//
			this.fraChangeLevel.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraChangeLevel.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraChangeLevel.Controls.Add(this.btnChangeLevelOk);
			this.fraChangeLevel.Controls.Add(this.btnChangeLevelCancel);
			this.fraChangeLevel.Controls.Add(this.DarkLabel65);
			this.fraChangeLevel.Controls.Add(this.nudChangeLevel);
			this.fraChangeLevel.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraChangeLevel.Location = new System.Drawing.Point(401, 293);
			this.fraChangeLevel.Name = "fraChangeLevel";
			this.fraChangeLevel.Size = new System.Drawing.Size(248, 72);
			this.fraChangeLevel.TabIndex = 38;
			this.fraChangeLevel.TabStop = false;
			this.fraChangeLevel.Text = "Change Level";
			this.fraChangeLevel.Visible = false;
			//
			//btnChangeLevelOk
			//
			this.btnChangeLevelOk.Location = new System.Drawing.Point(46, 45);
			this.btnChangeLevelOk.Name = "btnChangeLevelOk";
			this.btnChangeLevelOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangeLevelOk.Size = new System.Drawing.Size(75, 23);
			this.btnChangeLevelOk.TabIndex = 27;
			this.btnChangeLevelOk.Text = "Ok";
			//
			//btnChangeLevelCancel
			//
			this.btnChangeLevelCancel.Location = new System.Drawing.Point(127, 45);
			this.btnChangeLevelCancel.Name = "btnChangeLevelCancel";
			this.btnChangeLevelCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangeLevelCancel.Size = new System.Drawing.Size(75, 23);
			this.btnChangeLevelCancel.TabIndex = 26;
			this.btnChangeLevelCancel.Text = "Cancel";
			//
			//DarkLabel65
			//
			this.DarkLabel65.AutoSize = true;
			this.DarkLabel65.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel65.Location = new System.Drawing.Point(7, 21);
			this.DarkLabel65.Name = "DarkLabel65";
			this.DarkLabel65.Size = new System.Drawing.Size(36, 13);
			this.DarkLabel65.TabIndex = 24;
			this.DarkLabel65.Text = "Level:";
			//
			//nudChangeLevel
			//
			this.nudChangeLevel.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudChangeLevel.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudChangeLevel.Location = new System.Drawing.Point(60, 19);
			this.nudChangeLevel.Name = "nudChangeLevel";
			this.nudChangeLevel.Size = new System.Drawing.Size(120, 20);
			this.nudChangeLevel.TabIndex = 23;
			//
			//fraChangeGender
			//
			this.fraChangeGender.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraChangeGender.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraChangeGender.Controls.Add(this.btnChangeGenderOk);
			this.fraChangeGender.Controls.Add(this.btnChangeGenderCancel);
			this.fraChangeGender.Controls.Add(this.optChangeSexFemale);
			this.fraChangeGender.Controls.Add(this.optChangeSexMale);
			this.fraChangeGender.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraChangeGender.Location = new System.Drawing.Point(401, 364);
			this.fraChangeGender.Name = "fraChangeGender";
			this.fraChangeGender.Size = new System.Drawing.Size(248, 72);
			this.fraChangeGender.TabIndex = 37;
			this.fraChangeGender.TabStop = false;
			this.fraChangeGender.Text = "Change Player Gender";
			this.fraChangeGender.Visible = false;
			//
			//btnChangeGenderOk
			//
			this.btnChangeGenderOk.Location = new System.Drawing.Point(39, 42);
			this.btnChangeGenderOk.Name = "btnChangeGenderOk";
			this.btnChangeGenderOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangeGenderOk.Size = new System.Drawing.Size(75, 23);
			this.btnChangeGenderOk.TabIndex = 27;
			this.btnChangeGenderOk.Text = "Ok";
			//
			//btnChangeGenderCancel
			//
			this.btnChangeGenderCancel.Location = new System.Drawing.Point(120, 42);
			this.btnChangeGenderCancel.Name = "btnChangeGenderCancel";
			this.btnChangeGenderCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangeGenderCancel.Size = new System.Drawing.Size(75, 23);
			this.btnChangeGenderCancel.TabIndex = 26;
			this.btnChangeGenderCancel.Text = "Cancel";
			//
			//optChangeSexFemale
			//
			this.optChangeSexFemale.AutoSize = true;
			this.optChangeSexFemale.Location = new System.Drawing.Point(141, 19);
			this.optChangeSexFemale.Name = "optChangeSexFemale";
			this.optChangeSexFemale.Size = new System.Drawing.Size(59, 17);
			this.optChangeSexFemale.TabIndex = 1;
			this.optChangeSexFemale.TabStop = true;
			this.optChangeSexFemale.Text = "Female";
			//
			//optChangeSexMale
			//
			this.optChangeSexMale.AutoSize = true;
			this.optChangeSexMale.Location = new System.Drawing.Point(52, 19);
			this.optChangeSexMale.Name = "optChangeSexMale";
			this.optChangeSexMale.Size = new System.Drawing.Size(48, 17);
			this.optChangeSexMale.TabIndex = 0;
			this.optChangeSexMale.TabStop = true;
			this.optChangeSexMale.Text = "Male";
			//
			//fraGoToLabel
			//
			this.fraGoToLabel.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraGoToLabel.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraGoToLabel.Controls.Add(this.btnGoToLabelOk);
			this.fraGoToLabel.Controls.Add(this.btnGoToLabelCancel);
			this.fraGoToLabel.Controls.Add(this.txtGotoLabel);
			this.fraGoToLabel.Controls.Add(this.DarkLabel60);
			this.fraGoToLabel.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraGoToLabel.Location = new System.Drawing.Point(401, 255);
			this.fraGoToLabel.Name = "fraGoToLabel";
			this.fraGoToLabel.Size = new System.Drawing.Size(248, 73);
			this.fraGoToLabel.TabIndex = 35;
			this.fraGoToLabel.TabStop = false;
			this.fraGoToLabel.Text = "GoTo Label";
			this.fraGoToLabel.Visible = false;
			//
			//btnGoToLabelOk
			//
			this.btnGoToLabelOk.Location = new System.Drawing.Point(86, 44);
			this.btnGoToLabelOk.Name = "btnGoToLabelOk";
			this.btnGoToLabelOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnGoToLabelOk.Size = new System.Drawing.Size(75, 23);
			this.btnGoToLabelOk.TabIndex = 27;
			this.btnGoToLabelOk.Text = "Ok";
			//
			//btnGoToLabelCancel
			//
			this.btnGoToLabelCancel.Location = new System.Drawing.Point(167, 44);
			this.btnGoToLabelCancel.Name = "btnGoToLabelCancel";
			this.btnGoToLabelCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnGoToLabelCancel.Size = new System.Drawing.Size(75, 23);
			this.btnGoToLabelCancel.TabIndex = 26;
			this.btnGoToLabelCancel.Text = "Cancel";
			//
			//txtGotoLabel
			//
			this.txtGotoLabel.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtGotoLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtGotoLabel.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtGotoLabel.Location = new System.Drawing.Point(78, 18);
			this.txtGotoLabel.Name = "txtGotoLabel";
			this.txtGotoLabel.Size = new System.Drawing.Size(164, 20);
			this.txtGotoLabel.TabIndex = 1;
			//
			//DarkLabel60
			//
			this.DarkLabel60.AutoSize = true;
			this.DarkLabel60.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel60.Location = new System.Drawing.Point(3, 20);
			this.DarkLabel60.Name = "DarkLabel60";
			this.DarkLabel60.Size = new System.Drawing.Size(67, 13);
			this.DarkLabel60.TabIndex = 0;
			this.DarkLabel60.Text = "Label Name:";
			//
			//fraHidePic
			//
			this.fraHidePic.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraHidePic.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraHidePic.Controls.Add(this.btnHidePicOk);
			this.fraHidePic.Controls.Add(this.btnHidePicCancel);
			this.fraHidePic.Controls.Add(this.nudHidePic);
			this.fraHidePic.Controls.Add(this.DarkLabel59);
			this.fraHidePic.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraHidePic.Location = new System.Drawing.Point(401, 184);
			this.fraHidePic.Name = "fraHidePic";
			this.fraHidePic.Size = new System.Drawing.Size(248, 71);
			this.fraHidePic.TabIndex = 34;
			this.fraHidePic.TabStop = false;
			this.fraHidePic.Text = "Hide Picture";
			this.fraHidePic.Visible = false;
			//
			//btnHidePicOk
			//
			this.btnHidePicOk.Location = new System.Drawing.Point(86, 40);
			this.btnHidePicOk.Name = "btnHidePicOk";
			this.btnHidePicOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnHidePicOk.Size = new System.Drawing.Size(75, 23);
			this.btnHidePicOk.TabIndex = 27;
			this.btnHidePicOk.Text = "Ok";
			//
			//btnHidePicCancel
			//
			this.btnHidePicCancel.Location = new System.Drawing.Point(167, 40);
			this.btnHidePicCancel.Name = "btnHidePicCancel";
			this.btnHidePicCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnHidePicCancel.Size = new System.Drawing.Size(75, 23);
			this.btnHidePicCancel.TabIndex = 26;
			this.btnHidePicCancel.Text = "Cancel";
			//
			//nudHidePic
			//
			this.nudHidePic.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudHidePic.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudHidePic.Location = new System.Drawing.Point(84, 14);
			this.nudHidePic.Name = "nudHidePic";
			this.nudHidePic.Size = new System.Drawing.Size(158, 20);
			this.nudHidePic.TabIndex = 1;
			//
			//DarkLabel59
			//
			this.DarkLabel59.AutoSize = true;
			this.DarkLabel59.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel59.Location = new System.Drawing.Point(6, 16);
			this.DarkLabel59.Name = "DarkLabel59";
			this.DarkLabel59.Size = new System.Drawing.Size(72, 13);
			this.DarkLabel59.TabIndex = 0;
			this.DarkLabel59.Text = "Picture Index:";
			//
			//fraBeginQuest
			//
			this.fraBeginQuest.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraBeginQuest.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraBeginQuest.Controls.Add(this.btnBeginQuestOk);
			this.fraBeginQuest.Controls.Add(this.btnBeginQuestCancel);
			this.fraBeginQuest.Controls.Add(this.cmbBeginQuest);
			this.fraBeginQuest.Controls.Add(this.DarkLabel58);
			this.fraBeginQuest.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraBeginQuest.Location = new System.Drawing.Point(401, 105);
			this.fraBeginQuest.Name = "fraBeginQuest";
			this.fraBeginQuest.Size = new System.Drawing.Size(248, 79);
			this.fraBeginQuest.TabIndex = 33;
			this.fraBeginQuest.TabStop = false;
			this.fraBeginQuest.Text = "Begin Quest";
			this.fraBeginQuest.Visible = false;
			//
			//btnBeginQuestOk
			//
			this.btnBeginQuestOk.Location = new System.Drawing.Point(86, 47);
			this.btnBeginQuestOk.Name = "btnBeginQuestOk";
			this.btnBeginQuestOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnBeginQuestOk.Size = new System.Drawing.Size(75, 23);
			this.btnBeginQuestOk.TabIndex = 27;
			this.btnBeginQuestOk.Text = "Ok";
			//
			//btnBeginQuestCancel
			//
			this.btnBeginQuestCancel.Location = new System.Drawing.Point(167, 47);
			this.btnBeginQuestCancel.Name = "btnBeginQuestCancel";
			this.btnBeginQuestCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnBeginQuestCancel.Size = new System.Drawing.Size(75, 23);
			this.btnBeginQuestCancel.TabIndex = 26;
			this.btnBeginQuestCancel.Text = "Cancel";
			//
			//cmbBeginQuest
			//
			this.cmbBeginQuest.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbBeginQuest.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbBeginQuest.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbBeginQuest.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbBeginQuest.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbBeginQuest.ButtonIcon"));
			this.cmbBeginQuest.DrawDropdownHoverOutline = false;
			this.cmbBeginQuest.DrawFocusRectangle = false;
			this.cmbBeginQuest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbBeginQuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbBeginQuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbBeginQuest.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbBeginQuest.FormattingEnabled = true;
			this.cmbBeginQuest.Location = new System.Drawing.Point(50, 20);
			this.cmbBeginQuest.Name = "cmbBeginQuest";
			this.cmbBeginQuest.Size = new System.Drawing.Size(190, 21);
			this.cmbBeginQuest.TabIndex = 1;
			this.cmbBeginQuest.Text = null;
			this.cmbBeginQuest.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel58
			//
			this.DarkLabel58.AutoSize = true;
			this.DarkLabel58.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel58.Location = new System.Drawing.Point(6, 23);
			this.DarkLabel58.Name = "DarkLabel58";
			this.DarkLabel58.Size = new System.Drawing.Size(38, 13);
			this.DarkLabel58.TabIndex = 0;
			this.DarkLabel58.Text = "Quest:";
			//
			//fraShowChoices
			//
			this.fraShowChoices.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraShowChoices.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraShowChoices.Controls.Add(this.txtChoices4);
			this.fraShowChoices.Controls.Add(this.txtChoices3);
			this.fraShowChoices.Controls.Add(this.txtChoices2);
			this.fraShowChoices.Controls.Add(this.txtChoices1);
			this.fraShowChoices.Controls.Add(this.DarkLabel56);
			this.fraShowChoices.Controls.Add(this.DarkLabel57);
			this.fraShowChoices.Controls.Add(this.DarkLabel55);
			this.fraShowChoices.Controls.Add(this.DarkLabel54);
			this.fraShowChoices.Controls.Add(this.DarkLabel52);
			this.fraShowChoices.Controls.Add(this.txtChoicePrompt);
			this.fraShowChoices.Controls.Add(this.btnShowChoicesOk);
			this.fraShowChoices.Controls.Add(this.picShowChoicesFace);
			this.fraShowChoices.Controls.Add(this.btnShowChoicesCancel);
			this.fraShowChoices.Controls.Add(this.DarkLabel53);
			this.fraShowChoices.Controls.Add(this.nudShowChoicesFace);
			this.fraShowChoices.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraShowChoices.Location = new System.Drawing.Point(401, 103);
			this.fraShowChoices.Name = "fraShowChoices";
			this.fraShowChoices.Size = new System.Drawing.Size(248, 333);
			this.fraShowChoices.TabIndex = 32;
			this.fraShowChoices.TabStop = false;
			this.fraShowChoices.Text = "Show Choices";
			this.fraShowChoices.Visible = false;
			//
			//txtChoices4
			//
			this.txtChoices4.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtChoices4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtChoices4.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtChoices4.Location = new System.Drawing.Point(141, 174);
			this.txtChoices4.Name = "txtChoices4";
			this.txtChoices4.Size = new System.Drawing.Size(100, 20);
			this.txtChoices4.TabIndex = 34;
			//
			//txtChoices3
			//
			this.txtChoices3.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtChoices3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtChoices3.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtChoices3.Location = new System.Drawing.Point(6, 173);
			this.txtChoices3.Name = "txtChoices3";
			this.txtChoices3.Size = new System.Drawing.Size(100, 20);
			this.txtChoices3.TabIndex = 33;
			//
			//txtChoices2
			//
			this.txtChoices2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtChoices2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtChoices2.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtChoices2.Location = new System.Drawing.Point(141, 134);
			this.txtChoices2.Name = "txtChoices2";
			this.txtChoices2.Size = new System.Drawing.Size(100, 20);
			this.txtChoices2.TabIndex = 32;
			//
			//txtChoices1
			//
			this.txtChoices1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtChoices1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtChoices1.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtChoices1.Location = new System.Drawing.Point(6, 134);
			this.txtChoices1.Name = "txtChoices1";
			this.txtChoices1.Size = new System.Drawing.Size(100, 20);
			this.txtChoices1.TabIndex = 31;
			//
			//DarkLabel56
			//
			this.DarkLabel56.AutoSize = true;
			this.DarkLabel56.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel56.Location = new System.Drawing.Point(138, 157);
			this.DarkLabel56.Name = "DarkLabel56";
			this.DarkLabel56.Size = new System.Drawing.Size(49, 13);
			this.DarkLabel56.TabIndex = 30;
			this.DarkLabel56.Text = "Choice 4";
			//
			//DarkLabel57
			//
			this.DarkLabel57.AutoSize = true;
			this.DarkLabel57.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel57.Location = new System.Drawing.Point(7, 157);
			this.DarkLabel57.Name = "DarkLabel57";
			this.DarkLabel57.Size = new System.Drawing.Size(49, 13);
			this.DarkLabel57.TabIndex = 29;
			this.DarkLabel57.Text = "Choice 3";
			//
			//DarkLabel55
			//
			this.DarkLabel55.AutoSize = true;
			this.DarkLabel55.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel55.Location = new System.Drawing.Point(138, 118);
			this.DarkLabel55.Name = "DarkLabel55";
			this.DarkLabel55.Size = new System.Drawing.Size(49, 13);
			this.DarkLabel55.TabIndex = 28;
			this.DarkLabel55.Text = "Choice 2";
			//
			//DarkLabel54
			//
			this.DarkLabel54.AutoSize = true;
			this.DarkLabel54.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel54.Location = new System.Drawing.Point(6, 118);
			this.DarkLabel54.Name = "DarkLabel54";
			this.DarkLabel54.Size = new System.Drawing.Size(49, 13);
			this.DarkLabel54.TabIndex = 27;
			this.DarkLabel54.Text = "Choice 1";
			//
			//DarkLabel52
			//
			this.DarkLabel52.AutoSize = true;
			this.DarkLabel52.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel52.Location = new System.Drawing.Point(7, 19);
			this.DarkLabel52.Name = "DarkLabel52";
			this.DarkLabel52.Size = new System.Drawing.Size(40, 13);
			this.DarkLabel52.TabIndex = 26;
			this.DarkLabel52.Text = "Prompt";
			//
			//txtChoicePrompt
			//
			this.txtChoicePrompt.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtChoicePrompt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtChoicePrompt.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtChoicePrompt.Location = new System.Drawing.Point(9, 38);
			this.txtChoicePrompt.Multiline = true;
			this.txtChoicePrompt.Name = "txtChoicePrompt";
			this.txtChoicePrompt.Size = new System.Drawing.Size(228, 77);
			this.txtChoicePrompt.TabIndex = 21;
			//
			//btnShowChoicesOk
			//
			this.btnShowChoicesOk.Location = new System.Drawing.Point(84, 305);
			this.btnShowChoicesOk.Name = "btnShowChoicesOk";
			this.btnShowChoicesOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnShowChoicesOk.Size = new System.Drawing.Size(75, 23);
			this.btnShowChoicesOk.TabIndex = 25;
			this.btnShowChoicesOk.Text = "Ok";
			//
			//picShowChoicesFace
			//
			this.picShowChoicesFace.BackColor = System.Drawing.Color.Black;
			this.picShowChoicesFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.picShowChoicesFace.Location = new System.Drawing.Point(6, 199);
			this.picShowChoicesFace.Name = "picShowChoicesFace";
			this.picShowChoicesFace.Size = new System.Drawing.Size(100, 93);
			this.picShowChoicesFace.TabIndex = 2;
			this.picShowChoicesFace.TabStop = false;
			//
			//btnShowChoicesCancel
			//
			this.btnShowChoicesCancel.Location = new System.Drawing.Point(165, 305);
			this.btnShowChoicesCancel.Name = "btnShowChoicesCancel";
			this.btnShowChoicesCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnShowChoicesCancel.Size = new System.Drawing.Size(75, 23);
			this.btnShowChoicesCancel.TabIndex = 24;
			this.btnShowChoicesCancel.Text = "Cancel";
			//
			//DarkLabel53
			//
			this.DarkLabel53.AutoSize = true;
			this.DarkLabel53.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel53.Location = new System.Drawing.Point(109, 274);
			this.DarkLabel53.Name = "DarkLabel53";
			this.DarkLabel53.Size = new System.Drawing.Size(34, 13);
			this.DarkLabel53.TabIndex = 22;
			this.DarkLabel53.Text = "Face:";
			//
			//nudShowChoicesFace
			//
			this.nudShowChoicesFace.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudShowChoicesFace.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudShowChoicesFace.Location = new System.Drawing.Point(146, 272);
			this.nudShowChoicesFace.Name = "nudShowChoicesFace";
			this.nudShowChoicesFace.Size = new System.Drawing.Size(92, 20);
			this.nudShowChoicesFace.TabIndex = 23;
			//
			//fraPlayerVariable
			//
			this.fraPlayerVariable.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraPlayerVariable.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraPlayerVariable.Controls.Add(this.nudVariableData2);
			this.fraPlayerVariable.Controls.Add(this.optVariableAction2);
			this.fraPlayerVariable.Controls.Add(this.btnPlayerVarOk);
			this.fraPlayerVariable.Controls.Add(this.btnPlayerVarCancel);
			this.fraPlayerVariable.Controls.Add(this.DarkLabel51);
			this.fraPlayerVariable.Controls.Add(this.DarkLabel50);
			this.fraPlayerVariable.Controls.Add(this.nudVariableData4);
			this.fraPlayerVariable.Controls.Add(this.nudVariableData3);
			this.fraPlayerVariable.Controls.Add(this.optVariableAction3);
			this.fraPlayerVariable.Controls.Add(this.optVariableAction1);
			this.fraPlayerVariable.Controls.Add(this.nudVariableData1);
			this.fraPlayerVariable.Controls.Add(this.nudVariableData0);
			this.fraPlayerVariable.Controls.Add(this.optVariableAction0);
			this.fraPlayerVariable.Controls.Add(this.cmbVariable);
			this.fraPlayerVariable.Controls.Add(this.DarkLabel49);
			this.fraPlayerVariable.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraPlayerVariable.Location = new System.Drawing.Point(401, 282);
			this.fraPlayerVariable.Name = "fraPlayerVariable";
			this.fraPlayerVariable.Size = new System.Drawing.Size(246, 154);
			this.fraPlayerVariable.TabIndex = 31;
			this.fraPlayerVariable.TabStop = false;
			this.fraPlayerVariable.Text = "Player Variable";
			this.fraPlayerVariable.Visible = false;
			//
			//nudVariableData2
			//
			this.nudVariableData2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudVariableData2.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudVariableData2.Location = new System.Drawing.Point(120, 72);
			this.nudVariableData2.Name = "nudVariableData2";
			this.nudVariableData2.Size = new System.Drawing.Size(120, 20);
			this.nudVariableData2.TabIndex = 29;
			//
			//optVariableAction2
			//
			this.optVariableAction2.AutoSize = true;
			this.optVariableAction2.Location = new System.Drawing.Point(6, 72);
			this.optVariableAction2.Name = "optVariableAction2";
			this.optVariableAction2.Size = new System.Drawing.Size(65, 17);
			this.optVariableAction2.TabIndex = 28;
			this.optVariableAction2.TabStop = true;
			this.optVariableAction2.Text = "Subtract";
			//
			//btnPlayerVarOk
			//
			this.btnPlayerVarOk.Location = new System.Drawing.Point(84, 124);
			this.btnPlayerVarOk.Name = "btnPlayerVarOk";
			this.btnPlayerVarOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnPlayerVarOk.Size = new System.Drawing.Size(75, 23);
			this.btnPlayerVarOk.TabIndex = 27;
			this.btnPlayerVarOk.Text = "Ok";
			//
			//btnPlayerVarCancel
			//
			this.btnPlayerVarCancel.Location = new System.Drawing.Point(165, 124);
			this.btnPlayerVarCancel.Name = "btnPlayerVarCancel";
			this.btnPlayerVarCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnPlayerVarCancel.Size = new System.Drawing.Size(75, 23);
			this.btnPlayerVarCancel.TabIndex = 26;
			this.btnPlayerVarCancel.Text = "Cancel";
			//
			//DarkLabel51
			//
			this.DarkLabel51.AutoSize = true;
			this.DarkLabel51.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel51.Location = new System.Drawing.Point(75, 100);
			this.DarkLabel51.Name = "DarkLabel51";
			this.DarkLabel51.Size = new System.Drawing.Size(30, 13);
			this.DarkLabel51.TabIndex = 16;
			this.DarkLabel51.Text = "Low:";
			//
			//DarkLabel50
			//
			this.DarkLabel50.AutoSize = true;
			this.DarkLabel50.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel50.Location = new System.Drawing.Point(158, 100);
			this.DarkLabel50.Name = "DarkLabel50";
			this.DarkLabel50.Size = new System.Drawing.Size(32, 13);
			this.DarkLabel50.TabIndex = 15;
			this.DarkLabel50.Text = "High:";
			//
			//nudVariableData4
			//
			this.nudVariableData4.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudVariableData4.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudVariableData4.Location = new System.Drawing.Point(196, 98);
			this.nudVariableData4.Name = "nudVariableData4";
			this.nudVariableData4.Size = new System.Drawing.Size(44, 20);
			this.nudVariableData4.TabIndex = 14;
			//
			//nudVariableData3
			//
			this.nudVariableData3.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudVariableData3.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudVariableData3.Location = new System.Drawing.Point(111, 98);
			this.nudVariableData3.Name = "nudVariableData3";
			this.nudVariableData3.Size = new System.Drawing.Size(44, 20);
			this.nudVariableData3.TabIndex = 13;
			//
			//optVariableAction3
			//
			this.optVariableAction3.AutoSize = true;
			this.optVariableAction3.Location = new System.Drawing.Point(6, 98);
			this.optVariableAction3.Name = "optVariableAction3";
			this.optVariableAction3.Size = new System.Drawing.Size(65, 17);
			this.optVariableAction3.TabIndex = 12;
			this.optVariableAction3.TabStop = true;
			this.optVariableAction3.Text = "Random";
			//
			//optVariableAction1
			//
			this.optVariableAction1.AutoSize = true;
			this.optVariableAction1.Location = new System.Drawing.Point(146, 46);
			this.optVariableAction1.Name = "optVariableAction1";
			this.optVariableAction1.Size = new System.Drawing.Size(44, 17);
			this.optVariableAction1.TabIndex = 11;
			this.optVariableAction1.TabStop = true;
			this.optVariableAction1.Text = "Add";
			//
			//nudVariableData1
			//
			this.nudVariableData1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudVariableData1.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudVariableData1.Location = new System.Drawing.Point(196, 46);
			this.nudVariableData1.Name = "nudVariableData1";
			this.nudVariableData1.Size = new System.Drawing.Size(44, 20);
			this.nudVariableData1.TabIndex = 10;
			//
			//nudVariableData0
			//
			this.nudVariableData0.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudVariableData0.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudVariableData0.Location = new System.Drawing.Point(62, 46);
			this.nudVariableData0.Name = "nudVariableData0";
			this.nudVariableData0.Size = new System.Drawing.Size(44, 20);
			this.nudVariableData0.TabIndex = 9;
			//
			//optVariableAction0
			//
			this.optVariableAction0.AutoSize = true;
			this.optVariableAction0.Location = new System.Drawing.Point(6, 46);
			this.optVariableAction0.Name = "optVariableAction0";
			this.optVariableAction0.Size = new System.Drawing.Size(41, 17);
			this.optVariableAction0.TabIndex = 2;
			this.optVariableAction0.TabStop = true;
			this.optVariableAction0.Text = "Set";
			//
			//cmbVariable
			//
			this.cmbVariable.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbVariable.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbVariable.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbVariable.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbVariable.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbVariable.ButtonIcon"));
			this.cmbVariable.DrawDropdownHoverOutline = false;
			this.cmbVariable.DrawFocusRectangle = false;
			this.cmbVariable.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbVariable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbVariable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbVariable.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbVariable.FormattingEnabled = true;
			this.cmbVariable.Location = new System.Drawing.Point(60, 19);
			this.cmbVariable.Name = "cmbVariable";
			this.cmbVariable.Size = new System.Drawing.Size(179, 21);
			this.cmbVariable.TabIndex = 1;
			this.cmbVariable.Text = null;
			this.cmbVariable.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel49
			//
			this.DarkLabel49.AutoSize = true;
			this.DarkLabel49.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel49.Location = new System.Drawing.Point(6, 22);
			this.DarkLabel49.Name = "DarkLabel49";
			this.DarkLabel49.Size = new System.Drawing.Size(48, 13);
			this.DarkLabel49.TabIndex = 0;
			this.DarkLabel49.Text = "Variable:";
			//
			//fraChangeSprite
			//
			this.fraChangeSprite.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraChangeSprite.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraChangeSprite.Controls.Add(this.btnChangeSpriteOk);
			this.fraChangeSprite.Controls.Add(this.btnChangeSpriteCancel);
			this.fraChangeSprite.Controls.Add(this.DarkLabel48);
			this.fraChangeSprite.Controls.Add(this.nudChangeSprite);
			this.fraChangeSprite.Controls.Add(this.picChangeSprite);
			this.fraChangeSprite.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraChangeSprite.Location = new System.Drawing.Point(401, 280);
			this.fraChangeSprite.Name = "fraChangeSprite";
			this.fraChangeSprite.Size = new System.Drawing.Size(246, 117);
			this.fraChangeSprite.TabIndex = 30;
			this.fraChangeSprite.TabStop = false;
			this.fraChangeSprite.Text = "Change Sprite";
			this.fraChangeSprite.Visible = false;
			//
			//btnChangeSpriteOk
			//
			this.btnChangeSpriteOk.Location = new System.Drawing.Point(84, 89);
			this.btnChangeSpriteOk.Name = "btnChangeSpriteOk";
			this.btnChangeSpriteOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangeSpriteOk.Size = new System.Drawing.Size(75, 23);
			this.btnChangeSpriteOk.TabIndex = 30;
			this.btnChangeSpriteOk.Text = "Ok";
			//
			//btnChangeSpriteCancel
			//
			this.btnChangeSpriteCancel.Location = new System.Drawing.Point(165, 89);
			this.btnChangeSpriteCancel.Name = "btnChangeSpriteCancel";
			this.btnChangeSpriteCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangeSpriteCancel.Size = new System.Drawing.Size(75, 23);
			this.btnChangeSpriteCancel.TabIndex = 29;
			this.btnChangeSpriteCancel.Text = "Cancel";
			//
			//DarkLabel48
			//
			this.DarkLabel48.AutoSize = true;
			this.DarkLabel48.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel48.Location = new System.Drawing.Point(80, 67);
			this.DarkLabel48.Name = "DarkLabel48";
			this.DarkLabel48.Size = new System.Drawing.Size(34, 13);
			this.DarkLabel48.TabIndex = 28;
			this.DarkLabel48.Text = "Sprite";
			//
			//nudChangeSprite
			//
			this.nudChangeSprite.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudChangeSprite.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudChangeSprite.Location = new System.Drawing.Point(120, 63);
			this.nudChangeSprite.Name = "nudChangeSprite";
			this.nudChangeSprite.Size = new System.Drawing.Size(120, 20);
			this.nudChangeSprite.TabIndex = 27;
			//
			//picChangeSprite
			//
			this.picChangeSprite.BackColor = System.Drawing.Color.Black;
			this.picChangeSprite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.picChangeSprite.Location = new System.Drawing.Point(6, 19);
			this.picChangeSprite.Name = "picChangeSprite";
			this.picChangeSprite.Size = new System.Drawing.Size(70, 93);
			this.picChangeSprite.TabIndex = 3;
			this.picChangeSprite.TabStop = false;
			//
			//fraSetSelfSwitch
			//
			this.fraSetSelfSwitch.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraSetSelfSwitch.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraSetSelfSwitch.Controls.Add(this.btnSelfswitchOk);
			this.fraSetSelfSwitch.Controls.Add(this.btnSelfswitchCancel);
			this.fraSetSelfSwitch.Controls.Add(this.DarkLabel47);
			this.fraSetSelfSwitch.Controls.Add(this.cmbSetSelfSwitchTo);
			this.fraSetSelfSwitch.Controls.Add(this.DarkLabel46);
			this.fraSetSelfSwitch.Controls.Add(this.cmbSetSelfSwitch);
			this.fraSetSelfSwitch.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraSetSelfSwitch.Location = new System.Drawing.Point(401, 180);
			this.fraSetSelfSwitch.Name = "fraSetSelfSwitch";
			this.fraSetSelfSwitch.Size = new System.Drawing.Size(246, 100);
			this.fraSetSelfSwitch.TabIndex = 29;
			this.fraSetSelfSwitch.TabStop = false;
			this.fraSetSelfSwitch.Text = "Self Switches";
			this.fraSetSelfSwitch.Visible = false;
			//
			//btnSelfswitchOk
			//
			this.btnSelfswitchOk.Location = new System.Drawing.Point(84, 73);
			this.btnSelfswitchOk.Name = "btnSelfswitchOk";
			this.btnSelfswitchOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnSelfswitchOk.Size = new System.Drawing.Size(75, 23);
			this.btnSelfswitchOk.TabIndex = 27;
			this.btnSelfswitchOk.Text = "Ok";
			//
			//btnSelfswitchCancel
			//
			this.btnSelfswitchCancel.Location = new System.Drawing.Point(165, 73);
			this.btnSelfswitchCancel.Name = "btnSelfswitchCancel";
			this.btnSelfswitchCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnSelfswitchCancel.Size = new System.Drawing.Size(75, 23);
			this.btnSelfswitchCancel.TabIndex = 26;
			this.btnSelfswitchCancel.Text = "Cancel";
			//
			//DarkLabel47
			//
			this.DarkLabel47.AutoSize = true;
			this.DarkLabel47.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel47.Location = new System.Drawing.Point(6, 49);
			this.DarkLabel47.Name = "DarkLabel47";
			this.DarkLabel47.Size = new System.Drawing.Size(39, 13);
			this.DarkLabel47.TabIndex = 3;
			this.DarkLabel47.Text = "Set To";
			//
			//cmbSetSelfSwitchTo
			//
			this.cmbSetSelfSwitchTo.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbSetSelfSwitchTo.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbSetSelfSwitchTo.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbSetSelfSwitchTo.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbSetSelfSwitchTo.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbSetSelfSwitchTo.ButtonIcon"));
			this.cmbSetSelfSwitchTo.DrawDropdownHoverOutline = false;
			this.cmbSetSelfSwitchTo.DrawFocusRectangle = false;
			this.cmbSetSelfSwitchTo.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbSetSelfSwitchTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSetSelfSwitchTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbSetSelfSwitchTo.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbSetSelfSwitchTo.FormattingEnabled = true;
			this.cmbSetSelfSwitchTo.Items.AddRange(new object[] {"Off", "On"});
			this.cmbSetSelfSwitchTo.Location = new System.Drawing.Point(72, 46);
			this.cmbSetSelfSwitchTo.Name = "cmbSetSelfSwitchTo";
			this.cmbSetSelfSwitchTo.Size = new System.Drawing.Size(168, 21);
			this.cmbSetSelfSwitchTo.TabIndex = 2;
			this.cmbSetSelfSwitchTo.Text = null;
			this.cmbSetSelfSwitchTo.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel46
			//
			this.DarkLabel46.AutoSize = true;
			this.DarkLabel46.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel46.Location = new System.Drawing.Point(6, 22);
			this.DarkLabel46.Name = "DarkLabel46";
			this.DarkLabel46.Size = new System.Drawing.Size(63, 13);
			this.DarkLabel46.TabIndex = 1;
			this.DarkLabel46.Text = "Self Switch:";
			//
			//cmbSetSelfSwitch
			//
			this.cmbSetSelfSwitch.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbSetSelfSwitch.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbSetSelfSwitch.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbSetSelfSwitch.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbSetSelfSwitch.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbSetSelfSwitch.ButtonIcon"));
			this.cmbSetSelfSwitch.DrawDropdownHoverOutline = false;
			this.cmbSetSelfSwitch.DrawFocusRectangle = false;
			this.cmbSetSelfSwitch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbSetSelfSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSetSelfSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbSetSelfSwitch.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbSetSelfSwitch.FormattingEnabled = true;
			this.cmbSetSelfSwitch.Location = new System.Drawing.Point(72, 19);
			this.cmbSetSelfSwitch.Name = "cmbSetSelfSwitch";
			this.cmbSetSelfSwitch.Size = new System.Drawing.Size(168, 21);
			this.cmbSetSelfSwitch.TabIndex = 0;
			this.cmbSetSelfSwitch.Text = null;
			this.cmbSetSelfSwitch.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//fraMapTint
			//
			this.fraMapTint.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraMapTint.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraMapTint.Controls.Add(this.btnMapTintOk);
			this.fraMapTint.Controls.Add(this.btnMapTintCancel);
			this.fraMapTint.Controls.Add(this.DarkLabel42);
			this.fraMapTint.Controls.Add(this.nudMapTintData3);
			this.fraMapTint.Controls.Add(this.nudMapTintData2);
			this.fraMapTint.Controls.Add(this.DarkLabel43);
			this.fraMapTint.Controls.Add(this.DarkLabel44);
			this.fraMapTint.Controls.Add(this.nudMapTintData1);
			this.fraMapTint.Controls.Add(this.nudMapTintData0);
			this.fraMapTint.Controls.Add(this.DarkLabel45);
			this.fraMapTint.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraMapTint.Location = new System.Drawing.Point(401, 181);
			this.fraMapTint.Name = "fraMapTint";
			this.fraMapTint.Size = new System.Drawing.Size(246, 145);
			this.fraMapTint.TabIndex = 28;
			this.fraMapTint.TabStop = false;
			this.fraMapTint.Text = "Map Tinting";
			this.fraMapTint.Visible = false;
			//
			//btnMapTintOk
			//
			this.btnMapTintOk.Location = new System.Drawing.Point(84, 115);
			this.btnMapTintOk.Name = "btnMapTintOk";
			this.btnMapTintOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnMapTintOk.Size = new System.Drawing.Size(75, 23);
			this.btnMapTintOk.TabIndex = 45;
			this.btnMapTintOk.Text = "Ok";
			//
			//btnMapTintCancel
			//
			this.btnMapTintCancel.Location = new System.Drawing.Point(165, 115);
			this.btnMapTintCancel.Name = "btnMapTintCancel";
			this.btnMapTintCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnMapTintCancel.Size = new System.Drawing.Size(75, 23);
			this.btnMapTintCancel.TabIndex = 44;
			this.btnMapTintCancel.Text = "Cancel";
			//
			//DarkLabel42
			//
			this.DarkLabel42.AutoSize = true;
			this.DarkLabel42.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel42.Location = new System.Drawing.Point(5, 93);
			this.DarkLabel42.Name = "DarkLabel42";
			this.DarkLabel42.Size = new System.Drawing.Size(46, 13);
			this.DarkLabel42.TabIndex = 43;
			this.DarkLabel42.Text = "Opacity:";
			//
			//nudMapTintData3
			//
			this.nudMapTintData3.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudMapTintData3.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudMapTintData3.Location = new System.Drawing.Point(95, 89);
			this.nudMapTintData3.Name = "nudMapTintData3";
			this.nudMapTintData3.Size = new System.Drawing.Size(144, 20);
			this.nudMapTintData3.TabIndex = 42;
			//
			//nudMapTintData2
			//
			this.nudMapTintData2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudMapTintData2.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudMapTintData2.Location = new System.Drawing.Point(95, 64);
			this.nudMapTintData2.Maximum = new decimal(new int[] {255, 0, 0, 0});
			this.nudMapTintData2.Name = "nudMapTintData2";
			this.nudMapTintData2.Size = new System.Drawing.Size(144, 20);
			this.nudMapTintData2.TabIndex = 41;
			//
			//DarkLabel43
			//
			this.DarkLabel43.AutoSize = true;
			this.DarkLabel43.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel43.Location = new System.Drawing.Point(5, 66);
			this.DarkLabel43.Name = "DarkLabel43";
			this.DarkLabel43.Size = new System.Drawing.Size(31, 13);
			this.DarkLabel43.TabIndex = 40;
			this.DarkLabel43.Text = "Blue:";
			//
			//DarkLabel44
			//
			this.DarkLabel44.AutoSize = true;
			this.DarkLabel44.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel44.Location = new System.Drawing.Point(4, 43);
			this.DarkLabel44.Name = "DarkLabel44";
			this.DarkLabel44.Size = new System.Drawing.Size(39, 13);
			this.DarkLabel44.TabIndex = 39;
			this.DarkLabel44.Text = "Green:";
			//
			//nudMapTintData1
			//
			this.nudMapTintData1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudMapTintData1.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudMapTintData1.Location = new System.Drawing.Point(95, 39);
			this.nudMapTintData1.Maximum = new decimal(new int[] {255, 0, 0, 0});
			this.nudMapTintData1.Name = "nudMapTintData1";
			this.nudMapTintData1.Size = new System.Drawing.Size(144, 20);
			this.nudMapTintData1.TabIndex = 38;
			//
			//nudMapTintData0
			//
			this.nudMapTintData0.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudMapTintData0.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudMapTintData0.Location = new System.Drawing.Point(95, 14);
			this.nudMapTintData0.Maximum = new decimal(new int[] {255, 0, 0, 0});
			this.nudMapTintData0.Name = "nudMapTintData0";
			this.nudMapTintData0.Size = new System.Drawing.Size(144, 20);
			this.nudMapTintData0.TabIndex = 37;
			//
			//DarkLabel45
			//
			this.DarkLabel45.AutoSize = true;
			this.DarkLabel45.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel45.Location = new System.Drawing.Point(5, 16);
			this.DarkLabel45.Name = "DarkLabel45";
			this.DarkLabel45.Size = new System.Drawing.Size(30, 13);
			this.DarkLabel45.TabIndex = 36;
			this.DarkLabel45.Text = "Red:";
			//
			//fraShowChatBubble
			//
			this.fraShowChatBubble.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraShowChatBubble.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraShowChatBubble.Controls.Add(this.btnShowChatBubbleOk);
			this.fraShowChatBubble.Controls.Add(this.btnShowChatBubbleCancel);
			this.fraShowChatBubble.Controls.Add(this.DarkLabel41);
			this.fraShowChatBubble.Controls.Add(this.cmbChatBubbleTarget);
			this.fraShowChatBubble.Controls.Add(this.cmbChatBubbleTargetType);
			this.fraShowChatBubble.Controls.Add(this.DarkLabel40);
			this.fraShowChatBubble.Controls.Add(this.txtChatbubbleText);
			this.fraShowChatBubble.Controls.Add(this.DarkLabel39);
			this.fraShowChatBubble.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraShowChatBubble.Location = new System.Drawing.Point(401, 181);
			this.fraShowChatBubble.Name = "fraShowChatBubble";
			this.fraShowChatBubble.Size = new System.Drawing.Size(246, 141);
			this.fraShowChatBubble.TabIndex = 27;
			this.fraShowChatBubble.TabStop = false;
			this.fraShowChatBubble.Text = "Show ChatBubble";
			this.fraShowChatBubble.Visible = false;
			//
			//btnShowChatBubbleOk
			//
			this.btnShowChatBubbleOk.Location = new System.Drawing.Point(84, 112);
			this.btnShowChatBubbleOk.Name = "btnShowChatBubbleOk";
			this.btnShowChatBubbleOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnShowChatBubbleOk.Size = new System.Drawing.Size(75, 23);
			this.btnShowChatBubbleOk.TabIndex = 31;
			this.btnShowChatBubbleOk.Text = "Ok";
			//
			//btnShowChatBubbleCancel
			//
			this.btnShowChatBubbleCancel.Location = new System.Drawing.Point(165, 112);
			this.btnShowChatBubbleCancel.Name = "btnShowChatBubbleCancel";
			this.btnShowChatBubbleCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnShowChatBubbleCancel.Size = new System.Drawing.Size(75, 23);
			this.btnShowChatBubbleCancel.TabIndex = 30;
			this.btnShowChatBubbleCancel.Text = "Cancel";
			//
			//DarkLabel41
			//
			this.DarkLabel41.AutoSize = true;
			this.DarkLabel41.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel41.Location = new System.Drawing.Point(6, 88);
			this.DarkLabel41.Name = "DarkLabel41";
			this.DarkLabel41.Size = new System.Drawing.Size(36, 13);
			this.DarkLabel41.TabIndex = 29;
			this.DarkLabel41.Text = "Index:";
			//
			//cmbChatBubbleTarget
			//
			this.cmbChatBubbleTarget.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbChatBubbleTarget.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbChatBubbleTarget.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbChatBubbleTarget.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbChatBubbleTarget.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbChatBubbleTarget.ButtonIcon"));
			this.cmbChatBubbleTarget.DrawDropdownHoverOutline = false;
			this.cmbChatBubbleTarget.DrawFocusRectangle = false;
			this.cmbChatBubbleTarget.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbChatBubbleTarget.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChatBubbleTarget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbChatBubbleTarget.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbChatBubbleTarget.FormattingEnabled = true;
			this.cmbChatBubbleTarget.Location = new System.Drawing.Point(81, 85);
			this.cmbChatBubbleTarget.Name = "cmbChatBubbleTarget";
			this.cmbChatBubbleTarget.Size = new System.Drawing.Size(159, 21);
			this.cmbChatBubbleTarget.TabIndex = 28;
			this.cmbChatBubbleTarget.Text = null;
			this.cmbChatBubbleTarget.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//cmbChatBubbleTargetType
			//
			this.cmbChatBubbleTargetType.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbChatBubbleTargetType.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbChatBubbleTargetType.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbChatBubbleTargetType.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbChatBubbleTargetType.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbChatBubbleTargetType.ButtonIcon"));
			this.cmbChatBubbleTargetType.DrawDropdownHoverOutline = false;
			this.cmbChatBubbleTargetType.DrawFocusRectangle = false;
			this.cmbChatBubbleTargetType.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbChatBubbleTargetType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChatBubbleTargetType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbChatBubbleTargetType.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbChatBubbleTargetType.FormattingEnabled = true;
			this.cmbChatBubbleTargetType.Items.AddRange(new object[] {"Player", "Npc", "Event"});
			this.cmbChatBubbleTargetType.Location = new System.Drawing.Point(81, 58);
			this.cmbChatBubbleTargetType.Name = "cmbChatBubbleTargetType";
			this.cmbChatBubbleTargetType.Size = new System.Drawing.Size(159, 21);
			this.cmbChatBubbleTargetType.TabIndex = 27;
			this.cmbChatBubbleTargetType.Text = null;
			this.cmbChatBubbleTargetType.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel40
			//
			this.DarkLabel40.AutoSize = true;
			this.DarkLabel40.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel40.Location = new System.Drawing.Point(6, 61);
			this.DarkLabel40.Name = "DarkLabel40";
			this.DarkLabel40.Size = new System.Drawing.Size(68, 13);
			this.DarkLabel40.TabIndex = 2;
			this.DarkLabel40.Text = "Target Type:";
			//
			//txtChatbubbleText
			//
			this.txtChatbubbleText.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtChatbubbleText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtChatbubbleText.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtChatbubbleText.Location = new System.Drawing.Point(6, 32);
			this.txtChatbubbleText.Name = "txtChatbubbleText";
			this.txtChatbubbleText.Size = new System.Drawing.Size(234, 20);
			this.txtChatbubbleText.TabIndex = 1;
			//
			//DarkLabel39
			//
			this.DarkLabel39.AutoSize = true;
			this.DarkLabel39.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel39.Location = new System.Drawing.Point(6, 16);
			this.DarkLabel39.Name = "DarkLabel39";
			this.DarkLabel39.Size = new System.Drawing.Size(86, 13);
			this.DarkLabel39.TabIndex = 0;
			this.DarkLabel39.Text = "ChatBubble Text";
			//
			//fraPlaySound
			//
			this.fraPlaySound.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraPlaySound.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraPlaySound.Controls.Add(this.btnPlaySoundOk);
			this.fraPlaySound.Controls.Add(this.btnPlaySoundCancel);
			this.fraPlaySound.Controls.Add(this.cmbPlaySound);
			this.fraPlaySound.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraPlaySound.Location = new System.Drawing.Point(401, 179);
			this.fraPlaySound.Name = "fraPlaySound";
			this.fraPlaySound.Size = new System.Drawing.Size(246, 76);
			this.fraPlaySound.TabIndex = 26;
			this.fraPlaySound.TabStop = false;
			this.fraPlaySound.Text = "Play Sound";
			this.fraPlaySound.Visible = false;
			//
			//btnPlaySoundOk
			//
			this.btnPlaySoundOk.Location = new System.Drawing.Point(84, 46);
			this.btnPlaySoundOk.Name = "btnPlaySoundOk";
			this.btnPlaySoundOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnPlaySoundOk.Size = new System.Drawing.Size(75, 23);
			this.btnPlaySoundOk.TabIndex = 27;
			this.btnPlaySoundOk.Text = "Ok";
			//
			//btnPlaySoundCancel
			//
			this.btnPlaySoundCancel.Location = new System.Drawing.Point(165, 46);
			this.btnPlaySoundCancel.Name = "btnPlaySoundCancel";
			this.btnPlaySoundCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnPlaySoundCancel.Size = new System.Drawing.Size(75, 23);
			this.btnPlaySoundCancel.TabIndex = 26;
			this.btnPlaySoundCancel.Text = "Cancel";
			//
			//cmbPlaySound
			//
			this.cmbPlaySound.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbPlaySound.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbPlaySound.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbPlaySound.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbPlaySound.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbPlaySound.ButtonIcon"));
			this.cmbPlaySound.DrawDropdownHoverOutline = false;
			this.cmbPlaySound.DrawFocusRectangle = false;
			this.cmbPlaySound.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPlaySound.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPlaySound.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPlaySound.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbPlaySound.FormattingEnabled = true;
			this.cmbPlaySound.Location = new System.Drawing.Point(6, 19);
			this.cmbPlaySound.Name = "cmbPlaySound";
			this.cmbPlaySound.Size = new System.Drawing.Size(234, 21);
			this.cmbPlaySound.TabIndex = 0;
			this.cmbPlaySound.Text = null;
			this.cmbPlaySound.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//fraChangePK
			//
			this.fraChangePK.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraChangePK.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraChangePK.Controls.Add(this.btnChangePkOk);
			this.fraChangePK.Controls.Add(this.btnChangePkCancel);
			this.fraChangePK.Controls.Add(this.cmbSetPK);
			this.fraChangePK.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraChangePK.Location = new System.Drawing.Point(401, 104);
			this.fraChangePK.Name = "fraChangePK";
			this.fraChangePK.Size = new System.Drawing.Size(246, 75);
			this.fraChangePK.TabIndex = 25;
			this.fraChangePK.TabStop = false;
			this.fraChangePK.Text = "Set Player PK";
			this.fraChangePK.Visible = false;
			//
			//btnChangePkOk
			//
			this.btnChangePkOk.Location = new System.Drawing.Point(80, 46);
			this.btnChangePkOk.Name = "btnChangePkOk";
			this.btnChangePkOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangePkOk.Size = new System.Drawing.Size(75, 23);
			this.btnChangePkOk.TabIndex = 27;
			this.btnChangePkOk.Text = "Ok";
			//
			//btnChangePkCancel
			//
			this.btnChangePkCancel.Location = new System.Drawing.Point(161, 46);
			this.btnChangePkCancel.Name = "btnChangePkCancel";
			this.btnChangePkCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangePkCancel.Size = new System.Drawing.Size(75, 23);
			this.btnChangePkCancel.TabIndex = 26;
			this.btnChangePkCancel.Text = "Cancel";
			//
			//cmbSetPK
			//
			this.cmbSetPK.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbSetPK.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbSetPK.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbSetPK.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbSetPK.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbSetPK.ButtonIcon"));
			this.cmbSetPK.DrawDropdownHoverOutline = false;
			this.cmbSetPK.DrawFocusRectangle = false;
			this.cmbSetPK.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbSetPK.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSetPK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbSetPK.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbSetPK.FormattingEnabled = true;
			this.cmbSetPK.Items.AddRange(new object[] {"No", "Yes"});
			this.cmbSetPK.Location = new System.Drawing.Point(10, 19);
			this.cmbSetPK.Name = "cmbSetPK";
			this.cmbSetPK.Size = new System.Drawing.Size(226, 21);
			this.cmbSetPK.TabIndex = 18;
			this.cmbSetPK.Text = null;
			this.cmbSetPK.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//fraCreateLabel
			//
			this.fraCreateLabel.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraCreateLabel.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraCreateLabel.Controls.Add(this.btnCreatelabelOk);
			this.fraCreateLabel.Controls.Add(this.btnCreatelabelCancel);
			this.fraCreateLabel.Controls.Add(this.txtLabelName);
			this.fraCreateLabel.Controls.Add(this.lblLabelName);
			this.fraCreateLabel.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraCreateLabel.Location = new System.Drawing.Point(401, 132);
			this.fraCreateLabel.Name = "fraCreateLabel";
			this.fraCreateLabel.Size = new System.Drawing.Size(246, 74);
			this.fraCreateLabel.TabIndex = 24;
			this.fraCreateLabel.TabStop = false;
			this.fraCreateLabel.Text = "Create Label";
			this.fraCreateLabel.Visible = false;
			//
			//btnCreatelabelOk
			//
			this.btnCreatelabelOk.Location = new System.Drawing.Point(84, 45);
			this.btnCreatelabelOk.Name = "btnCreatelabelOk";
			this.btnCreatelabelOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnCreatelabelOk.Size = new System.Drawing.Size(75, 23);
			this.btnCreatelabelOk.TabIndex = 27;
			this.btnCreatelabelOk.Text = "Ok";
			//
			//btnCreatelabelCancel
			//
			this.btnCreatelabelCancel.Location = new System.Drawing.Point(165, 45);
			this.btnCreatelabelCancel.Name = "btnCreatelabelCancel";
			this.btnCreatelabelCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnCreatelabelCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCreatelabelCancel.TabIndex = 26;
			this.btnCreatelabelCancel.Text = "Cancel";
			//
			//txtLabelName
			//
			this.txtLabelName.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtLabelName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtLabelName.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtLabelName.Location = new System.Drawing.Point(80, 19);
			this.txtLabelName.Name = "txtLabelName";
			this.txtLabelName.Size = new System.Drawing.Size(160, 20);
			this.txtLabelName.TabIndex = 1;
			//
			//lblLabelName
			//
			this.lblLabelName.AutoSize = true;
			this.lblLabelName.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.lblLabelName.Location = new System.Drawing.Point(7, 21);
			this.lblLabelName.Name = "lblLabelName";
			this.lblLabelName.Size = new System.Drawing.Size(67, 13);
			this.lblLabelName.TabIndex = 0;
			this.lblLabelName.Text = "Label Name:";
			//
			//fraChangeClass
			//
			this.fraChangeClass.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraChangeClass.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraChangeClass.Controls.Add(this.btnChangeClassOk);
			this.fraChangeClass.Controls.Add(this.btnChangeClassCancel);
			this.fraChangeClass.Controls.Add(this.cmbChangeClass);
			this.fraChangeClass.Controls.Add(this.DarkLabel38);
			this.fraChangeClass.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraChangeClass.Location = new System.Drawing.Point(401, 109);
			this.fraChangeClass.Name = "fraChangeClass";
			this.fraChangeClass.Size = new System.Drawing.Size(246, 76);
			this.fraChangeClass.TabIndex = 23;
			this.fraChangeClass.TabStop = false;
			this.fraChangeClass.Text = "Change Player Class";
			this.fraChangeClass.Visible = false;
			//
			//btnChangeClassOk
			//
			this.btnChangeClassOk.Location = new System.Drawing.Point(84, 46);
			this.btnChangeClassOk.Name = "btnChangeClassOk";
			this.btnChangeClassOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangeClassOk.Size = new System.Drawing.Size(75, 23);
			this.btnChangeClassOk.TabIndex = 27;
			this.btnChangeClassOk.Text = "Ok";
			//
			//btnChangeClassCancel
			//
			this.btnChangeClassCancel.Location = new System.Drawing.Point(165, 46);
			this.btnChangeClassCancel.Name = "btnChangeClassCancel";
			this.btnChangeClassCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangeClassCancel.Size = new System.Drawing.Size(75, 23);
			this.btnChangeClassCancel.TabIndex = 26;
			this.btnChangeClassCancel.Text = "Cancel";
			//
			//cmbChangeClass
			//
			this.cmbChangeClass.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbChangeClass.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbChangeClass.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbChangeClass.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbChangeClass.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbChangeClass.ButtonIcon"));
			this.cmbChangeClass.DrawDropdownHoverOutline = false;
			this.cmbChangeClass.DrawFocusRectangle = false;
			this.cmbChangeClass.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbChangeClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChangeClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbChangeClass.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbChangeClass.FormattingEnabled = true;
			this.cmbChangeClass.Location = new System.Drawing.Point(49, 19);
			this.cmbChangeClass.Name = "cmbChangeClass";
			this.cmbChangeClass.Size = new System.Drawing.Size(191, 21);
			this.cmbChangeClass.TabIndex = 1;
			this.cmbChangeClass.Text = null;
			this.cmbChangeClass.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel38
			//
			this.DarkLabel38.AutoSize = true;
			this.DarkLabel38.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel38.Location = new System.Drawing.Point(8, 22);
			this.DarkLabel38.Name = "DarkLabel38";
			this.DarkLabel38.Size = new System.Drawing.Size(35, 13);
			this.DarkLabel38.TabIndex = 0;
			this.DarkLabel38.Text = "Class:";
			//
			//fraChangeSkills
			//
			this.fraChangeSkills.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraChangeSkills.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraChangeSkills.Controls.Add(this.btnChangeSkillsOk);
			this.fraChangeSkills.Controls.Add(this.btnChangeSkillsCancel);
			this.fraChangeSkills.Controls.Add(this.optChangeSkillsRemove);
			this.fraChangeSkills.Controls.Add(this.optChangeSkillsAdd);
			this.fraChangeSkills.Controls.Add(this.cmbChangeSkills);
			this.fraChangeSkills.Controls.Add(this.DarkLabel37);
			this.fraChangeSkills.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraChangeSkills.Location = new System.Drawing.Point(401, 108);
			this.fraChangeSkills.Name = "fraChangeSkills";
			this.fraChangeSkills.Size = new System.Drawing.Size(246, 98);
			this.fraChangeSkills.TabIndex = 22;
			this.fraChangeSkills.TabStop = false;
			this.fraChangeSkills.Text = "Change Player Skills";
			this.fraChangeSkills.Visible = false;
			//
			//btnChangeSkillsOk
			//
			this.btnChangeSkillsOk.Location = new System.Drawing.Point(84, 67);
			this.btnChangeSkillsOk.Name = "btnChangeSkillsOk";
			this.btnChangeSkillsOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangeSkillsOk.Size = new System.Drawing.Size(75, 23);
			this.btnChangeSkillsOk.TabIndex = 27;
			this.btnChangeSkillsOk.Text = "Ok";
			//
			//btnChangeSkillsCancel
			//
			this.btnChangeSkillsCancel.Location = new System.Drawing.Point(165, 67);
			this.btnChangeSkillsCancel.Name = "btnChangeSkillsCancel";
			this.btnChangeSkillsCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangeSkillsCancel.Size = new System.Drawing.Size(75, 23);
			this.btnChangeSkillsCancel.TabIndex = 26;
			this.btnChangeSkillsCancel.Text = "Cancel";
			//
			//optChangeSkillsRemove
			//
			this.optChangeSkillsRemove.AutoSize = true;
			this.optChangeSkillsRemove.Location = new System.Drawing.Point(147, 44);
			this.optChangeSkillsRemove.Name = "optChangeSkillsRemove";
			this.optChangeSkillsRemove.Size = new System.Drawing.Size(55, 17);
			this.optChangeSkillsRemove.TabIndex = 3;
			this.optChangeSkillsRemove.TabStop = true;
			this.optChangeSkillsRemove.Text = "Forget";
			//
			//optChangeSkillsAdd
			//
			this.optChangeSkillsAdd.AutoSize = true;
			this.optChangeSkillsAdd.Location = new System.Drawing.Point(65, 44);
			this.optChangeSkillsAdd.Name = "optChangeSkillsAdd";
			this.optChangeSkillsAdd.Size = new System.Drawing.Size(56, 17);
			this.optChangeSkillsAdd.TabIndex = 2;
			this.optChangeSkillsAdd.TabStop = true;
			this.optChangeSkillsAdd.Text = "Teach";
			//
			//cmbChangeSkills
			//
			this.cmbChangeSkills.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbChangeSkills.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbChangeSkills.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbChangeSkills.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbChangeSkills.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbChangeSkills.ButtonIcon"));
			this.cmbChangeSkills.DrawDropdownHoverOutline = false;
			this.cmbChangeSkills.DrawFocusRectangle = false;
			this.cmbChangeSkills.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbChangeSkills.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChangeSkills.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbChangeSkills.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbChangeSkills.FormattingEnabled = true;
			this.cmbChangeSkills.Location = new System.Drawing.Point(41, 17);
			this.cmbChangeSkills.Name = "cmbChangeSkills";
			this.cmbChangeSkills.Size = new System.Drawing.Size(198, 21);
			this.cmbChangeSkills.TabIndex = 1;
			this.cmbChangeSkills.Text = null;
			this.cmbChangeSkills.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel37
			//
			this.DarkLabel37.AutoSize = true;
			this.DarkLabel37.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel37.Location = new System.Drawing.Point(6, 20);
			this.DarkLabel37.Name = "DarkLabel37";
			this.DarkLabel37.Size = new System.Drawing.Size(29, 13);
			this.DarkLabel37.TabIndex = 0;
			this.DarkLabel37.Text = "Skill:";
			//
			//fraCompleteTask
			//
			this.fraCompleteTask.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraCompleteTask.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraCompleteTask.Controls.Add(this.btnCompleteQuestTaskOk);
			this.fraCompleteTask.Controls.Add(this.btnCompleteQuestTaskCancel);
			this.fraCompleteTask.Controls.Add(this.DarkLabel35);
			this.fraCompleteTask.Controls.Add(this.DarkLabel36);
			this.fraCompleteTask.Controls.Add(this.nudCompleteQuestTask);
			this.fraCompleteTask.Controls.Add(this.cmbCompleteQuest);
			this.fraCompleteTask.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraCompleteTask.Location = new System.Drawing.Point(401, 3);
			this.fraCompleteTask.Name = "fraCompleteTask";
			this.fraCompleteTask.Size = new System.Drawing.Size(246, 100);
			this.fraCompleteTask.TabIndex = 20;
			this.fraCompleteTask.TabStop = false;
			this.fraCompleteTask.Text = "Complete Quest Task";
			this.fraCompleteTask.Visible = false;
			//
			//btnCompleteQuestTaskOk
			//
			this.btnCompleteQuestTaskOk.Location = new System.Drawing.Point(84, 74);
			this.btnCompleteQuestTaskOk.Name = "btnCompleteQuestTaskOk";
			this.btnCompleteQuestTaskOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnCompleteQuestTaskOk.Size = new System.Drawing.Size(75, 23);
			this.btnCompleteQuestTaskOk.TabIndex = 27;
			this.btnCompleteQuestTaskOk.Text = "Ok";
			//
			//btnCompleteQuestTaskCancel
			//
			this.btnCompleteQuestTaskCancel.Location = new System.Drawing.Point(165, 74);
			this.btnCompleteQuestTaskCancel.Name = "btnCompleteQuestTaskCancel";
			this.btnCompleteQuestTaskCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnCompleteQuestTaskCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCompleteQuestTaskCancel.TabIndex = 26;
			this.btnCompleteQuestTaskCancel.Text = "Cancel";
			//
			//DarkLabel35
			//
			this.DarkLabel35.AutoSize = true;
			this.DarkLabel35.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel35.Location = new System.Drawing.Point(10, 50);
			this.DarkLabel35.Name = "DarkLabel35";
			this.DarkLabel35.Size = new System.Drawing.Size(34, 13);
			this.DarkLabel35.TabIndex = 23;
			this.DarkLabel35.Text = "Task:";
			//
			//DarkLabel36
			//
			this.DarkLabel36.AutoSize = true;
			this.DarkLabel36.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel36.Location = new System.Drawing.Point(10, 22);
			this.DarkLabel36.Name = "DarkLabel36";
			this.DarkLabel36.Size = new System.Drawing.Size(38, 13);
			this.DarkLabel36.TabIndex = 22;
			this.DarkLabel36.Text = "Quest:";
			//
			//nudCompleteQuestTask
			//
			this.nudCompleteQuestTask.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudCompleteQuestTask.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudCompleteQuestTask.Location = new System.Drawing.Point(60, 48);
			this.nudCompleteQuestTask.Maximum = new decimal(new int[] {10, 0, 0, 0});
			this.nudCompleteQuestTask.Name = "nudCompleteQuestTask";
			this.nudCompleteQuestTask.Size = new System.Drawing.Size(179, 20);
			this.nudCompleteQuestTask.TabIndex = 21;
			//
			//cmbCompleteQuest
			//
			this.cmbCompleteQuest.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCompleteQuest.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCompleteQuest.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCompleteQuest.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCompleteQuest.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCompleteQuest.ButtonIcon"));
			this.cmbCompleteQuest.DrawDropdownHoverOutline = false;
			this.cmbCompleteQuest.DrawFocusRectangle = false;
			this.cmbCompleteQuest.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCompleteQuest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCompleteQuest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCompleteQuest.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCompleteQuest.FormattingEnabled = true;
			this.cmbCompleteQuest.Location = new System.Drawing.Point(60, 19);
			this.cmbCompleteQuest.Name = "cmbCompleteQuest";
			this.cmbCompleteQuest.Size = new System.Drawing.Size(179, 21);
			this.cmbCompleteQuest.TabIndex = 20;
			this.cmbCompleteQuest.Text = null;
			this.cmbCompleteQuest.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//fraPlayerWarp
			//
			this.fraPlayerWarp.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraPlayerWarp.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraPlayerWarp.Controls.Add(this.btnPlayerWarpOk);
			this.fraPlayerWarp.Controls.Add(this.btnPlayerWarpCancel);
			this.fraPlayerWarp.Controls.Add(this.DarkLabel31);
			this.fraPlayerWarp.Controls.Add(this.cmbWarpPlayerDir);
			this.fraPlayerWarp.Controls.Add(this.nudWPY);
			this.fraPlayerWarp.Controls.Add(this.DarkLabel32);
			this.fraPlayerWarp.Controls.Add(this.nudWPX);
			this.fraPlayerWarp.Controls.Add(this.DarkLabel33);
			this.fraPlayerWarp.Controls.Add(this.nudWPMap);
			this.fraPlayerWarp.Controls.Add(this.DarkLabel34);
			this.fraPlayerWarp.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraPlayerWarp.Location = new System.Drawing.Point(401, 6);
			this.fraPlayerWarp.Name = "fraPlayerWarp";
			this.fraPlayerWarp.Size = new System.Drawing.Size(246, 97);
			this.fraPlayerWarp.TabIndex = 19;
			this.fraPlayerWarp.TabStop = false;
			this.fraPlayerWarp.Text = "Warp Player";
			this.fraPlayerWarp.Visible = false;
			//
			//btnPlayerWarpOk
			//
			this.btnPlayerWarpOk.Location = new System.Drawing.Point(83, 68);
			this.btnPlayerWarpOk.Name = "btnPlayerWarpOk";
			this.btnPlayerWarpOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnPlayerWarpOk.Size = new System.Drawing.Size(75, 23);
			this.btnPlayerWarpOk.TabIndex = 46;
			this.btnPlayerWarpOk.Text = "Ok";
			//
			//btnPlayerWarpCancel
			//
			this.btnPlayerWarpCancel.Location = new System.Drawing.Point(164, 68);
			this.btnPlayerWarpCancel.Name = "btnPlayerWarpCancel";
			this.btnPlayerWarpCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnPlayerWarpCancel.Size = new System.Drawing.Size(75, 23);
			this.btnPlayerWarpCancel.TabIndex = 45;
			this.btnPlayerWarpCancel.Text = "Cancel";
			//
			//DarkLabel31
			//
			this.DarkLabel31.AutoSize = true;
			this.DarkLabel31.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel31.Location = new System.Drawing.Point(8, 44);
			this.DarkLabel31.Name = "DarkLabel31";
			this.DarkLabel31.Size = new System.Drawing.Size(52, 13);
			this.DarkLabel31.TabIndex = 44;
			this.DarkLabel31.Text = "Direction:";
			//
			//cmbWarpPlayerDir
			//
			this.cmbWarpPlayerDir.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbWarpPlayerDir.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbWarpPlayerDir.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbWarpPlayerDir.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbWarpPlayerDir.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbWarpPlayerDir.ButtonIcon"));
			this.cmbWarpPlayerDir.DrawDropdownHoverOutline = false;
			this.cmbWarpPlayerDir.DrawFocusRectangle = false;
			this.cmbWarpPlayerDir.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbWarpPlayerDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbWarpPlayerDir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbWarpPlayerDir.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbWarpPlayerDir.FormattingEnabled = true;
			this.cmbWarpPlayerDir.Items.AddRange(new object[] {"Retain Direction", "Up", "Down", "Left", "Right"});
			this.cmbWarpPlayerDir.Location = new System.Drawing.Point(96, 41);
			this.cmbWarpPlayerDir.Name = "cmbWarpPlayerDir";
			this.cmbWarpPlayerDir.Size = new System.Drawing.Size(143, 21);
			this.cmbWarpPlayerDir.TabIndex = 43;
			this.cmbWarpPlayerDir.Text = null;
			this.cmbWarpPlayerDir.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//nudWPY
			//
			this.nudWPY.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudWPY.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudWPY.Location = new System.Drawing.Point(200, 15);
			this.nudWPY.Name = "nudWPY";
			this.nudWPY.Size = new System.Drawing.Size(39, 20);
			this.nudWPY.TabIndex = 42;
			//
			//DarkLabel32
			//
			this.DarkLabel32.AutoSize = true;
			this.DarkLabel32.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel32.Location = new System.Drawing.Point(177, 17);
			this.DarkLabel32.Name = "DarkLabel32";
			this.DarkLabel32.Size = new System.Drawing.Size(17, 13);
			this.DarkLabel32.TabIndex = 41;
			this.DarkLabel32.Text = "Y:";
			//
			//nudWPX
			//
			this.nudWPX.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudWPX.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudWPX.Location = new System.Drawing.Point(130, 15);
			this.nudWPX.Name = "nudWPX";
			this.nudWPX.Size = new System.Drawing.Size(39, 20);
			this.nudWPX.TabIndex = 40;
			//
			//DarkLabel33
			//
			this.DarkLabel33.AutoSize = true;
			this.DarkLabel33.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel33.Location = new System.Drawing.Point(107, 17);
			this.DarkLabel33.Name = "DarkLabel33";
			this.DarkLabel33.Size = new System.Drawing.Size(17, 13);
			this.DarkLabel33.TabIndex = 39;
			this.DarkLabel33.Text = "X:";
			//
			//nudWPMap
			//
			this.nudWPMap.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudWPMap.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudWPMap.Location = new System.Drawing.Point(43, 15);
			this.nudWPMap.Name = "nudWPMap";
			this.nudWPMap.Size = new System.Drawing.Size(58, 20);
			this.nudWPMap.TabIndex = 38;
			//
			//DarkLabel34
			//
			this.DarkLabel34.AutoSize = true;
			this.DarkLabel34.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel34.Location = new System.Drawing.Point(6, 17);
			this.DarkLabel34.Name = "DarkLabel34";
			this.DarkLabel34.Size = new System.Drawing.Size(31, 13);
			this.DarkLabel34.TabIndex = 37;
			this.DarkLabel34.Text = "Map:";
			//
			//fraSetFog
			//
			this.fraSetFog.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraSetFog.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraSetFog.Controls.Add(this.btnSetFogOk);
			this.fraSetFog.Controls.Add(this.btnSetFogCancel);
			this.fraSetFog.Controls.Add(this.DarkLabel30);
			this.fraSetFog.Controls.Add(this.DarkLabel29);
			this.fraSetFog.Controls.Add(this.DarkLabel28);
			this.fraSetFog.Controls.Add(this.nudFogData2);
			this.fraSetFog.Controls.Add(this.nudFogData1);
			this.fraSetFog.Controls.Add(this.nudFogData0);
			this.fraSetFog.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraSetFog.Location = new System.Drawing.Point(401, 7);
			this.fraSetFog.Name = "fraSetFog";
			this.fraSetFog.Size = new System.Drawing.Size(246, 96);
			this.fraSetFog.TabIndex = 18;
			this.fraSetFog.TabStop = false;
			this.fraSetFog.Text = "Set Fog";
			this.fraSetFog.Visible = false;
			//
			//btnSetFogOk
			//
			this.btnSetFogOk.Location = new System.Drawing.Point(84, 67);
			this.btnSetFogOk.Name = "btnSetFogOk";
			this.btnSetFogOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnSetFogOk.Size = new System.Drawing.Size(75, 23);
			this.btnSetFogOk.TabIndex = 41;
			this.btnSetFogOk.Text = "Ok";
			//
			//btnSetFogCancel
			//
			this.btnSetFogCancel.Location = new System.Drawing.Point(165, 67);
			this.btnSetFogCancel.Name = "btnSetFogCancel";
			this.btnSetFogCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnSetFogCancel.Size = new System.Drawing.Size(75, 23);
			this.btnSetFogCancel.TabIndex = 40;
			this.btnSetFogCancel.Text = "Cancel";
			//
			//DarkLabel30
			//
			this.DarkLabel30.AutoSize = true;
			this.DarkLabel30.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel30.Location = new System.Drawing.Point(124, 42);
			this.DarkLabel30.Name = "DarkLabel30";
			this.DarkLabel30.Size = new System.Drawing.Size(67, 13);
			this.DarkLabel30.TabIndex = 39;
			this.DarkLabel30.Text = "Fog Opacity:";
			//
			//DarkLabel29
			//
			this.DarkLabel29.AutoSize = true;
			this.DarkLabel29.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel29.Location = new System.Drawing.Point(7, 42);
			this.DarkLabel29.Name = "DarkLabel29";
			this.DarkLabel29.Size = new System.Drawing.Size(62, 13);
			this.DarkLabel29.TabIndex = 38;
			this.DarkLabel29.Text = "Fog Speed:";
			//
			//DarkLabel28
			//
			this.DarkLabel28.AutoSize = true;
			this.DarkLabel28.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel28.Location = new System.Drawing.Point(7, 15);
			this.DarkLabel28.Name = "DarkLabel28";
			this.DarkLabel28.Size = new System.Drawing.Size(28, 13);
			this.DarkLabel28.TabIndex = 37;
			this.DarkLabel28.Text = "Fog:";
			//
			//nudFogData2
			//
			this.nudFogData2.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudFogData2.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudFogData2.Location = new System.Drawing.Point(191, 39);
			this.nudFogData2.Maximum = new decimal(new int[] {255, 0, 0, 0});
			this.nudFogData2.Name = "nudFogData2";
			this.nudFogData2.Size = new System.Drawing.Size(49, 20);
			this.nudFogData2.TabIndex = 36;
			//
			//nudFogData1
			//
			this.nudFogData1.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudFogData1.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudFogData1.Location = new System.Drawing.Point(72, 40);
			this.nudFogData1.Name = "nudFogData1";
			this.nudFogData1.Size = new System.Drawing.Size(48, 20);
			this.nudFogData1.TabIndex = 35;
			//
			//nudFogData0
			//
			this.nudFogData0.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudFogData0.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudFogData0.Location = new System.Drawing.Point(97, 12);
			this.nudFogData0.Name = "nudFogData0";
			this.nudFogData0.Size = new System.Drawing.Size(143, 20);
			this.nudFogData0.TabIndex = 34;
			//
			//fraShowText
			//
			this.fraShowText.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraShowText.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraShowText.Controls.Add(this.DarkLabel27);
			this.fraShowText.Controls.Add(this.txtShowText);
			this.fraShowText.Controls.Add(this.btnShowTextCancel);
			this.fraShowText.Controls.Add(this.btnShowTextOk);
			this.fraShowText.Controls.Add(this.picShowTextFace);
			this.fraShowText.Controls.Add(this.DarkLabel26);
			this.fraShowText.Controls.Add(this.nudShowTextFace);
			this.fraShowText.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraShowText.Location = new System.Drawing.Point(6, 304);
			this.fraShowText.Name = "fraShowText";
			this.fraShowText.Size = new System.Drawing.Size(248, 284);
			this.fraShowText.TabIndex = 17;
			this.fraShowText.TabStop = false;
			this.fraShowText.Text = "Show Text";
			this.fraShowText.Visible = false;
			//
			//DarkLabel27
			//
			this.DarkLabel27.AutoSize = true;
			this.DarkLabel27.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel27.Location = new System.Drawing.Point(7, 19);
			this.DarkLabel27.Name = "DarkLabel27";
			this.DarkLabel27.Size = new System.Drawing.Size(28, 13);
			this.DarkLabel27.TabIndex = 26;
			this.DarkLabel27.Text = "Text";
			//
			//txtShowText
			//
			this.txtShowText.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtShowText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtShowText.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtShowText.Location = new System.Drawing.Point(9, 38);
			this.txtShowText.Multiline = true;
			this.txtShowText.Name = "txtShowText";
			this.txtShowText.Size = new System.Drawing.Size(228, 105);
			this.txtShowText.TabIndex = 21;
			//
			//btnShowTextCancel
			//
			this.btnShowTextCancel.Location = new System.Drawing.Point(167, 252);
			this.btnShowTextCancel.Name = "btnShowTextCancel";
			this.btnShowTextCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnShowTextCancel.Size = new System.Drawing.Size(75, 23);
			this.btnShowTextCancel.TabIndex = 24;
			this.btnShowTextCancel.Text = "Cancel";
			//
			//btnShowTextOk
			//
			this.btnShowTextOk.Location = new System.Drawing.Point(86, 252);
			this.btnShowTextOk.Name = "btnShowTextOk";
			this.btnShowTextOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnShowTextOk.Size = new System.Drawing.Size(75, 23);
			this.btnShowTextOk.TabIndex = 25;
			this.btnShowTextOk.Text = "Ok";
			//
			//picShowTextFace
			//
			this.picShowTextFace.BackColor = System.Drawing.Color.Black;
			this.picShowTextFace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.picShowTextFace.Location = new System.Drawing.Point(7, 149);
			this.picShowTextFace.Name = "picShowTextFace";
			this.picShowTextFace.Size = new System.Drawing.Size(100, 93);
			this.picShowTextFace.TabIndex = 2;
			this.picShowTextFace.TabStop = false;
			//
			//DarkLabel26
			//
			this.DarkLabel26.AutoSize = true;
			this.DarkLabel26.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel26.Location = new System.Drawing.Point(110, 224);
			this.DarkLabel26.Name = "DarkLabel26";
			this.DarkLabel26.Size = new System.Drawing.Size(34, 13);
			this.DarkLabel26.TabIndex = 22;
			this.DarkLabel26.Text = "Face:";
			//
			//nudShowTextFace
			//
			this.nudShowTextFace.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudShowTextFace.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudShowTextFace.Location = new System.Drawing.Point(147, 222);
			this.nudShowTextFace.Name = "nudShowTextFace";
			this.nudShowTextFace.Size = new System.Drawing.Size(92, 20);
			this.nudShowTextFace.TabIndex = 23;
			//
			//fraAddText
			//
			this.fraAddText.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraAddText.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraAddText.Controls.Add(this.btnAddTextOk);
			this.fraAddText.Controls.Add(this.btnAddTextCancel);
			this.fraAddText.Controls.Add(this.optAddText_Global);
			this.fraAddText.Controls.Add(this.optAddText_Map);
			this.fraAddText.Controls.Add(this.optAddText_Player);
			this.fraAddText.Controls.Add(this.DarkLabel25);
			this.fraAddText.Controls.Add(this.txtAddText_Text);
			this.fraAddText.Controls.Add(this.DarkLabel24);
			this.fraAddText.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraAddText.Location = new System.Drawing.Point(6, 363);
			this.fraAddText.Name = "fraAddText";
			this.fraAddText.Size = new System.Drawing.Size(233, 187);
			this.fraAddText.TabIndex = 3;
			this.fraAddText.TabStop = false;
			this.fraAddText.Text = "Add Text";
			this.fraAddText.Visible = false;
			//
			//btnAddTextOk
			//
			this.btnAddTextOk.Location = new System.Drawing.Point(55, 156);
			this.btnAddTextOk.Name = "btnAddTextOk";
			this.btnAddTextOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnAddTextOk.Size = new System.Drawing.Size(75, 23);
			this.btnAddTextOk.TabIndex = 9;
			this.btnAddTextOk.Text = "Ok";
			//
			//btnAddTextCancel
			//
			this.btnAddTextCancel.Location = new System.Drawing.Point(136, 156);
			this.btnAddTextCancel.Name = "btnAddTextCancel";
			this.btnAddTextCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnAddTextCancel.Size = new System.Drawing.Size(75, 23);
			this.btnAddTextCancel.TabIndex = 8;
			this.btnAddTextCancel.Text = "Cancel";
			//
			//optAddText_Global
			//
			this.optAddText_Global.AutoSize = true;
			this.optAddText_Global.Location = new System.Drawing.Point(173, 133);
			this.optAddText_Global.Name = "optAddText_Global";
			this.optAddText_Global.Size = new System.Drawing.Size(55, 17);
			this.optAddText_Global.TabIndex = 5;
			this.optAddText_Global.TabStop = true;
			this.optAddText_Global.Text = "Global";
			//
			//optAddText_Map
			//
			this.optAddText_Map.AutoSize = true;
			this.optAddText_Map.Location = new System.Drawing.Point(121, 133);
			this.optAddText_Map.Name = "optAddText_Map";
			this.optAddText_Map.Size = new System.Drawing.Size(46, 17);
			this.optAddText_Map.TabIndex = 4;
			this.optAddText_Map.TabStop = true;
			this.optAddText_Map.Text = "Map";
			//
			//optAddText_Player
			//
			this.optAddText_Player.AutoSize = true;
			this.optAddText_Player.Location = new System.Drawing.Point(61, 133);
			this.optAddText_Player.Name = "optAddText_Player";
			this.optAddText_Player.Size = new System.Drawing.Size(54, 17);
			this.optAddText_Player.TabIndex = 3;
			this.optAddText_Player.TabStop = true;
			this.optAddText_Player.Text = "Player";
			//
			//DarkLabel25
			//
			this.DarkLabel25.AutoSize = true;
			this.DarkLabel25.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel25.Location = new System.Drawing.Point(6, 135);
			this.DarkLabel25.Name = "DarkLabel25";
			this.DarkLabel25.Size = new System.Drawing.Size(49, 13);
			this.DarkLabel25.TabIndex = 2;
			this.DarkLabel25.Text = "Channel:";
			//
			//txtAddText_Text
			//
			this.txtAddText_Text.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.txtAddText_Text.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtAddText_Text.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.txtAddText_Text.Location = new System.Drawing.Point(6, 31);
			this.txtAddText_Text.Multiline = true;
			this.txtAddText_Text.Name = "txtAddText_Text";
			this.txtAddText_Text.Size = new System.Drawing.Size(222, 96);
			this.txtAddText_Text.TabIndex = 1;
			//
			//DarkLabel24
			//
			this.DarkLabel24.AutoSize = true;
			this.DarkLabel24.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel24.Location = new System.Drawing.Point(6, 15);
			this.DarkLabel24.Name = "DarkLabel24";
			this.DarkLabel24.Size = new System.Drawing.Size(28, 13);
			this.DarkLabel24.TabIndex = 0;
			this.DarkLabel24.Text = "Text";
			//
			//fraPlayerSwitch
			//
			this.fraPlayerSwitch.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraPlayerSwitch.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraPlayerSwitch.Controls.Add(this.btnSetPlayerSwitchOk);
			this.fraPlayerSwitch.Controls.Add(this.btnSetPlayerswitchCancel);
			this.fraPlayerSwitch.Controls.Add(this.cmbPlayerSwitchSet);
			this.fraPlayerSwitch.Controls.Add(this.DarkLabel23);
			this.fraPlayerSwitch.Controls.Add(this.cmbSwitch);
			this.fraPlayerSwitch.Controls.Add(this.DarkLabel22);
			this.fraPlayerSwitch.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraPlayerSwitch.Location = new System.Drawing.Point(213, 390);
			this.fraPlayerSwitch.Name = "fraPlayerSwitch";
			this.fraPlayerSwitch.Size = new System.Drawing.Size(182, 100);
			this.fraPlayerSwitch.TabIndex = 2;
			this.fraPlayerSwitch.TabStop = false;
			this.fraPlayerSwitch.Text = "Change Items";
			this.fraPlayerSwitch.Visible = false;
			//
			//btnSetPlayerSwitchOk
			//
			this.btnSetPlayerSwitchOk.Location = new System.Drawing.Point(20, 72);
			this.btnSetPlayerSwitchOk.Name = "btnSetPlayerSwitchOk";
			this.btnSetPlayerSwitchOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnSetPlayerSwitchOk.Size = new System.Drawing.Size(75, 23);
			this.btnSetPlayerSwitchOk.TabIndex = 9;
			this.btnSetPlayerSwitchOk.Text = "Ok";
			//
			//btnSetPlayerswitchCancel
			//
			this.btnSetPlayerswitchCancel.Location = new System.Drawing.Point(101, 72);
			this.btnSetPlayerswitchCancel.Name = "btnSetPlayerswitchCancel";
			this.btnSetPlayerswitchCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnSetPlayerswitchCancel.Size = new System.Drawing.Size(75, 23);
			this.btnSetPlayerswitchCancel.TabIndex = 8;
			this.btnSetPlayerswitchCancel.Text = "Cancel";
			//
			//cmbPlayerSwitchSet
			//
			this.cmbPlayerSwitchSet.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbPlayerSwitchSet.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbPlayerSwitchSet.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbPlayerSwitchSet.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbPlayerSwitchSet.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbPlayerSwitchSet.ButtonIcon"));
			this.cmbPlayerSwitchSet.DrawDropdownHoverOutline = false;
			this.cmbPlayerSwitchSet.DrawFocusRectangle = false;
			this.cmbPlayerSwitchSet.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPlayerSwitchSet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPlayerSwitchSet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPlayerSwitchSet.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbPlayerSwitchSet.FormattingEnabled = true;
			this.cmbPlayerSwitchSet.Items.AddRange(new object[] {"False", "True"});
			this.cmbPlayerSwitchSet.Location = new System.Drawing.Point(51, 41);
			this.cmbPlayerSwitchSet.Name = "cmbPlayerSwitchSet";
			this.cmbPlayerSwitchSet.Size = new System.Drawing.Size(125, 21);
			this.cmbPlayerSwitchSet.TabIndex = 3;
			this.cmbPlayerSwitchSet.Text = null;
			this.cmbPlayerSwitchSet.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel23
			//
			this.DarkLabel23.AutoSize = true;
			this.DarkLabel23.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel23.Location = new System.Drawing.Point(6, 46);
			this.DarkLabel23.Name = "DarkLabel23";
			this.DarkLabel23.Size = new System.Drawing.Size(35, 13);
			this.DarkLabel23.TabIndex = 2;
			this.DarkLabel23.Text = "Set to";
			//
			//cmbSwitch
			//
			this.cmbSwitch.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbSwitch.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbSwitch.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbSwitch.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbSwitch.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbSwitch.ButtonIcon"));
			this.cmbSwitch.DrawDropdownHoverOutline = false;
			this.cmbSwitch.DrawFocusRectangle = false;
			this.cmbSwitch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbSwitch.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbSwitch.FormattingEnabled = true;
			this.cmbSwitch.Location = new System.Drawing.Point(51, 13);
			this.cmbSwitch.Name = "cmbSwitch";
			this.cmbSwitch.Size = new System.Drawing.Size(125, 21);
			this.cmbSwitch.TabIndex = 1;
			this.cmbSwitch.Text = null;
			this.cmbSwitch.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel22
			//
			this.DarkLabel22.AutoSize = true;
			this.DarkLabel22.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel22.Location = new System.Drawing.Point(6, 16);
			this.DarkLabel22.Name = "DarkLabel22";
			this.DarkLabel22.Size = new System.Drawing.Size(39, 13);
			this.DarkLabel22.TabIndex = 0;
			this.DarkLabel22.Text = "Switch";
			//
			//fraChangeItems
			//
			this.fraChangeItems.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraChangeItems.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraChangeItems.Controls.Add(this.btnChangeItemsOk);
			this.fraChangeItems.Controls.Add(this.btnChangeItemsCancel);
			this.fraChangeItems.Controls.Add(this.nudChangeItemsAmount);
			this.fraChangeItems.Controls.Add(this.optChangeItemRemove);
			this.fraChangeItems.Controls.Add(this.optChangeItemAdd);
			this.fraChangeItems.Controls.Add(this.optChangeItemSet);
			this.fraChangeItems.Controls.Add(this.cmbChangeItemIndex);
			this.fraChangeItems.Controls.Add(this.DarkLabel21);
			this.fraChangeItems.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraChangeItems.Location = new System.Drawing.Point(6, 390);
			this.fraChangeItems.Name = "fraChangeItems";
			this.fraChangeItems.Size = new System.Drawing.Size(187, 120);
			this.fraChangeItems.TabIndex = 1;
			this.fraChangeItems.TabStop = false;
			this.fraChangeItems.Text = "Change Items";
			this.fraChangeItems.Visible = false;
			//
			//btnChangeItemsOk
			//
			this.btnChangeItemsOk.Location = new System.Drawing.Point(25, 91);
			this.btnChangeItemsOk.Name = "btnChangeItemsOk";
			this.btnChangeItemsOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangeItemsOk.Size = new System.Drawing.Size(75, 23);
			this.btnChangeItemsOk.TabIndex = 7;
			this.btnChangeItemsOk.Text = "Ok";
			//
			//btnChangeItemsCancel
			//
			this.btnChangeItemsCancel.Location = new System.Drawing.Point(106, 91);
			this.btnChangeItemsCancel.Name = "btnChangeItemsCancel";
			this.btnChangeItemsCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnChangeItemsCancel.Size = new System.Drawing.Size(75, 23);
			this.btnChangeItemsCancel.TabIndex = 6;
			this.btnChangeItemsCancel.Text = "Cancel";
			//
			//nudChangeItemsAmount
			//
			this.nudChangeItemsAmount.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudChangeItemsAmount.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudChangeItemsAmount.Location = new System.Drawing.Point(9, 65);
			this.nudChangeItemsAmount.Name = "nudChangeItemsAmount";
			this.nudChangeItemsAmount.Size = new System.Drawing.Size(172, 20);
			this.nudChangeItemsAmount.TabIndex = 5;
			//
			//optChangeItemRemove
			//
			this.optChangeItemRemove.AutoSize = true;
			this.optChangeItemRemove.Location = new System.Drawing.Point(121, 42);
			this.optChangeItemRemove.Name = "optChangeItemRemove";
			this.optChangeItemRemove.Size = new System.Drawing.Size(50, 17);
			this.optChangeItemRemove.TabIndex = 4;
			this.optChangeItemRemove.TabStop = true;
			this.optChangeItemRemove.Text = "Take";
			//
			//optChangeItemAdd
			//
			this.optChangeItemAdd.AutoSize = true;
			this.optChangeItemAdd.Location = new System.Drawing.Point(68, 42);
			this.optChangeItemAdd.Name = "optChangeItemAdd";
			this.optChangeItemAdd.Size = new System.Drawing.Size(47, 17);
			this.optChangeItemAdd.TabIndex = 3;
			this.optChangeItemAdd.TabStop = true;
			this.optChangeItemAdd.Text = "Give";
			//
			//optChangeItemSet
			//
			this.optChangeItemSet.AutoSize = true;
			this.optChangeItemSet.Location = new System.Drawing.Point(9, 42);
			this.optChangeItemSet.Name = "optChangeItemSet";
			this.optChangeItemSet.Size = new System.Drawing.Size(53, 17);
			this.optChangeItemSet.TabIndex = 2;
			this.optChangeItemSet.TabStop = true;
			this.optChangeItemSet.Text = "Set to";
			//
			//cmbChangeItemIndex
			//
			this.cmbChangeItemIndex.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbChangeItemIndex.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbChangeItemIndex.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbChangeItemIndex.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbChangeItemIndex.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbChangeItemIndex.ButtonIcon"));
			this.cmbChangeItemIndex.DrawDropdownHoverOutline = false;
			this.cmbChangeItemIndex.DrawFocusRectangle = false;
			this.cmbChangeItemIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbChangeItemIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbChangeItemIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbChangeItemIndex.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbChangeItemIndex.FormattingEnabled = true;
			this.cmbChangeItemIndex.Location = new System.Drawing.Point(42, 13);
			this.cmbChangeItemIndex.Name = "cmbChangeItemIndex";
			this.cmbChangeItemIndex.Size = new System.Drawing.Size(139, 21);
			this.cmbChangeItemIndex.TabIndex = 1;
			this.cmbChangeItemIndex.Text = null;
			this.cmbChangeItemIndex.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel21
			//
			this.DarkLabel21.AutoSize = true;
			this.DarkLabel21.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel21.Location = new System.Drawing.Point(6, 16);
			this.DarkLabel21.Name = "DarkLabel21";
			this.DarkLabel21.Size = new System.Drawing.Size(30, 13);
			this.DarkLabel21.TabIndex = 0;
			this.DarkLabel21.Text = "Item:";
			//
			//fraConditionalBranch
			//
			this.fraConditionalBranch.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraConditionalBranch.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraConditionalBranch.Controls.Add(this.cmbCondition_Time);
			this.fraConditionalBranch.Controls.Add(this.optCondition9);
			this.fraConditionalBranch.Controls.Add(this.btnConditionalBranchOk);
			this.fraConditionalBranch.Controls.Add(this.btnConditionalBranchCancel);
			this.fraConditionalBranch.Controls.Add(this.cmbCondition_Gender);
			this.fraConditionalBranch.Controls.Add(this.optCondition8);
			this.fraConditionalBranch.Controls.Add(this.fraConditions_Quest);
			this.fraConditionalBranch.Controls.Add(this.nudCondition_Quest);
			this.fraConditionalBranch.Controls.Add(this.DarkLabel18);
			this.fraConditionalBranch.Controls.Add(this.optCondition7);
			this.fraConditionalBranch.Controls.Add(this.cmbCondition_SelfSwitchCondition);
			this.fraConditionalBranch.Controls.Add(this.DarkLabel17);
			this.fraConditionalBranch.Controls.Add(this.cmbCondition_SelfSwitch);
			this.fraConditionalBranch.Controls.Add(this.optCondition6);
			this.fraConditionalBranch.Controls.Add(this.nudCondition_LevelAmount);
			this.fraConditionalBranch.Controls.Add(this.optCondition5);
			this.fraConditionalBranch.Controls.Add(this.cmbCondition_LevelCompare);
			this.fraConditionalBranch.Controls.Add(this.cmbCondition_LearntSkill);
			this.fraConditionalBranch.Controls.Add(this.optCondition4);
			this.fraConditionalBranch.Controls.Add(this.cmbCondition_ClassIs);
			this.fraConditionalBranch.Controls.Add(this.optCondition3);
			this.fraConditionalBranch.Controls.Add(this.nudCondition_HasItem);
			this.fraConditionalBranch.Controls.Add(this.DarkLabel16);
			this.fraConditionalBranch.Controls.Add(this.cmbCondition_HasItem);
			this.fraConditionalBranch.Controls.Add(this.optCondition2);
			this.fraConditionalBranch.Controls.Add(this.optCondition1);
			this.fraConditionalBranch.Controls.Add(this.DarkLabel15);
			this.fraConditionalBranch.Controls.Add(this.cmbCondtion_PlayerSwitchCondition);
			this.fraConditionalBranch.Controls.Add(this.cmbCondition_PlayerSwitch);
			this.fraConditionalBranch.Controls.Add(this.nudCondition_PlayerVarCondition);
			this.fraConditionalBranch.Controls.Add(this.cmbCondition_PlayerVarCompare);
			this.fraConditionalBranch.Controls.Add(this.DarkLabel14);
			this.fraConditionalBranch.Controls.Add(this.cmbCondition_PlayerVarIndex);
			this.fraConditionalBranch.Controls.Add(this.optCondition0);
			this.fraConditionalBranch.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraConditionalBranch.Location = new System.Drawing.Point(6, 7);
			this.fraConditionalBranch.Name = "fraConditionalBranch";
			this.fraConditionalBranch.Size = new System.Drawing.Size(389, 447);
			this.fraConditionalBranch.TabIndex = 0;
			this.fraConditionalBranch.TabStop = false;
			this.fraConditionalBranch.Text = "Conditional Branch";
			this.fraConditionalBranch.Visible = false;
			//
			//btnConditionalBranchOk
			//
			this.btnConditionalBranchOk.Location = new System.Drawing.Point(226, 416);
			this.btnConditionalBranchOk.Name = "btnConditionalBranchOk";
			this.btnConditionalBranchOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnConditionalBranchOk.Size = new System.Drawing.Size(75, 23);
			this.btnConditionalBranchOk.TabIndex = 31;
			this.btnConditionalBranchOk.Text = "Ok";
			//
			//btnConditionalBranchCancel
			//
			this.btnConditionalBranchCancel.Location = new System.Drawing.Point(307, 416);
			this.btnConditionalBranchCancel.Name = "btnConditionalBranchCancel";
			this.btnConditionalBranchCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnConditionalBranchCancel.Size = new System.Drawing.Size(75, 23);
			this.btnConditionalBranchCancel.TabIndex = 30;
			this.btnConditionalBranchCancel.Text = "Cancel";
			//
			//cmbCondition_Gender
			//
			this.cmbCondition_Gender.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCondition_Gender.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCondition_Gender.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCondition_Gender.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCondition_Gender.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCondition_Gender.ButtonIcon"));
			this.cmbCondition_Gender.DrawDropdownHoverOutline = false;
			this.cmbCondition_Gender.DrawFocusRectangle = false;
			this.cmbCondition_Gender.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCondition_Gender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondition_Gender.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCondition_Gender.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCondition_Gender.FormattingEnabled = true;
			this.cmbCondition_Gender.Items.AddRange(new object[] {"Male", "Female"});
			this.cmbCondition_Gender.Location = new System.Drawing.Point(239, 318);
			this.cmbCondition_Gender.Name = "cmbCondition_Gender";
			this.cmbCondition_Gender.Size = new System.Drawing.Size(144, 21);
			this.cmbCondition_Gender.TabIndex = 29;
			this.cmbCondition_Gender.Text = null;
			this.cmbCondition_Gender.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//optCondition8
			//
			this.optCondition8.AutoSize = true;
			this.optCondition8.Location = new System.Drawing.Point(6, 319);
			this.optCondition8.Name = "optCondition8";
			this.optCondition8.Size = new System.Drawing.Size(102, 17);
			this.optCondition8.TabIndex = 28;
			this.optCondition8.TabStop = true;
			this.optCondition8.Text = "Player Gender is";
			//
			//fraConditions_Quest
			//
			this.fraConditions_Quest.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraConditions_Quest.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraConditions_Quest.Controls.Add(this.DarkLabel20);
			this.fraConditions_Quest.Controls.Add(this.nudCondition_QuestTask);
			this.fraConditions_Quest.Controls.Add(this.cmbCondition_General);
			this.fraConditions_Quest.Controls.Add(this.DarkLabel19);
			this.fraConditions_Quest.Controls.Add(this.optCondition_Quest1);
			this.fraConditions_Quest.Controls.Add(this.optCondition_Quest0);
			this.fraConditions_Quest.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraConditions_Quest.Location = new System.Drawing.Point(6, 236);
			this.fraConditions_Quest.Name = "fraConditions_Quest";
			this.fraConditions_Quest.Size = new System.Drawing.Size(376, 77);
			this.fraConditions_Quest.TabIndex = 27;
			this.fraConditions_Quest.TabStop = false;
			this.fraConditions_Quest.Text = "Quest Conditions";
			//
			//DarkLabel20
			//
			this.DarkLabel20.AutoSize = true;
			this.DarkLabel20.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel20.Location = new System.Drawing.Point(123, 47);
			this.DarkLabel20.Name = "DarkLabel20";
			this.DarkLabel20.Size = new System.Drawing.Size(93, 13);
			this.DarkLabel20.TabIndex = 5;
			this.DarkLabel20.Text = "Player is on task...";
			//
			//nudCondition_QuestTask
			//
			this.nudCondition_QuestTask.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudCondition_QuestTask.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudCondition_QuestTask.Location = new System.Drawing.Point(233, 45);
			this.nudCondition_QuestTask.Name = "nudCondition_QuestTask";
			this.nudCondition_QuestTask.Size = new System.Drawing.Size(137, 20);
			this.nudCondition_QuestTask.TabIndex = 4;
			//
			//cmbCondition_General
			//
			this.cmbCondition_General.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCondition_General.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCondition_General.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCondition_General.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCondition_General.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCondition_General.ButtonIcon"));
			this.cmbCondition_General.DrawDropdownHoverOutline = false;
			this.cmbCondition_General.DrawFocusRectangle = false;
			this.cmbCondition_General.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCondition_General.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondition_General.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCondition_General.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCondition_General.FormattingEnabled = true;
			this.cmbCondition_General.Items.AddRange(new object[] {"Not Started", "Started", "Completed", "Can Start", "Can End"});
			this.cmbCondition_General.Location = new System.Drawing.Point(233, 18);
			this.cmbCondition_General.Name = "cmbCondition_General";
			this.cmbCondition_General.Size = new System.Drawing.Size(137, 21);
			this.cmbCondition_General.TabIndex = 3;
			this.cmbCondition_General.Text = null;
			this.cmbCondition_General.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel19
			//
			this.DarkLabel19.AutoSize = true;
			this.DarkLabel19.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel19.Location = new System.Drawing.Point(123, 21);
			this.DarkLabel19.Name = "DarkLabel19";
			this.DarkLabel19.Size = new System.Drawing.Size(104, 13);
			this.DarkLabel19.TabIndex = 2;
			this.DarkLabel19.Text = "If selected quest is...";
			//
			//optCondition_Quest1
			//
			this.optCondition_Quest1.AutoSize = true;
			this.optCondition_Quest1.Location = new System.Drawing.Point(6, 45);
			this.optCondition_Quest1.Name = "optCondition_Quest1";
			this.optCondition_Quest1.Size = new System.Drawing.Size(49, 17);
			this.optCondition_Quest1.TabIndex = 1;
			this.optCondition_Quest1.TabStop = true;
			this.optCondition_Quest1.Text = "Task";
			//
			//optCondition_Quest0
			//
			this.optCondition_Quest0.AutoSize = true;
			this.optCondition_Quest0.Location = new System.Drawing.Point(6, 19);
			this.optCondition_Quest0.Name = "optCondition_Quest0";
			this.optCondition_Quest0.Size = new System.Drawing.Size(62, 17);
			this.optCondition_Quest0.TabIndex = 0;
			this.optCondition_Quest0.TabStop = true;
			this.optCondition_Quest0.Text = "General";
			//
			//nudCondition_Quest
			//
			this.nudCondition_Quest.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudCondition_Quest.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudCondition_Quest.Location = new System.Drawing.Point(262, 210);
			this.nudCondition_Quest.Name = "nudCondition_Quest";
			this.nudCondition_Quest.Size = new System.Drawing.Size(120, 20);
			this.nudCondition_Quest.TabIndex = 26;
			//
			//DarkLabel18
			//
			this.DarkLabel18.AutoSize = true;
			this.DarkLabel18.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel18.Location = new System.Drawing.Point(218, 213);
			this.DarkLabel18.Name = "DarkLabel18";
			this.DarkLabel18.Size = new System.Drawing.Size(38, 13);
			this.DarkLabel18.TabIndex = 25;
			this.DarkLabel18.Text = "Quest:";
			//
			//optCondition7
			//
			this.optCondition7.AutoSize = true;
			this.optCondition7.Location = new System.Drawing.Point(6, 210);
			this.optCondition7.Name = "optCondition7";
			this.optCondition7.Size = new System.Drawing.Size(86, 17);
			this.optCondition7.TabIndex = 24;
			this.optCondition7.TabStop = true;
			this.optCondition7.Text = "Quest Status";
			//
			//cmbCondition_SelfSwitchCondition
			//
			this.cmbCondition_SelfSwitchCondition.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCondition_SelfSwitchCondition.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCondition_SelfSwitchCondition.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCondition_SelfSwitchCondition.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCondition_SelfSwitchCondition.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCondition_SelfSwitchCondition.ButtonIcon"));
			this.cmbCondition_SelfSwitchCondition.DrawDropdownHoverOutline = false;
			this.cmbCondition_SelfSwitchCondition.DrawFocusRectangle = false;
			this.cmbCondition_SelfSwitchCondition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCondition_SelfSwitchCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondition_SelfSwitchCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCondition_SelfSwitchCondition.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCondition_SelfSwitchCondition.FormattingEnabled = true;
			this.cmbCondition_SelfSwitchCondition.Items.AddRange(new object[] {"False", "True"});
			this.cmbCondition_SelfSwitchCondition.Location = new System.Drawing.Point(262, 183);
			this.cmbCondition_SelfSwitchCondition.Name = "cmbCondition_SelfSwitchCondition";
			this.cmbCondition_SelfSwitchCondition.Size = new System.Drawing.Size(121, 21);
			this.cmbCondition_SelfSwitchCondition.TabIndex = 23;
			this.cmbCondition_SelfSwitchCondition.Text = null;
			this.cmbCondition_SelfSwitchCondition.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel17
			//
			this.DarkLabel17.AutoSize = true;
			this.DarkLabel17.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel17.Location = new System.Drawing.Point(234, 186);
			this.DarkLabel17.Name = "DarkLabel17";
			this.DarkLabel17.Size = new System.Drawing.Size(14, 13);
			this.DarkLabel17.TabIndex = 22;
			this.DarkLabel17.Text = "is";
			//
			//cmbCondition_SelfSwitch
			//
			this.cmbCondition_SelfSwitch.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCondition_SelfSwitch.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCondition_SelfSwitch.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCondition_SelfSwitch.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCondition_SelfSwitch.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCondition_SelfSwitch.ButtonIcon"));
			this.cmbCondition_SelfSwitch.DrawDropdownHoverOutline = false;
			this.cmbCondition_SelfSwitch.DrawFocusRectangle = false;
			this.cmbCondition_SelfSwitch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCondition_SelfSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondition_SelfSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCondition_SelfSwitch.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCondition_SelfSwitch.FormattingEnabled = true;
			this.cmbCondition_SelfSwitch.Location = new System.Drawing.Point(107, 183);
			this.cmbCondition_SelfSwitch.Name = "cmbCondition_SelfSwitch";
			this.cmbCondition_SelfSwitch.Size = new System.Drawing.Size(121, 21);
			this.cmbCondition_SelfSwitch.TabIndex = 21;
			this.cmbCondition_SelfSwitch.Text = null;
			this.cmbCondition_SelfSwitch.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//optCondition6
			//
			this.optCondition6.AutoSize = true;
			this.optCondition6.Location = new System.Drawing.Point(6, 184);
			this.optCondition6.Name = "optCondition6";
			this.optCondition6.Size = new System.Drawing.Size(78, 17);
			this.optCondition6.TabIndex = 20;
			this.optCondition6.TabStop = true;
			this.optCondition6.Text = "Self Switch";
			//
			//nudCondition_LevelAmount
			//
			this.nudCondition_LevelAmount.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudCondition_LevelAmount.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudCondition_LevelAmount.Location = new System.Drawing.Point(269, 157);
			this.nudCondition_LevelAmount.Name = "nudCondition_LevelAmount";
			this.nudCondition_LevelAmount.Size = new System.Drawing.Size(113, 20);
			this.nudCondition_LevelAmount.TabIndex = 19;
			//
			//optCondition5
			//
			this.optCondition5.AutoSize = true;
			this.optCondition5.Location = new System.Drawing.Point(6, 157);
			this.optCondition5.Name = "optCondition5";
			this.optCondition5.Size = new System.Drawing.Size(61, 17);
			this.optCondition5.TabIndex = 18;
			this.optCondition5.TabStop = true;
			this.optCondition5.Text = "Level is";
			//
			//cmbCondition_LevelCompare
			//
			this.cmbCondition_LevelCompare.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCondition_LevelCompare.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCondition_LevelCompare.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCondition_LevelCompare.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCondition_LevelCompare.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCondition_LevelCompare.ButtonIcon"));
			this.cmbCondition_LevelCompare.DrawDropdownHoverOutline = false;
			this.cmbCondition_LevelCompare.DrawFocusRectangle = false;
			this.cmbCondition_LevelCompare.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCondition_LevelCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondition_LevelCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCondition_LevelCompare.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCondition_LevelCompare.FormattingEnabled = true;
			this.cmbCondition_LevelCompare.Items.AddRange(new object[] {"Equal To", "Great Than OrElse Equal To", "Less Than or Equal To", "Greater Than", "Less Than", "Does Not Equal"});
			this.cmbCondition_LevelCompare.Location = new System.Drawing.Point(107, 156);
			this.cmbCondition_LevelCompare.Name = "cmbCondition_LevelCompare";
			this.cmbCondition_LevelCompare.Size = new System.Drawing.Size(156, 21);
			this.cmbCondition_LevelCompare.TabIndex = 17;
			this.cmbCondition_LevelCompare.Text = null;
			this.cmbCondition_LevelCompare.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//cmbCondition_LearntSkill
			//
			this.cmbCondition_LearntSkill.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCondition_LearntSkill.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCondition_LearntSkill.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCondition_LearntSkill.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCondition_LearntSkill.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCondition_LearntSkill.ButtonIcon"));
			this.cmbCondition_LearntSkill.DrawDropdownHoverOutline = false;
			this.cmbCondition_LearntSkill.DrawFocusRectangle = false;
			this.cmbCondition_LearntSkill.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCondition_LearntSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondition_LearntSkill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCondition_LearntSkill.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCondition_LearntSkill.FormattingEnabled = true;
			this.cmbCondition_LearntSkill.Location = new System.Drawing.Point(107, 129);
			this.cmbCondition_LearntSkill.Name = "cmbCondition_LearntSkill";
			this.cmbCondition_LearntSkill.Size = new System.Drawing.Size(276, 21);
			this.cmbCondition_LearntSkill.TabIndex = 16;
			this.cmbCondition_LearntSkill.Text = null;
			this.cmbCondition_LearntSkill.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//optCondition4
			//
			this.optCondition4.AutoSize = true;
			this.optCondition4.Location = new System.Drawing.Point(6, 130);
			this.optCondition4.Name = "optCondition4";
			this.optCondition4.Size = new System.Drawing.Size(79, 17);
			this.optCondition4.TabIndex = 15;
			this.optCondition4.TabStop = true;
			this.optCondition4.Text = "Knows Skill";
			//
			//cmbCondition_ClassIs
			//
			this.cmbCondition_ClassIs.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCondition_ClassIs.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCondition_ClassIs.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCondition_ClassIs.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCondition_ClassIs.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCondition_ClassIs.ButtonIcon"));
			this.cmbCondition_ClassIs.DrawDropdownHoverOutline = false;
			this.cmbCondition_ClassIs.DrawFocusRectangle = false;
			this.cmbCondition_ClassIs.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCondition_ClassIs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondition_ClassIs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCondition_ClassIs.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCondition_ClassIs.FormattingEnabled = true;
			this.cmbCondition_ClassIs.Location = new System.Drawing.Point(107, 102);
			this.cmbCondition_ClassIs.Name = "cmbCondition_ClassIs";
			this.cmbCondition_ClassIs.Size = new System.Drawing.Size(276, 21);
			this.cmbCondition_ClassIs.TabIndex = 14;
			this.cmbCondition_ClassIs.Text = null;
			this.cmbCondition_ClassIs.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//optCondition3
			//
			this.optCondition3.AutoSize = true;
			this.optCondition3.Location = new System.Drawing.Point(6, 103);
			this.optCondition3.Name = "optCondition3";
			this.optCondition3.Size = new System.Drawing.Size(61, 17);
			this.optCondition3.TabIndex = 13;
			this.optCondition3.TabStop = true;
			this.optCondition3.Text = "Class Is";
			//
			//nudCondition_HasItem
			//
			this.nudCondition_HasItem.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudCondition_HasItem.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudCondition_HasItem.Location = new System.Drawing.Point(262, 76);
			this.nudCondition_HasItem.Name = "nudCondition_HasItem";
			this.nudCondition_HasItem.Size = new System.Drawing.Size(120, 20);
			this.nudCondition_HasItem.TabIndex = 12;
			//
			//DarkLabel16
			//
			this.DarkLabel16.AutoSize = true;
			this.DarkLabel16.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel16.Location = new System.Drawing.Point(234, 78);
			this.DarkLabel16.Name = "DarkLabel16";
			this.DarkLabel16.Size = new System.Drawing.Size(14, 13);
			this.DarkLabel16.TabIndex = 11;
			this.DarkLabel16.Text = "X";
			//
			//cmbCondition_HasItem
			//
			this.cmbCondition_HasItem.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCondition_HasItem.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCondition_HasItem.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCondition_HasItem.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCondition_HasItem.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCondition_HasItem.ButtonIcon"));
			this.cmbCondition_HasItem.DrawDropdownHoverOutline = false;
			this.cmbCondition_HasItem.DrawFocusRectangle = false;
			this.cmbCondition_HasItem.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCondition_HasItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondition_HasItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCondition_HasItem.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCondition_HasItem.FormattingEnabled = true;
			this.cmbCondition_HasItem.Location = new System.Drawing.Point(107, 75);
			this.cmbCondition_HasItem.Name = "cmbCondition_HasItem";
			this.cmbCondition_HasItem.Size = new System.Drawing.Size(121, 21);
			this.cmbCondition_HasItem.TabIndex = 10;
			this.cmbCondition_HasItem.Text = null;
			this.cmbCondition_HasItem.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//optCondition2
			//
			this.optCondition2.AutoSize = true;
			this.optCondition2.Location = new System.Drawing.Point(6, 76);
			this.optCondition2.Name = "optCondition2";
			this.optCondition2.Size = new System.Drawing.Size(67, 17);
			this.optCondition2.TabIndex = 9;
			this.optCondition2.TabStop = true;
			this.optCondition2.Text = "Has Item";
			//
			//optCondition1
			//
			this.optCondition1.AutoSize = true;
			this.optCondition1.Location = new System.Drawing.Point(6, 49);
			this.optCondition1.Name = "optCondition1";
			this.optCondition1.Size = new System.Drawing.Size(89, 17);
			this.optCondition1.TabIndex = 8;
			this.optCondition1.TabStop = true;
			this.optCondition1.Text = "Player Switch";
			//
			//DarkLabel15
			//
			this.DarkLabel15.AutoSize = true;
			this.DarkLabel15.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel15.Location = new System.Drawing.Point(234, 51);
			this.DarkLabel15.Name = "DarkLabel15";
			this.DarkLabel15.Size = new System.Drawing.Size(14, 13);
			this.DarkLabel15.TabIndex = 7;
			this.DarkLabel15.Text = "is";
			//
			//cmbCondtion_PlayerSwitchCondition
			//
			this.cmbCondtion_PlayerSwitchCondition.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCondtion_PlayerSwitchCondition.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCondtion_PlayerSwitchCondition.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCondtion_PlayerSwitchCondition.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCondtion_PlayerSwitchCondition.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCondtion_PlayerSwitchCondition.ButtonIcon"));
			this.cmbCondtion_PlayerSwitchCondition.DrawDropdownHoverOutline = false;
			this.cmbCondtion_PlayerSwitchCondition.DrawFocusRectangle = false;
			this.cmbCondtion_PlayerSwitchCondition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCondtion_PlayerSwitchCondition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondtion_PlayerSwitchCondition.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCondtion_PlayerSwitchCondition.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCondtion_PlayerSwitchCondition.FormattingEnabled = true;
			this.cmbCondtion_PlayerSwitchCondition.Items.AddRange(new object[] {"False", "True"});
			this.cmbCondtion_PlayerSwitchCondition.Location = new System.Drawing.Point(262, 48);
			this.cmbCondtion_PlayerSwitchCondition.Name = "cmbCondtion_PlayerSwitchCondition";
			this.cmbCondtion_PlayerSwitchCondition.Size = new System.Drawing.Size(121, 21);
			this.cmbCondtion_PlayerSwitchCondition.TabIndex = 6;
			this.cmbCondtion_PlayerSwitchCondition.Text = null;
			this.cmbCondtion_PlayerSwitchCondition.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//cmbCondition_PlayerSwitch
			//
			this.cmbCondition_PlayerSwitch.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCondition_PlayerSwitch.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCondition_PlayerSwitch.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCondition_PlayerSwitch.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCondition_PlayerSwitch.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCondition_PlayerSwitch.ButtonIcon"));
			this.cmbCondition_PlayerSwitch.DrawDropdownHoverOutline = false;
			this.cmbCondition_PlayerSwitch.DrawFocusRectangle = false;
			this.cmbCondition_PlayerSwitch.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCondition_PlayerSwitch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondition_PlayerSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCondition_PlayerSwitch.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCondition_PlayerSwitch.FormattingEnabled = true;
			this.cmbCondition_PlayerSwitch.Location = new System.Drawing.Point(107, 48);
			this.cmbCondition_PlayerSwitch.Name = "cmbCondition_PlayerSwitch";
			this.cmbCondition_PlayerSwitch.Size = new System.Drawing.Size(121, 21);
			this.cmbCondition_PlayerSwitch.TabIndex = 5;
			this.cmbCondition_PlayerSwitch.Text = null;
			this.cmbCondition_PlayerSwitch.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//nudCondition_PlayerVarCondition
			//
			this.nudCondition_PlayerVarCondition.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.nudCondition_PlayerVarCondition.ForeColor = System.Drawing.Color.Gainsboro;
			this.nudCondition_PlayerVarCondition.Location = new System.Drawing.Point(335, 22);
			this.nudCondition_PlayerVarCondition.Name = "nudCondition_PlayerVarCondition";
			this.nudCondition_PlayerVarCondition.Size = new System.Drawing.Size(47, 20);
			this.nudCondition_PlayerVarCondition.TabIndex = 4;
			//
			//cmbCondition_PlayerVarCompare
			//
			this.cmbCondition_PlayerVarCompare.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCondition_PlayerVarCompare.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCondition_PlayerVarCompare.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCondition_PlayerVarCompare.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCondition_PlayerVarCompare.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCondition_PlayerVarCompare.ButtonIcon"));
			this.cmbCondition_PlayerVarCompare.DrawDropdownHoverOutline = false;
			this.cmbCondition_PlayerVarCompare.DrawFocusRectangle = false;
			this.cmbCondition_PlayerVarCompare.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCondition_PlayerVarCompare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondition_PlayerVarCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCondition_PlayerVarCompare.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCondition_PlayerVarCompare.FormattingEnabled = true;
			this.cmbCondition_PlayerVarCompare.Items.AddRange(new object[] {"Equal To", "Great Than OrElse Equal To", "Less Than or Equal To", "Greater Than", "Less Than", "Does Not Equal"});
			this.cmbCondition_PlayerVarCompare.Location = new System.Drawing.Point(236, 21);
			this.cmbCondition_PlayerVarCompare.Name = "cmbCondition_PlayerVarCompare";
			this.cmbCondition_PlayerVarCompare.Size = new System.Drawing.Size(88, 21);
			this.cmbCondition_PlayerVarCompare.TabIndex = 3;
			this.cmbCondition_PlayerVarCompare.Text = null;
			this.cmbCondition_PlayerVarCompare.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//DarkLabel14
			//
			this.DarkLabel14.AutoSize = true;
			this.DarkLabel14.ForeColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)), System.Convert.ToInt32(System.Convert.ToByte(220)));
			this.DarkLabel14.Location = new System.Drawing.Point(216, 24);
			this.DarkLabel14.Name = "DarkLabel14";
			this.DarkLabel14.Size = new System.Drawing.Size(14, 13);
			this.DarkLabel14.TabIndex = 2;
			this.DarkLabel14.Text = "is";
			//
			//cmbCondition_PlayerVarIndex
			//
			this.cmbCondition_PlayerVarIndex.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCondition_PlayerVarIndex.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCondition_PlayerVarIndex.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCondition_PlayerVarIndex.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCondition_PlayerVarIndex.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCondition_PlayerVarIndex.ButtonIcon"));
			this.cmbCondition_PlayerVarIndex.DrawDropdownHoverOutline = false;
			this.cmbCondition_PlayerVarIndex.DrawFocusRectangle = false;
			this.cmbCondition_PlayerVarIndex.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbCondition_PlayerVarIndex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondition_PlayerVarIndex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCondition_PlayerVarIndex.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCondition_PlayerVarIndex.FormattingEnabled = true;
			this.cmbCondition_PlayerVarIndex.Location = new System.Drawing.Point(107, 21);
			this.cmbCondition_PlayerVarIndex.Name = "cmbCondition_PlayerVarIndex";
			this.cmbCondition_PlayerVarIndex.Size = new System.Drawing.Size(103, 21);
			this.cmbCondition_PlayerVarIndex.TabIndex = 1;
			this.cmbCondition_PlayerVarIndex.Text = null;
			this.cmbCondition_PlayerVarIndex.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//optCondition0
			//
			this.optCondition0.AutoSize = true;
			this.optCondition0.Location = new System.Drawing.Point(6, 22);
			this.optCondition0.Name = "optCondition0";
			this.optCondition0.Size = new System.Drawing.Size(95, 17);
			this.optCondition0.TabIndex = 0;
			this.optCondition0.TabStop = true;
			this.optCondition0.Text = "Player Variable";
			//
			//fraPlayBGM
			//
			this.fraPlayBGM.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraPlayBGM.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraPlayBGM.Controls.Add(this.btnPlayBgmOk);
			this.fraPlayBGM.Controls.Add(this.btnPlayBgmCancel);
			this.fraPlayBGM.Controls.Add(this.cmbPlayBGM);
			this.fraPlayBGM.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraPlayBGM.Location = new System.Drawing.Point(401, 1);
			this.fraPlayBGM.Name = "fraPlayBGM";
			this.fraPlayBGM.Size = new System.Drawing.Size(246, 75);
			this.fraPlayBGM.TabIndex = 21;
			this.fraPlayBGM.TabStop = false;
			this.fraPlayBGM.Text = "Play BGM";
			this.fraPlayBGM.Visible = false;
			//
			//btnPlayBgmOk
			//
			this.btnPlayBgmOk.Location = new System.Drawing.Point(46, 46);
			this.btnPlayBgmOk.Name = "btnPlayBgmOk";
			this.btnPlayBgmOk.Padding = new System.Windows.Forms.Padding(5);
			this.btnPlayBgmOk.Size = new System.Drawing.Size(75, 23);
			this.btnPlayBgmOk.TabIndex = 27;
			this.btnPlayBgmOk.Text = "Ok";
			//
			//btnPlayBgmCancel
			//
			this.btnPlayBgmCancel.Location = new System.Drawing.Point(127, 46);
			this.btnPlayBgmCancel.Name = "btnPlayBgmCancel";
			this.btnPlayBgmCancel.Padding = new System.Windows.Forms.Padding(5);
			this.btnPlayBgmCancel.Size = new System.Drawing.Size(75, 23);
			this.btnPlayBgmCancel.TabIndex = 26;
			this.btnPlayBgmCancel.Text = "Cancel";
			//
			//cmbPlayBGM
			//
			this.cmbPlayBGM.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbPlayBGM.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbPlayBGM.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbPlayBGM.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbPlayBGM.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbPlayBGM.ButtonIcon"));
			this.cmbPlayBGM.DrawDropdownHoverOutline = false;
			this.cmbPlayBGM.DrawFocusRectangle = false;
			this.cmbPlayBGM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
			this.cmbPlayBGM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbPlayBGM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbPlayBGM.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbPlayBGM.FormattingEnabled = true;
			this.cmbPlayBGM.Location = new System.Drawing.Point(6, 19);
			this.cmbPlayBGM.Name = "cmbPlayBGM";
			this.cmbPlayBGM.Size = new System.Drawing.Size(233, 21);
			this.cmbPlayBGM.TabIndex = 0;
			this.cmbPlayBGM.Text = null;
			this.cmbPlayBGM.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//pnlVariableSwitches
			//
			this.pnlVariableSwitches.Controls.Add(this.FraRenaming);
			this.pnlVariableSwitches.Controls.Add(this.fraLabeling);
			this.pnlVariableSwitches.Location = new System.Drawing.Point(800, 201);
			this.pnlVariableSwitches.Name = "pnlVariableSwitches";
			this.pnlVariableSwitches.Size = new System.Drawing.Size(93, 91);
			this.pnlVariableSwitches.TabIndex = 11;
			//
			//FraRenaming
			//
			this.FraRenaming.Controls.Add(this.btnRename_Cancel);
			this.FraRenaming.Controls.Add(this.btnRename_Ok);
			this.FraRenaming.Controls.Add(this.fraRandom10);
			this.FraRenaming.ForeColor = System.Drawing.Color.Gainsboro;
			this.FraRenaming.Location = new System.Drawing.Point(236, 429);
			this.FraRenaming.Name = "FraRenaming";
			this.FraRenaming.Size = new System.Drawing.Size(364, 143);
			this.FraRenaming.TabIndex = 8;
			this.FraRenaming.TabStop = false;
			this.FraRenaming.Text = "Renaming Variable/Switch";
			this.FraRenaming.Visible = false;
			//
			//btnRename_Cancel
			//
			this.btnRename_Cancel.ForeColor = System.Drawing.Color.Black;
			this.btnRename_Cancel.Location = new System.Drawing.Point(229, 102);
			this.btnRename_Cancel.Name = "btnRename_Cancel";
			this.btnRename_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btnRename_Cancel.TabIndex = 2;
			this.btnRename_Cancel.Text = "Cancel";
			this.btnRename_Cancel.UseVisualStyleBackColor = true;
			//
			//btnRename_Ok
			//
			this.btnRename_Ok.ForeColor = System.Drawing.Color.Black;
			this.btnRename_Ok.Location = new System.Drawing.Point(54, 102);
			this.btnRename_Ok.Name = "btnRename_Ok";
			this.btnRename_Ok.Size = new System.Drawing.Size(75, 23);
			this.btnRename_Ok.TabIndex = 1;
			this.btnRename_Ok.Text = "Ok";
			this.btnRename_Ok.UseVisualStyleBackColor = true;
			//
			//fraRandom10
			//
			this.fraRandom10.Controls.Add(this.txtRename);
			this.fraRandom10.Controls.Add(this.lblEditing);
			this.fraRandom10.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraRandom10.Location = new System.Drawing.Point(6, 19);
			this.fraRandom10.Name = "fraRandom10";
			this.fraRandom10.Size = new System.Drawing.Size(352, 77);
			this.fraRandom10.TabIndex = 0;
			this.fraRandom10.TabStop = false;
			this.fraRandom10.Text = "Editing Variable/Switch";
			//
			//txtRename
			//
			this.txtRename.Location = new System.Drawing.Point(6, 41);
			this.txtRename.Name = "txtRename";
			this.txtRename.Size = new System.Drawing.Size(340, 20);
			this.txtRename.TabIndex = 1;
			//
			//lblEditing
			//
			this.lblEditing.AutoSize = true;
			this.lblEditing.Location = new System.Drawing.Point(3, 25);
			this.lblEditing.Name = "lblEditing";
			this.lblEditing.Size = new System.Drawing.Size(100, 13);
			this.lblEditing.TabIndex = 0;
			this.lblEditing.Text = "Naming Variable #1";
			//
			//fraLabeling
			//
			this.fraLabeling.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.fraLabeling.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.fraLabeling.Controls.Add(this.lstSwitches);
			this.fraLabeling.Controls.Add(this.lstVariables);
			this.fraLabeling.Controls.Add(this.btnLabel_Cancel);
			this.fraLabeling.Controls.Add(this.lblRandomLabel36);
			this.fraLabeling.Controls.Add(this.btnRenameVariable);
			this.fraLabeling.Controls.Add(this.lblRandomLabel25);
			this.fraLabeling.Controls.Add(this.btnRenameSwitch);
			this.fraLabeling.Controls.Add(this.btnLabel_Ok);
			this.fraLabeling.ForeColor = System.Drawing.Color.Gainsboro;
			this.fraLabeling.Location = new System.Drawing.Point(195, 29);
			this.fraLabeling.Name = "fraLabeling";
			this.fraLabeling.Size = new System.Drawing.Size(456, 387);
			this.fraLabeling.TabIndex = 0;
			this.fraLabeling.TabStop = false;
			this.fraLabeling.Text = "Label Variables and  Switches   ";
			//
			//lstSwitches
			//
			this.lstSwitches.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.lstSwitches.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstSwitches.ForeColor = System.Drawing.Color.Gainsboro;
			this.lstSwitches.FormattingEnabled = true;
			this.lstSwitches.Location = new System.Drawing.Point(236, 39);
			this.lstSwitches.Name = "lstSwitches";
			this.lstSwitches.Size = new System.Drawing.Size(205, 288);
			this.lstSwitches.TabIndex = 7;
			//
			//lstVariables
			//
			this.lstVariables.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.lstVariables.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.lstVariables.ForeColor = System.Drawing.Color.Gainsboro;
			this.lstVariables.FormattingEnabled = true;
			this.lstVariables.Location = new System.Drawing.Point(14, 39);
			this.lstVariables.Name = "lstVariables";
			this.lstVariables.Size = new System.Drawing.Size(205, 288);
			this.lstVariables.TabIndex = 6;
			//
			//btnLabel_Cancel
			//
			this.btnLabel_Cancel.ForeColor = System.Drawing.Color.Black;
			this.btnLabel_Cancel.Location = new System.Drawing.Point(236, 341);
			this.btnLabel_Cancel.Name = "btnLabel_Cancel";
			this.btnLabel_Cancel.Size = new System.Drawing.Size(75, 23);
			this.btnLabel_Cancel.TabIndex = 12;
			this.btnLabel_Cancel.Text = "Cancel";
			this.btnLabel_Cancel.UseVisualStyleBackColor = true;
			//
			//lblRandomLabel36
			//
			this.lblRandomLabel36.AutoSize = true;
			this.lblRandomLabel36.Location = new System.Drawing.Point(293, 23);
			this.lblRandomLabel36.Name = "lblRandomLabel36";
			this.lblRandomLabel36.Size = new System.Drawing.Size(82, 13);
			this.lblRandomLabel36.TabIndex = 5;
			this.lblRandomLabel36.Text = "Player Switches";
			//
			//btnRenameVariable
			//
			this.btnRenameVariable.ForeColor = System.Drawing.Color.Black;
			this.btnRenameVariable.Location = new System.Drawing.Point(14, 341);
			this.btnRenameVariable.Name = "btnRenameVariable";
			this.btnRenameVariable.Size = new System.Drawing.Size(106, 23);
			this.btnRenameVariable.TabIndex = 9;
			this.btnRenameVariable.Text = "Rename Variable";
			this.btnRenameVariable.UseVisualStyleBackColor = true;
			//
			//lblRandomLabel25
			//
			this.lblRandomLabel25.AutoSize = true;
			this.lblRandomLabel25.Location = new System.Drawing.Point(80, 21);
			this.lblRandomLabel25.Name = "lblRandomLabel25";
			this.lblRandomLabel25.Size = new System.Drawing.Size(82, 13);
			this.lblRandomLabel25.TabIndex = 4;
			this.lblRandomLabel25.Text = "Player Variables";
			//
			//btnRenameSwitch
			//
			this.btnRenameSwitch.ForeColor = System.Drawing.Color.Black;
			this.btnRenameSwitch.Location = new System.Drawing.Point(332, 341);
			this.btnRenameSwitch.Name = "btnRenameSwitch";
			this.btnRenameSwitch.Size = new System.Drawing.Size(109, 23);
			this.btnRenameSwitch.TabIndex = 10;
			this.btnRenameSwitch.Text = "Rename Switch";
			this.btnRenameSwitch.UseVisualStyleBackColor = true;
			//
			//btnLabel_Ok
			//
			this.btnLabel_Ok.ForeColor = System.Drawing.Color.Black;
			this.btnLabel_Ok.Location = new System.Drawing.Point(144, 341);
			this.btnLabel_Ok.Name = "btnLabel_Ok";
			this.btnLabel_Ok.Size = new System.Drawing.Size(75, 23);
			this.btnLabel_Ok.TabIndex = 11;
			this.btnLabel_Ok.Text = "Ok";
			this.btnLabel_Ok.UseVisualStyleBackColor = true;
			//
			//optCondition9
			//
			this.optCondition9.AutoSize = true;
			this.optCondition9.Location = new System.Drawing.Point(6, 346);
			this.optCondition9.Name = "optCondition9";
			this.optCondition9.Size = new System.Drawing.Size(95, 17);
			this.optCondition9.TabIndex = 32;
			this.optCondition9.TabStop = true;
			this.optCondition9.Text = "Time of Day is:";
			//
			//cmbCondition_Time
			//
			this.cmbCondition_Time.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(69)), System.Convert.ToInt32(System.Convert.ToByte(73)), System.Convert.ToInt32(System.Convert.ToByte(74)));
			this.cmbCondition_Time.BorderColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)), System.Convert.ToInt32(System.Convert.ToByte(90)));
			this.cmbCondition_Time.BorderStyle = System.Windows.Forms.ButtonBorderStyle.Solid;
			this.cmbCondition_Time.ButtonColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)), System.Convert.ToInt32(System.Convert.ToByte(43)));
			this.cmbCondition_Time.ButtonIcon = (System.Drawing.Bitmap) (resources.GetObject("cmbCondition_Time.ButtonIcon"));
			this.cmbCondition_Time.DrawDropdownHoverOutline = false;
			this.cmbCondition_Time.DrawFocusRectangle = false;
			this.cmbCondition_Time.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.cmbCondition_Time.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbCondition_Time.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.cmbCondition_Time.ForeColor = System.Drawing.Color.Gainsboro;
			this.cmbCondition_Time.FormattingEnabled = true;
			this.cmbCondition_Time.Items.AddRange(new object[] {"Day", "Night", "Dawn", "Dusk"});
			this.cmbCondition_Time.Location = new System.Drawing.Point(239, 345);
			this.cmbCondition_Time.Name = "cmbCondition_Time";
			this.cmbCondition_Time.Size = new System.Drawing.Size(144, 21);
			this.cmbCondition_Time.TabIndex = 33;
			this.cmbCondition_Time.TextPadding = new System.Windows.Forms.Padding(2);
			//
			//FrmEditor_Events
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(45)), System.Convert.ToInt32(System.Convert.ToByte(48)));
			this.ClientSize = new System.Drawing.Size(1588, 614);
			this.ControlBox = false;
			this.Controls.Add(this.fraGraphic);
			this.Controls.Add(this.pnlVariableSwitches);
			this.Controls.Add(this.fraDialogue);
			this.Controls.Add(this.fraMoveRoute);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnLabeling);
			this.Controls.Add(this.DarkGroupBox6);
			this.Controls.Add(this.pnlTabPage);
			this.Controls.Add(this.tabPages);
			this.Controls.Add(this.fraPageSetUp);
			this.ForeColor = System.Drawing.Color.Gainsboro;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmEditor_Events";
			this.Text = "Event Editor";
			this.fraPageSetUp.ResumeLayout(false);
			this.fraPageSetUp.PerformLayout();
			this.tabPages.ResumeLayout(false);
			this.pnlTabPage.ResumeLayout(false);
			this.fraCommands.ResumeLayout(false);
			this.DarkGroupBox8.ResumeLayout(false);
			this.DarkGroupBox7.ResumeLayout(false);
			this.DarkGroupBox7.PerformLayout();
			this.DarkGroupBox5.ResumeLayout(false);
			this.DarkGroupBox4.ResumeLayout(false);
			this.DarkGroupBox3.ResumeLayout(false);
			this.DarkGroupBox3.PerformLayout();
			this.DarkGroupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.picGraphic).EndInit();
			this.DarkGroupBox1.ResumeLayout(false);
			this.DarkGroupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudPlayerVariable).EndInit();
			this.DarkGroupBox6.ResumeLayout(false);
			this.DarkGroupBox6.PerformLayout();
			this.fraMoveRoute.ResumeLayout(false);
			this.fraMoveRoute.PerformLayout();
			this.DarkGroupBox10.ResumeLayout(false);
			this.fraGraphic.ResumeLayout(false);
			this.fraGraphic.PerformLayout();
			this.pnlGraphicSel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.picGraphicSel).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudGraphic).EndInit();
			this.fraDialogue.ResumeLayout(false);
			this.fraPlayAnimation.ResumeLayout(false);
			this.fraPlayAnimation.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudPlayAnimTileY).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudPlayAnimTileX).EndInit();
			this.fraMoveRouteWait.ResumeLayout(false);
			this.fraMoveRouteWait.PerformLayout();
			this.fraCustomScript.ResumeLayout(false);
			this.fraCustomScript.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudCustomScript).EndInit();
			this.fraSetWeather.ResumeLayout(false);
			this.fraSetWeather.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudWeatherIntensity).EndInit();
			this.fraSpawnNpc.ResumeLayout(false);
			this.fraGiveExp.ResumeLayout(false);
			this.fraGiveExp.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudGiveExp).EndInit();
			this.fraEndQuest.ResumeLayout(false);
			this.fraSetAccess.ResumeLayout(false);
			this.fraSetWait.ResumeLayout(false);
			this.fraSetWait.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudWaitAmount).EndInit();
			this.fraShowPic.ResumeLayout(false);
			this.fraShowPic.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudPicOffsetY).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudPicOffsetX).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudShowPicture).EndInit();
			((System.ComponentModel.ISupportInitialize) this.picShowPic).EndInit();
			this.fraOpenShop.ResumeLayout(false);
			this.fraChangeLevel.ResumeLayout(false);
			this.fraChangeLevel.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudChangeLevel).EndInit();
			this.fraChangeGender.ResumeLayout(false);
			this.fraChangeGender.PerformLayout();
			this.fraGoToLabel.ResumeLayout(false);
			this.fraGoToLabel.PerformLayout();
			this.fraHidePic.ResumeLayout(false);
			this.fraHidePic.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudHidePic).EndInit();
			this.fraBeginQuest.ResumeLayout(false);
			this.fraBeginQuest.PerformLayout();
			this.fraShowChoices.ResumeLayout(false);
			this.fraShowChoices.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.picShowChoicesFace).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudShowChoicesFace).EndInit();
			this.fraPlayerVariable.ResumeLayout(false);
			this.fraPlayerVariable.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudVariableData2).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudVariableData4).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudVariableData3).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudVariableData1).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudVariableData0).EndInit();
			this.fraChangeSprite.ResumeLayout(false);
			this.fraChangeSprite.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudChangeSprite).EndInit();
			((System.ComponentModel.ISupportInitialize) this.picChangeSprite).EndInit();
			this.fraSetSelfSwitch.ResumeLayout(false);
			this.fraSetSelfSwitch.PerformLayout();
			this.fraMapTint.ResumeLayout(false);
			this.fraMapTint.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudMapTintData3).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudMapTintData2).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudMapTintData1).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudMapTintData0).EndInit();
			this.fraShowChatBubble.ResumeLayout(false);
			this.fraShowChatBubble.PerformLayout();
			this.fraPlaySound.ResumeLayout(false);
			this.fraChangePK.ResumeLayout(false);
			this.fraCreateLabel.ResumeLayout(false);
			this.fraCreateLabel.PerformLayout();
			this.fraChangeClass.ResumeLayout(false);
			this.fraChangeClass.PerformLayout();
			this.fraChangeSkills.ResumeLayout(false);
			this.fraChangeSkills.PerformLayout();
			this.fraCompleteTask.ResumeLayout(false);
			this.fraCompleteTask.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudCompleteQuestTask).EndInit();
			this.fraPlayerWarp.ResumeLayout(false);
			this.fraPlayerWarp.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudWPY).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudWPX).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudWPMap).EndInit();
			this.fraSetFog.ResumeLayout(false);
			this.fraSetFog.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudFogData2).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudFogData1).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudFogData0).EndInit();
			this.fraShowText.ResumeLayout(false);
			this.fraShowText.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.picShowTextFace).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudShowTextFace).EndInit();
			this.fraAddText.ResumeLayout(false);
			this.fraAddText.PerformLayout();
			this.fraPlayerSwitch.ResumeLayout(false);
			this.fraPlayerSwitch.PerformLayout();
			this.fraChangeItems.ResumeLayout(false);
			this.fraChangeItems.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudChangeItemsAmount).EndInit();
			this.fraConditionalBranch.ResumeLayout(false);
			this.fraConditionalBranch.PerformLayout();
			this.fraConditions_Quest.ResumeLayout(false);
			this.fraConditions_Quest.PerformLayout();
			((System.ComponentModel.ISupportInitialize) this.nudCondition_QuestTask).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudCondition_Quest).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudCondition_LevelAmount).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudCondition_HasItem).EndInit();
			((System.ComponentModel.ISupportInitialize) this.nudCondition_PlayerVarCondition).EndInit();
			this.fraPlayBGM.ResumeLayout(false);
			this.pnlVariableSwitches.ResumeLayout(false);
			this.FraRenaming.ResumeLayout(false);
			this.fraRandom10.ResumeLayout(false);
			this.fraRandom10.PerformLayout();
			this.fraLabeling.ResumeLayout(false);
			this.fraLabeling.PerformLayout();
			this.ResumeLayout(false);
			
		}
		
		internal TreeView tvCommands;
		internal DarkUI.Controls.DarkGroupBox fraPageSetUp;
		internal TabControl tabPages;
		internal TabPage TabPage1;
		internal DarkUI.Controls.DarkTextBox txtName;
		internal DarkUI.Controls.DarkLabel DarkLabel1;
		internal DarkUI.Controls.DarkButton btnNewPage;
		internal DarkUI.Controls.DarkButton btnCopyPage;
		internal DarkUI.Controls.DarkButton btnPastePage;
		internal DarkUI.Controls.DarkButton btnClearPage;
		internal DarkUI.Controls.DarkButton btnDeletePage;
		internal Panel pnlTabPage;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox1;
		internal DarkUI.Controls.DarkCheckBox chkPlayerVar;
		internal DarkUI.Controls.DarkComboBox cmbPlayerVar;
		internal DarkUI.Controls.DarkLabel DarkLabel2;
		internal DarkUI.Controls.DarkComboBox cmbPlayervarCompare;
		internal DarkUI.Controls.DarkNumericUpDown nudPlayerVariable;
		internal DarkUI.Controls.DarkCheckBox chkPlayerSwitch;
		internal DarkUI.Controls.DarkComboBox cmbPlayerSwitch;
		internal DarkUI.Controls.DarkComboBox cmbPlayerSwitchCompare;
		internal DarkUI.Controls.DarkLabel DarkLabel3;
		internal DarkUI.Controls.DarkComboBox cmbHasItem;
		internal DarkUI.Controls.DarkCheckBox chkHasItem;
		internal DarkUI.Controls.DarkComboBox cmbSelfSwitch;
		internal DarkUI.Controls.DarkCheckBox chkSelfSwitch;
		internal DarkUI.Controls.DarkComboBox cmbSelfSwitchCompare;
		internal DarkUI.Controls.DarkLabel DarkLabel4;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox2;
		internal PictureBox picGraphic;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox3;
		internal DarkUI.Controls.DarkCheckBox chkGlobal;
		internal DarkUI.Controls.DarkLabel DarkLabel5;
		internal DarkUI.Controls.DarkComboBox cmbMoveType;
		internal DarkUI.Controls.DarkButton btnMoveRoute;
		internal DarkUI.Controls.DarkLabel DarkLabel6;
		internal DarkUI.Controls.DarkComboBox cmbMoveSpeed;
		internal DarkUI.Controls.DarkComboBox cmbMoveFreq;
		internal DarkUI.Controls.DarkLabel DarkLabel7;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox4;
		internal DarkUI.Controls.DarkComboBox cmbPositioning;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox5;
		internal DarkUI.Controls.DarkComboBox cmbTrigger;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox6;
		internal DarkUI.Controls.DarkCheckBox chkWalkAnim;
		internal DarkUI.Controls.DarkCheckBox chkDirFix;
		internal DarkUI.Controls.DarkCheckBox chkWalkThrough;
		internal DarkUI.Controls.DarkCheckBox chkShowName;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox7;
		internal DarkUI.Controls.DarkComboBox cmbEventQuest;
		internal DarkUI.Controls.DarkLabel DarkLabel8;
		internal DarkUI.Controls.DarkLabel DarkLabel10;
		internal DarkUI.Controls.DarkLabel DarkLabel9;
		internal ListBox lstCommands;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox8;
		internal DarkUI.Controls.DarkButton btnAddCommand;
		internal DarkUI.Controls.DarkButton btnDeleteCommand;
		internal DarkUI.Controls.DarkButton btnEditCommand;
		internal DarkUI.Controls.DarkButton btnClearCommand;
		internal Panel fraCommands;
		internal DarkUI.Controls.DarkButton btnLabeling;
		internal DarkUI.Controls.DarkButton btnCancel;
		internal DarkUI.Controls.DarkButton btnOk;
		internal DarkUI.Controls.DarkButton btnCancelCommand;
		internal DarkUI.Controls.DarkGroupBox fraMoveRoute;
		internal DarkUI.Controls.DarkComboBox cmbEvent;
		internal ListBox lstMoveRoute;
		internal DarkUI.Controls.DarkGroupBox DarkGroupBox10;
		internal ListView lstvwMoveRoute;
		internal ColumnHeader ColumnHeader3;
		internal ColumnHeader ColumnHeader4;
		internal DarkUI.Controls.DarkCheckBox chkRepeatRoute;
		internal DarkUI.Controls.DarkCheckBox chkIgnoreMove;
		internal DarkUI.Controls.DarkButton btnMoveRouteOk;
		internal DarkUI.Controls.DarkButton btnMoveRouteCancel;
		internal DarkUI.Controls.DarkGroupBox fraGraphic;
		internal DarkUI.Controls.DarkLabel DarkLabel11;
		internal DarkUI.Controls.DarkComboBox cmbGraphic;
		internal DarkUI.Controls.DarkLabel DarkLabel12;
		internal DarkUI.Controls.DarkNumericUpDown nudGraphic;
		internal DarkUI.Controls.DarkLabel DarkLabel13;
		internal PictureBox picGraphicSel;
		internal DarkUI.Controls.DarkButton btnGraphicOk;
		internal DarkUI.Controls.DarkButton btnGraphicCancel;
		internal DarkUI.Controls.DarkGroupBox fraDialogue;
		internal DarkUI.Controls.DarkGroupBox fraConditionalBranch;
		internal DarkUI.Controls.DarkRadioButton optCondition0;
		internal DarkUI.Controls.DarkComboBox cmbCondition_PlayerVarIndex;
		internal DarkUI.Controls.DarkNumericUpDown nudCondition_PlayerVarCondition;
		internal DarkUI.Controls.DarkComboBox cmbCondition_PlayerVarCompare;
		internal DarkUI.Controls.DarkLabel DarkLabel14;
		internal DarkUI.Controls.DarkRadioButton optCondition1;
		internal DarkUI.Controls.DarkLabel DarkLabel15;
		internal DarkUI.Controls.DarkComboBox cmbCondtion_PlayerSwitchCondition;
		internal DarkUI.Controls.DarkComboBox cmbCondition_PlayerSwitch;
		internal DarkUI.Controls.DarkRadioButton optCondition2;
		internal DarkUI.Controls.DarkNumericUpDown nudCondition_HasItem;
		internal DarkUI.Controls.DarkLabel DarkLabel16;
		internal DarkUI.Controls.DarkComboBox cmbCondition_HasItem;
		internal DarkUI.Controls.DarkRadioButton optCondition3;
		internal DarkUI.Controls.DarkComboBox cmbCondition_ClassIs;
		internal DarkUI.Controls.DarkRadioButton optCondition4;
		internal DarkUI.Controls.DarkComboBox cmbCondition_LearntSkill;
		internal DarkUI.Controls.DarkRadioButton optCondition5;
		internal DarkUI.Controls.DarkComboBox cmbCondition_LevelCompare;
		internal DarkUI.Controls.DarkNumericUpDown nudCondition_LevelAmount;
		internal DarkUI.Controls.DarkRadioButton optCondition6;
		internal DarkUI.Controls.DarkComboBox cmbCondition_SelfSwitchCondition;
		internal DarkUI.Controls.DarkLabel DarkLabel17;
		internal DarkUI.Controls.DarkComboBox cmbCondition_SelfSwitch;
		internal DarkUI.Controls.DarkRadioButton optCondition7;
		internal DarkUI.Controls.DarkNumericUpDown nudCondition_Quest;
		internal DarkUI.Controls.DarkLabel DarkLabel18;
		internal DarkUI.Controls.DarkGroupBox fraConditions_Quest;
		internal DarkUI.Controls.DarkLabel DarkLabel19;
		internal DarkUI.Controls.DarkRadioButton optCondition_Quest1;
		internal DarkUI.Controls.DarkRadioButton optCondition_Quest0;
		internal DarkUI.Controls.DarkComboBox cmbCondition_General;
		internal DarkUI.Controls.DarkNumericUpDown nudCondition_QuestTask;
		internal DarkUI.Controls.DarkLabel DarkLabel20;
		internal DarkUI.Controls.DarkRadioButton optCondition8;
		internal DarkUI.Controls.DarkComboBox cmbCondition_Gender;
		internal DarkUI.Controls.DarkButton btnConditionalBranchOk;
		internal DarkUI.Controls.DarkButton btnConditionalBranchCancel;
		internal DarkUI.Controls.DarkGroupBox fraChangeItems;
		internal DarkUI.Controls.DarkGroupBox fraPlayerSwitch;
		internal DarkUI.Controls.DarkComboBox cmbChangeItemIndex;
		internal DarkUI.Controls.DarkLabel DarkLabel21;
		internal DarkUI.Controls.DarkRadioButton optChangeItemSet;
		internal DarkUI.Controls.DarkRadioButton optChangeItemRemove;
		internal DarkUI.Controls.DarkRadioButton optChangeItemAdd;
		internal DarkUI.Controls.DarkNumericUpDown nudChangeItemsAmount;
		internal DarkUI.Controls.DarkButton btnChangeItemsOk;
		internal DarkUI.Controls.DarkButton btnChangeItemsCancel;
		internal DarkUI.Controls.DarkComboBox cmbSwitch;
		internal DarkUI.Controls.DarkLabel DarkLabel22;
		internal DarkUI.Controls.DarkLabel DarkLabel23;
		internal DarkUI.Controls.DarkComboBox cmbPlayerSwitchSet;
		internal DarkUI.Controls.DarkButton btnSetPlayerSwitchOk;
		internal DarkUI.Controls.DarkButton btnSetPlayerswitchCancel;
		internal DarkUI.Controls.DarkGroupBox fraAddText;
		internal DarkUI.Controls.DarkTextBox txtAddText_Text;
		internal DarkUI.Controls.DarkLabel DarkLabel24;
		internal DarkUI.Controls.DarkRadioButton optAddText_Player;
		internal DarkUI.Controls.DarkLabel DarkLabel25;
		internal DarkUI.Controls.DarkRadioButton optAddText_Map;
		internal DarkUI.Controls.DarkButton btnAddTextOk;
		internal DarkUI.Controls.DarkButton btnAddTextCancel;
		internal DarkUI.Controls.DarkRadioButton optAddText_Global;
		internal DarkUI.Controls.DarkButton btnShowTextOk;
		internal DarkUI.Controls.DarkButton btnShowTextCancel;
		internal DarkUI.Controls.DarkNumericUpDown nudShowTextFace;
		internal DarkUI.Controls.DarkLabel DarkLabel26;
		internal DarkUI.Controls.DarkTextBox txtShowText;
		internal PictureBox picShowTextFace;
		internal DarkUI.Controls.DarkLabel DarkLabel27;
		internal DarkUI.Controls.DarkGroupBox fraShowText;
		internal DarkUI.Controls.DarkGroupBox fraSetFog;
		internal DarkUI.Controls.DarkButton btnSetFogOk;
		internal DarkUI.Controls.DarkButton btnSetFogCancel;
		internal DarkUI.Controls.DarkLabel DarkLabel30;
		internal DarkUI.Controls.DarkLabel DarkLabel29;
		internal DarkUI.Controls.DarkLabel DarkLabel28;
		internal DarkUI.Controls.DarkNumericUpDown nudFogData2;
		internal DarkUI.Controls.DarkNumericUpDown nudFogData1;
		internal DarkUI.Controls.DarkNumericUpDown nudFogData0;
		internal DarkUI.Controls.DarkGroupBox fraPlayerWarp;
		internal DarkUI.Controls.DarkButton btnPlayerWarpOk;
		internal DarkUI.Controls.DarkButton btnPlayerWarpCancel;
		internal DarkUI.Controls.DarkLabel DarkLabel31;
		internal DarkUI.Controls.DarkComboBox cmbWarpPlayerDir;
		internal DarkUI.Controls.DarkNumericUpDown nudWPY;
		internal DarkUI.Controls.DarkLabel DarkLabel32;
		internal DarkUI.Controls.DarkNumericUpDown nudWPX;
		internal DarkUI.Controls.DarkLabel DarkLabel33;
		internal DarkUI.Controls.DarkNumericUpDown nudWPMap;
		internal DarkUI.Controls.DarkLabel DarkLabel34;
		internal DarkUI.Controls.DarkGroupBox fraCompleteTask;
		internal DarkUI.Controls.DarkButton btnCompleteQuestTaskOk;
		internal DarkUI.Controls.DarkButton btnCompleteQuestTaskCancel;
		internal DarkUI.Controls.DarkLabel DarkLabel35;
		internal DarkUI.Controls.DarkLabel DarkLabel36;
		internal DarkUI.Controls.DarkNumericUpDown nudCompleteQuestTask;
		internal DarkUI.Controls.DarkComboBox cmbCompleteQuest;
		internal DarkUI.Controls.DarkGroupBox fraPlayBGM;
		internal DarkUI.Controls.DarkComboBox cmbPlayBGM;
		internal DarkUI.Controls.DarkButton btnPlayBgmOk;
		internal DarkUI.Controls.DarkButton btnPlayBgmCancel;
		internal DarkUI.Controls.DarkGroupBox fraChangeSkills;
		internal DarkUI.Controls.DarkComboBox cmbChangeSkills;
		internal DarkUI.Controls.DarkLabel DarkLabel37;
		internal DarkUI.Controls.DarkRadioButton optChangeSkillsAdd;
		internal DarkUI.Controls.DarkButton btnChangeSkillsOk;
		internal DarkUI.Controls.DarkButton btnChangeSkillsCancel;
		internal DarkUI.Controls.DarkRadioButton optChangeSkillsRemove;
		internal DarkUI.Controls.DarkGroupBox fraChangeClass;
		internal DarkUI.Controls.DarkComboBox cmbChangeClass;
		internal DarkUI.Controls.DarkLabel DarkLabel38;
		internal DarkUI.Controls.DarkButton btnChangeClassOk;
		internal DarkUI.Controls.DarkButton btnChangeClassCancel;
		internal DarkUI.Controls.DarkGroupBox fraCreateLabel;
		internal DarkUI.Controls.DarkLabel lblLabelName;
		internal DarkUI.Controls.DarkTextBox txtLabelName;
		internal DarkUI.Controls.DarkButton btnCreatelabelOk;
		internal DarkUI.Controls.DarkButton btnCreatelabelCancel;
		internal DarkUI.Controls.DarkGroupBox fraChangePK;
		internal DarkUI.Controls.DarkButton btnChangePkOk;
		internal DarkUI.Controls.DarkButton btnChangePkCancel;
		internal DarkUI.Controls.DarkComboBox cmbSetPK;
		internal DarkUI.Controls.DarkGroupBox fraPlaySound;
		internal DarkUI.Controls.DarkButton btnPlaySoundOk;
		internal DarkUI.Controls.DarkButton btnPlaySoundCancel;
		internal DarkUI.Controls.DarkComboBox cmbPlaySound;
		internal DarkUI.Controls.DarkGroupBox fraShowChatBubble;
		internal DarkUI.Controls.DarkLabel DarkLabel39;
		internal DarkUI.Controls.DarkTextBox txtChatbubbleText;
		internal DarkUI.Controls.DarkLabel DarkLabel40;
		internal DarkUI.Controls.DarkComboBox cmbChatBubbleTarget;
		internal DarkUI.Controls.DarkComboBox cmbChatBubbleTargetType;
		internal DarkUI.Controls.DarkButton btnShowChatBubbleOk;
		internal DarkUI.Controls.DarkButton btnShowChatBubbleCancel;
		internal DarkUI.Controls.DarkLabel DarkLabel41;
		internal DarkUI.Controls.DarkGroupBox fraMapTint;
		internal DarkUI.Controls.DarkButton btnMapTintOk;
		internal DarkUI.Controls.DarkButton btnMapTintCancel;
		internal DarkUI.Controls.DarkLabel DarkLabel42;
		internal DarkUI.Controls.DarkNumericUpDown nudMapTintData3;
		internal DarkUI.Controls.DarkNumericUpDown nudMapTintData2;
		internal DarkUI.Controls.DarkLabel DarkLabel43;
		internal DarkUI.Controls.DarkLabel DarkLabel44;
		internal DarkUI.Controls.DarkNumericUpDown nudMapTintData1;
		internal DarkUI.Controls.DarkNumericUpDown nudMapTintData0;
		internal DarkUI.Controls.DarkLabel DarkLabel45;
		internal DarkUI.Controls.DarkGroupBox fraSetSelfSwitch;
		internal DarkUI.Controls.DarkComboBox cmbSetSelfSwitch;
		internal DarkUI.Controls.DarkLabel DarkLabel46;
		internal DarkUI.Controls.DarkButton btnSelfswitchOk;
		internal DarkUI.Controls.DarkButton btnSelfswitchCancel;
		internal DarkUI.Controls.DarkLabel DarkLabel47;
		internal DarkUI.Controls.DarkComboBox cmbSetSelfSwitchTo;
		internal DarkUI.Controls.DarkGroupBox fraChangeSprite;
		internal PictureBox picChangeSprite;
		internal DarkUI.Controls.DarkButton btnChangeSpriteOk;
		internal DarkUI.Controls.DarkButton btnChangeSpriteCancel;
		internal DarkUI.Controls.DarkLabel DarkLabel48;
		internal DarkUI.Controls.DarkNumericUpDown nudChangeSprite;
		internal DarkUI.Controls.DarkGroupBox fraPlayerVariable;
		internal DarkUI.Controls.DarkComboBox cmbVariable;
		internal DarkUI.Controls.DarkLabel DarkLabel49;
		internal DarkUI.Controls.DarkRadioButton optVariableAction0;
		internal DarkUI.Controls.DarkRadioButton optVariableAction1;
		internal DarkUI.Controls.DarkNumericUpDown nudVariableData1;
		internal DarkUI.Controls.DarkNumericUpDown nudVariableData0;
		internal DarkUI.Controls.DarkRadioButton optVariableAction3;
		internal DarkUI.Controls.DarkNumericUpDown nudVariableData3;
		internal DarkUI.Controls.DarkRadioButton optVariableAction2;
		internal DarkUI.Controls.DarkButton btnPlayerVarOk;
		internal DarkUI.Controls.DarkButton btnPlayerVarCancel;
		internal DarkUI.Controls.DarkLabel DarkLabel51;
		internal DarkUI.Controls.DarkLabel DarkLabel50;
		internal DarkUI.Controls.DarkNumericUpDown nudVariableData4;
		internal DarkUI.Controls.DarkNumericUpDown nudVariableData2;
		internal DarkUI.Controls.DarkGroupBox fraShowChoices;
		internal DarkUI.Controls.DarkLabel DarkLabel52;
		internal DarkUI.Controls.DarkTextBox txtChoicePrompt;
		internal DarkUI.Controls.DarkButton btnShowChoicesOk;
		internal PictureBox picShowChoicesFace;
		internal DarkUI.Controls.DarkButton btnShowChoicesCancel;
		internal DarkUI.Controls.DarkLabel DarkLabel53;
		internal DarkUI.Controls.DarkNumericUpDown nudShowChoicesFace;
		internal DarkUI.Controls.DarkLabel DarkLabel56;
		internal DarkUI.Controls.DarkLabel DarkLabel57;
		internal DarkUI.Controls.DarkLabel DarkLabel55;
		internal DarkUI.Controls.DarkLabel DarkLabel54;
		internal DarkUI.Controls.DarkTextBox txtChoices4;
		internal DarkUI.Controls.DarkTextBox txtChoices3;
		internal DarkUI.Controls.DarkTextBox txtChoices2;
		internal DarkUI.Controls.DarkTextBox txtChoices1;
		internal DarkUI.Controls.DarkGroupBox fraBeginQuest;
		internal DarkUI.Controls.DarkComboBox cmbBeginQuest;
		internal DarkUI.Controls.DarkLabel DarkLabel58;
		internal DarkUI.Controls.DarkButton btnBeginQuestOk;
		internal DarkUI.Controls.DarkButton btnBeginQuestCancel;
		internal DarkUI.Controls.DarkGroupBox fraHidePic;
		internal DarkUI.Controls.DarkNumericUpDown nudHidePic;
		internal DarkUI.Controls.DarkLabel DarkLabel59;
		internal DarkUI.Controls.DarkButton btnHidePicOk;
		internal DarkUI.Controls.DarkButton btnHidePicCancel;
		internal DarkUI.Controls.DarkGroupBox fraGoToLabel;
		internal DarkUI.Controls.DarkTextBox txtGotoLabel;
		internal DarkUI.Controls.DarkLabel DarkLabel60;
		internal DarkUI.Controls.DarkButton btnGoToLabelOk;
		internal DarkUI.Controls.DarkButton btnGoToLabelCancel;
		internal DarkUI.Controls.DarkGroupBox fraPlayAnimation;
		internal DarkUI.Controls.DarkLabel DarkLabel61;
		internal DarkUI.Controls.DarkComboBox cmbPlayAnim;
		internal DarkUI.Controls.DarkLabel DarkLabel62;
		internal DarkUI.Controls.DarkComboBox cmbAnimTargetType;
		internal DarkUI.Controls.DarkNumericUpDown nudPlayAnimTileY;
		internal DarkUI.Controls.DarkNumericUpDown nudPlayAnimTileX;
		internal DarkUI.Controls.DarkComboBox cmbPlayAnimEvent;
		internal DarkUI.Controls.DarkButton btnPlayAnimationOk;
		internal DarkUI.Controls.DarkButton btnPlayAnimationCancel;
		internal DarkUI.Controls.DarkLabel lblPlayAnimY;
		internal DarkUI.Controls.DarkLabel lblPlayAnimX;
		internal DarkUI.Controls.DarkGroupBox fraChangeGender;
		internal DarkUI.Controls.DarkButton btnChangeGenderOk;
		internal DarkUI.Controls.DarkButton btnChangeGenderCancel;
		internal DarkUI.Controls.DarkRadioButton optChangeSexFemale;
		internal DarkUI.Controls.DarkRadioButton optChangeSexMale;
		internal DarkUI.Controls.DarkGroupBox fraChangeLevel;
		internal DarkUI.Controls.DarkButton btnChangeLevelOk;
		internal DarkUI.Controls.DarkButton btnChangeLevelCancel;
		internal DarkUI.Controls.DarkLabel DarkLabel65;
		internal DarkUI.Controls.DarkNumericUpDown nudChangeLevel;
		internal DarkUI.Controls.DarkGroupBox fraOpenShop;
		internal DarkUI.Controls.DarkComboBox cmbOpenShop;
		internal DarkUI.Controls.DarkButton btnOpenShopOk;
		internal DarkUI.Controls.DarkButton btnOpenShopCancel;
		internal DarkUI.Controls.DarkGroupBox fraShowPic;
		internal DarkUI.Controls.DarkComboBox cmbPicIndex;
		internal DarkUI.Controls.DarkLabel DarkLabel66;
		internal DarkUI.Controls.DarkLabel DarkLabel67;
		internal DarkUI.Controls.DarkLabel DarkLabel68;
		internal DarkUI.Controls.DarkNumericUpDown nudPicOffsetY;
		internal DarkUI.Controls.DarkNumericUpDown nudPicOffsetX;
		internal DarkUI.Controls.DarkLabel DarkLabel69;
		internal DarkUI.Controls.DarkComboBox cmbPicLoc;
		internal DarkUI.Controls.DarkNumericUpDown nudShowPicture;
		internal PictureBox picShowPic;
		internal DarkUI.Controls.DarkButton btnShowPicOk;
		internal DarkUI.Controls.DarkButton btnShowPicCancel;
		internal DarkUI.Controls.DarkLabel DarkLabel71;
		internal DarkUI.Controls.DarkLabel DarkLabel70;
		internal DarkUI.Controls.DarkGroupBox fraSetWait;
		internal DarkUI.Controls.DarkButton btnSetWaitOk;
		internal DarkUI.Controls.DarkButton btnSetWaitCancel;
		internal DarkUI.Controls.DarkLabel DarkLabel74;
		internal DarkUI.Controls.DarkLabel DarkLabel72;
		internal DarkUI.Controls.DarkLabel DarkLabel73;
		internal DarkUI.Controls.DarkNumericUpDown nudWaitAmount;
		internal DarkUI.Controls.DarkGroupBox fraSetAccess;
		internal DarkUI.Controls.DarkButton btnSetAccessOk;
		internal DarkUI.Controls.DarkButton btnSetAccessCancel;
		internal DarkUI.Controls.DarkComboBox cmbSetAccess;
		internal DarkUI.Controls.DarkGroupBox fraEndQuest;
		internal DarkUI.Controls.DarkButton btnEndQuestOk;
		internal DarkUI.Controls.DarkButton btnEndQuestCancel;
		internal DarkUI.Controls.DarkComboBox cmbEndQuest;
		internal DarkUI.Controls.DarkGroupBox fraSetWeather;
		internal DarkUI.Controls.DarkLabel DarkLabel75;
		internal DarkUI.Controls.DarkComboBox CmbWeather;
		internal DarkUI.Controls.DarkButton btnSetWeatherOk;
		internal DarkUI.Controls.DarkButton btnSetWeatherCancel;
		internal DarkUI.Controls.DarkLabel DarkLabel76;
		internal DarkUI.Controls.DarkNumericUpDown nudWeatherIntensity;
		internal DarkUI.Controls.DarkGroupBox fraGiveExp;
		internal DarkUI.Controls.DarkLabel DarkLabel77;
		internal DarkUI.Controls.DarkGroupBox fraSpawnNpc;
		internal DarkUI.Controls.DarkComboBox cmbSpawnNpc;
		internal DarkUI.Controls.DarkButton btnGiveExpOk;
		internal DarkUI.Controls.DarkButton btnGiveExpCancel;
		internal DarkUI.Controls.DarkNumericUpDown nudGiveExp;
		internal DarkUI.Controls.DarkButton btnSpawnNpcOk;
		internal DarkUI.Controls.DarkButton btnSpawnNpcCancel;
		internal DarkUI.Controls.DarkGroupBox fraCustomScript;
		internal DarkUI.Controls.DarkNumericUpDown nudCustomScript;
		internal DarkUI.Controls.DarkLabel DarkLabel78;
		internal DarkUI.Controls.DarkButton btnCustomScriptCancel;
		internal DarkUI.Controls.DarkButton btnCustomScriptOk;
		internal DarkUI.Controls.DarkGroupBox fraMoveRouteWait;
		internal DarkUI.Controls.DarkButton btnMoveWaitCancel;
		internal DarkUI.Controls.DarkButton btnMoveWaitOk;
		internal DarkUI.Controls.DarkLabel DarkLabel79;
		internal DarkUI.Controls.DarkComboBox cmbMoveWait;
		internal Panel pnlVariableSwitches;
		internal DarkUI.Controls.DarkGroupBox fraLabeling;
		internal ListBox lstSwitches;
		internal ListBox lstVariables;
		internal Label lblRandomLabel36;
		internal Label lblRandomLabel25;
		internal GroupBox FraRenaming;
		internal Button btnRename_Cancel;
		internal Button btnRename_Ok;
		internal GroupBox fraRandom10;
		internal TextBox txtRename;
		internal Label lblEditing;
		internal Button btnLabel_Cancel;
		internal Button btnRenameVariable;
		internal Button btnRenameSwitch;
		internal Button btnLabel_Ok;
		internal Panel pnlGraphicSel;
		internal DarkUI.Controls.DarkComboBox cmbCondition_Time;
		internal DarkUI.Controls.DarkRadioButton optCondition9;
	}
	
}
