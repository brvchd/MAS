using System;
using System.Collections.Generic;
using MP04.СustomException;

namespace MP04.bag
{
    public class CompanyPerson
    {
        private static Dictionary<Dictionary<Person, Company>, double> annualEarning;

        public static Dictionary<Dictionary<Person, Company>, double> AnnualEarning { get => new(annualEarning); set => annualEarning = value; }
        public static void AddEarnings(Person person, Company company, double salary = 2500)
        {
            if (salary < 0)
            {
                throw new ModelValidationException("salary cannot be negative");
            }
            if (person == null || company == null)
            {
                throw new ModelValidationException("Person or salary cannot be null");
            }
            var asd = new Dictionary<Person, Company>
            {
                { person, company }
            };
            AnnualEarning.Add(asd, salary);
        }
        public static double GetEarnings(Person person)
        {
            if (person == null)
            {
                throw new ModelValidationException("Person cannot be null");
            }
            var asd = new Dictionary<Person, Company>
            {
                { person, person.Company }
            };
            return AnnualEarning[asd];
        }
        public static void UpdateEarnings(Person person, double salary)
        {
            if (person == null || salary < 0)
            {
                throw new ModelValidationException("Person cannot be null");
            }
            var asd = new Dictionary<Person, Company>
            {
                { person, person.Company }
            };
            AnnualEarning[asd] = salary;
        }
    }
}