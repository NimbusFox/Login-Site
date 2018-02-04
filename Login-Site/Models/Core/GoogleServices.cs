using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.Models.Core {
    public class GoogleServices {
        public string AnalyticsID { get; set; }
        public string ReCaptchaSiteKey { get; set; }
        public string ReCaptchaPrivateKey { get; set; }
        public string ReCaptchaColor { get; set; }

        public GoogleServices() { }

        public GoogleServices(IPublishedContent page) {
            AnalyticsID = page.GetPropertyValue<string>("analyticsID", "");
            ReCaptchaSiteKey = page.GetPropertyValue<string>("reCaptchaSiteKey", "");
            ReCaptchaPrivateKey = page.GetPropertyValue<string>("reCaptchaPrivateKey", "");
            ReCaptchaColor = page.GetPropertyValue<string>("ReCaptchaColor", "Light");
        }
    }
}