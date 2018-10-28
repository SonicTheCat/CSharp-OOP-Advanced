public static class ArrayCreator 
{
    public static T[] Create<T>(int lenght, T item)
    {
        T[] arr = new T[lenght];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = item; 
        }
        return arr; 
    }
}