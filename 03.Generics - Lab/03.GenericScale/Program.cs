using System;

public class Program
{
    public static void Main()
    {
        Scale<string> scale = new Scale<string>("aaa", "aaz");
        Console.WriteLine(scale.GetHeavier());
    }
}