using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObiletDemo.Domain.OBiletApiModels.RequestModels
{
    public class GetSessionRequestModel
    {
        public int type { get; set; }
        public Connection connection { get; set; }
        public Browser browser { get; set; }
    }

    public class Connection
    {
        [JsonProperty(PropertyName = "ip-address")]
        public string ipaddress { get; set; }
        public string port { get; set; }
    }

    public class Browser
    {
        public string name { get; set; }
        public string version { get; set; }
    }
}


