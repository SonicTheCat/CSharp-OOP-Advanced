namespace TheTankGame.Core
{
    using System;

    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                var input = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                try
                {
                    var result = this.commandInterpreter.ProcessInput(input);
                    this.writer.WriteLine(result); 
                }
                catch (Exception ex)
                {
                    this.writer.WriteLine(ex.Message); 
                }

                if (input[0] == "Terminate")
                {
                    break; 
                }
            }
        }
    }
}