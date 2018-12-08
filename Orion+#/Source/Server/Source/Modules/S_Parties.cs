using System;
using ASFW;
using static Engine.Enums;

namespace Engine
{
    static class S_Parties
    {
        internal static PartyRec[] Party = new PartyRec[36];

        internal struct PartyRec
        {
            public int Leader;
            public int[] Member;
            public int MemberCount;
        }



        public static void SendDataToParty(int partyNum, ref byte[] data)
        {
            int i;
            var loopTo = Party[partyNum].MemberCount;
            for (i = 1; i <= loopTo; i++)
            {
                if (Party[partyNum].Member[i] > 0)
                    S_NetworkConfig.Socket.SendDataTo(Party[partyNum].Member[i], data, data.Length);
            }
        }

        public static void SendPartyInvite(int index, int target)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32((byte)Packets.ServerPackets.SPartyInvite);

            modDatabase.Addlog("Sent SMSG: SPartyInvite", S_Constants.PACKET_LOG);
            Console.WriteLine("Sent SMSG: SPartyInvite");

            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Player[target].Character[modTypes.TempPlayer[target].CurChar].Name)));

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendPartyUpdate(int partyNum)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32((byte)Packets.ServerPackets.SPartyUpdate);

            modDatabase.Addlog("Sent SMSG: SPartyUpdate", S_Constants.PACKET_LOG);
            Console.WriteLine("Sent SMSG: SPartyUpdate");

            buffer.WriteInt32(1);
            buffer.WriteInt32(Party[partyNum].Leader);
            for (var i = 1; i <= Constants.MAX_PARTY_MEMBERS; i++)
                buffer.WriteInt32(Party[partyNum].Member[i]);
            buffer.WriteInt32(Party[partyNum].MemberCount);

            byte[] bufferArray = buffer.ToArray();

            SendDataToParty(partyNum, ref bufferArray);
            buffer.Dispose();
        }

        public static void SendPartyUpdateTo(int index)
        {
            ByteStream buffer = new ByteStream(4);
            int i;
            int partyNum;

            buffer.WriteInt32((byte)Packets.ServerPackets.SPartyUpdate);

            modDatabase.Addlog("Sent SMSG: SPartyUpdate To Players", S_Constants.PACKET_LOG);
            Console.WriteLine("Sent SMSG: SPartyUpdate To Players");

            // check if we're in a party
            partyNum = modTypes.TempPlayer[index].InParty;
            if (partyNum > 0)
            {
                // send party data
                buffer.WriteInt32(1);
                buffer.WriteInt32(Party[partyNum].Leader);
                for (i = 1; i <= Constants.MAX_PARTY_MEMBERS; i++)
                    buffer.WriteInt32(Party[partyNum].Member[i]);
                buffer.WriteInt32(Party[partyNum].MemberCount);
            }
            else
                // send clear command
                buffer.WriteInt32(0);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendPartyVitals(int partyNum, int index)
        {
            ByteStream buffer;
            int i;

            buffer = new ByteStream(4);
            buffer.WriteInt32((byte)Packets.ServerPackets.SPartyVitals);
            buffer.WriteInt32(index);

            modDatabase.Addlog("Sent SMSG: SPartyVitals", S_Constants.PACKET_LOG);
            Console.WriteLine("Sent SMSG: SPartyVitals");

            for (i = 1; i <= (byte)Enums.VitalType.Count - 1; i++)
            {
                buffer.WriteInt32(S_Players.GetPlayerMaxVital(index, (VitalType)i));
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Vital[i]);
            }

            byte[] bufferArray = buffer.ToArray();

            SendDataToParty(partyNum, ref bufferArray);
            buffer.Dispose();
        }



        internal static void Packet_PartyRquest(int index, ref byte[] data)
        {
            modDatabase.Addlog("Recieved CMSG: CRequestParty", S_Constants.PACKET_LOG);
            Console.WriteLine("Recieved CMSG: CRequestParty");

            // Prevent partying with self
            if (modTypes.TempPlayer[index].Target == index)
                return;
            // make sure it's a valid target
            if (modTypes.TempPlayer[index].TargetType != (byte)Enums.TargetType.Player)
                return;

            // make sure they're connected and on the same map
            if (!S_NetworkConfig.Socket.IsConnected(modTypes.TempPlayer[index].Target) || !S_NetworkConfig.IsPlaying(modTypes.TempPlayer[index].Target))
                return;
            if (S_Players.GetPlayerMap(modTypes.TempPlayer[index].Target) != S_Players.GetPlayerMap(index))
                return;

            // init the request
            Party_Invite(index, modTypes.TempPlayer[index].Target);
        }

        internal static void Packet_AcceptParty(int index, ref byte[] data)
        {
            modDatabase.Addlog("Recieved CMSG: CAcceptParty", S_Constants.PACKET_LOG);
            Console.WriteLine("Recieved CMSG: CAcceptParty");

            Party_InviteAccept(modTypes.TempPlayer[index].PartyInvite, index);
        }

        internal static void Packet_DeclineParty(int index, ref byte[] data)
        {
            modDatabase.Addlog("Recieved CMSG: CDeclineParty", S_Constants.PACKET_LOG);
            Console.WriteLine("Recieved CMSG: CDeclineParty");

            Party_InviteDecline(modTypes.TempPlayer[index].PartyInvite, index);
        }

        internal static void Packet_LeaveParty(int index, ref byte[] data)
        {
            modDatabase.Addlog("Recieved CMSG: CLeaveParty", S_Constants.PACKET_LOG);
            Console.WriteLine("Recieved CMSG: CLeaveParty");

            Party_PlayerLeave(index);
        }

        internal static void Packet_PartyChatMsg(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);
            modDatabase.Addlog("Recieved CMSG: CPartyChatMsg", S_Constants.PACKET_LOG);
            Console.WriteLine("Recieved CMSG: CPartyChatMsg");

            PartyMsg(index, buffer.ReadString());

            buffer.Dispose();
        }


        public static void ClearParties()
        {
            int i;

            for (i = 1; i <= Constants.MAX_PARTIES; i++)
                ClearParty(i);
        }

        public static void ClearParty(int partyNum)
        {
            Party[partyNum] = default(PartyRec);
            Party[partyNum].Leader = 0;
            Party[partyNum].MemberCount = 0;
            Party[partyNum].Member = new int[5];
        }

        internal static void PartyMsg(int partyNum, string msg)
        {
            int i;

            // send message to all people
            for (i = 1; i <= Constants.MAX_PARTY_MEMBERS; i++)
            {
                // exist?
                if (Party[partyNum].Member[i] > 0)
                {
                    // make sure they're logged on
                    if (S_NetworkConfig.Socket.IsConnected(Party[partyNum].Member[i]) && S_NetworkConfig.IsPlaying(Party[partyNum].Member[i]))
                        S_NetworkSend.PlayerMsg(Party[partyNum].Member[i], msg, (int)Enums.ColorType.BrightBlue);
                }
            }
        }

        private static void Party_RemoveFromParty(int index, int partyNum)
        {
            for (var i = 1; i <= Constants.MAX_PARTY_MEMBERS; i++)
            {
                if (Party[partyNum].Member[i] == index)
                {
                    Party[partyNum].Member[i] = 0;
                    modTypes.TempPlayer[index].InParty = 0;
                    modTypes.TempPlayer[index].PartyInvite = 0;
                    break;
                }
            }
            Party_CountMembers(partyNum);
            SendPartyUpdate(partyNum);
            SendPartyUpdateTo(index);
        }

        internal static void Party_PlayerLeave(int index)
        {
            int partyNum;
            int i;

            partyNum = modTypes.TempPlayer[index].InParty;

            if (partyNum > 0)
            {
                // find out how many members we have
                Party_CountMembers(partyNum);
                // make sure there's more than 2 people
                if (Party[partyNum].MemberCount > 2)
                {

                    // check if leader
                    if (Party[partyNum].Leader == index)
                    {
                        // set next person down as leader
                        for (i = 1; i <= Constants.MAX_PARTY_MEMBERS; i++)
                        {
                            if (Party[partyNum].Member[i] > 0 && Party[partyNum].Member[i] != index)
                            {
                                Party[partyNum].Leader = Party[partyNum].Member[i];
                                PartyMsg(partyNum, string.Format("{0} is now the party leader.", S_Players.GetPlayerName(i)));
                                break;
                            }
                        }
                        // leave party
                        PartyMsg(partyNum, string.Format("{0} has left the party.", S_Players.GetPlayerName(index)));
                        Party_RemoveFromParty(index, partyNum);
                    }
                    else
                    {
                        // not the leader, just leave
                        PartyMsg(partyNum, string.Format("{0} has left the party.", S_Players.GetPlayerName(index)));
                        Party_RemoveFromParty(index, partyNum);
                    }
                }
                else
                {
                    // find out how many members we have
                    Party_CountMembers(partyNum);
                    // only 2 people, disband
                    PartyMsg(partyNum, "The party has been disbanded.");

                    // clear out everyone's party
                    for (i = 1; i <= Constants.MAX_PARTY_MEMBERS; i++)
                    {
                        index = Party[partyNum].Member[i];
                        // player exist?
                        if (index > 0)
                            Party_RemoveFromParty(index, partyNum);
                    }
                    // clear out the party itself
                    ClearParty(partyNum);
                }
            }
        }

        internal static void Party_Invite(int index, int target)
        {
            int partyNum;
            int i;

            // check if the person is a valid target
            if (!S_NetworkConfig.Socket.IsConnected(target) || !S_NetworkConfig.IsPlaying(target))
                return;

            // make sure they're not busy
            if (modTypes.TempPlayer[target].PartyInvite > 0 || modTypes.TempPlayer[target].TradeRequest > 0)
            {
                // they've already got a request for trade/party
                S_NetworkSend.PlayerMsg(index, "This player is busy.", (int)Enums.ColorType.BrightRed);
                // exit out early
                return;
            }
            // make syure they're not in a party
            if (modTypes.TempPlayer[target].InParty > 0)
            {
                // they're already in a party
                S_NetworkSend.PlayerMsg(index, "This player is already in a party.", (int)Enums.ColorType.BrightRed);
                // exit out early
                return;
            }

            // check if we're in a party
            if (modTypes.TempPlayer[index].InParty > 0)
            {
                partyNum = modTypes.TempPlayer[index].InParty;
                // make sure we're the leader
                if (Party[partyNum].Leader == index)
                {
                    // got a blank slot?
                    for (i = 1; i <= Constants.MAX_PARTY_MEMBERS; i++)
                    {
                        if (Party[partyNum].Member[i] == 0)
                        {
                            // send the invitation
                            SendPartyInvite(target, index);
                            // set the invite target
                            modTypes.TempPlayer[target].PartyInvite = index;
                            // let them know
                            S_NetworkSend.PlayerMsg(index, "Invitation sent.", (int)Enums.ColorType.Yellow);
                            return;
                        }
                    }
                    // no room
                    S_NetworkSend.PlayerMsg(index, "Party is full.", (int)Enums.ColorType.BrightRed);
                    return;
                }
                else
                {
                    // not the leader
                    S_NetworkSend.PlayerMsg(index, "You are not the party leader.", (int)Enums.ColorType.BrightRed);
                    return;
                }
            }
            else
            {
                // not in a party - doesn't matter!
                SendPartyInvite(target, index);
                // set the invite target
                modTypes.TempPlayer[target].PartyInvite = index;
                // let them know
                S_NetworkSend.PlayerMsg(index, "Invitation sent.", (int)Enums.ColorType.Yellow);
                return;
            }
        }

        internal static void Party_InviteAccept(int index, int target)
        {
            int partyNum = 0;
            int i = 0;

            // check if already in a party
            if (modTypes.TempPlayer[index].InParty > 0)
            {
                // get the partynumber
                partyNum = modTypes.TempPlayer[index].InParty;
                // got a blank slot?
                for (i = 1; i <= Constants.MAX_PARTY_MEMBERS; i++)
                {
                    if (Party[partyNum].Member[i] == 0)
                    {
                        // add to the party
                        Party[partyNum].Member[i] = target;
                        // recount party
                        Party_CountMembers(partyNum);
                        // send update to all - including new player
                        SendPartyUpdate(partyNum);
                        SendPartyVitals(partyNum, target);
                        // let everyone know they've joined
                        PartyMsg(partyNum, string.Format("{0} has joined the party.", S_Players.GetPlayerName(target)));
                        // add them in
                        modTypes.TempPlayer[target].InParty = (byte)partyNum;
                        return;
                    }
                }
                // no empty slots - let them know
                S_NetworkSend.PlayerMsg(index, "Party is full.", (int)Enums.ColorType.BrightRed);
                S_NetworkSend.PlayerMsg(target, "Party is full.", (int)Enums.ColorType.BrightRed);
                return;
            }
            else
            {
                // not in a party. Create one with the new person.
                for (i = 1; i <= Constants.MAX_PARTIES; i++)
                {
                    // find blank party
                    if (!(Party[i].Leader > 0))
                    {
                        partyNum = i;
                        break;
                    }
                }
                // create the party
                Party[partyNum].MemberCount = 2;
                Party[partyNum].Leader = index;
                Party[partyNum].Member[1] = index;
                Party[partyNum].Member[2] = target;
                SendPartyUpdate(partyNum);
                SendPartyVitals(partyNum, index);
                SendPartyVitals(partyNum, target);

                // let them know it's created
                PartyMsg(partyNum, "Party created.");
                PartyMsg(partyNum, string.Format("{0} has joined the party.", S_Players.GetPlayerName(index)));

                // clear the invitation
                modTypes.TempPlayer[target].PartyInvite = 0;

                // add them to the party
                modTypes.TempPlayer[index].InParty = (byte)partyNum;
                modTypes.TempPlayer[target].InParty = (byte)partyNum;
                return;
            }
        }

        internal static void Party_InviteDecline(int index, int target)
        {
            S_NetworkSend.PlayerMsg(index, string.Format("{0} has declined to join your party.", S_Players.GetPlayerName(target)), (int)Enums.ColorType.BrightRed);
            S_NetworkSend.PlayerMsg(target, "You declined to join the party.", (int)Enums.ColorType.Yellow);
            // clear the invitation
            modTypes.TempPlayer[target].PartyInvite = 0;
        }

        internal static void Party_CountMembers(int partyNum)
        {
            int i = 0;
            int highindex = 0;
            int x = 0;

            // find the high index
            for (i = Constants.MAX_PARTY_MEMBERS; i >= 1; i += -1)
            {
                if (Party[partyNum].Member[i] > 0)
                {
                    highindex = i;
                    break;
                }
            }
            // count the members
            for (i = 1; i <= Constants.MAX_PARTY_MEMBERS; i++)
            {
                // we've got a blank member
                if (Party[partyNum].Member[i] == 0)
                {
                    // is it lower than the high index?
                    if (i < highindex)
                    {
                        // move everyone down a slot
                        for (x = i; x <= Constants.MAX_PARTY_MEMBERS - 1; x++)
                        {
                            Party[partyNum].Member[x] = Party[partyNum].Member[x + 1];
                            Party[partyNum].Member[x + 1] = 0;
                        }
                    }
                    else
                    {
                        // not lower - highindex is count
                        Party[partyNum].MemberCount = highindex;
                        return;
                    }
                }
                // check if we've reached the max
                if (i == Constants.MAX_PARTY_MEMBERS)
                {
                    if (highindex == i)
                    {
                        Party[partyNum].MemberCount = Constants.MAX_PARTY_MEMBERS;
                        return;
                    }
                }
            }
            // if we're here it means that we need to re-count again
            Party_CountMembers(partyNum);
        }

        internal static void Party_ShareExp(int partyNum, int exp, int index, int mapNum)
        {
            int expShare = 0;
            int leftOver = 0;
            int i = 0;
            int tmpindex = 0;
            byte loseMemberCount = 0;

            // check if it's worth sharing
            if (!(exp >= Party[partyNum].MemberCount))
            {
                // no party - keep exp for self
                S_Events.GivePlayerExp(index, exp);
                return;
            }

            // check members in others maps
            for (i = 1; i <= Constants.MAX_PARTY_MEMBERS; i++)
            {
                tmpindex = Party[partyNum].Member[i];
                if (tmpindex > 0)
                {
                    if (S_NetworkConfig.Socket.IsConnected(tmpindex) && S_NetworkConfig.IsPlaying(tmpindex))
                    {
                        if (S_Players.GetPlayerMap(tmpindex) != mapNum)
                            loseMemberCount = (byte)(loseMemberCount + 1);
                    }
                }
            }

            // find out the equal share
            expShare = exp / (Party[partyNum].MemberCount - loseMemberCount);
            leftOver = exp % (Party[partyNum].MemberCount - loseMemberCount);

            // loop through and give everyone exp
            for (i = 1; i <= Constants.MAX_PARTY_MEMBERS; i++)
            {
                tmpindex = Party[partyNum].Member[i];
                // existing member?
                if (tmpindex > 0)
                {
                    // playing?
                    if (S_NetworkConfig.Socket.IsConnected(tmpindex) && S_NetworkConfig.IsPlaying(tmpindex))
                    {
                        if (S_Players.GetPlayerMap(tmpindex) == mapNum)
                            // give them their share
                            S_Events.GivePlayerExp(tmpindex, expShare);
                    }
                }
            }

            // give the remainder to a random member
            if (!(leftOver == 0))
            {
                tmpindex = Party[partyNum].Member[S_GameLogic.Random(1, Party[partyNum].MemberCount)];
                // give the exp
                S_Events.GivePlayerExp(tmpindex, leftOver);
            }
        }

        public static void PartyWarp(int index, int mapNum, int x, int y)
        {
            int i;

            if (Convert.ToBoolean(modTypes.TempPlayer[index].InParty))
            {
                if (Convert.ToBoolean(Party[modTypes.TempPlayer[index].InParty].Leader))
                {
                    var loopTo = Party[modTypes.TempPlayer[index].InParty].MemberCount;
                    for (i = 1; i <= loopTo; i++)
                        S_Players.PlayerWarp(Party[modTypes.TempPlayer[index].InParty].Member[i], mapNum, x, y);
                }
            }
        }

        internal static bool IsPlayerInParty(int index)
        {
            if (index < 0 || index > Constants.MAX_PLAYERS || !modTypes.TempPlayer[index].InGame)
                return false;
            if (modTypes.TempPlayer[index].InParty > 0)
                return true;
            return false;
        }

        internal static int GetPlayerParty(int index)
        {
            if (index < 0 || index > Constants.MAX_PLAYERS || !modTypes.TempPlayer[index].InGame)
                return 0;
            return modTypes.TempPlayer[index].InParty;
        }
    }
}
