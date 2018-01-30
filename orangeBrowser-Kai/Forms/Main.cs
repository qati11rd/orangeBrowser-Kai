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
			this.InitializeComponent();

			this.InitializeSettings();
		}

		private void InitializeSettings()
		{
			this.settings = SettingManager.GetInstance();

			this.Opacity = (double)this.settings.GetValue<decimal>("Window_Opacity") / 100;

			this.GoTo(this.settings.GetValue<string>("General_HomePage"));
		}

		private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
		{
			this.textBoxUrlBar.Text = e.Url.AbsoluteUri;
		}

		private void textBoxUrlBar_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.KeyChar == '\r' || e.KeyChar == '\n')
			{
				this.GoTo(this.textBoxUrlBar.Text);
			}
		}

		private void textBoxUrlBar_TextChanged(object sender, EventArgs e)
		{
			this.textBoxUrlBar.Text = this.textBoxUrlBar.Text.RemoveControls();
		}

		private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
		{
			this.textBoxUrlBar.DeselectAll();

			this.UpdateTitle();
		}

		private void textBoxUrlBar_Enter(object sender, EventArgs e)
		{
			this.ShowHttp();
		}

		private void textBoxUrlBar_Leave(object sender, EventArgs e)
		{
			this.HideHttp();
		}

		private void buttonGo_Click(object sender, EventArgs e)
		{
			this.GoTo(this.textBoxUrlBar.Text);
		}

		private void buttonSettings_Click(object sender, EventArgs e)
		{
			var form = new SettingForm();

			form.ShowDialog(this);
		}

		private void GoTo(string url, bool usingSearch = false)
		{
			url = url.RemoveControls();

			try
			{
				this.webBrowser.Url = new Uri(url);

				this.textBoxUrlBar.Text = url;
			}
			catch (Exception)
			{
				if (!usingSearch)
				{
					this.GoTo(Formatter.Format.SPrintF(this.settings.GetValue<string>("General_SearchPage"), url), true);
				}
			}
		}

		private void HideHttp()
		{
			if (this.settings.GetValue<bool>("General_HideHttp"))
			{
				string text = this.textBoxUrlBar.Text;

				if (text.StartsWith("https://"))
				{
					this.textBoxUrlBar.Text = text.Replace("https://", HTTPS_ALTER_STR);
				}
				else
				{
					this.textBoxUrlBar.Text = text.Replace("http://", "");
				}
			}
		}

		private void ShowHttp()
		{
			if (this.settings.GetValue<bool>("General_HideHttp"))
			{
				string text = this.textBoxUrlBar.Text;

				if (text.StartsWith(HTTPS_ALTER_STR))
				{
					this.textBoxUrlBar.Text = text.Replace(HTTPS_ALTER_STR, "https://");
				}
				else if (!text.StartsWith("https://"))
				{
					this.textBoxUrlBar.Text = "http://" + text;
				}
			}
		}

		private void UpdateTitle()
		{
			this.Text = this.webBrowser.DocumentTitle + " - " + Process.GetCurrentProcess().ProcessName;
		}
	}
}
