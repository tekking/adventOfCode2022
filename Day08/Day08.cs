using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day08
{
    internal class Day08 : BaseDay
    {
        protected override void SolvePart1(string[] input)
        {
            var height = input.Length;
            var width = input[0]
                .Length;
            var forest = new int[height, width];
            var obscuringHeight = new int[height, width];

            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    forest[i, j] = int.Parse(
                        input[i][j]
                            .ToString());
                    obscuringHeight[i, j] = i == 0 || j == 0 || i == height - 1 || j == width - 1 ? -1 : 10;
                }
            }

            // bleh
            for (var i = 0; i < height; i++)
            {
                var maxHeightSoFar = 0;
                for (var j = 0; j < width; j++)
                {
                    obscuringHeight[i, j] = Math.Min(maxHeightSoFar, obscuringHeight[i, j]);
                    maxHeightSoFar = Math.Max(maxHeightSoFar, forest[i, j]);
                }
            }

            for (var i = 0; i < height; i++)
            {
                var maxHeightSoFar = 0;
                for (var j = width - 1; j >= 0; j--)
                {
                    obscuringHeight[i, j] = Math.Min(maxHeightSoFar, obscuringHeight[i, j]);
                    maxHeightSoFar = Math.Max(maxHeightSoFar, forest[i, j]);
                }
            }

            for (var j = 0; j < width; j++)
            {
                var maxHeightSoFar = 0;
                for (var i = 0; i < height; i++)
                {
                    obscuringHeight[i, j] = Math.Min(maxHeightSoFar, obscuringHeight[i, j]);
                    maxHeightSoFar = Math.Max(maxHeightSoFar, forest[i, j]);
                }
            }

            for (var j = 0; j < width; j++)
            {
                var maxHeightSoFar = 0;
                for (var i = height - 1; i >= 0; i--)
                {
                    obscuringHeight[i, j] = Math.Min(maxHeightSoFar, obscuringHeight[i, j]);
                    maxHeightSoFar = Math.Max(maxHeightSoFar, forest[i, j]);
                }
            }

            var visibleCount = 0;
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    if (forest[i, j] > obscuringHeight[i, j])
                    {
                        visibleCount++;
                    }
                }
            }

            Console.WriteLine(visibleCount);
        }

        protected override void SolvePart2(string[] input)
        {
            var height = input.Length;
            var width = input[0]
                .Length;
            var forest = new int[height, width];

            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    forest[i, j] = int.Parse(
                        input[i][j]
                            .ToString());
                }
            }

            // more bleh
            var scenicScores = new int[height, width];
            var directions = new[]
            {
                (1, 0), (0, 1), (-1, 0), (0, -1)
            };
            var bestScore = 0;
            for (var i = 0; i < height; i++)
            {
                for (var j = 0; j < width; j++)
                {
                    var score = 1;
                    foreach (var direction in directions)
                    {
                        var dist = 0;
                        while (true)
                        {
                            var target = (x: i + direction.Item1 * (dist + 1), y: j + direction.Item2 * (dist + 1));
                            if (target.x < 0
                                || target.x >= height
                                || target.y < 0
                                || target.y >= width)
                            {
                                break;
                            }

                            if (forest[target.x, target.y] >= forest[i, j])
                            {
                                dist++;
                                break;
                            }

                            dist++;
                        }

                        score *= dist;
                    }

                    scenicScores[i, j] = score;
                    bestScore = Math.Max(bestScore, score);
                }
            }

            Console.WriteLine(bestScore);
        }
    }
}