
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ASFW;
using Engine;

namespace Engine
{
	
	public partial class FrmMenu : Form
	{
		public FrmMenu()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmMenu defaultInstance;
		
		/// <summary>
		/// The Instance of this Form
		/// </summary>
		public static FrmMenu Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmMenu();
					defaultInstance.FormClosed += new System.Windows.Forms.FormClosedEventHandler(defaultInstance_FormClosed);
				}
				
				return defaultInstance;
			}
			set
			{
				defaultInstance = value;
			}
		}
		
		static void defaultInstance_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			defaultInstance = null;
		}
		
#endregion
		
#region Form Functions
		
		/// <summary>
		/// clean up and close the game.
		/// </summary>
		public void FrmMenu_Disposed(object sender, EventArgs e)
		{
			C_General.DestroyGame();
		}
		
		/// <summary>
		/// On load, get GUI ready.
		/// </summary>
		public void Frmmenu_Load(object sender, EventArgs e)
		{
			Strings.Init(0, "English");

            LoadMenuGraphics();
			
			pnlLoad.Width = 730;
			pnlLoad.Height = 550;
			
			Width = 730;
			pnlLogin.Top = pnlMainMenu.Top;
			pnlLogin.Left = pnlMainMenu.Left;
			
			pnlNewChar.Top = pnlMainMenu.Top;
			pnlNewChar.Left = pnlMainMenu.Left;
			
			pnlRegister.Top = pnlMainMenu.Top;
			pnlRegister.Left = pnlMainMenu.Left;
			
			pnlCredits.Top = pnlMainMenu.Top;
			pnlCredits.Left = pnlMainMenu.Left;
			
			pnlIPConfig.Top = pnlMainMenu.Top;
			pnlIPConfig.Left = pnlMainMenu.Left;
			
			pnlCharSelect.Top = pnlMainMenu.Top;
			pnlCharSelect.Left = pnlMainMenu.Left;
            
            UI_MainMenu.Initialize();

            if (C_General.Started == false)
			{
				C_General.Startup();
			}
			
			C_NetworkConfig.Connect();
			
		}
		
		/// <summary>
		/// Draw Char select when its needed.
		/// </summary>
		public void PnlCharSelect_VisibleChanged(object sender, EventArgs e)
		{
			DrawCharacterSelect();
		}
		
		/// <summary>
		/// Shows the IP config.
		/// </summary>
		public void LblServerStatus_Click(object sender, EventArgs e)
		{
			C_UpdateUI.PnlCreditsVisible = false;
			C_UpdateUI.PnlLoginVisible = false;
			C_UpdateUI.PnlRegisterVisible = false;
			C_UpdateUI.PnlCharCreateVisible = false;
			
			txtIP.Text = C_Types.Options.Ip;
			txtPort.Text = C_Types.Options.Port.ToString();
			
			pnlIPConfig.Visible = true;
		}
		
#endregion
		
