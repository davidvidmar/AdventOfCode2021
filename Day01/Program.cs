using System.Linq;
using static AdventOfCode2021.Utils;

class Program
{
    static void Main()
    {
        int result1 = 0;
        int result2 = 0;

        StartDay(1);

        // Part 1
        StartPart(1);

        var lines = ReadInputAsIntLines("input.txt").ToArray();

        int current = -1;
        foreach (var item in lines)
        {
            Log(item);
            if (current != -1 && item > current)
            {
                LogLine("^");
                result1++;
            }
            else
                LogLine();
            current = item;
        }

        EndPart(1, result1);

        // Part 2
        StartPart(2);

        current = -1;
        for (int i = 0; i < lines.Length; i++)
        {
            var avg = -1;
            if (i > 2)
            {
                avg = lines[i] + lines[i - 1] + lines[i - 2];
                Log(avg);
                if (avg > current)
                {
                    Log("^");
                    result2++;
                }
                LogLine();
            }
            
            current = avg;
        }       

        EndPart(2, result2);
    }
}