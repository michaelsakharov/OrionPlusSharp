using System.Windows.Forms;
using System;
using System.IO;
using SFML.Audio;

namespace Engine
{
    static class E_Sound
    {

        // Music + Sound Players
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

        public static void PlayMusic(string FileName)
        {
            if (!(E_Types.Options.Music == 1) || !File.Exists(Application.StartupPath + E_Globals.MUSIC_PATH + FileName))
                return;
            if (FileName == CurMusic)
                return;

            if (MusicPlayer == null)
            {
                try
                {
                    MusicPlayer = new Music(Application.StartupPath + E_Globals.MUSIC_PATH + FileName);
                    MusicPlayer.Loop = true;
                    MusicPlayer.Volume = 0;
                    MusicPlayer.Play();
                    CurMusic = FileName;
                    FadeInSwitch = true;
                }
                catch (Exception ex)
                {
                }
            }
            else
                try
                {
                    CurMusic = FileName;
                    FadeOutSwitch = true;
                }
                catch (Exception ex)
                {
                }
        }

        public static void StopMusic()
        {
            if (MusicPlayer == null)
                return;
            MusicPlayer.Stop();
            MusicPlayer.Dispose();
            MusicPlayer = null;
            CurMusic = "";
        }

        public static void PlayPreview(string FileName)
        {
            if (!(E_Types.Options.Music == 1) || !File.Exists(Application.StartupPath + E_Globals.MUSIC_PATH + FileName))
                return;

            if (PreviewPlayer == null)
            {
                try
                {
                    PreviewPlayer = new Music(Application.StartupPath + E_Globals.MUSIC_PATH + FileName);
                    PreviewPlayer.Loop = true;
                    PreviewPlayer.Volume = 75;
                    PreviewPlayer.Play();
                }
                catch (Exception ex)
                {
                }
            }
            else
                try
                {
                    StopPreview();
                    PreviewPlayer = new Music(Application.StartupPath + E_Globals.MUSIC_PATH + FileName);
                    PreviewPlayer.Loop = true;
                    PreviewPlayer.Volume = 75;
                    PreviewPlayer.Play();
                }
                catch (Exception ex)
                {
                }
        }

        public static void StopPreview()
        {
            if (PreviewPlayer == null)
                return;
            PreviewPlayer.Stop();
            PreviewPlayer.Dispose();
            PreviewPlayer = null;
        }

        public static void PlaySound(string FileName, bool Looped = false)
        {
            if (!(E_Types.Options.Sound == 1) || !File.Exists(Application.StartupPath + E_Globals.SOUND_PATH + FileName))
                return;

            SoundBuffer buffer;
            if (SoundPlayer == null)
            {
                SoundPlayer = new Sound();
                buffer = new SoundBuffer(Application.StartupPath + E_Globals.SOUND_PATH + FileName);
                SoundPlayer.SoundBuffer = buffer;
                if (Looped == true)
                    SoundPlayer.Loop = true;
                else
                    SoundPlayer.Loop = false;
                SoundPlayer.Volume = MaxVolume;
                SoundPlayer.Play();
            }
            else
            {
                SoundPlayer.Stop();
                buffer = new SoundBuffer(Application.StartupPath + E_Globals.SOUND_PATH + FileName);
                SoundPlayer.SoundBuffer = buffer;
                if (Looped == true)
                    SoundPlayer.Loop = true;
                else
                    SoundPlayer.Loop = false;
                SoundPlayer.Volume = MaxVolume;
                SoundPlayer.Play();
            }
        }

        public static void StopSound()
        {
            if (SoundPlayer == null)
                return;
            SoundPlayer.Dispose();
            SoundPlayer = null;
        }

        public static void PlayExtraSound(string FileName, bool Looped = false)
        {
            if (!(E_Types.Options.Sound == 1) || !File.Exists(Application.StartupPath + E_Globals.SOUND_PATH + FileName))
                return;
            // If FileName = CurExtraSound Then Exit Sub

            SoundBuffer buffer;
            if (ExtraSoundPlayer == null)
            {
                ExtraSoundPlayer = new Sound();
                buffer = new SoundBuffer(Application.StartupPath + E_Globals.SOUND_PATH + FileName);
                ExtraSoundPlayer.SoundBuffer = buffer;
                if (Looped == true)
                    ExtraSoundPlayer.Loop = true;
                else
                    ExtraSoundPlayer.Loop = false;
                ExtraSoundPlayer.Volume = MaxVolume;
                ExtraSoundPlayer.Play();
            }
            else
            {
                ExtraSoundPlayer.Stop();
                buffer = new SoundBuffer(Application.StartupPath + E_Globals.SOUND_PATH + FileName);
                ExtraSoundPlayer.SoundBuffer = buffer;
                if (Looped == true)
                    ExtraSoundPlayer.Loop = true;
                else
                    ExtraSoundPlayer.Loop = false;
                ExtraSoundPlayer.Volume = MaxVolume;
                ExtraSoundPlayer.Play();
            }
        }

        public static void StopExtraSound()
        {
            if (ExtraSoundPlayer == null)
                return;
            ExtraSoundPlayer.Dispose();
            ExtraSoundPlayer = null;
        }

        public static void FadeIn()
        {
            if (MusicPlayer == null)
                return;

            if (MusicPlayer.Volume >= MaxVolume)
                FadeInSwitch = false;
            MusicPlayer.Volume = MusicPlayer.Volume + 3;
        }

        public static void FadeOut()
        {
            string tmpmusic;
            if (MusicPlayer == null)
                return;

            if (MusicPlayer.Volume == 0 || MusicPlayer.Volume < 3)
            {
                FadeOutSwitch = false;
                if (CurMusic == "")
                    StopMusic();
                else
                {
                    tmpmusic = CurMusic;
                    StopMusic();
                    PlayMusic(tmpmusic);
                }
            }
            if (MusicPlayer == null)
                return;

            MusicPlayer.Volume = MusicPlayer.Volume - 3;
        }
    }
}
