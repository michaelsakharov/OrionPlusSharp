
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.IO;
using System.Windows.Forms;
using ASFW;
using SFML.Graphics;
using SFML.Window;
using Engine;


namespace Engine
{
    internal sealed class C_Projectiles
    {

        #region Defines

        internal const int MaxProjectiles = 255;
        internal static ProjectileRec[] Projectiles = new ProjectileRec[MaxProjectiles + 1];
        internal static MapProjectileRec[] MapProjectiles = new MapProjectileRec[MaxProjectiles + 1];
        internal static int NumProjectiles;
        internal const byte EditorProjectile = 10;
        internal static bool[] ProjectileChanged = new bool[MaxProjectiles + 1];

        #endregion

        #region Types

        public struct ProjectileRec
        {
            public string Name;
            public int Sprite;
            public byte Range;
            public int Speed;
            public int Damage;
            public string OnInstantiate;
            public string OnUpdate;
            public string OnHitWall;
            public string OnHitEntity;
        }

        public struct MapProjectileRec
        {
            public int ProjectileNum;
            public int Owner;
            public byte OwnerType;
            public float X; // These are floats but converted to Ints last minute
            public float Y;
            public int RenderDir;
            public double Dir;
            public int Range;
            public int TravelTime;
            public int LastTravelTime;
            public int Timer;

            //Logic stuff
            public int Speed;
            public int logicPosition;
            public double delayTimer;

        }

        #endregion

        #region Sending

        public static void SendRequestProjectiles()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((System.Int32)Packets.ClientPackets.CRequestProjectiles);

            C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();

        }

        public static void SendClearProjectile(int projectileNum, int collisionindex, byte collisionType, int collisionZone)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((System.Int32)Packets.ClientPackets.CClearProjectile);
            buffer.WriteInt32(projectileNum);
            buffer.WriteInt32(collisionindex);
            buffer.WriteInt32(collisionType);
            buffer.WriteInt32(collisionZone);

