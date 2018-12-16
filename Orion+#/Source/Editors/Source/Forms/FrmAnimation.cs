
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
	partial class FrmAnimation
	{
		public FrmAnimation()
		{
			InitializeComponent();
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmAnimation defaultInstance;
		
		public static FrmAnimation Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmAnimation();
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
		
		public void NudSprite0_ValueChanged(object sender, EventArgs e)
		{
			Types.Animation[E_Globals.Editorindex].Sprite[0] = (int)nudSprite0.Value;
		}
		
		public void NudSprite1_ValueChanged(object sender, EventArgs e)
		{
			Types.Animation[E_Globals.Editorindex].Sprite[1] = (int)nudSprite1.Value;
		}
		
		public void NudLoopCount0_ValueChanged(object sender, EventArgs e)
		{
			Types.Animation[E_Globals.Editorindex].LoopCount[0] = (int)nudLoopCount0.Value;
		}
		
		public void NudLoopCount1_ValueChanged(object sender, EventArgs e)
		{
			Types.Animation[E_Globals.Editorindex].LoopCount[1] = (int)nudLoopCount1.Value;
		}
		
		public void NudFrameCount0_ValueChanged(object sender, EventArgs e)
		{
			Types.Animation[E_Globals.Editorindex].Frames[0] = (int)nudFrameCount0.Value;
		}
		
		public void NudFrameCount1_ValueChanged(object sender, EventArgs e)
		{
			Types.Animation[E_Globals.Editorindex].Frames[1] = (int)nudFrameCount1.Value;
		}
		
		public void NudLoopTime0_ValueChanged(object sender, EventArgs e)
		{
			Types.Animation[E_Globals.Editorindex].LoopTime[0] = (int)nudLoopTime0.Value;
		}
		
		public void NudLoopTime1_ValueChanged(object sender, EventArgs e)
		{
			Types.Animation[E_Globals.Editorindex].LoopTime[1] = (int)nudLoopTime1.Value;
		}
		
		public void BtnSave_Click(object sender, EventArgs e)
		{
			E_Editors.AnimationEditorOk();
		}
		
		public void TxtName_TextChanged(object sender, EventArgs e)
		{
			int tmpindex = 0;
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ANIMATIONS)
			{
				return;
			}
			tmpindex = lstIndex.SelectedIndex;
			Types.Animation[E_Globals.Editorindex].Name = txtName.Text.Trim();
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Animation[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
		}
		
		public void LstIndex_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			E_Editors.AnimationEditorInit();
		}
		
		public void BtnDelete_Click(object sender, EventArgs e)
		{
			int tmpindex = 0;
			
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ANIMATIONS)
			{
				return;
			}
			
			ClientDataBase.ClearAnimation(E_Globals.Editorindex);
			
			tmpindex = lstIndex.SelectedIndex;
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Animation[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
			
			E_Editors.AnimationEditorInit();
		}
		
		public void BtnCancel_Click(object sender, EventArgs e)
		{
			E_Editors.AnimationEditorCancel();
		}
		
		public void FrmEditor_Animation_Load(object sender, EventArgs e)
		{
			nudSprite0.Maximum = E_Graphics.NumAnimations;
			nudSprite1.Maximum = E_Graphics.NumAnimations;
		}
		
		public void CmbSound_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ANIMATIONS)
			{
				return;
			}
			
			Types.Animation[E_Globals.Editorindex].Sound = cmbSound.SelectedItem.ToString();
		}
		
	}
}
