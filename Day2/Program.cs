namespace Day2;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(RockPaperScissorScore("input.txt"));
        Console.WriteLine(RockPaperScissorScorePart2("input.txt"));
    }

    private static int RockPaperScissorScorePart2(string fileName)
    {
        var file = File.ReadAllLines(fileName);
        var sum = 0;
        foreach (var line in file)
        {
            if (line[2] == 'X')
            {
                sum += Lose(line[0]);
            }
            else if (line[2] == 'Y')
            {
                sum += Draw(line[0]) + 3;
            }
            else if (line[2] == 'Z')
            {
                sum += Win(line[0]) + 6;
            }
        }

        return sum;
    }

    private static int Lose(char character)
    {
        var dict = new Dictionary<char, int>()
        {
            {'A', 3}, {'B', 1}, {'C', 2}
        };
        return dict[character];
    }
    
    private static int Draw(char character)
    {
        var dict = new Dictionary<char, int>()
        {
            {'A', 1}, {'B', 2}, {'C', 3}
        };
        return dict[character];
    }
    
    private static int Win(char character)
    {
        var dict = new Dictionary<char, int>()
        {
            {'A', 2}, {'B', 3}, {'C', 1}
        };
        return dict[character];
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