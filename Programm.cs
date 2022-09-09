static class Programm
{
    static void Main(string[] args)
    {
        MainMenu();
    }

    static void MainMenu()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Welcome to the main menu. Please choose one of the options below.");
        Console.WriteLine("1. Time Manager");
        Console.WriteLine("2. Poka ne reshil kakoy budet vtoraya zadacha");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                TimeManager.TimeMenuSwitcher();
                break;
            case "2":
                Console.WriteLine("Not implemented yet.");
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong menu number.\n");
                break;
        }
    }
}