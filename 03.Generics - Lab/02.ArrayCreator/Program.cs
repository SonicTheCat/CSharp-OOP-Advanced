public class Program
{
    public static void Main()
    {
        string[] words = ArrayCreator.Create(5, "stamat");
        int[] numbers = ArrayCreator.Create(10, 1);

        foreach (var w in words)
        {
            System.Console.WriteLine(w);
        }
    }
}