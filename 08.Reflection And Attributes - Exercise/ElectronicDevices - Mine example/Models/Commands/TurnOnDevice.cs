using ElectronicDevices.Contracts;

namespace ElectronicDevices.Models.Commands
{
    public class TurnOnDevice : IExecutable
    {
        IElectronicDevice device;

        public TurnOnDevice(IElectronicDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            this.device.TurnOn();
        }
    }
}