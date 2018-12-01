using System;
using System.Collections.Generic;
using System.Linq;

namespace ListIteratorTask
{
    public class ListIterator<T>
    {
        private List<T> collection;
        private int currentIndex;

        public ListIterator(params T[] elements)
        {
            SetUpElementsInCollection(elements);
            this.currentIndex = 0;
        }

        private void SetUpElementsInCollection(params T[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("Invalid argument!");
            }

            bool anyNullElement = elements.Any(e => e == null);

            if (anyNullElement)
            {
                throw new ArgumentNullException("A value can not be null!");
            }

            this.collection = new List<T>(elements);
        }

        public bool HasNext() => this.currentIndex < this.collection.Count - 1;

        public bool Move()
        {
            if (HasNext())
            {
                this.currentIndex++;
                return true;
            }
            return false;
        }

        public T Print()
        {
            if (this.collection.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }

            return this.collection[this.currentIndex];
        }
    }
}