using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObiletDemo.Domain.OBiletApiModels.RequestModels
{
    public class DeviceSession
    {
        [JsonProperty(PropertyName = "session-id")]
        public string sessionid { get; set; }
        [JsonProperty(PropertyName = "device-id")]
        public string deviceid { get; set; }
        public string IpAddress { get; set; }
        public string Port { get; set; }
        public string BrowserName { get; set; }
        public string BrowserVersion { get; set; }
    }
}