            C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();

        }

        #endregion

        #region Recieving

        internal static void HandleUpdateProjectile(ref byte[] data)
        {
            int projectileNum = 0;
            ByteStream buffer = new ByteStream(data);
            projectileNum = buffer.ReadInt32();

            Projectiles[projectileNum].Name = buffer.ReadString();
            Projectiles[projectileNum].Sprite = buffer.ReadInt32();
            Projectiles[projectileNum].Range = (byte)(buffer.ReadInt32());
            Projectiles[projectileNum].Speed = buffer.ReadInt32();
            Projectiles[projectileNum].Damage = buffer.ReadInt32();
            //Logic
            Projectiles[projectileNum].OnInstantiate = buffer.ReadString();
            Projectiles[projectileNum].OnUpdate = buffer.ReadString();
            Projectiles[projectileNum].OnHitWall = buffer.ReadString();
            Projectiles[projectileNum].OnHitEntity = buffer.ReadString();

            buffer.Dispose();

        }

        internal static void HandleMapProjectile(ref byte[] data)
        {
            int i = 0;
            ByteStream buffer = new ByteStream(data);
            i = buffer.ReadInt32();

            ref var with_1 = ref MapProjectiles[i];
            with_1.ProjectileNum = buffer.ReadInt32();
            with_1.Owner = buffer.ReadInt32();
            with_1.OwnerType = (byte)(buffer.ReadInt32());
            switch (buffer.ReadInt32())
            {
                case 0: // Up
                    with_1.RenderDir = 0;
                    with_1.Dir = Math.Atan2(1.0, 0.0);
                    break;
                case 1: // down
                    with_1.RenderDir = 180;
                    with_1.Dir = Math.Atan2(-1.0, 0.0);
                    break;
                case 2: // Left
                    with_1.RenderDir = 270;
                    with_1.Dir = Math.Atan2(0.0, 1.0);
                    break;
                case 3: // Right
                    with_1.RenderDir = 90;
                    with_1.Dir = Math.Atan2(0.0, -1.0);
                    break;

                case 4: // Upleft
                    with_1.RenderDir = -45;
                    with_1.Dir = Math.Atan2(1.0, 1.0);
                    break;
                case 5: // Upright
                    with_1.RenderDir = 45;
                    with_1.Dir = Math.Atan2(1.0, -1.0);
                    break;
                case 6: // DownLeft
                    with_1.RenderDir = 225;
                    with_1.Dir = Math.Atan2(-1.0, 1.0);
                    break;
                case 7: // Downright
                    with_1.RenderDir = 135;
                    with_1.Dir = Math.Atan2(-1.0, -1.0);
                    break;
            }
            with_1.X = buffer.ReadInt32() * C_Constants.PicY;
            with_1.Y = buffer.ReadInt32() * C_Constants.PicX;
            with_1.Range = 0;
            with_1.Timer = C_General.GetTickCount() + 60000;
            //Logic
            with_1.Speed = Projectiles[with_1.ProjectileNum].Speed + 1;
            with_1.logicPosition = 0;


            buffer.Dispose();

        }

        #endregion

        #region Database

        public static void ClearProjectiles()
        {
            int i = 0;

            for (i = 1; i <= MaxProjectiles; i++)
            {
                ClearProjectile(i);
            }

        }

        public static void ClearMapProjectiles()
        {
            int i = 0;

            for (i = 1; i <= MaxProjectiles; i++)
            {
                ClearMapProjectile(i);
            }

        }

        public static void ClearProjectile(int index)
        {

            Projectiles[index].Name = "";
            Projectiles[index].Sprite = 0;
            Projectiles[index].Range = (byte)0;
            Projectiles[index].Speed = 1;
            Projectiles[index].Damage = 0;
            //Logic
            Projectiles[index].OnInstantiate = "";
            Projectiles[index].OnUpdate = "";
            Projectiles[index].OnHitWall = "";
            Projectiles[index].OnHitEntity = "";

        }

        public static void ClearMapProjectile(int projectileNum)
        {

            MapProjectiles[projectileNum].ProjectileNum = 0;
            MapProjectiles[projectileNum].Owner = 0;
            MapProjectiles[projectileNum].OwnerType = (byte)0;
            MapProjectiles[projectileNum].X = 0;
            MapProjectiles[projectileNum].Y = 0;
            MapProjectiles[projectileNum].Dir = (byte)0;
            MapProjectiles[projectileNum].Timer = 0;
            //Logic
            MapProjectiles[projectileNum].Speed = 0;
            MapProjectiles[projectileNum].logicPosition = 0;

        }

        #endregion

        #region Drawing

        internal static void CheckProjectiles()
        {
            int i = 0;

            i = 1;

            while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "projectiles\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
            {

                NumProjectiles++;
                i++;
            }

            if (NumProjectiles == 0)
            {
                return;
            }

        }

        internal static void DrawProjectile(int projectileNum)
        {
            bool canClearProjectile = false;
            int collisionindex = 0;
            byte collisionType = 0;
            int collisionZone = 0;
            int x = 0;
            int y = 0;
            int i = 0;
            int sprite = 0;

            float dirX = (float)Math.Cos((double)MapProjectiles[projectileNum].Dir);
            float dirY = (float)Math.Sin((double)MapProjectiles[projectileNum].Dir);

            MapProjectiles[projectileNum].Y += -dirY * (C_GameLogic.deltaTime * (MapProjectiles[projectileNum].Speed * 32));
            MapProjectiles[projectileNum].X += -dirX * (C_GameLogic.deltaTime * (MapProjectiles[projectileNum].Speed * 32));

            //MapProjectiles[projectileNum].Range = MapProjectiles[projectileNum].Range + 1;

            x = (int)MapProjectiles[projectileNum].X / C_Constants.PicY;
            y = (int)MapProjectiles[projectileNum].Y / C_Constants.PicX;

            //Check if its been going for over 1 minute, if so clear.
            if (MapProjectiles[projectileNum].Timer < C_General.GetTickCount())
            {
                canClearProjectile = true;
            }

            if (x > C_Maps.Map.MaxX || x < 0)
            {
                canClearProjectile = true;
            }
            if (y > C_Maps.Map.MaxY || y < 0)
            {
                canClearProjectile = true;
            }

            //Check for blocked wall collision
            if (canClearProjectile == false) //Add a check to prevent crashing
            {
                if (C_Maps.Map.Tile[x, y].Type == (byte)Enums.TileType.Blocked)
                {
                    canClearProjectile = true;
                }
            }

            //Check for npc collision
            for (i = 1; i <= Constants.MAX_MAP_NPCS; i++)
            {
                if (C_Maps.MapNpc[i].X == x && C_Maps.MapNpc[i].Y == y)
                {
                    canClearProjectile = true;
                    collisionindex = i;
                    collisionType = (byte)Enums.TargetType.Npc;
                    collisionZone = -1;
                    break;
                }
            }

            //Check for player collision
            for (i = 1; i <= Constants.MAX_PLAYERS; i++)
            {
                if (C_Player.IsPlaying(i) && C_Player.GetPlayerMap(i) == C_Player.GetPlayerMap(C_Variables.Myindex))
                {
                    if (C_Player.GetPlayerX(i) == x && C_Player.GetPlayerY(i) == y)
                    {
                        canClearProjectile = true;
                        collisionindex = i;
                        collisionType = (byte)Enums.TargetType.Player;
                        collisionZone = -1;
                        if (MapProjectiles[projectileNum].OwnerType == (byte)Enums.TargetType.Player)
                        {
                            if (MapProjectiles[projectileNum].Owner == i)
                            {
                                canClearProjectile = false; // Reset if its the owner of projectile
                            }
                        }
                        break;
                    }

                }
            }

            //Check if it has hit its maximum range
            if (MapProjectiles[projectileNum].Range >= Projectiles[MapProjectiles[projectileNum].ProjectileNum].Range + 1)
            {
                canClearProjectile = true;
            }

            //Clear the projectile if possible
            if (canClearProjectile == true)
            {
                //Only send the clear to the server if you're the projectile caster or the one hit (only if owner is not a player)
                if (MapProjectiles[projectileNum].OwnerType == (byte)Enums.TargetType.Player && MapProjectiles[projectileNum].Owner == C_Variables.Myindex)
                {
                    SendClearProjectile(projectileNum, collisionindex, collisionType, collisionZone);
                }

                ClearMapProjectile(projectileNum);
                return;
            }

            sprite = Projectiles[MapProjectiles[projectileNum].ProjectileNum].Sprite;
            if (sprite < 1 || sprite > NumProjectiles)
            {
                return;
            }

            ParseCode(Projectiles[MapProjectiles[projectileNum].ProjectileNum].OnUpdate.ToLower(), projectileNum);

            if (C_Graphics.ProjectileGfxInfo[sprite].IsLoaded == false)
            {
                C_Graphics.LoadTexture(sprite, (byte)11);
            }

            //see'ing we still use it, lets update timer
            C_Graphics.ProjectileGfxInfo[sprite].TextureTimer = C_General.GetTickCount() + 100000;

            x = C_Graphics.ConvertMapX((int)MapProjectiles[projectileNum].X);
            y = C_Graphics.ConvertMapY((int)MapProjectiles[projectileNum].Y);

            Sprite tmpSprite = new Sprite(C_Graphics.ProjectileGfx[sprite])
            {
                TextureRect = new IntRect(0, 0, 32, 32),
                Position = new Vector2f(x, y),
                Origin = new Vector2f(C_Constants.PicX / 2, C_Constants.PicY / 2),
                Rotation = (float)(MapProjectiles[projectileNum].Dir * (180 / Math.PI)) - 90,
            };

            C_Graphics.GameWindow.Draw(tmpSprite);

        }

        #endregion
        
        public static void ParseCode(string code, int projectileIndex)
        {
            // split the code into individual lines, and process them seperately
            string[] commands = code.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            // Are we Waiting? if so dont parse the commands, just subtract the timer
            if (MapProjectiles[projectileIndex].delayTimer <= 0)
            {
                // Now parse each command seperately
                for (; MapProjectiles[projectileIndex].logicPosition < commands.Length; MapProjectiles[projectileIndex].logicPosition++)
                {
                    if (!string.IsNullOrWhiteSpace(commands[MapProjectiles[projectileIndex].logicPosition]))
                    {
                        if (ParseUpdateCommand(commands[MapProjectiles[projectileIndex].logicPosition], projectileIndex)) // If returned true, Break this for loop since were gonna Delay the logic
                        {
                            break;
                        }
                    }
                }
                if(MapProjectiles[projectileIndex].logicPosition >= commands.Length)
                {
                    MapProjectiles[projectileIndex].logicPosition = 0;
                }
            }
            else
            {
                MapProjectiles[projectileIndex].delayTimer -= C_GameLogic.deltaTime;
            }
        }


        public static bool ParseUpdateCommand(string command, int projectileNum)
        {
            // todo, Add support for parsing Expressions like (1 + 1) or even (TargetHealth + 10)

            // Create a method which returns the Numbers from a string, this way we can check if the string is TargetHealth or something and return it or return a Number from int tryparse or something
            // For Expressions, if we do (1+1) without spaces then we can skip the whole Finding the expression part since it will already be there, then that will already get pushed into the Number Mehtod
            // So simply replace the ( and ) and find all the variable names and replace them with current values then Evaluate the expression using a c# Evaluator or a Math Evaluator whichever is faster

            //Lets get the individual parts of this command
            string[] lineandmod = command.Split(',');
            string line = lineandmod[0];
            string[] parts = line.Split(' ');

            if (parts[0] == "set")
            {
                //set a value
                if (parts[1] == "speed")
                {
                    int value = -1;
                    if (getIntNumber(parts[2], projectileNum, out value))
                    {
                        MapProjectiles[projectileNum].Speed = value;
                    }
                    else
                    {
                        MessageBox.Show($"{parts[2]} is an invalid whole number.", "Projectile Logic Error" + $" ID: {projectileNum}");
                    }
                }
                else if (parts[1] == "direction")
                {
                    double value = -1;
                    if (getDecimalNumber(parts[2], projectileNum, out value))
                    {
                        MapProjectiles[projectileNum].Dir = value;
                    }
                    else
                    {
                        MessageBox.Show($"{parts[2]} is an invalid decimal number.", "Projectile Logic Error" + $" ID: {projectileNum}");
                    }
                }
                else if (parts[1] == "x")
                {
                    int value = -1;
                    if (getIntNumber(parts[2], projectileNum, out value))
                    {
                        MapProjectiles[projectileNum].X = value;
                    }
                    else
                    {
                        MessageBox.Show($"{parts[2]} is an invalid whole number.", "Projectile Logic Error" + $" ID: {projectileNum}");
                    }
                }
                else if (parts[1] == "y")
                {
                    int value = -1;
                    if (getIntNumber(parts[2], projectileNum, out value))
                    {
                        MapProjectiles[projectileNum].Y = value;
                    }
                    else
                    {
                        MessageBox.Show($"{parts[2]} is an invalid whole number.", "Projectile Logic Error" + $" ID: {projectileNum}");
                    }
                }
                else
                {
                    MessageBox.Show($"{parts[1]} is an invalid option.", "Projectile Logic Error" + $" ID: {projectileNum}");
                }
            }
            else if (parts[0] == "add")
            {
                //set a value
                if (parts[1] == "speed")
                {
                    int value = -1;
                    if (getIntNumber(parts[2], projectileNum, out value))
                    {
                        MapProjectiles[projectileNum].Speed += value;
                    }
                    else
                    {
                        MessageBox.Show($"{parts[2]} is an invalid whole number.", "Projectile Logic Error" + $" ID: {projectileNum}");
                    }
                }
                else if (parts[1] == "direction")
                {
                    double value = -1;
                    if (getDecimalNumber(parts[2], projectileNum, out value))
                    {
                        MapProjectiles[projectileNum].Dir += value;
                    }
                    else
                    {
                        MessageBox.Show($"{parts[2]} is an invalid decimal number.", "Projectile Logic Error" + $" ID: {projectileNum}");
                    }
                }
                else if (parts[1] == "x")
                {

                    int value = -1;
                    if (getIntNumber(parts[2], projectileNum, out value))
                    {
                        MapProjectiles[projectileNum].X += value;
                    }
                    else
                    {
                        MessageBox.Show($"{parts[2]} is an invalid whole number.", "Projectile Logic Error" + $" ID: {projectileNum}");
                    }
                }
                else if (parts[1] == "y")
                {

                    int value = -1;
                    if (getIntNumber(parts[2], projectileNum, out value))
                    {
                        MapProjectiles[projectileNum].Y += value;
                    }
                    else
                    {
                        MessageBox.Show($"{parts[2]} is an invalid whole number.", "Projectile Logic Error" + $" ID: {projectileNum}");
                    }
                }
                else
                {
                    MessageBox.Show($"{parts[1]} is an invalid option.", "Projectile Logic Error" + $" ID: {projectileNum}");
                }
            }
            else if (parts[0] == "subtract")
            {
                //set a value
                if (parts[1] == "speed")
                {
                    int value = -1;
                    if (getIntNumber(parts[2], projectileNum, out value))
                    {
                        MapProjectiles[projectileNum].Speed -= value;
                    }
                    else
                    {
                        MessageBox.Show($"{parts[2]} is an invalid whole number.", "Projectile Logic Error" + $" ID: {projectileNum}");
                    }
                }
                else if (parts[1] == "direction")
                {
                    double value = -1;
                    if (getDecimalNumber(parts[2], projectileNum, out value))
                    {
                        MapProjectiles[projectileNum].Dir -= value;
                    }
                    else
                    {
                        MessageBox.Show($"{parts[2]} is an invalid decimal number.", "Projectile Logic Error" + $" ID: {projectileNum}");
                    }
                }
                else if (parts[1] == "x")
                {
                    int value = -1;
                    if (getIntNumber(parts[2], projectileNum, out value))
                    {
                        MapProjectiles[projectileNum].X -= value;
                    }
                    else
                    {
                        MessageBox.Show($"{parts[2]} is an invalid whole number.", "Projectile Logic Error" + $" ID: {projectileNum}");
                    }
                }
                else if (parts[1] == "y")
                {
                    int value = -1;
                    if (getIntNumber(parts[2], projectileNum, out value))
                    {
                        MapProjectiles[projectileNum].Y -= value;
                    }
                    else
                    {
                        MessageBox.Show($"{parts[2]} is an invalid whole number.", "Projectile Logic Error" + $" ID: {projectileNum}");
                    }
                }
                else
                {
                    MessageBox.Show($"{parts[1]} is an invalid option.", "Projectile Logic Error" + $" ID: {projectileNum}");
                }
            }
            else if (parts[0] == "make")
            {
                MessageBox.Show($"Cannot create new projectile instances inside On Update.", "Projectile Logic Error" + $" ID: {projectileNum}");
            }
            else if (parts[0] == "destroyself")
            {
                MessageBox.Show($"DestroySelf not Implemented", "Projectile Logic Error" + $" ID: {projectileNum}");
            }
            else if (parts[0] == "delay")
            {
                double value = -1;
                if (getDecimalNumber(parts[1], projectileNum, out value))
                {
                    MapProjectiles[projectileNum].delayTimer = value;
                    MapProjectiles[projectileNum].logicPosition += 1; // Make sure that next time were calculating the NEXT line and not this one agian, otherwise we will fall into an infinite loop
                    return true;
                }
                else
                {
                    MessageBox.Show($"{parts[2]} is an invalid decimal number.", "Projectile Logic Error" + $" ID: {projectileNum}");
                }
            }
            else
            {
                MessageBox.Show($"{parts[0]} is an invalid function.", "Projectile Logic Error" + $" ID: {projectileNum}");
            }
            return false;
        }

        public static bool getIntNumber(string part, int projectileNum, out int value)
        {
            // First see if this is one of the variables
            if(part == "speed") { value = MapProjectiles[projectileNum].Speed; return true; }
            if(part == "direction") { value = (int)MapProjectiles[projectileNum].Dir; return true; }
            if(part == "x") { value = (int)MapProjectiles[projectileNum].X; return true; }
            if(part == "y") { value = (int)MapProjectiles[projectileNum].Y; return true; }
            if(part == "damage") { value = Projectiles[MapProjectiles[projectileNum].ProjectileNum].Damage; return true; }
            if(part == "totaldamage") { MessageBox.Show($"Total damage has not been calculated yet in OnUpdate, use it in OnHitEntity instead!", "Projectile Logic Error" + $" ID: {projectileNum}"); value = 0; return false; }

            if(part.Contains("(")) // Evaluation Expression
            {
                part.Replace("(", "");
                part.Replace(")", "");
                // Part should now Just be an expression, so first things first we need to convert every part of the expression into a number
                MessageBox.Show($"({part}) Expressions are not supported yet!", "Projectile Logic Error" + $" ID: {projectileNum}");
            } 

            // Return a number
            if (int.TryParse(part, out value))
            {
                return true;
            }
            return false;
        }

        public static bool getDecimalNumber(string part, int projectileNum, out double value)
        {
            // First see if this is one of the variables
            if (part == "speed") { value = MapProjectiles[projectileNum].Speed; return true; }
            if (part == "direction") { value = MapProjectiles[projectileNum].Dir; return true; }
            if (part == "x") { value = MapProjectiles[projectileNum].X; return true; }
            if (part == "y") { value = MapProjectiles[projectileNum].Y; return true; }
            if (part == "damage") { value = Projectiles[MapProjectiles[projectileNum].ProjectileNum].Damage; return true; }

            if (part.Contains("(")) // Evaluation Expression
            {
                part.Replace("(", "");
                part.Replace(")", "");
                // Part should now Just be an expression, so first things first we need to convert every part of the expression into a number
                MessageBox.Show($"({part}) Expressions are not supported yet!", "Projectile Logic Error" + $" ID: {projectileNum}");
            }

            // Return a number
            if (Double.TryParse(part, out value))
            {
                return true;
            }
            return false;
        }

    }
}
