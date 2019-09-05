
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
using Microsoft.VisualBasic.CompilerServices;
using Engine;

namespace Engine
{
	
	partial class frmClasses
	{
		public frmClasses()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmClasses defaultInstance;
		
		public static frmClasses Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmClasses();
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
		
#region Frm Controls
		
		public void FrmEditor_Classes_Load(object sender, EventArgs e)
		{
			nudMaleSprite.Maximum = E_Graphics.NumCharacters;
			nudFemaleSprite.Maximum = E_Graphics.NumCharacters;

            E_Editors.ClassEditorInit();

            DrawPreview();
		}
		
		public void LstIndex_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstIndex.SelectedIndex < 0)
			{
                DarkGroupBox2.Hide();
				return;
			}
            DarkGroupBox2.Show();

            E_Globals.Editorindex = lstIndex.SelectedIndex + 1;
			
			E_Globals.LoadClassInfo = true;
		}
		
		public void BtnAddClass_Click(object sender, EventArgs e)
		{
			E_Globals.Max_Classes++;
			
			Array.Resize(ref Types.Classes, E_Globals.Max_Classes + 1);
			
			Types.Classes[E_Globals.Max_Classes].Name = "New Class";
			
			Types.Classes[E_Globals.Max_Classes].Stat = new byte[(int) Enums.StatType.Count];
			
			Types.Classes[E_Globals.Max_Classes].Vital = new int[(int) Enums.VitalType.Count];
			
			Types.Classes[E_Globals.Max_Classes].MaleSprite = new int[2];
			Types.Classes[E_Globals.Max_Classes].FemaleSprite = new int[2];
			
			for (var i = 1; i <= (int) Enums.StatType.Count - 1; i++)
			{
				Types.Classes[E_Globals.Max_Classes].Stat[(int) i] = 1;
			}
			
			Types.Classes[E_Globals.Max_Classes].StartItem = new int[6];
			Types.Classes[E_Globals.Max_Classes].StartValue = new int[6];
			
			Types.Classes[E_Globals.Max_Classes].StartMap = 1;
			Types.Classes[E_Globals.Max_Classes].StartX = (byte) 1;
			Types.Classes[E_Globals.Max_Classes].StartY = (byte) 1;
			
			E_Editors.ClassEditorInit();

            lstIndex.SelectedIndex = lstIndex.Items.Count - 1;
		}
		
		public void BtnRemoveClass_Click(object sender, EventArgs e)
		{
			int i = 0;
			
            if(E_Globals.Max_Classes == 0)
            {
                return;
            }

			//If its The Last class, its simple, just remove and redim
			if (E_Globals.Editorindex == E_Globals.Max_Classes)
			{
				E_Globals.Max_Classes--;
				Array.Resize(ref Types.Classes, E_Globals.Max_Classes + 1);
			}
			else
			{
				//but if its somewhere in the middle, or beginning, it gets harder xD
				for (i = 1; i <= E_Globals.Max_Classes; i++)
				{
					//we shift everything thats beneath the selected class, up 1 slot
					Types.Classes[E_Globals.Editorindex] = Types.Classes[E_Globals.Editorindex + 1];
				}
				
				//and then we remove it, and redim
				E_Globals.Max_Classes--;
				Array.Resize(ref Types.Classes, E_Globals.Max_Classes + 1);
			}
			
			E_Editors.ClassEditorInit();
		}
		
		public void BtnSave_Click(object sender, EventArgs e)
		{
			E_Editors.ClassesEditorOk();
		}
		
		public void BtnCancel_Click(object sender, EventArgs e)
		{
			E_Editors.ClassesEditorCancel();
		}
		
		public void TxtDescription_TextChanged(object sender, EventArgs e)
		{
			Types.Classes[E_Globals.Editorindex].Desc = txtDescription.Text;
		}
		
		public void TxtName_TextChanged(object sender, EventArgs e)
		{
			int tmpindex = 0;
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			tmpindex = lstIndex.SelectedIndex;
			Types.Classes[E_Globals.Editorindex].Name = txtName.Text.Trim();
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, Types.Classes[E_Globals.Editorindex].Name.Trim());
			lstIndex.SelectedIndex = tmpindex;
		}
		
#endregion
		
