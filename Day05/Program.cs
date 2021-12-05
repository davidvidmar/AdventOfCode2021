using static AdventOfCode2021.Utils;

namespace AdventOfCode2021;

class Program
{
    static void Main()
    {

        int result1 = 0;
        int result2 = 0;

        StartDay(4);

        // Part 1
        StartPart(1);

        var table = ReadData(ProcessDataPart1, 1000);
        //PrintData(table);
        result1 = EvaluateData(table, 2);

        EndPart(1, result1);

        // Part 2
        StartPart(2);

        table = ReadData(ProcessDataPart2, 1000);
        //PrintData(table);
        result2 = EvaluateData(table, 2);

        EndPart(2, result2);

    }

    private static void PrintData(int[,] table)
    {
        for (int y = 0; y < table.GetLength(1); y++)
        {
            for (int x = 0; x < table.GetLength(0); x++)
            {
                if (table[x, y] == 0)
                    Console.Write('.');
                else
                    Console.Write(table[x, y]);
            }
            Console.WriteLine();
        }
    }

    private static int EvaluateData(int[,] table, int level)
    {
        var result = 0;
        for (int y = 0; y < table.GetLength(1); y++)
        {
            for (int x = 0; x < table.GetLength(0); x++)
            {
                if (table[x, y] >= level)
                    result++;
            }
        }
        return result;
    }

    private static int[,] ReadData(Func<int, int, int, int, int[,], int[,]> processData, int dim)
    {
        //var lines = ReadInputAsLines("input-sample.txt").ToList();
        var lines = ReadInputAsLines().ToList();

        int[,] table = new int[dim, dim];

        foreach (var line in lines)
        {
            var s = line.Split(" -> ");
            var sx = Convert.ToInt32(s[0].Split(',')[0]);
            var sy = Convert.ToInt32(s[0].Split(',')[1]);
            var ex = Convert.ToInt32(s[1].Split(',')[0]);
            var ey = Convert.ToInt32(s[1].Split(',')[1]);

            table = processData(sx, sy, ex, ey, table);
        }

        return table;
    }

    private static int[,] ProcessDataPart1(int sx, int sy, int ex, int ey, int[,] table)
    {
        if (sx == ex || sy == ey)
        {
            var sxx = Math.Min(sx, ex);
            var exx = Math.Max(sx, ex);
            var syy = Math.Min(sy, ey);
            var eyy = Math.Max(sy, ey);
            for (int x = 0; x < exx - sxx + 1; x++)
            {
                for (int y = 0; y < eyy - syy + 1; y++)
                {
                    table[sxx + x, syy + y] = table[sxx + x, syy + y] + 1;
                }
            }
            //LogLine($"{sx},{ey} -> {ex},{ey}");
            //PrintData(table);
        }
        else
        {
            //LogLine($"NOT: {sx},{sy} -> {ex},{ey}");
        }

        return table;
    }

    private static int[,] ProcessDataPart2(int sx, int sy, int ex, int ey, int[,] table)
    {
        //Log($"{sx},{sy} -> {ex},{ey}");
        if (sy == ey)
        {
            //LogLine($" = ");
            if (ex > sx)
            {
                for (int i = 0; i < ex - sx + 1; i++)
                {
                    table[sx + i, sy] = table[sx + i, sy] + 1;
                }
            }
            else
            {
                for (int i = 0; i < sx - ex + 1; i++)
                {
                    table[sx - i, sy] = table[sx - i, sy] + 1;
                }
            }
            //PrintData(table);
        } else if (sx == ex)
        { 
            //LogLine($" | ");
            if (ey > sy)
            {
                for (int i = 0; i < ey - sy + 1; i++)
                {
                    table[sx, sy + i] = table[sx, sy + i] + 1;
                }
            }
            else
            {   
                for (int i = 0; i < sy - ey + 1; i++)
                {
                    table[sx, sy - i] = table[sx, sy - i] + 1;
                }
            }
            //PrintData(table);            
        }
        else if (Math.Abs(ex - sx) == Math.Abs(ey - sy))
        {
            if (ey > sy)
            {                
                for (int i = 0; i < ey - sy + 1; i++)
                {
                    if (ex > sx)
                    {
                        //LogLine($" \\ ");
                        table[sx + i, sy + i] = table[sx + i, sy + i] + 1;
                    }
                    else
                    {
                        //LogLine($" / ");
                        table[sx - i, sy + i] = table[sx - i, sy + i] + 1;
                    }
                }                
            }
            else
            {                
                for (int i = 0; i < sy - ey + 1; i++)
                {
                    if (ex > sx)
                    {
                        // "/"
                        // sy > ey, sx < ex
                        table[sx + i, sy - i] = table[sx + i, sy - i] + 1;
                    }
                    else
                    {
                        // "\"
                        // sy > ey, sx > ex
                        table[sx - i, sy - i] = table[sx - i, sy - i] + 1;
                    }
                }                
            }
            //PrintData(table);
        }
        else
        {
            //LogLine($" - NOT");
        }

        return table;
    }
}