using System.Data;
using System.Transactions;

string[] lines = File.ReadAllLines("input");

int output = 0;
List<int> multipliers = [1,1,1,1,1,1,1,1,1,1];
foreach (string line in lines){
    int score = 0;
    int thismultiplier = multipliers[0];


    string[] split = line.Split('|');
    string psplitnumber = split[1];
    List<int> playernumbers = [];
    foreach (string number in psplitnumber.Split(' ')){
            if (number.Length != 0){
                playernumbers.Add(int.Parse(number));
        }     
    }
    string[] wsplitnumbers = split[0].Split(":")[1].Split(' ');
    List<int> winningnumbers = [];
    foreach (string number in wsplitnumbers){
        if (number.Length != 0){
            winningnumbers.Add(int.Parse(number));
    }
    }
    int[] warr = winningnumbers.ToArray();

    foreach (int playernumber in playernumbers){
        if (warr.Contains(playernumber)){
            score +=1;}
            
        }
    

    for (int i = 1; i < 10; i++){
        multipliers[i-1] = multipliers[i];
    }
    multipliers[9] = 1;
    for (int i = 0; i < score; i++){
        multipliers[i] += 1*thismultiplier;
    }
    output += 1*thismultiplier;
    
    

}
Console.WriteLine(output);