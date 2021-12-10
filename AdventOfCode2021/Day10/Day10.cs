using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day10
{
    public class Day10 : DayBase
    {
        private Dictionary<char, char> _pairs = new Dictionary<char, char>
        {
            { '(', ')' },
            { '[', ']' },
            { '{', '}' },
            { '<', '>' },
        };
        private Dictionary<char, int> _scores = new Dictionary<char, int>
        {
            { ')', 3 },
            { ']', 57 },
            { '}', 1197 },
            { '>', 25137 },
        };

        public Day10()
            : base(10) { }
        
        public override void Run1()
        {
            var input = GetInputAsStringList(1);
            var errorChars = new List<char>();
            foreach (var row in input)
            {
                var expectedEndChars = new List<char>();
                foreach (var c in row)
                {
                    if (_pairs.Keys.Contains(c))
                    {
                        expectedEndChars.Add(_pairs[c]);
                        continue;
                    }

                    if (expectedEndChars.Last() == c)
                    {
                        expectedEndChars.RemoveAt(expectedEndChars.Count - 1);
                        continue;
                    }
                    errorChars.Add(c);
                    break;
                }
            }

            var result = 0;
            foreach (var c in errorChars)
                result += _scores[c];
            
            Console.WriteLine("Answer is: " + result);
        }
        public override void Run2()
        {
            
        }
    }
}