using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.Models {
    public class PageMaster : Master {
        public bool DisplayEditedTime { get; set; }
        public bool LoginRequired { get; set; }
        public IPublishedContent Page { get; set; }
        public bool DisplayHeader { get; set; }
        public bool DisplayFooter { get; set; }

        public PageMaster() { }

        public PageMaster(IPublishedContent page) {
            DisplayEditedTime = page.GetPropertyValue("displayEditedTime", defaultValue: false);
            LoginRequired = page.GetPropertyValue("loginRequired", defaultValue: false);
            Page = page;
            DisplayHeader = page.GetPropertyValue("displayHeader", defaultValue: true);
            DisplayFooter = page.GetPropertyValue("displayFooter", defaultValue: true);
        }
    }
}