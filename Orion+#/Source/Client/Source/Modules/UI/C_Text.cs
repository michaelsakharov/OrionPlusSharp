
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using SFML.Graphics;
using SFML.Window;
using Engine;


namespace Engine
{
	sealed class C_Text
	{
		internal const byte MaxChatDisplayLines = 8;
		internal const byte ChatLineSpacing = C_Constants.FontSize; // Should be same height as font
		internal const int MyChatTextLimit = 40;
		internal const int MyAmountValueLimit = 3;
		internal const int AllChatLineWidth = 40;
		internal const int ChatboxPadding = 10 + 16 + 2; // 10 = left and right border padding +2 each (3+2+3+2), 16 = scrollbar width, +2 for padding between scrollbar and text
		internal const int ChatEntryPadding = 10; // 5 on left and right
		internal static int FirstLineindex = 0;
		internal static int LastLineindex = 0;
		internal static int ScrollMod = 0;
		
		internal static void DrawText(int x, int y, string text, Color color, Color backColor, RenderWindow target, byte textSize = 13)
		{
			Text backString = new Text(text, C_Graphics.SfmlGameFont);
			Text frontString = new Text(text, C_Graphics.SfmlGameFont);
			backString.CharacterSize = System.Convert.ToUInt32(textSize);
			frontString.CharacterSize = System.Convert.ToUInt32(textSize);
			
			backString.Color = backColor;
			backString.Position = new Vector2f(x - 1, y - 1);
			target.Draw(backString);
			
			backString.Position = new Vector2f(x - 1, y + 1);
			target.Draw(backString);
			
			backString.Position = new Vector2f(x + 1, y + 1);
			target.Draw(backString);
			
			backString.Position = new Vector2f(x + 1, y - 1);
			target.Draw(backString);
			
			frontString.Color = color;
			frontString.Position = new Vector2f(x, y);
			target.Draw(frontString);
		}
		
		internal static void DrawPlayerName(int index)
		{
			int textX = 0;
			int textY = 0;
			Color color = new Color();
			Color backcolor = new Color();
			string name = "";
			
			// Check access level
			if (C_Player.GetPlayerPk(index) == 0)
			{
				
				switch (C_Player.GetPlayerAccess(index))
				{
					case (int) Enums.AdminType.Player:
						color = SFML.Graphics.Color.Red;
						backcolor = SFML.Graphics.Color.Black;
						break;
					case (int) Enums.AdminType.Monitor:
						color = SFML.Graphics.Color.Black;
						backcolor = SFML.Graphics.Color.White;
						break;
					case (int) Enums.AdminType.Mapper:
						color = SFML.Graphics.Color.Cyan;
						backcolor = SFML.Graphics.Color.Black;
						break;
					case (int) Enums.AdminType.Developer:
						color = SFML.Graphics.Color.Green;
						backcolor = SFML.Graphics.Color.Black;
						break;
					case (int) Enums.AdminType.Creator:
						color = SFML.Graphics.Color.Yellow;
						backcolor = SFML.Graphics.Color.Black;
						break;
				}
			}
			else
			{
				color = SFML.Graphics.Color.Red;
			}
			
			name = C_Types.Player[index].Name.Trim();
			// calc pos
			textX = (C_Graphics.ConvertMapX(C_Player.GetPlayerX(index) * C_Constants.PicX) + C_Types.Player[index].XOffset + (C_Constants.PicX / 2));
			textX = (int)(textX - ((double) GetTextWidth(name.Trim()) / 2));
			if (C_Player.GetPlayerSprite(index) < 1 || C_Player.GetPlayerSprite(index) > C_Graphics.NumCharacters)
			{
				textY = C_Graphics.ConvertMapY(C_Player.GetPlayerY(index) * C_Constants.PicY) + C_Types.Player[index].YOffset - 16;
			}
			else
			{
				// Determine location for text
				textY = (int)(C_Graphics.ConvertMapY(C_Player.GetPlayerY(index) * C_Constants.PicY) + C_Types.Player[index].YOffset - ((double) C_Graphics.CharacterGfxInfo[C_Player.GetPlayerSprite(index)].Height / 4) + 16);
			}
			
			// Draw name
			DrawText(textX, textY, name.Trim(), color, backcolor, C_Graphics.GameWindow);
		}
		
