using System.Windows.Forms;
using System;
using System.IO;
using SFML.Graphics;
using SFML.Window;
using System.Drawing;

namespace Engine
{
    static class E_Graphics
    {
        internal static RenderWindow GameWindow;
        internal static RenderWindow TilesetWindow;

        internal static RenderWindow EditorItem_Furniture;

        internal static RenderWindow EditorSkill_Icon;

        internal static RenderWindow EditorAnimation_Anim1;
        internal static RenderWindow EditorAnimation_Anim2;

        internal static RenderWindow TmpItemWindow;

        internal static SFML.Graphics.Font SFMLGameFont;

        // TileSets
        internal static Texture[] TileSetTexture;

        internal static Sprite[] TileSetSprite;
        internal static GraphicInfo[] TileSetTextureInfo;

        // Characters
        internal static Texture[] CharacterGFX;

        internal static Sprite[] CharacterSprite;
        internal static GraphicInfo[] CharacterGFXInfo;

        // Paperdolls
        internal static Texture[] PaperDollGFX;

        internal static Sprite[] PaperDollSprite;
        internal static GraphicInfo[] PaperDollGFXInfo;

        // Items
        internal static Texture[] ItemsGFX;

        internal static Sprite[] ItemsSprite;
        internal static GraphicInfo[] ItemsGFXInfo;

        // Resources
        internal static Texture[] ResourcesGFX;

        internal static Sprite[] ResourcesSprite;
        internal static GraphicInfo[] ResourcesGFXInfo;

        // Animations
        internal static Texture[] AnimationsGFX;

        internal static Sprite[] AnimationsSprite;
        internal static GraphicInfo[] AnimationsGFXInfo;

        // Skills
        internal static Texture[] SkillIconsGFX;

        internal static Sprite[] SkillIconsSprite;
        internal static GraphicInfo[] SkillIconsGFXInfo;

        // Housing
        internal static Texture[] FurnitureGFX;

        internal static Sprite[] FurnitureSprite;
        internal static GraphicInfo[] FurnitureGFXInfo;

        // Faces
        internal static Texture[] FacesGFX;

        internal static Sprite[] FacesSprite;
        internal static GraphicInfo[] FacesGFXInfo;

        // Projectiles
        internal static Texture[] ProjectileGFX;

        internal static Sprite[] ProjectileSprite;
        internal static GraphicInfo[] ProjectileGFXInfo;

        // Fogs
        internal static Texture[] FogGFX;

        internal static Sprite[] FogSprite;
        internal static GraphicInfo[] FogGFXInfo;

        // Door
        internal static Texture DoorGFX;

        internal static Sprite DoorSprite;
        internal static GraphicInfo DoorGFXInfo;

        // Directions
        internal static Texture DirectionsGfx;

        internal static Sprite DirectionsSprite;
        internal static GraphicInfo DirectionsGFXInfo;

        // Weather
        internal static Texture WeatherGFX;

        internal static Sprite WeatherSprite;
        internal static GraphicInfo WeatherGFXInfo;

        // Number of graphic files
        internal static Bitmap MapEditorBackBuffer;

        internal static Sprite MapTintSprite;

        internal static int NumTileSets;
        internal static int NumCharacters;
        internal static int NumPaperdolls;
        internal static int NumItems;
        internal static int NumResources;
        internal static int NumAnimations;
        internal static int NumSkillIcons;
        internal static int NumFaces;
        internal static int NumFogs;

        internal static RenderTexture NightGfx = new RenderTexture(245, 245);
        internal static Sprite NightSprite;
        internal static GraphicInfo NightGfxInfo;

        internal static Texture LightGfx;
        internal static Sprite LightSprite;
        internal static GraphicInfo LightGfxInfo;

        internal struct GraphicInfo
        {
            public int width;
            public int height;
            public bool IsLoaded;
            public int TextureTimer;
        }

        internal struct Graphics_Tiles
        {
            public Texture[,] Tile;
        }

        public static void InitGraphics()
        {
            GameWindow = new RenderWindow(My.MyProject.Forms.frmMapEditor.picScreen.Handle);
            GameWindow.SetFramerateLimit(E_Globals.FPS_LIMIT);

            TilesetWindow = new RenderWindow(My.MyProject.Forms.frmMapEditor.picBackSelect.Handle);

            EditorItem_Furniture = new RenderWindow(My.MyProject.Forms.FrmItem.picFurniture.Handle);

            EditorSkill_Icon = new RenderWindow(My.MyProject.Forms.frmSkill.picSprite.Handle);

            EditorAnimation_Anim1 = new RenderWindow(My.MyProject.Forms.FrmAnimation.picSprite0.Handle);
            EditorAnimation_Anim2 = new RenderWindow(My.MyProject.Forms.FrmAnimation.picSprite1.Handle);

            SFMLGameFont = new SFML.Graphics.Font(Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + @"\" + E_Globals.FONT_NAME);

            // this stuff only loads when needed :)

            TileSetTexture = new Texture[NumTileSets + 1];
            TileSetSprite = new Sprite[NumTileSets + 1];
            TileSetTextureInfo = new GraphicInfo[NumTileSets + 1];

            CharacterGFX = new Texture[NumCharacters + 1];
            CharacterSprite = new Sprite[NumCharacters + 1];
            CharacterGFXInfo = new GraphicInfo[NumCharacters + 1];

            PaperDollGFX = new Texture[NumPaperdolls + 1];
            PaperDollSprite = new Sprite[NumPaperdolls + 1];
            PaperDollGFXInfo = new GraphicInfo[NumPaperdolls + 1];

            ItemsGFX = new Texture[NumItems + 1];
            ItemsSprite = new Sprite[NumItems + 1];
            ItemsGFXInfo = new GraphicInfo[NumItems + 1];

            ResourcesGFX = new Texture[NumResources + 1];
            ResourcesSprite = new Sprite[NumResources + 1];
            ResourcesGFXInfo = new GraphicInfo[NumResources + 1];

            AnimationsGFX = new Texture[NumAnimations + 1];
            AnimationsSprite = new Sprite[NumAnimations + 1];
            AnimationsGFXInfo = new GraphicInfo[NumAnimations + 1];

            SkillIconsGFX = new Texture[NumSkillIcons + 1];
            SkillIconsSprite = new Sprite[NumSkillIcons + 1];
            SkillIconsGFXInfo = new GraphicInfo[NumSkillIcons + 1];

            FacesGFX = new Texture[NumFaces + 1];
            FacesSprite = new Sprite[NumFaces + 1];
            FacesGFXInfo = new GraphicInfo[NumFaces + 1];

            FurnitureGFX = new Texture[E_Housing.NumFurniture + 1];
            FurnitureSprite = new Sprite[E_Housing.NumFurniture + 1];
            FurnitureGFXInfo = new GraphicInfo[E_Housing.NumFurniture + 1];

            ProjectileGFX = new Texture[E_Projectiles.NumProjectiles + 1];
            ProjectileSprite = new Sprite[E_Projectiles.NumProjectiles + 1];
            ProjectileGFXInfo = new GraphicInfo[E_Projectiles.NumProjectiles + 1];

            FogGFX = new Texture[NumFogs + 1];
            FogSprite = new Sprite[NumFogs + 1];
            FogGFXInfo = new GraphicInfo[NumFogs + 1];

            // sadly, gui shit is always needed, so we preload it :/
            DoorGFXInfo = new GraphicInfo();
            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Misc\Door" + E_Globals.GFX_EXT))
            {
                // Load texture first, dont care about memory streams (just use the filename)
                DoorGFX = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"Misc\Door" + E_Globals.GFX_EXT);
                DoorSprite = new Sprite(DoorGFX);

                // Cache the width and height
                DoorGFXInfo.width = (int)DoorGFX.Size.X;
                DoorGFXInfo.height = (int)DoorGFX.Size.Y;
            }

            DirectionsGFXInfo = new GraphicInfo();
            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Misc\Direction" + E_Globals.GFX_EXT))
            {
                // Load texture first, dont care about memory streams (just use the filename)
                DirectionsGfx = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"Misc\Direction" + E_Globals.GFX_EXT);
                DirectionsSprite = new Sprite(DirectionsGfx);

                // Cache the width and height
                DirectionsGFXInfo.width = (int)DirectionsGfx.Size.X;
                DirectionsGFXInfo.height = (int)DirectionsGfx.Size.Y;
            }

            WeatherGFXInfo = new GraphicInfo();
            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Misc\Weather" + E_Globals.GFX_EXT))
            {
                // Load texture first, dont care about memory streams (just use the filename)
                WeatherGFX = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"Misc\Weather" + E_Globals.GFX_EXT);
                WeatherSprite = new Sprite(WeatherGFX);

