static class SortManager
{
    public static void SortMenuSwitcher()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Sorting menu:");
            Console.WriteLine("1.Insertion sort");
            Console.WriteLine("2.Quick sort");
            Console.WriteLine("3.Merge sort");
            Console.WriteLine("4.Comb sort");
            Console.WriteLine("5.Counting sort");
            Console.WriteLine("6.Radix sort");
            Console.WriteLine("7.Bucket sort");
            Console.WriteLine("8.Create random array");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    InsertionSort();
                    break;
                case "2":
                    Console.Clear();
                    QuickSortInit();
                    break;
                case "3":
                    Console.Clear();
                    MergeSortInit();
                    break;
                case "4":
                    Console.Clear();
                    CombSortInit();
                    break;
                case "5":
                    Console.Clear();
                    CountingSortInit();
                    break;
                case "6":
                    Console.Clear();
                    RadixSortInit();
                    break;
                case "7":
                    Console.Clear();
                    BucketSortInit();
                    break;
                case "8":
                    Console.Clear();
                    CreateRandomArray();
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong menu number.\n");
                    break;
            }
            SortMenuSwitcher();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex);
        }
    }
    
    static int[] ConvertInput()
    {
        Console.WriteLine("Input values of which array contains using ',' or whitespace or ';' separators:");
        string inputValues = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputValues))
        {
            Console.WriteLine("Try next time to input some values...");
            return new int[0];
        }
        string[] inputValuesArr = inputValues.Split(new string[] {" ", ",", ";"}, StringSplitOptions.TrimEntries);
        int newValue = 0;
        int i = 0;
        int[] sortingArr = new int[inputValuesArr.Length];
        foreach (var value in inputValuesArr)
        {
            if (!int.TryParse(value, out newValue))
            {
                Console.WriteLine(value + " - cannot be integer");
                continue;
            }
            sortingArr[i++] = newValue;
        }
        return sortingArr;
    }

    static void CreateRandomArray(int size = 29)
    {
        Random rand = new Random();
        int[] arr = new int[size];
        for (int i = 0; i < size; i++)
        {
            if (i % 2 == 0)
                arr[i] = rand.Next(1, 2395);

            else
                arr[i] = (rand.Next(1, 234)) * -1;
        }

        Console.WriteLine("Created array: ");
        for (int i = 0; i < size; i++)
            Console.Write(arr[i] + " ");
        Console.WriteLine();
    }

    static void InsertionSort()
    {
        List<int> sortingList = new List<int>(){};

        Console.WriteLine("Input values of which array contains using ',' or whitespace or ';' separators:");
        string inputValues = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputValues))
        {
            Console.WriteLine("Try next time to input some values...");
            return;
        }
        string[] inputValuesArr = inputValues.Split(new string[] { " ", ",", ";" }, StringSplitOptions.TrimEntries);
        int newValue = 0;
        foreach (var value in inputValuesArr)
        {
            if (!int.TryParse(value, out newValue))
            {
                Console.WriteLine(value + " - cannot be integer");
                continue;
            }
            sortingList.Add(newValue);
        }

        int i, operatingValue, flag, arrSize = sortingList.Count;
        Console.Write("Initial array is: ");
        for (i = 0; i < arrSize; i++)
            Console.Write(sortingList[i] + " ");

        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();

        for (i = 1; i < arrSize; i++)
        {
            operatingValue = sortingList[i];
            flag = 0;
            for (int j = i - 1; j >= 0 && flag != 1;)
            {
                if (operatingValue < sortingList[j])
                {
                    sortingList[j + 1] = sortingList[j];
                    j--;
                    sortingList[j + 1] = operatingValue;
                }
                else
                {
                    flag = 1;
                }
            }
        }

        watch.Stop();

        Console.Write("\nSorted Array is: ");
        for (i = 0; i < arrSize; i++)
            Console.Write(sortingList[i] + " ");
        Console.WriteLine();
        Console.WriteLine($"Execution Time: {watch.Elapsed} ms");
    }

    #region QuickSort
    static void QuickSortInit()
    {
        var watch = new System.Diagnostics.Stopwatch();
        var sortingArr = ConvertInput();
        watch.Start();
        sortingArr = QuickSort(sortingArr, 0, sortingArr.Length - 1);
        watch.Stop();

        Console.Write("\nSorted Array is: ");
        for (int i = 0; i < sortingArr.Length; i++)
            Console.Write(sortingArr[i] + " ");
        Console.WriteLine();
        Console.WriteLine($"Execution Time: {watch.Elapsed} ms");
    }
    static int[] QuickSort(int[] arr, int leftInd, int rightInd)
    {
        int i = leftInd, j = rightInd;
        int flag = arr[leftInd];
        while (i <= j)
        {
            while (arr[i] < flag)
                i++;

            while (arr[j] > flag)
                j--;

            if (i <= j)
            {
                int val = arr[i];
                arr[i] = arr[j];
                arr[j] = val;
                i++;
                j--;
            }
        }

        if (leftInd < j)
            QuickSort(arr, leftInd, j);
        if (i < rightInd)
            QuickSort(arr, i, rightInd);
        return arr;
    }
    #endregion

    #region MergeSort
    static void MergeSortInit()
    {
        var watch = new System.Diagnostics.Stopwatch();
        var sortingArr = ConvertInput();
        watch.Start();
        sortingArr = SortMergeArr(sortingArr, 0, sortingArr.Length - 1);
        watch.Stop();

        Console.Write("\nSorted Array is: ");
        for (int i = 0; i < sortingArr.Length; i++)
            Console.Write(sortingArr[i] + " ");
        Console.WriteLine();
        Console.WriteLine($"Execution Time: {watch.Elapsed} ms");
    }
    static int[] SortMergeArr(int[] array, int left, int right)
    {
        if (left < right)
        {
            int middle = left + (right - left) / 2;
            SortMergeArr(array, left, middle);
            SortMergeArr(array, middle + 1, right);
            MergeArr(array, left, middle, right);
        }
        return array;
    }
    static void MergeArr(int[] array, int left, int middle, int right)
    {
        var leftArrayLength = middle - left + 1;
        var rightArrayLength = right - middle;
        var leftTempArray = new int[leftArrayLength];
        var rightTempArray = new int[rightArrayLength];
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
            {
                array[k++] = leftTempArray[i++];
            }
            else
            {
                array[k++] = rightTempArray[j++];
            }
        }
        while (i < leftArrayLength)
        {
            array[k++] = leftTempArray[i++];
        }
        while (j < rightArrayLength)
        {
            array[k++] = rightTempArray[j++];
        }
    }
    #endregion

    #region CombinationSort
    static void CombSortInit()
    {
        var watch = new System.Diagnostics.Stopwatch();
        var sortingArr = ConvertInput();
        watch.Start();
        sortingArr = CombSort(sortingArr);
        watch.Stop();

        Console.Write("\nSorted Array is: ");
        for (int i = 0; i < sortingArr.Length; i++)
            Console.Write(sortingArr[i] + " ");
        Console.WriteLine();
        Console.WriteLine($"Execution Time: {watch.Elapsed} ms");
    }
    static int[] CombSort(int[] arr)
    {
        int arrayLength = arr.Length;
        int currentStep = arrayLength - 1;

        while (currentStep > 1)
        {
            for (int i = 0; i + currentStep < arr.Length; i++)
            {
                if (arr[i] > arr[i + currentStep])
                {
                    Swap(ref arr[i], ref arr[i + currentStep]);
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
                if (arr[j] > arr[j + 1])
                {
                    Swap(ref arr[j], ref arr[j + 1]);
                    swapFlag = true;
                }
            }

            if (!swapFlag)
                break;
        }
        return arr;
    }
    static int GetNextStep(int step)
    {
        step = step * 1000 / 1247;
        return step > 1 ? step : 1;
    }
    static void Swap(ref int value1, ref int value2)
    {
        int temp = value1;
        value1 = value2;
        value2 = temp;
    }
    #endregion

    #region CountingSort
    static void CountingSortInit()
    {
        var watch = new System.Diagnostics.Stopwatch();
        var sortingArr = ConvertInput();
        watch.Start();
        sortingArr = CountingSort(sortingArr);
        watch.Stop();

        Console.Write("\nSorted Array is: ");
        for (int i = 0; i < sortingArr.Length; i++)
            Console.Write(sortingArr[i] + " ");
        Console.WriteLine();
        Console.WriteLine($"Execution Time: {watch.Elapsed} ms");
    }
    static int[] CountingSort(int[] array)
    {
        int minVal = array.Min();
        int[] sortedArray = new int[array.Length];
        int[] counts = new int[array.Max() - minVal + 1];

        for (int i = 0; i < array.Length; i++)
            counts[array[i] - minVal]++;
        counts[0]--;

        for (int i = 1; i < counts.Length; i++)
            counts[i] = counts[i] + counts[i - 1];

        for (int i = array.Length - 1; i >= 0; i--)
            sortedArray[counts[array[i] - minVal]--] = array[i];

        return sortedArray;
    }
    #endregion

    #region RadixSort
    static void RadixSortInit()
    {
        var watch = new System.Diagnostics.Stopwatch();
        var sortingArr = ConvertInput();
        watch.Start();
        RadixSort(ref sortingArr);
        watch.Stop();

        Console.Write("\nSorted Array is: ");
        for (int i = 0; i < sortingArr.Length; i++)
            Console.Write(sortingArr[i] + " ");
        Console.WriteLine();
        Console.WriteLine($"Execution Time: {watch.Elapsed} ms");
    }
    static void RadixSort(ref int[] a)
    {
        // our helper array 
        int[] t = new int[a.Length];

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

        // the algorithm: 
        for (int c = 0, shift = 0; c < groups; c++, shift += r)
        {
            // reset count array 
            for (int j = 0; j < count.Length; j++)
                count[j] = 0;

            // counting elements of the c-th group 
            for (int i = 0; i < a.Length; i++)
                count[(a[i] >> shift) & mask]++;

            // calculating prefixes 
            pref[0] = 0;
            for (int i = 1; i < count.Length; i++)
                pref[i] = pref[i - 1] + count[i - 1];

            // from a[] to t[] elements ordered by c-th group 
            for (int i = 0; i < a.Length; i++)
                t[pref[(a[i] >> shift) & mask]++] = a[i];

            // a[]=t[] and start again until the last group 
            t.CopyTo(a, 0);
        }
    }
    #endregion

    #region BucketSort
    static void BucketSortInit()
    {
        var watch = new System.Diagnostics.Stopwatch();
        var sortingArr = ConvertInput();
        watch.Start();
        sortingArr = BucketSort(sortingArr);
        watch.Stop();

        Console.Write("\nSorted Array is: ");
        for (int i = 0; i < sortingArr.Length; i++)
            Console.Write(sortingArr[i] + " ");
        Console.WriteLine();
        Console.WriteLine($"Execution Time: {watch.Elapsed} ms");
    }
    static int[] BucketSort(int[] array)
    {
        if (array == null || array.Length <= 1)
            return array;

        int maxValue = array[0];
        int minValue = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] > maxValue)
                maxValue = array[i];

            if (array[i] < minValue)
                minValue = array[i];
        }

        LinkedList<int>[] bucket = new LinkedList<int>[maxValue - minValue + 1];
        for (int i = 0; i < array.Length; i++)
        {
            if (bucket[array[i] - minValue] == null)
                bucket[array[i] - minValue] = new LinkedList<int>();

            bucket[array[i] - minValue].AddLast(array[i]);
        }
        var index = 0;

        for (int i = 0; i < bucket.Length; i++)
        {
            if (bucket[i] != null)
            {
                LinkedListNode<int> node = bucket[i].First;
                while (node != null)
                {
                    array[index] = node.Value;
                    node = node.Next;
                    index++;
                }
            }
        }

        return array;
    }
    #endregion
}