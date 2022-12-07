namespace Day7;

internal class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine(FindLargestDirectory("inputTest.txt"));
        Console.WriteLine(FindLargestDirectory("input.txt"));
    }

    private static int FindLargestDirectory(string fileName)
    {
        var commands = ReadFile(fileName);
        var sum = 0;
        var directories = new List<Directory>();
        var directory = new Directory()
            { Name = "/", Parent = null, SubDirectories = new List<Directory>(), Files = new List<File>() };
        directories.Add(directory);
        foreach (var command in commands)
        {
            switch (command)
            {
                case "$ cd /":
                    directory = directories.Single(x => x.Name == "/");
                    continue;
                case string s when s.StartsWith("$ cd .."):
                    directory = directories.Single(x => directory.Parent == x.Name);
                    continue;
                case string s when s.StartsWith("$ cd"):
                    directory = directories.Single(x => x.Name == command.Split(' ').Last());
                    continue;
                case string s when s.StartsWith("dir"):
                    var directoryName = command.Remove(0, 4);
                    var dir = directories.Any(x => x.Name == directoryName)
                        ? directories.Single(x => x.Name == directoryName)
                        : new Directory()
                        {
                            Name = directoryName, Parent = directory.Name, Files = new List<File>(),
                            SubDirectories = new List<Directory>()
                        };
                    if (directories.All(x => x.Name != directoryName))
                        directories.Add(dir);
                    continue;
                case string s when char.IsNumber(s.First()):
                    var split = command.Split(' ');
                    var name = split.Last();
                    var size = int.Parse(split.First());
                    directory.Files.Add(new File() { Name = name, Size = size });
                    continue;
            }
        }
        
        directories.ForEach(x => sum += x.Files.Where(y => y.Size <= 100000).Sum(z => z.Size));

        return sum;
    }

    private static string[] ReadFile(string fileName)
    {
        return System.IO.File.ReadAllLines(fileName);
    }
}

class Directory
{
    public string? Name { get; set; }
    public string? Parent { get; set; }
    public List<Directory> SubDirectories { get; set; }
    public List<File> Files { get; set; }
}

class File
{
    public string Name { get; set; }
    public int Size { get; set; }
}