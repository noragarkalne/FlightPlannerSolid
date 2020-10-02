using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flight_Planner.Core.Models
{
    public class Airport : Entity
    {
        public string Country { get; set; }
        public string City { get; set; }
        //[JsonProperty(PropertyName = "airport")]
        public string AirportCode { get; set; }

        public override bool Equals(object obj)
        {
            var airport = obj as Airport;

            if (airport == null)
            {
                return false;
            }

            if (this.Country == airport.Country &&
                this.City == airport.City &&
                this.AirportCode == airport.AirportCode)
            {
                return true;
            }
            return false;
        }
    }
}
