using System.Collections.Generic;
using System.Drawing;

namespace Dyvenix.Genit.Config
{
	public class AppConfig
	{
		public AppConfig()
		{
		}

		public Point WindowPosition { get; set; }
		public Size WindowSize { get; set; }
		public int OutputHeight { get; set; }
		public List<string> MruFilepaths { get; set; }

		public void AddMruFilepath(string filepath)
		{
			if (MruFilepaths == null)
				MruFilepaths = new List<string>();

			var idx = MruFilepaths.IndexOf(filepath);
			if (idx >= -1)
				MruFilepaths.RemoveAt(idx);

			MruFilepaths.Insert(0, filepath);

			if (MruFilepaths.Count > 5)
				MruFilepaths.RemoveAt(5);
		}
	}
}
