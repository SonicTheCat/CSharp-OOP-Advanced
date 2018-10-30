using System;

public class CustomList<T> : ISoftUniCollection<T>, ICoolCollection<T>
    where T : IComparable<T>
{
    private T[] items;
    private ulong capacity;
    private ulong size; 

    public CustomList()
    {
        this.capacity = 4;
        this.items = new T[capacity];
    }

    public ulong Size => this.size;

    public ulong Capacity => this.capacity; 

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

    public T Remove(ulong index)
    {
        if (index < 0 || index >= size)
        {
            throw new IndexOutOfRangeException("Current index was outside the bounds of the list!");
        }

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
        for (ulong i = 0; i < Size; i++)
        {
            if (items[i].Equals(element))
            {
                return true;
            }
        }
        return false;
    }

    public void Swap(ulong idxOne, ulong idxTwo)
    {
        var fistElement = items[idxOne];
        items[idxOne] = items[idxTwo];
        items[idxTwo] = fistElement;
    }

    public int CountGreaterThan(T element)
    {
        var counter = 0;
        for (ulong i = 0; i < Size; i++)
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
        for (ulong i = 0; i < Size; i++)
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
        for (ulong i = 0; i < Size; i++)
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

        for (ulong i = 0; i < Size; i++)
        {
            cloning[i] = this.items[i]; 
        }
        return string.Join("\n", cloning); 
    }

    private void IncreaseCapacity()
    {
        capacity *= 2;
    }
}