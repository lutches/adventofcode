string[] instructions = File.ReadAllLines("input.txt");


HashSet<(int,int)> places = [];

(int,int) distance = (0,0);

(int,int) tailcord = (0,0);

foreach (string instruction in instructions){
    string[] inst = instruction.Split(' ');

    

    for (int steps = 0; steps < Int32.Parse(inst.Last()); steps ++){


        places.Add(tailcord);
        

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
    }
}

Console.WriteLine(places.Count);


