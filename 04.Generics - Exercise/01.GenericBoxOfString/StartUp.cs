using System;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(new Box<string>(Console.ReadLine()));
        }
    }
}