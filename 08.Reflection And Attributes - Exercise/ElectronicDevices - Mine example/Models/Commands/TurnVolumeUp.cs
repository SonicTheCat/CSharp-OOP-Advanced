using ElectronicDevices.Contracts; 

namespace ElectronicDevices.Models.Commands
{
    public class TurnVolumeUp : IExecutable
    {
        IElectronicDevice device;

        public TurnVolumeUp(IElectronicDevice device)
        {
            this.device = device;
        }

        public void Execute()
        {
            this.device.VolumeUp();
        }
    }
}