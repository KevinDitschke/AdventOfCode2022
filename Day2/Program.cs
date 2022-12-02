namespace Day2;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(RockPaperScissorScore("input.txt"));
    }

    private static int RockPaperScissorScore(string fileName)
    {
        var file = File.ReadAllLines(fileName);
        var sum = 0;
        foreach (var line in file)
        {
            switch (line)
            {
                case "A X":
                    sum += 4;
                    break;
                case "A Y":
                    sum += 8;
                    break;
                case "A Z":
                    sum += 3;
                    break;
                case "B X":
                    sum += 1;
                    break;
                case "B Y":
                    sum += 5;
                    break;
                case "B Z":
                    sum += 9;
                    break;
                case "C X":
                    sum += 7;
                    break;
                case "C Y":
                    sum += 2;
                    break;
                case "C Z":
                    sum += 6;
                    break;
            }
        }

        return sum;
    }
}