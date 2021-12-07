using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day4
{
    public class Day4 : DayBase
    {
        public Day4()
            : base(4) { }
        
        public override void Run1()
        {
            var input = GetInputAsStringList(1);
            var numbers = input[0].Split(',').Select(int.Parse);
            var subsystems = ParseSubsystems(input);

            // Check any winners
            var drawnNumbers = new List<int>();
            foreach (var num in numbers)
            {
                drawnNumbers.Add(num);
                foreach (var sub in subsystems)
                {
                    if (CheckSub(drawnNumbers, sub, num))
                    {
                        PrintWinnerScore(drawnNumbers, sub, num);
                        return;
                    }
                }
            }
        }

        private List<int[,]> ParseSubsystems(List<string> input)
        {
            var subsystems = new List<int[,]>();

            // Parse bingo's
            var subsystem = new int[5,5];
            var row = 0;
            for (int i = 2; i < input.Count; i++)
            {
                if (String.IsNullOrWhiteSpace(input[i]))
                {
                    subsystems.Add(subsystem);
                    subsystem = new int[5,5];
                    row = 0;
                }
                else
                {
                    for (int j = 0; j < 5; j++)
                    {
                        subsystem[row, j] = int.Parse(input[i].Substring(j * 3, 2).Trim());
                    }
                    row++;
                }
            }
            subsystems.Add(subsystem);
            return subsystems;
        }
        private bool CheckSub(List<int> drawnNumbers, int[,] subsystem, int newNumber)
        {
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (subsystem[r, c] == newNumber)
                    {
                        if (CheckWinner(drawnNumbers, subsystem, r, c))
                            return true;
                    }
                }
            }
            return false;
        }
        private bool CheckWinner(List<int> drawnNumbers, int[,] subsystem, int row, int col)
        {
            bool rowFailed = false;
            bool colFailed = false;
            for (int i = 0; i < 5; i++)
            {
                if (!rowFailed && !drawnNumbers.Contains(subsystem[row, i]))
                    rowFailed = true;
                if (!colFailed && !drawnNumbers.Contains(subsystem[i, col]))
                    colFailed = true;
            }
            return !(rowFailed && colFailed);
        }
        private void PrintWinnerScore(List<int> drawnNumbers, int[,] subsystem, int winningNumber)
        {
            var sum = 0;
            for (int r = 0; r < 5; r++)
            {
                for (int c = 0; c < 5; c++)
                {
                    if (!drawnNumbers.Contains(subsystem[r, c]))
                    {
                        sum += subsystem[r, c];
                    }
                }
            }
            Console.WriteLine("Answer is: " + sum * winningNumber);
        }
        
        
        public override void Run2()
        {
            var input = GetInputAsStringList(1);
            var numbers = input[0].Split(',').Select(int.Parse);
            var subsystems = ParseSubsystems(input);
            var deletedSubsystems = new List<Tuple<int[,], int>>();

            // Check any winners
            var drawnNumbers = new List<int>();
            foreach (var num in numbers)
            {
                if (deletedSubsystems.Count == subsystems.Count)
                    break;

                drawnNumbers.Add(num);
                foreach (var sub in subsystems)
                {
                    if (deletedSubsystems.Any(s => s.Item1 == sub))
                        continue;
                    if (CheckSub(drawnNumbers, sub, num))
                        deletedSubsystems.Add(new Tuple<int[,], int>(sub, num));
                }
            }
            PrintWinnerScore(drawnNumbers, deletedSubsystems[^1].Item1, deletedSubsystems[^1].Item2);
        }
    }
}