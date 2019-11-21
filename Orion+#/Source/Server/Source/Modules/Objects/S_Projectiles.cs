using System.Windows.Forms;
using System;
using System.IO;
using ASFW;
using ASFW.IO.FileIO;

namespace Engine
{
    internal static class S_Projectiles
    {
        internal const int MAX_PROJECTILES = 255;
        internal static ProjectileRec[] Projectiles = new ProjectileRec[256];
        internal static MapProjectileRec[,] MapProjectiles;



        internal struct ProjectileRec
        {
            public string Name;
            public int Sprite;
            public byte Range;
            public int Speed;
            public int Damage;
        }

        internal struct MapProjectileRec
        {
            public int ProjectileNum;
            public int Owner;
            public byte OwnerType;
            public int X;
            public int Y;
            public byte Dir;
            public int Timer;
        }



        public static void SaveProjectiles()
        {
            int i;

            for (i = 1; i <= MAX_PROJECTILES; i++)
                SaveProjectile(i);
        }

        public static void SaveProjectile(int ProjectileNum)
        {
            string filename;

            filename = Path.Combine(Application.StartupPath, "data", "projectiles", string.Format("projectile{0}.dat", ProjectileNum));

            ByteStream writer = new ByteStream(100);

            writer.WriteString(Projectiles[ProjectileNum].Name);
            writer.WriteInt32(Projectiles[ProjectileNum].Sprite);
            writer.WriteByte(Projectiles[ProjectileNum].Range);
            writer.WriteInt32(Projectiles[ProjectileNum].Speed);
            writer.WriteInt32(Projectiles[ProjectileNum].Damage);

            BinaryFile.Save(filename, ref writer);
        }

        public static void LoadProjectiles()
        {
            string filename;
            int i;

            CheckProjectile();

            for (i = 1; i <= MAX_PROJECTILES; i++)
            {
                filename = Path.Combine(Application.StartupPath, "data", "projectiles", string.Format("projectile{0}.dat", i));
                ByteStream reader = new ByteStream();
                BinaryFile.Load(filename, ref reader);

                Projectiles[i].Name = reader.ReadString();
                Projectiles[i].Sprite = reader.ReadInt32();
                Projectiles[i].Range = reader.ReadByte();
                Projectiles[i].Speed = reader.ReadInt32();
                Projectiles[i].Damage = reader.ReadInt32();

                //Application.DoEvents();
            }
        }

        public static void CheckProjectile()
        {
            int i;

            for (i = 1; i <= MAX_PROJECTILES; i++)
            {
                if (!File.Exists(Path.Combine(Application.StartupPath, "data", "projectiles", string.Format("projectile{0}.dat", i))))
                    SaveProjectile(i);
            }
        }

        public static void ClearMapProjectiles()
        {
            int x;
            int y;

            MapProjectiles = new MapProjectileRec[Constants.MAX_MAPS + S_Instances.MAX_INSTANCED_MAPS + 1, 256];
            for (x = 1; x <= Constants.MAX_MAPS + S_Instances.MAX_INSTANCED_MAPS; x++)
            {
                for (y = 1; y <= MAX_PROJECTILES; y++)
                    ClearMapProjectile(x, y);
            }
        }

        public static void ClearMapProjectile(int mapNum, int index)
        {
            MapProjectiles[mapNum, index].ProjectileNum = 0;
            MapProjectiles[mapNum, index].Owner = 0;
            MapProjectiles[mapNum, index].OwnerType = 0;
            MapProjectiles[mapNum, index].X = 0;
            MapProjectiles[mapNum, index].Y = 0;
            MapProjectiles[mapNum, index].Dir = 0;
            MapProjectiles[mapNum, index].Timer = 0;
        }

        public static void ClearProjectile(int index)
        {
            Projectiles[index].Name = "";
            Projectiles[index].Sprite = 0;
            Projectiles[index].Range = 1;
            Projectiles[index].Speed = 1;
            Projectiles[index].Damage = 0;
        }

        public static void ClearProjectiles()
        {
            int i;

            Projectiles = new ProjectileRec[256];

            for (i = 1; i <= MAX_PROJECTILES; i++)
                ClearProjectile(i);
        }



        public static void HandleRequestEditProjectiles(int index, ref byte[] data)
        {
            ByteStream buffer = new ByteStream(4);

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Developer)
                return;

