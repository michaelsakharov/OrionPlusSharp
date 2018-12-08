using System;

namespace Engine
{
    internal partial class frmProjectile
    {
        private void FrmEditor_Projectile_Load(object sender, EventArgs e)
        {
            nudPic.Maximum = E_Projectiles.NumProjectiles;
        }

        private void LstIndex_Click(object sender, EventArgs e)
        {
            E_Projectiles.ProjectileEditorInit();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            E_Projectiles.ProjectileEditorOk();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            E_Projectiles.ProjectileEditorCancel();
        }

        private void TxtName_TextChanged(System.Object sender, EventArgs e)
        {
            int tmpindex;

            if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
                return;

            tmpindex = lstIndex.SelectedIndex;
            E_Projectiles.Projectiles[E_Globals.Editorindex].Name = Microsoft.VisualBasic.Strings.Trim(txtName.Text);
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + E_Projectiles.Projectiles[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;
        }

        private void NudPic_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
                return;

            E_Projectiles.Projectiles[E_Globals.Editorindex].Sprite = (byte)nudPic.Value;
        }

        private void NudRange_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
                return;

            E_Projectiles.Projectiles[E_Globals.Editorindex].Range = (byte)nudRange.Value;
        }

        private void NudSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
                return;

            E_Projectiles.Projectiles[E_Globals.Editorindex].Speed = (byte)nudSpeed.Value;
        }

        private void NudDamage_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
                return;

            E_Projectiles.Projectiles[E_Globals.Editorindex].Damage = (byte)nudDamage.Value;
        }
    }
}
