using System;
using System.ComponentModel.Composition;
using OpenCBS.Engine.Interfaces;

namespace OpenCBS.Engine.RoundingPolicy
{
    [Export(typeof(IPolicy))]
    [PolicyAttribute(Implementation = "Two decimal")]
    public class TwoDecimalRoundingPolicy : IRoundingPolicy
    {
        public decimal Round(decimal amount)
        {
            return Math.Round(amount, 2, MidpointRounding.AwayFromZero);
        }
    }
}
