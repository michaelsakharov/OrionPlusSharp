using System.Windows.Forms;
using System.IO;
using ASFW;
using ASFW.IO.FileIO;

namespace Engine
{
    internal static class modCrafting
    {
        internal static RecipeRec[] Recipe = new RecipeRec[101];

        internal const byte RecipeType_Herb = 0;
        internal const byte RecipeType_Wood = 1;
        internal const byte RecipeType_Metal = 2;

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



        public static void CheckRecipes()
        {
            int i;

            for (i = 1; i <= Constants.MAX_RECIPE; i++)
            {
                if (!File.Exists(Path.Combine(Application.StartupPath, "data", "recipes", string.Format("recipe{0}.dat", i))))
                {
                    SaveRecipe(i);
                    //Application.DoEvents();
                }
            }
        }

        public static void SaveRecipes()
        {
            int i;

            for (i = 1; i <= Constants.MAX_RECIPE; i++)
            {
                SaveRecipe(i);
                //Application.DoEvents();
            }
        }

        public static void SaveRecipe(int RecipeNum)
        {
            string filename;
            int i;

            filename = Path.Combine(Application.StartupPath, "data", "recipes", string.Format("recipe{0}.dat", RecipeNum));

            ByteStream writer = new ByteStream(100);

            writer.WriteString(Recipe[RecipeNum].Name);
            writer.WriteByte(Recipe[RecipeNum].RecipeType);
            writer.WriteInt32(Recipe[RecipeNum].MakeItemNum);
            writer.WriteInt32(Recipe[RecipeNum].MakeItemAmount);

            for (i = 1; i <= Constants.MAX_INGREDIENT; i++)
            {
                writer.WriteInt32(Recipe[RecipeNum].Ingredients[i].ItemNum);
                writer.WriteInt32(Recipe[RecipeNum].Ingredients[i].Value);
            }

            writer.WriteByte(Recipe[RecipeNum].CreateTime);

            BinaryFile.Save(filename, ref writer);
        }

        public static void LoadRecipes()
        {
            int i;

            for (i = 1; i <= Constants.MAX_RECIPE; i++)
            {
                LoadRecipe(i);
                //Application.DoEvents();
            }
        }

        public static void LoadRecipe(int RecipeNum)
        {
            string filename;
            int i;

            CheckRecipes();

            filename = Path.Combine(Application.StartupPath, "data", "recipes", string.Format("recipe{0}.dat", RecipeNum));
            ByteStream reader = new ByteStream();
            BinaryFile.Load(filename, ref reader);

            Recipe[RecipeNum].Name = reader.ReadString();
            Recipe[RecipeNum].RecipeType = reader.ReadByte();
            Recipe[RecipeNum].MakeItemNum = reader.ReadInt32();
            Recipe[RecipeNum].MakeItemAmount = reader.ReadInt32();

            Recipe[RecipeNum].Ingredients = new IngredientsRec[Constants.MAX_INGREDIENT + 1];
            for (i = 1; i <= Constants.MAX_INGREDIENT; i++)
            {
                Recipe[RecipeNum].Ingredients[i].ItemNum = reader.ReadInt32();
                Recipe[RecipeNum].Ingredients[i].Value = reader.ReadInt32();
            }

            Recipe[RecipeNum].CreateTime = reader.ReadByte();
        }

        public static void ClearRecipes()
        {
            int i;

            for (i = 1; i <= Constants.MAX_RECIPE; i++)
            {
                ClearRecipe(i);
                //Application.DoEvents();
            }
        }

        public static void ClearRecipe(int Num)
        {
            Recipe[Num].Name = "";
            Recipe[Num].RecipeType = 0;
            Recipe[Num].MakeItemNum = 0;
            Recipe[Num].MakeItemAmount = 0;
            Recipe[Num].CreateTime = 0;
            Recipe[Num].Ingredients = new IngredientsRec[Constants.MAX_INGREDIENT + 1];
        }



        public static void Packet_RequestRecipes(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CRequestRecipes");

            SendRecipes(index);
        }

        public static void Packet_RequestEditRecipes(int index, ref byte[] data)
        {
            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (int)Enums.AdminType.Developer)
                return;

            var Buffer = new ByteStream(4);
            Buffer.WriteInt32((int)Packets.ServerPackets.SRecipeEditor);
            S_NetworkConfig.Socket.SendDataTo(index, Buffer.Data, Buffer.Head);

            S_General.AddDebug("Sent SMSG: SRecipeEditor");

            Buffer.Dispose();
        }

        public static void Packet_SaveRecipe(int index, ref byte[] data)
        {
            int n;

            // Prevent hacking
            if (S_Players.GetPlayerAccess(index) < (int)Enums.AdminType.Developer)
                return;
            ByteStream buffer = new ByteStream(data);
            S_General.AddDebug("Recieved EMSG: SaveRecipe");

            // recipe index
            n = buffer.ReadInt32();

            // Update the Recipe
            Recipe[n].Name = buffer.ReadString();
            Recipe[n].RecipeType = (byte)buffer.ReadInt32();
            Recipe[n].MakeItemNum = buffer.ReadInt32();
            Recipe[n].MakeItemAmount = buffer.ReadInt32();

            for (var i = 1; i <= Constants.MAX_INGREDIENT; i++)
            {
                Recipe[n].Ingredients[i].ItemNum = buffer.ReadInt32();
                Recipe[n].Ingredients[i].Value = buffer.ReadInt32();
            }

            Recipe[n].CreateTime = (byte)buffer.ReadInt32();

            // save
            SaveRecipe(n);

            // send to all
            SendUpdateRecipeToAll(n);

            buffer.Dispose();
        }

