using System;

namespace Engine
{
    internal partial class FrmRecipe
    {
        private void BtnSave_Click(object sender, EventArgs e)
        {
            E_Crafting.RecipeEditorOk();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            E_Crafting.RecipeEditorCancel();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int tmpindex;

            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_RECIPE)
                return;

            E_Crafting.ClearRecipe(E_Globals.Editorindex);

            tmpindex = lstIndex.SelectedIndex;
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + E_Crafting.Recipe[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;

            lstIngredients.Items.Clear();

            E_Crafting.RecipeEditorInit();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            int tmpindex;
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_RECIPE)
                return;
            tmpindex = lstIndex.SelectedIndex;
            E_Crafting.Recipe[E_Globals.Editorindex].Name = Microsoft.VisualBasic.Strings.Trim(txtName.Text);
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + E_Crafting.Recipe[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;
        }

        private void LstIndex_Click(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_RECIPE)
                return;
            E_Crafting.RecipeEditorInit();
        }

        private void BtnIngredientAdd_Click(object sender, EventArgs e)
        {
            if (lstIngredients.SelectedIndex < 0 || cmbIngredient.SelectedIndex == 0)
                return;

            E_Crafting.Recipe[E_Globals.Editorindex].Ingredients[lstIngredients.SelectedIndex + 1].ItemNum = (byte)cmbIngredient.SelectedIndex;
            E_Crafting.Recipe[E_Globals.Editorindex].Ingredients[lstIngredients.SelectedIndex + 1].Value = (byte)numItemAmount.Value;

            E_Crafting.UpdateIngredient();
        }

        private void CmbMakeItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            E_Crafting.Recipe[E_Globals.Editorindex].MakeItemNum = (byte)cmbMakeItem.SelectedIndex;
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            E_Crafting.Recipe[E_Globals.Editorindex].RecipeType = (byte)cmbType.SelectedIndex;
        }

        private void NudAmount_ValueChanged(object sender, EventArgs e)
        {
            E_Crafting.Recipe[E_Globals.Editorindex].MakeItemAmount = (byte)nudAmount.Value;
        }

        private void NudCreateTime_ValueChanged(object sender, EventArgs e)
        {
            E_Crafting.Recipe[E_Globals.Editorindex].CreateTime = (byte)nudCreateTime.Value;
        }
    }
}
