
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using ASFW;
using SFML.Graphics;
using SFML.Window;
using Engine;


namespace Engine
{
	sealed class C_Parties
	{
		
#region Types and Globals
		
		internal static PartyRec Party;
		
		public struct PartyRec
		{
			public int Leader;
			public int[] Member;
			public int MemberCount;
		}
		
#endregion
		
#region Database
		
		public static void ClearParty()
		{
			Party = new PartyRec {
					Leader = 0,
					MemberCount = 0
				};
			Party.Member = new int[Constants.MAX_PARTY_MEMBERS + 1];
		}
		
#endregion
		
#region Incoming Packets
		
		public static void Packet_PartyInvite(ref byte[] data)
		{
			string name = "";
			ByteStream buffer = new ByteStream(data);
			name = buffer.ReadString();
			
			C_Variables.DialogType = C_Constants.DialogueTypeParty;
			
			C_Variables.DialogMsg1 = "Party Invite";
			C_Variables.DialogMsg2 = name.Trim() + " has invited you to a party. Would you like to join?";
			
			C_Variables.UpdateDialog = true;
			
			buffer.Dispose();
		}
		
		public static void Packet_PartyUpdate(ref byte[] data)
		{
			int I = 0;
			int inParty;
			ByteStream buffer = new ByteStream(data);
			inParty = buffer.ReadInt32();
			
			// exit out if we're not in a party
			if (inParty == 0)
			{
				ClearParty();
				// exit out early
				buffer.Dispose();
				return;
			}
			
			// carry on otherwise
			Party.Leader = buffer.ReadInt32();
			for (I = 1; I <= Constants.MAX_PARTY_MEMBERS; I++)
			{
				Party.Member[I] = buffer.ReadInt32();
			}
			Party.MemberCount = buffer.ReadInt32();
			
			buffer.Dispose();
		}
		
		public static void Packet_PartyVitals(ref byte[] data)
		{
			int playerNum = 0;
			int partyindex = 0;
			ByteStream buffer = new ByteStream(data);
			// which player
			playerNum = buffer.ReadInt32();
			
			// find the party number
			for (var I = 1; I <= Constants.MAX_PARTY_MEMBERS; I++)
			{
				if (Party.Member[(int) I] == playerNum)
				{
					partyindex = System.Convert.ToInt32(I);
				}
			}
			
			// exit out if wrong data
			if (partyindex <= 0 || partyindex > Constants.MAX_PARTY_MEMBERS)
			{
				return;
			}
			
			// set vitals
			C_Types.Player[playerNum].MaxHp = buffer.ReadInt32();
			C_Types.Player[playerNum].Vital[(byte)Enums.VitalType.HP] = buffer.ReadInt32();
			
			C_Types.Player[playerNum].MaxMp = buffer.ReadInt32();
			C_Types.Player[playerNum].Vital[(byte)Enums.VitalType.MP] = buffer.ReadInt32();
			
			C_Types.Player[playerNum].MaxSp = buffer.ReadInt32();
			C_Types.Player[playerNum].Vital[(byte)Enums.VitalType.SP] = buffer.ReadInt32();
			
			buffer.Dispose();
		}
		
#endregion
		
#region Outgoing Packets
		
		internal static void SendPartyRequest(string name)
		{
			ByteStream buffer = new ByteStream(4);
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestParty);
			buffer.WriteString(name);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendAcceptParty()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CAcceptParty);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendDeclineParty()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CDeclineParty);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendLeaveParty()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CLeaveParty);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendPartyChatMsg(string text)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CPartyChatMsg);
			buffer.WriteString(text);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
#endregion
		
