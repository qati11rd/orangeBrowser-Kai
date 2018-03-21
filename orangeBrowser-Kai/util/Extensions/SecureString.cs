using System.Security;

namespace orangeBrowser_Kai.util
{
	static partial class Extensions
	{
		public static string ToString(this SecureString secureString, bool useUnicode)
		{
			using (var converter = new SecureStringConverter(secureString, useUnicode))
			{
				return converter.GetString();
			}
		}
	}
}
