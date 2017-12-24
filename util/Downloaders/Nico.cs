using System;
using System.Collections.Generic;
using System.Windows.Forms;
using orangeBrowser_Kai.Properties;

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

		public NicoDL NicoDL;

		public Nico(DownloadType downloadType, string url, string path) : base(downloadType, url, path)
		{
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
				this.NicoDL.Login(Settings.Default.Nico_Mail, Settings.Default.Nico_Password);
				this.NicoDL.Recode(this.DownloadUrl, Settings.Default.Nico_DefaultPath, Settings.Default.Nico_AllowLowMode);
			}

			return success;
		}

		private void SetDownloaderArgs()
		{
			this.DownloaderArgs = new DownloaderArgs();

			this.DownloaderArgs.Type = this.Type;
			this.DownloaderArgs.Status = this.Status;

			SetDownloadLambda();
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
				ChangeStatus(DownloadStatus.Completed);
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
			var now = DateTime.Now;

			// エコノミー扱いじゃなければ1秒後
			if (!IsEconomyTime(now, Settings.Default.Others_AmbiguousHoliday))
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
