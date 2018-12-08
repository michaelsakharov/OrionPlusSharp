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
                                        var withBlock = modTypes.TempPlayer[i].EventMap.EventPages[x];
                                        Buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock.EventId].Name)));
                                        Buffer.WriteInt32(withBlock.Dir);
                                        Buffer.WriteInt32(withBlock.GraphicNum);
                                        Buffer.WriteInt32(withBlock.GraphicType);
                                        Buffer.WriteInt32(withBlock.GraphicX);
                                        Buffer.WriteInt32(withBlock.GraphicX2);
                                        Buffer.WriteInt32(withBlock.GraphicY);
                                        Buffer.WriteInt32(withBlock.GraphicY2);
                                        Buffer.WriteInt32(withBlock.MovementSpeed);
                                        Buffer.WriteInt32(withBlock.X);
                                        Buffer.WriteInt32(withBlock.Y);
                                        Buffer.WriteInt32(withBlock.Position);
                                        Buffer.WriteInt32(withBlock.Visible);
                                        Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[page].WalkAnim);
                                        Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[page].DirFix);
                                        Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[page].WalkThrough);
                                        Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[page].ShowName);
                                        Buffer.WriteInt32(withBlock.QuestNum);
                                    }
                                    S_NetworkConfig.Socket.SendDataTo(i, Buffer.Data, Buffer.Head);

                                    modDatabase.Addlog("Sent SMSG: SSpawnEvent Remove Dead Events", S_Constants.PACKET_LOG);
                                    Console.WriteLine("Sent SMSG: SSpawnEvent Remove Dead Events");

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
                                    var withBlock = modTypes.TempPlayer[i].EventMap.EventPages[id];
                                    if (modTypes.Map[mapNum].Events[id].Pages[z].GraphicType == 1)
                                    {
                                        switch (modTypes.Map[mapNum].Events[id].Pages[z].GraphicY)
                                        {
                                            case 0:
                                                {
                                                    withBlock.Dir = (int)Enums.DirectionType.Down;
                                                    break;
                                                }

                                            case 1:
                                                {
                                                    withBlock.Dir = (int)Enums.DirectionType.Left;
                                                    break;
                                                }

                                            case 2:
                                                {
                                                    withBlock.Dir = (int)Enums.DirectionType.Right;
                                                    break;
                                                }

                                            case 3:
                                                {
                                                    withBlock.Dir = (int)Enums.DirectionType.Up;
                                                    break;
                                                }
                                        }
                                    }
                                    else
                                        withBlock.Dir = 0;
                                    withBlock.GraphicNum = modTypes.Map[mapNum].Events[id].Pages[z].Graphic;
                                    withBlock.GraphicType = modTypes.Map[mapNum].Events[id].Pages[z].GraphicType;
                                    withBlock.GraphicX = modTypes.Map[mapNum].Events[id].Pages[z].GraphicX;
                                    withBlock.GraphicY = modTypes.Map[mapNum].Events[id].Pages[z].GraphicY;
                                    withBlock.GraphicX2 = modTypes.Map[mapNum].Events[id].Pages[z].GraphicX2;
                                    withBlock.GraphicY2 = modTypes.Map[mapNum].Events[id].Pages[z].GraphicY2;
                                    withBlock.QuestNum = modTypes.Map[mapNum].Events[id].Pages[z].QuestNum;
                                    switch (modTypes.Map[mapNum].Events[id].Pages[z].MoveSpeed)
                                    {
                                        case 0:
                                            {
                                                withBlock.MovementSpeed = 2;
                                                break;
                                            }

                                        case 1:
                                            {
                                                withBlock.MovementSpeed = 3;
                                                break;
                                            }

                                        case 2:
                                            {
                                                withBlock.MovementSpeed = 4;
                                                break;
                                            }

                                        case 3:
                                            {
                                                withBlock.MovementSpeed = 6;
                                                break;
                                            }

                                        case 4:
                                            {
                                                withBlock.MovementSpeed = 12;
                                                break;
                                            }

                                        case 5:
                                            {
                                                withBlock.MovementSpeed = 24;
                                                break;
                                            }
                                    }
                                    withBlock.Position = modTypes.Map[mapNum].Events[id].Pages[z].Position;
                                    withBlock.EventId = id;
                                    withBlock.PageId = z;
                                    withBlock.Visible = 1;

                                    withBlock.MoveType = modTypes.Map[mapNum].Events[id].Pages[z].MoveType;
                                    if (withBlock.MoveType == 2)
                                    {
                                        withBlock.MoveRouteCount = modTypes.Map[mapNum].Events[id].Pages[z].MoveRouteCount;
                                        if (withBlock.MoveRouteCount > 0)
                                        {
                                            withBlock.MoveRoute = new MoveRouteStruct[modTypes.Map[mapNum].Events[id].Pages[z].MoveRouteCount + 1];
                                            var loopTo3 = modTypes.Map[mapNum].Events[id].Pages[z].MoveRouteCount;
                                            for (p = 0; p <= loopTo3; p++)
                                                withBlock.MoveRoute[p] = modTypes.Map[mapNum].Events[id].Pages[z].MoveRoute[p];
                                            withBlock.MoveRouteComplete = 0;
                                        }
                                        else
                                            withBlock.MoveRouteComplete = 1;
                                    }
                                    else
                                        withBlock.MoveRouteComplete = 1;

                                    withBlock.RepeatMoveRoute = modTypes.Map[mapNum].Events[id].Pages[z].RepeatMoveRoute;
                                    withBlock.IgnoreIfCannotMove = modTypes.Map[mapNum].Events[id].Pages[z].IgnoreMoveRoute;

                                    withBlock.MoveFreq = modTypes.Map[mapNum].Events[id].Pages[z].MoveFreq;
                                    withBlock.MoveSpeed = modTypes.Map[mapNum].Events[id].Pages[z].MoveSpeed;

                                    withBlock.WalkThrough = modTypes.Map[mapNum].Events[id].Pages[z].WalkThrough;
                                    withBlock.ShowName = modTypes.Map[mapNum].Events[id].Pages[z].ShowName;
                                    withBlock.WalkingAnim = modTypes.Map[mapNum].Events[id].Pages[z].WalkAnim;
                                    withBlock.FixedDir = modTypes.Map[mapNum].Events[id].Pages[z].DirFix;
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
                                    var withBlock1 = modTypes.TempPlayer[i].EventMap.EventPages[x];
                                    Buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock1.EventId].Name)));
                                    Buffer.WriteInt32(withBlock1.Dir);
                                    Buffer.WriteInt32(withBlock1.GraphicNum);
                                    Buffer.WriteInt32(withBlock1.GraphicType);
                                    Buffer.WriteInt32(withBlock1.GraphicX);
                                    Buffer.WriteInt32(withBlock1.GraphicX2);
                                    Buffer.WriteInt32(withBlock1.GraphicY);
                                    Buffer.WriteInt32(withBlock1.GraphicY2);
                                    Buffer.WriteInt32(withBlock1.MovementSpeed);
                                    Buffer.WriteInt32(withBlock1.X);
                                    Buffer.WriteInt32(withBlock1.Y);
                                    Buffer.WriteInt32(withBlock1.Position);
                                    Buffer.WriteInt32(withBlock1.Visible);
                                    Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[z].WalkAnim);
                                    Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[z].DirFix);
                                    Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[z].WalkThrough);
                                    Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[z].ShowName);
                                    Buffer.WriteInt32(modTypes.Map[mapNum].Events[id].Pages[z].QuestNum);
                                    Buffer.WriteInt32(withBlock1.QuestNum);
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
                                                    var withBlock = S_Events.TempEventMap[i].Events[x];
                                                    isglobal = true;
                                                    mapNum = i;
                                                    playerID = 0;
                                                    eventID = x;
                                                    WalkThrough = S_Events.TempEventMap[i].Events[x].WalkThrough;
                                                    if (withBlock.MoveRouteCount > 0)
                                                    {
                                                        if (withBlock.MoveRouteStep >= withBlock.MoveRouteCount && withBlock.RepeatMoveRoute == 1)
                                                        {
                                                            withBlock.MoveRouteStep = 0;
                                                            withBlock.MoveRouteComplete = 1;
                                                        }
                                                        else if (withBlock.MoveRouteStep >= withBlock.MoveRouteCount && withBlock.RepeatMoveRoute == 0)
                                                        {
                                                            donotprocessmoveroute = true;
                                                            withBlock.MoveRouteComplete = 1;
                                                        }
                                                        else
                                                            withBlock.MoveRouteComplete = 0;
                                                        if (donotprocessmoveroute == false)
                                                        {
                                                            withBlock.MoveRouteStep = withBlock.MoveRouteStep + 1;
                                                            switch (withBlock.MoveSpeed)
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
                                                            switch (withBlock.MoveRoute[withBlock.MoveRouteStep].Index)
                                                            {
                                                                case 1:
                                                                    {
                                                                        if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (int)Enums.DirectionType.Up, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Up, actualmovespeed, isglobal);
                                                                        else if (withBlock.IgnoreIfCannotMove == 0)
                                                                            withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 2:
                                                                    {
                                                                        if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (int)Enums.DirectionType.Down, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Down, actualmovespeed, isglobal);
                                                                        else if (withBlock.IgnoreIfCannotMove == 0)
                                                                            withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 3:
                                                                    {
                                                                        if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (int)Enums.DirectionType.Left, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Left, actualmovespeed, isglobal);
                                                                        else if (withBlock.IgnoreIfCannotMove == 0)
                                                                            withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 4:
                                                                    {
                                                                        if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (int)Enums.DirectionType.Right, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Right, actualmovespeed, isglobal);
                                                                        else if (withBlock.IgnoreIfCannotMove == 0)
                                                                            withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 5:
                                                                    {
                                                                        z = S_GameLogic.Random(0, 3);
                                                                        if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                        else if (withBlock.IgnoreIfCannotMove == 0)
                                                                            withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 6:
                                                                    {
                                                                        if (isglobal == false)
                                                                        {
                                                                            if (S_Events.IsOneBlockAway(withBlock.X, withBlock.Y, S_Players.GetPlayerX(playerID), S_Players.GetPlayerY(playerID)) == true)
                                                                            {
                                                                                S_Events.EventDir(playerID, S_Players.GetPlayerMap(playerID), eventID, S_Events.GetDirToPlayer(playerID, S_Players.GetPlayerMap(playerID), eventID), false);
                                                                                if (withBlock.IgnoreIfCannotMove == 0)
                                                                                    withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                            }
                                                                            else
                                                                            {
                                                                                z = S_Events.CanEventMoveTowardsPlayer(playerID, mapNum, eventID);
                                                                                if (z >= 4)
                                                                                {
                                                                                    // No
                                                                                    if (withBlock.IgnoreIfCannotMove == 0)
                                                                                        withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                                }
                                                                                else
                                                                                    // i is the direct, lets go...
                                                                                    if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                                    S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                                else if (withBlock.IgnoreIfCannotMove == 0)
                                                                                    withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
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
                                                                                if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                            else if (withBlock.IgnoreIfCannotMove == 0)
                                                                                withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                        }

                                                                        break;
                                                                    }

                                                                case 8:
                                                                    {
                                                                        if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (byte)withBlock.Dir, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, withBlock.Dir, actualmovespeed, isglobal);
                                                                        else if (withBlock.IgnoreIfCannotMove == 0)
                                                                            withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 9:
                                                                    {
                                                                        switch (withBlock.Dir)
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
                                                                        if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                            S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                        else if (withBlock.IgnoreIfCannotMove == 0)
                                                                            withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                        break;
                                                                    }

                                                                case 10:
                                                                    {
                                                                        withBlock.MoveTimer = S_General.GetTimeMs() + 100;
                                                                        break;
                                                                    }

                                                                case 11:
                                                                    {
                                                                        withBlock.MoveTimer = S_General.GetTimeMs() + 500;
                                                                        break;
                                                                    }

                                                                case 12:
                                                                    {
                                                                        withBlock.MoveTimer = S_General.GetTimeMs() + 1000;
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
                                                                        switch (withBlock.Dir)
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
                                                                        switch (withBlock.Dir)
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
                                                                        switch (withBlock.Dir)
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
                                                                        withBlock.MoveSpeed = 0;
                                                                        break;
                                                                    }

                                                                case 24:
                                                                    {
                                                                        withBlock.MoveSpeed = 1;
                                                                        break;
                                                                    }

                                                                case 25:
                                                                    {
                                                                        withBlock.MoveSpeed = 2;
                                                                        break;
                                                                    }

                                                                case 26:
                                                                    {
                                                                        withBlock.MoveSpeed = 3;
                                                                        break;
                                                                    }

                                                                case 27:
                                                                    {
                                                                        withBlock.MoveSpeed = 4;
                                                                        break;
                                                                    }

                                                                case 28:
                                                                    {
                                                                        withBlock.MoveSpeed = 5;
                                                                        break;
                                                                    }

                                                                case 29:
                                                                    {
                                                                        withBlock.MoveFreq = 0;
                                                                        break;
                                                                    }

                                                                case 30:
                                                                    {
                                                                        withBlock.MoveFreq = 1;
                                                                        break;
                                                                    }

                                                                case 31:
                                                                    {
                                                                        withBlock.MoveFreq = 2;
                                                                        break;
                                                                    }

                                                                case 32:
                                                                    {
                                                                        withBlock.MoveFreq = 3;
                                                                        break;
                                                                    }

                                                                case 33:
                                                                    {
                                                                        withBlock.MoveFreq = 4;
                                                                        break;
                                                                    }

                                                                case 34:
                                                                    {
                                                                        withBlock.WalkingAnim = 1;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 35:
                                                                    {
                                                                        withBlock.WalkingAnim = 0;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 36:
                                                                    {
                                                                        withBlock.FixedDir = 1;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 37:
                                                                    {
                                                                        withBlock.FixedDir = 0;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 38:
                                                                    {
                                                                        withBlock.WalkThrough = 1;
                                                                        break;
                                                                    }

                                                                case 39:
                                                                    {
                                                                        withBlock.WalkThrough = 0;
                                                                        break;
                                                                    }

                                                                case 40:
                                                                    {
                                                                        withBlock.Position = 0;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 41:
                                                                    {
                                                                        withBlock.Position = 1;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 42:
                                                                    {
                                                                        withBlock.Position = 2;
                                                                        // Need to send update to client
                                                                        sendupdate = true;
                                                                        break;
                                                                    }

                                                                case 43:
                                                                    {
                                                                        withBlock.GraphicType = withBlock.MoveRoute[withBlock.MoveRouteStep].Data1;
                                                                        withBlock.GraphicNum = withBlock.MoveRoute[withBlock.MoveRouteStep].Data2;
                                                                        withBlock.GraphicX = withBlock.MoveRoute[withBlock.MoveRouteStep].Data3;
                                                                        withBlock.GraphicX2 = withBlock.MoveRoute[withBlock.MoveRouteStep].Data4;
                                                                        withBlock.GraphicY = withBlock.MoveRoute[withBlock.MoveRouteStep].Data5;
                                                                        withBlock.GraphicY2 = withBlock.MoveRoute[withBlock.MoveRouteStep].Data6;
                                                                        if (withBlock.GraphicType == 1)
                                                                        {
                                                                            switch (withBlock.GraphicY)
                                                                            {
                                                                                case 0:
                                                                                    {
                                                                                        withBlock.Dir = (int)Enums.DirectionType.Down;
                                                                                        break;
                                                                                    }

                                                                                case 1:
                                                                                    {
                                                                                        withBlock.Dir = (int)Enums.DirectionType.Left;
                                                                                        break;
                                                                                    }

                                                                                case 2:
                                                                                    {
                                                                                        withBlock.Dir = (int)Enums.DirectionType.Right;
                                                                                        break;
                                                                                    }

                                                                                case 3:
                                                                                    {
                                                                                        withBlock.Dir = (int)Enums.DirectionType.Up;
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
                                                                    var withBlock1 = S_Events.TempEventMap[i].Events[x];
                                                                    Buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[i].Events[x].Name)));
                                                                    Buffer.WriteInt32(withBlock1.Dir);
                                                                    Buffer.WriteInt32(withBlock1.GraphicNum);
                                                                    Buffer.WriteInt32(withBlock1.GraphicType);
                                                                    Buffer.WriteInt32(withBlock1.GraphicX);
                                                                    Buffer.WriteInt32(withBlock1.GraphicX2);
                                                                    Buffer.WriteInt32(withBlock1.GraphicY);
                                                                    Buffer.WriteInt32(withBlock1.GraphicY2);
                                                                    Buffer.WriteInt32(withBlock1.MoveSpeed);
                                                                    Buffer.WriteInt32(withBlock1.X);
                                                                    Buffer.WriteInt32(withBlock1.Y);
                                                                    Buffer.WriteInt32(withBlock1.Position);
                                                                    Buffer.WriteInt32(withBlock1.Active);
                                                                    Buffer.WriteInt32(withBlock1.WalkingAnim);
                                                                    Buffer.WriteInt32(withBlock1.FixedDir);
                                                                    Buffer.WriteInt32(withBlock1.WalkThrough);
                                                                    Buffer.WriteInt32(withBlock1.ShowName);
                                                                    Buffer.WriteInt32(withBlock1.QuestNum);
                                                                }
                                                                S_NetworkConfig.SendDataToMap(i, ref Buffer.Data, Buffer.Head);

                                                                modDatabase.Addlog("Sent SMSG: SSpawnEvent Process Event Movement", S_Constants.PACKET_LOG);
                                                                Console.WriteLine("Sent SMSG: SSpawnEvent Process Event Movement");

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
                Application.DoEvents();
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
                                                        var withBlock = modTypes.TempPlayer[i].EventMap.EventPages[x];
                                                        isglobal = false;
                                                        sendupdate = false;
                                                        mapNum = S_Players.GetPlayerMap(i);
                                                        playerID = i;
                                                        eventID = x;
                                                        WalkThrough = withBlock.WalkThrough;
                                                        if (modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteCount > 0)
                                                        {
                                                            if (modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteStep >= modTypes.TempPlayer[i].EventMap.EventPages[x].MoveRouteCount && modTypes.TempPlayer[i].EventMap.EventPages[x].RepeatMoveRoute == 1)
                                                            {
                                                                withBlock.MoveRouteStep = 0;
                                                                withBlock.MoveRouteComplete = 1;
                                                            }
                                                            else if (withBlock.MoveRouteStep >= withBlock.MoveRouteCount && withBlock.RepeatMoveRoute == 0)
                                                            {
                                                                donotprocessmoveroute = true;
                                                                withBlock.MoveRouteComplete = 1;
                                                            }
                                                            else
                                                                withBlock.MoveRouteComplete = 0;
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
                                                                            if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (int)Enums.DirectionType.Up, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Up, actualmovespeed, isglobal);
                                                                            else if (modTypes.TempPlayer[i].EventMap.EventPages[x].IgnoreIfCannotMove == 0)
                                                                                withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 2:
                                                                        {
                                                                            if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (int)Enums.DirectionType.Down, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Down, actualmovespeed, isglobal);
                                                                            else if (withBlock.IgnoreIfCannotMove == 0)
                                                                                withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 3:
                                                                        {
                                                                            if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (int)Enums.DirectionType.Left, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Left, actualmovespeed, isglobal);
                                                                            else if (withBlock.IgnoreIfCannotMove == 0)
                                                                                withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 4:
                                                                        {
                                                                            if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (int)Enums.DirectionType.Right, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, (int)Enums.DirectionType.Right, actualmovespeed, isglobal);
                                                                            else if (withBlock.IgnoreIfCannotMove == 0)
                                                                                withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 5:
                                                                        {
                                                                            z = S_GameLogic.Random(0, 3);
                                                                            if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                            else if (withBlock.IgnoreIfCannotMove == 0)
                                                                                withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 6:
                                                                        {
                                                                            if (isglobal == false)
                                                                            {
                                                                                if (S_Events.IsOneBlockAway(withBlock.X, withBlock.Y, S_Players.GetPlayerX(playerID), S_Players.GetPlayerY(playerID)) == true)
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
                                                                                    if (withBlock.IgnoreIfCannotMove == 0)
                                                                                        withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    z = S_Events.CanEventMoveTowardsPlayer(playerID, mapNum, eventID);
                                                                                    if (z >= 4)
                                                                                    {
                                                                                        // No
                                                                                        if (withBlock.IgnoreIfCannotMove == 0)
                                                                                            withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                                    }
                                                                                    else
                                                                                        // i is the direct, lets go...
                                                                                        if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                                        S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                                    else if (withBlock.IgnoreIfCannotMove == 0)
                                                                                        withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
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
                                                                                    if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                                    S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                                else if (withBlock.IgnoreIfCannotMove == 0)
                                                                                    withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                            }

                                                                            break;
                                                                        }

                                                                    case 8:
                                                                        {
                                                                            if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (byte)withBlock.Dir, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, withBlock.Dir, actualmovespeed, isglobal);
                                                                            else if (withBlock.IgnoreIfCannotMove == 0)
                                                                                withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 9:
                                                                        {
                                                                            switch (withBlock.Dir)
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
                                                                            if (S_Events.CanEventMove(playerID, mapNum, withBlock.X, withBlock.Y, eventID, WalkThrough, (byte)z, isglobal))
                                                                                S_Events.EventMove(playerID, mapNum, eventID, z, actualmovespeed, isglobal);
                                                                            else if (withBlock.IgnoreIfCannotMove == 0)
                                                                                withBlock.MoveRouteStep = withBlock.MoveRouteStep - 1;
                                                                            break;
                                                                        }

                                                                    case 10:
                                                                        {
                                                                            withBlock.MoveTimer = S_General.GetTimeMs() + 100;
                                                                            break;
                                                                        }

                                                                    case 11:
                                                                        {
                                                                            withBlock.MoveTimer = S_General.GetTimeMs() + 500;
                                                                            break;
                                                                        }

                                                                    case 12:
                                                                        {
                                                                            withBlock.MoveTimer = S_General.GetTimeMs() + 1000;
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
                                                                            switch (withBlock.Dir)
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
                                                                            switch (withBlock.Dir)
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
                                                                            switch (withBlock.Dir)
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
                                                                            withBlock.MoveSpeed = 0;
                                                                            break;
                                                                        }

                                                                    case 24:
                                                                        {
                                                                            withBlock.MoveSpeed = 1;
                                                                            break;
                                                                        }

                                                                    case 25:
                                                                        {
                                                                            withBlock.MoveSpeed = 2;
                                                                            break;
                                                                        }

                                                                    case 26:
                                                                        {
                                                                            withBlock.MoveSpeed = 3;
                                                                            break;
                                                                        }

                                                                    case 27:
                                                                        {
                                                                            withBlock.MoveSpeed = 4;
                                                                            break;
                                                                        }

                                                                    case 28:
                                                                        {
                                                                            withBlock.MoveSpeed = 5;
                                                                            break;
                                                                        }

                                                                    case 29:
                                                                        {
                                                                            withBlock.MoveFreq = 0;
                                                                            break;
                                                                        }

                                                                    case 30:
                                                                        {
                                                                            withBlock.MoveFreq = 1;
                                                                            break;
                                                                        }

                                                                    case 31:
                                                                        {
                                                                            withBlock.MoveFreq = 2;
                                                                            break;
                                                                        }

                                                                    case 32:
                                                                        {
                                                                            withBlock.MoveFreq = 3;
                                                                            break;
                                                                        }

                                                                    case 33:
                                                                        {
                                                                            withBlock.MoveFreq = 4;
                                                                            break;
                                                                        }

                                                                    case 34:
                                                                        {
                                                                            withBlock.WalkingAnim = 1;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 35:
                                                                        {
                                                                            withBlock.WalkingAnim = 0;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 36:
                                                                        {
                                                                            withBlock.FixedDir = 1;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 37:
                                                                        {
                                                                            withBlock.FixedDir = 0;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 38:
                                                                        {
                                                                            withBlock.WalkThrough = 1;
                                                                            break;
                                                                        }

                                                                    case 39:
                                                                        {
                                                                            withBlock.WalkThrough = 0;
                                                                            break;
                                                                        }

                                                                    case 40:
                                                                        {
                                                                            withBlock.Position = 0;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 41:
                                                                        {
                                                                            withBlock.Position = 1;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 42:
                                                                        {
                                                                            withBlock.Position = 2;
                                                                            // Need to send update to client
                                                                            sendupdate = true;
                                                                            break;
                                                                        }

                                                                    case 43:
                                                                        {
                                                                            withBlock.GraphicType = withBlock.MoveRoute[withBlock.MoveRouteStep].Data1;
                                                                            withBlock.GraphicNum = withBlock.MoveRoute[withBlock.MoveRouteStep].Data2;
                                                                            withBlock.GraphicX = withBlock.MoveRoute[withBlock.MoveRouteStep].Data3;
                                                                            withBlock.GraphicX2 = withBlock.MoveRoute[withBlock.MoveRouteStep].Data4;
                                                                            withBlock.GraphicY = withBlock.MoveRoute[withBlock.MoveRouteStep].Data5;
                                                                            withBlock.GraphicY2 = withBlock.MoveRoute[withBlock.MoveRouteStep].Data6;
                                                                            if (withBlock.GraphicType == 1)
                                                                            {
                                                                                switch (withBlock.GraphicY)
                                                                                {
                                                                                    case 0:
                                                                                        {
                                                                                            withBlock.Dir = (int)Enums.DirectionType.Down;
                                                                                            break;
                                                                                        }

                                                                                    case 1:
                                                                                        {
                                                                                            withBlock.Dir = (int)Enums.DirectionType.Left;
                                                                                            break;
                                                                                        }

                                                                                    case 2:
                                                                                        {
                                                                                            withBlock.Dir = (int)Enums.DirectionType.Right;
                                                                                            break;
                                                                                        }

                                                                                    case 3:
                                                                                        {
                                                                                            withBlock.Dir = (int)Enums.DirectionType.Up;
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
                                                                        var withBlock1 = modTypes.TempPlayer[playerID].EventMap.EventPages[eventID];
                                                                        Buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(playerID)].Events[modTypes.TempPlayer[playerID].EventMap.EventPages[eventID].EventId].Name)));
                                                                        Buffer.WriteInt32(withBlock1.Dir);
                                                                        Buffer.WriteInt32(withBlock1.GraphicNum);
                                                                        Buffer.WriteInt32(withBlock1.GraphicType);
                                                                        Buffer.WriteInt32(withBlock1.GraphicX);
                                                                        Buffer.WriteInt32(withBlock1.GraphicX2);
                                                                        Buffer.WriteInt32(withBlock1.GraphicY);
                                                                        Buffer.WriteInt32(withBlock1.GraphicY2);
                                                                        Buffer.WriteInt32(withBlock1.MoveSpeed);
                                                                        Buffer.WriteInt32(withBlock1.X);
                                                                        Buffer.WriteInt32(withBlock1.Y);
                                                                        Buffer.WriteInt32(withBlock1.Position);
                                                                        Buffer.WriteInt32(withBlock1.Visible);
                                                                        Buffer.WriteInt32(withBlock1.WalkingAnim);
                                                                        Buffer.WriteInt32(withBlock1.FixedDir);
                                                                        Buffer.WriteInt32(withBlock1.WalkThrough);
                                                                        Buffer.WriteInt32(withBlock1.ShowName);
                                                                        Buffer.WriteInt32(withBlock1.QuestNum);
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
                Application.DoEvents();
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
                                                var withBlock = modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId];
                                                withBlock.ActionTimer = S_General.GetTimeMs();
                                                withBlock.CurList = 1;
                                                withBlock.CurSlot = 1;
                                                withBlock.EventId = modTypes.TempPlayer[i].EventMap.EventPages[x].EventId;
                                                withBlock.PageId = modTypes.TempPlayer[i].EventMap.EventPages[x].PageId;
                                                withBlock.WaitingForResponse = 0;
                                                withBlock.ListLeftOff = new int[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Pages[modTypes.TempPlayer[i].EventMap.EventPages[x].PageId].CommandListCount + 1];
                                            }
                                        }
                                    }
                                }
                                else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Pages[modTypes.TempPlayer[i].EventMap.EventPages[x].PageId].CommandListCount > 0)
                                {
                                    // Clearly need to start it!
                                    modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Active = 1;
                                    {
                                        var withBlock1 = modTypes.TempPlayer[i].EventProcessing[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId];
                                        withBlock1.ActionTimer = S_General.GetTimeMs();
                                        withBlock1.CurList = 1;
                                        withBlock1.CurSlot = 1;
                                        withBlock1.EventId = modTypes.TempPlayer[i].EventMap.EventPages[x].EventId;
                                        withBlock1.PageId = modTypes.TempPlayer[i].EventMap.EventPages[x].PageId;
                                        withBlock1.WaitingForResponse = 0;
                                        withBlock1.ListLeftOff = new int[modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.TempPlayer[i].EventMap.EventPages[x].EventId].Pages[modTypes.TempPlayer[i].EventMap.EventPages[x].PageId].CommandListCount + 1];
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
                                        var withBlock2 = modTypes.TempPlayer[i].EventProcessing[x];
                                        if (modTypes.TempPlayer[i].EventProcessingCount == 0)
                                            return;
                                        removeEventProcess = false;
                                        if (withBlock2.WaitingForResponse == 2)
                                        {
                                            if (modTypes.TempPlayer[i].InShop == 0)
                                                withBlock2.WaitingForResponse = 0;
                                        }
                                        if (withBlock2.WaitingForResponse == 3)
                                        {
                                            if (modTypes.TempPlayer[i].InBank == false)
                                                withBlock2.WaitingForResponse = 0;
                                        }
                                        if (withBlock2.WaitingForResponse == 4)
                                        {
                                            // waiting for eventmovement to complete
                                            if (withBlock2.EventMovingType == 0)
                                            {
                                                if (modTypes.TempPlayer[i].EventMap.EventPages[withBlock2.EventMovingId].MoveRouteComplete == 1)
                                                    withBlock2.WaitingForResponse = 0;
                                            }
                                            else if (S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[withBlock2.EventMovingId].MoveRouteComplete == 1)
                                                withBlock2.WaitingForResponse = 0;
                                        }
                                        if (withBlock2.WaitingForResponse == 0)
                                        {
                                            if (withBlock2.ActionTimer <= S_General.GetTimeMs())
                                            {
                                                restartlist = true;
                                                endprocess = false;
                                                while (restartlist == true && endprocess == false && withBlock2.WaitingForResponse == 0)
                                                {
                                                    restartlist = false;
                                                    if (withBlock2.ListLeftOff[withBlock2.CurList] > 0)
                                                    {
                                                        withBlock2.CurSlot = withBlock2.ListLeftOff[withBlock2.CurList] + 1;
                                                        withBlock2.ListLeftOff[withBlock2.CurList] = 0;
                                                    }
                                                    if (withBlock2.CurList > modTypes.Map[modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Map].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandListCount)
                                                    {
                                                        // Get rid of this event, it is bad
                                                        removeEventProcess = true;
                                                        endprocess = true;
                                                    }
                                                    if (withBlock2.CurSlot > modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].CommandCount)
                                                    {
                                                        if (withBlock2.CurList == 1)
                                                        {
                                                            // Get rid of this event, it is bad
                                                            removeEventProcess = true;
                                                            endprocess = true;
                                                        }
                                                        else
                                                        {
                                                            withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].ParentList;
                                                            withBlock2.CurSlot = 1;
                                                            restartlist = true;
                                                        }
                                                    }
                                                    if (restartlist == false && endprocess == false)
                                                    {
                                                        // If we are still here, then we are good to process shit :D
                                                        // Debug.WriteLine(.CurSlot)
                                                        switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Index)
                                                        {
                                                            case (int)S_Events.EventType.EvAddText:
                                                                {
                                                                    switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2)
                                                                    {
                                                                        case 0:
                                                                            {
                                                                                S_NetworkSend.PlayerMsg(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                                break;
                                                                            }

                                                                        case 1:
                                                                            {
                                                                                S_NetworkSend.MapMsg(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text1, (byte)modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                                break;
                                                                            }

                                                                        case 2:
                                                                            {
                                                                                S_NetworkSend.GlobalMsg(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text1); // Map(GetPlayerMap(i)).Events(.EventID).Pages(.PageID).CommandList(.CurList).Commands(.CurSlot).Data1)
                                                                                break;
                                                                            }
                                                                    }

                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvShowText:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SEventChat));
                                                                    buffer.WriteInt32(withBlock2.EventId);
                                                                    buffer.WriteInt32(withBlock2.PageId);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(ParseEventText(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text1))));
                                                                    buffer.WriteInt32(0);

                                                                    S_General.AddDebug("Sent SMSG: SEventChat evShowText");

                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].CommandCount > withBlock2.CurSlot)
                                                                    {
                                                                        if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot + 1].Index == (byte)S_Events.EventType.EvShowText || modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot + 1].Index == (byte)S_Events.EventType.EvShowChoices)
                                                                            buffer.WriteInt32(1);
                                                                        else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot + 1].Index == (byte)S_Events.EventType.EvCondition)
                                                                            buffer.WriteInt32(2);
                                                                        else
                                                                            buffer.WriteInt32(0);
                                                                    }
                                                                    else
                                                                        buffer.WriteInt32(2);
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);
                                                                    buffer.Dispose();
                                                                    withBlock2.WaitingForResponse = 1;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvShowChoices:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SEventChat));
                                                                    buffer.WriteInt32(withBlock2.EventId);
                                                                    buffer.WriteInt32(withBlock2.PageId);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data5);
                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(ParseEventText(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text1))));

                                                                    S_General.AddDebug("Sent SMSG: SEventChat evShowChoices");

                                                                    if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text2)) > 0)
                                                                    {
                                                                        w = 1;
                                                                        if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text3)) > 0)
                                                                        {
                                                                            w = 2;
                                                                            if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text4)) > 0)
                                                                            {
                                                                                w = 3;
                                                                                if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text5)) > 0)
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
                                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(ParseEventText(i, Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text2)))));
                                                                                    break;
                                                                                }

                                                                            case 2:
                                                                                {
                                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(ParseEventText(i, Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text3)))));
                                                                                    break;
                                                                                }

                                                                            case 3:
                                                                                {
                                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(ParseEventText(i, Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text4)))));
                                                                                    break;
                                                                                }

                                                                            case 4:
                                                                                {
                                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(ParseEventText(i, Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text5)))));
                                                                                    break;
                                                                                }
                                                                        }
                                                                    }
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].CommandCount > withBlock2.CurSlot)
                                                                    {
                                                                        if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot + 1].Index == (byte)S_Events.EventType.EvShowText || modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot + 1].Index == (byte)S_Events.EventType.EvShowChoices)
                                                                            buffer.WriteInt32(1);
                                                                        else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot + 1].Index == (byte)S_Events.EventType.EvCondition)
                                                                            buffer.WriteInt32(2);
                                                                        else
                                                                            buffer.WriteInt32(0);
                                                                    }
                                                                    else
                                                                        buffer.WriteInt32(2);
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);
                                                                    buffer.Dispose();
                                                                    withBlock2.WaitingForResponse = 1;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvPlayerVar:
                                                                {
                                                                    switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2)
                                                                    {
                                                                        case 0:
                                                                            {
                                                                                modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1] = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3;
                                                                                break;
                                                                            }

                                                                        case 1:
                                                                            {
                                                                                modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1] = modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1] + modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3;
                                                                                break;
                                                                            }

                                                                        case 2:
                                                                            {
                                                                                modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1] = modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1] - modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3;
                                                                                break;
                                                                            }

                                                                        case 3:
                                                                            {
                                                                                modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1] = S_GameLogic.Random(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data4);
                                                                                break;
                                                                            }
                                                                    }

                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvPlayerSwitch:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 0)
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Switches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1] = 1;
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 1)
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Switches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1] = 0;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvSelfSwitch:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Globals == 1)
                                                                    {
                                                                        if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 0)
                                                                            modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1 + 1] = 1;
                                                                        else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 1)
                                                                            modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1 + 1] = 0;
                                                                    }
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 0)
                                                                        modTypes.TempPlayer[i].EventMap.EventPages[withBlock2.EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1 + 1] = 1;
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 1)
                                                                        modTypes.TempPlayer[i].EventMap.EventPages[withBlock2.EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1 + 1] = 0;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvCondition:
                                                                {
                                                                    switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Condition)
                                                                    {
                                                                        case 0:
                                                                            {
                                                                                switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data2)
                                                                                {
                                                                                    case 0:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1] == modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data3)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 1:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1] >= modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data3)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 2:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1] <= modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data3)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 3:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1] > modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data3)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 4:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1] < modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data3)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 5:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Variables[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1] != modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data3)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 1:
                                                                            {
                                                                                switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data2)
                                                                                {
                                                                                    case 0:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Switches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1] == 1)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 1:
                                                                                        {
                                                                                            if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Switches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1] == 0)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 2:
                                                                            {
                                                                                if (S_Players.HasItem(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1) >= modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data2)
                                                                                {
                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                    withBlock2.CurSlot = 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                    withBlock2.CurSlot = 1;
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 3:
                                                                            {
                                                                                if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Classes == modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1)
                                                                                {
                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                    withBlock2.CurSlot = 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                    withBlock2.CurSlot = 1;
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 4:
                                                                            {
                                                                                if (S_Players.HasSkill(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1) == true)
                                                                                {
                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                    withBlock2.CurSlot = 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                    withBlock2.CurSlot = 1;
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 5:
                                                                            {
                                                                                switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data2)
                                                                                {
                                                                                    case 0:
                                                                                        {
                                                                                            if (S_Players.GetPlayerLevel(i) == modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 1:
                                                                                        {
                                                                                            if (S_Players.GetPlayerLevel(i) >= modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 2:
                                                                                        {
                                                                                            if (S_Players.GetPlayerLevel(i) <= modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 3:
                                                                                        {
                                                                                            if (S_Players.GetPlayerLevel(i) > modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 4:
                                                                                        {
                                                                                            if (S_Players.GetPlayerLevel(i) < modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }

                                                                                    case 5:
                                                                                        {
                                                                                            if (S_Players.GetPlayerLevel(i) != modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1)
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                withBlock2.CurSlot = 1;
                                                                                            }

                                                                                            break;
                                                                                        }
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 6:
                                                                            {
                                                                                if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Globals == 1)
                                                                                {
                                                                                    switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data2)
                                                                                    {
                                                                                        case 0 // Self Switch is true
                                                                                       :
                                                                                            {
                                                                                                if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1 + 1] == 1)
                                                                                                {
                                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                    withBlock2.CurSlot = 1;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                    withBlock2.CurSlot = 1;
                                                                                                }

                                                                                                break;
                                                                                            }

                                                                                        case 1  // self switch is false
                                                                                 :
                                                                                            {
                                                                                                if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1 + 1] == 0)
                                                                                                {
                                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                    withBlock2.CurSlot = 1;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                    withBlock2.CurSlot = 1;
                                                                                                }

                                                                                                break;
                                                                                            }
                                                                                    }
                                                                                }
                                                                                else
                                                                                    switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data2)
                                                                                    {
                                                                                        case 0 // Self Switch is true
                                                                                       :
                                                                                            {
                                                                                                if (modTypes.TempPlayer[i].EventMap.EventPages[withBlock2.EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1 + 1] == 1)
                                                                                                {
                                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                    withBlock2.CurSlot = 1;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                    withBlock2.CurSlot = 1;
                                                                                                }

                                                                                                break;
                                                                                            }

                                                                                        case 1  // self switch is false
                                                                                 :
                                                                                            {
                                                                                                if (modTypes.TempPlayer[i].EventMap.EventPages[withBlock2.EventId].SelfSwitches[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1 + 1] == 0)
                                                                                                {
                                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                    withBlock2.CurSlot = 1;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                    withBlock2.CurSlot = 1;
                                                                                                }

                                                                                                break;
                                                                                            }
                                                                                    }

                                                                                break;
                                                                            }

                                                                        case 7:
                                                                            {
                                                                                if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1 > 0 && modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1 <= S_Quest.MAX_QUESTS)
                                                                                {
                                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data2 == 0)
                                                                                    {
                                                                                        switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data3)
                                                                                        {
                                                                                            case 0:
                                                                                                {
                                                                                                    if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1].Status == 0)
                                                                                                    {
                                                                                                        withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                        withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                        withBlock2.CurSlot = 1;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                        withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                        withBlock2.CurSlot = 1;
                                                                                                    }

                                                                                                    break;
                                                                                                }

                                                                                            case 1:
                                                                                                {
                                                                                                    if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1].Status == 1)
                                                                                                    {
                                                                                                        withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                        withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                        withBlock2.CurSlot = 1;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                        withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                        withBlock2.CurSlot = 1;
                                                                                                    }

                                                                                                    break;
                                                                                                }

                                                                                            case 2:
                                                                                                {
                                                                                                    if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1].Status == 2 || modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1].Status == 3)
                                                                                                    {
                                                                                                        withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                        withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                        withBlock2.CurSlot = 1;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                        withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                        withBlock2.CurSlot = 1;
                                                                                                    }

                                                                                                    break;
                                                                                                }

                                                                                            case 3:
                                                                                                {
                                                                                                    if (S_Quest.CanStartQuest(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1))
                                                                                                    {
                                                                                                        withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                        withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                        withBlock2.CurSlot = 1;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                        withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                        withBlock2.CurSlot = 1;
                                                                                                    }

                                                                                                    break;
                                                                                                }

                                                                                            case 4:
                                                                                                {
                                                                                                    if (S_Quest.CanEndQuest(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1))
                                                                                                    {
                                                                                                        withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                        withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                                        withBlock2.CurSlot = 1;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                                        withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                                        withBlock2.CurSlot = 1;
                                                                                                    }

                                                                                                    break;
                                                                                                }
                                                                                        }
                                                                                    }
                                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data2 == 1)
                                                                                    {
                                                                                        if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1].ActualTask == modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data3)
                                                                                        {
                                                                                            withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                            withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                            withBlock2.CurSlot = 1;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                            withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                            withBlock2.CurSlot = 1;
                                                                                        }
                                                                                    }
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 8:
                                                                            {
                                                                                if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Sex == modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1)
                                                                                {
                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                    withBlock2.CurSlot = 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                    withBlock2.CurSlot = 1;
                                                                                }

                                                                                break;
                                                                            }

                                                                        case 9:
                                                                            {
                                                                                if ((int)Time.Instance.TimeOfDay == modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.Data1)
                                                                                {
                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.CommandList;
                                                                                    withBlock2.CurSlot = 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    withBlock2.ListLeftOff[withBlock2.CurList] = withBlock2.CurSlot;
                                                                                    withBlock2.CurList = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].ConditionalBranch.ElseCommandList;
                                                                                    withBlock2.CurSlot = 1;
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
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 0)
                                                                    {
                                                                        if (S_Players.HasItem(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1) > 0)
                                                                        {
                                                                            S_Players.SetPlayerInvItemValue(i, S_Players.FindItemSlot(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1), modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3);
                                                                            S_Quest.CheckTasks(i, (int)Enums.QuestType.Fetch, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                            S_Quest.CheckTasks(i, (int)Enums.QuestType.Give, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                        }
                                                                    }
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 1)
                                                                    {
                                                                        S_Players.GiveInvItem(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3, true);
                                                                        S_Quest.CheckTasks(i, (int)Enums.QuestType.Fetch, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                        S_Quest.CheckTasks(i, (int)Enums.QuestType.Give, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                    }
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 2)
                                                                    {
                                                                        int itemAmount;
                                                                        itemAmount = S_Players.HasItem(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                        // Check Amount
                                                                        if (itemAmount >= modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3)
                                                                        {
                                                                            S_Players.TakeInvItem(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3);
                                                                            S_Quest.CheckTasks(i, (int)Enums.QuestType.Fetch, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                            S_Quest.CheckTasks(i, (int)Enums.QuestType.Give, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
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
                                                                    S_Players.SetPlayerLevel(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                    S_Players.SetPlayerExp(i, 0);
                                                                    S_NetworkSend.SendExp(i);
                                                                    S_NetworkSend.SendPlayerData(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvChangeSkills:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 0)
                                                                    {
                                                                        if (S_Players.FindOpenSkillSlot(i) > 0)
                                                                        {
                                                                            if (S_Players.HasSkill(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1) == false)
                                                                                S_Players.SetPlayerSkill(i, S_Players.FindOpenSkillSlot(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                            else
                                                                            {
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                        }
                                                                    }
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 1)
                                                                    {
                                                                        if (S_Players.HasSkill(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1) == true)
                                                                        {
                                                                            for (p = 1; p <= Constants.MAX_PLAYER_SKILLS; p++)
                                                                            {
                                                                                if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Skill[p] == modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1)
                                                                                    S_Players.SetPlayerSkill(i, p, 0);
                                                                            }
                                                                        }
                                                                    }
                                                                    S_NetworkSend.SendPlayerSkills(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvChangeClass:
                                                                {
                                                                    modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Classes = (byte)modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1;
                                                                    S_NetworkSend.SendPlayerData(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvChangeSprite:
                                                                {
                                                                    S_Players.SetPlayerSprite(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                    S_NetworkSend.SendPlayerData(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvChangeSex:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1 == 0)
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Sex = (byte)Enums.SexType.Male;
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1 == 1)
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Sex = (byte)Enums.SexType.Female;
                                                                    S_NetworkSend.SendPlayerData(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvChangePk:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1 == 0)
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Pk = 0;
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1 == 1)
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Pk = 1;
                                                                    S_NetworkSend.SendPlayerData(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvWarpPlayer:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data4 == 0)
                                                                        S_Players.PlayerWarp(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3);
                                                                    else
                                                                    {
                                                                        modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].Dir = (byte)(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data4 - 1);
                                                                        S_Players.PlayerWarp(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3);
                                                                    }

                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvSetMoveRoute:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1 <= modTypes.Map[S_Players.GetPlayerMap(i)].EventCount)
                                                                    {
                                                                        if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].Globals == 1)
                                                                        {
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].MoveType = 2;
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].IgnoreIfCannotMove = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2;
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].RepeatMoveRoute = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3;
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].MoveRouteCount = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].MoveRouteCount;
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].MoveRoute = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].MoveRoute;
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].MoveRouteStep = 0;
                                                                            S_Events.TempEventMap[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].MoveRouteComplete = 0;
                                                                        }
                                                                        else
                                                                        {
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].MoveType = 2;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].IgnoreIfCannotMove = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].RepeatMoveRoute = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].MoveRouteCount = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].MoveRouteCount;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].MoveRoute = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].MoveRoute;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].MoveRouteStep = 0;
                                                                            modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].MoveRouteComplete = 0;
                                                                        }
                                                                    }

                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvPlayAnimation:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 0)
                                                                        S_Animations.SendAnimation(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, S_Players.GetPlayerX(i), S_Players.GetPlayerY(i), (byte)Enums.TargetType.Player, i);
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 1)
                                                                    {
                                                                        if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Globals == 1)
                                                                            S_Animations.SendAnimation(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].X, modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3].Y);
                                                                        else
                                                                            S_Animations.SendAnimation(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3].X, modTypes.TempPlayer[i].EventMap.EventPages[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3].Y, 0, 0);
                                                                    }
                                                                    else if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2 == 2)
                                                                        S_Animations.SendAnimation(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data4, 0, 0);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvCustomScript:
                                                                {
                                                                    // Runs Through Cases for a script
                                                                    S_Events.CustomScript(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, S_Players.GetPlayerMap(i), withBlock2.EventId);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvPlayBgm:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SPlayBGM));
                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text1)));
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SPlayBGM", S_Constants.PACKET_LOG);
                                                                    Console.WriteLine("Sent SMSG: SPlayBGM");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvFadeoutBgm:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SFadeoutBGM));
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SFadeoutBGM", S_Constants.PACKET_LOG);
                                                                    Console.WriteLine("Sent SMSG: SFadeoutBGM");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvPlaySound:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SPlaySound));
                                                                    buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text1)));
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SPlaySound", S_Constants.PACKET_LOG);
                                                                    Console.WriteLine("Sent SMSG: SPlaySound");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvStopSound:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SStopSound));
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SStopSound", S_Constants.PACKET_LOG);
                                                                    Console.WriteLine("Sent SMSG: SStopSound");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvSetAccess:
                                                                {
                                                                    modTypes.Player[i].Access = (byte)modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1;
                                                                    S_NetworkSend.SendPlayerData(i);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvOpenShop:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1 > 0)
                                                                    {
                                                                        if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Shop[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].Name)) > 0)
                                                                        {
                                                                            S_NetworkSend.SendOpenShop(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                            modTypes.TempPlayer[i].InShop = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1; // stops movement and the like
                                                                            withBlock2.WaitingForResponse = 2;
                                                                        }
                                                                    }

                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvOpenBank:
                                                                {
                                                                    S_NetworkSend.SendBank(i);
                                                                    modTypes.TempPlayer[i].InBank = true;
                                                                    withBlock2.WaitingForResponse = 3;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvGiveExp:
                                                                {
                                                                    S_Events.GivePlayerExp(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvShowChatBubble:
                                                                {
                                                                    switch (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1)
                                                                    {
                                                                        case (int)Enums.TargetType.Player:
                                                                            {
                                                                                S_NetworkSend.SendChatBubble(S_Players.GetPlayerMap(i), i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text1, (int)Enums.ColorType.Brown);
                                                                                break;
                                                                            }

                                                                        case (int)Enums.TargetType.Npc:
                                                                            {
                                                                                S_NetworkSend.SendChatBubble(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text1, (int)Enums.ColorType.Brown);
                                                                                break;
                                                                            }

                                                                        case (int)Enums.TargetType.Event:
                                                                            {
                                                                                S_NetworkSend.SendChatBubble(S_Players.GetPlayerMap(i), modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text1, (int)Enums.ColorType.Brown);
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
                                                                    FindEventLabel(Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Text1), S_Players.GetPlayerMap(i), withBlock2.EventId, withBlock2.PageId, ref withBlock2.CurSlot, ref withBlock2.CurList, ref withBlock2.ListLeftOff);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvSpawnNpc:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Npc[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1] > 0)
                                                                        S_Npc.SpawnNpc(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, S_Players.GetPlayerMap(i));
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
                                                                    S_Events.SendSpecialEffect(i, S_Events.EffectTypeFog, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvSetWeather:
                                                                {
                                                                    S_Events.SendSpecialEffect(i, S_Events.EffectTypeWeather, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvSetTint:
                                                                {
                                                                    S_Events.SendSpecialEffect(i, S_Events.EffectTypeTint, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data4);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvWait:
                                                                {
                                                                    withBlock2.ActionTimer = S_General.GetTimeMs() + modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1;
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvOpenMail:
                                                                {
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvBeginQuest:
                                                                {
                                                                    if (S_Quest.CanStartQuest(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1))
                                                                        S_Quest.QuestMessage(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, S_Quest.Quest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].Chat[1], modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvEndQuest:
                                                                {
                                                                    if (S_Quest.CanEndQuest(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1))
                                                                        S_Quest.EndQuest(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1);
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvQuestTask:
                                                                {
                                                                    if (S_Quest.QuestInProgress(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1))
                                                                    {
                                                                        if (modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].ActualTask == modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2)
                                                                        {
                                                                            if (S_Quest.Quest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].Task[modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].ActualTask].TaskType == (int)Enums.QuestType.TalkEvent || S_Quest.Quest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].Task[modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].ActualTask].TaskType == (int)Enums.QuestType.Fetch)
                                                                                S_Quest.CheckTask(i, modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1, S_Quest.Quest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].Task[modTypes.Player[i].Character[modTypes.TempPlayer[i].CurChar].PlayerQuest[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].ActualTask].TaskType, -1);
                                                                        }
                                                                    }

                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvShowPicture:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SPic));
                                                                    buffer.WriteInt32(0);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1 + 1);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data2);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data3);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data4);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data5);
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SPic evShowPicture", S_Constants.PACKET_LOG);
                                                                    Console.WriteLine("Sent SMSG: SPic evShowPicture");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvHidePicture:
                                                                {
                                                                    buffer = new ByteStream(4);
                                                                    buffer.WriteInt32(Convert.ToInt32(Packets.ServerPackets.SPic));
                                                                    buffer.WriteInt32(1);
                                                                    buffer.WriteInt32(modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1 + 1);
                                                                    S_NetworkConfig.Socket.SendDataTo(i, buffer.Data, buffer.Head);

                                                                    modDatabase.Addlog("Sent SMSG: SPic evHidePicture", S_Constants.PACKET_LOG);
                                                                    Console.WriteLine("Sent SMSG: SPic evHidePicture");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }

                                                            case (int)S_Events.EventType.EvWaitMovement:
                                                                {
                                                                    if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1 <= modTypes.Map[S_Players.GetPlayerMap(i)].EventCount)
                                                                    {
                                                                        if (modTypes.Map[S_Players.GetPlayerMap(i)].Events[modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1].Globals == 1)
                                                                        {
                                                                            withBlock2.WaitingForResponse = 4;
                                                                            withBlock2.EventMovingId = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1;
                                                                            withBlock2.EventMovingType = 1;
                                                                        }
                                                                        else
                                                                        {
                                                                            withBlock2.WaitingForResponse = 4;
                                                                            withBlock2.EventMovingId = modTypes.Map[S_Players.GetPlayerMap(i)].Events[withBlock2.EventId].Pages[withBlock2.PageId].CommandList[withBlock2.CurList].Commands[withBlock2.CurSlot].Data1;
                                                                            withBlock2.EventMovingType = 0;
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
                                                                    Console.WriteLine("Sent SMSG: SHoldPlayer");

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
                                                                    Console.WriteLine("Sent SMSG: SHoldPlayer Release");

                                                                    buffer.Dispose();
                                                                    break;
                                                                }
                                                        }
                                                    }
                                                }
                                                if (endprocess == false)
                                                    withBlock2.CurSlot = withBlock2.CurSlot + 1;
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
                    z = modTypes.Player[index].Character[modTypes.TempPlayer[i].CurChar].Variables[Convert.ToInt32(parsestring)];
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
                            Application.DoEvents();
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
                    Application.DoEvents();
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
                            var withBlock = modTypes.Map[mapNum].Events[i].Pages[z];
                            spawncurrentevent = true;

                            if (withBlock.ChkVariable == 1)
                            {
                                switch (withBlock.VariableCompare)
                                {
                                    case 0:
                                        {
                                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Variables[withBlock.Variableindex] != withBlock.VariableCondition)
                                                spawncurrentevent = false;
                                            break;
                                        }

                                    case 1:
                                        {
                                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Variables[withBlock.Variableindex] < withBlock.VariableCondition)
                                                spawncurrentevent = false;
                                            break;
                                        }

                                    case 2:
                                        {
                                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Variables[withBlock.Variableindex] > withBlock.VariableCondition)
                                                spawncurrentevent = false;
                                            break;
                                        }

                                    case 3:
                                        {
                                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Variables[withBlock.Variableindex] <= withBlock.VariableCondition)
                                                spawncurrentevent = false;
                                            break;
                                        }

                                    case 4:
                                        {
                                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Variables[withBlock.Variableindex] >= withBlock.VariableCondition)
                                                spawncurrentevent = false;
                                            break;
                                        }

                                    case 5:
                                        {
                                            if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Variables[withBlock.Variableindex] == withBlock.VariableCondition)
                                                spawncurrentevent = false;
                                            break;
                                        }
                                }
                            }

                            // we are assuming the event will spawn, and are looking for ways to stop it
                            if (withBlock.ChkSwitch == 1)
                            {
                                if (withBlock.SwitchCompare == 1)
                                {
                                    if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Switches[withBlock.Switchindex] == 0)
                                        spawncurrentevent = false;
                                }
                                else if (modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].Switches[withBlock.Switchindex] == 1)
                                    spawncurrentevent = false;
                            }

                            if (withBlock.ChkHasItem == 1)
                            {
                                if (S_Players.HasItem(index, withBlock.HasItemindex) == 0)
                                    spawncurrentevent = false;
                            }

                            if (withBlock.ChkSelfSwitch == 1)
                            {
                                if (withBlock.SelfSwitchCompare == 0)
                                    compare = 1;
                                else
                                    compare = 0;
                                if (modTypes.Map[mapNum].Events[i].Globals == 1)
                                {
                                    if (modTypes.Map[mapNum].Events[i].SelfSwitches[withBlock.SelfSwitchindex] != compare)
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
                                    var withBlock1 = modTypes.TempPlayer[index].EventMap.EventPages[modTypes.TempPlayer[index].EventMap.CurrentEvents];
                                    if (modTypes.Map[mapNum].Events[i].Pages[z].GraphicType == 1)
                                    {
                                        switch (modTypes.Map[mapNum].Events[i].Pages[z].GraphicY)
                                        {
                                            case 0:
                                                {
                                                    withBlock1.Dir = (int)Enums.DirectionType.Down;
                                                    break;
                                                }

                                            case 1:
                                                {
                                                    withBlock1.Dir = (int)Enums.DirectionType.Left;
                                                    break;
                                                }

                                            case 2:
                                                {
                                                    withBlock1.Dir = (int)Enums.DirectionType.Right;
                                                    break;
                                                }

                                            case 3:
                                                {
                                                    withBlock1.Dir = (int)Enums.DirectionType.Up;
                                                    break;
                                                }
                                        }
                                    }
                                    else
                                        withBlock1.Dir = 0;
                                    withBlock1.GraphicNum = modTypes.Map[mapNum].Events[i].Pages[z].Graphic;
                                    withBlock1.GraphicType = modTypes.Map[mapNum].Events[i].Pages[z].GraphicType;
                                    withBlock1.GraphicX = modTypes.Map[mapNum].Events[i].Pages[z].GraphicX;
                                    withBlock1.GraphicY = modTypes.Map[mapNum].Events[i].Pages[z].GraphicY;
                                    withBlock1.GraphicX2 = modTypes.Map[mapNum].Events[i].Pages[z].GraphicX2;
                                    withBlock1.GraphicY2 = modTypes.Map[mapNum].Events[i].Pages[z].GraphicY2;
                                    switch (modTypes.Map[mapNum].Events[i].Pages[z].MoveSpeed)
                                    {
                                        case 0:
                                            {
                                                withBlock1.MovementSpeed = 2;
                                                break;
                                            }

                                        case 1:
                                            {
                                                withBlock1.MovementSpeed = 3;
                                                break;
                                            }

                                        case 2:
                                            {
                                                withBlock1.MovementSpeed = 4;
                                                break;
                                            }

                                        case 3:
                                            {
                                                withBlock1.MovementSpeed = 6;
                                                break;
                                            }

                                        case 4:
                                            {
                                                withBlock1.MovementSpeed = 12;
                                                break;
                                            }

                                        case 5:
                                            {
                                                withBlock1.MovementSpeed = 24;
                                                break;
                                            }
                                    }
                                    if (Convert.ToBoolean(modTypes.Map[mapNum].Events[i].Globals))
                                    {
                                        withBlock1.X = S_Events.TempEventMap[mapNum].Events[i].X;
                                        withBlock1.Y = S_Events.TempEventMap[mapNum].Events[i].Y;
                                        withBlock1.Dir = S_Events.TempEventMap[mapNum].Events[i].Dir;
                                        withBlock1.MoveRouteStep = S_Events.TempEventMap[mapNum].Events[i].MoveRouteStep;
                                    }
                                    else
                                    {
                                        withBlock1.X = modTypes.Map[mapNum].Events[i].X;
                                        withBlock1.Y = modTypes.Map[mapNum].Events[i].Y;
                                        withBlock1.MoveRouteStep = 0;
                                    }
                                    withBlock1.Position = modTypes.Map[mapNum].Events[i].Pages[z].Position;
                                    withBlock1.EventId = i;
                                    withBlock1.PageId = z;
                                    if (spawncurrentevent == true)
                                        withBlock1.Visible = 1;
                                    else
                                        withBlock1.Visible = 0;

                                    withBlock1.MoveType = modTypes.Map[mapNum].Events[i].Pages[z].MoveType;
                                    if (withBlock1.MoveType == 2)
                                    {
                                        withBlock1.MoveRouteCount = modTypes.Map[mapNum].Events[i].Pages[z].MoveRouteCount;
                                        withBlock1.MoveRoute = new MoveRouteStruct[modTypes.Map[mapNum].Events[i].Pages[z].MoveRouteCount + 1];
                                        if (modTypes.Map[mapNum].Events[i].Pages[z].MoveRouteCount > 0)
                                        {
                                            var loopTo1 = modTypes.Map[mapNum].Events[i].Pages[z].MoveRouteCount;
                                            for (p = 0; p <= loopTo1; p++)
                                                withBlock1.MoveRoute[p] = modTypes.Map[mapNum].Events[i].Pages[z].MoveRoute[p];
                                        }
                                        withBlock1.MoveRouteComplete = 0;
                                    }
                                    else
                                        withBlock1.MoveRouteComplete = 1;

                                    withBlock1.RepeatMoveRoute = modTypes.Map[mapNum].Events[i].Pages[z].RepeatMoveRoute;
                                    withBlock1.IgnoreIfCannotMove = modTypes.Map[mapNum].Events[i].Pages[z].IgnoreMoveRoute;

                                    withBlock1.MoveFreq = modTypes.Map[mapNum].Events[i].Pages[z].MoveFreq;
                                    withBlock1.MoveSpeed = modTypes.Map[mapNum].Events[i].Pages[z].MoveSpeed;

                                    withBlock1.WalkingAnim = modTypes.Map[mapNum].Events[i].Pages[z].WalkAnim;
                                    withBlock1.WalkThrough = modTypes.Map[mapNum].Events[i].Pages[z].WalkThrough;
                                    withBlock1.ShowName = modTypes.Map[mapNum].Events[i].Pages[z].ShowName;
                                    withBlock1.FixedDir = modTypes.Map[mapNum].Events[i].Pages[z].DirFix;
                                    withBlock1.QuestNum = modTypes.Map[mapNum].Events[i].Pages[z].QuestNum;
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
                        var withBlock2 = modTypes.TempPlayer[index].EventMap.EventPages[i];
                        buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(modTypes.Map[S_Players.GetPlayerMap(index)].Events[modTypes.TempPlayer[index].EventMap.EventPages[i].EventId].Name)));
                        buffer.WriteInt32(withBlock2.Dir);
                        buffer.WriteInt32(withBlock2.GraphicNum);
                        buffer.WriteInt32(withBlock2.GraphicType);
                        buffer.WriteInt32(withBlock2.GraphicX);
                        buffer.WriteInt32(withBlock2.GraphicX2);
                        buffer.WriteInt32(withBlock2.GraphicY);
                        buffer.WriteInt32(withBlock2.GraphicY2);
                        buffer.WriteInt32(withBlock2.MovementSpeed);
                        buffer.WriteInt32(withBlock2.X);
                        buffer.WriteInt32(withBlock2.Y);
                        buffer.WriteInt32(withBlock2.Position);
                        buffer.WriteInt32(withBlock2.Visible);
                        buffer.WriteInt32(modTypes.Map[mapNum].Events[withBlock2.EventId].Pages[withBlock2.PageId].WalkAnim);
                        buffer.WriteInt32(modTypes.Map[mapNum].Events[withBlock2.EventId].Pages[withBlock2.PageId].DirFix);
                        buffer.WriteInt32(modTypes.Map[mapNum].Events[withBlock2.EventId].Pages[withBlock2.PageId].WalkThrough);
                        buffer.WriteInt32(modTypes.Map[mapNum].Events[withBlock2.EventId].Pages[withBlock2.PageId].ShowName);
                        buffer.WriteInt32(modTypes.Map[mapNum].Events[withBlock2.EventId].Pages[withBlock2.PageId].QuestNum);
                    }
                    S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

                    S_General.AddDebug("Sent SMSG: SSpawnEvent For Player");

                    buffer.Dispose();
                }
            }
        }
    }
}
