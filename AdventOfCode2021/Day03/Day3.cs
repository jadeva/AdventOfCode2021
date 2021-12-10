using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Day03
{
    public class Day3 : DayBase
    {
        public Day3()
            : base(3) { }
        
        public override void Run1()
        {
            var input = GetInputAsStringList(1);
            var value = 1;
            var gamma = 0;
            for (var i = input[0].Length - 1; i >= 0; i--)
            {
                var count = 0;
                foreach (var data in input)
                    if (data[i] == '1')
                        count++;

                if (count > input.Count / 2)
                    gamma += value;
                
                value *= 2;
            }

            int epsilon = gamma;
            for (int i = 0; i < input[0].Length; i++)
                epsilon ^= (1 << i);

            Console.WriteLine("Answer is: " + (gamma * epsilon));
        }
        public override void Run2()
        {
            var input = GetInputAsStringList(1);

            var oxygen = GetRating(input, true);
            var co2 = GetRating(input, false);
            Console.WriteLine("Ox: " + oxygen);
            Console.WriteLine("CO: " + co2);
            
            Console.WriteLine("Answer is: " + (oxygen * co2));
        }
        
        private int GetRating(List<string> inp, bool mostCommon)
        {
            var input = new List<string>(inp);
            for (var i = 0; i < input[0].Length; i++)
            {
                var count = 0;
                foreach (var data in input)
                    if (data[i] == '1')
                        count++;

                char keep;
                var inputCountHalf = input.Count / 2.0;
                if (count == inputCountHalf)
                {
                    keep = mostCommon ? '1' : '0';
                }
                else
                {
                    if (mostCommon)
                    {
                        keep = count > inputCountHalf ? '1' : '0';
                    }
                    else
                    {
                        keep = count > inputCountHalf ? '0' : '1';
                    }
                }
                
                input.RemoveAll(x => x[i] != keep);
                
                if (input.Count == 1)
                {
                    var value = 1;
                    var sum = 0;
                    for (var j = input[0].Length - 1; j >= 0; j--)
                    {
                        if (input[0][j] == '1')
                            sum += value;
                        
                        value *= 2;
                    }

                    return sum;
                }
            }

            return 0;
        }
    }
}