
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using Microsoft.VisualBasic.CompilerServices;
using Engine;

namespace Engine
{
	partial class FrmQuest
	{
		public FrmQuest()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmQuest defaultInstance;
		
		public static FrmQuest Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmQuest();
					defaultInstance.FormClosed += new System.Windows.Forms.FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
			set
			{
				defaultInstance = value;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			defaultInstance = null;
		}
		
#endregion
		int SelectedTask;
		
		public void FrmEditor_Quest_Load(object sender, EventArgs e)
		{
			Width = 740;
			
			fraRequirements.Location = fraQuestList.Location;
			fraRequirements.Visible = false;
			fraTasks.Location = fraQuestList.Location;
			fraTasks.Visible = false;
			
			nudAmount.Maximum = 999999;
			
			nudGiveAmount.Maximum = byte.MaxValue;
			nudTakeAmount.Maximum = byte.MaxValue;
			nudItemRewValue.Maximum = 999999;
            E_Quest.QuestEditorInit();

        }
		
		public void LstIndex_Click(object sender, EventArgs e)
		{
			E_Quest.QuestEditorInit();
		}
		
		public void TxtName_TextChanged(object sender, EventArgs e)
		{
			int tmpindex = 0;
			
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
			{
				return;
			}
			
			tmpindex = lstIndex.SelectedIndex;
			E_Quest.Quest[E_Globals.Editorindex].Name = txtName.Text.Trim();
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + E_Quest.Quest[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
		}
		
		public void BtnSave_Click(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
			{
				return;
			}
			
			if (txtName.Text.Trim().Length == 0)
			{
				MessageBox.Show("Name required.");
			}
			else
			{
				E_Quest.QuestEditorOk();
			}
		}
		
		public void BtnCancel_Click(object sender, EventArgs e)
		{
			E_Quest.QuestEditorCancel();
		}
		
		public void TxtStartText_TextChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
			{
				return;
			}
			
			E_Quest.Quest[E_Globals.Editorindex].Chat[1] = txtStartText.Text.Trim();
		}
		
		public void TxtProgressText_TextChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
			{
				return;
			}
			
			E_Quest.Quest[E_Globals.Editorindex].Chat[2] = txtProgressText.Text.Trim();
		}
		
		public void TxtEndText_TextChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
			{
				return;
			}
			
			E_Quest.Quest[E_Globals.Editorindex].Chat[3] = txtEndText.Text.Trim();
		}
		
		public void CmbStartItem_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
			{
				return;
			}
			
			E_Quest.Quest[E_Globals.Editorindex].QuestGiveItem = cmbStartItem.SelectedIndex;
		}
		
		public void CmbEndItem_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
			{
				return;
			}
			
			E_Quest.Quest[E_Globals.Editorindex].QuestRemoveItem = cmbEndItem.SelectedIndex;
		}
		
		public void NudGiveAmount_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
			{
				return;
			}
			
			E_Quest.Quest[E_Globals.Editorindex].QuestGiveItemValue = cmbEndItem.SelectedIndex;
		}
		
		public void NudTakeAmount_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
			{
				return;
			}
			
			E_Quest.Quest[E_Globals.Editorindex].QuestRemoveItemValue = (int) nudTakeAmount.Value;
		}
		
		public void ChkRepeat_CheckedChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
			{
				return;
			}
			
			if (chkRepeat.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Repeat = (byte) 1;
			}
			else
			{
				E_Quest.Quest[E_Globals.Editorindex].Repeat = (byte) 0;
			}
		}
		
		public void ChkQuestCancel_CheckedChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
			{
				return;
			}
			
			if (chkQuestCancel.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Cancelable = (byte) 1;
			}
			else
			{
				E_Quest.Quest[E_Globals.Editorindex].Cancelable = (byte) 0;
			}
		}
		
