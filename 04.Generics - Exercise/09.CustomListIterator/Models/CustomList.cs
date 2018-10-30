using System;
using System.Collections;
using System.Collections.Generic;

public class CustomList<T> : ISoftUniCollection<T>, ICoolCollection<T>, IEnumerable<T>
    where T : IComparable<T>
{
    private const string OUT_OF_RANGE_EXEPTION = "Current index was outside the bounds of the list!"; 

    private T[] items;
    private uint capacity;
    private uint size; 

    public CustomList()
    {
        this.capacity = 4;
        this.items = new T[capacity];
    }

    public uint Size => this.size;

    public uint Capacity => this.capacity; 


    //Set And Get Element At Given Index
    public T this[int index]
    {
        get
        {
            ValidateRange(index); 
            return this.items[index];
        }
        set
        {
            ValidateRange(index);
            this.items[index] = value; 
        }
    }

    public void Add(T value)
    {
        if (size == capacity)
        {
            var cloning = new T[capacity];
            this.items.CopyTo(cloning, 0);

            IncreaseCapacity();
            this.items = new T[capacity];
            cloning.CopyTo(this.items, 0);
        }

        items[size++] = value;
    }

    public T Remove(int index)
    {
        ValidateRange(index);

        T value = items[index];

        var cloning = new T[size - 1];
        var cloningCounter = 0;
        for (uint i = 0; i < size; i++)
        {
            if (i == index)
            {
                continue; 
            }

            cloning[cloningCounter++] = this.items[i]; 
        }
        this.items = new T[capacity];
        cloning.CopyTo(this.items, 0);
        size--; 

        return value; 
    }

    public bool Contains(T element)
    {
        for (uint i = 0; i < Size; i++)
        {
            if (items[i].Equals(element))
            {
                return true;
            }
        }
        return false;
    }

    public void Swap(int idxOne, int idxTwo)
    {
        var fistElement = items[idxOne];
        items[idxOne] = items[idxTwo];
        items[idxTwo] = fistElement;
    }

    public int CountGreaterThan(T element)
    {
        var counter = 0;
        for (uint i = 0; i < Size; i++)
        {
            if (items[i].CompareTo(element) > 0)
            {
                counter++;
            }
        }
        return counter;
    }

    public T Max()
    {
        T value = this.items[0];
        for (uint i = 0; i < Size; i++)
        {
            if (items[i].CompareTo(value) > 0)
            {
                value = items[i];
            }
        }
        return value;
    }

    public T Min()
    {
        T value = this.items[0];
        for (uint i = 0; i < Size; i++)
        {
            if (items[i].CompareTo(value) < 0)
            {
                value = items[i];
            }
        }
        return value; 
    }

    public override string ToString()
    {
        var cloning = new T[Size];

        for (uint i = 0; i < Size; i++)
        {
            cloning[i] = this.items[i]; 
        }
        return string.Join("\n", cloning); 
    }

    private void IncreaseCapacity()
    {
        capacity *= 2;
    }

    private void ValidateRange(int index)
    {
        if ((uint)index < 0 || (uint)index >= size)
        {
            throw new IndexOutOfRangeException(OUT_OF_RANGE_EXEPTION);
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < Size; i++)
        {
            yield return this.items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int i = 0; i < Size; i++)
        {
            yield return this.items[i];
        }
    }
}