using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_11_Calendar_Replacement
{

    class Day
    {

        public int DayOfMonth { get; set; }
        public List<Event> Events { get; set; }

        public Day(int Day)
        {

            DayOfMonth = Day;

        }
        
        public void AddEvent(Event e)
        {
            Events.Add(e);
        }

        public override string ToString()
        {
            return DayOfMonth.ToString();
        }


    }
}
