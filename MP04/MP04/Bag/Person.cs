using MP04.СustomException;

namespace MP04.bag
{
    public class Person
    {
        private string firstName;
        private string lastName;
        private string city;
        private string country;
        private Company company;

        public Person(string firstName, string lastName, string city, string country, Company company = null)
        {
            FirstName = firstName;
            LastName = lastName;
            City = city;
            Country = country;
            Company = company;
        }

        public string FirstName { get => firstName; set => firstName = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Invalid first name") : value; }
        public string LastName { get => lastName; set => lastName = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Invalid last name") : value; }
        public string City { get => city; set => city = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Invalid city") : value; }
        public string Country { get => country; set => country = string.IsNullOrWhiteSpace(value) ? throw new ModelValidationException("Invalid country") : value; }
        public Company Company
        {
            get => company; set
            {
                if (company == null && value != null)
                {
                    SetAssosiation(value);
                }
                else if (company != null && value == null)
                {
                    RemoveAssosiation();
                }
                else if (company != null && value != null)
                {
                    RemoveAssosiation();
                    SetAssosiation(value);
                }
            }
        }

        public void RemoveAssosiation()
        {
            Company tmp = company;
            company = null;
            tmp.RemovePerson(this);
        }
        public void SetAssosiation(Company cmp)
        {
            company = cmp;
            company.AddPerson(this);
        }
    }
}