
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using Engine;

namespace Engine
{
	sealed class C_UpdateUI
	{
		
#region Defines
		
		internal static bool GameDestroyed;
		internal static bool ReloadFrmMain;
		internal static bool PnlRegisterVisible;
		internal static bool PnlCharCreateVisible;
		internal static bool PnlLoginVisible;
		internal static bool PnlCreditsVisible;
		internal static bool Frmmenuvisible;
		internal static bool Frmmaingamevisible;
		internal static bool Pnlloadvisible;
		internal static int Lblnextcharleft;
		internal static string[] Cmbclass;
		internal static string TxtChatAdd;
		internal static bool ChkSavePassChecked;
		internal static string TempUserName;
		internal static string TempPassword;
		internal static bool PnlCharSelectVisible;
		internal static bool DrawCharSelect;
		
		//Mapreport
		internal static bool UpdateMapnames;
		
		internal static bool Adminvisible;
		
		//GUI drawing
		internal static bool HudVisible;
		
		internal static bool PnlCharacterVisible;
		internal static bool PnlInventoryVisible;
		internal static bool PnlSkillsVisible;
		internal static bool PnlBankVisible;
		internal static bool PnlShopVisible;
		internal static bool PnlTradeVisible;
		internal static bool PnlEventChatVisible;
		internal static bool PnlRClickVisible;
		internal static bool OptionsVisible;
		
		internal static bool VbKeyRight;
		internal static bool VbKeyLeft;
		internal static bool VbKeyUp;
		internal static bool VbKeyDown;
		internal static bool VbKeyShift;
		internal static bool VbKeyControl;
		internal static bool VbKeyAlt;
		
		internal static int PicHpWidth;
		internal static int PicManaWidth;
		internal static int PicExpWidth;
		
		internal static string LblHpText;
		internal static string LblManaText;
		internal static string LblExpText;
		
		//Editors
		internal static bool InitMapEditor;
		
		internal static bool UpdateCharacterPanel;
		
		internal static bool NeedToOpenShop;
		internal static int NeedToOpenShopNum;
		internal static bool NeedToOpenBank;
		internal static bool NeedToOpenTrade;
		internal static bool NeedtoCloseTrade;
		internal static bool NeedtoUpdateTrade;
		
		internal static bool InitMapProperties;
		
		internal static string Tradername;
		
		//UI Panels Coordinates
		internal static int HudWindowX = 0;
		
		internal static int HudWindowY = 0;
		internal static int HudFaceX = 4;
		internal static int HudFaceY = 4;
		
		//bars
		internal static int HudhpBarX = 110;
		
		internal static int HudhpBarY = 10;
		internal static int HudmpBarX = 110;
		internal static int HudmpBarY = 30;
		internal static int HudexpBarX = 110;
		internal static int HudexpBarY = 50;
		
		//Set the Chat Position
		
		internal static int MyChatX = 1;
		internal static int MyChatY = FrmGame.Default.Height - 55;
		
		internal static int ChatWindowX = 1;
		internal static int ChatWindowY = 705;
		
		internal static bool ShowItemDesc;
		internal static int ItemDescItemNum;
		internal static string ItemDescName;
		internal static string ItemDescDescription;
		internal static int ItemDescValue;
		internal static string ItemDescInfo;
		internal static string ItemDescType;
		internal static string ItemDescCost;
		internal static string ItemDescLevel;
		internal static string ItemDescSpeed;
		internal static string ItemDescStr;
		internal static string ItemDescEnd;
		internal static string ItemDescInt;
		internal static string ItemDescSpr;
		internal static string ItemDescVit;
		internal static string ItemDescLuck;
		internal static SFML.Graphics.Color ItemDescRarityColor;
		internal static SFML.Graphics.Color ItemDescRarityBackColor;
		
		//Action Panel Coordinates
		internal static int ActionPanelX = 942;
		
		internal static int ActionPanelY = 755;
		
		internal static int InvBtnX = 16;
		internal static int InvBtnY = 16;
		internal static int SkillBtnX = 80;
		internal static int SkillBtnY = 16;
		internal static int CharBtnX = 144;
		internal static int CharBtnY = 16;
		
		internal static int QuestBtnX = 25;
		internal static int QuestBtnY = 64;
		internal static int OptBtnX = 88;
		internal static int OptBtnY = 64;
		internal static int ExitBtnX = 144;
		internal static int ExitBtnY = 64;
		
