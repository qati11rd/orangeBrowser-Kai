﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

using orangeBrowser_Kai.util;

using SettingForm = orangeBrowser_Kai.Forms.Setting;

namespace orangeBrowser_Kai.Forms
{
	public partial class Main : Form
	{
		const string HTTPS_ALTER_STR = "[#Secured#]";

		readonly Dictionary<string, string> protocolReplaceMap = new Dictionary<string, string>()
		{
			{
				"file://", "[*File*]"
			},
			{
				"sftp://", "[=ScureFTP=]"
			},
			{
				"ftp://", "[-FTP-]"
			},
			{
				"https://", "[#Secured#]"
			},
			{
				"http://", ""
			}
		};

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

			this.HideHttp();
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

		private void textBoxUrlBar_MouseDown(object sender, MouseEventArgs e)
		{
			this.ShowHttp();
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
				this.textBoxUrlBar.DeselectAll();
			}
			catch (UriFormatException)
			{
				if (!usingSearch)
				{
					string searchPage = this.settings.GetValue<string>("General_SearchPage");

					this.GoTo(Formatter.Format.SPrintF(searchPage, url), true);
				}
			}
		}

		private string GetCurrentTransferProtocol()
		{
			string text = this.textBoxUrlBar.Text;

			foreach (var protocol in this.protocolReplaceMap.Keys)
			{
				if (text.StartsWith(protocol))
				{
					return protocol;
				}
			}

			return null;
		}

		private void HideHttp()
		{
			if (this.settings.GetValue<bool>("General_HideHttp"))
			{
				string text = this.textBoxUrlBar.Text;
				string protocol = this.GetCurrentTransferProtocol();

				if (protocol != null)
				{
					string replaceStr = this.protocolReplaceMap[protocol];

					this.textBoxUrlBar.Text = text.Replace(protocol, replaceStr);
				}
			}
		}

		private void ShowHttp()
		{
			if (this.GetCurrentTransferProtocol() != null)
			{
				return;
			}

			if (this.settings.GetValue<bool>("General_HideHttp"))
			{
				string text = this.textBoxUrlBar.Text;

				foreach (var protocolReplacePair in this.protocolReplaceMap)
				{
					if (text.StartsWith(protocolReplacePair.Value))
					{
						this.textBoxUrlBar.Text = text.Replace(protocolReplacePair.Swap(), false);
						break;
					}
				}
			}
		}

		private void UpdateTitle()
		{
			this.Text = this.webBrowser.DocumentTitle + " - " + Process.GetCurrentProcess().ProcessName;
		}
	}
}
