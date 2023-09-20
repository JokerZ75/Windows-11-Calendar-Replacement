using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_11_Calendar_Replacement
{
    class Calender
    {

        public Year CurrentYear { get; set; }
        public Month CurrentMonth { get; set; }
        public List<Year> Years { get; set; }

        public Calender()
        {
            CurrentYear = new Year(DateTime.Now.Year);
            CurrentMonth = new Month(DateTime.Now.Month, DateTime.Now.Year);
            Console.WriteLine(CurrentYear);
            Years = CalculateYears(Convert.ToInt32(CurrentYear.ToString()));
        }

        private List<Year> CalculateYears(int currentYear)
        {
            List<Year> YearList = new List<Year>();
            for (int i = 1; i < 100; i++)
            {
                YearList.Add(new Year(i));
            }
            return YearList;

        }

        public void AddEvent(Event e, int year, int month, int day)
        {
            Years[year].AddEvent(e, month, day);
        }

        public override string ToString()
        {
            return Years.ToString();
        }

    }
}
