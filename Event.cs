using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_11_Calendar_Replacement
{
    class Event
    {

        public string Name { get; set; }
        public DateTime Start { get; set; }

        public Event(string name, string description, DateTime start)
        {
            Name = name;
            Start = start;
        }

        public override string ToString()
        {
            return Name + " " + Start;
        }




    }
}
