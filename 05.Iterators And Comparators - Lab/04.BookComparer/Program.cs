using System;

public class Program
{
    public static void Main()
    {
        Book bookZero = new Book("Zero", 2013);
        Book bookOne = new Book("House of cards", 1989, "Michael Dobbs");
        Book bookTwo = new Book("Programing with C#", 2013, "Svetlin Nakov", "and", "Others");
        Book bookThree = new Book("Factotum", 1975);

        Library library = new Library(bookZero, bookOne, bookTwo, bookThree);

        foreach (var book in library)
        {
            Console.WriteLine(book);
        }
    }
}