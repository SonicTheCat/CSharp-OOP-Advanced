using System;

public class Engine : IEngine
{
    private const string EndCommand = "Enough! Pull back!";
    private const string OutputCommand = "Output";

    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IGameController gameController;

    public Engine(IGameController gameController, IReader reader, IWriter writer)
    {
        this.gameController = gameController;
        this.reader = reader;
        this.writer = writer;
    }

    public Engine(IGameController gameController)
        : this(gameController, new ConsoleReader(), new ConsoleWriter())
    {
    }

    public void Run()
    {
        while (true)
        {
            var input = this.reader.ReadLine();

            string[] data = null;

            if (input == EndCommand)
            {
                data = new[] { OutputCommand };
            }
            else
            {
                data = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            }

            try
            {
                var command = this.gameController.ParseCommand(data);
                command.Execute();
            }
            catch (Exception ex)
            {
                this.writer.WriteLine(ex.Message);
            }
        }
    }
}