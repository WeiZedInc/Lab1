namespace Lab1
{
    internal class TimeManager
    {
        public static void TimeMenuSwitcher()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Time menu:");
                Console.WriteLine("1.Show current time");
                Console.WriteLine("2.Validate your time");
                Console.WriteLine("3.Substract your time with another time");
                Console.WriteLine("4.Add time to time");
                Console.WriteLine("5.Subtract time from time");
                Console.WriteLine("6.Find day by date");
                Console.WriteLine("7.Use timezone");
                Console.WriteLine("8.Find the most popular day of the week by date range");
                Console.WriteLine("9.Switch date to the julian calendar");

                //switch (Console.ReadLine())
                //{
                //    case "1":
                //        Console.Clear();
                //        ShowCurrentTime();
                //        break;
                //    case "2":
                //        Console.Clear();
                //        ValidateDateTime();
                //        break;
                //    case "3":
                //        Console.Clear();
                //        SubtractTime();
                //        break;
                //    case "4":
                //        Console.Clear();
                //        if (ValidateDateTime())
                //            CalculateTime('+');
                //        break;
                //    case "5":
                //        Console.Clear();
                //        if (ValidateDateTime())
                //            CalculateTime('-');
                //        break;
                //    case "6":
                //        Console.Clear();
                //        if (ValidateDateTime())
                //            Console.WriteLine("Full date is: " + firstCustomTime.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                //        break;
                //    case "7":
                //        Console.Clear();
                //        SwitchTimeZones();
                //        break;
                //    case "8":
                //        Console.Clear();
                //        FindMostPopularDayOfTheWeek();
                //        break;
                //    case "9":
                //        Console.Clear();
                //        ValidateDateTime();
                //        DateTime dateTime = DateTime.FromOADate((firstCustomTime.ToOADate() + 2415018.5));
                //        Console.WriteLine("Julian date for your date is: " + dateTime + '\n'); // may be incorrect, can not rly understand what is julian dates formula, but seems it is it
                //        break;
                //    default:
                //        Console.Clear();
                //        Console.ForegroundColor = ConsoleColor.Red;
                //        Console.WriteLine("Wrong menu number.\n");
                //        break;
                //}
                TimeMenuSwitcher();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
        }
    }
}
