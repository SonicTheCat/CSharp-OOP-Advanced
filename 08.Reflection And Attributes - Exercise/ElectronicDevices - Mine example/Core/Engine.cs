using ElectronicDevices.Factories;
using ElectronicDevices.Models;
using System;

namespace ElectronicDevices.Core
{
    public class Engine
    {
        private CommandFactory commandFactory;
        private DeviceFactory deviceFactory;
        private RemoteControl button;

        public Engine()
        {
            this.commandFactory = new CommandFactory();
            this.deviceFactory = new DeviceFactory();
        }

        public void Run()
        {
            var deviceType = Console.ReadLine();
            var device = this.deviceFactory.CreateDevice(deviceType);
            Console.WriteLine("You are using " + device.GetType().Name + ". Enter Your Command below!");

            while (true)
            {
                try
                {
                    var commandType = Console.ReadLine();

                    if (commandType == "STOP") break;
                    else if (commandType.ToLower() == "changedevice") this.Run();

                    var command = this.commandFactory.CreateCommand(commandType, device);

                    this.button = new RemoteControl(command);
                    button.Press();
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}