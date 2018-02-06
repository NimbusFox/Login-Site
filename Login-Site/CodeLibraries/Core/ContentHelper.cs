using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core;
using Umbraco.Web;

namespace NimbusFox.Login_Site.CodeLibraries.Core {
    public class ContentHelper {
        public static string ParseText(string input) {
            var output = input;

            var keyValues = new Dictionary<string, string>();

            var member = MembersHelper.GetCurrentMember();

            keyValues.Add("current_member", member != null ? member.Username : "");

            if (UmbracoContext.Current.PageId != null) {
                member = MembersHelper.GetMember(UmbracoContext.Current.PageId.Value);
                keyValues.Add("page_member", member.Username);
            }

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

            foreach (var data in keyValues) {
                if (output.Contains($"${data.Key}")) {
                    output = output.Replace($"{data.Key}", data.Value);
                }
            }

            return output;
        }
    }
}