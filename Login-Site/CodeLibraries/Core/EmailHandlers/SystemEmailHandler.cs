using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using NimbusFox.Login_Site.Models.Core;
using NimbusFox.Login_Site.Models.Core.Content_Builder;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.CodeLibraries.Core.EmailHandlers {
    public class SystemEmailHandler {
        public static void RegistrationEmail(IMember newMember) {
            var site = new SiteModel(GlobalHelper.GetRoot());
            var registration =
                new RegisterForm(site.Pages.RegisterPage.FirstChild("registerForm"));

            var replace = new Dictionary<string, string>();

            var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);

            replace.Add("username", newMember.Username);
            replace.Add("sitename", site.Page.Name);
            replace.Add("date_time_registered", DateTime.Now.ToString());
            replace.Add("validation_link",
                GlobalHelper.GetCurrentAddress() + urlHelper.Action("validate", GlobalHelper.AjaxGateway) +
                $"?id={newMember.Id}&vc={newMember.GetValue("validationCode")}");

            foreach (var key in replace.Keys) {
                if (registration.Message.ToHtmlString().Contains($"${key}")) {
                    registration.Message = new HtmlString(registration.Message.ToHtmlString().Replace($"${key}", replace[key]));
                }
            }

            SendEmail(newMember.Email, registration.From, registration.Subject, registration.Message.ToHtmlString());
        }

        private static void SendEmail(string to, string from, string subject, string message) {
            var email = new MailMessage(from, to, subject, message) {IsBodyHtml = true};

            var client = new SmtpClient();

            client.Send(email);
        }
    }
}