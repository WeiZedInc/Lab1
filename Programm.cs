/* Lab1 by Yurii Kyrpotenko PI-23
 * 
 * Made 2-nd** ex from the first list (Sort Manager)
 * And
 * 9-th** ex from the second list (Time Manager)
 * 
 * Choosed additional (a*) and (b*) variants from 2-nd ex
 * Choosed additional (a*), (c*), (d*), (e*) variants from 9-th ex
 * 
 * Made 6* for the 9-th ex, and 3-4* for 2-nd ex
 */

using Lab1;
using System.Linq.Expressions;

static class Programm
{
    static void Main(string[] args)
    {
        MyList<double> list = new MyList<double>();
        list.Add(1);
        list.Add(0.1f);
        list.Add(-1.223f);
        list.Add(-4);
        list.Add(32.2);
        list.BucketSort();
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }
        Console.WriteLine();

        MyArray<double> array = new MyArray<double>(5);
        array[0] = 1.11;
        array[1] = -2.1f;
        array[2] = 0.11;
        array[3] = 22;
        array[4] = -4;
        array.BucketSort();
        for (int i = 0; i < array.Count; i++)
        {
            Console.WriteLine(array[i]);
        }
        // comb sort works with doubles, ints
        // insertion sort works with doubles, ints
        // quick sort works with doubles, ints
        // merge sort works with doubles, ints
        // counting sort works with doubles, ints 
        // radix sort works with doubles, ints 
        // bucket sort works with doubles, ints 
    }

    static void MainMenu()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Welcome to the main menu. Please, choose one of the options below.");
        Console.WriteLine("1. Time Manager");
        Console.WriteLine("2. Sort Manager");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                TimeManager.TimeMenuSwitcher();
                break;
            case "2":
                SortManager.SortMenuSwitcher();
                break;
            default:
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong menu number.\n");
                break;
        }
        MainMenu();
    }
}