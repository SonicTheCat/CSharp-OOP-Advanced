using System;
using System.Collections.Generic;

public class Book : IComparable<Book>
{
    public Book(string title, int year, params string[] authors)
    {
        this.Title = title;
        this.Year = year;
        this.Authors = authors;
    }

    public string Title { get; set; }

    public int Year { get; set; }

    public IList<string> Authors { get; set; }

    public int CompareTo(Book other)
    {
        if (this.Year != other.Year)
        {
            return this.Year.CompareTo(other.Year); 
        }

        return this.Title.CompareTo(other.Title); 
    }

    public override string ToString()
    {
        return $"{this.Title} - {this.Year}"; 
    }
}