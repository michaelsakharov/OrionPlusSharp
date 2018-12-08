using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;

namespace Engine
{
    partial class FrmLogin : System.Windows.Forms.Form
    {

        // Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                    components.Dispose();
            }
            finally
            {
                base.Dispose(disposing);
            }
        }

        // Required by the Windows Form Designer
        private System.ComponentModel.IContainer components;

        // NOTE: The following procedure is required by the Windows Form Designer
        // It can be modified using the Windows Form Designer.  
        // Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            this.tmrConnect = new System.Windows.Forms.Timer(this.components);
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlAdmin = new System.Windows.Forms.Panel();
            this.btnPetEditor = new System.Windows.Forms.Button();
            this.btnAutoMapper = new System.Windows.Forms.Button();
            this.btnClassEditor = new System.Windows.Forms.Button();
            this.btnRecipeEditor = new System.Windows.Forms.Button();
            this.btnProjectiles = new System.Windows.Forms.Button();
            this.btnQuest = new System.Windows.Forms.Button();
            this.btnhouseEditor = new System.Windows.Forms.Button();
            this.btnMapEditor = new System.Windows.Forms.Button();
            this.btnItemEditor = new System.Windows.Forms.Button();
            this.btnResourceEditor = new System.Windows.Forms.Button();
            this.btnNPCEditor = new System.Windows.Forms.Button();
            this.btnSkillEditor = new System.Windows.Forms.Button();
            this.btnShopEditor = new System.Windows.Forms.Button();
            this.btnAnimationEditor = new System.Windows.Forms.Button();
            this.pnlAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // tmrConnect
            // 
            this.tmrConnect.Enabled = true;
            this.tmrConnect.Interval = 1000;
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.Orange;
            this.lblConnectionStatus.Location = new System.Drawing.Point(12, 235);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(149, 17);
            this.lblConnectionStatus.TabIndex = 0;
            this.lblConnectionStatus.Text = "Connecting to Server...";
            // 
            // Label1
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
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(16, 84);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(159, 20);
            this.txtLogin.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(16, 123);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = (char)35;
            this.txtPassword.Size = new System.Drawing.Size(159, 20);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // Label2
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
            // btnLogin
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
            // pnlAdmin
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
            // btnPetEditor
            // 
            this.btnPetEditor.Location = new System.Drawing.Point(154, 34);
            this.btnPetEditor.Name = "btnPetEditor";
            this.btnPetEditor.Size = new System.Drawing.Size(112, 25);
            this.btnPetEditor.TabIndex = 54;
            this.btnPetEditor.Text = "Pet Editor";
            this.btnPetEditor.UseVisualStyleBackColor = true;
            // 
            // btnAutoMapper
            // 
            this.btnAutoMapper.Location = new System.Drawing.Point(154, 3);
            this.btnAutoMapper.Name = "btnAutoMapper";
            this.btnAutoMapper.Size = new System.Drawing.Size(112, 25);
            this.btnAutoMapper.TabIndex = 53;
            this.btnAutoMapper.Text = "Auto Mapper";
            this.btnAutoMapper.UseVisualStyleBackColor = true;
            // 
            // btnClassEditor
            // 
            this.btnClassEditor.Location = new System.Drawing.Point(390, 158);
            this.btnClassEditor.Name = "btnClassEditor";
            this.btnClassEditor.Size = new System.Drawing.Size(112, 25);
            this.btnClassEditor.TabIndex = 52;
            this.btnClassEditor.Text = "Class Editor";
            this.btnClassEditor.UseVisualStyleBackColor = true;
            // 
            // btnRecipeEditor
            // 
            this.btnRecipeEditor.Location = new System.Drawing.Point(272, 158);
            this.btnRecipeEditor.Name = "btnRecipeEditor";
            this.btnRecipeEditor.Size = new System.Drawing.Size(112, 25);
            this.btnRecipeEditor.TabIndex = 51;
            this.btnRecipeEditor.Text = "Recipe Editor";
            this.btnRecipeEditor.UseVisualStyleBackColor = true;
            // 
            // btnProjectiles
            // 
            this.btnProjectiles.Location = new System.Drawing.Point(390, 127);
            this.btnProjectiles.Name = "btnProjectiles";
            this.btnProjectiles.Size = new System.Drawing.Size(112, 25);
            this.btnProjectiles.TabIndex = 50;
            this.btnProjectiles.Text = "Projectiles Editor";
            this.btnProjectiles.UseVisualStyleBackColor = true;
            // 
            // btnQuest
            // 
            this.btnQuest.Location = new System.Drawing.Point(272, 3);
            this.btnQuest.Name = "btnQuest";
            this.btnQuest.Size = new System.Drawing.Size(112, 25);
            this.btnQuest.TabIndex = 48;
            this.btnQuest.Text = "Quest Editor";
            this.btnQuest.UseVisualStyleBackColor = true;
            // 
            // btnhouseEditor
            // 
            this.btnhouseEditor.Location = new System.Drawing.Point(272, 127);
            this.btnhouseEditor.Name = "btnhouseEditor";
            this.btnhouseEditor.Size = new System.Drawing.Size(112, 25);
            this.btnhouseEditor.TabIndex = 49;
            this.btnhouseEditor.Text = "Houses Editor";
            this.btnhouseEditor.UseVisualStyleBackColor = true;
            // 
            // btnMapEditor
            // 
            this.btnMapEditor.Location = new System.Drawing.Point(390, 3);
            this.btnMapEditor.Name = "btnMapEditor";
            this.btnMapEditor.Size = new System.Drawing.Size(112, 25);
            this.btnMapEditor.TabIndex = 41;
            this.btnMapEditor.Text = "Map Editor";
            this.btnMapEditor.UseVisualStyleBackColor = true;
            // 
            // btnItemEditor
            // 
            this.btnItemEditor.Location = new System.Drawing.Point(272, 34);
            this.btnItemEditor.Name = "btnItemEditor";
            this.btnItemEditor.Size = new System.Drawing.Size(112, 25);
            this.btnItemEditor.TabIndex = 42;
            this.btnItemEditor.Text = "Item Editor";
            this.btnItemEditor.UseVisualStyleBackColor = true;
            // 
            // btnResourceEditor
            // 
            this.btnResourceEditor.Location = new System.Drawing.Point(390, 34);
            this.btnResourceEditor.Name = "btnResourceEditor";
            this.btnResourceEditor.Size = new System.Drawing.Size(112, 25);
            this.btnResourceEditor.TabIndex = 43;
            this.btnResourceEditor.Text = "Resource Editor";
            this.btnResourceEditor.UseVisualStyleBackColor = true;
            // 
            // btnNPCEditor
            // 
            this.btnNPCEditor.Location = new System.Drawing.Point(272, 65);
            this.btnNPCEditor.Name = "btnNPCEditor";
            this.btnNPCEditor.Size = new System.Drawing.Size(112, 25);
            this.btnNPCEditor.TabIndex = 44;
            this.btnNPCEditor.Text = "NPC Editor";
            this.btnNPCEditor.UseVisualStyleBackColor = true;
            // 
            // btnSkillEditor
            // 
            this.btnSkillEditor.Location = new System.Drawing.Point(390, 65);
            this.btnSkillEditor.Name = "btnSkillEditor";
            this.btnSkillEditor.Size = new System.Drawing.Size(112, 25);
            this.btnSkillEditor.TabIndex = 45;
            this.btnSkillEditor.Text = "Skill Editor";
            this.btnSkillEditor.UseVisualStyleBackColor = true;
            // 
            // btnShopEditor
            // 
            this.btnShopEditor.Location = new System.Drawing.Point(272, 96);
            this.btnShopEditor.Name = "btnShopEditor";
            this.btnShopEditor.Size = new System.Drawing.Size(112, 25);
            this.btnShopEditor.TabIndex = 46;
            this.btnShopEditor.Text = "Shop Editor";
            this.btnShopEditor.UseVisualStyleBackColor = true;
            // 
            // btnAnimationEditor
            // 
            this.btnAnimationEditor.Location = new System.Drawing.Point(390, 96);
            this.btnAnimationEditor.Name = "btnAnimationEditor";
            this.btnAnimationEditor.Size = new System.Drawing.Size(112, 25);
            this.btnAnimationEditor.TabIndex = 47;
            this.btnAnimationEditor.Text = "Animation Editor";
            this.btnAnimationEditor.UseVisualStyleBackColor = true;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6.0F, 13.0F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = (System.Drawing.Image)resources.GetObject("$this.BackgroundImage");
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
            this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Orion+ Editors";
            this.pnlAdmin.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private Timer _tmrConnect;

        internal Timer tmrConnect
        {
            
            get
            {
                return _tmrConnect;
            }

            
            set
            {
                if (_tmrConnect != null)
                {
                }

                _tmrConnect = value;
                if (_tmrConnect != null)
                {
                }
            }
        }

        private Label _lblConnectionStatus;

        internal Label lblConnectionStatus
        {
            
            get
            {
                return _lblConnectionStatus;
            }

            
            set
            {
                if (_lblConnectionStatus != null)
                {
                }

                _lblConnectionStatus = value;
                if (_lblConnectionStatus != null)
                {
                }
            }
        }

        private Label _Label1;

        internal Label Label1
        {
            
            get
            {
                return _Label1;
            }

            
            set
            {
                if (_Label1 != null)
                {
                }

                _Label1 = value;
                if (_Label1 != null)
                {
                }
            }
        }

        private TextBox _txtLogin;

        internal TextBox txtLogin
        {
            
            get
            {
                return _txtLogin;
            }

            
            set
            {
                if (_txtLogin != null)
                {
                }

                _txtLogin = value;
                if (_txtLogin != null)
                {
                }
            }
        }

        private TextBox _txtPassword;

        internal TextBox txtPassword
        {
            
            get
            {
                return _txtPassword;
            }

            
            set
            {
                if (_txtPassword != null)
                {
                }

                _txtPassword = value;
                if (_txtPassword != null)
                {
                }
            }
        }

        private Label _Label2;

        internal Label Label2
        {
            
            get
            {
                return _Label2;
            }

            
            set
            {
                if (_Label2 != null)
                {
                }

                _Label2 = value;
                if (_Label2 != null)
                {
                }
            }
        }

        private Button _btnLogin;

        internal Button btnLogin
        {
            
            get
            {
                return _btnLogin;
            }

            
            set
            {
                if (_btnLogin != null)
                {
                }

                _btnLogin = value;
                if (_btnLogin != null)
                {
                }
            }
        }

        private Panel _pnlAdmin;

        internal Panel pnlAdmin
        {
            
            get
            {
                return _pnlAdmin;
            }

            
            set
            {
                if (_pnlAdmin != null)
                {
                }

                _pnlAdmin = value;
                if (_pnlAdmin != null)
                {
                }
            }
        }

        private Button _btnClassEditor;

        internal Button btnClassEditor
        {
            
            get
            {
                return _btnClassEditor;
            }

            
            set
            {
                if (_btnClassEditor != null)
                {
                }

                _btnClassEditor = value;
                if (_btnClassEditor != null)
                {
                }
            }
        }

        private Button _btnRecipeEditor;

        internal Button btnRecipeEditor
        {
            
            get
            {
                return _btnRecipeEditor;
            }

            
            set
            {
                if (_btnRecipeEditor != null)
                {
                }

                _btnRecipeEditor = value;
                if (_btnRecipeEditor != null)
                {
                }
            }
        }

        private Button _btnProjectiles;

        internal Button btnProjectiles
        {
            
            get
            {
                return _btnProjectiles;
            }

            
            set
            {
                if (_btnProjectiles != null)
                {
                }

                _btnProjectiles = value;
                if (_btnProjectiles != null)
                {
                }
            }
        }

        private Button _btnQuest;

        internal Button btnQuest
        {
            
            get
            {
                return _btnQuest;
            }

            
            set
            {
                if (_btnQuest != null)
                {
                }

                _btnQuest = value;
                if (_btnQuest != null)
                {
                }
            }
        }

        private Button _btnhouseEditor;

        internal Button btnhouseEditor
        {
            
            get
            {
                return _btnhouseEditor;
            }

            
            set
            {
                if (_btnhouseEditor != null)
                {
                }

                _btnhouseEditor = value;
                if (_btnhouseEditor != null)
                {
                }
            }
        }

        private Button _btnMapEditor;

        internal Button btnMapEditor
        {
            
            get
            {
                return _btnMapEditor;
            }

            
            set
            {
                if (_btnMapEditor != null)
                {
                }

                _btnMapEditor = value;
                if (_btnMapEditor != null)
                {
                }
            }
        }

        private Button _btnItemEditor;

        internal Button btnItemEditor
        {
            
            get
            {
                return _btnItemEditor;
            }

            
            set
            {
                if (_btnItemEditor != null)
                {
                }

                _btnItemEditor = value;
                if (_btnItemEditor != null)
                {
                }
            }
        }

        private Button _btnResourceEditor;

        internal Button btnResourceEditor
        {
            
            get
            {
                return _btnResourceEditor;
            }

            
            set
            {
                if (_btnResourceEditor != null)
                {
                }

                _btnResourceEditor = value;
                if (_btnResourceEditor != null)
                {
                }
            }
        }

        private Button _btnNPCEditor;

        internal Button btnNPCEditor
        {
            
            get
            {
                return _btnNPCEditor;
            }

            
            set
            {
                if (_btnNPCEditor != null)
                {
                }

                _btnNPCEditor = value;
                if (_btnNPCEditor != null)
                {
                }
            }
        }

        private Button _btnSkillEditor;

        internal Button btnSkillEditor
        {
            
            get
            {
                return _btnSkillEditor;
            }

            
            set
            {
                if (_btnSkillEditor != null)
                {
                }

                _btnSkillEditor = value;
                if (_btnSkillEditor != null)
                {
                }
            }
        }

        private Button _btnShopEditor;

        internal Button btnShopEditor
        {
            
            get
            {
                return _btnShopEditor;
            }

            
            set
            {
                if (_btnShopEditor != null)
                {
                }

                _btnShopEditor = value;
                if (_btnShopEditor != null)
                {
                }
            }
        }

        private Button _btnAnimationEditor;

        internal Button btnAnimationEditor
        {
            
            get
            {
                return _btnAnimationEditor;
            }

            
            set
            {
                if (_btnAnimationEditor != null)
                {
                }

                _btnAnimationEditor = value;
                if (_btnAnimationEditor != null)
                {
                }
            }
        }

        private Button _btnAutoMapper;

        internal Button btnAutoMapper
        {
            
            get
            {
                return _btnAutoMapper;
            }

            
            set
            {
                if (_btnAutoMapper != null)
                {
                }

                _btnAutoMapper = value;
                if (_btnAutoMapper != null)
                {
                }
            }
        }

        private Button _btnPetEditor;

        internal Button btnPetEditor
        {
            
            get
            {
                return _btnPetEditor;
            }

            
            set
            {
                if (_btnPetEditor != null)
                {
                }

                _btnPetEditor = value;
                if (_btnPetEditor != null)
                {
                }
            }
        }
    }
}