                // Cache the width and height
                WeatherGFXInfo.width = (int)WeatherGFX.Size.X;
                WeatherGFXInfo.height = (int)WeatherGFX.Size.Y;
            }

            LightGfxInfo = new GraphicInfo();
            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Misc\Light" + E_Globals.GFX_EXT))
            {
                LightGfx = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"Misc\Light" + E_Globals.GFX_EXT);
                LightSprite = new Sprite(LightGfx);

                // Cache the width and height
                LightGfxInfo.width = (int)LightGfx.Size.X;
                LightGfxInfo.height = (int)LightGfx.Size.Y;
            }
        }

        internal static void LoadTexture(int index, byte TexType)
        {
            if (TexType == 1)
            {
                if (index <= 0 || index > NumTileSets)
                    return;

                // Load texture first, dont care about memory streams (just use the filename)
                TileSetTexture[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"tilesets\" + index + E_Globals.GFX_EXT);
                TileSetSprite[index] = new Sprite(TileSetTexture[index]);

                // Cache the width and height
                {
                    var withBlock = TileSetTextureInfo[index];
                    withBlock.width = (int)TileSetTexture[index].Size.X;
                    withBlock.height = (int)TileSetTexture[index].Size.Y;
                    withBlock.IsLoaded = true;
                    withBlock.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }
            }
            else if (TexType == 2)
            {
                if (index <= 0 || index > NumCharacters)
                    return;

                // Load texture first, dont care about memory streams (just use the filename)
                CharacterGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"characters\" + index + E_Globals.GFX_EXT);
                CharacterSprite[index] = new Sprite(CharacterGFX[index]);

                // Cache the width and height
                {
                    var withBlock10 = CharacterGFXInfo[index];
                    withBlock10.width = (int)CharacterGFX[index].Size.X;
                    withBlock10.height = (int)CharacterGFX[index].Size.Y;
                    withBlock10.IsLoaded = true;
                    withBlock10.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }
            }
            else if (TexType == 3)
            {
                if (index <= 0 || index > NumPaperdolls)
                    return;

                // Load texture first, dont care about memory streams (just use the filename)
                PaperDollGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"Paperdolls\" + index + E_Globals.GFX_EXT);
                PaperDollSprite[index] = new Sprite(PaperDollGFX[index]);

                // Cache the width and height
                {
                    var withBlock9 = PaperDollGFXInfo[index];
                    withBlock9.width = (int)PaperDollGFX[index].Size.X;
                    withBlock9.height = (int)PaperDollGFX[index].Size.Y;
                    withBlock9.IsLoaded = true;
                    withBlock9.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }
            }
            else if (TexType == 4)
            {
                if (index <= 0 || index > NumItems)
                    return;

                // Load texture first, dont care about memory streams (just use the filename)
                ItemsGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"items\" + index + E_Globals.GFX_EXT);
                ItemsSprite[index] = new Sprite(ItemsGFX[index]);

                // Cache the width and height
                {
                    var withBlock8 = ItemsGFXInfo[index];
                    withBlock8.width = (int)ItemsGFX[index].Size.X;
                    withBlock8.height = (int)ItemsGFX[index].Size.Y;
                    withBlock8.IsLoaded = true;
                    withBlock8.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }
            }
            else if (TexType == 5)
            {
                if (index <= 0 || index > NumResources)
                    return;

                // Load texture first, dont care about memory streams (just use the filename)
                ResourcesGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"resources\" + index + E_Globals.GFX_EXT);
                ResourcesSprite[index] = new Sprite(ResourcesGFX[index]);

                // Cache the width and height
                {
                    var withBlock7 = ResourcesGFXInfo[index];
                    withBlock7.width = (int)ResourcesGFX[index].Size.X;
                    withBlock7.height = (int)ResourcesGFX[index].Size.Y;
                    withBlock7.IsLoaded = true;
                    withBlock7.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }
            }
            else if (TexType == 6)
            {
                if (index <= 0 || index > NumAnimations)
                    return;

                // Load texture first, dont care about memory streams (just use the filename)
                AnimationsGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"Animations\" + index + E_Globals.GFX_EXT);
                AnimationsSprite[index] = new Sprite(AnimationsGFX[index]);

                // Cache the width and height
                {
                    var withBlock6 = AnimationsGFXInfo[index];
                    withBlock6.width = (int)AnimationsGFX[index].Size.X;
                    withBlock6.height = (int)AnimationsGFX[index].Size.Y;
                    withBlock6.IsLoaded = true;
                    withBlock6.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }
            }
            else if (TexType == 7)
            {
                if (index <= 0 || index > NumFaces)
                    return;

                // Load texture first, dont care about memory streams (just use the filename)
                FacesGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"Faces\" + index + E_Globals.GFX_EXT);
                FacesSprite[index] = new Sprite(FacesGFX[index]);

                // Cache the width and height
                {
                    var withBlock5 = FacesGFXInfo[index];
                    withBlock5.width = (int)FacesGFX[index].Size.X;
                    withBlock5.height = (int)FacesGFX[index].Size.Y;
                    withBlock5.IsLoaded = true;
                    withBlock5.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }
            }
            else if (TexType == 8)
            {
                if (index <= 0 || index > NumFogs)
                    return;

                // Load texture first, dont care about memory streams (just use the filename)
                FogGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"Fogs\" + index + E_Globals.GFX_EXT);
                FogSprite[index] = new Sprite(FogGFX[index]);

                // Cache the width and height
                {
                    var withBlock4 = FogGFXInfo[index];
                    withBlock4.width = (int)FogGFX[index].Size.X;
                    withBlock4.height = (int)FogGFX[index].Size.Y;
                    withBlock4.IsLoaded = true;
                    withBlock4.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }
            }
            else if (TexType == 9)
            {
                if (index <= 0 || index > NumSkillIcons)
                    return;

                // Load texture first, dont care about memory streams (just use the filename)
                SkillIconsGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"SkillIcons\" + index + E_Globals.GFX_EXT);
                SkillIconsSprite[index] = new Sprite(SkillIconsGFX[index]);

                // Cache the width and height
                {
                    var withBlock3 = SkillIconsGFXInfo[index];
                    withBlock3.width = (int)SkillIconsGFX[index].Size.X;
                    withBlock3.height = (int)SkillIconsGFX[index].Size.Y;
                    withBlock3.IsLoaded = true;
                    withBlock3.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }
            }
            else if (TexType == 10)
            {
                if (index <= 0 || index > E_Housing.NumFurniture)
                    return;

                // Load texture first, dont care about memory streams (just use the filename)
                FurnitureGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"Furniture\" + index + E_Globals.GFX_EXT);
                FurnitureSprite[index] = new Sprite(FurnitureGFX[index]);

                // Cache the width and height
                {
                    var withBlock2 = FurnitureGFXInfo[index];
                    withBlock2.width = (int)FurnitureGFX[index].Size.X;
                    withBlock2.height = (int)FurnitureGFX[index].Size.Y;
                    withBlock2.IsLoaded = true;
                    withBlock2.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }
            }
            else if (TexType == 11)
            {
                if (index <= 0 || index > E_Projectiles.NumProjectiles)
                    return;

                // Load texture first, dont care about memory streams (just use the filename)
                ProjectileGFX[index] = new Texture(Application.StartupPath + E_Globals.GFX_PATH + @"Projectiles\" + index + E_Globals.GFX_EXT);
                ProjectileSprite[index] = new Sprite(ProjectileGFX[index]);

                // Cache the width and height
                {
                    var withBlock1 = ProjectileGFXInfo[index];
                    withBlock1.width = (int)ProjectileGFX[index].Size.X;
                    withBlock1.height = (int)ProjectileGFX[index].Size.Y;
                    withBlock1.IsLoaded = true;
                    withBlock1.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }
            }
        }

        internal static void RenderSprite(Sprite TmpSprite, RenderWindow Target, int DestX, int DestY, int SourceX, int SourceY, int SourceWidth, int SourceHeight)
        {
            TmpSprite.TextureRect = new IntRect(SourceX, SourceY, SourceWidth, SourceHeight);
            TmpSprite.Position = new Vector2f(DestX, DestY);
            Target.Draw(TmpSprite);
        }

        internal static void DrawDirections(int X, int Y)
        {
            Rectangle rec = new Rectangle();

            // render grid
            rec.Y = 24;
            rec.X = 0;
            rec.Width = 32;
            rec.Height = 32;

            RenderSprite(DirectionsSprite, GameWindow, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y), rec.X, rec.Y, rec.Width, rec.Height);

            // render dir blobs
            for (int i = 1; i <= 4; i++)
            {
                rec.X = (i - 1) * 8;
                rec.Width = 8;
                // find out whether render blocked or not
                if (!IsDirBlocked(ref E_Types.Map.Tile[X, Y].DirBlock, (byte)i))
                    rec.Y = 8;
                else
                    rec.Y = 16;
                rec.Height = 8;

                RenderSprite(DirectionsSprite, GameWindow, ConvertMapX(X * E_Globals.PIC_X) + E_Globals.DirArrowX[i], ConvertMapY(Y * E_Globals.PIC_Y) + E_Globals.DirArrowY[i], rec.X, rec.Y, rec.Width, rec.Height);
            }
        }

        // BitWise Operators for directional blocking
        internal static void SetDirBlock(ref byte blockvar, byte Dir, bool block)
        {
            checked
            {
                if (block)
                {
                    blockvar = (byte)(unchecked(blockvar) | (ulong)((long)Math.Round(Math.Pow(2.0, Dir))));
                }
                else
                {
                    blockvar = (byte)(unchecked(blockvar) & (~(ulong)((long)Math.Round(Math.Pow(2.0, Dir)))));
                }
            }
        }

        internal static bool IsDirBlocked(ref byte blockvar, byte Dir)
        {
            return !(~blockvar <= 0 || Math.Pow(2.0, (double)Dir) == 0.0);
        }

        internal static int ConvertMapX(int X)
        {
            return X - (E_Globals.TileView.Left * E_Globals.PIC_X) - E_Globals.Camera.Left;
        }

        internal static int ConvertMapY(int Y)
        {
            return Y - (E_Globals.TileView.Top * E_Globals.PIC_Y) - E_Globals.Camera.Top;
        }

        internal static void DrawNpc(int MapNpcNum)
        {
            byte anim = 0;
            int X = 0;
            int Y = 0;
            int Sprite = 0;
            int spriteleft = 0;
            Rectangle destrec = new Rectangle();
            Rectangle srcrec;
            int attackspeed;

            if (E_Types.MapNpc[MapNpcNum].Num == 0)
                return; // no npc set

            if (E_Types.MapNpc[MapNpcNum].X < E_Globals.TileView.Left || E_Types.MapNpc[MapNpcNum].X > E_Globals.TileView.Right)
                return;
            if (E_Types.MapNpc[MapNpcNum].Y < E_Globals.TileView.Top || E_Types.MapNpc[MapNpcNum].Y > E_Globals.TileView.Bottom)
                return;

            Sprite = Types.Npc[E_Types.MapNpc[MapNpcNum].Num].Sprite;

            if (Sprite < 1 || Sprite > NumCharacters)
                return;

            attackspeed = 1000;

            // Reset frame
            anim = 0;

            // Check for attacking animation
            if (E_Types.MapNpc[MapNpcNum].AttackTimer + (attackspeed / (int)2) > ClientDataBase.GetTickCount())
            {
                if (E_Types.MapNpc[MapNpcNum].Attacking == 1)
                    anim = 3;
            }
            else
                // If not attacking, walk normally
                switch (E_Types.MapNpc[MapNpcNum].Dir)
                {
                    case (byte)Enums.DirectionType.Up:
                        {
                            if ((E_Types.MapNpc[MapNpcNum].YOffset > 8))
                                anim = (byte)E_Types.MapNpc[MapNpcNum].Steps;
                            break;
                        }

                    case (byte)Enums.DirectionType.Down:
                        {
                            if ((E_Types.MapNpc[MapNpcNum].YOffset < -8))
                                anim = (byte)E_Types.MapNpc[MapNpcNum].Steps;
                            break;
                        }

                    case (byte)Enums.DirectionType.Left:
                        {
                            if ((E_Types.MapNpc[MapNpcNum].XOffset > 8))
                                anim = (byte)E_Types.MapNpc[MapNpcNum].Steps;
                            break;
                        }

                    case (byte)Enums.DirectionType.Right:
                        {
                            if ((E_Types.MapNpc[MapNpcNum].XOffset < -8))
                                anim = (byte)E_Types.MapNpc[MapNpcNum].Steps;
                            break;
                        }
                }

            // Check to see if we want to stop making him attack
            {
                var withBlock = E_Types.MapNpc[MapNpcNum];
                if (withBlock.AttackTimer + attackspeed < ClientDataBase.GetTickCount())
                {
                    withBlock.Attacking = 0;
                    withBlock.AttackTimer = 0;
                }
            }

            // Set the left
            switch (E_Types.MapNpc[MapNpcNum].Dir)
            {
                case (byte)Enums.DirectionType.Up:
                    {
                        spriteleft = 3;
                        break;
                    }

                case (byte)Enums.DirectionType.Right:
                    {
                        spriteleft = 2;
                        break;
                    }

                case (byte)Enums.DirectionType.Down:
                    {
                        spriteleft = 0;
                        break;
                    }

                case (byte)Enums.DirectionType.Left:
                    {
                        spriteleft = 1;
                        break;
                    }
            }

            srcrec = new Rectangle((anim) * (CharacterGFXInfo[Sprite].width / (int)4), spriteleft * (CharacterGFXInfo[Sprite].height / (int)4), (CharacterGFXInfo[Sprite].width / (int)4), (CharacterGFXInfo[Sprite].height / (int)4));

            // Calculate the X
            X = E_Types.MapNpc[MapNpcNum].X * E_Globals.PIC_X + E_Types.MapNpc[MapNpcNum].XOffset - ((CharacterGFXInfo[Sprite].width / (int)4 - 32) / 2);

            // Is the player's height more than 32..?
            if ((CharacterGFXInfo[Sprite].height / (int)4) > 32)
                // Create a 32 pixel offset for larger sprites
                Y = E_Types.MapNpc[MapNpcNum].Y * E_Globals.PIC_Y + E_Types.MapNpc[MapNpcNum].YOffset - ((CharacterGFXInfo[Sprite].height / (int)4) - 32);
            else
                // Proceed as normal
                Y = E_Types.MapNpc[MapNpcNum].Y * E_Globals.PIC_Y + E_Types.MapNpc[MapNpcNum].YOffset;

            destrec = new Rectangle(X, Y, CharacterGFXInfo[Sprite].width / (int)4, CharacterGFXInfo[Sprite].height / (int)4);

            DrawCharacter(Sprite, X, Y, srcrec);
        }

        internal static void DrawResource(int Resource, int dx, int dy, Rectangle rec)
        {
            if (Resource < 1 || Resource > NumResources)
                return;
            int X;
            int Y;
            int width;
            int height;

            X = ConvertMapX(dx);
            Y = ConvertMapY(dy);
            width = (rec.Right - rec.Left);
            height = (rec.Bottom - rec.Top);

            if (rec.Width < 0 || rec.Height < 0)
                return;

            if (ResourcesGFXInfo[Resource].IsLoaded == false)
                LoadTexture(Resource, 5);

            // seeying we still use it, lets update timer
            {
                var withBlock = ResourcesGFXInfo[Resource];
                withBlock.TextureTimer = ClientDataBase.GetTickCount() + 100000;
            }

            RenderSprite(ResourcesSprite[Resource], GameWindow, X, Y, rec.X, rec.Y, rec.Width, rec.Height);
        }

        internal static void DrawMapResource(int Resource_num)
        {
            int Resource_master = 0;

            int Resource_state = 0;
            int Resource_sprite = 0;
            Rectangle rec = new Rectangle();
            int X;
            int Y;

            if (E_Globals.GettingMap)
                return;
            if (E_Globals.MapData == false)
                return;

            if (E_Globals.MapResource[Resource_num].X > E_Types.Map.MaxX || E_Globals.MapResource[Resource_num].Y > E_Types.Map.MaxY)
                return;
            // Get the Resource type
            Resource_master = E_Types.Map.Tile[E_Globals.MapResource[Resource_num].X, E_Globals.MapResource[Resource_num].Y].Data1;

            if (Resource_master == 0)
                return;

            if (Types.Resource[Resource_master].ResourceImage == 0)
                return;

            // Get the Resource state
            Resource_state = E_Globals.MapResource[Resource_num].ResourceState;

            if (Resource_state == 0)
                Resource_sprite = Types.Resource[Resource_master].ResourceImage;
            else if (Resource_state == 1)
                Resource_sprite = Types.Resource[Resource_master].ExhaustedImage;

            // src rect
            {
                var withBlock = rec;
                withBlock.Y = 0;
                withBlock.Height = ResourcesGFXInfo[Resource_sprite].height;
                withBlock.X = 0;
                withBlock.Width = ResourcesGFXInfo[Resource_sprite].width;
            }

            // Set base x + y, then the offset due to size
            X = (E_Globals.MapResource[Resource_num].X * E_Globals.PIC_X) - (ResourcesGFXInfo[Resource_sprite].width / (int)2) + 16;
            Y = (E_Globals.MapResource[Resource_num].Y * E_Globals.PIC_Y) - ResourcesGFXInfo[Resource_sprite].height + 32;

            DrawResource(Resource_sprite, X, Y, rec);
        }

        internal static void DrawItem(int itemnum)
        {
            Rectangle srcrec;
            Rectangle destrec;
            int PicNum;
            int x;
            int y;
            PicNum = Types.Item[E_Types.MapItem[itemnum].Num].Pic;

            if (PicNum < 1 || PicNum > NumItems)
                return;

            if (ItemsGFXInfo[PicNum].IsLoaded == false)
                LoadTexture(PicNum, 4);

            // seeying we still use it, lets update timer
            {
                var withBlock = ItemsGFXInfo[PicNum];
                withBlock.TextureTimer = ClientDataBase.GetTickCount() + 100000;
            }

            {
                var withBlock1 = E_Types.MapItem[itemnum];
                if (withBlock1.X < E_Globals.TileView.Left || withBlock1.X > E_Globals.TileView.Right)
                    return;
                if (withBlock1.Y < E_Globals.TileView.Top || withBlock1.Y > E_Globals.TileView.Bottom)
                    return;
            }

            if (ItemsGFXInfo[PicNum].width > 32)
            {
                srcrec = new Rectangle((E_Types.MapItem[itemnum].Frame * 32), 0, 32, 32);
                destrec = new Rectangle(ConvertMapX(E_Types.MapItem[itemnum].X * E_Globals.PIC_X), ConvertMapY(E_Types.MapItem[itemnum].Y * E_Globals.PIC_Y), 32, 32);
            }
            else
            {
                srcrec = new Rectangle(0, 0, E_Globals.PIC_X, E_Globals.PIC_Y);
                destrec = new Rectangle(ConvertMapX(E_Types.MapItem[itemnum].X * E_Globals.PIC_X), ConvertMapY(E_Types.MapItem[itemnum].Y * E_Globals.PIC_Y), E_Globals.PIC_X, E_Globals.PIC_Y);
            }

            x = ConvertMapX(E_Types.MapItem[itemnum].X * E_Globals.PIC_X);
            y = ConvertMapY(E_Types.MapItem[itemnum].Y * E_Globals.PIC_Y);

            RenderSprite(ItemsSprite[PicNum], GameWindow, x, y, srcrec.X, srcrec.Y, srcrec.Width, srcrec.Height);
        }

        internal static void DrawCharacter(int Sprite, int x2, int y2, Rectangle rec)
        {
            int X;
            int y;
            int width;
            int height;
            if (Sprite < 1 || Sprite > NumCharacters)
                return;

            if (CharacterGFXInfo[Sprite].IsLoaded == false)
                LoadTexture(Sprite, 2);

            // seeying we still use it, lets update timer
            {
                var withBlock = CharacterGFXInfo[Sprite];
                withBlock.TextureTimer = ClientDataBase.GetTickCount() + 100000;
            }

            X = ConvertMapX(x2);
            y = ConvertMapY(y2);
            width = (rec.Width);
            height = (rec.Height);

            RenderSprite(CharacterSprite[Sprite], GameWindow, X, y, rec.X, rec.Y, rec.Width, rec.Height);
        }

        internal static void DrawMapTile(int X, int Y)
        {
            Rectangle srcrect = new Rectangle(0, 0, 0, 0);

            if (E_Globals.GettingMap)
                return;
            if (E_Globals.MapData == false)
                return;

            {
                var withBlock = E_Types.Map.Tile[X, Y];
                for (int i = (int)Enums.LayerType.Ground; i <= (int)Enums.LayerType.Mask2; i++)
                {
                    // skip tile if tileset isn't set
                    if (withBlock.Layer[i].Tileset > 0 && withBlock.Layer[i].Tileset <= NumTileSets)
                    {
                        if (TileSetTextureInfo[withBlock.Layer[i].Tileset].IsLoaded == false)
                            LoadTexture(withBlock.Layer[i].Tileset, 1);
                        // we use it, lets update timer
                        {
                            var withBlock1 = TileSetTextureInfo[i];
                            withBlock1.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                        }
                        if (E_AutoTiles.Autotile[X, Y].Layer[i].renderState == E_AutoTiles.RENDER_STATE_NORMAL)
                        {
                            {
                                var withBlock2 = srcrect;
                                withBlock2.X = E_Types.Map.Tile[X, Y].Layer[i].X * 32;
                                withBlock2.Y = E_Types.Map.Tile[X, Y].Layer[i].Y * 32;
                                withBlock2.Width = 32;
                                withBlock2.Height = 32;
                            }

                            RenderSprite(TileSetSprite[withBlock.Layer[i].Tileset], GameWindow, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y), srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height);
                        }
                        else if (E_AutoTiles.Autotile[X, Y].Layer[i].renderState == E_AutoTiles.RENDER_STATE_AUTOTILE)
                        {
                            // Draw autotiles
                            E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y), 1, X, Y, 0, false);
                            E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X) + 16, ConvertMapY(Y * E_Globals.PIC_Y), 2, X, Y, 0, false);
                            E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y) + 16, 3, X, Y, 0, false);
                            E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X) + 16, ConvertMapY(Y * E_Globals.PIC_Y) + 16, 4, X, Y, 0, false);
                        }
                    }
                }
            }
        }

        internal static void DrawMapFringeTile(int X, int Y)
        {
            Rectangle srcrect = new Rectangle(0, 0, 0, 0);
            Rectangle dest = new Rectangle(My.MyProject.Forms.frmMapEditor.PointToScreen(My.MyProject.Forms.frmMapEditor.picScreen.Location), new Size(32, 32));
            // Dim tmpSprite As Sprite

            if (E_Globals.GettingMap)
                return;
            if (E_Globals.MapData == false)
                return;

            {
                var withBlock = E_Types.Map.Tile[X, Y];
                for (int i = (int)Enums.LayerType.Fringe; i <= (int)Enums.LayerType.Fringe2; i++)
                {
                    // skip tile if tileset isn't set
                    if (withBlock.Layer[i].Tileset > 0 && withBlock.Layer[i].Tileset <= NumTileSets)
                    {
                        if (TileSetTextureInfo[withBlock.Layer[i].Tileset].IsLoaded == false)
                            LoadTexture(withBlock.Layer[i].Tileset, 1);

                        // we use it, lets update timer
                        {
                            var withBlock1 = TileSetTextureInfo[withBlock.Layer[i].Tileset];
                            withBlock1.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                        }

                        // render
                        if (E_AutoTiles.Autotile[X, Y].Layer[i].renderState == E_AutoTiles.RENDER_STATE_NORMAL)
                        {
                            {
                                var withBlock2 = srcrect;
                                withBlock2.X = E_Types.Map.Tile[X, Y].Layer[i].X * 32;
                                withBlock2.Y = E_Types.Map.Tile[X, Y].Layer[i].Y * 32;
                                withBlock2.Width = 32;
                                withBlock2.Height = 32;
                            }

                            RenderSprite(TileSetSprite[withBlock.Layer[i].Tileset], GameWindow, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y), srcrect.X, srcrect.Y, srcrect.Width, srcrect.Height);
                        }
                        else if (E_AutoTiles.Autotile[X, Y].Layer[i].renderState == E_AutoTiles.RENDER_STATE_AUTOTILE)
                        {
                            // Draw autotiles
                            E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y), 1, X, Y, 0, false);
                            E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X) + 16, ConvertMapY(Y * E_Globals.PIC_Y), 2, X, Y, 0, false);
                            E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y) + 16, 3, X, Y, 0, false);
                            E_AutoTiles.DrawAutoTile(i, ConvertMapX(X * E_Globals.PIC_X) + 16, ConvertMapY(Y * E_Globals.PIC_Y) + 16, 4, X, Y, 0, false);
                        }
                    }
                }
            }
        }

        internal static bool IsValidMapPoint(int X, int Y)
        {

            if (X < 0)
                return false;
            if (Y < 0)
                return false;
            if (X > E_Types.Map.MaxX)
                return false;
            if (Y > E_Types.Map.MaxY)
                return false;
            return true;
        }

        internal static void UpdateCamera()
        {
            {
                var withBlock = E_Globals.TileView;
                withBlock.Top = E_Globals.EditorViewY;
                withBlock.Bottom = E_Types.Map.MaxY;
                withBlock.Left = E_Globals.EditorViewX;
                withBlock.Right = E_Types.Map.MaxX;
            }

            {
                var withBlock1 = E_Globals.Camera;
                withBlock1.Y = 0;
                withBlock1.Height = E_Types.Map.MaxY * 32;
                withBlock1.X = 0;
                withBlock1.Width = E_Types.Map.MaxX * 32;
            }

            UpdateDrawMapName();
        }

        public static void ClearGFX()
        {
            var loopTo = NumTileSets;

            // clear tilesets
            for (var I = 1; I <= loopTo; I++)
            {
                if (TileSetTextureInfo[I].IsLoaded)
                {
                    if (TileSetTextureInfo[I].TextureTimer < ClientDataBase.GetTickCount())
                    {
                        TileSetTexture[I].Dispose();
                        TileSetTextureInfo[I].IsLoaded = false;
                        TileSetTextureInfo[I].TextureTimer = 0;
                    }
                }
            }

            var loopTo1 = NumCharacters;

            // clear characters
            for (int I = 1; I <= loopTo1; I++)
            {
                if (CharacterGFXInfo[I].IsLoaded)
                {
                    if (CharacterGFXInfo[I].TextureTimer < ClientDataBase.GetTickCount())
                    {
                        CharacterGFX[I].Dispose();
                        CharacterGFXInfo[I].IsLoaded = false;
                        CharacterGFXInfo[I].TextureTimer = 0;
                    }
                }
            }

            var loopTo2 = NumPaperdolls;

            // clear paperdoll
            for (int I = 1; I <= loopTo2; I++)
            {
                if (PaperDollGFXInfo[I].IsLoaded)
                {
                    if (PaperDollGFXInfo[I].TextureTimer < ClientDataBase.GetTickCount())
                    {
                        PaperDollGFX[I].Dispose();
                        PaperDollGFXInfo[I].IsLoaded = false;
                        PaperDollGFXInfo[I].TextureTimer = 0;
                    }
                }
            }

            var loopTo3 = NumItems;

            // clear items
            for (int I = 1; I <= loopTo3; I++)
            {
                if (ItemsGFXInfo[I].IsLoaded)
                {
                    if (ItemsGFXInfo[I].TextureTimer < ClientDataBase.GetTickCount())
                    {
                        ItemsGFX[I].Dispose();
                        ItemsGFXInfo[I].IsLoaded = false;
                        ItemsGFXInfo[I].TextureTimer = 0;
                    }
                }
            }

            var loopTo4 = NumResources;

            // clear resources
            for (int I = 1; I <= loopTo4; I++)
            {
                if (ResourcesGFXInfo[I].IsLoaded)
                {
                    if (ResourcesGFXInfo[I].TextureTimer < ClientDataBase.GetTickCount())
                    {
                        ResourcesGFX[I].Dispose();
                        ResourcesGFXInfo[I].IsLoaded = false;
                        ResourcesGFXInfo[I].TextureTimer = 0;
                    }
                }
            }

            var loopTo5 = NumFaces;

            // clear faces
            for (int I = 1; I <= loopTo5; I++)
            {
                if (FacesGFXInfo[I].IsLoaded)
                {
                    if (FacesGFXInfo[I].TextureTimer < ClientDataBase.GetTickCount())
                    {
                        FacesGFX[I].Dispose();
                        FacesGFXInfo[I].IsLoaded = false;
                        FacesGFXInfo[I].TextureTimer = 0;
                    }
                }
            }
        }

        internal static void Render_Graphics()
        {
            int X;
            int Y;
            int I;

            // Don't Render IF
            if (E_Globals.GettingMap)
                return;

            // lets get going

            // update view around player
            UpdateCamera();

            // let program do other things
            Application.DoEvents();

            My.MyProject.Forms.frmMapEditor.picScreen.Width = (E_Types.Map.MaxX * E_Globals.PIC_X) + E_Globals.PIC_X;
            My.MyProject.Forms.frmMapEditor.picScreen.Height = (E_Types.Map.MaxY * E_Globals.PIC_Y) + E_Globals.PIC_Y;

            // Clear each of our render targets
            GameWindow.DispatchEvents();
            GameWindow.Clear(SFML.Graphics.Color.Black);

            GameWindow.SetView(new SFML.Graphics.View(new FloatRect(0, 0, My.MyProject.Forms.frmMapEditor.picScreen.Width, My.MyProject.Forms.frmMapEditor.picScreen.Height)));
            TilesetWindow.SetView(new SFML.Graphics.View(new FloatRect(0, 0, My.MyProject.Forms.frmMapEditor.picBackSelect.Width, My.MyProject.Forms.frmMapEditor.picBackSelect.Height)));

            // clear any unused gfx
            ClearGFX();

            // update animation editor
            // If Editor = EDITOR_ANIMATION Then
            // EditorAnim_DrawAnim()
            // End If

            if (E_Globals.InMapEditor && E_Globals.MapData == true)
            {
                // blit lower tiles
                if (NumTileSets > 0)
                {
                    var loopTo = E_Globals.TileView.Right + 1;
                    for (X = E_Globals.TileView.Left; X <= loopTo; X++)
                    {
                        var loopTo1 = E_Globals.TileView.Bottom + 1;
                        for (Y = E_Globals.TileView.Top; Y <= loopTo1; Y++)
                        {
                            if (IsValidMapPoint(X, Y))
                                DrawMapTile(X, Y);
                        }
                    }
                }

                // events
                if (E_Types.Map.CurrentEvents > 0 && E_Types.Map.CurrentEvents <= E_Types.Map.EventCount)
                {
                    var loopTo2 = E_Types.Map.CurrentEvents;
                    for (I = 1; I <= loopTo2; I++)
                    {
                        if (E_Types.Map.MapEvents[I].Position == 0)
                            E_EventSystem.DrawEvent(I);
                    }
                }

                // Draw out the items
                if (NumItems > 0)
                {
                    for (I = 1; I <= Constants.MAX_MAP_ITEMS; I++)
                    {
                        if (E_Types.MapItem[I].Num > 0)
                            DrawItem(I);
                    }
                }

                var loopTo3 = E_Globals.TileView.Right;

                // Draw sum d00rs.
                for (X = E_Globals.TileView.Left; X <= loopTo3; X++)
                {
                    var loopTo4 = E_Globals.TileView.Bottom;
                    for (Y = E_Globals.TileView.Top; Y <= loopTo4; Y++)
                    {
                        if (IsValidMapPoint(X, Y))
                        {
                            if (E_Types.Map.Tile[X, Y].Type == (byte)Enums.TileType.Door)
                                DrawDoor(X, Y);
                        }
                    }
                }

                var loopTo5 = E_Types.Map.MaxY;

                // Y-based render. Renders Players, Npcs and Resources based on Y-axis.
                for (Y = 0; Y <= loopTo5; Y++)
                {
                    if (NumCharacters > 0)
                    {

                        // Npcs
                        for (I = 1; I <= Constants.MAX_MAP_NPCS; I++)
                        {
                            if (E_Types.MapNpc[I].Y == Y)
                                DrawNpc(I);
                        }

                        // events
                        if (E_Types.Map.CurrentEvents > 0 && E_Types.Map.CurrentEvents <= E_Types.Map.EventCount)
                        {
                            var loopTo6 = E_Types.Map.CurrentEvents;
                            for (I = 1; I <= loopTo6; I++)
                            {
                                if (E_Types.Map.MapEvents[I].Position == 1)
                                {
                                    if (Y == E_Types.Map.MapEvents[I].Y)
                                        E_EventSystem.DrawEvent(I);
                                }
                            }
                        }
                    }

                    // Resources
                    if (NumResources > 0)
                    {
                        if (E_Globals.Resources_Init)
                        {
                            if (E_Globals.Resource_index > 0)
                            {
                                var loopTo7 = E_Globals.Resource_index;
                                for (I = 1; I <= loopTo7; I++)
                                {
                                    if (E_Globals.MapResource[I].Y == Y)
                                        DrawMapResource(I);
                                }
                            }
                        }
                    }
                }

                // events
                if (E_Types.Map.CurrentEvents > 0 && E_Types.Map.CurrentEvents <= E_Types.Map.EventCount)
                {
                    var loopTo8 = E_Types.Map.CurrentEvents;
                    for (I = 1; I <= loopTo8; I++)
                    {
                        if (E_Types.Map.MapEvents[I].Position == 2)
                            E_EventSystem.DrawEvent(I);
                    }
                }

                // blit out upper tiles
                if (NumTileSets > 0)
                {
                    var loopTo9 = E_Globals.TileView.Right + 1;
                    for (X = E_Globals.TileView.Left; X <= loopTo9; X++)
                    {
                        var loopTo10 = E_Globals.TileView.Bottom + 1;
                        for (Y = E_Globals.TileView.Top; Y <= loopTo10; Y++)
                        {
                            if (IsValidMapPoint(X, Y))
                                DrawMapFringeTile(X, Y);
                        }
                    }
                }

                E_Weather.DrawWeather();
                E_Weather.DrawThunderEffect();
                DrawMapTint();

                // Draw out a square at mouse cursor
                if (E_Globals.MapGrid == true)
                    DrawGrid();

                if (E_Globals.SelectedTab == 4)
                {
                    var loopTo11 = E_Globals.TileView.Right;
                    for (X = E_Globals.TileView.Left; X <= loopTo11; X++)
                    {
                        var loopTo12 = E_Globals.TileView.Bottom;
                        for (Y = E_Globals.TileView.Top; Y <= loopTo12; Y++)
                        {
                            if (IsValidMapPoint(X, Y))
                                DrawDirections(X, Y);
                        }
                    }
                }

                var loopTo13 = E_Types.Map.CurrentEvents;

                // draw event names
                for (I = 0; I <= loopTo13; I++)
                {
                    if (E_Types.Map.MapEvents[I].Visible == 1)
                    {
                        if (E_Types.Map.MapEvents[I].ShowName == 1)
                            E_Text.DrawEventName(I);
                    }
                }

                // draw npc names
                for (I = 1; I <= Constants.MAX_MAP_NPCS; I++)
                {
                    if (E_Types.MapNpc[I].Num > 0)
                        E_Text.DrawNPCName(I);
                }

                if (E_Globals.CurrentFog > 0)
                    E_Weather.DrawFog();

                // Blit out map attributes
                if (E_Globals.InMapEditor)
                {
                    E_Text.DrawMapAttributes();
                    DrawTileOutline();
                }

                if (E_Globals.InMapEditor && E_Globals.SelectedTab == 5)
                {
                    E_EventSystem.DrawEvents();
                    E_EventSystem.EditorEvent_DrawGraphic();
                }

                // Draw map name
                DrawMapName();
            }

            // and finally show everything on screen
            GameWindow.Display();
        }

        public static void DrawMapName()
        {
            E_Text.DrawText((byte)E_Globals.DrawMapNameX, (byte)E_Globals.DrawMapNameY, E_Types.Map.Name, E_Globals.DrawMapNameColor, SFML.Graphics.Color.Black, ref GameWindow);
        }

        internal static void DrawDoor(int X, int Y)
        {
            Rectangle rec = new Rectangle();
            int x2;
            int y2;

            // sort out animation
            {
                var withBlock = E_Types.TempTile[X, Y];
                if (withBlock.DoorAnimate == 1)
                {
                    if (withBlock.DoorTimer + 100 < ClientDataBase.GetTickCount())
                    {
                        if (withBlock.DoorFrame < 4)
                            withBlock.DoorFrame = (byte)(withBlock.DoorFrame + 1);
                        else
                            withBlock.DoorAnimate = 2;// set to closing
                        withBlock.DoorTimer = ClientDataBase.GetTickCount();
                    }
                }
                else if (withBlock.DoorAnimate == 2)
                {
                    if (withBlock.DoorTimer + 100 < ClientDataBase.GetTickCount())
                    {
                        if (withBlock.DoorFrame > 1)
                            withBlock.DoorFrame = (byte)(withBlock.DoorFrame - 1);
                        else
                            withBlock.DoorAnimate = 0;// end animation
                        withBlock.DoorTimer = ClientDataBase.GetTickCount();
                    }
                }

                if (withBlock.DoorFrame == 0)
                    withBlock.DoorFrame = 1;
            }

            {
                var withBlock1 = rec;
                withBlock1.Y = 0;
                withBlock1.Height = DoorGFXInfo.height;
                withBlock1.X = ((E_Types.TempTile[X, Y].DoorFrame - 1) * DoorGFXInfo.width / (int)4);
                withBlock1.Width = DoorGFXInfo.width / (int)4;
            }

            x2 = (X * E_Globals.PIC_X);
            y2 = (Y * E_Globals.PIC_Y) - (DoorGFXInfo.height / (int)2) + 4;

            RenderSprite(DoorSprite, GameWindow, ConvertMapX(X * E_Globals.PIC_X), ConvertMapY(Y * E_Globals.PIC_Y), rec.X, rec.Y, rec.Width, rec.Height);
        }

        internal static void DrawTileOutline()
        {
            Rectangle rec = new Rectangle();
            int tileset;
            if (E_Globals.SelectedTab == 4 || E_Globals.HideCursor == true)
                return;

            {
                var withBlock = rec;
                withBlock.Y = 0;
                withBlock.Height = E_Globals.PIC_Y;
                withBlock.X = 0;
                withBlock.Width = E_Globals.PIC_X;
            }

            tileset = My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex + 1;

            // exit out if doesn't exist
            if (tileset <= 0 || tileset > NumTileSets)
                return;

            RectangleShape rec2 = new RectangleShape()
            {
                OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.Blue),
                OutlineThickness = 0.6f,
                FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
            };

            if (E_Globals.SelectedTab == 2)
                // RenderTexture(MiscGFX, GameWindow, ConvertMapX(CurX * PIC_X), ConvertMapY(CurY * PIC_Y), rec.X, rec.Y, rec.Width, rec.Height)
                rec2.Size = new Vector2f(rec.Width, rec.Height);
            else
            {
                if (TileSetTextureInfo[My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex + 1].IsLoaded == false)
                    LoadTexture(My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex + 1, 1);
                // we use it, lets update timer
                {
                    var withBlock1 = TileSetTextureInfo[My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex + 1];
                    withBlock1.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }

                if (E_Globals.EditorTileWidth == 1 && E_Globals.EditorTileHeight == 1)
                {
                    RenderSprite(TileSetSprite[My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex + 1], GameWindow, ConvertMapX(E_Globals.CurX * E_Globals.PIC_X), ConvertMapY(E_Globals.CurY * E_Globals.PIC_Y), E_Globals.EditorTileSelStart.X * E_Globals.PIC_X, E_Globals.EditorTileSelStart.Y * E_Globals.PIC_Y, rec.Width, rec.Height);
                    rec2.Size = new Vector2f(rec.Width, rec.Height);
                }
                else if (My.MyProject.Forms.frmMapEditor.cmbAutoTile.SelectedIndex > 0)
                {
                    RenderSprite(TileSetSprite[My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex + 1], GameWindow, ConvertMapX(E_Globals.CurX * E_Globals.PIC_X), ConvertMapY(E_Globals.CurY * E_Globals.PIC_Y), E_Globals.EditorTileSelStart.X * E_Globals.PIC_X, E_Globals.EditorTileSelStart.Y * E_Globals.PIC_Y, rec.Width, rec.Height);
                    rec2.Size = new Vector2f(rec.Width, rec.Height);
                }
                else
                {
                    RenderSprite(TileSetSprite[My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex + 1], GameWindow, ConvertMapX(E_Globals.CurX * E_Globals.PIC_X), ConvertMapY(E_Globals.CurY * E_Globals.PIC_Y), E_Globals.EditorTileSelStart.X * E_Globals.PIC_X, E_Globals.EditorTileSelStart.Y * E_Globals.PIC_Y, E_Globals.EditorTileSelEnd.X * E_Globals.PIC_X, E_Globals.EditorTileSelEnd.Y * E_Globals.PIC_Y);
                    rec2.Size = new Vector2f(E_Globals.EditorTileSelEnd.X * E_Globals.PIC_X, E_Globals.EditorTileSelEnd.Y * E_Globals.PIC_Y);
                }
            }

            rec2.Position = new Vector2f(ConvertMapX(E_Globals.CurX * E_Globals.PIC_X), ConvertMapY(E_Globals.CurY * E_Globals.PIC_Y));
            GameWindow.Draw(rec2);
        }

        internal static void DrawGrid()
        {
            RectangleShape rec = new RectangleShape();
            var loopTo = E_Globals.TileView.Right // - 1
            ;
            for (var x = E_Globals.TileView.Left; x <= loopTo; x++)
            {
                var loopTo1 = E_Globals.TileView.Bottom // - 1
;
                for (var y = E_Globals.TileView.Top; y <= loopTo1; y++)
                {
                    if (IsValidMapPoint(x, y))
                    {
                        rec.OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.White);
                        rec.OutlineThickness = 0.6f;
                        rec.FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent);
                        rec.Size = new Vector2f((x * E_Globals.PIC_X), (y * E_Globals.PIC_X));
                        rec.Position = new Vector2f(ConvertMapX((x - 1) * E_Globals.PIC_X), ConvertMapY((y - 1) * E_Globals.PIC_Y));

                        GameWindow.Draw(rec);
                    }
                }
            }
        }

        internal static void DrawMapTint()
        {
            // If InMapEditor Then Exit Sub

            if (E_Types.Map.HasMapTint == 0)
                return;

            MapTintSprite = new Sprite(new Texture(new SFML.Graphics.Image((byte)(E_Types.Map.MaxX * E_Globals.PIC_X), (byte)(E_Types.Map.MaxY * E_Globals.PIC_Y),  SFML.Graphics.Color.White)))
            {
                Color = new SFML.Graphics.Color((byte)E_Globals.CurrentTintR, (byte)E_Globals.CurrentTintG, (byte)E_Globals.CurrentTintB, (byte)E_Globals.CurrentTintA),
                TextureRect = new IntRect(0, 0, (E_Types.Map.MaxX * E_Globals.PIC_X) + E_Globals.PIC_X, (E_Types.Map.MaxY * E_Globals.PIC_Y) + E_Globals.PIC_Y),
                Position = new Vector2f(0, 0)
            };

            GameWindow.Draw(MapTintSprite);
        }

        internal static void EditorMap_DrawTileset()
        {
            int height;
            int width;
            byte tileset;

            TilesetWindow.DispatchEvents();
            TilesetWindow.Clear(SFML.Graphics.Color.Black);

            // find tileset number
            tileset = (byte)(My.MyProject.Forms.frmMapEditor.cmbTileSets.SelectedIndex + 1);

            // exit out if doesn't exist
            if (tileset <= 0 || tileset > NumTileSets)
                return;

            RectangleShape rec2 = new RectangleShape()
            {
                OutlineColor = new SFML.Graphics.Color(SFML.Graphics.Color.Red),
                OutlineThickness = 0.6f,
                FillColor = new SFML.Graphics.Color(SFML.Graphics.Color.Transparent)
            };

            if (TileSetTextureInfo[tileset].IsLoaded == false)
                LoadTexture(tileset, 1);
            // we use it, lets update timer
            {
                var withBlock = TileSetTextureInfo[tileset];
                withBlock.TextureTimer = ClientDataBase.GetTickCount() + 100000;
            }

            height = TileSetTextureInfo[tileset].height;
            width = TileSetTextureInfo[tileset].width;
            My.MyProject.Forms.frmMapEditor.picBackSelect.Height = height;
            My.MyProject.Forms.frmMapEditor.picBackSelect.Width = width;

            TilesetWindow.SetView(new SFML.Graphics.View(new SFML.Graphics.FloatRect(0, 0, width, height)));

            // change selected shape for autotiles
            if (My.MyProject.Forms.frmMapEditor.cmbAutoTile.SelectedIndex > 0)
            {
                switch (My.MyProject.Forms.frmMapEditor.cmbAutoTile.SelectedIndex)
                {
                    case 1 // autotile
                   :
                        {
                            E_Globals.EditorTileWidth = 2;
                            E_Globals.EditorTileHeight = 3;
                            break;
                        }

                    case 2 // fake autotile
             :
                        {
                            E_Globals.EditorTileWidth = 1;
                            E_Globals.EditorTileHeight = 1;
                            break;
                        }

                    case 3 // animated
             :
                        {
                            E_Globals.EditorTileWidth = 6;
                            E_Globals.EditorTileHeight = 3;
                            break;
                        }

                    case 4 // cliff
             :
                        {
                            E_Globals.EditorTileWidth = 2;
                            E_Globals.EditorTileHeight = 2;
                            break;
                        }

                    case 5 // waterfall
             :
                        {
                            E_Globals.EditorTileWidth = 2;
                            E_Globals.EditorTileHeight = 3;
                            break;
                        }
                }
            }

            RenderSprite(TileSetSprite[tileset], TilesetWindow, 0, 0, 0, 0, width, height);

            rec2.Size = new Vector2f(E_Globals.EditorTileWidth * E_Globals.PIC_X, E_Globals.EditorTileHeight * E_Globals.PIC_Y);

            rec2.Position = new Vector2f(E_Globals.EditorTileSelStart.X * E_Globals.PIC_X, E_Globals.EditorTileSelStart.Y * E_Globals.PIC_Y);
            TilesetWindow.Draw(rec2);

            // and finally show everything on screen
            TilesetWindow.Display();

            E_Globals.LastTileset = tileset;
        }

        public static void DestroyGraphics()
        {

            // Number of graphic files
            if (!(MapEditorBackBuffer == null))
                MapEditorBackBuffer.Dispose();
            var loopTo = NumAnimations;
            for (var i = 0; i <= loopTo; i++)
            {
                if (!(AnimationsGFX[i] == null))
                    AnimationsGFX[i].Dispose();
            }

            var loopTo1 = NumCharacters;
            for (int i = 0; i <= loopTo1; i++)
            {
                if (!(CharacterGFX[i] == null))
                    CharacterGFX[i].Dispose();
            }

            var loopTo2 = NumItems;
            for (int i = 0; i <= loopTo2; i++)
            {
                if (!(ItemsGFX[i] == null))
                    ItemsGFX[i].Dispose();
            }

            var loopTo3 = NumPaperdolls;
            for (int i = 0; i <= loopTo3; i++)
            {
                if (!(PaperDollGFX[i] == null))
                    PaperDollGFX[i].Dispose();
            }

            var loopTo4 = NumResources;
            for (int i = 0; i <= loopTo4; i++)
            {
                if (!(ResourcesGFX[i] == null))
                    ResourcesGFX[i].Dispose();
            }

            var loopTo5 = NumSkillIcons;
            for (int i = 0; i <= loopTo5; i++)
            {
                if (!(SkillIconsGFX[i] == null))
                    SkillIconsGFX[i].Dispose();
            }

            var loopTo6 = NumTileSets;
            for (int i = 0; i <= loopTo6; i++)
            {
                // If Not TileSetImgsGFX(i) Is Nothing Then TileSetImgsGFX(i).Dispose()
                if (!(TileSetTexture[i] == null))
                    TileSetTexture[i].Dispose();
            }

            var loopTo7 = E_Housing.NumFurniture;
            for (int i = 0; i <= loopTo7; i++)
            {
                if (!(FurnitureGFX[i] == null))
                    FurnitureGFX[i].Dispose();
            }

            var loopTo8 = NumFaces;
            for (int i = 0; i <= loopTo8; i++)
            {
                if (!(FacesGFX[i] == null))
                    FacesGFX[i].Dispose();
            }

            var loopTo9 = NumFogs;
            for (int i = 0; i <= loopTo9; i++)
            {
                if (!(FogGFX[i] == null))
                    FogGFX[i].Dispose();
            }

            if (!(DoorGFX == null))
                DoorGFX.Dispose();
            if (!(DirectionsGfx == null))
                DirectionsGfx.Dispose();
            if (!(WeatherGFX == null))
                WeatherGFX.Dispose();
        }

        internal static void EditorMap_DrawMapItem()
        {
            int itemnum;
            itemnum = Types.Item[My.MyProject.Forms.frmMapEditor.scrlMapItem.Value].Pic;

            if (itemnum < 1 || itemnum > NumItems)
            {
                My.MyProject.Forms.frmMapEditor.picMapItem.BackgroundImage = null;
                return;
            }

            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"items\" + itemnum + E_Globals.GFX_EXT))
                My.MyProject.Forms.frmMapEditor.picMapItem.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"items\" + itemnum + E_Globals.GFX_EXT);
        }

        internal static void EditorMap_DrawKey()
        {
            int itemnum;

            itemnum = Types.Item[My.MyProject.Forms.frmMapEditor.scrlMapKey.Value].Pic;

            if (itemnum < 1 || itemnum > NumItems)
            {
                My.MyProject.Forms.frmMapEditor.picMapKey.BackgroundImage = null;
                return;
            }

            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"items\" + itemnum + E_Globals.GFX_EXT))
                My.MyProject.Forms.frmMapEditor.picMapKey.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"items\" + itemnum + E_Globals.GFX_EXT);
        }

        internal static void EditorNpc_DrawSprite()
        {
            int Sprite;

            Sprite = (int)My.MyProject.Forms.frmNPC.nudSprite.Value;

            if (Sprite < 1 || Sprite > NumCharacters)
            {
                My.MyProject.Forms.frmNPC.picSprite.BackgroundImage = null;
                return;
            }

            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"characters\" + Sprite + E_Globals.GFX_EXT))
            {
                My.MyProject.Forms.frmNPC.picSprite.Width = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"characters\" + Sprite + E_Globals.GFX_EXT).Width / (int)4;
                My.MyProject.Forms.frmNPC.picSprite.Height = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"characters\" + Sprite + E_Globals.GFX_EXT).Height / (int)4;
                My.MyProject.Forms.frmNPC.picSprite.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"characters\" + Sprite + E_Globals.GFX_EXT);
            }
        }

        internal static void EditorResource_DrawSprite()
        {
            int Sprite = 0;

            // normal sprite
            Sprite = (int)My.MyProject.Forms.FrmResource.nudNormalPic.Value;

            if (Sprite < 1 || Sprite > NumResources)
                My.MyProject.Forms.FrmResource.picNormalpic.BackgroundImage = null;
            else if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"resources\" + Sprite + E_Globals.GFX_EXT))
                My.MyProject.Forms.FrmResource.picNormalpic.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"resources\" + Sprite + E_Globals.GFX_EXT);

            // exhausted sprite
            Sprite = (int)My.MyProject.Forms.FrmResource.nudExhaustedPic.Value;

            if (Sprite < 1 || Sprite > NumResources)
                My.MyProject.Forms.FrmResource.picExhaustedPic.BackgroundImage = null;
            else if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"resources\" + Sprite + E_Globals.GFX_EXT))
                My.MyProject.Forms.FrmResource.picExhaustedPic.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"resources\" + Sprite + E_Globals.GFX_EXT);
        }

        internal static void EditorSkill_BltIcon()
        {
            int iconnum = 0;
            Rectangle sRECT = new Rectangle();
            Rectangle dRECT = new Rectangle();
            iconnum = (int)My.MyProject.Forms.frmSkill.nudIcon.Value;

            if (iconnum < 1 || iconnum > NumSkillIcons)
            {
                EditorSkill_Icon.Clear(ToSFMLColor(My.MyProject.Forms.frmSkill.picSprite.BackColor));
                EditorSkill_Icon.Display();
                return;
            }

            if (SkillIconsGFXInfo[iconnum].IsLoaded == false)
                LoadTexture(iconnum, 9);

            // seeying we still use it, lets update timer
            {
                var withBlock = SkillIconsGFXInfo[iconnum];
                withBlock.TextureTimer = ClientDataBase.GetTickCount() + 100000;
            }

            {
                var withBlock1 = sRECT;
                withBlock1.Y = 0;
                withBlock1.Height = E_Globals.PIC_Y;
                withBlock1.X = 0;
                withBlock1.Width = E_Globals.PIC_X;
            }

            // drect is the same, so just copy it
            dRECT = sRECT;

            EditorSkill_Icon.Clear(ToSFMLColor(My.MyProject.Forms.frmSkill.picSprite.BackColor));

            RenderSprite(SkillIconsSprite[iconnum], EditorSkill_Icon, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height);

            EditorSkill_Icon.Display();
        }

        internal static void EditorAnim_DrawAnim()
        {
            int Animationnum;
            Rectangle sRECT = new Rectangle(); ;
            Rectangle dRECT = new Rectangle();
            int width = 0;
            int height = 0;
            int looptime = 0;
            int FrameCount = 0;
            bool ShouldRender;

            Animationnum = (int)My.MyProject.Forms.FrmAnimation.nudSprite0.Value;

            if (Animationnum < 1 || Animationnum > NumAnimations)
            {
                EditorAnimation_Anim1.Clear(ToSFMLColor(My.MyProject.Forms.FrmAnimation.picSprite0.BackColor));
                EditorAnimation_Anim1.Display();
            }
            else
            {
                if (AnimationsGFXInfo[Animationnum].IsLoaded == false)
                    LoadTexture(Animationnum, 6);

                // seeying we still use it, lets update timer
                {
                    var withBlock = AnimationsGFXInfo[Animationnum];
                    withBlock.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }

                looptime = (int)My.MyProject.Forms.FrmAnimation.nudLoopTime0.Value;
                FrameCount = (int)My.MyProject.Forms.FrmAnimation.nudFrameCount0.Value;

                ShouldRender = false;

                // check if we need to render new frame
                if (E_Globals.AnimEditorTimer[0] + looptime <= ClientDataBase.GetTickCount())
                {
                    // check if out of range
                    if (E_Globals.AnimEditorFrame[0] >= FrameCount)
                        E_Globals.AnimEditorFrame[0] = 1;
                    else
                        E_Globals.AnimEditorFrame[0] = E_Globals.AnimEditorFrame[0] + 1;
                    E_Globals.AnimEditorTimer[0] = ClientDataBase.GetTickCount();
                    ShouldRender = true;
                }

                if (ShouldRender)
                {
                    if (My.MyProject.Forms.FrmAnimation.nudFrameCount0.Value > 0)
                    {
                        // total width divided by frame count
                        height = AnimationsGFXInfo[Animationnum].height;
                        width = AnimationsGFXInfo[Animationnum].width / (int)My.MyProject.Forms.FrmAnimation.nudFrameCount0.Value;

                        {
                            var withBlock1 = sRECT;
                            withBlock1.Y = 0;
                            withBlock1.Height = height;
                            withBlock1.X = (E_Globals.AnimEditorFrame[0] - 1) * width;
                            withBlock1.Width = width;
                        }

                        {
                            var withBlock2 = dRECT;
                            withBlock2.Y = 0;
                            withBlock2.Height = height;
                            withBlock2.X = 0;
                            withBlock2.Width = width;
                        }

                        EditorAnimation_Anim1.Clear(ToSFMLColor(My.MyProject.Forms.FrmAnimation.picSprite0.BackColor));

                        RenderSprite(AnimationsSprite[Animationnum], EditorAnimation_Anim1, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height);

                        EditorAnimation_Anim1.Display();
                    }
                }
            }

            Animationnum = (int)My.MyProject.Forms.FrmAnimation.nudSprite1.Value;

            if (Animationnum < 1 || Animationnum > NumAnimations)
            {
                EditorAnimation_Anim2.Clear(ToSFMLColor(My.MyProject.Forms.FrmAnimation.picSprite1.BackColor));
                EditorAnimation_Anim2.Display();
            }
            else
            {
                if (AnimationsGFXInfo[Animationnum].IsLoaded == false)
                    LoadTexture(Animationnum, 6);

                // seeying we still use it, lets update timer
                {
                    var withBlock3 = AnimationsGFXInfo[Animationnum];
                    withBlock3.TextureTimer = ClientDataBase.GetTickCount() + 100000;
                }

                looptime = (int)My.MyProject.Forms.FrmAnimation.nudLoopTime1.Value;
                FrameCount = (int)My.MyProject.Forms.FrmAnimation.nudFrameCount1.Value;

                ShouldRender = false;

                // check if we need to render new frame
                if (E_Globals.AnimEditorTimer[1] + looptime <= ClientDataBase.GetTickCount())
                {
                    // check if out of range
                    if (E_Globals.AnimEditorFrame[1] >= FrameCount)
                        E_Globals.AnimEditorFrame[1] = 1;
                    else
                        E_Globals.AnimEditorFrame[1] = E_Globals.AnimEditorFrame[1] + 1;
                    E_Globals.AnimEditorTimer[1] = ClientDataBase.GetTickCount();
                    ShouldRender = true;
                }

                if (ShouldRender)
                {
                    if (My.MyProject.Forms.FrmAnimation.nudFrameCount1.Value > 0)
                    {
                        // total width divided by frame count
                        height = AnimationsGFXInfo[Animationnum].height;
                        width = AnimationsGFXInfo[Animationnum].width / (int)My.MyProject.Forms.FrmAnimation.nudFrameCount1.Value;

                        {
                            var withBlock4 = sRECT;
                            withBlock4.Y = 0;
                            withBlock4.Height = height;
                            withBlock4.X = (E_Globals.AnimEditorFrame[1] - 1) * width;
                            withBlock4.Width = width;
                        }

                        {
                            var withBlock5 = dRECT;
                            withBlock5.Y = 0;
                            withBlock5.Height = height;
                            withBlock5.X = 0;
                            withBlock5.Width = width;
                        }

                        EditorAnimation_Anim2.Clear(ToSFMLColor(My.MyProject.Forms.FrmAnimation.picSprite1.BackColor));

                        RenderSprite(AnimationsSprite[Animationnum], EditorAnimation_Anim2, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height);
                        EditorAnimation_Anim2.Display();
                    }
                }
            }
        }

        internal static void UpdateDrawMapName()
        {
            Graphics g = Graphics.FromImage(new Bitmap(1, 1));
            int width;
            width = (int)g.MeasureString(Microsoft.VisualBasic.Strings.Trim(E_Types.Map.Name), new System.Drawing.Font(E_Globals.FONT_NAME, E_Globals.FONT_SIZE, FontStyle.Bold, GraphicsUnit.Pixel)).Width;
            E_Globals.DrawMapNameX = ((E_Globals.SCREEN_MAPX + 1) * E_Globals.PIC_X / (int)2) - width + 32;
            E_Globals.DrawMapNameY = 1;

            switch (E_Types.Map.Moral)
            {
                case (byte)Enums.MapMoralType.None:
                    {
                        E_Globals.DrawMapNameColor = SFML.Graphics.Color.Red;
                        break;
                    }

                case (byte)Enums.MapMoralType.Safe:
                    {
                        E_Globals.DrawMapNameColor = SFML.Graphics.Color.Green;
                        break;
                    }

                default:
                    {
                        E_Globals.DrawMapNameColor = SFML.Graphics.Color.White;
                        break;
                    }
            }
            g.Dispose();
        }

        internal static SFML.Graphics.Color ToSFMLColor(System.Drawing.Color ToConvert)
        {
            return new SFML.Graphics.Color(ToConvert.R, ToConvert.G, ToConvert.G, ToConvert.A);
        }
    }
}
