using System;

namespace orangeBrowser_Kai.util
{
	static partial class Extensions
	{
		static public T GetLastContents<T>(this T[] array)
		{
			return array[array.Length - 1];
		}

		static public void ForEach<T>(this T[] array, Action<T> action)
		{
			Array.ForEach(array, action);
		}
	}
}
