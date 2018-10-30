using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        List<Box<double>> collection = new List<Box<double>>();

        int lines = int.Parse(Console.ReadLine());
        for (int i = 0; i < lines; i++)
        {
            var value = double.Parse(Console.ReadLine()); 
            collection.Add(new Box<double>(value));
        }

        var element = double.Parse(Console.ReadLine());
        var resutl = FindGreaterElementsCount(collection, element);
        Console.WriteLine(resutl);
    }

    static int FindGreaterElementsCount<T>(List<Box<T>> collection, T element)
       where T : IComparable<T>
    {
        var counter = 0;
        foreach (var item in collection)
        {
            if (item.CompareTo(element) > 0)
            {
                counter++;
            }
        }
        return counter;
    }
}