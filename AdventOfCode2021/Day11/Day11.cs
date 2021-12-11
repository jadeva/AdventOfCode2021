using System;
using System.Collections.Generic;
using AdventOfCode2021.Day09;

namespace AdventOfCode2021.Day11
{
    public class Day11 : DayBase
    {
        public Day11()
            : base(11) { }
        public override void Run1()
        {
            var map = GetInputAsInts();
            var width = map.GetLength(1);
            var height = map.GetLength(0);
            var blinks = 0;
            for (int i = 0; i < 100; i++)
                blinks += BlinkAll(map, width, height);
            
            Console.WriteLine("Answer is: " + blinks);
        }
        public override void Run2()
        {
            var map = GetInputAsInts();
            var width = map.GetLength(1);
            var height = map.GetLength(0);
            var blinks = 0;
            var rounds = 0;
            var totalBlinks = width * height;
            while (blinks < totalBlinks)
            {
                blinks = BlinkAll(map, width, height);
                rounds++;
            }
            
            Console.WriteLine("Answer is: " + rounds);
        }

        private int BlinkAll(int[,] map, int width, int height)
        {
            
            var blinks = 0;
            
            // Increse by one
            for (int r = 0; r < height; r++)
                for (int c = 0; c < width; c++)
                    map[r, c]++;
            
            // Blink everything
            for (int r = 0; r < height; r++)
                for (int c = 0; c < width; c++)
                    if (map[r, c] > 9)
                        Blink(map, width, height, r, c, ref blinks);

            // Reset all blinked to 0
            for (int r = 0; r < height; r++)
                for (int c = 0; c < width; c++)
                    if (map[r, c] < 0)
                        map[r, c] = 0;

            return blinks;
        }
        private void Blink(int[,] map, int width, int height, int row, int col, ref int blinks)
        {
            map[row, col] = int.MinValue;
            blinks++;
            for (int r = -1; r < 2; r++)
            {
                for (int c = -1; c < 2; c++)
                {
                    var curR = row + r;
                    var curC = col + c;
                    if (curR < 0 || curR >= height || curC < 0 || curC >= width)
                        continue;

                    if (curR == row && curC == col)
                        continue;
                    
                    map[curR, curC]++;
                    if (map[curR, curC] > 9)
                        Blink(map, width, height, curR, curC, ref blinks);
                }
            }
        }
        
        private int[,] GetInputAsInts()
        {
            var input = GetInputAsStringList(1);
            var ints = new int[input.Count, input[0].Length];

            for (int i = 0; i < input.Count; i++)
                for (int j = 0; j < input[i].Length; j++)
                    ints[i, j] = int.Parse(input[i][j].ToString());

            return ints;
        }
        
    }
}