
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Engine;

namespace Engine
{
	
	public partial class FrmEditor_Events
	{
		public FrmEditor_Events()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmEditor_Events defaultInstance;
		
		/// <summary>
		/// The Instance of this Form
		/// </summary>
		public static FrmEditor_Events Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmEditor_Events();
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
		
		public void ClearConditionFrame()
		{
			int i = 0;
			
			cmbCondition_PlayerVarIndex.Enabled = false;
			cmbCondition_PlayerVarIndex.Items.Clear();
			
			for (i = 1; i <= C_EventSystem.MaxVariables; i++)
			{
				cmbCondition_PlayerVarIndex.Items.Add(i +". " + C_EventSystem.Variables[i]);
			}
			cmbCondition_PlayerVarIndex.SelectedIndex = 0;
			cmbCondition_PlayerVarCompare.SelectedIndex = 0;
			cmbCondition_PlayerVarCompare.Enabled = false;
			nudCondition_PlayerVarCondition.Enabled = false;
			nudCondition_PlayerVarCondition.Value = 0;
			cmbCondition_PlayerSwitch.Enabled = false;
			cmbCondition_PlayerSwitch.Items.Clear();
			
			for (i = 1; i <= C_EventSystem.MaxSwitches; i++)
			{
				cmbCondition_PlayerSwitch.Items.Add(i +". " + C_EventSystem.Switches[i]);
			}
			cmbCondition_PlayerSwitch.SelectedIndex = 0;
			cmbCondtion_PlayerSwitchCondition.Enabled = false;
			cmbCondtion_PlayerSwitchCondition.SelectedIndex = 0;
			cmbCondition_HasItem.Enabled = false;
			cmbCondition_HasItem.Items.Clear();
			
			for (i = 1; i <= Constants.MAX_ITEMS; i++)
			{
				cmbCondition_HasItem.Items.Add(i +". " + Microsoft.VisualBasic.Strings.Trim(Types.Item[i].Name));
			}
			cmbCondition_HasItem.SelectedIndex = 0;
			nudCondition_HasItem.Enabled = false;
			nudCondition_HasItem.Value = 1;
			cmbCondition_ClassIs.Enabled = false;
			cmbCondition_ClassIs.Items.Clear();
			
			for (i = 1; i <= C_Variables.MaxClasses; i++)
			{
				cmbCondition_ClassIs.Items.Add(i +". " + Convert.ToString(Types.Classes[i].Name));
			}
			cmbCondition_ClassIs.SelectedIndex = 0;
			cmbCondition_LearntSkill.Enabled = false;
			cmbCondition_LearntSkill.Items.Clear();
			
			for (i = 1; i <= Constants.MAX_SKILLS; i++)
			{
				cmbCondition_LearntSkill.Items.Add(i +". " + Microsoft.VisualBasic.Strings.Trim(Types.Skill[i].Name));
			}
			cmbCondition_LearntSkill.SelectedIndex = 0;
			cmbCondition_LevelCompare.Enabled = false;
			cmbCondition_LevelCompare.SelectedIndex = 0;
			nudCondition_LevelAmount.Enabled = false;
			nudCondition_LevelAmount.Value = 0;
			if (cmbCondition_SelfSwitch.Items.Count > 0)
			{
				cmbCondition_SelfSwitch.SelectedIndex = 0;
			}
			
			cmbCondition_SelfSwitch.Enabled = false;
			
			if (cmbCondition_SelfSwitchCondition.Items.Count > 0)
			{
				cmbCondition_SelfSwitchCondition.SelectedIndex = 0;
			}
			
			cmbCondition_SelfSwitchCondition.Enabled = false;
			nudCondition_Quest.Enabled = false;
			nudCondition_Quest.Value = 1;
			fraConditions_Quest.Visible = false;
			optCondition_Quest0.Checked = true;
			cmbCondition_General.Enabled = true;
			cmbCondition_General.SelectedIndex = 0;
			nudCondition_QuestTask.Value = 1;
			
			cmbCondition_Gender.Enabled = false;
			
			cmbCondition_Time.Enabled = false;
		}
		
		public void InitEventEditorForm()
		{
			int i = 0;
			
			nudShowTextFace.Maximum = C_Graphics.NumFaces;
			nudShowChoicesFace.Maximum = C_Graphics.NumFaces;
			
			nudWPMap.Maximum = Constants.MAX_MAPS;
			
			cmbSwitch.Items.Clear();
			
			for (i = 1; i <= C_EventSystem.MaxSwitches; i++)
			{
				cmbSwitch.Items.Add(i +". " + C_EventSystem.Switches[i]);
			}
			cmbSwitch.SelectedIndex = 0;
			cmbVariable.Items.Clear();
			
			for (i = 1; i <= C_EventSystem.MaxVariables; i++)
			{
				cmbVariable.Items.Add(i +". " + C_EventSystem.Variables[i]);
			}
			cmbVariable.SelectedIndex = 0;
			cmbChangeItemIndex.Items.Clear();
			
			for (i = 1; i <= Constants.MAX_ITEMS; i++)
			{
				cmbChangeItemIndex.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Item[i].Name));
			}
			cmbChangeItemIndex.SelectedIndex = 0;
			nudChangeLevel.Minimum = 1;
			nudChangeLevel.Maximum = Constants.MAX_LEVELS;
			nudChangeLevel.Value = 1;
			cmbChangeSkills.Items.Clear();
			
