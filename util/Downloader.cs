using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace orangeBrowser_Kai.util
{
	public enum DownloadType
	{
		None,
		Nico,
	}

	public enum DownloadStatus
	{
		Wait,
		Downloading,
		Reserved,
		Stopped,
		Completed,
		Error,
		Other,
	}

	public class DownloaderArgs : EventArgs
	{
		public DownloadType Type;
		public DownloadStatus Status;

		public string Url;
		public string SavePath;

		public long DownloadedSize;
		public long VideoSize;
		public string Title;

		public DownloaderArgs()
		{
		}
	}

	class Downloader
	{
		static List<DownloadStatus> AvailableStatusList = new List<DownloadStatus>();

		public DownloadType Type { get; private set; }
		public DownloadStatus Status { get; private set; }

		public string DownloadUrl { get; private set; }
		public string SavePath { get; private set; }
		public Timer Timer { get; protected set; }

		public DownloaderArgs DownloaderArgs;

		public event EventHandler<DownloaderArgs> DownloadStatusChanged;

		public Downloader(DownloadType downloadType, string url, string savePath)
		{
			this.Type = downloadType;
			this.Status = DownloadStatus.Wait;
			this.DownloadUrl = url;
			this.SavePath = savePath;
		}

		public bool Start()
		{
			if (this.Status == DownloadStatus.Wait)
			{
				return StartBase();
			}
			else
			{
				return false;
			}
		}

		protected virtual bool StartBase()
		{
			SetDownloaderArgs();

			return ChangeStatus(DownloadStatus.Downloading);
		}

		private void SetDownloaderArgs()
		{
			this.DownloaderArgs = new DownloaderArgs();

			this.DownloaderArgs.Type = this.Type;
			this.DownloaderArgs.Status = this.Status;

			SetDownloadLambda();
		}

		protected virtual void SetDownloadLambda()
		{
		}

		public virtual bool Reserve()
		{
			bool success = ChangeStatus(DownloadStatus.Reserved);

			if (success)
			{
				Timer timer = GetTimer();

				// TODO: 予約する
				this.Timer.Tick += (sender, args) =>
				{
					Start();
				};
			}

			return success;
		}

		protected virtual Timer GetTimer()
		{
			throw new NotImplementedException();
		}

		public virtual bool Stop()
		{
			return ChangeStatus(DownloadStatus.Stopped);
		}

		public bool Resume()
		{
			return Start();
		}

		protected bool ChangeStatus(DownloadStatus status)
		{
			bool canChange = CanChangeStatus(status);

			if (canChange)
			{
				this.Status = status;

				if (this.DownloadStatusChanged != null)
				{
					DownloadStatusChanged(this, this.DownloaderArgs);
				}
			}

			return canChange;
		}

		private bool CanChangeStatus(DownloadStatus status)
		{
			if (this.Status == status)
			{
				return false;
			}

			return AvailableStatusList.Contains(status);
		}
	}
}
