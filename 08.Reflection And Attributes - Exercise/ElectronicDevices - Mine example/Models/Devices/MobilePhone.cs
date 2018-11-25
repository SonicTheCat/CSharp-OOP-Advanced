using ElectronicDevices.Contracts;
using System;

namespace ElectronicDevices.Models.Devices
{
    public class MobilePhone : IElectronicDevice
    {
        private int volume;

        public MobilePhone()
        {
            this.volume = 0;
        }

        public void ChangeChanel()
        {
            Console.WriteLine("Mobile Phone channel has been changed!");
        }

        public void OpenMenu()
        {
            Console.WriteLine("Menu is opened!");
        }

        public void TurnOff()
        {
            Console.WriteLine("The phone Is Off");
        }

        public void TurnOn()
        {
            Console.WriteLine("The phone Is On");
        }

        public void VolumeDown()
        {
            this.volume--;
            Console.WriteLine("Volume of the phone is " + this.volume);
        }

        public void VolumeUp()
        {
            this.volume++;
            Console.WriteLine("Volume of the phone is " + this.volume);
        }
    }
}
