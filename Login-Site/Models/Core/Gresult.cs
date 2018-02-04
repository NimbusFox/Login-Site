using Newtonsoft.Json;

namespace NimbusFox.Login_Site.Models.Core {
    public class Gresult {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}