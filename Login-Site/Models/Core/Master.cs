﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Login_Site.Models.Core {
    public class Master {
        public string Title { get; set; }

        public Master() { }

        public Master(IPublishedContent page) {
            Title = page.GetPropertyValue<string>("title", "");
        }
    }
}