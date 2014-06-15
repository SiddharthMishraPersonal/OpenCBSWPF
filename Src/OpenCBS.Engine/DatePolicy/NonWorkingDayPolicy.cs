using System;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.DatePolicy
{
    public class NonWorkingDayPolicy : INonWorkingDayPolicy
    {
        private readonly INonWorkingDayPolicy _weekendPolicy;
        private readonly INonWorkingDayPolicy _holidayPolicy;

        public NonWorkingDayPolicy(INonWorkingDayPolicy weekendPolicy, INonWorkingDayPolicy holidayPolicy)
        {
            _weekendPolicy = weekendPolicy;
            _holidayPolicy = holidayPolicy;
        }

        public bool IsNonWorkingDay(DateTime date)
        {
            if (_weekendPolicy == null) throw new ArgumentException("Weekend policy cannot be null.");
            if (_holidayPolicy == null) throw new ArgumentException("Holiday policy cannot be null.");
            return _weekendPolicy.IsNonWorkingDay(date) || _holidayPolicy.IsNonWorkingDay(date);
        }
    }
}
