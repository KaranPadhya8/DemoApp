// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using DemoApp.Models;

namespace DemoApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Flight> Flight = new List<Flight>
                {
                    new Flight { FlightNumber = 1, Departure = "YUL", Arrival = "YYZ", Day = 1 },
                    new Flight { FlightNumber = 2, Departure = "YUL", Arrival = "YYC", Day = 1 },
                    new Flight { FlightNumber = 3, Departure = "YUL", Arrival = "YVR", Day = 1 },
                    new Flight { FlightNumber = 4, Departure = "YUL", Arrival = "YYZ", Day = 2 },
                    new Flight { FlightNumber = 5, Departure = "YUL", Arrival = "YYC", Day = 2 },
                    new Flight { FlightNumber = 6, Departure = "YUL", Arrival = "YVR", Day = 2 },
            };
        
            Schedule FlightSchedule = new();
            FlightSchedule.Flights = Flight;
            OutputFlightSchedule(FlightSchedule);
            // update the location of your json file
            var orders = JsonConvert.DeserializeObject<Dictionary<string, Orders>>(File.ReadAllText(@"\DemoApp\coding-assigment-orders.json"));
            DisplayFlightItineraries(ScheduleOrders(orders, FlightSchedule));
        }
        

        public static void OutputFlightSchedule(Schedule schedule)
        {
            foreach (var flight in schedule.Flights)
            {
                Console.WriteLine($"Flight: {flight.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
            }
        }

        static List<Flight> ScheduleOrders(Dictionary<string, Orders> orders, Schedule schedule)
        {
            var flights = new List<Flight>();

            foreach (var order in orders)
            {
                var scheduled = false;

                foreach (var flight in schedule.Flights)
                {
                    if (flights.Count(f => f.FlightNumber == flight.FlightNumber) >= 20)
                    {
                        continue;
                    }

                    if (flight.Arrival == order.Value.Destination)
                    {
                        flights.Add(new Flight { Departure = flight.Arrival, Arrival = flight.Departure, FlightNumber = flight.FlightNumber, Day = flight.Day, OrderNo = order.Key });
                        scheduled = true;
                        break;
                    }
                }

                if (!scheduled)
                {
                    Console.WriteLine($"order: {order.Key} with destination {order.Value.Destination}, flightNumber: not scheduled");
                }
            }

            return flights;
        }

        static void DisplayFlightItineraries(List<Flight> flights)
        {
            foreach (var flight in flights)
            {
                Console.WriteLine($"order: {flight.OrderNo}, flightNumber: {flight.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival}, day: {flight.Day}");
            }
        }
    }
}
