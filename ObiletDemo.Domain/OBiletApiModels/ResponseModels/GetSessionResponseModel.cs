using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObiletDemo.Domain.OBiletApiModels.ResponseModels
{

    public class GetSessionResponseModel
    {
        [JsonProperty(PropertyName = "status")]
        public string status { get; set; }
        public Data data { get; set; }
        [JsonProperty(PropertyName = "message")]
        public object message { get; set; }
        [JsonProperty(PropertyName = "user-message")]
        public object usermessage { get; set; }
        [JsonProperty(PropertyName = "apirequest-id")]
        public object apirequestid { get; set; }
        [JsonProperty(PropertyName = "controller")]
        public object controller { get; set; }
        [JsonProperty(PropertyName = "clientrequest-id")]
        public object clientrequestid { get; set; }
    }

    public class Data
    {
        [JsonProperty(PropertyName = "session-id")]
        public string sessionid { get; set; }
        [JsonProperty(PropertyName = "device-id")]
        public string deviceid { get; set; }
        public object affiliate { get; set; }
        [JsonProperty(PropertyName = "device-type")]
        public int devicetype { get; set; }
        public object device { get; set; }
    }

}
