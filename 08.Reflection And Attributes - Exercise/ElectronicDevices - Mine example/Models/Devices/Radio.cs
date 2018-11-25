using ElectronicDevices.Contracts;
using System;

namespace ElectronicDevices.Models.Devices
{
   public class Radio : IElectronicDevice
    {
        private int volume;

        public Radio()
        {
            this.volume = 0;
        }

        public void ChangeChanel()
        {
            Console.WriteLine("Chanel has been changed!");
        }

        public void TurnOff()
        {
            Console.WriteLine("Radio Is Off");
        }

        public void TurnOn()
        {
            Console.WriteLine("Radio Is On");
        }

        public void VolumeDown()
        {
            this.volume--;
            Console.WriteLine("Volume of the radio is " + this.volume);
        }

        public void VolumeUp()
        {
            this.volume++;
            Console.WriteLine("Volume of the radio is " + this.volume);
        }

        public void OpenMenu()
        {
            Console.WriteLine("Menu is opened!");
        }
    }
}
