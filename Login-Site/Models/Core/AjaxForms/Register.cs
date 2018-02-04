using System;

namespace Login_Site.Models.Core.AjaxForms {
    public class Register : AjaxForm {
        public DateTime DateOfBirth { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}