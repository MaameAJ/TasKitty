using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasKitten
{
    enum RepetitionType { None, Hourly, Daily, Weekly, Biweekly, Monthly, Bimonthly, Yearly, Special }

    static class Repetition
    {
        public static TimeSpan EmptyInterval = new TimeSpan(0);
        public static TimeSpan HourlyInterval = new TimeSpan(hours: 1, minutes: 0, seconds: 0);
        public static TimeSpan DailyInterval = new TimeSpan(days: 1, hours: 0, minutes: 0, seconds: 0);
        public static TimeSpan WeeklyInterval = new TimeSpan(days: 7, hours: 0, minutes: 0, seconds: 0);
        public static TimeSpan BiWeeklyInterval = new TimeSpan(days: 14, hours: 0, minutes: 0, seconds: 0);
       
        static public TimeSpan GetTimeSpan(RepetitionType repeats)
        {
            switch (repeats)
            {
                case RepetitionType.Hourly:
                    return HourlyInterval;
                case RepetitionType.Daily:
                    return DailyInterval;
                case RepetitionType.Weekly:
                    return WeeklyInterval;
                case RepetitionType.Biweekly:
                    return BiWeeklyInterval;
                default:
                    return EmptyInterval;
            }
        }

        static public RepetitionType GetRepetitionType(TimeSpan interval)
        {

            if(interval.Equals(HourlyInterval))
            {
                return RepetitionType.Hourly;
            }
            else if(interval.Equals(DailyInterval))
            {
                return RepetitionType.Daily;
            }
            else if(interval.Equals(WeeklyInterval))
            {
                return RepetitionType.Weekly;
            }
            else if(interval.Equals(BiWeeklyInterval))
            {
                return RepetitionType.Biweekly;
            }
            else if(interval.Equals(EmptyInterval))
            {
                return RepetitionType.None;
            }
            else
            {
                return RepetitionType.Special;
            }
        }
    }
}
