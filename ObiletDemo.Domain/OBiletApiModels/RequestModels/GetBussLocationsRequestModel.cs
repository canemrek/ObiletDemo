using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObiletDemo.Domain.OBiletApiModels.RequestModels
{
    public class GetBussLocationsRequestModel
    {
        public string data { get; set; }
        [JsonProperty(PropertyName = "device-session")]
        public DeviceSession devicesession { get; set; }
        public DateTime date { get; set; }
        public string language { get; set; }
    }

   

}
