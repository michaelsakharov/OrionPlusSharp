using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using System.Linq;
using System.Threading;
using static Engine.Enums;
using System.Collections.Generic;

namespace Engine
{
    class TempOnlinePlayerData
    {
        public int Index;
        public modTypes.TempPlayerRec Player;
    }


    static class ModLoop
    {

        public static List<TempOnlinePlayerData> onlinePlayers = new List<TempOnlinePlayerData>();


        public static void UpdateOnlinePlayers()
        {
            onlinePlayers = modTypes.TempPlayer.Where(player => player.InGame).Select((player, index) => new TempOnlinePlayerData { Index = index + 1, Player = player }).ToList();
        }


        public static void ServerLoop()
        {
            int tick = 0;
            int tickCPS = 0;
            int cps = 0;
            int tmr25 = 0;
            int tmr300 = 0;
            int tmr500 = 0;
            int tmr1000 = 0;
            int lastUpdateSavePlayers = 0;
            int lastUpdateMapSpawnItems = 0;
            int lastUpdatePlayerVitals = 0;

            do
            {

                try
                {
                    //Because everything in here is called every single cycle we wanna make sure its all as fast as possible!
                    //So we need to pull out as much work from everything

                    // Update our current tick value.
                    tick = S_General.GetTimeMs();

                    // Get all our online players.
                    //var onlinePlayers = modTypes.TempPlayer.Where(player => player.InGame).Select((player, index) => new { Index = index + 1, player }).ToArray();

                    if (tick > tmr25)
                    {
                        if (onlinePlayers.Count() > 0)
                        {
                            // Check if any of our players has completed casting and get their skill going if they have.
                            var playerskills = (from p in onlinePlayers
                                                where p.Player.SkillBuffer > 0 && S_General.GetTimeMs() > (p.Player.SkillBufferTimer + Types.Skill[p.Player.SkillBuffer].CastTime * 1000)
                                                select new { p.Index, Success = HandleCastSkill(p.Index) }).ToArray();


                            // Check if we need to clear any of our players from being stunned.
                            var playerstuns = (from p in onlinePlayers
                                               where p.Player.StunDuration > 0 && p.Player.StunTimer > (p.Player.StunDuration * 1000)
                                               select new { p.Index, Success = HandleClearStun(p.Index) }).ToArray();

                            // Check if any of our pets has completed casting and get their skill going if they have.
                            var petskills = (from p in onlinePlayers
                                             where modTypes.Player[p.Index].Character[p.Player.CurChar].Pet.Alive == 1 && modTypes.TempPlayer[p.Index].PetskillBuffer.Skill > 0 && S_General.GetTimeMs() > p.Player.PetskillBuffer.Timer + (Types.Skill[modTypes.Player[p.Index].Character[p.Player.CurChar].Pet.Skill[p.Player.PetskillBuffer.Skill]].CastTime * 1000)
                                             select new { p.Index, Success = HandlePetSkill(p.Index) }).ToArray();

                            // Check if we need to clear any of our pets from being stunned.
                            var petstuns = (from p in onlinePlayers
                                            where p.Player.PetStunDuration > 0 && p.Player.PetStunTimer > (p.Player.PetStunDuration * 1000)
                                            select new { p.Index, Success = HandleClearPetStun(p.Index) }).ToArray();

                            // check pet regen timer
                            var petregen = (from p in onlinePlayers
                                            where p.Player.PetstopRegen == true && p.Player.PetstopRegenTimer + 5000 < S_General.GetTimeMs()
                                            select new { p.Index, Success = HandleStopPetRegen(p.Index) }).ToArray();
                        }
                        // HoT and DoT logic
                        // For x = 1 To MAX_DOTS
                        // HandleDoT_Pet i, x
                        // HandleHoT_Pet i, x
                        // Next

                        // Update all our available events.
                        S_EventLogic.UpdateEventLogic();

                        // Move the timer up 25ms.
                        tmr25 = S_General.GetTimeMs() + 25;
                    }
                    
                    if (tick > tmr1000)
                    {
                        if (onlinePlayers.Count() > 0)
                        {
                            // Handle our player crafting
                            var playercrafts = (from p in onlinePlayers
                                                where S_General.GetTimeMs() > p.Player.CraftTimer + (p.Player.CraftTimeNeeded * 1000) && p.Player.CraftIt == 1
                                                select new { p.Index, Success = HandlePlayerCraft(p.Index) }).ToArray();
                        }
                        Time.Instance.Tick();
                    
                        // Move the timer up 1000ms.
                        tmr1000 = S_General.GetTimeMs() + 1000;
                    }
                    
                    if (tick > tmr500)
                    {
                        if (onlinePlayers.Count() > 0)
                        {
                            // Handle player housing timers.
                            var playerhousing = (from p in onlinePlayers
                                                 where modTypes.Player[p.Index].Character[p.Player.CurChar].InHouse > 0 && S_NetworkConfig.IsPlaying(modTypes.Player[p.Index].Character[p.Player.CurChar].InHouse) && modTypes.Player[modTypes.Player[p.Index].Character[p.Player.CurChar].InHouse].Character[p.Player.CurChar].InHouse != modTypes.Player[p.Index].Character[p.Player.CurChar].InHouse
                                                 select new { p.Index, Success = HandlePlayerHouse(p.Index) }).ToArray();
                        }
                        // Move the timer up 500ms.
                        tmr500 = S_General.GetTimeMs() + 500;
                    }
                    
                    if (S_General.GetTimeMs() > tmr300)
                    {
                        UpdateNpcAi();
                        S_Pets.UpdatePetAi();
                        tmr300 = S_General.GetTimeMs() + 300;
                    }
                    
                    // Checks to update player vitals every 1 seconds - Can be tweaked
                    if (tick > lastUpdatePlayerVitals)
                    {
                        if (onlinePlayers.Count() > 0)
                        {
                            UpdatePlayerVitals();
                        }
                        lastUpdatePlayerVitals = S_General.GetTimeMs() + 1000;
                    }
                    
                    // Checks to spawn map items every 5 minutes - Can be tweaked
                    if (tick > lastUpdateMapSpawnItems)
                    {
                        UpdateMapSpawnItems();
                        lastUpdateMapSpawnItems = S_General.GetTimeMs() + 300000;
                    }
                    
                    // Checks to save players every 10 minutes - Can be tweaked
                    if (tick > lastUpdateSavePlayers)
                    {
                        if (onlinePlayers.Count() > 0)
                        {
                            UpdateSavePlayers();
                        }
                        lastUpdateSavePlayers = S_General.GetTimeMs() + 600000;
                    }

                    if (!modTypes.Options.unlockCPS)
                    {
                        Thread.Sleep(1);
                    }
                    // Calculator CPS
                    if (tickCPS < tick)
                    {
                        S_General.gameCPS = cps;
                        tickCPS = tick + 1000;
                        cps = 0;
                    }
                    else
                    {
                        cps++;
                    }
                }
                catch(Exception error)
                {
                    Console.WriteLine("AN WILD ERROR HAS APPEARED!");
                    Console.WriteLine(error.StackTrace.ToString());
                    S_Globals.ErrorCount++;
                    Console.WriteLine("THE SERVER IS NOW UNSTABLE!! PLEASE RESTART!!");
                    Console.WriteLine("THE SERVER IS NOW UNSTABLE!! PLEASE RESTART!!");
                    Console.WriteLine("THE SERVER IS NOW UNSTABLE!! PLEASE RESTART!!");
                }
            }
            while (true);
        }

        // Function GetTotalPlayersOnline() As Integer
        // GetTotalPlayersOnline = TempPlayer.Where(Function(x) x.InGame).ToArray().Length
        // End Function

        public static void UpdateSavePlayers()
        {
            int i;

            if (S_GameLogic.GetPlayersOnline() > 0)
            {
                Console.WriteLine("Saving all online players...");
                S_NetworkSend.GlobalMsg("Saving all online players...");
                var loopTo = S_GameLogic.GetPlayersOnline();
                for (i = 1; i <= loopTo; i++)
                {
                    if (S_NetworkConfig.IsPlaying(i))
                    {
                        modDatabase.SavePlayer(i);
                        modDatabase.SaveBank(i);
                    }
                }
            }
        }

