using System;
using System.Linq;
using System.Reflection;

namespace CreateCustomClassAttribute
{
    public class StartUp
    {
        public static void Main()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var types = assembly
                .GetTypes()
                .Where(x => x.GetCustomAttributes<CustomAttribute>().Any())
                .ToArray();

            foreach (var type in types)
            {
                var attr = type.GetCustomAttribute<CustomAttribute>();

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    switch (command)
                    {
                        case "Author":
                            Console.WriteLine($"Author: {attr.Author}");
                            break;
                        case "Revision":
                            Console.WriteLine($"Revision: {attr.Revision}");
                            break;
                        case "Description":
                            Console.WriteLine($"Class description: {attr.Description}");
                            break;
                        case "Reviewers":
                            Console.WriteLine($"Reviewers: {String.Join(", ", attr.Reviewers)}");
                            break;
                    }
                }
            }
        }
    }
}
