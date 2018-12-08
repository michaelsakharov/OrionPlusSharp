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
using static Engine.Types;

namespace Engine
{
    internal static class S_Items
    {
        public static void SaveItems()
        {
            int i;

            for (i = 1; i <= Constants.MAX_ITEMS; i++)
                SaveItem(i);
        }

        public static void SaveItem(int itemNum)
        {
            string filename;
            filename = Path.Combine(Application.StartupPath, "data", "items", string.Format("item{0}.dat", itemNum));

            ByteStream writer = new ByteStream(100);
            writer.WriteString(Types.Item[itemNum].Name);
            writer.WriteInt32(Types.Item[itemNum].Pic);
            writer.WriteString(Types.Item[itemNum].Description);

            writer.WriteByte(Types.Item[itemNum].Type);
            writer.WriteByte(Types.Item[itemNum].SubType);
            writer.WriteInt32(Types.Item[itemNum].Data1);
            writer.WriteInt32(Types.Item[itemNum].Data2);
            writer.WriteInt32(Types.Item[itemNum].Data3);
            writer.WriteInt32(Types.Item[itemNum].ClassReq);
            writer.WriteInt32(Types.Item[itemNum].AccessReq);
            writer.WriteInt32(Types.Item[itemNum].LevelReq);
            writer.WriteByte(Types.Item[itemNum].Mastery);
            writer.WriteInt32(Types.Item[itemNum].Price);

            for (var i = 0; i <= (int)Enums.StatType.Count - 1; i++)
                writer.WriteByte(Types.Item[itemNum].Add_Stat[i]);

            writer.WriteByte(Types.Item[itemNum].Rarity);
            writer.WriteInt32(Types.Item[itemNum].Speed);
            writer.WriteInt32(Types.Item[itemNum].TwoHanded);
            writer.WriteByte(Types.Item[itemNum].BindType);

            for (var i = 0; i <= (int)Enums.StatType.Count - 1; i++)
                writer.WriteByte(Types.Item[itemNum].Stat_Req[i]);

            writer.WriteInt32(Types.Item[itemNum].Animation);
            writer.WriteInt32(Types.Item[itemNum].Paperdoll);

            // Housing
            writer.WriteInt32(Types.Item[itemNum].FurnitureWidth);
            writer.WriteInt32(Types.Item[itemNum].FurnitureHeight);

            for (var a = 0; a <= 3; a++)
            {
                for (var b = 0; b <= 3; b++)
                {
                    writer.WriteInt32(Types.Item[itemNum].FurnitureBlocks[a, b]);
                    writer.WriteInt32(Types.Item[itemNum].FurnitureFringe[a, b]);
                }
            }

            writer.WriteByte(Types.Item[itemNum].KnockBack);
            writer.WriteByte(Types.Item[itemNum].KnockBackTiles);

            writer.WriteByte(Types.Item[itemNum].Randomize);
            writer.WriteByte(Types.Item[itemNum].RandomMin);
            writer.WriteByte(Types.Item[itemNum].RandomMax);

            writer.WriteByte(Types.Item[itemNum].Stackable);

            writer.WriteByte(Types.Item[itemNum].ItemLevel);

            writer.WriteInt32(Types.Item[itemNum].Projectile);
            writer.WriteInt32(Types.Item[itemNum].Ammo);

            BinaryFile.Save(filename, ref writer);
        }

        public static void LoadItems()
        {
            int i;

            CheckItems();

            for (i = 1; i <= Constants.MAX_ITEMS; i++)
                LoadItem(i);
        }

