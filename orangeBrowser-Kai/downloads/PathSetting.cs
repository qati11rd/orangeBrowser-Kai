
using System.Collections.Generic;

namespace orangeBrowser_Kai.downloads
{
	class PathSetting
	{
		public enum SearchType
		{
			NicoTitle,
			NicoTag,
		}

		protected bool useAmbiguous;

		protected SearchType searchType;
		protected string word;
		protected string savePath;

		protected static Dictionary<SearchType, string> searchTypeLastRequestedUrlMap = new Dictionary<SearchType, string>();
		protected static Dictionary<SearchType, List<string>> searchTypeLastSearchListMap = new Dictionary<SearchType, List<string>>();

		public PathSetting(SearchType searchType, string word, string savePath)
		{
			this.searchType = searchType;
			this.word = word;
			this.savePath = savePath;
		}

		protected virtual List<string> GetSearchListBase(string url)
		{
			return null;
		}

		protected List<string> GetSearchList(string url)
		{
			if (url == searchTypeLastRequestedUrlMap[this.searchType])
			{
				return searchTypeLastSearchListMap[this.searchType];
			}

			searchTypeLastSearchListMap[this.searchType] = this.GetSearchListBase(url);
			searchTypeLastRequestedUrlMap[this.searchType] = url;

			return searchTypeLastSearchListMap[this.searchType];
		}

		private bool IsHitBase(string searchStr)
		{
			if (this.useAmbiguous)
			{
				return searchStr.Contains(this.word);
			}
			else
			{
				return searchStr.Equals(this.word);
			}
		}

		public bool IsHit(string url)
		{
			var searchList = this.GetSearchList(url);

			if (searchList == null)
			{
				return false;
			}

			foreach (var searchStr in searchList)
			{
				if (this.IsHitBase(searchStr))
				{
					return true;
				}
			}

			return false;
		}
	}
}