		internal static void DrawNpcName(int mapNpcNum)
		{
			int textX = 0;
			int textY = 0;
			Color color = new Color();
			Color backcolor = new Color();
			int npcNum = 0;
			
			npcNum = C_Maps.MapNpc[mapNpcNum].Num;
			
			if (Types.Npc[npcNum].Behaviour == ((byte) 0)) // attack on sight
			{
				color = SFML.Graphics.Color.Red;
				backcolor = SFML.Graphics.Color.Black;
			} // attack when attacked + guard
			else if ((Types.Npc[npcNum].Behaviour == ((byte) 1)) || (Types.Npc[npcNum].Behaviour == (4)))
			{
				color = SFML.Graphics.Color.Green;
				backcolor = SFML.Graphics.Color.Black;
			} // friendly + shopkeeper + quest
			else if (((Types.Npc[npcNum].Behaviour == ((byte) 2)) || (Types.Npc[npcNum].Behaviour == (3))) || (Types.Npc[npcNum].Behaviour == (5)))
			{
				color = SFML.Graphics.Color.Yellow;
				backcolor = SFML.Graphics.Color.Black;
			}
			
			textX = (int)((C_Graphics.ConvertMapX(C_Maps.MapNpc[mapNpcNum].X * C_Constants.PicX) + C_Maps.MapNpc[mapNpcNum].XOffset + (C_Constants.PicX / 2)) - (GetTextWidth(Types.Npc[npcNum].Name.Trim()) / 2));
			if (Types.Npc[npcNum].Sprite < 1 || Types.Npc[npcNum].Sprite > C_Graphics.NumCharacters)
			{
				textY = C_Graphics.ConvertMapY(C_Maps.MapNpc[mapNpcNum].Y * C_Constants.PicY) + C_Maps.MapNpc[mapNpcNum].YOffset - 16;
			}
			else
			{
				textY = System.Convert.ToInt32(C_Graphics.ConvertMapY(C_Maps.MapNpc[mapNpcNum].Y * C_Constants.PicY) + C_Maps.MapNpc[mapNpcNum].YOffset - ((double) C_Graphics.CharacterGfxInfo[Types.Npc[npcNum].Sprite].Height / 4) + 16);
			}
			
			// Draw name
			DrawText(textX, textY, Types.Npc[npcNum].Name.Trim(), color, backcolor, C_Graphics.GameWindow);
		}
		
