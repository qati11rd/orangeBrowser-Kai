using System;
using System.Windows.Forms;
using orangeBrowser_Kai.Properties;
using orangeBrowser_Kai.util;

namespace orangeBrowser_Kai
{
	public partial class Main : Form
	{
		const string HTTPS_ALTER_STR = "[#Secured#]";

		public Main()
		{
			InitializeComponent();

			InitializeSettings();
		}

		private void InitializeSettings()
		{
			Opacity = Settings.Default.Window_Opacity;

			GoTo(Settings.Default.General_HomePage);
		}

		private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			textBoxUrlBar.Text = e.Url.AbsoluteUri;
		}

		private void textBoxUrlBar_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r' || e.KeyChar == '\n')
			{
				GoTo(textBoxUrlBar.Text);
			}
		}

		private void textBoxUrlBar_TextChanged(object sender, EventArgs e)
		{
			textBoxUrlBar.Text = textBoxUrlBar.Text.RemoveControls();
		}

		private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			HideHttp();
		}

		private void textBoxUrlBar_Enter(object sender, EventArgs e)
		{
			ShowHttp();
		}

		private void textBoxUrlBar_Leave(object sender, EventArgs e)
		{
			HideHttp();
		}

		private void buttonGo_Click(object sender, EventArgs e)
		{
			GoTo(textBoxUrlBar.Text);
		}

		private void GoTo(string url, bool usingSearch = false)
		{
			url = url.RemoveControls();

			try
			{
				webBrowser.Url = new Uri(url);

				textBoxUrlBar.Text = url;
			}
			catch (Exception)
			{
				if (!usingSearch) {
					GoTo(Formatter.Format.SPrintF(Settings.Default.General_SearchPage, url), true);
				}
			}
		}

		private void HideHttp()
		{
			if (Settings.Default.General_HideHttp)
			{
				string text = textBoxUrlBar.Text;

				if (text.StartsWith("https://"))
				{
					textBoxUrlBar.Text = text.Replace("https://", HTTPS_ALTER_STR);
				}
				else
				{
					textBoxUrlBar.Text = text.Replace("http://", "");
				}
			}
		}

		private void ShowHttp()
		{
			if (Settings.Default.General_HideHttp)
			{
				string text = textBoxUrlBar.Text;

				if (text.StartsWith(HTTPS_ALTER_STR))
				{
					textBoxUrlBar.Text = text.Replace(HTTPS_ALTER_STR, "https://");
				}
				else
				{
					textBoxUrlBar.Text = "http://" + text;
				}
			}
		}
	}
}
