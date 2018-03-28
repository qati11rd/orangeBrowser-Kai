using System.Collections.Generic;

namespace orangeBrowser_Kai.downloads.PathSettings.nico
{
	class Title : Nico
	{
		public Title(SearchType searchType, string word) : base(searchType, word)
		{
			this.useAmbiguous = true;
		}

		protected override List<string> GetSearchListBaseNico(string videoId)
		{
			var document = this.GetThumbInfo(videoId);
			var titleElementList = document.GetElementsByTagName("title");

			return new List<string>
			{
				titleElementList[0].InnerText,
			};
		}
	}
}
