namespace FestivalManager.Entities.Sets
{
	using System;

	public class Short : Set
	{
        private const int MaxDurationMinutes = 15;

        public Short(string name) 
			: base(name, new TimeSpan(0, MaxDurationMinutes, 0))
		{
		}
	}
}