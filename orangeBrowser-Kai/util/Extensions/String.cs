
using CSharp.Japanese.Kanaxs;

namespace orangeBrowser_Kai.util
{
	static partial class Extensions
	{
		public static string ToHankaku(this string str) => KanaEx.ToHankaku(str);

		public static string ToZenkaku(this string str) => KanaEx.ToZenkaku(str);
	}
}
