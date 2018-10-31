using System;
using System.Collections.Generic;

public class Program
{
    public static void Main()
    {
        Book book = new Book("pael", 212121); 
        Book book2 = new Book("pael", 212121, "Djon Sina", "BY Ivan", "BAt gergi");

        Library libraryOne = new Library();
        Library libraryTwo = new Library(book, book2);

        foreach (var b in libraryTwo)
        {
            Console.WriteLine(b.Title);
        }
    }
}

