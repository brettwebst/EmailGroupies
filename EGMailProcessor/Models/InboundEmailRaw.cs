using System;
using System.Collections.Generic;
using System.Text;

namespace EGMailProcessor.Models
{
    using Newtonsoft.Json;

    public class InboundEmailRaw
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "postVars")]
        public string PostVars { get; set; }

        [JsonProperty(PropertyName = "queryStringVars")]
        public string QueryStringVariables { get; set; }

        [JsonProperty(PropertyName = "body")]
        public string body { get; set; }
    }
}
