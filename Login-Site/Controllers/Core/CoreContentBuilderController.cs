using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_Site.CodeLibraries;
using Login_Site.Models;
using Login_Site.Models.Core.ContentBuilder;
using Login_Site.Models.Core;
using umbraco;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Login_Site.Controllers.Core {
    public class CoreContentBuilderController : SurfaceController {
        public ActionResult Menu(IPublishedContent page) {
            return PartialView("Core/Content Builder/Menu", new Menu(page));
        }

        public ActionResult MenuLink(IPublishedContent page) {
            return PartialView("Core/Content Builder/MenuLink", new MenuLink(page));
        }

        public ActionResult MenuDropDown(IPublishedContent page) {
            return PartialView("Core/Content Builder/MenuDropDown", new MenuDropDown(page));
        }

        public ActionResult MenuSubDropDown(IPublishedContent page) {
            return PartialView("Core/Content Builder/MenuSubDropDown", new MenuSubDropDown(page));
        }

        public ActionResult Cookies() {
            var cookieContent = GlobalHelper.GetRoot().GetPropertyValue<string>("cookieInformation", "");
            return PartialView("Core/Cookies", new HtmlString(cookieContent));
        }

        public ActionResult Site(IPublishedContent page) {
            var home = page.GetPropertyValue("homePage", new List<IPublishedContent>());

            return home.Any() ? Page(home.First()) : Content("");
        }

        public ActionResult Page(IPublishedContent page) {
            return PartialView("Core/Page", new Page(page));
        }
    }
}