using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace orangeBrowser_Kai.util.Downloaders
{
	class Nico : Downloader
	{
		static List<DownloadStatus> AvailableStatusList = new List<DownloadStatus>()
		{
			DownloadStatus.Downloading,
			DownloadStatus.Reserved,
			DownloadStatus.Stopped,
			DownloadStatus.Completed,
			DownloadStatus.Error,
			DownloadStatus.Other,
		};

		private SettingManager settings;

		public NicoDL NicoDL;

		public Nico(DownloadType downloadType, string url, string path) : base(downloadType, url, path)
		{
			this.settings = SettingManager.GetInstance();

			this.NicoDL = new NicoDL();

			this.NicoDL.StreamWrote += (sender, args) =>
			{
				if (this.Status == DownloadStatus.Stopped)
				{
					args.FileStream.Close();
				}
			};
		}

		protected override bool StartBase()
		{
			bool success = base.StartBase();

			if (success)
			{
				string mail = this.settings.GetValue<string>("Nico_Mail");
				string password = this.settings.GetValue<string>("Nico_Password");
				string path = this.settings.GetValue<string>("Nico_DefaultPath");
				bool isAllowLowMode = this.settings.GetValue<bool>("Nico_AllowLowMode");

				this.NicoDL.Login(mail, password);
				this.NicoDL.Recode(this.DownloadUrl, path, isAllowLowMode);
			}

			return success;
		}

		private void SetDownloaderArgs()
		{
			this.DownloaderArgs = new DownloaderArgs
			{
				Type = this.Type,
				Status = this.Status
			};

			this.SetDownloadLambda();
		}

		protected override void SetDownloadLambda()
		{
			this.NicoDL.Progression += (sender, args) =>
			{
				this.DownloaderArgs.Title = args.Title;
				this.DownloaderArgs.VideoSize = args.VideoSize;
				this.DownloaderArgs.DownloadedSize = args.DownloadedSize;
			};

			this.NicoDL.Completed += (sender, args) =>
			{
				this.ChangeStatus(DownloadStatus.Completed);
			};
		}

		protected override Timer GetTimer()
		{
			if (this.Timer == null)
			{
				this.Timer = new Timer();
			}

			this.Timer.Interval = GetTimerInterval();

			return this.Timer;
		}

		private int GetTimerInterval()
		{
			DateTime now = DateTime.Now;
			bool isAmbiguousHoliday = this.settings.GetValue<bool>("Others_AmbiguousHoliday");

			// エコノミー扱いじゃなければ1秒後
			if (!IsEconomyTime(now, isAmbiguousHoliday))
			{
				return 1;
			}

			return (int)now.AddHours(2).AddMinutes(1).Subtract(now).TotalSeconds;
		}

		public static bool IsEconomyTime(DateTime now, bool useAmbiguous)
		{
			if (IsEconomyDay(now, useAmbiguous))
			{
				return now.Hour < 2 || now.Hour >= 12;
			}
			else
			{
				return now.Hour < 2 || now.Hour >= 18;
			}
		}

		private static bool IsEconomyDay(DateTime now, bool useAmbiguous)
		{
			switch (now.DayOfWeek)
			{
			case DayOfWeek.Saturday:
			case DayOfWeek.Sunday:
				return true;
			}

			switch (now.Month)
			{
			case 7:
				return now.Day > 15;
			case 8:
				return true;
			case 12:
				return now.Day >= 30;
			case 1:
				return now.Day <= 3;
			}

			return now.IsPublicHoliday(useAmbiguous);
		}
	}
}
