using System.Windows.Forms;
using System;

namespace Engine
{
    internal partial class FrmItem
    {
        private void BtnSave_Click(object sender, EventArgs e)
        {
            E_Items.ItemEditorOk();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            E_Items.ItemEditorCancel();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int tmpindex;

            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            E_Items.ClearItem(E_Globals.Editorindex + 1);

            tmpindex = lstIndex.SelectedIndex;
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Item[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;

            E_Items.ItemEditorInit();
        }

        private void LstIndex_Click(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;
            E_Items.ItemEditorInit();
            PicFurniture_MouseDown(sender, (MouseEventArgs)e);
        }

        private void PicItem_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PicPaperdoll_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PicFurniture_Paint(object sender, PaintEventArgs e)
        {
        }

        private void FrmEditor_Item_Load(object sender, EventArgs e)
        {
            nudPic.Maximum = E_Graphics.NumItems;
            nudPaperdoll.Maximum = E_Graphics.NumPaperdolls;
            nudFurniture.Maximum = E_Housing.NumFurniture;
            cmbFurnitureType.SelectedIndex = 0;
        }

        private void BtnBasics_Click(object sender, EventArgs e)
        {
            fraBasics.Visible = true;
            fraRequirements.Visible = false;
        }

        private void BtnRequirements_Click(object sender, EventArgs e)
        {
            fraBasics.Visible = false;
            fraRequirements.Visible = true;
        }



        private void NudPic_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Pic = (byte)nudPic.Value;
            E_Items.EditorItem_DrawItem();
        }

