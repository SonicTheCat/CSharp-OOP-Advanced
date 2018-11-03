using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    public readonly List<int> pathOfStones;

    public Lake(IEnumerable<int> stones)
    {
        this.pathOfStones = new List<int>(stones); 
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < pathOfStones.Count; i++)
        {
            if (i % 2 == 0)
            {
                yield return this.pathOfStones[i]; 
            }
        }

        for (int i = this.pathOfStones.Count - 1; i >= 0; i--)
        {
            if (i % 2 != 0)
            {
                yield return this.pathOfStones[i]; 
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}