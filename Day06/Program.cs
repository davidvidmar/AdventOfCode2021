using static AdventOfCode2021.Utils;

namespace AdventOfCode2021;

class Program
{
    static void Main()
    {

        int result1 = 0;
        long result2 = 0;

        StartDay(6);

        // Part 1
        StartPart(1);

        var fishList = Utils.ReadInputAsIntArray().ToList();

        for (int day = 0; day < 80; day++)
        {
            fishList = ProcessFish(fishList);
        }

        result1 = fishList.Count;
        
        EndPart(1, result1);

        // Part 2
        StartPart(2);

        var d = new Dictionary<int, long>(8);                
        for (int i = 0; i < 9; i++)
        {
            d[i] = 0;
        }

        fishList = Utils.ReadInputAsIntArray().ToList();
        for (int i = 0; i < fishList.Count; i++)
        {
            d[fishList[i]]++;
        }

        for (int day = 1; day <= 256; day++)
        {
            var n = d[0];
            for (int i = 0; i < 8; i++)            
                d[i] = d[i + 1];                            
            d[6] += n;
            d[8] = n;
        }
        result2 = d.Sum(x => x.Value);

        EndPart(2, result2);

    }

    private static List<int> ProcessFish(List<int> fishList)
    {
        var newList = new List<int>();
        var newFish = new List<int>();
        foreach (var fish in fishList)
        {
            if (fish > 0)
            {
                newList.Add(fish - 1);
            }

            if (fish == 0)
            {
                newList.Add(6);
                newFish.Add(8);
            }
        }
        newList.AddRange(newFish);
        return newList;
    }
}