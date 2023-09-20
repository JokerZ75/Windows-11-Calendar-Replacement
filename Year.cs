using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Windows_11_Calendar_Replacement
{
    class Year
    {

        public int YearNumber { get; set; }
        public List<Month> Months { get; set; }

        public Year(int year)
        {

            YearNumber = year;
            Months = CalculateMonths(year);
        }

        private List<Month> CalculateMonths(int year)
        {
            List<Month> MonthList = new List<Month>();
            for (int i = 1; i < 13; i++)
            {
                MonthList.Add(new Month(i, year));
            }
            return MonthList;

        }

        public void AddEvent(Event e, int month, int day)
        {
            Months[month].AddEvent(e, day);
        }

        public override string ToString()
        {
            return YearNumber.ToString();
        }   

    }
}
