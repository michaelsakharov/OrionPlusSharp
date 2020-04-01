
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
	partial class frmProjectile
	{
		public frmProjectile()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static frmProjectile defaultInstance;
		
		public static frmProjectile Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new frmProjectile();
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
		
		public void FrmEditor_Projectile_Load(object sender, EventArgs e)
		{
			nudPic.Maximum = E_Projectiles.NumProjectiles;
            E_Projectiles.ProjectileEditorInit();

        }
		
		public void LstIndex_Click(object sender, EventArgs e)
		{
			E_Projectiles.ProjectileEditorInit();
		}
		
		public void BtnSave_Click(object sender, EventArgs e)
		{
			E_Projectiles.ProjectileEditorOk();
		}
		
		public void BtnCancel_Click(object sender, EventArgs e)
		{
			E_Projectiles.ProjectileEditorCancel();
		}
		
		public void TxtName_TextChanged(System.Object sender, EventArgs e)
		{
			int tmpindex = 0;
			
			if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
			{
				return;
			}
			
			tmpindex = lstIndex.SelectedIndex;
			E_Projectiles.Projectiles[E_Globals.Editorindex].Name = txtName.Text.Trim();
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + E_Projectiles.Projectiles[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
		}
		
		public void NudPic_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
			{
				return;
			}
			
			E_Projectiles.Projectiles[E_Globals.Editorindex].Sprite = (int) nudPic.Value;
		}
		
		public void NudRange_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
			{
				return;
			}
			
			E_Projectiles.Projectiles[E_Globals.Editorindex].Range = (byte) nudRange.Value;
		}
		
		public void NudSpeed_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
			{
				return;
			}
			
			E_Projectiles.Projectiles[E_Globals.Editorindex].Speed = (int) nudSpeed.Value;
		}
		
		public void NudDamage_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
			{
				return;
			}
			
			E_Projectiles.Projectiles[E_Globals.Editorindex].Damage = (int) nudDamage.Value;
		}

        // projectile Logic
        // On Instatiate
        private void darkTextBox2_TextChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
            {
                return;
            }

            E_Projectiles.Projectiles[E_Globals.Editorindex].OnInstantiate = darkTextBox2.Text;
        }

        // On Update
        private void darkTextBox3_TextChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
            {
                return;
            }

            E_Projectiles.Projectiles[E_Globals.Editorindex].OnInstantiate = darkTextBox3.Text;
        }

        // On Hit Wall
        private void darkTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
            {
                return;
            }

            E_Projectiles.Projectiles[E_Globals.Editorindex].OnInstantiate = darkTextBox1.Text;
        }

        // On Hit Entity
        private void darkTextBox4_TextChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex < 1 || E_Globals.Editorindex > E_Projectiles.MAX_PROJECTILES)
            {
                return;
            }

            E_Projectiles.Projectiles[E_Globals.Editorindex].OnInstantiate = darkTextBox4.Text;
        }
    }
}
