
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.CompilerServices;
using Engine;


namespace Engine
{
	sealed class C_DataBase
	{
		
		internal static string GetFileContents(string fullPath, ref string errInfo)
		{
			string strContents = "";
			StreamReader objReader = default(StreamReader);
			strContents = "";
			try
			{
				objReader = new StreamReader(fullPath);
				strContents = objReader.ReadToEnd();
				objReader.Close();
			}
			catch (Exception ex)
			{
				errInfo = ex.Message;
			}
			return strContents;
		}
		
#region Assets Check
		
		internal static void CheckCharacters()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "characters\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				C_Graphics.NumCharacters++;
				i++;
			}
			
			if (C_Graphics.NumCharacters == 0)
			{
				return;
			}
		}
		
		internal static void CheckPaperdolls()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "paperdolls\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				C_Graphics.NumPaperdolls++;
				i++;
			}
			
			if (C_Graphics.NumPaperdolls == 0)
			{
				return;
			}
		}
		
		internal static void CheckAnimations()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "animations\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				C_Graphics.NumAnimations++;
				i++;
			}
			
			if (C_Graphics.NumAnimations == 0)
			{
				return;
			}
		}
		
		internal static void CheckSkillIcons()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "SkillIcons\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				C_Graphics.NumSkillIcons++;
				i++;
			}
			
			if (C_Graphics.NumSkillIcons == 0)
			{
				return;
			}
		}
		
		internal static void CheckFaces()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Faces\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				C_Graphics.NumFaces++;
				i++;
			}
			
			if (C_Graphics.NumFaces == 0)
			{
				return;
			}
		}
		
		internal static void CheckFog()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Fogs\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				C_Graphics.NumFogs++;
				i++;
			}
			
			if (C_Graphics.NumFogs == 0)
			{
				return;
			}
		}
		
		internal static void CheckEmotes()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Emotes\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				C_Graphics.NumEmotes++;
				i++;
			}
			
			if (C_Graphics.NumEmotes == 0)
			{
				return;
			}
		}
		
		internal static void CheckPanoramas()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Panoramas\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				C_Graphics.NumPanorama++;
				i++;
			}
			
			if (C_Graphics.NumPanorama == 0)
			{
				return;
			}
		}
		
		internal static void CheckParallax()
		{
			int i = 0;
			i = 1;
			
			while (File.Exists(Application.StartupPath + C_Constants.GfxPath + "Parallax\\" + System.Convert.ToString(i) + C_Constants.GfxExt))
			{
				C_Graphics.NumParallax++;
				i++;
			}
			
			if (C_Graphics.NumParallax == 0)
			{
				return;
			}
		}
		
		internal static void CacheMusic()
		{
			string[] files = Directory.GetFiles(Application.StartupPath + C_Constants.MusicPath, "*.ogg");
			string maxNum = System.Convert.ToString(Directory.GetFiles(Application.StartupPath + C_Constants.MusicPath, "*.ogg").Count());
			int counter = 1;
			
			foreach (var FileName in files)
			{
				Array.Resize(ref C_Sound.MusicCache, counter + 1);
				
				C_Sound.MusicCache[counter] = Path.GetFileName(FileName);
				counter++;
                //Do we need todo this?
                //Application.DoEvents();
            }

        }
		
		internal static void CacheSound()
		{
			string[] files = Directory.GetFiles(Application.StartupPath + C_Constants.SoundPath, "*.ogg");
			string maxNum = System.Convert.ToString(Directory.GetFiles(Application.StartupPath + C_Constants.SoundPath, "*.ogg").Count());
			int counter = 1;
			
			foreach (var FileName in files)
			{
				Array.Resize(ref C_Sound.SoundCache, counter + 1);
				
				C_Sound.SoundCache[counter] = Path.GetFileName(FileName);
				counter++;
                //Do we need todo this?
                //Application.DoEvents();
            }

        }
		
