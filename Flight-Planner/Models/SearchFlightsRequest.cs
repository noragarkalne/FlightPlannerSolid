namespace Flight_Planner.Models
{
    public class SearchFlightsRequest 
    {
        public string From { get; set; }
        public string To { get; set; }
        public string DepartureDate { get; set; }

        public SearchFlightsRequest(string from, string to, string departureDate)
        {
            this.From = from;
            this.To = to;
            this.DepartureDate = departureDate;
        }

        public static bool IsRequestValid(SearchFlightsRequest req)
        {
            if (!string.IsNullOrEmpty(req?.To) &&
                !string.IsNullOrEmpty(req.From) &&
                !string.IsNullOrEmpty(req.DepartureDate) &&
                req.To.ToLowerInvariant().Trim() != req.From.ToLowerInvariant().Trim())
            {
                return true;
            }

            return false;
        }
    }
}