namespace AdventOfCode2022.Common
{
    public abstract class BaseDay
    {
        public void ExecuteFirstPart()
        {
            this.SolvePart1(this.GetInput());
        }

        public void TestFirstPart()
        {
            foreach (var exampleInput in this.GetExampleInputs())
            {
                this.SolvePart1(exampleInput);
            }
        }

        public void ExecuteSecondPart()
        {
            this.SolvePart2(this.GetInput());
        }

        public void TestSecondPart()
        {
            foreach (var exampleInput in this.GetExampleInputs())
            {
                this.SolvePart2(exampleInput);
            }
        }

        protected abstract void SolvePart1(string[] input);

        protected abstract void SolvePart2(string[] input);

        protected string[] GetInput()
        {
            var type = this.GetType();
            var folder = type.Namespace!.Split('.')[^1];

            var file = $"{folder}/input.txt";
            return File.ReadAllLines(file);
        }

        protected string[][] GetExampleInputs()
        {
            var type = this.GetType();
            var folder = type.Namespace!.Split('.')[^1];

            var files = Directory.GetFiles($"{folder}")
                                 .Where(p => p.StartsWith($"{folder}\\example")).Order();
            return files.Select(f => File.ReadAllLines(f))
                        .ToArray();
        }
    }
}