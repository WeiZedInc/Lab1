using System;
using System.Collections;
using System.Collections.Generic;

public interface IIndexInterface<T>
{
    // Indexer declaration:
    public T this[int index]
    {
        get;
        set;
    }
}

namespace Lab1Core
{
    public struct MyArray<T> : IEnumerable<T>, IEnumerator<T>, IIndexInterface<T> //interfaces for loops  
    {
        int count;
        public int Count { get => count; } // array size
        T[] array;
        public T[] Array { get => array; }


        public MyArray(int size = 1, int count = 0, int position = -1)
        {
            array = new T[size];
            count = array.Length;
            this.count = count;
            this.position = position;
        }

        public T Min() 
        {
            dynamic smallest = array[0];
            for (int i = 0; i < count; i++)
            {
                if (array[i] < smallest)
                    smallest = array[i];
            }
            return smallest;
        }

        public T Max()
        {
            dynamic largest = array[count];
            for (int i = 0; i < count; i++)
            {
                if (array[i] > largest)
                    largest = array[i];
            }
            return largest;
        }

        public bool Contains(T value)
        {
            foreach (T elment in array)
            {
                if (elment.Equals(value))
                    return true;
            }
            return false;
        }

        public T this[int index]  //indexator
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        #region interface implemetation
        int position;

        public T Current
        {
            get { try { return array[position]; } catch (IndexOutOfRangeException) { throw new InvalidOperationException(); } }
        }

        object IEnumerator.Current => Current;

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)array).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => array.GetEnumerator();

        public bool MoveNext()
        {
            position++;
            return (position < array.Length);
        }

        public void Reset() => position = -1;

        public void Dispose() => array = new T[0];

        #endregion

    }
}
