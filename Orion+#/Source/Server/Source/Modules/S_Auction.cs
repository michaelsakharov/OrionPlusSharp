using System;
using System.Windows.Forms;
using ASFW;
using Microsoft.VisualBasic;

namespace Engine
{
    public class S_Auction
    {

        //=========================================================
        public static AuctionHouseRec[] Auction = new AuctionHouseRec[100 + 1];


        public struct AuctionHouseRec
        {
            public string Owner;
            public int OwnerID;
            public int Item;
            public int Amount;
            public int Price;
            public int Bid;
            public int MaxBid;
            public int EndDate;
            public string Date;
            public string LastBidder;
        };



        public static void AddAuction(int Index, int ItemNum, int Amount, int Min, int Max)
        {
            int i;
            string Filename = "";
            int Unused = 0;



            // Find a empty auction slot.
            for (i = 1; i <= 100; i++)
            {
                if (Auction[i].Owner == string.Empty)
                {
                    Unused = i;
                    break;
                }
            } // i


            Auction[Unused].Owner = S_Players.GetPlayerName(Index);
            Auction[Unused].OwnerID = Index;
            Auction[Unused].Item = ItemNum;
            Auction[Unused].Amount = Amount;
            Auction[Unused].Price = Min;
            Auction[Unused].MaxBid = Max;
            Auction[Unused].Date = String.Format(DateTime.Today.ToString(), "m/d/yyyy");
            Auction[Unused].EndDate = 31;

            modDatabase.SaveAuction(Unused);


            S_NetworkSend.SendAuctions();

        }

        public static void BidOnAuction(int Index, int Bid, int AuctionNum)
        {
            // Obvious
            if (AuctionNum == 0) return;
            // Lets make sure the auction even exists!
            if (Auction[AuctionNum].Owner == string.Empty)
            {
                S_NetworkSend.PlayerMsg(Index, "Auction no longer exists!", (int)Enums.ColorType.Red);
                return;
            }

            // Make sure they have enough money!
            if (S_Players.HasItem(Index, 1) < Bid)
            {
                S_NetworkSend.PlayerMsg(Index, "You Don't Have Enough Money To Make This Bid!", (int)Enums.ColorType.Red);
                return;
            }

            if (Bid < Auction[AuctionNum].Price)
            {
                S_NetworkSend.PlayerMsg(Index, "You Haven't Met This Bids Minimum Price!", (int)Enums.ColorType.Red);
                return;
            }

            if (Bid > Auction[AuctionNum].Bid)
            {

                // Give the previous bidder his $$ back

                if (Auction[AuctionNum].LastBidder != string.Empty)
                {

                    GivePrevBid(Auction[AuctionNum].LastBidder, Auction[AuctionNum].Bid);

                }
                else
                {

                    // Something went south, most likely a account deletion. Log it just incase
                    S_General.AddDebug("Auction Failed To Find A Player And Return " + Bid + " To Them!");
                }

                Auction[AuctionNum].Bid = Bid;
                Auction[AuctionNum].LastBidder = S_Players.GetPlayerName(Index);
                S_Players.TakeInvItem(Index, 1, Bid);
                S_NetworkSend.PlayerMsg(Index, "You have successfully bid " + Bid, (int)Enums.ColorType.Red);

                // Lets check if we won!
                if (Bid >= Auction[AuctionNum].MaxBid)
                {
                    S_NetworkSend.PlayerMsg(Index, "You Have Won " + Types.Item[Auction[AuctionNum].Item].Name.Trim() + " !", (int)Enums.ColorType.Red);
                    S_Players.GiveInvItem(Index, Auction[AuctionNum].Item, 0, true);
                    // Should be working but may need work:
                    if(Auction[AuctionNum].OwnerID != 0)
                    {
                        S_NetworkSend.PlayerMsg(Auction[AuctionNum].OwnerID, "Your Auction has sold: " + Types.Item[Auction[AuctionNum].Item].Name.Trim() + " !", (int)Enums.ColorType.Red);
                        S_Players.GiveInvItem(Auction[AuctionNum].OwnerID, 1, Auction[AuctionNum].Bid, true);
                    }
                    else
                    {
                        AuctionSoldOut(AuctionNum);
                    }
                    DestroyAuction(AuctionNum);
                    S_NetworkSend.SendAuctions();
                }
                else
                {

                    // We are not quite there yet
                    S_NetworkSend.PlayerMsg(Index, "You Are " + (Auction[AuctionNum].MaxBid - Bid) + " Away from winning this auction!", (int)Enums.ColorType.Red);
                }

            }
            else
            {

                S_NetworkSend.PlayerMsg(Index, "Sorry, You Are " + (Auction[AuctionNum].Bid - Bid) + " Away from making a bid!", (int)Enums.ColorType.Red);

            }

        }

        public static void RemoveDeadAuction(int AuctionNum)
        {
            string Dates = "";

            //This is probably broken:
            Dates = String.Format(DateTime.Today.ToString(), "m/d/yyyy");

            if (DateAndTime.DateDiff("d", DateTime.Parse(Auction[AuctionNum].Date), DateTime.Parse(Dates), FirstDayOfWeek.System, FirstWeekOfYear.System) >= Auction[AuctionNum].EndDate)
            {

                // Give the auction to the previous bidder, they won ;p
                AuctionTimedOut(AuctionNum);
                DestroyAuction(AuctionNum);
            }


        }

