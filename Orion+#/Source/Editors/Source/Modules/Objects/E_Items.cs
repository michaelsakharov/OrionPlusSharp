
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using System.IO;
using ASFW;
using SFML.Graphics;
using Engine;


namespace Engine
{
	internal sealed class E_Items
	{
		
#region Database
		
		internal static void ClearItem(int index)
		{
			index--;
			Types.Item[index] = new Types.ItemRec();
			for (var x = 0; x <= (int) Enums.StatType.Count - 1; x++)
			{
				Types.Item[index].Add_Stat = new byte[(int) x + 1];
			}
			for (var x = 0; x <= (int) Enums.StatType.Count - 1; x++)
			{
				Types.Item[index].Stat_Req = new byte[(int) x + 1];
			}
			
			Types.Item[index].FurnitureBlocks = new int[4, 4];
			Types.Item[index].FurnitureFringe = new int[4, 4];
			
			Types.Item[index].Name = "";
		}
		
		internal static void ClearChanged_Item()
		{
			for (var i = 1; i <= Constants.MAX_ITEMS; i++)
			{
				E_Globals.Item_Changed[(int) i] = false;
			}
			E_Globals.Item_Changed = new bool[Constants.MAX_ITEMS + 1];
		}
		
		public static void ClearItems()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_ITEMS; i++)
			{
				ClearItem(i);
			}
			
		}
		
#endregion
		
#region Incoming Packets
		
		public static void Packet_EditItem(ref byte[] data)
		{
			ByteStream buffer = new ByteStream();
			buffer = new ByteStream(data);
			E_Globals.InitItemEditor = true;
			
			buffer.Dispose();
		}
		
		public static void Packet_UpdateItem(ref byte[] data)
		{
			int n = 0;
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			n = buffer.ReadInt32();
			
			// Update the item
			Types.Item[n].AccessReq = buffer.ReadInt32();
			
			for (i = 0; i <= (int) Enums.StatType.Count - 1; i++)
			{
				Types.Item[n].Add_Stat[i] = (byte)buffer.ReadInt32();
			}
			
			Types.Item[n].Animation = buffer.ReadInt32();
			Types.Item[n].BindType = (byte) (buffer.ReadInt32());
			Types.Item[n].ClassReq = buffer.ReadInt32();
			Types.Item[n].Data1 = buffer.ReadInt32();
			Types.Item[n].Data2 = buffer.ReadInt32();
			Types.Item[n].Data3 = buffer.ReadInt32();
			Types.Item[n].TwoHanded = buffer.ReadInt32();
			Types.Item[n].LevelReq = buffer.ReadInt32();
			Types.Item[n].Mastery = (byte) (buffer.ReadInt32());
			Types.Item[n].Name = buffer.ReadString().Trim();
			Types.Item[n].Paperdoll = buffer.ReadInt32();
			Types.Item[n].Pic = buffer.ReadInt32();
			Types.Item[n].Price = buffer.ReadInt32();
			Types.Item[n].Rarity = (byte) (buffer.ReadInt32());
			Types.Item[n].Speed = buffer.ReadInt32();
			
			Types.Item[n].Randomize = (byte) (buffer.ReadInt32());
			Types.Item[n].RandomMin = (byte) (buffer.ReadInt32());
			Types.Item[n].RandomMax = (byte) (buffer.ReadInt32());
			
			Types.Item[n].Stackable = (byte) (buffer.ReadInt32());
			Types.Item[n].Description = buffer.ReadString().Trim();
			
			for (i = 0; i <= (int) Enums.StatType.Count - 1; i++)
			{
				Types.Item[n].Stat_Req[i] = (byte)buffer.ReadInt32();
			}
			
			Types.Item[n].Type = (byte) (buffer.ReadInt32());
			Types.Item[n].SubType = (byte) (buffer.ReadInt32());
			
			Types.Item[n].ItemLevel = (byte) (buffer.ReadInt32());
			
			//Housing
			Types.Item[n].FurnitureWidth = buffer.ReadInt32();
			Types.Item[n].FurnitureHeight = buffer.ReadInt32();
			
			for (var a = 0; a <= 3; a++)
			{
				for (var b = 0; b <= 3; b++)
				{
					Types.Item[n].FurnitureBlocks[(int) a, (int) b] = buffer.ReadInt32();
					Types.Item[n].FurnitureFringe[(int) a, (int) b] = buffer.ReadInt32();
				}
			}
			
			Types.Item[n].KnockBack = (byte) (buffer.ReadInt32());
			Types.Item[n].KnockBackTiles = (byte) (buffer.ReadInt32());
			
			Types.Item[n].Projectile = buffer.ReadInt32();
			Types.Item[n].Ammo = buffer.ReadInt32();
			
			buffer.Dispose();
			
		}
		
