namespace TyrePressureMonitoringSystem.Contracts
{
    public interface IAlarm
    {
        bool AlarmOn { get; }

        void Check(); 
    }
}
