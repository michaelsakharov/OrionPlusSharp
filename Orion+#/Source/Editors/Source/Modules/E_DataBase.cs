using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using static Engine.E_Types;
using static Engine.Types;

namespace Engine
{
    static class ClientDataBase
    {
        internal static Random GameRand = new Random();

        public static void ClearTempTile()
        {
            int X;
            int Y;
            E_Types.TempTile = new TempTileRec[E_Types.Map.MaxX + 1, E_Types.Map.MaxY + 1];
            var loopTo = E_Types.Map.MaxX;
            for (X = 0; X <= loopTo; X++)
            {
                var loopTo1 = E_Types.Map.MaxY;
                for (Y = 0; Y <= loopTo1; Y++)
                    E_Types.TempTile[X, Y].DoorOpen = 0;
            }
        }

        internal static bool IsInBounds()
        {
            bool IsInBounds = false;
            if ((E_Globals.CurX >= 0))
            {
                if ((E_Globals.CurX <= E_Types.Map.MaxX))
                {
                    if ((E_Globals.CurY >= 0))
                    {
                        if ((E_Globals.CurY <= E_Types.Map.MaxY))
                            IsInBounds = true;
                    }
                }
            }
            return IsInBounds;
        }

        internal static int GetTickCount()
        {
            return Environment.TickCount;
        }

        internal static int Rand(int MaxNumber, int MinNumber = 0)
        {
            if (MinNumber > MaxNumber)
            {
                int t = MinNumber;
                MinNumber = MaxNumber;
                MaxNumber = t;
            }

            return GameRand.Next(MinNumber, MaxNumber);
        }

