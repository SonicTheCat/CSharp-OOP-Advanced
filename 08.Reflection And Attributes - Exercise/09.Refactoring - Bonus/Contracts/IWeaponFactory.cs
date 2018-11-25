namespace InfernoInfinity.Contracts
{
    using InfernoInfinity.Enums;

    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string type, string name, RarityLevel rarityLevel);  
    }
}
