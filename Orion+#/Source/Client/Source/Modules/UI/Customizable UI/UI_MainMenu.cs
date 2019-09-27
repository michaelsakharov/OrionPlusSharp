using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Engine
{
    public class UI_MainMenu
    {

        public static void Initialize()
        {
            if (File.Exists(Application.StartupPath + "\\Data\\UIConfiguration\\MainMenu.xml"))
            {
                LoadConfig();
            }
            else
            {
                CreateConfig();
                LoadConfig();
            }
        }

        internal static void CreateConfig()
        {
            XmlClass myXml = new XmlClass()
            {
                Filename = Application.StartupPath + "\\Data\\UIConfiguration\\MainMenu.xml",
                Root = "MainMenuConfig"
            };

            myXml.NewXmlDocument();

            myXml.LoadXml();

            myXml.WriteString("Window", "Width", FrmMenu.Default.Width.ToString());
            myXml.WriteString("Window", "Height", FrmMenu.Default.Height.ToString());

            myXml.WriteString("ServerStatusHeader", "X", FrmMenu.Default.lblStatusHeader.Location.X.ToString());
            myXml.WriteString("ServerStatusHeader", "Y", FrmMenu.Default.lblStatusHeader.Location.Y.ToString());

            myXml.WriteString("ServerStatus", "X", FrmMenu.Default.lblServerStatus.Location.X.ToString());
            myXml.WriteString("ServerStatus", "Y", FrmMenu.Default.lblServerStatus.Location.Y.ToString());

            myXml.WriteString("Logo", "X", FrmMenu.Default.picLogo.Location.X.ToString());
            myXml.WriteString("Logo", "Y", FrmMenu.Default.picLogo.Location.Y.ToString());
            myXml.WriteString("Logo", "Width", FrmMenu.Default.picLogo.Width.ToString());
            myXml.WriteString("Logo", "Height", FrmMenu.Default.picLogo.Height.ToString());

            myXml.WriteString("ButtonPlay", "X", FrmMenu.Default.btnPlay.Location.X.ToString());
            myXml.WriteString("ButtonPlay", "Y", FrmMenu.Default.btnPlay.Location.Y.ToString());
            myXml.WriteString("ButtonPlay", "Width", FrmMenu.Default.btnPlay.Width.ToString());
            myXml.WriteString("ButtonPlay", "Height", FrmMenu.Default.btnPlay.Height.ToString());
                               
            myXml.WriteString("ButtonRegister", "X", FrmMenu.Default.btnRegister.Location.X.ToString());
            myXml.WriteString("ButtonRegister", "Y", FrmMenu.Default.btnRegister.Location.Y.ToString());
            myXml.WriteString("ButtonRegister", "Width", FrmMenu.Default.btnRegister.Width.ToString());
            myXml.WriteString("ButtonRegister", "Height", FrmMenu.Default.btnRegister.Height.ToString());
                               
            myXml.WriteString("ButtonCredits", "X", FrmMenu.Default.btnCredits.Location.X.ToString());
            myXml.WriteString("ButtonCredits", "Y", FrmMenu.Default.btnCredits.Location.Y.ToString());
            myXml.WriteString("ButtonCredits", "Width", FrmMenu.Default.btnCredits.Width.ToString());
            myXml.WriteString("ButtonCredits", "Height", FrmMenu.Default.btnCredits.Height.ToString());
                               
            myXml.WriteString("ButtonExit", "X", FrmMenu.Default.btnExit.Location.X.ToString());
            myXml.WriteString("ButtonExit", "Y", FrmMenu.Default.btnExit.Location.Y.ToString());
            myXml.WriteString("ButtonExit", "Width", FrmMenu.Default.btnExit.Width.ToString());
            myXml.WriteString("ButtonExit", "Height", FrmMenu.Default.btnExit.Height.ToString());
                               
            myXml.WriteString("PanelMain", "X", FrmMenu.Default.pnlMainMenu.Location.X.ToString());
            myXml.WriteString("PanelMain", "Y", FrmMenu.Default.pnlMainMenu.Location.Y.ToString());
            myXml.WriteString("PanelMain", "Width", FrmMenu.Default.pnlMainMenu.Width.ToString());
            myXml.WriteString("PanelMain", "Height", FrmMenu.Default.pnlMainMenu.Height.ToString());

            myXml.CloseXml(true);
        }

        internal static void LoadConfig()
        {
            XmlClass myXml = new XmlClass()
            {
                Filename = Application.StartupPath + "\\Data\\UIConfiguration\\MainMenu.xml",
                Root = "MainMenuConfig"
            };

            myXml.LoadXml();

            FrmMenu.Default.Width = int.Parse(myXml.ReadString("Window", "Width"));
            FrmMenu.Default.Height = int.Parse(myXml.ReadString("Window", "Height"));
            FrmMenu.Default.pnlLoad.Width = int.Parse(myXml.ReadString("Window", "Width"));
            FrmMenu.Default.pnlLoad.Height = int.Parse(myXml.ReadString("Window", "Height"));

            FrmMenu.Default.lblStatusHeader.Location = new System.Drawing.Point(int.Parse(myXml.ReadString("ServerStatusHeader", "X")), int.Parse(myXml.ReadString("ServerStatusHeader", "Y")));

            FrmMenu.Default.lblServerStatus.Location = new System.Drawing.Point(int.Parse(myXml.ReadString("ServerStatus", "X")), int.Parse(myXml.ReadString("ServerStatus", "Y")));


            FrmMenu.Default.picLogo.Location = new System.Drawing.Point(int.Parse(myXml.ReadString("Logo", "X")), int.Parse(myXml.ReadString("Logo", "Y")));
            myXml.ReadString("Logo", "Width", FrmMenu.Default.picLogo.Width.ToString());
            myXml.ReadString("Logo", "Height", FrmMenu.Default.picLogo.Height.ToString());

            FrmMenu.Default.btnPlay.Location = new System.Drawing.Point(int.Parse(myXml.ReadString("ButtonPlay", "X")), int.Parse(myXml.ReadString("ButtonPlay", "Y")));
            myXml.ReadString("ButtonPlay", "Width", FrmMenu.Default.btnPlay.Width.ToString());
            myXml.ReadString("ButtonPlay", "Height", FrmMenu.Default.btnPlay.Height.ToString());

            FrmMenu.Default.btnRegister.Location = new System.Drawing.Point(int.Parse(myXml.ReadString("ButtonRegister", "X")), int.Parse(myXml.ReadString("ButtonRegister", "Y")));
            myXml.WriteString("ButtonRegister", "Width", FrmMenu.Default.btnRegister.Width.ToString());
            myXml.WriteString("ButtonRegister", "Height", FrmMenu.Default.btnRegister.Height.ToString());

            FrmMenu.Default.btnCredits.Location = new System.Drawing.Point(int.Parse(myXml.ReadString("ButtonCredits", "X")), int.Parse(myXml.ReadString("ButtonCredits", "Y")));
            myXml.ReadString("ButtonCredits", "Width", FrmMenu.Default.btnCredits.Width.ToString());
            myXml.ReadString("ButtonCredits", "Height", FrmMenu.Default.btnCredits.Height.ToString());

            FrmMenu.Default.btnExit.Location = new System.Drawing.Point(int.Parse(myXml.ReadString("ButtonExit", "X")), int.Parse(myXml.ReadString("ButtonExit", "Y")));
            myXml.ReadString("ButtonExit", "Width", FrmMenu.Default.btnExit.Width.ToString());
            myXml.ReadString("ButtonExit", "Height", FrmMenu.Default.btnExit.Height.ToString());

            FrmMenu.Default.pnlMainMenu.Location = new System.Drawing.Point(int.Parse(myXml.ReadString("PanelMain", "X")), int.Parse(myXml.ReadString("PanelMain", "Y")));
            myXml.ReadString("PanelMain", "Width", FrmMenu.Default.pnlMainMenu.Width.ToString());
            myXml.ReadString("PanelMain", "Height", FrmMenu.Default.pnlMainMenu.Height.ToString());

            myXml.CloseXml(true);
        }

    }
}
