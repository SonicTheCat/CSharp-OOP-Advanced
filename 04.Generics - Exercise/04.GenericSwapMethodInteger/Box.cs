using System;

public class Box<T> 
{
    private T element;

    public Box(T value)
    {
        this.element = value;
    }   

    public override string ToString()
    {
        return $"{element.GetType().FullName}: {this.element}"; 
    }
}