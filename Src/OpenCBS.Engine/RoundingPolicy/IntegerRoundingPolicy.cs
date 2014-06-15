using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.RoundingPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "Whole")]
    public class IntegerRoundingPolicy : IRoundingPolicy
    {
        public decimal Round(decimal amount)
        {
            return Math.Round(amount, 0, MidpointRounding.AwayFromZero);
        }
    }
}
