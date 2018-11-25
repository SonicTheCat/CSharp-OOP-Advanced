namespace ElectronicDevices.Contracts
{
    public interface IElectronicDevice
    {
        void TurnOn();

        void TurnOff();

        void VolumeUp();

        void VolumeDown();

        void ChangeChanel();

        void OpenMenu();
    }
}