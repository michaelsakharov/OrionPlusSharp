
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using System.Windows.Forms;
using ASFW;
using Engine;


namespace Engine
{
	internal sealed class C_GuiFunctions
	{
		
		internal static void CheckGuiMove(int x, int y)
		{
			int eqNum = 0;
			int invNum = 0;
			int skillslot = 0;
			int bankitem = 0;
			int shopslot = 0;
			int tradeNum = 0;
			
			C_UpdateUI.ShowItemDesc = false;
			//Charpanel
			if (C_UpdateUI.PnlCharacterVisible)
			{
				if (x > C_UpdateUI.CharWindowX && x < C_UpdateUI.CharWindowX + C_Graphics.CharPanelGfxInfo.Width)
				{
					if (y > C_UpdateUI.CharWindowY && y < C_UpdateUI.CharWindowY + C_Graphics.CharPanelGfxInfo.Height)
					{
						eqNum = IsEqItem(x, y);
						if (eqNum != 0)
						{
							C_GameLogic.UpdateDescWindow(C_Player.GetPlayerEquipment(C_Variables.Myindex, (Enums.EquipmentType)eqNum), 0, eqNum, (byte) 1);
							C_Items.LastItemDesc = C_Player.GetPlayerEquipment(C_Variables.Myindex, (Enums.EquipmentType)eqNum); // set it so you don't re-set values
							C_UpdateUI.ShowItemDesc = true;
							return;
						}
						else
						{
							C_UpdateUI.ShowItemDesc = false;
							C_Items.LastItemDesc = 0; // no item was last loaded
						}
					}
				}
			}
			
			//inventory
			if (C_UpdateUI.PnlInventoryVisible)
			{
				if (AboveInvpanel(x, y))
				{
					C_Items.InvX = x;
					C_Items.InvY = y;
					
					if (C_Items.DragInvSlotNum > 0)
					{
						if (C_Trade.InTrade)
						{
							return;
						}
						if (System.Convert.ToBoolean(C_Banks.InBank != 0 || C_Shops.InShop != 0))
						{
							return;
						}
						C_Graphics.DrawInventoryItem(x, y);
						C_UpdateUI.ShowItemDesc = false;
						C_Items.LastItemDesc = 0; // no item was last loaded
					}
					else
					{
						invNum = IsInvItem(x, y);
						
						if (invNum != 0)
						{
							// exit out if we're offering that item
							for (var i = 1; i <= Constants.MAX_INV; i++)
							{
								if (C_Trade.TradeYourOffer[(int) i].Num == invNum)
								{
									return;
								}
							}
							C_GameLogic.UpdateDescWindow(C_Player.GetPlayerInvItemNum(C_Variables.Myindex, invNum), C_Player.GetPlayerInvItemValue(C_Variables.Myindex, invNum), invNum, (byte) 0);
							C_Items.LastItemDesc = C_Player.GetPlayerInvItemNum(C_Variables.Myindex, invNum); // set it so you don't re-set values
							C_UpdateUI.ShowItemDesc = true;
							return;
						}
						else
						{
							C_UpdateUI.ShowItemDesc = false;
							C_Items.LastItemDesc = 0; // no item was last loaded
						}
					}
				}
			}
			
			//skills
			if (C_UpdateUI.PnlSkillsVisible == true)
			{
				if (AboveSkillpanel(x, y))
				{
					C_Variables.SkillX = x;
					C_Variables.SkillY = y;
					
					if (C_Variables.DragSkillSlotNum > 0)
					{
						if (C_Trade.InTrade)
						{
							return;
						}
						if (System.Convert.ToBoolean(C_Banks.InBank != 0 || C_Shops.InShop != 0))
						{
							return;
						}
						C_Graphics.DrawSkillItem(x, y);
						C_Variables.LastSkillDesc = 0; // no item was last loaded
						C_UpdateUI.ShowSkillDesc = false;
					}
					else
					{
						skillslot = IsPlayerSkill(x, y);
						
						if (skillslot != 0)
						{
							C_GameLogic.UpdateSkillWindow(C_Variables.PlayerSkills[skillslot]);
							C_Variables.LastSkillDesc = C_Variables.PlayerSkills[skillslot];
							C_UpdateUI.ShowSkillDesc = true;
							return;
						}
						else
						{
							C_Variables.LastSkillDesc = 0;
							C_UpdateUI.ShowSkillDesc = false;
						}
					}
					
				}
			}
			
			//bank
			if (C_UpdateUI.PnlBankVisible == true)
			{
				if (AboveBankpanel(x, y))
				{
					C_Banks.BankX = x;
					C_Banks.BankY = y;
					
					if (C_Banks.DragBankSlotNum > 0)
					{
						C_Banks.DrawBankItem(x, y);
					}
					else
					{
						bankitem = IsBankItem(x, y);
						
						if (bankitem != 0)
						{
							
							C_GameLogic.UpdateDescWindow(C_Banks.Bank.Item[bankitem].Num, C_Banks.Bank.Item[bankitem].Value, bankitem, (byte) 2);
							C_UpdateUI.ShowItemDesc = true;
							return;
						}
						else
						{
							C_UpdateUI.ShowItemDesc = false;
							C_Items.LastItemDesc = 0; // no item was last loaded
						}
					}
					
				}
			}
			
			//shop
			if (C_UpdateUI.PnlShopVisible == true)
			{
				if (AboveShoppanel(x, y))
				{
					shopslot = IsShopItem(x, y);
					
					if (shopslot != 0)
					{
						
						C_GameLogic.UpdateDescWindow(Types.Shop[C_Shops.InShop].TradeItem[shopslot].Item, Types.Shop[C_Shops.InShop].TradeItem[shopslot].ItemValue, shopslot, (byte) 3);
						C_Items.LastItemDesc = Types.Shop[C_Shops.InShop].TradeItem[shopslot].Item;
						C_UpdateUI.ShowItemDesc = true;
						return;
					}
					else
					{
						C_UpdateUI.ShowItemDesc = false;
						C_Items.LastItemDesc = 0;
					}
					
				}
			}
			
			//trade
			if (C_UpdateUI.PnlTradeVisible == true)
			{
				if (AboveTradepanel(x, y))
				{
					C_Trade.TradeX = x;
					C_Trade.TradeY = y;
					
					//ours
					tradeNum = IsTradeItem(x, y, true);
					
					if (tradeNum != 0)
					{
						C_GameLogic.UpdateDescWindow(C_Player.GetPlayerInvItemNum(C_Variables.Myindex, C_Trade.TradeYourOffer[tradeNum].Num), C_Trade.TradeYourOffer[tradeNum].Value, tradeNum, (byte) 4);
						C_Items.LastItemDesc = C_Player.GetPlayerInvItemNum(C_Variables.Myindex, C_Trade.TradeYourOffer[tradeNum].Num); // set it so you don't re-set values
						C_UpdateUI.ShowItemDesc = true;
						return;
					}
					else
					{
						C_UpdateUI.ShowItemDesc = false;
						C_Items.LastItemDesc = 0;
					}
					
					//theirs
					tradeNum = IsTradeItem(x, y, false);
					
					if (tradeNum != 0)
					{
						C_GameLogic.UpdateDescWindow(C_Trade.TradeTheirOffer[tradeNum].Num, C_Trade.TradeTheirOffer[tradeNum].Value, tradeNum, (byte) 4);
						C_Items.LastItemDesc = C_Trade.TradeTheirOffer[tradeNum].Num; // set it so you don't re-set values
						C_UpdateUI.ShowItemDesc = true;
						return;
					}
					else
					{
						C_UpdateUI.ShowItemDesc = false;
						C_Items.LastItemDesc = 0;
					}
				}
			}
			
		}
		
