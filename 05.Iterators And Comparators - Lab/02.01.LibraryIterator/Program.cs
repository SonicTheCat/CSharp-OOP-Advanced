public class Program
{
    public static void Main()
    {
        Book bookOne = new Book("House of cards", 1989, "Michael Dobbs");
        Book bookTwo = new Book("Programing with C#", 2013, "Svetlin Nakov", "and", "Others");
        Book bookThree = new Book("Factotum", 1975);

        Library library = new Library(bookOne, bookTwo, bookThree);

        foreach (var book in library)
        {
            System.Console.WriteLine(book.Title);
        }

    }
}