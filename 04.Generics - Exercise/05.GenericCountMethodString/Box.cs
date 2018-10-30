using System;

public class Box<T> : IComparable<T>
    where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value;
    }

    public int CompareTo(T element)
    {
        return this.value.CompareTo(element);
    }

    public override string ToString()
    {
        return $"{value.GetType().FullName}: {this.value}";
    }
}