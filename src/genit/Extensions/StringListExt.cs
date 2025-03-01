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
	}
}
