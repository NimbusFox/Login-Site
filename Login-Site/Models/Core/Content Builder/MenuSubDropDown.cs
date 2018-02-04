using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;

namespace NimbusFox.Login_Site.Models.Core.Content_Builder {
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