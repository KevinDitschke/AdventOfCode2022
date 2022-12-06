namespace Day5;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(ReadingBuffer("inputTest.txt"));
        Console.WriteLine(ReadingBuffer("input.txt"));
    }

    private static int ReadingBuffer(string fileName)
    {
        var text = ReadFile(fileName);
        var position = 0;
        for (var i = 0; i < text.Length-4; i++)
        {
            var subString = text.Substring(i, 4);
            if (subString.Select(x => x).Distinct().Count() == 4){
                position = i + 4;
                break;
            }
        }
        return position;
    }

    private static string ReadFile(string fileName)
    {
        return File.ReadAllText(fileName);
    }
}