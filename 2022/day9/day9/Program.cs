using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Security.AccessControl;

string[] instructions = File.ReadAllLines("input.txt");


HashSet<(int,int)> places = [];

HashSet<(int,int)> headplaces = [];
/*
(int,int) distance = (0,0);

(int,int) tailcord = (0,0);

foreach (string instruction in instructions){
    string[] inst = instruction.Split(' ');

    

    for (int steps = 0; steps < Int32.Parse(inst.Last()); steps ++){


        
        

        string direction = inst.First();
        if (direction == "R"){
            distance.Item1 += 1;
        }
        if (direction == "L"){
            distance.Item1 -= 1;
        }
        if (direction == "U"){
            distance.Item2 += 1;
        }
        if (direction == "D"){
            distance.Item2 -= 1;
        }

        if (distance.Item1 > 1|| distance.Item1 < -1){
            if (distance.Item1 > 1){
                tailcord.Item1 += distance.Item1-1;
                tailcord.Item2 += distance.Item2;
                distance = (1,0);
            }
            else{
                tailcord.Item1 += distance.Item1+1;
                tailcord.Item2 += distance.Item2;
                distance = (-1,0);
            }
            
        }

        if (distance.Item2 > 1 || distance.Item2 < -1){
            if (distance.Item2 > 1){
                tailcord.Item2 += distance.Item2-1;
                tailcord.Item1 += distance.Item1;
                distance = (0,1);
            }
            else {
                tailcord.Item2 += distance.Item2+1;
                tailcord.Item1 += distance.Item1;
                distance = (0,-1);
            }
            
        }

        places.Add(tailcord);
    }
}

Console.WriteLine(places.Count);

*/
static (int,int) moveafter((int,int) previous,(int,int) current){
    if(Math.Abs(previous.Item1 - current.Item1)> 1 || Math.Abs(previous.Item2-current.Item2)>1){

        (int,int) distance = (previous.Item1-current.Item1, previous.Item2-current.Item2);
        (int,int) response = (0,0);

        if (distance.Item1 > 1){
            response.Item1 = current.Item1 + 1;
            response.Item2 = previous.Item2; 
        }
        if (distance.Item1 < -1){
            response.Item1 = current.Item1 - 1;
            response.Item2 = previous.Item2;
        }
        if (distance.Item2 > 1){
            response.Item2 = current.Item2 + 1;
            response.Item1 = previous.Item1;
        }
        if (distance.Item2 < -1) {
            response.Item2 = current.Item2 - 1;
            response.Item1 = previous.Item1;
        }

        return response;
    }
    else {return current;}
}


int length = 10;
List<(int,int)> rope = [];
for (int i = 0; i < length; i++){
        rope.Add((0,0));
    }

foreach (string instruction in instructions){
    string[] inst = instruction.Split(' ');
    
    

    for (int steps = 0; steps < Int32.Parse(inst.Last()); steps ++){
        string direction = inst.First();

        if (direction == "R"){
            rope[0] = (rope[0].Item1 + 1, rope[0].Item2);
        }
        if (direction == "L"){
            rope[0] = (rope[0].Item1 - 1, rope[0].Item2);
        }
        if (direction == "U"){
            rope[0] = (rope[0].Item1, rope[0].Item2 + 1);
        }
        if (direction == "D"){
            rope[0] = (rope[0].Item1, rope[0].Item2 - 1);
        }

        for (int knot = 1; knot < rope.Count; knot++){
            rope[knot] = moveafter(rope[knot-1],rope[knot]);
        }
        places.Add(rope[^1]);

    }
    
    
    
}
Console.WriteLine(places.Count);

//2583 is to high
//not off by one error
