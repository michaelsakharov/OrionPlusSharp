
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using System.IO;
using Engine;

namespace Engine
{
	
	partial class FrmVisualWarp
	{
		public FrmVisualWarp()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmVisualWarp defaultInstance;
		
		public static FrmVisualWarp Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmVisualWarp();
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
		
		public void LstMaps_SelectedIndexChanged(object sender, EventArgs e)
		{
			DrawMap();
			E_Globals.EditorWarpMap = lstMaps.SelectedIndex + 1;
		}
		
		public void PicPreview_Click(object sender, EventArgs e)
		{
            MouseEventArgs eMouse = (MouseEventArgs)e;

            E_Globals.EditorWarpX = eMouse.Location.X / E_Globals.PIC_X;
			E_Globals.EditorWarpY = eMouse.Location.Y / E_Globals.PIC_Y;
			
			lblSelX.Text = "Selected X: " + System.Convert.ToString(E_Globals.EditorWarpX);
			lblSelY.Text = "Selected Y: " + System.Convert.ToString(E_Globals.EditorWarpY);
		}
		
		public void BtnWarpOK_Click(object sender, EventArgs e)
		{
			Visible = false;
		}
		
		private void PicPreview_Paint(object sender, PaintEventArgs e)
		{
			//This is here to make sure that the box dosen't try to re-paint itself... saves time and w/e else
			return;
		}
		
		private void DrawMap()
		{
			Graphics g = default(Graphics);
			int x = 0;
			int y = 0;
			Rectangle srcRect = new Rectangle();
			Rectangle destRect = new Rectangle();
			
			if (lstMaps.SelectedIndex < 0)
			{
				return;
			}
			
			if (File.Exists(Application.StartupPath + "\\Data\\Cache\\Map" + System.Convert.ToString(lstMaps.SelectedIndex + 1) +".png"))
			{
				g = picPreview.CreateGraphics();
				
				Bitmap mapsprite = new Bitmap(Application.StartupPath + "\\Data\\Cache\\Map" + System.Convert.ToString(lstMaps.SelectedIndex + 1) +".png");
				
				picPreview.Width = mapsprite.Width;
				picPreview.Height = mapsprite.Height;
				
				srcRect = new Rectangle(0, 0, mapsprite.Width, mapsprite.Height);
				destRect = new Rectangle(0, 0, mapsprite.Width, mapsprite.Height);
				
				picPreview.Refresh();
				g.DrawImage(mapsprite, destRect, srcRect, GraphicsUnit.Pixel);
				
				for (x = 0; x <= (mapsprite.Width / E_Globals.PIC_X); x++)
				{
					for (y = 0; y <= (mapsprite.Height / E_Globals.PIC_Y); y++)
					{
						g.DrawRectangle(Pens.Red, new Rectangle(x * E_Globals.PIC_X, y * E_Globals.PIC_Y, E_Globals.PIC_X, E_Globals.PIC_Y));
					}
				}
				
				g.Dispose();
			}
			else
			{
				MessageBox.Show("This map is not in the chache yet, please save the destination map first!");
			}
		}
		
		public void PnlPreview_Paint(object sender, PaintEventArgs e)
		{
			//nothing
		}
		
		public void PnlPreview_Scroll(object sender, ScrollEventArgs e)
		{
			DrawMap();
		}
		
		public void FrmVisualWarp_Load(object sender, EventArgs e)
		{
			
		}
		
	}
}
