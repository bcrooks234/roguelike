using System;

namespace Roguelike {
    public class Time {
        public ushort Hours;
        public ushort Milliseconds;
        public ushort Minutes;
        public ushort Seconds;

        public Time(ushort milliseconds = 0, ushort seconds = 0, ushort minutes = 0, ushort hours = 0) {
            if (milliseconds != 0) Milliseconds = milliseconds;
            if (seconds != 0) Seconds = seconds;
            if (minutes != 0) Minutes = minutes;
            if (hours != 0) Hours = hours;
        }

        public override string ToString() {
            return Hours + ":" + Minutes + ":" + Seconds + ":" + Milliseconds;
        }

        public string ToStringTwelveHour() {
            ushort hours = Hours;
            string prefix = "am";
            
            hours += 1;
            if (hours >= 12) { 
                if (hours != 24) prefix = "pm";
                if (hours > 12) hours -= 12;
            }

            return hours + ":" + Minutes + ":" + Seconds + ":" + Milliseconds + " " + prefix;
        }

        public void Print(bool twelveHour=false) {
            if (!twelveHour) Console.Write(ToString());
            else Console.Write(ToStringTwelveHour());
        }

        public int PassTime(ushort milliseconds = 0, ushort seconds = 0, ushort minutes = 0, ushort hours = 0) {
            Milliseconds += milliseconds;
            Seconds += seconds;
            Minutes += minutes;
            Hours += hours;

            return UpdateTime();
        }

        public int UpdateTime() {

            int daysPassed = 0;
            
            while (Milliseconds >= 1000) {
                Milliseconds -= 1000;
                Seconds++;
            }
            
            while (Seconds >= 60) {
                Seconds -= 60;
                Minutes++;
            }
            
            while (Minutes >= 60) {
                Minutes -= 60;
                Hours++;
            }
            
            while (Hours >= 24) {
                Hours -= 24;
                daysPassed++;
            }

            return daysPassed;
        }
    }
}