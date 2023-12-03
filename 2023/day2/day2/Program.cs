using System.Collections.ObjectModel;
using System.Net.Mail;

string[] input = File.ReadAllLines("input.in");

int result = 0;
Int64 powers = 0;

foreach (string line in input){
    string[] substrings = line.Split(" ");
    int red = 0;
    int minr = 0;
    int blue = 0;
    int minb = 0;
    int green = 0;
    int ming = 0;
    int failed = 0;

    for (int i = 3; i < substrings.Length; i += 2 ){
        if (substrings[i].Contains("red")){
            red += int.Parse(substrings[i-1]);

        }
        if (substrings[i].Contains("blue")){
            blue += int.Parse(substrings[i-1]);

        }
        if (substrings[i].Contains("green")){
            green += int.Parse(substrings[i-1]);

        }
        if (red> minr){minr = red;}
        if (blue >minb){minb = blue;}
        if (green > ming){ming = green;}
        
        if (substrings[i].Contains(';')){
            
            if (red <= 12 && green <= 13 && blue <= 14){
                red = 0;
                blue = 0;
                green = 0;
            }
            else {
                failed = 1;
                red = 0;
                blue = 0;
                green = 0;

            }
        }
        

    }
    if (red <= 12 && green <= 13 && blue <= 14 && failed == 0){
        string linenumber = substrings[1].Split(":")[0];

        result += int.Parse(linenumber);
    }
    Console.WriteLine(minr*minb*ming);
    powers += minr*minb*ming;



}
Console.WriteLine(result);
Console.WriteLine(powers);