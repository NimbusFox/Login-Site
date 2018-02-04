using Newtonsoft.Json;

namespace Login_Site.Models.Core {
    public class Gresult {
        [JsonProperty("success")]
        public bool Success { get; set; }
    }
}