		//Character window Coordinates
		internal static int CharWindowX = 943;
		
		internal static int CharWindowY = 475;
		internal const byte EqTop = 85;
		internal const byte EqLeft = 8;
		internal const byte EqOffsetX = 125;
		internal const byte EqOffsetY = 5;
		internal const byte EqColumns = 2;
		
		internal static int StrengthUpgradeX = 370;
		internal static int StrengthUpgradeY = 33;
		internal static int EnduranceUpgradeX = 370;
		internal static int EnduranceUpgradeY = 53;
		internal static int VitalityUpgradeX = 370;
		internal static int VitalityUpgradeY = 72;
		internal static int IntellectUpgradeX = 370;
		internal static int IntellectUpgradeY = 91;
		internal static int LuckUpgradeX = 370;
		internal static int LuckUpgradeY = 110;
		internal static int SpiritUpgradeX = 370;
		internal static int SpiritUpgradeY = 129;
		
		//Hotbar Coordinates
		internal static int HotbarX = 489;
		
		internal static int HotbarY = 825;
		
		//pet bar
		internal static int PetbarX = 489;
		
		internal static int PetbarY = 800;
		internal static int PetStatX = 943;
		internal static int PetStatY = 575;
		
		//Inventory window Coordinates
		internal static int InvWindowX = 943;
		
		internal static int InvWindowY = 475;
		internal const byte InvTop = 9;
		internal const byte InvLeft = 10;
		internal const byte InvOffsetY = 5;
		internal const byte InvOffsetX = 6;
		internal const byte InvColumns = 5;
		
		//Skill window Coordinates
		internal static int SkillWindowX = 943;
		
		internal static int SkillWindowY = 475;
		
		// skills constants
		internal const byte SkillTop = 9;
		
		internal const byte SkillLeft = 10;
		internal const byte SkillOffsetY = 5;
		internal const byte SkillOffsetX = 6;
		internal const byte SkillColumns = 5;
		
		internal static bool ShowSkillDesc;
		internal static byte SkillDescSize;
		internal static int SkillDescSkillNum;
		internal static string SkillDescName;
		internal static string SkillDescVital;
		internal static string SkillDescInfo;
		internal static string SkillDescType;
		internal static string SkillDescCastTime;
		internal static string SkillDescCoolDown;
		internal static string SkillDescDamage;
		internal static string SkillDescAoe;
		internal static string SkillDescRange;
		internal static string SkillDescReqMp;
		internal static string SkillDescReqLvl;
		internal static string SkillDescReqClass;
		internal static string SkillDescReqAccess;
		
		//dialog panel
		internal static bool DialogPanelVisible;
		
		internal static int DialogPanelX = 250;
		internal static int DialogPanelY = 400;
		internal static int OkButtonX = 50;
		internal static int OkButtonY = 130;
		internal static int CancelButtonX = 200;
		internal static int CancelButtonY = 130;
		
		//bank window Coordinates
		internal static int BankWindowX = 319;
		
		internal static int BankWindowY = 105;
		
		// Bank constants
		internal const byte BankTop = 30;
		
		internal const byte BankLeft = 16;
		internal const byte BankOffsetY = 5;
		internal const byte BankOffsetX = 6;
		internal const byte BankColumns = 9;
		
		// shop coordinates
		internal static int ShopWindowX = 250;
		
		internal static int ShopWindowY = 125;
		internal static int ShopFaceX = 60;
		internal static int ShopFaceY = 60;
		
		internal static int ShopButtonBuyX = 150;
		internal static int ShopButtonBuyY = 140;
		
		internal static int ShopButtonSellX = 150;
		internal static int ShopButtonSellY = 190;
		
		internal static int ShopButtonCloseX = 10;
		internal static int ShopButtonCloseY = 215;
		
		// shop constants
		internal const byte ShopTop = 46;
		
		internal const int ShopLeft = 271;
		internal const byte ShopOffsetY = 5;
		internal const byte ShopOffsetX = 5;
		internal const byte ShopColumns = 6;
		
		//trade constants
		internal const int TradeWindowX = 200;
		
		internal const byte TradeWindowY = 100;
		internal const int OurTradeX = 2;
		internal const byte OurTradeY = 17;
		internal const int TheirTradeX = 201;
		internal const byte TheirTradeY = 17;
		
