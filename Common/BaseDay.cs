namespace AdventOfCode2022.Common
{
    public abstract class BaseDay
    {
        public void ExecutePart1()
        {
            this.SolvePart1(this.GetInput(), this.GetExampleInput());
        }

        public void ExecutePart2()
        {
            this.SolvePart2(this.GetInput(), this.GetExampleInput());
        }

        protected abstract void SolvePart1(string[] input, string[] example);

        protected abstract void SolvePart2(string[] input, string[] example);

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