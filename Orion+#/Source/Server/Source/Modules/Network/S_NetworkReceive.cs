using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using ASFW;
using ASFW.IO;
using static Engine.Types;
using static Engine.S_Events;
using static Engine.modTypes;
using static Engine.Enums;
using static Engine.S_Housing;

namespace Engine
{
    static class S_NetworkReceive
    {
        internal static void PacketRouter()
        {
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CCheckPing] = Packet_Ping;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CNewAccount] = Packet_NewAccount;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CDelAccount] = Packet_DeleteAccount;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CLogin] = Packet_Login;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CAddChar] = Packet_AddChar;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CUseChar] = Packet_UseChar;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CDelChar] = Packet_DeleteChar;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSayMsg] = Packet_SayMessage;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CBroadcastMsg] = Packet_BroadCastMsg;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CPlayerMsg] = Packet_PlayerMsg;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CPlayerMove] = Packet_PlayerMove;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CPlayerDir] = Packet_PlayerDirection;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CUseItem] = Packet_UseItem;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CAttack] = Packet_Attack;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CPlayerInfoRequest] = Packet_PlayerInfo;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CWarpMeTo] = Packet_WarpMeTo;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CWarpToMe] = Packet_WarpToMe;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CWarpTo] = Packet_WarpTo;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSetSprite] = Packet_SetSprite;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CGetStats] = Packet_GetStats;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestNewMap] = Packet_RequestNewMap;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSaveMap] = Packet_MapData;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CNeedMap] = Packet_NeedMap;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CMapGetItem] = S_Items.Packet_GetItem;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CMapDropItem] = S_Items.Packet_DropItem;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CMapRespawn] = Packet_RespawnMap;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CMapReport] = Packet_MapReport; // Mapreport
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CKickPlayer] = Packet_KickPlayer;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CBanList] = Packet_Banlist;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CBanDestroy] = Packet_DestroyBans;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CBanPlayer] = Packet_BanPlayer;
                                            
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestEditMap] = Packet_EditMapRequest;
                                            
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSetAccess] = Packet_SetAccess;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CWhosOnline] = Packet_WhosOnline;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSetMotd] = Packet_SetMotd;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSearch] = Packet_PlayerSearch;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSkills] = Packet_Skills;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CCast] = Packet_Cast;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CQuit] = Packet_QuitGame;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSwapInvSlots] = Packet_SwapInvSlots;
                                            
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CCheckPing] = Packet_CheckPing;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CUnequip] = Packet_Unequip;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestPlayerData] = Packet_RequestPlayerData;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestItems] = S_Items.Packet_RequestItems;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestNPCS] = Packet_RequestNpcs;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestResources] = S_Resources.Packet_RequestResources;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSpawnItem] = Packet_SpawnItem;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CTrainStat] = Packet_TrainStat;
                                            
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestAnimations] = S_Animations.Packet_RequestAnimations;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestSkills] = Packet_RequestSkills;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestShops] = Packet_RequestShops;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestLevelUp] = Packet_RequestLevelUp;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CForgetSkill] = Packet_ForgetSkill;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CCloseShop] = Packet_CloseShop;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CBuyItem] = Packet_BuyItem;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSellItem] = Packet_SellItem;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CChangeBankSlots] = Packet_ChangeBankSlots;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CDepositItem] = Packet_DepositItem;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CWithdrawItem] = Packet_WithdrawItem;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CCloseBank] = Packet_CloseBank;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CAdminWarp] = Packet_AdminWarp;
                                            
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CTradeInvite] = Packet_TradeInvite;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CTradeInviteAccept] = Packet_TradeInviteAccept;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CAcceptTrade] = Packet_AcceptTrade;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CDeclineTrade] = Packet_DeclineTrade;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CTradeItem] = Packet_TradeItem;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CUntradeItem] = Packet_UntradeItem;
                                            
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CAdmin] = Packet_Admin;
                                            
            // quests                       
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestQuests] = S_Quest.Packet_RequestQuests;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CQuestLogUpdate] = S_Quest.Packet_QuestLogUpdate;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CPlayerHandleQuest] = S_Quest.Packet_PlayerHandleQuest;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CQuestReset] = S_Quest.Packet_QuestReset;
                                            
            // Housing                      
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CBuyHouse] = S_Housing.Packet_BuyHouse;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CVisit] = S_Housing.Packet_InviteToHouse;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CAcceptVisit] = S_Housing.Packet_AcceptInvite;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CPlaceFurniture] = S_Housing.Packet_PlaceFurniture;
                                            
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSellHouse] = S_Housing.Packet_SellHouse;
                                            
            // hotbar                       
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSetHotbarSlot] = Packet_SetHotBarSlot;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CDeleteHotbarSlot] = Packet_DeleteHotBarSlot;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CUseHotbarSlot] = Packet_UseHotBarSlot;
                                            
            // Events                       
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CEventChatReply] = S_Events.Packet_EventChatReply;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CEvent] = S_Events.Packet_Event;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestSwitchesAndVariables] = S_Events.Packet_RequestSwitchesAndVariables;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSwitchesAndVariables] = S_Events.Packet_SwitchesAndVariables;
                                            
            // projectiles                  
                                            
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestProjectiles] = S_Projectiles.HandleRequestProjectiles;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CClearProjectile] = S_Projectiles.HandleClearProjectile;
                                            
            // craft                        
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestRecipes] = modCrafting.Packet_RequestRecipes;
                                            
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CCloseCraft] = modCrafting.Packet_CloseCraft;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CStartCraft] = modCrafting.Packet_StartCraft;
                                            
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestClasses] = Packet_RequestClasses;
                                            
            // emotes                       
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CEmote] = Packet_Emote;
                                            
            // parties                      
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestParty] = S_Parties.Packet_PartyRquest;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CAcceptParty] = S_Parties.Packet_AcceptParty;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CDeclineParty] = S_Parties.Packet_DeclineParty;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CLeaveParty] = S_Parties.Packet_LeaveParty;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CPartyChatMsg] = S_Parties.Packet_PartyChatMsg;
                                            
            // pets                         
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CRequestPets] = S_Pets.Packet_RequestPets;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSummonPet] = S_Pets.Packet_SummonPet;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CPetMove] = S_Pets.Packet_PetMove;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CSetBehaviour] = S_Pets.Packet_SetPetBehaviour;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CReleasePet] = S_Pets.Packet_ReleasePet;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CPetSkill] = S_Pets.Packet_PetSkill;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CPetUseStatPoint] = S_Pets.Packet_UsePetStatPoint;

            // auction
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CAddAuct] = S_Auction.HandleAddAuction;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CCheckAuct] = S_Auction.HandleGetAuctions;
            S_NetworkConfig.Socket.PacketId[(int)Packets.ClientPackets.CBid] = S_Auction.HandleBid;

            // editor login                 
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.EditorLogin] = Packet_EditorLogin;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.EditorRequestMap] = Packet_EditorRequestMap;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.EditorSaveMap] = Packet_EditorMapData;
                                            
            // editor                       
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.RequestEditItem] = S_Items.Packet_EditItem;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.SaveItem] = S_Items.Packet_SaveItem;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.RequestEditNpc] = S_Npc.Packet_EditNpc;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.SaveNpc] = S_Npc.Packet_SaveNPC;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.RequestEditShop] = Packet_EditShop;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.SaveShop] = Packet_SaveShop;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.RequestEditSkill] = Packet_EditSkill;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.SaveSkill] = Packet_SaveSkill;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.RequestEditResource] = S_Resources.Packet_EditResource;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.SaveResource] = S_Resources.Packet_SaveResource;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.RequestEditAnimation] = S_Animations.Packet_EditAnimation;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.SaveAnimation] = S_Animations.Packet_SaveAnimation;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.RequestEditQuest] = S_Quest.Packet_RequestEditQuest;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.SaveQuest] = S_Quest.Packet_SaveQuest;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.RequestEditHouse] = S_Housing.Packet_RequestEditHouse;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.SaveHouses] = S_Housing.Packet_SaveHouses;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.RequestEditProjectiles] = S_Projectiles.HandleRequestEditProjectiles;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.SaveProjectile] = S_Projectiles.HandleSaveProjectile;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.RequestEditRecipes] = modCrafting.Packet_RequestEditRecipes;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.SaveRecipe] = modCrafting.Packet_SaveRecipe;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.RequestEditClasses] = Packet_RequestEditClasses;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.SaveClasses] = Packet_SaveClasses;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.RequestAutoMap] = S_AutoMap.Packet_RequestAutoMap;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.SaveAutoMap] = S_AutoMap.Packet_SaveAutoMap;
                                            
            // pet                          
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.CRequestEditPet] = S_Pets.Packet_RequestEditPet;
            S_NetworkConfig.Socket.PacketId[(int)Packets.EditorPackets.CSavePet] = S_Pets.Packet_SavePet;
        }

        private static void Packet_Ping(int index, ref byte[] data)
        {
            modTypes.TempPlayer[index].DataPackets = modTypes.TempPlayer[index].DataPackets + 1;
        }

        private static void Packet_NewAccount(int index, ref byte[] data)
        {
            string username;
            string password;
            int i;
            int n;
            string IP;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CNewAccount");

            if (!S_NetworkConfig.IsPlaying(index) && !S_NetworkConfig.IsLoggedIn(index))
            {
                // Get the Data
                username = S_Globals.EKeyPair.DecryptString(buffer.ReadString());
                password = S_Globals.EKeyPair.DecryptString(buffer.ReadString());
                // Prevent hacking
                if (Microsoft.VisualBasic.Strings.Len(username.Trim()) < 3 || Microsoft.VisualBasic.Strings.Len(password.Trim()) < 3)
                {
                    S_NetworkSend.AlertMsg(index, "Your username and password must be at least three characters in length");
                    return;
                }

                var loopTo = Microsoft.VisualBasic.Strings.Len(username);

                // Prevent hacking
                for (i = 1; i <= loopTo; i++)
                {
                    n = Microsoft.VisualBasic.Strings.AscW(Microsoft.VisualBasic.Strings.Mid(username, i, 1));

                    if (!S_General.IsNameLegal(n))
                    {
                        S_NetworkSend.AlertMsg(index, "Invalid username, only letters, numbers, spaces, and _ allowed in usernames.");
                        return;
                    }
                }

                // banned ip?

                // Cut off last portion of ip
                IP = S_NetworkConfig.Socket.ClientIp(index);

                for (i = Microsoft.VisualBasic.Strings.Len(IP); i >= 1; i += -1)
                {
                    if (Microsoft.VisualBasic.Strings.Mid(IP, i, 1) == ".")
                        break;
                }

                IP = Microsoft.VisualBasic.Strings.Mid(IP, 1, i);
                if (modDatabase.IsBanned(IP))
                    S_NetworkSend.AlertMsg(index, "Your Banned!");

                // Check to see if account already exists
                if (!modDatabase.AccountExist(username))
                {
                    modDatabase.AddAccount(index, username, password);

                    Console.WriteLine("Account " + username + " has been created.");
                    modDatabase.Addlog("Account " + username + " has been created.", S_Constants.PLAYER_LOG);

                    // Load the player
                    modDatabase.LoadPlayer(index, username);

                    // Check if character data has been created
                    if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Name)) > 0)
                        // we have a char!
                        S_Players.HandleUseChar(index);
                    else
                        // send new char shit
                        if (!S_NetworkConfig.IsPlaying(index))
                        S_NetworkSend.SendNewCharClasses(index);

                    // Show the player up on the socket status
                    modDatabase.Addlog(S_Players.GetPlayerLogin(index) + " has logged in from " + S_NetworkConfig.Socket.ClientIp(index) + ".", S_Constants.PLAYER_LOG);
                    Console.WriteLine(S_Players.GetPlayerLogin(index) + " has logged in from " + S_NetworkConfig.Socket.ClientIp(index) + ".");
                }
                else
                    S_NetworkSend.AlertMsg(index, "Sorry, that account username is already taken!");

                buffer.Dispose();
            }
        }

        private static void Packet_DeleteAccount(int index, ref byte[] data)
        {
            string Name;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CDelChar");

            // Get the data
            Name = buffer.ReadString();

            if (S_Players.GetPlayerLogin(index) == Microsoft.VisualBasic.Strings.Trim(Name))
            {
                S_NetworkSend.PlayerMsg(index, "You cannot delete your own account while online!", (int)Enums.ColorType.BrightRed);
                return;
            }

            var loopTo = S_GameLogic.GetPlayersOnline();
            for (var i = 1; i <= loopTo; i++)
            {
                if (S_NetworkConfig.IsPlaying(i))
                {
                    if (Microsoft.VisualBasic.Strings.Trim(modTypes.Player[i].Login) == Microsoft.VisualBasic.Strings.Trim(Name))
                    {
                        S_NetworkSend.AlertMsg(i, "Your account has been removed by an admin!");
                        modDatabase.ClearPlayer(i);
                    }
                }
            }
        }

        private static void Packet_Login(int index, ref byte[] data)
        {
            string Name;
            string IP;
            string Password;
            int i;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CLogin");

            if (!S_NetworkConfig.IsPlaying(index))
            {
                if (!S_NetworkConfig.IsLoggedIn(index))
                {

                    // check if its banned
                    // Cut off last portion of ip
                    IP = S_NetworkConfig.Socket.ClientIp(index);

                    for (i = Microsoft.VisualBasic.Strings.Len(IP); i >= 1; i += -1)
                    {
                        if (Microsoft.VisualBasic.Strings.Mid(IP, i, 1) == ".")
                            break;
                    }

                    IP = Microsoft.VisualBasic.Strings.Mid(IP, 1, i);
                    if (modDatabase.IsBanned(IP))
                        S_NetworkSend.AlertMsg(index, "Your Banned!");

                    // Get the data
                    Name = S_Globals.EKeyPair.DecryptString(buffer.ReadString());
                    Password = S_Globals.EKeyPair.DecryptString(buffer.ReadString());

                    // Check versions
                    if (S_Globals.EKeyPair.DecryptString(buffer.ReadString()) != Application.ProductVersion)
                    {
                        S_NetworkSend.AlertMsg(index, "Version outdated, please visit " + modTypes.Options.Website);
                        return;
                    }

                    if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Name)) < 3 || Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Password)) < 3)
                    {
                        S_NetworkSend.AlertMsg(index, "Your name and password must be at least three characters in length");
                        return;
                    }

                    if (!modDatabase.AccountExist(Name))
                    {
                        S_NetworkSend.AlertMsg(index, "That account name does not exist.");
                        return;
                    }

                    if (!modDatabase.PasswordOK(Name, Password))
                    {
                        S_NetworkSend.AlertMsg(index, "Incorrect password.");
                        return;
                    }

                    if (S_NetworkConfig.IsMultiAccounts(Name))
                    {
                        S_NetworkSend.AlertMsg(index, "Multiple account logins is not authorized.");
                        return;
                    }

                    // Load the player
                    modDatabase.LoadPlayer(index, Name);
                    modDatabase.ClearBank(index);
                    modDatabase.LoadBank(index, Name);

                    buffer.Dispose();
                    buffer = new ByteStream(4);
                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SLoginOk));
                    buffer.WriteInt32(S_Constants.MAX_CHARS);

                    S_General.AddDebug("Sent SMSG: SLoginOk");

                    for (i = 1; i <= S_Constants.MAX_CHARS; i++)
                    {
                        if (modTypes.Player[index].Character[i].Classes <= 0)
                        {
                            buffer.WriteString("");
                            buffer.WriteInt32(modTypes.Player[index].Character[i].Sprite);
                            buffer.WriteInt32(modTypes.Player[index].Character[i].Level);
                            buffer.WriteString("");
                            buffer.WriteInt32(0);
                        }
                        else
                        {
                            buffer.WriteString(Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Character[i].Name));
                            buffer.WriteInt32(modTypes.Player[index].Character[i].Sprite);
                            buffer.WriteInt32(modTypes.Player[index].Character[i].Level);
                            buffer.WriteString(Microsoft.VisualBasic.Strings.Trim(Types.Classes[modTypes.Player[index].Character[i].Classes].Name));
                            buffer.WriteInt32(modTypes.Player[index].Character[i].Sex);
                        }
                    }

                    S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

                    // Show the player up on the socket status
                    modDatabase.Addlog(S_Players.GetPlayerLogin(index) + " has logged in from " + S_NetworkConfig.Socket.ClientIp(index) + ".", S_Constants.PLAYER_LOG);
                    Console.WriteLine(S_Players.GetPlayerLogin(index) + " has logged in from " + S_NetworkConfig.Socket.ClientIp(index) + ".");

                    // ' Check if character data has been created
                    // If Len(Trim$(Player(index).Character(TempPlayer(index).CurChar).Name)) > 0 Then
                    // ' we have a char!
                    // 'HandleUseChar(index)
                    // Else
                    // ' send new char shit
                    // If Not IsPlaying(index) Then
                    // SendNewCharClasses(index)
                    // End If
                    // End If

                    buffer.Dispose();
                }
            }
        }

        private static void Packet_UseChar(int index, ref byte[] data)
        {
            byte slot;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CUseChar");

            if (!S_NetworkConfig.IsPlaying(index))
            {
                if (S_NetworkConfig.IsLoggedIn(index))
                {
                    slot = (byte)buffer.ReadInt32();

                    // Check if character data has been created
                    if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Character[slot].Name)) > 0)
                    {
                        // we have a char!
                        modTypes.TempPlayer[index].CurChar = slot;
                        S_Players.HandleUseChar(index);
                        modDatabase.ClearBank(index);
                        modDatabase.LoadBank(index, Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Login));
                    }
                    else
                        // send new char shit
                        if (!S_NetworkConfig.IsPlaying(index))
                    {
                        S_NetworkSend.SendNewCharClasses(index);
                        modTypes.TempPlayer[index].CurChar = slot;
                    }
                }
            }
        }

        private static void Packet_AddChar(int index, ref byte[] data)
        {
            string Name;
            byte slot;
            int Sex;
            int Classes;
            int Sprite;
            int i;
            int n;

            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CAddChar");

            if (!S_NetworkConfig.IsPlaying(index))
            {
                slot = (byte)buffer.ReadInt32();
                Name = buffer.ReadString();
                Sex = buffer.ReadInt32();
                Classes = buffer.ReadInt32();
                Sprite = buffer.ReadInt32();

                // Prevent hacking
                if (Microsoft.VisualBasic.Strings.Len(Name.Trim()) < 3)
                {
                    S_NetworkSend.AlertMsg(index, "Character name must be at least three characters in length.");
                    return;
                }

                var loopTo = Microsoft.VisualBasic.Strings.Len(Name);
                for (i = 1; i <= loopTo; i++)
                {
                    n = Microsoft.VisualBasic.Strings.AscW(Microsoft.VisualBasic.Strings.Mid(Name, i, 1));

                    if (!S_General.IsNameLegal(n))
                    {
                        S_NetworkSend.AlertMsg(index, "Invalid name, only letters, numbers, spaces, and _ allowed in names.");
                        return;
                    }
                }

                if ((Sex < (byte)Enums.SexType.Male) || (Sex > (byte)Enums.SexType.Female))
                    return;

                if (Classes < 1 || Classes > S_Globals.Max_Classes)
                    return;

                // Check if char already exists in slot
                if (modDatabase.CharExist(index, slot))
                {
                    S_NetworkSend.AlertMsg(index, "Character already exists!");
                    return;
                }

                // Check if name is already in use
                if (modDatabase.FindChar(Name))
                {
                    S_NetworkSend.AlertMsg(index, "Sorry, but that name is in use!");
                    return;
                }

                // Everything went ok, add the character
                modTypes.TempPlayer[index].CurChar = slot;
                modDatabase.AddChar(index, slot, Name, (byte)Sex, (byte)Classes, Sprite);
                modDatabase.Addlog("Character " + Name + " added to " + S_Players.GetPlayerLogin(index) + "'s account.", S_Constants.PLAYER_LOG);

                // log them in!!
                S_Players.HandleUseChar(index);

                buffer.Dispose();
            }
        }

        private static void Packet_DeleteChar(int index, ref byte[] data)
        {
            byte slot;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CDelChar");

            if (!S_NetworkConfig.IsPlaying(index))
            {
                if (S_NetworkConfig.IsLoggedIn(index))
                {
                    slot = (byte)buffer.ReadInt32();

                    // Check if character data has been created
                    if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Character[slot].Name)) > 0)
                    {
                        // we have a char!
                        modDatabase.DeleteName(Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Character[slot].Name));
                        modDatabase.ClearCharacter(index, slot);
                        modDatabase.SaveCharacter(index, slot);

                        buffer.Dispose();
                        buffer = new ByteStream(4);
                        buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SLoginOk));
                        buffer.WriteInt32(S_Constants.MAX_CHARS);

                        S_General.AddDebug("Sent SMSG: SLoginOk");

                        for (var i = 1; i <= S_Constants.MAX_CHARS; i++)
                        {
                            if (modTypes.Player[index].Character[i].Classes <= 0)
                            {
                                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Character[i].Name)));
                                buffer.WriteInt32(modTypes.Player[index].Character[i].Sprite);
                                buffer.WriteInt32(modTypes.Player[index].Character[i].Level);
                                buffer.WriteString((""));
                                buffer.WriteInt32(0);
                            }
                            else
                            {
                                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Character[i].Name)));
                                buffer.WriteInt32(modTypes.Player[index].Character[i].Sprite);
                                buffer.WriteInt32(modTypes.Player[index].Character[i].Level);
                                buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Types.Classes[modTypes.Player[index].Character[i].Classes].Name)));
                                buffer.WriteInt32(modTypes.Player[index].Character[i].Sex);
                            }
                        }

                        S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
                    }
                }
            }
        }

        private static void Packet_SayMessage(int index, ref byte[] data)
        {
            string msg;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CSayMsg");

            // msg = Buffer.ReadString
            msg = buffer.ReadString();

            modDatabase.Addlog("Map #" + S_Players.GetPlayerMap(index) + ": " + S_Players.GetPlayerName(index) + " says, '" + msg + "'", S_Constants.PLAYER_LOG);

            S_NetworkSend.SayMsg_Map(S_Players.GetPlayerMap(index), index, msg, (int)Enums.ColorType.White);
            S_NetworkSend.SendChatBubble(S_Players.GetPlayerMap(index), index, (byte)Enums.TargetType.Player, msg, (int)Enums.ColorType.White);

            buffer.Dispose();
        }

        private static void Packet_BroadCastMsg(int index, ref byte[] data)
        {
            string msg;
            string s;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CBroadcastMsg");

            // msg = Buffer.ReadString
            msg = buffer.ReadString();

            s = "[Global]" + S_Players.GetPlayerName(index) + ": " + msg;
            S_NetworkSend.SayMsg_Global(index, msg, (int)Enums.ColorType.White);
            modDatabase.Addlog(s, S_Constants.PLAYER_LOG);
            Console.WriteLine(s);

            buffer.Dispose();
        }

        internal static void Packet_PlayerMsg(int index, ref byte[] data)
        {
            string OtherPlayer;
            string Msg;
            int OtherPlayerindex;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CPlayerMsg");

            OtherPlayer = buffer.ReadString();
            // Msg = buffer.ReadString
            Msg = buffer.ReadString();
            buffer.Dispose();

            OtherPlayerindex = S_GameLogic.FindPlayer(OtherPlayer);
            if (OtherPlayerindex != index)
            {
                if (OtherPlayerindex > 0)
                {
                    modDatabase.Addlog(S_Players.GetPlayerName(index) + " tells " + S_Players.GetPlayerName(index) + ", '" + Msg + "'", S_Constants.PLAYER_LOG);
                    S_NetworkSend.PlayerMsg(OtherPlayerindex, S_Players.GetPlayerName(index) + " tells you, '" + Msg + "'", (int)Enums.ColorType.Pink);
                    S_NetworkSend.PlayerMsg(index, "You tell " + S_Players.GetPlayerName(OtherPlayerindex) + ", '" + Msg + "'", (int)Enums.ColorType.Pink);
                }
                else
                    S_NetworkSend.PlayerMsg(index, "Player is not online.", (int)Enums.ColorType.BrightRed);
            }
            else
                S_NetworkSend.PlayerMsg(index, "Cannot message your self!", (int)Enums.ColorType.BrightRed);
        }

        private static void Packet_PlayerMove(int index, ref byte[] data)
        {
            int Dir;
            int movement;
            int tmpX;
            int tmpY;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CPlayerMove");

            if (Convert.ToBoolean(modTypes.TempPlayer[index].GettingMap) == true)
                return;

            Dir = buffer.ReadInt32();
            movement = buffer.ReadInt32();
            tmpX = buffer.ReadInt32();
            tmpY = buffer.ReadInt32();
            buffer.Dispose();

            // Prevent hacking
            if (Dir < (byte)Enums.DirectionType.Up || Dir > (byte)Enums.DirectionType.Right)
                return;

            if (movement < 1 || movement > 2)
                return;

            // Prevent player from moving if they have casted a skill
            if (modTypes.TempPlayer[index].SkillBuffer > 0)
            {
                S_NetworkSend.SendPlayerXY(index);
                return;
            }

            // Cant move if in the bank!
            if (modTypes.TempPlayer[index].InBank)
            {
                S_NetworkSend.SendPlayerXY(index);
                return;
            }

            // if stunned, stop them moving
            if (modTypes.TempPlayer[index].StunDuration > 0)
            {
                S_NetworkSend.SendPlayerXY(index);
                return;
            }

            // Prevent player from moving if in shop
            if (modTypes.TempPlayer[index].InShop > 0)
            {
                S_NetworkSend.SendPlayerXY(index);
                return;
            }

            // Desynced
            if (S_Players.GetPlayerX(index) != tmpX)
            {
                S_NetworkSend.SendPlayerXY(index);
                return;
            }

            if (S_Players.GetPlayerY(index) != tmpY)
            {
                S_NetworkSend.SendPlayerXY(index);
                return;
            }

            S_Players.PlayerMove(index, Dir, movement, false);

            S_General.AddDebug(" Player: " + S_Players.GetPlayerName(index) + " : " + " X: " + tmpX + " Y: " + tmpY + " Dir: " + Dir + " Movement: " + movement);

            buffer.Dispose();
        }

        public static void Packet_PlayerDirection(int index, ref byte[] data)
        {
            int dir;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CPlayerDir");

            if (modTypes.TempPlayer[index].GettingMap == 1)
                return;

            dir = buffer.ReadInt32();
            buffer.Dispose();

            // Prevent hacking
            if (dir < (byte)Enums.DirectionType.Up || dir > (byte)Enums.DirectionType.Right)
                return;

            S_Players.SetPlayerDir(index, dir);

            buffer = new ByteStream(4);
            buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SPlayerDir));
            buffer.WriteInt32(index);
            buffer.WriteInt32(S_Players.GetPlayerDir(index));
            S_NetworkConfig.SendDataToMapBut(index, S_Players.GetPlayerMap(index), ref buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: SPlayerDir");

            buffer.Dispose();
        }

        public static void Packet_UseItem(int index, ref byte[] data)
        {
            int invnum;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CUseItem");

            invnum = buffer.ReadInt32();
            buffer.Dispose();

            S_Players.UseItem(index, invnum);
        }

        public static void Packet_Attack(int index, ref byte[] data)
        {
            int i;
            int Tempindex;
            int x = 0;
            int y = 0;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CAttack");

            // can't attack whilst casting
            if (modTypes.TempPlayer[index].SkillBuffer > 0)
                return;

            // can't attack whilst stunned
            if (modTypes.TempPlayer[index].StunDuration > 0)
                return;

            // Send this packet so they can see the person attacking
            buffer = new ByteStream(4);
            buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SAttack));
            buffer.WriteInt32(index);
            S_NetworkConfig.SendDataToMap(S_Players.GetPlayerMap(index), ref buffer.Data, buffer.Head);
            buffer.Dispose();

            // Projectile check
            if (S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Weapon) > 0)
            {
                if (Types.Item[S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Weapon)].Projectile > 0)
                {
                    if (Types.Item[S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Weapon)].Ammo > 0)
                    {
                        if (Convert.ToBoolean(S_Players.HasItem(index, Types.Item[S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Weapon)].Ammo)))
                        {
                            S_Players.TakeInvItem(index, Types.Item[S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Weapon)].Ammo, 1);
                            S_Projectiles.PlayerFireProjectile(index);
                            return;
                        }
                        else
                        {
                            S_NetworkSend.PlayerMsg(index, "No More " + Types.Item[Types.Item[S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Weapon)].Ammo].Name + " !", (int)Enums.ColorType.BrightRed);
                            return;
                        }
                    }
                    else
                    {
                        S_Projectiles.PlayerFireProjectile(index);
                        return;
                    }
                }
            }

            var loopTo = S_GameLogic.GetPlayersOnline();

            // Try to attack a player
            for (i = 1; i <= loopTo; i++)
            {
                Tempindex = i;

                // Make sure we dont try to attack ourselves
                if (Tempindex != index)
                {
                    if (S_NetworkConfig.IsPlaying(Tempindex))
                        S_Players.TryPlayerAttackPlayer(index, i);
                }
            }

            // Try to attack a npc
            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                S_Players.TryPlayerAttackNpc(index, i);

            // Check tradeskills
            switch (S_Players.GetPlayerDir(index))
            {
                case (byte)Enums.DirectionType.Up:
                    {
                        if (S_Players.GetPlayerY(index) == 0)
                            return;
                        x = S_Players.GetPlayerX(index);
                        y = S_Players.GetPlayerY(index) - 1;
                        break;
                    }

                case (byte)Enums.DirectionType.Down:
                    {
                        if (S_Players.GetPlayerY(index) == modTypes.Map[S_Players.GetPlayerMap(index)].MaxY)
                            return;
                        x = S_Players.GetPlayerX(index);
                        y = S_Players.GetPlayerY(index) + 1;
                        break;
                    }

                case (byte)Enums.DirectionType.Left:
                    {
                        if (S_Players.GetPlayerX(index) == 0)
                            return;
                        x = S_Players.GetPlayerX(index) - 1;
                        y = S_Players.GetPlayerY(index);
                        break;
                    }

                case (byte)Enums.DirectionType.Right:
                    {
                        if (S_Players.GetPlayerX(index) == modTypes.Map[S_Players.GetPlayerMap(index)].MaxX)
                            return;
                        x = S_Players.GetPlayerX(index) + 1;
                        y = S_Players.GetPlayerY(index);
                        break;
                    }
            }

            S_Resources.CheckResource(index, x, y);

            buffer.Dispose();
        }

        public static void Packet_PlayerInfo(int index, ref byte[] data)
        {
            int i;
            int n;
            string name;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CPlayerInfoRequest");

            name = buffer.ReadString();
            i = S_GameLogic.FindPlayer(name);

            if (i > 0)
            {
                S_NetworkSend.PlayerMsg(index, "Account:  " + Microsoft.VisualBasic.Strings.Trim(modTypes.Player[i].Login) + ", Name: " + S_Players.GetPlayerName(i), (int)Enums.ColorType.Yellow);

                if (S_Players.GetPlayerAccess(index) > (byte)Enums.AdminType.Monitor)
                {
                    S_NetworkSend.PlayerMsg(index, "-=- Stats for " + S_Players.GetPlayerName(i) + " -=-", (int)Enums.ColorType.Yellow);
                    S_NetworkSend.PlayerMsg(index, "Level: " + S_Players.GetPlayerLevel(i) + "  Exp: " + S_Players.GetPlayerExp(i) + "/" + S_Players.GetPlayerNextLevel(i), (int)Enums.ColorType.Yellow);
                    S_NetworkSend.PlayerMsg(index, "HP: " + S_Players.GetPlayerVital(i, Enums.VitalType.HP) + "/" + S_Players.GetPlayerMaxVital(i, Enums.VitalType.HP) + "  MP: " + S_Players.GetPlayerVital(i, Enums.VitalType.MP) + "/" + S_Players.GetPlayerMaxVital(i, Enums.VitalType.MP) + "  SP: " + S_Players.GetPlayerVital(i, Enums.VitalType.SP) + "/" + S_Players.GetPlayerMaxVital(i, Enums.VitalType.SP), (int)Enums.ColorType.Yellow);
                    S_NetworkSend.PlayerMsg(index, "Strength: " + S_Players.GetPlayerStat(i, Enums.StatType.Strength) + "  Defense: " + S_Players.GetPlayerStat(i, Enums.StatType.Endurance) + "  Magic: " + S_Players.GetPlayerStat(i, Enums.StatType.Intelligence) + "  Speed: " + S_Players.GetPlayerStat(i, Enums.StatType.Spirit), (int)Enums.ColorType.Yellow);
                    n = (S_Players.GetPlayerStat(i, Enums.StatType.Strength) / 2) + (S_Players.GetPlayerLevel(i) / 2);
                    i = (S_Players.GetPlayerStat(i, Enums.StatType.Endurance) / 2) + (S_Players.GetPlayerLevel(i) / 2);

                    if (n > 100)
                        n = 100;
                    if (i > 100)
                        i = 100;
                    S_NetworkSend.PlayerMsg(index, "Critical Hit Chance: " + n + "%, Block Chance: " + i + "%", (int)Enums.ColorType.Yellow);
                }
            }
            else
                S_NetworkSend.PlayerMsg(index, "Player is not online.", (int)Enums.ColorType.BrightRed);

            buffer.Dispose();
        }

        public static void Packet_WarpMeTo(int index, ref byte[] data)
        {
            int n;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CWarpMeTo");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;

            // The player
            n = S_GameLogic.FindPlayer(buffer.ReadString());
            buffer.Dispose();

            if (n != index)
            {
                if (n > 0)
                {
                    S_Players.PlayerWarp(index, S_Players.GetPlayerMap(n), S_Players.GetPlayerX(n), S_Players.GetPlayerY(n));
                    S_NetworkSend.PlayerMsg(n, S_Players.GetPlayerName(index) + " has warped to you.", (int)Enums.ColorType.Yellow);
                    S_NetworkSend.PlayerMsg(index, "You have been warped to " + S_Players.GetPlayerName(n) + ".", (int)Enums.ColorType.Yellow);
                    modDatabase.Addlog(S_Players.GetPlayerName(index) + " has warped to " + S_Players.GetPlayerName(n) + ", map #" + S_Players.GetPlayerMap(n) + ".", S_Constants.ADMIN_LOG);
                }
                else
                    S_NetworkSend.PlayerMsg(index, "Player is not online.", (int)Enums.ColorType.BrightRed);
            }
            else
                S_NetworkSend.PlayerMsg(index, "You cannot warp to yourself, dumbass!", (int)Enums.ColorType.BrightRed);
        }

        public static void Packet_WarpToMe(int index, ref byte[] data)
        {
            int n;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CWarpToMe");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;

            // The player
            n = S_GameLogic.FindPlayer(buffer.ReadString());
            buffer.Dispose();

            if (n != index)
            {
                if (n > 0)
                {
                    S_Players.PlayerWarp(n, S_Players.GetPlayerMap(index), S_Players.GetPlayerX(index), S_Players.GetPlayerY(index));
                    S_NetworkSend.PlayerMsg(n, "You have been summoned by " + S_Players.GetPlayerName(index) + ".", (int)Enums.ColorType.Yellow);
                    S_NetworkSend.PlayerMsg(index, S_Players.GetPlayerName(n) + " has been summoned.", (int)Enums.ColorType.Yellow);
                    modDatabase.Addlog(S_Players.GetPlayerName(index) + " has warped " + S_Players.GetPlayerName(n) + " to self, map #" + S_Players.GetPlayerMap(index) + ".", S_Constants.ADMIN_LOG);
                }
                else
                    S_NetworkSend.PlayerMsg(index, "Player is not online.", (int)Enums.ColorType.BrightRed);
            }
            else
                S_NetworkSend.PlayerMsg(index, "You cannot warp yourself to yourself, dumbass!", (int)Enums.ColorType.BrightRed);
        }

        public static void Packet_WarpTo(int index, ref byte[] data)
        {
            int n;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CWarpTo");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;

            // The map
            n = buffer.ReadInt32();
            buffer.Dispose();

            // Prevent hacking
            if (n < 0 || n > S_Instances.MAX_CACHED_MAPS)
                return;

            S_Players.PlayerWarp(index, n, S_Players.GetPlayerX(index), S_Players.GetPlayerY(index));
            S_NetworkSend.PlayerMsg(index, "You have been warped to map #" + n, (int)Enums.ColorType.Yellow);
            modDatabase.Addlog(S_Players.GetPlayerName(index) + " warped to map #" + n + ".", S_Constants.ADMIN_LOG);
        }

        public static void Packet_SetSprite(int index, ref byte[] data)
        {
            int n;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CSetSprite");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;

            // The sprite
            n = buffer.ReadInt32();
            buffer.Dispose();

            S_Players.SetPlayerSprite(index, n);
            S_NetworkSend.SendPlayerData(index);
        }

        public static void Packet_GetStats(int index, ref byte[] data)
        {
            int i;
            int n;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CGetStats");

            S_NetworkSend.PlayerMsg(index, "-=- Stats for " + S_Players.GetPlayerName(index) + " -=-", (int)Enums.ColorType.Yellow);
            S_NetworkSend.PlayerMsg(index, "Level: " + S_Players.GetPlayerLevel(index) + "  Exp: " + S_Players.GetPlayerExp(index) + "/" + S_Players.GetPlayerNextLevel(index), (int)Enums.ColorType.Yellow);
            S_NetworkSend.PlayerMsg(index, "HP: " + S_Players.GetPlayerVital(index, Enums.VitalType.HP) + "/" + S_Players.GetPlayerMaxVital(index, Enums.VitalType.HP) + "  MP: " + S_Players.GetPlayerVital(index, Enums.VitalType.MP) + "/" + S_Players.GetPlayerMaxVital(index, Enums.VitalType.MP) + "  SP: " + S_Players.GetPlayerVital(index, Enums.VitalType.SP) + "/" + S_Players.GetPlayerMaxVital(index, Enums.VitalType.SP), (int)Enums.ColorType.Yellow);
            S_NetworkSend.PlayerMsg(index, "STR: " + S_Players.GetPlayerStat(index, Enums.StatType.Strength) + "  DEF: " + S_Players.GetPlayerStat(index, Enums.StatType.Endurance) + "  MAGI: " + S_Players.GetPlayerStat(index, Enums.StatType.Intelligence) + "  Speed: " + S_Players.GetPlayerStat(index, Enums.StatType.Spirit), (int)Enums.ColorType.Yellow);
            n = (S_Players.GetPlayerStat(index, Enums.StatType.Strength) / 2) + (S_Players.GetPlayerLevel(index) / 2);
            i = (S_Players.GetPlayerStat(index, Enums.StatType.Endurance) / 2) + (S_Players.GetPlayerLevel(index) / 2);

            if (n > 100)
                n = 100;
            if (i > 100)
                i = 100;
            S_NetworkSend.PlayerMsg(index, "Critical Hit Chance: " + n + "%, Block Chance: " + i + "%", (int)Enums.ColorType.Yellow);
            buffer.Dispose();
        }

        public static void Packet_RequestNewMap(int index, ref byte[] data)
        {
            int dir;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CRequestNewMap");

            dir = buffer.ReadInt32();
            buffer.Dispose();

            // Prevent hacking
            if (dir < (byte)Enums.DirectionType.Up || dir > (byte)Enums.DirectionType.Right)
                return;

            S_Players.PlayerMove(index, dir, 1, true);
        }

        public static void Packet_MapData(int index, ref byte[] data)
        {
            int i;
            int mapNum;
            int x;
            int y;

            S_General.AddDebug("Recieved CMSG: CSaveMap");

            ByteStream buffer = new ByteStream(Compression.DecompressBytes(data));

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;

            S_Globals.Gettingmap = true;

            mapNum = S_Players.GetPlayerMap(index);

            i = modTypes.Map[mapNum].Revision + 1;
            modDatabase.ClearMap(mapNum);

            modTypes.Map[mapNum].Name = buffer.ReadString();
            modTypes.Map[mapNum].Music = buffer.ReadString();
            modTypes.Map[mapNum].Revision = i;
            modTypes.Map[mapNum].Moral = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].Tileset = buffer.ReadInt32();
            modTypes.Map[mapNum].Up = buffer.ReadInt32();
            modTypes.Map[mapNum].Down = buffer.ReadInt32();
            modTypes.Map[mapNum].Left = buffer.ReadInt32();
            modTypes.Map[mapNum].Right = buffer.ReadInt32();
            modTypes.Map[mapNum].BootMap = buffer.ReadInt32();
            modTypes.Map[mapNum].BootX = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].BootY = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].MaxX = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].MaxY = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].WeatherType = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].Fogindex = buffer.ReadInt32();
            modTypes.Map[mapNum].WeatherIntensity = buffer.ReadInt32();
            modTypes.Map[mapNum].FogAlpha = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].FogSpeed = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].HasMapTint = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].MapTintR = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].MapTintG = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].MapTintB = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].MapTintA = (byte)buffer.ReadInt32();

            modTypes.Map[mapNum].Instanced = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].Panorama = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].Parallax = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].Brightness = (byte)buffer.ReadInt32();

            modTypes.Map[mapNum].Tile = new TileRec[modTypes.Map[mapNum].MaxX + 1, modTypes.Map[mapNum].MaxY + 1];

            for (x = 1; x <= Constants.MAX_MAP_NPCS; x++)
            {
                modDatabase.ClearMapNpc(x, mapNum);
                modTypes.Map[mapNum].Npc[x] = buffer.ReadInt32();
            }

            {
                var loopTo = modTypes.Map[mapNum].MaxX;
                for (int xx = 0; xx <= loopTo; xx++)
                {
                    var loopTo1 = modTypes.Map[mapNum].MaxY;
                    for (y = 0; y <= loopTo1; y++)
                    {
                        modTypes.Map[mapNum].Tile[xx, y].Data1 = buffer.ReadInt32();
                        modTypes.Map[mapNum].Tile[xx, y].Data2 = buffer.ReadInt32();
                        modTypes.Map[mapNum].Tile[xx, y].Data3 = buffer.ReadInt32();
                        modTypes.Map[mapNum].Tile[xx, y].DirBlock = (byte)buffer.ReadInt32();
                        modTypes.Map[mapNum].Tile[xx, y].Layer = new TileDataRec[6];
                        for (i = 0; i <= (byte)Enums.LayerType.Count - 1; i++)
                        {
                            modTypes.Map[mapNum].Tile[xx, y].Layer[i].Tileset = (byte)buffer.ReadInt32();
                            modTypes.Map[mapNum].Tile[xx, y].Layer[i].X = (byte)buffer.ReadInt32();
                            modTypes.Map[mapNum].Tile[xx, y].Layer[i].Y = (byte)buffer.ReadInt32();
                            modTypes.Map[mapNum].Tile[xx, y].Layer[i].AutoTile = (byte)buffer.ReadInt32();
                        }
                        modTypes.Map[mapNum].Tile[xx, y].Type = (byte)buffer.ReadInt32();
                    }
                }
            }

            // Event Data!
            modTypes.Map[mapNum].EventCount = buffer.ReadInt32();

            if (modTypes.Map[mapNum].EventCount > 0)
            {
                modTypes.Map[mapNum].Events = new EventStruct[modTypes.Map[mapNum].EventCount + 1];
                var loopTo2 = modTypes.Map[mapNum].EventCount;
                for (i = 1; i <= loopTo2; i++)
                {
                    {
                        modTypes.Map[mapNum].Events[i].Name = buffer.ReadString();
                        modTypes.Map[mapNum].Events[i].Globals = (byte)buffer.ReadInt32();
                        modTypes.Map[mapNum].Events[i].X = buffer.ReadInt32();
                        modTypes.Map[mapNum].Events[i].Y = buffer.ReadInt32();
                        modTypes.Map[mapNum].Events[i].PageCount = buffer.ReadInt32();
                    }
                    if (modTypes.Map[mapNum].Events[i].PageCount > 0)
                    {
                        modTypes.Map[mapNum].Events[i].Pages = new EventPageStruct[modTypes.Map[mapNum].Events[i].PageCount + 1];
                        modTypes.TempPlayer[i].EventMap.EventPages = new MapEventStruct[modTypes.Map[mapNum].Events[i].PageCount + 1];
                        var loopTo3 = modTypes.Map[mapNum].Events[i].PageCount;
                        for (x = 1; x <= loopTo3; x++)
                        {
                            {
                                //var modTypes.Map[mapNum].Events[i].Pages[x] = modTypes.Map[mapNum].Events[i].Pages[x];
                                modTypes.Map[mapNum].Events[i].Pages[x].ChkVariable = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].Variableindex = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].VariableCondition = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].VariableCompare = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].ChkSwitch = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].Switchindex = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].SwitchCompare = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].ChkHasItem = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].HasItemindex = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].HasItemAmount = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].ChkSelfSwitch = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].SelfSwitchindex = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].SelfSwitchCompare = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicType = (byte)buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].Graphic = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicX = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicY = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicX2 = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicY2 = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].MoveType = (byte)buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].MoveSpeed = (byte)buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].MoveFreq = (byte)buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].IgnoreMoveRoute = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].RepeatMoveRoute = buffer.ReadInt32();

                                if (modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount > 0)
                                {
                                    modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute = new MoveRouteStruct[modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount + 1];
                                    var loopTo4 = modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount;
                                    for (y = 1; y <= loopTo4; y++)
                                    {
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Index = buffer.ReadInt32();
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data1 = buffer.ReadInt32();
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data2 = buffer.ReadInt32();
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data3 = buffer.ReadInt32();
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data4 = buffer.ReadInt32();
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data5 = buffer.ReadInt32();
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data6 = buffer.ReadInt32();
                                    }
                                }

                                modTypes.Map[mapNum].Events[i].Pages[x].WalkAnim = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].DirFix = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].WalkThrough = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].ShowName = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].Trigger = (byte)buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].Position = (byte)buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].QuestNum = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].ChkPlayerGender = buffer.ReadInt32();
                            }

                            if (modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount > 0)
                            {
                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList = new CommandListStruct[modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount + 1];
                                var loopTo5 = modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount;
                                for (y = 1; y <= loopTo5; y++)
                                {
                                    modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount = buffer.ReadInt32();
                                    modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].ParentList = buffer.ReadInt32();
                                    if (modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount > 0)
                                    {
                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands = new EventCommandStruct[modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount + 1];
                                        var loopTo6 = modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount;
                                        for (var z = 1; z <= loopTo6; z++)
                                        {
                                            {
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Index = (byte)buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text1 = buffer.ReadString();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text2 = buffer.ReadString();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text3 = buffer.ReadString();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text4 = buffer.ReadString();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text5 = buffer.ReadString();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data1 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data2 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data3 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data4 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data5 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data6 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.CommandList = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Condition = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data1 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data2 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data3 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.ElseCommandList = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount = buffer.ReadInt32();
                                                int tmpcount = modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount;
                                                if (tmpcount > 0)
                                                {
                                                    var oldMoveRoute = modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute;
                                                    modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute = new MoveRouteStruct[tmpcount + 1];
                                                    if (oldMoveRoute != null)
                                                        Array.Copy(oldMoveRoute, modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute, Math.Min(tmpcount + 1, oldMoveRoute.Length));
                                                    var loopTo7 = tmpcount;
                                                    for (var w = 1; w <= loopTo7; w++)
                                                    {
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Index = buffer.ReadInt32();
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data1 = buffer.ReadInt32();
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data2 = buffer.ReadInt32();
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data3 = buffer.ReadInt32();
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data4 = buffer.ReadInt32();
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data5 = buffer.ReadInt32();
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data6 = buffer.ReadInt32();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // End Event Data

            // Save the map
            modDatabase.SaveMap(mapNum);
            modDatabase.SaveMapEvent(mapNum);

            S_Globals.Gettingmap = false;

            S_Npc.SendMapNpcsToMap(mapNum);
            S_Npc.SpawnMapNpcs(mapNum);
            S_EventLogic.SpawnGlobalEvents(mapNum);
            var loopTo8 = S_GameLogic.GetPlayersOnline();
            for (i = 1; i <= loopTo8; i++)
            {
                if (S_NetworkConfig.IsPlaying(i))
                {
                    if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Map == mapNum)
                        S_EventLogic.SpawnMapEventsFor(i, mapNum);
                }
            }

            // Clear it all out
            for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
            {
                S_Items.SpawnItemSlot(i, 0, 0, S_Players.GetPlayerMap(index), modTypes.MapItem[S_Players.GetPlayerMap(index), i].X, modTypes.MapItem[S_Players.GetPlayerMap(index), i].Y);
                modDatabase.ClearMapItem(i, S_Players.GetPlayerMap(index));
            }

            // Respawn
            S_Items.SpawnMapItems(S_Players.GetPlayerMap(index));

            modDatabase.ClearTempTile(mapNum);
            S_Resources.CacheResources(mapNum);
            var loopTo9 = S_GameLogic.GetPlayersOnline();

            // Refresh map for everyone online
            for (i = 1; i <= loopTo9; i++)
            {
                if (S_NetworkConfig.IsPlaying(i) && S_Players.GetPlayerMap(i) == mapNum)
                {
                    S_Players.PlayerWarp(i, mapNum, S_Players.GetPlayerX(i), S_Players.GetPlayerY(i));
                    // Send map
                    S_NetworkSend.SendMapData(i, mapNum, true);
                }
            }

            buffer.Dispose();
        }

        private static void Packet_NeedMap(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            S_General.AddDebug("Recieved CMSG: CNeedMap");
            string s = Convert.ToString(buffer.ReadInt32());
            buffer.Dispose();
            bool flag = Convert.ToDouble(s) == 1.0;
            if (flag)
            {
                S_NetworkSend.SendMapData(index, S_Players.GetPlayerMap(index), true);
            }
            else
            {
                S_NetworkSend.SendMapData(index, S_Players.GetPlayerMap(index), false);
            }
            S_EventLogic.SpawnMapEventsFor(index, S_Players.GetPlayerMap(index));
            S_NetworkSend.SendJoinMap(index);
            modTypes.TempPlayer[index].GettingMap = 0;
        }

        public static void Packet_RespawnMap(int index, ref byte[] data)
        {
            int i;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CMapRespawn");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;

            // Clear out it all
            for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
            {
                S_Items.SpawnItemSlot(i, 0, 0, S_Players.GetPlayerMap(index), modTypes.MapItem[S_Players.GetPlayerMap(index), i].X, modTypes.MapItem[S_Players.GetPlayerMap(index), i].Y);
                modDatabase.ClearMapItem(i, S_Players.GetPlayerMap(index));
            }

            // Respawn
            S_Items.SpawnMapItems(S_Players.GetPlayerMap(index));

            // Respawn NPCS
            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                S_Npc.SpawnNpc(i, S_Players.GetPlayerMap(index));

            S_Resources.CacheResources(S_Players.GetPlayerMap(index));
            S_NetworkSend.PlayerMsg(index, "Map respawned.", (int)Enums.ColorType.BrightGreen);
            modDatabase.Addlog(S_Players.GetPlayerName(index) + " has respawned map #" + S_Players.GetPlayerMap(index), S_Constants.ADMIN_LOG);

            buffer.Dispose();
        }

        public static void Packet_KickPlayer(int index, ref byte[] data)
        {
            int n;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CKickPlayer");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) <= 0)
                return;

            // The player index
            n = S_GameLogic.FindPlayer(buffer.ReadString());
            buffer.Dispose();

            if (n != index)
            {
                if (n > 0)
                {
                    if (S_Players.GetPlayerAccess(n) < S_Players.GetPlayerAccess(index))
                    {
                        S_NetworkSend.GlobalMsg(S_Players.GetPlayerName(n) + " has been kicked from " + modTypes.Options.GameName + " by " + S_Players.GetPlayerName(index) + "!");
                        modDatabase.Addlog(S_Players.GetPlayerName(index) + " has kicked " + S_Players.GetPlayerName(n) + ".", S_Constants.ADMIN_LOG);
                        S_NetworkSend.AlertMsg(n, "You have been kicked by " + S_Players.GetPlayerName(index) + "!");
                    }
                    else
                        S_NetworkSend.PlayerMsg(index, "That is a higher or same access admin then you!", (int)Enums.ColorType.BrightRed);
                }
                else
                    S_NetworkSend.PlayerMsg(index, "Player is not online.", (int)Enums.ColorType.BrightRed);
            }
            else
                S_NetworkSend.PlayerMsg(index, "You cannot kick yourself!", (int)Enums.ColorType.BrightRed);
        }

        public static void Packet_Banlist(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CBanList");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;

            S_NetworkSend.PlayerMsg(index, "Command /banlist is not available in Orion+... yet ;)", (int)Enums.ColorType.Yellow);
        }

        public static void Packet_DestroyBans(int index, ref byte[] data)
        {
            string filename;

            S_General.AddDebug("Recieved CMSG: CBanDestory");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Creator)
                return;

            filename = Application.StartupPath + @"\data\banlist.txt";

            if (File.Exists(filename))
                FileSystem.Kill(filename);

            S_NetworkSend.PlayerMsg(index, "Ban list destroyed.", (int)Enums.ColorType.BrightGreen);
        }

        public static void Packet_BanPlayer(int index, ref byte[] data)
        {
            int n;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CBanPlayer");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;

            // The player index
            n = S_GameLogic.FindPlayer(buffer.ReadString());
            buffer.Dispose();

            if (n != index)
            {
                if (n > 0)
                {
                    if (S_Players.GetPlayerAccess(n) < S_Players.GetPlayerAccess(index))
                        modDatabase.BanIndex(n, index);
                    else
                        S_NetworkSend.PlayerMsg(index, "That is a higher or same access admin then you!", (int)Enums.ColorType.BrightRed);
                }
                else
                    S_NetworkSend.PlayerMsg(index, "Player is not online.", (int)Enums.ColorType.BrightRed);
            }
            else
                S_NetworkSend.PlayerMsg(index, "You cannot ban yourself, dumbass!", (int)Enums.ColorType.BrightRed);
        }

        private static void Packet_EditMapRequest(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CRequestEditMap");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;

            if (S_Players.GetPlayerMap(index) > Constants.MAX_MAPS)
            {
                S_NetworkSend.PlayerMsg(index, "Cant edit instanced maps!", (int)Enums.ColorType.BrightRed);
                return;
            }

            S_Events.SendMapEventData(index);

            ByteStream Buffer = new ByteStream(4);
            Buffer.WriteInt32((byte)Packets.ServerPackets.SEditMap);
            S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);
            Buffer.Dispose();
        }

        public static void Packet_EditShop(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved EMSG: RequestEditShop");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Developer)
                return;

            var Buffer = new ByteStream(4);
            Buffer.WriteInt32((byte)Packets.ServerPackets.SShopEditor);
            S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);

            S_General.AddDebug("Sent SMSG: SShopEditor");

            Buffer.Dispose();
        }

        public static void Packet_SaveShop(int index, ref byte[] data)
        {
            int ShopNum;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved EMSG: SaveShop");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Developer)
                return;

            ShopNum = buffer.ReadInt32();

            // Prevent hacking
            if (ShopNum < 0 || ShopNum > Constants.MAX_SHOPS)
                return;

            Types.Shop[ShopNum].BuyRate = buffer.ReadInt32();
            Types.Shop[ShopNum].Name = buffer.ReadString();
            Types.Shop[ShopNum].Face = (byte)buffer.ReadInt32();

            for (var i = 0; i <= Constants.MAX_TRADES; i++)
            {
                Types.Shop[ShopNum].TradeItem[i].CostItem = buffer.ReadInt32();
                Types.Shop[ShopNum].TradeItem[i].CostValue = buffer.ReadInt32();
                Types.Shop[ShopNum].TradeItem[i].Item = buffer.ReadInt32();
                Types.Shop[ShopNum].TradeItem[i].ItemValue = buffer.ReadInt32();
            }

            if (Types.Shop[ShopNum].Name == null)
                Types.Shop[ShopNum].Name = "";

            buffer.Dispose();

            // Save it
            S_NetworkSend.SendUpdateShopToAll(ShopNum);
            modDatabase.SaveShop(ShopNum);
            modDatabase.Addlog(S_Players.GetPlayerLogin(index) + " saving shop #" + ShopNum + ".", S_Constants.ADMIN_LOG);
        }

        public static void Packet_EditSkill(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved EMSG: RequestEditSkill");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Developer)
                return;

            var Buffer = new ByteStream(4);
            Buffer.WriteInt32((int)Packets.ServerPackets.SSkillEditor);
            S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);

            S_General.AddDebug("Sent SMSG: SSkillEditor");

            Buffer.Dispose();
        }

        public static void Packet_SaveSkill(int index, ref byte[] data)
        {
            int skillnum;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved EMSG: SaveSkill");

            skillnum = buffer.ReadInt32();

            // Prevent hacking
            if (skillnum < 0 || skillnum > Constants.MAX_SKILLS)
                return;

            Types.Skill[skillnum].AccessReq = buffer.ReadInt32();
            Types.Skill[skillnum].AoE = buffer.ReadInt32();
            Types.Skill[skillnum].CastAnim = buffer.ReadInt32();
            Types.Skill[skillnum].CastTime = buffer.ReadInt32();
            Types.Skill[skillnum].CdTime = buffer.ReadInt32();
            Types.Skill[skillnum].ClassReq = buffer.ReadInt32();
            Types.Skill[skillnum].Dir = (byte)buffer.ReadInt32();
            Types.Skill[skillnum].Duration = buffer.ReadInt32();
            Types.Skill[skillnum].Icon = buffer.ReadInt32();
            Types.Skill[skillnum].Interval = buffer.ReadInt32();
            Types.Skill[skillnum].IsAoE = Convert.ToBoolean(buffer.ReadInt32());
            Types.Skill[skillnum].LevelReq = buffer.ReadInt32();
            Types.Skill[skillnum].Map = buffer.ReadInt32();
            Types.Skill[skillnum].MpCost = buffer.ReadInt32();
            Types.Skill[skillnum].Name = buffer.ReadString();
            Types.Skill[skillnum].Range = buffer.ReadInt32();
            Types.Skill[skillnum].SkillAnim = buffer.ReadInt32();
            Types.Skill[skillnum].StunDuration = buffer.ReadInt32();
            Types.Skill[skillnum].Type = (byte)buffer.ReadInt32();
            Types.Skill[skillnum].Vital = buffer.ReadInt32();
            Types.Skill[skillnum].X = buffer.ReadInt32();
            Types.Skill[skillnum].Y = buffer.ReadInt32();

            // projectiles
            Types.Skill[skillnum].IsProjectile = buffer.ReadInt32();
            Types.Skill[skillnum].Projectile = buffer.ReadInt32();

            Types.Skill[skillnum].KnockBack = (byte)buffer.ReadInt32();
            Types.Skill[skillnum].KnockBackTiles = (byte)buffer.ReadInt32();

            // Save it
            S_NetworkSend.SendUpdateSkillToAll(skillnum);
            modDatabase.SaveSkill(skillnum);
            modDatabase.Addlog(S_Players.GetPlayerLogin(index) + " saved Skill #" + skillnum + ".", S_Constants.ADMIN_LOG);

            buffer.Dispose();
        }

        public static void Packet_SetAccess(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            int n;
            int i;

            S_General.AddDebug("Recieved CMSG: CSetAccess");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Creator)
                return;

            // The index
            n = S_GameLogic.FindPlayer(buffer.ReadString());
            // The access
            i = buffer.ReadInt32();

            // Check for invalid access level
            if (i >= 0 || i <= 3)
            {

                // Check if player is on
                if (n > 0)
                {

                    // check to see if same level access is trying to change another access of the very same level and boot them if they are.
                    if (S_Players.GetPlayerAccess(n) == S_Players.GetPlayerAccess(index))
                    {
                        S_NetworkSend.PlayerMsg(index, "Invalid access level.", (int)Enums.ColorType.BrightRed);
                        return;
                    }

                    if (S_Players.GetPlayerAccess(n) <= 0)
                        S_NetworkSend.GlobalMsg(S_Players.GetPlayerName(n) + " has been blessed with administrative access.");

                    S_Players.SetPlayerAccess(n, i);
                    S_NetworkSend.SendPlayerData(n);
                    modDatabase.Addlog(S_Players.GetPlayerName(index) + " has modified " + S_Players.GetPlayerName(n) + "'s access.", S_Constants.ADMIN_LOG);
                }
                else
                    S_NetworkSend.PlayerMsg(index, "Player is not online.", (int)Enums.ColorType.BrightRed);
            }
            else
                S_NetworkSend.PlayerMsg(index, "Invalid access level.", (int)Enums.ColorType.BrightRed);

            buffer.Dispose();
        }

        public static void Packet_WhosOnline(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CWhosOnline");

            S_NetworkSend.SendWhosOnline(index);
        }

        public static void Packet_SetMotd(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CSetMotd");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;

            modTypes.Options.Motd = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            modDatabase.SaveOptions();

            S_NetworkSend.GlobalMsg("MOTD changed to: " + modTypes.Options.Motd);
            modDatabase.Addlog(S_Players.GetPlayerName(index) + " changed MOTD to: " + modTypes.Options.Motd, S_Constants.ADMIN_LOG);

            buffer.Dispose();
        }

        public static void Packet_PlayerSearch(int index, ref byte[] data)
        {
            byte TargetFound = 0;
            byte rclick = 0;
            int x = 0;
            int y = 0;
            int i = 0;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CSearch");

            x = buffer.ReadInt32();
            y = buffer.ReadInt32();
            rclick = (byte)buffer.ReadInt32();

            // Prevent subscript out of range
            if (x < 0 || x > modTypes.Map[S_Players.GetPlayerMap(index)].MaxX || y < 0 || y > modTypes.Map[S_Players.GetPlayerMap(index)].MaxY)
                return;
            var loopTo = S_GameLogic.GetPlayersOnline();

            // Check for a player
            for (i = 1; i <= loopTo; i++)
            {
                if (S_NetworkConfig.IsPlaying(i))
                {
                    if (S_Players.GetPlayerMap(index) == S_Players.GetPlayerMap(i))
                    {
                        if (S_Players.GetPlayerX(i) == x)
                        {
                            if (S_Players.GetPlayerY(i) == y)
                            {

                                // Consider the player
                                if (i != index)
                                {
                                    if (S_Players.GetPlayerLevel(i) >= S_Players.GetPlayerLevel(index) + 5)
                                        S_NetworkSend.PlayerMsg(index, "You wouldn't stand a chance.", (int)Enums.ColorType.BrightRed);
                                    else if (S_Players.GetPlayerLevel(i) > S_Players.GetPlayerLevel(index))
                                        S_NetworkSend.PlayerMsg(index, "This one seems to have an advantage over you.", (int)Enums.ColorType.Yellow);
                                    else if (S_Players.GetPlayerLevel(i) == S_Players.GetPlayerLevel(index))
                                        S_NetworkSend.PlayerMsg(index, "This would be an even fight.", (int)Enums.ColorType.White);
                                    else if (S_Players.GetPlayerLevel(index) >= S_Players.GetPlayerLevel(i) + 5)
                                        S_NetworkSend.PlayerMsg(index, "You could slaughter that player.", (int)Enums.ColorType.BrightBlue);
                                    else if (S_Players.GetPlayerLevel(index) > S_Players.GetPlayerLevel(i))
                                        S_NetworkSend.PlayerMsg(index, "You would have an advantage over that player.", (int)Enums.ColorType.BrightCyan);
                                }

                                // Change target
                                modTypes.TempPlayer[index].Target = i;
                                modTypes.TempPlayer[index].TargetType = (byte)Enums.TargetType.Player;
                                S_NetworkSend.PlayerMsg(index, "Your target is now " + S_Players.GetPlayerName(i) + ".", (int)Enums.ColorType.Yellow);
                                S_NetworkSend.SendTarget(index, modTypes.TempPlayer[index].Target, modTypes.TempPlayer[index].TargetType);
                                TargetFound = 1;
                                if (rclick == 1)
                                    S_NetworkSend.SendRightClick(index);
                                return;
                            }
                        }
                    }
                }
            }

            // Check for an item
            for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
            {
                if (modTypes.MapItem[S_Players.GetPlayerMap(index), i].Num > 0)
                {
                    if (modTypes.MapItem[S_Players.GetPlayerMap(index), i].X == x)
                    {
                        if (modTypes.MapItem[S_Players.GetPlayerMap(index), i].Y == y)
                        {
                            S_NetworkSend.PlayerMsg(index, "You see " + S_GameLogic.CheckGrammar(Microsoft.VisualBasic.Strings.Trim(Types.Item[modTypes.MapItem[S_Players.GetPlayerMap(index), i].Num].Name)) + ".", (int)Enums.ColorType.White);
                            return;
                        }
                    }
                }
            }

            // Check for an npc
            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
            {
                if (modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].Num > 0)
                {
                    if (modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].X == x)
                    {
                        if (modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].Y == y)
                        {
                            // Change target
                            modTypes.TempPlayer[index].Target = i;
                            modTypes.TempPlayer[index].TargetType = (byte)Enums.TargetType.Npc;
                            S_NetworkSend.PlayerMsg(index, "Your target is now " + S_GameLogic.CheckGrammar(Microsoft.VisualBasic.Strings.Trim(Types.Npc[modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[i].Num].Name)) + ".", (int)Enums.ColorType.Yellow);
                            S_NetworkSend.SendTarget(index, modTypes.TempPlayer[index].Target, modTypes.TempPlayer[index].TargetType);
                            TargetFound = 1;
                            return;
                        }
                    }
                }
            }

            // Housing
            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse > 0)
            {
                if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse == index)
                {
                    if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Houseindex > 0)
                    {
                        if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.FurnitureCount > 0)
                        {
                            var loopTo1 = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.FurnitureCount;
                            for (i = 1; i <= loopTo1; i++)
                            {
                                if (x >= modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Furniture[i].X && x <= modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Furniture[i].X + Types.Item[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureWidth - 1)
                                {
                                    if (y <= modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y && y >= modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Furniture[i].Y - Types.Item[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum].FurnitureHeight + 1)
                                    {
                                        // Found an Item, get the index and lets pick it up!
                                        x = S_Players.FindOpenInvSlot(index, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum);
                                        if (x > 0)
                                        {
                                            S_Players.GiveInvItem(index, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Furniture[i].ItemNum, 0, true);
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.FurnitureCount = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.FurnitureCount - 1;
                                            var loopTo2 = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.FurnitureCount + 1;
                                            for (x = i + 1; x <= loopTo2; x++)
                                                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Furniture[x - 1] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Furniture[x];
                                            var oldFurniture = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Furniture;
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Furniture = new FurnitureRec[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.FurnitureCount + 1];
                                            if (oldFurniture != null)
                                                Array.Copy(oldFurniture, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Furniture, Math.Min(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.FurnitureCount + 1, oldFurniture.Length));
                                            S_Housing.SendFurnitureToHouse(index);
                                            return;
                                        }
                                        else
                                            S_NetworkSend.PlayerMsg(index, "No inventory space available!", (int)Enums.ColorType.BrightRed);
                                        return;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (TargetFound == 0)
                S_NetworkSend.SendTarget(index, 0, 0);

            buffer.Dispose();
        }

        public static void Packet_Skills(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CSkills");

            S_NetworkSend.SendPlayerSkills(index);
        }

        public static void Packet_Cast(int index, ref byte[] data)
        {
            int n;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CCast");

            // Skill slot
            n = buffer.ReadInt32();
            buffer.Dispose();

            // set the skill buffer before castin
            S_Players.BufferSkill(index, n);

            buffer.Dispose();
        }

        public static void Packet_QuitGame(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CQuit");

            S_NetworkSend.SendLeftGame(index);
            S_Players.LeftGame(index);
        }

        public static void Packet_SwapInvSlots(int index, ref byte[] data)
        {
            int oldSlot;
            int newSlot;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CSwapInvSlots");

            if ((byte)modTypes.TempPlayer[index].InTrade > 0 || modTypes.TempPlayer[index].InBank || Convert.ToBoolean(modTypes.TempPlayer[index].InShop))
                return;

            // Old Slot
            oldSlot = buffer.ReadInt32();
            newSlot = buffer.ReadInt32();
            buffer.Dispose();

            S_Players.PlayerSwitchInvSlots(index, oldSlot, newSlot);

            buffer.Dispose();
        }

        public static void Packet_CheckPing(int index, ref byte[] data)
        {
            ByteStream buffer;
            buffer = new ByteStream(4);
            buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SSendPing));
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: SSendPing");

            buffer.Dispose();
        }

        public static void Packet_Unequip(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CUnequip");

            S_Players.PlayerUnequipItem(index, buffer.ReadInt32());

            buffer.Dispose();
        }

        public static void Packet_RequestPlayerData(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CRequestPlayerData");

            S_NetworkSend.SendPlayerData(index);
        }

        public static void Packet_RequestNpcs(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CRequestNPCS");

            S_Npc.SendNpcs(index);
        }

        public static void Packet_SpawnItem(int index, ref byte[] data)
        {
            int tmpItem;
            int tmpAmount;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CSpawnItem");

            // item
            tmpItem = buffer.ReadInt32();
            tmpAmount = buffer.ReadInt32();

            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Creator)
                return;

            S_Items.SpawnItem(tmpItem, tmpAmount, S_Players.GetPlayerMap(index), S_Players.GetPlayerX(index), S_Players.GetPlayerY(index));
            buffer.Dispose();
        }

        public static void Packet_TrainStat(int index, ref byte[] data)
        {
            int tmpstat;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CTrainStat");

            // check points
            if (S_Players.GetPlayerPOINTS(index) == 0)
                return;

            // stat
            tmpstat = buffer.ReadInt32();

            // increment stat
            S_Players.SetPlayerStat(index, (StatType)tmpstat, S_Players.GetPlayerRawStat(index, (StatType)tmpstat) + 1);

            // decrement points
            S_Players.SetPlayerPOINTS(index, S_Players.GetPlayerPOINTS(index) - 1);

            // send player new data
            S_NetworkSend.SendPlayerData(index);
            buffer.Dispose();
        }

        public static void Packet_RequestSkills(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CRequestSkills");

            S_NetworkSend.SendSkills(index);
        }

        public static void Packet_RequestShops(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CRequestShops");

            S_NetworkSend.SendShops(index);
        }

        public static void Packet_RequestLevelUp(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CRequestLevelUp");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Creator)
                return;

            S_Players.SetPlayerExp(index, S_Players.GetPlayerNextLevel(index));
            S_Players.CheckPlayerLevelUp(index);
        }

        public static void Packet_ForgetSkill(int index, ref byte[] data)
        {
            int skillslot;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CForgetSkill");

            skillslot = buffer.ReadInt32();

            // Check for subscript out of range
            if (skillslot < 1 || skillslot > Constants.MAX_PLAYER_SKILLS)
                return;

            // dont let them forget a skill which is in CD
            if (modTypes.TempPlayer[index].SkillCd[skillslot] > 0)
            {
                S_NetworkSend.PlayerMsg(index, "Cannot forget a skill which is cooling down!", (int)Enums.ColorType.BrightRed);
                return;
            }

            // dont let them forget a skill which is buffered
            if (modTypes.TempPlayer[index].SkillBuffer == skillslot)
            {
                S_NetworkSend.PlayerMsg(index, "Cannot forget a skill which you are casting!", (int)Enums.ColorType.BrightRed);
                return;
            }

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Skill[skillslot] = 0;
            S_NetworkSend.SendPlayerSkills(index);

            buffer.Dispose();
        }

        public static void Packet_CloseShop(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CCloseShop");

            modTypes.TempPlayer[index].InShop = 0;
        }

        public static void Packet_BuyItem(int index, ref byte[] data)
        {
            int shopslot;
            int shopnum;
            int itemamount;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CBuyItem");

            shopslot = buffer.ReadInt32();

            // not in shop, exit out
            shopnum = modTypes.TempPlayer[index].InShop;
            if (shopnum < 1 || shopnum > Constants.MAX_SHOPS)
                return;

            {
                // check trade exists
                if (Types.Shop[shopnum].TradeItem[shopslot].Item < 1)
                    return;

                // check has the cost item
                itemamount = S_Players.HasItem(index, Types.Shop[shopnum].TradeItem[shopslot].CostItem);
                if (itemamount == 0 || itemamount < Types.Shop[shopnum].TradeItem[shopslot].CostValue)
                {
                    S_NetworkSend.PlayerMsg(index, "You do not have enough to buy this item.", (int)Enums.ColorType.BrightRed);
                    S_NetworkSend.ResetShopAction(index);
                    return;
                }

                // it's fine, let's go ahead
                S_Players.TakeInvItem(index, Types.Shop[shopnum].TradeItem[shopslot].CostItem, Types.Shop[shopnum].TradeItem[shopslot].CostValue);
                S_Players.GiveInvItem(index, Types.Shop[shopnum].TradeItem[shopslot].Item, Types.Shop[shopnum].TradeItem[shopslot].ItemValue);
            }

            // send confirmation message & reset their shop action
            S_NetworkSend.PlayerMsg(index, "Trade successful.", (int)Enums.ColorType.BrightGreen);
            S_NetworkSend.ResetShopAction(index);

            buffer.Dispose();
        }

        public static void Packet_SellItem(int index, ref byte[] data)
        {
            int invSlot;
            int itemNum;
            int price;
            double multiplier;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CSellItem");

            invSlot = buffer.ReadInt32();

            // if invalid, exit out
            if (invSlot < 1 || invSlot > Constants.MAX_INV)
                return;

            // has item?
            if (S_Players.GetPlayerInvItemNum(index, invSlot) < 1 || S_Players.GetPlayerInvItemNum(index, invSlot) > Constants.MAX_ITEMS)
                return;

            // seems to be valid
            itemNum = S_Players.GetPlayerInvItemNum(index, invSlot);

            // work out price
            multiplier = Types.Shop[modTypes.TempPlayer[index].InShop].BuyRate / (double)100;
            price = (int)(Types.Item[itemNum].Price * multiplier);

            // item has cost?
            if (price <= 0)
            {
                S_NetworkSend.PlayerMsg(index, "The shop doesn't want that item.", (int)Enums.ColorType.Yellow);
                S_NetworkSend.ResetShopAction(index);
                return;
            }

            // take item and give gold
            S_Players.TakeInvItem(index, itemNum, 1);
            S_Players.GiveInvItem(index, 1, price);

            // send confirmation message & reset their shop action
            S_NetworkSend.PlayerMsg(index, "Sold the " + Microsoft.VisualBasic.Strings.Trim(Types.Item[S_Players.GetPlayerInvItemNum(index, invSlot)].Name) + " !", (int)Enums.ColorType.BrightGreen);
            S_NetworkSend.ResetShopAction(index);

            buffer.Dispose();
        }

        public static void Packet_ChangeBankSlots(int index, ref byte[] data)
        {
            int oldslot;
            int newslot;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CChangeBankSlots");

            oldslot = buffer.ReadInt32();
            newslot = buffer.ReadInt32();

            S_Players.PlayerSwitchBankSlots(index, oldslot, newslot);

            buffer.Dispose();
        }

        public static void Packet_DepositItem(int index, ref byte[] data)
        {
            int invslot;
            int amount;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CDepositItem");

            invslot = buffer.ReadInt32();
            amount = buffer.ReadInt32();

            S_Players.GiveBankItem(index, invslot, amount);

            buffer.Dispose();
        }

        public static void Packet_WithdrawItem(int index, ref byte[] data)
        {
            int bankslot;
            int amount;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CWithdrawItem");

            bankslot = buffer.ReadInt32();
            amount = buffer.ReadInt32();

            S_Players.TakeBankItem(index, bankslot, amount);

            buffer.Dispose();
        }

        public static void Packet_CloseBank(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CCloseBank");

            modDatabase.SaveBank(index);
            modDatabase.SavePlayer(index);

            modTypes.TempPlayer[index].InBank = false;
        }

        public static void Packet_AdminWarp(int index, ref byte[] data)
        {
            int x;
            int y;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CAdminWarp");

            x = buffer.ReadInt32();
            y = buffer.ReadInt32();

            if (S_Players.GetPlayerAccess(index) >= (byte)Enums.AdminType.Mapper)
            {
                // Set the  Information
                S_Players.SetPlayerX(index, x);
                S_Players.SetPlayerY(index, y);

                // send the stuff
                S_NetworkSend.SendPlayerXY(index);
            }

            buffer.Dispose();
        }

        public static void Packet_TradeInvite(int index, ref byte[] data)
        {
            string Name;
            int tradetarget;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CTradeInvite");

            Name = buffer.ReadString();

            buffer.Dispose();

            // Check for a player

            tradetarget = S_GameLogic.FindPlayer(Name);

            // make sure we don't error
            if (tradetarget <= 0 || tradetarget > Constants.MAX_PLAYERS)
                return;

            // can't trade with yourself..
            if (tradetarget == index)
            {
                S_NetworkSend.PlayerMsg(index, "You can't trade with yourself.", (int)Enums.ColorType.BrightRed);
                return;
            }

            // send the trade request
            modTypes.TempPlayer[index].TradeRequest = tradetarget;
            modTypes.TempPlayer[tradetarget].TradeRequest = index;

            S_NetworkSend.PlayerMsg(tradetarget, Microsoft.VisualBasic.Strings.Trim(S_Players.GetPlayerName(index)) + " has invited you to trade.", (int)Enums.ColorType.Yellow);
            S_NetworkSend.PlayerMsg(index, "You have invited " + Microsoft.VisualBasic.Strings.Trim(S_Players.GetPlayerName(tradetarget)) + " to trade.", (int)Enums.ColorType.BrightGreen);
            S_NetworkSend.SendClearTradeTimer(index);

            S_NetworkSend.SendTradeInvite(tradetarget, index);
        }

        public static void Packet_TradeInviteAccept(int index, ref byte[] data)
        {
            int tradetarget;
            byte status;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CTradeInviteAccept");

            status = (byte)buffer.ReadInt32();

            buffer.Dispose();

            if (status == 0)
                return;

            tradetarget = modTypes.TempPlayer[index].TradeRequest;

            // Let them trade!
            if (modTypes.TempPlayer[tradetarget].TradeRequest == index)
            {
                // let them know they're trading
                S_NetworkSend.PlayerMsg(index, "You have accepted " + Microsoft.VisualBasic.Strings.Trim(S_Players.GetPlayerName(tradetarget)) + "'s trade request.", (int)Enums.ColorType.Yellow);
                S_NetworkSend.PlayerMsg(tradetarget, Microsoft.VisualBasic.Strings.Trim(S_Players.GetPlayerName(index)) + " has accepted your trade request.", (int)Enums.ColorType.BrightGreen);
                // clear the trade timeout clientside
                S_NetworkSend.SendClearTradeTimer(index);

                // clear the tradeRequest server-side
                modTypes.TempPlayer[index].TradeRequest = 0;
                modTypes.TempPlayer[tradetarget].TradeRequest = 0;

                // set that they're trading with each other
                modTypes.TempPlayer[index].InTrade = tradetarget;
                modTypes.TempPlayer[tradetarget].InTrade = index;

                // clear out their trade offers
                modTypes.TempPlayer[index].TradeOffer = new PlayerInvRec[Constants.MAX_INV + 1];
                modTypes.TempPlayer[tradetarget].TradeOffer = new PlayerInvRec[Constants.MAX_INV + 1];
                for (var i = 1; i <= Constants.MAX_INV; i++)
                {
                    modTypes.TempPlayer[index].TradeOffer[i].Num = 0;
                    modTypes.TempPlayer[index].TradeOffer[i].Value = 0;
                    modTypes.TempPlayer[tradetarget].TradeOffer[i].Num = 0;
                    modTypes.TempPlayer[tradetarget].TradeOffer[i].Value = 0;
                }
                // Used to init the trade window clientside
                S_NetworkSend.SendTrade(index, tradetarget);
                S_NetworkSend.SendTrade(tradetarget, index);

                // Send the offer data - Used to clear their client
                S_NetworkSend.SendTradeUpdate(index, 0);
                S_NetworkSend.SendTradeUpdate(index, 1);
                S_NetworkSend.SendTradeUpdate(tradetarget, 0);
                S_NetworkSend.SendTradeUpdate(tradetarget, 1);
                return;
            }
        }

        public static void Packet_AcceptTrade(int index, ref byte[] data)
        {
            int itemNum;
            int tradeTarget;
            int i;
            Types.PlayerInvRec[] tmpTradeItem = new Types.PlayerInvRec[Constants.MAX_INV + 1];
            Types.PlayerInvRec[] tmpTradeItem2 = new Types.PlayerInvRec[Constants.MAX_INV + 1];

            S_General.AddDebug("Recieved CMSG: CAcceptTrade");

            modTypes.TempPlayer[index].AcceptTrade = true;

            tradeTarget = modTypes.TempPlayer[index].InTrade;

            // if not both of them accept, then exit
            if (!modTypes.TempPlayer[tradeTarget].AcceptTrade)
            {
                S_NetworkSend.SendTradeStatus(index, 2);
                S_NetworkSend.SendTradeStatus(tradeTarget, 1);
                return;
            }

            // take their items
            for (i = 1; i <= Constants.MAX_INV; i++)
            {
                // player
                if (modTypes.TempPlayer[index].TradeOffer[i].Num > 0)
                {
                    itemNum = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Inv[modTypes.TempPlayer[index].TradeOffer[i].Num].Num;
                    if (itemNum > 0)
                    {
                        // store temp
                        tmpTradeItem[i].Num = itemNum;
                        tmpTradeItem[i].Value = modTypes.TempPlayer[index].TradeOffer[i].Value;
                        // take item
                        S_Players.TakeInvSlot(index, modTypes.TempPlayer[index].TradeOffer[i].Num, tmpTradeItem[i].Value);
                    }
                }
                // target
                if (modTypes.TempPlayer[tradeTarget].TradeOffer[i].Num > 0)
                {
                    itemNum = S_Players.GetPlayerInvItemNum(tradeTarget, modTypes.TempPlayer[tradeTarget].TradeOffer[i].Num);
                    if (itemNum > 0)
                    {
                        // store temp
                        tmpTradeItem2[i].Num = itemNum;
                        tmpTradeItem2[i].Value = modTypes.TempPlayer[tradeTarget].TradeOffer[i].Value;
                        // take item
                        S_Players.TakeInvSlot(tradeTarget, modTypes.TempPlayer[tradeTarget].TradeOffer[i].Num, tmpTradeItem2[i].Value);
                    }
                }
            }

            // taken all items. now they can't not get items because of no inventory space.
            for (i = 1; i <= Constants.MAX_INV; i++)
            {
                // player
                if (tmpTradeItem2[i].Num > 0)
                    // give away!
                    S_Players.GiveInvItem(index, tmpTradeItem2[i].Num, tmpTradeItem2[i].Value, false);
                // target
                if (tmpTradeItem[i].Num > 0)
                    // give away!
                    S_Players.GiveInvItem(tradeTarget, tmpTradeItem[i].Num, tmpTradeItem[i].Value, false);
            }

            S_NetworkSend.SendInventory(index);
            S_NetworkSend.SendInventory(tradeTarget);

            // they now have all the items. Clear out values + let them out of the trade.
            for (i = 1; i <= Constants.MAX_INV; i++)
            {
                modTypes.TempPlayer[index].TradeOffer[i].Num = 0;
                modTypes.TempPlayer[index].TradeOffer[i].Value = 0;
                modTypes.TempPlayer[tradeTarget].TradeOffer[i].Num = 0;
                modTypes.TempPlayer[tradeTarget].TradeOffer[i].Value = 0;
            }

            modTypes.TempPlayer[index].InTrade = 0;
            modTypes.TempPlayer[tradeTarget].InTrade = 0;

            S_NetworkSend.PlayerMsg(index, "Trade completed.", (int)Enums.ColorType.BrightGreen);
            S_NetworkSend.PlayerMsg(tradeTarget, "Trade completed.", (int)Enums.ColorType.BrightGreen);

            S_NetworkSend.SendCloseTrade(index);
            S_NetworkSend.SendCloseTrade(tradeTarget);
        }

        public static void Packet_DeclineTrade(int index, ref byte[] data)
        {
            int tradeTarget;

            S_General.AddDebug("Recieved CMSG: CDeclineTrade");

            tradeTarget = modTypes.TempPlayer[index].InTrade;

            for (var i = 1; i <= Constants.MAX_INV; i++)
            {
                modTypes.TempPlayer[index].TradeOffer[i].Num = 0;
                modTypes.TempPlayer[index].TradeOffer[i].Value = 0;
                modTypes.TempPlayer[tradeTarget].TradeOffer[i].Num = 0;
                modTypes.TempPlayer[tradeTarget].TradeOffer[i].Value = 0;
            }

            modTypes.TempPlayer[index].InTrade = 0;
            modTypes.TempPlayer[tradeTarget].InTrade = 0;

            S_NetworkSend.PlayerMsg(index, "You declined the trade.", (int)Enums.ColorType.Yellow);
            S_NetworkSend.PlayerMsg(tradeTarget, S_Players.GetPlayerName(index) + " has declined the trade.", (int)Enums.ColorType.BrightRed);

            S_NetworkSend.SendCloseTrade(index);
            S_NetworkSend.SendCloseTrade(tradeTarget);
        }

        public static void Packet_TradeItem(int index, ref byte[] data)
        {
            int itemnum = 0;
            int invslot = 0;
            int amount = 0;
            int emptyslot = 0;
            int i = 0;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CTradeItem");

            invslot = buffer.ReadInt32();
            amount = buffer.ReadInt32();

            buffer.Dispose();

            if (invslot <= 0 || invslot > Constants.MAX_INV)
                return;

            itemnum = S_Players.GetPlayerInvItemNum(index, invslot);

            if (itemnum <= 0 || itemnum > Constants.MAX_ITEMS)
                return;

            // make sure they have the amount they offer
            if (amount < 0 || amount > S_Players.GetPlayerInvItemValue(index, invslot))
                return;

            if (Types.Item[itemnum].Type == (byte)Enums.ItemType.Currency || Types.Item[itemnum].Stackable == 1)
            {

                // check if already offering same currency item
                for (i = 1; i <= Constants.MAX_INV; i++)
                {
                    if (modTypes.TempPlayer[index].TradeOffer[i].Num == invslot)
                    {
                        // add amount
                        modTypes.TempPlayer[index].TradeOffer[i].Value = modTypes.TempPlayer[index].TradeOffer[i].Value + amount;

                        // clamp to limits
                        if (modTypes.TempPlayer[index].TradeOffer[i].Value > S_Players.GetPlayerInvItemValue(index, invslot))
                            modTypes.TempPlayer[index].TradeOffer[i].Value = S_Players.GetPlayerInvItemValue(index, invslot);

                        // cancel any trade agreement
                        modTypes.TempPlayer[index].AcceptTrade = false;
                        modTypes.TempPlayer[modTypes.TempPlayer[index].InTrade].AcceptTrade = false;

                        S_NetworkSend.SendTradeStatus(index, 0);
                        S_NetworkSend.SendTradeStatus(modTypes.TempPlayer[index].InTrade, 0);

                        S_NetworkSend.SendTradeUpdate(index, 0);
                        S_NetworkSend.SendTradeUpdate(modTypes.TempPlayer[index].InTrade, 1);
                        // exit early
                        return;
                    }
                }
            }
            else
                // make sure they're not already offering it
                for (i = 1; i <= Constants.MAX_INV; i++)
                {
                    if (modTypes.TempPlayer[index].TradeOffer[i].Num == invslot)
                    {
                        S_NetworkSend.PlayerMsg(index, "You've already offered this item.", (int)Enums.ColorType.BrightRed);
                        return;
                    }
                }

            // not already offering - find earliest empty slot
            for (i = 1; i <= Constants.MAX_INV; i++)
            {
                if (modTypes.TempPlayer[index].TradeOffer[i].Num == 0)
                {
                    emptyslot = i;
                    break;
                }
            }
            modTypes.TempPlayer[index].TradeOffer[emptyslot].Num = invslot;
            modTypes.TempPlayer[index].TradeOffer[emptyslot].Value = amount;

            // cancel any trade agreement and send new data
            modTypes.TempPlayer[index].AcceptTrade = false;
            modTypes.TempPlayer[modTypes.TempPlayer[index].InTrade].AcceptTrade = false;

            S_NetworkSend.SendTradeStatus(index, 0);
            S_NetworkSend.SendTradeStatus(modTypes.TempPlayer[index].InTrade, 0);

            S_NetworkSend.SendTradeUpdate(index, 0);
            S_NetworkSend.SendTradeUpdate(modTypes.TempPlayer[index].InTrade, 1);
        }

        public static void Packet_UntradeItem(int index, ref byte[] data)
        {
            int tradeslot;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CUntradeItem");

            tradeslot = buffer.ReadInt32();

            buffer.Dispose();

            if (tradeslot <= 0 || tradeslot > Constants.MAX_INV)
                return;
            if (modTypes.TempPlayer[index].TradeOffer[tradeslot].Num <= 0)
                return;

            modTypes.TempPlayer[index].TradeOffer[tradeslot].Num = 0;
            modTypes.TempPlayer[index].TradeOffer[tradeslot].Value = 0;

            if (modTypes.TempPlayer[index].AcceptTrade)
                modTypes.TempPlayer[index].AcceptTrade = false;
            if (modTypes.TempPlayer[modTypes.TempPlayer[index].InTrade].AcceptTrade)
                modTypes.TempPlayer[modTypes.TempPlayer[index].InTrade].AcceptTrade = false;

            S_NetworkSend.SendTradeStatus(index, 0);
            S_NetworkSend.SendTradeStatus(modTypes.TempPlayer[index].InTrade, 0);

            S_NetworkSend.SendTradeUpdate(index, 0);
            S_NetworkSend.SendTradeUpdate(modTypes.TempPlayer[index].InTrade, 1);
        }

        public static void HackingAttempt(int index, string Reason)
        {
            if (index > 0 && S_NetworkConfig.IsPlaying(index))
            {
                S_NetworkSend.GlobalMsg(S_Players.GetPlayerLogin(index) + "/" + S_Players.GetPlayerName(index) + " has been booted for (" + Reason + ")");

                S_NetworkSend.AlertMsg(index, "You have lost your connection with " + modTypes.Options.GameName + ".");
            }
        }

        // Mapreport
        public static void Packet_MapReport(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CMapReport");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;

            S_NetworkSend.SendMapReport(index);
        }

        public static void Packet_Admin(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CAdmin");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;

            S_NetworkSend.SendAdminPanel(index);
        }

        public static void Packet_SetHotBarSlot(int index, ref byte[] data)
        {
            int slot;
            int skill;
            byte type;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CSetHotbarSlot");

            slot = buffer.ReadInt32();
            skill = buffer.ReadInt32();
            type = (byte)buffer.ReadInt32();

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Hotbar[slot].Slot = skill;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Hotbar[slot].SlotType = type;

            S_NetworkSend.SendHotbar(index);

            buffer.Dispose();
        }

        public static void Packet_DeleteHotBarSlot(int index, ref byte[] data)
        {
            int slot;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CDeleteHotbarSlot");

            slot = buffer.ReadInt32();

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Hotbar[slot].Slot = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Hotbar[slot].SlotType = 0;

            S_NetworkSend.SendHotbar(index);

            buffer.Dispose();
        }

        public static void Packet_UseHotBarSlot(int index, ref byte[] data)
        {
            int slot;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CUseHotbarSlot");

            slot = buffer.ReadInt32();
            buffer.Dispose();

            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Hotbar[slot].Slot > 0)
            {
                if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Hotbar[slot].SlotType == 1)
                    S_Players.BufferSkill(index, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Hotbar[slot].Slot);
                else if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Hotbar[slot].SlotType == 2)
                    S_Players.UseItem(index, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Hotbar[slot].Slot);
            }

            S_NetworkSend.SendHotbar(index);
        }

        public static void Packet_RequestClasses(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CRequestClasses");

            S_NetworkSend.SendClasses(index);
        }

        public static void Packet_RequestEditClasses(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved EMSG: RequestEditClasses");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Developer)
                return;

            S_NetworkSend.SendClasses(index);

            S_NetworkSend.SendClassEditor(index);
        }

        public static void Packet_SaveClasses(int index, ref byte[] data)
        {
            int i;
            int z;
            int x;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved EMSG: SaveClasses");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Developer)
                return;

            // Max classes
            S_Globals.Max_Classes = (byte)buffer.ReadInt32();
            Types.Classes = new ClassRec[S_Globals.Max_Classes + 1];
            var loopTo = S_Globals.Max_Classes;
            for (i = 0; i <= loopTo; i++)
                Types.Classes[i].Stat = new byte[7];
            var loopTo1 = S_Globals.Max_Classes;
            for (i = 1; i <= loopTo1; i++)
            {
                {
                    Types.Classes[i].Name = buffer.ReadString();
                    Types.Classes[i].Desc = buffer.ReadString();

                    // get array size
                    z = buffer.ReadInt32();

                    // redim array
                    Types.Classes[i].MaleSprite = new int[z + 1];
                    var loopTo2 = z;
                    // loop-receive data
                    for (x = 0; x <= loopTo2; x++)
                        Types.Classes[i].MaleSprite[x] = buffer.ReadInt32();

                    // get array size
                    z = buffer.ReadInt32();
                    // redim array
                    Types.Classes[i].FemaleSprite = new int[z + 1];
                    var loopTo3 = z;
                    // loop-receive data
                    for (x = 0; x <= loopTo3; x++)
                        Types.Classes[i].FemaleSprite[x] = buffer.ReadInt32();

                    Types.Classes[i].Stat[(int)Enums.StatType.Strength] = (byte)buffer.ReadInt32();
                    Types.Classes[i].Stat[(int)Enums.StatType.Endurance] = (byte)buffer.ReadInt32();
                    Types.Classes[i].Stat[(int)Enums.StatType.Vitality] = (byte)buffer.ReadInt32();
                    Types.Classes[i].Stat[(int)Enums.StatType.Intelligence] = (byte)buffer.ReadInt32();
                    Types.Classes[i].Stat[(int)Enums.StatType.Luck] = (byte)buffer.ReadInt32();
                    Types.Classes[i].Stat[(int)Enums.StatType.Spirit] = (byte)buffer.ReadInt32();

                    Types.Classes[i].StartItem = new int[6];
                    Types.Classes[i].StartValue = new int[6];
                    for (var q = 1; q <= 5; q++)
                    {
                        Types.Classes[i].StartItem[q] = buffer.ReadInt32();
                        Types.Classes[i].StartValue[q] = buffer.ReadInt32();
                    }

                    Types.Classes[i].StartMap = buffer.ReadInt32();
                    Types.Classes[i].StartX = (byte)buffer.ReadInt32();
                    Types.Classes[i].StartY = (byte)buffer.ReadInt32();

                    Types.Classes[i].BaseExp = buffer.ReadInt32();
                }
            }

            buffer.Dispose();

            modDatabase.SaveClasses();

            modDatabase.LoadClasses();

            S_NetworkSend.SendClassesToAll();
        }

        private static void Packet_EditorLogin(int index, ref byte[] data)
        {
            string Name;
            string Password;
            string Version;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved EMSG: EditorLogin");

            if (!S_NetworkConfig.IsLoggedIn(index))
            {

                // Get the data
                Name = S_Globals.EKeyPair.DecryptString(buffer.ReadString());
                Password = S_Globals.EKeyPair.DecryptString(buffer.ReadString());
                Version = S_Globals.EKeyPair.DecryptString(buffer.ReadString());

                // Check versions
                if (Version != Application.ProductVersion)
                {
                    S_NetworkSend.AlertMsg(index, "Version outdated, please visit " + modTypes.Options.Website);
                    return;
                }

                if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Name)) < 3 || Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Password)) < 3)
                {
                    S_NetworkSend.AlertMsg(index, "Your name and password must be at least three characters in length");
                    return;
                }

                if (!modDatabase.AccountExist(Name))
                {
                    S_NetworkSend.AlertMsg(index, "That account name does not exist.");
                    return;
                }

                if (!modDatabase.PasswordOK(Name, Password))
                {
                    S_NetworkSend.AlertMsg(index, "Incorrect password.");
                    return;
                }

                if (S_NetworkConfig.IsMultiAccounts(Name))
                {
                    S_NetworkSend.AlertMsg(index, "Multiple account logins is not authorized.");
                    return;
                }

                // Load the player
                modDatabase.LoadPlayer(index, Name);

                if (S_Players.GetPlayerAccess(index) > (byte)Enums.AdminType.Player)
                {
                    S_NetworkSend.SendEditorLoadOk(index);
                    // SendMapData(index, 1, True)
                    S_NetworkSend.SendGameData(index);
                    S_NetworkSend.SendMapNames(index);
                    S_Projectiles.SendProjectiles(index);
                    S_Quest.SendQuests(index);
                    modCrafting.SendRecipes(index);
                    S_Housing.SendHouseConfigs(index);
                    S_Pets.SendPets(index);
                }
                else
                {
                    S_NetworkSend.AlertMsg(index, "not authorized.");
                    return;
                }

                // Show the player up on the socket status
                modDatabase.Addlog(S_Players.GetPlayerLogin(index) + " has logged in from " + S_NetworkConfig.Socket.ClientIp(index) + ".", S_Constants.PLAYER_LOG);

                Console.WriteLine(S_Players.GetPlayerLogin(index) + " has logged in from " + S_NetworkConfig.Socket.ClientIp(index) + ".");
            }

            buffer.Dispose();
        }

        private static void Packet_EditorRequestMap(int index, ref byte[] data)
        {
            int mapNum;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved EMSG: EditorRequestMap");

            mapNum = buffer.ReadInt32();

            buffer.Dispose();

            if (S_Players.GetPlayerAccess(index) > (byte)Enums.AdminType.Player)
            {
                S_NetworkSend.SendMapData(index, mapNum, true);
                S_NetworkSend.SendMapNames(index);

                buffer = new ByteStream(4);
                buffer.WriteInt32((int)Packets.ServerPackets.SEditMap);
                S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

                S_General.AddDebug("Sent SMSG: SEditMap");

                buffer.Dispose();
            }
            else
                S_NetworkSend.AlertMsg(index, "Not Allowed!");
        }

        public static void Packet_EditorMapData(int index, ref byte[] data)
        {
            int i;
            int mapNum;
            int x;
            int y;

            S_General.AddDebug("Recieved EMSG: EditorSaveMap");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Mapper)
                return;

            ByteStream buffer = new ByteStream(Compression.DecompressBytes(data));

            S_Globals.Gettingmap = true;

            mapNum = buffer.ReadInt32();

            i = modTypes.Map[mapNum].Revision + 1;
            modDatabase.ClearMap(mapNum);

            modTypes.Map[mapNum].Name = buffer.ReadString();
            modTypes.Map[mapNum].Music = buffer.ReadString();
            modTypes.Map[mapNum].Revision = i;
            modTypes.Map[mapNum].Moral = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].Tileset = buffer.ReadInt32();
            modTypes.Map[mapNum].Up = buffer.ReadInt32();
            modTypes.Map[mapNum].Down = buffer.ReadInt32();
            modTypes.Map[mapNum].Left = buffer.ReadInt32();
            modTypes.Map[mapNum].Right = buffer.ReadInt32();
            modTypes.Map[mapNum].BootMap = buffer.ReadInt32();
            modTypes.Map[mapNum].BootX = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].BootY = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].MaxX = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].MaxY = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].WeatherType = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].Fogindex = buffer.ReadInt32();
            modTypes.Map[mapNum].WeatherIntensity = buffer.ReadInt32();
            modTypes.Map[mapNum].FogAlpha = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].FogSpeed = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].HasMapTint = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].MapTintR = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].MapTintG = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].MapTintB = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].MapTintA = (byte)buffer.ReadInt32();

            modTypes.Map[mapNum].Instanced = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].Panorama = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].Parallax = (byte)buffer.ReadInt32();
            modTypes.Map[mapNum].Brightness = (byte)buffer.ReadInt32();

            modTypes.Map[mapNum].Tile = new TileRec[modTypes.Map[mapNum].MaxX + 1, modTypes.Map[mapNum].MaxY + 1];

            for (x = 1; x <= Constants.MAX_MAP_NPCS; x++)
            {
                modDatabase.ClearMapNpc(x, mapNum);
                modTypes.Map[mapNum].Npc[x] = buffer.ReadInt32();
            }

            {
                var loopTo = modTypes.Map[mapNum].MaxX;
                for (int xx = 0; xx <= loopTo; xx++)
                {
                    var loopTo1 = modTypes.Map[mapNum].MaxY;
                    for (y = 0; y <= loopTo1; y++)
                    {
                        modTypes.Map[mapNum].Tile[xx, y].Data1 = buffer.ReadInt32();
                        modTypes.Map[mapNum].Tile[xx, y].Data2 = buffer.ReadInt32();
                        modTypes.Map[mapNum].Tile[xx, y].Data3 = buffer.ReadInt32();
                        modTypes.Map[mapNum].Tile[xx, y].DirBlock = (byte)buffer.ReadInt32();
                        modTypes.Map[mapNum].Tile[xx, y].Layer = new TileDataRec[6];
                        for (i = 0; i <= (byte)Enums.LayerType.Count - 1; i++)
                        {
                            modTypes.Map[mapNum].Tile[xx, y].Layer[i].Tileset = (byte)buffer.ReadInt32();
                            modTypes.Map[mapNum].Tile[xx, y].Layer[i].X = (byte)buffer.ReadInt32();
                            modTypes.Map[mapNum].Tile[xx, y].Layer[i].Y = (byte)buffer.ReadInt32();
                            modTypes.Map[mapNum].Tile[xx, y].Layer[i].AutoTile = (byte)buffer.ReadInt32();
                        }
                        modTypes.Map[mapNum].Tile[xx, y].Type = (byte)buffer.ReadInt32();
                    }
                }
            }

            // Event Data!
            modTypes.Map[mapNum].EventCount = buffer.ReadInt32();

            if (modTypes.Map[mapNum].EventCount > 0)
            {
                modTypes.Map[mapNum].Events = new EventStruct[modTypes.Map[mapNum].EventCount + 1];
                var loopTo2 = modTypes.Map[mapNum].EventCount;
                for (i = 1; i <= loopTo2; i++)
                {
                    {
                        modTypes.Map[mapNum].Events[i].Name = buffer.ReadString();
                        modTypes.Map[mapNum].Events[i].Globals = (byte)buffer.ReadInt32();
                        modTypes.Map[mapNum].Events[i].X = buffer.ReadInt32();
                        modTypes.Map[mapNum].Events[i].Y = buffer.ReadInt32();
                        modTypes.Map[mapNum].Events[i].PageCount = buffer.ReadInt32();
                    }
                    if (modTypes.Map[mapNum].Events[i].PageCount > 0)
                    {
                        modTypes.Map[mapNum].Events[i].Pages = new EventPageStruct[modTypes.Map[mapNum].Events[i].PageCount + 1];
                        modTypes.TempPlayer[i].EventMap.EventPages = new MapEventStruct[modTypes.Map[mapNum].Events[i].PageCount + 1];
                        var loopTo3 = modTypes.Map[mapNum].Events[i].PageCount;
                        for (x = 1; x <= loopTo3; x++)
                        {
                            {
                                //var modTypes.Map[mapNum].Events[i].Pages[x] = modTypes.Map[mapNum].Events[i].Pages[x];
                                modTypes.Map[mapNum].Events[i].Pages[x].ChkVariable = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].Variableindex = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].VariableCondition = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].VariableCompare = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].ChkSwitch = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].Switchindex = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].SwitchCompare = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].ChkHasItem = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].HasItemindex = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].HasItemAmount = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].ChkSelfSwitch = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].SelfSwitchindex = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].SelfSwitchCompare = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicType = (byte)buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].Graphic = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicX = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicY = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicX2 = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicY2 = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].MoveType = (byte)buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].MoveSpeed = (byte)buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].MoveFreq = (byte)buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].IgnoreMoveRoute = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].RepeatMoveRoute = buffer.ReadInt32();

                                if (modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount > 0)
                                {
                                    modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute = new MoveRouteStruct[modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount + 1];
                                    var loopTo4 = modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount;
                                    for (y = 1; y <= loopTo4; y++)
                                    {
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Index = buffer.ReadInt32();
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data1 = buffer.ReadInt32();
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data2 = buffer.ReadInt32();
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data3 = buffer.ReadInt32();
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data4 = buffer.ReadInt32();
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data5 = buffer.ReadInt32();
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data6 = buffer.ReadInt32();
                                    }
                                }

                                modTypes.Map[mapNum].Events[i].Pages[x].WalkAnim = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].DirFix = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].WalkThrough = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].ShowName = buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].Trigger = (byte)buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].Position = (byte)buffer.ReadInt32();
                                modTypes.Map[mapNum].Events[i].Pages[x].QuestNum = buffer.ReadInt32();

                                modTypes.Map[mapNum].Events[i].Pages[x].ChkPlayerGender = buffer.ReadInt32();
                            }

                            if (modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount > 0)
                            {
                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList = new CommandListStruct[modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount + 1];
                                var loopTo5 = modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount;
                                for (y = 1; y <= loopTo5; y++)
                                {
                                    modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount = buffer.ReadInt32();
                                    modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].ParentList = buffer.ReadInt32();
                                    if (modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount > 0)
                                    {
                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands = new EventCommandStruct[modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount + 1];
                                        var loopTo6 = modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount;
                                        for (var z = 1; z <= loopTo6; z++)
                                        {
                                            {
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Index = (byte)buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text1 = buffer.ReadString();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text2 = buffer.ReadString();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text3 = buffer.ReadString();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text4 = buffer.ReadString();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text5 = buffer.ReadString();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data1 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data2 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data3 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data4 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data5 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data6 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.CommandList = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Condition = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data1 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data2 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data3 = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.ElseCommandList = buffer.ReadInt32();
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount = buffer.ReadInt32();
                                                int tmpcount = modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount;
                                                if (tmpcount > 0)
                                                {
                                                    var oldMoveRoute = modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute;
                                                    modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute = new MoveRouteStruct[tmpcount + 1];
                                                    if (oldMoveRoute != null)
                                                        Array.Copy(oldMoveRoute, modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute, Math.Min(tmpcount + 1, oldMoveRoute.Length));
                                                    var loopTo7 = tmpcount;
                                                    for (var w = 1; w <= loopTo7; w++)
                                                    {
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Index = buffer.ReadInt32();
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data1 = buffer.ReadInt32();
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data2 = buffer.ReadInt32();
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data3 = buffer.ReadInt32();
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data4 = buffer.ReadInt32();
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data5 = buffer.ReadInt32();
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data6 = buffer.ReadInt32();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            // End Event Data

            // Save the map
            modDatabase.SaveMap(mapNum);

            modDatabase.SaveMapEvent(mapNum);

            S_Globals.Gettingmap = false;

            S_Npc.SendMapNpcsToMap(mapNum);
            S_Npc.SpawnMapNpcs(mapNum);
            S_EventLogic.SpawnGlobalEvents(mapNum);
            var loopTo8 = S_GameLogic.GetPlayersOnline();
            for (i = 1; i <= loopTo8; i++)
            {
                if (S_NetworkConfig.IsPlaying(i))
                {
                    if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Map == mapNum)
                        S_EventLogic.SpawnMapEventsFor(i, mapNum);
                }
            }

            // Clear out it all
            for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
            {
                S_Items.SpawnItemSlot(i, 0, 0, S_Players.GetPlayerMap(index), modTypes.MapItem[S_Players.GetPlayerMap(index), i].X, modTypes.MapItem[S_Players.GetPlayerMap(index), i].Y);
                modDatabase.ClearMapItem(i, S_Players.GetPlayerMap(index));
            }

            // Respawn
            S_Items.SpawnMapItems(mapNum);

            modDatabase.ClearTempTile(mapNum);
            S_Resources.CacheResources(mapNum);
            var loopTo9 = S_GameLogic.GetPlayersOnline();

            // Refresh map for everyone online
            for (i = 1; i <= loopTo9; i++)
            {
                if (S_NetworkConfig.IsPlaying(i) && S_Players.GetPlayerMap(i) == mapNum)
                {
                    S_Players.PlayerWarp(i, mapNum, S_Players.GetPlayerX(i), S_Players.GetPlayerY(i));
                    // Send map
                    S_NetworkSend.SendMapData(i, mapNum, true);
                }
            }

            buffer.Dispose();
        }

        private static void Packet_Emote(int index, ref byte[] data)
        {
            int Emote;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CEmote");

            Emote = buffer.ReadInt32();

            S_NetworkSend.SendEmote(index, Emote);

            buffer.Dispose();
        }
    }
}
