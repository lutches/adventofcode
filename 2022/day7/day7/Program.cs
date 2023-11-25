using System.ComponentModel;
using System.Diagnostics.Tracing;
using System.Linq.Expressions;

string[] data = File.ReadAllLines("input.in");

int sum = 0;
List<int> storage = [];
/*
for (int i = 0; i < data.Length; i++){
    
    if (data[i] == "$ cd .."){
        //ignore
 
    }
    else if (data[i].Contains("cd")){
      
        int[] check = inspectdir(i,data);
        if(check[0]<= 100000){
            sum += check[0];
        }
    }
   
}
*/
for (int i = 0; i < data.Length; i++ ){
    if (data[i] == "$ cd ..");

    else if(data[i].Contains("cd")){
        int[] check = inspectdir (i,data);
        storage.Add(check[0]);
    }
}




static int[] inspectdir(int index, string[] data)
{
    int score = 0;
    
    /*foreach (string line in data){
        int i = 0;
        if (line.Contains("$ cd "+ name)){
            index = i;
        }
        else {
            i ++;
        }
    }
*/
    
    for (int i= 1; index + i <= data.Length-1; i++){
        string line = data[index + i];
        if (line == "$ cd .."){
            return [score, i];
        }
        else if (line.Contains("cd")){
            int[] answer = inspectdir(index+i, data);
            score += answer.First();
            i += answer.Last();
        }
        else if ("0123456789".Contains(line[0])){
            string[] readline = line.Split(' ');
            score += Int32.Parse(readline[0]);
        }
    }
    return [score, index];
}

//int[] intanswer = inspectdir(0,data);

//Console.WriteLine(intanswer[0]);


//Console.WriteLine(sum); 



int available = 70000000;

int needs = 30000000;

int used = inspectdir(0, data).First();

Console.WriteLine(51418875-43313415);

int canBeUsed = available - needs;

int further = used -canBeUsed;

// should be 3313415

//storage.Sort();



for (int i = 0; i< storage.Count; i++){
    if (storage[i] < further){
        storage.RemoveAt(i);
        i --;
    }
    else{break;} 
}


Console.WriteLine(storage[0]);

// 11759605 is to high