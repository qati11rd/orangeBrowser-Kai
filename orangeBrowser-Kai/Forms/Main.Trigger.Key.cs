using System;
using System.Windows.Forms;

using orangeBrowser_Kai.util;

namespace orangeBrowser_Kai.Forms
{
	partial class Main
	{
		private bool key_isTriggered;

		void KeyTrigger_Main(PreviewKeyDownEventArgs e)
		{
			this.key_isTriggered = false;

			this.KeyTrigger_Main(e.KeyData);

			e.IsInputKey = this.key_isTriggered;
		}

		void KeyTrigger_Main(Keys keys)
		{
			this.KeyTrigger_Window(keys);
			this.KeyTrigger_UrlBar(keys);
			this.KeyTrigger_Browser(keys);
			this.KeyTrigger_Alert(keys);
			this.KeyTrigger_Nico(keys);
		}

		void KeyTrigger_Window(Keys keys)
		{
			var prefix = SettingManager.PrefixKey + "Window_";

			if (this.KeyTrigger_IsTriggered(keys, prefix + "Close"))
			{
				this.Close();
			}

			this.KeyTrigger_WindowOpen(keys);
		}

		void KeyTrigger_WindowOpen(Keys keys)
		{
			var prefix = SettingManager.PrefixKey + "Window_Open_";

			if (this.KeyTrigger_IsTriggered(keys, prefix + "Settings"))
			{
				this.buttonSettings.PerformClick();
			}
		}

		void KeyTrigger_UrlBar(Keys keys)
		{
			var prefix = SettingManager.PrefixKey + "UrlBar_";

			if (this.KeyTrigger_IsTriggered(keys, prefix + "SelectAll"))
			{
				this.textBoxUrlBar.Focus();
				this.textBoxUrlBar.SelectAll();
			}

			if (this.KeyTrigger_IsTriggered(keys, prefix + "Paste"))
			{
				if (Clipboard.ContainsText())
				{
					this.textBoxUrlBar.Text = Clipboard.GetText();
				}

				this.textBoxUrlBar.Focus();
				this.textBoxUrlBar.SelectAll();
			}
		}

		void KeyTrigger_Browser(Keys keys)
		{
			var prefix = SettingManager.PrefixKey + "Browser_";

			if (this.KeyTrigger_IsTriggered(keys, prefix + "Reload"))
			{
				this.GoTo(this.webBrowser.Url.AbsoluteUri);
			}

			if (this.KeyTrigger_IsTriggered(keys, prefix + "Home"))
			{
				this.GoTo(this.settings.GetValue<string>(SettingManager.Prefix + "Browser_HomePage"));
			}
		}

		void KeyTrigger_Alert(Keys keys)
		{
			var prefix = SettingManager.PrefixKey + "Alert_";

			if (this.KeyTrigger_IsTriggered(keys, prefix + "Time"))
			{
				MessageBox.Show(DateTime.Now.ToString(), "現在時刻");
			}
		}

		void KeyTrigger_Nico(Keys keys)
		{
			var prefix = SettingManager.PrefixKey + "Nico_";

			if (this.KeyTrigger_IsTriggered(keys, prefix + "Download"))
			{
				// TODO
			}

			if (this.KeyTrigger_IsTriggered(keys, prefix + "Reserve"))
			{
				// TODO
			}
		}

		bool KeyTrigger_IsTriggered(Keys keys, string key)
		{
			if (this.key_isTriggered)
			{
				return false;
			}

			this.key_isTriggered = keys == this.settings.GetValue<Keys>(key);

			return this.key_isTriggered;
		}
	}
}
