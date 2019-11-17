using System;

namespace Roguelike {
    public class Game {
        public Date Date;
        public Time Time;
        
        public Game() {
            
            Date = new Date(31, 12, 2019);    
            Time = new Time(hours: 6, minutes: 14, seconds: 19);
            
            Cave cave = new Cave(100, 100);
            cave.Generate();
            
            while (true) {
                Console.Clear();
                
                Date.Print();
                Console.Write("     ");
                Time.Print(true);

                ushort daysPassed = (ushort)Time.PassTime(hours: 1);
                Date.PassTime(days: daysPassed);

                Console.ReadKey();
            }
        }
    }
}