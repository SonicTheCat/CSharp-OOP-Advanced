public interface ICoolCollection<T>
{
    bool Contains(T element);

    void Swap(ulong index1, ulong index2);

    int CountGreaterThan(T element);

    T Max();

    T Min(); 
}