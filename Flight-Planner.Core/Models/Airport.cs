using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Flight_Planner.Core.Models
{
    public class Airport : Entity
    {
        [ConcurrencyCheck]
        public string Country { get; set; }
        [ConcurrencyCheck]
        public string City { get; set; }
        [ConcurrencyCheck]
        [JsonProperty(PropertyName = "airport")]
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
