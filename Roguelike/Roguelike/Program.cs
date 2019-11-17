using System;

namespace Roguelike {
    internal class Program {
        public static void Main(string[] args) {
            Game game = new Game();
            Console.WriteLine("\nPress any key to exit ");
            
            Console.ReadKey();
        }
    }
}