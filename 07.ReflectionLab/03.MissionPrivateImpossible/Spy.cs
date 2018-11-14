using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldsToInvestigate)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Class under investigation: " + className);

        var typeClass = Type.GetType(className);
        var fields = typeClass.GetFields(
            BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

        Object classInstance = Activator.CreateInstance(typeClass, new object[] { });

        foreach (var field in fields)
        {
            if (fieldsToInvestigate.Contains(field.Name))
            {
                sb.AppendLine(field.Name + " = " + field.GetValue(classInstance));
            }
        }
        return sb.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type typeClass = Type.GetType(className);

        StringBuilder sb = new StringBuilder();

        typeClass
            .GetFields(BindingFlags.Instance | BindingFlags.Public)
            .ToList()
            .ForEach(f => sb.AppendLine(f.Name + " must be private!"));

       typeClass
            .GetMethods(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(x => x.Name.StartsWith("get"))
            .ToList()
            .ForEach(x => sb.AppendLine(x.Name + " have to be public!"));

        typeClass
           .GetMethods(BindingFlags.Instance | BindingFlags.Public)
           .Where(x => x.Name.StartsWith("set"))
           .ToList()
           .ForEach(x => sb.AppendLine(x.Name + " have to be private!"));

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string className)
    {
        Type typeClass = Type.GetType(className);

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {typeClass.BaseType.Name}");

        MethodInfo[] classMethods = typeClass.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic); 

        foreach (var method in classMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim(); 
    }
}