			for (i = 1; i <= Constants.MAX_SKILLS; i++)
			{
				cmbChangeSkills.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Skill[i].Name));
			}
			cmbChangeSkills.SelectedIndex = 0;
			cmbChangeClass.Items.Clear();
			
			if (C_Variables.MaxClasses > 0)
			{
				for (i = 1; i <= C_Variables.MaxClasses; i++)
				{
					cmbChangeClass.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Classes[i].Name));
				}
				cmbChangeClass.SelectedIndex = 0;
			}
			nudChangeSprite.Maximum = C_Graphics.NumCharacters;
			cmbPlayAnim.Items.Clear();
			
			for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
			{
				cmbPlayAnim.Items.Add(i +". " + Microsoft.VisualBasic.Strings.Trim(Types.Animation[i].Name));
			}
			cmbPlayAnim.SelectedIndex = 0;
			
			cmbPlayBGM.Items.Clear();
			
			if ((C_Sound.MusicCache.Length - 1) > 0)
			{
				for (i = 1; i <= (C_Sound.MusicCache.Length - 1); i++)
				{
					cmbPlayBGM.Items.Add(C_Sound.MusicCache[i]);
				}
				cmbPlayBGM.SelectedIndex = 0;
			}
			else
			{
				
			}
			cmbPlaySound.Items.Clear();
			
			if ((C_Sound.SoundCache.Length - 1) > 0)
			{
				for (i = 1; i <= (C_Sound.SoundCache.Length - 1); i++)
				{
					cmbPlaySound.Items.Add(C_Sound.SoundCache[i]);
				}
				cmbPlaySound.SelectedIndex = 0;
			}
			else
			{
				
			}
			cmbOpenShop.Items.Clear();
			
			for (i = 1; i <= Constants.MAX_SHOPS; i++)
			{
				cmbOpenShop.Items.Add(i +". " + Microsoft.VisualBasic.Strings.Trim(Types.Shop[i].Name));
			}
			cmbOpenShop.SelectedIndex = 0;
			cmbSpawnNpc.Items.Clear();
			
			for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
			{
				if (C_Maps.Map.Npc[i] > 0)
				{
					cmbSpawnNpc.Items.Add(i +". " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[C_Maps.Map.Npc[i]].Name));
				}
				else
				{
					cmbSpawnNpc.Items.Add(i +". ");
				}
			}
			
			//set up all quest combo's
			cmbBeginQuest.Items.Clear();
			cmbCompleteQuest.Items.Clear();
			cmbEndQuest.Items.Clear();
			
			cmbBeginQuest.Items.Add("None");
			cmbCompleteQuest.Items.Add("None");
			cmbEndQuest.Items.Add("None");
			
			for (i = 1; i <= C_Quest.MaxQuests; i++)
			{
				cmbBeginQuest.Items.Add(i +". " + Microsoft.VisualBasic.Strings.Trim(C_Quest.Quest[i].Name));
				cmbCompleteQuest.Items.Add(i +". " + Microsoft.VisualBasic.Strings.Trim(C_Quest.Quest[i].Name));
				cmbEndQuest.Items.Add(i +". " + Microsoft.VisualBasic.Strings.Trim(C_Quest.Quest[i].Name));
			}
			
			cmbSpawnNpc.SelectedIndex = 0;
			nudFogData0.Maximum = C_Graphics.NumFogs;
			cmbEventQuest.Items.Clear();
			cmbEventQuest.Items.Add("None");
			for (i = 1; i <= C_Quest.MaxQuests; i++)
			{
				cmbEventQuest.Items.Add(i +". " + Microsoft.VisualBasic.Strings.Trim(C_Quest.Quest[i].Name));
			}
			
			//If NumPics > 0 Then
			//    btnCommands45.Enabled = True
			//    scrlShowPicture.Maximum = NumPics
			//    cmbPicIndex.SelectedIndex = 0
			//Else
			
			//End If
			
			fraDialogue.Visible = false;
			
			C_EventSystem.EditorEvent_DrawGraphic();
		}
		
		public void FrmEditor_Events_Load(object sender, EventArgs e)
		{
			Width = 824;
			fraDialogue.Width = Width;
			fraDialogue.Height = Height;
			fraDialogue.Top = 0;
			fraDialogue.Left = 0;
			
			fraMoveRoute.Width = Width;
			fraMoveRoute.Height = Height;
			fraMoveRoute.Top = 0;
			fraMoveRoute.Left = 0;
			
			fraGraphic.Width = Width;
			fraGraphic.Height = Height;
			fraGraphic.Top = 0;
			fraGraphic.Left = 0;
		}
		
		public void BtnOK_Click(object sender, EventArgs e)
		{
			C_EventSystem.EventEditorOK();
		}
		
		public void BtnCancel_Click(object sender, EventArgs e)
		{
			//Dispose();
            Close();
		}
		
		public void TvCommands_AfterSelect(object sender, TreeViewEventArgs e)
		{
			int x = 0;
			
			fraDialogue.Width = this.Width;
			fraDialogue.Height = this.Height;
			
			fraDialogue.BringToFront();
			
			//MsgBox(tvCommands.SelectedNode.Text)
			
			switch (tvCommands.SelectedNode.Text)
			{
				//Messages
				
				//show text
			case "Show Text":
				txtShowText.Text = "";
				fraDialogue.Visible = true;
				fraShowText.Visible = true;
				nudShowTextFace.Value = 0;
				nudShowTextFace.Maximum = C_Graphics.NumFaces;
				fraCommands.Visible = false;
				break;
				//show choices
			case "Show Choices":
				txtChoicePrompt.Text = "";
				txtChoices1.Text = "";
				txtChoices2.Text = "";
				txtChoices3.Text = "";
				txtChoices4.Text = "";
				nudShowChoicesFace.Value = 0;
				fraDialogue.Visible = true;
				fraShowChoices.Visible = true;
				fraCommands.Visible = false;
				break;
				//chatbox text
			case "Add Chatbox Text":
				txtAddText_Text.Text = "";
				optAddText_Player.Checked = true;
				fraDialogue.Visible = true;
				fraAddText.Visible = true;
				fraCommands.Visible = false;
				break;
				//chat bubble
			case "Show ChatBubble":
				txtChatbubbleText.Text = "";
				cmbChatBubbleTargetType.SelectedIndex = 0;
				cmbChatBubbleTarget.Visible = false;
				fraDialogue.Visible = true;
				fraShowChatBubble.Visible = true;
				fraCommands.Visible = false;
				break;
				//event progression
				//player variable
			case "Set Player Variable":
				nudVariableData0.Value = 0;
				nudVariableData1.Value = 0;
				nudVariableData2.Value = 0;
				nudVariableData3.Value = 0;
				nudVariableData4.Value = 0;
				
				cmbVariable.SelectedIndex = 0;
				optVariableAction0.Checked = true;
				fraDialogue.Visible = true;
				fraPlayerVariable.Visible = true;
				fraCommands.Visible = false;
				break;
				//player switch
			case "Set Player Switch":
				cmbPlayerSwitchSet.SelectedIndex = 0;
				cmbSwitch.SelectedIndex = 0;
				fraDialogue.Visible = true;
				fraPlayerSwitch.Visible = true;
				fraCommands.Visible = false;
				break;
				//self switch
			case "Set Self Switch":
				cmbSetSelfSwitchTo.SelectedIndex = 0;
				fraDialogue.Visible = true;
				fraSetSelfSwitch.Visible = true;
				fraCommands.Visible = false;
				break;
				//flow control
				
				//conditional branch
			case "Conditional Branch":
				fraDialogue.Visible = true;
				fraConditionalBranch.Visible = true;
				optCondition0.Checked = true;
				ClearConditionFrame();
				cmbCondition_PlayerVarIndex.Enabled = true;
				cmbCondition_PlayerVarCompare.Enabled = true;
				nudCondition_PlayerVarCondition.Enabled = true;
				fraCommands.Visible = false;
				break;
				//Exit Event Process
			case "Stop Event Processing":
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvExitProcess);
				fraCommands.Visible = false;
				fraDialogue.Visible = false;
				break;
				//Label
			case "Label":
				txtLabelName.Text = "";
				fraCreateLabel.Visible = true;
				fraCommands.Visible = false;
				fraDialogue.Visible = true;
				break;
				//GoTo Label
			case "GoTo Label":
				txtGotoLabel.Text = "";
				fraGoToLabel.Visible = true;
				fraCommands.Visible = false;
				fraDialogue.Visible = true;
				break;
				//Player Control
				
				//Change Items
			case "Change Items":
				cmbChangeItemIndex.SelectedIndex = 0;
				optChangeItemSet.Checked = true;
				nudChangeItemsAmount.Value = 0;
				fraDialogue.Visible = true;
				fraChangeItems.Visible = true;
				fraCommands.Visible = false;
				break;
				//Restore Hp
			case "Restore HP":
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvRestoreHp);
				fraCommands.Visible = false;
				fraDialogue.Visible = false;
				break;
				//Restore Mp
			case "Restore Mp":
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvRestoreMp);
				fraCommands.Visible = false;
				fraDialogue.Visible = false;
				break;
				//Level Up
			case "Level Up":
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvLevelUp);
				fraCommands.Visible = false;
				fraDialogue.Visible = false;
				break;
				//Change Level
			case "Change Level":
				nudChangeLevel.Value = 1;
				fraDialogue.Visible = true;
				fraChangeLevel.Visible = true;
				fraCommands.Visible = false;
				break;
				//Change Skills
			case "Change Skills":
				cmbChangeSkills.SelectedIndex = 0;
				fraDialogue.Visible = true;
				fraChangeSkills.Visible = true;
				fraCommands.Visible = false;
				break;
				//Change Class
			case "Change Class":
				if (C_Variables.MaxClasses > 0)
				{
					if (cmbChangeClass.Items.Count == 0)
					{
						cmbChangeClass.Items.Clear();
						
						for (var i = 1; i <= C_Variables.MaxClasses; i++)
						{
							cmbChangeClass.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Classes[(int) i].Name));
						}
						cmbChangeClass.SelectedIndex = 0;
					}
				}
				fraDialogue.Visible = true;
				fraChangeClass.Visible = true;
				fraCommands.Visible = false;
				break;
				//Change Sprite
			case "Change Sprite":
				nudChangeSprite.Value = 1;
				fraDialogue.Visible = true;
				fraChangeSprite.Visible = true;
				fraCommands.Visible = false;
				break;
				//Change Gender
			case "Change Gender":
				optChangeSexMale.Checked = true;
				fraDialogue.Visible = true;
				fraChangeGender.Visible = true;
				fraCommands.Visible = false;
				break;
				//Change PK
			case "Change PK":
				cmbSetPK.SelectedIndex = 0;
				fraDialogue.Visible = true;
				fraChangePK.Visible = true;
				fraCommands.Visible = false;
				break;
				//Give Exp
			case "Give Experience":
				nudGiveExp.Value = 0;
				fraDialogue.Visible = true;
				fraGiveExp.Visible = true;
				fraCommands.Visible = false;
				break;
				//Movement
				
				//Warp Player
			case "Warp Player":
				nudWPMap.Value = 0;
				nudWPX.Value = 0;
				nudWPY.Value = 0;
				cmbWarpPlayerDir.SelectedIndex = 0;
				fraDialogue.Visible = true;
				fraPlayerWarp.Visible = true;
				fraCommands.Visible = false;
				break;
				//Set Move Route
			case "Set Move Route":
				fraMoveRoute.Visible = true;
				lstMoveRoute.Items.Clear();
				cmbEvent.Items.Clear();
				C_EventSystem.ListOfEvents = new int[C_Maps.Map.EventCount + 1];
				C_EventSystem.ListOfEvents[0] = C_EventSystem.EditorEvent;
				cmbEvent.Items.Add("This Event");
				cmbEvent.SelectedIndex = 0;
				cmbEvent.Enabled = true;
				for (var i = 1; i <= C_Maps.Map.EventCount; i++)
				{
					if (i != C_EventSystem.EditorEvent)
					{
						cmbEvent.Items.Add(Microsoft.VisualBasic.Strings.Trim(C_Maps.Map.Events[(int) i].Name));
						x++;
						C_EventSystem.ListOfEvents[x] = System.Convert.ToInt32(i);
					}
				}
				C_EventSystem.IsMoveRouteCommand = true;
				chkIgnoreMove.Checked = false;
				chkRepeatRoute.Checked = false;
				C_EventSystem.TempMoveRouteCount = 0;
				C_EventSystem.TempMoveRoute = new C_EventSystem.MoveRouteRec[1];
				fraMoveRoute.Visible = true;
				fraMoveRoute.BringToFront();
				fraCommands.Visible = false;
				break;
				//Wait for Route Completion
			case "Wait for Route Completion":
				cmbMoveWait.Items.Clear();
				C_EventSystem.ListOfEvents = new int[C_Maps.Map.EventCount + 1];
				C_EventSystem.ListOfEvents[0] = C_EventSystem.EditorEvent;
				cmbMoveWait.Items.Add("This Event");
				cmbMoveWait.SelectedIndex = 0;
				cmbMoveWait.Enabled = true;
				for (var i = 1; i <= C_Maps.Map.EventCount; i++)
				{
					if (i != C_EventSystem.EditorEvent)
					{
						cmbMoveWait.Items.Add(Microsoft.VisualBasic.Strings.Trim(C_Maps.Map.Events[(int) i].Name));
						x++;
						C_EventSystem.ListOfEvents[x] = System.Convert.ToInt32(i);
					}
				}
				fraDialogue.Visible = true;
				fraMoveRouteWait.Visible = true;
				fraCommands.Visible = false;
				break;
				//Force Spawn Npc
			case "Force Spawn Npc":
				//lets populate the combobox
				cmbSpawnNpc.Items.Clear();
				for (var i = 1; i <= Constants.MAX_NPCS; i++)
				{
					cmbSpawnNpc.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Npc[(int) i].Name));
				}
				cmbSpawnNpc.SelectedIndex = 0;
				fraDialogue.Visible = true;
				fraSpawnNpc.Visible = true;
				fraCommands.Visible = false;
				break;
				//Hold Player
			case "Hold Player":
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvHoldPlayer);
				fraCommands.Visible = false;
				fraDialogue.Visible = false;
				break;
				//Release Player
			case "Release Player":
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvReleasePlayer);
				fraCommands.Visible = false;
				fraDialogue.Visible = false;
				break;
				//Animation
				
				//Play Animation
			case "Play Animation":
				cmbPlayAnimEvent.Items.Clear();
				
				for (var i = 1; i <= C_Maps.Map.EventCount; i++)
				{
					cmbPlayAnimEvent.Items.Add(i +". " + Microsoft.VisualBasic.Strings.Trim(C_Maps.Map.Events[(int) i].Name));
				}
				cmbPlayAnimEvent.SelectedIndex = 0;
				cmbAnimTargetType.SelectedIndex = 0;
				cmbPlayAnim.SelectedIndex = 0;
				nudPlayAnimTileX.Value = 0;
				nudPlayAnimTileY.Value = 0;
				nudPlayAnimTileX.Maximum = C_Maps.Map.MaxX;
				nudPlayAnimTileY.Maximum = C_Maps.Map.MaxY;
				fraDialogue.Visible = true;
				fraPlayAnimation.Visible = true;
				fraCommands.Visible = false;
				lblPlayAnimX.Visible = false;
				lblPlayAnimY.Visible = false;
				nudPlayAnimTileX.Visible = false;
				nudPlayAnimTileY.Visible = false;
				cmbPlayAnimEvent.Visible = false;
				break;
				//Quests
				
				//Begin Quest
			case "Begin Quest":
				cmbBeginQuest.SelectedIndex = 0;
				fraDialogue.Visible = true;
				fraBeginQuest.Visible = true;
				fraCommands.Visible = false;
				break;
				//Complete Task
			case "Complete Task":
				cmbCompleteQuest.SelectedIndex = 0;
				nudCompleteQuestTask.Value = 0;
				fraDialogue.Visible = true;
				fraCompleteTask.Visible = true;
				fraCommands.Visible = false;
				break;
				//End Quest
			case "End Quest":
				cmbEndQuest.SelectedIndex = 0;
				fraDialogue.Visible = true;
				fraEndQuest.Visible = true;
				fraCommands.Visible = false;
				break;
				//Map Functions
				
				//Set Fog
			case "Set Fog":
				nudFogData0.Value = 0;
				nudFogData1.Value = 0;
				nudFogData2.Value = 0;
				fraDialogue.Visible = true;
				fraSetFog.Visible = true;
				fraCommands.Visible = false;
				break;
				//Set Weather
			case "Set Weather":
				CmbWeather.SelectedIndex = 0;
				nudWeatherIntensity.Value = 0;
				fraDialogue.Visible = true;
				fraSetWeather.Visible = true;
				fraCommands.Visible = false;
				break;
				//Set Map Tinting
			case "Set Map Tinting":
				nudMapTintData0.Value = 0;
				nudMapTintData1.Value = 0;
				nudMapTintData2.Value = 0;
				nudMapTintData3.Value = 0;
				fraDialogue.Visible = true;
				fraMapTint.Visible = true;
				fraCommands.Visible = false;
				break;
				//Music and Sound
				
				//PlayBGM
			case "Play BGM":
				cmbPlayBGM.SelectedIndex = 0;
				fraDialogue.Visible = true;
				fraPlayBGM.Visible = true;
				fraCommands.Visible = false;
				break;
				//Stop BGM
			case "Stop BGM":
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvFadeoutBgm);
				fraCommands.Visible = false;
				fraDialogue.Visible = false;
				break;
				//Play Sound
			case "Play Sound":
				cmbPlaySound.SelectedIndex = 0;
				fraDialogue.Visible = true;
				fraPlaySound.Visible = true;
				fraCommands.Visible = false;
				break;
				//Stop Sounds
			case "Stop Sounds":
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvStopSound);
				fraCommands.Visible = false;
				fraDialogue.Visible = false;
				break;
				//Etc...
				
				//Wait...
			case "Wait...":
				nudWaitAmount.Value = 1;
				fraDialogue.Visible = true;
				fraSetWait.Visible = true;
				fraCommands.Visible = false;
				break;
				//Set Access
			case "Set Access":
				cmbSetAccess.SelectedIndex = 0;
				fraDialogue.Visible = true;
				fraSetAccess.Visible = true;
				fraCommands.Visible = false;
				break;
				//Custom Script
			case "Custom Script":
				nudCustomScript.Value = 0;
				fraDialogue.Visible = true;
				fraCustomScript.Visible = true;
				fraCommands.Visible = false;
				break;
				
				//Shop, bank etc
				
				//Open bank
			case "Open bank":
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvOpenBank);
				fraCommands.Visible = false;
				fraDialogue.Visible = false;
				break;
				//Open shop
			case "Open shop":
				fraDialogue.Visible = true;
				fraOpenShop.Visible = true;
				cmbOpenShop.SelectedIndex = 0;
				fraCommands.Visible = false;
				break;
				//Open Mail
			case "45":
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvOpenMail);
				fraCommands.Visible = false;
				fraDialogue.Visible = false;
				break;
				//cutscene options
				
				//Fade in
			case "Fade In":
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvFadeIn);
				fraCommands.Visible = false;
				fraDialogue.Visible = false;
				break;
				//Fade out
			case "Fade Out":
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvFadeOut);
				fraCommands.Visible = false;
				fraDialogue.Visible = false;
				break;
				//Flash white
			case "48":
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvFlashWhite);
				fraCommands.Visible = false;
				fraDialogue.Visible = false;
				break;
				//Show pic
			case "49":
				cmbPicIndex.SelectedIndex = 0;
				nudShowPicture.Value = 1;
				cmbPicLoc.SelectedIndex = 0;
				nudPicOffsetX.Value = 0;
				nudPicOffsetY.Value = 0;
				fraDialogue.Visible = true;
				fraShowPic.Visible = true;
				fraCommands.Visible = false;
				break;
				//Hide pic
			case "50":
				nudHidePic.Value = 0;
				fraDialogue.Visible = true;
				fraHidePic.Visible = true;
				fraCommands.Visible = false;
				break;
				
		}
	}
	
	public void BtnCancelCommand_Click(object sender, EventArgs e)
	{
		fraCommands.Visible = false;
	}
	
