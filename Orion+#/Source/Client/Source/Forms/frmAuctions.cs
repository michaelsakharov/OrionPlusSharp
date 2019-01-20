using System;
using System.Windows.Forms;
using Engine;

namespace frmAuctions
{
	/// <summary>
	/// Summary description for frmAuctions.
	/// </summary>
	public class frmAuctions : System.Windows.Forms.Form
	{
		public System.Windows.Forms.GroupBox fraBuy;
		public System.Windows.Forms.GroupBox fraNew;
		public System.Windows.Forms.TextBox txtMax;
		public System.Windows.Forms.TextBox txtPrice;
		public System.Windows.Forms.Button cmdSave;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.GroupBox fraMain;
		public System.Windows.Forms.ListBox lstAuctions;
        public Label lblMax;
        public Label lblHigh;
        public Label lblItemName;
        public Label lblBuyOut;
        public TextBox txtBid;
        public Button btnBid;
        public Button btnBuyOut;
        public PictureBox pictureBox1;
        public Label label2;
        public Button btnNew;
        public ProgressBar progressBar1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public frmAuctions()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			if (_InstancePtr == null) _InstancePtr = this;
		}

		/// <summary>
		/// Default instance for Form
		/// </summary>
		public static frmAuctions InstancePtr
		{
			get
			{
				if (_InstancePtr == null || _InstancePtr.IsDisposed) _InstancePtr = new frmAuctions();
				return _InstancePtr;
			}
		}
		protected static frmAuctions _InstancePtr = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.fraBuy = new System.Windows.Forms.GroupBox();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblHigh = new System.Windows.Forms.Label();
            this.lblItemName = new System.Windows.Forms.Label();
            this.lblBuyOut = new System.Windows.Forms.Label();
            this.txtBid = new System.Windows.Forms.TextBox();
            this.btnBid = new System.Windows.Forms.Button();
            this.btnBuyOut = new System.Windows.Forms.Button();
            this.fraNew = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtMax = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.cmdSave = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.fraMain = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.lstAuctions = new System.Windows.Forms.ListBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.fraBuy.SuspendLayout();
            this.fraNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.fraMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // fraBuy
            // 
            this.fraBuy.BackColor = System.Drawing.SystemColors.Control;
            this.fraBuy.Controls.Add(this.lblMax);
            this.fraBuy.Controls.Add(this.lblHigh);
            this.fraBuy.Controls.Add(this.lblItemName);
            this.fraBuy.Controls.Add(this.lblBuyOut);
            this.fraBuy.Controls.Add(this.txtBid);
            this.fraBuy.Controls.Add(this.btnBid);
            this.fraBuy.Controls.Add(this.btnBuyOut);
            this.fraBuy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraBuy.Location = new System.Drawing.Point(8, 8);
            this.fraBuy.Name = "fraBuy";
            this.fraBuy.Size = new System.Drawing.Size(349, 422);
            this.fraBuy.TabIndex = 10;
            this.fraBuy.TabStop = false;
            this.fraBuy.Text = "Buy -ItemName-";
            // 
            // lblMax
            // 
            this.lblMax.AutoSize = true;
            this.lblMax.Location = new System.Drawing.Point(115, 127);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(54, 13);
            this.lblMax.TabIndex = 6;
            this.lblMax.Text = "Time Left:";
            // 
            // lblHigh
            // 
            this.lblHigh.AutoSize = true;
            this.lblHigh.Location = new System.Drawing.Point(115, 156);
            this.lblHigh.Name = "lblHigh";
            this.lblHigh.Size = new System.Drawing.Size(62, 13);
            this.lblHigh.TabIndex = 5;
            this.lblHigh.Text = "Current Bid:";
            // 
            // lblItemName
            // 
            this.lblItemName.AutoSize = true;
            this.lblItemName.Location = new System.Drawing.Point(115, 221);
            this.lblItemName.Name = "lblItemName";
            this.lblItemName.Size = new System.Drawing.Size(61, 13);
            this.lblItemName.TabIndex = 4;
            this.lblItemName.Text = "Item Name:";
            // 
            // lblBuyOut
            // 
            this.lblBuyOut.AutoSize = true;
            this.lblBuyOut.Location = new System.Drawing.Point(115, 188);
            this.lblBuyOut.Name = "lblBuyOut";
            this.lblBuyOut.Size = new System.Drawing.Size(75, 13);
            this.lblBuyOut.TabIndex = 3;
            this.lblBuyOut.Text = "Buy Out Price:";
            // 
            // txtBid
            // 
            this.txtBid.Location = new System.Drawing.Point(118, 248);
            this.txtBid.Name = "txtBid";
            this.txtBid.Size = new System.Drawing.Size(100, 20);
            this.txtBid.TabIndex = 2;
            this.txtBid.Text = "0";
            // 
            // btnBid
            // 
            this.btnBid.Location = new System.Drawing.Point(130, 274);
            this.btnBid.Name = "btnBid";
            this.btnBid.Size = new System.Drawing.Size(75, 23);
            this.btnBid.TabIndex = 1;
            this.btnBid.Text = "Bid!";
            this.btnBid.UseVisualStyleBackColor = true;
            this.btnBid.Click += new System.EventHandler(this.btnBid_Click);
            // 
            // btnBuyOut
            // 
            this.btnBuyOut.Location = new System.Drawing.Point(130, 303);
            this.btnBuyOut.Name = "btnBuyOut";
            this.btnBuyOut.Size = new System.Drawing.Size(75, 23);
            this.btnBuyOut.TabIndex = 0;
            this.btnBuyOut.Text = "Buy Out";
            this.btnBuyOut.UseVisualStyleBackColor = true;
            this.btnBuyOut.Click += new System.EventHandler(this.btnBuyOut_Click);
            // 
            // fraNew
            // 
            this.fraNew.BackColor = System.Drawing.SystemColors.Control;
            this.fraNew.Controls.Add(this.label2);
            this.fraNew.Controls.Add(this.pictureBox1);
            this.fraNew.Controls.Add(this.txtMax);
            this.fraNew.Controls.Add(this.txtPrice);
            this.fraNew.Controls.Add(this.cmdSave);
            this.fraNew.Controls.Add(this.Label1);
            this.fraNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraNew.Location = new System.Drawing.Point(8, 8);
            this.fraNew.Name = "fraNew";
            this.fraNew.Size = new System.Drawing.Size(349, 421);
            this.fraNew.TabIndex = 2;
            this.fraNew.TabStop = false;
            this.fraNew.Text = "Auction House:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(24, 197);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Max Bid:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(140, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 50);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // txtMax
            // 
            this.txtMax.BackColor = System.Drawing.SystemColors.Window;
            this.txtMax.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMax.Location = new System.Drawing.Point(105, 194);
            this.txtMax.Name = "txtMax";
            this.txtMax.Size = new System.Drawing.Size(163, 20);
            this.txtMax.TabIndex = 7;
            this.txtMax.Text = "0";
            // 
            // txtPrice
            // 
            this.txtPrice.BackColor = System.Drawing.SystemColors.Window;
            this.txtPrice.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtPrice.Location = new System.Drawing.Point(105, 162);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(163, 20);
            this.txtPrice.TabIndex = 5;
            this.txtPrice.Text = "0";
            // 
            // cmdSave
            // 
            this.cmdSave.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSave.Location = new System.Drawing.Point(105, 388);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(114, 25);
            this.cmdSave.TabIndex = 3;
            this.cmdSave.Text = "Send Auction!";
            this.cmdSave.UseVisualStyleBackColor = false;
            this.cmdSave.Click += new System.EventHandler(this.cmdSave_Click);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(24, 170);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(82, 17);
            this.Label1.TabIndex = 6;
            this.Label1.Text = "Starting Price:";
            // 
            // fraMain
            // 
            this.fraMain.BackColor = System.Drawing.SystemColors.Control;
            this.fraMain.Controls.Add(this.progressBar1);
            this.fraMain.Controls.Add(this.btnNew);
            this.fraMain.Controls.Add(this.lstAuctions);
            this.fraMain.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraMain.Location = new System.Drawing.Point(8, 8);
            this.fraMain.Name = "fraMain";
            this.fraMain.Size = new System.Drawing.Size(349, 421);
            this.fraMain.TabIndex = 0;
            this.fraMain.TabStop = false;
            this.fraMain.Text = "Auction House:";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(24, 388);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 23);
            this.btnNew.TabIndex = 10;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // lstAuctions
            // 
            this.lstAuctions.BackColor = System.Drawing.SystemColors.Window;
            this.lstAuctions.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstAuctions.Location = new System.Drawing.Point(24, 24);
            this.lstAuctions.Name = "lstAuctions";
            this.lstAuctions.Size = new System.Drawing.Size(292, 342);
            this.lstAuctions.TabIndex = 9;
            this.lstAuctions.DoubleClick += new System.EventHandler(this.lstAuctions_DoubleClick);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(216, 388);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 11;
            // 
            // frmAuctions
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(364, 441);
            this.Controls.Add(this.fraMain);
            this.Controls.Add(this.fraNew);
            this.Controls.Add(this.fraBuy);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAuctions";
            this.Text = "Form1";
            this.fraBuy.ResumeLayout(false);
            this.fraBuy.PerformLayout();
            this.fraNew.ResumeLayout(false);
            this.fraNew.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.fraMain.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		//=========================================================
		private int CurrentAuction; 
        

		private void cmdSave_Click(object sender, System.EventArgs e)
		{
			 int InvNum;
			 int MaxPrice; 
			 int Price; 

			MaxPrice = Convert.ToInt32(Convert.ToDouble(txtMax.Text));
			Price = Convert.ToInt32(Convert.ToDouble(txtPrice.Text));

			InvNum = C_Auction.CurrentAuctionSelections;


			if (InvNum!=0) {
                C_Auction.SendAddAuct(InvNum, Price, MaxPrice);
				fraNew.Visible = false;
				fraMain.Visible = true;
				txtPrice.Text = Convert.ToString(0);
				txtMax.Text = Convert.ToString(0);
                C_Auction.CurrentAuctionSelections = 0;
			}
		}




		private void lstAuctions_DoubleClick(object sender, System.EventArgs e)
		{
			string tmpString = lstAuctions.Items[lstAuctions.SelectedIndex].ToString();


			if (tmpString == "Empty") return;



			CurrentAuction = lstAuctions.SelectedIndex + 1;
            C_Auction.LoadAuctionItem(CurrentAuction);
		}

        private void btnBid_Click(object sender, EventArgs e)
        {
            int Bid;


            if (Convert.ToDouble(txtBid.Text) != 0)
            {
                Bid = Convert.ToInt32(Convert.ToDouble(txtBid.Text));
                fraBuy.Visible = false;
                fraMain.Visible = true;
                C_Auction.SendBid(CurrentAuction, Bid);
            }
        }

        private void btnBuyOut_Click(object sender, EventArgs e)
        {
            C_Auction.SendBid(CurrentAuction, C_Auction.Auction[CurrentAuction].MaxBid);
            fraBuy.Visible = false;
            fraMain.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //frmMain.Show;
            C_Auction.IsPickingItem = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            InstancePtr.fraMain.Visible = false;
            InstancePtr.fraNew.Visible = true;
            InstancePtr.fraBuy.Visible = false;
        }
    }
}