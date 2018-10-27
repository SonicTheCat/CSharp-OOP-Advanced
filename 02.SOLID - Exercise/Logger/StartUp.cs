using System;

namespace OpenClosedLiskov
{
    class StartUp
    {
        static void Main()
        {
            int countOfAppenders = int.Parse(Console.ReadLine());
            var controller = new Controller();
            controller.Act(countOfAppenders);
        }
    }
}
