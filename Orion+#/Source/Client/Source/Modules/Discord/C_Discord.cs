using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DiscordRPC;
using DiscordRPC.Logging;

namespace Engine
{
    sealed class C_Discord
    {

        public static DiscordRpcClient client;

        private static string lastState = "";

        static void InitializeDiscord()
        {
            if (C_Types.Options.ApplicationID != null)
            {
                client = new DiscordRpcClient(C_Types.Options.ApplicationID);

                client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

                client.OnPresenceUpdate += (sender, e) =>
                {
                    OnPresenceUpdate(e.Presence);
                };

                client.Initialize();
            }
        }

        public static void SetPresence(string details, string state)
        {

            if(client == null)
            {
                InitializeDiscord();
            }
            if (state != lastState)
            {
                client.SetPresence(new RichPresence()
                {
                    Details = C_Constants.GameName,
                    State = state,
                    Assets = new Assets()
                    {
                        LargeImageKey = C_Types.Options.LargeImageKey,
                        LargeImageText = C_Types.Options.LargeImageText,
                        SmallImageKey = C_Types.Options.SmallImageKey
                    }
                });

                lastState = state;
            }

        }

        static void OnPresenceUpdate(BaseRichPresence presence)
        {

        }

    }
}
