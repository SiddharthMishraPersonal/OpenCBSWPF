using System;
using System.Collections.Generic;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.DatePolicy
{
    public class WeekendPolicy : INonWorkingDayPolicy
    {
        private readonly List<DayOfWeek> _weekends = new List<DayOfWeek>();

        public bool IsNonWorkingDay(DateTime date)
        {
            return _weekends.Contains(date.DayOfWeek);
        }

        public void AddWeekend(DayOfWeek day)
        {
            _weekends.Add(day);
        }
    }
}
