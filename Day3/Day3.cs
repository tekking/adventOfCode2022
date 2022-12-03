using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day3
{
    internal class Day3 : BaseDay
    {
        protected override void SolvePart1(string[] input)
        {
            Console.WriteLine(
                input.Select(this.GetOverlapLetterForRow)
                     .Select(this.GetPriority)
                     .Sum());
        }

        protected override void SolvePart2(string[] input)
        {
            Console.WriteLine(
                input.Chunk(3)
                     .Select(this.GetOverlapForSet)
                     .Select(this.GetPriority)
                     .Sum());
        }

        private char GetOverlapLetterForRow(string row)
        {
            return row[..(row.Length / 2)]
                   .Intersect(row[(row.Length / 2)..])
                   .First();
        }

        private char GetOverlapForSet(string[] set)
        {
            return set[0]
                   .Intersect(set[1])
                   .Intersect(set[2])
                   .First();
        }

        private int GetPriority(char c)
        {
            switch (c)
            {
                case <= 'Z' and >= 'A':
                    return ((int)c) - 38;

                case <= 'z' and >= 'a':
                    return ((int)c) - 96;

                default:
                    throw new ArgumentException();
            }
        }
    }
}