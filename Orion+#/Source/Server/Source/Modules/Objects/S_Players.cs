using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Linq;
using ASFW;
using static Engine.Enums;
using static Engine.Types;
using static Engine.modTypes;

namespace Engine
{
    static class S_Players
    {
        public static bool CanPlayerAttackPlayer(int Attacker, int Victim, bool IsSkill = false)
        {
            if (!IsSkill)
            {
                // Check attack timer
                if (GetPlayerEquipment(Attacker, Enums.EquipmentType.Weapon) > 0)
                {
                    if (S_General.GetTimeMs() < modTypes.TempPlayer[Attacker].AttackTimer + Types.Item[GetPlayerEquipment(Attacker, Enums.EquipmentType.Weapon)].Speed)
                        return false;
                }
                else if (S_General.GetTimeMs() < modTypes.TempPlayer[Attacker].AttackTimer + 1000)
                    return false;
            }

            // Check for subscript out of range
            if (!S_NetworkConfig.IsPlaying(Victim))
                return false;

            // Make sure they are on the same map
            if (!(GetPlayerMap(Attacker) == GetPlayerMap(Victim)))
                return false;

            // Make sure we dont attack the player if they are switching maps
            if (modTypes.TempPlayer[Victim].GettingMap == 1)
                return false;

            if (!IsSkill)
            {
                // Check if at same coordinates
                switch (GetPlayerDir(Attacker))
                {
                    case (byte)Enums.DirectionType.Up:
                    case (byte)Enums.DirectionType.UpLeft:
                    case (byte)Enums.DirectionType.UpRight:
                        {
                            if (!((GetPlayerY(Victim) + 1 == GetPlayerY(Attacker)) && (GetPlayerX(Victim) == GetPlayerX(Attacker))))
                                return false;
                            break;
                        }

                    case (byte)Enums.DirectionType.Down:
                    case (byte)Enums.DirectionType.DownLeft:
                    case (byte)Enums.DirectionType.DownRight:
                        {
                            if (!((GetPlayerY(Victim) - 1 == GetPlayerY(Attacker)) && (GetPlayerX(Victim) == GetPlayerX(Attacker))))
                                return false;
                            break;
                        }

                    case (byte)Enums.DirectionType.Left:
                        {
                            if (!((GetPlayerY(Victim) == GetPlayerY(Attacker)) && (GetPlayerX(Victim) + 1 == GetPlayerX(Attacker))))
                                return false;
                            break;
                        }

                    case (byte)Enums.DirectionType.Right:
                        {
                            if (!((GetPlayerY(Victim) == GetPlayerY(Attacker)) && (GetPlayerX(Victim) - 1 == GetPlayerX(Attacker))))
                                return false;
                            break;
                        }

                    default:
                        {
                            return false;
                        }
                }
            }

            // Check if map is attackable
            if (!(modTypes.Map[GetPlayerMap(Attacker)].Moral == (byte)Enums.MapMoralType.None))
            {
                if (GetPlayerPK(Victim) == 0)
                {
                    S_NetworkSend.PlayerMsg(Attacker, "This is a safe zone!", (int)Enums.ColorType.BrightRed);
                    return false;
                }
            }

            // Make sure they have more then 0 hp
            if (GetPlayerVital(Victim, Enums.VitalType.HP) <= 0)
                return false;

            // Check to make sure that they dont have access
            if (GetPlayerAccess(Attacker) > (byte)Enums.AdminType.Monitor)
            {
                S_NetworkSend.PlayerMsg(Attacker, "You cannot attack any player for thou art an admin!", (int)Enums.ColorType.BrightRed);
                return false;
            }

            // Check to make sure the victim isn't an admin
            if (GetPlayerAccess(Victim) > (byte)Enums.AdminType.Monitor)
            {
                S_NetworkSend.PlayerMsg(Attacker, "You cannot attack " + GetPlayerName(Victim) + "!", (int)Enums.ColorType.BrightRed);
                return false;
            }

            // Make sure attacker is high enough level
            if (GetPlayerLevel(Attacker) < 10)
            {
                S_NetworkSend.PlayerMsg(Attacker, "You are below level 10, you cannot attack another player yet!", (int)Enums.ColorType.BrightRed);
                return false;
            }

            // Make sure victim is high enough level
            if (GetPlayerLevel(Victim) < 10)
            {
                S_NetworkSend.PlayerMsg(Attacker, GetPlayerName(Victim) + " is below level 10, you cannot attack this player yet!", (int)Enums.ColorType.BrightRed);
                return false;
            }

            return true;
        }

        public static bool CanPlayerBlockHit(int index)
        {
            int i;
            int n;
            int ShieldSlot;
            ShieldSlot = GetPlayerEquipment(index, Enums.EquipmentType.Shield);

            bool CanPlayerBlockHit = false;

            if (ShieldSlot > 0)
            {
                n = (byte)Conversion.Int(VBMathClone.Rnd() * 2);

                if (n == 1)
                {
                    i = (GetPlayerStat(index, Enums.StatType.Endurance) / 2) + (GetPlayerLevel(index) / 2);
                    n = (byte)Conversion.Int(VBMathClone.Rnd() * 100) + 1;

                    if (n <= i)
                        CanPlayerBlockHit = true;
                }
            }
            return CanPlayerBlockHit;
        }

        public static bool CanPlayerCriticalHit(int index)
        {
            
            int i;
            int n;
            bool CanPlayerCriticalHit = false;
            if (GetPlayerEquipment(index, Enums.EquipmentType.Weapon) > 0)
            {
                n = (byte)(VBMathClone.Rnd()) * 2;

                if (n == 1)
                {
                    i = (GetPlayerStat(index, Enums.StatType.Strength) / 2) + (GetPlayerLevel(index) / 2);
                    n = (byte)Conversion.Int(VBMathClone.Rnd() * 100) + 1;

                    if (n <= i)
                        CanPlayerCriticalHit = true;
                }
            }
            return CanPlayerCriticalHit;
        }

        public static int GetPlayerDamage(int index)
        {
            int weaponNum;

            int GetPlayerDamage = 0;

            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(index) == false || index <= 0 || index > Constants.MAX_PLAYERS)
                return 0;

            if (GetPlayerEquipment(index, Enums.EquipmentType.Weapon) > 0)
            {
                weaponNum = GetPlayerEquipment(index, Enums.EquipmentType.Weapon);
                GetPlayerDamage = (GetPlayerStat(index, Enums.StatType.Strength) * 2) + (Types.Item[weaponNum].Data2 * 2) + (GetPlayerLevel(index) * 3) + S_GameLogic.Random(0, 20);
            }
            else
                GetPlayerDamage = (GetPlayerStat(index, Enums.StatType.Strength) * 2) + (GetPlayerLevel(index) * 3) + S_GameLogic.Random(0, 20);
            return GetPlayerDamage;
        }

        public static int GetPlayerProtection(int index)
        {
            int Armor;
            int Helm;
            int Shoes;
            int Gloves;
            int GetPlayerProtection = 0;

            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(index) == false || index <= 0 || index > Constants.MAX_PLAYERS)
                return 0;

            Armor = GetPlayerEquipment(index, Enums.EquipmentType.Armor);
            Helm = GetPlayerEquipment(index, Enums.EquipmentType.Helmet);
            Shoes = GetPlayerEquipment(index, Enums.EquipmentType.Shoes);
            Gloves = GetPlayerEquipment(index, Enums.EquipmentType.Gloves);
            GetPlayerProtection = (GetPlayerStat(index, Enums.StatType.Endurance) / 5);

            if (Armor > 0)
                GetPlayerProtection = GetPlayerProtection + Types.Item[Armor].Data2;

            if (Helm > 0)
                GetPlayerProtection = GetPlayerProtection + Types.Item[Helm].Data2;

            if (Shoes > 0)
                GetPlayerProtection = GetPlayerProtection + Types.Item[Shoes].Data2;

