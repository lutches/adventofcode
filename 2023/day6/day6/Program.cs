string input = File.ReadAllText("input.in");

string[] splits = input.Split(" ");
List<string> Listsplits = []; 
foreach (string race in splits){
    if (race != "" && !race.Contains(':')){
        Listsplits.Add(race);
    }
    if (race.Contains("\n")){
        Listsplits.Add(race.Split("\n")[0]);
    }
}
List<(long,long)> races = [];
for (int i = 0; i < Listsplits.Count/2;i++){
    (long,long) race = (long.Parse(Listsplits[i]) , long.Parse(Listsplits[i+Listsplits.Count/2] ));
    races.Add(race);
}

int output = 0;
foreach ((long,long) race in races){
    HashSet<long> speeds = [];
    for (long speed = 0; speed < race.Item1;speed++){
        long raceleft = race.Item1-speed;
        if (speed*raceleft > race.Item2){
            speeds.Add(speed);
        }
    }
    if (output == 0){
        output = speeds.Count;
    }
    else {
        output *= speeds.Count;
    }
}
Console.WriteLine(output);