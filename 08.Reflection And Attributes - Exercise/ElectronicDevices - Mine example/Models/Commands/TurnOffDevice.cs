using ElectronicDevices.Contracts;

namespace ElectronicDevices.Models.Commands
{
    public class TurnOffDevice : IExecutable
    {
        IElectronicDevice device;

        public TurnOffDevice(IElectronicDevice device)
        {
            this.device = device; 
        }

        public void Execute()
        {
            this.device.TurnOff();
        }
    }
}