		internal static int TradeButtonAcceptX = 50;
		internal static int TradeButtonAcceptY = 320;
		
		internal static int TradeButtonDeclineX = 250;
		internal static int TradeButtonDeclineY = 320;
		
		//event chat constants
		internal const int EventChatX = 250;
		
		internal const byte EventChatY = 210;
		internal static int EventChatTextX = 113;
		internal static int EventChatTextY = 14;
		
		//right click menu
		internal static string RClickname;
		
		internal static int RClickX;
		internal static int RClickY;
		
		internal static bool DrawChar;
		
		internal static int CraftPanelX = 25;
		internal static int CraftPanelY = 25;
		internal static bool LoadClassInfo;
		
#endregion
		
		public static void UpdateUi()
		{
			
			if (ReloadFrmMain == true)
			{
				ReloadFrmMain = false;
			}
			
			if (C_Variables.UpdateNews == true)
			{
				FrmMenu.Default.lblNews.Text = C_Variables.News;
				FrmMenu.Default.Text = C_Constants.GameName;
				FrmGame.Default.Text = C_Constants.GameName;
				C_Variables.UpdateNews = false;
			}
			
			if (PnlRegisterVisible != FrmMenu.Default.pnlRegister.Visible)
			{
				FrmMenu.Default.pnlRegister.Visible = PnlRegisterVisible;
				FrmMenu.Default.pnlRegister.BringToFront();
			}
			
			if (DrawChar == true)
			{
				FrmMenu.Default.DrawCharacter();
				DrawChar = false;
			}
			
			if (PnlCharCreateVisible != FrmMenu.Default.pnlNewChar.Visible)
			{
				FrmMenu.Default.pnlNewChar.Visible = PnlCharCreateVisible;
				FrmMenu.Default.pnlNewChar.BringToFront();
				DrawChar = true;
			}
			
			if (Lblnextcharleft != FrmMenu.Default.lblNextChar.Left)
			{
				FrmMenu.Default.lblNextChar.Left = Lblnextcharleft;
			}
			
			if (!ReferenceEquals(Cmbclass, null))
			{
				FrmMenu.Default.cmbClass.Items.Clear();
				
				for (var i = 1; i <= (Cmbclass.Length - 1); i++)
				{
					FrmMenu.Default.cmbClass.Items.Add(Cmbclass[(int) i]);
				}
				
				FrmMenu.Default.cmbClass.SelectedIndex = 0;
				
				FrmMenu.Default.rdoMale.Checked = true;
				
				FrmMenu.Default.txtCharName.Focus();
				
				Cmbclass = null;
			}
			
			if (PnlLoginVisible != FrmMenu.Default.pnlLogin.Visible)
			{
				FrmMenu.Default.pnlLogin.Visible = PnlLoginVisible;
				if (PnlLoginVisible)
				{
					FrmMenu.Default.txtLogin.Focus();
				}
			}
			
			if (PnlCreditsVisible != FrmMenu.Default.pnlCredits.Visible)
			{
				FrmMenu.Default.pnlCredits.Visible = PnlCreditsVisible;
			}
			
			if (Frmmenuvisible != FrmMenu.Default.Visible)
			{
				FrmMenu.Default.Visible = Frmmenuvisible;
			}
			
			if (DrawCharSelect)
			{
				FrmMenu.Default.DrawCharacterSelect();
				DrawCharSelect = false;
			}
			
			if (PnlCharSelectVisible != FrmMenu.Default.pnlCharSelect.Visible)
			{
				FrmMenu.Default.pnlCharSelect.Visible = PnlCharSelectVisible;
				if (PnlCharSelectVisible)
				{
					DrawCharSelect = true;
				}
			}
			
			if (Frmmaingamevisible != FrmGame.Default.Visible)
			{
				FrmGame.Default.Visible = Frmmaingamevisible;
			}
			
			if (C_Crafting.InitCrafting == true)
			{
				C_Crafting.CraftingInit();
				C_Crafting.InitCrafting = false;
			}
			
			if (NeedToOpenShop == true)
			{
				C_GameLogic.OpenShop(NeedToOpenShopNum);
				NeedToOpenShop = false;
				NeedToOpenShopNum = 0;
				PnlShopVisible = true;
			}
			
			if (NeedToOpenBank == true)
			{
				C_Banks.InBank = System.Convert.ToInt32(true);
				PnlBankVisible = true;
				C_Banks.DrawBank();
				NeedToOpenBank = false;
			}
			
			if (NeedToOpenTrade == true)
			{
				C_Trade.InTrade = true;
				PnlTradeVisible = true;
				
				NeedToOpenTrade = false;
			}
			
			if (NeedtoCloseTrade == true)
			{
				C_Trade.InTrade = false;
				PnlTradeVisible = false;
				
				NeedtoCloseTrade = false;
			}
			
			if (NeedtoUpdateTrade == true)
			{
				C_Trade.DrawTrade();
				NeedtoUpdateTrade = false;
			}
			
			if (UpdateCharacterPanel == true)
			{
				UpdateCharacterPanel = false;
			}
			
			if (Pnlloadvisible != FrmMenu.Default.pnlLoad.Visible)
			{
				FrmMenu.Default.pnlLoad.Visible = Pnlloadvisible;
			}
			
			if (UpdateMapnames == true)
			{
				int x = 0;
				
				FrmAdmin.Default.lstMaps.Items.Clear();
				
				for (x = 1; x <= Constants.MAX_MAPS; x++)
				{
					FrmAdmin.Default.lstMaps.Items.Add(x.ToString());
					FrmAdmin.Default.lstMaps.Items[x - 1].SubItems.Add(C_Types.MapNames[x]);
				}
				
				UpdateMapnames = false;
			}
			
			if (Adminvisible == true)
			{
				FrmAdmin.Default.Visible = !FrmAdmin.Default.Visible;
				Adminvisible = false;
			}
			
			if (C_Quest.UpdateQuestChat == true)
			{
				C_Variables.DialogMsg1 = "Quest: " + Microsoft.VisualBasic.Strings.Trim(C_Quest.Quest[C_Quest.QuestNum].Name);
				C_Variables.DialogMsg2 = C_Quest.QuestMessage;
				
				C_Variables.DialogType = C_Constants.DialogueTypeQuest;
				
				if (C_Quest.QuestNumForStart > 0 && C_Quest.QuestNumForStart <= C_Quest.MaxQuests)
				{
					C_Quest.QuestAcceptTag = C_Quest.QuestNumForStart;
				}
				
				C_Variables.UpdateDialog = true;
				
				C_Quest.UpdateQuestChat = false;
			}
			
			if (C_Quest.UpdateQuestWindow == true)
			{
				C_Quest.LoadQuestlogBox();
				C_Quest.UpdateQuestWindow = false;
			}
			
			if (C_Variables.UpdateDialog == true)
			{
				if (C_Variables.DialogType == C_Constants.DialogueTypeBuyhome || C_Variables.DialogType == C_Constants.DialogueTypeVisit) //house offer & visit
				{
					C_Variables.DialogButton1Text = "Accept";
					C_Variables.DialogButton2Text = "Decline";
					DialogPanelVisible = true;
				}
				else if (C_Variables.DialogType == C_Constants.DialogueTypeParty || C_Variables.DialogType == C_Constants.DialogueTypeTrade)
				{
					C_Variables.DialogButton1Text = "Accept";
					C_Variables.DialogButton2Text = "Decline";
					DialogPanelVisible = true;
				}
				else if (C_Variables.DialogType == C_Constants.DialogueTypeQuest)
				{
					C_Variables.DialogButton1Text = "Accept";
					C_Variables.DialogButton2Text = "Ok";
					if (C_Quest.QuestAcceptTag > 0)
					{
						C_Variables.DialogButton2Text = "Decline";
					}
					DialogPanelVisible = true;
				}
				
				C_Variables.UpdateDialog = false;
			}
			
			if (C_EventSystem.EventChat == true)
			{
				PnlEventChatVisible = true;
				C_EventSystem.EventChat = false;
			}
			
			if (C_Variables.ShowRClick == true)
			{
				RClickname = C_Types.Player[C_Variables.MyTarget].Name;
				RClickX = C_Graphics.ConvertMapX(C_Variables.CurX * C_Constants.PicX);
				RClickY = C_Graphics.ConvertMapY(C_Variables.CurY * C_Constants.PicY);
				PnlRClickVisible = true;
				
				C_Variables.ShowRClick = false;
			}
			
			if (InitMapEditor == true)
			{
				FrmEditor_MapEditor.Default.MapEditorInit();
				InitMapEditor = false;
			}
			
			if (InitMapProperties == true)
			{
				FrmEditor_MapEditor.Default.MapPropertiesInit();
				InitMapProperties = false;
			}
			
			if (C_EventSystem.InitEventEditorForm == true)
			{
				FrmEditor_Events.Default.InitEventEditorForm();
				
				// populate form
				// set the tabs
				FrmEditor_Events.Default.tabPages.TabPages.Clear();
				
				for (var i = 1; i <= C_EventSystem.TmpEvent.PageCount; i++)
				{
					FrmEditor_Events.Default.tabPages.TabPages.Add(Conversion.Str(i));
				}
				// items
				FrmEditor_Events.Default.cmbHasItem.Items.Clear();
				FrmEditor_Events.Default.cmbHasItem.Items.Add("None");
				for (var i = 1; i <= Constants.MAX_ITEMS; i++)
				{
					FrmEditor_Events.Default.cmbHasItem.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Item[(int) i].Name));
				}
				// variables
				FrmEditor_Events.Default.cmbPlayerVar.Items.Clear();
				FrmEditor_Events.Default.cmbPlayerVar.Items.Add("None");
				for (var i = 1; i <= C_EventSystem.MaxVariables; i++)
				{
					FrmEditor_Events.Default.cmbPlayerVar.Items.Add(i +". " + C_EventSystem.Variables[(int) i]);
				}
				// variables
				FrmEditor_Events.Default.cmbPlayerSwitch.Items.Clear();
				FrmEditor_Events.Default.cmbPlayerSwitch.Items.Add("None");
				for (var i = 1; i <= C_EventSystem.MaxSwitches; i++)
				{
					FrmEditor_Events.Default.cmbPlayerSwitch.Items.Add(i +". " + C_EventSystem.Switches[(int) i]);
				}
				// name
				FrmEditor_Events.Default.txtName.Text = C_EventSystem.TmpEvent.Name;
				// enable delete button
				if (C_EventSystem.TmpEvent.PageCount > 1)
				{
					FrmEditor_Events.Default.btnDeletePage.Enabled = true;
				}
				else
				{
					FrmEditor_Events.Default.btnDeletePage.Enabled = false;
				}
				FrmEditor_Events.Default.btnPastePage.Enabled = false;
				// Load page 1 to start off with
				C_EventSystem.CurPageNum = 1;
				C_EventSystem.EventEditorLoadPage(C_EventSystem.CurPageNum);
				
