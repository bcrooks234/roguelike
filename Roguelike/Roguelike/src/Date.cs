using System;

namespace Roguelike {
    public class Date {
        public ushort Day;
        public ushort Month;
        public ushort Year;

        private ushort daysInMonth = 30;

        public Date(ushort day, ushort month, ushort year) {
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

        public void PassTime(ushort days = 0, ushort months = 0, ushort years = 0) {
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