		internal static bool CheckGuiClick(int x, int y, MouseEventArgs e)
		{
			bool returnValue = false;
			int eqNum = 0;
			int invNum = 0;
			int slotnum = 0;
			int hotbarslot = 0;
			ByteStream buffer = new ByteStream();
			
			returnValue = false;
			//action panel
			if (C_UpdateUI.HudVisible && C_Variables.HideGui == false)
			{
				if (AboveActionPanel(x, y))
				{
					// left click
					if (e.Button == MouseButtons.Left)
					{
						//Inventory
						if (x > C_UpdateUI.ActionPanelX + C_UpdateUI.InvBtnX && x < C_UpdateUI.ActionPanelX + C_UpdateUI.InvBtnX + 48 && y > C_UpdateUI.ActionPanelY + C_UpdateUI.InvBtnY && y < C_UpdateUI.ActionPanelY + C_UpdateUI.InvBtnY + 32)
						{
							C_Sound.PlaySound("Click.ogg");
							C_UpdateUI.PnlInventoryVisible = !C_UpdateUI.PnlInventoryVisible;
							C_UpdateUI.PnlCharacterVisible = false;
							C_UpdateUI.PnlSkillsVisible = false;
							returnValue = true;
							//Skills
						}
						else if (x > C_UpdateUI.ActionPanelX + C_UpdateUI.SkillBtnX && x < C_UpdateUI.ActionPanelX + C_UpdateUI.SkillBtnX + 48 && y > C_UpdateUI.ActionPanelY + C_UpdateUI.SkillBtnY && y < C_UpdateUI.ActionPanelY + C_UpdateUI.SkillBtnY + 32)
						{
							C_Sound.PlaySound("Click.ogg");
							buffer = new ByteStream(4);
							buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSkills);
							C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
							buffer.Dispose();
							C_UpdateUI.PnlSkillsVisible = !C_UpdateUI.PnlSkillsVisible;
							C_UpdateUI.PnlInventoryVisible = false;
							C_UpdateUI.PnlCharacterVisible = false;
							returnValue = true;
							//Char
						}
						else if (x > C_UpdateUI.ActionPanelX + C_UpdateUI.CharBtnX && x < C_UpdateUI.ActionPanelX + C_UpdateUI.CharBtnX + 48 && y > C_UpdateUI.ActionPanelY + C_UpdateUI.CharBtnY && y < C_UpdateUI.ActionPanelY + C_UpdateUI.CharBtnY + 32)
						{
							C_Sound.PlaySound("Click.ogg");
							C_NetworkSend.SendRequestPlayerData();
							C_UpdateUI.PnlCharacterVisible = !C_UpdateUI.PnlCharacterVisible;
							C_UpdateUI.PnlInventoryVisible = false;
							C_UpdateUI.PnlSkillsVisible = false;
							returnValue = true;
							//Quest
						}
						else if (x > C_UpdateUI.ActionPanelX + C_UpdateUI.QuestBtnX && x < C_UpdateUI.ActionPanelX + C_UpdateUI.QuestBtnX + 48 && y > C_UpdateUI.ActionPanelY + C_UpdateUI.QuestBtnY && y < C_UpdateUI.ActionPanelY + C_UpdateUI.QuestBtnY + 32)
						{
							C_Quest.UpdateQuestLog();
							// show the window
							C_UpdateUI.PnlInventoryVisible = false;
							C_UpdateUI.PnlCharacterVisible = false;
							C_Quest.RefreshQuestLog();
							C_Quest.PnlQuestLogVisible = !C_Quest.PnlQuestLogVisible;
							returnValue = true;
							//Options
						}
						else if (x > C_UpdateUI.ActionPanelX + C_UpdateUI.OptBtnX && x < C_UpdateUI.ActionPanelX + C_UpdateUI.OptBtnX + 48 && y > C_UpdateUI.ActionPanelY + C_UpdateUI.OptBtnY && y < C_UpdateUI.ActionPanelY + C_UpdateUI.OptBtnY + 32)
						{
							C_Sound.PlaySound("Click.ogg");
							C_UpdateUI.PnlCharacterVisible = false;
							C_UpdateUI.PnlInventoryVisible = false;
							C_UpdateUI.PnlSkillsVisible = false;
							
							C_UpdateUI.OptionsVisible = !C_UpdateUI.OptionsVisible;
							FrmOptions.Default.BringToFront();
							returnValue = true;
							//Exit
						}
						else if (x > C_UpdateUI.ActionPanelX + C_UpdateUI.ExitBtnX && x < C_UpdateUI.ActionPanelX + C_UpdateUI.ExitBtnX + 48 && y > C_UpdateUI.ActionPanelY + C_UpdateUI.ExitBtnY && y < C_UpdateUI.ActionPanelY + C_UpdateUI.ExitBtnY + 32)
						{
							C_Sound.PlaySound("Click.ogg");
							FrmAdmin.Default.Dispose();
							C_NetworkSend.SendLeaveGame();
							//DestroyGame()
							
							returnValue = true;
						}
					}
				}
				
				//hotbar
				if (AboveHotbar(x, y))
				{
					
					hotbarslot = C_HotBar.IsHotBarSlot(e.Location.X, e.Location.Y);
					
					if (e.Button == MouseButtons.Left)
					{
						if (hotbarslot > 0)
						{
							slotnum = C_Types.Player[C_Variables.Myindex].Hotbar[hotbarslot].Slot;
							
							if (slotnum != 0)
							{
								C_Sound.PlaySound("Click.ogg");
								C_HotBar.SendUseHotbarSlot(hotbarslot);
							}
							
							returnValue = true;
						}
					}
					else if (e.Button == MouseButtons.Right) // right click
					{
						if (C_Types.Player[C_Variables.Myindex].Hotbar[hotbarslot].Slot > 0)
						{
							//forget hotbar skill
							DialogResult result1 = MessageBox.Show("Want to Delete this from your hotbar?", C_Constants.GameName, MessageBoxButtons.YesNo);
							if (result1 == DialogResult.Yes)
							{
								C_HotBar.SendDeleteHotbar(C_HotBar.IsHotBarSlot(e.Location.X, e.Location.Y));
							}
							
							returnValue = true;
						}
						else
						{
							buffer = new ByteStream(4);
							buffer.WriteInt32((System.Int32) Packets.ClientPackets.CSkills);
							C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
							buffer.Dispose();
							C_UpdateUI.PnlSkillsVisible = true;
							C_Text.AddText("Click on the skill you want to place here", (System.Int32) Enums.QColorType.TellColor);
							C_HotBar.SelSkillSlot = true;
							C_HotBar.SelHotbarSlot = C_HotBar.IsHotBarSlot(e.Location.X, e.Location.Y);
						}
					}
					returnValue = true;
				}
				
				if (AbovePetbar(x, y))
				{
					if (C_Types.Player[C_Variables.Myindex].Pet.Num > 0)
					{
						hotbarslot = C_Pets.IsPetBarSlot(e.Location.X, e.Location.Y);
						
						if (e.Button == MouseButtons.Left)
						{
							if (hotbarslot > 0)
							{
								if (hotbarslot >= 1 && hotbarslot <= 4)
								{
									if (hotbarslot == 1)
									{
										//summon
										C_Pets.SendSummonPet();
									}
									else if (hotbarslot == 2)
									{
										C_Pets.SendPetBehaviour(C_Pets.PetAttackBehaviourAttackonsight);
									}
									else if (hotbarslot == 3)
									{
										C_Pets.SendPetBehaviour(C_Pets.PetAttackBehaviourGuard);
									}
                                    else if (hotbarslot == 4)
									{
										C_Pets.SendPetMount();
									}
									
								}
								else if (hotbarslot >= 5 && hotbarslot <= 8)
								{
									slotnum = System.Convert.ToInt32(C_Types.Player[C_Variables.Myindex].Pet.Skill[hotbarslot - 3]);
									
									if (slotnum != 0)
									{
										C_Sound.PlaySound("Click.ogg");
										C_Pets.SendUsePetSkill(slotnum);
									}
								}
								
								returnValue = true;
							}
						}
						
						returnValue = true;
					}
				}
				
			}
			
