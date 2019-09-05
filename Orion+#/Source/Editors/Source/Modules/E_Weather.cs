
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
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;
using Engine;


namespace Engine
{
	internal sealed class E_Weather
	{
		internal const int MAX_WEATHER_PARTICLES = 250;
		
		internal static WeatherParticleRec[] WeatherParticle = new WeatherParticleRec[MAX_WEATHER_PARTICLES + 1];
		internal static Sound WeatherSoundPlayer;
		internal static string CurWeatherMusic;
		
		public struct WeatherParticleRec
		{
			public int type;
			public int X;
			public int Y;
			public int Velocity;
			public int InUse;
		}
		
		public static void ProcessWeather()
		{
			int i = 0;
			int x;

            if (E_Globals.CurrentWeather > 0)
            {
                if (E_Globals.CurrentWeather == (int)Enums.WeatherType.Rain || E_Globals.CurrentWeather == (int)Enums.WeatherType.Storm)
                {
                    PlayWeatherSound("Rain.ogg", true);
                }
                //Setup a particle
                for (i = 1; i <= MAX_WEATHER_PARTICLES; i++)
                {
                    if (WeatherParticle[i].InUse == 0)
                    {
                        WeatherParticle[i].InUse = 1;
                        WeatherParticle[i].type = E_Globals.CurrentWeather;
                        if (ClientDataBase.Rand(1, 3) == 1)
                        {
                            WeatherParticle[i].Velocity = ClientDataBase.Rand(8, 14);
                            WeatherParticle[i].X = (E_Globals.TileView.Left * 32) - 32;
                            WeatherParticle[i].Y = (E_Globals.TileView.Top * 32) + ClientDataBase.Rand(-32, (int)E_Graphics.GameWindow.Size.Y);
                        }
                        else
                        {
                            WeatherParticle[i].Velocity = ClientDataBase.Rand(10, 15);
                            WeatherParticle[i].X = (E_Globals.TileView.Left * 32) + ClientDataBase.Rand(-32, (int)E_Graphics.GameWindow.Size.X);
                            WeatherParticle[i].Y = (E_Globals.TileView.Top * 32) - 32;
                        }
                    }
                    else
                    {
                        WeatherParticle[i].type = E_Globals.CurrentWeather;
                    }
                }
            }
            else
            {
                StopWeatherSound();
                for (i = 1; i <= MAX_WEATHER_PARTICLES; i++)
                {
                    if (WeatherParticle[i].InUse == 1)
                    {
                        WeatherParticle[i].InUse = 0;
                    }
                }
            }
			if (E_Globals.CurrentWeather == (int) Enums.WeatherType.Storm)
			{
				x = ClientDataBase.Rand(1, 400 - E_Globals.CurrentWeatherIntensity);
				if (x == 1)
				{
					//Draw Thunder
					E_Globals.DrawThunder = ClientDataBase.Rand(15, 22);
					E_Sound.PlayExtraSound("Thunder.ogg");
				}
			}
			for (i = 1; i <= MAX_WEATHER_PARTICLES; i++)
			{
				if (WeatherParticle[i].InUse == 1)
				{
					if (WeatherParticle[i].X > E_Globals.TileView.Right * 32 || WeatherParticle[i].Y > E_Globals.TileView.Bottom * 32)
					{
						//WeatherParticle[i].InUse = 0;
                        if (ClientDataBase.Rand(1, 3) == 1)
                        {
                            WeatherParticle[i].X = (E_Globals.TileView.Left * 32) - 32;
                            WeatherParticle[i].Y = (E_Globals.TileView.Top * 32) + ClientDataBase.Rand(-32, (int)E_Graphics.GameWindow.Size.Y);
                        }
                        else
                        {
                            WeatherParticle[i].X = (E_Globals.TileView.Left * 32) + ClientDataBase.Rand(-32, (int)E_Graphics.GameWindow.Size.X);
                            WeatherParticle[i].Y = (E_Globals.TileView.Top * 32) - 32;
                        }
                    }
					else
					{
						WeatherParticle[i].X = WeatherParticle[i].X + WeatherParticle[i].Velocity;
						WeatherParticle[i].Y = WeatherParticle[i].Y + WeatherParticle[i].Velocity;
					}
				}
			}
			
		}
		
