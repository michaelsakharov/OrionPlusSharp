using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;
using ASFW;

namespace Engine
{
    static class S_Npc
    {
        public static void SpawnAllMapNpcs()
        {
            int i;

            for (i = 1; i <= S_Instances.MAX_CACHED_MAPS; i++)
                SpawnMapNpcs(i);
        }

        public static void SpawnMapNpcs(int mapNum)
        {
            int i;

            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                SpawnNpc(i, mapNum);
        }

        internal static void SpawnNpc(int mapNpcNum, int mapNum)
        {
            ByteStream buffer = new ByteStream(4);
            int npcNum = 0;
            int x = 0;
            int y = 0;
            var i = 0;
            bool spawned = false;

            // Check for subscript out of range
            if (mapNpcNum <= 0 || mapNpcNum > Constants.MAX_MAP_NPCS || mapNum <= 0 || mapNum > S_Instances.MAX_CACHED_MAPS)
                return;

            npcNum = modTypes.Map[mapNum].Npc[mapNpcNum];

            if (npcNum > 0)
            {
                if (!(Types.Npc[npcNum].SpawnTime == (byte)Time.Instance.TimeOfDay) && !(Types.Npc[npcNum].SpawnTime == 4))
                    return;

                modTypes.MapNpc[mapNum].Npc[mapNpcNum].Num = npcNum;
                modTypes.MapNpc[mapNum].Npc[mapNpcNum].Target = 0;
                modTypes.MapNpc[mapNum].Npc[mapNpcNum].TargetType = 0; // clear

                modTypes.MapNpc[mapNum].Npc[mapNpcNum].Vital[(int)Enums.VitalType.HP] = S_GameLogic.GetNpcMaxVital(npcNum, Enums.VitalType.HP);
                modTypes.MapNpc[mapNum].Npc[mapNpcNum].Vital[(int)Enums.VitalType.MP] = S_GameLogic.GetNpcMaxVital(npcNum, Enums.VitalType.MP);
                modTypes.MapNpc[mapNum].Npc[mapNpcNum].Vital[(int)Enums.VitalType.SP] = S_GameLogic.GetNpcMaxVital(npcNum, Enums.VitalType.SP);

                modTypes.MapNpc[mapNum].Npc[mapNpcNum].Dir = (int)Conversion.Int(VBMath.Rnd() * 4);
                var loopTo = modTypes.Map[mapNum].MaxX;

                // Check if theres a spawn tile for the specific npc
                for (x = 0; x <= loopTo; x++)
                {
                    var loopTo1 = modTypes.Map[mapNum].MaxY;
                    for (y = 0; y <= loopTo1; y++)
                    {
                        if (modTypes.Map[mapNum].Tile[x, y].Type == (int)Enums.TileType.NpcSpawn)
                        {
                            if (modTypes.Map[mapNum].Tile[x, y].Data1 == mapNpcNum)
                            {
                                modTypes.MapNpc[mapNum].Npc[mapNpcNum].X = (byte)(byte)x;
                                modTypes.MapNpc[mapNum].Npc[mapNpcNum].Y = (byte)(byte)y;
                                modTypes.MapNpc[mapNum].Npc[mapNpcNum].Dir = modTypes.Map[mapNum].Tile[x, y].Data2;
                                spawned = true;
                                break;
                            }
                        }
                    }
                }

                if (!spawned)
                {
                    // Well try 100 times to randomly place the sprite
                    while (i < 100)
                    {
                        x = S_GameLogic.Random(0, modTypes.Map[mapNum].MaxX);
                        y = S_GameLogic.Random(0, modTypes.Map[mapNum].MaxY);

                        if (x > modTypes.Map[mapNum].MaxX)
                            x = modTypes.Map[mapNum].MaxX;
                        if (y > modTypes.Map[mapNum].MaxY)
                            y = modTypes.Map[mapNum].MaxY;

                        // Check if the tile is walkable
                        if (NpcTileIsOpen(mapNum, x, y))
                        {
                            modTypes.MapNpc[mapNum].Npc[mapNpcNum].X = (byte)x;
                            modTypes.MapNpc[mapNum].Npc[mapNpcNum].Y = (byte)y;
                            spawned = true;
                            break;
                        }
                        i += 1;
                    }
                }

                // Didn't spawn, so now we'll just try to find a free tile
                if (!spawned)
                {
                    var loopTo2 = modTypes.Map[mapNum].MaxX;
                    for (x = 0; x <= loopTo2; x++)
                    {
                        var loopTo3 = modTypes.Map[mapNum].MaxY;
                        for (y = 0; y <= loopTo3; y++)
                        {
                            if (NpcTileIsOpen(mapNum, x, y))
                            {
                                modTypes.MapNpc[mapNum].Npc[mapNpcNum].X = (byte)x;
                                modTypes.MapNpc[mapNum].Npc[mapNpcNum].Y = (byte)y;
                                spawned = true;
                            }
                        }
                    }
                }

                // If we suceeded in spawning then send it to everyone
                if (spawned)
                {
                    buffer.WriteInt32((int)Packets.ServerPackets.SSpawnNpc);
                    buffer.WriteInt32(mapNpcNum);
                    buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[mapNpcNum].Num);
                    buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[mapNpcNum].X);
                    buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[mapNpcNum].Y);
                    buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[mapNpcNum].Dir);

                    S_General.AddDebug("Recieved SMSG: SSpawnNpc");

