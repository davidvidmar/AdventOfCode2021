using static AdventOfCode2021.Utils;

int result1 = 0;
int result2 = 0;

StartDay(3);

// Part 1
StartPart(1);

var lines = ReadInputAsLines("input.txt").ToList();

string gr = "", er = "";
for (int i = 0; i < lines[0].Length; i++)
{
    int cnt = lines.Count(line => line[i] == '1');
    gr += (cnt > lines.Count / 2 ? "1" : "0");
    er += (cnt > lines.Count / 2 ? "0" : "1");
}

//LogLine("gr = " + gr + " = " + Convert.ToInt32(gr, 2));
//LogLine("er = " + er + " = " + Convert.ToInt32(er, 2));

result1 = Convert.ToInt32(gr, 2) * Convert.ToInt32(er, 2);

EndPart(1, result1);

// Part 2
StartPart(2);

List<string> o = new(lines);
List<string> co2 = new(lines); ;

for (int i = 0; i < lines[0].Length; i++)
{
    int cnt = o.Count(line => line[i] == '1');    
    var c2 = cnt > o.Count / 2 ? '1' : '0';
    if (o.Count > 1) {
        var c = cnt == (decimal)o.Count / 2 ? '1' : c2;
        o.RemoveAll(x => x[i] != c);
    }    
}

for (int i = 0; i < lines[0].Length; i++)
{
    int cnt = co2.Count(line => line[i] == '1');
    var c2 = cnt > co2.Count / 2 ? '0' : '1';
    if (co2.Count > 1)
    {
        var c = cnt == (decimal)co2.Count / 2 ? '0' : c2;
        co2.RemoveAll(x => x[i] != c);
    }
}

//Console.WriteLine(o[0]);
//Console.WriteLine(co2[0]);

result2 = Convert.ToInt32(o[0], 2) * Convert.ToInt32(co2[0], 2);

EndPart(2, result2);