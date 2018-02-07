using System;
using System.Linq;
using System.Text.RegularExpressions;
using NimbusFox.Login_Site.Models.Core;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Security;

namespace NimbusFox.Login_Site.CodeLibraries.Core {
    public static class MembersHelper {
        private static MembershipHelper Ms => new MembershipHelper(UmbracoContext.Current);

        public static bool IsLoggedIn => Ms.IsLoggedIn();

        public static int GetCurrentMemberId() {
            return IsLoggedIn ? Ms.GetCurrentMemberId() : 0;
        }

        public static IMember GetCurrentMember() {
            return IsLoggedIn ? ApplicationContext.Current.Services.MemberService.GetById(GetCurrentMemberId()) : null;
        }

        public static IMember GetMember(int memberId) {
            return ApplicationContext.Current.Services.MemberService.GetById(memberId);
        }
    }

}