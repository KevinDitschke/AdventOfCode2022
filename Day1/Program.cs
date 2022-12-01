namespace Day1;

internal class Program
{
    static void Main(string[] args)
    {
        foreach (var sum in GetHighestCaloryCount("inputTest.txt"))
        {
            Console.WriteLine(sum);
        }
        var sums = GetHighestCaloryCount("input.txt");

        foreach (var sum in sums)
        {
            Console.WriteLine(sum);
        }
        
        Console.WriteLine(sums.Sum());
    }

    private static List<int> GetHighestCaloryCount(string fileName)
    {
        var file = File.ReadAllLines(fileName);

        int temp = 0;
        var listOfSums = new List<int>();
        foreach (var line in file)
        {
            int output = 0;
            if (int.TryParse(line, out output))
                temp += output;
            else
            {
                listOfSums.Add(temp);
                temp = 0;
            }
        }

        listOfSums.Add(temp);
        return listOfSums.OrderByDescending(x => x).Take(3).ToList();
    }
}