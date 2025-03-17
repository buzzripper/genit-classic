using Dyvenix.Genit.Misc;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

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

			doc.InitializeOnLoad();

			return doc;
		}

		public static void SaveDoc(Doc doc, string filepath)
		{
			ValidateDoc(doc);

			var docJson = JsonSerializer.Serialize(doc, _serializerOptions);

			File.WriteAllText(filepath, docJson);
		}

		private static void ValidateDoc(Doc doc)
		{
			var errors = new List<string>();

			doc.Validate(errors);

			if (errors.Count > 0)
				throw new ValidationException(errors);
		}
	}
}
