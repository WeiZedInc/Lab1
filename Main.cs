using System.Globalization;

class Programm
{
    static DateTime customTime = new DateTime();
    static void Main(string[] args)
    {
        var currentTime = DateTime.Now;
        Console.WriteLine("Current time: " + currentTime.ToString("\tdddd, dd MMMM yyyy HH:mm:ss"));
        Console.WriteLine("Short variant: \t" + currentTime);
        Console.WriteLine("Time zone: \t" + currentTime.ToString("GMT K"));
        MenuSwitcher();

    }

    static void MenuSwitcher()
    {
        Console.WriteLine("\n\n Time menu:");
        Console.WriteLine("1.Validate your time");
        Console.WriteLine("2.Substract your time to current time");
        Console.WriteLine("3.Substract your time to new time");

        switch (Console.ReadLine())
        {
            case "1":
                ValidateDateTime();
                break;
            case "2":
                if(ValidateDateTime())
                    CalculateTime();
                break;
            case "3":
                if (ValidateDateTime())
                    CalculateTime();
                break;
            default:
                Console.WriteLine("Wrong menu number.");
                MenuSwitcher();
                break;
        }
    }

    static bool ValidateDateTime()
    {
        Console.WriteLine("Enter your time...");
        string timeStr = Console.ReadLine();
        if (!DateTime.TryParse(timeStr, out customTime))
        {
            Console.WriteLine("DateTime isn't correct");
            return false;
        }
        Console.WriteLine("Time is correct. (" + customTime + ")");
        return true;
    }

    static void CalculateTime()
    {
        TimeSpan timeSpan = customTime.Subtract(DateTime.Now);
        Console.WriteLine("("+ customTime + ") - (" + DateTime.Now + ") = " + timeSpan.Days + " days " + timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds);
    }
}