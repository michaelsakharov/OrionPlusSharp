
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Windows.Forms;
using Engine;


namespace Engine
{
	
	internal struct ChatCursor
	{
		internal int X;
		internal int Y;
	}
	
	internal struct ChatData
	{
		internal bool Active;
		internal int HistoryLimit;
		internal int MessageLimit;
		
		internal List<string> History;
		internal string CachedMessage;
		internal string CurrentMessage;
		internal ChatCursor Cursor;
		
		internal bool ProcessCharacter(KeyPressEventArgs evt)
		{
			if (!Active)
			{
				return false;
			}
			
			if (string.IsNullOrEmpty(CurrentMessage))
			{
				CurrentMessage = "";
			}
			
			if (evt.KeyChar.ToString() == Microsoft.VisualBasic.Constants.vbBack)
			{
			}
			else
			{
				CurrentMessage = CurrentMessage + evt.KeyChar;
				if (CurrentMessage.Length > MessageLimit)
				{
					CurrentMessage = CurrentMessage.Substring(0, MessageLimit);
				}
			}
			
			return true;
		}
		
		internal bool ProcessKey(KeyEventArgs evt)
		{
			if (!Active)
			{
				if (evt.KeyCode == Keys.Enter)
				{
					evt.Handled = true;
					evt.SuppressKeyPress = true;
					Active = true;
					return true;
				}
				
				return false;
			}
			
			if (string.IsNullOrEmpty(CurrentMessage))
			{
				CurrentMessage = "";
			}
			
			switch (evt.KeyCode)
			{
				case Keys.Enter:
					History.Add(CurrentMessage);
					if (History.Count > HistoryLimit)
					{
						History.RemoveRange(0, History.Count - HistoryLimit);
					}
					Cursor.Y = History.Count;
					Active = false;
					break;
					
				case Keys.Back:
					if (CurrentMessage.Length > 0)
					{
						CurrentMessage = CurrentMessage.Remove(CurrentMessage.Length - 1);
					}
					break;
					
				case Keys.Left:
					Cursor.X = Math.Max(0, Cursor.X - 1);
					break;
					
				case Keys.Right:
					Cursor.X = Math.Min(CurrentMessage.Length, Cursor.X + 1);
					break;
					
				case Keys.Down:
					Cursor.Y = Math.Min(History.Count, Cursor.Y + 1);
					if (Cursor.Y == History.Count)
					{
						CurrentMessage = CachedMessage;
					}
					else
					{
						CurrentMessage = History[Cursor.Y];
					}
					break;
					
				case Keys.Up:
					if (Cursor.Y == History.Count)
					{
						CachedMessage = CurrentMessage;
					}
					
					Cursor.Y = Math.Max(0, Cursor.Y - 1);
					CurrentMessage = History[Cursor.Y];
					break;
					
				default:
					if (evt.KeyCode == Keys.V && evt.Modifiers == Keys.Control)
					{
						CurrentMessage = CurrentMessage + Clipboard.GetText();
					}
					
					var keyName = Enum.GetName(typeof(Keys), evt.KeyCode);
					if (keyName.Length == 1)
					{
						Cursor.Y = History.Count;
					}
					
					CachedMessage = CurrentMessage;
					break;
			}
			
			return true;
		}
		
	}
	
	sealed class ChatModule
	{                                                                                                                         //This 10 should be HistoryLimit
		internal static ChatData ChatInput = new ChatData {Active = false, HistoryLimit = 10, MessageLimit = 100, History = new List<string>(10 + 1), CurrentMessage = "", Cursor = new ChatCursor() {X = 0, Y = 0}};
	}
}
