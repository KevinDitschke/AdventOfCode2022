namespace Day4;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine(SectionsFullyContained("inputTest.txt"));
        Console.WriteLine(SectionsFullyContained("input.txt"));
    }

    private static int SectionsFullyContained(string fileName)
    {
        var sum = 0;
        var sections = ReadFile(fileName);

        foreach (var section in sections)
        {
            var ranges = section.Split(',');
            var firstSectionRange = new SectionRange()
            {
                Start = int.Parse(ranges[0].Split('-').First()), 
                End = int.Parse(ranges[0].Split('-').Last())
            };
            var secondSectionRange = new SectionRange()
            {
                Start = int.Parse(ranges[1].Split('-').First()), 
                End = int.Parse(ranges[1].Split('-').Last())
            };

            if (firstSectionRange.Start <= secondSectionRange.Start &&
                 firstSectionRange.End >= secondSectionRange.End ||
                firstSectionRange.Start >= secondSectionRange.Start && firstSectionRange.End <= secondSectionRange.End ||
                firstSectionRange.Start <= secondSectionRange.Start && firstSectionRange.End >= secondSectionRange.Start ||
                 secondSectionRange.Start <= firstSectionRange.Start && secondSectionRange.End >= firstSectionRange.Start)
                sum++;
        }

        return sum;
    }
    
    private static string[] ReadFile(string fileName)
    {
        return File.ReadAllLines(fileName);
    }

    struct SectionRange
    {
        public int Start { get; set; }
        public int End { get; set; }
    }
}