using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Dyvenix.Genit.Models
{
	public static class DocManager
	{
		private static readonly JsonSerializerOptions _serializerOptions = new JsonSerializerOptions { WriteIndented = true };

		public static Doc LoadDoc(string filepath)
		{
			if (filepath == "TEST")
				return Utils.GenerateTestDoc();

			return null;
		}

		public static void SaveDoc(Doc doc)
		{

		}
	}
}
