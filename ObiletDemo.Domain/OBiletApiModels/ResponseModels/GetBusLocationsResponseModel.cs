using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObiletDemo.Domain.OBiletApiModels.ResponseModels
{
    public class GetBusLocationsResponseModel
    {
        [JsonProperty(PropertyName = "status")]
        public string status { get; set; }
        public Datum[] data { get; set; }
        [JsonProperty(PropertyName = "message")]
        public object message { get; set; }
        [JsonProperty(PropertyName = "user-message")]
        public object usermessage { get; set; }
        [JsonProperty(PropertyName = "api-request-id")]
        public object apirequestid { get; set; }
        [JsonProperty(PropertyName = "controller")]
        public string controller { get; set; }
        [JsonProperty(PropertyName = "client-request-id")]
        public object clientrequestid { get; set; }
    }

    public class Datum
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "parent-id")]
        public int parentid { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string type { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "geo-location")]
        public GeoLocation geolocation { get; set; }
        public int zoom { get; set; }
        [JsonProperty(PropertyName = "tz-code")]
        public string tzcode { get; set; }
        [JsonProperty(PropertyName = "weather-code")]
        public object weathercode { get; set; }
        [JsonProperty(PropertyName = "rank")]
        public int? rank { get; set; }
        [JsonProperty(PropertyName = "reference-code")]
        public object referencecode { get; set; }
        [JsonProperty(PropertyName = "keywords")]
        public string keywords { get; set; }
    }

    public class GeoLocation
    {
        [JsonProperty(PropertyName = "latitude")]
        public float latitude { get; set; }
        [JsonProperty(PropertyName = "longitude")]
        public float longitude { get; set; }
        [JsonProperty(PropertyName = "zoom")]
        public int zoom { get; set; }
    }

}
