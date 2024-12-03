using System;

public class Day2
{
    static void Main(string[] args)
    {

        var part = args.Length > 0 ? args[0].ToLower() : "part1";
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
        string[] lines = File.ReadAllLines(file);
        int n = 0;
        int unsafeRules = 0;
        bool unsafeRule = true;

        foreach (string line in lines)
        {
            string[] splitLine = line.Split(' ');
            int[] levels = new int[splitLine.Length];
            foreach (string split in splitLine)
            {
                
                levels[n] = int.Parse(split);
                n++;
            }

            bool isAscending = levels.SequenceEqual(levels.OrderBy(x => x));
            bool isDescending = levels.SequenceEqual(levels.OrderByDescending(x => x));
            if (isAscending == true || isDescending == true) 
            {
                unsafeRule = false;
                for (int i = 0; i < levels.Length-1; i++)
                {
                    
                    int diff = levels[i] - levels[i + 1];
                    if (Math.Abs(diff) > 3 || Math.Abs(diff) < 1)
                    {
             
                            //Är unsafe
                            unsafeRule = true;
                            break;
                        
                    }
                }

            } 
                if (unsafeRule)
                {
                    unsafeRules++;
                }
                

            n = 0;
        }

        return lines.Length - unsafeRules;
    }
    static int Part2(string file)
    {
        return 0;
    }

}
