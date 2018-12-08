using ASFW;

namespace Engine
{
    internal static class E_Crafting
    {
        internal static bool[] Recipe_Changed = new bool[101];
        internal static RecipeRec[] Recipe = new RecipeRec[101];
        internal static bool InitRecipeEditor;
        internal static bool InitCrafting;
        internal static bool InCraft;
        internal static bool pnlCraftVisible;

        internal const byte RecipeType_Herb = 0;
        internal const byte RecipeType_Wood = 1;
        internal const byte RecipeType_Metal = 2;

        internal static string[] RecipeNames = new string[101];

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

        internal struct RecipeRec
        {
            public string Name;
            public byte RecipeType;
            public int MakeItemNum;
            public int MakeItemAmount;
            public IngredientsRec[] Ingredients;
            public byte CreateTime;
        }

        internal struct IngredientsRec
        {
            public int ItemNum;
            public int Value;
        }



        public static void ClearRecipes()
        {
            int i;

            for (i = 1; i <= Constants.MAX_RECIPE; i++)
                ClearRecipe(i);
        }

        public static void ClearRecipe(int Num)
        {
            Recipe[Num].Name = "";
            Recipe[Num].RecipeType = 0;
            Recipe[Num].MakeItemNum = 0;
            Recipe[Num].Ingredients = new IngredientsRec[Constants.MAX_INGREDIENT + 1];
        }

        internal static void ClearChanged_Recipe()
        {
            int i;

            for (i = 1; i <= Constants.MAX_RECIPE; i++)
                Recipe_Changed[i] = default(bool);

            Recipe_Changed = new bool[101];
        }