		internal static void DrawThunderEffect()
		{
			if (E_Globals.InMapEditor)
			{
				return;
			}
			
			if (E_Globals.DrawThunder > 0)
			{
				Sprite tmpSprite = default(Sprite);
				tmpSprite = new Sprite(new Texture(new SFML.Graphics.Image(E_Graphics.GameWindow.Size.X, E_Graphics.GameWindow.Size.Y, SFML.Graphics.Color.White))) {
						Color = new SFML.Graphics.Color(255, 255, 255, 150),
						TextureRect = new IntRect(0, 0, (int)E_Graphics.GameWindow.Size.X, (int)E_Graphics.GameWindow.Size.Y),
						Position = new Vector2f(0, 0)
					};
				
				E_Graphics.GameWindow.Draw(tmpSprite); //
				
				E_Globals.DrawThunder--;
				
				tmpSprite.Dispose();
			}
		}
		
		internal static void DrawWeather()
		{
			int i = 0;
			int SpriteLeft = 0;
			
			//If InMapEditor Then Exit Sub
			
			for (i = 1; i <= MAX_WEATHER_PARTICLES; i++)
			{
				if (System.Convert.ToBoolean(WeatherParticle[i].InUse))
				{
					if (WeatherParticle[i].type == (int) Enums.WeatherType.Storm)
					{
						SpriteLeft = 0;
					}
					else
					{
						SpriteLeft = WeatherParticle[i].type - 1;
					}
					E_Graphics.RenderSprite(E_Graphics.WeatherSprite, E_Graphics.GameWindow, E_Graphics.ConvertMapX(WeatherParticle[i].X), E_Graphics.ConvertMapY(WeatherParticle[i].Y), SpriteLeft * 32, 0, 32, 32);
				}
			}
			
		}
		
		internal static void DrawFog()
		{
			int fogNum = 0;
			
			//If InMapEditor Then Exit Sub
			
			fogNum = E_Globals.CurrentFog;
			if (fogNum <= 0 || fogNum > E_Graphics.NumFogs)
			{
				return;
			}
			
			int horz = 0;
			int vert = 0;
			
			for (var x = E_Globals.TileView.Left; x <= E_Globals.TileView.Right + 1; x++)
			{
				for (var y = E_Globals.TileView.Top; y <= E_Globals.TileView.Bottom + 1; y++)
				{
					if (E_Graphics.IsValidMapPoint(System.Convert.ToInt32(x), System.Convert.ToInt32(y)))
					{
						horz = System.Convert.ToInt32(- x);
						vert = System.Convert.ToInt32(- y);
					}
				}
			}
			
			if (E_Graphics.FogGFXInfo[fogNum].IsLoaded == false)
			{
				E_Graphics.LoadTexture(fogNum, (byte) 8);
			}
			
			//seeying we still use it, lets update timer
            E_Graphics.FogGFXInfo[fogNum].TextureTimer = System.Convert.ToInt32(System.Convert.ToInt32(ClientDataBase.GetTickCount()) + 100000);
			
			Sprite tmpSprite = default(Sprite);
			tmpSprite = new Sprite(E_Graphics.FogGFX[fogNum]) {
					Color = new SFML.Graphics.Color(255, 255, 255, (byte)E_Globals.CurrentFogOpacity),
					TextureRect = new IntRect(0, 0, (int)E_Graphics.GameWindow.Size.X + 200, (int)E_Graphics.GameWindow.Size.Y + 200),
					Position = new Vector2f((float) ((horz * 2.5) + 50), (float) ((vert * 3.5) + 50)),
					Scale = (new Vector2f((float) ((E_Graphics.GameWindow.Size.X + 200) / E_Graphics.FogGFXInfo[fogNum].width), (float) ((E_Graphics.GameWindow.Size.Y + 200) / E_Graphics.FogGFXInfo[fogNum].height)))
				};
			
			E_Graphics.GameWindow.Draw(tmpSprite); //
			
		}
		
		public static void PlayWeatherSound(string FileName, bool Looped = false)
		{
			if (!(E_Types.Options.Sound == 1) || !File.Exists(Application.StartupPath + E_Globals.SOUND_PATH + FileName))
			{
				return;
			}
			if (CurWeatherMusic == FileName)
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
			
			buffer = new SoundBuffer(Application.StartupPath + E_Globals.SOUND_PATH + FileName);
			WeatherSoundPlayer.SoundBuffer = buffer;
			WeatherSoundPlayer.Loop = Looped;
			WeatherSoundPlayer.Volume = E_Sound.MaxVolume;
			WeatherSoundPlayer.Play();
			
			CurWeatherMusic = FileName;
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
		
	}
}
