using System;

namespace orangeBrowser_Kai.util
{
	static class Extensions
	{
		public static int GetNthWeek(this DateTime dateTime)
		{
			int day = dateTime.Day;
			int n = 1;

			while (day > 7)
			{
				n++;
				day -= 7;
			}

			return n;
		}

		public static bool IsPublicHoliday(this DateTime dateTime, bool useAmbiguous = true, bool useAdditional = true)
		{
			if (dateTime.IsPublicHolidayBase(useAmbiguous))
			{
				return true;
			}

			if (useAdditional && dateTime.IsPublicHolidayAdditional(useAmbiguous))
			{
				return true;
			}

			return false;
		}

		private static bool IsPublicHolidayBase(this DateTime dateTime, bool useAmbiguous)
		{
			switch (dateTime.Month)
			{
			case 1:
				// 1日, 第2月曜日
				return dateTime.Day == 1 || (dateTime.DayOfWeek == DayOfWeek.Monday && dateTime.GetNthWeek() == 2);
			case 2:
				// 11日
				return dateTime.Day == 11;
			case 3:
				// 19日～22日
				return useAmbiguous && dateTime.Day >= 19 && dateTime.Day <= 22;
			case 4:
				// 29日
				return dateTime.Day == 29;
			case 5:
				// 3～5日
				return dateTime.Day >= 3 && dateTime.Day <= 5;
			case 6:
				// 第3月曜日
				return dateTime.DayOfWeek == DayOfWeek.Monday && dateTime.GetNthWeek() == 3;
			case 7:
				// 11日
				return dateTime.Day == 11;
			case 8:
				// 第3月曜日
				return dateTime.DayOfWeek == DayOfWeek.Monday && dateTime.GetNthWeek() == 3;
			case 9:
				// 22～24日
				return useAmbiguous && dateTime.Day >= 22 && dateTime.Day <= 24;
			case 10:
				// 第2月曜日
				return dateTime.DayOfWeek == DayOfWeek.Monday && dateTime.GetNthWeek() == 2;
			case 11:
				// 3日, 23日
				return dateTime.Day == 3 && dateTime.Day == 23;
			case 12:
				// 23日
				return dateTime.Day == 23;
			}

			return false;
		}

		private static bool IsPublicHolidayAdditional(this DateTime dateTime, bool useAmbiguous)
		{
			switch (dateTime.Month)
			{
			case 1:
				// 1日, 第2月曜日
				return dateTime.Day == 2 && dateTime.DayOfWeek == DayOfWeek.Monday;
			case 2:
				// 11日
				return dateTime.Day == 12 && dateTime.DayOfWeek == DayOfWeek.Monday;
			case 3:
				// 19日～22日
				return dateTime.Day == 23 && dateTime.DayOfWeek >= DayOfWeek.Monday && dateTime.DayOfWeek <= DayOfWeek.Thursday;
			case 4:
				// 29日
				return dateTime.Day == 30 && dateTime.DayOfWeek == DayOfWeek.Monday;
			case 5:
				// 3～5日
				return dateTime.Day == 6 && dateTime.DayOfWeek >= DayOfWeek.Monday && dateTime.DayOfWeek <= DayOfWeek.Wednesday;
			case 6:
				// 第3月曜日
				return false;
			case 7:
				// 11日
				return dateTime.Day == 12 && dateTime.DayOfWeek == DayOfWeek.Monday;
			case 8:
				// 第3月曜日
				return false;
			case 9:
				// 22～24日
				return dateTime.Day == 25 && dateTime.DayOfWeek >= DayOfWeek.Monday && dateTime.DayOfWeek <= DayOfWeek.Wednesday;
			case 10:
				// 第2月曜日
				return false;
			case 11:
				// 3日, 23日
				return (dateTime.Day == 4 || dateTime.Day == 24) && dateTime.DayOfWeek == DayOfWeek.Monday;
			case 12:
				// 23日
				return dateTime.Day == 24 && dateTime.DayOfWeek == DayOfWeek.Monday;
			}

			return false;
		}
	}
}