            buffer.WriteInt32((byte)Packets.ServerPackets.SProjectileEditor);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void HandleSaveProjectile(int index, ref byte[] data)
        {
            int ProjectileNum;
            ByteStream buffer = new ByteStream(data);
            if (S_Players.GetPlayerAccess(index) < (byte)Enums.AdminType.Developer)
                return;

            ProjectileNum = buffer.ReadInt32();

            // Prevent hacking
            if (ProjectileNum < 0 || ProjectileNum > MAX_PROJECTILES)
                return;

            Projectiles[ProjectileNum].Name = buffer.ReadString();
            Projectiles[ProjectileNum].Sprite = buffer.ReadInt32();
            Projectiles[ProjectileNum].Range = (byte)buffer.ReadInt32();
            Projectiles[ProjectileNum].Speed = buffer.ReadInt32();
            Projectiles[ProjectileNum].Damage = buffer.ReadInt32();

            // Save it
            SendUpdateProjectileToAll(ProjectileNum);
            SaveProjectile(ProjectileNum);
            modDatabase.Addlog(S_Players.GetPlayerLogin(index) + " saved Projectile #" + ProjectileNum + ".", S_Constants.ADMIN_LOG);
            buffer.Dispose();
        }

        public static void HandleRequestProjectiles(int index, ref byte[] data)
        {
            SendProjectiles(index);
        }

        public static void HandleClearProjectile(int index, ref byte[] data)
        {
            int ProjectileNum;
            int Targetindex;
            Enums.TargetType TargetType;
            int TargetZone;
            int mapNum;
            int Damage;
            int armor;
            int npcnum;
            ByteStream buffer = new ByteStream(data);
            ProjectileNum = buffer.ReadInt32();
            Targetindex = buffer.ReadInt32();
            TargetType = (Enums.TargetType)buffer.ReadInt32();
            TargetZone = buffer.ReadInt32();
            buffer.Dispose();

            mapNum = S_Players.GetPlayerMap(index);

            switch (MapProjectiles[mapNum, ProjectileNum].OwnerType)
            {
                case (byte)Enums.TargetType.Player:
                    {
                        if (MapProjectiles[mapNum, ProjectileNum].Owner == index)
                        {
                            switch (TargetType)
                            {
                                case Enums.TargetType.Player:
                                    {
                                        if (S_NetworkConfig.IsPlaying(Targetindex))
                                        {
                                            if (Targetindex != index)
                                            {
                                                if (S_Players.CanPlayerAttackPlayer(index, Targetindex, true) == true)
                                                {

                                                    // Get the damage we can do
                                                    Damage = S_Players.GetPlayerDamage(index) + Projectiles[MapProjectiles[mapNum, ProjectileNum].ProjectileNum].Damage;

                                                    // if the player blocks, take away the block amount
                                                    armor = Convert.ToInt32(S_Players.CanPlayerBlockHit(Targetindex));
                                                    Damage = Damage - armor;

                                                    // randomise for up to 10% lower than max hit
                                                    Damage = S_GameLogic.Random(1, Damage);

                                                    if (Damage < 1)
                                                        Damage = 1;

                                                    S_Players.AttackPlayer(index, Targetindex, Damage);
                                                }
                                            }
                                        }

                                        break;
                                    }

                                case Enums.TargetType.Npc:
                                    {
                                        npcnum = modTypes.MapNpc[mapNum].Npc[Targetindex].Num;
                                        if (S_Players.CanPlayerAttackNpc(index, Targetindex, true) == true)
                                        {
                                            // Get the damage we can do
                                            Damage = S_Players.GetPlayerDamage(index) + Projectiles[MapProjectiles[mapNum, ProjectileNum].ProjectileNum].Damage;

                                            // if the npc blocks, take away the block amount
                                            armor = 0;
                                            Damage = Damage - armor;

                                            // randomise from 1 to max hit
                                            Damage = S_GameLogic.Random(1, Damage);

                                            if (Damage < 1)
                                                Damage = 1;

                                            S_Players.PlayerAttackNpc(index, Targetindex, Damage);
                                        }

                                        break;
                                    }
                            }
                        }

                        break;
                    }
            }

            ClearMapProjectile(mapNum, ProjectileNum);
        }



