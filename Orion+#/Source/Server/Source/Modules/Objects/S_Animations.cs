using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using ASFW;
using ASFW.IO.FileIO;
using static Engine.Types;

namespace Engine
{
    internal static class S_Animations
    {
        public static void SaveAnimations()
        {
            int i;

            for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
                SaveAnimation(i);
        }

        public static void SaveAnimation(int AnimationNum)
        {
            string filename;
            int x;

            filename = Path.Combine(Application.StartupPath, "data", "animations", string.Format("animation{0}.dat", AnimationNum));

            ByteStream writer = new ByteStream(100);

            writer.WriteString(Types.Animation[AnimationNum].Name);
            writer.WriteString(Types.Animation[AnimationNum].Sound);
            var loopTo = Information.UBound(Types.Animation[AnimationNum].Sprite);
            for (x = 0; x <= loopTo; x++)
                writer.WriteInt32(Types.Animation[AnimationNum].Sprite[x]);
            var loopTo1 = Information.UBound(Types.Animation[AnimationNum].Frames);
            for (x = 0; x <= loopTo1; x++)
                writer.WriteInt32(Types.Animation[AnimationNum].Frames[x]);
            var loopTo2 = Information.UBound(Types.Animation[AnimationNum].LoopCount);
            for (x = 0; x <= loopTo2; x++)
                writer.WriteInt32(Types.Animation[AnimationNum].LoopCount[x]);
            var loopTo3 = Information.UBound(Types.Animation[AnimationNum].LoopTime);
            for (x = 0; x <= loopTo3; x++)
                writer.WriteInt32(Types.Animation[AnimationNum].LoopTime[x]);

            BinaryFile.Save(filename, ref writer);
        }

        public static void LoadAnimations()
        {
            int i;

            CheckAnimations();

            for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
                LoadAnimation(i);
        }

        public static void LoadAnimation(int AnimationNum)
        {
            string filename;

            filename = Path.Combine(Application.StartupPath, "data", "animations", string.Format("animation{0}.dat", AnimationNum));
            ByteStream reader = new ByteStream();
            BinaryFile.Load(filename, ref reader);

            Types.Animation[AnimationNum].Name = reader.ReadString();
            Types.Animation[AnimationNum].Sound = reader.ReadString();
            var loopTo = Information.UBound(Types.Animation[AnimationNum].Sprite);
            for (var x = 0; x <= loopTo; x++)
                Types.Animation[AnimationNum].Sprite[x] = reader.ReadInt32();
            var loopTo1 = Information.UBound(Types.Animation[AnimationNum].Frames);
            for (int x = 0; x <= loopTo1; x++)
                Types.Animation[AnimationNum].Frames[x] = reader.ReadInt32();
            var loopTo2 = Information.UBound(Types.Animation[AnimationNum].LoopCount);
            for (int x = 0; x <= loopTo2; x++)
                Types.Animation[AnimationNum].LoopCount[x] = reader.ReadInt32();
            var loopTo3 = Information.UBound(Types.Animation[AnimationNum].LoopTime);
            for (int x = 0; x <= loopTo3; x++)
                Types.Animation[AnimationNum].LoopTime[x] = reader.ReadInt32();

            if (Types.Animation[AnimationNum].Name == null)
                Types.Animation[AnimationNum].Name = "";
        }

        public static void CheckAnimations()
        {
            int i;

            for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
            {
                if (!File.Exists(Path.Combine(Application.StartupPath, "data", "animations", string.Format("animation{0}.dat", i))))
                {
                    SaveAnimation(i);
                    Application.DoEvents();
                }
            }
        }

        public static void ClearAnimation(int index)
        {
            Types.Animation[index] = default(AnimationRec);
            Types.Animation[index].Name = "";
            Types.Animation[index].Sound = "";
            Types.Animation[index].Sprite = new int[2];
            Types.Animation[index].Frames = new int[2];
            Types.Animation[index].LoopCount = new int[2];
            Types.Animation[index].LoopTime = new int[2];
        }

        public static void ClearAnimations()
        {
            for (var i = 1; i <= Constants.MAX_ANIMATIONS; i++)
                ClearAnimation(i);
        }

        public static byte[] AnimationsData()
        {
            ByteStream buffer = new ByteStream(4);

            for (var i = 1; i <= Constants.MAX_ANIMATIONS; i++)
            {
                if (!(Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Animation[i].Name)) > 0))
                    continue;
                buffer.WriteBlock(AnimationData(i));
            }

