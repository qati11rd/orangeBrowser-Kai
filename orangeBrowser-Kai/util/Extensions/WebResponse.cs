using System.IO;
using System.Net;
using System.Text;

namespace orangeBrowser_Kai.util
{
	static partial class Extensions
	{
		public static string ReadToEnd(this WebResponse response, Encoding encoding)
		{
			using (var reader = new StreamReader(response.GetResponseStream(), encoding))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
