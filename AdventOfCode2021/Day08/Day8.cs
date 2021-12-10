using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day08
{
    public class Day8 : DayBase
    {
        private static Dictionary<int, int> _knownChars = new Dictionary<int, int>()
            {
                { 2, 1 },
                { 4, 4 },
                { 3, 7 },
                { 7, 8 },
            };
        public Day8() 
            : base(8)
        { }

        public override void Run1()
        {
            
            
            var input = GetInputAsStringList(1);

            var counter = 0;
            foreach (var row in input)
            {
                var outputs = GetOutputs(row);
                foreach (var output in outputs)
                {
                    if (_knownChars.TryGetValue(output.Length, out _))
                        counter++;
                }
            }
            Console.WriteLine("Answer is: " + counter);
        }

        private string[] GetOutputs(string row)
        {
            return row.Split('|')[1].Trim().Split(' ');
        }
        private string[] GetInputs(string row)
        {
            return row.Split('|')[0].Trim().Split(' ');
        }

        public override void Run2()
        {
            var input = GetInputAsStringList(1);
            var result = 0;
            foreach (var row in input)
            {
                var inputs = GetInputs(row).ToList();
                var outputs = GetOutputs(row);

                var oneChars = inputs.First(s => s.Length == 2);
                var fourChars = inputs.First(s => s.Length == 4);
                var sevenChars = inputs.First(s => s.Length == 3);
                var eightChars = inputs.First(s => s.Length == 7);
                
                inputs.Remove(oneChars);
                inputs.Remove(fourChars);
                inputs.Remove(sevenChars);
                inputs.Remove(eightChars);

                // Find top
                var top = ExceptChars(sevenChars, oneChars);
                // Find bottom and bottom left
                var bottom = String.Empty;
                var bottomLeft = String.Empty;
                foreach (var i in inputs)
                {
                    if (bottomLeft.Length != 2)
                        bottomLeft = ExceptChars(i, fourChars + top);
                    if (bottom.Length != 1)
                        bottom = ExceptChars(i, fourChars + top);

                    if (bottom.Length == 1 && bottomLeft.Length == 2)
                    {
                        bottomLeft = ExceptChars(bottomLeft, bottom);
                        break;
                    }
                }
                // Find middle
                var middle = String.Empty;
                foreach (var i in inputs)
                {
                    middle = ExceptChars(i, sevenChars + bottom);
                    if (middle.Length == 1)
                        break;
                }
                // Find topLeft
                var topLeft = ExceptChars(eightChars, sevenChars + middle + bottom + bottomLeft); 
                // Find bottomRight
                var bottomRight = String.Empty;
                foreach (var i in inputs)
                {
                    var sixChars = top + topLeft + middle + bottomLeft + bottom;
                    if (sixChars.All(i.Contains))
                    {
                        bottomRight = ExceptChars(i, sixChars);
                        if (bottomRight.Length == 1)
                            break;
                    }
                }
                //Find topRight
                var topRight = ExceptChars(oneChars, bottomRight); 
                
                Console.WriteLine($"  {top}  ");
                Console.WriteLine($"{topLeft}   {topRight}");                
                Console.WriteLine($"  {middle}  ");
                Console.WriteLine($"{bottomLeft}   {bottomRight}");
                Console.WriteLine($"  {bottom}  ");
                
                
                var digitSegments = new[]
                {
                    top + topLeft + topRight + bottomLeft + bottomRight + bottom,
                    oneChars,
                    top + topRight + middle + bottomLeft + bottom,
                    top + topRight + middle + bottomRight + bottom,
                    fourChars,
                    top + topLeft + middle + bottomRight + bottom,
                    top + topLeft + middle + bottomLeft + bottomRight + bottom,
                    sevenChars,
                    eightChars,
                    top + topLeft + topRight + middle + bottomRight + bottom
                };

                
                var digits = String.Empty;
                foreach (var output in outputs)
                {
                    if (_knownChars.TryGetValue(output.Length, out var value))
                    {
                        digits += value;
                        continue;
                    }
                
                    for (var index = 0; index < digitSegments.Length; index++)
                    {
                        var segment = digitSegments[index];
                        if (output.Length == segment.Length && output.All(segment.Contains))
                        {
                            digits += index.ToString();
                            break;
                        }
                    }
                }
                Console.WriteLine("Digits: " + digits);
                result += int.Parse(digits);
            }
            Console.WriteLine("Answer is: " + result);
            
        }

        private string ExceptChars(string text, string except)
        {
            return new String(text.Except(except).ToArray());
        }
    }
}