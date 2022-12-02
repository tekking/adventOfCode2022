using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day1
{
    internal class Day1 : BaseDay
    {
        protected override void SolvePart1(string[] input)
        {
            var sums = new List<int>();
            var currentSum = 0;
            foreach (var line in input)
            {
                if (line != string.Empty)
                {
                    currentSum += int.Parse(line);
                }
                else
                {
                    sums.Add(currentSum);
                    currentSum = 0;
                }
            }

            sums.Add(currentSum);

            Console.WriteLine(sums.Max());
        }

        protected override void SolvePart2(string[] input)
        {
            var sums = new List<int>();
            var currentSum = 0;
            foreach (var line in input)
            {
                if (line != string.Empty)
                {
                    currentSum += int.Parse(line);
                }
                else
                {
                    sums.Add(currentSum);
                    currentSum = 0;
                }
            }

            sums.Add(currentSum);
            var orderedSums = sums.OrderByDescending(s => s)
                                  .ToList();

            var topThree = 0;
            for (var i = 0; i < 3; i++)
            {
                topThree += orderedSums[i];
            }

            Console.WriteLine(topThree);
        }
    }
}