
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.IO;
using System.Windows.Forms;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using Engine;


namespace Engine
{
	internal sealed class C_Weather
	{
		
#region Types and Globals
		
		internal const int MaxWeatherParticles = 100;
		
		internal static WeatherParticleRec[] WeatherParticle = new WeatherParticleRec[MaxWeatherParticles + 1];
		internal static Sound WeatherSoundPlayer;
		internal static string CurWeatherMusic;
		
		public struct WeatherParticleRec
		{
			public int Type;
			public int X;
			public int Y;
			public int Velocity;
			public int InUse;
		}
		
		internal static int FogOffsetX;
		internal static int FogOffsetY;
		
		internal static int CurrentWeather;
		internal static int CurrentWeatherIntensity;
		internal static int CurrentFog;
		internal static int CurrentFogSpeed;
		internal static int CurrentFogOpacity;
		internal static int CurrentTintR;
		internal static int CurrentTintG;
		internal static int CurrentTintB;
		internal static int CurrentTintA;
		internal static int DrawThunder;
		
#endregion
		
#region Drawing
		
		internal static void DrawThunderEffect()
		{
			
			if (DrawThunder > 0)
			{
				Sprite tmpSprite = default(Sprite);
				tmpSprite = new Sprite(new Texture(new SFML.Graphics.Image(C_Graphics.GameWindow.Size.X, C_Graphics.GameWindow.Size.Y, SFML.Graphics.Color.White))) {
						Color = new Color((byte) 255, (byte) 255, (byte) 255, (byte) 150),
						TextureRect = new IntRect(0, 0, (int)C_Graphics.GameWindow.Size.X, (int)C_Graphics.GameWindow.Size.Y),
						Position = new Vector2f(0, 0)
					};
				
				C_Graphics.GameWindow.Draw(tmpSprite); //
				
				DrawThunder--;
				
				tmpSprite.Dispose();
			}
		}
		
		internal static void DrawWeather()
		{
			int i = 0;
			int spriteLeft = 0;
			
			for (i = 1; i <= MaxWeatherParticles; i++)
			{
				if (System.Convert.ToBoolean(WeatherParticle[i].InUse))
				{
					if (WeatherParticle[i].Type == (int) Enums.WeatherType.Storm)
					{
						spriteLeft = 0;
					}
					else
					{
						spriteLeft = WeatherParticle[i].Type - 1;
					}
					
					C_Graphics.RenderSprite(C_Graphics.WeatherSprite, C_Graphics.GameWindow, C_Graphics.ConvertMapX(WeatherParticle[i].X), C_Graphics.ConvertMapY(WeatherParticle[i].Y), spriteLeft * 32, 0, 32, 32);
				}
			}
			
		}
		
		internal static void DrawFog()
		{
			int fogNum = 0;
			
			fogNum = CurrentFog;
			if (fogNum <= 0 || fogNum > C_Graphics.NumFogs)
			{
				return;
			}
			
			if (C_Graphics.FogGfxInfo[fogNum].IsLoaded == false)
			{
				C_Graphics.LoadTexture(fogNum, (byte) 8);
			}
			
			//seeying we still use it, lets update timer
			ref var with_1 = ref C_Graphics.FogGfxInfo[fogNum];
			with_1.TextureTimer = C_General.GetTickCount() + 100000;
			
			C_Graphics.FogGfx[fogNum].Repeated = true;
			C_Graphics.FogGfx[fogNum].Smooth = true;
			
			C_Graphics.FogSprite[fogNum].Color = new Color(255, 255, 255, (byte)CurrentFogOpacity);
			C_Graphics.FogSprite[fogNum].TextureRect = new IntRect(0, 0, (int)C_Graphics.GameWindow.Size.X + 200, (int)C_Graphics.GameWindow.Size.Y + 200);
			C_Graphics.FogSprite[fogNum].Position = new Vector2f((float) ((FogOffsetX * 2.5) - 50), (float) ((FogOffsetY * 3.5) - 50));
			C_Graphics.FogSprite[fogNum].Scale = new Vector2f((float) ((C_Graphics.GameWindow.Size.X + 200) / C_Graphics.FogGfxInfo[fogNum].Width), (float) ((C_Graphics.GameWindow.Size.Y + 200) / C_Graphics.FogGfxInfo[fogNum].Height));
			
			C_Graphics.GameWindow.Draw(C_Graphics.FogSprite[fogNum]);
			
		}
		
#endregion
		
#region Functions
		
