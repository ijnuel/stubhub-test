using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StubHub.ConsoleApp.Models
{
    public class EventDistance
    {
        public EventDistance(int distance, Event currentEvent)
        {
            Distance = distance;
            Event = currentEvent;
        }
        public Event Event { get; set; }
        public int Distance { get; set; }
    }
}
