using Umbraco.Core.Models;

namespace NimbusFox.Login_Site.Models.Core {
    public class Page : PageMaster {
        public Page() { }

        public Page(IPublishedContent page) : base(page) { }
    }
}