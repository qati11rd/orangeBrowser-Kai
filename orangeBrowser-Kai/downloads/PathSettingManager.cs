using System.Collections.Generic;

using orangeBrowser_Kai.util;

namespace orangeBrowser_Kai.downloads
{
	static class PathSettingManager
	{
		private static SettingManager settings;

		private static List<PathSetting> pathSettingList;

		public static void Initialize()
		{
			settings = SettingManager.GetInstance();
		}

		public static List<PathSetting> GetPathSettingList()
		{
			return settings.GetValue<List<PathSetting>>(SettingManager.PrefixPath + "");
		}

		public static string GetPath(string url, string defaultPath)
		{
			var pathSettingList = GetPathSettingList();

			foreach (var pathSetting in pathSettingList)
			{
				if (pathSetting.IsHit(url))
				{
					return pathSetting
				}
			}

			return defaultPath;
		}
	}
}
