namespace CurstomFrameworkDI.Modules
{
    using CurstomFrameworkDI.Modules.Contracts;
    using System.Reflection;
    using System.Linq;
    using CurstomFrameworkDI.Attributes;
    using System;

    public class Injector
    {
        private readonly IModule module;

        public Injector(IModule module)
        {
            this.module = module;
        }

        private bool CheckForFieldInjection<TClass>()
        {
            return typeof(TClass)
                .GetFields((BindingFlags)62)
                .Any(f => f.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private bool CheckForConstructorInjection<TClass>()
        {
            return typeof(TClass)
                .GetConstructors()
                .Any(c => c.GetCustomAttributes(typeof(InjectAttribute), true).Any());
        }

        private TClass CreateConstructorInjection<TClass>()
        {
            var desireClass = typeof(TClass);
            if (desireClass == null)
            {
                return default(TClass);
            }

            var constructors = desireClass.GetConstructors();

            foreach (var constructor in constructors)
            {
                if (!CheckForConstructorInjection<TClass>())
                {
                    continue;
                }

                var inject = (InjectAttribute)constructor
                    .GetCustomAttributes(typeof(InjectAttribute), true)
                    .FirstOrDefault();

                var parameterTypes = constructor.GetParameters();
                var constructorParams = new object[parameterTypes.Length];

                var i = 0;

                foreach (var parameterType in parameterTypes)
                {
                    var named = parameterType.GetCustomAttributes(typeof(NamedAttribute));
                    Type dependacy = null;

                    if (named == null)
                    {
                        dependacy = this.module.GetMapping(parameterType.ParameterType, inject);
                    }
                    else
                    {
                        dependacy = this.module.GetMapping(parameterType.ParameterType, named);
                    }

                    if (parameterType.ParameterType.IsAssignableFrom(dependacy))
                    {
                        object instance = this.module.GetInstance(dependacy);
                        if (instance != null)
                        {
                            constructorParams[i++] = instance;
                        }
                        else
                        {
                            instance = Activator.CreateInstance(dependacy);
                            constructorParams[i++] = instance;
                            this.module.SetInstance(parameterType.ParameterType, instance);
                        }
                    }
                }
                return (TClass)Activator.CreateInstance(desireClass, constructorParams);
            }
            return default(TClass);
        }

        private TClass CreateFieldInjection<TClass>()
        {
            var desireClass = typeof(TClass);
            var desireClassInstance = this.module.GetInstance(desireClass);

            if (desireClassInstance == null)
            {
                desireClassInstance = Activator.CreateInstance(desireClass);
                this.module.SetInstance(desireClass, desireClassInstance);
            }

            var fields = desireClass.GetFields((BindingFlags)62);

            foreach (var field in fields)
            {
                if (field.GetCustomAttributes(typeof(InjectAttribute), true).Any())
                {
                    var injection = (InjectAttribute)field
                 .GetCustomAttributes(typeof(InjectAttribute), true)
                 .FirstOrDefault();

                    Type dependancy = null;

                    var named = field.GetCustomAttributes(typeof(NamedAttribute), true);
                    var type = field.FieldType;

                    if (named == null)
                    {
                        dependancy = this.module.GetMapping(type, injection);
                    }
                    else
                    {
                        dependancy = this.module.GetMapping(type, named); 
                    }

                    if (type.IsAssignableFrom(dependancy))
                    {
                        object instance = this.module.GetInstance(dependancy);

                        if (instance == null)
                        {
                            instance = Activator.CreateInstance(dependancy);
                            this.module.SetInstance(dependancy, instance);
                        }

                        field.SetValue(desireClassInstance, instance); 
                    }
                }
            }
            return (TClass)desireClassInstance; 
        }

        public TClass Inject<TClass>()
        {
            var hasConstructroAttribute = this.CheckForConstructorInjection<TClass>();
            var hasFieldAttribute = this.CheckForFieldInjection<TClass>();

            if (hasConstructroAttribute && hasFieldAttribute)
            {
                throw new ArgumentException("There must be only field or constructor annotated with Inject attribute"); 
            }

            if (hasConstructroAttribute)
            {
                return this.CreateConstructorInjection<TClass>(); 
            }
            else if (hasFieldAttribute)
            {
                return this.CreateFieldInjection<TClass>(); 
            }

            return default(TClass);
        }
    }
}
