using System;
using System.Collections.Generic;

public class StartUp
{
    public static void Main()
    {
        var people = new List<Person>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            var tokens = input.Split();

            var name = tokens[0];
            var age = int.Parse(tokens[1]);
            var town = tokens[2];

            people.Add(new Person(name, age, town));
        }

        var n = int.Parse(Console.ReadLine());

        var person = people[n - 1];
        var samePeople = 0;

        foreach (var p in people)
        {
            if (person.CompareTo(p) == 0)
            {
                samePeople++;
            }
        }

        if (samePeople == 1)
        {
            Console.WriteLine("No matches");
        }
        else
        {
            Console.WriteLine($"{samePeople} {people.Count - samePeople} {people.Count}");
        }
    }
}