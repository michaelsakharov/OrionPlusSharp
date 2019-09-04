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
using static Engine.modTypes;
using static Engine.Types;
using static Engine.S_Events;
using static Engine.S_Quest;
using static Engine.S_Housing;

namespace Engine
{
    static class modDatabase
    {
        internal static void CreateClasses()
        {
            XmlClass myXml = new XmlClass()
            {
                Filename = Path.Combine(Application.StartupPath, "data", "Classes.xml"),
                Root = "Data"
            };

            myXml.NewXmlDocument();

            S_Globals.Max_Classes = 1;

            myXml.LoadXml();

            myXml.WriteString("INIT", "MaxClasses", S_Globals.Max_Classes.ToString());
            myXml.WriteString("CLASS1", "Name", "Warrior");
            myXml.WriteString("CLASS1", "Desc", "Warrior Description");
            myXml.WriteString("CLASS1", "MaleSprite", "1");
            myXml.WriteString("CLASS1", "FemaleSprite", "2");
            myXml.WriteString("CLASS1", "Str", "5");
            myXml.WriteString("CLASS1", "End", "5");
            myXml.WriteString("CLASS1", "Vit", "5");
            myXml.WriteString("CLASS1", "Luck", "5");
            myXml.WriteString("CLASS1", "Int", "5");
            myXml.WriteString("CLASS1", "Spir", "5");
            myXml.WriteString("CLASS1", "BaseExp", "25");

            myXml.WriteString("CLASS1", "StartMap", modTypes.Options.StartMap.ToString());
            myXml.WriteString("CLASS1", "StartX", modTypes.Options.StartX.ToString());
            myXml.WriteString("CLASS1", "StartY", modTypes.Options.StartY.ToString());

            myXml.CloseXml(true);
        }

        public static void ClearClasses()
        {
            int i;

            Types.Classes = new ClassRec[S_Globals.Max_Classes + 1];
            var loopTo = S_Globals.Max_Classes;
            for (i = 1; i <= loopTo; i++)
            {
                Types.Classes[i] = default(ClassRec);
                Types.Classes[i].Name = "";
                Types.Classes[i].Desc = "";
            }

            var loopTo1 = S_Globals.Max_Classes;
            for (i = 0; i <= loopTo1; i++)
            {
                Types.Classes[i].Stat = new byte[7];
                Types.Classes[i].StartItem = new int[6];
                Types.Classes[i].StartValue = new int[6];
            }
        }

        public static void LoadClasses()
        {
            int i;
            int n;
            string tmpSprite;
            string[] tmpArray;
            int x;

            if (!File.Exists(Path.Combine(Application.StartupPath, "data", "Classes.xml")))
                CreateClasses();

            XmlClass myXml = new XmlClass()
            {
                Filename = Path.Combine(Application.StartupPath, "data", "Classes.xml"),
                Root = "Data"
            };

            myXml.LoadXml();

            S_Globals.Max_Classes = (byte)Conversion.Val(myXml.ReadString("INIT", "MaxClasses", "1"));

            ClearClasses();
            var loopTo = S_Globals.Max_Classes;
            for (i = 1; i <= loopTo; i++)
            {
                Types.Classes[i].Name = myXml.ReadString("CLASS" + i, "Name");
                Types.Classes[i].Desc = myXml.ReadString("CLASS" + i, "Desc");

                // read string of sprites
                tmpSprite = myXml.ReadString("CLASS" + i, "MaleSprite");
                // split into an array of strings
                tmpArray = Microsoft.VisualBasic.Strings.Split(tmpSprite, ",");
                // redim the class sprite array
                Types.Classes[i].MaleSprite = new int[Information.UBound(tmpArray) + 1];
                var loopTo1 = Information.UBound(tmpArray);
                // loop through converting strings to values and store in the sprite array
                for (n = 0; n <= loopTo1; n++)
                    Types.Classes[i].MaleSprite[n] = (byte)Conversion.Val(tmpArray[n]);

                // read string of sprites
                tmpSprite = myXml.ReadString("CLASS" + i, "FemaleSprite");
                // split into an array of strings
                tmpArray = Microsoft.VisualBasic.Strings.Split(tmpSprite, ",");
                // redim the class sprite array
                Types.Classes[i].FemaleSprite = new int[Information.UBound(tmpArray) + 1];
                var loopTo2 = Information.UBound(tmpArray);
                // loop through converting strings to values and store in the sprite array
                for (n = 0; n <= loopTo2; n++)
                    Types.Classes[i].FemaleSprite[n] = (byte)Conversion.Val(tmpArray[n]);

                // continue
                Types.Classes[i].Stat[(int)Enums.StatType.Strength] = (byte)Conversion.Val(myXml.ReadString("CLASS" + i, "Str"));
                Types.Classes[i].Stat[(int)Enums.StatType.Endurance] = (byte)Conversion.Val(myXml.ReadString("CLASS" + i, "End"));
                Types.Classes[i].Stat[(int)Enums.StatType.Vitality] = (byte)Conversion.Val(myXml.ReadString("CLASS" + i, "Vit"));
                Types.Classes[i].Stat[(int)Enums.StatType.Luck] = (byte)Conversion.Val(myXml.ReadString("CLASS" + i, "Luck"));
                Types.Classes[i].Stat[(int)Enums.StatType.Intelligence] = (byte)Conversion.Val(myXml.ReadString("CLASS" + i, "Int"));
                Types.Classes[i].Stat[(int)Enums.StatType.Spirit] = (byte)Conversion.Val(myXml.ReadString("CLASS" + i, "Speed"));

                Types.Classes[i].BaseExp = (byte)Conversion.Val(myXml.ReadString("CLASS" + i, "BaseExp"));

                Types.Classes[i].StartMap = (byte)Conversion.Val(myXml.ReadString("CLASS" + i, "StartMap"));
                Types.Classes[i].StartX = (byte)Conversion.Val(myXml.ReadString("CLASS" + i, "StartX"));
                Types.Classes[i].StartY = (byte)Conversion.Val(myXml.ReadString("CLASS" + i, "StartY"));

                // loop for items & values
                for (x = 1; x <= 5; x++)
                {
                    Types.Classes[i].StartItem[x] = (byte)Conversion.Val(myXml.ReadString("CLASS" + i, "StartItem" + x));
                    Types.Classes[i].StartValue[x] = (byte)Conversion.Val(myXml.ReadString("CLASS" + i, "StartValue" + x));
                }
            }

            myXml.CloseXml(false);
        }

        public static void SaveClasses()
        {
            string tmpstring = "";
            int i;
            int x;

            XmlClass myXml = new XmlClass()
            {
                Filename = Path.Combine(Application.StartupPath, "data", "Classes.xml"),
                Root = "Data"
            };

            myXml.LoadXml();

            myXml.WriteString("INIT", "MaxClasses", Conversion.Str(S_Globals.Max_Classes));
            var loopTo = S_Globals.Max_Classes;
            for (i = 1; i <= loopTo; i++)
            {
                myXml.WriteString("CLASS" + i, "Name", Microsoft.VisualBasic.Strings.Trim(Types.Classes[i].Name));
                myXml.WriteString("CLASS" + i, "Desc", Microsoft.VisualBasic.Strings.Trim(Types.Classes[i].Desc));

                tmpstring = "";
                var loopTo1 = Information.UBound(Types.Classes[i].MaleSprite);
                for (x = 0; x <= loopTo1; x++)
                    tmpstring = tmpstring + System.Convert.ToString(Types.Classes[i].MaleSprite[x]) + ",";

                myXml.WriteString("CLASS" + i, "MaleSprite", tmpstring.TrimEnd(','));

                tmpstring = "";
                var loopTo2 = Information.UBound(Types.Classes[i].FemaleSprite);
                for (x = 0; x <= loopTo2; x++)
                    tmpstring = tmpstring + System.Convert.ToString(Types.Classes[i].FemaleSprite[x]) + ",";
                myXml.WriteString("CLASS" + i, "FemaleSprite", tmpstring.TrimEnd(','));

                tmpstring = "";

                myXml.WriteString("CLASS" + i, "Str", Conversion.Str(Types.Classes[i].Stat[(byte)Enums.StatType.Strength]));
                myXml.WriteString("CLASS" + i, "End", Conversion.Str(Types.Classes[i].Stat[(byte)Enums.StatType.Endurance]));
                myXml.WriteString("CLASS" + i, "Vit", Conversion.Str(Types.Classes[i].Stat[(byte)Enums.StatType.Vitality]));
                myXml.WriteString("CLASS" + i, "Luck", Conversion.Str(Types.Classes[i].Stat[(byte)Enums.StatType.Luck]));
                myXml.WriteString("CLASS" + i, "Int", Conversion.Str(Types.Classes[i].Stat[(byte)Enums.StatType.Intelligence]));
                myXml.WriteString("CLASS" + i, "Speed", Conversion.Str(Types.Classes[i].Stat[(byte)Enums.StatType.Spirit]));

                myXml.WriteString("CLASS" + i, "BaseExp", Conversion.Str(Types.Classes[i].BaseExp));

                myXml.WriteString("CLASS" + i, "StartMap", Conversion.Str(Types.Classes[i].StartMap));
                myXml.WriteString("CLASS" + i, "StartX", Conversion.Str(Types.Classes[i].StartX));
                myXml.WriteString("CLASS" + i, "StartY", Conversion.Str(Types.Classes[i].StartY));

                // loop for items & values
                for (x = 1; x <= 5; x++)
                {
                    myXml.WriteString("CLASS" + i, "StartItem" + x, Conversion.Str(Types.Classes[i].StartItem[x]));
                    myXml.WriteString("CLASS" + i, "StartValue" + x, Conversion.Str(Types.Classes[i].StartValue[x]));
                }
            }

            myXml.CloseXml(true);
        }

        public static int GetClassMaxVital(int ClassNum, Enums.VitalType Vital)
        {
            int GetClassMaxVital = 0;

            switch (Vital)
            {
                case Enums.VitalType.HP:
                    {
                        GetClassMaxVital = (1 + (Types.Classes[ClassNum].Stat[(byte)Enums.StatType.Vitality] / 2) + Types.Classes[ClassNum].Stat[(byte)Enums.StatType.Vitality]) * 2;
                        break;
                    }

                case Enums.VitalType.MP:
                    {
                        GetClassMaxVital = (1 + (Types.Classes[ClassNum].Stat[(byte)Enums.StatType.Intelligence] / 2) + Types.Classes[ClassNum].Stat[(byte)Enums.StatType.Intelligence]) * 2;
                        break;
                    }

                case Enums.VitalType.SP:
                    {
                        GetClassMaxVital = (1 + (Types.Classes[ClassNum].Stat[(byte)Enums.StatType.Spirit] / 2) + Types.Classes[ClassNum].Stat[(byte)Enums.StatType.Spirit]) * 2;
                        break;
                    }
            }
            return GetClassMaxVital;
        }

        public static string GetClassName(int ClassNum)
        {
            return Microsoft.VisualBasic.Strings.Trim(Types.Classes[ClassNum].Name);
        }



        public static void CheckMaps()
        {
            for (var i = 1; i <= Constants.MAX_MAPS; i++)
            {
                if (!File.Exists(Path.Combine(Application.StartupPath, "data", "maps", string.Format("map{0}.dat", i))))
                    SaveMap(i);
            }
        }

        public static void ClearMaps()
        {
            for (var i = 1; i <= S_Instances.MAX_CACHED_MAPS; i++)
                ClearMap(i);
        }

        public static void ClearMap(int mapNum)
        {
            int x;
            int y;
            modTypes.Map[mapNum] = default(MapRec);
            modTypes.Map[mapNum].Tileset = 1;
            modTypes.Map[mapNum].Name = "";
            modTypes.Map[mapNum].MaxX = S_Constants.MAX_MAPX;
            modTypes.Map[mapNum].MaxY = S_Constants.MAX_MAPY;
            modTypes.Map[mapNum].Npc = new int[Constants.MAX_MAP_NPCS + 1];
            modTypes.Map[mapNum].Tile = new TileRec[modTypes.Map[mapNum].MaxX + 1, modTypes.Map[mapNum].MaxY + 1];

            for (x = 0; x <= S_Constants.MAX_MAPX; x++)
            {
                for (y = 0; y <= S_Constants.MAX_MAPY; y++)
                    modTypes.Map[mapNum].Tile[x, y].Layer = new TileDataRec[6];
            }

            modTypes.Map[mapNum].EventCount = 0;
            modTypes.Map[mapNum].Events = new EventStruct[1];

            // Reset the values for if a player is on the map or not
            modTypes.PlayersOnMap[mapNum] = 0;
            modTypes.Map[mapNum].Tileset = 1;
            modTypes.Map[mapNum].Name = "";
            modTypes.Map[mapNum].Music = "";
            modTypes.Map[mapNum].MaxX = S_Constants.MAX_MAPX;
            modTypes.Map[mapNum].MaxY = S_Constants.MAX_MAPY;

            ClearTempTile(mapNum);
        }

