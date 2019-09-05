using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Net;
using ASFW.Network;

namespace Engine
{
    internal static class S_NetworkConfig
    {
        private static Server _Socket;

        internal static Server Socket
        {
            get
            {
                return _Socket;
            }
            
            set
            {
                if (_Socket != null)
                {
                    _Socket.ConnectionReceived -= Socket_ConnectionReceived;
                    _Socket.ConnectionLost -= Socket_ConnectionLost;
                    _Socket.CrashReport -= Socket_CrashReport;
                    _Socket.TrafficReceived -= Socket_TrafficReceived;
                    _Socket.PacketReceived -= Socket_PacketReceived;
                }

                _Socket = value;
                if (_Socket != null)
                {
                    _Socket.ConnectionReceived += Socket_ConnectionReceived;
                    _Socket.ConnectionLost += Socket_ConnectionLost;
                    _Socket.CrashReport += Socket_CrashReport;
                    _Socket.TrafficReceived += Socket_TrafficReceived;
                    _Socket.PacketReceived += Socket_PacketReceived;
                }
            }
        }

        internal static void InitNetwork()
        {
            if (!(Socket == null))
                return;
            // Establish some Rulez
            Socket = new Server((int)Packets.EditorPackets.Count, Constants.MAX_PLAYERS)
            {
                BufferLimit = 2048000,
                PacketAcceptLimit = 100,
                PacketDisconnectCount = 150 // If the other thing was even remotely reasonable, this is DEFINITELY spam count!
            };
            // END THE ESTABLISHMENT! WOOH ANARCHY! ~SpiceyWolf
            // And this children is why we dont give Wolves Spicy food. ~Wolf

            S_NetworkReceive.PacketRouter(); // Need them packet ids boah!
        }

        internal static void DestroyNetwork()
        {
            Socket.Dispose();
        }

        internal static string GetIP()
        {
            var request = HttpWebRequest.Create(new Uri("http://ascensiongamedev.com/resources/myip.php"));
            request.Method = WebRequestMethods.Http.Get;

            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(request.GetResponse().GetResponseStream());
                return reader.ReadToEnd();
            }
            catch (Exception e)
            {
                return "127.0.0.1";
            }
        }

        public static bool IsLoggedIn(int index)
        {
            return Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Login)) > 0;
        }

        public static bool IsPlaying(int index)
        {
            return modTypes.TempPlayer[index].InGame;
        }

        public static bool IsMultiAccounts(string Login)
        {
            var loopTo = S_GameLogic.GetPlayersOnline();
            // Lol this was broke before ~ SpiceyWolf
            for (int i = 1; i <= loopTo; i++)
            {
                if (modTypes.Player[i].Login.Trim().ToLower() == Login.Trim().ToLower())
                    return true;
            }
            return false;
        }

        internal static void SendDataToAll(ref byte[] data, int head)
        {
            var loopTo = S_GameLogic.GetPlayersOnline();
            for (int i = 1; i <= loopTo; i++)
            {
                if (IsPlaying(i))
                    Socket.SendDataTo(i, data, head);
            }
        }

        public static void SendDataToAllBut(int index, ref byte[] data, int head)
        {
            var loopTo = S_GameLogic.GetPlayersOnline();
            for (int i = 1; i <= loopTo; i++)
            {
                if (IsPlaying(i) && i != index)
                    Socket.SendDataTo(i, data, head);
            }
        }

        public static void SendDataToMapBut(int index, int mapNum, ref byte[] data, int head)
        {
            var loopTo = S_GameLogic.GetPlayersOnline();
            for (int i = 1; i <= loopTo; i++)
            {
                if (IsPlaying(i) && S_Players.GetPlayerMap(i) == mapNum && i != index)
                    Socket.SendDataTo(i, data, head);
            }
        }

        public static void SendDataToMap(int mapNum, ref byte[] data, int head)
        {
            int i;
            var loopTo = S_GameLogic.GetPlayersOnline();
            for (i = 1; i <= loopTo; i++)
            {
                if (IsPlaying(i))
                {
                    if (S_Players.GetPlayerMap(i) == mapNum)
                        Socket.SendDataTo(i, data, head);
                }
            }
        }


        internal static void Socket_ConnectionReceived(int index)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Connection received on index[" + index + "] - IP[" + Socket.ClientIp(index) + "]");
            Console.ResetColor();
            S_NetworkSend.SendKeyPair(index);
            S_NetworkSend.SendNews(index);
        }

        internal static void Socket_ConnectionLost(int index)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Connection lost on index[" + index + "] - WAS IN GAME: " + modTypes.TempPlayer[index].InGame);
            Console.ResetColor();
            S_Players.LeftGame(index);
        }

        internal static void Socket_CrashReport(int index, string err)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            if (S_Globals.DebugTxt == true)
                Console.WriteLine("There was a network error -> Index[" + index + "]");
            Console.ResetColor();
            Console.WriteLine("Report: " + err);
            S_Players.LeftGame(index);
        }

        private static void Socket_TrafficReceived(int size, ref byte[] data)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (S_Globals.DebugTxt == true)
                Console.WriteLine("Traffic Received : [Size: " + size + "]");
            Console.ResetColor();
        }

        private static void Socket_PacketReceived(int size, int header, ref byte[] data)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            if (S_Globals.DebugTxt == true)
                Console.WriteLine("Packet Received : [Size: " + size + "| Packet: " + ((Packets.ClientPackets)header).ToString() + "]");
            Console.ResetColor();
        }
    }
}