        private void CmbBind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].BindType = (byte)cmbBind.SelectedIndex;
        }

        private void NudRarity_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Rarity = (byte)nudRarity.Value;
        }

        private void CmbAnimation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Animation = cmbAnimation.SelectedIndex;
        }

        private void CmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            cmbSubType.Enabled = false;

            if ((cmbType.SelectedIndex == (byte)Enums.ItemType.Equipment))
            {
                fraEquipment.Visible = true;

                // Build subtype cmb
                cmbSubType.Items.Clear();
                cmbSubType.Items.Add("None");

                cmbSubType.Items.Add("Weapon");
                cmbSubType.Items.Add("Armor");
                cmbSubType.Items.Add("Helmet");
                cmbSubType.Items.Add("Shield");
                cmbSubType.Items.Add("Shoes");
                cmbSubType.Items.Add("Gloves");

                cmbSubType.Enabled = true;
                cmbSubType.SelectedIndex = Types.Item[E_Globals.Editorindex].SubType;
            }
            else
                fraEquipment.Visible = false;

            if ((cmbType.SelectedIndex == (byte)Enums.ItemType.Consumable))
            {
                fraVitals.Visible = true;

                // Build subtype cmb
                cmbSubType.Items.Clear();
                cmbSubType.Items.Add("None");

                cmbSubType.Items.Add("Hp");
                cmbSubType.Items.Add("Mp");
                cmbSubType.Items.Add("Sp");
                cmbSubType.Items.Add("Exp");

                cmbSubType.Enabled = true;
                cmbSubType.SelectedIndex = Types.Item[E_Globals.Editorindex].SubType;
            }
            else
                fraVitals.Visible = false;

            if ((cmbType.SelectedIndex == (byte)Enums.ItemType.Skill))
                fraSkill.Visible = true;
            else
                fraSkill.Visible = false;

            if (cmbType.SelectedIndex == (byte)Enums.ItemType.Furniture)
                fraFurniture.Visible = true;
            else
                fraFurniture.Visible = false;

            if (cmbType.SelectedIndex == (byte)Enums.ItemType.Recipe)
                fraRecipe.Visible = true;
            else
                fraRecipe.Visible = false;

            if (cmbType.SelectedIndex == (byte)Enums.ItemType.Pet)
                fraPet.Visible = true;
            else
                fraPet.Visible = false;

            Types.Item[E_Globals.Editorindex].Type = (byte)cmbType.SelectedIndex;
        }

        private void NudVitalMod_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Data1 = (byte)nudVitalMod.Value;
        }

        private void CmbSkills_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Data1 = cmbSkills.SelectedIndex;
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            int tmpindex;
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;
            tmpindex = lstIndex.SelectedIndex;
            Types.Item[E_Globals.Editorindex].Name = Microsoft.VisualBasic.Strings.Trim(txtName.Text);
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Item[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;
        }

        private void NudPrice_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Price = (byte)nudPrice.Value;
        }

        private void ChkStackable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStackable.Checked == true)
                Types.Item[E_Globals.Editorindex].Stackable = 1;
            else
                Types.Item[E_Globals.Editorindex].Stackable = 0;
        }

        private void CmbRecipe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Data1 = cmbRecipe.SelectedIndex;
        }

        private void TxtDescription_TextChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Description = Microsoft.VisualBasic.Strings.Trim(txtDescription.Text);
        }

        private void CmbSubType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].SubType = (byte)cmbSubType.SelectedIndex;
        }

        private void NudItemLvl_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].ItemLevel = (byte)nudItemLvl.Value;
        }

        private void CmbPet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Data1 = cmbPet.SelectedIndex;
        }



        private void CmbClassReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].ClassReq = cmbClassReq.SelectedIndex;
        }

        private void CmbAccessReq_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].AccessReq = cmbAccessReq.SelectedIndex;
        }

        private void NudLevelReq_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].LevelReq = (byte)nudLevelReq.Value;
        }

        private void NudStrReq_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Stat_Req[(byte)Enums.StatType.Strength] = (byte)nudStrReq.Value;
        }

        private void NudEndReq_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Stat_Req[(byte)Enums.StatType.Endurance] = (byte)nudEndReq.Value;
        }

        private void NudVitReq_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Stat_Req[(byte)Enums.StatType.Vitality] = (byte)nudVitReq.Value;
        }

        private void NudLuckReq_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Stat_Req[(byte)Enums.StatType.Luck] = (byte)nudLuckReq.Value;
        }

        private void NudIntReq_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Stat_Req[(byte)Enums.StatType.Intelligence] = (byte)nudIntReq.Value;
        }

        private void NudSprReq_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Stat_Req[(byte)Enums.StatType.Spirit] = (byte)nudSprReq.Value;
        }



        private void CmbTool_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;
            Types.Item[E_Globals.Editorindex].Data3 = cmbTool.SelectedIndex;
        }

        private void NudDamage_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Data2 = (byte)nudDamage.Value;
        }

        private void NudSpeed_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;
            lblSpeed.Text = "Speed: " + nudSpeed.Value / (int)1000 + " sec";
            Types.Item[E_Globals.Editorindex].Speed = (byte)nudSpeed.Value;
        }

        private void NudPaperdoll_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Paperdoll = (byte)nudPaperdoll.Value;
            E_Items.EditorItem_DrawPaperdoll();
        }

        private void NudStrength_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Add_Stat[(byte)Enums.StatType.Strength] = (byte)nudStrength.Value;
        }

        private void NudLuck_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Add_Stat[(byte)Enums.StatType.Luck] = (byte)nudLuck.Value;
        }

        private void NudEndurance_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Add_Stat[(byte)Enums.StatType.Endurance] = (byte)nudEndurance.Value;
        }

        private void NudIntelligence_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Add_Stat[(byte)Enums.StatType.Intelligence] = (byte)nudIntelligence.Value;
        }

        private void NudVitality_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Add_Stat[(byte)Enums.StatType.Vitality] = (byte)nudVitality.Value;
        }

        private void NudSpirit_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Add_Stat[(byte)Enums.StatType.Spirit] = (byte)nudSpirit.Value;
        }

        private void ChkKnockBack_CheckedChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            if (chkKnockBack.Checked == true)
                Types.Item[E_Globals.Editorindex].KnockBack = 1;
            else
                Types.Item[E_Globals.Editorindex].KnockBack = 0;
        }

        private void CmbKnockBackTiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].KnockBackTiles = (byte)cmbKnockBackTiles.SelectedIndex;
        }

        private void ChkRandomize_CheckedChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            if (chkRandomize.Checked == true)
                Types.Item[E_Globals.Editorindex].Randomize = 1;
            else
                Types.Item[E_Globals.Editorindex].Randomize = 0;
        }

        private void CmbProjectile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Projectile = cmbProjectile.SelectedIndex;
        }

        private void CmbAmmo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Ammo = cmbAmmo.SelectedIndex;
        }



        private void CmbFurnitureType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;
            Types.Item[E_Globals.Editorindex].Data1 = cmbFurnitureType.SelectedIndex;
        }

        private void OptNoFurnitureEditing_CheckedChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;
            if (optNoFurnitureEditing.Checked == true)
                lblSetOption.Text = "No Editing: Lets you look at the image without setting any options (blocks/fringes).";
            E_Items.EditorItem_DrawFurniture();
        }

        private void OptSetBlocks_CheckedChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;
            if (optSetBlocks.Checked == true)
                lblSetOption.Text = "Set Blocks: Os are passable and Xs are not. Simply place Xs where you do not want the player to walk.";
            E_Items.EditorItem_DrawFurniture();
        }

        private void OptSetFringe_CheckedChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;
            if (optSetFringe.Checked == true)
                lblSetOption.Text = "Set Fringe: Os are draw on the fringe layer (the player can walk behind).";
            E_Items.EditorItem_DrawFurniture();
        }

        private void NudFurniture_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;

            Types.Item[E_Globals.Editorindex].Data2 = (byte)nudFurniture.Value;

            if (E_Graphics.FurnitureGFXInfo[(byte)nudFurniture.Value].IsLoaded == false)
                E_Graphics.LoadTexture((byte)nudFurniture.Value, 10);

            // seeying we still use it, lets update timer
            {
                var withBlock = E_Graphics.FurnitureGFXInfo[(byte)nudFurniture.Value];
                withBlock.TextureTimer = ClientDataBase.GetTickCount() + 100000;
            }

            if (nudFurniture.Value > 0 && nudFurniture.Value <= E_Housing.NumFurniture)
            {
                Types.Item[E_Globals.Editorindex].FurnitureWidth = E_Graphics.FurnitureGFXInfo[(byte)nudFurniture.Value].width / (int)32;
                Types.Item[E_Globals.Editorindex].FurnitureHeight = E_Graphics.FurnitureGFXInfo[(byte)nudFurniture.Value].height / (int)32;
                if (Types.Item[E_Globals.Editorindex].FurnitureHeight > 1)
                    Types.Item[E_Globals.Editorindex].FurnitureHeight = Types.Item[E_Globals.Editorindex].FurnitureHeight - 1;
            }
            else
            {
                Types.Item[E_Globals.Editorindex].FurnitureWidth = 1;
                Types.Item[E_Globals.Editorindex].FurnitureHeight = 1;
            }

            E_Items.EditorItem_DrawFurniture();
        }

        private void PicFurniture_MouseDown(object sender, MouseEventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
                return;
            int X;
            int Y;
            X = e.X / 32;
            Y = e.Y / 32;

            if (X > 3)
                return;
            if (Y > 3)
                return;

            if (optSetBlocks.Checked == true)
            {
                if (Types.Item[E_Globals.Editorindex].FurnitureBlocks[X, Y] == 1)
                    Types.Item[E_Globals.Editorindex].FurnitureBlocks[X, Y] = 0;
                else
                    Types.Item[E_Globals.Editorindex].FurnitureBlocks[X, Y] = 1;
            }
            else if (optSetFringe.Checked == true)
            {
                if (Types.Item[E_Globals.Editorindex].FurnitureFringe[X, Y] == 1)
                    Types.Item[E_Globals.Editorindex].FurnitureFringe[X, Y] = 0;
                else
                    Types.Item[E_Globals.Editorindex].FurnitureFringe[X, Y] = 1;
            }
            E_Items.EditorItem_DrawFurniture();
        }
    }
}
