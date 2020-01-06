
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
            ResetAllEmitters();
            emitterListBox.Items.Add("Emitter " + emitterListBox.Items.Count);
            frmProjectile.Default.emitterTypeComboBox.SelectedIndex = 0; // Reset to Linear
                    E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters.Add(new LinearEmitter() { emitterName = "Emitter " + emitterListBox.Items.Count });
            emitterListBox.SelectedIndex = emitterListBox.Items.Count - 1;
            //UpdateEmitterUI();
        }

        private void picProjectilePreview_Paint(object sender, PaintEventArgs e)
        {
            // Override Paint, cause we dont want it to Paint
        }

        private void btnDeleteEmitter_Click(object sender, EventArgs e)
        {
            ResetAllEmitters();
            int selectedIndex = emitterListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                emitterListBox.SelectedIndex = selectedIndex - 1;
                emitterListBox.Items.RemoveAt(selectedIndex);
                frmProjectile.Default.emitterTypeComboBox.SelectedIndex = 0; // Reset to Linear
                E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters.RemoveAt(selectedIndex);
                if (emitterListBox.SelectedIndex == -1 && emitterListBox.Items.Count > 0)
                {
                    emitterListBox.SelectedIndex = 0;
                }
            }
            //UpdateEmitterUI();
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
        
        public void UpdateEmitterSettings(object sender, EventArgs e)
        {
            ResetAllEmitters();
            E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].picture = (byte)emitterSpriteNud.Value;
            E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].range = (byte)emitterRangeNud.Value;
            E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].count = (byte)emitterCountNud.Value;
            E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].speed = (byte)emitterBulletSpeedNud.Value;
            E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].yOffset = (int)emitterYOffsetNud.Value;
            E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].xOffset = (int)emitterXOffsetNud.Value;
            E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].rotationOffset = (int)emitterOffsetRotationNud.Value;
            E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].additionalDamage = (byte)darkNumericUpDown1.Value;
            E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].startDelay = (float)darkNumericUpDown2.Value;
            E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].startDelayTimer = 0;
            foreach(ProjectileBullet proj in E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].projectiles)
            {
                if(PreviewDirectionDropdown.SelectedIndex == -1)
                {
                    proj.dir = 0;
                    continue;
                }
                proj.dir = (byte)PreviewDirectionDropdown.SelectedIndex;
            }
        }

        public void ResetAllEmitters()
        {
            for (int i = 0; i < E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters.Count; i++)
            {
                E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[i].ResetEmitter();
            }
        }

        E_Emitter previousEmitter = null;
        public void UpdateEmitterUI(object sender, EventArgs e)
        {
            if (emitterListBox.SelectedIndex != -1)
            {
                if (previousEmitter != E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex])
                {
                    UpdateEmitterUI();
                    previousEmitter = E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex];
                }
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
            if (emitterListBox.SelectedIndex != -1)
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
            if (emitterListBox.SelectedIndex != -1)
            {
                emitterSpriteNud.Value = E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].picture;
                emitterRangeNud.Value = E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].range;
                emitterCountNud.Value = E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].count;
                emitterBulletSpeedNud.Value = E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].speed;
                emitterYOffsetNud.Value = E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].yOffset;
                emitterXOffsetNud.Value = E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].xOffset;
                emitterOffsetRotationNud.Value = E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].rotationOffset;
                darkNumericUpDown1.Value = E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].additionalDamage;
                darkNumericUpDown2.Value = (Decimal)E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[emitterListBox.SelectedIndex].startDelay;
            }

        }

        public void emitterTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEmitterType();
        }

        public void UpdateEmitterType()
        {
            for (int i = 0; i < E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters.Count; i++)
            {

                switch (frmProjectile.Default.emitterTypeComboBox.SelectedText)
                {
                    case "Linear":
                        E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[i] = new LinearEmitter();
                        break;
                    case "Accelerating":
                        E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[i] = new E_Emitter();
                        break;
                    case "Laser Beam":
                        E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[i] = new E_Emitter();
                        break;
                    case "Boomerang":
                        E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[i] = new E_Emitter();
                        break;
                    case "Homing":
                        E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[i] = new E_Emitter();
                        break;
                    case "Re-Direction":
                        E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[i] = new E_Emitter();
                        break;
                    case "Wave":
                        E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[i] = new E_Emitter();
                        break;
                    case "Exploding Bullets":
                        E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[i] = new E_Emitter();
                        break;
                    case "Bouncing":
                        E_Projectiles.Projectiles[E_Globals.Editorindex].Emitters[i] = new E_Emitter();
                        break;
                }
            }
        }

        #endregion
    }
}
