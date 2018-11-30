namespace CustomLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicList<string> dynamicList = new DynamicList<string>();

            dynamicList.Add("C#");
            dynamicList.Add("JS");
            dynamicList.Add("Python");
            dynamicList.Add("Java");

           // dynamicList.RemoveAt(2);
           // dynamicList.RemoveAt(1);
           // dynamicList.RemoveAt(1);
           // dynamicList.RemoveAt(0);

            dynamicList.Remove("C#");
            dynamicList.Remove("C#");
            dynamicList.Remove("Java");
        }
    }
}
