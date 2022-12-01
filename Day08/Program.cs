using static AdventOfCode2021.Utils;

namespace AdventOfCode2021;

class Program
{
    static void Main()
    {

        //  1      c  f      // 2 **
        //  4     bcd f      // 4 **
        //  7    a c  f      // 3 **
        //  8    abcdefg     // 7 **

        //  2    a cde g     // 5
        //  3    a cd fg     // 5
        //  5    ab d fg     // 5
        
        //  0    abc efg     // 6
        //  9    abcd fg     // 6
        //  6    ab defg     // 6

        int result1 = 0;
        int result2 = 0;

        StartDay(8);

        #region Part 1

        StartPart(1);

        var lines = ReadInputAsLines("input.txt");       
        foreach (var line in lines)
        {
            var s = line.Split(" | ");
            var signal = s[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var digit = s[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            result1 +=
                digit.Count(d => d.Length == 2) +
                digit.Count(d => d.Length == 4) +
                digit.Count(d => d.Length == 3) +
                digit.Count(d => d.Length == 7);
        }        

        EndPart(1, result1);

        #endregion

        #region Part 2

        StartPart(2);

        lines = new string[] { "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab | cdfeb fcadb cdfeb cdbaf" };

        foreach (var line in lines)
        {
            var s = line.Split(" | ");

            var signals = s[0].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var digits = s[1].Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var d1 = signals.Single(s => s.Length == 2).OrderBy(c => c).ToList();
            var d4 = signals.Single(s => s.Length == 4).OrderBy(c => c).ToList();
            var d7 = signals.Single(s => s.Length == 3).OrderBy(c => c).ToList();
            var d8 = signals.Single(s => s.Length == 7).OrderBy(c => c).ToList();

            var l5 = signals.Where(s => s.Length == 6);
            var l6 = signals.Where(s => s.Length == 6);

            
        }

        EndPart(2, result2);

        #endregion

    }

}