#endregion
		
#region Options
		
		internal static void CreateOptions()
		{
			XmlClass myXml = new XmlClass() {
					Filename = Application.StartupPath + "\\Data\\Config.xml",
					Root = "Options"
				};
			
			myXml.NewXmlDocument();
			
			C_Types.Options.Password = "";
			C_Types.Options.SavePass = false;
			C_Types.Options.Username = "";
			C_Types.Options.Ip = "127.0.0.1";
			C_Types.Options.Port = 7001;
			C_Types.Options.MenuMusic = "";
			C_Types.Options.Music = (byte) 1;
			C_Types.Options.Sound = (byte) 1;
			C_Types.Options.Volume = 100;
			C_Types.Options.ScreenSize = (byte) 0;
			C_Types.Options.HighEnd = (byte) 0;
			C_Types.Options.UnlockFPS = (byte) 0;
			C_Types.Options.ShowNpcBar = (byte) 0;
			
			myXml.LoadXml();
			
			myXml.WriteString("UserInfo", "Username", C_Types.Options.Username.Trim());
			myXml.WriteString("UserInfo", "Password", C_Types.Options.Password.Trim());
			myXml.WriteString("UserInfo", "SavePass", Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(C_Types.Options.SavePass)));
			
			myXml.WriteString("Connection", "Ip", C_Types.Options.Ip.Trim());
			myXml.WriteString("Connection", "Port", Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(C_Types.Options.Port)));
			
			myXml.WriteString("Sfx", "MenuMusic", C_Types.Options.MenuMusic.Trim());
			myXml.WriteString("Sfx", "Music", Microsoft.VisualBasic.Strings.Trim(C_Types.Options.Music.ToString()));
			myXml.WriteString("Sfx", "Sound", Microsoft.VisualBasic.Strings.Trim(C_Types.Options.Sound.ToString()));
			myXml.WriteString("Sfx", "Volume", Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(C_Types.Options.Volume)));
			
			myXml.WriteString("Misc", "ScreenSize", Microsoft.VisualBasic.Strings.Trim(C_Types.Options.ScreenSize.ToString()));
			myXml.WriteString("Misc", "HighEnd", Microsoft.VisualBasic.Strings.Trim(C_Types.Options.HighEnd.ToString()));
			myXml.WriteString("Misc", "UnlockFPS", Microsoft.VisualBasic.Strings.Trim(C_Types.Options.UnlockFPS.ToString()));
			myXml.WriteString("Misc", "ShowNpcBar", Microsoft.VisualBasic.Strings.Trim(C_Types.Options.ShowNpcBar.ToString()));
			
			myXml.CloseXml(true);
		}
		
		internal static void SaveOptions()
		{
			XmlClass myXml = new XmlClass() {
					Filename = Application.StartupPath + "\\Data\\Config.xml",
					Root = "Options"
				};
			
			myXml.LoadXml();
			
			myXml.WriteString("UserInfo", "Username", C_Types.Options.Username.Trim());
			myXml.WriteString("UserInfo", "Password", C_Types.Options.Password.Trim());
			myXml.WriteString("UserInfo", "SavePass", Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(C_Types.Options.SavePass)));
			
			myXml.WriteString("Connection", "Ip", C_Types.Options.Ip.Trim());
			myXml.WriteString("Connection", "Port", Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(C_Types.Options.Port)));
			
			myXml.WriteString("Sfx", "MenuMusic", C_Types.Options.MenuMusic.Trim());
			myXml.WriteString("Sfx", "Music", Microsoft.VisualBasic.Strings.Trim(C_Types.Options.Music.ToString()));
			myXml.WriteString("Sfx", "Sound", Microsoft.VisualBasic.Strings.Trim(C_Types.Options.Sound.ToString()));
			myXml.WriteString("Sfx", "Volume", Microsoft.VisualBasic.Strings.Trim(System.Convert.ToString(C_Types.Options.Volume)));
			
			myXml.WriteString("Misc", "ScreenSize", Microsoft.VisualBasic.Strings.Trim(C_Types.Options.ScreenSize.ToString()));
			myXml.WriteString("Misc", "HighEnd", Microsoft.VisualBasic.Strings.Trim(C_Types.Options.HighEnd.ToString()));
			myXml.WriteString("Misc", "UnlockFPS", Microsoft.VisualBasic.Strings.Trim(C_Types.Options.UnlockFPS.ToString()));
			myXml.WriteString("Misc", "ShowNpcBar", Microsoft.VisualBasic.Strings.Trim(C_Types.Options.ShowNpcBar.ToString()));
			
			myXml.CloseXml(true);
		}
		
		internal static void LoadOptions()
		{
			XmlClass myXml = new XmlClass() {
					Filename = Application.StartupPath + "\\Data\\Config.xml",
					Root = "Options"
				};
			
			myXml.LoadXml();
			C_Types.Options.Username = myXml.ReadString("UserInfo", "Username", "");
			C_Types.Options.Password = myXml.ReadString("UserInfo", "Password", "");
			C_Types.Options.SavePass = bool.Parse(myXml.ReadString("UserInfo", "SavePass", "False"));
			
			C_Types.Options.Ip = myXml.ReadString("Connection", "Ip", "127.0.0.1");
			C_Types.Options.Port = (int)(Conversion.Val(myXml.ReadString("Connection", "Port", "7001")));
			
			C_Types.Options.MenuMusic = myXml.ReadString("Sfx", "MenuMusic", "");
			C_Types.Options.Music = byte.Parse(myXml.ReadString("Sfx", "Music", "1"));
			C_Types.Options.Sound = byte.Parse(myXml.ReadString("Sfx", "Sound", "1"));
			C_Types.Options.Volume = (float) (Conversion.Val(myXml.ReadString("Sfx", "Volume", "100")));
			
			C_Types.Options.ScreenSize = byte.Parse(myXml.ReadString("Misc", "ScreenSize", "0"));
			C_Types.Options.HighEnd = (byte) (Conversion.Val(myXml.ReadString("Misc", "HighEnd", "0")));
			C_Types.Options.UnlockFPS = (byte) (Conversion.Val(myXml.ReadString("Misc", "UnlockFPS", "0")));
			C_Types.Options.ShowNpcBar = (byte) (Conversion.Val(myXml.ReadString("Misc", "ShowNpcBar", "1")));
			myXml.CloseXml(true);
			
			// show in GUI
			if (C_Types.Options.Music == 1)
			{
				FrmOptions.Default.optMOn.Checked = true;
			}
			else
			{
				FrmOptions.Default.optMOff.Checked = false;
			}
			
			if (C_Types.Options.Music == 1)
			{
				FrmOptions.Default.optSOn.Checked = true;
			}
			else
			{
				FrmOptions.Default.optSOff.Checked = false;
			}
			
			FrmOptions.Default.lblVolume.Text = "Volume: " + System.Convert.ToString(C_Types.Options.Volume);
			FrmOptions.Default.scrlVolume.Value = (int)C_Types.Options.Volume;
			
			FrmOptions.Default.cmbScreenSize.SelectedIndex = C_Types.Options.ScreenSize;
			
		}
		