#endregion
	
#region Page Buttons
	
	public void TabPages_Click(object sender, EventArgs e)
	{
		C_EventSystem.CurPageNum = tabPages.SelectedIndex + 1;
		C_EventSystem.EventEditorLoadPage(C_EventSystem.CurPageNum);
	}
	
	public void BtnNewPage_Click(object sender, EventArgs e)
	{
		int pageCount = 0;
		int i = 0;
		
		if (chkGlobal.Checked == true)
		{
			MessageBox.Show("You cannot have multiple pages on global events!");
			return;
		}
		
		pageCount = C_EventSystem.TmpEvent.PageCount + 1;
		
		// redim the array
		Array.Resize(ref C_EventSystem.TmpEvent.Pages, pageCount + 1);
		
		C_EventSystem.TmpEvent.PageCount = pageCount;
		
		// set the tabs
		tabPages.TabPages.Clear();
		
		for (i = 1; i <= C_EventSystem.TmpEvent.PageCount; i++)
		{
			tabPages.TabPages.Add(Conversion.Str(i));
		}
		btnDeletePage.Enabled = true;
	}
	
	public void BtnCopyPage_Click(object sender, EventArgs e)
	{
		C_EventSystem.CopyEventPage = C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum];
		btnPastePage.Enabled = true;
	}
	
	public void BtnPastePage_Click(object sender, EventArgs e)
	{
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum] = C_EventSystem.CopyEventPage;
		C_EventSystem.EventEditorLoadPage(C_EventSystem.CurPageNum);
	}
	
	public void BtnDeletePage_Click(object sender, EventArgs e)
	{
		// move everything else down a notch
		if (C_EventSystem.CurPageNum < C_EventSystem.TmpEvent.PageCount)
		{
			for (var i = C_EventSystem.CurPageNum; i <= C_EventSystem.TmpEvent.PageCount - 1; i++)
			{
				C_EventSystem.TmpEvent.Pages[i + 1] = C_EventSystem.TmpEvent.Pages[(int) i];
			}
		}
		C_EventSystem.TmpEvent.PageCount--;
		// set the tabs
		tabPages.TabPages.Clear();
		
		for (var i = 1; i <= C_EventSystem.TmpEvent.PageCount; i++)
		{
			tabPages.TabPages.Add("0", Conversion.Str(i), "");
		}
		// set the tab back
		if (C_EventSystem.CurPageNum <= C_EventSystem.TmpEvent.PageCount)
		{
			tabPages.SelectedIndex = tabPages.TabPages.IndexOfKey(System.Convert.ToString(C_EventSystem.CurPageNum));
		}
		else
		{
			tabPages.SelectedIndex = tabPages.TabPages.IndexOfKey(System.Convert.ToString(C_EventSystem.TmpEvent.PageCount));
		}
		// make sure we disable
		if (C_EventSystem.TmpEvent.PageCount <= 1)
		{
			btnDeletePage.Enabled = false;
		}
		
	}
	
	public void BtnClearPage_Click(object sender, EventArgs e)
	{
	}
	
	public void TxtName_TextChanged(object sender, EventArgs e)
	{
		C_EventSystem.TmpEvent.Name = txtName.Text.Trim();
	}
	
#endregion
	