			//Charpanel
			if (C_UpdateUI.PnlCharacterVisible)
			{
				if (AboveCharpanel(x, y))
				{
					// left click
					if (e.Button == MouseButtons.Left)
					{
						
						//lets see if they want to upgrade
						//Strenght
						if (x > C_UpdateUI.CharWindowX + C_UpdateUI.StrengthUpgradeX && x < C_UpdateUI.CharWindowX + C_UpdateUI.StrengthUpgradeX + 10 && y > C_UpdateUI.CharWindowY + C_UpdateUI.StrengthUpgradeY && y < C_UpdateUI.CharWindowY + C_UpdateUI.StrengthUpgradeY + 10)
						{
							if (!(C_Player.GetPlayerPoints(C_Variables.Myindex) == 0))
							{
								C_Sound.PlaySound("Click.ogg");
								C_NetworkSend.SendTrainStat((byte) 1);
							}
						}
						//Endurance
						if (x > C_UpdateUI.CharWindowX + C_UpdateUI.EnduranceUpgradeX && x < C_UpdateUI.CharWindowX + C_UpdateUI.EnduranceUpgradeX + 10 && y > C_UpdateUI.CharWindowY + C_UpdateUI.EnduranceUpgradeY && y < C_UpdateUI.CharWindowY + C_UpdateUI.EnduranceUpgradeY + 10)
						{
							if (!(C_Player.GetPlayerPoints(C_Variables.Myindex) == 0))
							{
								C_Sound.PlaySound("Click.ogg");
								C_NetworkSend.SendTrainStat((byte) 2);
							}
						}
						//Vitality
						if (x > C_UpdateUI.CharWindowX + C_UpdateUI.VitalityUpgradeX && x < C_UpdateUI.CharWindowX + C_UpdateUI.VitalityUpgradeX + 10 && y > C_UpdateUI.CharWindowY + C_UpdateUI.VitalityUpgradeY && y < C_UpdateUI.CharWindowY + C_UpdateUI.VitalityUpgradeY + 10)
						{
							if (!(C_Player.GetPlayerPoints(C_Variables.Myindex) == 0))
							{
								C_Sound.PlaySound("Click.ogg");
								C_NetworkSend.SendTrainStat((byte) 3);
							}
						}
						//WillPower
						if (x > C_UpdateUI.CharWindowX + C_UpdateUI.LuckUpgradeX && x < C_UpdateUI.CharWindowX + C_UpdateUI.LuckUpgradeX + 10 && y > C_UpdateUI.CharWindowY + C_UpdateUI.LuckUpgradeY && y < C_UpdateUI.CharWindowY + C_UpdateUI.LuckUpgradeY + 10)
						{
							if (!(C_Player.GetPlayerPoints(C_Variables.Myindex) == 0))
							{
								C_Sound.PlaySound("Click.ogg");
								C_NetworkSend.SendTrainStat((byte) 4);
							}
						}
						//Intellect
						if (x > C_UpdateUI.CharWindowX + C_UpdateUI.IntellectUpgradeX && x < C_UpdateUI.CharWindowX + C_UpdateUI.IntellectUpgradeX + 10 && y > C_UpdateUI.CharWindowY + C_UpdateUI.IntellectUpgradeY && y < C_UpdateUI.CharWindowY + C_UpdateUI.IntellectUpgradeY + 10)
						{
							if (!(C_Player.GetPlayerPoints(C_Variables.Myindex) == 0))
							{
								C_Sound.PlaySound("Click.ogg");
								C_NetworkSend.SendTrainStat((byte) 5);
							}
						}
						//Spirit
						if (x > C_UpdateUI.CharWindowX + C_UpdateUI.SpiritUpgradeX && x < C_UpdateUI.CharWindowX + C_UpdateUI.SpiritUpgradeX + 10 && y > C_UpdateUI.CharWindowY + C_UpdateUI.SpiritUpgradeY && y < C_UpdateUI.CharWindowY + C_UpdateUI.SpiritUpgradeY + 10)
						{
							if (!(C_Player.GetPlayerPoints(C_Variables.Myindex) == 0))
							{
								C_Sound.PlaySound("Click.ogg");
								C_NetworkSend.SendTrainStat((byte) 6);
							}
						}
						returnValue = true;
					}
					else if (e.Button == MouseButtons.Right)
					{
						//first check for equip
						eqNum = IsEqItem(x, y);
						
						if (eqNum != 0)
						{
							C_Sound.PlaySound("Click.ogg");
							DialogResult result1 = MessageBox.Show("Want to Unequip this?", C_Constants.GameName, MessageBoxButtons.YesNo);
							if (result1 == DialogResult.Yes)
							{
								C_NetworkSend.SendUnequip(eqNum);
							}
							returnValue = true;
						}
					}
				}
				
				//Inventory panel
			}
			else if (C_UpdateUI.PnlInventoryVisible)
			{
				if (AboveInvpanel(x, y))
				{
					invNum = IsInvItem(e.Location.X, e.Location.Y);
					
					if (e.Button == MouseButtons.Left)
					{
						if (invNum != 0)
						{
							if (C_Trade.InTrade)
							{
								return returnValue;
							}
							if (System.Convert.ToBoolean(C_Banks.InBank != 0 || C_Shops.InShop != 0))
							{
								return returnValue;
							}
							
							if (Types.Item[C_Player.GetPlayerInvItemNum(C_Variables.Myindex, invNum)].Type == (byte)Enums.ItemType.Furniture)
							{
								C_Sound.PlaySound("Click.ogg");
								C_Housing.FurnitureSelected = invNum;
								returnValue = true;
							}
							
						}
					}
				}
			}
			
			if (C_UpdateUI.DialogPanelVisible)
			{
				//ok button
				if (x > C_UpdateUI.DialogPanelX + C_UpdateUI.OkButtonX && x < C_UpdateUI.DialogPanelX + C_UpdateUI.OkButtonX + C_Graphics.ButtonGfxInfo.Width && y > C_UpdateUI.DialogPanelY + C_UpdateUI.OkButtonY && y < C_UpdateUI.DialogPanelY + C_UpdateUI.OkButtonY + C_Graphics.ButtonGfxInfo.Height)
				{
					C_UpdateUI.VbKeyDown = false;
					C_UpdateUI.VbKeyUp = false;
					C_UpdateUI.VbKeyLeft = false;
					C_UpdateUI.VbKeyRight = false;
					
					if (C_Variables.DialogType == C_Constants.DialogueTypeBuyhome) //house offer
					{
						C_Housing.SendBuyHouse((byte) 1);
					}
					else if (C_Variables.DialogType == C_Constants.DialogueTypeVisit)
					{
						C_Housing.SendVisit((byte) 1);
					}
					else if (C_Variables.DialogType == C_Constants.DialogueTypeParty)
					{
						C_Parties.SendAcceptParty();
					}
					else if (C_Variables.DialogType == C_Constants.DialogueTypeQuest)
					{
						if (C_Quest.QuestAcceptTag > 0)
						{
							C_Quest.PlayerHandleQuest(C_Quest.QuestAcceptTag, 1);
							C_Quest.QuestAcceptTag = 0;
							C_Quest.RefreshQuestLog();
						}
					}
					else if (C_Variables.DialogType == C_Constants.DialogueTypeTrade)
					{
						C_Trade.SendTradeInviteAccept((byte) 1);
					}
					
					C_Sound.PlaySound("Click.ogg");
					C_UpdateUI.DialogPanelVisible = false;
				}
				//cancel button
				if (x > C_UpdateUI.DialogPanelX + C_UpdateUI.CancelButtonX && x < C_UpdateUI.DialogPanelX + C_UpdateUI.CancelButtonX + C_Graphics.ButtonGfxInfo.Width && y > C_UpdateUI.DialogPanelY + C_UpdateUI.CancelButtonY && y < C_UpdateUI.DialogPanelY + C_UpdateUI.CancelButtonY + C_Graphics.ButtonGfxInfo.Height)
				{
					C_UpdateUI.VbKeyDown = false;
					C_UpdateUI.VbKeyUp = false;
					C_UpdateUI.VbKeyLeft = false;
					C_UpdateUI.VbKeyRight = false;
					
					if (C_Variables.DialogType == C_Constants.DialogueTypeBuyhome) //house offer declined
					{
						C_Housing.SendBuyHouse((byte) 0);
					}
					else if (Convert.ToBoolean(C_Constants.DialogueTypeVisit)) //visit declined
					{
						C_Housing.SendVisit((byte) 0);
					}
					else if (Convert.ToBoolean(C_Constants.DialogueTypeParty)) //party declined
					{
						C_Parties.SendLeaveParty();
					}
					else if (Convert.ToBoolean(C_Constants.DialogueTypeQuest)) //quest declined
					{
						C_Quest.QuestAcceptTag = 0;
					}
					else if (C_Variables.DialogType == C_Constants.DialogueTypeTrade)
					{
						C_Trade.SendTradeInviteAccept((byte) 0);
					}
					C_Sound.PlaySound("Click.ogg");
					C_UpdateUI.DialogPanelVisible = false;
				}
				returnValue = true;
			}
			
			if (C_UpdateUI.PnlBankVisible == true)
			{
				if (AboveBankpanel(x, y))
				{
					if (x > C_UpdateUI.BankWindowX + 140 && x < C_UpdateUI.BankWindowX + 140 + C_Text.GetTextWidth("Close Bank", (byte) 15))
					{
						if (y > C_UpdateUI.BankWindowY + C_Graphics.BankPanelGfxInfo.Height - 15 && y < C_UpdateUI.BankWindowY + C_Graphics.BankPanelGfxInfo.Height)
						{
							C_Sound.PlaySound("Click.ogg");
							C_Banks.CloseBank();
						}
					}
					returnValue = true;
				}
			}
			
			//trade
			if (C_UpdateUI.PnlTradeVisible == true)
			{
				if (AboveTradepanel(x, y))
				{
					//accept button
					if (x > C_UpdateUI.TradeWindowX + C_UpdateUI.TradeButtonAcceptX && x < C_UpdateUI.TradeWindowX + C_UpdateUI.TradeButtonAcceptX + C_Graphics.ButtonGfxInfo.Width)
					{
						if (y > C_UpdateUI.TradeWindowY + C_UpdateUI.TradeButtonAcceptY && y < C_UpdateUI.TradeWindowY + C_UpdateUI.TradeButtonAcceptY + C_Graphics.ButtonGfxInfo.Height)
						{
							C_Sound.PlaySound("Click.ogg");
							C_Trade.AcceptTrade();
						}
					}
					
					//decline button
					if (x > C_UpdateUI.TradeWindowX + C_UpdateUI.TradeButtonDeclineX && x < C_UpdateUI.TradeWindowX + C_UpdateUI.TradeButtonDeclineX + C_Graphics.ButtonGfxInfo.Width)
					{
						if (y > C_UpdateUI.TradeWindowY + C_UpdateUI.TradeButtonDeclineY && y < C_UpdateUI.TradeWindowY + C_UpdateUI.TradeButtonDeclineY + C_Graphics.ButtonGfxInfo.Height)
						{
							C_Sound.PlaySound("Click.ogg");
							C_Trade.DeclineTrade();
						}
					}
					
					returnValue = true;
				}
				
			}
			
