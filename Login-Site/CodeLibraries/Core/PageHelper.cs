using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Login_Site.CodeLibraries.Core {
    public static class PageHelper {
        public static string PageTitle(IPublishedContent page) {
            var current = page.GetPropertyValue<string>("title", page.Name);

            var root = GlobalHelper.GetRoot(page);

            var rootTitle = root.GetPropertyValue<string>("title", root.Name);

            var output = rootTitle;

            if (current != rootTitle) {
                output = current + " - " + rootTitle;
            }

            return output;
        }

        public static string GetUrl(IPublishedContent page) {
            return page.UrlWithDomain();
        }

        public static IPublishedContent CurrentPage {
            get {
                if (HttpContext.Current.Session["CurrentPage"] == null) {
                    return GlobalHelper.GetRoot();
                }

                return (IPublishedContent)HttpContext.Current.Session["CurrentPage"];
            }
            set { HttpContext.Current.Session["CurrentPage"] = value; }
        }
    }

}