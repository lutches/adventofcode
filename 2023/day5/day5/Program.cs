
static long respose(long destination, long source, long range, long value){
    if (value > source && value < source+range){
        return destination + (value-source);
    }
    return value;
}

string[] input = File.ReadAllLines("input");

List<Int64> seeds = [];

for (int i = 1; i< input[0].Split(' ').Length; i++){
    seeds.Add(Int64.Parse(input[0].Split(' ')[i]));   
}

List<(Int64,Int64,Int64)[]> tempinst = [];
List<(Int64,Int64,Int64)> temptuple = [];

foreach (string line in input){
    if (line.Length == 0){
        if (temptuple.Count > 0){
            tempinst.Add([.. temptuple]);
            temptuple.Clear();
        }
    }
    else if ("0123456789".Contains(line[0])){
        string[] inst = line.Split(' ');
        temptuple.Add((Int64.Parse(inst[0]),Int64.Parse(inst[1]),Int64.Parse(inst[2])));
    }
}
tempinst.Add([.. temptuple]);

(Int64,Int64,Int64)[][] instrucitons = [.. tempinst];

foreach ((Int64,Int64,Int64)[] map in instrucitons){
    for(int i = 0; i< seeds.Count; i++){
        foreach((Int64,Int64,Int64) inst in map){
            Int64 answer = respose(inst.Item1,inst.Item2,inst.Item3,seeds[i]);
            if (answer != seeds[i]){
                seeds[i] = answer;
                break;
            }
        }
    }
}
Console.WriteLine(seeds.Min());



List<(long,long)> seeds2 = [];

for (int i = 1; i< input[0].Split(' ').Length; i+=2){
    (long,long) seed2 = (long.Parse(input[0].Split(' ')[i]),(long.Parse(input[0].Split(' ')[i+1])));
    seeds2.Add(seed2);   
}

foreach ((Int64,Int64,Int64)[] map in instrucitons){
    List<(long,long)> possible= [];
    for(int i = 0; i< seeds2.Count; i++){
        foreach((Int64,Int64,Int64) inst in map){
            if (inst.Item2 > seeds2[i].Item1 && inst.Item2 < seeds2[i].Item1 + seeds2[i].Item2){
                long[] range = [seeds2[i].Item1 + seeds2[i].Item2 - inst.Item2, inst.Item3];
                (long,long) add = (inst.Item1,range.Min());
                possible.Add(add);
            }
            else if (inst.Item2 < seeds2[i].Item1 && inst.Item2+inst.Item3 > seeds2[i].Item1){
                long[] range = [inst.Item2 + inst.Item3 - seeds2[i].Item2, seeds2[i].Item2];
                (long,long) add = (seeds2[i].Item1,range.Min());
                possible.Add(add);
            }
        }
    }
}
