
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
	partial class FrmRecipe
	{
		public FrmRecipe()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmRecipe defaultInstance;
		
		public static FrmRecipe Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmRecipe();
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
		
		public void BtnSave_Click(object sender, EventArgs e)
		{
			E_Crafting.RecipeEditorOk();
		}
		
		public void BtnCancel_Click(object sender, EventArgs e)
		{
			E_Crafting.RecipeEditorCancel();
		}
		
		public void BtnDelete_Click(object sender, EventArgs e)
		{
			int tmpindex = 0;
			
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_RECIPE)
			{
				return;
			}
			
			E_Crafting.ClearRecipe(E_Globals.Editorindex);
			
			tmpindex = lstIndex.SelectedIndex;
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + E_Crafting.Recipe[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
			
			lstIngredients.Items.Clear();
			
			E_Crafting.RecipeEditorInit();
		}
		
		public void TxtName_TextChanged(object sender, EventArgs e)
		{
			int tmpindex = 0;
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_RECIPE)
			{
				return;
			}
			tmpindex = lstIndex.SelectedIndex;
			E_Crafting.Recipe[E_Globals.Editorindex].Name = txtName.Text.Trim();
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + E_Crafting.Recipe[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
		}
		
		public void LstIndex_Click(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_RECIPE)
			{
				return;
			}
			E_Crafting.RecipeEditorInit();
		}
		
		public void BtnIngredientAdd_Click(object sender, EventArgs e)
		{
			if (lstIngredients.SelectedIndex < 0 || cmbIngredient.SelectedIndex == 0)
			{
				return;
			}
			
			E_Crafting.Recipe[E_Globals.Editorindex].Ingredients[lstIngredients.SelectedIndex + 1].ItemNum = cmbIngredient.SelectedIndex;
			E_Crafting.Recipe[E_Globals.Editorindex].Ingredients[lstIngredients.SelectedIndex + 1].Value = (int) numItemAmount.Value;
			
			E_Crafting.UpdateIngredient();
			
		}
		
		public void CmbMakeItem_SelectedIndexChanged(object sender, EventArgs e)
		{
			E_Crafting.Recipe[E_Globals.Editorindex].MakeItemNum = cmbMakeItem.SelectedIndex;
		}
		
		public void CmbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			E_Crafting.Recipe[E_Globals.Editorindex].RecipeType = (byte) cmbType.SelectedIndex;
		}
		
		public void NudAmount_ValueChanged(object sender, EventArgs e)
		{
			E_Crafting.Recipe[E_Globals.Editorindex].MakeItemAmount = (int) nudAmount.Value;
		}
		
		public void NudCreateTime_ValueChanged(object sender, EventArgs e)
		{
			E_Crafting.Recipe[E_Globals.Editorindex].CreateTime = (byte) nudCreateTime.Value;
		}

        private void FrmRecipe_Load(object sender, EventArgs e)
        {
            E_Crafting.RecipeEditorInit();
        }
    }
}
