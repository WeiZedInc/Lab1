using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;

namespace Lab1
{
    public class MyList<T> : IEnumerable<T>, IEnumerator<T> // interfaces for acessing loops
    {
        int count = 0; 
        public int Count { get => count; } // array size

        T[] array = new T[1]; //list based on generic array
        public T[] Array { get => array; } // array size
        int index = -1; 

        public void Clear() 
        {
            array = new T[1];
            count = 0;
            index = -1;
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

        public void Add(T mass) 
        {
            count++;
            System.Array.Resize(ref this.array, count);
            index++; 
            this.array[index] = mass; 
        }
        public T this[int index]  //indexator, list[]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        #region interface implemetation
        int position = -1;
        public bool MoveNext() 
        {
            position++;
            return (position < array.Length);
        }

        public void Reset() => position = -1; 

        public T Current
        {
            get { try { return array[position]; } catch (IndexOutOfRangeException) { throw new InvalidOperationException(); } }
        }

        object IEnumerator.Current => Current;
        public IEnumerator GetEnumerator() => array.GetEnumerator();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => ((IEnumerable<T>)array).GetEnumerator();
        public void Dispose() => this.Dispose();
        #endregion

        #region Sorting


        


        // Algorithm was taken from this web-site https://en.wikibooks.org/wiki/Algorithm_Implementation/Sorting/Radix_sort and reworked to generic types
        public void RadixSort()
        {
            // our helper array 
            dynamic t = new T[array.Length];

            // number of bits our group will be long 
            int r = 4; // try to set this also to 2, 8 or 16 to see if it is 
                       // quicker or not 

            // number of bits of a C# int 
            int b = 32;

            // counting and prefix arrays
            // (note dimensions 2^r which is the number of all possible values of a 
            // r-bit number) 
            int[] count = new int[1 << r];
            int[] pref = new int[1 << r];

            // number of groups 
            int groups = (int)Math.Ceiling((double)b / (double)r);

            // the mask to identify groups 
            int mask = (1 << r) - 1;

            dynamic value = default;
            // the algorithm: 
            for (int c = 0, shift = 0; c < groups; c++, shift += r)
            {
                // reset count array 
                for (int j = 0; j < count.Length; j++)
                    count[j] = 0;

                // counting elements of the c-th group 
                for (int i = 0; i < array.Length; i++)
                {
                    value = array[i];
                    count[((int)value >> shift) & mask]++;
                }

                // calculating prefixes 
                pref[0] = 0;
                for (int i = 1; i < count.Length; i++)
                    pref[i] = pref[i - 1] + count[i - 1];

                // from a[] to t[] elements ordered by c-th group 
                for (int i = 0; i < array.Length; i++)
                {
                    value = array[i];
                    t[pref[((int)value >> shift) & mask]++] = array[i];
                }

                // a[]=t[] and start again until the last group 
                t.CopyTo(array, 0);
            }
        }


        public void BucketSort()
        {
            if (array == null || array.Length <= 1)
                return;

            dynamic maxValue = array.Max();
            dynamic minValue = array.Min();

            LinkedList<T>[] bucket = new LinkedList<T>[(int)(maxValue - minValue + 1)];
            for (int i = 0; i < array.Length; i++)
            {
                if (bucket[(int)(array[i] - minValue)] == null)
                    bucket[(int)(array[i] - minValue)] = new LinkedList<T>();

                bucket[(int)(array[i] - minValue)].AddLast(array[i]);
            }
            var index = 0;

            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != null)
                {
                    LinkedListNode<T> node = bucket[i].First;
                    while (node != null)
                    {
                        array[index] = node.Value;
                        node = node.Next;
                        index++;
                    }
                }
            }

        }
        #endregion
    }
}
