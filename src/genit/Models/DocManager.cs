using System;
using System.Collections.Generic;
using System.IO;
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

			if (!File.Exists(filepath))
				throw new FileNotFoundException($"File not found: {filepath}");	

			var doc = JsonSerializer.Deserialize<Doc>(File.ReadAllText(filepath));
			doc.ModelFilepath = filepath;

			return doc;
		}

		public static void SaveDoc(Doc doc)
		{

		}
	}
}
