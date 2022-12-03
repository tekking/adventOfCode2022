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
            this.SolvePart1(this.GetExampleInput());
        }

        public void ExecuteSecondPart()
        {
            this.SolvePart2(this.GetInput());
        }

        public void TestSecondPart()
        {
            this.SolvePart2(this.GetExampleInput());
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

        protected string[] GetExampleInput()
        {
            var type = this.GetType();
            var folder = type.Namespace!.Split('.')[^1];

            var file = $"{folder}/example.txt";
            return File.Exists(file) ? File.ReadAllLines(file) : Array.Empty<string>();
        }
    }
}