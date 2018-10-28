using System.Collections.Generic;

public class Box<T> : ISimpleCollection<T>
{
    private IList<T> collection;

    public Box()
    {
        collection = new List<T>();
    }

    public int Count => this.collection.Count;

    public void Add(T element)
    {
        collection.Add(element);
    }

    public T Remove()
    {
        var last = collection[collection.Count - 1];
        collection.RemoveAt(collection.Count - 1);
        return last;
    }
}