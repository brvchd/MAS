using System.Collections.Generic;
using MP04.СustomException;

namespace MP04.Ordered
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private readonly List<Person> queueToUrzad = new();

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            
        }

        public string FirstName { get => firstName; set => firstName = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Invalid first name") : value; }
        public string LastName { get => lastName; set => lastName = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Invalid last name") : value;  }
        public List<Person> QueueToUrzad { get => new(queueToUrzad); }

        public void AddToWaitingLine(Person person)
        {
            queueToUrzad.Add(person);
            if (queueToUrzad.Count > 1)
            {
                queueToUrzad.Sort((x, y) => string.Compare(x.FirstName, y.FirstName));
            }
            
        }

        public void RemoveFromWaitingLine(Person person)
        {
            if(!queueToUrzad.Contains(person))
            {
                return;
            }
            queueToUrzad.Remove(person);
            if (queueToUrzad.Count > 1)
            {
                queueToUrzad.Sort((x, y) => string.Compare(x.FirstName, y.FirstName));
            }
        }
    }
}