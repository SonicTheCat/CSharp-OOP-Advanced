using System;

public class Box<T>
    where T : IComparable<T>
{
    private T value;

    public Box(T value)
    {
        this.value = value; 
    }

    public int CompareTo(T other)
    {
        return this.value.CompareTo(other); 
    }

    public override string ToString()
    {
        return $"{value.GetType().FullName}: {this.value}";
    }
}