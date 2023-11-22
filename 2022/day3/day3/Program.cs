using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

String[] items = File.ReadAllLines("input.in");

int output = 0;
foreach (string bag in items)
{
    int halfsize = bag.Length/2;

    string halfbag1 = bag.Substring(0,halfsize-1);
    string halfbag2 = bag.Substring(halfsize, halfsize-1);
    if (halfbag1.Length == halfbag2.Length)
    {
        Console.WriteLine("True");
    }
    Console.WriteLine(halfbag1);
    Console.WriteLine(halfbag2);
    foreach (char i in halfbag1){
        if (halfbag2.Contains(i))
        {
            Console.WriteLine(i);
            if (i >= 'A' && i <= 'Z'){
                int value = (int) i - 38;
                output += value;
            }
            else{
                int value = (int) i - 96;
                output += value;
            }
            
        }
        
    }
}
Console.WriteLine(output);
