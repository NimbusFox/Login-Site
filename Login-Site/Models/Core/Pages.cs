using System.Collections.Generic;
using System.Linq;
using Login_Site.CodeLibraries.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Login_Site.Models.Core {
    public class Pages {
        public IPublishedContent HomePage { get; }
        public IPublishedContent LoginPage { get; }
        public IPublishedContent LogoutPage { get; }
        public IPublishedContent RegisterPage { get; }
        public IPublishedContent UserPage { get; }

        public Pages() {
            var root = GlobalHelper.GetRoot();

            var defaultVal = new List<IPublishedContent>();

            HomePage = root.GetPropertyValue("homePage", defaultVal).FirstOrDefault();
            LoginPage = root.GetPropertyValue("loginPage", defaultVal).FirstOrDefault();
            LogoutPage = root.GetPropertyValue("logoutPage", defaultVal).FirstOrDefault();
            RegisterPage = root.GetPropertyValue("registerPage", defaultVal).FirstOrDefault();
            UserPage = root.GetPropertyValue("userPage", defaultVal).FirstOrDefault();
        }
    }
}