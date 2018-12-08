using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Text;
using SFML.Graphics;
using SFML.Window;

namespace Engine
{
    static class E_Text
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

        internal static void DrawText(int X, int y, string text,  Color color,  Color BackColor, ref RenderWindow target, byte TextSize = E_Globals.FONT_SIZE)
        {
            Text mystring = new Text(text, E_Graphics.SFMLGameFont)
            {
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
            int TextX;
            int TextY;
             Color color = new  Color();
             Color backcolor = new  Color();
            int npcNum;

            npcNum = E_Types.MapNpc[MapNpcNum].Num;

            switch (Types.Npc[npcNum].Behaviour)
            {
                case 0 // attack on sight
               :
                    {
                        color = Color.Red;
                        backcolor = Color.Black;
                        break;
                    }

                case 1:
                case 4 // attack when attacked + guard
         :
                    {
                        color = Color.Green;
                        backcolor = Color.Black;
                        break;
                    }

                case 2:
                case 3:
                case 5 // friendly + shopkeeper + quest
         :
                    {
                        color = Color.Yellow;
                        backcolor = Color.Black;
                        break;
                    }
            }

            TextX = E_Graphics.ConvertMapX(E_Types.MapNpc[MapNpcNum].X * E_Globals.PIC_X) + E_Types.MapNpc[MapNpcNum].XOffset + (E_Globals.PIC_X / 2) - GetTextWidth((Microsoft.VisualBasic.Strings.Trim(Types.Npc[npcNum].Name))) / (int)2;
            if (Types.Npc[npcNum].Sprite < 1 || Types.Npc[npcNum].Sprite > E_Graphics.NumCharacters)
                TextY = E_Graphics.ConvertMapY(E_Types.MapNpc[MapNpcNum].Y * E_Globals.PIC_Y) + E_Types.MapNpc[MapNpcNum].YOffset - 16;
            else
                TextY = E_Graphics.ConvertMapY(E_Types.MapNpc[MapNpcNum].Y * E_Globals.PIC_Y) + E_Types.MapNpc[MapNpcNum].YOffset - (E_Graphics.CharacterGFXInfo[Types.Npc[npcNum].Sprite].height / (int)4) + 16;

            // Draw name
            DrawText(TextX, TextY, Microsoft.VisualBasic.Strings.Trim(Types.Npc[npcNum].Name), color, backcolor, ref E_Graphics.GameWindow);
        }

        internal static void DrawEventName(int index)
        {
            int TextX = 0;
            int TextY = 0;
            Color color;
            Color backcolor;
            string Name;

            if (E_Globals.InMapEditor)
                return;

            color = Color.Yellow;
            backcolor = Color.Black;

            Name = Microsoft.VisualBasic.Strings.Trim(E_Types.Map.MapEvents[index].Name);
            // calc pos
            TextX = E_Graphics.ConvertMapX(E_Types.Map.MapEvents[index].X * E_Globals.PIC_X) + E_Types.Map.MapEvents[index].XOffset + (E_Globals.PIC_X / 2) - GetTextWidth(Microsoft.VisualBasic.Strings.Trim(Name)) / (int)2;
            if (E_Types.Map.MapEvents[index].GraphicType == 0)
                TextY = E_Graphics.ConvertMapY(E_Types.Map.MapEvents[index].Y * E_Globals.PIC_Y) + E_Types.Map.MapEvents[index].YOffset - 16;
            else if (E_Types.Map.MapEvents[index].GraphicType == 1)
            {
                if (E_Types.Map.MapEvents[index].GraphicNum < 1 || E_Types.Map.MapEvents[index].GraphicNum > E_Graphics.NumCharacters)
                    TextY = E_Graphics.ConvertMapY(E_Types.Map.MapEvents[index].Y * E_Globals.PIC_Y) + E_Types.Map.MapEvents[index].YOffset - 16;
                else
                    // Determine location for text
                    TextY = E_Graphics.ConvertMapY(E_Types.Map.MapEvents[index].Y * E_Globals.PIC_Y) + E_Types.Map.MapEvents[index].YOffset - (E_Graphics.CharacterGFXInfo[E_Types.Map.MapEvents[index].GraphicNum].height / (int)4) + 16;
            }
            else if (E_Types.Map.MapEvents[index].GraphicType == 2)
            {
                if (E_Types.Map.MapEvents[index].GraphicY2 > 0)
                    TextY = E_Graphics.ConvertMapY(E_Types.Map.MapEvents[index].Y * E_Globals.PIC_Y) + E_Types.Map.MapEvents[index].YOffset - (E_Types.Map.MapEvents[index].GraphicY2 * E_Globals.PIC_Y) + 16;
                else
                    TextY = E_Graphics.ConvertMapY(E_Types.Map.MapEvents[index].Y * E_Globals.PIC_Y) + E_Types.Map.MapEvents[index].YOffset - 32 + 16;
            }

            // Draw name
            DrawText(TextX, TextY, Microsoft.VisualBasic.Strings.Trim(Name), color, backcolor, ref E_Graphics.GameWindow);
        }

        internal static void DrawMapAttributes()
        {
            int X;
            int y;
            int tX;
            int tY;
            RectangleShape rec = new RectangleShape();

            if (E_Globals.SelectedTab == 2)
            {
                var loopTo = E_Globals.TileView.Right;
                for (X = E_Globals.TileView.Left; X <= loopTo; X++)
                {
                    var loopTo1 = E_Globals.TileView.Bottom;
                    for (y = E_Globals.TileView.Top; y <= loopTo1; y++)
                    {
                        if (E_Graphics.IsValidMapPoint(X, y))
                        {
                            {
                                var withBlock = E_Types.Map.Tile[X, y];
                                tX = ((E_Graphics.ConvertMapX(X * E_Globals.PIC_X)) - 4) + (int)(E_Globals.PIC_X * 0.5);
                                tY = ((E_Graphics.ConvertMapY(y * E_Globals.PIC_Y)) - 7) + (int)(E_Globals.PIC_Y * 0.5);

                                rec.OutlineColor = new  Color( Color.White);
                                rec.OutlineThickness = 0.6F;

                                rec.Size = new Vector2f((E_Globals.PIC_X), (E_Globals.PIC_X));
                                rec.Position = new Vector2f(E_Graphics.ConvertMapX((X) * E_Globals.PIC_X), E_Graphics.ConvertMapY((y) * E_Globals.PIC_Y));

                                switch (withBlock.Type)
                                {
                                    case (byte)Enums.TileType.Blocked:
                                        {
                                            rec.FillColor = new  Color(255, 0, 0, 100);
                                            E_Graphics.GameWindow.Draw(rec);
                                            DrawText(tX, tY, "B", ( Color.White), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.Warp:
                                        {
                                            DrawText(tX, tY, "W", ( Color.Blue), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.Item:
                                        {
                                            DrawText(tX, tY, "I", ( Color.White), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.NpcAvoid:
                                        {
                                            DrawText(tX, tY, "N", ( Color.White), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.Key:
                                        {
                                            DrawText(tX, tY, "K", ( Color.White), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.KeyOpen:
                                        {
                                            DrawText(tX, tY, "KO", ( Color.White), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.Resource:
                                        {
                                            DrawText(tX, tY, "R", ( Color.Green), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.Door:
                                        {
                                            DrawText(tX, tY, "D", ( Color.Black), ( Color.Red), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.NpcSpawn:
                                        {
                                            rec.FillColor = new  Color(255, 255, 0, 100);
                                            E_Graphics.GameWindow.Draw(rec);
                                            DrawText(tX, tY, "S", ( Color.White), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.Shop:
                                        {
                                            DrawText(tX, tY, "SH", ( Color.Blue), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.Bank:
                                        {
                                            DrawText(tX, tY, "BA", ( Color.Blue), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.Heal:
                                        {
                                            DrawText(tX, tY, "H", ( Color.Green), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.Trap:
                                        {
                                            DrawText(tX, tY, "T", ( Color.Red), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.House:
                                        {
                                            DrawText(tX, tY, "H", ( Color.Green), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.Craft:
                                        {
                                            DrawText(tX, tY, "C", ( Color.Green), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }

                                    case (byte)Enums.TileType.Light:
                                        {
                                            DrawText(tX, tY, "L", ( Color.Yellow), ( Color.Black), ref E_Graphics.GameWindow);
                                            break;
                                        }
                                }
                            }
                        }
                    }
                }
            }
        }

        internal static int GetTextWidth(string text, byte textsize = E_Globals.FONT_SIZE)
        {
            Text mystring = new Text(text, E_Graphics.SFMLGameFont);
            FloatRect textBounds;
            mystring.CharacterSize = textsize;
            textBounds = mystring.GetLocalBounds();
            return (int)textBounds.Width;
        }

        internal static  Color GetSFMLColor(byte Ccolor)
        {
            switch (Ccolor)
            {
                case (byte)Enums.ColorType.Black:
                    {
                        return  Color.Black;
                    }

                case (byte)Enums.ColorType.Blue:
                    {
                        return new  Color(73, 151, 208);
                    }

                case (byte)Enums.ColorType.Green:
                    {
                        return new  Color(102, 255, 0, 180);
                    }

                case (byte)Enums.ColorType.Cyan:
                    {
                        return new  Color(0, 139, 139);
                    }

                case (byte)Enums.ColorType.Red:
                    {
                        return new  Color(255, 0, 0, 180);
                    }

                case (byte)Enums.ColorType.Magenta:
                    {
                        return  Color.Magenta;
                    }

                case (byte)Enums.ColorType.Brown:
                    {
                        return new  Color(139, 69, 19);
                    }

                case (byte)Enums.ColorType.Gray:
                    {
                        return new  Color(211, 211, 211);
                    }

                case (byte)Enums.ColorType.DarkGray:
                    {
                        return new  Color(169, 169, 169);
                    }

                case (byte)Enums.ColorType.BrightBlue:
                    {
                        return new  Color(0, 191, 255);
                    }

                case (byte)Enums.ColorType.BrightGreen:
                    {
                        return new  Color(0, 255, 0);
                    }

                case (byte)Enums.ColorType.BrightCyan:
                    {
                        return new  Color(0, 255, 255);
                    }

                case (byte)Enums.ColorType.BrightRed:
                    {
                        return new  Color(255, 0, 0);
                    }

                case (byte)Enums.ColorType.Pink:
                    {
                        return new  Color(255, 192, 203);
                    }

                case (byte)Enums.ColorType.Yellow:
                    {
                        return  Color.Yellow;
                    }

                case (byte)Enums.ColorType.White:
                    {
                        return  Color.White;
                    }

                default:
                    {
                        return  Color.White;
                    }
            }
        }

        internal static char[] SplitChars = new char[] { ' ', '-', ControlChars.Tab };

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
                i += 1;
            }

            string[] lines = strBuilder.ToString().Split('|');
            foreach (string line in lines)
                // line = Replace(line, "|", "")
                rtnString.Add(line.Replace("|", ""));// & vbNewLine)

            return rtnString;
        }

        internal static string[] Explode(string str, char[] splitChars)
        {
            List<string> parts = new List<string>();
            int startindex = 0;
            while (true)
            {
                int index = str.IndexOfAny(splitChars, startindex);

                if (index == -1)
                {
                    parts.Add(str.Substring(startindex));
                    return parts.ToArray();
                }

                string word = str.Substring(startindex, index - startindex);
                char nextChar = str.Substring(index, 1)[0];
                // Dashes and the likes should stick to the word occuring before it. Whitespace doesn't have to.
                if (char.IsWhiteSpace(nextChar))
                {
                    parts.Add(word);
                    parts.Add(nextChar.ToString());
                }
                else
                    parts.Add(word + nextChar);

                startindex = index + 1;
            }
        }
    }
}
