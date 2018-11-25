namespace InfernoInfinity.Core.Commands
{ 
    using System;

    public class END : Command
    {
        public END(string[] data)
            : base(data)
        {
        }

        public override void Execute()
        {
            Environment.Exit(0); 
        }
    }
}