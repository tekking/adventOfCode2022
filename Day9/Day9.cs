using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day9
{
    internal class Day9 : BaseDay
    {
        protected override void SolvePart1(string[] input)
        {
            var head = new Point();
            var tail = new Point();
            var tailLocations = new HashSet<Point>
            {
                tail
            };

            foreach (var line in input)
            {
                var move = this.ParseMove(line);
                for (var step = 0; step < move.count; step++)
                {
                    head += move.dir;
                    var changed = true;
                    while (changed)
                    {
                        var diff = head - tail;
                        changed = false;
                        if (diff.Length >= 2)
                        {
                            tail += diff.Normalized;
                            tailLocations.Add(tail);
                            changed = true;
                        }
                    }
                }
            }

            Console.WriteLine(tailLocations.Count);
        }

        protected override void SolvePart2(string[] input)
        {
            var head = new Point();
            var tails = new Point[9];
            var tailLocations = new HashSet<Point>
            {
                tails[8]
            };

            foreach (var line in input)
            {
                var move = this.ParseMove(line);
                for (var step = 0; step < move.count; step++)
                {
                    head += move.dir;

                    for (var i = 0; i < 9; i++)
                    {
                        var changed = true;
                        var goal = i == 0 ? head : tails[i - 1];
                        while (changed)
                        {
                            var diff = goal - tails[i];
                            changed = false;
                            if (diff.Length >= 2)
                            {
                                tails[i] += diff.Normalized;
                                changed = true;

                                if (i == 8)
                                {
                                    tailLocations.Add(tails[i]);
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine(tailLocations.Count);
        }

        private (Point dir, int count) ParseMove(string line)
        {
            var dist = int.Parse(line.Split(' ')[1]);
            var direction = line.Split(' ')[0] switch
            {
                "R" => new Point
                {
                    X = 1
                },
                "L" => new Point
                {
                    X = -1
                },
                "U" => new Point
                {
                    Y = 1
                },
                "D" => new Point
                {
                    Y = -1
                },
                _ => throw new ArgumentOutOfRangeException()
            };
            return (direction, dist);
        }

        private readonly record struct Point
        {
            public int X { get; init; }

            public int Y { get; init; }

            public static Point operator +(Point a, Point b)
            {
                return new Point
                {
                    X = a.X + b.X,
                    Y = a.Y + b.Y
                };
            }

            public static Point operator -(Point a, Point b)
            {
                return new Point
                {
                    X = a.X - b.X,
                    Y = a.Y - b.Y
                };
            }

            public double Length => Math.Sqrt(this.X * this.X + this.Y * this.Y);

            public Point Normalized =>
                new Point
                {
                    X = this.X == 0 ? 0 : this.X / Math.Abs(this.X),
                    Y = this.Y == 0 ? 0 : this.Y / Math.Abs(this.Y)
                };

            public override string ToString()
            {
                return $"({this.X},{this.Y})";
            }
        }
    }
}