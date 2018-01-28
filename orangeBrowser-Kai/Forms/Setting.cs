using System;
using System.Windows.Forms;
using orangeBrowser_Kai.util;

namespace orangeBrowser_Kai.Forms
{
	public partial class Setting : Form
	{
		private SettingManager settings;

		private char passwordChar;

		public Setting()
		{
			InitializeComponent();

			InitializeSettingValues();
		}

		private void InitializeSettingValues()
		{
			settings = SettingManager.GetInstance();

			InitializeFields();

			ResetSettingValues();
		}

		private void InitializeFields()
		{
			passwordChar = textBoxNicoPassword.PasswordChar;
		}

		private void ResetSettingValues()
		{
			settings.DiscardChanges();

			ResetGeneralTabValues();
			ResetNicoTabValues();
			ResetWindowTabValues();
		}

		private void ResetGeneralTabValues()
		{
			ResetTextBoxValue(textBoxGeneralHomePage);
			ResetTextBoxValue(textBoxGeneralSearchPage);
			ResetCheckBoxValue(checkBoxGeneralHideHttp);
		}

		private void ResetNicoTabValues()
		{
			ResetTextBoxValue(textBoxNicoMail);
			ResetTextBoxValue(textBoxNicoPassword);
			ResetCheckBoxValue(checkBoxNicoAllowLowMode);
		}

		private void ResetWindowTabValues()
		{
			ResetNumericUpDownValue(numericUpDownWindowOpacity);
		}

		private void buttonOkay_Click(object sender, EventArgs e)
		{
			settings.Save();

			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			settings.DiscardChanges();

			Close();
		}

		private void buttonApply_Click(object sender, EventArgs e)
		{
			settings.Save();

			UpdateButtonEnabled();
		}

		private void buttonConfirm_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void buttonReset_Click(object sender, EventArgs e)
		{
			ResetSettingValues();
		}

		private void buttonShowPassword_Click(object sender, EventArgs e)
		{
			if (textBoxNicoPassword.PasswordChar == passwordChar)
			{
				textBoxNicoPassword.PasswordChar = '\0';
				buttonShowPassword.Text = "Hide";
			}
			else
			{
				textBoxNicoPassword.PasswordChar = passwordChar;
				buttonShowPassword.Text = "Show";
			}
		}

		private void Setting_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!settings.IsValueChanged())
			{
				return;
			}

			DialogResult result = MessageBox.Show("Save changes?", "", MessageBoxButtons.YesNoCancel);

			switch (result)
			{
			case DialogResult.Yes:
				settings.Save();
				break;
			case DialogResult.No:
				settings.Reset();
				break;
			case DialogResult.Cancel:
				e.Cancel = true;
				break;
			default:
				throw new InvalidOperationException();
			}
		}

		private void UpdateSetting(string key, object value)
		{
			settings.SetValue(key, value);

			UpdateButtonEnabled();
		}

		private void UpdateButtonEnabled()
		{
			buttonApply.Enabled = settings.IsValueChanged();
		}
	}
}
