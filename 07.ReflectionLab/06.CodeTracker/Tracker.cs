using System;
using System.Reflection;

public class Tracker
{
    public static void PrintMethodsByAuthor()
    {
        var typeOfClass = typeof(StartUp);

        MethodInfo[] methods = typeOfClass
            .GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static);

        foreach (var method in methods)
        {
            var attributes = method.GetCustomAttributes<SoftUniAttribute>(); 

            foreach (SoftUniAttribute attr in attributes)
            {
                Console.WriteLine(method.Name + " is write by " + attr.Name);
            }
        }
    }
}