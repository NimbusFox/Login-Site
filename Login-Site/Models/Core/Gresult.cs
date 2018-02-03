using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Login_Site.Models.Core {
    public class Gresult {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}