
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using ASFW;
using Engine;


namespace Engine
{
	internal sealed class E_Crafting
	{
		
#region Globals
		
		internal static bool[] Recipe_Changed = new bool[Constants.MAX_RECIPE + 1];
		internal static RecipeRec[] Recipe = new RecipeRec[Constants.MAX_RECIPE + 1];
		internal static bool InitRecipeEditor;
		internal static bool InitCrafting;
		internal static bool InCraft;
		internal static bool pnlCraftVisible;
		
		internal const byte RecipeType_Herb = 0;
		internal const byte RecipeType_Wood = 1;
		internal const byte RecipeType_Metal = 2;
		
		internal static string[] RecipeNames = new string[Constants.MAX_RECIPE + 1];
		
		internal static bool chkKnownOnlyChecked;
		internal static bool chkKnownOnlyEnabled;
		internal static bool btnCraftEnabled;
		internal static bool btnCraftStopEnabled;
		internal static bool nudCraftAmountEnabled;
		internal static bool lstRecipeEnabled;
		
		internal static byte CraftAmountValue;
		internal static int CraftProgressValue;
		internal static int picProductindex;
		internal static string lblProductNameText;
		internal static string lblProductAmountText;
		
		internal static int[] picMaterialIndex = new int[Constants.MAX_INGREDIENT + 1];
		internal static string[] lblMaterialName = new string[Constants.MAX_INGREDIENT + 1];
		internal static string[] lblMaterialAmount = new string[Constants.MAX_INGREDIENT + 1];
		
		internal static int SelectedRecipe = 0;
		
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
			
			for (i = 1; i <= Constants.MAX_RECIPE; i++)
			{
				ClearRecipe(i);
			}
			
		}
		
		public static void ClearRecipe(int Num)
		{
			Recipe[Num].Name = "";
			Recipe[Num].RecipeType = (byte) 0;
			Recipe[Num].MakeItemNum = 0;
			Recipe[Num].Ingredients = new E_Crafting.IngredientsRec[Constants.MAX_INGREDIENT + 1];
		}
		
		internal static void ClearChanged_Recipe()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_RECIPE; i++)
			{
				Recipe_Changed[i] = false;
			}
			
			Recipe_Changed = new bool[Constants.MAX_RECIPE + 1];
		}
		
#endregion
		
