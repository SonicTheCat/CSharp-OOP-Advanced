using IntegrationTests.Contracts;
using System.Collections.Generic;
using System.Linq;
using System; 

namespace IntegrationTests.Models
{
    public class User : IName
    {
        private HashSet<Category> categories;

        public User()
        {
            this.categories = new HashSet<Category>(); 
        }

        public string Name { get; }

        public IReadOnlyCollection<Category> Categories => this.categories; 

        public void AssignUserToCategory(Category category)
        {
            this.categories.Add(category);
        }
    }
}