using System.Collections.Generic;
using System.Xml;

namespace orangeBrowser_Kai.downloads.PathSettings.nico
{
	class Tag : Nico
	{
		public Tag(SearchType searchType, string word) : base(searchType, word)
		{
			this.useAmbiguous = false;
		}

		protected override List<string> GetSearchListBaseNico(string videoId)
		{
			var document = this.GetThumbInfo(videoId);
			var tagElementList = document.GetElementsByTagName("tags");

			var resultList = new List<string>();
			foreach (XmlNode tag in tagElementList)
			{
				resultList.Add(tag.InnerText);
			}

			return resultList;
		}
	}
}
