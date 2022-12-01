using static AdventOfCode2021.Utils;

namespace AdventOfCode2021;

class Program
{
    static void Main()
    {

        int result1 = 0;
        int result2 = 0;

        StartDay(9);

        // Part 1
        StartPart(1);

        var (area, cols, lines) = Utils.ReadIntArray();

        for (int l = 0; l < lines; l++)
        {
            for (int c = 0; c < cols; c++)
            {
                var low = true; 
                if (l > 0         && area[c, l - 1] <= area[c, l]) low &= false;
                if (l < lines - 1 && area[c, l + 1] <= area[c, l]) low &= false;
                if (c > 0         && area[c - 1, l] <= area[c, l]) low &= false;
                if (c < cols - 1  && area[c + 1, l] <= area[c, l]) low &= false;

                if (low)
                    result1 += area[c, l] + 1;
            }
        }

        EndPart(1, result1);

        // Part 2
        StartPart(2);

        //for (int l = 0; l < lines; l++)
        //{
        //    for (int c = 0; c < cols; c++)
        //    {
        //        var low = true; ;
        //        if (l > 0 && area[c, l - 1] <= area[c, l]) low &= false;
        //        if (l < lines - 1 && area[c, l + 1] <= area[c, l]) low &= false;
        //        if (c > 0 && area[c - 1, l] <= area[c, l]) low &= false;
        //        if (c < cols - 1 && area[c + 1, l] <= area[c, l]) low &= false;

        //        if (low)
        //            result1 += area[c, l] + 1;
        //    }
        //}

        EndPart(2, result2);

    }
}