#region Editor
		
		internal static void RecipeEditorPreInit()
		{
			int i = 0;
			
			E_Globals.Editor = E_Globals.EDITOR_RECIPE;
			FrmRecipe.Default.lstIndex.Items.Clear();
			
			// Add the names
			for (i = 1; i <= Constants.MAX_RECIPE; i++)
			{
                if(Recipe[i].Name != null)
                {
                    FrmRecipe.Default.lstIndex.Items.Add(i + ": " + Recipe[i].Name.Trim());
                }
                else
                {
                    FrmRecipe.Default.lstIndex.Items.Add(i + ": " + "Null");
                }
			}
			
			//fill comboboxes
			FrmRecipe.Default.cmbMakeItem.Items.Clear();
			FrmRecipe.Default.cmbIngredient.Items.Clear();
			
			FrmRecipe.Default.cmbMakeItem.Items.Add("None");
			FrmRecipe.Default.cmbIngredient.Items.Add("None");
			for (i = 1; i <= Constants.MAX_ITEMS; i++)
			{
                if (Types.Item[i].Name != null)
                {
                    FrmRecipe.Default.cmbMakeItem.Items.Add(Types.Item[i].Name.Trim());
                    FrmRecipe.Default.cmbIngredient.Items.Add(Types.Item[i].Name.Trim());
                }
                else
                {
                    FrmRecipe.Default.cmbMakeItem.Items.Add("Null");
                    FrmRecipe.Default.cmbIngredient.Items.Add("Null");
                }
			}
			
			FrmRecipe.Default.Show();
			FrmRecipe.Default.lstIndex.SelectedIndex = 0;
			RecipeEditorInit();
		}
		
		internal static void RecipeEditorInit()
		{
			
			if (FrmRecipe.Default.Visible == false)
			{
				return;
			}
			E_Globals.Editorindex = FrmRecipe.Default.lstIndex.SelectedIndex + 1;
			
            if(Recipe[E_Globals.Editorindex].Name == null) { return; }

			FrmRecipe.Default.txtName.Text = Recipe[E_Globals.Editorindex].Name.Trim();
			
			FrmRecipe.Default.lstIngredients.Items.Clear();
			
			FrmRecipe.Default.cmbType.SelectedIndex = Recipe[E_Globals.Editorindex].RecipeType;
			FrmRecipe.Default.cmbMakeItem.SelectedIndex = Recipe[E_Globals.Editorindex].MakeItemNum;
			
			if (Recipe[E_Globals.Editorindex].MakeItemAmount < 1)
			{
                Recipe[E_Globals.Editorindex].MakeItemAmount = 1;
			}
			FrmRecipe.Default.nudAmount.Value = Recipe[E_Globals.Editorindex].MakeItemAmount;
			
			if (Recipe[E_Globals.Editorindex].CreateTime < 1)
			{
                Recipe[E_Globals.Editorindex].CreateTime = (byte) 1;
			}
			FrmRecipe.Default.nudCreateTime.Value = Recipe[E_Globals.Editorindex].CreateTime;
			
			UpdateIngredient();
			
			Recipe_Changed[E_Globals.Editorindex] = true;
			
		}
		
		internal static void RecipeEditorCancel()
		{
			E_Globals.Editor = (byte) 0;
			FrmRecipe.Default.Visible = false;
			ClearChanged_Recipe();
			ClearRecipes();
			SendRequestRecipes();
		}
		
		internal static void RecipeEditorOk()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_RECIPE; i++)
			{
				if (Recipe_Changed[i])
				{
					SendSaveRecipe(i);
				}
			}
			
			FrmRecipe.Default.Visible = false;
			E_Globals.Editor = (byte) 0;
			ClearChanged_Recipe();
		}
		
		internal static void UpdateIngredient()
		{
			int i = 0;
			FrmRecipe.Default.lstIngredients.Items.Clear();
			
			for (i = 1; i <= Constants.MAX_INGREDIENT; i++)
			{
				// if none, show as none
				if (Recipe[E_Globals.Editorindex].Ingredients[i].ItemNum <= 0 && Recipe[E_Globals.Editorindex].Ingredients[i].Value == 0)
				{
					FrmRecipe.Default.lstIngredients.Items.Add("Empty");
				}
				else
				{
                    if (Types.Item[Recipe[E_Globals.Editorindex].Ingredients[i].ItemNum].Name != null)
                    {
                        FrmRecipe.Default.lstIngredients.Items.Add(Types.Item[Recipe[E_Globals.Editorindex].Ingredients[i].ItemNum].Name.Trim() + " X " + System.Convert.ToString(Recipe[E_Globals.Editorindex].Ingredients[i].Value));
                    }
                    else
                    {
                        FrmRecipe.Default.lstIngredients.Items.Add("Null" + " X " + System.Convert.ToString(Recipe[E_Globals.Editorindex].Ingredients[i].Value));
                    }
				}
				
			}
			
			FrmRecipe.Default.lstIngredients.SelectedIndex = 0;
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
			Recipe[n].Name = buffer.ReadString();
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
		
#endregion
		
#region OutGoing Packets
		
		public static void SendRequestRecipes()
		{
			ByteStream buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CRequestRecipes);
			
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendRequestEditRecipes()
		{
			ByteStream buffer = new ByteStream();
			buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.RequestEditRecipes);
			
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
		public static void SendSaveRecipe(int RecipeNum)
		{
			ByteStream buffer = new ByteStream();
			buffer = new ByteStream(4);
			
			buffer.WriteInt32((System.Int32) Packets.EditorPackets.SaveRecipe);
			
			buffer.WriteInt32(RecipeNum);
			
			buffer.WriteString(Recipe[RecipeNum].Name.Trim());
			buffer.WriteInt32(Recipe[RecipeNum].RecipeType);
			buffer.WriteInt32(Recipe[RecipeNum].MakeItemNum);
			buffer.WriteInt32(Recipe[RecipeNum].MakeItemAmount);
			
			for (var i = 1; i <= Constants.MAX_INGREDIENT; i++)
			{
				buffer.WriteInt32(Recipe[RecipeNum].Ingredients[(int) i].ItemNum);
				buffer.WriteInt32(Recipe[RecipeNum].Ingredients[(int) i].Value);
			}
			
			buffer.WriteInt32(Recipe[RecipeNum].CreateTime);
			
			E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			buffer.Dispose();
		}
		
#endregion
		
#region Functions
		
		public static int GetRecipeIndex(string RecipeName)
		{
			int returnValue = 0;
			int i = 0;
			
			returnValue = 0;
			
			for (i = 1; i <= Constants.MAX_RECIPE; i++)
			{
				if (Recipe[i].Name != null && Recipe[i].Name.Trim() == RecipeName.Trim())
				{
					returnValue = i;
					break;
				}
			}
			
			return returnValue;
		}
		
#endregion
		
	}
}
