namespace InfernoInfinity.Contracts
{
    using InfernoInfinity.Enums;
    using InfernoInfinity.Models.Gems;
    using System.Collections.Generic;

    public interface IWeapon
    {
        string Name { get; }

        int MinDemage { get; }

        int MaxDemage { get; }

        RarityLevel Rarity { get; }

        IReadOnlyCollection<IGem> Sockets { get; }

        void AddGem(IGem gem, int index);

        void RemoveGem(int index);
    }
}