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
			this.InitializeComponent();

			this.InitializeSettingValues();
		}

		private void InitializeSettingValues()
		{
			this.settings = SettingManager.GetInstance();

			this.InitializeFields();

			this.ResetSettingValues();
		}

		private void InitializeFields()
		{
			this.passwordChar = this.textBoxNicoPassword.PasswordChar;
		}

		private void ResetSettingValues()
		{
			this.settings.DiscardChanges();

			this.ResetGeneralTabValues();
			this.ResetNicoTabValues();
			this.ResetWindowTabValues();
		}

		private void ResetGeneralTabValues()
		{
			this.ResetTextBoxValue(this.textBoxGeneralHomePage);
			this.ResetTextBoxValue(this.textBoxGeneralSearchPage);
			this.ResetCheckBoxValue(this.checkBoxGeneralHideHttp);
		}

		private void ResetNicoTabValues()
		{
			this.ResetTextBoxValue(this.textBoxNicoMail);
			this.ResetTextBoxValue(this.textBoxNicoPassword);
			this.ResetCheckBoxValue(this.checkBoxNicoAllowLowMode);
		}

		private void ResetWindowTabValues()
		{
			this.ResetNumericUpDownValue(this.numericUpDownWindowOpacity);
		}

		private void buttonOkay_Click(object sender, EventArgs e)
		{
			this.settings.Save();

			this.Close();
		}

		private void buttonCancel_Click(object sender, EventArgs e)
		{
			this.settings.DiscardChanges();

			this.Close();
		}

		private void buttonApply_Click(object sender, EventArgs e)
		{
			this.settings.Save();

			this.UpdateButtonEnabled();
		}

		private void buttonConfirm_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buttonReset_Click(object sender, EventArgs e)
		{
			this.ResetSettingValues();
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

			this.UpdateButtonEnabled();
		}

		private void UpdateButtonEnabled()
		{
			this.buttonApply.Enabled = this.settings.IsValueChanged();
		}
	}
}
