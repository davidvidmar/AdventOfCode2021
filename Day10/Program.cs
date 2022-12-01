using static AdventOfCode2021.Utils;

namespace AdventOfCode2021;

class Program
{
    static void Main()
    {

        int result1 = 0;
        long result2 = 0;

        StartDay(10);

        // Part 1
        StartPart(1);

        //var lines = Utils.ReadInputAsLines("input-sample.txt");
        var lines = Utils.ReadInputAsLines();

        var co = "([{<";
        var cc = ")]}>";
        var price = new[] { 3, 57, 1197, 25137 };        
        var stack = new Stack<char>();

        foreach (var line in lines)
        {
            stack.Clear();
            //Console.Write(line + " - ");
            for (int i = 0; i < line.Length; i++)
            {
                // opening
                if (co.Contains(line[i]))
                {
                    stack.Push(cc[co.IndexOf(line[i])]);
                }
                else
                // closing
                if (cc.Contains(line[i]))
                {
                    // correct closing
                    if (line[i] == stack.Peek())
                    {
                        stack.Pop();
                    }
                    else
                    {
                        // corrupted = incorrect closing
                        var index = cc.IndexOf(line[i]);
                        result1 += price[index];
                        //Console.WriteLine(line + " - invalid - " + line[i]);
                        break;
                    }
                }
                else
                    throw new Exception("Invalid char.");
            }
            if (stack.Count > 0)
            {
                // incomplete 
                //Console.WriteLine();
            }
        }

        // ...

        EndPart(1, result1);

        // Part 2
        StartPart(2);

        var results2 = new List<long>();
        
        foreach (var line in lines)
        {            
            stack.Clear();
            //Console.Write(line + " - ");
            for (int i = 0; i < line.Length; i++)
            {
                // opening
                if (co.Contains(line[i]))
                {
                    stack.Push(cc[co.IndexOf(line[i])]);
                }
                else
                // closing
                if (cc.Contains(line[i]))
                {
                    // correct closing
                    if (line[i] == stack.Peek())
                    {
                        stack.Pop();
                    }
                    else
                    {
                        // corrupted = incorrect closing
                        // var index = cc.IndexOf(line[i]);
                        // result1 += price[index];
                        //Console.WriteLine(line + " - invalid - " + line[i]);
                        stack.Clear();
                        break;
                    }
                }
                else
                    throw new Exception("Invalid char.");
            }
            if (stack.Count > 0)
            {
                long r = 0;
                // incomplete 
                while (stack.Count > 0)
                {
                    var c = stack.Pop();
                    var index = cc.IndexOf(c) + 1;
                    r = r * 5 + index;
                }
                Console.WriteLine(result2);
                results2.Add(r);             
            }
        }

        results2.Sort();
        result2 = results2[results2.Count / 2];

        EndPart(2, result2);

    }

}