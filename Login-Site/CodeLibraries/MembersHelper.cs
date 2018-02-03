using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Security;

namespace Login_Site.CodeLibraries {
    public static class MembersHelper {
        public static bool IsLoggedIn {
            get {
                var msh = new MembershipHelper(UmbracoContext.Current);

                return msh.IsLoggedIn();
            }
        }

        public static bool IsEmailBanned(string email) {
            var cs = ApplicationContext.Current.Services.ContentService;
            var rootBanned = cs.GetRootContent()
                .First(x => GlobalHelper.GetNode(x.Id).DocumentTypeAlias == "blockedEmails");

            var emails = rootBanned.Children().Select(x => x.Name).ToList();

            var currentBanned = GlobalHelper.GetRoot().FirstChild("blockedEmails");

            emails.AddRange(currentBanned.Children.Select(x => x.Name).Where(x => !emails.Contains(x)));

            for (var i = 0; i < emails.Count; i++) {
                var text = emails[i];
                if (text.Contains("*")) {
                    emails[i] = text.Replace("*", "(.*?)");
                }
            }

            return emails.Select(vEmail => new Regex(vEmail)).Any(reg => reg.IsMatch(email));
        }

        public static bool IsIpBanned(string ip) {
            var cs = ApplicationContext.Current.Services.ContentService;
            var rootBanned = cs.GetRootContent()
                .First(x => GlobalHelper.GetNode(x.Id).DocumentTypeAlias == "blockedIPs");

            var ips = rootBanned.Children().Select(x => x.Name).ToList();

            var currentBanned = GlobalHelper.GetRoot().FirstChild("blockedIPs");

            ips.AddRange(currentBanned.Children.Select(x => x.Name).Where(x => !ips.Contains(x)));

            return ips.Contains(ip);
        }

        public static bool IsNameBanned(string name) {
            var cs = ApplicationContext.Current.Services.ContentService;
            var rootBanned = cs.GetRootContent()
                .First(x => GlobalHelper.GetNode(x.Id).DocumentTypeAlias == "blockedNames");

            var names = rootBanned.Children().Select(x => x.Name).ToList();

            var currentBanned = GlobalHelper.GetRoot().FirstChild("blockedNames");

            names.AddRange(currentBanned.Children.Select(x => x.Name).Where(x => !names.Contains(x)));

            for (var i = 0; i < names.Count; i++) {
                var text = names[i];
                if (text.Contains("*")) {
                    names[i] = text.Replace("*", "(.*?)");
                }
            }

            return names.Select(vEmail => new Regex(vEmail)).Any(reg => reg.IsMatch(name));
        }

        public static int GetLoggedInMemberId() {
            var helper = new UmbracoHelper(UmbracoContext.Current);

            return helper.MembershipHelper.GetCurrentMemberId();
        }

        public static DateTime GetTimeZoneDateTime() {
            return GetTimeZoneDateTime(DateTime.Now);
        }

        public static DateTime GetTimeZoneDateTime(DateTime value) {
            int? time = null;

            if (IsLoggedIn) {
                var ms = ApplicationContext.Current.Services.MemberService;

                var member = ms.GetById(GetLoggedInMemberId());

                var timezone = member.GetValue<IPublishedContent>("timeZone");

                if (timezone != null) {
                    time = timezone.GetPropertyValue<int?>("minutes", null);
                }
            }

            if (time == null) {
                var timezone = GlobalHelper.GetRoot().GetPropertyValue<IPublishedContent>("siteTimezone");

                if (timezone == null) {
                    time = 0;
                } else {
                    time = timezone.GetPropertyValue<int>("minutes");
                }
            }

            return value.AddMinutes(time.Value);
        }
    }

}