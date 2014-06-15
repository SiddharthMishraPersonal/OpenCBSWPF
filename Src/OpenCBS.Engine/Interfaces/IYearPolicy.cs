
using System;

namespace OpenCBS.Engine.Interfaces
{
    public interface IYearPolicy : IPolicy
    {
        int GetNumberOfDays(DateTime date);
    }
}
