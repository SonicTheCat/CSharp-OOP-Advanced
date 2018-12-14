namespace Travel.Core.Contracts
{
	public interface IEngine
	{
		void Run();

		string ProcessCommand(string input);
	}
}