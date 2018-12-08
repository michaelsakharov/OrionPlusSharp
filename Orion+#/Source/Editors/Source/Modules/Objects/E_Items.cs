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
using ASFW;
using SFML.Graphics;
using static Engine.Types;

namespace Engine
{
    internal static class E_Items
    {
        internal static void ClearItem(int index)
        {
            index = index - 1;
            Types.Item[index] = default(ItemRec);
            Types.Item[index] = new Types.ItemRec();
            for (var x = 0; x <= (byte)Enums.StatType.Count - 1; x++)
                Types.Item[index].Add_Stat = new byte[x + 1];
            for (int x = 0; x <= (byte)Enums.StatType.Count - 1; x++)
                Types.Item[index].Stat_Req = new byte[x + 1];

            Types.Item[index].FurnitureBlocks = new int[4, 4];
            Types.Item[index].FurnitureFringe = new int[4, 4];

            Types.Item[index].Name = "";
        }

        internal static void ClearChanged_Item()
        {
            for (var i = 1; i <= Constants.MAX_ITEMS; i++)
                E_Globals.Item_Changed[i] = default(bool);
            E_Globals.Item_Changed = new bool[501];
        }

        public static void ClearItems()
        {
            int i;

            for (i = 1; i <= Constants.MAX_ITEMS; i++)
                ClearItem(i);
        }



        public static void Packet_EditItem(ref byte[] data)
        {
            ByteStream buffer;
            buffer = new ByteStream(data);
            E_Globals.InitItemEditor = true;

            buffer.Dispose();
        }

        public static void Packet_UpdateItem(ref byte[] data)
        {
            int n;
            int i;
            ByteStream buffer = new ByteStream(data);
            n = buffer.ReadInt32();

            // Update the item
            Types.Item[n].AccessReq = buffer.ReadInt32();

            for (i = 0; i <= (byte)Enums.StatType.Count - 1; i++)
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

            for (i = 0; i <= (byte)Enums.StatType.Count - 1; i++)
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

            buffer.Dispose();
        }



