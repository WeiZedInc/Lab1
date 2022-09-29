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

static class Programm
{
    static void Main(string[] args)
    {
        //MainMenu();

        //MyList<int> myList = new MyList<int>();
        //myList.Add(1);
        //myList.Add(0);
        //myList.Add(-3);
        //myList.Add(22);
        //myList.Add(245);
        //myList.Add(11);
        //myList.QuickSort(myList.Count-1);
        //foreach (var item in myList)
        //    Console.WriteLine(item);

        //MyArray<int> array = new MyArray<int>(6);
        //array[0] = 1;
        //array[1] = 0;
        //array[2] = -3;
        //array[3] = 22;
        //array[4] = 245;
        //array[5] = 11;
        //array.CountingSort();
        //foreach (var item in array)
        //    Console.WriteLine(item);

        MyLinkedList<int> linkedList = new MyLinkedList<int>();
        linkedList.AddLast(-1);
        linkedList.AddLast(12);
        linkedList.AddLast(33);
        linkedList.AddLast(0);
        linkedList.AddLast(5);
        linkedList.MergeSort();
        foreach (var item in linkedList)
            Console.WriteLine(item);

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