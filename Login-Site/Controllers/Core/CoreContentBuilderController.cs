using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NimbusFox.Login_Site.CodeLibraries.Core;
using NimbusFox.Login_Site.Models;
using NimbusFox.Login_Site.Models.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Mvc;
using NimbusFox.Login_Site.Models.Core.Content_Builder;

namespace NimbusFox.Login_Site.Controllers.Core {
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

        public ActionResult UserSection() {
            return PartialView("Core/UserSection");
        }

        public ActionResult LoginForm(IPublishedContent page) {
            return PartialView("Core/Content Builder/LoginForm");
        }

        public ActionResult RegisterForm(IPublishedContent page) {
            return PartialView("Core/Content Builder/RegisterForm");
        }

        public ActionResult LogoutDisplay(IPublishedContent page) {
            Members.Logout();
            return PartialView("Core/Content Builder/LogoutDisplay", new LogoutDisplay(page));
        }

        public ActionResult Container(IPublishedContent page) {
            return PartialView("Core/Content Builder/Container", new Container(page));
        }

        public ActionResult Content(IPublishedContent page) {
            return PartialView("Core/Content Builder/Content", new Models.Core.Content_Builder.Content(page));
        }

        public ActionResult CenteredDialog(IPublishedContent page) {
            return PartialView("Core/Content Builder/Containers/CenteredDialog", page);
        }

        public ActionResult Dialog(IPublishedContent page) {
            return PartialView("Core/Content Builder/Containers/Dialog", page);
        }

        public ActionResult Jumbotron(IPublishedContent page) {
            return PartialView("Core/Content Builder/Containers/Jumbotron", page);
        }

        public ActionResult RedirectCounter(IPublishedContent page) {
            return PartialView("Core/Content Builder/RedirectCounter", new RedirectCounter(page));
        }

        public ActionResult Settings(IPublishedContent page) {
            return PartialView("Core/Content Builder/Settings");
        }
    }
}