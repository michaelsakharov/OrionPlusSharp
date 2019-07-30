using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;
using System;
using ASFW;
using static Engine.S_Events;

namespace Engine
{
    internal static class S_EventLogic
    {
        internal static void RemoveDeadEvents()
        {
            int i;
            int mapNum;
            int x;
            int id;
            int page;
            int compare;
            var loopTo = S_GameLogic.GetPlayersOnline();
            for (i = 1; i <= loopTo; i++)
            {
                if (S_Globals.Gettingmap == true)
                    return;

                if (S_NetworkConfig.IsPlaying(i) == false)
                {
                    modTypes.TempPlayer[i].EventMap.CurrentEvents = 0;
                    return;
                }

                if (modTypes.TempPlayer[i].EventMap.CurrentEvents > 0)
                {
                    mapNum = S_Players.GetPlayerMap(i);
                    var loopTo1 = modTypes.TempPlayer[i].EventMap.CurrentEvents;
                    for (x = 1; x <= loopTo1; x++)
                    {
                        id = modTypes.TempPlayer[i].EventMap.EventPages[x].EventId;
                        page = modTypes.TempPlayer[i].EventMap.EventPages[x].PageId;

                        if (modTypes.Map[mapNum].Events[id].PageCount >= page)
                        {

                            // See if there is any reason to delete this event....
                            // In other words, go back through conditions and make sure they all check up.
                            if (modTypes.TempPlayer[i].EventMap.EventPages[x].Visible == 1)
                            {
                                if (modTypes.Map[mapNum].Events[id].Pages[page].ChkHasItem == 1)
                                {
                                    if (S_Players.HasItem(i, modTypes.Map[mapNum].Events[id].Pages[page].HasItemindex) == 0)
                                        modTypes.TempPlayer[i].EventMap.EventPages[x].Visible = 0;
                                }

                                if (modTypes.Map[mapNum].Events[id].Pages[page].ChkSelfSwitch == 1)
                                {
                                    if (modTypes.Map[mapNum].Events[id].Pages[page].SelfSwitchCompare == 0)
                                        compare = 1;
                                    else
                                        compare = 0;
                                    if (modTypes.Map[mapNum].Events[id].Globals == 1)
                                    {
                                        if (modTypes.Map[mapNum].Events[id].SelfSwitches[modTypes.Map[mapNum].Events[id].Pages[page].SelfSwitchindex] != compare)
                                            modTypes.TempPlayer[i].EventMap.EventPages[x].Visible = 0;
                                    }
                                    else if (modTypes.TempPlayer[i].EventMap.EventPages[id].SelfSwitches[modTypes.Map[mapNum].Events[id].Pages[page].SelfSwitchindex] != compare)
                                        modTypes.TempPlayer[i].EventMap.EventPages[x].Visible = 0;
                                }

                                if (modTypes.Map[mapNum].Events[id].Pages[page].ChkVariable == 1)
                                {
                                    switch (modTypes.Map[mapNum].Events[id].Pages[page].VariableCompare)
                                    {
                                        case 0:
                                            {
                                                if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[mapNum].Events[id].Pages[page].Variableindex] != modTypes.Map[mapNum].Events[id].Pages[page].VariableCondition)
                                                    modTypes.TempPlayer[i].EventMap.EventPages[x].Visible = 0;
                                                break;
                                            }

                                        case 1:
                                            {
                                                if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[mapNum].Events[id].Pages[page].Variableindex] < modTypes.Map[mapNum].Events[id].Pages[page].VariableCondition)
                                                    modTypes.TempPlayer[i].EventMap.EventPages[x].Visible = 0;
                                                break;
                                            }

                                        case 2:
                                            {
                                                if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[mapNum].Events[id].Pages[page].Variableindex] > modTypes.Map[mapNum].Events[id].Pages[page].VariableCondition)
                                                    modTypes.TempPlayer[i].EventMap.EventPages[x].Visible = 0;
                                                break;
                                            }

                                        case 3:
                                            {
                                                if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[mapNum].Events[id].Pages[page].Variableindex] <= modTypes.Map[mapNum].Events[id].Pages[page].VariableCondition)
                                                    modTypes.TempPlayer[i].EventMap.EventPages[x].Visible = 0;
                                                break;
                                            }

