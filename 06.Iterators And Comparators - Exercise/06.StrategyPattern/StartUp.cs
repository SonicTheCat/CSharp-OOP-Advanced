using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var countOfLines = int.Parse(Console.ReadLine());
        
        var list = new List<Person>(); 
        for (int i = 0; i < countOfLines; i++)
        {
            var toknes = Console.ReadLine().Split();
            list.Add(new Person(toknes[0], int.Parse(toknes[1]))); 
        }

        PrintSet(list, new NameComparer());
        PrintSet(list, new AgeComparer());
    }

    static void PrintSet<T>(List<Person> people, T comparer)
        where T : IComparer<Person>
    {
        SortedSet<Person> set = new SortedSet<Person>(people, comparer);

        foreach (var person in set)
        {
            Console.WriteLine(person);
        }
    }
}