using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Ajax.Utilities;
using Umbraco.Web.Media.EmbedProviders.Settings;

namespace NimbusFox.Login_Site.Models.Core.AjaxForms {
    public class AjaxForm {
        public string RecaptchaError { get; set; }
        public bool Success { get; set; }
        private Dictionary<string, string> Errors { get; set; }
        private Dictionary<string, string> Labels { get; set; }

        protected AjaxForm() {
            Errors = new Dictionary<string, string>();
            Labels = new Dictionary<string, string>();
        }

        public void AddError(string key, string error) {
            if (Errors.ContainsKey(key)) {
                Errors[key] = error;
            } else {
                Errors.Add(key, error);
            }
        }

        public void RemoveError(string key) {
            if (Errors.ContainsKey(key)) {
                Errors.Remove(key);
            }
        }

        public string GetError(string key) {
            if (key.IsNullOrWhiteSpace()) {
                return "";
            }

            return Errors.ContainsKey(key) ? Errors[key] : "";
        }

        public void AddLabel(string key, string label) {
            if (Labels.ContainsKey(key)) {
                Labels[key] = label;
            } else {
                Labels.Add(key, label);
            }
        }

        public void RemoveLabel(string key) {
            if (Labels.ContainsKey(key)) {
                Labels.Remove(key);
            }
        }

        public string GetLabel(string key) {
            if (key.IsNullOrWhiteSpace()) {
                return "";
            }

            return Labels.ContainsKey(key) ? Labels[key] : "";
        }
    }
}