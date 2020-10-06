using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Flight_Planner.Core.Models;
using Flight_Planner.Core.Services;
using Flight_Planner.Services;
using Flight_Planner_Data;

namespace Flight_Planner.Models
{
    public class SearchFlightRequest 
    {
        public string From { get; set; }
        public string To { get; set; }
        public string DepartureDate { get; set; }

        
        public SearchFlightRequest(string from, string to, string departureDate)
        {
            this.From = from;
            this.To = to;
            this.DepartureDate = departureDate;
        }

        public static bool IsRequestValid(SearchFlightRequest req)
        {
            if (req?.To != null &&
                req.From != null &&
                req.DepartureDate != null &&
                req.To != req.From)
            {
                return true;
            }
            return false;
        }
    }
}