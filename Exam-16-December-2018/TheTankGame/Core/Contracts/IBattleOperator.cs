using TheTankGame.Entities.Vehicles.Contracts;

namespace TheTankGame.Core.Contracts
{
    public interface IBattleOperator
    {
        string Battle(IVehicle attacker, IVehicle target);
    }
}