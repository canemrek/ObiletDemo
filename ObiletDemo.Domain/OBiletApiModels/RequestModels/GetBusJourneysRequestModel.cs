using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObiletDemo.Domain.OBiletApiModels.RequestModels
{

    public class GetBusJourneysRequestModel
    {
        [JsonProperty(PropertyName = "device-session")]
        public DeviceSession devicesession { get; set; }
        public DateTime date { get; set; }
        public string language { get; set; }
        public Data data { get; set; }
    }


    public class Data
    {
        [JsonProperty(PropertyName = "origin-id")]
        public int originid { get; set; }
        [JsonProperty(PropertyName = "destination-id")]
        public int destinationid { get; set; }
        [JsonProperty(PropertyName = "departure-date")]
        public DateTime departuredate { get; set; }
    }

}
