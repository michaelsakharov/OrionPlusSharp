
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using Engine;

namespace Engine
{
	partial class frmNPC
	{
		public frmNPC()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmNPC defaultInstance;
		
		public static frmNPC Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmNPC();
					defaultInstance.FormClosed += new System.Windows.Forms.FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
			set
			{
				defaultInstance = value;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			defaultInstance = null;
		}
		
#endregion
		
#region Form Code
		
		public void FrmEditor_NPC_Load(object sender, EventArgs e)
		{
			nudSprite.Maximum = E_Graphics.NumCharacters;
			
			cmbItem.Items.Clear();
			cmbItem.Items.Add("None");
			for (var i = 1; i <= Constants.MAX_ITEMS; i++)
			{
                if (Types.Item[(int)i].Name != null)
                {
                    cmbItem.Items.Add(i + ": " + Types.Item[(int)i].Name);
                }
                else
                {
                    cmbItem.Items.Add(i + ": " + "Null");
                }
			}
            E_Editors.NpcEditorInit();

        }

        private long RandomNumber(long high, long low)
        {
            System.Random rnd = new System.Random();

            return rnd.Next((int)low, (int)high);

        }

        private void btnGenStats_Click(object sender, EventArgs e)
        {
            long High;
            long Low;
            long HighExp;
            long LowExp;
            long HighHP;
            long LowHP;
            long HighDam;
            long LowDam;

            if (!chkIsBoss.Checked)
            {
                High = (long)(nudLevel.Value + 4);
                Low = (long)(nudLevel.Value - 4);
                HighExp = (long)(nudLevel.Value * 5 + 2);
                LowExp = (long)(nudLevel.Value * 5 - 2);
                HighHP = (long)(nudLevel.Value * 10 + 3);
                LowHP = (long)(nudLevel.Value * 10 - 3);
                HighDam = (long)(nudLevel.Value + 4);
                LowDam = (long)(nudLevel.Value - 4);
            }
            else
            {
                High = (long)(nudLevel.Value + 10);
                Low = (long)(nudLevel.Value + 4);
                HighExp = (long)(nudLevel.Value * 8 + 6);
                LowExp = (long)(nudLevel.Value * 8 + 2);
                HighHP = (long)(nudLevel.Value * 15 + 3);
                LowHP = (long)(nudLevel.Value * 15 - 3);
                HighDam = (long)(nudLevel.Value + 4);
                LowDam = (long)(nudLevel.Value - 4);
            }

            if (Low <= 0)
            {
                nudStrength.Value =     RandomNumber(High, 0);
                nudEndurance.Value =    RandomNumber(High, 0);
                nudVitality.Value =     RandomNumber(High, 0);
                nudLuck.Value =         RandomNumber(High, 0);
                nudIntelligence.Value = RandomNumber(High, 0);
                nudSpirit.Value =       RandomNumber(High, 0);
                nudExp.Value =          RandomNumber(HighExp, LowExp);
                nudHp.Value =           RandomNumber(HighHP, LowHP);
                nudDamage.Value =       RandomNumber(HighDam, 2);
            }
            else
            {
                nudStrength.Value =     RandomNumber(High, Low);
                nudEndurance.Value =    RandomNumber(High, Low);
                nudVitality.Value =     RandomNumber(High, Low);
                nudLuck.Value =         RandomNumber(High, Low);
                nudIntelligence.Value = RandomNumber(High, Low);
                nudSpirit.Value =       RandomNumber(High, Low);
                nudExp.Value =          RandomNumber(HighExp, LowExp);
                nudHp.Value =           RandomNumber(HighHP, LowHP);
                nudDamage.Value =       RandomNumber(HighDam, LowDam);
            }

        }

        public void LstIndex_Click(object sender, EventArgs e)
		{
			E_Editors.NpcEditorInit();
		}
		
		public void BtnSave_Click(object sender, EventArgs e)
		{
			E_Editors.NpcEditorOk();
		}
		