                                        case 4:
                                            {
                                                if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[mapNum].Events[id].Pages[page].Variableindex] >= modTypes.Map[mapNum].Events[id].Pages[page].VariableCondition)
                                                    modTypes.TempPlayer[i].EventMap.EventPages[x].Visible = 0;
                                                break;
                                            }

                                        case 5:
                                            {
                                                if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[mapNum].Events[id].Pages[page].Variableindex] == modTypes.Map[mapNum].Events[id].Pages[page].VariableCondition)
                                                    modTypes.TempPlayer[i].EventMap.EventPages[x].Visible = 0;
                                                break;
                                            }
                                    }
                                }

                                if (modTypes.Map[mapNum].Events[id].Pages[page].ChkSwitch == 1)
                                {
                                    if (modTypes.Map[mapNum].Events[id].Pages[page].SwitchCompare == 1)
                                    {
                                        if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Switches[modTypes.Map[mapNum].Events[id].Pages[page].Switchindex] == 0)
                                            modTypes.TempPlayer[i].EventMap.EventPages[x].Visible = 0;
                                    }
                                    else if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Switches[modTypes.Map[mapNum].Events[id].Pages[page].Switchindex] == 1)
                                        modTypes.TempPlayer[i].EventMap.EventPages[x].Visible = 0;
                                }

                                if (modTypes.Map[mapNum].Events[id].Globals == 1 && modTypes.TempPlayer[i].EventMap.EventPages[x].Visible == 0)
                                    S_Events.TempEventMap[mapNum].Events[id].Active = 0;

                                if (modTypes.TempPlayer[i].EventMap.EventPages[x].Visible == 0)
                                {
                                    ByteStream Buffer = new ByteStream(4);
                                    Buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SSpawnEvent));
                                    Buffer.WriteInt32(id);
                                    {
                                        Buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Name)));
                                        Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].Dir);
                                        Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicNum);
                                        Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicType);
                                        Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicX);
                                        Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicX2);
                                        Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicY);
                                        Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicY2);
                                        Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].MovementSpeed);
                                        Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].X);
                                        Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].Y);
                                        Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].Position);
                                        Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].Visible);
                                        Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[page].WalkAnim);
                                        Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[page].DirFix);
                                        Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[page].WalkThrough);
                                        Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[page].ShowName);
                                        Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].QuestNum);
                                    }
                                    S_NetworkConfig.Socket.SendDataTo(i, Buffer.Data, Buffer.Head);

                                    modDatabase.Addlog("Sent SMSG: SSpawnEvent Remove Dead Events", S_Constants.PACKET_LOG);
                                    S_General.AddDebug("Sent SMSG: SSpawnEvent Remove Dead Events");

                                    Buffer.Dispose();
                                }
                            }
                        }
                    }
                }
            }
        }

        internal static void SpawnNewEvents()
        {
            int pageID;
            int id;
            int compare;
            int i;
            int mapNum;
            int n;
            int x;
            int z;
            bool spawnevent;
            int p;
            var loopTo = S_GameLogic.GetPlayersOnline();

            // That was only removing events... now we gotta worry about spawning them again, luckily, it is almost the same exact thing, but backwards!

            for (i = 1; i <= loopTo; i++)
            {
                if (S_Globals.Gettingmap == true)
                    return;

                if (modTypes.TempPlayer[i].EventMap.CurrentEvents > 0)
                {
                    mapNum = S_Players.GetPlayerMap(i);
                    if (mapNum == 0)
                        return;
                    var loopTo1 = modTypes.TempPlayer[i].EventMap.CurrentEvents;
                    for (x = 1; x <= loopTo1; x++)
                    {
                        id = modTypes.TempPlayer[i].EventMap.EventPages[x].EventId;
                        pageID = modTypes.TempPlayer[i].EventMap.EventPages[x].PageId;

                        if (modTypes.TempPlayer[i].EventMap.EventPages[x].Visible == 0)
                            pageID = 0;

                        // If (Map(MapNum).Events Is Nothing) Then Continue For
                        for (z = modTypes.Map[mapNum].Events[id].PageCount; z >= 1; z += -1)
                        {
                            spawnevent = true;

                            if (modTypes.Map[mapNum].Events[id].Pages[z].ChkHasItem == 1)
                            {
                                if (S_Players.HasItem(i, modTypes.Map[mapNum].Events[id].Pages[z].HasItemindex) == 0)
                                    spawnevent = false;
                            }

                            if (modTypes.Map[mapNum].Events[id].Pages[z].ChkSelfSwitch == 1)
                            {
                                if (modTypes.Map[mapNum].Events[id].Pages[z].SelfSwitchCompare == 0)
                                    compare = 1;
                                else
                                    compare = 0;
                                if (modTypes.Map[mapNum].Events[id].Globals == 1)
                                {
                                    if (modTypes.Map[mapNum].Events[id].SelfSwitches[modTypes.Map[mapNum].Events[id].Pages[z].SelfSwitchindex] != compare)
                                        spawnevent = false;
                                }
                                else if (modTypes.TempPlayer[i].EventMap.EventPages[id].SelfSwitches[modTypes.Map[mapNum].Events[id].Pages[z].SelfSwitchindex] != compare)
                                    spawnevent = false;
                            }

                            if (modTypes.Map[mapNum].Events[id].Pages[z].ChkVariable == 1)
                            {
                                switch (modTypes.Map[mapNum].Events[id].Pages[z].VariableCompare)
                                {
                                    case 0:
                                        {
                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[mapNum].Events[id].Pages[z].Variableindex] != modTypes.Map[mapNum].Events[id].Pages[z].VariableCondition)
                                                spawnevent = false;
                                            break;
                                        }

                                    case 1:
                                        {
                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[mapNum].Events[id].Pages[z].Variableindex] < modTypes.Map[mapNum].Events[id].Pages[z].VariableCondition)
                                                spawnevent = false;
                                            break;
                                        }

                                    case 2:
                                        {
                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[mapNum].Events[id].Pages[z].Variableindex] > modTypes.Map[mapNum].Events[id].Pages[z].VariableCondition)
                                                spawnevent = false;
                                            break;
                                        }

                                    case 3:
                                        {
                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[mapNum].Events[id].Pages[z].Variableindex] <= modTypes.Map[mapNum].Events[id].Pages[z].VariableCondition)
                                                spawnevent = false;
                                            break;
                                        }

                                    case 4:
                                        {
                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[mapNum].Events[id].Pages[z].Variableindex] >= modTypes.Map[mapNum].Events[id].Pages[z].VariableCondition)
                                                spawnevent = false;
                                            break;
                                        }

                                    case 5:
                                        {
                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[mapNum].Events[id].Pages[z].Variableindex] == modTypes.Map[mapNum].Events[id].Pages[z].VariableCondition)
                                                spawnevent = false;
                                            break;
                                        }
                                }
                            }

                            if (modTypes.Map[mapNum].Events[id].Pages[z].ChkSwitch == 1)
                            {
                                if (modTypes.Map[mapNum].Events[id].Pages[z].SwitchCompare == 0)
                                {
                                    if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Switches[modTypes.Map[mapNum].Events[id].Pages[z].Switchindex] == 1)
                                        spawnevent = false;// do not spawn
                                }
                                else if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Switches[modTypes.Map[mapNum].Events[id].Pages[z].Switchindex] == 0)
                                    spawnevent = false;
                            }

                            if (spawnevent == true)
                            {
                                if (modTypes.TempPlayer[i].EventMap.EventPages[x].Visible == 1)
                                {
                                    if (z <= pageID)
                                        spawnevent = false;
                                }
                            }

                            if (spawnevent == true)
                            {
                                if (modTypes.TempPlayer[i].EventProcessingCount > 0)
                                {
                                    var loopTo2 = Information.UBound(modTypes.TempPlayer[i].EventProcessing);
                                    for (n = 1; n <= loopTo2; n++)
                                    {
                                        if (modTypes.TempPlayer[i].EventProcessing[n].EventId == id)
                                            modTypes.TempPlayer[i].EventProcessing[n].Active = 0;
                                    }
                                }

                                {
                                    if (modTypes.Map[mapNum].Events[id].Pages[z].GraphicType == 1)
                                    {
                                        switch (modTypes.Map[mapNum].Events[id].Pages[z].GraphicY)
                                        {
                                            case 0:
                                                {
                                                    modTypes.TempPlayer[i].EventMap.EventPages[id].Dir = (int)Enums.DirectionType.Down;
                                                    break;
                                                }

                                            case 1:
                                                {
                                                    modTypes.TempPlayer[i].EventMap.EventPages[id].Dir = (int)Enums.DirectionType.Left;
                                                    break;
                                                }

                                            case 2:
                                                {
                                                    modTypes.TempPlayer[i].EventMap.EventPages[id].Dir = (int)Enums.DirectionType.Right;
                                                    break;
                                                }

                                            case 3:
                                                {
                                                    modTypes.TempPlayer[i].EventMap.EventPages[id].Dir = (int)Enums.DirectionType.Up;
                                                    break;
                                                }
                                        }
                                    }
                                    else
                                        modTypes.TempPlayer[i].EventMap.EventPages[id].Dir = 0;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].GraphicNum = modTypes.Map[mapNum].Events[id].Pages[z].Graphic;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].GraphicType = modTypes.Map[mapNum].Events[id].Pages[z].GraphicType;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].GraphicX = modTypes.Map[mapNum].Events[id].Pages[z].GraphicX;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].GraphicY = modTypes.Map[mapNum].Events[id].Pages[z].GraphicY;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].GraphicX2 = modTypes.Map[mapNum].Events[id].Pages[z].GraphicX2;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].GraphicY2 = modTypes.Map[mapNum].Events[id].Pages[z].GraphicY2;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].QuestNum = modTypes.Map[mapNum].Events[id].Pages[z].QuestNum;
                                    switch (modTypes.Map[mapNum].Events[id].Pages[z].MoveSpeed)
                                    {
                                        case 0:
                                            {
                                                modTypes.TempPlayer[i].EventMap.EventPages[id].MovementSpeed = 2;
                                                break;
                                            }

                                        case 1:
                                            {
                                                modTypes.TempPlayer[i].EventMap.EventPages[id].MovementSpeed = 3;
                                                break;
                                            }

                                        case 2:
                                            {
                                                modTypes.TempPlayer[i].EventMap.EventPages[id].MovementSpeed = 4;
                                                break;
                                            }

                                        case 3:
                                            {
                                                modTypes.TempPlayer[i].EventMap.EventPages[id].MovementSpeed = 6;
                                                break;
                                            }

                                        case 4:
                                            {
                                                modTypes.TempPlayer[i].EventMap.EventPages[id].MovementSpeed = 12;
                                                break;
                                            }

                                        case 5:
                                            {
                                                modTypes.TempPlayer[i].EventMap.EventPages[id].MovementSpeed = 24;
                                                break;
                                            }
                                    }
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].Position = modTypes.Map[mapNum].Events[id].Pages[z].Position;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].EventId = id;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].PageId = z;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].Visible = 1;

                                    modTypes.TempPlayer[i].EventMap.EventPages[id].MoveType = modTypes.Map[mapNum].Events[id].Pages[z].MoveType;
                                    if (modTypes.TempPlayer[i].EventMap.EventPages[id].MoveType == 2)
                                    {
                                        modTypes.TempPlayer[i].EventMap.EventPages[id].MoveRouteCount = modTypes.Map[mapNum].Events[id].Pages[z].MoveRouteCount;
                                        if (modTypes.TempPlayer[i].EventMap.EventPages[id].MoveRouteCount > 0)
                                        {
                                            modTypes.TempPlayer[i].EventMap.EventPages[id].MoveRoute = new MoveRouteStruct[modTypes.Map[mapNum].Events[id].Pages[z].MoveRouteCount + 1];
                                            var loopTo3 = modTypes.Map[mapNum].Events[id].Pages[z].MoveRouteCount;
                                            for (p = 0; p <= loopTo3; p++)
                                                modTypes.TempPlayer[i].EventMap.EventPages[id].MoveRoute[p] = modTypes.Map[mapNum].Events[id].Pages[z].MoveRoute[p];
                                            modTypes.TempPlayer[i].EventMap.EventPages[id].MoveRouteComplete = 0;
                                        }
                                        else
                                            modTypes.TempPlayer[i].EventMap.EventPages[id].MoveRouteComplete = 1;
                                    }
                                    else
                                        modTypes.TempPlayer[i].EventMap.EventPages[id].MoveRouteComplete = 1;

                                    modTypes.TempPlayer[i].EventMap.EventPages[id].RepeatMoveRoute = modTypes.Map[mapNum].Events[id].Pages[z].RepeatMoveRoute;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].IgnoreIfCannotMove = modTypes.Map[mapNum].Events[id].Pages[z].IgnoreMoveRoute;

                                    modTypes.TempPlayer[i].EventMap.EventPages[id].MoveFreq = modTypes.Map[mapNum].Events[id].Pages[z].MoveFreq;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].MoveSpeed = modTypes.Map[mapNum].Events[id].Pages[z].MoveSpeed;

                                    modTypes.TempPlayer[i].EventMap.EventPages[id].WalkThrough = modTypes.Map[mapNum].Events[id].Pages[z].WalkThrough;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].ShowName = modTypes.Map[mapNum].Events[id].Pages[z].ShowName;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].WalkingAnim = modTypes.Map[mapNum].Events[id].Pages[z].WalkAnim;
                                    modTypes.TempPlayer[i].EventMap.EventPages[id].FixedDir = modTypes.Map[mapNum].Events[id].Pages[z].DirFix;
                                }

                                if (modTypes.Map[mapNum].Events[id].Globals == 1)
                                {
                                    if (spawnevent)
                                    {
                                        S_Events.TempEventMap[mapNum].Events[id].Active = z; S_Events.TempEventMap[mapNum].Events[id].Position = modTypes.Map[mapNum].Events[id].Pages[z].Position;
                                    }
                                }

                                var Buffer = new ByteStream(4);
                                Buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SSpawnEvent));
                                Buffer.WriteInt32(id);
                                {
                                    Buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Name)));
                                    Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].Dir);
                                    Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicNum);
                                    Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicType);
                                    Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicX);
                                    Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicX2);
                                    Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicY);
                                    Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicY2);
                                    Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].MovementSpeed);
                                    Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].X);
                                    Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].Y);
                                    Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].Position);
                                    Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].Visible);
                                    Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[z].WalkAnim);
                                    Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[z].DirFix);
                                    Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[z].WalkThrough);
                                    Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[z].ShowName);
                                    Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[z].QuestNum);
                                    Buffer.WriteInt32(modTypes.TempPlayer[i].EventMap.EventPages[x].QuestNum);
                                }
                                S_NetworkConfig.Socket.SendDataTo(i, Buffer.Data, Buffer.Head);

                                S_General.AddDebug("Sent SMSG: SSpawnEvent Spawn New Events");

                                Buffer.Dispose();
                                z = 1;
                            }
                        }
                    }
                }
            }
        }

        internal static void ProcessEventMovement()
        {
            int rand = 0;
            int x = 0;
            int i = 0;
            int playerID = 0;
            int eventID = 0;
            int WalkThrough = 0;
            bool isglobal = false;
            int mapNum = 0;
            int actualmovespeed = 0;
            ByteStream Buffer;
            int z = 0;
            bool sendupdate = false;
            bool donotprocessmoveroute = false;
            int pageNum = 0;

            // Process Movement if needed for each player/each map/each event....

            for (i = 1; i <= Constants.MAX_MAPS; i++)
            {
                if (S_Globals.Gettingmap == true)
                    return;

                if (Convert.ToBoolean(modTypes.PlayersOnMap[i]))
                {
                    // Manage Global Events First, then all the others.....
                    if (S_Events.TempEventMap[i].EventCount > 0)
                    {
                        var loopTo = S_Events.TempEventMap[i].EventCount;
                        for (x = 1; x <= loopTo; x++)
                        {
                            if (S_Events.TempEventMap[i].Events[x].Active > 0)
                            {
                                pageNum = 1;
                                if (S_Events.TempEventMap[i].Events[x].MoveTimer <= S_General.GetTimeMs())
                                {
                                    // Real event! Lets process it!
                                    switch (S_Events.TempEventMap[i].Events[x].MoveType)
                                    {
                                        case 0:
                                            {
                                                break;
                                            }

                                        case 1 // Random, move randomly if possible...
                               :
                                            {
                                                rand = S_GameLogic.Random(0, 3);
                                                if (S_Events.CanEventMove(0, i, S_Events.TempEventMap[i].Events[x].X, S_Events.TempEventMap[i].Events[x].Y, x, S_Events.TempEventMap[i].Events[x].WalkThrough, (byte)rand, true))
                                                {
                                                    switch (S_Events.TempEventMap[i].Events[x].MoveSpeed)
                                                    {
                                                        case 0:
                                                            {
                                                                S_Events.EventMove(0, i, x, rand, 2, true);
                                                                break;
                                                            }

                                                        case 1:
                                                            {
                                                                S_Events.EventMove(0, i, x, rand, 3, true);
                                                                break;
                                                            }

                                                        case 2:
                                                            {
                                                                S_Events.EventMove(0, i, x, rand, 4, true);
                                                                break;
                                                            }

                                                        case 3:
                                                            {
                                                                S_Events.EventMove(0, i, x, rand, 6, true);
                                                                break;
                                                            }

                                                        case 4:
                                                            {
                                                                S_Events.EventMove(0, i, x, rand, 12, true);
                                                                break;
                                                            }

                                                        case 5:
                                                            {
                                                                S_Events.EventMove(0, i, x, rand, 24, true);
                                                                break;
                                                            }
                                                    }
                                                }
                                                else
                                                    S_Events.EventDir(0, i, x, rand, true);
                                                break;
                                            }

                                        case 2 // Move Route
                                 :
                                            {
                                                {
                                                    isglobal = true;
                                                    mapNum = i;
                                                    playerID = 0;
                                                    eventID = x;
                                                    WalkThrough = S_Events.TempEventMap[i].Events[x].WalkThrough;
                                                    if (S_Events.TempEventMap[i].Events[x].MoveRouteCount > 0)
                                                    {
                                                        if (S_Events.TempEventMap[i].Events[x].MoveRouteStep >= S_Events.TempEventMap[i].Events[x].MoveRouteCount && S_Events.TempEventMap[i].Events[x].RepeatMoveRoute == 1)
                                                        {
                                                            S_Events.TempEventMap[i].Events[x].MoveRouteStep = 0;
                                                            S_Events.TempEventMap[i].Events[x].MoveRouteComplete = 1;
                                                        }
                                                        else if (S_Events.TempEventMap[i].Events[x].MoveRouteStep >= S_Events.TempEventMap[i].Events[x].MoveRouteCount && S_Events.TempEventMap[i].Events[x].RepeatMoveRoute == 0)
                                                        {
                                                            donotprocessmoveroute = true;
                                                            S_Events.TempEventMap[i].Events[x].MoveRouteComplete = 1;
                                                        }
                                                        else
                                                            S_Events.TempEventMap[i].Events[x].MoveRouteComplete = 0;
                                                        if (donotprocessmoveroute == false)
                                                        {
                                                            S_Events.TempEventMap[i].Events[x].MoveRouteStep = S_Events.TempEventMap[i].Events[x].MoveRouteStep + 1;
                                                            switch (S_Events.TempEventMap[i].Events[x].MoveSpeed)
                                                            {
                                                                case 0:
                                                                    {
                                                                        actualmovespeed = 2;
                                                                        break;
                                                                    }

                                                                case 1:
                                                                    {
                                                                        actualmovespeed = 3;
                                                                        break;
                                                                    }

                                                                case 2:
                                                                    {
                                                                        actualmovespeed = 4;
                                                                        break;
                                                                    }

                                                                case 3:
                                                                    {
                                                                        actualmovespeed = 6;
                                                                        break;
                                                                    }

                                                                case 4:
                                                                    {
                                                                        actualmovespeed = 12;
                                                                        break;
                                                                    }

                                                                case 5:
                                                                    {
                                                                        actualmovespeed = 24;
                                                                        break;
                                                                    }
                                                            }
                                                            switch (S_Events.TempEventMap[i].Events[x].MoveRoute[S_Events.TempEventMap[i].Events[x].MoveRouteStep].Index)
                                                            {
                                                                case 1:
                                                                    {
                                                                        if (S_Events.CanEventMove(playerID, mapNum, S_Events.TempEventMap[i].Events[x].X, S_Events.TempEventMap[i].Events[x].Y, eventID, WalkThrough, (int)Enums.DirectionType.Up, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Up, actualmovespeed, isglobal);
                                                                        else if (S_Events.TempEventMap[i].Events[x].IgnoreIfCannotMove == 0)
                                                                            S_Events.TempEventMap[i].Events[x].MoveRouteStep = S_Events.TempEventMap[i].Events[x].MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 2:
                                                                    {
                                                                        if (S_Events.CanEventMove(playerID, mapNum, S_Events.TempEventMap[i].Events[x].X, S_Events.TempEventMap[i].Events[x].Y, eventID, WalkThrough, (int)Enums.DirectionType.Down, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Down, actualmovespeed, isglobal);
                                                                        else if (S_Events.TempEventMap[i].Events[x].IgnoreIfCannotMove == 0)
                                                                            S_Events.TempEventMap[i].Events[x].MoveRouteStep = S_Events.TempEventMap[i].Events[x].MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 3:
                                                                    {
                                                                        if (S_Events.CanEventMove(playerID, mapNum, S_Events.TempEventMap[i].Events[x].X, S_Events.TempEventMap[i].Events[x].Y, eventID, WalkThrough, (int)Enums.DirectionType.Left, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Left, actualmovespeed, isglobal);
                                                                        else if (S_Events.TempEventMap[i].Events[x].IgnoreIfCannotMove == 0)
                                                                            S_Events.TempEventMap[i].Events[x].MoveRouteStep = S_Events.TempEventMap[i].Events[x].MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 4:
                                                                    {
                                                                        if (S_Events.CanEventMove(playerID, mapNum, S_Events.TempEventMap[i].Events[x].X, S_Events.TempEventMap[i].Events[x].Y, eventID, WalkThrough, (int)Enums.DirectionType.Right, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Right, actualmovespeed, isglobal);
                                                                        else if (S_Events.TempEventMap[i].Events[x].IgnoreIfCannotMove == 0)
                                                                            S_Events.TempEventMap[i].Events[x].MoveRouteStep = S_Events.TempEventMap[i].Events[x].MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 5:
                                                                    {
                                                                        z = S_GameLogic.Random(0, 3);
                                                                        if (S_Events.CanEventMove(playerID, mapNum, S_Events.TempEventMap[i].Events[x].X, S_Events.TempEventMap[i].Events[x].Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                        else if (S_Events.TempEventMap[i].Events[x].IgnoreIfCannotMove == 0)
                                                                            S_Events.TempEventMap[i].Events[x].MoveRouteStep = S_Events.TempEventMap[i].Events[x].MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 6:
                                                                    {
                                                                        if (isglobal == false)
                                                                        {
                                                                            if (S_Events.IsOneBlockAway(S_Events.TempEventMap[i].Events[x].X, S_Events.TempEventMap[i].Events[x].Y, S_Players.GetPlayerX(playerID), S_Players.GetPlayerY(playerID)) == true)
                                                                            {
                                                                                S_Events.EventDir(playerID, S_Players.GetPlayerMap(playerID), eventID, S_Events.GetDirToPlayer(playerID, S_Players.GetPlayerMap(playerID), eventID), false);
                                                                                if (S_Events.TempEventMap[i].Events[x].IgnoreIfCannotMove == 0)
                                                                                    S_Events.TempEventMap[i].Events[x].MoveRouteStep = S_Events.TempEventMap[i].Events[x].MoveRouteStep - 1;
                                                                            }
                                                                            else
                                                                            {
                                                                                z = S_Events.CanEventMoveTowardsPlayer(playerID, mapNum, eventID);
                                                                                if (z >= 4)
                                                                                {
                                                                                    // No
                                                                                    if (S_Events.TempEventMap[i].Events[x].IgnoreIfCannotMove == 0)
                                                                                        S_Events.TempEventMap[i].Events[x].MoveRouteStep = S_Events.TempEventMap[i].Events[x].MoveRouteStep - 1;
                                                                                }
                                                                                else
                                                                                    // i is the direct, lets go...
                                                                                    if (S_Events.CanEventMove(playerID, mapNum, S_Events.TempEventMap[i].Events[x].X, S_Events.TempEventMap[i].Events[x].Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                                    S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                                else if (S_Events.TempEventMap[i].Events[x].IgnoreIfCannotMove == 0)
                                                                                    S_Events.TempEventMap[i].Events[x].MoveRouteStep = S_Events.TempEventMap[i].Events[x].MoveRouteStep - 1;
                                                                            }
                                                                        }

                                                                        break;
                                                                    }

                                                                case 7:
                                                                    {
                                                                        if (isglobal == false)
                                                                        {
                                                                            z = S_Events.CanEventMoveAwayFromPlayer(playerID, mapNum, eventID);
                                                                            if (z >= 5)
                                                                            {
                                                                            }
                                                                            else
                                                                                // i is the direct, lets go...
                                                                                if (S_Events.CanEventMove(playerID, mapNum, S_Events.TempEventMap[i].Events[x].X, S_Events.TempEventMap[i].Events[x].Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                            else if (S_Events.TempEventMap[i].Events[x].IgnoreIfCannotMove == 0)
                                                                                S_Events.TempEventMap[i].Events[x].MoveRouteStep = S_Events.TempEventMap[i].Events[x].MoveRouteStep - 1;
                                                                        }

                                                                        break;
                                                                    }

                                                                case 8:
                                                                    {
                                                                        if (S_Events.CanEventMove(playerID, mapNum, S_Events.TempEventMap[i].Events[x].X, S_Events.TempEventMap[i].Events[x].Y, eventID, WalkThrough, (byte)S_Events.TempEventMap[i].Events[x].Dir, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, S_Events.TempEventMap[i].Events[x].Dir, actualmovespeed, isglobal);
                                                                        else if (S_Events.TempEventMap[i].Events[x].IgnoreIfCannotMove == 0)
                                                                            S_Events.TempEventMap[i].Events[x].MoveRouteStep = S_Events.TempEventMap[i].Events[x].MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 9:
                                                                    {
                                                                        switch (S_Events.TempEventMap[i].Events[x].Dir)
                                                                        {
                                                                            case (int)Enums.DirectionType.Up:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Down;
                                                                                    break;
                                                                                }

                                                                            case (int)Enums.DirectionType.Down:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Up;
                                                                                    break;
                                                                                }

                                                                            case (int)Enums.DirectionType.Left:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Right;
                                                                                    break;
                                                                                }

                                                                            case (int)Enums.DirectionType.Right:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Left;
                                                                                    break;
                                                                                }
                                                                        }
                                                                        if (S_Events.CanEventMove(playerID, mapNum, S_Events.TempEventMap[i].Events[x].X, S_Events.TempEventMap[i].Events[x].Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                        else if (S_Events.TempEventMap[i].Events[x].IgnoreIfCannotMove == 0)
                                                                            S_Events.TempEventMap[i].Events[x].MoveRouteStep = S_Events.TempEventMap[i].Events[x].MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 10:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveTimer = S_General.GetTimeMs() + 100;
                                                                        break;
                                                                    }

                                                                case 11:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveTimer = S_General.GetTimeMs() + 500;
                                                                        break;
                                                                    }

                                                                case 12:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveTimer = S_General.GetTimeMs() + 1000;
                                                                        break;
                                                                    }

                                                                case 13:
                                                                    {
                                                                        S_Events.EventDir(playerID, mapNum, eventID, (int)Enums.DirectionType.Up, isglobal);
                                                                        break;
                                                                    }

                                                                case 14:
                                                                    {
                                                                        S_Events.EventDir(playerID, mapNum, eventID, (int)Enums.DirectionType.Down, isglobal);
                                                                        break;
                                                                    }

                                                                case 15:
                                                                    {
                                                                        S_Events.EventDir(playerID, mapNum, eventID, (int)Enums.DirectionType.Left, isglobal);
                                                                        break;
                                                                    }

                                                                case 16:
                                                                    {
                                                                        S_Events.EventDir(playerID, mapNum, eventID, (int)Enums.DirectionType.Right, isglobal);
                                                                        break;
                                                                    }

                                                                case 17:
                                                                    {
                                                                        switch (S_Events.TempEventMap[i].Events[x].Dir)
                                                                        {
                                                                            case (int)Enums.DirectionType.Up:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Right;
                                                                                    break;
                                                                                }

                                                                            case (int)Enums.DirectionType.Right:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Down;
                                                                                    break;
                                                                                }

                                                                            case (int)Enums.DirectionType.Left:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Up;
                                                                                    break;
                                                                                }

                                                                            case (int)Enums.DirectionType.Down:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Left;
                                                                                    break;
                                                                                }
                                                                        }
                                                                        S_Events.EventDir(playerID, mapNum, eventID, z, isglobal);
                                                                        break;
                                                                    }

                                                                case 18:
                                                                    {
                                                                        switch (S_Events.TempEventMap[i].Events[x].Dir)
                                                                        {
                                                                            case (int)Enums.DirectionType.Up:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Left;
                                                                                    break;
                                                                                }

                                                                            case (int)Enums.DirectionType.Right:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Up;
                                                                                    break;
                                                                                }

                                                                            case (int)Enums.DirectionType.Left:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Down;
                                                                                    break;
                                                                                }

                                                                            case (int)Enums.DirectionType.Down:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Right;
                                                                                    break;
                                                                                }
                                                                        }
                                                                        S_Events.EventDir(playerID, mapNum, eventID, z, isglobal);
                                                                        break;
                                                                    }

                                                                case 19:
                                                                    {
                                                                        switch (S_Events.TempEventMap[i].Events[x].Dir)
                                                                        {
                                                                            case (int)Enums.DirectionType.Up:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Down;
                                                                                    break;
                                                                                }

                                                                            case (int)Enums.DirectionType.Right:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Left;
                                                                                    break;
                                                                                }

                                                                            case (int)Enums.DirectionType.Left:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Right;
                                                                                    break;
                                                                                }

                                                                            case (int)Enums.DirectionType.Down:
                                                                                {
                                                                                    z = (int)Enums.DirectionType.Up;
                                                                                    break;
                                                                                }
                                                                        }
                                                                        S_Events.EventDir(playerID, mapNum, eventID, z, isglobal);
                                                                        break;
                                                                    }

                                                                case 20:
                                                                    {
                                                                        z = S_GameLogic.Random(0, 3);
                                                                        S_Events.EventDir(playerID, mapNum, eventID, z, isglobal);
                                                                        break;
                                                                    }

                                                                case 21:
                                                                    {
                                                                        if (isglobal == false)
                                                                        {
                                                                            z = S_Events.GetDirToPlayer(playerID, mapNum, eventID);
                                                                            S_Events.EventDir(playerID, mapNum, eventID, z, isglobal);
                                                                        }

                                                                        break;
                                                                    }

                                                                case 22:
                                                                    {
                                                                        if (isglobal == false)
                                                                        {
                                                                            z = S_Events.GetDirAwayFromPlayer(playerID, mapNum, eventID);
                                                                            S_Events.EventDir(playerID, mapNum, eventID, z, isglobal);
                                                                        }

                                                                        break;
                                                                    }

                                                                case 23:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveSpeed = 0;
                                                                        break;
                                                                    }

                                                                case 24:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveSpeed = 1;
                                                                        break;
                                                                    }

                                                                case 25:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveSpeed = 2;
                                                                        break;
                                                                    }

                                                                case 26:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveSpeed = 3;
                                                                        break;
                                                                    }

                                                                case 27:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveSpeed = 4;
                                                                        break;
                                                                    }

                                                                case 28:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveSpeed = 5;
                                                                        break;
                                                                    }

                                                                case 29:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveFreq = 0;
                                                                        break;
                                                                    }

                                                                case 30:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveFreq = 1;
                                                                        break;
                                                                    }

                                                                case 31:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveFreq = 2;
                                                                        break;
                                                                    }

                                                                case 32:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveFreq = 3;
                                                                        break;
                                                                    }

                                                                case 33:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].MoveFreq = 4;
                                                                        break;
                                                                    }

                                                                case 34:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].WalkingAnim = 1;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 35:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].WalkingAnim = 0;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 36:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].FixedDir = 1;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 37:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].FixedDir = 0;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 38:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].WalkThrough = 1;
                                                                        break;
                                                                    }

                                                                case 39:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].WalkThrough = 0;
                                                                        break;
                                                                    }

                                                                case 40:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].Position = 0;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 41:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].Position = 1;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 42:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].Position = 2;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 43:
                                                                    {
                                                                        S_Events.TempEventMap[i].Events[x].GraphicType = S_Events.TempEventMap[i].Events[x].MoveRoute[S_Events.TempEventMap[i].Events[x].MoveRouteStep].Data1;
                                                                        S_Events.TempEventMap[i].Events[x].GraphicNum = S_Events.TempEventMap[i].Events[x].MoveRoute[S_Events.TempEventMap[i].Events[x].MoveRouteStep].Data2;
                                                                        S_Events.TempEventMap[i].Events[x].GraphicX = S_Events.TempEventMap[i].Events[x].MoveRoute[S_Events.TempEventMap[i].Events[x].MoveRouteStep].Data3;
                                                                        S_Events.TempEventMap[i].Events[x].GraphicX2 = S_Events.TempEventMap[i].Events[x].MoveRoute[S_Events.TempEventMap[i].Events[x].MoveRouteStep].Data4;
                                                                        S_Events.TempEventMap[i].Events[x].GraphicY = S_Events.TempEventMap[i].Events[x].MoveRoute[S_Events.TempEventMap[i].Events[x].MoveRouteStep].Data5;
                                                                        S_Events.TempEventMap[i].Events[x].GraphicY2 = S_Events.TempEventMap[i].Events[x].MoveRoute[S_Events.TempEventMap[i].Events[x].MoveRouteStep].Data6;
                                                                        if (S_Events.TempEventMap[i].Events[x].GraphicType == 1)
                                                                        {
                                                                            switch (S_Events.TempEventMap[i].Events[x].GraphicY)
                                                                            {
                                                                                case 0:
                                                                                    {
                                                                                        S_Events.TempEventMap[i].Events[x].Dir = (int)Enums.DirectionType.Down;
                                                                                        break;
                                                                                    }

                                                                                case 1:
                                                                                    {
                                                                                        S_Events.TempEventMap[i].Events[x].Dir = (int)Enums.DirectionType.Left;
                                                                                        break;
                                                                                    }

                                                                                case 2:
                                                                                    {
                                                                                        S_Events.TempEventMap[i].Events[x].Dir = (int)Enums.DirectionType.Right;
                                                                                        break;
                                                                                    }

                                                                                case 3:
                                                                                    {
                                                                                        S_Events.TempEventMap[i].Events[x].Dir = (int)Enums.DirectionType.Up;
                                                                                        break;
                                                                                    }
                                                                            }
                                                                        }
                                                                        // Need to Send Update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }
                                                            }

                                                            if (sendupdate)
                                                            {
                                                                Buffer = new ByteStream(4);
                                                                Buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SSpawnEvent));
                                                                Buffer.WriteInt32(eventID);
                                                                {
                                                                    Buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[i].Events[x].Name)));
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].Dir);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].GraphicNum);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].GraphicType);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].GraphicX);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].GraphicX2);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].GraphicY);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].GraphicY2);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].MoveSpeed);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].X);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].Y);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].Position);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].Active);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].WalkingAnim);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].FixedDir);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].WalkThrough);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].ShowName);
                                                                    Buffer.WriteInt32(S_Events.TempEventMap[i].Events[x].QuestNum);
                                                                }
                                                                S_NetworkConfig.SendDataToMap(i, ref Buffer.Data, Buffer.Head);

                                                                modDatabase.Addlog("Sent SMSG: SSpawnEvent Process Event Movement", S_Constants.PACKET_LOG);
                                                                S_General.AddDebug("Sent SMSG: SSpawnEvent Process Event Movement");

                                                                Buffer.Dispose();
                                                            }
                                                        }
                                                        donotprocessmoveroute = false;
                                                    }
                                                }

                                                break;
                                            }
                                    }

                                    switch (S_Events.TempEventMap[i].Events[x].MoveFreq)
                                    {
                                        case 0:
                                            {
                                                S_Events.TempEventMap[i].Events[x].MoveTimer = S_General.GetTimeMs() + 4000;
                                                break;
                                            }

                                        case 1:
                                            {
                                                S_Events.TempEventMap[i].Events[x].MoveTimer = S_General.GetTimeMs() + 2000;
                                                break;
                                            }

                                        case 2:
                                            {
                                                S_Events.TempEventMap[i].Events[x].MoveTimer = S_General.GetTimeMs() + 1000;
                                                break;
                                            }

                                        case 3:
                                            {
                                                S_Events.TempEventMap[i].Events[x].MoveTimer = S_General.GetTimeMs() + 500;
                                                break;
                                            }

                                        case 4:
                                            {
                                                S_Events.TempEventMap[i].Events[x].MoveTimer = S_General.GetTimeMs() + 250;
                                                break;
                                            }
                                    }
                                }
                            }
                        }
                    }
                }
                //Application.DoEvents();
            }
        }

        internal static void ProcessLocalEventMovement()
        {
            int rand = 0;
            int x = 0;
            int i = 0;
            int playerID = 0;
            int eventID = 0;
            int WalkThrough = 0;
            bool isglobal = false;
            int mapNum = 0;
            int actualmovespeed = 0;
            ByteStream Buffer;
            int z = 0;
            bool sendupdate = false;
            bool donotprocessmoveroute = false;
            var loopTo = S_GameLogic.GetPlayersOnline();
            for (i = 1; i <= loopTo; i++)
            {
                if (S_Globals.Gettingmap == true)
                    return;

                if (S_NetworkConfig.IsPlaying(i))
                {
                    playerID = i;
                    if (modTypes.TempPlayer[i].EventMap.CurrentEvents > 0)
                    {
                        var loopTo1 = modTypes.TempPlayer[i].EventMap.CurrentEvents;
                        for (x = 1; x <= loopTo1; x++)
                        {
                            if (S_Globals.Gettingmap == true)
                                return;

                            if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Globals == 0)
                            {
                                if (modTypes.TempPlayer[i].EventMap.EventPages[x].Visible == 1)
                                {
                                    if (modTypes.TempPlayer[i].EventMap.EventPages[x].MoveTimer <= S_General.GetTimeMs())
                                    {
                                        // Real event! Lets process it!
                                        switch (modTypes.TempPlayer[i].EventMap.EventPages[x].MoveType)
                                        {
                                            case 0:
                                                {
                                                    break;
                                                }

                                            case 1 // Random, move randomly if possible...
                                   :
                                                {
                                                    rand = S_GameLogic.Random(0, 3);
                                                    playerID = i;
                                                    if (S_Events.CanEventMove(i, S_Players.GetPlayerMap(i), modTypes.TempPlayer[i].EventMap.EventPages[x].X, modTypes.TempPlayer[i].EventMap.EventPages[x].Y, x, modTypes.TempPlayer[i].EventMap.EventPages[x].WalkThrough, (byte)rand, false))
                                                    {
                                                        switch (modTypes.TempPlayer[i].EventMap.EventPages[x].MoveSpeed)
                                                        {
                                                            case 0:
                                                                {
                                                                    S_Events.EventMove(i, S_Players.GetPlayerMap(i), x, rand, 2, false);
                                                                    break;
                                                                }

                                                            case 1:
                                                                {
                                                                    S_Events.EventMove(i, S_Players.GetPlayerMap(i), x, rand, 3, false);
                                                                    break;
                                                                }

                                                            case 2:
                                                                {
                                                                    S_Events.EventMove(i, S_Players.GetPlayerMap(i), x, rand, 4, false);
                                                                    break;
                                                                }

                                                            case 3:
                                                                {
                                                                    S_Events.EventMove(i, S_Players.GetPlayerMap(i), x, rand, 6, false);
                                                                    break;
                                                                }

                                                            case 4:
                                                                {
                                                                    S_Events.EventMove(i, S_Players.GetPlayerMap(i), x, rand, 12, false);
                                                                    break;
                                                                }

                                                            case 5:
                                                                {
                                                                    S_Events.EventMove(i, S_Players.GetPlayerMap(i), x, rand, 24, false);
                                                                    break;
                                                                }
                                                        }
                                                    }
                                                    else
                                                        S_Events.EventDir(0, S_Players.GetPlayerMap(i), x, rand, true);
                                                    break;
                                                }

                                            case 2 // Move Route
                                     :
                                                {
                                                    {
                                                        //var modTypes.TempPlayer[i].EventMap.EventPages[x] = modTypes.TempPlayer[i].EventMap.EventPages[x];
                                                        isglobal = false;
                                                        sendupdate = false;
                                                        mapNum = S_Players.GetPlayerMap(i);
                                                        playerID = i;
                                                        eventID = x;
                                                        WalkThrough = modTypes.TempPlayer[i].EventMap.EventPages[x].WalkThrough;
                                                        if (modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteCount > 0)
                                                        {
                                                            if (modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep >= modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteCount && modTypes.TempPlayer[i].EventMap.EventPages[x].RepeatMoveRoute == 1)
                                                            {
                                                                modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep = 0;
                                                                modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteComplete = 1;
                                                            }
                                                            else if (modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep >= modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteCount && modTypes.TempPlayer[i].EventMap.EventPages[x].RepeatMoveRoute == 0)
                                                            {
                                                                donotprocessmoveroute = true;
                                                                modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteComplete = 1;
                                                            }
                                                            else
                                                                modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteComplete = 0;
                                                            if (donotprocessmoveroute == false)
                                                            {
                                                                switch (modTypes.TempPlayer[i].EventMap.EventPages[x].MoveSpeed)
                                                                {
                                                                    case 0:
                                                                        {
                                                                            actualmovespeed = 2;
                                                                            break;
                                                                        }

                                                                    case 1:
                                                                        {
                                                                            actualmovespeed = 3;
                                                                            break;
                                                                        }

                                                                    case 2:
                                                                        {
                                                                            actualmovespeed = 4;
                                                                            break;
                                                                        }

                                                                    case 3:
                                                                        {
                                                                            actualmovespeed = 6;
                                                                            break;
                                                                        }

                                                                    case 4:
                                                                        {
                                                                            actualmovespeed = 12;
                                                                            break;
                                                                        }

                                                                    case 5:
                                                                        {
                                                                            actualmovespeed = 24;
                                                                            break;
                                                                        }
                                                                }
                                                                modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep + 1;
                                                                switch (modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRoute[modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep].Index)
                                                                {
                                                                    case 1:
                                                                        {
                                                                            if (S_Events.CanEventMove(playerID, mapNum, modTypes.TempPlayer[i].EventMap.EventPages[x].X, modTypes.TempPlayer[i].EventMap.EventPages[x].Y, eventID, WalkThrough, (int)Enums.DirectionType.Up, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Up, actualmovespeed, isglobal);
                                                                            else if (modTypes.TempPlayer[i].EventMap.EventPages[x].IgnoreIfCannotMove == 0)
                                                                                modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 2:
                                                                        {
                                                                            if (S_Events.CanEventMove(playerID, mapNum, modTypes.TempPlayer[i].EventMap.EventPages[x].X, modTypes.TempPlayer[i].EventMap.EventPages[x].Y, eventID, WalkThrough, (int)Enums.DirectionType.Down, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Down, actualmovespeed, isglobal);
                                                                            else if (modTypes.TempPlayer[i].EventMap.EventPages[x].IgnoreIfCannotMove == 0)
                                                                                modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 3:
                                                                        {
                                                                            if (S_Events.CanEventMove(playerID, mapNum, modTypes.TempPlayer[i].EventMap.EventPages[x].X, modTypes.TempPlayer[i].EventMap.EventPages[x].Y, eventID, WalkThrough, (int)Enums.DirectionType.Left, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Left, actualmovespeed, isglobal);
                                                                            else if (modTypes.TempPlayer[i].EventMap.EventPages[x].IgnoreIfCannotMove == 0)
                                                                                modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 4:
                                                                        {
                                                                            if (S_Events.CanEventMove(playerID, mapNum, modTypes.TempPlayer[i].EventMap.EventPages[x].X, modTypes.TempPlayer[i].EventMap.EventPages[x].Y, eventID, WalkThrough, (int)Enums.DirectionType.Right, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Right, actualmovespeed, isglobal);
                                                                            else if (modTypes.TempPlayer[i].EventMap.EventPages[x].IgnoreIfCannotMove == 0)
                                                                                modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 5:
                                                                        {
                                                                            z = S_GameLogic.Random(0, 3);
                                                                            if (S_Events.CanEventMove(playerID, mapNum, modTypes.TempPlayer[i].EventMap.EventPages[x].X, modTypes.TempPlayer[i].EventMap.EventPages[x].Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                            else if (modTypes.TempPlayer[i].EventMap.EventPages[x].IgnoreIfCannotMove == 0)
                                                                                modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 6:
                                                                        {
                                                                            if (isglobal == false)
                                                                            {
                                                                                if (S_Events.IsOneBlockAway(modTypes.TempPlayer[i].EventMap.EventPages[x].X, modTypes.TempPlayer[i].EventMap.EventPages[x].Y, S_Players.GetPlayerX(playerID), S_Players.GetPlayerY(playerID)) == true)
                                                                                {
                                                                                    S_Events.EventDir(playerID, S_Players.GetPlayerMap(playerID), eventID, S_Events.GetDirToPlayer(playerID, S_Players.GetPlayerMap(playerID), eventID), false);
                                                                                    // Lets do cool stuff!
                                                                                    if (modTypes.Map[S_Players.GetPlayerMap(playerID)].Events[eventID].Pages[modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].PageId].Trigger == 1)
                                                                                    {
                                                                                        if (modTypes.Map[mapNum].Events[eventID].Pages[modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].PageId].CommandListCount > 0)
                                                                                        {
                                                                                            modTypes.TempPlayer[playerID].EventProcessing[eventID].Active = 1;
                                                                                            modTypes.TempPlayer[playerID].EventProcessing[eventID].ActionTimer = S_General.GetTimeMs();
                                                                                            modTypes.TempPlayer[playerID].EventProcessing[eventID].CurList = 1;
                                                                                            modTypes.TempPlayer[playerID].EventProcessing[eventID].CurSlot = 1;
                                                                                            modTypes.TempPlayer[playerID].EventProcessing[eventID].EventId = eventID;
                                                                                            modTypes.TempPlayer[playerID].EventProcessing[eventID].PageId = modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].PageId;
                                                                                            modTypes.TempPlayer[playerID].EventProcessing[eventID].WaitingForResponse = 0;
                                                                                            modTypes.TempPlayer[playerID].EventProcessing[eventID].ListLeftOff = new int[modTypes.Map[S_Players.GetPlayerMap(playerID)].Events[modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].EventId].Pages[modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].PageId].CommandListCount + 1];
                                                                                        }
                                                                                    }
                                                                                    if (modTypes.TempPlayer[i].EventMap.EventPages[x].IgnoreIfCannotMove == 0)
                                                                                        modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep - 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    z = S_Events.CanEventMoveTowardsPlayer(playerID, mapNum, eventID);
                                                                                    if (z >= 4)
                                                                                    {
                                                                                        // No
                                                                                        if (modTypes.TempPlayer[i].EventMap.EventPages[x].IgnoreIfCannotMove == 0)
                                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep - 1;
                                                                                    }
                                                                                    else
                                                                                        // i is the direct, lets go...
                                                                                        if (S_Events.CanEventMove(playerID, mapNum, modTypes.TempPlayer[i].EventMap.EventPages[x].X, modTypes.TempPlayer[i].EventMap.EventPages[x].Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                                        S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                                    else if (modTypes.TempPlayer[i].EventMap.EventPages[x].IgnoreIfCannotMove == 0)
                                                                                        modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep - 1;
                                                                                }
                                                                            }

                                                                            break;
                                                                        }

                                                                    case 7:
                                                                        {
                                                                            if (isglobal == false)
                                                                            {
                                                                                z = S_Events.CanEventMoveAwayFromPlayer(playerID, mapNum, eventID);
                                                                                if (z >= 5)
                                                                                {
                                                                                }
                                                                                else
                                                                                    // i is the direct, lets go...
                                                                                    if (S_Events.CanEventMove(playerID, mapNum, modTypes.TempPlayer[i].EventMap.EventPages[x].X, modTypes.TempPlayer[i].EventMap.EventPages[x].Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                                    S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                                else if (modTypes.TempPlayer[i].EventMap.EventPages[x].IgnoreIfCannotMove == 0)
                                                                                    modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep - 1;
                                                                            }

                                                                            break;
                                                                        }

                                                                    case 8:
                                                                        {
                                                                            if (S_Events.CanEventMove(playerID, mapNum, modTypes.TempPlayer[i].EventMap.EventPages[x].X, modTypes.TempPlayer[i].EventMap.EventPages[x].Y, eventID, WalkThrough, (byte)modTypes.TempPlayer[i].EventMap.EventPages[x].Dir, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, modTypes.TempPlayer[i].EventMap.EventPages[x].Dir, actualmovespeed, isglobal);
                                                                            else if (modTypes.TempPlayer[i].EventMap.EventPages[x].IgnoreIfCannotMove == 0)
                                                                                modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 9:
                                                                        {
                                                                            switch (modTypes.TempPlayer[i].EventMap.EventPages[x].Dir)
                                                                            {
                                                                                case (int)Enums.DirectionType.Up:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Down;
                                                                                        break;
                                                                                    }

                                                                                case (int)Enums.DirectionType.Down:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Up;
                                                                                        break;
                                                                                    }

                                                                                case (int)Enums.DirectionType.Left:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Right;
                                                                                        break;
                                                                                    }

                                                                                case (int)Enums.DirectionType.Right:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Left;
                                                                                        break;
                                                                                    }
                                                                            }
                                                                            if (S_Events.CanEventMove(playerID, mapNum, modTypes.TempPlayer[i].EventMap.EventPages[x].X, modTypes.TempPlayer[i].EventMap.EventPages[x].Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                            else if (modTypes.TempPlayer[i].EventMap.EventPages[x].IgnoreIfCannotMove == 0)
                                                                                modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 10:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveTimer = S_General.GetTimeMs() + 100;
                                                                            break;
                                                                        }

                                                                    case 11:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveTimer = S_General.GetTimeMs() + 500;
                                                                            break;
                                                                        }

                                                                    case 12:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveTimer = S_General.GetTimeMs() + 1000;
                                                                            break;
                                                                        }

                                                                    case 13:
                                                                        {
                                                                            S_Events.EventDir(playerID, mapNum, eventID, (int)Enums.DirectionType.Up, isglobal);
                                                                            break;
                                                                        }

                                                                    case 14:
                                                                        {
                                                                            S_Events.EventDir(playerID, mapNum, eventID, (int)Enums.DirectionType.Down, isglobal);
                                                                            break;
                                                                        }

                                                                    case 15:
                                                                        {
                                                                            S_Events.EventDir(playerID, mapNum, eventID, (int)Enums.DirectionType.Left, isglobal);
                                                                            break;
                                                                        }

                                                                    case 16:
                                                                        {
                                                                            S_Events.EventDir(playerID, mapNum, eventID, (int)Enums.DirectionType.Right, isglobal);
                                                                            break;
                                                                        }

                                                                    case 17:
                                                                        {
                                                                            switch (modTypes.TempPlayer[i].EventMap.EventPages[x].Dir)
                                                                            {
                                                                                case (int)Enums.DirectionType.Up:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Right;
                                                                                        break;
                                                                                    }

                                                                                case (int)Enums.DirectionType.Right:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Down;
                                                                                        break;
                                                                                    }

                                                                                case (int)Enums.DirectionType.Left:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Up;
                                                                                        break;
                                                                                    }

                                                                                case (int)Enums.DirectionType.Down:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Left;
                                                                                        break;
                                                                                    }
                                                                            }
                                                                            S_Events.EventDir(playerID, mapNum, eventID, z, isglobal);
                                                                            break;
                                                                        }

                                                                    case 18:
                                                                        {
                                                                            switch (modTypes.TempPlayer[i].EventMap.EventPages[x].Dir)
                                                                            {
                                                                                case (int)Enums.DirectionType.Up:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Left;
                                                                                        break;
                                                                                    }

                                                                                case (int)Enums.DirectionType.Right:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Up;
                                                                                        break;
                                                                                    }

                                                                                case (int)Enums.DirectionType.Left:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Down;
                                                                                        break;
                                                                                    }

                                                                                case (int)Enums.DirectionType.Down:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Right;
                                                                                        break;
                                                                                    }
                                                                            }
                                                                            S_Events.EventDir(playerID, mapNum, eventID, z, isglobal);
                                                                            break;
                                                                        }

                                                                    case 19:
                                                                        {
                                                                            switch (modTypes.TempPlayer[i].EventMap.EventPages[x].Dir)
                                                                            {
                                                                                case (int)Enums.DirectionType.Up:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Down;
                                                                                        break;
                                                                                    }

                                                                                case (int)Enums.DirectionType.Right:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Left;
                                                                                        break;
                                                                                    }

                                                                                case (int)Enums.DirectionType.Left:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Right;
                                                                                        break;
                                                                                    }

                                                                                case (int)Enums.DirectionType.Down:
                                                                                    {
                                                                                        z = (int)Enums.DirectionType.Up;
                                                                                        break;
                                                                                    }
                                                                            }
                                                                            S_Events.EventDir(playerID, mapNum, eventID, z, isglobal);
                                                                            break;
                                                                        }

                                                                    case 20:
                                                                        {
                                                                            z = S_GameLogic.Random(0, 3);
                                                                            S_Events.EventDir(playerID, mapNum, eventID, z, isglobal);
                                                                            break;
                                                                        }

                                                                    case 21:
                                                                        {
                                                                            if (isglobal == false)
                                                                            {
                                                                                z = S_Events.GetDirToPlayer(playerID, mapNum, eventID);
                                                                                S_Events.EventDir(playerID, mapNum, eventID, z, isglobal);
                                                                            }

                                                                            break;
                                                                        }

                                                                    case 22:
                                                                        {
                                                                            if (isglobal == false)
                                                                            {
                                                                                z = S_Events.GetDirAwayFromPlayer(playerID, mapNum, eventID);
                                                                                S_Events.EventDir(playerID, mapNum, eventID, z, isglobal);
                                                                            }

                                                                            break;
                                                                        }

                                                                    case 23:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveSpeed = 0;
                                                                            break;
                                                                        }

                                                                    case 24:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveSpeed = 1;
                                                                            break;
                                                                        }

                                                                    case 25:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveSpeed = 2;
                                                                            break;
                                                                        }

                                                                    case 26:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveSpeed = 3;
                                                                            break;
                                                                        }

                                                                    case 27:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveSpeed = 4;
                                                                            break;
                                                                        }

                                                                    case 28:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveSpeed = 5;
                                                                            break;
                                                                        }

                                                                    case 29:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveFreq = 0;
                                                                            break;
                                                                        }

                                                                    case 30:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveFreq = 1;
                                                                            break;
                                                                        }

                                                                    case 31:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveFreq = 2;
                                                                            break;
                                                                        }

                                                                    case 32:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveFreq = 3;
                                                                            break;
                                                                        }

                                                                    case 33:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].MoveFreq = 4;
                                                                            break;
                                                                        }

                                                                    case 34:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].WalkingAnim = 1;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 35:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].WalkingAnim = 0;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 36:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].FixedDir = 1;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 37:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].FixedDir = 0;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 38:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].WalkThrough = 1;
                                                                            break;
                                                                        }

                                                                    case 39:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].WalkThrough = 0;
                                                                            break;
                                                                        }

                                                                    case 40:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].Position = 0;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 41:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].Position = 1;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 42:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].Position = 2;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 43:
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicType = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRoute[modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep].Data1;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicNum = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRoute[modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep].Data2;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicX = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRoute[modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep].Data3;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicX2 = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRoute[modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep].Data4;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicY = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRoute[modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep].Data5;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicY2 = modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRoute[modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep].Data6;
                                                                            if (modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicType == 1)
                                                                            {
                                                                                switch (modTypes.TempPlayer[i].EventMap.EventPages[x].GraphicY)
                                                                                {
                                                                                    case 0:
                                                                                        {
                                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].Dir = (int)Enums.DirectionType.Down;
                                                                                            break;
                                                                                        }

                                                                                    case 1:
                                                                                        {
                                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].Dir = (int)Enums.DirectionType.Left;
                                                                                            break;
                                                                                        }

                                                                                    case 2:
                                                                                        {
                                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].Dir = (int)Enums.DirectionType.Right;
                                                                                            break;
                                                                                        }

                                                                                    case 3:
                                                                                        {
                                                                                            modTypes.TempPlayer[i].EventMap.EventPages[x].Dir = (int)Enums.DirectionType.Up;
                                                                                            break;
                                                                                        }
                                                                                }
                                                                            }
                                                                            // Need to Send Update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }
                                                                }

                                                                if (sendupdate)
                                                                {
                                                                    Buffer = new ByteStream(4);
                                                                    Buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SSpawnEvent));
                                                                    Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].EventId);
                                                                    {
                                                                        Buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(playerID)].Events[modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].EventId].Name)));
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].Dir);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].GraphicNum);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].GraphicType);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].GraphicX);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].GraphicX2);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].GraphicY);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].GraphicY2);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].MoveSpeed);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].X);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].Y);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].Position);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].Visible);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].WalkingAnim);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].FixedDir);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].WalkThrough);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].ShowName);
                                                                        Buffer.WriteInt32(modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].QuestNum);
                                                                    }
                                                                    S_NetworkConfig.Socket.SendDataTo(playerID, Buffer.Data, Buffer.Head);
                                                                    Buffer.Dispose();
                                                                }
                                                            }
                                                            donotprocessmoveroute = false;
                                                        }
                                                    }

                                                    break;
                                                }
                                        }
                                        switch (modTypes.TempPlayer[playerID].EventMap.EventPages[x].MoveFreq)
                                        {
                                            case 0:
                                                {
                                                    modTypes.TempPlayer[playerID].EventMap.EventPages[x].MoveTimer = S_General.GetTimeMs() + 4000;
                                                    break;
                                                }

                                            case 1:
                                                {
                                                    modTypes.TempPlayer[playerID].EventMap.EventPages[x].MoveTimer = S_General.GetTimeMs() + 2000;
                                                    break;
                                                }

                                            case 2:
                                                {
                                                    modTypes.TempPlayer[playerID].EventMap.EventPages[x].MoveTimer = S_General.GetTimeMs() + 1000;
                                                    break;
                                                }

                                            case 3:
                                                {
                                                    modTypes.TempPlayer[playerID].EventMap.EventPages[x].MoveTimer = S_General.GetTimeMs() + 500;
                                                    break;
                                                }

                                            case 4:
                                                {
                                                    modTypes.TempPlayer[playerID].EventMap.EventPages[x].MoveTimer = S_General.GetTimeMs() + 250;
                                                    break;
                                                }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //Application.DoEvents();
            }
        }

        internal static void ProcessEventCommands()
        {
            ByteStream buffer = new ByteStream(4);
            int i = 0;
            int x = 0;
            bool removeEventProcess = false;
            int w = 0;
            int v = 0;
            int p = 0;
            bool restartlist = false;
            bool restartloop = false;
            bool endprocess = false;
            var loopTo = S_GameLogic.GetPlayersOnline();

            // Now, we process the damn things for commands :P

            for (i = 1; i <= loopTo; i++)
            {
                if (S_Globals.Gettingmap == true)
                    return;

                if (S_NetworkConfig.IsPlaying(i) && modTypes.TempPlayer[i].GettingMap == 0)
                {
                    var loopTo1 = modTypes.TempPlayer[i].EventMap.CurrentEvents;
                    for (x = 1; x <= loopTo1; x++)
                    {
                        if (Convert.ToBoolean(modTypes.TempPlayer[i].EventMap.EventPages[x].Visible))
                        {
                            if (modTypes.Map[modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Map].Events[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Pages[modTypes.TempPlayer[i].EventMap.EventPages[x].PageId].Trigger == 2)
                            {
                                if (modTypes.TempPlayer[i].EventProcessingCount > 0)
                                {
                                    if (modTypes.TempPlayer[i].EventProcessing[x].Active == 0)
                                    {
                                        if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Pages[modTypes.TempPlayer[i].EventMap.EventPages[x].PageId].CommandListCount > 0)
                                        {
                                            // start new event processing
                                            modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Active = 1;
                                            {
                                                modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].ActionTimer = S_General.GetTimeMs();
                                                modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].CurList = 1;
                                                modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].CurSlot = 1;
                                                modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].EventId = modTypes.TempPlayer[i].EventMap.EventPages[x].EventId;
                                                modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].PageId = modTypes.TempPlayer[i].EventMap.EventPages[x].PageId;
                                                modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].WaitingForResponse = 0;
                                                modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].ListLeftOff = new int[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Pages[modTypes.TempPlayer[i].EventMap.EventPages[x].PageId].CommandListCount + 1];
                                            }
                                        }
                                    }
                                }
                                else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Pages[modTypes.TempPlayer[i].EventMap.EventPages[x].PageId].CommandListCount > 0)
                                {
                                    // Clearly need to start it!
                                    modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Active = 1;
                                    {
                                        modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].ActionTimer = S_General.GetTimeMs();
                                        modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].CurList = 1;
                                        modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].CurSlot = 1;
                                        modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].EventId = modTypes.TempPlayer[i].EventMap.EventPages[x].EventId;
                                        modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].PageId = modTypes.TempPlayer[i].EventMap.EventPages[x].PageId;
                                        modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].WaitingForResponse = 0;
                                        modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].ListLeftOff = new int[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Pages[modTypes.TempPlayer[i].EventMap.EventPages[x].PageId].CommandListCount + 1];
                                    }
                                }
                            }
                        }
                    }
                }
            }

            var loopTo2 = S_GameLogic.GetPlayersOnline();

            // That is it for starting parallel processes :D now we just have to make the code that actually processes the events to their fullest
            for (i = 1; i <= loopTo2; i++)
            {
                if (S_Globals.Gettingmap == true)
                    return;

                if (S_NetworkConfig.IsPlaying(i) && modTypes.TempPlayer[i].GettingMap == 0)
                {
                    if (modTypes.TempPlayer[i].EventProcessingCount > 0)
                    {
                        restartloop = true;
                        while (restartloop == true)
                        {
                            restartloop = false;
                            var loopTo3 = modTypes.TempPlayer[i].EventProcessingCount;
                            for (x = 1; x <= loopTo3; x++)
                            {
                                if (modTypes.TempPlayer[i].EventProcessing[x].Active == 1)
                                {
                                    if (x > modTypes.TempPlayer[i].EventProcessingCount)
                                        break;
                                    {
                                        if (modTypes.TempPlayer[i].EventProcessingCount == 0)
                                            return;
                                        removeEventProcess = false;
                                        if (modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse == 2)
                                        {
                                            if (modTypes.TempPlayer[i].InShop == 0)
                                                modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse = 0;
                                        }
                                        if (modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse == 3)
                                        {
                                            if (modTypes.TempPlayer[i].InBank == false)
                                                modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse = 0;
                                        }
                                        if (modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse == 4)
                                        {
                                            // waiting for eventmovement to complete
                                            if (modTypes.TempPlayer[i].EventProcessing[x].EventMovingType == 0)
                                            {
                                                if (modTypes.TempPlayer[i].EventMap.EventPages[modTypes.TempPlayer[i].EventProcessing[x].EventMovingId].MoveRouteComplete == 1)
                                                    modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse = 0;
                                            }
                                            else if (S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventMovingId].MoveRouteComplete == 1)
                                                modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse = 0;
                                        }
                                        if (modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse == 0)
                                        {
                                            if (modTypes.TempPlayer[i].EventProcessing[x].ActionTimer <= S_General.GetTimeMs())
                                            {
                                                restartlist = true;
                                                endprocess = false;
                                                while (restartlist == true && endprocess == false && modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse == 0)
                                                {
                                                    restartlist = false;
                                                    if (modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] > 0)
                                                    {
                                                        modTypes.TempPlayer[i].EventProcessing[x].CurSlot = modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] + 1;
                                                        modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = 0;
                                                    }
                                                    if (modTypes.TempPlayer[i].EventProcessing[x].CurList > modTypes.Map[modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Map].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandListCount)
                                                    {
                                                        // Get rid of this event, it is bad
                                                        removeEventProcess = true;
                                                        endprocess = true;
                                                    }
                                                    if (modTypes.TempPlayer[i].EventProcessing[x].CurSlot > modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].CommandCount)
                                                    {
                                                        if (modTypes.TempPlayer[i].EventProcessing[x].CurList == 1)
                                                        {
                                                            // Get rid of this event, it is bad
                                                            removeEventProcess = true;
                                                            endprocess = true;
                                                        }
                                                        else
                                                        {
                                                            modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].ParentList;
                                                            modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                            restartlist = true;
                                                        }
                                                    }
                                                    if (restartlist == false && endprocess == false)
                                                    {
                                                        // If we are still here, then we are good to process shit :D
                                                        // Debug.WriteLine(.CurSlot)
                                                        switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Index)
                                                        {
                                                            case (int)S_Events.EventType.EvAddText:
                                                                {
                                                                    switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2)
                                                                    {
                                                                        case 0:
                                                                            {
                                                                                S_NetworkSend.PlayerMsg(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                                break;
                                                                            }

                                                                        case 1:
                                                                            {
                                                                                S_NetworkSend.MapMsg(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text1, (byte)modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                                break;
                                                                            }

                                                                        case 2:
                                                                            {
                                                                                S_NetworkSend.GlobalMsg(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text1); // Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                                                break;
                                                                            }
                                                                    }

                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvShowText:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SEventChat));
                                                                    buffer.WriteInt32(modTypes.TempPlayer[i].EventProcessing[x].EventId);
                                                                    buffer.WriteInt32(modTypes.TempPlayer[i].EventProcessing[x].PageId);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(ParseEventText(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text1))));
                                                                    buffer.WriteInt32(0);

                                                                    S_General.AddDebug("Sent SMSG: SEventChat evShowText");

                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].CommandCount > modTypes.TempPlayer[i].EventProcessing[x].CurSlot)
                                                                    {
                                                                        if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot + 1].Index == (byte)S_Events.EventType.EvShowText || modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot + 1].Index == (byte)S_Events.EventType.EvShowChoices)
                                                                            buffer.WriteInt32(1);
                                                                        else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot + 1].Index == (byte)S_Events.EventType.EvCondition)
                                                                            buffer.WriteInt32(2);
                                                                        else
                                                                            buffer.WriteInt32(0);
                                                                    }
                                                                    else
                                                                        buffer.WriteInt32(2);
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);
                                                                    buffer.Dispose();
                                                                    modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse = 1;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvShowChoices:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SEventChat));
                                                                    buffer.WriteInt32(modTypes.TempPlayer[i].EventProcessing[x].EventId);
                                                                    buffer.WriteInt32(modTypes.TempPlayer[i].EventProcessing[x].PageId);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data5);
                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(ParseEventText(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text1))));

                                                                    S_General.AddDebug("Sent SMSG: SEventChat evShowChoices");

                                                                    if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text2)) > 0)
                                                                    {
                                                                        w = 1;
                                                                        if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text3)) > 0)
                                                                        {
                                                                            w = 2;
                                                                            if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text4)) > 0)
                                                                            {
                                                                                w = 3;
                                                                                if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text5)) > 0)
                                                                                    w = 4;
                                                                            }
                                                                        }
                                                                    }
                                                                    buffer.WriteInt32(w);
                                                                    var loopTo4 = w;
                                                                    for (v = 1; v <= loopTo4; v++)
                                                                    {
                                                                        switch (v)
                                                                        {
                                                                            case 1:
                                                                                {
                                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(ParseEventText(i, Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text2)))));
                                                                                    break;
                                                                                }

                                                                            case 2:
                                                                                {
                                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(ParseEventText(i, Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text3)))));
                                                                                    break;
                                                                                }

                                                                            case 3:
                                                                                {
                                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(ParseEventText(i, Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text4)))));
                                                                                    break;
                                                                                }

                                                                            case 4:
                                                                                {
                                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(ParseEventText(i, Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text5)))));
                                                                                    break;
                                                                                }
                                                                        }
                                                                    }
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].CommandCount > modTypes.TempPlayer[i].EventProcessing[x].CurSlot)
                                                                    {
                                                                        if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot + 1].Index == (byte)S_Events.EventType.EvShowText || modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot + 1].Index == (byte)S_Events.EventType.EvShowChoices)
                                                                            buffer.WriteInt32(1);
                                                                        else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot + 1].Index == (byte)S_Events.EventType.EvCondition)
                                                                            buffer.WriteInt32(2);
                                                                        else
                                                                            buffer.WriteInt32(0);
                                                                    }
                                                                    else
                                                                        buffer.WriteInt32(2);
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);
                                                                    buffer.Dispose();
                                                                    modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse = 1;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvPlayerVar:
                                                                {
                                                                    switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2)
                                                                    {
                                                                        case 0:
                                                                            {
                                                                                modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1] = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3;
                                                                                break;
                                                                            }

                                                                        case 1:
                                                                            {
                                                                                modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1] = modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1] + modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3;
                                                                                break;
                                                                            }

                                                                        case 2:
                                                                            {
                                                                                modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1] = modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1] - modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3;
                                                                                break;
                                                                            }

                                                                        case 3:
                                                                            {
                                                                                modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1] = S_GameLogic.Random(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data4);
                                                                                break;
                                                                            }
                                                                    }

                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvPlayerSwitch:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 0)
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Switches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1] = 1;
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 1)
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Switches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1] = 0;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvSelfSwitch:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Globals == 1)
                                                                    {
                                                                        if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 0)
                                                                            modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1 + 1] = 1;
                                                                        else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 1)
                                                                            modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1 + 1] = 0;
                                                                    }
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 0)
                                                                        modTypes.TempPlayer[i].EventMap.EventPages[modTypes.TempPlayer[i].EventProcessing[x].EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1 + 1] = 1;
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 1)
                                                                        modTypes.TempPlayer[i].EventMap.EventPages[modTypes.TempPlayer[i].EventProcessing[x].EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1 + 1] = 0;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvCondition:
                                                                {
                                                                    switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Condition)
                                                                    {
                                                                        case 0:
                                                                            {
                                                                                switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data2)
                                                                                {
                                                                                    case 0:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1] == modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data3)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 1:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1] >= modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data3)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 2:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1] <= modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data3)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 3:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1] > modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data3)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 4:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1] < modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data3)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 5:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1] != modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data3)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 1:
                                                                            {
                                                                                switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data2)
                                                                                {
                                                                                    case 0:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Switches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1] == 1)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 1:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Switches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1] == 0)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 2:
                                                                            {
                                                                                if (S_Players.HasItem(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1) >= modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data2)
                                                                                {
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 3:
                                                                            {
                                                                                if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Classes == modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1)
                                                                                {
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 4:
                                                                            {
                                                                                if (S_Players.HasSkill(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1) == true)
                                                                                {
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 5:
                                                                            {
                                                                                switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data2)
                                                                                {
                                                                                    case 0:
                                                                                        {
                                                                                            if (S_Players.GetPlayerLevel(i) == modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 1:
                                                                                        {
                                                                                            if (S_Players.GetPlayerLevel(i) >= modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 2:
                                                                                        {
                                                                                            if (S_Players.GetPlayerLevel(i) <= modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 3:
                                                                                        {
                                                                                            if (S_Players.GetPlayerLevel(i) > modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 4:
                                                                                        {
                                                                                            if (S_Players.GetPlayerLevel(i) < modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 5:
                                                                                        {
                                                                                            if (S_Players.GetPlayerLevel(i) != modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1)
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 6:
                                                                            {
                                                                                if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Globals == 1)
                                                                                {
                                                                                    switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data2)
                                                                                    {
                                                                                        case 0 // Self Switch is true
                                                                                       :
                                                                                            {
                                                                                                if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1 + 1] == 1)
                                                                                                {
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                }

                                                                                                break;
                                                                                            }

                                                                                        case 1  // self switch is false
                                                                                 :
                                                                                            {
                                                                                                if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1 + 1] == 0)
                                                                                                {
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                }

                                                                                                break;
                                                                                            }
                                                                                    }
                                                                                }
                                                                                else
                                                                                    switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data2)
                                                                                    {
                                                                                        case 0 // Self Switch is true
                                                                                       :
                                                                                            {
                                                                                                if (modTypes.TempPlayer[i].EventMap.EventPages[modTypes.TempPlayer[i].EventProcessing[x].EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1 + 1] == 1)
                                                                                                {
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                }

                                                                                                break;
                                                                                            }

                                                                                        case 1  // self switch is false
                                                                                 :
                                                                                            {
                                                                                                if (modTypes.TempPlayer[i].EventMap.EventPages[modTypes.TempPlayer[i].EventProcessing[x].EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1 + 1] == 0)
                                                                                                {
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                }

                                                                                                break;
                                                                                            }
                                                                                    }

                                                                                break;
                                                                            }

                                                                        case 7:
                                                                            {
                                                                                if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1 > 0 && modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1 <= S_Quest.MAX_QUESTS)
                                                                                {
                                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data2 == 0)
                                                                                    {
                                                                                        switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data3)
                                                                                        {
                                                                                            case 0:
                                                                                                {
                                                                                                    if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1].Status == 0)
                                                                                                    {
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                    }

                                                                                                    break;
                                                                                                }

                                                                                            case 1:
                                                                                                {
                                                                                                    if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1].Status == 1)
                                                                                                    {
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                    }

                                                                                                    break;
                                                                                                }

                                                                                            case 2:
                                                                                                {
                                                                                                    if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1].Status == 2 || modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1].Status == 3)
                                                                                                    {
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                    }

                                                                                                    break;
                                                                                                }

                                                                                            case 3:
                                                                                                {
                                                                                                    if (S_Quest.CanStartQuest(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1))
                                                                                                    {
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                    }

                                                                                                    break;
                                                                                                }

                                                                                            case 4:
                                                                                                {
                                                                                                    if (S_Quest.CanEndQuest(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1))
                                                                                                    {
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                        modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                                    }

                                                                                                    break;
                                                                                                }
                                                                                        }
                                                                                    }
                                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data2 == 1)
                                                                                    {
                                                                                        if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1].ActualTask == modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data3)
                                                                                        {
                                                                                            modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                            modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                            modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                            modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                            modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                        }
                                                                                    }
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 8:
                                                                            {
                                                                                if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Sex == modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1)
                                                                                {
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 9:
                                                                            {
                                                                                if ((int)Time.Instance.TimeOfDay == modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.Data1)
                                                                                {
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.CommandList;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff[modTypes.TempPlayer[i].EventProcessing[x].CurList] = modTypes.TempPlayer[i].EventProcessing[x].CurSlot;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].ConditionalBranch.ElseCommandList;
                                                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = 1;
                                                                                }

                                                                                break;
                                                                            }
                                                                    }
                                                                    endprocess = true;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvExitProcess:
                                                                {
                                                                    removeEventProcess = true;
                                                                    endprocess = true;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvChangeItems:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 0)
                                                                    {
                                                                        if (S_Players.HasItem(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1) > 0)
                                                                        {
                                                                            S_Players.SetPlayerInvItemValue(i, S_Players.FindItemSlot(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1), modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3);
                                                                            S_Quest.CheckTasks(i, (int)Enums.QuestType.Fetch, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                            S_Quest.CheckTasks(i, (int)Enums.QuestType.Give, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                        }
                                                                    }
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 1)
                                                                    {
                                                                        S_Players.GiveInvItem(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3, true);
                                                                        S_Quest.CheckTasks(i, (int)Enums.QuestType.Fetch, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                        S_Quest.CheckTasks(i, (int)Enums.QuestType.Give, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                    }
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 2)
                                                                    {
                                                                        int itemAmount;
                                                                        itemAmount = S_Players.HasItem(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                        // Check Amount
                                                                        if (itemAmount >= modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3)
                                                                        {
                                                                            S_Players.TakeInvItem(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3);
                                                                            S_Quest.CheckTasks(i, (int)Enums.QuestType.Fetch, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                            S_Quest.CheckTasks(i, (int)Enums.QuestType.Give, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                        }
                                                                    }
                                                                    S_NetworkSend.SendInventory(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvRestoreHp:
                                                                {
                                                                    S_Players.SetPlayerVital(i, Enums.VitalType.HP, S_Players.GetPlayerMaxVital(i, Enums.VitalType.HP));
                                                                    S_NetworkSend.SendVital(i, Enums.VitalType.HP);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvRestoreMp:
                                                                {
                                                                    S_Players.SetPlayerVital(i, Enums.VitalType.MP, S_Players.GetPlayerMaxVital(i, Enums.VitalType.MP));
                                                                    S_NetworkSend.SendVital(i, Enums.VitalType.MP);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvLevelUp:
                                                                {
                                                                    S_Players.SetPlayerExp(i, S_Players.GetPlayerNextLevel(i));
                                                                    S_Players.CheckPlayerLevelUp(i);
                                                                    S_NetworkSend.SendExp(i);
                                                                    S_NetworkSend.SendPlayerData(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvChangeLevel:
                                                                {
                                                                    S_Players.SetPlayerLevel(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                    S_Players.SetPlayerExp(i, 0);
                                                                    S_NetworkSend.SendExp(i);
                                                                    S_NetworkSend.SendPlayerData(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvChangeSkills:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 0)
                                                                    {
                                                                        if (S_Players.FindOpenSkillSlot(i) > 0)
                                                                        {
                                                                            if (S_Players.HasSkill(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1) == false)
                                                                                S_Players.SetPlayerSkill(i, S_Players.FindOpenSkillSlot(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                            else
                                                                            {
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                        }
                                                                    }
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 1)
                                                                    {
                                                                        if (S_Players.HasSkill(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1) == true)
                                                                        {
                                                                            for (p = 1; p <= Constants.MAX_PLAYER_SKILLS; p++)
                                                                            {
                                                                                if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Skill[p] == modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1)
                                                                                    S_Players.SetPlayerSkill(i, p, 0);
                                                                            }
                                                                        }
                                                                    }
                                                                    S_NetworkSend.SendPlayerSkills(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvChangeClass:
                                                                {
                                                                    modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Classes = (byte)modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1;
                                                                    S_NetworkSend.SendPlayerData(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvChangeSprite:
                                                                {
                                                                    S_Players.SetPlayerSprite(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                    S_NetworkSend.SendPlayerData(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvChangeSex:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1 == 0)
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Sex = (byte)Enums.SexType.Male;
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1 == 1)
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Sex = (byte)Enums.SexType.Female;
                                                                    S_NetworkSend.SendPlayerData(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvChangePk:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1 == 0)
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Pk = 0;
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1 == 1)
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Pk = 1;
                                                                    S_NetworkSend.SendPlayerData(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvWarpPlayer:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data4 == 0)
                                                                        S_Players.PlayerWarp(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3);
                                                                    else
                                                                    {
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Dir = (byte)(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data4 - 1);
                                                                        S_Players.PlayerWarp(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3);
                                                                    }

                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvSetMoveRoute:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1 <= modTypes.Map[S_Players.GetPlayerMap(i)].EventCount)
                                                                    {
                                                                        if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].Globals == 1)
                                                                        {
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].MoveType = 2;
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].IgnoreIfCannotMove = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2;
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].RepeatMoveRoute = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3;
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].MoveRouteCount = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].MoveRouteCount;
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].MoveRoute = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].MoveRoute;
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].MoveRouteStep = 0;
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].MoveRouteComplete = 0;
                                                                        }
                                                                        else
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].MoveType = 2;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].IgnoreIfCannotMove = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].RepeatMoveRoute = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].MoveRouteCount = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].MoveRouteCount;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].MoveRoute = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].MoveRoute;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].MoveRouteStep = 0;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].MoveRouteComplete = 0;
                                                                        }
                                                                    }

                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvPlayAnimation:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 0)
                                                                        S_Animations.SendAnimation(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, S_Players.GetPlayerX(i), S_Players.GetPlayerY(i), (byte)Enums.TargetType.Player, i);
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 1)
                                                                    {
                                                                        if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Globals == 1)
                                                                            S_Animations.SendAnimation(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].X, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3].Y);
                                                                        else
                                                                            S_Animations.SendAnimation(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3].X, modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3].Y, 0, 0);
                                                                    }
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2 == 2)
                                                                        S_Animations.SendAnimation(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data4, 0, 0);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvCustomScript:
                                                                {
                                                                    // Runs Through Cases for a script
                                                                    S_Events.CustomScript(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, S_Players.GetPlayerMap(i), modTypes.TempPlayer[i].EventProcessing[x].EventId);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvPlayBgm:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SPlayBGM));
                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text1)));
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SPlayBGM", S_Constants.PACKET_LOG);
                                                                    S_General.AddDebug("Sent SMSG: SPlayBGM");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvFadeoutBgm:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SFadeoutBGM));
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SFadeoutBGM", S_Constants.PACKET_LOG);
                                                                    S_General.AddDebug("Sent SMSG: SFadeoutBGM");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvPlaySound:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SPlaySound));
                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text1)));
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SPlaySound", S_Constants.PACKET_LOG);
                                                                    S_General.AddDebug("Sent SMSG: SPlaySound");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvStopSound:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SStopSound));
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SStopSound", S_Constants.PACKET_LOG);
                                                                    S_General.AddDebug("Sent SMSG: SStopSound");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvSetAccess:
                                                                {
                                                                    modTypes.Player[i].Access = (byte)modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1;
                                                                    S_NetworkSend.SendPlayerData(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvOpenShop:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1 > 0)
                                                                    {
                                                                        if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Shop[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].Name)) > 0)
                                                                        {
                                                                            S_NetworkSend.SendOpenShop(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                            modTypes.TempPlayer[i].InShop = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1; // stops movement and the like
                                                                            modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse = 2;
                                                                        }
                                                                    }

                                                                    break;
                                                                }
                                                            case (int)S_Events.EventType.EvOpenBank:
                                                                {
                                                                    S_NetworkSend.SendBank(i);
                                                                    modTypes.TempPlayer[i].InBank = true;
                                                                    modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse = 3;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvGiveExp:
                                                                {
                                                                    S_Events.GivePlayerExp(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvShowChatBubble:
                                                                {
                                                                    switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1)
                                                                    {
                                                                        case (int)Enums.TargetType.Player:
                                                                            {
                                                                                S_NetworkSend.SendChatBubble(S_Players.GetPlayerMap(i), i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text1, (int)Enums.ColorType.Brown);
                                                                                break;
                                                                            }

                                                                        case (int)Enums.TargetType.Npc:
                                                                            {
                                                                                S_NetworkSend.SendChatBubble(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text1, (int)Enums.ColorType.Brown);
                                                                                break;
                                                                            }

                                                                        case (int)Enums.TargetType.Event:
                                                                            {
                                                                                S_NetworkSend.SendChatBubble(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text1, (int)Enums.ColorType.Brown);
                                                                                break;
                                                                            }
                                                                    }

                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvLabel:
                                                                {
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvGotoLabel:
                                                                {
                                                                    // Find the label's list of commands and slot
                                                                    FindEventLabel(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Text1), S_Players.GetPlayerMap(i), modTypes.TempPlayer[i].EventProcessing[x].EventId, modTypes.TempPlayer[i].EventProcessing[x].PageId, ref modTypes.TempPlayer[i].EventProcessing[x].CurSlot, ref modTypes.TempPlayer[i].EventProcessing[x].CurList, ref modTypes.TempPlayer[i].EventProcessing[x].ListLeftOff);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvSpawnNpc:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Npc[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1] > 0)
                                                                        S_Npc.SpawnNpc(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, S_Players.GetPlayerMap(i));
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvFadeIn:
                                                                {
                                                                    S_Events.SendSpecialEffect(i, S_Events.EffectTypeFadein);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvFadeOut:
                                                                {
                                                                    S_Events.SendSpecialEffect(i, S_Events.EffectTypeFadeout);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvFlashWhite:
                                                                {
                                                                    S_Events.SendSpecialEffect(i, S_Events.EffectTypeFlash);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvSetFog:
                                                                {
                                                                    S_Events.SendSpecialEffect(i, S_Events.EffectTypeFog, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvSetWeather:
                                                                {
                                                                    S_Events.SendSpecialEffect(i, S_Events.EffectTypeWeather, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvSetTint:
                                                                {
                                                                    S_Events.SendSpecialEffect(i, S_Events.EffectTypeTint, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data4);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvWait:
                                                                {
                                                                    modTypes.TempPlayer[i].EventProcessing[x].ActionTimer = S_General.GetTimeMs() + modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvOpenMail:
                                                                {
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvBeginQuest:
                                                                {
                                                                    if (S_Quest.CanStartQuest(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1))
                                                                        S_Quest.QuestMessage(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, S_Quest.Quest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].Chat[1], modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvEndQuest:
                                                                {
                                                                    if (S_Quest.CanEndQuest(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1))
                                                                        S_Quest.EndQuest(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvQuestTask:
                                                                {
                                                                    if (S_Quest.QuestInProgress(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1))
                                                                    {
                                                                        if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].ActualTask == modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2)
                                                                        {
                                                                            if (S_Quest.Quest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].Task[modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].ActualTask].TaskType == (int)Enums.QuestType.TalkEvent || S_Quest.Quest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].Task[modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].ActualTask].TaskType == (int)Enums.QuestType.Fetch)
                                                                                S_Quest.CheckTask(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1, S_Quest.Quest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].Task[modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].ActualTask].TaskType, -1);
                                                                        }
                                                                    }

                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvShowPicture:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SPic));
                                                                    buffer.WriteInt32(0);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1 + 1);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data2);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data3);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data4);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data5);
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SPic evShowPicture", S_Constants.PACKET_LOG);
                                                                    S_General.AddDebug("Sent SMSG: SPic evShowPicture");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvHidePicture:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SPic));
                                                                    buffer.WriteInt32(1);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1 + 1);
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SPic evHidePicture", S_Constants.PACKET_LOG);
                                                                    S_General.AddDebug("Sent SMSG: SPic evHidePicture");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvWaitMovement:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1 <= modTypes.Map[S_Players.GetPlayerMap(i)].EventCount)
                                                                    {
                                                                        if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1].Globals == 1)
                                                                        {
                                                                            modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse = 4;
                                                                            modTypes.TempPlayer[i].EventProcessing[x].EventMovingId = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1;
                                                                            modTypes.TempPlayer[i].EventProcessing[x].EventMovingType = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            modTypes.TempPlayer[i].EventProcessing[x].WaitingForResponse = 4;
                                                                            modTypes.TempPlayer[i].EventProcessing[x].EventMovingId = modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventProcessing[x].EventId].Pages[modTypes.TempPlayer[i].EventProcessing[x].PageId].CommandList[modTypes.TempPlayer[i].EventProcessing[x].CurList].Commands[modTypes.TempPlayer[i].EventProcessing[x].CurSlot].Data1;
                                                                            modTypes.TempPlayer[i].EventProcessing[x].EventMovingType = 0;
                                                                        }
                                                                    }

                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvHoldPlayer:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SHoldPlayer));
                                                                    buffer.WriteInt32(0);
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SHoldPlayer", S_Constants.PACKET_LOG);
                                                                    S_General.AddDebug("Sent SMSG: SHoldPlayer");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvReleasePlayer:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SHoldPlayer));
                                                                    buffer.WriteInt32(1);
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SHoldPlayer Release", S_Constants.PACKET_LOG);
                                                                    S_General.AddDebug("Sent SMSG: SHoldPlayer Release");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }
                                                        }
                                                    }
                                                }
                                                if (endprocess == false)
                                                    modTypes.TempPlayer[i].EventProcessing[x].CurSlot = modTypes.TempPlayer[i].EventProcessing[x].CurSlot + 1;
                                            }
                                        }
                                    }
                                }
                                if (removeEventProcess == true)
                                {
                                    modTypes.TempPlayer[i].EventProcessing[x].Active = 0;
                                    restartloop = true;
                                    removeEventProcess = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        internal static void UpdateEventLogic()
        {
            // Check Removing and Adding of Events (Did switches change or something?)

            if (S_Globals.Gettingmap == true)
                return;

            RemoveDeadEvents();

            if (S_Globals.Gettingmap == true)
                return;

            SpawnNewEvents();

            if (S_Globals.Gettingmap == true)
                return;

            ProcessEventMovement();

            if (S_Globals.Gettingmap == true)
                return;

            ProcessLocalEventMovement();

            if (S_Globals.Gettingmap == true)
                return;

            ProcessEventCommands();
        }

        public static string ParseEventText(int index, string txt)
        {
            int i;
            int x;
            string newtxt;
            string parsestring;
            int z;

            txt = Microsoft.VisualBasic.Strings.Replace(txt, "/name", Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Name));
            txt = Microsoft.VisualBasic.Strings.Replace(txt, "/p", Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Name));
            txt = Microsoft.VisualBasic.Strings.Replace(txt, "$playername$", Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Name));
            txt = Microsoft.VisualBasic.Strings.Replace(txt, "$playerclass$", Microsoft.VisualBasic.Strings.Trim(Types.Classes[modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Classes].Name));
            while (Microsoft.VisualBasic.Strings.InStr(1, txt, "/v") > 0)
            {
                x = Microsoft.VisualBasic.Strings.InStr(1, txt, "/v");
                if (x > 0)
                {
                    i = 0;
                    while (!Information.IsNumeric(Microsoft.VisualBasic.Strings.Mid(txt, x + 2 + i, 1)) == false)
                        i = i + 1;
                    newtxt = Microsoft.VisualBasic.Strings.Mid(txt, 1, x - 1);
                    parsestring = Microsoft.VisualBasic.Strings.Mid(txt, x + 2, i);
                    z = modTypes.Player[index].Character[modTypes.TempPlayer[i].CurChar].Variables[(int)Conversion.Val(parsestring)];
                    newtxt = newtxt + System.Convert.ToString(z);
                    newtxt = newtxt + Microsoft.VisualBasic.Strings.Mid(txt, x + 2 + i, Microsoft.VisualBasic.Strings.Len(txt) - (x + i));
                    txt = newtxt;
                }
            }
            return txt;
        }

        public static void FindEventLabel(string Label, int mapNum, int eventID, int pageID, ref int CurSlot, ref int CurList, ref int[] ListLeftOff)
        {
            int tmpCurSlot = 0;
            int tmpCurList = 0;
            int[] CurrentListOption;
            bool removeEventProcess = false;
            int[] tmpListLeftOff;
            bool restartlist = false;
            int w = 0;

            // Store the Old data, just in case

            tmpCurSlot = CurSlot;
            tmpCurList = CurList;
            tmpListLeftOff = ListLeftOff;

            ListLeftOff = new int[modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandListCount + 1];
            CurrentListOption = new int[modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandListCount + 1];
            CurList = 1;
            CurSlot = 1;

            while (!removeEventProcess == true)
            {
                if (ListLeftOff[CurList] > 0)
                {
                    CurSlot = ListLeftOff[CurList];
                    ListLeftOff[CurList] = 0;
                }
                if (CurList > modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandListCount)
                    // Get rid of this event, it is bad
                    removeEventProcess = true;

                if (CurSlot > modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].CommandCount)
                {
                    if (CurList == 1)
                        removeEventProcess = true;
                    else
                    {
                        CurList = modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].ParentList;
                        CurSlot = 1;
                        restartlist = true;
                    }
                }

                if (restartlist == false)
                {
                    if (removeEventProcess == false)
                    {
                        // If we are still here, then we are good to process shit :D
                        switch (modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].Commands[CurSlot].Index)
                        {
                            case (int)S_Events.EventType.EvShowChoices:
                                {
                                    if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].Commands[CurSlot].Text2)) > 0)
                                    {
                                        w = 1;
                                        if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].Commands[CurSlot].Text3)) > 0)
                                        {
                                            w = 2;
                                            if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].Commands[CurSlot].Text4)) > 0)
                                            {
                                                w = 3;
                                                if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].Commands[CurSlot].Text5)) > 0)
                                                    w = 4;
                                            }
                                        }
                                    }
                                    if (w > 0)
                                    {
                                        if (CurrentListOption[CurList] < w)
                                        {
                                            CurrentListOption[CurList] = CurrentListOption[CurList] + 1;
                                            // Process
                                            ListLeftOff[CurList] = CurSlot;
                                            switch (CurrentListOption[CurList])
                                            {
                                                case 1:
                                                    {
                                                        CurList = modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].Commands[CurSlot].Data1;
                                                        break;
                                                    }

                                                case 2:
                                                    {
                                                        CurList = modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].Commands[CurSlot].Data2;
                                                        break;
                                                    }

                                                case 3:
                                                    {
                                                        CurList = modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].Commands[CurSlot].Data3;
                                                        break;
                                                    }

                                                case 4:
                                                    {
                                                        CurList = modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].Commands[CurSlot].Data4;
                                                        break;
                                                    }
                                            }
                                            CurSlot = 0;
                                        }
                                        else
                                            CurrentListOption[CurList] = 0;
                                    }
                                    w = 0;
                                    break;
                                }

                            case (int)S_Events.EventType.EvCondition:
                                {
                                    if (CurrentListOption[CurList] == 0)
                                    {
                                        CurrentListOption[CurList] = 1;
                                        ListLeftOff[CurList] = CurSlot;
                                        CurList = modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].Commands[CurSlot].ConditionalBranch.CommandList;
                                        CurSlot = 0;
                                    }
                                    else if (CurrentListOption[CurList] == 1)
                                    {
                                        CurrentListOption[CurList] = 2;
                                        ListLeftOff[CurList] = CurSlot;
                                        CurList = modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].Commands[CurSlot].ConditionalBranch.ElseCommandList;
                                        CurSlot = 0;
                                    }
                                    else if (CurrentListOption[CurList] == 2)
                                        CurrentListOption[CurList] = 0;
                                    break;
                                }

                            case (int)S_Events.EventType.EvLabel:
                                {
                                    // Do nothing, just a label
                                    if (Microsoft.VisualBasic.Strings.Trim(modTypes.Map[mapNum].Events[eventID].Pages[pageID].CommandList[CurList].Commands[CurSlot].Text1) == Microsoft.VisualBasic.Strings.Trim(Label))
                                        return;
                                    break;
                                }
                        }
                        CurSlot = CurSlot + 1;
                    }
                }
                restartlist = false;
            }

            ListLeftOff = tmpListLeftOff;
            CurList = tmpCurList;
            CurSlot = tmpCurSlot;
        }

        public static int FindNpcPath(int mapNum, int mapnpcnum, int targetx, int targety)
        {
            int tim = 0;
            int sX = (int)modTypes.MapNpc[mapNum].Npc[mapnpcnum].X;
            int sY = (int)modTypes.MapNpc[mapNum].Npc[mapnpcnum].Y;
            int FX = targetx;
            int FY = targety;
            bool flag = FX == -1;
            if (flag)
            {
                FX = 0;
            }
            bool flag2 = FY == -1;
            if (flag2)
            {
                FY = 0;
            }
            checked
            {
                int[,] pos = new int[(int)(modTypes.Map[mapNum].MaxX + 1), (int)(modTypes.Map[mapNum].MaxY + 1)];
                pos[sX, sY] = 100 + tim;
                pos[FX, FY] = 2;
                bool reachable = false;
                int FindNpcPath = 0;
                while (!reachable)
                {
                    int maxY = (int)modTypes.Map[mapNum].MaxY;
                    for (int i = 0; i <= maxY; i++)
                    {
                        int maxX = (int)modTypes.Map[mapNum].MaxX;
                        for (int j = 0; j <= maxX; j++)
                        {
                            bool flag3 = pos[j, i] == 100 + tim;
                            if (flag3)
                            {
                                bool flag4 = j < (int)modTypes.Map[mapNum].MaxX;
                                if (flag4)
                                {
                                    bool flag5 = pos[j + 1, i] == 0;
                                    if (flag5)
                                    {
                                        pos[j + 1, i] = 100 + tim + 1;
                                    }
                                    else
                                    {
                                        bool flag6 = pos[j + 1, i] == 2;
                                        if (flag6)
                                        {
                                            reachable = true;
                                        }
                                    }
                                }
                                bool flag7 = j > 0;
                                if (flag7)
                                {
                                    bool flag8 = pos[j - 1, i] == 0;
                                    if (flag8)
                                    {
                                        pos[j - 1, i] = 100 + tim + 1;
                                    }
                                    else
                                    {
                                        bool flag9 = pos[j - 1, i] == 2;
                                        if (flag9)
                                        {
                                            reachable = true;
                                        }
                                    }
                                }
                                bool flag10 = i < (int)modTypes.Map[mapNum].MaxY;
                                if (flag10)
                                {
                                    bool flag11 = pos[j, i + 1] == 0;
                                    if (flag11)
                                    {
                                        pos[j, i + 1] = 100 + tim + 1;
                                    }
                                    else
                                    {
                                        bool flag12 = pos[j, i + 1] == 2;
                                        if (flag12)
                                        {
                                            reachable = true;
                                        }
                                    }
                                }
                                bool flag13 = i > 0;
                                if (flag13)
                                {
                                    bool flag14 = pos[j, i - 1] == 0;
                                    if (flag14)
                                    {
                                        pos[j, i - 1] = 100 + tim + 1;
                                    }
                                    else
                                    {
                                        bool flag15 = pos[j, i - 1] == 2;
                                        if (flag15)
                                        {
                                            reachable = true;
                                        }
                                    }
                                }
                            }
                            //Application.DoEvents();
                        }
                    }
                    bool flag16 = !reachable;
                    if (flag16)
                    {
                        int Sum = 0;
                        int maxY2 = (int)modTypes.Map[mapNum].MaxY;
                        for (int i = 0; i <= maxY2; i++)
                        {
                            int maxX2 = (int)modTypes.Map[mapNum].MaxX;
                            for (int j = 0; j <= maxX2; j++)
                            {
                                Sum += pos[j, i];
                            }
                        }
                        int LastSum = 0;
                        bool flag17 = Sum == LastSum;
                        if (flag17)
                        {
                            FindNpcPath = 4;
                            return FindNpcPath;
                        }
                        LastSum = Sum;
                    }
                    tim++;
                }
                int LastX = FX;
                int LastY = FY;
                Point[] path = new Point[tim + 1 + 1];
                while (LastX != sX || LastY != sY)
                {
                    tim--;
                    bool did = false;
                    bool flag18 = LastX < (int)modTypes.Map[mapNum].MaxX;
                    if (flag18)
                    {
                        bool flag19 = pos[LastX + 1, LastY] == 100 + tim;
                        if (flag19)
                        {
                            LastX++;
                            did = true;
                        }
                    }
                    bool flag20 = !did;
                    if (flag20)
                    {
                        bool flag21 = LastX > 0;
                        if (flag21)
                        {
                            bool flag22 = pos[LastX - 1, LastY] == 100 + tim;
                            if (flag22)
                            {
                                LastX--;
                                did = true;
                            }
                        }
                    }
                    bool flag23 = !did;
                    if (flag23)
                    {
                        bool flag24 = LastY < (int)modTypes.Map[mapNum].MaxY;
                        if (flag24)
                        {
                            bool flag25 = pos[LastX, LastY + 1] == 100 + tim;
                            if (flag25)
                            {
                                LastY++;
                                did = true;
                            }
                        }
                    }
                    bool flag26 = !did;
                    if (flag26)
                    {
                        bool flag27 = LastY > 0;
                        if (flag27)
                        {
                            bool flag28 = pos[LastX, LastY - 1] == 100 + tim;
                            if (flag28)
                            {
                                LastY--;
                            }
                        }
                    }
                    path[tim].X = LastX;
                    path[tim].Y = LastY;
                    //Application.DoEvents();
                }
                bool flag29 = path[1].X > LastX;
                if (flag29)
                {
                    return 3;
                }
                bool flag30 = path[1].Y > LastY;
                if (flag30)
                {
                    return 1;
                }
                bool flag31 = path[1].Y < LastY;
                if (flag31)
                {
                    return 0;
                }
                bool flag32 = path[1].X < LastX;
                if (flag32)
                {
                    return 2;
                }
                return FindNpcPath;
            }
        }

        public static void SpawnAllMapGlobalEvents()
        {
            int i;

            for (i = 0; i <= Constants.MAX_MAPS; i++)
                SpawnGlobalEvents(i);
        }

        public static void SpawnGlobalEvents(int mapNum)
        {
            bool flag = modTypes.Map[mapNum].EventCount > 0;
            checked
            {
                if (flag)
                {
                    S_Events.TempEventMap[mapNum].EventCount = 0;
                    S_Events.TempEventMap[mapNum].Events = new S_Events.GlobalEventStruct[1];
                    int eventCount = modTypes.Map[mapNum].EventCount;
                    for (int i = 1; i <= eventCount; i++)
                    {
                        S_Events.TempEventMap[mapNum].EventCount = S_Events.TempEventMap[mapNum].EventCount + 1;
                        S_Events.GlobalEventsStruct[] tempEventMap = S_Events.TempEventMap;
                        tempEventMap[mapNum].Events = (S_Events.GlobalEventStruct[])Microsoft.VisualBasic.CompilerServices.Utils.CopyArray(tempEventMap[mapNum].Events, new S_Events.GlobalEventStruct[S_Events.TempEventMap[mapNum].EventCount + 1]);
                        bool flag2 = modTypes.Map[mapNum].Events[i].PageCount > 0;
                        if (flag2)
                        {
                            bool flag3 = modTypes.Map[mapNum].Events[i].Globals == 1;
                            if (flag3)
                            {
                                S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].X = modTypes.Map[mapNum].Events[i].X;
                                S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].Y = modTypes.Map[mapNum].Events[i].Y;
                                bool flag4 = modTypes.Map[mapNum].Events[i].Pages[1].GraphicType == 1;
                                if (flag4)
                                {
                                    switch (modTypes.Map[mapNum].Events[i].Pages[1].GraphicY)
                                    {
                                        case 0:
                                            S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].Dir = 1;
                                            break;
                                        case 1:
                                            S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].Dir = 2;
                                            break;
                                        case 2:
                                            S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].Dir = 3;
                                            break;
                                        case 3:
                                            S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].Dir = 0;
                                            break;
                                    }
                                }
                                else
                                {
                                    S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].Dir = 1;
                                }
                                S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].Active = 1;
                                S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].MoveType = (int)modTypes.Map[mapNum].Events[i].Pages[1].MoveType;
                                bool flag5 = S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].MoveType == 2;
                                if (flag5)
                                {
                                    S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].MoveRouteCount = modTypes.Map[mapNum].Events[i].Pages[1].MoveRouteCount;
                                    S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].MoveRoute = new S_Events.MoveRouteStruct[modTypes.Map[mapNum].Events[i].Pages[1].MoveRouteCount + 1];
                                    int moveRouteCount = modTypes.Map[mapNum].Events[i].Pages[1].MoveRouteCount;
                                    for (int z = 0; z <= moveRouteCount; z++)
                                    {
                                        S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].MoveRoute[z] = modTypes.Map[mapNum].Events[i].Pages[1].MoveRoute[z];
                                    }
                                    S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].MoveRouteComplete = 0;
                                }
                                else
                                {
                                    S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].MoveRouteComplete = 1;
                                }
                                S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].RepeatMoveRoute = modTypes.Map[mapNum].Events[i].Pages[1].RepeatMoveRoute;
                                S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].IgnoreIfCannotMove = modTypes.Map[mapNum].Events[i].Pages[1].IgnoreMoveRoute;
                                S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].MoveFreq = (int)modTypes.Map[mapNum].Events[i].Pages[1].MoveFreq;
                                S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].MoveSpeed = (int)modTypes.Map[mapNum].Events[i].Pages[1].MoveSpeed;
                                S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].WalkThrough = modTypes.Map[mapNum].Events[i].Pages[1].WalkThrough;
                                S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].FixedDir = modTypes.Map[mapNum].Events[i].Pages[1].DirFix;
                                S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].WalkingAnim = modTypes.Map[mapNum].Events[i].Pages[1].WalkAnim;
                                S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].ShowName = modTypes.Map[mapNum].Events[i].Pages[1].ShowName;
                                S_Events.TempEventMap[mapNum].Events[S_Events.TempEventMap[mapNum].EventCount].QuestNum = modTypes.Map[mapNum].Events[i].Pages[1].QuestNum;
                            }
                        }
                    }
                }
            }
        }

        internal static void SpawnMapEventsFor(int index, int mapNum)
        {
            int i;
            int z;
            bool spawncurrentevent;
            int p;
            int compare;

            modTypes.TempPlayer[index].EventMap.CurrentEvents = 0;
            modTypes.TempPlayer[index].EventMap.EventPages = new MapEventStruct[1];
            if (modTypes.Map[mapNum].EventCount > 0)
            {
                modTypes.TempPlayer[index].EventProcessing = new EventProcessingStruct[modTypes.Map[mapNum].EventCount + 1];
                modTypes.TempPlayer[index].EventProcessingCount = modTypes.Map[mapNum].EventCount;
            }
            else
            {
                modTypes.TempPlayer[index].EventProcessing = new EventProcessingStruct[1];
                modTypes.TempPlayer[index].EventProcessingCount = 0;
            }

            if (modTypes.Map[mapNum].EventCount <= 0)
                return;
            var loopTo = modTypes.Map[mapNum].EventCount;
            for (i = 1; i <= loopTo; i++)
            {
                if (modTypes.Map[mapNum].Events[i].PageCount > 0)
                {
                    for (z = modTypes.Map[mapNum].Events[i].PageCount; z >= 1; z += -1)
                    {
                        {
                            spawncurrentevent = true;

                            if (modTypes.Map[mapNum].Events[i].Pages[z].ChkVariable == 1)
                            {
                                switch (modTypes.Map[mapNum].Events[i].Pages[z].VariableCompare)
                                {
                                    case 0:
                                        {
                                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Variables[modTypes.Map[mapNum].Events[i].Pages[z].Variableindex] != modTypes.Map[mapNum].Events[i].Pages[z].VariableCondition)
                                                spawncurrentevent = false;
                                            break;
                                        }

                                    case 1:
                                        {
                                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Variables[modTypes.Map[mapNum].Events[i].Pages[z].Variableindex] < modTypes.Map[mapNum].Events[i].Pages[z].VariableCondition)
                                                spawncurrentevent = false;
                                            break;
                                        }

                                    case 2:
                                        {
                                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Variables[modTypes.Map[mapNum].Events[i].Pages[z].Variableindex] > modTypes.Map[mapNum].Events[i].Pages[z].VariableCondition)
                                                spawncurrentevent = false;
                                            break;
                                        }

                                    case 3:
                                        {
                                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Variables[modTypes.Map[mapNum].Events[i].Pages[z].Variableindex] <= modTypes.Map[mapNum].Events[i].Pages[z].VariableCondition)
                                                spawncurrentevent = false;
                                            break;
                                        }

                                    case 4:
                                        {
                                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Variables[modTypes.Map[mapNum].Events[i].Pages[z].Variableindex] >= modTypes.Map[mapNum].Events[i].Pages[z].VariableCondition)
                                                spawncurrentevent = false;
                                            break;
                                        }

                                    case 5:
                                        {
                                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Variables[modTypes.Map[mapNum].Events[i].Pages[z].Variableindex] == modTypes.Map[mapNum].Events[i].Pages[z].VariableCondition)
                                                spawncurrentevent = false;
                                            break;
                                        }
                                }
                            }

                            // we are assuming the event will spawn, and are looking for ways to stop it
                            if (modTypes.Map[mapNum].Events[i].Pages[z].ChkSwitch == 1)
                            {
                                if (modTypes.Map[mapNum].Events[i].Pages[z].SwitchCompare == 1)
                                {
                                    if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Switches[modTypes.Map[mapNum].Events[i].Pages[z].Switchindex] == 0)
                                        spawncurrentevent = false;
                                }
                                else if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Switches[modTypes.Map[mapNum].Events[i].Pages[z].Switchindex] == 1)
                                    spawncurrentevent = false;
                            }

                            if (modTypes.Map[mapNum].Events[i].Pages[z].ChkHasItem == 1)
                            {
                                if (S_Players.HasItem(index, modTypes.Map[mapNum].Events[i].Pages[z].HasItemindex) == 0)
                                    spawncurrentevent = false;
                            }

                            if (modTypes.Map[mapNum].Events[i].Pages[z].ChkSelfSwitch == 1)
                            {
                                if (modTypes.Map[mapNum].Events[i].Pages[z].SelfSwitchCompare == 0)
                                    compare = 1;
                                else
                                    compare = 0;
                                if (modTypes.Map[mapNum].Events[i].Globals == 1)
                                {
                                    if (modTypes.Map[mapNum].Events[i].SelfSwitches[modTypes.Map[mapNum].Events[i].Pages[z].SelfSwitchindex] != compare)
                                        spawncurrentevent = false;
                                }
                                else if (compare == 1)
                                    spawncurrentevent = false;
                            }

                            if (spawncurrentevent == true || (spawncurrentevent == false && z == 1))
                            {
                                // spawn the event... send data to player
                                modTypes.TempPlayer[index].EventMap.CurrentEvents = modTypes.TempPlayer[index].EventMap.CurrentEvents + 1;
                                var oldEventPages = modTypes.TempPlayer[index].EventMap.EventPages;
                                modTypes.TempPlayer[index].EventMap.EventPages = new MapEventStruct[modTypes.TempPlayer[index].EventMap.CurrentEvents + 1];
                                if (oldEventPages != null)
                                    Array.Copy(oldEventPages, modTypes.TempPlayer[index].EventMap.EventPages, Math.Min(modTypes.TempPlayer[index].EventMap.CurrentEvents + 1, oldEventPages.Length));
                                {
                                    if (modTypes.Map[mapNum].Events[i].Pages[z].GraphicType == 1)
                                    {
                                        switch (modTypes.Map[mapNum].Events[i].Pages[z].GraphicY)
                                        {
                                            case 0:
                                                {
                                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].Dir = (int)Enums.DirectionType.Down;
                                                    break;
                                                }

                                            case 1:
                                                {
                                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].Dir = (int)Enums.DirectionType.Left;
                                                    break;
                                                }

                                            case 2:
                                                {
                                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].Dir = (int)Enums.DirectionType.Right;
                                                    break;
                                                }

                                            case 3:
                                                {
                                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].Dir = (int)Enums.DirectionType.Up;
                                                    break;
                                                }
                                        }
                                    }
                                    else
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].Dir = 0;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].GraphicNum = modTypes.Map[mapNum].Events[i].Pages[z].Graphic;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].GraphicType = modTypes.Map[mapNum].Events[i].Pages[z].GraphicType;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].GraphicX = modTypes.Map[mapNum].Events[i].Pages[z].GraphicX;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].GraphicY = modTypes.Map[mapNum].Events[i].Pages[z].GraphicY;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].GraphicX2 = modTypes.Map[mapNum].Events[i].Pages[z].GraphicX2;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].GraphicY2 = modTypes.Map[mapNum].Events[i].Pages[z].GraphicY2;
                                    switch (modTypes.Map[mapNum].Events[i].Pages[z].MoveSpeed)
                                    {
                                        case 0:
                                            {
                                                modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MovementSpeed = 2;
                                                break;
                                            }

                                        case 1:
                                            {
                                                modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MovementSpeed = 3;
                                                break;
                                            }

                                        case 2:
                                            {
                                                modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MovementSpeed = 4;
                                                break;
                                            }

                                        case 3:
                                            {
                                                modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MovementSpeed = 6;
                                                break;
                                            }

                                        case 4:
                                            {
                                                modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MovementSpeed = 12;
                                                break;
                                            }

                                        case 5:
                                            {
                                                modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MovementSpeed = 24;
                                                break;
                                            }
                                    }
                                    if (Convert.ToBoolean(modTypes.Map[mapNum].Events[i].Globals))
                                    {
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].X = S_Events.TempEventMap[mapNum].Events[i].X;
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].Y = S_Events.TempEventMap[mapNum].Events[i].Y;
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].Dir = S_Events.TempEventMap[mapNum].Events[i].Dir;
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MoveRouteStep = S_Events.TempEventMap[mapNum].Events[i].MoveRouteStep;
                                    }
                                    else
                                    {
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].X = modTypes.Map[mapNum].Events[i].X;
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].Y = modTypes.Map[mapNum].Events[i].Y;
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MoveRouteStep = 0;
                                    }
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].Position = modTypes.Map[mapNum].Events[i].Pages[z].Position;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].EventId = i;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].PageId = z;
                                    if (spawncurrentevent == true)
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].Visible = 1;
                                    else
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].Visible = 0;

                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MoveType = modTypes.Map[mapNum].Events[i].Pages[z].MoveType;
                                    if (modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MoveType == 2)
                                    {
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MoveRouteCount = modTypes.Map[mapNum].Events[i].Pages[z].MoveRouteCount;
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MoveRoute = new MoveRouteStruct[modTypes.Map[mapNum].Events[i].Pages[z].MoveRouteCount + 1];
                                        if (modTypes.Map[mapNum].Events[i].Pages[z].MoveRouteCount > 0)
                                        {
                                            var loopTo1 = modTypes.Map[mapNum].Events[i].Pages[z].MoveRouteCount;
                                            for (p = 0; p <= loopTo1; p++)
                                                modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MoveRoute[p] = modTypes.Map[mapNum].Events[i].Pages[z].MoveRoute[p];
                                        }
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MoveRouteComplete = 0;
                                    }
                                    else
                                        modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MoveRouteComplete = 1;

                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].RepeatMoveRoute = modTypes.Map[mapNum].Events[i].Pages[z].RepeatMoveRoute;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].IgnoreIfCannotMove = modTypes.Map[mapNum].Events[i].Pages[z].IgnoreMoveRoute;

                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MoveFreq = modTypes.Map[mapNum].Events[i].Pages[z].MoveFreq;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].MoveSpeed = modTypes.Map[mapNum].Events[i].Pages[z].MoveSpeed;

                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].WalkingAnim = modTypes.Map[mapNum].Events[i].Pages[z].WalkAnim;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].WalkThrough = modTypes.Map[mapNum].Events[i].Pages[z].WalkThrough;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].ShowName = modTypes.Map[mapNum].Events[i].Pages[z].ShowName;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].FixedDir = modTypes.Map[mapNum].Events[i].Pages[z].DirFix;
                                    modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents].QuestNum = modTypes.Map[mapNum].Events[i].Pages[z].QuestNum;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            ByteStream buffer;
            if (modTypes.TempPlayer[index].EventMap.CurrentEvents > 0)
            {
                var loopTo2 = modTypes.TempPlayer[index].EventMap.CurrentEvents;
                for (i = 1; i <= loopTo2; i++)
                {
                    buffer = new ByteStream(4);
                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SSpawnEvent));
                    buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[i].EventId);
                    {
                        //var modTypes.TempPlayer[i].EventProcessing[x] = modTypes.TempPlayer[index].EventMap.EventPages[i];
                        buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Name)));
                        buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[i].Dir);
                        buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[i].GraphicNum);
                        buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[i].GraphicType);
                        buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[i].GraphicX);
                        buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[i].GraphicX2);
                        buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[i].GraphicY);
                        buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[i].GraphicY2);
                        buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[i].MovementSpeed);
                        buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[i].X);
                        buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[i].Y);
                        buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[i].Position);
                        buffer.WriteInt32(modTypes.TempPlayer[index].EventMap.EventPages[i].Visible);
                        buffer.WriteInt32(modTypes.Map[mapNum].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].WalkAnim);
                        buffer.WriteInt32(modTypes.Map[mapNum].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].DirFix);
                        buffer.WriteInt32(modTypes.Map[mapNum].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].WalkThrough);
                        buffer.WriteInt32(modTypes.Map[mapNum].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].ShowName);
                        buffer.WriteInt32(modTypes.Map[mapNum].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Pages[modTypes.TempPlayer[index].EventMap.EventPages[i].PageId].QuestNum);
                    }
                    S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

                    S_General.AddDebug("Sent SMSG: SSpawnEvent For Player");

                    buffer.Dispose();
                }
            }
        }
    }
}
