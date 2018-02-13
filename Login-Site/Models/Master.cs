using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.Models {
    public class Master {
        public string Title { get; set; }

        public Master() { }

        public Master(IPublishedContent page) {
            Title = page.GetPropertyValue<string>("title", "");
        }
    }
}