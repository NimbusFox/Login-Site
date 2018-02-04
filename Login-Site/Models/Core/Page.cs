using Umbraco.Core.Models;

namespace Login_Site.Models.Core {
    public class Page : PageMaster {
        public Page() { }

        public Page(IPublishedContent page) : base(page) { }
    }
}