#region Draw Functions
		
		/// <summary>
		/// Preload the images in the menu.
		/// </summary>
		internal void LoadMenuGraphics()
		{
			
			//main menu
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\menu" + C_Constants.GfxExt))
			{
				BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\menu" + C_Constants.GfxExt);
			}
			
			//main menu buttons
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt))
			{
				btnCredits.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
				btnExit.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
				btnLogin.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
				btnPlay.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
				btnRegister.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
				btnNewChar.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
				btnUseChar.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
				btnDelChar.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
				btnCreateAccount.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
				btnSaveIP.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
			}
			
			//main menu panels
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\panel" + C_Constants.GfxExt))
			{
				pnlMainMenu.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\panel" + C_Constants.GfxExt);
				pnlLogin.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\panel" + C_Constants.GfxExt);
				pnlNewChar.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\panel" + C_Constants.GfxExt);
				pnlCharSelect.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\panel" + C_Constants.GfxExt);
				pnlRegister.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\panel" + C_Constants.GfxExt);
				pnlCredits.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\panel" + C_Constants.GfxExt);
				pnlIPConfig.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\panel" + C_Constants.GfxExt);
			}
			
			//logo
			if (File.Exists(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\logo" + C_Constants.GfxExt))
			{
				picLogo.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\logo" + C_Constants.GfxExt);
			}
			
			//set text for controls from language file
			
			//main
			lblStatusHeader.Text = Strings.Get("mainmenu", "serverstatus");
			lblNewsHeader.Text = Strings.Get("mainmenu", "newsheader");
			lblNews.Text = Strings.Get("mainmenu", "news");
			btnPlay.Text = Strings.Get("mainmenu", "buttonplay");
			btnRegister.Text = Strings.Get("mainmenu", "buttonregister");
			btnCredits.Text = Strings.Get("mainmenu", "buttoncredits");
			btnExit.Text = Strings.Get("mainmenu", "buttonexit");
			
			//logon panel
			lblLogin.Text = Strings.Get("mainmenu", "login");
			lblLoginName.Text = Strings.Get("mainmenu", "loginname");
			lblLoginPass.Text = Strings.Get("mainmenu", "loginpass");
			chkSavePass.Text = Strings.Get("mainmenu", "loginchkbox");
			btnLogin.Text = Strings.Get("mainmenu", "loginbutton");
			
			//new char panel
			lblNewChar.Text = Strings.Get("mainmenu", "newchar");
			lblNewCharName.Text = Strings.Get("mainmenu", "newcharname");
			lblNewCharClass.Text = Strings.Get("mainmenu", "newcharclass");
			lblNewCharGender.Text = Strings.Get("mainmenu", "newchargender");
			rdoMale.Text = Strings.Get("mainmenu", "newcharmale");
			rdoFemale.Text = Strings.Get("mainmenu", "newcharfemale");
			lblNewCharSprite.Text = Strings.Get("mainmenu", "newcharsprite");
			btnCreateCharacter.Text = Strings.Get("mainmenu", "newcharbutton");
			
			//char select
			lblCharSelect.Text = Strings.Get("mainmenu", "selchar");
			btnNewChar.Text = Strings.Get("mainmenu", "selcharnew");
			btnUseChar.Text = Strings.Get("mainmenu", "selcharuse");
			btnDelChar.Text = Strings.Get("mainmenu", "selchardel");
			
			//new account
			lblNewAccount.Text = Strings.Get("mainmenu", "newacc");
			lblNewAccName.Text = Strings.Get("mainmenu", "newaccname");
			lblNewAccPass.Text = Strings.Get("mainmenu", "newaccpass");
			lblNewAccPass2.Text = Strings.Get("mainmenu", "newaccpass2");
			
			//credits
			lblCreditsTop.Text = Strings.Get("mainmenu", "credits");
			
			//ip config
			lblIpConfig.Text = Strings.Get("mainmenu", "ipconfig");
			lblIpAdress.Text = Strings.Get("mainmenu", "ipconfigadres");
			lblPort.Text = Strings.Get("mainmenu", "ipconfigport");
		}
		
		/// <summary>
		/// Draw the Character for new char creation.
		/// </summary>
		public void DrawCharacter()
		{
			if (pnlNewChar.Visible == true)
			{
				Graphics g = pnlNewChar.CreateGraphics();
				string filename = "";
				Rectangle srcRect = new Rectangle();
				Rectangle destRect = new Rectangle();
				int charwidth = 0;
				int charheight = 0;
				
				if (C_Variables.NewCharClass == 0)
				{
					C_Variables.NewCharClass = 1;
				}
				if (C_Variables.NewCharSprite == 0)
				{
					C_Variables.NewCharSprite = 1;
				}
				
				if (rdoMale.Checked == true)
				{
					filename = Application.StartupPath + C_Constants.GfxPath + "characters\\" + Types.Classes[C_Variables.NewCharClass].MaleSprite[C_Variables.NewCharSprite] + C_Constants.GfxExt;
				}
				else
				{
					filename = Application.StartupPath + C_Constants.GfxPath + "characters\\" + Types.Classes[C_Variables.NewCharClass].FemaleSprite[C_Variables.NewCharSprite] + C_Constants.GfxExt;
				}
				
				Bitmap charsprite = new Bitmap(filename);
				
				charwidth = System.Convert.ToInt32((double) charsprite.Width / 4);
				charheight = System.Convert.ToInt32((double) charsprite.Height / 4);
				
				srcRect = new Rectangle(0, 0, charwidth, charheight);
				destRect = new Rectangle(placeholderforsprite.Left, placeholderforsprite.Top, charwidth, charheight);
				
				charsprite.MakeTransparent(charsprite.GetPixel(0, 0));
				
				if (charwidth > 32)
				{
					C_UpdateUI.Lblnextcharleft = 100 - (64 - charwidth);
				}
				else
				{
					C_UpdateUI.Lblnextcharleft = 100;
				}
				pnlNewChar.Refresh();
				g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel);
				g.Dispose();
			}
		}
		
		/// <summary>
		/// Draw the character for the char select screen.
		/// </summary>
		public void DrawCharacterSelect()
		{
			Graphics g = default(Graphics);
			Rectangle srcRect = new Rectangle();
			Rectangle destRect = new Rectangle();
			
			if (pnlCharSelect.Visible == true)
			{
				string filename = "";
				int charwidth = 0;
				int charheight = 0;
				
				//first
				if (C_Types.CharSelection[1].Sprite > 0)
				{
					g = picChar1.CreateGraphics();
					
					filename = Application.StartupPath + C_Constants.GfxPath + "characters\\" + System.Convert.ToString(C_Types.CharSelection[1].Sprite) + C_Constants.GfxExt;
					
					Bitmap charsprite = new Bitmap(filename);
					
					charwidth = System.Convert.ToInt32((double) charsprite.Width / 4);
					charheight = System.Convert.ToInt32((double) charsprite.Height / 4);
					
					srcRect = new Rectangle(0, 0, charwidth, charheight);
					destRect = new Rectangle(0, 0, charwidth, charheight);
					
					charsprite.MakeTransparent(charsprite.GetPixel(0, 0));
					
					picChar1.Refresh();
					g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel);
					
					if (C_Variables.SelectedChar == 1)
					{
						g.DrawRectangle(Pens.Red, new Rectangle(0, 0, charwidth - 1, charheight));
					}
					
					g.Dispose();
				}
				else
				{
					picChar1.BorderStyle = BorderStyle.FixedSingle;
					picChar1.Refresh();
				}
				
				//second
				if (C_Types.CharSelection[2].Sprite > 0)
				{
					g = picChar2.CreateGraphics();
					
					filename = Application.StartupPath + C_Constants.GfxPath + "characters\\" + System.Convert.ToString(C_Types.CharSelection[2].Sprite) + C_Constants.GfxExt;
					
					Bitmap charsprite = new Bitmap(filename);
					
					charwidth = System.Convert.ToInt32((double) charsprite.Width / 4);
					charheight = System.Convert.ToInt32((double) charsprite.Height / 4);
					
					srcRect = new Rectangle(0, 0, charwidth, charheight);
					destRect = new Rectangle(0, 0, charwidth, charheight);
					
					charsprite.MakeTransparent(charsprite.GetPixel(0, 0));
					
					picChar2.Refresh();
					g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel);
					
					if (C_Variables.SelectedChar == 2)
					{
						g.DrawRectangle(Pens.Red, new Rectangle(0, 0, charwidth - 1, charheight));
					}
					
					g.Dispose();
				}
				else
				{
					picChar2.BorderStyle = BorderStyle.FixedSingle;
					picChar2.Refresh();
				}
				
				//third
				if (C_Types.CharSelection[3].Sprite > 0)
				{
					g = picChar3.CreateGraphics();
					
					filename = Application.StartupPath + C_Constants.GfxPath + "characters\\" + System.Convert.ToString(C_Types.CharSelection[3].Sprite) + C_Constants.GfxExt;
					
					Bitmap charsprite = new Bitmap(filename);
					
					charwidth = System.Convert.ToInt32((double) charsprite.Width / 4);
					charheight = System.Convert.ToInt32((double) charsprite.Height / 4);
					
					srcRect = new Rectangle(0, 0, charwidth, charheight);
					destRect = new Rectangle(0, 0, charwidth, charheight);
					
					charsprite.MakeTransparent(charsprite.GetPixel(0, 0));
					
					picChar3.Refresh();
					g.DrawImage(charsprite, destRect, srcRect, GraphicsUnit.Pixel);
					
					if (C_Variables.SelectedChar == 3)
					{
						g.DrawRectangle(Pens.Red, new Rectangle(0, 0, charwidth - 1, charheight));
					}
					
					g.Dispose();
				}
				else
				{
					picChar3.BorderStyle = BorderStyle.FixedSingle;
					picChar3.Refresh();
				}
				
			}
		}
		
		/// <summary>
		/// Stop the NewChar panel from repainting itself.
		/// </summary>
		public void PnlNewChar_Paint(object sender, PaintEventArgs e)
		{
			//nada here
		}
		
