using System.Text;

namespace Day5;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(StackSupplies("inputTest.txt"));
        Console.WriteLine(StackSupplies("input.txt"));
    }

    private static string StackSupplies(string fileName)
    {
        var stacks = GetStacksFromList(fileName);
        var movements = GetMovementFromList(fileName);
        
        foreach (var movement in movements)
        {
            for (int i = movement[0]; i > 0; i--)
            {
                Console.WriteLine($"move {movement[0]} from {movement[1]} to {movement[2]}");
                var pop = stacks[movement[1]-1].Pop();
                
                stacks[movement[2]-1].Push(pop);
            }
        }

        var sb = new StringBuilder();
        foreach (var stack in stacks.Where(stack => stack.TryPeek(out _)))
        {
            sb.Append(stack.Peek());
        }
        return sb.ToString();
    }

    private static IEnumerable<int[]> GetMovementFromList(string fileName)
    {
        var lines = ReadFile(fileName);
        var numbers = new List<int>();

        foreach (var line in lines.Where(x => x.StartsWith("m")))
        {
            numbers.AddRange(line.Split(' ').Where(x => int.TryParse(x, out _)).Select(int.Parse).ToList());
        }
        return numbers.Chunk(3);
    }

    private static List<Stack<char>> GetStacksFromList(string fileName)
    {
        var lines = ReadFile(fileName);
        var stacks = new List<Stack<char>>()
        {
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
            new(),
            new()
        };
        foreach (var line in lines.Where(x => x.Contains('[')).Reverse())
        {
            if (char.IsLetter(line[1]))
                stacks[0].Push(line[1]);
            if (char.IsLetter(line[5]))
                stacks[1].Push(line[5]);
            if (char.IsLetter(line[9]))
                stacks[2].Push(line[9]);

            if (line.Length < 12)
                continue;

            if (char.IsLetter(line[13]))
                stacks[3].Push(line[13]);
            if (char.IsLetter(line[17]))
                stacks[4].Push(line[17]);
            if (char.IsLetter(line[21]))
                stacks[5].Push(line[21]);
            if (char.IsLetter(line[25]))
                stacks[6].Push(line[25]);
            if (char.IsLetter(line[29]))
                stacks[7].Push(line[29]);
            if (char.IsLetter(line[33]))
                stacks[8].Push(line[33]);
        }

        return stacks;
    }

    private static string[] ReadFile(string fileName)
    {
        return File.ReadAllLines(fileName);
    }
}