using System;

namespace Lab1Core.Menu
{
    public class TimeManager
    {
        public static void TimeMenuSwitcher()
        {
            try
            {
                MyDateTime myDateTime = new MyDateTime();
                Console.WriteLine("2.Validate your time"); // btn
                Console.WriteLine("3.Substract your time with another time"); // btn
                Console.WriteLine("4.Add time to time"); // btn
                Console.WriteLine("5.Subtract time from time"); // btn
                Console.WriteLine("6.Find day by date"); // btn
                Console.WriteLine("7.Use timezone"); // btn
                Console.WriteLine("8.Find the most popular day of the week by date range"); //btn
                Console.WriteLine("9.Switch date to the julian calendar"); //btn

                switch (Console.ReadLine())
                {
                    case "2":
                        Console.Clear();
                        //myDateTime.ValidateDateTime();
                        break;
                    case "3":
                        Console.Clear();
                        myDateTime.SubtractTime();
                        break;
                    case "4":
                        Console.Clear();
                        //if (myDateTime.ValidateDateTime())
                            myDateTime.CalculateTime('+');
                        break;
                    case "5":
                        Console.Clear();
                        //if (myDateTime.ValidateDateTime())
                            myDateTime.CalculateTime('-');
                        break;
                    case "6":
                        Console.Clear();
                        //if (myDateTime.ValidateDateTime())
                            Console.WriteLine("Full date is: " + myDateTime.firstCustomTime.ToString("dddd, dd MMMM yyyy HH:mm:ss"));
                        break;
                    case "7":
                        Console.Clear();
                        myDateTime.SwitchTimeZones();
                        break;
                    case "8":
                        Console.Clear();
                        myDateTime.FindMostPopularDayOfTheWeek();
                        break;
                    case "9":
                        Console.Clear();
                        //.ValidateDateTime();
                        DateTime dateTime = DateTime.FromOADate(myDateTime.firstCustomTime.ToOADate() + 2415018.5);
                        Console.WriteLine("Julian date for your date is: " + dateTime + '\n'); // may be incorrect, can not rly understand what is julian dates formula, but seems it is it
                        break;
                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Wrong menu number.\n");
                        break;
                }
                TimeMenuSwitcher();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex);
            }
        }
    }
}
