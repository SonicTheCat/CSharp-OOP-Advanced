using ElectronicDevices.Contracts;

namespace ElectronicDevices.Models.Commands
{
    public class ChangeChanel : IExecutable
    {
        IElectronicDevice device;

        public ChangeChanel(IElectronicDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            this.device.ChangeChanel();
        }
    }
}