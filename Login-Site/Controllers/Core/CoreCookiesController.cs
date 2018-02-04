using System;
using System.Web;
using NimbusFox.Login_Site.CodeLibraries.Core;
using Umbraco.Web.Mvc;

namespace NimbusFox.Login_Site.Controllers.Core {
    public class CoreCookiesController : SurfaceController {
        public void Accept() {
            var cookie = new HttpCookie("AcceptedCookies", GlobalHelper.CookieAcceptanceValue()) { Expires = DateTime.Now.AddMonths(2) };

            HttpContext.Response.AppendCookie(cookie);
        }
    }

}