        public static void SendUpdateProjectileToAll(int ProjectileNum)
        {
            ByteStream buffer;

            buffer = new ByteStream(4);

            buffer.WriteInt32((byte)Packets.ServerPackets.SUpdateProjectile);
            buffer.WriteInt32(ProjectileNum);
            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Projectiles[ProjectileNum].Name)));
            buffer.WriteInt32(Projectiles[ProjectileNum].Sprite);
            buffer.WriteInt32(Projectiles[ProjectileNum].Range);
            buffer.WriteInt32(Projectiles[ProjectileNum].Speed);
            buffer.WriteInt32(Projectiles[ProjectileNum].Damage);

            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendUpdateProjectileTo(int index, int ProjectileNum)
        {
            ByteStream buffer;

            buffer = new ByteStream(4);

            buffer.WriteInt32((byte)Packets.ServerPackets.SUpdateProjectile);
            buffer.WriteInt32(ProjectileNum);
            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Projectiles[ProjectileNum].Name)));
            buffer.WriteInt32(Projectiles[ProjectileNum].Sprite);
            buffer.WriteInt32(Projectiles[ProjectileNum].Range);
            buffer.WriteInt32(Projectiles[ProjectileNum].Speed);
            buffer.WriteInt32(Projectiles[ProjectileNum].Damage);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendProjectiles(int index)
        {
            int i;

            for (i = 1; i <= MAX_PROJECTILES; i++)
            {
                if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Projectiles[i].Name)) > 0)
                    SendUpdateProjectileTo(index, i);
            }
        }

        public static void SendProjectileToMap(int mapNum, int ProjectileNum)
        {
            ByteStream buffer;

            buffer = new ByteStream(4);
            buffer.WriteInt32((byte)Packets.ServerPackets.SMapProjectile);

            {
                buffer.WriteInt32(ProjectileNum);
                buffer.WriteInt32(MapProjectiles[mapNum, ProjectileNum].ProjectileNum);
                buffer.WriteInt32(MapProjectiles[mapNum, ProjectileNum].Owner);
                buffer.WriteInt32(MapProjectiles[mapNum, ProjectileNum].OwnerType);
                buffer.WriteInt32(MapProjectiles[mapNum, ProjectileNum].Dir);
                buffer.WriteInt32(MapProjectiles[mapNum, ProjectileNum].X);
                buffer.WriteInt32(MapProjectiles[mapNum, ProjectileNum].Y);
            }

            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }



        internal static void PlayerFireProjectile(int index, int IsSkill = 0)
        {
            int ProjectileSlot = 0;
            int ProjectileNum = 0;
            int mapNum = 0;
            int i = 0;

            mapNum = S_Players.GetPlayerMap(index);

            // Find a free projectile
            for (i = 1; i <= MAX_PROJECTILES; i++)
            {
                if (MapProjectiles[mapNum, i].ProjectileNum == 0)
                {
                    ProjectileSlot = i;
                    break;
                }
            }

            // Check for no projectile, if so just overwrite the first slot
            if (ProjectileSlot == 0)
                ProjectileSlot = 1;

            // Check for skill, if so then load data acordingly
            if (IsSkill > 0)
                ProjectileNum = Types.Skill[IsSkill].Projectile;
            else
                ProjectileNum = Types.Item[S_Players.GetPlayerEquipment(index, Enums.EquipmentType.Weapon)].Projectile;

            if (ProjectileNum == 0)
                return;

            {
                MapProjectiles[mapNum, ProjectileSlot].ProjectileNum = ProjectileNum;
                MapProjectiles[mapNum, ProjectileSlot].Owner = index;
                MapProjectiles[mapNum, ProjectileSlot].OwnerType = (byte)Enums.TargetType.Player;
                MapProjectiles[mapNum, ProjectileSlot].Dir = (byte)S_Players.GetPlayerDir(index);
                MapProjectiles[mapNum, ProjectileSlot].X = S_Players.GetPlayerX(index);
                MapProjectiles[mapNum, ProjectileSlot].Y = S_Players.GetPlayerY(index);
                MapProjectiles[mapNum, ProjectileSlot].Timer = S_General.GetTimeMs() + 60000;
            }

            SendProjectileToMap(mapNum, ProjectileSlot);
        }
    }
}
