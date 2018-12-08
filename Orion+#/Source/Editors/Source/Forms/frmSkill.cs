using System;

namespace Engine
{
    internal partial class frmSkill
    {
        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            int tmpindex;

            if (E_Globals.Editorindex == 0)
                return;
            tmpindex = lstIndex.SelectedIndex;
            Types.Skill[E_Globals.Editorindex].Name = Microsoft.VisualBasic.Strings.Trim(txtName.Text);
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Skill[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].Type = (byte)cmbType.SelectedIndex;
        }

        private void NudMp_ValueChanged(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].MpCost = (byte)nudMp.Value;
        }

        private void NudLevel_ValueChanged(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].LevelReq = (byte)nudLevel.Value;
        }

        private void CmbAccessReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].AccessReq = (byte)cmbAccessReq.SelectedIndex;
        }

        private void CmbClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].ClassReq = (byte)cmbClass.SelectedIndex;
        }

        private void NudCast_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].CastTime = (byte)nudCast.Value;
        }

        private void NudCool_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].CdTime = (byte)nudCool.Value;
        }

        private void NudIcon_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].Icon = (byte)nudIcon.Value;
            E_Graphics.EditorSkill_BltIcon();
        }

        private void NudMap_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].Map = (byte)nudMap.Value;
        }

        private void CmbDir_SelectedIndexChanged(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].Dir = (byte)cmbDir.SelectedIndex;
        }

        private void NudX_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].X = (byte)nudX.Value;
        }

        private void NudY_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].Y = (byte)nudY.Value;
        }

        private void NudVital_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].Vital = (byte)nudVital.Value;
        }

        private void NudDuration_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].Duration = (byte)nudDuration.Value;
        }

        private void NudInterval_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].Interval = (byte)nudInterval.Value;
        }

        private void NudRange_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].Range = (byte)nudRange.Value;
        }

        private void ChkAOE_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAoE.Checked == false)
                Types.Skill[E_Globals.Editorindex].IsAoE = false;
            else
                Types.Skill[E_Globals.Editorindex].IsAoE = true;
        }

        private void NudAoE_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].AoE = (byte)nudAoE.Value;
        }

        private void CmbAnimCast_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].CastAnim = (byte)cmbAnimCast.SelectedIndex;
        }

        private void CmbAnim_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].SkillAnim = (byte)cmbAnim.SelectedIndex;
        }

        private void NudStun_Scroll(object sender, EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].StunDuration = (byte)nudStun.Value;
        }

        private void LstIndex_Click(object sender, EventArgs e)
        {
            E_Editors.SkillEditorInit();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            E_Editors.SkillEditorOk();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int tmpindex;

            ClientDataBase.ClearSkill(E_Globals.Editorindex);

            tmpindex = lstIndex.SelectedIndex;
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Skill[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;

            E_Editors.SkillEditorInit();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            E_Editors.SkillEditorCancel();
        }

        private void FrmEditor_Skill_Load(object sender, EventArgs e)
        {
            nudIcon.Maximum = E_Graphics.NumSkillIcons;
            nudCast.Value = 1;
        }

        private void ChkProjectile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkProjectile.Checked == false)
                Types.Skill[E_Globals.Editorindex].IsProjectile = 0;
            else
                Types.Skill[E_Globals.Editorindex].IsProjectile = 1;
        }

        private void ScrlProjectile_Scroll(System.Object sender, System.EventArgs e)
        {
            Types.Skill[E_Globals.Editorindex].Projectile = (byte)cmbProjectile.SelectedIndex;
        }

        private void ChkKnockBack_CheckedChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_SKILLS)
                return;

            if (chkKnockBack.Checked == true)
                Types.Skill[E_Globals.Editorindex].KnockBack = 1;
            else
                Types.Skill[E_Globals.Editorindex].KnockBack = 0;
        }

        private void CmbKnockBackTiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_SKILLS)
                return;

            Types.Skill[E_Globals.Editorindex].KnockBackTiles = (byte)cmbKnockBackTiles.SelectedIndex;
        }
    }
}
