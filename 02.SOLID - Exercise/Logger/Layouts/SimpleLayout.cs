using OpenClosedLiskov.Contracts; 

namespace OpenClosedLiskov.Models
{
    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}"; 
    }
}