        public static void SendRequestItems()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CRequestItems);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendSaveItem(int itemNum)
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.SaveItem);
            buffer.WriteInt32(itemNum);
            buffer.WriteInt32(Types.Item[itemNum].AccessReq);

            for (var i = 0; i <= (byte)Enums.StatType.Count - 1; i++)
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

            for (var i = 0; i <= (byte)Enums.StatType.Count - 1; i++)
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

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        internal static void SendRequestEditItem()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.RequestEditItem);
            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }



        internal static void ItemEditorPreInit()
        {
            int i;

            {
                var withBlock = My.MyProject.Forms.FrmItem;
                E_Globals.Editor = E_Globals.EDITOR_ITEM;
                withBlock.lstIndex.Items.Clear();

                // Add the names
                for (i = 1; i <= Constants.MAX_ITEMS; i++)
                    withBlock.lstIndex.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(Types.Item[i].Name));

                withBlock.Show();
                withBlock.lstIndex.SelectedIndex = 0;
                ItemEditorInit();
            }
        }

        internal static void ItemEditorInit()
        {
            int i;

            if (My.MyProject.Forms.FrmItem.Visible == false)
                return;
            E_Globals.Editorindex = My.MyProject.Forms.FrmItem.lstIndex.SelectedIndex + 1;

            {
                var withBlock = Types.Item[E_Globals.Editorindex];
                // populate combo boxes
                My.MyProject.Forms.FrmItem.cmbAnimation.Items.Clear();
                My.MyProject.Forms.FrmItem.cmbAnimation.Items.Add("None");
                for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
                    My.MyProject.Forms.FrmItem.cmbAnimation.Items.Add(i + ": " + Types.Animation[i].Name);

                My.MyProject.Forms.FrmItem.cmbAmmo.Items.Clear();
                My.MyProject.Forms.FrmItem.cmbAmmo.Items.Add("None");
                for (i = 1; i <= Constants.MAX_ITEMS; i++)
                    My.MyProject.Forms.FrmItem.cmbAmmo.Items.Add(i + ": " + Types.Item[i].Name);

                My.MyProject.Forms.FrmItem.cmbProjectile.Items.Clear();
                My.MyProject.Forms.FrmItem.cmbProjectile.Items.Add("None");
                for (i = 1; i <= E_Projectiles.MAX_PROJECTILES; i++)
                    My.MyProject.Forms.FrmItem.cmbProjectile.Items.Add(i + ": " + E_Projectiles.Projectiles[i].Name);

                My.MyProject.Forms.FrmItem.cmbSkills.Items.Clear();
                My.MyProject.Forms.FrmItem.cmbSkills.Items.Add("None");
                for (i = 1; i <= Constants.MAX_SKILLS; i++)
                    My.MyProject.Forms.FrmItem.cmbSkills.Items.Add(i + ": " + Types.Skill[i].Name);

                My.MyProject.Forms.FrmItem.cmbPet.Items.Clear();
                My.MyProject.Forms.FrmItem.cmbPet.Items.Add("None");
                for (i = 1; i <= Constants.MAX_PETS; i++)
                    My.MyProject.Forms.FrmItem.cmbPet.Items.Add(i + ": " + E_Pets.Pet[i].Name);

                My.MyProject.Forms.FrmItem.cmbRecipe.Items.Clear();
                My.MyProject.Forms.FrmItem.cmbRecipe.Items.Add("None");
                for (i = 1; i <= Constants.MAX_RECIPE; i++)
                    My.MyProject.Forms.FrmItem.cmbRecipe.Items.Add(i + ": " + E_Crafting.Recipe[i].Name);

                My.MyProject.Forms.FrmItem.txtName.Text = Microsoft.VisualBasic.Strings.Trim(withBlock.Name);
                My.MyProject.Forms.FrmItem.txtDescription.Text = Microsoft.VisualBasic.Strings.Trim(withBlock.Description);

                if (withBlock.Pic > My.MyProject.Forms.FrmItem.nudPic.Maximum)
                    withBlock.Pic = 0;
                My.MyProject.Forms.FrmItem.nudPic.Value = withBlock.Pic;
                if (withBlock.Type > (byte)Enums.ItemType.Count - 1)
                    withBlock.Type = 0;
                My.MyProject.Forms.FrmItem.cmbType.SelectedIndex = withBlock.Type;
                My.MyProject.Forms.FrmItem.cmbAnimation.SelectedIndex = withBlock.Animation;

                if (withBlock.ItemLevel == 0)
                    withBlock.ItemLevel = 1;
                My.MyProject.Forms.FrmItem.nudItemLvl.Value = withBlock.ItemLevel;

                // Type specific settings
                if ((My.MyProject.Forms.FrmItem.cmbType.SelectedIndex == (byte)Enums.ItemType.Equipment))
                {
                    My.MyProject.Forms.FrmItem.fraEquipment.Visible = true;
                    My.MyProject.Forms.FrmItem.cmbProjectile.SelectedIndex = withBlock.Data1;
                    My.MyProject.Forms.FrmItem.nudDamage.Value = withBlock.Data2;
                    My.MyProject.Forms.FrmItem.cmbTool.SelectedIndex = withBlock.Data3;

                    My.MyProject.Forms.FrmItem.cmbSubType.SelectedIndex = withBlock.SubType;

                    if (withBlock.Speed < 100)
                        withBlock.Speed = 100;
                    if (withBlock.Speed > My.MyProject.Forms.FrmItem.nudSpeed.Maximum)
                        withBlock.Speed = (int)My.MyProject.Forms.FrmItem.nudSpeed.Maximum;
                    My.MyProject.Forms.FrmItem.nudSpeed.Value = withBlock.Speed;

                    My.MyProject.Forms.FrmItem.nudStrength.Value = withBlock.Add_Stat[(byte)Enums.StatType.Strength];
                    My.MyProject.Forms.FrmItem.nudEndurance.Value = withBlock.Add_Stat[(byte)Enums.StatType.Endurance];
                    My.MyProject.Forms.FrmItem.nudIntelligence.Value = withBlock.Add_Stat[(byte)Enums.StatType.Intelligence];
                    My.MyProject.Forms.FrmItem.nudVitality.Value = withBlock.Add_Stat[(byte)Enums.StatType.Vitality];
                    My.MyProject.Forms.FrmItem.nudLuck.Value = withBlock.Add_Stat[(byte)Enums.StatType.Luck];
                    My.MyProject.Forms.FrmItem.nudSpirit.Value = withBlock.Add_Stat[(byte)Enums.StatType.Spirit];

                    if (withBlock.KnockBack == 1)
                        My.MyProject.Forms.FrmItem.chkKnockBack.Checked = true;
                    else
                        My.MyProject.Forms.FrmItem.chkKnockBack.Checked = false;
                    My.MyProject.Forms.FrmItem.cmbKnockBackTiles.SelectedIndex = withBlock.KnockBackTiles;

                    if (withBlock.Randomize == 1)
                        My.MyProject.Forms.FrmItem.chkRandomize.Checked = true;
                    else
                        My.MyProject.Forms.FrmItem.chkRandomize.Checked = false;

                    // If .RandomMin = 0 Then .RandomMin = 1
                    // frmEditor_Item.numMin.Value = .RandomMin

                    // If .RandomMax <= 1 Then .RandomMax = 2
                    // frmEditor_Item.numMax.Value = .RandomMax

                    My.MyProject.Forms.FrmItem.nudPaperdoll.Value = withBlock.Paperdoll;

                    My.MyProject.Forms.FrmItem.cmbProjectile.SelectedIndex = withBlock.Projectile;
                    My.MyProject.Forms.FrmItem.cmbAmmo.SelectedIndex = withBlock.Ammo;
                }
                else
                    My.MyProject.Forms.FrmItem.fraEquipment.Visible = false;

                if ((My.MyProject.Forms.FrmItem.cmbType.SelectedIndex == (byte)Enums.ItemType.Consumable))
                {
                    My.MyProject.Forms.FrmItem.fraVitals.Visible = true;
                    My.MyProject.Forms.FrmItem.nudVitalMod.Value = withBlock.Data1;
                }
                else
                    My.MyProject.Forms.FrmItem.fraVitals.Visible = false;

                if ((My.MyProject.Forms.FrmItem.cmbType.SelectedIndex == (byte)Enums.ItemType.Skill))
                {
                    My.MyProject.Forms.FrmItem.fraSkill.Visible = true;
                    My.MyProject.Forms.FrmItem.cmbSkills.SelectedIndex = withBlock.Data1;
                }
                else
                    My.MyProject.Forms.FrmItem.fraSkill.Visible = false;

                if (My.MyProject.Forms.FrmItem.cmbType.SelectedIndex == (byte)Enums.ItemType.Furniture)
                {
                    My.MyProject.Forms.FrmItem.fraFurniture.Visible = true;
                    if (Types.Item[E_Globals.Editorindex].Data2 > 0 && Types.Item[E_Globals.Editorindex].Data2 <= E_Housing.NumFurniture)
                        My.MyProject.Forms.FrmItem.nudFurniture.Value = Types.Item[E_Globals.Editorindex].Data2;
                    else
                        My.MyProject.Forms.FrmItem.nudFurniture.Value = 1;
                    My.MyProject.Forms.FrmItem.cmbFurnitureType.SelectedIndex = Types.Item[E_Globals.Editorindex].Data1;
                }
                else
                    My.MyProject.Forms.FrmItem.fraFurniture.Visible = false;

                if ((My.MyProject.Forms.FrmItem.cmbType.SelectedIndex == (byte)Enums.ItemType.Pet))
                {
                    My.MyProject.Forms.FrmItem.fraPet.Visible = true;
                    My.MyProject.Forms.FrmItem.cmbPet.SelectedIndex = withBlock.Data1;
                }
                else
                    My.MyProject.Forms.FrmItem.fraPet.Visible = false;

                // Basic requirements
                My.MyProject.Forms.FrmItem.cmbAccessReq.SelectedIndex = withBlock.AccessReq;
                My.MyProject.Forms.FrmItem.nudLevelReq.Value = withBlock.LevelReq;

                My.MyProject.Forms.FrmItem.nudStrReq.Value = withBlock.Stat_Req[(byte)Enums.StatType.Strength];
                My.MyProject.Forms.FrmItem.nudVitReq.Value = withBlock.Stat_Req[(byte)Enums.StatType.Vitality];
                My.MyProject.Forms.FrmItem.nudLuckReq.Value = withBlock.Stat_Req[(byte)Enums.StatType.Luck];
                My.MyProject.Forms.FrmItem.nudEndReq.Value = withBlock.Stat_Req[(byte)Enums.StatType.Endurance];
                My.MyProject.Forms.FrmItem.nudIntReq.Value = withBlock.Stat_Req[(byte)Enums.StatType.Intelligence];
                My.MyProject.Forms.FrmItem.nudSprReq.Value = withBlock.Stat_Req[(byte)Enums.StatType.Spirit];

                // Build cmbClassReq
                My.MyProject.Forms.FrmItem.cmbClassReq.Items.Clear();
                My.MyProject.Forms.FrmItem.cmbClassReq.Items.Add("None");
                var loopTo = E_Globals.Max_Classes;
                for (i = 1; i <= loopTo; i++)
                    My.MyProject.Forms.FrmItem.cmbClassReq.Items.Add(Types.Classes[i].Name);

                My.MyProject.Forms.FrmItem.cmbClassReq.SelectedIndex = withBlock.ClassReq;
                // Info
                My.MyProject.Forms.FrmItem.nudPrice.Value = withBlock.Price;
                My.MyProject.Forms.FrmItem.cmbBind.SelectedIndex = withBlock.BindType;
                My.MyProject.Forms.FrmItem.nudRarity.Value = withBlock.Rarity;

                if (withBlock.Stackable == 1)
                    My.MyProject.Forms.FrmItem.chkStackable.Checked = true;
                else
                    My.MyProject.Forms.FrmItem.chkStackable.Checked = false;

                E_Globals.Editorindex = My.MyProject.Forms.FrmItem.lstIndex.SelectedIndex + 1;
            }

            My.MyProject.Forms.FrmItem.nudPic.Maximum = E_Graphics.NumItems;

            if (E_Graphics.NumPaperdolls > 0)
                My.MyProject.Forms.FrmItem.nudPaperdoll.Maximum = E_Graphics.NumPaperdolls + 1;

            EditorItem_DrawItem();
            EditorItem_DrawPaperdoll();
            EditorItem_DrawFurniture();
            E_Globals.Item_Changed[E_Globals.Editorindex] = true;
        }

        internal static void ItemEditorCancel()
        {
            E_Globals.Editor = 0;
            My.MyProject.Forms.FrmItem.Visible = false;
            ClearChanged_Item();
            ClearItems();
            SendRequestItems();
        }

        internal static void ItemEditorOk()
        {
            int i;

            for (i = 1; i <= Constants.MAX_ITEMS; i++)
            {
                if (E_Globals.Item_Changed[i])
                    SendSaveItem(i);
            }

            My.MyProject.Forms.FrmItem.Visible = false;
            E_Globals.Editor = 0;
            ClearChanged_Item();
        }



        internal static void CheckItems()
        {
            int i;
            i = 1;

            while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Items\" + i + E_Globals.GFX_EXT))
            {
                E_Graphics.NumItems = E_Graphics.NumItems + 1;
                i = i + 1;
            }

            if (E_Graphics.NumItems == 0)
                return;
        }

        internal static void EditorItem_DrawItem()
        {
            int itemnum;
            itemnum = (int)My.MyProject.Forms.FrmItem.nudPic.Value;

            if (itemnum < 1 || itemnum > E_Graphics.NumItems)
            {
                My.MyProject.Forms.FrmItem.picItem.BackgroundImage = null;
                return;
            }

            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"items\" + itemnum + E_Globals.GFX_EXT))
                My.MyProject.Forms.FrmItem.picItem.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"items\" + itemnum + E_Globals.GFX_EXT);
        }

        internal static void EditorItem_DrawPaperdoll()
        {
            int Sprite;

            Sprite = (int)My.MyProject.Forms.FrmItem.nudPaperdoll.Value;

            if (Sprite < 1 || Sprite > E_Graphics.NumPaperdolls)
            {
                My.MyProject.Forms.FrmItem.picPaperdoll.BackgroundImage = null;
                return;
            }

            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"paperdolls\" + Sprite + E_Globals.GFX_EXT))
                My.MyProject.Forms.FrmItem.picPaperdoll.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"paperdolls\" + Sprite + E_Globals.GFX_EXT);
        }

        internal static void EditorItem_DrawFurniture()
        {
            int Furniturenum;
            Rectangle sRECT = new Rectangle();
            Rectangle dRECT = new Rectangle();
            Furniturenum = (int)My.MyProject.Forms.FrmItem.nudFurniture.Value;

            if (Furniturenum < 1 || Furniturenum > E_Housing.NumFurniture)
            {
                E_Graphics.EditorItem_Furniture.Clear(E_Graphics.ToSFMLColor(My.MyProject.Forms.FrmItem.picFurniture.BackColor));
                E_Graphics.EditorItem_Furniture.Display();
                return;
            }

            if (E_Graphics.FurnitureGFXInfo[Furniturenum].IsLoaded == false)
                E_Graphics.LoadTexture(Furniturenum, 10);

            // seeying we still use it, lets update timer
            {
                var withBlock = E_Graphics.FurnitureGFXInfo[Furniturenum];
                withBlock.TextureTimer = ClientDataBase.GetTickCount() + 100000;
            }

            // rect for source
            {
                var withBlock1 = sRECT;
                withBlock1.Y = 0;
                withBlock1.Height = E_Graphics.FurnitureGFXInfo[Furniturenum].height;
                withBlock1.X = 0;
                withBlock1.Width = E_Graphics.FurnitureGFXInfo[Furniturenum].width;
            }

            // same for destination as source
            dRECT = sRECT;

            E_Graphics.EditorItem_Furniture.Clear(E_Graphics.ToSFMLColor(My.MyProject.Forms.FrmItem.picFurniture.BackColor));

            E_Graphics.RenderSprite(E_Graphics.FurnitureSprite[Furniturenum], E_Graphics.EditorItem_Furniture, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height);

            if (My.MyProject.Forms.FrmItem.optSetBlocks.Checked == true)
            {
                for (var X = 0; X <= 3; X++)
                {
                    for (var Y = 0; Y <= 3; Y++)
                    {
                        if (X <= (E_Graphics.FurnitureGFXInfo[Furniturenum].width / (double)32) - 1)
                        {
                            if (Y <= (E_Graphics.FurnitureGFXInfo[Furniturenum].height / (double)32) - 1)
                            {
                                if (Types.Item[E_Globals.Editorindex].FurnitureBlocks[X, Y] == 1)
                                    E_Text.DrawText(X * 32 + 8, Y * 32 + 8, "X", SFML.Graphics.Color.Red, SFML.Graphics.Color.Black, ref E_Graphics.EditorItem_Furniture);
                                else
                                    E_Text.DrawText(X * 32 + 8, Y * 32 + 8, "O", SFML.Graphics.Color.Blue, SFML.Graphics.Color.Black, ref E_Graphics.EditorItem_Furniture);
                            }
                        }
                    }
                }
            }
            else if (My.MyProject.Forms.FrmItem.optSetFringe.Checked == true)
            {
                for (var X = 0; X <= 3; X++)
                {
                    for (var Y = 0; Y <= 3; Y++)
                    {
                        if (X <= (E_Graphics.FurnitureGFXInfo[Furniturenum].width / (double)32) - 1)
                        {
                            if (Y <= (E_Graphics.FurnitureGFXInfo[Furniturenum].height / (double)32))
                            {
                                if (Types.Item[E_Globals.Editorindex].FurnitureFringe[X, Y] == 1)
                                    E_Text.DrawText(X * 32 + 8, Y * 32 + 8, "O", SFML.Graphics.Color.Blue, SFML.Graphics.Color.Black, ref E_Graphics.EditorItem_Furniture);
                            }
                        }
                    }
                }
            }
            E_Graphics.EditorItem_Furniture.Display();
        }
    }
}
