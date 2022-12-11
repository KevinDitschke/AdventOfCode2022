namespace Day7;

public class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine(GetTotalSize("inputTest.txt"));
        Console.WriteLine(GetTotalSize("input.txt"));
    }

    public static int GetTotalSize(string fileName)
    {
        var commands = ReadFile(fileName);
        var folder = new Folder("/", null);
        folder.SetCurrentFolder(folder);
        int i = 0;
        foreach (var command in commands)
        {
            i++;
            switch (command)
            {
                case "$ cd /":
                    folder.CurrentFolder.MoveToTopLevel();
                    continue;
                case string s when s.StartsWith("$ cd .."):
                    folder.CurrentFolder = folder.CurrentFolder.MoveOneUp();
                    continue;
                case string s when s.StartsWith("$ cd"):
                    var dir = command.Split(' ').Last();
                    folder.SetCurrentFolder(folder.CurrentFolder.SubFolders.Single(x => x.Name == dir));
                    continue;
                case string s when s.StartsWith("dir"):
                    var directoryName = command.Remove(0, 4);
                    folder.CurrentFolder.AddFolder(directoryName, folder.CurrentFolder);
                    continue;
                case string s when char.IsNumber(s.First()):
                    var size = int.Parse(command.Split(' ').First());
                    folder.CurrentFolder.Size += size;
                    continue;
            }
        }
        Console.WriteLine("RootSize: " + folder.Size);
        return GetFolderSizes(folder, 0);
    }

    private static int GetFolderSizes(Folder folder, int total)
    {
        if (folder.Size <= 100000)
        {
            if(folder.Size != 0)
                Console.WriteLine($"{folder.Name} - {folder.Size}");
            total += folder.Size;
        }
        foreach (var subfolder in folder.SubFolders)
        {
            total = GetFolderSizes(subfolder, total);
        }
        return total;
    }

    private static string[] ReadFile(string fileName)
    {
        return File.ReadAllLines(fileName);
    }
}