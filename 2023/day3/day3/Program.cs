

using System.Text;

string[] input = File.ReadAllLines("input.txt");

int sum = 0;

for(int y = 0; y < input.Length; y ++){
    string row = input[y];
    for(int x = 0; x < row.Length; x++){
        char column = row[x];
        if(column == '*'){
            (int,bool) result = findnumber(y,x,input);
            if(result.Item2){
                sum += result.Item1;
            }
        }
        }
    }


Console.WriteLine(sum);



static (int,bool) findnumber(int y, int x, string[] map){

    List<int> numbers = [];
    int xcheck = 2;
    int ycheck = 2;
    if (x>0){
        x--;
        xcheck++;
    }
    if(y>0){
        y--;
        ycheck++;
    }
    for (int i = 0; i< ycheck && i+y < map.Length; i++){
        for (int j = 0; j< xcheck && j+x < map[y].Length; j++){
            if (isnumber(map[i+y][j+x])){
                numbers.Add(stepper(j+x,map[i+y]));
                if (isnumber(map[i+y][j+x+1])){
                    break;
                }
            }
        }
    }
    if (numbers.Count == 2){
        Console.WriteLine(numbers[0].ToString() + " " + numbers[1].ToString());
        return(numbers[0]*numbers[1],true);
    }
    return (0,false);



}



static int stepper(int x, string row){
    int start = 0;
    StringBuilder str = new();
    for(int temp = x;temp>=0; temp--){
        if (!isnumber(row[temp])){
            start = temp+1;
            break;
        }
    }

    for (int steppy = start; steppy <row.Length; steppy++){
        if (isnumber(row[steppy])){
            str.Append(row[steppy]);
        }
        else {
            string build = str.ToString();
            return int.Parse(build);
        }
    }
    if (str.Length != 0){
        string build = str.ToString();
            return int.Parse(build);
    }
    else {
        return 0;
    }
}

/*

//try 2




using System.Text;

string[] input = File.ReadAllLines("input.txt");

int output = 0;

for (int y = 0; y< input.Length; y++){
    string row = input[y];
    for (int x = 0; x < row.Length; x++){
        
        char column = row[x];
        if (isnumber(column)){
            int number = wholenumber(x,row);
            int numberlength = number.ToString().Length;
            if (number == 633){
                Console.WriteLine(number);
            }
            if (checkarea(x,y,numberlength,input)){
                Console.WriteLine(number);
                output += number;
            }
            x += numberlength -1;
            
            
        }
    }
}
Console.WriteLine(output);

static int wholenumber(int x, string row){
    StringBuilder str = new();
    for(int columnm = x; x< row.Length && isnumber(row[x]); x++){
        str.Append(row[x]);
    }
    return int.Parse(str.ToString());
}

static bool checkarea(int x, int y, int length, string[] map){
    int tempx = x;
    int tempx2 = 1+length;
    if (tempx > 0){
        tempx --;
        tempx2 ++;
    }
    int tempy = y;
    int tempy2 = 2;
    if (tempy > 0){
        tempy --;
        tempy2 ++;
    }
    for (int i = 0; i+tempy < map.Length && i< tempy2 ; i++){
        for (int j = 0; j+tempx < map[i].Length && j <tempx2; j++){
            if (map[i+tempy][j+tempx] == '.' || isnumber(map[i+tempy][j+tempx]));
            else{
                return true;
            }
        }
    }
    return false;


}
*/

static bool isnumber(char number){
    if ("0123456789".Contains(number)){
        return true;
    }
    else {
        return false;
    }
}
