
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using System.IO;
using Engine;

namespace Engine
{
	
	partial class frmPet
	{
		public frmPet()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmPet defaultInstance;
		
		public static frmPet Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmPet();
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
		
#region Basics
		
		public void FrmEditor_Pet_Load(object sender, EventArgs e)
		{
			EditorPet_DrawPet();
			
			nudSprite.Maximum = E_Graphics.NumCharacters;
			nudRange.Maximum = 50;
			nudLevel.Maximum = Constants.MAX_LEVELS;
			nudMaxLevel.Maximum = Constants.MAX_LEVELS;

            E_Pets.PetEditorInit();

        }
		
		public void LstIndex_Click(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			E_Pets.PetEditorInit();
		}
		
		public void TxtName_TextChanged(object sender, EventArgs e)
		{
			int tmpindex = 0;
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			tmpindex = lstIndex.SelectedIndex;
			E_Pets.Pet[E_Globals.Editorindex].Name = txtName.Text.Trim();
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + E_Pets.Pet[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
		}
		
		public void NudSprite_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].Sprite = (int) nudSprite.Value;
			
			EditorPet_DrawPet();
		}
		
		internal void EditorPet_DrawPet()
		{
			int petnum = 0;
			
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			petnum = (int) nudSprite.Value;
			
			if (petnum < 1 || petnum > E_Graphics.NumCharacters)
			{
				picSprite.BackgroundImage = null;
				return;
			}
			
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Characters\\" + System.Convert.ToString(petnum) + E_Globals.GFX_EXT))
			{
				picSprite.BackgroundImage = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "Characters\\" + System.Convert.ToString(petnum) + E_Globals.GFX_EXT);
			}
			
		}
		
		public void NudRange_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].Range = (int) nudRange.Value;
		}
		
		public void BtnSave_Click(object sender, EventArgs e)
		{
			E_Pets.PetEditorOk();
		}
		
		public void BtnCancel_Click(object sender, EventArgs e)
		{
			E_Pets.PetEditorCancel();
		}
		
#endregion
		
#region Stats
		
		public void OptCustomStats_CheckedChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			if (optCustomStats.Checked == true)
			{
				pnlCustomStats.Visible = true;
				E_Pets.Pet[E_Globals.Editorindex].StatType = (byte) 1;
			}
			else
			{
				pnlCustomStats.Visible = false;
				E_Pets.Pet[E_Globals.Editorindex].StatType = (byte) 0;
			}
		}
		
		public void OptAdoptStats_CheckedChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			if (optAdoptStats.Checked == true)
			{
				pnlCustomStats.Visible = false;
				E_Pets.Pet[E_Globals.Editorindex].StatType = (byte) 0;
			}
			else
			{
				pnlCustomStats.Visible = true;
				E_Pets.Pet[E_Globals.Editorindex].StatType = (byte) 1;
			}
		}
		
		public void NudStrength_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Strength] = (byte)nudStrength.Value;
		}
		
		public void NudEndurance_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Endurance] = (byte)nudEndurance.Value;
		}
		
		public void NudVitality_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Vitality] = (byte)nudVitality.Value;
		}
		
		public void NudLuck_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Luck] = (byte)nudLuck.Value;
		}
		
		public void NudIntelligence_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Intelligence] = (byte)nudIntelligence.Value;
		}
		
		public void NudSpirit_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Spirit] = (byte)nudSpirit.Value;
		}
		
		public void NudLevel_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].Level = (int) nudLevel.Value;
		}
		
#endregion
		
#region Leveling
		
		public void NudPetExp_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].ExpGain = (int) nudPetExp.Value;
		}
		
		public void NudPetPnts_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].LevelPnts = (int) nudPetPnts.Value;
		}
		
		public void NudMaxLevel_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].MaxLevel = (int) nudMaxLevel.Value;
		}
		
		public void OptLevel_CheckedChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			if (optLevel.Checked == true)
			{
				pnlPetlevel.Visible = true;
				E_Pets.Pet[E_Globals.Editorindex].LevelingType = (byte) 1;
			}
		}
		
		public void OptDoNotLevel_CheckedChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			if (optDoNotLevel.Checked == true)
			{
				pnlPetlevel.Visible = false;
				E_Pets.Pet[E_Globals.Editorindex].LevelingType = (byte) 0;
			}
		}
		
#endregion
		
#region Skills
		
		public void CmbSkill1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].Skill[1] = cmbSkill1.SelectedIndex;
		}
		
		public void CmbSkill2_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].Skill[2] = cmbSkill2.SelectedIndex;
		}
		
		public void CmbSkill3_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].Skill[3] = cmbSkill3.SelectedIndex;
		}
		
		public void CmbSkill4_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].Skill[4] = cmbSkill4.SelectedIndex;
		}
		
#endregion
		
#region Evolving
		
		public void ChkEvolve_CheckedChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			if (chkEvolve.Checked == true)
			{
				E_Pets.Pet[E_Globals.Editorindex].Evolvable = (byte) 1;
			}
			else
			{
				E_Pets.Pet[E_Globals.Editorindex].Evolvable = (byte) 0;
			}
			
		}
		
		public void NudEvolveLvl_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].EvolveLevel = (int) nudEvolveLvl.Value;
		}
		
		public void CmbEvolve_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_PETS)
			{
				return;
			}
			
			E_Pets.Pet[E_Globals.Editorindex].EvolveNum = cmbEvolve.SelectedIndex;
		}

        #endregion
    }
}
