namespace FestivalManager.Entities.Sets
{
    using System;

    public class Long : Set
    {
        private const int MaxDurationMinutes = 60;

        public Long(string name)
            : base(name, new TimeSpan(0, MaxDurationMinutes, 0))
        {
        }
    }
}