
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
	public struct E_Options
	{
		public string Username;
		public string Password;
		public bool SavePass;
		
		public string MenuMusic;
		public byte Music;
		public byte Sound;
		public float Volume;
		
		public string IP;
		public int Port;
		public byte ScreenSize;
	}
}