        public static void Packet_CloseCraft(int index, ref byte[] data)
        {
            S_General.AddDebug("Recieved CMSG: CCloseCraft");

            modTypes.TempPlayer[index].IsCrafting = false;
        }

        public static void Packet_StartCraft(int index, ref byte[] data)
        {
            int recipeindex;
            int amount;
            ByteStream buffer = new ByteStream(data);

            S_General.AddDebug("Recieved CMSG: CStartCraft");

            recipeindex = buffer.ReadInt32();
            amount = buffer.ReadInt32();

            if (modTypes.TempPlayer[index].IsCrafting == false)
                return;

            if (recipeindex == 0 || amount == 0)
                return;

            if (!CheckLearnedRecipe(index, recipeindex))
                return;

            StartCraft(index, recipeindex, amount);

            buffer.Dispose();
        }



        public static void SendRecipes(int index)
        {
            int i;

            for (i = 1; i <= Constants.MAX_RECIPE; i++)
            {
                if (Microsoft.VisualBasic.Strings.Len(Microsoft.VisualBasic.Strings.Trim(Recipe[i].Name)) > 0)
                    SendUpdateRecipeTo(index, i);
            }
        }

        public static void SendUpdateRecipeTo(int index, int RecipeNum)
        {
            ByteStream buffer;
            int i;
            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SUpdateRecipe);
            buffer.WriteInt32(RecipeNum);

            S_General.AddDebug("Sent SMSG: SUpdateRecipe");

            buffer.WriteString((Microsoft.VisualBasic.Strings.Trim(Recipe[RecipeNum].Name)));
            buffer.WriteInt32(Recipe[RecipeNum].RecipeType);
            buffer.WriteInt32(Recipe[RecipeNum].MakeItemNum);
            buffer.WriteInt32(Recipe[RecipeNum].MakeItemAmount);

            for (i = 1; i <= Constants.MAX_INGREDIENT; i++)
            {
                buffer.WriteInt32(Recipe[RecipeNum].Ingredients[i].ItemNum);
                buffer.WriteInt32(Recipe[RecipeNum].Ingredients[i].Value);
            }

            buffer.WriteInt32(Recipe[RecipeNum].CreateTime);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendUpdateRecipeToAll(int RecipeNum)
        {
            ByteStream buffer;
            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SUpdateRecipe);
            buffer.WriteInt32(RecipeNum);

            S_General.AddDebug("Sent SMSG: SUpdateRecipe To All");

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

            S_NetworkConfig.SendDataToAll(ref buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendPlayerRecipes(int index)
        {
            int i;
            ByteStream buffer;
            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SSendPlayerRecipe);

            S_General.AddDebug("Sent SMSG: SSendPlayerRecipe");

            for (i = 1; i <= Constants.MAX_RECIPE; i++)
                buffer.WriteInt32(modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RecipeLearned[i]);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendOpenCraft(int index)
        {
            ByteStream buffer;
            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SOpenCraft);

            S_General.AddDebug("Sent SMSG: SOpenCraft");

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }

        public static void SendCraftUpdate(int index, byte done)
        {
            ByteStream buffer;
            buffer = new ByteStream(4);
            buffer.WriteInt32((int)Packets.ServerPackets.SUpdateCraft);

            S_General.AddDebug("Sent SMSG: SUpdateCraft");

            buffer.WriteInt32(done);

            S_NetworkConfig.Socket.SendDataTo(index, buffer.Data, buffer.Head);

            buffer.Dispose();
        }



        internal static bool CheckLearnedRecipe(int index, int RecipeNum)
        {
            bool CheckLearnedRecipe = false;
            bool flag = modTypes.Player[index].Character[(int)modTypes.TempPlayer[index].CurChar].RecipeLearned[RecipeNum] == 1;
            if (flag)
            {
                CheckLearnedRecipe = true;
            }
            return CheckLearnedRecipe;
        }

        internal static void LearnRecipe(int index, int RecipeNum, int InvNum)
        {
            if (CheckLearnedRecipe(index, RecipeNum))
                S_NetworkSend.PlayerMsg(index, "You allready know this recipe!", (int)Enums.ColorType.BrightRed);
            else
            {
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RecipeLearned[RecipeNum] = 1;

                S_NetworkSend.PlayerMsg(index, "You learned the " + Recipe[RecipeNum].Name + " recipe!", (int)Enums.ColorType.BrightGreen);

                S_Players.TakeInvItem(index, S_Players.GetPlayerInvItemNum(index, InvNum), 0);

                modDatabase.SavePlayer(index);
                S_NetworkSend.SendPlayerData(index);
            }
        }

        internal static void StartCraft(int index, int RecipeNum, int Amount)
        {
            //Todo Orion+#
        }

        internal static void UpdateCraft(int index)
        {
            int i;

            // ok, we made the item, give and take the shit
            if (S_Players.GiveInvItem(index, Recipe[modTypes.TempPlayer[index].CraftRecipe].MakeItemNum, Recipe[modTypes.TempPlayer[index].CraftRecipe].MakeItemAmount, true))
            {
                for (i = 1; i <= Constants.MAX_INGREDIENT; i++)
                    S_Players.TakeInvItem(index, Recipe[modTypes.TempPlayer[index].CraftRecipe].Ingredients[i].ItemNum, Recipe[modTypes.TempPlayer[index].CraftRecipe].Ingredients[i].Value);
                S_NetworkSend.PlayerMsg(index, "You created " + Microsoft.VisualBasic.Strings.Trim(Types.Item[Recipe[modTypes.TempPlayer[index].CraftRecipe].MakeItemNum].Name) + " X " + Recipe[modTypes.TempPlayer[index].CraftRecipe].MakeItemAmount, (int)Enums.ColorType.BrightGreen);
            };
            //Todo Orion+#
        }
    }
}
