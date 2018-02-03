using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;
using Login_Site.Models;
using Login_Site.Models.Core;
using Newtonsoft.Json;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Login_Site.CodeLibraries {
    public static class GlobalHelper {

        public static string ContentBuilder {
            get {
                if (ConfigurationManager.AppSettings.HasKeys()) {
                    if (ConfigurationManager.AppSettings.AllKeys.Contains("ContentBuilder")) {
                        return ConfigurationManager.AppSettings["ContentBuilder"];
                    }
                }

                return "CoreContentBuilder";
            }
        }

        public static IPublishedContent GetRoot() {
            var cs = ApplicationContext.Current.Services.ContentService;

            var data = GetNode(cs.GetRootContent().First().Id);

            return data;
        }

        public static IPublishedContent GetRoot(IPublishedContent page) {
            var output = page;

            while (output.Parent != null) {
                output = output.Parent;
            }

            return output;
        }

        public static IPublishedContent GetRoot(int id) {
            return GetRoot(GetNode(id));
        }

        public static IPublishedContent GetNode(int nodeId) {
            return new UmbracoHelper(UmbracoContext.Current).TypedContent(nodeId);
        }

        public static bool ValidRecaptcha(string response, string ip = "") {
            using (var client = new WebClient()) {

                var gresponse =
                    client.UploadValues("https://www.google.com/recaptcha/api/siteverify", new NameValueCollection()
                    {
                        { "secret", GetRoot().GetPropertyValue<string>("secretKey", "") },
                        { "response", response },
                        { "remoteip", ip }
                    });

                var result = JsonConvert.DeserializeObject<Gresult>(System.Text.Encoding.UTF8.GetString(gresponse));

                return result.Success;
            }
        }

        public static string GetIp() {
            var ip = HttpContext.Current.Request.UserHostAddress;

            if (HttpContext.Current.Request.Headers.HasKeys()) {
                if (HttpContext.Current.Request.Headers.AllKeys.Contains("X-Forwarded-For")) {
                    ip = HttpContext.Current.Request.Headers["X-Forwarded-For"];
                }
            }

            return ip;
        }

        public static string GetGResponse() {
            if (HttpContext.Current.Request.QueryString.AllKeys.Any(x => x == "g-recaptcha-response")) {
                return HttpContext.Current.Request.QueryString["g-recaptcha-response"];
            }

            if (HttpContext.Current.Request.Form.AllKeys.Any(x => x == "g-recaptcha-response")) {
                return HttpContext.Current.Request.Form["g-recaptcha-response"];
            }

            return "";
        }

        public static string RenderEmail(Dictionary<string, string> keys, string email) {
            var output = email;

            foreach (var item in keys) {
                var regex = new Regex($"##{item.Key}##", RegexOptions.IgnoreCase);

                if (regex.IsMatch(output)) {
                    output = output.Replace(regex.Match(output).Value, item.Value);
                }
            }

            return output;
        }

        public static IPublishedContent GetLatestEdit(IPublishedContent page) {
            var latest = page;

            if (page.DocumentTypeAlias.ToLower() == "site") {
                var current = page.GetPropertyValue<IPublishedContent>("home", null);

                if (current != null) {
                    page = current;
                }
            }

            foreach (var child in page.Children()) {
                var edit = GetLatestEdit(child);

                if (edit.UpdateDate > latest.UpdateDate) {
                    latest = edit;
                }
            }

            return latest;
        }

        public static int GetSystemId() {
            return ApplicationContext.Current.Services.UserService.GetByEmail("System@system.com").Id;
        }

        public static string GetCookieDomain() {
            var domain = ApplicationContext.Current.Services.DomainService
                .GetAssignedDomains(GetRoot().Id, false).First().DomainName;

            return domain.Count(x => x == '.') <= 1 ? $".{domain}" : domain.Substring(domain.IndexOf('.'));
        }

        public static bool IsDev {
            get {
                if (ConfigurationManager.AppSettings.AllKeys.Contains("IsDev")) {
                    if (ConfigurationManager.AppSettings["IsDev"] == "true") {
                        return true;
                    }
                }
                return false;
            }
        }

        public static string CookieText() {
            return true.ToString();
        }
    }

}