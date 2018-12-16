
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
using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.CompilerServices;
using Engine;


namespace Engine
{
	namespace My
	{
		
		// The following events are available for MyApplication:
		// Startup: Raised when the application starts, before the startup form is created.
		// Shutdown: Raised after all application forms are closed.  This event is not raised if the application terminates abnormally.
		// UnhandledException: Raised if the application encounters an unhandled exception.
		// StartupNextInstance: Raised when launching a single-instance application and the application is already active.
		// NetworkAvailabilityChanged: Raised when the network connection is connected or disconnected.
		public partial class MyApplication : global::Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
		{
			
			private void MyApplication_UnhandledException(object sender, Microsoft.VisualBasic.ApplicationServices.UnhandledExceptionEventArgs e)
			{
				string myFilePath = "\\ErrorLog.log";
				
				using (StreamWriter sw = new StreamWriter(File.Open(myFilePath, FileMode.Append)))
				{
					sw.WriteLine(DateTime.Now);
					sw.WriteLine(e.Exception.Message);
				}
				
				
				MessageBox.Show("An unexcpected error occured. Application will be terminated.");
				ProjectData.EndApp();
			}
			
		}
		
	}
}
