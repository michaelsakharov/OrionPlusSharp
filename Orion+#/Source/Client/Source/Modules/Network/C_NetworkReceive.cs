
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using ASFW;
using ASFW.IO;
using System.Windows.Forms;
using Engine;


namespace Engine
{
	sealed class C_NetworkReceive
	{
		
		public static void PacketRouter()
		{
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SAlertMsg] = new ASFW.Network.Client.DataArgs(Packet_AlertMSG);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SKeyPair] = new ASFW.Network.Client.DataArgs(Packet_KeyPair);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SLoadCharOk] = new ASFW.Network.Client.DataArgs(Packet_LoadCharOk);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SLoginOk] = new ASFW.Network.Client.DataArgs(Packet_LoginOk);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SNewCharClasses] = new ASFW.Network.Client.DataArgs(Packet_NewCharClasses);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SClassesData] = new ASFW.Network.Client.DataArgs(Packet_ClassesData);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SInGame] = new ASFW.Network.Client.DataArgs(Packet_InGame);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerInv] = new ASFW.Network.Client.DataArgs(Packet_PlayerInv);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerInvUpdate] = new ASFW.Network.Client.DataArgs(Packet_PlayerInvUpdate);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerWornEq] = new ASFW.Network.Client.DataArgs(Packet_PlayerWornEquipment);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerHp] = new ASFW.Network.Client.DataArgs(Packet_PlayerHP);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerMp] = new ASFW.Network.Client.DataArgs(Packet_PlayerMP);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerSp] = new ASFW.Network.Client.DataArgs(Packet_PlayerSP);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerStats] = new ASFW.Network.Client.DataArgs(Packet_PlayerStats);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerData] = new ASFW.Network.Client.DataArgs(Packet_PlayerData);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerMove] = new ASFW.Network.Client.DataArgs(Packet_PlayerMove);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SNpcMove] = new ASFW.Network.Client.DataArgs(Packet_NpcMove);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerDir] = new ASFW.Network.Client.DataArgs(Packet_PlayerDir);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SNpcDir] = new ASFW.Network.Client.DataArgs(Packet_NpcDir);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerXY] = new ASFW.Network.Client.DataArgs(Packet_PlayerXY);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SAttack] = new ASFW.Network.Client.DataArgs(Packet_Attack);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SNpcAttack] = new ASFW.Network.Client.DataArgs(Packet_NpcAttack);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SCheckForMap] = new ASFW.Network.Client.DataArgs(C_Maps.Packet_CheckMap);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SMapData] = new ASFW.Network.Client.DataArgs(C_Maps.Packet_MapData);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SMapNpcData] = new ASFW.Network.Client.DataArgs(C_Maps.Packet_MapNPCData);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SMapNpcUpdate] = new ASFW.Network.Client.DataArgs(C_Maps.Packet_MapNPCUpdate);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SMapDone] = new ASFW.Network.Client.DataArgs(C_Maps.Packet_MapDone);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SGlobalMsg] = new ASFW.Network.Client.DataArgs(Packet_GlobalMessage);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerMsg] = new ASFW.Network.Client.DataArgs(Packet_PlayerMessage);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SMapMsg] = new ASFW.Network.Client.DataArgs(Packet_MapMessage);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SSpawnItem] = new ASFW.Network.Client.DataArgs(Packet_SpawnItem);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SUpdateItem] = new ASFW.Network.Client.DataArgs(C_Items.Packet_UpdateItem);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SSpawnNpc] = new ASFW.Network.Client.DataArgs(Packet_SpawnNPC);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SNpcDead] = new ASFW.Network.Client.DataArgs(Packet_NpcDead);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SUpdateNpc] = new ASFW.Network.Client.DataArgs(Packet_UpdateNPC);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SMapKey] = new ASFW.Network.Client.DataArgs(Packet_MapKey);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SEditMap] = new ASFW.Network.Client.DataArgs(C_Maps.Packet_EditMap);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SUpdateShop] = new ASFW.Network.Client.DataArgs(C_Shops.Packet_UpdateShop);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SUpdateSkill] = new ASFW.Network.Client.DataArgs(Packet_UpdateSkill);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SSkills] = new ASFW.Network.Client.DataArgs(Packet_Skills);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SLeftMap] = new ASFW.Network.Client.DataArgs(Packet_LeftMap);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SResourceCache] = new ASFW.Network.Client.DataArgs(C_Resources.Packet_ResourceCache);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SUpdateResource] = new ASFW.Network.Client.DataArgs(C_Resources.Packet_UpdateResource);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SSendPing] = new ASFW.Network.Client.DataArgs(Packet_Ping);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SDoorAnimation] = new ASFW.Network.Client.DataArgs(Packet_DoorAnimation);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SActionMsg] = new ASFW.Network.Client.DataArgs(Packet_ActionMessage);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerEXP] = new ASFW.Network.Client.DataArgs(Packet_PlayerExp);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SBlood] = new ASFW.Network.Client.DataArgs(Packet_Blood);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SUpdateAnimation] = new ASFW.Network.Client.DataArgs(Packet_UpdateAnimation);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SAnimation] = new ASFW.Network.Client.DataArgs(Packet_Animation);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SMapNpcVitals] = new ASFW.Network.Client.DataArgs(Packet_NPCVitals);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SCooldown] = new ASFW.Network.Client.DataArgs(Packet_Cooldown);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SClearSkillBuffer] = new ASFW.Network.Client.DataArgs(Packet_ClearSkillBuffer);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SSayMsg] = new ASFW.Network.Client.DataArgs(Packet_SayMessage);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SOpenShop] = new ASFW.Network.Client.DataArgs(C_Shops.Packet_OpenShop);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SResetShopAction] = new ASFW.Network.Client.DataArgs(C_Shops.Packet_ResetShopAction);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SStunned] = new ASFW.Network.Client.DataArgs(Packet_Stunned);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SMapWornEq] = new ASFW.Network.Client.DataArgs(Packet_MapWornEquipment);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SBank] = new ASFW.Network.Client.DataArgs(C_Banks.Packet_OpenBank);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SLeftGame] = new ASFW.Network.Client.DataArgs(Packet_LeftGame);
			
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SClearTradeTimer] = new ASFW.Network.Client.DataArgs(C_Trade.Packet_ClearTradeTimer);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.STradeInvite] = new ASFW.Network.Client.DataArgs(C_Trade.Packet_TradeInvite);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.STrade] = new ASFW.Network.Client.DataArgs(C_Trade.Packet_Trade);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SCloseTrade] = new ASFW.Network.Client.DataArgs(C_Trade.Packet_CloseTrade);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.STradeUpdate] = new ASFW.Network.Client.DataArgs(C_Trade.Packet_TradeUpdate);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.STradeStatus] = new ASFW.Network.Client.DataArgs(C_Trade.Packet_TradeStatus);
			
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SGameData] = new ASFW.Network.Client.DataArgs(Packet_GameData);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SMapReport] = new ASFW.Network.Client.DataArgs(Packet_Mapreport); //Mapreport
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.STarget] = new ASFW.Network.Client.DataArgs(Packet_Target);
			
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SAdmin] = new ASFW.Network.Client.DataArgs(Packet_Admin);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SMapNames] = new ASFW.Network.Client.DataArgs(Packet_MapNames);
			
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SCritical] = new ASFW.Network.Client.DataArgs(Packet_Critical);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SNews] = new ASFW.Network.Client.DataArgs(Packet_News);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SrClick] = new ASFW.Network.Client.DataArgs(Packet_RClick);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.STotalOnline] = new ASFW.Network.Client.DataArgs(Packet_TotalOnline);
			
			//quests
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SUpdateQuest] = new ASFW.Network.Client.DataArgs(C_Quest.Packet_UpdateQuest);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerQuest] = new ASFW.Network.Client.DataArgs(C_Quest.Packet_PlayerQuest);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayerQuests] = new ASFW.Network.Client.DataArgs(C_Quest.Packet_PlayerQuests);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SQuestMessage] = new ASFW.Network.Client.DataArgs(C_Quest.Packet_QuestMessage);
			
			//Housing
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SHouseConfigs] = new ASFW.Network.Client.DataArgs(C_Housing.Packet_HouseConfigurations);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SBuyHouse] = new ASFW.Network.Client.DataArgs(C_Housing.Packet_HouseOffer);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SVisit] = new ASFW.Network.Client.DataArgs(C_Housing.Packet_Visit);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SFurniture] = new ASFW.Network.Client.DataArgs(C_Housing.Packet_Furniture);
			
			//hotbar
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SHotbar] = new ASFW.Network.Client.DataArgs(Packet_Hotbar);
			
			//Events
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SSpawnEvent] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_SpawnEvent);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SEventMove] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_EventMove);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SEventDir] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_EventDir);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SEventChat] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_EventChat);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SEventStart] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_EventStart);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SEventEnd] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_EventEnd);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlayBGM] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_PlayBGM);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPlaySound] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_PlaySound);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SFadeoutBGM] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_FadeOutBGM);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SStopSound] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_StopSound);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SSwitchesAndVariables] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_SwitchesAndVariables);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SMapEventData] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_MapEventData);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SChatBubble] = new ASFW.Network.Client.DataArgs(Packet_ChatBubble);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SSpecialEffect] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_SpecialEffect);
			//SPic
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SHoldPlayer] = new ASFW.Network.Client.DataArgs(C_EventSystem.Packet_HoldPlayer);
			
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SUpdateProjectile] = new ASFW.Network.Client.DataArgs(C_Projectiles.HandleUpdateProjectile);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SMapProjectile] = new ASFW.Network.Client.DataArgs(C_Projectiles.HandleMapProjectile);
			
			//craft
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SUpdateRecipe] = new ASFW.Network.Client.DataArgs(C_Crafting.Packet_UpdateRecipe);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SSendPlayerRecipe] = new ASFW.Network.Client.DataArgs(C_Crafting.Packet_SendPlayerRecipe);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SOpenCraft] = new ASFW.Network.Client.DataArgs(C_Crafting.Packet_OpenCraft);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SUpdateCraft] = new ASFW.Network.Client.DataArgs(C_Crafting.Packet_UpdateCraft);
			
			//emotes
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SEmote] = new ASFW.Network.Client.DataArgs(Packet_Emote);
			
			//party
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPartyInvite] = new ASFW.Network.Client.DataArgs(C_Parties.Packet_PartyInvite);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPartyUpdate] = new ASFW.Network.Client.DataArgs(C_Parties.Packet_PartyUpdate);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPartyVitals] = new ASFW.Network.Client.DataArgs(C_Parties.Packet_PartyVitals);
			
			//pets
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SUpdatePet] = new ASFW.Network.Client.DataArgs(C_Pets.Packet_UpdatePet);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SUpdatePlayerPet] = new ASFW.Network.Client.DataArgs(C_Pets.Packet_UpdatePlayerPet);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPetMove] = new ASFW.Network.Client.DataArgs(C_Pets.Packet_PetMove);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPetDir] = new ASFW.Network.Client.DataArgs(C_Pets.Packet_PetDir);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPetVital] = new ASFW.Network.Client.DataArgs(C_Pets.Packet_PetVital);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SClearPetSkillBuffer] = new ASFW.Network.Client.DataArgs(C_Pets.Packet_ClearPetSkillBuffer);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPetAttack] = new ASFW.Network.Client.DataArgs(C_Pets.Packet_PetAttack);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPetXY] = new ASFW.Network.Client.DataArgs(C_Pets.Packet_PetXY);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SPetExp] = new ASFW.Network.Client.DataArgs(C_Pets.Packet_PetExperience);
			
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.SClock] = new ASFW.Network.Client.DataArgs(C_Time.Packet_Clock);
			C_NetworkConfig.Socket.PacketId[(byte)Packets.ServerPackets.STime] = new ASFW.Network.Client.DataArgs(C_Time.Packet_Time);
        }
		
		private static void Packet_AlertMSG(ref byte[] data)
		{
			string msg = "";
			ByteStream buffer = new ByteStream(data);
			C_UpdateUI.Pnlloadvisible = false;
			
			if (FrmMenu.Default.Visible == false)
			{
				C_UpdateUI.Frmmenuvisible = true;
				C_UpdateUI.Frmmaingamevisible = false;
			}
			
			C_UpdateUI.PnlCharCreateVisible = false;
			C_UpdateUI.PnlLoginVisible = false;
			C_UpdateUI.PnlRegisterVisible = false;
			C_UpdateUI.PnlCharSelectVisible = false;
			
			msg = buffer.ReadString();
			
			buffer.Dispose();

            MessageBox.Show(msg, C_Constants.GameName);
			C_General.DestroyGame();
		}
		
		private static void Packet_KeyPair(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_Variables.EKeyPair.ImportKeyString(buffer.ReadString());
			buffer.Dispose();
		}
		
		private static void Packet_LoadCharOk(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			// Now we can receive game data
			C_Variables.Myindex = buffer.ReadInt32();
			
			buffer.Dispose();
			
			C_UpdateUI.Pnlloadvisible = true;
			C_General.SetStatus(Strings.Get("gamegui", "datarecieve"));
		}
		
		private static void Packet_LoginOk(ref byte[] data)
		{
			string charName = "";
			int sprite = 0;
			int level = 0;
			string className = "";
			byte gender = 0;
			
			// save options
			C_Types.Options.SavePass = C_UpdateUI.ChkSavePassChecked;
			C_Types.Options.Username = C_UpdateUI.TempUserName.Trim();
			
			if (C_UpdateUI.ChkSavePassChecked == false)
			{
				C_Types.Options.Password = "";
			}
			else
			{
				C_Types.Options.Password = C_UpdateUI.TempPassword.Trim();
			}
			
			C_DataBase.SaveOptions();
			
			// Request classes.
			C_NetworkSend.SendRequestClasses();
			
			ByteStream buffer = new ByteStream(data);
			// Now we can receive char data
			C_Variables.MaxChars = (byte) (buffer.ReadInt32());
			C_Types.CharSelection = new C_Types.CharSelRec[C_Variables.MaxChars + 1];
			
			C_Variables.SelectedChar = (byte) 1;
			
			//reset for deleting chars
			for (var i = 1; i <= C_Variables.MaxChars; i++)
			{
				C_Types.CharSelection[(int) i].Name = "";
				C_Types.CharSelection[(int) i].Sprite = 0;
				C_Types.CharSelection[(int) i].Level = 0;
				C_Types.CharSelection[(int) i].ClassName = "";
				C_Types.CharSelection[(int) i].Gender = 0;
			}
			
			for (var i = 1; i <= C_Variables.MaxChars; i++)
			{
				charName = buffer.ReadString();
				sprite = buffer.ReadInt32();
				level = buffer.ReadInt32();
				className = buffer.ReadString();
				gender = (byte) (buffer.ReadInt32());
				
				C_Types.CharSelection[(int) i].Name = charName;
				C_Types.CharSelection[(int) i].Sprite = sprite;
				C_Types.CharSelection[(int) i].Level = level;
				C_Types.CharSelection[(int) i].ClassName = className;
				C_Types.CharSelection[(int) i].Gender = gender;
			}
			
			buffer.Dispose();
			
			// Used for if the player is creating a new character
			C_UpdateUI.Frmmenuvisible = true;
			C_UpdateUI.Pnlloadvisible = false;
			C_UpdateUI.PnlCreditsVisible = false;
			C_UpdateUI.PnlRegisterVisible = false;
			C_UpdateUI.PnlCharCreateVisible = false;
			C_UpdateUI.PnlLoginVisible = false;
			
			C_UpdateUI.PnlCharSelectVisible = true;
			
			FrmMenu.Default.DrawCharacter();
			
			C_UpdateUI.DrawCharSelect = true;
			
		}
		
		private static void Packet_NewCharClasses(ref byte[] data)
		{
			int i = 0;
			int z = 0;
			int x = 0;
			ByteStream buffer = new ByteStream(data);
			// Max classes
			C_Variables.MaxClasses = (byte) (buffer.ReadInt32());
			Types.Classes = new C_Types.ClassRec[C_Variables.MaxClasses + 1];
			
			C_Variables.SelectedChar = (byte) 1;
			
			for (i = 1; i <= C_Variables.MaxClasses; i++)
			{
				
				ref var with_1 = ref Types.Classes[i];
				with_1.Name = buffer.ReadString().Trim();
				with_1.Desc = buffer.ReadString().Trim();
				
				with_1.Vital = new int[(int) Enums.VitalType.Count];
				
				with_1.Vital[(byte)Enums.VitalType.HP] = buffer.ReadInt32();
				with_1.Vital[(byte)Enums.VitalType.MP] = buffer.ReadInt32();
				with_1.Vital[(byte)Enums.VitalType.SP] = buffer.ReadInt32();
				
				// get array size
				z = buffer.ReadInt32();
				// redim array
				with_1.MaleSprite = new int[z + 1 + 1];
				// loop-receive data
				for (x = 1; x <= z + 1; x++)
				{
					with_1.MaleSprite[x] = buffer.ReadInt32();
				}
				
				// get array size
				z = buffer.ReadInt32();
				// redim array
				with_1.FemaleSprite = new int[z + 1 + 1];
				// loop-receive data
				for (x = 1; x <= z + 1; x++)
				{
					with_1.FemaleSprite[x] = buffer.ReadInt32();
				}
				
				with_1.Stat = new byte[(int) Enums.StatType.Count];
				
				with_1.Stat[(byte)Enums.StatType.Strength] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Endurance] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Vitality] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Intelligence] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Luck] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Spirit] = (byte)buffer.ReadInt32();
				
				with_1.StartItem = new int[6];
				with_1.StartValue = new int[6];
				for (var q = 1; q <= 5; q++)
				{
					with_1.StartItem[q] = buffer.ReadInt32();
					with_1.StartValue[q] = buffer.ReadInt32();
				}
				
				with_1.StartMap = buffer.ReadInt32();
				with_1.StartX = (byte)buffer.ReadInt32();
				with_1.StartY = (byte)buffer.ReadInt32();
				
				with_1.BaseExp = buffer.ReadInt32();
				
			}
			
			buffer.Dispose();
			
			// Used for if the player is creating a new character
			C_UpdateUI.Frmmenuvisible = true;
			C_UpdateUI.Pnlloadvisible = false;
			C_UpdateUI.PnlCreditsVisible = false;
			C_UpdateUI.PnlRegisterVisible = false;
			C_UpdateUI.PnlCharCreateVisible = true;
			C_UpdateUI.PnlLoginVisible = false;
			
			C_UpdateUI.Cmbclass = new string[C_Variables.MaxClasses + 1];
			
			for (i = 1; i <= C_Variables.MaxClasses; i++)
			{
				C_UpdateUI.Cmbclass[i] = Types.Classes[i].Name;
			}
			
			FrmMenu.Default.DrawCharacter();
			
			C_Variables.NewCharSprite = 1;
		}
		
		private static void Packet_ClassesData(ref byte[] data)
		{
			int i = 0;
			int z = 0;
			int x = 0;
			ByteStream buffer = new ByteStream(data);
			// Max classes
			C_Variables.MaxClasses = (byte) (buffer.ReadInt32());
			Types.Classes = new C_Types.ClassRec[C_Variables.MaxClasses + 1];
			
			C_Variables.SelectedChar = (byte) 1;
			
			for (i = 1; i <= C_Variables.MaxClasses; i++)
			{
				
				ref var with_1 = ref Types.Classes[i];
				with_1.Name = buffer.ReadString().Trim();
				with_1.Desc = buffer.ReadString().Trim();
				
				with_1.Vital = new int[(int) Enums.VitalType.Count];
				
				with_1.Vital[(byte)Enums.VitalType.HP] = buffer.ReadInt32();
				with_1.Vital[(byte)Enums.VitalType.MP] = buffer.ReadInt32();
				with_1.Vital[(byte)Enums.VitalType.SP] = buffer.ReadInt32();
				
				// get array size
				z = buffer.ReadInt32();
				// redim array
				with_1.MaleSprite = new int[z + 1 + 1];
				// loop-receive data
				for (x = 1; x <= z + 1; x++)
				{
					with_1.MaleSprite[x] = buffer.ReadInt32();
				}
				
				// get array size
				z = buffer.ReadInt32();
				// redim array
				with_1.FemaleSprite = new int[z + 1 + 1];
				// loop-receive data
				for (x = 1; x <= z + 1; x++)
				{
					with_1.FemaleSprite[x] = buffer.ReadInt32();
				}
				
				with_1.Stat = new byte[(int) Enums.StatType.Count];
				
				with_1.Stat[(byte)Enums.StatType.Strength] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Endurance] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Vitality] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Intelligence] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Luck] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Spirit] = (byte)buffer.ReadInt32();
				
				with_1.StartItem = new int[6];
				with_1.StartValue = new int[6];
				for (var q = 1; q <= 5; q++)
				{
					with_1.StartItem[q] = buffer.ReadInt32();
					with_1.StartValue[q] = buffer.ReadInt32();
				}
				
				with_1.StartMap = buffer.ReadInt32();
				with_1.StartX = (byte)buffer.ReadInt32();
				with_1.StartY = (byte)buffer.ReadInt32();
				
				with_1.BaseExp = buffer.ReadInt32();
				
			}
			
			C_UpdateUI.Cmbclass = new string[C_Variables.MaxClasses + 1];
			for (i = 1; i <= C_Variables.MaxClasses; i++)
			{
				C_UpdateUI.Cmbclass[i] = Types.Classes[i].Name;
			}
			FrmMenu.Default.DrawCharacter();
			C_Variables.NewCharSprite = 1;
			
			buffer.Dispose();
		}
		
		private static void Packet_InGame(ref byte[] data)
		{
			C_Variables.InGame = true;
			C_Variables.CanMoveNow = true;
			C_General.GameInit();
		}
		
		private static void Packet_PlayerInv(ref byte[] data)
		{
			int i = 0;
			int invNum = 0;
			int amount = 0;
			ByteStream buffer = new ByteStream(data);
			for (i = 1; i <= Constants.MAX_INV; i++)
			{
				invNum = buffer.ReadInt32();
				amount = buffer.ReadInt32();
				C_Player.SetPlayerInvItemNum(C_Variables.Myindex, i, invNum);
				C_Player.SetPlayerInvItemValue(C_Variables.Myindex, i, amount);
				
				C_Types.Player[C_Variables.Myindex].RandInv[i].Prefix = buffer.ReadString();
				C_Types.Player[C_Variables.Myindex].RandInv[i].Suffix = buffer.ReadString();
				C_Types.Player[C_Variables.Myindex].RandInv[i].Rarity = buffer.ReadInt32();
				for (var n = 1; n <= (int) Enums.StatType.Count - 1; n++)
				{
					C_Types.Player[C_Variables.Myindex].RandInv[i].Stat[(int) n] = buffer.ReadInt32();
				}
				C_Types.Player[C_Variables.Myindex].RandInv[i].Damage = buffer.ReadInt32();
				C_Types.Player[C_Variables.Myindex].RandInv[i].Speed = buffer.ReadInt32();
			}
			
			// changes to inventory, need to clear any drop menu
			FrmGame.Default.pnlCurrency.Visible = false;
			FrmGame.Default.txtCurrency.Text = "";
			C_Variables.TmpCurrencyItem = 0;
			C_Variables.CurrencyMenu = (byte) 0; // clear
			
			buffer.Dispose();
		}
		
		private static void Packet_PlayerInvUpdate(ref byte[] data)
		{
			int n = 0;
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			n = buffer.ReadInt32();
			C_Player.SetPlayerInvItemNum(C_Variables.Myindex, n, buffer.ReadInt32());
			C_Player.SetPlayerInvItemValue(C_Variables.Myindex, n, buffer.ReadInt32());
			
			C_Types.Player[C_Variables.Myindex].RandInv[n].Prefix = buffer.ReadString();
			C_Types.Player[C_Variables.Myindex].RandInv[n].Suffix = buffer.ReadString();
			C_Types.Player[C_Variables.Myindex].RandInv[n].Rarity = buffer.ReadInt32();
			for (i = 1; i <= (int) Enums.StatType.Count - 1; i++)
			{
				C_Types.Player[C_Variables.Myindex].RandInv[n].Stat[i] = buffer.ReadInt32();
			}
			C_Types.Player[C_Variables.Myindex].RandInv[n].Damage = buffer.ReadInt32();
			C_Types.Player[C_Variables.Myindex].RandInv[n].Speed = buffer.ReadInt32();
			
			// changes, clear drop menu
			FrmGame.Default.pnlCurrency.Visible = false;
			FrmGame.Default.txtCurrency.Text = "";
			C_Variables.TmpCurrencyItem = 0;
			C_Variables.CurrencyMenu = (byte) 0; // clear
			
			buffer.Dispose();
		}
		
		private static void Packet_PlayerWornEquipment(ref byte[] data)
		{
			int i = 0;
			int n = 0;
			ByteStream buffer = new ByteStream(data);
			for (i = 1; i <= (int) Enums.EquipmentType.Count - 1; i++)
			{
				C_Player.SetPlayerEquipment(C_Variables.Myindex, buffer.ReadInt32(), (Enums.EquipmentType)i);
			}
			
			for (i = 1; i <= (int) Enums.EquipmentType.Count - 1; i++)
			{
				C_Types.Player[C_Variables.Myindex].RandEquip[i].Prefix = buffer.ReadString();
				C_Types.Player[C_Variables.Myindex].RandEquip[i].Suffix = buffer.ReadString();
				C_Types.Player[C_Variables.Myindex].RandEquip[i].Damage = buffer.ReadInt32();
				C_Types.Player[C_Variables.Myindex].RandEquip[i].Speed = buffer.ReadInt32();
				C_Types.Player[C_Variables.Myindex].RandEquip[i].Rarity = buffer.ReadInt32();
				
				for (n = 1; n <= (int) Enums.StatType.Count - 1; n++)
				{
					C_Types.Player[C_Variables.Myindex].RandEquip[i].Stat[n] = buffer.ReadInt32();
				}
			}
			
			// changes to inventory, need to clear any drop menu
			
			FrmGame.Default.pnlCurrency.Visible = false;
			FrmGame.Default.txtCurrency.Text = "";
			C_Variables.TmpCurrencyItem = 0;
			C_Variables.CurrencyMenu = (byte) 0; // clear
			
			buffer.Dispose();
		}
		
		private static void Packet_PlayerHP(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_Types.Player[C_Variables.Myindex].MaxHp = buffer.ReadInt32();
			
			C_Player.SetPlayerVital(C_Variables.Myindex, Enums.VitalType.HP, buffer.ReadInt32());
			
			if (C_Player.GetPlayerMaxVital(C_Variables.Myindex, Enums.VitalType.HP) > 0)
			{
				C_UpdateUI.LblHpText = C_Player.GetPlayerVital(C_Variables.Myindex, Enums.VitalType.HP) + "/" + System.Convert.ToString(C_Player.GetPlayerMaxVital(C_Variables.Myindex, Enums.VitalType.HP));
				// hp bar
				C_UpdateUI.PicHpWidth = System.Convert.ToInt32(Conversion.Int((((double) C_Player.GetPlayerVital(C_Variables.Myindex, Enums.VitalType.HP) / 169) / ((double) C_Player.GetPlayerMaxVital(C_Variables.Myindex, Enums.VitalType.HP) / 169)) * 169));
			}
			
			buffer.Dispose();
		}
		
		private static void Packet_PlayerMP(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_Types.Player[C_Variables.Myindex].MaxMp = buffer.ReadInt32();
			C_Player.SetPlayerVital(C_Variables.Myindex, Enums.VitalType.MP, buffer.ReadInt32());
			
			if (C_Player.GetPlayerMaxVital(C_Variables.Myindex, Enums.VitalType.MP) > 0)
			{
				C_UpdateUI.LblManaText = C_Player.GetPlayerVital(C_Variables.Myindex, Enums.VitalType.MP) + "/" + System.Convert.ToString(C_Player.GetPlayerMaxVital(C_Variables.Myindex, Enums.VitalType.MP));
				// mp bar
				C_UpdateUI.PicManaWidth = System.Convert.ToInt32(Conversion.Int((((double) C_Player.GetPlayerVital(C_Variables.Myindex, Enums.VitalType.MP) / 169) / ((double) C_Player.GetPlayerMaxVital(C_Variables.Myindex, Enums.VitalType.MP) / 169)) * 169));
			}
			
			buffer.Dispose();
		}
		
		private static void Packet_PlayerSP(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_Types.Player[C_Variables.Myindex].MaxSp = buffer.ReadInt32();
			C_Player.SetPlayerVital(C_Variables.Myindex, Enums.VitalType.SP, buffer.ReadInt32());
			
			buffer.Dispose();
		}
		
		private static void Packet_PlayerStats(ref byte[] data)
		{
			int i = 0;
			int index = 0;
			ByteStream buffer = new ByteStream(data);
			index = buffer.ReadInt32();
			for (i = 1; i <= (int) Enums.StatType.Count - 1; i++)
			{
				C_Player.SetPlayerStat(index, (Enums.StatType)i, buffer.ReadInt32());
			}
			C_UpdateUI.UpdateCharacterPanel = true;
			
			buffer.Dispose();
		}
		
		private static void Packet_PlayerData(ref byte[] data)
		{
			int i = 0;
			int x = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			C_Player.SetPlayerName(i, buffer.ReadString());
			C_Player.SetPlayerClass(i, buffer.ReadInt32());
			C_Player.SetPlayerLevel(i, buffer.ReadInt32());
			C_Player.SetPlayerPoints(i, buffer.ReadInt32());
			C_Player.SetPlayerSprite(i, buffer.ReadInt32());
			C_Player.SetPlayerMap(i, buffer.ReadInt32());
			C_Player.SetPlayerX(i, buffer.ReadInt32());
			C_Player.SetPlayerY(i, buffer.ReadInt32());
			C_Player.SetPlayerDir(i, buffer.ReadInt32());
			C_Player.SetPlayerAccess(i, buffer.ReadInt32());
			C_Player.SetPlayerPk(i, buffer.ReadInt32());
			
			for (x = 1; x <= (int) Enums.StatType.Count - 1; x++)
			{
				C_Player.SetPlayerStat(i, (Enums.StatType)x, buffer.ReadInt32());
			}
			
			C_Types.Player[i].InHouse = buffer.ReadInt32();
			
			for (x = 0; x <= (int) Enums.ResourceSkills.Count - 1; x++)
			{
				C_Types.Player[i].GatherSkills[x].SkillLevel = buffer.ReadInt32();
				C_Types.Player[i].GatherSkills[x].SkillCurExp = buffer.ReadInt32();
				C_Types.Player[i].GatherSkills[x].SkillNextLvlExp = buffer.ReadInt32();
			}
			
			for (x = 1; x <= Constants.MAX_RECIPE; x++)
			{
				C_Types.Player[i].RecipeLearned[x] = (byte)buffer.ReadInt32();
			}
			
			// Check if the player is the client player
			if (i == C_Variables.Myindex)
			{
				// Reset directions
				C_Variables.DirUp = false;
				C_Variables.DirDown = false;
				C_Variables.DirLeft = false;
				C_Variables.DirRight = false;
				
				C_UpdateUI.UpdateCharacterPanel = true;
			}
			
			// Make sure they aren't walking
			C_Types.Player[i].Moving = (byte) 0;
			C_Types.Player[i].XOffset = 0;
			C_Types.Player[i].YOffset = 0;
			
			if (i == C_Variables.Myindex)
			{
				C_Variables.PlayerData = true;
			}
			
			buffer.Dispose();
		}
		
		private static void Packet_PlayerMove(ref byte[] data)
		{
			int i = 0;
			int x = 0;
			int y = 0;
			int dir = 0;
			byte n = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			x = buffer.ReadInt32();
			y = buffer.ReadInt32();
			dir = buffer.ReadInt32();
			n = (byte) (buffer.ReadInt32());
			
			C_Player.SetPlayerX(i, x);
			C_Player.SetPlayerY(i, y);
			C_Player.SetPlayerDir(i, dir);
			C_Types.Player[i].XOffset = 0;
			C_Types.Player[i].YOffset = 0;
			C_Types.Player[i].Moving = n;
			
			switch (C_Player.GetPlayerDir(i))
			{
				case (int) Enums.DirectionType.Up:
					C_Types.Player[i].YOffset = C_Constants.PicY;
					break;
				case (int) Enums.DirectionType.Down:
					C_Types.Player[i].YOffset = C_Constants.PicY * -1;
					break;
				case (int) Enums.DirectionType.Left:
					C_Types.Player[i].XOffset = C_Constants.PicX;
					break;
				case (int) Enums.DirectionType.Right:
					C_Types.Player[i].XOffset = C_Constants.PicX * -1;
					break;
			}
			
			buffer.Dispose();
		}
		
		private static void Packet_NpcMove(ref byte[] data)
		{
			int mapNpcNum = 0;
			int movement = 0;
			int x = 0;
			int y = 0;
			int dir = 0;
			ByteStream buffer = new ByteStream(data);
			mapNpcNum = buffer.ReadInt32();
			x = buffer.ReadInt32();
			y = buffer.ReadInt32();
			dir = buffer.ReadInt32();
			movement = buffer.ReadInt32();
			
			ref var with_1 = ref C_Maps.MapNpc[mapNpcNum];
			with_1.X = (byte)x;
			with_1.Y = (byte)y;
			with_1.Dir = (byte)dir;
			with_1.XOffset = 0;
			with_1.YOffset = 0;
			with_1.Moving = (byte)movement;
			
			if (with_1.Dir == (byte)Enums.DirectionType.Up)
			{
				with_1.YOffset = C_Constants.PicY;
			}
			else if (with_1.Dir == (byte)Enums.DirectionType.Down)
			{
				with_1.YOffset = C_Constants.PicY * -1;
			}
			else if (with_1.Dir == (byte)Enums.DirectionType.Left)
			{
				with_1.XOffset = C_Constants.PicX;
			}
			else if (with_1.Dir == (byte)Enums.DirectionType.Right)
			{
				with_1.XOffset = C_Constants.PicX * -1;
			}
			
			buffer.Dispose();
		}
		
		private static void Packet_PlayerDir(ref byte[] data)
		{
			int dir = 0;
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			dir = buffer.ReadInt32();
			
			C_Player.SetPlayerDir(i, dir);
			
			ref var with_1 = ref C_Types.Player[i];
			with_1.XOffset = 0;
			with_1.YOffset = 0;
			with_1.Moving = (byte) 0;
			
			buffer.Dispose();
		}
		
		private static void Packet_NpcDir(ref byte[] data)
		{
			int dir = 0;
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			dir = buffer.ReadInt32();
			
			ref var with_1 = ref C_Maps.MapNpc[i];
			with_1.Dir = (byte)dir;
			with_1.XOffset = 0;
			with_1.YOffset = 0;
			with_1.Moving = 0;
			
			buffer.Dispose();
		}
		
		private static void Packet_PlayerXY(ref byte[] data)
		{
			int x = 0;
			int y = 0;
			int dir = 0;
			ByteStream buffer = new ByteStream(data);
			x = buffer.ReadInt32();
			y = buffer.ReadInt32();
			dir = buffer.ReadInt32();
			
			C_Player.SetPlayerX(C_Variables.Myindex, x);
			C_Player.SetPlayerY(C_Variables.Myindex, y);
			C_Player.SetPlayerDir(C_Variables.Myindex, dir);
			
			// Make sure they aren't walking
			C_Types.Player[C_Variables.Myindex].Moving = (byte) 0;
			C_Types.Player[C_Variables.Myindex].XOffset = 0;
			C_Types.Player[C_Variables.Myindex].YOffset = 0;
			
			buffer.Dispose();
		}
		
		private static void Packet_Attack(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			
			// Set player to attacking
			C_Types.Player[i].Attacking = (byte) 1;
			C_Types.Player[i].AttackTimer = C_General.GetTickCount();
			
			buffer.Dispose();
		}
		
		private static void Packet_NpcAttack(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			
			// Set npc to attacking
			C_Maps.MapNpc[i].Attacking = (byte) 1;
			C_Maps.MapNpc[i].AttackTimer = C_General.GetTickCount();
			
			buffer.Dispose();
		}
		
		private static void Packet_GlobalMessage(ref byte[] data)
		{
			string msg = "";
			ByteStream buffer = new ByteStream(data);
			
			msg = buffer.ReadString().Trim();
			
			buffer.Dispose();
			
			C_Text.AddText(msg, (System.Int32) Enums.QColorType.GlobalColor);
		}
		
		private static void Packet_MapMessage(ref byte[] data)
		{
			string msg = "";
			ByteStream buffer = new ByteStream(data);
			
			msg = buffer.ReadString().Trim();
			
			buffer.Dispose();
			
			C_Text.AddText(msg, (System.Int32) Enums.QColorType.BroadcastColor);
			
		}
		
		private static void Packet_SpawnItem(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			
			i = buffer.ReadInt32();
			
			ref var with_1 = ref C_Maps.MapItem[i];
			with_1.Num = buffer.ReadInt32();
			with_1.Value = buffer.ReadInt32();
			with_1.X = (byte)buffer.ReadInt32();
			with_1.Y = (byte)buffer.ReadInt32();
			
			buffer.Dispose();
		}
		
		private static void Packet_PlayerMessage(ref byte[] data)
		{
			string msg = "";
			int colour = 0;
			ByteStream buffer = new ByteStream(data);
			
			msg = buffer.ReadString().Trim();
			
			colour = buffer.ReadInt32();
			
			buffer.Dispose();
			
			C_Text.AddText(msg, colour);
		}
		
		private static void Packet_SpawnNPC(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			
			ref var with_1 = ref C_Maps.MapNpc[i];
			with_1.Num = buffer.ReadInt32();
			with_1.X = (byte)buffer.ReadInt32();
			with_1.Y = (byte)buffer.ReadInt32();
			with_1.Dir = (byte)buffer.ReadInt32();
			
			for (i = 1; i <= (int) Enums.VitalType.Count - 1; i++)
			{
				with_1.Vital[i] = buffer.ReadInt32();
			}
			// Client use only
			with_1.XOffset = 0;
			with_1.YOffset = 0;
			with_1.Moving = 0;
			
			buffer.Dispose();
		}
		
		private static void Packet_NpcDead(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			C_Maps.ClearMapNpc(i);
			
			buffer.Dispose();
		}
		
		private static void Packet_UpdateNPC(ref byte[] data)
		{
			int i = 0;
			int x = 0;
			ByteStream buffer = new ByteStream(data);
			i = buffer.ReadInt32();
			
			// Update the Npc
			Types.Npc[i].Animation = buffer.ReadInt32();
			Types.Npc[i].AttackSay = buffer.ReadString().Trim();
			Types.Npc[i].Behaviour = (byte) (buffer.ReadInt32());
			Types.Npc[i].DropChance = new int[6];
			Types.Npc[i].DropItem = new int[6];
			Types.Npc[i].DropItemValue = new int[6];
			for (x = 1; x <= 5; x++)
			{
				Types.Npc[i].DropChance[x] = buffer.ReadInt32();
				Types.Npc[i].DropItem[x] = buffer.ReadInt32();
				Types.Npc[i].DropItemValue[x] = buffer.ReadInt32();
			}
			
			Types.Npc[i].Exp = buffer.ReadInt32();
			Types.Npc[i].Faction = (byte) (buffer.ReadInt32());
			Types.Npc[i].Hp = buffer.ReadInt32();
			Types.Npc[i].Name = buffer.ReadString().Trim();
			Types.Npc[i].Range = (byte) (buffer.ReadInt32());
			Types.Npc[i].SpawnTime = (byte) (buffer.ReadInt32());
			Types.Npc[i].SpawnSecs = buffer.ReadInt32();
			Types.Npc[i].Sprite = buffer.ReadInt32();
			
			for (i = 0; i <= (int) Enums.StatType.Count - 1; i++)
			{
				Types.Npc[i].Stat[i] = (byte)buffer.ReadInt32();
			}
			
			Types.Npc[i].QuestNum = buffer.ReadInt32();
			
			for (x = 1; x <= Constants.MAX_NPC_SKILLS; x++)
			{
				Types.Npc[i].Skill[x] = (byte)buffer.ReadInt32();
			}
			
			Types.Npc[i].Level = buffer.ReadInt32();
			Types.Npc[i].Damage = buffer.ReadInt32();
			
			if (ReferenceEquals(Types.Npc[i].AttackSay, null))
			{
				Types.Npc[i].AttackSay = "";
			}
			if (ReferenceEquals(Types.Npc[i].Name, null))
			{
				Types.Npc[i].Name = "";
			}
			
			buffer.Dispose();
		}
		
		private static void Packet_MapKey(ref byte[] data)
		{
			int n = 0;
			int x = 0;
			int y = 0;
			ByteStream buffer = new ByteStream(data);
			x = buffer.ReadInt32();
			y = buffer.ReadInt32();
			n = buffer.ReadInt32();
			C_Maps.TempTile[x, y].DoorOpen = (byte) n;
			
			buffer.Dispose();
		}
		
		private static void Packet_UpdateSkill(ref byte[] data)
		{
			int skillnum = 0;
			ByteStream buffer = new ByteStream(data);
			skillnum = buffer.ReadInt32();
			
			Types.Skill[skillnum].AccessReq = buffer.ReadInt32();
			Types.Skill[skillnum].AoE = buffer.ReadInt32();
			Types.Skill[skillnum].CastAnim = buffer.ReadInt32();
			Types.Skill[skillnum].CastTime = buffer.ReadInt32();
			Types.Skill[skillnum].CdTime = buffer.ReadInt32();
			Types.Skill[skillnum].ClassReq = buffer.ReadInt32();
			Types.Skill[skillnum].Dir = (byte) (buffer.ReadInt32());
			Types.Skill[skillnum].Duration = buffer.ReadInt32();
			Types.Skill[skillnum].Icon = buffer.ReadInt32();
			Types.Skill[skillnum].Interval = buffer.ReadInt32();
			Types.Skill[skillnum].IsAoE = System.Convert.ToBoolean(buffer.ReadInt32());
			Types.Skill[skillnum].LevelReq = buffer.ReadInt32();
			Types.Skill[skillnum].Map = buffer.ReadInt32();
			Types.Skill[skillnum].MpCost = buffer.ReadInt32();
			Types.Skill[skillnum].Name = buffer.ReadString().Trim();
			Types.Skill[skillnum].Range = buffer.ReadInt32();
			Types.Skill[skillnum].SkillAnim = buffer.ReadInt32();
			Types.Skill[skillnum].StunDuration = buffer.ReadInt32();
			Types.Skill[skillnum].Type = (byte) (buffer.ReadInt32());
			Types.Skill[skillnum].Vital = buffer.ReadInt32();
			Types.Skill[skillnum].X = buffer.ReadInt32();
			Types.Skill[skillnum].Y = buffer.ReadInt32();
			
			Types.Skill[skillnum].IsProjectile = buffer.ReadInt32();
			Types.Skill[skillnum].Projectile = buffer.ReadInt32();
			
			Types.Skill[skillnum].KnockBack = (byte) (buffer.ReadInt32());
			Types.Skill[skillnum].KnockBackTiles = (byte) (buffer.ReadInt32());
			
			if (ReferenceEquals(Types.Skill[skillnum].Name, null))
			{
				Types.Skill[skillnum].Name = "";
			}
			
			buffer.Dispose();
			
		}
		
		private static void Packet_Skills(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			for (i = 1; i <= Constants.MAX_PLAYER_SKILLS; i++)
			{
				C_Variables.PlayerSkills[i] = (byte) (buffer.ReadInt32());
			}
			
			buffer.Dispose();
		}
		
		private static void Packet_LeftMap(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_Player.ClearPlayer(buffer.ReadInt32());
			
			buffer.Dispose();
		}
		
		private static void Packet_Ping(ref byte[] data)
		{
			C_Variables.PingEnd = C_General.GetTickCount();
			C_Variables.Ping = C_Variables.PingEnd - C_Variables.PingStart;
		}
		
		private static void Packet_DoorAnimation(ref byte[] data)
		{
			int x = 0;
			int y = 0;
			ByteStream buffer = new ByteStream(data);
			x = buffer.ReadInt32();
			y = buffer.ReadInt32();
			ref var with_1 = ref C_Maps.TempTile[x, y];
			with_1.DoorFrame = 1;
			with_1.DoorAnimate = 1; // 0 = nothing| 1 = opening | 2 = closing
			with_1.DoorTimer = C_General.GetTickCount();
			
			buffer.Dispose();
		}
		
		private static void Packet_ActionMessage(ref byte[] data)
		{
			int x = 0;
			int y = 0;
			string message = "";
			int color = 0;
			int tmpType = 0;
			ByteStream buffer = new ByteStream(data);
			message = buffer.ReadString().Trim();
			color = buffer.ReadInt32();
			tmpType = buffer.ReadInt32();
			x = buffer.ReadInt32();
			y = buffer.ReadInt32();
			
			buffer.Dispose();
			
			C_GameLogic.CreateActionMsg(message, color, (byte) tmpType, x, y);
		}
		
		private static void Packet_PlayerExp(ref byte[] data)
		{
			int index = 0;
			int tnl = 0;
			ByteStream buffer = new ByteStream(data);
			index = buffer.ReadInt32();
			C_Player.SetPlayerExp(index, buffer.ReadInt32());
			tnl = buffer.ReadInt32();
			
			if (tnl == 0)
			{
				tnl = 1;
			}
			C_Variables.NextlevelExp = tnl;
			
			buffer.Dispose();
		}
		
		private static void Packet_Blood(ref byte[] data)
		{
			int x = 0;
			int y = 0;
			int sprite = 0;
			ByteStream buffer = new ByteStream(data);
			x = buffer.ReadInt32();
			y = buffer.ReadInt32();
			
			// randomise sprite
			sprite = C_GameLogic.Rand(1, 3);
			
			C_Variables.BloodIndex++;
			if (C_Variables.BloodIndex >= byte.MaxValue)
			{
				C_Variables.BloodIndex = (byte) 1;
			}
			
			ref var with_1 = ref C_Types.Blood[C_Variables.BloodIndex];
			with_1.X = x;
			with_1.Y = y;
			with_1.Sprite = sprite;
			with_1.Timer = C_General.GetTickCount();
			
			buffer.Dispose();
		}
		
		private static void Packet_UpdateAnimation(ref byte[] data)
		{
			int n = 0;
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			n = buffer.ReadInt32();
			// Update the Animation
			for (i = 0; i <= (Types.Animation[n].Frames.Length - 1); i++)
			{
				Types.Animation[n].Frames[i] = buffer.ReadInt32();
			}
			
			for (i = 0; i <= (Types.Animation[n].LoopCount.Length - 1); i++)
			{
				Types.Animation[n].LoopCount[i] = buffer.ReadInt32();
			}
			
			for (i = 0; i <= (Types.Animation[n].LoopTime.Length - 1); i++)
			{
				Types.Animation[n].LoopTime[i] = buffer.ReadInt32();
			}
			
			Types.Animation[n].Name = buffer.ReadString().Trim();
			Types.Animation[n].Sound = buffer.ReadString().Trim();
			
			if (ReferenceEquals(Types.Animation[n].Name, null))
			{
				Types.Animation[n].Name = "";
			}
			if (ReferenceEquals(Types.Animation[n].Sound, null))
			{
				Types.Animation[n].Sound = "";
			}
			
			for (i = 0; i <= (Types.Animation[n].Sprite.Length - 1); i++)
			{
				Types.Animation[n].Sprite[i] = buffer.ReadInt32();
			}
			buffer.Dispose();
		}
		
		private static void Packet_Animation(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_Variables.AnimationIndex++;
			if (C_Variables.AnimationIndex >= byte.MaxValue)
			{
				C_Variables.AnimationIndex = (byte) 1;
			}
			
			ref var with_1 = ref C_Types.AnimInstance[C_Variables.AnimationIndex];
			with_1.Animation = buffer.ReadInt32();
			with_1.X = buffer.ReadInt32();
			with_1.Y = buffer.ReadInt32();
			with_1.LockType = (byte)buffer.ReadInt32();
			with_1.lockindex = buffer.ReadInt32();
			with_1.Used[0] = true;
			with_1.Used[1] = true;
			
			buffer.Dispose();
		}
		
		private static void Packet_NPCVitals(ref byte[] data)
		{
			int mapNpcNum = 0;
			ByteStream buffer = new ByteStream(data);
			mapNpcNum = buffer.ReadInt32();
			for (var i = 1; i <= (int) Enums.VitalType.Count - 1; i++)
			{
				C_Maps.MapNpc[mapNpcNum].Vital[(int) i] = buffer.ReadInt32();
			}
			
			buffer.Dispose();
		}
		
		private static void Packet_Cooldown(ref byte[] data)
		{
			int slot = 0;
			ByteStream buffer = new ByteStream(data);
			slot = buffer.ReadInt32();
			C_Variables.SkillCd[slot] = C_General.GetTickCount();
			
			buffer.Dispose();
		}
		
		private static void Packet_ClearSkillBuffer(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_Variables.SkillBuffer = 0;
			C_Variables.SkillBufferTimer = 0;
			
			buffer.Dispose();
		}
		
		private static void Packet_SayMessage(ref byte[] data)
		{
			int access;
			string name = "";
			string message = "";
			string header = "";
			int pk;
			ByteStream buffer = new ByteStream(data);
			name = buffer.ReadString().Trim();
			access = buffer.ReadInt32();
			pk = buffer.ReadInt32();
			message = buffer.ReadString().Trim();
			header = buffer.ReadString().Trim();
			
			C_Text.AddText(header + name + ": " + message, (System.Int32) Enums.QColorType.SayColor);
			
			buffer.Dispose();
		}
		
		private static void Packet_Stunned(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_Variables.StunDuration = buffer.ReadInt32();
			
			buffer.Dispose();
		}
		
		private static void Packet_MapWornEquipment(ref byte[] data)
		{
			int playernum = 0;
			ByteStream buffer = new ByteStream(data);
			playernum = buffer.ReadInt32();
			C_Player.SetPlayerEquipment(playernum, buffer.ReadInt32(), Enums.EquipmentType.Armor);
			C_Player.SetPlayerEquipment(playernum, buffer.ReadInt32(), Enums.EquipmentType.Weapon);
			C_Player.SetPlayerEquipment(playernum, buffer.ReadInt32(), Enums.EquipmentType.Helmet);
			C_Player.SetPlayerEquipment(playernum, buffer.ReadInt32(), Enums.EquipmentType.Shield);
			C_Player.SetPlayerEquipment(playernum, buffer.ReadInt32(), Enums.EquipmentType.Shoes);
			C_Player.SetPlayerEquipment(playernum, buffer.ReadInt32(), Enums.EquipmentType.Gloves);
			
			buffer.Dispose();
		}
		
		private static void Packet_GameData(ref byte[] data)
		{
			int n = 0;
			int i = 0;
			int z = 0;
			int x = 0;
			int a = 0;
			int b = 0;
			ByteStream buffer = new ByteStream(Compression.DecompressBytes(data));
			
			//\\\Read Class Data\\\
			
			// Max classes
			C_Variables.MaxClasses = (byte) (buffer.ReadInt32());
			Types.Classes = new C_Types.ClassRec[C_Variables.MaxClasses + 1];
			
			for (i = 0; i <= C_Variables.MaxClasses; i++)
			{
				Types.Classes[i].Stat = new byte[(int) Enums.StatType.Count];
			}
			
			for (i = 0; i <= C_Variables.MaxClasses; i++)
			{
				Types.Classes[i].Vital = new int[(int) Enums.VitalType.Count];
			}
			
			for (i = 1; i <= C_Variables.MaxClasses; i++)
			{
				
				ref var with_1 = ref Types.Classes[i];
				with_1.Name = buffer.ReadString().Trim();
				with_1.Desc = buffer.ReadString().Trim();
				
				with_1.Vital[(byte)Enums.VitalType.HP] = buffer.ReadInt32();
				with_1.Vital[(byte)Enums.VitalType.MP] = buffer.ReadInt32();
				with_1.Vital[(byte)Enums.VitalType.SP] = buffer.ReadInt32();
				
				// get array size
				z = buffer.ReadInt32();
				// redim array
				with_1.MaleSprite = new int[z + 1];
				// loop-receive data
				for (x = 0; x <= z; x++)
				{
					with_1.MaleSprite[x] = buffer.ReadInt32();
				}
				
				// get array size
				z = buffer.ReadInt32();
				// redim array
				with_1.FemaleSprite = new int[z + 1];
				// loop-receive data
				for (x = 0; x <= z; x++)
				{
					with_1.FemaleSprite[x] = buffer.ReadInt32();
				}
				
				with_1.Stat[(byte)Enums.StatType.Strength] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Endurance] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Vitality] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Intelligence] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Luck] = (byte)buffer.ReadInt32();
				with_1.Stat[(byte)Enums.StatType.Spirit] = (byte)buffer.ReadInt32();
				
				with_1.StartItem = new int[6];
				with_1.StartValue = new int[6];
				for (var q = 1; q <= 5; q++)
				{
					with_1.StartItem[q] = buffer.ReadInt32();
					with_1.StartValue[q] = buffer.ReadInt32();
				}
				
				with_1.StartMap = buffer.ReadInt32();
				with_1.StartX = (byte)buffer.ReadInt32();
				with_1.StartY = (byte)buffer.ReadInt32();
				
				with_1.BaseExp = buffer.ReadInt32();
				
			}
			
			i = 0;
			x = 0;
			n = 0;
			z = 0;
			
			//\\\End Read Class Data\\\
			
			//\\\Read Item Data\\\\\\\
			x = buffer.ReadInt32();
			
			for (i = 1; i <= x; i++)
			{
				n = buffer.ReadInt32();
				
				// Update the item
				Types.Item[n].AccessReq = buffer.ReadInt32();
				
				for (z = 0; z <= (int) Enums.StatType.Count - 1; z++)
				{
					Types.Item[n].Add_Stat[z] = (byte)buffer.ReadInt32();
				}
				
				Types.Item[n].Animation = buffer.ReadInt32();
				Types.Item[n].BindType = (byte) (buffer.ReadInt32());
				Types.Item[n].ClassReq = buffer.ReadInt32();
				Types.Item[n].Data1 = buffer.ReadInt32();
				Types.Item[n].Data2 = buffer.ReadInt32();
				Types.Item[n].Data3 = buffer.ReadInt32();
				Types.Item[n].TwoHanded = buffer.ReadInt32();
				Types.Item[n].LevelReq = buffer.ReadInt32();
				Types.Item[n].Mastery = (byte) (buffer.ReadInt32());
				Types.Item[n].Name = buffer.ReadString().Trim();
				Types.Item[n].Paperdoll = buffer.ReadInt32();
				Types.Item[n].Pic = buffer.ReadInt32();
				Types.Item[n].Price = buffer.ReadInt32();
				Types.Item[n].Rarity = (byte) (buffer.ReadInt32());
				Types.Item[n].Speed = buffer.ReadInt32();
				
				Types.Item[n].Randomize = (byte) (buffer.ReadInt32());
				Types.Item[n].RandomMin = (byte) (buffer.ReadInt32());
				Types.Item[n].RandomMax = (byte) (buffer.ReadInt32());
				
				Types.Item[n].Stackable = (byte) (buffer.ReadInt32());
				Types.Item[n].Description = buffer.ReadString().Trim();
				
				for (z = 0; z <= (int) Enums.StatType.Count - 1; z++)
				{
					Types.Item[n].Stat_Req[z] = (byte)buffer.ReadInt32();
				}
				
				Types.Item[n].Type = (byte) (buffer.ReadInt32());
				Types.Item[n].SubType = (byte) (buffer.ReadInt32());
				
				Types.Item[n].ItemLevel = (byte) (buffer.ReadInt32());
				
				//Housing
				Types.Item[n].FurnitureWidth = buffer.ReadInt32();
				Types.Item[n].FurnitureHeight = buffer.ReadInt32();
				
				for (a = 0; a <= 3; a++)
				{
					for (b = 0; b <= 3; b++)
					{
						Types.Item[n].FurnitureBlocks[a, b] = buffer.ReadInt32();
						Types.Item[n].FurnitureFringe[a, b] = buffer.ReadInt32();
					}
				}
				
				Types.Item[n].KnockBack = (byte) (buffer.ReadInt32());
				Types.Item[n].KnockBackTiles = (byte) (buffer.ReadInt32());
				
				Types.Item[n].Projectile = buffer.ReadInt32();
				Types.Item[n].Ammo = buffer.ReadInt32();
			}
			
			// changes to inventory, need to clear any drop menu
			
			FrmGame.Default.pnlCurrency.Visible = false;
			FrmGame.Default.txtCurrency.Text = "";
			C_Variables.TmpCurrencyItem = 0;
			C_Variables.CurrencyMenu = (byte) 0; // clear
			
			i = 0;
			n = 0;
			x = 0;
			z = 0;
			
			//\\\End Read Item Data\\\\\\\
			
			//\\\Read Animation Data\\\\\\\
			x = buffer.ReadInt32();
			
			for (i = 1; i <= x; i++)
			{
				n = buffer.ReadInt32();
				// Update the Animation
				for (z = 0; z <= (Types.Animation[n].Frames.Length - 1); z++)
				{
					Types.Animation[n].Frames[z] = buffer.ReadInt32();
				}
				
				for (z = 0; z <= (Types.Animation[n].LoopCount.Length - 1); z++)
				{
					Types.Animation[n].LoopCount[z] = buffer.ReadInt32();
				}
				
				for (z = 0; z <= (Types.Animation[n].LoopTime.Length - 1); z++)
				{
					Types.Animation[n].LoopTime[z] = buffer.ReadInt32();
				}
				
				Types.Animation[n].Name = buffer.ReadString().Trim();
				Types.Animation[n].Sound = buffer.ReadString().Trim();
				
				if (ReferenceEquals(Types.Animation[n].Name, null))
				{
					Types.Animation[n].Name = "";
				}
				if (ReferenceEquals(Types.Animation[n].Sound, null))
				{
					Types.Animation[n].Sound = "";
				}
				
				for (z = 0; z <= (Types.Animation[n].Sprite.Length - 1); z++)
				{
					Types.Animation[n].Sprite[z] = buffer.ReadInt32();
				}
			}
			
			i = 0;
			n = 0;
			x = 0;
			z = 0;
			
			//\\\End Read Animation Data\\\\\\\
			
			//\\\Read NPC Data\\\\\\\
			x = buffer.ReadInt32();
			for (i = 1; i <= x; i++)
			{
				n = buffer.ReadInt32();
				// Update the Npc
				Types.Npc[n].Animation = buffer.ReadInt32();
				Types.Npc[n].AttackSay = buffer.ReadString().Trim();
				Types.Npc[n].Behaviour = (byte) (buffer.ReadInt32());
				for (z = 1; z <= 5; z++)
				{
					Types.Npc[n].DropChance[z] = buffer.ReadInt32();
					Types.Npc[n].DropItem[z] = buffer.ReadInt32();
					Types.Npc[n].DropItemValue[z] = buffer.ReadInt32();
				}
				
				Types.Npc[n].Exp = buffer.ReadInt32();
				Types.Npc[n].Faction = (byte) (buffer.ReadInt32());
				Types.Npc[n].Hp = buffer.ReadInt32();
				Types.Npc[n].Name = buffer.ReadString().Trim();
				Types.Npc[n].Range = (byte) (buffer.ReadInt32());
				Types.Npc[n].SpawnTime = (byte) (buffer.ReadInt32());
				Types.Npc[n].SpawnSecs = buffer.ReadInt32();
				Types.Npc[n].Sprite = buffer.ReadInt32();
				
				for (z = 0; z <= (int) Enums.StatType.Count - 1; z++)
				{
					Types.Npc[n].Stat[z] = (byte)buffer.ReadInt32();
				}
				
				Types.Npc[n].QuestNum = buffer.ReadInt32();
				
				Types.Npc[n].Skill = new byte[Constants.MAX_NPC_SKILLS + 1];
				for (z = 1; z <= Constants.MAX_NPC_SKILLS; z++)
				{
					Types.Npc[n].Skill[z] = (byte)buffer.ReadInt32();
				}
				
				Types.Npc[i].Level = buffer.ReadInt32();
				Types.Npc[i].Damage = buffer.ReadInt32();
				
				if (ReferenceEquals(Types.Npc[n].AttackSay, null))
				{
					Types.Npc[n].AttackSay = "";
				}
				if (ReferenceEquals(Types.Npc[n].Name, null))
				{
					Types.Npc[n].Name = "";
				}
			}
			
			i = 0;
			n = 0;
			x = 0;
			z = 0;
			
			//\\\End Read NPC Data\\\\\\\
			
			//\\\Read Shop Data\\\\\\\
			x = buffer.ReadInt32();
			
			for (i = 1; i <= x; i++)
			{
				n = buffer.ReadInt32();
				
				Types.Shop[n].BuyRate = buffer.ReadInt32();
				Types.Shop[n].Name = buffer.ReadString().Trim();
				Types.Shop[n].Face = (byte) (buffer.ReadInt32());
				
				for (z = 0; z <= Constants.MAX_TRADES; z++)
				{
					Types.Shop[n].TradeItem[z].CostItem = buffer.ReadInt32();
					Types.Shop[n].TradeItem[z].CostValue = buffer.ReadInt32();
					Types.Shop[n].TradeItem[z].Item = buffer.ReadInt32();
					Types.Shop[n].TradeItem[z].ItemValue = buffer.ReadInt32();
				}
				
				if (ReferenceEquals(Types.Shop[n].Name, null))
				{
					Types.Shop[n].Name = "";
				}
			}
			
			i = 0;
			n = 0;
			x = 0;
			z = 0;
			
			//\\\End Read Shop Data\\\\\\\
			
			//\\\Read Skills Data\\\\\\\\\\
			x = buffer.ReadInt32();
			
			for (i = 1; i <= x; i++)
			{
				n = buffer.ReadInt32();
				
				Types.Skill[n].AccessReq = buffer.ReadInt32();
				Types.Skill[n].AoE = buffer.ReadInt32();
				Types.Skill[n].CastAnim = buffer.ReadInt32();
				Types.Skill[n].CastTime = buffer.ReadInt32();
				Types.Skill[n].CdTime = buffer.ReadInt32();
				Types.Skill[n].ClassReq = buffer.ReadInt32();
				Types.Skill[n].Dir = (byte) (buffer.ReadInt32());
				Types.Skill[n].Duration = buffer.ReadInt32();
				Types.Skill[n].Icon = buffer.ReadInt32();
				Types.Skill[n].Interval = buffer.ReadInt32();
				Types.Skill[n].IsAoE = System.Convert.ToBoolean(buffer.ReadInt32());
				Types.Skill[n].LevelReq = buffer.ReadInt32();
				Types.Skill[n].Map = buffer.ReadInt32();
				Types.Skill[n].MpCost = buffer.ReadInt32();
				Types.Skill[n].Name = buffer.ReadString().Trim();
				Types.Skill[n].Range = buffer.ReadInt32();
				Types.Skill[n].SkillAnim = buffer.ReadInt32();
				Types.Skill[n].StunDuration = buffer.ReadInt32();
				Types.Skill[n].Type = (byte) (buffer.ReadInt32());
				Types.Skill[n].Vital = buffer.ReadInt32();
				Types.Skill[n].X = buffer.ReadInt32();
				Types.Skill[n].Y = buffer.ReadInt32();
				
				Types.Skill[n].IsProjectile = buffer.ReadInt32();
				Types.Skill[n].Projectile = buffer.ReadInt32();
				
				Types.Skill[n].KnockBack = (byte) (buffer.ReadInt32());
				Types.Skill[n].KnockBackTiles = (byte) (buffer.ReadInt32());
				
				if (ReferenceEquals(Types.Skill[n].Name, null))
				{
					Types.Skill[n].Name = "";
				}
			}
			
			i = 0;
			x = 0;
			n = 0;
			z = 0;
			
			//\\\End Read Skills Data\\\\\\\\\\
			
			//\\\Read Resource Data\\\\\\\\\\\\
			x = buffer.ReadInt32();
			
			for (i = 1; i <= x; i++)
			{
				n = buffer.ReadInt32();
				
				Types.Resource[n].Animation = buffer.ReadInt32();
				Types.Resource[n].EmptyMessage = buffer.ReadString().Trim();
				Types.Resource[n].ExhaustedImage = buffer.ReadInt32();
				Types.Resource[n].Health = buffer.ReadInt32();
				Types.Resource[n].ExpReward = buffer.ReadInt32();
				Types.Resource[n].ItemReward = buffer.ReadInt32();
				Types.Resource[n].Name = buffer.ReadString().Trim();
				Types.Resource[n].ResourceImage = buffer.ReadInt32();
				Types.Resource[n].ResourceType = buffer.ReadInt32();
				Types.Resource[n].RespawnTime = buffer.ReadInt32();
				Types.Resource[n].SuccessMessage = buffer.ReadString().Trim();
				Types.Resource[n].LvlRequired = buffer.ReadInt32();
				Types.Resource[n].ToolRequired = buffer.ReadInt32();
				Types.Resource[n].Walkthrough = System.Convert.ToBoolean(buffer.ReadInt32());
				
				if (ReferenceEquals(Types.Resource[n].Name, null))
				{
					Types.Resource[n].Name = "";
				}
				if (ReferenceEquals(Types.Resource[n].EmptyMessage, null))
				{
					Types.Resource[n].EmptyMessage = "";
				}
				if (ReferenceEquals(Types.Resource[n].SuccessMessage, null))
				{
					Types.Resource[n].SuccessMessage = "";
				}
			}
			
			i = 0;
			n = 0;
			x = 0;
			z = 0;
			
			//\\\End Read Resource Data\\\\\\\\\\\\
			
			buffer.Dispose();
		}
		
		private static void Packet_Target(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_Variables.MyTarget = buffer.ReadInt32();
			C_Variables.MyTargetType = buffer.ReadInt32();
			
			buffer.Dispose();
		}
		
		private static void Packet_Mapreport(ref byte[] data)
		{
			int I = 0;
			ByteStream buffer = new ByteStream(data);
			for (I = 1; I <= Constants.MAX_MAPS; I++)
			{
				C_Types.MapNames[I] = buffer.ReadString().Trim();
			}
			
			C_UpdateUI.UpdateMapnames = true;
			
			buffer.Dispose();
		}
		
		private static void Packet_Admin(ref byte[] data)
		{
			C_UpdateUI.Adminvisible = true;
		}
		
		private static void Packet_MapNames(ref byte[] data)
		{
			int I = 0;
			ByteStream buffer = new ByteStream(data);
			for (I = 1; I <= Constants.MAX_MAPS; I++)
			{
				C_Types.MapNames[I] = buffer.ReadString().Trim();
			}
			
			buffer.Dispose();
		}
		
		private static void Packet_Hotbar(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			for (i = 1; i <= C_HotBar.MaxHotbar; i++)
			{
				C_Types.Player[C_Variables.Myindex].Hotbar[i].Slot = buffer.ReadInt32();
				C_Types.Player[C_Variables.Myindex].Hotbar[i].SType = (byte) (buffer.ReadInt32());
			}
			
			buffer.Dispose();
		}
		
		private static void Packet_Critical(ref byte[] data)
		{
			C_Variables.ShakeTimerEnabled = true;
			C_Variables.ShakeTimer = C_General.GetTickCount();
		}
		
		private static void Packet_News(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_Constants.GameName = buffer.ReadString();
			C_Variables.News = buffer.ReadString();
			
			C_Variables.UpdateNews = true;
			
			buffer.Dispose();
		}
		
		private static void Packet_RClick(ref byte[] data)
		{
			C_Variables.ShowRClick = true;
		}
		
		private static void Packet_TotalOnline(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			C_Variables.TotalOnline = buffer.ReadInt32();
			
			buffer.Dispose();
		}
		
		private static void Packet_Emote(ref byte[] data)
		{
			int index = 0;
			int emote = 0;
			ByteStream buffer = new ByteStream(data);
			index = buffer.ReadInt32();
			emote = buffer.ReadInt32();
			
			ref var with_1 = ref C_Types.Player[index];
			with_1.Emote = emote;
			with_1.EmoteTimer = C_General.GetTickCount() + 5000;
			
			buffer.Dispose();
			
		}
		
		private static void Packet_ChatBubble(ref byte[] data)
		{
			int targetType = 0;
			int target = 0;
			string message = "";
			int colour = 0;
			ByteStream buffer = new ByteStream(data);
			
			target = buffer.ReadInt32();
			targetType = buffer.ReadInt32();
			message = buffer.ReadString().Trim();
			colour = buffer.ReadInt32();
			C_GameLogic.AddChatBubble(target, (byte) targetType, message, colour);
			
			buffer.Dispose();
			
		}
		
		private static void Packet_LeftGame(ref byte[] data)
		{
			C_General.DestroyGame(true);
		}
		
	}
}
