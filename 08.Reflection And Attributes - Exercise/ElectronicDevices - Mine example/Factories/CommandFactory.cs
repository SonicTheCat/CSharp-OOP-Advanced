using ElectronicDevices.Contracts;
using System;

namespace ElectronicDevices.Factories
{
    public class CommandFactory
    {
        public IExecutable CreateCommand(string type, IElectronicDevice device)
        {
            var typeName = Type.GetType("ElectronicDevices.Models.Commands." + type);
            return (IExecutable)Activator.CreateInstance(typeName, new object[] { device });
        }
    }
}