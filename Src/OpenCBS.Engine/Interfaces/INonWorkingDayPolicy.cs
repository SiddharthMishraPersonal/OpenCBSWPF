using System;

namespace OpenCBS.Engine.Interfaces
{
    public interface INonWorkingDayPolicy
    {
        bool IsNonWorkingDay(DateTime date);
    }
}
