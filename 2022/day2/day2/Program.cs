string input = File.ReadAllText("input.in");

string[] rounds = input.Split("\n");

int score = 0;

foreach (string i in rounds)
{
    //win
    if (i.Contains("Z"))
    {
        score += 6;
    }
    //draw
    else if (i.Contains("Y"))
    {
        score += 3;
    }
}

foreach (string i in rounds)
{
    if (i.Contains("A Y") ^ i.Contains("B X") ^ i.Contains("C Z")){score += 1;}
    else if (i.Contains("B Y") ^ i.Contains("C X") ^ i.Contains("A Z")){score += 2;}
    else {score += 3;}
}
Console.WriteLine(score);