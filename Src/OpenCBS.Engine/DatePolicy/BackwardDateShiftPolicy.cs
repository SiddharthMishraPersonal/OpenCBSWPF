using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.DatePolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "Backward")]
    public class BackwardDateShiftPolicy : IDateShiftPolicy
    {
        private readonly INonWorkingDayPolicy _nonWorkingDayPolicy;

        [ImportingConstructor]
        public BackwardDateShiftPolicy(INonWorkingDayPolicy nonWorkingDayPolicy)
        {
            _nonWorkingDayPolicy = nonWorkingDayPolicy;
        }

        public DateTime ShiftDate(DateTime date)
        {
            if (_nonWorkingDayPolicy == null) throw new ArgumentException("Non-working day policy cannot be null.");

            while (_nonWorkingDayPolicy.IsNonWorkingDay(date))
            {
                date = date.AddDays(-1);
            }
            return date;
        }
    }
}
