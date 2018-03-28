using System;

namespace orangeBrowser_Kai.util
{
	static partial class Extensions
	{
		public static T GetLastContents<T>(this T[] array)
		{
			return array[array.Length - 1];
		}

		public static void ForEach<T>(this T[] array, Action<T> action)
		{
			Array.ForEach(array, action);
		}
	}
}