#endregion
		
#region Blood
		
		public static void ClearBlood()
		{
			for (var I = 1; I <= byte.MaxValue; I++)
			{
				C_Types.Blood[(int) I].Timer = 0;
			}
		}
		
#endregion
		
#region Npc's
		
		public static void ClearNpcs()
		{
			int i = 0;
			
			Types.Npc = new Types.NpcRec[Constants.MAX_NPCS + 1];
			
			for (i = 1; i <= Constants.MAX_NPCS; i++)
			{
				ClearNpc(i);
			}
			
		}
		
		public static void ClearNpc(int index)
		{
			Types.Npc[index] = new Types.NpcRec {
					Name = "",
					AttackSay = ""
				};
			for (var x = 0; x <= (int) Enums.StatType.Count - 1; x++)
			{
				Types.Npc[index].Stat = new byte[(int) x + 1];
			}
			
			Types.Npc[index].DropChance = new int[6];
			Types.Npc[index].DropItem = new int[6];
			Types.Npc[index].DropItemValue = new int[6];
			
			Types.Npc[index].Skill = new byte[7];
		}
		
#endregion
		
#region Animations
		
		public static void ClearAnimation(int index)
		{
			Types.Animation[index] = new Types.AnimationRec();
			for (var x = 0; x <= 1; x++)
			{
				Types.Animation[index].Sprite = new int[(int) x + 1];
			}
			for (var x = 0; x <= 1; x++)
			{
				Types.Animation[index].Frames = new int[(int) x + 1];
			}
			for (var x = 0; x <= 1; x++)
			{
				Types.Animation[index].LoopCount = new int[(int) x + 1];
			}
			for (var x = 0; x <= 1; x++)
			{
				Types.Animation[index].LoopTime = new int[(int) x + 1];
			}
			Types.Animation[index].Name = "";
		}
		
		public static void ClearAnimations()
		{
			int i = 0;
			
			Types.Animation = new Types.AnimationRec[Constants.MAX_ANIMATIONS + 1];
			
			for (i = 1; i <= Constants.MAX_ANIMATIONS; i++)
			{
				ClearAnimation(i);
			}
			
		}
		
		public static void ClearAnimInstances()
		{
			int i = 0;
			
			C_Types.AnimInstance = new Types.AnimInstanceRec[Constants.MAX_ANIMATIONS + 1];
			
			for (i = 0; i <= Constants.MAX_ANIMATIONS; i++)
			{
				for (var x = 0; x <= 1; x++)
				{
					C_Types.AnimInstance[i].Timer = new int[(int) x + 1];
				}
				for (var x = 0; x <= 1; x++)
				{
					C_Types.AnimInstance[i].Used = new bool[(int) x + 1];
				}
				for (var x = 0; x <= 1; x++)
				{
					C_Types.AnimInstance[i].LoopIndex = new int[(int) x + 1];
				}
				for (var x = 0; x <= 1; x++)
				{
					C_Types.AnimInstance[i].FrameIndex = new int[(int) x + 1];
				}
				
				ClearAnimInstance(i);
			}
		}
		
		public static void ClearAnimInstance(int index)
		{
			C_Types.AnimInstance[index].Animation = 0;
			C_Types.AnimInstance[index].X = 0;
			C_Types.AnimInstance[index].Y = 0;
			
			for (var i = 0; i <= (C_Types.AnimInstance[index].Used.Length - 1); i++)
			{
				C_Types.AnimInstance[index].Used[(int) i] = false;
			}
			for (var i = 0; i <= (C_Types.AnimInstance[index].Timer.Length - 1); i++)
			{
				C_Types.AnimInstance[index].Timer[(int) i] = 0;
			}
			for (var i = 0; i <= (C_Types.AnimInstance[index].FrameIndex.Length - 1); i++)
			{
				C_Types.AnimInstance[index].FrameIndex[(int) i] = 0;
			}
			
			C_Types.AnimInstance[index].LockType = (byte) 0;
			C_Types.AnimInstance[index].lockindex = 0;
		}
		
#endregion
		
#region Skills
		
		public static void ClearSkills()
		{
			int i = 0;
			
			for (i = 1; i <= Constants.MAX_SKILLS; i++)
			{
				ClearSkill(i);
			}
			
		}
		
		public static void ClearSkill(int index)
		{
			Types.Skill[index] = new Types.SkillRec {
					Name = ""
				};
		}
		
#endregion
		
	}
}
