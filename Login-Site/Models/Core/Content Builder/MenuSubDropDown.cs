using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Login_Site.Models.Core.ContentBuilder {
    public class MenuSubDropDown {
        public string Text { get; set; }
        public List<IPublishedContent> Children { get; set; }

        public MenuSubDropDown() { }

        public MenuSubDropDown(IPublishedContent page) {
            Text = page.Name;
            Children = page.Children.ToList();
        }
    }
}