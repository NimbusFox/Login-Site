using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.Models.Core.Content_Builder {
    public class RedirectCounter {
        public IPublishedContent Page { get; }
        public int Seconds { get; set; }

        public RedirectCounter(IPublishedContent page) {
            Page = page.GetPropertyValue("page", new List<IPublishedContent>())
                .FirstOrDefault();

            Seconds = page.GetPropertyValue("seconds", 3);

            if (Seconds > 5) {
                Seconds = 5;
            }

            if (Seconds < 1) {
                Seconds = 1;
            }
        }
    }
}