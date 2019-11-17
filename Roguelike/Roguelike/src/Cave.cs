using System;
using System.IO;

namespace Roguelike {
    public class Cave {
        private int[,] _caveValues;
        private readonly int _width;
        private readonly int _height;
        
        const int SmoothingIterations = 3;


        public Cave(int width, int height) {

            _caveValues = new int[width, height];
            _width = width;
            _height = height;

        }

        public void Generate() {
            Random random = new Random();
            
            // Create the rough random cave map
            for (int y = 0; y < _height; y++) {
                for (int x = 0; x < _width; x++) {
                    _caveValues[x, y] = random.Next() % 2;

                    if (x == 0 || x == _width - 1) _caveValues[x, y] = 1;
                    if (y == 0 || y == _height - 1) _caveValues[x, y] = 1;
                }
            }
            
            SaveCave(0);
            
            // Smooth the first cave map through cellular automata iterations  
            for (int i = 0; i < SmoothingIterations; i++) {
                _caveValues =
                    Utils.CellularAutomata(_caveValues, _width, _height); 
                SaveCave(1+i);
            }


            //TODO: Make sure entire map is connected

        }

        public void SaveCave(int v) {

            string[] rows = new string[_height];
            for (int y = 0; y < _height; y++) {
                string row = "";
                for (int x = 0; x < _width; x++) {
                    row += _caveValues[x, y];
                }

                rows[y] = row;
            }
            
            System.IO.File.WriteAllLines(@"C:\cave" + v + ".txt", rows);
        }

        public string[] LoadCave() {
            return System.IO.File.ReadAllLines(@"C:\cave.txt");
        }
    }
}