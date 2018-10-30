using System;

class StartUp
{
    static void Main()
    {
        for (int i = 0; i < 3; i++)
        {
            var input = Console.ReadLine().Split();

            if (i == 0)
            {
                var name = input[0] + " " + input[1];
                var address = input[2];
                PrintTuple(new MyTuple<string, string>(name, address));
            }
            else if (i == 1)
            {
                var name = input[0];
                var countOfBeers = int.Parse(input[1]);
                PrintTuple(new MyTuple<string, int>(name, countOfBeers));
            }
            else
            {
                var integer = int.Parse(input[0]);
                var floatingPoint = double.Parse(input[1]);
                PrintTuple(new MyTuple<int, double>(integer, floatingPoint));
            }
        }
    }

    public static void PrintTuple<T, U>(MyTuple<T, U> tuple)
    {
        Console.WriteLine(tuple.FirstItem + " -> " + tuple.SecondItem);
    }
}