using System;
using System.Text.RegularExpressions;

public class Day03
{
    static void Main(string[] args)
    {

        var part = args.Length > 0 ? args[0].ToLower() : "part2";
        var fileName = ("input.txt");
        string file = Path.Combine(Directory.GetCurrentDirectory(), fileName);

        var solution = part switch
        {
            "part1" => Part1(file),
            "part2" => Part2(file),
            _ => throw new ArgumentOutOfRangeException(nameof(part), $"Unexpected {nameof(part)} value: '{part}'")
        };

        Console.WriteLine($"Solution for {part}:");
        Console.WriteLine(solution);
    }

    static int Part1(string file)
    {
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        int sum = 0;    

        Regex regex = new Regex(pattern);
        string content = File.ReadAllText(file);
        MatchCollection matches = regex.Matches(content);

        foreach (Match match in matches)
        {

                string numberOne = match.Groups[1].Value;
                string numberTwo = match.Groups[2].Value;

                int factorOne = int.Parse(numberOne);
                int factorTwo = int.Parse(numberTwo);

                sum += (factorOne * factorTwo);

        }

        return sum;
    }

    static int Part2(string file)
    {
        string pattern = @"mul\((\d{1,3}),(\d{1,3})\)";
        int sum = 0;

        
        string content = File.ReadAllText(file);
        Regex doNotPattern = new Regex(@"don't\(\).*?do\(\)");
        Regex removeLastRegex = new Regex(@"don't\(\).*");
        string cleanedContent = content.Replace("\r", "").Replace("\n", "");
        string removeDoNot = doNotPattern.Replace(cleanedContent, "!!!!!");
        string lastDoNot = removeLastRegex.Replace(removeDoNot, "!!!!!");
        cleanedContent = lastDoNot;

        
        Regex regex = new Regex(pattern);
        MatchCollection matches = regex.Matches(cleanedContent);

        foreach (Match match in matches)
        {

            string numberOne = match.Groups[1].Value;
            string numberTwo = match.Groups[2].Value;

            int factorOne = int.Parse(numberOne);
            int factorTwo = int.Parse(numberTwo);

            sum += (factorOne * factorTwo);

        }

        return sum;
    }
}