			//eventchat
			if (C_UpdateUI.PnlEventChatVisible == true)
			{
				if (AboveEventChat(x, y))
				{
					//Response1
					if (C_EventSystem.EventChoiceVisible[1])
					{
						if (x > C_UpdateUI.EventChatX + 10 && x < C_UpdateUI.EventChatX + 10 + C_Text.GetTextWidth(C_EventSystem.EventChoices[1]))
						{
							if (y > C_UpdateUI.EventChatY + 124 && y < C_UpdateUI.EventChatY + 124 + 13)
							{
								C_Sound.PlaySound("Click.ogg");
								buffer = new ByteStream(4);
								buffer.WriteInt32((System.Int32) Packets.ClientPackets.CEventChatReply);
								buffer.WriteInt32(C_EventSystem.EventReplyId);
								buffer.WriteInt32(C_EventSystem.EventReplyPage);
								buffer.WriteInt32(1);
								C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
								buffer.Dispose();
								C_EventSystem.ClearEventChat();
								C_EventSystem.InEvent = false;
							}
						}
					}
					
					//Response2
					if (C_EventSystem.EventChoiceVisible[2])
					{
						if (x > C_UpdateUI.EventChatX + 10 && x < C_UpdateUI.EventChatX + 10 + C_Text.GetTextWidth(C_EventSystem.EventChoices[2]))
						{
							if (y > C_UpdateUI.EventChatY + 146 && y < C_UpdateUI.EventChatY + 146 + 13)
							{
								C_Sound.PlaySound("Click.ogg");
								buffer = new ByteStream(4);
								buffer.WriteInt32((System.Int32) Packets.ClientPackets.CEventChatReply);
								buffer.WriteInt32(C_EventSystem.EventReplyId);
								buffer.WriteInt32(C_EventSystem.EventReplyPage);
								buffer.WriteInt32(2);
								C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
								buffer.Dispose();
								C_EventSystem.ClearEventChat();
								C_EventSystem.InEvent = false;
							}
						}
					}
					
					//Response3
					if (C_EventSystem.EventChoiceVisible[3])
					{
						if (x > C_UpdateUI.EventChatX + 226 && x < C_UpdateUI.EventChatX + 226 + C_Text.GetTextWidth(C_EventSystem.EventChoices[3]))
						{
							if (y > C_UpdateUI.EventChatY + 124 && y < C_UpdateUI.EventChatY + 124 + 13)
							{
								C_Sound.PlaySound("Click.ogg");
								buffer = new ByteStream(4);
								buffer.WriteInt32((System.Int32) Packets.ClientPackets.CEventChatReply);
								buffer.WriteInt32(C_EventSystem.EventReplyId);
								buffer.WriteInt32(C_EventSystem.EventReplyPage);
								buffer.WriteInt32(3);
								C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
								buffer.Dispose();
								C_EventSystem.ClearEventChat();
								C_EventSystem.InEvent = false;
							}
						}
					}
					
					//Response4
					if (C_EventSystem.EventChoiceVisible[4])
					{
						if (x > C_UpdateUI.EventChatX + 226 && x < C_UpdateUI.EventChatX + 226 + C_Text.GetTextWidth(C_EventSystem.EventChoices[4]))
						{
							if (y > C_UpdateUI.EventChatY + 146 && y < C_UpdateUI.EventChatY + 146 + 13)
							{
								C_Sound.PlaySound("Click.ogg");
								buffer = new ByteStream(4);
								buffer.WriteInt32((System.Int32) Packets.ClientPackets.CEventChatReply);
								buffer.WriteInt32(C_EventSystem.EventReplyId);
								buffer.WriteInt32(C_EventSystem.EventReplyPage);
								buffer.WriteInt32(4);
								C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
								buffer.Dispose();
								C_EventSystem.ClearEventChat();
								C_EventSystem.InEvent = false;
							}
						}
					}
					
					//continue
					if (C_EventSystem.EventChatType != 1)
					{
						if (x > C_UpdateUI.EventChatX + 410 && x < C_UpdateUI.EventChatX + 410 + C_Text.GetTextWidth("Continue"))
						{
							if (y > C_UpdateUI.EventChatY + 156 && y < C_UpdateUI.EventChatY + 156 + 13)
							{
								C_Sound.PlaySound("Click.ogg");
								buffer = new ByteStream(4);
								buffer.WriteInt32((System.Int32) Packets.ClientPackets.CEventChatReply);
								buffer.WriteInt32(C_EventSystem.EventReplyId);
								buffer.WriteInt32(C_EventSystem.EventReplyPage);
								buffer.WriteInt32(0);
								C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
								buffer.Dispose();
								C_EventSystem.ClearEventChat();
								C_EventSystem.InEvent = false;
							}
						}
					}
					returnValue = true;
				}
			}
			
			//right click
			if (C_UpdateUI.PnlRClickVisible == true)
			{
				if (AboveRClickPanel(x, y))
				{
					//trade
					if (x > C_UpdateUI.RClickX + (C_Graphics.RClickGfxInfo.Width / 2) - (C_Text.GetTextWidth("Invite to Trade") / 2) && x < C_UpdateUI.RClickX + (C_Graphics.RClickGfxInfo.Width / 2) - (C_Text.GetTextWidth("Invite to Trade") / 2) + C_Text.GetTextWidth("Invite to Trade"))
					{
						if (y > C_UpdateUI.RClickY + 35 && y < C_UpdateUI.RClickY + 35 + 12)
						{
							if (C_Variables.MyTarget > 0)
							{
								C_Trade.SendTradeRequest(C_Types.Player[C_Variables.MyTarget].Name);
							}
							C_UpdateUI.PnlRClickVisible = false;
						}
					}
					
					//party
					if (x > C_UpdateUI.RClickX + (C_Graphics.RClickGfxInfo.Width / 2) - (C_Text.GetTextWidth("Invite to Party") / 2) && x < C_UpdateUI.RClickX + (C_Graphics.RClickGfxInfo.Width / 2) - (C_Text.GetTextWidth("Invite to Party") / 2) + C_Text.GetTextWidth("Invite to Party"))
					{
						if (y > C_UpdateUI.RClickY + 60 && y < C_UpdateUI.RClickY + 60 + 12)
						{
							if (C_Variables.MyTarget > 0)
							{
								C_Parties.SendPartyRequest(C_Types.Player[C_Variables.MyTarget].Name);
							}
							C_UpdateUI.PnlRClickVisible = false;
						}
					}
					
					//House
					if (x > C_UpdateUI.RClickX + (C_Graphics.RClickGfxInfo.Width / 2) - (C_Text.GetTextWidth("Invite to House") / 2) && x < C_UpdateUI.RClickX + (C_Graphics.RClickGfxInfo.Width / 2) - (C_Text.GetTextWidth("Invite to House") / 2) + C_Text.GetTextWidth("Invite to House"))
					{
						if (y > C_UpdateUI.RClickY + 85 && y < C_UpdateUI.RClickY + 85 + 12)
						{
							if (C_Variables.MyTarget > 0)
							{
								C_Housing.SendInvite(C_Types.Player[C_Variables.MyTarget].Name);
							}
							C_UpdateUI.PnlRClickVisible = false;
						}
					}
					
					returnValue = true;
				}
			}
			
			if (C_Quest.PnlQuestLogVisible)
			{
				if (AboveQuestPanel(x, y))
				{
					//check if they press the list
					int tmpy = 10;
					for (var i = 1; i <= C_Quest.MaxActivequests; i++)
					{
						if (C_Quest.QuestNames[(int) i].Trim().Length > 0)
						{
							if (x > (C_Quest.QuestLogX + 7) && x < (C_Quest.QuestLogX + 7) + (C_Text.GetTextWidth(C_Quest.QuestNames[(int) i])))
							{
								if (y > (C_Quest.QuestLogY + tmpy) && y < (C_Quest.QuestLogY + tmpy + 13))
								{
									C_Quest.SelectedQuest = System.Convert.ToInt32(i);
									C_Quest.LoadQuestlogBox();
								}
							}
							tmpy = tmpy + 20;
						}
					}
					
					//close button
					if (x > (C_Quest.QuestLogX + 195) && x < (C_Quest.QuestLogX + 290))
					{
						if (y > (C_Quest.QuestLogY + 358) && y < (C_Quest.QuestLogY + 375))
						{
							C_Quest.ResetQuestLog();
						}
						
						returnValue = true;
					}
				}
			}
			
