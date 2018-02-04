using Umbraco.Core.Models;
using Umbraco.Web;

namespace Login_Site.Models.Core.Content_Builder {
    public class LoginForm {
        public string RedirectMessage { get; }

        public LoginForm() { }

        public LoginForm(IPublishedContent page) {
            RedirectMessage = page.GetPropertyValue<string>("redirectMessage", "");
        }
    }
}