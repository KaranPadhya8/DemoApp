using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Models
{
    public class Schedule
    {
        public List<Flight> Flights { get; set; }
        public int Day { get; set; }
    }
}
