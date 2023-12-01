using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Text;

string[] data = File.ReadAllLines("input.in");

int sum = 0;


foreach(string line in data){
    int[] thisline = findnumber(line);
    List<int> lineints = [];
    lineints.Add(thisline[0]);
    lineints.Add(thisline[^1]);
    
 

    StringBuilder str = new StringBuilder("",2);
    str.Append(lineints[0]);
    str.Append(lineints[1]);
    string String = str.ToString();
    sum += int.Parse(String);
}
Console.WriteLine(sum);


static int[] findnumber(string line){
    List<int> numbers = [];
    string[] letternumbers = ["zero","one","two","three","four","five","six","seven","eight","nine"];
    for (int letter = 0; letter < line.Length; letter++){
    //every char
        for (int number = 0; number < letternumbers.Length; number++){
            //compare with numbers
            if (letternumbers[number][0] == line[letter]){
                for (int nextletter = 1; nextletter< 10; nextletter ++){
                    if (letter+nextletter < line.Length){
                        if (letternumbers[number][nextletter] == line[letter+nextletter]){
                            if (nextletter >= letternumbers[number].Length-1){
                                numbers.Add(number);
                                break;
                                }
                        }
                        else {break;}
                    }
                }
                    
                }
            }
        if(line[letter]-48 < 10){numbers.Add(line[letter]-48);}
            
            
            }

            int[] arr = numbers.ToArray();
            return arr;
        }



