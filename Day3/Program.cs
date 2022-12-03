namespace Day3;

internal class Program
{
    private static Dictionary<char, int> priorities; 

    static void Main(string[] args)
    {
        priorities = new Dictionary<char, int>();
        for (int i = 1; i < 27; i++)
        {
            priorities.Add((char)(i+64), i+26);
            priorities.Add((char)(i+96), i);
        }
        Console.WriteLine(MostCommonRucksackItem("inputTest.txt"));
        Console.WriteLine(MostCommonRucksackItem("input.txt"));
    }

    private static int MostCommonRucksackItem(string fileName)
    {
        var file = File.ReadAllLines(fileName);
        var sum = 0;

        foreach (var rucksack in file)
        {
            var firstCompartment = rucksack.Substring(0, rucksack.Length/2) ;
            var secondCompartment = rucksack.Substring(rucksack.Length/2, rucksack.Length/2);

            var duplicate = firstCompartment.First(x => secondCompartment.Contains(x));
            sum += priorities[duplicate];
        }
        return sum;
    }
}