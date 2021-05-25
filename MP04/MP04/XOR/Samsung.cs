using System;
using System.Collections.Generic;

namespace MP04.XOR
{
    public class Samsung : Company
    {
        private readonly HashSet<Person> employees = new();

        public Samsung(string city, string country, double capitalisation) : base(city, country, capitalisation)
        {

        }
        public HashSet<Person> Employees { get => new(employees);  }

        public void AddPerson(Person person)
        {
            if (person == null)
            {
                throw new Exception("Person cannot be null");
            }
            if (employees.Contains(person))
            {
                return;
            }
            employees.Add(person);
            person.Samsung = this;
        }

        public void RemovePerson(Person person)
        {
            if (employees.Count < 1)
            {
                throw new Exception("Nothing to remove");
            }
            if (!employees.Contains(person))
            {
                return;
            }
            employees.Remove(person);
            person.Samsung = null;
        }
    }
}