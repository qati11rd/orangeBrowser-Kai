using System.Collections.Generic;

namespace orangeBrowser_Kai.util
{
	static partial class Extensions
	{
		// 毎回作成するので注意。
		public static KeyValuePair<TValue, TKey> Swap<TKey, TValue>(this KeyValuePair<TKey, TValue> pair)
		{
			return new KeyValuePair<TValue, TKey>(pair.Value, pair.Key);
		}
	}
}