#region Conditions
	
	public void ChkPlayerVar_CheckedChanged(object sender, EventArgs e)
	{
		if (chkPlayerVar.Checked == true)
		{
			cmbPlayerVar.Enabled = false;
			nudPlayerVariable.Enabled = false;
			cmbPlayervarCompare.Enabled = false;
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].ChkVariable = 0;
		}
		else
		{
			cmbPlayerVar.Enabled = true;
			nudPlayerVariable.Enabled = true;
			cmbPlayervarCompare.Enabled = true;
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].ChkVariable = 1;
		}
	}
	
	public void CmbPlayerVar_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbPlayerVar.SelectedIndex == -1)
		{
			return;
		}
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].Variableindex = cmbPlayerVar.SelectedIndex;
	}
	
	public void CmbPlayervarCompare_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbPlayervarCompare.SelectedIndex == -1)
		{
			return;
		}
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].VariableCompare = cmbPlayervarCompare.SelectedIndex;
	}
	
	public void NudPlayerVariable_ValueChanged(object sender, EventArgs e)
	{
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].VariableCondition = (int) nudPlayerVariable.Value;
	}
	
	public void ChkPlayerSwitch_CheckedChanged(object sender, EventArgs e)
	{
		if (chkPlayerSwitch.Checked == true)
		{
			cmbPlayerSwitch.Enabled = true;
			cmbPlayerSwitchCompare.Enabled = true;
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].ChkSwitch = 1;
		}
		else
		{
			cmbPlayerSwitch.Enabled = false;
			cmbPlayerSwitchCompare.Enabled = false;
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].ChkSwitch = 0;
		}
	}
	
	public void CmbPlayerSwitch_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbPlayerSwitch.SelectedIndex == -1)
		{
			return;
		}
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].Switchindex = cmbPlayerSwitch.SelectedIndex;
	}
	
	public void CmbPlayerSwitchCompare_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbPlayerSwitchCompare.SelectedIndex == -1)
		{
			return;
		}
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].SwitchCompare = cmbPlayerSwitchCompare.SelectedIndex;
	}
	
	public void ChkHasItem_CheckedChanged(object sender, EventArgs e)
	{
		if (chkHasItem.Checked == true)
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].ChkHasItem = 1;
			cmbHasItem.Enabled = true;
		}
		else
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].ChkHasItem = 0;
			cmbHasItem.Enabled = false;
		}
		
	}
	
	public void CmbHasItem_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbHasItem.SelectedIndex == -1)
		{
			return;
		}
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].HasItemindex = cmbHasItem.SelectedIndex;
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].HasItemAmount = (int) nudCondition_HasItem.Value;
	}
	
	public void ChkSelfSwitch_CheckedChanged(object sender, EventArgs e)
	{
		if (chkSelfSwitch.Checked == true)
		{
			cmbSelfSwitch.Enabled = true;
			cmbSelfSwitchCompare.Enabled = true;
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].ChkSelfSwitch = 1;
		}
		else
		{
			cmbSelfSwitch.Enabled = false;
			cmbSelfSwitchCompare.Enabled = false;
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].ChkSelfSwitch = 0;
		}
	}
	
	public void CmbSelfSwitch_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbSelfSwitch.SelectedIndex == -1)
		{
			return;
		}
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].SelfSwitchindex = cmbSelfSwitch.SelectedIndex;
	}
	
	public void CmbSelfSwitchCompare_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbSelfSwitchCompare.SelectedIndex == -1)
		{
			return;
		}
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].SelfSwitchCompare = cmbSelfSwitchCompare.SelectedIndex;
	}
	
#endregion
	
#region Graphic
	
	public void PicGraphic_Click(object sender, EventArgs e)
	{
		fraGraphic.Top = 0;
		fraGraphic.Left = 0;
		fraGraphic.Width = this.Width;
		fraGraphic.Height = this.Height;
		fraGraphic.BringToFront();
		fraGraphic.Visible = true;
		C_EventSystem.GraphicSelType = 0;
	}
	
	public void CmbGraphic_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbGraphic.SelectedIndex == -1)
		{
			return;
		}
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].GraphicType = (byte) cmbGraphic.SelectedIndex;
		// set the max on the scrollbar
		switch (cmbGraphic.SelectedIndex)
		{
			case 0: // None
				nudGraphic.Value = 1;
				nudGraphic.Enabled = false;
				break;
			case 1: // character
				nudGraphic.Maximum = C_Graphics.NumCharacters;
				nudGraphic.Enabled = true;
				break;
			case 2: // Tileset
				nudGraphic.Maximum = C_Graphics.NumTileSets;
				nudGraphic.Enabled = true;
				break;
		}
		
		if (C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].GraphicType == 1)
		{
			if (this.nudGraphic.Value <= 0 || this.nudGraphic.Value > C_Graphics.NumCharacters)
			{
				return;
			}
			
		}
		else if (C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].GraphicType == 2)
		{
			if (this.nudGraphic.Value <= 0 || this.nudGraphic.Value > C_Graphics.NumTileSets)
			{
				return;
			}
			
		}
		C_EventSystem.EditorEvent_DrawGraphic();
	}
	
	public void NudGraphic_ValueChanged(object sender, EventArgs e)
	{
		C_EventSystem.EditorEvent_DrawGraphic();
	}
	
	public void PicGraphicSel_Click(object sender, MouseEventArgs olde)
    {
        MouseEventArgs e = new MouseEventArgs(olde.Button, olde.Clicks, (int)(olde.X * (848 / (float)FrmGame.Default.Width)), (int)(olde.Y * (678 / (float)FrmGame.Default.Height)), olde.Delta);
        int X = 0;
		int Y = 0;
		
		X = e.Location.X;
		Y = e.Location.Y;
		
		int selW = (int) (Math.Ceiling((Double)(X / C_Constants.PicX)) - C_EventSystem.GraphicSelX);
		int selH = (int) (Math.Ceiling((Double)(Y / C_Constants.PicY)) - C_EventSystem.GraphicSelY);
		
		if (this.cmbGraphic.SelectedIndex == 2)
		{
			//Tileset... hard one....
			if (Control.ModifierKeys == Keys.Shift)
			{
				if (C_EventSystem.GraphicSelX > -1 && C_EventSystem.GraphicSelY > -1)
				{
					if (selW >= 0 && selH >= 0)
					{
						C_EventSystem.GraphicSelX2 = selW + 1;
						C_EventSystem.GraphicSelY2 = selH + 1;
					}
				}
			}
			else
			{
				C_EventSystem.GraphicSelX = (int) (Math.Ceiling((Double)(X / C_Constants.PicX)));
				C_EventSystem.GraphicSelY = (int) (Math.Ceiling((Double)(Y / C_Constants.PicY)));
				C_EventSystem.GraphicSelX2 = 1;
				C_EventSystem.GraphicSelY2 = 1;
			}
		}
		else if (this.cmbGraphic.SelectedIndex == 1)
		{
			C_EventSystem.GraphicSelX = X;
			C_EventSystem.GraphicSelY = Y;
			C_EventSystem.GraphicSelX2 = 0;
			C_EventSystem.GraphicSelY2 = 0;
			if (this.nudGraphic.Value <= 0 || this.nudGraphic.Value > C_Graphics.NumCharacters)
			{
				return;
			}
			for (var i = 0; i <= 3; i++)
			{
				if (C_EventSystem.GraphicSelX >= (((double) C_Graphics.CharacterGfxInfo[(int) this.nudGraphic.Value].Width / 4) * i) && C_EventSystem.GraphicSelX < (((double) C_Graphics.CharacterGfxInfo[(int) this.nudGraphic.Value].Width / 4) * (i + 1)))
				{
					C_EventSystem.GraphicSelX = System.Convert.ToInt32(i);
				}
			}
			for (var i = 0; i <= 3; i++)
			{
				if (C_EventSystem.GraphicSelY >= (((double) C_Graphics.CharacterGfxInfo[(int) this.nudGraphic.Value].Height / 4) * i) && C_EventSystem.GraphicSelY < (((double) C_Graphics.CharacterGfxInfo[(int) this.nudGraphic.Value].Height / 4) * (i + 1)))
				{
					C_EventSystem.GraphicSelY = System.Convert.ToInt32(i);
				}
			}
		}
		C_EventSystem.EditorEvent_DrawGraphic();
	}
	
	public void BtnGraphicOk_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.GraphicSelType == 0)
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].GraphicType = (byte) cmbGraphic.SelectedIndex;
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].Graphic = (int) nudGraphic.Value;
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].GraphicX = C_EventSystem.GraphicSelX;
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].GraphicY = C_EventSystem.GraphicSelY;
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].GraphicX2 = C_EventSystem.GraphicSelX2;
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].GraphicY2 = C_EventSystem.GraphicSelY2;
		}
		else
		{
			AddMoveRouteCommand(42);
			C_EventSystem.GraphicSelType = 0;
		}
		fraGraphic.Visible = false;
	}
	
	public void BtnGraphicCancel_Click(object sender, EventArgs e)
	{
		fraGraphic.Visible = false;
	}
	
#endregion
	
#region Movement
	
	public void CmbMoveType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbMoveType.SelectedIndex == -1)
		{
			return;
		}
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].MoveType = (byte) cmbMoveType.SelectedIndex;
		if (cmbMoveType.SelectedIndex == 2)
		{
			btnMoveRoute.Enabled = true;
		}
		else
		{
			btnMoveRoute.Enabled = false;
		}
	}
	
	public void BtnMoveRoute_Click(object sender, EventArgs e)
	{
		fraMoveRoute.BringToFront();
		lstMoveRoute.Items.Clear();
		cmbEvent.Items.Clear();
		cmbEvent.Items.Add("This Event");
		cmbEvent.SelectedIndex = 0;
		cmbEvent.Enabled = false;
		C_EventSystem.IsMoveRouteCommand = false;
		chkIgnoreMove.Checked = System.Convert.ToBoolean(C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].IgnoreMoveRoute);
		chkRepeatRoute.Checked = System.Convert.ToBoolean(C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].RepeatMoveRoute);
		C_EventSystem.TempMoveRouteCount = C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].MoveRouteCount;
		
		//Will it let me do this
		C_EventSystem.TempMoveRoute = C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].MoveRoute;
		for (var i = 1; i <= C_EventSystem.TempMoveRouteCount; i++)
		{
			switch (C_EventSystem.TempMoveRoute[(int) i].Index)
			{
				case 1:
					lstMoveRoute.Items.Add("Move Up");
					break;
				case 2:
					lstMoveRoute.Items.Add("Move Down");
					break;
				case 3:
					lstMoveRoute.Items.Add("Move Left");
					break;
				case 4:
					lstMoveRoute.Items.Add("Move Right");
					break;
				case 5:
					lstMoveRoute.Items.Add("Move Randomly");
					break;
				case 6:
					lstMoveRoute.Items.Add("Move Towards Player");
					break;
				case 7:
					lstMoveRoute.Items.Add("Move Away From Player");
					break;
				case 8:
					lstMoveRoute.Items.Add("Step Forward");
					break;
				case 9:
					lstMoveRoute.Items.Add("Step Back");
					break;
				case 10:
					lstMoveRoute.Items.Add("Wait 100ms");
					break;
				case 11:
					lstMoveRoute.Items.Add("Wait 500ms");
					break;
				case 12:
					lstMoveRoute.Items.Add("Wait 1000ms");
					break;
				case 13:
					lstMoveRoute.Items.Add("Turn Up");
					break;
				case 14:
					lstMoveRoute.Items.Add("Turn Down");
					break;
				case 15:
					lstMoveRoute.Items.Add("Turn Left");
					break;
				case 16:
					lstMoveRoute.Items.Add("Turn Right");
					break;
				case 17:
					lstMoveRoute.Items.Add("Turn 90 Degrees To the Right");
					break;
				case 18:
					lstMoveRoute.Items.Add("Turn 90 Degrees To the Left");
					break;
				case 19:
					lstMoveRoute.Items.Add("Turn Around 180 Degrees");
					break;
				case 20:
					lstMoveRoute.Items.Add("Turn Randomly");
					break;
				case 21:
					lstMoveRoute.Items.Add("Turn Towards Player");
					break;
				case 22:
					lstMoveRoute.Items.Add("Turn Away from Player");
					break;
				case 23:
					lstMoveRoute.Items.Add("Set Speed 8x Slower");
					break;
				case 24:
					lstMoveRoute.Items.Add("Set Speed 4x Slower");
					break;
				case 25:
					lstMoveRoute.Items.Add("Set Speed 2x Slower");
					break;
				case 26:
					lstMoveRoute.Items.Add("Set Speed to Normal");
					break;
				case 27:
					lstMoveRoute.Items.Add("Set Speed 2x Faster");
					break;
				case 28:
					lstMoveRoute.Items.Add("Set Speed 4x Faster");
					break;
				case 29:
					lstMoveRoute.Items.Add("Set Frequency Lowest");
					break;
				case 30:
					lstMoveRoute.Items.Add("Set Frequency Lower");
					break;
				case 31:
					lstMoveRoute.Items.Add("Set Frequency Normal");
					break;
				case 32:
					lstMoveRoute.Items.Add("Set Frequency Higher");
					break;
				case 33:
					lstMoveRoute.Items.Add("Set Frequency Highest");
					break;
				case 34:
					lstMoveRoute.Items.Add("Turn On Walking Animation");
					break;
				case 35:
					lstMoveRoute.Items.Add("Turn Off Walking Animation");
					break;
				case 36:
					lstMoveRoute.Items.Add("Turn On Fixed Direction");
					break;
				case 37:
					lstMoveRoute.Items.Add("Turn Off Fixed Direction");
					break;
				case 38:
					lstMoveRoute.Items.Add("Turn On Walk Through");
					break;
				case 39:
					lstMoveRoute.Items.Add("Turn Off Walk Through");
					break;
				case 40:
					lstMoveRoute.Items.Add("Set Position Below Player");
					break;
				case 41:
					lstMoveRoute.Items.Add("Set Position at Player Level");
					break;
				case 42:
					lstMoveRoute.Items.Add("Set Position Above Player");
					break;
				case 43:
					lstMoveRoute.Items.Add("Set Graphic");
					break;
			}
		}
		
		fraMoveRoute.Visible = true;
		
	}
	
	public void CmbMoveSpeed_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbMoveSpeed.SelectedIndex == -1)
		{
			return;
		}
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].MoveSpeed = (byte) cmbMoveSpeed.SelectedIndex;
	}
	
	public void CmbMoveFreq_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbMoveFreq.SelectedIndex == -1)
		{
			return;
		}
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].MoveFreq = (byte) cmbMoveFreq.SelectedIndex;
	}
	