		internal static void DrawEventName(int index)
		{
			int textX = 0;
			int textY = 0;
			Color color = new Color();
			Color backcolor = new Color();
			string name = "";
			
			color = SFML.Graphics.Color.Yellow;
			backcolor = SFML.Graphics.Color.Black;
			
			name = C_Maps.Map.MapEvents[index].Name.Trim();
			
			// calc pos
			textX = ((C_Graphics.ConvertMapX(C_Maps.Map.MapEvents[index].X * C_Constants.PicX) + C_Maps.Map.MapEvents[index].XOffset + (C_Constants.PicX / 2)) - (GetTextWidth(name.Trim()) / 2));
			if (C_Maps.Map.MapEvents[index].GraphicType == 0)
			{
				textY = C_Graphics.ConvertMapY(C_Maps.Map.MapEvents[index].Y * C_Constants.PicY) + C_Maps.Map.MapEvents[index].YOffset - 16;
			}
			else if (C_Maps.Map.MapEvents[index].GraphicType == 1)
			{
				if (C_Maps.Map.MapEvents[index].GraphicNum < 1 || C_Maps.Map.MapEvents[index].GraphicNum > C_Graphics.NumCharacters)
				{
					textY = C_Graphics.ConvertMapY(C_Maps.Map.MapEvents[index].Y * C_Constants.PicY) + C_Maps.Map.MapEvents[index].YOffset - 16;
				}
				else
				{
					// Determine location for text
					textY = System.Convert.ToInt32(C_Graphics.ConvertMapY(C_Maps.Map.MapEvents[index].Y * C_Constants.PicY) + C_Maps.Map.MapEvents[index].YOffset - (C_Graphics.CharacterGfxInfo[C_Maps.Map.MapEvents[index].GraphicNum].Height / 4) + 16);
				}
			}
			else if (C_Maps.Map.MapEvents[index].GraphicType == 2)
			{
				if (C_Maps.Map.MapEvents[index].GraphicY2 > 0)
				{
					textX = textX + (C_Maps.Map.MapEvents[index].GraphicY2 * C_Constants.PicY) / 2 - 16;
					textY = C_Graphics.ConvertMapY(C_Maps.Map.MapEvents[index].Y * C_Constants.PicY) + C_Maps.Map.MapEvents[index].YOffset - (C_Maps.Map.MapEvents[index].GraphicY2 * C_Constants.PicY) + 16;
				}
				else
				{
					textY = C_Graphics.ConvertMapY(C_Maps.Map.MapEvents[index].Y * C_Constants.PicY) + C_Maps.Map.MapEvents[index].YOffset - 32 + 16;
				}
			}
			
			// Draw name
			DrawText(textX, textY, name.Trim(), color, backcolor, C_Graphics.GameWindow);
			
			//For i = 1 To MaxQuests
			//    'check if the npc is the starter to any quest: [!] symbol
			//    'can accept the quest as a new one
			//    If Player(MyIndex).PlayerQuest(i).Status = QuestStatusType.NotStarted OrElse Player(MyIndex).PlayerQuest(i).Status = QuestStatusType.Repeatable OrElse (Player(MyIndex).PlayerQuest(i).Status = QuestStatusType.Completed AndAlso Quest(i).Repeat = 1) Then
			//        'the npc gives this quest
			//        If Map.MapEvents(Index).questnum = i Then
			//            Name = "[!]"
			//            TextX = ConvertMapX(Map.MapEvents(Index).X * PicX) + Map.MapEvents(Index).XOffset + (PicX \ 2) - GetTextWidth((Trim$("[!]"))) + 8
			//            TextY = TextY - 16
			//            If Quest(i).Repeat = 1 Then
			//                DrawText(TextX, TextY, Trim$(Name), Color.White, backcolor, GameWindow)
			//            Else
			//                DrawText(TextX, TextY, Trim$(Name), color, backcolor, GameWindow)
			//            End If
			//            Exit For
			//        End If
			//    ElseIf Player(MyIndex).PlayerQuest(i).Status = QuestStatusType.Started Then
			//        If Map.MapEvents(Index).questnum = i Then
			//            Name = "[*]"
			//            TextX = ConvertMapX(Map.MapEvents(Index).X * PicX) + Map.MapEvents(Index).XOffset + (PicX \ 2) - GetTextWidth((Trim$("[*]"))) + 8
			//            TextY = TextY - 16
			//            DrawText(TextX, TextY, Trim$(Name), color, backcolor, GameWindow)
			//            Exit For
			//        End If
			//    End If
			//Next
			
		}
		
