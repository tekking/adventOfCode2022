namespace AdventOfCode2022.Common
{
    public abstract class BaseDay
    {
        public void ExecutePart1()
        {
            this.SolvePart1(this.GetInput());
        }

        public void ExecutePart2()
        {
            this.SolvePart2(this.GetInput());
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
    }
}