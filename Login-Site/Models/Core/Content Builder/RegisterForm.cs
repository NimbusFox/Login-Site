using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.Models.Core.Content_Builder {
    public class RegisterForm {
        public string RedirectMessage { get; }
        public string From { get; }
        public string Subject { get; }
        public HtmlString Message { get; set; }

        public RegisterForm() { }

        public RegisterForm(IPublishedContent page) {
            RedirectMessage = page.GetPropertyValue<string>("redirectMessage", "");
            From = page.GetPropertyValue<string>("from", "");
            Subject = page.GetPropertyValue<string>("subject", "");
            Message = new HtmlString(page.GetPropertyValue<string>("message", ""));
        }
    }
}