        private static void UpdateMapSpawnItems()
        {
            int x;
            int y;

            // ///////////////////////////////////////////
            // // This is used for respawning map items //
            // ///////////////////////////////////////////
            for (y = 1; y <= S_Instances.MAX_CACHED_MAPS; y++)
            {

                // Make sure no one is on the map when it respawns
                if (modTypes.PlayersOnMap[y] == 0)
                {

                    // Clear out unnecessary junk
                    for (x = 1; x <= Constants.MAX_MAP_ITEMS; x++)
                        modDatabase.ClearMapItem(x, y);

                    // Spawn the items
                    S_Items.SpawnMapItems(y);
                    S_Items.SendMapItemsToAll(y);
                }
            }
        }

        private static void UpdatePlayerVitals()
        {
            int i;
            var loopTo = S_GameLogic.GetPlayersOnline();
            for (i = 1; i <= loopTo; i++)
            {
                if (S_NetworkConfig.IsPlaying(i))
                {
                    if (S_Players.GetPlayerVital(i, VitalType.HP) != S_Players.GetPlayerMaxVital(i, VitalType.HP))
                    {
                        S_Players.SetPlayerVital(i, VitalType.HP, S_Players.GetPlayerVital(i, VitalType.HP) + S_Players.GetPlayerVitalRegen(i, VitalType.HP));
                        S_NetworkSend.SendVital(i, VitalType.HP);
                    }

                    if (S_Players.GetPlayerVital(i, VitalType.MP) != S_Players.GetPlayerMaxVital(i, VitalType.MP))
                    {
                        S_Players.SetPlayerVital(i, VitalType.MP, S_Players.GetPlayerVital(i, VitalType.MP) + S_Players.GetPlayerVitalRegen(i, VitalType.MP));
                        S_NetworkSend.SendVital(i, VitalType.MP);
                    }

                    if (S_Players.GetPlayerVital(i, VitalType.SP) != S_Players.GetPlayerMaxVital(i, VitalType.SP))
                    {
                        S_Players.SetPlayerVital(i, VitalType.SP, S_Players.GetPlayerVital(i, VitalType.SP) + S_Players.GetPlayerVitalRegen(i, VitalType.SP));
                        S_NetworkSend.SendVital(i, VitalType.SP);
                    }
                }
                // send vitals to party if in one
                if (modTypes.TempPlayer[i].InParty > 0)
                    S_Parties.SendPartyVitals(modTypes.TempPlayer[i].InParty, i);
            }
        }

