using System.Text;

string[] pairs = File.ReadAllLines("input.in");

//Console.WriteLine(pairs[1]);
int count = 0;
foreach (string pair in pairs){
    string[] pairarray = pair.Split(',');
    string[] firstvalues = pairarray[0].Split('-');
    string[] secondvalues = pairarray[1].Split('-');
    int[] firstInts = [Int32.Parse(firstvalues[0]),Int32.Parse(firstvalues[1])];
    int[] secondInts = [Int32.Parse(secondvalues[0]),Int32.Parse(secondvalues[1])];




    if (firstInts[0]<= secondInts[0] & firstInts[1] >= secondInts[0]){
        count ++;
       
    }
    else if(firstInts[0]<=secondInts[1] & firstInts[1]>=secondInts[1]){
        count ++;
    }
    else if(firstInts[0]>=secondInts[0] & firstInts[1]<= secondInts[1]){
        count ++;
    }
    else{Console.WriteLine(pair);}

}

Console.WriteLine(count);

