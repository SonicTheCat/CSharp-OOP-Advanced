using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    class StartUp
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            List<Box<string>> boxes = new List<Box<string>>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine();
                boxes.Add(new Box<string>(input));
            }

            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Swap<Box<string>>(boxes, indexes[0], indexes[1]);
            Print<Box<string>>(boxes);
        }

        public static void Print<T>(List<T> elements)
        {
            foreach (var element in elements)
            {
                Console.WriteLine(element);
            }
        }

        public static void Swap<T>(IList<T> elements, int idxOne, int idxTwo)
        {
            var fistElement = elements[idxOne];
            elements[idxOne] = elements[idxTwo];
            elements[idxTwo] = fistElement;
        }
    }
}