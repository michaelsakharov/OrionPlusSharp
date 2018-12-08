using Microsoft.VisualBasic;
using System;

namespace Engine
{
    internal partial class FrmHouse
    {
        private void LstIndex_Click(object sender, EventArgs e)
        {
            E_Housing.HouseEditorInit();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            int tmpindex;

            if (E_Globals.Editorindex <= 0)
                return;

            tmpindex = lstIndex.SelectedIndex;
            E_Housing.House[E_Globals.Editorindex].ConfigName = Microsoft.VisualBasic.Strings.Trim(txtName.Text);
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + E_Housing.House[E_Globals.Editorindex].ConfigName);
            lstIndex.SelectedIndex = tmpindex;
        }

        private void NudBaseMap_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            if (nudBaseMap.Value < 1 || nudBaseMap.Value > Constants.MAX_MAPS)
                return;
            E_Housing.House[E_Globals.Editorindex].BaseMap = (byte)nudBaseMap.Value;
        }

        private void NudX_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            if (nudX.Value < 0 || nudX.Value > 255)
                return;
            E_Housing.House[E_Globals.Editorindex].X = (byte)nudX.Value;
        }

        private void NudY_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            if (nudY.Value < 0 || nudY.Value > 255)
                return;
            E_Housing.House[E_Globals.Editorindex].Y = (byte)nudY.Value;
        }

        private void NudPrice_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            E_Housing.House[E_Globals.Editorindex].Price = (byte)nudPrice.Value;
        }

        private void NudFurniture_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            if (nudFurniture.Value < 0)
                return;
            E_Housing.House[E_Globals.Editorindex].MaxFurniture = (byte)nudFurniture.Value;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(txtName.Text)) == 0)
            {
                Interaction.MsgBox("Name required.");
                return;
            }

            if (nudBaseMap.Value == 0)
            {
                Interaction.MsgBox("Base map required.");
                return;
            }

            E_Housing.HouseEditorOk();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            E_Housing.HouseEditorCancel();
        }
    }
}
