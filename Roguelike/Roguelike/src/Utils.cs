namespace Roguelike {
    public static class Utils {
        public static int[,] CellularAutomata(int[,] values, int width, int height) {
            int[,] newValues = values;

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    bool solid = values[x, y] == 1;
                    int count = 0;
                    
                    if (x != 0) count += values[x - 1, y];
                    if (y != 0) count += values[x, y - 1];
                    if (x != width - 1) count += values[x + 1, y];
                    if (y != height - 1) count += values[x, y + 1];

                    if (solid) {
                        if (count < 2) {
                            newValues[x, y] = 0;
                        }
                    }
                    else if (count > 2) {
                        newValues[x, y] = 1;
                    }


                }
            }

            return newValues;
        }
    }
}