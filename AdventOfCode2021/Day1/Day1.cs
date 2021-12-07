using System;

namespace AdventOfCode2021.Day1
{
    public class Day1 : DayBase
    {
        public Day1()
            : base(1)
        { }
        
        public override void Run1()
        {
            var input = GetInputAsIntList(1);
            var count = 0;
            for (var i = 1; i < input.Count; i++)
            {
                if (input[i] > input[i - 1])
                    count++;
            }
            Console.WriteLine("Answer is: " + count);
        }
        public override void Run2()
        {
            var input = GetInputAsIntList(1);
            var count = 0;
            var lastSum = -1; 
            for (var i = 2; i < input.Count; i++)
            {
                var newSum = input[i - 2] + input[i - 1] + input[i];
                if (lastSum >= 0 && newSum > lastSum)
                    count++;

                lastSum = newSum;
            }
            Console.WriteLine("Answer is: " + count);
        }
    }
}