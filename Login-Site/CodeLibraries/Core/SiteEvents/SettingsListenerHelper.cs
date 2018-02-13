using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NimbusFox.Login_Site.CodeLibraries.SiteEvents;
using NimbusFox.Login_Site.Models;

namespace NimbusFox.Login_Site.CodeLibraries.Core.SiteEvents {
    public static class SettingsListenerHelper {
        internal static void Init() {
            SettingsListenerEvents.AddEvent(SettingsCheck);
        }

        private static UserSettings SettingsCheck(UserSettings settings) {
            return settings;
        }
    }
}