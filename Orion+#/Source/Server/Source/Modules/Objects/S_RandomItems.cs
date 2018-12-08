namespace Engine
{
    static class S_RandomItems
    {
        internal static void ClearRandBank(int index, int BankNum)
        {
            int i;

            modTypes.Bank[index].ItemRand[BankNum].Prefix = "";
            modTypes.Bank[index].ItemRand[BankNum].Suffix = "";
            modTypes.Bank[index].ItemRand[BankNum].Damage = 0;
            modTypes.Bank[index].ItemRand[BankNum].Speed = 0;
            modTypes.Bank[index].ItemRand[BankNum].Rarity = 0;

            for (i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                modTypes.Bank[index].ItemRand[BankNum].Stat[i] = 0;
        }

        internal static void ClearRandInv(int index, int InvNum)
        {
            int i;

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Prefix = "";
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Suffix = "";
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Damage = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Speed = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Rarity = 0;

            for (i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[InvNum].Stat[i] = 0;
        }

        internal static void ClearRandEq(int index, Enums.EquipmentType Equipment)
        {
            int i;

            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(int)Equipment].Prefix = "";
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(int)Equipment].Suffix = "";
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(int)Equipment].Damage = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(int)Equipment].Speed = 0;
            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(int)Equipment].Rarity = 0;

            for (i = 1; i <= (int)Enums.StatType.Count - 1; i++)
                modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandEquip[(int)Equipment].Stat[i] = 0;
        }

        internal static void GivePlayerRandomItem(int index, int itemnum, int invslot)
        {
            int RandomType = 0;
            int StatAmount;
            int Rarity;
            int TempNum;
            double TempAmount = 0;
            int i;
            int ItemLevel;
            string Prefix = "";

            // Check to see if we're out of range, or if the item isn't random.
            if (itemnum < 1 || itemnum > Constants.MAX_ITEMS)
                return;
            if (index < 1 || index > Constants.MAX_PLAYERS)
                return;
            if (Types.Item[itemnum].Randomize == 0)
                return;

            // See what rarity we get
            TempNum = S_GameLogic.Random(1, 100);
            if (TempNum >= 95)
            {
                Rarity = (int)Enums.RarityType.RARITY_EPIC;
                TempAmount = 0.5;
                Prefix = "Epic ";
            }
            else if (TempNum >= 80 && TempNum < 95)
            {
                Rarity = (int)Enums.RarityType.RARITY_RARE;
                TempAmount = 0.35;
                Prefix = "Rare ";
            }
            else if (TempNum >= 60 && TempNum < 80)
            {
                Rarity = (int)Enums.RarityType.RARITY_UNCOMMON;
                TempAmount = 0.2;
                Prefix = "Unrare ";
            }
            else if (TempNum >= 20 && TempNum < 60)
            {
                Rarity = (int)Enums.RarityType.RARITY_COMMON;
                TempAmount = 0;
            }
            else
            {
                Rarity = (int)Enums.RarityType.RARITY_BROKEN;
                RandomType = (int)Enums.RandomBonusType.RANDOM_BROKEN;
                Prefix = "Broken ";
            }

            // We've got a rarity! Determine the Enchant type
            if (Rarity != (int)Enums.RarityType.RARITY_BROKEN)
                RandomType = S_GameLogic.Random(1, Constants.MAX_RANDOM_TYPES);

            // Set the item level for easy reference
            ItemLevel = Types.Item[itemnum].ItemLevel;

            // set the Bonus StatAmount
            StatAmount = (int)(ItemLevel * TempAmount);
            if (StatAmount < 4 && Rarity == (int)Enums.RarityType.RARITY_EPIC)
                StatAmount = 4;
            if (StatAmount < 3 && Rarity == (int)Enums.RarityType.RARITY_RARE)
                StatAmount = 3;
            if (StatAmount < 2 && Rarity == (int)Enums.RarityType.RARITY_UNCOMMON)
                StatAmount = 2;

            // Give out the item based off of the randomtype
            switch (RandomType)
            {
                case (int)Enums.RandomBonusType.RANDOM_SPEED:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Speed";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = (int)(Types.Item[itemnum].Speed - (Types.Item[itemnum].Speed * TempAmount));
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_DAMAGE:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Damage";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        if (TempAmount < 1)
                            TempAmount = 1;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = (int)(Types.Item[itemnum].Data2 + (Types.Item[itemnum].Data2 * TempAmount));
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_WARRIOR:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Warrior";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Strength] = ItemLevel + StatAmount;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Endurance] = ItemLevel + StatAmount;
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_ARCHER:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Archer";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Spirit] = ItemLevel + StatAmount;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Endurance] = ItemLevel + StatAmount;
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_MAGE:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Mage";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Intelligence] = ItemLevel + StatAmount;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Endurance] = ItemLevel + StatAmount;
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_JESTER:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Jester";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Intelligence] = ItemLevel + StatAmount;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Spirit] = ItemLevel + StatAmount;
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_BATTLEMAGE:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Battlemage";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Strength] = ItemLevel + StatAmount;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Intelligence] = ItemLevel + StatAmount;
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_ROGUE:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Rogue";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Strength] = ItemLevel + StatAmount;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Spirit] = ItemLevel + StatAmount;
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_TOWER:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Tower";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Endurance] = ItemLevel + StatAmount;
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_SURVIVALIST:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Survival";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.ResourceSkills.Fisherman] = ItemLevel + StatAmount;
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_PERFECTIONIST:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Perfection";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.ResourceSkills.Miner] = ItemLevel + StatAmount;
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_COALMEN:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Coalmen";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.ResourceSkills.Miner] = ItemLevel + StatAmount;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.ResourceSkills.WoodCutter] = ItemLevel + StatAmount;
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_BOWYER:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Bowyer";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.ResourceSkills.WoodCutter] = ItemLevel + StatAmount;
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_BROKEN:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = "Broken ";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = "";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = (int)Enums.RarityType.RARITY_BROKEN;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = (int)(Types.Item[itemnum].Data2 - (Types.Item[itemnum].Data2 / (double)10));
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = (int)(Types.Item[itemnum].Speed + (Types.Item[itemnum].Speed / (double)10));
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_PRISM:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Prism";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        for (i = 1; i <= 4; i++)
                            modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[S_GameLogic.Random(1, (int)Enums.StatType.Count - 1)] = ItemLevel + StatAmount;
                        break;
                    }

                case (int)Enums.RandomBonusType.RANDOM_CANNON:
                    {
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Prefix = Prefix;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Suffix = " of Cannon";
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Rarity = Rarity;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Damage = Types.Item[itemnum].Data2;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Speed = Types.Item[itemnum].Speed;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Strength] = ItemLevel + StatAmount;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Intelligence] = ItemLevel + StatAmount;
                        modTypes.Player[index].Character[modTypes.TempPlayer[index].CurChar].RandInv[invslot].Stat[(int)Enums.StatType.Spirit] = ItemLevel + StatAmount;
                        break;
                    }
            }
        }
    }
}
