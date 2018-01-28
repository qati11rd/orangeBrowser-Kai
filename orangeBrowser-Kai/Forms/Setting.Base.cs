using System;
using System.Windows.Forms;

namespace orangeBrowser_Kai.Forms
{
	partial class Setting
	{
		private void TextBox_TextChanged(object textBoxObj, EventArgs e)
		{
			TextBox textBox = (TextBox)textBoxObj;

			UpdateSetting((string)(textBox.Tag), textBox.Text);
		}

		private void CheckBox_CheckedChanged(object checkBoxObj, EventArgs e)
		{
			CheckBox checkBox = (CheckBox)checkBoxObj;

			UpdateSetting((string)(checkBox.Tag), checkBox.Checked);
		}

		private void RadioButton_CheckedChanged(object radioButtonObj, EventArgs e)
		{
			RadioButton radioButton = (RadioButton)radioButtonObj;

			UpdateSetting((string)(radioButton.Tag), radioButton.Checked);
		}

		private void NumericUpDown_ValueChanged(object numericUpDownObj, EventArgs e)
		{
			NumericUpDown numericUpDown = (NumericUpDown)numericUpDownObj;

			UpdateSetting((string)(numericUpDown.Tag), numericUpDown.Value);
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
			return settings.GetValue<T>((string)control.Tag);
		}
	}
}
