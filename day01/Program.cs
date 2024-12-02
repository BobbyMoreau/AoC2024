using System;

class Day01
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
        var (columnOne, columnTwo) = ReadSplitInput(file);
        
        Array.Sort(columnOne);
        Array.Sort(columnTwo);
        int sum = 0;

        for(int i = 0; i < columnOne.Length; i++)
        {          
            sum += Math.Abs(columnOne[i] - columnTwo[i]);
        }
        return sum;
    }

    static int Part2(string file)
    {
        var (columnOne, columnTwo) = ReadSplitInput(file);

        Array.Sort(columnOne);
        Array.Sort(columnTwo);

        int sum = 0;
        for (int i = 0; i < columnOne.Length; i++)
        {
            int count = 0;
            for (int j = 0; j < columnTwo.Length; j++)
            {
                if (columnOne[i] == columnTwo[j])
                {
                    count++;
                }

                if (columnOne[i] < columnTwo[j])
                {
                    break;
                }
            }

            sum += (count * columnOne[i]);
        }
        return sum;
    }


    static (int[] columnOne, int[] columnTwo) ReadSplitInput(string file)
    {
        
        string[] lines = File.ReadAllLines(file);
        int[] columnOne = new int[lines.Length];
        int[] columnTwo = new int[lines.Length];
        int n = 0;

        foreach (string line in lines)
        {
            string[] splitLine = line.Split(' ');
            columnOne[n] = int.Parse(splitLine[0].Trim());
            string secondPiece = string.Join(" ", splitLine.Skip(1));
            secondPiece = secondPiece.Trim();
            columnTwo[n] = int.Parse(secondPiece);
            n++;
        }

        return (columnOne, columnTwo);
    }
}