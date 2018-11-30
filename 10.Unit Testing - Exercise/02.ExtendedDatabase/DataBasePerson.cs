using ExtendedDatabase.Contracts;
using System;
using System.Linq;

namespace ExtendedDatabase
{
    public class DataBasePerson
    {
        private const int DefaultCapacity = 16;

        private IPerson[] people;
        private int size;

        public DataBasePerson(params IPerson[] peopleInput)
        {
            this.people = new IPerson[DefaultCapacity];
            this.size = 0;
            this.SetInitialElements(peopleInput);
        }

        public int Size => this.size;

        private void SetInitialElements(params IPerson[] peopleInput)
        {
            if (peopleInput.Length > DefaultCapacity)
            {
                throw new InvalidOperationException("Invalid Capacity!");
            }

            foreach (var person in peopleInput)
            {
                this.Add(person);
            }
        }

        public void Add(IPerson person)
        {
            if (this.size >= DefaultCapacity)
            {
                throw new InvalidOperationException("No more space in the array!");
            }

            var containsUsername = this.people.Any(p => p != null && p.Username == person.Username);
            if (containsUsername)
            {
                throw new InvalidOperationException("Person with the same username already exists!");
            }

            var containsId = this.people.Any(p => p != null && p.ID == person.ID);
            if (containsId)
            {
                throw new InvalidOperationException("Person with the same ID already exists!");
            }

            this.people[size++] = person;
        }

        public void Remove()
        {
            if (this.size <= 0)
            {
                throw new InvalidOperationException("The collection is empty!");
            }
            this.people[--size] = null;
        }

        public IPerson[] Fetch() => this.people.Take(size).ToArray();

        public IPerson FindByUsername(string username)
        {
            if (username == null)
            {
                throw new ArgumentNullException("Invalid username!");
            }

            var targetPerson = this.people.FirstOrDefault(p => p != null && p.Username == username);

            if (targetPerson == null)
            {
                throw new InvalidOperationException("No person found with that username!");
            }

            return targetPerson;
        }

        public IPerson FindById(int Id)
        {
            if (Id < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid Id");
            }

            var targetPerson = this.people.FirstOrDefault(p => p != null && p.ID == Id);

            if (targetPerson == null)
            {
                throw new InvalidOperationException("No person found with that username!");
            }

            return targetPerson;
        }
    }
}