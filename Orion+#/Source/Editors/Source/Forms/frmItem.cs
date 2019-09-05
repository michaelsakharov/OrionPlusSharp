
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
	partial class FrmItem
	{
		public FrmItem()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmItem defaultInstance;
		
		public static FrmItem Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmItem();
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
		
#region Form Code
		
		public void BtnSave_Click(object sender, EventArgs e)
		{
			E_Items.ItemEditorOk();
		}
		
		public void BtnCancel_Click(object sender, EventArgs e)
		{
			E_Items.ItemEditorCancel();
		}
		
		public void BtnDelete_Click(object sender, EventArgs e)
		{
			int tmpindex = 0;
			
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			E_Items.ClearItem(E_Globals.Editorindex + 1);
			
			tmpindex = lstIndex.SelectedIndex;
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Item[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
			
			E_Items.ItemEditorInit();
		}
		
		public void LstIndex_Click(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			E_Items.ItemEditorInit();
			PicFurniture_MouseDown(sender, (MouseEventArgs)e);
		}
		
		public void PicItem_Paint(object sender, PaintEventArgs e)
		{
			//Dont let it auto paint ;)
		}
		
		public void PicPaperdoll_Paint(object sender, PaintEventArgs e)
		{
			//Dont let it auto paint :0
		}
		
		public void PicFurniture_Paint(object sender, PaintEventArgs e)
		{
			//Dont let it auto paint ;)
		}
		
		public void FrmEditor_Item_Load(object sender, EventArgs e)
		{
			nudPic.Maximum = E_Graphics.NumItems;
			nudPaperdoll.Maximum = E_Graphics.NumPaperdolls;
			nudFurniture.Maximum = E_Housing.NumFurniture;
			cmbFurnitureType.SelectedIndex = 0;
		}
		
		public void BtnBasics_Click(object sender, EventArgs e)
		{
			fraBasics.Visible = true;
			fraRequirements.Visible = false;
		}
		
		public void BtnRequirements_Click(object sender, EventArgs e)
		{
			fraBasics.Visible = false;
			fraRequirements.Visible = true;
		}
		
#endregion
		
#region Basics
		
		public void NudPic_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Pic = (int) nudPic.Value;
			E_Items.EditorItem_DrawItem();
		}
		
		public void CmbBind_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].BindType = (byte) cmbBind.SelectedIndex;
		}
		
		public void NudRarity_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Rarity = (byte) nudRarity.Value;
		}
		
		public void CmbAnimation_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Animation = cmbAnimation.SelectedIndex;
		}
		
		public void CmbType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			cmbSubType.Enabled = false;
			
			if (cmbType.SelectedIndex == (int) Enums.ItemType.Equipment)
			{
				fraEquipment.Visible = true;
				
				// Build subtype cmb
				cmbSubType.Items.Clear();
				cmbSubType.Items.Add("None");
				
				cmbSubType.Items.Add("Weapon");
				cmbSubType.Items.Add("Armor");
				cmbSubType.Items.Add("Helmet");
				cmbSubType.Items.Add("Shield");
				cmbSubType.Items.Add("Shoes");
				cmbSubType.Items.Add("Gloves");
				
				cmbSubType.Enabled = true;
				cmbSubType.SelectedIndex = Types.Item[E_Globals.Editorindex].SubType;
			}
			else
			{
				fraEquipment.Visible = false;
			}
			
			if (cmbType.SelectedIndex == (int) Enums.ItemType.Consumable)
			{
				fraVitals.Visible = true;
				
				// Build subtype cmb
				cmbSubType.Items.Clear();
				cmbSubType.Items.Add("None");
				
				cmbSubType.Items.Add("Hp");
				cmbSubType.Items.Add("Mp");
				cmbSubType.Items.Add("Sp");
				cmbSubType.Items.Add("Exp");
				
				cmbSubType.Enabled = true;
				cmbSubType.SelectedIndex = Types.Item[E_Globals.Editorindex].SubType;
			}
			else
			{
				fraVitals.Visible = false;
			}
			
			if (cmbType.SelectedIndex == (int) Enums.ItemType.Skill)
			{
				fraSkill.Visible = true;
			}
			else
			{
				fraSkill.Visible = false;
			}
			
			if (cmbType.SelectedIndex == (int) Enums.ItemType.Furniture)
			{
				fraFurniture.Visible = true;
			}
			else
			{
				fraFurniture.Visible = false;
			}
			
			if (cmbType.SelectedIndex == (int) Enums.ItemType.Recipe)
			{
				fraRecipe.Visible = true;
			}
			else
			{
				fraRecipe.Visible = false;
			}
			
			if (cmbType.SelectedIndex == (int) Enums.ItemType.Pet)
			{
				fraPet.Visible = true;
			}
			else
			{
				fraPet.Visible = false;
			}
			
			Types.Item[E_Globals.Editorindex].Type = (byte) cmbType.SelectedIndex;
		}
		
		public void NudVitalMod_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Data1 = (int) nudVitalMod.Value;
		}
		
		public void CmbSkills_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Data1 = cmbSkills.SelectedIndex;
		}
		
		public void TxtName_TextChanged(object sender, EventArgs e)
		{
			int tmpindex = 0;
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			tmpindex = lstIndex.SelectedIndex;
			Types.Item[E_Globals.Editorindex].Name = txtName.Text.Trim();
			lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
			lstIndex.Items.Insert(E_Globals.Editorindex - 1, E_Globals.Editorindex + ": " + Types.Item[E_Globals.Editorindex].Name);
			lstIndex.SelectedIndex = tmpindex;
		}
		
		public void NudPrice_ValueChanged(object sender, EventArgs e)
		{

        }

        public void ChkStackable_CheckedChanged(object sender, EventArgs e)
		{
			if (chkStackable.Checked == true)
			{
				Types.Item[E_Globals.Editorindex].Stackable = (byte) 1;
			}
			else
			{
				Types.Item[E_Globals.Editorindex].Stackable = (byte) 0;
			}
		}
		
		public void CmbRecipe_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Data1 = cmbRecipe.SelectedIndex;
		}
		
		public void TxtDescription_TextChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Description = txtDescription.Text.Trim();
		}
		
		public void CmbSubType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].SubType = (byte) cmbSubType.SelectedIndex;
		}
		
		public void NudItemLvl_ValueChanged(object sender, EventArgs e)
		{

        }

        public void CmbPet_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Data1 = cmbPet.SelectedIndex;
		}
		