		public void BtnDelete_Click(object sender, EventArgs e)
		{
			int tmpindex = 0;
			
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			ClientDataBase.ClearNpc(E_Globals.Editorindex);
			
			tmpindex = lstIndex.SelectedIndex;
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Npc[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
			
			E_Editors.NpcEditorInit();
		}
		
		public void BtnCancel_Click(object sender, EventArgs e)
		{
			E_Editors.NpcEditorCancel();
		}
		
#endregion
		
#region Properties
		
		public void TxtName_TextChanged(object sender, EventArgs e)
		{
			int tmpindex = 0;
			
			if (E_Globals.Editorindex == 0)
			{
				return;
			}
			
			tmpindex = lstIndex.SelectedIndex;
			Types.Npc[E_Globals.Editorindex].Name = txtName.Text.Trim();
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Npc[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
		}
		
		public void TxtAttackSay_TextChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].AttackSay = txtAttackSay.Text;
		}
		
		public void NudSprite_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Sprite = (int) nudSprite.Value;
			
			E_Graphics.EditorNpc_DrawSprite();
		}
		
		public void NudRange_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Range = (byte) nudRange.Value;
		}
		
		public void CmbBehavior_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Behaviour = (byte) cmbBehaviour.SelectedIndex;
		}
		
		public void CmbFaction_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Faction = (byte) cmbFaction.SelectedIndex;
		}
		
		public void CmbAnimation_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Animation = (byte)cmbAnimation.SelectedIndex;
		}
		
		public void NudSpawnSecs_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].SpawnSecs = (int) nudSpawnSecs.Value;
		}
		
		public void NudHp_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Hp = (int) nudHp.Value;
		}
		
		public void NudExp_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Exp = (int) nudExp.Value;
		}
		
		public void CmbQuest_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].QuestNum = (byte)cmbQuest.SelectedIndex;
		}
		
		public void NudLevel_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Level = (int) nudLevel.Value;
		}
		
		public void NudDamage_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Damage = (int) nudDamage.Value;
		}
		
		public void CmbSpawnPeriod_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].SpawnTime = (byte) cmbSpawnPeriod.SelectedIndex;
		}
		
#endregion
		
#region Stats
		
		public void NudStrength_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Stat[(int)Enums.StatType.Strength] = (byte)nudStrength.Value;
		}
		
		public void NudEndurance_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Stat[(int)Enums.StatType.Endurance] = (byte)nudEndurance.Value;
		}
		
		public void NudVitality_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Stat[(int)Enums.StatType.Vitality] = (byte)nudVitality.Value;
		}
		
		public void NudLuck_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Stat[(int)Enums.StatType.Luck] = (byte)nudLuck.Value;
		}
		
		public void NudIntelligence_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Stat[(int)Enums.StatType.Intelligence] = (byte)nudIntelligence.Value;
		}
		
		public void NudSpirit_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Stat[(int)Enums.StatType.Spirit] = (byte)nudSpirit.Value;
		}
		
#endregion
		
#region Drop Items
		
		public void CmbDropSlot_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			cmbItem.SelectedIndex = Types.Npc[E_Globals.Editorindex].DropItem[cmbDropSlot.SelectedIndex + 1];
			
			nudAmount.Value = Types.Npc[E_Globals.Editorindex].DropItemValue[cmbDropSlot.SelectedIndex + 1];
			
			nudChance.Value = Types.Npc[E_Globals.Editorindex].DropChance[cmbDropSlot.SelectedIndex + 1];
		}
		
		public void CmbItem_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].DropItem[cmbDropSlot.SelectedIndex + 1] = (byte)cmbItem.SelectedIndex;
		}
		
		public void ScrlValue_Scroll(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].DropItemValue[cmbDropSlot.SelectedIndex + 1] = (int)nudAmount.Value;
		}
		
		public void NudChance_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].DropChance[cmbDropSlot.SelectedIndex + 1] = (int)nudChance.Value;
		}
		
#endregion
		
#region Skills
		
		public void CmbSkill1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Skill[1] = (byte)cmbSkill1.SelectedIndex;
		}
		
		public void CmbSkill2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Skill[2] = (byte)cmbSkill2.SelectedIndex;
		}
		
		public void CmbSkill3_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Skill[3] = (byte)cmbSkill3.SelectedIndex;
		}
		
		public void CmbSkill4_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Skill[4] = (byte)cmbSkill4.SelectedIndex;
		}
		
		public void CmbSkill5_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Skill[5] = (byte)cmbSkill5.SelectedIndex;
		}
		
		public void CmbSkill6_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			Types.Npc[E_Globals.Editorindex].Skill[6] = (byte)cmbSkill6.SelectedIndex;
		}

        #endregion
    }
}
