﻿using System;
using System.Windows.Forms;
using orangeBrowser_Kai.Properties;

namespace orangeBrowser_Kai
{
	public partial class Main : Form
	{
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

		private void textBoxUrlBar_TextChanged(object sender, EventArgs e)
		{
			string text = textBoxUrlBar.Text;

			if (text.Contains("\r") || text.Contains("\n"))
			{
				GoTo(text.Replace("\r", "").Replace("\n", ""));
			}
		}

		private void GoTo(string url, bool usingSearch = false)
		{
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
	}
}
