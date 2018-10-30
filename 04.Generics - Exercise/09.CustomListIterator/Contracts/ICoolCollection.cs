public interface ICoolCollection<T>
{
    bool Contains(T element);

    void Swap(int index1, int index2);

    int CountGreaterThan(T element);

    T Max();

    T Min(); 
}