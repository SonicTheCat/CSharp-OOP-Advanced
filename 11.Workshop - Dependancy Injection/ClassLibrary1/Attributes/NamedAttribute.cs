namespace CurstomFrameworkDI.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Field)]
    public class NamedAttribute : Attribute
    {
      public NamedAttribute(string name)
        {
            this.Name = name;
        }

        public string Name { get; }
    }
}