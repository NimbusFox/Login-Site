using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.Models.Core.Content_Builder {
    public class Container {
        public string Type { get; set; }
        public IPublishedContent Page { get; set; }

        public Container() { }

        public Container(IPublishedContent page) {
            Type = page.GetPropertyValue<string>("type", "dialog");
            Page = page;
        }
    }
}