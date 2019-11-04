using System;

namespace SampleApp.Api.Attributes
{
    [AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class)]
    public class InjectAttribute : Attribute
    {
    }
}
