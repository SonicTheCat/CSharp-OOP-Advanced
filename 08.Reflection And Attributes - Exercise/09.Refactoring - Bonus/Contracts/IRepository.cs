namespace InfernoInfinity.Contracts
{
    public interface IRepository
    {
        void AddWeapon(IWeapon weapon);

        IWeapon GetWeapon(string name);

        string PrintWeapon(IWeapon weapon);
    }
}
