using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NimbusFox.Login_Site.Models;

namespace NimbusFox.Login_Site.CodeLibraries.SiteEvents {
    public class SettingsListenerEvents {
        private static List<Func<UserSettings, UserSettings>> _Events = new List<Func<UserSettings, UserSettings>>();

        public static void RunEvents(UserSettings settings) {
            foreach (var runEvent in _Events) {
                runEvent(settings);
            }
        }

        public static void AddEvent(Func<UserSettings, UserSettings> registeringEvent) {
            if (!_Events.Contains(registeringEvent)) {
                _Events.Add(registeringEvent);
            }
        }
    }
}