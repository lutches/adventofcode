
using System.Text.Unicode;
using System.Xml.XPath;

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


for (int i = 0; i < instrucitons.Length; i++){
    (long,long,long)[] map = instrucitons[i];
    foreach ((long,long,long) inst in map){
        foreach ((long,long,long) nextinst in instrucitons[i+1]){
            
        }
    }
}