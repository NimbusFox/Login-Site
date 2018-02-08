using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NimbusFox.Login_Site.CodeLibraries.Core;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace NimbusFox.Login_Site.Models.Core {
    public class AjaxGateway {
        public IPublishedContent SuccessfulAccountActivation { get; }
        public IPublishedContent FailedAccountActivation { get; }
        public IPublishedContent SuccessfulAccountRegistration { get; }
        public IPublishedContent SuccessfulLogin { get; }
        private readonly List<IPublishedContent> _defaultVal = new List<IPublishedContent>();
        private readonly IPublishedContent _root;

        public AjaxGateway() {
            _root = GlobalHelper.GetRoot();

            if (_root.Children.Any(x => x.DocumentTypeAlias.ToLower() == "ajaxgateway")) {
                var gateway = _root.FirstChild("ajaxGateway");

                SuccessfulAccountActivation =
                    gateway.GetPropertyValue("successfulAccountActivation", _defaultVal).FirstOrDefault();

                FailedAccountActivation = gateway.GetPropertyValue("failedAccountActivation", _defaultVal).FirstOrDefault();

                SuccessfulAccountRegistration = gateway.GetPropertyValue("successfulAccountRegistration", _defaultVal)
                    .FirstOrDefault();

                SuccessfulLogin = gateway.GetPropertyValue("successfulLogin", _defaultVal).FirstOrDefault();
            }
        }
    }
}