        internal static void RecipeEditorPreInit()
        {
            int i;

            {
                var withBlock = My.MyProject.Forms.FrmRecipe;
                E_Globals.Editor = E_Globals.EDITOR_RECIPE;
                withBlock.lstIndex.Items.Clear();

                // Add the names
                for (i = 1; i <= Constants.MAX_RECIPE; i++)
                    withBlock.lstIndex.Items.Add(i + ": " + Microsoft.VisualBasic.Strings.Trim(Recipe[i].Name));

                // fill comboboxes
                withBlock.cmbMakeItem.Items.Clear();
                withBlock.cmbIngredient.Items.Clear();

                withBlock.cmbMakeItem.Items.Add("None");
                withBlock.cmbIngredient.Items.Add("None");
                for (i = 1; i <= Constants.MAX_ITEMS; i++)
                {
                    withBlock.cmbMakeItem.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Item[i].Name));
                    withBlock.cmbIngredient.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Item[i].Name));
                }

                withBlock.Show();
                withBlock.lstIndex.SelectedIndex = 0;
                RecipeEditorInit();
            }
        }

        internal static void RecipeEditorInit()
        {
            if (My.MyProject.Forms.FrmRecipe.Visible == false)
                return;
            E_Globals.Editorindex = My.MyProject.Forms.FrmRecipe.lstIndex.SelectedIndex + 1;

            {
                var withBlock = Recipe[E_Globals.Editorindex];
                My.MyProject.Forms.FrmRecipe.txtName.Text = Microsoft.VisualBasic.Strings.Trim(withBlock.Name);

                My.MyProject.Forms.FrmRecipe.lstIngredients.Items.Clear();

                My.MyProject.Forms.FrmRecipe.cmbType.SelectedIndex = withBlock.RecipeType;
                My.MyProject.Forms.FrmRecipe.cmbMakeItem.SelectedIndex = withBlock.MakeItemNum;

                if (withBlock.MakeItemAmount < 1)
                    withBlock.MakeItemAmount = 1;
                My.MyProject.Forms.FrmRecipe.nudAmount.Value = withBlock.MakeItemAmount;

                if (withBlock.CreateTime < 1)
                    withBlock.CreateTime = 1;
                My.MyProject.Forms.FrmRecipe.nudCreateTime.Value = withBlock.CreateTime;

                UpdateIngredient();
            }

            Recipe_Changed[E_Globals.Editorindex] = true;
        }

        internal static void RecipeEditorCancel()
        {
            E_Globals.Editor = 0;
            My.MyProject.Forms.FrmRecipe.Visible = false;
            ClearChanged_Recipe();
            ClearRecipes();
            SendRequestRecipes();
        }

        internal static void RecipeEditorOk()
        {
            int i;

            for (i = 1; i <= Constants.MAX_RECIPE; i++)
            {
                if (Recipe_Changed[i])
                    SendSaveRecipe(i);
            }

            My.MyProject.Forms.FrmRecipe.Visible = false;
            E_Globals.Editor = 0;
            ClearChanged_Recipe();
        }

        internal static void UpdateIngredient()
        {
            int i;
            My.MyProject.Forms.FrmRecipe.lstIngredients.Items.Clear();

            for (i = 1; i <= Constants.MAX_INGREDIENT; i++)
            {
                {
                    var withBlock = Recipe[E_Globals.Editorindex].Ingredients[i];
                    // if none, show as none
                    if (withBlock.ItemNum <= 0 && withBlock.Value == 0)
                        My.MyProject.Forms.FrmRecipe.lstIngredients.Items.Add("Empty");
                    else
                        My.MyProject.Forms.FrmRecipe.lstIngredients.Items.Add(Microsoft.VisualBasic.Strings.Trim(Types.Item[withBlock.ItemNum].Name) + " X " + withBlock.Value);
                }
            }

            My.MyProject.Forms.FrmRecipe.lstIngredients.SelectedIndex = 0;
        }



        public static void Packet_UpdateRecipe(ref byte[] data)
        {
            int n;
            int i;
            ByteStream buffer = new ByteStream(data);
            // recipe index
            n = buffer.ReadInt32();

            // Update the Recipe
            Recipe[n].Name = buffer.ReadString();
            Recipe[n].RecipeType = (byte)buffer.ReadInt32();
            Recipe[n].MakeItemNum = buffer.ReadInt32();
            Recipe[n].MakeItemAmount = buffer.ReadInt32();

            for (i = 1; i <= Constants.MAX_INGREDIENT; i++)
            {
                Recipe[n].Ingredients[i].ItemNum = buffer.ReadInt32();
                Recipe[n].Ingredients[i].Value = buffer.ReadInt32();
            }

            Recipe[n].CreateTime = (byte)buffer.ReadInt32();

            buffer.Dispose();
        }

        public static void Packet_RecipeEditor(ref byte[] data)
        {
            InitRecipeEditor = true;
        }



        public static void SendRequestRecipes()
        {
            ByteStream buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.ClientPackets.CRequestRecipes);

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendRequestEditRecipes()
        {
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.RequestEditRecipes);

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }

        public static void SendSaveRecipe(int RecipeNum)
        {
            ByteStream buffer;
            buffer = new ByteStream(4);

            buffer.WriteInt32((int)Packets.EditorPackets.SaveRecipe);

            buffer.WriteInt32(RecipeNum);

            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Recipe[RecipeNum].Name)));
            buffer.WriteInt32(Recipe[RecipeNum].RecipeType);
            buffer.WriteInt32(Recipe[RecipeNum].MakeItemNum);
            buffer.WriteInt32(Recipe[RecipeNum].MakeItemAmount);

            for (var i = 1; i <= Constants.MAX_INGREDIENT; i++)
            {
                buffer.WriteInt32(Recipe[RecipeNum].Ingredients[i].ItemNum);
                buffer.WriteInt32(Recipe[RecipeNum].Ingredients[i].Value);
            }

            buffer.WriteInt32(Recipe[RecipeNum].CreateTime);

            E_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
            buffer.Dispose();
        }



        public static int GetRecipeIndex(string RecipeName)
        {
            int i;

            int GetRecipeIndex = 0;

            for (i = 1; i <= Constants.MAX_RECIPE; i++)
            {
                if (Microsoft.VisualBasic.Strings.Trim(Recipe[i].Name) == Microsoft.VisualBasic.Strings.Trim(RecipeName))
                {
                    GetRecipeIndex = i;
                    break;
                }
            }
            return GetRecipeIndex;
        }
    }
}
