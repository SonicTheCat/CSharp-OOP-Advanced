public interface IGameController
{
    IExecutable ParseCommand(string[] data);
}