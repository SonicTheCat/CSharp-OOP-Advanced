using _03BarracksFactory.Contracts;
using _03BarracksFactory.Core.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace _03BarracksFactory.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private IServiceProvider serviceProvider;
        private CommandFactory factory;

        public CommandInterpreter(IServiceProvider service)
        {
            this.serviceProvider = service;
            this.factory = new CommandFactory();
        }

        public IExecutable InterpretCommand(string[] data)
        {
            return factory.CreateCommand(data, this.serviceProvider);
        }
    }
}