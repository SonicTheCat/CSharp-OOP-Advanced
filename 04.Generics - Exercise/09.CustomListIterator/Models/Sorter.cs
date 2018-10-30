using System;

public class Sorter
{
    public static void Sort<T>(CustomList<T> customList)
        where T : IComparable<T>
    {
        for (int i = 0; i < customList.Size - 1; i++)
        {
            for (int j = i + 1; j < customList.Size; j++)
            {
                if (customList[i].CompareTo(customList[j]) > 0)
                {
                    customList.Swap(i, j);
                }
            }
        }
    }
}