#endregion
	
#region Positioning
	
	public void CmbPositioning_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbPositioning.SelectedIndex == -1)
		{
			return;
		}
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].Position = (byte) cmbPositioning.SelectedIndex;
	}
	
#endregion
	
#region Trigger
	
	public void CmbTrigger_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbTrigger.SelectedIndex == -1)
		{
			return;
		}
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].Trigger = (byte) cmbTrigger.SelectedIndex;
	}
	
#endregion
	
#region Global
	
	public void ChkGlobal_CheckedChanged(object sender, EventArgs e)
	{
		if (C_EventSystem.TmpEvent.PageCount > 1)
		{
			if (Interaction.MsgBox("If you set the event to global you will lose all pages except for your first one. Do you want to continue?", Microsoft.VisualBasic.Constants.vbYesNo, null) == Microsoft.VisualBasic.Constants.vbNo)
			{
				return;
			}
		}
		if (chkGlobal.Checked == true)
		{
			C_EventSystem.TmpEvent.Globals = 1;
		}
		else
		{
			C_EventSystem.TmpEvent.Globals = 0;
		}
		
		C_EventSystem.TmpEvent.PageCount = 1;
		C_EventSystem.CurPageNum = 1;
		this.tabPages.TabPages.Clear();
		
		for (var i = 1; i <= C_EventSystem.TmpEvent.PageCount; i++)
		{
			this.tabPages.TabPages.Add("0", Conversion.Str(i), "0");
		}
		C_EventSystem.EventEditorLoadPage(C_EventSystem.CurPageNum);
	}
	
#endregion
	
#region Quest
	
	public void CmbEventQuest_SelectedIndexChanged(object sender, EventArgs e)
	{
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].Questnum = cmbEventQuest.SelectedIndex;
	}
	
#endregion
	
#region Options
	
	public void ChkWalkAnim_CheckedChanged(object sender, EventArgs e)
	{
		if (chkWalkAnim.Checked == true)
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].WalkAnim = (byte) 1;
		}
		else
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].WalkAnim = (byte) 0;
		}
		
	}
	
	public void ChkDirFix_CheckedChanged(object sender, EventArgs e)
	{
		if (chkDirFix.Checked == true)
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].DirFix = (byte) 1;
		}
		else
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].DirFix = (byte) 0;
		}
		
	}
	
	public void ChkWalkThrough_CheckedChanged(object sender, EventArgs e)
	{
		if (chkWalkThrough.Checked == true)
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].WalkThrough = (byte) 1;
		}
		else
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].WalkThrough = (byte) 0;
		}
		
	}
	
	public void ChkShowName_CheckedChanged(object sender, EventArgs e)
	{
		if (chkShowName.Checked == true)
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].ShowName = (byte) 1;
		}
		else
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].ShowName = (byte) 0;
		}
		
	}
	
#endregion
	
#region Commands
	
	public void LstCommands_SelectedIndexChanged(object sender, EventArgs e)
	{
		C_EventSystem.CurCommand = lstCommands.SelectedIndex + 1;
	}
	
	public void BtnAddCommand_Click(object sender, EventArgs e)
	{
		if (lstCommands.SelectedIndex > -1)
		{
			C_EventSystem.IsEdit = false;
			//tabPages.SelectedTab = TabPage
			fraCommands.Visible = true;
		}
	}
	
	public void BtnEditCommand_Click(object sender, EventArgs e)
	{
		if (lstCommands.SelectedIndex > -1)
		{
			C_EventSystem.EditEventCommand();
		}
	}
	
	public void BtnDeleteComand_Click(object sender, EventArgs e)
	{
		if (lstCommands.SelectedIndex > -1)
		{
			C_EventSystem.DeleteEventCommand();
		}
		
	}
	
	public void BtnClearCommand_Click(object sender, EventArgs e)
	{
		if (Interaction.MsgBox("Are you sure you want to clear all event commands?", Microsoft.VisualBasic.Constants.vbYesNo, "Clear Event Commands?") == Microsoft.VisualBasic.Constants.vbYes)
		{
			C_EventSystem.ClearEventCommands();
		}
	}
	
#endregion
	
#region Variables/Switches
	
	//    'Renaming Variables/Switches
	public void BtnLabeling_Click(object sender, EventArgs e)
	{
		pnlVariableSwitches.Visible = true;
		pnlVariableSwitches.BringToFront();
		pnlVariableSwitches.Top = 0;
		pnlVariableSwitches.Left = 0;
		pnlVariableSwitches.Width = Width;
		pnlVariableSwitches.Height = Height;
		lstSwitches.Items.Clear();
		
		for (var i = 1; i <= C_EventSystem.MaxSwitches; i++)
		{
			lstSwitches.Items.Add(Convert.ToString(i)+". " + C_EventSystem.Switches[(int) i].Trim());
		}
		lstSwitches.SelectedIndex = 0;
		lstVariables.Items.Clear();
		
		for (var i = 1; i <= C_EventSystem.MaxVariables; i++)
		{
			lstVariables.Items.Add(Convert.ToString(i)+". " + C_EventSystem.Variables[(int) i].Trim());
		}
		lstVariables.SelectedIndex = 0;
		
	}
	
	public void BtnRename_Ok_Click(object sender, EventArgs e)
	{
		switch (C_EventSystem.RenameType)
		{
			case 1:
				//Variable
				if (C_EventSystem.Renameindex > 0 && C_EventSystem.Renameindex <= C_EventSystem.MaxVariables + 1)
				{
					C_EventSystem.Variables[C_EventSystem.Renameindex] = txtRename.Text;
					FraRenaming.Visible = false;
					fraLabeling.Visible = true;
					C_EventSystem.RenameType = 0;
					C_EventSystem.Renameindex = 0;
				}
				break;
			case 2:
				//Switch
				if (C_EventSystem.Renameindex > 0 && C_EventSystem.Renameindex <= C_EventSystem.MaxSwitches + 1)
				{
					C_EventSystem.Switches[C_EventSystem.Renameindex] = txtRename.Text;
					FraRenaming.Visible = false;
					fraLabeling.Visible = true;
					C_EventSystem.RenameType = 0;
					C_EventSystem.Renameindex = 0;
				}
				break;
		}
		lstSwitches.Items.Clear();
		
		for (var i = 1; i <= C_EventSystem.MaxSwitches; i++)
		{
			lstSwitches.Items.Add(Convert.ToString(i)+". " + C_EventSystem.Switches[(int) i].Trim());
		}
		lstSwitches.SelectedIndex = 0;
		lstVariables.Items.Clear();
		
		for (var i = 1; i <= C_EventSystem.MaxVariables; i++)
		{
			lstVariables.Items.Add(Convert.ToString(i)+". " + C_EventSystem.Variables[(int) i].Trim());
		}
		lstVariables.SelectedIndex = 0;
	}
	
	public void BtnRename_Cancel_Click(object sender, EventArgs e)
	{
		FraRenaming.Visible = false;
		C_EventSystem.RenameType = 0;
		C_EventSystem.Renameindex = 0;
		lstSwitches.Items.Clear();
		
		for (var i = 1; i <= C_EventSystem.MaxSwitches; i++)
		{
			lstSwitches.Items.Add(Convert.ToString(i)+". " + C_EventSystem.Switches[(int) i].Trim());
		}
		lstSwitches.SelectedIndex = 0;
		lstVariables.Items.Clear();
		
		for (var i = 1; i <= C_EventSystem.MaxVariables; i++)
		{
			lstVariables.Items.Add(Convert.ToString(i)+". " + C_EventSystem.Variables[(int) i].Trim());
		}
		lstVariables.SelectedIndex = 0;
	}
	
	public void TxtRename_TextChanged(object sender, EventArgs e)
	{
		C_EventSystem.TmpEvent.Name = txtName.Text.Trim();
	}
	
	public void LstVariables_DoubleClick(object sender, EventArgs e)
	{
		if (lstVariables.SelectedIndex > -1 && lstVariables.SelectedIndex < C_EventSystem.MaxVariables)
		{
			FraRenaming.Visible = true;
			fraLabeling.Visible = false;
			lblEditing.Text = "Editing Variable #" + Convert.ToString(lstVariables.SelectedIndex + 1);
			txtRename.Text = C_EventSystem.Variables[lstVariables.SelectedIndex + 1];
			C_EventSystem.RenameType = 1;
			C_EventSystem.Renameindex = lstVariables.SelectedIndex + 1;
		}
	}
	
	public void LstSwitches_DoubleClick(object sender, EventArgs e)
	{
		if (lstSwitches.SelectedIndex > -1 && lstSwitches.SelectedIndex < C_EventSystem.MaxSwitches)
		{
			FraRenaming.Visible = true;
			fraLabeling.Visible = false;
			lblEditing.Text = "Editing Switch #" + Convert.ToString(lstSwitches.SelectedIndex + 1);
			txtRename.Text = C_EventSystem.Switches[lstSwitches.SelectedIndex + 1];
			C_EventSystem.RenameType = 2;
			C_EventSystem.Renameindex = lstSwitches.SelectedIndex + 1;
		}
	}
	
	public void BtnRenameVariable_Click(object sender, EventArgs e)
	{
		if (lstVariables.SelectedIndex > -1 && lstVariables.SelectedIndex < C_EventSystem.MaxVariables)
		{
			FraRenaming.Visible = true;
			fraLabeling.Visible = false;
			lblEditing.Text = "Editing Variable #" + Convert.ToString(lstVariables.SelectedIndex + 1);
			txtRename.Text = C_EventSystem.Variables[lstVariables.SelectedIndex + 1];
			C_EventSystem.RenameType = 1;
			C_EventSystem.Renameindex = lstVariables.SelectedIndex + 1;
		}
	}
	
	public void BtnRenameSwitch_Click(object sender, EventArgs e)
	{
		if (lstSwitches.SelectedIndex > -1 && lstSwitches.SelectedIndex < C_EventSystem.MaxSwitches)
		{
			FraRenaming.Visible = true;
			lblEditing.Text = "Editing Switch #" + Convert.ToString(lstSwitches.SelectedIndex + 1);
			txtRename.Text = C_EventSystem.Switches[lstSwitches.SelectedIndex + 1];
			C_EventSystem.RenameType = 2;
			C_EventSystem.Renameindex = lstSwitches.SelectedIndex + 1;
		}
	}
	
	public void BtnLabel_Ok_Click(object sender, EventArgs e)
	{
		pnlVariableSwitches.Visible = false;
		C_EventSystem.SendSwitchesAndVariables();
	}
	
	public void BtnLabel_Cancel_Click(object sender, EventArgs e)
	{
		pnlVariableSwitches.Visible = false;
		C_EventSystem.RequestSwitchesAndVariables();
	}
	