        internal static void CheckTilesets()
        {
            int i;
            Bitmap tmp;
            i = 1;

            while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"\tilesets\" + i + E_Globals.GFX_EXT))
            {
                E_Graphics.NumTileSets = E_Graphics.NumTileSets + 1;
                i = i + 1;
            }

            E_Globals.TilesetsClr = new SFML.Graphics.Color[E_Graphics.NumTileSets + 1];
            var loopTo = E_Graphics.NumTileSets;
            for (i = 1; i <= loopTo; i++)
            {
                tmp = new Bitmap(Application.StartupPath + E_Globals.GFX_PATH + @"\tilesets\" + i + E_Globals.GFX_EXT);
                E_Globals.TilesetsClr[E_Graphics.NumTileSets] = new SFML.Graphics.Color(tmp.GetPixel(0, 0).R, tmp.GetPixel(0, 0).G, tmp.GetPixel(0, 0).B);
            }
            if (E_Graphics.NumTileSets == 0)
                return;
        }

        internal static void CheckCharacters()
        {
            int i;
            i = 1;

            while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"characters\" + i + E_Globals.GFX_EXT))
            {
                E_Graphics.NumCharacters = E_Graphics.NumCharacters + 1;
                i = i + 1;
            }

            if (E_Graphics.NumCharacters == 0)
                return;
        }

        internal static void CheckPaperdolls()
        {
            int i;
            i = 1;

            while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"paperdolls\" + i + E_Globals.GFX_EXT))
            {
                E_Graphics.NumPaperdolls = E_Graphics.NumPaperdolls + 1;
                i = i + 1;
            }

            if (E_Graphics.NumPaperdolls == 0)
                return;
        }

        internal static void CheckAnimations()
        {
            int i;
            i = 1;

            while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"animations\" + i + E_Globals.GFX_EXT))
            {
                E_Graphics.NumAnimations = E_Graphics.NumAnimations + 1;
                i = i + 1;
            }

            if (E_Graphics.NumAnimations == 0)
                return;
        }

        internal static void CheckResources()
        {
            int i;
            i = 1;

            while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Resources\" + i + E_Globals.GFX_EXT))
            {
                E_Graphics.NumResources = E_Graphics.NumResources + 1;
                i = i + 1;
            }

            if (E_Graphics.NumResources == 0)
                return;
        }

        internal static void CheckSkillIcons()
        {
            int i;
            i = 1;

            while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"SkillIcons\" + i + E_Globals.GFX_EXT))
            {
                E_Graphics.NumSkillIcons = E_Graphics.NumSkillIcons + 1;
                i = i + 1;
            }

            if (E_Graphics.NumSkillIcons == 0)
                return;
        }

        internal static void CheckFaces()
        {
            int i;
            i = 1;

            while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Faces\" + i + E_Globals.GFX_EXT))
            {
                E_Graphics.NumFaces = E_Graphics.NumFaces + 1;
                i = i + 1;
            }

            if (E_Graphics.NumFaces == 0)
                return;
        }

        internal static void CheckFog()
        {
            int i;
            i = 1;

            while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Fogs\" + i + E_Globals.GFX_EXT))
            {
                E_Graphics.NumFogs = E_Graphics.NumFogs + 1;
                i = i + 1;
            }

            if (E_Graphics.NumFogs == 0)
                return;
        }

        internal static void CacheMusic()
        {
            string[] Files = Directory.GetFiles(Application.StartupPath + E_Globals.MUSIC_PATH, "*.ogg");
            string MaxNum = Directory.GetFiles(Application.StartupPath + E_Globals.MUSIC_PATH, "*.ogg").Count().ToString();
            int Counter = 1;

            foreach (var FileName in Files)
            {
                var oldMusicCache = E_Sound.MusicCache;
                E_Sound.MusicCache = new string[Counter + 1];
                if (oldMusicCache != null)
                    Array.Copy(oldMusicCache, E_Sound.MusicCache, Math.Min(Counter + 1, oldMusicCache.Length));

                E_Sound.MusicCache[Counter] = Path.GetFileName(FileName);
                Counter = Counter + 1;
                Application.DoEvents();
            }
        }

        internal static void CacheSound()
        {
            string[] Files = Directory.GetFiles(Application.StartupPath + E_Globals.SOUND_PATH, "*.ogg");
            string MaxNum = Directory.GetFiles(Application.StartupPath + E_Globals.SOUND_PATH, "*.ogg").Count().ToString();
            int Counter = 1;

            foreach (var FileName in Files)
            {
                var oldSoundCache = E_Sound.SoundCache;
                E_Sound.SoundCache = new string[Counter + 1];
                if (oldSoundCache != null)
                    Array.Copy(oldSoundCache, E_Sound.SoundCache, Math.Min(Counter + 1, oldSoundCache.Length));

                E_Sound.SoundCache[Counter] = Path.GetFileName(FileName);
                Counter = Counter + 1;
                Application.DoEvents();
            }
        }

        internal static string GetFileContents(string FullPath, string ErrInfo = "")
        {
            string strContents;
            StreamReader objReader;
            strContents = "";
            try
            {
                objReader = new StreamReader(FullPath);
                strContents = objReader.ReadToEnd();
                objReader.Close();
            }
            catch (Exception Ex)
            {
                ErrInfo = Ex.Message;
            }
            return strContents;
        }

        public static void ClearMap()
        {
            lock (E_Types.MapLock)
            {
                E_Types.Map.mapNum = 0;
                E_Types.Map.Name = "";
                E_Types.Map.tileset = 1;
                E_Types.Map.MaxX = E_Globals.SCREEN_MAPX;
                E_Types.Map.MaxY = E_Globals.SCREEN_MAPY;
                E_Types.Map.BootMap = 0;
                E_Types.Map.BootX = 0;
                E_Types.Map.BootY = 0;
                E_Types.Map.Down = 0;
                E_Types.Map.Left = 0;
                E_Types.Map.Moral = 0;
                E_Types.Map.Music = "";
                E_Types.Map.Revision = 0;
                E_Types.Map.Right = 0;
                E_Types.Map.Up = 0;

                E_Types.Map.Npc = new int[Constants.MAX_MAP_NPCS + 1];
                E_Types.Map.Tile = new TileRec[E_Types.Map.MaxX + 1, E_Types.Map.MaxY + 1];
                var loopTo = E_Globals.SCREEN_MAPX;
                for (var x = 0; x <= loopTo; x++)
                {
                    var loopTo1 = E_Globals.SCREEN_MAPY;
                    for (var y = 0; y <= loopTo1; y++)
                    {
                        E_Types.Map.Tile[x, y].Layer = new TileDataRec[6];
                        for (var l = 0; l <= (byte)Enums.LayerType.Count - 1; l++)
                        {
                            E_Types.Map.Tile[x, y].Layer[l].Tileset = 0;
                            E_Types.Map.Tile[x, y].Layer[l].X = 0;
                            E_Types.Map.Tile[x, y].Layer[l].Y = 0;
                            E_Types.Map.Tile[x, y].Layer[l].AutoTile = 0;
                        }
                    }
                }
            }
        }

        public static void ClearMapItems()
        {
            int i;

            for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
                ClearMapItem(i);
        }

        public static void ClearMapItem(int index)
        {
            E_Types.MapItem[index].Frame = 0;
            E_Types.MapItem[index].Num = 0;
            E_Types.MapItem[index].Value = 0;
            E_Types.MapItem[index].X = 0;
            E_Types.MapItem[index].Y = 0;
        }

        public static void ClearMapNpc(int index)
        {
            E_Types.MapNpc[index].Attacking = 0;
            E_Types.MapNpc[index].AttackTimer = 0;
            E_Types.MapNpc[index].Dir = 0;
            E_Types.MapNpc[index].Map = 0;
            E_Types.MapNpc[index].Moving = 0;
            E_Types.MapNpc[index].Num = 0;
            E_Types.MapNpc[index].Steps = 0;
            E_Types.MapNpc[index].Target = 0;
            E_Types.MapNpc[index].TargetType = 0;
            E_Types.MapNpc[index].Vital[(byte)Enums.VitalType.HP] = 0;
            E_Types.MapNpc[index].Vital[(byte)Enums.VitalType.MP] = 0;
            E_Types.MapNpc[index].Vital[(byte)Enums.VitalType.SP] = 0;
            E_Types.MapNpc[index].X = 0;
            E_Types.MapNpc[index].XOffset = 0;
            E_Types.MapNpc[index].Y = 0;
            E_Types.MapNpc[index].YOffset = 0;
        }

        public static void ClearMapNpcs()
        {
            int i;

            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
                ClearMapNpc(i);
        }

        internal static void ClearChanged_Resource()
        {
            for (var i = 1; i <= Constants.MAX_RESOURCES; i++)
                E_Globals.Resource_Changed[i] = default(bool);
            E_Globals.Resource_Changed = new bool[101];
        }

        public static void ClearResource(int index)
        {
            Types.Resource[index] = default(ResourceRec);
            Types.Resource[index] = new Types.ResourceRec()
            {
                Name = ""
            };
        }

        public static void ClearResources()
        {
            int i;

            for (i = 1; i <= Constants.MAX_RESOURCES; i++)
                ClearResource(i);
        }

        public static void ClearNpcs()
        {
            int i;

            for (i = 1; i <= Constants.MAX_NPCS; i++)
                ClearNpc(i);
        }

        public static void ClearNpc(int index)
        {
            Types.Npc[index] = default(NpcRec);
            Types.Npc[index].Name = "";
            Types.Npc[index].AttackSay = "";
            Types.Npc[index].Stat = new byte[7];
            Types.Npc[index].Skill = new byte[Constants.MAX_NPC_SKILLS + 1];

            Types.Npc[index].DropItem = new int[6];
            Types.Npc[index].DropItemValue = new int[6];
            Types.Npc[index].DropChance = new int[6];
        }

        public static void ClearAnimation(int index)
        {
            Types.Animation[index] = default(AnimationRec);
            Types.Animation[index] = new Types.AnimationRec();
            for (var x = 0; x <= 1; x++)
                Types.Animation[index].Sprite = new int[x + 1];
            for (int x = 0; x <= 1; x++)
                Types.Animation[index].Frames = new int[x + 1];
            for (int x = 0; x <= 1; x++)
                Types.Animation[index].LoopCount = new int[x + 1];
            for (int x = 0; x <= 1; x++)
                Types.Animation[index].LoopTime = new int[x + 1];
            Types.Animation[index].Name = "";
        }

        public static void ClearAnimations()
        {
            int i;

            for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
                ClearAnimation(i);
        }

        public static void ClearSkills()
        {
            int i;

            for (i = 1; i <= Constants.MAX_SKILLS; i++)
                ClearSkill(i);
        }

        public static void ClearSkill(int index)
        {
            Types.Skill[index] = default(SkillRec);
            Types.Skill[index] = new Types.SkillRec()
            {
                Name = ""
            };
        }

        public static void ClearShop(int index)
        {
            Types.Shop[index] = default(ShopRec);
            Types.Shop[index] = new Types.ShopRec()
            {
                Name = ""
            };
            Types.Shop[index].TradeItem = new TradeItemRec[Constants.MAX_TRADES + 1];
        }

        public static void ClearShops()
        {
            int i;

            for (i = 1; i <= Constants.MAX_SHOPS; i++)
                ClearShop(i);
        }
    }
}
