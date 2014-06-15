
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.YearPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(PolicyType = "YearPolicy", Implementation = "365")]
    public class ThreeHundredSixtyFiveDayYearPolicy : IYearPolicy
    {
        public int GetNumberOfDays(System.DateTime date)
        {
            return 365;
        }
    }
}
