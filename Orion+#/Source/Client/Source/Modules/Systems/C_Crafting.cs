
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using Asfw;
using Engine;


namespace Engine
{
	internal sealed class C_Crafting
	{
		
#region Globals & Types
		
		internal static bool[] RecipeChanged = new bool[Constants.MAX_RECIPE + 1];
		internal static RecipeRec[] Recipe = new RecipeRec[Constants.MAX_RECIPE + 1];
		internal static bool InitRecipeEditor;
		internal static bool InitCrafting;
		internal static bool InCraft;
		internal static bool PnlCraftVisible;
		
		internal const byte RecipeTypeHerb = 0;
		internal const byte RecipeTypeWood = 1;
		internal const byte RecipeTypeMetal = 2;
		
		internal static string[] RecipeNames = new string[Constants.MAX_RECIPE + 1];
		
		internal static bool ChkKnownOnlyChecked;
		internal static bool ChkKnownOnlyEnabled;
		internal static bool BtnCraftEnabled;
		internal static bool BtnCraftStopEnabled;
		internal static bool NudCraftAmountEnabled;
		internal static bool LstRecipeEnabled;
		
		internal static byte CraftAmountValue;
		internal static int CraftProgressValue;
		internal static int PicProductindex;
		internal static string LblProductNameText;
		internal static string LblProductAmountText;
		
		internal static int[] PicMaterialIndex = new int[Constants.MAX_INGREDIENT + 1];
		internal static string[] LblMaterialName = new string[Constants.MAX_INGREDIENT + 1];
		internal static string[] LblMaterialAmount = new string[Constants.MAX_INGREDIENT + 1];
		
		internal static int SelectedRecipe = 0;
		
		internal static bool CraftTimerEnabled;
		internal static int CraftTimer;
		
		public struct RecipeRec
		{
			public string Name;
			public byte RecipeType;
			public int MakeItemNum;
			public int MakeItemAmount;
			public IngredientsRec[] Ingredients;
			public byte CreateTime;
		}
		
		public struct IngredientsRec
		{
			public int ItemNum;
			public int Value;
		}
		
#endregion
		
#region Database
		
		public static void ClearRecipes()
		{
			int i = 0;
			
			Recipe = new C_Crafting.RecipeRec[Constants.MAX_RECIPE + 1];
			
			for (i = 1; i <= Constants.MAX_RECIPE; i++)
			{
				ClearRecipe(i);
			}
			
		}
		
		public static void ClearRecipe(int num)
		{
			Recipe[num].Name = "";
			Recipe[num].RecipeType = (byte) 0;
			Recipe[num].MakeItemNum = 0;
			Recipe[num].Ingredients = new C_Crafting.IngredientsRec[Constants.MAX_INGREDIENT + 1];
		}
		
		internal static void ClearChanged_Recipe()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_RECIPE; i++)
			{
				RecipeChanged[i] = false;
			}
			
			RecipeChanged = new bool[Constants.MAX_RECIPE + 1];
		}
		
#endregion
		
#region Incoming Packets
		
		public static void Packet_UpdateRecipe(ref byte[] data)
		{
			int n = 0;
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			//recipe index
			n = buffer.ReadInt32();
			
			// Update the Recipe
			Recipe[n].Name = buffer.ReadString().Trim();
			Recipe[n].RecipeType = (byte) (buffer.ReadInt32());
			Recipe[n].MakeItemNum = buffer.ReadInt32();
			Recipe[n].MakeItemAmount = buffer.ReadInt32();
			
			for (i = 1; i <= Constants.MAX_INGREDIENT; i++)
			{
				Recipe[n].Ingredients[i].ItemNum = buffer.ReadInt32();
				Recipe[n].Ingredients[i].Value = buffer.ReadInt32();
			}
			
			Recipe[n].CreateTime = (byte) (buffer.ReadInt32());
			
			buffer.Dispose();
			
		}
		
		public static void Packet_RecipeEditor(ref byte[] data)
		{
			InitRecipeEditor = true;
		}
		
		public static void Packet_SendPlayerRecipe(ref byte[] data)
		{
			int i = 0;
			ByteStream buffer = new ByteStream(data);
			for (i = 1; i <= Constants.MAX_RECIPE; i++)
			{
				C_Types.Player[C_Variables.Myindex].RecipeLearned[i] = (byte)buffer.ReadInt32();
			}
			
			buffer.Dispose();
		}
		
		public static void Packet_OpenCraft(ref byte[] data)
		{
			InitCrafting = true;
		}
		
		public static void Packet_UpdateCraft(ref byte[] data)
		{
			byte done;
			ByteStream buffer = new ByteStream(data);
			done = (byte) (buffer.ReadInt32());
			
			if (done == 1)
			{
				InitCrafting = true;
			}
			else
			{
				CraftProgressValue = 0;
				CraftTimerEnabled = true;
			}
			
			buffer.Dispose();
		}
		
