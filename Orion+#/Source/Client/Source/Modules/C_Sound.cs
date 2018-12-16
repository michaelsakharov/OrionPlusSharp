
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.IO;
using System.Windows.Forms;
using SFML.Audio;
using Engine;


namespace Engine
{
	sealed class C_Sound
	{
		
		//Music + Sound Players
		internal static Sound SoundPlayer;
		
		internal static Sound ExtraSoundPlayer;
		internal static Music MusicPlayer;
		internal static Music PreviewPlayer;
		internal static string[] MusicCache = new string[101];
		internal static string[] SoundCache = new string[101];
		
		internal static bool FadeInSwitch;
		internal static bool FadeOutSwitch;
		internal static string CurMusic;
		internal static float MaxVolume;
		
		public static void PlayMusic(string fileName)
		{
			if (C_Types.Options.Music == 0 || !File.Exists(Application.StartupPath + C_Constants.MusicPath + fileName))
			{
				return;
			}
			if (fileName == CurMusic)
			{
				return;
			}
			
			if (ReferenceEquals(MusicPlayer, null))
			{
				try
				{
					MusicPlayer = new Music(Application.StartupPath + C_Constants.MusicPath + fileName);
					MusicPlayer.Loop = true;
					MusicPlayer.Volume = 0;
					MusicPlayer.Play();
					CurMusic = fileName;
					FadeInSwitch = true;
				}
				catch (Exception)
				{
					
				}
			}
			else
			{
				try
				{
					CurMusic = fileName;
					FadeOutSwitch = true;
				}
				catch (Exception)
				{
					
				}
			}
		}
		
		public static void StopMusic()
		{
			if (ReferenceEquals(MusicPlayer, null))
			{
				return;
			}
			MusicPlayer.Stop();
			MusicPlayer.Dispose();
			MusicPlayer = null;
			CurMusic = "";
		}
		
		public static void PlayPreview(string fileName)
		{
			if (C_Types.Options.Music == 0 || !File.Exists(Application.StartupPath + C_Constants.MusicPath + fileName))
			{
				return;
			}
			
			if (ReferenceEquals(PreviewPlayer, null))
			{
				try
				{
					PreviewPlayer = new Music(Application.StartupPath + C_Constants.MusicPath + fileName);
					PreviewPlayer.Loop = true;
					PreviewPlayer.Volume = 75;
					PreviewPlayer.Play();
				}
				catch (Exception)
				{
					
				}
			}
			else
			{
				try
				{
					StopPreview();
					PreviewPlayer = new Music(Application.StartupPath + C_Constants.MusicPath + fileName);
					PreviewPlayer.Loop = true;
					PreviewPlayer.Volume = 75;
					PreviewPlayer.Play();
				}
				catch (Exception)
				{
					
				}
			}
		}
		
		public static void StopPreview()
		{
			if (ReferenceEquals(PreviewPlayer, null))
			{
				return;
			}
			PreviewPlayer.Stop();
			PreviewPlayer.Dispose();
			PreviewPlayer = null;
		}
		
		public static void PlaySound(string fileName, bool looped = false)
		{
			if (C_Types.Options.Sound == 0 || !File.Exists(Application.StartupPath + C_Constants.SoundPath + fileName))
			{
				return;
			}
			
			SoundBuffer buffer = default(SoundBuffer);
			if (ReferenceEquals(SoundPlayer, null))
			{
				SoundPlayer = new Sound();
				buffer = new SoundBuffer(Application.StartupPath + C_Constants.SoundPath + fileName);
				SoundPlayer.SoundBuffer = buffer;
				if (looped == true)
				{
					SoundPlayer.Loop = true;
				}
				else
				{
					SoundPlayer.Loop = false;
				}
				SoundPlayer.Volume = MaxVolume;
				SoundPlayer.Play();
			}
			else
			{
				SoundPlayer.Stop();
				buffer = new SoundBuffer(Application.StartupPath + C_Constants.SoundPath + fileName);
				SoundPlayer.SoundBuffer = buffer;
				if (looped == true)
				{
					SoundPlayer.Loop = true;
				}
				else
				{
					SoundPlayer.Loop = false;
				}
				SoundPlayer.Volume = MaxVolume;
				SoundPlayer.Play();
			}
		}
		
		public static void StopSound()
		{
			if (ReferenceEquals(SoundPlayer, null))
			{
				return;
			}
			SoundPlayer.Dispose();
			SoundPlayer = null;
		}
		
		public static void PlayExtraSound(string fileName, bool looped = false)
		{
			if (C_Types.Options.Sound == 0 || !File.Exists(Application.StartupPath + C_Constants.SoundPath + fileName))
			{
				return;
			}
			
			SoundBuffer buffer = default(SoundBuffer);
			if (ReferenceEquals(ExtraSoundPlayer, null))
			{
				ExtraSoundPlayer = new Sound();
				buffer = new SoundBuffer(Application.StartupPath + C_Constants.SoundPath + fileName);
				ExtraSoundPlayer.SoundBuffer = buffer;
				if (looped == true)
				{
					ExtraSoundPlayer.Loop = true;
				}
				else
				{
					ExtraSoundPlayer.Loop = false;
				}
				ExtraSoundPlayer.Volume = MaxVolume;
				ExtraSoundPlayer.Play();
			}
			else
			{
				ExtraSoundPlayer.Stop();
				buffer = new SoundBuffer(Application.StartupPath + C_Constants.SoundPath + fileName);
				ExtraSoundPlayer.SoundBuffer = buffer;
				if (looped == true)
				{
					ExtraSoundPlayer.Loop = true;
				}
				else
				{
					ExtraSoundPlayer.Loop = false;
				}
				ExtraSoundPlayer.Volume = MaxVolume;
				ExtraSoundPlayer.Play();
			}
		}
		
		public static void StopExtraSound()
		{
			if (ReferenceEquals(ExtraSoundPlayer, null))
			{
				return;
			}
			ExtraSoundPlayer.Dispose();
			ExtraSoundPlayer = null;
		}
		
		public static void FadeIn()
		{
			
			if (ReferenceEquals(MusicPlayer, null))
			{
				return;
			}
			
			if (MusicPlayer.Volume>= MaxVolume)
			{
				FadeInSwitch = false;
			}
			MusicPlayer.Volume = MusicPlayer.Volume+ 3;
			
		}
		
		public static void FadeOut()
		{
			string tmpmusic = "";
			if (ReferenceEquals(MusicPlayer, null))
			{
				return;
			}
			
			if (MusicPlayer.Volume== 0 || MusicPlayer.Volume< 3)
			{
				FadeOutSwitch = false;
				if (string.IsNullOrEmpty(CurMusic))
				{
					StopMusic();
				}
				else
				{
					tmpmusic = CurMusic;
					StopMusic();
					PlayMusic(tmpmusic);
				}
			}
			if (ReferenceEquals(MusicPlayer, null))
			{
				return;
			}
			
			MusicPlayer.Volume = MusicPlayer.Volume- 3;
			
		}
		
	}
}
