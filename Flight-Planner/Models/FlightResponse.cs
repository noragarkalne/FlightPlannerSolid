using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Models
{
    public class FlightResponse
    {  
        public int Id { get; set; }
        public virtual AirportResponse To { get; set; }
        public virtual AirportResponse From { get; set; }
        public string Carrier { get; set; }
        public string DepartureTime { get; set; }
        public string ArrivalTime { get; set; }
    }
}