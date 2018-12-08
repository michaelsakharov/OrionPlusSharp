namespace Engine
{
    static class S_Constants
    {

        // Path constants
        internal const string ADMIN_LOG = "admin.log";

        internal const string PLAYER_LOG = "player.log";
        internal const string PACKET_LOG = "packet.log";

        // Maximum values
        internal const byte MAX_HOTBAR = 7;

        internal const byte MAX_CHARS = 3;
        internal const byte StatPtsPerLvl = 3;
        internal const byte MAX_MAPX = 50;
        internal const byte MAX_MAPY = 50;

        internal const long ITEM_SPAWN_TIME = 30000; // 30 seconds
        internal const long ITEM_DESPAWN_TIME = 90000; // 1:30 seconds
    }
}
