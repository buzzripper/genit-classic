using System.Collections.Generic;

namespace Dyvenix.Genit.Extensions
{
	public static class StringListExt
	{
		public static void AddIfNotExists(this List<string> list, string newValue)
		{
			if (!list.Contains(newValue))
				list.Add(newValue);
		}

		public static void AddLine(this List<string> list, int tabCount, string line)
		{
			list.Add($"{Tabs(tabCount)}{line}");
		}

		public static void AddLine(this List<string> list)
		{
			list.Add(string.Empty);
		}

		private static string Tabs(int count)
		{
			return new string('\t', count);
		}
	}
}
