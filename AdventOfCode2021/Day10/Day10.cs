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
        
        public Day10()
            : base(10) { }
        
        public override void Run1()
        {
            var charScores = new Dictionary<char, int>
            {
                { ')', 3 },
                { ']', 57 },
                { '}', 1197 },
                { '>', 25137 },
            };
        
            var input = GetInputAsStringList(1);
            var errorChars = new List<char>();
            foreach (var row in input)
            {
                if (IsCorrupt(row, out var errorChar, out _))
                    errorChars.Add(errorChar);
            }

            var result = 0;
            foreach (var c in errorChars)
                result += charScores[c];
            
            Console.WriteLine("Answer is: " + result);
        }
        private bool IsCorrupt(string row, out char errorChar, out List<char> expectedEndChars)
        {
            expectedEndChars = new List<char>();
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

                errorChar = c;
                return true;
            }

            errorChar = default;
            return false;
        }
        public override void Run2()
        {
            var charScores = new Dictionary<char, int>
            {
                { ')', 1 },
                { ']', 2 },
                { '}', 3 },
                { '>', 4 },
            };
            var input = GetInputAsStringList(1);
            var scores = new List<long>();
            foreach (var row in input)
            {
                if (!IsCorrupt(row, out _, out var expectedEndChars))
                {
                    long score = 0;
                    for (var i = expectedEndChars.Count - 1; i >= 0; i--)
                    {
                        score *= 5;
                        score += charScores[expectedEndChars[i]];
                    }
                    scores.Add(score);
                }
            }
            scores.Sort();
            Console.WriteLine("Answer is: " + scores[scores.Count / 2]);
        }
    }
}