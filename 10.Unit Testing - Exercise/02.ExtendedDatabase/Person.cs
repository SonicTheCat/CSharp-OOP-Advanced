using ExtendedDatabase.Contracts;

namespace ExtendedDatabase
{
    public class Person : IPerson
    {
        public Person(int Id, string username)
        {
            this.ID = Id;
            this.Username = username; 
        }

        public int ID { get; }

        public string Username { get; }
    }
}
