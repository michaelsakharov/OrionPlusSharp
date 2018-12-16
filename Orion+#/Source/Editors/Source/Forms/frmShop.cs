
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
	
	partial class frmShop
	{
		public frmShop()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmShop defaultInstance;
		
		public static frmShop Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmShop();
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
			Types.Shop[E_Globals.Editorindex].Name = txtName.Text.Trim();
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Shop[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
		}
		
		public void ScrlBuy_Scroll(object sender, EventArgs e)
		{
			Types.Shop[E_Globals.Editorindex].BuyRate = (int) nudBuy.Value;
		}
		
		public void BtnUpdate_Click(object sender, EventArgs e)
		{
			int index = 0;
			index = lstTradeItem.SelectedIndex + 1;
			if (index == 0)
			{
				return;
			}
            Types.Shop[E_Globals.Editorindex].TradeItem[index].Item = cmbItem.SelectedIndex;
            Types.Shop[E_Globals.Editorindex].TradeItem[index].ItemValue = (int) nudItemValue.Value;
            Types.Shop[E_Globals.Editorindex].TradeItem[index].CostItem = cmbCostItem.SelectedIndex;
            Types.Shop[E_Globals.Editorindex].TradeItem[index].CostValue = (int) nudCostValue.Value;
			E_Editors.UpdateShopTrade();
		}
		
		public void BtnDeleteTrade_Click(object sender, EventArgs e)
		{
			int index = 0;
			index = lstTradeItem.SelectedIndex + 1;
			if (index == 0)
			{
				return;
			}
            Types.Shop[E_Globals.Editorindex].TradeItem[index].Item = 0;
            Types.Shop[E_Globals.Editorindex].TradeItem[index].ItemValue = 0;
            Types.Shop[E_Globals.Editorindex].TradeItem[index].CostItem = 0;
            Types.Shop[E_Globals.Editorindex].TradeItem[index].CostValue = 0;
			E_Editors.UpdateShopTrade();
		}
		
		public void LstIndex_Click(object sender, EventArgs e)
		{
			E_Editors.ShopEditorInit();
		}
		
		public void BtnSave_Click(object sender, EventArgs e)
		{
			if (txtName.Text.Trim().Length == 0)
			{
				MessageBox.Show("Name required.");
			}
			else
			{
				E_Editors.ShopEditorOk();
			}
		}
		
		public void BtnCancel_Click(object sender, EventArgs e)
		{
			E_Editors.ShopEditorCancel();
		}
		
		public void BtnDelete_Click(object sender, EventArgs e)
		{
			int tmpindex = 0;
			
			ClientDataBase.ClearShop(E_Globals.Editorindex);
			
			tmpindex = lstIndex.SelectedIndex;
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Shop[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
			
			E_Editors.ShopEditorInit();
		}
		
		public void ScrlFace_Scroll(object sender, EventArgs e)
		{
			
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Faces\\" + System.Convert.ToString(nudFace.Value) + E_Globals.GFX_EXT))
			{
				this.picFace.BackgroundImage = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "Faces\\" + System.Convert.ToString(nudFace.Value) + E_Globals.GFX_EXT);
			}
			
			Types.Shop[E_Globals.Editorindex].Face = (byte) nudFace.Value;
		}
		
	}
}
