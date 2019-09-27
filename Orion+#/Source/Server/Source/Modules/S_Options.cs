namespace Engine
{
    internal struct S_Options
    {
        //Config file
        public string GameName;
        public string Motd;
        public string Website;
        public int Port;
        public int StartMap;
        public int StartX;
        public int StartY;
        public float xpMultiplier;

        // Game Settings
        public bool allowEightDirectionalMovement;
        public bool useSmoothDynamicLightRendering;

        

        // Session based settings
        public bool unlockCPS;
    }
}
