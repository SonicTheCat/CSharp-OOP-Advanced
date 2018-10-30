public interface ISoftUniCollection<T>
{
    uint Size { get; }

    uint Capacity { get; }

    void Add(T element);

    T Remove(int index); 
}