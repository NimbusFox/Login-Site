using System;
using System.ComponentModel.DataAnnotations;
using NimbusFox.Login_Site.CodeLibraries.Core;
using Umbraco.Core;

namespace NimbusFox.Login_Site.Models.Core.AjaxForms {
    public class Register : AjaxForm {
        private DateTime _DateOfBirth { get; set; } = DateTime.Now.AddYears(-12);

        public string DateOfBirth {
            get { return _DateOfBirth.ToString("yyyy-MM-dd"); }
            set { _DateOfBirth = DateTime.Parse(value); }
        }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public Register() {
            AddLabel(this.GetName(x => x.DateOfBirth), "Date of Birth");
            AddLabel(this.GetName(x => x.Username), "Username");
            AddLabel(this.GetName(x => x.Email), "Email");
            AddLabel(this.GetName(x => x.Password), "Password");
            AddLabel(this.GetName(x => x.ConfirmPassword), "Confirm Password");
        }
    }
}