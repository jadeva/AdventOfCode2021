using System;
using System.Collections.Generic;

namespace AdventOfCode2021.Day06
{
    public class Day6 : DayBase
    {
        public Day6()
            : base(6) { }
        
        public override void Run1()
        {
            var input = GetInputCommaSeparatedAsIntList(1);
            Console.WriteLine("Answer is: " + GetFishAfterDays(input, 80));
        }
        private static ulong GetFishAfterDays(List<int> input, int days)
        {
            var dayArr = new ulong[10];
            foreach (var i in input)
                dayArr[i]++;
            
            for (int i = 0; i < days; i++)
            {
                dayArr[9] += dayArr[0]; // Create new
                dayArr[7] += dayArr[0]; // Reset days
                for (int j = 1; j < dayArr.Length; j++)
                    dayArr[j - 1] = dayArr[j];

                dayArr[9] = 0;
            }

            ulong result = 0;
            foreach (var d in dayArr)
                result += d;

            return result;
        }

        public override void Run2()
        {
            var input = GetInputCommaSeparatedAsIntList(1);
            Console.WriteLine("Answer is: " + GetFishAfterDays(input, 256));
        }
    }
}