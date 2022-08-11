using StubHub.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubHub.ConsoleApp
{
    public static class Solutions
    {
        /***
         * fixed default code errors
        ***/
        public static void DefaultCode(List<Event> events, Customer customer)
        {
            Console.WriteLine("Default Code....................................................");
            var query = from result in events
                        where result.City.Contains("New York")
                        select result;

            // 1. TASK
            foreach (var item in query)
            {
                AddToEmail(customer, item);
            }
        }

        /***
         * add all events in the customer's location to the email
        ***/
        public static void ProblemOne(List<Event> events, Customer customer)
        {
            Console.WriteLine("Problem One....................................................");
            var cityEvents = events.Where(x => x.City.Equals(customer.City)).ToList();
            cityEvents.ForEach(item => AddToEmail(customer, item));
        }

        /***
         * add 5 closest events to the customer's location to the email
        ***/
        public static void ProblemTwo(List<Event> events, Customer customer)
        {
            Console.WriteLine("Problem Two....................................................");
            List<EventDistance> eventsWithDistance = new List<EventDistance>();
            foreach (var item in events)
            {
                var distance = GetDistance(customer.City, item.City);
                eventsWithDistance.Add(new EventDistance(distance, item));
            }

            var closestFiveEvents = eventsWithDistance
                .OrderBy(x => x.Distance).Take(5)
                .Select(x => x.Event).ToList();

            closestFiveEvents.ForEach(item => AddToEmail(customer, item));
        }

        /***
         * optimized to add 5 closest events to the customer's location to the email
        ***/
        public static void ProblemThree(List<Event> events, Customer customer)
        {
            Console.WriteLine("Problem Three....................................................");
            Dictionary<Event, int> eventsWithDistance = new Dictionary<Event, int>();
            foreach (var item in events)
            {
                var distance = GetDistance(customer.City, item.City);
                eventsWithDistance.Add(item, distance);
            }

            var closestFiveEvents = eventsWithDistance
                .OrderBy(x => x.Value).Take(5)
                .Select(x => x.Key).ToList();

            closestFiveEvents.ForEach(item => AddToEmail(customer, item));
        }

        /***
         * optimized to not stop whenever get distance fails
         * When get distance fails, log the error and continue with other events
        ***/
        public static void ProblemFour(List<Event> events, Customer customer)
        {
            Console.WriteLine("Problem Four....................................................");
            Dictionary<Event, int> eventsWithDistance = new Dictionary<Event, int>();
            foreach (var item in events)
            {
                try
                {
                    var distance = GetDistance(customer.City, item.City);
                    eventsWithDistance.Add(item, distance);
                }
                catch (Exception)
                {
                    //log the error and continue
                    Console.WriteLine($"Unable to get the distance between {customer.City} and {item.City}");
                }
            }

            var closestFiveEvents = eventsWithDistance
                .OrderBy(x => x.Value).Take(5)
                .Select(x => x.Key).ToList();

            closestFiveEvents.ForEach(item => AddToEmail(customer, item));
        }

        /***
         * optimized to order final results by price
        ***/
        public static void ProblemFive(List<Event> events, Customer customer)
        {
            Console.WriteLine("Problem Five....................................................");
            Dictionary<Event, EventData> eventsWithDistance = new Dictionary<Event, EventData>();
            foreach (var item in events)
            {
                int distance;
                int price;
                try
                {
                    distance = GetDistance(customer.City, item.City);
                }
                catch (Exception)
                {
                    //log the error and continue
                    Console.WriteLine($"Unable to get the distance between {customer.City} and {item.City}");
                    continue;
                }
                try
                {
                    price = GetPrice(item);
                }
                catch (Exception)
                {
                    //log the error and assign max value
                    Console.WriteLine($"Unable to get the price of {item.Name} in {item.City}");
                    price = int.MaxValue;
                }
                eventsWithDistance.Add(item, new EventData(distance, price));
            }

            var closestFiveEvents = eventsWithDistance.OrderBy(x => x.Value.Distance).ThenBy(x => x.Value.Price).Take(5).Select(x => x.Key).ToList();

            closestFiveEvents.ForEach(item => AddToEmail(customer, item));


        }


        #region Helpers

        // You do not need to know how these methods work
        static void AddToEmail(Customer c, Event e, int? price = null)
        {
            var distance = GetDistance(c.City, e.City);
            Console.Out.WriteLine($"{c.Name}: {e.Name} in {e.City}"
            + (distance > 0 ? $" ({distance} miles away)" : "")
            + (price.HasValue ? $" for ${price}" : ""));
        }


        static int GetPrice(Event e)
        {
            return (AlphebiticalDistance(e.City, "") + AlphebiticalDistance(e.Name, "")) / 10;
        }


        static int GetDistance(string fromCity, string toCity)
        {
            return AlphebiticalDistance(fromCity, toCity);
        }


        private static int AlphebiticalDistance(string s, string t)
        {
            var result = 0;
            var i = 0;
            for (i = 0; i < Math.Min(s.Length, t.Length); i++)
            {
                // Console.Out.WriteLine($"loop 1 i={i} {s.Length} {t.Length}");
                result += Math.Abs(s[i] - t[i]);
            }
            for (; i < Math.Max(s.Length, t.Length); i++)
            {
                // Console.Out.WriteLine($"loop 2 i={i} {s.Length} {t.Length}");
                result += s.Length > t.Length ? s[i] : t[i];
            }
            return result;
        }
        #endregion
    }
}