				FrmEditor_Events.Default.nudShowTextFace.Maximum = C_Graphics.NumFaces;
				FrmEditor_Events.Default.nudShowChoicesFace.Maximum = C_Graphics.NumFaces;
				// show the editor
				FrmEditor_Events.Default.Show();
				
				C_EventSystem.InitEventEditorForm = false;
			}
			
			if (OptionsVisible == true)
			{
				
				// show in GUI
				if (C_Types.Options.Music == 1)
				{
					FrmOptions.Default.optMOn.Checked = true;
				}
				else
				{
					FrmOptions.Default.optMOff.Checked = true;
				}
				
				if (C_Types.Options.Music == 1)
				{
					FrmOptions.Default.optSOn.Checked = true;
				}
				else
				{
					FrmOptions.Default.optSOff.Checked = true;
				}
				
				FrmOptions.Default.lblVolume.Text = "Volume: " + System.Convert.ToString(C_Types.Options.Volume);
				FrmOptions.Default.scrlVolume.Value = (int)C_Types.Options.Volume;
				
				FrmOptions.Default.cmbScreenSize.SelectedIndex = C_Types.Options.ScreenSize;
				
				if (C_Types.Options.HighEnd == 1)
				{
					FrmOptions.Default.chkHighEnd.Checked = true;
				}
				else
				{
					FrmOptions.Default.chkHighEnd.Checked = false;
				}
				
				if (C_Types.Options.ShowNpcBar == 1)
				{
					FrmOptions.Default.chkNpcBars.Checked = true;
				}
				else
				{
					FrmOptions.Default.chkNpcBars.Checked = false;
				}
				
				FrmOptions.Default.Visible = true;
				OptionsVisible = false;
			}
		}
		
	}
}
