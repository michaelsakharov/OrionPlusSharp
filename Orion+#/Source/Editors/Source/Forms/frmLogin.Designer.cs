
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using Engine;

namespace Engine
{
	[global::Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
		public partial class FrmLogin : System.Windows.Forms.Form
		{
		
		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
			protected override void Dispose(bool disposing)
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
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		[System.Diagnostics.DebuggerStepThrough()]
			private void InitializeComponent()
			{
			this.components = new System.ComponentModel.Container();
			base.Load += new System.EventHandler(FrmLogin_Load);
			base.Closing += new System.ComponentModel.CancelEventHandler(FrmLogin_UnLoad);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
			this.tmrConnect = new System.Windows.Forms.Timer(this.components);
			this.tmrConnect.Tick += new System.EventHandler(this.TmrConnect_Tick);
			this.lblConnectionStatus = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.txtLogin = new System.Windows.Forms.TextBox();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.btnLogin = new System.Windows.Forms.Button();
			this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
			this.pnlAdmin = new System.Windows.Forms.Panel();
			this.btnPetEditor = new System.Windows.Forms.Button();
			this.btnPetEditor.Click += new System.EventHandler(this.BtnPetEditor_Click);
			this.btnAutoMapper = new System.Windows.Forms.Button();
			this.btnAutoMapper.Click += new System.EventHandler(this.BtnAutoMapper_Click);
			this.btnClassEditor = new System.Windows.Forms.Button();
			this.btnClassEditor.Click += new System.EventHandler(this.BtnClassEditor_Click);
			this.btnRecipeEditor = new System.Windows.Forms.Button();
			this.btnRecipeEditor.Click += new System.EventHandler(this.BtnRecipeEditor_Click);
			this.btnProjectiles = new System.Windows.Forms.Button();
			this.btnProjectiles.Click += new System.EventHandler(this.BtnProjectiles_Click);
			this.btnQuest = new System.Windows.Forms.Button();
			this.btnQuest.Click += new System.EventHandler(this.BtnQuest_Click);
			this.btnhouseEditor = new System.Windows.Forms.Button();
			this.btnhouseEditor.Click += new System.EventHandler(this.BtnhouseEditor_Click);
			this.btnMapEditor = new System.Windows.Forms.Button();
			this.btnMapEditor.Click += new System.EventHandler(this.BtnMapEditor_Click);
			this.btnItemEditor = new System.Windows.Forms.Button();
			this.btnItemEditor.Click += new System.EventHandler(this.BtnItemEditor_Click);
			this.btnResourceEditor = new System.Windows.Forms.Button();
			this.btnResourceEditor.Click += new System.EventHandler(this.BtnResourceEditor_Click);
			this.btnNPCEditor = new System.Windows.Forms.Button();
			this.btnNPCEditor.Click += new System.EventHandler(this.BtnNPCEditor_Click);
			this.btnSkillEditor = new System.Windows.Forms.Button();
			this.btnSkillEditor.Click += new System.EventHandler(this.BtnSkillEditor_Click);
			this.btnShopEditor = new System.Windows.Forms.Button();
			this.btnShopEditor.Click += new System.EventHandler(this.BtnShopEditor_Click);
			this.btnAnimationEditor = new System.Windows.Forms.Button();
			this.btnAnimationEditor.Click += new System.EventHandler(this.BtnAnimationEditor_Click);
			this.pnlAdmin.SuspendLayout();
			this.SuspendLayout();
			//
			//tmrConnect
			//
			this.tmrConnect.Enabled = true;
			this.tmrConnect.Interval = 1000;
			//
			//lblConnectionStatus
			//
			this.lblConnectionStatus.AutoSize = true;
			this.lblConnectionStatus.BackColor = System.Drawing.Color.Transparent;
			this.lblConnectionStatus.Font = new System.Drawing.Font("Segoe UI", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.lblConnectionStatus.ForeColor = System.Drawing.Color.Orange;
			this.lblConnectionStatus.Location = new System.Drawing.Point(12, 235);
			this.lblConnectionStatus.Name = "lblConnectionStatus";
			this.lblConnectionStatus.Size = new System.Drawing.Size(149, 17);
			this.lblConnectionStatus.TabIndex = 0;
			this.lblConnectionStatus.Text = "Connecting to Server...";
			//
			//Label1
			//
			this.Label1.AutoSize = true;
			this.Label1.BackColor = System.Drawing.Color.Transparent;
			this.Label1.ForeColor = System.Drawing.Color.White;
			this.Label1.Location = new System.Drawing.Point(13, 68);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(60, 13);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "User Name";
			//
			//txtLogin
			//
			this.txtLogin.Location = new System.Drawing.Point(16, 84);
			this.txtLogin.Name = "txtLogin";
			this.txtLogin.Size = new System.Drawing.Size(159, 20);
			this.txtLogin.TabIndex = 2;
			//
			//txtPassword
			//
			this.txtPassword.Location = new System.Drawing.Point(16, 123);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.PasswordChar = global::Microsoft.VisualBasic.Strings.ChrW(35);
			this.txtPassword.Size = new System.Drawing.Size(159, 20);
			this.txtPassword.TabIndex = 4;
			this.txtPassword.UseSystemPasswordChar = true;
			//
			//Label2
			//
			this.Label2.AutoSize = true;
			this.Label2.BackColor = System.Drawing.Color.Transparent;
			this.Label2.ForeColor = System.Drawing.Color.White;
			this.Label2.Location = new System.Drawing.Point(13, 107);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(53, 13);
			this.Label2.TabIndex = 3;
			this.Label2.Text = "Password";
			//
			//btnLogin
			//
			this.btnLogin.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnLogin.ForeColor = System.Drawing.Color.White;
			this.btnLogin.Location = new System.Drawing.Point(16, 161);
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Size = new System.Drawing.Size(159, 23);
			this.btnLogin.TabIndex = 5;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = false;
			//
			//pnlAdmin
			//
			this.pnlAdmin.BackColor = System.Drawing.Color.Transparent;
			this.pnlAdmin.Controls.Add(this.btnPetEditor);
			this.pnlAdmin.Controls.Add(this.btnAutoMapper);
			this.pnlAdmin.Controls.Add(this.btnClassEditor);
			this.pnlAdmin.Controls.Add(this.btnRecipeEditor);
			this.pnlAdmin.Controls.Add(this.btnProjectiles);
			this.pnlAdmin.Controls.Add(this.btnQuest);
			this.pnlAdmin.Controls.Add(this.btnhouseEditor);
			this.pnlAdmin.Controls.Add(this.btnMapEditor);
			this.pnlAdmin.Controls.Add(this.btnItemEditor);
			this.pnlAdmin.Controls.Add(this.btnResourceEditor);
			this.pnlAdmin.Controls.Add(this.btnNPCEditor);
			this.pnlAdmin.Controls.Add(this.btnSkillEditor);
			this.pnlAdmin.Controls.Add(this.btnShopEditor);
			this.pnlAdmin.Controls.Add(this.btnAnimationEditor);
			this.pnlAdmin.Location = new System.Drawing.Point(12, 12);
			this.pnlAdmin.Name = "pnlAdmin";
			this.pnlAdmin.Size = new System.Drawing.Size(505, 189);
			this.pnlAdmin.TabIndex = 6;
			this.pnlAdmin.Visible = false;
			//
			//btnPetEditor
			//
			this.btnPetEditor.Location = new System.Drawing.Point(154, 34);
			this.btnPetEditor.Name = "btnPetEditor";
			this.btnPetEditor.Size = new System.Drawing.Size(112, 25);
			this.btnPetEditor.TabIndex = 54;
			this.btnPetEditor.Text = "Pet Editor";
			this.btnPetEditor.UseVisualStyleBackColor = true;
			//
			//btnAutoMapper
			//
			this.btnAutoMapper.Location = new System.Drawing.Point(154, 3);
			this.btnAutoMapper.Name = "btnAutoMapper";
			this.btnAutoMapper.Size = new System.Drawing.Size(112, 25);
			this.btnAutoMapper.TabIndex = 53;
			this.btnAutoMapper.Text = "Auto Mapper";
			this.btnAutoMapper.UseVisualStyleBackColor = true;
			//
			//btnClassEditor
			//
			this.btnClassEditor.Location = new System.Drawing.Point(390, 158);
			this.btnClassEditor.Name = "btnClassEditor";
			this.btnClassEditor.Size = new System.Drawing.Size(112, 25);
			this.btnClassEditor.TabIndex = 52;
			this.btnClassEditor.Text = "Class Editor";
			this.btnClassEditor.UseVisualStyleBackColor = true;
			//
			//btnRecipeEditor
			//
			this.btnRecipeEditor.Location = new System.Drawing.Point(272, 158);
			this.btnRecipeEditor.Name = "btnRecipeEditor";
			this.btnRecipeEditor.Size = new System.Drawing.Size(112, 25);
			this.btnRecipeEditor.TabIndex = 51;
			this.btnRecipeEditor.Text = "Recipe Editor";
			this.btnRecipeEditor.UseVisualStyleBackColor = true;
			//
			//btnProjectiles
			//
			this.btnProjectiles.Location = new System.Drawing.Point(390, 127);
			this.btnProjectiles.Name = "btnProjectiles";
			this.btnProjectiles.Size = new System.Drawing.Size(112, 25);
			this.btnProjectiles.TabIndex = 50;
			this.btnProjectiles.Text = "Projectiles Editor";
			this.btnProjectiles.UseVisualStyleBackColor = true;
			//
			//btnQuest
			//
			this.btnQuest.Location = new System.Drawing.Point(272, 3);
			this.btnQuest.Name = "btnQuest";
			this.btnQuest.Size = new System.Drawing.Size(112, 25);
			this.btnQuest.TabIndex = 48;
			this.btnQuest.Text = "Quest Editor";
			this.btnQuest.UseVisualStyleBackColor = true;
			//
			//btnhouseEditor
			//
			this.btnhouseEditor.Location = new System.Drawing.Point(272, 127);
			this.btnhouseEditor.Name = "btnhouseEditor";
			this.btnhouseEditor.Size = new System.Drawing.Size(112, 25);
			this.btnhouseEditor.TabIndex = 49;
			this.btnhouseEditor.Text = "Houses Editor";
			this.btnhouseEditor.UseVisualStyleBackColor = true;
			//
			//btnMapEditor
			//
			this.btnMapEditor.Location = new System.Drawing.Point(390, 3);
			this.btnMapEditor.Name = "btnMapEditor";
			this.btnMapEditor.Size = new System.Drawing.Size(112, 25);
			this.btnMapEditor.TabIndex = 41;
			this.btnMapEditor.Text = "Map Editor";
			this.btnMapEditor.UseVisualStyleBackColor = true;
			//
			//btnItemEditor
			//
			this.btnItemEditor.Location = new System.Drawing.Point(272, 34);
			this.btnItemEditor.Name = "btnItemEditor";
			this.btnItemEditor.Size = new System.Drawing.Size(112, 25);
			this.btnItemEditor.TabIndex = 42;
			this.btnItemEditor.Text = "Item Editor";
			this.btnItemEditor.UseVisualStyleBackColor = true;
			//
			//btnResourceEditor
			//
			this.btnResourceEditor.Location = new System.Drawing.Point(390, 34);
			this.btnResourceEditor.Name = "btnResourceEditor";
			this.btnResourceEditor.Size = new System.Drawing.Size(112, 25);
			this.btnResourceEditor.TabIndex = 43;
			this.btnResourceEditor.Text = "Resource Editor";
			this.btnResourceEditor.UseVisualStyleBackColor = true;
			//
			//btnNPCEditor
			//
			this.btnNPCEditor.Location = new System.Drawing.Point(272, 65);
			this.btnNPCEditor.Name = "btnNPCEditor";
			this.btnNPCEditor.Size = new System.Drawing.Size(112, 25);
			this.btnNPCEditor.TabIndex = 44;
			this.btnNPCEditor.Text = "NPC Editor";
			this.btnNPCEditor.UseVisualStyleBackColor = true;
			//
			//btnSkillEditor
			//
			this.btnSkillEditor.Location = new System.Drawing.Point(390, 65);
			this.btnSkillEditor.Name = "btnSkillEditor";
			this.btnSkillEditor.Size = new System.Drawing.Size(112, 25);
			this.btnSkillEditor.TabIndex = 45;
			this.btnSkillEditor.Text = "Skill Editor";
			this.btnSkillEditor.UseVisualStyleBackColor = true;
			//
			//btnShopEditor
			//
			this.btnShopEditor.Location = new System.Drawing.Point(272, 96);
			this.btnShopEditor.Name = "btnShopEditor";
			this.btnShopEditor.Size = new System.Drawing.Size(112, 25);
			this.btnShopEditor.TabIndex = 46;
			this.btnShopEditor.Text = "Shop Editor";
			this.btnShopEditor.UseVisualStyleBackColor = true;
			//
			//btnAnimationEditor
			//
			this.btnAnimationEditor.Location = new System.Drawing.Point(390, 96);
			this.btnAnimationEditor.Name = "btnAnimationEditor";
			this.btnAnimationEditor.Size = new System.Drawing.Size(112, 25);
			this.btnAnimationEditor.TabIndex = 47;
			this.btnAnimationEditor.Text = "Animation Editor";
			this.btnAnimationEditor.UseVisualStyleBackColor = true;
			//
			//frmLogin
			//
			this.AutoScaleDimensions = new System.Drawing.SizeF((float) (6.0F), (float) (13.0F));
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = (System.Drawing.Image) (resources.GetObject("$this.BackgroundImage"));
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.ClientSize = new System.Drawing.Size(529, 261);
			this.Controls.Add(this.pnlAdmin);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.txtLogin);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.lblConnectionStatus);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = (System.Drawing.Icon) (resources.GetObject("$this.Icon"));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmLogin";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "Orion+ Editors";
			this.pnlAdmin.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		
		internal Timer tmrConnect;
		internal Label lblConnectionStatus;
		internal Label Label1;
		internal TextBox txtLogin;
		internal TextBox txtPassword;
		internal Label Label2;
		internal Button btnLogin;
		internal Panel pnlAdmin;
		internal Button btnClassEditor;
		internal Button btnRecipeEditor;
		internal Button btnProjectiles;
		internal Button btnQuest;
		internal Button btnhouseEditor;
		internal Button btnMapEditor;
		internal Button btnItemEditor;
		internal Button btnResourceEditor;
		internal Button btnNPCEditor;
		internal Button btnSkillEditor;
		internal Button btnShopEditor;
		internal Button btnAnimationEditor;
		internal Button btnAutoMapper;
		internal Button btnPetEditor;
	}
	
}
