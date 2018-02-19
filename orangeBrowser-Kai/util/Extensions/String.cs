
using System.Collections.Generic;
using CSharp.Japanese.Kanaxs;

namespace orangeBrowser_Kai.util
{
	static partial class Extensions
	{
		public static string ToHankaku(this string str) => KanaEx.ToHankaku(str);

		public static string ToZenkaku(this string str) => KanaEx.ToZenkaku(str);

		public static string RemoveControls(this string str)
		{
			return str
				.Replace("\a", "")
				.Replace("\b", "")
				.Replace("\t", "")
				.Replace("\n", "")
				.Replace("\v", "")
				.Replace("\f", "")
				.Replace("\r", "")
				.Replace("\0", "");
		}

		public static string Replace(this string str, KeyValuePair<string, string> pair, bool addLastIfEmptyKey = true)
		{
			if (pair.Key.Length == 0)
			{
				if (addLastIfEmptyKey)
				{
					return str + pair.Value;
				}
				else
				{
					return pair.Value + str;
				}
			}

			return str.Replace(pair.Key, pair.Value);
		}

		public static string Replace(this string str, KeyValuePair<char, char> pair)
		{
			return str.Replace(pair.Key, pair.Value);
		}
	}
}
