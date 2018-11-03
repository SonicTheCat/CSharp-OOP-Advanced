using System;
using System.Linq;

class StartUp
{
    static void Main()
    {
        MyStack<string> stack = new MyStack<string>();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            if (input == "Pop")
            {
                if (stack.Size == 0)
                {
                   Print("No elements");
                }
                else
                {
                    stack.Pop();
                }
            }
            else
            {
                var tokens = input
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Skip(1)
                    .ToArray();

                foreach (var token in tokens)
                {
                    stack.Push(token); 
                }
            }
        }
        Iterate(stack);
        Iterate(stack);
    }

    static void Iterate<U>(MyStack<U> stack)
    {
        foreach (var item in stack)
        {
            Print(item);
        }
    }

    static void Print<U>(U item)
    {
        Console.WriteLine(item);
    }
}