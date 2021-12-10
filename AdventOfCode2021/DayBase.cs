using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021
{
    public abstract class DayBase
    {
        public int Day { get; }
        
        protected DayBase(int day)
        {
            Day = day;
            
        }
        protected StreamReader GetStreamReader(int testNumber)
        {
            return new StreamReader($"Day{Day:D2}\\Input{testNumber}.txt");
        }
        protected List<string> GetInputAsStringList(int testNumber)
        {
            var strings = new List<string>();
            using (var reader = GetStreamReader(testNumber))
            {
                while (!reader.EndOfStream)
                    strings.Add(reader.ReadLine());
            }
            return strings;
        }
        protected List<List<string>> GetInputAsStringListWithSplit(int testNumber)
        {
            var strings = new List<List<string>>();
            using (var reader = GetStreamReader(testNumber))
            {
                while (!reader.EndOfStream)
                    strings.Add(reader.ReadLine().Split(' ').ToList());
            }
            return strings;
        }
        protected List<int> GetInputAsIntList(int testNumber)
        {
            var ints = new List<int>();
            using (var reader = GetStreamReader(testNumber))
            {
                while (!reader.EndOfStream)
                    ints.Add(int.Parse(reader.ReadLine()));
            }
            return ints;
        }
        protected List<int> GetInputCommaSeparatedAsIntList(int testNumber)
        {
            var ints = new List<int>();
            var input = GetInputAsString(1);
            return input.Split(',').Select(int.Parse).ToList();
        }
        protected string GetInputAsString(int testNumber)
        {
            using var reader = GetStreamReader(testNumber);
            return reader.ReadToEnd();
        }
        public abstract void Run1();
        public abstract void Run2();
    }
} 