		public static void DrawMapAttributes()
		{
			int X = 0;
			int y = 0;
			int tX = 0;
			int tY = 0;
			
			if (ReferenceEquals(FrmEditor_MapEditor.Default.tabpages.SelectedTab, FrmEditor_MapEditor.Default.tpAttributes))
			{
				for (X = C_Variables.TileView.Left; X <= C_Variables.TileView.Right; X++)
				{
					for (y = C_Variables.TileView.Top; y <= C_Variables.TileView.Bottom; y++)
					{
						if (C_Graphics.IsValidMapPoint(X, y))
						{
							tX = System.Convert.ToInt32(((C_Graphics.ConvertMapX(X * C_Constants.PicX)) - 4) + (C_Constants.PicX * 0.5));
							tY = System.Convert.ToInt32(((C_Graphics.ConvertMapY(y * C_Constants.PicY)) - 7) + (C_Constants.PicY * 0.5));
							if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.Blocked)
							{
								DrawText(tX, tY, "B", Color.Red, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.Warp)
							{
								DrawText(tX, tY, "W", Color.Blue, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.Item)
							{
								DrawText(tX, tY, "I", Color.White, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.NpcAvoid)
							{
								DrawText(tX, tY, "N", Color.White, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.Key)
							{
								DrawText(tX, tY, "K", Color.White, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.KeyOpen)
							{
								DrawText(tX, tY, "KO", Color.White, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.Resource)
							{
								DrawText(tX, tY, "R", Color.Green, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.Door)
							{
								DrawText(tX, tY, "D", Color.Black, Color.Red, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.NpcSpawn)
							{
								DrawText(tX, tY, "S", Color.Yellow, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.Shop)
							{
								DrawText(tX, tY, "SH", Color.Blue, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.Bank)
							{
								DrawText(tX, tY, "BA", Color.Blue, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.Heal)
							{
								DrawText(tX, tY, "H", Color.Green, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.Trap)
							{
								DrawText(tX, tY, "T", Color.Red, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.House)
							{
								DrawText(tX, tY, "H", Color.Green, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.Craft)
							{
								DrawText(tX, tY, "C", Color.Green, Color.Black, C_Graphics.GameWindow);
							}
							else if (C_Maps.Map.Tile[X, y].Type == (byte)Enums.TileType.Light)
							{
								DrawText(tX, tY, "L", Color.Yellow, Color.Black, C_Graphics.GameWindow);
							}
						}
					}
				}
			}
			
		}
		
		public static void DrawActionMsg(int index)
		{
			int x = 0;
			int y = 0;
			int i = 0;
			int time = 0;
			
			// how long we want each message to appear
			switch (C_Types.ActionMsg[index].Type)
			{
				case (int) Enums.ActionMsgType.Static:
					time = 1500;
					
					if (C_Types.ActionMsg[index].Y > 0)
					{
						x = System.Convert.ToInt32(C_Types.ActionMsg[index].X + Conversion.Int(C_Constants.PicX / 2) - ((Microsoft.VisualBasic.Strings.Trim(C_Types.ActionMsg[index].Message).Length / 2) * 8));
						y = C_Types.ActionMsg[index].Y - Conversion.Int(C_Constants.PicY / 2) - 2;
					}
					else
					{
						x = System.Convert.ToInt32(C_Types.ActionMsg[index].X + Conversion.Int(C_Constants.PicX / 2) - ((Microsoft.VisualBasic.Strings.Trim(C_Types.ActionMsg[index].Message).Length / 2) * 8));
						y = C_Types.ActionMsg[index].Y - Conversion.Int(C_Constants.PicY / 2) + 18;
					}
					break;
					
				case (int) Enums.ActionMsgType.Scroll:
					time = 1500;
					
					if (C_Types.ActionMsg[index].Y > 0)
					{
						x = System.Convert.ToInt32(C_Types.ActionMsg[index].X + Conversion.Int(C_Constants.PicX / 2) - ((Microsoft.VisualBasic.Strings.Trim(C_Types.ActionMsg[index].Message).Length / 2) * 8));
						y = System.Convert.ToInt32(C_Types.ActionMsg[index].Y - Conversion.Int(C_Constants.PicY / 2) - 2 - (C_Types.ActionMsg[index].Scroll * 0.6));
						C_Types.ActionMsg[index].Scroll = C_Types.ActionMsg[index].Scroll + 1;
					}
					else
					{
						x = System.Convert.ToInt32(C_Types.ActionMsg[index].X + Conversion.Int(C_Constants.PicX / 2) - ((Microsoft.VisualBasic.Strings.Trim(C_Types.ActionMsg[index].Message).Length / 2) * 8));
						y = System.Convert.ToInt32(C_Types.ActionMsg[index].Y - Conversion.Int(C_Constants.PicY / 2) + 18 + (C_Types.ActionMsg[index].Scroll * 0.6));
						C_Types.ActionMsg[index].Scroll = C_Types.ActionMsg[index].Scroll + 1;
					}
					break;
					
				case (int) Enums.ActionMsgType.Screen:
					time = 3000;
					
					// This will kill any action screen messages that there in the system
					for (i = byte.MaxValue; i >= 1; i--)
					{
						if (C_Types.ActionMsg[i].Type == (int) Enums.ActionMsgType.Screen)
						{
							if (i != index)
							{
								C_GameLogic.ClearActionMsg((byte) index);
								index = i;
							}
						}
					}
					x = System.Convert.ToInt32((FrmGame.Default.picscreen.Width / 2) - ((Microsoft.VisualBasic.Strings.Trim(C_Types.ActionMsg[index].Message).Length / 2) * 8));
					y = 425;
					break;
					
			}
			
			x = C_Graphics.ConvertMapX(x);
			y = C_Graphics.ConvertMapY(y);
			
			if (C_General.GetTickCount() < C_Types.ActionMsg[index].Created + time)
			{
				DrawText(x, y, C_Types.ActionMsg[index].Message, GetSfmlColor((byte) (C_Types.ActionMsg[index].Color)), Color.Black, C_Graphics.GameWindow);
			}
			else
			{
				C_GameLogic.ClearActionMsg((byte) index);
			}
			
		}
		
		private readonly static Text WidthTester = new Text("", C_Graphics.SfmlGameFont);
		
		internal static int GetTextWidth(string text, byte textSize = 13)
		{
			WidthTester.DisplayedString = text;
			WidthTester.CharacterSize = System.Convert.ToUInt32(textSize);
			return System.Convert.ToInt32(WidthTester.GetLocalBounds().Width);
		}
		
		internal static void AddText(string msg, int color)
		{
			if (string.IsNullOrEmpty(C_UpdateUI.TxtChatAdd))
			{
				C_UpdateUI.TxtChatAdd = C_UpdateUI.TxtChatAdd + msg;
				AddChatRec(msg, color);
			}
			else
			{
				foreach (string str in WordWrap(msg, C_Graphics.MyChatWindowGfxInfo.Width - ChatboxPadding, WrapMode.Font, WrapType.Smart, 13))
				{
					C_UpdateUI.TxtChatAdd = C_UpdateUI.TxtChatAdd + Microsoft.VisualBasic.Constants.vbNewLine + str;
					AddChatRec(str, color);
				}
				
			}
		}
		
		internal static void AddChatRec(string msg, int color)
		{
			C_Types.ChatRec @struct = new C_Types.ChatRec();
			@struct.Text = msg;
			@struct.Color = color;
			C_Types.Chat.Add(@struct);
		}
		
		internal static Color GetSfmlColor(byte color)
		{
			if (color == (byte)Enums.ColorType.Black)
			{
				return SFML.Graphics.Color.Black;
			}
			else if (color == (byte)Enums.ColorType.Blue)
			{
				return new Color(73, 151, 208);
			}
			else if (color == (byte)Enums.ColorType.Green)
			{
				return new Color(102, 255, 0, 180);
			}
			else if (color == (byte)Enums.ColorType.Cyan)
			{
				return new Color(0, 139, 139);
			}
			else if (color == (byte)Enums.ColorType.Red)
			{
				return new Color(255, 0, 0, 180);
			}
			else if (color == (byte)Enums.ColorType.Magenta)
			{
				return SFML.Graphics.Color.Magenta;
			}
			else if (color == (byte)Enums.ColorType.Brown)
			{
				return new Color(139, 69, 19);
			}
			else if (color == (byte)Enums.ColorType.Gray)
			{
				return new Color(211, 211, 211);
			}
			else if (color == (byte)Enums.ColorType.DarkGray)
			{
				return new Color(169, 169, 169);
			}
			else if (color == (byte)Enums.ColorType.BrightBlue)
			{
				return new Color(0, 191, 255);
			}
			else if (color == (byte)Enums.ColorType.BrightGreen)
			{
				return new Color(0, 255, 0);
			}
			else if (color == (byte)Enums.ColorType.BrightCyan)
			{
				return new Color(0, 255, 255);
			}
			else if (color == (byte)Enums.ColorType.BrightRed)
			{
				return new Color(255, 0, 0);
			}
			else if (color == (byte)Enums.ColorType.Pink)
			{
				return new Color(255, 192, 203);
			}
			else if (color == (byte)Enums.ColorType.Yellow)
			{
				return SFML.Graphics.Color.Yellow;
			}
			else if (color == (byte)Enums.ColorType.White)
			{
				return SFML.Graphics.Color.White;
			}
			else
			{
				return SFML.Graphics.Color.White;
			}
		}
		
		internal static char[] SplitChars = new char[] {' ', '-', ControlChars.Tab};
		
		internal enum WrapMode
		{
			Characters,
			Font
		}
		
		internal enum WrapType
		{
			None,
			BreakWord,
			Whitespace,
			Smart
		}
		
		internal static List<string> WordWrap(string str, int width, WrapMode mode, WrapType type, byte size)
		{
			List<string> lines = new List<string>();
			string line = "";
			string nextLine = "";
			
			if (!(str == ""))
			{
				foreach (var word in Explode(str, SplitChars))
				{
					var trim = word.Trim();
					var currentType = type;
					do
					{
						var baseLine = line.Length < 1 ? "" : line + " ";
						var newLine = nextLine.Length < 1 ? baseLine + trim : nextLine;
						nextLine = "";
						
						if (mode == WrapMode.Font ? Convert.ToBoolean(GetTextWidth(System.Convert.ToString(newLine), size)) : newLine.Length < width)
						{
							line = System.Convert.ToString(newLine);
						}
						else if (mode == WrapMode.Font ? Convert.ToBoolean(GetTextWidth(System.Convert.ToString(newLine), size)) : newLine.Length == width)
						{
							lines.Add(newLine);
							line = "";
						}
						else
						{
							if (currentType == WrapType.None)
							{
								line = System.Convert.ToString(newLine);
							}
							else if (currentType == WrapType.Whitespace)
							{
								lines.Add(line.Length < 1 ? newLine : line);
								line = System.Convert.ToString(line.Length < 1 ? "" : trim);
							}
							else if (currentType == WrapType.BreakWord)
							{
								var remaining = trim;
								do
								{
									if ((mode == WrapMode.Font ? (GetTextWidth(System.Convert.ToString(baseLine), size)) : baseLine.Length) > width)
									{
										lines.Add(line);
										baseLine = "";
										line = "";
									}
									
									var i = remaining.Length - 1;
									while (-1 < i)
									{
										switch (mode)
										{
											case WrapMode.Font:
												if (!(width < GetTextWidth(baseLine + remaining.Substring(0, i) + "-", size)))
												{
													goto endOfWhileLoop;
												}
												break;
												
											case WrapMode.Characters:
												if (!(width < (baseLine + remaining.Substring(0, i) + "-").Length))
												{
													goto endOfWhileLoop;
												}
												break;
										}
										i--;
									}
endOfWhileLoop:
									
									line = System.Convert.ToString(baseLine + remaining.Substring(0, i + 1) + (remaining.Length <= i + 1 ? "" : "-"));
									lines.Add(line);
									line = "";
									baseLine = "";
									remaining = remaining.Substring(i + 1);
								} while ((remaining.Length > 0) && (width < (mode == WrapMode.Font ? (GetTextWidth(System.Convert.ToString(remaining), size)) : remaining.Length)));
								line = System.Convert.ToString(remaining);
							}
							else if (currentType == WrapType.Smart)
							{
								if ((line.Length < 1) || (width < (mode == WrapMode.Font ? (GetTextWidth(System.Convert.ToString(trim), size)) : trim.Length)))
								{
									currentType = WrapType.BreakWord;
								}
								else
								{
									currentType = WrapType.Whitespace;
								}
								nextLine = System.Convert.ToString(newLine);
								
							}
						}
					} while (nextLine.Length > 0);
				}
			}
			
			if (line.Length > 0)
			{
				lines.Add(line);
			}
			
			return lines;
		}
		
		internal static string[] Explode(string str, char[] splitChars)
		{
			string[] returnValue = default(string[]);
			
			List<string> parts = new List<string>();
			int startindex = 0;
			returnValue = null;
			
			if (str == null)
			{
				return returnValue;
			}
			
			while (true)
			{
				int index = str.IndexOfAny(splitChars, startindex);
				
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
		
		internal static void DrawChatBubble(int index)
		{
			List<string> theArray = default(List<string>);
			int x = 0;
			int y = 0;
			int i = 0;
			int maxWidth = 0;
			int x2 = 0;
			int y2 = 0;
			
			if (C_Variables.ChatBubble[index].TargetType == (byte)Enums.TargetType.Player)
			{
				// it's a player
				if (C_Player.GetPlayerMap(System.Convert.ToInt32(C_Variables.ChatBubble[index].Target)) == C_Player.GetPlayerMap(C_Variables.Myindex))
				{
					// it's on our map - get co-ords
					x = C_Graphics.ConvertMapX((C_Types.Player[C_Variables.ChatBubble[index].Target].X * 32) + C_Types.Player[C_Variables.ChatBubble[index].Target].XOffset) + 16;
					y = C_Graphics.ConvertMapY((C_Types.Player[C_Variables.ChatBubble[index].Target].Y * 32) + C_Types.Player[C_Variables.ChatBubble[index].Target].YOffset) - 40;
				}
			}
			else if (C_Variables.ChatBubble[index].TargetType == (byte)Enums.TargetType.Npc)
			{
				// it's on our map - get co-ords
				x = C_Graphics.ConvertMapX((C_Maps.MapNpc[C_Variables.ChatBubble[index].Target].X * 32) + C_Maps.MapNpc[C_Variables.ChatBubble[index].Target].XOffset) + 16;
				y = C_Graphics.ConvertMapY((C_Maps.MapNpc[C_Variables.ChatBubble[index].Target].Y * 32) + C_Maps.MapNpc[C_Variables.ChatBubble[index].Target].YOffset) - 40;
			}
			else if (C_Variables.ChatBubble[index].TargetType == (byte)Enums.TargetType.Event)
			{
				x = C_Graphics.ConvertMapX((C_Maps.Map.MapEvents[C_Variables.ChatBubble[index].Target].X * 32) + C_Maps.Map.MapEvents[C_Variables.ChatBubble[index].Target].XOffset) + 16;
				y = C_Graphics.ConvertMapY((C_Maps.Map.MapEvents[C_Variables.ChatBubble[index].Target].Y * 32) + C_Maps.Map.MapEvents[C_Variables.ChatBubble[index].Target].YOffset) - 40;
			}
			// word wrap the text
			theArray = WordWrap(System.Convert.ToString(C_Variables.ChatBubble[index].Msg), C_Constants.ChatBubbleWidth, WrapMode.Font, WrapType.Smart, 13);
			// find max width
			for (i = 0; i <= theArray.Count - 1; i++)
			{
				if (GetTextWidth(theArray[i]) > maxWidth)
				{
					maxWidth = GetTextWidth(theArray[i]);
				}
			}
			// calculate the new position
			x2 = x - (maxWidth / 2);
			y2 = y - (theArray.Count * 12);
			
			// render bubble - top left
			C_Graphics.RenderTextures(C_Graphics.ChatBubbleGfx, C_Graphics.GameWindow, x2 - 9, y2 - 5, 0, 0, 9, 5, 9, 5);
			// top right
			C_Graphics.RenderTextures(C_Graphics.ChatBubbleGfx, C_Graphics.GameWindow, x2 + maxWidth, y2 - 5, 119, 0, 9, 5, 9, 5);
			// top
			C_Graphics.RenderTextures(C_Graphics.ChatBubbleGfx, C_Graphics.GameWindow, x2, y2 - 5, 10, 0, maxWidth, 5, 5, 5);
			// bottom left
			C_Graphics.RenderTextures(C_Graphics.ChatBubbleGfx, C_Graphics.GameWindow, x2 - 9, y, 0, 19, 9, 6, 9, 6);
			// bottom right
			C_Graphics.RenderTextures(C_Graphics.ChatBubbleGfx, C_Graphics.GameWindow, x2 + maxWidth, y, 119, 19, 9, 6, 9, 6);
			// bottom - left half
			C_Graphics.RenderTextures(C_Graphics.ChatBubbleGfx, C_Graphics.GameWindow, x2, y, 10, 19, System.Convert.ToSingle((maxWidth / 2) - 5), 6, 9, 6);
			// bottom - right half
			C_Graphics.RenderTextures(C_Graphics.ChatBubbleGfx, C_Graphics.GameWindow, x2 + (maxWidth / 2) + 6, y, 10, 19, System.Convert.ToSingle((maxWidth / 2) - 5), 6, 9, 6);
			// left
			C_Graphics.RenderTextures(C_Graphics.ChatBubbleGfx, C_Graphics.GameWindow, x2 - 9, y2, 0, 6, 9, theArray.Count * 12, 9, 1);
			// right
			C_Graphics.RenderTextures(C_Graphics.ChatBubbleGfx, C_Graphics.GameWindow, x2 + maxWidth, y2, 119, 6, 9, theArray.Count * 12, 9, 1);
			// center
			C_Graphics.RenderTextures(C_Graphics.ChatBubbleGfx, C_Graphics.GameWindow, x2, y2, 9, 5, maxWidth, theArray.Count * 12, 1, 1);
			// little pointy bit
			C_Graphics.RenderTextures(C_Graphics.ChatBubbleGfx, C_Graphics.GameWindow, x - 5, y, 58, 19, 11, 11, 11, 11);
			
			// render each line centralised
			for (i = 0; i <= theArray.Count - 1; i++)
			{
				DrawText(System.Convert.ToInt32(x - ((double) GetTextWidth(theArray[i]) / 2)), y2, theArray[i], C_Graphics.ToSfmlColor(System.Drawing.ColorTranslator.FromOle(Information.QBColor(System.Convert.ToInt32(C_Variables.ChatBubble[index].Colour)))), Color.Black, C_Graphics.GameWindow);
				y2 = y2 + 12;
			}
			// check if it's timed out - close it if so
			if (C_Variables.ChatBubble[index].Timer + 5000 < C_General.GetTickCount())
			{
				C_Variables.ChatBubble[index].Active = false;
			}
			
		}
		
	}
}
