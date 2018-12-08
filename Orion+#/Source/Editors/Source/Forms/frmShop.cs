using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using System.IO;

namespace Engine
{
    internal partial class frmShop
    {
        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            int tmpindex;

            if (E_Globals.Editorindex == 0)
                return;
            tmpindex = lstIndex.SelectedIndex;
            Types.Shop[E_Globals.Editorindex].Name = Microsoft.VisualBasic.Strings.Trim(txtName.Text);
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Shop[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;
        }

        private void ScrlBuy_Scroll(object sender, EventArgs e)
        {
            Types.Shop[E_Globals.Editorindex].BuyRate = (byte)nudBuy.Value;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            int index;
            index = lstTradeItem.SelectedIndex + 1;
            if (index == 0)
                return;
            {
                var withBlock = Types.Shop[E_Globals.Editorindex].TradeItem[index];
                withBlock.Item = (byte)cmbItem.SelectedIndex;
                withBlock.ItemValue = (byte)nudItemValue.Value;
                withBlock.CostItem = (byte)cmbCostItem.SelectedIndex;
                withBlock.CostValue = (byte)nudCostValue.Value;
            }
            E_Editors.UpdateShopTrade();
        }

        private void BtnDeleteTrade_Click(object sender, EventArgs e)
        {
            int index;
            index = lstTradeItem.SelectedIndex + 1;
            if (index == 0)
                return;
            {
                var withBlock = Types.Shop[E_Globals.Editorindex].TradeItem[index];
                withBlock.Item = 0;
                withBlock.ItemValue = 0;
                withBlock.CostItem = 0;
                withBlock.CostValue = 0;
            }
            E_Editors.UpdateShopTrade();
        }

        private void LstIndex_Click(object sender, EventArgs e)
        {
            E_Editors.ShopEditorInit();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(txtName.Text)) == 0)
                Interaction.MsgBox("Name required.");
            else
                E_Editors.ShopEditorOk();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            E_Editors.ShopEditorCancel();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int tmpindex;

            ClientDataBase.ClearShop(E_Globals.Editorindex);

            tmpindex = lstIndex.SelectedIndex;
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Shop[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;

            E_Editors.ShopEditorInit();
        }

        private void ScrlFace_Scroll(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Faces\" + nudFace.Value + E_Globals.GFX_EXT))
                this.picFace.BackgroundImage = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"Faces\" + nudFace.Value + E_Globals.GFX_EXT);

            Types.Shop[E_Globals.Editorindex].Face = (byte)nudFace.Value;
        }
    }
}
