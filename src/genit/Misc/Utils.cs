using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace Dyvenix.Genit.Misc
{
	public static class Utils
	{
		public static string ConvertToRelative(string baseFilepath, string path)
		{
			if (!Path.IsPathRooted(baseFilepath))
				throw new ApplicationException($"Base path is not an absolute path ({baseFilepath})");
			if (!Path.IsPathRooted(path))
				throw new ApplicationException($"File path is already a relative path ({path})");

			Uri baseUri = new Uri(baseFilepath);
			Uri fileUri = new Uri(path);
			return Uri.UnescapeDataString(baseUri.MakeRelativeUri(fileUri).ToString()).Replace('/', '\\');
		}

		public static string ResolveRelativePath(string basePath, string path)
		{
			if (string.IsNullOrWhiteSpace(basePath) || string.IsNullOrWhiteSpace(path))
				return path;

			if (Path.IsPathRooted(path))
				return path;

			var bp = Path.GetDirectoryName(basePath);   // In case it's a filepath

			return Path.GetFullPath(Path.Combine(bp, path));
		}

		public static string FmtToken(string tokenTitle)
		{
			return $"${{{{{tokenTitle}}}}}";
		}

		public static string ToCamelCase(string input)
		{
			if (string.IsNullOrWhiteSpace(input))
				return input;

			if (input.Length == 1)
				return input.ToLower();

			var firstChar = input.Substring(0, 1).ToLower();
			return $"{firstChar}{input.Substring(1)}";
		}

		public static List<string> BuildAddlUsingsList(ObservableCollection<string> attrs)
		{
			var usings = new List<string>();
			attrs?.ToList().ForEach(a => usings.Add(a));
			return usings;
		}
	}
}
