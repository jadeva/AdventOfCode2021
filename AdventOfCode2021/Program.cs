using System;
using System.Collections.Generic;
using AdventOfCode2021.Day01;
using AdventOfCode2021.Day02;
using AdventOfCode2021.Day03;
using AdventOfCode2021.Day04;
using AdventOfCode2021.Day05;
using AdventOfCode2021.Day06;
using AdventOfCode2021.Day07;
using AdventOfCode2021.Day08;
using AdventOfCode2021.Day09;

namespace AdventOfCode2021
{
    class Program
    {
        private static Dictionary<int, DayBase> _days = new Dictionary<int, DayBase>
        {
            { 1, new Day1() },
            { 2, new Day2() },
            { 3, new Day3() },
            { 4, new Day4() },
            { 5, new Day5() },
            { 6, new Day6() },
            { 7, new Day7() },
            { 8, new Day8() },
            { 9, new Day9() },
            { 10, new Day10.Day10() },
            { 11, new Day11.Day11() },
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Select day of december to run:");
            var day = int.Parse(Console.ReadLine());

            if (_days.TryGetValue(day, out var program))
            {
                Console.WriteLine("Select first or second test to run (1/2):");
                var test = int.Parse(Console.ReadLine());
                if (test == 1)
                    program.Run1();
                else if (test == 2)
                    program.Run2();
                else
                    Console.WriteLine($"Test {test} not available.");    
            } 
            else
                Console.WriteLine($"No solution found for {day} december.");

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}