        public static void LoadItem(int ItemNum)
        {
            string filename;
            int s;

            filename = Path.Combine(Application.StartupPath, "data", "items", string.Format("item{0}.dat", ItemNum));

            ByteStream reader = new ByteStream();
            BinaryFile.Load(filename, ref reader);

            Types.Item[ItemNum].Name = reader.ReadString();
            Types.Item[ItemNum].Pic = reader.ReadInt32();
            Types.Item[ItemNum].Description = reader.ReadString();

            Types.Item[ItemNum].Type = reader.ReadByte();
            Types.Item[ItemNum].SubType = reader.ReadByte();
            Types.Item[ItemNum].Data1 = reader.ReadInt32();
            Types.Item[ItemNum].Data2 = reader.ReadInt32();
            Types.Item[ItemNum].Data3 = reader.ReadInt32();
            Types.Item[ItemNum].ClassReq = reader.ReadInt32();
            Types.Item[ItemNum].AccessReq = reader.ReadInt32();
            Types.Item[ItemNum].LevelReq = reader.ReadInt32();
            Types.Item[ItemNum].Mastery = reader.ReadByte();
            Types.Item[ItemNum].Price = reader.ReadInt32();

            for (s = 0; s <= (int)Enums.StatType.Count - 1; s++)
                Types.Item[ItemNum].Add_Stat[s] = reader.ReadByte();

            Types.Item[ItemNum].Rarity = reader.ReadByte();
            Types.Item[ItemNum].Speed = reader.ReadInt32();
            Types.Item[ItemNum].TwoHanded = reader.ReadInt32();
            Types.Item[ItemNum].BindType = reader.ReadByte();

            for (s = 0; s <= (int)Enums.StatType.Count - 1; s++)
                Types.Item[ItemNum].Stat_Req[s] = reader.ReadByte();

            Types.Item[ItemNum].Animation = reader.ReadInt32();
            Types.Item[ItemNum].Paperdoll = reader.ReadInt32();

            // Housing
            Types.Item[ItemNum].FurnitureWidth = reader.ReadInt32();
            Types.Item[ItemNum].FurnitureHeight = reader.ReadInt32();

            for (var a = 0; a <= 3; a++)
            {
                for (var b = 0; b <= 3; b++)
                {
                    Types.Item[ItemNum].FurnitureBlocks[a, b] = reader.ReadInt32();
                    Types.Item[ItemNum].FurnitureFringe[a, b] = reader.ReadInt32();
                }
            }

            Types.Item[ItemNum].KnockBack = reader.ReadByte();
            Types.Item[ItemNum].KnockBackTiles = reader.ReadByte();

            Types.Item[ItemNum].Randomize = reader.ReadByte();
            Types.Item[ItemNum].RandomMin = reader.ReadByte();
            Types.Item[ItemNum].RandomMax = reader.ReadByte();

            Types.Item[ItemNum].Stackable = reader.ReadByte();

            Types.Item[ItemNum].ItemLevel = reader.ReadByte();

            Types.Item[ItemNum].Projectile = reader.ReadInt32();
            Types.Item[ItemNum].Ammo = reader.ReadInt32();
        }

        public static void CheckItems()
        {
            int i;

            for (i = 1; i <= Constants.MAX_ITEMS; i++)
            {
                if (!File.Exists(Path.Combine(Application.StartupPath, "data", "items", string.Format("item{0}.dat", i))))
                    SaveItem(i);
            }
        }

        public static void ClearItem(int index)
        {
            Types.Item[index] = default(ItemRec);
            Types.Item[index].Name = "";
            Types.Item[index].Description = "";

            for (var i = 0; i <= Constants.MAX_ITEMS; i++)
            {
                Types.Item[i].Add_Stat = new byte[7];
                Types.Item[i].Stat_Req = new byte[7];
                Types.Item[i].FurnitureBlocks = new int[4, 4];
                Types.Item[i].FurnitureFringe = new int[4, 4];
            }
        }

        public static void ClearItems()
        {
            for (var i = 1; i <= Constants.MAX_ITEMS; i++)
                ClearItem(i);
        }

