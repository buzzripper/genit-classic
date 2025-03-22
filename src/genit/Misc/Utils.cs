using System;
using System.IO;
using System.Threading;

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

		//public static string ConvertFolderpathToRelative(string basePath, string filepath)
		//{
		//	var bp = Path.GetDirectoryName(basePath); // In case it's a filename
		//	var fp = 
		//	if (!Path.IsPathRooted(bp))
		//		throw new ApplicationException($"Base path is not an absolute path ({bp})");
		//	if (Path.IsPathRooted(filepath))
		//		throw new ApplicationException($"File path is already a relative path ({filepath})");

		//	Uri baseUri = new Uri(bp);
		//	Uri fileUri = new Uri(filepath);
		//	return Uri.UnescapeDataString(baseUri.MakeRelativeUri(fileUri).ToString()).Replace('/', '\\');
		//}

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
	}
}
