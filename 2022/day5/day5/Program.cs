// import file

using System.ComponentModel.DataAnnotations;
using System.Collections;

string[] origin = File.ReadAllLines("input.in");


List<string> strings = [];

foreach (string line in origin){
    if (line.Contains('[')){
        strings.Add(line);
    }
}
strings.Reverse();

List<List<char>> stacks = [];

foreach (string line in strings){
    int stackpointer = 0;

    for (int i = 1; i < 36; i += 4){
        if (line[i] != ' '){
        if (stacks.Count <= stackpointer){
            stacks.Add([]);
            stacks[stackpointer].Add(line[i]);
        }
        else {
            stacks[stackpointer].Add(line[i]);
        } }

        stackpointer ++;
        
    }
}

List<List<int>> operations = [];
foreach (string line in origin){
    if (line.Contains("move")){
        string[] temp = line.Split(" from ");
        string[] tempfrst = temp[0].Split("move ");
        string[] tempscnd = temp[1].Split(" to ");

        int first = Int32.Parse(tempfrst[1]);
        int second = Int32.Parse(tempscnd[0]);
        int third = Int32.Parse(tempscnd[1]);

        operations.Add([first,second,third]);
    }
}

/*
foreach (List<int> operation in operations){
    for (int i = 0; i < operation[0]; i++){
        char moveable = stacks[operation[1]-1].Last();
        stacks[operation[1]-1].RemoveAt(stacks[operation[1]-1].Count-1);

        stacks[operation[2]-1].Add(moveable);
    }
}
*/

foreach (List<int> operation in operations){
    List<char> moveable = [];
    for (int i = 0; i < operation[0]; i++){
        moveable.Add(stacks[operation[1]-1].Last());
        stacks[operation[1]-1].RemoveAt(stacks[operation[1]-1].Count-1);
    }
    moveable.Reverse();
    stacks[operation[2]-1].AddRange(moveable);
}
foreach (List<char> stack in stacks){
    Console.WriteLine(stack.Last());
}
