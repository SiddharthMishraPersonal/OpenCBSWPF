using System;

namespace OpenCBS.Engine.Interfaces
{
    public interface IDateShiftPolicy : IPolicy
    {
        DateTime ShiftDate(DateTime date);
    }
}