#endregion
		
#region Requirements
		
		public void CmbClassReq_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].ClassReq = cmbClassReq.SelectedIndex;
		}
		
		public void CmbAccessReq_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].AccessReq = cmbAccessReq.SelectedIndex;
		}
		
		public void NudLevelReq_ValueChanged(object sender, EventArgs e)
		{

        }

        public void NudStrReq_ValueChanged(object sender, EventArgs e)
		{

        }

        public void NudEndReq_ValueChanged(object sender, EventArgs e)
		{

        }

        public void NudVitReq_ValueChanged(object sender, EventArgs e)
		{

        }

        public void NudLuckReq_ValueChanged(object sender, EventArgs e)
		{

        }

        public void NudIntReq_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Stat_Req[(byte)Enums.StatType.Intelligence] = (byte)nudIntReq.Value;
		}
		
		public void NudSprReq_ValueChanged(object sender, EventArgs e)
		{

        }

        #endregion

        #region Equipment

        public void CmbTool_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			Types.Item[E_Globals.Editorindex].Data3 = cmbTool.SelectedIndex;
		}
		
		public void NudDamage_ValueChanged(object sender, EventArgs e)
		{

        }

        public void NudSpeed_ValueChanged(object sender, EventArgs e)
		{

        }

        public void NudPaperdoll_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Paperdoll = (int) nudPaperdoll.Value;
			E_Items.EditorItem_DrawPaperdoll();
		}
		
		public void NudStrength_ValueChanged(object sender, EventArgs e)
		{

        }

        public void NudLuck_ValueChanged(object sender, EventArgs e)
		{

        }

        public void NudEndurance_ValueChanged(object sender, EventArgs e)
		{

        }

        public void NudIntelligence_ValueChanged(object sender, EventArgs e)
		{

        }

        public void NudVitality_ValueChanged(object sender, EventArgs e)
		{

        }

        public void NudSpirit_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Add_Stat[(byte)Enums.StatType.Spirit] = (byte)nudSpirit.Value;
		}
		
		public void ChkKnockBack_CheckedChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			if (chkKnockBack.Checked == true)
			{
				Types.Item[E_Globals.Editorindex].KnockBack = (byte) 1;
			}
			else
			{
				Types.Item[E_Globals.Editorindex].KnockBack = (byte) 0;
			}
		}
		
		public void CmbKnockBackTiles_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].KnockBackTiles = (byte) cmbKnockBackTiles.SelectedIndex;
		}
		
		public void ChkRandomize_CheckedChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			if (chkRandomize.Checked == true)
			{
				Types.Item[E_Globals.Editorindex].Randomize = (byte) 1;
			}
			else
			{
				Types.Item[E_Globals.Editorindex].Randomize = (byte) 0;
			}
		}
		
		public void CmbProjectile_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Projectile = cmbProjectile.SelectedIndex;
		}
		
		public void CmbAmmo_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Ammo = cmbAmmo.SelectedIndex;
		}
		
