using System;

class StartUp
{
    static void Main()
    {
        CommandController controller = new CommandController();

        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                controller.Parse(input);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

