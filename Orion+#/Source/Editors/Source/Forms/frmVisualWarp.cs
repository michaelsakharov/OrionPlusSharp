using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using System.IO;

namespace Engine
{
    internal partial class FrmVisualWarp
    {
        private void LstMaps_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrawMap();
            E_Globals.EditorWarpMap = lstMaps.SelectedIndex + 1;
        }

        private void PicPreview_Click(object sender, MouseEventArgs e)
        {
            E_Globals.EditorWarpX = e.Location.X / E_Globals.PIC_X;
            E_Globals.EditorWarpY = e.Location.Y / E_Globals.PIC_Y;

            lblSelX.Text = "Selected X: " + E_Globals.EditorWarpX;
            lblSelY.Text = "Selected Y: " + E_Globals.EditorWarpY;
        }

        private void BtnWarpOK_Click(object sender, EventArgs e)
        {
            Visible = false;
        }

        private new void PicPreview_Paint(object sender, PaintEventArgs e)
        {
            // This is here to make sure that the box dosen't try to re-paint itself... saves time and w/e else
            return;
        }

        private void DrawMap()
        {
            Graphics g;
            int x;
            int y;
            Rectangle srcRect;
            Rectangle destRect;

            if (lstMaps.SelectedIndex < 0)
                return;

            if (File.Exists(Application.StartupPath + @"\Data\Cache\Map" + lstMaps.SelectedIndex + 1 + ".png"))
            {
                g = picPreview.CreateGraphics();

                Bitmap mapsprite = new Bitmap(Application.StartupPath + @"\Data\Cache\Map" + lstMaps.SelectedIndex + 1 + ".png");

                picPreview.Width = mapsprite.Width;
                picPreview.Height = mapsprite.Height;

                srcRect = new Rectangle(0, 0, mapsprite.Width, mapsprite.Height);
                destRect = new Rectangle(0, 0, mapsprite.Width, mapsprite.Height);

                picPreview.Refresh();
                g.DrawImage(mapsprite, destRect, srcRect, GraphicsUnit.Pixel);
                var loopTo = (mapsprite.Width / E_Globals.PIC_X);
                for (x = 0; x <= loopTo; x++)
                {
                    var loopTo1 = (mapsprite.Height / E_Globals.PIC_Y);
                    for (y = 0; y <= loopTo1; y++)
                        g.DrawRectangle(Pens.Red, new Rectangle(x * E_Globals.PIC_X, y * E_Globals.PIC_Y, E_Globals.PIC_X, E_Globals.PIC_Y));
                }

                g.Dispose();
            }
            else
                Interaction.MsgBox("This map is not in the chache yet, please save the destination map first!");
        }

        private void PnlPreview_Paint(object sender, PaintEventArgs e)
        {
        }

        private void PnlPreview_Scroll(object sender, ScrollEventArgs e)
        {
            DrawMap();
        }

        private void FrmVisualWarp_Load(object sender, EventArgs e)
        {
        }
    }
}