#endregion
		
#region OutGoing Packets
		
		public static void SendRequestRecipes()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestRecipes);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendRequestEditRecipes()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.RequestEditRecipes);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendSaveRecipe(int recipeNum)
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.SaveRecipe);
			
			buffer.WriteInt32(recipeNum);
			
			buffer.WriteString(Microsoft.VisualBasic.Strings.Trim(Recipe[recipeNum].Name));
			buffer.WriteInt32(Recipe[recipeNum].RecipeType);
			buffer.WriteInt32(Recipe[recipeNum].MakeItemNum);
			buffer.WriteInt32(Recipe[recipeNum].MakeItemAmount);
			
			for (var i = 1; i <= Constants.MAX_INGREDIENT; i++)
			{
				buffer.WriteInt32(Recipe[recipeNum].Ingredients[(int) i].ItemNum);
				buffer.WriteInt32(Recipe[recipeNum].Ingredients[(int) i].Value);
			}
			
			buffer.WriteInt32(Recipe[recipeNum].CreateTime);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		internal static void SendCraftIt(string recipeName, int amount)
		{
			ByteStream buffer = new ByteStream(4);
			int i = 0;
			int recipeindex = 0;
			
			recipeindex = GetRecipeIndex(recipeName);
			
			if (recipeindex <= 0)
			{
				return;
			}
			
			//check,check, double check
			
			//we dont even know the damn recipe xD
			if (C_Types.Player[C_Variables.Myindex].RecipeLearned[recipeindex] == 0)
			{
				return;
			}
			
			//enough ingredients
			for (i = 1; i <= Constants.MAX_INGREDIENT; i++)
			{
				if (Recipe[recipeindex].Ingredients[i].ItemNum > 0 && C_Quest.HasItem(C_Variables.Myindex, Recipe[recipeindex].Ingredients[i].ItemNum) < (amount * Recipe[recipeindex].Ingredients[i].Value))
				{
					C_Text.AddText(Strings.Get("crafting", "notenough"), (System.Int32) Enums.ColorType.Red);
					return;
				}
			}
			
			//all seems fine...
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CStartCraft);
			
			buffer.WriteInt32(recipeindex);
			buffer.WriteInt32(amount);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
			
			CraftTimer = C_General.GetTickCount();
			CraftTimerEnabled = true;
			
			BtnCraftEnabled = false;
			BtnCraftStopEnabled = false;
			BtnCraftStopEnabled = false;
			NudCraftAmountEnabled = false;
			LstRecipeEnabled = false;
			ChkKnownOnlyEnabled = false;
		}
		
		public static void SendCloseCraft()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CCloseCraft);
			
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
		}
		
#endregion
		
