using System;
using System.Linq;

namespace AdventOfCode2021.Day7
{
    public class Day7 : DayBase
    {
        public Day7()
            : base(7) { }
        
        public override void Run1()
        {
            var input = GetInputCommaSeparatedAsIntList(1);
            var leastFuel = int.MaxValue;

            for (int i = 0; i < input.Count; i++)
            {
                var fuel = 0;
                for (int j = 0; j < input.Count; j++)
                {
                    fuel += Math.Abs(input[i] - input[j]);
                }

                leastFuel = Math.Min(fuel, leastFuel);
            }
            Console.WriteLine("Answer is: " + leastFuel);
        }
        public override void Run2()
        {
            var input = GetInputCommaSeparatedAsIntList(1);
            var leastFuel = int.MaxValue;
            var maxDistance = input.Max();
            Console.WriteLine("max: " + maxDistance);
            for (int i = 0; i < maxDistance; i++)
            {
                var fuel = 0;
                for (int j = 0; j < input.Count; j++)
                {
                    var steps = Math.Abs(i - input[j]);
                    for (int k = 1; k <= steps; k++)
                    {
                        fuel += k;
                    }
                }

                leastFuel = Math.Min(fuel, leastFuel);
            }
            Console.WriteLine("Answer is: " + leastFuel);
        }
    }
}