                    for (i = 1; i <= (int)Enums.VitalType.Count - 1; i++)
                        buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[mapNpcNum].Vital[i]);

                    S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                }

                SendMapNpcVitals(mapNum, (byte)mapNpcNum);
            }

            buffer.Dispose();
        }



        internal static bool NpcTileIsOpen(int mapNum, int x, int y)
        {
            int LoopI;
            bool NpcTileIsOpen = true;

            if (modTypes.PlayersOnMap[mapNum] == 1)
            {
                var loopTo = S_NetworkConfig.Socket.HighIndex;
                for (LoopI = 1; LoopI <= loopTo; LoopI++)
                {
                    if (S_Players.GetPlayerMap(LoopI) == mapNum && S_Players.GetPlayerX(LoopI) == x && S_Players.GetPlayerY(LoopI) == y)
                    {
                        NpcTileIsOpen = false;
                        return NpcTileIsOpen;
                    }
                }
            }

            for (LoopI = 1; LoopI <= Constants.MAX_MAP_NPCS; LoopI++)
            {
                if (modTypes.MapNpc[mapNum].Npc[LoopI].Num > 0 && modTypes.MapNpc[mapNum].Npc[LoopI].X == x && modTypes.MapNpc[mapNum].Npc[LoopI].Y == y)
                {
                    NpcTileIsOpen = false;
                    return NpcTileIsOpen;
                }
            }

            if (modTypes.Map[mapNum].Tile[x, y].Type != (int)Enums.TileType.None && modTypes.Map[mapNum].Tile[x, y].Type != (int)Enums.TileType.NpcSpawn && modTypes.Map[mapNum].Tile[x, y].Type != (int)Enums.TileType.Item)
                NpcTileIsOpen = false;

            return NpcTileIsOpen;
        }

        public static bool CanNpcMove(int mapNum, int MapNpcNum, byte Dir)
        {
            int i;
            int n;
            int x;
            int y;
            bool CanNpcMove = false;

            // Check for subscript out of range
            if (mapNum <= 0 || mapNum > S_Instances.MAX_CACHED_MAPS || MapNpcNum <= 0 || MapNpcNum > Constants.MAX_MAP_NPCS || Dir < (int)Enums.DirectionType.Up || Dir > (byte)Enums.DirectionType.Right)
                return false;

            x = modTypes.MapNpc[mapNum].Npc[MapNpcNum].X;
            y = modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y;
            CanNpcMove = true;

            switch (Dir)
            {
                case (int)Enums.DirectionType.Up:
                    {

                        // Check to make sure not outside of boundries
                        if (y > 0)
                        {
                            n = modTypes.Map[mapNum].Tile[x, y - 1].Type;

                            // Check to make sure that the tile is walkable
                            if (n != (int)Enums.TileType.None && n != (int)Enums.TileType.Item && n != (int)Enums.TileType.NpcSpawn)
                            {
                                return false;
                            }

                            var loopTo = S_GameLogic.GetPlayersOnline();

                            // Check to make sure that there is not a player in the way
                            for (i = 1; i <= loopTo; i++)
                            {
                                if (S_NetworkConfig.IsPlaying(i))
                                {
                                    if ((S_Players.GetPlayerMap(i) == mapNum) && (S_Players.GetPlayerX(i) == modTypes.MapNpc[mapNum].Npc[MapNpcNum].X) && (S_Players.GetPlayerY(i) == modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y - 1))
                                    {
                                        return false;
                                    }
                                }
                            }

                            // Check to make sure that there is not another npc in the way
                            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                            {
                                if ((i != MapNpcNum) && (modTypes.MapNpc[mapNum].Npc[i].Num > 0) && (modTypes.MapNpc[mapNum].Npc[i].X == modTypes.MapNpc[mapNum].Npc[MapNpcNum].X) && (modTypes.MapNpc[mapNum].Npc[i].Y == modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y - 1))
                                {
                                    return false;
                                }
                            }
                        }
                        else
                            CanNpcMove = false;
                        break;
                    }

                case (int)Enums.DirectionType.Down:
                    {

                        // Check to make sure not outside of boundries
                        if (y < modTypes.Map[mapNum].MaxY)
                        {
                            n = modTypes.Map[mapNum].Tile[x, y + 1].Type;

                            // Check to make sure that the tile is walkable
                            if (n != (int)Enums.TileType.None && n != (int)Enums.TileType.Item && n != (int)Enums.TileType.NpcSpawn)
                            {
                                return false;
                            }

                            var loopTo1 = S_GameLogic.GetPlayersOnline();

                            // Check to make sure that there is not a player in the way
                            for (i = 1; i <= loopTo1; i++)
                            {
                                if (S_NetworkConfig.IsPlaying(i))
                                {
                                    if ((S_Players.GetPlayerMap(i) == mapNum) && (S_Players.GetPlayerX(i) == modTypes.MapNpc[mapNum].Npc[MapNpcNum].X) && (S_Players.GetPlayerY(i) == modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y + 1))
                                    {
                                        return false;
                                    }
                                }
                            }

                            // Check to make sure that there is not another npc in the way
                            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                            {
                                if ((i != MapNpcNum) && (modTypes.MapNpc[mapNum].Npc[i].Num > 0) && (modTypes.MapNpc[mapNum].Npc[i].X == modTypes.MapNpc[mapNum].Npc[MapNpcNum].X) && (modTypes.MapNpc[mapNum].Npc[i].Y == modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y + 1))
                                {
                                    return false;
                                }
                            }
                        }
                        else
                            CanNpcMove = false;
                        break;
                    }

                case (int)Enums.DirectionType.Left:
                    {

                        // Check to make sure not outside of boundries
                        if (x > 0)
                        {
                            n = modTypes.Map[mapNum].Tile[x - 1, y].Type;

                            // Check to make sure that the tile is walkable
                            if (n != (int)Enums.TileType.None && n != (int)Enums.TileType.Item && n != (int)Enums.TileType.NpcSpawn)
                            {
                                return false;
                            }

                            var loopTo2 = S_GameLogic.GetPlayersOnline();

                            // Check to make sure that there is not a player in the way
                            for (i = 1; i <= loopTo2; i++)
                            {
                                if (S_NetworkConfig.IsPlaying(i))
                                {
                                    if ((S_Players.GetPlayerMap(i) == mapNum) && (S_Players.GetPlayerX(i) == modTypes.MapNpc[mapNum].Npc[MapNpcNum].X - 1) && (S_Players.GetPlayerY(i) == modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y))
                                    {
                                        return false;
                                    }
                                }
                            }

                            // Check to make sure that there is not another npc in the way
                            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                            {
                                if ((i != MapNpcNum) && (modTypes.MapNpc[mapNum].Npc[i].Num > 0) && (modTypes.MapNpc[mapNum].Npc[i].X == modTypes.MapNpc[mapNum].Npc[MapNpcNum].X - 1) && (modTypes.MapNpc[mapNum].Npc[i].Y == modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y))
                                {
                                    return false;
                                }
                            }
                        }
                        else
                            CanNpcMove = false;
                        break;
                    }

                case (int)Enums.DirectionType.Right:
                    {

                        // Check to make sure not outside of boundries
                        if (x < modTypes.Map[mapNum].MaxX)
                        {
                            n = modTypes.Map[mapNum].Tile[x + 1, y].Type;

                            // Check to make sure that the tile is walkable
                            if (n != (int)Enums.TileType.None && n != (int)Enums.TileType.Item && n != (int)Enums.TileType.NpcSpawn)
                            {
                                return false;
                            }

                            var loopTo3 = S_GameLogic.GetPlayersOnline();

                            // Check to make sure that there is not a player in the way
                            for (i = 1; i <= loopTo3; i++)
                            {
                                if (S_NetworkConfig.IsPlaying(i))
                                {
                                    if ((S_Players.GetPlayerMap(i) == mapNum) && (S_Players.GetPlayerX(i) == modTypes.MapNpc[mapNum].Npc[MapNpcNum].X + 1) && (S_Players.GetPlayerY(i) == modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y))
                                    {
                                        return false;
                                    }
                                }
                            }

                            // Check to make sure that there is not another npc in the way
                            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                            {
                                if ((i != MapNpcNum) && (modTypes.MapNpc[mapNum].Npc[i].Num > 0) && (modTypes.MapNpc[mapNum].Npc[i].X == modTypes.MapNpc[mapNum].Npc[MapNpcNum].X + 1) && (modTypes.MapNpc[mapNum].Npc[i].Y == modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y))
                                {
                                    return false;
                                }
                            }
                        }
                        else
                            CanNpcMove = false;
                        break;
                    }
            }

            if (modTypes.MapNpc[mapNum].Npc[MapNpcNum].SkillBuffer > 0)
                CanNpcMove = false;

            return true;
        }

        public static void NpcMove(int mapNum, int MapNpcNum, int Dir, int Movement)
        {
            ByteStream buffer = new ByteStream(4);

            // Check for subscript out of range
            if (mapNum <= 0 || mapNum > S_Instances.MAX_CACHED_MAPS || MapNpcNum <= 0 || MapNpcNum > Constants.MAX_MAP_NPCS || Dir < (int)Enums.DirectionType.Up || Dir > (int)Enums.DirectionType.Right || Movement < 1 || Movement > 2)
                return;

            modTypes.MapNpc[mapNum].Npc[MapNpcNum].Dir = Dir;

            switch (Dir)
            {
                case (int)Enums.DirectionType.Up:
                    {
                        modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y = (byte)(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y - 1);

                        buffer.WriteInt32((int)Packets.ServerPackets.SNpcMove);
                        buffer.WriteInt32(MapNpcNum);
                        buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].X);
                        buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y);
                        buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Dir);
                        buffer.WriteInt32(Movement);

                        modDatabase.Addlog("Sent SMSG: SNpcMove Up", S_Constants.PACKET_LOG);
                        Console.WriteLine("Sent SMSG: SNpcMove Up");

                        S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                        break;
                    }

                case (int)Enums.DirectionType.Down:
                    {
                        modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y = (byte)(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y + 1);

                        buffer.WriteInt32((int)Packets.ServerPackets.SNpcMove);
                        buffer.WriteInt32(MapNpcNum);
                        buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].X);
                        buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y);
                        buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Dir);
                        buffer.WriteInt32(Movement);

                        modDatabase.Addlog("Sent SMSG: SNpcMove Down", S_Constants.PACKET_LOG);
                        Console.WriteLine("Sent SMSG: SNpcMove Down");

                        S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                        break;
                    }

                case (int)Enums.DirectionType.Left:
                    {
                        modTypes.MapNpc[mapNum].Npc[MapNpcNum].X = (byte)(modTypes.MapNpc[mapNum].Npc[MapNpcNum].X - 1);

                        buffer.WriteInt32((int)Packets.ServerPackets.SNpcMove);
                        buffer.WriteInt32(MapNpcNum);
                        buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].X);
                        buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y);
                        buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Dir);
                        buffer.WriteInt32(Movement);

                        modDatabase.Addlog("Sent SMSG: SNpcMove Left", S_Constants.PACKET_LOG);
                        Console.WriteLine("Sent SMSG: SNpcMove Left");

                        S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                        break;
                    }

                case (int)Enums.DirectionType.Right:
                    {
                        modTypes.MapNpc[mapNum].Npc[MapNpcNum].X = (byte)(modTypes.MapNpc[mapNum].Npc[MapNpcNum].X + 1);

                        buffer.WriteInt32((int)Packets.ServerPackets.SNpcMove);
                        buffer.WriteInt32(MapNpcNum);
                        buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].X);
                        buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y);
                        buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Dir);
                        buffer.WriteInt32(Movement);

                        modDatabase.Addlog("Sent SMSG: SNpcMove Right", S_Constants.PACKET_LOG);
                        Console.WriteLine("Sent SMSG: SNpcMove Right");

                        S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                        break;
                    }
            }

            buffer.Dispose();
        }

        public static void NpcDir(int mapNum, int MapNpcNum, int Dir)
        {
            ByteStream buffer = new ByteStream(4);

            // Check for subscript out of range
            if (mapNum <= 0 || mapNum > S_Instances.MAX_CACHED_MAPS || MapNpcNum <= 0 || MapNpcNum > Constants.MAX_MAP_NPCS || Dir < (byte)Enums.DirectionType.Up || Dir > (byte)Enums.DirectionType.Right)
                return;

            modTypes.MapNpc[mapNum].Npc[MapNpcNum].Dir = Dir;

            buffer.WriteInt32((int)Packets.ServerPackets.SNpcDir);
            buffer.WriteInt32(MapNpcNum);
            buffer.WriteInt32(Dir);

            modDatabase.Addlog("Sent SMSG: SNpcDir", S_Constants.PACKET_LOG);
            Console.WriteLine("Sent SMSG: SNpcDir");

            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }



        internal static void TryNpcAttackPlayer(int mapnpcnum, int index)
        {
            int mapNum = 0;
            int npcnum = 0;
            int Damage = 0;
            int i = 0;
            int armor = 0;

            // Can the npc attack the player?

            if (CanNpcAttackPlayer(mapnpcnum, index))
            {
                mapNum = S_Players.GetPlayerMap(index);
                npcnum = modTypes.MapNpc[mapNum].Npc[mapnpcnum].Num;

                // check if PLAYER can avoid the attack
                if (S_Players.CanPlayerDodge(index))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Dodge!", (int)Enums.ColorType.Pink, 1, (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].X * 32), (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Y * 32));
                    return;
                }

                if (S_Players.CanPlayerParry(index))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Parry!", (int)Enums.ColorType.Pink, 1, (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].X * 32), (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Y * 32));
                    return;
                }

                // Get the damage we can do
                Damage = GetNpcDamage(npcnum);

                if (S_Players.CanPlayerBlockHit(index))
                {
                    S_NetworkSend.SendActionMsg(mapNum, "Block!", (int)Enums.ColorType.Pink, 1, (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].X * 32), (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Y * 32));
                    return;
                }
                else
                {
                    for (i = 2; i <= (int)Enums.EquipmentType.Count - 1; i++) // start at 2, so we skip weapon
                    {
                        if (S_Players.GetPlayerEquipment(index, (Enums.EquipmentType)i) > 0)
                            armor = armor + Types.Item[S_Players.GetPlayerEquipment(index, (Enums.EquipmentType)i)].Data2;
                    }
                    // take away armour
                    Damage = Damage - ((S_Players.GetPlayerStat(index, Enums.StatType.Spirit) * 2) + (S_Players.GetPlayerLevel(index) * 2) + armor);

                    // * 1.5 if crit hit
                    if (CanNpcCrit(npcnum))
                    {
                        Damage = (int)(Damage * 1.5);
                        S_NetworkSend.SendActionMsg(mapNum, "Critical!", (int)Enums.ColorType.BrightCyan, 1, (modTypes.MapNpc[mapNum].Npc[mapnpcnum].X * 32), (modTypes.MapNpc[mapNum].Npc[mapnpcnum].Y * 32));
                    }
                }

                if (Damage > 0)
                    NpcAttackPlayer(mapnpcnum, index, Damage);
            }
        }

        public static bool CanNpcAttackPlayer(int MapNpcNum, int index)
        {
            int mapNum;
            int NpcNum;

            // Check for subscript out of range
            if (MapNpcNum <= 0 || MapNpcNum > Constants.MAX_MAP_NPCS || !S_NetworkConfig.IsPlaying(index))
                return false;

            // Check for subscript out of range
            if (modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[MapNpcNum].Num <= 0)
                return false;

            mapNum = S_Players.GetPlayerMap(index);
            NpcNum = modTypes.MapNpc[mapNum].Npc[MapNpcNum].Num;

            // Make sure the npc isn't already dead
            if (modTypes.MapNpc[mapNum].Npc[MapNpcNum].Vital[(int)Enums.VitalType.HP] <= 0)
                return false;

            // Make sure npcs dont attack more then once a second
            if (S_General.GetTimeMs() < modTypes.MapNpc[mapNum].Npc[MapNpcNum].AttackTimer + 1000)
                return false;

            // Make sure we dont attack the player if they are switching maps
            if (modTypes.TempPlayer[index].GettingMap == 1)
                return false;

            modTypes.MapNpc[mapNum].Npc[MapNpcNum].AttackTimer = S_General.GetTimeMs();

            // Make sure they are on the same map
            if (S_NetworkConfig.IsPlaying(index))
            {
                if (NpcNum > 0)
                {

                    // Check if at same coordinates
                    if ((S_Players.GetPlayerY(index) + 1 == modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y) && (S_Players.GetPlayerX(index) == modTypes.MapNpc[mapNum].Npc[MapNpcNum].X))
                        return true;
                    else if ((S_Players.GetPlayerY(index) - 1 == modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y) && (S_Players.GetPlayerX(index) == modTypes.MapNpc[mapNum].Npc[MapNpcNum].X))
                        return true;
                    else if ((S_Players.GetPlayerY(index) == modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y) && (S_Players.GetPlayerX(index) + 1 == modTypes.MapNpc[mapNum].Npc[MapNpcNum].X))
                        return true;
                    else if ((S_Players.GetPlayerY(index) == modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y) && (S_Players.GetPlayerX(index) - 1 == modTypes.MapNpc[mapNum].Npc[MapNpcNum].X))
                        return true;
                }
            }
            return false;
        }

        public static bool CanNpcAttackNpc(int mapNum, int Attacker, int Victim)
        {
            int aNpcNum;
            int vNpcNum;
            int VictimX;
            int VictimY;
            int AttackerX;
            int AttackerY;

            // Check for subscript out of range
            if (Attacker <= 0 || Attacker > Constants.MAX_MAP_NPCS)
                return false;

            if (Victim <= 0 || Victim > Constants.MAX_MAP_NPCS)
                return false;

            // Check for subscript out of range
            if (modTypes.MapNpc[mapNum].Npc[Attacker].Num <= 0)
                return false;

            // Check for subscript out of range
            if (modTypes.MapNpc[mapNum].Npc[Victim].Num <= 0)
                return false;

            aNpcNum = modTypes.MapNpc[mapNum].Npc[Attacker].Num;
            vNpcNum = modTypes.MapNpc[mapNum].Npc[Victim].Num;

            if (aNpcNum <= 0)
                return false;
            if (vNpcNum <= 0)
                return false;

            // Make sure the npcs arent already dead
            if (modTypes.MapNpc[mapNum].Npc[Attacker].Vital[(int)Enums.VitalType.HP] <= 0)
                return false;

            // Make sure the npc isn't already dead
            if (modTypes.MapNpc[mapNum].Npc[Victim].Vital[(int)Enums.VitalType.HP] <= 0)
                return false;

            // Make sure npcs dont attack more then once a second
            if (S_General.GetTimeMs() < modTypes.MapNpc[mapNum].Npc[Attacker].AttackTimer + 1000)
                return false;

            modTypes.MapNpc[mapNum].Npc[Attacker].AttackTimer = S_General.GetTimeMs();

            AttackerX = modTypes.MapNpc[mapNum].Npc[Attacker].X;
            AttackerY = modTypes.MapNpc[mapNum].Npc[Attacker].Y;
            VictimX = modTypes.MapNpc[mapNum].Npc[Victim].X;
            VictimY = modTypes.MapNpc[mapNum].Npc[Victim].Y;

            // Check if at same coordinates
            if ((VictimY + 1 == AttackerY) && (VictimX == AttackerX))
                return true;
            else if ((VictimY - 1 == AttackerY) && (VictimX == AttackerX))
                return true;
            else if ((VictimY == AttackerY) && (VictimX + 1 == AttackerX))
                return true;
            else if ((VictimY == AttackerY) && (VictimX - 1 == AttackerX))
                return true;

            return false;
        }

        internal static void NpcAttackPlayer(int MapNpcNum, int Victim, int Damage)
        {
            string Name;
            int mapNum = 0;
            int z = 0;
            int InvCount = 0;
            int EqCount = 0;
            int j = 0;
            int x = 0;
            ByteStream buffer = new ByteStream(4);

            // Check for subscript out of range

            if (MapNpcNum <= 0 || MapNpcNum > Constants.MAX_MAP_NPCS || S_NetworkConfig.IsPlaying(Victim) == false)
                return;

            // Check for subscript out of range
            if (modTypes.MapNpc[S_Players.GetPlayerMap(Victim)].Npc[MapNpcNum].Num <= 0)
                return;

            mapNum = S_Players.GetPlayerMap(Victim);
            Name = Microsoft.VisualBasic.Strings.Trim(Types.Npc[modTypes.MapNpc[mapNum].Npc[MapNpcNum].Num].Name);

            // Send this packet so they can see the npc attacking
            buffer.WriteInt32((int)Packets.ServerPackets.SNpcAttack);
            buffer.WriteInt32(MapNpcNum);
            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
            buffer.Dispose();

            if (Damage <= 0)
                return;

            // set the regen timer
            modTypes.MapNpc[mapNum].Npc[MapNpcNum].StopRegen = 1;
            modTypes.MapNpc[mapNum].Npc[MapNpcNum].StopRegenTimer = S_General.GetTimeMs();

            if (Damage >= S_Players.GetPlayerVital(Victim, Enums.VitalType.HP))
            {
                // Say damage
                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(Victim), "-" + S_Players.GetPlayerVital(Victim, Enums.VitalType.HP), (int)Enums.ColorType.BrightRed, 1, (S_Players.GetPlayerX(Victim) * 32), (S_Players.GetPlayerY(Victim) * 32));

                // Set NPC target to 0
                modTypes.MapNpc[mapNum].Npc[MapNpcNum].Target = 0;
                modTypes.MapNpc[mapNum].Npc[MapNpcNum].TargetType = 0;

                if (S_Players.GetPlayerLevel(Victim) >= 10)
                {
                    for (z = 1; z <= Constants.MAX_INV; z++)
                    {
                        if (S_Players.GetPlayerInvItemNum(Victim, z) > 0)
                            InvCount = InvCount + 1;
                    }

                    for (z = 1; z <= (int)Enums.EquipmentType.Count - 1; z++)
                    {
                        if (S_Players.GetPlayerEquipment(Victim, (Enums.EquipmentType)z) > 0)
                            EqCount = EqCount + 1;
                    }
                    z = S_GameLogic.Random(1, InvCount + EqCount);

                    if (z == 0)
                        z = 1;
                    if (z > InvCount + EqCount)
                        z = InvCount + EqCount;
                    if (z > InvCount)
                    {
                        z = z - InvCount;

                        for (x = 1; x <= (int)Enums.EquipmentType.Count - 1; x++)
                        {
                            if (S_Players.GetPlayerEquipment(Victim, (Enums.EquipmentType)x) > 0)
                            {
                                j = j + 1;

                                if (j == z)
                                {
                                    // Here it is, drop this piece of equipment!
                                    S_NetworkSend.PlayerMsg(Victim, "In death you lost grip on your " + Microsoft.VisualBasic.Strings.Trim(Types.Item[S_Players.GetPlayerEquipment(Victim, (Enums.EquipmentType)x)].Name), (int)Enums.ColorType.BrightRed);
                                    S_Items.SpawnItem(S_Players.GetPlayerEquipment(Victim, (Enums.EquipmentType)x), 1, S_Players.GetPlayerMap(Victim), S_Players.GetPlayerX(Victim), S_Players.GetPlayerY(Victim));
                                    S_Players.SetPlayerEquipment(Victim, 0, (Enums.EquipmentType)x);
                                    S_NetworkSend.SendWornEquipment(Victim);
                                    S_NetworkSend.SendMapEquipment(Victim);
                                }
                            }
                        }
                    }
                    else
                        for (x = 1; x <= Constants.MAX_INV; x++)
                        {
                            if (S_Players.GetPlayerInvItemNum(Victim, x) > 0)
                            {
                                j = j + 1;

                                if (j == z)
                                {
                                    // Here it is, drop this item!
                                    S_NetworkSend.PlayerMsg(Victim, "In death you lost grip on your " + Microsoft.VisualBasic.Strings.Trim(Types.Item[S_Players.GetPlayerInvItemNum(Victim, x)].Name), (int)Enums.ColorType.BrightRed);
                                    S_Items.SpawnItem(S_Players.GetPlayerInvItemNum(Victim, x), S_Players.GetPlayerInvItemValue(Victim, x), S_Players.GetPlayerMap(Victim), S_Players.GetPlayerX(Victim), S_Players.GetPlayerY(Victim));
                                    S_Players.SetPlayerInvItemNum(Victim, x, 0);
                                    S_Players.SetPlayerInvItemValue(Victim, x, 0);
                                    S_NetworkSend.SendInventory(Victim);
                                }
                            }
                        }
                }

                // kill player
                S_Players.KillPlayer(Victim);

                // Player is dead
                S_NetworkSend.GlobalMsg(S_Players.GetPlayerName(Victim) + " has been killed by " + Name);
            }
            else
            {
                // Player not dead, just do the damage
                S_Players.SetPlayerVital(Victim, Enums.VitalType.HP, S_Players.GetPlayerVital(Victim, Enums.VitalType.HP) - Damage);
                S_NetworkSend.SendVital(Victim, Enums.VitalType.HP);
                S_Animations.SendAnimation(mapNum, Types.Npc[modTypes.MapNpc[S_Players.GetPlayerMap(Victim)].Npc[MapNpcNum].Num].Animation, 0, 0, (byte)Enums.TargetType.Player, Victim);

                // send vitals to party if in one
                if (modTypes.TempPlayer[Victim].InParty > 0)
                    S_Parties.SendPartyVitals(modTypes.TempPlayer[Victim].InParty, Victim);

                // send the sound
                // SendMapSound Victim, GetPlayerX(Victim), GetPlayerY(Victim), SoundEntity.seNpc, MapNpc(MapNum).Npc(MapNpcNum).Num

                // Say damage
                S_NetworkSend.SendActionMsg(S_Players.GetPlayerMap(Victim), "-" + Damage, (int)Enums.ColorType.BrightRed, 1, (S_Players.GetPlayerX(Victim) * 32), (S_Players.GetPlayerY(Victim) * 32));
                S_NetworkSend.SendBlood(S_Players.GetPlayerMap(Victim), S_Players.GetPlayerX(Victim), S_Players.GetPlayerY(Victim));

                // set the regen timer
                modTypes.TempPlayer[Victim].StopRegen = 1;
                modTypes.TempPlayer[Victim].StopRegenTimer = S_General.GetTimeMs();
            }
        }

        public static void NpcAttackNpc(int mapNum, int Attacker, int Victim, int Damage)
        {
            ByteStream buffer = new ByteStream(4);
            int aNpcNum;
            int vNpcNum;
            int n;

            if (Attacker <= 0 || Attacker > Constants.MAX_MAP_NPCS)
                return;
            if (Victim <= 0 || Victim > Constants.MAX_MAP_NPCS)
                return;

            if (Damage <= 0)
                return;

            aNpcNum = modTypes.MapNpc[mapNum].Npc[Attacker].Num;
            vNpcNum = modTypes.MapNpc[mapNum].Npc[Victim].Num;

            if (aNpcNum <= 0)
                return;
            if (vNpcNum <= 0)
                return;

            // Send this packet so they can see the person attacking
            buffer.WriteInt32((int)Packets.ServerPackets.SNpcAttack);
            buffer.WriteInt32(Attacker);
            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
            buffer.Dispose();

            if (Damage >= modTypes.MapNpc[mapNum].Npc[Victim].Vital[(byte)Enums.VitalType.HP])
            {
                S_NetworkSend.SendActionMsg(mapNum, "-" + Damage, (int)Enums.ColorType.BrightRed, 1, (modTypes.MapNpc[mapNum].Npc[Victim].X * 32), (modTypes.MapNpc[mapNum].Npc[Victim].Y * 32));
                S_NetworkSend.SendBlood(mapNum, modTypes.MapNpc[mapNum].Npc[Victim].X, modTypes.MapNpc[mapNum].Npc[Victim].Y);

                // npc is dead.

                // Set NPC target to 0
                modTypes.MapNpc[mapNum].Npc[Attacker].Target = 0;
                modTypes.MapNpc[mapNum].Npc[Attacker].TargetType = 0;

                // Drop the goods if they get it
                var tmpitem = S_GameLogic.Random(1, 5);
                n = (int)Conversion.Int(VBMath.Rnd() * Types.Npc[vNpcNum].DropChance[tmpitem]) + 1;
                if (n == 1)
                    S_Items.SpawnItem(Types.Npc[vNpcNum].DropItem[tmpitem], Types.Npc[vNpcNum].DropItemValue[tmpitem], mapNum, modTypes.MapNpc[mapNum].Npc[Victim].X, modTypes.MapNpc[mapNum].Npc[Victim].Y);

                // Reset victim's stuff so it dies in loop
                modTypes.MapNpc[mapNum].Npc[Victim].Num = 0;
                modTypes.MapNpc[mapNum].Npc[Victim].SpawnWait = S_General.GetTimeMs();
                modTypes.MapNpc[mapNum].Npc[Victim].Vital[(byte)Enums.VitalType.HP] = 0;

                // send npc death packet to map
                buffer = new ByteStream(4);
                buffer.WriteInt32((int)Packets.ServerPackets.SNpcDead);
                buffer.WriteInt32(Victim);
                S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                buffer.Dispose();
            }
            else
            {
                // npc not dead, just do the damage
                modTypes.MapNpc[mapNum].Npc[Victim].Vital[(byte)Enums.VitalType.HP] = modTypes.MapNpc[mapNum].Npc[Victim].Vital[(byte)Enums.VitalType.HP] - Damage;
                // Say damage
                S_NetworkSend.SendActionMsg(mapNum, "-" + Damage, (int)Enums.ColorType.BrightRed, 1, (modTypes.MapNpc[mapNum].Npc[Victim].X * 32), (modTypes.MapNpc[mapNum].Npc[Victim].Y * 32));
                S_NetworkSend.SendBlood(mapNum, modTypes.MapNpc[mapNum].Npc[Victim].X, modTypes.MapNpc[mapNum].Npc[Victim].Y);
            }
        }

        internal static void KnockBackNpc(int index, int NpcNum, int IsSkill = 0)
        {
            if (IsSkill > 0)
            {
                var loopTo = Types.Skill[IsSkill].KnockBackTiles;
                for (var i = 1; i <= loopTo; i++)
                {
                    if (CanNpcMove(S_Players.GetPlayerMap(index), NpcNum, (byte)S_Players.GetPlayerDir(index)))
                        NpcMove(S_Players.GetPlayerMap(index), NpcNum, S_Players.GetPlayerDir(index), (byte)Enums.MovementType.Walking);
                }
                modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[NpcNum].StunDuration = 1;
                modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[NpcNum].StunTimer = S_General.GetTimeMs();
            }
            else if (Types.Item[S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Weapon)].KnockBack == 1)
            {
                var loopTo1 = Types.Item[S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Weapon)].KnockBackTiles;
                for (var i = 1; i <= loopTo1; i++)
                {
                    if (CanNpcMove(S_Players.GetPlayerMap(index), NpcNum, (byte)S_Players.GetPlayerDir(index)))
                        NpcMove(S_Players.GetPlayerMap(index), NpcNum, S_Players.GetPlayerDir(index), (byte)Enums.MovementType.Walking);
                }
                modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[NpcNum].StunDuration = 1;
                modTypes.MapNpc[S_Players.GetPlayerMap(index)].Npc[NpcNum].StunTimer = S_General.GetTimeMs();
            }
        }

        internal static int RandomNpcAttack(int mapNum, int MapNpcNum)
        {
            int i;
            List<byte> SkillList = new List<byte>();

            int RandomNpcAttack = 0;

            if (modTypes.MapNpc[mapNum].Npc[MapNpcNum].SkillBuffer > 0)
                return 0;

            for (i = 1; i <= Constants.MAX_NPC_SKILLS; i++)
            {
                if (Types.Npc[modTypes.MapNpc[mapNum].Npc[MapNpcNum].Num].Skill[i] > 0)
                    SkillList.Add(Types.Npc[modTypes.MapNpc[mapNum].Npc[MapNpcNum].Num].Skill[i]);
            }

            if (SkillList.Count > 1)
                RandomNpcAttack = SkillList[S_GameLogic.Random(0, SkillList.Count - 1)];
            else
                RandomNpcAttack = 0;

            return RandomNpcAttack;
        }

        internal static int GetNpcSkill(int NpcNum, int skillslot)
        {
            return Types.Npc[NpcNum].Skill[skillslot];
        }

        internal static void BufferNpcSkill(int mapNum, int MapNpcNum, int skillslot)
        {
            int skillnum;
            int MPCost;
            int SkillCastType;
            int range;
            bool HasBuffered;

            byte TargetType;
            int Target;

            // Prevent subscript out of range
            if (skillslot <= 0 || skillslot > Constants.MAX_NPC_SKILLS)
                return;

            skillnum = GetNpcSkill(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Num, skillslot);

            if (skillnum <= 0 || skillnum > Constants.MAX_SKILLS)
                return;

            // see if cooldown has finished
            if (modTypes.MapNpc[mapNum].Npc[MapNpcNum].SkillCd[skillslot] > S_General.GetTimeMs())
            {
                TryNpcAttackPlayer(MapNpcNum, modTypes.MapNpc[mapNum].Npc[MapNpcNum].Target);
                return;
            }

            MPCost = Types.Skill[skillnum].MpCost;

            // Check if they have enough MP
            if (modTypes.MapNpc[mapNum].Npc[MapNpcNum].Vital[(byte)Enums.VitalType.MP] < MPCost)
                return;

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

            TargetType = modTypes.MapNpc[mapNum].Npc[MapNpcNum].TargetType;
            Target = modTypes.MapNpc[mapNum].Npc[MapNpcNum].Target;
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
                            return;
                        if (TargetType == (int)Enums.TargetType.Player)
                        {
                            // if have target, check in range
                            if (!S_Players.IsInRange(range, modTypes.MapNpc[mapNum].Npc[MapNpcNum].X, modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y, S_Players.GetPlayerX(Target), S_Players.GetPlayerY(Target)))
                                return;
                            else
                                HasBuffered = true;
                        }
                        else if (TargetType == (int)Enums.TargetType.Npc)
                        {
                        }

                        break;
                    }
            }

            if (HasBuffered)
            {
                S_Animations.SendAnimation(mapNum, Types.Skill[skillnum].CastAnim, 0, 0, (byte)Enums.TargetType.Player, Target);
                modTypes.MapNpc[mapNum].Npc[MapNpcNum].SkillBuffer = skillslot;
                modTypes.MapNpc[mapNum].Npc[MapNpcNum].SkillBufferTimer = S_General.GetTimeMs();
                return;
            }
        }

        internal static bool CanNpcBlock(int npcnum)
        {
            int rate;
            int stat;
            int rndNum;

            bool CanNpcBlock = false;

            stat = Types.Npc[npcnum].Stat[(byte)Enums.StatType.Luck] / (int)5;  // guessed shield agility
            rate = (int)(stat / 12.08);
            rndNum = S_GameLogic.Random(1, 100);

            if (rndNum <= rate)
                CanNpcBlock = true;
            return CanNpcBlock;
        }

        internal static bool CanNpcCrit(int npcnum)
        {
            int rate;
            int rndNum;

            bool CanNpcCrit = false;

            rate = Types.Npc[npcnum].Stat[(byte)Enums.StatType.Luck] / (int)3;
            rndNum = S_GameLogic.Random(1, 100);

            if (rndNum <= rate)
                CanNpcCrit = true;
            return CanNpcCrit;
        }

        internal static bool CanNpcDodge(int npcnum)
        {
            int rate;
            int rndNum;

            bool CanNpcDodge = false;

            rate = Types.Npc[npcnum].Stat[(byte)Enums.StatType.Luck] / (int)4;
            rndNum = S_GameLogic.Random(1, 100);

            if (rndNum <= rate)
                CanNpcDodge = true;
            return CanNpcDodge;
        }

        internal static bool CanNpcParry(int npcnum)
        {
            int rate;
            int rndNum;

            bool CanNpcParry = false;

            rate = Types.Npc[npcnum].Stat[(byte)Enums.StatType.Luck] / (int)6;
            rndNum = S_GameLogic.Random(1, 100);

            if (rndNum <= rate)
                CanNpcParry = true;
            return CanNpcParry;
        }

        public static int GetNpcDamage(int npcnum)
        {
            return (Types.Npc[npcnum].Stat[(byte)Enums.StatType.Strength] * 2) + (Types.Npc[npcnum].Damage * 2) + (Types.Npc[npcnum].Level * 3) + S_GameLogic.Random(1, 20);
        }

        internal static void SpellNpc_Effect(byte Vital, bool increment, int index, int Damage, int Skillnum, int mapNum)
        {
            string sSymbol;
            int Colour = 0;

            if (Damage > 0)
            {
                if (increment)
                {
                    sSymbol = "+";
                    if (Vital == (int)Enums.VitalType.HP)
                        Colour = (int)Enums.ColorType.BrightGreen;
                    if (Vital == (int)Enums.VitalType.MP)
                        Colour = (int)Enums.ColorType.BrightBlue;
                }
                else
                {
                    sSymbol = "-";
                    Colour = (int)Enums.ColorType.Blue;
                }

                S_Animations.SendAnimation(mapNum, Types.Skill[Skillnum].SkillAnim, 0, 0, (byte)Enums.TargetType.Npc, index);
                S_NetworkSend.SendActionMsg(mapNum, sSymbol + Damage, Colour, (byte)Enums.ActionMsgType.Scroll, modTypes.MapNpc[mapNum].Npc[index].X * 32, modTypes.MapNpc[mapNum].Npc[index].Y * 32);

                // send the sound
                // SendMapSound(Index, MapNpc(MapNum).Npc(Index).x, MapNpc(MapNum).Npc(Index).y, SoundEntity.seSpell, Skillnum)

                if (increment)
                {
                    modTypes.MapNpc[mapNum].Npc[index].Vital[Vital] = modTypes.MapNpc[mapNum].Npc[index].Vital[Vital] + Damage;

                    if (Types.Skill[Skillnum].Duration > 0)
                    {
                    }
                }
                else if (!increment)
                    modTypes.MapNpc[mapNum].Npc[index].Vital[Vital] = modTypes.MapNpc[mapNum].Npc[index].Vital[Vital] - Damage;
            }
        }

        internal static bool IsNpcDead(int mapNum, int MapNpcNum)
        {
            bool IsNpcDead = false;
            bool flag = mapNum < 0 || mapNum > 500 || MapNpcNum < 0 || MapNpcNum > 30;
            if (!flag)
            {
                bool flag2 = modTypes.MapNpc[mapNum].Npc[MapNpcNum].Vital[1] <= 0;
                if (flag2)
                {
                    IsNpcDead = true;
                }
            }
            return IsNpcDead;
        }

        internal static void DropNpcItems(int mapNum, int MapNpcNum)
        {
            var NpcNum = modTypes.MapNpc[mapNum].Npc[MapNpcNum].Num;
            var tmpitem = S_GameLogic.Random(1, 5);
            var n = Conversion.Int(VBMath.Rnd() * Types.Npc[NpcNum].DropChance[tmpitem]) + 1;

            if (n == 1)
                S_Items.SpawnItem(Types.Npc[NpcNum].DropItem[tmpitem], Types.Npc[NpcNum].DropItemValue[tmpitem], mapNum, modTypes.MapNpc[mapNum].Npc[MapNpcNum].X, modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y);
        }



        public static void SendMapNpcsToMap(int mapNum)
        {
            int i;
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SMapNpcData);

            S_General.AddDebug("Sent SMSG: SMapNpcData");

            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
            {
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Num);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].X);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Y);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Dir);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Vital[(byte)Enums.VitalType.HP]);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Vital[(byte)Enums.VitalType.MP]);
            }

            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }



        public static void Packet_EditNpc(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved EMSG: RequestEditNpc");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Developer)
                return;

            var Buffer = new ByteStream(4);
            Buffer.WriteInt32((int)Packets.ServerPackets.SNpcEditor);
            S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);

            S_General.AddDebug("Sent SMSG: SNpcEditor");

            Buffer.Dispose();
        }

        public static void Packet_SaveNPC(int index, ref byte[] data)
        {
            int NpcNum;
            int i;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved EMSG: SaveNpc");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Developer)
                return;

            NpcNum = buffer.ReadInt32();

            // Update the Npc
            Types.Npc[NpcNum].Animation = buffer.ReadInt32();
            Types.Npc[NpcNum].AttackSay = buffer.ReadString();
            Types.Npc[NpcNum].Behaviour = (byte)buffer.ReadInt32();
            for (i = 1; i <= 5; i++)
            {
                Types.Npc[NpcNum].DropChance[i] = buffer.ReadInt32();
                Types.Npc[NpcNum].DropItem[i] = buffer.ReadInt32();
                Types.Npc[NpcNum].DropItemValue[i] = buffer.ReadInt32();
            }

            Types.Npc[NpcNum].Exp = buffer.ReadInt32();
            Types.Npc[NpcNum].Faction = (byte)buffer.ReadInt32();
            Types.Npc[NpcNum].Hp = buffer.ReadInt32();
            Types.Npc[NpcNum].Name = buffer.ReadString();
            Types.Npc[NpcNum].Range = (byte)buffer.ReadInt32();
            Types.Npc[NpcNum].SpawnTime = (byte)buffer.ReadInt32();
            Types.Npc[NpcNum].SpawnSecs = buffer.ReadInt32();
            Types.Npc[NpcNum].Sprite = buffer.ReadInt32();

            for (i = 0; i <= (int)Enums.StatType.Count - 1; i++)
                Types.Npc[NpcNum].Stat[i] = (byte)buffer.ReadInt32();

            Types.Npc[NpcNum].QuestNum = buffer.ReadInt32();

            for (i = 1; i <= Constants.MAX_NPC_SKILLS; i++)
                Types.Npc[NpcNum].Skill[i] = (byte)buffer.ReadInt32();

            Types.Npc[NpcNum].Level = buffer.ReadInt32();
            Types.Npc[NpcNum].Damage = buffer.ReadInt32();

            // Save it
            SendUpdateNpcToAll(NpcNum);
            modDatabase.SaveNpc(NpcNum);
            modDatabase.Addlog(S_Players.GetPlayerLogin(index) + " saved Npc #" + NpcNum + ".", S_Constants.ADMIN_LOG);

            buffer.Dispose();
        }

        public static void SendNpcs(int index)
        {
            int i;

            for (i = 1; i <= Constants.MAX_NPCS; i++)
            {
                if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Npc[i].Name)) > 0)
                    SendUpdateNpcTo(index, i);
            }
        }

        public static void SendUpdateNpcTo(int index, int NpcNum)
        {
            ByteStream buffer;
            int i;
            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SUpdateNpc);

            S_General.AddDebug("Sent SMSG: SUpdateNpc");

            buffer.WriteInt32(NpcNum);
            buffer.WriteInt32(Types.Npc[NpcNum].Animation);
            buffer.WriteString((Types.Npc[NpcNum].AttackSay));
            buffer.WriteInt32(Types.Npc[NpcNum].Behaviour);

            for (i = 1; i <= 5; i++)
            {
                buffer.WriteInt32(Types.Npc[NpcNum].DropChance[i]);
                buffer.WriteInt32(Types.Npc[NpcNum].DropItem[i]);
                buffer.WriteInt32(Types.Npc[NpcNum].DropItemValue[i]);
            }

            buffer.WriteInt32(Types.Npc[NpcNum].Exp);
            buffer.WriteInt32(Types.Npc[NpcNum].Faction);
            buffer.WriteInt32(Types.Npc[NpcNum].Hp);
            buffer.WriteString((Types.Npc[NpcNum].Name));
            buffer.WriteInt32(Types.Npc[NpcNum].Range);
            buffer.WriteInt32(Types.Npc[NpcNum].SpawnTime);
            buffer.WriteInt32(Types.Npc[NpcNum].SpawnSecs);
            buffer.WriteInt32(Types.Npc[NpcNum].Sprite);

            for (i = 0; i <= (int)Enums.StatType.Count - 1; i++)
                buffer.WriteInt32(Types.Npc[NpcNum].Stat[i]);

            buffer.WriteInt32(Types.Npc[NpcNum].QuestNum);

            for (i = 1; i <= Constants.MAX_NPC_SKILLS; i++)
                buffer.WriteInt32(Types.Npc[NpcNum].Skill[i]);

            buffer.WriteInt32(Types.Npc[NpcNum].Level);
            buffer.WriteInt32(Types.Npc[NpcNum].Damage);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendUpdateNpcToAll(int NpcNum)
        {
            ByteStream buffer;
            int i;
            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SUpdateNpc);

            S_General.AddDebug("Sent SMSG: SUpdateNpc To All");

            buffer.WriteInt32(NpcNum);
            buffer.WriteInt32(Types.Npc[NpcNum].Animation);
            buffer.WriteString((Types.Npc[NpcNum].AttackSay));
            buffer.WriteInt32(Types.Npc[NpcNum].Behaviour);

            for (i = 1; i <= 5; i++)
            {
                buffer.WriteInt32(Types.Npc[NpcNum].DropChance[i]);
                buffer.WriteInt32(Types.Npc[NpcNum].DropItem[i]);
                buffer.WriteInt32(Types.Npc[NpcNum].DropItemValue[i]);
            }

            buffer.WriteInt32(Types.Npc[NpcNum].Exp);
            buffer.WriteInt32(Types.Npc[NpcNum].Faction);
            buffer.WriteInt32(Types.Npc[NpcNum].Hp);
            buffer.WriteString((Types.Npc[NpcNum].Name));
            buffer.WriteInt32(Types.Npc[NpcNum].Range);
            buffer.WriteInt32(Types.Npc[NpcNum].SpawnTime);
            buffer.WriteInt32(Types.Npc[NpcNum].SpawnSecs);
            buffer.WriteInt32(Types.Npc[NpcNum].Sprite);

            for (i = 0; i <= (int)Enums.StatType.Count - 1; i++)
                buffer.WriteInt32(Types.Npc[NpcNum].Stat[i]);

            buffer.WriteInt32(Types.Npc[NpcNum].QuestNum);

            for (i = 1; i <= Constants.MAX_NPC_SKILLS; i++)
                buffer.WriteInt32(Types.Npc[NpcNum].Skill[i]);

            buffer.WriteInt32(Types.Npc[NpcNum].Level);
            buffer.WriteInt32(Types.Npc[NpcNum].Damage);

            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendMapNpcsTo(int index, int mapNum)
        {
            int i;
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SMapNpcData);

            S_General.AddDebug("Sent SMSG: SMapNpcData");

            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
            {
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Num);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].X);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Y);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Dir);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Vital[(byte)Enums.VitalType.HP]);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[i].Vital[(byte)Enums.VitalType.MP]);
            }

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendMapNpcTo(int mapNum, int MapNpcNum)
        {
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SMapNpcUpdate);

            S_General.AddDebug("Sent SMSG: SMapNpcUpdate");

            buffer.WriteInt32(MapNpcNum);

            {
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Num);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].X);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Y);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Dir);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Vital[(byte)Enums.VitalType.HP]);
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Vital[(byte)Enums.VitalType.MP]);
            }

            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendMapNpcVitals(int mapNum, byte MapNpcNum)
        {
            int i;
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SMapNpcVitals);
            buffer.WriteInt32(MapNpcNum);

            S_General.AddDebug("Sent SMSG: SMapNpcVitals");

            for (i = 1; i <= (int)Enums.VitalType.Count - 1; i++)
                buffer.WriteInt32(modTypes.MapNpc[mapNum].Npc[MapNpcNum].Vital[i]);

            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendNpcAttack(int index, int NpcNum)
        {
            var Buffer = new ByteStream(4);
            Buffer.WriteInt32((int)Packets.ServerPackets.SAttack);

            S_General.AddDebug("Sent SMSG: SNpcAttack");

            Buffer.WriteInt32(NpcNum);
            S_NetworkConfig.SendDataToMap(S_Players.GetPlayerMap(index), ref Buffer.Data, Buffer.Head);
            Buffer.Dispose();
        }

        public static void SendNpcDead(int mapNum, int index)
        {
            var Buffer = new ByteStream(4);
            Buffer.WriteInt32((int)Packets.ServerPackets.SNpcDead);

            S_General.AddDebug("Sent SMSG: SNpcDead");

            Buffer.WriteInt32(index);
            S_NetworkConfig.SendDataToMap(mapNum, ref Buffer.Data, Buffer.Head);
            Buffer.Dispose();
        }
    }
}
