using static AdventOfCode2021.Utils;

int result1 = 0;
int result2 = 0;

StartDay(2);

// Part 1
StartPart(1);

var pos = 0;
var depth = 0;

var lines = ReadInputAsLines();

foreach (var line in lines)
{
    var s = line.Split(' ');

    var way = s[0];
    var amount = Convert.ToInt32(s[1]);

    if (way == "forward")
        pos += amount;
    if (way == "up")
        depth -= amount;
    if (way == "down")
        depth += amount;
}

LogLine($"pos = {pos}, depth = {depth}");
result1 = pos * depth;

EndPart(1, result1);

// Part 2
StartPart(2);

var aim = 0;
pos = 0;
depth = 0;

foreach (var line in lines)
{
    var s = line.Split(' ');

    var way = s[0];
    var amount = Convert.ToInt32(s[1]);

    if (way == "forward")
    {
        pos += amount;
        depth += aim * amount;
    }
    if (way == "up")
        aim -= amount;
    if (way == "down")
        aim += amount;

    LogLine($"pos = {pos}, depth = {depth}, aim = {aim}");
}

LogLine($"pos = {pos}, depth = {depth}");
result2 = pos * depth;

EndPart(2, result2);