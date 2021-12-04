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

        (List<int> draws, List<List<int>> cards) = ReadData();

        foreach (var draw in draws)
        {
            MarkCards(draw, cards);
            var win = CheckCards(cards);
            if (win != null)
            {
                LogLine(draw);
                win.ForEach(w => Log(w + " "));
                var mult = 0;
                win.ForEach(w => mult += w);
                LogLine();
                LogLine(mult);

                result1 = mult * draw;
                break;
            }
        }

        EndPart(1, result1);

        // Part 2
        StartPart(2);
        
        (draws, cards) = ReadData();

        foreach (var draw in draws)
        {
            //Console.Write("." + draw);
            MarkCards(draw, cards);            
            (List<int> card, List<int>? list) = CheckCards2(cards);
            while (card != null)
            {
                //Console.WriteLine();
                cards.Remove(card);
                //Console.WriteLine(cards.Count);

                if (cards.Count == 0)
                {
                    LogLine(draw);
                    list.ForEach(w => Log(w + " "));
                    var sum = 0;
                    list.ForEach(w => sum += w);                    
                    LogLine(sum);

                    result2 = sum * draw;
                    break;
                }
                (card, list) = CheckCards2(cards);
            }
        }

        EndPart(2, result2);

    }

    private static (List<int>?, List<int>?) CheckCards2(List<List<int>> cards)
    {
        foreach (var card in cards)
        {
            // check rows
            for (int i = 0; i < 5; i++)
            {
                if (card.GetRange(i * 5, 5).All(i => i < 0))
                    return (card, card.Where(n => n > 0).ToList());
            }
            // check columns
            for (int i = 0; i < 5; i++)
            {
                //var column = new List<int>();
                var columnWin = true;
                for (int j = 0; j < 5; j++)
                {
                    int num = card[j * 5 + i];
                    columnWin &= num < 0;
                    //column.Add(num);
                }
                if (columnWin)
                    return (card, card.Where(n => n > 0).ToList());
            }
        }
        return (null, null);
    }

    private static List<int>? CheckCards(List<List<int>> cards)
    {
        foreach (var card in cards)
        { 
            // check rows
            for (int i = 0; i < 5; i++)
            {
                if (card.GetRange(i * 5, 5).All(i => i < 0))
                    return card.Where(n => n > 0).ToList();
            }
            // check columns
            for (int i = 0; i < 5; i++)
            {
                var column = new List<int>();
                var columnWin = true;
                for (int j = 0; j < 5; j++)
                {
                    int num = card[i * 5 + j];
                    columnWin &= num < 0;                    
                    column.Add(num);
                }
                if (columnWin)
                    return column;
            }
        }
        return null;
    }

    private static void MarkCards(int draw, List<List<int>> cards)
    {
        foreach (var card in cards)
        {
            var i = card.IndexOf(draw);
            if (i >= 0) card[i] = -card[i] - 1;
        }
    }

    private static (List<int> draws, List<List<int>> cards) ReadData()
    {
        //var lines = ReadInputAsLines("input-/*sample*/.txt").ToList();
        var lines = ReadInputAsLines().ToList();

        var draws = lines[0].Split(',').Select(s => Convert.ToInt32(s)).ToList();
        lines.RemoveAt(0);

        var cards = new List<List<int>>();

        while (lines.Count > 0)
        {
            if (lines[0].Trim().Length == 0)
                lines.RemoveAt(0);

            var card = new List<int>();
            for (int i = 0; i < 5; i++)
            {
                var l = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(s => Convert.ToInt32(s));
                card.AddRange(l);
                lines.RemoveAt(0);
            }
            cards.Add(card);
        }
        return (draws, cards);
    }
}