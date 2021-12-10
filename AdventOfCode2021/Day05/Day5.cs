using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day05
{
    public class Day5 : DayBase
    {
        public Day5()
            : base(5) { }
        
        public override void Run1()
        {
            var input = GetInputAsStringList(1);
            var lines = new List<Line>();
            foreach (var i in input)
            {
                var line = new Line(i);
                if (!line.IsDiagonal)
                    lines.Add(line);
            }

            CountDangerousAreas(lines);
        }
        private static void CountDangerousAreas(List<Line> lines)
        {
            var points = new Dictionary<Point, int>(new PointComparer());
            foreach (var line in lines)
            {
                var xDir = line.From.X > line.To.X ? -1 : 1;
                if (line.IsVertical)
                    xDir = 0;
                var yDir = line.From.Y > line.To.Y ? -1 : 1;
                if (line.IsHorizontal)
                    yDir = 0;
                    
                for (int i = 0; i <= line.Length; i++)
                {
                    var curPoint = new Point(line.From.X + i * xDir, line.From.Y + i * yDir);
                    if (points.ContainsKey(curPoint))
                        points[curPoint]++;
                    else
                        points[curPoint] = 1;                            
                }
            }

            var dangerousAreas = points.Values.Count(i => i > 1);
            Console.WriteLine("Answer is: " + dangerousAreas);
        }
        public override void Run2()
        {
            var lines = GetInputAsStringList(1).Select(s => new Line(s)).ToList(); 
            CountDangerousAreas(lines);
        }

        private class Point
        {
            public int X { get; }
            public int Y { get; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
        private class Line
        {
            public Point From { get;} 
            public Point To { get;}
            public bool IsDiagonal => From.X != To.X && From.Y != To.Y;
            public bool IsVertical => From.X == To.X;
            public bool IsHorizontal => From.Y == To.Y;
            public int Length { get; }

            public Line(string input)
            {
                var parts = input.Split(" -> ");
                var from = parts[0].Split(',');
                var to = parts[1].Split(',');
                From = new Point(int.Parse(from[0]), int.Parse(from[1]));
                To = new Point(int.Parse(to[0]), int.Parse(to[1]));
                if (IsHorizontal)
                    Length = Math.Abs(From.X - To.X);
                else
                    Length = Math.Abs(From.Y - To.Y);
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
                return x.X == y.X && x.Y == y.Y;
            }
            public int GetHashCode(Point obj)
            {
                return HashCode.Combine(obj.X, obj.Y);
            }
        }
    }
}