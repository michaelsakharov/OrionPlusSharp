
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using Asfw.Network;
using System.Windows.Forms;
using Engine;


namespace Engine
{
    internal sealed class C_NetworkConfig
    {
        internal static Client Socket;

        internal static void InitNetwork()
        {
            if (Socket != null)
            {
                return;
            }
            Socket = new Client((int)Packets.ServerPackets.COUNT, 4096);
            Socket.ConnectionLost += Socket_ConnectionLost;
            Socket.CrashReport += Socket_CrashReport;
            C_NetworkReceive.PacketRouter();
        }

        internal static void Connect()
        {
            Socket.Connect(C_Types.Options.Ip, C_Types.Options.Port);
        }

        internal static void DestroyNetwork()
        {
            Socket.Dispose();
        }

        #region  Events

        private static void Socket_ConnectionSuccess()
        {

        }

        private static void Socket_ConnectionFailed()
        {

        }

        private static void Socket_ConnectionLost()
        {
            MessageBox.Show("Connection was terminated! Returning to Main Menu");
            DestroyNetwork();
            C_General.DestroyGame(true);
        }

        private static void Socket_CrashReport(string err)
        {
            MessageBox.Show("There was a network error -> Report: " + err);
            DestroyNetwork();
            C_General.DestroyGame();
        }
        #endregion
    }
}
