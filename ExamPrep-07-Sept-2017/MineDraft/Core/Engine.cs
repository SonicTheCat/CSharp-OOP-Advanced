using System;

public class Engine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly ICommandInterpreter commandInterpreter;

    public Engine(IReader reader, IWriter writer, ICommandInterpreter commandInterpreter)
    {
        this.reader = reader;
        this.writer = writer;
        this.commandInterpreter = commandInterpreter;
    }

    public void Run()
    {
        while (true)
        {
            var input = reader.ReadLine()
                .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            try
            {
                var result = this.commandInterpreter.ProcessCommand(input);
                writer.WriteLine(result);

                if (input[0] == Constants.ShutdownString)
                {
                    Environment.Exit(0); 
                }
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message); 
            }
        }
    }
}