			if (C_Crafting.PnlCraftVisible)
			{
				if (AboveCraftPanel(x, y))
				{
					//check if they press the list
					int tmpy = 10;
					for (var i = 1; i <= Constants.MAX_RECIPE; i++)
					{
						if (C_Crafting.RecipeNames[(int) i].Trim().Length > 0)
						{
							if (x > (C_UpdateUI.CraftPanelX + 12) && x < (C_UpdateUI.CraftPanelX + 12) + (C_Text.GetTextWidth(C_Crafting.RecipeNames[(int) i])))
							{
								if (y > (C_UpdateUI.CraftPanelY + tmpy) && y < (C_UpdateUI.CraftPanelY + tmpy + 13))
								{
									C_Crafting.SelectedRecipe = System.Convert.ToInt32(i);
									C_Crafting.CraftingInit();
								}
							}
							tmpy = tmpy + 20;
						}
					}
					
					//start button
					if (x > (C_UpdateUI.CraftPanelX + 256) && x < (C_UpdateUI.CraftPanelX + 330))
					{
						if (y > (C_UpdateUI.CraftPanelY + 415) && y < (C_UpdateUI.CraftPanelY + 437))
						{
							if (C_Crafting.SelectedRecipe > 0)
							{
								C_Crafting.CraftProgressValue = 0;
								C_Crafting.SendCraftIt(C_Crafting.RecipeNames[C_Crafting.SelectedRecipe], C_Crafting.CraftAmountValue);
							}
						}
					}
					
					//close button
					if (x > (C_UpdateUI.CraftPanelX + 614) && x < (C_UpdateUI.CraftPanelX + 689))
					{
						if (y > (C_UpdateUI.CraftPanelY + 472) && y < (C_UpdateUI.CraftPanelY + 494))
						{
							C_Crafting.ResetCraftPanel();
							C_Crafting.PnlCraftVisible = false;
							C_Crafting.InCraft = false;
							C_Crafting.SendCloseCraft();
						}
					}
					
					//minus
					if (x > (C_UpdateUI.CraftPanelX + 340) && x < (C_UpdateUI.CraftPanelX + 340 + 10))
					{
						if (y > (C_UpdateUI.CraftPanelY + 422) && y < (C_UpdateUI.CraftPanelY + 422 + 10))
						{
							if (C_Crafting.CraftAmountValue > 1)
							{
								C_Crafting.CraftAmountValue--;
							}
						}
					}
					
					//plus
					if (x > (C_UpdateUI.CraftPanelX + 392) && x < (C_UpdateUI.CraftPanelX + 392 + 10))
					{
						if (y > (C_UpdateUI.CraftPanelY + 422) && y < (C_UpdateUI.CraftPanelY + 422 + 10))
						{
							if (C_Crafting.CraftAmountValue < 100)
							{
								C_Crafting.CraftAmountValue++;
							}
						}
					}
					
					return true;
				}
			}
			
			return returnValue;
		}
		
		internal static bool CheckGuiDoubleClick(int x, int y, MouseEventArgs e)
		{
			int invNum = 0;
			int skillnum = 0;
			int bankItem = 0;
			int value = 0;
			int tradeNum = 0;
			double multiplier = 0;
			int i = 0;
			
			if (C_UpdateUI.PnlInventoryVisible)
			{
				if (AboveInvpanel(x, y))
				{
					C_Items.DragInvSlotNum = 0;
					invNum = IsInvItem(C_Items.InvX, C_Items.InvY);
					
					if (invNum != 0)
					{
						
						// are we in a shop
						if (C_Shops.InShop > 0)
						{
							if (C_Shops.ShopAction == ((byte) 0)) // nothing, give value
							{
								multiplier = (double) Types.Shop[C_Shops.InShop].BuyRate / 100;
								value = System.Convert.ToInt32(Types.Item[C_Player.GetPlayerInvItemNum(C_Variables.Myindex, invNum)].Price * multiplier);
								if (value > 0)
								{
									C_Text.AddText("You can sell this item for " + System.Convert.ToString(value) + " gold.", (System.Int32) Enums.QColorType.TellColor);
								}
								else
								{
									C_Text.AddText("The shop does not want this item.", (System.Int32) Enums.QColorType.AlertColor);
								}
							} // 2 = sell
							else if (C_Shops.ShopAction == ((byte) 2))
							{
								C_Shops.SellItem(invNum);
							}
							
							return false;
						}
						
						// in bank
						if (System.Convert.ToBoolean(C_Banks.InBank))
						{
							if (Types.Item[C_Player.GetPlayerInvItemNum(C_Variables.Myindex, invNum)].Type == (byte)Enums.ItemType.Currency || Types.Item[C_Player.GetPlayerInvItemNum(C_Variables.Myindex, invNum)].Stackable == 1)
							{
								C_Variables.CurrencyMenu = (byte) 2; // deposit
								FrmGame.Default.lblCurrency.Text = "How many do you want to deposit?";
								C_Variables.TmpCurrencyItem = invNum;
								FrmGame.Default.txtCurrency.Text = "";
								FrmGame.Default.pnlCurrency.Visible = true;
								FrmGame.Default.pnlCurrency.BringToFront();
								FrmGame.Default.txtCurrency.Focus();
								return false;
							}
							C_Banks.DepositItem(invNum, 0);
							return false;
						}
						
						// in trade
						if (C_Trade.InTrade == true)
						{
							// exit out if we're offering that item
							for (i = 1; i <= Constants.MAX_INV; i++)
							{
								if (C_Trade.TradeYourOffer[i].Num == invNum)
								{
									return false;
								}
							}
							if (Types.Item[C_Player.GetPlayerInvItemNum(C_Variables.Myindex, invNum)].Type == (byte)Enums.ItemType.Currency || Types.Item[C_Player.GetPlayerInvItemNum(C_Variables.Myindex, invNum)].Stackable == 1)
							{
								C_Variables.CurrencyMenu = (byte) 4; // trade
								FrmGame.Default.lblCurrency.Text = "How many do you want to trade?";
								C_Variables.TmpCurrencyItem = invNum;
								FrmGame.Default.txtCurrency.Text = "";
								FrmGame.Default.pnlCurrency.Visible = true;
								FrmGame.Default.pnlCurrency.BringToFront();
								FrmGame.Default.txtCurrency.Focus();
								return false;
							}
							C_Trade.TradeItem(invNum, 0);
							return false;
						}
						
						// use item if not doing anything else
						if (Types.Item[C_Player.GetPlayerInvItemNum(C_Variables.Myindex, invNum)].Type == (byte)Enums.ItemType.None)
						{
							return false;
						}
						C_NetworkSend.SendUseItem(invNum);
						return false;
					}
				}
			}
			
			//Skill panel
			if (C_UpdateUI.PnlSkillsVisible == true)
			{
				if (AboveSkillpanel(x, y))
				{
					
					skillnum = IsPlayerSkill(C_Variables.SkillX, C_Variables.SkillY);
					
					if (skillnum != 0)
					{
						C_Player.PlayerCastSkill(skillnum);
						return false;
					}
				}
			}
			
			//Bank panel
			if (C_UpdateUI.PnlBankVisible == true)
			{
				if (AboveBankpanel(x, y))
				{
					
					C_Banks.DragBankSlotNum = 0;
					
					bankItem = IsBankItem(C_Banks.BankX, C_Banks.BankY);
					if (bankItem != 0)
					{
						if (C_GameLogic.GetBankItemNum((byte) bankItem) == (int) Enums.ItemType.None)
						{
							return false;
						}
						
						if (Types.Item[C_GameLogic.GetBankItemNum((byte) bankItem)].Type == (byte)Enums.ItemType.Currency || Types.Item[C_GameLogic.GetBankItemNum((byte) bankItem)].Stackable == 1)
						{
							C_Variables.CurrencyMenu = (byte) 3; // withdraw
							FrmGame.Default.lblCurrency.Text = "How many do you want to withdraw?";
							C_Variables.TmpCurrencyItem = bankItem;
							FrmGame.Default.txtCurrency.Text = "";
							FrmGame.Default.pnlCurrency.Visible = true;
							FrmGame.Default.txtCurrency.Focus();
							return false;
						}
						
						C_Banks.WithdrawItem(bankItem, 0);
						return false;
					}
				}
			}
			
			//trade panel
			if (C_UpdateUI.PnlTradeVisible == true)
			{
				//ours
				if (AboveTradepanel(x, y))
				{
					tradeNum = IsTradeItem(C_Trade.TradeX, C_Trade.TradeY, true);
					
					if (tradeNum != 0)
					{
						C_Trade.UntradeItem(tradeNum);
					}
				}
			}
            return false;
        }
		
