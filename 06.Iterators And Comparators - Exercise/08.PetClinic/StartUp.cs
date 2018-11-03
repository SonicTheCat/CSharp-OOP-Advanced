using System;
using System.Linq;

namespace _08.PetClinic
{
   public class StartUp
    {
        static void Main()
        {
            int countOfLines = int.Parse(Console.ReadLine());
            Controller controller = new Controller();

            for (int i = 0; i < countOfLines; i++)
            {
                var tokens = Console.ReadLine().Split();
                var command = tokens[0];
                tokens = tokens.Skip(1).ToArray(); 

                try
                {
                    switch (command)
                    {
                        case "Create": controller.Create(tokens); break;
                        case "Add": controller.Add(tokens); break;
                        case "Release": controller.Release(tokens[0]); break;
                        case "HasEmptyRooms": controller.HasEmptyRooms(tokens[0]); break;
                        case "Print": controller.PreparePrint(tokens); break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}