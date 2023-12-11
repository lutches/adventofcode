string[] input = File.ReadAllLines("input.in");

List<(string, int, List<int>)> hands = [];


foreach (string hand in input){
    string[] sphand = hand.Split(" ");
    (string, int, List<int>) pHand = (sphand[0].Replace("T","a").Replace("J","b").Replace("Q","c").Replace("K","d").Replace("A","e"), int.Parse(sphand[1]), []);
    hands.Add(pHand);
}

for (int i = 0; i< hands.Count; i++){
    (string, int, List<int>) hand = hands[i];
    string chand = hand.Item1;
    foreach (char value in hand.Item1){
        int count = chand.Length - chand.Replace(value.ToString(), "").Length;
        chand = chand.Replace(value.ToString(), "");
        if (count > 1){
            if (count >3){
                hand.Item3.Add(4);
            }
            else if (count > 2){
                hand.Item3.Add(3);
            }
            else {
                hand.Item3.Add(2);
            }
        }
    }
}


List<string> fives = [];
List<string> fours = [];
List<string> fullhouse = [];
List<string> threes = [];
List<string> twopairs = [];
List<string> pairs = [];
List<string> suckies = [];

foreach((string, int, List<int>) hand in hands){
    if (hand.Item3.Count > 1){
        if (hand.Item3.Contains(3)){
            fullhouse.Add(hand.Item1+ " " + hand.Item2);
        }
        else {
            twopairs.Add(hand.Item1+ " " + hand.Item2);
        }
    }
    else if (hand.Item3.Count == 1){
        if (hand.Item3.Contains(5)){
            fives.Add(hand.Item1+ " " + hand.Item2);
        }
        if (hand.Item3.Contains(4)){
            fours.Add(hand.Item1+ " " + hand.Item2);
        }
        if (hand.Item3.Contains(3)){
            threes.Add(hand.Item1+ " " + hand.Item2);
        }
        if (hand.Item3.Contains(2)){
            pairs.Add(hand.Item1+ " " + hand.Item2);
        }
    }
    else if (hand.Item3.Count == 0){
        suckies.Add(hand.Item1+ " " + hand.Item2);
    }
}

List<string> sorted = [];
fives.Sort();

List<string> suckielist = [];

foreach (string suckie in suckies){
    string temp = suckie.Max()+ " " + suckie;
    suckielist.Add(temp);
}
suckielist.Sort();

suckies.Clear();
foreach (string suck in suckielist){
    suckies.Add(suck.Split(" ")[1] + " "+ suck.Split(" ")[2]);
}

sorted.AddRange(suckies);

pairs.Sort();
sorted.AddRange(pairs);

twopairs.Sort();
sorted.AddRange(twopairs);

threes.Sort();
sorted.AddRange(threes);

fullhouse.Sort();
sorted.AddRange(fullhouse);

fours.Sort();
sorted.AddRange(fours);

fives.Sort();
sorted.AddRange(fives);




int output = 0;
for (int i = 0; i < sorted.Count; i++){
    output += int.Parse(sorted[i].Split(" ")[1]) * (i+1);
    Console.WriteLine(sorted[i] +" "+ (i+1));
    
}

Console.WriteLine(output);

// 253915307 is to low
// 254065498 is to low
// 254597030 is wrong
// 253685770


