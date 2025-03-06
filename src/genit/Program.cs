using System;
using System.Windows.Forms;

namespace Dyvenix.Genit
{
	internal static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF1cWmhIfEx1RHxQdld5ZFRHallYTnNWUj0eQnxTdEBjWn9fcHxXQWRUWERwXQ==");

			// To customize application configuration such as set high DPI settings or default font,
			// see https://aka.ms/applicationconfiguration.
			ApplicationConfiguration.Initialize();
			Application.SetColorMode(SystemColorMode.Dark);
			Application.Run(new MainForm());
		}
	}
}