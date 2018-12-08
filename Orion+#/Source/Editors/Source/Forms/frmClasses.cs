using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using System.IO;
using static Engine.E_Types;

namespace Engine
{
    internal partial class frmClasses
    {
        private void FrmEditor_Classes_Load(object sender, EventArgs e)
        {
            nudMaleSprite.Maximum = E_Graphics.NumCharacters;
            nudFemaleSprite.Maximum = E_Graphics.NumCharacters;

            DrawPreview();
        }

        private void LstIndex_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstIndex.SelectedIndex < 0)
                return;

            E_Globals.Editorindex = lstIndex.SelectedIndex + 1;

            E_Globals.LoadClassInfo = true;
        }

        private void BtnAddClass_Click(object sender, EventArgs e)
        {
            E_Globals.Max_Classes = (byte)(E_Globals.Max_Classes + 1);
            var oldClasses = Types.Classes;
            Types.Classes = new ClassRec[E_Globals.Max_Classes + 1];
            if (oldClasses != null)
                Array.Copy(oldClasses, Types.Classes, Math.Min(E_Globals.Max_Classes + 1, oldClasses.Length));

            Types.Classes[E_Globals.Max_Classes].Name = "New Class";

            Types.Classes[E_Globals.Max_Classes].Stat = new byte[7];

            Types.Classes[E_Globals.Max_Classes].Vital = new int[4];

            Types.Classes[E_Globals.Max_Classes].MaleSprite = new int[2];
            Types.Classes[E_Globals.Max_Classes].FemaleSprite = new int[2];

            for (var i = 1; i <= (byte)Enums.StatType.Count - 1; i++)
                Types.Classes[E_Globals.Max_Classes].Stat[i] = 1;

            Types.Classes[E_Globals.Max_Classes].StartItem = new int[6];
            Types.Classes[E_Globals.Max_Classes].StartValue = new int[6];

            Types.Classes[E_Globals.Max_Classes].StartMap = 1;
            Types.Classes[E_Globals.Max_Classes].StartX = 1;
            Types.Classes[E_Globals.Max_Classes].StartY = 1;

            E_Editors.ClassEditorInit();
        }

        private void BtnRemoveClass_Click(object sender, EventArgs e)
        {
            int i;

            // If its The Last class, its simple, just remove and redim
            if (E_Globals.Editorindex == E_Globals.Max_Classes)
            {
                E_Globals.Max_Classes = (byte)(E_Globals.Max_Classes - 1);
                var oldClasses = Types.Classes;
                Types.Classes = new ClassRec[E_Globals.Max_Classes + 1];
                if (oldClasses != null)
                    Array.Copy(oldClasses, Types.Classes, Math.Min(E_Globals.Max_Classes + 1, oldClasses.Length));
            }
            else
            {
                var loopTo = E_Globals.Max_Classes;
                // but if its somewhere in the middle, or beginning, it gets harder xD
                for (i = 1; i <= loopTo; i++)
                    // we shift everything thats beneath the selected class, up 1 slot
                    Types.Classes[E_Globals.Editorindex] = Types.Classes[E_Globals.Editorindex + 1];

                // and then we remove it, and redim
                E_Globals.Max_Classes = (byte)(E_Globals.Max_Classes - 1);
                var oldClasses1 = Types.Classes;
                Types.Classes = new ClassRec[E_Globals.Max_Classes + 1];
                if (oldClasses1 != null)
                    Array.Copy(oldClasses1, Types.Classes, Math.Min(E_Globals.Max_Classes + 1, oldClasses1.Length));
            }

            E_Editors.ClassEditorInit();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            E_Editors.ClassesEditorOk();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            E_Editors.ClassesEditorCancel();
        }

        private void TxtDescription_TextChanged(object sender, EventArgs e)
        {
            Types.Classes[E_Globals.Editorindex].Desc = txtDescription.Text;
        }

        private void TxtName_TextChanged(object sender, EventArgs e)
        {
            int tmpindex;
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            tmpindex = lstIndex.SelectedIndex;
            Types.Classes[E_Globals.Editorindex].Name = txtName.Text.Trim();
            lstIndex.Items.RemoveAt(E_Globals.Editorindex - 1);
            lstIndex.Items.Insert(E_Globals.Editorindex - 1, Types.Classes[E_Globals.Editorindex].Name.Trim());
            lstIndex.SelectedIndex = tmpindex;
        }



        private void BtnAddMaleSprite_Click(object sender, EventArgs e)
        {
            byte tmpamount;
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            tmpamount = (byte)Information.UBound(Types.Classes[E_Globals.Editorindex].MaleSprite);
            var oldMaleSprite = Types.Classes[E_Globals.Editorindex].MaleSprite;
            Types.Classes[E_Globals.Editorindex].MaleSprite = new int[tmpamount + 1 + 1];
            if (oldMaleSprite != null)
                Array.Copy(oldMaleSprite, Types.Classes[E_Globals.Editorindex].MaleSprite, Math.Min(tmpamount + 1 + 1, oldMaleSprite.Length));

            Types.Classes[E_Globals.Editorindex].MaleSprite[tmpamount + 1] = 1;

            E_Globals.LoadClassInfo = true;
        }

        private void BtnDeleteMaleSprite_Click(object sender, EventArgs e)
        {
            byte tmpamount;
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            tmpamount = (byte)Information.UBound(Types.Classes[E_Globals.Editorindex].MaleSprite);
            var oldMaleSprite = Types.Classes[E_Globals.Editorindex].MaleSprite;
            Types.Classes[E_Globals.Editorindex].MaleSprite = new int[tmpamount - 1 + 1];
            if (oldMaleSprite != null)
                Array.Copy(oldMaleSprite, Types.Classes[E_Globals.Editorindex].MaleSprite, Math.Min(tmpamount - 1 + 1, oldMaleSprite.Length));

            E_Globals.LoadClassInfo = true;
        }

        private void BtnAddFemaleSprite_Click(object sender, EventArgs e)
        {
            byte tmpamount;
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            tmpamount = (byte)Information.UBound(Types.Classes[E_Globals.Editorindex].FemaleSprite);
            var oldFemaleSprite = Types.Classes[E_Globals.Editorindex].FemaleSprite;
            Types.Classes[E_Globals.Editorindex].FemaleSprite = new int[tmpamount + 1 + 1];
            if (oldFemaleSprite != null)
                Array.Copy(oldFemaleSprite, Types.Classes[E_Globals.Editorindex].FemaleSprite, Math.Min(tmpamount + 1 + 1, oldFemaleSprite.Length));

            Types.Classes[E_Globals.Editorindex].FemaleSprite[tmpamount + 1] = 1;

            E_Globals.LoadClassInfo = true;
        }

        private void BtnDeleteFemaleSprite_Click(object sender, EventArgs e)
        {
            byte tmpamount;
            if (E_Globals.Editorindex == 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            tmpamount = (byte)Information.UBound(Types.Classes[E_Globals.Editorindex].FemaleSprite);
            var oldFemaleSprite = Types.Classes[E_Globals.Editorindex].FemaleSprite;
            Types.Classes[E_Globals.Editorindex].FemaleSprite = new int[tmpamount - 1 + 1];
            if (oldFemaleSprite != null)
                Array.Copy(oldFemaleSprite, Types.Classes[E_Globals.Editorindex].FemaleSprite, Math.Min(tmpamount - 1 + 1, oldFemaleSprite.Length));

            E_Globals.LoadClassInfo = true;
        }

        private void NudMaleSprite_ValueChanged(object sender, EventArgs e)
        {
            if (cmbMaleSprite.SelectedIndex < 0)
                return;

            Types.Classes[E_Globals.Editorindex].MaleSprite[cmbMaleSprite.SelectedIndex] = (int)nudMaleSprite.Value;

            DrawPreview();
        }

        private void NudFemaleSprite_ValueChanged(object sender, EventArgs e)
        {
            if (cmbFemaleSprite.SelectedIndex < 0)
                return;

            Types.Classes[E_Globals.Editorindex].FemaleSprite[cmbFemaleSprite.SelectedIndex] = (int)nudFemaleSprite.Value;

            DrawPreview();
        }

        private void CmbMaleSprite_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudMaleSprite.Value = Types.Classes[E_Globals.Editorindex].MaleSprite[cmbMaleSprite.SelectedIndex];
            DrawPreview();
        }

        private void CmbFemaleSprite_SelectedIndexChanged(object sender, EventArgs e)
        {
            nudFemaleSprite.Value = Types.Classes[E_Globals.Editorindex].FemaleSprite[cmbFemaleSprite.SelectedIndex];
            DrawPreview();
        }

        public void DrawPreview()
        {
            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Characters\" + nudMaleSprite.Value + E_Globals.GFX_EXT))
            {
                picMale.Width = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"characters\" + nudMaleSprite.Value + E_Globals.GFX_EXT).Width / 4;
                picMale.Height = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"characters\" + nudMaleSprite.Value + E_Globals.GFX_EXT).Height / 4;
                picMale.BackgroundImage = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"Characters\" + nudMaleSprite.Value + E_Globals.GFX_EXT);
            }

            if (File.Exists(Application.StartupPath + E_Globals.GFX_PATH + @"Characters\" + nudFemaleSprite.Value + E_Globals.GFX_EXT))
            {
                picFemale.Width = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"characters\" + nudFemaleSprite.Value + E_Globals.GFX_EXT).Width / 4;
                picFemale.Height = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"characters\" + nudFemaleSprite.Value + E_Globals.GFX_EXT).Height / 4;
                picFemale.BackgroundImage = Image.FromFile(Application.StartupPath + E_Globals.GFX_PATH + @"Characters\" + nudFemaleSprite.Value + E_Globals.GFX_EXT);
            }
        }

        private void PicMale_Paint(object sender, EventArgs e)
        {
        }

        private void PicFemale_Paint(object sender, EventArgs e)
        {
        }



        private void NumStrength_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Strength] = (byte)nudStrength.Value;
        }

        private void NumLuck_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Luck] = (byte)nudLuck.Value;
        }

        private void NumEndurance_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Endurance] = (byte)nudEndurance.Value;
        }

        private void NumIntelligence_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Intelligence] = (byte)nudIntelligence.Value;
        }

        private void NumVitality_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Vitality] = (byte)nudVitality.Value;
        }

        private void NumSpirit_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            Types.Classes[E_Globals.Editorindex].Stat[(byte)Enums.StatType.Spirit] = (byte)nudSpirit.Value;
        }

        private void NumBaseExp_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            Types.Classes[E_Globals.Editorindex].BaseExp = (byte)nudBaseExp.Value;
        }



        private void BtnItemAdd_Click(object sender, EventArgs e)
        {
            if (lstStartItems.SelectedIndex < 0 || cmbItems.SelectedIndex < 0)
                return;

            Types.Classes[E_Globals.Editorindex].StartItem[lstStartItems.SelectedIndex + 1] = cmbItems.SelectedIndex;
            Types.Classes[E_Globals.Editorindex].StartValue[lstStartItems.SelectedIndex + 1] = (byte)nudItemAmount.Value;

            E_Globals.LoadClassInfo = true;
        }



        private void NumStartMap_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            Types.Classes[E_Globals.Editorindex].StartMap = (byte)nudStartMap.Value;
        }

        private void NumStartX_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            Types.Classes[E_Globals.Editorindex].StartX = (byte)nudStartX.Value;
        }

        private void NumStartY_ValueChanged(object sender, EventArgs e)
        {
            if (E_Globals.Editorindex <= 0 || E_Globals.Editorindex > E_Globals.Max_Classes)
                return;

            Types.Classes[E_Globals.Editorindex].StartY = (byte)nudStartY.Value;
        }
    }
}
