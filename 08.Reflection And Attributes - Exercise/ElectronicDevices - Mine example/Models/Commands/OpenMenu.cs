using ElectronicDevices.Contracts;

namespace ElectronicDevices.Models.Commands
{
    public class OpenMenu : IExecutable
    {
        IElectronicDevice device;

        public OpenMenu(IElectronicDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            this.device.OpenMenu();
        }
    }
}
