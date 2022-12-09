using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day05
{
    internal class Day05 : BaseDay
    {
        protected override void SolvePart1(string[] input)
        {
            var start = this.ParseStart(input);
            var end = this.ExecuteMoves(input, start);
            foreach (var stack in end)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }

        protected override void SolvePart2(string[] input)
        {
            var start = this.ParseStart(input);
            var end = this.ExecuteMovesPart2(input, start);
            foreach (var stack in end)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }

        private Stack<char>[] ParseStart(string[] input)
        {
            var stackCount = (input[0]
                                  .Length
                              + 1)
                             / 4;
            var stacks = new Stack<char>[stackCount];
            for (var i = 0; i < stackCount; i++)
            {
                stacks[i] = new Stack<char>();
            }

            var stackLines = input.Where(l => l.StartsWith('[') || l.StartsWith("  "))
                                  .Reverse();
            foreach (var stackLine in stackLines)
            {
                for (var i = 0; i < stackCount; i++)
                {
                    if (stackLine[i * 4 + 1] != ' ')
                    {
                        stacks[i]
                            .Push(stackLine[i * 4 + 1]);
                    }
                }
            }

            return stacks;
        }

        private Stack<char>[] ExecuteMoves(string[] input, Stack<char>[] state)
        {
            foreach (var move in input.Where(i => i.StartsWith('m')))
            {
                var split = move.Split(' ');
                var count = int.Parse(split[1]);
                var from = int.Parse(split[3]);
                var to = int.Parse(split[5]);

                for (var i = 0; i < count; i++)
                {
                    state[to - 1]
                        .Push(
                            state[from - 1]
                                .Pop());
                }
            }

            return state;
        }

        private Stack<char>[] ExecuteMovesPart2(string[] input, Stack<char>[] state)
        {
            foreach (var move in input.Where(i => i.StartsWith('m')))
            {
                var split = move.Split(' ');
                var count = int.Parse(split[1]);
                var from = int.Parse(split[3]);
                var to = int.Parse(split[5]);

                var moveStack = new Stack<char>();
                for (var i = 0; i < count; i++)
                {
                    moveStack.Push(
                        state[from - 1]
                            .Pop());
                }

                for (var i = 0; i < count; i++)
                {
                    state[to - 1]
                        .Push(moveStack.Pop());
                }
            }

            return state;
        }
    }
}