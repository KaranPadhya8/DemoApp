using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Models
{
    public class Flight
    {
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public int FlightNumber { get; set; }
        public int Day { get; set; }
        public string? OrderNo { get; set; }
    }
}
