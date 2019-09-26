
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using Engine;

namespace Engine
{
	public struct C_Options
	{
		public string Username;
		public string Password;
		public bool SavePass;
		
		public string MenuMusic;
		public byte Music;
		public byte Sound;
		public float Volume;
		
		public string Ip;
		public int Port;
		public byte ScreenSize;
		public byte VSync;
		public byte UnlockFPS;
		public byte ShowNpcBar;

        //Discord
		public string ApplicationID;
		public string LargeImageKey;
		public string LargeImageText;
		public string SmallImageKey;
	}
}