#region Sprites
		
		public void BtnAddMaleSprite_Click(object sender, EventArgs e)
		{
			byte tmpamount = 0;
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			tmpamount = (byte) (Types.Classes[E_Globals.Editorindex].MaleSprite.Length - 1);
			
			Array.Resize(ref Types.Classes[E_Globals.Editorindex].MaleSprite, tmpamount + 1 + 1);
			
			Types.Classes[E_Globals.Editorindex].MaleSprite[tmpamount + 1] = 1;
			
			E_Globals.LoadClassInfo = true;
		}
		
		public void BtnDeleteMaleSprite_Click(object sender, EventArgs e)
		{
			byte tmpamount = 0;
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			tmpamount = (byte) (Types.Classes[E_Globals.Editorindex].MaleSprite.Length - 1);
			
			Array.Resize(ref Types.Classes[E_Globals.Editorindex].MaleSprite, tmpamount);
			
			E_Globals.LoadClassInfo = true;
		}
		
		public void BtnAddFemaleSprite_Click(object sender, EventArgs e)
		{
			byte tmpamount = 0;
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			tmpamount = (byte) (Types.Classes[E_Globals.Editorindex].FemaleSprite.Length - 1);
			
			Array.Resize(ref Types.Classes[E_Globals.Editorindex].FemaleSprite, tmpamount + 1 + 1);
			
			Types.Classes[E_Globals.Editorindex].FemaleSprite[tmpamount + 1] = 1;
			
			E_Globals.LoadClassInfo = true;
		}
		
		public void BtnDeleteFemaleSprite_Click(object sender, EventArgs e)
		{
			byte tmpamount = 0;
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			tmpamount = (byte) (Types.Classes[E_Globals.Editorindex].FemaleSprite.Length - 1);
			
			Array.Resize(ref Types.Classes[E_Globals.Editorindex].FemaleSprite, tmpamount);
			
			E_Globals.LoadClassInfo = true;
		}
		
		public void NudMaleSprite_ValueChanged(object sender, EventArgs e)
		{
			if (cmbMaleSprite.SelectedIndex < 0)
			{
				return;
			}
			
			Types.Classes[E_Globals.Editorindex].MaleSprite[cmbMaleSprite.SelectedIndex] = (int)nudMaleSprite.Value;
			
			DrawPreview();
		}
		
		public void NudFemaleSprite_ValueChanged(object sender, EventArgs e)
		{
			if (cmbFemaleSprite.SelectedIndex < 0)
			{
				return;
			}
			
			Types.Classes[E_Globals.Editorindex].FemaleSprite[cmbFemaleSprite.SelectedIndex] = (int)nudFemaleSprite.Value;
			
			DrawPreview();
		}
		
		public void CmbMaleSprite_SelectedIndexChanged(object sender, EventArgs e)
		{
			nudMaleSprite.Value = System.Convert.ToDecimal(Types.Classes[E_Globals.Editorindex].MaleSprite[cmbMaleSprite.SelectedIndex]);
			DrawPreview();
		}
		
		public void CmbFemaleSprite_SelectedIndexChanged(object sender, EventArgs e)
		{
			nudFemaleSprite.Value = System.Convert.ToDecimal(Types.Classes[E_Globals.Editorindex].FemaleSprite[cmbFemaleSprite.SelectedIndex]);
			DrawPreview();
		}
		
		public void DrawPreview()
		{
			
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Characters\\" + System.Convert.ToString(nudMaleSprite.Value) + E_Globals.GFX_EXT))
			{
				picMale.Width = System.Convert.ToInt32(Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "characters\\" + System.Convert.ToString(nudMaleSprite.Value) + E_Globals.GFX_EXT).Width / 4);
				picMale.Height = System.Convert.ToInt32(Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "characters\\" + System.Convert.ToString(nudMaleSprite.Value) + E_Globals.GFX_EXT).Height / 4);
				picMale.BackgroundImage = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "Characters\\" + System.Convert.ToString(nudMaleSprite.Value) + E_Globals.GFX_EXT);
			}
			
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Characters\\" + System.Convert.ToString(nudFemaleSprite.Value) + E_Globals.GFX_EXT))
			{
				picFemale.Width = System.Convert.ToInt32(Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "characters\\" + System.Convert.ToString(nudFemaleSprite.Value) + E_Globals.GFX_EXT).Width / 4);
				picFemale.Height = System.Convert.ToInt32(Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "characters\\" + System.Convert.ToString(nudFemaleSprite.Value) + E_Globals.GFX_EXT).Height / 4);
				picFemale.BackgroundImage = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "Characters\\" + System.Convert.ToString(nudFemaleSprite.Value) + E_Globals.GFX_EXT);
			}
			
		}
		
		public void PicMale_Paint(object sender, EventArgs e)
		{
			//nope
		}
		
		public void PicFemale_Paint(object sender, EventArgs e)
		{
			//nope
		}
		
#endregion
		
#region Stats
		
		public void NumStrength_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			Types.Classes[E_Globals.Editorindex].Stat[(int)Enums.StatType.Strength] = (byte)nudStrength.Value;
		}
		
		public void NumLuck_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			Types.Classes[E_Globals.Editorindex].Stat[(int)Enums.StatType.Luck] = (byte)nudLuck.Value;
		}
		
		public void NumEndurance_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Endurance] = (byte)nudEndurance.Value;
		}
		
		public void NumIntelligence_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Intelligence] = (byte)nudIntelligence.Value;
		}
		
		public void NumVitality_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Vitality] = (byte)nudVitality.Value;
		}
		
		public void NumSpirit_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Spirit] = (byte)nudSpirit.Value;
		}
		
		public void NumBaseExp_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			Types.Classes[E_Globals.Editorindex].BaseExp = (int) nudBaseExp.Value;
		}
		
#endregion
		
#region Start Items
		
		public void BtnItemAdd_Click(object sender, EventArgs e)
		{
			if (lstStartItems.SelectedIndex < 0 || cmbItems.SelectedIndex < 0)
			{
				return;
			}
			
			Types.Classes[E_Globals.Editorindex].StartItem[lstStartItems.SelectedIndex + 1] = cmbItems.SelectedIndex;
			Types.Classes[E_Globals.Editorindex].StartValue[lstStartItems.SelectedIndex + 1] = (byte)nudItemAmount.Value;
			
			E_Globals.LoadClassInfo = true;
		}
		
#endregion
		
#region Starting Point
		
		public void NumStartMap_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			Types.Classes[E_Globals.Editorindex].StartMap = (int) nudStartMap.Value;
		}
		
		public void NumStartX_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			Types.Classes[E_Globals.Editorindex].StartX = (byte) nudStartX.Value;
		}
		
		public void NumStartY_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
			{
				return;
			}
			
			Types.Classes[E_Globals.Editorindex].StartY = (byte) nudStartY.Value;
		}
		
#endregion
		
	}
}
