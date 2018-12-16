
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using System.Text;
using SFML.Graphics;
using SFML.Window;
using Engine;


namespace Engine
{
	sealed class E_Text
	{
		internal const byte MaxChatDisplayLines = 8;
		internal const byte ChatLineSpacing = 12; // Should be same height as font
		internal const int MyChatTextLimit = 55;
		internal const int MyAmountValueLimit = 3;
		internal const int AllChatLineWidth = 55;
		internal static int FirstLineindex = 0;
		internal static int LastLineindex = 0;
		internal static int ScrollMod = 0;
		
		// Game text buffer
		internal static string MyText = "";
		
		internal static void DrawText(int X, int y, string text, SFML.Graphics.Color color, SFML.Graphics.Color BackColor, RenderWindow target, byte TextSize = 13)
		{
			Text mystring = new Text(text, E_Graphics.SFMLGameFont) {
					CharacterSize = TextSize,
					Color = BackColor,
					Position = new Vector2f(X - 1, y - 1)
				};
			target.Draw(mystring);
			
			mystring.Position = new Vector2f(X - 1, y + 1);
			target.Draw(mystring);
			
			mystring.Position = new Vector2f(X + 1, y + 1);
			target.Draw(mystring);
			
			mystring.Position = new Vector2f(X + 1, y + -1);
			target.Draw(mystring);
			
			mystring.Color = color;
			mystring.Position = new Vector2f(X, y);
			target.Draw(mystring);
			
		}
		
		internal static void DrawNPCName(int MapNpcNum)
		{
			int TextX = 0;
			int TextY = 0;
			SFML.Graphics.Color color = new SFML.Graphics.Color();
            SFML.Graphics.Color backcolor = new SFML.Graphics.Color();
			int npcNum = 0;
			
			npcNum = E_Types.MapNpc[MapNpcNum].Num;
			
			if (Types.Npc[npcNum].Behaviour == ((byte) 0)) // attack on sight
			{
				color = SFML.Graphics.Color.Red;
				backcolor = SFML.Graphics.Color.Black;
			} // attack when attacked + guard
			else if ((Types.Npc[npcNum].Behaviour == ((byte) 1)) || (Types.Npc[npcNum].Behaviour == ((byte) 4)))
			{
				color = SFML.Graphics.Color.Green;
				backcolor = SFML.Graphics.Color.Black;
			} // friendly + shopkeeper + quest
			else if (((Types.Npc[npcNum].Behaviour == ((byte) 2)) || (Types.Npc[npcNum].Behaviour == ((byte) 3))) || (Types.Npc[npcNum].Behaviour == ((byte) 5)))
			{
				color = SFML.Graphics.Color.Yellow;
				backcolor = SFML.Graphics.Color.Black;
			}
			
			TextX = System.Convert.ToInt32(E_Graphics.ConvertMapX(E_Types.MapNpc[MapNpcNum].X * E_Globals.PIC_X) + E_Types.MapNpc[MapNpcNum].XOffset + (E_Globals.PIC_X / 2) - (double) GetTextWidth(Types.Npc[npcNum].Name.Trim()) / 2);
			if (Types.Npc[npcNum].Sprite < 1 || Types.Npc[npcNum].Sprite > E_Graphics.NumCharacters)
			{
				TextY = E_Graphics.ConvertMapY(E_Types.MapNpc[MapNpcNum].Y * E_Globals.PIC_Y) + E_Types.MapNpc[MapNpcNum].YOffset - 16;
			}
			else
			{
				TextY = System.Convert.ToInt32(E_Graphics.ConvertMapY(E_Types.MapNpc[MapNpcNum].Y * E_Globals.PIC_Y) + E_Types.MapNpc[MapNpcNum].YOffset - ((double) E_Graphics.CharacterGFXInfo[Types.Npc[npcNum].Sprite].height / 4) + 16);
			}
			
			// Draw name
			DrawText(TextX, TextY, Types.Npc[npcNum].Name.Trim(), color, backcolor, E_Graphics.GameWindow);
		}
		
