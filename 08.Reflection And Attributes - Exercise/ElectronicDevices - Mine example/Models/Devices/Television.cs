using ElectronicDevices.Contracts;
using System;

namespace ElectronicDevices.Models.Devices
{
    public class Television : IElectronicDevice
    {
        private int volume;

        public Television()
        {
            this.volume = 0; 
        }

        public void ChangeChanel()
        {
            Console.WriteLine("Chanel has been changed!");
        }

        public void TurnOff()
        {
            Console.WriteLine("TV Is Off");
        }

        public void TurnOn()
        {
            Console.WriteLine("TV Is On");
        }

        public void VolumeDown()
        {
            this.volume--;
            Console.WriteLine("Volume is " + this.volume);
        }

        public void VolumeUp()
        {
            this.volume++;
            Console.WriteLine("Volume is " + this.volume);
        }

        public void OpenMenu()
        {
            Console.WriteLine("Menu is opened!");
        }
    }
}