// treetop tree house

using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.InteropServices;

string[] read = File.ReadAllLines("input.txt");

// convert

List<int[]> templist = [];
foreach(string treeline in read){
    int index = 0;
    List<int> temp = [];
    foreach (char tree in treeline){
        int treeint = tree - '0';
        temp.Add(treeint);
    }
    int[] temp1 = temp.ToArray();
    templist.Add(temp1);
    index ++;
}

int[][] treeheights = templist.ToArray();

int visibleTrees = 0;

for (int i = 0; i< treeheights.Length; i++){
    int[] treeline = treeheights[i];
    if (i == 0 || i == treeheights.Length-1){
        visibleTrees += treeheights.Length;

    }
    else{
        for (int j = 0; j< treeline.Length; j ++){
            if (j == 0 ^ j == treeline.Length-1){
                visibleTrees ++;

            }
            else if(visible(i,j,treeheights)){
                    visibleTrees ++;
                }
            

    }

        
    }
}

/*

for (int i = 0; i < treeheights.Length; i++){
    int[] treeline = treeheights[i];
    for (int j = 0; j < treeline.Length; j++){
        if (visible(i,j,treeheights)){
            visibleTrees++;
        }
    }
}
*/
Console.WriteLine(visibleTrees);


static bool visible(int i, int j, int[][] treeheights){
    int tree = treeheights[i][j];

    int covered = 0;

    int[][] x = intarrsplit(treeheights[i],j);

    foreach (int[] subs in x){
        foreach (int comptree in subs){
            if (comptree >= tree){
                covered ++;
                break;
            }
            
        }
        
    }
    if(covered < 2){return true;} // small speedup

    List<int> ylist = [];

    foreach (int[] treeline in treeheights){
        ylist.Add(treeline[j]);
    }
    int[][] y = intarrsplit(ylist.ToArray(),i);


    foreach (int[] subs in y){
        foreach (int comptree in subs){
            if (comptree >= tree){
                covered ++;
                break;
            }
            
        }
    }
    if (covered >= 4){
        

        return false;
        }
    return true;
}


static int[][] intarrsplit(int[] tosplit, int spliton){
    int[] first = tosplit.Take(spliton).ToArray();
    int[] last = tosplit.Skip(spliton+1).ToArray();
    return [first,last];
}

// part II

static int lineview(int index, int[] line){
    int[][] split = intarrsplit(line,index);
    List<int> first = [];
    foreach (int Int in split[0]){
        first.Add(Int);
    }
    first.Reverse();
    first.ToArray();
    int[] second = split[1];

    if (first.Count == 0 || second.Length ==0){
        return 0;
    }

    int score = 0;
 
    foreach (int tree in first){
        score ++;
        if (tree >= line[index]){
            break;
        }
    }
    

    int secondint = 0;
    foreach (int tree in second){
        secondint ++;
        if(tree>=line[index]){
            break;
        }
    }

    score *= secondint;
    
    
    return score;




}

int bestscore = 0;

int iindex = 0;
int jindex = 0;
foreach (int[] line in treeheights){
    jindex = 0;
    foreach (int tree in line){
        int thisscore = score(iindex, jindex, treeheights);
        if(thisscore > bestscore){
            bestscore = thisscore;
        }
        jindex ++;
    }
    iindex ++;
}

Console.WriteLine(bestscore);

static int score(int i, int j, int[][] treeheights){
    int score = 0;
    score += lineview(j,treeheights[i]);

    List<int> y = [];
    foreach(int[]line in treeheights){
        y.Add(line[j]);
    }
    int[] yarr = y.ToArray();
    score *= lineview(i,yarr);

    return score; 
}