		internal static void DrawEventName(int index)
		{
			int TextX = 0;
			int TextY = 0;
            SFML.Graphics.Color color = new SFML.Graphics.Color();
            SFML.Graphics.Color backcolor = new SFML.Graphics.Color();
			string Name = "";
			
			if (E_Globals.InMapEditor)
			{
				return;
			}
			
			color = SFML.Graphics.Color.Yellow;
			backcolor = SFML.Graphics.Color.Black;
			
			Name = E_Types.Map.MapEvents[index].Name.Trim();
			// calc pos
			TextX = System.Convert.ToInt32(E_Graphics.ConvertMapX(E_Types.Map.MapEvents[index].X * E_Globals.PIC_X) + E_Types.Map.MapEvents[index].XOffset + (E_Globals.PIC_X / 2) - (double) GetTextWidth(Name.Trim()) / 2);
			if (E_Types.Map.MapEvents[index].GraphicType == 0)
			{
				TextY = E_Graphics.ConvertMapY(E_Types.Map.MapEvents[index].Y * E_Globals.PIC_Y) + E_Types.Map.MapEvents[index].YOffset - 16;
			}
			else if (E_Types.Map.MapEvents[index].GraphicType == 1)
			{
				if (E_Types.Map.MapEvents[index].GraphicNum < 1 || E_Types.Map.MapEvents[index].GraphicNum > E_Graphics.NumCharacters)
				{
					TextY = E_Graphics.ConvertMapY(E_Types.Map.MapEvents[index].Y * E_Globals.PIC_Y) + E_Types.Map.MapEvents[index].YOffset - 16;
				}
				else
				{
					// Determine location for text
					TextY = System.Convert.ToInt32(E_Graphics.ConvertMapY(E_Types.Map.MapEvents[index].Y * E_Globals.PIC_Y) + E_Types.Map.MapEvents[index].YOffset - ((double) E_Graphics.CharacterGFXInfo[E_Types.Map.MapEvents[index].GraphicNum].height / 4) + 16);
				}
			}
			else if (E_Types.Map.MapEvents[index].GraphicType == 2)
			{
				if (E_Types.Map.MapEvents[index].GraphicY2 > 0)
				{
					TextY = E_Graphics.ConvertMapY(E_Types.Map.MapEvents[index].Y * E_Globals.PIC_Y) + E_Types.Map.MapEvents[index].YOffset - (E_Types.Map.MapEvents[index].GraphicY2 * E_Globals.PIC_Y) + 16;
				}
				else
				{
					TextY = E_Graphics.ConvertMapY(E_Types.Map.MapEvents[index].Y * E_Globals.PIC_Y) + E_Types.Map.MapEvents[index].YOffset - 32 + 16;
				}
			}
			
			// Draw name
			DrawText(TextX, TextY, Name.Trim(), color, backcolor, E_Graphics.GameWindow);
			
		}
		
