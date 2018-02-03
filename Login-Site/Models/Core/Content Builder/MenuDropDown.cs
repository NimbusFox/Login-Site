using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Login_Site.Models.Core.ContentBuilder {
    public class MenuDropDown {
        public string Text { get; set; }
        public List<IPublishedContent> Children { get; set; }

        public MenuDropDown() { }

        public MenuDropDown(IPublishedContent page) {
            Text = page.Name;
            Children = page.Children.ToList();
        }
    }
}