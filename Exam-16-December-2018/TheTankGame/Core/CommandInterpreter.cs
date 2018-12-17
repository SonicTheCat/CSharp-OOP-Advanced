namespace TheTankGame.Core
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private readonly IManager tankManager;

        public CommandInterpreter(IManager tankManager)
        {
            this.tankManager = tankManager;
        }

        public string ProcessInput(IList<string> inputParameters)
        {
            string command = inputParameters[0];
            var tokens = inputParameters.Skip(1).ToList();

            string result = string.Empty;

            var method = this.tankManager.GetType().GetMethods().FirstOrDefault(x => x.Name.Contains(command));

            result = (string)method.Invoke(this.tankManager, new object[] { tokens });

            return result;
        }
    }
}