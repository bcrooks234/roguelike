using System;

namespace Roguelike {
    public class Date {
        public int Day;
        public int Month;
        public int Year;

        private int daysInMonth = 30;

        public Date(int day, int month, int year) {
            Day = day;
            Month = month;
            Year = year;
        }


        public override string ToString() {
            return Day + "/" + Month + "/" + Year;
        }


        public void Print() {
            Console.Write(ToString());
        }

        public void PassTime(int days = 0, int months = 0, int years = 0) {
            Day += days;
            Month += months;
            Year += years;

            while (Day > daysInMonth) {

                Day -= daysInMonth;
                Month++;
            }
            
            while (Month > 12) {
                Month -= 12;
                Year++;
            }
        }
    }
}