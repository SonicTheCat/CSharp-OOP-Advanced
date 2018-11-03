using System;

class StartUp
{
    static void Main()
    {
        var countOfLines = int.Parse(Console.ReadLine());
        LinkedList<int> collection = new LinkedList<int>(); 

        for (int i = 0; i < countOfLines; i++)
        {
            var command = Console.ReadLine().Split();
            var number = int.Parse(command[1]); 

            if (command[0] == "Add")
            {
                collection.Add(number); 
            }
            else if (command[0] == "Remove")
            {
                collection.Remove(number);
            }
        }

        Console.WriteLine(collection.Count);
        Console.WriteLine(string.Join(" ", collection));
    }
}