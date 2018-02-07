using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NimbusFox.Login_Site.Models.Core.AjaxForms;
using Umbraco.Core;
using Umbraco.Core.Models;
using Umbraco.Web;
using Umbraco.Web.Security;
using DateTime = System.DateTime;

namespace NimbusFox.Login_Site.CodeLibraries.Core.MemberHandlers {
    public class RegistrationHandler {
        public static Register IsRegistrationValid(Register data) {
            var ms = ApplicationContext.Current.Services.MemberService;
            var valid = true;

            if (data.Username.IsNullOrWhiteSpace()) {
                valid = false;
                data.AddError(data.GetName(x => x.Username), "Your username cannot be blank");
            } else if (ms.Exists(data.Username)) {
                valid = false;
                data.AddError(data.GetName(x => x.Username), "A user with this username exists");
            }

            if (ms.GetByEmail(data.Email) != null) {
                valid = false;
                data.AddError(data.GetName(x => x.Email), "This email is already in use");
            }

            bool pValid;
            PasswordValidation(data, out pValid);

            valid = pValid && valid;

            if (!pValid) {
                data.AddError(data.GetName(x => x.Password),
                    "Your password must have:" +
                    "<ul>" +
                    "<li>At least one upper and one lower character</li>" +
                    "<li>At lease one number</li><li>At least one special character</li>" +
                    "<li>At least 8 characters</li>" +
                    "</ul>");
            }

            if (data.Password != data.ConfirmPassword) {
                valid = false;
                data.AddError(data.GetName(x => x.ConfirmPassword), "Your passwords must match");
            }

            if (DateTime.Parse(data.DateOfBirth) < DateTime.Today.AddYears(-100) || DateTime.Parse(data.DateOfBirth) > DateTime.Today.AddYears(-10)) {
                valid = false;
                data.AddError(data.GetName(x => x.DateOfBirth), "Please enter a valid date of birth");
            }

            data.Success = valid;
            return data;
        }

        private static void PasswordValidation(Register data, out bool pValid) {
            var password = data.Password;
            var specialCharacters = new List<char> { '!', '"', '£', '$', '%', '^', '&', '*', '(', ')', '@', '#', '~', '[', ']', '{', '}', '?', '/', '\\', '|', '-', '_', '=', '+', '`', '¬' };
            int temp;

            pValid = password.Any(x => x.IsLowerCase()) && password.Any(x => x.IsUpperCase()) && password.Any(x => int.TryParse(x.ToString(), out temp)) && password.Any(x => specialCharacters.Contains(x)) && password.Length >= 8;
        }

        public static string GenerateValidationValue() {
            var output = "";

            output += Guid.NewGuid().ToString().Replace("-", "");
            output += Guid.NewGuid().ToString().Replace("-", "");

            return output;
        }

        public static IMember CreateMember(Register data) {
            var ms = ApplicationContext.Current.Services.MemberService;

            var member = ms.CreateMember(data.Username, data.Email, data.Username, "member");

            member.RawPasswordValue = data.Password;
            member.SetValue("dateOfBirth", data.DateOfBirth);

            member.SetValue("validated", false);
            member.SetValue("validationCode", GenerateValidationValue());

            return member;
        }

        public static void AddUpdateMember(IMember member) {
            var ms = ApplicationContext.Current.Services.MemberService;

            ms.Save(member);
        }

        public static bool ValidateRegistration(string id, string validationCode) {
            var ms = ApplicationContext.Current.Services.MemberService;

            int mId;

            if (!int.TryParse(id, out mId)) {
                return false;
            }

            var member = ms.GetById(mId);

            if (member == null) {
                return false;
            }

            if (member.GetValue<bool>("validated")) {
                return false;
            }

            var vc = member.GetValue<string>("validationCode");

            if (vc.IsNullOrWhiteSpace()) {
                return false;
            }

            if (validationCode != vc) {
                return false;
            }

            member.SetValue("validated", true);
            member.SetValue("validationCode", "");

            AddUpdateMember(member);

            return true;
        }
    }
}