        public static byte[] ItemsData()
        {
            ByteStream buffer = new ByteStream(4);
            for (var i = 1; i <= Constants.MAX_ITEMS; i++)
            {
                if (!(Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Item[i].Name)) > 0))
                    continue;
                buffer.WriteBlock(ItemData(i));
            }
            return buffer.ToArray();
        }

        public static byte[] ItemData(int itemNum)
        {
            ByteStream buffer = new ByteStream(4);
            buffer.WriteInt32(itemNum);
            buffer.WriteInt32(Types.Item[itemNum].AccessReq);

            for (var i = 0; i <= (int)Enums.StatType.Count - 1; i++)
                buffer.WriteInt32(Types.Item[itemNum].Add_Stat[i]);

            buffer.WriteInt32(Types.Item[itemNum].Animation);
            buffer.WriteInt32(Types.Item[itemNum].BindType);
            buffer.WriteInt32(Types.Item[itemNum].ClassReq);
            buffer.WriteInt32(Types.Item[itemNum].Data1);
            buffer.WriteInt32(Types.Item[itemNum].Data2);
            buffer.WriteInt32(Types.Item[itemNum].Data3);
            buffer.WriteInt32(Types.Item[itemNum].TwoHanded);
            buffer.WriteInt32(Types.Item[itemNum].LevelReq);
            buffer.WriteInt32(Types.Item[itemNum].Mastery);
            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Types.Item[itemNum].Name)));
            buffer.WriteInt32(Types.Item[itemNum].Paperdoll);
            buffer.WriteInt32(Types.Item[itemNum].Pic);
            buffer.WriteInt32(Types.Item[itemNum].Price);
            buffer.WriteInt32(Types.Item[itemNum].Rarity);
            buffer.WriteInt32(Types.Item[itemNum].Speed);

            buffer.WriteInt32(Types.Item[itemNum].Randomize);
            buffer.WriteInt32(Types.Item[itemNum].RandomMin);
            buffer.WriteInt32(Types.Item[itemNum].RandomMax);

            buffer.WriteInt32(Types.Item[itemNum].Stackable);
            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Types.Item[itemNum].Description)));

            for (var i = 0; i <= (int)Enums.StatType.Count - 1; i++)
                buffer.WriteInt32(Types.Item[itemNum].Stat_Req[i]);

            buffer.WriteInt32(Types.Item[itemNum].Type);
            buffer.WriteInt32(Types.Item[itemNum].SubType);

            buffer.WriteInt32(Types.Item[itemNum].ItemLevel);
            // Housing
            buffer.WriteInt32(Types.Item[itemNum].FurnitureWidth);
            buffer.WriteInt32(Types.Item[itemNum].FurnitureHeight);

            for (var i = 0; i <= 3; i++)
            {
                for (var x = 0; x <= 3; x++)
                {
                    buffer.WriteInt32(Types.Item[itemNum].FurnitureBlocks[i, x]);
                    buffer.WriteInt32(Types.Item[itemNum].FurnitureFringe[i, x]);
                }
            }

            buffer.WriteInt32(Types.Item[itemNum].KnockBack);
            buffer.WriteInt32(Types.Item[itemNum].KnockBackTiles);
            buffer.WriteInt32(Types.Item[itemNum].Projectile);
            buffer.WriteInt32(Types.Item[itemNum].Ammo);
            return buffer.ToArray();
        }



        public static void SendMapItemsTo(int index, int mapNum)
        {
            int i;
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SMapItemData);

            S_General.AddDebug("Sent SMSG: SMapItemData");

            for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
            {
                buffer.WriteInt32(modTypes.MapItem[mapNum, i].Num);
                buffer.WriteInt32(modTypes.MapItem[mapNum, i].Value);
                buffer.WriteInt32(modTypes.MapItem[mapNum, i].X);
                buffer.WriteInt32(modTypes.MapItem[mapNum, i].Y);
            }

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendMapItemsToAll(int mapNum)
        {
            int i;
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ServerPackets.SMapItemData);

            S_General.AddDebug("Sent SMSG: SMapItemData To All");

            for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
            {
                buffer.WriteInt32(modTypes.MapItem[mapNum, i].Num);
                buffer.WriteInt32(modTypes.MapItem[mapNum, i].Value);
                buffer.WriteInt32(modTypes.MapItem[mapNum, i].X);
                buffer.WriteInt32(modTypes.MapItem[mapNum, i].Y);
            }

            S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SpawnItem(int itemNum, int ItemVal, int mapNum, int x, int y)
        {
            int i;

            // Check for subscript out of range
            if (itemNum < 1 || itemNum > Constants.MAX_ITEMS || mapNum <= 0 || mapNum > S_Instances.MAX_CACHED_MAPS)
                return;

            // Find open map item slot
            i = FindOpenMapItemSlot(mapNum);

            if (i == 0)
                return;

            SpawnItemSlot(i, itemNum, ItemVal, mapNum, x, y);
        }

        public static void SpawnItemSlot(int MapItemSlot, int itemNum, int ItemVal, int mapNum, int x, int y)
        {
            int i;
            ByteStream buffer = new ByteStream(4);

            // Check for subscript out of range
            if (MapItemSlot <= 0 || MapItemSlot > Constants.MAX_MAP_ITEMS || itemNum < 0 || itemNum > Constants.MAX_ITEMS || mapNum <= 0 || mapNum > S_Instances.MAX_CACHED_MAPS)
                return;

            i = MapItemSlot;

            if (i != 0)
            {
                if (itemNum >= 0 && itemNum <= Constants.MAX_ITEMS)
                {
                    modTypes.MapItem[mapNum, i].Num = itemNum;
                    modTypes.MapItem[mapNum, i].Value = ItemVal;
                    modTypes.MapItem[mapNum, i].X = (byte)x;
                    modTypes.MapItem[mapNum, i].Y = (byte)y;

                    buffer.WriteInt32((int)Packets.ServerPackets.SSpawnItem);
                    buffer.WriteInt32(i);
                    buffer.WriteInt32(itemNum);
                    buffer.WriteInt32(ItemVal);
                    buffer.WriteInt32(x);
                    buffer.WriteInt32(y);

                    S_General.AddDebug("Sent SMSG: SSpawnItem MapItemSlot");

                    S_NetworkConfig.SendDataToMap(mapNum, ref buffer.Data, buffer.Head);
                }
            }

            buffer.Dispose();
        }

        public static int FindOpenMapItemSlot(int mapNum)
        {
            int i;

            // Check for subscript out of range
            if (mapNum <= 0 || mapNum > S_Instances.MAX_CACHED_MAPS)
                return 0;

            for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
            {
                if (modTypes.MapItem[mapNum, i].Num == 0)
                {
                    return i;
                }
            }
            return 0;
        }

        public static void SpawnAllMapsItems()
        {
            int i;

            for (i = 1; i <= S_Instances.MAX_CACHED_MAPS; i++)
                SpawnMapItems(i);
        }

        public static void SpawnMapItems(int mapNum)
        {
            int x;
            int y;

            // Check for subscript out of range
            if (mapNum <= 0 || mapNum > S_Instances.MAX_CACHED_MAPS)
                return;
            var loopTo = modTypes.Map[mapNum].MaxX;

            // Spawn what we have
            for (x = 0; x <= loopTo; x++)
            {
                var loopTo1 = modTypes.Map[mapNum].MaxY;
                for (y = 0; y <= loopTo1; y++)
                {
                    // Check if the tile type is an item or a saved tile incase someone drops something
                    if ((modTypes.Map[mapNum].Tile[x, y].Type == (int)Enums.TileType.Item))
                    {

                        // Check to see if its a currency and if they set the value to 0 set it to 1 automatically
                        if (Types.Item[modTypes.Map[mapNum].Tile[x, y].Data1].Type == (int)Enums.ItemType.Currency || Types.Item[modTypes.Map[mapNum].Tile[x, y].Data1].Stackable == 1)
                        {
                            if (modTypes.Map[mapNum].Tile[x, y].Data2 <= 0)
                                SpawnItem(modTypes.Map[mapNum].Tile[x, y].Data1, 1, mapNum, x, y);
                            else
                                SpawnItem(modTypes.Map[mapNum].Tile[x, y].Data1, modTypes.Map[mapNum].Tile[x, y].Data2, mapNum, x, y);
                        }
                        else
                            SpawnItem(modTypes.Map[mapNum].Tile[x, y].Data1, modTypes.Map[mapNum].Tile[x, y].Data2, mapNum, x, y);
                    }
                }
            }
        }



        public static void Packet_RequestItems(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CRequestItems");

            SendItems(index);
        }

        public static void Packet_EditItem(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved EMSG: RequestEditItem");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (int)Enums.AdminType.Mapper)
                return;

            var Buffer = new ByteStream(4);

            Buffer.WriteInt32((int)Packets.ServerPackets.SItemEditor);
            S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);

            S_General.AddDebug("Sent SMSG: SItemEditor");

            Buffer.Dispose();
        }

        public static void Packet_SaveItem(int index, ref byte[] data)
        {
            int n;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved EMSG: SaveItem");

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (int)Enums.AdminType.Developer)
                return;

            n = buffer.ReadInt32();

            if (n < 0 || n > Constants.MAX_ITEMS)
                return;

            // Update the item
            Types.Item[n].AccessReq = buffer.ReadInt32();

            for (var i = 0; i <= (int)Enums.StatType.Count - 1; i++)
                Types.Item[n].Add_Stat[i] = (byte)buffer.ReadInt32();

            Types.Item[n].Animation = buffer.ReadInt32();
            Types.Item[n].BindType = (byte)buffer.ReadInt32();
            Types.Item[n].ClassReq = buffer.ReadInt32();
            Types.Item[n].Data1 = buffer.ReadInt32();
            Types.Item[n].Data2 = buffer.ReadInt32();
            Types.Item[n].Data3 = buffer.ReadInt32();
            Types.Item[n].TwoHanded = buffer.ReadInt32();
            Types.Item[n].LevelReq = buffer.ReadInt32();
            Types.Item[n].Mastery = (byte)buffer.ReadInt32();
            Types.Item[n].Name = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());
            Types.Item[n].Paperdoll = buffer.ReadInt32();
            Types.Item[n].Pic = buffer.ReadInt32();
            Types.Item[n].Price = buffer.ReadInt32();
            Types.Item[n].Rarity = (byte)buffer.ReadInt32();
            Types.Item[n].Speed = buffer.ReadInt32();

            Types.Item[n].Randomize = (byte)buffer.ReadInt32();
            Types.Item[n].RandomMin = (byte)buffer.ReadInt32();
            Types.Item[n].RandomMax = (byte)buffer.ReadInt32();

            Types.Item[n].Stackable = (byte)buffer.ReadInt32();
            Types.Item[n].Description = Microsoft.VisualBasic.Strings.Trim(buffer.ReadString());

            for (var i = 0; i <= (int)Enums.StatType.Count - 1; i++)
                Types.Item[n].Stat_Req[i] = (byte)buffer.ReadInt32();

            Types.Item[n].Type = (byte)buffer.ReadInt32();
            Types.Item[n].SubType = (byte)buffer.ReadInt32();

            Types.Item[n].ItemLevel = (byte)buffer.ReadInt32();

            // Housing
            Types.Item[n].FurnitureWidth = buffer.ReadInt32();
            Types.Item[n].FurnitureHeight = buffer.ReadInt32();

            for (var a = 0; a <= 3; a++)
            {
                for (var b = 0; b <= 3; b++)
                {
                    Types.Item[n].FurnitureBlocks[a, b] = buffer.ReadInt32();
                    Types.Item[n].FurnitureFringe[a, b] = buffer.ReadInt32();
                }
            }

            Types.Item[n].KnockBack = (byte)buffer.ReadInt32();
            Types.Item[n].KnockBackTiles = (byte)buffer.ReadInt32();

            Types.Item[n].Projectile = buffer.ReadInt32();
            Types.Item[n].Ammo = buffer.ReadInt32();

            // Save it
            SendUpdateItemToAll(n);
            SaveItem(n);
            modDatabase.Addlog(S_Players.GetPlayerLogin(index) + " saved item #" + n + ".", S_Constants.ADMIN_LOG);
            buffer.Dispose();
        }

        public static void Packet_GetItem(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CMapGetItem");

            S_Players.PlayerMapGetItem(index);
        }

        public static void Packet_DropItem(int index, ref byte[] data)
        {
            int InvNum;
            int Amount;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CMapDropItem");

            InvNum = buffer.ReadInt32();
            Amount = buffer.ReadInt32();
            buffer.Dispose();

            if (modTypes.TempPlayer[index].InBank || Convert.ToBoolean(modTypes.TempPlayer[index].InShop))
                return;

            // Prevent hacking
            if (InvNum < 1 || InvNum > Constants.MAX_INV)
                return;
            if (S_Players.GetPlayerInvItemNum(index, InvNum) < 1 || S_Players.GetPlayerInvItemNum(index, InvNum) > Constants.MAX_ITEMS)
                return;
            if (Types.Item[S_Players.GetPlayerInvItemNum(index, InvNum)].Type == (int)Enums.ItemType.Currency || Types.Item[S_Players.GetPlayerInvItemNum(index, InvNum)].Stackable == 1)
            {
                if (Amount < 1 || Amount > S_Players.GetPlayerInvItemValue(index, InvNum))
                    return;
            }

            // everything worked out fine
            S_Players.PlayerMapDropItem(index, InvNum, Amount);
        }



        public static void SendItems(int index)
        {
            int i;

            for (i = 1; i <= Constants.MAX_ITEMS; i++)
            {
                if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Types.Item[i].Name)) > 0)
                    SendUpdateItemTo(index, i);
            }
        }

        public static void SendUpdateItemTo(int index, int itemNum)
        {
            ByteStream buffer;
            buffer = new ByteStream(4);
            buffer.WriteInt32((byte)Packets.ServerPackets.SUpdateItem);

            buffer.WriteBlock(ItemData(itemNum));

            S_General.AddDebug("Sent SMSG: SUpdateItem");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendUpdateItemToAll(int itemNum)
        {
            ByteStream buffer;
            buffer = new ByteStream(4);
            buffer.WriteInt32((byte)Packets.ServerPackets.SUpdateItem);

            buffer.WriteBlock(ItemData(itemNum));

            S_General.AddDebug("Sent SMSG: SUpdateItem To All");

            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);
            buffer.Dispose();
        }
    }
}
