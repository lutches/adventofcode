using System;
using System.Collections.Immutable;
using System.Globalization;
using System.IO;
using System.Numerics;
using System.Reflection.Metadata;

class Program
{
    static void Main()
    {
        string fileContent = File.ReadAllText("input.in");
        //Console.WriteLine(fileContent);

        string[] elfs = fileContent.Split("\n\n");
        int[] elftotal = new int[elfs.Length];

        for (int i = 0; i < elfs.Length; i++)
        {
            string[] elf = elfs[i].Split("\n");
            int total = 0;
            for (int j = 0; j < elf.Length; j++)
            {
                string[] ing = elf[j].Split(" ");
                total += int.Parse(ing[ing.Length - 1]);
            }
            elftotal[i] = total;
        }

        Array.Sort(elftotal);
        foreach (int i in elftotal)
            Console.WriteLine(i);
    }
}
