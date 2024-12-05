using System;

public class Day04
{
    static void Main(string[] args)
    {

        var part = args.Length > 0 ? args[0].ToLower() : "part1";
        var fileName =("input.txt");
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
        
    }

    static int Part2(string file)
    {
        
    }


    
}