using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.YearPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(PolicyType = "YearPolicy", Implementation = "360")]
    public class ThreeHundredSixtyDayYearPolicy : IYearPolicy
    {
        public int GetNumberOfDays(DateTime date)
        {
            return 360;
        }
    }
}
