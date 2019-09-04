using System;

namespace Engine
{
    static class S_GameLogic
    {
        public static int GetTotalMapPlayers(int mapNum)
        {
            int i;
            int n;
            n = 0;
            var loopTo = GetPlayersOnline();
            for (i = 1; i <= loopTo; i++)
            {
                if (S_NetworkConfig.IsPlaying(i) && S_Players.GetPlayerMap(i) == mapNum)
                    n = n + 1;
            }

            return n;
        }

        internal static int GetPlayersOnline()
        {
            int x;
            x = 0;
            var loopTo = S_NetworkConfig.Socket.HighIndex;
            for (int i = 1; i <= loopTo; i++)
            {
                if (modTypes.TempPlayer[i].InGame == true)
                    x = x + 1;
            }
            return x;
        }

        public static int GetNpcMaxVital(int NpcNum, Enums.VitalType Vital)
        {

            // Prevent subscript out of range
            if (NpcNum <= 0 || NpcNum > Constants.MAX_NPCS)
                return 0;

            switch (Vital)
            {
                case Enums.VitalType.HP:
                    {
                        return Types.Npc[NpcNum].Hp;
                        break;
                    }

                case Enums.VitalType.MP:
                    {
                        return Types.Npc[NpcNum].Stat[(int)Enums.StatType.Intelligence] * 2;
                        break;
                    }

                case Enums.VitalType.SP:
                    {
                        return Types.Npc[NpcNum].Stat[(int)Enums.StatType.Spirit] * 2;
                        break;
                    }
            }
            return 0;
        }

        public static int FindPlayer(string Name)
        {
            int i;
            var loopTo = GetPlayersOnline();
            for (i = 1; i <= loopTo; i++)
            {
                if (S_NetworkConfig.IsPlaying(i))
                {
                    // Make sure we dont try to check a name thats to small
                    if (Microsoft.VisualBasic.Strings.Len(S_Players.GetPlayerName(i)) >= Microsoft.VisualBasic.Strings.Len(Name.Trim()))
                    {
                        if (Microsoft.VisualBasic.Strings.Mid(S_Players.GetPlayerName(i), 1, Microsoft.VisualBasic.Strings.Len(Name.Trim())).ToUpper() == Name.Trim().ToUpper())
                        {
                            return i;
                        }
                    }
                }
            }

            return 0;
        }

        internal static int Random(Int32 low, Int32 high)
        {
            System.Random random = new System.Random();
            return random.Next(low, high + 1);
        }

        internal static string CheckGrammar(string Word, byte Caps = 0)
        {
            string FirstLetter;

            FirstLetter = Microsoft.VisualBasic.Strings.Left(Word, 1).ToLower();

            if (FirstLetter == "$")
            {
                return (Microsoft.VisualBasic.Strings.Mid(Word, 2, Microsoft.VisualBasic.Strings.Len(Word) - 1));
            };
            return FirstLetter;
        }
    }
}
