using System;
using System.Web.Mvc;
using NimbusFox.Login_Site.CodeLibraries.Core.EmailHandlers;
using NimbusFox.Login_Site.CodeLibraries.Core.MemberHandlers;
using NimbusFox.Login_Site.Models.Core.AjaxForms;
using Umbraco.Web.Mvc;

namespace NimbusFox.Login_Site.Controllers.Core {
    public class CoreAjaxController : SurfaceController {
        
        public ActionResult Register() {
            var register = new Register();

            if (Request.HttpMethod.ToLower() == "post") {
                if (TryUpdateModel(register)) {
                    register = RegistrationHandler.IsRegistrationValid(register);

                    if (register.Success) {
                        var member = RegistrationHandler.CreateMember(register);
                        RegistrationHandler.AddUpdateMember(member);
                        SystemEmailHandler.RegistrationEmail(member);
                    }
                }
            }

            ModelState.Clear();
            register.Password = "";
            register.ConfirmPassword = "";

            return PartialView("Core/AjaxForms/RegisterForm", register);
        }
    }
}