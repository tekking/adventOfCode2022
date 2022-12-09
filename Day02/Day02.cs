using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day02
{
    internal class Day02 : BaseDay
    {
        protected override void SolvePart1(string[] input)
        {
            Console.WriteLine(
                input.Select(this.ScoreRoundPart1)
                     .Sum());
        }

        protected override void SolvePart2(string[] input)
        {
            Console.WriteLine(
                input.Select(this.ScoreRoundPart2)
                     .Sum());
        }

        private int ScoreRoundPart1(string round)
        {
            var theirHand = round.Split(' ')[0] switch
            {
                "A" => 0,
                "B" => 1,
                _ => 2
            };
            var yourHand = round.Split(' ')[1] switch
            {
                "X" => 0,
                "Y" => 1,
                _ => 2
            };

            var outcomeScore = ((yourHand - theirHand + 3) % 3) switch
            {
                0 => 3,
                1 => 6,
                _ => 0
            };

            return yourHand + 1 + outcomeScore;
        }

        private int ScoreRoundPart2(string round)
        {
            var theirHand = round.Split(' ')[0] switch
            {
                "A" => 0,
                "B" => 1,
                _ => 2
            };
            var yourHand = round.Split(' ')[1] switch
            {
                "X" => (theirHand + 2) % 3,
                "Y" => theirHand,
                _ => (theirHand + 1) % 3
            };

            var outcomeScore = ((yourHand - theirHand + 3) % 3) switch
            {
                0 => 3,
                1 => 6,
                _ => 0
            };

            return yourHand + 1 + outcomeScore;
        }
    }
}