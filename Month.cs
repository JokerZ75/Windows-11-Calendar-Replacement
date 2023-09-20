using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_11_Calendar_Replacement
{
    class Month
    {

        public int MonthOfYear { get; set; }
        public List<Day> Days { get; set; }

        public Month(int Month, int CurrentYear)
        {

            MonthOfYear = Month;
            Days = CalculateDays(Month, CurrentYear);
        }

        private List<Day> CalculateDays(int month, int currentYear)
        {
            int numberOfDays = DateTime.DaysInMonth(currentYear, month);
            List<Day> DayList = new List<Day>();
            for (int i = 1; i < numberOfDays + 1; i++)
            {
                DayList.Add(new Day(i));
            }
            return DayList;

        }

        public void AddEvent(Event e, int day)
        {
            Days[day].AddEvent(e);
        }

        public override string ToString()
        {
            return MonthOfYear.ToString();
        }

    }
}
