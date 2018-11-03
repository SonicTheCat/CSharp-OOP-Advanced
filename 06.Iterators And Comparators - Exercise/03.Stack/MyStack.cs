using System.Collections;
using System.Collections.Generic;

public class MyStack<T> : IEnumerable<T>
{
    private T[] elements;
    private int capacity;

    public MyStack()
    {
        this.capacity = 4;
        this.elements = new T[this.capacity];
    }

    public int Size { get; private set; }

    public void Push(T element)
    {
        if (this.Size == this.elements.Length)
        {
            var cloningArr = new T[this.capacity *= 2];
            this.elements.CopyTo(cloningArr, 0);
            this.elements = cloningArr;
        }

        this.elements[this.Size] = element;
        this.Size++;
    }

    public T Pop()
    {
        this.Size--;
        var element = this.elements[this.Size];
        this.elements[this.Size] = default(T);

        return element;
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = this.Size - 1; i >= 0; i--)
        {
            yield return this.elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}