using NimbusFox.Login_Site.CodeLibraries.Core;

namespace NimbusFox.Login_Site.Models.Core.AjaxForms {
    public class Login : AjaxForm {
        public string Username { get; set; }
        public string Password { get; set; }

        public Login() {
            AddLabel(this.GetName(x => x.Username), "Username");
            AddLabel(this.GetName(x => x.Password), "Password");
        }
    }
}