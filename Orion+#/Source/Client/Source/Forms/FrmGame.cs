
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Windows.Forms;
using Engine;

namespace Engine
{
	
	partial class FrmGame
	{
		public FrmGame()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmGame defaultInstance;
		
		/// <summary>
		/// The Instance of this Form
		/// </summary>
		public static FrmGame Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmGame();
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
		
#region Frm Code
		
		private const int CpNocloseButton = 0x200;
		
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams myCp = base.CreateParams;
				myCp.ClassStyle = myCp.ClassStyle | CpNocloseButton;
				return myCp;
			}
		}
		
		public void FrmMainGame_Load(object sender, EventArgs e)
		{
			C_General.RePositionGui();
			
			FrmAdmin.Default.Visible = false;
		}
		
		public void FrmMainGame_Closing(object sender, EventArgs e)
		{
			Application.Exit();
		}
		
		public void FrmMainGame_KeyPress(object sender, KeyPressEventArgs e)
		{
			ChatModule.ChatInput.ProcessCharacter(e);
		}
		
		public void FrmMainGame_KeyDown(object sender, KeyEventArgs e)
		{
			if (ChatModule.ChatInput.ProcessKey(e))
			{
				if (e.KeyCode == Keys.Enter)
				{
					C_GameLogic.HandlePressEnter();
				}
			}
			
			if (ChatModule.ChatInput.Active)
			{
				if (e.KeyCode == Keys.Enter)
				{
					C_GameLogic.HandlePressEnter();
				}
			}
			else
			{
				if (e.KeyCode == Keys.S)
				{
					C_UpdateUI.VbKeyDown = true;
				}
				if (e.KeyCode == Keys.W)
				{
					C_UpdateUI.VbKeyUp = true;
				}
				if (e.KeyCode == Keys.A)
				{
					C_UpdateUI.VbKeyLeft = true;
				}
				if (e.KeyCode == Keys.D)
				{
					C_UpdateUI.VbKeyRight = true;
				}
                if (e.KeyCode == Keys.Down)
                {
                    C_UpdateUI.VbKeyDown = true;
                }
                if (e.KeyCode == Keys.Up)
                {
                    C_UpdateUI.VbKeyUp = true;
                }
                if (e.KeyCode == Keys.Left)
                {
                    C_UpdateUI.VbKeyLeft = true;
                }
                if (e.KeyCode == Keys.Right)
                {
                    C_UpdateUI.VbKeyRight = true;
                }

                if (e.KeyCode == Keys.ShiftKey)
				{
					C_UpdateUI.VbKeyShift = true;
				}
				if (e.KeyCode == Keys.ControlKey)
				{
					C_UpdateUI.VbKeyControl = true;
				}
				if (e.KeyCode == Keys.Alt)
				{
					C_UpdateUI.VbKeyAlt = true;
				}
				
				if (e.KeyCode == Keys.Space)
				{
					C_GameLogic.CheckMapGetItem();
				}
			}
		}
		
		public void FrmMainGame_KeyUp(object sender, KeyEventArgs e)
		{
			int skillnum = 0;
			if (e.KeyCode == Keys.S)
			{
				C_UpdateUI.VbKeyDown = false;
			}
			if (e.KeyCode == Keys.W)
			{
				C_UpdateUI.VbKeyUp = false;
			}
			if (e.KeyCode == Keys.A)
			{
				C_UpdateUI.VbKeyLeft = false;
			}
			if (e.KeyCode == Keys.D)
			{
				C_UpdateUI.VbKeyRight = false;
			}
            if (e.KeyCode == Keys.Down)
            {
                C_UpdateUI.VbKeyDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                C_UpdateUI.VbKeyUp = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                C_UpdateUI.VbKeyLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                C_UpdateUI.VbKeyRight = false;
            }

            if (e.KeyCode == Keys.ShiftKey)
			{
				C_UpdateUI.VbKeyShift = false;
			}
			if (e.KeyCode == Keys.ControlKey)
			{
				C_UpdateUI.VbKeyControl = false;
			}
			if (e.KeyCode == Keys.Alt)
			{
				C_UpdateUI.VbKeyAlt = false;
			}
			
			//hotbar
			if (e.KeyCode == Keys.NumPad1)
			{
				skillnum = C_Types.Player[C_Variables.Myindex].Hotbar[1].Slot;
				
				if (skillnum != 0)
				{
					C_Player.PlayerCastSkill(skillnum);
				}
			}
			if (e.KeyCode == Keys.NumPad2)
			{
				skillnum = C_Types.Player[C_Variables.Myindex].Hotbar[2].Slot;
				
				if (skillnum != 0)
				{
					C_Player.PlayerCastSkill(skillnum);
				}
			}
			if (e.KeyCode == Keys.NumPad3)
			{
				skillnum = C_Types.Player[C_Variables.Myindex].Hotbar[3].Slot;
				
				if (skillnum != 0)
				{
					C_Player.PlayerCastSkill(skillnum);
				}
			}
			if (e.KeyCode == Keys.NumPad4)
			{
				skillnum = C_Types.Player[C_Variables.Myindex].Hotbar[4].Slot;
				
				if (skillnum != 0)
				{
					C_Player.PlayerCastSkill(skillnum);
				}
			}
			if (e.KeyCode == Keys.NumPad5)
			{
				skillnum = C_Types.Player[C_Variables.Myindex].Hotbar[5].Slot;
				
				if (skillnum != 0)
				{
					C_Player.PlayerCastSkill(skillnum);
				}
			}
			if (e.KeyCode == Keys.NumPad6)
			{
				skillnum = C_Types.Player[C_Variables.Myindex].Hotbar[6].Slot;
				
				if (skillnum != 0)
				{
					C_Player.PlayerCastSkill(skillnum);
				}
			}
			if (e.KeyCode == Keys.NumPad7)
			{
				skillnum = C_Types.Player[C_Variables.Myindex].Hotbar[7].Slot;
				
				if (skillnum != 0)
				{
					C_Player.PlayerCastSkill(skillnum);
				}
			}
			
			//admin
			if (e.KeyCode == Keys.Insert)
			{
				if (C_Types.Player[C_Variables.Myindex].Access > 0)
				{
					C_NetworkSend.SendRequestAdmin();
				}
			}
			//hide gui
			if (e.KeyCode == Keys.F10)
			{
				C_Variables.HideGui = !C_Variables.HideGui;
			}
			
			//lets check for keys for inventory etc
			if (!ChatModule.ChatInput.Active)
			{
				//inventory
				if (e.KeyCode == Keys.I)
				{
					C_UpdateUI.PnlInventoryVisible = !C_UpdateUI.PnlInventoryVisible;
				}
				//Character window
				if (e.KeyCode == Keys.C)
				{
					C_UpdateUI.PnlCharacterVisible = !C_UpdateUI.PnlCharacterVisible;
				}
				//quest window
				if (e.KeyCode == Keys.Q)
				{
					C_Quest.PnlQuestLogVisible = !C_Quest.PnlQuestLogVisible;
				}
				//options window
				if (e.KeyCode == Keys.O)
				{
					FrmOptions.Default.Visible = !FrmOptions.Default.Visible;
				}
				//skill window
				if (e.KeyCode == Keys.K)
				{
					C_UpdateUI.PnlSkillsVisible = !C_UpdateUI.PnlSkillsVisible;
				}
			}
			
		}
		
		public void LblCurrencyOk_Click(object sender, EventArgs e)
		{
			if (Information.IsNumeric(txtCurrency.Text))
			{
				if (C_Variables.CurrencyMenu == ((byte) 1)) // drop item
				{
					C_NetworkSend.SendDropItem(C_Variables.TmpCurrencyItem, System.Convert.ToInt32(Conversion.Val(txtCurrency.Text)));
				} // deposit item
				else if (C_Variables.CurrencyMenu == ((byte) 2))
				{
					C_Banks.DepositItem(C_Variables.TmpCurrencyItem, System.Convert.ToInt32(Conversion.Val(txtCurrency.Text)));
				} // withdraw item
				else if (C_Variables.CurrencyMenu == ((byte) 3))
				{
					C_Banks.WithdrawItem(C_Variables.TmpCurrencyItem, System.Convert.ToInt32(Conversion.Val(txtCurrency.Text)));
				} // trade item
				else if (C_Variables.CurrencyMenu == ((byte) 4))
				{
					C_Trade.TradeItem(C_Variables.TmpCurrencyItem, System.Convert.ToInt32(Conversion.Val(txtCurrency.Text)));
				}
			}
			
			pnlCurrency.Visible = false;
			C_Variables.TmpCurrencyItem = 0;
			txtCurrency.Text = "";
			C_Variables.CurrencyMenu = (byte) 0; // clear
		}

        #endregion

        #region PicScreen Code

        public void Picscreen_MouseDown(object sender, MouseEventArgs olde)
		{
            MouseEventArgs e = new MouseEventArgs(olde.Button, olde.Clicks, (int)(olde.X * (C_Constants.BaseScreenWidth / (float)FrmGame.Default.Width)), (int)(olde.Y * (C_Constants.BaseScreenHeight / (float)FrmGame.Default.Height)), olde.Delta);
            if (!C_GuiFunctions.CheckGuiClick(e.X, e.Y, e))
			{
				
				if (C_Constants.InMapEditor)
				{
					FrmEditor_MapEditor.Default.MapEditorMouseDown((System.Int32) e.Button, e.X, e.Y, false);
				}
				
				// left click
				if (e.Button == MouseButtons.Left)
				{
					
					// if we're in the middle of choose the trade target or not
					if (!C_Trade.TradeRequest)
					{
						if (C_Pets.PetAlive(C_Variables.Myindex))
						{
							if (C_GameLogic.IsInBounds())
							{
								C_Pets.PetMove(C_Variables.CurX, C_Variables.CurY);
							}
						}
						// targetting
						C_NetworkSend.PlayerSearch(C_Variables.CurX, C_Variables.CurY, (byte) 0);
					}
					else
					{
						// trading
						C_Trade.SendTradeRequest(C_Types.Player[C_Variables.MyTarget].Name);
					}
					C_UpdateUI.PnlRClickVisible = false;
					C_Pets.ShowPetStats = false;
					
					// right click
				}
				else if (e.Button == MouseButtons.Right)
				{
					if (C_Variables.ShiftDown || C_UpdateUI.VbKeyShift == true)
					{
						// admin warp if we're pressing shift and right clicking
						if (C_Player.GetPlayerAccess(C_Variables.Myindex) >= 2)
						{
							C_NetworkSend.AdminWarp(C_Variables.CurX, C_Variables.CurY);
						}
					}
					else
					{
						// rightclick menu
						if (C_Pets.PetAlive(C_Variables.Myindex))
						{
							if (C_GameLogic.IsInBounds() && C_Variables.CurX == C_Types.Player[C_Variables.Myindex].Pet.X & C_Variables.CurY == C_Types.Player[C_Variables.Myindex].Pet.Y)
							{
								C_Pets.ShowPetStats = true;
							}
						}
						else
						{
							C_NetworkSend.PlayerSearch(C_Variables.CurX, C_Variables.CurY, (byte) 1);
						}
					}
					C_Housing.FurnitureSelected = 0;
				}
			}
			
			C_GuiFunctions.CheckGuiMouseDown(e.X, e.Y, e);
			
			if (!FrmAdmin.Default.Visible || !FrmOptions.Default.Visible)
			{
				Focus();
			}
			
		}
		
		public void Picscreen_DoubleClick(object sender, EventArgs earg)
        {
            MouseEventArgs olde = (MouseEventArgs)earg;
            MouseEventArgs e = new MouseEventArgs(olde.Button, olde.Clicks, (int)(olde.X * (C_Constants.BaseScreenWidth / (float)FrmGame.Default.Width)), (int)(olde.Y * (C_Constants.BaseScreenHeight / (float)FrmGame.Default.Height)), olde.Delta);

            C_GuiFunctions.CheckGuiDoubleClick(e.X, e.Y, e);
		}
		
		public void Picscreen_Paint(object sender, PaintEventArgs e)
		{
			//This is here to make sure that the box dosen't try to re-paint itself... saves time and w/e else
			return;
		}
		
		public void Picscreen_MouseMove(object sender, MouseEventArgs olde)
        {
            MouseEventArgs e = new MouseEventArgs(olde.Button, olde.Clicks, (int)(olde.X * (C_Constants.BaseScreenWidth / (float)FrmGame.Default.Width)), (int)(olde.Y * (C_Constants.BaseScreenHeight / (float)FrmGame.Default.Height)), olde.Delta);
            C_Variables.CurX = C_Variables.TileView.Left + ((e.Location.X + C_Variables.Camera.Left) / C_Constants.PicX);
			C_Variables.CurY = C_Variables.TileView.Top + ((e.Location.Y + C_Variables.Camera.Top) / C_Constants.PicY);
			C_Variables.CurMouseX = e.Location.X;
			C_Variables.CurMouseY = e.Location.Y;
			C_GuiFunctions.CheckGuiMove(e.X, e.Y);
			
			if (C_Constants.InMapEditor)
			{
				if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
				{
					FrmEditor_MapEditor.Default.MapEditorMouseDown((System.Int32) e.Button, e.X, e.Y);
				}
			}
		}
		
		public void Picscreen_MouseUp(object sender, MouseEventArgs olde)
        {
            MouseEventArgs e = new MouseEventArgs(olde.Button, olde.Clicks, (int)(olde.X * (C_Constants.BaseScreenWidth / (float)FrmGame.Default.Width)), (int)(olde.Y * (C_Constants.BaseScreenHeight / (float)FrmGame.Default.Height)), olde.Delta);
            C_Variables.CurX = C_Variables.TileView.Left + ((e.Location.X + C_Variables.Camera.Left) / C_Constants.PicX);
			C_Variables.CurY = C_Variables.TileView.Top + ((e.Location.Y + C_Variables.Camera.Top) / C_Constants.PicY);
			C_GuiFunctions.CheckGuiMouseUp(e.X, e.Y, e);
		}
		
		public void Picscreen_KeyDown(object sender, KeyEventArgs e)
		{
			int num = 0;
			if (e.KeyCode == Keys.S)
			{
				C_UpdateUI.VbKeyDown = true;
			}
			if (e.KeyCode == Keys.W)
			{
				C_UpdateUI.VbKeyUp = true;
			}
			if (e.KeyCode == Keys.A)
			{
				C_UpdateUI.VbKeyLeft = true;
			}
			if (e.KeyCode == Keys.D)
			{
				C_UpdateUI.VbKeyRight = true;
			}
			if (e.KeyCode == Keys.ShiftKey)
			{
				C_UpdateUI.VbKeyShift = true;
			}
			if (e.KeyCode == Keys.ControlKey)
			{
				C_UpdateUI.VbKeyControl = true;
			}
			if (e.KeyCode == Keys.Alt)
			{
				C_UpdateUI.VbKeyAlt = true;
			}
			
			//hotbar
			if (e.KeyCode == Keys.NumPad1)
			{
				num = C_Types.Player[C_Variables.Myindex].Hotbar[1].Slot;
				
				if (num != 0)
				{
					C_HotBar.SendUseHotbarSlot(1);
				}
			}
			if (e.KeyCode == Keys.NumPad2)
			{
				num = C_Types.Player[C_Variables.Myindex].Hotbar[2].Slot;
				
				if (num != 0)
				{
					C_HotBar.SendUseHotbarSlot(2);
				}
			}
			if (e.KeyCode == Keys.NumPad3)
			{
				num = C_Types.Player[C_Variables.Myindex].Hotbar[3].Slot;
				
				if (num != 0)
				{
					C_HotBar.SendUseHotbarSlot(3);
				}
			}
			if (e.KeyCode == Keys.NumPad4)
			{
				num = C_Types.Player[C_Variables.Myindex].Hotbar[4].Slot;
				
				if (num != 0)
				{
					C_HotBar.SendUseHotbarSlot(4);
				}
			}
			if (e.KeyCode == Keys.NumPad5)
			{
				num = C_Types.Player[C_Variables.Myindex].Hotbar[5].Slot;
				
				if (num != 0)
				{
					C_HotBar.SendUseHotbarSlot(5);
				}
			}
			if (e.KeyCode == Keys.NumPad6)
			{
				num = C_Types.Player[C_Variables.Myindex].Hotbar[6].Slot;
				
				if (num != 0)
				{
					C_HotBar.SendUseHotbarSlot(6);
				}
			}
			if (e.KeyCode == Keys.NumPad7)
			{
				num = C_Types.Player[C_Variables.Myindex].Hotbar[7].Slot;
				
				if (num != 0)
				{
					C_HotBar.SendUseHotbarSlot(7);
				}
			}
			
			//admin
			if (e.KeyCode == Keys.Insert)
			{
				if (C_Types.Player[C_Variables.Myindex].Access > 0)
				{
					C_NetworkSend.SendRequestAdmin();
				}
			}
			//hide gui
			if (e.KeyCode == Keys.F10)
			{
				C_Variables.HideGui = !C_Variables.HideGui;
			}
			
			if (e.KeyCode == Keys.Enter)
			{
				ChatModule.ChatInput.ProcessKey(e);
				C_GameLogic.HandlePressEnter();
				C_GameLogic.CheckMapGetItem();
			}
		}
		
		public void Picscreen_KeyUp(object sender, KeyEventArgs e)
		{
			
			if (e.KeyCode == Keys.S)
			{
				C_UpdateUI.VbKeyDown = false;
			}
			if (e.KeyCode == Keys.W)
			{
				C_UpdateUI.VbKeyUp = false;
			}
			if (e.KeyCode == Keys.A)
			{
				C_UpdateUI.VbKeyLeft = false;
			}
			if (e.KeyCode == Keys.D)
			{
				C_UpdateUI.VbKeyRight = false;
			}
			if (e.KeyCode == Keys.ShiftKey)
			{
				C_UpdateUI.VbKeyShift = false;
			}
			if (e.KeyCode == Keys.ControlKey)
			{
				C_UpdateUI.VbKeyControl = false;
			}
			if (e.KeyCode == Keys.Alt)
			{
				C_UpdateUI.VbKeyAlt = false;
			}
			
			Keys keyData = e.KeyData;
			if (IsAcceptable(keyData))
			{
				e.Handled = true;
				e.SuppressKeyPress = true;
			}
			
		}
		
#endregion
		
#region Quest Code
		
		private void LblAbandonQuest_Click(object sender, EventArgs e)
		{
			//Dim QuestNum As Integer = GetQuestNum(Trim$(lstQuestLog.Text))
			//If Trim$(lstQuestLog.Text) = "" Then Exit Sub
			
			//PlayerHandleQuest(QuestNum, 2)
			//ResetQuestLog()
			//pnlQuestLog.Visible = False
		}
		
#endregion
		
#region Misc
		
		private readonly Keys[] _nonAcceptableKeys = new Keys[] {Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9};
		
		internal bool IsAcceptable(Keys keyData)
		{
			int index = Array.IndexOf(_nonAcceptableKeys, keyData);
			return index >= 0;
		}
		
#endregion
		
#region Crafting
		
		private void ChkKnownOnly_CheckedChanged(object sender, EventArgs e)
		{
			C_Crafting.CraftingInit();
		}

        #endregion

        private void FrmGame_Resize(object sender, EventArgs e)
        {
            // Window has Resized, So find the new Picscreen position and size.
            // Picscreen size must always be a Multiple of whatever resolution was chosen
        }
    }
}
