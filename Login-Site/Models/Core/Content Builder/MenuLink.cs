using Login_Site.Models;
using Login_Site.Models.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Login_Site.Models.Core.ContentBuilder {
    public class MenuLink : ItemVisibility {
        public string Text { get; set; }
        public string Url { get; set; }
        public bool NewPage { get; set; }
        public string Parent { get; set; }

        public MenuLink() { }

        public MenuLink(IPublishedContent page) : base(page) {
            Text = page.Name;
            NewPage = page.GetPropertyValue("newPage", defaultValue: false);
            Url = page.GetPropertyValue<string>("targetUrl",
                page.GetPropertyValue<IPublishedContent>("internalPage")?.UrlWithDomain() ?? "#");
            Parent = page.Parent.DocumentTypeAlias;
        }
    }
}