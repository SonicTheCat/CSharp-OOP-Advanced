using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private T[] elements;

    public LinkedList()
    {
        this.Capacity = 4;
        this.Count = 0;
        this.elements = new T[this.Capacity];
    }

    public int Count { get; private set; }

    public int Capacity { get; private set; }

    public void Add(T element)
    {
        if (this.Count == this.Capacity)
        {
            this.IncreaseCapacity();
            var copiedArr = new T[this.Capacity];
            this.elements.CopyTo(copiedArr, 0);
            this.elements = copiedArr; 
        }

        this.elements[Count++] = element; 
    }

    public bool Remove(T element)
    {
        var indexFound = -1;
        for (int i = 0; i < this.Count; i++)
        {
            if (this.elements[i].Equals(element))
            {
                indexFound = i;
                break; 
            }
        }

        if (indexFound >= 0)
        {
            var decreaser = indexFound == 0 ? this.Count - indexFound - 1 : this.Count - indexFound;
            for (int i = indexFound; i < decreaser; i++)
            {
                this.elements[i] = this.elements[i + 1];
            }
            this.Count--;
            return true; 
        }

        return false; 
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.Count; i++)
        {
            yield return this.elements[i]; 
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

    private void IncreaseCapacity()
    {
        this.Capacity *= 2;
    }
}