#region Drawing
		
		internal static void DrawParty()
		{
			int I = 0;
			int x = 0;
			int y = 0;
			int barwidth = 0;
			int playerNum = 0;
			string theName = "";
			Rectangle[] rec = new Rectangle[2];
			
			// render the window
			
			// draw the bars
			if (Party.Leader > 0) // make sure we're in a party
			{
				// draw leader
				playerNum = Party.Leader;
				// name
				theName = C_Player.GetPlayerName(playerNum).Trim();
				// draw name
				y = 100;
				x = 10;
				C_Text.DrawText(x, y, theName, SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
				
				// draw hp
				if (C_Types.Player[playerNum].Vital[(byte)Enums.VitalType.HP] > 0)
				{
					// calculate the width to fill
					barwidth = System.Convert.ToInt32(C_Types.Player[playerNum].Vital[(byte)Enums.VitalType.HP] / (C_Player.GetPlayerMaxVital(playerNum, Enums.VitalType.HP)) * 64);
					// draw bars
					rec[1] = new Rectangle(x, y, barwidth, 6);
					RectangleShape rectShape = new RectangleShape(new Vector2f(barwidth, 6)) {
							Position = new Vector2f(x, y + 15),
							FillColor = SFML.Graphics.Color.Red
						};
					C_Graphics.GameWindow.Draw(rectShape);
				}
				// draw mp
				if (C_Types.Player[playerNum].Vital[(byte)Enums.VitalType.MP] > 0)
				{
					// calculate the width to fill
					barwidth = System.Convert.ToInt32(C_Types.Player[playerNum].Vital[(byte)Enums.VitalType.MP] / (C_Player.GetPlayerMaxVital(playerNum, Enums.VitalType.MP)) * 64);
					// draw bars
					rec[1] = new Rectangle(x, y, barwidth, 6);
					RectangleShape rectShape2 = new RectangleShape(new Vector2f(barwidth, 6)) {
							Position = new Vector2f(x, y + 24),
							FillColor = SFML.Graphics.Color.Blue
						};
					C_Graphics.GameWindow.Draw(rectShape2);
				}
				
				// draw members
				for (I = 1; I <= Constants.MAX_PARTY_MEMBERS; I++)
				{
					if (Party.Member[I] > 0)
					{
						if (Party.Member[I] != Party.Leader)
						{
							// cache the index
							playerNum = Party.Member[I];
							// name
							theName = C_Player.GetPlayerName(playerNum).Trim();
							// draw name
							y = 100 + ((I - 1) * 30);
							
							C_Text.DrawText(x, y, theName, SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
							// draw hp
							y = 115 + ((I - 1) * 30);
							
							// make sure we actually have the data before rendering
							if (C_Player.GetPlayerVital(playerNum, Enums.VitalType.HP) > 0 && C_Player.GetPlayerMaxVital(playerNum, Enums.VitalType.HP) > 0)
							{
								barwidth = System.Convert.ToInt32(C_Types.Player[playerNum].Vital[(byte)Enums.VitalType.HP] / (C_Player.GetPlayerMaxVital(playerNum, Enums.VitalType.HP)) * 64);
							}
							rec[1] = new Rectangle(x, y, barwidth, 6);
							RectangleShape rectShape = new RectangleShape(new Vector2f(barwidth, 6)) {
									Position = new Vector2f(x, y),
									FillColor = SFML.Graphics.Color.Red
								};
							C_Graphics.GameWindow.Draw(rectShape);
							// draw mp
							y = 115 + ((I - 1) * 30);
							// make sure we actually have the data before rendering
							if (C_Player.GetPlayerVital(playerNum, Enums.VitalType.MP) > 0 && C_Player.GetPlayerMaxVital(playerNum, Enums.VitalType.MP) > 0)
							{
								barwidth = System.Convert.ToInt32(C_Types.Player[playerNum].Vital[(byte)Enums.VitalType.MP] / (C_Player.GetPlayerMaxVital(playerNum, Enums.VitalType.MP)) * 64);
							}
							rec[1] = new Rectangle(x, y, barwidth, 6);
							RectangleShape rectShape2 = new RectangleShape(new Vector2f(barwidth, 6)) {
									Position = new Vector2f(x, y + 8),
									FillColor = SFML.Graphics.Color.Blue
								};
							C_Graphics.GameWindow.Draw(rectShape2);
						}
					}
				}
			}
		}
		
#endregion
		
	}
}
