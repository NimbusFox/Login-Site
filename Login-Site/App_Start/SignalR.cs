using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Owin;

namespace Login_Site.App_Start {
    public class Startup {
        public void Configuration(IAppBuilder app) {
            app.MapSignalR();
        }
    }
}