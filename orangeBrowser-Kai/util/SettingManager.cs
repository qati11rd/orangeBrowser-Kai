using System;
using System.Collections.Generic;
using System.Configuration;

using orangeBrowser_Kai.settings;

namespace orangeBrowser_Kai.util
{
	class SettingManager
	{
		private static SettingManager manager;
		private static readonly object _lock = new object();

		public static readonly string Prefix = "Settings_";
		public static readonly string PrefixKey = "Key_";

		private List<string> prefixList;

		Dictionary<string, ApplicationSettingsBase> settingsMap;
		Dictionary<string, ApplicationSettingsBase> originalSettingsMap;

		private List<string> changedValueList;

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
			this.Initialize();
		}

		private void Initialize()
		{
			this.prefixList = new List<string>();
			this.settingsMap = new Dictionary<string, ApplicationSettingsBase>();
			this.originalSettingsMap = new Dictionary<string, ApplicationSettingsBase>();

			this.AddSettingMap<Settings>(Prefix);
			this.AddSettingMap<ShortCutKey>(PrefixKey);

			this.changedValueList = new List<string>();
		}

		private void AddSettingMap<T>(string prefix) where T : ApplicationSettingsBase
		{
			this.prefixList.Add(prefix);

			var settings = Activator.CreateInstance<T>();
			settings.Reload();
			this.settingsMap.Add(prefix, settings);

			var originalSettings = Activator.CreateInstance<T>();
			originalSettings.Reload();
			this.originalSettingsMap.Add(prefix, originalSettings);
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
			foreach(var settings in this.settingsMap.Values)
			{
				settings.Save();
			}

			foreach(var originalSettings in this.originalSettingsMap.Values)
			{
				originalSettings.Reload();
			}

			this.changedValueList.Clear();
		}

		public void DiscardChanges()
		{
			foreach(var settings in this.settingsMap.Values)
			{
				settings.Reload();
			}

			Initialize();
		}

		public void Reset()
		{
			foreach(var settings in this.settingsMap.Values)
			{
				settings.Reset();

				foreach(SettingsProperty key in settings.Properties)
				{
					this.UpdateChangedValueList(key.Name);
				}
			}
		}

		public bool IsValueChanged()
		{
			return this.changedValueList.Count != 0;
		}

		private string GetPrefix(string key)
		{
			foreach(var prefix in this.prefixList)
			{
				if (key.StartsWith(prefix))
				{
					return prefix;
				}
			}

			return null;
		}

		public void SetValue<T>(string key, T value)
		{
			var prefix = this.GetPrefix(key);

			var settingKey = key.Remove(0, prefix.Length);

			this.settingsMap[prefix][settingKey] = value;

			this.UpdateChangedValueList(key);
		}

		public T GetValue<T>(string key)
		{
			var prefix = this.GetPrefix(key);

			var settingKey = key.Remove(0, prefix.Length);

			return (T)this.settingsMap[prefix][settingKey];
		}

		private T GetOriginalValue<T>(string key)
		{
			var prefix = this.GetPrefix(key);

			var settingKey = key.Remove(0, prefix.Length);

			return (T)this.originalSettingsMap[prefix][settingKey];
		}
	}
}
