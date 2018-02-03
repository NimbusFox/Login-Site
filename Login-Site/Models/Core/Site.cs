using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Login_Site.Models.Core {
    public class Site : Master {
        public Pages Pages { get; set; }
        public GoogleServices GoogleServices { get; set; }
        public IPublishedContent Menu { get; set; }
        public IPublishedContent Page { get; set; }

        public Site() {
            Pages = new Pages();
        }

        public Site(IPublishedContent page) {
            Pages = new Pages();
            GoogleServices = new GoogleServices(page);
            Menu = page.GetPropertyValue("menu", new List<IPublishedContent>()).FirstOrDefault();
        }
    }
}