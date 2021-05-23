using System;
using System.Collections.Generic;
using MP04.СustomException;

namespace MP04.bag
{
    public class Company
    {
        private string name;
        private int yearOpened;
        private string specialisation;
        private readonly HashSet<Person> persons = new();

        public Company(string name, int yearOpened, string specialisation, Person person)
        {
            Name = name;
            YearOpened = yearOpened;
            Specialisation = specialisation;
            AddPerson(person);
        }

        public string Name { get => name; set => name = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Invalid first name") : value; }
        public int YearOpened { get => yearOpened; set => yearOpened = (value > 1500) ? value : throw new ModelValidationException(); }
        public string Specialisation { get => specialisation; set => specialisation = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Invalid specialisation") : value;}
        private HashSet<Person> Persons { get => new(persons);}

        public void AddPerson(Person person)
        {
            if (person == null)
            {
                throw new Exception("Person cannot be null");
            }
            if (persons.Contains(person))
            {
                return;
            }
            persons.Add(person);
            person.Company = this;
            CompanyPerson.AddEarnings(person, this);
        }

        public void RemovePerson(Person person)
        {
            if (persons.Count < 1)
            {
                throw new Exception("Nothing to remove");
            }
            if (!persons.Contains(person))
            {
                return;
            }
            persons.Remove(person);
            person.Company = null;
        }
    }
}