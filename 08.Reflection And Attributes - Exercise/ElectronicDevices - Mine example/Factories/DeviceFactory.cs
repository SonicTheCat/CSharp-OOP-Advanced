using ElectronicDevices.Contracts;
using System;

namespace ElectronicDevices.Factories
{
    public class DeviceFactory
    {
        public IElectronicDevice CreateDevice(string type)
        {
            var typeName = Type.GetType("ElectronicDevices.Models.Devices." + type);
            return (IElectronicDevice)Activator.CreateInstance(typeName);
        }
    }
}