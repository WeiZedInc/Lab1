using Lab1;
using System.Drawing;

static class SortManager
{
    public static void SortMenuSwitcher()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Choose what do you want to sort:");
            Console.WriteLine("1.Array<T>");
            Console.WriteLine("2.List<T>");
            Console.WriteLine("3.LinkedList<T>");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    ArraysSorting();
                    break;
                case "2":
                    Console.Clear();
                    ListsSorting();
                    break;
                case "3":
                    Console.Clear();
                    LinkedListsSorting();
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

    static void ArraysSorting()
    {
        Console.WriteLine("Enter size of the array:");
        if (!int.TryParse(Console.ReadLine(),out int size))
        {
            Console.WriteLine("Incorrect input.");
            return;
        }

        dynamic arr;
        Type type;
        ChooseType(out type, out arr, ref size);


        Console.Clear();
        Console.WriteLine($"Created custom array of type [{type.Name}] with size of [{size}]");


        Console.WriteLine($"Please, enter numbers to fill the array.");
        if (!FillCollection(arr, type, size))
            return;

        SortedArrayOutput(arr);
    }

    static void ListsSorting()
    {

    }

    static void LinkedListsSorting()
    {

    }

    static bool FillCollection(dynamic collection, Type type, int size)
    {
        Console.WriteLine("Input values of which array contains using ',' or whitespace or ';' separators:");
        string inputValues = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputValues))
        {
            Console.WriteLine("Try next time to input some values...");
            return false;
        }
        string[] cuttedValues = inputValues.Split(new string[] { " ", ",", ";" }, StringSplitOptions.TrimEntries);

        switch (type.Name)
        {
            case "Int32":
                for (int i = 0; i < size; i++)
                {
                    if (!int.TryParse(cuttedValues[i], out int newInt))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be integer");
                        continue;
                    }
                    collection[i] = newInt;
                }
                break;
            case "Double":
                for (int i = 0; i < size; i++)
                {
                    if (!double.TryParse(cuttedValues[i], out double newDouble))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be double");
                        continue;
                    }
                    collection[i] = newDouble;
                }
                break;
            case "Single":
                for (int i = 0; i < size; i++)
                {
                    if (!float.TryParse(cuttedValues[i], out float newFloat))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be float");
                        continue;
                    }
                    collection[i] = newFloat;
                }
                break;
            case "Int16":
                for (int i = 0; i < size; i++)
                {
                    if (!short.TryParse(cuttedValues[i], out short newShort))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be short");
                        continue;
                    }
                    collection[i] = newShort;
                }
                break;
            case "UInt16":
                for (int i = 0; i < size; i++)
                {
                    if (!ushort.TryParse(cuttedValues[i], out ushort newUshort))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be ushort");
                        continue;
                    }
                    collection[i] = newUshort;
                }
                break;
            case "UInt32":
                for (int i = 0; i < size; i++)
                {
                    if (!uint.TryParse(cuttedValues[i], out uint newUint))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be uint");
                        continue;
                    }
                    collection[i] = newUint;
                }
                break;
            default:
                break;
        }
        return true;
    }

    static void SortedArrayOutput(dynamic arr)
    {
        Console.Clear();
        Console.WriteLine("Array filled up!");
        Console.WriteLine("We are almost done!\n");
        Console.WriteLine("Now choose the sorting method:");
        Console.WriteLine("1.Insertion sort");
        Console.WriteLine("2.Quick sort");
        Console.WriteLine("3.Merge sort");
        Console.WriteLine("4.Comb sort");
        Console.WriteLine("5.Counting sort");
        Console.WriteLine("6.Radix sort");
        Console.WriteLine("7.Bucket sort");
        switch (Console.ReadLine())
        {
            case "1":
                arr.InsertionSort();
                Console.WriteLine("Sorted array is:");
                foreach (var num in arr)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            case "2":
                arr.QuickSort(arr.Count - 1);
                Console.WriteLine("Sorted array is:");
                foreach (var num in arr)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            case "3":
                arr.SortMergeArr();
                Console.WriteLine("Sorted array is:");
                foreach (var num in arr)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            case "4":
                arr.CombSort();
                Console.WriteLine("Sorted array is:");
                foreach (var num in arr)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            case "5":
                arr.CountingSort();
                Console.WriteLine("Sorted array is:");
                foreach (var num in arr)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            case "6":
                arr.RadixSort();
                Console.WriteLine("Sorted array is:");
                foreach (var num in arr)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            case "7":
                arr.BucketSort();
                Console.WriteLine("Sorted array is:");
                foreach (var num in arr)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Incorrect input.");
                return;
        }
    }

    static void ChooseType(out Type type, out dynamic arr, ref int size)
    {
        Console.WriteLine("Choose type of the array");
        Console.WriteLine("1.int");
        Console.WriteLine("2.double");
        Console.WriteLine("3.float");
        Console.WriteLine("4.short");
        Console.WriteLine("5.ushort");
        Console.WriteLine("6.uint");
        switch (Console.ReadLine())
        {
            case "1":
                arr = new MyArray<int>(size);
                type = typeof(int);
                break;
            case "2":
                arr = new MyArray<double>(size);
                type = typeof(double);
                break;
            case "3":
                arr = new MyArray<float>(size);
                type = typeof(float);
                break;
            case "4":
                arr = new MyArray<short>(size);
                type = typeof(short);
                break;
            case "5":
                arr = new MyArray<ushort>(size);
                type = typeof(ushort);
                break;
            case "6":
                arr = new MyArray<uint>(size);
                type = typeof(uint);
                break;
            default:
                Console.WriteLine("Incorrect input.");
                type = null;
                arr = null;
                break;
        }
    }
}