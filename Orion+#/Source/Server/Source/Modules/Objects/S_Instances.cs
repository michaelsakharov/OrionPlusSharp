namespace Engine
{
    static class S_Instances
    {
        struct InstancedMap
        {
            public int OriginalMap;
        }

        // Consts
        internal const int INSTANCED_MAP_MASK = 16777216; // 1 << 24

        internal const int MAP_NUMBER_MASK = INSTANCED_MAP_MASK - 1;

        internal const int MAX_INSTANCED_MAPS = 100;
        internal const int MAX_CACHED_MAPS = Constants.MAX_MAPS + MAX_INSTANCED_MAPS;
        internal const string INSTANCED_MAP_SUFFIX = " (Instanced)";

        static InstancedMap[] InstancedMaps = new InstancedMap[101];

        internal static void ClearInstancedMaps()
        {
            int i;

            for (i = 1; i <= MAX_INSTANCED_MAPS; i++)
            {
                S_Resources.CacheResources(i + Constants.MAX_MAPS);
                InstancedMaps[i].OriginalMap = 0;
            }
        }

        internal static int FindFreeInstanceMapSlot()
        {
            int i;

            for (i = 1; i <= MAX_INSTANCED_MAPS; i++)
            {
                if (InstancedMaps[i].OriginalMap == 0)
                {
                    return i;
                }
            }

            return -1;
        }

        internal static int CreateInstance(int mapNum)
        {
            int i;
            int slot;

            if (mapNum <= 0 || mapNum > Constants.MAX_MAPS)
            {
                return -1;
            }

            slot = FindFreeInstanceMapSlot();

            if (slot == -1)
            {
                return -1;
            }

            InstancedMaps[slot].OriginalMap = mapNum;

            // Copy Map Data
            modTypes.Map[slot + Constants.MAX_MAPS] = modTypes.Map[mapNum];

            // Copy Map Item Data

            for (i = 1; i <= Constants.MAX_MAP_ITEMS; i++)
                modTypes.MapItem[slot + Constants.MAX_MAPS, i] = modTypes.MapItem[mapNum, i];

            // Copy Map NPCs
            modTypes.MapNpc[slot + Constants.MAX_MAPS] = modTypes.MapNpc[mapNum];

            // Re-Cache Resource
            S_Resources.CacheResources(slot + Constants.MAX_MAPS);

            if (!(modTypes.Map[slot + Constants.MAX_MAPS].Name == Microsoft.VisualBasic.Constants.vbNullString))
                modTypes.Map[slot + Constants.MAX_MAPS].Name = modTypes.Map[slot + Constants.MAX_MAPS].Name + INSTANCED_MAP_SUFFIX;
            return slot;
        }

        internal static void DestroyInstancedMap(int Slot)
        {
            int x;

            modDatabase.ClearMap(Slot + Constants.MAX_MAPS);

            for (x = 1; x <= Constants.MAX_MAP_NPCS; x++)
                modDatabase.ClearMapNpc(x, Slot + Constants.MAX_MAPS);

            for (x = 1; x <= Constants.MAX_MAP_ITEMS; x++)
                modDatabase.ClearMapItem(x, Slot + Constants.MAX_MAPS);
            InstancedMaps[Slot].OriginalMap = 0;
        }

        internal static bool IsInstancedMap(int mapNum)
        {
            return mapNum > Constants.MAX_MAPS && mapNum <= MAX_CACHED_MAPS;
        }

        internal static int GetInstanceBaseMap(int mapNum)
        {
            return InstancedMaps[mapNum - Constants.MAX_MAPS].OriginalMap;
        }
    }
}
