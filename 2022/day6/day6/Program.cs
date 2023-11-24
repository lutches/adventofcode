

string data = File.ReadAllText("input.in");

int output = 0;
Console.WriteLine(data.Length);

for (int i = 3; i < data.Length; i ++){

    if (data[i-3] != data [i-2] 
    && data[i-3] != data[i-1] 
    && data[i-3] != data[i] 
    && data[i-2] != data[i-1] 
    && data[i-2] != data[i] 
    && data[i-1] != data[i]){

                output = i+1;
                break;
            }
        }



Console.WriteLine(output);