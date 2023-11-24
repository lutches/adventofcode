

string data = File.ReadAllText("input.in");

int output = 0;
Console.WriteLine(data.Length);
HashSet<char> comps = [];

for (int i = 13; i < data.Length; i ++){

    for (int j = 0; j < 14; j++){
        comps.Add(data[i-j]);
    }

    if (comps.Count == 14){
        Console.WriteLine(comps.ToArray());
        output = i+1;
        break;
    }
    comps.Clear();
    
    
}  




Console.WriteLine(output);