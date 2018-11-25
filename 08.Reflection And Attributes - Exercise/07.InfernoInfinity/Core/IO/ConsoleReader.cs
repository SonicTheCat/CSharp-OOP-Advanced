namespace InfernoInfinity.Core.IO
{
    using InfernoInfinity.Contracts;
    using System;

    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}