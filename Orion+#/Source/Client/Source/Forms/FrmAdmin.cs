
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using Engine;

namespace Engine
{
	partial class FrmAdmin
	{
		public FrmAdmin()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmAdmin defaultInstance;
		
		/// <summary>
		/// The Instance of this Form
		/// </summary>
		public static FrmAdmin Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmAdmin();
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
		
		public void FrmAdmin_Load(object sender, EventArgs e)
		{
			// set values for admin panel
			cmbSpawnItem.Items.Clear();
			
			// Add the names
			for (var i = 1; i <= Constants.MAX_ITEMS; i++)
			{
				cmbSpawnItem.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Item[(int) i].Name));
			}
		}
		
#region Moderation
		
		public void BtnAdminWarpTo_Click(object sender, EventArgs e)
		{
			
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			// Check to make sure its a valid map #
			if (nudAdminMap.Value > 0 && nudAdminMap.Value <= Constants.MAX_MAPS)
			{
				C_NetworkSend.WarpTo(System.Convert.ToInt32(nudAdminMap.Value));
			}
			else
			{
				C_Text.AddText("Invalid map number.", (System.Int32) Enums.ColorType.BrightRed);
			}
		}
		
		public void BtnAdminBan_Click(object sender, EventArgs e)
		{
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			if (Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtAdminName.Text)).Length < 1)
			{
				return;
			}
			
			C_NetworkSend.SendBan(Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtAdminName.Text)));
		}
		
		public void BtnAdminKick_Click(object sender, EventArgs e)
		{
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			if (Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtAdminName.Text)).Length < 1)
			{
				return;
			}
			
			C_NetworkSend.SendKick(Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtAdminName.Text)));
		}
		
		public void BtnAdminWarp2Me_Click(object sender, EventArgs e)
		{
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			if (Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtAdminName.Text)).Length < 1)
			{
				return;
			}
			
			if (Information.IsNumeric(Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtAdminName.Text))))
			{
				return;
			}
			
			C_NetworkSend.WarpToMe(Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtAdminName.Text)));
		}
		
		public void BtnAdminWarpMe2_Click(object sender, EventArgs e)
		{
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			if (Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtAdminName.Text)).Length < 1)
			{
				return;
			}
			
			if (Information.IsNumeric(Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtAdminName.Text))))
			{
				return;
			}
			
			C_NetworkSend.WarpMeTo(Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtAdminName.Text)));
		}
		
		public void BtnAdminSetAccess_Click(object sender, EventArgs e)
		{
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Creator)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			if (Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtAdminName.Text)).Length < 2)
			{
				return;
			}
			
			if (Information.IsNumeric(Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtAdminName.Text))) || cmbAccess.SelectedIndex < 0)
			{
				return;
			}
			
			C_NetworkSend.SendSetAccess(Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(txtAdminName.Text)), System.Convert.ToByte(cmbAccess.SelectedIndex));
		}
		
		public void BtnAdminSetSprite_Click(object sender, EventArgs e)
		{
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			if (nudAdminSprite.Value < 1)
			{
				return;
			}
			
			C_NetworkSend.SendSetSprite(System.Convert.ToInt32(nudAdminSprite.Value));
		}
		
#endregion
		
#region Editors
		
		public void BtnMapEditor_Click(object sender, EventArgs e)
		{
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			C_Maps.SendRequestEditMap();
		}
		
#endregion
		
#region Map Report
		
		public void BtnMapReport_Click(object sender, EventArgs e)
		{
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			C_NetworkSend.SendRequestMapreport();
		}
		
		public void LstMaps_DoubleClick(object sender, EventArgs e)
		{
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			// Check to make sure its a valid map #
			if (lstMaps.FocusedItem.Index + 1 > 0 && lstMaps.FocusedItem.Index + 1 <= Constants.MAX_MAPS)
			{
				C_NetworkSend.WarpTo(System.Convert.ToInt32(lstMaps.FocusedItem.Index + 1));
			}
			else
			{
				C_Text.AddText("Invalid map number: " + (lstMaps.FocusedItem.Index + 1), (System.Int32) Enums.QColorType.AlertColor);
			}
		}
		
#endregion
		
#region Misc
		
		public void CmbSpawnItem_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (Types.Item[cmbSpawnItem.SelectedIndex + 1].Type == (byte)Enums.ItemType.Currency || Types.Item[cmbSpawnItem.SelectedIndex + 1].Stackable == 1)
			{
				nudSpawnItemAmount.Enabled = true;
				return;
			}
			nudSpawnItemAmount.Enabled = false;
		}
		
		public void BtnSpawnItem_Click(object sender, EventArgs e)
		{
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Creator)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			C_NetworkSend.SendSpawnItem(System.Convert.ToInt32(cmbSpawnItem.SelectedIndex + 1), System.Convert.ToInt32(nudSpawnItemAmount.Value));
		}
		
		public void BtnLevelUp_Click(object sender, EventArgs e)
		{
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Developer)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			C_NetworkSend.SendRequestLevelUp();
			
		}
		
		public void BtnALoc_Click(object sender, EventArgs e)
		{
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			C_Variables.BLoc = !C_Variables.BLoc;
		}
		
		public void BtnRespawn_Click(object sender, EventArgs e)
		{
			if (C_Player.GetPlayerAccess(C_Variables.Myindex) < (int) Enums.AdminType.Mapper)
			{
				C_Text.AddText("You need to be a high enough staff member to do this!", (System.Int32) Enums.QColorType.AlertColor);
				return;
			}
			
			C_Maps.SendMapRespawn();
		}
		
#endregion
		
	}
}
