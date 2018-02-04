using Umbraco.Core.Models;
using Umbraco.Web;

namespace Login_Site.Models.Core {
    public class PageMaster : Master {
        public bool DisplayEditedTime { get; set; }
        public bool LoginRequired { get; set; }
        public IPublishedContent Page { get; set; }

        public PageMaster() { }

        public PageMaster(IPublishedContent page) {
            DisplayEditedTime = page.GetPropertyValue("displayEditedTime", defaultValue: false);
            LoginRequired = page.GetPropertyValue("loginRequired", defaultValue: false);
            Page = page;
        }
    }
}