		internal static void DrawMapAttributes()
		{
			int X = 0;
			int y = 0;
			int tX = 0;
			int tY = 0;
			RectangleShape rec = new RectangleShape();
			
			if (E_Globals.SelectedTab == 2)
			{
				for (X = E_Globals.TileView.Left; X <= E_Globals.TileView.Right; X++)
				{
					for (y = E_Globals.TileView.Top; y <= E_Globals.TileView.Bottom; y++)
					{
						if (E_Graphics.IsValidMapPoint(X, y))
						{
							tX = System.Convert.ToInt32(((E_Graphics.ConvertMapX(X * E_Globals.PIC_X)) - 4) + (E_Globals.PIC_X * 0.5));
							tY = System.Convert.ToInt32(((E_Graphics.ConvertMapY(y * E_Globals.PIC_Y)) - 7) + (E_Globals.PIC_Y * 0.5));
							
							rec.OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.White);
							rec.OutlineThickness = (float) (0.6F);
							
							rec.Size = new Vector2f(E_Globals.PIC_X, E_Globals.PIC_X);
							rec.Position = new Vector2f(E_Graphics.ConvertMapX((X) * E_Globals.PIC_X), E_Graphics.ConvertMapY((y) * E_Globals.PIC_Y));
							
							if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.Blocked)
							{
								rec.FillColor = new SFML.Graphics.Color(255, 0, 0, 100);
								E_Graphics.GameWindow.Draw(rec);
								DrawText(tX, tY, "B", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.Warp)
							{
								DrawText(tX, tY, "W", SFML.Graphics.Color.Blue, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.Item)
							{
								DrawText(tX, tY, "I", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.NpcAvoid)
							{
								DrawText(tX, tY, "N", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.Key)
							{
								DrawText(tX, tY, "K", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.KeyOpen)
							{
								DrawText(tX, tY, "KO", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.Resource)
							{
								DrawText(tX, tY, "R", SFML.Graphics.Color.Green, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.Door)
							{
								DrawText(tX, tY, "D", SFML.Graphics.Color.Black, SFML.Graphics.Color.Red, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.NpcSpawn)
							{
								rec.FillColor = new SFML.Graphics.Color(255, 255, 0, 100);
								E_Graphics.GameWindow.Draw(rec);
								DrawText(tX, tY, "S", SFML.Graphics.Color.White, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.Shop)
							{
								DrawText(tX, tY, "SH", SFML.Graphics.Color.Blue, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.Bank)
							{
								DrawText(tX, tY, "BA", SFML.Graphics.Color.Blue, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.Heal)
							{
								DrawText(tX, tY, "H", SFML.Graphics.Color.Green, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.Trap)
							{
								DrawText(tX, tY, "T", SFML.Graphics.Color.Red, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.House)
							{
								DrawText(tX, tY, "H", SFML.Graphics.Color.Green, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.Craft)
							{
								DrawText(tX, tY, "C", SFML.Graphics.Color.Green, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
							else if (E_Types.Map.Tile[X, y].Type == (byte)Enums.TileType.Light)
							{
								DrawText(tX, tY, "L", SFML.Graphics.Color.Yellow, SFML.Graphics.Color.Black, E_Graphics.GameWindow);
							}
						}
					}
				}
			}
			
		}
		
		internal static int GetTextWidth(string text, byte textsize = 13)
		{
			Text mystring = new Text(text, E_Graphics.SFMLGameFont);
			FloatRect textBounds = new FloatRect();
			mystring.CharacterSize = System.Convert.ToUInt32(textsize);
			textBounds = mystring.GetLocalBounds();
			return System.Convert.ToInt32(textBounds.Width);
		}
		
		internal static SFML.Graphics.Color GetSFMLColor(byte Color)
		{
			if (Color == (byte)Enums.ColorType.Black)
			{
				return SFML.Graphics.Color.Black;
			}
			else if (Color == (byte)Enums.ColorType.Blue)
			{
				return new SFML.Graphics.Color(73, 151, 208);
			}
			else if (Color == (byte)Enums.ColorType.Green)
			{
				return new SFML.Graphics.Color(102, 255, 0, 180);
			}
			else if (Color == (byte)Enums.ColorType.Cyan)
			{
				return new SFML.Graphics.Color(0, 139, 139);
			}
			else if (Color == (byte)Enums.ColorType.Red)
			{
				return new SFML.Graphics.Color(255, 0, 0, 180);
			}
			else if (Color == (byte)Enums.ColorType.Magenta)
			{
				return SFML.Graphics.Color.Magenta;
			}
			else if (Color == (byte)Enums.ColorType.Brown)
			{
				return new SFML.Graphics.Color(139, 69, 19);
			}
			else if (Color == (byte)Enums.ColorType.Gray)
			{
				return new SFML.Graphics.Color(211, 211, 211);
			}
			else if (Color == (byte)Enums.ColorType.DarkGray)
			{
				return new SFML.Graphics.Color(169, 169, 169);
			}
			else if (Color == (byte)Enums.ColorType.BrightBlue)
			{
				return new SFML.Graphics.Color(0, 191, 255);
			}
			else if (Color == (byte)Enums.ColorType.BrightGreen)
			{
				return new SFML.Graphics.Color(0, 255, 0);
			}
			else if (Color == (byte)Enums.ColorType.BrightCyan)
			{
				return new SFML.Graphics.Color(0, 255, 255);
			}
			else if (Color == (byte)Enums.ColorType.BrightRed)
			{
				return new SFML.Graphics.Color(255, 0, 0);
			}
			else if (Color == (byte)Enums.ColorType.Pink)
			{
				return new SFML.Graphics.Color(255, 192, 203);
			}
			else if (Color == (byte)Enums.ColorType.Yellow)
			{
				return SFML.Graphics.Color.Yellow;
			}
			else if (Color == (byte)Enums.ColorType.White)
			{
				return SFML.Graphics.Color.White;
			}
			else
			{
				return SFML.Graphics.Color.White;
			}
		}
		
		internal static char[] SplitChars = new char[] {' ', '-', ControlChars.Tab};
		
		internal static List<string> WordWrap(string str, int width)
		{
			
			string[] words = Explode(str, SplitChars);
			int curLineLength = 0;
			StringBuilder strBuilder = new StringBuilder();
			int i = 0;
			List<string> rtnString = new List<string>();
			
			while (i < words.Length)
			{
				string word = words[i];
				
				// If adding the new word to the current line would be too Integer,
				// then put it on a new line (and split it up if it's too Integer).
				if (curLineLength + word.Length > width)
				{
					
					// Only move down to a new line if we have text on the current line.
					// Avoids situation where wrapped whitespace causes emptylines in text.
					if (curLineLength > 0)
					{
						strBuilder.Append("|");
						curLineLength = 0;
					}
					
					// If the current word is too Integer to fit on a line even on it's own then
					// split the word up.
					while (word.Length > width)
					{
						strBuilder.Append(word.Substring(0, width - 1) + "-");
						word = word.Substring(width - 1);
						strBuilder.Append("|");
					}
					
					// Remove leading whitespace from the word so the new line starts flush to the left.
					word = word.TrimStart();
					
				}
				
				strBuilder.Append(word);
				curLineLength += word.Length;
				i++;
			}
			
			string[] lines = strBuilder.ToString().Split("|".ToCharArray());
			foreach (string line in lines)
			{
				//line = Replace(line, "|", "")
				rtnString.Add(line.Replace("|", "")); // & vbNewLine)
			}
			
			return rtnString;
			
		}
		
		internal static string[] Explode(string str, char[] splitChars)
		{
			string[] returnValue = default(string[]);
			
			List<string> parts = new List<string>();
			int startindex = 0;
			returnValue = null;
			while (true)
			{
				int index = str.IndexOfAny(splitChars.ToString().ToCharArray(), startindex);
				
				if (index == -1)
				{
					parts.Add(str.Substring(startindex));
					return parts.ToArray();
				}
				
				string word = str.Substring(startindex, index - startindex);
				char nextChar = System.Convert.ToChar(str.Substring(index, 1)[0]);
				// Dashes and the likes should stick to the word occuring before it. Whitespace doesn't have to.
				if (char.IsWhiteSpace(nextChar))
				{
					parts.Add(word);
					parts.Add(nextChar.ToString());
				}
				else
				{
					parts.Add(word + nextChar);
				}
				
				startindex = index + 1;
			}
			
			return returnValue;
		}
		
		//Friend Function KeyPressed(e As KeyEventArgs) As String
		
		//    Dim keyValue As String = ""
		
		//    If e.KeyCode = 32 Then ' Space
		//        keyValue = ChrW(e.KeyCode)
		
		//    ElseIf e.KeyCode >= 65 AndAlso e.KeyCode <= 90 Then ' Letters
		//        If e.Shift Then
		//            keyValue = ChrW(e.KeyCode)
		//        Else
		//            keyValue = ChrW(e.KeyCode + 32)
		//        End If
		
		//    ElseIf e.KeyCode = Keys.D0 Then
		//        If e.Shift Then
		//            keyValue = ")"
		//        Else
		//            keyValue = "0"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.D1 Then
		//        If e.Shift Then
		//            keyValue = "!"
		//        Else
		//            keyValue = "1"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.D2 Then
		//        If e.Shift Then
		//            keyValue = "@"
//        Else
//            keyValue = "2"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.D3 Then
		//        If e.Shift Then
		//            keyValue = "#"
		//        Else
		//            keyValue = "3"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.D4 Then
		//        If e.Shift Then
		//            keyValue = "$"
		//        Else
		//            keyValue = "4"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.D5 Then
		//        If e.Shift Then
		//            keyValue = "%"
		//        Else
		//            keyValue = "5"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.D6 Then
		//        If e.Shift Then
		//            keyValue = "^"
		//        Else
		//            keyValue = "6"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.D7 Then
		//        If e.Shift Then
		//            keyValue = "&"
		//        Else
		//            keyValue = "7"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.D8 Then
		//        If e.Shift Then
		//            keyValue = "*"
		//        Else
		//            keyValue = "8"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.D9 Then
		//        If e.Shift Then
		//            keyValue = "("
		//        Else
		//            keyValue = "9"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.OemPeriod Then
		//        If e.Shift Then
		//            keyValue = ">"
		//        Else
		//            keyValue = "."
		//        End If
		
		//    ElseIf e.KeyCode = Keys.OemPipe Then
		//        If e.Shift Then
		//            'keyValue= "|"
		//        Else
		//            keyValue = "\"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.OemCloseBrackets Then
		//        If e.Shift Then
		//            keyValue = "}"
		//        Else
		//            keyValue = "]"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.OemMinus Then
		//        If e.Shift Then
		//            keyValue = "_"
		//        Else
		//            keyValue = "-"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.OemOpenBrackets Then
		//        If e.Shift Then
		//            keyValue = "{"
		//        Else
		//            keyValue = "["
		//        End If
		
		//    ElseIf e.KeyCode = Keys.OemQuestion Then
		//        If e.Shift Then
		//            keyValue = "?"
		//        Else
		//            keyValue = "/"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.OemQuotes Then
		//        If e.Shift Then
		//            keyValue = Chr(34)
		//        Else
		//            keyValue = "'"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.OemSemicolon Then
		//        If e.Shift Then
		//            keyValue = ":"
		//        Else
		//            keyValue = ";"
		//        End If
		
		//    ElseIf e.KeyCode = Keys.Oemcomma Then
		//        If e.Shift Then
		//            keyValue = "<"
		//        Else
		//            keyValue = ","
		//        End If
		
		//    ElseIf e.KeyCode = Keys.Oemplus Then
		//        If e.Shift Then
		//            keyValue = "+"
		//        Else
		//            keyValue = "="
		//        End If
		
		//    ElseIf e.KeyCode = Keys.Oemtilde Then
		//        If e.Shift Then
		//            keyValue = "~"
		//        Else
		//            keyValue = "`"
		//        End If
		
		//    End If
		
		//    Return keyValue
		
		//End Function
	}
}
