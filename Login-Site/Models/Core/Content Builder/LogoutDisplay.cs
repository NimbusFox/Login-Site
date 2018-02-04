using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.Models.Core.Content_Builder {
    public class LogoutDisplay {
        public string RedirectMessage { get; }

        public LogoutDisplay() { }

        public LogoutDisplay(IPublishedContent page) {
            RedirectMessage = page.GetPropertyValue<string>("redirectMessage", "");
        }
    }
}