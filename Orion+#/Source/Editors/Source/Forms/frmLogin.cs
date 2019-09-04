
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
	partial class FrmLogin
	{
		public FrmLogin()
		{
			InitializeComponent();
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmLogin defaultInstance;
		
		public static FrmLogin Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmLogin();
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
		
		public void FrmLogin_Load(object sender, EventArgs e)
		{
			E_Loop.Main();
		}
		
		public void FrmLogin_UnLoad(object sender, EventArgs e)
		{
            if (E_NetworkConfig.Socket != null && E_NetworkConfig.Socket.IsConnected)
            {
                E_NetworkSend.SendLeaveGame();
            }
            E_Loop.CloseEditor();
		}
		
		private int TmrConnect_Tick_i = 6;
		
		public void TmrConnect_Tick(object sender, EventArgs e)
		{
			if (E_NetworkConfig.Socket != null && E_NetworkConfig.Socket.IsConnected == true)
			{
				lblConnectionStatus.ForeColor = Color.Green;
				lblConnectionStatus.Text = "Online...";
				tmrConnect.Enabled = false;
			}
			else
			{
				lblConnectionStatus.ForeColor = Color.Red;
				TmrConnect_Tick_i++;
				if (TmrConnect_Tick_i >= 5)
				{
					E_NetworkConfig.Connect();
					lblConnectionStatus.Text = "Reconnecting...";
					lblConnectionStatus.ForeColor = Color.Orange;
					TmrConnect_Tick_i = 0;
				}
				else
				{
					lblConnectionStatus.Text = "Offline...";
				}
			}
		}
		
		internal bool IsLoginLegal(string Username, string Password)
		{
			if (Username.Trim().Length >= 3)
			{
				if (Password.Trim().Length >= 3)
				{
					return true;
				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
			
		}
		
		public void BtnLogin_Click(object sender, EventArgs e)
		{
			if (E_NetworkConfig.Socket.IsConnected)
			{
				if (IsLoginLegal(txtLogin.Text, txtPassword.Text))
				{
					E_NetworkSend.SendEditorLogin(txtLogin.Text, txtPassword.Text);
				}
			}
		}
		
#region Editors
		
		public void BtnMapEditor_Click(object sender, EventArgs e)
		{
			E_NetworkSend.SendEditorRequestMap(1);
		}
		
		public void BtnItemEditor_Click(object sender, EventArgs e)
		{
			E_Items.SendRequestItems();
			E_Items.SendRequestEditItem();
		}
		
		public void BtnResourceEditor_Click(object sender, EventArgs e)
		{
			E_NetworkSend.SendRequestResources();
			E_NetworkSend.SendRequestEditResource();
		}
		
		public void BtnNPCEditor_Click(object sender, EventArgs e)
		{
			E_NetworkSend.SendRequestNPCS();
			E_NetworkSend.SendRequestEditNpc();
		}
		
		public void BtnSkillEditor_Click(object sender, EventArgs e)
		{
			E_NetworkSend.SendRequestSkills();
			E_NetworkSend.SendRequestEditSkill();
		}
		
		public void BtnShopEditor_Click(object sender, EventArgs e)
		{
			E_NetworkSend.SendRequestShops();
			E_NetworkSend.SendRequestEditShop();
		}
		
		public void BtnAnimationEditor_Click(object sender, EventArgs e)
		{
			E_NetworkSend.SendRequestAnimations();
			E_NetworkSend.SendRequestEditAnimation();
		}
		
		public void BtnQuest_Click(object sender, EventArgs e)
		{
			E_Quest.SendRequestQuests();
			E_Quest.SendRequestEditQuest();
		}
		
		public void BtnhouseEditor_Click(object sender, EventArgs e)
		{
			E_Housing.SendRequestEditHouse();
		}
		
		public void BtnProjectiles_Click(object sender, EventArgs e)
		{
			E_Projectiles.SendRequestProjectiles();
			E_Projectiles.SendRequestEditProjectiles();
		}
		
		public void BtnClassEditor_Click(object sender, EventArgs e)
		{
			E_NetworkSend.SendRequestClasses();
			E_NetworkSend.SendRequestEditClass();
		}
		
		public void BtnAutoMapper_Click(object sender, EventArgs e)
		{
			E_AutoMap.SendRequestAutoMapper();
		}
		
		public void BtnRecipeEditor_Click(object sender, EventArgs e)
		{
			E_Crafting.SendRequestRecipes();
			E_Crafting.SendRequestEditRecipes();
		}
		
		public void BtnPetEditor_Click(object sender, EventArgs e)
		{
			E_Pets.SendRequestPets();
			E_Pets.SendRequestEditPet();
		}
		
#endregion
		
	}
}
