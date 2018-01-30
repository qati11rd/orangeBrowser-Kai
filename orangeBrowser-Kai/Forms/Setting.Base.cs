using System;
using System.Windows.Forms;

namespace orangeBrowser_Kai.Forms
{
	partial class Setting
	{
		private void TextBox_TextChanged(object textBoxObj, EventArgs e)
		{
			var textBox = (TextBox)textBoxObj;

			this.UpdateSetting((string)(textBox.Tag), textBox.Text);
		}

		private void CheckBox_CheckedChanged(object checkBoxObj, EventArgs e)
		{
			var checkBox = (CheckBox)checkBoxObj;

			this.UpdateSetting((string)(checkBox.Tag), checkBox.Checked);
		}

		private void RadioButton_CheckedChanged(object radioButtonObj, EventArgs e)
		{
			var radioButton = (RadioButton)radioButtonObj;

			this.UpdateSetting((string)(radioButton.Tag), radioButton.Checked);
		}

		private void NumericUpDown_ValueChanged(object numericUpDownObj, EventArgs e)
		{
			var numericUpDown = (NumericUpDown)numericUpDownObj;

			this.UpdateSetting((string)(numericUpDown.Tag), numericUpDown.Value);
		}

		private void ResetTextBoxValue(TextBox textBox)
		{
			textBox.Text = GetSettingValue<string>(textBox);
		}

		private void ResetCheckBoxValue(CheckBox checkBox)
		{
			checkBox.Checked = GetSettingValue<bool>(checkBox);
		}

		private void ResetCheckBoxCheckState(CheckBox checkBox)
		{
			checkBox.CheckState = GetSettingValue<CheckState>(checkBox);
		}

		private void ResetRadioButtonValue(RadioButton radioButton)
		{
			radioButton.Checked = GetSettingValue<bool>(radioButton);
		}

		private void ResetNumericUpDownValue(NumericUpDown numericUpDown)
		{
			numericUpDown.Value = GetSettingValue<decimal>(numericUpDown);
		}

		private T GetSettingValue<T>(Control control)
		{
			return this.settings.GetValue<T>((string)control.Tag);
		}
	}
}
