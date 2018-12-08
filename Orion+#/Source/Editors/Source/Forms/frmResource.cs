using System;

namespace Engine
{
    internal partial class FrmResource
    {
        private void ScrlNormalPic_Scroll(object sender, EventArgs e)
        {
            E_Graphics.EditorResource_DrawSprite();
            Types.Resource[E_Globals.Editorindex].ResourceImage = (byte)nudNormalPic.Value;
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Types.Resource[E_Globals.Editorindex].ResourceType = cmbType.SelectedIndex;
        }

        private void ScrlExhaustedPic_Scroll(object sender, EventArgs e)
        {
            E_Graphics.EditorResource_DrawSprite();
            Types.Resource[E_Globals.Editorindex].ExhaustedImage = (byte)nudExhaustedPic.Value;
        }

        private void ScrlRewardItem_Scroll(object sender, EventArgs e)
        {
            Types.Resource[E_Globals.Editorindex].ItemReward = cmbRewardItem.SelectedIndex;
        }

        private void ScrlRewardExp_Scroll(object sender, EventArgs e)
        {
            Types.Resource[E_Globals.Editorindex].ExpReward = (byte)nudRewardExp.Value;
        }

        private void ScrlLvlReq_Scroll(object sender, EventArgs e)
        {
            Types.Resource[E_Globals.Editorindex].LvlRequired = (byte)nudLvlReq.Value;
        }

        private void CmbTool_SelectedIndexChanged(object sender, EventArgs e)
        {
            Types.Resource[E_Globals.Editorindex].ToolRequired = cmbTool.SelectedIndex;
        }

        private void ScrlHealth_Scroll(object sender, EventArgs e)
        {
            Types.Resource[E_Globals.Editorindex].Health = (byte)nudHealth.Value;
        }

        private void ScrlRespawn_Scroll(object sender, EventArgs e)
        {
            Types.Resource[E_Globals.Editorindex].RespawnTime = (byte)nudRespawn.Value;
        }

        private void ScrlAnim_Scroll(object sender, EventArgs e)
        {
            Types.Resource[E_Globals.Editorindex].Animation = cmbAnimation.SelectedIndex;
        }

        private void LstIndex_Click(object sender, EventArgs e)
        {
            E_Editors.ResourceEditorInit();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            E_Editors.ResourceEditorOk();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int tmpindex;

            ClientDataBase.ClearResource(E_Globals.Editorindex);

            tmpindex = lstIndex.SelectedIndex;
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Resource[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;

            E_Editors.ResourceEditorInit();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            E_Editors.ResourceEditorCancel();
        }

        private void FrmEditor_Resource_Load(object sender, EventArgs e)
        {
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            int tmpindex;

            if (E_Globals.Editorindex == 0)
                return;
            tmpindex = lstIndex.SelectedIndex;
            Types.Resource[E_Globals.Editorindex].Name = Microsoft.VisualBasic.Strings.Trim(txtName.Text);
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Resource[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;
        }

        private void TxtMessage_TextChanged(object sender, EventArgs e)
        {
            Types.Resource[E_Globals.Editorindex].SuccessMessage = Microsoft.VisualBasic.Strings.Trim(txtMessage.Text);
        }

        private void TxtMessage2_TextChanged(object sender, EventArgs e)
        {
            Types.Resource[E_Globals.Editorindex].EmptyMessage = Microsoft.VisualBasic.Strings.Trim(txtMessage2.Text);
        }
    }
}