        public static void SaveMaps()
        {
            int i;

            for (i = 1; i <= Constants.MAX_MAPS; i++)
            {
                SaveMap(i);
                SaveMapEvent(i);
            }
        }

        public static void SaveMap(int mapNum)
        {
            string filename;
            int x;
            int y;
            int l;

            filename = Path.Combine(Application.StartupPath, "data", "maps", string.Format("map{0}.dat", mapNum));
            ByteStream writer = new ByteStream(100);
            writer.WriteString(modTypes.Map[mapNum].Name);
            writer.WriteString(modTypes.Map[mapNum].Music);
            writer.WriteInt32(modTypes.Map[mapNum].Revision);
            writer.WriteByte(modTypes.Map[mapNum].Moral);
            writer.WriteInt32(modTypes.Map[mapNum].Tileset);
            writer.WriteInt32(modTypes.Map[mapNum].Up);
            writer.WriteInt32(modTypes.Map[mapNum].Down);
            writer.WriteInt32(modTypes.Map[mapNum].Left);
            writer.WriteInt32(modTypes.Map[mapNum].Right);
            writer.WriteInt32(modTypes.Map[mapNum].BootMap);
            writer.WriteByte(modTypes.Map[mapNum].BootX);
            writer.WriteByte(modTypes.Map[mapNum].BootY);
            writer.WriteByte(modTypes.Map[mapNum].MaxX);
            writer.WriteByte(modTypes.Map[mapNum].MaxY);
            writer.WriteByte(modTypes.Map[mapNum].WeatherType);
            writer.WriteInt32(modTypes.Map[mapNum].Fogindex);
            writer.WriteInt32(modTypes.Map[mapNum].WeatherIntensity);
            writer.WriteByte(modTypes.Map[mapNum].FogAlpha);
            writer.WriteByte(modTypes.Map[mapNum].FogSpeed);
            writer.WriteByte(modTypes.Map[mapNum].HasMapTint);
            writer.WriteByte(modTypes.Map[mapNum].MapTintR);
            writer.WriteByte(modTypes.Map[mapNum].MapTintG);
            writer.WriteByte(modTypes.Map[mapNum].MapTintB);
            writer.WriteByte(modTypes.Map[mapNum].MapTintA);

            writer.WriteByte(modTypes.Map[mapNum].Instanced);
            writer.WriteByte(modTypes.Map[mapNum].Panorama);
            writer.WriteByte(modTypes.Map[mapNum].Parallax);
            writer.WriteByte(modTypes.Map[mapNum].Brightness);
            var loopTo = modTypes.Map[mapNum].MaxX;
            for (x = 0; x <= loopTo; x++)
            {
                var loopTo1 = modTypes.Map[mapNum].MaxY;
                for (y = 0; y <= loopTo1; y++)
                {
                    writer.WriteInt32(modTypes.Map[mapNum].Tile[x, y].Data1);
                    writer.WriteInt32(modTypes.Map[mapNum].Tile[x, y].Data2);
                    writer.WriteInt32(modTypes.Map[mapNum].Tile[x, y].Data3);
                    writer.WriteByte(modTypes.Map[mapNum].Tile[x, y].DirBlock);
                    for (l = 0; l <= (byte)Enums.LayerType.Count - 1; l++)
                    {
                        writer.WriteByte(modTypes.Map[mapNum].Tile[x, y].Layer[l].Tileset);
                        writer.WriteByte(modTypes.Map[mapNum].Tile[x, y].Layer[l].X);
                        writer.WriteByte(modTypes.Map[mapNum].Tile[x, y].Layer[l].Y);
                        writer.WriteByte(modTypes.Map[mapNum].Tile[x, y].Layer[l].AutoTile);
                    }
                    writer.WriteByte(modTypes.Map[mapNum].Tile[x, y].Type);
                }
            }

            for (x = 1; x <= Constants.MAX_MAP_NPCS; x++)
                writer.WriteInt32(modTypes.Map[mapNum].Npc[x]);

            BinaryFile.Save(filename, ref writer);
        }

