namespace Day1;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(GetHighestCaloryCount("inputTest.txt"));
        Console.WriteLine(GetHighestCaloryCount("input.txt"));
    }

    private static int GetHighestCaloryCount(string fileName)
    {
        var file = File.ReadAllLines(fileName);
        
        int temp = 0;
        int sum = 0;
        foreach (var line in file)
        {
            int output = 0;
            if (int.TryParse(line, out output))
                temp += output;
            else
            {
                if (temp > sum)
                {
                    sum = temp;
                }
                temp = 0;
            }
        }
        return sum;
    }
}