		public static void ProcessWeather()
		{
			int i = 0;
			int x;
			
			if (CurrentWeather > 0 && CurrentWeather <= (int)Enums.WeatherType.Fog)
			{
				if (CurrentWeather == (int) Enums.WeatherType.Rain || CurrentWeather == (int) Enums.WeatherType.Storm)
				{
					PlayWeatherSound("Rain.ogg", true);
				}
				x = C_GameLogic.Rand(1, 101 - CurrentWeatherIntensity);
				if (x == 1)
				{
					//Add a new particle
					for (i = 1; i <= MaxWeatherParticles; i++)
					{
						if (WeatherParticle[i].InUse == 0)
						{
							if (C_GameLogic.Rand(1, 3) == 1)
							{
								WeatherParticle[i].InUse = 1;
								WeatherParticle[i].Type = CurrentWeather;
								WeatherParticle[i].Velocity = C_GameLogic.Rand(8, 14);
								WeatherParticle[i].X = (C_Variables.TileView.Left * 32) - 32;
								WeatherParticle[i].Y = (C_Variables.TileView.Top * 32) + C_GameLogic.Rand(-32, (int)C_Graphics.GameWindow.Size.Y);
							}
							else
							{
								WeatherParticle[i].InUse = 1;
								WeatherParticle[i].Type = CurrentWeather;
								WeatherParticle[i].Velocity = C_GameLogic.Rand(10, 15);
								WeatherParticle[i].X = (C_Variables.TileView.Left * 32) + C_GameLogic.Rand(-32, (int)C_Graphics.GameWindow.Size.X);
								WeatherParticle[i].Y = (C_Variables.TileView.Top * 32) - 32;
							}
							//Exit For
						}
					}
				}
			}
			else
			{
				StopWeatherSound();
			}
			if (CurrentWeather == (int) Enums.WeatherType.Storm)
			{
				x = C_GameLogic.Rand(1, 400 - CurrentWeatherIntensity);
				if (x == 1)
				{
					//Draw Thunder
					DrawThunder = C_GameLogic.Rand(15, 22);
					C_Sound.PlayExtraSound("Thunder.ogg");
				}
			}
			for (i = 1; i <= MaxWeatherParticles; i++)
			{
				if (WeatherParticle[i].InUse == 1)
				{
					if (WeatherParticle[i].X > C_Variables.TileView.Right * 32 || WeatherParticle[i].Y > C_Variables.TileView.Bottom * 32)
					{
						WeatherParticle[i].InUse = 0;
					}
					else
					{
						WeatherParticle[i].X = WeatherParticle[i].X + WeatherParticle[i].Velocity;
						WeatherParticle[i].Y = WeatherParticle[i].Y + WeatherParticle[i].Velocity;
					}
				}
			}
			
		}
		
#endregion
		
#region Sound
		
		public static void PlayWeatherSound(string fileName, bool looped = false)
		{
			if (!(C_Types.Options.Sound == 1) || !File.Exists(Application.StartupPath + C_Constants.SoundPath + fileName))
			{
				return;
			}
			if (CurWeatherMusic == fileName)
			{
				return;
			}
			
			SoundBuffer buffer = default(SoundBuffer);
			if (ReferenceEquals(WeatherSoundPlayer, null))
			{
				WeatherSoundPlayer = new Sound();
			}
			else
			{
				WeatherSoundPlayer.Stop();
			}
			
			buffer = new SoundBuffer(Application.StartupPath + C_Constants.SoundPath + fileName);
			WeatherSoundPlayer.SoundBuffer = buffer;
			if (looped == true)
			{
				WeatherSoundPlayer.Loop = true;
			}
			else
			{
				WeatherSoundPlayer.Loop = false;
			}
			WeatherSoundPlayer.Volume = C_Sound.MaxVolume;
			WeatherSoundPlayer.Play();
			
			CurWeatherMusic = fileName;
		}
		
		public static void StopWeatherSound()
		{
			if (ReferenceEquals(WeatherSoundPlayer, null))
			{
				return;
			}
			WeatherSoundPlayer.Dispose();
			WeatherSoundPlayer = null;
			
			CurWeatherMusic = "";
		}
		
#endregion
		
	}
}
