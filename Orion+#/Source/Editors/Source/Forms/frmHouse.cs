
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
	partial class FrmHouse
	{
		public FrmHouse()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmHouse defaultInstance;
		
		public static FrmHouse Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmHouse();
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
		
		public void LstIndex_Click(object sender, EventArgs e)
		{
			E_Housing.HouseEditorInit();
		}
		
		public void TxtName_TextChanged(object sender, EventArgs e)
		{
			int tmpindex = 0;
			
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			tmpindex = lstIndex.SelectedIndex;
			E_Housing.House[E_Globals.Editorindex].ConfigName = txtName.Text.Trim();
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + E_Housing.House[E_Globals.Editorindex].ConfigName);
			lstIndex.SelectedIndex = tmpindex;
			
		}
		
		public void NudBaseMap_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			if (nudBaseMap.Value < 1 || nudBaseMap.Value > Constants.MAX_MAPS)
			{
				return;
			}
			E_Housing.House[E_Globals.Editorindex].BaseMap = (int) nudBaseMap.Value;
		}
		
		public void NudX_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			if (nudX.Value < 0 || nudX.Value > 255)
			{
				return;
			}
			E_Housing.House[E_Globals.Editorindex].X = (int) nudX.Value;
			
		}
		
		public void NudY_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			if (nudY.Value < 0 || nudY.Value > 255)
			{
				return;
			}
			E_Housing.House[E_Globals.Editorindex].Y = (int) nudY.Value;
			
		}
		
		public void NudPrice_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			E_Housing.House[E_Globals.Editorindex].Price = (int) nudPrice.Value;
			
		}
		
		public void NudFurniture_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0)
			{
				return;
			}
			
			if (nudFurniture.Value < 0)
			{
				return;
			}
			E_Housing.House[E_Globals.Editorindex].MaxFurniture = (int) nudFurniture.Value;
		}
		
		public void BtnSave_Click(object sender, EventArgs e)
		{
			if (txtName.Text.Trim().Length == 0)
			{
				MessageBox.Show("Name required.");
				return;
			}
			
			if (nudBaseMap.Value == 0)
			{
				MessageBox.Show("Base map required.");
				return;
			}
			
			E_Housing.HouseEditorOk();
		}
		
		public void BtnCancel_Click(object sender, EventArgs e)
		{
			E_Housing.HouseEditorCancel();
		}

        private void FrmHouse_Load(object sender, EventArgs e)
        {
            E_Housing.HouseEditorInit();
        }
    }
}
