using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;

using orangeBrowser_Kai.util;

namespace orangeBrowser_Kai.downloads.PathSettings
{
	class Nico : PathSetting
	{
		const string BaseApi = "http://ext.nicovideo.jp/api/getthumbinfo/";

		protected Nico(SearchType searchType, string word) : base(searchType, word)
		{
		}

		protected virtual List<string> GetSearchListBaseNico(string videoId)
		{
			return null;
		}

		protected XmlDocument GetThumbInfo(string videoId)
		{
			var request = WebRequest.Create(BaseApi + videoId);
			var response = request.GetResponse();
			var resText = response.ReadToEnd(Encoding.UTF8);

			var xml = new XmlDocument();
			xml.LoadXml(resText);

			return xml;
		}

		protected override List<string> GetSearchListBase(string url)
		{
			var regex = new Regex(@"/((?:sm|nm|so)\d+)");
			var match = regex.Match(url);

			if (!match.Success)
			{
				return base.GetSearchListBase(url);
			}

			var group = match.Groups[1];

			return this.GetSearchListBaseNico(group.Value);
		}
	}
}
