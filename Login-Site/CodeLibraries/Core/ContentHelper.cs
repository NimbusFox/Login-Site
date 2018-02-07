using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NimbusFox.Login_Site.Models.Core;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.CodeLibraries.Core {
    public class ContentHelper {
        public static string ParseText(string input) {
            var output = input;

            var keyValues = new Dictionary<string, string>();

            var member = MembersHelper.GetCurrentMember();

            keyValues.Add("current_member", member != null ? member.Username : "");

            if (HttpContext.Current.Request.QueryString.HasKeys()) {
                var queryString = HttpContext.Current.Request.QueryString;

                if (queryString.HasKey("id")) {
                    var id = queryString.GetValue("id");
                    if (int.TryParse(id, out var numId)) {
                        member = MembersHelper.GetMember(numId);
                        if (member != null) {
                            keyValues.Add("activated_member", member.Username);
                            keyValues.Add("activated_member_email", member.Email);
                        }
                    }
                }
            }

            keyValues.Add("date", DateTime.Now.ToString("dd/MM/yyyy"));
            keyValues.Add("time", DateTime.Now.ToString("h:mm tt"));

            var site = new SiteModel(GlobalHelper.GetRoot());
            keyValues.Add("link_login", site.Pages.LoginPage != null ? site.Pages.LoginPage.UrlWithDomain() : "");
            keyValues.Add("link_register", site.Pages.RegisterPage != null ? site.Pages.RegisterPage.UrlWithDomain() : "");
            keyValues.Add("link_logout", site.Pages.LogoutPage != null ? site.Pages.LogoutPage.UrlWithDomain() : "");

            foreach (var data in keyValues) {
                if (output.Contains($"${data.Key}")) {
                    output = output.Replace($"${data.Key}", data.Value);
                }
            }

            return output;
        }
    }
}