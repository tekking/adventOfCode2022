using AdventOfCode2022.Common;

namespace AdventOfCode2022.Day7
{
    internal class Day7 : BaseDay
    {
        protected override void SolvePart1(string[] input)
        {
            var knownFolders = this.DetermineListOfFolders(input);
            Console.WriteLine(knownFolders.Where(f => f.Size <= 100000).Sum(f => f.Size));
        }

        protected override void SolvePart2(string[] input)
        {
            var knownFolders = this.DetermineListOfFolders(input);
            var totalSize = knownFolders.First(f => f.Name == "/").Size;
            Console.WriteLine(knownFolders.Where(f => f.Size >= totalSize - 40000000).Min(f => f.Size));
        }

        private List<Folder> DetermineListOfFolders(string[] input)
        {
            var root = new Folder("/");
            var currentFolder = root;
            var currentPath = new Stack<Folder>();

            var knownFolders = new List<Folder>
            {
                root
            };

            var index = 0;
            while (index < input.Length)
            {
                var line = input[index];

                if (line == "$ cd /")
                {
                    currentFolder = root;
                    currentPath = new Stack<Folder>();
                    index++;
                    continue;
                }

                if (line == "$ cd ..")
                {
                    currentFolder = currentPath.Pop();
                    index++;
                    continue;
                }

                if (line.StartsWith("$ cd"))
                {
                    var folderTarget = (Folder)currentFolder.Content.First(f => f.Name == line.Split(' ')[2]);
                    currentPath.Push(currentFolder);
                    currentFolder = folderTarget;
                    index++;
                    continue;
                }

                if (line == "$ ls")
                {
                    index++;
                    line = input[index];
                    while (!line.StartsWith("$"))
                    {
                        var name = line.Split(' ')[1];
                        if (currentFolder.Content.All(n => n.Name != name))
                        {
                            if (line.StartsWith("dir"))
                            {
                                var newFolder = new Folder(name);
                                knownFolders.Add(newFolder);
                                currentFolder.Content.Add(newFolder);
                            }
                            else
                            {
                                var size = int.Parse(line.Split(' ')[0]);
                                currentFolder.Content.Add(new File(name, size));
                            }
                        }

                        index++;

                        if (index > input.Length - 1)
                        {
                            break;
                        }

                        line = input[index];
                    }
                }
            }

            return knownFolders;
        }

        private abstract class Node
        {
            public Node(string name)
            {
                this.Name = name;
            }

            public string Name { get; set; }

            public abstract int Size { get; set; }
        }

        private class Folder : Node
        {
            public Folder(string name)
                : base(name)
            {
                this.Content = new List<Node>();
            }

            public List<Node> Content { get; set; }

            public override int Size
            {
                get
                {
                    return this.Content.Sum(n => n.Size);
                }
                set
                {
                }
            }
        }

        private class File : Node
        {
            public File(string name, int size)
                : base(name)
            {
                this.Size = size;
            }

            public override int Size { get; set; }
        }
    }
}