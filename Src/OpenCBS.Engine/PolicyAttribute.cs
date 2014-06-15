using System;
using System.ComponentModel.Composition;

namespace OpenCBS.Engine
{
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class)]
    public class PolicyAttribute : Attribute
    {
        public string Implementation { get; set; }
        public string PolicyType { get; set; }
    }
}