#endregion
		
#region Outgoing Packets
		
		public static void SendRequestItems()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestItems);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendSaveItem(int itemNum)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.SaveItem);
			buffer.WriteInt32(itemNum);
			buffer.WriteInt32(Types.Item[itemNum].AccessReq);
			
			for (var i = 0; i <= (int) Enums.StatType.Count - 1; i++)
			{
				buffer.WriteInt32(System.Convert.ToInt32(Types.Item[itemNum].Add_Stat[(int) i]));
			}
			
			buffer.WriteInt32(Types.Item[itemNum].Animation);
			buffer.WriteInt32(Types.Item[itemNum].BindType);
			buffer.WriteInt32(Types.Item[itemNum].ClassReq);
			buffer.WriteInt32(Types.Item[itemNum].Data1);
			buffer.WriteInt32(Types.Item[itemNum].Data2);
			buffer.WriteInt32(Types.Item[itemNum].Data3);
			buffer.WriteInt32(Types.Item[itemNum].TwoHanded);
			buffer.WriteInt32(Types.Item[itemNum].LevelReq);
			buffer.WriteInt32(Types.Item[itemNum].Mastery);
			buffer.WriteString(Types.Item[itemNum].Name.Trim());
			buffer.WriteInt32(Types.Item[itemNum].Paperdoll);
			buffer.WriteInt32(Types.Item[itemNum].Pic);
			buffer.WriteInt32(Types.Item[itemNum].Price);
			buffer.WriteInt32(Types.Item[itemNum].Rarity);
			buffer.WriteInt32(Types.Item[itemNum].Speed);
			
			buffer.WriteInt32(Types.Item[itemNum].Randomize);
			buffer.WriteInt32(Types.Item[itemNum].RandomMin);
			buffer.WriteInt32(Types.Item[itemNum].RandomMax);
			
			buffer.WriteInt32(Types.Item[itemNum].Stackable);
			buffer.WriteString(Types.Item[itemNum].Description.Trim());
			
			for (var i = 0; i <= (int) Enums.StatType.Count - 1; i++)
			{
				buffer.WriteInt32(System.Convert.ToInt32(Types.Item[itemNum].Stat_Req[(int) i]));
			}
			
			buffer.WriteInt32(Types.Item[itemNum].Type);
			buffer.WriteInt32(Types.Item[itemNum].SubType);
			
			buffer.WriteInt32(Types.Item[itemNum].ItemLevel);
			
			//Housing
			buffer.WriteInt32(Types.Item[itemNum].FurnitureWidth);
			buffer.WriteInt32(Types.Item[itemNum].FurnitureHeight);
			
			for (var i = 0; i <= 3; i++)
			{
				for (var x = 0; x <= 3; x++)
				{
					buffer.WriteInt32(System.Convert.ToInt32(Types.Item[itemNum].FurnitureBlocks[(int) i, (int) x]));
					buffer.WriteInt32(System.Convert.ToInt32(Types.Item[itemNum].FurnitureFringe[(int) i, (int) x]));
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
			
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.RequestEditItem);
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
#endregion
		
#region Editor
		
		internal static void ItemEditorPreInit()
		{
			int i = 0;
			
			E_Globals.Editor = E_Globals.EDITOR_ITEM;
			FrmItem.Default.lstIndex.Items.Clear();
			
			// Add the names
			for (i = 1; i <= Constants.MAX_ITEMS; i++)
			{
				FrmItem.Default.lstIndex.Items.Add(i + ": " + Types.Item[i].Name.Trim());
			}
			
			FrmItem.Default.Show();
			FrmItem.Default.lstIndex.SelectedIndex = 0;
			ItemEditorInit();
		}
		
		internal static void ItemEditorInit()
		{
			int i = 0;
			
			if (FrmItem.Default.Visible == false)
			{
				return;
			}
			E_Globals.Editorindex = FrmItem.Default.lstIndex.SelectedIndex + 1;
			
			//populate combo boxes
			FrmItem.Default.cmbAnimation.Items.Clear();
			FrmItem.Default.cmbAnimation.Items.Add("None");
			for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
			{
				FrmItem.Default.cmbAnimation.Items.Add(i + ": " + Types.Animation[i].Name);
			}
			
			FrmItem.Default.cmbAmmo.Items.Clear();
			FrmItem.Default.cmbAmmo.Items.Add("None");
			for (i = 1; i <= Constants.MAX_ITEMS; i++)
			{
				FrmItem.Default.cmbAmmo.Items.Add(i + ": " + Types.Item[i].Name);
			}
			
			FrmItem.Default.cmbProjectile.Items.Clear();
			FrmItem.Default.cmbProjectile.Items.Add("None");
			for (i = 1; i <= E_Projectiles.MAX_PROJECTILES; i++)
			{
				FrmItem.Default.cmbProjectile.Items.Add(i + ": " + E_Projectiles.Projectiles[i].Name);
			}
			
			FrmItem.Default.cmbSkills.Items.Clear();
			FrmItem.Default.cmbSkills.Items.Add("None");
			for (i = 1; i <= Constants.MAX_SKILLS; i++)
			{
				FrmItem.Default.cmbSkills.Items.Add(i + ": " + Types.Skill[i].Name);
			}
			
			FrmItem.Default.cmbPet.Items.Clear();
			FrmItem.Default.cmbPet.Items.Add("None");
			for (i = 1; i <= Constants.MAX_PETS; i++)
			{
				FrmItem.Default.cmbPet.Items.Add(i + ": " + E_Pets.Pet[i].Name);
			}
			
			FrmItem.Default.cmbRecipe.Items.Clear();
			FrmItem.Default.cmbRecipe.Items.Add("None");
			for (i = 1; i <= Constants.MAX_RECIPE; i++)
			{
				FrmItem.Default.cmbRecipe.Items.Add(i + ": " + E_Crafting.Recipe[i].Name);
			}
			
			FrmItem.Default.txtName.Text = Types.Item[E_Globals.Editorindex].Name.Trim();
			FrmItem.Default.txtDescription.Text = Types.Item[E_Globals.Editorindex].Description.Trim();
			
			if (Types.Item[E_Globals.Editorindex].Pic > FrmItem.Default.nudPic.Maximum)
			{
				Types.Item[E_Globals.Editorindex].Pic = 0;
			}
			FrmItem.Default.nudPic.Value = Types.Item[E_Globals.Editorindex].Pic;
			if (Types.Item[E_Globals.Editorindex].Type > (int) Enums.ItemType.Count - 1)
			{
				Types.Item[E_Globals.Editorindex].Type = (byte) 0;
			}
			FrmItem.Default.cmbType.SelectedIndex = Types.Item[E_Globals.Editorindex].Type;
			FrmItem.Default.cmbAnimation.SelectedIndex = Types.Item[E_Globals.Editorindex].Animation;
			
			if (Types.Item[E_Globals.Editorindex].ItemLevel == 0)
			{
				Types.Item[E_Globals.Editorindex].ItemLevel = (byte) 1;
			}
			FrmItem.Default.nudItemLvl.Value = Types.Item[E_Globals.Editorindex].ItemLevel;
			
			// Type specific settings
			if (FrmItem.Default.cmbType.SelectedIndex == (int) Enums.ItemType.Equipment)
			{
				FrmItem.Default.fraEquipment.Visible = true;
				FrmItem.Default.cmbProjectile.SelectedIndex = Types.Item[E_Globals.Editorindex].Data1;
				FrmItem.Default.nudDamage.Value = Types.Item[E_Globals.Editorindex].Data2;
				FrmItem.Default.cmbTool.SelectedIndex = Types.Item[E_Globals.Editorindex].Data3;
				
				FrmItem.Default.cmbSubType.SelectedIndex = Types.Item[E_Globals.Editorindex].SubType;
				
				if (Types.Item[E_Globals.Editorindex].Speed < 100)
				{
					Types.Item[E_Globals.Editorindex].Speed = 100;
				}
				if (Types.Item[E_Globals.Editorindex].Speed > FrmItem.Default.nudSpeed.Maximum)
				{
					Types.Item[E_Globals.Editorindex].Speed = (int) FrmItem.Default.nudSpeed.Maximum;
				}
				FrmItem.Default.nudSpeed.Value = Types.Item[E_Globals.Editorindex].Speed;
				
				FrmItem.Default.nudStrength.Value = Types.Item[E_Globals.Editorindex].Add_Stat[(byte)Enums.StatType.Strength];
				FrmItem.Default.nudEndurance.Value = Types.Item[E_Globals.Editorindex].Add_Stat[(byte)Enums.StatType.Endurance];
				FrmItem.Default.nudIntelligence.Value = Types.Item[E_Globals.Editorindex].Add_Stat[(byte)Enums.StatType.Intelligence];
				FrmItem.Default.nudVitality.Value = Types.Item[E_Globals.Editorindex].Add_Stat[(byte)Enums.StatType.Vitality];
				FrmItem.Default.nudLuck.Value = Types.Item[E_Globals.Editorindex].Add_Stat[(byte)Enums.StatType.Luck];
				FrmItem.Default.nudSpirit.Value = Types.Item[E_Globals.Editorindex].Add_Stat[(byte)Enums.StatType.Spirit];
				
				if (Types.Item[E_Globals.Editorindex].KnockBack == 1)
				{
					FrmItem.Default.chkKnockBack.Checked = true;
				}
				else
				{
					FrmItem.Default.chkKnockBack.Checked = false;
				}
				FrmItem.Default.cmbKnockBackTiles.SelectedIndex = Types.Item[E_Globals.Editorindex].KnockBackTiles;
				
				if (Types.Item[E_Globals.Editorindex].Randomize == 1)
				{
					FrmItem.Default.chkRandomize.Checked = true;
				}
				else
				{
					FrmItem.Default.chkRandomize.Checked = false;
				}
				
				//If .RandomMin = 0 Then .RandomMin = 1
				//frmEditor_Item.numMin.Value = .RandomMin
				
				//If .RandomMax <= 1 Then .RandomMax = 2
				//frmEditor_Item.numMax.Value = .RandomMax
				
				FrmItem.Default.nudPaperdoll.Value = Types.Item[E_Globals.Editorindex].Paperdoll;
				
				FrmItem.Default.cmbProjectile.SelectedIndex = Types.Item[E_Globals.Editorindex].Projectile;
				FrmItem.Default.cmbAmmo.SelectedIndex = Types.Item[E_Globals.Editorindex].Ammo;
			}
			else
			{
				FrmItem.Default.fraEquipment.Visible = false;
			}
			
			if (FrmItem.Default.cmbType.SelectedIndex == (int) Enums.ItemType.Consumable)
			{
				FrmItem.Default.fraVitals.Visible = true;
				FrmItem.Default.nudVitalMod.Value = Types.Item[E_Globals.Editorindex].Data1;
			}
			else
			{
				FrmItem.Default.fraVitals.Visible = false;
			}
			
			if (FrmItem.Default.cmbType.SelectedIndex == (int) Enums.ItemType.Skill)
			{
				FrmItem.Default.fraSkill.Visible = true;
				FrmItem.Default.cmbSkills.SelectedIndex = Types.Item[E_Globals.Editorindex].Data1;
			}
			else
			{
				FrmItem.Default.fraSkill.Visible = false;
			}
			
			if (FrmItem.Default.cmbType.SelectedIndex == (int) Enums.ItemType.Furniture)
			{
				FrmItem.Default.fraFurniture.Visible = true;
				if (Types.Item[E_Globals.Editorindex].Data2 > 0 && Types.Item[E_Globals.Editorindex].Data2 <= E_Housing.NumFurniture)
				{
					FrmItem.Default.nudFurniture.Value = Types.Item[E_Globals.Editorindex].Data2;
				}
				else
				{
					FrmItem.Default.nudFurniture.Value = 1;
				}
				FrmItem.Default.cmbFurnitureType.SelectedIndex = Types.Item[E_Globals.Editorindex].Data1;
			}
			else
			{
				FrmItem.Default.fraFurniture.Visible = false;
			}
			
			if (FrmItem.Default.cmbType.SelectedIndex == (int) Enums.ItemType.Pet)
			{
				FrmItem.Default.fraPet.Visible = true;
				FrmItem.Default.cmbPet.SelectedIndex = Types.Item[E_Globals.Editorindex].Data1;
			}
			else
			{
				FrmItem.Default.fraPet.Visible = false;
			}
			
			// Basic requirements
			FrmItem.Default.cmbAccessReq.SelectedIndex = Types.Item[E_Globals.Editorindex].AccessReq;
			FrmItem.Default.nudLevelReq.Value = Types.Item[E_Globals.Editorindex].LevelReq;
			
			FrmItem.Default.nudStrReq.Value = Types.Item[E_Globals.Editorindex].Stat_Req[(byte)Enums.StatType.Strength];
			FrmItem.Default.nudVitReq.Value = Types.Item[E_Globals.Editorindex].Stat_Req[(byte)Enums.StatType.Vitality];
			FrmItem.Default.nudLuckReq.Value = Types.Item[E_Globals.Editorindex].Stat_Req[(byte)Enums.StatType.Luck];
			FrmItem.Default.nudEndReq.Value = Types.Item[E_Globals.Editorindex].Stat_Req[(byte)Enums.StatType.Endurance];
			FrmItem.Default.nudIntReq.Value = Types.Item[E_Globals.Editorindex].Stat_Req[(byte)Enums.StatType.Intelligence];
			FrmItem.Default.nudSprReq.Value = Types.Item[E_Globals.Editorindex].Stat_Req[(byte)Enums.StatType.Spirit];
			
			// Build cmbClassReq
			FrmItem.Default.cmbClassReq.Items.Clear();
			FrmItem.Default.cmbClassReq.Items.Add("None");
			
			for (i = 1; i <= E_Globals.Max_Classes; i++)
			{
				FrmItem.Default.cmbClassReq.Items.Add(Types.Classes[i].Name);
			}
			
			FrmItem.Default.cmbClassReq.SelectedIndex = Types.Item[E_Globals.Editorindex].ClassReq;
			// Info
			FrmItem.Default.nudPrice.Value = Types.Item[E_Globals.Editorindex].Price;
			FrmItem.Default.cmbBind.SelectedIndex = Types.Item[E_Globals.Editorindex].BindType;
			FrmItem.Default.nudRarity.Value = Types.Item[E_Globals.Editorindex].Rarity;
			
			if (Types.Item[E_Globals.Editorindex].Stackable == 1)
			{
				FrmItem.Default.chkStackable.Checked = true;
			}
			else
			{
				FrmItem.Default.chkStackable.Checked = false;
			}
			
			E_Globals.Editorindex = FrmItem.Default.lstIndex.SelectedIndex + 1;
			
			FrmItem.Default.nudPic.Maximum = E_Graphics.NumItems;
			
			if (E_Graphics.NumPaperdolls > 0)
			{
				FrmItem.Default.nudPaperdoll.Maximum = E_Graphics.NumPaperdolls + 1;
			}
			
			EditorItem_DrawItem();
			EditorItem_DrawPaperdoll();
			EditorItem_DrawFurniture();
			E_Globals.Item_Changed[E_Globals.Editorindex] = true;
			
		}
		
		internal static void ItemEditorCancel()
		{
			E_Globals.Editor = (byte) 0;
			FrmItem.Default.Visible = false;
			ClearChanged_Item();
			ClearItems();
			SendRequestItems();
		}
		
		internal static void ItemEditorOk()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_ITEMS; i++)
			{
				if (E_Globals.Item_Changed[i])
				{
					SendSaveItem(i);
				}
			}
			
			FrmItem.Default.Visible = false;
			E_Globals.Editor = (byte) 0;
			ClearChanged_Item();
		}
		
