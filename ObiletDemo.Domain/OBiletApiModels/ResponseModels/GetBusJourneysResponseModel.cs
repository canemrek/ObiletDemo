using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ObiletDemo.Domain.OBiletApiModels.ResponseModels
{
    public class GetBusJourneysResponseModel
    {
        [JsonProperty(PropertyName = "status")]
        public string status { get; set; }
        [JsonProperty(PropertyName = "data")]
        public BusJournyeMain[] data { get; set; }
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

    public class BusJournyeMain
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "partner-id")]
        public int partnerid { get; set; }
        [JsonProperty(PropertyName = "partner-name")]
        public string partnername { get; set; }
        [JsonProperty(PropertyName = "route-id")]
        public int routeid { get; set; }
        [JsonProperty(PropertyName = "bus-type")]
        public string bustype { get; set; }
        [JsonProperty(PropertyName = "bus-type-name")]
        public string bustypename { get; set; }
        [JsonProperty(PropertyName = "total-seats")]
        public int totalseats { get; set; }
        [JsonProperty(PropertyName = "available-seats")]
        public int availableseats { get; set; }
        [JsonProperty(PropertyName = "journey")]
        public Journey journey { get; set; }
        [JsonProperty(PropertyName = "features")]
        public Feature[] features { get; set; }
        [JsonProperty(PropertyName = "origin-location")]
        public string originlocation { get; set; }
        [JsonProperty(PropertyName = "destination-location")]
        public string destinationlocation { get; set; }
        [JsonProperty(PropertyName = "is-active")]
        public bool isactive { get; set; }
        [JsonProperty(PropertyName = "origin-location-id")]
        public int originlocationid { get; set; }
        [JsonProperty(PropertyName = "destination-location-id")]
        public int destinationlocationid { get; set; }
        [JsonProperty(PropertyName = "is-promoted")]
        public bool ispromoted { get; set; }
        [JsonProperty(PropertyName = "cancellation-offset")]
        public int cancellationoffset { get; set; }
        [JsonProperty(PropertyName = "has-bus-shuttle")]
        public bool hasbusshuttle { get; set; }
        [JsonProperty(PropertyName = "disable-sales-without-gov-id")]
        public bool disablesaleswithoutgovid { get; set; }
        [JsonProperty(PropertyName = "display-offset")]
        public string displayoffset { get; set; }
        [JsonProperty(PropertyName = "partner-rating")]
        public float? partnerrating { get; set; }
        [JsonProperty(PropertyName = "has-dynamic-pricing")]
        public bool hasdynamicpricing { get; set; }
        [JsonProperty(PropertyName = "disable-sales-without-hes-code")]
        public bool disablesaleswithouthescode { get; set; }
        [JsonProperty(PropertyName = "disable-single-seat-selection")]
        public bool disablesingleseatselection { get; set; }
        [JsonProperty(PropertyName = "change-offset")]
        public int changeoffset { get; set; }
        [JsonProperty(PropertyName = "rank")]
        public int? rank { get; set; }
        [JsonProperty(PropertyName = "display-coupon-code-input")]
        public bool displaycouponcodeinput { get; set; }
        [JsonProperty(PropertyName = "disable-sales-without-date-of-birth")]
        public bool disablesaleswithoutdateofbirth { get; set; }
    }

    public class Journey
    {
        [JsonProperty(PropertyName = "kind")]
        public string kind { get; set; }
        [JsonProperty(PropertyName = "code")]
        public string code { get; set; }
        [JsonProperty(PropertyName = "stops")]
        public Stop[] stops { get; set; }
        [JsonProperty(PropertyName = "origin")]
        public string origin { get; set; }
        [JsonProperty(PropertyName = "destination")]
        public string destination { get; set; }
        [JsonProperty(PropertyName = "departure")]
        public DateTime departure { get; set; }
        [JsonProperty(PropertyName = "arrival")]
        public DateTime arrival { get; set; }
        [JsonProperty(PropertyName = "currency")]
        public string currency { get; set; }
        [JsonProperty(PropertyName = "duration")]
        public string duration { get; set; }
        [JsonProperty(PropertyName = "original-price")]
        public float originalprice { get; set; }
        [JsonProperty(PropertyName = "internet-price")]
        public float internetprice { get; set; }
        [JsonProperty(PropertyName = "provider-internet-price")]
        public float? providerinternetprice { get; set; }
        [JsonProperty(PropertyName = "booking")]
        public object booking { get; set; }
        [JsonProperty(PropertyName = "bus-name")]
        public string busname { get; set; }
        [JsonProperty(PropertyName = "policy")]
        public Policy policy { get; set; }
        [JsonProperty(PropertyName = "features")]
        public string[] features { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }
        [JsonProperty(PropertyName = "available")]
        public object available { get; set; }
    }

    public class Policy
    {
        [JsonProperty(PropertyName = "max-seats")]
        public object maxseats { get; set; }
        [JsonProperty(PropertyName = "max-single")]
        public int? maxsingle { get; set; }
        [JsonProperty(PropertyName = "max-single-males")]
        public int? maxsinglemales { get; set; }
        [JsonProperty(PropertyName = "max-single-females")]
        public int? maxsinglefemales { get; set; }
        [JsonProperty(PropertyName = "mixed-genders")]
        public bool mixedgenders { get; set; }
        [JsonProperty(PropertyName = "gov-id")]
        public bool govid { get; set; }
        [JsonProperty(PropertyName = "lht")]
        public bool lht { get; set; }
    }

    public class Stop
    {
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "station")]
        public string station { get; set; }
        [JsonProperty(PropertyName = "time")]
        public DateTime? time { get; set; }
        [JsonProperty(PropertyName = "is-origin")]
        public bool isorigin { get; set; }
        [JsonProperty(PropertyName = "is-destination")]
        public bool isdestination { get; set; }
    }

    public class Feature
    {
        [JsonProperty(PropertyName = "id")]
        public int id { get; set; }
        [JsonProperty(PropertyName = "priority")]
        public int? priority { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string name { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string description { get; set; }
        [JsonProperty(PropertyName = "is-promoted")]
        public bool ispromoted { get; set; }
        [JsonProperty(PropertyName = "back-color")]
        public string backcolor { get; set; }
        [JsonProperty(PropertyName = "fore-color")]
        public string forecolor { get; set; }
    }

}
