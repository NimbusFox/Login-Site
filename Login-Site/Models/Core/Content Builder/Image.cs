using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox_Uk.Models.Core.Content_Builder {
    public class Image {
        public string Url { get; set; }
        public string AltText { get; set; }
        public string Source { get; set; }

        public Image() { }

        public Image(IPublishedContent page) {
            var height = page.GetPropertyValue("height", 0);
            var width = page.GetPropertyValue("width", 0);

            AltText = page.Name;
            Source = page.GetPropertyValue<string>("source", string.Empty);

            var media = page.GetPropertyValue<dynamic>("image");

            if (media != null) {
                Url = media.Url;

                if (height > 0 || width > 0) {
                    Url += "?mode=max";

                    if (height > 0) {
                        Url += "&height=" + height;
                    }

                    if (width > 0) {
                        Url += "&width=" + width;
                    }
                }
            }
        }
    }
}