using System;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace Lab1
{
    static class ExtensionSorting
    {
        static bool isRecursion = false;
        static bool CheckForCorrectClass(dynamic myClass)
        {
            if (myClass.GetType().Name == typeof(MyArray<>).Name ||
                myClass.GetType().Name == typeof(MyList<>).Name ||
                myClass.GetType().Name == typeof(MyLinkedList<>).Name) return true;

            Console.WriteLine("This methods made only for my custom generic classes");
            return false;
        }

        static dynamic Min(dynamic array)
        {
            dynamic smallest = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < smallest)
                    smallest = array[i];
            }
            return smallest;
        }

        static dynamic Max(dynamic array)
        {
            dynamic largest = array[array.Length-1];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > largest)
                    largest = array[i];
            }
            return largest;
        }

        public static void InsertionSortGeneric<T>(this T myClass)
        {
            if (CheckForCorrectClass(myClass) == false) return;
            dynamic dynamicT = myClass;
            dynamic array = dynamicT.Array;

            int i, flag, arrSize = array.Length;
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

        public static void QuickSortGeneric<T>(this T myClass, int lastIndex, int startInd = 0)
        {
            isRecursion = true;
            if (CheckForCorrectClass(myClass) == false && isRecursion == false) return;
            dynamic dynamicT = myClass;
            dynamic array = dynamicT.Array;

            int i = startInd, j = lastIndex;
            dynamic flag = array[(startInd + lastIndex) / 2];
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
                QuickSortGeneric(myClass, j, startInd);
            if (i < lastIndex)
                QuickSortGeneric(myClass, lastIndex, i);
            isRecursion = false;
        }

        public static void CountingSortGeneric<T>(this T myClass)
        {
            if (CheckForCorrectClass(myClass) == false) return;
            dynamic dynamicT = myClass;
            dynamic array = dynamicT.Array;

            var minVal = Min(array);
            var sortedArray = new dynamic[array.Length];
            int[] counts = new int[(int)(Max(array) - minVal + 1)];

            for (int i = 0; i < array.Length; i++)
                counts[(int)(array[i] - minVal)]++;
            counts[0]--;

            for (int i = 1; i < counts.Length; i++)
                counts[i] = counts[i] + counts[i - 1];

            for (int i = array.Length - 1; i >= 0; i--)
                sortedArray[counts[(int)(array[i] - minVal)]--] = array[i];

            for (int i = 0; i < array.Length; i++)
                array[i] = sortedArray[i];
        }
    }
}
