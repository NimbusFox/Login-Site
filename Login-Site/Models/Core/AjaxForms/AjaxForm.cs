namespace Login_Site.Models.Core.AjaxForms {
    public class AjaxForm {
        public string RedirectTo { get; set; }
        public string RecaptchaError { get; set; }
        public bool Success { get; set; }
    }
}