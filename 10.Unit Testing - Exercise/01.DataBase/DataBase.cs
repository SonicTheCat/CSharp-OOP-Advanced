using System;
using System.Linq;

namespace DataBaseNameSpace
{
    public class DataBase
    {
        private const int DefaultCapacity = 16;

        private int[] arr;
        private int size;

        public DataBase(params int[] elements)
        {
            this.arr = new int[DefaultCapacity];
            this.size = 0;
            this.SetInitialElements(elements);
        }

        public int Size => this.size; 

        private void SetInitialElements(params int[] elements)
        {
            if (elements.Length > DefaultCapacity)
            {
                throw new InvalidOperationException("Invalid Capacity!");
            }

            elements.CopyTo(this.arr, 0);
            this.size = elements.Length; 
        }

        public void Add(int number)
        {
            if (this.size >= DefaultCapacity)
            {
                throw new InvalidOperationException("No more space in the array!");
            }

            this.arr[size++] = number;
        }

        public int Remove()
        {
            if (this.size <= 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            return this.arr[--size];
        }

        public int[] Fetch() => this.arr.Take(size).ToArray();
    }
}