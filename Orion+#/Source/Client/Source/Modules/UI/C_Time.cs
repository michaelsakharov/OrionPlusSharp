
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using Asfw;
using Engine;


namespace Engine
{
	internal sealed class C_Time
	{
		
		public static void Packet_Clock(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			Time.Instance.GameSpeed = buffer.ReadInt32();
			Time.Instance._Time = new DateTime(BitConverter.ToInt64(buffer.ReadBytes(), 0));
			
			buffer.Dispose();
		}
		
		public static void Packet_Time(ref byte[] data)
		{
			ByteStream buffer = new ByteStream(data);
			
			Time.Instance.TimeOfDay = (TimeOfDay)buffer.ReadByte();
			
			if (Time.Instance.TimeOfDay == TimeOfDay.Dawn)
			{
				C_Text.AddText("A chilling, refreshing, breeze has come with the morning.", (System.Int32) Enums.ColorType.BrightBlue);
			}
			else if (Time.Instance.TimeOfDay == TimeOfDay.Day)
			{
				C_Text.AddText("Day has dawned in this region.", (System.Int32) Enums.ColorType.Yellow);
			}
			else if (Time.Instance.TimeOfDay == TimeOfDay.Dusk)
			{
				C_Text.AddText("Dusk has begun darkening the skies...", (System.Int32) Enums.ColorType.BrightRed);
			}
			else
			{
				C_Text.AddText("Night has fallen upon the weary travelers.", (System.Int32) Enums.ColorType.DarkGray);
			}
			
			buffer.Dispose();
		}
		
	}
}
