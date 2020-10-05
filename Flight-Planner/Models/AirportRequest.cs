using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Flight_Planner.Models
{
    public class AirportRequest
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        [JsonProperty(PropertyName = "airport")]
        public string AirportCode { get; set; }

    }
}