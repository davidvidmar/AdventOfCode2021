using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main()
        {
            int result1 = 0;
            int result2 = 0;

            Utils.StartDay(1);
            Utils.StartPart(1);

            var lines = Utils.ReadInputAsIntLines("input.txt");

            int current = -1;            
            foreach (var item in lines)
            {
                Console.Write(item);
                if (current != -1 && item > current)
                {
                    Console.WriteLine("^");
                    result1++;
                }
                else
                    Console.WriteLine();
                current = item;
            }

            Utils.EndPart(1, result1);

            Utils.StartPart(2);

            // ...

            Utils.EndPart(2, result2);
        }
    }
}
