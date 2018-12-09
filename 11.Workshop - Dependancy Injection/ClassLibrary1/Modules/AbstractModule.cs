namespace CurstomFrameworkDI.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CurstomFrameworkDI.Attributes;
    using CurstomFrameworkDI.Modules.Contracts;

    public abstract class AbstractModule : IModule
    {
        private readonly IDictionary<Type, Dictionary<string, Type>> implementations;
        private readonly IDictionary<Type, object> instances;

        protected AbstractModule()
        {
            this.implementations = new Dictionary<Type, Dictionary<string, Type>>();
            this.instances = new Dictionary<Type, object>();
        }

        public abstract void Configure(); 

        public object GetInstance(Type type)
        {
            this.instances.TryGetValue(type, out object value);
            return value; 
        }

        public Type GetMapping(Type currentInterface, object attribute)
        {
            var currentImplementation = this.implementations[currentInterface];

            Type type = null;

            if (attribute is InjectAttribute)
            {
                if (currentImplementation.Count == 1)
                {
                    type = currentImplementation.Values.First(); 
                }
                else
                {
                    throw new ArgumentException("No available mapping for this class: " + currentInterface.FullName); 
                }
            }
            else if(attribute is NamedAttribute)
            {
                NamedAttribute named = attribute as NamedAttribute;
                string dependancyName = named.Name;
                type = currentImplementation[dependancyName]; 
            }

            return type;
        }
       
        public void SetInstance(Type implementation, object instance)
        {
            if (!this.instances.ContainsKey(implementation))
            {
                this.instances.Add(implementation, instance); 
            }
        }

        protected void CreateMapping<TInter, TImpl>()
        {
            if (!this.implementations.ContainsKey(typeof(TInter)))
            {
                this.implementations[typeof(TInter)] = new Dictionary<string, Type>();
            }

            this.implementations[typeof(TInter)].Add(typeof(TImpl).Name, typeof(TImpl));
        }
    }
}