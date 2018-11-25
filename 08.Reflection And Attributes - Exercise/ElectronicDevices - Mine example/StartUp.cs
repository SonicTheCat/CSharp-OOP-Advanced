using ElectronicDevices.Core;

namespace ElectronicDevices
{
    public class StartUp
    {
        public static void Main()
        {
            //Here I made an example of Command Design Pattern

            /// Every Command Design Pattern has command, receiver, invoker and client. 
            /// In this case: 

            /// 1.Our receivers are the devices: MobilePhone, Tv, Radio 

            /// 2.Our commands are TurnTvOn, TurnTvOff, OpenMenu, ChangeChanel and ect. A command must implement a method Execute()!

            /// 3.Our invoker is the RemoteControl class. 
            ///      --- The invoker does not know anything about a concrete command, it knows only about the command interface. 

            /// 4.Our client is the Engine class
            ///     --- Invoker object(s), command objects and receiver objects are held by a client object, the client decides which receiver objects it assigns to the command objects, and which commands it assigns to the invoker.
            ///     --- The client decides which commands to execute at which points. To execute a command, it passes the command object to the invoker object.

            Engine engine = new Engine();
            engine.Run();
        }
    }
}