		internal static bool CheckGuiMouseUp(int x, int y, MouseEventArgs e)
		{
			int i = 0;
			Rectangle recPos = new Rectangle();
			ByteStream buffer = new ByteStream();
			int hotbarslot = 0;
			
			//Inventory
			if (C_UpdateUI.PnlInventoryVisible)
			{
				if (AboveInvpanel(x, y))
				{
					if (C_Trade.InTrade)
					{
						return false;
					}
					if (System.Convert.ToBoolean(C_Banks.InBank != 0 || C_Shops.InShop != 0))
					{
						return false;
					}
					
					if (C_Items.DragInvSlotNum > 0)
					{
						
						for (i = 1; i <= Constants.MAX_INV; i++)
						{
							
							recPos.Y = C_UpdateUI.InvWindowY + C_UpdateUI.InvTop + ((C_UpdateUI.InvOffsetY + 32) * ((i - 1) / C_UpdateUI.InvColumns));
							recPos.Height = C_Constants.PicY;
							recPos.X = C_UpdateUI.InvWindowX + C_UpdateUI.InvLeft + ((C_UpdateUI.InvOffsetX + 32) * ((i - 1) % C_UpdateUI.InvColumns));
							recPos.Width = C_Constants.PicX;
							
							if (e.Location.X >= recPos.Left && e.Location.X <= recPos.Right)
							{
								if (e.Location.Y >= recPos.Top && e.Location.Y <= recPos.Bottom) //
								{
									if (C_Items.DragInvSlotNum != i)
									{
										C_NetworkSend.SendChangeInvSlots(C_Items.DragInvSlotNum, i);
										break;
									}
								}
							}
							
						}
						
					}
					
					C_Items.DragInvSlotNum = 0;
				}
				else if (AboveHotbar(x, y))
				{
					if (C_Items.DragInvSlotNum > 0)
					{
						hotbarslot = C_HotBar.IsHotBarSlot(e.Location.X, e.Location.Y);
						if (hotbarslot > 0)
						{
							C_HotBar.SendSetHotbarSlot(hotbarslot, C_Items.DragInvSlotNum, 2);
						}
					}
					
					C_Items.DragInvSlotNum = 0;
				}
				else
				{
					if (C_Housing.FurnitureSelected > 0)
					{
						if (C_Types.Player[C_Variables.Myindex].InHouse == C_Variables.Myindex)
						{
							if (Types.Item[C_Variables.PlayerInv[C_Housing.FurnitureSelected].Num].Type == (byte)Enums.ItemType.Furniture)
							{
								buffer = new ByteStream(4);
								buffer.WriteInt32((System.Int32) Packets.ClientPackets.CPlaceFurniture);
								i = C_Variables.CurX;
								buffer.WriteInt32(i);
								i = C_Variables.CurY;
								buffer.WriteInt32(i);
								buffer.WriteInt32(C_Housing.FurnitureSelected);
								C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
								buffer.Dispose();
								
								C_Housing.FurnitureSelected = 0;
							}
						}
					}
				}
			}
			
			//skills
			if (C_UpdateUI.PnlSkillsVisible)
			{
				if (AboveSkillpanel(x, y))
				{
					if (C_Trade.InTrade)
					{
						return false;
					}
					if (System.Convert.ToBoolean(C_Banks.InBank != 0 || C_Shops.InShop != 0))
					{
						return false;
					}
					
					if (C_Variables.DragSkillSlotNum > 0)
					{
						
						for (i = 1; i <= Constants.MAX_PLAYER_SKILLS; i++)
						{
							
							recPos.Y = C_UpdateUI.SkillWindowY + C_UpdateUI.SkillTop + ((C_UpdateUI.SkillOffsetY + 32) * ((i - 1) / C_UpdateUI.SkillColumns));
							recPos.Height = C_Constants.PicY;
							recPos.X = C_UpdateUI.SkillWindowX + C_UpdateUI.SkillLeft + ((C_UpdateUI.SkillOffsetX + 32) * ((i - 1) % C_UpdateUI.SkillColumns));
							recPos.Width = C_Constants.PicX;
							
							if (e.Location.X >= recPos.Left && e.Location.X <= recPos.Right)
							{
								if (e.Location.Y >= recPos.Top && e.Location.Y <= recPos.Bottom) //
								{
									if (C_Variables.DragSkillSlotNum != i)
									{
										//SendChangeSkillSlots(DragSkillSlotNum, i)
										break;
									}
								}
							}
							
						}
						
					}
					
					C_Variables.DragSkillSlotNum = 0;
				}
				else if (AboveHotbar(x, y))
				{
					if (C_Variables.DragSkillSlotNum > 0)
					{
						hotbarslot = C_HotBar.IsHotBarSlot(e.Location.X, e.Location.Y);
						if (hotbarslot > 0)
						{
							C_HotBar.SendSetHotbarSlot(hotbarslot, C_Variables.DragSkillSlotNum, 1);
						}
					}
					
					C_Variables.DragSkillSlotNum = 0;
				}
			}
			
			//bank
			if (C_UpdateUI.PnlBankVisible == true)
			{
				if (AboveBankpanel(x, y))
				{
					// TODO : Add sub to change bankslots client side first so there's no delay in switching
					if (C_Banks.DragBankSlotNum > 0)
					{
						for (i = 1; i <= Constants.MAX_BANK; i++)
						{
							recPos.Y = C_UpdateUI.BankWindowY + C_UpdateUI.BankTop + ((C_UpdateUI.BankOffsetY + 32) * ((i - 1) / C_UpdateUI.BankColumns));
							recPos.Height = C_Constants.PicY;
							recPos.X = C_UpdateUI.BankWindowX + C_UpdateUI.BankLeft + ((C_UpdateUI.BankOffsetX + 32) * ((i - 1) % C_UpdateUI.BankColumns));
							recPos.Width = C_Constants.PicX;
							
							if (x >= recPos.Left && x <= recPos.Right)
							{
								if (y >= recPos.Top && y <= recPos.Bottom)
								{
									if (C_Banks.DragBankSlotNum != i)
									{
										C_Banks.ChangeBankSlots(C_Banks.DragBankSlotNum, i);
										break;
									}
								}
							}
						}
					}
					
					C_Banks.DragBankSlotNum = 0;
				}
			}
            return false;
        }
		
