namespace P02_BlackBoxInteger
{
    using System;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var type = typeof(BlackBoxInteger);
            var flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var constructor = type.GetConstructor(flags, null, new Type[] { typeof(int) }, null);
            var instance = (BlackBoxInteger)constructor.Invoke(new object[] { 0 });

            var field = type.GetField("innerValue", flags);

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split("_");
                var methodName = tokens[0];
                var number = int.Parse(tokens[1]);

                MethodInfo method = type.GetMethod(methodName, flags);
                method.Invoke(instance, new object[] { number });

                Console.WriteLine(field.GetValue(instance));
            }
        }
    }
}