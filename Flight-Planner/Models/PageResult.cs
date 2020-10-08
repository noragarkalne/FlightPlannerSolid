using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Flight_Planner.Core.Models;

namespace Flight_Planner.Models
{
    public class PageResult
    {
        public int Page { get; set; }
        public int TotalItems = 0;
        public List<Flight> Items { get; set; }

        public PageResult()
        {
            Items = new List<Flight>();
        }


        
    }
}