using System;
using System.Collections.Generic;

public class ListyIterator<T>
{
    private IList<T> elements;
    private int internalIndex;

    public ListyIterator(params T[] elements)
    {
        this.Reset();
        this.elements = new List<T>(elements);
    }

    public bool HasNext()
    {
        return this.internalIndex < this.elements.Count - 1;
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.internalIndex++;
            return true;
        }
        return false;
    }

    public void Print()
    {
        if (this.elements.Count < 1)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }

        Print(this.elements[internalIndex]);
    }

    public void Print<U>(params U[] value)
    {
        Console.WriteLine(value[0]);
    }

    private void Reset()
    {
        this.internalIndex = 0;
    }
}