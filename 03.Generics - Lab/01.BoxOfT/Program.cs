using System;
using System.Collections.Generic;

namespace BoxOfT
{
    class Program
    {
        static void Main()
        {
            ISimpleCollection<int> boxNumbers = new Box<int>();

            boxNumbers.Add(1);
            boxNumbers.Add(1000);
            boxNumbers.Add(16);
            boxNumbers.Add(123131);
            boxNumbers.Add(324);

            ISimpleCollection<string> textBox = new Box<string>();

            textBox.Add("Pael");
            textBox.Add("sa");
            textBox.Add("Ligael");

            Console.WriteLine(boxNumbers.Remove());
            Console.WriteLine(boxNumbers.Count);

            Console.WriteLine(boxNumbers.Remove());
            Console.WriteLine(boxNumbers.Count);
         
            Console.WriteLine(textBox.Remove());
            Console.WriteLine(textBox.Count);
        }

        //private static void PrintGenerics<T>(IBox<int> boxNumbers)
        //{
        //    throw new NotImplementedException();
        //}

        //public static void PrintGenerics<T>(IBox<int> elements)
        //{
        //    foreach (var el in elements)
        //    {
        //        Console.WriteLine(el);
        //    }
        //}
    }
}