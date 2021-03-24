namespace Engine
{
    static class S_Globals
    {
        internal static bool Debugging;
        internal static bool DebugTxt = false;
        internal static string ConsoleText;
        internal static int ErrorCount;

        // Used for closing key doors again
        internal static int KeyTimer;

        // Used for gradually giving back npcs hp
        internal static int GiveNPCHPTimer;

        internal static int GiveNPCMPTimer;

        // Used for logging
        internal static bool ServerLog;

        // Text vars
        internal static string vbQuote;

        // Maximum classes
        internal static byte Max_Classes;

        // Used for server loop
        internal static bool ServerOnline;

        // Used for outputting text
        internal static int NumLines;

        // Used to handle shutting down server with countdown.
        internal static bool isShuttingDown;

        internal static int Secs;
        internal static byte TempMapData;

        internal static bool Gettingmap;
        internal static Asfw.IO.Encryption.KeyPair EKeyPair = new Asfw.IO.Encryption.KeyPair();
    }
}
