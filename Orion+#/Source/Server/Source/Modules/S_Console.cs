using System;
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
                            Console.WriteLine("/timespeed, Set Game Speed '/timespeed 1'");
                            Console.WriteLine("/ip, View the ip of the server '/ip'");
                            break;
                        }

                    case "/exit":
                        {
                            S_General.DestroyServer();
                            break;
                        }

                    case "/setadmin":
                        {
                            if (parts.Length < 3)
                                continue;


                            string Name = parts[1];
                            int Pindex = S_GameLogic.FindPlayer(Name);
                            int Power; int.TryParse(parts[2], out Power);

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
                            if (parts.Length < 2)
                                continue;


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
                            if (parts.Length < 2)
                                continue;


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
                            if (parts.Length < 2)
                                return;


                            double speed;
                            double.TryParse(parts[1], out speed);
                            Time.Instance.GameSpeed = speed;
                            Console.WriteLine("Set GameSpeed to " + Time.Instance.GameSpeed + " secs per seconds");
                            break;
                        }

                    case "/ip":
                        {
                            Console.WriteLine("Ip:" + S_General.MyIPAddress);
                            break;
                        }

                    case "":
                        {
                            continue;
                            break;
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