#endregion
		
#region Furniture
		
		public void CmbFurnitureType_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			Types.Item[E_Globals.Editorindex].Data1 = cmbFurnitureType.SelectedIndex;
		}
		
		public void OptNoFurnitureEditing_CheckedChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			if (optNoFurnitureEditing.Checked == true)
			{
				lblSetOption.Text = "No Editing: Lets you look at the image without setting any options (blocks/fringes).";
			}
			E_Items.EditorItem_DrawFurniture();
		}
		
		public void OptSetBlocks_CheckedChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			if (optSetBlocks.Checked == true)
			{
				lblSetOption.Text = "Set Blocks: Os are passable and Xs are not. Simply place Xs where you do not want the player to walk.";
			}
			E_Items.EditorItem_DrawFurniture();
		}
		
		public void OptSetFringe_CheckedChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			if (optSetFringe.Checked == true)
			{
				lblSetOption.Text = "Set Fringe: Os are draw on the fringe layer (the player can walk behind).";
			}
			E_Items.EditorItem_DrawFurniture();
		}
		
		public void NudFurniture_ValueChanged(object sender, EventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			
			Types.Item[E_Globals.Editorindex].Data2 = (int) nudFurniture.Value;
			
			if (E_Graphics.FurnitureGFXInfo[(int) nudFurniture.Value].IsLoaded == false)
			{
				E_Graphics.LoadTexture((int) nudFurniture.Value, (byte) 10);
			}

            //seeying we still use it, lets update timer
            E_Graphics.FurnitureGFXInfo[(int)nudFurniture.Value].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
			
			if (nudFurniture.Value > 0 && nudFurniture.Value <= E_Housing.NumFurniture)
			{
				Types.Item[E_Globals.Editorindex].FurnitureWidth = System.Convert.ToInt32((double) E_Graphics.FurnitureGFXInfo[(int) nudFurniture.Value].width / 32);
				Types.Item[E_Globals.Editorindex].FurnitureHeight = System.Convert.ToInt32((double) E_Graphics.FurnitureGFXInfo[(int) nudFurniture.Value].height / 32);
				if (Types.Item[E_Globals.Editorindex].FurnitureHeight > 1)
				{
					Types.Item[E_Globals.Editorindex].FurnitureHeight = Types.Item[E_Globals.Editorindex].FurnitureHeight - 1;
				}
			}
			else
			{
				Types.Item[E_Globals.Editorindex].FurnitureWidth = 1;
				Types.Item[E_Globals.Editorindex].FurnitureHeight = 1;
			}
			
			E_Items.EditorItem_DrawFurniture();
		}
		
		public void PicFurniture_MouseDown(object sender, MouseEventArgs e)
		{
			if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > Constants.MAX_ITEMS)
			{
				return;
			}
			int X = 0;
			int Y = 0;
			X = System.Convert.ToInt32((double) e.X / 32);
			Y = System.Convert.ToInt32((double) e.Y / 32);
			
			if (X > 3)
			{
				return;
			}
			if (Y > 3)
			{
				return;
			}
			
			if (optSetBlocks.Checked == true)
			{
				if (Types.Item[E_Globals.Editorindex].FurnitureBlocks[X, Y] == 1)
				{
					Types.Item[E_Globals.Editorindex].FurnitureBlocks[X, Y] = 0;
				}
				else
				{
					Types.Item[E_Globals.Editorindex].FurnitureBlocks[X, Y] = 1;
				}
			}
			else if (optSetFringe.Checked == true)
			{
				if (Types.Item[E_Globals.Editorindex].FurnitureFringe[X, Y] == 1)
				{
					Types.Item[E_Globals.Editorindex].FurnitureFringe[X, Y] = 0;
				}
				else
				{
					Types.Item[E_Globals.Editorindex].FurnitureFringe[X, Y] = 1;
				}
			}
			E_Items.EditorItem_DrawFurniture();
		}
		
#endregion
		
	}
}
