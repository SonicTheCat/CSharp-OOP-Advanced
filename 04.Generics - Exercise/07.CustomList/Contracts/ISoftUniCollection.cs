public interface ISoftUniCollection<T>
{
    ulong Size { get; }

    ulong Capacity { get; }

    void Add(T element);

    T Remove(ulong index); 
}