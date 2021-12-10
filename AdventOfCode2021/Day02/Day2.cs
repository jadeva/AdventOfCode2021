using System;

namespace AdventOfCode2021.Day02
{
    public class Day2 : DayBase
    {
        public Day2()
            : base(2) { }
        
        public override void Run1()
        {
            var horizontal = 0;
            var depth = 0;

            var input = GetInputAsStringListWithSplit(1);
            foreach (var measure in input)
            {
                if (measure[0] == "forward")
                    horizontal += int.Parse(measure[1]);
                else if (measure[0] == "up")
                    depth -= int.Parse(measure[1]);
                else if (measure[0] == "down")
                    depth += int.Parse(measure[1]);
            }
            
            Console.WriteLine("Answer is: " + (horizontal * depth));
        }
        public override void Run2()
        {
            var horizontal = 0;
            var depth = 0;
            var aim = 0;

            var input = GetInputAsStringListWithSplit(1);
            foreach (var measure in input)
            {
                if (measure[0] == "forward")
                {
                    var value = int.Parse(measure[1]);
                    horizontal += value;
                    depth += aim * value;
                }
                else if (measure[0] == "up")
                {
                    aim -= int.Parse(measure[1]);
                }
                else if (measure[0] == "down")
                {
                    aim += int.Parse(measure[1]);
                }
            }
            
            Console.WriteLine("Answer is: " + (horizontal * depth));
        }
    }
}