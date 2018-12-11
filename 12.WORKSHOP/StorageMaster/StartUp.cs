namespace StorageMaster
{
    public class StartUp
    {
        public static void Main()
        {
            StorageMaster storage = new StorageMaster();
            Engine engine = new Engine(storage);
            engine.Run();
        }
    }
}