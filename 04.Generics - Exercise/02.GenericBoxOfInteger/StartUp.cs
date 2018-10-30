using System;

public class StartUp
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var number = int.Parse(Console.ReadLine()); 
            Console.WriteLine(new Box<int>(number));
        }
    }
}