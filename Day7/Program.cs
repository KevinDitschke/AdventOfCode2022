namespace Day7;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(FindLargestDirectory("inputTest.txt"));
        Console.WriteLine(FindLargestDirectory("input.txt"));
    }

    private static int FindLargestDirectory(string fileName)
    {
        var commands = ReadFile(fileName);
        var sum = 0;
        var directories = new List<Directory>();
        
        foreach (var command in commands)
        {
            Directory directory = new Directory();
            switch (command)
            {
                case string s when s.StartsWith("$ cd .."):
                    directory = directories.Single(x => directory.Parent == x.Name);
                    break;
                case string s when s.StartsWith("dir"):
                    var dir = command.Remove(0, 4);
                    directory = directories.Any(x => x.Name == dir)
                        ? directories.Single(x => x.Name == dir)
                        : new Directory() { Name = dir, Parent = directory.Name };
                    directories.Add(directory);
                    break;
                case string s when char.IsNumber(s.First()):
                    var split = command.Split(' ');
                    var name = split.Last();
                    if (split.Last().Length > 1)
                    {
                        var size = int.Parse(split.First());
                        directory.Files.Add(new File(){Name = name, Size = size});
                    }
                    else
                    {
                        var newDirectory = new Directory()
                        {
                            Name = name,
                            Parent = directory.Name
                        };
                        directory.SubDirectories.Add(newDirectory);
                        directories.Add(newDirectory);
                    }
                    

                    break;
            }
                
        }

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
    public List<Directory>? SubDirectories { get; set; }
    public List<File>? Files { get; set; }
}

class File
{
    public string Name { get; set; }
    public int Size { get; set; }
}