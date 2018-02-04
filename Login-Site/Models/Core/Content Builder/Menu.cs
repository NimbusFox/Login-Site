using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Login_Site.Models.Core.Content_Builder {
    public class Menu {
        public string Title { get; set; }
        public bool FullWidth { get; set; }
        public List<IPublishedContent> Children { get; set; }

        public Menu() { }

        public Menu(IPublishedContent page) {
            Title = page.GetPropertyValue<string>("title", page.Name);
            FullWidth = page.GetPropertyValue("fullWidth", defaultValue: false);
            Children = page.Children.ToList();
        }
    }
}