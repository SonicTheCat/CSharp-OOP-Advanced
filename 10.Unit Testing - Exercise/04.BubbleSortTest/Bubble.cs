namespace BubbleSortTest
{
    public class Bubble
    {
        public void SortCollection(int[] collection)
        {
            int count = 1;

            while (true)
            {
                bool found = false;
                for (int i = 0; i < collection.Length - count; i++)
                {
                    if (collection[i] > collection[i + 1])
                    {
                        var temp = collection[i];
                        collection[i] = collection[i + 1];
                        collection[i + 1] = temp;
                        found = true;
                    }
                }
                count++;

                if (!found)
                {
                    break;
                }
            }
        }
    }
}