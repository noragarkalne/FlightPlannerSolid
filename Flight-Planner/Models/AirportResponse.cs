﻿using Newtonsoft.Json;

namespace Flight_Planner.Models
{
    public class AirportResponse
    {
        public string Country { get; set; }
        public string City { get; set; }
        [JsonProperty(PropertyName = "airport")]
        public string AirportCode { get; set; }
    }
}