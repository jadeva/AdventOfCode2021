using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day9
{
    public class Day9 : DayBase
    {
        public Day9()
            : base(9) { }
        
        public override void Run1()
        {
            var map = GetInputAsInts();
            var lowPoints = new List<int>();
            var width = map.GetLength(1);
            var height = map.GetLength(0);
            
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    var value = map[row, col];
                    if (row - 1 >= 0 && map[row - 1, col] <= value)
                        continue;
                    if (row + 1 < height && map[row + 1, col] <= value)
                        continue;
                    if (col - 1 >= 0 && map[row, col - 1] <= value)
                        continue;
                    if (col + 1 < width && map[row, col + 1] <= value)
                        continue;
                    
                    lowPoints.Add(value);
                }   
            }
            var result = lowPoints.Sum() + lowPoints.Count;
            Console.WriteLine("Answer is: " + result);
        }

        private int[,] GetInputAsInts()
        {
            var input = GetInputAsStringList(1);
            var ints = new int[input.Count, input[0].Length];
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                    ints[i, j] = int.Parse(input[i][j].ToString());
            }

            return ints;
        }
        public override void Run2()
        {
        }
    }
}