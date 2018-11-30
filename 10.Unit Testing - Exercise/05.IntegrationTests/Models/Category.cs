using IntegrationTests.Contracts;
using System.Collections.Generic;

namespace IntegrationTests.Models
{
    public class Category : IName
    {
        private HashSet<User> users; 

        public Category(string name)
        {
            this.Name = name;
            this.users = new HashSet<User>();
        }

        public string Name { get; }

        public IReadOnlyCollection<User> Users => this.users; 

        public void AssignUserToCategory(User user)
        {
            this.users.Add(user); 
        }
    }
}