#endregion
	
#region Move Route
	
	//MoveRoute Commands
	public void LstvwMoveRoute_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (lstvwMoveRoute.SelectedItems.Count == 0)
		{
			return;
		}
		
		//Set Graphic
		if ((int) (lstvwMoveRoute.SelectedItems[0].Index + 1) == 43)
		{
			fraGraphic.Width = 841;
			fraGraphic.Height = 585;
			fraGraphic.Visible = true;
			fraGraphic.BringToFront();
			C_EventSystem.GraphicSelType = 1;
		}
		else
		{
			AddMoveRouteCommand(lstvwMoveRoute.SelectedItems[0].Index);
		}
	}
	
	public void LstMoveRoute_KeyDown(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Delete)
		{
			//remove move route command lol
			if (lstMoveRoute.SelectedIndex > -1)
			{
				RemoveMoveRouteCommand(lstMoveRoute.SelectedIndex);
			}
		}
	}
	
	public void AddMoveRouteCommand(int Index)
	{
		int i = 0;
		int X = 0;
		
		Index++;
		if (lstMoveRoute.SelectedIndex > -1)
		{
			i = lstMoveRoute.SelectedIndex + 1;
			C_EventSystem.TempMoveRouteCount++;
			Array.Resize(ref C_EventSystem.TempMoveRoute, C_EventSystem.TempMoveRouteCount + 1);
			for (X = C_EventSystem.TempMoveRouteCount - 1; X >= i; X--)
			{
				C_EventSystem.TempMoveRoute[X + 1] = C_EventSystem.TempMoveRoute[X];
			}
			C_EventSystem.TempMoveRoute[i].Index = Index;
			//if set graphic then...
			if (Index == 43)
			{
				C_EventSystem.TempMoveRoute[i].Data1 = cmbGraphic.SelectedIndex;
				C_EventSystem.TempMoveRoute[i].Data2 = (int) nudGraphic.Value;
				C_EventSystem.TempMoveRoute[i].Data3 = C_EventSystem.GraphicSelX;
				C_EventSystem.TempMoveRoute[i].Data4 = C_EventSystem.GraphicSelX2;
				C_EventSystem.TempMoveRoute[i].Data5 = C_EventSystem.GraphicSelY;
				C_EventSystem.TempMoveRoute[i].Data6 = C_EventSystem.GraphicSelY2;
			}
			PopulateMoveRouteList();
		}
		else
		{
			C_EventSystem.TempMoveRouteCount++;
			Array.Resize(ref C_EventSystem.TempMoveRoute, C_EventSystem.TempMoveRouteCount + 1);
			C_EventSystem.TempMoveRoute[C_EventSystem.TempMoveRouteCount].Index = Index;
			PopulateMoveRouteList();
			//if set graphic then....
			if (Index == 43)
			{
				C_EventSystem.TempMoveRoute[C_EventSystem.TempMoveRouteCount].Data1 = cmbGraphic.SelectedIndex;
				C_EventSystem.TempMoveRoute[C_EventSystem.TempMoveRouteCount].Data2 = (int) nudGraphic.Value;
				C_EventSystem.TempMoveRoute[C_EventSystem.TempMoveRouteCount].Data3 = C_EventSystem.GraphicSelX;
				C_EventSystem.TempMoveRoute[C_EventSystem.TempMoveRouteCount].Data4 = C_EventSystem.GraphicSelX2;
				C_EventSystem.TempMoveRoute[C_EventSystem.TempMoveRouteCount].Data5 = C_EventSystem.GraphicSelY;
				C_EventSystem.TempMoveRoute[C_EventSystem.TempMoveRouteCount].Data6 = C_EventSystem.GraphicSelY2;
			}
		}
		
	}
	
	public void RemoveMoveRouteCommand(int Index)
	{
		int i = 0;
		
		Index++;
		if (Index > 0 && Index <= C_EventSystem.TempMoveRouteCount)
		{
			for (i = Index + 1; i <= C_EventSystem.TempMoveRouteCount; i++)
			{
				C_EventSystem.TempMoveRoute[i - 1] = C_EventSystem.TempMoveRoute[i];
			}
			C_EventSystem.TempMoveRouteCount--;
			if (C_EventSystem.TempMoveRouteCount == 0)
			{
				C_EventSystem.TempMoveRoute = new C_EventSystem.MoveRouteRec[1];
			}
			else
			{
				Array.Resize(ref C_EventSystem.TempMoveRoute, C_EventSystem.TempMoveRouteCount + 1);
			}
			PopulateMoveRouteList();
		}
		
	}
	
	public void PopulateMoveRouteList()
	{
		int i = 0;
		
		lstMoveRoute.Items.Clear();
		
		for (i = 1; i <= C_EventSystem.TempMoveRouteCount; i++)
		{
			switch (C_EventSystem.TempMoveRoute[i].Index)
			{
				case 1:
					lstMoveRoute.Items.Add("Move Up");
					break;
				case 2:
					lstMoveRoute.Items.Add("Move Down");
					break;
				case 3:
					lstMoveRoute.Items.Add("Move Left");
					break;
				case 4:
					lstMoveRoute.Items.Add("Move Right");
					break;
				case 5:
					lstMoveRoute.Items.Add("Move Randomly");
					break;
				case 6:
					lstMoveRoute.Items.Add("Move Towards Player");
					break;
				case 7:
					lstMoveRoute.Items.Add("Move Away From Player");
					break;
				case 8:
					lstMoveRoute.Items.Add("Step Forward");
					break;
				case 9:
					lstMoveRoute.Items.Add("Step Back");
					break;
				case 10:
					lstMoveRoute.Items.Add("Wait 100ms");
					break;
				case 11:
					lstMoveRoute.Items.Add("Wait 500ms");
					break;
				case 12:
					lstMoveRoute.Items.Add("Wait 1000ms");
					break;
				case 13:
					lstMoveRoute.Items.Add("Turn Up");
					break;
				case 14:
					lstMoveRoute.Items.Add("Turn Down");
					break;
				case 15:
					lstMoveRoute.Items.Add("Turn Left");
					break;
				case 16:
					lstMoveRoute.Items.Add("Turn Right");
					break;
				case 17:
					lstMoveRoute.Items.Add("Turn 90 Degrees To the Right");
					break;
				case 18:
					lstMoveRoute.Items.Add("Turn 90 Degrees To the Left");
					break;
				case 19:
					lstMoveRoute.Items.Add("Turn Around 180 Degrees");
					break;
				case 20:
					lstMoveRoute.Items.Add("Turn Randomly");
					break;
				case 21:
					lstMoveRoute.Items.Add("Turn Towards Player");
					break;
				case 22:
					lstMoveRoute.Items.Add("Turn Away from Player");
					break;
				case 23:
					lstMoveRoute.Items.Add("Set Speed 8x Slower");
					break;
				case 24:
					lstMoveRoute.Items.Add("Set Speed 4x Slower");
					break;
				case 25:
					lstMoveRoute.Items.Add("Set Speed 2x Slower");
					break;
				case 26:
					lstMoveRoute.Items.Add("Set Speed to Normal");
					break;
				case 27:
					lstMoveRoute.Items.Add("Set Speed 2x Faster");
					break;
				case 28:
					lstMoveRoute.Items.Add("Set Speed 4x Faster");
					break;
				case 29:
					lstMoveRoute.Items.Add("Set Frequency Lowest");
					break;
				case 30:
					lstMoveRoute.Items.Add("Set Frequency Lower");
					break;
				case 31:
					lstMoveRoute.Items.Add("Set Frequency Normal");
					break;
				case 32:
					lstMoveRoute.Items.Add("Set Frequency Higher");
					break;
				case 33:
					lstMoveRoute.Items.Add("Set Frequency Highest");
					break;
				case 34:
					lstMoveRoute.Items.Add("Turn On Walking Animation");
					break;
				case 35:
					lstMoveRoute.Items.Add("Turn Off Walking Animation");
					break;
				case 36:
					lstMoveRoute.Items.Add("Turn On Fixed Direction");
					break;
				case 37:
					lstMoveRoute.Items.Add("Turn Off Fixed Direction");
					break;
				case 38:
					lstMoveRoute.Items.Add("Turn On Walk Through");
					break;
				case 39:
					lstMoveRoute.Items.Add("Turn Off Walk Through");
					break;
				case 40:
					lstMoveRoute.Items.Add("Set Position Below Player");
					break;
				case 41:
					lstMoveRoute.Items.Add("Set Position at Player Level");
					break;
				case 42:
					lstMoveRoute.Items.Add("Set Position Above Player");
					break;
				case 43:
					lstMoveRoute.Items.Add("Set Graphic");
					break;
			}
		}
		
	}
	
	public void ChkIgnoreMove_CheckedChanged(object sender, EventArgs e)
	{
		if (chkIgnoreMove.Checked == true)
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].IgnoreMoveRoute = 1;
		}
		else
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].IgnoreMoveRoute = 0;
		}
	}
	
	public void ChkRepeatRoute_CheckedChanged(object sender, EventArgs e)
	{
		if (chkRepeatRoute.Checked == true)
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].RepeatMoveRoute = 1;
		}
		else
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].RepeatMoveRoute = 0;
		}
	}
	
	public void BtnMoveRouteOk_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.IsMoveRouteCommand == true)
		{
			if (!C_EventSystem.IsEdit)
			{
				C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvSetMoveRoute);
			}
			else
			{
				C_EventSystem.EditCommand();
			}
			C_EventSystem.TempMoveRouteCount = 0;
			C_EventSystem.TempMoveRoute = new C_EventSystem.MoveRouteRec[1];
			fraMoveRoute.Visible = false;
		}
		else
		{
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].MoveRouteCount = C_EventSystem.TempMoveRouteCount;
			C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].MoveRoute = C_EventSystem.TempMoveRoute;
			C_EventSystem.TempMoveRouteCount = 0;
			C_EventSystem.TempMoveRoute = new C_EventSystem.MoveRouteRec[1];
			fraMoveRoute.Visible = false;
		}
	}
	
	public void BtnMoveRouteCancel_Click(object sender, EventArgs e)
	{
		C_EventSystem.TempMoveRouteCount = 0;
		C_EventSystem.TempMoveRoute = new C_EventSystem.MoveRouteRec[1];
		fraMoveRoute.Visible = false;
	}
	
