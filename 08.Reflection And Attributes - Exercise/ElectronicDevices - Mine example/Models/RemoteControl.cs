using ElectronicDevices.Contracts;

namespace ElectronicDevices.Models
{
    public class RemoteControl
    {
        IExecutable device;

        //The invoker does not know anything about a concrete command, it knows only about the command interface. 
        public RemoteControl(IExecutable executable)
        {
            this.device = executable; 
        }

        public void Press()
        {
            this.device.Execute(); 
        }
    }
}