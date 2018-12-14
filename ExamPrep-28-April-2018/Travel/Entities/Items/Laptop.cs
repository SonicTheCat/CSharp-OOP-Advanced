namespace Travel.Entities.Items
{
	public class Laptop : Item
	{
        private const int DefaultValue = 3000;

        public Laptop()
			: base(DefaultValue)
		{
		}
	}
}