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

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Initializing Console Loop");
            Console.ResetColor();

            while ((true))
            {
                line = Console.ReadLine();

                parts = line.Split(' '); if ((parts.Length < 1))
                    continue;

                switch (parts[0].Trim().ToLower().Replace("/", ""))
                {
                    case "help":
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("/help, Shows this message.");
                            Console.WriteLine("/exit, Closes down the server.");
                            Console.WriteLine("/setadmin, Sets player access level, usage '/setadmin playername powerlvl' powerlevel goes from 0 for player, to 4 to creator.");
                            Console.WriteLine("/kick, Kicks user from server, usage '/kick playername'");
                            Console.WriteLine("/ban, Bans user from server, usage '/ban playername'");
                            Console.WriteLine("/timespeed, Set Game Speed, usage  '/timespeed speed'");
                            Console.WriteLine("/ip, View the ip of the server");
                            Console.WriteLine("/say, Send a global message for everyone to see, usage '/say message'");
                            Console.WriteLine("/setxpmultiplier, Set the Global XP multiplier, usage '/setxpmultiplier multiplayer'");
                            Console.WriteLine("/debugtext, Toggle Debug Text");
                            Console.WriteLine("/unlockcps, unlock CPS");
                            Console.WriteLine("/lockcps, lock CPS");
                            Console.ResetColor();
                            break;
                        }

                    case "exit":
                        {
                            S_General.DestroyServer();
                            break;
                        }

                    case "setadmin":
                        {
                            if (parts.Length > 3 || parts.Length < 3)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect usage.");
                                Console.ResetColor();
                                break;
                            }


                            string Name = parts[1];
                            int Pindex = S_GameLogic.FindPlayer(Name);
                            int.TryParse(parts[2], out int Power);

                            Console.ForegroundColor = ConsoleColor.Yellow;
                            if (!(Pindex > 0))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Player name is empty or invalid. [Name not found]");
                            }
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
                            Console.ResetColor();
                            break;
                        }

                    case "kick":
                        {
                            if (parts.Length > 2 || parts.Length < 2) {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect usage.");
                                Console.ResetColor();
                                break;
                                }


                            string Name = parts[1];
                            int Pindex = S_GameLogic.FindPlayer(Name);
                            Console.ForegroundColor = ConsoleColor.Red;
                            if (!(Pindex > 0))
                                Console.WriteLine("Player name is empty or invalid. [Name not found]");
                            else
                            {
                                S_NetworkSend.AlertMsg(Pindex, "You have been kicked by the server owner!");
                                S_Players.LeftGame(Pindex);
                            }
                            Console.ResetColor();
                            break;
                        }

                    case "ban":
                        {
                            if (parts.Length > 2 || parts.Length < 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect usage.");
                                Console.ResetColor();
                                break;
                            }


                            string Name = parts[1];
                            int Pindex = S_GameLogic.FindPlayer(Name);

                            Console.ForegroundColor = ConsoleColor.Red;
                            if (!(Pindex > 0))
                                Console.WriteLine("Player name is empty or invalid. [Name not found]");
                            else
                                modDatabase.ServerBanIndex(Pindex);
                            
                            Console.ResetColor();
                            break;
                        }

                    case "timespeed":
                        {
                            if (parts.Length > 2 || parts.Length < 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect usage.");
                                Console.ResetColor();
                                break;
                            }


                            double.TryParse(parts[1], out double speed);
                            Time.Instance.GameSpeed = speed;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Set GameSpeed to " + Time.Instance.GameSpeed + " secs per seconds");
                            Console.ResetColor();
                            break;
                        }

                    case "ip":
                        {
                            Console.WriteLine("Ip:" + S_General.MyIPAddress);
                            break;
                        }
                    case "say":
                        {
                            if (parts.Length > 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect usage.");
                                Console.ResetColor();
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
                    case "setxpmultiplier":
                        {
                            if (parts.Length > 2 || parts.Length < 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect usage.");
                                Console.ResetColor();
                                break;
                            }
                            float.TryParse(parts[1], out float xpMultiplayer);
                            modTypes.Options.xpMultiplier = xpMultiplayer;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Global XP Multiplayer set to: " + xpMultiplayer);
                            Console.ResetColor();
                            break;
                        }
                    case "unlockcps":
                        {
                            if (parts.Length > 1 || parts.Length < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect usage.");
                                Console.ResetColor();
                                break;
                            }
                            modTypes.Options.unlockCPS = true;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("CPS: " + S_General.gameCPS + " CPS is Unlocked");
                            Console.ResetColor();
                            break;
                        }
                    case "lockcps":
                        {
                            if (parts.Length > 1 || parts.Length < 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect usage.");
                                Console.ResetColor();
                                break;
                            }
                            modTypes.Options.unlockCPS = false;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("CPS: " + S_General.gameCPS + " CPS is locked");
                            Console.ResetColor();
                            break;
                        }
                    case "debugtext":
                        {
                            if (parts.Length > 1)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect usage.");
                                Console.ResetColor();
                                break;
                            }
                            S_Globals.DebugTxt = !S_Globals.DebugTxt;
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("Debug Text: " + S_Globals.DebugTxt);
                            Console.ResetColor();
                            break;
                        }
                    case "":
                        {
                            continue;
                        }

                    default:
                        {
                            
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Command. If you are unsure of the functions type 'help'.");
                            Console.ResetColor();
                            break;
                        }
                }
            }
        }
    }
}
