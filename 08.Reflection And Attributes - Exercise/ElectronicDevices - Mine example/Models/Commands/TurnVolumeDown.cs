using ElectronicDevices.Contracts; 

namespace ElectronicDevices.Models.Commands
{
    public class TurnVolumeDown : IExecutable
    {
        IElectronicDevice device;

        public TurnVolumeDown(IElectronicDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            this.device.VolumeDown();
        }
    }
}