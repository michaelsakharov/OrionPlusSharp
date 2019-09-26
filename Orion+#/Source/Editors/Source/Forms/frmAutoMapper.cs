
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
	partial class FrmAutoMapper
	{
		public FrmAutoMapper()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmAutoMapper defaultInstance;
		
		public static FrmAutoMapper Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmAutoMapper();
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
		
#region Frm Code
		
		public void FrmAutoMapper_Load(object sender, EventArgs e)
		{
			pnlResources.Top = 0;
			pnlResources.Left = 0;
			pnlTileConfig.Top = 0;
			pnlTileConfig.Left = 0;
			Width = 409;
		}
		
		public void TilesetsToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			pnlTileConfig.Visible = true;
			pnlTileConfig.BringToFront();
		}
		
		public void ResourcesToolStripMenuItem2_Click(object sender, EventArgs e)
		{
			string[] Resources;
			int i = 0;
			
			pnlResources.Visible = true;
			pnlResources.BringToFront();
			
			Resources = E_AutoMap.ResourcesNum.Split(';');
			
			lstResources.Items.Clear();
			
			for (i = 0; i <= (Resources.Length - 1); i++)
			{
				lstResources.Items.Add(Resources[i]);
			}
		}
		
		public void BtnStart_Click(object sender, EventArgs e)
		{
			E_AutoMap.MapStart = System.Convert.ToInt32(Conversion.Val(txtMapStart.Text));
			E_AutoMap.MapSize = System.Convert.ToInt32(Conversion.Val(txtMapSize.Text));
			E_AutoMap.MapX = System.Convert.ToInt32(Conversion.Val(txtMapX.Text));
			E_AutoMap.MapY = System.Convert.ToInt32(Conversion.Val(txtMapY.Text));
			E_AutoMap.SandBorder = System.Convert.ToInt32(Conversion.Val(txtSandBorder.Text));
			E_AutoMap.DetailFreq = System.Convert.ToInt32(Conversion.Val(txtDetail.Text));
			E_AutoMap.ResourceFreq = System.Convert.ToInt32(Conversion.Val(txtResourceFreq.Text));
			
			E_AutoMap.SendSaveAutoMapper();
			
			this.Dispose();
		}
		
#endregion
		
#region Resources
		
		public void LstResources_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (lstResources.SelectedIndex < 0)
			{
				return;
			}
			txtResource.Text = System.Convert.ToString(lstResources.Items[lstResources.SelectedIndex]);
		}
		
		public void BtnAdd_Click(object sender, EventArgs e)
		{
			lstResources.Items.Add(Conversion.Val(txtResource.Text));
		}
		
		public void BtnRemove_Click(object sender, EventArgs e)
		{
			if (lstResources.SelectedIndex < 0)
			{
				return;
			}
			lstResources.Items.RemoveAt(lstResources.SelectedIndex);
		}
		
		public void BtnUpdate_Click(object sender, EventArgs e)
		{
			
			if (lstResources.SelectedIndex < 0)
			{
				return;
			}
			
			lstResources.Items[lstResources.SelectedIndex] = txtResource.Text;
		}
		
		public void BtnCloseResource_Click(object sender, EventArgs e)
		{
			pnlResources.Visible = false;
		}
		
		public void BtnSaveResource_Click(object sender, EventArgs e)
		{
			int i = 0;
			string ResourceStr = "";
			
			XmlClass myXml = new XmlClass() {
					Filename = System.IO.Path.Combine(Application.StartupPath, "Data", "AutoMapper.xml"),
					Root = "Options"
				};
			
			myXml.LoadXml();
			
			for (i = 0; i <= lstResources.Items.Count - 1; i++)
			{
				ResourceStr = Convert.ToString(ResourceStr + System.Convert.ToString(lstResources.Items[i]));
				if (i < lstResources.Items.Count - 1)
				{
					ResourceStr = ResourceStr + ";";
				}
			}
			
			myXml.WriteString("Resources", "ResourcesNum", ResourceStr);
			
			myXml.CloseXml(true);
			
			pnlResources.Visible = false;
		}
		
#endregion
		
#region TileSet
		
		public void CmbPrefab_SelectedIndexChanged(object sender, EventArgs e)
		{
			int Layer = 0;
			
			for (Layer = 1; Layer <= (int) Enums.LayerType.Count - 1; Layer++)
			{
				if (E_AutoMap.Tile[cmbPrefab.SelectedIndex + 1].Layer[Layer].Tileset > 0)
				{
					break;
				}
			}
			
			cmbLayer.SelectedIndex = Layer - 1;
			CmbLayer_SelectedIndexChanged(sender, e);
		}
		
		public void CmbLayer_SelectedIndexChanged(object sender, EventArgs e)
		{
			int Prefab = 0;
			int Layer = 0;
			Prefab = cmbPrefab.SelectedIndex + 1;
			Layer = cmbLayer.SelectedIndex + 1;
            if(Prefab == 0) { Prefab = 1; }
			txtTileset.Text = E_AutoMap.Tile[Prefab].Layer[Layer].Tileset.ToString();
			txtTileX.Text = E_AutoMap.Tile[Prefab].Layer[Layer].X.ToString();
			txtTileY.Text = E_AutoMap.Tile[Prefab].Layer[Layer].Y.ToString();
			txtAutotile.Text = E_AutoMap.Tile[Prefab].Layer[Layer].AutoTile.ToString();
			
			if (E_AutoMap.Tile[Prefab].Type == (byte)Enums.TileType.Blocked)
			{
				chkBlocked.Checked = true;
			}
			else
			{
				chkBlocked.Checked = false;
			}
		}
		
		public void BtnTileSetClose_Click(object sender, EventArgs e)
		{
			pnlTileConfig.Visible = false;
		}
		
		public void BtnTileSetSave_Click(object sender, EventArgs e)
		{
			int Prefab = 0;
			int Layer = 0;
			XmlClass myXml = new XmlClass() {
					Filename = System.IO.Path.Combine(Application.StartupPath, "Data", "AutoMapper.xml"),
					Root = "Options"
				};
			
			myXml.LoadXml();
			
			Prefab = cmbPrefab.SelectedIndex + 1;
			
			for (Layer = 1; Layer <= 5; Layer++)
			{
				if (E_AutoMap.Tile[Prefab].Layer[Layer].Tileset > 0)
				{
					myXml.WriteString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "Tileset", System.Convert.ToString(Conversion.Val(E_AutoMap.Tile[Prefab].Layer[Layer].Tileset)));
					myXml.WriteString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "X", System.Convert.ToString(Conversion.Val(E_AutoMap.Tile[Prefab].Layer[Layer].X)));
					myXml.WriteString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "Y", System.Convert.ToString(Conversion.Val(E_AutoMap.Tile[Prefab].Layer[Layer].Y)));
					myXml.WriteString("Prefab" + System.Convert.ToString(Prefab), "Layer" + System.Convert.ToString(Layer) + "Autotile", System.Convert.ToString(Conversion.Val(E_AutoMap.Tile[Prefab].Layer[Layer].AutoTile)));
				}
			}
			
			myXml.WriteString("Prefab" + System.Convert.ToString(Prefab), "Type", System.Convert.ToString(Conversion.Val(E_AutoMap.Tile[Prefab].Type)));
			
			myXml.CloseXml(true);
			
			pnlTileConfig.Visible = false;
			
			E_AutoMap.LoadTilePrefab();
		}
		
#endregion
		
	}
}