#endregion
		
#region Drawing
		
		internal static void CheckItems()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "Items\\" + System.Convert.ToString(i) + E_Globals.GFX_EXT))
			{
				E_Graphics.NumItems++;
				i++;
			}
			
			if (E_Graphics.NumItems == 0)
			{
				return;
			}
		}
		
		internal static void EditorItem_DrawItem()
		{
			int itemnum = 0;
			itemnum = (int) FrmItem.Default.nudPic.Value;
			
			if (itemnum < 1 || itemnum > E_Graphics.NumItems)
			{
				FrmItem.Default.picItem.BackgroundImage = null;
				return;
			}
			
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "items\\" + System.Convert.ToString(itemnum) + E_Globals.GFX_EXT))
			{
				FrmItem.Default.picItem.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "items\\" + System.Convert.ToString(itemnum) + E_Globals.GFX_EXT);
			}
			
		}
		
		internal static void EditorItem_DrawPaperdoll()
		{
			int Sprite = 0;
			
			Sprite = (int) FrmItem.Default.nudPaperdoll.Value;
			
			if (Sprite < 1 || Sprite > E_Graphics.NumPaperdolls)
			{
				FrmItem.Default.picPaperdoll.BackgroundImage = null;
				return;
			}
			
			if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + "paperdolls\\" + System.Convert.ToString(Sprite) + E_Globals.GFX_EXT))
			{
				FrmItem.Default.picPaperdoll.BackgroundImage = System.Drawing.Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + "paperdolls\\" + System.Convert.ToString(Sprite) + E_Globals.GFX_EXT);
			}
		}
		
		internal static void EditorItem_DrawFurniture()
		{
			int Furniturenum = 0;
			Rectangle sRECT = new Rectangle();
			Rectangle dRECT = new Rectangle();
			Furniturenum = (int) FrmItem.Default.nudFurniture.Value;
			
			if (Furniturenum < 1 || Furniturenum > E_Housing.NumFurniture)
			{
				E_Graphics.EditorItem_Furniture.Clear(E_Graphics.ToSFMLColor(FrmItem.Default.picFurniture.BackColor));
				E_Graphics.EditorItem_Furniture.Display();
				return;
			}
			
			if (E_Graphics.FurnitureGFXInfo[Furniturenum].IsLoaded == false)
			{
				E_Graphics.LoadTexture(Furniturenum, (byte) 10);
			}
			
			//seeying we still use it, lets update timer
			E_Graphics.FurnitureGFXInfo[Furniturenum].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
			
			// rect for source
			sRECT.Y = 0;
			sRECT.Height = E_Graphics.FurnitureGFXInfo[Furniturenum].height;
			sRECT.X = 0;
			sRECT.Width = E_Graphics.FurnitureGFXInfo[Furniturenum].width;
			
			// same for destination as source
			dRECT = sRECT;
			
			E_Graphics.EditorItem_Furniture.Clear(E_Graphics.ToSFMLColor(FrmItem.Default.picFurniture.BackColor));
			
			E_Graphics.RenderSprite(E_Graphics.FurnitureSprite[Furniturenum], E_Graphics.EditorItem_Furniture, dRECT.X, dRECT.Y, sRECT.X, sRECT.Y, sRECT.Width, sRECT.Height);
			
			if (FrmItem.Default.optSetBlocks.Checked == true)
			{
				for (var X = 0; X <= 3; X++)
				{
					for (var Y = 0; Y <= 3; Y++)
					{
						if (X <= ((double) E_Graphics.FurnitureGFXInfo[Furniturenum].width / 32) - 1)
						{
							if (Y <= ((double) E_Graphics.FurnitureGFXInfo[Furniturenum].height / 32) - 1)
							{
								if (Types.Item[E_Globals.Editorindex].FurnitureBlocks[(int) X, (int) Y] == 1)
								{
									E_Text.DrawText(System.Convert.ToInt32(X * 32 + 8), System.Convert.ToInt32(Y * 32 + 8), "X", SFML.Graphics.Color.Red, SFML.Graphics.Color.Black, E_Graphics.EditorItem_Furniture);
								}
								else
								{
									E_Text.DrawText(System.Convert.ToInt32(X * 32 + 8), System.Convert.ToInt32(Y * 32 + 8), "O", SFML.Graphics.Color.Blue, SFML.Graphics.Color.Black, E_Graphics.EditorItem_Furniture);
								}
							}
						}
					}
				}
			}
			else if (FrmItem.Default.optSetFringe.Checked == true)
			{
				for (var X = 0; X <= 3; X++)
				{
					for (var Y = 0; Y <= 3; Y++)
					{
						if (X <= ((double) E_Graphics.FurnitureGFXInfo[Furniturenum].width / 32) - 1)
						{
							if (Y <= ((double) E_Graphics.FurnitureGFXInfo[Furniturenum].height / 32))
							{
								if (Types.Item[E_Globals.Editorindex].FurnitureFringe[(int) X, (int) Y] == 1)
								{
									E_Text.DrawText(System.Convert.ToInt32(X * 32 + 8), System.Convert.ToInt32(Y * 32 + 8), "O", SFML.Graphics.Color.Blue, SFML.Graphics.Color.Black, E_Graphics.EditorItem_Furniture);
								}
							}
						}
					}
				}
			}
			E_Graphics.EditorItem_Furniture.Display();
		}
		
#endregion
		
	}
}
