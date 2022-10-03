using System.Collections;

namespace Lab1
{
    internal struct MyArray<T> : IEnumerable<T>, IEnumerator<T> //interfaces for loops  
    {
        int count = 0;
        public int Count { get => count; } // array size
        T[] array;
        public T[] Array { get => array; } 


        public MyArray(int size = 1)
        {
            array = new T[size];
            count = array.Length;
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
        int position = -1;

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