		internal static bool CheckGuiMouseDown(int x, int y, MouseEventArgs e)
		{
			int invNum = 0;
			int skillnum = 0;
			int bankNum = 0;
			int shopItem = 0;
			
			//Inventory
			if (C_UpdateUI.PnlInventoryVisible)
			{
				if (AboveInvpanel(x, y))
				{
					invNum = IsInvItem(e.Location.X, e.Location.Y);
					
					if (e.Button == MouseButtons.Left)
					{
						if (invNum != 0)
						{
							if (C_Trade.InTrade)
							{
								return false;
							}
							if (System.Convert.ToBoolean(C_Banks.InBank != 0 || C_Shops.InShop != 0))
							{
								return false;
							}
							C_Items.DragInvSlotNum = invNum;
						}
					}
					else if (e.Button == MouseButtons.Right)
					{
						if (System.Convert.ToBoolean(~C_Banks.InBank != 0 && ~C_Shops.InShop != 0 && !C_Trade.InTrade))
						{
							if (invNum != 0)
							{
								if (Types.Item[C_Player.GetPlayerInvItemNum(C_Variables.Myindex, invNum)].Type == (byte)Enums.ItemType.Currency || Types.Item[C_Player.GetPlayerInvItemNum(C_Variables.Myindex, invNum)].Stackable == 1)
								{
									if (C_Player.GetPlayerInvItemValue(C_Variables.Myindex, invNum) > 0)
									{
										C_Variables.CurrencyMenu = (byte) 1; // drop
										FrmGame.Default.lblCurrency.Text = "How many do you want to drop?";
										C_Variables.TmpCurrencyItem = invNum;
										FrmGame.Default.txtCurrency.Text = "";
										FrmGame.Default.pnlCurrency.Visible = true;
										FrmGame.Default.txtCurrency.Focus();
									}
								}
								else
								{
									C_NetworkSend.SendDropItem(invNum, 0);
								}
							}
						}
					}
				}
			}
			
			//skills
			if (C_UpdateUI.PnlSkillsVisible == true)
			{
				if (AboveSkillpanel(x, y))
				{
					skillnum = IsPlayerSkill(e.Location.X, e.Location.Y);
					if (e.Button == MouseButtons.Left)
					{
						if (skillnum != 0)
						{
							if (C_Trade.InTrade)
							{
								return false;
							}
							
							C_Variables.DragSkillSlotNum = skillnum;
							
							if (C_HotBar.SelSkillSlot == true)
							{
								C_HotBar.SendSetHotbarSlot(C_HotBar.SelHotbarSlot, skillnum, 1);
							}
						}
					}
					else if (e.Button == MouseButtons.Right) // right click
					{
						
						if (skillnum != 0)
						{
							DialogResult result1 = MessageBox.Show("Want to forget this skill?", C_Constants.GameName, MessageBoxButtons.YesNo);
							if (result1 == DialogResult.Yes)
							{
								C_NetworkSend.ForgetSkill(skillnum);
								return false;
							}
						}
					}
				}
			}
			
			//Bank
			if (C_UpdateUI.PnlBankVisible == true)
			{
				if (AboveBankpanel(x, y))
				{
					bankNum = IsBankItem(x, y);
					
					if (bankNum != 0)
					{
						
						if (e.Button == MouseButtons.Left)
						{
							C_Banks.DragBankSlotNum = bankNum;
						}
						
					}
				}
			}
			
			//Shop
			if (C_UpdateUI.PnlShopVisible == true)
			{
				if (AboveShoppanel(x, y))
				{
					shopItem = IsShopItem(x, y);
					
					if (shopItem > 0)
					{
						if (C_Shops.ShopAction == ((byte) 0)) // no action, give cost
						{
							ref var with_1 = ref Types.Shop[C_Shops.InShop].TradeItem[shopItem];
							C_Text.AddText("You can buy this item for " + System.Convert.ToString(with_1.CostValue) + " " + Microsoft.VisualBasic.Strings.Trim(Types.Item[with_1.CostItem].Name) +".", (System.Int32) Enums.ColorType.Yellow);
						} // buy item
						else if (C_Shops.ShopAction == ((byte) 1))
						{
							// buy item code
							C_Shops.BuyItem(shopItem);
						}
					}
					else
					{
						// check for buy button
						if (x > C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonBuyX && x < C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonBuyX + C_Graphics.ButtonGfxInfo.Width)
						{
							if (y > C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonBuyY && y < C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonBuyY + C_Graphics.ButtonGfxInfo.Height)
							{
								if (C_Shops.ShopAction == 1)
								{
									return false;
								}
								C_Shops.ShopAction = (byte) 1; // buying an item
								C_Text.AddText("Click on the item in the shop you wish to buy.", (System.Int32) Enums.ColorType.Yellow);
							}
						}
						// check for sell button
						if (x > C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonSellX && x < C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonSellX + C_Graphics.ButtonGfxInfo.Width)
						{
							if (y > C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonSellY && y < C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonSellY + C_Graphics.ButtonGfxInfo.Height)
							{
								if (C_Shops.ShopAction == 2)
								{
									return false;
								}
								C_Shops.ShopAction = (byte) 2; // selling an item
								C_Text.AddText("Double-click on the item in your inventory you wish to sell.", (System.Int32) Enums.ColorType.Yellow);
							}
						}
						// check for close button
						if (x > C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonCloseX && x < C_UpdateUI.ShopWindowX + C_UpdateUI.ShopButtonCloseX + C_Graphics.ButtonGfxInfo.Width)
						{
							if (y > C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonCloseY && y < C_UpdateUI.ShopWindowY + C_UpdateUI.ShopButtonCloseY + C_Graphics.ButtonGfxInfo.Height)
							{
								ByteStream buffer = new ByteStream();
								buffer = new ByteStream(4);
								buffer.WriteInt32((System.Int32) Packets.ClientPackets.CCloseShop);
								C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
								buffer.Dispose();
								C_UpdateUI.PnlShopVisible = false;
								C_Shops.InShop = 0;
								C_Shops.ShopAction = (byte) 0;
							}
						}
					}
				}
			}
			
			if (C_UpdateUI.HudVisible == true)
			{
				if (AboveChatScrollUp(x, y))
				{
					if (C_Text.ScrollMod + C_Text.FirstLineindex < C_Text.MaxChatDisplayLines)
					{
						C_Text.ScrollMod++;
					}
				}
				if (AboveChatScrollDown(x, y))
				{
					if (C_Text.ScrollMod - 1 >= 0)
					{
						C_Text.ScrollMod--;
					}
				}
			}
            return false;
        }
		
#region Support Functions
		
		public static int IsEqItem(float x, float y)
		{
			int returnValue = 0;
			Types.Rect tempRec = new Types.Rect();
			int i = 0;
			returnValue = 0;
			
			for (i = 1; i <= (int) Enums.EquipmentType.Count - 1; i++)
			{
				
				if (C_Player.GetPlayerEquipment(C_Variables.Myindex, (Enums.EquipmentType)i) > 0 && C_Player.GetPlayerEquipment(C_Variables.Myindex, (Enums.EquipmentType)i) <= Constants.MAX_ITEMS)
				{
					
					tempRec.Top = C_UpdateUI.CharWindowY + C_UpdateUI.EqTop + ((C_UpdateUI.EqOffsetY + 32) * ((i - 1) / C_UpdateUI.EqColumns));
					tempRec.Bottom = tempRec.Top + C_Constants.PicY;
					tempRec.Left = C_UpdateUI.CharWindowX + C_UpdateUI.EqLeft + ((C_UpdateUI.EqOffsetX + 32) * ((i - 1) % C_UpdateUI.EqColumns));
					tempRec.Right = tempRec.Left + C_Constants.PicX;
					
					if (x >= tempRec.Left && x <= tempRec.Right)
					{
						if (y >= tempRec.Top && y <= tempRec.Bottom)
						{
							return i;
							
						}
					}
				}
				
			}
			
			return returnValue;
		}
		
		public static int IsInvItem(float x, float y)
		{
			int returnValue = 0;
			Types.Rect tempRec = new Types.Rect();
			int i = 0;
			returnValue = 0;
			
			for (i = 1; i <= Constants.MAX_INV; i++)
			{
				
				if (C_Player.GetPlayerInvItemNum(C_Variables.Myindex, i) > 0 && C_Player.GetPlayerInvItemNum(C_Variables.Myindex, i) <= Constants.MAX_ITEMS)
				{
					
					tempRec.Top = C_UpdateUI.InvWindowY + C_UpdateUI.InvTop + ((C_UpdateUI.InvOffsetY + 32) * ((i - 1) / C_UpdateUI.InvColumns));
					tempRec.Bottom = tempRec.Top + C_Constants.PicY;
					tempRec.Left = C_UpdateUI.InvWindowX + C_UpdateUI.InvLeft + ((C_UpdateUI.InvOffsetX + 32) * ((i - 1) % C_UpdateUI.InvColumns));
					tempRec.Right = tempRec.Left + C_Constants.PicX;
					
					if (x >= tempRec.Left && x <= tempRec.Right)
					{
						if (y >= tempRec.Top && y <= tempRec.Bottom)
						{
							return i;
							
						}
					}
				}
				
			}
			
			return returnValue;
		}
		
		public static int IsPlayerSkill(float x, float y)
		{
			int returnValue = 0;
			Types.Rect tempRec = new Types.Rect();
			int i = 0;
			
			returnValue = 0;
			
			for (i = 1; i <= Constants.MAX_PLAYER_SKILLS; i++)
			{
				
				if (C_Variables.PlayerSkills[i] > 0 && C_Variables.PlayerSkills[i] <= Constants.MAX_PLAYER_SKILLS)
				{
					
					tempRec.Top = C_UpdateUI.SkillWindowY + C_UpdateUI.SkillTop + ((C_UpdateUI.SkillOffsetY + 32) * ((i - 1) / C_UpdateUI.SkillColumns));
					tempRec.Bottom = tempRec.Top + C_Constants.PicY;
					tempRec.Left = C_UpdateUI.SkillWindowX + C_UpdateUI.SkillLeft + ((C_UpdateUI.SkillOffsetX + 32) * ((i - 1) % C_UpdateUI.SkillColumns));
					tempRec.Right = tempRec.Left + C_Constants.PicX;
					
					if (x >= tempRec.Left && x <= tempRec.Right)
					{
						if (y >= tempRec.Top && y <= tempRec.Bottom)
						{
							return i;
							
						}
					}
				}
				
			}
			
			return returnValue;
		}
		
		public static int IsBankItem(float x, float y)
		{
			int returnValue = 0;
			Types.Rect tempRec = new Types.Rect();
			int i = 0;
			
			returnValue = 0;
			
			for (i = 1; i <= Constants.MAX_BANK; i++)
			{
				if (C_GameLogic.GetBankItemNum((byte) i) > 0 && C_GameLogic.GetBankItemNum((byte) i) <= Constants.MAX_ITEMS)
				{
					
					tempRec.Top = C_UpdateUI.BankWindowY + C_UpdateUI.BankTop + ((C_UpdateUI.BankOffsetY + 32) * ((i - 1) / C_UpdateUI.BankColumns));
					tempRec.Bottom = tempRec.Top + C_Constants.PicY;
					tempRec.Left = C_UpdateUI.BankWindowX + C_UpdateUI.BankLeft + ((C_UpdateUI.BankOffsetX + 32) * ((i - 1) % C_UpdateUI.BankColumns));
					tempRec.Right = tempRec.Left + C_Constants.PicX;
					
					if (x >= tempRec.Left && x <= tempRec.Right)
					{
						if (y >= tempRec.Top && y <= tempRec.Bottom)
						{
							
							return i;
							
						}
					}
				}
			}
			return returnValue;
		}
		
