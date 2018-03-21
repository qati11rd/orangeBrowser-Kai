using System.IO;
using System.Net;
using System.Text;

namespace orangeBrowser_Kai.util
{
	static partial class Extensions
	{
		static public string ReadToEnd(this WebResponse response, Encoding encoding)
		{
			using (var reader = new StreamReader(response.GetResponseStream(), encoding))
			{
				return reader.ReadToEnd();
			}
		}

		static public string ReadToEnd(this WebResponse response)
		{
			using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
