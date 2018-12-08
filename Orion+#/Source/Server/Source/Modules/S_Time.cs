using System;
using ASFW;

namespace Engine
{
    internal static class modTime
    {
        public static void InitTime()
        {
            // Add handlers to time events
            Time.Instance.OnTimeChanged += HandleTimeChanged;
            Time.Instance.OnTimeOfDayChanged += HandleTimeOfDayChanged;
            Time.Instance.OnTimeSync += HandleTimeSync;

            // Prepare the time instance
            Time.Instance._Time = DateTime.Now;
            Time.Instance.GameSpeed = 1;
        }

        public static void HandleTimeChanged(ref Time source)
        {
            S_General.UpdateCaption();
        }

        public static void HandleTimeOfDayChanged(ref Time source)
        {
            SendTimeToAll();
            modDatabase.ClearAllMapNpcs();
            S_Npc.SpawnAllMapNpcs();
        }

        public static void HandleTimeSync(ref Time source)
        {
            SendGameClockToAll();
        }

        public static void SendGameClockTo(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SClock);
            buffer.WriteInt32((int)Time.Instance.GameSpeed);
            buffer.WriteBytes(BitConverter.GetBytes(Time.Instance._Time.Ticks));
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: SClock");

            S_General.AddDebug(" Player: " + S_Players.GetPlayerName(index) + " : " + " GameSpeed: " + Time.Instance.GameSpeed + " Instance Time Ticks: " + Time.Instance._Time.Ticks);

            buffer.Dispose();
        }

        public static void SendGameClockToAll()
        {
            int I;
            var loopTo = S_GameLogic.GetPlayersOnline();
            for (I = 1; I <= loopTo; I++)
            {
                if (S_NetworkConfig.IsPlaying(I))
                    SendGameClockTo(I);
            }
        }

        public static void SendTimeTo(int index)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.STime);
            buffer.WriteByte((byte)Time.Instance.TimeOfDay);
            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            S_General.AddDebug("Sent SMSG: STime");

            S_General.AddDebug(" Player: " + S_Players.GetPlayerName(index) + " : " + " Time Of Day: " + Time.Instance.TimeOfDay);

            buffer.Dispose();
        }

        public static void SendTimeToAll()
        {
            int I;
            var loopTo = S_GameLogic.GetPlayersOnline();
            for (I = 1; I <= loopTo; I++)
            {
                if (S_NetworkConfig.IsPlaying(I))
                    SendTimeTo(I);
            }
        }
    }
}
