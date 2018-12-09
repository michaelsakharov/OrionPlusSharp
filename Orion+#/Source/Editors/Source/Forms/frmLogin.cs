using System.Drawing;
using System;

namespace Engine
{
    internal partial class FrmLogin
    {
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            E_Loop.Main();
        }

        private void FrmLogin_UnLoad(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            E_Loop.CloseEditor();
        }

        int tmr_Connect_Tick = 0;

        private void TmrConnect_Tick(object sender, EventArgs e)
        {
            if (E_NetworkConfig.Socket.IsConnected == true)
            {
                lblConnectionStatus.ForeColor = Color.Green;
                lblConnectionStatus.Text = "Online...";
                tmrConnect.Enabled = false;
            }
            else
            {
                lblConnectionStatus.ForeColor = Color.Red;
                tmr_Connect_Tick++;
                if (tmr_Connect_Tick == 5)
                {
                    E_NetworkConfig.Connect();
                    lblConnectionStatus.Text = "Reconnecting...";
                    lblConnectionStatus.ForeColor = Color.Orange;
                    tmr_Connect_Tick = 0;
                }
                else
                    lblConnectionStatus.Text = "Offline...";
            }
        }

        internal bool IsLoginLegal(string Username, string Password)
        {
            if (Username.Length >= 3)
            {
                if (Password.Length >= 3)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (E_NetworkConfig.Socket.IsConnected)
            {
                if (IsLoginLegal(txtLogin.Text, txtPassword.Text))
                    E_NetworkSend.SendEditorLogin(txtLogin.Text, txtPassword.Text);
            }
        }


        private void BtnMapEditor_Click(object sender, EventArgs e)
        {
            E_NetworkSend.SendEditorRequestMap(1);
        }

        private void BtnItemEditor_Click(object sender, EventArgs e)
        {
            E_Items.SendRequestItems();
            E_Items.SendRequestEditItem();
        }

        private void BtnResourceEditor_Click(object sender, EventArgs e)
        {
            E_NetworkSend.SendRequestResources();
            E_NetworkSend.SendRequestEditResource();
        }

        private void BtnNPCEditor_Click(object sender, EventArgs e)
        {
            E_NetworkSend.SendRequestNPCS();
            E_NetworkSend.SendRequestEditNpc();
        }

        private void BtnSkillEditor_Click(object sender, EventArgs e)
        {
            E_NetworkSend.SendRequestSkills();
            E_NetworkSend.SendRequestEditSkill();
        }

        private void BtnShopEditor_Click(object sender, EventArgs e)
        {
            E_NetworkSend.SendRequestShops();
            E_NetworkSend.SendRequestEditShop();
        }

        private void BtnAnimationEditor_Click(object sender, EventArgs e)
        {
            E_NetworkSend.SendRequestAnimations();
            E_NetworkSend.SendRequestEditAnimation();
        }

        private void BtnQuest_Click(object sender, EventArgs e)
        {
            E_Quest.SendRequestQuests();
            E_Quest.SendRequestEditQuest();
        }

        private void BtnhouseEditor_Click(object sender, EventArgs e)
        {
            E_Housing.SendRequestEditHouse();
        }

        private void BtnProjectiles_Click(object sender, EventArgs e)
        {
            E_Projectiles.SendRequestProjectiles();
            E_Projectiles.SendRequestEditProjectiles();
        }

        private void BtnClassEditor_Click(object sender, EventArgs e)
        {
            E_NetworkSend.SendRequestClasses();
            E_NetworkSend.SendRequestEditClass();
        }

        private void BtnAutoMapper_Click(object sender, EventArgs e)
        {
            E_AutoMap.SendRequestAutoMapper();
        }

        private void BtnRecipeEditor_Click(object sender, EventArgs e)
        {
            E_Crafting.SendRequestRecipes();
            E_Crafting.SendRequestEditRecipes();
        }

        private void BtnPetEditor_Click(object sender, EventArgs e)
        {
            E_Pets.SendRequestPets();
            E_Pets.SendRequestEditPet();
        }
    }
}