#endregion
	
#region CommandFrames
	
#region Show Text
	
	public void NudShowTextFace_ValueChanged(object sender, EventArgs e)
	{
		if (nudShowTextFace.Value > 0)
		{
			if (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Faces\\" + System.Convert.ToString(nudShowTextFace.Value) + C_Constants.GfxExt))
			{
				picShowTextFace.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxPath + "Faces\\" + System.Convert.ToString(nudShowTextFace.Value) + C_Constants.GfxExt);
			}
		}
		else
		{
			picShowTextFace.BackgroundImage = null;
		}
	}
	
	public void BtnShowTextOk_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvShowText);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		
		// hide
		fraDialogue.Visible = false;
		fraShowText.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnShowTextCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraShowText.Visible = false;
	}
	
#endregion
	
#region Add Text
	
	public void BtnAddTextOk_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvAddText);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraAddText.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnAddTextCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraAddText.Visible = false;
	}
	
#endregion
	
#region Show Choices
	
	public void NudShowChoicesFace_ValueChanged(object sender, EventArgs e)
	{
		if (nudShowChoicesFace.Value > 0)
		{
			if (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Faces\\" + System.Convert.ToString(nudShowChoicesFace.Value) + C_Constants.GfxExt))
			{
				picShowChoicesFace.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxPath + "Faces\\" + System.Convert.ToString(nudShowChoicesFace.Value) + C_Constants.GfxExt);
			}
		}
		else
		{
			picShowChoicesFace.Text = "Face: None";
			picShowChoicesFace.BackgroundImage = null;
		}
	}
	
	public void BtnShowChoicesOk_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvShowChoices);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraShowChoices.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnShowChoicesCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraShowChoices.Visible = false;
	}
	
#endregion
	
#region Show Chatbubble
	
	public void CmbChatBubbleTargetType_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (cmbChatBubbleTargetType.SelectedIndex == 0)
		{
			cmbChatBubbleTarget.Visible = false;
		}
		else if (cmbChatBubbleTargetType.SelectedIndex == 1)
		{
			cmbChatBubbleTarget.Visible = true;
			cmbChatBubbleTarget.Items.Clear();
			
			for (var i = 1; i <= Constants.MAX_MAP_NPCS; i++)
			{
				if (C_Maps.Map.Npc[(int) i] <= 0)
				{
					cmbChatBubbleTarget.Items.Add(i +". ");
				}
				else
				{
					cmbChatBubbleTarget.Items.Add(i +". " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[C_Maps.Map.Npc[(int) i]].Name));
				}
			}
			cmbChatBubbleTarget.SelectedIndex = 0;
		}
		else if (cmbChatBubbleTargetType.SelectedIndex == 2)
		{
			cmbChatBubbleTarget.Visible = true;
			cmbChatBubbleTarget.Items.Clear();
			
			for (var i = 1; i <= C_Maps.Map.EventCount; i++)
			{
				cmbChatBubbleTarget.Items.Add(i +". " + Microsoft.VisualBasic.Strings.Trim(C_Maps.Map.Events[(int) i].Name));
			}
			cmbChatBubbleTarget.SelectedIndex = 0;
		}
		
	}
	
	public void BtnShowChatBubbleOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvShowChatBubble);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraShowChatBubble.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnShowChatBubbleCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraShowChatBubble.Visible = false;
	}
	
#endregion
	
#region Set Player Variable
	
	public void OptVariableAction0_CheckedChanged(object sender, EventArgs e)
	{
		if (optVariableAction0.Checked == true)
		{
			nudVariableData0.Enabled = true;
			nudVariableData0.Value = 0;
			nudVariableData1.Enabled = false;
			nudVariableData1.Value = 0;
			nudVariableData2.Enabled = false;
			nudVariableData2.Value = 0;
			nudVariableData3.Enabled = false;
			nudVariableData3.Value = 0;
			nudVariableData4.Enabled = false;
			nudVariableData4.Value = 0;
		}
	}
	
	public void OptVariableAction1_CheckedChanged(object sender, EventArgs e)
	{
		if (optVariableAction1.Checked == true)
		{
			nudVariableData0.Enabled = false;
			nudVariableData0.Value = 0;
			nudVariableData1.Enabled = true;
			nudVariableData1.Value = 0;
			nudVariableData2.Enabled = false;
			nudVariableData2.Value = 0;
			nudVariableData3.Enabled = false;
			nudVariableData3.Value = 0;
			nudVariableData4.Enabled = false;
			nudVariableData4.Value = 0;
		}
	}
	
	public void OptVariableAction2_CheckedChanged(object sender, EventArgs e)
	{
		if (optVariableAction2.Checked == true)
		{
			nudVariableData0.Enabled = false;
			nudVariableData0.Value = 0;
			nudVariableData1.Enabled = false;
			nudVariableData1.Value = 0;
			nudVariableData2.Enabled = true;
			nudVariableData2.Value = 0;
			nudVariableData3.Enabled = false;
			nudVariableData3.Value = 0;
			nudVariableData4.Enabled = false;
			nudVariableData4.Value = 0;
		}
	}
	
	public void OptVariableAction3_CheckedChanged(object sender, EventArgs e)
	{
		if (optVariableAction2.Checked == true)
		{
			nudVariableData0.Enabled = false;
			nudVariableData0.Value = 0;
			nudVariableData1.Enabled = false;
			nudVariableData1.Value = 0;
			nudVariableData2.Enabled = false;
			nudVariableData2.Value = 0;
			nudVariableData3.Enabled = true;
			nudVariableData3.Value = 0;
			nudVariableData4.Enabled = true;
			nudVariableData4.Value = 0;
		}
	}
	
	public void BtnPlayerVarOk_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvPlayerVar);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraPlayerVariable.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnPlayerVarCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraPlayerVariable.Visible = false;
	}
	
#endregion
	
#region Set Player Switch
	
	public void BtnSetPlayerSwitchOk_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvPlayerSwitch);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraPlayerSwitch.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnSetPlayerswitchCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraPlayerSwitch.Visible = false;
	}
	
#endregion
	
#region Set Self Switch
	
	public void BtnSelfswitchOk_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvSelfSwitch);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraSetSelfSwitch.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnSelfswitchCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraSetSelfSwitch.Visible = false;
	}
	
#endregion
	
