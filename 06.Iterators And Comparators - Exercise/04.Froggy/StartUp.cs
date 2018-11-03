using System;
using System.Collections.Generic;
using System.Linq;

public class StartUp
{
    public static void Main()
    {
        var stones = Console.ReadLine()
                   .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                   .Select(int.Parse)
                   .ToArray();

        Lake lake = new Lake(stones); 

        Console.WriteLine(string.Join(", ", lake));
    }
}