#endregion
		
#region Credits
		
		/// <summary>
		/// This timer handles the scrolling credits.
		/// </summary>
		public void TmrCredits_Tick(object sender, EventArgs e)
		{
			string credits = "";
			string filepath = "";
			filepath = Application.StartupPath + "\\Data\\credits.txt";
			lblScrollingCredits.Top = 177;
			if (C_UpdateUI.PnlCreditsVisible == true)
			{
				tmrCredits.Enabled = false;
                string refString = "";
				credits = C_DataBase.GetFileContents(filepath, ref refString);
				lblScrollingCredits.Text = "" + Microsoft.VisualBasic.Constants.vbNewLine + credits;
				while (!(C_UpdateUI.PnlCreditsVisible == false))
				{
					lblScrollingCredits.Top--;
					if (lblScrollingCredits.Bottom <= lblCreditsTop.Bottom)
					{
						lblScrollingCredits.Top = 177;
					}
					Application.DoEvents();
					System.Threading.Thread.Sleep(100);
				}
			}
		}
		
#endregion
		
#region Login
		
		/// <summary>
		/// Handles press enter on login name txtbox.
		/// </summary>
		public void TxtLogin_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				BtnLogin_Click(this, null);
			}
		}
		
		/// <summary>
		/// Handles press enter on login password txtbox.
		/// </summary>
		public void TxtPassword_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				BtnLogin_Click(this, null);
			}
		}
		
		/// <summary>
		/// Handle the SavePas checkbox.
		/// </summary>
		public void ChkSavePass_CheckedChanged(object sender, EventArgs e)
		{
			C_UpdateUI.ChkSavePassChecked = chkSavePass.Checked;
		}
		
