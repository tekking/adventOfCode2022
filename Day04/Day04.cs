using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day04
{
    internal class Day04 : BaseDay
    {
        protected override void SolvePart1(string[] input)
        {
            Console.WriteLine(input.Where(this.FullOverlap).Count());
        }

        protected override void SolvePart2(string[] input)
        {
            Console.WriteLine(input.Where(this.Overlap).Count());
        }

        private bool FullOverlap(string line)
        {
            var splitLine = line.Split('-', ',')
                                .Select(int.Parse)
                                .ToList();
            var firstRange = (splitLine[0], splitLine[1]);
            var secondRange = (splitLine[2], splitLine[3]);

            if (firstRange.Item1 == secondRange.Item1)
            {
                return true;
            }

            if (firstRange.Item1 < secondRange.Item1)
            {
                return firstRange.Item2 >= secondRange.Item2;
            }

            return firstRange.Item2 <= secondRange.Item2;
        }

        private bool Overlap(string line)
        {
            var splitLine = line.Split('-', ',')
                                .Select(int.Parse)
                                .ToList();
            var firstRange = (splitLine[0], splitLine[1]);
            var secondRange = (splitLine[2], splitLine[3]);

            var maxRange = Math.Max(firstRange.Item2, secondRange.Item2) - Math.Min(firstRange.Item1, secondRange.Item1);
            var sumOfRanges = (firstRange.Item2 - firstRange.Item1) + (secondRange.Item2 - secondRange.Item1);

            return maxRange <= sumOfRanges;
        }
    }
}