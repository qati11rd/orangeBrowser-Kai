using System;
using System.Diagnostics;
using System.Windows.Forms;
using orangeBrowser_Kai.util;

using SettingForm = orangeBrowser_Kai.Forms.Setting;

namespace orangeBrowser_Kai.Forms
{
	public partial class Main : Form
	{
		const string HTTPS_ALTER_STR = "[#Secured#]";

		SettingManager settings;

		public Main()
		{
			InitializeComponent();

			InitializeSettings();
		}

		private void InitializeSettings()
		{
			settings = SettingManager.GetInstance();

			Opacity = (double)settings.GetValue<decimal>("Window_Opacity");

			GoTo(settings.GetValue<string>("General_HomePage"));
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
			textBoxUrlBar.DeselectAll();

			UpdateTitle();
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

		private void buttonSettings_Click(object sender, EventArgs e)
		{
			SettingForm form = new SettingForm();

			form.ShowDialog(this);
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
				if (!usingSearch)
				{
					GoTo(Formatter.Format.SPrintF(settings.GetValue<string>("General_SearchPage"), url), true);
				}
			}
		}

		private void HideHttp()
		{
			if (settings.GetValue<bool>("General_HideHttp"))
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
			if (settings.GetValue<bool>("General_HideHttp"))
			{
				string text = textBoxUrlBar.Text;

				if (text.StartsWith(HTTPS_ALTER_STR))
				{
					textBoxUrlBar.Text = text.Replace(HTTPS_ALTER_STR, "https://");
				}
				else if (!text.StartsWith("https://"))
				{
					textBoxUrlBar.Text = "http://" + text;
				}
			}
		}

		private void UpdateTitle()
		{
			Text = webBrowser.DocumentTitle + " - " + Process.GetCurrentProcess().ProcessName;
		}
	}
}
