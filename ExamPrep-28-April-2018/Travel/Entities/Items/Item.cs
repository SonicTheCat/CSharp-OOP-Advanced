namespace Travel.Entities.Items
{
    using Contracts;

    public abstract class Item : IItem
    {
        protected Item(int value)
        {
            this.Value = value;
        }

        public int Value { get; private set; }
    }
}