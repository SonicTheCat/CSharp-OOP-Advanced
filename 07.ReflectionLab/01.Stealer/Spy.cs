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
        //Console.WriteLine(classInstance.GetType().BaseType);

        foreach (var field in fields)
        {
            if (fieldsToInvestigate.Contains(field.Name))
            {
                //field.SetValue(classInstance, "private field was changed!");
                sb.AppendLine(field.Name + " = " + field.GetValue(classInstance));
            }
        }
        return sb.ToString().TrimEnd();
    }
}