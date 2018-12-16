
using System.Collections;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualBasic;


using System.IO;
using System.Windows.Forms;
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
				string myFilePath = System.Windows.Forms.Application.StartupPath + "\\ErrorLog.log";
				
				using (StreamWriter sw = new StreamWriter(File.Open(myFilePath, FileMode.Append)))
				{
					sw.WriteLine(DateTime.Now);
					sw.WriteLine(C_General.GetExceptionInfo(e.Exception));
				}
				
				
				MessageBox.Show("An unexpected error occured. Check the error log for details.");
				ProjectData.EndApp();
				
			}
			
		}
		
	}
}