            if (Gloves > 0)
                GetPlayerProtection = GetPlayerProtection + Types.Item[Gloves].Data2;
            return GetPlayerProtection;
        }

        public static void AttackPlayer(int Attacker, int Victim, int Damage, int skillnum = 0, int npcnum = 0)
        {
            int exp;
            int mapNum;
            int n;
            ByteStream buffer;

            if (npcnum == 0)
            {
                // Check for subscript out of range
                if (S_NetworkConfig.IsPlaying(Attacker) == false || S_NetworkConfig.IsPlaying(Victim) == false || Damage < 0)
                    return;

                // Check for weapon
                n = 0;

                if (GetPlayerEquipment(Attacker, Enums.EquipmentType.Weapon) > 0)
                    n = GetPlayerEquipment(Attacker, Enums.EquipmentType.Weapon);

                // Send this packet so they can see the person attacking
                buffer = new ByteStream(4);
                buffer.WriteInt32((int)Packets.ServerPackets.SAttack);
                buffer.WriteInt32(Attacker);
                S_NetworkConfig.SendDataToMapBut(Attacker, GetPlayerMap(Attacker), ref buffer.Data, buffer.Head);
                buffer.Dispose();

                if (Damage >= GetPlayerVital(Victim, Enums.VitalType.HP))
                {
                    S_NetworkSend.SendActionMsg(GetPlayerMap(Victim), "-" + Damage, (int)Enums.ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32));

                    // Player is dead
                    S_NetworkSend.GlobalMsg(GetPlayerName(Victim) + " has been killed by " + GetPlayerName(Attacker));
                    // Calculate exp to give attacker
                    exp = (GetPlayerExp(Victim) / 10);

                    // Make sure we dont get less then 0
                    if (exp < 0)
                        exp = 0;

                    if (exp == 0)
                    {
                        S_NetworkSend.PlayerMsg(Victim, "You lost no exp.", (int)Enums.ColorType.BrightGreen);
                        S_NetworkSend.PlayerMsg(Attacker, "You received no exp.", (int)Enums.ColorType.BrightRed);
                    }
                    else
                    {
                        SetPlayerExp(Victim, GetPlayerExp(Victim) - exp);
                        S_NetworkSend.SendExp(Victim);
                        S_NetworkSend.PlayerMsg(Victim, "You lost " + exp + " exp.", (int)Enums.ColorType.BrightRed);
                        SetPlayerExp(Attacker, GetPlayerExp(Attacker) + exp);
                        S_NetworkSend.SendExp(Attacker);
                        S_NetworkSend.PlayerMsg(Attacker, "You received " + exp + " exp.", (int)Enums.ColorType.BrightGreen);
                    }

                    // Check for a level up
                    CheckPlayerLevelUp(Attacker);

                    // Check if target is player who died and if so set target to 0
                    if (modTypes.TempPlayer[Attacker].TargetType == (byte)Enums.TargetType.Player)
                    {
                        if (modTypes.TempPlayer[Attacker].Target == Victim)
                        {
                            modTypes.TempPlayer[Attacker].Target = 0;
                            modTypes.TempPlayer[Attacker].TargetType = (byte)Enums.TargetType.None;
                        }
                    }

                    if (GetPlayerPK(Victim) == 0)
                    {
                        if (GetPlayerPK(Attacker) == 0)
                        {
                            SetPlayerPK(Attacker, 1);
                            S_NetworkSend.SendPlayerData(Attacker);
                            S_NetworkSend.GlobalMsg(GetPlayerName(Attacker) + " has been deemed a Player Killer!!!");
                        }
                    }
                    else
                        S_NetworkSend.GlobalMsg(GetPlayerName(Victim) + " has paid the price for being a Player Killer!!!");

                    OnDeath(Victim);
                }
                else
                {
                    // Player not dead, just do the damage
                    SetPlayerVital(Victim, Enums.VitalType.HP, GetPlayerVital(Victim, Enums.VitalType.HP) - Damage);
                    S_NetworkSend.SendVital(Victim, Enums.VitalType.HP);
                    S_NetworkSend.SendActionMsg(GetPlayerMap(Victim), "-" + Damage, (int)Enums.ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32));

                    // if a stunning skill, stun the player
                    if (skillnum > 0)
                    {
                        if (Types.Skill[skillnum].StunDuration > 0)
                            StunPlayer(Victim, skillnum);
                    }
                }

                // Reset attack timer
                modTypes.TempPlayer[Attacker].AttackTimer = S_General.GetTimeMs();
            }
            else
            {
                // Check for subscript out of range
                if (S_NetworkConfig.IsPlaying(Victim) == false || Damage < 0)
                    return;

                mapNum = GetPlayerMap(Victim);

                // Send this packet so they can see the person attacking
                buffer = new ByteStream(4);
                buffer.WriteInt32((int)Packets.ServerPackets.SNpcAttack);
                buffer.WriteInt32(Attacker);
                S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                buffer.Dispose();

                if (Damage >= GetPlayerVital(Victim, Enums.VitalType.HP))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "-" + Damage, (int)Enums.ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32));

                    // Player is dead
                    S_NetworkSend.GlobalMsg(GetPlayerName(Victim) + " has been killed by " + Types.Npc[modTypes.MapNpc[mapNum].Npc[Attacker].Num].Name);

                    // Check if target is player who died and if so set target to 0
                    if (modTypes.TempPlayer[Attacker].TargetType == (byte)Enums.TargetType.Player)
                    {
                        if (modTypes.TempPlayer[Attacker].Target == Victim)
                        {
                            modTypes.TempPlayer[Attacker].Target = 0;
                            modTypes.TempPlayer[Attacker].TargetType = (byte)Enums.TargetType.None;
                        }
                    }

                    OnDeath(Victim);
                }
                else
                {
                    // Player not dead, just do the damage
                    SetPlayerVital(Victim, Enums.VitalType.HP, GetPlayerVital(Victim, Enums.VitalType.HP) - Damage);
                    S_NetworkSend.SendVital(Victim, Enums.VitalType.HP);
                    S_NetworkSend.SendActionMsg(mapNum, "-" + Damage, (int)Enums.ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32));

                    // if a stunning skill, stun the player
                    if (skillnum > 0)
                    {
                        if (Types.Skill[skillnum].StunDuration > 0)
                            StunPlayer(Victim, skillnum);
                    }
                }

                // Reset attack timer
                modTypes.MapNpc[mapNum].Npc[Attacker].AttackTimer = S_General.GetTimeMs();
            }
        }

        internal static void StunPlayer(int index, int skillnum)
        {
            // check if it's a stunning skill
            if (Types.Skill[skillnum].StunDuration > 0)
            {
                // set the values on index
                modTypes.TempPlayer[index].StunDuration = Types.Skill[skillnum].StunDuration;
                modTypes.TempPlayer[index].StunTimer = S_General.GetTimeMs();
                // send it to the index
                S_NetworkSend.SendStunned(index);
                // tell him he's stunned
                S_NetworkSend.PlayerMsg(index, "You have been stunned!", (int)Enums.ColorType.Yellow);
            }
        }

        public static bool CanPlayerAttackNpc(int Attacker, int MapNpcNum, bool IsSkill = false)
        {
            int mapNum = 0;
            int NpcNum = 0;
            int atkX = 0;
            int atkY = 0;
            int attackspeed = 0;

            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(Attacker) == false || MapNpcNum <= 0 || MapNpcNum > Constants.MAX_MAP_NPCS)
                return false;

            // Check for subscript out of range
            if (modTypes.MapNpc[GetPlayerMap(Attacker)].Npc[MapNpcNum].Num <= 0)
                return false;

            mapNum = GetPlayerMap(Attacker);
            NpcNum = modTypes.MapNpc[mapNum].Npc[MapNpcNum].Num;

            // Make sure the npc isn't already dead
            if (modTypes.MapNpc[mapNum].Npc[MapNpcNum].Vital[(byte)Enums.VitalType.HP] <= 0)
                return false;

            // Make sure they are on the same map
            if (S_NetworkConfig.IsPlaying(Attacker))
            {

                // attack speed from weapon
                if (GetPlayerEquipment(Attacker, Enums.EquipmentType.Weapon) > 0)
                    attackspeed = Types.Item[GetPlayerEquipment(Attacker, Enums.EquipmentType.Weapon)].Speed;
                else
                    attackspeed = 1000;

                if (NpcNum > 0 && S_General.GetTimeMs() > modTypes.TempPlayer[Attacker].AttackTimer + attackspeed)
                {

                    // exit out early
                    if (IsSkill)
                    {
                        if (Types.Npc[NpcNum].Behaviour != (byte)Enums.NpcBehavior.Friendly && Types.Npc[NpcNum].Behaviour != (byte)Enums.NpcBehavior.ShopKeeper)
                        {
                            return true;
                        }
                    }

                    // Check if at same coordinates
                    switch (GetPlayerDir(Attacker))
                    {
                        case (byte)Enums.DirectionType.Up:
                        case (byte)Enums.DirectionType.UpLeft:
                        case (byte)Enums.DirectionType.UpRight:
                            {
                                atkX = GetPlayerX(Attacker);
                                atkY = GetPlayerY(Attacker) - 1;
                                break;
                            }

                        case (byte)Enums.DirectionType.Down:
                        case (byte)Enums.DirectionType.DownLeft:
                        case (byte)Enums.DirectionType.DownRight:
                            {
                                atkX = GetPlayerX(Attacker);
                                atkY = GetPlayerY(Attacker) + 1;
                                break;
                            }

                        case (byte)Enums.DirectionType.Left:
                            {
                                atkX = GetPlayerX(Attacker) - 1;
                                atkY = GetPlayerY(Attacker);
                                break;
                            }

                        case (byte)Enums.DirectionType.Right:
                            {
                                atkX = GetPlayerX(Attacker) + 1;
                                atkY = GetPlayerY(Attacker);
                                break;
                            }
                    }

                    if (atkX == modTypes.MapNpc[mapNum].Npc[MapNpcNum].X)
                    {
                        if (atkY == modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y)
                        {
                            if (Types.Npc[NpcNum].Behaviour != (byte)Enums.NpcBehavior.Friendly && Types.Npc[NpcNum].Behaviour != (byte)Enums.NpcBehavior.ShopKeeper && Types.Npc[NpcNum].Behaviour != (byte)Enums.NpcBehavior.Quest)
                                return true;
                            else
                            {
                                if (Types.Npc[NpcNum].Behaviour == (byte)Enums.NpcBehavior.Quest)
                                {
                                    if (S_Quest.QuestCompleted(Attacker, Types.Npc[NpcNum].QuestNum))
                                    {
                                        S_NetworkSend.PlayerMsg(Attacker, Microsoft.VisualBasic.Strings.Trim(Types.Npc[NpcNum].Name) + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[NpcNum].AttackSay), (int)Enums.ColorType.Yellow);
                                        return false;
                                    }
                                    else if (!S_Quest.CanStartQuest(Attacker, Types.Npc[NpcNum].QuestNum) && !S_Quest.QuestInProgress(Attacker, Types.Npc[NpcNum].QuestNum))
                                    {
                                        S_Quest.CheckTasks(Attacker, (int)Enums.QuestType.Talk, NpcNum);
                                        S_Quest.CheckTasks(Attacker, (int)Enums.QuestType.Give, NpcNum);
                                        S_Quest.CheckTasks(Attacker, (int)Enums.QuestType.Fetch, NpcNum);
                                        return false;
                                    }
                                    else if (S_Quest.QuestInProgress(Attacker, Types.Npc[NpcNum].QuestNum))
                                    {
                                        S_Quest.CheckTasks(Attacker, (int)Enums.QuestType.Talk, NpcNum);
                                        S_Quest.CheckTasks(Attacker, (int)Enums.QuestType.Give, NpcNum);
                                        S_Quest.CheckTasks(Attacker, (int)Enums.QuestType.Fetch, NpcNum);
                                        return false;
                                    }
                                    else
                                    {
                                        S_Quest.ShowQuest(Attacker, Types.Npc[NpcNum].QuestNum);
                                        return false;
                                    }
                                }
                                else if (Types.Npc[NpcNum].Behaviour == (byte)Enums.NpcBehavior.Friendly || Types.Npc[NpcNum].Behaviour == (byte)Enums.NpcBehavior.ShopKeeper)
                                {
                                    S_Quest.CheckTasks(Attacker, (int)Enums.QuestType.Talk, NpcNum);
                                    S_Quest.CheckTasks(Attacker, (int)Enums.QuestType.Give, NpcNum);
                                    S_Quest.CheckTasks(Attacker, (int)Enums.QuestType.Fetch, NpcNum);
                                }
                                if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Npc[NpcNum].AttackSay)) > 0)
                                    S_NetworkSend.PlayerMsg(Attacker, Microsoft.VisualBasic.Strings.Trim(Types.Npc[NpcNum].Name) + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Npc[NpcNum].AttackSay), (int)Enums.ColorType.Yellow);
                            }
                        }
                    }
                }
            }
            return false;
        }

        internal static void StunNPC(int index, int mapNum, int skillnum)
        {
            // check if it's a stunning skill
            if (Types.Skill[skillnum].StunDuration > 0)
            {
                // set the values on index
                modTypes.MapNpc[mapNum].Npc[index].StunDuration = Types.Skill[skillnum].StunDuration;
                modTypes.MapNpc[mapNum].Npc[index].StunTimer = S_General.GetTimeMs();
            }
        }

        public static void PlayerAttackNpc(int Attacker, int MapNpcNum, int Damage)
        {
            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(Attacker) == false || MapNpcNum <= 0 || MapNpcNum > Constants.MAX_MAP_NPCS || Damage < 0)
                return;

            var MapNum = GetPlayerMap(Attacker);
            var NpcNum = modTypes.MapNpc[MapNum].Npc[MapNpcNum].Num;
            var Name = Types.Npc[NpcNum].Name.Trim();

            // Check for weapon
            var Weapon = 0;
            if (GetPlayerEquipment(Attacker, Enums.EquipmentType.Weapon) > 0)
                Weapon = GetPlayerEquipment(Attacker, Enums.EquipmentType.Weapon);

            // Deal damage to our NPC.
            modTypes.MapNpc[MapNum].Npc[MapNpcNum].Vital[(byte)Enums.VitalType.HP] = modTypes.MapNpc[MapNum].Npc[MapNpcNum].Vital[(byte)Enums.VitalType.HP] - Damage;

            // Set the NPC target to the player so they can come after them.
            modTypes.MapNpc[MapNum].Npc[MapNpcNum].TargetType = (byte)Enums.TargetType.Player;
            modTypes.MapNpc[MapNum].Npc[MapNpcNum].Target = Attacker;

            // Check for any mobs on the map with the Guard behaviour so they can come after our player.
            if (Types.Npc[modTypes.MapNpc[MapNum].Npc[MapNpcNum].Num].Behaviour == (byte)Enums.NpcBehavior.Guard)
            {
                foreach (var Guard in modTypes.MapNpc[MapNum].Npc.Where(x => x.Num == modTypes.MapNpc[MapNum].Npc[MapNpcNum].Num).Select((x, y) => y + 1).ToArray())
                {
                    modTypes.MapNpc[MapNum].Npc[Guard].Target = Attacker;
                    modTypes.MapNpc[MapNum].Npc[Guard].TargetType = (byte)Enums.TargetType.Player;
                }
            }

            // Send our general visual stuff.
            S_NetworkSend.SendActionMsg(MapNum, "-" + Damage, (int)Enums.ColorType.BrightRed, 1, (modTypes.MapNpc[MapNum].Npc[MapNpcNum].X * 32), (modTypes.MapNpc[MapNum].Npc[MapNpcNum].Y * 32));
            S_NetworkSend.SendBlood(GetPlayerMap(Attacker), modTypes.MapNpc[MapNum].Npc[MapNpcNum].X, modTypes.MapNpc[MapNum].Npc[MapNpcNum].Y);
            S_NetworkSend.SendPlayerAttack(Attacker);
            if (Weapon > 0)
                S_Animations.SendAnimation(MapNum, Types.Item[GetPlayerEquipment(Attacker, Enums.EquipmentType.Weapon)].Animation, 0, 0, (byte)Enums.TargetType.Npc, MapNpcNum);

            // Reset our attack timer.
            modTypes.TempPlayer[Attacker].AttackTimer = S_General.GetTimeMs();

            if (!S_Npc.IsNpcDead(MapNum, MapNpcNum))
            {
                // Check if our NPC has something to share with our player.
                if (modTypes.MapNpc[MapNum].Npc[MapNpcNum].Target == 0)
                {
                    if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Npc[NpcNum].AttackSay)) > 0)
                        S_NetworkSend.PlayerMsg(Attacker, string.Format("{0} says: '{1}'", Types.Npc[NpcNum].Name.Trim(), Types.Npc[NpcNum].AttackSay.Trim()), (int)Enums.ColorType.Yellow);
                }

                S_Npc.SendMapNpcTo(MapNum, MapNpcNum);
            }
            else
                HandlePlayerKillNpc(MapNum, Attacker, MapNpcNum);
        }

        public static bool IsInRange(int range, int x1, int y1, int x2, int y2)
        {
            int nVal;
            bool IsInRange = false;
            nVal = (int)Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2));
            if (nVal <= range)
                IsInRange = true;
            return IsInRange;
        }

        internal static void SpellPlayer_Effect(byte Vital, bool increment, int index, int Damage, int Skillnum)
        {
            string sSymbol;
            int Colour = 0;

            if (Damage > 0)
            {
                if (increment)
                {
                    sSymbol = "+";
                    if (Vital == (byte)Enums.VitalType.HP)
                        Colour = (int)Enums.ColorType.BrightGreen;
                    if (Vital == (byte)Enums.VitalType.MP)
                        Colour = (int)Enums.ColorType.BrightBlue;
                }
                else
                {
                    sSymbol = "-";
                    Colour = (int)Enums.ColorType.Blue;
                }

                S_Animations.SendAnimation(GetPlayerMap(index), Types.Skill[Skillnum].SkillAnim, 0, 0, (byte)Enums.TargetType.Player, index);
                S_NetworkSend.SendActionMsg(GetPlayerMap(index), sSymbol + Damage, Colour, (byte)Enums.ActionMsgType.Scroll, GetPlayerX(index) * 32, GetPlayerY(index) * 32);

                // send the sound
                // SendMapSound Index, GetPlayerX(Index), GetPlayerY(Index), SoundEntity.seSpell, Spellnum

                if (increment)
                {
                    SetPlayerVital(index, (VitalType)Vital, GetPlayerVital(index, (VitalType)Vital) + Damage);

                    if (Types.Skill[Skillnum].Duration > 0)
                    {
                    }
                }
                else if (!increment)
                    SetPlayerVital(index, (VitalType)Vital, GetPlayerVital(index, (VitalType)Vital) - Damage);

                S_NetworkSend.SendVital(index, (VitalType)Vital);
            }
        }

        internal static bool CanPlayerDodge(int index)
        {
            int rate;
            int rndNum;

            bool CanPlayerDodge = false;

            rate = GetPlayerStat(index, Enums.StatType.Luck) / (int)4;
            rndNum = S_GameLogic.Random(1, 100);

            if (rndNum <= rate)
                CanPlayerDodge = true;
            return CanPlayerDodge;
        }

        internal static bool CanPlayerParry(int index)
        {
            int rate;
            int rndNum;

            bool CanPlayerParry = false;

            rate = GetPlayerStat(index, Enums.StatType.Luck) / (int)6;
            rndNum = S_GameLogic.Random(1, 100);

            if (rndNum <= rate)
                CanPlayerParry = true;
            return CanPlayerParry;
        }

        internal static void TryPlayerAttackPlayer(int Attacker, int Victim)
        {
            int mapNum = 0;
            int Damage = 0;
            int i = 0;
            int armor = 0;

            Damage = 0;

            // Can we attack the player?
            if (CanPlayerAttackPlayer(Attacker, Victim))
            {
                mapNum = GetPlayerMap(Attacker);

                // check if NPC can avoid the attack
                if (CanPlayerDodge(Victim))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Dodge!", (int)Enums.ColorType.Pink, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32));
                    return;
                }

                if (CanPlayerParry(Victim))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Parry!", (int)Enums.ColorType.Pink, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32));
                    return;
                }

                // Get the damage we can do
                Damage = GetPlayerDamage(Attacker);

                if (CanPlayerBlockHit(Victim))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Block!", (int)Enums.ColorType.BrightCyan, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32));
                    Damage = 0;
                    return;
                }
                else
                {
                    for (i = 1; i <= (byte)Enums.EquipmentType.Count - 1; i++)
                    {
                        if (GetPlayerEquipment(Victim, (EquipmentType)i) > 0)
                            armor = armor + Types.Item[GetPlayerEquipment(Victim, (EquipmentType)i)].Data2;
                    }

                    // take away armour
                    Damage = Damage - ((GetPlayerStat(Victim, Enums.StatType.Spirit) * 2) + (GetPlayerLevel(Victim) * 3) + armor);

                    // * 1.5 if it's a crit!
                    if (CanPlayerCriticalHit(Attacker))
                    {
                        Damage = (int)(Damage * 1.5);
                        S_NetworkSend.SendActionMsg(mapNum, "Critical!", (int)Enums.ColorType.BrightCyan, 1, (GetPlayerX(Attacker) * 32), (GetPlayerY(Attacker) * 32));
                    }
                }

                if (Damage > 0)
                    PlayerAttackPlayer(Attacker, Victim, Damage);
                else
                    S_NetworkSend.PlayerMsg(Attacker, "Your attack does nothing.", (int)Enums.ColorType.BrightRed);
            }
        }

        public static void PlayerAttackPlayer(int Attacker, int Victim, int Damage)
        {
            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(Attacker) == false || S_NetworkConfig.IsPlaying(Victim) == false || Damage <= 0)
                return;

            // Check if our assailant has a weapon.
            var Weapon = 0;
            if (GetPlayerEquipment(Attacker, Enums.EquipmentType.Weapon) > 0)
                Weapon = GetPlayerEquipment(Attacker, Enums.EquipmentType.Weapon);

            // Stop our player's regeneration abilities.
            modTypes.TempPlayer[Attacker].StopRegen = 1;
            modTypes.TempPlayer[Attacker].StopRegenTimer = S_General.GetTimeMs();

            // Deal damage to our player.
            SetPlayerVital(Victim, Enums.VitalType.HP, GetPlayerVital(Victim, Enums.VitalType.HP) - Damage);

            // Send all the visuals to our player.
            if (Weapon > 0)
                S_Animations.SendAnimation(GetPlayerMap(Victim), Types.Item[Weapon].Animation, 0, 0, (byte)Enums.TargetType.Player, Victim);
            S_NetworkSend.SendActionMsg(GetPlayerMap(Victim), "-" + Damage, (int)Enums.ColorType.BrightRed, 1, (GetPlayerX(Victim) * 32), (GetPlayerY(Victim) * 32));
            S_NetworkSend.SendBlood(GetPlayerMap(Victim), GetPlayerX(Victim), GetPlayerY(Victim));

            // set the regen timer
            modTypes.TempPlayer[Victim].StopRegen = 1;
            modTypes.TempPlayer[Victim].StopRegenTimer = S_General.GetTimeMs();

            // Reset attack timer
            modTypes.TempPlayer[Attacker].AttackTimer = S_General.GetTimeMs();

            if (!IsPlayerDead(Victim))
            {
                // Send our player's new vitals to everyone that needs them.
                S_NetworkSend.SendVital(Victim, Enums.VitalType.HP);
                if (modTypes.TempPlayer[Victim].InParty > 0)
                    S_Parties.SendPartyVitals(modTypes.TempPlayer[Victim].InParty, Victim);
            }
            else
                // Handle our dead player.
                HandlePlayerKillPlayer(Attacker, Victim);
        }

        internal static void TryPlayerAttackNpc(int index, int mapnpcnum)
        {
            int npcnum;

            int mapNum;

            int Damage;

            Damage = 0;

            // Can we attack the npc?
            if (CanPlayerAttackNpc(index, mapnpcnum))
            {
                mapNum = GetPlayerMap(index);
                npcnum = modTypes.MapNpc[mapNum].Npc[mapnpcnum].Num;

                // check if NPC can avoid the attack
                if (S_Npc.CanNpcDodge(npcnum))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Dodge!", (int)Enums.ColorType.Pink, 1, (modTypes.MapNpc[mapNum].Npc[mapnpcnum].X * 32), (modTypes.MapNpc[mapNum].Npc[mapnpcnum].Y * 32));
                    return;
                }

                if (S_Npc.CanNpcParry(npcnum))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Parry!", (int)Enums.ColorType.Pink, 1, (modTypes.MapNpc[mapNum].Npc[mapnpcnum].X * 32), (modTypes.MapNpc[mapNum].Npc[mapnpcnum].Y * 32));
                    return;
                }

                // Get the damage we can do
                Damage = GetPlayerDamage(index);

                if (S_Npc.CanNpcBlock(npcnum))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Block!", (int)Enums.ColorType.BrightCyan, 1, (modTypes.MapNpc[mapNum].Npc[mapnpcnum].X * 32), (modTypes.MapNpc[mapNum].Npc[mapnpcnum].Y * 32));
                    Damage = 0;
                    return;
                }
                else
                {
                    Damage = Damage - ((Types.Npc[npcnum].Stat[(byte)Enums.StatType.Spirit] * 2) + (Types.Npc[npcnum].Level * 3));

                    // * 1.5 if it's a crit!
                    if (CanPlayerCriticalHit(index))
                    {
                        Damage = (int)(Damage * 1.5);
                        S_NetworkSend.SendActionMsg(mapNum, "Critical!", (int)Enums.ColorType.BrightCyan, 1, (GetPlayerX(index) * 32), (GetPlayerY(index) * 32));
                    }
                }

                modTypes.TempPlayer[index].Target = mapnpcnum;
                modTypes.TempPlayer[index].TargetType = (byte)Enums.TargetType.Npc;
                S_NetworkSend.SendTarget(index, mapnpcnum, (byte)Enums.TargetType.Npc);

                if (Damage > 0)
                    PlayerAttackNpc(index, mapnpcnum, Damage);
                else
                    S_NetworkSend.PlayerMsg(index, "Your attack does nothing.", (int)Enums.ColorType.BrightRed);
            }
        }

        internal static bool IsPlayerDead(int index)
        {
            bool IsPlayerDead = false;
            if (index < 0 || index > Constants.MAX_PLAYERS || !modTypes.TempPlayer[index].InGame)
                return false;
            if (GetPlayerVital(index, Enums.VitalType.HP) <= 0)
                IsPlayerDead = true;
            return IsPlayerDead;
        }

        internal static void HandlePlayerKillPlayer(int Attacker, int Victim)
        {
            // Notify everyone that our player has bit the dust.
            S_NetworkSend.GlobalMsg(string.Format("{0} has been killed by {1}!", GetPlayerName(Victim), GetPlayerName(Attacker)));

            // Hand out player experience
            HandlePlayerKillExperience(Attacker, Victim);

            // Handle our PK outcomes.
            HandlePlayerKilledPK(Attacker, Victim);

            // Remove our player from everyone's target list.
            foreach (var p in modTypes.TempPlayer.Where((x, i) => x.InGame && GetPlayerMap(i + 1) == GetPlayerMap(Victim) && x.TargetType == (byte)Enums.TargetType.Player && x.Target == Victim).Select((x, i) => i + 1).ToArray())
            {
                modTypes.TempPlayer[p].Target = 0;
                modTypes.TempPlayer[p].TargetType = (byte)Enums.TargetType.None;
                S_NetworkSend.SendTarget(p, 0, (byte)Enums.TargetType.None);
            }

            // Actually kill the player.
            OnDeath(Victim);

            // Handle our quest system stuff.
            S_Quest.CheckTasks(Attacker, (int)Enums.QuestType.Kill, 0);
        }

        internal static void HandlePlayerKillNpc(int mapNum, int index, int MapNpcNum)
        {
            // Set our attacker's target to nothing.
            S_NetworkSend.SendTarget(index, 0, (byte)Enums.TargetType.None);

            // Hand out player experience
            HandleNpcKillExperience(index, modTypes.MapNpc[mapNum].Npc[MapNpcNum].Num);

            // Drop items if we can.
            S_Npc.DropNpcItems(mapNum, MapNpcNum);

            // Handle quest tasks related to NPC death
            S_Quest.CheckTasks(index, (int)Enums.QuestType.Slay, modTypes.MapNpc[mapNum].Npc[MapNpcNum].Num);

            // Set our NPC's data to default so we know it's dead.
            modTypes.MapNpc[mapNum].Npc[MapNpcNum].Num = 0;
            modTypes.MapNpc[mapNum].Npc[MapNpcNum].SpawnWait = S_General.GetTimeMs();
            modTypes.MapNpc[mapNum].Npc[MapNpcNum].Vital[(byte)Enums.VitalType.HP] = 0;

            // Notify all our clients that the NPC has died.
            S_Npc.SendNpcDead(mapNum, MapNpcNum);

            // Check if our dead NPC is targetted by another player and remove their targets.
            foreach (var p in modTypes.TempPlayer.Where((x, i) => x.InGame && GetPlayerMap(i + 1) == mapNum && x.TargetType == (byte)Enums.TargetType.Npc && x.Target == MapNpcNum).Select((x, i) => i + 1).ToArray())
            {
                modTypes.TempPlayer[p].Target = 0;
                modTypes.TempPlayer[p].TargetType = (byte)Enums.TargetType.None;
                S_NetworkSend.SendTarget(p, 0, (byte)Enums.TargetType.None);
            }
        }

        internal static void HandlePlayerKilledPK(int Attacker, int Victim)
        {
            int z = 0;
            int eqcount = 0;
            // TODO: Redo this method, it is horrendous.
            int invcount = 0, j = 0;
            if (GetPlayerPK(Victim) == 0)
            {
                if (GetPlayerPK(Attacker) == 0)
                {
                    SetPlayerPK(Attacker, 1);
                    S_NetworkSend.SendPlayerData(Attacker);
                    S_NetworkSend.GlobalMsg(GetPlayerName(Attacker) + " has been deemed a Player Killer!!!");
                }
            }
            else
                S_NetworkSend.GlobalMsg(GetPlayerName(Victim) + " has paid the price for being a Player Killer!!!");

            if (GetPlayerLevel(Victim) >= 10)
            {
                for (z = 1; z <= Constants.MAX_INV; z++)
                {
                    if (GetPlayerInvItemNum(Victim, z) > 0)
                        invcount = invcount + 1;
                }

                for (z = 1; z <= (byte)Enums.EquipmentType.Count - 1; z++)
                {
                    if (GetPlayerEquipment(Victim, (EquipmentType)z) > 0)
                        eqcount = eqcount + 1;
                }
                z = S_GameLogic.Random(1, invcount + eqcount);

                if (z == 0)
                    z = 1;
                if (z > invcount + eqcount)
                    z = invcount + eqcount;
                if (z > invcount)
                {
                    z = z - invcount;

                    for (var x = 1; x <= (byte)Enums.EquipmentType.Count - 1; x++)
                    {
                        if (GetPlayerEquipment(Victim, (EquipmentType)x) > 0)
                        {
                            j = j + 1;

                            if (j == z)
                            {
                                // Here it is, drop this piece of equipment!
                                S_NetworkSend.PlayerMsg(Victim, "In death you lost grip on your " + Microsoft.VisualBasic.Strings.Trim(Types.Item[GetPlayerEquipment(Victim, (EquipmentType)x)].Name), (int)Enums.ColorType.BrightRed);
                                S_Items.SpawnItem(GetPlayerEquipment(Victim, (EquipmentType)x), 1, GetPlayerMap(Victim), GetPlayerX(Victim), GetPlayerY(Victim));
                                SetPlayerEquipment(Victim, 0, (EquipmentType)x);
                                S_NetworkSend.SendWornEquipment(Victim);
                                S_NetworkSend.SendMapEquipment(Victim);
                            }
                        }
                    }
                }
                else
                    for (var x = 1; x <= Constants.MAX_INV; x++)
                    {
                        if (GetPlayerInvItemNum(Victim, x) > 0)
                        {
                            j = j + 1;

                            if (j == z)
                            {
                                // Here it is, drop this item!
                                S_NetworkSend.PlayerMsg(Victim, "In death you lost grip on your " + Microsoft.VisualBasic.Strings.Trim(Types.Item[GetPlayerInvItemNum(Victim, x)].Name), (int)Enums.ColorType.BrightRed);
                                S_Items.SpawnItem(GetPlayerInvItemNum(Victim, x), GetPlayerInvItemValue(Victim, x), GetPlayerMap(Victim), GetPlayerX(Victim), GetPlayerY(Victim));
                                SetPlayerInvItemNum(Victim, x, 0);
                                SetPlayerInvItemValue(Victim, x, 0);
                                S_NetworkSend.SendInventory(Victim);
                            }
                        }
                    }
            }
        }



        public static string GetPlayerLogin(int index)
        {
            return Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Login);
        }

        public static string GetPlayerName(int index)
        {
            if (index > Constants.MAX_PLAYERS)
                return string.Empty;
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Name.Trim();
        }

        public static void SetPlayerAccess(int index, int Access)
        {
            modTypes.Player[index].Access = (byte)Access;
        }

        public static void SetPlayerSprite(int index, int Sprite)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Sprite = Sprite;
        }

        public static int GetPlayerMaxVital(int index, Enums.VitalType Vital)
        {
            int GetPlayerMaxVital = 0;

            if (index > Constants.MAX_PLAYERS)
                return 0;

            switch (Vital)
            {
                case Enums.VitalType.HP:
                    {
                        GetPlayerMaxVital = (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Level + (GetPlayerStat(index, Enums.StatType.Vitality) / 2) + Types.Classes[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Classes].Stat[(byte)Enums.StatType.Vitality]) * 2;
                        break;
                    }

                case Enums.VitalType.MP:
                    {
                        GetPlayerMaxVital = (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Level + (GetPlayerStat(index, Enums.StatType.Intelligence) / 2) + Types.Classes[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Classes].Stat[(byte)Enums.StatType.Intelligence]) * 2;
                        break;
                    }

                case Enums.VitalType.SP:
                    {
                        GetPlayerMaxVital = (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Level + (GetPlayerStat(index, Enums.StatType.Spirit) / 2) + Types.Classes[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Classes].Stat[(byte)Enums.StatType.Spirit]) * 2;
                        break;
                    }
            }
            return GetPlayerMaxVital;
        }

        internal static int GetPlayerStat(int index, Enums.StatType Stat)
        {
            int x;
            int i;

            int GetPlayerStat = 0;

            if (index > Constants.MAX_PLAYERS)
                return 0;

            x = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Stat[(int)Stat];

            for (i = 1; i <= (byte)Enums.EquipmentType.Count - 1; i++)
            {
                if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Equipment[i] > 0)
                {
                    if (Types.Item[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Equipment[i]].Add_Stat[(int)Stat] > 0)
                        x = x + Types.Item[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Equipment[i]].Add_Stat[(int)Stat];
                }
            }

            GetPlayerStat = x;
            return GetPlayerStat;
        }

        public static int GetPlayerAccess(int index)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;
            return modTypes.Player[index].Access;
        }

        public static int GetPlayerMap(int index)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Map;
        }

        public static int GetPlayerX(int index)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].X;
        }

        public static int GetPlayerY(int index)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Y;
        }

        public static int GetPlayerDir(int index)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Dir;
        }

        public static int GetPlayerSprite(int index)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Sprite;
        }

        public static int GetPlayerPK(int index)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pk;
        }

        public static int GetPlayerEquipment(int index, Enums.EquipmentType EquipmentSlot)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;
            if (EquipmentSlot == 0)
                return 0;
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Equipment[(byte)EquipmentSlot];
        }

        public static void SetPlayerEquipment(int index, int InvNum, Enums.EquipmentType EquipmentSlot)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Equipment[(byte)EquipmentSlot] = InvNum;
        }

        public static void SetPlayerDir(int index, int Dir)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Dir = (byte)Dir;
        }

        public static void SetPlayerVital(int index, Enums.VitalType Vital, int Value)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Vital[(byte)Vital] = Value;

            if (GetPlayerVital(index, Vital) > GetPlayerMaxVital(index, Vital))
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Vital[(byte)Vital] = GetPlayerMaxVital(index, Vital);

            if (GetPlayerVital(index, Vital) < 0)
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Vital[(byte)Vital] = 0;
        }

        internal static bool IsDirBlocked(ref byte Blockvar, ref byte Dir)
        {
            return !(~Blockvar <= 0 || Math.Pow(2.0, (double)Dir) == 0.0);
        }

        public static int GetPlayerVital(int index, Enums.VitalType Vital)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Vital[(byte)Vital];
        }

        public static int GetPlayerLevel(int index)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Level;
        }

        public static int GetPlayerPOINTS(int index)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Points;
        }

        public static int GetPlayerNextLevel(int index)
        {
            return ((GetPlayerLevel(index) + 1) * (GetPlayerStat(index, Enums.StatType.Strength) + GetPlayerStat(index, Enums.StatType.Endurance) + GetPlayerStat(index, Enums.StatType.Intelligence) + GetPlayerStat(index, Enums.StatType.Spirit) + GetPlayerPOINTS(index)) + S_Constants.StatPtsPerLvl) * Types.Classes[GetPlayerClass(index)].BaseExp; // 25
        }

        public static int GetPlayerExp(int index)
        {
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Exp;
        }

        public static void SetPlayerMap(int index, int mapNum)
        {
            if (mapNum > 0 && mapNum <= S_Instances.MAX_CACHED_MAPS)
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Map = mapNum;
        }

        public static void SetPlayerX(int index, int X)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].X = (byte)X;
        }

        public static void SetPlayerY(int index, int Y)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Y = (byte)Y;
        }

        public static void SetPlayerExp(int index, int Exp)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Exp = Exp;
        }

        internal static int GetPlayerRawStat(int index, Enums.StatType Stat)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;

            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Stat[(byte)Stat];
        }

        internal static void SetPlayerStat(int index, Enums.StatType Stat, int Value)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Stat[(byte)Stat] = (byte)Value;
        }

        public static void SetPlayerLevel(int index, int Level)
        {
            if (Level > Constants.MAX_LEVELS)
                return;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Level = Level;
        }

        public static void SetPlayerPOINTS(int index, int Points)
        {
            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Points + Points > Constants.MAX_POINTS)
            {
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Points = Constants.MAX_POINTS;
            }
            else
            {
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Points = Points;
            }
        }

        public static void CheckPlayerLevelUp(int index)
        {
            int expRollover;
            int level_count;

            level_count = 0;

            while (GetPlayerExp(index) >= GetPlayerNextLevel(index))
            {
                expRollover = GetPlayerExp(index) - GetPlayerNextLevel(index);
                SetPlayerLevel(index, GetPlayerLevel(index) + 1);
                SetPlayerPOINTS(index, GetPlayerPOINTS(index) + 3);
                SetPlayerExp(index, expRollover);
                level_count = level_count + 1;
            }

            if (level_count > 0)
            {
                if (level_count == 1)
                    // singular
                    S_NetworkSend.GlobalMsg(GetPlayerName(index) + " has gained " + level_count + " level!");
                else
                    // plural
                    S_NetworkSend.GlobalMsg(GetPlayerName(index) + " has gained " + level_count + " levels!");
                S_NetworkSend.SendExp(index);
                S_NetworkSend.SendPlayerData(index);
            }
        }

        public static int GetPlayerClass(int index)
        {
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Classes;
        }

        public static void SetPlayerPK(int index, int PK)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Pk = (byte)PK;
        }



        internal static void HandleUseChar(int index)
        {
            if (!S_NetworkConfig.IsPlaying(index))
            {
                JoinGame(index);
                var text = string.Format("{0} | {1} has began playing {2}.", GetPlayerLogin(index), GetPlayerName(index), modTypes.Options.GameName);
                modDatabase.Addlog(text, S_Constants.PLAYER_LOG);
                Console.WriteLine(text);
            }
        }



        public static void SendLeaveMap(int index, int mapNum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SLeftMap);
            buffer.WriteInt32(index);
            S_NetworkConfig.SendDataToMapBut(index, mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }



        public static void PlayerWarp(int index, int MapNum, int X, int Y, bool HouseTeleport = false, bool NoInstance = false)
        {
            int OldMap;
            int i;
            ByteStream buffer;

            if (modTypes.Map[MapNum].Instanced == 1 & NoInstance == false)
            {
                MapNum = S_Instances.CreateInstance(MapNum); // AndAlso MAP_NUMBER_MASK)
                if (MapNum == -1)
                {
                    // Couldn't create instanced map!
                    MapNum = GetPlayerMap(index);
                    X = GetPlayerX(index);
                    Y = GetPlayerY(index);
                    S_NetworkSend.AlertMsg(index, "Unable to create a cached map!");
                }
                else
                {
                    // store old info, for returning to entrance of instance
                    if (!(modTypes.TempPlayer[index].InInstance == 1))
                    {
                        modTypes.TempPlayer[index].TmpMap = GetPlayerMap(index);
                        modTypes.TempPlayer[index].TmpX = GetPlayerX(index);
                        modTypes.TempPlayer[index].TmpY = GetPlayerY(index);
                        modTypes.TempPlayer[index].InInstance = 1;
                    }
                    MapNum = MapNum + Constants.MAX_MAPS;
                }
            }

            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(index) == false || MapNum <= 0 || MapNum > S_Instances.MAX_CACHED_MAPS)
                return;

            // Check if you are out of bounds
            if (X > modTypes.Map[MapNum].MaxX)
                X = modTypes.Map[MapNum].MaxX;
            if (Y > modTypes.Map[MapNum].MaxY)
                Y = modTypes.Map[MapNum].MaxY;

            modTypes.TempPlayer[index].EventProcessingCount = 0;
            modTypes.TempPlayer[index].EventMap.CurrentEvents = 0;

            if (HouseTeleport == false)
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse = 0;

            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse > 0)
            {
                if (S_NetworkConfig.IsPlaying(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse))
                {
                    if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse != modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse)
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse = 0;
                        PlayerWarp(index, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastMap, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastX, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastY);
                        return;
                    }
                    else
                        S_Housing.SendFurnitureToHouse(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse);
                }
            }

            // clear target
            modTypes.TempPlayer[index].Target = 0;
            modTypes.TempPlayer[index].TargetType = (byte)Enums.TargetType.None;
            S_NetworkSend.SendTarget(index, 0, (byte)Enums.TargetType.None);

            // Save old map to send erase player data to
            OldMap = GetPlayerMap(index);

            if (OldMap != MapNum)
                SendLeaveMap(index, OldMap);

            SetPlayerMap(index, MapNum);
            SetPlayerX(index, X);
            SetPlayerY(index, Y);
            if (S_Pets.PetAlive(index))
            {
                S_Pets.SetPetX(index, X);
                S_Pets.SetPetY(index, Y);
                modTypes.TempPlayer[index].PetTarget = 0;
                modTypes.TempPlayer[index].PetTargetType = 0;
                S_Pets.SendPetXy(index, X, Y);
            }

            S_NetworkSend.SendPlayerXY(index);

            // send equipment of all people on new map
            if (S_GameLogic.GetTotalMapPlayers(MapNum) > 0)
            {
                var loopTo = S_GameLogic.GetPlayersOnline();
                for (i = 1; i <= loopTo; i++)
                {
                    if (S_NetworkConfig.IsPlaying(i))
                    {
                        if (GetPlayerMap(i) == MapNum)
                            S_NetworkSend.SendMapEquipmentTo(i, index);
                    }
                }
            }

            // Now we check if there were any players left on the map the player just left, and if not stop processing npcs
            if (S_GameLogic.GetTotalMapPlayers(OldMap) == 0)
            {
                modTypes.PlayersOnMap[OldMap] = 0;

                if (S_Instances.IsInstancedMap(OldMap))
                    S_Instances.DestroyInstancedMap(OldMap - Constants.MAX_MAPS);

                // Regenerate all NPCs' health
                for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                {
                    if (modTypes.MapNpc[OldMap].Npc[i].Num > 0)
                        modTypes.MapNpc[OldMap].Npc[i].Vital[(byte)Enums.VitalType.HP] = S_GameLogic.GetNpcMaxVital(modTypes.MapNpc[OldMap].Npc[i].Num, Enums.VitalType.HP);
                }
            }

            // Sets it so we know to process npcs on the map
            modTypes.PlayersOnMap[MapNum] = 1;
            modTypes.TempPlayer[index].GettingMap = 1;

            S_Quest.CheckTasks(index, (int)Enums.QuestType.Reach, MapNum);

            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SCheckForMap);
            buffer.WriteInt32(MapNum);
            buffer.WriteInt32(modTypes.Map[MapNum].Revision);
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void PlayerMove(int index, int Dir, int Movement, bool ExpectingWarp)
        {
            int mapNum = 0;
            ByteStream Buffer;
            int x = 0;
            int y = 0;
            bool begineventprocessing = false;
            bool Moved = false;
            bool DidWarp = false;
            byte NewMapX = 0;
            byte NewMapY = 0;
            int VitalType = 0;
            int Colour = 0;
            int amount = 0;

            // Check for subscript out of range
            //if (S_NetworkConfig.IsPlaying(index) == false || Dir < (byte)Enums.DirectionType.Up || Dir > (byte)Enums.DirectionType.Right || Movement < 1 || Movement > 2)
            // 8 Directional Movement
            if (S_NetworkConfig.IsPlaying(index) == false || Dir < (byte)Enums.DirectionType.Up || Dir > (byte)Enums.DirectionType.DownRight || Movement < 1 || Movement > 2)
                return;

            SetPlayerDir(index, Dir);
            Moved = false;
            mapNum = GetPlayerMap(index);

            switch (Dir)
            {
                case (byte)Enums.DirectionType.Up:
                    {
                        // Check to make sure not outside of boundries
                        if (GetPlayerY(index) > 0)
                        {
                            // Check to make sure that the tile is walkable
                            byte directionRef = ((int)Enums.DirectionType.Up + 1);
                            if (!IsDirBlocked(ref modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].DirBlock, ref directionRef))
                            {
                                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index) - 1].Type != (byte)Enums.TileType.Blocked)
                                {
                                    if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index) - 1].Type != (byte)Enums.TileType.Resource)
                                    {
                                        // Check to see if the tile is a key and if it is check if its opened
                                        if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index) - 1].Type != (byte)Enums.TileType.Key || (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index) - 1].Type == (byte)Enums.TileType.Key && modTypes.TempTile[GetPlayerMap(index)].DoorOpen[GetPlayerX(index), GetPlayerY(index) - 1] == 1))
                                        {
                                            SetPlayerY(index, GetPlayerY(index) - 1);
                                            S_NetworkSend.SendPlayerMove(index, Movement);
                                            Moved = true;
                                        }

                                        var loopTo = modTypes.TempPlayer[index].EventMap.CurrentEvents;

                                        // check for event
                                        for (var i = 1; i <= loopTo; i++)
                                        {
                                            if (modTypes.TempPlayer[index].EventMap.EventPages[i].X == GetPlayerX(index) && modTypes.TempPlayer[index].EventMap.EventPages[i].Y == GetPlayerY(index) - 1)
                                            {
                                                if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].Trigger == 1)
                                                {
                                                    // PlayerMsg(Index, "OnTouch event", ColorType.Red)
                                                    // Process this event, it is on-touch and everything checks out.
                                                    if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount > 0)
                                                    {
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurList = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurSlot = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].EventId = modTypes.TempPlayer[index].EventMap.EventPages[i].EventId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].PageId = modTypes.TempPlayer[index].EventMap.EventPages[i].PageId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].WaitingForResponse = 0;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ListLeftOff = new int[modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount + 1];

                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Active = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ActionTimer = S_General.GetTimeMs();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else if (modTypes.Map[GetPlayerMap(index)].Up > 0)
                        {
                            NewMapY = modTypes.Map[modTypes.Map[GetPlayerMap(index)].Up].MaxY;
                            PlayerWarp(index, modTypes.Map[GetPlayerMap(index)].Up, GetPlayerX(index), NewMapY);
                            DidWarp = true;
                            Moved = true;
                        }

                        break;
                    }

                case (byte)Enums.DirectionType.Down:
                    {

                        // Check to make sure not outside of boundries
                        if (GetPlayerY(index) < modTypes.Map[mapNum].MaxY)
                        {

                            // Check to make sure that the tile is walkable
                            byte directionRef = (int)(Enums.DirectionType.Down + 1);
                            if (!IsDirBlocked(ref modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].DirBlock, ref directionRef))
                            {
                                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index) + 1].Type != (byte)Enums.TileType.Blocked)
                                {
                                    if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index) + 1].Type != (byte)Enums.TileType.Resource)
                                    {

                                        // Check to see if the tile is a key and if it is check if its opened
                                        if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index) + 1].Type != (byte)Enums.TileType.Key || (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index) + 1].Type == (byte)Enums.TileType.Key && modTypes.TempTile[GetPlayerMap(index)].DoorOpen[GetPlayerX(index), GetPlayerY(index) + 1] == 1))
                                        {
                                            SetPlayerY(index, GetPlayerY(index) + 1);
                                            S_NetworkSend.SendPlayerMove(index, Movement);
                                            Moved = true;
                                        }

                                        var loopTo1 = modTypes.TempPlayer[index].EventMap.CurrentEvents;

                                        // check for event
                                        for (var i = 1; i <= loopTo1; i++)
                                        {
                                            if (modTypes.TempPlayer[index].EventMap.EventPages[i].X == GetPlayerX(index) && modTypes.TempPlayer[index].EventMap.EventPages[i].Y == GetPlayerY(index) + 1)
                                            {
                                                if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].Trigger == 1)
                                                {
                                                    // PlayerMsg(Index, "OnTouch event", ColorType.Red)
                                                    // Process this event, it is on-touch and everything checks out.
                                                    if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount > 0)
                                                    {
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurList = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurSlot = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].EventId = modTypes.TempPlayer[index].EventMap.EventPages[i].EventId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].PageId = modTypes.TempPlayer[index].EventMap.EventPages[i].PageId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].WaitingForResponse = 0;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ListLeftOff = new int[modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount + 1];

                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Active = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ActionTimer = S_General.GetTimeMs();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else

                            // Check to see if we can move them to the another map
                            if (modTypes.Map[GetPlayerMap(index)].Down > 0)
                        {
                            PlayerWarp(index, modTypes.Map[GetPlayerMap(index)].Down, GetPlayerX(index), 0);
                            DidWarp = true;
                            Moved = true;
                        }

                        break;
                    }

                case (byte)Enums.DirectionType.Left:
                    {

                        // Check to make sure not outside of boundries
                        if (GetPlayerX(index) > 0)
                        {

                            // Check to make sure that the tile is walkable
                            byte directionRef = (int)(Enums.DirectionType.Left + 1);
                            if (!IsDirBlocked(ref modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].DirBlock, ref directionRef))
                            {
                                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) - 1, GetPlayerY(index)].Type != (byte)Enums.TileType.Blocked)
                                {
                                    if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) - 1, GetPlayerY(index)].Type != (byte)Enums.TileType.Resource)
                                    {

                                        // Check to see if the tile is a key and if it is check if its opened
                                        if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) - 1, GetPlayerY(index)].Type != (byte)Enums.TileType.Key || (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) - 1, GetPlayerY(index)].Type == (byte)Enums.TileType.Key && modTypes.TempTile[GetPlayerMap(index)].DoorOpen[GetPlayerX(index) - 1, GetPlayerY(index)] == 1))
                                        {
                                            SetPlayerX(index, GetPlayerX(index) - 1);
                                            S_NetworkSend.SendPlayerMove(index, Movement);
                                            Moved = true;
                                        }

                                        var loopTo2 = modTypes.TempPlayer[index].EventMap.CurrentEvents;

                                        // check for event
                                        for (var i = 1; i <= loopTo2; i++)
                                        {
                                            if (modTypes.TempPlayer[index].EventMap.EventPages[i].X == GetPlayerX(index) - 1 && modTypes.TempPlayer[index].EventMap.EventPages[i].Y == GetPlayerY(index))
                                            {
                                                if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].Trigger == 1)
                                                {
                                                    // PlayerMsg(Index, "OnTouch event", ColorType.Red)
                                                    // Process this event, it is on-touch and everything checks out.
                                                    if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount > 0)
                                                    {
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurList = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurSlot = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].EventId = modTypes.TempPlayer[index].EventMap.EventPages[i].EventId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].PageId = modTypes.TempPlayer[index].EventMap.EventPages[i].PageId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].WaitingForResponse = 0;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ListLeftOff = new int[modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount + 1];

                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Active = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ActionTimer = S_General.GetTimeMs();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else

                            // Check to see if we can move them to the another map
                            if (modTypes.Map[GetPlayerMap(index)].Left > 0)
                        {
                            NewMapX = modTypes.Map[modTypes.Map[GetPlayerMap(index)].Left].MaxX;
                            PlayerWarp(index, modTypes.Map[GetPlayerMap(index)].Left, NewMapX, GetPlayerY(index));
                            DidWarp = true;
                            Moved = true;
                        }

                        break;
                    }

                case (byte)Enums.DirectionType.Right:
                    {

                        // Check to make sure not outside of boundries
                        if (GetPlayerX(index) < modTypes.Map[mapNum].MaxX)
                        {

                            // Check to make sure that the tile is walkable
                            byte directionRef = (int)(Enums.DirectionType.Right + 1);
                            if (!IsDirBlocked(ref modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].DirBlock, ref directionRef))
                            {
                                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) + 1, GetPlayerY(index)].Type != (byte)Enums.TileType.Blocked)
                                {
                                    if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) + 1, GetPlayerY(index)].Type != (byte)Enums.TileType.Resource)
                                    {

                                        // Check to see if the tile is a key and if it is check if its opened
                                        if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) + 1, GetPlayerY(index)].Type != (byte)Enums.TileType.Key || (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) + 1, GetPlayerY(index)].Type == (byte)Enums.TileType.Key && modTypes.TempTile[GetPlayerMap(index)].DoorOpen[GetPlayerX(index) + 1, GetPlayerY(index)] == 1))
                                        {
                                            SetPlayerX(index, GetPlayerX(index) + 1);
                                            S_NetworkSend.SendPlayerMove(index, Movement);
                                            Moved = true;
                                        }

                                        var loopTo3 = modTypes.TempPlayer[index].EventMap.CurrentEvents;

                                        // check for event
                                        for (var i = 1; i <= loopTo3; i++)
                                        {
                                            if (modTypes.TempPlayer[index].EventMap.EventPages[i].X == GetPlayerX(index) && modTypes.TempPlayer[index].EventMap.EventPages[i].Y == GetPlayerY(index))
                                            {
                                                if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].Trigger == 1)
                                                {
                                                    // PlayerMsg(Index, "OnTouch event", ColorType.Red)
                                                    // Process this event, it is on-touch and everything checks out.
                                                    if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount > 0)
                                                    {
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurList = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurSlot = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].EventId = modTypes.TempPlayer[index].EventMap.EventPages[i].EventId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].PageId = modTypes.TempPlayer[index].EventMap.EventPages[i].PageId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].WaitingForResponse = 0;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ListLeftOff = new int[modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount + 1];

                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Active = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ActionTimer = S_General.GetTimeMs();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else

                            // Check to see if we can move them to the another map
                            if (modTypes.Map[GetPlayerMap(index)].Right > 0)
                        {
                            PlayerWarp(index, modTypes.Map[GetPlayerMap(index)].Right, 0, GetPlayerY(index));
                            DidWarp = true;
                            Moved = true;
                        }

                        break;
                    }


                // 8 Directional Movement
                case (byte)Enums.DirectionType.UpLeft:
                    {
                        // Check to make sure not outside of boundries
                        if (GetPlayerY(index) > 0 && GetPlayerX(index) > 0)
                        {
                            // Check to make sure that the tile is walkable
                            byte directionRef = (int)(Enums.DirectionType.UpLeft + 1);
                            if (!IsDirBlocked(ref modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].DirBlock, ref directionRef))
                            {
                                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) - 1, GetPlayerY(index) - 1].Type != (byte)Enums.TileType.Blocked)
                                {
                                    if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) - 1, GetPlayerY(index) - 1].Type != (byte)Enums.TileType.Resource)
                                    {

                                        // Check to see if the tile is a key and if it is check if its opened
                                        if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) - 1, GetPlayerY(index) - 1].Type != (byte)Enums.TileType.Key || (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) - 1, GetPlayerY(index) - 1].Type == (byte)Enums.TileType.Key && modTypes.TempTile[GetPlayerMap(index)].DoorOpen[GetPlayerX(index) - 1, GetPlayerY(index) - 1] == 1))
                                        {
                                            SetPlayerX(index, GetPlayerX(index) - 1);
                                            SetPlayerY(index, GetPlayerY(index) - 1);
                                            S_NetworkSend.SendPlayerMove(index, Movement);
                                            Moved = true;
                                        }

                                        var loopTo3 = modTypes.TempPlayer[index].EventMap.CurrentEvents;

                                        // check for event
                                        for (var i = 1; i <= loopTo3; i++)
                                        {
                                            if (modTypes.TempPlayer[index].EventMap.EventPages[i].X == GetPlayerX(index) - 1 && modTypes.TempPlayer[index].EventMap.EventPages[i].Y == GetPlayerY(index) - 1)
                                            {
                                                if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].Trigger == 1)
                                                {
                                                    // PlayerMsg(Index, "OnTouch event", ColorType.Red)
                                                    // Process this event, it is on-touch and everything checks out.
                                                    if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount > 0)
                                                    {
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurList = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurSlot = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].EventId = modTypes.TempPlayer[index].EventMap.EventPages[i].EventId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].PageId = modTypes.TempPlayer[index].EventMap.EventPages[i].PageId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].WaitingForResponse = 0;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ListLeftOff = new int[modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount + 1];

                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Active = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ActionTimer = S_General.GetTimeMs();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else // Check to see if we can move them to the another map
                        if (modTypes.Map[GetPlayerMap(index)].Up > 0 && modTypes.Map[GetPlayerMap(index)].Left > 0)
                        {
                            PlayerWarp(index, modTypes.Map[GetPlayerMap(index)].Up, GetPlayerX(index), Map[Map[GetPlayerMap(index)].Up].MaxY);
                            DidWarp = true;
                            Moved = true;
                        }

                        break;
                    }

                case (byte)Enums.DirectionType.UpRight:
                    {
                        // Check to make sure not outside of boundries
                        if (GetPlayerY(index) > 0 && GetPlayerX(index) < modTypes.Map[mapNum].MaxX)
                        {
                            // Check to make sure that the tile is walkable
                            byte directionRef = (int)(Enums.DirectionType.UpRight + 1);
                            if (!IsDirBlocked(ref modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].DirBlock, ref directionRef))
                            {
                                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) + 1, GetPlayerY(index) - 1].Type != (byte)Enums.TileType.Blocked)
                                {
                                    if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) + 1, GetPlayerY(index) - 1].Type != (byte)Enums.TileType.Resource)
                                    {

                                        // Check to see if the tile is a key and if it is check if its opened
                                        if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) + 1, GetPlayerY(index) - 1].Type != (byte)Enums.TileType.Key || (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) + 1, GetPlayerY(index) - 1].Type == (byte)Enums.TileType.Key && modTypes.TempTile[GetPlayerMap(index)].DoorOpen[GetPlayerX(index) + 1, GetPlayerY(index) - 1] == 1))
                                        {
                                            SetPlayerX(index, GetPlayerX(index) + 1);
                                            SetPlayerY(index, GetPlayerY(index) - 1);
                                            S_NetworkSend.SendPlayerMove(index, Movement);
                                            Moved = true;
                                        }

                                        var loopTo3 = modTypes.TempPlayer[index].EventMap.CurrentEvents;

                                        // check for event
                                        for (var i = 1; i <= loopTo3; i++)
                                        {
                                            if (modTypes.TempPlayer[index].EventMap.EventPages[i].X == GetPlayerX(index) + 1 && modTypes.TempPlayer[index].EventMap.EventPages[i].Y == GetPlayerY(index) - 1)
                                            {
                                                if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].Trigger == 1)
                                                {
                                                    // PlayerMsg(Index, "OnTouch event", ColorType.Red)
                                                    // Process this event, it is on-touch and everything checks out.
                                                    if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount > 0)
                                                    {
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurList = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurSlot = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].EventId = modTypes.TempPlayer[index].EventMap.EventPages[i].EventId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].PageId = modTypes.TempPlayer[index].EventMap.EventPages[i].PageId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].WaitingForResponse = 0;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ListLeftOff = new int[modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount + 1];

                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Active = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ActionTimer = S_General.GetTimeMs();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else // Check to see if we can move them to the another map
                        if (modTypes.Map[GetPlayerMap(index)].Up > 0 && modTypes.Map[GetPlayerMap(index)].Right > 0)
                        {
                            PlayerWarp(index, modTypes.Map[GetPlayerMap(index)].Up, GetPlayerX(index), Map[Map[GetPlayerMap(index)].Up].MaxY);
                            DidWarp = true;
                            Moved = true;
                        }

                        break;
                    }

                case (byte)Enums.DirectionType.DownLeft:
                    {
                        // Check to make sure not outside of boundries
                        if (GetPlayerY(index) < modTypes.Map[GetPlayerMap(index)].MaxY && GetPlayerX(index) > 0)
                        {
                            // Check to make sure that the tile is walkable
                            byte directionRef = (int)(Enums.DirectionType.DownLeft + 1);
                            if (!IsDirBlocked(ref modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].DirBlock, ref directionRef))
                            {
                                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) - 1, GetPlayerY(index) + 1].Type != (byte)Enums.TileType.Blocked)
                                {
                                    if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) - 1, GetPlayerY(index) + 1].Type != (byte)Enums.TileType.Resource)
                                    {

                                        // Check to see if the tile is a key and if it is check if its opened
                                        if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) - 1, GetPlayerY(index) + 1].Type != (byte)Enums.TileType.Key || (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) - 1, GetPlayerY(index) + 1].Type == (byte)Enums.TileType.Key && modTypes.TempTile[GetPlayerMap(index)].DoorOpen[GetPlayerX(index) - 1, GetPlayerY(index) + 1] == 1))
                                        {
                                            SetPlayerX(index, GetPlayerX(index) - 1);
                                            SetPlayerY(index, GetPlayerY(index) + 1);
                                            S_NetworkSend.SendPlayerMove(index, Movement);
                                            Moved = true;
                                        }

                                        var loopTo3 = modTypes.TempPlayer[index].EventMap.CurrentEvents;

                                        // check for event
                                        for (var i = 1; i <= loopTo3; i++)
                                        {
                                            if (modTypes.TempPlayer[index].EventMap.EventPages[i].X == GetPlayerX(index) - 1 && modTypes.TempPlayer[index].EventMap.EventPages[i].Y == GetPlayerY(index) + 1)
                                            {
                                                if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].Trigger == 1)
                                                {
                                                    // PlayerMsg(Index, "OnTouch event", ColorType.Red)
                                                    // Process this event, it is on-touch and everything checks out.
                                                    if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount > 0)
                                                    {
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurList = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurSlot = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].EventId = modTypes.TempPlayer[index].EventMap.EventPages[i].EventId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].PageId = modTypes.TempPlayer[index].EventMap.EventPages[i].PageId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].WaitingForResponse = 0;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ListLeftOff = new int[modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount + 1];

                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Active = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ActionTimer = S_General.GetTimeMs();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else // Check to see if we can move them to the another map
                        if (modTypes.Map[GetPlayerMap(index)].Down > 0 && modTypes.Map[GetPlayerMap(index)].Left > 0)
                        {
                            PlayerWarp(index, modTypes.Map[GetPlayerMap(index)].Down, GetPlayerX(index), 0);
                            DidWarp = true;
                            Moved = true;
                        }

                        break;
                    }

                case (byte)Enums.DirectionType.DownRight:
                    {
                        // Check to make sure not outside of boundries
                        if (GetPlayerY(index) < modTypes.Map[GetPlayerMap(index)].MaxY && GetPlayerX(index) < modTypes.Map[GetPlayerMap(index)].MaxX)
                        {
                            // Check to make sure that the tile is walkable
                            byte directionRef = (int)(Enums.DirectionType.DownRight + 1);
                            if (!IsDirBlocked(ref modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].DirBlock, ref directionRef))
                            {
                                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) + 1, GetPlayerY(index) + 1].Type != (byte)Enums.TileType.Blocked)
                                {
                                    if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) + 1, GetPlayerY(index) + 1].Type != (byte)Enums.TileType.Resource)
                                    {

                                        // Check to see if the tile is a key and if it is check if its opened
                                        if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) + 1, GetPlayerY(index) + 1].Type != (byte)Enums.TileType.Key || (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index) + 1, GetPlayerY(index) + 1].Type == (byte)Enums.TileType.Key && modTypes.TempTile[GetPlayerMap(index)].DoorOpen[GetPlayerX(index) + 1, GetPlayerY(index) + 1] == 1))
                                        {
                                            SetPlayerX(index, GetPlayerX(index) + 1);
                                            SetPlayerY(index, GetPlayerY(index) + 1);
                                            S_NetworkSend.SendPlayerMove(index, Movement);
                                            Moved = true;
                                        }

                                        var loopTo3 = modTypes.TempPlayer[index].EventMap.CurrentEvents;

                                        // check for event
                                        for (var i = 1; i <= loopTo3; i++)
                                        {
                                            if (modTypes.TempPlayer[index].EventMap.EventPages[i].X == GetPlayerX(index) + 1 && modTypes.TempPlayer[index].EventMap.EventPages[i].Y == GetPlayerY(index) + 1)
                                            {
                                                if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].Trigger == 1)
                                                {
                                                    // PlayerMsg(Index, "OnTouch event", ColorType.Red)
                                                    // Process this event, it is on-touch and everything checks out.
                                                    if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount > 0)
                                                    {
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurList = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurSlot = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].EventId = modTypes.TempPlayer[index].EventMap.EventPages[i].EventId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].PageId = modTypes.TempPlayer[index].EventMap.EventPages[i].PageId;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].WaitingForResponse = 0;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ListLeftOff = new int[modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount + 1];

                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Active = 1;
                                                        modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ActionTimer = S_General.GetTimeMs();
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else // Check to see if we can move them to the another map
                        if (modTypes.Map[GetPlayerMap(index)].Down > 0 && modTypes.Map[GetPlayerMap(index)].Right > 0)
                        {
                            PlayerWarp(index, modTypes.Map[GetPlayerMap(index)].Down, GetPlayerX(index), 0);
                            DidWarp = true;
                            Moved = true;
                        }

                        break;
                    }
            }

            {
                // Check to see if the tile is a warp tile, and if so warp them
                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Type == (byte)Enums.TileType.Warp)
                {
                    mapNum = modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data1;
                    x = modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data2;
                    y = modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data3;

                    // If (MapNum AndAlso INSTANCED_MAP_MASK) > 0 Then
                    if (modTypes.Map[mapNum].Instanced == 1)
                    {
                        if (Convert.ToBoolean(modTypes.TempPlayer[index].InParty))
                            S_Parties.PartyWarp(index, mapNum, x, y);
                        else
                            PlayerWarp(index, mapNum, x, y);
                    }
                    else
                        PlayerWarp(index, mapNum, x, y);

                    DidWarp = true;
                    Moved = true;
                }

                // Check to see if the tile is a door tile, and if so warp them
                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Type == (byte)Enums.TileType.Door)
                {
                    mapNum = modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data1;
                    x = modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data2;
                    y = modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data3;
                    // send the animation to the map
                    S_NetworkSend.SendDoorAnimation(GetPlayerMap(index), GetPlayerX(index), GetPlayerY(index));

                    if (modTypes.Map[mapNum].Instanced == 1)
                    {
                        if (Convert.ToBoolean(modTypes.TempPlayer[index].InParty))
                            S_Parties.PartyWarp(index, mapNum, x, y);
                        else
                            PlayerWarp(index, mapNum, x, y);
                    }
                    else
                        PlayerWarp(index, mapNum, x, y);
                    DidWarp = true;
                    Moved = true;
                }

                // Check for key trigger open
                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Type == (byte)Enums.TileType.KeyOpen)
                {
                    x = modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data1;
                    y = modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data2;

                    if (modTypes.Map[GetPlayerMap(index)].Tile[x, y].Type == (byte)Enums.TileType.Key && modTypes.TempTile[GetPlayerMap(index)].DoorOpen[x, y] == 0)
                    {
                        modTypes.TempTile[GetPlayerMap(index)].DoorOpen[x, y] = 1;
                        modTypes.TempTile[GetPlayerMap(index)].DoorTimer = S_General.GetTimeMs();
                        S_NetworkSend.SendMapKey(index, x, y, 1);
                        S_NetworkSend.MapMsg(GetPlayerMap(index), "A door has been unlocked.", (int)Enums.ColorType.White);
                    }
                }

                // Check for a shop, and if so open it
                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Type == (byte)Enums.TileType.Shop)
                {
                    x = modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data1;
                    if (x > 0)
                    {
                        if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Shop[x].Name)) > 0)
                        {
                            S_NetworkSend.SendOpenShop(index, x);
                            modTypes.TempPlayer[index].InShop = x; // stops movement and the like
                        }
                    }
                }

                // Check to see if the tile is a bank, and if so send bank
                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Type == (byte)Enums.TileType.Bank)
                {
                    S_NetworkSend.SendBank(index);
                    modTypes.TempPlayer[index].InBank = true;
                    Moved = true;
                }

                // Check if it's a heal tile
                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Type == (byte)Enums.TileType.Heal)
                {
                    VitalType = modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data1;
                    amount = modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data2;
                    if (!(GetPlayerVital(index, (VitalType)VitalType) == GetPlayerMaxVital(index, (VitalType)VitalType)))
                    {
                        if (VitalType == (byte)Enums.VitalType.HP)
                            Colour = (int)Enums.ColorType.BrightGreen;
                        else
                            Colour = (int)Enums.ColorType.BrightBlue;
                        S_NetworkSend.SendActionMsg(GetPlayerMap(index), "+" + amount, Colour, (byte)Enums.ActionMsgType.Scroll, GetPlayerX(index) * 32, GetPlayerY(index) * 32, 1);
                        SetPlayerVital(index, (VitalType)VitalType, GetPlayerVital(index, (VitalType)VitalType) + amount);
                        S_NetworkSend.PlayerMsg(index, "You feel rejuvinating forces coarsing through your body.", (int)Enums.ColorType.BrightGreen);
                        S_NetworkSend.SendVital(index, (VitalType)VitalType);
                        // send vitals to party if in one
                        if (modTypes.TempPlayer[index].InParty > 0)
                            S_Parties.SendPartyVitals(modTypes.TempPlayer[index].InParty, index);
                    }
                    Moved = true;
                }

                // Check if it's a trap tile
                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Type == (byte)Enums.TileType.Trap)
                {
                    amount = modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data1;
                    S_NetworkSend.SendActionMsg(GetPlayerMap(index), "-" + amount, (int)Enums.ColorType.BrightRed, (byte)Enums.ActionMsgType.Scroll, GetPlayerX(index) * 32, GetPlayerY(index) * 32, 1);
                    if (GetPlayerVital(index, Enums.VitalType.HP) - amount <= 0)
                    {
                        KillPlayer(index);
                        S_NetworkSend.PlayerMsg(index, "You've been killed by a trap.", (int)Enums.ColorType.BrightRed);
                    }
                    else
                    {
                        SetPlayerVital(index, Enums.VitalType.HP, GetPlayerVital(index, Enums.VitalType.HP) - amount);
                        S_NetworkSend.PlayerMsg(index, "You've been injured by a trap.", (int)Enums.ColorType.BrightRed);
                        S_NetworkSend.SendVital(index, Enums.VitalType.HP);
                        // send vitals to party if in one
                        if (modTypes.TempPlayer[index].InParty > 0)
                            S_Parties.SendPartyVitals(modTypes.TempPlayer[index].InParty, index);
                    }
                    Moved = true;
                }

                // Housing
                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Type == (byte)Enums.TileType.House)
                {
                    if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Houseindex == modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data1)
                    {
                        // Do warping and such to the player's house :/
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastMap = GetPlayerMap(index);
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastX = GetPlayerX(index);
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastY = GetPlayerY(index);
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse = index;
                        var data = S_NetworkSend.PlayerData(index);
                        S_NetworkConfig.Socket.SendDataTo(index, data, data.Length);
                        PlayerWarp(index, S_Housing.HouseConfig[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Houseindex].BaseMap, S_Housing.HouseConfig[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Houseindex].X, S_Housing.HouseConfig[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].House.Houseindex].Y, true);
                        DidWarp = true;
                        return;
                    }
                    else
                    {
                        // Send the buy sequence and see what happens. (To be recreated in events.)
                        Buffer = new ByteStream(4);
                        Buffer.WriteInt32((int)Packets.ServerPackets.SBuyHouse);
                        Buffer.WriteInt32(modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data1);
                        S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);
                        Buffer.Dispose();
                        modTypes.TempPlayer[index].BuyHouseindex = modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Data1;
                    }
                }

                // crafting
                if (modTypes.Map[GetPlayerMap(index)].Tile[GetPlayerX(index), GetPlayerY(index)].Type == (byte)Enums.TileType.Craft)
                {
                    modTypes.TempPlayer[index].IsCrafting = true;
                    modCrafting.SendPlayerRecipes(index);
                    modCrafting.SendOpenCraft(index);
                    Moved = true;
                }
            }

            if (Moved == true)
            {
                if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse > 0)
                {
                    if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].X == S_Housing.HouseConfig[modTypes.Player[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse].Character[modTypes.TempPlayer[index].CurChar].House.Houseindex].X)
                    {
                        if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Y == S_Housing.HouseConfig[modTypes.Player[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse].Character[modTypes.TempPlayer[index].CurChar].House.Houseindex].Y)
                        {
                            PlayerWarp(index, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastMap, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastX, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastY);
                            DidWarp = true;
                        }
                    }
                }
            }

            // They tried to hack
            if (Moved == false || (ExpectingWarp && !DidWarp))
                PlayerWarp(index, GetPlayerMap(index), GetPlayerX(index), GetPlayerY(index));

            x = GetPlayerX(index);
            y = GetPlayerY(index);

            if (Moved == true)
            {
                if (modTypes.TempPlayer[index].EventMap.CurrentEvents > 0)
                {
                    var loopTo4 = modTypes.TempPlayer[index].EventMap.CurrentEvents;
                    for (var i = 1; i <= loopTo4; i++)
                    {
                        if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Globals == 1)
                        {
                            if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].X == x && modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Y == y && modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].Trigger == 1 && modTypes.TempPlayer[index].EventMap.EventPages[i].Visible == 1)
                                begineventprocessing = true;
                        }
                        else if (modTypes.TempPlayer[index].EventMap.EventPages[i].X == x && modTypes.TempPlayer[index].EventMap.EventPages[i].Y == y && modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].Trigger == 1 && modTypes.TempPlayer[index].EventMap.EventPages[i].Visible == 1)
                            begineventprocessing = true;
                        begineventprocessing = false;
                        if (begineventprocessing == true)
                        {
                            // Process this event, it is on-touch and everything checks out.
                            if (modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount > 0)
                            {
                                modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Active = 1;
                                modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ActionTimer = S_General.GetTimeMs();
                                modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurList = 1;
                                modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].CurSlot = 1;
                                modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].EventId = modTypes.TempPlayer[index].EventMap.EventPages[i].EventId;
                                modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].PageId = modTypes.TempPlayer[index].EventMap.EventPages[i].PageId;
                                modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].WaitingForResponse = 0;
                                modTypes.TempPlayer[index].EventProcessing[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].ListLeftOff = new int[modTypes.Map[GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].CommandListCount + 1];
                            }
                            begineventprocessing = false;
                        }
                    }
                }
            }
        }



        public static int HasItem(int index, int ItemNum)
        {
            int i;
            int HasItem = 0;
            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(index) == false || ItemNum <= 0 || ItemNum > Constants.MAX_ITEMS)
                return 0;

            for (i = 1; i <= Constants.MAX_INV; i++)
            {
                // Check to see if the player has the item
                if (GetPlayerInvItemNum(index, i) == ItemNum)
                {
                    if (Types.Item[ItemNum].Type == (byte)Enums.ItemType.Currency || Types.Item[ItemNum].Stackable == 1)
                        HasItem = GetPlayerInvItemValue(index, i);
                    else
                        HasItem = 1;
                    //return 0;
                }
            }
            return HasItem;
        }

        public static int FindItemSlot(int index, int ItemNum)
        {
            int i;
            int FindItemSlot = 0;
            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(index) == false || ItemNum <= 0 || ItemNum > Constants.MAX_ITEMS)
                return 0;

            for (i = 1; i <= Constants.MAX_INV; i++)
            {
                // Check to see if the player has the item
                if (GetPlayerInvItemNum(index, i) == ItemNum)
                {
                    FindItemSlot = i;
                    //return 0;
                }
            }
            return FindItemSlot;
        }

        public static int GetPlayerInvItemNum(int index, int InvSlot)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;
            if (InvSlot == 0)
                return 0;

            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Inv[InvSlot].Num;
        }

        public static int GetPlayerInvItemValue(int index, int InvSlot)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;
            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Inv[InvSlot].Value;
        }

        public static void PlayerMapGetItem(int index)
        {
            int i;
            int itemnum;
            int n;
            int mapNum;
            string Msg;

            if (!S_NetworkConfig.IsPlaying(index))
                return;
            mapNum = GetPlayerMap(index);

            for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
            {

                // See if theres even an item here
                if ((modTypes.MapItem[mapNum, i].Num > 0) & (modTypes.MapItem[mapNum, i].Num <= Constants.MAX_ITEMS))
                {
                    // our drop?
                    if (CanPlayerPickupItem(index, i))
                    {
                        // Check if item is at the same location as the player
                        if ((modTypes.MapItem[mapNum, i].X == GetPlayerX(index)))
                        {
                            if ((modTypes.MapItem[mapNum, i].Y == GetPlayerY(index)))
                            {
                                // Find open slot
                                n = FindOpenInvSlot(index, modTypes.MapItem[mapNum, i].Num);

                                // Open slot available?
                                if (n != 0)
                                {
                                    // Set item in players inventor
                                    itemnum = modTypes.MapItem[mapNum, i].Num;

                                    if (Types.Item[itemnum].Randomize != 0)
                                    {
                                        if (Microsoft.VisualBasic.Strings.Trim(modTypes.MapItem[mapNum, i].RandData.Prefix) != "" || Microsoft.VisualBasic.Strings.Trim(modTypes.MapItem[mapNum, i].RandData.Suffix) != "")
                                        {
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[n].Prefix = modTypes.MapItem[mapNum, i].RandData.Prefix;
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[n].Suffix = modTypes.MapItem[mapNum, i].RandData.Suffix;
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[n].Rarity = modTypes.MapItem[mapNum, i].RandData.Rarity;
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[n].Damage = modTypes.MapItem[mapNum, i].RandData.Damage;
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[n].Speed = modTypes.MapItem[mapNum, i].RandData.Speed;
                                            for (var m = 1; m <= (byte)Enums.StatType.Count - 1; m++)
                                                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[n].Stat[m] = modTypes.MapItem[GetPlayerMap(index), i].RandData.Stat[m];
                                        }
                                        else
                                            S_RandomItems.GivePlayerRandomItem(index, itemnum, n);
                                    }

                                    SetPlayerInvItemNum(index, n, modTypes.MapItem[mapNum, i].Num);

                                    if (Types.Item[GetPlayerInvItemNum(index, n)].Type == (byte)Enums.ItemType.Currency || Types.Item[GetPlayerInvItemNum(index, n)].Stackable == 1)
                                    {
                                        SetPlayerInvItemValue(index, n, GetPlayerInvItemValue(index, n) + modTypes.MapItem[mapNum, i].Value);
                                        Msg = modTypes.MapItem[mapNum, i].Value + " " + Microsoft.VisualBasic.Strings.Trim(Types.Item[GetPlayerInvItemNum(index, n)].Name);
                                    }
                                    else
                                    {
                                        SetPlayerInvItemValue(index, n, 0);
                                        Msg = S_GameLogic.CheckGrammar(Microsoft.VisualBasic.Strings.Trim(Types.Item[GetPlayerInvItemNum(index, n)].Name), 1);
                                    }

                                    // Erase item from the map
                                    modTypes.MapItem[mapNum, i].Num = 0;
                                    modTypes.MapItem[mapNum, i].Value = 0;
                                    modTypes.MapItem[mapNum, i].X = 0;
                                    modTypes.MapItem[mapNum, i].Y = 0;

                                    S_NetworkSend.SendInventoryUpdate(index, n);
                                    S_Items.SpawnItemSlot(i, 0, 0, GetPlayerMap(index), 0, 0);

                                    S_NetworkSend.SendActionMsg(GetPlayerMap(index), Msg, (int)Enums.ColorType.White, 1, (GetPlayerX(index) * 32), (GetPlayerY(index) * 32));
                                    S_Quest.CheckTasks(index, (int)Enums.QuestType.Gather, S_Quest.GetItemNum(Microsoft.VisualBasic.Strings.Trim(Types.Item[GetPlayerInvItemNum(index, n)].Name)));
                                    break;
                                }
                                else
                                {
                                    S_NetworkSend.PlayerMsg(index, "Your inventory is full.", (int)Enums.ColorType.BrightRed);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static bool CanPlayerPickupItem(int index, int mapItemNum)
        {
            int mapnum;

            mapnum = GetPlayerMap(index);

            // no lock or locked to player?
            if (modTypes.MapItem[mapnum, mapItemNum].PlayerName == Microsoft.VisualBasic.Constants.vbNullString | modTypes.MapItem[mapnum, mapItemNum].PlayerName == GetPlayerName(index).Trim())
            {
                return true;
            }

            return false;
        }

        public static void SetPlayerInvItemValue(int index, int InvSlot, int ItemValue)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Inv[InvSlot].Value = ItemValue;
        }

        public static void SetPlayerInvItemNum(int index, int invSlot, int itemNum)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Inv[invSlot].Num = itemNum;
        }

        public static int FindOpenInvSlot(int index, int ItemNum)
        {
            int i;

            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(index) == false || ItemNum <= 0 || ItemNum > Constants.MAX_ITEMS)
                return 0;

            if (Types.Item[ItemNum].Type == (byte)Enums.ItemType.Currency || Types.Item[ItemNum].Stackable == 1)
            {
                // If currency then check to see if they already have an instance of the item and add it to that
                for (i = 1; i <= Constants.MAX_INV; i++)
                {
                    if (GetPlayerInvItemNum(index, i) == ItemNum)
                    {
                        return i;
                    }
                }
            }

            for (i = 1; i <= Constants.MAX_INV; i++)
            {
                // Try to find an open free slot
                if (GetPlayerInvItemNum(index, i) == 0)
                {
                    return i;
                }
            }
            return 0;
        }

        public static bool TakeInvItem(int index, int ItemNum, int ItemVal)
        {
            int i;

            bool TakeInvItem = false;

            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(index) == false || ItemNum <= 0 || ItemNum > Constants.MAX_ITEMS)
                return false;

            for (i = 1; i <= Constants.MAX_INV; i++)
            {

                // Check to see if the player has the item
                if (GetPlayerInvItemNum(index, i) == ItemNum)
                {
                    if (Types.Item[ItemNum].Type == (byte)Enums.ItemType.Currency || Types.Item[ItemNum].Stackable == 1)
                    {

                        // Is what we are trying to take away more then what they have?  If so just set it to zero
                        if (ItemVal >= GetPlayerInvItemValue(index, i))
                            TakeInvItem = true;
                        else
                        {
                            SetPlayerInvItemValue(index, i, GetPlayerInvItemValue(index, i) - ItemVal);
                            S_NetworkSend.SendInventoryUpdate(index, i);
                        }
                    }
                    else
                        TakeInvItem = true;

                    if (TakeInvItem)
                    {
                        SetPlayerInvItemNum(index, i, 0);
                        SetPlayerInvItemValue(index, i, 0);
                        // Send the inventory update
                        S_NetworkSend.SendInventoryUpdate(index, i);
                        return false;
                    }
                }
            }
            return TakeInvItem;
        }

        public static bool GiveInvItem(int index, int ItemNum, int ItemVal, bool SendUpdate = true)
        {
            int i;
            bool GiveInvItem = false;
            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(index) == false || ItemNum <= 0 || ItemNum > Constants.MAX_ITEMS)
            {
                return false;
            }

            i = FindOpenInvSlot(index, ItemNum);

            // Check to see if inventory is full
            if (i != 0)
            {
                SetPlayerInvItemNum(index, i, ItemNum);
                SetPlayerInvItemValue(index, i, GetPlayerInvItemValue(index, i) + ItemVal);
                if (SendUpdate)
                    S_NetworkSend.SendInventoryUpdate(index, i);
                GiveInvItem = true;
            }
            else
            {
                S_NetworkSend.PlayerMsg(index, "Your inventory is full.", (int)Enums.ColorType.BrightRed);
                GiveInvItem = false;
            }
            return GiveInvItem;
        }

        public static void PlayerMapDropItem(int index, int InvNum, int Amount)
        {
            int i;

            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(index) == false || InvNum <= 0 || InvNum > Constants.MAX_INV)
                return;

            // check the player isn't doing something
            if ((modTypes.TempPlayer[index].InBank == true) || (modTypes.TempPlayer[index].InShop == 1) || modTypes.TempPlayer[index].InTrade > 0)
                return;

            if ((GetPlayerInvItemNum(index, InvNum) > 0))
            {
                if ((GetPlayerInvItemNum(index, InvNum) <= Constants.MAX_ITEMS))
                {
                    i = S_Items.FindOpenMapItemSlot(GetPlayerMap(index));

                    if (i != 0)
                    {
                        modTypes.MapItem[GetPlayerMap(index), i].Num = GetPlayerInvItemNum(index, InvNum);
                        modTypes.MapItem[GetPlayerMap(index), i].X = (byte)GetPlayerX(index);
                        modTypes.MapItem[GetPlayerMap(index), i].Y = (byte)GetPlayerY(index);
                        modTypes.MapItem[GetPlayerMap(index), i].PlayerName = Microsoft.VisualBasic.Strings.Trim(GetPlayerName(index));
                        modTypes.MapItem[GetPlayerMap(index), i].PlayerTimer = S_General.GetTimeMs() + S_Constants.ITEM_SPAWN_TIME;
                        modTypes.MapItem[GetPlayerMap(index), i].CanDespawn = true;
                        modTypes.MapItem[GetPlayerMap(index), i].DespawnTimer = S_General.GetTimeMs() + S_Constants.ITEM_DESPAWN_TIME;

                        if (Types.Item[GetPlayerInvItemNum(index, InvNum)].Type == (byte)Enums.ItemType.Currency || Types.Item[GetPlayerInvItemNum(index, InvNum)].Stackable == 1)
                        {

                            // Check if its more then they have and if so drop it all
                            if (Amount >= GetPlayerInvItemValue(index, InvNum))
                            {
                                modTypes.MapItem[GetPlayerMap(index), i].Value = GetPlayerInvItemValue(index, InvNum);
                                SetPlayerInvItemNum(index, InvNum, 0);
                                SetPlayerInvItemValue(index, InvNum, 0);
                                Amount = GetPlayerInvItemValue(index, InvNum);
                            }
                            else
                            {
                                modTypes.MapItem[GetPlayerMap(index), i].Value = Amount;
                                SetPlayerInvItemValue(index, InvNum, GetPlayerInvItemValue(index, InvNum) - Amount);
                            }
                            S_NetworkSend.MapMsg(GetPlayerMap(index), string.Format("{0} has dropped {1} ({2}x).", GetPlayerName(index), S_GameLogic.CheckGrammar(Microsoft.VisualBasic.Strings.Trim(Types.Item[GetPlayerInvItemNum(index, InvNum)].Name)), Amount), (int)Enums.ColorType.Yellow);
                        }
                        else
                        {
                            // Its not a currency object so this is easy
                            modTypes.MapItem[GetPlayerMap(index), i].Value = 0;
                            // send message

                            S_NetworkSend.MapMsg(GetPlayerMap(index), string.Format("{0} has dropped {1}.", GetPlayerName(index), S_GameLogic.CheckGrammar(Microsoft.VisualBasic.Strings.Trim(Types.Item[GetPlayerInvItemNum(index, InvNum)].Name))), (int)Enums.ColorType.Yellow);
                            SetPlayerInvItemNum(index, InvNum, 0);
                            SetPlayerInvItemValue(index, InvNum, 0);
                        }

                        // Send inventory update
                        S_NetworkSend.SendInventoryUpdate(index, InvNum);
                        // Spawn the item before we set the num or we'll get a different free map item slot
                        S_Items.SpawnItemSlot(i, modTypes.MapItem[GetPlayerMap(index), i].Num, Amount, GetPlayerMap(index), GetPlayerX(index), GetPlayerY(index));
                    }
                    else
                        S_NetworkSend.PlayerMsg(index, "Too many items already on the ground.", (int)Enums.ColorType.Yellow);
                }
            }
        }

        public static bool TakeInvSlot(int index, int InvSlot, int ItemVal)
        {
            int itemNum;

            bool TakeInvSlot = false;

            // Check for subscript out of range
            if (S_NetworkConfig.IsPlaying(index) == false || InvSlot <= 0 || InvSlot > Constants.MAX_ITEMS)
                return false;

            itemNum = GetPlayerInvItemNum(index, InvSlot);

            if (Types.Item[itemNum].Type == (byte)Enums.ItemType.Currency || Types.Item[itemNum].Stackable == 1)
            {

                // Is what we are trying to take away more then what they have?  If so just set it to zero
                if (ItemVal >= GetPlayerInvItemValue(index, InvSlot))
                    TakeInvSlot = true;
                else
                    SetPlayerInvItemValue(index, InvSlot, GetPlayerInvItemValue(index, InvSlot) - ItemVal);
            }
            else
                TakeInvSlot = true;

            if (TakeInvSlot)
            {
                SetPlayerInvItemNum(index, InvSlot, 0);
                SetPlayerInvItemValue(index, InvSlot, 0);
                return false;
            }
            return TakeInvSlot;
        }

        internal static void UseItem(int index, int InvNum)
        {
            int InvItemNum = 0;
            int i = 0;
            int n = 0;
            int x = 0;
            int y = 0;
            int tempitem = 0;
            int m = 0;
            int[] tempdata = new int[11];
            string[] tempstr = new string[3];

            // Prevent hacking
            if (InvNum < 1 || InvNum > Constants.MAX_ITEMS)
                return;

            if ((GetPlayerInvItemNum(index, InvNum) > 0) && (GetPlayerInvItemNum(index, InvNum) <= Constants.MAX_ITEMS))
            {
                InvItemNum = GetPlayerInvItemNum(index, InvNum);

                n = Types.Item[InvItemNum].Data2;

                // Find out what kind of item it is
                switch (Types.Item[InvItemNum].Type)
                {
                    case (byte)Enums.ItemType.Equipment:
                        {
                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                            {
                                if (GetPlayerStat(index, (StatType)i) < Types.Item[InvItemNum].Stat_Req[i])
                                {
                                    S_NetworkSend.PlayerMsg(index, "You do not meet the stat requirements to equip this item.", (int)Enums.ColorType.BrightRed);
                                    return;
                                }
                            }

                            // Make sure they are the right level
                            i = Types.Item[InvItemNum].LevelReq;

                            if (i > GetPlayerLevel(index))
                            {
                                S_NetworkSend.PlayerMsg(index, "You do not meet the level requirements to equip this item.", (int)Enums.ColorType.BrightRed);
                                return;
                            }

                            // Make sure they are the right class
                            if (!(Types.Item[InvItemNum].ClassReq == GetPlayerClass(index)) && !(Types.Item[InvItemNum].ClassReq == 0))
                            {
                                S_NetworkSend.PlayerMsg(index, "You do not meet the class requirements to equip this item.", (int)Enums.ColorType.BrightRed);
                                return;
                            }

                            // access requirement
                            if (!(GetPlayerAccess(index) >= Types.Item[InvItemNum].AccessReq))
                            {
                                S_NetworkSend.PlayerMsg(index, "You do not meet the access requirement to equip this item.", (int)Enums.ColorType.BrightRed);
                                return;
                            }

                            // if that went fine, we progress the subtype

                            switch (Types.Item[InvItemNum].SubType)
                            {
                                case (byte)Enums.EquipmentType.Weapon:
                                    {
                                        if (Types.Item[InvItemNum].TwoHanded > 0)
                                        {
                                            if (GetPlayerEquipment(index, Enums.EquipmentType.Shield) > 0)
                                            {
                                                S_NetworkSend.PlayerMsg(index, "This is a 2Handed weapon! Please unequip shield first.", (int)Enums.ColorType.BrightRed);
                                                return;
                                            }
                                        }

                                        if (GetPlayerEquipment(index, Enums.EquipmentType.Weapon) > 0)
                                        {
                                            tempitem = GetPlayerEquipment(index, Enums.EquipmentType.Weapon);
                                            tempstr[1] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Weapon].Prefix;
                                            tempstr[2] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Weapon].Suffix;
                                            tempdata[1] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Weapon].Damage;
                                            tempdata[2] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Weapon].Speed;
                                            tempdata[3] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Weapon].Rarity;
                                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                                tempdata[i + 3] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Weapon].Stat[i];
                                        }

                                        SetPlayerEquipment(index, InvItemNum, Enums.EquipmentType.Weapon);

                                        // Transfer the Inventory data to the Equipment data
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Weapon].Prefix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Prefix;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Weapon].Suffix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Suffix;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Weapon].Damage = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Damage;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Weapon].Speed = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Speed;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Weapon].Rarity = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Rarity;

                                        for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Weapon].Stat[i] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Stat[i];

                                        if (Types.Item[InvItemNum].Randomize != 0)
                                            S_NetworkSend.PlayerMsg(index, "You equip " + tempstr[1] + " " + S_GameLogic.CheckGrammar(Types.Item[InvItemNum].Name) + " " + tempstr[2], (int)Enums.ColorType.BrightGreen);
                                        else
                                            S_NetworkSend.PlayerMsg(index, "You equip " + S_GameLogic.CheckGrammar(Types.Item[InvItemNum].Name), (int)Enums.ColorType.BrightGreen);

                                        SetPlayerInvItemNum(index, InvNum, 0);
                                        SetPlayerInvItemValue(index, InvNum, 0);
                                        S_RandomItems.ClearRandInv(index, InvNum);

                                        if (tempitem > 0)
                                        {
                                            m = FindOpenInvSlot(index, tempitem);
                                            SetPlayerInvItemNum(index, m, tempitem);
                                            SetPlayerInvItemValue(index, m, 0);

                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Prefix = tempstr[1];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Suffix = tempstr[2];

                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Damage = tempdata[1];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Speed = tempdata[2];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Rarity = tempdata[3];

                                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Stat[i] = tempdata[i + 3];

                                            tempitem = 0;
                                        }

                                        S_NetworkSend.SendWornEquipment(index);
                                        S_NetworkSend.SendMapEquipment(index);
                                        S_NetworkSend.SendInventory(index);
                                        S_NetworkSend.SendInventoryUpdate(index, InvNum);
                                        S_NetworkSend.SendStats(index);

                                        // send vitals
                                        S_NetworkSend.SendVitals(index);

                                        // send vitals to party if in one
                                        if (modTypes.TempPlayer[index].InParty > 0)
                                            S_Parties.SendPartyVitals(modTypes.TempPlayer[index].InParty, index);
                                        break;
                                    }

                                case (byte)Enums.EquipmentType.Armor:
                                    {
                                        if (GetPlayerEquipment(index, Enums.EquipmentType.Armor) > 0)
                                        {
                                            tempitem = GetPlayerEquipment(index, Enums.EquipmentType.Armor);
                                            tempstr[1] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Armor].Prefix;
                                            tempstr[2] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Armor].Suffix;
                                            tempdata[1] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Armor].Damage;
                                            tempdata[2] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Armor].Speed;
                                            tempdata[3] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Armor].Rarity;
                                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                                tempdata[i + 3] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Armor].Stat[i];
                                        }

                                        SetPlayerEquipment(index, InvItemNum, Enums.EquipmentType.Armor);

                                        // Transfer the Inventory data to the Equipment data
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Armor].Prefix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Prefix;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Armor].Suffix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Suffix;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Armor].Damage = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Damage;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Armor].Speed = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Speed;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Armor].Rarity = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Rarity;

                                        for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Armor].Stat[i] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Stat[i];

                                        S_NetworkSend.PlayerMsg(index, "You equip " + S_GameLogic.CheckGrammar(Types.Item[InvItemNum].Name), (int)Enums.ColorType.BrightGreen);
                                        TakeInvItem(index, InvItemNum, 0);
                                        S_RandomItems.ClearRandInv(index, InvNum);

                                        if (tempitem > 0)
                                        {
                                            m = FindOpenInvSlot(index, tempitem);
                                            SetPlayerInvItemNum(index, m, tempitem);
                                            SetPlayerInvItemValue(index, m, 0);

                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Prefix = tempstr[1];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Suffix = tempstr[2];

                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Damage = tempdata[1];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Speed = tempdata[2];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Rarity = tempdata[3];

                                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Stat[i] = tempdata[i + 3];

                                            tempitem = 0;
                                        }

                                        S_NetworkSend.SendWornEquipment(index);
                                        S_NetworkSend.SendMapEquipment(index);

                                        S_NetworkSend.SendInventory(index);
                                        S_NetworkSend.SendStats(index);

                                        // send vitals
                                        S_NetworkSend.SendVitals(index);

                                        // send vitals to party if in one
                                        if (modTypes.TempPlayer[index].InParty > 0)
                                            S_Parties.SendPartyVitals(modTypes.TempPlayer[index].InParty, index);
                                        break;
                                    }

                                case (byte)Enums.EquipmentType.Helmet:
                                    {
                                        if (GetPlayerEquipment(index, Enums.EquipmentType.Helmet) > 0)
                                        {
                                            tempitem = GetPlayerEquipment(index, Enums.EquipmentType.Helmet);
                                            tempstr[1] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Helmet].Prefix;
                                            tempstr[2] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Helmet].Suffix;
                                            tempdata[1] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Helmet].Damage;
                                            tempdata[2] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Helmet].Speed;
                                            tempdata[3] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Helmet].Rarity;
                                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                                tempdata[i + 3] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Helmet].Stat[i];
                                        }

                                        SetPlayerEquipment(index, InvItemNum, Enums.EquipmentType.Helmet);

                                        // Transfer the Inventory data to the Equipment data
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Helmet].Prefix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Prefix;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Helmet].Suffix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Suffix;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Helmet].Damage = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Damage;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Helmet].Speed = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Speed;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Helmet].Rarity = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Rarity;

                                        for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Helmet].Stat[i] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Stat[i];

                                        S_NetworkSend.PlayerMsg(index, "You equip " + S_GameLogic.CheckGrammar(Types.Item[InvItemNum].Name), (int)Enums.ColorType.BrightGreen);
                                        TakeInvItem(index, InvItemNum, 1);
                                        S_RandomItems.ClearRandInv(index, InvNum);

                                        if (tempitem > 0)
                                        {
                                            m = FindOpenInvSlot(index, tempitem);
                                            SetPlayerInvItemNum(index, m, tempitem);
                                            SetPlayerInvItemValue(index, m, 0);

                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Prefix = tempstr[1];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Suffix = tempstr[2];

                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Damage = tempdata[1];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Speed = tempdata[2];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Rarity = tempdata[3];

                                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Stat[i] = tempdata[i + 3];

                                            tempitem = 0;
                                        }

                                        S_NetworkSend.SendWornEquipment(index);
                                        S_NetworkSend.SendMapEquipment(index);
                                        S_NetworkSend.SendInventory(index);
                                        S_NetworkSend.SendStats(index);

                                        // send vitals
                                        S_NetworkSend.SendVitals(index);

                                        // send vitals to party if in one
                                        if (modTypes.TempPlayer[index].InParty > 0)
                                            S_Parties.SendPartyVitals(modTypes.TempPlayer[index].InParty, index);
                                        break;
                                    }

                                case (byte)Enums.EquipmentType.Shield:
                                    {
                                        if (Types.Item[GetPlayerEquipment(index, Enums.EquipmentType.Weapon)].TwoHanded > 0)
                                        {
                                            S_NetworkSend.PlayerMsg(index, "Please unequip your 2handed weapon first.", (int)Enums.ColorType.BrightRed);
                                            return;
                                        }

                                        if (GetPlayerEquipment(index, Enums.EquipmentType.Shield) > 0)
                                        {
                                            tempitem = GetPlayerEquipment(index, Enums.EquipmentType.Shield);
                                            tempstr[1] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shield].Prefix;
                                            tempstr[2] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shield].Suffix;
                                            tempdata[1] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shield].Damage;
                                            tempdata[2] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shield].Speed;
                                            tempdata[3] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shield].Rarity;
                                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                                tempdata[i + 3] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shield].Stat[i];
                                        }

                                        SetPlayerEquipment(index, InvItemNum, Enums.EquipmentType.Shield);

                                        // Transfer the Inventory data to the Equipment data
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shield].Prefix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Prefix;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shield].Suffix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Suffix;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shield].Damage = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Damage;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shield].Speed = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Speed;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shield].Rarity = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Rarity;

                                        for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shield].Stat[i] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Stat[i];

                                        S_NetworkSend.PlayerMsg(index, "You equip " + S_GameLogic.CheckGrammar(Types.Item[InvItemNum].Name), (int)Enums.ColorType.BrightGreen);
                                        TakeInvItem(index, InvItemNum, 1);
                                        S_RandomItems.ClearRandInv(index, InvNum);

                                        if (tempitem > 0)
                                        {
                                            m = FindOpenInvSlot(index, tempitem);
                                            SetPlayerInvItemNum(index, m, tempitem);
                                            SetPlayerInvItemValue(index, m, 0);

                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Prefix = tempstr[1];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Suffix = tempstr[2];

                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Damage = tempdata[1];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Speed = tempdata[2];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Rarity = tempdata[3];

                                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Stat[i] = tempdata[i + 3];

                                            tempitem = 0;
                                        }

                                        S_NetworkSend.SendWornEquipment(index);
                                        S_NetworkSend.SendMapEquipment(index);
                                        S_NetworkSend.SendInventory(index);
                                        S_NetworkSend.SendStats(index);

                                        // send vitals
                                        S_NetworkSend.SendVitals(index);

                                        // send vitals to party if in one
                                        if (modTypes.TempPlayer[index].InParty > 0)
                                            S_Parties.SendPartyVitals(modTypes.TempPlayer[index].InParty, index);
                                        break;
                                    }

                                case (byte)Enums.EquipmentType.Shoes:
                                    {
                                        if (GetPlayerEquipment(index, Enums.EquipmentType.Shoes) > 0)
                                        {
                                            tempitem = GetPlayerEquipment(index, Enums.EquipmentType.Shoes);
                                            tempstr[1] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shoes].Prefix;
                                            tempstr[2] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shoes].Suffix;
                                            tempdata[1] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shoes].Damage;
                                            tempdata[2] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shoes].Speed;
                                            tempdata[3] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shoes].Rarity;
                                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                                tempdata[i + 3] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shoes].Stat[i];
                                        }

                                        SetPlayerEquipment(index, InvItemNum, Enums.EquipmentType.Shoes);

                                        // Transfer the Inventory data to the Equipment data
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shoes].Prefix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Prefix;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shoes].Suffix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Suffix;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shoes].Damage = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Damage;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shoes].Speed = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Speed;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shoes].Rarity = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Rarity;

                                        for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Shoes].Stat[i] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Stat[i];

                                        S_NetworkSend.PlayerMsg(index, "You equip " + S_GameLogic.CheckGrammar(Types.Item[InvItemNum].Name), (int)Enums.ColorType.BrightGreen);
                                        TakeInvItem(index, InvItemNum, 1);
                                        S_RandomItems.ClearRandInv(index, InvNum);

                                        if (tempitem > 0)
                                        {
                                            m = FindOpenInvSlot(index, tempitem);
                                            SetPlayerInvItemNum(index, m, tempitem);
                                            SetPlayerInvItemValue(index, m, 0);

                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Prefix = tempstr[1];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Suffix = tempstr[2];

                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Damage = tempdata[1];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Speed = tempdata[2];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Rarity = tempdata[3];

                                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Stat[i] = tempdata[i + 3];

                                            tempitem = 0;
                                        }

                                        S_NetworkSend.SendWornEquipment(index);
                                        S_NetworkSend.SendMapEquipment(index);
                                        S_NetworkSend.SendInventory(index);
                                        S_NetworkSend.SendStats(index);

                                        // send vitals
                                        S_NetworkSend.SendVitals(index);

                                        // send vitals to party if in one
                                        if (modTypes.TempPlayer[index].InParty > 0)
                                            S_Parties.SendPartyVitals(modTypes.TempPlayer[index].InParty, index);
                                        break;
                                    }

                                case (byte)Enums.EquipmentType.Gloves:
                                    {
                                        if (GetPlayerEquipment(index, Enums.EquipmentType.Gloves) > 0)
                                        {
                                            tempitem = GetPlayerEquipment(index, Enums.EquipmentType.Gloves);
                                            tempstr[1] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Gloves].Prefix;
                                            tempstr[2] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Gloves].Suffix;
                                            tempdata[1] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Gloves].Damage;
                                            tempdata[2] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Gloves].Speed;
                                            tempdata[3] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Gloves].Rarity;
                                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                                tempdata[i + 3] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Gloves].Stat[i];
                                        }

                                        SetPlayerEquipment(index, InvItemNum, Enums.EquipmentType.Gloves);

                                        // Transfer the Inventory data to the Equipment data
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Gloves].Prefix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Prefix;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Gloves].Suffix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Suffix;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Gloves].Damage = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Damage;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Gloves].Speed = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Speed;
                                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Gloves].Rarity = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Rarity;

                                        for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(byte)Enums.EquipmentType.Gloves].Stat[i] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Stat[i];

                                        S_NetworkSend.PlayerMsg(index, "You equip " + S_GameLogic.CheckGrammar(Types.Item[InvItemNum].Name), (int)Enums.ColorType.BrightGreen);
                                        TakeInvItem(index, InvItemNum, 1);
                                        S_RandomItems.ClearRandInv(index, InvNum);

                                        if (tempitem > 0)
                                        {
                                            m = FindOpenInvSlot(index, tempitem);
                                            SetPlayerInvItemNum(index, m, tempitem);
                                            SetPlayerInvItemValue(index, m, 0);

                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Prefix = tempstr[1];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Suffix = tempstr[2];

                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Damage = tempdata[1];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Speed = tempdata[2];
                                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Rarity = tempdata[3];

                                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                                                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Stat[i] = tempdata[i + 3];

                                            tempitem = 0;
                                        }

                                        S_NetworkSend.SendWornEquipment(index);
                                        S_NetworkSend.SendMapEquipment(index);
                                        S_NetworkSend.SendInventory(index);
                                        S_NetworkSend.SendStats(index);

                                        // send vitals
                                        S_NetworkSend.SendVitals(index);

                                        // send vitals to party if in one
                                        if (modTypes.TempPlayer[index].InParty > 0)
                                            S_Parties.SendPartyVitals(modTypes.TempPlayer[index].InParty, index);
                                        break;
                                    }
                            }

                            break;
                        }

                    case (byte)Enums.ItemType.Consumable:
                        {
                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                            {
                                if (GetPlayerStat(index, (StatType)i) < Types.Item[InvItemNum].Stat_Req[i])
                                {
                                    S_NetworkSend.PlayerMsg(index, "You do not meet the stat requirements to use this item.", (int)Enums.ColorType.BrightRed);
                                    return;
                                }
                            }

                            // Make sure they are the right level
                            i = Types.Item[InvItemNum].LevelReq;

                            if (i > GetPlayerLevel(index))
                            {
                                S_NetworkSend.PlayerMsg(index, "You do not meet the level requirements to use this item.", (int)Enums.ColorType.BrightRed);
                                return;
                            }

                            // Make sure they are the right class
                            if (!(Types.Item[InvItemNum].ClassReq == GetPlayerClass(index)) && !(Types.Item[InvItemNum].ClassReq == 0))
                            {
                                S_NetworkSend.PlayerMsg(index, "You do not meet the class requirements to use this item.", (int)Enums.ColorType.BrightRed);
                                return;
                            }

                            // access requirement
                            if (!(GetPlayerAccess(index) >= Types.Item[InvItemNum].AccessReq))
                            {
                                S_NetworkSend.PlayerMsg(index, "You do not meet the access requirement to use this item.", (int)Enums.ColorType.BrightRed);
                                return;
                            }

                            // if that went fine, we progress the subtype

                            switch (Types.Item[InvItemNum].SubType)
                            {
                                case (byte)Enums.ConsumableType.Hp:
                                    {
                                        S_NetworkSend.SendActionMsg(GetPlayerMap(index), "+" + Types.Item[InvItemNum].Data1, (int)Enums.ColorType.BrightGreen, (byte)Enums.ActionMsgType.Scroll, GetPlayerX(index) * 32, GetPlayerY(index) * 32);
                                        S_Animations.SendAnimation(GetPlayerMap(index), Types.Item[InvItemNum].Animation, 0, 0, (byte)Enums.TargetType.Player, index);
                                        SetPlayerVital(index, Enums.VitalType.HP, GetPlayerVital(index, Enums.VitalType.HP) + Types.Item[InvItemNum].Data1);
                                        if (Types.Item[InvItemNum].Stackable == 1)
                                            TakeInvItem(index, InvItemNum, 1);
                                        else
                                            TakeInvItem(index, InvItemNum, 0);
                                        S_NetworkSend.SendVital(index, Enums.VitalType.HP);

                                        // send vitals to party if in one
                                        if (modTypes.TempPlayer[index].InParty > 0)
                                            S_Parties.SendPartyVitals(modTypes.TempPlayer[index].InParty, index);
                                        break;
                                    }

                                case (byte)Enums.ConsumableType.Mp:
                                    {
                                        S_NetworkSend.SendActionMsg(GetPlayerMap(index), "+" + Types.Item[InvItemNum].Data1, (int)Enums.ColorType.BrightBlue, (byte)Enums.ActionMsgType.Scroll, GetPlayerX(index) * 32, GetPlayerY(index) * 32);
                                        S_Animations.SendAnimation(GetPlayerMap(index), Types.Item[InvItemNum].Animation, 0, 0, (byte)Enums.TargetType.Player, index);
                                        SetPlayerVital(index, Enums.VitalType.MP, GetPlayerVital(index, Enums.VitalType.MP) + Types.Item[InvItemNum].Data1);
                                        if (Types.Item[InvItemNum].Stackable == 1)
                                            TakeInvItem(index, InvItemNum, 1);
                                        else
                                            TakeInvItem(index, InvItemNum, 0);
                                        S_NetworkSend.SendVital(index, Enums.VitalType.MP);

                                        // send vitals to party if in one
                                        if (modTypes.TempPlayer[index].InParty > 0)
                                            S_Parties.SendPartyVitals(modTypes.TempPlayer[index].InParty, index);
                                        break;
                                    }

                                case (byte)Enums.ConsumableType.Exp:
                                    {
                                        break;
                                    }
                            }

                            break;
                        }

                    case (byte)Enums.ItemType.Key:
                        {
                            InvItemNum = GetPlayerInvItemNum(index, InvNum);

                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                            {
                                if (GetPlayerStat(index, (StatType)i) < Types.Item[InvItemNum].Stat_Req[i])
                                {
                                    S_NetworkSend.PlayerMsg(index, "You do not meet the stat requirements to use this item.", (int)Enums.ColorType.BrightRed);
                                    return;
                                }
                            }

                            // Make sure they are the right level
                            i = Types.Item[InvItemNum].LevelReq;

                            if (i > GetPlayerLevel(index))
                            {
                                S_NetworkSend.PlayerMsg(index, "You do not meet the level requirements to use this item.", (int)Enums.ColorType.BrightRed);
                                return;
                            }

                            // Make sure they are the right class
                            if (!(Types.Item[InvItemNum].ClassReq == GetPlayerClass(index)) && !(Types.Item[InvItemNum].ClassReq == 0))
                            {
                                S_NetworkSend.PlayerMsg(index, "You do not meet the class requirements to use this item.", (int)Enums.ColorType.BrightRed);
                                return;
                            }

                            switch (GetPlayerDir(index))
                            {
                                case (byte)Enums.DirectionType.Up:
                                    {
                                        if (GetPlayerY(index) > 0)
                                        {
                                            x = GetPlayerX(index);
                                            y = GetPlayerY(index) - 1;
                                        }
                                        else
                                            return;
                                        break;
                                    }

                                case (byte)Enums.DirectionType.Down:
                                    {
                                        if (GetPlayerY(index) < modTypes.Map[GetPlayerMap(index)].MaxY)
                                        {
                                            x = GetPlayerX(index);
                                            y = GetPlayerY(index) + 1;
                                        }
                                        else
                                            return;
                                        break;
                                    }

                                case (byte)Enums.DirectionType.Left:
                                    {
                                        if (GetPlayerX(index) > 0)
                                        {
                                            x = GetPlayerX(index) - 1;
                                            y = GetPlayerY(index);
                                        }
                                        else
                                            return;
                                        break;
                                    }

                                case (byte)Enums.DirectionType.Right:
                                    {
                                        if (GetPlayerX(index) < modTypes.Map[GetPlayerMap(index)].MaxX)
                                        {
                                            x = GetPlayerX(index) + 1;
                                            y = GetPlayerY(index);
                                        }
                                        else
                                            return;
                                        break;
                                    }

                                    // 8 Directional Movement

                                case (byte)Enums.DirectionType.UpLeft:
                                    {
                                        if (GetPlayerY(index) > 0 && GetPlayerX(index) > 0)
                                        {
                                            x = GetPlayerX(index) - 1;
                                            y = GetPlayerY(index) - 1;
                                        }
                                        else
                                            return;
                                        break;
                                    }

                                case (byte)Enums.DirectionType.UpRight:
                                    {
                                        if (GetPlayerY(index) > 0 && GetPlayerX(index) < modTypes.Map[GetPlayerMap(index)].MaxX)
                                        {
                                            x = GetPlayerX(index) + 1;
                                            y = GetPlayerY(index) - 1;
                                        }
                                        else
                                            return;
                                        break;
                                    }

                                case (byte)Enums.DirectionType.DownLeft:
                                    {
                                        if (GetPlayerX(index) > 0 && GetPlayerY(index) < modTypes.Map[GetPlayerMap(index)].MaxY)
                                        {
                                            x = GetPlayerX(index) - 1;
                                            y = GetPlayerY(index) + 1;
                                        }
                                        else
                                            return;
                                        break;
                                    }

                                case (byte)Enums.DirectionType.DownRight:
                                    {
                                        if (GetPlayerX(index) < modTypes.Map[GetPlayerMap(index)].MaxX && GetPlayerY(index) < modTypes.Map[GetPlayerMap(index)].MaxY)
                                        {
                                            x = GetPlayerX(index) + 1;
                                            y = GetPlayerY(index) + 1;
                                        }
                                        else
                                            return;
                                        break;
                                    }
                            }

                            // Check if a key exists
                            if (modTypes.Map[GetPlayerMap(index)].Tile[x, y].Type == (byte)Enums.TileType.Key)
                            {

                                // Check if the key they are using matches the map key
                                if (InvItemNum == modTypes.Map[GetPlayerMap(index)].Tile[x, y].Data1)
                                {
                                    modTypes.TempTile[GetPlayerMap(index)].DoorOpen[x, y] = 1;
                                    modTypes.TempTile[GetPlayerMap(index)].DoorTimer = S_General.GetTimeMs();
                                    S_NetworkSend.SendMapKey(index, x, y, 1);
                                    S_NetworkSend.MapMsg(GetPlayerMap(index), "A door has been unlocked.", (int)Enums.ColorType.Yellow);

                                    S_Animations.SendAnimation(GetPlayerMap(index), Types.Item[InvItemNum].Animation, x, y);

                                    // Check if we are supposed to take away the item
                                    if (modTypes.Map[GetPlayerMap(index)].Tile[x, y].Data2 == 1)
                                    {
                                        TakeInvItem(index, InvItemNum, 0);
                                        S_NetworkSend.PlayerMsg(index, "The key is destroyed in the lock.", (int)Enums.ColorType.Yellow);
                                    }
                                }
                            }

                            break;
                        }

                    case (byte)Enums.ItemType.Skill:
                        {
                            InvItemNum = GetPlayerInvItemNum(index, InvNum);

                            for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                            {
                                if (GetPlayerStat(index, (StatType)i) < Types.Item[InvItemNum].Stat_Req[i])
                                {
                                    S_NetworkSend.PlayerMsg(index, "You do not meet the stat requirements to use this item.", (int)Enums.ColorType.BrightRed);
                                    return;
                                }
                            }

                            // Make sure they are the right class
                            if (!(Types.Item[InvItemNum].ClassReq == GetPlayerClass(index)) && !(Types.Item[InvItemNum].ClassReq == 0))
                            {
                                S_NetworkSend.PlayerMsg(index, "You do not meet the class requirements to use this item.", (int)Enums.ColorType.BrightRed);
                                return;
                            }

                            // Get the skill num
                            n = Types.Item[InvItemNum].Data1;

                            if (n > 0)
                            {

                                // Make sure they are the right class
                                if (Types.Skill[n].ClassReq == GetPlayerClass(index) || Types.Skill[n].ClassReq == 0)
                                {
                                    // Make sure they are the right level
                                    i = Types.Skill[n].LevelReq;

                                    if (i <= GetPlayerLevel(index))
                                    {
                                        i = FindOpenSkillSlot(index);

                                        // Make sure they have an open skill slot
                                        if (i > 0)
                                        {

                                            // Make sure they dont already have the skill
                                            if (!HasSkill(index, n))
                                            {
                                                SetPlayerSkill(index, i, n);
                                                S_Animations.SendAnimation(GetPlayerMap(index), Types.Item[InvItemNum].Animation, 0, 0, (byte)Enums.TargetType.Player, index);
                                                TakeInvItem(index, InvItemNum, 0);
                                                S_NetworkSend.PlayerMsg(index, "You study the skill carefully.", (int)Enums.ColorType.Yellow);
                                                S_NetworkSend.PlayerMsg(index, "You have learned a new skill!", (int)Enums.ColorType.BrightGreen);
                                            }
                                            else
                                                S_NetworkSend.PlayerMsg(index, "You have already learned this skill!", (int)Enums.ColorType.BrightRed);
                                        }
                                        else
                                            S_NetworkSend.PlayerMsg(index, "You have learned all that you can learn!", (int)Enums.ColorType.BrightRed);
                                    }
                                    else
                                        S_NetworkSend.PlayerMsg(index, "You must be level " + i + " to learn this skill.", (int)Enums.ColorType.Yellow);
                                }
                                else
                                    S_NetworkSend.PlayerMsg(index, "This skill can only be learned by " + S_GameLogic.CheckGrammar(modDatabase.GetClassName(Types.Skill[n].ClassReq)) + ".", (int)Enums.ColorType.Yellow);
                            }
                            else
                                S_NetworkSend.PlayerMsg(index, "This scroll is not connected to a skill, please inform an admin!", (int)Enums.ColorType.BrightRed);
                            break;
                        }

                    case (byte)Enums.ItemType.Furniture:
                        {
                            S_NetworkSend.PlayerMsg(index, "To place furniture, simply click on it in your inventory, then click in your house where you want it.", (int)Enums.ColorType.Yellow);
                            break;
                        }

                    case (byte)Enums.ItemType.Recipe:
                        {
                            S_NetworkSend.PlayerMsg(index, "Lets learn this recipe :)", (int)Enums.ColorType.BrightGreen);
                            // Get the recipe num
                            n = Types.Item[InvItemNum].Data1;
                            modCrafting.LearnRecipe(index, n, InvNum);
                            break;
                        }

                    case (byte)Enums.ItemType.Pet:
                        {
                            if (Types.Item[InvItemNum].Stackable == 1)
                                TakeInvItem(index, InvItemNum, 1);
                            else
                                TakeInvItem(index, InvItemNum, 0);
                            n = Types.Item[InvItemNum].Data1;
                            S_Pets.AdoptPet(index, n);
                            break;
                        }
                }
            }
        }

        public static void PlayerSwitchInvSlots(int index, int OldSlot, int NewSlot)
        {
            int OldNum;
            int OldValue;
            int OldRarity;
            string OldPrefix;
            string OldSuffix;
            int OldSpeed;
            int OldDamage;
            int NewNum;
            int NewValue;
            int NewRarity;
            string NewPrefix;
            string NewSuffix;
            int NewSpeed;
            int NewDamage;
            int[] NewStats = new int[7];
            int[] OldStats = new int[7];

            if (OldSlot == 0 || NewSlot == 0)
                return;

            OldNum = GetPlayerInvItemNum(index, OldSlot);
            OldValue = GetPlayerInvItemValue(index, OldSlot);
            NewNum = GetPlayerInvItemNum(index, NewSlot);
            NewValue = GetPlayerInvItemValue(index, NewSlot);

            if (OldNum == NewNum && Types.Item[NewNum].Stackable == 1)
            {
                SetPlayerInvItemNum(index, NewSlot, NewNum);
                SetPlayerInvItemValue(index, NewSlot, OldValue + NewValue);
                SetPlayerInvItemNum(index, OldSlot, 0);
                SetPlayerInvItemValue(index, OldSlot, 0);
            }
            else
            {
                SetPlayerInvItemNum(index, NewSlot, OldNum);
                SetPlayerInvItemValue(index, NewSlot, OldValue);
                SetPlayerInvItemNum(index, OldSlot, NewNum);
                SetPlayerInvItemValue(index, OldSlot, NewValue);
            }

            // RandomInv
            {
                NewPrefix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[NewSlot].Prefix;
                NewSuffix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[NewSlot].Suffix;
                NewDamage = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[NewSlot].Damage;
                NewSpeed = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[NewSlot].Speed;
                NewRarity = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[NewSlot].Rarity;
                for (var i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                    NewStats[i] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[NewSlot].Stat[i];
            }

            {
                OldPrefix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[OldSlot].Prefix;
                OldSuffix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[OldSlot].Suffix;
                OldDamage = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[OldSlot].Damage;
                OldSpeed = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[OldSlot].Speed;
                OldRarity = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[OldSlot].Rarity;
                for (var i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                    OldStats[i] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[OldSlot].Stat[i];
            }

            {
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[NewSlot].Prefix = OldPrefix;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[NewSlot].Suffix = OldSuffix;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[NewSlot].Damage = OldDamage;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[NewSlot].Speed = OldSpeed;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[NewSlot].Rarity = OldRarity;
                for (var i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[NewSlot].Stat[i] = OldStats[i];
            }

            {
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[OldSlot].Prefix = NewPrefix;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[OldSlot].Suffix = NewSuffix;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[OldSlot].Damage = NewDamage;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[OldSlot].Speed = NewSpeed;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[OldSlot].Rarity = NewRarity;
                for (var i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[OldSlot].Stat[i] = NewStats[i];
            }

            S_NetworkSend.SendInventory(index);
        }



        public static void CheckEquippedItems(int index)
        {
            int itemNum;
            int i;

            // We want to check incase an admin takes away an object but they had it equipped
            for (i = 1; i <= (byte)Enums.EquipmentType.Count - 1; i++)
            {
                itemNum = GetPlayerEquipment(index, (EquipmentType)i);

                if (itemNum > 0)
                {
                    switch (i)
                    {
                        case (byte)Enums.EquipmentType.Weapon:
                            {
                                if (Types.Item[itemNum].SubType != (byte)Enums.EquipmentType.Weapon)
                                    SetPlayerEquipment(index, 0, (EquipmentType)i);
                                break;
                            }

                        case (byte)Enums.EquipmentType.Armor:
                            {
                                if (Types.Item[itemNum].SubType != (byte)Enums.EquipmentType.Armor)
                                    SetPlayerEquipment(index, 0, (EquipmentType)i);
                                break;
                            }

                        case (byte)Enums.EquipmentType.Helmet:
                            {
                                if (Types.Item[itemNum].SubType != (byte)Enums.EquipmentType.Helmet)
                                    SetPlayerEquipment(index, 0, (EquipmentType)i);
                                break;
                            }

                        case (byte)Enums.EquipmentType.Shield:
                            {
                                if (Types.Item[itemNum].SubType != (byte)Enums.EquipmentType.Shield)
                                    SetPlayerEquipment(index, 0, (EquipmentType)i);
                                break;
                            }

                        case (byte)Enums.EquipmentType.Shoes:
                            {
                                if (Types.Item[itemNum].SubType != (byte)Enums.EquipmentType.Shoes)
                                    SetPlayerEquipment(index, 0, (EquipmentType)i);
                                break;
                            }

                        case (byte)Enums.EquipmentType.Gloves:
                            {
                                if (Types.Item[itemNum].SubType != (byte)Enums.EquipmentType.Gloves)
                                    SetPlayerEquipment(index, 0, (EquipmentType)i);
                                break;
                            }
                    }
                }
                else
                    SetPlayerEquipment(index, 0, (EquipmentType)i);
            }
        }

        public static void PlayerUnequipItem(int index, int EqSlot)
        {
            int i;
            int m;
            int itemnum;

            if (EqSlot <= 0 || EqSlot > (byte)Enums.EquipmentType.Count - 1)
                return; // exit out early if error'd

            if (FindOpenInvSlot(index, GetPlayerEquipment(index, (EquipmentType)EqSlot)) > 0)
            {
                itemnum = GetPlayerEquipment(index, (EquipmentType)EqSlot);

                m = FindOpenInvSlot(index, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Equipment[EqSlot]);
                SetPlayerInvItemNum(index, m, modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Equipment[EqSlot]);
                SetPlayerInvItemValue(index, m, 0);

                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Prefix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[EqSlot].Prefix;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Suffix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[EqSlot].Suffix;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Damage = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[EqSlot].Damage;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Speed = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[EqSlot].Speed;
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Rarity = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[EqSlot].Rarity;
                for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[m].Stat[i] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[EqSlot].Stat[i];

                S_RandomItems.ClearRandEq(index, (EquipmentType)EqSlot);

                S_NetworkSend.PlayerMsg(index, "You unequip " + S_GameLogic.CheckGrammar(Types.Item[GetPlayerEquipment(index, (EquipmentType)EqSlot)].Name), (int)Enums.ColorType.Yellow);
                // remove equipment
                SetPlayerEquipment(index, 0, (EquipmentType)EqSlot);
                S_NetworkSend.SendWornEquipment(index);
                S_NetworkSend.SendMapEquipment(index);
                S_NetworkSend.SendStats(index);
                S_NetworkSend.SendInventory(index);
                // send vitals
                S_NetworkSend.SendVitals(index);

                // send vitals to party if in one
                if (modTypes.TempPlayer[index].InParty > 0)
                    S_Parties.SendPartyVitals(modTypes.TempPlayer[index].InParty, index);
            }
            else
                S_NetworkSend.PlayerMsg(index, "Your inventory is full.", (int)Enums.ColorType.BrightRed);
        }



        public static void JoinGame(int index)
        {
            int i;

            // Set the flag so we know the person is in the game
            modTypes.TempPlayer[index].InGame = true;
            ModLoop.UpdateOnlinePlayers();

            // Notify everyone that a player has joined the game.
            S_NetworkSend.GlobalMsg(string.Format("{0} has joined {1}!", GetPlayerName(index), modTypes.Options.GameName));

            // Send an ok to client to start receiving in game data
            S_NetworkSend.SendLoadCharOk(index);

            // Set some data related to housing instances.
            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse == 1 || modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Map == 501)
            {
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse = 0;
                if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastMap > 0)
                {
                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].X = (byte)modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastX;
                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Y = (byte)modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastY;
                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Map = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].LastMap;
                }
            }

            // Send all the required game data to the user.
            S_NetworkSend.SendTotalOnlineTo(index);
            CheckEquippedItems(index);
            S_NetworkSend.SendGameData(index);
            S_NetworkSend.SendInventory(index);
            S_NetworkSend.SendWornEquipment(index);
            S_NetworkSend.SendMapEquipment(index);
            S_Projectiles.SendProjectiles(index);
            S_NetworkSend.SendVitals(index);
            S_NetworkSend.SendExp(index);
            S_Quest.SendQuests(index);
            S_Quest.SendPlayerQuests(index);
            S_NetworkSend.SendMapNames(index);
            S_NetworkSend.SendHotbar(index);
            S_NetworkSend.SendPlayerSkills(index);
            modCrafting.SendRecipes(index);
            S_NetworkSend.SendStats(index);
            S_NetworkSend.SendJoinMap(index);
            S_Housing.SendHouseConfigs(index);
            S_Pets.SendPets(index);
            S_Pets.SendUpdatePlayerPet(index, true);
            modTime.SendTimeTo(index);
            modTime.SendGameClockTo(index);
            var loopTo = S_Resources.ResourceCache[GetPlayerMap(index)].ResourceCount;
            for (i = 0; i <= loopTo; i++)
                S_Resources.SendResourceCacheTo(index, i);

            S_NetworkSend.SendTotalOnlineToAll();

            // Warp the player to his saved location
            PlayerWarp(index, GetPlayerMap(index), GetPlayerX(index), GetPlayerY(index));

            // Send welcome messages
            S_NetworkSend.SendWelcome(index);

            // Send the flag so they know they can start doing stuff
            S_NetworkSend.SendInGame(index);

            S_General.UpdateCaption();
        }

        public static void LeftGame(int index)
        {
            int i = 0;
            int tradeTarget;

            if (modTypes.TempPlayer[index].InGame)
            {
                S_NetworkSend.SendLeftMap(index);
                modTypes.TempPlayer[index].InGame = false;
                ModLoop.UpdateOnlinePlayers();

                // Send a global message that he/she left
                S_NetworkSend.GlobalMsg(string.Format("{0} has left {1}!", GetPlayerName(index), modTypes.Options.GameName));

                Console.WriteLine(string.Format("{0} has left {1}!", GetPlayerName(index), modTypes.Options.GameName));

                // Check if player was the only player on the map and stop npc processing if so
                if (GetPlayerMap(index) > 0)
                {
                    if (S_GameLogic.GetTotalMapPlayers(GetPlayerMap(index)) < 1)
                    {
                        modTypes.PlayersOnMap[GetPlayerMap(index)] = 0;
                        if (S_Instances.IsInstancedMap(GetPlayerMap(index)))
                        {
                            S_Instances.DestroyInstancedMap(GetPlayerMap(index) - Constants.MAX_MAPS);

                            if (modTypes.TempPlayer[index].InInstance == 1)
                            {
                                SetPlayerMap(index, modTypes.TempPlayer[index].TmpMap);
                                SetPlayerX(index, modTypes.TempPlayer[index].TmpX);
                                SetPlayerY(index, modTypes.TempPlayer[index].TmpY);
                                modTypes.TempPlayer[index].InInstance = 0;
                            }
                        }
                    }
                }

                // Check if the player was in a party, and if so cancel it out so the other player doesn't continue to get half exp
                // leave party.
                S_Parties.Party_PlayerLeave(index);

                // cancel any trade they're in
                if (modTypes.TempPlayer[index].InTrade > 0)
                {
                    tradeTarget = modTypes.TempPlayer[index].InTrade;
                    S_NetworkSend.PlayerMsg(tradeTarget, string.Format("{0} has declined the trade.", GetPlayerName(index)), (int)Enums.ColorType.BrightRed);
                    // clear out trade
                    for (i = 1; i <= Constants.MAX_INV; i++)
                    {
                        modTypes.TempPlayer[tradeTarget].TradeOffer[i].Num = 0;
                        modTypes.TempPlayer[tradeTarget].TradeOffer[i].Value = 0;
                    }
                    modTypes.TempPlayer[tradeTarget].InTrade = 0;
                    S_NetworkSend.SendCloseTrade(tradeTarget);
                }

                // pet
                // ReleasePet(Index)
                S_Pets.ReCallPet(index);

                modDatabase.SavePlayer(index);
                modDatabase.SaveBank(index);

                modTypes.TempPlayer[index] = default(TempPlayerRec);
                modTypes.TempPlayer[i].SkillCd = new int[Constants.MAX_PLAYER_SKILLS + 1];
                modTypes.TempPlayer[i].TradeOffer = new PlayerInvRec[Constants.MAX_INV + 1];
            }

            S_NetworkSend.SendTotalOnlineToAll();

            modDatabase.ClearPlayer(index);
            modDatabase.ClearBank(index);

            S_NetworkConfig.Socket.Disconnect(index);
            S_General.UpdateCaption();
        }

        internal static void KillPlayer(int index)
        {
            int exp;

            // Calculate exp to give attacker
            exp = GetPlayerExp(index) / 3;

            // Make sure we dont get less then 0
            if (exp < 0)
                exp = 0;
            if (exp == 0)
                S_NetworkSend.PlayerMsg(index, "You've lost no experience.", (int)Enums.ColorType.BrightGreen);
            else
            {
                SetPlayerExp(index, GetPlayerExp(index) - exp);
                S_NetworkSend.SendExp(index);
                S_NetworkSend.PlayerMsg(index, string.Format("You've lost {0} experience.", exp), (int)Enums.ColorType.BrightRed);
            }

            OnDeath(index);
        }

        public static void OnDeath(int index)
        {
            // Dim i As Integer

            // Set HP to nothing
            SetPlayerVital(index, Enums.VitalType.HP, 0);

            // Warp player away
            SetPlayerDir(index, (byte)Enums.DirectionType.Down);

            {
                // to the bootmap if it is set
                if (modTypes.Map[GetPlayerMap(index)].BootMap > 0)
                    PlayerWarp(index, modTypes.Map[GetPlayerMap(index)].BootMap, modTypes.Map[GetPlayerMap(index)].BootX, modTypes.Map[GetPlayerMap(index)].BootY);
                else
                    PlayerWarp(index, modTypes.Options.StartMap, modTypes.Options.StartX, modTypes.Options.StartY);
            }

            // Clear skill casting
            modTypes.TempPlayer[index].SkillBuffer = 0;
            modTypes.TempPlayer[index].SkillBufferTimer = 0;
            S_NetworkSend.SendClearSkillBuffer(index);

            // Restore vitals
            SetPlayerVital(index, Enums.VitalType.HP, GetPlayerMaxVital(index, Enums.VitalType.HP));
            SetPlayerVital(index, Enums.VitalType.MP, GetPlayerMaxVital(index, Enums.VitalType.MP));
            SetPlayerVital(index, Enums.VitalType.SP, GetPlayerMaxVital(index, Enums.VitalType.SP));
            S_NetworkSend.SendVitals(index);

            // send vitals to party if in one
            if (modTypes.TempPlayer[index].InParty > 0)
                S_Parties.SendPartyVitals(modTypes.TempPlayer[index].InParty, index);

            // If the player the attacker killed was a pk then take it away
            if (GetPlayerPK(index) == 1)
            {
                SetPlayerPK(index, 1);
                S_NetworkSend.SendPlayerData(index);
            }
        }

        public static int GetPlayerVitalRegen(int index, Enums.VitalType Vital)
        {
            int i = 0;

            // Prevent subscript out of range
            if (S_NetworkConfig.IsPlaying(index) == false || index <= 0 || index > Constants.MAX_PLAYERS)
            {
                return 0;
            }

            switch (Vital)
            {
                case Enums.VitalType.HP:
                    {
                        i = (GetPlayerStat(index, Enums.StatType.Vitality) / 2);
                        break;
                    }

                case Enums.VitalType.MP:
                    {
                        i = (GetPlayerStat(index, Enums.StatType.Spirit) / 2);
                        break;
                    }

                case Enums.VitalType.SP:
                    {
                        i = (GetPlayerStat(index, Enums.StatType.Spirit) / 2);
                        break;
                    }
            }

            if (i < 2)
                i = 2;
            return i;
        }

        internal static void HandleNpcKillExperience(int index, int NpcNum)
        {
            // Get the experience we'll have to hand out. If it's negative, just ignore this method.
            int Experience = (int)(Types.Npc[NpcNum].Exp * modTypes.Options.xpMultiplier);
            if (Experience <= 0)
                return;

            // Is our player in a party? If so, hand out exp to everyone.
            if (S_Parties.IsPlayerInParty(index))
                S_Parties.Party_ShareExp(S_Parties.GetPlayerParty(index), Experience, index, GetPlayerMap(index));
            else
                S_Events.GivePlayerExp(index, Experience);
        }

        internal static void HandlePlayerKillExperience(int Attacker, int Victim)
        {
            // Calculate exp to give attacker
            var exp = (int)((GetPlayerExp(Victim) / 10) * modTypes.Options.xpMultiplier);

            // Make sure we dont get less then 0
            if (exp < 0)
                exp = 0;

            if (exp == 0)
            {
                S_NetworkSend.PlayerMsg(Victim, "You've lost no exp.", (int)Enums.ColorType.BrightRed);
                S_NetworkSend.PlayerMsg(Attacker, "You've received no exp.", (int)Enums.ColorType.BrightBlue);
            }
            else
            {
                SetPlayerExp(Victim, GetPlayerExp(Victim) - exp);
                S_NetworkSend.SendExp(Victim);
                S_NetworkSend.PlayerMsg(Victim, string.Format("You've lost {0} exp.", exp), (int)Enums.ColorType.BrightRed);

                // check if we're in a party
                if (Convert.ToInt32(S_Parties.IsPlayerInParty(Attacker)) > 0)
                    // pass through party exp share function
                    S_Parties.Party_ShareExp(S_Parties.GetPlayerParty(Attacker), exp, Attacker, GetPlayerMap(Attacker));
                else
                    // not in party, get exp for self
                    S_Events.GivePlayerExp(Attacker, exp);
            }
        }



        public static int FindOpenSkillSlot(int index)
        {
            int i;

            for (i = 1; i <= Constants.MAX_PLAYER_SKILLS; i++)
            {
                if (GetPlayerSkill(index, i) == 0)
                {
                    return i;
                }
            }
            return 0;
        }

        public static int GetPlayerSkill(int index, int Skillslot)
        {
            if (index > Constants.MAX_PLAYERS)
                return 0;

            return modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Skill[Skillslot];
        }

        internal static int GetPlayerSkillSlot(int index, int SkillId)
        {
            if (index < 0 || index > Constants.MAX_PLAYERS)
                return -1;
            var data = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Skill.Where(x => x == SkillId).ToArray();
            if (data.Length > 0)
                return data.Single();
            return -1;
        }

        public static bool HasSkill(int index, int Skillnum)
        {
            int i;

            for (i = 1; i <= Constants.MAX_PLAYER_SKILLS; i++)
            {
                if (GetPlayerSkill(index, i) == Skillnum)
                {
                    return true;
                }
            }
            return false;
        }

        public static void SetPlayerSkill(int index, int Skillslot, int Skillnum)
        {
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Skill[Skillslot] = Skillnum;
        }

        internal static void BufferSkill(int index, int Skillslot)
        {
            int skillnum;
            int MPCost;
            int LevelReq;
            int mapNum;
            int SkillCastType;
            int ClassReq;
            int AccessReq;
            int range;
            bool HasBuffered;

            Enums.TargetType TargetType;
            int Target;

            // Prevent subscript out of range
            if (Skillslot <= 0 || Skillslot > Constants.MAX_PLAYER_SKILLS)
                return;

            skillnum = GetPlayerSkill(index, Skillslot);
            mapNum = GetPlayerMap(index);

            if (skillnum <= 0 || skillnum > Constants.MAX_SKILLS)
                return;

            // Make sure player has the skill
            if (!HasSkill(index, skillnum))
                return;

            // see if cooldown has finished
            if (modTypes.TempPlayer[index].SkillCd[Skillslot] > S_General.GetTimeMs())
            {
                S_NetworkSend.PlayerMsg(index, "Skill hasn't cooled down yet!", (int)Enums.ColorType.Yellow);
                return;
            }

            MPCost = Types.Skill[skillnum].MpCost;

            // Check if they have enough MP
            if (GetPlayerVital(index, Enums.VitalType.MP) < MPCost)
            {
                S_NetworkSend.PlayerMsg(index, "Not enough mana!", (int)Enums.ColorType.Yellow);
                return;
            }

            LevelReq = Types.Skill[skillnum].LevelReq;

            // Make sure they are the right level
            if (LevelReq > GetPlayerLevel(index))
            {
                S_NetworkSend.PlayerMsg(index, "You must be level " + LevelReq + " to use this skill.", (int)Enums.ColorType.BrightRed);
                return;
            }

            AccessReq = Types.Skill[skillnum].AccessReq;

            // make sure they have the right access
            if (AccessReq > GetPlayerAccess(index))
            {
                S_NetworkSend.PlayerMsg(index, "You must be an administrator to use this skill.", (int)Enums.ColorType.BrightRed);
                return;
            }

            ClassReq = Types.Skill[skillnum].ClassReq;

            // make sure the classreq > 0
            if (ClassReq > 0)
            {
                if (ClassReq != GetPlayerClass(index))
                {
                    S_NetworkSend.PlayerMsg(index, "Only " + S_GameLogic.CheckGrammar(Microsoft.VisualBasic.Strings.Trim(Types.Classes[ClassReq].Name)) + " can use this skill.", (int)Enums.ColorType.Yellow);
                    return;
                }
            }

            // find out what kind of skill it is! self cast, target or AOE
            if (Types.Skill[skillnum].Range > 0)
            {
                // ranged attack, single target or aoe?
                if (!Types.Skill[skillnum].IsAoE)
                    SkillCastType = 2; // targetted
                else
                    SkillCastType = 3;// targetted aoe
            }
            else if (!Types.Skill[skillnum].IsAoE)
                SkillCastType = 0; // self-cast
            else
                SkillCastType = 1;// self-cast AoE

            TargetType = (TargetType)modTypes.TempPlayer[index].TargetType;
            Target = modTypes.TempPlayer[index].Target;
            range = Types.Skill[skillnum].Range;
            HasBuffered = false;

            switch (SkillCastType)
            {
                case 0:
                case 1 // self-cast & self-cast AOE
               :
                    {
                        HasBuffered = true;
                        break;
                    }

                case 2:
                case 3 // targeted & targeted AOE
         :
                    {
                        // check if have target
                        if (!(Target > 0))
                            S_NetworkSend.PlayerMsg(index, "You do not have a target.", (int)Enums.ColorType.BrightRed);
                        if (TargetType == Enums.TargetType.Player)
                        {
                            // Housing
                            if (modTypes.Player[Target].Character[modTypes.TempPlayer[Target].CurChar].InHouse == modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].InHouse)
                            {
                                if (CanPlayerAttackPlayer(index, Target, true))
                                    HasBuffered = true;
                            }
                            // if have target, check in range
                            if (!IsInRange(range, GetPlayerX(index), GetPlayerY(index), GetPlayerX(Target), GetPlayerY(Target)))
                                S_NetworkSend.PlayerMsg(index, "Target not in range.", (int)Enums.ColorType.BrightRed);
                            else
                                // go through skill types
                                if (Types.Skill[skillnum].Type != (byte)Enums.SkillType.DamageHp && Types.Skill[skillnum].Type != (byte)Enums.SkillType.DamageMp)
                                HasBuffered = true;
                            else if (CanPlayerAttackPlayer(index, Target, true))
                                HasBuffered = true;
                        }
                        else if (TargetType == Enums.TargetType.Npc)
                        {
                            // if have target, check in range
                            if (!IsInRange(range, GetPlayerX(index), GetPlayerY(index), modTypes.MapNpc[mapNum].Npc[Target].X, modTypes.MapNpc[mapNum].Npc[Target].Y))
                            {
                                S_NetworkSend.PlayerMsg(index, "Target not in range.", (int)Enums.ColorType.BrightRed);
                                HasBuffered = false;
                            }
                            else
                                // go through skill types
                                if (Types.Skill[skillnum].Type != (byte)Enums.SkillType.DamageHp && Types.Skill[skillnum].Type != (byte)Enums.SkillType.DamageMp)
                                HasBuffered = true;
                            else if (CanPlayerAttackNpc(index, Target, true))
                                HasBuffered = true;
                        }

                        break;
                    }
            }

            if (HasBuffered)
            {
                S_Animations.SendAnimation(mapNum, Types.Skill[skillnum].CastAnim, 0, 0, (byte)Enums.TargetType.Player, index);
                modTypes.TempPlayer[index].SkillBuffer = Skillslot;
                modTypes.TempPlayer[index].SkillBufferTimer = S_General.GetTimeMs();
                return;
            }
            else
                S_NetworkSend.SendClearSkillBuffer(index);
        }



        public static void GiveBankItem(int index, int InvSlot, int Amount)
        {
            int BankSlot;
            int itemnum;

            if (InvSlot < 0 || InvSlot > Constants.MAX_INV)
                return;

            if (GetPlayerInvItemValue(index, InvSlot) < 0)
                return;
            if (GetPlayerInvItemValue(index, InvSlot) < Amount)
                return;

            BankSlot = FindOpenBankSlot(index, GetPlayerInvItemNum(index, InvSlot));
            itemnum = GetPlayerInvItemNum(index, InvSlot);

            if (BankSlot > 0)
            {
                if (Types.Item[GetPlayerInvItemNum(index, InvSlot)].Type == (byte)Enums.ItemType.Currency || Types.Item[GetPlayerInvItemNum(index, InvSlot)].Stackable == 1)
                {
                    if (GetPlayerBankItemNum(index, (byte)BankSlot) == GetPlayerInvItemNum(index, InvSlot))
                    {
                        SetPlayerBankItemValue(index, (byte)BankSlot, GetPlayerBankItemValue(index, (byte)BankSlot) + Amount);
                        TakeInvItem(index, GetPlayerInvItemNum(index, InvSlot), Amount);
                    }
                    else
                    {
                        SetPlayerBankItemNum(index, (byte)BankSlot, GetPlayerInvItemNum(index, InvSlot));
                        SetPlayerBankItemValue(index, (byte)BankSlot, Amount);
                        TakeInvItem(index, GetPlayerInvItemNum(index, InvSlot), Amount);
                    }
                }
                else if (GetPlayerBankItemNum(index, (byte)BankSlot) == GetPlayerInvItemNum(index, InvSlot) && Types.Item[itemnum].Randomize == 0)
                {
                    SetPlayerBankItemValue(index, (byte)BankSlot, GetPlayerBankItemValue(index, (byte)BankSlot) + 1);
                    TakeInvItem(index, GetPlayerInvItemNum(index, InvSlot), 0);
                }
                else
                {
                    modTypes.Bank[index].ItemRand[BankSlot].Prefix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvSlot].Prefix;
                    modTypes.Bank[index].ItemRand[BankSlot].Suffix = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvSlot].Suffix;
                    modTypes.Bank[index].ItemRand[BankSlot].Rarity = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvSlot].Rarity;
                    modTypes.Bank[index].ItemRand[BankSlot].Damage = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvSlot].Damage;
                    modTypes.Bank[index].ItemRand[BankSlot].Speed = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvSlot].Speed;

                    for (var i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                        modTypes.Bank[index].ItemRand[BankSlot].Stat[i] = modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvSlot].Stat[i];

                    SetPlayerBankItemNum(index, (byte)BankSlot, itemnum);
                    SetPlayerBankItemValue(index, (byte)BankSlot, 1);
                    S_RandomItems.ClearRandInv(index, InvSlot);
                    TakeInvItem(index, GetPlayerInvItemNum(index, InvSlot), 0);
                }
            }

            modDatabase.SaveBank(index);
            modDatabase.SavePlayer(index);
            S_NetworkSend.SendBank(index);
        }

        public static int GetPlayerBankItemNum(int index, byte BankSlot)
        {
            return modTypes.Bank[index].Item[BankSlot].Num;
        }

        public static void SetPlayerBankItemNum(int index, byte BankSlot, int ItemNum)
        {
            modTypes.Bank[index].Item[BankSlot].Num = ItemNum;
        }

        public static int GetPlayerBankItemValue(int index, byte BankSlot)
        {
            return modTypes.Bank[index].Item[BankSlot].Value;
        }

        public static void SetPlayerBankItemValue(int index, byte BankSlot, int ItemValue)
        {
            modTypes.Bank[index].Item[BankSlot].Value = ItemValue;
        }

        public static byte FindOpenBankSlot(int index, int ItemNum)
        {
            int i;

            if (!S_NetworkConfig.IsPlaying(index))
                return 0;
            if (ItemNum <= 0 || ItemNum > Constants.MAX_ITEMS)
                return 0;

            if (Types.Item[ItemNum].Type == (byte)Enums.ItemType.Currency || Types.Item[ItemNum].Stackable == 1)
            {
                for (i = 1; i <= Constants.MAX_BANK; i++)
                {
                    if (GetPlayerBankItemNum(index, (byte)i) == ItemNum)
                    {
                        return (byte)i;
                    }
                }
            }

            for (i = 1; i <= Constants.MAX_BANK; i++)
            {
                if (GetPlayerBankItemNum(index, (byte)i) == 0)
                {
                    return (byte)i;
                }
            }
            return 0;
        }

        public static void TakeBankItem(int index, int BankSlot, int Amount)
        {
            int invSlot;

            if (BankSlot < 0 || BankSlot > Constants.MAX_BANK)
                return;

            if (GetPlayerBankItemValue(index, (byte)BankSlot) < 0)
                return;

            if (GetPlayerBankItemValue(index, (byte)BankSlot) < Amount)
                return;

            invSlot = FindOpenInvSlot(index, GetPlayerBankItemNum(index, (byte)BankSlot));

            if (invSlot > 0)
            {
                if (Types.Item[GetPlayerBankItemNum(index, (byte)BankSlot)].Type == (byte)Enums.ItemType.Currency || Types.Item[GetPlayerBankItemNum(index, (byte)BankSlot)].Stackable == 1)
                {
                    GiveInvItem(index, GetPlayerBankItemNum(index, (byte)BankSlot), Amount);
                    SetPlayerBankItemValue(index, (byte)BankSlot, GetPlayerBankItemValue(index, (byte)BankSlot) - Amount);
                    if (GetPlayerBankItemValue(index, (byte)BankSlot) <= 0)
                    {
                        SetPlayerBankItemNum(index, (byte)BankSlot, 0);
                        SetPlayerBankItemValue(index, (byte)BankSlot, 0);
                    }
                }
                else if (GetPlayerBankItemNum(index, (byte)BankSlot) == GetPlayerInvItemNum(index, invSlot) && Types.Item[GetPlayerBankItemNum(index, (byte)BankSlot)].Randomize == 0)
                {
                    if (GetPlayerBankItemValue(index, (byte)BankSlot) > 1)
                    {
                        GiveInvItem(index, GetPlayerBankItemNum(index, (byte)BankSlot), 0);
                        SetPlayerBankItemValue(index, (byte)BankSlot, GetPlayerBankItemValue(index, (byte)BankSlot) - 1);
                    }
                }
                else
                {
                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invSlot].Prefix = modTypes.Bank[index].ItemRand[BankSlot].Prefix;
                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invSlot].Suffix = modTypes.Bank[index].ItemRand[BankSlot].Suffix;
                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invSlot].Rarity = modTypes.Bank[index].ItemRand[BankSlot].Rarity;
                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invSlot].Damage = modTypes.Bank[index].ItemRand[BankSlot].Damage;
                    modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invSlot].Speed = modTypes.Bank[index].ItemRand[BankSlot].Speed;
                    for (var i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invSlot].Stat[i] = modTypes.Bank[index].ItemRand[BankSlot].Stat[i];

                    GiveInvItem(index, GetPlayerBankItemNum(index, (byte)BankSlot), 0);
                    SetPlayerBankItemNum(index, (byte)BankSlot, 0);
                    SetPlayerBankItemValue(index, (byte)BankSlot, 0);
                    S_RandomItems.ClearRandBank(index, BankSlot);
                }
            }

            modDatabase.SaveBank(index);
            modDatabase.SavePlayer(index);
            S_NetworkSend.SendBank(index);
        }

        public static void PlayerSwitchBankSlots(int index, int OldSlot, int NewSlot)
        {
            int OldNum;
            int OldValue;
            int NewNum;
            int NewValue;
            int i;
            int[] NewStats;
            int[] OldStats;
            int NewRarity;
            int OldRarity;
            string NewPrefix;
            string OldPrefix;
            string NewSuffix;
            string OldSuffix;
            int NewSpeed;
            int OldSpeed;
            int NewDamage;
            int OldDamage;

            if (OldSlot == 0 || NewSlot == 0)
                return;

            OldNum = GetPlayerBankItemNum(index, (byte)OldSlot);
            OldValue = GetPlayerBankItemValue(index, (byte)OldSlot);
            NewNum = GetPlayerBankItemNum(index, (byte)NewSlot);
            NewValue = GetPlayerBankItemValue(index, (byte)NewSlot);

            SetPlayerBankItemNum(index, (byte)NewSlot, OldNum);
            SetPlayerBankItemValue(index, (byte)NewSlot, OldValue);

            SetPlayerBankItemNum(index, (byte)OldSlot, NewNum);
            SetPlayerBankItemValue(index, (byte)OldSlot, NewValue);

            OldStats = new int[7];
            NewStats = new int[7];

            // RandomInv
            {
                NewPrefix = modTypes.Bank[index].ItemRand[NewSlot].Prefix;
                NewSuffix = modTypes.Bank[index].ItemRand[NewSlot].Suffix;
                NewDamage = modTypes.Bank[index].ItemRand[NewSlot].Damage;
                NewSpeed = modTypes.Bank[index].ItemRand[NewSlot].Speed;
                NewRarity = modTypes.Bank[index].ItemRand[NewSlot].Rarity;
                for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                    NewStats[i] = modTypes.Bank[index].ItemRand[NewSlot].Stat[i];
            }

            {
                OldPrefix = modTypes.Bank[index].ItemRand[OldSlot].Prefix;
                OldSuffix = modTypes.Bank[index].ItemRand[OldSlot].Suffix;
                OldDamage = modTypes.Bank[index].ItemRand[OldSlot].Damage;
                OldSpeed = modTypes.Bank[index].ItemRand[OldSlot].Speed;
                OldRarity = modTypes.Bank[index].ItemRand[OldSlot].Rarity;
                for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                    OldStats[i] = modTypes.Bank[index].ItemRand[OldSlot].Stat[i];
            }

            {
                modTypes.Bank[index].ItemRand[NewSlot].Prefix = OldPrefix;
                modTypes.Bank[index].ItemRand[NewSlot].Suffix = OldSuffix;
                modTypes.Bank[index].ItemRand[NewSlot].Damage = OldDamage;
                modTypes.Bank[index].ItemRand[NewSlot].Speed = OldSpeed;
                modTypes.Bank[index].ItemRand[NewSlot].Rarity = OldRarity;
                for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                    modTypes.Bank[index].ItemRand[NewSlot].Stat[i] = OldStats[i];
            }

            {
                modTypes.Bank[index].ItemRand[OldSlot].Prefix = NewPrefix;
                modTypes.Bank[index].ItemRand[OldSlot].Suffix = NewSuffix;
                modTypes.Bank[index].ItemRand[OldSlot].Damage = NewDamage;
                modTypes.Bank[index].ItemRand[OldSlot].Speed = NewSpeed;
                modTypes.Bank[index].ItemRand[OldSlot].Rarity = NewRarity;
                for (i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                    modTypes.Bank[index].ItemRand[OldSlot].Stat[i] = NewStats[i];
            }

            S_NetworkSend.SendBank(index);
        }
    }
}