        private static void UpdateNpcAi()
        {
            int i = 0;
            int x = 0;
            int n = 0;
            int x1 = 0;
            int y1 = 0;
            int mapNum = 0;
            int tickCount = 0;
            int damage = 0;
            int distanceX = 0;
            int distanceY = 0;
            int npcNum = 0;
            int target = 0;
            byte targetTypes = 0;
            int targetX = 0;
            int targetY = 0;
            bool targetVerify = false;
            int resourceIndex = 0;

            for (mapNum = 1; mapNum <= S_Instances.MAX_CACHED_MAPS; mapNum++)
            {

                // items appearing to everyone
                for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
                {
                    if (modTypes.MapItem[mapNum, i].Num > 0)
                    {
                        if (modTypes.MapItem[mapNum, i].PlayerName != Microsoft.VisualBasic.Constants.vbNullString)
                        {
                            // make item public?
                            if (modTypes.MapItem[mapNum, i].PlayerTimer < S_General.GetTimeMs())
                            {
                                // make it public
                                modTypes.MapItem[mapNum, i].PlayerName = Microsoft.VisualBasic.Constants.vbNullString;
                                modTypes.MapItem[mapNum, i].PlayerTimer = 0;
                                // send updates to everyone
                                S_Items.SendMapItemsToAll(mapNum);
                            }
                            // despawn item?
                            if (modTypes.MapItem[mapNum, i].CanDespawn)
                            {
                                if (modTypes.MapItem[mapNum, i].DespawnTimer < S_General.GetTimeMs())
                                {
                                    // despawn it
                                    modDatabase.ClearMapItem(i, mapNum);
                                    // send updates to everyone
                                    S_Items.SendMapItemsToAll(mapNum);
                                }
                            }
                        }
                    }
                }

                // Close the doors
                if (tickCount > modTypes.TempTile[mapNum].DoorTimer + 5000)
                {
                    var loopTo = modTypes.Map[mapNum].MaxX;
                    for (x1 = 0; x1 <= loopTo; x1++)
                    {
                        var loopTo1 = modTypes.Map[mapNum].MaxY;
                        for (y1 = 0; y1 <= loopTo1; y1++)
                        {
                            if (modTypes.Map[mapNum].Tile[x1, y1].Type == (int)TileType.Key && modTypes.TempTile[mapNum].DoorOpen[x1, y1] == 1)
                            {
                                modTypes.TempTile[mapNum].DoorOpen[x1, y1] = 0;
                                S_NetworkSend.SendMapKeyToMap(mapNum, x1, y1, 0);
                            }
                        }
                    }
                }

                // Respawning Resources
                if (S_Resources.ResourceCache == null)
                    return;
                if (S_Resources.ResourceCache[mapNum].ResourceCount > 0)
                {
                    var loopTo2 = S_Resources.ResourceCache[mapNum].ResourceCount;
                    for (i = 1; i <= loopTo2; i++)
                    {
                        resourceIndex = modTypes.Map[mapNum].Tile[S_Resources.ResourceCache[mapNum].ResourceData[i].X, S_Resources.ResourceCache[mapNum].ResourceData[i].Y].Data1;

                        if (resourceIndex > 0)
                        {
                            if (S_Resources.ResourceCache[mapNum].ResourceData[i].ResourceState == 1 || S_Resources.ResourceCache[mapNum].ResourceData[i].CurHealth < 1)
                            {
                                if (S_Resources.ResourceCache[mapNum].ResourceData[i].ResourceTimer + (Types.Resource[resourceIndex].RespawnTime * 1000) < S_General.GetTimeMs())
                                {
                                    S_Resources.ResourceCache[mapNum].ResourceData[i].ResourceTimer = S_General.GetTimeMs();
                                    S_Resources.ResourceCache[mapNum].ResourceData[i].ResourceState = 0; // normal
                                                                                                         // re-set health to resource root
                                    S_Resources.ResourceCache[mapNum].ResourceData[i].CurHealth = (byte)Types.Resource[resourceIndex].Health;
                                    S_Resources.SendResourceCacheToMap(mapNum, i);
                                }
                            }
                        }
                    }
                }

                if (modTypes.PlayersOnMap[mapNum] == 1)
                {
                    tickCount = S_General.GetTimeMs();

                    for (x = 1; x <= Constants.MAX_MAP_NPCS; x++)
                    {
                        npcNum = modTypes.MapNpc[mapNum].Npc[x].Num;

                        // check if they've completed casting, and if so set the actual skill going
                        if (modTypes.MapNpc[mapNum].Npc[x].SkillBuffer > 0 && modTypes.Map[mapNum].Npc[x] > 0 && modTypes.MapNpc[mapNum].Npc[x].Num > 0)
                        {
                            if (S_General.GetTimeMs() > modTypes.MapNpc[mapNum].Npc[x].SkillBufferTimer + (Types.Skill[Types.Npc[npcNum].Skill[modTypes.MapNpc[mapNum].Npc[x].SkillBuffer]].CastTime * 1000))
                            {
                                CastNpcSkill(x, mapNum, modTypes.MapNpc[mapNum].Npc[x].SkillBuffer);
                                modTypes.MapNpc[mapNum].Npc[x].SkillBuffer = 0;
                                modTypes.MapNpc[mapNum].Npc[x].SkillBufferTimer = 0;
                            }
                        }
                        else
                        {
                            // /////////////////////////////////////////
                            // // This is used for ATTACKING ON SIGHT //
                            // /////////////////////////////////////////
                            // Make sure theres a npc with the map
                            if (modTypes.Map[mapNum].Npc[x] > 0 && modTypes.MapNpc[mapNum].Npc[x].Num > 0)
                            {

                                // If the npc is a attack on sight, search for a player on the map
                                if (Types.Npc[npcNum].Behaviour == (int)NpcBehavior.AttackOnSight || Types.Npc[npcNum].Behaviour == (int)NpcBehavior.Guard)
                                {

                                    // make sure it's not stunned
                                    if (!(modTypes.MapNpc[mapNum].Npc[x].StunDuration > 0))
                                    {
                                        var loopTo3 = S_GameLogic.GetPlayersOnline();
                                        for (i = 1; i <= loopTo3; i++)
                                        {
                                            if (S_NetworkConfig.IsPlaying(i))
                                            {
                                                if (S_Players.GetPlayerMap(i) == mapNum && modTypes.MapNpc[mapNum].Npc[x].Target == 0 && S_Players.GetPlayerAccess(i) <= (int)AdminType.Monitor)
                                                {
                                                    if (S_Pets.PetAlive(i))
                                                    {
                                                        n = Types.Npc[npcNum].Range;
                                                        distanceX = modTypes.MapNpc[mapNum].Npc[x].X - modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Pet.X;
                                                        distanceY = modTypes.MapNpc[mapNum].Npc[x].Y - modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Pet.Y;

                                                        // Make sure we get a positive value
                                                        if (distanceX < 0)
                                                            distanceX = distanceX * -1;
                                                        if (distanceY < 0)
                                                            distanceY = distanceY * -1;

                                                        // Are they in range?  if so GET'M!
                                                        if (distanceX <= n && distanceY <= n)
                                                        {
                                                            if (Types.Npc[npcNum].Behaviour == (int)NpcBehavior.AttackOnSight || S_Players.GetPlayerPK(i) == i)
                                                            {
                                                                if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Npc[npcNum].AttackSay)) > 0)
                                                                    S_NetworkSend.PlayerMsg(i, Microsoft.VisualBasic.Strings.Trim(Types.Npc[npcNum].Name) + " says: " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[npcNum].AttackSay), (int)QColorType.SayColor);
                                                                modTypes.MapNpc[mapNum].Npc[x].TargetType = (int)TargetType.Pet;
                                                                modTypes.MapNpc[mapNum].Npc[x].Target = i;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        n = Types.Npc[npcNum].Range;
                                                        distanceX = modTypes.MapNpc[mapNum].Npc[x].X - S_Players.GetPlayerX(i);
                                                        distanceY = modTypes.MapNpc[mapNum].Npc[x].Y - S_Players.GetPlayerY(i);

                                                        // Make sure we get a positive value
                                                        if (distanceX < 0)
                                                            distanceX = distanceX * -1;
                                                        if (distanceY < 0)
                                                            distanceY = distanceY * -1;

                                                        // Are they in range?  if so GET'M!
                                                        if (distanceX <= n && distanceY <= n)
                                                        {
                                                            if (Types.Npc[npcNum].Behaviour == (int)NpcBehavior.AttackOnSight || S_Players.GetPlayerPK(i) == 1)
                                                            {
                                                                if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Npc[npcNum].AttackSay)) > 0)
                                                                    S_NetworkSend.PlayerMsg(i, S_GameLogic.CheckGrammar(Microsoft.VisualBasic.Strings.Trim(Types.Npc[npcNum].Name), 1) + " says, '" + Microsoft.VisualBasic.Strings.Trim(Types.Npc[npcNum].AttackSay) + "' to you.", (int)ColorType.Yellow);
                                                                modTypes.MapNpc[mapNum].Npc[x].TargetType = (int)TargetType.Player;
                                                                modTypes.MapNpc[mapNum].Npc[x].Target = i;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }

                                        // Check if target was found for NPC targetting
                                        if (modTypes.MapNpc[mapNum].Npc[x].Target == 0 && Types.Npc[npcNum].Faction > 0)
                                        {
                                            // search for npc of another faction to target
                                            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                                            {
                                                // exist?
                                                if (modTypes.MapNpc[mapNum].Npc[i].Num > 0)
                                                {
                                                    // different faction?
                                                    if (Types.Npc[modTypes.MapNpc[mapNum].Npc[i].Num].Faction > 0 && Types.Npc[modTypes.MapNpc[mapNum].Npc[i].Num].Faction != Types.Npc[npcNum].Faction)
                                                    {
                                                        n = Types.Npc[npcNum].Range;
                                                        distanceX = (modTypes.MapNpc[mapNum].Npc[x].X - modTypes.MapNpc[mapNum].Npc[i].X);
                                                        distanceY = (modTypes.MapNpc[mapNum].Npc[x].Y - modTypes.MapNpc[mapNum].Npc[i].Y);

                                                        // Make sure we get a positive value
                                                        if (distanceX < 0)
                                                            distanceX = distanceX * -1;
                                                        if (distanceY < 0)
                                                            distanceY = distanceY * -1;

                                                        // Are they in range?  if so GET'M!
                                                        if (distanceX <= n && distanceY <= n && Types.Npc[npcNum].Behaviour == (int)NpcBehavior.AttackOnSight)
                                                        {
                                                            modTypes.MapNpc[mapNum].Npc[x].TargetType = 2; // npc
                                                            modTypes.MapNpc[mapNum].Npc[x].Target = i;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }

                            targetVerify = false;

                            // /////////////////////////////////////////////
                            // // This is used for NPC walking/targetting //
                            // /////////////////////////////////////////////
                            // Make sure theres a npc with the map
                            if (modTypes.Map[mapNum].Npc[x] > 0 && modTypes.MapNpc[mapNum].Npc[x].Num > 0)
                            {
                                if (modTypes.MapNpc[mapNum].Npc[x].StunDuration > 0)
                                {
                                    // check if we can unstun them
                                    if (S_General.GetTimeMs() > modTypes.MapNpc[mapNum].Npc[x].StunTimer + (modTypes.MapNpc[mapNum].Npc[x].StunDuration * 1000))
                                    {
                                        modTypes.MapNpc[mapNum].Npc[x].StunDuration = 0;
                                        modTypes.MapNpc[mapNum].Npc[x].StunTimer = 0;
                                    }
                                }
                                else
                                {
                                    target = modTypes.MapNpc[mapNum].Npc[x].Target;
                                    targetTypes = modTypes.MapNpc[mapNum].Npc[x].TargetType;

                                    // Check to see if its time for the npc to walk
                                    if (Types.Npc[npcNum].Behaviour != (int)NpcBehavior.ShopKeeper && Types.Npc[npcNum].Behaviour != (int)NpcBehavior.Quest)
                                    {
                                        if (targetTypes == (int)TargetType.Player)
                                        {
                                            // Check to see if we are following a player or not
                                            if (target > 0)
                                            {
                                                // Check if the player is even playing, if so follow'm
                                                if (S_NetworkConfig.IsPlaying(target) && S_Players.GetPlayerMap(target) == mapNum)
                                                {
                                                    targetVerify = true;
                                                    targetY = S_Players.GetPlayerY(target);
                                                    targetX = S_Players.GetPlayerX(target);
                                                }
                                                else
                                                {
                                                    modTypes.MapNpc[mapNum].Npc[x].TargetType = 0; // clear
                                                    modTypes.MapNpc[mapNum].Npc[x].Target = 0;
                                                }
                                            }
                                        }
                                        else if (targetTypes == (int)TargetType.Npc)
                                        {
                                            if (target > 0)
                                            {
                                                if (modTypes.MapNpc[mapNum].Npc[target].Num > 0)
                                                {
                                                    targetVerify = true;
                                                    targetY = modTypes.MapNpc[mapNum].Npc[target].Y;
                                                    targetX = modTypes.MapNpc[mapNum].Npc[target].X;
                                                }
                                                else
                                                {
                                                    modTypes.MapNpc[mapNum].Npc[x].TargetType = 0; // clear
                                                    modTypes.MapNpc[mapNum].Npc[x].Target = 0;
                                                }
                                            }
                                        }
                                        else if (targetTypes == (int)TargetType.Pet)
                                        {
                                            if (target > 0)
                                            {
                                                if (S_NetworkConfig.IsPlaying(target) == true && S_Players.GetPlayerMap(target) == mapNum && S_Pets.PetAlive(target))
                                                {
                                                    targetVerify = true;
                                                    targetY = modTypes.Player[target].Character[modTypes.TempPlayer[target].CurChar].Pet.Y;
                                                    targetX = modTypes.Player[target].Character[modTypes.TempPlayer[target].CurChar].Pet.X;
                                                }
                                                else
                                                {
                                                    modTypes.MapNpc[mapNum].Npc[x].TargetType = 0; // clear
                                                    modTypes.MapNpc[mapNum].Npc[x].Target = 0;
                                                }
                                            }
                                        }

                                        if (targetVerify)
                                        {
                                            // Gonna make the npcs smarter.. Implementing a pathfinding algorithm.. we shall see what happens.
                                            if (S_Events.IsOneBlockAway(targetX, targetY, (int)modTypes.MapNpc[mapNum].Npc[x].X, (int)modTypes.MapNpc[mapNum].Npc[x].Y) == false)
                                            {
                                                i = S_EventLogic.FindNpcPath(mapNum, x, targetX, targetY);
                                                if (i < 4)
                                                {
                                                    if (S_Npc.CanNpcMove(mapNum, x, (byte)i))
                                                        S_Npc.NpcMove(mapNum, x, i, (int)MovementType.Walking);
                                                }
                                                else
                                                {
                                                    i = (int)(VBMath.Rnd() * 4);
                                                    if (i == 1)
                                                    {
                                                        i = (int)(VBMath.Rnd() * 4);

                                                        if (S_Npc.CanNpcMove(mapNum, x, (byte)i))
                                                            S_Npc.NpcMove(mapNum, x, i, (int)MovementType.Walking);
                                                    }
                                                }
                                            }
                                            else
                                                S_Npc.NpcDir(mapNum, x, S_Events.GetNpcDir(targetX, targetY, (int)(modTypes.MapNpc[mapNum].Npc[x].X), (int)(modTypes.MapNpc[mapNum].Npc[x].Y)));
                                        }
                                        else
                                        {
                                            i = (int)(VBMath.Rnd() * 4);

                                            if (i == 1)
                                            {
                                                i = (int)(VBMath.Rnd() * 4);

                                                if (S_Npc.CanNpcMove(mapNum, x, (byte)i))
                                                    S_Npc.NpcMove(mapNum, x, i, (int)MovementType.Walking);
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        // /////////////////////////////////////////////
                        // // This is used for npcs to attack targets //
                        // /////////////////////////////////////////////
                        // Make sure theres a npc with the map
                        if (modTypes.Map[mapNum].Npc[x] > 0 && modTypes.MapNpc[mapNum].Npc[x].Num > 0)
                        {
                            target = modTypes.MapNpc[mapNum].Npc[x].Target;
                            targetTypes = modTypes.MapNpc[mapNum].Npc[x].TargetType;

                            // Check if the npc can attack the targeted player player
                            if (target > 0)
                            {
                                if (targetTypes == (int)TargetType.Player)
                                {

                                    // Is the target playing and on the same map?
                                    if (S_NetworkConfig.IsPlaying(target) && S_Players.GetPlayerMap(target) == mapNum)
                                    {
                                        if (S_NetworkConfig.IsPlaying(target) && S_Players.GetPlayerMap(target) == mapNum)
                                        {
                                            if (S_GameLogic.Random(1, 3) == 1)
                                            {
                                                int skillnum = S_Npc.RandomNpcAttack(mapNum, x);
                                                if (skillnum > 0)
                                                    S_Npc.BufferNpcSkill(mapNum, x, skillnum);
                                                else
                                                    S_Npc.TryNpcAttackPlayer(x, target);// , Damage)
                                            }
                                            else
                                                S_Npc.TryNpcAttackPlayer(x, target);
                                        }
                                        else
                                        {
                                            // Player left map or game, set target to 0
                                            modTypes.MapNpc[mapNum].Npc[x].Target = 0;
                                            modTypes.MapNpc[mapNum].Npc[x].TargetType = 0; // clear
                                        }
                                    }
                                    else
                                    {
                                        // Player left map or game, set target to 0
                                        modTypes.MapNpc[mapNum].Npc[x].Target = 0;
                                        modTypes.MapNpc[mapNum].Npc[x].TargetType = 0; // clear
                                    }
                                }
                                else if (targetTypes == (int)TargetType.Npc)
                                {
                                    if (modTypes.MapNpc[mapNum].Npc[target].Num > 0)
                                    {
                                        // Can the npc attack the npc?
                                        if (S_Npc.CanNpcAttackNpc(mapNum, x, target))
                                        {
                                            damage = (Types.Npc[npcNum].Stat[(byte)StatType.Strength] -Types.Npc[target].Stat[(byte)StatType.Endurance]);
                                            if (damage < 1)
                                                damage = 1;
                                            S_Npc.NpcAttackNpc(mapNum, x, target, damage);
                                        }
                                    }
                                    else
                                    {
                                        // npc is dead or non-existant
                                        modTypes.MapNpc[mapNum].Npc[x].Target = 0;
                                        modTypes.MapNpc[mapNum].Npc[x].TargetType = 0; // clear
                                    }
                                }
                                else if (targetTypes == (int)TargetType.Pet)
                                {
                                    if (S_NetworkConfig.IsPlaying(target) && S_Players.GetPlayerMap(target) == mapNum && S_Pets.PetAlive(target))
                                        S_Pets.TryNpcAttackPet(x, target);
                                    else
                                    {
                                        // Player left map or game, set target to 0
                                        modTypes.MapNpc[mapNum].Npc[x].Target = 0;
                                        modTypes.MapNpc[mapNum].Npc[x].TargetType = 0; // clear
                                    }
                                }
                            }
                        }

                        // ////////////////////////////////////////////
                        // // This is used for regenerating NPC's HP //
                        // ////////////////////////////////////////////
                        // Check to see if we want to regen some of the npc's hp
                        if (modTypes.MapNpc[mapNum].Npc[x].Num > 0 && tickCount > S_Globals.GiveNPCHPTimer + 10000)
                        {
                            if (modTypes.MapNpc[mapNum].Npc[x].Vital[(byte)VitalType.HP] > 0)
                            {
                                modTypes.MapNpc[mapNum].Npc[x].Vital[(byte)VitalType.HP] = modTypes.MapNpc[mapNum].Npc[x].Vital[(byte)VitalType.HP] + GetNpcVitalRegen(npcNum, VitalType.HP);

                                // Check if they have more then they should and if so just set it to max
                                if (modTypes.MapNpc[mapNum].Npc[x].Vital[(byte)VitalType.HP] > S_GameLogic.GetNpcMaxVital(npcNum, VitalType.HP))
                                    modTypes.MapNpc[mapNum].Npc[x].Vital[(byte)VitalType.HP] = S_GameLogic.GetNpcMaxVital(npcNum, VitalType.HP);
                            }
                        }

                        if (modTypes.MapNpc[mapNum].Npc[x].Num > 0 && tickCount > S_Globals.GiveNPCMPTimer + 10000 && modTypes.MapNpc[mapNum].Npc[x].Vital[(byte)VitalType.MP] > 0)
                        {
                            modTypes.MapNpc[mapNum].Npc[x].Vital[(int)VitalType.MP] = modTypes.MapNpc[mapNum].Npc[x].Vital[(byte)VitalType.MP] + GetNpcVitalRegen(npcNum, VitalType.MP);

                            // Check if they have more then they should and if so just set it to max
                            if (modTypes.MapNpc[mapNum].Npc[x].Vital[(int)VitalType.MP] > S_GameLogic.GetNpcMaxVital(npcNum, VitalType.MP))
                                modTypes.MapNpc[mapNum].Npc[x].Vital[(int)VitalType.MP] = S_GameLogic.GetNpcMaxVital(npcNum, VitalType.MP);
                        }

                        // ////////////////////////////////////////////////////////
                        // // This is used for checking if an NPC is dead or not //
                        // ////////////////////////////////////////////////////////
                        // Check if the npc is dead or not
                        if (modTypes.MapNpc[mapNum].Npc[x].Num > 0 && modTypes.MapNpc[mapNum].Npc[x].Vital[(byte)VitalType.HP] <= 0)
                        {
                            modTypes.MapNpc[mapNum].Npc[x].Num = 0;
                            modTypes.MapNpc[mapNum].Npc[x].SpawnWait = S_General.GetTimeMs();
                            modTypes.MapNpc[mapNum].Npc[x].Vital[(int)VitalType.HP] = 0;
                        }

                        // //////////////////////////////////////
                        // // This is used for spawning an NPC //
                        // //////////////////////////////////////
                        // Check if we are supposed to spawn an npc or not
                        if (modTypes.MapNpc[mapNum].Npc[x].Num == 0 && modTypes.Map[mapNum].Npc[x] > 0)
                        {
                            if (tickCount > modTypes.MapNpc[mapNum].Npc[x].SpawnWait + (Types.Npc[modTypes.Map[mapNum].Npc[x]].SpawnSecs * 1000))
                                S_Npc.SpawnNpc(x, mapNum);
                        }
                    }
                }
            }

            // Make sure we reset the timer for npc hp regeneration
            if (S_General.GetTimeMs() > S_Globals.GiveNPCHPTimer + 10000)
                S_Globals.GiveNPCHPTimer = S_General.GetTimeMs();

            if (S_General.GetTimeMs() > S_Globals.GiveNPCMPTimer + 10000)
                S_Globals.GiveNPCMPTimer = S_General.GetTimeMs();

            // Make sure we reset the timer for door closing
            if (S_General.GetTimeMs() > S_Globals.KeyTimer + 15000)
                S_Globals.KeyTimer = S_General.GetTimeMs();
        }

        public static int GetNpcVitalRegen(int npcNum, VitalType vital)
        {
            int i;
            int GetNpcVitalRegen = 0;
            // Prevent subscript out of range
            if (npcNum <= 0 || npcNum > Constants.MAX_NPCS)
            {
                return 0;
            }

            switch (vital)
            {
                case VitalType.HP:
                    {
                        i = Types.Npc[npcNum].Stat[(int)StatType.Vitality] / 3;

                        if (i < 1)
                            i = 1;
                        GetNpcVitalRegen = i;
                        break;
                    }

                case VitalType.MP:
                    {
                        i = Types.Npc[npcNum].Stat[(int)StatType.Intelligence] / 3;

                        if (i < 1)
                            i = 1;
                        GetNpcVitalRegen = i;
                        break;
                    }
            }
            return GetNpcVitalRegen;
        }

        internal static bool HandleCloseSocket(int index)
        {
            S_NetworkConfig.Socket.Disconnect(index);
            return true;
        }

        internal static bool HandlePlayerHouse(int index)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse = 0;
            S_Players.PlayerWarp(index, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastMap, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastX, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastY);
            S_NetworkSend.PlayerMsg(index, "Your visitation has ended. Possibly due to a disconnection. You are being warped back to your previous location.", (int)ColorType.Yellow);
            return true;
        }

        internal static bool HandlePetSkill(int index)
        {
            S_Pets.PetCastSkill(index, modTypes.TempPlayer[index].PetskillBuffer.Skill, modTypes.TempPlayer[index].PetskillBuffer.Target, modTypes.TempPlayer[index].PetskillBuffer.TargetTypes, true);
            modTypes.TempPlayer[index].PetskillBuffer.Skill = 0;
            modTypes.TempPlayer[index].PetskillBuffer.Timer = 0;
            modTypes.TempPlayer[index].PetskillBuffer.Target = 0;
            modTypes.TempPlayer[index].PetskillBuffer.TargetTypes = 0;
            return true;
        }

        internal static bool HandlePlayerCraft(int index)
        {
            modTypes.TempPlayer[index].CraftIt = 0;
            modTypes.TempPlayer[index].CraftTimer = 0;
            modTypes.TempPlayer[index].CraftTimeNeeded = 0;
            modCrafting.UpdateCraft(index);
            return true;
        }

        internal static bool HandleClearStun(int index)
        {
            modTypes.TempPlayer[index].StunDuration = 0;
            modTypes.TempPlayer[index].StunTimer = 0;
            S_NetworkSend.SendStunned(index);
            return true;
        }

        internal static bool HandleClearPetStun(int index)
        {
            modTypes.TempPlayer[index].PetStunDuration = 0;
            modTypes.TempPlayer[index].PetStunTimer = 0;
            return true;
        }

        internal static bool HandleStopPetRegen(int index)
        {
            modTypes.TempPlayer[index].PetstopRegen = false;
            modTypes.TempPlayer[index].PetstopRegenTimer = 0;
            return true;
        }

        internal static bool HandleCastSkill(int index)
        {
            CastSkill(index, modTypes.TempPlayer[index].SkillBuffer);
            modTypes.TempPlayer[index].SkillBuffer = 0;
            modTypes.TempPlayer[index].SkillBufferTimer = 0;
            return true;
        }

        internal static void CastSkill(int index, int skillSlot)
        {
            // Set up some basic variables we'll be using.
            var skillId = S_Players.GetPlayerSkill(index, skillSlot);

            // Preventative checks
            if (!S_NetworkConfig.IsPlaying(index) || skillSlot <= 0 || skillSlot > Constants.MAX_PLAYER_SKILLS || !S_Players.HasSkill(index, skillId))
                return;

            // Check if the player is able to cast the spell.
            if (S_Players.GetPlayerVital(index, VitalType.MP) < Types.Skill[skillId].MpCost)
            {
                S_NetworkSend.PlayerMsg(index, "Not enough mana!", (int)ColorType.BrightRed);
                return;
            }
            else if (S_Players.GetPlayerLevel(index) < Types.Skill[skillId].LevelReq)
            {
                S_NetworkSend.PlayerMsg(index, string.Format("You must be level {0} to use this skill.", Types.Skill[skillId].LevelReq), (int)ColorType.BrightRed);
                return;
            }
            else if (S_Players.GetPlayerAccess(index) < Types.Skill[skillId].AccessReq)
            {
                S_NetworkSend.PlayerMsg(index, "You must be an administrator to use this skill.", (int)ColorType.BrightRed);
                return;
            }
            else if (!(Types.Skill[skillId].ClassReq == 0) && S_Players.GetPlayerClass(index) != Types.Skill[skillId].ClassReq)
            {
                S_NetworkSend.PlayerMsg(index, string.Format("Only {0} can use this skill.", S_GameLogic.CheckGrammar((Types.Classes[Types.Skill[skillId].ClassReq].Name.Trim()))), (int)ColorType.BrightRed);
                return;
            }
            else if (Types.Skill[skillId].Range > 0 && !IsTargetOnMap(index))
                return;
            else if (Types.Skill[skillId].Range > 0 && !IsInSkillRange(index, skillId) && Types.Skill[skillId].IsProjectile == 0)
            {
                S_NetworkSend.PlayerMsg(index, "Target not in range.", (int)ColorType.BrightRed);
                S_NetworkSend.SendClearSkillBuffer(index);
                return;
            }

            // Determine what kind of Skill Type we're dealing with and move on to the appropriate methods.
            if (Types.Skill[skillId].IsProjectile == 1)
                S_Projectiles.PlayerFireProjectile(index, skillId);
            else
            {
                if (Types.Skill[skillId].Range == 0 && !Types.Skill[skillId].IsAoE)
                    HandleSelfCastSkill(index, skillId);
                if (Types.Skill[skillId].Range == 0 && Types.Skill[skillId].IsAoE)
                    HandleSelfCastAoESkill(index, skillId);
                if (Types.Skill[skillId].Range > 0 && Types.Skill[skillId].IsAoE)
                    HandleTargetedAoESkill(index, skillId);
                if (Types.Skill[skillId].Range > 0 && !Types.Skill[skillId].IsAoE)
                    HandleTargetedSkill(index, skillId);
            }

            // Do everything we need to do at the end of the cast.
            FinalizeCast(index, S_Players.GetPlayerSkillSlot(index, skillId), Types.Skill[skillId].MpCost);
        }

        private static void HandleSelfCastAoESkill(int index, int skillId)
        {

            // Set up some variables we'll definitely be using.
            var centerX = S_Players.GetPlayerX(index);
            var centerY = S_Players.GetPlayerY(index);

            // Determine what kind of spell we're dealing with and process it.
            switch (Types.Skill[skillId].Type)
            {
                case (int)SkillType.DamageHp:
                case (int)SkillType.DamageMp:
                case (int)SkillType.HealHp:
                case (int)SkillType.HealMp:
                    {
                        HandleAoE(index, skillId, centerX, centerY);
                        break;
                    }

                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        private static void HandleTargetedAoESkill(int index, int skillId)
        {

            // Set up some variables we'll definitely be using.
            int centerX;
            int centerY;
            switch (modTypes.TempPlayer[index].TargetType)
            {
                case (int)TargetType.Npc:
                    {
                        centerX = modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[modTypes.TempPlayer[index].Target].X;
                        centerY = modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[modTypes.TempPlayer[index].Target].Y;
                        break;
                    }

                case (int)TargetType.Player:
                    {
                        centerX = S_Players.GetPlayerX(modTypes.TempPlayer[index].Target);
                        centerY = S_Players.GetPlayerY(modTypes.TempPlayer[index].Target);
                        break;
                    }

                default:
                    {
                        throw new NotImplementedException();
                    }
            }

            // Determine what kind of spell we're dealing with and process it.
            switch (Types.Skill[skillId].Type)
            {
                case (int)SkillType.HealMp:
                case (int)SkillType.DamageHp:
                case (int)SkillType.DamageMp:
                case (int)SkillType.HealHp:
                    {
                        HandleAoE(index, skillId, centerX, centerY);
                        break;
                    }

                default:
                    {
                        throw new NotImplementedException();
                    }
            }
        }

        private static void HandleSelfCastSkill(int index, int skillId)
        {
            // Determine what kind of spell we're dealing with and process it.
            switch (Types.Skill[skillId].Type)
            {
                case (int)SkillType.HealHp:
                    {
                        SkillPlayer_Effect((byte)VitalType.HP, true, index, Types.Skill[skillId].Vital, skillId);
                        break;
                    }

                case (int)SkillType.HealMp:
                    {
                        SkillPlayer_Effect((byte)VitalType.MP, true, index, Types.Skill[skillId].Vital, skillId);
                        break;
                    }

                case (int)SkillType.Warp:
                    {
                        S_Animations.SendAnimation(S_Players.GetPlayerMap(index), Types.Skill[skillId].SkillAnim, 0, 0, (int)TargetType.Player, index);
                        S_Players.PlayerWarp(index, Types.Skill[skillId].Map, Types.Skill[skillId].X, Types.Skill[skillId].Y);
                        break;
                    }

                default:
                    {
                        throw new NotImplementedException();
                    }
            }

            // Play our animation.
            S_Animations.SendAnimation(S_Players.GetPlayerMap(index), Types.Skill[skillId].SkillAnim, 0, 0, (int)TargetType.Player, index);
        }

        private static void HandleTargetedSkill(int index, int skillId)
        {
            // Set up some variables we'll definitely be using.
            VitalType vital;
            bool dealsDamage;
            var amount = Types.Skill[skillId].Vital;
            var target = modTypes.TempPlayer[index].Target;

            // Determine what vital we need to adjust and how.
            switch (Types.Skill[skillId].Type)
            {
                case (int)SkillType.DamageHp:
                    {
                        vital = VitalType.HP;
                        dealsDamage = true;
                        break;
                    }

                case (int)SkillType.DamageMp:
                    {
                        vital = VitalType.MP;
                        dealsDamage = true;
                        break;
                    }

                case (int)SkillType.HealHp:
                    {
                        vital = VitalType.HP;
                        dealsDamage = false;
                        break;
                    }

                case (int)SkillType.HealMp:
                    {
                        vital = VitalType.MP;
                        dealsDamage = false;
                        break;
                    }

                default:
                    {
                        throw new NotImplementedException();
                    }
            }

            switch (modTypes.TempPlayer[index].TargetType)
            {
                case (int)TargetType.Npc:
                    {
                        // Deal with damaging abilities.
                        if (dealsDamage && S_Players.CanPlayerAttackNpc(index, target, true))
                            SkillNpc_Effect((byte)vital, false, target, amount, skillId, S_Players.GetPlayerMap(index));

                        // Deal with healing abilities
                        if (!dealsDamage)
                            SkillNpc_Effect((byte)vital, true, target, amount, skillId, S_Players.GetPlayerMap(index));

                        // Handle our NPC death if it kills them
                        if (S_Npc.IsNpcDead(S_Players.GetPlayerMap(index), modTypes.TempPlayer[index].Target))
                            S_Players.HandlePlayerKillNpc(S_Players.GetPlayerMap(index), index, modTypes.TempPlayer[index].Target);
                        break;
                    }

                case (int)TargetType.Player:
                    {

                        // Deal with damaging abilities.
                        if (dealsDamage && S_Players.CanPlayerAttackPlayer(index, target, true))
                            SkillPlayer_Effect((byte)vital, false, target, amount, skillId);

                        // Deal with healing abilities
                        if (!dealsDamage)
                            SkillPlayer_Effect((byte)vital, true, target, amount, skillId);

                        if (S_Players.IsPlayerDead(target))
                        {
                            // Actually kill the player.
                            S_Players.OnDeath(target);

                            // Handle PK stuff.
                            S_Players.HandlePlayerKilledPK(index, target);

                            // Handle our quest system stuff.
                            S_Quest.CheckTasks(index, (int)QuestType.Kill, 0);
                        }

                        break;
                    }

                default:
                    {
                        throw new NotImplementedException();
                    }
            }

            // Play our animation.
            S_Animations.SendAnimation(S_Players.GetPlayerMap(index), Types.Skill[skillId].SkillAnim, 0, 0, modTypes.TempPlayer[index].TargetType, target);
        }

        private static void HandleAoE(int index, int skillId, int x, int y)
        {
            // Get some basic things set up.
            var map = S_Players.GetPlayerMap(index);
            var range = Types.Skill[skillId].Range;
            var amount = Types.Skill[skillId].Vital;
            VitalType vital;
            bool dealsDamage;

            // Determine what vital we need to adjust and how.
            switch (Types.Skill[skillId].Type)
            {
                case (int)SkillType.DamageHp:
                    {
                        vital = VitalType.HP;
                        dealsDamage = true;
                        break;
                    }

                case (int)SkillType.DamageMp:
                    {
                        vital = VitalType.MP;
                        dealsDamage = true;
                        break;
                    }

                case (int)SkillType.HealHp:
                    {
                        vital = VitalType.HP;
                        dealsDamage = false;
                        break;
                    }

                case (int)SkillType.HealMp:
                    {
                        vital = VitalType.MP;
                        dealsDamage = false;
                        break;
                    }

                default:
                    {
                        throw new NotImplementedException();
                    }
            }

            // Loop through all online players on the current map.
            foreach (var id in modTypes.TempPlayer.Where(p => p.InGame).Select((p, i) => i + 1).Where(i => S_Players.GetPlayerMap(i) == map && i != index).ToArray())
            {
                if (S_Players.IsInRange(range, x, y, S_Players.GetPlayerX(id), S_Players.GetPlayerY(id)))
                {

                    // Deal with damaging abilities.
                    if (dealsDamage && S_Players.CanPlayerAttackPlayer(index, id, true))
                        SkillPlayer_Effect((byte)vital, false, id, amount, skillId);

                    // Deal with healing abilities
                    if (!dealsDamage)
                        SkillPlayer_Effect((byte)vital, true, id, amount, skillId);

                    // Send our animation to the map.
                    S_Animations.SendAnimation(map, Types.Skill[skillId].SkillAnim, 0, 0, (int)TargetType.Player, id);

                    if (S_Players.IsPlayerDead(id))
                    {
                        // Actually kill the player.
                        S_Players.OnDeath(id);

                        // Handle PK stuff.
                        S_Players.HandlePlayerKilledPK(index, id);

                        // Handle our quest system stuff.
                        S_Quest.CheckTasks(index, (int)QuestType.Kill, 0);
                    }
                }
            }

            // Loop through all the NPCs on this map
            foreach (var id in modTypes.MapNpc[map].Npc.Where(n => n.Num > 0 && n.Vital[(int)VitalType.HP] > 0).Select((n, i) => i + 1).ToArray())
            {
                if (S_Players.IsInRange(range, x, y, modTypes.MapNpc[map].Npc[id].X, modTypes.MapNpc[map].Npc[id].Y))
                {

                    // Deal with damaging abilities.
                    if (dealsDamage && S_Players.CanPlayerAttackNpc(index, id, true))
                        SkillNpc_Effect((byte)vital, false, id, amount, skillId, map);

                    // Deal with healing abilities
                    if (!dealsDamage)
                        SkillNpc_Effect((byte)vital, true, id, amount, skillId, map);

                    // Send our animation to the map.
                    S_Animations.SendAnimation(map, Types.Skill[skillId].SkillAnim, 0, 0, (int)TargetType.Npc, id);

                    // Handle our NPC death if it kills them
                    if (S_Npc.IsNpcDead(map, id))
                        S_Players.HandlePlayerKillNpc(map, index, id);
                }
            }
        }

        private static void FinalizeCast(int index, int skillSlot, int skillCost)
        {
            S_Players.SetPlayerVital(index, VitalType.MP, S_Players.GetPlayerVital(index, VitalType.MP) - skillCost);
            S_NetworkSend.SendVital(index, VitalType.MP);
            modTypes.TempPlayer[index].SkillCd[skillSlot] = S_General.GetTimeMs() + (Types.Skill[skillSlot].CdTime * 1000);
            S_NetworkSend.SendCooldown(index, skillSlot);
        }

        private static bool IsTargetOnMap(int index)
        {
            bool IsTargetOnMap = false;
            if (modTypes.TempPlayer[index].TargetType == (int)TargetType.Player)
            {
                if (S_Players.GetPlayerMap(modTypes.TempPlayer[index].Target) == S_Players.GetPlayerMap(index))
                    IsTargetOnMap = true;
            }
            else if (modTypes.TempPlayer[index].TargetType == (int)TargetType.Npc)
            {
                if (modTypes.TempPlayer[index].Target > 0 && modTypes.TempPlayer[index].Target <= Constants.MAX_MAP_NPCS && modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[modTypes.TempPlayer[index].Target].Vital[(int)VitalType.HP] > 0)
                    IsTargetOnMap = true;
            }
            return IsTargetOnMap;
        }

        private static bool IsInSkillRange(int index, int SkillId)
        {
            int targetX = 0;
            int targetY = 0;

            if (modTypes.TempPlayer[index].TargetType == (int)TargetType.Player)
            {
                targetX = S_Players.GetPlayerX(modTypes.TempPlayer[index].Target);
                targetY = S_Players.GetPlayerY(modTypes.TempPlayer[index].Target);
            }
            else if (modTypes.TempPlayer[index].TargetType == (int)TargetType.Npc)
            {
                targetX = modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[modTypes.TempPlayer[index].Target].X;
                targetY = modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[modTypes.TempPlayer[index].Target].Y;
            }

            return S_Players.IsInRange(Types.Skill[SkillId].Range, S_Players.GetPlayerX(index), S_Players.GetPlayerY(index), targetX, targetY);
        }

        internal static void CastNpcSkill(int npcNum, int mapNum, int skillslot)
        {
            int skillnum = 0;
            int mpCost = 0;
            int vital = 0;
            bool didCast = false;
            int i = 0;
            int aoe = 0;
            int range = 0;
            byte vitalType = 0;
            bool increment = false;
            int x = 0;
            int y = 0;

            byte targetType = 0;
            int target = 0;
            int skillCastType = 0;

            didCast = false;

            // Prevent subscript out of range
            if (skillslot <= 0 || skillslot > Constants.MAX_NPC_SKILLS)
                return;

            skillnum = S_Npc.GetNpcSkill(modTypes.MapNpc[mapNum].Npc[npcNum].Num, skillslot);

            mpCost = Types.Skill[skillnum].MpCost;

            // Check if they have enough MP
            if (modTypes.MapNpc[mapNum].Npc[npcNum].Vital[(int)VitalType.MP] < mpCost)
                return;

            // find out what kind of skill it is! self cast, target or AOE
            if (Types.Skill[skillnum].IsProjectile == 1)
                skillCastType = 4; // Projectile
            else if (Types.Skill[skillnum].Range > 0)
            {
                // ranged attack, single target or aoe?
                if (!Types.Skill[skillnum].IsAoE)
                    skillCastType = 2; // targetted
                else
                    skillCastType = 3;// targetted aoe
            }
            else if (!Types.Skill[skillnum].IsAoE)
                skillCastType = 0; // self-cast
            else
                skillCastType = 1;// self-cast AoE

            // set the vital
            vital = Types.Skill[skillnum].Vital;
            aoe = Types.Skill[skillnum].AoE;
            range = Types.Skill[skillnum].Range;

            switch (skillCastType)
            {
                case 0: // self-cast target
                    { 
                        break;
                    }

                case 1:
                case 3: // self-cast AOE & targetted AOE
                    {
                        if (skillCastType == 1)
                        {
                            x = modTypes.MapNpc[mapNum].Npc[npcNum].X;
                            y = modTypes.MapNpc[mapNum].Npc[npcNum].Y;
                        }
                        else if (skillCastType == 3)
                        {
                            targetType = modTypes.MapNpc[mapNum].Npc[npcNum].TargetType;
                            target = modTypes.MapNpc[mapNum].Npc[npcNum].Target;

                            if (targetType == 0)
                                return;
                            if (target == 0)
                                return;

                            if (targetType == (int)TargetType.Player)
                            {
                                x = S_Players.GetPlayerX(target);
                                y = S_Players.GetPlayerY(target);
                            }
                            else
                            {
                                x = modTypes.MapNpc[mapNum].Npc[target].X;
                                y = modTypes.MapNpc[mapNum].Npc[target].Y;
                            }

                            if (!S_Players.IsInRange(range, x, y, S_Players.GetPlayerX(npcNum), S_Players.GetPlayerY(npcNum)))
                                return;
                        }
                        switch (Types.Skill[skillnum].Type)
                        {
                            case (int)SkillType.DamageHp:
                                {
                                    didCast = true;
                                    var loopTo = S_GameLogic.GetPlayersOnline();
                                    for (i = 1; i <= loopTo; i++)
                                    {
                                        if (S_NetworkConfig.IsPlaying(i))
                                        {
                                            if (S_Players.GetPlayerMap(i) == mapNum)
                                            {
                                                if (S_Players.IsInRange(aoe, x, y, S_Players.GetPlayerX(i), S_Players.GetPlayerY(i)))
                                                {
                                                    if (S_Npc.CanNpcAttackPlayer(npcNum, i))
                                                    {
                                                        S_Animations.SendAnimation(mapNum, Types.Skill[skillnum].SkillAnim, 0, 0, (int)TargetType.Player, i);
                                                        S_NetworkSend.PlayerMsg(i, Microsoft.VisualBasic.Strings.Trim(Types.Npc[modTypes.MapNpc[mapNum].Npc[npcNum].Num].Name) + " uses " + Microsoft.VisualBasic.Strings.Trim(Types.Skill[skillnum].Name) + "!", (int)ColorType.Yellow);
                                                        SkillPlayer_Effect((byte)VitalType.HP, false, i, vital, skillnum);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                                    {
                                        if (modTypes.MapNpc[mapNum].Npc[i].Num > 0)
                                        {
                                            if (modTypes.MapNpc[mapNum].Npc[i].Vital[(int)VitalType.HP] > 0)
                                            {
                                                if (S_Players.IsInRange(aoe, x, y, modTypes.MapNpc[mapNum].Npc[i].X, modTypes.MapNpc[mapNum].Npc[i].Y))
                                                {
                                                    if (S_Players.CanPlayerAttackNpc(npcNum, i, true))
                                                    {
                                                        S_Animations.SendAnimation(mapNum, Types.Skill[skillnum].SkillAnim, 0, 0, (int)TargetType.Npc, i);
                                                        SkillNpc_Effect((byte)VitalType.HP, false, i, vital, skillnum, mapNum);
                                                        if (Types.Skill[skillnum].KnockBack == 1)
                                                            S_Npc.KnockBackNpc(npcNum, target, skillnum);
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    break;
                                }

                            case (int)SkillType.HealHp:
                            case (int)SkillType.HealMp:
                            case (int)SkillType.DamageMp:
                                {
                                    if (Types.Skill[skillnum].Type == (int)SkillType.HealHp)
                                    {
                                        vitalType = (int)VitalType.HP;
                                        increment = true;
                                    }
                                    else if (Types.Skill[skillnum].Type == (int)SkillType.HealMp)
                                    {
                                        vitalType = (int)VitalType.MP;
                                        increment = true;
                                    }
                                    else if (Types.Skill[skillnum].Type == (int)SkillType.DamageMp)
                                    {
                                        vitalType = (int)VitalType.MP;
                                        increment = false;
                                    }

                                    didCast = true;
                                    var loopTo1 = S_GameLogic.GetPlayersOnline();
                                    for (i = 1; i <= loopTo1; i++)
                                    {
                                        if (S_NetworkConfig.IsPlaying(i) && S_Players.GetPlayerMap(i) == S_Players.GetPlayerMap(npcNum))
                                        {
                                            if (S_Players.IsInRange(aoe, x, y, S_Players.GetPlayerX(i), S_Players.GetPlayerY(i)))
                                                SkillPlayer_Effect(vitalType, increment, i, vital, skillnum);
                                        }
                                    }
                                    for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                                    {
                                        if (modTypes.MapNpc[mapNum].Npc[i].Num > 0 && modTypes.MapNpc[mapNum].Npc[i].Vital[(int)VitalType.HP] > 0)
                                        {
                                            if (S_Players.IsInRange(aoe, x, y, modTypes.MapNpc[mapNum].Npc[i].X, modTypes.MapNpc[mapNum].Npc[i].Y))
                                                SkillNpc_Effect(vitalType, increment, i, vital, skillnum, mapNum);
                                        }
                                    }

                                    break;
                                }
                        }

                        break;
                    }

                case 2: // targetted
                    {
                        targetType = modTypes.MapNpc[mapNum].Npc[npcNum].TargetType;
                        target = modTypes.MapNpc[mapNum].Npc[npcNum].Target;

                        if (targetType == 0 || target == 0)
                            return;

                        if (modTypes.MapNpc[mapNum].Npc[npcNum].TargetType == (int)TargetType.Player)
                        {
                            x = S_Players.GetPlayerX(target);
                            y = S_Players.GetPlayerY(target);
                        }
                        else
                        {
                            x = modTypes.MapNpc[mapNum].Npc[target].X;
                            y = modTypes.MapNpc[mapNum].Npc[target].Y;
                        }

                        if (!S_Players.IsInRange(range, modTypes.MapNpc[mapNum].Npc[npcNum].X, modTypes.MapNpc[mapNum].Npc[npcNum].Y, x, y))
                            return;

                        switch (Types.Skill[skillnum].Type)
                        {
                            case (int)SkillType.DamageHp:
                                {
                                    if (modTypes.MapNpc[mapNum].Npc[npcNum].TargetType == (int)TargetType.Player)
                                    {
                                        if (S_Npc.CanNpcAttackPlayer(npcNum, target) && vital > 0)
                                        {
                                            S_Animations.SendAnimation(mapNum, Types.Skill[skillnum].SkillAnim, 0, 0, (int)TargetType.Player, target);
                                            S_NetworkSend.PlayerMsg(target, Microsoft.VisualBasic.Strings.Trim(Types.Npc[modTypes.MapNpc[mapNum].Npc[npcNum].Num].Name) + " uses " + Microsoft.VisualBasic.Strings.Trim(Types.Skill[skillnum].Name) + "!", (int)ColorType.Yellow);
                                            SkillPlayer_Effect((byte)VitalType.HP, false, target, vital, skillnum);
                                            didCast = true;
                                        }
                                    }
                                    else if (S_Players.CanPlayerAttackNpc(npcNum, target, true) && vital > 0)
                                    {
                                        S_Animations.SendAnimation(mapNum, Types.Skill[skillnum].SkillAnim, 0, 0, (int)TargetType.Npc, target);
                                        SkillNpc_Effect((byte)VitalType.HP, false, i, vital, skillnum, mapNum);

                                        if (Types.Skill[skillnum].KnockBack == 1)
                                            S_Npc.KnockBackNpc(npcNum, target, skillnum);
                                        didCast = true;
                                    }

                                    break;
                                }

                            case (int)SkillType.DamageMp:
                            case (int)SkillType.HealMp:
                            case (int)SkillType.HealHp:
                                {
                                    if (Types.Skill[skillnum].Type == (int)SkillType.DamageMp)
                                    {
                                        vitalType = (int)VitalType.MP;
                                        increment = false;
                                    }
                                    else if (Types.Skill[skillnum].Type == (int)SkillType.HealMp)
                                    {
                                        vitalType = (int)VitalType.MP;
                                        increment = true;
                                    }
                                    else if (Types.Skill[skillnum].Type == (int)SkillType.HealHp)
                                    {
                                        vitalType = (int)VitalType.HP;
                                        increment = true;
                                    }

                                    if (modTypes.TempPlayer[npcNum].TargetType == (int)TargetType.Player)
                                    {
                                        if (Types.Skill[skillnum].Type == (int)SkillType.DamageMp)
                                        {
                                            if (S_Players.CanPlayerAttackPlayer(npcNum, target, true))
                                                SkillPlayer_Effect(vitalType, increment, target, vital, skillnum);
                                        }
                                        else
                                            SkillPlayer_Effect(vitalType, increment, target, vital, skillnum);
                                    }
                                    else if (Types.Skill[skillnum].Type == (int)SkillType.DamageMp)
                                    {
                                        if (S_Players.CanPlayerAttackNpc(npcNum, target, true))
                                            SkillNpc_Effect(vitalType, increment, target, vital, skillnum, mapNum);
                                    }
                                    else
                                        SkillNpc_Effect(vitalType, increment, target, vital, skillnum, mapNum);
                                    break;
                                }
                        }

                        break;
                    }

                case 4: // Projectile
                    {
                        S_Projectiles.PlayerFireProjectile(npcNum, skillnum);

                        didCast = true;
                        break;
                    }
            }

            if (didCast)
            {
                modTypes.MapNpc[mapNum].Npc[npcNum].Vital[(int)VitalType.MP] = modTypes.MapNpc[mapNum].Npc[npcNum].Vital[(int)VitalType.MP] - mpCost;
                S_Npc.SendMapNpcVitals(mapNum, (byte)npcNum);
                modTypes.MapNpc[mapNum].Npc[npcNum].SkillCd[skillslot] = S_General.GetTimeMs() + (Types.Skill[skillnum].CdTime * 1000);
            }
        }

        internal static void SkillPlayer_Effect(byte vital, bool increment, int index, int damage, int skillnum)
        {
            string sSymbol;
            int colour = 0;

            if (damage > 0)
            {
                // Calculate for Magic Resistance.
                damage = damage - ((S_Players.GetPlayerStat(index, (StatType)(((int)StatType.Spirit) * 2)) + (S_Players.GetPlayerLevel(index) * 3)));

                if (increment)
                {
                    sSymbol = "+";
                    if (vital == (int)VitalType.HP)
                        colour = (int)ColorType.BrightGreen;
                    if (vital == (int)VitalType.MP)
                        colour = (int)ColorType.BrightBlue;
                }
                else
                {
                    sSymbol = "-";
                    colour = (int)ColorType.BrightRed;
                }

                // Deal with stun effects.
                if (Types.Skill[skillnum].StunDuration > 0)
                    S_Players.StunPlayer(index, skillnum);

                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(index), sSymbol + damage, colour, (int)ActionMsgType.Scroll, S_Players.GetPlayerX(index) * 32, S_Players.GetPlayerY(index) * 32);
                if (increment)
                    S_Players.SetPlayerVital(index, (VitalType)vital, S_Players.GetPlayerVital(index, (VitalType)vital) + damage);
                if (!increment)
                    S_Players.SetPlayerVital(index, (VitalType)vital, S_Players.GetPlayerVital(index, (VitalType)vital) - damage);
                S_NetworkSend.SendVital(index, (VitalType)vital);
            }
        }

        internal static void SkillNpc_Effect(byte vital, bool increment, int index, int damage, int skillnum, int mapNum)
        {
            string sSymbol;
            int color = 0;

            if (index <= 0 || index > Constants.MAX_MAP_NPCS || damage < 0 || modTypes.MapNpc[mapNum].Npc[index].Vital[vital] <= 0)
                return;

            if (damage > 0)
            {
                if (increment)
                {
                    sSymbol = "+";
                    if (vital == (int)VitalType.HP)
                        color = (int)ColorType.BrightGreen;
                    if (vital == (int)VitalType.MP)
                        color = (int)ColorType.BrightBlue;
                }
                else
                {
                    sSymbol = "-";
                    color = (int)ColorType.BrightRed;
                }

                // Deal with Stun and Knockback effects.
                if (Types.Skill[skillnum].KnockBack == 1)
                    S_Npc.KnockBackNpc(index, index, skillnum);
                if (Types.Skill[skillnum].StunDuration > 0)
                    S_Players.StunNPC(index, mapNum, skillnum);

                S_NetworkSend.SendActionMsg(mapNum, sSymbol + damage, color, (int)ActionMsgType.Scroll, modTypes.MapNpc[mapNum].Npc[index].X * 32, modTypes.MapNpc[mapNum].Npc[index].Y * 32);
                if (increment)
                    modTypes.MapNpc[mapNum].Npc[index].Vital[vital] = modTypes.MapNpc[mapNum].Npc[index].Vital[vital] + damage;
                if (!increment)
                    modTypes.MapNpc[mapNum].Npc[index].Vital[vital] = modTypes.MapNpc[mapNum].Npc[index].Vital[vital] - damage;
                S_Npc.SendMapNpcVitals(mapNum, (byte)index);
            }
        }
    }
}