#region Rewards
		
		public void NudExpReward_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
			{
				return;
			}
			
			E_Quest.Quest[E_Globals.Editorindex].RewardExp = (int) nudExpReward.Value;
		}
		
		public void BtnAddReward_Click(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
			{
				return;
			}
			
			if (cmbItemReward.SelectedIndex < 0)
			{
				return;
			}
			
			E_Quest.Quest[E_Globals.Editorindex].RewardCount = E_Quest.Quest[E_Globals.Editorindex].RewardCount + 1;
			
			Array.Resize(ref E_Quest.Quest[E_Globals.Editorindex].RewardItem, E_Quest.Quest[E_Globals.Editorindex].RewardCount + 1);
			Array.Resize(ref E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount, E_Quest.Quest[E_Globals.Editorindex].RewardCount + 1);
			
			E_Quest.Quest[E_Globals.Editorindex].RewardItem[E_Quest.Quest[E_Globals.Editorindex].RewardCount] = cmbItemReward.SelectedIndex;
			E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount[E_Quest.Quest[E_Globals.Editorindex].RewardCount] = (int)nudItemRewValue.Value;
			
			lstRewards.Items.Clear();
			for (var i = 1; i <= E_Quest.Quest[E_Globals.Editorindex].RewardCount; i++)
			{
                if (Types.Item[E_Quest.Quest[E_Globals.Editorindex].RewardItem[(int)i]].Name != null && E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount[(int)i] != null)
                {
                    lstRewards.Items.Add(i + ":" + E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount[(int)i] + " X " + Types.Item[E_Quest.Quest[E_Globals.Editorindex].RewardItem[(int)i]].Name.Trim());
                }
                else
                {
                    lstRewards.Items.Add(i + ":" + "Null" + " X " + "Null");
                }
            }
		}
		
		public void BtnRemoveReward_Click(object sender, EventArgs e)
		{
			int[] tmpRewardItem;
			int[] tmpRewardItemIndex;
			
			if (lstRewards.SelectedIndex < 0)
			{
				return;
			}
			if (E_Quest.Quest[E_Globals.Editorindex].RewardCount <= 0)
			{
				return;
			}
			
			tmpRewardItem = new int[E_Quest.Quest[E_Globals.Editorindex].RewardCount];
			tmpRewardItemIndex = new int[E_Quest.Quest[E_Globals.Editorindex].RewardCount];
			
			for (var i = 1; i <= E_Quest.Quest[E_Globals.Editorindex].RewardCount; i++)
			{
				if (!(i == lstRewards.SelectedIndex + 1))
				{
					tmpRewardItem[(int) i] = System.Convert.ToInt32(E_Quest.Quest[E_Globals.Editorindex].RewardItem[(int) i]);
					tmpRewardItemIndex[(int) i] = System.Convert.ToInt32(E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount[(int) i]);
				}
			}
			
			E_Quest.Quest[E_Globals.Editorindex].RewardCount = E_Quest.Quest[E_Globals.Editorindex].RewardCount - 1;
			
			E_Quest.Quest[E_Globals.Editorindex].RewardItem = new int[E_Quest.Quest[E_Globals.Editorindex].RewardCount + 1];
			E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount = new int[E_Quest.Quest[E_Globals.Editorindex].RewardCount + 1];
			
			for (var i = 1; i <= E_Quest.Quest[E_Globals.Editorindex].RewardCount; i++)
			{
				E_Quest.Quest[E_Globals.Editorindex].RewardItem[(int) i] = tmpRewardItem[(int) i];
				E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount[(int) i] = tmpRewardItemIndex[(int) i];
			}
			
			lstRewards.Items.Clear();
			for (var i = 1; i <= E_Quest.Quest[E_Globals.Editorindex].RewardCount; i++)
			{
				lstRewards.Items.Add(i + ":" + E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount[(int) i] + " X " + Types.Item[E_Quest.Quest[E_Globals.Editorindex].RewardItem[(int) i]].Name.Trim());
			}
			
		}
		
#endregion
		
