
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using Engine;

namespace Engine
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]public 
	partial class FrmMenu : System.Windows.Forms.Form
	{
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.chkSavePass = new System.Windows.Forms.CheckBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblLoginPass = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lblLoginName = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.pnlRegister = new System.Windows.Forms.Panel();
            this.btnCreateAccount = new System.Windows.Forms.Button();
            this.txtRPass2 = new System.Windows.Forms.TextBox();
            this.lblNewAccPass2 = new System.Windows.Forms.Label();
            this.txtRPass = new System.Windows.Forms.TextBox();
            this.lblNewAccPass = new System.Windows.Forms.Label();
            this.txtRuser = new System.Windows.Forms.TextBox();
            this.lblNewAccName = new System.Windows.Forms.Label();
            this.lblNewAccount = new System.Windows.Forms.Label();
            this.pnlCredits = new System.Windows.Forms.Panel();
            this.lblCreditsTop = new System.Windows.Forms.Label();
            this.lblScrollingCredits = new System.Windows.Forms.Label();
            this.tmrCredits = new System.Windows.Forms.Timer(this.components);
            this.pnlNewChar = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblNewCharSprite = new System.Windows.Forms.Label();
            this.btnCreateCharacter = new System.Windows.Forms.Button();
            this.placeholderforsprite = new System.Windows.Forms.PictureBox();
            this.lblNextChar = new System.Windows.Forms.Label();
            this.lblPrevChar = new System.Windows.Forms.Label();
            this.rdoFemale = new System.Windows.Forms.RadioButton();
            this.rdoMale = new System.Windows.Forms.RadioButton();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.lblNewCharGender = new System.Windows.Forms.Label();
            this.lblNewCharClass = new System.Windows.Forms.Label();
            this.txtCharName = new System.Windows.Forms.TextBox();
            this.lblNewCharName = new System.Windows.Forms.Label();
            this.lblNewChar = new System.Windows.Forms.Label();
            this.lblStatusHeader = new System.Windows.Forms.Label();
            this.lblServerStatus = new System.Windows.Forms.Label();
            this.pnlMainMenu = new System.Windows.Forms.Panel();
            this.lblNewsHeader = new System.Windows.Forms.Label();
            this.lblNews = new System.Windows.Forms.Label();
            this.pnlIPConfig = new System.Windows.Forms.Panel();
            this.btnSaveIP = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblIpAdress = new System.Windows.Forms.Label();
            this.lblIpConfig = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnCredits = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.pnlCharSelect = new System.Windows.Forms.Panel();
            this.btnUseChar = new System.Windows.Forms.Button();
            this.btnDelChar = new System.Windows.Forms.Button();
            this.btnNewChar = new System.Windows.Forms.Button();
            this.picChar3 = new System.Windows.Forms.PictureBox();
            this.picChar2 = new System.Windows.Forms.PictureBox();
            this.picChar1 = new System.Windows.Forms.PictureBox();
            this.lblCharSelect = new System.Windows.Forms.Label();
            this.Label16 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.pnlLoad = new System.Windows.Forms.Panel();
            this.pnlLogin.SuspendLayout();
            this.pnlRegister.SuspendLayout();
            this.pnlCredits.SuspendLayout();
            this.pnlNewChar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.placeholderforsprite)).BeginInit();
            this.pnlMainMenu.SuspendLayout();
            this.pnlIPConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlCharSelect.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChar3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChar1)).BeginInit();
            this.pnlLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLogin
            // 
            this.pnlLogin.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLogin.BackgroundImage")));
            this.pnlLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.chkSavePass);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.lblLoginPass);
            this.pnlLogin.Controls.Add(this.txtLogin);
            this.pnlLogin.Controls.Add(this.lblLoginName);
            this.pnlLogin.Controls.Add(this.lblLogin);
            this.pnlLogin.ForeColor = System.Drawing.Color.White;
            this.pnlLogin.Location = new System.Drawing.Point(737, 6);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(400, 192);
            this.pnlLogin.TabIndex = 37;
            this.pnlLogin.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnLogin.BackgroundImage")));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnLogin.Location = new System.Drawing.Point(180, 153);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(110, 26);
            this.btnLogin.TabIndex = 49;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            this.btnLogin.MouseEnter += new System.EventHandler(this.BtnLogin_MouseEnter);
            this.btnLogin.MouseLeave += new System.EventHandler(this.BtnLogin_MouseLeave);
            // 
            // chkSavePass
            // 
            this.chkSavePass.AutoSize = true;
            this.chkSavePass.BackColor = System.Drawing.Color.Transparent;
            this.chkSavePass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSavePass.Location = new System.Drawing.Point(110, 128);
            this.chkSavePass.Name = "chkSavePass";
            this.chkSavePass.Size = new System.Drawing.Size(123, 21);
            this.chkSavePass.TabIndex = 25;
            this.chkSavePass.Text = "Save Password?";
            this.chkSavePass.UseVisualStyleBackColor = false;
            this.chkSavePass.CheckedChanged += new System.EventHandler(this.ChkSavePass_CheckedChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(180, 98);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(110, 25);
            this.txtPassword.TabIndex = 24;
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtPassword_KeyDown);
            // 
            // lblLoginPass
            // 
            this.lblLoginPass.AutoSize = true;
            this.lblLoginPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginPass.Location = new System.Drawing.Point(107, 101);
            this.lblLoginPass.Name = "lblLoginPass";
            this.lblLoginPass.Size = new System.Drawing.Size(70, 17);
            this.lblLoginPass.TabIndex = 23;
            this.lblLoginPass.Text = "Password:";
            // 
            // txtLogin
            // 
            this.txtLogin.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLogin.Location = new System.Drawing.Point(180, 63);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(110, 25);
            this.txtLogin.TabIndex = 17;
            this.txtLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtLogin_KeyDown);
            // 
            // lblLoginName
            // 
            this.lblLoginName.AutoSize = true;
            this.lblLoginName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginName.Location = new System.Drawing.Point(107, 66);
            this.lblLoginName.Name = "lblLoginName";
            this.lblLoginName.Size = new System.Drawing.Size(48, 17);
            this.lblLoginName.TabIndex = 16;
            this.lblLoginName.Text = "Name:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Segoe UI Semibold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.Location = new System.Drawing.Point(156, 9);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(85, 37);
            this.lblLogin.TabIndex = 15;
            this.lblLogin.Text = "Login";
            // 
            // pnlRegister
            // 
            this.pnlRegister.BackColor = System.Drawing.Color.Transparent;
            this.pnlRegister.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlRegister.BackgroundImage")));
            this.pnlRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlRegister.Controls.Add(this.btnCreateAccount);
            this.pnlRegister.Controls.Add(this.txtRPass2);
            this.pnlRegister.Controls.Add(this.lblNewAccPass2);
            this.pnlRegister.Controls.Add(this.txtRPass);
            this.pnlRegister.Controls.Add(this.lblNewAccPass);
            this.pnlRegister.Controls.Add(this.txtRuser);
            this.pnlRegister.Controls.Add(this.lblNewAccName);
            this.pnlRegister.Controls.Add(this.lblNewAccount);
            this.pnlRegister.ForeColor = System.Drawing.Color.White;
            this.pnlRegister.Location = new System.Drawing.Point(1143, 6);
            this.pnlRegister.Name = "pnlRegister";
            this.pnlRegister.Size = new System.Drawing.Size(400, 192);
            this.pnlRegister.TabIndex = 38;
            this.pnlRegister.Visible = false;
            // 
            // btnCreateAccount
            // 
            this.btnCreateAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreateAccount.BackgroundImage")));
            this.btnCreateAccount.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateAccount.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateAccount.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateAccount.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCreateAccount.Location = new System.Drawing.Point(180, 157);
            this.btnCreateAccount.Name = "btnCreateAccount";
            this.btnCreateAccount.Size = new System.Drawing.Size(110, 26);
            this.btnCreateAccount.TabIndex = 23;
            this.btnCreateAccount.Text = "Create Account";
            this.btnCreateAccount.UseVisualStyleBackColor = true;
            this.btnCreateAccount.Click += new System.EventHandler(this.BtnCreateAccount_Click);
            this.btnCreateAccount.MouseEnter += new System.EventHandler(this.BtnCreateAccount_MouseEnter);
            this.btnCreateAccount.MouseLeave += new System.EventHandler(this.BtnCreateAccount_MouseLeave);
            // 
            // txtRPass2
            // 
            this.txtRPass2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRPass2.Location = new System.Drawing.Point(180, 125);
            this.txtRPass2.Name = "txtRPass2";
            this.txtRPass2.PasswordChar = '*';
            this.txtRPass2.Size = new System.Drawing.Size(110, 25);
            this.txtRPass2.TabIndex = 21;
            // 
            // lblNewAccPass2
            // 
            this.lblNewAccPass2.AutoSize = true;
            this.lblNewAccPass2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAccPass2.Location = new System.Drawing.Point(70, 128);
            this.lblNewAccPass2.Name = "lblNewAccPass2";
            this.lblNewAccPass2.Size = new System.Drawing.Size(116, 17);
            this.lblNewAccPass2.TabIndex = 20;
            this.lblNewAccPass2.Text = "Retype Password:";
            // 
            // txtRPass
            // 
            this.txtRPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRPass.Location = new System.Drawing.Point(180, 97);
            this.txtRPass.Name = "txtRPass";
            this.txtRPass.PasswordChar = '*';
            this.txtRPass.Size = new System.Drawing.Size(110, 25);
            this.txtRPass.TabIndex = 19;
            // 
            // lblNewAccPass
            // 
            this.lblNewAccPass.AutoSize = true;
            this.lblNewAccPass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAccPass.Location = new System.Drawing.Point(107, 100);
            this.lblNewAccPass.Name = "lblNewAccPass";
            this.lblNewAccPass.Size = new System.Drawing.Size(70, 17);
            this.lblNewAccPass.TabIndex = 18;
            this.lblNewAccPass.Text = "Password:";
            // 
            // txtRuser
            // 
            this.txtRuser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRuser.Location = new System.Drawing.Point(180, 63);
            this.txtRuser.Name = "txtRuser";
            this.txtRuser.Size = new System.Drawing.Size(110, 25);
            this.txtRuser.TabIndex = 17;
            // 
            // lblNewAccName
            // 
            this.lblNewAccName.AutoSize = true;
            this.lblNewAccName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAccName.Location = new System.Drawing.Point(107, 65);
            this.lblNewAccName.Name = "lblNewAccName";
            this.lblNewAccName.Size = new System.Drawing.Size(73, 17);
            this.lblNewAccName.TabIndex = 16;
            this.lblNewAccName.Text = "Username:";
            // 
            // lblNewAccount
            // 
            this.lblNewAccount.AutoSize = true;
            this.lblNewAccount.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewAccount.Location = new System.Drawing.Point(122, 12);
            this.lblNewAccount.Name = "lblNewAccount";
            this.lblNewAccount.Size = new System.Drawing.Size(192, 40);
            this.lblNewAccount.TabIndex = 15;
            this.lblNewAccount.Text = "New Account";
            // 
            // pnlCredits
            // 
            this.pnlCredits.BackColor = System.Drawing.Color.Transparent;
            this.pnlCredits.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlCredits.BackgroundImage")));
            this.pnlCredits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCredits.Controls.Add(this.lblCreditsTop);
            this.pnlCredits.Controls.Add(this.lblScrollingCredits);
            this.pnlCredits.ForeColor = System.Drawing.Color.White;
            this.pnlCredits.Location = new System.Drawing.Point(1143, 204);
            this.pnlCredits.Name = "pnlCredits";
            this.pnlCredits.Size = new System.Drawing.Size(400, 192);
            this.pnlCredits.TabIndex = 39;
            this.pnlCredits.Visible = false;
            // 
            // lblCreditsTop
            // 
            this.lblCreditsTop.BackColor = System.Drawing.Color.Transparent;
            this.lblCreditsTop.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditsTop.Location = new System.Drawing.Point(78, 6);
            this.lblCreditsTop.Name = "lblCreditsTop";
            this.lblCreditsTop.Size = new System.Drawing.Size(247, 33);
            this.lblCreditsTop.TabIndex = 15;
            this.lblCreditsTop.Text = "Credits";
            this.lblCreditsTop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblScrollingCredits
            // 
            this.lblScrollingCredits.AutoSize = true;
            this.lblScrollingCredits.BackColor = System.Drawing.Color.Transparent;
            this.lblScrollingCredits.Location = new System.Drawing.Point(70, 179);
            this.lblScrollingCredits.Name = "lblScrollingCredits";
            this.lblScrollingCredits.Size = new System.Drawing.Size(0, 13);
            this.lblScrollingCredits.TabIndex = 17;
            this.lblScrollingCredits.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tmrCredits
            // 
            this.tmrCredits.Enabled = true;
            this.tmrCredits.Interval = 1000;
            this.tmrCredits.Tick += new System.EventHandler(this.TmrCredits_Tick);
            // 
            // pnlNewChar
            // 
            this.pnlNewChar.BackColor = System.Drawing.Color.Transparent;
            this.pnlNewChar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlNewChar.BackgroundImage")));
            this.pnlNewChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlNewChar.Controls.Add(this.txtDescription);
            this.pnlNewChar.Controls.Add(this.lblNewCharSprite);
            this.pnlNewChar.Controls.Add(this.btnCreateCharacter);
            this.pnlNewChar.Controls.Add(this.placeholderforsprite);
            this.pnlNewChar.Controls.Add(this.lblNextChar);
            this.pnlNewChar.Controls.Add(this.lblPrevChar);
            this.pnlNewChar.Controls.Add(this.rdoFemale);
            this.pnlNewChar.Controls.Add(this.rdoMale);
            this.pnlNewChar.Controls.Add(this.cmbClass);
            this.pnlNewChar.Controls.Add(this.lblNewCharGender);
            this.pnlNewChar.Controls.Add(this.lblNewCharClass);
            this.pnlNewChar.Controls.Add(this.txtCharName);
            this.pnlNewChar.Controls.Add(this.lblNewCharName);
            this.pnlNewChar.Controls.Add(this.lblNewChar);
            this.pnlNewChar.ForeColor = System.Drawing.Color.White;
            this.pnlNewChar.Location = new System.Drawing.Point(737, 204);
            this.pnlNewChar.Name = "pnlNewChar";
            this.pnlNewChar.Size = new System.Drawing.Size(400, 192);
            this.pnlNewChar.TabIndex = 43;
            this.pnlNewChar.Visible = false;
            this.pnlNewChar.VisibleChanged += new System.EventHandler(this.PnlNewChar_VisibleChanged);
            this.pnlNewChar.Paint += new System.Windows.Forms.PaintEventHandler(this.PnlNewChar_Paint);
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(227, 76);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(157, 62);
            this.txtDescription.TabIndex = 44;
            // 
            // lblNewCharSprite
            // 
            this.lblNewCharSprite.AutoSize = true;
            this.lblNewCharSprite.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCharSprite.Location = new System.Drawing.Point(49, 71);
            this.lblNewCharSprite.Name = "lblNewCharSprite";
            this.lblNewCharSprite.Size = new System.Drawing.Size(42, 17);
            this.lblNewCharSprite.TabIndex = 43;
            this.lblNewCharSprite.Text = "Sprite";
            // 
            // btnCreateCharacter
            // 
            this.btnCreateCharacter.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreateCharacter.BackgroundImage")));
            this.btnCreateCharacter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCreateCharacter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCreateCharacter.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateCharacter.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCreateCharacter.Location = new System.Drawing.Point(263, 150);
            this.btnCreateCharacter.Name = "btnCreateCharacter";
            this.btnCreateCharacter.Size = new System.Drawing.Size(121, 26);
            this.btnCreateCharacter.TabIndex = 42;
            this.btnCreateCharacter.Text = "Create Character";
            this.btnCreateCharacter.UseVisualStyleBackColor = true;
            this.btnCreateCharacter.Click += new System.EventHandler(this.BtnCreateCharacter_Click);
            this.btnCreateCharacter.MouseEnter += new System.EventHandler(this.BtnCreateCharacter_MouseEnter);
            this.btnCreateCharacter.MouseLeave += new System.EventHandler(this.BtnCreateCharacter_MouseLeave);
            // 
            // placeholderforsprite
            // 
            this.placeholderforsprite.Location = new System.Drawing.Point(50, 91);
            this.placeholderforsprite.Name = "placeholderforsprite";
            this.placeholderforsprite.Size = new System.Drawing.Size(48, 60);
            this.placeholderforsprite.TabIndex = 41;
            this.placeholderforsprite.TabStop = false;
            this.placeholderforsprite.Visible = false;
            // 
            // lblNextChar
            // 
            this.lblNextChar.AutoSize = true;
            this.lblNextChar.Location = new System.Drawing.Point(100, 156);
            this.lblNextChar.Name = "lblNextChar";
            this.lblNextChar.Size = new System.Drawing.Size(15, 13);
            this.lblNextChar.TabIndex = 40;
            this.lblNextChar.Text = ">";
            this.lblNextChar.Click += new System.EventHandler(this.LblNextChar_Click);
            // 
            // lblPrevChar
            // 
            this.lblPrevChar.AutoSize = true;
            this.lblPrevChar.Location = new System.Drawing.Point(37, 156);
            this.lblPrevChar.Name = "lblPrevChar";
            this.lblPrevChar.Size = new System.Drawing.Size(15, 13);
            this.lblPrevChar.TabIndex = 39;
            this.lblPrevChar.Text = "<";
            this.lblPrevChar.Click += new System.EventHandler(this.LblPrevChar_Click);
            // 
            // rdoFemale
            // 
            this.rdoFemale.AutoSize = true;
            this.rdoFemale.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoFemale.Location = new System.Drawing.Point(135, 118);
            this.rdoFemale.Name = "rdoFemale";
            this.rdoFemale.Size = new System.Drawing.Size(67, 21);
            this.rdoFemale.TabIndex = 38;
            this.rdoFemale.TabStop = true;
            this.rdoFemale.Text = "Female";
            this.rdoFemale.UseVisualStyleBackColor = true;
            this.rdoFemale.CheckedChanged += new System.EventHandler(this.RdoFemale_CheckedChanged);
            // 
            // rdoMale
            // 
            this.rdoMale.AutoSize = true;
            this.rdoMale.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoMale.Location = new System.Drawing.Point(135, 93);
            this.rdoMale.Name = "rdoMale";
            this.rdoMale.Size = new System.Drawing.Size(55, 21);
            this.rdoMale.TabIndex = 37;
            this.rdoMale.TabStop = true;
            this.rdoMale.Text = "Male";
            this.rdoMale.UseVisualStyleBackColor = true;
            this.rdoMale.CheckedChanged += new System.EventHandler(this.RdoMale_CheckedChanged);
            // 
            // cmbClass
            // 
            this.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Location = new System.Drawing.Point(227, 43);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(157, 25);
            this.cmbClass.TabIndex = 36;
            this.cmbClass.SelectedIndexChanged += new System.EventHandler(this.CmbClass_SelectedIndexChanged);
            // 
            // lblNewCharGender
            // 
            this.lblNewCharGender.AutoSize = true;
            this.lblNewCharGender.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCharGender.Location = new System.Drawing.Point(133, 75);
            this.lblNewCharGender.Name = "lblNewCharGender";
            this.lblNewCharGender.Size = new System.Drawing.Size(54, 17);
            this.lblNewCharGender.TabIndex = 34;
            this.lblNewCharGender.Text = "Gender:";
            // 
            // lblNewCharClass
            // 
            this.lblNewCharClass.AutoSize = true;
            this.lblNewCharClass.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCharClass.Location = new System.Drawing.Point(186, 45);
            this.lblNewCharClass.Name = "lblNewCharClass";
            this.lblNewCharClass.Size = new System.Drawing.Size(41, 17);
            this.lblNewCharClass.TabIndex = 33;
            this.lblNewCharClass.Text = "Class:";
            // 
            // txtCharName
            // 
            this.txtCharName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCharName.Location = new System.Drawing.Point(59, 42);
            this.txtCharName.Name = "txtCharName";
            this.txtCharName.Size = new System.Drawing.Size(121, 25);
            this.txtCharName.TabIndex = 32;
            // 
            // lblNewCharName
            // 
            this.lblNewCharName.AutoSize = true;
            this.lblNewCharName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewCharName.ForeColor = System.Drawing.Color.White;
            this.lblNewCharName.Location = new System.Drawing.Point(13, 45);
            this.lblNewCharName.Name = "lblNewCharName";
            this.lblNewCharName.Size = new System.Drawing.Size(46, 17);
            this.lblNewCharName.TabIndex = 31;
            this.lblNewCharName.Text = "Name:";
            // 
            // lblNewChar
            // 
            this.lblNewChar.AutoSize = true;
            this.lblNewChar.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewChar.ForeColor = System.Drawing.Color.White;
            this.lblNewChar.Location = new System.Drawing.Point(85, 1);
            this.lblNewChar.Name = "lblNewChar";
            this.lblNewChar.Size = new System.Drawing.Size(235, 40);
            this.lblNewChar.TabIndex = 30;
            this.lblNewChar.Text = "Create Character";
            // 
            // lblStatusHeader
            // 
            this.lblStatusHeader.AutoSize = true;
            this.lblStatusHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusHeader.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusHeader.ForeColor = System.Drawing.Color.White;
            this.lblStatusHeader.Location = new System.Drawing.Point(482, 9);
            this.lblStatusHeader.Name = "lblStatusHeader";
            this.lblStatusHeader.Size = new System.Drawing.Size(113, 21);
            this.lblStatusHeader.TabIndex = 44;
            this.lblStatusHeader.Text = "Server Status:";
            // 
            // lblServerStatus
            // 
            this.lblServerStatus.AutoSize = true;
            this.lblServerStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblServerStatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServerStatus.ForeColor = System.Drawing.Color.Red;
            this.lblServerStatus.Location = new System.Drawing.Point(589, 9);
            this.lblServerStatus.Name = "lblServerStatus";
            this.lblServerStatus.Size = new System.Drawing.Size(63, 21);
            this.lblServerStatus.TabIndex = 45;
            this.lblServerStatus.Text = "Offline";
            this.lblServerStatus.Click += new System.EventHandler(this.LblServerStatus_Click);
            // 
            // pnlMainMenu
            // 
            this.pnlMainMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMainMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlMainMenu.BackgroundImage")));
            this.pnlMainMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlMainMenu.Controls.Add(this.lblNewsHeader);
            this.pnlMainMenu.Controls.Add(this.lblNews);
            this.pnlMainMenu.ForeColor = System.Drawing.Color.White;
            this.pnlMainMenu.Location = new System.Drawing.Point(160, 180);
            this.pnlMainMenu.Name = "pnlMainMenu";
            this.pnlMainMenu.Size = new System.Drawing.Size(400, 192);
            this.pnlMainMenu.TabIndex = 46;
            // 
            // lblNewsHeader
            // 
            this.lblNewsHeader.AutoSize = true;
            this.lblNewsHeader.BackColor = System.Drawing.Color.Transparent;
            this.lblNewsHeader.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewsHeader.Location = new System.Drawing.Point(112, 16);
            this.lblNewsHeader.Name = "lblNewsHeader";
            this.lblNewsHeader.Size = new System.Drawing.Size(171, 40);
            this.lblNewsHeader.TabIndex = 36;
            this.lblNewsHeader.Text = "Latest News";
            // 
            // lblNews
            // 
            this.lblNews.BackColor = System.Drawing.Color.Transparent;
            this.lblNews.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNews.Location = new System.Drawing.Point(17, 55);
            this.lblNews.Name = "lblNews";
            this.lblNews.Size = new System.Drawing.Size(366, 121);
            this.lblNews.TabIndex = 37;
            this.lblNews.Text = resources.GetString("lblNews.Text");
            this.lblNews.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnlIPConfig
            // 
            this.pnlIPConfig.BackColor = System.Drawing.Color.Transparent;
            this.pnlIPConfig.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlIPConfig.BackgroundImage")));
            this.pnlIPConfig.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlIPConfig.Controls.Add(this.btnSaveIP);
            this.pnlIPConfig.Controls.Add(this.txtPort);
            this.pnlIPConfig.Controls.Add(this.lblPort);
            this.pnlIPConfig.Controls.Add(this.txtIP);
            this.pnlIPConfig.Controls.Add(this.lblIpAdress);
            this.pnlIPConfig.Controls.Add(this.lblIpConfig);
            this.pnlIPConfig.Controls.Add(this.Label13);
            this.pnlIPConfig.ForeColor = System.Drawing.Color.White;
            this.pnlIPConfig.Location = new System.Drawing.Point(1143, 402);
            this.pnlIPConfig.Name = "pnlIPConfig";
            this.pnlIPConfig.Size = new System.Drawing.Size(400, 133);
            this.pnlIPConfig.TabIndex = 51;
            this.pnlIPConfig.Visible = false;
            // 
            // btnSaveIP
            // 
            this.btnSaveIP.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSaveIP.BackgroundImage")));
            this.btnSaveIP.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSaveIP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSaveIP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveIP.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSaveIP.Location = new System.Drawing.Point(157, 101);
            this.btnSaveIP.Name = "btnSaveIP";
            this.btnSaveIP.Size = new System.Drawing.Size(110, 22);
            this.btnSaveIP.TabIndex = 50;
            this.btnSaveIP.Text = "Save IP";
            this.btnSaveIP.UseVisualStyleBackColor = true;
            this.btnSaveIP.Click += new System.EventHandler(this.BtnSaveIP_Click);
            // 
            // txtPort
            // 
            this.txtPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPort.Location = new System.Drawing.Point(157, 71);
            this.txtPort.Name = "txtPort";
            this.txtPort.PasswordChar = '*';
            this.txtPort.Size = new System.Drawing.Size(110, 25);
            this.txtPort.TabIndex = 28;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPort.Location = new System.Drawing.Point(84, 74);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(35, 17);
            this.lblPort.TabIndex = 27;
            this.lblPort.Text = "Port:";
            // 
            // txtIP
            // 
            this.txtIP.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIP.Location = new System.Drawing.Point(157, 39);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(192, 25);
            this.txtIP.TabIndex = 26;
            // 
            // lblIpAdress
            // 
            this.lblIpAdress.AutoSize = true;
            this.lblIpAdress.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpAdress.Location = new System.Drawing.Point(84, 42);
            this.lblIpAdress.Name = "lblIpAdress";
            this.lblIpAdress.Size = new System.Drawing.Size(59, 17);
            this.lblIpAdress.TabIndex = 25;
            this.lblIpAdress.Text = "IP Adres:";
            // 
            // lblIpConfig
            // 
            this.lblIpConfig.BackColor = System.Drawing.Color.Transparent;
            this.lblIpConfig.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIpConfig.Location = new System.Drawing.Point(86, 4);
            this.lblIpConfig.Name = "lblIpConfig";
            this.lblIpConfig.Size = new System.Drawing.Size(247, 32);
            this.lblIpConfig.TabIndex = 15;
            this.lblIpConfig.Text = "IPConfig";
            this.lblIpConfig.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.BackColor = System.Drawing.Color.Transparent;
            this.Label13.Location = new System.Drawing.Point(70, 179);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(0, 13);
            this.Label13.TabIndex = 17;
            this.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.Transparent;
            this.picLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("picLogo.BackgroundImage")));
            this.picLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picLogo.Location = new System.Drawing.Point(77, 30);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(560, 144);
            this.picLogo.TabIndex = 52;
            this.picLogo.TabStop = false;
            // 
            // btnPlay
            // 
            this.btnPlay.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPlay.BackgroundImage")));
            this.btnPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnPlay.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPlay.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPlay.ForeColor = System.Drawing.Color.White;
            this.btnPlay.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnPlay.Location = new System.Drawing.Point(142, 490);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(106, 37);
            this.btnPlay.TabIndex = 53;
            this.btnPlay.Text = "Play";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.BtnPlay_Click);
            this.btnPlay.MouseEnter += new System.EventHandler(this.BtnPlay_MouseEnter);
            this.btnPlay.MouseLeave += new System.EventHandler(this.BtnPlay_MouseLeave);
            // 
            // btnRegister
            // 
            this.btnRegister.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRegister.BackgroundImage")));
            this.btnRegister.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRegister.Location = new System.Drawing.Point(254, 490);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(106, 37);
            this.btnRegister.TabIndex = 54;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.BtnRegister_Click);
            this.btnRegister.MouseEnter += new System.EventHandler(this.BtnRegister_MouseEnter);
            this.btnRegister.MouseLeave += new System.EventHandler(this.BtnRegister_MouseLeave);
            // 
            // btnCredits
            // 
            this.btnCredits.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCredits.BackgroundImage")));
            this.btnCredits.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCredits.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCredits.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCredits.ForeColor = System.Drawing.Color.White;
            this.btnCredits.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCredits.Location = new System.Drawing.Point(366, 490);
            this.btnCredits.Name = "btnCredits";
            this.btnCredits.Size = new System.Drawing.Size(106, 37);
            this.btnCredits.TabIndex = 55;
            this.btnCredits.Text = "Credits";
            this.btnCredits.UseVisualStyleBackColor = true;
            this.btnCredits.Click += new System.EventHandler(this.BtnCredits_Click);
            this.btnCredits.MouseEnter += new System.EventHandler(this.BtnCredits_MouseEnter);
            this.btnCredits.MouseLeave += new System.EventHandler(this.BtnCredits_MouseLeave);
            // 
            // btnExit
            // 
            this.btnExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExit.BackgroundImage")));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnExit.Location = new System.Drawing.Point(478, 490);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(106, 37);
            this.btnExit.TabIndex = 56;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.BtnExit_Click);
            this.btnExit.MouseEnter += new System.EventHandler(this.BtnExit_MouseEnter);
            this.btnExit.MouseLeave += new System.EventHandler(this.BtnExit_MouseLeave);
            // 
            // pnlCharSelect
            // 
            this.pnlCharSelect.BackColor = System.Drawing.Color.Transparent;
            this.pnlCharSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlCharSelect.BackgroundImage")));
            this.pnlCharSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlCharSelect.Controls.Add(this.btnUseChar);
            this.pnlCharSelect.Controls.Add(this.btnDelChar);
            this.pnlCharSelect.Controls.Add(this.btnNewChar);
            this.pnlCharSelect.Controls.Add(this.picChar3);
            this.pnlCharSelect.Controls.Add(this.picChar2);
            this.pnlCharSelect.Controls.Add(this.picChar1);
            this.pnlCharSelect.Controls.Add(this.lblCharSelect);
            this.pnlCharSelect.Controls.Add(this.Label16);
            this.pnlCharSelect.ForeColor = System.Drawing.Color.White;
            this.pnlCharSelect.Location = new System.Drawing.Point(737, 342);
            this.pnlCharSelect.Name = "pnlCharSelect";
            this.pnlCharSelect.Size = new System.Drawing.Size(400, 192);
            this.pnlCharSelect.TabIndex = 57;
            this.pnlCharSelect.Visible = false;
            this.pnlCharSelect.VisibleChanged += new System.EventHandler(this.PnlCharSelect_VisibleChanged);
            // 
            // btnUseChar
            // 
            this.btnUseChar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUseChar.BackgroundImage")));
            this.btnUseChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUseChar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnUseChar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUseChar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnUseChar.Location = new System.Drawing.Point(147, 154);
            this.btnUseChar.Name = "btnUseChar";
            this.btnUseChar.Size = new System.Drawing.Size(110, 26);
            this.btnUseChar.TabIndex = 52;
            this.btnUseChar.Text = "Use Character";
            this.btnUseChar.UseVisualStyleBackColor = true;
            this.btnUseChar.Click += new System.EventHandler(this.BtnUseChar_Click);
            // 
            // btnDelChar
            // 
            this.btnDelChar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDelChar.BackgroundImage")));
            this.btnDelChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDelChar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelChar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelChar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnDelChar.Location = new System.Drawing.Point(263, 154);
            this.btnDelChar.Name = "btnDelChar";
            this.btnDelChar.Size = new System.Drawing.Size(119, 26);
            this.btnDelChar.TabIndex = 51;
            this.btnDelChar.Text = "Delete Character";
            this.btnDelChar.UseVisualStyleBackColor = true;
            this.btnDelChar.Click += new System.EventHandler(this.BtnDelChar_Click);
            // 
            // btnNewChar
            // 
            this.btnNewChar.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNewChar.BackgroundImage")));
            this.btnNewChar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnNewChar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNewChar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewChar.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnNewChar.Location = new System.Drawing.Point(20, 154);
            this.btnNewChar.Name = "btnNewChar";
            this.btnNewChar.Size = new System.Drawing.Size(121, 26);
            this.btnNewChar.TabIndex = 50;
            this.btnNewChar.Text = "New Character";
            this.btnNewChar.UseVisualStyleBackColor = true;
            this.btnNewChar.Click += new System.EventHandler(this.BtnNewChar_Click);
            // 
            // picChar3
            // 
            this.picChar3.BackColor = System.Drawing.Color.Transparent;
            this.picChar3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picChar3.Location = new System.Drawing.Point(300, 52);
            this.picChar3.Name = "picChar3";
            this.picChar3.Size = new System.Drawing.Size(48, 60);
            this.picChar3.TabIndex = 44;
            this.picChar3.TabStop = false;
            this.picChar3.Click += new System.EventHandler(this.PicChar3_Click);
            // 
            // picChar2
            // 
            this.picChar2.BackColor = System.Drawing.Color.Transparent;
            this.picChar2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picChar2.Location = new System.Drawing.Point(175, 52);
            this.picChar2.Name = "picChar2";
            this.picChar2.Size = new System.Drawing.Size(48, 60);
            this.picChar2.TabIndex = 43;
            this.picChar2.TabStop = false;
            this.picChar2.Click += new System.EventHandler(this.PicChar2_Click);
            // 
            // picChar1
            // 
            this.picChar1.BackColor = System.Drawing.Color.Transparent;
            this.picChar1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.picChar1.Location = new System.Drawing.Point(52, 52);
            this.picChar1.Name = "picChar1";
            this.picChar1.Size = new System.Drawing.Size(48, 60);
            this.picChar1.TabIndex = 42;
            this.picChar1.TabStop = false;
            this.picChar1.Click += new System.EventHandler(this.PicChar1_Click);
            // 
            // lblCharSelect
            // 
            this.lblCharSelect.BackColor = System.Drawing.Color.Transparent;
            this.lblCharSelect.Font = new System.Drawing.Font("Segoe UI Semibold", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCharSelect.Location = new System.Drawing.Point(44, 12);
            this.lblCharSelect.Name = "lblCharSelect";
            this.lblCharSelect.Size = new System.Drawing.Size(312, 33);
            this.lblCharSelect.TabIndex = 15;
            this.lblCharSelect.Text = "Character Selection";
            this.lblCharSelect.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Label16
            // 
            this.Label16.AutoSize = true;
            this.Label16.BackColor = System.Drawing.Color.Transparent;
            this.Label16.Location = new System.Drawing.Point(70, 179);
            this.Label16.Name = "Label16";
            this.Label16.Size = new System.Drawing.Size(0, 13);
            this.Label16.TabIndex = 17;
            this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.White;
            this.lblStatus.Location = new System.Drawing.Point(224, 261);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(280, 30);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Loading text";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlLoad
            // 
            this.pnlLoad.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pnlLoad.BackgroundImage")));
            this.pnlLoad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLoad.Controls.Add(this.lblStatus);
            this.pnlLoad.Location = new System.Drawing.Point(-2, 1);
            this.pnlLoad.Name = "pnlLoad";
            this.pnlLoad.Size = new System.Drawing.Size(54, 48);
            this.pnlLoad.TabIndex = 58;
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1100, 541);
            this.Controls.Add(this.pnlCharSelect);
            this.Controls.Add(this.pnlNewChar);
            this.Controls.Add(this.pnlLoad);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCredits);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.pnlIPConfig);
            this.Controls.Add(this.lblServerStatus);
            this.Controls.Add(this.lblStatusHeader);
            this.Controls.Add(this.pnlCredits);
            this.Controls.Add(this.pnlRegister);
            this.Controls.Add(this.pnlLogin);
            this.Controls.Add(this.pnlMainMenu);
            this.Controls.Add(this.picLogo);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMenu";
            this.Load += new System.EventHandler(this.Frmmenu_Load);
            this.Disposed += new System.EventHandler(this.FrmMenu_Disposed);
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlRegister.ResumeLayout(false);
            this.pnlRegister.PerformLayout();
            this.pnlCredits.ResumeLayout(false);
            this.pnlCredits.PerformLayout();
            this.pnlNewChar.ResumeLayout(false);
            this.pnlNewChar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.placeholderforsprite)).EndInit();
            this.pnlMainMenu.ResumeLayout(false);
            this.pnlMainMenu.PerformLayout();
            this.pnlIPConfig.ResumeLayout(false);
            this.pnlIPConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlCharSelect.ResumeLayout(false);
            this.pnlCharSelect.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picChar3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChar1)).EndInit();
            this.pnlLoad.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Panel pnlLogin;
		internal System.Windows.Forms.CheckBox chkSavePass;
		internal System.Windows.Forms.TextBox txtPassword;
		internal System.Windows.Forms.Label lblLoginPass;
		internal System.Windows.Forms.TextBox txtLogin;
		internal System.Windows.Forms.Label lblLoginName;
		internal System.Windows.Forms.Label lblLogin;
		internal System.Windows.Forms.Panel pnlRegister;
		internal System.Windows.Forms.TextBox txtRPass2;
		internal System.Windows.Forms.Label lblNewAccPass2;
		internal System.Windows.Forms.TextBox txtRPass;
		internal System.Windows.Forms.Label lblNewAccPass;
		internal System.Windows.Forms.TextBox txtRuser;
		internal System.Windows.Forms.Label lblNewAccName;
		internal System.Windows.Forms.Label lblNewAccount;
		internal System.Windows.Forms.Panel pnlCredits;
		internal System.Windows.Forms.Label lblCreditsTop;
		internal System.Windows.Forms.Label lblScrollingCredits;
		internal System.Windows.Forms.Timer tmrCredits;
		internal System.Windows.Forms.Panel pnlNewChar;
		internal System.Windows.Forms.PictureBox placeholderforsprite;
		internal System.Windows.Forms.Label lblNextChar;
		internal System.Windows.Forms.Label lblPrevChar;
		internal System.Windows.Forms.RadioButton rdoFemale;
		internal System.Windows.Forms.RadioButton rdoMale;
		internal System.Windows.Forms.ComboBox cmbClass;
		internal System.Windows.Forms.Label lblNewCharGender;
		internal System.Windows.Forms.Label lblNewCharClass;
		internal System.Windows.Forms.TextBox txtCharName;
		internal System.Windows.Forms.Label lblNewCharName;
		internal System.Windows.Forms.Label lblNewChar;
		internal System.Windows.Forms.Label lblStatusHeader;
		internal System.Windows.Forms.Label lblServerStatus;
		internal System.Windows.Forms.Panel pnlMainMenu;
		internal System.Windows.Forms.Label lblNewsHeader;
		internal System.Windows.Forms.Label lblNews;
		internal System.Windows.Forms.Panel pnlIPConfig;
		internal System.Windows.Forms.TextBox txtPort;
		internal System.Windows.Forms.Label lblPort;
		internal System.Windows.Forms.TextBox txtIP;
		internal System.Windows.Forms.Label lblIpAdress;
		internal System.Windows.Forms.Label lblIpConfig;
		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.PictureBox picLogo;
		internal System.Windows.Forms.Button btnLogin;
		internal System.Windows.Forms.Button btnCreateAccount;
		internal System.Windows.Forms.Button btnPlay;
		internal System.Windows.Forms.Button btnRegister;
		internal System.Windows.Forms.Button btnCredits;
		internal System.Windows.Forms.Button btnExit;
		internal System.Windows.Forms.Button btnCreateCharacter;
		internal System.Windows.Forms.Button btnSaveIP;
		internal System.Windows.Forms.Panel pnlCharSelect;
		internal System.Windows.Forms.Label lblCharSelect;
		internal System.Windows.Forms.Label Label16;
		internal System.Windows.Forms.PictureBox picChar3;
		internal System.Windows.Forms.PictureBox picChar2;
		internal System.Windows.Forms.PictureBox picChar1;
		internal System.Windows.Forms.Button btnDelChar;
		internal System.Windows.Forms.Button btnNewChar;
		internal System.Windows.Forms.Button btnUseChar;
		internal System.Windows.Forms.TextBox txtDescription;
		internal System.Windows.Forms.Label lblNewCharSprite;
        internal System.Windows.Forms.Label lblStatus;
        internal System.Windows.Forms.Panel pnlLoad;
        private System.ComponentModel.IContainer components;
    }
	
}
