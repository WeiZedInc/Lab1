class Programm
{
    static DateTime firstCustomTime = new DateTime();
    static DateTime secondCustomTime = new DateTime();
    static TimeSpan customTimeSpan = new TimeSpan();
    static void Main(string[] args)
    {
        TimeMenuSwitcher();
    }

    static void TimeMenuSwitcher()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Time menu:");
            Console.WriteLine("1.Show current time"); 
            Console.WriteLine("2.Validate your time"); 
            Console.WriteLine("3.Substract your time with another time");
            Console.WriteLine("4.Add time to time");
            Console.WriteLine("5.Subtract time from time");
            Console.WriteLine("6.Find day by date");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    ShowCurrentTime();
                    break;
                case "2":
                    Console.Clear();
                    ValidateDateTime();
                    break;
                case "3":
                    Console.Clear();
                    SubtractTime();
                    break;
                case "4":
                    Console.Clear();
                    if (ValidateDateTime())
                        CalculateTime('+');
                    break;
                case "5":
                    Console.Clear();
                    if (ValidateDateTime())
                        CalculateTime('-');
                    break;
                case "6":
                    Console.Clear();
                    if (ValidateDateTime())
                        Console.WriteLine("Full date is: " + firstCustomTime.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                    break;
                default:
                    Console.WriteLine("Wrong menu number.");
                    break;
            }
            TimeMenuSwitcher();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex);
        }
    }

    static bool ValidateDateTime(bool isFirstTime = true)
    {
        Console.WriteLine("Enter your time...");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime dt))
        {
            Console.WriteLine("DateTime isn't correct");
            return false;
        }
        if (isFirstTime)
            firstCustomTime = dt;
        else
            secondCustomTime = dt;

        Console.WriteLine("Time is correct. (" + dt + ")\n");
        return true;
    }

    static void SubtractTime()
    {
        if (!ValidateDateTime())
            return;

        Console.WriteLine("Do you want to subtract this time with current time? y/n");
        string result = Console.ReadLine();
        if (result == "y")
        {
            var timeNow = DateTime.Now;
            customTimeSpan = firstCustomTime.Subtract(timeNow);
            string timeFormatted = (customTimeSpan.Hours.ToString() + ':' + customTimeSpan.Minutes.ToString() + ':' + customTimeSpan.Seconds.ToString()).Replace("-", "");
            Console.WriteLine($"Result is: ({firstCustomTime}) - ({timeNow}) = {customTimeSpan.Days} days " + timeFormatted);
            Console.WriteLine("Result saved for further calculations.\n");
        }
        else if (result == "n")
        {
            Console.WriteLine("Subtraction with 2 custom values.");
            if (!ValidateDateTime(false))
                return;

            customTimeSpan = firstCustomTime.Subtract(secondCustomTime);
            string timeFormatted = (customTimeSpan.Hours.ToString() + ':' + customTimeSpan.Minutes.ToString() + ':' + customTimeSpan.Seconds.ToString()).Replace("-", "");
            Console.WriteLine($"Result is: ({firstCustomTime}) - ({secondCustomTime}) = {customTimeSpan.Days} days " + timeFormatted);
            Console.WriteLine("Result saved for further calculations.\n");
        }
        else
        {
            Console.WriteLine("Answer isn't correct, try again.");
        }

        Console.WriteLine("In which format do you want to get result?");
        Console.WriteLine("Press any key for all formats  | d - days / h - hours / m - minutes / s - seconds");
        switch (Console.ReadLine())
        {
            case "d":
                Console.WriteLine("d = " + customTimeSpan.TotalDays);
                break;
            case "h":
                Console.WriteLine("h = " + customTimeSpan.TotalHours);
                break;
            case "m":
                Console.WriteLine("m = " + customTimeSpan.TotalMinutes);
                break;
            case "s":
                Console.WriteLine("s = " + customTimeSpan.TotalSeconds);
                break;
            default:
                Console.WriteLine("Displaying all.");
                Console.WriteLine("d = " + customTimeSpan.TotalDays);
                Console.WriteLine("h = " + customTimeSpan.TotalHours);
                Console.WriteLine("m = " + customTimeSpan.TotalMinutes);
                Console.WriteLine("s = " + customTimeSpan.TotalSeconds);
                Console.WriteLine();
                break;
        }
    }

    static void CalculateTime(char symbol)
    {
        Console.WriteLine("Do you want to use saved result, or a new one? saved/new");
        float value = 0;
        string timeFormat = "";
        switch (Console.ReadLine())
        {
            case "saved":
                Console.WriteLine("Using saved value from last subtraction: " + customTimeSpan);
                timeFormat = "saved";
                break;
            case "new":
                Console.WriteLine("Enter time format. (d - days, h - hours, m - minutes, s - seconds)");
                timeFormat = Console.ReadLine();
                switch (timeFormat)
                {
                    case "d":
                        Console.WriteLine("Enter days amount:");
                        if (!float.TryParse(Console.ReadLine(), out value))
                        {
                            Console.WriteLine("Incorrect input.");
                            return;
                        }
                        break;
                    case "h":
                        Console.WriteLine("Enter hours amount:");
                        if (!float.TryParse(Console.ReadLine(), out value))
                        {
                            Console.WriteLine("Incorrect input.");
                            return;
                        }
                        break;
                    case "m":
                        Console.WriteLine("Enter minutes amount:");
                        if (!float.TryParse(Console.ReadLine(), out value))
                        {
                            Console.WriteLine("Incorrect input.");
                            return;
                        }
                        break;
                    case "s":
                        Console.WriteLine("Enter second amount:");
                        if (!float.TryParse(Console.ReadLine(), out value))
                        {
                            Console.WriteLine("Incorrect input.");
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine("Incorrect format.");
                        return;
                }
                break;
            default:
                Console.WriteLine("Incorrect input.");
                return;
        }


        if (symbol == '+')
        {
            switch (timeFormat)
            {
                case "d":
                    Console.WriteLine("Result is: " + firstCustomTime.AddDays(value));
                    break;
                case "h":
                    Console.WriteLine("Result is: " + firstCustomTime.AddHours(value));
                    break;
                case "m":
                    Console.WriteLine("Result is: " + firstCustomTime.AddMinutes(value));
                    break;
                case "s":
                    Console.WriteLine("Result is: " + firstCustomTime.AddSeconds(value));
                    break;
                case "saved":
                    
                    Console.WriteLine("Result is: " + firstCustomTime.AddDays(customTimeSpan.TotalDays));
                    break;
                default:
                    Console.WriteLine("Idk how did u get here :3");
                    break;
            }
        }
        else
        {
            switch (timeFormat)
            {
                case "d":
                    Console.WriteLine("Result is: " + firstCustomTime.AddDays(-value));
                    break;
                case "h":
                    Console.WriteLine("Result is: " + firstCustomTime.AddHours(-value));
                    break;
                case "m":
                    Console.WriteLine("Result is: " + firstCustomTime.AddMinutes(-value));
                    break;
                case "s":
                    Console.WriteLine("Result is: " + firstCustomTime.AddSeconds(-value));
                    break;
                case "saved":

                    Console.WriteLine("Result is: " + firstCustomTime.AddDays(-customTimeSpan.TotalDays));
                    break;
                default:
                    Console.WriteLine("Idk how did u get here :3");
                    break;
            }
        }
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