using System;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Lab1Core
{
    public class MyDateTime
    {
        public delegate void TimeTickerHandler();
        public event TimeTickerHandler TimeTicker;

        public DateTime firstCustomTime { get; set; }
        public DateTime secondCustomTime { get; set; }
        public TimeSpan customTimeSpan { get; set; }
        
        public MyDateTime()
        {
            firstCustomTime = new DateTime();
            secondCustomTime = new DateTime();
            customTimeSpan = new TimeSpan();
        }

        public async Task StartTimeTickerEvent()
        {
            TimeTicker?.Invoke();
            await Task.Delay(1000 - DateTime.Now.Millisecond);
            while (true)
            {
                TimeTicker?.Invoke();
                await Task.Delay(1000);
            }
        }
        public bool ValidateDateTime(string input, bool isFirstTime = true)
        {
            if (!DateTime.TryParse(input, out DateTime dt))
                return false;

            if (isFirstTime)
                firstCustomTime = dt;
            else
                secondCustomTime = dt;

            return true;
        }


        public void SubtractTime()
        {
            //if (!ValidateDateTime())
               // return;

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
                //if (!ValidateDateTime(false))
                //    return;

                customTimeSpan = firstCustomTime.Subtract(secondCustomTime);
                string timeFormatted = (customTimeSpan.Hours.ToString() + ':' + customTimeSpan.Minutes.ToString() + ':' + customTimeSpan.Seconds.ToString()).Replace("-", "");
                Console.WriteLine($"Result is: ({firstCustomTime}) - ({secondCustomTime}) = {customTimeSpan.Days} days " + timeFormatted);
                Console.WriteLine("Result saved for further calculations.\n");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Answer isn't correct, try again.");
                return;
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
        public void CalculateTime(char symbol)
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
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect input.");
                                return;
                            }
                            break;
                        case "h":
                            Console.WriteLine("Enter hours amount:");
                            if (!float.TryParse(Console.ReadLine(), out value))
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
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
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect input.");
                                return;
                            }
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Incorrect format.");
                            return;
                    }
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
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
                        Console.ForegroundColor = ConsoleColor.Red;
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
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Idk how did u get here :3");
                        break;
                }
            }
            Console.WriteLine();
        }


        public void SwitchTimeZones()
        {
            Console.WriteLine("Do you want to see all time zones? y/n \n");
            string timeInput = Console.ReadLine();
            string newTimeZone = "Pacific Standard Time";
            if (timeInput == "y")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                foreach (TimeZoneInfo tz in TimeZoneInfo.GetSystemTimeZones())
                    Console.WriteLine(tz.DisplayName + " - \n" + tz.Id + "\n");
                Console.ForegroundColor = ConsoleColor.Green;
            }

            Console.WriteLine("\n\n Do you want to change time zone for current computer time, or new? current/new ");
            string input = Console.ReadLine();
            if (input == "current")
            {
                Console.WriteLine("Enter prefered time zone (use only english timezone names from the offered list):");
                newTimeZone = Console.ReadLine();
                var currentTime = DateTime.Now;
                try
                {
                    var tz = TimeZoneInfo.FindSystemTimeZoneById(newTimeZone);
                    var date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
                    Console.WriteLine("Local time in other time zone: " + date + " " + tz.DisplayName + '\n');
                }
                catch (TimeZoneNotFoundException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no such time zone.");
                    return;
                }


            }
            else if (input == "new")
            {
                //ValidateDateTime();

                Console.WriteLine("Enter prefered time zone:");
                newTimeZone = Console.ReadLine();
                try
                {
                    var tz = TimeZoneInfo.FindSystemTimeZoneById(newTimeZone);
                    var date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
                    Console.WriteLine("New time in other time zone: " + date + " " + tz.DisplayName + '\n');
                }
                catch (TimeZoneNotFoundException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no such time zone.");
                    return;
                }

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wrong input.");
            }
        }
        public void FindMostPopularDayOfTheWeek()
        {
            Console.WriteLine("Please, enter the date range");
           // if (!ValidateDateTime() || !ValidateDateTime(false))
            //    return;

            Console.WriteLine("Please, enter the day of the months");
            int dayNum = 0;
            DateTime finishDate = DateTime.Now, startDate = DateTime.Now;
            Dictionary<string, int> daysCounter = new Dictionary<string, int>
        {
            {"Monday", 0 },
            {"Tuesday", 0 },
            {"Wednesday", 0 },
            {"Thursday", 0 },
            {"Friday", 0 },
            {"Saturday", 0 },
            {"Sunday", 0 }
        };
            if (!int.TryParse(Console.ReadLine(), out dayNum) || dayNum > 31 || dayNum < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect day number, try again.");
                return;
            }

            if (DateTime.Compare(firstCustomTime, secondCustomTime) > 0)
            {
                startDate = secondCustomTime;
                finishDate = firstCustomTime;
            }
            else if (DateTime.Compare(firstCustomTime, secondCustomTime) == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Dates cannot be the same");
                return;
            }
            else if (DateTime.Compare(firstCustomTime, secondCustomTime) < 0)
            {
                startDate = firstCustomTime;
                finishDate = secondCustomTime;
            }


            int daysLeft = Convert.ToInt32(finishDate.Subtract(startDate).TotalDays);
            while (daysLeft != 0)
            {
                if (startDate.Day == dayNum)
                    daysCounter[startDate.DayOfWeek.ToString()] += 1;

                startDate = startDate.AddDays(1);
                daysLeft--;
            }

            Console.WriteLine("The most popular day of the week in tha range is: " + daysCounter.Keys.Max() + " with count of " + daysCounter.Values.Max().ToString() + " days.");
        }
    }
}
