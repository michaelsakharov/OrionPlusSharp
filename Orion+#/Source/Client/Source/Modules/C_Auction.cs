using System;
using System.Windows.Forms;
using ASFW;

namespace Engine
{
    public class C_Auction
    {

        //=========================================================

        public static int CurrentAuctionSelections;
        public static bool IsPickingItem;

        public static AuctionHouseRec[] Auction = new AuctionHouseRec[100 + 1];

        public struct AuctionHouseRec
        {
            public string Owner;
            public int Item;
            public int Amount;
            public int Price;
            public int Bid;
            public int MaxBid;
            public int MinBid;
            public int EndDate;
            public string Date;
        };

        public static void LoadAuctionItem(int AuctionNum)
        {
            frmAuctions.frmAuctions.InstancePtr.fraBuy.Visible = true;
            frmAuctions.frmAuctions.InstancePtr.fraMain.Visible = false;
            frmAuctions.frmAuctions.InstancePtr.fraNew.Visible = false;



            frmAuctions.frmAuctions.InstancePtr.lblItemName.Text = "Item Name: " + Types.Item[Auction[AuctionNum].Item].Name;
            frmAuctions.frmAuctions.InstancePtr.lblBuyOut.Text = "Starting Price: " + Auction[AuctionNum].Price;
            frmAuctions.frmAuctions.InstancePtr.lblHigh.Text = "Current Bid: " + Auction[AuctionNum].Bid;
            frmAuctions.frmAuctions.InstancePtr.lblMax.Text = "Buy Out Price: " + Auction[AuctionNum].MaxBid;
        }


        public static void SendAddAuct(int ItemNum, int Price, int max)
        {
            C_NetworkSend.SendAddAuction(ItemNum, Price, max);
        }

        public static void SendGetAuctions()
        {
            C_NetworkSend.SendGetAuction();
        }

        public static void SendBid(int AuctionNum, int Bid)
        {
            C_NetworkSend.SendBid(AuctionNum, Bid);
        }

        public static void HandleAddAuction(ref byte[] data)
        {
            ByteStream buffer = new ByteStream(data);

            long i;

            for (i = 1; i < 100; i++)
            {
                Auction[i].Owner = buffer.ReadString();
                Auction[i].Item = buffer.ReadInt32();
                Auction[i].Price = buffer.ReadInt32();
                Auction[i].MaxBid = buffer.ReadInt32();
                Auction[i].EndDate = buffer.ReadInt32();
                Auction[i].Amount = buffer.ReadInt32();
                Auction[i].Bid = buffer.ReadInt32();
            }

            
            if (!frmAuctions.frmAuctions.InstancePtr.lstAuctions.InvokeRequired)
            {
                frmAuctions.frmAuctions.InstancePtr.lstAuctions.ClearSelected();
                frmAuctions.frmAuctions.InstancePtr.lstAuctions.Items.Clear();
                for (i = 1; i < 100; i++)
                {
                    if (Auction[i].Owner != "")
                    {
                        frmAuctions.frmAuctions.InstancePtr.lstAuctions.Items.Add(Types.Item[Auction[i].Item].Name + " Price: " + Auction[i].Price);
                    }
                    else
                    {
                        frmAuctions.frmAuctions.InstancePtr.lstAuctions.Items.Add("Empty");
                    }
                }
            }
            else
            {
                frmAuctions.frmAuctions.InstancePtr.lstAuctions.BeginInvoke(new Action(() => frmAuctions.frmAuctions.InstancePtr.lstAuctions.Items.Clear()));
                frmAuctions.frmAuctions.InstancePtr.lstAuctions.BeginInvoke(new Action(() => frmAuctions.frmAuctions.InstancePtr.lstAuctions.ClearSelected()));
                for (i = 1; i < 100; i++)
                {
                    if (Auction[i].Owner != "")
                    {
                        frmAuctions.frmAuctions.InstancePtr.lstAuctions.BeginInvoke(new Action(() => frmAuctions.frmAuctions.InstancePtr.lstAuctions.Items.Add(Types.Item[Auction[i].Item].Name + " Price: " + Auction[i].Price)));
                    }
                    else
                    {
                        frmAuctions.frmAuctions.InstancePtr.lstAuctions.BeginInvoke(new Action(() => frmAuctions.frmAuctions.InstancePtr.lstAuctions.Items.Add("Empty")));
                    }
                }
                Application.DoEvents();
            }
            
        }

        public static void HandleOpenAuction(ref byte[] data)
        {
            if (!frmAuctions.frmAuctions.InstancePtr.InvokeRequired)
            {
                frmAuctions.frmAuctions.InstancePtr.Visible = true;

                frmAuctions.frmAuctions.InstancePtr.fraMain.Visible = true;

                frmAuctions.frmAuctions.InstancePtr.fraNew.Visible = false;

                frmAuctions.frmAuctions.InstancePtr.fraBuy.Visible = false;
            }
            else
            {
                frmAuctions.frmAuctions.InstancePtr.lstAuctions.BeginInvoke(new Action(() => frmAuctions.frmAuctions.InstancePtr.Visible = true));
                frmAuctions.frmAuctions.InstancePtr.lstAuctions.BeginInvoke(new Action(() => frmAuctions.frmAuctions.InstancePtr.fraMain.Visible = true));
                frmAuctions.frmAuctions.InstancePtr.lstAuctions.BeginInvoke(new Action(() => frmAuctions.frmAuctions.InstancePtr.fraNew.Visible = false));
                frmAuctions.frmAuctions.InstancePtr.lstAuctions.BeginInvoke(new Action(() => frmAuctions.frmAuctions.InstancePtr.fraBuy.Visible = false));
                Application.DoEvents();
            }

            C_NetworkSend.SendGetAuction();
        }
    }
}