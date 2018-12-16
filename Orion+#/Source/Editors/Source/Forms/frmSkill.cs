
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
	partial class frmSkill
	{
		public frmSkill()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmSkill defaultInstance;
		
		public static frmSkill Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmSkill();
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
		
		public void TxtName_TextChanged(object sender, EventArgs e)
		{
			int tmpindex = 0;
			
			if (E_Globals.Editorindex == 0)
			{
				return;
			}
			tmpindex = lstIndex.SelectedIndex;
			Types.Skill[E_Globals.Editorindex].Name = txtName.Text.Trim();
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Skill[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
		}
		
		public void CmbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].Type = (byte) cmbType.SelectedIndex;
		}
		
		public void NudMp_ValueChanged(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].MpCost = (int) nudMp.Value;
		}
		
		public void NudLevel_ValueChanged(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].LevelReq = (int) nudLevel.Value;
		}
		
		public void CmbAccessReq_SelectedIndexChanged(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].AccessReq = cmbAccessReq.SelectedIndex;
		}
		
		public void CmbClass_SelectedIndexChanged(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].ClassReq = cmbClass.SelectedIndex;
		}
		
		public void NudCast_Scroll(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].CastTime = (int) nudCast.Value;
		}
		
		public void NudCool_Scroll(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].CdTime = (int) nudCool.Value;
		}
		
		public void NudIcon_Scroll(object sender, EventArgs e)
		{
			
			Types.Skill[E_Globals.Editorindex].Icon = (int) nudIcon.Value;
			E_Graphics.EditorSkill_BltIcon();
		}
		
		public void NudMap_Scroll(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].Map = (int) nudMap.Value;
		}
		
		public void CmbDir_SelectedIndexChanged(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].Dir = (byte) cmbDir.SelectedIndex;
		}
		
		public void NudX_Scroll(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].X = (int) nudX.Value;
		}
		
		public void NudY_Scroll(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].Y = (int) nudY.Value;
		}
		
		public void NudVital_Scroll(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].Vital = (int) nudVital.Value;
		}
		
		public void NudDuration_Scroll(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].Duration = (int) nudDuration.Value;
		}
		
		public void NudInterval_Scroll(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].Interval = (int) nudInterval.Value;
		}
		
		public void NudRange_Scroll(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].Range = (int) nudRange.Value;
		}
		
		public void ChkAOE_CheckedChanged(object sender, EventArgs e)
		{
			if (chkAoE.Checked == false)
			{
				Types.Skill[E_Globals.Editorindex].IsAoE = false;
			}
			else
			{
				Types.Skill[E_Globals.Editorindex].IsAoE = true;
			}
		}
		
		public void NudAoE_Scroll(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].AoE = (int) nudAoE.Value;
		}
		
		public void CmbAnimCast_Scroll(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].CastAnim = cmbAnimCast.SelectedIndex;
		}
		
		public void CmbAnim_Scroll(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].SkillAnim = cmbAnim.SelectedIndex;
		}
		
		public void NudStun_Scroll(object sender, EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].StunDuration = (int) nudStun.Value;
		}
		
		public void LstIndex_Click(object sender, EventArgs e)
		{
			E_Editors.SkillEditorInit();
		}
		
		public void BtnSave_Click(object sender, EventArgs e)
		{
			E_Editors.SkillEditorOk();
		}
		
		public void BtnDelete_Click(object sender, EventArgs e)
		{
			int tmpindex = 0;
			
			ClientDataBase.ClearSkill(E_Globals.Editorindex);
			
			tmpindex = lstIndex.SelectedIndex;
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Skill[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
			
			E_Editors.SkillEditorInit();
		}
		
		public void BtnCancel_Click(object sender, EventArgs e)
		{
			E_Editors.SkillEditorCancel();
		}
		
		public void FrmEditor_Skill_Load(object sender, EventArgs e)
		{
			nudIcon.Maximum = E_Graphics.NumSkillIcons;
			nudCast.Value = 1;
		}
		
		public void ChkProjectile_CheckedChanged(object sender, EventArgs e)
		{
			if (chkProjectile.Checked == false)
			{
				Types.Skill[E_Globals.Editorindex].IsProjectile = 0;
			}
			else
			{
				Types.Skill[E_Globals.Editorindex].IsProjectile = 1;
			}
		}
		
		public void ScrlProjectile_Scroll(System.Object sender, System.EventArgs e)
		{
			Types.Skill[E_Globals.Editorindex].Projectile = cmbProjectile.SelectedIndex;
		}
		
		public void ChkKnockBack_CheckedChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_SKILLS)
			{
				return;
			}
			
			if (chkKnockBack.Checked == true)
			{
				Types.Skill[E_Globals.Editorindex].KnockBack = (byte) 1;
			}
			else
			{
				Types.Skill[E_Globals.Editorindex].KnockBack = (byte) 0;
			}
		}
		
		public void CmbKnockBackTiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_SKILLS)
			{
				return;
			}
			
			Types.Skill[E_Globals.Editorindex].KnockBackTiles = (byte) cmbKnockBackTiles.SelectedIndex;
		}
		
	}
}
