using System;

namespace Engine
{
    internal partial class frmNPC
    {
        private void FrmEditor_NPC_Load(object sender, EventArgs e)
        {
            nudSprite.Maximum = E_Graphics.NumCharacters;

            cmbItem.Items.Clear();
            cmbItem.Items.Add("None");
            for (var i = 1; i <= Constants.MAX_ITEMS; i++)
                cmbItem.Items.Add(i + ": " + Types.Item[i].Name);
        }

        private void LstIndex_Click(object sender, EventArgs e)
        {
            E_Editors.NpcEditorInit();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            E_Editors.NpcEditorOk();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            int tmpindex;

            if (E_Globals.Editorindex <= 0)
                return;

            ClientDataBase.ClearNpc(E_Globals.Editorindex);

            tmpindex = lstIndex.SelectedIndex;
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Npc[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;

            E_Editors.NpcEditorInit();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            E_Editors.NpcEditorCancel();
        }



        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            int tmpindex;

            if (E_Globals.Editorindex == 0)
                return;

            tmpindex = lstIndex.SelectedIndex;
            Types.Npc[E_Globals.Editorindex].Name = Microsoft.VisualBasic.Strings.Trim(txtName.Text);
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Npc[E_Globals.Editorindex].Name);
            lstIndex.SelectedIndex = tmpindex;
        }

        private void TxtAttackSay_TextChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].AttackSay = txtAttackSay.Text;
        }

        private void NudSprite_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Sprite = (byte)nudSprite.Value;

            E_Graphics.EditorNpc_DrawSprite();
        }

        private void NudRange_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Range = (byte)nudRange.Value;
        }

        private void CmbBehavior_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Behaviour = (byte)cmbBehaviour.SelectedIndex;
        }

        private void CmbFaction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Faction = (byte)cmbFaction.SelectedIndex;
        }

        private void CmbAnimation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Animation = (byte)cmbAnimation.SelectedIndex;
        }

        private void NudSpawnSecs_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].SpawnSecs = (byte)nudSpawnSecs.Value;
        }

        private void NudHp_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Hp = (byte)nudHp.Value;
        }

        private void NudExp_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Exp = (byte)nudExp.Value;
        }

        private void CmbQuest_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].QuestNum = (byte)cmbQuest.SelectedIndex;
        }

        private void NudLevel_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Level = (byte)nudLevel.Value;
        }

        private void NudDamage_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Damage = (byte)nudDamage.Value;
        }

        private void CmbSpawnPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].SpawnTime = (byte)cmbSpawnPeriod.SelectedIndex;
        }



        private void NudStrength_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Strength] = (byte)nudStrength.Value;
        }

        private void NudEndurance_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Endurance] = (byte)nudEndurance.Value;
        }

        private void NudVitality_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Vitality] = (byte)nudVitality.Value;
        }

        private void NudLuck_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Luck] = (byte)nudLuck.Value;
        }

        private void NudIntelligence_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Intelligence] = (byte)nudIntelligence.Value;
        }

        private void NudSpirit_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Spirit] = (byte)nudSpirit.Value;
        }



        private void CmbDropSlot_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            cmbItem.SelectedIndex = Types.Npc[E_Globals.Editorindex].DropItem[cmbDropSlot.SelectedIndex + 1];

            nudAmount.Value = Types.Npc[E_Globals.Editorindex].DropItemValue[cmbDropSlot.SelectedIndex + 1];

            nudChance.Value = Types.Npc[E_Globals.Editorindex].DropChance[cmbDropSlot.SelectedIndex + 1];
        }

        private void CmbItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].DropItem[cmbDropSlot.SelectedIndex + 1] = (byte)cmbItem.SelectedIndex;
        }

        private void ScrlValue_Scroll(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].DropItemValue[cmbDropSlot.SelectedIndex + 1] = (byte)nudAmount.Value;
        }

        private void NudChance_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].DropChance[cmbDropSlot.SelectedIndex + 1] = (byte)nudChance.Value;
        }



        private void CmbSkill1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Skill[1] = (byte)cmbSkill1.SelectedIndex;
        }

        private void CmbSkill2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Skill[2] = (byte)cmbSkill2.SelectedIndex;
        }

        private void CmbSkill3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Skill[3] = (byte)cmbSkill3.SelectedIndex;
        }

        private void CmbSkill4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Skill[4] = (byte)cmbSkill4.SelectedIndex;
        }

        private void CmbSkill5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Skill[5] = (byte)cmbSkill5.SelectedIndex;
        }

        private void CmbSkill6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0)
                return;

            Types.Npc[E_Globals.Editorindex].Skill[6] = (byte)cmbSkill6.SelectedIndex;
        }
    }
}