		public static int IsShopItem(float x, float y)
		{
			int returnValue = 0;
			Rectangle tempRec = new Rectangle();
			int i = 0;
			returnValue = 0;
			
			for (i = 1; i <= Constants.MAX_TRADES; i++)
			{
				
				if (Types.Shop[C_Shops.InShop].TradeItem[i].Item > 0 && Types.Shop[C_Shops.InShop].TradeItem[i].Item <= Constants.MAX_ITEMS)
				{
					tempRec.Y = C_UpdateUI.ShopWindowY + C_UpdateUI.ShopTop + ((C_UpdateUI.ShopOffsetY + 32) * ((i - 1) / C_UpdateUI.ShopColumns));
					tempRec.Height = C_Constants.PicY;
					tempRec.X = C_UpdateUI.ShopWindowX + C_UpdateUI.ShopLeft + ((C_UpdateUI.ShopOffsetX + 32) * ((i - 1) % C_UpdateUI.ShopColumns));
					tempRec.Width = C_Constants.PicX;
					
					if (x >= tempRec.Left && x <= tempRec.Right)
					{
						if (y >= tempRec.Top && y <= tempRec.Bottom)
						{
							return i;
							
						}
					}
				}
			}
			return returnValue;
		}
		
		public static int IsTradeItem(float x, float y, bool yours)
		{
			int returnValue = 0;
			Types.Rect tempRec = new Types.Rect();
			int i = 0;
			int itemnum = 0;
			
			returnValue = 0;
			
			for (i = 1; i <= Constants.MAX_INV; i++)
			{
				
				if (yours)
				{
					itemnum = C_Player.GetPlayerInvItemNum(C_Variables.Myindex, C_Trade.TradeYourOffer[i].Num);
					
					tempRec.Top = C_UpdateUI.TradeWindowY + C_UpdateUI.OurTradeY + C_UpdateUI.InvTop + ((C_UpdateUI.InvOffsetY + 32) * ((i - 1) / C_UpdateUI.InvColumns));
					tempRec.Bottom = tempRec.Top + C_Constants.PicY;
					tempRec.Left = C_UpdateUI.TradeWindowX + C_UpdateUI.OurTradeX + C_UpdateUI.InvLeft + ((C_UpdateUI.InvOffsetX + 32) * ((i - 1) % C_UpdateUI.InvColumns));
					tempRec.Right = tempRec.Left + C_Constants.PicX;
				}
				else
				{
					itemnum = C_Trade.TradeTheirOffer[i].Num;
					
					tempRec.Top = C_UpdateUI.TradeWindowY + C_UpdateUI.TheirTradeY + C_UpdateUI.InvTop + ((C_UpdateUI.InvOffsetY + 32) * ((i - 1) / C_UpdateUI.InvColumns));
					tempRec.Bottom = tempRec.Top + C_Constants.PicY;
					tempRec.Left = C_UpdateUI.TradeWindowX + C_UpdateUI.TheirTradeX + C_UpdateUI.InvLeft + ((C_UpdateUI.InvOffsetX + 32) * ((i - 1) % C_UpdateUI.InvColumns));
					tempRec.Right = tempRec.Left + C_Constants.PicX;
				}
				
				if (itemnum > 0 && itemnum <= Constants.MAX_ITEMS)
				{
					
					if (x >= tempRec.Left && x <= tempRec.Right)
					{
						if (y >= tempRec.Top && y <= tempRec.Bottom)
						{
							return i;
							
						}
					}
					
				}
				
			}
			
			return returnValue;
		}
		
		public static bool AboveActionPanel(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.ActionPanelX && x < C_UpdateUI.ActionPanelX + C_Graphics.ActionPanelGfxInfo.Width)
			{
				if (y > C_UpdateUI.ActionPanelY && y < C_UpdateUI.ActionPanelY + C_Graphics.ActionPanelGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AboveHotbar(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.HotbarX && x < C_UpdateUI.HotbarX + C_Graphics.HotBarGfxInfo.Width)
			{
				if (y > C_UpdateUI.HotbarY && y < C_UpdateUI.HotbarY + C_Graphics.HotBarGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AbovePetbar(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.PetbarX && x < C_UpdateUI.PetbarX + C_Graphics.PetbarGfxInfo.Width)
			{
				if (y > C_UpdateUI.PetbarY && y < C_UpdateUI.PetbarY + C_Graphics.HotBarGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AboveInvpanel(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.InvWindowX && x < C_UpdateUI.InvWindowX + C_Graphics.InvPanelGfxInfo.Width)
			{
				if (y > C_UpdateUI.InvWindowY && y < C_UpdateUI.InvWindowY + C_Graphics.InvPanelGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AboveCharpanel(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.CharWindowX && x < C_UpdateUI.CharWindowX + C_Graphics.CharPanelGfxInfo.Width)
			{
				if (y > C_UpdateUI.CharWindowY && y < C_UpdateUI.CharWindowY + C_Graphics.CharPanelGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AboveSkillpanel(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.SkillWindowX && x < C_UpdateUI.SkillWindowX + C_Graphics.SkillPanelGfxInfo.Width)
			{
				if (y > C_UpdateUI.SkillWindowY && y < C_UpdateUI.SkillWindowY + C_Graphics.SkillPanelGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AboveBankpanel(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.BankWindowX && x < C_UpdateUI.BankWindowX + C_Graphics.BankPanelGfxInfo.Width)
			{
				if (y > C_UpdateUI.BankWindowY && y < C_UpdateUI.BankWindowY + C_Graphics.BankPanelGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AboveShoppanel(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.ShopWindowX && x < C_UpdateUI.ShopWindowX + C_Graphics.ShopPanelGfxInfo.Width)
			{
				if (y > C_UpdateUI.ShopWindowY && y < C_UpdateUI.ShopWindowY + C_Graphics.ShopPanelGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AboveTradepanel(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.TradeWindowX && x < C_UpdateUI.TradeWindowX + C_Graphics.TradePanelGfxInfo.Width)
			{
				if (y > C_UpdateUI.TradeWindowY && y < C_UpdateUI.TradeWindowY + C_Graphics.TradePanelGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AboveEventChat(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.EventChatX && x < C_UpdateUI.EventChatX + C_Graphics.EventChatGfxInfo.Width)
			{
				if (y > C_UpdateUI.EventChatY && y < C_UpdateUI.EventChatY + C_Graphics.EventChatGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AboveChatScrollUp(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.ChatWindowX + C_Graphics.ChatWindowGfxInfo.Width - 24 && x < C_UpdateUI.ChatWindowX + C_Graphics.ChatWindowGfxInfo.Width)
			{
				if (y > C_UpdateUI.ChatWindowY && y < C_UpdateUI.ChatWindowY + 24) //ChatWindowGFXInfo.height Then
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AboveChatScrollDown(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.ChatWindowX + C_Graphics.ChatWindowGfxInfo.Width - 24 && x < C_UpdateUI.ChatWindowX + C_Graphics.ChatWindowGfxInfo.Width)
			{
				if (y > C_UpdateUI.ChatWindowY + C_Graphics.ChatWindowGfxInfo.Height - 24 && y < C_UpdateUI.ChatWindowY + C_Graphics.ChatWindowGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AboveRClickPanel(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.RClickX && x < C_UpdateUI.RClickX + C_Graphics.RClickGfxInfo.Width)
			{
				if (y > C_UpdateUI.RClickY && y < C_UpdateUI.RClickY + C_Graphics.RClickGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AboveQuestPanel(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_Quest.QuestLogX && x < C_Quest.QuestLogX + C_Graphics.QuestGfxInfo.Width)
			{
				if (y > C_Quest.QuestLogY && y < C_Quest.QuestLogY + C_Graphics.QuestGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
		public static bool AboveCraftPanel(float x, float y)
		{
			bool returnValue = false;
			returnValue = false;
			
			if (x > C_UpdateUI.CraftPanelX && x < C_UpdateUI.CraftPanelX + C_Graphics.CraftGfxInfo.Width)
			{
				if (y > C_UpdateUI.CraftPanelY && y < C_UpdateUI.CraftPanelY + C_Graphics.CraftGfxInfo.Height)
				{
					return true;
				}
			}
			return returnValue;
		}
		
#endregion
		
	}
}
