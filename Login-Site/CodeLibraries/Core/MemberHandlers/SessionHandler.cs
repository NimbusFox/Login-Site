using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using NimbusFox.Login_Site.Models.Core.AjaxForms;
using Umbraco.Core;
using Umbraco.Web;
using Umbraco.Web.Security;

namespace NimbusFox.Login_Site.CodeLibraries.Core.MemberHandlers {
    public class SessionHandler {

        private static MembershipHelper Members => new MembershipHelper(UmbracoContext.Current);

        public static Login LoginValidation(Login data) {
            var ms = ApplicationContext.Current.Services.MemberService;
            var valid = !(!ms.Exists(data.Username) && ms.GetByEmail(data.Username) == null);

            data.Success = valid;

            return data;
        }

        public static void Logout() => Members.Logout();
    }
}