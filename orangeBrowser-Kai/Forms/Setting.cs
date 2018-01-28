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
			this.settings = SettingManager.GetInstance();

			InitializeFields();

			ResetSettingValues();
		}

		private void InitializeFields()
		{
			this.passwordChar = this.textBoxNicoPassword.PasswordChar;
		}

		private void ResetSettingValues()
		{
			this.settings.DiscardChanges();

			ResetGeneralTabValues();
			ResetNicoTabValues();
			ResetWindowTabValues();
		}

		private void ResetGeneralTabValues()
		{
			ResetTextBoxValue(this.textBoxGeneralHomePage);
			ResetTextBoxValue(this.textBoxGeneralSearchPage);
			ResetCheckBoxValue(this.checkBoxGeneralHideHttp);
		}

		private void ResetNicoTabValues()
		{
			ResetTextBoxValue(this.textBoxNicoMail);
			ResetTextBoxValue(this.textBoxNicoPassword);
			ResetCheckBoxValue(this.checkBoxNicoAllowLowMode);
		}

		private void ResetWindowTabValues()
		{
			ResetNumericUpDownValue(this.numericUpDownWindowOpacity);
		}

		private void buttonOkay_Click(object sender, EventArgs e)
		{
			this.settings.Save();

			Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.settings.DiscardChanges();

			Close();
		}

		private void buttonApply_Click(object sender, EventArgs e)
		{
			this.settings.Save();

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
			if (this.textBoxNicoPassword.PasswordChar == this.passwordChar)
			{
				this.textBoxNicoPassword.PasswordChar = '\0';
				this.buttonShowPassword.Text = "Hide";
			}
			else
			{
				this.textBoxNicoPassword.PasswordChar = this.passwordChar;
				this.buttonShowPassword.Text = "Show";
			}
		}

		private void Setting_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (!this.settings.IsValueChanged())
			{
				return;
			}

			DialogResult result = MessageBox.Show("Save changes?", "", MessageBoxButtons.YesNoCancel);

			switch (result)
			{
			case DialogResult.Yes:
				this.settings.Save();
				break;
			case DialogResult.No:
				this.settings.Reset();
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
			this.settings.SetValue(key, value);

			UpdateButtonEnabled();
		}

		private void UpdateButtonEnabled()
		{
			this.buttonApply.Enabled = this.settings.IsValueChanged();
		}
	}
}
