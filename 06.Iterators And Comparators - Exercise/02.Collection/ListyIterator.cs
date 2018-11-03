using System;
using System.Collections;
using System.Collections.Generic;

public class ListyIterator<T> : IEnumerable<T>
{
    private IList<T> elements;
    private int internalIndex;

    public ListyIterator(ICollection<T> elements)
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

    public IEnumerator<T> GetEnumerator()
    {
        foreach (var item in this.elements)
        {
            yield return item; 
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator(); 
    }

    private void Reset()
    {
        this.internalIndex = 0;
    }
}