class SortManager
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

    static void InsertionSort()
    {
        List<int> sortingList = new List<int>(){};

        Console.WriteLine("Input values of which array contains using ',' separator:");
        string inputValues = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputValues))
        {
            Console.WriteLine("Try next time to input some values...");
            return;
        }
        string[] inputValuesArr = inputValues.Split(',', StringSplitOptions.TrimEntries);
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

        Console.Write("\nSorted Array is: ");
        for (i = 0; i < arrSize; i++)
            Console.Write(sortingList[i] + " ");
        Console.WriteLine();
    }

    static void QuickSortInit()
    {

        Console.WriteLine("Input values of which array contains using ',' separator:");
        string inputValues = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputValues))
        {
            Console.WriteLine("Try next time to input some values...");
            return;
        }
        string[] inputValuesArr = inputValues.Split(',', StringSplitOptions.TrimEntries);
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
        sortingArr = QuickSort(sortingArr, 0, sortingArr.Length - 1);
        Console.Write("\nSorted Array is: ");
        for (i = 0; i < sortingArr.Length; i++)
            Console.Write(sortingArr[i] + " ");
    }
    static int[] QuickSort(int[] arr, int leftInd, int rightInd)
    {
        int i = leftInd, j = rightInd;
        int flag = arr[leftInd];
        while (i <= j)
        {
            while (arr[i] < flag)
            {
                i++;
            }

            while (arr[j] > flag)
            {
                j--;
            }
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

    static void MergeSortInit()
    {

    }
}