using System;

namespace Engine
{
    internal partial class FrmAnimation
    {
        private void NudSprite0_ValueChanged(object sender, EventArgs e)
        {
            Types.Animation[E_Globals.Editorindex].Sprite[0] = (byte)nudSprite0.Value;
        }

        private void NudSprite1_ValueChanged(object sender, EventArgs e)
        {
            Types.Animation[E_Globals.Editorindex].Sprite[1] = (byte)nudSprite1.Value;
        }

        private void NudLoopCount0_ValueChanged(object sender, EventArgs e)
        {
            Types.Animation[E_Globals.Editorindex].LoopCount[0] = (byte)nudLoopCount0.Value;
        }

        private void NudLoopCount1_ValueChanged(object sender, EventArgs e)
        {
            Types.Animation[E_Globals.Editorindex].LoopCount[1] = (byte)nudLoopCount1.Value;
        }

        private void NudFrameCount0_ValueChanged(object sender, EventArgs e)
        {
            Types.Animation[E_Globals.Editorindex].Frames[0] = (byte)nudFrameCount0.Value;
        }

        private void NudFrameCount1_ValueChanged(object sender, EventArgs e)
        {
            Types.Animation[E_Globals.Editorindex].Frames[1] = (byte)nudFrameCount1.Value;
        }

        private void NudLoopTime0_ValueChanged(object sender, EventArgs e)
        {
            Types.Animation[E_Globals.Editorindex].LoopTime[0] = (byte)nudLoopTime0.Value;
        }

        private void NudLoopTime1_ValueChanged(object sender, EventArgs e)
        {
            Types.Animation[E_Globals.Editorindex].LoopTime[1] = (byte)nudLoopTime1.Value;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            E_Editors.AnimationEditorOk();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            int tmpindex;
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ANIMATIONS)
                return;
            tmpindex = lstIndex.SelectedIndex;
            Types.Animation[E_Globals.Editorindex].Name = Microsoft.VisualBasic.Strings.Trim(txtName.Text);
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Animation[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;
        }

        private void LstIndex_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            E_Editors.AnimationEditorInit();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int tmpindex;

            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ANIMATIONS)
                return;

            ClientDataBase.ClearAnimation(E_Globals.Editorindex);

            tmpindex = lstIndex.SelectedIndex;
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Animation[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;

            E_Editors.AnimationEditorInit();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            E_Editors.AnimationEditorCancel();
        }

        private void FrmEditor_Animation_Load(object sender, EventArgs e)
        {
            nudSprite0.Maximum = E_Graphics.NumAnimations;
            nudSprite1.Maximum = E_Graphics.NumAnimations;
        }

        private void CmbSound_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ANIMATIONS)
                return;

            Types.Animation[E_Globals.Editorindex].Sound = cmbSound.SelectedItem.ToString();
        }
    }
}
