using Lab1Core;
using System.Collections;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

public sealed class SortManager
{
    private static readonly SortManager instance = new SortManager();
    private SortManager() { } // to prevent external instantiation
    public static SortManager Instance { get => instance; }

    public MyLinkedList<T>? CreateFillAndSortLinkedList<T>(string algorithmName, string inputValues)
    {
        Type type = typeof(T);
        var cuttedValues = ParseInput(inputValues, type);
        if (cuttedValues == null) return null;

        int size = cuttedValues.Length;
        MyLinkedList<T> array = (MyLinkedList<T>)FillCollection(new MyLinkedList<T>(), ref type, ref size, ref cuttedValues);

        SortCollection(array, algorithmName);
        return array;
    }
    public MyList<T>? CreateFillAndSortList<T>(string algorithmName, string inputValues)
    {
        Type type = typeof(T);
        var cuttedValues = ParseInput(inputValues, type);
        if (cuttedValues == null) return null;

        int size = cuttedValues.Length;
        MyList<T> array = (MyList<T>)FillCollection(new MyList<T>(), ref type, ref size, ref cuttedValues);

        SortCollection(array, algorithmName);
        return array;
    }
    public MyArray<T>? CreateFillAndSortArray<T>(string algorithmName, string inputValues = "10 3 18 4 -2")
    {
        Type type = typeof(T);
        var cuttedValues = ParseInput(inputValues, type);
        if (cuttedValues == null) return null;

        int size = cuttedValues.Length;
        MyArray<T> array = (MyArray<T>)FillCollection(new MyArray<T>(size), ref type, ref size, ref cuttedValues);


        SortCollection(array, algorithmName);
        return array;
    }

    IIndexInterface<T> FillCollection<T>(IIndexInterface<T> array, ref Type type, ref int size, ref string[] cuttedValues)
    {
        switch (type.Name)
        {
            case "Int32":
                for (int i = 0; i < size; i++)
                {
                    if (!int.TryParse(cuttedValues[i], out int newInt))
                        continue;
                    array[i] = Unsafe.As<int, T>(ref newInt);
                }
                break;
            case "Double":
                for (int i = 0; i < size; i++)
                {
                    if (!double.TryParse(cuttedValues[i], out double newDouble))
                        continue;
                    array[i] = Unsafe.As<double, T>(ref newDouble);
                }
                break;
            case "Single":
                for (int i = 0; i < size; i++)
                {
                    if (!float.TryParse(cuttedValues[i], out float newFloat))
                        continue;
                    array[i] = Unsafe.As<float, T>(ref newFloat);
                }
                break;
            case "Int16":
                for (int i = 0; i < size; i++)
                {
                    if (!short.TryParse(cuttedValues[i], out short newShort))
                        continue;
                    array[i] = Unsafe.As<short, T>(ref newShort);
                }
                break;
            case "UInt16":
                for (int i = 0; i < size; i++)
                {
                    if (!ushort.TryParse(cuttedValues[i], out ushort newUshort))
                        continue;
                    array[i] = Unsafe.As<ushort, T>(ref newUshort);
                }
                break;
            case "UInt32":
                for (int i = 0; i < size; i++)
                {
                    if (!uint.TryParse(cuttedValues[i], out uint newUint))
                        continue;
                    array[i] = Unsafe.As<uint, T>(ref newUint);
                }
                break;
        }
        return array;
    }
    string[]? ParseInput(string inputValues, Type type)
    {
        if (string.IsNullOrWhiteSpace(inputValues))
            return null;

        bool isWhiteSpaceSeparator = false;
        if (type.Name == "Double" || type.Name == "Single")
            isWhiteSpaceSeparator = true;


        string[] cuttedValues;
        if (isWhiteSpaceSeparator)
            cuttedValues = inputValues.Split(" ", StringSplitOptions.TrimEntries);
        else
            cuttedValues = inputValues.Split(new string[] { " ", ",", ";" }, StringSplitOptions.TrimEntries);

        return cuttedValues;
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