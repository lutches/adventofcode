using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

String[] items = File.ReadAllLines("input.in");

int output = 0;
int runs = 0;
int additions = 0;
char[] outputchars = [];
foreach (string bag in items)
{
    int halfsize = bag.Length/2;

    string halfbag1 = bag.Substring(0,halfsize);
    string halfbag2 = bag.Substring(halfsize, halfsize);
    runs ++;
    foreach (char i in halfbag1){
        if (halfbag2.Contains(i))
        {
            additions ++;
            if (i >= 'A' && i <= 'Z'){
                int value = (int) i - 38;
                output += value;
            }
            
            else{
                int value = (int) i - 96;
                output += value;
            }
            //Console.WriteLine(halfbag1.Length == halfbag2.Length);
            break;
            
        }
        
    }
}
//Console.WriteLine(output);
int count = 0;
runs = 0;
additions = 0;
for (int i = 0; i < items.Length; i += 3) {
    runs ++;
    foreach (char letter in items[i]){

        if (items[i+1].Contains(letter) & items[i+2].Contains(letter)){
            additions ++;
            if (letter >= 'A' && letter <= 'Z'){
                int value = (int) letter - 38;
                count += value;
            }
            
            else{
                int value = (int) letter - 96;
                count += value;
            }
            break;

        }
    }
}
Console.WriteLine(count);
Console.WriteLine(runs);
Console.WriteLine(additions);