            return buffer.ToArray();
        }

        public static byte[] AnimationData(int AnimationNum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32(AnimationNum);
            var loopTo = Information.UBound(Types.Animation[AnimationNum].Frames);
            for (var i = 0; i <= loopTo; i++)
                buffer.WriteInt32(Types.Animation[AnimationNum].Frames[i]);
            var loopTo1 = Information.UBound(Types.Animation[AnimationNum].LoopCount);
            for (int i = 0; i <= loopTo1; i++)
                buffer.WriteInt32(Types.Animation[AnimationNum].LoopCount[i]);
            var loopTo2 = Information.UBound(Types.Animation[AnimationNum].LoopTime);
            for (int i = 0; i <= loopTo2; i++)
                buffer.WriteInt32(Types.Animation[AnimationNum].LoopTime[i]);

            buffer.WriteString((Types.Animation[AnimationNum].Name));
            buffer.WriteString((Types.Animation[AnimationNum].Sound));
            var loopTo3 = Information.UBound(Types.Animation[AnimationNum].Sprite);
            for (var i = 0; i <= loopTo3; i++)
                buffer.WriteInt32(Types.Animation[AnimationNum].Sprite[i]);

            return buffer.ToArray();
        }



        public static void Packet_EditAnimation(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved EMSG: RequestEditAnimation");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (int)Enums.AdminType.Developer)
                return;

            var Buffer = new ByteStream(4);
            Buffer.WriteInt32((int)Packets.ServerPackets.SAnimationEditor);
            S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);
            Buffer.Dispose();
        }

        public static void Packet_SaveAnimation(int index, ref byte[] data)
        {
            int AnimNum;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved EMSG: SaveAnimation");

            AnimNum = buffer.ReadInt32();
            var loopTo = Information.UBound(Types.Animation[AnimNum].Frames);

            // Update the Animation
            for (var i = 0; i <= loopTo; i++)
                Types.Animation[AnimNum].Frames[i] = buffer.ReadInt32();
            var loopTo1 = Information.UBound(Types.Animation[AnimNum].LoopCount);
            for (int i = 0; i <= loopTo1; i++)
                Types.Animation[AnimNum].LoopCount[i] = buffer.ReadInt32();
            var loopTo2 = Information.UBound(Types.Animation[AnimNum].LoopTime);
            for (int i = 0; i <= loopTo2; i++)
                Types.Animation[AnimNum].LoopTime[i] = buffer.ReadInt32();

            Types.Animation[AnimNum].Name = buffer.ReadString();
            Types.Animation[AnimNum].Sound = buffer.ReadString();

            if (Types.Animation[AnimNum].Name == null)
                Types.Animation[AnimNum].Name = "";
            if (Types.Animation[AnimNum].Sound == null)
                Types.Animation[AnimNum].Sound = "";
            var loopTo3 = Information.UBound(Types.Animation[AnimNum].Sprite);
            for (var i = 0; i <= loopTo3; i++)
                Types.Animation[AnimNum].Sprite[i] = buffer.ReadInt32();

            buffer.Dispose();

            // Save it
            SaveAnimation(AnimNum);
            SendUpdateAnimationToAll(AnimNum);
            modDatabase.Addlog(S_Players.GetPlayerLogin(index) + " saved Animation #" + AnimNum + ".", S_Constants.ADMIN_LOG);
        }

        public static void Packet_RequestAnimations(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CRequestAnimations");

            SendAnimations(index);
        }



        public static void SendAnimation(int mapNum, int Anim, int X, int Y, byte LockType = 0, int Lockindex = 0)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SAnimation);
            buffer.WriteInt32(Anim);
            buffer.WriteInt32(X);
            buffer.WriteInt32(Y);
            buffer.WriteInt32(LockType);
            buffer.WriteInt32(Lockindex);

            S_General.AddDebug("Sent SMSG: SAnimation");

            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendAnimations(int index)
        {
            int i;

            for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
            {
                if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Animation[i].Name)) > 0)
                    SendUpdateAnimationTo(index, i);
            }
        }

        public static void SendUpdateAnimationTo(int index, int AnimationNum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SUpdateAnimation);

            buffer.WriteBlock(AnimationData(AnimationNum));

            // buffer.WriteInt32(AnimationNum)

            // For i = 0 To UBound(Animation(AnimationNum).Frames)
            // buffer.WriteInt32(Animation(AnimationNum).Frames(i))
            // Next

            // For i = 0 To UBound(Animation(AnimationNum).LoopCount)
            // buffer.WriteInt32(Animation(AnimationNum).LoopCount(i))
            // Next

            // For i = 0 To UBound(Animation(AnimationNum).LoopTime)
            // buffer.WriteInt32(Animation(AnimationNum).LoopTime(i))
            // Next

            // buffer.WriteString((Animation(AnimationNum).Name))
            // buffer.WriteString((Animation(AnimationNum).Sound))

            // For i = 0 To UBound(Animation(AnimationNum).Sprite)
            // buffer.WriteInt32(Animation(AnimationNum).Sprite(i))
            // Next

            S_General.AddDebug("Sent SMSG: SUpdateAnimation");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendUpdateAnimationToAll(int AnimationNum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SUpdateAnimation);

            buffer.WriteBlock(AnimationData(AnimationNum));

            // buffer.WriteInt32(AnimationNum)

            // For i = 0 To UBound(Animation(AnimationNum).Frames)
            // buffer.WriteInt32(Animation(AnimationNum).Frames(i))
            // Next

            // For i = 0 To UBound(Animation(AnimationNum).LoopCount)
            // buffer.WriteInt32(Animation(AnimationNum).LoopCount(i))
            // Next

            // For i = 0 To UBound(Animation(AnimationNum).LoopTime)
            // buffer.WriteInt32(Animation(AnimationNum).LoopTime(i))
            // Next

            // buffer.WriteString((Animation(AnimationNum).Name))
            // buffer.WriteString((Animation(AnimationNum).Sound))

            // For i = 0 To UBound(Animation(AnimationNum).Sprite)
            // buffer.WriteInt32(Animation(AnimationNum).Sprite(i))
            // Next

            S_General.AddDebug("Sent SMSG: SUpdateAnimation To All");

            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }
    }
}
