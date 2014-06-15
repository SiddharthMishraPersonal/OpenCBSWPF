using System;
using System.Collections.Generic;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.DatePolicy
{
    public class HolidayPolicy : INonWorkingDayPolicy
    {
        private readonly List<DateTime> _holidays = new List<DateTime>();

        public bool IsNonWorkingDay(DateTime date)
        {
            return _holidays.Contains(date);
        }

        public void AddHoliday(DateTime date)
        {
            _holidays.Add(date);
        }
    }
}
