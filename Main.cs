using System.Globalization;

class Programm
{
    static DateTime customTime = new DateTime();
    static TimeSpan customTimeSpan = new TimeSpan();
    static void Main(string[] args)
    {
        MenuSwitcher();
    }

    static void MenuSwitcher()
    {
        Console.WriteLine("Time menu:");
        Console.WriteLine("1.Show current time");
        Console.WriteLine("2.Validate your time");
        Console.WriteLine("3.Substract your time with current time");
        Console.WriteLine("4.Add time to time");
        Console.WriteLine("5.Subtract time to time");
        Console.WriteLine();

        switch (Console.ReadLine())
        {
            case "1":
                ShowCurrentTime();
                break;
            case "2":
                ValidateDateTime();
                break;
            case "3":
                if(ValidateDateTime())
                    SubtractTime();
                break;
            case "4":
                if (ValidateDateTime())
                    CalculateTime('+');
                break;
            case "5":
                if (ValidateDateTime())
                    CalculateTime('-');
                break;
            default:
                Console.WriteLine("Wrong menu number.");
                break;
        }
        MenuSwitcher();
    }

    static bool ValidateDateTime()
    {
        Console.WriteLine("Enter your time...");
        if (!DateTime.TryParse(Console.ReadLine(), out customTime))
        {
            Console.WriteLine("DateTime isn't correct");
            return false;
        }
        Console.WriteLine("Time is correct. (" + customTime + ")");
        Console.WriteLine();
        return true;
    }

    static void SubtractTime()
    {
        customTimeSpan = customTime.Subtract(DateTime.Now);
        string timeFormatted = (customTimeSpan.Hours.ToString() + ':' + customTimeSpan.Minutes.ToString() + ':' + customTimeSpan.Seconds.ToString()).Replace("-", "");
        Console.WriteLine("Result is: ("+ customTime + ") - (" + DateTime.Now + ") = " + customTimeSpan.Days + " days " + timeFormatted);
        Console.WriteLine("Result saved for further calculations.");
        Console.WriteLine();
    }

    static void CalculateTime(char symbol)
    {
        if (symbol == '+')
            Console.WriteLine("Result is: " + customTime.Add(customTimeSpan));
        else
            Console.WriteLine("Result is: " + customTime.Subtract(customTime));

        Console.WriteLine();
    }

    static void ShowCurrentTime()
    {
        var currentTime = DateTime.Now;
        Console.WriteLine("Current time: " + currentTime.ToString("\tdddd, dd MMMM yyyy HH:mm:ss"));
        Console.WriteLine("Short variant: \t" + currentTime);
        Console.WriteLine("Time zone: \t" + currentTime.ToString("GMT K"));
        Console.WriteLine();
    }
}