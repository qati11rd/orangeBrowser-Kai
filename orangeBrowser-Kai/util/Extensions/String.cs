
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
	}
}
