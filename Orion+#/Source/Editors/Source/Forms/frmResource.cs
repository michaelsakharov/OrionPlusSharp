
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
	partial class FrmResource
	{
		public FrmResource()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmResource defaultInstance;
		
		public static FrmResource Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmResource();
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
		
		public void ScrlNormalPic_Scroll(object sender, EventArgs e)
		{
			E_Graphics.EditorResource_DrawSprite();
			Types.Resource[E_Globals.Editorindex].ResourceImage = (int) nudNormalPic.Value;
		}
		
		public void CmbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			Types.Resource[E_Globals.Editorindex].ResourceType = cmbType.SelectedIndex;
		}
		
		public void ScrlExhaustedPic_Scroll(object sender, EventArgs e)
		{
			E_Graphics.EditorResource_DrawSprite();
			Types.Resource[E_Globals.Editorindex].ExhaustedImage = (int) nudExhaustedPic.Value;
		}
		
		public void ScrlRewardItem_Scroll(object sender, EventArgs e)
		{
			Types.Resource[E_Globals.Editorindex].ItemReward = cmbRewardItem.SelectedIndex;
		}
		
		public void ScrlRewardExp_Scroll(object sender, EventArgs e)
		{
			Types.Resource[E_Globals.Editorindex].ExpReward = (int) nudRewardExp.Value;
		}
		
		public void ScrlLvlReq_Scroll(object sender, EventArgs e)
		{
			Types.Resource[E_Globals.Editorindex].LvlRequired = (int) nudLvlReq.Value;
		}
		
		public void CmbTool_SelectedIndexChanged(object sender, EventArgs e)
		{
			
			Types.Resource[E_Globals.Editorindex].ToolRequired = cmbTool.SelectedIndex;
		}
		
		public void ScrlHealth_Scroll(object sender, EventArgs e)
		{
			Types.Resource[E_Globals.Editorindex].Health = (int) nudHealth.Value;
		}
		
		public void ScrlRespawn_Scroll(object sender, EventArgs e)
		{
			Types.Resource[E_Globals.Editorindex].RespawnTime = (int) nudRespawn.Value;
		}
		
		public void ScrlAnim_Scroll(object sender, EventArgs e)
		{
			Types.Resource[E_Globals.Editorindex].Animation = cmbAnimation.SelectedIndex;
		}
		
		public void LstIndex_Click(object sender, EventArgs e)
		{
			E_Editors.ResourceEditorInit();
		}
		
		public void BtnSave_Click(object sender, EventArgs e)
		{
			E_Editors.ResourceEditorOk();
		}
		
		public void BtnDelete_Click(object sender, EventArgs e)
		{
			int tmpindex = 0;
			
			ClientDataBase.ClearResource(E_Globals.Editorindex);
			
			tmpindex = lstIndex.SelectedIndex;
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Resource[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
			
			E_Editors.ResourceEditorInit();
		}
		
		public void BtnCancel_Click(object sender, EventArgs e)
		{
			E_Editors.ResourceEditorCancel();
		}
		
		public void FrmEditor_Resource_Load(object sender, EventArgs e)
		{
			
		}
		
		public void TxtName_TextChanged(object sender, EventArgs e)
		{
			int tmpindex = 0;
			
			if (E_Globals.Editorindex == 0)
			{
				return;
			}
			tmpindex = lstIndex.SelectedIndex;
			Types.Resource[E_Globals.Editorindex].Name = txtName.Text.Trim();
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Resource[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
		}
		
		public void TxtMessage_TextChanged(object sender, EventArgs e)
		{
			Types.Resource[E_Globals.Editorindex].SuccessMessage = txtMessage.Text.Trim();
		}
		
		public void TxtMessage2_TextChanged(object sender, EventArgs e)
		{
			Types.Resource[E_Globals.Editorindex].EmptyMessage = txtMessage2.Text.Trim();
		}
		
	}
}
