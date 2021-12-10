using static AdventOfCode2021.Utils;

namespace AdventOfCode2021;

class Program
{
    static void Main()
    {

        int result1 = 0;
        int result2 = 0;

        StartDay(7);

        // Part 1
        StartPart(1);

        //var crabs = Utils.ReadInputAsIntArray("input-sample.txt");
        var crabs = Utils.ReadInputAsIntArray();

        result1 = Int32.MaxValue;
        for (int i = 0; i < crabs.Max(); i++)
        {
            var x = crabs.Sum(x => Math.Abs(x - i));
            if (x < result1) result1 = x;
        }

        EndPart(1, result1);

        // Part 2
        StartPart(2);

        result2 = Int32.MaxValue;
        for (int i = 0; i < crabs.Max(); i++)
        {            
            var x = crabs.Sum(x => (Math.Abs(x - i - 1) * (Math.Abs(x - i - 1) + 1)) /2);
            //LogLine($"{x}");
            if (x < result2) result2 = x;
        }

        EndPart(2, result2);

    }

}