        public static void DestroyAuction(int AuctionNum)
        {



            Auction[AuctionNum].Owner = string.Empty;
            Auction[AuctionNum].OwnerID = 0;
            Auction[AuctionNum].Amount = 0;
            Auction[AuctionNum].Bid = 0;
            Auction[AuctionNum].EndDate = 0;
            Auction[AuctionNum].Date = string.Empty;
            Auction[AuctionNum].Item = 0;
            Auction[AuctionNum].MaxBid = 0;
            Auction[AuctionNum].Price = 0;
            Auction[AuctionNum].LastBidder = string.Empty;



            modDatabase.SaveAuction(AuctionNum);

        }

        private static void GivePrevBid(string PlayerName, int Bid)
        {
            string Filename = "";
            int i;
            int F;

            i = S_NetworkConfig.Socket.HighIndex + 3;


            //modDatabase.ClearPlayer(i);
            //Filename = Application.StartupPath + "\\data\\accounts\\" + PlayerName.Trim() + ".bin";
            //F = FileSystem.FreeFile();
            //FileSystem.FileOpen(F, Filename, OpenMode.Binary, (OpenAccess)(-1), (OpenShare)(-1), -1);
            //FileSystem.FileGet(F, ref modTypes.Player[i]);
            //FileSystem.FileClose(F);

            modTypes.Player[i].Money = Bid;

            modDatabase.SavePlayer(i);

            //Filename = Application.StartupPath + "\\data\\accounts\\" + PlayerName.Trim() + ".bin";
            //F = FileSystem.FreeFile();
            //FileSystem.FileOpen(F, Filename, OpenMode.Binary, (OpenAccess)(-1), (OpenShare)(-1), -1);
            //FileSystem.FilePut(F, modTypes.Player[i]);
            //FileSystem.FileClose(F);
            //
            //
            //modDatabase.ClearPlayer(i);

        }

        private static void AuctionTimedOut(int AuctionNum)
        {
            int i;
            string Filename = "";
            int F;
            string PlayerName = "";

            PlayerName = Auction[AuctionNum].LastBidder;

            i = S_NetworkConfig.Socket.HighIndex + 3;


            //modDatabase.ClearPlayer(i);
            //modDatabase.LoadPlayer(i, PlayerName);
            //Filename = Application.StartupPath + "\\data\\accounts\\" + PlayerName.Trim() + ".bin";
            //F = FileSystem.FreeFile();
            //FileSystem.FileOpen(F, Filename, OpenMode.Binary, (OpenAccess)(-1), (OpenShare)(-1), -1);
            //FileSystem.FileGet(F, ref modTypes.Player[i]);
            //FileSystem.FileClose(F);

            modTypes.Player[i].BidWon = Auction[i].Item;

            modDatabase.SavePlayer(i);

            //Filename = Application.StartupPath + "\\data\\accounts\\" + PlayerName.Trim() + ".bin";
            //F = FileSystem.FreeFile();
            //FileSystem.FileOpen(F, Filename, OpenMode.Binary, (OpenAccess)(-1), (OpenShare)(-1), -1);
            //FileSystem.FilePut(F, modTypes.Player[i]);
            //FileSystem.FileClose(F);


            //modDatabase.ClearPlayer(i);

        }

        private static void AuctionSoldOut(int AuctionNum)
        {
            int i;
            string Filename = "";
            int F;
            string PlayerName = "";

            PlayerName = Auction[AuctionNum].LastBidder;

            i = S_NetworkConfig.Socket.HighIndex + 3;


            //modDatabase.ClearPlayer(i);
            //modDatabase.LoadPlayer(i, PlayerName);
            //Filename = Application.StartupPath + "\\data\\accounts\\" + PlayerName.Trim() + ".bin";
            //F = FileSystem.FreeFile();
            //FileSystem.FileOpen(F, Filename, OpenMode.Binary, (OpenAccess)(-1), (OpenShare)(-1), -1);
            //FileSystem.FileGet(F, ref modTypes.Player[i]);
            //FileSystem.FileClose(F);

            modTypes.Player[i].Money = Auction[AuctionNum].Bid;

            modDatabase.SavePlayer(i);

            //Filename = Application.StartupPath + "\\data\\accounts\\" + PlayerName.Trim() + ".bin";
            //F = FileSystem.FreeFile();
            //FileSystem.FileOpen(F, Filename, OpenMode.Binary, (OpenAccess)(-1), (OpenShare)(-1), -1);
            //FileSystem.FilePut(F, modTypes.Player[i]);
            //FileSystem.FileClose(F);


            //modDatabase.ClearPlayer(i);

        }



        public static void HandleGetAuctions(int index, ref byte[] data)
        {
            S_NetworkSend.SendAuctions(index);
        }

        public static void HandleAddAuction(int index, ref byte[] data)
        {
            int InvItem;
            int ItemNum;
            int Price;
            int MaxPrice;
        
            ByteStream buffer = new ByteStream(data);
        
            InvItem = buffer.ReadInt32();
        
            Price = buffer.ReadInt32();
        
            MaxPrice = buffer.ReadInt32();
        
            buffer.Dispose();
        
            ItemNum = S_Players.GetPlayerInvItemNum(index, InvItem);
        
            if (Price > 0)
            {
        
                AddAuction(index, ItemNum, 1, Price, MaxPrice);
            }
            else
            {
                S_NetworkSend.PlayerMsg(index, "Your Price Must Be Above 0!", (int)Enums.ColorType.Red);
            }
        }

        public static void HandleBid(int index, ref byte[] data)
        {
            int Bid;
            int Num;

            ByteStream buffer = new ByteStream(data);

            Num = buffer.ReadInt32();

            Bid = buffer.ReadInt32();

            BidOnAuction(index, Bid, Num);

            buffer.Dispose();
        }
    }
}