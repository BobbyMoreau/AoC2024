using System;

class Day01
{
    static void Main(string[] args)
    {
        var part = Environment.GetEnvironmentVariable("part") ?? "part1";
        var path = "C:/Users/bobby.moreau-raquin/EDF/AoC/AoC2024/day01/input.txt";
        var solution = part switch
        {
            "part1" => Part1(path),
            "part2" => Part2(path),
            _ => throw new ArgumentOutOfRangeException(nameof(part), $"Unexpected {nameof(part)} value: '{part}'")
        };

        Console.WriteLine("C#");
        Console.WriteLine(solution);

    }

    static int Part1(string path)
    {
        string[] lines = File.ReadAllLines(path);
        int[] colOne = new int[lines.Length];
        int[] colTwo = new int[lines.Length];
        int n = 0;

        foreach (string line in lines)
        {        
            string[] splitLine = line.Split(' ');
            colOne[n] = int.Parse(splitLine[0].Trim());
            string secondPiece = string.Join(" ", splitLine.Skip(1));
            secondPiece = secondPiece.Trim();
            colTwo[n] = int.Parse(secondPiece);
            n++;
        }
        
        Array.Sort(colOne);
        Array.Sort(colTwo);
        int sum = 0;

        for(int i = 0; i < n; i++)
        {          
            sum += Math.Abs(colOne[i] - colTwo[i]);
        }

        Console.WriteLine(sum);
        return sum;
    }

    static int Part2(string path)
    {
        return 0;
    }
}