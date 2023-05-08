using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace CasseBriques {
	static class Program {
		/// <summary>
		/// Point d'entrée principal de l'application.
		/// </summary>
		[STAThread]
		static void Main() {
			string json = File.ReadAllText("config.json");
			JObject config = JObject.Parse(json);

			// Lit la quantité maximale de mémoire utilisable
			long maxMemory = (long)config["RamConfig"]["MaxRAMinB"];

			Process process = Process.GetCurrentProcess();
			process.MaxWorkingSet = new IntPtr(maxMemory);

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
            try 
			{
				Application.Run(new CB());
			}
			catch(Exception e)
            {
				MessageBox.Show(e.Message+"\n"+e.StackTrace, "Error");
            }
		}
	}
}
