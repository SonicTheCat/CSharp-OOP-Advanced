using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var tokens = Console.ReadLine().Split();
        ListyIterator<string> iterator = new ListyIterator<string>(tokens.Skip(1).ToArray());

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            switch (input)
            {
                case "Move":
                    bool isMoved = iterator.Move();
                    iterator.Print(isMoved);
                    break;
                case "HasNext":
                    bool next = iterator.HasNext();
                    iterator.Print(next);
                    break;
                case "Print":
                    try
                    {
                        iterator.Print();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    break;
                case "PrintAll":
                    {
                        foreach (var element in iterator)
                        {
                            Console.Write(element + " ");
                        }
                        Console.WriteLine();
                    }
                    break; 
            }
        }
    }
}