using System.Collections.Generic;
using System.Linq;
using NimbusFox.Login_Site.CodeLibraries.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.Models.Core {
    public class Pages {
        public IPublishedContent HomePage { get; }
        public IPublishedContent LoginPage { get; }
        public IPublishedContent LogoutPage { get; }
        public IPublishedContent RegisterPage { get; }
        private readonly List<IPublishedContent> _defaultVal = new List<IPublishedContent>();

        public Pages() {
            var root = GlobalHelper.GetRoot();


            HomePage = root.GetPropertyValue("homePage", _defaultVal).FirstOrDefault();
            LoginPage = root.GetPropertyValue("loginPage", _defaultVal).FirstOrDefault();
            LogoutPage = root.GetPropertyValue("logoutPage", _defaultVal).FirstOrDefault();
            RegisterPage = root.GetPropertyValue("registerPage", _defaultVal).FirstOrDefault();
        }
    }
}