        public static void SaveMapEvent(int mapNum)
        {
            XmlClass myXml = new XmlClass()
            {
                Filename = Application.StartupPath + @"\data\maps\map" + mapNum + "_eventdata.xml",
                Root = "Data"
            };

            if (!File.Exists(Application.StartupPath + @"\data\maps\map" + mapNum + "_eventdata.xml"))
                myXml.NewXmlDocument();

            myXml.LoadXml();

            // This is for event saving, it is in .xml files because there are non-limited values (strings) that cannot easily be loaded/saved in the normal manner.
            myXml.WriteString("Events", "EventCount", modTypes.Map[mapNum].EventCount.ToString());

            if (modTypes.Map[mapNum].EventCount > 0)
            {
                var loopTo = modTypes.Map[mapNum].EventCount;
                for (var i = 1; i <= loopTo; i++)
                {
                    {
                        myXml.WriteString("Event" + i, "Name", modTypes.Map[mapNum].Events[i].Name);
                        myXml.WriteString("Event" + i, "Global", modTypes.Map[mapNum].Events[i].Globals.ToString());
                        myXml.WriteString("Event" + i, "x", modTypes.Map[mapNum].Events[i].X.ToString());
                        myXml.WriteString("Event" + i, "y", modTypes.Map[mapNum].Events[i].Y.ToString());
                        myXml.WriteString("Event" + i, "PageCount", modTypes.Map[mapNum].Events[i].PageCount.ToString());
                        Console.WriteLine(modTypes.Map[mapNum].Events[i].PageCount);
                    }
                    if (modTypes.Map[mapNum].Events[i].PageCount + 1 > 0)
                    {
                        var loopTo1 = modTypes.Map[mapNum].Events[i].PageCount;
                        for (var x = 1; x <= loopTo1; x++)
                        {
                            {
                                myXml.WriteString("Event" + i + "Page" + x, "chkVariable", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].ChkVariable).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "VariableIndex", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].Variableindex).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "VariableCondition", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].VariableCondition).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "VariableCompare", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].VariableCompare).ToString());

                                myXml.WriteString("Event" + i + "Page" + x, "chkSwitch", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].ChkSwitch).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "SwitchIndex", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].Switchindex).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "SwitchCompare", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].SwitchCompare).ToString());

                                myXml.WriteString("Event" + i + "Page" + x, "chkHasItem", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].ChkHasItem).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "HasItemIndex", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].HasItemindex).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "HasItemAmount", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].HasItemAmount).ToString());

                                myXml.WriteString("Event" + i + "Page" + x, "chkSelfSwitch", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].ChkSelfSwitch).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "SelfSwitchIndex", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].SelfSwitchindex).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "SelfSwitchCompare", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].SelfSwitchCompare).ToString());

                                myXml.WriteString("Event" + i + "Page" + x, "GraphicType", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].GraphicType).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "Graphic", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].Graphic).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "GraphicX", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].GraphicX).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "GraphicY", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].GraphicY).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "GraphicX2", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].GraphicX2).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "GraphicY2", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].GraphicY2).ToString());

                                myXml.WriteString("Event" + i + "Page" + x, "MoveType", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].MoveType).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "MoveSpeed", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].MoveSpeed).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "MoveFreq", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].MoveFreq).ToString());

                                myXml.WriteString("Event" + i + "Page" + x, "IgnoreMoveRoute", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].IgnoreMoveRoute).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "RepeatMoveRoute", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].RepeatMoveRoute).ToString());

                                myXml.WriteString("Event" + i + "Page" + x, "MoveRouteCount", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount).ToString());

                                if (modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount > 0)
                                {
                                    var loopTo2 = modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount;
                                    for (var y = 1; y <= loopTo2; y++)
                                    {
                                        myXml.WriteString("Event" + i + "Page" + x, "MoveRoute" + y + "Index", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Index).ToString());
                                        myXml.WriteString("Event" + i + "Page" + x, "MoveRoute" + y + "Data1", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data1).ToString());
                                        myXml.WriteString("Event" + i + "Page" + x, "MoveRoute" + y + "Data2", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data2).ToString());
                                        myXml.WriteString("Event" + i + "Page" + x, "MoveRoute" + y + "Data3", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data3).ToString());
                                        myXml.WriteString("Event" + i + "Page" + x, "MoveRoute" + y + "Data4", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data4).ToString());
                                        myXml.WriteString("Event" + i + "Page" + x, "MoveRoute" + y + "Data5", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data5).ToString());
                                        myXml.WriteString("Event" + i + "Page" + x, "MoveRoute" + y + "Data6", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data6).ToString());
                                    }
                                }

                                myXml.WriteString("Event" + i + "Page" + x, "WalkAnim", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].WalkAnim).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "DirFix", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].DirFix).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "WalkThrough", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].WalkThrough).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "ShowName", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].ShowName).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "Trigger", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].Trigger).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "CommandListCount", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount).ToString());

                                myXml.WriteString("Event" + i + "Page" + x, "Position", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].Position).ToString());
                                myXml.WriteString("Event" + i + "Page" + x, "QuestNum", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].QuestNum).ToString());

                                myXml.WriteString("Event" + i + "Page" + x, "PlayerGender", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].ChkPlayerGender).ToString());
                            }

                            if (modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount > 0)
                            {
                                var loopTo3 = modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount;
                                for (var y = 1; y <= loopTo3; y++)
                                {
                                    myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "CommandCount", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount).ToString());
                                    myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "ParentList", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].ParentList).ToString());

                                    if (modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount > 0)
                                    {
                                        var loopTo4 = modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount;
                                        for (var z = 1; z <= loopTo4; z++)
                                        {
                                            {
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "Index", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Index).ToString());
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "Text1", modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text1);
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "Text2", modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text2);
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "Text3", modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text3);
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "Text4", modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text4);
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "Text5", modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Text5);
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "Data1", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data1).ToString());
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "Data2", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data2).ToString());
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "Data3", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data3).ToString());
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "Data4", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data4).ToString());
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "Data5", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data5).ToString());
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "Data6", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].Data6).ToString());
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "ConditionalBranchCommandList", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.CommandList).ToString());
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "ConditionalBranchCondition", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Condition).ToString());
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "ConditionalBranchData1", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data1).ToString());
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "ConditionalBranchData2", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data2).ToString());
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "ConditionalBranchData3", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.Data3).ToString());
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "ConditionalBranchElseCommandList", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].ConditionalBranch.ElseCommandList).ToString());
                                                myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "MoveRouteCount", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount).ToString());

                                                if (modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount > 0)
                                                {
                                                    var loopTo5 = modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRouteCount;
                                                    for (var w = 1; w <= loopTo5; w++)
                                                    {
                                                        myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "MoveRoute" + w + "Index", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Index).ToString());
                                                        myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "MoveRoute" + w + "Data1", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data1).ToString());
                                                        myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "MoveRoute" + w + "Data2", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data2).ToString());
                                                        myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "MoveRoute" + w + "Data3", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data3).ToString());
                                                        myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "MoveRoute" + w + "Data4", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data4).ToString());
                                                        myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "MoveRoute" + w + "Data5", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data5).ToString());
                                                        myXml.WriteString("Event" + i + "Page" + x, "CommandList" + y + "Command" + z + "MoveRoute" + w + "Data6", Conversion.Val(modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[z].MoveRoute[w].Data6).ToString());
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            myXml.CloseXml(true);
        }

        public static void LoadMapEvent(int mapNum)
        {
            XmlClass myXml = new XmlClass()
            {
                Filename = Application.StartupPath + @"\data\maps\map" + mapNum + "_eventdata.xml",
                Root = "Data"
            };

            myXml.LoadXml();
            modTypes.Map[mapNum].EventCount = (int)Conversion.Val(myXml.ReadString("Events", "EventCount"));

            if (!(modTypes.Map[mapNum].EventCount > 0))
            {
                myXml.CloseXml(false);
                return;
            }

            int i;
            int x;
            int y;
            int p;

            modTypes.Map[mapNum].Events = new EventStruct[modTypes.Map[mapNum].EventCount + 1];
            var loopTo = modTypes.Map[mapNum].EventCount;
            for (i = 1; i <= loopTo; i++)
            {
                if (Conversion.Val(myXml.ReadString("Event" + i, "PageCount")) > 0)
                {
                    {
                        modTypes.Map[mapNum].Events[i].Name = myXml.ReadString("Event" + i, "Name");
                        modTypes.Map[mapNum].Events[i].Globals = (byte)Conversion.Val(myXml.ReadString("Event" + i, "Global"));
                        modTypes.Map[mapNum].Events[i].X = (byte)Conversion.Val(myXml.ReadString("Event" + i, "x"));
                        modTypes.Map[mapNum].Events[i].Y = (byte)Conversion.Val(myXml.ReadString("Event" + i, "y"));
                        modTypes.Map[mapNum].Events[i].PageCount = (byte)Conversion.Val(myXml.ReadString("Event" + i, "PageCount"));
                    }
                    if (modTypes.Map[mapNum].Events[i].PageCount > 0)
                    {
                        modTypes.Map[mapNum].Events[i].Pages = new EventPageStruct[modTypes.Map[mapNum].Events[i].PageCount + 1];
                        var loopTo1 = modTypes.Map[mapNum].Events[i].PageCount;
                        for (x = 1; x <= loopTo1; x++)
                        {
                            {
                                //var modTypes.Map[mapNum].Events[i].Pages[x] = modTypes.Map[mapNum].Events[i].Pages[x];
                                modTypes.Map[mapNum].Events[i].Pages[x].ChkVariable = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "chkVariable"));
                                modTypes.Map[mapNum].Events[i].Pages[x].Variableindex = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "VariableIndex"));
                                modTypes.Map[mapNum].Events[i].Pages[x].VariableCondition = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "VariableCondition"));
                                modTypes.Map[mapNum].Events[i].Pages[x].VariableCompare = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "VariableCompare"));

                                modTypes.Map[mapNum].Events[i].Pages[x].ChkSwitch = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "chkSwitch"));
                                modTypes.Map[mapNum].Events[i].Pages[x].Switchindex = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "SwitchIndex"));
                                modTypes.Map[mapNum].Events[i].Pages[x].SwitchCompare = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "SwitchCompare"));

                                modTypes.Map[mapNum].Events[i].Pages[x].ChkHasItem = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "chkHasItem"));
                                modTypes.Map[mapNum].Events[i].Pages[x].HasItemindex = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "HasItemIndex"));
                                modTypes.Map[mapNum].Events[i].Pages[x].HasItemAmount = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "HasItemAmount"));

                                modTypes.Map[mapNum].Events[i].Pages[x].ChkSelfSwitch = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "chkSelfSwitch"));
                                modTypes.Map[mapNum].Events[i].Pages[x].SelfSwitchindex = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "SelfSwitchIndex"));
                                modTypes.Map[mapNum].Events[i].Pages[x].SelfSwitchCompare = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "SelfSwitchCompare"));

                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicType = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "GraphicType"));
                                modTypes.Map[mapNum].Events[i].Pages[x].Graphic = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "Graphic"));
                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicX = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "GraphicX"));
                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicY = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "GraphicY"));
                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicX2 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "GraphicX2"));
                                modTypes.Map[mapNum].Events[i].Pages[x].GraphicY2 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "GraphicY2"));

                                modTypes.Map[mapNum].Events[i].Pages[x].MoveType = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "MoveType"));
                                modTypes.Map[mapNum].Events[i].Pages[x].MoveSpeed = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "MoveSpeed"));
                                modTypes.Map[mapNum].Events[i].Pages[x].MoveFreq = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "MoveFreq"));

                                modTypes.Map[mapNum].Events[i].Pages[x].IgnoreMoveRoute = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "IgnoreMoveRoute"));
                                modTypes.Map[mapNum].Events[i].Pages[x].RepeatMoveRoute = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "RepeatMoveRoute"));

                                modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "MoveRouteCount"));

                                if (modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount > 0)
                                {
                                    modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute = new MoveRouteStruct[modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount + 1];
                                    var loopTo2 = modTypes.Map[mapNum].Events[i].Pages[x].MoveRouteCount;
                                    for (y = 1; y <= loopTo2; y++)
                                    {
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Index = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "MoveRoute" + y + "Index"));
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data1 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "MoveRoute" + y + "Data1"));
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data2 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "MoveRoute" + y + "Data2"));
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data3 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "MoveRoute" + y + "Data3"));
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data4 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "MoveRoute" + y + "Data4"));
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data5 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "MoveRoute" + y + "Data5"));
                                        modTypes.Map[mapNum].Events[i].Pages[x].MoveRoute[y].Data6 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "MoveRoute" + y + "Data6"));
                                    }
                                }

                                modTypes.Map[mapNum].Events[i].Pages[x].WalkAnim = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "WalkAnim"));
                                modTypes.Map[mapNum].Events[i].Pages[x].DirFix = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "DirFix"));
                                modTypes.Map[mapNum].Events[i].Pages[x].WalkThrough = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "WalkThrough"));
                                modTypes.Map[mapNum].Events[i].Pages[x].ShowName = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "ShowName"));
                                modTypes.Map[mapNum].Events[i].Pages[x].Trigger = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "Trigger"));
                                modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandListCount"));

                                modTypes.Map[mapNum].Events[i].Pages[x].Position = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "Position"));
                                modTypes.Map[mapNum].Events[i].Pages[x].QuestNum = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "QuestNum"));

                                modTypes.Map[mapNum].Events[i].Pages[x].ChkPlayerGender = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "PlayerGender"));
                            }

                            if (modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount > 0)
                            {
                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList = new CommandListStruct[modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount + 1];
                                var loopTo3 = modTypes.Map[mapNum].Events[i].Pages[x].CommandListCount;
                                for (y = 1; y <= loopTo3; y++)
                                {
                                    modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "CommandCount"));
                                    modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].ParentList = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "ParentList"));
                                    if (modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount > 0)
                                    {
                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands = new EventCommandStruct[modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount + 1];
                                        var loopTo4 = modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].CommandCount;
                                        for (p = 1; p <= loopTo4; p++)
                                        {
                                            {
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].Index = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "Index"));
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].Text1 = myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "Text1");
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].Text2 = myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "Text2");
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].Text3 = myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "Text3");
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].Text4 = myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "Text4");
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].Text5 = myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "Text5");
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].Data1 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "Data1"));
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].Data2 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "Data2"));
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].Data3 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "Data3"));
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].Data4 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "Data4"));
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].Data5 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "Data5"));
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].Data6 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "Data6"));
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].ConditionalBranch.CommandList = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "ConditionalBranchCommandList"));
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].ConditionalBranch.Condition = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "ConditionalBranchCondition"));
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].ConditionalBranch.Data1 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "ConditionalBranchData1"));
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].ConditionalBranch.Data2 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "ConditionalBranchData2"));
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].ConditionalBranch.Data3 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "ConditionalBranchData3"));
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].ConditionalBranch.ElseCommandList = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "ConditionalBranchElseCommandList"));
                                                modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].MoveRouteCount = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "MoveRouteCount"));
                                                if (modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].MoveRouteCount > 0)
                                                {
                                                    modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].MoveRoute = new MoveRouteStruct[modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].MoveRouteCount + 1];
                                                    var loopTo5 = modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].MoveRouteCount;
                                                    for (var w = 1; w <= loopTo5; w++)
                                                    {
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].MoveRoute[w].Index = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "MoveRoute" + w + "Index"));
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].MoveRoute[w].Data1 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "MoveRoute" + w + "Data1"));
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].MoveRoute[w].Data2 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "MoveRoute" + w + "Data2"));
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].MoveRoute[w].Data3 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "MoveRoute" + w + "Data3"));
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].MoveRoute[w].Data4 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "MoveRoute" + w + "Data4"));
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].MoveRoute[w].Data5 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "MoveRoute" + w + "Data5"));
                                                        modTypes.Map[mapNum].Events[i].Pages[x].CommandList[y].Commands[p].MoveRoute[w].Data6 = (byte)Conversion.Val(myXml.ReadString("Event" + i + "Page" + x, "CommandList" + y + "Command" + p + "MoveRoute" + w + "Data6"));
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            myXml.CloseXml(false);
        }

        public static void LoadMaps()
        {
            int i;

            CheckMaps();

            for (i = 1; i <= Constants.MAX_MAPS; i++)
                LoadMap(i);
        }

        public static void LoadMap(int mapNum)
        {
            string filename;
            int x;
            int y;
            int l;

            filename = Path.Combine(Application.StartupPath, "data", "maps", string.Format("map{0}.dat", mapNum));
            ByteStream reader = new ByteStream();
            BinaryFile.Load(filename, ref reader);

            modTypes.Map[mapNum].Name = reader.ReadString();
            modTypes.Map[mapNum].Music = reader.ReadString();
            modTypes.Map[mapNum].Revision = reader.ReadInt32();
            modTypes.Map[mapNum].Moral = reader.ReadByte();
            modTypes.Map[mapNum].Tileset = reader.ReadInt32();
            modTypes.Map[mapNum].Up = reader.ReadInt32();
            modTypes.Map[mapNum].Down = reader.ReadInt32();
            modTypes.Map[mapNum].Left = reader.ReadInt32();
            modTypes.Map[mapNum].Right = reader.ReadInt32();
            modTypes.Map[mapNum].BootMap = reader.ReadInt32();
            modTypes.Map[mapNum].BootX = reader.ReadByte();
            modTypes.Map[mapNum].BootY = reader.ReadByte();
            modTypes.Map[mapNum].MaxX = reader.ReadByte();
            modTypes.Map[mapNum].MaxY = reader.ReadByte();
            modTypes.Map[mapNum].WeatherType = reader.ReadByte();
            modTypes.Map[mapNum].Fogindex = reader.ReadInt32();
            modTypes.Map[mapNum].WeatherIntensity = reader.ReadInt32();
            modTypes.Map[mapNum].FogAlpha = reader.ReadByte();
            modTypes.Map[mapNum].FogSpeed = reader.ReadByte();
            modTypes.Map[mapNum].HasMapTint = reader.ReadByte();
            modTypes.Map[mapNum].MapTintR = reader.ReadByte();
            modTypes.Map[mapNum].MapTintG = reader.ReadByte();
            modTypes.Map[mapNum].MapTintB = reader.ReadByte();
            modTypes.Map[mapNum].MapTintA = reader.ReadByte();
            modTypes.Map[mapNum].Instanced = reader.ReadByte();
            modTypes.Map[mapNum].Panorama = reader.ReadByte();
            modTypes.Map[mapNum].Parallax = reader.ReadByte();
            modTypes.Map[mapNum].Brightness = reader.ReadByte();

            // have to set the tile()
            modTypes.Map[mapNum].Tile = new TileRec[modTypes.Map[mapNum].MaxX + 1, modTypes.Map[mapNum].MaxY + 1];
            var loopTo = modTypes.Map[mapNum].MaxX;
            for (x = 0; x <= loopTo; x++)
            {
                var loopTo1 = modTypes.Map[mapNum].MaxY;
                for (y = 0; y <= loopTo1; y++)
                {
                    modTypes.Map[mapNum].Tile[x, y].Data1 = reader.ReadInt32();
                    modTypes.Map[mapNum].Tile[x, y].Data2 = reader.ReadInt32();
                    modTypes.Map[mapNum].Tile[x, y].Data3 = reader.ReadInt32();
                    modTypes.Map[mapNum].Tile[x, y].DirBlock = reader.ReadByte();
                    modTypes.Map[mapNum].Tile[x, y].Layer = new TileDataRec[6];
                    for (l = 0; l <= (byte)Enums.LayerType.Count - 1; l++)
                    {
                        modTypes.Map[mapNum].Tile[x, y].Layer[l].Tileset = reader.ReadByte();
                        modTypes.Map[mapNum].Tile[x, y].Layer[l].X = reader.ReadByte();
                        modTypes.Map[mapNum].Tile[x, y].Layer[l].Y = reader.ReadByte();
                        modTypes.Map[mapNum].Tile[x, y].Layer[l].AutoTile = reader.ReadByte();
                    }
                    modTypes.Map[mapNum].Tile[x, y].Type = reader.ReadByte();
                }
            }

            for (x = 1; x <= Constants.MAX_MAP_NPCS; x++)
            {
                modTypes.Map[mapNum].Npc[x] = reader.ReadInt32();
                modTypes.MapNpc[mapNum].Npc[x].Num = modTypes.Map[mapNum].Npc[x];
            }

            ClearTempTile(mapNum);
            S_Resources.CacheResources(mapNum);

            if (modTypes.Map[mapNum].Name == null)
                modTypes.Map[mapNum].Name = "";
            if (modTypes.Map[mapNum].Music == null)
                modTypes.Map[mapNum].Music = "";

            if (File.Exists(Application.StartupPath + @"\data\maps\map" + mapNum + "_eventdata.xml"))
                LoadMapEvent(mapNum);
        }

        public static void ClearTempTiles()
        {
            modTypes.TempTile = new TempTileRec[601];

            for (var i = 1; i <= S_Instances.MAX_CACHED_MAPS; i++)
                ClearTempTile(i);
        }

        public static void ClearTempTile(int mapNum)
        {
            int y;
            int x;
            modTypes.TempTile[mapNum].DoorTimer = 0;
            modTypes.TempTile[mapNum].DoorOpen = new byte[modTypes.Map[mapNum].MaxX + 1, modTypes.Map[mapNum].MaxY + 1];
            var loopTo = modTypes.Map[mapNum].MaxX;
            for (x = 0; x <= loopTo; x++)
            {
                var loopTo1 = modTypes.Map[mapNum].MaxY;
                for (y = 0; y <= loopTo1; y++)
                    modTypes.TempTile[mapNum].DoorOpen[x, y] = 0;
            }
        }

        public static void ClearMapItem(int index, int mapNum)
        {
            modTypes.MapItem[mapNum, index] = default(MapItemRec);
            modTypes.MapItem[mapNum, index].RandData.Prefix = "";
            modTypes.MapItem[mapNum, index].RandData.Suffix = "";
        }

        public static void ClearMapItems()
        {
            int x;
            int y;

            for (y = 1; y <= S_Instances.MAX_CACHED_MAPS; y++)
            {
                for (x = 1; x <= Constants.MAX_MAP_ITEMS; x++)
                    ClearMapItem(x, y);
            }
        }



        public static void SaveNpcs()
        {
            int i;

            for (i = 1; i <= Constants.MAX_NPCS; i++)
            {
                SaveNpc(i);
                //Application.DoEvents();
            }
        }

        public static void SaveNpc(int NpcNum)
        {
            string filename;
            int i;
            filename = Path.Combine(Application.StartupPath, "data", "npcs", string.Format("npc{0}.dat", NpcNum));

            ByteStream writer = new ByteStream(100);
            writer.WriteString(Types.Npc[NpcNum].Name);
            writer.WriteString(Types.Npc[NpcNum].AttackSay);
            writer.WriteInt32(Types.Npc[NpcNum].Sprite);
            writer.WriteByte(Types.Npc[NpcNum].SpawnTime);
            writer.WriteInt32(Types.Npc[NpcNum].SpawnSecs);
            writer.WriteByte(Types.Npc[NpcNum].Behaviour);
            writer.WriteByte(Types.Npc[NpcNum].Range);

            for (i = 1; i <= 5; i++)
            {
                writer.WriteInt32(Types.Npc[NpcNum].DropChance[i]);
                writer.WriteInt32(Types.Npc[NpcNum].DropItem[i]);
                writer.WriteInt32(Types.Npc[NpcNum].DropItemValue[i]);
            }

            for (i = 0; i <= (byte)Enums.StatType.Count - 1; i++)
                writer.WriteByte(Types.Npc[NpcNum].Stat[i]);

            writer.WriteByte(Types.Npc[NpcNum].Faction);
            writer.WriteInt32(Types.Npc[NpcNum].Hp);
            writer.WriteInt32(Types.Npc[NpcNum].Exp);
            writer.WriteInt32(Types.Npc[NpcNum].Animation);

            writer.WriteInt32(Types.Npc[NpcNum].QuestNum);

            for (i = 1; i <= Constants.MAX_NPC_SKILLS; i++)
                writer.WriteByte(Types.Npc[NpcNum].Skill[i]);

            writer.WriteInt32(Types.Npc[NpcNum].Level);
            writer.WriteInt32(Types.Npc[NpcNum].Damage);

            BinaryFile.Save(filename, ref writer);
        }

        public static void LoadNpcs()
        {
            int i;

            CheckNpcs();

            for (i = 1; i <= Constants.MAX_NPCS; i++)
            {
                LoadNpc(i);
                //Application.DoEvents();
            }
        }

        public static void LoadNpc(int NpcNum)
        {
            string filename;
            int n;

            filename = Path.Combine(Application.StartupPath, "data", "npcs", string.Format("npc{0}.dat", NpcNum));
            ByteStream reader = new ByteStream();
            BinaryFile.Load(filename, ref reader);

            Types.Npc[NpcNum].Name = reader.ReadString();
            Types.Npc[NpcNum].AttackSay = reader.ReadString();
            Types.Npc[NpcNum].Sprite = reader.ReadInt32();
            Types.Npc[NpcNum].SpawnTime = reader.ReadByte();
            Types.Npc[NpcNum].SpawnSecs = reader.ReadInt32();
            Types.Npc[NpcNum].Behaviour = reader.ReadByte();
            Types.Npc[NpcNum].Range = reader.ReadByte();

            for (var i = 1; i <= 5; i++)
            {
                Types.Npc[NpcNum].DropChance[i] = reader.ReadInt32();
                Types.Npc[NpcNum].DropItem[i] = reader.ReadInt32();
                Types.Npc[NpcNum].DropItemValue[i] = reader.ReadInt32();
            }

            for (n = 0; n <= (byte)Enums.StatType.Count - 1; n++)
                Types.Npc[NpcNum].Stat[n] = reader.ReadByte();

            Types.Npc[NpcNum].Faction = reader.ReadByte();
            Types.Npc[NpcNum].Hp = reader.ReadInt32();
            Types.Npc[NpcNum].Exp = reader.ReadInt32();
            Types.Npc[NpcNum].Animation = reader.ReadInt32();

            Types.Npc[NpcNum].QuestNum = reader.ReadInt32();

            for (var i = 1; i <= Constants.MAX_NPC_SKILLS; i++)
                Types.Npc[NpcNum].Skill[i] = reader.ReadByte();

            Types.Npc[NpcNum].Level = reader.ReadInt32();
            Types.Npc[NpcNum].Damage = reader.ReadInt32();

            if (Types.Npc[NpcNum].Name == null)
                Types.Npc[NpcNum].Name = "";
            if (Types.Npc[NpcNum].AttackSay == null)
                Types.Npc[NpcNum].AttackSay = "";
        }

        public static void CheckNpcs()
        {
            int i;

            for (i = 1; i <= Constants.MAX_NPCS; i++)
            {
                if (!File.Exists(Path.Combine(Application.StartupPath, "data", "npcs", string.Format("npc{0}.dat", i))))
                {
                    SaveNpc(i);
                    //Application.DoEvents();
                }
            }
        }

        public static void ClearMapNpc(int index, int mapNum)
        {
            modTypes.MapNpc[mapNum].Npc[index] = default(MapNpcRec);

            modTypes.MapNpc[mapNum].Npc[index].Vital = new int[(byte)Enums.VitalType.Count + 1];
            modTypes.MapNpc[mapNum].Npc[index].SkillCd = new int[Constants.MAX_NPC_SKILLS + 1];
        }

        public static void ClearAllMapNpcs()
        {
            int y;

            for (y = 1; y <= S_Instances.MAX_CACHED_MAPS; y++)
            {
                ClearMapNpcs(y);
                //Application.DoEvents();
            }
        }

        public static void ClearMapNpcs(int mapNum)
        {
            int x = 0;
            int y = 0;

            for (x = 1; x <= Constants.MAX_MAP_NPCS; x++)
            {
                ClearMapNpc(x, y);
                //Application.DoEvents();
            }
        }

        public static void ClearNpc(int index)
        {
            Types.Npc[index] = default(NpcRec);
            Types.Npc[index].Name = "";
            Types.Npc[index].AttackSay = "";
            Types.Npc[index].Stat = new byte[7];
            for (var i = 1; i <= 5; i++)
            {
                Types.Npc[index].DropChance = new int[6];
                Types.Npc[index].DropItem = new int[6];
                Types.Npc[index].DropItemValue = new int[6];
                Types.Npc[index].Skill = new byte[Constants.MAX_NPC_SKILLS + 1];
            }
        }

        public static void ClearNpcs()
        {
            for (var i = 1; i <= Constants.MAX_NPCS; i++)
                ClearNpc(i);
        }



        public static void SaveShops()
        {
            int i;

            for (i = 1; i <= Constants.MAX_SHOPS; i++)
            {
                SaveShop(i);
                //Application.DoEvents();
            }
        }

        public static void SaveShop(int shopNum)
        {
            int i;
            string filename;

            filename = Path.Combine(Application.StartupPath, "data", "shops", string.Format("shop{0}.dat", shopNum));

            ByteStream writer = new ByteStream(100);

            writer.WriteString(Types.Shop[shopNum].Name);
            writer.WriteByte(Types.Shop[shopNum].Face);
            writer.WriteInt32(Types.Shop[shopNum].BuyRate);

            for (i = 1; i <= Constants.MAX_TRADES; i++)
            {
                writer.WriteInt32(Types.Shop[shopNum].TradeItem[i].Item);
                writer.WriteInt32(Types.Shop[shopNum].TradeItem[i].ItemValue);
                writer.WriteInt32(Types.Shop[shopNum].TradeItem[i].CostItem);
                writer.WriteInt32(Types.Shop[shopNum].TradeItem[i].CostValue);
            }

            BinaryFile.Save(filename, ref writer);
        }

        public static void LoadShops()
        {
            int i;

            CheckShops();

            for (i = 1; i <= Constants.MAX_SHOPS; i++)
            {
                LoadShop(i);
                //Application.DoEvents();
            }
        }

        public static void LoadShop(int ShopNum)
        {
            string filename;
            int x;

            filename = Path.Combine(Application.StartupPath, "data", "shops", string.Format("shop{0}.dat", ShopNum));
            ByteStream reader = new ByteStream();
            BinaryFile.Load(filename, ref reader);

            Types.Shop[ShopNum].Name = reader.ReadString();
            Types.Shop[ShopNum].Face = reader.ReadByte();
            Types.Shop[ShopNum].BuyRate = reader.ReadInt32();

            for (x = 1; x <= Constants.MAX_TRADES; x++)
            {
                Types.Shop[ShopNum].TradeItem[x].Item = reader.ReadInt32();
                Types.Shop[ShopNum].TradeItem[x].ItemValue = reader.ReadInt32();
                Types.Shop[ShopNum].TradeItem[x].CostItem = reader.ReadInt32();
                Types.Shop[ShopNum].TradeItem[x].CostValue = reader.ReadInt32();
            }
        }

        public static void CheckShops()
        {
            int i;

            for (i = 1; i <= Constants.MAX_SHOPS; i++)
            {
                if (!File.Exists(Path.Combine(Application.StartupPath, "data", "shops", string.Format("shop{0}.dat", i))))
                {
                    SaveShop(i);
                    //Application.DoEvents();
                }
            }
        }

        public static void ClearShop(int index)
        {
            int i;

            Types.Shop[index] = default(ShopRec);
            Types.Shop[index].Name = "";

            Types.Shop[index].TradeItem = new TradeItemRec[Constants.MAX_TRADES + 1];
            for (i = 0; i <= Constants.MAX_SHOPS; i++)
                Types.Shop[i].TradeItem = new TradeItemRec[Constants.MAX_TRADES + 1];
        }

        public static void ClearShops()
        {
            for (var i = 1; i <= Constants.MAX_SHOPS; i++)
                ClearShop(i);
        }



        public static void SaveSkills()
        {
            int i;
            Console.WriteLine("Saving skills... ");

            for (i = 1; i <= Constants.MAX_SKILLS; i++)
            {
                SaveSkill(i);
                //Application.DoEvents();
            }
        }

        public static void SaveSkill(int skillnum)
        {
            string filename;
            filename = Path.Combine(Application.StartupPath, "data", "skills", string.Format("skills{0}.dat", skillnum));

            ByteStream writer = new ByteStream(100);

            writer.WriteString(Types.Skill[skillnum].Name);
            writer.WriteByte(Types.Skill[skillnum].Type);
            writer.WriteInt32(Types.Skill[skillnum].MpCost);
            writer.WriteInt32(Types.Skill[skillnum].LevelReq);
            writer.WriteInt32(Types.Skill[skillnum].AccessReq);
            writer.WriteInt32(Types.Skill[skillnum].ClassReq);
            writer.WriteInt32(Types.Skill[skillnum].CastTime);
            writer.WriteInt32(Types.Skill[skillnum].CdTime);
            writer.WriteInt32(Types.Skill[skillnum].Icon);
            writer.WriteInt32(Types.Skill[skillnum].Map);
            writer.WriteInt32(Types.Skill[skillnum].X);
            writer.WriteInt32(Types.Skill[skillnum].Y);
            writer.WriteByte(Types.Skill[skillnum].Dir);
            writer.WriteInt32(Types.Skill[skillnum].Vital);
            writer.WriteInt32(Types.Skill[skillnum].Duration);
            writer.WriteInt32(Types.Skill[skillnum].Interval);
            writer.WriteInt32(Types.Skill[skillnum].Range);
            writer.WriteBoolean(Types.Skill[skillnum].IsAoE);
            writer.WriteInt32(Types.Skill[skillnum].AoE);
            writer.WriteInt32(Types.Skill[skillnum].CastAnim);
            writer.WriteInt32(Types.Skill[skillnum].SkillAnim);
            writer.WriteInt32(Types.Skill[skillnum].StunDuration);

            writer.WriteInt32(Types.Skill[skillnum].IsProjectile);
            writer.WriteInt32(Types.Skill[skillnum].Projectile);

            writer.WriteByte(Types.Skill[skillnum].KnockBack);
            writer.WriteByte(Types.Skill[skillnum].KnockBackTiles);

            BinaryFile.Save(filename, ref writer);
        }

        public static void LoadSkills()
        {
            int i;

            CheckSkills();

            for (i = 1; i <= Constants.MAX_SKILLS; i++)
            {
                LoadSkill(i);
                //Application.DoEvents();
            }
        }

        public static void LoadSkill(int SkillNum)
        {
            string filename;

            filename = Path.Combine(Application.StartupPath, "data", "skills", string.Format("skills{0}.dat", SkillNum));
            ByteStream reader = new ByteStream();
            BinaryFile.Load(filename, ref reader);

            Types.Skill[SkillNum].Name = reader.ReadString();
            Types.Skill[SkillNum].Type = reader.ReadByte();
            Types.Skill[SkillNum].MpCost = reader.ReadInt32();
            Types.Skill[SkillNum].LevelReq = reader.ReadInt32();
            Types.Skill[SkillNum].AccessReq = reader.ReadInt32();
            Types.Skill[SkillNum].ClassReq = reader.ReadInt32();
            Types.Skill[SkillNum].CastTime = reader.ReadInt32();
            Types.Skill[SkillNum].CdTime = reader.ReadInt32();
            Types.Skill[SkillNum].Icon = reader.ReadInt32();
            Types.Skill[SkillNum].Map = reader.ReadInt32();
            Types.Skill[SkillNum].X = reader.ReadInt32();
            Types.Skill[SkillNum].Y = reader.ReadInt32();
            Types.Skill[SkillNum].Dir = reader.ReadByte();
            Types.Skill[SkillNum].Vital = reader.ReadInt32();
            Types.Skill[SkillNum].Duration = reader.ReadInt32();
            Types.Skill[SkillNum].Interval = reader.ReadInt32();
            Types.Skill[SkillNum].Range = reader.ReadInt32();
            Types.Skill[SkillNum].IsAoE = reader.ReadBoolean();
            Types.Skill[SkillNum].AoE = reader.ReadInt32();
            Types.Skill[SkillNum].CastAnim = reader.ReadInt32();
            Types.Skill[SkillNum].SkillAnim = reader.ReadInt32();
            Types.Skill[SkillNum].StunDuration = reader.ReadInt32();

            Types.Skill[SkillNum].IsProjectile = reader.ReadInt32();
            Types.Skill[SkillNum].Projectile = reader.ReadInt32();

            Types.Skill[SkillNum].KnockBack = reader.ReadByte();
            Types.Skill[SkillNum].KnockBackTiles = reader.ReadByte();
        }

        public static void CheckSkills()
        {
            int i;

            for (i = 1; i <= Constants.MAX_SKILLS; i++)
            {
                if (!File.Exists(Path.Combine(Application.StartupPath, "data", "skills", string.Format("skills{0}.dat", i))))
                {
                    SaveSkill(i);
                    //Application.DoEvents();
                }
            }
        }

        public static void ClearSkill(int index)
        {
            Types.Skill[index] = default(SkillRec);
            Types.Skill[index].Name = "";
            Types.Skill[index].LevelReq = 1; // Needs to be 1 for the skill editor
        }

        public static void ClearSkills()
        {
            for (var i = 1; i <= Constants.MAX_SKILLS; i++)
                ClearSkill(i);
        }



        public static bool AccountExist(string Name)
        {
            return File.Exists(Application.StartupPath + @"\Data\Accounts\" + Microsoft.VisualBasic.Strings.Trim(Name) + @"\Data.bin");
        }

        public static bool PasswordOK(string Name, string Password)
        {
            if (!AccountExist(Name))
                return false;
            ByteStream reader = new ByteStream();
            BinaryFile.Load(Application.StartupPath + @"\Data\Accounts\" + Microsoft.VisualBasic.Strings.Trim(Name) + @"\Data.bin", ref reader);
            if (reader.ReadString().Trim() != Name.Trim())
                return false;
            return reader.ReadString().Trim().ToUpper() == Password.Trim().ToUpper();
        }

        public static void AddAccount(int index, string Name, string Password)
        {
            ClearPlayer(index);

            modTypes.Player[index].Login = Name;
            modTypes.Player[index].Password = Password;

            SavePlayer(index);
        }

        public static void DeleteName(string Name)
        {
            TextFile.RemoveString(Application.StartupPath + @"\Data\Accounts\charlist.txt", Name.Trim().ToLower());
        }



        public static void SaveAllPlayersOnline()
        {
            var loopTo = S_GameLogic.GetPlayersOnline();
            for (var i = 1; i <= loopTo; i++)
            {
                if (!S_NetworkConfig.IsPlaying(i))
                    continue;
                SavePlayer(i);
                SaveBank(i);
            }
        }

        public static void SavePlayer(int index)
        {
            string playername = Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Login);
            string filename = Application.StartupPath + @"\Data\Accounts\" + playername;
            S_General.CheckDir(filename); filename += @"\Data.bin";

            ByteStream writer = new ByteStream(9 + modTypes.Player[index].Login.Length + modTypes.Player[index].Password.Length);

            writer.WriteString(modTypes.Player[index].Login);
            writer.WriteString(modTypes.Player[index].Password);
            writer.WriteByte(modTypes.Player[index].Access);

            BinaryFile.Save(filename, ref writer);

            for (var i = 1; i <= S_Constants.MAX_CHARS; i++)
                SaveCharacter(index, i);
        }

        public static void LoadPlayer(int index, string Name)
        {
            string filename = Application.StartupPath + @"\Data\Accounts\" + Name.Trim() + @"\Data.bin";
            ClearPlayer(index);
            ByteStream reader = new ByteStream();
            BinaryFile.Load(filename, ref reader);

            modTypes.Player[index].Login = reader.ReadString();
            modTypes.Player[index].Password = reader.ReadString();
            modTypes.Player[index].Access = reader.ReadByte();

            for (int i = 1; i <= S_Constants.MAX_CHARS; i++)
                LoadCharacter(index, i);
        }

        public static void ClearPlayer(int index)
        {
            modTypes.TempPlayer[index].SkillCd = new int[Constants.MAX_PLAYER_SKILLS + 1];
            modTypes.TempPlayer[index].PetSkillCd = new int[5];

            modTypes.Player[index].Login = "";
            modTypes.Player[index].Password = "";

            modTypes.Player[index].Access = 0;

            for (var i = 1; i <= S_Constants.MAX_CHARS; i++)
                ClearCharacter(index, i);
        }



        internal static void LoadBank(int index, string Name)
        {
            string filename = Application.StartupPath + @"\Data\Accounts\" + Name.Trim() + @"\Bank.bin";

            ClearBank(index);

            if (!File.Exists(filename))
            {
                SaveBank(index);
                return;
            }

            ByteStream reader = new ByteStream();
            BinaryFile.Load(filename, ref reader);

            for (var i = 1; i <= Constants.MAX_BANK; i++)
            {
                modTypes.Bank[index].Item[i].Num = reader.ReadByte();
                modTypes.Bank[index].Item[i].Value = reader.ReadInt32();

                modTypes.Bank[index].ItemRand[i].Prefix = reader.ReadString();
                modTypes.Bank[index].ItemRand[i].Suffix = reader.ReadString();
                modTypes.Bank[index].ItemRand[i].Rarity = reader.ReadInt32();
                modTypes.Bank[index].ItemRand[i].Damage = reader.ReadInt32();
                modTypes.Bank[index].ItemRand[i].Speed = reader.ReadInt32();

                for (var x = 1; x <= (int)Enums.StatType.Count - 1; x++)
                    modTypes.Bank[index].ItemRand[i].Stat[x] = reader.ReadInt32();
            }
        }

        public static void SaveBank(int index)
        {
            var filename = Application.StartupPath + @"\Data\Accounts\" + modTypes.Player[index].Login.Trim() + @"\Bank.bin";

            ByteStream writer = new ByteStream(100);

            for (var i = 1; i <= Constants.MAX_BANK; i++)
            {
                writer.WriteByte((byte)modTypes.Bank[index].Item[i].Num);
                writer.WriteInt32(modTypes.Bank[index].Item[i].Value);

                if (modTypes.Bank[index].ItemRand[i].Prefix == null)
                    modTypes.Bank[index].ItemRand[i].Prefix = "";
                if (modTypes.Bank[index].ItemRand[i].Suffix == null)
                    modTypes.Bank[index].ItemRand[i].Suffix = "";

                writer.WriteString(modTypes.Bank[index].ItemRand[i].Prefix);
                writer.WriteString(modTypes.Bank[index].ItemRand[i].Suffix);
                writer.WriteInt32(modTypes.Bank[index].ItemRand[i].Rarity);
                writer.WriteInt32(modTypes.Bank[index].ItemRand[i].Damage);
                writer.WriteInt32(modTypes.Bank[index].ItemRand[i].Speed);

                for (var x = 1; x <= (int)Enums.StatType.Count - 1; x++)
                    writer.WriteInt32(modTypes.Bank[index].ItemRand[i].Stat[x]);
            }

            BinaryFile.Save(filename, ref writer);
        }

        public static void ClearBank(int index)
        {
            modTypes.Bank[index].Item = new PlayerInvRec[Constants.MAX_BANK + 1];
            modTypes.Bank[index].ItemRand = new RandInvRec[Constants.MAX_BANK + 1];

            for (var i = 1; i <= Constants.MAX_BANK; i++)
            {
                modTypes.Bank[index].Item[i].Num = 0;
                modTypes.Bank[index].Item[i].Value = 0;
                modTypes.Bank[index].ItemRand[i].Prefix = "";
                modTypes.Bank[index].ItemRand[i].Suffix = "";
                modTypes.Bank[index].ItemRand[i].Rarity = 0;
                modTypes.Bank[index].ItemRand[i].Damage = 0;
                modTypes.Bank[index].ItemRand[i].Speed = 0;

                modTypes.Bank[index].ItemRand[i].Stat = new int[7];
                for (var x = 1; x <= (int)Enums.StatType.Count - 1; x++)
                    modTypes.Bank[index].ItemRand[i].Stat[x] = 0;
            }
        }



        public static void ClearCharacter(int index, int CharNum)
        {
            modTypes.Player[index].Character[CharNum].Classes = 0;
            modTypes.Player[index].Character[CharNum].Dir = 0;

            for (var i = 0; i <= (int)Enums.EquipmentType.Count - 1; i++)
                modTypes.Player[index].Character[CharNum].Equipment[i] = 0;

            for (int i = 0; i <= Constants.MAX_INV; i++)
            {
                modTypes.Player[index].Character[CharNum].Inv[i].Num = 0;
                modTypes.Player[index].Character[CharNum].Inv[i].Value = 0;
            }

            modTypes.Player[index].Character[CharNum].Exp = 0;
            modTypes.Player[index].Character[CharNum].Level = 0;
            modTypes.Player[index].Character[CharNum].Map = 0;
            modTypes.Player[index].Character[CharNum].Name = "";
            modTypes.Player[index].Character[CharNum].Pk = 0;
            modTypes.Player[index].Character[CharNum].Points = 0;
            modTypes.Player[index].Character[CharNum].Sex = 0;

            for (var i = 0; i <= Constants.MAX_PLAYER_SKILLS; i++)
                modTypes.Player[index].Character[CharNum].Skill[i] = 0;

            modTypes.Player[index].Character[CharNum].Sprite = 0;

            for (var i = 0; i <= (int)Enums.StatType.Count - 1; i++)
                modTypes.Player[index].Character[CharNum].Stat[i] = 0;

            for (int i = 0; i <= (int)Enums.VitalType.Count - 1; i++)
                modTypes.Player[index].Character[CharNum].Vital[i] = 0;

            modTypes.Player[index].Character[CharNum].X = 0;
            modTypes.Player[index].Character[CharNum].Y = 0;

            modTypes.Player[index].Character[CharNum].PlayerQuest = new PlayerQuestRec[251];
            for (var i = 1; i <= S_Quest.MAX_QUESTS; i++)
            {
                modTypes.Player[index].Character[CharNum].PlayerQuest[i].Status = 0;
                modTypes.Player[index].Character[CharNum].PlayerQuest[i].ActualTask = 0;
                modTypes.Player[index].Character[CharNum].PlayerQuest[i].CurrentCount = 0;
            }

            // Housing
            modTypes.Player[index].Character[CharNum].House.Houseindex = 0;
            modTypes.Player[index].Character[CharNum].House.FurnitureCount = 0;
            modTypes.Player[index].Character[CharNum].House.Furniture = new FurnitureRec[modTypes.Player[index].Character[CharNum].House.FurnitureCount + 1];
            var loopTo = modTypes.Player[index].Character[CharNum].House.FurnitureCount;
            for (var i = 0; i <= loopTo; i++)
            {
                modTypes.Player[index].Character[CharNum].House.Furniture[i].ItemNum = 0;
                modTypes.Player[index].Character[CharNum].House.Furniture[i].X = 0;
                modTypes.Player[index].Character[CharNum].House.Furniture[i].Y = 0;
            }

            modTypes.Player[index].Character[CharNum].InHouse = 0;
            modTypes.Player[index].Character[CharNum].LastMap = 0;
            modTypes.Player[index].Character[CharNum].LastX = 0;
            modTypes.Player[index].Character[CharNum].LastY = 0;

            modTypes.Player[index].Character[CharNum].Hotbar = new HotbarRec[S_Constants.MAX_HOTBAR + 1];
            for (var i = 1; i <= S_Constants.MAX_HOTBAR; i++)
            {
                modTypes.Player[index].Character[CharNum].Hotbar[i].Slot = 0;
                modTypes.Player[index].Character[CharNum].Hotbar[i].SlotType = 0;
            }

            modTypes.Player[index].Character[CharNum].Switches = new byte[501];
            for (var i = 1; i <= S_Events.MaxSwitches; i++)
                modTypes.Player[index].Character[CharNum].Switches[i] = 0;
            modTypes.Player[index].Character[CharNum].Variables = new int[501];
            for (var i = 1; i <= S_Events.MaxVariables; i++)
                modTypes.Player[index].Character[CharNum].Variables[i] = 0;

            modTypes.Player[index].Character[CharNum].GatherSkills = new ResourceSkillsRec[5];
            for (var i = 0; i <= (int)Enums.ResourceSkills.Count - 1; i++)
            {
                modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillLevel = 1;
                modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillCurExp = 0;
                modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillNextLvlExp = 100;
            }

            modTypes.Player[index].Character[CharNum].RecipeLearned = new byte[101];
            for (var i = 1; i <= Constants.MAX_RECIPE; i++)
                modTypes.Player[index].Character[CharNum].RecipeLearned[i] = 0;

            // random items
            modTypes.Player[index].Character[CharNum].RandInv = new RandInvRec[Constants.MAX_INV + 1];
            for (var i = 1; i <= Constants.MAX_INV; i++)
            {
                modTypes.Player[index].Character[CharNum].RandInv[i].Prefix = "";
                modTypes.Player[index].Character[CharNum].RandInv[i].Suffix = "";
                modTypes.Player[index].Character[CharNum].RandInv[i].Rarity = 0;
                modTypes.Player[index].Character[CharNum].RandInv[i].Damage = 0;
                modTypes.Player[index].Character[CharNum].RandInv[i].Speed = 0;

                modTypes.Player[index].Character[CharNum].RandInv[i].Stat = new int[7];
                for (var x = 1; x <= (int)Enums.StatType.Count - 1; x++)
                    modTypes.Player[index].Character[CharNum].RandInv[i].Stat[x] = 0;
            }

            modTypes.Player[index].Character[CharNum].RandEquip = new RandInvRec[7];
            for (var i = 1; i <= (int)Enums.EquipmentType.Count - 1; i++)
            {
                modTypes.Player[index].Character[CharNum].RandEquip[i].Prefix = "";
                modTypes.Player[index].Character[CharNum].RandEquip[i].Suffix = "";
                modTypes.Player[index].Character[CharNum].RandEquip[i].Rarity = 0;
                modTypes.Player[index].Character[CharNum].RandEquip[i].Damage = 0;
                modTypes.Player[index].Character[CharNum].RandEquip[i].Speed = 0;

                modTypes.Player[index].Character[CharNum].RandEquip[i].Stat = new int[7];
                for (var x = 1; x <= (int)Enums.StatType.Count - 1; x++)
                    modTypes.Player[index].Character[CharNum].RandEquip[i].Stat[x] = 0;
            }

            // pets
            modTypes.Player[index].Character[CharNum].Pet.Num = 0;
            modTypes.Player[index].Character[CharNum].Pet.Health = 0;
            modTypes.Player[index].Character[CharNum].Pet.Mana = 0;
            modTypes.Player[index].Character[CharNum].Pet.Level = 0;

            modTypes.Player[index].Character[CharNum].Pet.Stat = new int[7];
            for (var i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                modTypes.Player[index].Character[CharNum].Pet.Stat[i] = 0;

            modTypes.Player[index].Character[CharNum].Pet.Skill = new int[5];
            for (var i = 1; i <= 4; i++)
                modTypes.Player[index].Character[CharNum].Pet.Skill[i] = 0;

            modTypes.Player[index].Character[CharNum].Pet.X = 0;
            modTypes.Player[index].Character[CharNum].Pet.Y = 0;
            modTypes.Player[index].Character[CharNum].Pet.Dir = 0;
            modTypes.Player[index].Character[CharNum].Pet.Alive = 0;
            modTypes.Player[index].Character[CharNum].Pet.AttackBehaviour = 0;
            modTypes.Player[index].Character[CharNum].Pet.AdoptiveStats = 0;
            modTypes.Player[index].Character[CharNum].Pet.Points = 0;
            modTypes.Player[index].Character[CharNum].Pet.Exp = 0;
        }

        public static void LoadCharacter(int index, int CharNum)
        {
            string filename = Application.StartupPath + @"\Data\Accounts\" + modTypes.Player[index].Login.Trim() + @"\" + CharNum + ".bin";

            ClearCharacter(index, CharNum);

            ByteStream reader = new ByteStream();
            BinaryFile.Load(filename, ref reader);

            modTypes.Player[index].Character[CharNum].Classes = reader.ReadByte();
            modTypes.Player[index].Character[CharNum].Dir = reader.ReadByte();

            for (var i = 1; i <= (int)Enums.EquipmentType.Count - 1; i++)
                modTypes.Player[index].Character[CharNum].Equipment[i] = reader.ReadByte();

            modTypes.Player[index].Character[CharNum].Exp = reader.ReadInt32();

            for (var i = 0; i <= Constants.MAX_INV; i++)
            {
                modTypes.Player[index].Character[CharNum].Inv[i].Num = reader.ReadByte();
                modTypes.Player[index].Character[CharNum].Inv[i].Value = reader.ReadInt32();
            }

            modTypes.Player[index].Character[CharNum].Level = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].Map = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].Name = reader.ReadString();
            modTypes.Player[index].Character[CharNum].Pk = reader.ReadByte();
            modTypes.Player[index].Character[CharNum].Points = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].Sex = reader.ReadByte();

            for (var i = 0; i <= Constants.MAX_PLAYER_SKILLS; i++)
                modTypes.Player[index].Character[CharNum].Skill[i] = reader.ReadByte();

            modTypes.Player[index].Character[CharNum].Sprite = reader.ReadInt32();

            for (var i = 0; i <= (int)Enums.StatType.Count - 1; i++)
                modTypes.Player[index].Character[CharNum].Stat[i] = reader.ReadInt32();

            for (int i = 0; i <= (int)Enums.VitalType.Count - 1; i++)
                modTypes.Player[index].Character[CharNum].Vital[i] = reader.ReadInt32();

            modTypes.Player[index].Character[CharNum].X = reader.ReadByte();
            modTypes.Player[index].Character[CharNum].Y = reader.ReadByte();

            for (var i = 1; i <= S_Quest.MAX_QUESTS; i++)
            {
                modTypes.Player[index].Character[CharNum].PlayerQuest[i].Status = reader.ReadInt32();
                modTypes.Player[index].Character[CharNum].PlayerQuest[i].ActualTask = reader.ReadInt32();
                modTypes.Player[index].Character[CharNum].PlayerQuest[i].CurrentCount = reader.ReadInt32();
            }

            // Housing
            modTypes.Player[index].Character[CharNum].House.Houseindex = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].House.FurnitureCount = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].House.Furniture = new FurnitureRec[modTypes.Player[index].Character[CharNum].House.FurnitureCount + 1];
            var loopTo = modTypes.Player[index].Character[CharNum].House.FurnitureCount;
            for (var i = 0; i <= loopTo; i++)
            {
                modTypes.Player[index].Character[CharNum].House.Furniture[i].ItemNum = reader.ReadInt32();
                modTypes.Player[index].Character[CharNum].House.Furniture[i].X = reader.ReadInt32();
                modTypes.Player[index].Character[CharNum].House.Furniture[i].Y = reader.ReadInt32();
            }
            modTypes.Player[index].Character[CharNum].InHouse = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].LastMap = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].LastX = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].LastY = reader.ReadInt32();

            for (var i = 1; i <= S_Constants.MAX_HOTBAR; i++)
            {
                modTypes.Player[index].Character[CharNum].Hotbar[i].Slot = reader.ReadInt32();
                modTypes.Player[index].Character[CharNum].Hotbar[i].SlotType = reader.ReadByte();
            }

            modTypes.Player[index].Character[CharNum].Switches = new byte[501];
            for (var i = 1; i <= S_Events.MaxSwitches; i++)
                modTypes.Player[index].Character[CharNum].Switches[i] = reader.ReadByte();
            modTypes.Player[index].Character[CharNum].Variables = new int[501];
            for (var i = 1; i <= S_Events.MaxVariables; i++)
                modTypes.Player[index].Character[CharNum].Variables[i] = reader.ReadInt32();

            modTypes.Player[index].Character[CharNum].GatherSkills = new ResourceSkillsRec[5];
            for (var i = 0; i <= (int)Enums.ResourceSkills.Count - 1; i++)
            {
                modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillLevel = reader.ReadInt32();
                modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillCurExp = reader.ReadInt32();
                modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillNextLvlExp = reader.ReadInt32();
                if (modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillLevel == 0)
                    modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillLevel = 1;
                if (modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillNextLvlExp == 0)
                    modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillNextLvlExp = 100;
            }

            modTypes.Player[index].Character[CharNum].RecipeLearned = new byte[101];
            for (var i = 1; i <= Constants.MAX_RECIPE; i++)
                modTypes.Player[index].Character[CharNum].RecipeLearned[i] = reader.ReadByte();

            // random items
            modTypes.Player[index].Character[CharNum].RandInv = new RandInvRec[Constants.MAX_INV + 1];
            for (var i = 1; i <= Constants.MAX_INV; i++)
            {
                modTypes.Player[index].Character[CharNum].RandInv[i].Prefix = reader.ReadString();
                modTypes.Player[index].Character[CharNum].RandInv[i].Suffix = reader.ReadString();
                modTypes.Player[index].Character[CharNum].RandInv[i].Rarity = reader.ReadInt32();
                modTypes.Player[index].Character[CharNum].RandInv[i].Damage = reader.ReadInt32();
                modTypes.Player[index].Character[CharNum].RandInv[i].Speed = reader.ReadInt32();

                modTypes.Player[index].Character[CharNum].RandInv[i].Stat = new int[7];
                for (var x = 1; x <= (int)Enums.StatType.Count - 1; x++)
                    modTypes.Player[index].Character[CharNum].RandInv[i].Stat[x] = reader.ReadInt32();
            }

            modTypes.Player[index].Character[CharNum].RandEquip = new RandInvRec[7];
            for (var i = 1; i <= (int)Enums.EquipmentType.Count - 1; i++)
            {
                modTypes.Player[index].Character[CharNum].RandEquip[i].Prefix = reader.ReadString();
                modTypes.Player[index].Character[CharNum].RandEquip[i].Suffix = reader.ReadString();
                modTypes.Player[index].Character[CharNum].RandEquip[i].Rarity = reader.ReadInt32();
                modTypes.Player[index].Character[CharNum].RandEquip[i].Damage = reader.ReadInt32();
                modTypes.Player[index].Character[CharNum].RandEquip[i].Speed = reader.ReadInt32();

                modTypes.Player[index].Character[CharNum].RandEquip[i].Stat = new int[7];
                for (var x = 1; x <= (int)Enums.StatType.Count - 1; x++)
                    modTypes.Player[index].Character[CharNum].RandEquip[i].Stat[x] = reader.ReadInt32();
            }

            // pets
            modTypes.Player[index].Character[CharNum].Pet.Num = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].Pet.Health = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].Pet.Mana = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].Pet.Level = reader.ReadInt32();

            modTypes.Player[index].Character[CharNum].Pet.Stat = new int[7];
            for (var i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                modTypes.Player[index].Character[CharNum].Pet.Stat[i] = reader.ReadInt32();

            modTypes.Player[index].Character[CharNum].Pet.Skill = new int[5];
            for (var i = 1; i <= 4; i++)
                modTypes.Player[index].Character[CharNum].Pet.Skill[i] = reader.ReadInt32();

            modTypes.Player[index].Character[CharNum].Pet.X = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].Pet.Y = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].Pet.Dir = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].Pet.Alive = reader.ReadByte();
            modTypes.Player[index].Character[CharNum].Pet.AttackBehaviour = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].Pet.AdoptiveStats = reader.ReadByte();
            modTypes.Player[index].Character[CharNum].Pet.Points = reader.ReadInt32();
            modTypes.Player[index].Character[CharNum].Pet.Exp = reader.ReadInt32();
        }

        public static void SaveCharacter(int index, int CharNum)
        {
            string filename = Application.StartupPath + @"\Data\Accounts\" + modTypes.Player[index].Login.Trim() + @"\" + CharNum + ".bin";

            ByteStream writer = new ByteStream(100);

            writer.WriteByte(modTypes.Player[index].Character[CharNum].Classes);
            writer.WriteByte(modTypes.Player[index].Character[CharNum].Dir);

            for (var i = 1; i <= (int)Enums.EquipmentType.Count - 1; i++)
                writer.WriteByte((byte)modTypes.Player[index].Character[CharNum].Equipment[i]);

            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Exp);

            for (var i = 0; i <= Constants.MAX_INV; i++)
            {
                writer.WriteByte((byte)modTypes.Player[index].Character[CharNum].Inv[i].Num);
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].Inv[i].Value);
            }

            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Level);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Map);
            writer.WriteString(modTypes.Player[index].Character[CharNum].Name);
            writer.WriteByte(modTypes.Player[index].Character[CharNum].Pk);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Points);
            writer.WriteByte(modTypes.Player[index].Character[CharNum].Sex);

            for (var i = 0; i <= Constants.MAX_PLAYER_SKILLS; i++)
                writer.WriteByte((byte)modTypes.Player[index].Character[CharNum].Skill[i]);

            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Sprite);

            for (var i = 0; i <= (int)Enums.StatType.Count - 1; i++)
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].Stat[i]);

            for (int i = 0; i <= (int)Enums.VitalType.Count - 1; i++)
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].Vital[i]);

            writer.WriteByte(modTypes.Player[index].Character[CharNum].X);
            writer.WriteByte(modTypes.Player[index].Character[CharNum].Y);

            for (var i = 1; i <= S_Quest.MAX_QUESTS; i++)
            {
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].PlayerQuest[i].Status);
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].PlayerQuest[i].ActualTask);
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].PlayerQuest[i].CurrentCount);
            }

            // Housing
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].House.Houseindex);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].House.FurnitureCount);
            var loopTo = modTypes.Player[index].Character[CharNum].House.FurnitureCount;
            for (var i = 0; i <= loopTo; i++)
            {
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].House.Furniture[i].ItemNum);
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].House.Furniture[i].X);
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].House.Furniture[i].Y);
            }
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].InHouse);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].LastMap);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].LastX);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].LastY);

            for (var i = 1; i <= S_Constants.MAX_HOTBAR; i++)
            {
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].Hotbar[i].Slot);
                writer.WriteByte(modTypes.Player[index].Character[CharNum].Hotbar[i].SlotType);
            }

            for (int i = 1; i <= S_Events.MaxSwitches; i++)
                writer.WriteByte(modTypes.Player[index].Character[CharNum].Switches[i]);

            for (int i = 1; i <= S_Events.MaxVariables; i++)
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].Variables[i]);

            for (int i = 0; i <= (int)Enums.ResourceSkills.Count - 1; i++)
            {
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillLevel);
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillCurExp);
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillNextLvlExp);
            }

            for (int i = 1; i <= Constants.MAX_RECIPE; i++)
                writer.WriteByte(modTypes.Player[index].Character[CharNum].RecipeLearned[i]);

            // random items
            for (int i = 1; i <= Constants.MAX_INV; i++)
            {
                writer.WriteString(modTypes.Player[index].Character[CharNum].RandInv[i].Prefix);
                writer.WriteString(modTypes.Player[index].Character[CharNum].RandInv[i].Suffix);
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].RandInv[i].Rarity);
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].RandInv[i].Damage);
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].RandInv[i].Speed);
                for (var x = 1; x <= (int)Enums.StatType.Count - 1; x++)
                    writer.WriteInt32(modTypes.Player[index].Character[CharNum].RandInv[i].Stat[x]);
            }

            for (int i = 1; i <= (int)Enums.EquipmentType.Count - 1; i++)
            {
                writer.WriteString(modTypes.Player[index].Character[CharNum].RandEquip[i].Prefix);
                writer.WriteString(modTypes.Player[index].Character[CharNum].RandEquip[i].Suffix);
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].RandEquip[i].Rarity);
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].RandEquip[i].Damage);
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].RandEquip[i].Speed);
                for (var x = 1; x <= (int)Enums.StatType.Count - 1; x++)
                    writer.WriteInt32(modTypes.Player[index].Character[CharNum].RandEquip[i].Stat[x]);
            }

            // pets
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Pet.Num);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Pet.Health);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Pet.Mana);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Pet.Level);

            for (var i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].Pet.Stat[i]);

            for (int i = 1; i <= 4; i++)
                writer.WriteInt32(modTypes.Player[index].Character[CharNum].Pet.Skill[i]);

            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Pet.X);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Pet.Y);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Pet.Dir);
            writer.WriteByte(modTypes.Player[index].Character[CharNum].Pet.Alive);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Pet.AttackBehaviour);
            writer.WriteByte(modTypes.Player[index].Character[CharNum].Pet.AdoptiveStats);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Pet.Points);
            writer.WriteInt32(modTypes.Player[index].Character[CharNum].Pet.Exp);

            BinaryFile.Save(filename, ref writer);
        }

        public static bool CharExist(int index, int CharNum)
        {
            return modTypes.Player[index].Character[CharNum].Name.Trim().Length > 0;
        }

        public static void AddChar(int index, int CharNum, string Name, byte Sex, byte ClassNum, int Sprite)
        {
            int n;
            int i;

            if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(modTypes.Player[index].Character[CharNum].Name)) == 0)
            {
                modTypes.Player[index].Character[CharNum].Name = Name;
                modTypes.Player[index].Character[CharNum].Sex = Sex;
                modTypes.Player[index].Character[CharNum].Classes = ClassNum;

                if (modTypes.Player[index].Character[CharNum].Sex == (int)Enums.SexType.Male)
                    modTypes.Player[index].Character[CharNum].Sprite = Types.Classes[ClassNum].MaleSprite[Sprite - 1];
                else
                    modTypes.Player[index].Character[CharNum].Sprite = Types.Classes[ClassNum].FemaleSprite[Sprite - 1];

                modTypes.Player[index].Character[CharNum].Level = 1;

                for (n = 1; n <= (int)Enums.StatType.Count - 1; n++)
                    modTypes.Player[index].Character[CharNum].Stat[n] = Types.Classes[ClassNum].Stat[n];

                modTypes.Player[index].Character[CharNum].Dir = (int)Enums.DirectionType.Down;
                modTypes.Player[index].Character[CharNum].Map = Types.Classes[ClassNum].StartMap;
                modTypes.Player[index].Character[CharNum].X = Types.Classes[ClassNum].StartX;
                modTypes.Player[index].Character[CharNum].Y = Types.Classes[ClassNum].StartY;
                modTypes.Player[index].Character[CharNum].Dir = (int)Enums.DirectionType.Down;
                modTypes.Player[index].Character[CharNum].Vital[(int)Enums.VitalType.HP] = S_Players.GetPlayerMaxVital(index, Enums.VitalType.HP);
                modTypes.Player[index].Character[CharNum].Vital[(int)Enums.VitalType.MP] = S_Players.GetPlayerMaxVital(index, Enums.VitalType.MP);
                modTypes.Player[index].Character[CharNum].Vital[(int)Enums.VitalType.SP] = S_Players.GetPlayerMaxVital(index, Enums.VitalType.SP);

                // set starter equipment
                for (n = 1; n <= 5; n++)
                {
                    if (Types.Classes[ClassNum].StartItem[n] > 0)
                    {
                        modTypes.Player[index].Character[CharNum].Inv[n].Num = Types.Classes[ClassNum].StartItem[n];
                        modTypes.Player[index].Character[CharNum].Inv[n].Value = Types.Classes[ClassNum].StartValue[n];

                        if (Convert.ToBoolean(Types.Item[Types.Classes[ClassNum].StartItem[n]].Randomize))
                        {
                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[n].Prefix = "";
                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[n].Suffix = "";
                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[n].Rarity = (int)Enums.RarityType.RARITY_COMMON;
                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[n].Damage = Types.Item[Types.Classes[ClassNum].StartItem[n]].Data2;
                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[n].Speed = Types.Item[Types.Classes[ClassNum].StartItem[n]].Speed;
                            for (i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[n].Stat[i] = Types.Item[Types.Classes[ClassNum].StartItem[n]].Add_Stat[i];
                        }
                    }
                }

                // set skills
                modTypes.Player[index].Character[CharNum].GatherSkills = new ResourceSkillsRec[5];
                for (i = 0; i <= (int)Enums.ResourceSkills.Count - 1; i++)
                {
                    modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillLevel = 1;
                    modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillCurExp = 0;
                    modTypes.Player[index].Character[CharNum].GatherSkills[i].SkillNextLvlExp = 100;
                }

                // Append name to file
                AddTextToFile(Name, @"accounts\charlist.txt");

                SavePlayer(index);
                return;
            }
        }

        public static bool FindChar(string Name)
        {
            bool FindChar = false;
            string[] characters;
            string fullpath;
            string Contents;

            fullpath = Path.Combine(Application.StartupPath, "data", "accounts", "charlist.txt");

            Contents = GetFileContents(fullpath);
            characters = Microsoft.VisualBasic.Strings.Split(Contents, Microsoft.VisualBasic.Constants.vbNewLine);
            var loopTo = Information.UBound(characters);
            for (var i = 0; i <= loopTo; i++)
            {
                if (characters[i].ToLower().Trim() == Name.ToLower().Trim())
                    FindChar = true;
            }

            return FindChar;
        }



        internal static void SaveOptions()
        {
            XmlClass myXml = new XmlClass()
            {
                Filename = Path.Combine(Application.StartupPath, "Data", "Config.xml"),
                Root = "Options"
            };

            // Check if xml filename is here.
            if (!File.Exists(myXml.Filename))
                // Create new blank xml file.
                myXml.NewXmlDocument();

            myXml.LoadXml();
            myXml.WriteString("Settings", "Game_Name", modTypes.Options.GameName);
            myXml.WriteString("Settings", "Port", Conversion.Str(modTypes.Options.Port));
            myXml.WriteString("Settings", "MoTd", modTypes.Options.Motd);

            myXml.WriteString("Settings", "Website", Microsoft.VisualBasic.Strings.Trim(modTypes.Options.Website));

            myXml.WriteString("Settings", "StartMap", modTypes.Options.StartMap.ToString());
            myXml.WriteString("Settings", "StartX", modTypes.Options.StartX.ToString());
            myXml.WriteString("Settings", "StartY", modTypes.Options.StartY.ToString());
            myXml.WriteString("Game", "xpMultiplier", modTypes.Options.xpMultiplier.ToString());
            myXml.CloseXml(true);
        }

        internal static void LoadOptions()
        {
            XmlClass myXml = new XmlClass()
            {
                Filename = Path.Combine(Application.StartupPath, "Data", "Config.xml"),
                Root = "Options"
            };
            myXml.LoadXml();
            modTypes.Options.GameName = myXml.ReadString("Settings", "Game_Name", "Orion+#");
            modTypes.Options.Port = Convert.ToInt32(myXml.ReadString("Settings", "Port", "7001"));
            modTypes.Options.Motd = myXml.ReadString("Settings", "MoTd", "Welcome to the Orion+# Engine");
            modTypes.Options.Website = myXml.ReadString("Settings", "Website", "http://ascensiongamedev.com/index.php");
            modTypes.Options.StartMap = Convert.ToInt32(myXml.ReadString("Settings", "StartMap", "1"));
            modTypes.Options.StartX = Convert.ToInt32(myXml.ReadString("Settings", "StartX", "13+"));
            modTypes.Options.StartY = Convert.ToInt32(myXml.ReadString("Settings", "StartY", "7"));
            modTypes.Options.xpMultiplier = Convert.ToSingle(myXml.ReadString("Game", "xpMultiplier", "1"));
            myXml.CloseXml(false);
        }



        internal static string GetFileContents(string fullPath)
        {
            var strContents = "";
            StreamReader objReader;
            if (!File.Exists(fullPath))
                File.Create(fullPath).Dispose();
            try
            {
                objReader = new StreamReader(fullPath);
                strContents = objReader.ReadToEnd();
                objReader.Close();
            }
            catch
            {
            }
            return strContents;
        }

        internal static bool Addlog(string strData, string FN)
        {
            string fullpath;
            string contents;
            var bAns = false;
            StreamWriter objReader;
            fullpath = Path.Combine(Application.StartupPath, "data", "logs", FN);
            contents = GetFileContents(fullpath);
            contents = contents + Microsoft.VisualBasic.Constants.vbNewLine + strData;
            try
            {
                objReader = new StreamWriter(fullpath);
                objReader.Write(contents);
                objReader.Close();
                bAns = true;
            }
            catch
            {
            }
            return bAns;
        }

        internal static bool AddTextToFile(string strData, string fn)
        {
            string fullpath;
            string contents;
            var bAns = false;
            StreamWriter objReader;
            fullpath = Path.Combine(Application.StartupPath, "data", fn);
            contents = GetFileContents(fullpath);
            contents = contents + Microsoft.VisualBasic.Constants.vbNewLine + strData;
            try
            {
                objReader = new StreamWriter(fullpath);
                objReader.Write(contents);
                objReader.Close();
                bAns = true;
            }
            catch
            {
            }
            return bAns;
        }



        public static void ServerBanIndex(int BanPlayerindex)
        {
            string filename;
            string IP;
            int F;
            int i;
            filename = Application.StartupPath + @"\data\banlist.txt";

            // Make sure the file exists
            if (!File.Exists(@"data\banlist.txt"))
                F = FileSystem.FreeFile();

            // Cut off last portion of ip
            IP = S_NetworkConfig.Socket.ClientIp(BanPlayerindex);

            for (i = Microsoft.VisualBasic.Strings.Len(IP); i >= 1; i += -1)
            {
                if (Microsoft.VisualBasic.Strings.Mid(IP, i, 1) == ".")
                    break;
            }

            IP = Microsoft.VisualBasic.Strings.Mid(IP, 1, i);
            AddTextToFile(IP, "banlist.txt");
            S_NetworkSend.GlobalMsg(S_Players.GetPlayerName(BanPlayerindex) + " has been banned from " + modTypes.Options.GameName + " by " + "the Server" + "!");
            Addlog("The Server" + " has banned " + S_Players.GetPlayerName(BanPlayerindex) + ".", S_Constants.ADMIN_LOG);
            S_NetworkSend.AlertMsg(BanPlayerindex, "You have been banned by " + "The Server" + "!");
        }

        public static bool IsBanned(string IP)
        {
            string filename = Application.StartupPath + "\\data\\banlist.txt";
            bool flag = !File.Exists("data\\banlist.txt");
            bool IsBanned = false;
            if (flag)
            {
                IsBanned = false;
            }
            else
            {
                StreamReader sr = new StreamReader(filename);
                while (sr.Peek() >= 0)
                {
                    string line = sr.ReadLine();
                    if (Microsoft.VisualBasic.Strings.Trim(line.ToLower()) == Microsoft.VisualBasic.Strings.Trim(Microsoft.VisualBasic.Strings.Mid(IP, 1, Microsoft.VisualBasic.Strings.Len(line)).ToLower()))
                    {
                        IsBanned = true;
                    }
                }
                sr.Close();
            }
            return IsBanned;
        }

        public static void BanIndex(int BanPlayerindex, int BannedByindex)
        {
            string filename = Application.StartupPath + @"\Data\banlist.txt";
            string IP;
            int i;

            // Make sure the file exists
            if (!File.Exists(filename))
                File.Create(filename).Dispose();

            // Cut off last portion of ip
            IP = S_NetworkConfig.Socket.ClientIp(BanPlayerindex);

            for (i = Microsoft.VisualBasic.Strings.Len(IP); i >= 1; i += -1)
            {
                if (Microsoft.VisualBasic.Strings.Mid(IP, i, 1) == ".")
                    break;
            }

            IP = Microsoft.VisualBasic.Strings.Mid(IP, 1, i);
            AddTextToFile(IP, "banlist.txt");
            S_NetworkSend.GlobalMsg(S_Players.GetPlayerName(BanPlayerindex) + " has been banned from " + modTypes.Options.GameName + " by " + S_Players.GetPlayerName(BannedByindex) + "!");
            Addlog(S_Players.GetPlayerName(BannedByindex) + " has banned " + S_Players.GetPlayerName(BanPlayerindex) + ".", S_Constants.ADMIN_LOG);
            S_NetworkSend.AlertMsg(BanPlayerindex, "You have been banned by " + S_Players.GetPlayerName(BannedByindex) + "!");
        }



        public static byte[] ClassData()
        {
            int i;
            int n;
            int q;
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32(S_Globals.Max_Classes);
            var loopTo = S_Globals.Max_Classes;
            for (i = 1; i <= loopTo; i++)
            {
                buffer.WriteString((GetClassName(i).Trim()));
                buffer.WriteString((Types.Classes[i].Desc.Trim()));
                buffer.WriteInt32(GetClassMaxVital(i, Enums.VitalType.HP));
                buffer.WriteInt32(GetClassMaxVital(i, Enums.VitalType.MP));
                buffer.WriteInt32(GetClassMaxVital(i, Enums.VitalType.SP));

                // set sprite array size
                n = Information.UBound(Types.Classes[i].MaleSprite);

                // send array size
                buffer.WriteInt32(n);
                var loopTo1 = n;

                // loop around sending each sprite
                for (q = 0; q <= loopTo1; q++)
                    buffer.WriteInt32(Types.Classes[i].MaleSprite[q]);

                // set sprite array size
                n = Information.UBound(Types.Classes[i].FemaleSprite);

                // send array size
                buffer.WriteInt32(n);
                var loopTo2 = n;

                // loop around sending each sprite
                for (q = 0; q <= loopTo2; q++)
                    buffer.WriteInt32(Types.Classes[i].FemaleSprite[q]);

                buffer.WriteInt32(Types.Classes[i].Stat[(int)Enums.StatType.Strength]);
                buffer.WriteInt32(Types.Classes[i].Stat[(int)Enums.StatType.Endurance]);
                buffer.WriteInt32(Types.Classes[i].Stat[(int)Enums.StatType.Vitality]);
                buffer.WriteInt32(Types.Classes[i].Stat[(int)Enums.StatType.Intelligence]);
                buffer.WriteInt32(Types.Classes[i].Stat[(int)Enums.StatType.Luck]);
                buffer.WriteInt32(Types.Classes[i].Stat[(int)Enums.StatType.Spirit]);

                for (q = 1; q <= 5; q++)
                {
                    buffer.WriteInt32(Types.Classes[i].StartItem[q]);
                    buffer.WriteInt32(Types.Classes[i].StartValue[q]);
                }

                buffer.WriteInt32(Types.Classes[i].StartMap);
                buffer.WriteInt32(Types.Classes[i].StartX);
                buffer.WriteInt32(Types.Classes[i].StartY);

                buffer.WriteInt32(Types.Classes[i].BaseExp);
            }

            return buffer.ToArray();
        }

        public static byte[] NpcsData()
        {
            ByteStream buffer = new ByteStream(4);
            for (var i = 1; i <= Constants.MAX_NPCS; i++)
            {
                if (!(Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Npc[i].Name)) > 0))
                    continue;
                buffer.WriteBlock(NpcData(i));
            }
            return buffer.ToArray();
        }

        public static byte[] NpcData(int NpcNum)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32(NpcNum);
            buffer.WriteInt32(Types.Npc[NpcNum].Animation);
            buffer.WriteString((Types.Npc[NpcNum].AttackSay));
            buffer.WriteInt32(Types.Npc[NpcNum].Behaviour);
            for (var i = 1; i <= 5; i++)
            {
                buffer.WriteInt32(Types.Npc[NpcNum].DropChance[i]);
                buffer.WriteInt32(Types.Npc[NpcNum].DropItem[i]);
                buffer.WriteInt32(Types.Npc[NpcNum].DropItemValue[i]);
            }
            buffer.WriteInt32(Types.Npc[NpcNum].Exp);
            buffer.WriteInt32(Types.Npc[NpcNum].Faction);
            buffer.WriteInt32(Types.Npc[NpcNum].Hp);
            buffer.WriteString((Types.Npc[NpcNum].Name));
            buffer.WriteInt32(Types.Npc[NpcNum].Range);
            buffer.WriteInt32(Types.Npc[NpcNum].SpawnTime);
            buffer.WriteInt32(Types.Npc[NpcNum].SpawnSecs);
            buffer.WriteInt32(Types.Npc[NpcNum].Sprite);
            for (var i = 0; i <= (int)Enums.StatType.Count - 1; i++)
                buffer.WriteInt32(Types.Npc[NpcNum].Stat[i]);
            buffer.WriteInt32(Types.Npc[NpcNum].QuestNum);
            for (var i = 1; i <= Constants.MAX_NPC_SKILLS; i++)
                buffer.WriteInt32(Types.Npc[NpcNum].Skill[i]);
            buffer.WriteInt32(Types.Npc[NpcNum].Level);
            buffer.WriteInt32(Types.Npc[NpcNum].Damage);
            return buffer.ToArray();
        }

        public static byte[] ShopsData()
        {
            ByteStream buffer = new ByteStream(4);
            for (var i = 1; i <= Constants.MAX_SHOPS; i++)
            {
                if (!(Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Shop[i].Name)) > 0))
                    continue;
                buffer.WriteBlock(ShopData(i));
            }
            return buffer.ToArray();
        }

        public static byte[] ShopData(int shopNum)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32(shopNum);
            buffer.WriteInt32(Types.Shop[shopNum].BuyRate);
            buffer.WriteString((Types.Shop[shopNum].Name));
            buffer.WriteInt32(Types.Shop[shopNum].Face);
            for (var i = 0; i <= Constants.MAX_TRADES; i++)
            {
                buffer.WriteInt32(Types.Shop[shopNum].TradeItem[i].CostItem);
                buffer.WriteInt32(Types.Shop[shopNum].TradeItem[i].CostValue);
                buffer.WriteInt32(Types.Shop[shopNum].TradeItem[i].Item);
                buffer.WriteInt32(Types.Shop[shopNum].TradeItem[i].ItemValue);
            }
            return buffer.ToArray();
        }

        public static byte[] SkillsData()
        {
            ByteStream buffer = new ByteStream(4);
            for (var i = 1; i <= Constants.MAX_SKILLS; i++)
            {
                if (!(Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Skill[i].Name)) > 0))
                    continue;
                buffer.WriteBlock(SkillData(i));
            }
            return buffer.ToArray();
        }

        public static byte[] SkillData(int skillnum)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32(skillnum);
            buffer.WriteInt32(Types.Skill[skillnum].AccessReq);
            buffer.WriteInt32(Types.Skill[skillnum].AoE);
            buffer.WriteInt32(Types.Skill[skillnum].CastAnim);
            buffer.WriteInt32(Types.Skill[skillnum].CastTime);
            buffer.WriteInt32(Types.Skill[skillnum].CdTime);
            buffer.WriteInt32(Types.Skill[skillnum].ClassReq);
            buffer.WriteInt32(Types.Skill[skillnum].Dir);
            buffer.WriteInt32(Types.Skill[skillnum].Duration);
            buffer.WriteInt32(Types.Skill[skillnum].Icon);
            buffer.WriteInt32(Types.Skill[skillnum].Interval);
            buffer.WriteInt32(Convert.ToInt32(Types.Skill[skillnum].IsAoE));
            buffer.WriteInt32(Types.Skill[skillnum].LevelReq);
            buffer.WriteInt32(Types.Skill[skillnum].Map);
            buffer.WriteInt32(Types.Skill[skillnum].MpCost);
            buffer.WriteString((Types.Skill[skillnum].Name));
            buffer.WriteInt32(Types.Skill[skillnum].Range);
            buffer.WriteInt32(Types.Skill[skillnum].SkillAnim);
            buffer.WriteInt32(Types.Skill[skillnum].StunDuration);
            buffer.WriteInt32(Types.Skill[skillnum].Type);
            buffer.WriteInt32(Types.Skill[skillnum].Vital);
            buffer.WriteInt32(Types.Skill[skillnum].X);
            buffer.WriteInt32(Types.Skill[skillnum].Y);
            buffer.WriteInt32(Types.Skill[skillnum].IsProjectile);
            buffer.WriteInt32(Types.Skill[skillnum].Projectile);
            buffer.WriteInt32(Types.Skill[skillnum].KnockBack);
            buffer.WriteInt32(Types.Skill[skillnum].KnockBackTiles);
            return buffer.ToArray();
        }
    }
}
