using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.Models.Core {
    public enum EItemVisibility {
        Users,
        NonRegistered,
        All,
        None
    }

    public class ItemVisibility {
        public EItemVisibility Visibility { get; set; }

        protected ItemVisibility() { }

        protected ItemVisibility(IPublishedContent page) {
            var visibility = page.GetPropertyValue<string>("visibility", "").Split(',');

            if (visibility.Any()) {
                if (visibility.Contains("Users") && visibility.Contains("Non-Registered")) {
                    Visibility = EItemVisibility.All;
                } else {
                    if (visibility.Contains("Users")) {
                        Visibility = EItemVisibility.Users;
                    }

                    if (visibility.Contains("Non-Registered")) {
                        Visibility = EItemVisibility.NonRegistered;
                    }
                }
            } else {
                Visibility = EItemVisibility.None;
            }
        }
    }
}