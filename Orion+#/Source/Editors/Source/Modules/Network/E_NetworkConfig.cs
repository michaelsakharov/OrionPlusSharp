using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using Asfw.Network;

namespace Engine
{
    internal static class E_NetworkConfig
    {
        private static Client _Socket;

        internal static Client Socket
        {

            get
            {
                return _Socket;
            }


            set
            {
                if (_Socket != null)
                {
                    _Socket.ConnectionSuccess -= Socket_ConnectionSuccess;
                    _Socket.ConnectionFailed -= Socket_ConnectionFailed;
                    _Socket.ConnectionLost -= Socket_ConnectionLost;
                    _Socket.CrashReport -= Socket_CrashReport;
                }

                _Socket = value;
                if (_Socket != null)
                {
                    _Socket.ConnectionSuccess += Socket_ConnectionSuccess;
                    _Socket.ConnectionFailed += Socket_ConnectionFailed;
                    _Socket.ConnectionLost += Socket_ConnectionLost;
                    _Socket.CrashReport += Socket_CrashReport;
                }
            }
        }

        internal static void InitNetwork()
        {
            if (!(Socket == null))
                return;
            Socket = new Client((int)Packets.ServerPackets.COUNT, 4096);
            E_NetworkReceive.PacketRouter();
        }

        internal static void Connect()
        {
            Socket.Connect(E_Types.Options.IP, E_Types.Options.Port);
        }

        internal static void DestroyNetwork()
        {
            // Calling a disconnect is not necessary when using destroy network as
            // Dispose already calls it and cleans up the memory internally.
            // But if our Socket is alive, lets try to send one last thing to the server
            if (Socket != null && Socket.IsConnected)
            {
                E_NetworkSend.SendLeaveGame();
            }
            Socket.Dispose();
        }


        private static void Socket_ConnectionSuccess()
        {
        }

        private static void Socket_ConnectionFailed()
        {
        }

        private static void Socket_ConnectionLost()
        {
            Interaction.MsgBox("Connection was terminated!");
            DestroyNetwork();
            E_Loop.CloseEditor();
        }

        private static void Socket_CrashReport(string err)
        {
            if (!E_Globals.GameDestroyed)
            {
                Interaction.MsgBox("There was a network error -> Report: " + err);
            }
            DestroyNetwork();
            E_Loop.CloseEditor();
        }
    }
}
