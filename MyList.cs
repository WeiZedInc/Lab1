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
            Array.Resize(ref this.array, count);
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
        public void InsertionSort()
        {
            int i, flag, arrSize = Count;
            dynamic operatingValue;

            for (i = 1; i < arrSize; i++)
            {
                operatingValue = array[i];
                if (operatingValue is null) break;

                flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (operatingValue < array[j])
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = operatingValue;
                    }
                    else
                    {
                        flag = 1;
                    }
                }
            }
        }

        /// <param name="lastIndex">lastIndex = (Count of all elements in list) - 1</param>
        /// <param name="startInd">startIndex = 0</param>
        public void QuickSort(int lastIndex, int startInd = 0)
        {
            lastIndex = count - 1;
            int i = startInd, j = lastIndex;
            dynamic flag = array[startInd];
            while (i <= j)
            {
                while (array[i] < flag)
                    i++;

                while (array[j] > flag)
                    j--;

                if (i <= j)
                {
                    dynamic val = array[i];
                    array[i] = array[j];
                    array[j] = val;
                    i++;
                    j--;
                }
            }

            if (startInd < j)
                QuickSort(startInd, j);
            if (i < lastIndex)
                QuickSort(i, lastIndex);
        }

        /// <param name="left">left = 0</param>
        /// <param name="right">right = (Count of all elements in list) - 1</param>
        /// <param name="array">array = default</param>
        public void SortMergeArr(int left, int right, dynamic array = default)
        {
            array = this.array;
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                SortMergeArr(left, middle, array);
                SortMergeArr(middle + 1, right,array);
                MergeArr(array, left, middle, right);
            }
        }
        void MergeArr(int[] array, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            dynamic leftTempArray = new int[leftArrayLength];
            dynamic rightTempArray = new int[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[left + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[middle + 1 + j];
            i = 0;
            j = 0;
            int k = left;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                    array[k++] = leftTempArray[i++];
                else
                    array[k++] = rightTempArray[j++];
            }
            while (i < leftArrayLength)
                array[k++] = leftTempArray[i++];
            while (j < rightArrayLength)
                array[k++] = rightTempArray[j++];
        }

        public void CombSort()
        {
            int arrayLength = count;
            int currentStep = arrayLength - 1;
            dynamic? value;

            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    value = array[i];
                    if (value > array[i + currentStep])
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                    }
                }
                currentStep = GetNextStep(currentStep);
            }

            //bubble sort
            for (int i = 1; i < arrayLength; i++)
            {
                bool swapFlag = false;
                for (int j = 0; j < arrayLength - i; j++)
                {
                    value = array[j];
                    if (value > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                    break;
            }
        }
        int GetNextStep(int step)
        {
            step = step * 1000 / 1247;
            return step > 1 ? step : 1;
        }
        void Swap(ref T value1, ref T value2)
        {
            dynamic temp = value1;
            value1 = value2;
            value2 = temp;
        }

        public void CountingSort()
        {
            dynamic minVal = array.Min();
            dynamic[] sortedArray = new dynamic[array.Length];
            int[] counts = new int[array.Max() - minVal + 1];

            for (int i = 0; i < array.Length; i++)
                counts[array[i] - minVal]++;
            counts[0]--;

            for (int i = 1; i < counts.Length; i++)
                counts[i] = counts[i] + counts[i - 1];

            for (int i = array.Length - 1; i >= 0; i--)
                sortedArray[counts[array[i] - minVal]--] = array[i];

            for (int i = 0; i < count; i++)
                array[i] = sortedArray[i];
        }
        #endregion
    }
}
