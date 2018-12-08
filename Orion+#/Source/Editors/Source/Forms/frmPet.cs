using System.Drawing;
using System.Windows.Forms;
using System;
using System.IO;

namespace Engine
{
    internal partial class frmPet
    {
        private void FrmEditor_Pet_Load(object sender, EventArgs e)
        {
            EditorPet_DrawPet();

            nudSprite.Maximum = E_Graphics.NumCharacters;
            nudRange.Maximum = 50;
            nudLevel.Maximum = Constants.MAX_LEVELS;
            nudMaxLevel.Maximum = Constants.MAX_LEVELS;
        }

        private void LstIndex_Click(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;
            E_Pets.PetEditorInit();
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            int tmpindex;
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;
            tmpindex = lstIndex.SelectedIndex;
            E_Pets.Pet[E_Globals.Editorindex].Name = Microsoft.VisualBasic.Strings.Trim(txtName.Text);
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + E_Pets.Pet[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;
        }

        private void NudSprite_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].Sprite = (byte)nudSprite.Value;

            EditorPet_DrawPet();
        }

        internal void EditorPet_DrawPet()
        {
            int petnum;

            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            petnum = (byte)nudSprite.Value;

            if (petnum < 1 || petnum > E_Graphics.NumCharacters)
            {
                picSprite.BackgroundImage = null;
                return;
            }

            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Characters\" + petnum + E_Globals.GFX_EXT))
                picSprite.BackgroundImage = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"Characters\" + petnum + E_Globals.GFX_EXT);
        }

        private void NudRange_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].Range = (byte)nudRange.Value;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            E_Pets.PetEditorOk();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            E_Pets.PetEditorCancel();
        }



        private void OptCustomStats_CheckedChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            if (optCustomStats.Checked == true)
            {
                pnlCustomStats.Visible = true;
                E_Pets.Pet[E_Globals.Editorindex].StatType = 1;
            }
            else
            {
                pnlCustomStats.Visible = false;
                E_Pets.Pet[E_Globals.Editorindex].StatType = 0;
            }
        }

        private void OptAdoptStats_CheckedChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            if (optAdoptStats.Checked == true)
            {
                pnlCustomStats.Visible = false;
                E_Pets.Pet[E_Globals.Editorindex].StatType = 0;
            }
            else
            {
                pnlCustomStats.Visible = true;
                E_Pets.Pet[E_Globals.Editorindex].StatType = 1;
            }
        }

        private void NudStrength_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Strength] = (byte)nudStrength.Value;
        }

        private void NudEndurance_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Endurance] = (byte)nudEndurance.Value;
        }

        private void NudVitality_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Vitality] = (byte)nudVitality.Value;
        }

        private void NudLuck_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Luck] = (byte)nudLuck.Value;
        }

        private void NudIntelligence_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Intelligence] = (byte)nudIntelligence.Value;
        }

        private void NudSpirit_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Spirit] = (byte)nudSpirit.Value;
        }

        private void NudLevel_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].Level = (byte)nudLevel.Value;
        }



        private void NudPetExp_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].ExpGain = (byte)nudPetExp.Value;
        }

        private void NudPetPnts_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].LevelPnts = (byte)nudPetPnts.Value;
        }

        private void NudMaxLevel_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].MaxLevel = (byte)nudMaxLevel.Value;
        }

        private void OptLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            if (optLevel.Checked == true)
            {
                pnlPetlevel.Visible = true;
                E_Pets.Pet[E_Globals.Editorindex].LevelingType = 1;
            }
        }

        private void OptDoNotLevel_CheckedChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            if (optDoNotLevel.Checked == true)
            {
                pnlPetlevel.Visible = false;
                E_Pets.Pet[E_Globals.Editorindex].LevelingType = 0;
            }
        }



        private void CmbSkill1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].Skill[1] = cmbSkill1.SelectedIndex;
        }

        private void CmbSkill2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].Skill[2] = cmbSkill2.SelectedIndex;
        }

        private void CmbSkill3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].Skill[3] = cmbSkill3.SelectedIndex;
        }

        private void CmbSkill4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].Skill[4] = cmbSkill4.SelectedIndex;
        }



        private void ChkEvolve_CheckedChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            if (chkEvolve.Checked == true)
                E_Pets.Pet[E_Globals.Editorindex].Evolvable = 1;
            else
                E_Pets.Pet[E_Globals.Editorindex].Evolvable = 0;
        }

        private void NudEvolveLvl_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].EvolveLevel = (byte)nudEvolveLvl.Value;
        }

        private void CmbEvolve_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_PETS)
                return;

            E_Pets.Pet[E_Globals.Editorindex].EvolveNum = cmbEvolve.SelectedIndex;
        }
    }
}
