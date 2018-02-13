using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using NimbusFox.Login_Site.CodeLibraries.Core;
using NimbusFox.Login_Site.CodeLibraries.Core.EmailHandlers;
using NimbusFox.Login_Site.CodeLibraries.Core.MemberHandlers;
using NimbusFox.Login_Site.Models;
using NimbusFox.Login_Site.Models.Core;
using NimbusFox.Login_Site.Models.Core.AjaxForms;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace NimbusFox.Login_Site.Controllers.Core {
    public class CoreAjaxController : SurfaceController {

        public ActionResult Login() {
            var login = new Login();

            if (Request.HttpMethod.ToLower() == "post") {
                if (TryUpdateModel(login)) {
                    login = SessionHandler.LoginValidation(login);

                    if (login.Success) {
                        var gateway = new AjaxGateway();
                        var ms = ApplicationContext.Services.MemberService;
                        var member = ms.Exists(login.Username) ? ms.GetByUsername(login.Username) : ms.GetByEmail(login.Username);

                        if (Members.Login(member.Username, login.Password)) {
                            return PartialView("Core/Page", new Page(gateway.SuccessfulLogin));
                        }
                        login.AddError(login.GetName(x => x.Username), "Either your username or password was incorrect. Please try again");
                    } else {
                        login.AddError(login.GetName(x => x.Username), "Either your username or password was incorrect. Please try again");
                    }
                }
            }

            ModelState.Clear();
            login.Password = "";
            return PartialView("Core/AjaxForms/LoginForm", login);
        }

        public ActionResult Register() {
            var register = new Register();

            if (Request.HttpMethod.ToLower() == "post") {
                if (TryUpdateModel(register)) {
                    register = RegistrationHandler.IsRegistrationValid(register);

                    if (register.Success) {
                        var member = RegistrationHandler.CreateMember(register);
                        RegistrationHandler.AddUpdateMember(member);
                        SystemEmailHandler.RegistrationEmail(member);

                        var gateway = new AjaxGateway();

                        return PartialView("Core/Page", new Page(gateway.SuccessfulAccountRegistration));
                    }
                }
            }

            ModelState.Clear();
            register.Password = "";
            register.ConfirmPassword = "";

            return PartialView("Core/AjaxForms/RegisterForm", register);
        }

        public ActionResult Validate() {
            var queryString = Request.QueryString;

            if (queryString.HasKeys()) {
                if (queryString.HasKey("id") &&
                    queryString.HasKey("vc")) {
                    var id = queryString.GetValue("id");
                    var vc = queryString.GetValue("vc");

                    var gateway = new AjaxGateway();

                    if (RegistrationHandler.ValidateRegistration(id, vc)) {
                        if (gateway.SuccessfulAccountActivation != null) {
                            return PartialView("~/Views/Master.cshtml",
                                new RenderModel<IPublishedContent>(gateway.SuccessfulAccountActivation));
                        }
                    } else {
                        if (gateway.FailedAccountActivation != null) {
                            return PartialView("~/Views/Master.cshtml",
                                new RenderModel<IPublishedContent>(gateway.FailedAccountActivation));
                        }
                    }
                }
            }

            return Content("");
        }

        public ActionResult Settings() {
            var input = new Dictionary<string, string>();

            if (Request.HttpMethod.ToLower() == "post") {
                if (TryUpdateModel(input)) {

                }
            }

            ModelState.Clear();

            var currentSettings = MembersHelper.GetCurrentMember().GetValue<Dictionary<string, string>>("userSettings");

            var output = new UserSettings(currentSettings);

            foreach (var item in input) {
                output.AddUpdateSettings(item.Key, item.Value);
            }

            return PartialView("Core/AjaxForms/SettingsForm", output);
        }
    }
}