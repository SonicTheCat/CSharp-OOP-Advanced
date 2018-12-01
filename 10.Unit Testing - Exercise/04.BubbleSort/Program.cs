namespace BubbleSortTest
{
    public class Program
    {
        static void Main()
        {
           // var collection = new int[] { 6, 5, 3, 1, 8, 7, 2, 4 };
            var collection = new int[] { 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 20, 1, 10001, 50 };

            var bubble = new Bubble();
            bubble.SortCollection(collection);
            System.Console.WriteLine();
        }
    }
}
