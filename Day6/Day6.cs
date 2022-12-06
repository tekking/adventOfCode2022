using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day6
{
    internal class Day6 : BaseDay
    {
        protected override void SolvePart1(string[] input)
        {
            foreach (var code in input)
            {
                Console.WriteLine(
                    code.Select(
                            (_, index) => (index, code[index..(index + 4)]
                                               .ToHashSet()))
                        .First(h => h.Item2.Count == 4)
                        .index
                    + 4);
            }
        }

        protected override void SolvePart2(string[] input)
        {
            foreach (var code in input)
            {
                Console.WriteLine(
                    code.Select(
                            (_, index) => (index, code[index..(index + 14)]
                                               .ToHashSet()))
                        .First(h => h.Item2.Count == 14)
                        .index
                    + 14);
            }
        }
    }
}