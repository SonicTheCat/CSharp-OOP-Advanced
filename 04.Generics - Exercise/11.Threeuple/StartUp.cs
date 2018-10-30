using System;

public class StartUp
{
    public static void Main()
    {
        for (int i = 0; i < 3; i++)
        {
            var input = Console.ReadLine().Split();
            var name = input[0];

            if (i == 0)
            {
                name += " " + input[1];
                var address = input[2];
                var town = input[3];
                PrintTuple(new MyTuple<string, string, string>(name, address, town));
            }
            else if (i == 1)
            {
                var countOfBeers = int.Parse(input[1]);
                bool drunk = input[2] == "drunk" ? true : false;
                PrintTuple(new MyTuple<string, int, bool>(name, countOfBeers, drunk));
            }
            else
            {
                var accountBalance = double.Parse(input[1]);
                var bankName = input[2];
                PrintTuple(new MyTuple<string, double,string>(name, accountBalance, bankName));
            }
        }
    }

    public static void PrintTuple<T1, T2, T3>(MyTuple<T1, T2, T3> tuple)
    {
        Console.WriteLine(tuple.FirstItem + " -> " + tuple.SecondItem + " -> " + tuple.ThirdItem);
    }
}