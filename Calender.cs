using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            for (int i = currentYear; i < currentYear + 5; i++)
            {
                YearList.Add(new Year(i));
            }
            for (int i = currentYear; i > currentYear - 5; i--)
            {
                YearList.Add(new Year(i));
            }   
            return YearList;

        }

        private Year GenerateNewYear(int next)
        {
            return new Year(Convert.ToInt32(CurrentYear.ToString()) + next);
         }

        public void AddEvent(Event e, int year, int month, int day)
        {
            Years[year].AddEvent(e, month, day);
        }

        public void NextMonth()
        {
            if ( CurrentMonth.MonthOfYear == 12)
            {
                CurrentYear = Years.Find(Years => Years.YearNumber == Convert.ToInt32(CurrentYear.ToString()) + 1) ?? GenerateNewYear(1);
                CurrentMonth = CurrentYear.Months.Find(Months => Months.MonthOfYear == 1);
            }
            else
            {
                CurrentMonth = CurrentYear.Months.Find(Months => Months.MonthOfYear == Convert.ToInt32(CurrentMonth.ToString()) + 1);

            }
        }

        public void PrevMonth()
        {
           if ( CurrentMonth.MonthOfYear == 1)
            {
                CurrentYear = Years.Find(Years => Years.YearNumber == Convert.ToInt32(CurrentYear.ToString()) - 1) ?? GenerateNewYear(-1);
                CurrentMonth = CurrentYear.Months.Find(Months => Months.MonthOfYear == 12);
            }
            else
            {
                CurrentMonth = CurrentYear.Months.Find(Months => Months.MonthOfYear == Convert.ToInt32(CurrentMonth.ToString()) - 1);

            }   
        }

        public override string ToString()
        {
            return Years.ToString();
        }

    }
}
