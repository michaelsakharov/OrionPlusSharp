using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;

namespace Engine
{
    internal partial class FrmAutoMapper
    {
        private void FrmAutoMapper_Load(object sender, EventArgs e)
        {
            pnlResources.Top = 0;
            pnlResources.Left = 0;
            pnlTileConfig.Top = 0;
            pnlTileConfig.Left = 0;
            Width = 409;
        }

        private void TilesetsToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            pnlTileConfig.Visible = true;
            pnlTileConfig.BringToFront();
        }

        private void ResourcesToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            string[] Resources;
            int i;

            pnlResources.Visible = true;
            pnlResources.BringToFront();

            Resources = Microsoft.VisualBasic.Strings.Split(E_AutoMap.ResourcesNum, ";");

            lstResources.Items.Clear();
            var loopTo = Information.UBound(Resources);
            for (i = 0; i <= loopTo; i++)
                lstResources.Items.Add(Resources[i]);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            E_AutoMap.MapStart = (int)Conversion.Val(txtMapStart.Text);
            E_AutoMap.MapSize = (int)Conversion.Val(txtMapSize.Text);
            E_AutoMap.MapX = (int)Conversion.Val(txtMapX.Text);
            E_AutoMap.MapY = (int)Conversion.Val(txtMapY.Text);
            E_AutoMap.SandBorder = (int)Conversion.Val(txtSandBorder.Text);
            E_AutoMap.DetailFreq = (int)Conversion.Val(txtDetail.Text);
            E_AutoMap.ResourceFreq = (int)Conversion.Val(txtResourceFreq.Text);

            E_AutoMap.SendSaveAutoMapper();

            this.Dispose();
        }



        private void LstResources_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstResources.SelectedIndex < 0)
                return;
            txtResource.Text = lstResources.Items[lstResources.SelectedIndex].ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            lstResources.Items.Add(Conversion.Val(txtResource.Text));
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lstResources.SelectedIndex < 0)
                return;
            lstResources.Items.RemoveAt(lstResources.SelectedIndex);
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (lstResources.SelectedIndex < 0)
                return;

            lstResources.Items[lstResources.SelectedIndex] = txtResource.Text;
        }

        private void BtnCloseResource_Click(object sender, EventArgs e)
        {
            pnlResources.Visible = false;
        }

        private void BtnSaveResource_Click(object sender, EventArgs e)
        {
            int i;
            string ResourceStr = "";

            XmlClass myXml = new XmlClass()
            {
                Filename = System.IO.Path.Combine(Application.StartupPath, "Data", "AutoMapper.xml"),
                Root = "Options"
            };

            myXml.LoadXml();
            var loopTo = lstResources.Items.Count - 1;
            for (i = 0; i <= loopTo; i++)
            {
                ResourceStr = System.Convert.ToString(ResourceStr + lstResources.Items[i]);
                if (i < lstResources.Items.Count - 1)
                    ResourceStr = ResourceStr + ";";
            }

            myXml.WriteString("Resources", "ResourcesNum", ResourceStr);

            myXml.CloseXml(true);

            pnlResources.Visible = false;
        }



        private void CmbPrefab_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Layer;

            for (Layer = 1; Layer <= (byte)Enums.LayerType.Count - 1; Layer++)
            {
                if (E_AutoMap.Tile[cmbPrefab.SelectedIndex + 1].Layer[Layer].Tileset > 0)
                    break;
            }

            cmbLayer.SelectedIndex = Layer - 1;
            CmbLayer_SelectedIndexChanged(sender, e);
        }

        private void CmbLayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Prefab;
            int Layer;
            Prefab = cmbPrefab.SelectedIndex + 1;
            Layer = cmbLayer.SelectedIndex + 1;
            txtTileset.Text = E_AutoMap.Tile[Prefab].Layer[Layer].Tileset.ToString();
            txtTileX.Text = E_AutoMap.Tile[Prefab].Layer[Layer].X.ToString();
            txtTileY.Text = E_AutoMap.Tile[Prefab].Layer[Layer].Y.ToString();
            txtAutotile.Text = E_AutoMap.Tile[Prefab].Layer[Layer].AutoTile.ToString();

            if (E_AutoMap.Tile[Prefab].Type == (byte)Enums.TileType.Blocked)
                chkBlocked.Checked = true;
            else
                chkBlocked.Checked = false;
        }

        private void BtnTileSetClose_Click(object sender, EventArgs e)
        {
            pnlTileConfig.Visible = false;
        }

        private void BtnTileSetSave_Click(object sender, EventArgs e)
        {
            int Prefab;
            int Layer;
            XmlClass myXml = new XmlClass()
            {
                Filename = System.IO.Path.Combine(Application.StartupPath, "Data", "AutoMapper.xml"),
                Root = "Options"
            };

            myXml.LoadXml();

            Prefab = cmbPrefab.SelectedIndex + 1;

            for (Layer = 1; Layer <= 5; Layer++)
            {
                if (E_AutoMap.Tile[Prefab].Layer[Layer].Tileset > 0)
                {
                    myXml.WriteString("Prefab" + Prefab, "Layer" + Layer + "Tileset", Conversion.Val(E_AutoMap.Tile[Prefab].Layer[Layer].Tileset).ToString());
                    myXml.WriteString("Prefab" + Prefab, "Layer" + Layer + "X", Conversion.Val(E_AutoMap.Tile[Prefab].Layer[Layer].X).ToString());
                    myXml.WriteString("Prefab" + Prefab, "Layer" + Layer + "Y", Conversion.Val(E_AutoMap.Tile[Prefab].Layer[Layer].Y).ToString());
                    myXml.WriteString("Prefab" + Prefab, "Layer" + Layer + "Autotile", Conversion.Val(E_AutoMap.Tile[Prefab].Layer[Layer].AutoTile).ToString());
                }
            }

            myXml.WriteString("Prefab" + Prefab, "Type", Conversion.Val(E_AutoMap.Tile[Prefab].Type).ToString());

            myXml.CloseXml(true);

            pnlTileConfig.Visible = false;

            E_AutoMap.LoadTilePrefab();
        }
    }
}