#endregion
		
#region Char Creation
		
		/// <summary>
		/// Changes selected class.
		/// </summary>
		public void CmbClass_SelectedIndexChanged(object sender, EventArgs e)
		{
			C_Variables.NewCharClass = cmbClass.SelectedIndex + 1;
			txtDescription.Text = Types.Classes[C_Variables.NewCharClass].Desc;
			DrawCharacter();
		}
		
		/// <summary>
		/// Switches to male gender.
		/// </summary>
		public void RdoMale_CheckedChanged(object sender, EventArgs e)
		{
			DrawCharacter();
		}
		
		/// <summary>
		/// Switches to female gender.
		/// </summary>
		public void RdoFemale_CheckedChanged(object sender, EventArgs e)
		{
			DrawCharacter();
		}
		
		/// <summary>
		/// Switches sprite for selected class to next one, if any.
		/// </summary>
		public void LblNextChar_Click(object sender, EventArgs e)
		{
			C_Variables.NewCharSprite++;
			if (rdoMale.Checked == true)
			{
				if (C_Variables.NewCharSprite > Types.Classes[C_Variables.NewCharClass].MaleSprite.Length - 1)
				{
					C_Variables.NewCharSprite = 1;
				}
			}
			else if (rdoFemale.Checked == true)
			{
				if (C_Variables.NewCharSprite > Types.Classes[C_Variables.NewCharClass].FemaleSprite.Length - 1)
				{
					C_Variables.NewCharSprite = 1;
				}
			}
			DrawCharacter();
		}
		
		/// <summary>
		/// Switches sprite for selected class to previous one, if any.
		/// </summary>
		public void LblPrevChar_Click(object sender, EventArgs e)
		{
			C_Variables.NewCharSprite--;
			if (rdoMale.Checked == true)
			{
				if (C_Variables.NewCharSprite == 0)
				{
					C_Variables.NewCharSprite = Types.Classes[C_Variables.NewCharClass].MaleSprite.Length - 1;
				}
			}
			else if (rdoFemale.Checked == true)
			{
				if (C_Variables.NewCharSprite == 0)
				{
					C_Variables.NewCharSprite = Types.Classes[C_Variables.NewCharClass].FemaleSprite.Length - 1;
				}
			}
			DrawCharacter();
		}
		
		/// <summary>
		/// Initial drawing of new char.
		/// </summary>
		public void PnlNewChar_VisibleChanged(object sender, EventArgs e)
		{
			DrawCharacter();
		}
		
#endregion
		
