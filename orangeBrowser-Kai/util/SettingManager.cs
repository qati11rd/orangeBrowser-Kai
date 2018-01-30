using System.Collections.Generic;
using System.Configuration;

using orangeBrowser_Kai.Properties;

namespace orangeBrowser_Kai.util
{
	class SettingManager
	{
		private static SettingManager manager;
		private static readonly object _lock = new object();

		private Settings settings;
		private Settings originalSettings;
		private List<string> changedValueList = new List<string>();

		public static SettingManager GetInstance()
		{
			if (manager == null)
			{
				lock (_lock)
				{
					manager = new SettingManager();
				}
			}

			return manager;
		}

		private SettingManager()
		{
			this.settings = new Settings();
			this.settings.Reload();

			this.originalSettings = new Settings();
			this.originalSettings.Reload();
		}

		private void UpdateChangedValueList(string key)
		{
			object changedValue = this.GetValue<object>(key);
			object originalValue = this.GetOriginalValue<object>(key);

			if (changedValue.Equals(originalValue))
			{
				this.RemoveChangedValue(key);
			}
			else
			{
				this.SetChangedValue(key);
			}
		}

		private void SetChangedValue(string key)
		{
			if (!this.changedValueList.Contains(key))
			{
				this.changedValueList.Add(key);
			}
		}

		private void RemoveChangedValue(string key)
		{
			if (this.changedValueList.Contains(key))
			{
				this.changedValueList.Remove(key);
			}
		}

		public void Save()
		{
			this.settings.Save();
			this.originalSettings.Reload();

			this.changedValueList.Clear();
		}

		public void DiscardChanges()
		{
			this.settings.Reload();

			this.settings = new Settings();

			this.changedValueList.Clear();
		}

		public void Reset()
		{
			this.settings.Reset();

			foreach(SettingsProperty key in this.settings.Properties)
			{
				this.UpdateChangedValueList(key.Name);
			}
		}

		public bool IsValueChanged()
		{
			return this.changedValueList.Count != 0;
		}

		public void SetValue<T>(string key, T value)
		{
			this.settings[key] = value;

			this.UpdateChangedValueList(key);
		}

		public T GetValue<T>(string key)
		{
			return (T)this.settings[key];
		}

		private T GetOriginalValue<T>(string key)
		{
			return (T)this.originalSettings[key];
		}
	}
}