#region Tasks
		
		public void LstTasks_DoubleClick(object sender, EventArgs e)
		{
			if (lstTasks.SelectedIndex < 0)
			{
				return;
			}
			
			SelectedTask = lstTasks.SelectedIndex + 1;
			E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
			fraTasks.Visible = true;
			fraTasks.BringToFront();
		}
		
		public void BtnAddTask_Click(object sender, EventArgs e)
		{
			E_Quest.Quest[E_Globals.Editorindex].TaskCount = E_Quest.Quest[E_Globals.Editorindex].TaskCount + 1;
			
			Array.Resize(ref E_Quest.Quest[E_Globals.Editorindex].Task, E_Quest.Quest[E_Globals.Editorindex].TaskCount + 1);
			
			SelectedTask = E_Quest.Quest[E_Globals.Editorindex].TaskCount;
			
			E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
			
			fraTasks.Visible = true;
			fraTasks.BringToFront();
		}
		
		public void BtnRemoveTask_Click(object sender, EventArgs e)
		{
			int i = 0;
			E_Quest.TaskRec[] tmptask;
			
			if (lstTasks.SelectedIndex < 0)
			{
				return;
			}
			if (E_Quest.Quest[E_Globals.Editorindex].TaskCount <= 0)
			{
				return;
			}
			
			tmptask = new E_Quest.TaskRec[E_Quest.Quest[E_Globals.Editorindex].TaskCount];
			
			for (i = 1; i <= E_Quest.Quest[E_Globals.Editorindex].TaskCount; i++)
			{
				if (!(i == lstTasks.SelectedIndex + 1))
				{
					tmptask[i] = E_Quest.Quest[E_Globals.Editorindex].Task[i];
				}
			}
			
			E_Quest.Quest[E_Globals.Editorindex].TaskCount = E_Quest.Quest[E_Globals.Editorindex].TaskCount - 1;
			
			E_Quest.Quest[E_Globals.Editorindex].Task = new E_Quest.TaskRec[E_Quest.Quest[E_Globals.Editorindex].TaskCount + 1];
			
			for (i = 1; i <= E_Quest.Quest[E_Globals.Editorindex].TaskCount; i++)
			{
				if (!(i == lstTasks.SelectedIndex + 1))
				{
					E_Quest.Quest[E_Globals.Editorindex].Task[i] = tmptask[i];
				}
			}
			
			lstTasks.Items.Clear();
			for (i = 1; i <= E_Quest.Quest[E_Globals.Editorindex].TaskCount; i++)
			{
                if (E_Quest.Quest[E_Globals.Editorindex].Task[i].TaskLog != null)
                {
                    lstTasks.Items.Add(i + ":" + E_Quest.Quest[E_Globals.Editorindex].Task[i].TaskLog);
                }
                else
                {
                    lstTasks.Items.Add(i + ":" + "Null");
                }
				
			}
			
		}
		
		public void BtnSaveTask_Click(object sender, EventArgs e)
		{
			
			if (lstTasks.SelectedIndex < 0)
			{
				SelectedTask = E_Quest.Quest[E_Globals.Editorindex].TaskCount;
			}
			else
			{
				SelectedTask = lstTasks.SelectedIndex + 1;
			}
			
			E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskLog = txtTaskLog.Text.Trim();
			E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Speech = txtTaskSpeech.Text;
			
			if (chkEnd.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].QuestEnd = (byte) 1;
			}
			else
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].QuestEnd = (byte) 0;
			}
			
			E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Npc = cmbNpc.SelectedIndex;
			E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Item = cmbItem.SelectedIndex;
			E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Map = cmbMap.SelectedIndex;
			E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Resource = cmbResource.SelectedIndex;
			E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Amount = (int) nudAmount.Value;
			
			if (optTask0.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 0;
			}
			else if (optTask1.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 1;
			}
			else if (optTask2.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 2;
			}
			else if (optTask3.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 3;
			}
			else if (optTask4.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 4;
			}
			else if (optTask5.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 5;
			}
			else if (optTask6.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 6;
			}
			else if (optTask7.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 7;
			}
			
			lstTasks.Items.Clear();
			for (var i = 1; i <= E_Quest.Quest[E_Globals.Editorindex].TaskCount; i++)
			{
                if (E_Quest.Quest[E_Globals.Editorindex].Task[i].TaskLog != null)
                {
                    lstTasks.Items.Add(i + ":" + E_Quest.Quest[E_Globals.Editorindex].Task[(int)i].TaskLog);
                }
                else
                {
                    lstTasks.Items.Add(i + ":" + "Null");
                }
			}
			
			fraTasks.Visible = false;
		}
		
		public void BtnCancelTask_Click(object sender, EventArgs e)
		{
			E_Quest.Quest[E_Globals.Editorindex].TaskCount = E_Quest.Quest[E_Globals.Editorindex].TaskCount - 1;
			
			E_Quest.Quest[E_Globals.Editorindex].Task = new E_Quest.TaskRec[E_Quest.Quest[E_Globals.Editorindex].TaskCount + 1];
			
			SelectedTask = E_Quest.Quest[E_Globals.Editorindex].TaskCount;
			fraTasks.Visible = false;
		}
		
		public void OptTask0_CheckedChanged(object sender, EventArgs e)
		{
			if (optTask0.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 0;
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = 0;
				E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
			}
		}
		
		public void OptTask1_CheckedChanged(object sender, EventArgs e)
		{
			if (optTask1.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 1;
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = E_Quest.QUEST_TYPE_GOSLAY;
				E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
				cmbNpc.Enabled = true;
			}
			else
			{
				cmbNpc.Enabled = false;
			}
		}
		
		public void OptTask2_CheckedChanged(object sender, EventArgs e)
		{
			if (optTask2.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 2;
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = E_Quest.QUEST_TYPE_GOGATHER;
				E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
				cmbItem.Enabled = true;
			}
			else
			{
				cmbItem.Enabled = false;
			}
		}
		
		public void OptTask3_CheckedChanged(object sender, EventArgs e)
		{
			if (optTask3.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 3;
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = E_Quest.QUEST_TYPE_GOTALK;
				E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
				cmbNpc.Enabled = true;
			}
			else
			{
				cmbNpc.Enabled = false;
			}
		}
		
		public void OptTask4_CheckedChanged(object sender, EventArgs e)
		{
			if (optTask4.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 4;
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = E_Quest.QUEST_TYPE_GOREACH;
				E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
				cmbMap.Enabled = true;
			}
			else
			{
				cmbMap.Enabled = false;
			}
		}
		
		public void OptTask5_CheckedChanged(object sender, EventArgs e)
		{
			if (optTask5.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 5;
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = E_Quest.QUEST_TYPE_GOGIVE;
				E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
				cmbItem.Enabled = true;
			}
			else
			{
				cmbItem.Enabled = false;
			}
		}
		
		public void OptTask6_CheckedChanged(object sender, EventArgs e)
		{
			if (optTask6.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 6;
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = E_Quest.QUEST_TYPE_GOTRAIN;
				E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
				cmbResource.Enabled = true;
				nudAmount.Enabled = true;
			}
			else
			{
				cmbResource.Enabled = false;
			}
		}
		
		public void OptTask7_CheckedChanged(object sender, EventArgs e)
		{
			if (optTask7.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 7;
				E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = E_Quest.QUEST_TYPE_GOGET;
				E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
				cmbNpc.Enabled = true;
			}
			else
			{
				cmbNpc.Enabled = false;
			}
		}
		
