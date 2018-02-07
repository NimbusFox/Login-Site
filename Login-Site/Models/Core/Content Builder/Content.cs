using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NimbusFox.Login_Site.CodeLibraries.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.Models.Core.Content_Builder {
    public class Content {
        private string Text { get; set; }

        public Content(IPublishedContent page) {
            Text = page.GetPropertyValue<string>("editor", "");
        }

        public string GetText() {
            return Text;
        }

        public HtmlString GetHtml() {
            return new HtmlString(Text);
        }

        public void ParseVariables() {
            Text = ContentHelper.ParseText(Text);
        }
    }
}