using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using static Engine.E_Quest;

namespace Engine
{
    internal partial class FrmQuest
    {
        private int SelectedTask;

        private void FrmEditor_Quest_Load(object sender, EventArgs e)
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
        }

        private void LstIndex_Click(object sender, EventArgs e)
        {
            E_Quest.QuestEditorInit();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            int tmpindex;

            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
                return;

            tmpindex = lstIndex.SelectedIndex;
            E_Quest.Quest[E_Globals.Editorindex].Name = Microsoft.VisualBasic.Strings.Trim(txtName.Text);
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + E_Quest.Quest[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
                return;

            if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(txtName.Text)) == 0)
                Interaction.MsgBox("Name required.");
            else
                E_Quest.QuestEditorOk();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            E_Quest.QuestEditorCancel();
        }

        private void TxtStartText_TextChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
                return;

            E_Quest.Quest[E_Globals.Editorindex].Chat[1] = Microsoft.VisualBasic.Strings.Trim(txtStartText.Text);
        }

        private void TxtProgressText_TextChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
                return;

            E_Quest.Quest[E_Globals.Editorindex].Chat[2] = Microsoft.VisualBasic.Strings.Trim(txtProgressText.Text);
        }

        private void TxtEndText_TextChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
                return;

            E_Quest.Quest[E_Globals.Editorindex].Chat[3] = Microsoft.VisualBasic.Strings.Trim(txtEndText.Text);
        }

        private void CmbStartItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
                return;

            E_Quest.Quest[E_Globals.Editorindex].QuestGiveItem = cmbStartItem.SelectedIndex;
        }

        private void CmbEndItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
                return;

            E_Quest.Quest[E_Globals.Editorindex].QuestRemoveItem = cmbEndItem.SelectedIndex;
        }

        private void NudGiveAmount_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
                return;

            E_Quest.Quest[E_Globals.Editorindex].QuestGiveItemValue = cmbEndItem.SelectedIndex;
        }

        private void NudTakeAmount_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
                return;

            E_Quest.Quest[E_Globals.Editorindex].QuestRemoveItemValue = (byte)nudTakeAmount.Value;
        }

        private void ChkRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
                return;

            if (chkRepeat.Checked == true)
                E_Quest.Quest[E_Globals.Editorindex].Repeat = 1;
            else
                E_Quest.Quest[E_Globals.Editorindex].Repeat = 0;
        }

        private void ChkQuestCancel_CheckedChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
                return;

            if (chkQuestCancel.Checked == true)
                E_Quest.Quest[E_Globals.Editorindex].Cancelable = 1;
            else
                E_Quest.Quest[E_Globals.Editorindex].Cancelable = 0;
        }


        private void NudExpReward_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
                return;

            E_Quest.Quest[E_Globals.Editorindex].RewardExp = (byte)nudExpReward.Value;
        }

        private void BtnAddReward_Click(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Quest.MAX_QUESTS)
                return;

            if (cmbItemReward.SelectedIndex < 0)
                return;

            E_Quest.Quest[E_Globals.Editorindex].RewardCount = E_Quest.Quest[E_Globals.Editorindex].RewardCount + 1;
            var oldRewardItem = E_Quest.Quest[E_Globals.Editorindex].RewardItem;
            E_Quest.Quest[E_Globals.Editorindex].RewardItem = new int[E_Quest.Quest[E_Globals.Editorindex].RewardCount + 1];
            if (oldRewardItem != null)
                Array.Copy(oldRewardItem, E_Quest.Quest[E_Globals.Editorindex].RewardItem, Math.Min(E_Quest.Quest[E_Globals.Editorindex].RewardCount + 1, oldRewardItem.Length));
            var oldRewardItemAmount = E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount;
            E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount = new int[E_Quest.Quest[E_Globals.Editorindex].RewardCount + 1];
            if (oldRewardItemAmount != null)
                Array.Copy(oldRewardItemAmount, E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount, Math.Min(E_Quest.Quest[E_Globals.Editorindex].RewardCount + 1, oldRewardItemAmount.Length));

            E_Quest.Quest[E_Globals.Editorindex].RewardItem[E_Quest.Quest[E_Globals.Editorindex].RewardCount] = cmbItemReward.SelectedIndex;
            E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount[E_Quest.Quest[E_Globals.Editorindex].RewardCount] = (byte)nudItemRewValue.Value;

            lstRewards.Items.Clear();
            var loopTo = E_Quest.Quest[E_Globals.Editorindex].RewardCount;
            for (var i = 1; i <= loopTo; i++)
                lstRewards.Items.Add(i + ":" + E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount[i] + " X " + Microsoft.VisualBasic.Strings.Trim(Types.Item[E_Quest.Quest[E_Globals.Editorindex].RewardItem[i]].Name));
        }

        private void BtnRemoveReward_Click(object sender, EventArgs e)
        {
            int[] tmpRewardItem;
            int[] tmpRewardItemIndex;

            if (lstRewards.SelectedIndex < 0)
                return;
            if (E_Quest.Quest[E_Globals.Editorindex].RewardCount <= 0)
                return;

            tmpRewardItem = new int[E_Quest.Quest[E_Globals.Editorindex].RewardCount - 1 + 1];
            tmpRewardItemIndex = new int[E_Quest.Quest[E_Globals.Editorindex].RewardCount - 1 + 1];
            var loopTo = E_Quest.Quest[E_Globals.Editorindex].RewardCount;
            for (var i = 1; i <= loopTo; i++)
            {
                if (!(i == lstRewards.SelectedIndex + 1))
                {
                    tmpRewardItem[i] = E_Quest.Quest[E_Globals.Editorindex].RewardItem[i];
                    tmpRewardItemIndex[i] = E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount[i];
                }
            }

            E_Quest.Quest[E_Globals.Editorindex].RewardCount = E_Quest.Quest[E_Globals.Editorindex].RewardCount - 1;

            E_Quest.Quest[E_Globals.Editorindex].RewardItem = new int[E_Quest.Quest[E_Globals.Editorindex].RewardCount + 1];
            E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount = new int[E_Quest.Quest[E_Globals.Editorindex].RewardCount + 1];
            var loopTo1 = E_Quest.Quest[E_Globals.Editorindex].RewardCount;
            for (var i = 1; i <= loopTo1; i++)
            {
                E_Quest.Quest[E_Globals.Editorindex].RewardItem[i] = tmpRewardItem[i];
                E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount[i] = tmpRewardItemIndex[i];
            }

            lstRewards.Items.Clear();
            var loopTo2 = E_Quest.Quest[E_Globals.Editorindex].RewardCount;
            for (var i = 1; i <= loopTo2; i++)
                lstRewards.Items.Add(i + ":" + E_Quest.Quest[E_Globals.Editorindex].RewardItemAmount[i] + " X " + Microsoft.VisualBasic.Strings.Trim(Types.Item[E_Quest.Quest[E_Globals.Editorindex].RewardItem[i]].Name));
        }



        private void LstTasks_DoubleClick(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex < 0)
                return;

            SelectedTask = lstTasks.SelectedIndex + 1;
            E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
            fraTasks.Visible = true;
            fraTasks.BringToFront();
        }

        private void BtnAddTask_Click(object sender, EventArgs e)
        {
            E_Quest.Quest[E_Globals.Editorindex].TaskCount = E_Quest.Quest[E_Globals.Editorindex].TaskCount + 1;
            var oldTask = E_Quest.Quest[E_Globals.Editorindex].Task;
            E_Quest.Quest[E_Globals.Editorindex].Task = new TaskRec[E_Quest.Quest[E_Globals.Editorindex].TaskCount + 1];
            if (oldTask != null)
                Array.Copy(oldTask, E_Quest.Quest[E_Globals.Editorindex].Task, Math.Min(E_Quest.Quest[E_Globals.Editorindex].TaskCount + 1, oldTask.Length));

            SelectedTask = E_Quest.Quest[E_Globals.Editorindex].TaskCount;

            E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);

            fraTasks.Visible = true;
            fraTasks.BringToFront();
        }

        private void BtnRemoveTask_Click(object sender, EventArgs e)
        {
            int i;
            E_Quest.TaskRec[] tmptask;

            if (lstTasks.SelectedIndex < 0)
                return;
            if (E_Quest.Quest[E_Globals.Editorindex].TaskCount <= 0)
                return;

            tmptask = new TaskRec[E_Quest.Quest[E_Globals.Editorindex].TaskCount - 1 + 1];
            var loopTo = E_Quest.Quest[E_Globals.Editorindex].TaskCount;
            for (i = 1; i <= loopTo; i++)
            {
                if (!(i == lstTasks.SelectedIndex + 1))
                    tmptask[i] = E_Quest.Quest[E_Globals.Editorindex].Task[i];
            }

            E_Quest.Quest[E_Globals.Editorindex].TaskCount = E_Quest.Quest[E_Globals.Editorindex].TaskCount - 1;

            E_Quest.Quest[E_Globals.Editorindex].Task = new TaskRec[E_Quest.Quest[E_Globals.Editorindex].TaskCount + 1];
            var loopTo1 = E_Quest.Quest[E_Globals.Editorindex].TaskCount;
            for (i = 1; i <= loopTo1; i++)
            {
                if (!(i == lstTasks.SelectedIndex + 1))
                    E_Quest.Quest[E_Globals.Editorindex].Task[i] = tmptask[i];
            }

            lstTasks.Items.Clear();
            var loopTo2 = E_Quest.Quest[E_Globals.Editorindex].TaskCount;
            for (i = 1; i <= loopTo2; i++)
                lstTasks.Items.Add(i + ":" + E_Quest.Quest[E_Globals.Editorindex].Task[i].TaskLog);
        }

        private void BtnSaveTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedIndex < 0)
                SelectedTask = E_Quest.Quest[E_Globals.Editorindex].TaskCount;
            else
                SelectedTask = lstTasks.SelectedIndex + 1;

            E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskLog = Microsoft.VisualBasic.Strings.Trim(txtTaskLog.Text);
            E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Speech = txtTaskSpeech.Text;

            if (chkEnd.Checked == true)
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].QuestEnd = 1;
            else
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].QuestEnd = 0;

            E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Npc = cmbNpc.SelectedIndex;
            E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Item = cmbItem.SelectedIndex;
            E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Map = cmbMap.SelectedIndex;
            E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Resource = cmbResource.SelectedIndex;
            E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Amount = (byte)nudAmount.Value;

            if (optTask0.Checked == true)
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 0;
            else if (optTask1.Checked == true)
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 1;
            else if (optTask2.Checked == true)
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 2;
            else if (optTask3.Checked == true)
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 3;
            else if (optTask4.Checked == true)
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 4;
            else if (optTask5.Checked == true)
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 5;
            else if (optTask6.Checked == true)
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 6;
            else if (optTask7.Checked == true)
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 7;

            lstTasks.Items.Clear();
            var loopTo = E_Quest.Quest[E_Globals.Editorindex].TaskCount;
            for (var i = 1; i <= loopTo; i++)
                lstTasks.Items.Add(i + ":" + E_Quest.Quest[E_Globals.Editorindex].Task[i].TaskLog);

            fraTasks.Visible = false;
        }

        private void BtnCancelTask_Click(object sender, EventArgs e)
        {
            E_Quest.Quest[E_Globals.Editorindex].TaskCount = E_Quest.Quest[E_Globals.Editorindex].TaskCount - 1;

            E_Quest.Quest[E_Globals.Editorindex].Task = new TaskRec[E_Quest.Quest[E_Globals.Editorindex].TaskCount + 1];

            SelectedTask = E_Quest.Quest[E_Globals.Editorindex].TaskCount;
            fraTasks.Visible = false;
        }

        private void OptTask0_CheckedChanged(object sender, EventArgs e)
        {
            if (optTask0.Checked == true)
            {
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 0;
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = 0;
                E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
            }
        }

        private void OptTask1_CheckedChanged(object sender, EventArgs e)
        {
            if (optTask1.Checked == true)
            {
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 1;
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = E_Quest.QUEST_TYPE_GOSLAY;
                E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
                cmbNpc.Enabled = true;
            }
            else
                cmbNpc.Enabled = false;
        }

        private void OptTask2_CheckedChanged(object sender, EventArgs e)
        {
            if (optTask2.Checked == true)
            {
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 2;
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = E_Quest.QUEST_TYPE_GOGATHER;
                E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
                cmbItem.Enabled = true;
            }
            else
                cmbItem.Enabled = false;
        }

        private void OptTask3_CheckedChanged(object sender, EventArgs e)
        {
            if (optTask3.Checked == true)
            {
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 3;
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = E_Quest.QUEST_TYPE_GOTALK;
                E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
                cmbNpc.Enabled = true;
            }
            else
                cmbNpc.Enabled = false;
        }

        private void OptTask4_CheckedChanged(object sender, EventArgs e)
        {
            if (optTask4.Checked == true)
            {
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 4;
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = E_Quest.QUEST_TYPE_GOREACH;
                E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
                cmbMap.Enabled = true;
            }
            else
                cmbMap.Enabled = false;
        }

        private void OptTask5_CheckedChanged(object sender, EventArgs e)
        {
            if (optTask5.Checked == true)
            {
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 5;
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = E_Quest.QUEST_TYPE_GOGIVE;
                E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
                cmbItem.Enabled = true;
            }
            else
                cmbItem.Enabled = false;
        }

        private void OptTask6_CheckedChanged(object sender, EventArgs e)
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
                cmbResource.Enabled = false;
        }

        private void OptTask7_CheckedChanged(object sender, EventArgs e)
        {
            if (optTask7.Checked == true)
            {
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].Order = 7;
                E_Quest.Quest[E_Globals.Editorindex].Task[SelectedTask].TaskType = E_Quest.QUEST_TYPE_GOGET;
                E_Quest.LoadTask(E_Globals.Editorindex, SelectedTask);
                cmbNpc.Enabled = true;
            }
            else
                cmbNpc.Enabled = false;
        }



        private void BtnAddRequirement_Click(object sender, EventArgs e)
        {
            E_Quest.Quest[E_Globals.Editorindex].ReqCount = E_Quest.Quest[E_Globals.Editorindex].ReqCount + 1;

            E_Quest.Quest[E_Globals.Editorindex].Requirement = new int[E_Quest.Quest[E_Globals.Editorindex].ReqCount + 1];
            E_Quest.Quest[E_Globals.Editorindex].RequirementIndex = new int[E_Quest.Quest[E_Globals.Editorindex].ReqCount + 1];

            fraRequirements.Visible = true;
            fraRequirements.BringToFront();
        }

        private void BtnRemoveRequirement_Click(object sender, EventArgs e)
        {
            int i;
            int[] tmpRequirement;
            int[] tmpRequirementIndex;

            if (lstRequirements.SelectedIndex < 0)
                return;

            tmpRequirement = new int[E_Quest.Quest[E_Globals.Editorindex].ReqCount - 1 + 1];
            tmpRequirementIndex = new int[E_Quest.Quest[E_Globals.Editorindex].ReqCount - 1 + 1];
            var loopTo = E_Quest.Quest[E_Globals.Editorindex].ReqCount;
            for (i = 1; i <= loopTo; i++)
            {
                if (!(i == lstRequirements.SelectedIndex + 1))
                {
                    tmpRequirement[i] = E_Quest.Quest[E_Globals.Editorindex].Requirement[i];
                    tmpRequirementIndex[i] = E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[i];
                }
            }

            E_Quest.Quest[E_Globals.Editorindex].ReqCount = E_Quest.Quest[E_Globals.Editorindex].ReqCount - 1;

            E_Quest.Quest[E_Globals.Editorindex].Requirement = new int[E_Quest.Quest[E_Globals.Editorindex].ReqCount + 1];
            E_Quest.Quest[E_Globals.Editorindex].RequirementIndex = new int[E_Quest.Quest[E_Globals.Editorindex].ReqCount + 1];
            var loopTo1 = E_Quest.Quest[E_Globals.Editorindex].ReqCount;
            for (i = 1; i <= loopTo1; i++)
            {
                if (!(i == lstRequirements.SelectedIndex + 1))
                {
                    E_Quest.Quest[E_Globals.Editorindex].Requirement[i] = tmpRequirement[i];
                    E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[i] = tmpRequirementIndex[i];
                }
            }

            lstRequirements.Items.Clear();
            var loopTo2 = E_Quest.Quest[E_Globals.Editorindex].ReqCount;
            for (i = 1; i <= loopTo2; i++)
            {
                switch (E_Quest.Quest[E_Globals.Editorindex].Requirement[i])
                {
                    case 1:
                        {
                            lstRequirements.Items.Add(i + ":" + "Item Requirement: " + Microsoft.VisualBasic.Strings.Trim(Types.Item[E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[i]].Name));
                            break;
                        }

                    case 2:
                        {
                            lstRequirements.Items.Add(i + ":" + "Quest Requirement: " + Microsoft.VisualBasic.Strings.Trim(E_Quest.Quest[E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[i]].Name));
                            break;
                        }

                    case 3:
                        {
                            lstRequirements.Items.Add(i + ":" + "Class Requirement: " + Microsoft.VisualBasic.Strings.Trim(Types.Classes[E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[i]].Name));
                            break;
                        }

                    default:
                        {
                            lstRequirements.Items.Add(i + ":");
                            break;
                        }
                }
            }
        }

        private void LstRequirements_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRequirements.SelectedIndex < 0)
                return;

            E_Quest.LoadRequirement(E_Globals.Editorindex, lstRequirements.SelectedIndex + 1);
            fraRequirements.Visible = true;
            fraRequirements.BringToFront();
        }

        private void BtnRequirementSave_Click(object sender, EventArgs e)
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
            var loopTo = E_Quest.Quest[E_Globals.Editorindex].ReqCount;
            for (var i = 1; i <= loopTo; i++)
            {
                switch (E_Quest.Quest[E_Globals.Editorindex].Requirement[i])
                {
                    case 1:
                        {
                            lstRequirements.Items.Add(i + ":" + "Item Requirement: " + Microsoft.VisualBasic.Strings.Trim(Types.Item[E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[i]].Name));
                            break;
                        }

                    case 2:
                        {
                            lstRequirements.Items.Add(i + ":" + "Quest Requirement: " + Microsoft.VisualBasic.Strings.Trim(E_Quest.Quest[E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[i]].Name));
                            break;
                        }

                    case 3:
                        {
                            lstRequirements.Items.Add(i + ":" + "Class Requirement: " + Microsoft.VisualBasic.Strings.Trim(Types.Classes[E_Quest.Quest[E_Globals.Editorindex].RequirementIndex[i]].Name));
                            break;
                        }

                    default:
                        {
                            lstRequirements.Items.Add(i + ":");
                            break;
                        }
                }
            }

            fraRequirements.Visible = false;
        }

        private void BtnRequirementCancel_Click(object sender, EventArgs e)
        {
            fraRequirements.Visible = false;
        }

        private void RdbNoneReq_CheckedChanged(object sender, EventArgs e)
        {
            cmbItemReq.SelectedIndex = 0;
            cmbItemReq.Enabled = false;

            cmbQuestReq.SelectedIndex = 0;
            cmbQuestReq.Enabled = false;

            cmbClassReq.SelectedIndex = 0;
            cmbClassReq.Enabled = false;
        }

        private void RdbItemReq_CheckedChanged(object sender, EventArgs e)
        {
            cmbItemReq.Enabled = true;
        }

        private void RdbQuestReq_CheckedChanged(object sender, EventArgs e)
        {
            cmbQuestReq.Enabled = true;
        }

        private void RdbClassReq_CheckedChanged(object sender, EventArgs e)
        {
            cmbClassReq.Enabled = true;
        }
    }
}
