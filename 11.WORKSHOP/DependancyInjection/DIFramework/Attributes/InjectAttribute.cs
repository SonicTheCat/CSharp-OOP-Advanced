namespace CurstomFrameworkDI.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field, AllowMultiple = true)]
    public class InjectAttribute : Attribute
    {

    }
}
