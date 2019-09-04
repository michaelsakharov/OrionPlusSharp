
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using Engine;

namespace Engine
{
	partial class FrmOptions
	{
		public FrmOptions()
		{
			InitializeComponent();
			
			
			if (defaultInstance == null)
				defaultInstance = this;
		}
		
#region Default Instance
		
		private static FrmOptions defaultInstance;
		
		/// <summary>
		/// The Instance of this Form
		/// </summary>
		public static FrmOptions Default
		{
			get
			{
				if (defaultInstance == null)
				{
					defaultInstance = new FrmOptions();
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
		
#region Options
		
		public void scrlVolume_ValueChanged(object sender, EventArgs e)
		{
			C_Types.Options.Volume = System.Convert.ToSingle(scrlVolume.Value);
			
			C_Sound.MaxVolume = C_Types.Options.Volume;
			
			lblVolume.Text = "Volume: " + System.Convert.ToString(C_Types.Options.Volume);
			
			if (!ReferenceEquals(C_Sound.MusicPlayer, null))
			{
				C_Sound.MusicPlayer.Volume = C_Sound.MaxVolume;
			}
			
		}
		
		public void btnSaveSettings_Click(object sender, EventArgs e)
		{
			//music
			if (optMOn.Checked == true)
			{
				C_Types.Options.Music = (byte) 1;
				// start music playing
				C_Sound.PlayMusic(C_Maps.Map.Music.Trim());
			}
			else
			{
				C_Types.Options.Music = (byte) 0;
				// stop music playing
				C_Sound.StopMusic();
				C_Sound.CurMusic = "";
			}
			
			//sound
			if (optSOn.Checked == true)
			{
				C_Types.Options.Sound = (byte) 1;
			}
			else
			{
				C_Types.Options.Sound = (byte) 0;
				C_Sound.StopSound();
			}
			
			//screensize
			C_Types.Options.ScreenSize = System.Convert.ToByte(cmbScreenSize.SelectedIndex);
			
			if (chkHighEnd.Checked)
			{
				C_Types.Options.HighEnd = (byte) 1;
			}
			else
			{
				C_Types.Options.HighEnd = (byte) 0;
			}

            if (checkBox1.Checked)
            {
                C_Types.Options.UnlockFPS = (byte)1;
            }
            else
            {
                C_Types.Options.UnlockFPS = (byte)0;
            }

            if (chkNpcBars.Checked)
			{
				C_Types.Options.ShowNpcBar = (byte) 1;
			}
			else
			{
				C_Types.Options.ShowNpcBar = (byte) 0;
			}
			
			// save to config.ini
			C_DataBase.SaveOptions();
			
			//reload options
			C_DataBase.LoadOptions();
			
			C_General.RePositionGui();
			
			this.Visible = false;
		}

        #endregion
        
    }
}