#endregion
		
#region Requirements
		
		public void BtnAddRequirement_Click(object sender, EventArgs e)
		{
			E_Quest.Quest[E_Globals.Editorindex].ReqCount = E_Quest.Quest[E_Globals.Editorindex].ReqCount + 1;
			
			E_Quest.Quest[E_Globals.Editorindex].Requirement = new int[E_Quest.Quest[E_Globals.Editorindex].ReqCount + 1];
			E_Quest.Quest[E_Globals.Editorindex].RequirementIndex = new int[E_Quest.Quest[E_Globals.Editorindex].ReqCount + 1];
			
			fraRequirements.Visible = true;
			fraRequirements.BringToFront();
		}
		
		public void BtnRemoveRequirement_Click(object sender, EventArgs e)
		{
			int i = 0;
			int[] tmpRequirement;
			int[] tmpRequirementIndex;
			
			if (lstRequirements.SelectedIndex < 0)
			{
				return;
			}
			
			tmpRequirement = new int[E_Quest.Quest[E_Globals.Editorindex].ReqCount];
			tmpRequirementIndex = new int[E_Quest.Quest[E_Globals.Editorindex].ReqCount];
			
			for (i = 1; i <= E_Quest.Quest[E_Globals.Editorindex].ReqCount; i++)
			{
				if (!(i == lstRequirements.SelectedIndex + 1))
				{
					tmpRequirement[i] = System.Convert.ToInt32(E_Quest.Quest[E_Globals.Editorindex].Requirement[i]);
					tmpRequirementIndex[i] = System.Convert.ToInt32(E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[i]);
				}
			}
			
			E_Quest.Quest[E_Globals.Editorindex].ReqCount = E_Quest.Quest[E_Globals.Editorindex].ReqCount - 1;
			
			E_Quest.Quest[E_Globals.Editorindex].Requirement = new int[E_Quest.Quest[E_Globals.Editorindex].ReqCount + 1];
			E_Quest.Quest[E_Globals.Editorindex].RequirementIndex = new int[E_Quest.Quest[E_Globals.Editorindex].ReqCount + 1];
			
			for (i = 1; i <= E_Quest.Quest[E_Globals.Editorindex].ReqCount; i++)
			{
				if (!(i == lstRequirements.SelectedIndex + 1))
				{
					E_Quest.Quest[E_Globals.Editorindex].Requirement[i] = tmpRequirement[i];
					E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[i] = tmpRequirementIndex[i];
				}
			}
			
			lstRequirements.Items.Clear();
			for (i = 1; i <= E_Quest.Quest[E_Globals.Editorindex].ReqCount; i++)
			{

                if ((int)(E_Quest.Quest[E_Globals.Editorindex].Requirement[i]) == 1)
                {
                    lstRequirements.Items.Add(i + ":" + "Item Requirement: " + Types.Item[E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[i]].Name.Trim());
                }
                else if ((int)(E_Quest.Quest[E_Globals.Editorindex].Requirement[i]) == 2)
                {
                    lstRequirements.Items.Add(i + ":" + "Quest Requirement: " + E_Quest.Quest[E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[i]].Name.Trim());
                }
                else if ((int)(E_Quest.Quest[E_Globals.Editorindex].Requirement[i]) == 3)
                {
                    lstRequirements.Items.Add(i + ":" + "Class Requirement: " + Types.Classes[E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[i]].Name.Trim());
                }
                else
                {
                    lstRequirements.Items.Add(i + ":");
                }
                
				
			}
		}
		
		public void LstRequirements_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstRequirements.SelectedIndex < 0)
			{
				return;
			}
			
			E_Quest.LoadRequirement(E_Globals.Editorindex, lstRequirements.SelectedIndex + 1);
			fraRequirements.Visible = true;
			fraRequirements.BringToFront();
		}
		
		public void BtnRequirementSave_Click(object sender, EventArgs e)
		{
			if (rdbNoneReq.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Requirement[E_Quest.Quest[E_Globals.Editorindex].ReqCount] = 0;
				E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[E_Quest.Quest[E_Globals.Editorindex].ReqCount] = 0;
			}
			else if (rdbItemReq.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Requirement[E_Quest.Quest[E_Globals.Editorindex].ReqCount] = 1;
				E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[E_Quest.Quest[E_Globals.Editorindex].ReqCount] = cmbItemReq.SelectedIndex;
			}
			else if (rdbQuestReq.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Requirement[E_Quest.Quest[E_Globals.Editorindex].ReqCount] = 2;
				E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[E_Quest.Quest[E_Globals.Editorindex].ReqCount] = cmbQuestReq.SelectedIndex;
			}
			else if (rdbClassReq.Checked == true)
			{
				E_Quest.Quest[E_Globals.Editorindex].Requirement[E_Quest.Quest[E_Globals.Editorindex].ReqCount] = 3;
				E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[E_Quest.Quest[E_Globals.Editorindex].ReqCount] = cmbClassReq.SelectedIndex;
			}
			
			lstRequirements.Items.Clear();
			for (var i = 1; i <= E_Quest.Quest[E_Globals.Editorindex].ReqCount; i++)
			{
				if ((int) (E_Quest.Quest[E_Globals.Editorindex].Requirement[(int) i]) == 1)
				{
					lstRequirements.Items.Add(i + ":" + "Item Requirement: " + Types.Item[E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[(int) i]].Name.Trim());
				}
				else if ((int) (E_Quest.Quest[E_Globals.Editorindex].Requirement[(int) i]) == 2)
				{
					lstRequirements.Items.Add(i + ":" + "Quest Requirement: " + E_Quest.Quest[E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[(int) i]].Name.Trim());
				}
				else if ((int) (E_Quest.Quest[E_Globals.Editorindex].Requirement[(int) i]) == 3)
				{
					lstRequirements.Items.Add(i + ":" + "Class Requirement: " + Types.Classes[E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[(int) i]].Name.Trim());
				}
				else
				{
					lstRequirements.Items.Add(i + ":");
				}
				
			}
			
			fraRequirements.Visible = false;
		}
		
		public void BtnRequirementCancel_Click(object sender, EventArgs e)
		{
			fraRequirements.Visible = false;
		}
		
		public void RdbNoneReq_CheckedChanged(object sender, EventArgs e)
		{
			cmbItemReq.SelectedIndex = 0;
			cmbItemReq.Enabled = false;
			
			cmbQuestReq.SelectedIndex = 0;
			cmbQuestReq.Enabled = false;
			
			cmbClassReq.SelectedIndex = 0;
			cmbClassReq.Enabled = false;
		}
		
		public void RdbItemReq_CheckedChanged(object sender, EventArgs e)
		{
			cmbItemReq.Enabled = true;
		}
		
		public void RdbQuestReq_CheckedChanged(object sender, EventArgs e)
		{
			cmbQuestReq.Enabled = true;
		}
		
		public void RdbClassReq_CheckedChanged(object sender, EventArgs e)
		{
			cmbClassReq.Enabled = true;
		}
		
#endregion
		
	}
}
