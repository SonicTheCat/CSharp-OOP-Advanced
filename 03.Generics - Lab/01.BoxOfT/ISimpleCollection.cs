public interface ISimpleCollection<T>
{
    int Count { get; }

    void Add(T element);

    T Remove();
}