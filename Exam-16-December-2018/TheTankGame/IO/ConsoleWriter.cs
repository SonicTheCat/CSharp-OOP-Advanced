namespace TheTankGame.IO
{
    using System;
    using System.Text;
    using Contracts;

    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}