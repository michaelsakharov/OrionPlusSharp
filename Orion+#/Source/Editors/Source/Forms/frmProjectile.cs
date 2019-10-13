
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
            UpdateEmitterUI();
            E_Graphics.ProjectilePreviewWindow.SetView(new SFML.Graphics.View(new SFML.Graphics.FloatRect(0, 0, picProjectilePreview.Width, picProjectilePreview.Height)));

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

        #region New Projectile Editor Stuff

        private void btnAddEmitter_Click(object sender, EventArgs e)
        {
            emitterListBox.Items.Add("Emitter " + emitterListBox.Items.Count);
            emitterListBox.SelectedIndex = emitterListBox.Items.Count - 1;
            E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters.Add(new E_Emitter());
            UpdateEmitterUI();
        }

        private void picProjectilePreview_Paint(object sender, PaintEventArgs e)
        {
            // Override Paint, cause we dont want it to Paint
        }

        private void btnDeleteEmitter_Click(object sender, EventArgs e)
        {
            int selectedIndex = emitterListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                emitterListBox.SelectedIndex = selectedIndex - 1;
                emitterListBox.Items.RemoveAt(selectedIndex);
                E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters.RemoveAt(selectedIndex);
                if (emitterListBox.SelectedIndex == -1 && emitterListBox.Items.Count > 0)
                {
                    emitterListBox.SelectedIndex = 0;
                }
            }
            UpdateEmitterUI();
        }

        private void emitterNameTextBox_TextChanged(object sender, EventArgs e)
        {
            int tmpindex = emitterListBox.SelectedIndex;
            if (tmpindex != -1)
            {
                E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].emitterName = emitterNameTextBox.Text.Trim();
                emitterListBox.Items.RemoveAt(tmpindex);
                emitterListBox.Items.Insert(tmpindex, emitterNameTextBox.Text.Trim());
                emitterListBox.SelectedIndex = tmpindex;
            }
        }




        public void UpdateEmitterUI()
        {
            if (emitterListBox.SelectedIndex == -1)
            {
                Width = 465;
            }
            else
            {
                Width = 1060;
            }
            if (emitterListBox.SelectedIndex != -1 && E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters.Count > 0)
            {
                emitterNameTextBox.Text = E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].emitterName;
            }
            else
            {
                emitterNameTextBox.Text = "";
            }
            if(emitterListBox.Items.Count > 0)
            {
                nudPic.Enabled = false;
                nudRange.Enabled = false;
                nudSpeed.Enabled = false;
                nudDamage.Enabled = false;
            }
            else
            {
                nudPic.Enabled = true;
                nudRange.Enabled = true;
                nudSpeed.Enabled = true;
                nudDamage.Enabled = true;
            }
        }

        #endregion
    }
}
