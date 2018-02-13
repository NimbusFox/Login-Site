using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NimbusFox.Login_Site.Models.Core.AjaxForms;

namespace NimbusFox.Login_Site.Models {
    public class UserSettings : AjaxForm {
        private Dictionary<string, string> Settings = new Dictionary<string, string>();

        public void AddUpdateSettings<T>(string key, T value) {
            if (!Settings.ContainsKey(key)) {
                Settings.Add(key, "");
            }

            Settings[key] = value.ToString();
        }

        public T GetSetting<T>(string key, T defaultValue) {
            if (Settings.ContainsKey(key)) {
                return (T) Convert.ChangeType(Settings[key], typeof(T));
            }

            return defaultValue;
        }

        public Dictionary<string, string> GetAllSettings() {
            return new Dictionary<string, string>(Settings);
        }

        public UserSettings(UserSettings settings) {
            Settings = settings.Settings;
        }

        public UserSettings() { }

        public UserSettings(Dictionary<string, string> settings) {
            Settings = settings;
        }
    }
}