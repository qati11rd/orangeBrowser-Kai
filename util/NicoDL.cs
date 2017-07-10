using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Security;
using System.Runtime.InteropServices;
using System.Xml;

// 元ソース uri: http://d.hatena.ne.jp/fezg00/20111115/1321348924

namespace orangeBrowser_Kai.util
{
	enum Mode
	{
		None,
		High,
		Low,
	}

	class ProgressionArgs : EventArgs
	{
		public long DownloadedSize;
		public long VideoSize;
		public string Title;

		public Mode Mode;

		public ProgressionArgs()
		{
		}
	}

	class NicoDL
	{
		private static readonly Encoding _niconicoEncode = Encoding.UTF8;
		private readonly CookieContainer _cookie = new CookieContainer();

		public event EventHandler<ProgressionArgs> Progression;
		public event EventHandler<ProgressionArgs> Completed;

		public NicoDL()
		{
		}

		string SecureStringToString(SecureString secureString)
		{
			var pointer = IntPtr.Zero;

			try
			{
				var buffer = new char[secureString.Length];

				pointer = Marshal.SecureStringToCoTaskMemUnicode(secureString);
				Marshal.Copy(pointer, buffer, 0, buffer.Length);

				return new string(buffer);
			}
			finally
			{
				if (pointer != IntPtr.Zero)
				{
					Marshal.ZeroFreeCoTaskMemUnicode(pointer);
				}
			}
		}

		public void Login(string mail, SecureString password)
		{
			var req = (HttpWebRequest)WebRequest.Create("https://secure.nicovideo.jp/secure/login?site=niconico");
			req.ContentType = "application/x-www-form-urlencoded";
			req.Method = "POST";
			req.CookieContainer = _cookie;

			var buff = _niconicoEncode.GetBytes(string.Format("mail={0}&password={1}", mail, SecureStringToString(password)));
			req.ContentLength = buff.Length;

			using (var stream = req.GetRequestStream())
			{
				stream.Write(buff, 0, buff.Length);
			}

			req.GetResponse().Close();

			if (_cookie.Count == 0)
			{
				throw new Exception("ログインエラー");
			}
		}

		public bool Recode(string url, string path)
		{
			return Recode(url, path, false);
		}

		public bool Recode(string url, string path, bool allowedLowMode)
		{
			var thumbInfo = GetThumbInfo(url);
			var videoInfo = GetFlv(url);
			var progression = new ProgressionArgs()
			{
				Title = thumbInfo["title"]
			};
			progression.Mode = GetMode(videoInfo["url"]);

			if (!videoInfo.ContainsKey("url") || (progression.Mode == Mode.Low && !allowedLowMode))
			{
				return false;
			}

			RequestPage(url);

			var req = (HttpWebRequest)WebRequest.Create(videoInfo["url"]);
			req.CookieContainer = _cookie;

			FillVideoSize(progression, thumbInfo);

			using (var stream = req.GetResponse().GetResponseStream())
			{
				var fileName = thumbInfo["title"];
				Array.ForEach(Path.GetInvalidFileNameChars(), c => fileName = fileName.Replace(c.ToString(), ""));
				Path.GetInvalidFileNameChars().ForEach(c => fileName = fileName.Replace(c.ToString(), ""));

				var filePath = Path.Combine(path, fileName);

				Save(stream, filePath, progression);
			}

			return true;
		}

		private static void FillVideoSize(ProgressionArgs progression, Dictionary<string, string> thumbInfo)
		{
			var size = thumbInfo["size_high"];

			if (progression.Mode == Mode.Low)
			{
				size = thumbInfo["size_low"];
			}

			progression.VideoSize = long.Parse(size);
		}

		void RequestPage(string url)
		{
			var req = (HttpWebRequest)WebRequest.Create(url);
			req.CookieContainer = _cookie;
			req.GetResponse().Close();

			return;
		}

		private static Mode GetMode(string videoUrl)
		{
			return videoUrl.ToLower().EndsWith("low") ? Mode.Low : Mode.High;
		}

		private void Save(Stream stream, string filePath, ProgressionArgs videoInfo)
		{
			long buffSize = Math.Min(videoInfo.VideoSize, 1024 * 1024);

			byte[] buff = new byte[buffSize];
			var readSize = stream.Read(buff, 0, 3);

			if (buff[0] == 'F' && buff[1] == 'L' && buff[2] == 'V')
			{
				filePath += ".flv";
			}
			else
			{
				filePath += ".mp4";
			}

			var tempFilePath = Path.GetTempFileName();
			long totalReadSize = readSize;

			using (var outStream = File.OpenWrite(tempFilePath))
			{
				outStream.Write(buff, 0, 3);

				while (readSize != 0)
				{
					readSize = stream.Read(buff, 0, buff.Length);
					outStream.Write(buff, 0, readSize);

					totalReadSize += readSize;
					videoInfo.DownloadedSize = totalReadSize;

					OnProgression(videoInfo);
				}
			}

			if (File.Exists(filePath))
			{
				File.Delete(filePath);
			}

			File.Move(tempFilePath, filePath);
		}

		private Dictionary<string, string> GetThumbInfo(string url)
		{
			var number = url.Split('/').GetLastContents().Split('?')[0];
			var req = (HttpWebRequest)WebRequest.Create("http://ext.nicovideo.jp/api/getthumbinfo/" + number);
			req.CookieContainer = _cookie;
			var resText = req.GetResponse().ReadToEnd(_niconicoEncode);

			var webData = new Dictionary<string, string>();
			var xml = new XmlDocument();
			xml.LoadXml(resText);

			webData.Add("title", xml.GetElementsByTagName("title")[0].InnerText);
			webData.Add("size_high", xml.GetElementsByTagName("size_high")[0].InnerText);
			webData.Add("size_low", xml.GetElementsByTagName("size_low")[0].InnerText);

			return webData;
		}

		private Dictionary<string, string> GetFlv(string url)
		{
			var number = url.Split('/').GetLastContents().Split('?')[0];
			var req = (HttpWebRequest)WebRequest.Create("http://flapi.nicovideo.jp/api/getflv/" + number);
			req.CookieContainer = _cookie;
			var resText = req.GetResponse().ReadToEnd(_niconicoEncode);

			return ConvertDic(resText);
		}

		static Dictionary<string, string> ConvertDic(string source)
		{
			var webData = new Dictionary<string, string>();

			foreach (var item in source.Split('&'))
			{
				var values = item.Split('=');
				webData.Add(values[0], Uri.UnescapeDataString(values[1]));
			}

			return webData;
		}

		protected void OnProgression(ProgressionArgs progressionArgs)
		{
			if (Progression != null)
			{
				Progression(this, progressionArgs);
			}
		}

		protected void OnCompleted(ProgressionArgs progressionArgs)
		{
			if (Completed != null)
			{
				Completed(this, progressionArgs);
			}
		}
	}

	static class Extentions
	{
		static public T GetLastContents<T>(this T[] array)
		{
			return array[array.Length - 1];
		}

		static public void ForEach<T>(this T[] array, Action<T> action)
		{
			Array.ForEach(array, action);
		}

		static public string ReadToEnd(this WebResponse response, Encoding encoding)
		{
			using (var reader = new StreamReader(response.GetResponseStream(), encoding))
			{
				return reader.ReadToEnd();
			}
		}

		static public string ReadToEnd(this WebResponse response)
		{
			using (var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