#region Conditional Branch
	
	public void OptCondition_Index0_CheckedChanged(object sender, EventArgs e)
	{
		if (!optCondition0.Checked)
		{
			return;
		}
		
		ClearConditionFrame();
		
		cmbCondition_PlayerVarIndex.Enabled = true;
		cmbCondition_PlayerVarCompare.Enabled = true;
		nudCondition_PlayerVarCondition.Enabled = true;
	}
	
	public void OptCondition1_CheckedChanged(object sender, EventArgs e)
	{
		if (!optCondition1.Checked)
		{
			return;
		}
		
		ClearConditionFrame();
		
		cmbCondition_PlayerSwitch.Enabled = true;
		cmbCondtion_PlayerSwitchCondition.Enabled = true;
	}
	
	public void OptCondition2_CheckedChanged(object sender, EventArgs e)
	{
		if (!optCondition2.Checked)
		{
			return;
		}
		
		ClearConditionFrame();
		
		cmbCondition_HasItem.Enabled = true;
		nudCondition_HasItem.Enabled = true;
	}
	
	public void OptCondition3_CheckedChanged(object sender, EventArgs e)
	{
		if (!optCondition3.Checked)
		{
			return;
		}
		
		ClearConditionFrame();
		
		cmbCondition_ClassIs.Enabled = true;
	}
	
	public void OptCondition4_CheckedChanged(object sender, EventArgs e)
	{
		if (!optCondition4.Checked)
		{
			return;
		}
		
		cmbCondition_LearntSkill.Enabled = true;
	}
	
	public void OptCondition5_CheckedChanged(object sender, EventArgs e)
	{
		if (!optCondition5.Checked)
		{
			return;
		}
		
		ClearConditionFrame();
		
		cmbCondition_LevelCompare.Enabled = true;
		nudCondition_LevelAmount.Enabled = true;
	}
	
	public void OptCondition6_CheckedChanged(object sender, EventArgs e)
	{
		if (!optCondition6.Checked)
		{
			return;
		}
		
		ClearConditionFrame();
		
		cmbCondition_SelfSwitch.Enabled = true;
		cmbCondition_SelfSwitchCondition.Enabled = true;
	}
	
	public void OptCondition7_CheckedChanged(object sender, EventArgs e)
	{
		if (!optCondition7.Checked)
		{
			return;
		}
		
		ClearConditionFrame();
		
		fraConditions_Quest.Visible = true;
		nudCondition_Quest.Enabled = true;
	}
	
	public void OptCondition8_CheckedChanged(object sender, EventArgs e)
	{
		if (!optCondition8.Checked)
		{
			return;
		}
		
		ClearConditionFrame();
		
		cmbCondition_Gender.Enabled = true;
	}
	
	public void OptCondition9_CheckedChanged(object sender, EventArgs e)
	{
		if (!optCondition9.Checked)
		{
			return;
		}
		
		ClearConditionFrame();
		
		cmbCondition_Time.Enabled = true;
	}
	
	public void BtnConditionalBranchOk_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.IsEdit == false)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvCondition);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraCommands.Visible = false;
		fraConditionalBranch.Visible = false;
	}
	
	public void BtnConditionalBranchCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraConditionalBranch.Visible = false;
	}
	
#endregion
	
#region Create Label
	
	public void BtnCreatelabelOk_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.IsEdit == false)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvLabel);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraCreateLabel.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnCreateLabelCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraCreateLabel.Visible = false;
	}
	
#endregion
	
#region GoTo Label
	
	public void BtnGoToLabelOk_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.IsEdit == false)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvGotoLabel);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraGoToLabel.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnGoToLabelCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraGoToLabel.Visible = false;
	}
	
#endregion
	
#region Change Items
	
	public void BtnChangeItemsOk_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.IsEdit == false)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvChangeItems);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraCommands.Visible = false;
		fraChangeItems.Visible = false;
	}
	
	public void BtnChangeItemsCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraChangeItems.Visible = false;
	}
	
	public void CmbChangeItemIndex_SelectedIndexChanged(object sender, EventArgs e)
	{
		C_EventSystem.TmpEvent.Pages[C_EventSystem.CurPageNum].Questnum = cmbEventQuest.SelectedIndex;
	}
	
#endregion
	
#region Change Level
	
	public void BtnChangeLevelOK_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.IsEdit == false)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvChangeLevel);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraChangeLevel.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnChangeLevelCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraChangeLevel.Visible = false;
	}
	
#endregion
	
#region Change Skills
	
	public void BtnChangeSkillsOK_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.IsEdit == false)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvChangeSkills);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraChangeSkills.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnChangeSkillsCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraChangeSkills.Visible = false;
	}
	
#endregion
	
#region Change Class
	
	public void BtnChangeClassOK_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.IsEdit == false)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvChangeClass);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraChangeClass.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnChangeClassCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraChangeClass.Visible = false;
	}
	
#endregion
	
#region Change Sprite
	
	public void BtnChangeSpriteOK_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.IsEdit == false)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvChangeSprite);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraChangeSprite.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnChangeSpriteCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraChangeSprite.Visible = false;
	}
	
#endregion
	
#region Change Gender
	
	public void BtnChangeGenderOK_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.IsEdit == false)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvChangeSex);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraChangeGender.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnChangeGenderCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraChangeGender.Visible = false;
	}
	
#endregion
	
#region Change PK
	
	public void BtnChangePkOK_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.IsEdit == false)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvChangePk);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraChangePK.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnChangePkCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraChangePK.Visible = false;
	}
	
#endregion
	
#region Give Exp
	
	public void BtnGiveExpOK_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.IsEdit == false)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvGiveExp);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraGiveExp.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnGiveExpCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraGiveExp.Visible = false;
	}
	
#endregion
	
#region Player Warp
	
	public void BtnPlayerWarpOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvWarpPlayer);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraPlayerWarp.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnPlayerWarpCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraPlayerWarp.Visible = false;
	}
	
#endregion
	
#region Route Completion
	
	public void BtnMoveWaitOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvWaitMovement);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraMoveRouteWait.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnMoveWaitCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraMoveRouteWait.Visible = false;
	}
	
#endregion
	
#region Spawn Npc
	
	public void BtnSpawnNpcOK_Click(object sender, EventArgs e)
	{
		if (C_EventSystem.IsEdit == false)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvSpawnNpc);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraSpawnNpc.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnSpawnNpcCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraSpawnNpc.Visible = false;
	}
	
#endregion
	
#region Play Animation
	
	private void OptPlayAnimPlayer_CheckedChanged(object sender, EventArgs e)
	{
		lblPlayAnimX.Visible = false;
		lblPlayAnimY.Visible = false;
		nudPlayAnimTileX.Visible = false;
		nudPlayAnimTileY.Visible = false;
		cmbPlayAnimEvent.Visible = false;
	}
	
	private void OptPlayAnimEvent_CheckedChanged(object sender, EventArgs e)
	{
		lblPlayAnimX.Visible = false;
		lblPlayAnimY.Visible = false;
		nudPlayAnimTileX.Visible = false;
		nudPlayAnimTileY.Visible = false;
		cmbPlayAnimEvent.Visible = true;
	}
	
	private void OptPlayAnimTile_CheckedChanged(object sender, EventArgs e)
	{
		lblPlayAnimX.Visible = true;
		lblPlayAnimY.Visible = true;
		nudPlayAnimTileX.Visible = true;
		nudPlayAnimTileY.Visible = true;
		cmbPlayAnimEvent.Visible = false;
	}
	
	public void BtnPlayAnimationOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvPlayAnimation);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraPlayAnimation.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnPlayAnimationCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraPlayAnimation.Visible = false;
	}
	
#endregion
	
#region Begin Quest
	
	public void BtnBeginQuestOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvBeginQuest);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraBeginQuest.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnBeginQuestCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraBeginQuest.Visible = false;
	}
	
#endregion
	
#region Complete QuestTask
	
	public void BtnCompleteQuestTaskOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvQuestTask);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraCompleteTask.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnCompleteQuestTaskCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraCompleteTask.Visible = false;
	}
	
#endregion
	
#region End Quest
	
	public void BtnEndQuestOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvEndQuest);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraEndQuest.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnEndQuestCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraEndQuest.Visible = false;
	}
	
#endregion
	
#region Set Fog
	
	public void BtnSetFogOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvSetFog);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraSetFog.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnSetFogCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraSetFog.Visible = false;
	}
	
#endregion
	
#region Set Weather
	
	public void BtnSetWeatherOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvSetWeather);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraSetWeather.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnSetWeatherCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraSetWeather.Visible = false;
	}
	
#endregion
	
#region Set Map Tint
	
	public void BtnMapTintOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvSetTint);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraMapTint.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnMapTintCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraMapTint.Visible = false;
	}
	
#endregion
	
#region Play BGM
	
	public void BtnPlayBgmOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvPlayBgm);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraPlayBGM.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnPlayBgmCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraPlayBGM.Visible = false;
	}
	
#endregion
	
#region Play Sound
	
	public void BtnPlaySoundOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvPlaySound);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraPlaySound.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnPlaySoundCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraPlaySound.Visible = false;
	}
	
#endregion
	
#region Wait
	
	public void BtnSetWaitOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvWait);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraSetWait.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnSetWaitCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraSetWait.Visible = false;
	}
	
#endregion
	
#region Set Access
	
	public void BtnSetAccessOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvSetAccess);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraSetAccess.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnSetAccessCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraSetAccess.Visible = false;
	}
	
#endregion
	
#region Custom Script
	
	public void BtnCustomScriptOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvCustomScript);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraCustomScript.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnCustomScriptCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraCustomScript.Visible = false;
	}
	
#endregion
	
#region Show Pic
	
	public void BtnShowPicOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvShowPicture);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraShowPic.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnShowPicCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraShowPic.Visible = false;
	}
	
#endregion
	
#region Hide Pic
	
	public void BtnHidePicOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvHidePicture);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraHidePic.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnHidePicCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraHidePic.Visible = false;
	}
	
#endregion
	
#region Open Shop
	
	public void BtnOpenShopOK_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			C_EventSystem.AddCommand((System.Int32) C_EventSystem.EventType.EvOpenShop);
		}
		else
		{
			C_EventSystem.EditCommand();
		}
		// hide
		fraDialogue.Visible = false;
		fraOpenShop.Visible = false;
		fraCommands.Visible = false;
	}
	
	public void BtnOpenShopCancel_Click(object sender, EventArgs e)
	{
		if (!C_EventSystem.IsEdit)
		{
			fraCommands.Visible = true;
		}
		else
		{
			fraCommands.Visible = false;
		}
		fraDialogue.Visible = false;
		fraOpenShop.Visible = false;
	}
	
	public void PicGraphicSel_Click(object sender, EventArgs e)
	{
		
	}
	
#endregion
	
#endregion
	
}
}