#region Functions
		
		internal static void CraftingInit()
		{
			int i = 0;
			int x = 0;
			
			x = 1;
			
			for (i = 1; i <= Constants.MAX_RECIPE; i++)
			{
				if (ChkKnownOnlyChecked == true)
				{
					if (C_Types.Player[C_Variables.Myindex].RecipeLearned[i] == 1)
					{
						RecipeNames[x] = Microsoft.VisualBasic.Strings.Trim(Recipe[i].Name);
						x++;
					}
				}
				else
				{
					if (Microsoft.VisualBasic.Strings.Trim(Recipe[i].Name).Length > 0)
					{
						RecipeNames[x] = Microsoft.VisualBasic.Strings.Trim(Recipe[i].Name);
						x++;
					}
				}
			}
			
			CraftAmountValue = (byte) 1;
			
			InCraft = true;
			
			LoadRecipe(RecipeNames[SelectedRecipe]);
			
			PnlCraftVisible = true;
		}
		
		public static void LoadRecipe(string recipeName)
		{
			int recipeindex = 0;
			
			recipeindex = GetRecipeIndex(recipeName);
			
			if (recipeindex <= 0)
			{
				return;
			}
			
			PicProductindex = Types.Item[Recipe[recipeindex].MakeItemNum].Pic;
			LblProductNameText = Types.Item[Recipe[recipeindex].MakeItemNum].Name;
			LblProductAmountText = "X 1";
			
			for (var i = 1; i <= Constants.MAX_INGREDIENT; i++)
			{
				if (Recipe[recipeindex].Ingredients[(int) i].ItemNum > 0)
				{
					PicMaterialIndex[(int) i] = Types.Item[Recipe[recipeindex].Ingredients[(int) i].ItemNum].Pic;
					LblMaterialName[(int) i] = Types.Item[Recipe[recipeindex].Ingredients[(int) i].ItemNum].Name;
					LblMaterialAmount[(int) i] = "X " + System.Convert.ToString(C_Quest.HasItem(C_Variables.Myindex, Recipe[recipeindex].Ingredients[(int) i].ItemNum)) + "/" + System.Convert.ToString(Recipe[recipeindex].Ingredients[(int) i].Value);
				}
				else
				{
					PicMaterialIndex[(int) i] = 0;
					LblMaterialName[(int) i] = "";
					LblMaterialAmount[(int) i] = "";
				}
			}
			
		}
		
		public static int GetRecipeIndex(string recipeName)
		{
			int returnValue = 0;
			int i = 0;
			
            if(recipeName == null)
            {
                return 0;
            }

			for (i = 1; i <= Constants.MAX_RECIPE; i++)
			{
				if (Recipe[i].Name != null && Recipe[i].Name.Trim() == recipeName.Trim())
				{
					returnValue = i;
					break;
				}
			}
			
			return returnValue;
		}
		
		internal static void DrawCraftPanel()
		{
			int i = 0;
			int y = 0;
			Rectangle rec = new Rectangle();
			int pgbvalue = 0;

            for (i = 1; i <= Constants.MAX_RECIPE; i++)
            {
                if (RecipeNames[i] == null)
                {
                    RecipeNames[i] = "";
                }
            }

            //first render panel
            C_Graphics.RenderSprite(C_Graphics.CraftSprite, C_Graphics.GameWindow, C_UpdateUI.CraftPanelX, C_UpdateUI.CraftPanelY, 0, 0, C_Graphics.CraftGfxInfo.Width, C_Graphics.CraftGfxInfo.Height);
			
			y = 10;
			
			//draw recipe names
			for (i = 1; i <= Constants.MAX_RECIPE; i++)
			{
				if (RecipeNames[i].Trim().Length > 0)
				{
                    C_Text.DrawText(C_UpdateUI.CraftPanelX + 12, C_UpdateUI.CraftPanelY + y, RecipeNames[i].Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
                    y = y + 20;
				}
			}
			
			//progress bar
			pgbvalue = (int)(((double) CraftProgressValue / 100) * 100);
			
			rec.Y = 0;
			rec.Height = C_Graphics.ProgBarGfxInfo.Height;
			rec.X = 0;
			rec.Width = (int)((double) pgbvalue * C_Graphics.ProgBarGfxInfo.Width / 100);
			
			C_Graphics.RenderSprite(C_Graphics.ProgBarSprite, C_Graphics.GameWindow, C_UpdateUI.CraftPanelX + 410, C_UpdateUI.CraftPanelY + 417, rec.X, rec.Y, rec.Width, rec.Height);
			
			//amount controls
			C_Graphics.RenderSprite(C_Graphics.CharPanelMinSprite, C_Graphics.GameWindow, C_UpdateUI.CraftPanelX + 340, C_UpdateUI.CraftPanelY + 422, 0, 0, C_Graphics.CharPanelMinGfxInfo.Width, C_Graphics.CharPanelMinGfxInfo.Height);
			
			C_Text.DrawText(C_UpdateUI.CraftPanelX + 367, C_UpdateUI.CraftPanelY + 418, Microsoft.VisualBasic.Strings.Trim(CraftAmountValue.ToString()), SFML.Graphics.Color.Black, SFML.Graphics.Color.White, C_Graphics.GameWindow);
			
			C_Graphics.RenderSprite(C_Graphics.CharPanelPlusSprite, C_Graphics.GameWindow, C_UpdateUI.CraftPanelX + 392, C_UpdateUI.CraftPanelY + 422, 0, 0, C_Graphics.CharPanelPlusGfxInfo.Width, C_Graphics.CharPanelPlusGfxInfo.Height);
			
			if (SelectedRecipe == 0)
			{
				return;
			}
			
			if (PicProductindex > 0)
			{
				if (C_Graphics.ItemsGfxInfo[PicProductindex].IsLoaded == false)
				{
					C_Graphics.LoadTexture(PicProductindex, (byte) 4);
				}

                //seeying we still use it, lets update timer
                C_Graphics.ItemsGfxInfo[PicProductindex].TextureTimer = C_General.GetTickCount() + 100000;
				
				C_Graphics.RenderSprite(C_Graphics.ItemsSprite[PicProductindex], C_Graphics.GameWindow, C_UpdateUI.CraftPanelX + 267, C_UpdateUI.CraftPanelY + 20, 0, 0, C_Graphics.ItemsGfxInfo[PicProductindex].Width, C_Graphics.ItemsGfxInfo[PicProductindex].Height);
				
				C_Text.DrawText(C_UpdateUI.CraftPanelX + 310, C_UpdateUI.CraftPanelY + 20, LblProductNameText.Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
				
				C_Text.DrawText(C_UpdateUI.CraftPanelX + 310, C_UpdateUI.CraftPanelY + 35, LblProductAmountText.Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
			}
			
			y = 107;
			
			for (i = 1; i <= Constants.MAX_INGREDIENT; i++)
			{
				if (PicMaterialIndex[i] > 0)
				{
					if (C_Graphics.ItemsGfxInfo[PicMaterialIndex[i]].IsLoaded == false)
					{
						C_Graphics.LoadTexture(PicMaterialIndex[i], (byte) 4);
					}
					
					//seeying we still use it, lets update timer
					ref var with_3 = ref C_Graphics.ItemsGfxInfo[PicMaterialIndex[i]];
					with_3.TextureTimer = C_General.GetTickCount() + 100000;
					
					C_Graphics.RenderSprite(C_Graphics.ItemsSprite[PicMaterialIndex[i]], C_Graphics.GameWindow, C_UpdateUI.CraftPanelX + 275, C_UpdateUI.CraftPanelY + y, 0, 0, C_Graphics.ItemsGfxInfo[PicMaterialIndex[i]].Width, C_Graphics.ItemsGfxInfo[PicMaterialIndex[i]].Height);
					
					C_Text.DrawText(C_UpdateUI.CraftPanelX + 315, C_UpdateUI.CraftPanelY + y, LblMaterialName[i].Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
					
					C_Text.DrawText(C_UpdateUI.CraftPanelX + 315, C_UpdateUI.CraftPanelY + y + 15, LblMaterialAmount[i].Trim(), SFML.Graphics.Color.White, SFML.Graphics.Color.Black, C_Graphics.GameWindow);
					
					y = y + 63;
				}
			}
			
		}
		
		internal static void ResetCraftPanel()
		{
			//reset the panel's info
			RecipeNames = new string[Constants.MAX_RECIPE + 1];
			
			for (var i = 1; i <= Constants.MAX_RECIPE; i++)
			{
				RecipeNames[i] = "";
			}
			
			CraftProgressValue = 0;
			
			CraftAmountValue = 1;
			
			PicProductindex = 0;
			LblProductNameText = Strings.Get("crafting", "noneselected");
			LblProductAmountText = "0";
			
			for (var i = 1; i <= Constants.MAX_INGREDIENT; i++)
			{
				PicMaterialIndex[i] = 0;
				LblMaterialName[i] = "";
				LblMaterialAmount[i] = "";
			}
			
			CraftTimerEnabled = false;
			
			BtnCraftEnabled = true;
			BtnCraftStopEnabled = true;
			NudCraftAmountEnabled = true;
			LstRecipeEnabled = true;
			ChkKnownOnlyEnabled = true;
			
			SelectedRecipe = 0;
		}
		
#endregion
		
	}
}
