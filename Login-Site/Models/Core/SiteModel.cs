using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.Models.Core {
    public class SiteModel : Master {
        public Pages Pages { get; set; }
        public GoogleServices GoogleServices { get; set; }
        public IPublishedContent Menu { get; set; }
        public IPublishedContent Page { get; set; }

        public SiteModel() {
            Pages = new Pages();
        }

        public SiteModel(IPublishedContent page) {
            Pages = new Pages();
            GoogleServices = new GoogleServices(page);
            Menu = page.GetPropertyValue("menu", new List<IPublishedContent>()).FirstOrDefault();
            Page = page;
        }
    }
}