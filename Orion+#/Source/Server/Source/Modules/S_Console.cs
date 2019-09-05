using System;
using System.Linq;
using System.Threading;

namespace Engine
{
    static class S_Console
    {
        private static Thread threadConsole;

        public static void Main()
        {
            threadConsole = new Thread(new ThreadStart(ConsoleThread));
            threadConsole.Start();

            // Spin up the server on the main thread
            S_General.InitServer();
        }

        private static void ConsoleThread()
        {
            string line;
            string[] parts;

            Console.WriteLine("Initializing Console Loop");

            while ((true))
            {
                line = Console.ReadLine();

                parts = line.Split(' '); if ((parts.Length < 1))
                    continue;

                switch (parts[0].Trim().ToLower())
                {
                    case "/help":
                        {
                            Console.WriteLine("/help, Shows this message.");
                            Console.WriteLine("/exit, Closes down the server.");
                            Console.WriteLine("/setadmin, Sets player access level, use with '/setadmin playername powerlvl' powerlevel goes from 0 for player, to 4 to creator.");
                            Console.WriteLine("/kick, Kicks user from server, use with '/kick playername'");
                            Console.WriteLine("/ban, Bans user from server, use with '/ban playername'");
                            Console.WriteLine("/timespeed, Set Game Speed '/timespeed speed'");
                            Console.WriteLine("/ip, View the ip of the server '/ip'");
                            Console.WriteLine("/say, Send a global message for everyone to see '/say message'");
                            Console.WriteLine("/setxpmultiplier, Set the Global XP multiplier '/setxpmultiplier multiplayer'");
                            Console.WriteLine("/debugtext, Toggle Debug Text '/debugtext'");
                            Console.WriteLine("/unlockcps, unlock CPS '/unlockcps'");
                            Console.WriteLine("/lockcps, lock CPS '/lockcps'");
                            Console.WriteLine("/cps, view CPS '/cps'");
                            break;
                        }

                    case "/exit":
                        {
                            S_General.DestroyServer();
                            break;
                        }

                    case "/setadmin":
                        {
                            if (parts.Length > 3 || parts.Length < 3)
                            {
                                Console.WriteLine("Incorrect usage.");
                                break;
                            }


                            string Name = parts[1];
                            int Pindex = S_GameLogic.FindPlayer(Name);
                            int.TryParse(parts[2], out int Power);

                            if (!(Pindex > 0))
                                Console.WriteLine("Player name is empty or invalid. [Name not found]");
                            else
                                switch (Power)
                                {
                                    case 0:
                                        {
                                            S_Players.SetPlayerAccess(Pindex, Power);
                                            S_NetworkSend.SendPlayerData(Pindex);
                                            S_NetworkSend.PlayerMsg(Pindex, "Your PowerLevel has been set to Player Rank!", (int)Enums.ColorType.BrightCyan);
                                            Console.WriteLine("Successfully set the power level to " + Power + " for player " + Name);
                                            break;
                                        }

                                    case 1:
                                        {
                                            S_Players.SetPlayerAccess(Pindex, Power);
                                            S_NetworkSend.SendPlayerData(Pindex);
                                            S_NetworkSend.PlayerMsg(Pindex, "Your PowerLevel has been set to Monitor Rank!", (int)Enums.ColorType.BrightCyan);
                                            Console.WriteLine("Successfully set the power level to " + Power + " for player " + Name);
                                            break;
                                        }

                                    case 2:
                                        {
                                            S_Players.SetPlayerAccess(Pindex, Power);
                                            S_NetworkSend.SendPlayerData(Pindex);
                                            S_NetworkSend.PlayerMsg(Pindex, "Your PowerLevel has been set to Mapper Rank!", (int)Enums.ColorType.BrightCyan);
                                            Console.WriteLine("Successfully set the power level to " + Power + " for player " + Name);
                                            break;
                                        }

                                    case 3:
                                        {
                                            S_Players.SetPlayerAccess(Pindex, Power);
                                            S_NetworkSend.SendPlayerData(Pindex);
                                            S_NetworkSend.PlayerMsg(Pindex, "Your PowerLevel has been set to Developer Rank!", (int)Enums.ColorType.BrightCyan);
                                            Console.WriteLine("Successfully set the power level to " + Power + " for player " + Name);
                                            break;
                                        }

                                    case 4:
                                        {
                                            S_Players.SetPlayerAccess(Pindex, Power);
                                            S_NetworkSend.SendPlayerData(Pindex);
                                            S_NetworkSend.PlayerMsg(Pindex, "Your PowerLevel has been set to Creator Rank!", (int)Enums.ColorType.BrightCyan);
                                            Console.WriteLine("Successfully set the power level to " + Power + " for player " + Name);
                                            break;
                                        }

                                    default:
                                        {
                                            Console.WriteLine("Failed to set the power level to " + Power + " for player " + Name);
                                            break;
                                        }
                                }

                            break;
                        }

                    case "/kick":
                        {
                            if (parts.Length > 2 || parts.Length < 2) {
                                Console.WriteLine("Incorrect usage.");
                                break;
                                }


                            string Name = parts[1];
                            int Pindex = S_GameLogic.FindPlayer(Name);
                            if (!(Pindex > 0))
                                Console.WriteLine("Player name is empty or invalid. [Name not found]");
                            else
                            {
                                S_NetworkSend.AlertMsg(Pindex, "You have been kicked by the server owner!");
                                S_Players.LeftGame(Pindex);
                            }

                            break;
                        }

                    case "/ban":
                        {
                            if (parts.Length > 2 || parts.Length < 2)
                            {
                                Console.WriteLine("Incorrect usage.");
                                break;
                            }


                            string Name = parts[1];
                            int Pindex = S_GameLogic.FindPlayer(Name);
                            if (!(Pindex > 0))
                                Console.WriteLine("Player name is empty or invalid. [Name not found]");
                            else
                                modDatabase.ServerBanIndex(Pindex);
                            break;
                        }

                    case "/timespeed":
                        {
                            if (parts.Length > 2 || parts.Length < 2)
                            {
                                Console.WriteLine("Incorrect usage.");
                                break;
                            }


                            double.TryParse(parts[1], out double speed);
                            Time.Instance.GameSpeed = speed;
                            Console.WriteLine("Set GameSpeed to " + Time.Instance.GameSpeed + " secs per seconds");
                            break;
                        }

                    case "/ip":
                        {
                            Console.WriteLine("Ip:" + S_General.MyIPAddress);
                            break;
                        }
                    case "/say":
                        {
                            if (parts.Length > 2)
                            {
                                Console.WriteLine("Incorrect usage.");
                                break;
                            }

                            string message = "";
                            foreach (var item in parts.ToList().Skip(1))
                                if (message == "")
                                {
                                    message += item;
                                }
                                else
                                {
                                    message += " " + item;
                                }
                            S_NetworkSend.GlobalMsg(message);
                            Console.WriteLine(message);
                            break;
                        }
                    case "/setxpmultiplier":
                        {
                            if (parts.Length > 2 || parts.Length < 2)
                            {
                                Console.WriteLine("Incorrect usage.");
                                break;
                            }
                            float.TryParse(parts[1], out float xpMultiplayer);
                            modTypes.Options.xpMultiplier = xpMultiplayer;
                            Console.WriteLine("Global XP Multiplayer set to: " + xpMultiplayer);
                            break;
                        }
                    case "/unlockcps":
                        {
                            if (parts.Length > 1 || parts.Length < 1)
                            {
                                Console.WriteLine("Incorrect usage.");
                                break;
                            }
                            modTypes.Options.unlockCPS = true;
                            Console.WriteLine("CPS: " + S_General.gameCPS + " CPS is Unlocked");
                            break;
                        }
                    case "/lockcps":
                        {
                            if (parts.Length > 1 || parts.Length < 1)
                            {
                                Console.WriteLine("Incorrect usage.");
                                break;
                            }
                            modTypes.Options.unlockCPS = false;
                            Console.WriteLine("CPS: " + S_General.gameCPS + " CPS is locked");
                            break;
                        }
                    case "/cps":
                        {
                            if (parts.Length > 1 || parts.Length < 1)
                            {
                                Console.WriteLine("Incorrect usage.");
                                break;
                            }
                            Console.WriteLine("CPS: " + S_General.gameCPS);
                            break;
                        }
                    case "/debugtext":
                        {
                            if (parts.Length > 1)
                            {
                                Console.WriteLine("Incorrect usage.");
                                break;
                            }
                            S_Globals.DebugTxt = !S_Globals.DebugTxt;
                            Console.WriteLine("Debug Text: " + S_Globals.DebugTxt);
                            break;
                        }
                    case "":
                        {
                            continue;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid Command. If you are unsure of the functions type '/help'.");
                            break;
                        }
                }
            }
        }
    }
}
