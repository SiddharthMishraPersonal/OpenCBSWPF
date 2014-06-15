using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.DatePolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "No")]
    public class NoDateShiftPolicy : IDateShiftPolicy
    {
        public DateTime ShiftDate(DateTime date)
        {
            return date;
        }
    }
}