#region Buttons
		
		/// <summary>
		/// Handle Play button press.
		/// </summary>
		public void BtnPlay_Click(object sender, EventArgs e)
		{
			if (C_NetworkConfig.Socket.IsConnected == true)
			{
				C_Sound.PlaySound("Click.ogg");
				C_UpdateUI.PnlRegisterVisible = false;
				C_UpdateUI.PnlLoginVisible = true;
				C_UpdateUI.PnlCharCreateVisible = false;
				C_UpdateUI.PnlCreditsVisible = false;
				pnlIPConfig.Visible = false;
				txtLogin.Focus();
				if (C_Types.Options.SavePass == true)
				{
					txtLogin.Text = C_Types.Options.Username;
					txtPassword.Text = C_Types.Options.Password;
					chkSavePass.Checked = true;
				}
			}
		}
		
		/// <summary>
		/// Changes to hover state on button.
		/// </summary>
		public void BtnPlay_MouseEnter(object sender, EventArgs e)
		{
			btnPlay.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button_hover" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Changes to normal state on button.
		/// </summary>
		public void BtnPlay_MouseLeave(object sender, EventArgs e)
		{
			btnPlay.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Handle Register button press.
		/// </summary>
		public void BtnRegister_Click(object sender, EventArgs e)
		{
			if (C_NetworkConfig.Socket.IsConnected== true)
			{
				C_Sound.PlaySound("Click.ogg");
				C_UpdateUI.PnlRegisterVisible = true;
				C_UpdateUI.PnlLoginVisible = false;
				C_UpdateUI.PnlCharCreateVisible = false;
				C_UpdateUI.PnlCreditsVisible = false;
				pnlIPConfig.Visible = false;
			}
		}
		
		/// <summary>
		/// Changes to hover state on button.
		/// </summary>
		public void BtnRegister_MouseEnter(object sender, EventArgs e)
		{
			btnRegister.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button_hover" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Changes to normal state on button.
		/// </summary>
		public void BtnRegister_MouseLeave(object sender, EventArgs e)
		{
			btnRegister.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Handle Credits button press.
		/// </summary>
		public void BtnCredits_Click(object sender, EventArgs e)
		{
			C_Sound.PlaySound("Click.ogg");
			if (C_UpdateUI.PnlCreditsVisible == false)
			{
				tmrCredits.Enabled = true;
			}
			C_UpdateUI.PnlCreditsVisible = true;
			C_UpdateUI.PnlLoginVisible = false;
			C_UpdateUI.PnlRegisterVisible = false;
			C_UpdateUI.PnlCharCreateVisible = false;
			pnlIPConfig.Visible = false;
		}
		
		/// <summary>
		/// Changes to hover state on button.
		/// </summary>
		public void BtnCredits_MouseEnter(object sender, EventArgs e)
		{
			btnCredits.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button_hover" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Changes to normal state on button.
		/// </summary>
		public void BtnCredits_MouseLeave(object sender, EventArgs e)
		{
			btnCredits.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Handles Exit button press.
		/// </summary>
		public void BtnExit_Click(object sender, EventArgs e)
		{
			C_Sound.PlaySound("Click.ogg");
			C_General.DestroyGame();
		}
		
		/// <summary>
		/// Changes to hover state on button.
		/// </summary>
		public void BtnExit_MouseEnter(object sender, EventArgs e)
		{
			btnExit.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button_hover" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Changes to normal state on button.
		/// </summary>
		public void BtnExit_MouseLeave(object sender, EventArgs e)
		{
			btnExit.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Handles Login button press.
		/// </summary>
		public void BtnLogin_Click(object sender, EventArgs e)
		{
			if (C_General.IsLoginLegal(txtLogin.Text, txtPassword.Text))
			{
				C_General.MenuState(C_Constants.MenuStateLogin);
			}
		}
		
		/// <summary>
		/// Changes to hover state on button.
		/// </summary>
		public void BtnLogin_MouseEnter(object sender, EventArgs e)
		{
			btnLogin.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button_hover" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Changes to normal state on button.
		/// </summary>
		public void BtnLogin_MouseLeave(object sender, EventArgs e)
		{
			btnLogin.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Handles CreateAccount button press.
		/// </summary>
		public void BtnCreateAccount_Click(object sender, EventArgs e)
		{
			string name = "";
			string password = "";
			string passwordAgain = "";
			name = txtRuser.Text.Trim();
			password = txtRPass.Text.Trim();
			passwordAgain = txtRPass2.Text.Trim();
			
			if (C_General.IsLoginLegal(name, password))
			{
				if (password != passwordAgain)
				{
					MessageBox.Show("Passwords don't match.");
					return;
				}
				
				if (!C_General.IsStringLegal(name))
				{
					return;
				}
				
				C_General.MenuState(C_Constants.MenuStateNewaccount);
			}
		}
		
		/// <summary>
		/// Changes to hover state on button.
		/// </summary>
		public void BtnCreateAccount_MouseEnter(object sender, EventArgs e)
		{
			btnCreateAccount.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button_hover" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Changes to normal state on button.
		/// </summary>
		public void BtnCreateAccount_MouseLeave(object sender, EventArgs e)
		{
			btnCreateAccount.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Handles CreateCharacter button press.
		/// </summary>
		public void BtnCreateCharacter_Click(object sender, EventArgs e)
		{
			C_General.MenuState(C_Constants.MenuStateAddchar);
		}
		
		/// <summary>
		/// Changes to hover state on button.
		/// </summary>
		public void BtnCreateCharacter_MouseEnter(object sender, EventArgs e)
		{
			btnCreateCharacter.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button_hover" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Changes to normal state on button.
		/// </summary>
		public void BtnCreateCharacter_MouseLeave(object sender, EventArgs e)
		{
			btnCreateCharacter.BackgroundImage = Image.FromFile(Application.StartupPath + C_Constants.GfxGuiPath + "Menu\\button" + C_Constants.GfxExt);
		}
		
		/// <summary>
		/// Handles SaveIP button press.
		/// </summary>
		public void BtnSaveIP_Click(object sender, EventArgs e)
		{
			C_Types.Options.Ip = System.Convert.ToString(txtIP.Text);
			C_Types.Options.Port = System.Convert.ToInt32(txtPort.Text);
			
			pnlIPConfig.Visible = false;
			C_DataBase.SaveOptions();
		}
		
		/// <summary>
		/// Handles selecting character 1.
		/// </summary>
		public void PicChar1_Click(object sender, EventArgs e)
		{
			C_Variables.SelectedChar = (byte) 1;
			DrawCharacterSelect();
		}
		
		/// <summary>
		/// Handles selecting character 2.
		/// </summary>
		public void PicChar2_Click(object sender, EventArgs e)
		{
			C_Variables.SelectedChar = (byte) 2;
			DrawCharacterSelect();
		}
		
		/// <summary>
		/// Handles selecting character 3.
		/// </summary>
		public void PicChar3_Click(object sender, EventArgs e)
		{
			C_Variables.SelectedChar = (byte) 3;
			DrawCharacterSelect();
		}
		
		/// <summary>
		/// Handles NewChar button press.
		/// </summary>
		public void BtnNewChar_Click(object sender, EventArgs e)
		{
			int i = 0;
			byte newSelectedChar = 0;
			
			newSelectedChar = (byte) 0;
			
			for (i = 1; i <= C_Variables.MaxChars; i++)
			{
				if (string.IsNullOrEmpty(C_Types.CharSelection.ToString()))
				{
					newSelectedChar = (byte) i;
					break;
				}
			}
			
			if (newSelectedChar > 0)
			{
				C_Variables.SelectedChar = newSelectedChar;
			}
			
			C_UpdateUI.PnlCharCreateVisible = true;
			C_UpdateUI.PnlCharSelectVisible = false;
			C_UpdateUI.DrawChar = true;
		}
		
		/// <summary>
		/// Handles UseChar button press.
		/// </summary>
		public void BtnUseChar_Click(object sender, EventArgs e)
		{
			C_UpdateUI.Pnlloadvisible = true;
			C_UpdateUI.Frmmenuvisible = false;
			
			ByteStream buffer = new ByteStream();
			buffer = new ByteStream(8);
			buffer.WriteInt32((System.Int32) Packets.ClientPackets.CUseChar);
			buffer.WriteInt32(C_Variables.SelectedChar);
			C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
			
			buffer.Dispose();
		}
		
		/// <summary>
		/// Handles DelChar button press.
		/// </summary>
		public void BtnDelChar_Click(object sender, EventArgs e)
		{
			DialogResult result1 = MessageBox.Show("Sure you want to delete character " + System.Convert.ToString(C_Variables.SelectedChar) + "?", "You sure?", MessageBoxButtons.YesNo);
			if (result1 == DialogResult.Yes)
			{
				ByteStream buffer = new ByteStream(4);
				buffer.WriteInt32((System.Int32) Packets.ClientPackets.CDelChar);
				buffer.WriteInt32(C_Variables.SelectedChar);
				C_NetworkConfig.Socket.SendData(buffer.Data, buffer.Head);
				buffer.Dispose();
			}
		}
		
#endregion
		
	}
}
