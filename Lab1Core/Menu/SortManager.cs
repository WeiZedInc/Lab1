using Lab1Core;
using System;
using System.Collections;
using static System.Runtime.InteropServices.JavaScript.JSType;

public sealed class SortManager
{
    private static readonly SortManager instance = new SortManager();
    private SortManager() { } // to prevent external instantiation
    public static SortManager Instance { get => instance; }

    public void ListsSorting(string alghoritmName)
    {
        IEnumerable list;
        Type type;
        ChooseTypeForList(out type, out list);



        if (!FillList(list, type))
            return;

        SortCollection(list, alghoritmName);
    }
    public void LinkedListsSorting(string alghoritmName)
    {
        IEnumerable list;
        Type type;
        ChooseTypeForLinkedList(out type, out list);


        if (!FillLinkedList(list, type))
            return;

        SortCollection(list, alghoritmName);
    }

    public bool FillList(dynamic collection, Type type)
    {
        bool isWhiteSpaceSeparator = false;
        if (type.Name == "Double" || type.Name == "Single")
            isWhiteSpaceSeparator = true;

        string format = isWhiteSpaceSeparator ? "WHITESPACE separator, example [23,4 -23,431 0,13f]" : "',' or whitespace or ';' separators";
        Console.WriteLine($"Input values of which list contains using {format}:");
        string inputValues = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputValues))
        {
            Console.WriteLine("Try next time to input some values...");
            return false;
        }

        string[] cuttedValues;
        if (isWhiteSpaceSeparator)
            cuttedValues = inputValues.Split(" ", StringSplitOptions.TrimEntries);
        else
            cuttedValues = inputValues.Split(new string[] { " ", ",", ";" }, StringSplitOptions.TrimEntries);

        switch (type.Name)
        {
            case "Int32":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!int.TryParse(cuttedValues[i], out int newInt))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be integer");
                        continue;
                    }
                    collection.Add(newInt);
                }
                break;
            case "Double":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!double.TryParse(cuttedValues[i], out double newDouble))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be double");
                        continue;
                    }
                    collection.Add(newDouble);
                }
                break;
            case "Single":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!float.TryParse(cuttedValues[i], out float newFloat))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be float");
                        continue;
                    }
                    collection.Add(newFloat);
                }
                break;
            case "Int16":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!short.TryParse(cuttedValues[i], out short newShort))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be short");
                        continue;
                    }
                    collection.Add(newShort);
                }
                break;
            case "UInt16":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!ushort.TryParse(cuttedValues[i], out ushort newUshort))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be ushort");
                        continue;
                    }
                    collection.Add(newUshort);
                }
                break;
            case "UInt32":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!uint.TryParse(cuttedValues[i], out uint newUint))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be uint");
                        continue;
                    }
                    collection.Add(newUint);
                }
                break;
            default:
                break;
        }
        return true;
    }
    public bool FillLinkedList(dynamic collection, Type type)
    {
        bool isWhiteSpaceSeparator = false;
        if (type.Name == "Double" || type.Name == "Single")
            isWhiteSpaceSeparator = true;

        string format = isWhiteSpaceSeparator ? "WHITESPACE separator, example [23,4 -23,431 0,13f]" : "',' or whitespace or ';' separators";
        Console.WriteLine($"Input values of which linkedlist contains using {format}:");
        string inputValues = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputValues))
        {
            Console.WriteLine("Try next time to input some values...");
            return false;
        }

        string[] cuttedValues;
        if (isWhiteSpaceSeparator)
            cuttedValues = inputValues.Split(" ", StringSplitOptions.TrimEntries);
        else
            cuttedValues = inputValues.Split(new string[] { " ", ",", ";" }, StringSplitOptions.TrimEntries);


        switch (type.Name)
        {
            case "Int32":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!int.TryParse(cuttedValues[i], out int newInt))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be integer");
                        continue;
                    }
                    collection.AddLast(newInt);
                }
                break;
            case "Double":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!double.TryParse(cuttedValues[i], out double newDouble))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be double");
                        continue;
                    }
                    collection.AddLast(newDouble);
                }
                break;
            case "Single":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!float.TryParse(cuttedValues[i], out float newFloat))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be float");
                        continue;
                    }
                    collection.AddLast(newFloat);
                }
                break;
            case "Int16":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!short.TryParse(cuttedValues[i], out short newShort))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be short");
                        continue;
                    }
                    collection.AddLast(newShort);
                }
                break;
            case "UInt16":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!ushort.TryParse(cuttedValues[i], out ushort newUshort))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be ushort");
                        continue;
                    }
                    collection.AddLast(newUshort);
                }
                break;
            case "UInt32":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!uint.TryParse(cuttedValues[i], out uint newUint))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be uint");
                        continue;
                    }
                    collection.AddLast(newUint);
                }
                break;
            default:
                break;
        }
        return true;
    }

    public void ChooseTypeForList(out Type type, out IEnumerable list)
    {
        Console.WriteLine("Choose type for List");
        Console.WriteLine("1.int");
        Console.WriteLine("2.double");
        Console.WriteLine("3.float");
        Console.WriteLine("4.short");
        Console.WriteLine("5.ushort");
        Console.WriteLine("6.uint");
        switch (Console.ReadLine())
        {
            case "1":
                list = new MyList<int>();
                type = typeof(int);
                break;
            case "2":
                list = new MyList<double>();
                type = typeof(double);
                break;
            case "3":
                list = new MyList<float>();
                type = typeof(float);
                break;
            case "4":
                list = new MyList<short>();
                type = typeof(short);
                break;
            case "5":
                list = new MyList<ushort>();
                type = typeof(ushort);
                break;
            case "6":
                list = new MyList<uint>();
                type = typeof(uint);
                break;
            default:
                Console.WriteLine("Incorrect input.");
                type = null;
                list = null;
                break;
        }
    }
    public void ChooseTypeForLinkedList(out Type type, out IEnumerable collection)
    {
        Console.WriteLine("Choose type for LinkedList");
        Console.WriteLine("1.int");
        Console.WriteLine("2.double");
        Console.WriteLine("3.float");
        Console.WriteLine("4.short");
        Console.WriteLine("5.ushort");
        Console.WriteLine("6.uint");
        switch (Console.ReadLine())
        {
            case "1":
                collection = new MyLinkedList<int>();
                type = typeof(int);
                break;
            case "2":
                collection = new MyLinkedList<double>();
                type = typeof(double);
                break;
            case "3":
                collection = new MyLinkedList<float>();
                type = typeof(float);
                break;
            case "4":
                collection = new MyLinkedList<short>();
                type = typeof(short);
                break;
            case "5":
                collection = new MyLinkedList<ushort>();
                type = typeof(ushort);
                break;
            case "6":
                collection = new MyLinkedList<uint>();
                type = typeof(uint);
                break;
            default:
                Console.WriteLine("Incorrect input.");
                type = null;
                collection = null;
                break;
        }
    }

    public bool CreateFillAndSortArray<T>(string algorithmName, string inputValues = "10 5 2 3")
    {
        Type type = typeof(T);
        bool isWhiteSpaceSeparator = false;
        if (type.Name == "Double" || type.Name == "Single")
            isWhiteSpaceSeparator = true;


        string[] cuttedValues;
        if (isWhiteSpaceSeparator)
            cuttedValues = inputValues.Split(" ", StringSplitOptions.TrimEntries);
        else
            cuttedValues = inputValues.Split(new string[] { " ", ",", ";" }, StringSplitOptions.TrimEntries);

        int size = cuttedValues.Length;
        IEnumerable array = new MyArray<T>(size);

        switch (type.Name)
        {
            case "Int32":
                var intArr = new MyArray<int>(size);
                for (int i = 0; i < size; i++)
                {
                    if (!int.TryParse(cuttedValues[i], out int newInt))
                        continue;
                    intArr[i] = newInt;
                }
                array = intArr;
                break;
            case "Double":
                var doubleArr = new MyArray<double>(size);
                for (int i = 0; i < size; i++)
                {
                    if (!double.TryParse(cuttedValues[i], out double newDouble))
                        continue;
                    doubleArr[i] = newDouble;
                }
                array = doubleArr;
                break;
            case "Single":
                var floatArr = new MyArray<float>(size);
                for (int i = 0; i < size; i++)
                {
                    if (!float.TryParse(cuttedValues[i], out float newFloat))
                        continue;
                    floatArr[i] = newFloat;
                }
                array = floatArr;
                break;
            case "Int16":
                var shortArr = new MyArray<short>(size);
                for (int i = 0; i < size; i++)
                {
                    if (!short.TryParse(cuttedValues[i], out short newShort))
                        continue;
                    shortArr[i] = newShort;
                }
                array = shortArr;
                break;
            case "UInt16":
                var ushortArr = new MyArray<ushort>(size);
                for (int i = 0; i < size; i++)
                {
                    if (!ushort.TryParse(cuttedValues[i], out ushort newUshort))
                        continue;
                    ushortArr[i] = newUshort;
                }
                array = ushortArr;
                break;
            case "UInt32":
                var uintArr = new MyArray<uint>(size);
                for (int i = 0; i < size; i++)
                {
                    if (!uint.TryParse(cuttedValues[i], out uint newUint))
                        continue;
                    uintArr[i] = newUint;
                }
                array = uintArr;
                break;
            default:
                break;
        }

        SortCollection(array, algorithmName);
        return true;
    }
    void SortCollection(IEnumerable collection, string algorithmName)
    {
        if ("MyLinkedList`1" == collection.GetType().Name)
            algorithmName = "Merge Sort";

        switch (algorithmName)
        {
            case "Insertion sort":
                collection.InsertionSortGeneric();
                break;
            case "Quick sort":
                collection.QuickSortGeneric();
                break;
            case "Merge sort":
                collection.MergeSortGeneric();
                break;
            case "Counting sort":
                collection.CountingSortGeneric();
                break;
            case "Radix sort":
                collection.RadixSortGeneric();
                break;
            case "Bucket sort":
                collection.BucketSortGeneric();
                break;
            default:
                throw new Exception();
        }
    }
}