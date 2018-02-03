using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_Site.CodeLibraries;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace Login_Site.Controllers.Core {
    public class CookiesController : SurfaceController {
        public void Accept() {
            var cookie = new HttpCookie("AcceptedCookies", GlobalHelper.CookieText()) { Expires = DateTime.Now.AddMonths(2) };

            HttpContext.Response.AppendCookie(cookie);
        }
    }

}