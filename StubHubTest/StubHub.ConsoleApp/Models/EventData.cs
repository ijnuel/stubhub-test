using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubHub.ConsoleApp.Models
{
    public class EventData
    {
        public EventData(int distance, int price)
        {
            Distance = distance;
            Price = price;
        }

        public int Distance { get; set; }
        public int Price { get; set; }
    }
}
