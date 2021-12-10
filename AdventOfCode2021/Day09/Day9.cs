using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day09
{
    public class Day9 : DayBase
    {
        private PointComparer _pointComparer = new PointComparer();
        public Day9()
            : base(9) { }
        
        public override void Run1()
        {
            var map = GetInputAsInts();
            var lowPoints = GetLowPoints(map);
            var result = lowPoints.Sum(p => p.Value) + lowPoints.Count;
            Console.WriteLine("Answer is: " + result);
        }

        private int[,] GetInputAsInts()
        {
            var input = GetInputAsStringList(1);
            var ints = new int[input.Count, input[0].Length];
            for (int i = 0; i < input.Count; i++)
            {
                for (int j = 0; j < input[i].Length; j++)
                    ints[i, j] = int.Parse(input[i][j].ToString());
            }

            return ints;
        }
        private List<Point> GetLowPoints(int[,] map)
        {
            var lowPoints = new List<Point>();
            var width = map.GetLength(1);
            var height = map.GetLength(0);
            
            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    var value = map[row, col];
                    if (row - 1 >= 0 && map[row - 1, col] <= value)
                        continue;
                    if (row + 1 < height && map[row + 1, col] <= value)
                        continue;
                    if (col - 1 >= 0 && map[row, col - 1] <= value)
                        continue;
                    if (col + 1 < width && map[row, col + 1] <= value)
                        continue;
                    
                    lowPoints.Add(new Point(row, col, value));
                }   
            }

            return lowPoints;
        }
        public override void Run2()
        {
            var map = GetInputAsInts();
            var lowPoints = GetLowPoints(map);


            List<List<Point>> basins = new List<List<Point>>();
            foreach (var lowPoint in lowPoints)
            {
                List<Point> basin = new List<Point>();
                basin.Add(lowPoint);
                FindAdjacent(lowPoint, map, basin);
                basins.Add(basin);
            }

            var orderedBasins = basins.OrderByDescending(b => b.Count).ToArray();
            Console.WriteLine("Answer is: " + (orderedBasins[0].Count * orderedBasins[1].Count * orderedBasins[2].Count));
            
        }

        private void FindAdjacent(Point point, int[,] map, List<Point> basin)
        {
            var width = map.GetLength(1);
            var height = map.GetLength(0);

            if (point.Row - 1 >= 0 && map[point.Row - 1, point.Col] < 9)
                AddNewPointToList(point.Row - 1, point.Col, map, basin);
            if (point.Row + 1 < height && map[point.Row + 1, point.Col] < 9)
                AddNewPointToList(point.Row + 1, point.Col, map, basin);
            if (point.Col - 1 >= 0 && map[point.Row, point.Col - 1] < 9)
                AddNewPointToList(point.Row, point.Col - 1, map, basin);
            if (point.Col + 1 < width && map[point.Row, point.Col + 1] < 9)
                AddNewPointToList(point.Row, point.Col + 1, map, basin);
        }
        private void AddNewPointToList(int row, int col, int[,] map, List<Point> basin)
        {
            var newPoint = new Point(row, col, map[row, col]);
            if (!basin.Contains(newPoint, _pointComparer))
            {
                basin.Add(newPoint);
                FindAdjacent(newPoint, map, basin);
            }
        }

        private class Point
        {
            public int Row { get; }
            public int Col { get; }
            public int Value { get; }

            public Point(int row, int col, int value)
            {
                Row = row;
                Col = col;
                Value = value;
            }
        }
        
        private class PointComparer : IEqualityComparer<Point>
        {
            public bool Equals(Point x, Point y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Row == y.Row && x.Col == y.Col;
            }
            public int GetHashCode(Point obj)
            {
                return HashCode.Combine(obj.Row, obj.Col);
            }
        }
    }
}