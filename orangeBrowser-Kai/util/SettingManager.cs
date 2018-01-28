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
			settings = new Settings();
			settings.Reload();

			originalSettings = new Settings();
			originalSettings.Reload();
		}

		private void UpdateChangedValueList(string key)
		{
			object changedValue = GetValue<object>(key);
			object originalValue = GetOriginalValue<object>(key);

			if (changedValue.Equals(originalValue))
			{
				RemoveChangedValue(key);
			}
			else
			{
				SetChangedValue(key);
			}
		}

		private void SetChangedValue(string key)
		{
			if (!changedValueList.Contains(key))
			{
				changedValueList.Add(key);
			}
		}

		private void RemoveChangedValue(string key)
		{
			if (changedValueList.Contains(key))
			{
				changedValueList.Remove(key);
			}
		}

		public void Save()
		{
			settings.Save();
			originalSettings.Reload();

			changedValueList.Clear();
		}

		public void DiscardChanges()
		{
			settings.Reload();

			settings = new Settings();

			changedValueList.Clear();
		}

		public void Reset()
		{
			settings.Reset();

			foreach(SettingsProperty key in settings.Properties)
			{
				UpdateChangedValueList(key.Name);
			}
		}

		public bool IsValueChanged()
		{
			return changedValueList.Count != 0;
		}

		public void SetValue<T>(string key, T value)
		{
			settings[key] = value;

			UpdateChangedValueList(key);
		}

		public T GetValue<T>(string key)
		{
			return (T)settings[key];
		}

		private T GetOriginalValue<T>(string key)
		{
			return (T)originalSettings[key];
		}
	}
}
