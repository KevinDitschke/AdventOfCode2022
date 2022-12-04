namespace Day3;

internal class Program
{
    private static Dictionary<char, int> priorities;

    static void Main(string[] args)
    {
        priorities = new Dictionary<char, int>();
        for (int i = 1; i < 27; i++)
        {
            priorities.Add((char)(i + 64), i + 26);
            priorities.Add((char)(i + 96), i);
        }

        Console.WriteLine(GroupsOfThree("input.txt"));
    }

    private static int GroupsOfThree(string fileName)
    {
        var file = File.ReadAllLines(fileName);
        var groups = file.Chunk(3);
        var totalsum = 0;
        foreach (var rucksacks in groups)
        {
            totalsum += MostCommonRucksackItem(rucksacks);
        }
        return totalsum;
    }

    private static int MostCommonRucksackItem(string[] rucksacks)
    {
        var sum = 0;

        var duplicate = rucksacks[0].First(x => rucksacks[1].Contains(x) && rucksacks[2].Contains(x));
        sum += priorities[duplicate];
        return sum;
    }
}