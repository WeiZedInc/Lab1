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


        public string CalculateTime(bool isSubtractingWithCurrentTime, bool isSubtracting)
        {
            if (isSubtractingWithCurrentTime)
            {
                var timeNow = DateTime.Now;
                customTimeSpan = new TimeSpan(firstCustomTime.Add(new TimeSpan(timeNow.Ticks)).Ticks);
                string timeFormatted = (customTimeSpan.Hours.ToString() + ':' + customTimeSpan.Minutes.ToString() + ':' + customTimeSpan.Seconds.ToString().Replace("-", ""));
                return $"Time difference is: ({firstCustomTime}) - ({timeNow}) = {customTimeSpan.Days} days " + timeFormatted;
            }
            else
            {
                customTimeSpan = new TimeSpan(firstCustomTime.Add(new TimeSpan(secondCustomTime.Ticks)).Ticks);
                string timeFormatted = (customTimeSpan.Hours.ToString() + ':' + customTimeSpan.Minutes.ToString() + ':' + customTimeSpan.Seconds.ToString().Replace("-", ""));
                return $"Time difference is: ({firstCustomTime}) - ({secondCustomTime}) = {customTimeSpan.Days} days " + timeFormatted;
            }
        }
        public string SwitchTimeZones(string timeZone = "Pacific Standard Time")
        {
            try
            {
                var tz = TimeZoneInfo.FindSystemTimeZoneById(timeZone);
                var date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, tz);
                return "Local time in other time zone: " + date + " " + tz.DisplayName + '\n';
            }
            catch (TimeZoneNotFoundException)
            {
                return "There are no such time zone.";
            }
        }

        public string JulianDate()
        {
            DateTime dateTime = DateTime.FromOADate(firstCustomTime.ToOADate() + 2415018.5);
            return "Julian date for your date is: " + dateTime;
        }

        public string FindDayByDate() => "Full date is: " + firstCustomTime.ToString("dddd, dd MMMM yyyy");

        public string FindMostPopularDayOfTheWeek(int dayNum = 1)
        {
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
                return "";
            }

            if (DateTime.Compare(firstCustomTime, secondCustomTime) > 0)
            {
                startDate = secondCustomTime;
                finishDate = firstCustomTime;
            }
            else if (DateTime.Compare(firstCustomTime, secondCustomTime) == 0)
            {
                return "";
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

            return "The most popular day of the week in tha range is: " + daysCounter.Keys.Max() + " with count of " + daysCounter.Values.Max().ToString() + " days.";
        }
    }
}
