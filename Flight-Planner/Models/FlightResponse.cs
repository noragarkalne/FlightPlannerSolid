﻿namespace Flight_Planner.Models
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