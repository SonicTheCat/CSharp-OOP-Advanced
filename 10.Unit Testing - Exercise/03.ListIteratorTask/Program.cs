using System;

namespace ListIteratorTask
{
    class Program
    {
        static void Main(string[] args)
        {
            ListIterator<string> collection = new ListIterator<string>("Hasan", "Stamat", "Pesho");

            collection.Print();
            Console.WriteLine(collection.HasNext());
            collection.Move();
            Console.WriteLine(collection.HasNext());
            collection.Print();
            collection.Move();
            Console.WriteLine(collection.HasNext());
            collection.Print();
        }
    }
}